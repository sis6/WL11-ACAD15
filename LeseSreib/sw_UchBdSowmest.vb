Option Explicit On
Option Strict On
'Imports Microsoft.Office.Interop
Imports clsPrf
Imports modRasstOp
Imports OperBD
Imports System.Data
Public Class sw_UchBdSowmest
    Private wta As New OperBD.DsUprSowmestTableAdapters.uchastkiNTableAdapter
    Private wDsupr As New OperBD.DsUprSowmest
    Sub New(ByVal iDostup As dostup)
        connBD.UstPodkl(wta, iDostup.StrPodklSowmest)
    End Sub
    Function WseZapisi() As DsUprSowmest.uchastkiNDataTable
        Return wta.GetData()
    End Function
End Class
''' <summary>
''' класс чтения,записи данных о участке трассы ВЛ 
''' </summary>
''' <remarks></remarks>
Public Class sw_ParamuchBdSowmest
    Private wta As New OperBD.DsUprSowmestTableAdapters.uchastkiNTableAdapter
    Private wDsupr As New OperBD.DsUprSowmest
    Private wRowOuch As OperBD.DsUprSowmest.uchastkiNRow = Nothing
    Private wUch As modRasstOp.wlUch  'участок модели соответствующий записи в БД
    ''' <summary>
    ''' Проверяет есть ли запись о участке.
    ''' </summary>
    ''' <value></value>
    ''' <returns> возвращает True если есть</returns>
    ''' <remarks></remarks>
    ReadOnly Property IsUchastok() As Boolean
        Get
            Return wRowOuch IsNot Nothing
        End Get
    End Property
    Property Unom As Integer
        Get
            Return wRowOuch.Unom
        End Get
        Set(ByVal value As Integer)
            wRowOuch.Unom = value
        End Set
    End Property
    ''' <summary>
    ''' возвращает созданный объект модели участка
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Uchastok() As modRasstOp.wlUch
        Get
            Return wUch
        End Get
    End Property
    ''' <summary>
    ''' индентификатор участка в базе данных совместнгй работы
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property UidUch() As Guid
        Get
            Try
                Return wRowOuch.UIdUch
            Catch ex As Exception
                Return Guid.Empty
            End Try

        End Get
    End Property
    Property NameWl() As String
        Get
            Return wRowOuch.NameWl
        End Get
        Set(ByVal value As String)
            wRowOuch.NameWl = value
        End Set
    End Property
    Property NameRab As String
        Get
            Return wRowOuch.NameRab
        End Get
        Set(ByVal value As String)
            wRowOuch.NameRab = value
        End Set
    End Property
    Property Shirina() As Double

        Get
            Return wRowOuch.Shirina
        End Get
        Set(ByVal value As Double)
            wRowOuch.Shirina = CSng(value)
        End Set
    End Property
    ReadOnly Property NameUch() As String
        Get
            Return wRowOuch.NameUch
        End Get
    End Property
    ReadOnly Property Polz() As String
        Get
            If wRowOuch.IsPolzNull Then
                Return "--"
            Else
                Return wRowOuch.Polz
            End If

        End Get
    End Property
    ReadOnly Property DataMod() As Date
        Get
            If wRowOuch.IsDataModNull Then
                Return Date.MinValue
            Else
                Return wRowOuch.DataMod
            End If

        End Get
    End Property
    ReadOnly Property PolzOVl() As String
        Get
            If wRowOuch.IsPolzOVLNull Then
                Return "--"
            Else
                Return wRowOuch.PolzOVL
            End If
        End Get
    End Property
    ReadOnly Property DataModOp() As Date
        Get
            If wRowOuch.IsDataModOpNull Then
                Return Date.MinValue
            Else
                Return wRowOuch.DataModOp
            End If
        End Get
    End Property
    ''' <summary>
    ''' Проверяет есть ли запись с такими параметрами в БД
    ''' </summary>
    ''' <param name="iNameWl"> имя ВЛ </param>
    ''' <param name="iNameUch"> имя участка </param>
    ''' <param name="iNameRab">имя работы </param>
    ''' <returns>Возвращает истнуесли такая запись есть </returns>
    ''' <remarks></remarks>
    Public Shared Function ProverkaNeUnikfkalnosti(iNameWl As String, iNameUch As String, iNameRab As String) As Boolean
        Dim lDs As New OperBD.DsUprSowmest
        Dim lTa As New OperBD.DsUprSowmestTableAdapters.uchastkiNTableAdapter
        lTa.FillWlRabUch(lDs.uchastkiN, iNameWl, iNameUch, iNameRab)
        If lDs.uchastkiN.Count > 0 Then Return True Else Return False
    End Function

