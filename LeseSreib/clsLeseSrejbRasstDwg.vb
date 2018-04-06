Option Strict On
Option Explicit On

Imports BazDwg
Imports clsPrf
Imports modRasstOp
Imports LeseSreib.clsSwExel
''' <summary>
''' класс обеспечивающий сохранение считанной модели в словаре чертежа
''' </summary>
''' <remarks></remarks>
Public Class clsLeseSrejbRasstDwg
    Const wStrGuidDef As String = "9939BFF2-610E-4E37-9776-851C79C9F270"
    Const ZapIdentDan As String = "ZapidentDann" ' Запись о идентифицирующие участки хранящиеся в чертеже(нименование участков)
    Const ZapGuidUch As String = "ZapGuidUch"    'Запись в строковом представление глобальных идентификаторов
    Const ZapShirinProfil As String = "ZapShirinProfil"
    Const ZapIdentIzmen As String = "ZapIdentIzmen"  'запись храняться данные кто что изменил
    Const ZapOLinii As String = "ZapOLinii"
    '  Const KorSlDann As String = "Uch"   ' korenъ для формирования имени словаря в котором храняться данные 
    Const SufRazm As String = "MaxNum"
    Private wTrassa As clsTrass
    Private wRasst As wlRasst
    Private wKorenSlowar As String        'GlobParam.KorSlDann корень имени словарей в которых храниться данные о профиле и расстановки , 
    Private GlSl As dwgSlowar
    Private wStrsIdent() As String

    Private snumUch(), sGuidUch(), sShirina() As String
    Private wKlwUchZap As Integer
    ''' <summary>
    ''' создает объект для операций с данными профиля и расстановки хранящихся в солварях чертежа
    ''' </summary>
    ''' <param name="iNameKorenSlowaUch"> корень слова=названия словаря участка  </param>
    ''' <param name="iRasst"> профиль и расстановка </param>
    ''' <remarks></remarks>
    Sub New(ByVal iNameKorenSlowaUch As String, ByVal iRasst As wlRasst)
        wKorenSlowar = iNameKorenSlowaUch
        wRasst = iRasst
        Try
            wTrassa = CType(iRasst.Trassa, clsTrass)
        Catch ex As Exception
            wTrassa = Nothing
        End Try

        GlSl = New dwgSlowar(wKorenSlowar)
        wStrsIdent = GlSl.ZapisIzSlovarStr(ZapIdentIzmen)
        If wStrsIdent Is Nothing Then
            ReDim wStrsIdent(modRasstOp.IdentSohranenij.Maxnum)
        Else
            If wStrsIdent.Length <= modRasstOp.IdentSohranenij.Maxnum Then
                ReDim Preserve wStrsIdent(modRasstOp.IdentSohranenij.Maxnum)
            End If
        End If
    End Sub
    Private Sub ZapisGrupDann(ByVal lNameslwDann As String, ByVal KorZap As String, ByVal CollStr As Collection)
        Dim Slw As New dwgSlowarMas(lNameslwDann, KorZap)
        ' Dim Klwzap As Integer = UchPrfExel.UchWL.MaxNumPiket

        Dim mas(0) As String
        mas(0) = CStr(CollStr.Count - 1)
        Slw.ZapisW_SlowarStr(KorZap & SufRazm, mas)
        Slw.Collection_W_Slowar(CollStr)  'UchPrfExel.UchWL.GetStrPredPik()

    End Sub
    Private Sub ZapisOSostaweRasst_Slw(ByVal w As Collection)


        ReDim snumUch(w.Count), sGuidUch(w.Count), sShirina(w.Count)

        If Not w Is Nothing Then

            Dim wr As modRasstOp.wlUch
            Dim I As Integer = 0
            For Each wr In w
                Dim NameSlwDann As String = wKorenSlowar & I

                I += 1
                snumUch(I) = wr.NameUch
                sGuidUch(I) = wr.UidUch.ToString
                sShirina(I) = CStr(wr.ShirinaPofil)
                wr.dsProfil.AcceptChanges()
                wr.DannElemRasstUch.DataSet.AcceptChanges()
                wr.DsRasst.AcceptChanges()
            Next

            '       Application.ShowAlertDialog("ZagruzkaTrRasstW_SlwIzExcel данные о трассе и расстановки загружены в словари ")

            snumUch(0) = CStr(w.Count - 1)
            sGuidUch(0) = snumUch(0)
            GlSl.ZapisW_SlowarStr(ZapIdentDan, snumUch) 'записываем наименовние участков
            GlSl.ZapisW_SlowarStr(ZapGuidUch, sGuidUch)  'записываем GUId участков  
            GlSl.ZapisW_SlowarStr(ZapShirinProfil, sShirina)
        End If
    End Sub
    Private Sub ZapisTrRasstW_Slw(ByVal w As Collection)


        ReDim snumUch(w.Count), sGuidUch(w.Count), sShirina(w.Count)

        If Not w Is Nothing Then

            Dim wr As modRasstOp.wlUch
            Dim I As Integer = 0
            For Each wr In w
                Dim NameSlwDann As String = wKorenSlowar & I
                'записывем пикеты

                ZapisGrupDann(NameSlwDann, LeseSreib.clsSwExel.sProfil, wr.UchTr.GetStrPredPik())
                'записываем Угодия
                ZapisGrupDann(NameSlwDann, LeseSreib.clsSwExel.sPiketUgod, wr.UchTr.GetStrPredUgod())

                'записываем климат
                ZapisGrupDann(NameSlwDann, LeseSreib.clsSwExel.sKlimat, wr.UchTr.GetStrPredKlim())
                'записываем данные о элементах
                'провода
                ZapisGrupDann(NameSlwDann, LeseSreib.clsSwExel.sTprovod, wr.GetProvodUch())
                'типы опор
                ZapisGrupDann(NameSlwDann, LeseSreib.clsSwExel.sTopor, wr.GetOporUch())
                'типы гирлянд
                ZapisGrupDann(NameSlwDann, LeseSreib.clsSwExel.sTGirlajnd, wr.GetGirlajndUch())
                'Расстановка
                'записываем opohs
                ZapisGrupDann(NameSlwDann, LeseSreib.clsSwExel.srastOp, wr.GetStrPred())
                'записываем умалчиваемые параметры
                ZapisGrupDann(NameSlwDann, LeseSreib.clsSwExel.sParamUch, wr.GetStrPredParam())
                ZapisGrupDann(NameSlwDann, LeseSreib.clsSwExel.sMechUsl, wr.GetStrPredMechUsl)
                '  acDoc.Editor.WriteMessage(wr.NameUch & "  добавлен в словарь " & vbCrLf)
                I += 1
                snumUch(I) = wr.NameUch
                sGuidUch(I) = wr.UidUch.ToString
                sShirina(I) = CStr(wr.ShirinaPofil)
                wr.dsProfil.AcceptChanges()
                wr.DannElemRasstUch.DataSet.AcceptChanges()
                wr.DsRasst.AcceptChanges()
            Next

            '       Application.ShowAlertDialog("ZagruzkaTrRasstW_SlwIzExcel данные о трассе и расстановки загружены в словари ")

            snumUch(0) = CStr(w.Count - 1)
            sGuidUch(0) = snumUch(0)
            GlSl.ZapisW_SlowarStr(ZapIdentDan, snumUch) 'записываем наименовние участков
            GlSl.ZapisW_SlowarStr(ZapGuidUch, sGuidUch)  'записываем GUId участков  
            GlSl.ZapisW_SlowarStr(ZapShirinProfil, sShirina)
        End If
    End Sub
    Private Sub ZapisTrW_Slw(ByVal w As Collection)


        ReDim snumUch(w.Count), sGuidUch(w.Count), sShirina(w.Count)

        If Not w Is Nothing Then

            Dim wr As modRasstOp.wlUch
            Dim I As Integer = 0
            For Each wr In w
                Dim NameSlwDann As String = wKorenSlowar & I
                'записывем пикеты

                ZapisGrupDann(NameSlwDann, LeseSreib.clsSwExel.sProfil, wr.UchTr.GetStrPredPik())
                'записываем Угодия
                ZapisGrupDann(NameSlwDann, LeseSreib.clsSwExel.sPiketUgod, wr.UchTr.GetStrPredUgod())

                'записываем климат
                ZapisGrupDann(NameSlwDann, LeseSreib.clsSwExel.sKlimat, wr.UchTr.GetStrPredKlim())
                ''записываем данные о элементах
                ''провода
                'ZapisGrupDann(NameSlwDann, LeseSreib.clsSwExel.sTprovod, wr.GetProvodUch())
                ''типы опор
                'ZapisGrupDann(NameSlwDann, LeseSreib.clsSwExel.sTopor, wr.GetOporUch())
                ''типы гирлянд
                'ZapisGrupDann(NameSlwDann, LeseSreib.clsSwExel.sTGirlajnd, wr.GetGirlajndUch())
                ''Расстановка
                ''записываем opohs
                'ZapisGrupDann(NameSlwDann, LeseSreib.clsSwExel.srastOp, wr.GetStrPred())
                ''записываем умалчиваемые параметры
                'ZapisGrupDann(NameSlwDann, LeseSreib.clsSwExel.sParamUch, wr.GetStrPredParam())
                'ZapisGrupDann(NameSlwDann, LeseSreib.clsSwExel.sMechUsl, wr.GetStrPredMechUsl)
                ''  acDoc.Editor.WriteMessage(wr.NameUch & "  добавлен в словарь " & vbCrLf)
                I += 1
                snumUch(I) = wr.NameUch
                sGuidUch(I) = wr.UidUch.ToString
                sShirina(I) = CStr(wr.ShirinaPofil)
                wr.dsProfil.AcceptChanges()
            Next

            '       Application.ShowAlertDialog("ZagruzkaTrRasstW_SlwIzExcel данные о трассе и расстановки загружены в словари ")

            snumUch(0) = CStr(w.Count - 1)
            sGuidUch(0) = snumUch(0)
            GlSl.ZapisW_SlowarStr(ZapIdentDan, snumUch) 'записываем наименовние участков
            GlSl.ZapisW_SlowarStr(ZapGuidUch, sGuidUch)  'записываем GUId участков  
            GlSl.ZapisW_SlowarStr(ZapShirinProfil, sShirina)
        End If
    End Sub
    Private Sub ZapisRasstW_Slw(ByVal w As Collection)


        IzwlechIdentInfo()
        If wKlwUchZap < 0 Then
            MsgBox("ZapisRasstW_Slw данные о профиле не представлены в чертеже словаре " & wKorenSlowar)
            Return
        End If
        If wKlwUchZap <> w.Count - 1 Then
            MsgBox("количество участков профиля " & wKlwUchZap & " не совпадает с количеством участков расстановки " & w.Count - 1)
            Return
        End If
        If Not w Is Nothing Then

            Dim wr As modRasstOp.wlUch
            Dim I As Integer = 0
            For Each wr In w
                If wr.UidUch.ToString <> sGuidUch(I + 1) Or wr.NameUch <> snumUch(I + 1) Then
                    MsgBox("Идентификаторы расстановки Имя " & wr.NameUch & " или Guid  " & wr.UidUch.ToString & vbCr _
                           & " Не соответствует идентификаторам профиля имя " & snumUch(I + 1) & "или Guid  " & sGuidUch(I + 1))
                    Continue For
                End If
                Dim NameSlwDann As String = wKorenSlowar & I
                'записывем пикеты

                'ZapisGrupDann(NameSlwDann, LeseSreib.clsSwExel.sProfil, wr.UchTr.GetStrPredPik())
                ''записываем Угодия
                'ZapisGrupDann(NameSlwDann, LeseSreib.clsSwExel.sPiketUgod, wr.UchTr.GetStrPredUgod())

                ''записываем климат
                'ZapisGrupDann(NameSlwDann, LeseSreib.clsSwExel.sKlimat, wr.UchTr.GetStrPredKlim())
                'записываем данные о элементах
                'провода
                ZapisGrupDann(NameSlwDann, LeseSreib.clsSwExel.sTprovod, wr.GetProvodUch())
                'типы опор
                ZapisGrupDann(NameSlwDann, LeseSreib.clsSwExel.sTopor, wr.GetOporUch())
                'типы гирлянд
                ZapisGrupDann(NameSlwDann, LeseSreib.clsSwExel.sTGirlajnd, wr.GetGirlajndUch())
                'Расстановка
                'записываем opohs
                ZapisGrupDann(NameSlwDann, LeseSreib.clsSwExel.srastOp, wr.GetStrPred())
                'записываем умалчиваемые параметры
                ZapisGrupDann(NameSlwDann, LeseSreib.clsSwExel.sParamUch, wr.GetStrPredParam())
                ZapisGrupDann(NameSlwDann, LeseSreib.clsSwExel.sMechUsl, wr.GetStrPredMechUsl)
                '  acDoc.Editor.WriteMessage(wr.NameUch & "  добавлен в словарь " & vbCrLf)
                I += 1
                'snumUch(I) = wr.NameUch
                'sGuidUch(I) = wr.NameIdent
                'sShirina(I) = CStr(wr.ShirinaPofil)
                wr.DannElemRasstUch.DataSet.AcceptChanges()
                wr.DsRasst.AcceptChanges()
            Next

            '       Application.ShowAlertDialog("ZagruzkaTrRasstW_SlwIzExcel данные о трассе и расстановки загружены в словари ")

            'snumUch(0) = CStr(w.Count - 1)
            'sGuidUch(0) = snumUch(0)
            'GlSl.ZapisW_SlowarStr(ZapIdentDan, snumUch) 'записываем наименовние участков
            'GlSl.ZapisW_SlowarStr(ZapGuidUch, sGuidUch)  'записываем GUId участков  
            'GlSl.ZapisW_SlowarStr(ZapShirinProfil, sShirina)

        End If
    End Sub
    ''' <summary>
    ''' Сохранение данных о составе трассы и расстановке и идентификаторов участков.
    ''' </summary>
    ''' <remarks></remarks>
    Sub SaveOSostave()
        If wRasst Is Nothing Then
            SystemKommand.Soob(Me.ToString & " Save Математической модели расстановки нет в чертеже  ")
            Return
        End If
        SaveOlinii()
        ZapisOSostaweRasst_Slw(wTrassa.Uchastki())
        wStrsIdent(IdentSohranenij.pPolzSohr) = My.User.Name
        wStrsIdent(IdentSohranenij.pDataSohr) = CStr(Now)
        wStrsIdent(IdentSohranenij.rPolzSohr) = My.User.Name
        wStrsIdent(IdentSohranenij.rDataSohr) = CStr(Now)
        GlSl.ZapisW_SlowarStr(ZapIdentIzmen, wStrsIdent)
    End Sub
    ''' <summary>
    '''  сохранение всей модели и данных о времени и пользователях последних изменений
    ''' </summary>
    ''' <remarks></remarks>
    Sub Save()
        If wRasst Is Nothing Then
            SystemKommand.Soob(Me.ToString & " Save Математической модели расстановки нет в чертеже  ")
            Return
        End If
        SaveOlinii()
        ZapisTrRasstW_Slw(wTrassa.Uchastki())
        wStrsIdent(IdentSohranenij.pPolzSohr) = My.User.Name
        wStrsIdent(IdentSohranenij.pDataSohr) = CStr(Now)
        wStrsIdent(IdentSohranenij.rPolzSohr) = My.User.Name
        wStrsIdent(IdentSohranenij.rDataSohr) = CStr(Now)
        GlSl.ZapisW_SlowarStr(ZapIdentIzmen, wStrsIdent)
    End Sub
    ''' <summary>
    ''' сохранени модели трассы 
    ''' </summary>
    ''' <remarks></remarks>
    Sub SaveTr()
        If wRasst Is Nothing Then
            SystemKommand.Soob(Me.ToString & " SaveTr Математической модели расстановки нет в чертеже  ")
            Return
        End If
        SaveOlinii()
        ZapisTrW_Slw(wTrassa.Uchastki())
        wStrsIdent(IdentSohranenij.pPolzSohr) = My.User.Name
        wStrsIdent(IdentSohranenij.pDataSohr) = CStr(Now)
        GlSl.ZapisW_SlowarStr(ZapIdentIzmen, wStrsIdent)
    End Sub
    Private Sub SaveOlinii()
        Dim lstr(2) As String
        lstr(0) = wTrassa.NameLin
        lstr(1) = CStr(wTrassa.Unom)
        lstr(2) = CStr(wTrassa.NameRab)
        GlSl.ZapisW_SlowarStr(ZapOLinii, lstr)
    End Sub
    ''' <summary>
    ''' сохранени модели только расстановки 
    ''' </summary>
    ''' <remarks></remarks>
    Sub SaveRasst()
        ZapisRasstW_Slw(wTrassa.Uchastki())
        wStrsIdent(IdentSohranenij.rPolzSohr) = My.User.Name
        wStrsIdent(IdentSohranenij.rDataSohr) = CStr(Now)
        GlSl.ZapisW_SlowarStr(ZapIdentIzmen, wStrsIdent)
    End Sub
    Private Function ChitatGrupDann(ByVal lNameSlwDan As String, ByVal Korzap As String) As Collection
        Dim Slw As New dwgSlowarMas(lNameSlwDan, Korzap)
        Dim MaxNum As Integer
        Try
            MaxNum = CInt(Slw.ZapisIzSlovarStr(Korzap & SufRazm)(0))
        Catch ex As InvalidCastException
            MaxNum = -1
        Catch ex As Exception
            MaxNum = -1


        End Try



        Dim wrCollStr As Collection = Slw.CollectionIsSlowar(MaxNum)
        '     Application.ShowAlertDialog("ChitatGrupDannСчитано " & wrCollStr.Count & " " & Korzap)
        Return wrCollStr
    End Function
    Shared Sub IzwlechDannOLini(ByVal NameSl As String, ByRef NameWl As String, ByRef NameRab As String, ByRef Unom As Integer)
        Dim lSlw = New dwgSlowar(NameSl)
        Dim lstr() = lSlw.ZapisIzSlovarStr(ZapOLinii)
        Try
            NameWl = lstr(0)

        Catch ex As Exception
            NameWl = "IzwlechDannOLini"

        End Try


        Try
            Unom = CInt(lstr(1))
        Catch ex As Exception
            Unom = 750
        End Try

        Try
            NameRab = lstr(2)
        Catch ex As Exception
            NameRab = "IzwlechDannOLiniRabota"
        End Try
    End Sub
    Sub IzwlechIdentInfo()
        If wRasst Is Nothing Then
            SystemKommand.Soob(Me.ToString & " IzwlechIdentInfo SaveTr Математической модели расстановки нет в чертеже  ")
            Return
        End If

        snumUch = GlSl.ZapisIzSlovarStr(ZapIdentDan)
        sGuidUch = GlSl.ZapisIzSlovarStr(ZapGuidUch)
        sShirina = GlSl.ZapisIzSlovarStr(ZapShirinProfil)
        Try
            wKlwUchZap = CInt(snumUch(0))
        Catch ex As Exception
            ' Application.ShowAlertDialog("Operazii.ChitatTrRasstIzSlw    участок не представлен в бД Чертежа   " & acDoc.Name)
            BazDwg.SystemKommand.Soob("IzwlechIdentInfo    участок не представлен в Cловаре  " & wKorenSlowar)
            wKlwUchZap = -1
            Return
        End Try
    End Sub
    Function Izwlech() As Boolean

        IzwlechIdentInfo()

        If wKlwUchZap < 0 Then Return False


        Dim i As Integer = 0
        '   Dim wrCollStr As Collection
        For i = 0 To wKlwUchZap
            Dim lUiduch As Guid
            Try
                lUiduch = New Guid(sGuidUch(i + 1)) ' Вообщето извлекать из словарей guid нет необходимости?
            Catch ex As Exception
                lUiduch = Guid.Empty
            End Try

            Dim lwluch As New modRasstOp.wlUch(New Guid("9939BFF2-610E-4E37-9776-851C79C9F270")) 'участки читаем из словаря с пустым Guid'ом
            Dim wr As clsPrf.clsUchPrf = lwluch.UchTr
            Dim NameSlDan = wKorenSlowar & i

            Try
                wr.NameUch() = snumUch(i + 1)
            Catch ex As Exception
                wr.NameUch = "не задан"
            End Try

            Try
                wr.ShirinaPofil = CDbl(sShirina(i + 1))
            Catch ex As Exception

            End Try
            'BazfunNet.SoobEditor("Считано пикетов  угодий" & wrCollStr.Count)
            '  LeseSreib.clsSwExel.

            wr.SetPoStrPred(ChitatGrupDann(NameSlDan, LeseSreib.clsSwExel.sProfil), ChitatGrupDann(NameSlDan, sKlimat), _
            ChitatGrupDann(NameSlDan, sPiketUgod))
            lwluch.SetElemRasstUch(ChitatGrupDann(NameSlDan, LeseSreib.clsSwExel.sTprovod), ChitatGrupDann(NameSlDan, LeseSreib.clsSwExel.sTopor), _
                                    ChitatGrupDann(NameSlDan, LeseSreib.clsSwExel.sTGirlajnd))
            lwluch.SetPoStrPred(ChitatGrupDann(NameSlDan, sParamUch), ChitatGrupDann(NameSlDan, sMechUsl), _
                                                                                                         ChitatGrupDann(NameSlDan, srastOp))



            wTrassa.DobUch(wr)
            'If wr.BegUch.DataRowPiket.RowState <> DataRowState.Added Then
            '    MsgBox(Me.ToString & "  " & wr.BegUch.DataRowPiket.RowState)
            'End If

        Next
        wRasst.OprRast()
        wRasst.Trassa.DataSohr = wStrsIdent(IdentSohranenij.pDataSohr)
        wRasst.Trassa.PolzSohr = wStrsIdent(IdentSohranenij.pPolzSohr)
        wRasst.DataSohr = wStrsIdent(IdentSohranenij.rDataSohr)
        wRasst.PolzSohr = wStrsIdent(IdentSohranenij.rPolzSohr)

        Return True
    End Function
    ReadOnly Property Rasst() As wlRasst
        Get
            Return wRasst
        End Get
    End Property

End Class
