Option Strict On
Option Explicit On
#If ARX_APP Then
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.ApplicationServices
Imports DBTransMan = Autodesk.AutoCAD.DatabaseServices.TransactionManager
Imports Autodesk.AutoCAD.EditorInput
#Else
Imports Bricscad.ApplicationServices
Imports _AcBr = Teigha.BoundaryRepresentation
Imports _AcCm = Teigha.Colors
Imports Teigha.DatabaseServices
Imports Bricscad.EditorInput
Imports Teigha.Geometry
Imports _AcGi = Teigha.GraphicsInterface
Imports _AcGs = Teigha.GraphicsSystem
Imports _AcPl = Bricscad.PlottingServices
Imports _AcBrx = Bricscad.Runtime
Imports _AcTrx = Teigha.Runtime
Imports _AcWnd = Bricscad.Windows
Imports DBTransMan = Teigha.DatabaseServices.TransactionManager
#End If
Imports BazDwg
Public Class SrawPoUgluPoint2d
    Implements IComparer(Of Point2d)
    Private wZentr As Point2d
	Public Function Compare(ByVal x As Point2d, ByVal y As Point2d) As Integer Implements System.Collections.Generic.IComparer(Of Point2d).Compare
		Dim Ugx As Double = x.GetAsVector().Angle
		Dim Ugy As Double = y.GetAsVector.Angle
		Return Ugx.CompareTo(Ugy)
	End Function

End Class
Public Class SrawPoUgluPoint2dZentr
    Implements IComparer(Of Point2d)
    Private wZentr As Point2d

    Public Function Compare(ByVal x As Point2d, ByVal y As Point2d) As Integer Implements System.Collections.Generic.IComparer(Of Point2d).Compare
        Dim Ugx As Double = x.GetVectorTo(wZentr).Angle
        Dim Ugy As Double = y.GetVectorTo(wZentr).Angle
        Ugx = x.GetVectorTo(wZentr).Angle
        Return Ugx.CompareTo(Ugy)
    End Function
    Property Zentr() As Point2d
        Get
            Return wZentr
        End Get
        Set(ByVal value As Point2d)
            wZentr = value
        End Set
    End Property
