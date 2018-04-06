<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWibUch
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
        Me.components = New System.ComponentModel.Container
        Dim UidUchLabel As System.Windows.Forms.Label
        Dim PutExelLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWibUch))
        Me.FillToolStrip = New System.Windows.Forms.ToolStrip
        Me.ObToolStripLabel = New System.Windows.Forms.ToolStripLabel
        Me.ObToolStripCBox = New System.Windows.Forms.ToolStripComboBox
        Me.UnomToolStripLabel = New System.Windows.Forms.ToolStripLabel
        Me.UnomToolStripCombBox = New System.Windows.Forms.ToolStripComboBox
        Me.FillToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripUchDann = New System.Windows.Forms.ToolStripButton
        Me.ToolStripModUch = New System.Windows.Forms.ToolStripButton
        Me.AddNewUch = New System.Windows.Forms.ToolStripButton
        Me.KnFileExcel = New System.Windows.Forms.ToolStripButton
        Me.ToolStripMod_Xls = New System.Windows.Forms.ToolStripButton
        Me.FSpLinRegionpDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CbPsEnd = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.PObjectESSpBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsUpr = New OperBD.dsUpr
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CbPsBeg = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.PObjectESSpBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FSpLinRegionpBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TrassLinBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TrassLinDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UchastkiNBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UchastkiNDataGridView = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.FileExcelBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UidUchTextBox = New System.Windows.Forms.TextBox
        Me.PutExelTextBox = New System.Windows.Forms.TextBox
        Me.FindFileExcel = New System.Windows.Forms.OpenFileDialog
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FSpLinRegionpTableAdapter = New OperBD.dsUprTableAdapters.fSpLinRegionpTableAdapter
        Me.TableAdapterManager = New OperBD.dsUprTableAdapters.TableAdapterManager
        Me.TrassLinTableAdapter = New OperBD.dsUprTableAdapters.TrassLinTableAdapter
        Me.UchastkiNTableAdapter = New OperBD.dsUprTableAdapters.uchastkiNTableAdapter
        Me.PObjectESSpTableAdapter = New OperBD.dsUprTableAdapters.pObjectESSpTableAdapter
        Me.FileExcelTableAdapter = New OperBD.dsUprTableAdapters.FileExcelTableAdapter
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NameUch = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataMod = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataModOp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataW = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Polz = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Sost = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SostOp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UIdUch = New System.Windows.Forms.DataGridViewTextBoxColumn
        UidUchLabel = New System.Windows.Forms.Label
        PutExelLabel = New System.Windows.Forms.Label
        Me.FillToolStrip.SuspendLayout()
        CType(Me.FSpLinRegionpDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PObjectESSpBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsUpr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PObjectESSpBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FSpLinRegionpBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrassLinBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrassLinDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UchastkiNBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UchastkiNDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FileExcelBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UidUchLabel
        '
        UidUchLabel.AutoSize = True
        UidUchLabel.Location = New System.Drawing.Point(930, 346)
        UidUchLabel.Name = "UidUchLabel"
        UidUchLabel.Size = New System.Drawing.Size(49, 13)
        UidUchLabel.TabIndex = 7
        UidUchLabel.Text = "Uid Uch:"
        AddHandler UidUchLabel.Click, AddressOf Me.UidUchLabel_Click
        '
        'PutExelLabel
        '
        PutExelLabel.AutoSize = True
        PutExelLabel.Location = New System.Drawing.Point(930, 372)
        PutExelLabel.Name = "PutExelLabel"
        PutExelLabel.Size = New System.Drawing.Size(49, 13)
        PutExelLabel.TabIndex = 9
        PutExelLabel.Text = "Put Exel:"
        '
        'FillToolStrip
        '
        Me.FillToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ObToolStripLabel, Me.ObToolStripCBox, Me.UnomToolStripLabel, Me.UnomToolStripCombBox, Me.FillToolStripButton, Me.ToolStripSeparator1, Me.ToolStripUchDann, Me.ToolStripModUch, Me.AddNewUch, Me.KnFileExcel, Me.ToolStripMod_Xls})
        Me.FillToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.FillToolStrip.Name = "FillToolStrip"
        Me.FillToolStrip.Size = New System.Drawing.Size(1407, 25)
        Me.FillToolStrip.TabIndex = 1
        Me.FillToolStrip.Text = "FillToolStrip"
        '
        'ObToolStripLabel
        '
        Me.ObToolStripLabel.Name = "ObToolStripLabel"
        Me.ObToolStripLabel.Size = New System.Drawing.Size(25, 22)
        Me.ObToolStripLabel.Text = "Ob:"
        '
        'ObToolStripCBox
        '
        Me.ObToolStripCBox.Name = "ObToolStripCBox"
        Me.ObToolStripCBox.Size = New System.Drawing.Size(250, 25)
        '
        'UnomToolStripLabel
        '
        Me.UnomToolStripLabel.Name = "UnomToolStripLabel"
        Me.UnomToolStripLabel.Size = New System.Drawing.Size(37, 22)
        Me.UnomToolStripLabel.Text = "unom:"
        '
        'UnomToolStripCombBox
        '
        Me.UnomToolStripCombBox.Name = "UnomToolStripCombBox"
        Me.UnomToolStripCombBox.Size = New System.Drawing.Size(100, 25)
        '
        'FillToolStripButton
        '
        Me.FillToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.FillToolStripButton.Name = "FillToolStripButton"
        Me.FillToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.FillToolStripButton.Text = "Fill"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripUchDann
        '
        Me.ToolStripUchDann.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripUchDann.Image = CType(resources.GetObject("ToolStripUchDann.Image"), System.Drawing.Image)
        Me.ToolStripUchDann.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripUchDann.Name = "ToolStripUchDann"
        Me.ToolStripUchDann.Size = New System.Drawing.Size(71, 22)
        Me.ToolStripUchDann.Text = "Данные Уч."
        Me.ToolStripUchDann.ToolTipText = "Данные Участка в Базе данных"
        '
        'ToolStripModUch
        '
        Me.ToolStripModUch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripModUch.Image = CType(resources.GetObject("ToolStripModUch.Image"), System.Drawing.Image)
        Me.ToolStripModUch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripModUch.Name = "ToolStripModUch"
        Me.ToolStripModUch.Size = New System.Drawing.Size(67, 22)
        Me.ToolStripModUch.Text = "модель уч."
        Me.ToolStripModUch.ToolTipText = "построить модель участка и расстановеи"
        '
        'AddNewUch
        '
        Me.AddNewUch.Image = CType(resources.GetObject("AddNewUch.Image"), System.Drawing.Image)
        Me.AddNewUch.Name = "AddNewUch"
        Me.AddNewUch.RightToLeftAutoMirrorImage = True
        Me.AddNewUch.Size = New System.Drawing.Size(44, 22)
        Me.AddNewUch.Text = "Уч."
        Me.AddNewUch.ToolTipText = "Добавить участок"
        '
        'KnFileExcel
        '
        Me.KnFileExcel.Image = Global.OperBD.My.Resources.Resources.openHS
        Me.KnFileExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.KnFileExcel.Name = "KnFileExcel"
        Me.KnFileExcel.Size = New System.Drawing.Size(40, 22)
        Me.KnFileExcel.Text = "xls"
        Me.KnFileExcel.ToolTipText = "Выбрать файл Excel c описанием участка"
        '
        'ToolStripMod_Xls
        '
        Me.ToolStripMod_Xls.Image = Global.OperBD.My.Resources.Resources.ImportXML
        Me.ToolStripMod_Xls.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripMod_Xls.Name = "ToolStripMod_Xls"
        Me.ToolStripMod_Xls.Size = New System.Drawing.Size(48, 22)
        Me.ToolStripMod_Xls.Tag = "Мод"
        Me.ToolStripMod_Xls.Text = "Мод"
        Me.ToolStripMod_Xls.ToolTipText = "Модель участка из Excel"
        '
        'FSpLinRegionpDataGridView
        '
        Me.FSpLinRegionpDataGridView.AutoGenerateColumns = False
        Me.FSpLinRegionpDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.FSpLinRegionpDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.FSpLinRegionpDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn8, Me.CbPsEnd, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn1, Me.CbPsBeg})
        Me.FSpLinRegionpDataGridView.DataSource = Me.FSpLinRegionpBindingSource
        Me.FSpLinRegionpDataGridView.Location = New System.Drawing.Point(0, 45)
        Me.FSpLinRegionpDataGridView.Name = "FSpLinRegionpDataGridView"
        Me.FSpLinRegionpDataGridView.Size = New System.Drawing.Size(790, 259)
        Me.FSpLinRegionpDataGridView.TabIndex = 2
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "DataW"
        Me.DataGridViewTextBoxColumn7.HeaderText = "DataW"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 66
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Name"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "polz"
        Me.DataGridViewTextBoxColumn8.HeaderText = "polz"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 51
        '
        'CbPsEnd
        '
        Me.CbPsEnd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.CbPsEnd.DataPropertyName = "IndeksPSe"
        Me.CbPsEnd.DataSource = Me.PObjectESSpBindingSource1
        Me.CbPsEnd.DisplayMember = "Name"
        Me.CbPsEnd.HeaderText = "IndeksPSe"
        Me.CbPsEnd.Name = "CbPsEnd"
        Me.CbPsEnd.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CbPsEnd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.CbPsEnd.ValueMember = "Indeks"
        Me.CbPsEnd.Width = 84
        '
        'PObjectESSpBindingSource1
        '
        Me.PObjectESSpBindingSource1.DataMember = "pObjectESSp"
        Me.PObjectESSpBindingSource1.DataSource = Me.DsUpr
        '
        'DsUpr
        '
        Me.DsUpr.DataSetName = "dsUpr"
        Me.DsUpr.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Tip"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Tip"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 47
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Unom"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Unom"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 60
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "IndeksL"
        Me.DataGridViewTextBoxColumn1.HeaderText = "IndeksL"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 70
        '
        'CbPsBeg
        '
        Me.CbPsBeg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.CbPsBeg.DataPropertyName = "IndeksPSb"
        Me.CbPsBeg.DataSource = Me.PObjectESSpBindingSource
        Me.CbPsBeg.DisplayMember = "Name"
        Me.CbPsBeg.HeaderText = "IndeksPSb"
        Me.CbPsBeg.Name = "CbPsBeg"
        Me.CbPsBeg.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CbPsBeg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.CbPsBeg.ValueMember = "Indeks"
        Me.CbPsBeg.Width = 84
        '
        'PObjectESSpBindingSource
        '
        Me.PObjectESSpBindingSource.DataMember = "pObjectESSp"
        Me.PObjectESSpBindingSource.DataSource = Me.DsUpr
        '
        'FSpLinRegionpBindingSource
        '
        Me.FSpLinRegionpBindingSource.DataMember = "fSpLinRegionp"
        Me.FSpLinRegionpBindingSource.DataSource = Me.DsUpr
        '
        'TrassLinBindingSource
        '
        Me.TrassLinBindingSource.DataMember = "fSpLinRegionp_TrassLin"
        Me.TrassLinBindingSource.DataSource = Me.FSpLinRegionpBindingSource
        '
        'TrassLinDataGridView
        '
        Me.TrassLinDataGridView.AutoGenerateColumns = False
        Me.TrassLinDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.TrassLinDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TrassLinDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn16, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn10})
        Me.TrassLinDataGridView.DataSource = Me.TrassLinBindingSource
        Me.TrassLinDataGridView.Location = New System.Drawing.Point(796, 45)
        Me.TrassLinDataGridView.Name = "TrassLinDataGridView"
        Me.TrassLinDataGridView.Size = New System.Drawing.Size(570, 220)
        Me.TrassLinDataGridView.TabIndex = 3
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "DataW"
        Me.DataGridViewTextBoxColumn13.HeaderText = "DataW"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.Width = 66
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "Polz"
        Me.DataGridViewTextBoxColumn14.HeaderText = "Polz"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "IndeksL"
        Me.DataGridViewTextBoxColumn15.HeaderText = "IndeksL"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "IndeksN"
        Me.DataGridViewTextBoxColumn16.HeaderText = "IndeksN"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "NameTr"
        Me.DataGridViewTextBoxColumn11.HeaderText = "NameTr"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "IndeksT"
        Me.DataGridViewTextBoxColumn10.HeaderText = "IndeksT"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        '
        'UchastkiNBindingSource
        '
        Me.UchastkiNBindingSource.DataMember = "FK_uchastkiN_TrassLin"
        Me.UchastkiNBindingSource.DataSource = Me.TrassLinBindingSource
        '
        'UchastkiNDataGridView
        '
        Me.UchastkiNDataGridView.AutoGenerateColumns = False
        Me.UchastkiNDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.UchastkiNDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.UchastkiNDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn18, Me.NameUch, Me.DataMod, Me.DataModOp, Me.DataW, Me.Polz, Me.Sost, Me.SostOp, Me.DataGridViewTextBoxColumn25, Me.UIdUch})
        Me.UchastkiNDataGridView.DataSource = Me.UchastkiNBindingSource
        Me.UchastkiNDataGridView.Location = New System.Drawing.Point(0, 323)
        Me.UchastkiNDataGridView.Name = "UchastkiNDataGridView"
        Me.UchastkiNDataGridView.Size = New System.Drawing.Size(924, 317)
        Me.UchastkiNDataGridView.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(0, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Линии Электропередачи(ЛЭП)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(793, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Трассы ЛЭП"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(-3, 307)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Участки трасс ЛЭП"
        '
        'FileExcelBindingSource
        '
        Me.FileExcelBindingSource.DataMember = "uchastkiN_FileExcel"
        Me.FileExcelBindingSource.DataSource = Me.UchastkiNBindingSource
        '
        'UidUchTextBox
        '
        Me.UidUchTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FileExcelBindingSource, "UidUch", True))
        Me.UidUchTextBox.Location = New System.Drawing.Point(985, 343)
        Me.UidUchTextBox.Name = "UidUchTextBox"
        Me.UidUchTextBox.Size = New System.Drawing.Size(149, 20)
        Me.UidUchTextBox.TabIndex = 8
        '
        'PutExelTextBox
        '
        Me.PutExelTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FileExcelBindingSource, "PutExel", True))
        Me.PutExelTextBox.Location = New System.Drawing.Point(985, 369)
        Me.PutExelTextBox.Name = "PutExelTextBox"
        Me.PutExelTextBox.Size = New System.Drawing.Size(410, 20)
        Me.PutExelTextBox.TabIndex = 10
        '
        'FindFileExcel
        '
        Me.FindFileExcel.FileName = "Искать файл Excel"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Unom"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Unom"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "DataW"
        Me.DataGridViewTextBoxColumn6.HeaderText = "DataW"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "IndeksN"
        Me.DataGridViewTextBoxColumn9.HeaderText = "IndeksN"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "IndeksT"
        Me.DataGridViewTextBoxColumn12.HeaderText = "IndeksT"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "DataMod"
        Me.DataGridViewTextBoxColumn17.HeaderText = "DataMod"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.Width = 76
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "DataW"
        Me.DataGridViewTextBoxColumn19.HeaderText = "DataW"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.Width = 66
        '
        'FSpLinRegionpTableAdapter
        '
        Me.FSpLinRegionpTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.FileExcelTableAdapter = Nothing
        Me.TableAdapterManager.TrassLinTableAdapter = Me.TrassLinTableAdapter
        Me.TableAdapterManager.uchastkiNTableAdapter = Me.UchastkiNTableAdapter
        Me.TableAdapterManager.UnomNTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = OperBD.dsUprTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'TrassLinTableAdapter
        '
        Me.TrassLinTableAdapter.ClearBeforeFill = True
        '
        'UchastkiNTableAdapter
        '
        Me.UchastkiNTableAdapter.ClearBeforeFill = True
        '
        'PObjectESSpTableAdapter
        '
        Me.PObjectESSpTableAdapter.ClearBeforeFill = True
        '
        'FileExcelTableAdapter
        '
        Me.FileExcelTableAdapter.ClearBeforeFill = True
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "Num"
        Me.DataGridViewTextBoxColumn18.HeaderText = "Num"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.Width = 54
        '
        'NameUch
        '
        Me.NameUch.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.NameUch.DataPropertyName = "NameUch"
        Me.NameUch.HeaderText = "NameUch"
        Me.NameUch.Name = "NameUch"
        '
        'DataMod
        '
        Me.DataMod.DataPropertyName = "DataMod"
        Me.DataMod.HeaderText = "DataMod"
        Me.DataMod.Name = "DataMod"
        Me.DataMod.Width = 76
        '
        'DataModOp
        '
        Me.DataModOp.DataPropertyName = "DataModOp"
        Me.DataModOp.HeaderText = "DataModOp"
        Me.DataModOp.Name = "DataModOp"
        Me.DataModOp.Width = 90
        '
        'DataW
        '
        Me.DataW.DataPropertyName = "DataW"
        Me.DataW.HeaderText = "DataW"
        Me.DataW.Name = "DataW"
        Me.DataW.Width = 66
        '
        'Polz
        '
        Me.Polz.DataPropertyName = "Polz"
        Me.Polz.HeaderText = "Polz"
        Me.Polz.Name = "Polz"
        Me.Polz.Width = 52
        '
        'Sost
        '
        Me.Sost.DataPropertyName = "Sost"
        Me.Sost.HeaderText = "Sost"
        Me.Sost.Name = "Sost"
        Me.Sost.Width = 53
        '
        'SostOp
        '
        Me.SostOp.DataPropertyName = "SostOp"
        Me.SostOp.HeaderText = "SostOp"
        Me.SostOp.Name = "SostOp"
        Me.SostOp.Width = 67
        '
        'DataGridViewTextBoxColumn25
        '
        Me.DataGridViewTextBoxColumn25.DataPropertyName = "IndeksT"
        Me.DataGridViewTextBoxColumn25.HeaderText = "IndeksT"
        Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
        Me.DataGridViewTextBoxColumn25.Width = 71
        '
        'UIdUch
        '
        Me.UIdUch.DataPropertyName = "UIdUch"
        Me.UIdUch.HeaderText = "UIdUch"
        Me.UIdUch.Name = "UIdUch"
        Me.UIdUch.Width = 69
        '
        'frmWibUch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1407, 672)
        Me.Controls.Add(UidUchLabel)
        Me.Controls.Add(Me.UidUchTextBox)
        Me.Controls.Add(PutExelLabel)
        Me.Controls.Add(Me.PutExelTextBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.UchastkiNDataGridView)
        Me.Controls.Add(Me.TrassLinDataGridView)
        Me.Controls.Add(Me.FSpLinRegionpDataGridView)
        Me.Controls.Add(Me.FillToolStrip)
        Me.Name = "frmWibUch"
        Me.Text = "frmWibUch"
        Me.FillToolStrip.ResumeLayout(False)
        Me.FillToolStrip.PerformLayout()
        CType(Me.FSpLinRegionpDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PObjectESSpBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsUpr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PObjectESSpBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FSpLinRegionpBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrassLinBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrassLinDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UchastkiNBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UchastkiNDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FileExcelBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DsUpr As OperBD.dsUpr
    Friend WithEvents FSpLinRegionpBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FSpLinRegionpTableAdapter As OperBD.dsUprTableAdapters.fSpLinRegionpTableAdapter
    Friend WithEvents TableAdapterManager As OperBD.dsUprTableAdapters.TableAdapterManager
    Friend WithEvents FillToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ObToolStripLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents UnomToolStripLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents FillToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents FSpLinRegionpDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents TrassLinTableAdapter As OperBD.dsUprTableAdapters.TrassLinTableAdapter
    Friend WithEvents TrassLinBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TrassLinDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents UchastkiNTableAdapter As OperBD.dsUprTableAdapters.uchastkiNTableAdapter
    Friend WithEvents UchastkiNBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents UchastkiNDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents ObToolStripCBox As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents UnomToolStripCombBox As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStripUchDann As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolStripModUch As System.Windows.Forms.ToolStripButton
    Friend WithEvents AddNewUch As System.Windows.Forms.ToolStripButton
    Friend WithEvents PObjectESSpBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PObjectESSpTableAdapter As OperBD.dsUprTableAdapters.pObjectESSpTableAdapter
    Friend WithEvents PObjectESSpBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CbPsBeg As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CbPsEnd As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KnFileExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents FileExcelBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FileExcelTableAdapter As OperBD.dsUprTableAdapters.FileExcelTableAdapter
    Friend WithEvents UidUchTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PutExelTextBox As System.Windows.Forms.TextBox
    Friend WithEvents FindFileExcel As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ToolStripMod_Xls As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NameUch As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataMod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataModOp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataW As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Polz As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SostOp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UIdUch As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
