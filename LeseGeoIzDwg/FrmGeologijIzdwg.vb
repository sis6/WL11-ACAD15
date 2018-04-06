Public Class FrmGeologijIzdwg
    'Public SpSkwajn As List(Of SkwajIzDwgPoMText)
    'Public SpIge As List(Of HatchIdentifikator)
    Public SpSkwajPoobrazu As List(Of PostroenijSkwajEntity)
    Private wObrazgeologii As ObrazGeoloGii
    Public Sub ZadatModelGeologii(iGeologij As ObrazGeoloGii)
        wObrazgeologii = iGeologij


    End Sub
    Private Sub FrmOtladGeo_Load(sender As Object, e As EventArgs) Handles Me.Load
        With wObrazgeologii
            DataGridViewSkwajn.DataSource = .SpSkwajn
            DataGridViewSloiIge.DataSource = .GetSloiIge
            ComboBoxSloewIGE.DataSource = .GetSpisokNaimenowanij
            DataGridViewParamIge.DataSource = .GetSpisokParamIge
        End With

        DataGridViewSkwajnEntity.DataSource = SpSkwajPoobrazu
    End Sub

    Private Sub DataGridViewSkwajn_CellContentClick(sender As Object, e As Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewSkwajn.CellContentClick

    End Sub
End Class