End Class
Public Class myKontur
    Private wGrTchk As List(Of Point2d)
    Private wMasLin() As Line2d
    Dim wRazmKontur, wKolwo As Integer
    Private Zentr As Point2d = New Point2d(0, 0)
    Private dOtw As Double
    Const PiNaDwa = 0.5 * Math.PI
    Shared Function OprZentr(ByVal SpTchk As List(Of Point2d)) As Point2d
        Dim xSum As Double = 0, ySum As Double = 0

        For Each el As Point2d In SpTchk
            xSum += el.X
            ySum += el.Y
        Next
        xSum /= SpTchk.Count
        ySum /= SpTchk.Count
        Return New Point2d(xSum, ySum)
    End Function
    Sub New(ByVal iShirOtv As Double)
        dOtw = iShirOtv
    End Sub
    ''' <summary>
    ''' Задает и получает список граничных точек контура
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property GrTchk() As List(Of Point2d)
        Get
            Return wGrTchk
        End Get
        Set(ByVal iGrTchk As List(Of Point2d))
            Dim lsraw As New SrawPoUgluPoint2d
            wKolwo = iGrTchk.Count
            wRazmKontur = wKolwo - 1
            wGrTchk = iGrTchk
            wGrTchk.Sort(lSraw)
            ReDim wMasLin(wRazmKontur)
            For I = 0 To wRazmKontur
                wMasLin(I) = New Line2d(wGrTchk(I), wGrTchk((I + 1) Mod (wKolwo)))
            Next
        End Set
    End Property



    Private Function Bissektrisa(ByVal i As Integer) As Point2d
        Dim l1 As Line2d = wMasLin(i)
        Dim l2 As Line2d
        If i > 0 Then l2 = wMasLin(i - 1) Else l2 = wMasLin(wRazmKontur)
        Dim Ug1 As Double = l1.Direction.Angle
        Dim DeltaUg As Double = l1.Direction.GetAngleTo(l2.Direction)
        Dim UgB = Ug1 - DeltaUg / 2 + PiNaDwa
        Dim Tchk1 As Point2d = Kommand.UstTchk(wGrTchk(i).X, wGrTchk(i).Y, dOtw, UgB)
        Dim Tchk2 As Point2d = Kommand.UstTchk(wGrTchk(i).X, wGrTchk(i).Y, dOtw, UgB + Math.PI)
        If Tchk1.GetDistanceTo(Zentr) > Tchk2.GetDistanceTo(Zentr) Then
            Return Tchk1
        Else
            Return Tchk2
        End If
    End Function
    Private Function OrtoIsh(ByVal i As Integer) As Point2d
        Dim Wec As Vector2d = wMasLin(i).Direction
        'wMasLin(i).GetPerpendicularLine(wMasLin(i).EvaluatePoint(0.5))

        Dim Tchk1 As Point2d = Kommand.UstTchk(wGrTchk(i).X, wGrTchk(i).Y, dOtw, Wec.Angle + PiNaDwa)
        Dim Tchk2 As Point2d = Kommand.UstTchk(wGrTchk(i).X, wGrTchk(i).Y, dOtw, Wec.Angle - PiNaDwa)
        If Tchk1.GetDistanceTo(Zentr) > Tchk2.GetDistanceTo(Zentr) Then
            Return Tchk1
        Else
            Return Tchk2
        End If
    End Function
    Private Function OrtoWh(ByVal i As Integer) As Point2d
        Dim Wec As Vector2d
        If i > 0 Then Wec = wMasLin(i - 1).Direction Else Wec = wMasLin(wRazmKontur).Direction
        Dim Tchk1 As Point2d = Kommand.UstTchk(wGrTchk(i).X, wGrTchk(i).Y, dOtw, Wec.Angle + PiNaDwa)
        Dim Tchk2 As Point2d = Kommand.UstTchk(wGrTchk(i).X, wGrTchk(i).Y, dOtw, Wec.Angle - PiNaDwa)
        If Tchk1.GetDistanceTo(Zentr) > Tchk2.GetDistanceTo(Zentr) Then
            Return Tchk1
        Else
            Return Tchk2
        End If
    End Function
    Private Function OrtoSer(ByVal i As Integer) As Point2d
        Dim Wec As Vector2d = wMasLin(i).Direction
        Dim TchkSer As Point2d = wMasLin(i).EvaluatePoint(0.5)
        Dim Tchk1 As Point2d = Kommand.UstTchk(TchkSer.X, TchkSer.Y, dOtw, Wec.Angle + PiNaDwa)
        Dim Tchk2 As Point2d = Kommand.UstTchk(TchkSer.X, TchkSer.Y, dOtw, Wec.Angle - PiNaDwa)
        If Tchk1.GetDistanceTo(Zentr) > Tchk2.GetDistanceTo(Zentr) Then
            Return Tchk1
        Else
            Return Tchk2
        End If
    End Function
    ReadOnly Property MaxNumProek() As Integer
        Get
            Return wRazmKontur
        End Get
    End Property
    ReadOnly Property KonturOtv() As Point2dCollection
        Get
            Dim lColl As New Point2dCollection
            For I As Integer = 0 To wRazmKontur
                lColl.Add(OrtoWh(I))
                lColl.Add(Bissektrisa(I))
                lColl.Add(OrtoIsh(I))
                lColl.Add(OrtoSer(I))



            Next
            Return lColl
        End Get
    End Property
