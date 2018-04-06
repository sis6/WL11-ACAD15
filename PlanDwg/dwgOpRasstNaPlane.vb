Imports BazDwg
#If ARX_APP Then
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.DatabaseServices
#Else
Imports Teigha.Geometry
Imports Teigha.DatabaseServices
#End If


Public Class dwgOpRasstNaPlane
    Private wX, wYp As Double
    Private wOpRasst As modRasstOp.wlOpRasst
    ' переменные за отражение плана
    Private wXdwg, wYdwg As Double
    Private Shared wKoorX, wKoorY As clsKoor
    Property TchkPlana As clsPrf.clsPiket3d
    ''' <summary>
    ''' устанавливает объекты класса координат для пересчета реальных координат в координаты плана и обратно
    ''' </summary>
    ''' <param name="iKoorX"> координаты по х </param>
    ''' <param name="iKoorY">координаты по y  </param>
    ''' <remarks> функция общая для всех опор трасы, достаточно установить при инициализации трассы   </remarks>
    Public Shared Sub KoorPl(ByVal iKoorX As clsKoor, ByVal iKoorY As clsKoor)
        wKoorX = iKoorX
        wKoorY = iKoorY
    End Sub
    ''' <summary>
    ''' нахождение координат чертежа любой реальной точки по правилу преобразования точек трассы
    ''' </summary>
    ''' <param name="iRealTchk"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetDwg(ByVal iRealTchk As Point2d) As Point2d
        Return New Point2d(wKoorX.GetDwg(iRealTchk.X), wKoorY.GetDwg(iRealTchk.Y))
    End Function
    ReadOnly Property ProekzijOpor() As List(Of Point2d)
        Get
            Dim masGr As New List(Of Point2d)
            Dim lwiletP, lwiletM As Double
            lwiletP = 3    'wOpRasst.DannOpor.WiletP
            lwiletM = 1.5     'wOpRasst.DannOpor.WiletM
            masGr.Add(New Point2d(lwiletP, -lwiletM))
            masGr.Add(New Point2d(lwiletP, lwiletM))
            masGr.Add(New Point2d(-lwiletP, lwiletM))
            masGr.Add(New Point2d(-lwiletP, -lwiletM))

            '   masGr.Add(New Point2d(0, 2 * lwiletM))

            Return masGr
        End Get
    End Property

#Region "Plan"
    ' Private Property Length As Integer

    Sub New(ByVal iTchkPlan As clsPrf.clsPiket3d, ByVal iOpRasst As modRasstOp.wlOpRasst)

        Dim lk() As Double
        lk = iTchkPlan.KoorPk(iOpRasst.RastOtNachala)
        _TchkPlana = iTchkPlan
        wOpRasst = iOpRasst
        wX = lk(0)
        wYp = lk(1)
        If NaUgluLi() Then
            wOpRasst.UgolPoworotaOp = 0.5 * (TchkPlana.Ugol + TchkPlana.DirectUgol - Math.PI) ' угол биссектрисы поворота
        Else
            wOpRasst.UgolPoworotaOp = TchkPlana.Ugol - 0.5 * Math.PI
        End If
    End Sub
    Private Function NaUgluLi() As Boolean
        If wOpRasst.Tip = 0 Then Return False

        If wOpRasst.rawnoR(TchkPlana.Piket.RastOtnachala) And TchkPlana.EstUgolPoworota Then
            Return True
        Else
            Return False
        End If

    End Function
    Private Function TchkOkoloTr(ByVal iH As Double, ByVal iDelta As Double) As Point2d
        Dim RPoTrasse As Double = wOpRasst.RastOtNachala + iDelta
        Dim Wugol As Double ' угол трассы
        Dim lKoor(), lx, ly As Double
        If RPoTrasse < TchkPlana.Piket.RastOtnachala Then

            lKoor = TchkPlana.KoorPk(RPoTrasse)
            Wugol = TchkPlana.Ugol
            lx = lKoor(0)
            ly = lKoor(1)
        Else
            If TchkPlana.Sled IsNot Nothing Then
                lKoor = TchkPlana.Sled.KoorPk(RPoTrasse)
                Wugol = TchkPlana.DirectUgol
                lx = lKoor(0)
                ly = lKoor(1)
            Else
                Wugol = TchkPlana.Ugol
                lx = wX
                ly = wYp
            End If
            Return Kommand.UstTchk(lx, ly, Math.Abs(iH), Wugol + 0.5 * Math.Sign(iH) * Math.PI)
        End If
    End Function
    Private Function TchkOkoloOp(ByVal iDelta As Double, ByVal iH As Double) As Point2d
        Dim RPoTrasse As Double = wOpRasst.RastOtNachala + iDelta
        Dim Wugol As Double ' угол трассы

        Dim lHor As Point2d
        Wugol = TchkPlana.Ugol
        If iDelta > 0 Then
            lHor = Kommand.UstTchk(wX, wYp, iDelta, Wugol)
        Else
            lHor = Kommand.UstTchk(wX, wYp, -iDelta, Wugol + Math.PI)

        End If
        Return Kommand.UstTchk(lHor.X, lHor.Y, Math.Abs(iH), Wugol + 0.5 * Math.Sign(iH) * Math.PI)
    End Function
    Private Function TchkOkoloOp(ByVal TchkSdwiga As Point2d) As Point2d
        Return TchkOkoloOp(TchkSdwiga.X, TchkSdwiga.Y)
    End Function

    Function GrTchkOhranZonP() As Point2d
        With wOpRasst
            Dim wUgol As Double = TchkPlana.Ugol - .UgolPoworotaOp
            Dim lwilet = .DannOpor.TrawersPlus + clsPrf.clsTrass.OhranZon / Math.Sin(wUgol)
            Return Kommand.UstTchk(wX, wYp, lwilet, .UgolPoworotaOp)
        End With
    End Function
    Function GrTchkOhranZonM() As Point2d
        With wOpRasst
            Dim wUgol As Double = TchkPlana.Ugol - .UgolPoworotaOp
            Dim lwilet As Double = .DannOpor.TrawersMinus + clsPrf.clsTrass.OhranZon / Math.Sin(wUgol)
            Return Kommand.UstTchk(wX, wYp, lwilet, .UgolPoworotaOp + Math.PI)
        End With
    End Function
    Function GrTchkProvodP() As Point2d
        With wOpRasst
            Dim wUgol As Double = .UgolPoworotaOp
            Dim lwilet As Double = .DannOpor.TrawersPlus
            Return Kommand.UstTchk(wX, wYp, lwilet, wUgol)
        End With
    End Function
    Function GrTchkProvodM() As Point2d
        With wOpRasst
            Dim wUgol As Double = .UgolPoworotaOp
            Dim lwilet As Double = .DannOpor.TrawersMinus
            Return Kommand.UstTchk(wX, wYp, lwilet, wUgol + Math.PI)
        End With
    End Function