#Region "Cохранение вБД"
    Sub DataSohrProf()
        wRowOuch.Polz = My.User.Name
        wRowOuch.DataMod = Now
    End Sub
    Sub DataSohrRasst()

        wRowOuch.PolzOVL = My.User.Name
        wRowOuch.DataModOp = Now
        '    MsgBox("Сохраняет " & wRowOuch.PolzOVL)
    End Sub
    Private Sub SozdatZapisUchastka(ByVal IUidUch As Guid) 'создаем  или корректируем запись участка по данным участка

        wRowOuch = CType(wDsupr.uchastkiN.NewRow, DsUprSowmest.uchastkiNRow)
        With wRowOuch
            .UIdUch = IUidUch
            .Unom = wUch.Unom
            .NameWl = wUch.NameWl
            .NameUch = wUch.NameUch
            .NameRab = wUch.NameRab
            .DataW = Now
            .Shirina = CSng(wUch.ShirinaPofil)
        End With
        wDsupr.uchastkiN.AdduchastkiNRow(wRowOuch)

    End Sub
    Private Sub Init(ByVal iUidUch As Guid) 'инициализация записи в бд для записи участка
        If iUidUch.Equals(Guid.Empty) Then
            SozdatZapisUchastka(Guid.NewGuid) ' cоздаем новую запись с новым гуидом
            Return
        End If

        Try
            wta.FillBy(wDsupr.uchastkiN, iUidUch) ' извлекаеи запись
        Catch ex As Exception
            MsgBox(Me.ToString & "Init идентификатор участка  " & iUidUch.ToString & " не верно задан. " & vbCr & " Создаем новую запись " & ex.Message)
            iUidUch = Guid.NewGuid ' если неуспешно то создаем новую  запись
            SozdatZapisUchastka(Guid.NewGuid) ' cоздаем новую запись с новым гуидом
            Return
        End Try

        If wDsupr.uchastkiN.Rows.Count = 0 Then
            BazDwg.SystemKommand.SoobEditor(Me.ToString & " участок c Guid " & iUidUch.ToString & " отсутствует в БД. Создаем запись ")
            '   .MsgBox(Me.ToString & " участок c Guid " & iUidUch.ToString & " отсутствует в БД ")
            SozdatZapisUchastka(iUidUch)  ' cоздаем новую запись с  заданным  гуидом
        Else
            wRowOuch = CType(wDsupr.uchastkiN.Rows(0), DsUprSowmest.uchastkiNRow)
            With wRowOuch
                .Unom = wUch.Unom
                .NameWl = wUch.NameWl
                .NameUch = wUch.NameUch
                .NameRab = wUch.NameRab
                .Shirina = CSng(wUch.ShirinaPofil)
                '.DataMod = Now
                '.Polz = My.User.Name
                '.PolzOVL = My.User.Name

            End With  'корректируем запись
        End If

    End Sub
    ''' <summary>
    ''' Конструктор для создания объекта обеспечивающего запись данных участка в временную  базу данных
    ''' </summary>
    ''' <param name="iUiduch">Guid участка во временной базе данных </param>
    ''' <param name="iDostup"> характеристики пользователя и строки подключения </param>
    ''' <param name="IUch"> участок который будет записан во временню БД </param>
    ''' <remarks></remarks>
    Sub New(ByVal iUiduch As Guid, ByVal iDostup As dostup, ByVal IUch As clsPrf.clsUchPrf)
        If String.IsNullOrEmpty(My.User.Name) Then My.User.InitializeWithWindowsUser() 'инициализация юзера
        Try
            connBD.UstPodkl(wta, iDostup.StrPodklSowmest)  'подключение табле адаптера к совместной БД
        Catch ex As Exception
            If wta Is Nothing Then
                MsgBox(Me.ToString & " wta Nothing")
            End If
            If iDostup Is Nothing Then
                MsgBox(Me.ToString & " iDostup  Nothing")
            End If

        End Try

        wUch = CType(IUch, wlUch)


        Init(iUiduch)
    End Sub
    Sub update()
        wta.Update(wDsupr.uchastkiN)
        ' tableadapter()
        ' Dim ds As Tableadapter

    End Sub
    Sub Delete()
        wRowOuch.Delete()
        '    wDsupr.AcceptChanges()
    End Sub
#End Region
    ''' <summary>
    ''' Конструктор для создания объекта обеспечивающего создание участка из временой БД 
    ''' </summary>
    ''' <param name="iUiduch"></param>
    ''' <param name="iDostup"></param>
    ''' <remarks> Данные по участку должны присутствовать в БД</remarks>
    Sub New(ByVal iUiduch As Guid, ByVal iDostup As dostup)
        connBD.UstPodkl(wta, iDostup.StrPodklSowmest)
        Try
            wta.FillBy(wDsupr.uchastkiN, iUiduch)
        Catch ex As Exception
            MsgBox(Me.ToString & "New идентификатор участка  " & iUiduch.ToString & " не верно задан " & ex.Message)
            Return
        End Try
        If wDsupr.uchastkiN.Rows.Count = 0 Then
            MsgBox(Me.ToString & " участок c Guid " & iUiduch.ToString & " отсутствует в БД ")
            Return
        Else
            wRowOuch = CType(wDsupr.uchastkiN.Rows(0), DsUprSowmest.uchastkiNRow)
        End If
        wUch = New wlUch(wRowOuch)

    End Sub


End Class
''' <summary>
''' Класс обеспечивает чтение данных из БД формирование модели участка
''' </summary>
''' <remarks></remarks>
Public Class sw_UchIzBdSowmest
    Inherits Sw_IzDs_Rasst
    Protected wParamUch As sw_ParamuchBdSowmest
    Private wConnBd As connBD
#Region "чтение из BD"
    ''' <summary>
    ''' Параметры участка бeруться по гуиду участка базы данных
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub IzBdUchastok()

        With wConnBd
            '.ad.Fill(DsProfil.ProfilN, wParamUch.UidUch)

            .ada.Fill(dsProfil.ProfilA, wParamUch.UidUch)

            .adK.Fill(dsProfil.TablKlimN, wParamUch.UidUch)
            .adPikugod.Fill(dsProfil.PikUgodN, wParamUch.UidUch)
        End With
        If dsProfil.ProfilA.Count = 0 Then
            MsgBox(Me.ToString & "IzBdUchastok dsProfil.ProfilA не считано")
        End If
        ' IzDsUzastok(wParamUch.NameUch)
        wRasstNaUch.NameUch = wParamUch.NameUch
        wRasstNaUch.SozdatPoDataSet()
    End Sub
    ''' <summary>
    ''' когда имя известно или ннужно присвоить отличное от имени в БД
    ''' </summary>
    ''' <param name="iNameUch"></param>
    ''' <remarks></remarks>
    Private Sub IzBdUchastok(ByVal iNameUch As String)

        '   Dim ada As New dsProfilTableAdapters.ProfilATableAdapter
        With wConnBd
            .ada.Fill(dsProfil.ProfilA, wParamUch.UidUch)
            .adK.Fill(dsProfil.TablKlimN, wParamUch.UidUch)
            .adPikugod.Fill(dsProfil.PikUgodN, wParamUch.UidUch)
        End With
        If dsProfil.ProfilA.Count = 0 Then
            MsgBox(Me.ToString & "IzBdUchastok dsProfil.ProfilA не считано")
        End If
        wRasstNaUch.NameUch = iNameUch
        wRasstNaUch.SozdatPoDataSet()


    End Sub
    Private Sub IzBDRasstanowku()
        ' Dim prmuch As New dsRasstTableAdapters.ParamUchNTableAdapter
        With wConnBd
            ' MsgBox(Me.ToString & " IzBDRasstanowku Guid " & wParamUch.UidUch.ToString)
            .addefp.Fill(dsRasst.ParamUchN, wParamUch.UidUch)
            '    Dim adMech As New dsRasstTableAdapters.MechUslTableAdapter
            .admu.FillBy(dsRasst.MechUsl, wParamUch.UidUch)
            ' Dim adOpor As New dsRasstTableAdapters.rastOpNTableAdapter
            .adopor.FillOporNaUchastke(dsRasst.rastOpN, wParamUch.UidUch)
            IzDsRasstanowku()
        End With



    End Sub
    ''' <summary>
    ''' Параметры участка бeруться по гуиду участка базы данных
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub IzBD_Wse()
        IzBdUchastok()
        IzBDRasstanowku()
    End Sub
    ''' <summary>
    ''' когда имя известно или ннужно присвоить отличное от имени в БД
    ''' </summary>
    ''' <param name="iNameUch"></param>
    ''' <remarks></remarks>
    Private Sub IzBD_Wse(ByVal iNameUch As String)
        IzBdUchastok(iNameUch)
        IzBDRasstanowku()
    End Sub

    ReadOnly Property DataSetProfil() As DsProfil
        Get
            Return dsProfil
        End Get
    End Property
    ReadOnly Property DataSetRasst() As dsRasst
        Get
            Return dsRasst
        End Get
    End Property
    ReadOnly Property DataSetElemRasstUch As ElemRasstUch
        Get
            Return wRasstNaUch.DannElemRasstUch.DataSet
        End Get
    End Property
    ReadOnly Property ParamUch() As sw_ParamuchBdSowmest
        Get
            Return wParamUch
        End Get
    End Property

#End Region
#Region "Init"
    Sub New()

    End Sub
    ''' <summary>
    ''' Для чтения из бд
    ''' </summary>
    ''' <param name="iUkNaUch"> Guid участка во БД совместной работы </param>
    ''' <param name="idostup"> доступ и прочее </param>
    ''' <remarks></remarks>
    Public Sub New(ByVal iUkNaUch As Guid, ByVal idostup As dostup)
        'Для чтения из бд в модель участка
        MyClass.New()

        wParamUch = New sw_ParamuchBdSowmest(iUkNaUch, idostup)  'по указателю получили данные участка
        If wParamUch.IsUchastok Then
            wConnBd = New connBD(idostup.StrPodklSowmest)   ' подключили табле адаптеры
            wRasstNaUch = wParamUch.Uchastok
            wRasstNaUch.SetElemRasstUch(idostup.StrPodklSowmest)
        End If
    End Sub
#End Region
End Class
''' <summary>
''' записывает данные участка трассы в БД совместной работы 
''' </summary>
''' <remarks></remarks>
Public Class sw_UchWBdSowmest
    Inherits Sw_IzRasst_DS
    Protected wParamUch As sw_ParamuchBdSowmest
    Private wdostup As OperBD.dostup
    Private wConnBd As connBD
    ''' <summary>
    ''' Guid участка записаного в БД
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GuidUch() As Guid

        Get
            Return wParamUch.UidUch
        End Get

    End Property
    ''' <summary>
    ''' для записи данных  участка в   БД
    ''' </summary>
    ''' <param name="iRasstnauch"> участок ВЛ </param>
    ''' <param name="iParamUch"> данные о записи параметров участка в бД(запись в таблице участков)   </param>
    ''' <param name="idostup">  свединее о пользователе  </param>
    ''' <remarks></remarks>
    Sub New(ByVal iRasstnauch As wlUch, ByVal iParamUch As sw_ParamuchBdSowmest, ByVal idostup As OperBD.dostup)
        'для записи участка в новeую запись участока БД
        MyBase.New(iRasstnauch)
        If iParamUch.UidUch.Equals(Guid.Empty) Then
            MsgBox(Me.ToString & " участок не создан  ")
            Return
        End If
        wConnBd = New connBD(idostup.StrPodklSowmest)
        wParamUch = iParamUch
        wdostup = idostup
    End Sub
