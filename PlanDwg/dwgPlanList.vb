#If ARX_APP Then
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.ApplicationServices
#Else
Imports Teigha.Geometry
Imports Teigha.DatabaseServices
Imports Bricscad.ApplicationServices
#End If

Imports System.Collections.Generic
''' <summary>
''' для упорядочивания образа слоев по началу
''' </summary>
''' <remarks></remarks>
Public Class ComparatorPlanList
	'
	Implements IComparer(Of dwgPlanList)

	Public Function Compare(ByVal x As dwgPlanList, ByVal y As dwgPlanList) As Integer Implements System.Collections.Generic.IComparer(Of dwgPlanList).Compare


		Return x.DistanzOtNachala.CompareTo(y.DistanzOtNachala)


	End Function

	Shared Sub SearchAndInsert(
ByVal lis As List(Of dwgPlanList),
ByVal insert As dwgPlanList, ByVal dc As IComparer(Of dwgPlanList))



		Dim index As Integer = lis.BinarySearch(insert, dc)

		If index < 0 Then
			index = index Xor -1
			lis.Insert(index, insert)
		End If
	End Sub
End Class
Public Class dwgPlanList
    Private wPolylineTrass As SwajzPolylineRasst
    Private wPolylineEkran As Polyline
    Private wPoints As Point3dCollection 'точки пересечения полилинии границы экрана с полилинией плана
    Private wDistanze As List(Of Double) 'расстояния от от начала полилинии трассы до точки пересечения
    Private wVector As Vector3dCollection 'вектор направления траcсы в точки пересечения
    Private wPointZentr As Point3d   'геометрический центр полилинии
    Private wNiz, wWerh As Point2d 'Границы области представляемой экраном в области модели
    Private wNizVportList As Point3d
    Sub New(ipolylineTrass As SwajzPolylineRasst, iPolyline As Polyline)
        wPolylineEkran = iPolyline
        wPolylineTrass = ipolylineTrass
        wPoints = New Point3dCollection
        wVector = New Vector3dCollection
        wDistanze = New List(Of Double)
        iPolyline.IntersectWith(ipolylineTrass.LwPolyLine, Intersect.ExtendThis, wPoints, IntPtr.Zero, IntPtr.Zero)
        'If wPoints.Count < 2 Then
        '    Application.ShowAlertDialog(Me.ToString & "  Точек пересечения меньше 2 " & wPoints.Count)
        'End If
        For Each elp As Point3d In wPoints
            Dim r As Double = wPolylineTrass.LwPolyLine.GetDistAtPoint(elp)
            wDistanze.Add(r)
            wVector.Add(wPolylineTrass.DirectionWTchk(r))
        Next
        OpredZentr()
        InitViewPort()
    End Sub
    ReadOnly Property EstPeresechenij As Boolean
        Get
            If wDistanze.Count > 0 Then Return True Else Return False
          
        End Get
    End Property

    ReadOnly Property Bounds() As Extents3d
        Get
            Return wPolylineEkran.Bounds
        End Get
    End Property

    Private Sub OpredZentr()
        Dim sumX, sumY, sumz As Double
        Dim i As Integer = 0
        Dim lSpTchk As New Point3dCollection
        Dim lKolwo As Integer = wPolylineEkran.NumberOfVertices

        Do Until i = lKolwo
            Dim lpoint As Point3d = wPolylineEkran.GetPoint3dAt(i)
            lSpTchk.Add(lpoint)
            sumX += lpoint.X
            sumY += lpoint.Y
            sumz += lpoint.Z
            i += 1
        Loop
        wPointZentr = New Point3d(sumX / lKolwo, sumY / lKolwo, sumz / lKolwo)
        '    wPolylineEkran.GeometricExtents.  
    End Sub
    Private Function opredTozkiStrelki(NumI As Integer, iRazmer As Double) As Point2dCollection
        Dim lpoint As Point3d = Me.wPoints(NumI)
        Dim lvector As Vector3d = Me.wVector(NumI)
        Dim lr As Double = Me.wDistanze(NumI)
        Dim lpointGr As Point3d = Me.wPolylineTrass.LwPolyLine.GetPointAtDist(lr + iRazmer)
        Dim lvectorPerp As Vector3d = lvector.GetPerpendicularVector
        Dim pointGr As New Point2dCollection
        pointGr.Add(New Point2d(lpointGr.X + 3 * lvectorPerp.X, lpointGr.Y + 3 * lvectorPerp.Y))
        pointGr.Add(New Point2d(lpoint.X, lpoint.Y))
        pointGr.Add(New Point2d(lpointGr.X - 3 * lvectorPerp.X, lpointGr.Y - 3 * lvectorPerp.Y))
        Return pointGr

    End Function

    Sub WiwestiMLeader(collDb As DBObjectCollection)
        Dim i As Integer = 0
        For Each elp As Point3d In wPoints
            Dim vectorNapr As New Vector3d(elp.X - wPointZentr.X, elp.Y - wPointZentr.Y, 0)
            Dim vectornorm = vectorNapr.GetNormal()
            Dim lrast As Double = wPolylineTrass.LwPolyLine.GetDistAtPoint(elp)
            Dim lstrText As String = clsPrf.ClsPiket.StrPiketaj(wPolylineTrass.DistanzePolylineToPiketajProfilaj(lrast))
            Dim lpKonMLeader As Point3d = New Point3d(elp.X - 25 * vectornorm.X, elp.Y - 25 * vectornorm.Y, 0)
            Dim elMleader As MLeader = CType(BazDwg.dbPrim.CreateMLeader(lpKonMLeader, elp, lstrText), MLeader)
            collDb.Add(elMleader)
            collDb.Add(BazDwg.dbPrim.CreateLwPolyline(opredTozkiStrelki(i, 9)))
            collDb.Add(BazDwg.dbPrim.CreateLwPolyline(opredTozkiStrelki(i, -9)))

        Next
    End Sub
    ReadOnly Property GrBeg() As Double
        Get
            If wPoints.Count > 1 Then
                If wDistanze(0) < wDistanze(1) Then
                    Return wDistanze(0)
                Else
                    Return wDistanze(1)
                End If
            End If
            If wDistanze(0) > wPolylineTrass.LwPolyLine.Length - wDistanze(0) Then Return wDistanze(0) Else Return -1


        End Get
    End Property
    ReadOnly Property GrEnd() As Double
        Get
            If wPoints.Count > 1 Then
                If wDistanze(0) < wDistanze(1) Then
                    Return wDistanze(1)
                Else
                    Return wDistanze(0)
                End If
            End If
            If wDistanze(0) < wPolylineTrass.LwPolyLine.Length - wDistanze(0) Then Return wDistanze(0) Else Return -1


        End Get
    End Property
    ReadOnly Property NameVPoints() As String
        Get
            If wPoints.Count = 0 Then Return ""
            If wPoints.Count > 1 Then
                Dim lmenshe, lbolshe As Double
                If wDistanze(0) < wDistanze(1) Then
                    lmenshe = wDistanze(0)
                    lbolshe = wDistanze(1)
                Else
                    lmenshe = wDistanze(1)
                    lbolshe = wDistanze(0)

                End If
                Dim lpikBeg As Double = wPolylineTrass.DistanzePolylineToPiketajProfilaj(lmenshe)
                Dim lpikEnd As Double = wPolylineTrass.DistanzePolylineToPiketajProfilaj(lbolshe)
                Return clsPrf.ClsPiket.StrPiketaj(lpikBeg) & "-" & clsPrf.ClsPiket.StrPiketaj(lpikEnd)
            Else
                If wDistanze(0) < wPolylineTrass.LwPolyLine.Length - wDistanze(0) Then
                    Return wPolylineTrass.BegTrass.NamePiket & clsPrf.ClsPiket.StrPiketaj(wPolylineTrass.DistanzePolylineToPiketajProfilaj(wDistanze(0)))
                Else
                    Return clsPrf.ClsPiket.StrPiketaj(wPolylineTrass.DistanzePolylineToPiketajProfilaj(wDistanze(0))) & wPolylineTrass.EndTrass.NamePiket

                End If
            End If
        End Get
    End Property
	ReadOnly Property DistanzOtNachala As Double
		Get
			If wPoints.Count = 0 Then Return 0
			If wPoints.Count > 1 Then

				If wDistanze(0) < wDistanze(1) Then
					Return wDistanze(0)

				Else
					Return wDistanze(1)


				End If

			Else
				Return wDistanze(0)
			End If
		End Get
	End Property
