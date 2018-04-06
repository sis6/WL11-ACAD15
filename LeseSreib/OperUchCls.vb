Option Strict Off
Imports modRasstOp
Imports OperBD
Class DannUchastka
    Public ProfilARows() As OperBD.DsProfil.ProfilARow
    Public KlimatRows() As DsProfil.TablKlimNRow
    Public PiketUgodRows() As DsProfil.PikUgodNRow
    Public RastOpRows() As dsRasst.rastOpNRow
    Public MechUslRows() As dsRasst.MechUslRow

End Class
Public Enum ChastUchastka
    OtNachala = 0
    Mejdu = 1
    DoKonza = 2
End Enum
Public Class OperUchCls
    Private wOsnowUch As wlUch
    Private wDopolUch As wlUch
    Private wBegPiketaj, wEndPiketaj As Double
    Private wChastOtNachala, wChastMejdu, wChastDoKonza As New DannUchastka
    Private wMasChastej(2) As DannUchastka
    ''' <summary>
    ''' Coздает класс для операций с участками
    ''' </summary>
    ''' <param name="iOsnUch">  основной участок  </param>
    ''' <param name="iDop"> участок для вставки  </param>
    ''' <param name="iBegPiketaj"> начальный пикетаж выделение части основного участка </param>
    ''' <param name="iEndPiketaj"> конечный пикетаж выделения частей основного участка </param>
    ''' <remarks></remarks>
    Sub New(iOsnUch As wlUch, iDop As wlUch, iBegPiketaj As Double, iEndPiketaj As Double)
        If iBegPiketaj < iOsnUch.PiketajBeg Then wBegPiketaj = iOsnUch.PiketajBeg Else wBegPiketaj = iBegPiketaj
        If iEndPiketaj > iOsnUch.PiketajEnd Then wEndPiketaj = iOsnUch.PiketajEnd Else wEndPiketaj = iEndPiketaj
        wOsnowUch = iOsnUch
        wDopolUch = iDop
        wMasChastej(ChastUchastka.OtNachala) = wChastOtNachala : wMasChastej(ChastUchastka.Mejdu) = wChastMejdu : wMasChastej(ChastUchastka.DoKonza) = wChastDoKonza
    End Sub
    ''' <summary>
    ''' разделение таблиц по пикетажу
    ''' </summary>
    ''' <param name="iTabl"> исходная таблица </param>
    ''' <param name="iPikGr">  пикетаж разделения </param>
    ''' <param name="irowsDo">массив DataRow до точки разделения </param>
    ''' <param name="irowsposle"> массив DataRow после точки разделения  </param>
    ''' <remarks>  если есть запись с пикатажем равным точке разделения то входит в массив после </remarks>
    Shared Sub RazdelenieTabl(ByVal iTabl As DataTable, ByVal iPikGr As Double, ByRef irowsDo As DataRow(), ByRef irowsposle As DataRow())

        Dim lEstNachalo As Boolean = False
        irowsDo = iTabl.Select("Piketaj < '" & CStr(iPikGr) & "'", "Piketaj") ' нашли записи с пикетажем меньше граничного 
        Dim lcountDo = irowsDo.Length
        '   If lcountDo > 0 Then elPred = irowsDo(lcountDo - 1) 'нашли ближайшую к PikB, но с меньшим пикетажом если она есть 

        irowsposle = iTabl.Select("Piketaj >= '" & CStr(iPikGr) & "'", "Piketaj DESC") 'нашли записи с пиетажем большим или равным начальному



    End Sub
    Shared Function Widelit(ByVal iTabl As DataTable, ByVal iPiketajBeg As Double, iPiketajEnd As Double) As DataRow()
        Return iTabl.Select("Piketaj > '" & CStr(iPiketajBeg) & "'  And Piketaj <= '" & CStr(iPiketajEnd) & "'", "Piketaj")
    End Function
    Shared Function WidelitOtBeg(ByVal iTabl As DataTable, ByVal iPiketajGr As Double) As DataRow()
        Return iTabl.Select("Piketaj <= '" & CStr(iPiketajGr) & "'", "Piketaj")
    End Function
    Shared Function WidelitDoEnd(ByVal iTabl As DataTable, ByVal iPiketajGr As Double) As DataRow()
        Return iTabl.Select("Piketaj > '" & CStr(iPiketajGr) & "'", "Piketaj")
    End Function
    Private Sub RazdelitDan()
        With wChastOtNachala
            .ProfilARows = WidelitOtBeg(wOsnowUch.dsProfil.ProfilA, wBegPiketaj)
            .KlimatRows = WidelitOtBeg(wOsnowUch.dsProfil.TablKlimN, wBegPiketaj)
            .PiketUgodRows = WidelitOtBeg(wOsnowUch.dsProfil.PikUgodN, wBegPiketaj)
            .RastOpRows = WidelitOtBeg(wOsnowUch.DsRasst.rastOpN, wBegPiketaj)
            .MechUslRows = WidelitOtBeg(wOsnowUch.DsRasst.MechUsl, wBegPiketaj)
        End With
        With wChastMejdu
            .ProfilARows = Widelit(wOsnowUch.dsProfil.ProfilA, wBegPiketaj, wEndPiketaj)
            .KlimatRows = Widelit(wOsnowUch.dsProfil.TablKlimN, wBegPiketaj, wEndPiketaj)
            .PiketUgodRows = Widelit(wOsnowUch.dsProfil.PikUgodN, wBegPiketaj, wEndPiketaj)
            .RastOpRows = Widelit(wOsnowUch.DsRasst.rastOpN, wBegPiketaj, wEndPiketaj)
            .MechUslRows = Widelit(wOsnowUch.DsRasst.MechUsl, wBegPiketaj, wEndPiketaj)
        End With
        With wChastDoKonza
            .ProfilARows = WidelitDoEnd(wOsnowUch.dsProfil.ProfilA, wEndPiketaj)
            .KlimatRows = WidelitDoEnd(wOsnowUch.dsProfil.TablKlimN, wEndPiketaj)
            .PiketUgodRows = WidelitDoEnd(wOsnowUch.dsProfil.PikUgodN, wEndPiketaj)
            .RastOpRows = WidelitDoEnd(wOsnowUch.DsRasst.rastOpN, wEndPiketaj)
            .MechUslRows = WidelitDoEnd(wOsnowUch.DsRasst.MechUsl, wEndPiketaj)
        End With
    End Sub
    Public Function SozdatUchastok(Indeks As ChastUchastka) As wlUch
        RazdelitDan()
        Dim lDsProfil As New DsProfil, ldsRasst As New dsRasst, lElemUch As New ElemRasstUch
        Dim lDannuch As DannUchastka = wMasChastej(Indeks)
        For Each el As DsProfil.ProfilARow In lDannuch.ProfilARows
            lDsProfil.ProfilA.ImportRow(el)
            Dim elprow = lDsProfil.ProfilA.FindByUIdTchk(el.UIdTchk)
            elprow.UIdTchk = Guid.NewGuid
            elprow.UIdUch = Guid.Empty

        Next
        For Each el As DsProfil.TablKlimNRow In lDannuch.KlimatRows
            lDsProfil.TablKlimN.ImportRow(el)
            Dim elprow = lDsProfil.TablKlimN.FindByUIdKlim(el.UIdKlim)
            elprow.UIdKlim = Guid.NewGuid
            elprow.UIdUch = Guid.Empty
        Next
        For Each el As DsProfil.PikUgodNRow In lDannuch.PiketUgodRows
            lDsProfil.PikUgodN.ImportRow(el)
            Dim elprow = lDsProfil.PikUgodN.FindByUIdUgod(el.UIdUgod)
            elprow.UIdUgod = Guid.NewGuid
            elprow.UidUch = Guid.Empty
        Next
        'opor
        For Each el As dsRasst.rastOpNRow In lDannuch.RastOpRows
            ldsRasst.rastOpN.ImportRow(el)
            Dim elprow = ldsRasst.rastOpN.FindByUIdRast(el.UIdRast)
            elprow.UIdUch = Guid.Empty
            elprow.UIdRast = Guid.NewGuid

        Next
        'mech uslow
        For Each el As dsRasst.MechUslRow In lDannuch.MechUslRows
            ldsRasst.MechUsl.ImportRow(el)
            Dim elprow = ldsRasst.MechUsl.FindByUIndtaj(el.UIndtaj)
            elprow.UidUch = Guid.Empty
            elprow.UIndtaj = Guid.NewGuid

        Next
        ldsRasst.ParamUchN.ImportRow(wOsnowUch.DsRasst.ParamUchN.Rows(0))
        Dim elrowpar As dsRasst.ParamUchNRow = ldsRasst.ParamUchN.Rows(0)
        elrowpar.UIdUch = Guid.Empty

        For Each el As ElemRasstUch.oporIUchRow In wOsnowUch.DannElemRasstUch.DataSet.oporIUch
            lElemUch.oporIUch.ImportRow(el)
            Dim elrow As ElemRasstUch.oporIUchRow = lElemUch.oporIUch.Item(lElemUch.oporIUch.Count - 1)
            elrow.UidUch = Guid.Empty

        Next
        For Each el As ElemRasstUch.prowodaUchRow In wOsnowUch.DannElemRasstUch.DataSet.prowodaUch
            lElemUch.prowodaUch.ImportRow(el)
            Dim elrow As ElemRasstUch.prowodaUchRow = lElemUch.prowodaUch.Item(lElemUch.prowodaUch.Count - 1)
            elrow.UidUch = Guid.Empty

        Next
        For Each el As ElemRasstUch.GirjlanduchRow In wOsnowUch.DannElemRasstUch.DataSet.Girjlanduch
            lElemUch.Girjlanduch.ImportRow(el)
            Dim elrow As ElemRasstUch.GirjlanduchRow = lElemUch.Girjlanduch.Item(lElemUch.Girjlanduch.Count - 1)
            elrow.UidUch = Guid.Empty

        Next
        Dim lwlUch As New wlUch(lDsProfil, ldsRasst, lElemUch)

        Return lwlUch
    End Function
    Sub WstawitUchastok()
        Dim lSdwigWstawki = wBegPiketaj - wDopolUch.PiketajBeg
        Dim lSdwigKonza = wDopolUch.PiketajEnd - wDopolUch.PiketajBeg + wBegPiketaj - wEndPiketaj
        RazdelitDan()
        'Вставка
        'пикетов
        For Each el As DsProfil.ProfilARow In wDopolUch.dsProfil.ProfilA
            el.SetAdded()
            wOsnowUch.dsProfil.ProfilA.ImportRow(el)
            Dim elprow = wOsnowUch.dsProfil.ProfilA.FindByUIdTchk(el.UIdTchk)
            ' Возможен вариант но нужно приводить
            'Dim elprow = wOsnowUch.DsProfil.ProfilA.Rows(wOsnowUch.DsProfil.ProfilA.Count - 1)
            elprow.Piketaj += lSdwigWstawki
            elprow.UIdTchk = Guid.NewGuid
            elprow.UIdUch = wOsnowUch.UidUch
        Next
        'климата
        For Each el As DsProfil.TablKlimNRow In wDopolUch.dsProfil.TablKlimN
            el.SetAdded()
            wOsnowUch.dsProfil.TablKlimN.ImportRow(el)
            Dim elprow = wOsnowUch.dsProfil.TablKlimN.FindByUIdKlim(el.UIdKlim)
            elprow.Piketaj += lSdwigWstawki
            elprow.UIdKlim = Guid.NewGuid
            elprow.UIdUch = wOsnowUch.UidUch
        Next
        'ugodij
        For Each el As DsProfil.PikUgodNRow In wDopolUch.dsProfil.PikUgodN
            el.SetAdded()
            wOsnowUch.dsProfil.PikUgodN.ImportRow(el)
            Dim elprow = wOsnowUch.dsProfil.PikUgodN.FindByUIdUgod(el.UIdUgod)
            elprow.Piketaj += lSdwigWstawki
            elprow.UIdUgod = Guid.NewGuid
            elprow.UidUch = wOsnowUch.UidUch
        Next
        'opor
        For Each el As dsRasst.rastOpNRow In wDopolUch.DsRasst.rastOpN
            el.SetAdded()
            wOsnowUch.DsRasst.rastOpN.ImportRow(el)
            Dim elprow = wOsnowUch.DsRasst.rastOpN.FindByUIdRast(el.UIdRast)
            elprow.Piketaj += lSdwigWstawki
            elprow.UIdRast = Guid.NewGuid
            elprow.UIdUch = wOsnowUch.UidUch
        Next
        'mechuslowij
        For Each el As dsRasst.MechUslRow In wDopolUch.DsRasst.MechUsl
            el.SetAdded()
            wOsnowUch.DsRasst.MechUsl.ImportRow(el)
            Dim elprow = wOsnowUch.DsRasst.MechUsl.FindByUIndtaj(el.UIndtaj)
            elprow.Piketaj += lSdwigWstawki
            elprow.UIndtaj = Guid.NewGuid
            elprow.UidUch = wOsnowUch.UidUch
        Next
        wOsnowUch.DannElemRasstUch.Objedin(wDopolUch.DannElemRasstUch.DataSet)
        'konez вставки
        'udalenie
        'пикетов
        For Each el As DsProfil.ProfilARow In wChastMejdu.ProfilARows
            el.Delete()
        Next
        For Each el As DsProfil.TablKlimNRow In wChastMejdu.KlimatRows
            el.Delete()
        Next
        For Each el As DsProfil.PikUgodNRow In wChastMejdu.PiketUgodRows
            el.Delete()
        Next
        'opor
        For Each el As dsRasst.rastOpNRow In wChastMejdu.RastOpRows
            el.Delete()

        Next
        'mech uslow
        For Each el As dsRasst.MechUslRow In wChastMejdu.MechUslRows
            el.Delete()

        Next
        'konez удаления
        'sdwig
        'пикетов
        For Each el As DsProfil.ProfilARow In wChastDoKonza.ProfilARows
            el.Piketaj += lSdwigKonza
        Next
        For Each el As DsProfil.TablKlimNRow In wChastDoKonza.KlimatRows
            el.Piketaj += lSdwigKonza
        Next
        For Each el As DsProfil.PikUgodNRow In wChastDoKonza.PiketUgodRows
            el.Piketaj += lSdwigKonza
        Next
        'opor
        For Each el As dsRasst.rastOpNRow In wChastDoKonza.RastOpRows
            el.Piketaj += lSdwigKonza

        Next
        'mech uslow
        For Each el As dsRasst.MechUslRow In wChastDoKonza.MechUslRows
            el.Piketaj += lSdwigKonza

        Next
        'konez сдвига
    End Sub

End Class
