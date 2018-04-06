Imports System.Collections.Generic
''' <summary>
''' по точкам полученным при анализе полилинии строит иодель участка профиля
''' </summary>
''' <remarks></remarks>
Public Class modImport
    Private wSp As List(Of PointProf)
    Private wUchprf As New clsPrf.clsUchPrf(Guid.Empty)
    Public LabelInfo As Windows.Forms.Label
    Sub New(ByVal iProfil As PoSpPoint3dProf)
        wSp = iProfil.SpToshek
        wSp.Last()
    End Sub
    Sub ZapisatWDwg(ByVal UchPrf As clsPrf.clsUchPrf)
        Dim lRasst As modRasstOp.wlRasst
        Dim wlUch As New modRasstOp.wlUch(UchPrf)
        wlUch.SetElemRasstUch()
        wlUch.SozdatParam()



        lRasst = New modRasstOp.wlRasst(New clsPrf.clsTrass("ВЛdPolyline", "R_Polyline", UchPrf.Unom))
        lRasst.Trassa.DobUch(wlUch)
        lRasst.OprRast()
        Dim dnDwg As New LeseSreib.clsLeseSrejbRasstDwg(LeseSreib.KorSlDann, lRasst)
        dnDwg.Save()
    End Sub
    Sub zapolnit()
        Dim I As Integer = 1

        For Each el As PointProf In wSp
            LabelInfo.Text = CStr(I)
            LabelInfo.Refresh()
            Dim lpik As New clsPrf.ClsPiket(CStr(I), el.Piketaj, el.Otm, wUchprf, el.otmLw, el.OtmPr, el.StrUgol)
            wUchprf.DobPiket(lpik)

            I += 1
        Next
        LabelInfo.Text = "Импорт завершен"
        LabelInfo.Refresh()
        wUchprf.NameUch = "По полилинии"
        Try
            ZapisatWDwg(wUchprf)

        Catch ex As System.IO.FileNotFoundException
            MsgBox(ex.FileName & "  " & ex.Source)
        End Try

    End Sub
    Function GetUchastok() As clsPrf.clsUchPrf
        Dim I As Integer = 1
        For Each el As PointProf In wSp


            LabelInfo.Text = CStr(I)
            LabelInfo.Refresh()
            Dim lpik As New clsPrf.ClsPiket(CStr(I), el.Piketaj, el.Otm, wUchprf, , , el.StrUgol)
            wUchprf.DobPiket(lpik)


            I += 1
        Next
        '  MsgBox(Me.ToString & "  " & I)
        LabelInfo.Text = "участок  сформирован"
        LabelInfo.Refresh()
        wUchprf.NameUch = "Вставка из PlLine "
        Return wUchprf
    End Function
End Class