#Region "участок  в BD"

    Private Sub OpredGranUch(ByRef PikBeg As Double, ByRef PikEnd As Double)
        Dim lprf As DsProfil = dsProfil
        If lprf.ProfilN.Rows.Count = 0 Then Return
        PikBeg = CType(lprf.ProfilN.Rows(0), OperBD.DsProfil.ProfilNRow).Piketaj
        PikEnd = CType(lprf.ProfilN.Rows(lprf.ProfilN.Rows.Count - 1), OperBD.DsProfil.ProfilNRow).Piketaj
    End Sub
    Private Sub ObniwitRasstOp()
        ' таккак опорам могут присвоит новые имена совпадающие со старыми именами других опор
        ' то процедуру проводим несколько раз
        Dim SpNiobn As New List(Of dsRasst.rastOpNRow)
        Dim i As Integer = 0
        Dim ipred As Integer = Integer.MaxValue
        'отдельно учли удаленные чтобы в дальнейшем при обновление добавленых не менялась таблица RastOpN
        Dim lTableUdal As dsRasst.rastOpNDataTable
        lTableUdal = CType(dsRasst.rastOpN.GetChanges(DataRowState.Deleted), OperBD.dsRasst.rastOpNDataTable)
        If lTableUdal IsNot Nothing Then
            wConnBd.adopor.Update(lTableUdal)
        End If


