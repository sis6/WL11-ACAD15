Imports BazDwg
Imports clsPrf
Imports modRasstOp
Public Class RejmSohranenij
    Protected Const SlSowmest As String = "SlSowmest"
    Protected Const ZapisOrej As String = "ZapisOrej"
    Protected ZapisOGuid As String = "ZapisOGuid"
    Protected wRejmSowmest As Integer = 0
    Protected wMassGuid() As Guid ' массив указателей данных на участке в базе данных совместного режима
    Protected wkolwoUch As Integer = 0 'количество участков
    ''' <summary>
    ''' устанавливает режим совместной работы
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property RejmSowmest As Boolean
        Get
            If wRejmSowmest > 0 Then Return True
            Return False

        End Get
        Set(ByVal value As Boolean)
            If value = True Then
                wRejmSowmest = 1
            Else
                wRejmSowmest = 0

            End If
        End Set
    End Property
    Private Sub RazborZapisi(ByVal iOrejm() As String) 'формирование членов класса по считаной записи
        Erase wMassGuid
        Dim lRazmPar As Integer
        If iOrejm Is Nothing Then Return
        Try
            lRazmPar = UBound(iOrejm)
        Catch ex As Exception
            lRazmPar = -1
            Return
        End Try
        If lRazmPar > -1 Then wRejmSowmest = CInt(iOrejm(0))
        '  If wRejmSowmest = 0 Then Return
        Dim lkolwoUch As Integer = 0
        If lRazmPar > 0 Then wkolwoUch = CInt(iOrejm(1))
        lRazmPar = Math.Min(2 + wkolwoUch - 1, lRazmPar)
        For i As Integer = 2 To lRazmPar
            Dim lguid As Guid
            Try
                lguid = New Guid(CStr(iOrejm(i)))
            Catch ex As Exception
                Exit For
            End Try
            ReDim Preserve wMassGuid(i - 2)
            wMassGuid(i - 2) = lguid
        Next
    End Sub

    Protected Sub Izwlech() 'для извлечения записи из данного чертежа
        Dim SlParam As New BazDwg.dwgSlowar(SlSowmest)
        Dim lrejm() As String

        lrejm = SlParam.ZapisIzSlovarStr(ZapisOrej)
        RazborZapisi(lrejm)



    End Sub
    ''' <summary>
    ''' Сохранение в словаре записи о режимах работы и указателей на участки в бД совместной работы
    ''' </summary>
    ''' <remarks></remarks>
    Sub Save()
        Dim SlParam As New BazDwg.dwgSlowar(SlSowmest)
        Dim lStatus() As String
        Dim lkolwoUch As Integer = 0
        If wMassGuid IsNot Nothing Then
            lkolwoUch = wMassGuid.Length
        End If
        ReDim lStatus(1 + lkolwoUch)


        lStatus(0) = CStr(wRejmSowmest)
        lStatus(1) = CStr(lkolwoUch)
        For I As Integer = 0 To lkolwoUch - 1
            lStatus(I + 2) = wMassGuid(I).ToString
        Next
        '     Dim lock As Autodesk.AutoCAD.ApplicationServices.DocumentLock = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.LockDocument()
        SlParam.ZapisW_SlowarStr(ZapisOrej, lStatus)
        '   lock.Dispose()


    End Sub
    ' ''' <summary>
    ' ''' Сохранение в словаре записи о режимах работы и указателей на участки в бД совместной работы
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Friend Shared Sub Save(iMassguid() As Guid)
    '    Dim SlParam As New BazfunNet.dwgSlowar(SlSowmest)
    '    Dim lStatus() As String
    '    Dim lkolwoUch As Integer = 0
    '    If iMassguid IsNot Nothing Then
    '        lkolwoUch = iMassguid.Length
    '    End If
    '    ReDim lStatus(1 + lkolwoUch)


    '    lStatus(0) = CStr(1)
    '    lStatus(1) = CStr(lkolwoUch)
    '    For I As Integer = 0 To lkolwoUch - 1
    '        lStatus(I + 2) = iMassguid(I).ToString
    '    Next
    '    '     Dim lock As Autodesk.AutoCAD.ApplicationServices.DocumentLock = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.LockDocument()
    '    SlParam.ZapisW_SlowarStr(ZapisOrej, lStatus)
    '    '   lock.Dispose()


    'End Sub
    ''' <summary>
    ''' создание класса режиме и указателях в текущем чертеже 
    ''' </summary>
    ''' <remarks></remarks>
    Sub New()

        Izwlech()

    End Sub
    ReadOnly Property MassGuid As Guid()
        Get
            Return wMassGuid
        End Get
    End Property