#Region "ViewPort"
	Shared Function WiwestiViewPort(iPolyline As Polyline) As ObjectId
        Dim lExt As Extents3d = iPolyline.Bounds

        Dim lNiz As Point2d = New Point2d(lExt.MinPoint.X, lExt.MinPoint.Y)
        Dim lwerh As Point2d = New Point2d(lExt.MaxPoint.X, lExt.MaxPoint.Y)
        Dim LwidEkran As New BazDwg.dwgWidEkranScale(lNiz, lwerh, New Point3d(10, 10, 0), 0.5)
        Return LwidEkran.WiwestiNaList
    End Function
    Shared Function WiwestiViewPort(iPolyline As Polyline, iX As Double, iY As Double) As ObjectId
        Dim lExt As Extents3d = iPolyline.Bounds

        Dim lNiz As Point2d = New Point2d(lExt.MinPoint.X, lExt.MinPoint.Y)
        Dim lwerh As Point2d = New Point2d(lExt.MaxPoint.X, lExt.MaxPoint.Y)
        Dim LwidEkran As New BazDwg.dwgWidEkranScale(lNiz, lwerh, New Point3d(iX, iY, 0), 1.5)
        Return LwidEkran.WiwestiNaList
    End Function

    Sub InitViewPort()
        Dim lExt As Extents3d = wPolylineEkran.Bounds
        wNiz = New Point2d(lExt.MinPoint.X, lExt.MinPoint.Y)
        wWerh = New Point2d(lExt.MaxPoint.X, lExt.MaxPoint.Y)
        wNizVportList = New Point3d(20, 20, 0)
    End Sub
    Function WiwestiViewPort() As ObjectId

        Dim LwidEkran As New BazDwg.dwgWidEkran(wNiz, wWerh, wNizVportList)
        Return LwidEkran.WiwestiNaList
    End Function
    Private Function GetObjectCollectionPoint2d() As Point2dCollection
        Dim lpoint2d As New Point2dCollection
        Dim lKolwo As Integer = wPolylineEkran.NumberOfVertices
        Dim i As Integer = 0
        Do Until i = lKolwo
            Dim lp2d As Point2d = wPolylineEkran.GetPoint2dAt(i)
            lpoint2d.Add(New Point2d(lp2d.X - wNiz.X + wNizVportList.X, lp2d.Y - wNiz.Y + wNizVportList.Y))

            i += 1
        Loop
        Return lpoint2d
    End Function
    Function WiwestiViewPortClip() As ObjectId


        Dim LwidEkran As New BazDwg.dwgWidEkranScale(wNiz, wWerh, wNizVportList, 0.5)
        Return LwidEkran.WiwestiNaListClip(GetObjectCollectionPoint2d)
    End Function
    Function WiwestiViewPortClip(iScaleVidEkran As Double) As ObjectId


        Dim LwidEkran As New BazDwg.dwgWidEkranScale(wNiz, wWerh, wNizVportList, iScaleVidEkran)
        Return LwidEkran.WiwestiNaListClip(GetObjectCollectionPoint2d)
    End Function
