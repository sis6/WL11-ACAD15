Public Class frmPoisk

    Dim objfrmUch As New FrmUch
    Dim objfrmModUch As New FrmUchprf
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DsProfil1.ProfilN' table. You can move, or remove it, as needed.
        '  Me.ProfilNTableAdapter.Fill(Me.DsProfil.ProfilN)
        'TODO: This line of code loads data into the 'DsUpr.TrassLin' table. You can move, or remove it, as needed.
     
       
        'TODO: This line of code loads data into the 'ProfilRasst_11DataSet.pObjectESSp' table. You can move, or remove it, as needed.
        Me.PObjectESSpTableAdapter.Fill(Me.DsWibUch.pObjectESSp)
        'TODO: This line of code loads data into the 'ProfilRasst_11DataSet.allProfil' table. You can move, or remove it, as needed.
        Me.PObjectESSlTableAdapter.Fill(Me.DsWibUch.pObjectESSl)
        Me.RegPsTableAdapter.Fill(Me.DsWibUch.RegPs)
        'TODO: This line of code loads data into the 'ProfilRasst_11DataSet.TrassLin' table. You can move, or remove it, as needed.
        Me.TrassLinTableAdapter.Fill(Me.DsWibUch.TrassLin)
        'TODO: This line of code loads data into the 'ProfilRasst_11DataSet.uchastkiN' table. You can move, or remove it, as needed.
        Me.UchastkiNTableAdapter.Fill(Me.DsWibUch.uchastkiN)

        Me.UnomNTableAdapter.Fill(Me.DsWibUch.UnomN)
        'TODO: This line of code loads data into the 'ProfilRasst_11DataSet.tESS' table. You can move, or remove it, as needed.
        Me.TESSTableAdapter.Fill(Me.DsWibUch.tESS)
        ObToolStripTextBox.ComboBox.DataSource = tESSBS
        ObToolStripTextBox.ComboBox.DisplayMember = "Name"
        ObToolStripTextBox.ComboBox.ValueMember = "Oboz"
        UnomToolStripTextBox.ComboBox.DataSource = UnomNBS
        UnomToolStripTextBox.ComboBox.DisplayMember = "Unom"
        UnomToolStripTextBox.ComboBox.ValueMember = "Unom"

    End Sub

    Private Sub Cbregiom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' MsgBox(Cbregiom.SelectedIndex)
    End Sub

    Private Sub FillToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.UnomNTableAdapter.Fill(Me.DsWibUch.UnomN)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub





    Private Sub FillByToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FillByToolStripButton.Click
        If Me.FSpLinRegionpBindingSource.DataMember <> "fSpLinRegionp" Then

            Me.FSpLinRegionpBindingSource.DataMember = "fSpLinRegionp"
            Me.TrassLinBindingSource.DataMember = "fSpLinRegionp_TrassLin"
            Me.UchastkiNBindingSource.DataMember = "FK_uchastkiN_TrassLin"
           
        End If

        Try


            Me.FSpLinRegionpTableAdapter.FillBy(Me.DsWibUch.fSpLinRegionp, CType(ObToolStripTextBox.ComboBox.SelectedValue, Integer), New System.Nullable(Of Integer)(CType(UnomToolStripTextBox.Text, Integer)))
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub

   

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Me.FSpLinRegionpBindingSource.DataMember = "pObjectESSl"
        Me.TrassLinBindingSource.DataMember = "pObjectESSl_TrassLin"
        Me.UchastkiNBindingSource.DataMember = "FK_uchastkiN_TrassLin"
      
    End Sub

    Private Sub AllProfilDataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub FSpLinRegionpBindingSource_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FSpLinRegionpBindingSource.CurrentChanged

    End Sub

    Private Sub TrassLinDataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridLinij.CellContentClick

    End Sub

    Private Sub TrassLinBindingSource_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrassLinBindingSource.CurrentChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        MsgBox(UchastkiNDataGridView.SelectedRows.Count & " " & objfrmUch.Visible)
        objfrmUch = New FrmUch
        objfrmUch.NameUchToolStripTextBox.Text = UchastkiNDataGridView.SelectedRows.Item(0).Cells.Item("UIdUch").Value.ToString


        objfrmUch.Show()
        objfrmUch.BringToFront()
        Me.WindowState = FormWindowState.Minimized
        objfrmUch.WindowState = FormWindowState.Normal
        Me.SendToBack()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        objfrmModUch = New FrmUchprf
        objfrmModUch.UkNauch = UchastkiNDataGridView.SelectedRows.Item(0).Cells.Item("UIdUch").Value
        ' UchastkiNBindingSource.Current
        objfrmModUch.Show()
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class