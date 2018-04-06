#If ARX_APP Then
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.EditorInput
#Else
Imports Teigha.Geometry
Imports Teigha.DatabaseServices
Imports Bricscad.ApplicationServices
Imports Bricscad.EditorInput
#End If




Imports BazDwg

Public Class Razrez
	Private wTochkaPeresechenijX, wTolschina As Double
	Private wYmin As Double, wYmax As Double

	ReadOnly Property MinTochka As Point3d
		Get
			Return New Point3d(wTochkaPeresechenijX, wYmin, 0)
		End Get
	End Property
	ReadOnly Property MaxTochka As Point3d
		Get
			Return New Point3d(wTochkaPeresechenijX, wYmax, 0)
		End Get
	End Property
	ReadOnly Property MinTochka2D As Point2d
		Get
			Return New Point2d(wTochkaPeresechenijX, wYmin)
		End Get
	End Property
	ReadOnly Property MaxTochka2D As Point2d
		Get
			Return New Point2d(wTochkaPeresechenijX, wYmax)
		End Get
	End Property
	ReadOnly Property Ymax As Double
		Get
			Return wYmax
		End Get
	End Property
	ReadOnly Property Ymin As Double
		Get
			Return wYmin
		End Get
	End Property
	ReadOnly Property Tolschina As Double
		Get
			Return wTolschina
		End Get
	End Property


	Function KoeffSowpadeniePoY(izadan As Razrez) As Double
		Dim lYmax As Double = Math.Min(izadan.wYmax, wYmax)
		Dim lymin As Double = Math.Max(izadan.wYmin, wYmin)




		Return (lYmax - lymin)
	End Function
	Sub New(iPointN As Point2d, ipointW As Point2d)
		wYmin = iPointN.Y
		wYmax = ipointW.Y
		wTochkaPeresechenijX = 0.5 * (iPointN.X + ipointW.X)
		wTolschina = wYmax - wYmin
	End Sub
	Sub New(iX As Double, iYmax As Double, iYmin As Double)
		If iYmax > iYmin Then
			wYmin = iYmin
			wYmax = iYmax
		Else
			wYmin = iYmax
			wYmax = iYmin
		End If
		wTochkaPeresechenijX = iX
		wTolschina = wYmax - wYmin
	End Sub
End Class
Public Class OgranHatch

	Private wRastOtNachalaDwgBeg, wRastOtNachalaDwgEnd, wNachaloPoYBeg, wNachalopoYEnd As Double    '
	Private wAlgDjaris As AlgDjarvis
#Region " Read onlu"
	ReadOnly Property RastOtNachalaDwgBeg As Double
		Get
			Return wRastOtNachalaDwgBeg
		End Get
	End Property
	ReadOnly Property RastOtNachalaDwgEnd As Double
		Get
			Return wRastOtNachalaDwgEnd
		End Get
	End Property
	ReadOnly Property OtmetkaDwgEnd As Double
		Get
			Return wNachalopoYEnd
		End Get
	End Property
	ReadOnly Property OtmetkaDwgBeg As Double
		Get
			Return wNachaloPoYBeg
		End Get
	End Property
	ReadOnly Property LewPeresechenie As Razrez
		Get
			Return New Razrez(wAlgDjaris.LewNijn, wAlgDjaris.LewVerh)
		End Get
	End Property
	ReadOnly Property PrawPeresechenie As Razrez
		Get
			Return New Razrez(wAlgDjaris.PrawNijn, wAlgDjaris.PrawVerh)
		End Get
	End Property
	ReadOnly Property DlinaOgranHatch As Double
		Get
			Return wRastOtNachalaDwgEnd - wRastOtNachalaDwgBeg
		End Get
	End Property

