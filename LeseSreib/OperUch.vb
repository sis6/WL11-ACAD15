Option Explicit On
Option Strict Off

Imports modRasstOp

Public Module OperUch
  
    'Private Sub RazdelenieZon(ByVal iTabl As DataTable, ByVal iPikGr As Double, ByRef irowsDo As DataRow(), ByRef irowsposle As DataRow())

    '    Dim lEstNachalo As Boolean = False
    '    irowsDo = iTabl.Select("Piketaj < '" & CStr(iPikGr) & "'", "Piketaj") ' нашли записи с пикетажем меньше граничного 
    '    Dim lcountDo = irowsDo.Length
    '    '   If lcountDo > 0 Then elPred = irowsDo(lcountDo - 1) 'нашли ближайшую к PikB, но с меньшим пикетажом если она есть 

    '    irowsposle = iTabl.Select("Piketaj >= '" & CStr(iPikGr) & "'", "Piketaj DESC") 'нашли записи с пиетажем большим или равным начальному


    'End Sub
    'Private Sub WidelenieZon(ByVal iTabl As DataTable, ByVal PikB As Double, ByVal PikE As Double)
    '    Dim elPred As DataRow = Nothing
    '    Dim lEstNachalo As Boolean = False
    '    Dim lRowsDo As DataRow() = iTabl.Select("Piketaj < '" & CStr(PikB) & "'", "Piketaj") ' нашли записи с пикетажем меньше начального 
    '    Dim lcountDo = lRowsDo.Length
    '    If lcountDo > 0 Then elPred = lRowsDo(lcountDo - 1) 'нашли ближайшую к PikB, но с меньшим пикетажом если она есть 

    '    Dim lrowsPosle As DataRow() = iTabl.Select("Piketaj >= '" & CStr(PikB) & "'", "Piketaj") 'нашли записи с пиетажем большим или равным начальному
    '    Dim lcountPosle As Integer = lrowsPosle.Length

    '    If lcountPosle > 0 Then

    '        If clsPrf.clsPiket.Sraw(lrowsPosle(0)("Piketaj"), PikB) = 0 Then
    '            lEstNachalo = True
    '        End If
    '    End If


    '    For i As Integer = 0 To lcountDo - 1 '
    '        lRowsDo(i).Delete()
    '    Next
    '    For i As Integer = 0 To lcountPosle - 1
    '        Dim el As DataRow = lrowsPosle(i)
    '        If clsPrf.clsPiket.Sraw(el("Piketaj"), PikE) >= 0 Then
    '            el.Delete()
    '        End If
    '    Next


    '    If lEstNachalo = False And lcountDo > 0 Then
    '        elPred.RejectChanges()

    '        elPred("piketaj") = PikB
    '    End If

    '    iTabl.AcceptChanges()
    'End Sub
    'Private Sub SdwinutZon(ByVal iTabl As DataTable, ByVal PikB As Double, ByVal Sdwig As Double)
    '    Dim elPred As DataRow = Nothing


    '    Dim lrowsPosle As DataRow() = iTabl.Select("Piketaj >= '" & CStr(PikB) & "'", "Piketaj") 'нашли записи с пиетажем большим или равным начальному
    '    Dim lcountPosle As Integer = lrowsPosle.Length


    '    For i As Integer = 0 To lcountPosle - 1
    '        lrowsPosle(i)("piketaj") += Sdwig
    '    Next




    '    iTabl.AcceptChanges()
    'End Sub
    'Private Function Widelit(ByVal iUch As modRasstOp.wlUch, ByVal PikB As Double, ByVal PikE As Double) As modRasstOp.wlUch
    '    Dim lDsPrf As OperBD.DsProfil = iUch.DsProfil
    '    Dim lDsRast As OperBD.dsRasst = iUch.DsRasst

    '    lDsPrf.AcceptChanges()  'зачем 
    '    lDsRast.AcceptChanges() 'ведь потом могут неотразиться в Бд предшествующие изменения

    '    Dim lRowsDo As OperBD.DsProfil.ProfilARow() = lDsPrf.ProfilA.Select("Piketaj < '" & CStr(PikB) & "'", "Piketaj") ' нашли записи с пикетажем меньше начального 
    '    Dim lcountDo = lRowsDo.Length
    '    '  Dim elpred As OperBD.DsProfil.ProfilARow
    '    '    If lcountDo > 0 Then elPred = lRowsDo(lcountDo - 1) 'нашли ближайшую к PikB, но с меньшим пикетажом если она есть 
    '    Dim lrowsPosle As OperBD.DsProfil.ProfilARow() = lDsPrf.ProfilA.Select("Piketaj >= '" & CStr(PikB) & "'", "Piketaj") 'нашли записи с пиетажем большим или равным начальному
    '    Dim lcountPosle As Integer = lrowsPosle.Length
    '    If lcountPosle > 0 Then PikB = lrowsPosle(0).Piketaj
    '    For i As Integer = 0 To lcountDo - 1
    '        lRowsDo(i).Delete()
    '    Next
    '    '     Dim ell As OperBD.DsProfil.ProfilARow = lDsPrf.ProfilA.NewProfilARow()
    '    For I As Integer = 0 To lcountPosle - 1
    '        Dim el As OperBD.DsProfil.ProfilARow = lrowsPosle(I)

    '        If el.Piketaj > PikE Then
    '            el.Delete()
    '        End If
    '    Next
    '    lDsPrf.ProfilA.AcceptChanges()

    '    WidelenieZon(lDsPrf.TablKlimN, PikB, PikE)

    '    WidelenieZon(lDsPrf.PikUgodN, PikB, PikE)

    '    For I As Integer = 0 To lDsRast.rastOpN.Count - 1
    '        Dim el As OperBD.dsRasst.rastOpNRow = lDsRast.rastOpN(I)
    '        If el.Piketaj < PikB Or el.Piketaj > PikE Then
    '            el.Delete()
    '        End If
    '    Next
    '    lDsRast.rastOpN.AcceptChanges()

    '    WidelenieZon(lDsRast.MechUsl, PikB, PikE)
    '    Dim liZ_DS_Uch As New Sw_IzDs_Rasst(lDsPrf, lDsRast, CType(iUch, modRasstOp.wlUch).DannElemRasstUch.DataSet, iUch.NameUch & CInt(PikB) & " - " & CInt(PikE))
    '    '   liZ_DS_Uch.IzDsRasstanowku()
    '    Return liZ_DS_Uch.RasstNaUch
    'End Function
    '   Dim lrowsDo As DataRow(), lrowsPosle As DataRow()
    ' ''' <summary>
    ' ''' Разделяет заданый участок трассы на два по граничному пикету, Guid участков одинаковы 
    ' ''' </summary>
    ' ''' <param name="iUch"> заданый участок </param>
    ' ''' <param name="ipiket"> разганичивающий пикет </param>
    ' ''' <returns> возвращает массив из двух участков </returns>
    ' ''' <remarks></remarks>
    'Private Function RazdelitNaDwaUch(ByVal iUch As modRasstOp.wlUch, ByVal ipiket As clsPrf.clsPiket) As modRasstOp.wlUch() '
    '    Dim lrowsDo As DataRow(), lrowsPosle As DataRow()
    '    Dim luch(1) As modRasstOp.wlUch
    '    Dim lpikGr As Double = ipiket.Piketaj ' пикетаж граничного пикета
    '    Dim lDsPrf As OperBD.DsProfil = iUch.DsProfil
    '    Dim lDsRast As OperBD.dsRasst = iUch.DsRasst


    '    lDsPrf.AcceptChanges()
    '    lDsRast.AcceptChanges()

    '    lrowsDo = lDsPrf.ProfilA.Select("Piketaj <= '" & CStr(lpikGr + 0.5) & "'", "Piketaj") ' нашли записи с пикетажем меньше заданого 
    '    Dim lcountDo = lrowsDo.Length
    '    Dim elpred As OperBD.DsProfil.ProfilARow
    '    If lcountDo > 0 Then elpred = lrowsDo(lcountDo - 1) 'граничный пикет
    '    lrowsPosle = lDsPrf.ProfilA.Select("Piketaj >= '" & CStr(lpikGr - 0.5) & "'", "Piketaj") 'нашли записи с пиетажем большим или равным начальному
    '    Dim lcountPosle As Integer = lrowsPosle.Length


    '    luch(0) = New modRasstOp.wlUch(iUch.UidUch)
    '    luch(1) = New modRasstOp.wlUch(iUch.UidUch)
    '    luch(0).NameUch = iUch.NameUch
    '    luch(1).NameUch = iUch.NameUch & "п"

    '    'Добовляем в участки пикеты
    '    For Each el As OperBD.DsProfil.ProfilARow In lrowsDo ' добавляем в Do описание пикетов Прим??? граничный пикет должен входить в оба участка
    '        luch(0).DsProfil.ProfilA.ImportRow(el)

    '    Next
    '    '  luch(0).SetPiket()
    '    For Each el As OperBD.DsProfil.ProfilARow In lrowsPosle ' добавляем в Posle описание пикетов
    '        luch(1).DsProfil.ProfilA.ImportRow(el)
    '    Next

    '    'Добовляем в участки климат
    '    RazdelenieZon(lDsPrf.TablKlimN, lpikGr, lrowsDo, lrowsPosle)

    '    For Each el As OperBD.DsProfil.TablKlimNRow In lrowsDo
    '        luch(0).DsProfil.TablKlimN.ImportRow(el)
    '    Next

    '    For Each el As OperBD.DsProfil.TablKlimNRow In lrowsPosle
    '        luch(1).DsProfil.TablKlimN.ImportRow(el)
    '    Next

    '    'Добовляем в участки piketaж угодий 
    '    RazdelenieZon(lDsPrf.PikUgodN, lpikGr, lrowsDo, lrowsPosle)
    '    For Each el As OperBD.DsProfil.PikUgodNRow In lrowsDo
    '        luch(0).DsProfil.PikUgodN.ImportRow(el)
    '    Next

    '    For Each el As OperBD.DsProfil.PikUgodNRow In lrowsPosle
    '        luch(1).DsProfil.PikUgodN.ImportRow(el)
    '    Next

    '    luch(0).SozdatPoDataSet()
    '    luch(1).SozdatPoDataSet()

    '    'If luch(1).BegKlimZon IsNot Nothing Then
    '    '    MsgBox("OperUch:Widelit " & "  ВегКлим до  " & luch(1).BegKlimZon.Piketaj & " BegUch " & luch(1).BegUch.Piketaj)
    '    'End If

    '    luch(0).SetElemRasstUch(iUch.DannElemRasstUch.DataSet)
    '    luch(1).SetElemRasstUch(iUch.DannElemRasstUch.DataSet)
    '    If lDsRast.ParamUchN.Count > 0 Then
    '        luch(0).DsRasst.ParamUchN.ImportRow(iUch.DsRasst.ParamUchN.Rows(0))
    '        luch(1).DsRasst.ParamUchN.ImportRow(iUch.DsRasst.ParamUchN.Rows(0))
    '    End If
    '    luch(0).UstParam()
    '    luch(1).UstParam()
    '    '     MsgBox("OperUch:Widelit " & " параметров участка 1 " & luch(1).DsRasst.ParamUchN.Rows.Count)

    '    For I As Integer = 0 To lDsRast.rastOpN.Count - 1     'опоры
    '        Dim el As OperBD.dsRasst.rastOpNRow = lDsRast.rastOpN(I)
    '        If el.Piketaj <= lpikGr Then
    '            luch(0).DsRasst.rastOpN.ImportRow(el)
    '            luch(0).DobOp(New wlOpRasst(el, luch(0)))
    '        Else
    '            luch(1).DsRasst.rastOpN.ImportRow(el)
    '            luch(1).DobOp(New wlOpRasst(el, luch(1)))
    '        End If
    '    Next

    '    RazdelenieZon(lDsRast.MechUsl, lpikGr, lrowsDo, lrowsPosle)

    '    For Each el As OperBD.dsRasst.MechUslRow In lrowsDo
    '        luch(0).DsRasst.MechUsl.ImportRow(el)
    '        luch(0).Dob(New modRasstOp.DannZonMechusl(el, luch(0)))
    '    Next

    '    For Each el As OperBD.dsRasst.MechUslRow In lrowsPosle
    '        luch(1).DsRasst.MechUsl.ImportRow(el)
    '        luch(1).Dob(New modRasstOp.DannZonMechusl(el, luch(1)))
    '    Next


    '    'lDsRastDo.ParamUchN.AddParamUchNRow(lDsRastDo.ParamUchN(0))


    '    Return luch
    'End Function
    'Public Function Sdwinut(ByVal iUch As modRasstOp.wlUch, ByVal PikB As Double, ByVal Sdwig As Double) As modRasstOp.wlUch
    '    Dim lDsPrf As OperBD.DsProfil = iUch.DsProfil
    '    Dim lDsRast As OperBD.dsRasst = iUch.DsRasst

    '    lDsPrf.AcceptChanges()
    '    lDsRast.AcceptChanges()

    '    Dim lRowsDo As OperBD.DsProfil.ProfilARow() = lDsPrf.ProfilA.Select("Piketaj < '" & CStr(PikB) & "'", "Piketaj DESC") ' нашли записи с пикетажем меньше начального 
    '    Dim lcountDo = lRowsDo.Length

    '    Dim elpred As OperBD.DsProfil.ProfilARow
    '    If lcountDo > 0 Then elpred = lRowsDo(lcountDo - 1) 'нашли ближайшую к PikB, но с меньшим пикетажом если она есть 
    '    Dim lrowsPosle As OperBD.DsProfil.ProfilARow() = lDsPrf.ProfilA.Select("Piketaj >= '" & CStr(PikB) & "'", "Piketaj") 'нашли записи с пиетажем большим или равным начальному
    '    Dim lcountPosle As Integer = lrowsPosle.Length
    '    If lcountPosle > 0 Then PikB = lrowsPosle(0).Piketaj

    '    For I As Integer = 0 To lcountPosle - 1
    '        Dim el As OperBD.DsProfil.ProfilARow = lrowsPosle(I)
    '        el.Piketaj += Sdwig

    '    Next
    '    lDsPrf.ProfilA.AcceptChanges()

    '    SdwinutZon(lDsPrf.TablKlimN, PikB, Sdwig)

    '    SdwinutZon(lDsPrf.PikUgodN, PikB, Sdwig)

    '    For I As Integer = 0 To lDsRast.rastOpN.Count - 1
    '        Dim el As OperBD.dsRasst.rastOpNRow = lDsRast.rastOpN(I)
    '        If el.Piketaj >= PikB Then
    '            el.Piketaj += Sdwig
    '        End If
    '    Next
    '    lDsRast.rastOpN.AcceptChanges()

    '    SdwinutZon(lDsRast.MechUsl, PikB, Sdwig)
    '    Dim liZ_DS_Uch As New Sw_IzDs_Rasst(lDsPrf, lDsRast, CType(iUch, modRasstOp.wlUch).DannElemRasstUch.DataSet, iUch.NameUch & CInt(PikB) & " -sdwig " & CInt(Sdwig))
    '    '   liZ_DS_Uch.IzDsRasstanowku()
    '    Return liZ_DS_Uch.RasstNaUch
    'End Function
    Sub DobawitUch(ByVal KudaUch As modRasstOp.wlUch, ByVal ChtoUch As wlUch)
        Dim lDsPrf As OperBD.DsProfil = ChtoUch.dsProfil
        Dim lDsRast As OperBD.dsRasst = ChtoUch.DsRasst

        Dim sdwigPik As Double = 0
        Dim lNomerPerwogoPiketa As Integer = 0  'Если в участке цели отсутствуют пикеты, то копируем с начального пикета, в противном случае его пропускаем 
        If KudaUch.MaxNumPiket > 0 Then
            sdwigPik = KudaUch.EndUch.Piketaj - ChtoUch.BegUch.Piketaj
            lNomerPerwogoPiketa = 1
        End If
        Dim lnomerOp As Integer = 0
        Try

            If KudaUch.PoslOpor.NaKonzeUchastka And ChtoUch.PervOpor().NaNachaleUchastka Then lnomerOp = 1 'если один участок заканчиваеться опорой
            ' а другой начинаеться, то первую опору последующего не включаем 
        Catch ex As Exception

        End Try
        For I As Integer = lNomerPerwogoPiketa To lDsPrf.ProfilA.Count - 1   ' добавляем в uch  пикетs

            Dim el As OperBD.DsProfil.ProfilARow = lDsPrf.ProfilA(I)
            If el.RowState = DataRowState.Unchanged Then el.SetAdded()
            KudaUch.dsProfil.ProfilA.ImportRow(el)
            Dim elprow = KudaUch.dsProfil.ProfilA.FindByUIdTchk(el.UIdTchk)
            elprow.Piketaj += sdwigPik
            elprow.UIdTchk = Guid.NewGuid
            elprow.UIdUch = KudaUch.UidUch

        Next

        For Each el As OperBD.DsProfil.TablKlimNRow In lDsPrf.TablKlimN
            el.SetAdded()
            KudaUch.dsProfil.TablKlimN.ImportRow(el)
            Dim elprow = KudaUch.dsProfil.TablKlimN.FindByUIdKlim(el.UIdKlim)
            elprow.Piketaj += sdwigPik
            elprow.UIdKlim = Guid.NewGuid
            elprow.UIdUch = KudaUch.UidUch

        Next
        For Each el As OperBD.DsProfil.PikUgodNRow In lDsPrf.PikUgodN
            el.SetAdded()
            KudaUch.dsProfil.PikUgodN.ImportRow(el)
            Dim elprow = KudaUch.dsProfil.PikUgodN.FindByUIdUgod(el.UIdUgod)
            elprow.Piketaj += sdwigPik
            elprow.UIdUgod = Guid.NewGuid
            elprow.UidUch = KudaUch.UidUch
        Next

        KudaUch.SozdatPoDataSet()

        KudaUch.DannElemRasstUch.Objedin(ChtoUch.DannElemRasstUch.DataSet)
        '   MsgBox("OperUch::DobawitUch " & "posleSozdatObjedin")

        If KudaUch.DefParam Is Nothing Then
            If ChtoUch.DsRasst.ParamUchN.Rows.Count > 0 Then
                KudaUch.DsRasst.ParamUchN.ImportRow(ChtoUch.DsRasst.ParamUchN.Rows(0))
                Dim eldob = KudaUch.DsRasst.ParamUchN.FindByUIdUch(ChtoUch.UidUch)
                eldob.UIdUch = KudaUch.UidUch
            End If
            KudaUch.UstParam()
        End If

        For i As Integer = lnomerOp To lDsRast.rastOpN.Count - 1     'опоры
            Dim el As OperBD.dsRasst.rastOpNRow = lDsRast.rastOpN(i)
            el.SetAdded()
            KudaUch.DsRasst.rastOpN.ImportRow(el)
            Dim eldob = KudaUch.DsRasst.rastOpN.FindByUIdRast(el.UIdRast)
            If KudaUch.Opori.Contains(el.NumName) Then
                eldob.NumName = KudaUch.DopustimoeImj(el.NumName)
            End If

            eldob.Piketaj += sdwigPik
            eldob.UIdUch = KudaUch.UidUch
            eldob.UIdRast = Guid.NewGuid
            KudaUch.DobOp(New wlOpRasst(eldob, KudaUch))
        Next
        For Each el As OperBD.dsRasst.MechUslRow In lDsRast.MechUsl
            el.SetAdded()
            KudaUch.DsRasst.MechUsl.ImportRow(el)
            Dim eldob = KudaUch.DsRasst.MechUsl.FindByUIndtaj(el.UIndtaj)
            eldob.Piketaj += sdwigPik
            eldob.UidUch = KudaUch.UidUch
            eldob.UIndtaj = Guid.NewGuid
            KudaUch.Dob(New modRasstOp.DannZonMechusl(eldob, KudaUch))
        Next


    End Sub
    Sub DobawitUchPered(ByVal KudaUch As modRasstOp.wlUch, ByVal ChtoUch As wlUch)
        Dim lDsPrf As OperBD.DsProfil = ChtoUch.dsProfil
        Dim lDsRast As OperBD.dsRasst = ChtoUch.DsRasst

        Dim sdwigPik As Double = KudaUch.BegUch.Piketaj - ChtoUch.EndUch.Piketaj


        Dim lnomerOp As Integer = ChtoUch.Count - 1
        Try

            If KudaUch.PervOpor.NaNachaleUchastka And ChtoUch.PoslOpor().NaKonzeUchastka Then lnomerOp -= 1 'если один участок заканчиваеться опорой
            ' а другой начинаеться, то первую опору последующего не включаем 
        Catch ex As Exception

        End Try
        For I As Integer = 0 To lDsPrf.ProfilA.Count - 1   ' добавляем в uch  пикетs

            Dim el As OperBD.DsProfil.ProfilARow = lDsPrf.ProfilA(I)
            If el.RowState = DataRowState.Unchanged Then el.SetAdded()
            KudaUch.dsProfil.ProfilA.ImportRow(el)
            Dim elprow = KudaUch.dsProfil.ProfilA.FindByUIdTchk(el.UIdTchk)
            elprow.Piketaj += sdwigPik
            elprow.UIdTchk = Guid.NewGuid
            elprow.UIdUch = KudaUch.UidUch

        Next

        For Each el As OperBD.DsProfil.TablKlimNRow In lDsPrf.TablKlimN
            el.SetAdded()
            KudaUch.dsProfil.TablKlimN.ImportRow(el)
            Dim elprow = KudaUch.dsProfil.TablKlimN.FindByUIdKlim(el.UIdKlim)
            elprow.Piketaj += sdwigPik
            elprow.UIdKlim = Guid.NewGuid
            elprow.UIdUch = KudaUch.UidUch

        Next
        For Each el As OperBD.DsProfil.PikUgodNRow In lDsPrf.PikUgodN
            el.SetAdded()
            KudaUch.dsProfil.PikUgodN.ImportRow(el)
            Dim elprow = KudaUch.dsProfil.PikUgodN.FindByUIdUgod(el.UIdUgod)
            elprow.Piketaj += sdwigPik
            elprow.UIdUgod = Guid.NewGuid
            elprow.UidUch = KudaUch.UidUch
        Next

        KudaUch.SozdatPoDataSet()

        KudaUch.DannElemRasstUch.Objedin(ChtoUch.DannElemRasstUch.DataSet)
        '   MsgBox("OperUch::DobawitUch " & "posleSozdatObjedin")

        If KudaUch.DefParam Is Nothing Then
            If ChtoUch.DsRasst.ParamUchN.Rows.Count > 0 Then
                KudaUch.DsRasst.ParamUchN.ImportRow(ChtoUch.DsRasst.ParamUchN.Rows(0))
                Dim eldob = KudaUch.DsRasst.ParamUchN.FindByUIdUch(ChtoUch.UidUch)
                eldob.UIdUch = KudaUch.UidUch
            End If
            KudaUch.UstParam()
        End If

        For i As Integer = 0 To lDsRast.rastOpN.Count - 1     'опоры
            Dim el As OperBD.dsRasst.rastOpNRow = lDsRast.rastOpN(i)
            el.SetAdded()
            KudaUch.DsRasst.rastOpN.ImportRow(el)
            Dim eldob = KudaUch.DsRasst.rastOpN.FindByUIdRast(el.UIdRast)
            If KudaUch.Opori.Contains(el.NumName) Then
                eldob.NumName = KudaUch.DopustimoeImj(el.NumName)
            End If

            eldob.Piketaj += sdwigPik
            eldob.UIdUch = KudaUch.UidUch
            eldob.UIdRast = Guid.NewGuid
            KudaUch.DobOp(New wlOpRasst(eldob, KudaUch))
        Next
        For Each el As OperBD.dsRasst.MechUslRow In lDsRast.MechUsl
            el.SetAdded()
            KudaUch.DsRasst.MechUsl.ImportRow(el)
            Dim eldob = KudaUch.DsRasst.MechUsl.FindByUIndtaj(el.UIndtaj)
            eldob.Piketaj += sdwigPik
            eldob.UidUch = KudaUch.UidUch
            eldob.UIndtaj = Guid.NewGuid
            KudaUch.Dob(New modRasstOp.DannZonMechusl(eldob, KudaUch))
        Next

        Wirownajt(KudaUch)
    End Sub
    Private Sub Wirownajt(ByVal KudaUch As modRasstOp.wlUch)
        If KudaUch.PiketajBeg > 0 Then Return
        Dim lDsPrf As OperBD.DsProfil = KudaUch.dsProfil
        Dim lDsRast As OperBD.dsRasst = KudaUch.DsRasst


        Dim sdwigPik As Double = -KudaUch.PiketajBeg


        For Each el As OperBD.DsProfil.ProfilARow In lDsPrf.ProfilA   ' добавляем в uch  пикетs

            el.Piketaj += sdwigPik



        Next

        For Each el As OperBD.DsProfil.TablKlimNRow In lDsPrf.TablKlimN
            el.Piketaj += sdwigPik


        Next
        For Each el As OperBD.DsProfil.PikUgodNRow In lDsPrf.PikUgodN
            el.Piketaj += sdwigPik
        Next




        For Each el As OperBD.dsRasst.rastOpNRow In lDsRast.rastOpN     'опоры
            el.Piketaj += sdwigPik


        Next
        For Each el As OperBD.dsRasst.MechUslRow In lDsRast.MechUsl
            el.Piketaj += sdwigPik
        Next


        '  MsgBox("OperUch::DobawitUch " & "Sozdat")
    End Sub
  
End Module