#End Region
    Private Function WrOtwodFaz(ByVal iwilet As Double) As Point2d()
        Dim wM(1) As Point2d
        Dim lwiletM, lDelta As Double

        With wOpRasst
            Dim wUgol As Double = TchkPlana.Ugol - .UgolPoworotaOp 'угол между трасой и опорой
            lDelta = 2.5 / Math.Sin(wUgol)
            If iwilet > 0 Then
                lwiletM = iwilet - lDelta
                iwilet += lDelta

                wM(0) = Kommand.UstTchk(wX, wYp, iwilet, .UgolPoworotaOp)
                wM(1) = Kommand.UstTchk(wX, wYp, lwiletM, .UgolPoworotaOp)
            Else
                iwilet = -iwilet
                lwiletM = iwilet - lDelta
                iwilet += lDelta
                wM(0) = Kommand.UstTchk(wX, wYp, iwilet, .UgolPoworotaOp + Math.PI)
                wM(1) = Kommand.UstTchk(wX, wYp, lwiletM, .UgolPoworotaOp + Math.PI)
            End If
        End With
        Return wM
    End Function
    Private Function WrOtwodLin() As Point2d()
        Dim wM(1) As Point2d
        Dim lwilet, lwiletM, lDelta As Double
        With wOpRasst
            Dim wUgol As Double = TchkPlana.Ugol - .UgolPoworotaOp
            lDelta = 2.0 / Math.Sin(wUgol)

            lwiletM = .DannOpor.TrawersMinus + lDelta
            lwilet += .DannOpor.TrawersPlus + lDelta

            wM(0) = Kommand.UstTchk(wX, wYp, lwilet, .UgolPoworotaOp)
            wM(1) = Kommand.UstTchk(wX, wYp, lwiletM, .UgolPoworotaOp + Math.PI)

        End With
        Return wM

    End Function
    Function GrtchkWremZon(ByVal faz As Integer) As Point2d()

        With wOpRasst


            Select Case faz
                Case 0
                    Return WrOtwodFaz(.DannOpor.Trawers(modRasstOp.Fazi.faz0))
                Case 1
                    Return WrOtwodFaz(.DannOpor.Trawers(modRasstOp.Fazi.faz1))
                Case 2
                    Return WrOtwodFaz(.DannOpor.Trawers(modRasstOp.Fazi.faz2))
                Case Else
                    Return WrOtwodLin()

            End Select



        End With

    End Function