#End Region
#Region "Операции"
	Private Function GlubinaXdwg(iX As Double, iGlubinaBeg As Double, iglubinaEnd As Double) As Double
		If iX < wRastOtNachalaDwgBeg Then Return iGlubinaBeg
		If iX > wRastOtNachalaDwgEnd Then Return iglubinaEnd
		Dim delta As Double = iX - wRastOtNachalaDwgBeg

		Return iGlubinaBeg + delta * (iglubinaEnd - iGlubinaBeg) / (wRastOtNachalaDwgEnd - wRastOtNachalaDwgBeg)
	End Function
	'Private Function IzmRastojniedwg(iX As Double, iRasstNewBeg As Double, iRasstNewEnd As Double) As Double
	'    If iX < wRastOtNachalaDwgBeg Then iX = wRastOtNachalaDwgBeg
	'    If iX > wRastOtNachalaDwgEnd Then iX = wRastOtNachalaDwgEnd
	'    Dim ldlina = wRastOtNachalaDwgEnd - wRastOtNachalaDwgBeg ' может стоит ввести переменную wdlina
	'    Dim ldlinaNew = iRasstNewEnd - iRasstNewBeg
	'    Dim lbetta = ldlinaNew / ldlina
	'    Dim lalfa = iRasstNewBeg - lbetta * wRastOtNachalaDwgBeg

	'    Return lalfa + lbetta * iX
	'End Function

	'Sub IzmenitPoljnie(iRasstBeg As Double, iRasstEnd As Double, iLinprof As GrebenProfilDwg)
	'    Dim luchIshod As List(Of Point2d) = iLinprof.GetUchastokLinii(wRastOtNachalaDwgBeg, wRastOtNachalaDwgEnd)
	'    Dim lWerhGlubBeg = luchIshod.First.Y - wNachaloPoYBeg
	'    Dim lNijnGlubBeg = luchIshod.First.Y - wAlgDjaris.LewNijn.Y
	'    Dim lWerhGlubEnd = luchIshod.Last.Y - wNachalopoYEnd
	'    Dim lNijnGlubEnd = luchIshod.Last.Y - wAlgDjaris.PrawNijn.Y

	'    Dim lwerh As New List(Of Point2d)
	'    For Each el As Point2d In wAlgDjaris.GetWerhGraniza
	'        Dim lXnew = IzmRastojniedwg(el.X, iRasstBeg, iRasstEnd)
	'        Dim lynew = iLinprof.GetPointLinii(el.X).Y - GlubinaXdwg(el.X, lWerhGlubBeg, lWerhGlubEnd)
	'        lwerh.Add(New Point2d(lXnew, lynew))

	'    Next
	'    Dim lniz As New List(Of Point2d)
	'    For Each el As Point2d In wAlgDjaris.GetNijnijGraniza
	'        Dim lXnew = IzmRastojniedwg(el.X, iRasstBeg, iRasstEnd)
	'        Dim lynew = iLinprof.GetPointLinii(el.X).Y - GlubinaXdwg(el.X, lNijnGlubBeg, lNijnGlubEnd)
	'        lniz.Add(New Point2d(lXnew, lynew))

	'    Next
	'    wAlgDjaris.ZamenitWerhiNiz(lwerh, lniz)
	'End Sub
	'Sub Sdwinut(idelta As Double, ilinProf As GrebenProfilDwg)
	'    IzmenitPoljnie(wRastOtNachalaDwgBeg + idelta, wRastOtNachalaDwgEnd + idelta, ilinProf)
	'End Sub
#End Region
#Region "Конструирование"
	Sub New(Isp As List(Of Point2d))
		wAlgDjaris = New AlgDjarvis(Isp)

		wAlgDjaris.Algoritm()
		UstanovitPoAlgDjarvis()
	End Sub

	Sub New(iEntiy As Entity)

		Dim lWerh As New List(Of Point2d)
		With iEntiy.GeometricExtents
			lWerh.Add(New Point2d(.MinPoint.X, .MinPoint.Y))
			lWerh.Add(New Point2d(.MinPoint.X, .MaxPoint.Y))
			lWerh.Add(New Point2d(.MaxPoint.X, .MinPoint.Y))
			lWerh.Add(New Point2d(.MaxPoint.X, .MaxPoint.Y))
		End With
		wAlgDjaris = New AlgDjarvis(lWerh)
		wAlgDjaris.Algoritm()
		UstanovitPoAlgDjarvis()
	End Sub

	Private Sub UstanovitPoAlgDjarvis()

		With wAlgDjaris
			wNachaloPoYBeg = .LewVerh.Y
			wNachalopoYEnd = .PrawVerh.Y
			wRastOtNachalaDwgBeg = .LewVerh.X
			wRastOtNachalaDwgEnd = .PrawVerh.X
		End With

	End Sub

