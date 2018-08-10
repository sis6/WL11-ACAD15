
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
Imports Bricscad.EditorInput
Imports Teigha.Geometry
Imports _AcGi = Teigha.GraphicsInterface
Imports _AcGs = Teigha.GraphicsSystem
Imports _AcPl = Bricscad.PlottingServices
Imports _AcBrx = Bricscad.Runtime
Imports Teigha.Runtime
Imports _AcWnd = Bricscad.Windows
Imports DBTransMan = Teigha.DatabaseServices.TransactionManager
#End If
Imports BazDwg
Imports ProfilBaseDwg

Public Class DljaInit
	Implements IExtensionApplication
	'CommandUprLoc.dll
	Public Sub Initialize() Implements IExtensionApplication.Initialize

		My.Settings.BasePapkaLocal = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)

		Dim ltekpapka = Environment.CurrentDirectory
		My.Settings.BasePapkaLocal = Environment.CurrentDirectory
		WiwodDok.DocWordBase.BasePapka = My.Settings.BasePapkaGlobal
		LeseSreib.UstBasePapKu(My.Settings.BasePapkaGlobal)
		OperBD.My.MySettings.Default.BasePapka = My.Settings.BasePapkaGlobal
		ProfilBaseDwg.My.MySettings.Default.BasePapkaGlobal = My.Settings.BasePapkaGlobal


		Dim lname = My.Application.Culture.Name
		My.Application.ChangeCulture(lname)
		My.Application.Culture.NumberFormat.NumberDecimalSeparator = "."
		My.Application.Culture.NumberFormat.NumberGroupSeparator = ""
		Dim lDecSep = My.Application.Culture.NumberFormat.NumberDecimalSeparator
		Dim lGroupSep = My.Application.Culture.NumberFormat.NumberGroupSeparator
		BazDwg.SystemKommand.SoobEditor(vbCr & " Inizialize  ldec " & lDecSep & "lGroup  " & lGroupSep & "Kult " & lname & vbCr)

		BazDwg.SystemKommand.SoobEditor(vbCr & Me.ToString & " приложение  " & My.Application.Info.AssemblyName & vbCr _
										& "загрузка  из " & My.Application.Info.DirectoryPath & "  базовая папка  " & LeseSreib.BasePapka)

	End Sub

	Public Sub Terminate() Implements IExtensionApplication.Terminate

	End Sub
