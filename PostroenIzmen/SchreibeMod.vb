Imports modRasstOp
''' <summary>
''' Запись 1 участка как расстановки в словарь
''' </summary>
''' <remarks></remarks>
Public Class SchreibeMod
    Private wRasst As modRasstOp.wlRasst

    Sub New(ByVal UchPrf As clsPrf.clsUchPrf)
        Dim wlUch As New modRasstOp.wlUch(UchPrf)
        wlUch.SetElemRasstUch()
        wlUch.SozdatParam()



        wRasst = New modRasstOp.wlRasst(New clsPrf.clsTrass("ВЛdPolyline", "R_Polyline", UchPrf.Unom))
        wRasst.Trassa.DobUch(wlUch)
        wRasst.OprRast()
        Dim dnDwg As New LeseSreib.clsLeseSrejbRasstDwg(LeseSreib.KorSlDann, wRasst)
        dnDwg.Save()
        ' If Not dnDwg.Izwlech() Then wRasst = Nothing

    End Sub
End Class