#End Region
#Region "Get"
	Function GetPeresechenie(ix As Double) As Razrez
		If ix < wRastOtNachalaDwgBeg Then Return Nothing
		If ix > wRastOtNachalaDwgEnd Then Return Nothing
		'Dim Delta = ix - wRastOtNachalaDwgBeg
		'Dim wdlina = wRastOtNachalaDwgEnd - wRastOtNachalaDwgBeg
		'If wdlina < 0.01 Then
		'    wdlina = 0.01
		'End If
		With wAlgDjaris
			Dim lGrPoint = wAlgDjaris.PointGr(ix)
			Dim lymin As Double = lGrPoint(1).Y
			Dim lymax As Double = lGrPoint(0).Y
			Return New Razrez(New Point2d(ix, lymin), New Point2d(ix, lymax))
		End With



	End Function

	Function GetOgrPolyline() As Polyline
		Dim lPolyline As New Polyline
		lPolyline.Closed = True
		With wAlgDjaris
			lPolyline.AddVertexAt(0, .LewNijn, 0, 0, 0)
			lPolyline.AddVertexAt(1, .LewVerh, 0, 0, 0)
			lPolyline.AddVertexAt(2, .PrawVerh, 0, 0, 0)
			lPolyline.AddVertexAt(3, .PrawNijn, 0, 0, 0)
			lPolyline.AddVertexAt(4, .LewNijn, 0, 0, 0)
		End With


		Return lPolyline
	End Function
	Function GetWneschnijPoDlaris() As Polyline

		Return wAlgDjaris.GetWneschnijKontur
	End Function

#End Region



End Class
Public Class clsHatch
	Private wHatch As Hatch
	Private wWneschnijKontur As Polyline
	Private wOgranHatch As OgranHatch
	Private wSumPolyline As New List(Of Polyline)
