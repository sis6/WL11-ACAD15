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
Imports _AcBr = Teigha.BoundaryRepresentation
Imports _AcCm = Teigha.Colors
Imports Teigha.DatabaseServices
Imports _AcEd = Bricscad.EditorInput
Imports Teigha.Geometry
Imports _AcGi = Teigha.GraphicsInterface
Imports _AcGs = Teigha.GraphicsSystem
Imports _AcPl = Bricscad.PlottingServices
Imports _AcBrx = Bricscad.Runtime
Imports Teigha.Runtime
Imports _AcWnd = Bricscad.Windows
Imports DBTransMan = Teigha.DatabaseServices.TransactionManager
#End If
Imports modRasstOp
Imports BazDwg
Imports Rashet
Imports clsPrf.Slujba
Imports ProfilBaseDwg

Public Class clsKommandRst
    Inherits clsKommandBase
    Private Shared objAnkUch As wlAnkUchWopt   'Выбраный анкерный участок
    Public Shared WibrOp As wlOpRasst
    Shared objFrmDinWiwoda As frmProlet
    Private Shared wfrmupr As FrmInfoUpr
    '  Private Shared wobjMenuUch As New dwgMenu
    Private SpAnkUch As New List(Of wlAnkUchTr)
    Private MaxNumAu As Integer
