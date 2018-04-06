Imports OperBD

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmKorrProfilWlUch
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()>
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
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmKorrProfilWlUch))
		Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Me.DsProfilA = New DsProfil()
		Me.ClsZonKlimatBindingSource = New System.Windows.Forms.BindingSource(Me.components)
		Me.ToolStripUprKorrUch = New System.Windows.Forms.ToolStrip()
		Me.NameUch = New System.Windows.Forms.ToolStripLabel()
		Me.NameFileUch = New System.Windows.Forms.ToolStripLabel()
		Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
		Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
		Me.ToolStripLabelGr = New System.Windows.Forms.ToolStripLabel()
		Me.ToolStripLabelPikBeg = New System.Windows.Forms.ToolStripLabel()
		Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
		Me.ToolStripLabelPikEnd = New System.Windows.Forms.ToolStripLabel()
		Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
		Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
		Me.ToolStripLabelWibrPiket = New System.Windows.Forms.ToolStripLabel()
		Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
		Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
		Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
		Me.ToolStripButtonSohrDwg = New System.Windows.Forms.ToolStripButton()
		Me.PiketUgodBindingSource = New System.Windows.Forms.BindingSource(Me.components)
		Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn27 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn28 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn29 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn30 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn31 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn32 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn34 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn35 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn36 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn37 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn38 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn39 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn40 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn41 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn42 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn43 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn44 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn45 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn46 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn47 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn48 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn49 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn50 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn51 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn52 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn53 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn54 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn55 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn56 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn57 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
		Me.ButtonSdwigPik = New System.Windows.Forms.Button()
		Me.ButtonObmPrnaLew = New System.Windows.Forms.Button()
		Me.ButtonIzmOtm = New System.Windows.Forms.Button()
		Me.ButtonInversij = New System.Windows.Forms.Button()
		Me.Klimat = New System.Windows.Forms.TabPage()
		Me.KlimatGridView = New System.Windows.Forms.DataGridView()
		Me.PiketajDataGridViewKlimzon = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.StGolEkwDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.StGolUslDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.TexspDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.TgolDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.TminDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.TmaxDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.NaporVetraDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.NapPriGolDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.TipMestaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
		Me.PolzDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataWDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Profil = New System.Windows.Forms.TabPage()
		Me.TextBoxBegSdwig = New System.Windows.Forms.TextBox()
		Me.TextBoxIzmOtm = New System.Windows.Forms.TextBox()
		Me.TextBoxSdwig = New System.Windows.Forms.TextBox()
		Me.DataGridViewProfil = New System.Windows.Forms.DataGridView()
		Me.NameTchkDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Piketaj1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Otmetka1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.OtmetkaPrDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.OtmetkaLwDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.UIdTchk1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.UIdUch1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.IdTipSoor1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
		Me.Param1DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Param2DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Param3DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Param4DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.OpisDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.UgolPoworotDataGridViewTextBoxColumn2 = New OperBD.MaskedTextBoxColumn()
		Me.LabelWibrPik = New System.Windows.Forms.Label()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.DataGridViewPikUgod = New System.Windows.Forms.DataGridView()
		Me.DataGridViewComboBoxPiketaj = New System.Windows.Forms.DataGridViewComboBoxColumn()
		Me.TipDataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
		Me.TabControl1 = New System.Windows.Forms.TabControl()
		Me.ToolStripButtonAllOk = New System.Windows.Forms.ToolStripButton()
		CType(Me.DsProfilA, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.ClsZonKlimatBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.ToolStripUprKorrUch.SuspendLayout()
		CType(Me.PiketUgodBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Klimat.SuspendLayout()
		CType(Me.KlimatGridView, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Profil.SuspendLayout()
		CType(Me.DataGridViewProfil, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.DataGridViewPikUgod, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.TabControl1.SuspendLayout()
		Me.SuspendLayout()
		'
		'DsProfilA
		'
		Me.DsProfilA.DataSetName = "dsProfil"
		Me.DsProfilA.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
		'
		'ClsZonKlimatBindingSource
		'
		Me.ClsZonKlimatBindingSource.DataMember = "TablKlimN"
		Me.ClsZonKlimatBindingSource.DataSource = Me.DsProfilA      '
		'ToolStripUprKorrUch
		'
		resources.ApplyResources(Me.ToolStripUprKorrUch, "ToolStripUprKorrUch")
		Me.ToolStripUprKorrUch.BackColor = System.Drawing.Color.Gainsboro
		Me.HelpProvider1.SetHelpKeyword(Me.ToolStripUprKorrUch, resources.GetString("ToolStripUprKorrUch.HelpKeyword"))
		Me.HelpProvider1.SetHelpNavigator(Me.ToolStripUprKorrUch, CType(resources.GetObject("ToolStripUprKorrUch.HelpNavigator"), System.Windows.Forms.HelpNavigator))
		Me.HelpProvider1.SetHelpString(Me.ToolStripUprKorrUch, resources.GetString("ToolStripUprKorrUch.HelpString"))
		Me.ToolStripUprKorrUch.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NameUch, Me.NameFileUch, Me.ToolStripSeparator1, Me.ToolStripSeparator2, Me.ToolStripLabelGr, Me.ToolStripLabelPikBeg, Me.ToolStripSeparator3, Me.ToolStripLabelPikEnd, Me.ToolStripSeparator6, Me.ToolStripLabel2, Me.ToolStripLabelWibrPiket, Me.ToolStripSeparator4, Me.ToolStripButtonAllOk, Me.ToolStripSeparator5, Me.ToolStripSeparator7, Me.ToolStripButtonSohrDwg})
		Me.ToolStripUprKorrUch.Name = "ToolStripUprKorrUch"
		Me.ToolStripUprKorrUch.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
		Me.HelpProvider1.SetShowHelp(Me.ToolStripUprKorrUch, CType(resources.GetObject("ToolStripUprKorrUch.ShowHelp"), Boolean))
		'
		'NameUch
		'
		resources.ApplyResources(Me.NameUch, "NameUch")
		Me.NameUch.BackColor = System.Drawing.SystemColors.Control
		Me.NameUch.Name = "NameUch"
		'
		'NameFileUch
		'
		resources.ApplyResources(Me.NameFileUch, "NameFileUch")
		Me.NameFileUch.Name = "NameFileUch"
		'
		'ToolStripSeparator1
		'
		resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
		Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
		'
		'ToolStripSeparator2
		'
		resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
		Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
		'
		'ToolStripLabelGr
		'
		resources.ApplyResources(Me.ToolStripLabelGr, "ToolStripLabelGr")
		Me.ToolStripLabelGr.Name = "ToolStripLabelGr"
		'
		'ToolStripLabelPikBeg
		'
		resources.ApplyResources(Me.ToolStripLabelPikBeg, "ToolStripLabelPikBeg")
		Me.ToolStripLabelPikBeg.Name = "ToolStripLabelPikBeg"
		'
		'ToolStripSeparator3
		'
		resources.ApplyResources(Me.ToolStripSeparator3, "ToolStripSeparator3")
		Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
		'
		'ToolStripLabelPikEnd
		'
		resources.ApplyResources(Me.ToolStripLabelPikEnd, "ToolStripLabelPikEnd")
		Me.ToolStripLabelPikEnd.Name = "ToolStripLabelPikEnd"
		'
		'ToolStripSeparator6
		'
		resources.ApplyResources(Me.ToolStripSeparator6, "ToolStripSeparator6")
		Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
		'
		'ToolStripLabel2
		'
		resources.ApplyResources(Me.ToolStripLabel2, "ToolStripLabel2")
		Me.ToolStripLabel2.Name = "ToolStripLabel2"
		'
		'ToolStripLabelWibrPiket
		'
		resources.ApplyResources(Me.ToolStripLabelWibrPiket, "ToolStripLabelWibrPiket")
		Me.ToolStripLabelWibrPiket.Name = "ToolStripLabelWibrPiket"
		'
		'ToolStripSeparator4
		'
		resources.ApplyResources(Me.ToolStripSeparator4, "ToolStripSeparator4")
		Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
		'
		'ToolStripSeparator5
		'
		resources.ApplyResources(Me.ToolStripSeparator5, "ToolStripSeparator5")
		Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
		'
		'ToolStripSeparator7
		'
		resources.ApplyResources(Me.ToolStripSeparator7, "ToolStripSeparator7")
		Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
		'
		'ToolStripButtonSohrDwg
		'
		resources.ApplyResources(Me.ToolStripButtonSohrDwg, "ToolStripButtonSohrDwg")
		Me.ToolStripButtonSohrDwg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
		Me.ToolStripButtonSohrDwg.ForeColor = System.Drawing.SystemColors.GrayText
		Me.ToolStripButtonSohrDwg.Name = "ToolStripButtonSohrDwg"
		'
		'PiketUgodBindingSource
		'
		Me.PiketUgodBindingSource.DataMember = "PikUgodN"
		Me.PiketUgodBindingSource.DataSource = Me.DsProfilA
		Me.PiketUgodBindingSource.Sort = "Piketaj "
		'
		'DataGridViewTextBoxColumn1
		'
		Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
		Me.DataGridViewTextBoxColumn1.DataPropertyName = "Piketaj"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn1, "DataGridViewTextBoxColumn1")
		Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
		Me.DataGridViewTextBoxColumn1.ReadOnly = True
		Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
		Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
		'
		'DataGridViewTextBoxColumn2
		'
		Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
		Me.DataGridViewTextBoxColumn2.DataPropertyName = "Otmetka"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn2, "DataGridViewTextBoxColumn2")
		Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
		Me.DataGridViewTextBoxColumn2.ReadOnly = True
		'
		'DataGridViewTextBoxColumn3
		'
		Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
		Me.DataGridViewTextBoxColumn3.DataPropertyName = "NamePiket"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn3, "DataGridViewTextBoxColumn3")
		Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
		Me.DataGridViewTextBoxColumn3.ReadOnly = True
		'
		'DataGridViewTextBoxColumn4
		'
		Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
		Me.DataGridViewTextBoxColumn4.DataPropertyName = "OtmetkaLw"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn4, "DataGridViewTextBoxColumn4")
		Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
		Me.DataGridViewTextBoxColumn4.ReadOnly = True
		'
		'DataGridViewTextBoxColumn5
		'
		Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.DataGridViewTextBoxColumn5.DataPropertyName = "OtmetkaPr"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn5, "DataGridViewTextBoxColumn5")
		Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
		Me.DataGridViewTextBoxColumn5.ReadOnly = True
		'
		'DataGridViewTextBoxColumn6
		'
		Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
		Me.DataGridViewTextBoxColumn6.DataPropertyName = "UgolPoworota"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn6, "DataGridViewTextBoxColumn6")
		Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
		Me.DataGridViewTextBoxColumn6.ReadOnly = True
		'
		'DataGridViewTextBoxColumn7
		'
		Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
		Me.DataGridViewTextBoxColumn7.DataPropertyName = "StGolEkw"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn7, "DataGridViewTextBoxColumn7")
		Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
		Me.DataGridViewTextBoxColumn7.ReadOnly = True
		'
		'DataGridViewTextBoxColumn8
		'
		Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
		Me.DataGridViewTextBoxColumn8.DataPropertyName = "StGolUsl"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn8, "DataGridViewTextBoxColumn8")
		Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
		Me.DataGridViewTextBoxColumn8.ReadOnly = True
		'
		'DataGridViewTextBoxColumn9
		'
		Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
		Me.DataGridViewTextBoxColumn9.DataPropertyName = "Texsp"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn9, "DataGridViewTextBoxColumn9")
		Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
		Me.DataGridViewTextBoxColumn9.ReadOnly = True
		'
		'DataGridViewTextBoxColumn10
		'
		Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
		Me.DataGridViewTextBoxColumn10.DataPropertyName = "Tgol"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn10, "DataGridViewTextBoxColumn10")
		Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
		Me.DataGridViewTextBoxColumn10.ReadOnly = True
		'
		'DataGridViewTextBoxColumn11
		'
		Me.DataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
		Me.DataGridViewTextBoxColumn11.DataPropertyName = "Tmin"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn11, "DataGridViewTextBoxColumn11")
		Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
		Me.DataGridViewTextBoxColumn11.ReadOnly = True
		'
		'DataGridViewTextBoxColumn12
		'
		Me.DataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
		Me.DataGridViewTextBoxColumn12.DataPropertyName = "Tmax"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn12, "DataGridViewTextBoxColumn12")
		Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
		Me.DataGridViewTextBoxColumn12.ReadOnly = True
		'
		'DataGridViewTextBoxColumn13
		'
		Me.DataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
		Me.DataGridViewTextBoxColumn13.DataPropertyName = "Napor"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn13, "DataGridViewTextBoxColumn13")
		Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
		Me.DataGridViewTextBoxColumn13.ReadOnly = True
		'
		'DataGridViewTextBoxColumn14
		'
		Me.DataGridViewTextBoxColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
		Me.DataGridViewTextBoxColumn14.DataPropertyName = "NaporPrGol"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn14, "DataGridViewTextBoxColumn14")
		Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
		Me.DataGridViewTextBoxColumn14.ReadOnly = True
		'
		'DataGridViewTextBoxColumn15
		'
		Me.DataGridViewTextBoxColumn15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.DataGridViewTextBoxColumn15.DataPropertyName = "TipMesta"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn15, "DataGridViewTextBoxColumn15")
		Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
		Me.DataGridViewTextBoxColumn15.ReadOnly = True
		'
		'DataGridViewTextBoxColumn16
		'
		Me.DataGridViewTextBoxColumn16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.DataGridViewTextBoxColumn16.DataPropertyName = "FiVetPr"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn16, "DataGridViewTextBoxColumn16")
		Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
		Me.DataGridViewTextBoxColumn16.ReadOnly = True
		'
		'DataGridViewTextBoxColumn17
		'
		Me.DataGridViewTextBoxColumn17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
		Me.DataGridViewTextBoxColumn17.DataPropertyName = "Sled"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn17, "DataGridViewTextBoxColumn17")
		Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
		Me.DataGridViewTextBoxColumn17.ReadOnly = True
		'
		'DataGridViewTextBoxColumn18
		'
		Me.DataGridViewTextBoxColumn18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
		Me.DataGridViewTextBoxColumn18.DataPropertyName = "Piketaj"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn18, "DataGridViewTextBoxColumn18")
		Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
		Me.DataGridViewTextBoxColumn18.ReadOnly = True
		'
		'DataGridViewTextBoxColumn19
		'
		Me.DataGridViewTextBoxColumn19.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
		Me.DataGridViewTextBoxColumn19.DataPropertyName = "Key"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn19, "DataGridViewTextBoxColumn19")
		Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
		Me.DataGridViewTextBoxColumn19.ReadOnly = True
		'
		'DataGridViewTextBoxColumn20
		'
		Me.DataGridViewTextBoxColumn20.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
		Me.DataGridViewTextBoxColumn20.DataPropertyName = "NameTipOpor"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn20, "DataGridViewTextBoxColumn20")
		Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
		Me.DataGridViewTextBoxColumn20.ReadOnly = True
		'
		'DataGridViewTextBoxColumn21
		'
		Me.DataGridViewTextBoxColumn21.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
		Me.DataGridViewTextBoxColumn21.DataPropertyName = "NameGirlT"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn21, "DataGridViewTextBoxColumn21")
		Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
		Me.DataGridViewTextBoxColumn21.ReadOnly = True
		'
		'DataGridViewTextBoxColumn22
		'
		Me.DataGridViewTextBoxColumn22.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
		Me.DataGridViewTextBoxColumn22.DataPropertyName = "Tip"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn22, "DataGridViewTextBoxColumn22")
		Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
		Me.DataGridViewTextBoxColumn22.ReadOnly = True
		'
		'DataGridViewTextBoxColumn23
		'
		Me.DataGridViewTextBoxColumn23.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
		Me.DataGridViewTextBoxColumn23.DataPropertyName = "Piketaj"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn23, "DataGridViewTextBoxColumn23")
		Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
		Me.DataGridViewTextBoxColumn23.ReadOnly = True
		'
		'DataGridViewTextBoxColumn24
		'
		Me.DataGridViewTextBoxColumn24.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
		Me.DataGridViewTextBoxColumn24.DataPropertyName = "NameGirlT"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn24, "DataGridViewTextBoxColumn24")
		Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
		Me.DataGridViewTextBoxColumn24.ReadOnly = True
		'
		'DataGridViewTextBoxColumn25
		'
		Me.DataGridViewTextBoxColumn25.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
		Me.DataGridViewTextBoxColumn25.DataPropertyName = "NameGirlT"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn25, "DataGridViewTextBoxColumn25")
		Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
		Me.DataGridViewTextBoxColumn25.ReadOnly = True
		'
		'DataGridViewTextBoxColumn26
		'
		Me.DataGridViewTextBoxColumn26.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
		Me.DataGridViewTextBoxColumn26.DataPropertyName = "Name_mark"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn26, "DataGridViewTextBoxColumn26")
		Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
		Me.DataGridViewTextBoxColumn26.ReadOnly = True
		'
		'DataGridViewTextBoxColumn27
		'
		Me.DataGridViewTextBoxColumn27.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
		Me.DataGridViewTextBoxColumn27.DataPropertyName = "Name_markT"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn27, "DataGridViewTextBoxColumn27")
		Me.DataGridViewTextBoxColumn27.Name = "DataGridViewTextBoxColumn27"
		Me.DataGridViewTextBoxColumn27.ReadOnly = True
		'
		'DataGridViewTextBoxColumn28
		'
		Me.DataGridViewTextBoxColumn28.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
		Me.DataGridViewTextBoxColumn28.DataPropertyName = "Tip_op"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn28, "DataGridViewTextBoxColumn28")
		Me.DataGridViewTextBoxColumn28.Name = "DataGridViewTextBoxColumn28"
		Me.DataGridViewTextBoxColumn28.ReadOnly = True
		'
		'DataGridViewTextBoxColumn29
		'
		Me.DataGridViewTextBoxColumn29.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
		Me.DataGridViewTextBoxColumn29.DataPropertyName = "Gabarit"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn29, "DataGridViewTextBoxColumn29")
		Me.DataGridViewTextBoxColumn29.Name = "DataGridViewTextBoxColumn29"
		Me.DataGridViewTextBoxColumn29.ReadOnly = True
		'
		'DataGridViewTextBoxColumn30
		'
		Me.DataGridViewTextBoxColumn30.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.DataGridViewTextBoxColumn30.DataPropertyName = "Sled"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn30, "DataGridViewTextBoxColumn30")
		Me.DataGridViewTextBoxColumn30.Name = "DataGridViewTextBoxColumn30"
		Me.DataGridViewTextBoxColumn30.ReadOnly = True
		'
		'DataGridViewTextBoxColumn31
		'
		Me.DataGridViewTextBoxColumn31.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.DataGridViewTextBoxColumn31.DataPropertyName = "Piket"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn31, "DataGridViewTextBoxColumn31")
		Me.DataGridViewTextBoxColumn31.Name = "DataGridViewTextBoxColumn31"
		Me.DataGridViewTextBoxColumn31.ReadOnly = True
		'
		'DataGridViewTextBoxColumn32
		'
		Me.DataGridViewTextBoxColumn32.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
		Me.DataGridViewTextBoxColumn32.DataPropertyName = "Piketaj"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn32, "DataGridViewTextBoxColumn32")
		Me.DataGridViewTextBoxColumn32.Name = "DataGridViewTextBoxColumn32"
		Me.DataGridViewTextBoxColumn32.ReadOnly = True
		'
		'DataGridViewTextBoxColumn33
		'
		Me.DataGridViewTextBoxColumn33.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
		Me.DataGridViewTextBoxColumn33.DataPropertyName = "Key"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn33, "DataGridViewTextBoxColumn33")
		Me.DataGridViewTextBoxColumn33.Name = "DataGridViewTextBoxColumn33"
		Me.DataGridViewTextBoxColumn33.ReadOnly = True
		'
		'DataGridViewTextBoxColumn34
		'
		Me.DataGridViewTextBoxColumn34.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
		Me.DataGridViewTextBoxColumn34.DataPropertyName = "EndPiket"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn34, "DataGridViewTextBoxColumn34")
		Me.DataGridViewTextBoxColumn34.Name = "DataGridViewTextBoxColumn34"
		Me.DataGridViewTextBoxColumn34.ReadOnly = True
		'
		'DataGridViewTextBoxColumn35
		'
		Me.DataGridViewTextBoxColumn35.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.DataGridViewTextBoxColumn35.DataPropertyName = "MarkaT"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn35, "DataGridViewTextBoxColumn35")
		Me.DataGridViewTextBoxColumn35.Name = "DataGridViewTextBoxColumn35"
		Me.DataGridViewTextBoxColumn35.ReadOnly = True
		'
		'DataGridViewTextBoxColumn36
		'
		Me.DataGridViewTextBoxColumn36.DataPropertyName = "Girl"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn36, "DataGridViewTextBoxColumn36")
		Me.DataGridViewTextBoxColumn36.Name = "DataGridViewTextBoxColumn36"
		Me.DataGridViewTextBoxColumn36.ReadOnly = True
		'
		'DataGridViewTextBoxColumn37
		'
		Me.DataGridViewTextBoxColumn37.DataPropertyName = "GirlT"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn37, "DataGridViewTextBoxColumn37")
		Me.DataGridViewTextBoxColumn37.Name = "DataGridViewTextBoxColumn37"
		Me.DataGridViewTextBoxColumn37.ReadOnly = True
		'
		'DataGridViewTextBoxColumn38
		'
		Me.DataGridViewTextBoxColumn38.DataPropertyName = "DlGirl"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn38, "DataGridViewTextBoxColumn38")
		Me.DataGridViewTextBoxColumn38.Name = "DataGridViewTextBoxColumn38"
		Me.DataGridViewTextBoxColumn38.ReadOnly = True
		'
		'DataGridViewTextBoxColumn39
		'
		Me.DataGridViewTextBoxColumn39.DataPropertyName = "massGirl"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn39, "DataGridViewTextBoxColumn39")
		Me.DataGridViewTextBoxColumn39.Name = "DataGridViewTextBoxColumn39"
		Me.DataGridViewTextBoxColumn39.ReadOnly = True
		'
		'DataGridViewTextBoxColumn40
		'
		Me.DataGridViewTextBoxColumn40.DataPropertyName = "UserTipOp"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn40, "DataGridViewTextBoxColumn40")
		Me.DataGridViewTextBoxColumn40.Name = "DataGridViewTextBoxColumn40"
		Me.DataGridViewTextBoxColumn40.ReadOnly = True
		'
		'DataGridViewTextBoxColumn41
		'
		Me.DataGridViewTextBoxColumn41.DataPropertyName = "Tip_i"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn41, "DataGridViewTextBoxColumn41")
		Me.DataGridViewTextBoxColumn41.Name = "DataGridViewTextBoxColumn41"
		Me.DataGridViewTextBoxColumn41.ReadOnly = True
		'
		'DataGridViewTextBoxColumn42
		'
		Me.DataGridViewTextBoxColumn42.DataPropertyName = "Wis_op0"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn42, "DataGridViewTextBoxColumn42")
		Me.DataGridViewTextBoxColumn42.Name = "DataGridViewTextBoxColumn42"
		Me.DataGridViewTextBoxColumn42.ReadOnly = True
		'
		'DataGridViewTextBoxColumn43
		'
		Me.DataGridViewTextBoxColumn43.DataPropertyName = "Wis_op1"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn43, "DataGridViewTextBoxColumn43")
		Me.DataGridViewTextBoxColumn43.Name = "DataGridViewTextBoxColumn43"
		Me.DataGridViewTextBoxColumn43.ReadOnly = True
		'
		'DataGridViewTextBoxColumn44
		'
		Me.DataGridViewTextBoxColumn44.DataPropertyName = "Wis_op2"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn44, "DataGridViewTextBoxColumn44")
		Me.DataGridViewTextBoxColumn44.Name = "DataGridViewTextBoxColumn44"
		Me.DataGridViewTextBoxColumn44.ReadOnly = True
		'
		'DataGridViewTextBoxColumn45
		'
		Me.DataGridViewTextBoxColumn45.DataPropertyName = "Wis_opT"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn45, "DataGridViewTextBoxColumn45")
		Me.DataGridViewTextBoxColumn45.Name = "DataGridViewTextBoxColumn45"
		Me.DataGridViewTextBoxColumn45.ReadOnly = True
		'
		'DataGridViewTextBoxColumn46
		'
		Me.DataGridViewTextBoxColumn46.DataPropertyName = "Name_mark"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn46, "DataGridViewTextBoxColumn46")
		Me.DataGridViewTextBoxColumn46.Name = "DataGridViewTextBoxColumn46"
		Me.DataGridViewTextBoxColumn46.ReadOnly = True
		'
		'DataGridViewTextBoxColumn47
		'
		Me.DataGridViewTextBoxColumn47.DataPropertyName = "SigSrG"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn47, "DataGridViewTextBoxColumn47")
		Me.DataGridViewTextBoxColumn47.Name = "DataGridViewTextBoxColumn47"
		Me.DataGridViewTextBoxColumn47.ReadOnly = True
		'
		'DataGridViewTextBoxColumn48
		'
		Me.DataGridViewTextBoxColumn48.DataPropertyName = "SigGol"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn48, "DataGridViewTextBoxColumn48")
		Me.DataGridViewTextBoxColumn48.Name = "DataGridViewTextBoxColumn48"
		Me.DataGridViewTextBoxColumn48.ReadOnly = True
		'
		'DataGridViewTextBoxColumn49
		'
		Me.DataGridViewTextBoxColumn49.DataPropertyName = "Jung"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn49, "DataGridViewTextBoxColumn49")
		Me.DataGridViewTextBoxColumn49.Name = "DataGridViewTextBoxColumn49"
		Me.DataGridViewTextBoxColumn49.ReadOnly = True
		'
		'DataGridViewTextBoxColumn50
		'
		Me.DataGridViewTextBoxColumn50.DataPropertyName = "Alfa"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn50, "DataGridViewTextBoxColumn50")
		Me.DataGridViewTextBoxColumn50.Name = "DataGridViewTextBoxColumn50"
		Me.DataGridViewTextBoxColumn50.ReadOnly = True
		'
		'DataGridViewTextBoxColumn51
		'
		Me.DataGridViewTextBoxColumn51.DataPropertyName = "Ppogon"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn51, "DataGridViewTextBoxColumn51")
		Me.DataGridViewTextBoxColumn51.Name = "DataGridViewTextBoxColumn51"
		Me.DataGridViewTextBoxColumn51.ReadOnly = True
		'
		'DataGridViewTextBoxColumn52
		'
		Me.DataGridViewTextBoxColumn52.DataPropertyName = "Sprwd"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn52, "DataGridViewTextBoxColumn52")
		Me.DataGridViewTextBoxColumn52.Name = "DataGridViewTextBoxColumn52"
		Me.DataGridViewTextBoxColumn52.ReadOnly = True
		'
		'DataGridViewTextBoxColumn53
		'
		Me.DataGridViewTextBoxColumn53.DataPropertyName = "DiamPrwd"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn53, "DataGridViewTextBoxColumn53")
		Me.DataGridViewTextBoxColumn53.Name = "DataGridViewTextBoxColumn53"
		Me.DataGridViewTextBoxColumn53.ReadOnly = True
		'
		'DataGridViewTextBoxColumn54
		'
		Me.DataGridViewTextBoxColumn54.DataPropertyName = "WesPogon"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn54, "DataGridViewTextBoxColumn54")
		Me.DataGridViewTextBoxColumn54.Name = "DataGridViewTextBoxColumn54"
		Me.DataGridViewTextBoxColumn54.ReadOnly = True
		'
		'DataGridViewTextBoxColumn55
		'
		Me.DataGridViewTextBoxColumn55.DataPropertyName = "Tekpl"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn55, "DataGridViewTextBoxColumn55")
		Me.DataGridViewTextBoxColumn55.Name = "DataGridViewTextBoxColumn55"
		Me.DataGridViewTextBoxColumn55.ReadOnly = True
		'
		'DataGridViewTextBoxColumn56
		'
		Me.DataGridViewTextBoxColumn56.DataPropertyName = "WesPogon"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn56, "DataGridViewTextBoxColumn56")
		Me.DataGridViewTextBoxColumn56.Name = "DataGridViewTextBoxColumn56"
		Me.DataGridViewTextBoxColumn56.ReadOnly = True
		'
		'DataGridViewTextBoxColumn57
		'
		Me.DataGridViewTextBoxColumn57.DataPropertyName = "WesPogon"
		resources.ApplyResources(Me.DataGridViewTextBoxColumn57, "DataGridViewTextBoxColumn57")
		Me.DataGridViewTextBoxColumn57.Name = "DataGridViewTextBoxColumn57"
		Me.DataGridViewTextBoxColumn57.ReadOnly = True
		'
		'HelpProvider1
		'
		resources.ApplyResources(Me.HelpProvider1, "HelpProvider1")
		'
		'ButtonSdwigPik
		'
		resources.ApplyResources(Me.ButtonSdwigPik, "ButtonSdwigPik")
		Me.HelpProvider1.SetHelpKeyword(Me.ButtonSdwigPik, resources.GetString("ButtonSdwigPik.HelpKeyword"))
		Me.HelpProvider1.SetHelpNavigator(Me.ButtonSdwigPik, CType(resources.GetObject("ButtonSdwigPik.HelpNavigator"), System.Windows.Forms.HelpNavigator))
		Me.HelpProvider1.SetHelpString(Me.ButtonSdwigPik, resources.GetString("ButtonSdwigPik.HelpString"))
		Me.ButtonSdwigPik.Name = "ButtonSdwigPik"
		Me.HelpProvider1.SetShowHelp(Me.ButtonSdwigPik, CType(resources.GetObject("ButtonSdwigPik.ShowHelp"), Boolean))
		Me.ButtonSdwigPik.UseVisualStyleBackColor = True
		'
		'ButtonObmPrnaLew
		'
		resources.ApplyResources(Me.ButtonObmPrnaLew, "ButtonObmPrnaLew")
		Me.HelpProvider1.SetHelpKeyword(Me.ButtonObmPrnaLew, resources.GetString("ButtonObmPrnaLew.HelpKeyword"))
		Me.HelpProvider1.SetHelpNavigator(Me.ButtonObmPrnaLew, CType(resources.GetObject("ButtonObmPrnaLew.HelpNavigator"), System.Windows.Forms.HelpNavigator))
		Me.HelpProvider1.SetHelpString(Me.ButtonObmPrnaLew, resources.GetString("ButtonObmPrnaLew.HelpString"))
		Me.ButtonObmPrnaLew.Name = "ButtonObmPrnaLew"
		Me.HelpProvider1.SetShowHelp(Me.ButtonObmPrnaLew, CType(resources.GetObject("ButtonObmPrnaLew.ShowHelp"), Boolean))
		Me.ButtonObmPrnaLew.UseVisualStyleBackColor = True
		'
		'ButtonIzmOtm
		'
		resources.ApplyResources(Me.ButtonIzmOtm, "ButtonIzmOtm")
		Me.HelpProvider1.SetHelpKeyword(Me.ButtonIzmOtm, resources.GetString("ButtonIzmOtm.HelpKeyword"))
		Me.HelpProvider1.SetHelpNavigator(Me.ButtonIzmOtm, CType(resources.GetObject("ButtonIzmOtm.HelpNavigator"), System.Windows.Forms.HelpNavigator))
		Me.HelpProvider1.SetHelpString(Me.ButtonIzmOtm, resources.GetString("ButtonIzmOtm.HelpString"))
		Me.ButtonIzmOtm.Name = "ButtonIzmOtm"
		Me.HelpProvider1.SetShowHelp(Me.ButtonIzmOtm, CType(resources.GetObject("ButtonIzmOtm.ShowHelp"), Boolean))
		Me.ButtonIzmOtm.UseVisualStyleBackColor = True
		'
		'ButtonInversij
		'
		resources.ApplyResources(Me.ButtonInversij, "ButtonInversij")
		Me.HelpProvider1.SetHelpKeyword(Me.ButtonInversij, resources.GetString("ButtonInversij.HelpKeyword"))
		Me.HelpProvider1.SetHelpNavigator(Me.ButtonInversij, CType(resources.GetObject("ButtonInversij.HelpNavigator"), System.Windows.Forms.HelpNavigator))
		Me.HelpProvider1.SetHelpString(Me.ButtonInversij, resources.GetString("ButtonInversij.HelpString"))
		Me.ButtonInversij.Name = "ButtonInversij"
		Me.HelpProvider1.SetShowHelp(Me.ButtonInversij, CType(resources.GetObject("ButtonInversij.ShowHelp"), Boolean))
		Me.ButtonInversij.UseVisualStyleBackColor = True
		'
		'Klimat
		'
		resources.ApplyResources(Me.Klimat, "Klimat")
		Me.Klimat.Controls.Add(Me.KlimatGridView)
		Me.HelpProvider1.SetHelpKeyword(Me.Klimat, resources.GetString("Klimat.HelpKeyword"))
		Me.HelpProvider1.SetHelpNavigator(Me.Klimat, CType(resources.GetObject("Klimat.HelpNavigator"), System.Windows.Forms.HelpNavigator))
		Me.HelpProvider1.SetHelpString(Me.Klimat, resources.GetString("Klimat.HelpString"))
		Me.Klimat.Name = "Klimat"
		Me.HelpProvider1.SetShowHelp(Me.Klimat, CType(resources.GetObject("Klimat.ShowHelp"), Boolean))
		Me.Klimat.UseVisualStyleBackColor = True
		'
		'KlimatGridView
		'
		resources.ApplyResources(Me.KlimatGridView, "KlimatGridView")
		Me.KlimatGridView.AutoGenerateColumns = False
		Me.KlimatGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
		Me.KlimatGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
		Me.KlimatGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.KlimatGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PiketajDataGridViewKlimzon, Me.StGolEkwDataGridViewTextBoxColumn, Me.StGolUslDataGridViewTextBoxColumn, Me.TexspDataGridViewTextBoxColumn, Me.TgolDataGridViewTextBoxColumn, Me.TminDataGridViewTextBoxColumn, Me.TmaxDataGridViewTextBoxColumn, Me.NaporVetraDataGridViewTextBoxColumn, Me.NapPriGolDataGridViewTextBoxColumn, Me.TipMestaDataGridViewTextBoxColumn, Me.PolzDataGridViewTextBoxColumn, Me.DataWDataGridViewTextBoxColumn})
		Me.KlimatGridView.DataSource = Me.ClsZonKlimatBindingSource
		Me.HelpProvider1.SetHelpKeyword(Me.KlimatGridView, resources.GetString("KlimatGridView.HelpKeyword"))
		Me.HelpProvider1.SetHelpNavigator(Me.KlimatGridView, CType(resources.GetObject("KlimatGridView.HelpNavigator"), System.Windows.Forms.HelpNavigator))
		Me.HelpProvider1.SetHelpString(Me.KlimatGridView, resources.GetString("KlimatGridView.HelpString"))
		Me.KlimatGridView.Name = "KlimatGridView"
		Me.HelpProvider1.SetShowHelp(Me.KlimatGridView, CType(resources.GetObject("KlimatGridView.ShowHelp"), Boolean))
		'
		'PiketajDataGridViewKlimzon
		'
		Me.PiketajDataGridViewKlimzon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.PiketajDataGridViewKlimzon.DataPropertyName = "Piketaj"
		resources.ApplyResources(Me.PiketajDataGridViewKlimzon, "PiketajDataGridViewKlimzon")
		Me.PiketajDataGridViewKlimzon.Name = "PiketajDataGridViewKlimzon"
		'
		'StGolEkwDataGridViewTextBoxColumn
		'
		Me.StGolEkwDataGridViewTextBoxColumn.DataPropertyName = "StGolEkw"
		resources.ApplyResources(Me.StGolEkwDataGridViewTextBoxColumn, "StGolEkwDataGridViewTextBoxColumn")
		Me.StGolEkwDataGridViewTextBoxColumn.Name = "StGolEkwDataGridViewTextBoxColumn"
		'
		'StGolUslDataGridViewTextBoxColumn
		'
		Me.StGolUslDataGridViewTextBoxColumn.DataPropertyName = "StGolUsl"
		resources.ApplyResources(Me.StGolUslDataGridViewTextBoxColumn, "StGolUslDataGridViewTextBoxColumn")
		Me.StGolUslDataGridViewTextBoxColumn.Name = "StGolUslDataGridViewTextBoxColumn"
		'
		'TexspDataGridViewTextBoxColumn
		'
		Me.TexspDataGridViewTextBoxColumn.DataPropertyName = "Texsp"
		resources.ApplyResources(Me.TexspDataGridViewTextBoxColumn, "TexspDataGridViewTextBoxColumn")
		Me.TexspDataGridViewTextBoxColumn.Name = "TexspDataGridViewTextBoxColumn"
		'
		'TgolDataGridViewTextBoxColumn
		'
		Me.TgolDataGridViewTextBoxColumn.DataPropertyName = "Tgol"
		resources.ApplyResources(Me.TgolDataGridViewTextBoxColumn, "TgolDataGridViewTextBoxColumn")
		Me.TgolDataGridViewTextBoxColumn.Name = "TgolDataGridViewTextBoxColumn"
		'
		'TminDataGridViewTextBoxColumn
		'
		Me.TminDataGridViewTextBoxColumn.DataPropertyName = "Tmin"
		resources.ApplyResources(Me.TminDataGridViewTextBoxColumn, "TminDataGridViewTextBoxColumn")
		Me.TminDataGridViewTextBoxColumn.Name = "TminDataGridViewTextBoxColumn"
		'
		'TmaxDataGridViewTextBoxColumn
		'
		Me.TmaxDataGridViewTextBoxColumn.DataPropertyName = "Tmax"
		resources.ApplyResources(Me.TmaxDataGridViewTextBoxColumn, "TmaxDataGridViewTextBoxColumn")
		Me.TmaxDataGridViewTextBoxColumn.Name = "TmaxDataGridViewTextBoxColumn"
		'
		'NaporVetraDataGridViewTextBoxColumn
		'
		Me.NaporVetraDataGridViewTextBoxColumn.DataPropertyName = "NaporVetra"
		resources.ApplyResources(Me.NaporVetraDataGridViewTextBoxColumn, "NaporVetraDataGridViewTextBoxColumn")
		Me.NaporVetraDataGridViewTextBoxColumn.Name = "NaporVetraDataGridViewTextBoxColumn"
		'
		'NapPriGolDataGridViewTextBoxColumn
		'
		Me.NapPriGolDataGridViewTextBoxColumn.DataPropertyName = "NapPriGol"
		resources.ApplyResources(Me.NapPriGolDataGridViewTextBoxColumn, "NapPriGolDataGridViewTextBoxColumn")
		Me.NapPriGolDataGridViewTextBoxColumn.Name = "NapPriGolDataGridViewTextBoxColumn"
		'
		'TipMestaDataGridViewTextBoxColumn
		'
		Me.TipMestaDataGridViewTextBoxColumn.DataPropertyName = "TipMesta"
		resources.ApplyResources(Me.TipMestaDataGridViewTextBoxColumn, "TipMestaDataGridViewTextBoxColumn")
		Me.TipMestaDataGridViewTextBoxColumn.Name = "TipMestaDataGridViewTextBoxColumn"
		Me.TipMestaDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
		Me.TipMestaDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
		'
		'PolzDataGridViewTextBoxColumn
		'
		Me.PolzDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.PolzDataGridViewTextBoxColumn.DataPropertyName = "Polz"
		resources.ApplyResources(Me.PolzDataGridViewTextBoxColumn, "PolzDataGridViewTextBoxColumn")
		Me.PolzDataGridViewTextBoxColumn.Name = "PolzDataGridViewTextBoxColumn"
		Me.PolzDataGridViewTextBoxColumn.ReadOnly = True
		'
		'DataWDataGridViewTextBoxColumn
		'
		Me.DataWDataGridViewTextBoxColumn.DataPropertyName = "DataW"
		resources.ApplyResources(Me.DataWDataGridViewTextBoxColumn, "DataWDataGridViewTextBoxColumn")
		Me.DataWDataGridViewTextBoxColumn.Name = "DataWDataGridViewTextBoxColumn"
		Me.DataWDataGridViewTextBoxColumn.ReadOnly = True
		'
		'Profil
		'
		resources.ApplyResources(Me.Profil, "Profil")
		Me.Profil.Controls.Add(Me.TextBoxBegSdwig)
		Me.Profil.Controls.Add(Me.TextBoxIzmOtm)
		Me.Profil.Controls.Add(Me.TextBoxSdwig)
		Me.Profil.Controls.Add(Me.DataGridViewProfil)
		Me.Profil.Controls.Add(Me.LabelWibrPik)
		Me.Profil.Controls.Add(Me.ButtonInversij)
		Me.Profil.Controls.Add(Me.Label1)
		Me.Profil.Controls.Add(Me.DataGridViewPikUgod)
		Me.Profil.Controls.Add(Me.ButtonIzmOtm)
		Me.Profil.Controls.Add(Me.ButtonObmPrnaLew)
		Me.Profil.Controls.Add(Me.ButtonSdwigPik)
		Me.HelpProvider1.SetHelpKeyword(Me.Profil, resources.GetString("Profil.HelpKeyword"))
		Me.HelpProvider1.SetHelpNavigator(Me.Profil, CType(resources.GetObject("Profil.HelpNavigator"), System.Windows.Forms.HelpNavigator))
		Me.HelpProvider1.SetHelpString(Me.Profil, resources.GetString("Profil.HelpString"))
		Me.Profil.Name = "Profil"
		Me.HelpProvider1.SetShowHelp(Me.Profil, CType(resources.GetObject("Profil.ShowHelp"), Boolean))
		Me.Profil.UseVisualStyleBackColor = True
		'
		'TextBoxBegSdwig
		'
		resources.ApplyResources(Me.TextBoxBegSdwig, "TextBoxBegSdwig")
		Me.HelpProvider1.SetHelpKeyword(Me.TextBoxBegSdwig, resources.GetString("TextBoxBegSdwig.HelpKeyword"))
		Me.HelpProvider1.SetHelpNavigator(Me.TextBoxBegSdwig, CType(resources.GetObject("TextBoxBegSdwig.HelpNavigator"), System.Windows.Forms.HelpNavigator))
		Me.HelpProvider1.SetHelpString(Me.TextBoxBegSdwig, resources.GetString("TextBoxBegSdwig.HelpString"))
		Me.TextBoxBegSdwig.Name = "TextBoxBegSdwig"
		Me.HelpProvider1.SetShowHelp(Me.TextBoxBegSdwig, CType(resources.GetObject("TextBoxBegSdwig.ShowHelp"), Boolean))
		'
		'TextBoxIzmOtm
		'
		resources.ApplyResources(Me.TextBoxIzmOtm, "TextBoxIzmOtm")
		Me.HelpProvider1.SetHelpKeyword(Me.TextBoxIzmOtm, resources.GetString("TextBoxIzmOtm.HelpKeyword"))
		Me.HelpProvider1.SetHelpNavigator(Me.TextBoxIzmOtm, CType(resources.GetObject("TextBoxIzmOtm.HelpNavigator"), System.Windows.Forms.HelpNavigator))
		Me.HelpProvider1.SetHelpString(Me.TextBoxIzmOtm, resources.GetString("TextBoxIzmOtm.HelpString"))
		Me.TextBoxIzmOtm.Name = "TextBoxIzmOtm"
		Me.HelpProvider1.SetShowHelp(Me.TextBoxIzmOtm, CType(resources.GetObject("TextBoxIzmOtm.ShowHelp"), Boolean))
		'
		'TextBoxSdwig
		'
		resources.ApplyResources(Me.TextBoxSdwig, "TextBoxSdwig")
		Me.HelpProvider1.SetHelpKeyword(Me.TextBoxSdwig, resources.GetString("TextBoxSdwig.HelpKeyword"))
		Me.HelpProvider1.SetHelpNavigator(Me.TextBoxSdwig, CType(resources.GetObject("TextBoxSdwig.HelpNavigator"), System.Windows.Forms.HelpNavigator))
		Me.HelpProvider1.SetHelpString(Me.TextBoxSdwig, resources.GetString("TextBoxSdwig.HelpString"))
		Me.TextBoxSdwig.Name = "TextBoxSdwig"
		Me.HelpProvider1.SetShowHelp(Me.TextBoxSdwig, CType(resources.GetObject("TextBoxSdwig.ShowHelp"), Boolean))
		'
		'DataGridViewProfil
		'
		resources.ApplyResources(Me.DataGridViewProfil, "DataGridViewProfil")
		Me.DataGridViewProfil.AutoGenerateColumns = False
		Me.DataGridViewProfil.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
		Me.DataGridViewProfil.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NameTchkDataGridViewTextBoxColumn, Me.Piketaj1, Me.Otmetka1, Me.OtmetkaPrDataGridViewTextBoxColumn, Me.OtmetkaLwDataGridViewTextBoxColumn, Me.UIdTchk1, Me.UIdUch1, Me.IdTipSoor1, Me.Param1DataGridViewTextBoxColumn1, Me.Param2DataGridViewTextBoxColumn1, Me.Param3DataGridViewTextBoxColumn1, Me.Param4DataGridViewTextBoxColumn1, Me.OpisDataGridViewTextBoxColumn1, Me.UgolPoworotDataGridViewTextBoxColumn2})
		Me.DataGridViewProfil.DataMember = "ProfilA"
		Me.DataGridViewProfil.DataSource = Me.DsProfilA
		DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
		DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
		DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
		DataGridViewCellStyle1.Format = "N2"
		DataGridViewCellStyle1.NullValue = Nothing
		DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
		Me.DataGridViewProfil.DefaultCellStyle = DataGridViewCellStyle1
		Me.DataGridViewProfil.GridColor = System.Drawing.SystemColors.ControlText
		Me.HelpProvider1.SetHelpKeyword(Me.DataGridViewProfil, resources.GetString("DataGridViewProfil.HelpKeyword"))
		Me.HelpProvider1.SetHelpNavigator(Me.DataGridViewProfil, CType(resources.GetObject("DataGridViewProfil.HelpNavigator"), System.Windows.Forms.HelpNavigator))
		Me.HelpProvider1.SetHelpString(Me.DataGridViewProfil, resources.GetString("DataGridViewProfil.HelpString"))
		Me.DataGridViewProfil.Name = "DataGridViewProfil"
		Me.HelpProvider1.SetShowHelp(Me.DataGridViewProfil, CType(resources.GetObject("DataGridViewProfil.ShowHelp"), Boolean))
		'
		'NameTchkDataGridViewTextBoxColumn
		'
		Me.NameTchkDataGridViewTextBoxColumn.DataPropertyName = "NameTchk"
		resources.ApplyResources(Me.NameTchkDataGridViewTextBoxColumn, "NameTchkDataGridViewTextBoxColumn")
		Me.NameTchkDataGridViewTextBoxColumn.Name = "NameTchkDataGridViewTextBoxColumn"
		'
		'Piketaj1
		'
		Me.Piketaj1.DataPropertyName = "Piketaj"
		resources.ApplyResources(Me.Piketaj1, "Piketaj1")
		Me.Piketaj1.Name = "Piketaj1"
		'
		'Otmetka1
		'
		Me.Otmetka1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
		Me.Otmetka1.DataPropertyName = "Otmetka"
		resources.ApplyResources(Me.Otmetka1, "Otmetka1")
		Me.Otmetka1.Name = "Otmetka1"
		'
		'OtmetkaPrDataGridViewTextBoxColumn
		'
		Me.OtmetkaPrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
		Me.OtmetkaPrDataGridViewTextBoxColumn.DataPropertyName = "OtmetkaPr"
		resources.ApplyResources(Me.OtmetkaPrDataGridViewTextBoxColumn, "OtmetkaPrDataGridViewTextBoxColumn")
		Me.OtmetkaPrDataGridViewTextBoxColumn.Name = "OtmetkaPrDataGridViewTextBoxColumn"
		'
		'OtmetkaLwDataGridViewTextBoxColumn
		'
		Me.OtmetkaLwDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
		Me.OtmetkaLwDataGridViewTextBoxColumn.DataPropertyName = "OtmetkaLw"
		resources.ApplyResources(Me.OtmetkaLwDataGridViewTextBoxColumn, "OtmetkaLwDataGridViewTextBoxColumn")
		Me.OtmetkaLwDataGridViewTextBoxColumn.Name = "OtmetkaLwDataGridViewTextBoxColumn"
		'
		'UIdTchk1
		'
		Me.UIdTchk1.DataPropertyName = "UIdTchk"
		resources.ApplyResources(Me.UIdTchk1, "UIdTchk1")
		Me.UIdTchk1.Name = "UIdTchk1"
		'
		'UIdUch1
		'
		Me.UIdUch1.DataPropertyName = "UIdUch"
		resources.ApplyResources(Me.UIdUch1, "UIdUch1")
		Me.UIdUch1.Name = "UIdUch1"
		'
		'IdTipSoor1
		'
		Me.IdTipSoor1.DataPropertyName = "IdTipSoor"
		resources.ApplyResources(Me.IdTipSoor1, "IdTipSoor1")
		Me.IdTipSoor1.Name = "IdTipSoor1"
		Me.IdTipSoor1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
		Me.IdTipSoor1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
		'
		'Param1DataGridViewTextBoxColumn1
		'
		Me.Param1DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
		Me.Param1DataGridViewTextBoxColumn1.DataPropertyName = "Param1"
		resources.ApplyResources(Me.Param1DataGridViewTextBoxColumn1, "Param1DataGridViewTextBoxColumn1")
		Me.Param1DataGridViewTextBoxColumn1.Name = "Param1DataGridViewTextBoxColumn1"
		'
		'Param2DataGridViewTextBoxColumn1
		'
		Me.Param2DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
		Me.Param2DataGridViewTextBoxColumn1.DataPropertyName = "Param2"
		resources.ApplyResources(Me.Param2DataGridViewTextBoxColumn1, "Param2DataGridViewTextBoxColumn1")
		Me.Param2DataGridViewTextBoxColumn1.Name = "Param2DataGridViewTextBoxColumn1"
		'
		'Param3DataGridViewTextBoxColumn1
		'
		Me.Param3DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
		Me.Param3DataGridViewTextBoxColumn1.DataPropertyName = "Param3"
		resources.ApplyResources(Me.Param3DataGridViewTextBoxColumn1, "Param3DataGridViewTextBoxColumn1")
		Me.Param3DataGridViewTextBoxColumn1.Name = "Param3DataGridViewTextBoxColumn1"
		'
		'Param4DataGridViewTextBoxColumn1
		'
		Me.Param4DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
		Me.Param4DataGridViewTextBoxColumn1.DataPropertyName = "Param4"
		resources.ApplyResources(Me.Param4DataGridViewTextBoxColumn1, "Param4DataGridViewTextBoxColumn1")
		Me.Param4DataGridViewTextBoxColumn1.Name = "Param4DataGridViewTextBoxColumn1"
		'
		'OpisDataGridViewTextBoxColumn1
		'
		Me.OpisDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.OpisDataGridViewTextBoxColumn1.DataPropertyName = "Opis"
		resources.ApplyResources(Me.OpisDataGridViewTextBoxColumn1, "OpisDataGridViewTextBoxColumn1")
		Me.OpisDataGridViewTextBoxColumn1.Name = "OpisDataGridViewTextBoxColumn1"
		'
		'UgolPoworotDataGridViewTextBoxColumn2
		'
		Me.UgolPoworotDataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
		Me.UgolPoworotDataGridViewTextBoxColumn2.DataPropertyName = "UgolPoworot"
		resources.ApplyResources(Me.UgolPoworotDataGridViewTextBoxColumn2, "UgolPoworotDataGridViewTextBoxColumn2")
		Me.UgolPoworotDataGridViewTextBoxColumn2.Name = "UgolPoworotDataGridViewTextBoxColumn2"
		Me.UgolPoworotDataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
		Me.UgolPoworotDataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
		'
		'LabelWibrPik
		'
		resources.ApplyResources(Me.LabelWibrPik, "LabelWibrPik")
		Me.HelpProvider1.SetHelpKeyword(Me.LabelWibrPik, resources.GetString("LabelWibrPik.HelpKeyword"))
		Me.HelpProvider1.SetHelpNavigator(Me.LabelWibrPik, CType(resources.GetObject("LabelWibrPik.HelpNavigator"), System.Windows.Forms.HelpNavigator))
		Me.HelpProvider1.SetHelpString(Me.LabelWibrPik, resources.GetString("LabelWibrPik.HelpString"))
		Me.LabelWibrPik.Name = "LabelWibrPik"
		Me.HelpProvider1.SetShowHelp(Me.LabelWibrPik, CType(resources.GetObject("LabelWibrPik.ShowHelp"), Boolean))
		'
		'Label1
		'
		resources.ApplyResources(Me.Label1, "Label1")
		Me.HelpProvider1.SetHelpKeyword(Me.Label1, resources.GetString("Label1.HelpKeyword"))
		Me.HelpProvider1.SetHelpNavigator(Me.Label1, CType(resources.GetObject("Label1.HelpNavigator"), System.Windows.Forms.HelpNavigator))
		Me.HelpProvider1.SetHelpString(Me.Label1, resources.GetString("Label1.HelpString"))
		Me.Label1.Name = "Label1"
		Me.HelpProvider1.SetShowHelp(Me.Label1, CType(resources.GetObject("Label1.ShowHelp"), Boolean))
		'
		'DataGridViewPikUgod
		'
		resources.ApplyResources(Me.DataGridViewPikUgod, "DataGridViewPikUgod")
		Me.DataGridViewPikUgod.AutoGenerateColumns = False
		Me.DataGridViewPikUgod.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
		Me.DataGridViewPikUgod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.DataGridViewPikUgod.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewComboBoxPiketaj, Me.TipDataGridViewComboBoxColumn})
		Me.DataGridViewPikUgod.DataSource = Me.PiketUgodBindingSource
		Me.HelpProvider1.SetHelpKeyword(Me.DataGridViewPikUgod, resources.GetString("DataGridViewPikUgod.HelpKeyword"))
		Me.HelpProvider1.SetHelpNavigator(Me.DataGridViewPikUgod, CType(resources.GetObject("DataGridViewPikUgod.HelpNavigator"), System.Windows.Forms.HelpNavigator))
		Me.HelpProvider1.SetHelpString(Me.DataGridViewPikUgod, resources.GetString("DataGridViewPikUgod.HelpString"))
		Me.DataGridViewPikUgod.Name = "DataGridViewPikUgod"
		Me.HelpProvider1.SetShowHelp(Me.DataGridViewPikUgod, CType(resources.GetObject("DataGridViewPikUgod.ShowHelp"), Boolean))
		'
		'DataGridViewComboBoxPiketaj
		'
		Me.DataGridViewComboBoxPiketaj.DataPropertyName = "Piketaj"
		resources.ApplyResources(Me.DataGridViewComboBoxPiketaj, "DataGridViewComboBoxPiketaj")
		Me.DataGridViewComboBoxPiketaj.Name = "DataGridViewComboBoxPiketaj"
		Me.DataGridViewComboBoxPiketaj.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
		Me.DataGridViewComboBoxPiketaj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
		'
		'TipDataGridViewComboBoxColumn
		'
		Me.TipDataGridViewComboBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.TipDataGridViewComboBoxColumn.DataPropertyName = "Tip"
		resources.ApplyResources(Me.TipDataGridViewComboBoxColumn, "TipDataGridViewComboBoxColumn")
		Me.TipDataGridViewComboBoxColumn.Name = "TipDataGridViewComboBoxColumn"
		Me.TipDataGridViewComboBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
		Me.TipDataGridViewComboBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
		'
		'TabControl1
		'
		resources.ApplyResources(Me.TabControl1, "TabControl1")
		Me.TabControl1.Controls.Add(Me.Profil)
		Me.TabControl1.Controls.Add(Me.Klimat)
		Me.HelpProvider1.SetHelpKeyword(Me.TabControl1, resources.GetString("TabControl1.HelpKeyword"))
		Me.HelpProvider1.SetHelpNavigator(Me.TabControl1, CType(resources.GetObject("TabControl1.HelpNavigator"), System.Windows.Forms.HelpNavigator))
		Me.HelpProvider1.SetHelpString(Me.TabControl1, resources.GetString("TabControl1.HelpString"))
		Me.TabControl1.Name = "TabControl1"
		Me.TabControl1.SelectedIndex = 0
		Me.HelpProvider1.SetShowHelp(Me.TabControl1, CType(resources.GetObject("TabControl1.ShowHelp"), Boolean))
		'
		'ToolStripButtonAllOk
		'
		resources.ApplyResources(Me.ToolStripButtonAllOk, "ToolStripButtonAllOk")
		Me.ToolStripButtonAllOk.Name = "ToolStripButtonAllOk"
		'
		'FrmKorrProfilWlUch
		'
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.TabControl1)
		Me.Controls.Add(Me.ToolStripUprKorrUch)
		Me.HelpProvider1.SetHelpKeyword(Me, resources.GetString("$this.HelpKeyword"))
		Me.HelpProvider1.SetHelpNavigator(Me, CType(resources.GetObject("$this.HelpNavigator"), System.Windows.Forms.HelpNavigator))
		Me.HelpProvider1.SetHelpString(Me, resources.GetString("$this.HelpString"))
		Me.Name = "FrmKorrProfilWlUch"
		Me.HelpProvider1.SetShowHelp(Me, CType(resources.GetObject("$this.ShowHelp"), Boolean))
		CType(Me.DsProfilA, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.ClsZonKlimatBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ToolStripUprKorrUch.ResumeLayout(False)
		Me.ToolStripUprKorrUch.PerformLayout()
		CType(Me.PiketUgodBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Klimat.ResumeLayout(False)
		CType(Me.KlimatGridView, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Profil.ResumeLayout(False)
		Me.Profil.PerformLayout()
		CType(Me.DataGridViewProfil, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.DataGridViewPikUgod, System.ComponentModel.ISupportInitialize).EndInit()
		Me.TabControl1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents NameTrDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ClsZonKlimatBindingSource As System.Windows.Forms.BindingSource
	Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn23 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn24 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn25 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn27 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn28 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn29 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn30 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn31 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn32 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn34 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents NamePiketDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn35 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn36 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn37 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents NameUch As System.Windows.Forms.ToolStripLabel
	Friend WithEvents DataGridViewTextBoxColumn38 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn39 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn40 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn41 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn42 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn43 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn44 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn45 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn46 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn47 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn48 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn49 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn50 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn51 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn52 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn53 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn54 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn55 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn56 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn57 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents ToolStripLabelGr As System.Windows.Forms.ToolStripLabel
	Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents ToolStripLabelPikEnd As System.Windows.Forms.ToolStripLabel
	Friend WithEvents PiketUgodBindingSource As System.Windows.Forms.BindingSource
	Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents TipiDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
	Friend WithEvents ToolStripLabelWibrPiket As System.Windows.Forms.ToolStripLabel
	Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents ToolStripUprKorrUch As System.Windows.Forms.ToolStrip
	Public WithEvents ToolStripLabelPikBeg As System.Windows.Forms.ToolStripLabel
	Public WithEvents DsProfilA As DsProfil
	Public WithEvents NameFileUch As System.Windows.Forms.ToolStripLabel
	Public WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
	Friend WithEvents Klimat As System.Windows.Forms.TabPage
	Friend WithEvents KlimatGridView As System.Windows.Forms.DataGridView
	Friend WithEvents Profil As System.Windows.Forms.TabPage
	Friend WithEvents TextBoxBegSdwig As System.Windows.Forms.TextBox
	Friend WithEvents TextBoxIzmOtm As System.Windows.Forms.TextBox
	Friend WithEvents TextBoxSdwig As System.Windows.Forms.TextBox
	Friend WithEvents DataGridViewProfil As System.Windows.Forms.DataGridView
	Friend WithEvents NameTchkDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents Piketaj1 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents Otmetka1 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents OtmetkaPrDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents OtmetkaLwDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents UIdTchk1 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents UIdUch1 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents IdTipSoor1 As System.Windows.Forms.DataGridViewComboBoxColumn
	Friend WithEvents Param1DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents Param2DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents Param3DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents Param4DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents OpisDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents UgolPoworotDataGridViewTextBoxColumn2 As OperBD.MaskedTextBoxColumn
	Friend WithEvents LabelWibrPik As System.Windows.Forms.Label
	Friend WithEvents ButtonInversij As System.Windows.Forms.Button
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents DataGridViewPikUgod As System.Windows.Forms.DataGridView
	Friend WithEvents DataGridViewComboBoxPiketaj As System.Windows.Forms.DataGridViewComboBoxColumn
	Friend WithEvents TipDataGridViewComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
	Friend WithEvents ButtonIzmOtm As System.Windows.Forms.Button
	Friend WithEvents ButtonObmPrnaLew As System.Windows.Forms.Button
	Friend WithEvents ButtonSdwigPik As System.Windows.Forms.Button
	Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
	Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents ToolStripButtonSohrDwg As System.Windows.Forms.ToolStripButton
	Friend WithEvents PiketajDataGridViewKlimzon As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents StGolEkwDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents StGolUslDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents TexspDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents TgolDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents TminDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents TmaxDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents NaporVetraDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents NapPriGolDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents TipMestaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
	Friend WithEvents PolzDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataWDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	Public WithEvents ToolStripButtonAllOk As ToolStripButton
End Class