#Region "new"
	Sub New(iHatch As clsHatch)
		With iHatch

			wHatch = .wHatch
			wWneschnijKontur = .wWneschnijKontur
			wSumPolyline = .wSumPolyline
			wOgranHatch = .wOgranHatch
		End With
	End Sub
	Private Sub SamijWneschnijKontur()
		Dim lKolwoLoop As Integer = wHatch.NumberOfLoops
		' Dim lNameHatch As String = wHatch.PatternName
		'   Application.ShowAlertDialog(.LoopType.ToString)
		Dim lhatchLoop As HatchLoop = Nothing
		Dim lMaxDlina As Double = -100000
		wWneschnijKontur = Nothing

		Dim lLooptipe As HatchLoopTypes = HatchLoopTypes.Default
		For J As Integer = 0 To lKolwoLoop - 1
			lhatchLoop = wHatch.GetLoopAt(J)
			If Not (CBool(lhatchLoop.LoopType And HatchLoopTypes.Outermost) Or CBool(lhatchLoop.LoopType And HatchLoopTypes.External)) Then
				Continue For
			End If
			If CBool(lhatchLoop.LoopType And HatchLoopTypes.Textbox) Or CBool(lhatchLoop.LoopType And HatchLoopTypes.TextIsland) Then
				Continue For
			End If
			Dim lhatchLoopBulge As BulgeVertexCollection = lhatchLoop.Polyline
			Dim lhatchCurves As Curve2dCollection = lhatchLoop.Curves
			Dim colPointCurves As New Point3dCollection
			Dim lPolyline As Polyline
			If lhatchLoopBulge IsNot Nothing Then

				lPolyline = ParamHatch.PoBugle2DPolyLineLW(lhatchLoopBulge)



			Else


				lPolyline = ParamHatch.PoCurve2DPolyLineLW(lhatchCurves)



			End If
			wSumPolyline.Add(lPolyline)
			If lPolyline.NumberOfVertices > 1 AndAlso lPolyline.Length > lMaxDlina Then
				lMaxDlina = lPolyline.Length
				wWneschnijKontur = lPolyline

				lLooptipe = lhatchLoop.LoopType
			End If
		Next



	End Sub

	Private Sub NajtiPoX(colCurve As Curve2dCollection, Sp As List(Of Point2d))


		For Each el As Curve2d In colCurve
			If TypeOf (el) Is LineSegment2d Then
				Dim lsegment As LineSegment2d = CType(el, LineSegment2d)

				Sp.Add(lsegment.StartPoint)
				'  Gr.addPoint(lsegment.EndPoint)



			End If


		Next

	End Sub
	Private Sub NajtiPoX(collBugle As BulgeVertexCollection, Sp As List(Of Point2d))


		For Each el As BulgeVertex In collBugle
			Sp.Add(el.Vertex)
		Next

	End Sub
	Private Function GrHatch() As OgranHatch
		Dim lKolwoLoop As Integer = wHatch.NumberOfLoops
		Dim lNameHatch As String = wHatch.PatternName
		'   Application.ShowAlertDialog(.LoopType.ToString)
		Dim lhatchLoop As HatchLoop = Nothing

		Dim lSpPoint2dHatch As New List(Of Point2d)

		For J As Integer = 0 To lKolwoLoop - 1
			lhatchLoop = wHatch.GetLoopAt(J)
			If Not (CBool(lhatchLoop.LoopType And HatchLoopTypes.Outermost) Or CBool(lhatchLoop.LoopType And HatchLoopTypes.External)) Then
				Continue For
			End If
			If CBool(lhatchLoop.LoopType And HatchLoopTypes.Textbox) Or CBool(lhatchLoop.LoopType And HatchLoopTypes.TextIsland) Then
				Continue For
			End If


			Dim lhatchBulgeVertext As BulgeVertexCollection = lhatchLoop.Polyline
			Dim lhatchCurves As Curve2dCollection = lhatchLoop.Curves

			Dim lIndex As Integer = 0
			If lhatchBulgeVertext IsNot Nothing Then
				NajtiPoX(lhatchBulgeVertext, lSpPoint2dHatch)


			Else
				NajtiPoX(lhatchCurves, lSpPoint2dHatch)

			End If
		Next

		Dim lOgrHatch As New OgranHatch(lSpPoint2dHatch)

		Return lOgrHatch

	End Function

	Sub New(ihatch As Hatch)

		wHatch = ihatch
		'  wHatch.LineWeight = LineWeight.ByBlock
		Try
			wOgranHatch = GrHatch()
		Catch ex As Exception
			wOgranHatch = New OgranHatch(wHatch)
		End Try


		SamijWneschnijKontur()          'POgranHatch.GetWneschnij   
		If wWneschnijKontur IsNot Nothing Then
			Try
				If wWneschnijKontur.Area < 0.8 * wHatch.Area Then
					wWneschnijKontur = wOgranHatch.GetWneschnijPoDlaris                             ' pOgrKontur
				End If
			Catch ex As Exception
				BazDwg.SystemKommand.SoobEditor(Me.ToString & " " & CStr(Me.RastOtNachalaDwgBeg) & vbCr & ex.Message)
			End Try

			'  


			Dim lDlinakontur As Double = dbPrim.DlinaPoX(wWneschnijKontur)
			Dim lDlHatch As Double = dbPrim.DlinaPoX(wHatch)

			If Math.Abs(lDlinakontur - lDlHatch) > 0.4 * lDlHatch Then
				MsgBox(Me.ToString & " new  длина области штриховки " & lDlHatch & " Длина ограничивающего  контура " & lDlinakontur _
					   & " начало dwg " & CStr(Me.RastOtNachalaDwgBeg) & " Y " & CStr(Me.OtmetkaBegPodwg) _
					 & vbCr & " Слой чертежа " & wHatch.Layer & " PatternHatch  " & Me.wHatch.PatternName & " D " & wOgranHatch.DlinaOgranHatch)
			End If
		Else
			wWneschnijKontur = wOgranHatch.GetWneschnijPoDlaris

		End If
	End Sub
