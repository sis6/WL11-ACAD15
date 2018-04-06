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
Public Class AlgDjarvis
    Private wDopuskDljGraniz As Double = 0.5
    Private wVneschnijkontur As New List(Of Point2d)
    Private wWerhGraniza As List(Of Point2d) 'по убывынию x
    Private wNizGraniza As List(Of Point2d) 'по возрастанию x
    Private wWseMnojestwo As List(Of Point2d)

    Private wLewNijn, wPrawVerh As Point2d
    Private wLewverh, wPrawNijn As Point2d
    Private wXBeg, wXend As Double
    Private wTochkiPoxNiz As New List(Of Point2d)
    '   Private wSamajNijn As Point2d

    Sub New()
        wWseMnojestwo = New List(Of Point2d)

    End Sub
    ''' <summary>
    ''' верхняя и нижняя точка контура в координате X
    ''' </summary>
    ''' <param name="IX"></param>
    ''' <returns></returns>
    ''' <remarks> возвращает в нулевом элементе точку верх ней границы в первом нижней </remarks>
    Function PointGr(IX As Double) As Point2d()
        Dim lpointGr(1) As Point2d
        Dim lwerh = New GrebenProfilDwg(wWerhGraniza)
        Dim lnijn = New GrebenProfilDwg(wNizGraniza)
        lpointGr(0) = lwerh.GetPointLinii(IX)
        lpointGr(1) = lnijn.GetPointLinii(IX)
        Return lpointGr
    End Function
    Private Sub Add(ipoint As Point2d)
        ComparatorPoint2dXY.SearchAndInsert(wWseMnojestwo, ipoint, New ComparatorPoint2dXY)
        '   wWseMnojestwo.Add(ipoint)
    End Sub
    Sub New(iSp As List(Of Point2d))
        wWseMnojestwo = New List(Of Point2d)
        For Each el As Point2d In iSp
            ComparatorPoint2dXY.SearchAndInsert(wWseMnojestwo, el, New ComparatorPoint2dXY)
        Next
      
    End Sub
#Region "Po polnomu"
    Private Function rotate(A As Point2d, B As Point2d, C As Point2d) As Double
        Return (B.X - A.X) * (C.Y - B.Y) - (B.Y - A.Y) * (C.X - B.X)
    End Function
    Private Function norm(A As Point2d, B As Point2d, C As Point2d) As Double
        Dim w As Double = (A.X - B.X) * (A.X - B.X) + (A.Y - B.Y) * (A.Y - B.Y)
        Dim w1 As Double = (C.X - B.X) * (C.X - B.X) + (C.Y - B.Y) * (C.Y - B.Y)
        Return Math.Sqrt(w * w1)
    End Function
    Private Function poworot(A As Point2d, B As Point2d, C As Point2d) As Double
        Return rotate(A, B, C) / norm(A, B, C)
    End Function
    Private Function poworotA(A As Point2d, B As Point2d, C As Point2d) As Double
        Dim vec1 As Vector2d = A - B
        Dim vec2 As Vector2d = B - C
        Return vec1.GetAngleTo(vec2)

    End Function

    Private Sub OpredGran()
        Dim lcomp As New ComparatorPoint2dPoX
        For Each el As Point2d In wWseMnojestwo
            ComparatorPoint2dPoX.SearchAndInsert(wTochkiPoxNiz, el, lcomp)
        Next

        Dim lnumber = wTochkiPoxNiz.Count - 1
        Dim lNiz(lnumber), lwerh(lnumber) As Double

        wLewNijn = wTochkiPoxNiz(0)
        wLewverh = wLewNijn
        wPrawVerh = wTochkiPoxNiz(lnumber)
        wPrawNijn = wPrawVerh
        '   wSamajNijn = wLewNijn
        wXBeg = wLewNijn.X

        wXend = wPrawVerh.X
        For Each el As Point2d In wWseMnojestwo
            '  ComparatorPoint2d.SearchAndInsert(wTochkiPoxNiz, el, lcomp)

            If el.X - wXBeg < wDopuskDljGraniz Then
                If el.Y < wLewNijn.Y Then
                    wLewNijn = el
                Else
                    If el.Y > wLewverh.Y Then wLewverh = el
                End If

            Else
                If wXend - el.X < wDopuskDljGraniz Then
                    If el.Y > wPrawVerh.Y Then
                        wPrawVerh = el
                    Else
                        If el.Y < wPrawNijn.Y Then wPrawNijn = el
                    End If

                End If
            End If
            '     If el.Y < wSamajNijn.Y Then wSamajNijn = el
        Next
        If wLewverh.Y - wLewNijn.Y < wDopuskDljGraniz Then
            Dim i As Integer
            i = 0
        End If

    End Sub
    
    Private Sub NajtiP2()
        wVneschnijkontur.Add(wTochkiPoxNiz(0))
        Dim lMinfi As Double = 2.0 * Math.PI
        Dim lWtorPoint As Point2d = wTochkiPoxNiz(1)

        'For Each el As Point2d In wWseMnojestwo
        '    If el = wTochkiPoxNiz(0) Then Continue For
        '    Dim langle = (el - wTochkiPoxNiz(0)).Angle
        '    If langle < lMinfi Then
        '        lWtorPoint = el
        '        lMinfi = langle
        '    End If
        'Next

        For Each el As Point2d In wWseMnojestwo
            If el = wTochkiPoxNiz(0) Then Continue For
            Dim langle = rotate(wTochkiPoxNiz(0), lWtorPoint, el)
            If langle < 0 Then
                lWtorPoint = el

            End If
        Next
        If lWtorPoint.Equals(Point2d.Origin) Then
            Application.ShowAlertDialog(Me.ToString & " NajtiP2 Вторая точка не найдена")

        Else
            wVneschnijkontur.Add(lWtorPoint)
            wWseMnojestwo.Remove(lWtorPoint)
            'wVneschnijkontur.Add(lkont)
            'wWseMnojestwo.Remove(lkont)
        End If

    End Sub
    Private Function WidelitNijnGraniz() As List(Of Point2d)
        Dim lNijnGraniz As New List(Of Point2d)
        Dim PrRab As Boolean = False
        For Each el As Point2d In wVneschnijkontur
            If PrRab Then
                lNijnGraniz.Add(el)
                If el = wPrawNijn Then
                    Exit For
                End If
            Else
                If el = wLewNijn Then
                    lNijnGraniz.Add(el)
                    PrRab = True
                End If
            End If
        Next
        Return lNijnGraniz
    End Function
    Private Function WidelitWerhnjGraniz() As List(Of Point2d)
        Dim lWerhGraniz As New List(Of Point2d)
        Dim PrRab As Boolean = False
        For Each el As Point2d In wVneschnijkontur
            If PrRab Then
                lWerhGraniz.Add(el)
                If el = wLewverh Then
                    Exit For
                End If
            Else
                If el = wPrawVerh Then
                    lWerhGraniz.Add(el)
                    PrRab = True
                End If
            End If
        Next
        Return lWerhGraniz
    End Function
    Sub Algoritm()
        Dim lPointNajden As Point2d
        Dim minfi As Double = 2 * Math.PI
        OpredGran()
        NajtiP2()
        Dim lper As Point2d = wVneschnijkontur(0)
        Dim lwtor As Point2d = wVneschnijkontur(1)

        Do Until lPointNajden.IsEqualTo(wVneschnijkontur(0))


            For Each el As Point2d In wWseMnojestwo


                Dim lugolfi = poworotA(lper, lwtor, el)

                If lugolfi < minfi Then
                    lPointNajden = el
                    minfi = lugolfi
                End If



            Next
            wVneschnijkontur.Add(lPointNajden)
            wWseMnojestwo.Remove(lPointNajden)
            lper = lwtor
            lwtor = lPointNajden
            minfi = 2 * Math.PI

        Loop

        wWerhGraniza = WidelitWerhnjGraniz()

        wNizGraniza = WidelitNijnGraniz()

    End Sub
