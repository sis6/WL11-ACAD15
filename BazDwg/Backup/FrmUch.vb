Public Class FrmUch
    Dim rwUch As dsUpr.uchastkiNRow
    WriteOnly Property RowUch() As dsUpr.uchastkiNRow
        Set(ByVal value As dsUpr.uchastkiNRow)
            rwUch = value


            Try
                DsProfil.ProfilN.UIdUchColumn.DefaultValue = rwUch.UIdUch
            Catch ex As System.NullReferenceException
                System.Windows.Forms.MessageBox.Show("Не выбран участок")
                Exit Property
            Catch ex As Exception
                System.Windows.Forms.MessageBox.Show(ex.Message)
                Exit Property

            End Try
            NameUchToolStripTextBox.Text = rwUch.NameUch
            Me.ProfilNTableAdapter.Fill(Me.DsProfil.ProfilN, rwUch.UIdUch)
            Try
                Me.ProfilATableAdapter.Fill(Me.DsProfil.ProfilA, rwUch.UIdUch)
            Catch ex As System.Exception
                System.Windows.Forms.MessageBox.Show(ex.Message)
            End Try
        End Set
    End Property
    Private Sub FrmUch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DsProfil.TipSoor' table. You can move, or remove it, as needed.
        Me.TipSoorTableAdapter.Fill(Me.DsProfil.TipSoor)
        'TODO: This line of code loads data into the 'DsProfil.PikUgodN' table. You can move, or remove it, as needed.
        Me.PikUgodNTableAdapter.Fill(Me.DsProfil.PikUgodN)
        'TODO: This line of code loads data into the 'DsProfil.UgolPoworota' table. You can move, or remove it, as needed.
        Me.UgolPoworotaTableAdapter.Fill(Me.DsProfil.UgolPoworota)
        'TODO: This line of code loads data into the 'DsProfil.Osob' table. You can move, or remove it, as needed.
        Me.OsobTableAdapter.Fill(Me.DsProfil.Osob)
        'TODO: This line of code loads data into the 'DsProfil.PikUgodN' table. You can move, or remove it, as needed.
        Me.PikUgodNTableAdapter.Fill(Me.DsProfil.PikUgodN)
        'TODO: This line of code loads data into the 'DsProfil.Osob' table. You can move, or remove it, as needed.
        Me.OsobTableAdapter.Fill(Me.DsProfil.Osob)
        'TODO: This line of code loads data into the 'DsProfil.UgolPoworota' table. You can move, or remove it, as needed.
        Me.UgolPoworotaTableAdapter.Fill(Me.DsProfil.UgolPoworota)
        'Me.ProfilATableAdapter.UpdateQuery()
        'Me.DsProfil.ProfilAT()
        '   DsProfil.ProfilN.IdUchColumn.DefaultValue =  
        ''  DsProfil.ProfilN.UIdUchColumn.DefaultValue = New System.Nullable(Of System.Guid)(New System.Guid(IUiduchToolStripTextBox.Text))
        ' ProfilNDataGridView.Columns(1).CellType
    End Sub

    

    

    Private Sub ProfilNBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProfilNBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.ProfilNBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.DsProfil)


    End Sub

    Private Sub FillToolStripButton_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FillToolStripButton.Click
        Try
            Me.ProfilNTableAdapter.Fill(Me.DsProfil.ProfilN, rwUch.UIdUch)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
        Try
            Me.ProfilATableAdapter.Fill(Me.DsProfil.ProfilA, rwUch.UIdUch)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
        '   DsProfil.ProfilN.IdUchColumn.DefaultValue =  

    End Sub

    Private Sub IUiduchToolStripTextBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NameUchToolStripTextBox.Click

    End Sub


    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSohr.Click
        ' Me.ProfilATableAdapter.UpdateQuery(5)
        Me.Validate()
        'UIdTchkDataGridViewTextBoxColumn1.DataPropertyName

        Me.ProfilNBindingSource.EndEdit()
        Me.ProfilNTableAdapter.Update(DsProfil.ProfilN)
    End Sub

    Private Sub UgolPoworotaDataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles UgolPoworotaDataGridView.CellContentClick
        Try
            MsgBox(ProfilNDataGridView.SelectedRows.Item(0).Cells("gUIdTchk").Value.ToString)
        Catch ex As Exception

        End Try
        MsgBox(ProfilNDataGridView.SelectedRows.Count)
    End Sub

    Private Sub ProfilNDataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ProfilNDataGridView.CellContentClick

    End Sub

    Private Sub OsobDataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles OsobDataGridView.CellContentClick

    End Sub

    Private Sub ProfilNDataGridView_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles ProfilNDataGridView.DefaultValuesNeeded

        e.Row.Cells("gUIdTchk").Value = Guid.NewGuid()   '"UIdTchk"
        'Dim w1 = e.Row.Cells.Count
    End Sub
End Class