End Class
Public Class myLine3D
    Implements IDisposable
    Private wLin As Line
    '  Private wLin3d As Line3d
    Sub New(ByVal a As Point3d, ByVal b As Point3d)
        wLin = New Line(a, b)
        '  wLin3d = New Line3d(a, b)
    End Sub
    Function Distance(ByVal a As Point3d) As Double
        Dim lp As Point3d = wLin.GetClosestPointTo(a, False)
        Dim llin = lp.DistanceTo(a)
        '  Dim llin3d = wLin3d.GetDistanceTo(a)
        Return llin
    End Function
    Function GetBlijajshuj(ByVal a As Point3d) As Point3d
        Return wLin.GetClosestPointTo(a, True)
    End Function
    Sub Dispose() Implements IDisposable.Dispose
        If wLin.IsDisposed Then wLin.Dispose()
    End Sub

End Class
Public Class myLine2D
    Implements IDisposable

    Private wLin As Line2d
    Sub New(ByVal a As Point2d, ByVal b As Point2d)
        wLin = New Line2d(a, b)


    End Sub
    Sub Dispose() Implements IDisposable.Dispose
        If wLin.IsDisposed Then wLin.Dispose()
    End Sub
    Function Distance(ByVal a As Point2d) As Double
        Return wLin.GetDistanceTo(a)

    End Function
    'Function PointOrto(ByVal a As Point2d) As Point2d

    '    Return wLin.GetNormalPoint(wLin.EvaluatePoint(0.5)).Point
    'End Function
    ''' <summary>
    ''' параметр определяющий точку на линии в которую опущен перпендикуляр
    ''' </summary>
    ''' <param name="a"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function ParametrOrto(ByVal a As Point2d) As Double

        Dim lline As Line2d = wLin.GetPerpendicularLine(a)
        '     Dim lpop = lline.GetLine().StartPoint
        Dim lPointInt = lline.IntersectWith(wLin)
        If lPointInt.Length > 0 Then
            Dim lpar As Double = wLin.GetParameterOf(lPointInt(0))
            Return lpar
        End If
        Return -1
    End Function
