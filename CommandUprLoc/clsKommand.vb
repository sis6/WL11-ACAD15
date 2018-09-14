
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
Imports Teigha.Runtime
Imports _AcTrx = Teigha.Runtime
Imports _AcWnd = Bricscad.Windows
Imports DBTransMan = Teigha.DatabaseServices.TransactionManager
#End If


Imports BazDwg
Imports LeseSreib

Imports modRasstOp
Imports ProfilBaseDwg

'<Assembly: CommandClass(GetType(clsKommand))> 
'команды Автокада
Public Class clsKommand
    Inherits clsKommandBase
#Region "Параметры и информация"
    <CommandMethod("Info")> _
    Public Sub Info()
        Dim frmuch As New frmUchastki
        MsgBox(Me.ToString & " Info " & Application.DocumentManager.MdiActiveDocument.Name)
        If gRasst IsNot Nothing Then

			frmuch.Rasst = gRasst
            frmuch.Text &= gTrassa.NameDwg            'эти данные связаны с чертежом
            'frmuch.tbNameRab.Text = gTrassa.NameRab  'храниться в словаре чертежа
            frmuch.ShowDialog()
            '   Operazii.WiwodGrListEkranWDWG()
        Else
            Application.ShowAlertDialog(Me.ToString & "Info:  Трасса не представлена в словаре")
        End If


    End Sub
	<CommandMethod("UstZash")>
	Sub UstZash()

		Application.ShowAlertDialog("Защита от записи в чертеж WL11-Acad15 снята" & vbCr & " механизм оставлен в предыдущих версиях")


	End Sub

	Private Sub GranizEkranowInfo()
        Dim objGrEkr As New dwgSpGranizVidEkran
        objGrEkr.Izwlech()
        ' Dim wrRast As Double
        Dim StrnaWiw As String = "Границы Екранов" & vbCrLf
        For Each wrRast In objGrEkr.Rast
            StrnaWiw &= CDbl(wrRast) & vbCrLf
        Next

        Application.ShowAlertDialog(StrnaWiw)
    End Sub
    Private Sub ZapisGraniz()
        Dim frmGr As New frmWwdGrList
        frmGr.SpGr = New dwgSpGranizList

        frmGr.SpGrVid = New dwgSpGranizVidEkran
        frmGr.Trassa = gTrassa()

        If Application.ShowModalDialog(frmGr) = Windows.Forms.DialogResult.OK Then
            frmGr.SpGr.Save()
            frmGr.SpGrVid.Save()
        End If
    End Sub
    <CommandMethod("NewGrEkran")> _
    Sub NewGranizEkran()
        Dim Tchk As Point3dCollection = Kommand.GetPointsFromUser()
        Application.ShowAlertDialog("NewGranizEkran " & "Считано " & Tchk.Count)
        Dim objGrEkr As New dwgSpGranizVidEkran
        Dim tRast As Point3d
        Dim WrD As Double
        For Each tRast In Tchk

            WrD = gTrassa.UtochnitGraniz(gTrassa.RastPoDwgX(tRast.X))


            '  Application.ShowAlertDialog("NewGranizEkran " & "Rast " & WrD)

            objGrEkr.Dob(WrD)
        Next
        objGrEkr.Save()
        ZapisGraniz()

    End Sub
    <CommandMethod("EditGrEkran")> _
    Sub DobGranizEkran()
        GranizEkranowInfo()

        Dim objGrEkr As New dwgSpGranizVidEkran
        objGrEkr.Izwlech()
        Dim Tchk As Point3dCollection = Kommand.GetPointsFromUser()
        For Each tRast As Point3d In Tchk
            Dim WrD As Double = gTrassa.UtochnitGraniz(gTrassa.RastPoDwgX(tRast.X))
            objGrEkr.Dob(WrD)
        Next
        ZapisGraniz()
        objGrEkr.Save()

    End Sub
    ''' <summary>
    ''' Выводит форму границ экранов и листов и затем соответствующие границы отражает в модели в служебном слое
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("GrList")> _
    Public Sub GrList()

        ZapisGraniz()

		Kommand.createNewLayerNePrint(DwgParam.SlSlujbn)
        BazDwg.netSelectSet.OchistitSloj(DwgParam.SlSlujbn)


        Dim SpGrList As New dwgSpGranizList
        SpGrList.Izwlech()
        Dim SpGrEkr As New dwgSpGranizVidEkran
        SpGrEkr.Izwlech()
        Dim col As New ObjectIdCollection


        Dim NameLists As Collection = SpGrList.NameLists
        Dim MaxNumList = NameLists.Count - 1
        If MaxNumList >= 0 Then
            Dim Grl As dwgGranizList

            For Each Grl In SpGrList.SpGraniz

                Dim X As Double = gTrassa.DwgXpoRast(Grl.RastotNach)
                Dim tname = Grl.NameList
                Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage("Граница " & X & " листа " & tname)
                col.Add(MakeEntities.CreateLine(X, 800, X, gTrassa.objGeom.Podpis.OsX))
                col.Add(dwgText.CreateText(New Point3d(X, 800, 0), tname, 7))
            Next
        Else
            col.Add(dwgText.CreateText(New Point3d(clsPodpis.OsY, 600, 0), "Листы не предусмотрены", 7))
        End If
        For Each wr As Double In SpGrEkr.Rast
            Dim X As Double = gTrassa.objGeom.DwgXpoRast(wr)
            col.Add(MakeEntities.CreateLine(X, 600, X, gTrassa.objGeom.Podpis.OsX))
            col.Add(dwgText.CreateText(New Point3d(X, 600, 0), Format(wr, "#.#"), 7))
        Next
        Kommand.changeSloj(col, DwgParam.SlSlujbn)

    End Sub


