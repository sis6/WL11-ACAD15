<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUch))
        Me.ProfilNBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.ProfilNBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsProfil = New OperBD.dsProfil
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ProfilNBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.FillToolStrip = New System.Windows.Forms.ToolStrip
        Me.IUiduchToolStripLabel = New System.Windows.Forms.ToolStripLabel
        Me.NameUchToolStripTextBox = New System.Windows.Forms.ToolStripTextBox
        Me.FillToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSohr = New System.Windows.Forms.ToolStripButton
        Me.ProfilNDataGridView = New System.Windows.Forms.DataGridView
        Me.gUIdTchk = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NameTchkDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PiketajDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OtmetkaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OtmetkaPrDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OtmetkaLwDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OsobBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.OsobDataGridView = New System.Windows.Forms.DataGridView
        Me.TipSoorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UgolPoworotaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UgolPoworotaDataGridView = New System.Windows.Forms.DataGridView
        Me.UIdTchkDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UgolPoworotDataGridViewTextBoxColumn = New OperBD.MaskedTextBoxColumn
        Me.PikUgodNBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PikUgodNDataGridView = New System.Windows.Forms.DataGridView
        Me.UIdTchkDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TipDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MaskedTextBox1 = New System.Windows.Forms.MaskedTextBox
        Me.ProfilNTableAdapter = New OperBD.dsProfilTableAdapters.ProfilNTableAdapter
        Me.TableAdapterManager = New OperBD.dsProfilTableAdapters.TableAdapterManager
        Me.OsobTableAdapter = New OperBD.dsProfilTableAdapters.OsobTableAdapter
        Me.PikUgodNTableAdapter = New OperBD.dsProfilTableAdapters.PikUgodNTableAdapter
        Me.TipSoorTableAdapter = New OperBD.dsProfilTableAdapters.TipSoorTableAdapter
        Me.UgolPoworotaTableAdapter = New OperBD.dsProfilTableAdapters.UgolPoworotaTableAdapter
        Me.ProfilATableAdapter = New OperBD.dsProfilTableAdapters.ProfilATableAdapter
        Me.ProfilABS = New System.Windows.Forms.BindingSource(Me.components)
        Me.IdTipSoor = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.UIdTchkDataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Param1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Param2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Param3DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Param4DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OpisDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.ProfilNBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ProfilNBindingNavigator.SuspendLayout()
        CType(Me.ProfilNBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsProfil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FillToolStrip.SuspendLayout()
        CType(Me.ProfilNDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OsobBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OsobDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TipSoorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UgolPoworotaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UgolPoworotaDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PikUgodNBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PikUgodNDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProfilABS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ProfilNBindingNavigator
        '
        Me.ProfilNBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.ProfilNBindingNavigator.BindingSource = Me.ProfilNBindingSource
        Me.ProfilNBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.ProfilNBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.ProfilNBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.ProfilNBindingNavigatorSaveItem})
        Me.ProfilNBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.ProfilNBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.ProfilNBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.ProfilNBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.ProfilNBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.ProfilNBindingNavigator.Name = "ProfilNBindingNavigator"
        Me.ProfilNBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.ProfilNBindingNavigator.Size = New System.Drawing.Size(1254, 25)
        Me.ProfilNBindingNavigator.TabIndex = 0
        Me.ProfilNBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        '
        'ProfilNBindingSource
        '
        Me.ProfilNBindingSource.DataMember = "ProfilN"
        Me.ProfilNBindingSource.DataSource = Me.DsProfil
        '
        'DsProfil
        '
        Me.DsProfil.DataSetName = "dsProfil"
        Me.DsProfil.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(36, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 21)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ProfilNBindingNavigatorSaveItem
        '
        Me.ProfilNBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ProfilNBindingNavigatorSaveItem.Image = CType(resources.GetObject("ProfilNBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.ProfilNBindingNavigatorSaveItem.Name = "ProfilNBindingNavigatorSaveItem"
        Me.ProfilNBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.ProfilNBindingNavigatorSaveItem.Text = "Save Data"
        '
        'FillToolStrip
        '
        Me.FillToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IUiduchToolStripLabel, Me.NameUchToolStripTextBox, Me.FillToolStripButton, Me.ToolStripSeparator1, Me.ToolStripSohr})
        Me.FillToolStrip.Location = New System.Drawing.Point(0, 25)
        Me.FillToolStrip.Name = "FillToolStrip"
        Me.FillToolStrip.Size = New System.Drawing.Size(1254, 25)
        Me.FillToolStrip.TabIndex = 1
        Me.FillToolStrip.Text = "FillToolStrip"
        '
        'IUiduchToolStripLabel
        '
        Me.IUiduchToolStripLabel.Name = "IUiduchToolStripLabel"
        Me.IUiduchToolStripLabel.Size = New System.Drawing.Size(53, 22)
        Me.IUiduchToolStripLabel.Text = "Участок:"
        '
        'NameUchToolStripTextBox
        '
        Me.NameUchToolStripTextBox.Name = "NameUchToolStripTextBox"
        Me.NameUchToolStripTextBox.Size = New System.Drawing.Size(200, 25)
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
        'ToolStripSohr
        '
        Me.ToolStripSohr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSohr.Image = Global.OperBD.My.Resources.Resources.saveHS
        Me.ToolStripSohr.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSohr.Name = "ToolStripSohr"
        Me.ToolStripSohr.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripSohr.Text = "ToolStripButton1"
        '
        'ProfilNDataGridView
        '
        Me.ProfilNDataGridView.AutoGenerateColumns = False
        Me.ProfilNDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ProfilNDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gUIdTchk, Me.NameTchkDataGridViewTextBoxColumn, Me.PiketajDataGridViewTextBoxColumn, Me.OtmetkaDataGridViewTextBoxColumn, Me.OtmetkaPrDataGridViewTextBoxColumn, Me.OtmetkaLwDataGridViewTextBoxColumn})
        Me.ProfilNDataGridView.DataSource = Me.ProfilNBindingSource
        Me.ProfilNDataGridView.Location = New System.Drawing.Point(24, 53)
        Me.ProfilNDataGridView.Name = "ProfilNDataGridView"
        Me.ProfilNDataGridView.RowHeadersVisible = False
        Me.ProfilNDataGridView.Size = New System.Drawing.Size(525, 523)
        Me.ProfilNDataGridView.TabIndex = 2
        '
        'gUIdTchk
        '
        Me.gUIdTchk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.gUIdTchk.DataPropertyName = "UIdTchk"
        Me.gUIdTchk.HeaderText = "UIdTchk"
        Me.gUIdTchk.Name = "gUIdTchk"
        Me.gUIdTchk.Width = 74
        '
        'NameTchkDataGridViewTextBoxColumn
        '
        Me.NameTchkDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.NameTchkDataGridViewTextBoxColumn.DataPropertyName = "NameTchk"
        Me.NameTchkDataGridViewTextBoxColumn.HeaderText = "Имя"
        Me.NameTchkDataGridViewTextBoxColumn.Name = "NameTchkDataGridViewTextBoxColumn"
        '
        'PiketajDataGridViewTextBoxColumn
        '
        Me.PiketajDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.PiketajDataGridViewTextBoxColumn.DataPropertyName = "Piketaj"
        Me.PiketajDataGridViewTextBoxColumn.HeaderText = "Пикетаж"
        Me.PiketajDataGridViewTextBoxColumn.Name = "PiketajDataGridViewTextBoxColumn"
        Me.PiketajDataGridViewTextBoxColumn.Width = 77
        '
        'OtmetkaDataGridViewTextBoxColumn
        '
        Me.OtmetkaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.OtmetkaDataGridViewTextBoxColumn.DataPropertyName = "Otmetka"
        Me.OtmetkaDataGridViewTextBoxColumn.HeaderText = "Отметка"
        Me.OtmetkaDataGridViewTextBoxColumn.Name = "OtmetkaDataGridViewTextBoxColumn"
        Me.OtmetkaDataGridViewTextBoxColumn.Width = 76
        '
        'OtmetkaPrDataGridViewTextBoxColumn
        '
        Me.OtmetkaPrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.OtmetkaPrDataGridViewTextBoxColumn.DataPropertyName = "OtmetkaPr"
        Me.OtmetkaPrDataGridViewTextBoxColumn.HeaderText = "Отм. Пр"
        Me.OtmetkaPrDataGridViewTextBoxColumn.Name = "OtmetkaPrDataGridViewTextBoxColumn"
        Me.OtmetkaPrDataGridViewTextBoxColumn.Width = 73
        '
        'OtmetkaLwDataGridViewTextBoxColumn
        '
        Me.OtmetkaLwDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.OtmetkaLwDataGridViewTextBoxColumn.DataPropertyName = "OtmetkaLw"
        Me.OtmetkaLwDataGridViewTextBoxColumn.HeaderText = "Отм. Лв"
        Me.OtmetkaLwDataGridViewTextBoxColumn.Name = "OtmetkaLwDataGridViewTextBoxColumn"
        Me.OtmetkaLwDataGridViewTextBoxColumn.Width = 73
        '
        'OsobBindingSource
        '
        Me.OsobBindingSource.DataMember = "ProfilN_Osob"
        Me.OsobBindingSource.DataSource = Me.ProfilNBindingSource
        '
        'OsobDataGridView
        '
        Me.OsobDataGridView.AutoGenerateColumns = False
        Me.OsobDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.OsobDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdTipSoor, Me.UIdTchkDataGridViewTextBoxColumn3, Me.Param1DataGridViewTextBoxColumn, Me.Param2DataGridViewTextBoxColumn, Me.Param3DataGridViewTextBoxColumn, Me.Param4DataGridViewTextBoxColumn, Me.OpisDataGridViewTextBoxColumn})
        Me.OsobDataGridView.DataSource = Me.OsobBindingSource
        Me.OsobDataGridView.Location = New System.Drawing.Point(555, 114)
        Me.OsobDataGridView.Name = "OsobDataGridView"
        Me.OsobDataGridView.RowHeadersVisible = False
        Me.OsobDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.OsobDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.OsobDataGridView.Size = New System.Drawing.Size(612, 52)
        Me.OsobDataGridView.TabIndex = 3
        '
        'TipSoorBindingSource
        '
        Me.TipSoorBindingSource.DataMember = "TipSoor"
        Me.TipSoorBindingSource.DataSource = Me.DsProfil
        '
        'UgolPoworotaBindingSource
        '
        Me.UgolPoworotaBindingSource.DataMember = "FK_UgolPoworota_ProfilN"
        Me.UgolPoworotaBindingSource.DataSource = Me.ProfilNBindingSource
        '
        'UgolPoworotaDataGridView
        '
        Me.UgolPoworotaDataGridView.AutoGenerateColumns = False
        Me.UgolPoworotaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.UgolPoworotaDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.UIdTchkDataGridViewTextBoxColumn2, Me.UgolPoworotDataGridViewTextBoxColumn})
        Me.UgolPoworotaDataGridView.DataSource = Me.UgolPoworotaBindingSource
        Me.UgolPoworotaDataGridView.Location = New System.Drawing.Point(555, 53)
        Me.UgolPoworotaDataGridView.Name = "UgolPoworotaDataGridView"
        Me.UgolPoworotaDataGridView.RowHeadersVisible = False
        Me.UgolPoworotaDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.UgolPoworotaDataGridView.Size = New System.Drawing.Size(200, 41)
        Me.UgolPoworotaDataGridView.TabIndex = 4
        '
        'UIdTchkDataGridViewTextBoxColumn2
        '
        Me.UIdTchkDataGridViewTextBoxColumn2.DataPropertyName = "UIdTchk"
        Me.UIdTchkDataGridViewTextBoxColumn2.HeaderText = "UIdTchk"
        Me.UIdTchkDataGridViewTextBoxColumn2.Name = "UIdTchkDataGridViewTextBoxColumn2"
        Me.UIdTchkDataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'UgolPoworotDataGridViewTextBoxColumn
        '
        Me.UgolPoworotDataGridViewTextBoxColumn.DataPropertyName = "UgolPoworot"
        Me.UgolPoworotDataGridViewTextBoxColumn.HeaderText = "UgolPoworot"
        Me.UgolPoworotDataGridViewTextBoxColumn.Name = "UgolPoworotDataGridViewTextBoxColumn"
        Me.UgolPoworotDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.UgolPoworotDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'PikUgodNBindingSource
        '
        Me.PikUgodNBindingSource.DataMember = "FK_PikUgodN_ProfilN"
        Me.PikUgodNBindingSource.DataSource = Me.ProfilNBindingSource
        '
        'PikUgodNDataGridView
        '
        Me.PikUgodNDataGridView.AutoGenerateColumns = False
        Me.PikUgodNDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PikUgodNDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.UIdTchkDataGridViewTextBoxColumn1, Me.TipDataGridViewTextBoxColumn})
        Me.PikUgodNDataGridView.DataSource = Me.PikUgodNBindingSource
        Me.PikUgodNDataGridView.Location = New System.Drawing.Point(824, 172)
        Me.PikUgodNDataGridView.Name = "PikUgodNDataGridView"
        Me.PikUgodNDataGridView.RowHeadersVisible = False
        Me.PikUgodNDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.PikUgodNDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.PikUgodNDataGridView.Size = New System.Drawing.Size(204, 55)
        Me.PikUgodNDataGridView.TabIndex = 5
        '
        'UIdTchkDataGridViewTextBoxColumn1
        '
        Me.UIdTchkDataGridViewTextBoxColumn1.DataPropertyName = "UIdTchk"
        Me.UIdTchkDataGridViewTextBoxColumn1.HeaderText = "UIdTchk"
        Me.UIdTchkDataGridViewTextBoxColumn1.Name = "UIdTchkDataGridViewTextBoxColumn1"
        '
        'TipDataGridViewTextBoxColumn
        '
        Me.TipDataGridViewTextBoxColumn.DataPropertyName = "Tip"
        Me.TipDataGridViewTextBoxColumn.HeaderText = "Tip"
        Me.TipDataGridViewTextBoxColumn.Name = "TipDataGridViewTextBoxColumn"
        '
        'MaskedTextBox1
        '
        Me.MaskedTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UgolPoworotaBindingSource, "UgolPoworot", True))
        Me.MaskedTextBox1.Location = New System.Drawing.Point(783, 65)
        Me.MaskedTextBox1.Mask = "L999\°99'99"""
        Me.MaskedTextBox1.Name = "MaskedTextBox1"
        Me.MaskedTextBox1.Size = New System.Drawing.Size(100, 20)
        Me.MaskedTextBox1.TabIndex = 6
        '
        'ProfilNTableAdapter
        '
        Me.ProfilNTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.OsobTableAdapter = Me.OsobTableAdapter
        Me.TableAdapterManager.PikUgodNTableAdapter = Me.PikUgodNTableAdapter
        Me.TableAdapterManager.ProfilNTableAdapter = Me.ProfilNTableAdapter
        Me.TableAdapterManager.TablKlimNTableAdapter = Nothing
        Me.TableAdapterManager.TipSoorTableAdapter = Me.TipSoorTableAdapter
        Me.TableAdapterManager.UgolPoworotaTableAdapter = Me.UgolPoworotaTableAdapter
        Me.TableAdapterManager.UpdateOrder = OperBD.dsProfilTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'OsobTableAdapter
        '
        Me.OsobTableAdapter.ClearBeforeFill = True
        '
        'PikUgodNTableAdapter
        '
        Me.PikUgodNTableAdapter.ClearBeforeFill = True
        '
        'TipSoorTableAdapter
        '
        Me.TipSoorTableAdapter.ClearBeforeFill = True
        '
        'UgolPoworotaTableAdapter
        '
        Me.UgolPoworotaTableAdapter.ClearBeforeFill = True
        '
        'ProfilATableAdapter
        '
        Me.ProfilATableAdapter.ClearBeforeFill = True
        '
        'ProfilABS
        '
        Me.ProfilABS.DataMember = "ProfilA"
        Me.ProfilABS.DataSource = Me.DsProfil
        '
        'IdTipSoor
        '
        Me.IdTipSoor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.IdTipSoor.DataPropertyName = "IdTipSoor"
        Me.IdTipSoor.DataSource = Me.TipSoorBindingSource
        Me.IdTipSoor.DisplayMember = "NameTip"
        Me.IdTipSoor.HeaderText = "Пересеч."
        Me.IdTipSoor.Name = "IdTipSoor"
        Me.IdTipSoor.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IdTipSoor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.IdTipSoor.ValueMember = "IdTipSoor"
        Me.IdTipSoor.Width = 78
        '
        'UIdTchkDataGridViewTextBoxColumn3
        '
        Me.UIdTchkDataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.UIdTchkDataGridViewTextBoxColumn3.DataPropertyName = "UIdTchk"
        Me.UIdTchkDataGridViewTextBoxColumn3.HeaderText = "UIdTchk"
        Me.UIdTchkDataGridViewTextBoxColumn3.Name = "UIdTchkDataGridViewTextBoxColumn3"
        Me.UIdTchkDataGridViewTextBoxColumn3.Width = 74
        '
        'Param1DataGridViewTextBoxColumn
        '
        Me.Param1DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Param1DataGridViewTextBoxColumn.DataPropertyName = "Param1"
        Me.Param1DataGridViewTextBoxColumn.HeaderText = "Отм1"
        Me.Param1DataGridViewTextBoxColumn.Name = "Param1DataGridViewTextBoxColumn"
        Me.Param1DataGridViewTextBoxColumn.Width = 59
        '
        'Param2DataGridViewTextBoxColumn
        '
        Me.Param2DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Param2DataGridViewTextBoxColumn.DataPropertyName = "Param2"
        Me.Param2DataGridViewTextBoxColumn.HeaderText = "Отм2"
        Me.Param2DataGridViewTextBoxColumn.Name = "Param2DataGridViewTextBoxColumn"
        Me.Param2DataGridViewTextBoxColumn.Width = 59
        '
        'Param3DataGridViewTextBoxColumn
        '
        Me.Param3DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Param3DataGridViewTextBoxColumn.DataPropertyName = "Param3"
        Me.Param3DataGridViewTextBoxColumn.HeaderText = "Отм3"
        Me.Param3DataGridViewTextBoxColumn.Name = "Param3DataGridViewTextBoxColumn"
        Me.Param3DataGridViewTextBoxColumn.Width = 59
        '
        'Param4DataGridViewTextBoxColumn
        '
        Me.Param4DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Param4DataGridViewTextBoxColumn.DataPropertyName = "Param4"
        Me.Param4DataGridViewTextBoxColumn.HeaderText = "Отм4"
        Me.Param4DataGridViewTextBoxColumn.Name = "Param4DataGridViewTextBoxColumn"
        Me.Param4DataGridViewTextBoxColumn.Width = 59
        '
        'OpisDataGridViewTextBoxColumn
        '
        Me.OpisDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.OpisDataGridViewTextBoxColumn.DataPropertyName = "Opis"
        Me.OpisDataGridViewTextBoxColumn.HeaderText = "Описание"
        Me.OpisDataGridViewTextBoxColumn.Name = "OpisDataGridViewTextBoxColumn"
        '
        'FrmUch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1254, 672)
        Me.Controls.Add(Me.MaskedTextBox1)
        Me.Controls.Add(Me.PikUgodNDataGridView)
        Me.Controls.Add(Me.UgolPoworotaDataGridView)
        Me.Controls.Add(Me.OsobDataGridView)
        Me.Controls.Add(Me.ProfilNDataGridView)
        Me.Controls.Add(Me.FillToolStrip)
        Me.Controls.Add(Me.ProfilNBindingNavigator)
        Me.Name = "FrmUch"
        Me.Text = "FrmUch"
        CType(Me.ProfilNBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ProfilNBindingNavigator.ResumeLayout(False)
        Me.ProfilNBindingNavigator.PerformLayout()
        CType(Me.ProfilNBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsProfil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FillToolStrip.ResumeLayout(False)
        Me.FillToolStrip.PerformLayout()
        CType(Me.ProfilNDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OsobBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OsobDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TipSoorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UgolPoworotaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UgolPoworotaDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PikUgodNBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PikUgodNDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProfilABS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ProfilNBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProfilNTableAdapter As OperBD.dsProfilTableAdapters.ProfilNTableAdapter
    Friend WithEvents TableAdapterManager As OperBD.dsProfilTableAdapters.TableAdapterManager
    Friend WithEvents ProfilNBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ProfilNBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents FillToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents IUiduchToolStripLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents NameUchToolStripTextBox As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents FillToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ProfilNDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents OsobTableAdapter As OperBD.dsProfilTableAdapters.OsobTableAdapter
    Friend WithEvents OsobBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents UgolPoworotaTableAdapter As OperBD.dsProfilTableAdapters.UgolPoworotaTableAdapter
    Friend WithEvents OsobDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents UgolPoworotaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PikUgodNTableAdapter As OperBD.dsProfilTableAdapters.PikUgodNTableAdapter
    Friend WithEvents UgolPoworotaDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents PikUgodNBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PikUgodNDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents ProfilATableAdapter As OperBD.dsProfilTableAdapters.ProfilATableAdapter
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSohr As System.Windows.Forms.ToolStripButton
    Friend WithEvents TipSoorTableAdapter As OperBD.dsProfilTableAdapters.TipSoorTableAdapter
    Friend WithEvents TipSoorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsProfil As OperBD.dsProfil
    Friend WithEvents ProfilABS As System.Windows.Forms.BindingSource
    Friend WithEvents UIdTchkDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaskedTextBox1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents UIdTchkDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UgolPoworotDataGridViewTextBoxColumn As OperBD.MaskedTextBoxColumn
    Friend WithEvents gUIdTchk As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NameTchkDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PiketajDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OtmetkaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OtmetkaPrDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OtmetkaLwDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdTipSoor As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents UIdTchkDataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Param1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Param2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Param3DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Param4DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OpisDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
