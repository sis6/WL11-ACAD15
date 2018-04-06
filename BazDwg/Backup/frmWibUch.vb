Public Class frmWibUch
    Dim UnomNTableAdapter As New dsUprTableAdapters.UnomNTableAdapter
    Dim TESSTableadapter As New dsUprTableAdapters.tESSTableAdapter
    Dim tESSBS As New BindingSource
    Dim UnomNBS As New BindingSource
    Dim objfrmUch As FrmUch
    Dim objfrmModUch As FrmUchprf
    Private Sub frmWibUch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DsUpr.FileExcel' table. You can move, or remove it, as needed.
        Me.FileExcelTableAdapter.Fill(Me.DsUpr.FileExcel)
        'TODO: This line of code loads data into the 'DsUpr.pObjectESSp' table. You can move, or remove it, as needed.
        Me.PObjectESSpTableAdapter.Fill(Me.DsUpr.pObjectESSp)
        'TODO: This line of code loads data into the 'DsUpr.uchastkiN' table. You can move, or remove it, as needed.
        Me.UchastkiNTableAdapter.Fill(Me.DsUpr.uchastkiN)
        'TODO: This line of code loads data into the 'DsUpr.TrassLin' table. You can move, or remove it, as needed.
        Me.TrassLinTableAdapter.Fill(Me.DsUpr.TrassLin)
        Me.UnomNTableAdapter.Fill(Me.DsUpr.UnomN)
        'TODO: This line of code loads data into the 'ProfilRasst_11DataSet.tESS' table. You can move, or remove it, as needed.
        Me.TESSTableadapter.Fill(Me.DsUpr.tESS)
        tESSBS.DataSource = DsUpr
        tESSBS.DataMember = "tESS"       '   TESSTableadapter
        ObToolStripCBox.ComboBox.DataSource = tESSBS
        ObToolStripCBox.ComboBox.DisplayMember = "Name"
        ObToolStripCBox.ComboBox.ValueMember = "Oboz"
        UnomNBS.DataSource = DsUpr
        UnomNBS.DataMember = "UnomN"
        UnomToolStripCombBox.ComboBox.DataSource = UnomNBS
        UnomToolStripCombBox.ComboBox.DisplayMember = "Unom"
        UnomToolStripCombBox.ComboBox.ValueMember = "Unom"
        FindFileExcel.Filter = "Описание профиля в 97-2003|*.xls|Описание профиля Excel|*.xlsx"
        FindFileExcel.DefaultExt = "xls"

    End Sub
    Private Sub Obnow()
        Try
            Me.FSpLinRegionpTableAdapter.Fill(Me.DsUpr.fSpLinRegionp, CType(ObToolStripCBox.ComboBox.SelectedValue, Integer), New System.Nullable(Of Short)(CType(UnomToolStripCombBox.Text, Short)))
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub FillToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FillToolStripButton.Click
        Obnow()

    End Sub

   
    Private Sub UchastkiNDataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles UchastkiNDataGridView.CellContentClick

    End Sub

    Private Sub ToolStripUchDann_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripUchDann.Click
        Dim rw As dsUpr.uchastkiNRow
        '  Dim rw1 As DataRowView
        Try
            rw = CType(UchastkiNBindingSource.Current, DataRowView).Row
        Catch ex As Exception
            MsgBox(ex.ToString)
            Exit Sub
        End Try

        ' MsgBox(rw.UIdUch.ToString)
        objfrmUch = New FrmUch
        objfrmUch.RowUch = rw
        objfrmUch.Show()
        ' Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub ToolStripModUch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripModUch.Click
        Dim rw As dsUpr.uchastkiNRow
        '  Dim rw1 As DataRowView
        Try
            rw = CType(UchastkiNBindingSource.Current, DataRowView).Row
        Catch ex As NullReferenceException
            MsgBox("Не выбран участок")
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.ToString)
            Exit Sub
        End Try

        objfrmModUch = New FrmUchprf
        objfrmModUch.RowUch = rw
        objfrmModUch.Show()
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub AddNewUch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewUch.Click
        Dim rw As dsUpr.TrassLinRow
        Try
            rw = CType(TrassLinBindingSource.Current, DataRowView).Row
        Catch ex As NullReferenceException
            MsgBox("Не выбрана трасса")
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.ToString)
            Exit Sub
        End Try
        'MsgBox(rw.NameTr)
        'Dim rwnewUch As dsUpr.uchastkiNRow = DsUpr.uchastkiN.NewuchastkiNRow
        'Dim ww As Guid = Guid.NewGuid()
        'MsgBox(ww.ToString)
        'rwnewUch.UIdUch = Guid.NewGuid()
        'rwnewUch.NameUch = "now"
        'rwnewUch.IndeksT = rw.IndeksT
        'rwnewUch.DataW = Now()
        'rwnewUch.Polz = My.User.Name
        'rwnewUch.IdUch = -1
        'DsUpr.uchastkiN.AdduchastkiNRow(rwnewUch)
        'UchastkiNBindingSource.EndEdit()
        UchastkiNTableAdapter.Connection.ConnectionString = My.Settings.ProfilRasst_WinAuId
        UchastkiNBindingSource.EndEdit()
        Try
            UchastkiNTableAdapter.Update(DsUpr.uchastkiN)
        Catch ex As Exception
            MsgBox("AddNewUch_Click " & ex.ToString)

        End Try


    End Sub

    Private Sub KnFileExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KnFileExcel.Click
        Dim rw As dsUpr.uchastkiNRow
        Dim rwf As dsUpr.FileExcelRow
        Dim lput As String = ""
        Try
            rw = CType(UchastkiNBindingSource.Current, DataRowView).Row
        Catch ex As Exception
            MsgBox("Не выбран участок")
            Exit Sub
        End Try
        If FindFileExcel.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ' MsgBox(OpenFileDialog1.FileName)
            lput = FindFileExcel.FileName
        End If
        If lput <> "" Then
            Try

                rwf = CType(FileExcelBindingSource.Current, DataRowView).Row
            Catch ex As Exception
                UidUchTextBox.Text = rw.UIdUch.ToString
                rwf = DsUpr.FileExcel.NewFileExcelRow
                rwf.UidUch = rw.UIdUch
                DsUpr.FileExcel.AddFileExcelRow(rwf)
            End Try
            rwf.PutExel = lput
            FileExcelBindingSource.EndEdit()
            FileExcelTableAdapter.Update(DsUpr.FileExcel)

        End If

    End Sub
    Private Sub FindFileExcel_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles FindFileExcel.FileOk
        FindFileExcel.Filter = "Описание профиля в 97-2003|*.xls|Описание профиля Excel|*.xlsx"
        FindFileExcel.DefaultExt = "xls"
        'If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '    ' MsgBox(OpenFileDialog1.FileName)
        '    lbSpFile.Items.Add(OpenFileDialog1.FileName)
        'End If
    End Sub
    Private Sub ToolStripMod_Xls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMod_Xls.Click
        Dim rw As dsUpr.uchastkiNRow
        '  Dim rw1 As DataRowView
        Try
            rw = CType(UchastkiNBindingSource.Current, DataRowView).Row
        Catch ex As Exception
            MsgBox(ex.ToString)
            Exit Sub
        End Try

        Dim rwf As dsUpr.FileExcelRow = Nothing
        Dim lput As String = ""
        Try
            rwf = CType(FileExcelBindingSource.Current, DataRowView).Row
        Catch ex As Exception
            MsgBox("Нет записи о файле")
        End Try
        If Not rwf Is Nothing Then
            objfrmModUch = New FrmUchprf
            objfrmModUch.RowFileUch = rwf
            objfrmModUch.RowUch(False) = rw
            objfrmModUch.Show()
            Me.WindowState = FormWindowState.Minimized
        End If

    End Sub

    Private Sub UidUchTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UidUchTextBox.TextChanged

    End Sub

    Private Sub UidUchLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub UchastkiNBindingSource_AddingNew(ByVal sender As Object, ByVal e As System.ComponentModel.AddingNewEventArgs) Handles UchastkiNBindingSource.AddingNew

        '  CType(e.NewObject, dsUpr.uchastkiNRow).UIdUch = Guid.NewGuid
        ' = Guid.NewGuid.ToString
    End Sub

    Private Sub UchastkiNDataGridView_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles UchastkiNDataGridView.DefaultValuesNeeded
        With e.Row
            .Cells("UIdUch").Value = Guid.NewGuid
            .Cells("DataW").Value = Now()
            .Cells("Polz").Value = My.User.Name
            .Cells("NameUch").Value = "N_U"
        End With
    End Sub

    Private Sub UchastkiNDataGridView_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles UchastkiNDataGridView.RowsAdded
        'Dim IdS = UchastkiNDataGridView.NewRowIndex
        ''   MsgBox(UchastkiNDataGridView.Rows(IdS).Cells(1).Value.ToString)
    End Sub
End Class