#End Region
#Region "Вывод w Dwg "
	Sub DeleteIzDwg()

		Dim doc As Document = Application.DocumentManager.MdiActiveDocument
		Dim db As Database = doc.Database
		Dim ed As Editor = doc.Editor
		Using tx As Transaction = db.TransactionManager.StartTransaction
			Dim acBlkTbl As BlockTable
			acBlkTbl = CType(tx.GetObject(db.BlockTableId,
										 OpenMode.ForRead), BlockTable)
			Dim btr As BlockTableRecord = CType(tx.GetObject(acBlkTbl(BlockTableRecord.ModelSpace), OpenMode.ForWrite), BlockTableRecord)



			Dim DBObject1 As DBObject = wHatch.ObjectId.GetObject(OpenMode.ForWrite)

			DBObject1.Erase()


			tx.Commit()

		End Using

	End Sub
	'Sub PerepisatHatch(iNameLayer As String)
	'    Dim lhatch As Hatch = GreateHatchPoPoint(iNameLayer, New ParamHatch(wHatch), Me.wOgranHatch.GetAlgDjris.GetPoint2dColl(), Me.wOgranHatch.GetAlgDjris.GetDoubleColl)
	'    DeleteIzDwg()
	'    wHatch = lhatch
	'End Sub
	'Sub PerepisatHatch(iNameLayer As String, Inijn As clsHatch)
	'    Dim lAlgDjSwoj As AlgDjarvis = Me.wOgranHatch.GetAlgDjris
	'    Dim lalgNijn As AlgDjarvis = Inijn.wOgranHatch.GetAlgDjris

	'    Dim lkontur As Point2dCollection = lAlgDjSwoj.GetPoint2dColl(lalgNijn)
	'    Dim lhatch As Hatch = wiwestiwDwg(iNameLayer, lkontur)

	'    DeleteIzDwg()
	'    wHatch = lhatch

	'End Sub
	Function OpredParamHatch() As ParamHatch
		Return New ParamHatch(wHatch.PatternName, wHatch.PatternScale, wHatch.PatternAngle, wHatch.LineWeight)
	End Function
#End Region
#Region "proverki"
	Function MejduX(iX As Double) As Boolean

		'
		If (RastOtNachalaDwgBeg - iX) < 0 And (RastOtNachalaDWGEnd - iX) > 0 _
			Then Return True Else Return False
	End Function
	Private Function WnutriPolyline(iPl As Polyline, iP As Point2d) As Boolean
		Dim lcolPoint As New Point3dCollection
		Dim lline = New Line(New Point3d(iP.X, iP.Y, 0), New Point3d(iP.X, 100000.0, 0))
		Try
			lline.IntersectWith(iPl, Intersect.OnBothOperands, lcolPoint, IntPtr.Zero, IntPtr.Zero)
		Catch ex As Exception
			Return False
		End Try

		Dim lcount = lcolPoint.Count
		If lcount Mod 2 = 0 Then Return False
		Return True
	End Function
	''' <summary>
	''' Проверяет находиться данная точка внутри штриховки
	''' </summary>
	''' <param name="iPoint"> точка чертежа </param>
	''' <returns></returns>
	''' <remarks></remarks>
	Private Function WnutriPolyline(iPoint As Point2d) As Boolean
		If iPoint.X < RastOtNachalaDwgBeg Then Return False
		If iPoint.X > RastOtNachalaDWGEnd Then Return False


		For Each el As Polyline In Me.wSumPolyline
			If WnutriPolyline(el, iPoint) Then Return True
		Next
		Return False


		' Return wOgranHatch.GetPeresechenie(ix)

	End Function
	''' <summary>
	''' проверяет являеться ли линия границы ровной линией или она изломана
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Function LinijBegLi() As Boolean
		Dim lpoint = New Point2d(RastOtNachalaDwgBeg + ObrazGeologii.KritBlizostiDwg, 0.5 * (OtmetkaBegPodwg + OtmetkaBegNizDwg))
		Return WnutriPolyline(lpoint)
	End Function
	Function Wnutri(iMtext As MText) As Boolean


		Return Wnutri(iMtext.Location)




	End Function
	Function Wnutri(iPoint As Point3d) As Boolean
		'отсекаем точки лежащие заведомо вне штриховки по ограничивающему контуру
		Dim lperes = wOgranHatch.GetPeresechenie(iPoint.X)

		If lperes Is Nothing Then Return False

		If lperes.MinTochka2D.Y > iPoint.Y Or lperes.MaxTochka2D.Y < iPoint.Y Then Return False
		'остальные проверяем по полилиниям.
		Return WnutriPolyline(New Point2d(iPoint.X, iPoint.Y))

	End Function
	Function NeRawnPoParam(iHatch As clsHatch) As Boolean
		Dim lhatchZadan = iHatch.GetHatch
		Return wHatch.PatternName <> lhatchZadan.PatternName OrElse wHatch.PatternAngle <> lhatchZadan.PatternAngle _
				  OrElse wHatch.PatternScale <> lhatchZadan.PatternScale
	End Function
	Function NeRawnPoParam(iParamIge As ParamIge) As Boolean

		Return wHatch.PatternName <> iParamIge.PatternName OrElse wHatch.PatternAngle <> iParamIge.PatternAngle _
				  OrElse wHatch.PatternScale <> iParamIge.PatternScale
	End Function
	Private Const KritBlizRajdom = 2 * ObrazGeologii.PolushirinaSdopusk
	''' <summary>
	''' Определяет имеют ли  слои общие границы  1 слой перед isled -1 слой после iSled 0 - не имеют общих границ
	''' </summary>
	''' <param name="iSled"> слой для сравнений </param>
	''' <returns></returns>
	''' <remarks></remarks>
	Function Rajdom(iSled As clsHatch) As Integer
		Dim lkritBeg = Math.Abs(RastOtNachalaDwgBeg - iSled.RastOtNachalaDWGEnd) + Math.Abs(OtmetkaBegPodwg - iSled.OtmetkaEndPoDwg)
		Dim lkritEnd = Math.Abs(RastOtNachalaDWGEnd - iSled.RastOtNachalaDwgBeg) + Math.Abs(OtmetkaEndPoDwg - iSled.OtmetkaBegPodwg)
		If lkritBeg < KritBlizRajdom Then Return 1 ' iSled  перед
		If lkritEnd < KritBlizRajdom Then Return -1 ' iSled  после
		Return 0   ' iSled  общих границ нет
	End Function