beg:    i = 0

        For Each el As dsRasst.rastOpNRow In dsRasst.rastOpN
            Try
                If el.RowState <> DataRowState.Deleted Then wConnBd.adopor.Update(el)

            Catch ex As System.Data.SqlClient.SqlException
                i += 1
            Catch ex As Exception
                MsgBox(Me.ToString & "ObniwitRasstOp что то  с=  " & el.NumName & vbCr & ex.Message)
                Return
            End Try


        Next
        If ipred = i Then
            MsgBox(Me.ToString & "ObniwitRasstOp Не удалось обновить в БД опор =  " & i)
            Return
        End If
        If i > 0 Then
            ipred = i
            GoTo beg
        End If
        dsRasst.rastOpN.AcceptChanges()
    End Sub

    ''' <summary>
    ''' записывает данные растановки в бд
    ''' </summary>
    ''' <remarks> Проверяет на совпадение Guidow </remarks>
    Sub RasstanowkuWBDUpdate()
        If Not wRasstNaUch.UidUch = wParamUch.UidUch Then
            MsgBox(Me.ToString & " RasstanowkuWBD  идентификатор записи участка " & wParamUch.UidUch.ToString & vbCr & " не соответствует идентификаторам модели " & wRasstNaUch.UidUch.ToString)
            Return
        End If
        Dim lDannElUch As DannElemRasstUch = wRasstNaUch.DannElemRasstUch
        lDannElUch.StrPodkl = wdostup.StrPodklSowmest
		' wRasstNaUch.UstUidUchRasst()
		'MsgBox(Me.ToString & "RasstanowkuWBDUpdate  " & wdostup.StrPodklSowmest)
		lDannElUch.Update()
        With wConnBd
            .addefp.Update(dsRasst.ParamUchN)
            .admu.Update(dsRasst.MechUsl)
            ObniwitRasstOp()
        End With
    End Sub
    ''' <summary>
    ''' записывает данные растановки в бд
    ''' </summary>
    ''' <remarks> Устанавливает Guid элементов по guid участка </remarks>
    Public Sub RasstanowkuWBDNewGuid()
        Dim lDannElUch As DannElemRasstUch = wRasstNaUch.DannElemRasstUch
        lDannElUch.StrPodkl = wdostup.StrPodklSowmest
        wRasstNaUch.UstUidUchRasst()
        lDannElUch.Update()
        With wConnBd
            .addefp.Update(dsRasst.ParamUchN)
            .admu.Update(dsRasst.MechUsl)
            ObniwitRasstOp()
        End With
    End Sub
    ''' <summary>
    ''' записывает данные профиля в БД
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ProfilWBD()
        If Not wRasstNaUch.UidUch = wParamUch.UidUch Then
            MsgBox(Me.ToString & " ProfilWBD  идентификатор записи участка " & wParamUch.UidUch.ToString & vbCr & " не соответствует идентификаторам модели " & wRasstNaUch.UidUch.ToString)
            Return
        End If
        wParamUch.Shirina = wRasstNaUch.ShirinaPofil
        wParamUch.NameWl = wRasstNaUch.NameWl
        With wConnBd
            .ad.Fill(dsProfil.ProfilN, wParamUch.UidUch)
            .adOs.FillBy(dsProfil.Osob, wParamUch.UidUch)
            .AdUg.FillBy(dsProfil.UgolPoworota, wParamUch.UidUch)
        End With
        ProfilwDS()
        With wConnBd
            .ad.Update(dsProfil.ProfilN)
            .adOs.Update(dsProfil.Osob)
            .AdUg.Update(dsProfil.UgolPoworota)
            .adPikugod.Update(dsProfil.PikUgodN)
            .adK.Update(dsProfil.TablKlimN)
        End With

    End Sub
    ''' <summary>
    ''' записывает данные профиля в БД
    ''' </summary>
    ''' <remarks> В случае если в бд с guidom записи участка есть данные и Guid записи и Guid участка не совпадают то запись не производиться   </remarks>
    Function ProfilwBDNewGuid() As Boolean

        wParamUch.Shirina = wRasstNaUch.ShirinaPofil
        wParamUch.NameWl = wRasstNaUch.NameWl
        With wConnBd 'так как из БД передается представление ProfilA, в этих таблицах нужно отразить изменение 
            .ad.Fill(dsProfil.ProfilN, wParamUch.UidUch)
            .adOs.FillBy(dsProfil.Osob, wParamUch.UidUch)
            .AdUg.FillBy(dsProfil.UgolPoworota, wParamUch.UidUch)
        End With
        If wRasstNaUch.UidUch <> wParamUch.UidUch Then

            If dsProfil.ProfilN.Count > 0 Then
                MsgBox(Me.ToString & " ProfilwBDzam идентификатор записи участка " & wParamUch.UidUch.ToString & vbCr & " не соответствует идентификаторам модели " _
                       & wRasstNaUch.UidUch.ToString _
                       & vbCr & " Для  участка " & wParamUch.UidUch.ToString & vbCr & " имеються данные запись не произведена")
                Return False
            End If
            wRasstNaUch.UstUidUchProfil(wParamUch.UidUch) 'если с этим Guid'ом данных нет то приводим к этому значению записываемый участок

        End If

        ProfilwDS()
        With wConnBd
            .ad.Update(dsProfil.ProfilN)
            .adOs.Update(dsProfil.Osob)
            .AdUg.Update(dsProfil.UgolPoworota)
            .adPikugod.Update(dsProfil.PikUgodN)
            'For Each el As DsProfil.TablKlimNRow In DsProfil.TablKlimN
            '    Try
            '        .adK.Update(el)
            '    Catch ex As Exception

            '        MsgBox(Me.ToString & " обновление климата " & el.Piketaj & "  " & el.RowState & "  ")
            '    End Try

            'Next

            .adK.Update(dsProfil.TablKlimN)
        End With
        Return True
    End Function

#End Region
End Class