End Class
''' <summary>
''' класс инкапсулирует функции обеспечивающии сохранение и чтение данных модели расстановки в совместном режиме
''' </summary>
''' <remarks></remarks>
Public Class clsSreibeBD
    Inherits RejmSohranenij
    ' Private wMassGuid() As Guid ' массив указателей данных на участке в базе данных совместного режима
    ''' <summary>
    ''' записывает В БД данные о составе трассы по записям участкам
    ''' </summary>
    ''' <param name="iRasst"> модель профиля и расстановки </param>
    ''' <param name="idostup"> характеристики доступа пользователя  </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SchreibeWSowmestOSostawe(ByVal iRasst As modRasstOp.wlRasst, ByVal idostup As OperBD.dostup) As Boolean
        Dim TekIndexUch As Integer = 0
        For Each eluch As clsPrf.clsUchPrf In iRasst.Trassa.Uchastki
            Dim paruch As LeseSreib.sw_ParamuchBdSowmest
            Dim KolwoUchBdSowmest As Integer = 0
            If wMassGuid IsNot Nothing Then KolwoUchBdSowmest = wMassGuid.Length
            If TekIndexUch < KolwoUchBdSowmest Then
                paruch = New LeseSreib.sw_ParamuchBdSowmest(wMassGuid(TekIndexUch), idostup, eluch)
            Else
                paruch = New LeseSreib.sw_ParamuchBdSowmest(Guid.Empty, idostup, eluch)
                ReDim Preserve wMassGuid(TekIndexUch)
                wMassGuid(TekIndexUch) = paruch.UidUch
            End If
            paruch.DataSohrProf()
            paruch.DataSohrRasst()

            Try

                paruch.update()
            Catch ex As Exception
                MsgBox(Me.ToString & " SchreibeWSowmest Не удалось создать запись о участке " & ex.Message)
                Return False
            End Try


            TekIndexUch += 1




        Next
        ' RejmSohranenij.Save(wMassGuid)
        Save()
        Return True
    End Function
    ''' <summary>
    ''' запись в БД совместной работы профиля и расстановки 
    ''' </summary>
    ''' <param name="iRasst"> модель профиля и расстановки </param>
    ''' <param name="idostup"> характеристики доступа пользователя </param>
    ''' <remarks></remarks>
    Public Function SchreibeWSowmest(ByVal iRasst As modRasstOp.wlRasst, ByVal idostup As OperBD.dostup) As Boolean
        Dim TekIndexUch As Integer = 0
        For Each eluch As clsPrf.clsUchPrf In iRasst.Trassa.Uchastki
            Dim paruch As LeseSreib.sw_ParamuchBdSowmest
            Dim KolwoUchBdSowmest As Integer = 0
            If wMassGuid IsNot Nothing Then KolwoUchBdSowmest = wMassGuid.Length
            If TekIndexUch < KolwoUchBdSowmest Then
                paruch = New LeseSreib.sw_ParamuchBdSowmest(wMassGuid(TekIndexUch), idostup, eluch)
            Else
                paruch = New LeseSreib.sw_ParamuchBdSowmest(Guid.Empty, idostup, eluch)
                ReDim Preserve wMassGuid(TekIndexUch)
                wMassGuid(TekIndexUch) = paruch.UidUch
            End If
            paruch.DataSohrProf()
            paruch.DataSohrRasst()

            Try

                paruch.update()
            Catch ex As Exception
                MsgBox(Me.ToString & " SchreibeWSowmest Не удалось создать запись о участке " & ex.Message)
                Return False
            End Try

            Dim dannUchastka As New LeseSreib.sw_UchWBdSowmest(CType(eluch, modRasstOp.wlUch), paruch, idostup)

            If dannUchastka.ProfilwBDNewGuid() Then
                dannUchastka.RasstanowkuWBDNewGuid()
                TekIndexUch += 1
            End If



        Next
        ' RejmSohranenij.Save(wMassGuid)
        Save()
        Return True
    End Function
    ''' <summary>
    ''' запись в БД совместной работы  расстановки 
    ''' </summary>
    ''' <param name="iRasst"> модель профиля и расстановки</param>
    ''' <param name="idostup"> характеристики доступа пользователя</param>
    ''' <remarks></remarks>
    Public Sub SchreibeRasstWSowmest(ByVal iRasst As modRasstOp.wlRasst, ByVal idostup As OperBD.dostup)
		Dim TekIndexUch As Integer = 0
		'MsgBox(Me.ToString & " SchreibeRasstWSowmest Сохраняем в БД данные профиля участка ")
		For Each eluch As clsPrf.clsUchPrf In iRasst.Trassa.Uchastki
            Dim paruch As LeseSreib.sw_ParamuchBdSowmest
            Dim KolwoUchBdSowmest As Integer = 0
            If wMassGuid IsNot Nothing Then KolwoUchBdSowmest = wMassGuid.Length
            If TekIndexUch < KolwoUchBdSowmest Then
                paruch = New LeseSreib.sw_ParamuchBdSowmest(wMassGuid(TekIndexUch), idostup, eluch)
            Else
                MsgBox(Me.ToString & " SchreibeRasstWSowmest Сохранити в БД данные профиля участка " & eluch.NameUch)

				Exit For
            End If
            paruch.DataSohrRasst()
            Try
                paruch.update()
            Catch ex As Exception
                Return
            End Try

            Dim dannUchastka As New LeseSreib.sw_UchWBdSowmest(CType(eluch, modRasstOp.wlUch), paruch, idostup)

            dannUchastka.RasstanowkuWBDUpdate()
            TekIndexUch += 1

        Next
        Save()
    End Sub
    ''' <summary>
    ''' запись в БД совместной работы профиля 
    ''' </summary>
    ''' <param name="iRasst"> модель профиля и расстановки</param>
    ''' <param name="idostup"> характеристики доступа пользователя</param>
    ''' <remarks></remarks>
    Function SchreibeTrassWSowmest(ByVal iRasst As modRasstOp.wlRasst, ByVal idostup As OperBD.dostup) As Boolean
        Dim TekIndexUch As Integer = 0
        For Each eluch As clsPrf.clsUchPrf In iRasst.Trassa.Uchastki
            Dim paruch As LeseSreib.sw_ParamuchBdSowmest
            Dim KolwoUchBdSowmest As Integer = 0
            If wMassGuid IsNot Nothing Then KolwoUchBdSowmest = wMassGuid.Length
            If TekIndexUch < KolwoUchBdSowmest Then
                paruch = New LeseSreib.sw_ParamuchBdSowmest(wMassGuid(TekIndexUch), idostup, eluch)
            Else
                paruch = New LeseSreib.sw_ParamuchBdSowmest(Guid.Empty, idostup, eluch)
                ReDim Preserve wMassGuid(TekIndexUch)
                wMassGuid(TekIndexUch) = paruch.UidUch
            End If
            paruch.DataSohrProf()
            Try
                paruch.update()
            Catch ex As Exception
                MsgBox(Me.ToString & " SchreibeTrassWSowmest Не удалось создать запись о участке " & ex.Message)
                Return False
            End Try

            Dim dannUchastka As New LeseSreib.sw_UchWBdSowmest(CType(eluch, modRasstOp.wlUch), paruch, idostup)
            If dannUchastka.ProfilwBDNewGuid() Then
                TekIndexUch += 1
            End If
            '     dannUchastka.RasstanowkuWBD()


        Next
        Save()
        Return True
    End Function

    'Sub New(iMassGuid() As Guid)
    '    wMassGuid = iMassGuid
    'End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()


    End Sub
End Class
