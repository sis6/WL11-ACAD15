Imports modRasstOp

Public Class FrmWiwRezGabarit
    Public Sub addDann(ByVal Irez As DFun, ByVal Ifaz As Fazi)
        Select Case Ifaz
            Case modRasstOp.Fazi.faz0
                DFunBindingSourceZ0.Add(Irez)
            Case modRasstOp.Fazi.faz1
                DFunBindingSourcez1.Add(Irez)
            Case Fazi.faz2
                DFunBindingSourceZ2.Add(Irez)
        End Select

    End Sub
    Public Sub DopZag(ByVal iZag As String)
        DopDataGridViewTextBoxColumn.HeaderText = iZag
        DataGridViewTextBoxColumn8.HeaderText = iZag
        DataGridViewTextBoxColumn4.HeaderText = iZag
    End Sub


    Private Sub DFunBindingSourcez1_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DFunBindingSourcez1.CurrentChanged

    End Sub

    Private Sub DataGridViewz2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewz2.CellContentClick

    End Sub

    Private Sub FrmWiwRezGabarit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub DataGridViewZ1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewZ1.CellContentClick

    End Sub

    Private Sub DataGridViewZ0_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewZ0.CellContentClick

    End Sub

    Private Sub Label1Rejm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


End Class