#End Region
#Region "Get ReadOly"
	Function GetHatch() As Hatch
		Return wHatch
	End Function
	Function GetWneschyijkontur() As Polyline
		Return wWneschnijKontur
	End Function
	Function GetOgranHatch() As OgranHatch
		Return wOgranHatch
	End Function
	Function GetPeresecheniePl(ix As Double) As Razrez
		If ix < RastOtNachalaDwgBeg Then Return Nothing
		If ix > RastOtNachalaDWGEnd Then Return Nothing

		Dim lline = New Line(New Point3d(ix, 0, 0), New Point3d(ix, 100000.0, 0))
		Dim lyMin As Double = 10000
		Dim lymax As Double = -10000
		Dim lcolPoint As New Point3dCollection
		For Each el As Polyline In Me.wSumPolyline
			Try
				lline.IntersectWith(el, Intersect.OnBothOperands, lcolPoint, IntPtr.Zero, IntPtr.Zero)
			Catch ex As Exception
				Continue For
			End Try

			For Each elp As Point3d In lcolPoint
				If elp.Y < lyMin Then
					lyMin = elp.Y
				End If
				If elp.Y > lymax Then
					lymax = elp.Y
				End If
			Next
		Next

		If lyMin < 9999 And lymax > -9999 Then

			Return New Razrez(New Point2d(ix, lyMin), New Point2d(ix, lymax))
		Else
			Return wOgranHatch.GetPeresechenie(ix)
		End If

		' Return wOgranHatch.GetPeresechenie(ix)

	End Function
	ReadOnly Property RastOtNachalaDwgBeg() As Double
		Get
			Return wOgranHatch.RastOtNachalaDwgBeg
		End Get
	End Property
	ReadOnly Property RastOtNachalaDWGEnd() As Double
		Get
			Return wOgranHatch.RastOtNachalaDwgEnd
		End Get
	End Property
	ReadOnly Property OtmetkaBegPodwg() As Double
		Get
			Return wOgranHatch.OtmetkaDwgBeg()
		End Get
	End Property
	ReadOnly Property OtmetkaEndPoDwg As Double
		Get
			Return wOgranHatch.OtmetkaDwgEnd
		End Get
	End Property
	ReadOnly Property TolshinaBegDwg() As Double
		Get
			Return wOgranHatch.LewPeresechenie.Tolschina
		End Get
	End Property
	ReadOnly Property TolshinaEndDwg() As Double
		Get
			Return wOgranHatch.PrawPeresechenie.Tolschina
		End Get
	End Property
	ReadOnly Property OtmetkaBegNizDwg() As Double
		Get
			Return wOgranHatch.LewPeresechenie.MinTochka2D.Y
		End Get
	End Property
#End Region

End Class
