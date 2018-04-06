Option Strict On
Option Explicit On
#If ARX_APP Then
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.ApplicationServices
Imports DBTransMan = Autodesk.AutoCAD.DatabaseServices.TransactionManager
#Else
Imports Bricscad.ApplicationServices
Imports _AcCm = Teigha.Colors
Imports Teigha.DatabaseServices
Imports _AcEd = Bricscad.EditorInput
Imports Teigha.Geometry
Imports _AcGi = Teigha.GraphicsInterface
Imports _AcGs = Teigha.GraphicsSystem
Imports _AcPl = Bricscad.PlottingServices
Imports _AcBrx = Bricscad.Runtime
Imports _AcTrx = Teigha.Runtime
Imports _AcWnd = Bricscad.Windows

#End If
Imports clsPrf
Imports modRasstOp

Imports BazDwg

Public Class dwgObrazOporRasst
    Public Const WisTextR As Double = 3
    Private Op As wlOpRasst
    Private wRasst As wlRasst
    Private colEntiteOP As New ObjectIdCollection
    Private X, otm, otmWer, otmwer1, otmwer2, otmwerT, otmSer, otmDelta As Double
    '  Private DannOpor1 As DwgRstOpTr
    Private wNameGrupp As String

    Sub Ust()
        With CType(wRasst.Trassa, DwgTr)
            X = .DwgXpoRast(Op.RastOtNachala)
            otm = .DwgYpoOtm(Op.Otmetka)
            otmDelta = .DwgYpoOtm(Op.Otmetka + Op.DeltaWis)
            otmWer = .DwgYpoOtm(Op.OtmetkaWerha(Fazi.faz0))
            otmwer1 = .DwgYpoOtm(Op.OtmetkaWerha(Fazi.faz1))
            otmwer2 = .DwgYpoOtm(Op.OtmetkaWerha(Fazi.faz2))
            otmwerT = .DwgYpoOtm(Op.OtmetkaWerha(Fazi.tros))
        End With
        otmSer = 0.5 * (otmWer + otm)

    End Sub
    ReadOnly Property RisOpor() As ObjectIdCollection
        Get
            Return colEntiteOP
        End Get
    End Property

    Private ReadOnly Property Pred() As dwgObrazOporRasst
        Get
            If Op.Pred Is Nothing Then
                Return Nothing
            Else
                Return CType(Op.Pred.Obraz, dwgObrazOporRasst)
            End If

        End Get

    End Property
    Private ReadOnly Property Sled() As dwgObrazOporRasst
        Get
            If Op.Sled Is Nothing Then
                Return Nothing
            Else
                Return CType(Op.Sled.Obraz, dwgObrazOporRasst)
            End If

        End Get

    End Property
    ReadOnly Property DwgX() As Double
        Get
            Return X
        End Get
    End Property
    ReadOnly Property DwgOtmTros() As Double
        Get
            Return otmwerT
        End Get
    End Property
    'Sub UstPred(ByVal op As RstOpTrDwg) 'устанавливает ор перед собственой 
    '    op.PredOp = Me.PredOp
    '    op.SledOp = Me
    '    Me.PredOp = op
    '    'op.Pred = wBegOp.Pred
    '    'op.Sled = wBegOp
    '    'wBegOp.Pred = op

    'End Sub
    'Sub UstSled(ByVal op As RstOpTrDwg) 'устанавливает ор ппосле собственой 
    '    op.PredOp = Me
    '    op.SledOp = Me.SledOp
    '    Me.SledOp = op
    '    'op.Pred = wBegOp.Pred
    '    'op.Sled = wBegOp
    '    'wBegOp.Pred = op

    'End Sub

    Private Sub WiwopNaAbr(ByVal Tip As Integer, ByVal Xdwg As Double, ByVal Ydwg As Double, ByVal coll As ObjectIdCollection, Optional ByVal UgolOp As Double = 0)
        Dim Rad As Double = 1
        Dim Radw As Double = 2 * Rad
        Dim colEnt As New DBObjectCollection
        colEnt.Add(BazDwg.Znaki.CreateKrug(Xdwg, Ydwg, Rad))
        colEnt.Add(dbPrim.CreateNakl(Xdwg, Ydwg, Radw, Radw, UgolOp))
        If Tip > 0 Then
            colEnt.Add(BazDwg.Znaki.CreatePrTreg(Xdwg, Ydwg, Radw, 0))

        End If
        For Each el As ObjectId In dbPrim.Wkl(colEnt)
            coll.Add(el)
        Next

    End Sub
    Private Sub SdwigPrimPox(ByVal iPrim As Entity, ByVal isdwigX As Double)
        Dim acPt3d As Point3d = New Point3d(0, 0, 0)
        Dim acVec3d As Vector3d = acPt3d.GetVectorTo(New Point3d(isdwigX, 0, 0))

        iPrim.TransformBy(Matrix3d.Displacement(acVec3d))
    End Sub
    ''' <summary>
    ''' Выводит опору на профиль трассы
    ''' </summary>
    ''' <remarks></remarks>
    Sub wiwestiOP_Profil()
        Dim colEnt As New DBObjectCollection
        Dim OtmNaAbr As Double = CType(wRasst.Trassa, DwgTr).objGeom.Podpis.PolGrafAbr
        Dim XmShir As Double = X - 2
        Dim XpShir As Double = X + 2
        BazDwg.MakeNeGraf.DeleteIzGroup(wNameGrupp)
        colEnt.Add(BazDwg.dbPrim.CreateLine(X, otm, X, otmwerT, Op.GetStrPred)) 'Вывели тело опоры
        If Math.Abs(Op.DeltaWis) > 0.01 Then colEnt.Add(Znaki.CreatePrjamoygolnik(X, otm, otmDelta - otm, 2))
        colEnt.Add(BazDwg.dbPrim.CreateLine(XmShir, otmWer, XpShir, otmWer))
        ' colEnt.Add(dbPrim.CreateLine(X, otmWer, X, otmwer1)) 'Вывели тело опоры от нижней до первой
        colEnt.Add(dbPrim.CreateLine(XmShir, otmwer1, XpShir, otmwer1))
        '   colEnt.Add(dbPrim.CreateLine(X, otmwer1, X, otmwer2)) 'Вывели тело опоры от  первой до второй
        colEnt.Add(dbPrim.CreateLine(XmShir, otmwer2, XpShir, otmwer2))
        ' colEnt.Add(dbPrim.CreateLine(X, otmwer2, X, otmwerT)) 'Вывели тело опоры от   второй до тоса
        colEnt.Add(dbPrim.CreateLine(XmShir, otmwerT, XpShir, otmwerT))
        colEnt.Add(dbPrim.CreateTextV(New Point3d(X - 1, otm + 0.4 * (otmSer - otm), 0), Op.StrPiketajOp(), DwgTr.WisTextP)) 'пикетаж на тело опоры
        Select Case Op.Tip
            Case 1
                colEnt.Add(Znaki.CreateTregW(X, otmwerT, 2, 3))
            Case 0
                colEnt.Add(dbPrim.CreateLine(XmShir, otmwerT, XpShir, otmwerT))
            Case Else
                colEnt.Add(Znaki.CreateTreg(X, otmwerT, 2, 3))

        End Select




        'Выводим имя и тип опоры

        Dim ltxt1, ltxt2 As Entity
        ltxt1 = dbPrim.CreateText(New Point3d(X, otmwerT + 16, 0), Op.NumName, WisTextR)
        ltxt2 = dbPrim.CreateText(New Point3d(X, otmwerT + 9, 0), Op.UserTipOp, WisTextR)
        ' ltxt1.MoveStretchPointsA()
        Dim Ex As Extents3d = ltxt1.Bounds.Value
        Dim R As Double = Math.Abs(Ex.MaxPoint.X - Ex.MinPoint.X)
        SdwigPrimPox(ltxt1, -0.5 * R)
        Ex = ltxt2.Bounds.Value
        Dim wR As Double = Math.Abs(Ex.MaxPoint.X - Ex.MinPoint.X)
        SdwigPrimPox(ltxt2, -0.5 * wR)
        If R < wR Then R = wR
        colEnt.Add(ltxt1)
        colEnt.Add(ltxt2)
        colEnt.Add(dbPrim.CreateLine(X - 0.5 * R, otmwerT + 15, X + 0.5 * R, otmwerT + 15)) 'горизонтальная черта между названием и типом
        'расстояние между опрами
        Dim lPred As dwgObrazOporRasst = Pred
        If Not lPred Is Nothing Then
            Dim lBegX = 0.5 * (lPred.X + X)
            Dim lShir = lBegX - lPred.X
            Dim lOtmWiwDlProleta As Double = 0.5 * (lPred.otmWer + otmWer)
            Dim lpiketajPred As Double = Op.Pred.PiketajOporW_SledUchastke
            If lpiketajPred < 0 Then lpiketajPred = Op.Pred.Piketaj
            Dim lWrDlin As Long = CLng(Op.Piketaj) - CLng(lpiketajPred)
            If lWrDlin = 0 Then lWrDlin = CLng(Op.RastOtNachala) - CLng(Op.Pred.RastOtNachala)
            If lWrDlin > 0 Then
                Dim lprim As Entity = dbPrim.CreateText(New Point3d(lBegX, lOtmWiwDlProleta, 0), Format(lWrDlin, "#."), DwgTr.WisTextP)
                Dim lEx As Extents3d = lprim.Bounds.Value
                Dim ShirTxt = Math.Abs(lEx.MaxPoint.X - lEx.MinPoint.X)

                Dim acPt3d As Point3d = New Point3d(0, 0, 0)
                Dim acVec3d As Vector3d = acPt3d.GetVectorTo(New Point3d(-0.5 * ShirTxt, 0, 0))

                lprim.TransformBy(Matrix3d.Displacement(acVec3d))

                '  colEnt.Add(lprim0)
                colEnt.Add(lprim)
            End If



        End If
        colEntiteOP = dbPrim.Wkl(colEnt)
        WiwopNaAbr(Op.Tip, X, OtmNaAbr, colEntiteOP, 0.5 * Math.PI)
        BazDwg.MakeNeGraf.InsertWGroup(colEntiteOP, wNameGrupp, Op.NumName)
        BazDwg.Kommand.changeSloj(colEntiteOP, DwgParam.SlRasstOpor)
    End Sub
    Function WiwestiOtmetkuNijnegoProvod(Napr As Double) As Entity
        '  "▼Нн.пр.=40,50м"
        Dim lDlinamLeader As Double = 2 * Math.Abs(Napr)
        Dim lPointFaz As New Point3d(X, otmWer, 0)
        Dim lpointwiwText As New Point3d(X + Napr, otmWer - lDlinamLeader, 0)
        Dim lMlider As MLeader = CType(BazDwg.dbPrim.CreateMLeader(lpointwiwText, lPointFaz, _
                                                                      "▼Нн.пр.=" & Format(Op.OtmetkaNijnFaz, "f2") & " м ", 2.5), MLeader)
        With lMlider
            .TextAlignmentType = TextAlignmentType.LeftAlignment
            .TextAttachmentDirection = TextAttachmentDirection.AttachmentHorizontal '  направление присоеденения
            .SetTextAttachmentType(CType(TextAttachmentType.AttachmentBottomLine, TextAttachmentType), LeaderDirectionType.LeftLeader)

            '    .TextAttachmentType = TextAttachmentType.AttachmentBottomLine '   тип присоеденения подчеркивать где подчеркивать
            .LandingGap = 1.0      'отступ от полки
            .DoglegLength = 0.2   'полка
            '    .ConnectionPoint(New Vector3d(lPointFaz.X - lpointwiwText.X, 1, 0))
            '    .TextAngleType = TextAngleType.InsertAngle

        End With
        Return lMlider

    End Function
    Function WiwestiOtmetkuZemli(Napr As Double) As Entity
        '  "▼Нн.пр.=40,50м"
        Dim lDlinamLeader As Double = 2 * Math.Abs(Napr)
        Dim lPointzemli As New Point3d(X, otm, 0)
        Dim lpointwiwText As New Point3d(X + Napr, otm + lDlinamLeader, 0)
        Dim lMlider As MLeader = CType(BazDwg.dbPrim.CreateMLeader(lpointwiwText, lPointzemli, _
                                                                      "▼Нзем.=" & Format(Op.Otmetka, "f2") & " м ", 2.5), MLeader)
        With lMlider
            .TextAlignmentType = TextAlignmentType.LeftAlignment
            .TextAttachmentDirection = TextAttachmentDirection.AttachmentHorizontal '  направление присоеденения
            .SetTextAttachmentType(CType(TextAttachmentType.AttachmentBottomLine, TextAttachmentType), LeaderDirectionType.LeftLeader)
            '   .TextAttachmentType = TextAttachmentType.AttachmentBottomLine '   тип присоеденения подчеркивать где подчеркивать
            .LandingGap = 1.0      'отступ от полки
            .DoglegLength = 0.2   'полка
            '    .ConnectionPoint(New Vector3d(lPointFaz.X - lpointwiwText.X, 1, 0))
            '    .TextAngleType = TextAngleType.InsertAngle

        End With
        Return lMlider

    End Function
    ReadOnly Property Opora() As wlOpRasst
        Get
            Return Op
        End Get
    End Property
    Sub Wideliti()
        BazDwg.Kommand.Wiswetit(colEntiteOP)
    End Sub

    Sub New(ByVal iop As wlOpRasst)
        Op = iop
        wRasst = iop.rstUch.Rasst
        wNameGrupp = dwgSlowar.DopustImjSlowaraj(modRasstOp.baz_fun.DobavitStrokGuid(iop.DataRow.UIdRast, iop.rstUch.NameUch).ToString)

        Ust()
        Op.Obraz = Me
    End Sub
    Sub UdalitObraz()
        BazDwg.MakeNeGraf.DeleteIzGroup(wNameGrupp)
        BazDwg.MakeNeGraf.DeleteGroup(wNameGrupp)
    End Sub
    ''' <summary>
    ''' Возвращает и записывает данные ассоциированные с опорой
    ''' </summary>
    ''' <value></value>
    ''' <returns> массив строк в которые записаны данные </returns>
    ''' <remarks>для обычных расчетов  важны только приведеные центры, остальное параметры расчетных режимов  </remarks>
    Property StrDan() As String()
        Get
            '  Return BazfunNet.CreateEntities.MakeNeGraf.ChitXdataIzGroup(wNameGrupp)
            Dim Slowar As New LeseSreib.clsLeseSreibUsl(wRasst)   ' в этом словаре расчетные условия  
            Return Slowar.GetZapis(Op.NumName)
        End Get
        Set(ByVal imasStr As String())
            Dim Slowar As New LeseSreib.clsLeseSreibUsl(wRasst)
            Slowar.SetZapis(Op.NumName, imasStr)
            ' BazfunNet.CreateEntities.MakeNeGraf.DobWGroupXdata(wNameGrupp, imasStr)
        End Set
    End Property
End Class
