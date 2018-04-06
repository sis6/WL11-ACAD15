Imports modRasstOp
Imports BazDwg

'Imports Microsoft.Office.Interop
'Imports Microsoft.Office.Interop.Excel
Public Module ModIsp
    Public Const GlParam As String = "GlParam" 'Имя словаря
    Public Const ZpParam As String = "ZapOUch" 'Имя записи о параметрах профиля
    Public Const ZpParamPlana As String = "ZapParamPlan"  'Имя записи о параметрах профиля
    Public Const SpFile As String = "SpFile"  'Запись о прикрепленных файлах
    Public Const SpFileIge As String = "SpFileIge"  'Запись о прикрепленных файлах c описанием параметров ИГЭ
    'Public Const ZapIdentDan As String = "ZapidentDann" ' Запись о идентифицирующие участки хранящиеся в чертеже(нименование участков)
    'Public Const ZapGuidUch As String = "ZapGuidUch"    'Запись в строковом представление глобальных идентификаторов
    Public Const KorSlDann As String = "Uch"   ' korenъ для формирования имени словаря в котором храняться данные 
    Private wNameWL As New List(Of String)
    Private wUnom As Integer
    Function BasePapka() As String
        Return My.Settings.BasePapka
    End Function
    Sub UstBasePapKu(iPut As String)
        My.Settings.BasePapka = iPut
    End Sub
    Function NameWl() As String
        Dim l As New System.Text.StringBuilder
        For Each el As String In wNameWL

            l.Append(el)
            l.Append(" ")
        Next
        Return l.ToString
    End Function
    Function Unom() As Integer
        Return wUnom
    End Function
    Public Sub WiborSwFile()
        'Для составления списка Exel файлов связанных с чертежем
        ' можно выбрать один из участков
        Dim SlParam As New dwgSlowar(LeseSreib.GlParam)
        '   Dim Danr() As TypedValue, Danwh() As TypedValue
        Dim SwFile() As String = Nothing
        Dim RazmParam As Integer
        SwFile = SlParam.ZapisIzSlovarStr((LeseSreib.SpFile))
        Try
            ' SlParam.ZapisIsSlowar(LeseSreib.SpFile) 'Считали что записано в словаре о записях

            RazmParam = UBound(SwFile)
        Catch ex As Exception
            RazmParam = -1
           
        End Try
       

        SwFile = LeseSreib.ModIsp.ZapisSwFile(SwFile)

        Try
            RazmParam = UBound(SwFile)
        Catch ex As Exception
            RazmParam = -1

        End Try
        SlParam.ZapisW_SlowarStr(LeseSreib.SpFile, SwFile)

    End Sub
    Public Function LeseSlwFileUch() As String()
        'Читает в строку список файлов прикрепленыз к чертежу
        Dim SlParam As New dwgSlowar(LeseSreib.GlParam)
        Dim lRazmParam As Integer
        Dim lSpStr() As String = SlParam.ZapisIzSlovarStr(LeseSreib.SpFile)

        Try

            lRazmParam = UBound(lSpStr)


        Catch ex As Exception

            Return Nothing
        End Try

        Return lSpStr

    End Function

	''' <summary>
	''' Cчитывает только расстановку из ассоцированых файлов
	''' </summary>
	''' <param name="PutiK_File">пути к ассоциированным файлам</param>
	''' <param name="iRasst">модель трасы и расстановки в которой нужно заменить расстановку </param>
	''' <returns> возвращает массив участков </returns>
	''' <remarks></remarks>
	Function LeseDannRasst(ByVal PutiK_File() As String, ByVal iRasst As wlRasst) As wlUch()
        Dim iTrassa = iRasst.Trassa
        If PutiK_File Is Nothing Then
            Return Nothing
        End If
        Dim MasUch() As wlUch = Nothing ' массив  участков  расстановки результирующий
        Dim lAppExcel As New Microsoft.Office.Interop.Excel.Application

        'инициализация формы сообщений

        clsSwExel.frmSoob = New frmSoob
        clsSwExel.frmSoob.Show()
        clsSwExel.frmSoob.TextBox1.AppendText("LeseDannRasst  ")

        Dim I As Integer = 1 'индекс в массиве файлов
        Dim mi As Integer = 0 'индекс в массиве участков
        Dim Count As Integer = iTrassa.Uchastki().Count  'количество участков в трассе


        For Each Str As String In PutiK_File
            If I <= Count Then
                Dim DocExcel As New LeseSreib.Sw_UchPrfExel(lAppExcel, CType(iTrassa.Uchastki(I), clsPrf.clsUchPrf))
                ReDim Preserve MasUch(mi)
                DocExcel.NameFile = Str
                If DocExcel.NameFile = Str Then
                    clsSwExel.frmSoob.TextBox1.AppendText(vbCrLf & " Расст файл " & Str & vbCr)
                    DocExcel.IzExcelRasstanowku()
                    MasUch(mi) = DocExcel.RasstUchWL
                    clsSwExel.frmSoob.TextBox1.AppendText(" участок " & DocExcel.RasstUchWL.NameUch & vbCrLf)
                Else
                    clsSwExel.frmSoob.TextBox1.AppendText(vbCrLf & " Файл отсутствует добавляем существуюший" & vbCr & " Участок " & DocExcel.RasstUchWL.NameUch & vbCrLf)
                    MasUch(mi) = CType(iTrassa.Uchastki(I), modRasstOp.wlUch)
                End If

            End If

            I += 1
            mi += 1


        Next
        lAppExcel.Quit()
        lAppExcel = Nothing
        clsSwExel.frmSoob.Close()
        clsSwExel.frmSoob = Nothing

        Return MasUch
    End Function
    ''' <summary>
    ''' Считывает трассу и расстановку из ассоциированных с чертежом файлов и формирует коллекцию участков
    ''' </summary>
    ''' <param name="PutiK_File">пути к ассоциированным файлам </param>
    ''' <returns> возвращает коллекцию участков </returns>
    ''' <remarks></remarks>
    Function LeseDann(ByVal PutiK_File() As String) As Collection

        If PutiK_File Is Nothing Then
            Return Nothing
        End If
        Dim objRdann As New Collection ' создали коллекцию для хранения списка участков
        Dim lAppExcel As New Microsoft.Office.Interop.Excel.Application

        Dim wf As frmSoob = New frmSoob 'форма для выдачи сообщений
        clsSwExel.frmSoob = wf
        clsSwExel.frmSoob.Show()
        clsSwExel.frmSoob.TextBox1.AppendText("LeseDann  ")


        For Each Str As String In PutiK_File
            Dim DocExcel As New LeseSreib.Sw_UchPrfExel(lAppExcel)
            DocExcel.NameFile = Str
            If DocExcel.NameFile = Str Then
                clsSwExel.frmSoob.TextBox1.AppendText(vbCrLf & "начали " & Str & " " & DocExcel.RasstUchWL.NameUch & vbCrLf)
                DocExcel.IzExcel()
                objRdann.Add(DocExcel.RasstUchWL)
                clsSwExel.frmSoob.TextBox1.AppendText("Каталог " & Str & " " & DocExcel.RasstUchWL.NameUch & vbCrLf)
            End If
            If Not wNameWL.Contains(DocExcel.NameLin) Then wNameWL.Add(DocExcel.NameLin)
            If DocExcel.Unom > wUnom Then wUnom = DocExcel.Unom
        Next
        lAppExcel.Quit()
        lAppExcel = Nothing
        clsSwExel.frmSoob.Close()
        clsSwExel.frmSoob = Nothing
        Return objRdann
    End Function
    Function ZapisSwFile(ByVal SpFile() As String) As String()
        Dim frmObj As New frmWiborFile
        Dim RazmFile As Integer
        ' MsgBox("ModIsp  ZapisSwFile " & "Создали форму ")
        Try
            RazmFile = UBound(SpFile)



        Catch ex As System.Exception
            RazmFile = -1
        Finally
        End Try

        For I = 0 To RazmFile

            If Not String.IsNullOrEmpty(SpFile(I)) Then
                frmObj.lbSpFile.Items.Add(SpFile(I))
            End If
        Next
        'MsgBox("ModIsp  ZapisSwFile " & " Dialog ")

        Dim RezSpFile() As String = Nothing
        If frmObj.ShowDialog = Windows.Forms.DialogResult.OK Then

            RazmFile = frmObj.lbSpFile.Items.Count - 1
            If RazmFile >= 0 Then
                ReDim RezSpFile(RazmFile)
                For I = 0 To RazmFile
                    RezSpFile(I) = frmObj.lbSpFile.Items(I).ToString
                Next

            End If
            Return RezSpFile
        End If
        Return SpFile
    End Function
    ''' <summary>
    ''' Создает из словаря профиль  расстановку
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>дублирует функцию из clsLeseSreib </remarks>
    Friend Function CreateIzSlowara() As modRasstOp.wlRasst
        Dim lname As String = ""
        Dim lunom As Integer
        Dim lnamerab As String = ""
        clsLeseSrejbRasstDwg.IzwlechDannOLini(KorSlDann, lname, lnamerab, lunom)
        Dim ltrassa As New clsPrf.clsTrass(lname, lnamerab, lunom)
        Dim lrasst As New modRasstOp.wlRasst(ltrassa)
        Dim dnDwg As New LeseSreib.clsLeseSrejbRasstDwg(KorSlDann, lrasst)
        dnDwg.Izwlech()
        Return lrasst
    End Function
    Public Sub ZapisatW_Excel(ByVal iUch As modRasstOp.wlUch, ByVal inameuch As String, ByVal iUnom As Integer)
        Dim lExcApp As New Microsoft.Office.Interop.Excel.Application
        '    Dim www As String = My.Settings.BasePapka
        Dim lbooks As Microsoft.Office.Interop.Excel.Workbook = lExcApp.Workbooks.Add(My.Settings.BasePapka & "\DANNTEMPLATE\" & "\shablonWL11.xltx")
        'Dim lshets As Microsoft.Office.Interop.Excel.Worksheet = CType(ExcApp.ActiveSheet, Microsoft.Office.Interop.Excel.Worksheet)    'CType(lbooks.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        ' lExcApp.Visible = True
        Dim LwlUch As New LeseSreib.Sw_UchPrfExel(lbooks, iUch, inameuch, iUnom)
        LwlUch.UchastokW_Exel()
        lExcApp.Visible = True
    End Sub
End Module
