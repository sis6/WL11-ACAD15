Imports modelGeo

Public Class FrmSloiIge
    Private wSlojIGeReal As List(Of GeologijDwg.GranizaSlojIgeRealDwg)
    Private wSlojIgeRealPoSkwaj As List(Of GeologijDwg.GranizaSlojIgeRealDwg)
    Private wRasst As modRasstOp.wlRasst
    Sub SetSwajz(iDwgRasstGeo As ObrazGeologiiRealDwg, iobraz As LeseGeoIzDwg.ObrazGeoloGii)
        wSlojIGeReal = iDwgRasstGeo.GetSloiIgePodOporami(iobraz)
        wSlojIgeRealPoSkwaj = iDwgRasstGeo.GetSlojIgeNaSkwajnah
    End Sub

    Private Sub FrmSloiIge_Load(sender As Object, e As EventArgs) Handles Me.Load
        DataGridViewIgeNaTrasse.DataSource = wSlojIGeReal
        DataGridViewIgePoSkwaj.DataSource = wSlojIgeRealPoSkwaj
    End Sub


End Class