#Region "Расстановка на профиле  Главное меню"
    Private Function SwedObOpore(ByVal wop As modRasstOp.wlOpRasst) As String
        Dim Soob As String
        With wop
            Soob = "Имя участка трассы " & .rstUch.NameUch & vbCr
            Soob &= "Выбрана опора " & .NumName & " r " & .RastOtNachala & " Pik " & .Piketaj & " Имя Типа " & .UserTipOp
            If .Obraz Is Nothing Then
                Soob &= " не отрисована "
            Else
                Soob &= " Элементов в рисунке " & CType(.Obraz, dwgObrazOporRasst).RisOpor.Count
            End If
        End With
        Soob &= vbCr
        Return Soob
    End Function
    ''' <summary>
    ''' Выводит расстановку опор на профиль
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("RstNaPr")> _
    Public Sub wiwOpNaProfil()
        Kommand.createNewLayerNePrint(DwgParam.SlSlujbn)
        BazDwg.netSelectSet.OchistitSloj(DwgParam.SlSlujbn)

        If gRasst IsNot Nothing Then dwgWiwRasst.WiwRasstNaProfil()

        SkrutMenuUch()
    End Sub
    ''' <summary>
    ''' При наличие прикрепленного файла считывает в модель только расстановку 
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("LeseRasstXls")> _
    Public Sub LeseRasstXls()
        'чтение только расстановки 
        If gRasst Is Nothing Then
            Application.ShowAlertDialog("LeseRasstXl   отсутствует модель")
            Return
        End If
        ' Dim lmasuch() As wlUch = LeseSreib.ModIsp.LeseDannRasst(LeseSreib.LeseSlwFileUch, gRasst.Trassa)
        Dim lnamewl As String = gTrassa.NameLin
        Dim lnameRab As String = gTrassa.NameRab
        Dim lUnom As Integer = gTrassa.Unom

        Dim lmasuch() As wlUch = LeseSreib.ModIsp.LeseDannRasst(LeseSreib.LeseSlwFileUch, gRasst)
        '     Application.ShowAlertDialog("LeseRasstXl   Создаем расст")
        If lmasuch Is Nothing Then
            Application.ShowAlertDialog("LeseRasstXl   Ничего не считано")
            Return
        End If
        If lmasuch.Length < 1 Then
            Application.ShowAlertDialog("LeseRasstXl   Cчитаны пустые строки")
            Return
        End If
        '  LeseSreib.ModIsp.NameWl()

        Application.ShowAlertDialog("LeseRasstXl   Создаем расст")

        gRasst = Nothing

        gRasst = New wlRasst(New DwgTr(lnamewl, lnameRab, lUnom))

        For Each w As wlUch In lmasuch
            gTrassa.DobUch(w)
        Next
        gRasst.OprRast()
        SkrutMenuUch()
    End Sub
    ''' <summary>
    ''' Сохранение в словарях чертежа или в базе даных в зависимости от режима работы модели расстановки опор 
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("SohrWSlwRasst")> _
    Public Sub SohrWSlwRasst()
        If gTrassa.NameDwg = Application.DocumentManager.MdiActiveDocument.Name Then

			ZapisRasstWSohran()



		Else
            Application.ShowAlertDialog("Модель трассы создана  в " & gTrassa.NameDwg & vbCr _
                                        & "сохранение  в  " & Application.DocumentManager.MdiActiveDocument.Name & " недопустимо ")
        End If


    End Sub
    Shared Sub SkrutMenuUch()
        Dim m As New dwgMenuCui
        m.UdalMenuCui()
        If wfrmupr IsNot Nothing Then
            wfrmupr.Close()
            wfrmupr = Nothing
        End If
    End Sub
    Shared Sub DobawitMenuUch()
        Dim m As New dwgMenuCui
        m.BuildMenuCui(objAnkUch.NameAnkPr)
        If wfrmupr IsNot Nothing Then
            wfrmupr.Close()
            wfrmupr = Nothing
        End If

        wfrmupr = New FrmInfoUpr
        wfrmupr.Text = objAnkUch.NameAnkPr
        wfrmupr.Show()
    End Sub
    ''' <summary>
    ''' корректировка данных расстановки в форме. При наличие в составе трассы несколько участков, для корректировки предлагается первый.   
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("KorrDannRasst")> _
    Public Sub KorrDannRasst()
        Dim lobj As New LeseSreib.FrmKorrRasstWlUch
        '  lobj.RasstNaTrasse = gRasst
        If gRasst Is Nothing Then

            If MsgBox("Трасса не представлена в чертеже." & vbCr & "Загрузить участок по умолчанию<OK>", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
				Dim wLStr() = {My.Settings.BasePapkaGlobal & "\DANN\default11.xls"}
				clsKommand0.ZagruzkaTrassRasstIzExcel(wLStr)

			Else
                Return
            End If


        End If
        ' MsgBox(Me.ToString & "KorrDannUch uch " & gRasst.Trassa.Uchastki.Count)
        lobj.IzmUch = gRasst.Uch(0)
        lobj.Dostup = gDostup
        Application.ShowModelessDialog(lobj)

		SkrutMenuUch()
    End Sub
    ''' <summary>
    ''' корректировка данных расстановки в форме. Выбор участка происходит указанием точки на чертеже
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("KorrDannRasstWibor")> _
    Public Sub KorrDannProfWibor()
        Dim lobj As New LeseSreib.FrmKorrRasstWlUch
        '  lobj.RasstNaTrasse = gRasst
        If gRasst Is Nothing Then
            Application.ShowAlertDialog("Трасса не представлена в чертеже.")
            Return
        Else
            Application.ShowAlertDialog("Укажите точку на участке")
        End If
        Dim lPoint As Point3d = Kommand.GetPointOtPolz(0)
        Dim lRealZ As Double = gTrassa.objGeom.RastPoDwgX(lPoint.X)
        Dim lpiket As clsPrf.ClsPiket = gTrassa.Piket(lRealZ)
        Dim luch As clsPrf.clsUchPrf = lpiket.UchPrf
        lobj.IzmUch = CType(luch, wlUch)
        lobj.Dostup = gDostup
        Application.ShowModelessDialog(lobj)

		SkrutMenuUch()
    End Sub

#End Region
#Region "Расчеты п. 'расстановка' "

    ''' <summary>
    ''' Выбор анкерного участка
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("wOpPr")> _
    Public Sub wibrAnkUchProfil()  '
        Dim Twibr As Point3dCollection
        If gRasst Is Nothing Then
            Application.ShowAlertDialog("wibrOpNaProfil:растановка не загружена в чертеж")
            Exit Sub
        End If
        Dim Soob As String = "wibrAnkUchProfil" & vbCr
        Twibr = Kommand.GetPointOtPolz()
        Dim t As Point3d = Twibr(0)
        '  MsgBox("Выбоано точек " & Twibr.Count & "  Koor " & Twibr(0).X)

        Soob &= "   на черт " & t.X
        Dim r As Double = gTrassa.RastPoDwgX(t.X)
        Soob &= " на трасе " & t.X & vbCr
        WibrOp = gRasst.wibratOporuDo(r)
        Dim lAnkOpDo, lAnkOpPosle As wlOpRasst

        If WibrOp Is Nothing Then
            Soob &= "подходящей  опоры не существует" & vbCr
            MsgBox(Soob)
        Else
            Soob &= SwedObOpore(WibrOp)
            lAnkOpDo = gRasst.PredAnk(WibrOp)
            If lAnkOpDo Is Nothing Then
                Soob &= "подходящей анкерной опоры  до точки выбора не существует" & vbCr
            Else
                Soob &= "начало анкер. участка" & vbCr & SwedObOpore(lAnkOpDo)
            End If
            lAnkOpPosle = gRasst.SledAnk(WibrOp)
            If lAnkOpPosle Is Nothing Then
                Soob &= "подходящей анкерной опоры  после точки выбора не существует" & vbCr
            Else
                Soob &= "конец  анкер. участка" & vbCr & SwedObOpore(lAnkOpPosle)
            End If

            '  Application.ShowAlertDialog(Soob)
            If lAnkOpDo Is Nothing Or lAnkOpPosle Is Nothing Then
                Application.ShowAlertDialog("Анкерный участок не создан" & vbCr & Soob)
            Else

                objAnkUch = New wlAnkUchWopt(lAnkOpDo, lAnkOpPosle)

                If objAnkUch.Nagr Is Nothing Then
                    Application.ShowAlertDialog(Me.ToString & " wibrAnkUchProfil " & " не хватает даанных для расчетов на " & objAnkUch.NameAnkPr)
                    Return
                End If

                Dim opDwg As dwgObrazOporRasst

                If lAnkOpDo.EtaOporaW_PredUchastke Is Nothing Then
                    If lAnkOpDo.Obraz Is Nothing Then
                        opDwg = New dwgObrazOporRasst(lAnkOpDo)
                    Else
                        opDwg = CType(lAnkOpDo.Obraz, dwgObrazOporRasst)
                    End If
                Else
                    If lAnkOpDo.EtaOporaW_PredUchastke.Obraz Is Nothing Then
                        opDwg = New dwgObrazOporRasst(lAnkOpDo.EtaOporaW_PredUchastke)
                    Else
                        opDwg = CType(lAnkOpDo.EtaOporaW_PredUchastke.Obraz, dwgObrazOporRasst)
                    End If
                End If

                Dim objRusl As rstUslRascheta = New rstUslRascheta(objAnkUch)
                objRusl.StrPred = opDwg.StrDan()
                objAnkUch.PrivedZentrTaj = objRusl.PrivedZentrTajesti
                objAnkUch.PrivedZentrTajT = objRusl.PrivedZentrTajestiTr
                DobawitMenuUch()
                BazDwg.Kommand.createNewLayer(DwgParam.SlSlujbn)

                WiwGabKrivAnkUch(objAnkUch)

                WiwKrivProvisAnkUch(objAnkUch)

            End If


        End If

    End Sub
    ''' <summary>
    ''' добавить анкерную опору в указаную точку профиля
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("DobAnkOp")> _
    Public Sub DobAnkOp()
        If gTrassa.objGeom.obrParam.TipGraniz = ParamTrass.TipDetal Then
            Application.ShowAlertDialog(Me.ToString & " DobAnkOp: В режиме деталь добавление анкерной опоры не предусмотрено ")

        End If
        Dim Twibr As Point3dCollection
        Twibr = Kommand.GetPointOtPolz()
        Dim t As Point3d = Twibr(0)
        Dim r As Double = gTrassa.objGeom.RastPoDwgX(t.X)
        If Not gRasst.EstOpora(r) Then
            ' Application.ShowAlertDialog("wibrT:на черт X " & t.X & "   Y " & t.Y)
            gRasst.DobOpUniver(r, 1)
            dwgWiwRasst.wiwOpNaProfil()

        Else
            Application.ShowAlertDialog("wibrT:на черт X " & t.X & "   Y " & t.Y & "  уже есть опора")
        End If


    End Sub
    ''' <summary>
    ''' Выставит анкерные опоры по всем точкам углов поворота профиля 
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("AnkOpPouglam")> _
    Public Sub AnkOpPouglam()
        If gTrassa.objGeom.obrParam.TipGraniz = ParamTrass.TipDetal Then
            Application.ShowAlertDialog(Me.ToString & " DobAnkOp: В режиме деталь добавление анкерной опоры не предусмотрено ")

        End If
        Dim lSpuglow As List(Of clsPrf.ClsPiket) = gTrassa.SpUglowPow
        'For Each lu As clsPrf.clsUchPrf In gRasst.Trassa.Uchastki
        '    If Not lSpuglow.Contains(lu.EndUch) Then lSpuglow.Add(lu.EndUch)
        'Next

        For Each el As clsPrf.ClsPiket In lSpuglow
            Dim r As Double = el.RastOtnachala
            If Not gRasst.EstOpora(r) Then
                ' Application.ShowAlertDialog("wibrT:на черт X " & t.X & "   Y " & t.Y)
                gRasst.DobAnkOp(el)

            Else
                Application.ShowAlertDialog(Me.ToString & " AnkOpPouglam :на черт  для пикета" & el.NamePiket & "   пикетаж  " & el.Piketaj & " от начала  " & el.RastOtnachala & "  уже есть опора")
            End If
        Next

        dwgWiwRasst.wiwOpNaProfil()


    End Sub
    ''' <summary>
    ''' Выдача по опроной ведомости 
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("Wedomost")> _
    Public Sub Wedomost()
        Dim doc As New Rashet.docWordWedomost()
        doc.Rasst = gRasst
        doc.NameLin = gTrassa.NameLin
        doc.NameTrass = gTrassa.NameRab
        doc.Otkrit()

    End Sub
    Shared Function OpredelitObraz(ByVal iWop As wlOpRasst) As dwgObrazOporRasst
        Dim lWopObr As dwgObrazOporRasst
        If iWop Is Nothing Then
            Return Nothing
        Else
            'если опора не первая на участки (Вообщето такая опора не попадет в расстановку всей трассы)
            If iWop.EtaOporaW_PredUchastke Is Nothing Then
                If iWop.Obraz Is Nothing Then
                    lWopObr = New dwgObrazOporRasst(iWop)
                Else
                    lWopObr = CType(iWop.Obraz, dwgObrazOporRasst)
                End If


            Else
                'фактически этот участок не реализуеться
                If iWop.EtaOporaW_PredUchastke.Obraz Is Nothing Then
                    lWopObr = New dwgObrazOporRasst(WibrOp.EtaOporaW_PredUchastke)
                Else
                    lWopObr = CType(WibrOp.EtaOporaW_PredUchastke.Obraz, dwgObrazOporRasst)
                End If

            End If
        End If
        Return lWopObr
    End Function
    Private Sub InitMod()
        Dim lBegAnk, lEndAnk As wlOpRasst
        SpAnkUch.Clear()
        Dim lwop As wlOpRasst = CType(gRasst.opColl(1), wlOpRasst)
        lBegAnk = gRasst.PredAnk(lwop)
        If lBegAnk Is Nothing Then lBegAnk = gRasst.SledAnk(lwop)
        Do

            If lBegAnk IsNot Nothing Then
                lEndAnk = gRasst.SledAnk(lBegAnk)
                If lEndAnk IsNot Nothing Then
                    Dim lAnkUch As New wlAnkUchWopt(lBegAnk, lEndAnk)
                    Dim lObrazOp As dwgObrazOporRasst = OpredelitObraz(lBegAnk)
                    Dim lobjRusl As rstUslRascheta = New rstUslRascheta(lAnkUch)
                    lobjRusl.StrPred = lObrazOp.StrDan()

                    lAnkUch.PrivedZentrTaj = lobjRusl.PrivedZentrTajesti
                    lAnkUch.PrivedZentrTajT = lobjRusl.PrivedZentrTajestiTr
                    '  lAnkUch.OprRejTros()
                    SpAnkUch.Add(lAnkUch)
                    lBegAnk = lEndAnk
                Else
                    MaxNumAu = SpAnkUch.Count - 1
                    Return
                End If
            Else
                MaxNumAu = -1
                Return
            End If
        Loop
    End Sub
#Region "Монтаж табл"
    Private SpvisOp As String()
    Private wPriznakRaschetaMontaj As Boolean
    Private Function GetSpVisOp() As Boolean
        Dim lSlowar As New dwgSlowar("SpVisOp")



        SpvisOp = lSlowar.ZapisIzSlovarStr("vizOp")
        If SpvisOp Is Nothing Then SpvisOp = {""}
        Dim objF As New FrmVisOp
        objF.Rasst = gRasst
        objF.SpvisOp = SpvisOp
        If objF.ShowDialog = Windows.Forms.DialogResult.OK Then
            SpvisOp = objF.SpvisOp
            lSlowar.ZapisW_SlowarStr("vizOp", SpvisOp)
            Return objF.CheckBoxRaschet.Checked
        End If
        SpvisOp = Nothing
        Return objF.CheckBoxRaschet.Checked
    End Function
    ''' <summary>
    ''' расчет монтажных таблиц с выдачей результатов на формы, а затем в документ ( 3 типа документов) 
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("RaschetMont")> _
    Public Sub RaschetMontTabl()
        Dim i As Integer
        Dim PrTrosa As Boolean  'признак наличия троса
        '   Dim lItogDoc As DocWordMontag
        Dim lSpRez As New List(Of wlMontadTabl)
        InitMod()

        If GetSpVisOp() Then
            If SpvisOp Is Nothing Then
                Application.ShowAlertDialog("Не установлен список визируемых опор")

                Return
            End If
        Else
            Return
        End If
        For i = 0 To MaxNumAu
            Dim lobjMnt As New wlMontadTabl(SpAnkUch(i), Fazi.faz0)
            lobjMnt.OpredNumVisProlet(SpvisOp)
            If lobjMnt.MaxNum > -1 Then
                PrTrosa = Not (SpAnkUch(i).Tros Is Nothing)

                lobjMnt.RaschitatMontag()
                If PrTrosa Then
                    lobjMnt.AnkUch.OprRejTrosGrozoZashita()
                    lobjMnt.RaschitatMontagTros()
                End If
                lSpRez.Add(lobjMnt)

            End If
        Next
        Dim wFrmwiwRez As New FrmRezMontag
        For Each el As wlMontadTabl In lSpRez

            wFrmwiwRez.RassmUch(el)

        Next
        Do
            Select Case wFrmwiwRez.ShowDialog() '                                         =  Then
                Case Windows.Forms.DialogResult.OK
                    wObjFormWipDok = New FrmSoobRasstanowki
                    wObjFormWipDok.ProgressBar.Maximum = 2 * SpvisOp.Length + 5 + MaxNumAu
                    wObjFormWipDok.LabelKolwoStrok.Text = CStr(2 * SpvisOp.Length + 3 + MaxNumAu)
                    Dim lItogDoc As New DocWordMontag()
                    lItogDoc.WstawitKolontitul(gRasst.ToString, gRasst.Trassa.ToString)
                    For Each el As wlMontadTabl In lSpRez
                        wObjFormWipDok.LabelNameAnk.Text = el.AnkUch.NameAnkPr
                        lItogDoc.RassmUch(el)
                        AddHandler lItogDoc.Wstawil, AddressOf obrabot
                        wObjFormWipDok.Visible = True
                        lItogDoc.Wiwesti()
                        RemoveHandler lItogDoc.Wstawil, AddressOf obrabot
                    Next
                    lItogDoc.Otkrit()
                    wObjFormWipDok.Close()
                    wObjFormWipDok = Nothing
                Case Windows.Forms.DialogResult.Yes
                    Dim llItogDoc As New DocWordMontagPrTr(wFrmwiwRez.CheckBoxRejm.Checked)
                    WiwodMontTablItog(Of DocWordMontagPrTr)(llItogDoc, lSpRez)
                Case Windows.Forms.DialogResult.Retry
                    Dim llItogDoc As New DocWordMontagPr(wFrmwiwRez.CheckBoxRejm.Checked)
                    WiwodMontTablItog(Of DocWordMontagPr)(llItogDoc, lSpRez)
                Case Else
                    Return
            End Select
        Loop

    End Sub
    ''' <summary>
    ''' Результаты по проводу и тросу. Нагрузки на трос определяются по условиям грозозащиты. 
    ''' Состав результатов расчета и формат документам выводятся в соответствие   со стандартом предприятия.
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("RaschetMontPrTR")> _
    Public Sub RaschetMontTablPrTr()
        Dim lItogDoc As DocWordMontagPrTr
        lItogDoc = New DocWordMontagPrTr()
        RaschetMontTablItog(Of DocWordMontagPrTr)(lItogDoc, Fazi.faz0, False)
    End Sub
    ''' <summary>
    ''' Расчет монтажных таблиц  провода и троса. Нагрузки на трос определяются из условий расстановки.
    '''  Состав результатов расчета и формат документам выводятся в соответствие   со стандартом предприятия.
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("RaschetMontPrTrZad")> _
    Public Sub RaschetMontTablPrTrZad()
        Dim lItogDoc As DocWordMontagPrTr
        lItogDoc = New DocWordMontagPrTr()
        RaschetMontTablItog(Of DocWordMontagPrTr)(lItogDoc, Fazi.faz0, True)
    End Sub
    ''' <summary>
    ''' Результаты только по проводу. 
    ''' Состав результатов расчета и формат документам выводятся в соответствие   со стандартом предприятия.
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("RaschetMontPr")> _
    Public Sub RaschetMontTablPr()
        Dim lItogDoc As DocWordMontagPr
        lItogDoc = New DocWordMontagPr()
        RaschetMontTablItog(Of DocWordMontagPr)(lItogDoc, Fazi.faz0, False)
    End Sub
    ''' <summary>
    ''' Расчет монтажных таблиц оптоволоконного кабеля(ОКСН)  прикрепляемого к телу опоры.
    '''  Состав результатов расчета и формат документам выводятся в соответствие   со стандартом предприятия.
    '''  Нагрузки на ОКСН определяются из условий расстановки
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("RaschetMontOpt")> _
    Public Sub RaschetMontTablOpt()
        Dim lItogDoc As DocWordMontagPr
        lItogDoc = New DocWordMontagPr()
        RaschetMontTablItog(Of DocWordMontagPr)(lItogDoc, Fazi.opt, False)
    End Sub
    Private wObjFormWipDok As FrmSoobRasstanowki
    Public Sub RaschetMontTablItog(Of T As IDocWordMontag)(ByVal iItogDoc As T, ifaza As modRasstOp.Fazi, pRZadanijRejimaTrosa As Boolean)
        Dim i As Integer
        Dim PrTrosa As Boolean  'признак наличия троса
        InitMod()


        If GetSpVisOp() Then
            If SpvisOp Is Nothing Then
                Application.ShowAlertDialog("Не установлен список визируемых опор")
                Return
            End If
        Else
            Return
        End If
        wObjFormWipDok = New FrmSoobRasstanowki
        wObjFormWipDok.ProgressBar.Maximum = 2 * SpvisOp.Length + 5
        wObjFormWipDok.LabelKolwoStrok.Text = CStr(2 * SpvisOp.Length)
        For i = 0 To MaxNumAu
            Dim lobjMnt As New wlMontadTabl(SpAnkUch(i), ifaza)
            wObjFormWipDok.LabelNameAnk.Text = SpAnkUch(i).NameAnkPr


            lobjMnt.OpredNumVisProlet(SpvisOp)

            If lobjMnt.MaxNum > -1 Then
                iItogDoc.RassmUch(lobjMnt)
                PrTrosa = Not (SpAnkUch(i).Tros Is Nothing)
                lobjMnt.RaschitatMontag()
                If PrTrosa And TypeOf iItogDoc Is DocWordMontagPrTr Then
                    If pRZadanijRejimaTrosa Then

                        lobjMnt.AnkUch.OprRejPoMechUsl()
                    Else
                        lobjMnt.AnkUch.OprRejTrosGrozoZashita()
                    End If

                    lobjMnt.RaschitatMontagTros()
                End If
                AddHandler iItogDoc.wstawil, AddressOf obrabot
                wObjFormWipDok.Visible = True
                iItogDoc.Wiwesti()
                RemoveHandler iItogDoc.wstawil, AddressOf obrabot

            End If
        Next
        iItogDoc.WstavkaInfo()
        iItogDoc.Zakonchit()
        iItogDoc.Otkrit()
        wObjFormWipDok.Close()
        wObjFormWipDok = Nothing


    End Sub
    Private Sub WiwodMontTablItog(Of T As IDocWordMontag)(ByVal iItogDoc As T, iSp As List(Of wlMontadTabl))
        wObjFormWipDok = New FrmSoobRasstanowki
        wObjFormWipDok.ProgressBar.Maximum = 2 * SpvisOp.Length + 5
        wObjFormWipDok.LabelKolwoStrok.Text = CStr(2 * SpvisOp.Length)
        For Each lobjMnt In iSp
            wObjFormWipDok.LabelNameAnk.Text = lobjMnt.AnkUch.NameAnkPr
            If lobjMnt.MaxNum > -1 Then
                iItogDoc.RassmUch(lobjMnt)
                AddHandler iItogDoc.wstawil, AddressOf obrabot
                wObjFormWipDok.Visible = True
                iItogDoc.Wiwesti()
                RemoveHandler iItogDoc.wstawil, AddressOf obrabot
            End If
        Next
        iItogDoc.WstavkaInfo()
        iItogDoc.Zakonchit()
        iItogDoc.Otkrit()
        wObjFormWipDok.Close()
        wObjFormWipDok = Nothing
    End Sub

    Sub obrabot(num As Integer)
        wObjFormWipDok.LabelTekStrok.Text = CStr(num)
        wObjFormWipDok.ProgressBar.Value = num
        wObjFormWipDok.Refresh()
    End Sub


#End Region
    ''' <summary>
    ''' По всем анкерным участкам трасы производиться расчет  поперечного отклонения гирлянд
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("OtklGirl")> _
    Public Sub OtklGirl()
        Dim lfrm As New Rashet.FrmRezRaschetOtklBallast
        InitMod()
        Dim lpredProwod As List(Of ParaDoubleString) = Aotlad.LeseIzSlowara(Aotlad.NameSlowar, Aotlad.NavtZapProwod)
        Dim lpredTros As List(Of ParaDoubleString) = Aotlad.LeseIzSlowara(Aotlad.NameSlowar, Aotlad.NavtZapTros)
        lfrm.UstanowitSpiski(SpAnkUch, lpredProwod, lpredTros)
      
        lfrm.ShowDialog()

        Aotlad.ZapisW_Slowar(lpredProwod, Aotlad.NameSlowar, Aotlad.NavtZapProwod)
        Aotlad.ZapisW_Slowar(lpredTros, Aotlad.NameSlowar, Aotlad.NavtZapTros)
    End Sub
    Private Sub WiwesteDannOAnkUch(ByVal iAnkUch As wlAnkUchTr, ByVal icolEnt As DBObjectCollection)
        Dim lOpDwgBeg As New dwgObrazOporRasst(iAnkUch.BegOpAnkUch)
        Dim lOpDwgEnd As New dwgObrazOporRasst(iAnkUch.EndOpAnkUch)
        wlAnalizOtklGirlAnkUch.SpPreduglow = Aotlad.LeseIzSlowara("PredOtkl", "prowod")
        Dim lotm, lbegX, lShirzon, lwidth, lheight, lXwst As Double

        lbegX = lOpDwgBeg.DwgX
        lShirzon = lOpDwgEnd.DwgX - lbegX
        lotm = gTrassa.OsKlRasst
        Dim llin As Entity = dbPrim.CreateLine(lbegX, lotm - 10, lbegX, lotm)
        dwgWiwMechusl.OpredRazm(lbegX, lShirzon, lXwst, lwidth, lheight)
        Dim lprim As Entity = dbPrim.CreateMText(New Point3d(lXwst, lotm, 0), dwgWiwMechusl.WiwodTxtTrosa(iAnkUch), lwidth, lheight)
        llin.Layer = DwgParam.SlRasstUslow
        lprim.Layer = DwgParam.SlRasstUslow
        icolEnt.Add(llin)
        icolEnt.Add(lprim)

        ' lOpDwgBeg. 
    End Sub
    ''' <summary>
    ''' Для всех анкерных участков трассы определяються расчетные и нормативные нагрузки
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("RaschetNagrNaWsej")> _
    Public Sub RaschetNagrNaWsej()
        Dim lFrm As New FrmWseNagr
        InitMod()
        lFrm.Swajz(SpAnkUch)
        lFrm.Show()
    End Sub
    ''' <summary>
    ''' производиться решение уравнений состояния для всех анкерных участков, выводиться кривая провисания
    ''' и в надписи по мехусловиям вноситься исходный режим троса.
    ''' </summary>
    ''' <remarks> команда выполняеться в главном меню подпункт пункта 'расстановка'</remarks>
    <CommandMethod("RaschetTaj")> _
    Public Sub RaschetTaj()
        Dim lcolEnt As New DBObjectCollection
        Dim PrTrosa As Boolean  'признак наличия троса
        InitMod()
        BazDwg.netSelectSet.OchistitSloj(DwgParam.SlRasstUslow)
        For i As Integer = 0 To MaxNumAu
            Dim lUrsost As UrSostAuI(Of rstProlet) = SpAnkUch(i).Raschet()
            Dim lProv As New dwgKrivProvis(SpAnkUch(i).NameAnkPr, 92)
            lProv.NameKr = lUrsost.GabRej.Info                  'objAnkUch.gpGabRej.Info
            lProv.TchkKriv = SpAnkUch(i).GetKrivProvisPr(lUrsost.ProletiResh)
            PrTrosa = Not (SpAnkUch(i).Tros Is Nothing)
            If PrTrosa Then
                SpAnkUch(i).OprRejTrosGrozoZashita()
                '       SpAnkUch(i).RaschetT()
                WiwesteDannOAnkUch(SpAnkUch(i), lcolEnt)

            End If

        Next
        dbPrim.Wkl(lcolEnt)
        Dim objMechUsl As New dwgWiwMechusl(gRasst)
        objMechUsl.Wiw()
        Kommand.changeSloj(objMechUsl.ObrazWiwod, DwgParam.SlRasstUslow)
    End Sub
    ''' <summary>
    ''' Расчитывает весовые и ветровые пролеты и выводит их в форму. С возможностью последующей выдачи как в документ так и чертеж
    ''' </summary>
    ''' <remarks> команда выполняеться в главном меню под подпункт пункта 'расстановка' </remarks>
    <CommandMethod("RaschetWes")> _
    Public Sub RaschetWes()
        Dim lSlow As New dwgSlowar("GlobalDannRaschetow")
        Dim lmasStrok() As String = lSlow.ZapisIzSlovarStr("PredWesVetrProlet")
        Dim lobjForm As New frmRezRaschetaAll
        lobjForm.PredProlet = lmasStrok
        InitMod()
        lobjForm.SpAnk = SpAnkUch

        Dim lSpSost As New List(Of UrSostAuI(Of rstProlet))
        For i As Integer = 0 To MaxNumAu
            Dim lUrsost As UrSostAuI(Of rstProlet) = SpAnkUch(i).Raschet()
            '   lobjForm.swajzAdd(SpAnkUch(i))
            lSpSost.Add(lUrsost)

        Next
        lobjForm.SpResch = lSpSost
        If lobjForm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Kommand.createNewLayer(DwgParam.SlRasstRezRashetAll)
            BazDwg.netSelectSet.OchistitSloj(DwgParam.SlRasstRezRashetAll)
            For i As Integer = 0 To MaxNumAu
                Dim wTabl As New dwgWiwRezRascheta(gTrassa, SpAnkUch(i), lSpSost(i))
                wTabl.SlojRazmeschenij = DwgParam.SlRasstRezRashetAll
                wTabl.WiwodWDwg()
            Next
        End If
        lSlow.ZapisW_SlowarStr("PredWesVetrProlet", lobjForm.PredProlet)

    End Sub
    <CommandMethod("RaschetDlajTu")> _
    Public Sub RaschetDlajTu()
        'Dim lSlow As New dwgSlowar("GlobalDannRaschetow")
        'Dim lmasStrok() As String = lSlow.ZapisIzSlovarStr("PredWesVetrProlet")
        Dim lobjForm As New FrmOporaDljaTu
        '     lobjForm.PredProlet = lmasStrok
        InitMod()

        Dim lspItog As New List(Of oporaDljaTU)   'прообраз InitGeoSo
        Dim lrezReshPred As Rashet.rstRezReshUrSost = Nothing
        For Each el As Rashet.wlAnkUchTr In SpAnkUch
            Dim lur As Rashet.UrSostAuI(Of modRasstOp.rstProlet) = el.Raschet()

            For Each elop As Rashet.rstRezReshUrSost In lur.Reshenie
                If elop.DlinaProleta > 0.1 Then 'Чтобы не включать последнею опору анкернрго участка ( при определение результата в нее не передаеться пролет)
                    Dim LoporSkw As New oporaDljaTU(elop, el)
                    If lrezReshPred IsNot Nothing Then
                        LoporSkw.SetPred(lrezReshPred, SpAnkUch)
                        lrezReshPred = Nothing
                    End If

                    lspItog.Add(LoporSkw)
                Else
                    lrezReshPred = elop
                End If

            Next
        Next
        lobjForm.SpOpSkwaj = lspItog

        'Dim lSpSost As New List(Of UrSostAuI(Of rstProlet))
        'For i As Integer = 0 To MaxNumAu
        '    Dim lUrsost As UrSostAuI(Of rstProlet) = SpAnkUch(i).Raschet()
        '    '   lobjForm.swajzAdd(SpAnkUch(i))
        '    lSpSost.Add(lUrsost)

        'Next

        If lobjForm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'Kommand.createNewLayer(DwgParam.SlRasstRezRashetAll)
            'BazDwg.netSelectSet.OchistitSloj(DwgParam.SlRasstRezRashetAll)
            'For i As Integer = 0 To MaxNumAu
            '    Dim wTabl As New dwgWiwRezRascheta(gTrassa, SpAnkUch(i), lSpSost(i))
            '    wTabl.SlojRazmeschenij = DwgParam.SlRasstRezRashetAll
            '    wTabl.WiwodWDwg()
            'Next
        End If
        '     lSlow.ZapisW_SlowarStr("PredWesVetrProlet", lobjForm.PredProlet)

    End Sub
    <CommandMethod("RaschetGabStrel")> _
    Public Sub RaschetGabStrel()
      
      
        InitMod()

        Dim ldoc As New docGabStrel(SpAnkUch)
        ldoc.Otkrit()

      



    End Sub

    ''' <summary>
    ''' Вывод кривых провисания и габаритных кривых для всех анкерных участков трассы.
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("WiwodKrivProvGab")> _
    Public Sub WiwodKrivProvGab()
        Dim lcolEnt As New DBObjectCollection
        Kommand.createNewLayerNePrint(DwgParam.SlSlujbn)
        BazDwg.netSelectSet.OchistitSloj(DwgParam.SlSlujbn)

        InitMod()

        For i As Integer = 0 To MaxNumAu
            Dim lUrsost As UrSostAuI(Of rstProlet) = SpAnkUch(i).Raschet()
            Dim lProv As New dwgKrivProvis(SpAnkUch(i).NameAnkPr, 92)
            lProv.NameKr = lUrsost.GabRej.Info                  'objAnkUch.gpGabRej.Info
            lProv.TchkKriv = SpAnkUch(i).GetKrivProvisPr(lUrsost.ProletiResh)
            WiwGabKrivAnkUch(SpAnkUch(i))
            WiwKrivProvisAnkUch(SpAnkUch(i))
            WiwKrivProvisTrAnkUch(SpAnkUch(i))
        Next

    End Sub
#End Region
#Region "Габаритные кривые, кривые провисания   вспомогательные функции команд нет"
    Private Shared Sub KrivDwgS(ByVal Clkriv As Collection, Optional ByVal SdwigX As Double = 0, Optional ByVal sdwigY As Double = 0)
        Dim colPoint3 As New Point3dCollection
        For Each oneTchk As Double() In Clkriv
            With gTrassa()
                Dim wWis As Double = .WisotaNad(oneTchk(0), oneTchk(1))

                Dim xdwg As Double = .DwgXpoRast(oneTchk(0) + SdwigX)
                Dim hdwg As Double = .DwgYpoOtm(oneTchk(1) + sdwigY)
                colPoint3.Add(New Point3d(xdwg, hdwg, 0))
            End With
        Next
        Dim colprim As New ObjectIdCollection
        Dim objid As ObjectId = BazDwg.MakeEntities.CreateSpline(colPoint3)
        colprim.Add(objid)
        Kommand.changeColor(objid, 6)
        Kommand.changeSloj(objid, DwgParam.SlSlujbn)
        Dim objIdG As ObjectId = BazDwg.MakeNeGraf.InsertWGroup(colprim, "GbKrivS", "Крив")
    End Sub

    Private Shared Sub WiwGabKrivAnkUch(ByVal ankUch As wlAnkUch, Optional ByVal Sigma As Double = -1, Optional ByVal gamma As Double = -1)

        If Sigma < 0 Then Sigma = ankUch.gpGabRej.Sigma
        If gamma < 0 Then gamma = ankUch.gpGabRej.Gamma

        Dim ProvisGab As New dwgKrivProvis(ankUch.NameAnkPr & "GabKriv", 6)
        ProvisGab.NameKr = "габаритная"
        ProvisGab.SdwigY = -ankUch.Gabarit
        ProvisGab.TchkKriv = ankUch.GetKrivProvisPr(Sigma, gamma)

    End Sub
    Private Shared Sub WiwGabKrivAnkUchNameColor(ByVal ankUch As wlAnkUch, ByVal iName As String, ByVal iColor As Integer)

        'If Sigma < 0 Then Sigma = ankUch.gpGabRej.Sigma
        'If gamma < 0 Then gamma = ankUch.gpGabRej.Gamma

        Dim ProvisGab As New dwgKrivProvis(ankUch.NameAnkPr & "GabKriv", iColor)
        ProvisGab.NameKr = iName
        ProvisGab.SdwigY = -ankUch.Gabarit
        ProvisGab.TchkKriv = ankUch.GetKrivProvisPr(ankUch.gpGabRej.Sigma, ankUch.gpGabRej.Gamma)

    End Sub
    Private Sub WiwKrivProvisTrAnkUch(ByVal ankUch As wlAnkUchTr)
        Dim Provistrosa As New dwgKrivProvis(ankUch.NameAnkPr & "ProvisTrosa", 4)
        '   Provistrosa.NameKr = "Трос: Тяжение " & Format(ankUch.RejTrMaxNagr.Sigma, "F1") & "  " & Format(ankUch.RejTrMaxNagr.Gamma, "f1")
        Provistrosa.NameKr = ankUch.RejTrMaxNagr.Info("Трос")
        Provistrosa.TchkKriv = ankUch.GetKrivProvis
    End Sub
    Private Sub WiwKrivProvisAnkUch(ByVal ankUch As wlAnkUch, Optional ByVal Sigma As Double = -1, Optional ByVal gamma As Double = -1, Optional iFaza As Fazi = Fazi.faz0)
        'Dim colprim As New ObjectIdCollection
        'Dim colPoint2 As New Point2dCollection

        If Sigma < 0 Then Sigma = ankUch.gpGabRej.Sigma
        If gamma < 0 Then gamma = ankUch.gpGabRej.Gamma

        Dim ProvisProv As New dwgKrivProvis(ankUch.NameAnkPr & modRasstOp.wlOpRasst.NameFaz(iFaza), 7 + iFaza)
        ProvisProv.NameKr = modRasstOp.wlOpRasst.NameFaz(iFaza)
        ProvisProv.TchkKriv = ankUch.GetKrivProvisPr(Sigma, gamma, iFaza)

    End Sub


#End Region
#Region "На анкерном участке"
#Region "Изменение"
    Delegate Function Rasst(ByVal Dlina As Double) As Double
    ''' <summary>
    ''' добавляет промежуточную  опору в указаную точку профиля
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("DobPromOp")> _
    Public Sub DobPromOp()
        Dim Twibr As Point3dCollection
        If gRasst Is Nothing Then
            Application.ShowAlertDialog("wibrOpNaProfil:растановка не выведена в чертеж")
            Exit Sub
        End If
        Dim Soob As String = "wibrOpNaProfil" & vbCr
        Twibr = Kommand.GetPointOtPolz()
        Dim t As Point3d = Twibr(0)

        Soob &= Now().ToBinary() & "   на черт " & t.X
        Dim r As Double = gTrassa.RastPoDwgX(t.X)
        Soob &= " на трасе " & t.X & vbCr
        gRasst.DobOp(r)

        dwgWiwRasst.wiwOpNaProfil()
        WiwGabKrivAnkUch(objAnkUch)
        WiwKrivProvisAnkUch(objAnkUch)

    End Sub
    Private Sub rasstabitD(ByVal Fun As Rasst)
        If objAnkUch Is Nothing Then
            Application.ShowAlertDialog("Raschet:не выбран анкерный участок")
            Exit Sub
        End If
        Dim opDwg As dwgObrazOporRasst
        Dim opBeg = objAnkUch.BegOpAnkUch
        If opBeg.Obraz Is Nothing Then
            opDwg = New dwgObrazOporRasst(opBeg)
        Else
            opDwg = CType(opBeg.Obraz, dwgObrazOporRasst)
        End If
        Dim Str As String = "Расширенные данные" & vbCr
        Dim DlProleta As Double = objAnkUch.GabProlet.DlinaProleta
        Dim lStrDlinProlet As String = InputBox("Введите длину пролета", "Расчетный пролет", CStr(DlProleta))
        Try
            DlProleta = CDbl(lStrDlinProlet)
        Catch ex As InvalidCastException
            Return
        Catch ex As Exception
            Return
        End Try


        Dim Endrasst As Double = Fun(DlProleta)
        Dim wopGr As wlOpRasst = gRasst.wibratOporuPosle(Endrasst + 1)
        For wr As Double = Endrasst + DlProleta To wopGr.RastOtNachala Step DlProleta
            gRasst.DobOp(wr)
        Next
        Fun(DlProleta)
        dwgWiwRasst.wiwOpNaProfil()
        '  MsgBox(Str)

        WiwGabKrivAnkUch(objAnkUch)
        WiwKrivProvisAnkUch(objAnkUch)



    End Sub
    ''' <summary>
    '''Все промежуточные опоры, кроме ближайших к анкерным опорам будут расставлены в соответствии с габаритным пролетом,  
    ''' необходимое количество опор будет добавлено в соответствие с параметрами участка и условиями расстановки
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("rasstabit1")> _
    Public Sub rasstabit1()

        rasstabitD(AddressOf objAnkUch.Rasstawit1)

    End Sub
    ''' <summary>
    ''' Все промежуточные опоры анкерного участка будут расставлены в соответствии с габаритным пролетом,  
    '''  необходимое количество опор будет добавлено в соответствие с параметрами участка и условиями расстановки
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("rasstabit")> _
    Public Sub rasstabit()

        rasstabitD(AddressOf objAnkUch.Rasstawit)

    End Sub
    ''' <summary>
    ''' удаляет промежуточную опору, ближайшую к указаной точки профиля 
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("UdalPromOp")> _
    Public Sub UdalPromOp()
        Dim wop As wlOpRasst = wibratOpor()
        If wop Is Nothing Then
            Application.ShowAlertDialog("опора не выбрана")
            Return
        End If

        If wop.Tip > 0 Then
            Application.ShowAlertDialog("Опора" & wop.NumName & " анкерная.  Удалить можно только промежуточные опоры")
            Return
        End If

        Dim rez As MsgBoxResult = MsgBox("Удаляеться опора " & wop.NumName, MsgBoxStyle.OkCancel)
        If rez = MsgBoxResult.Ok Then
            Dim obrOp As dwgObrazOporRasst = CType(wop.Obraz, dwgObrazOporRasst)

            gRasst.UdalOp(wop)
            obrOp.UdalitObraz()
            dwgWiwRasst.wiwOpNaProfil()

            WiwGabKrivAnkUch(objAnkUch)
            WiwKrivProvisAnkUch(objAnkUch)
        End If

    End Sub
#End Region
    ''' <summary>
    ''' расчет нагрузок,габаритного пролета, результат на форму 
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("Nagruzki")> _
    Public Sub Nagruzki()
        If objAnkUch Is Nothing Then
            Application.ShowAlertDialog("Nagruzki:не выбран анкерный участок")
            Exit Sub
        Else
            SystemKommand.SoobEditor("Nagruzki: выбран анкерный участок " & objAnkUch.NameAnkPr)

        End If
        Dim objfrNagr As New FrmNagr
        objfrNagr.Swajz(objAnkUch)
        objfrNagr.Show()

    End Sub
    <CommandMethod("NagruzkiT")> _
    Public Sub NagruzkiT()

        If objAnkUch Is Nothing Then
            Application.ShowAlertDialog("NagruzkiT:не выбран анкерный участок")
            Exit Sub
        Else
            SystemKommand.SoobEditor("NagruzkiT: выбран анкерный участок " & objAnkUch.NameAnkPr)

        End If
        Dim objfrNagr As New FrmNagr
        objfrNagr.SwajzT(objAnkUch)
        objfrNagr.Show()

    End Sub
    <CommandMethod("NagruzkiW")> _
    Public Sub NagruzkiW()

        If objAnkUch Is Nothing Then
            Application.ShowAlertDialog("Nagruzkiw:не выбран анкерный участок")
            Exit Sub
        Else
            SystemKommand.SoobEditor("NagruzkiT: выбран анкерный участок " & objAnkUch.NameAnkPr)

        End If
        Dim objfrNagr As New FrmNagr
        objfrNagr.SwajzWopt(objAnkUch)
        objfrNagr.Show()

    End Sub
    ''' <summary>
    ''' В соответствие с режимами полученными при определение габаритного пролета решается уравнение состояния   анкерного участка.
    '''  Выводяться кривые провисания и габаритные
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("Raschet")> _
    Public Sub Raschet()
        If objAnkUch Is Nothing Then
            Application.ShowAlertDialog("Raschet:не выбран анкерный участок")
            Exit Sub
        Else
            SystemKommand.SoobEditor("Raschet: выбран анкерный участок " & objAnkUch.NameAnkPr)
        End If
        Dim objfrm As FrmRezRascheta = New FrmRezRascheta
        objfrm.AnkUch = objAnkUch
        Dim lUrsost As UrSostAuI(Of rstProlet) = objAnkUch.Raschet()
        objfrm.UrsostAu = lUrsost
        objfrm.Show()
        Dim lProv As New dwgKrivProvis(objAnkUch.NameAnkPr, 92)
        lProv.NameKr = lUrsost.GabRej.Info                  'objAnkUch.gpGabRej.Info
        lProv.TchkKriv = objAnkUch.GetKrivProvisPr(lUrsost.ProletiResh)
        Kommand.createNewLayer(DwgParam.SlRasstRezRashet)
        BazDwg.netSelectSet.OchistitSloj(DwgParam.SlRasstRezRashet)
        Dim wTabl As New dwgWiwRezRascheta(gTrassa, objAnkUch, lUrsost)
        wTabl.WiwodWDwg()
    End Sub
    ''' <summary>
    ''' Предоставляет возможность расчета при обрыве провода в одном пролете выбранного анкерного участка
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("RaschetAw")> _
    Public Sub RaschetAw()


        If objAnkUch Is Nothing Then
            Application.ShowAlertDialog("Raschet:не выбран анкерный участок")
            Exit Sub


        End If
        Dim sNum As String = InputBox("Введите номер аварийного пролета. Не больше " & objAnkUch.MaxnumProleta)
        Dim lnum As Integer
        Try
            lnum = Integer.Parse(sNum)
        Catch ex As Exception
            lnum = 0
        End Try



        Dim objfrm As FrmRezRascheta = New FrmRezRascheta
        objfrm.AnkUch = objAnkUch
        Dim lUrsost As UrSostAuI(Of rstProlet) = objAnkUch.Raschet(lnum)
        'For Each el As rstRezReshUrSost In lUrsost.Reshenie

        'Next
        objfrm.UrsostAu = lUrsost
        objfrm.Show()
        Dim lProv As New dwgKrivProvis("KrivprovAw", 90)
        lProv.TchkKriv = objAnkUch.GetKrivProvisPr(lUrsost.ProletiResh)
        '  truchnawiw.OpredRastUsl(r)
    End Sub
    ''' <summary>
    ''' определяет режим троса по условиям грозозащиты для режима провода определенного при расчете габаритного пролета.
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("RaschetRejTros")> _
    Public Sub RaschetRejTros()


        If objAnkUch Is Nothing Then
            Application.ShowAlertDialog("Raschet:не выбран анкерный участок")
            Exit Sub
        Else
            Application.ShowAlertDialog("Raschet: выбран анкерный участок " & objAnkUch.NameAnkPr)

        End If
        objAnkUch.OprRejTrosGrozoZashita()
        If MsgBox(objAnkUch.InfoT & vbCr & " сформировать документ ", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            Dim lobj As New Rashet.DocWordTros(objAnkUch)

            lobj.NameLin = objAnkUch.BegOpAnkUch.rstUch.NameWl
            lobj.NameTrass = objAnkUch.BegOpAnkUch.rstUch.NameUch



            lobj.Otkrit()
        End If

        WiwKrivProvisTrAnkUch(objAnkUch)
        '  truchnawiw.OpredRastUsl(r)
    End Sub
    ''' <summary>
    ''' расчет условий прохождения ВЛ над пересекаемыми объектами с учетом их типа
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("Pereseshenij")> _
    Public Sub Pereseshenij()    'RaschetP(

        wfrmupr.Visible = False

        If objAnkUch Is Nothing Then
            Application.ShowAlertDialog("Raschet:не выбран анкерный участок")
            Exit Sub
        End If

        '   Dim opDwg As DwgRstOpTr = OpredZadanUslow()
        Dim objform As New frmRezRaschetaPeresech
        objform.AnkUch = objAnkUch
        objform.Show()
		'  Application.ShowodelessDialog(objform)
		'If objform.ShowDialog = Windows.Forms.DialogResult.OK Then


		'End If
		'    If Not wfrmupr.IsDisposed Then wfrmupr.Visible = True
	End Sub

    ''' <summary>
    ''' Позволяет задать горизонтальный профиль пересечения. Можно задать  до шести расчетных точек
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("ZadPeresesh")> _
    Public Sub ZadPeresesh()    'RaschetP(


        If objAnkUch Is Nothing Then
            Application.ShowAlertDialog("Raschet:не выбран анкерный участок")
            Exit Sub

        End If


        Dim objform As New FrmHorPeresech

        objform.AnkUcH = objAnkUch

        objform.Show()
        'If objform.ShowDialog = Windows.Forms.DialogResult.OK Then
        '    opDwg.StrDan = objform.StrPred

        'End If


    End Sub
    ''' <summary>
    ''' Обеспечивает задание параметров исходного и расчетного режима, отличных от режимов определенных при расчете габаритного пролета. 
    ''' Параметры режима вводятся в форме, выведенной на  экран
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("ZadatUslow")> _
    Public Sub ZadatUslow()    'RaschetP(

        If objAnkUch Is Nothing Then
            Application.ShowAlertDialog("Raschet:не выбран анкерный участок")
            Exit Sub

        End If
        Dim Slowar As New LeseSreib.clsLeseSreibUsl(gRasst) ' в этом словаре дублируються расчетные условия, которые занесены и в расширенные данные опоры  
        Dim opDwg As dwgObrazOporRasst = OpredZadanUslow()

        Dim objform As New frmZadRejm

        objform.AnkUch = objAnkUch

        objform.StrPred = opDwg.StrDan()

        If objform.ShowDialog = Windows.Forms.DialogResult.OK Then
            opDwg.StrDan = objform.StrPred
            objAnkUch.PrivedZentrTaj = objform.UslRascheta.PrivedZentrTajesti
            objAnkUch.PrivedZentrTajT = objform.UslRascheta.PrivedZentrTajestiTr
            '     Slowar.SetZapis(objAnkUch.BegOpAnkUch.NumName, objform.StrPred)
        End If


    End Sub
    Private Function OpredZadanUslow() As dwgObrazOporRasst
        Dim opDwg As dwgObrazOporRasst 'вводим для чтения данных о условмях расчета
        Dim opBeg = objAnkUch.BegOpAnkUch
        If opBeg.Obraz Is Nothing Then
            opDwg = New dwgObrazOporRasst(opBeg)
        Else
            opDwg = CType(opBeg.Obraz, dwgObrazOporRasst)
        End If
        Return opDwg
    End Function
    ''' <summary>
    ''' Проводиться расчет аналогично  команде Raschet только  по заданным условиям расчета
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("RaschetPoZad")> _
    Public Sub RaschetPoZad()


        If objAnkUch Is Nothing Then
            Application.ShowAlertDialog("Raschet:не выбран анкерный участок")
            Exit Sub
        Else
            SystemKommand.SoobEditor("Raschet: выбран анкерный участок " & objAnkUch.NameAnkPr)

        End If
        Dim objUsl As New Rashet.rstUslRascheta(objAnkUch)
        Dim objfrm As New FrmRezRascheta

        objfrm.AnkUch = objAnkUch
        ' objform.StrPred = OpredZadanUslow().StrDan
        objUsl.StrPred = OpredZadanUslow().StrDan
        ' objAnkUch.UslRascheta = objUsl
        Dim lUrsost As UrSostAuI(Of rstProlet) = objAnkUch.Raschet(objUsl.IshodRejm, objUsl.GabaritRejm)

        objfrm.UrsostAu = lUrsost
        objfrm.Show()
        Dim lProv As New dwgKrivProvis(objAnkUch.NameAnkPr, 70)
        lProv.NameKr = lUrsost.GabRej.Info                     '  objUsl.GabaritRejm.Info
        lProv.TchkKriv = objAnkUch.GetKrivProvisPr(lUrsost.ProletiResh)

    End Sub
    ''' <summary>
    ''' Как и для провода позволяет непосредственно задать нагрузки, отличные от режимов определенных при расчетах габаритного пролета и по условиям грозозащиты.
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("ZadatUslowT")> _
    Public Sub ZadatUslowT()    'RaschetP(


        If objAnkUch Is Nothing Then
            Application.ShowAlertDialog("Raschet:не выбран анкерный участок")
            Exit Sub

        End If
        Dim opDwg As dwgObrazOporRasst = OpredZadanUslow()
        '   Dim Slowar As New LeseSreib.clsLeseSreibUsl(gRasst) ' в этом словаре дублируються расчетные условия, которые занесены и в расширенные данные опоры  
        Dim objform As New frmZadRejmTr

        objform.AnkUch = objAnkUch
        objform.StrPred = opDwg.StrDan()

        If objform.ShowDialog = Windows.Forms.DialogResult.OK Then
            opDwg.StrDan = objform.StrPred

            objAnkUch.PrivedZentrTajT = objform.UslRascheta.PrivedZentrTajestiTr
            '   Slowar.SetZapis(objAnkUch.BegOpAnkUch.NumName, objform.StrPred)
        End If


    End Sub
    ''' <summary>
    ''' Определения режима троса по заданому режиму провода
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("RaschetRejTrosZad")> _
    Public Sub RaschetRejTrosZad()
        If objAnkUch Is Nothing Then
            Application.ShowAlertDialog("Raschet:не выбран анкерный участок")
            Exit Sub
        Else
            Application.ShowAlertDialog("Raschet: выбран анкерный участок " & objAnkUch.NameAnkPr)
        End If
        'Dim objform As New frmZadRejmTr
        'objform.AnkUch = objAnkUch
        'objform.StrPred = OpredZadanUslow().StrDan
        Dim objUsl As New Rashet.rstUslRascheta(objAnkUch)
        objUsl.StrPred = OpredZadanUslow().StrDan
        objAnkUch.OprRejTrosGrozoZashita(objUsl.IshodRejm)  'objform.IshRej
        If MsgBox(objAnkUch.InfoT & vbCr & " сформировать документ ", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            Dim lobj As New Rashet.DocWordTros(objAnkUch)
            lobj.NameLin = objAnkUch.BegOpAnkUch.rstUch.NameWl
            lobj.NameTrass = objAnkUch.BegOpAnkUch.rstUch.NameUch
            lobj.Otkrit()
        End If
        WiwKrivProvisTrAnkUch(objAnkUch)
    End Sub
    ''' <summary>
    ''' Расчет провисания троса при заданом режиму троса
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("RaschetPoZadT")> _
    Public Sub RaschetPoZadT()
        If objAnkUch Is Nothing Then
            Application.ShowAlertDialog("Raschet:не выбран анкерный участок")
            Exit Sub
        Else
            SystemKommand.SoobEditor("RaschetPoZadT: выбран анкерный участок " & objAnkUch.NameAnkPr)
        End If
        Dim objUsl As New Rashet.rstUslRascheta(objAnkUch)
        Dim objfrm As New FrmRezRascheta
        objfrm.AnkUch = objAnkUch
        objUsl.StrPred = OpredZadanUslow().StrDan
        Dim lUrsost As UrSostAuI(Of rstProlet) = objAnkUch.RaschetT(objUsl.IshodRejmT, objUsl.GabaritRejmT)
        objfrm.UrsostAuT = lUrsost
        objfrm.Show()
        Dim lProv As New dwgKrivProvis(objAnkUch.NameAnkPr, 90)
        lProv.NameKr = objUsl.GabaritRejmT.Info
        lProv.TchkKriv = objAnkUch.GetKrivProvisPr(lUrsost.ProletiResh)
    End Sub
    ''' <summary>
    ''' Решается уравнение состояния   анкерного участка для ОКСН. Выводяться кривые провисания 
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("RaschetW")> _
    Public Sub RaschetW()
        If objAnkUch Is Nothing Then
            Application.ShowAlertDialog("Raschet:не выбран анкерный участок")
            Exit Sub
        Else
            SystemKommand.SoobEditor("RaschetW: выбран анкерный участок " & objAnkUch.NameAnkPr)
        End If
        If objAnkUch.EstliWopt Then
            Dim objfrm As New FrmRezRascheta
            objfrm.faza = Fazi.opt
            objfrm.AnkUch = objAnkUch

            Dim lUrsost As UrSostAuI(Of rstProlet) = objAnkUch.RaschetW()
            objfrm.UrsostAu = lUrsost
            objfrm.Show()
            Dim lProv As New dwgKrivProvis(objAnkUch.NameAnkPr, 95)
            lProv.NameKr = lUrsost.GabRej.Info
            lProv.TchkKriv = objAnkUch.GetKrivProvisPr(lUrsost.ProletiResh)
        Else
            SystemKommand.Soob("RaschetW:: Не задан ВОК")
        End If

    End Sub

#End Region
	Private Function wibratOpor() As wlOpRasst
        Dim Twibr As Point3dCollection
        If gRasst Is Nothing Then
            Application.ShowAlertDialog("wibrOpNaProfil:растановка не выведена в чертеж")

            Return Nothing
        End If
        Dim Soob As String = "wibratOpor" & vbCr
        Twibr = Kommand.GetPointOtPolz()
        Dim t As Point3d = Twibr(0)


        Soob &= "   на черт " & t.X
        Dim r As Double = gTrassa.RastPoDwgX(t.X)
        Soob &= " на трасе " & t.X & vbCr
        WibrOp = gRasst.wibratOporu(r)


        If WibrOp Is Nothing Then
            Soob &= "подходящей  опоры не существует" & vbCr
            Return Nothing
        Else
            If WibrOp.Obraz Is Nothing Then wiwOpNaProfil()
            CType(WibrOp.Obraz, dwgObrazOporRasst).Wideliti()
            Return WibrOp
        End If
    End Function
    Shared Sub PoOporeAnkUch(ByVal iWibrOp As wlOpRasst)
        Dim lobjAnkUch As wlAnkUchTr = Nothing
        Dim lAnkOpDo As wlOpRasst = gRasst.PredAnk(iWibrOp)
        Dim lAnkOpPosle = gRasst.SledAnk(iWibrOp)

        '  Application.ShowAlertDialog(Soob)
        If lAnkOpDo Is Nothing Or lAnkOpPosle Is Nothing Then
            Application.ShowAlertDialog("Анкерный участок не создан")
            Return
        Else
            lobjAnkUch = New wlAnkUchTr(lAnkOpDo, lAnkOpPosle)
            Dim opDwg As dwgObrazOporRasst
            If lAnkOpDo.EtaOporaW_PredUchastke Is Nothing Then
                If lAnkOpDo.Obraz Is Nothing Then
                    opDwg = New dwgObrazOporRasst(lAnkOpDo)
                Else
                    opDwg = CType(lAnkOpDo.Obraz, dwgObrazOporRasst)
                End If
            Else
                If lAnkOpDo.EtaOporaW_PredUchastke.Obraz Is Nothing Then
                    opDwg = New dwgObrazOporRasst(lAnkOpDo.EtaOporaW_PredUchastke)
                Else
                    opDwg = CType(lAnkOpDo.EtaOporaW_PredUchastke.Obraz, dwgObrazOporRasst)
                End If
            End If
            Dim objRusl As rstUslRascheta = New rstUslRascheta(lobjAnkUch)
            objRusl.StrPred = opDwg.StrDan()
            lobjAnkUch.PrivedZentrTaj = objRusl.PrivedZentrTajesti
            lobjAnkUch.PrivedZentrTajT = objRusl.PrivedZentrTajestiTr

            WiwGabKrivAnkUchNameColor(lobjAnkUch, "габ. онлайн", 160)
            '                WiwGabKrivAnkUchS(objAnkUch)

        End If

        WiwDinamfunction(lobjAnkUch)
        'If objFrmDinWiwoda.WindowState <> Windows.Forms.FormWindowState.Normal Then
        '    objFrmDinWiwoda.WindowState = Windows.Forms.FormWindowState.Normal

        'End If


    End Sub
    Private Shared Sub WiwDinamfunction(ByVal iobjAnkUch As wlAnkUch)

        If objFrmDinWiwoda Is Nothing Then
            objFrmDinWiwoda = New frmProlet
        End If
        If objFrmDinWiwoda.IsDisposed Then
            objFrmDinWiwoda = New frmProlet
        End If


        objFrmDinWiwoda.Swajz(iobjAnkUch)

        objFrmDinWiwoda.Show()
        objFrmDinWiwoda.TopMost = True

    End Sub
#Region "Итоговые таблицы оформление"
    Dim wShirinaStolbzow() As Double = {70, 70}
    Dim wShirinaStolbzowPiket() As Double = {80, 50}
    ''' <summary>
    ''' Вывод итоговых таблиц о расстановке и профиле в пространство модели
    ''' </summary>
    ''' <remarks></remarks>
    Sub WiwodTablModel()

        Dim SpIntervalTrass(0) As modRasstOp.wlIntRasst

        Dim Obraz As New ObjectIdCollection
        Dim OtstupOtGranizLista As Double = 40

        Kommand.createNewLayer(DwgParam.SlRasstInfo)
        SpIntervalTrass(0) = New modRasstOp.wlIntRasst(gRasst, 0, gRasst.Trassa.Dlina)
        Dim ShirLista As Double = gTrassa.objGeom.obrParam.ShirinaLista
        Dim lGrTrass As Double = gTrassa.DwgXpoRast(gTrassa.Dlina)
        ' Dim wOsX As Double = gTrassa.objGeom.Podpis.OsX
        Dim PoXWiw As Double = lGrTrass + 2 * OtstupOtGranizLista
        Dim PoYwiw As Double = gTrassa.DwgYpoOtm(gTrassa.MaxOtmetka + 10)

        BazDwg.netSelectSet.OchistitSloj(DwgParam.SlRasstInfo)
        Obraz.Add(MakeEntitesLista.CreateTable(New Point3d(PoXWiw, PoYwiw, 0), wShirinaStolbzowPiket, SpIntervalTrass(0).InfoOInt, "Данные трассы", ""))
        Obraz.Add(MakeEntitesLista.CreateTable(New Point3d(PoXWiw, PoYwiw - 100, 0), wShirinaStolbzow, SpIntervalTrass(0).InfoOpor, "Количество опор трассы", ""))


        Kommand.changeSloj(Obraz, DwgParam.SlRasstInfo)

    End Sub
    ''' <summary>
    ''' Вывод итоговых таблиц о растановке и профиле в пространства листов
    ''' </summary>
    ''' <remarks></remarks>
    Sub WiwodTablList()
        Dim SpGrList As New dwgSpGranizTr(gTrassa)
        SpGrList.Izwlech()
        Dim SpIntervalTrass() As modRasstOp.wlIntRasst
        Dim lGrWerh, lgrNijn As Double
        Dim Obraz As New ObjectIdCollection
        Dim OtstupOtGranizLista As Double = 40

        Kommand.createNewLayer(DwgParam.SlRasstInfo)


        '   Application.ShowAlertDialog("WiwodList Листов " & CStr(SpGrList.Count))
        ReDim SpIntervalTrass(SpGrList.Count - 1)
        Dim lKolwoInterval = 0
        For I As Integer = 2 To SpGrList.Count + 1


            If I = SpGrList.Count + 1 Then
                lGrWerh = gTrassa.Dlina
            Else
                lGrWerh = CType(SpGrList.SpGraniz(I), dwgGranizList).RastotNach
            End If
            lgrNijn = CType(SpGrList.SpGraniz(I - 1), dwgGranizList).RastotNach


            SpIntervalTrass(lKolwoInterval) = New modRasstOp.wlIntRasst(gRasst, lgrNijn, lGrWerh)
            Dim ShirLista = gTrassa.objGeom.obrParam.ShirinaLista
            Dim GrLista = gTrassa.objGeom.KoorP.Koeff * SpIntervalTrass(lKolwoInterval).Dlina
            '   Dim wOsX As Double = gTrassa.objGeom.Podpis.OsX
            Dim PoXWiw As Double = CDbl(GrLista) + clsPodpis.OsY + OtstupOtGranizLista
            Dim PoYwiw As Double = CDbl(ShirLista)
            Dim lnameList As String = CType(SpGrList.SpGraniz(I - 1), dwgGranizList).NameList
            'Dim lMas As Array
            'lMas = SpIntervalTrass(lKolwoInterval).InfoOInt
            'MsgBox("WiwodList " & lMas.Rank & " " & lMas.GetUpperBound(0))
            'Obraz.Add( _
            '    MakeEntitesLista.CreateLine(GrLista + clsPodpis.OsY, wOsX, GrLista + clsPodpis.OsY, wOsX + ShirLista, CType(SpGrList.SpGraniz(I - 1), dwgGranizList).NameList) _
            '    )
            '  Obraz.Add(MakeEntitesLista.CreateLine(clsPodpis.OsY, wOsX, PoXWiw, PoYwiw, lnameList))
            Kommand.OchistSlojList(DwgParam.SlRasstInfo, lnameList)
            Obraz.Add(MakeEntitesLista.CreateTable(New Point3d(PoXWiw, PoYwiw, 0), wShirinaStolbzowPiket, SpIntervalTrass(lKolwoInterval).InfoOInt, "Данные участка", lnameList))
            Obraz.Add(MakeEntitesLista.CreateTable(New Point3d(PoXWiw, PoYwiw - 100, 0), wShirinaStolbzow, SpIntervalTrass(lKolwoInterval).InfoOpor, "Количество опор на листе", lnameList))
            lKolwoInterval += 1
        Next

        Kommand.changeSloj(Obraz, DwgParam.SlRasstInfo)

    End Sub
    ''' <summary>
    ''' Вывод итоговых таблиц по расстановки опор: В пространстве модели по всей расстановке 
    ''' В пространствах листа по части отражаемой в листе 
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("InfoWList")> _
    Public Sub InfoWList()
        WiwodTablList()
        WiwodTablModel()
    End Sub

#End Region
#Region "Tonnaj"
    Dim StrInfo As String
    Private Function RaschetTonnaj(ByVal IAnkUch As wlAnkUchTr) As List(Of RezRaschTonnaj)


        StrInfo &= " Для  " & IAnkUch.NameAnkPr & vbCr
        Dim objRaschetTonnaj As New wlTonnajGirl
        With objRaschetTonnaj
            .AnkUch = IAnkUch
            .Rashet()
            StrInfo &= .IshRejm.Info & .RejmP7.Info & .RejmP3.Info

            For Each el As RezRaschTonnaj In objRaschetTonnaj.Tonnaj
                StrInfo &= el.NumName & " Т= " & Format(el.Tonnaj, "f2") & "Н" & " Тн= " & Format(el.TonnajMaxNorm, "f2") & "Н" & " Тав= " & Format(el.TonnajAw, "f2") & _
                 " Компл " & el.Кompllektazij & vbCr
            Next
        End With

        If IAnkUch.Tros Is Nothing Then
            StrInfo &= " трос отсутствует " & vbCr
            Return objRaschetTonnaj.Tonnaj
        Else
            StrInfo &= " Трос " & vbCr
        End If

        Dim objRaschetTonnajT As New wlTonnajGirlT
        With objRaschetTonnajT
            .AnkUch = IAnkUch
            .Rashet()
            StrInfo &= .IshRejm.Info & .RejmP7.Info & .RejmP3.Info

            For Each el As RezRaschTonnaj In objRaschetTonnajT.Tonnaj
                StrInfo &= el.NumName & " Т= " & Format(el.Tonnaj, "f2") & "Н" & " Тн= " & Format(el.TonnajMaxNorm, "f2") & "Н" & " Тав= " & Format(el.TonnajAw, "f2") & _
                " Компл " & el.Кompllektazij & vbCr
            Next
        End With


        Return objRaschetTonnaj.Tonnaj
    End Function
    <CommandMethod("OprTonnaj")> _
    Sub OprTonnaj()
        ' If SpAnkUch. Is Nothing Then
        InitMod()

        '' End If
        'StrInfo = "Расчет нагрузок(тоннажа) для гирлянд и креплений троса " & vbCr
        'For Each el As wlAnkUchTr In SpAnkUch
        '    RaschetTonnaj(el)
        'Next
        'MsgBox(StrInfo)
        Dim objDoc = New docwordTonnaj(SpAnkUch)
        objDoc.OprTonnaj()
    End Sub
    ''' <summary>
    ''' Расчет нагрузок(тоннажа) для гирлянд и креплений троса
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("OprTonnajF")> _
    Sub OprTonnajF()
        ' If SpAnkUch. Is Nothing Then
        InitMod()

        '' End If
        StrInfo = "Расчет нагрузок(тоннажа) для гирлянд и креплений троса " & vbCr
        For Each el As wlAnkUchTr In SpAnkUch
            RaschetTonnaj(el)
        Next
        MsgBox(StrInfo)

    End Sub
#End Region
#Region "otladka"
    Public Sub RaschetMontOtl()
        If objAnkUch Is Nothing Then
            Application.ShowAlertDialog("Raschet:не выбран анкерный участок")
            Exit Sub
        Else
            Application.ShowAlertDialog("Raschet: выбран анкерный участок " & objAnkUch.NameAnkPr)

        End If
        Dim StrInfo As String = "Moнтажные " & vbCr
        Dim gabrej As New Rejm("mont-20", objAnkUch.Nagr.G1, -20, objAnkUch.gpGabRej.Sigma)
        Dim lUrsost As rstSostAnkM(Of rstProlet) = objAnkUch.RaschetM(RejRaschMont.RejMont, gabrej)
        StrInfo &= gabrej.Info & vbCr

        gabrej = New Rejm("mont40", objAnkUch.Nagr.G1, 40, objAnkUch.gpGabRej.Sigma)
        lUrsost = objAnkUch.RaschetM(RejRaschMont.RejMont, gabrej)
        StrInfo &= gabrej.Info & vbCr
        gabrej = New Rejm("pred40", gabrej.Gamma, 40, gabrej.Sigma)
        lUrsost = objAnkUch.RaschetM(RejRaschMont.RejPred, gabrej)
        StrInfo &= gabrej.Info & vbCr
        gabrej = New Rejm("ust40", gabrej.Gamma, 40, gabrej.Sigma)
        lUrsost = objAnkUch.RaschetM(RejRaschMont.RejUst, gabrej)
        StrInfo &= gabrej.Info & vbCr
        gabrej = New Rejm("ust-20", gabrej.Gamma, -20, gabrej.Sigma)
        lUrsost = objAnkUch.RaschetM(RejRaschMont.RejUst, gabrej)
        Dim S As Double = lUrsost.ProletiResh(0).StrelaMax
        Dim Sigma = lUrsost.ProletiResh(0).Sigma0
        StrInfo &= gabrej.Info & " Стрела" & S & " Сигма " & Sigma & vbCr
        MsgBox(StrInfo)
        Dim lProv As New dwgKrivProvis("KrivprovR", 97)
        lProv.TchkKriv = objAnkUch.GetKrivProvisPr(lUrsost.ProletiResh)

    End Sub
    <CommandMethod("otlRst")> _
    Public Sub otlRst()
        Dim lfrm As New LeseSreib.FrmRastUsl
        lfrm.Rasst = gRasst
        lfrm.Show()


    End Sub
#End Region

    Sub New()
        If gRasst Is Nothing Then
			ChitatIzSohran(False)
		End If
        Kommand.createNewLayerNePrint(DwgParam.SlSlujbn)
        Dim objS As New dwgSobitij
        Dim lStrApp = clsXDATA.ProvReg
        If lStrApp = "" Then
            clsXDATA.Init()
            ' lStrApp = clsXDATA.ProvReg
        End If
    End Sub
End Class