#Region "Obraz na DWg"
    Public Sub WiwProekOpor(ByVal coll As DBObjectCollection)

        Dim lKontur As New myKontur(2)
        lKontur.GrTchk = ProekzijOpor()
        Dim CollTchkOtv As Point2dCollection = lKontur.KonturOtv

        Dim DwgGrTchk As New Point2dCollection
        Dim DwgProek As New Point2dCollection
        For i As Integer = 0 To lKontur.MaxNumProek
            Dim ltchk As Point2d = lKontur.GrTchk(i)
            DwgProek.Add(GetDwg(TchkOkoloOp(ltchk)))
        Next
        For Each el As Point2d In CollTchkOtv
            DwgGrTchk.Add(GetDwg(TchkOkoloOp(el)))
        Next
        Dim lObrazP As DBObject = dbPrim.CreateLwPolyline(DwgProek, 0, 0, 0)
        Dim lObrazOtw As DBObject = dbPrim.CreateLwPolyline(DwgGrTchk, 0, 0, 0)
        CType(lObrazP, Polyline).Closed = True
        CType(lObrazOtw, Polyline).Closed = True
        coll.Add(lObrazP)
        coll.Add(lObrazOtw)
    End Sub
    Public Sub Wiwop(ByVal coll As DBObjectCollection, Optional ByVal Razm As Double = 1, Optional ByVal iOpPred As dwgOpRasstNaPlane = Nothing)
        Dim PozName As Double = 10
        Dim PozPik As Double = PozName + 5

        wXdwg = wKoorX.GetDwg(wX)
        wYdwg = wKoorY.GetDwg(wYp)

        With wOpRasst
            coll.Add(dbPrim.CreateNakl(wXdwg, wYdwg, Razm, Razm, .UgolPoworotaOp))
            coll.Add(Znaki.CreateKrug(wXdwg, wYdwg, 0.5 * Razm))
            If wOpRasst.Tip > 0 Then
                coll.Add(Znaki.CreatePrTreg(wXdwg, wYdwg, Razm, .UgolPoworotaOp))

            End If
            ' CreateEntities.MakeEntities.CreateLeader(New Point3d(wXdwg, wYdwg - PozName, 0), 10, CStr(.NumName) & "  " & Format(.Piketaj, "#.#") & "  " & CStr(.UserTipOp))

            'coll.Add(dbPrim.CreateText(New Point3d(wXdwg, wYdwg - PozName, 0), CStr(.NumName), 5))
            'coll.Add(dbPrim.CreateText(New Point3d(wXdwg, wYdwg - PozPik, 0), Format(.Piketaj, "#.#"), 5))
            'coll.Add(dbPrim.CreateText(New Point3d(wXdwg, wYdwg - PozPik - 5, 0), CStr(.UserTipOp), 5))
            '     coll.Add(dbPrim.CreateMText(New Point3d(wXdwg, wYdwg - PozName, 0), CStr(.NumName) & "  " & Format(.Piketaj, "#.#") & "  " & CStr(.UserTipOp), 10, 5))
            '  Dim idMtext As ObjectId = CreateEntities.dwgText.CreateMText(New Point3d(wXdwg, wYdwg + 15, 0), _
            '                                                    CStr(.NumName) & "  " & Format(.Piketaj, "#.#") & "  " & CStr(.UserTipOp), 10, 3)
            ' CreateEntities.MakeEntities.CreateLeader(New Point3d(wXdwg, wYdwg, 0), 10, idMtext)
            coll.Add(dbPrim.CreateMLeader(New Point3d(wXdwg + 10, wYdwg + 30, 0), New Point3d(wXdwg, wYdwg, 0), CStr(.NumName) & "\P" &
                                      CStr(.UserTipOp) & "\P" & clsPrf.ClsPiket.StrPiketaj(.Piketaj)))  ' 
            If iOpPred IsNot Nothing Then
                Dim lX As Double = 0.5 * (wXdwg + iOpPred.wXdwg)
                Dim lY As Double = 0.5 * (wYdwg + iOpPred.wYdwg)
                Dim lDlPoRast As Long = CLng(.RastOtNachala - iOpPred.wOpRasst.RastOtNachala)
                Dim lDlPoPiket As Long = CLng(.Piketaj) - CLng(iOpPred.wOpRasst.Piketaj)
                Dim lnaWiw As Long
                If Math.Abs(lDlPoPiket - lDlPoRast) > 2 Then
                    lnaWiw = lDlPoRast
                Else
                    lnaWiw = lDlPoPiket
                End If
                coll.Add(dbPrim.CreateText(New Point3d(lX, lY, 0), Format(lnaWiw, "#.#"), 5))
                '    coll.Add(dbPrim.CreateText(New Point3d(lX, lY, 0), Format(.RastOtNachala - iOpPred.wOpRasst.RastOtNachala, "#.#"), 5))
            End If
        End With

    End Sub
#End Region
End Class