End Class
''' <summary>
''' Класс инкапсулирующий функции обеспечивающий построение модели трассы и расстановки ВЛ и
''' сохранение ее в словарях чертежа
''' </summary>
''' <remarks> модель трассы и расстановки не обязательно должна присутствовать в пространстве активного чертежа </remarks>
Public Class clsKommandBase
    'Public Const PutKNastrojkiAcad As String = "D:\Настройки Acad"
    Public Shared Sobitie As SobCollDoc


	Protected Shared DopustPolz As Boolean 'допустимость пользователя
    Protected Shared CollFileRab As Collection

    Friend Shared gRasst As modRasstOp.wlRasst

    Shared Function gTrassa() As DwgTr
        If gRasst Is Nothing Then Return Nothing
        Return CType(gRasst.Trassa, DwgTr)
    End Function
    Sub New()
		'gDostup = New OperBD.dostup
		'	MsgBox(ToString() & "  " & gDostup.StrPodklSowmest)


		If Sobitie Is Nothing Then Sobitie = New SobCollDoc




		DopustPolz = True
            If CollFileRab Is Nothing Then CollFileRab = New Collection

		If String.IsNullOrEmpty(My.User.Name) Then My.User.InitializeWithWindowsUser()
		SystemKommand.SoobEditor("Параметр приложения " & "  user   " & My.User.Name)



		SystemKommand.SoobEditor(vbCr & " Создан класс " & ToString() & " в " & Application.DocumentManager.MdiActiveDocument.Name)




	End Sub



#Region "чтение запись  из словарей и баз данных совместной работы"
	''' <summary>
	''' Сохранение модели трассы и расстановки в словарях чертежа
	''' </summary>
	''' <remarks> временно , только в форме выбора режима </remarks>
	Public Shared Sub SohranitTrassRasstW_Dwg()
        If DopustPolz Then
            Dim dnDwg As New LeseSreib.clsLeseSrejbRasstDwg(LeseSreib.KorSlDann, gRasst)
            dnDwg.Save()

        End If

    End Sub
    ''' <summary>
    ''' Cохранение модели и трассы в зависимости от режима работы в чертеже или бД
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function ZapisWSohran() As Boolean
        If DopustPolz Then
			If False Then
				'	Return gRejRab.SchreibeWSowmest(gRasst, gDostup)
			Else
				SohranitTrassRasstW_Dwg()

            End If
            SystemKommand.Sohr()
            Return True
        End If
        Return False
    End Function
    Private Shared Sub ZapisRasstW_SlwIzDwg()
        If DopustPolz Then
            Dim dnDwg As New LeseSreib.clsLeseSrejbRasstDwg(LeseSreib.KorSlDann, gRasst)
            dnDwg.SaveRasst()

        End If

    End Sub
    Shared Sub ZapisRasstWSohran()
        If DopustPolz Then
			If False Then
				'gRejRab.SchreibeRasstWSowmest(gRasst, gDostup)
			Else
				ZapisRasstW_SlwIzDwg()
            End If
            SystemKommand.Sohr()
        End If

    End Sub
    Private Shared Sub ZapisTrW_SlwIzDwg()
        If DopustPolz Then
            Dim dnDwg As New LeseSreib.clsLeseSrejbRasstDwg(LeseSreib.KorSlDann, gRasst)
            dnDwg.SaveTr()

        End If

    End Sub
    Shared Sub ZapisTrassaWSohran()
        If DopustPolz Then
			If False Then
				'gRejRab.SchreibeTrassWSowmest(gRasst, gDostup)
			Else
				ZapisTrW_SlwIzDwg()
            End If
            SystemKommand.Sohr()
        End If

    End Sub
    Private Shared Sub ChitatTrRasstIz_Slw()


        If DopustPolz Then
            Dim lnamelin As String = ""
            Dim lnameRab As String = ""
            Dim lunom As Integer
            LeseSreib.clsLeseSrejbRasstDwg.IzwlechDannOLini(LeseSreib.KorSlDann, lnamelin, lnameRab, lunom)
            gRasst = New modRasstOp.wlRasst(New DwgTr(lnamelin, lnameRab, lunom))
            Dim dnDwg As New LeseSreib.clsLeseSrejbRasstDwg(LeseSreib.KorSlDann, gRasst)
            If Not dnDwg.Izwlech() Then gRasst = Nothing

        End If

    End Sub

    Shared Sub ChitatIzSohran(iPrRejimSowmestRab As Boolean)


        If DopustPolz Then
            If iPrRejimSowmestRab Then
				MsgBox("clskommand0 Связи с БД не предусмотрено")
				'gRasst = gRejRab.leseIzSowmest(gDostup)
			Else
                MsgBox("clskommand0 ChitatIzSohran из чертежа")
                ChitatTrRasstIz_Slw()
            End If


        End If

    End Sub
#End Region
    ''' <summary>
    ''' Выделяет из расстановки участок и наего основе строит расстановку
    ''' </summary>
    ''' <param name="lPikbeg"> начальный пикет  </param>
    ''' <param name="lPikEnd"> конечный пикет</param>
    ''' <returns> расстановка </returns>
    ''' <remarks> пока можно выделить для одного участка расстановки </remarks>
    Shared Function WidelitIzRasstanowki(lPikbeg As clsPrf.ClsPiket, lPikEnd As clsPrf.ClsPiket) As modRasstOp.wlRasst
        If lPikbeg.UchPrf Is lPikEnd.UchPrf Then
            Dim lclsOperUch As New LeseSreib.OperUchCls(CType(lPikbeg.UchPrf, modRasstOp.wlUch), Nothing, lPikbeg.Piketaj, lPikEnd.Piketaj)

            Dim lUchWidelit As modRasstOp.wlUch = lclsOperUch.SozdatUchastok(LeseSreib.ChastUchastka.Mejdu)
            Dim lRasst As New modRasstOp.wlRasst(New clsPrf.clsTrass(gRasst.Trassa.NameLin, "Detal", gRasst.Trassa.Unom))
            lRasst.Trassa.DobUch(lUchWidelit)
            lRasst.OprRast()
            Return lRasst
        Else
            Return Nothing
        End If
    End Function
    ''' <summary>
    ''' ОпредеВыделяет из расстановки участок  и наего основе строит расстановку
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function WidelitRasstannowkuPoParamDwg() As modRasstOp.wlRasst
        Dim lrasst As modRasstOp.wlRasst
        If gRasst Is Nothing Then
            Application.ShowAlertDialog("clsKommand0.vb:WidelitRasstannowkuPoParamDwg  " & " Не загружена расстановка")
            Return Nothing
        End If

        If gTrassa.objGeom.obrParam.TipGraniz = ParamTrass.TipDetal Then
            Dim lPikBeg As clsPrf.ClsPiket = gTrassa.Piket(gTrassa.objGeom.obrParam.BegUch)
            Dim lpikEnd As clsPrf.ClsPiket = gTrassa.Piket(gTrassa.objGeom.obrParam.EndUch)
            If lPikBeg Is Nothing OrElse lpikEnd Is Nothing Then
                Application.ShowAlertDialog("clsKommand0.vb:WidelitRasstannowkuPoParamDwg  " & " Не найдены границы детали")
                lrasst = gRasst
            Else
                lrasst = clsKommandBase.WidelitIzRasstanowki(lPikBeg, lpikEnd)
            End If

        Else
            lrasst = gRasst

        End If
        Return lrasst
    End Function
    Protected Overrides Sub Finalize()

		'   MsgBox(Me.ToString & " закончил работу ")
		MyBase.Finalize()
    End Sub