#End Region
End Class
Public Class dwgVidEkranPoPolyline

    Private wPolylineEkran As Polyline

    Private wNiz, wWerh As Point2d 'Границы области представляемой экраном в области модели
    Private wNizVportList As Point3d
    Private wScale As Double
    Sub New(iPolyline As Polyline, iPointNizVportWListe As Point3d, iScale As Double)
        wPolylineEkran = iPolyline
        wNizVportList = iPointNizVportWListe
        wScale = iScale
        InitViewPort()
    End Sub







#Region "ViewPort"


    Sub InitViewPort()
        Dim lExt As Extents3d = wPolylineEkran.Bounds
        wNiz = New Point2d(lExt.MinPoint.X, lExt.MinPoint.Y)
        wWerh = New Point2d(lExt.MaxPoint.X, lExt.MaxPoint.Y)

    End Sub
    Function WiwestiViewPort() As ObjectId

        Dim LwidEkran As New BazDwg.dwgWidEkran(wNiz, wWerh, wNizVportList)
        Return LwidEkran.WiwestiNaList
    End Function
    Private Function GetObjectCollectionPoint2d() As Point2dCollection
        Dim lpoint2d As New Point2dCollection
        Dim lKolwo As Integer = wPolylineEkran.NumberOfVertices
        Dim i As Integer = 0
        Do Until i = lKolwo
            Dim lp2d As Point2d = wPolylineEkran.GetPoint2dAt(i)
            lpoint2d.Add(New Point2d(lp2d.X - wNiz.X + wNizVportList.X, lp2d.Y - wNiz.Y + wNizVportList.Y))

            i += 1
        Loop
        Return lpoint2d
    End Function
    Function WiwestiViewPortClip() As ObjectId


        Dim LwidEkran As New BazDwg.dwgWidEkranScale(wNiz, wWerh, wNizVportList, wScale)
        Return LwidEkran.WiwestiNaListClip(GetObjectCollectionPoint2d)
    End Function
#End Region
End Class