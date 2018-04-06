<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWwdGrList
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWwdGrList))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridViewListov = New System.Windows.Forms.DataGridView()
        Me.NameListDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.RastotNachDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClsGranizBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ButtonOk = New System.Windows.Forms.Button()
        Me.DataGridViewVid = New System.Windows.Forms.DataGridView()
        Me.Rast = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.RastOtnachalaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClsZonKlimatBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ListBoxUch = New System.Windows.Forms.ListBox()
        Me.LabelUch = New System.Windows.Forms.Label()
        Me.Labelklim = New System.Windows.Forms.Label()
        Me.LabelList = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clsPiketBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewUgl = New System.Windows.Forms.DataGridView()
        Me.NamePiketDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RastOtnachalaDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OtmetkaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LabelWisPrfWidEkran = New System.Windows.Forms.Label()
        Me.HelpProviderGrList = New System.Windows.Forms.HelpProvider()
        CType(Me.DataGridViewListov, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClsGranizBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewVid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClsZonKlimatBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.clsPiketBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewUgl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridViewListov
        '
        Me.DataGridViewListov.AutoGenerateColumns = False
        Me.DataGridViewListov.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewListov.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NameListDataGridViewTextBoxColumn, Me.RastotNachDataGridViewTextBoxColumn})
        Me.DataGridViewListov.DataSource = Me.ClsGranizBindingSource
        Me.HelpProviderGrList.SetHelpString(Me.DataGridViewListov, resources.GetString("DataGridViewListov.HelpString"))
        resources.ApplyResources(Me.DataGridViewListov, "DataGridViewListov")
        Me.DataGridViewListov.Name = "DataGridViewListov"
        Me.HelpProviderGrList.SetShowHelp(Me.DataGridViewListov, CType(resources.GetObject("DataGridViewListov.ShowHelp"), Boolean))
        '
        'NameListDataGridViewTextBoxColumn
        '
        Me.NameListDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.NameListDataGridViewTextBoxColumn.DataPropertyName = "NameList"
        resources.ApplyResources(Me.NameListDataGridViewTextBoxColumn, "NameListDataGridViewTextBoxColumn")
        Me.NameListDataGridViewTextBoxColumn.Name = "NameListDataGridViewTextBoxColumn"
        Me.NameListDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.NameListDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'RastotNachDataGridViewTextBoxColumn
        '
        Me.RastotNachDataGridViewTextBoxColumn.DataPropertyName = "RastotNach"
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.RastotNachDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        resources.ApplyResources(Me.RastotNachDataGridViewTextBoxColumn, "RastotNachDataGridViewTextBoxColumn")
        Me.RastotNachDataGridViewTextBoxColumn.Name = "RastotNachDataGridViewTextBoxColumn"
        '
        'ClsGranizBindingSource
        '
        Me.ClsGranizBindingSource.AllowNew = True
        Me.ClsGranizBindingSource.DataSource = GetType(ProfilBaseDwg.dwgGranizList)
        '
        'ButtonOk
        '
        Me.ButtonOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.HelpProviderGrList.SetHelpString(Me.ButtonOk, resources.GetString("ButtonOk.HelpString"))
        resources.ApplyResources(Me.ButtonOk, "ButtonOk")
        Me.ButtonOk.Name = "ButtonOk"
        Me.HelpProviderGrList.SetShowHelp(Me.ButtonOk, CType(resources.GetObject("ButtonOk.ShowHelp"), Boolean))
        Me.ButtonOk.UseVisualStyleBackColor = True
        '
        'DataGridViewVid
        '
        Me.DataGridViewVid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewVid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Rast})
        Me.HelpProviderGrList.SetHelpString(Me.DataGridViewVid, resources.GetString("DataGridViewVid.HelpString"))
        resources.ApplyResources(Me.DataGridViewVid, "DataGridViewVid")
        Me.DataGridViewVid.Name = "DataGridViewVid"
        Me.HelpProviderGrList.SetShowHelp(Me.DataGridViewVid, CType(resources.GetObject("DataGridViewVid.ShowHelp"), Boolean))
        '
        'Rast
        '
        Me.Rast.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        resources.ApplyResources(Me.Rast, "Rast")
        Me.Rast.Name = "Rast"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RastOtnachalaDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.ClsZonKlimatBindingSource
        resources.ApplyResources(Me.DataGridView1, "DataGridView1")
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.HelpProviderGrList.SetShowHelp(Me.DataGridView1, CType(resources.GetObject("DataGridView1.ShowHelp"), Boolean))
        '
        'RastOtnachalaDataGridViewTextBoxColumn
        '
        Me.RastOtnachalaDataGridViewTextBoxColumn.DataPropertyName = "RastOtnachala"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.RastOtnachalaDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        resources.ApplyResources(Me.RastOtnachalaDataGridViewTextBoxColumn, "RastOtnachalaDataGridViewTextBoxColumn")
        Me.RastOtnachalaDataGridViewTextBoxColumn.Name = "RastOtnachalaDataGridViewTextBoxColumn"
        Me.RastOtnachalaDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ClsZonKlimatBindingSource
        '
        Me.ClsZonKlimatBindingSource.DataSource = GetType(clsPrf.clsZonKlimat)
        '
        'ListBoxUch
        '
        resources.ApplyResources(Me.ListBoxUch, "ListBoxUch")
        Me.ListBoxUch.FormattingEnabled = True
        Me.ListBoxUch.MultiColumn = True
        Me.ListBoxUch.Name = "ListBoxUch"
        Me.HelpProviderGrList.SetShowHelp(Me.ListBoxUch, CType(resources.GetObject("ListBoxUch.ShowHelp"), Boolean))
        '
        'LabelUch
        '
        resources.ApplyResources(Me.LabelUch, "LabelUch")
        Me.LabelUch.Name = "LabelUch"
        Me.HelpProviderGrList.SetShowHelp(Me.LabelUch, CType(resources.GetObject("LabelUch.ShowHelp"), Boolean))
        '
        'Labelklim
        '
        resources.ApplyResources(Me.Labelklim, "Labelklim")
        Me.Labelklim.Name = "Labelklim"
        Me.HelpProviderGrList.SetShowHelp(Me.Labelklim, CType(resources.GetObject("Labelklim.ShowHelp"), Boolean))
        '
        'LabelList
        '
        resources.ApplyResources(Me.LabelList, "LabelList")
        Me.LabelList.Name = "LabelList"
        Me.HelpProviderGrList.SetShowHelp(Me.LabelList, CType(resources.GetObject("LabelList.ShowHelp"), Boolean))
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        Me.HelpProviderGrList.SetShowHelp(Me.Label1, CType(resources.GetObject("Label1.ShowHelp"), Boolean))
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "RastotNach"
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle4
        resources.ApplyResources(Me.DataGridViewTextBoxColumn1, "DataGridViewTextBoxColumn1")
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        resources.ApplyResources(Me.DataGridViewTextBoxColumn2, "DataGridViewTextBoxColumn2")
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "RastOtnachala"
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle5
        resources.ApplyResources(Me.DataGridViewTextBoxColumn3, "DataGridViewTextBoxColumn3")
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Piketaj"
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle6
        resources.ApplyResources(Me.DataGridViewTextBoxColumn4, "DataGridViewTextBoxColumn4")
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'clsPiketBindingSource
        '
        Me.clsPiketBindingSource.DataSource = GetType(clsPrf.ClsPiket)
        '
        'DataGridViewUgl
        '
        Me.DataGridViewUgl.AutoGenerateColumns = False
        Me.DataGridViewUgl.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.DataGridViewUgl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewUgl.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NamePiketDataGridViewTextBoxColumn, Me.DataGridViewTextBoxColumn5, Me.RastOtnachalaDataGridViewTextBoxColumn1, Me.OtmetkaDataGridViewTextBoxColumn})
        Me.DataGridViewUgl.DataSource = Me.clsPiketBindingSource
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.InfoText
        DataGridViewCellStyle7.Format = "N1"
        DataGridViewCellStyle7.NullValue = Nothing
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewUgl.DefaultCellStyle = DataGridViewCellStyle7
        Me.HelpProviderGrList.SetHelpString(Me.DataGridViewUgl, resources.GetString("DataGridViewUgl.HelpString"))
        resources.ApplyResources(Me.DataGridViewUgl, "DataGridViewUgl")
        Me.DataGridViewUgl.Name = "DataGridViewUgl"
        Me.HelpProviderGrList.SetShowHelp(Me.DataGridViewUgl, CType(resources.GetObject("DataGridViewUgl.ShowHelp"), Boolean))
        '
        'NamePiketDataGridViewTextBoxColumn
        '
        Me.NamePiketDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.NamePiketDataGridViewTextBoxColumn.DataPropertyName = "NamePiket"
        resources.ApplyResources(Me.NamePiketDataGridViewTextBoxColumn, "NamePiketDataGridViewTextBoxColumn")
        Me.NamePiketDataGridViewTextBoxColumn.Name = "NamePiketDataGridViewTextBoxColumn"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Piketaj"
        resources.ApplyResources(Me.DataGridViewTextBoxColumn5, "DataGridViewTextBoxColumn5")
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'RastOtnachalaDataGridViewTextBoxColumn1
        '
        Me.RastOtnachalaDataGridViewTextBoxColumn1.DataPropertyName = "RastOtnachala"
        resources.ApplyResources(Me.RastOtnachalaDataGridViewTextBoxColumn1, "RastOtnachalaDataGridViewTextBoxColumn1")
        Me.RastOtnachalaDataGridViewTextBoxColumn1.Name = "RastOtnachalaDataGridViewTextBoxColumn1"
        '
        'OtmetkaDataGridViewTextBoxColumn
        '
        Me.OtmetkaDataGridViewTextBoxColumn.DataPropertyName = "Otmetka"
        resources.ApplyResources(Me.OtmetkaDataGridViewTextBoxColumn, "OtmetkaDataGridViewTextBoxColumn")
        Me.OtmetkaDataGridViewTextBoxColumn.Name = "OtmetkaDataGridViewTextBoxColumn"
        Me.OtmetkaDataGridViewTextBoxColumn.ReadOnly = True
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        Me.HelpProviderGrList.SetShowHelp(Me.Label2, CType(resources.GetObject("Label2.ShowHelp"), Boolean))
        '
        'LabelWisPrfWidEkran
        '
        resources.ApplyResources(Me.LabelWisPrfWidEkran, "LabelWisPrfWidEkran")
        Me.LabelWisPrfWidEkran.Name = "LabelWisPrfWidEkran"
        Me.HelpProviderGrList.SetShowHelp(Me.LabelWisPrfWidEkran, CType(resources.GetObject("LabelWisPrfWidEkran.ShowHelp"), Boolean))
        '
        'HelpProviderGrList
        '
        resources.ApplyResources(Me.HelpProviderGrList, "HelpProviderGrList")
        '
        'frmWwdGrList
        '
        Me.AcceptButton = Me.ButtonOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelWisPrfWidEkran)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DataGridViewUgl)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LabelList)
        Me.Controls.Add(Me.Labelklim)
        Me.Controls.Add(Me.LabelUch)
        Me.Controls.Add(Me.ListBoxUch)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.DataGridViewVid)
        Me.Controls.Add(Me.ButtonOk)
        Me.Controls.Add(Me.DataGridViewListov)
        Me.ForeColor = System.Drawing.SystemColors.InfoText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.HelpProviderGrList.SetHelpNavigator(Me, CType(resources.GetObject("$this.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmWwdGrList"
        Me.HelpProviderGrList.SetShowHelp(Me, CType(resources.GetObject("$this.ShowHelp"), Boolean))
        CType(Me.DataGridViewListov, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClsGranizBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewVid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClsZonKlimatBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.clsPiketBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewUgl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridViewListov As System.Windows.Forms.DataGridView
    Friend WithEvents ClsGranizBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ButtonOk As System.Windows.Forms.Button
    Friend WithEvents DataGridViewVid As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ClsZonKlimatBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ListBoxUch As System.Windows.Forms.ListBox
    Friend WithEvents RastotNachDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NameListDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents LabelUch As System.Windows.Forms.Label
    Friend WithEvents Labelklim As System.Windows.Forms.Label
    Friend WithEvents LabelList As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RastOtnachalaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PiketajDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rast As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clsPiketBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridViewUgl As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NamePiketDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RastOtnachalaDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OtmetkaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LabelWisPrfWidEkran As System.Windows.Forms.Label
    Friend WithEvents HelpProviderGrList As System.Windows.Forms.HelpProvider
End Class