#End Region
	''' <summary>
	''' Вывод границ листов и видовых экранов в чертеж в пространство иодели.
	''' </summary>
	''' <remarks></remarks>
#Region "Вывод профиля и расстановки"
	<CommandMethod("WiwodTr")> _
    Public Sub WiwodTr()
        '  Dim ltrassa = gTrassa()
        If dwgWiwRasst.ProvZagruzki() Then

            gTrassa.ObrazPrf()
            BazDwg.netSelectSet.OchistitSloj(DwgParam.SlProfilWidEkran)
			Kommand.createNewLayerNePrint(DwgParam.SlProfilWidEkran)
			Dim SpGrList As New dwgSpGranizTr(gTrassa)
            SpGrList.Izwlech()
            Dim SpGrEkr As New dwgSpGranizVidEkran
            SpGrEkr.Izwlech()

            Dim NameLists As Collection = SpGrList.NameLists
            Dim MaxNumList = NameLists.Count - 1
            If MaxNumList >= 0 Then
                Dim Gr As Collection
                Dim objTrNalist As dwgTrListName
                For I As Integer = 0 To MaxNumList
                    Dim lgrb, lGre As Double
                    Dim tname As String = CStr(NameLists.Item(I + 1))
                    SpGrList.GranLista(tname, lgrb, lGre)
                    If lGre > 1 Then
                        Gr = SpGrEkr.EkranDiapazon(lgrb, lGre)
                        Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage("WiwodTrWDWG " & tname & " " & Gr.Count & " B " & lgrb & " E " & lGre & vbCrLf)
                        objTrNalist = New dwgTrListName(gTrassa, tname)
                        objTrNalist.ObrazProfilWlist(Gr)
                    End If
                Next
            End If
        End If

    End Sub
    ''' <summary>
    ''' Вывод профиля в модель без пересчета видовых экранов
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("WiwodProfModel")> _
    Public Sub WiwodProfModel()
        If dwgWiwRasst.ProvZagruzki() Then
            gTrassa.ObrazPrf()

        End If
    End Sub
    <CommandMethod("WiwodProfModelGeo")> _
    Public Sub WiwodProfModelGeo()
        gTrassa.ObrazPrfGeo()
    End Sub
    <CommandMethod("WiwodKlim")> _
    Public Sub WiwodKlim()
        gTrassa.WiwTolkoKlim()
    End Sub
    <CommandMethod("WiwodRajon")> _
    Public Sub WiwodRajon()
        gTrassa.WiwTolkoKlim()
    End Sub
#End Region
#Region "сохранить в словаре"
    ''' <summary>
    '''сохраняет модель в словарях или БД в зависимости от режима
    ''' </summary>
    ''' <remarks> находиться в группе команд "Служебное" </remarks>
    <CommandMethod("SohrWSlw")> _
    Public Sub SohrWSlw()
        If Not dwgWiwRasst.ProvZagruzki() Then Return
        If gTrassa.NameDwg = Application.DocumentManager.MdiActiveDocument.Name Then

			ZapisWSohran()



		Else
            Application.ShowAlertDialog("Модель задания создана  в " & gTrassa.NameDwg & vbCr _
                                        & "сохранение  в  " & Application.DocumentManager.MdiActiveDocument.Name & " недопустимо ")
        End If
    End Sub
    ''' <summary>
    ''' - команда сохраняет   изменения  только топографических данных  в чертеже или в базе данных в зависимости от режима работы
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("SohrWSlwTrass")> _
    Public Sub SohrWSlwTr()
        If Not dwgWiwRasst.ProvZagruzki() Then Return
        If gTrassa.NameDwg = Application.DocumentManager.MdiActiveDocument.Name Then

			ZapisTrassaWSohran()



		Else
            Application.ShowAlertDialog("Модель трассы создана  в " & gTrassa.NameDwg & vbCr _
                                                   & "сохранение  в  " & Application.DocumentManager.MdiActiveDocument.Name & " недопустимо ")
        End If
    End Sub