#End Region
#Region "Read only"
    ReadOnly Property LewNijn() As Point2d
        Get
            Return wLewNijn
        End Get
    End Property
    ReadOnly Property LewVerh() As Point2d
        Get
            Return wLewverh
        End Get
    End Property
    ReadOnly Property PrawNijn() As Point2d
        Get
            Return wPrawNijn
        End Get
    End Property
    ReadOnly Property PrawVerh() As Point2d
        Get
            Return wPrawVerh
        End Get
    End Property


    'ReadOnly Property Xbeg As Double
    '    Get
    '        Return wXBeg
    '    End Get
    'End Property
    'ReadOnly Property Xend As Double
    '    Get
    '        Return wXend
    '    End Get
    'End Property
    ''' <summary>
    ''' Внутренняя точка области.
    ''' </summary>
    ''' <param name="iAnormX"></param>
    ''' <param name="iAnormY"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property GetWnutrPoint2d(iAnormX As Double, iAnormY As Double) As Point2d
        Get
            Dim pN As Point2d = iAnormX * LewNijn + (1 - iAnormX) * PrawNijn.GetAsVector()
            Dim pW As Point2d = iAnormX * LewVerh + (1 - iAnormX) * PrawVerh.GetAsVector()
            Return iAnormY * pN + (1 - iAnormY) * pW.GetAsVector

        End Get
    End Property
    ReadOnly Property GetWnutrPointi3d(iAnormX As Double, iAnormY As Double) As Point3d
        Get
            Dim wp = GetWnutrPoint2d(iAnormX, iAnormY)
            Return New Point3d(wp.X, wp.Y, 0)

        End Get
    End Property
    Function GetPoint2dColl() As Point2dCollection
        Return PreobColl(wVneschnijkontur)
    End Function
#End Region
    Private Function GetPoint2dColl(iWerhOgr As List(Of Point2d), iNijnOgr As List(Of Point2d)) As Point2dCollection
        Dim lvneschnij As New List(Of Point2d)
        Dim lcomp As New ComparatorPoint2dPoX
        lvneschnij.AddRange(wNizGraniza)
        For Each el As Point2d In iNijnOgr
            If el.X > wLewNijn.X And el.X < wPrawNijn.X Then
                ComparatorPoint2dPoX.SearchAndInsert(lvneschnij, el, lcomp)
            End If
        Next

        Dim lwspver As New List(Of Point2d)
        lwspver.AddRange(wWerhGraniza)
        lwspver.Reverse()
        For Each el As Point2d In iWerhOgr
            If el.X > wLewNijn.X And el.X < wPrawNijn.X Then
                ComparatorPoint2dPoX.SearchAndInsert(lwspver, el, lcomp)
            End If
        Next
        lwspver.Reverse()

        lvneschnij.AddRange(lwspver)
        lvneschnij.Add(lvneschnij(0))
        Return PreobColl(lvneschnij)
    End Function
    ''' <summary>
    ''' Получение граничного контура с уточнением по слою расположеному ниже
    ''' </summary>
    ''' <param name="iNijnOgr"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetPoint2dColl(iNijnOgr As AlgDjarvis) As Point2dCollection
        Dim lvneschnij As New List(Of Point2d)
        Dim lcomp As New ComparatorPoint2dPoX
        Dim lPers As New GrebenProfilDwg(iNijnOgr.GetWerhGraniza)
        lvneschnij.Add(lPers.GetPointLinii(wLewNijn.X))
        lvneschnij.Add(lPers.GetPointLinii(wPrawVerh.X))
        For Each el As Point2d In iNijnOgr.GetWerhGraniza ' построили нижнею границу по верхней
            If el.X > wLewNijn.X - wDopuskDljGraniz And el.X < wPrawNijn.X + wDopuskDljGraniz Then
                ComparatorPoint2dPoX.SearchAndInsert(lvneschnij, el, lcomp)
            End If
        Next
        For Each el As Point2d In GetNijnijGraniza() ' если контур меньше по длине дополнили нижними точками 
            If el.X < iNijnOgr.wLewNijn.X - wDopuskDljGraniz Or el.X > iNijnOgr.wPrawNijn.X + wDopuskDljGraniz Then
                ComparatorPoint2dPoX.SearchAndInsert(lvneschnij, el, lcomp)
            End If
        Next
        lvneschnij.AddRange(GetWerhGraniza)
        lvneschnij.Add(lvneschnij.First)

        Return PreobColl(lvneschnij)
    End Function
    ''' <summary>
    ''' заменяет верхнею  и  нижнею границу и создает контур  верхняя граница по убыванию
    ''' </summary>
    ''' <param name="iWerh"> верхняя граница по убыванию  </param>
    ''' <param name="iniz"> нижняя граница по возрастанию </param>
    ''' <remarks> верхняя граница по убыванию: нижняя граница по возрастанию  </remarks>
    Private Sub ZamenitWerhiNiz(iWerh As List(Of Point2d), iniz As List(Of Point2d))
        wWerhGraniza = iWerh
        wNizGraniza = iniz
        SozdatPoWerhNizu()
    End Sub
    ''' <summary>
    ''' пересоздает по новой контур
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SozdatPoWerhNizu()
        wVneschnijkontur.Clear()

        wVneschnijkontur.AddRange(wNizGraniza)
        wVneschnijkontur.AddRange(wWerhGraniza)
        wVneschnijkontur.Add(wNizGraniza(0))
        wLewNijn = wNizGraniza.First
        wLewverh = wWerhGraniza.Last
        wPrawVerh = wWerhGraniza.First
        wPrawNijn = wNizGraniza.Last
        '   wSamajNijn = wLewNijn
        wXBeg = wLewNijn.X

        wXend = wPrawVerh.X

    End Sub
    Private Function GetDoubleColl() As DoubleCollection
        Dim lcoll As New DoubleCollection
        For Each el As Point2d In wVneschnijkontur
            lcoll.Add(0)
        Next
        Return lcoll
    End Function
    ''' <summary>
    ''' возвращает верхнею границу упорядоченую  по убывынию x
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetWerhGraniza() As List(Of Point2d)
        Return wWerhGraniza
    End Function
    ''' <summary>
    ''' возвращает нижнею границу упорядоченую по возрастанию x 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetNijnijGraniza() As List(Of Point2d)
        Return wNizGraniza
    End Function
    Private Shared Function PreobColl(iSp As List(Of Point2d)) As Point2dCollection
        Dim lcol As New Point2dCollection
        For Each el As Point2d In iSp
            lcol.Add(el)
        Next


        Return lcol

    End Function
    Private Shared Function CollDouble(iColl As Point2dCollection) As DoubleCollection
        Dim lcol As New DoubleCollection
        For Each el As Point2d In iColl
            lcol.Add(0)
        Next


        Return lcol

    End Function


    Function GetWneschnijKontur() As Polyline
        Dim lPolyline As New Polyline
        lPolyline.Closed = True
        For i As Integer = 0 To wVneschnijkontur.Count - 1
            lPolyline.AddVertexAt(i, wVneschnijkontur(i), 0, 0, 0)
        Next


        Return lPolyline
    End Function
End Class
