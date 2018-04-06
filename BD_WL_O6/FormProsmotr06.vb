Public Class FormProsmotr06
	Private Sub FormProsmotr06_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		ParamUchNBindingSource.DataSource = DsRass_06
		MechUslBindingSource.DataSource = DsRass_06
		RastOpNBindingSource.DataSource = DsRass_06
	End Sub
End Class