#End Region
#Region "отладка"
    ''' <summary>
    ''' пустая команда для отладки
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("otlChitatUchSlw")> _
    Public Sub otlChitatUchSlw()

      

    End Sub

  


    Private Sub WiwestiRajonDwg(bPiket As clsPrf.ClsPiket, ePiket As clsPrf.ClsPiket)
        If Not bPiket Is ePiket Then
            Dim lXbeg = gTrassa.objGeom.DwgXpoRast(bPiket.RastOtnachala)
            Dim lXend = gTrassa.objGeom.DwgXpoRast(ePiket.RastOtnachala)
            Dim lDlObl = lXend - lXbeg
            Dim lPoY = gTrassa.objGeom.Podpis.PodpisKoor(13) + 1
            Dim lStrText = bPiket.NameRajon
            If String.IsNullOrEmpty(lStrText) Then lStrText = "не определен"
            Dim ltext As DBText = CType(dbPrim.CreateText(New Point3d(lXbeg, lPoY, 0), lStrText, DwgTr.WisTextP + 1), DBText)
            Dim lZnak As ObjectId = BazDwg.MakeEntities.CreateWstawkBlock(New Point3d(lXend, lPoY + 1.5, 0), "ТИЗ-О-землепользователи")
            'Try
            '    Kommand.changeSloj(lZnak, DwgParam.SlProfilRajon)
            'Catch ex As Exception


            'End Try
            If Not lZnak.IsNull Then Kommand.changeSloj(lZnak, DwgParam.SlProfilRajon)
            ltext.Layer = DwgParam.SlProfilRajon
            Dim lDltexta = dbPrim.DlinaPoX(ltext)
            If lDltexta < lDlObl Then
                Dim ldelta = 0.5 * (lDlObl - lDltexta)
                ltext.Position = New Point3d(lXbeg + ldelta, lPoY, 0)
            Else
                ltext.Justify = AttachmentPoint.BaseLeft
                ltext.AlignmentPoint = New Point3d(lXend, lPoY, 0)
            End If
            '      WiwestiwDwg(bPiket, el.GetPiket)
            dbPrim.Wkl(ltext)
        End If

    End Sub
    <CommandMethod("OtladOperazij")> _
    Public Sub OtladOperazij()
        'Dim m As New dwgMenuCui
        'm.UdalMenuCui()
        '   Application.ShowAlertDialog(Me.ToString & " Свободная команда")
        '    dwgMenuCui.menuNet()
        Kommand.createNewLayer(DwgParam.SlProfilRajon)
        BazDwg.netSelectSet.OchistitSloj(DwgParam.SlProfilRajon)
        Dim lspRajon = NajtiRajoni()
        gTrassa.ustBeg()
        Dim bPiket As clsPrf.ClsPiket = gTrassa.Piket
        For Each el As clsPrf.rajon In lspRajon
            WiwestiRajonDwg(bPiket, el.GetPiket)
            bPiket = el.GetPiket
        Next
        Dim EndPik = gTrassa.GetPiketi.Last
        WiwestiRajonDwg(bPiket, EndPik)
    End Sub