End Class
''' <summary>
''' команды не требующие предварительно загруженой модели
''' </summary>
''' <remarks></remarks>
Public Class clsKommand0
    Inherits clsKommandBase
    Private Sub SlovariDwg()
        Dim pDict As DBDictionary      'Autodesk.AutoCAD.DatabaseServices.DBObject
        Dim pDictInum As DbDictionaryEnumerator

        Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database
        Dim tm As DBTransMan = db.TransactionManager
        Dim ta As Transaction = tm.StartTransaction()

        Dim Str_oth As String = "Cловари чертежа" & vbCr
        Try

            pDict = CType(ta.GetObject(db.NamedObjectsDictionaryId, OpenMode.ForRead), DBDictionary)

            pDictInum = pDict.GetEnumerator()
            'MsgBox()
            Str_oth = pDict.ObjectId.ObjectClass.DxfName & vbCrLf
            Do While pDictInum.MoveNext()
                ' MsgBox("S " & "k " &  & "  Z  " & )
                Str_oth = Str_oth & " Name " & pDictInum.Key & " Tip " & pDictInum.Value.ObjectClass.DxfName & vbCrLf
            Loop

            ta.Commit()
        Catch ex As InvalidOperationException
            Application.ShowAlertDialog(Me.ToString & "исключение" & ex.Message)
            Exit Try
        Catch ex As Exception
            Application.ShowAlertDialog(Me.ToString & " что то не то" & ex.GetType.ToString)
            Exit Try
        Finally

            ta.Dispose()
        End Try
        Application.ShowAlertDialog(Str_oth)
    End Sub
    <CommandMethod("pslwall")> _
    Sub prosmotrSlowar()
        SlovariDwg()
        'If gRasst Is Nothing Then

        '    ChitatIzSohran(gRejRab.RejmSowmest)


        'End If
    End Sub
   
    ' cловарь со списком связаных с чертежом описаний профиля
    <CommandMethod("wiboru")> _
    Public Sub WiborU()
        LeseSreib.WiborSwFile()
    End Sub

	<CommandMethod("Param")> _
    Public Sub param()
        Dim frmObj As New ProfilBaseDwg.frmParam
        frmObj.Trassa = gTrassa()
        frmObj.Text &= Application.DocumentManager.MdiActiveDocument.Name

        ' frmObj.Show()
        If Application.ShowModalDialog(frmObj) = Windows.Forms.DialogResult.OK Then
            Application.ShowAlertDialog("Записываем в чертеж")


			If gRasst IsNot Nothing Then
                gTrassa.objGeom = Nothing
                gTrassa.objGeom = New ProfilBaseDwg.dwgGeometr
            End If



        End If



    End Sub




#Region "Загрузки"
	''' <summary>
	''' Читать трасу и расстановку из чертежа или из совместной Бд в зависимости от режима
	''' </summary>
	''' <remarks></remarks>
	<CommandMethod("ChTrRst")> _
    Public Sub ChitatTrRst()
		ChitatIzSohran(False)
		clsKommandRst.SkrutMenuUch()

        If gRasst Is Nothing Then
            Application.ShowAlertDialog("Данные отсутствуют в чертеже")
        End If


    End Sub
