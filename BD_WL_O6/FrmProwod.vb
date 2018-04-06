Public Class FrmProwod
    Public RowDan As TipElWl_06.prowodaNRow
    Private Sub FrmProwod_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: данная строка кода позволяет загрузить данные в таблицу "TipElWl_06.prowodaN". При необходимости она может быть перемещена или удалена.
        Me.ProwodaNTableAdapter.Fill(Me.TipElWl_06.prowodaN)

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.Disposed

    End Sub

    Private Sub DataGridView1_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.RowEnter

        RowDan = CType(CType(ProwodaNBindingSource.List(e.RowIndex), DataRowView).Row, TipElWl_06.prowodaNRow)
        Labelmarkf.Text = RowDan.Name_mark
    End Sub

    'Private Sub DataVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.RowEnter
    '  
    'End Sub

    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged

    End Sub
End Class