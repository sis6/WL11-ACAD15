Public Class FrmOpora
    Public RowDan As TipElWl_06.oporiRow
    Private Sub FrmOpora_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: данная строка кода позволяет загрузить данные в таблицу "TipElWl_06.opori". При необходимости она может быть перемещена или удалена.
        Me.OporiTableAdapter.Fill(Me.TipElWl_06.opori)

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.RowEnter
        RowDan = CType(CType(OporiBindingSource.List(e.RowIndex), DataRowView).Row, TipElWl_06.oporiRow)
        LabelShifrOp.Text = RowDan.Tip_op
    End Sub

    Private Sub TextBoxPoisk_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxPoisk.TextChanged
        Me.OporiTableAdapter.FillBy(Me.TipElWl_06.opori, TextBoxPoisk.Text)
    End Sub
End Class