#End Region
#Region "Korrektirowki"
    <CommandMethod("WsawitKlimZon")> _
    Public Sub WsawitKlimZon()
        Dim lPoint As Point3d = Kommand.GetPointOtPolz(0)
        Dim lRealZ As Double = gTrassa.objGeom.RastPoDwgX(lPoint.X)
        Dim lpiket As clsPrf.ClsPiket = gTrassa.Piket(lRealZ)
        Dim luch As clsPrf.clsUchPrf = lpiket.UchPrf
        luch.WstawitKlimZon(lRealZ)
    End Sub
    ''' <summary>
    ''' pusto   
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("KorrDannUch")> _
    Public Sub KorrDannUch()

        'BazDwg.SystemKommand.Soob("Временно Расположение сведений" & vbCr _
        '                             & "BazDwg.dwgMenuCui " & "D:\WL11_13" & vbCr _
        '                             & "WiwodDok.DocWordBase.BasePapka" & WiwodDok.DocWordBase.BasePapka & vbCr _
        '                             & "OperBD.BasePapka" & OperBD.BasePapka)

    End Sub

    <CommandMethod("KorrDannProfLocal")> _
    Public Sub KorrDannProfLocal()
		If False Then
			Application.ShowAlertDialog("В совместном режиме  корректировка профиля запрещена")
		Else
			KorrDannProf()
        End If
    End Sub
    ''' <summary>
    ''' корректировка данных профиля в форме. При наличие в составе трассы несколько участков, для корректировки предлагается 1.   
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("KorrDannProf")> _
    Public Sub KorrDannProf()
        Dim lobj As New LeseSreib.FrmKorrProfilWlUch
        '  lobj.RasstNaTrasse = gRasst
        If gRasst Is Nothing Then

            If MsgBox("Трасса не представлена в чертеже." & vbCr & "Загрузить участок по умолчанию<OK>", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
				Dim wLStr() = {My.Settings.BasePapkaGlobal & "\DANN\default11.xls"}
				clsKommand0.ZagruzkaTrassRasstIzExcel(wLStr)

			Else
                Return
            End If


        End If
        '  MsgBox(Me.ToString & "KorrDannUch uch " & gRasst.Trassa.Uchastki.Count)
        lobj.IzmUch = gRasst.Uch(0)
        lobj.Dostup = gDostup
        Application.ShowModelessDialog(lobj)


	End Sub
    ''' <summary>
    ''' корректировка данных профиля в форме. Выбор участка происходит указанием точки на чертеже
    ''' </summary>
    ''' <remarks></remarks>
    <CommandMethod("KorrDannProfWibor")> _
    Public Sub KorrDannProfWibor()
        Dim lobj As New LeseSreib.FrmKorrProfilWlUch
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

	End Sub


	<CommandMethod("KorrBdDwg")> _
    Public Sub KorrBdDwg()
        Dim lfrm As New LeseSreib.FrmUchastkiKorr
        If ProvZagruzki() Then
            lfrm.Rasst = gRasst   'передали в форму расстановку
            lfrm.tbNameRab.Text = gTrassa.NameRab
            If lfrm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                '1e

                With gTrassa.objGeom.obrParam

                    .Rabota = lfrm.tbNameRab.Text
                End With





            End If
        End If

    

        clsKommandRst.SkrutMenuUch()

    End Sub
    <CommandMethod("KorrPiket", CommandFlags.UsePickSet)> _
    Public Sub KorrPiket()
        'на горячую Ctrl Alt T
        Dim lsp As List(Of Double) = Kommand.Wibrano(DwgParam.SlProfil)
        If lsp.Count < 1 Then  ' Выбираем в чертеже пикет для коррекции
            lsp = Kommand.Wibrano(DwgParam.SlProfilWspomogP)
            If lsp.Count < 1 Then
                Application.ShowAlertDialog("не выбран пикет")
                Return
            End If

        End If
        Dim lspPik As New List(Of clsPrf.ClsPiket)
        Dim lspReal As New List(Of Double)
        For Each r In lsp
            Dim zr As Double = gTrassa.RastPoDwgX(r)
            Dim lpiket = gTrassa.Piket(zr)
            Dim lpiketPr = lpiket.Pred
            If lpiketPr IsNot Nothing Then
                If Math.Abs(zr - lpiket.RastOtnachala) > Math.Abs(zr - lpiketPr.RastOtnachala) Then
                    lpiket = lpiketPr
                End If
            End If
            lspPik.Add(lpiket)
            lspReal.Add(zr)
        Next

        Dim lpik = lspPik(0)



        Dim lfrm As New clsPrf.frmPiket
        lfrm.Ustanowit(lpik, My.Settings.BasePapkaGlobal)
        If lfrm.ShowDialog() = Windows.Forms.DialogResult.OK And lfrm.CheckBoxPerepisat.Checked Then
            gTrassa.ObrazPrf()
        End If


	End Sub
    <CommandMethod("DobPiket", CommandFlags.UsePickSet)> _
    Public Sub DobPiket()
        'на горячую Ctrl T
        Dim lPoint As Point3d = Kommand.GetPointOtPolz(0)
        Dim lRealZ As Double = gTrassa.objGeom.RastPoDwgX(lPoint.X)
        Dim lpiket As clsPrf.ClsPiket = gTrassa.Piket(lRealZ)



        Dim lPiketajRealz As Double = lRealZ - lpiket.RastOtnachala + lpiket.Piketaj

        Dim lotmetkaRealz As Double = lpiket.Otmetka(lPiketajRealz)
        Dim lotmetkaRealLw, lotmetkaRealPr As Double
        If lpiket.EstOtmetkaLw Then
            lotmetkaRealLw = lpiket.OtmetkaLw(lPiketajRealz)
        Else
            lotmetkaRealLw = Double.MinValue
        End If
        If lpiket.EstOtmetkaPr Then
            lotmetkaRealPr = lpiket.OtmetkaPr(lPiketajRealz)
        Else
            lotmetkaRealPr = Double.MinValue
        End If

        Dim lnewPiket As New clsPrf.ClsPiket("New", lPiketajRealz, lotmetkaRealz, lpiket.UchPrf, lotmetkaRealLw, lotmetkaRealPr)
        lpiket.UchPrf.DobPiket(lnewPiket)
        lnewPiket.RastOtnachala = lpiket.RastOtnachala + lnewPiket.Piketaj - lpiket.Piketaj


        Dim lfrm As New clsPrf.frmPiket
        lfrm.Ustanowit(lnewPiket, My.Settings.BasePapkaGlobal)
        If lfrm.ShowDialog() = Windows.Forms.DialogResult.OK Then

            lnewPiket.RastOtnachala = lpiket.RastOtnachala + lnewPiket.Piketaj - lpiket.Piketaj
            'If lfrm.Pikugod IsNot Nothing Then
            '    lpiket.UchPrf.Dob(lfrm.Pikugod)
            'End If

            If lfrm.CheckBoxPerepisat.Checked Then gTrassa.ObrazPrf()

		Else
            lpiket.UchPrf.Udalit(lnewPiket)
        End If


        ' ls = lpik.UchPrf.NameUch & vbCr

        'Dim lp1 As New Point3d(lsp(0) - 1, 0, 0)


        '  Kommand.CheckForPickfirstSelection()
    End Sub
#End Region
#Region "Wedomosti"
    <CommandMethod("WedomostUglow")> _
    Public Sub WedomostUglow()
        Dim lDoc As New WedIzisk.docUglPow(gTrassa)
        lDoc.NameLin = gTrassa.NameLin
        lDoc.NameTrass = gTrassa.NameRab
        lDoc.Otkrit()

    End Sub
    <CommandMethod("WedomostPeresech")> _
    Public Sub WedomostPeresech()
        Dim lDoc As New WedIzisk.docPeresech(gTrassa)
        lDoc.NameLin = gTrassa.NameLin
        lDoc.NameTrass = gTrassa.NameRab
        lDoc.Otkrit()

    End Sub
    <CommandMethod("WedomostUgodDoc")> _
    Public Sub WedomostUgodDoc()
        Dim lspRajon = NajtiRajoni()
        Dim lDoc As WedIzisk.DocUgodij
        If lspRajon.Count > 0 Then
            lDoc = New WedIzisk.DocUgodij(gTrassa, lspRajon)
        Else
            lDoc = New WedIzisk.DocUgodij(gTrassa)


        End If

        lDoc.NameLin = gTrassa.NameLin
        lDoc.NameTrass = gTrassa.NameRab
        lDoc.OtkritBezKolonTit()
        lDoc.ZakForm()

    End Sub
    Function EstLiRajon(iSpRajon As List(Of clsPrf.rajon), iNameRajon As String) As Boolean
        For Each el As clsPrf.rajon In iSpRajon
            If iNameRajon.Equals(el.NameRajon) Then Return True
        Next
        Return False
    End Function
    Function SowpadeniePredRajon(iSpRajon As List(Of clsPrf.rajon), iNameRajon As String) As Boolean
        If iSpRajon.Count = 0 Then Return False
        Return iSpRajon.Last.NameRajon.Equals(iNameRajon)

    End Function
    Function NajtiRajoni() As List(Of clsPrf.rajon)
        Dim lspRajon As New List(Of clsPrf.rajon)
        For Each el As clsPrf.clsUchPrf In gTrassa.Uchastki
            Dim elpik As clsPrf.ClsPiket = el.BegUch
            Do Until elpik Is Nothing
                Dim lnamerajon As String = elpik.NameRajon
                If Not String.IsNullOrEmpty(lnamerajon) Then
                    If Not SowpadeniePredRajon(lspRajon, lnamerajon) Then lspRajon.Add(New clsPrf.rajon(gTrassa, elpik, elpik.NameRajon))
                End If
                elpik = elpik.Sled

            Loop
        Next
        Return lspRajon
    End Function
    <CommandMethod("WedomostUgod")> _
    Public Sub WedomostUgod()
        Dim lXls As New WedIzisk.xlsPiketUgod(gTrassa)

    End Sub
#End Region

	Sub New()
		MyBase.New
		If gRasst Is Nothing Then

			ChitatIzSohran(False)


		End If

	End Sub
End Class