End Class
Public Class myPolyline3d

    Private wCollPoint As Point3dCollection
    Private wPolyLineCurve As PolylineCurve3d
    Private wPolyline3d As Polyline3d
    Private wCurve As Curve

    Function SblijniePoCurve(ByVal iCurve As myPolyline3d) As PointOnCurve3d()
        Dim lPolyLineCurve = New PolylineCurve3d(wCollPoint)
        Dim lIcurvePolylineCurve = New PolylineCurve3d(iCurve.wCollPoint)
        Return lPolyLineCurve.GetClosestPointTo(lIcurvePolylineCurve)
    End Function
    Sub New(ByVal iSp As List(Of Double()))
        wCollPoint = New Point3dCollection

        For Each el As Double() In iSp
            wCollPoint.Add(New Point3d(el))
        Next

        wPolyLineCurve = New PolylineCurve3d(wCollPoint)

        wPolyline3d = New Polyline3d(Poly3dType.SimplePoly, wCollPoint, False)
        '  wPolyLineCurve = CType(wPolyline3d, Curve)
        wCurve = CType(wPolyline3d, Curve)

    End Sub
    Function Distance(ByVal iCurve As myPolyline3d) As Line
        If wCollPoint.Count = 0 Then Return Nothing
        If iCurve.wCollPoint.Count = 0 Then Return Nothing
        Dim lpointMe = wCollPoint(0)
        Dim lpointIcurve As Point3d = iCurve.wCollPoint(0)
        Dim lmin As Double = lpointMe.DistanceTo(lpointIcurve)





        For Each el As Point3d In wCollPoint
            Dim lpoint As Point3d = iCurve.wPolyline3d.GetClosestPointTo(el, False)
            Dim w As Double = el.DistanceTo(lpoint)

            If w < lmin Then
                lmin = w
                lpointMe = New Point3d(el.ToArray)
                lpointIcurve = New Point3d(lpoint.ToArray)
            End If

        Next



        Return New Line(lpointMe, lpointIcurve)
    End Function
    ''' <summary>
    ''' находит минимальное  расстояние и соответсьвующие ему смещения  данной полилинии с заданой
    ''' </summary>
    ''' <param name="iCurve"> заданая полилиния </param>
    ''' <returns>Возвращает массив d(0) - минимальное расстояние d(1) смещение по горизонтали d(2) смещение по вертикали </returns>
    ''' <remarks></remarks>
    Function DistanceGV(ByVal iCurve As myPolyline3d) As Double()
        '

        Dim lmin, lminG, lminV As Double
        lmin = 1000
        'находим проекцию полилинии на горизонтальную плоскость
        Dim PBeglin As Point3d = iCurve.wCollPoint(0)
        Dim pEndLin As Point3d = iCurve.wCollPoint(iCurve.wCollPoint.Count - 1)
        Dim linProek As Line2d = New Line2d(New Point2d(PBeglin.X, PBeglin.Y), New Point2d(pEndLin.X, pEndLin.Y))
        'поиск минимального расстояния
        For I As Integer = 0 To wCollPoint.Count - 1
            For J As Integer = 0 To iCurve.wCollPoint.Count - 1
                Dim li As Point3d = wCollPoint(I)
                Dim lj As Point3d = iCurve.wCollPoint(J)
                Dim wr = li.DistanceTo(lj)
             
                If wr < lmin Then
                    lmin = wr
                    lminG = linProek.GetDistanceTo(New Point2d(li.X, li.Y))
                    lminV = Math.Abs(li.Z - lj.Z)
                End If



            Next

        Next
        Dim rez(2) As Double
        rez(0) = lmin
        rez(1) = lminG
        rez(2) = lminV



        Return rez
    End Function
    ''' <summary>
    ''' находит минимальное расстояние и смещения между данной полилинии и заданой  в заданой точки
    ''' </summary>
    ''' <param name="iCurve"> заданая полилиния </param>
    ''' <param name="iAlfa"> параметр положения точки линии  </param>
    ''' <returns> Возвращает массив d(0) - минимальное расстояние d(1) смещение по горизонтали d(2) смещение по вертикали  </returns>
    ''' <remarks></remarks>
    Function DistanceGVTochka(ByVal iCurve As myPolyline3d, iAlfa As Double) As Double()
        Dim lNum, lNumiCurve As Integer
        If iAlfa < 0 Then
            lNum = 0
            lNumiCurve = 0
        Else
            If iAlfa > 1 Then
                lNumiCurve = iCurve.wCollPoint.Count - 1
                lNum = wCollPoint.Count - 1
            Else
                lNumiCurve = CInt((iCurve.wCollPoint.Count - 1) * iAlfa)
                lNum = CInt((wCollPoint.Count - 1) * iAlfa)
            End If
        End If


        'находим проекцию полилинии на горизонтальную плоскость
        Dim PBeglin As Point3d = iCurve.wCollPoint(0)
        Dim pEndLin As Point3d = iCurve.wCollPoint(iCurve.wCollPoint.Count - 1)
        Dim linProek As Line2d = New Line2d(New Point2d(PBeglin.X, PBeglin.Y), New Point2d(pEndLin.X, pEndLin.Y))
        'поиск расстояния и сближений

        Dim li As Point3d = wCollPoint(lNum)
        Dim lj As Point3d = iCurve.wCollPoint(lNumiCurve)
        Dim wr = li.DistanceTo(lj)




        Dim rez(2) As Double
        rez(0) = wr
        rez(1) = linProek.GetDistanceTo(New Point2d(li.X, li.Y))
        rez(2) = Math.Abs(li.Z - lj.Z)



        Return rez
    End Function
    Function Distance(ByVal iPoint As Point3d) As Double
        Dim lpc As PointOnCurve3d = wPolyLineCurve.GetClosestPointTo(iPoint)
        Dim zn As Double = Math.Sign(iPoint.Z - lpc.Point.Z)
        Return zn * iPoint.DistanceTo(lpc.Point)
    End Function
   
  
End Class