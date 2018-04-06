<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProsmotr06
	Inherits System.Windows.Forms.Form

	'Форма переопределяет dispose для очистки списка компонентов.
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

	'Является обязательной для конструктора форм Windows Forms
	Private components As System.ComponentModel.IContainer

	'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
	'Для ее изменения используйте конструктор форм Windows Form.  
	'Не изменяйте ее в редакторе исходного кода.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Me.DataGridViewRasst = New System.Windows.Forms.DataGridView()
		Me.DsRass_06 = New BD_WL_O6.DsRass_06()
		Me.RastOpNBindingSource = New System.Windows.Forms.BindingSource(Me.components)
		Me.RastOpNTableAdapter = New BD_WL_O6.DsRass_06TableAdapters.rastOpNTableAdapter()
		Me.DataGridViewMechUsl = New System.Windows.Forms.DataGridView()
		Me.MechUslBindingSource = New System.Windows.Forms.BindingSource(Me.components)
		Me.DataGridView1 = New System.Windows.Forms.DataGridView()
		Me.ParamUchNBindingSource = New System.Windows.Forms.BindingSource(Me.components)
		Me.ParamUchNTableAdapter = New BD_WL_O6.DsRass_06TableAdapters.ParamUchNTableAdapter()
		Me.NameUchDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.NameLinDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.GnwDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.GnwGDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.GregDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.GregGolDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.TipopADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.TipopPDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DlGirlDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.MassGirlDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.NamemarkDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.NamemarkTDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DlGirlTDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.MassGirlTDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.TipopDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.RastDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.NamemarkDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Sig1TminDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Sig1TexspDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Sig7TgolDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.NamemarkTDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Sig1TminTDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Sig1TexspTDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Sig7TgolTDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.GabaritDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.NumNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.TipopDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DlinaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.WisotaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.TipDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.TipIDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		CType(Me.DataGridViewRasst, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.DsRass_06, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.RastOpNBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.DataGridViewMechUsl, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.MechUslBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.ParamUchNBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'DataGridViewRasst
		'
		Me.DataGridViewRasst.AutoGenerateColumns = False
		Me.DataGridViewRasst.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
		Me.DataGridViewRasst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.DataGridViewRasst.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NumNameDataGridViewTextBoxColumn, Me.TipopDataGridViewTextBoxColumn, Me.DlinaDataGridViewTextBoxColumn, Me.WisotaDataGridViewTextBoxColumn, Me.TipDataGridViewTextBoxColumn, Me.TipIDataGridViewTextBoxColumn})
		Me.DataGridViewRasst.DataSource = Me.RastOpNBindingSource
		Me.DataGridViewRasst.Location = New System.Drawing.Point(24, 105)
		Me.DataGridViewRasst.Name = "DataGridViewRasst"
		Me.DataGridViewRasst.RowHeadersWidth = 4
		Me.DataGridViewRasst.Size = New System.Drawing.Size(451, 256)
		Me.DataGridViewRasst.TabIndex = 0
		'
		'DsRass_06
		'
		Me.DsRass_06.DataSetName = "DsRass_06"
		Me.DsRass_06.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
		'
		'RastOpNBindingSource
		'
		Me.RastOpNBindingSource.DataMember = "rastOpN"
		Me.RastOpNBindingSource.DataSource = Me.DsRass_06
		'
		'RastOpNTableAdapter
		'
		Me.RastOpNTableAdapter.ClearBeforeFill = True
		'
		'DataGridViewMechUsl
		'
		Me.DataGridViewMechUsl.AutoGenerateColumns = False
		Me.DataGridViewMechUsl.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
		Me.DataGridViewMechUsl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.DataGridViewMechUsl.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TipopDataGridViewTextBoxColumn1, Me.RastDataGridViewTextBoxColumn, Me.NamemarkDataGridViewTextBoxColumn, Me.Sig1TminDataGridViewTextBoxColumn, Me.Sig1TexspDataGridViewTextBoxColumn, Me.Sig7TgolDataGridViewTextBoxColumn, Me.NamemarkTDataGridViewTextBoxColumn, Me.Sig1TminTDataGridViewTextBoxColumn, Me.Sig1TexspTDataGridViewTextBoxColumn, Me.Sig7TgolTDataGridViewTextBoxColumn, Me.GabaritDataGridViewTextBoxColumn})
		Me.DataGridViewMechUsl.DataSource = Me.MechUslBindingSource
		Me.DataGridViewMechUsl.Location = New System.Drawing.Point(492, 105)
		Me.DataGridViewMechUsl.Name = "DataGridViewMechUsl"
		Me.DataGridViewMechUsl.RowHeadersWidth = 4
		Me.DataGridViewMechUsl.Size = New System.Drawing.Size(812, 256)
		Me.DataGridViewMechUsl.TabIndex = 1
		'
		'MechUslBindingSource
		'
		Me.MechUslBindingSource.DataMember = "MechUsl"
		Me.MechUslBindingSource.DataSource = Me.DsRass_06
		'
		'DataGridView1
		'
		Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.DataGridView1.AutoGenerateColumns = False
		Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
		Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NameUchDataGridViewTextBoxColumn2, Me.NameLinDataGridViewTextBoxColumn2, Me.GnwDataGridViewTextBoxColumn, Me.GnwGDataGridViewTextBoxColumn, Me.GregDataGridViewTextBoxColumn, Me.GregGolDataGridViewTextBoxColumn, Me.TipopADataGridViewTextBoxColumn, Me.TipopPDataGridViewTextBoxColumn, Me.DlGirlDataGridViewTextBoxColumn, Me.MassGirlDataGridViewTextBoxColumn, Me.NamemarkDataGridViewTextBoxColumn1, Me.NamemarkTDataGridViewTextBoxColumn1, Me.DlGirlTDataGridViewTextBoxColumn, Me.MassGirlTDataGridViewTextBoxColumn})
		Me.DataGridView1.DataSource = Me.ParamUchNBindingSource
		Me.DataGridView1.Location = New System.Drawing.Point(24, -4)
		Me.DataGridView1.Name = "DataGridView1"
		Me.DataGridView1.Size = New System.Drawing.Size(1281, 94)
		Me.DataGridView1.TabIndex = 2
		'
		'ParamUchNBindingSource
		'
		Me.ParamUchNBindingSource.DataMember = "ParamUchN"
		Me.ParamUchNBindingSource.DataSource = Me.DsRass_06
		'
		'ParamUchNTableAdapter
		'
		Me.ParamUchNTableAdapter.ClearBeforeFill = True
		'
		'NameUchDataGridViewTextBoxColumn2
		'
		Me.NameUchDataGridViewTextBoxColumn2.DataPropertyName = "NameUch"
		Me.NameUchDataGridViewTextBoxColumn2.HeaderText = "NameUch"
		Me.NameUchDataGridViewTextBoxColumn2.Name = "NameUchDataGridViewTextBoxColumn2"
		Me.NameUchDataGridViewTextBoxColumn2.Width = 80
		'
		'NameLinDataGridViewTextBoxColumn2
		'
		Me.NameLinDataGridViewTextBoxColumn2.DataPropertyName = "NameLin"
		Me.NameLinDataGridViewTextBoxColumn2.HeaderText = "NameLin"
		Me.NameLinDataGridViewTextBoxColumn2.Name = "NameLinDataGridViewTextBoxColumn2"
		Me.NameLinDataGridViewTextBoxColumn2.Width = 74
		'
		'GnwDataGridViewTextBoxColumn
		'
		Me.GnwDataGridViewTextBoxColumn.DataPropertyName = "Gnw"
		Me.GnwDataGridViewTextBoxColumn.HeaderText = "Gnw"
		Me.GnwDataGridViewTextBoxColumn.Name = "GnwDataGridViewTextBoxColumn"
		Me.GnwDataGridViewTextBoxColumn.Width = 54
		'
		'GnwGDataGridViewTextBoxColumn
		'
		Me.GnwGDataGridViewTextBoxColumn.DataPropertyName = "GnwG"
		Me.GnwGDataGridViewTextBoxColumn.HeaderText = "GnwG"
		Me.GnwGDataGridViewTextBoxColumn.Name = "GnwGDataGridViewTextBoxColumn"
		Me.GnwGDataGridViewTextBoxColumn.Width = 62
		'
		'GregDataGridViewTextBoxColumn
		'
		Me.GregDataGridViewTextBoxColumn.DataPropertyName = "Greg"
		Me.GregDataGridViewTextBoxColumn.HeaderText = "Greg"
		Me.GregDataGridViewTextBoxColumn.Name = "GregDataGridViewTextBoxColumn"
		Me.GregDataGridViewTextBoxColumn.Width = 55
		'
		'GregGolDataGridViewTextBoxColumn
		'
		Me.GregGolDataGridViewTextBoxColumn.DataPropertyName = "GregGol"
		Me.GregGolDataGridViewTextBoxColumn.HeaderText = "GregGol"
		Me.GregGolDataGridViewTextBoxColumn.Name = "GregGolDataGridViewTextBoxColumn"
		Me.GregGolDataGridViewTextBoxColumn.Width = 71
		'
		'TipopADataGridViewTextBoxColumn
		'
		Me.TipopADataGridViewTextBoxColumn.DataPropertyName = "Tip_opA"
		Me.TipopADataGridViewTextBoxColumn.HeaderText = "Tip_opA"
		Me.TipopADataGridViewTextBoxColumn.Name = "TipopADataGridViewTextBoxColumn"
		Me.TipopADataGridViewTextBoxColumn.Width = 72
		'
		'TipopPDataGridViewTextBoxColumn
		'
		Me.TipopPDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.TipopPDataGridViewTextBoxColumn.DataPropertyName = "Tip_opP"
		Me.TipopPDataGridViewTextBoxColumn.HeaderText = "Tip_opP"
		Me.TipopPDataGridViewTextBoxColumn.Name = "TipopPDataGridViewTextBoxColumn"
		'
		'DlGirlDataGridViewTextBoxColumn
		'
		Me.DlGirlDataGridViewTextBoxColumn.DataPropertyName = "DlGirl"
		Me.DlGirlDataGridViewTextBoxColumn.HeaderText = "DlGirl"
		Me.DlGirlDataGridViewTextBoxColumn.Name = "DlGirlDataGridViewTextBoxColumn"
		Me.DlGirlDataGridViewTextBoxColumn.Width = 57
		'
		'MassGirlDataGridViewTextBoxColumn
		'
		Me.MassGirlDataGridViewTextBoxColumn.DataPropertyName = "MassGirl"
		Me.MassGirlDataGridViewTextBoxColumn.HeaderText = "MassGirl"
		Me.MassGirlDataGridViewTextBoxColumn.Name = "MassGirlDataGridViewTextBoxColumn"
		Me.MassGirlDataGridViewTextBoxColumn.Width = 72
		'
		'NamemarkDataGridViewTextBoxColumn1
		'
		Me.NamemarkDataGridViewTextBoxColumn1.DataPropertyName = "Name_mark"
		Me.NamemarkDataGridViewTextBoxColumn1.HeaderText = "Name_mark"
		Me.NamemarkDataGridViewTextBoxColumn1.Name = "NamemarkDataGridViewTextBoxColumn1"
		Me.NamemarkDataGridViewTextBoxColumn1.Width = 89
		'
		'NamemarkTDataGridViewTextBoxColumn1
		'
		Me.NamemarkTDataGridViewTextBoxColumn1.DataPropertyName = "Name_markT"
		Me.NamemarkTDataGridViewTextBoxColumn1.HeaderText = "Name_markT"
		Me.NamemarkTDataGridViewTextBoxColumn1.Name = "NamemarkTDataGridViewTextBoxColumn1"
		Me.NamemarkTDataGridViewTextBoxColumn1.Width = 96
		'
		'DlGirlTDataGridViewTextBoxColumn
		'
		Me.DlGirlTDataGridViewTextBoxColumn.DataPropertyName = "DlGirlT"
		Me.DlGirlTDataGridViewTextBoxColumn.HeaderText = "DlGirlT"
		Me.DlGirlTDataGridViewTextBoxColumn.Name = "DlGirlTDataGridViewTextBoxColumn"
		Me.DlGirlTDataGridViewTextBoxColumn.Width = 64
		'
		'MassGirlTDataGridViewTextBoxColumn
		'
		Me.MassGirlTDataGridViewTextBoxColumn.DataPropertyName = "MassGirlT"
		Me.MassGirlTDataGridViewTextBoxColumn.HeaderText = "MassGirlT"
		Me.MassGirlTDataGridViewTextBoxColumn.Name = "MassGirlTDataGridViewTextBoxColumn"
		Me.MassGirlTDataGridViewTextBoxColumn.Width = 79
		'
		'TipopDataGridViewTextBoxColumn1
		'
		Me.TipopDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.TipopDataGridViewTextBoxColumn1.DataPropertyName = "Tip_op"
		Me.TipopDataGridViewTextBoxColumn1.HeaderText = "Tip_op"
		Me.TipopDataGridViewTextBoxColumn1.Name = "TipopDataGridViewTextBoxColumn1"
		'
		'RastDataGridViewTextBoxColumn
		'
		Me.RastDataGridViewTextBoxColumn.DataPropertyName = "Rast"
		Me.RastDataGridViewTextBoxColumn.HeaderText = "Rast"
		Me.RastDataGridViewTextBoxColumn.Name = "RastDataGridViewTextBoxColumn"
		Me.RastDataGridViewTextBoxColumn.Width = 54
		'
		'NamemarkDataGridViewTextBoxColumn
		'
		Me.NamemarkDataGridViewTextBoxColumn.DataPropertyName = "Name_mark"
		Me.NamemarkDataGridViewTextBoxColumn.HeaderText = "Name_mark"
		Me.NamemarkDataGridViewTextBoxColumn.Name = "NamemarkDataGridViewTextBoxColumn"
		Me.NamemarkDataGridViewTextBoxColumn.Width = 89
		'
		'Sig1TminDataGridViewTextBoxColumn
		'
		Me.Sig1TminDataGridViewTextBoxColumn.DataPropertyName = "Sig1_Tmin"
		Me.Sig1TminDataGridViewTextBoxColumn.HeaderText = "S1Tmin"
		Me.Sig1TminDataGridViewTextBoxColumn.Name = "Sig1TminDataGridViewTextBoxColumn"
		Me.Sig1TminDataGridViewTextBoxColumn.Width = 68
		'
		'Sig1TexspDataGridViewTextBoxColumn
		'
		Me.Sig1TexspDataGridViewTextBoxColumn.DataPropertyName = "Sig1_Texsp"
		Me.Sig1TexspDataGridViewTextBoxColumn.HeaderText = "S1Texsp"
		Me.Sig1TexspDataGridViewTextBoxColumn.Name = "Sig1TexspDataGridViewTextBoxColumn"
		Me.Sig1TexspDataGridViewTextBoxColumn.Width = 74
		'
		'Sig7TgolDataGridViewTextBoxColumn
		'
		Me.Sig7TgolDataGridViewTextBoxColumn.DataPropertyName = "Sig7_Tgol"
		Me.Sig7TgolDataGridViewTextBoxColumn.HeaderText = "S7"
		Me.Sig7TgolDataGridViewTextBoxColumn.Name = "Sig7TgolDataGridViewTextBoxColumn"
		Me.Sig7TgolDataGridViewTextBoxColumn.Width = 45
		'
		'NamemarkTDataGridViewTextBoxColumn
		'
		Me.NamemarkTDataGridViewTextBoxColumn.DataPropertyName = "Name_markT"
		Me.NamemarkTDataGridViewTextBoxColumn.HeaderText = "Name_markT"
		Me.NamemarkTDataGridViewTextBoxColumn.Name = "NamemarkTDataGridViewTextBoxColumn"
		Me.NamemarkTDataGridViewTextBoxColumn.Width = 96
		'
		'Sig1TminTDataGridViewTextBoxColumn
		'
		Me.Sig1TminTDataGridViewTextBoxColumn.DataPropertyName = "Sig1_TminT"
		Me.Sig1TminTDataGridViewTextBoxColumn.HeaderText = "S1TminT"
		Me.Sig1TminTDataGridViewTextBoxColumn.Name = "Sig1TminTDataGridViewTextBoxColumn"
		Me.Sig1TminTDataGridViewTextBoxColumn.Width = 75
		'
		'Sig1TexspTDataGridViewTextBoxColumn
		'
		Me.Sig1TexspTDataGridViewTextBoxColumn.DataPropertyName = "Sig1_TexspT"
		Me.Sig1TexspTDataGridViewTextBoxColumn.HeaderText = "S1TexspT"
		Me.Sig1TexspTDataGridViewTextBoxColumn.Name = "Sig1TexspTDataGridViewTextBoxColumn"
		Me.Sig1TexspTDataGridViewTextBoxColumn.Width = 81
		'
		'Sig7TgolTDataGridViewTextBoxColumn
		'
		Me.Sig7TgolTDataGridViewTextBoxColumn.DataPropertyName = "Sig7_TgolT"
		Me.Sig7TgolTDataGridViewTextBoxColumn.HeaderText = "S7lT"
		Me.Sig7TgolTDataGridViewTextBoxColumn.Name = "Sig7TgolTDataGridViewTextBoxColumn"
		Me.Sig7TgolTDataGridViewTextBoxColumn.Width = 54
		'
		'GabaritDataGridViewTextBoxColumn
		'
		Me.GabaritDataGridViewTextBoxColumn.DataPropertyName = "Gabarit"
		Me.GabaritDataGridViewTextBoxColumn.HeaderText = "Gab"
		Me.GabaritDataGridViewTextBoxColumn.Name = "GabaritDataGridViewTextBoxColumn"
		Me.GabaritDataGridViewTextBoxColumn.Width = 52
		'
		'NumNameDataGridViewTextBoxColumn
		'
		Me.NumNameDataGridViewTextBoxColumn.DataPropertyName = "NumName"
		Me.NumNameDataGridViewTextBoxColumn.HeaderText = "NumName"
		Me.NumNameDataGridViewTextBoxColumn.Name = "NumNameDataGridViewTextBoxColumn"
		Me.NumNameDataGridViewTextBoxColumn.Width = 82
		'
		'TipopDataGridViewTextBoxColumn
		'
		Me.TipopDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.TipopDataGridViewTextBoxColumn.DataPropertyName = "Tip_op"
		Me.TipopDataGridViewTextBoxColumn.HeaderText = "Tip_op"
		Me.TipopDataGridViewTextBoxColumn.Name = "TipopDataGridViewTextBoxColumn"
		'
		'DlinaDataGridViewTextBoxColumn
		'
		Me.DlinaDataGridViewTextBoxColumn.DataPropertyName = "Dlina"
		Me.DlinaDataGridViewTextBoxColumn.HeaderText = "Dlina"
		Me.DlinaDataGridViewTextBoxColumn.Name = "DlinaDataGridViewTextBoxColumn"
		Me.DlinaDataGridViewTextBoxColumn.Width = 56
		'
		'WisotaDataGridViewTextBoxColumn
		'
		Me.WisotaDataGridViewTextBoxColumn.DataPropertyName = "Wisota"
		Me.WisotaDataGridViewTextBoxColumn.HeaderText = "Wisota"
		Me.WisotaDataGridViewTextBoxColumn.Name = "WisotaDataGridViewTextBoxColumn"
		Me.WisotaDataGridViewTextBoxColumn.Width = 65
		'
		'TipDataGridViewTextBoxColumn
		'
		Me.TipDataGridViewTextBoxColumn.DataPropertyName = "Tip"
		Me.TipDataGridViewTextBoxColumn.HeaderText = "Tip"
		Me.TipDataGridViewTextBoxColumn.Name = "TipDataGridViewTextBoxColumn"
		Me.TipDataGridViewTextBoxColumn.Width = 47
		'
		'TipIDataGridViewTextBoxColumn
		'
		Me.TipIDataGridViewTextBoxColumn.DataPropertyName = "TipI"
		Me.TipIDataGridViewTextBoxColumn.HeaderText = "TipI"
		Me.TipIDataGridViewTextBoxColumn.Name = "TipIDataGridViewTextBoxColumn"
		Me.TipIDataGridViewTextBoxColumn.Width = 50
		'
		'FormProsmotr06
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(1334, 398)
		Me.Controls.Add(Me.DataGridView1)
		Me.Controls.Add(Me.DataGridViewMechUsl)
		Me.Controls.Add(Me.DataGridViewRasst)
		Me.Name = "FormProsmotr06"
		Me.Text = "FormProsmotr06"
		CType(Me.DataGridViewRasst, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.DsRass_06, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.RastOpNBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.DataGridViewMechUsl, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.MechUslBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.ParamUchNBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents DataGridViewRasst As Windows.Forms.DataGridView
	Friend WithEvents RastOpNBindingSource As Windows.Forms.BindingSource
	Friend WithEvents RastOpNTableAdapter As DsRass_06TableAdapters.rastOpNTableAdapter
	Friend WithEvents DataGridViewMechUsl As Windows.Forms.DataGridView
	Friend WithEvents MechUslBindingSource As Windows.Forms.BindingSource
	Friend WithEvents DataGridView1 As Windows.Forms.DataGridView
	Friend WithEvents ParamUchNBindingSource As Windows.Forms.BindingSource
	Friend WithEvents ParamUchNTableAdapter As DsRass_06TableAdapters.ParamUchNTableAdapter
	Public WithEvents DsRass_06 As DsRass_06
	Friend WithEvents NumNameDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents TipopDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DlinaDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents WisotaDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents TipDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents TipIDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents TipopDataGridViewTextBoxColumn1 As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents RastDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents NamemarkDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents Sig1TminDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents Sig1TexspDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents Sig7TgolDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents NamemarkTDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents Sig1TminTDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents Sig1TexspTDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents Sig7TgolTDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents GabaritDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents NameUchDataGridViewTextBoxColumn2 As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents NameLinDataGridViewTextBoxColumn2 As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents GnwDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents GnwGDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents GregDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents GregGolDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents TipopADataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents TipopPDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DlGirlDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents MassGirlDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents NamemarkDataGridViewTextBoxColumn1 As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents NamemarkTDataGridViewTextBoxColumn1 As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DlGirlTDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents MassGirlTDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
End Class
