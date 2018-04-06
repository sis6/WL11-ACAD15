Imports LeseGeoIzDwg

Public Class FrmSloiigeSkwajn
    Private wparamige As List(Of LeseGeoIzDwg.ParamIge)
    WriteOnly Property Skwajna() As GeologijDwg.SkwajnaRealDwg
        Set(value As GeologijDwg.SkwajnaRealDwg)
            SloiIgeRealSkwajBindingSource.DataSource = value.GetSloiIgePosle
            SloiIgeRealSkwajEndBindingSource.DataSource = value.GetSloiIgeDo
            RazrezIgeRealSkwajBindingSource.DataSource = value.GetSlojNaSkwajne
            TextBoxName.Text = value.nameSkaj
            TextBoxRast.Text = Format(value.Rastojnie, "f2")
            TextBoxPiketaj.Text = clsPrf.ClsPiket.StrPiketaj(value.Piketaj)
            TextBoxOtmetka.Text = Format(value.Otmetka, "f2")
            TextBoxGlubina.Text = Format(value.Glubina, "f2")

        End Set
    End Property
    WriteOnly Property ParamIGe() As List(Of ParamIge)
        Set(value As List(Of ParamIge))
           
            DataGridViewParamIge.DataSource = value
            DataGridViewParamIge.DisplayMember = "IndexIge"
            DataGridViewParamIge.ValueMember = "IndexIge"

        End Set
    End Property
    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub ButtonOk_Click(sender As Object, e As EventArgs) Handles ButtonOk.Click

    End Sub

    Private Sub ButtonPerep_Click(sender As Object, e As EventArgs) Handles ButtonPerep.Click

    End Sub

    Private Sub FrmSloiigeSkwajn_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class