Public Class FrmZadatSdwig3DRez
    Sub Add(iRez As modRasstOp.DFun)
        DFunBindingSource.Add(iRez)
    End Sub
    WriteOnly Property Rejm() As Rashet.Rejm
        Set(value As Rashet.Rejm)
            LabelGamma.Text = Format(value.Gamma, "f4")
            LabelSigma.Text = Format(value.Sigma, "f1")
            LabelTemp.Text = Format(value.Temp, "f0")
        End Set
    End Property
    WriteOnly Property Opora() As modRasstOp.wlOpRasst
        Set(value As modRasstOp.wlOpRasst)
            LabelNameOp.Text = value.NumName
        End Set
    End Property

    Private Sub DataGridView1_CellContentClick(sender As Object, e As Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        If TypeOf e.Value Is Double Then
            If Double.IsNaN(e.Value) Then
                'DataGridView1.CurrentCell.Value = ""
                e.Value = ""
                e.FormattingApplied = True
            End If
            End If

    End Sub
End Class