#Region "загрузка Excel"

    ''' <summary>
    ''' Загрузка модели трассы и расстановки из файлов Excel
    ''' </summary>
    ''' <param name="iStrPut"> пути к файлам EXcel </param>
    ''' <remarks></remarks>
    Shared Sub ZagruzkaTrassRasstIzExcel(ByVal iStrPut As String())
        Dim CollUch As Collection = LeseSreib.ModIsp.LeseDann(iStrPut)
        '   Application.ShowAlertDialog("clsKommand0 " & ":ZagruzkaTrassRasstIzExcel " & CollUch.Count)
        If CollUch IsNot Nothing Then

            gRasst = New modRasstOp.wlRasst(New ProfilBaseDwg.DwgTr(LeseSreib.ModIsp.NameWl, "Данные из Excel", LeseSreib.ModIsp.Unom))
            For Each wr As modRasstOp.wlUch In CollUch
                If wr.UchTr.MaxNumPiket > 0 Then
                    gTrassa.DobUch(wr)
                    SystemKommand.SoobEditor("clsKommand0 " & ":ZagruzkaTrassRasstIzExcel " & "добавили участок" & wr.UchTr.NameUch)

                    '  MsgBox("Считан " & wr.RasstUchWl.Count)
                End If
            Next
            If gTrassa.MaxNumUchTr > -1 Then
                gRasst.OprRast()
                gTrassa.objGeom.obrParam.Rabota = "Данные из Excel"
                gTrassa.objGeom.obrParam.SchreibeParam()
                Application.ShowAlertDialog("clsKommand0 " & ":ZagruzkaTrassRasstIzExcel    трасса загружена")
            Else
                Application.ShowAlertDialog("clsKommand0 " & ":ZagruzkaTrassRasstIzExcel отсутствуют участки")
                gRasst = Nothing
            End If


            '     MsgBox("Закончен Init ")
        End If
    End Sub
    ''' <summary>
    ''' Загрузка модели трассы(только данных профиля)  из файлов Excel
    ''' </summary>
    ''' <param name="iStrPut"> пути к файлам EXcel </param>
    ''' <remarks></remarks>
    Shared Sub ZagruzkaTrassIzExcel(ByVal iStrPut As String())
        Dim CollUch As Collection = LeseSreib.ModIsp.LeseDann(iStrPut)
        '   Application.ShowAlertDialog("clsKommand0 " & ":ZagruzkaTrassRasstIzExcel " & CollUch.Count)
        If CollUch IsNot Nothing Then

            gRasst = New modRasstOp.wlRasst(New ProfilBaseDwg.DwgTr(LeseSreib.ModIsp.NameWl, "trassa из Excel", LeseSreib.ModIsp.Unom))
            For Each wr As modRasstOp.wlUch In CollUch
                If wr.UchTr.MaxNumPiket > 0 Then
                    wr.OchistwlUchIUdalit()
                    gTrassa.DobUch(wr)
                    SystemKommand.SoobEditor("clsKommand0 " & ":ZagruzkaTrassIzExcel " & "добавили участок" & wr.UchTr.NameUch)

                    '  MsgBox("Считан " & wr.RasstUchWl.Count)
                End If
            Next
            If gTrassa.MaxNumUchTr > -1 Then
                gRasst.OprRast()
                gTrassa.objGeom.obrParam.Rabota = "Данные из Excel"
                gTrassa.objGeom.obrParam.SchreibeParam()
                Application.ShowAlertDialog("clsKommand0 " & ":ZagruzkaTrassIzExcel    трасса загружена")
            Else
                Application.ShowAlertDialog("clsKommand0 " & ":ZagruzkaTrassIzExcel отсутствуют участки")
                gRasst = Nothing
            End If


            '     MsgBox("Закончен Init ")
        End If
    End Sub
    <CommandMethod("TrRstIz_Excel")> _
    Public Sub TrRstW_Slw()
		If False Then
			Application.ShowAlertDialog("TrRstW_Slw в совместном режиме не допустима загрузка из внешних источников ")
			Return
		End If
		'If gDostup.Prawo = OperBD.dostup.PrawoDostup.Polz Or gDostup.Prawo = OperBD.dostup.PrawoDostup.PolzGeod Or gDostup.Prawo = OperBD.dostup.PrawoDostup.AdGeod Then
		'    Application.ShowAlertDialog("TrRstW_Slw запрещено  с правом  " & gDostup.ImaPolz & " загружать расстановку")
		'End If
		ZagruzkaTrassRasstIzExcel(LeseSreib.LeseSlwFileUch())

	End Sub
#End Region
    <CommandMethod("zTrIzExcel")> _
    Public Sub zTrIzExcel()
		If False Then
			Application.ShowAlertDialog("TrRstW_Slw в совместном режиме не допустима загрузка из внешних источников ")
			Return
		End If

		ZagruzkaTrassIzExcel(LeseSreib.LeseSlwFileUch())

	End Sub

#End Region





	Sub New()
        '   Dim llayout As New SobPrimList
        '    Application.ShowAlertDialog("Параметр приложения " & My.Settings.Param1 & "gjkmpjdfntkmcrbq " & My.Settings.polzParam1)
    End Sub
End Class
