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


Public Class GrebenProfilDwg
    Private wLinijProfil As List(Of Point2d)
    Dim wRastOtNachalaDwgBeg, wRastOtNachalaDwgEnd As Double
#Region "poisk"
    Private wKritPoiska As Double
    Private Function FunPoisk(iP As Point2d) As Boolean
        If iP.X >= wKritPoiska Then Return True
        Return False

    End Function
    Private Function NajtiIndex(ixdwg As Double) As Integer
        wKritPoiska = ixdwg
        Return wLinijProfil.FindIndex(AddressOf FunPoisk)
    End Function
#End Region
    Function GetWseLinij() As List(Of Point2d)
        Return wLinijProfil
    End Function
    Shared Function Slojt(iA As Point2d, iB As Point2d) As Point2d

        Return New Point2d(iA.X + iB.X, iA.Y + iB.Y)

    End Function

    Shared Function PointMejduPoint(iPb As Point2d, iPe As Point2d, iXdwg As Double) As Point2d
        If IPb.X > iPe.X Then
            Dim lw = IPb
            IPb = iPe
            iPe = lw
        End If
        If iXdwg <= IPb.X Then Return IPb
        If iXdwg >= iPe.X Then Return iPe
        Dim lY = iPb.Y + (iXdwg - iPb.X) * (iPe.Y - iPb.Y) / (iPe.X - iPb.X)
        Return New Point2d(iXdwg, lY)
    End Function
    Function GetPointLinii(iXDwg As Double) As Point2d
        Dim lIndex = NajtiIndex(iXDwg)
        If lIndex < 0 Then Return wLinijProfil.Last
        If lIndex = 0 Then Return wLinijProfil.First
        Dim lpointB = wLinijProfil(lIndex - 1)
        Dim lpointe = wLinijProfil(lIndex)
        Dim lwspY = lpointB.Y + (iXDwg - lpointB.X) * (lpointe.Y - lpointB.Y) / (lpointe.X - lpointB.X)
        Return New Point2d(iXDwg, lwspY)
    End Function
    Function GetUchastokLinii(ixdwgB As Double, ixdwgE As Double) As List(Of Point2d)
        Dim lSpUchastka As New List(Of Point2d)
        Dim lIndexB = NajtiIndex(ixdwgB) 'находим индекс элемента большего заданого критерия

        If lIndexB < 0 Then
            lSpUchastka.Add(wLinijProfil.Last)
        Else
            If lIndexB = 0 Then
                lSpUchastka.Add(wLinijProfil.First)
            Else
                'апроксимируем начальную точку участка
                Dim lpointB As Point2d = wLinijProfil(lIndexB - 1)
                Dim lpointe As Point2d = wLinijProfil(lIndexB)
                Dim lwspY As Double = lpointB.Y + (ixdwgB - lpointB.X) * (lpointe.Y - lpointB.Y) / (lpointe.X - lpointB.X)
                lSpUchastka.Add(New Point2d(ixdwgB, lwspY))
            End If

        End If

        Dim lIndexe = NajtiIndex(ixdwgE)
        If lIndexe < 0 Then lIndexe = lSpUchastka.Count - 1
        If lIndexe < lIndexB Then Return lSpUchastka
        For i As Integer = lIndexB To lIndexe - 1
            Dim lwsp1 = lSpUchastka.Last
            Dim lwsp2 = wLinijProfil(i)
            If lwsp2.X.CompareTo(lwsp1.X) > 0 Then lSpUchastka.Add(lwsp2)
        Next


        Dim lpB As Point2d = wLinijProfil(lIndexe - 1)
        Dim lpe As Point2d = wLinijProfil(lIndexe)
        Dim wspY As Double = lpB.Y + (ixdwgE - lpB.X) * (lpe.Y - lpB.Y) / (lpe.X - lpB.X)
        lpB = lSpUchastka.Last
        lpe = New Point2d(ixdwgE, wspY)
        If lpB.X.CompareTo(lpe.X) < 0 Then lSpUchastka.Add(lpe)

        Return lSpUchastka
    End Function
    Private Function OpredLinKoeff(iIndB As Integer, iIndE As Integer) As Double
        Dim lpointB As Point2d = wLinijProfil(iIndB)
        Dim lpointe As Point2d = wLinijProfil(iIndE)
        Return (lpointe.Y - lpointB.Y) / (lpointe.X - lpointB.X)
    End Function
    Private Function GetUchastokLiniiК(ixdwgB As Double, ixdwgE As Double) As List(Of Point2d)
        Dim lSpUchastka As New List(Of Point2d)
        Dim lIndexB = NajtiIndex(ixdwgB) 'находим индекс элемента большего заданого критерия
        Dim lIndexe = NajtiIndex(ixdwgE)
        If lIndexB < 0 Then lIndexB = lSpUchastka.Count - 1
        If lIndexe < 0 Then lIndexe = lSpUchastka.Count - 1
        If lIndexB = lIndexe Then

            lSpUchastka.Add(wLinijProfil(lIndexB))
            Return lSpUchastka
        End If

        ' 
        Dim lModkoeffuchNa2 = 2.0 * Math.Abs(OpredLinKoeff(lIndexB, lIndexe))


        If lIndexB = 0 Then
            lSpUchastka.Add(wLinijProfil.First)
        Else
            'апроксимируем начальную точку участка
            Dim lpointB As Point2d = wLinijProfil(lIndexB - 1)
            Dim lpointe As Point2d = wLinijProfil(lIndexB)
            Dim lkoeffT = (lpointe.Y - lpointB.Y) / (lpointe.X - lpointB.X)
            ' If Math.Abs(lkoeffT) < lModkoeffuchNa2 Then
            Dim lwspY As Double = lpointB.Y + (ixdwgB - lpointB.X) * lkoeffT
            lSpUchastka.Add(New Point2d(ixdwgB, lwspY))
            '  Else
            '    Dim lwspY As Double = lpointB.Y + (ixdwgB - lpointB.X) * Math.Sign(lkoeffT) * lModkoeffuchNa2
            '    lSpUchastka.Add(New Point2d(ixdwgB, lwspY))
            'End If

        End If


        If lIndexe < lIndexB Then Return lSpUchastka
        '    Dim lPred = lSpUchastka(0)
        For i As Integer = lIndexB To lIndexe - 1
            Dim lpred = lSpUchastka.Last
            Dim lwsp2 = wLinijProfil(i)

            If lwsp2.X.CompareTo(lpred.X) > 0 Then
                Dim lkoef = (lwsp2.Y - lpred.Y) / (lwsp2.X - lpred.X)
                If Math.Abs(lkoef) < lModkoeffuchNa2 Then
                    lSpUchastka.Add(lwsp2)
                Else
                    Dim lwspY As Double = lpred.Y + (lwsp2.X - lpred.X) * Math.Sign(lkoef) * lModkoeffuchNa2
                    lSpUchastka.Add(New Point2d(lwsp2.X, lwspY))
                End If

            End If

        Next


        Dim lpB As Point2d = wLinijProfil(lIndexe - 1)
        Dim lpe As Point2d = wLinijProfil(lIndexe)
        Dim wspY As Double = lpB.Y + (ixdwgE - lpB.X) * (lpe.Y - lpB.Y) / (lpe.X - lpB.X)
        lpB = lSpUchastka.Last
        lpe = New Point2d(ixdwgE, wspY)
        If lpB.X.CompareTo(lpe.X) < 0 Then
            lSpUchastka.Add(lpe)
        Else
            lSpUchastka.Remove(lpB)
            lSpUchastka.Add(lpe)
        End If


        Return lSpUchastka
    End Function


    Private Function GlubinaXdwg(iX As Double, iGlubinaBeg As Double, iglubinaEnd As Double) As Double
        If iX < wRastOtNachalaDwgBeg Then Return iGlubinaBeg
        If iX > wRastOtNachalaDwgEnd Then Return iglubinaEnd
        Dim delta As Double = iX - wRastOtNachalaDwgBeg

        Return iGlubinaBeg + delta * (iglubinaEnd - iGlubinaBeg) / (wRastOtNachalaDwgEnd - wRastOtNachalaDwgBeg)
    End Function
    Function GetSmeschenPoint(iGlubinaBed As Double, iGlubinaEnd As Double, iXdwg As Double) As Point2d
        Dim lsmesch As New List(Of Point2d)
        Dim ly = Me.GetPointLinii(iXdwg)

        Return New Point2d(iXdwg, ly.Y - GlubinaXdwg(iXdwg, iGlubinaBed, iGlubinaEnd))



    End Function
    Function GetSmeschen(iGlubinaBed As Double, iGlubinaEnd As Double) As List(Of Point2d)
        Dim lsmesch As New List(Of Point2d)
        For Each el As Point2d In wLinijProfil
            lsmesch.Add(New Point2d(el.X, el.Y - GlubinaXdwg(el.X, iGlubinaBed, iGlubinaEnd)))

        Next
        Return lsmesch
    End Function
    ''' <summary>
    ''' конструктор для операций с гребенком профиля
    ''' </summary>
    ''' <param name="iSp"> Список точек гребенки профиля  </param>
    ''' <remarks></remarks>
    Sub New(iSp As List(Of Point2d))
        wLinijProfil = New List(Of Point2d)
        wLinijProfil.AddRange(iSp)

        If wLinijProfil.Last.X < wLinijProfil.First.X Then wLinijProfil.Reverse()
        wRastOtNachalaDwgBeg = wLinijProfil.First.X
        wRastOtNachalaDwgEnd = wLinijProfil.Last.X
        '  If iPrParApr Then wLinijProfil = OprApr()
    End Sub
    Sub UstLinApr()
        wLinijProfil = OprApr()
    End Sub

    Function Otklonenie() As Double()
        Dim lLineGr As New Line2d(wLinijProfil.First, wLinijProfil.Last)

        Dim ldistanze = wRastOtNachalaDwgEnd - wRastOtNachalaDwgBeg
        Dim lmin = 0
        Dim lmax = 0
        Dim elmin As Point2d = wLinijProfil.First
        For Each el As Point2d In wLinijProfil
            Dim lpar = (el.X - wRastOtNachalaDwgBeg) / ldistanze
            Dim lPointapr = lLineGr.EvaluatePoint(lpar)
            Dim Delta = el.Y - lPointapr.Y
            If Delta < lmin Then
                lmin = el.Y - lPointapr.Y

            End If
            If Delta > lmax Then
                lmax = el.Y - lPointapr.Y

            End If
        Next
        Dim lrez(1) As Double
        lrez(0) = lmin
        lrez(1) = lmax
        Return lrez
    End Function
    Function MinOtkl() As Double
        Dim lLineGr As New Line2d(wLinijProfil.First, wLinijProfil.Last)

        Dim ldistanze = wRastOtNachalaDwgEnd - wRastOtNachalaDwgBeg
        Dim lmin = 0.0
        Dim elmin As Point2d = wLinijProfil.First
        For Each el As Point2d In wLinijProfil
            Dim lpar = (el.X - wRastOtNachalaDwgBeg) / ldistanze
            Dim lPointapr = lLineGr.EvaluatePoint(lpar)
            If el.Y - lPointapr.Y < lmin Then
                lmin = el.Y - lPointapr.Y
                elmin = el
            End If
        Next
        Return lmin
    End Function
    Private Function OprAprP() As List(Of Point2d)

        Dim lLineGr As New Line2d(wLinijProfil.First, wLinijProfil.Last)

        Dim ldistanze = wRastOtNachalaDwgEnd - wRastOtNachalaDwgBeg
        Dim wmin = 0.0
        Dim elmin As Point2d = wLinijProfil.First
        For Each el As Point2d In wLinijProfil
            Dim lpar = (el.X - wRastOtNachalaDwgBeg) / ldistanze
            Dim lPointapr = lLineGr.EvaluatePoint(lpar)
            If el.Y - lPointapr.Y < wmin Then
                wmin = el.Y - lPointapr.Y
                elmin = el
            End If
        Next
        Dim lel = New Point2d(elmin.X, elmin.Y - 0.9 * wmin)
        Dim eps = wmin / elmin.Y
        '  lel = lLineGr.EvaluatePoint(elmin.X - wRastOtNachalaDwgBeg / ldistanze)
        Dim lparabol As New Parabola(wLinijProfil.First, lel, wLinijProfil.Last)
        Return lparabol.SdelatParabolu(wLinijProfil)
    End Function
    ''' <summary>
    ''' Линейная апроксимация гребенки профиля
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function OprApr() As List(Of Point2d)

        Dim lLineGr As New Line2d(wLinijProfil.First, wLinijProfil.Last)
        Dim lSpPoint As New List(Of Point2d)
        Dim ldistanze = wRastOtNachalaDwgEnd - wRastOtNachalaDwgBeg


        For Each el As Point2d In wLinijProfil
            Dim lpar = (el.X - wRastOtNachalaDwgBeg) / ldistanze
            Dim lPointapr = lLineGr.EvaluatePoint(lpar)
            lSpPoint.Add(lPointapr)

        Next


        Return lSpPoint
    End Function
End Class
Public Class Parabola
    Private wP1, wp2, wp3 As Point2d
    '   Private wX2minusX1, wY2minusY1, wX2Y1minusX1Y2, wX1plusX2, wX1X2 As Double
    Private wA, wB, wC As Double
    Sub New(iP1 As Point2d, ip2 As Point2d, ip3 As Point2d)
        wP1 = iP1
        wp2 = ip2
        wp3 = ip3
        OprKoeff()
    End Sub
    Function Fun(P As Point2d) As Double
        Dim X = P.X


        Return wA * X * X + wB * X + wC
        'If Double.IsNaN(wz) Then
      



    End Function
    Function FunEps(P As Point2d) As Double
        Dim X = P.X
        Dim Eps = 0.5 * P.Y

        Dim wz = wA * X * X + wB * X + wC
        'If Double.IsNaN(wz) Then
        '    Return P.Y
        'End If
        Dim delta = Math.Abs(wz - P.Y)
        If wz > P.Y Then
            If delta > Eps Then
                Return P.Y + Eps
            Else
                Return wz
            End If
        Else
            If delta > Eps Then
                Return P.Y - Eps
            Else
                Return wz
            End If

        End If



    End Function
    Private Sub OprKoeff()
        Dim lX2minusX1 = wp2.X - wP1.X
        Dim lY2minusY1 = wp2.Y - wP1.Y
        Dim lX2Y1minusX1Y2 = wp2.X * wP1.Y - wP1.X * wp2.Y
        Dim lX1plusX2 = wp2.X + wP1.X
        Dim lX1X2 = wp2.X * wP1.X
        Dim X3 = wp3.X
        Dim werh = wp3.Y - (X3 * lY2minusY1 + lX2Y1minusX1Y2) / lX2minusX1
        Dim niz = X3 * (X3 - lX1plusX2) + lX1X2
        wA = werh / niz
   
        If Double.IsNaN(wA) OrElse Double.IsInfinity(wA) Then
            wA = 0
            wB = (wp3.Y - wP1.Y) / (wp3.X - wP1.X)
            wC = wP1.Y - wB * wP1.X
        Else

            wB = lY2minusY1 / lX2minusX1 - wA * lX1plusX2
            wC = lX2Y1minusX1Y2 / lX2minusX1 + wA * lX1X2
        End If

        'Dim lly = Fun(wP1)
        'Dim llly = Fun(wp2)
        'Dim lllly = Fun(wp3)
    End Sub
    Function SdelatParabolu(iSp As List(Of Point2d)) As List(Of Point2d)
        Dim lsp As New List(Of Point2d)
        For Each el As Point2d In iSp
            lsp.Add(New Point2d(el.X, Fun(el)))
        Next
        Return lsp
    End Function

End Class

