<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmKorrRasstWlUch
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmKorrRasstWlUch))
        Me.RastOpDataGridView = New System.Windows.Forms.DataGridView()
        Me.NumNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PiketajDataGridViewRasstOp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipDataGridViewOpRasstColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.NameTipOpor = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.nameGirl = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.NameGirlT = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.WisotaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PodwesW = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UgolPoworotDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RastOpNBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsRasst1 = New OperBD.dsRasst()
        Me.ContextMenuStripObm = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItemCop = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemIns = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemDel = New System.Windows.Forms.ToolStripMenuItem()
        Me.MechUslDataGridView = New System.Windows.Forms.DataGridView()
        Me.ClszonMechuslBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.GnwDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GnwGDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GregDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GregGolDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipopADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.TipopPDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DlGirlDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MassGirlDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NamemarkDataGridViewParamUch = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.NamemarkTDataGridViewParamUch = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DlGirlTDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MassGirlTDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WlDefParamBindingSource = New System.Windows.Forms.BindingSource(Me.components)
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
        Me.ToolStripButtonAllOk = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButtonSohrDwg = New System.Windows.Forms.ToolStripButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Profil = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridViewPikUgod = New System.Windows.Forms.DataGridView()
        Me.DataGridViewComboBoxPiketaj = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.TipDataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.PiketUgodBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsProfilA = New OperBD.DsProfil()
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
        Me.Klimat = New System.Windows.Forms.TabPage()
        Me.KlimatGridView = New System.Windows.Forms.DataGridView()
        Me.PiketajDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.ClsZonKlimatBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Rasstanowka = New System.Windows.Forms.TabPage()
        Me.TextBoxSuffiks = New System.Windows.Forms.TextBox()
        Me.ButtonSuffix = New System.Windows.Forms.Button()
        Me.CheckBoxNapr = New System.Windows.Forms.CheckBox()
        Me.TextBoxNachNum = New System.Windows.Forms.TextBox()
        Me.ButtonPerenum = New System.Windows.Forms.Button()
        Me.Element1 = New System.Windows.Forms.TabPage()
        Me.GirlajndDataGridView = New System.Windows.Forms.DataGridView()
        Me.NameGDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Zepnost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DlGirlDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MassGirlDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ssech = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GirlajndBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ElemRasstUch1 = New OperBD.ElemRasstUch()
        Me.ProvodaDataGridView = New System.Windows.Forms.DataGridView()
        Me.UserMarkDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sprwd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DiamPrwd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ppogon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SigMax = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Alfa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Jung = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SigGol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SigSrG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tekpl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ModF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ModD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProvodaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.OporDataGridView = New System.Windows.Forms.DataGridView()
        Me.UserTipOpDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipiDataGridViewOporUchColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.WisopDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WinosDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Wisop1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Winos1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Wisop2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Winos2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WisopTDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WinosTDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ZepnDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OporBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
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
        Me.PiketajMechusl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipopDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.NamemarkDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ProwodFaz = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sig7TgolDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sig1TminDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sig1TexspDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NamemarkTDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.GabaritDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sig7_TgolT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sig1_TexspT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Name_markW = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Sig7_TgolW = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sig1_TexspW = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.RastOpDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RastOpNBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsRasst1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripObm.SuspendLayout()
        CType(Me.MechUslDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClszonMechuslBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WlDefParamBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStripUprKorrUch.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.Profil.SuspendLayout()
        CType(Me.DataGridViewPikUgod, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PiketUgodBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsProfilA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewProfil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Klimat.SuspendLayout()
        CType(Me.KlimatGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClsZonKlimatBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Rasstanowka.SuspendLayout()
        Me.Element1.SuspendLayout()
        CType(Me.GirlajndDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GirlajndBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ElemRasstUch1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProvodaDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProvodaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OporDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OporBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RastOpDataGridView
        '
        Me.RastOpDataGridView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RastOpDataGridView.AutoGenerateColumns = False
        Me.RastOpDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.RastOpDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.RastOpDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NumNameDataGridViewTextBoxColumn, Me.PiketajDataGridViewRasstOp, Me.TipDataGridViewOpRasstColumn, Me.NameTipOpor, Me.nameGirl, Me.NameGirlT, Me.WisotaDataGridViewTextBoxColumn, Me.PodwesW, Me.UgolPoworotDataGridViewTextBoxColumn1})
        Me.RastOpDataGridView.DataSource = Me.RastOpNBindingSource
        Me.RastOpDataGridView.Location = New System.Drawing.Point(6, 89)
        Me.RastOpDataGridView.Name = "RastOpDataGridView"
        Me.RastOpDataGridView.Size = New System.Drawing.Size(732, 685)
        Me.RastOpDataGridView.TabIndex = 3
        '
        'NumNameDataGridViewTextBoxColumn
        '
        Me.NumNameDataGridViewTextBoxColumn.DataPropertyName = "NumName"
        Me.NumNameDataGridViewTextBoxColumn.HeaderText = "Номер оп."
        Me.NumNameDataGridViewTextBoxColumn.Name = "NumNameDataGridViewTextBoxColumn"
        Me.NumNameDataGridViewTextBoxColumn.ToolTipText = "Обозначение опоры в расстановки допускаються буквы"
        Me.NumNameDataGridViewTextBoxColumn.Width = 78
        '
        'PiketajDataGridViewRasstOp
        '
        Me.PiketajDataGridViewRasstOp.DataPropertyName = "Piketaj"
        Me.PiketajDataGridViewRasstOp.HeaderText = "Пикетаж"
        Me.PiketajDataGridViewRasstOp.Name = "PiketajDataGridViewRasstOp"
        Me.PiketajDataGridViewRasstOp.Width = 77
        '
        'TipDataGridViewOpRasstColumn
        '
        Me.TipDataGridViewOpRasstColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.TipDataGridViewOpRasstColumn.DataPropertyName = "Tip"
        Me.TipDataGridViewOpRasstColumn.HeaderText = "Тип опоры"
        Me.TipDataGridViewOpRasstColumn.Name = "TipDataGridViewOpRasstColumn"
        Me.TipDataGridViewOpRasstColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TipDataGridViewOpRasstColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.TipDataGridViewOpRasstColumn.ToolTipText = "тип опоры промежуточная или анкерная"
        Me.TipDataGridViewOpRasstColumn.Width = 60
        '
        'NameTipOpor
        '
        Me.NameTipOpor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.NameTipOpor.DataPropertyName = "Tip_op"
        Me.NameTipOpor.HeaderText = "Шифр опоры"
        Me.NameTipOpor.Name = "NameTipOpor"
        Me.NameTipOpor.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.NameTipOpor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'nameGirl
        '
        Me.nameGirl.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.nameGirl.DataPropertyName = "NameGirl"
        Me.nameGirl.HeaderText = "Гирл. Пр"
        Me.nameGirl.Name = "nameGirl"
        Me.nameGirl.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.nameGirl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.nameGirl.ToolTipText = "наименование гирлянды провода если используеться отличная от умалчиваемых"
        Me.nameGirl.Width = 60
        '
        'NameGirlT
        '
        Me.NameGirlT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.NameGirlT.DataPropertyName = "NameGirlT"
        Me.NameGirlT.HeaderText = "Креп. Тр"
        Me.NameGirlT.Name = "NameGirlT"
        Me.NameGirlT.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.NameGirlT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.NameGirlT.ToolTipText = "наименование крепления троса если используеться отличная от умалчиваемых"
        Me.NameGirlT.Width = 60
        '
        'WisotaDataGridViewTextBoxColumn
        '
        Me.WisotaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.WisotaDataGridViewTextBoxColumn.DataPropertyName = "Wisota"
        Me.WisotaDataGridViewTextBoxColumn.HeaderText = "Осн. от земли(м.)"
        Me.WisotaDataGridViewTextBoxColumn.Name = "WisotaDataGridViewTextBoxColumn"
        Me.WisotaDataGridViewTextBoxColumn.ToolTipText = "заглубление или приподнятие опоры"
        Me.WisotaDataGridViewTextBoxColumn.Width = 70
        '
        'PodwesW
        '
        Me.PodwesW.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.PodwesW.DataPropertyName = "PodwesW"
        Me.PodwesW.HeaderText = "Подвес ОКСН"
        Me.PodwesW.Name = "PodwesW"
        Me.PodwesW.Width = 70
        '
        'UgolPoworotDataGridViewTextBoxColumn1
        '
        Me.UgolPoworotDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.UgolPoworotDataGridViewTextBoxColumn1.DataPropertyName = "UgolPoworot"
        Me.UgolPoworotDataGridViewTextBoxColumn1.HeaderText = "Угол поворота"
        Me.UgolPoworotDataGridViewTextBoxColumn1.Name = "UgolPoworotDataGridViewTextBoxColumn1"
        Me.UgolPoworotDataGridViewTextBoxColumn1.ToolTipText = "Угол поворота относительно биссектрисы угла"
        Me.UgolPoworotDataGridViewTextBoxColumn1.Width = 75
        '
        'RastOpNBindingSource
        '
        Me.RastOpNBindingSource.DataMember = "rastOpN"
        Me.RastOpNBindingSource.DataSource = Me.DsRasst1
        Me.RastOpNBindingSource.Sort = "Piketaj"
        '
        'DsRasst1
        '
        Me.DsRasst1.DataSetName = "dsRasst"
        Me.DsRasst1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ContextMenuStripObm
        '
        Me.ContextMenuStripObm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemCop, Me.ToolStripMenuItemIns, Me.ToolStripMenuItemDel})
        Me.ContextMenuStripObm.Name = "ContextMenuStripObm"
        Me.ContextMenuStripObm.Size = New System.Drawing.Size(140, 70)
        '
        'ToolStripMenuItemCop
        '
        Me.ToolStripMenuItemCop.Name = "ToolStripMenuItemCop"
        Me.ToolStripMenuItemCop.Size = New System.Drawing.Size(139, 22)
        Me.ToolStripMenuItemCop.Text = "Копировать"
        '
        'ToolStripMenuItemIns
        '
        Me.ToolStripMenuItemIns.Name = "ToolStripMenuItemIns"
        Me.ToolStripMenuItemIns.Size = New System.Drawing.Size(139, 22)
        Me.ToolStripMenuItemIns.Text = "Вставить"
        '
        'ToolStripMenuItemDel
        '
        Me.ToolStripMenuItemDel.Name = "ToolStripMenuItemDel"
        Me.ToolStripMenuItemDel.Size = New System.Drawing.Size(139, 22)
        Me.ToolStripMenuItemDel.Text = "Удалить"
        '
        'MechUslDataGridView
        '
        Me.MechUslDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MechUslDataGridView.AutoGenerateColumns = False
        Me.MechUslDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.MechUslDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.MechUslDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PiketajMechusl, Me.TipopDataGridViewTextBoxColumn, Me.NamemarkDataGridViewTextBoxColumn, Me.ProwodFaz, Me.Sig7TgolDataGridViewTextBoxColumn, Me.Sig1TminDataGridViewTextBoxColumn, Me.Sig1TexspDataGridViewTextBoxColumn, Me.NamemarkTDataGridViewTextBoxColumn, Me.GabaritDataGridViewTextBoxColumn, Me.Sig7_TgolT, Me.Sig1_TexspT, Me.Name_markW, Me.Sig7_TgolW, Me.Sig1_TexspW})
        Me.MechUslDataGridView.DataSource = Me.ClszonMechuslBindingSource
        Me.MechUslDataGridView.Location = New System.Drawing.Point(760, 93)
        Me.MechUslDataGridView.Name = "MechUslDataGridView"
        Me.MechUslDataGridView.Size = New System.Drawing.Size(845, 681)
        Me.MechUslDataGridView.TabIndex = 4
        '
        'ClszonMechuslBindingSource
        '
        Me.ClszonMechuslBindingSource.DataMember = "MechUsl"
        Me.ClszonMechuslBindingSource.DataSource = Me.DsRasst1
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AutoGenerateColumns = False
        Me.DataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GnwDataGridViewTextBoxColumn, Me.GnwGDataGridViewTextBoxColumn, Me.GregDataGridViewTextBoxColumn, Me.GregGolDataGridViewTextBoxColumn, Me.TipopADataGridViewTextBoxColumn, Me.TipopPDataGridViewTextBoxColumn, Me.DlGirlDataGridViewTextBoxColumn, Me.MassGirlDataGridViewTextBoxColumn, Me.NamemarkDataGridViewParamUch, Me.NamemarkTDataGridViewParamUch, Me.DlGirlTDataGridViewTextBoxColumn, Me.MassGirlTDataGridViewTextBoxColumn})
        Me.DataGridView2.DataSource = Me.WlDefParamBindingSource
        Me.DataGridView2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.DataGridView2.Location = New System.Drawing.Point(6, 20)
        Me.DataGridView2.Name = "DataGridView2"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.DataGridView2.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView2.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.DataGridView2.Size = New System.Drawing.Size(1405, 44)
        Me.DataGridView2.TabIndex = 5
        '
        'GnwDataGridViewTextBoxColumn
        '
        Me.GnwDataGridViewTextBoxColumn.DataPropertyName = "Gnw"
        Me.GnwDataGridViewTextBoxColumn.HeaderText = "Gnw"
        Me.GnwDataGridViewTextBoxColumn.Name = "GnwDataGridViewTextBoxColumn"
        Me.GnwDataGridViewTextBoxColumn.ToolTipText = "Нормативный коэффициэнт надежности по ветру"
        Me.GnwDataGridViewTextBoxColumn.Width = 54
        '
        'GnwGDataGridViewTextBoxColumn
        '
        Me.GnwGDataGridViewTextBoxColumn.DataPropertyName = "GnwG"
        Me.GnwGDataGridViewTextBoxColumn.HeaderText = "GnwG"
        Me.GnwGDataGridViewTextBoxColumn.Name = "GnwGDataGridViewTextBoxColumn"
        Me.GnwGDataGridViewTextBoxColumn.ToolTipText = "Нормативный коэффициэнт надежности по гололеду"
        Me.GnwGDataGridViewTextBoxColumn.Width = 62
        '
        'GregDataGridViewTextBoxColumn
        '
        Me.GregDataGridViewTextBoxColumn.DataPropertyName = "Greg"
        Me.GregDataGridViewTextBoxColumn.HeaderText = "Greg"
        Me.GregDataGridViewTextBoxColumn.Name = "GregDataGridViewTextBoxColumn"
        Me.GregDataGridViewTextBoxColumn.ToolTipText = "Региональный коэффициэнт коэффициэнт надежности по ветру"
        Me.GregDataGridViewTextBoxColumn.Width = 55
        '
        'GregGolDataGridViewTextBoxColumn
        '
        Me.GregGolDataGridViewTextBoxColumn.DataPropertyName = "GregGol"
        Me.GregGolDataGridViewTextBoxColumn.HeaderText = "GregGol"
        Me.GregGolDataGridViewTextBoxColumn.Name = "GregGolDataGridViewTextBoxColumn"
        Me.GregGolDataGridViewTextBoxColumn.ToolTipText = "Региональный коэффициэнт коэффициэнт надежности по гололеду"
        Me.GregGolDataGridViewTextBoxColumn.Width = 71
        '
        'TipopADataGridViewTextBoxColumn
        '
        Me.TipopADataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TipopADataGridViewTextBoxColumn.DataPropertyName = "Tip_opA"
        Me.TipopADataGridViewTextBoxColumn.HeaderText = "Шифр Анк. Оп."
        Me.TipopADataGridViewTextBoxColumn.Name = "TipopADataGridViewTextBoxColumn"
        Me.TipopADataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TipopADataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'TipopPDataGridViewTextBoxColumn
        '
        Me.TipopPDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TipopPDataGridViewTextBoxColumn.DataPropertyName = "Tip_opP"
        Me.TipopPDataGridViewTextBoxColumn.HeaderText = "Шифр Пром. Оп"
        Me.TipopPDataGridViewTextBoxColumn.Name = "TipopPDataGridViewTextBoxColumn"
        Me.TipopPDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TipopPDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DlGirlDataGridViewTextBoxColumn
        '
        Me.DlGirlDataGridViewTextBoxColumn.DataPropertyName = "DlGirl"
        Me.DlGirlDataGridViewTextBoxColumn.HeaderText = "Дл. гирл"
        Me.DlGirlDataGridViewTextBoxColumn.Name = "DlGirlDataGridViewTextBoxColumn"
        Me.DlGirlDataGridViewTextBoxColumn.Width = 76
        '
        'MassGirlDataGridViewTextBoxColumn
        '
        Me.MassGirlDataGridViewTextBoxColumn.DataPropertyName = "MassGirl"
        Me.MassGirlDataGridViewTextBoxColumn.HeaderText = "Масса гирл"
        Me.MassGirlDataGridViewTextBoxColumn.Name = "MassGirlDataGridViewTextBoxColumn"
        Me.MassGirlDataGridViewTextBoxColumn.Width = 91
        '
        'NamemarkDataGridViewParamUch
        '
        Me.NamemarkDataGridViewParamUch.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.NamemarkDataGridViewParamUch.DataPropertyName = "Name_mark"
        Me.NamemarkDataGridViewParamUch.HeaderText = "Марка провода"
        Me.NamemarkDataGridViewParamUch.Name = "NamemarkDataGridViewParamUch"
        Me.NamemarkDataGridViewParamUch.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.NamemarkDataGridViewParamUch.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'NamemarkTDataGridViewParamUch
        '
        Me.NamemarkTDataGridViewParamUch.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.NamemarkTDataGridViewParamUch.ContextMenuStrip = Me.ContextMenuStripObm
        Me.NamemarkTDataGridViewParamUch.DataPropertyName = "Name_markT"
        Me.NamemarkTDataGridViewParamUch.HeaderText = "Марка троса"
        Me.NamemarkTDataGridViewParamUch.Name = "NamemarkTDataGridViewParamUch"
        Me.NamemarkTDataGridViewParamUch.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.NamemarkTDataGridViewParamUch.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DlGirlTDataGridViewTextBoxColumn
        '
        Me.DlGirlTDataGridViewTextBoxColumn.DataPropertyName = "DlGirlT"
        Me.DlGirlTDataGridViewTextBoxColumn.HeaderText = "Дл. Креп.Тр"
        Me.DlGirlTDataGridViewTextBoxColumn.Name = "DlGirlTDataGridViewTextBoxColumn"
        Me.DlGirlTDataGridViewTextBoxColumn.Width = 94
        '
        'MassGirlTDataGridViewTextBoxColumn
        '
        Me.MassGirlTDataGridViewTextBoxColumn.DataPropertyName = "MassGirlT"
        Me.MassGirlTDataGridViewTextBoxColumn.HeaderText = "Масс Кр. Тр."
        Me.MassGirlTDataGridViewTextBoxColumn.Name = "MassGirlTDataGridViewTextBoxColumn"
        Me.MassGirlTDataGridViewTextBoxColumn.Width = 97
        '
        'WlDefParamBindingSource
        '
        Me.WlDefParamBindingSource.DataMember = "ParamUchN"
        Me.WlDefParamBindingSource.DataSource = Me.DsRasst1
        '
        'ToolStripUprKorrUch
        '
        Me.ToolStripUprKorrUch.BackColor = System.Drawing.Color.Gainsboro
        Me.ToolStripUprKorrUch.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NameUch, Me.NameFileUch, Me.ToolStripSeparator1, Me.ToolStripSeparator2, Me.ToolStripLabelGr, Me.ToolStripLabelPikBeg, Me.ToolStripSeparator3, Me.ToolStripLabelPikEnd, Me.ToolStripSeparator6, Me.ToolStripLabel2, Me.ToolStripLabelWibrPiket, Me.ToolStripSeparator4, Me.ToolStripButtonAllOk, Me.ToolStripSeparator5, Me.ToolStripButtonSohrDwg})
        Me.ToolStripUprKorrUch.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripUprKorrUch.Name = "ToolStripUprKorrUch"
        Me.ToolStripUprKorrUch.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStripUprKorrUch.Size = New System.Drawing.Size(1628, 25)
        Me.ToolStripUprKorrUch.TabIndex = 9
        Me.ToolStripUprKorrUch.Text = "Управление коррекцией участка"
        '
        'NameUch
        '
        Me.NameUch.BackColor = System.Drawing.SystemColors.Control
        Me.NameUch.Name = "NameUch"
        Me.NameUch.Size = New System.Drawing.Size(51, 22)
        Me.NameUch.Text = "Участок"
        '
        'NameFileUch
        '
        Me.NameFileUch.Name = "NameFileUch"
        Me.NameFileUch.Size = New System.Drawing.Size(89, 22)
        Me.NameFileUch.Text = "ToolStripLabel1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabelGr
        '
        Me.ToolStripLabelGr.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ToolStripLabelGr.Name = "ToolStripLabelGr"
        Me.ToolStripLabelGr.Size = New System.Drawing.Size(109, 22)
        Me.ToolStripLabelGr.Text = "Границы участка"
        '
        'ToolStripLabelPikBeg
        '
        Me.ToolStripLabelPikBeg.Name = "ToolStripLabelPikBeg"
        Me.ToolStripLabelPikBeg.Size = New System.Drawing.Size(105, 22)
        Me.ToolStripLabelPikBeg.Text = "Начальный пикет"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabelPikEnd
        '
        Me.ToolStripLabelPikEnd.Name = "ToolStripLabelPikEnd"
        Me.ToolStripLabelPikEnd.Size = New System.Drawing.Size(98, 22)
        Me.ToolStripLabelPikEnd.Text = "Конечный пикет"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(92, 22)
        Me.ToolStripLabel2.Text = "Выбраный пикет"
        '
        'ToolStripLabelWibrPiket
        '
        Me.ToolStripLabelWibrPiket.Name = "ToolStripLabelWibrPiket"
        Me.ToolStripLabelWibrPiket.Size = New System.Drawing.Size(89, 22)
        Me.ToolStripLabelWibrPiket.Text = "ToolStripLabel1"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButtonAllOk
        '
        Me.ToolStripButtonAllOk.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ToolStripButtonAllOk.Image = CType(resources.GetObject("ToolStripButtonAllOk.Image"), System.Drawing.Image)
        Me.ToolStripButtonAllOk.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonAllOk.Name = "ToolStripButtonAllOk"
        Me.ToolStripButtonAllOk.Size = New System.Drawing.Size(99, 22)
        Me.ToolStripButtonAllOk.Text = "Принять все"
        Me.ToolStripButtonAllOk.ToolTipText = "Учесть корректировки профиля и расстановки"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButtonSohrDwg
        '
        Me.ToolStripButtonSohrDwg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButtonSohrDwg.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ToolStripButtonSohrDwg.Image = CType(resources.GetObject("ToolStripButtonSohrDwg.Image"), System.Drawing.Image)
        Me.ToolStripButtonSohrDwg.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonSohrDwg.Name = "ToolStripButtonSohrDwg"
        Me.ToolStripButtonSohrDwg.Size = New System.Drawing.Size(146, 22)
        Me.ToolStripButtonSohrDwg.Text = " Не сохранить в чертеже"
        Me.ToolStripButtonSohrDwg.ToolTipText = "Указывает учитываються ли изменения  в источниках данных"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Параметры участка"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(748, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Условия расстановки"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Расстановка"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.Profil)
        Me.TabControl1.Controls.Add(Me.Klimat)
        Me.TabControl1.Controls.Add(Me.Rasstanowka)
        Me.TabControl1.Controls.Add(Me.Element1)
        Me.TabControl1.Location = New System.Drawing.Point(0, 28)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1616, 806)
        Me.TabControl1.TabIndex = 15
        '
        'Profil
        '
        Me.Profil.Controls.Add(Me.Label1)
        Me.Profil.Controls.Add(Me.DataGridViewPikUgod)
        Me.Profil.Controls.Add(Me.DataGridViewProfil)
        Me.Profil.Location = New System.Drawing.Point(4, 22)
        Me.Profil.Name = "Profil"
        Me.Profil.Size = New System.Drawing.Size(1608, 780)
        Me.Profil.TabIndex = 4
        Me.Profil.Text = "Профиль"
        Me.Profil.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1387, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Пикетаж угодий"
        '
        'DataGridViewPikUgod
        '
        Me.DataGridViewPikUgod.AllowUserToAddRows = False
        Me.DataGridViewPikUgod.AllowUserToDeleteRows = False
        Me.DataGridViewPikUgod.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewPikUgod.AutoGenerateColumns = False
        Me.DataGridViewPikUgod.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.DataGridViewPikUgod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewPikUgod.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewComboBoxPiketaj, Me.TipDataGridViewComboBoxColumn})
        Me.DataGridViewPikUgod.DataSource = Me.PiketUgodBindingSource
        Me.DataGridViewPikUgod.Location = New System.Drawing.Point(1390, 24)
        Me.DataGridViewPikUgod.Name = "DataGridViewPikUgod"
        Me.DataGridViewPikUgod.ReadOnly = True
        Me.DataGridViewPikUgod.Size = New System.Drawing.Size(196, 752)
        Me.DataGridViewPikUgod.TabIndex = 6
        '
        'DataGridViewComboBoxPiketaj
        '
        Me.DataGridViewComboBoxPiketaj.DataPropertyName = "Piketaj"
        Me.DataGridViewComboBoxPiketaj.HeaderText = "Пикетаж(м.)"
        Me.DataGridViewComboBoxPiketaj.Name = "DataGridViewComboBoxPiketaj"
        Me.DataGridViewComboBoxPiketaj.ReadOnly = True
        Me.DataGridViewComboBoxPiketaj.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewComboBoxPiketaj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewComboBoxPiketaj.Width = 94
        '
        'TipDataGridViewComboBoxColumn
        '
        Me.TipDataGridViewComboBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TipDataGridViewComboBoxColumn.DataPropertyName = "Tip"
        Me.TipDataGridViewComboBoxColumn.HeaderText = "Тип угодия"
        Me.TipDataGridViewComboBoxColumn.Name = "TipDataGridViewComboBoxColumn"
        Me.TipDataGridViewComboBoxColumn.ReadOnly = True
        Me.TipDataGridViewComboBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TipDataGridViewComboBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'PiketUgodBindingSource
        '
        Me.PiketUgodBindingSource.DataMember = "PikUgodN"
        Me.PiketUgodBindingSource.DataSource = Me.DsProfilA
        Me.PiketUgodBindingSource.Sort = "Piketaj "
        '
        'DsProfilA
        '
        Me.DsProfilA.DataSetName = "dsProfil"
        Me.DsProfilA.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DataGridViewProfil
        '
        Me.DataGridViewProfil.AllowUserToAddRows = False
        Me.DataGridViewProfil.AllowUserToDeleteRows = False
        Me.DataGridViewProfil.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewProfil.AutoGenerateColumns = False
        Me.DataGridViewProfil.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.DataGridViewProfil.ColumnHeadersHeight = 20
        Me.DataGridViewProfil.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NameTchkDataGridViewTextBoxColumn, Me.Piketaj1, Me.Otmetka1, Me.OtmetkaPrDataGridViewTextBoxColumn, Me.OtmetkaLwDataGridViewTextBoxColumn, Me.UIdTchk1, Me.UIdUch1, Me.IdTipSoor1, Me.Param1DataGridViewTextBoxColumn1, Me.Param2DataGridViewTextBoxColumn1, Me.Param3DataGridViewTextBoxColumn1, Me.Param4DataGridViewTextBoxColumn1, Me.OpisDataGridViewTextBoxColumn1, Me.UgolPoworotDataGridViewTextBoxColumn2})
        Me.DataGridViewProfil.DataMember = "ProfilA"
        Me.DataGridViewProfil.DataSource = Me.DsProfilA
        Me.DataGridViewProfil.GridColor = System.Drawing.SystemColors.ControlText
        Me.DataGridViewProfil.Location = New System.Drawing.Point(17, 24)
        Me.DataGridViewProfil.Name = "DataGridViewProfil"
        Me.DataGridViewProfil.ReadOnly = True
        Me.DataGridViewProfil.Size = New System.Drawing.Size(1358, 748)
        Me.DataGridViewProfil.TabIndex = 0
        '
        'NameTchkDataGridViewTextBoxColumn
        '
        Me.NameTchkDataGridViewTextBoxColumn.DataPropertyName = "NameTchk"
        Me.NameTchkDataGridViewTextBoxColumn.HeaderText = "Имя"
        Me.NameTchkDataGridViewTextBoxColumn.Name = "NameTchkDataGridViewTextBoxColumn"
        Me.NameTchkDataGridViewTextBoxColumn.ReadOnly = True
        Me.NameTchkDataGridViewTextBoxColumn.Width = 54
        '
        'Piketaj1
        '
        Me.Piketaj1.DataPropertyName = "Piketaj"
        Me.Piketaj1.HeaderText = "Пикетаж"
        Me.Piketaj1.Name = "Piketaj1"
        Me.Piketaj1.ReadOnly = True
        Me.Piketaj1.Width = 77
        '
        'Otmetka1
        '
        Me.Otmetka1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Otmetka1.DataPropertyName = "Otmetka"
        Me.Otmetka1.HeaderText = "Отметка"
        Me.Otmetka1.Name = "Otmetka1"
        Me.Otmetka1.ReadOnly = True
        Me.Otmetka1.Width = 65
        '
        'OtmetkaPrDataGridViewTextBoxColumn
        '
        Me.OtmetkaPrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.OtmetkaPrDataGridViewTextBoxColumn.DataPropertyName = "OtmetkaPr"
        Me.OtmetkaPrDataGridViewTextBoxColumn.HeaderText = "ОтметкаПр"
        Me.OtmetkaPrDataGridViewTextBoxColumn.Name = "OtmetkaPrDataGridViewTextBoxColumn"
        Me.OtmetkaPrDataGridViewTextBoxColumn.ReadOnly = True
        Me.OtmetkaPrDataGridViewTextBoxColumn.Width = 72
        '
        'OtmetkaLwDataGridViewTextBoxColumn
        '
        Me.OtmetkaLwDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.OtmetkaLwDataGridViewTextBoxColumn.DataPropertyName = "OtmetkaLw"
        Me.OtmetkaLwDataGridViewTextBoxColumn.HeaderText = "ОтметкаЛв"
        Me.OtmetkaLwDataGridViewTextBoxColumn.Name = "OtmetkaLwDataGridViewTextBoxColumn"
        Me.OtmetkaLwDataGridViewTextBoxColumn.ReadOnly = True
        Me.OtmetkaLwDataGridViewTextBoxColumn.Width = 72
        '
        'UIdTchk1
        '
        Me.UIdTchk1.DataPropertyName = "UIdTchk"
        Me.UIdTchk1.HeaderText = "UIdTchk"
        Me.UIdTchk1.Name = "UIdTchk1"
        Me.UIdTchk1.ReadOnly = True
        Me.UIdTchk1.Visible = False
        Me.UIdTchk1.Width = 74
        '
        'UIdUch1
        '
        Me.UIdUch1.DataPropertyName = "UIdUch"
        Me.UIdUch1.HeaderText = "UIdUch"
        Me.UIdUch1.Name = "UIdUch1"
        Me.UIdUch1.ReadOnly = True
        Me.UIdUch1.Visible = False
        Me.UIdUch1.Width = 69
        '
        'IdTipSoor1
        '
        Me.IdTipSoor1.DataPropertyName = "IdTipSoor"
        Me.IdTipSoor1.HeaderText = "Тип пересечения"
        Me.IdTipSoor1.Name = "IdTipSoor1"
        Me.IdTipSoor1.ReadOnly = True
        Me.IdTipSoor1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IdTipSoor1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.IdTipSoor1.Width = 119
        '
        'Param1DataGridViewTextBoxColumn1
        '
        Me.Param1DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Param1DataGridViewTextBoxColumn1.DataPropertyName = "Param1"
        Me.Param1DataGridViewTextBoxColumn1.HeaderText = "Отм пер1"
        Me.Param1DataGridViewTextBoxColumn1.Name = "Param1DataGridViewTextBoxColumn1"
        Me.Param1DataGridViewTextBoxColumn1.ReadOnly = True
        Me.Param1DataGridViewTextBoxColumn1.Width = 62
        '
        'Param2DataGridViewTextBoxColumn1
        '
        Me.Param2DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Param2DataGridViewTextBoxColumn1.DataPropertyName = "Param2"
        Me.Param2DataGridViewTextBoxColumn1.HeaderText = "Отм пер2"
        Me.Param2DataGridViewTextBoxColumn1.Name = "Param2DataGridViewTextBoxColumn1"
        Me.Param2DataGridViewTextBoxColumn1.ReadOnly = True
        Me.Param2DataGridViewTextBoxColumn1.Width = 62
        '
        'Param3DataGridViewTextBoxColumn1
        '
        Me.Param3DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Param3DataGridViewTextBoxColumn1.DataPropertyName = "Param3"
        Me.Param3DataGridViewTextBoxColumn1.HeaderText = "Отм пер3"
        Me.Param3DataGridViewTextBoxColumn1.Name = "Param3DataGridViewTextBoxColumn1"
        Me.Param3DataGridViewTextBoxColumn1.ReadOnly = True
        Me.Param3DataGridViewTextBoxColumn1.Width = 62
        '
        'Param4DataGridViewTextBoxColumn1
        '
        Me.Param4DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Param4DataGridViewTextBoxColumn1.DataPropertyName = "Param4"
        Me.Param4DataGridViewTextBoxColumn1.HeaderText = "Отм пер4"
        Me.Param4DataGridViewTextBoxColumn1.Name = "Param4DataGridViewTextBoxColumn1"
        Me.Param4DataGridViewTextBoxColumn1.ReadOnly = True
        Me.Param4DataGridViewTextBoxColumn1.Width = 62
        '
        'OpisDataGridViewTextBoxColumn1
        '
        Me.OpisDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.OpisDataGridViewTextBoxColumn1.DataPropertyName = "Opis"
        Me.OpisDataGridViewTextBoxColumn1.HeaderText = "Описание пересечения"
        Me.OpisDataGridViewTextBoxColumn1.Name = "OpisDataGridViewTextBoxColumn1"
        Me.OpisDataGridViewTextBoxColumn1.ReadOnly = True
        '
        'UgolPoworotDataGridViewTextBoxColumn2
        '
        Me.UgolPoworotDataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.UgolPoworotDataGridViewTextBoxColumn2.DataPropertyName = "UgolPoworot"
        Me.UgolPoworotDataGridViewTextBoxColumn2.HeaderText = "Угол поворота"
        Me.UgolPoworotDataGridViewTextBoxColumn2.Name = "UgolPoworotDataGridViewTextBoxColumn2"
        Me.UgolPoworotDataGridViewTextBoxColumn2.ReadOnly = True
        Me.UgolPoworotDataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.UgolPoworotDataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.UgolPoworotDataGridViewTextBoxColumn2.Width = 90
        '
        'Klimat
        '
        Me.Klimat.Controls.Add(Me.KlimatGridView)
        Me.Klimat.Location = New System.Drawing.Point(4, 22)
        Me.Klimat.Name = "Klimat"
        Me.Klimat.Padding = New System.Windows.Forms.Padding(3)
        Me.Klimat.Size = New System.Drawing.Size(1608, 780)
        Me.Klimat.TabIndex = 2
        Me.Klimat.Text = "Климат"
        Me.Klimat.UseVisualStyleBackColor = True
        '
        'KlimatGridView
        '
        Me.KlimatGridView.AllowUserToAddRows = False
        Me.KlimatGridView.AllowUserToDeleteRows = False
        Me.KlimatGridView.AutoGenerateColumns = False
        Me.KlimatGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.KlimatGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.KlimatGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.KlimatGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PiketajDataGridViewTextBoxColumn1, Me.StGolEkwDataGridViewTextBoxColumn, Me.StGolUslDataGridViewTextBoxColumn, Me.TexspDataGridViewTextBoxColumn, Me.TgolDataGridViewTextBoxColumn, Me.TminDataGridViewTextBoxColumn, Me.TmaxDataGridViewTextBoxColumn, Me.NaporVetraDataGridViewTextBoxColumn, Me.NapPriGolDataGridViewTextBoxColumn, Me.TipMestaDataGridViewTextBoxColumn, Me.PolzDataGridViewTextBoxColumn, Me.DataWDataGridViewTextBoxColumn})
        Me.KlimatGridView.DataSource = Me.ClsZonKlimatBindingSource
        Me.KlimatGridView.Location = New System.Drawing.Point(6, 6)
        Me.KlimatGridView.Name = "KlimatGridView"
        Me.KlimatGridView.ReadOnly = True
        Me.KlimatGridView.Size = New System.Drawing.Size(1077, 701)
        Me.KlimatGridView.TabIndex = 3
        '
        'PiketajDataGridViewTextBoxColumn1
        '
        Me.PiketajDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.PiketajDataGridViewTextBoxColumn1.DataPropertyName = "Piketaj"
        Me.PiketajDataGridViewTextBoxColumn1.HeaderText = "Пикетаж"
        Me.PiketajDataGridViewTextBoxColumn1.Name = "PiketajDataGridViewTextBoxColumn1"
        Me.PiketajDataGridViewTextBoxColumn1.ReadOnly = True
        '
        'StGolEkwDataGridViewTextBoxColumn
        '
        Me.StGolEkwDataGridViewTextBoxColumn.DataPropertyName = "StGolEkw"
        Me.StGolEkwDataGridViewTextBoxColumn.HeaderText = "Ст. гол. экв"
        Me.StGolEkwDataGridViewTextBoxColumn.Name = "StGolEkwDataGridViewTextBoxColumn"
        Me.StGolEkwDataGridViewTextBoxColumn.ReadOnly = True
        Me.StGolEkwDataGridViewTextBoxColumn.Width = 84
        '
        'StGolUslDataGridViewTextBoxColumn
        '
        Me.StGolUslDataGridViewTextBoxColumn.DataPropertyName = "StGolUsl"
        Me.StGolUslDataGridViewTextBoxColumn.HeaderText = "Ст. гол. усл."
        Me.StGolUslDataGridViewTextBoxColumn.Name = "StGolUslDataGridViewTextBoxColumn"
        Me.StGolUslDataGridViewTextBoxColumn.ReadOnly = True
        Me.StGolUslDataGridViewTextBoxColumn.Width = 86
        '
        'TexspDataGridViewTextBoxColumn
        '
        Me.TexspDataGridViewTextBoxColumn.DataPropertyName = "Texsp"
        Me.TexspDataGridViewTextBoxColumn.HeaderText = "Tср.эксп."
        Me.TexspDataGridViewTextBoxColumn.Name = "TexspDataGridViewTextBoxColumn"
        Me.TexspDataGridViewTextBoxColumn.ReadOnly = True
        Me.TexspDataGridViewTextBoxColumn.Width = 81
        '
        'TgolDataGridViewTextBoxColumn
        '
        Me.TgolDataGridViewTextBoxColumn.DataPropertyName = "Tgol"
        Me.TgolDataGridViewTextBoxColumn.HeaderText = "Tгол."
        Me.TgolDataGridViewTextBoxColumn.Name = "TgolDataGridViewTextBoxColumn"
        Me.TgolDataGridViewTextBoxColumn.ReadOnly = True
        Me.TgolDataGridViewTextBoxColumn.Width = 59
        '
        'TminDataGridViewTextBoxColumn
        '
        Me.TminDataGridViewTextBoxColumn.DataPropertyName = "Tmin"
        Me.TminDataGridViewTextBoxColumn.HeaderText = "Tмин."
        Me.TminDataGridViewTextBoxColumn.Name = "TminDataGridViewTextBoxColumn"
        Me.TminDataGridViewTextBoxColumn.ReadOnly = True
        Me.TminDataGridViewTextBoxColumn.Width = 62
        '
        'TmaxDataGridViewTextBoxColumn
        '
        Me.TmaxDataGridViewTextBoxColumn.DataPropertyName = "Tmax"
        Me.TmaxDataGridViewTextBoxColumn.HeaderText = "Tмакс"
        Me.TmaxDataGridViewTextBoxColumn.Name = "TmaxDataGridViewTextBoxColumn"
        Me.TmaxDataGridViewTextBoxColumn.ReadOnly = True
        Me.TmaxDataGridViewTextBoxColumn.Width = 65
        '
        'NaporVetraDataGridViewTextBoxColumn
        '
        Me.NaporVetraDataGridViewTextBoxColumn.DataPropertyName = "NaporVetra"
        Me.NaporVetraDataGridViewTextBoxColumn.HeaderText = "Напор ветра"
        Me.NaporVetraDataGridViewTextBoxColumn.Name = "NaporVetraDataGridViewTextBoxColumn"
        Me.NaporVetraDataGridViewTextBoxColumn.ReadOnly = True
        Me.NaporVetraDataGridViewTextBoxColumn.Width = 88
        '
        'NapPriGolDataGridViewTextBoxColumn
        '
        Me.NapPriGolDataGridViewTextBoxColumn.DataPropertyName = "NapPriGol"
        Me.NapPriGolDataGridViewTextBoxColumn.HeaderText = "Напор ветра при гол."
        Me.NapPriGolDataGridViewTextBoxColumn.Name = "NapPriGolDataGridViewTextBoxColumn"
        Me.NapPriGolDataGridViewTextBoxColumn.ReadOnly = True
        Me.NapPriGolDataGridViewTextBoxColumn.Width = 110
        '
        'TipMestaDataGridViewTextBoxColumn
        '
        Me.TipMestaDataGridViewTextBoxColumn.DataPropertyName = "TipMesta"
        Me.TipMestaDataGridViewTextBoxColumn.HeaderText = "Тип места"
        Me.TipMestaDataGridViewTextBoxColumn.Name = "TipMestaDataGridViewTextBoxColumn"
        Me.TipMestaDataGridViewTextBoxColumn.ReadOnly = True
        Me.TipMestaDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TipMestaDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.TipMestaDataGridViewTextBoxColumn.Width = 78
        '
        'PolzDataGridViewTextBoxColumn
        '
        Me.PolzDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.PolzDataGridViewTextBoxColumn.DataPropertyName = "Polz"
        Me.PolzDataGridViewTextBoxColumn.HeaderText = "Polz"
        Me.PolzDataGridViewTextBoxColumn.Name = "PolzDataGridViewTextBoxColumn"
        Me.PolzDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DataWDataGridViewTextBoxColumn
        '
        Me.DataWDataGridViewTextBoxColumn.DataPropertyName = "DataW"
        Me.DataWDataGridViewTextBoxColumn.HeaderText = "DataW"
        Me.DataWDataGridViewTextBoxColumn.Name = "DataWDataGridViewTextBoxColumn"
        Me.DataWDataGridViewTextBoxColumn.ReadOnly = True
        Me.DataWDataGridViewTextBoxColumn.Width = 66
        '
        'ClsZonKlimatBindingSource
        '
        Me.ClsZonKlimatBindingSource.DataMember = "TablKlimN"
        Me.ClsZonKlimatBindingSource.DataSource = Me.DsProfilA
        '
        'Rasstanowka
        '
        Me.Rasstanowka.Controls.Add(Me.TextBoxSuffiks)
        Me.Rasstanowka.Controls.Add(Me.ButtonSuffix)
        Me.Rasstanowka.Controls.Add(Me.CheckBoxNapr)
        Me.Rasstanowka.Controls.Add(Me.TextBoxNachNum)
        Me.Rasstanowka.Controls.Add(Me.ButtonPerenum)
        Me.Rasstanowka.Controls.Add(Me.Label3)
        Me.Rasstanowka.Controls.Add(Me.Label5)
        Me.Rasstanowka.Controls.Add(Me.DataGridView2)
        Me.Rasstanowka.Controls.Add(Me.RastOpDataGridView)
        Me.Rasstanowka.Controls.Add(Me.Label4)
        Me.Rasstanowka.Controls.Add(Me.MechUslDataGridView)
        Me.Rasstanowka.Location = New System.Drawing.Point(4, 22)
        Me.Rasstanowka.Name = "Rasstanowka"
        Me.Rasstanowka.Padding = New System.Windows.Forms.Padding(3)
        Me.Rasstanowka.Size = New System.Drawing.Size(1608, 780)
        Me.Rasstanowka.TabIndex = 1
        Me.Rasstanowka.Text = "Расстановка"
        Me.Rasstanowka.UseVisualStyleBackColor = True
        '
        'TextBoxSuffiks
        '
        Me.TextBoxSuffiks.Location = New System.Drawing.Point(671, 67)
        Me.TextBoxSuffiks.Name = "TextBoxSuffiks"
        Me.TextBoxSuffiks.Size = New System.Drawing.Size(41, 20)
        Me.TextBoxSuffiks.TabIndex = 19
        '
        'ButtonSuffix
        '
        Me.ButtonSuffix.Location = New System.Drawing.Point(540, 66)
        Me.ButtonSuffix.Name = "ButtonSuffix"
        Me.ButtonSuffix.Size = New System.Drawing.Size(116, 23)
        Me.ButtonSuffix.TabIndex = 18
        Me.ButtonSuffix.Text = "добавить суффикс"
        Me.ButtonSuffix.UseVisualStyleBackColor = True
        '
        'CheckBoxNapr
        '
        Me.CheckBoxNapr.AutoSize = True
        Me.CheckBoxNapr.Location = New System.Drawing.Point(329, 70)
        Me.CheckBoxNapr.Name = "CheckBoxNapr"
        Me.CheckBoxNapr.Size = New System.Drawing.Size(92, 17)
        Me.CheckBoxNapr.TabIndex = 17
        Me.CheckBoxNapr.Text = "по убыванию"
        Me.CheckBoxNapr.UseVisualStyleBackColor = True
        '
        'TextBoxNachNum
        '
        Me.TextBoxNachNum.Location = New System.Drawing.Point(282, 68)
        Me.TextBoxNachNum.Name = "TextBoxNachNum"
        Me.TextBoxNachNum.Size = New System.Drawing.Size(41, 20)
        Me.TextBoxNachNum.TabIndex = 16
        '
        'ButtonPerenum
        '
        Me.ButtonPerenum.Location = New System.Drawing.Point(117, 68)
        Me.ButtonPerenum.Name = "ButtonPerenum"
        Me.ButtonPerenum.Size = New System.Drawing.Size(159, 23)
        Me.ButtonPerenum.TabIndex = 15
        Me.ButtonPerenum.Text = "Перенумеровать начиная с"
        Me.ButtonPerenum.UseVisualStyleBackColor = True
        '
        'Element1
        '
        Me.Element1.Controls.Add(Me.GirlajndDataGridView)
        Me.Element1.Controls.Add(Me.ProvodaDataGridView)
        Me.Element1.Controls.Add(Me.OporDataGridView)
        Me.Element1.Location = New System.Drawing.Point(4, 22)
        Me.Element1.Name = "Element1"
        Me.Element1.Padding = New System.Windows.Forms.Padding(3)
        Me.Element1.Size = New System.Drawing.Size(1608, 780)
        Me.Element1.TabIndex = 3
        Me.Element1.Text = "Провода&Опоры"
        Me.Element1.UseVisualStyleBackColor = True
        '
        'GirlajndDataGridView
        '
        Me.GirlajndDataGridView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GirlajndDataGridView.AutoGenerateColumns = False
        Me.GirlajndDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GirlajndDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NameGDataGridViewTextBoxColumn, Me.TipDataGridViewTextBoxColumn, Me.Zepnost, Me.DlGirlDataGridViewTextBoxColumn1, Me.MassGirlDataGridViewTextBoxColumn1, Me.Ssech})
        Me.GirlajndDataGridView.DataSource = Me.GirlajndBindingSource
        Me.GirlajndDataGridView.Location = New System.Drawing.Point(19, 600)
        Me.GirlajndDataGridView.Name = "GirlajndDataGridView"
        Me.GirlajndDataGridView.Size = New System.Drawing.Size(753, 184)
        Me.GirlajndDataGridView.TabIndex = 2
        '
        'NameGDataGridViewTextBoxColumn
        '
        Me.NameGDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.NameGDataGridViewTextBoxColumn.DataPropertyName = "NameG"
        Me.NameGDataGridViewTextBoxColumn.HeaderText = "Наименование гирлянды"
        Me.NameGDataGridViewTextBoxColumn.Name = "NameGDataGridViewTextBoxColumn"
        '
        'TipDataGridViewTextBoxColumn
        '
        Me.TipDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.TipDataGridViewTextBoxColumn.DataPropertyName = "Tip"
        Me.TipDataGridViewTextBoxColumn.HeaderText = "Тип"
        Me.TipDataGridViewTextBoxColumn.Name = "TipDataGridViewTextBoxColumn"
        Me.TipDataGridViewTextBoxColumn.Width = 51
        '
        'Zepnost
        '
        Me.Zepnost.DataPropertyName = "Zepnost"
        Me.Zepnost.HeaderText = "Цепность"
        Me.Zepnost.Name = "Zepnost"
        '
        'DlGirlDataGridViewTextBoxColumn1
        '
        Me.DlGirlDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DlGirlDataGridViewTextBoxColumn1.DataPropertyName = "DlGirl"
        Me.DlGirlDataGridViewTextBoxColumn1.HeaderText = "Длина"
        Me.DlGirlDataGridViewTextBoxColumn1.Name = "DlGirlDataGridViewTextBoxColumn1"
        Me.DlGirlDataGridViewTextBoxColumn1.Width = 65
        '
        'MassGirlDataGridViewTextBoxColumn1
        '
        Me.MassGirlDataGridViewTextBoxColumn1.DataPropertyName = "MassGirl"
        Me.MassGirlDataGridViewTextBoxColumn1.HeaderText = "Масса"
        Me.MassGirlDataGridViewTextBoxColumn1.Name = "MassGirlDataGridViewTextBoxColumn1"
        '
        'Ssech
        '
        Me.Ssech.DataPropertyName = "Ssech"
        Me.Ssech.HeaderText = "Сеч.(м2)"
        Me.Ssech.Name = "Ssech"
        '
        'GirlajndBindingSource
        '
        Me.GirlajndBindingSource.DataMember = "Girjlanduch"
        Me.GirlajndBindingSource.DataSource = Me.ElemRasstUch1
        '
        'ElemRasstUch1
        '
        Me.ElemRasstUch1.DataSetName = "ElemRasstUch"
        Me.ElemRasstUch1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ProvodaDataGridView
        '
        Me.ProvodaDataGridView.AutoGenerateColumns = False
        Me.ProvodaDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.ProvodaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ProvodaDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.UserMarkDataGridViewTextBoxColumn, Me.Sprwd, Me.DiamPrwd, Me.Ppogon, Me.SigMax, Me.Alfa, Me.Jung, Me.SigGol, Me.SigSrG, Me.Tekpl, Me.ModF, Me.ModD, Me.TipP})
        Me.ProvodaDataGridView.DataSource = Me.ProvodaBindingSource
        Me.ProvodaDataGridView.Location = New System.Drawing.Point(8, 376)
        Me.ProvodaDataGridView.Name = "ProvodaDataGridView"
        Me.ProvodaDataGridView.Size = New System.Drawing.Size(1380, 196)
        Me.ProvodaDataGridView.TabIndex = 1
        '
        'UserMarkDataGridViewTextBoxColumn
        '
        Me.UserMarkDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.UserMarkDataGridViewTextBoxColumn.DataPropertyName = "UserMark"
        Me.UserMarkDataGridViewTextBoxColumn.HeaderText = "Марка провода"
        Me.UserMarkDataGridViewTextBoxColumn.Name = "UserMarkDataGridViewTextBoxColumn"
        '
        'Sprwd
        '
        Me.Sprwd.DataPropertyName = "Sprwd"
        Me.Sprwd.HeaderText = "Sprwd"
        Me.Sprwd.Name = "Sprwd"
        Me.Sprwd.Width = 62
        '
        'DiamPrwd
        '
        Me.DiamPrwd.DataPropertyName = "DiamPrwd"
        Me.DiamPrwd.HeaderText = "DiamPrwd"
        Me.DiamPrwd.Name = "DiamPrwd"
        Me.DiamPrwd.Width = 80
        '
        'Ppogon
        '
        Me.Ppogon.DataPropertyName = "Ppogon"
        Me.Ppogon.HeaderText = "Ppogon"
        Me.Ppogon.Name = "Ppogon"
        Me.Ppogon.Width = 69
        '
        'SigMax
        '
        Me.SigMax.DataPropertyName = "SigMax"
        Me.SigMax.HeaderText = "SigMax"
        Me.SigMax.Name = "SigMax"
        Me.SigMax.Width = 67
        '
        'Alfa
        '
        Me.Alfa.DataPropertyName = "Alfa"
        Me.Alfa.HeaderText = "Alfa"
        Me.Alfa.Name = "Alfa"
        Me.Alfa.Width = 50
        '
        'Jung
        '
        Me.Jung.DataPropertyName = "Jung"
        Me.Jung.HeaderText = "Jung"
        Me.Jung.Name = "Jung"
        Me.Jung.Width = 55
        '
        'SigGol
        '
        Me.SigGol.DataPropertyName = "SigGol"
        Me.SigGol.HeaderText = "SigGol"
        Me.SigGol.Name = "SigGol"
        Me.SigGol.Width = 63
        '
        'SigSrG
        '
        Me.SigSrG.DataPropertyName = "SigSrG"
        Me.SigSrG.HeaderText = "SigSrG"
        Me.SigSrG.Name = "SigSrG"
        Me.SigSrG.Width = 65
        '
        'Tekpl
        '
        Me.Tekpl.DataPropertyName = "Tekpl"
        Me.Tekpl.HeaderText = "Tekpl"
        Me.Tekpl.Name = "Tekpl"
        Me.Tekpl.Width = 59
        '
        'ModF
        '
        Me.ModF.DataPropertyName = "ModF"
        Me.ModF.HeaderText = "ModF"
        Me.ModF.Name = "ModF"
        Me.ModF.Width = 59
        '
        'ModD
        '
        Me.ModD.DataPropertyName = "ModD"
        Me.ModD.HeaderText = "ModD"
        Me.ModD.Name = "ModD"
        Me.ModD.Width = 61
        '
        'TipP
        '
        Me.TipP.DataPropertyName = "TipP"
        Me.TipP.HeaderText = "TipP"
        Me.TipP.Name = "TipP"
        Me.TipP.Width = 54
        '
        'ProvodaBindingSource
        '
        Me.ProvodaBindingSource.DataMember = "prowodaUch"
        Me.ProvodaBindingSource.DataSource = Me.ElemRasstUch1
        '
        'OporDataGridView
        '
        Me.OporDataGridView.AutoGenerateColumns = False
        Me.OporDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.OporDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.OporDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.UserTipOpDataGridViewTextBoxColumn, Me.TipiDataGridViewOporUchColumn, Me.WisopDataGridViewTextBoxColumn, Me.WinosDataGridViewTextBoxColumn, Me.Wisop1DataGridViewTextBoxColumn, Me.Winos1DataGridViewTextBoxColumn, Me.Wisop2DataGridViewTextBoxColumn, Me.Winos2DataGridViewTextBoxColumn, Me.WisopTDataGridViewTextBoxColumn, Me.WinosTDataGridViewTextBoxColumn, Me.ZepnDataGridViewTextBoxColumn})
        Me.OporDataGridView.DataSource = Me.OporBindingSource
        Me.OporDataGridView.Location = New System.Drawing.Point(8, 23)
        Me.OporDataGridView.Name = "OporDataGridView"
        Me.OporDataGridView.Size = New System.Drawing.Size(1367, 321)
        Me.OporDataGridView.TabIndex = 0
        '
        'UserTipOpDataGridViewTextBoxColumn
        '
        Me.UserTipOpDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.UserTipOpDataGridViewTextBoxColumn.DataPropertyName = "UserTipOp"
        Me.UserTipOpDataGridViewTextBoxColumn.HeaderText = "Шифр опоры"
        Me.UserTipOpDataGridViewTextBoxColumn.Name = "UserTipOpDataGridViewTextBoxColumn"
        '
        'TipiDataGridViewOporUchColumn
        '
        Me.TipiDataGridViewOporUchColumn.DataPropertyName = "Tip_i"
        Me.TipiDataGridViewOporUchColumn.HeaderText = "Тип опоры"
        Me.TipiDataGridViewOporUchColumn.Name = "TipiDataGridViewOporUchColumn"
        Me.TipiDataGridViewOporUchColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TipiDataGridViewOporUchColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.TipiDataGridViewOporUchColumn.Width = 86
        '
        'WisopDataGridViewTextBoxColumn
        '
        Me.WisopDataGridViewTextBoxColumn.DataPropertyName = "Wis_op"
        Me.WisopDataGridViewTextBoxColumn.HeaderText = "Подвес1"
        Me.WisopDataGridViewTextBoxColumn.Name = "WisopDataGridViewTextBoxColumn"
        Me.WisopDataGridViewTextBoxColumn.Width = 76
        '
        'WinosDataGridViewTextBoxColumn
        '
        Me.WinosDataGridViewTextBoxColumn.DataPropertyName = "Winos"
        Me.WinosDataGridViewTextBoxColumn.HeaderText = "Вылет1"
        Me.WinosDataGridViewTextBoxColumn.Name = "WinosDataGridViewTextBoxColumn"
        Me.WinosDataGridViewTextBoxColumn.Width = 70
        '
        'Wisop1DataGridViewTextBoxColumn
        '
        Me.Wisop1DataGridViewTextBoxColumn.DataPropertyName = "Wis_op1"
        Me.Wisop1DataGridViewTextBoxColumn.HeaderText = "Подвес2"
        Me.Wisop1DataGridViewTextBoxColumn.Name = "Wisop1DataGridViewTextBoxColumn"
        Me.Wisop1DataGridViewTextBoxColumn.Width = 76
        '
        'Winos1DataGridViewTextBoxColumn
        '
        Me.Winos1DataGridViewTextBoxColumn.DataPropertyName = "Winos1"
        Me.Winos1DataGridViewTextBoxColumn.HeaderText = "Вылет2"
        Me.Winos1DataGridViewTextBoxColumn.Name = "Winos1DataGridViewTextBoxColumn"
        Me.Winos1DataGridViewTextBoxColumn.Width = 70
        '
        'Wisop2DataGridViewTextBoxColumn
        '
        Me.Wisop2DataGridViewTextBoxColumn.DataPropertyName = "Wis_op2"
        Me.Wisop2DataGridViewTextBoxColumn.HeaderText = "Подвес3"
        Me.Wisop2DataGridViewTextBoxColumn.Name = "Wisop2DataGridViewTextBoxColumn"
        Me.Wisop2DataGridViewTextBoxColumn.Width = 76
        '
        'Winos2DataGridViewTextBoxColumn
        '
        Me.Winos2DataGridViewTextBoxColumn.DataPropertyName = "Winos2"
        Me.Winos2DataGridViewTextBoxColumn.HeaderText = "Вылет3"
        Me.Winos2DataGridViewTextBoxColumn.Name = "Winos2DataGridViewTextBoxColumn"
        Me.Winos2DataGridViewTextBoxColumn.Width = 70
        '
        'WisopTDataGridViewTextBoxColumn
        '
        Me.WisopTDataGridViewTextBoxColumn.DataPropertyName = "Wis_opT"
        Me.WisopTDataGridViewTextBoxColumn.HeaderText = "ПодвесТ"
        Me.WisopTDataGridViewTextBoxColumn.Name = "WisopTDataGridViewTextBoxColumn"
        Me.WisopTDataGridViewTextBoxColumn.Width = 77
        '
        'WinosTDataGridViewTextBoxColumn
        '
        Me.WinosTDataGridViewTextBoxColumn.DataPropertyName = "WinosT"
        Me.WinosTDataGridViewTextBoxColumn.HeaderText = "ВылетT"
        Me.WinosTDataGridViewTextBoxColumn.Name = "WinosTDataGridViewTextBoxColumn"
        Me.WinosTDataGridViewTextBoxColumn.Width = 71
        '
        'ZepnDataGridViewTextBoxColumn
        '
        Me.ZepnDataGridViewTextBoxColumn.DataPropertyName = "Zepn"
        Me.ZepnDataGridViewTextBoxColumn.HeaderText = "Цепн"
        Me.ZepnDataGridViewTextBoxColumn.Name = "ZepnDataGridViewTextBoxColumn"
        Me.ZepnDataGridViewTextBoxColumn.Width = 58
        '
        'OporBindingSource
        '
        Me.OporBindingSource.DataMember = "oporIUch"
        Me.OporBindingSource.DataSource = Me.ElemRasstUch1
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "D:\WL_11-13\Help\Form\FrmKorrRasstWlUch.htm"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Piketaj"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Piketaj"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.ToolTipText = "Количество проводов в фазе"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Otmetka"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Otmetka"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "NamePiket"
        Me.DataGridViewTextBoxColumn3.HeaderText = "NamePiket"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "OtmetkaLw"
        Me.DataGridViewTextBoxColumn4.HeaderText = "OtmetkaLw"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "OtmetkaPr"
        Me.DataGridViewTextBoxColumn5.HeaderText = "OtmetkaPr"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "UgolPoworota"
        Me.DataGridViewTextBoxColumn6.HeaderText = "UgolPoworota"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "StGolEkw"
        Me.DataGridViewTextBoxColumn7.HeaderText = "StGolEkw"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "StGolUsl"
        Me.DataGridViewTextBoxColumn8.HeaderText = "StGolUsl"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "Texsp"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Texsp"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "Tgol"
        Me.DataGridViewTextBoxColumn10.HeaderText = "Tgol"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "Tmin"
        Me.DataGridViewTextBoxColumn11.HeaderText = "Tmin"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "Tmax"
        Me.DataGridViewTextBoxColumn12.HeaderText = "Tmax"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "Napor"
        Me.DataGridViewTextBoxColumn13.HeaderText = "Napor"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "NaporPrGol"
        Me.DataGridViewTextBoxColumn14.HeaderText = "NaporPrGol"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "TipMesta"
        Me.DataGridViewTextBoxColumn15.HeaderText = "TipMesta"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "FiVetPr"
        Me.DataGridViewTextBoxColumn16.HeaderText = "FiVetPr"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "Sled"
        Me.DataGridViewTextBoxColumn17.HeaderText = "Sled"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "Piketaj"
        Me.DataGridViewTextBoxColumn18.HeaderText = "Piketaj"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "Key"
        Me.DataGridViewTextBoxColumn19.HeaderText = "Key"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.ReadOnly = True
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "NameTipOpor"
        Me.DataGridViewTextBoxColumn20.HeaderText = "NameTipOpor"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.ReadOnly = True
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn21.DataPropertyName = "NameGirlT"
        Me.DataGridViewTextBoxColumn21.HeaderText = "NameGirlT"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.ReadOnly = True
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn22.DataPropertyName = "Tip"
        Me.DataGridViewTextBoxColumn22.HeaderText = "Tip"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.ReadOnly = True
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn23.DataPropertyName = "Piketaj"
        Me.DataGridViewTextBoxColumn23.HeaderText = "Piketaj"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        Me.DataGridViewTextBoxColumn23.ReadOnly = True
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn24.DataPropertyName = "NameGirlT"
        Me.DataGridViewTextBoxColumn24.HeaderText = "NameGirlT"
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        Me.DataGridViewTextBoxColumn24.ReadOnly = True
        '
        'DataGridViewTextBoxColumn25
        '
        Me.DataGridViewTextBoxColumn25.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn25.DataPropertyName = "NameGirlT"
        Me.DataGridViewTextBoxColumn25.HeaderText = "NameGirlT"
        Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
        Me.DataGridViewTextBoxColumn25.ReadOnly = True
        '
        'DataGridViewTextBoxColumn26
        '
        Me.DataGridViewTextBoxColumn26.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn26.DataPropertyName = "Name_mark"
        Me.DataGridViewTextBoxColumn26.HeaderText = "Name_mark"
        Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
        Me.DataGridViewTextBoxColumn26.ReadOnly = True
        '
        'DataGridViewTextBoxColumn27
        '
        Me.DataGridViewTextBoxColumn27.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn27.DataPropertyName = "Name_markT"
        Me.DataGridViewTextBoxColumn27.HeaderText = "Name_markT"
        Me.DataGridViewTextBoxColumn27.Name = "DataGridViewTextBoxColumn27"
        Me.DataGridViewTextBoxColumn27.ReadOnly = True
        '
        'DataGridViewTextBoxColumn28
        '
        Me.DataGridViewTextBoxColumn28.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn28.DataPropertyName = "Tip_op"
        Me.DataGridViewTextBoxColumn28.HeaderText = "Tip_op"
        Me.DataGridViewTextBoxColumn28.Name = "DataGridViewTextBoxColumn28"
        Me.DataGridViewTextBoxColumn28.ReadOnly = True
        '
        'DataGridViewTextBoxColumn29
        '
        Me.DataGridViewTextBoxColumn29.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn29.DataPropertyName = "Gabarit"
        Me.DataGridViewTextBoxColumn29.HeaderText = "Gabarit"
        Me.DataGridViewTextBoxColumn29.Name = "DataGridViewTextBoxColumn29"
        Me.DataGridViewTextBoxColumn29.ReadOnly = True
        '
        'DataGridViewTextBoxColumn30
        '
        Me.DataGridViewTextBoxColumn30.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn30.DataPropertyName = "Sled"
        Me.DataGridViewTextBoxColumn30.HeaderText = "Sled"
        Me.DataGridViewTextBoxColumn30.Name = "DataGridViewTextBoxColumn30"
        Me.DataGridViewTextBoxColumn30.ReadOnly = True
        '
        'DataGridViewTextBoxColumn31
        '
        Me.DataGridViewTextBoxColumn31.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn31.DataPropertyName = "Piket"
        Me.DataGridViewTextBoxColumn31.HeaderText = "Piket"
        Me.DataGridViewTextBoxColumn31.Name = "DataGridViewTextBoxColumn31"
        Me.DataGridViewTextBoxColumn31.ReadOnly = True
        '
        'DataGridViewTextBoxColumn32
        '
        Me.DataGridViewTextBoxColumn32.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn32.DataPropertyName = "Piketaj"
        Me.DataGridViewTextBoxColumn32.HeaderText = "Piketaj"
        Me.DataGridViewTextBoxColumn32.Name = "DataGridViewTextBoxColumn32"
        Me.DataGridViewTextBoxColumn32.ReadOnly = True
        '
        'DataGridViewTextBoxColumn33
        '
        Me.DataGridViewTextBoxColumn33.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn33.DataPropertyName = "Key"
        Me.DataGridViewTextBoxColumn33.HeaderText = "Key"
        Me.DataGridViewTextBoxColumn33.Name = "DataGridViewTextBoxColumn33"
        Me.DataGridViewTextBoxColumn33.ReadOnly = True
        '
        'DataGridViewTextBoxColumn34
        '
        Me.DataGridViewTextBoxColumn34.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn34.DataPropertyName = "EndPiket"
        Me.DataGridViewTextBoxColumn34.HeaderText = "EndPiket"
        Me.DataGridViewTextBoxColumn34.Name = "DataGridViewTextBoxColumn34"
        Me.DataGridViewTextBoxColumn34.ReadOnly = True
        '
        'DataGridViewTextBoxColumn35
        '
        Me.DataGridViewTextBoxColumn35.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn35.DataPropertyName = "MarkaT"
        Me.DataGridViewTextBoxColumn35.HeaderText = "MarkaT"
        Me.DataGridViewTextBoxColumn35.Name = "DataGridViewTextBoxColumn35"
        Me.DataGridViewTextBoxColumn35.ReadOnly = True
        '
        'DataGridViewTextBoxColumn36
        '
        Me.DataGridViewTextBoxColumn36.DataPropertyName = "Girl"
        Me.DataGridViewTextBoxColumn36.HeaderText = "Girl"
        Me.DataGridViewTextBoxColumn36.Name = "DataGridViewTextBoxColumn36"
        Me.DataGridViewTextBoxColumn36.ReadOnly = True
        '
        'DataGridViewTextBoxColumn37
        '
        Me.DataGridViewTextBoxColumn37.DataPropertyName = "GirlT"
        Me.DataGridViewTextBoxColumn37.HeaderText = "GirlT"
        Me.DataGridViewTextBoxColumn37.Name = "DataGridViewTextBoxColumn37"
        Me.DataGridViewTextBoxColumn37.ReadOnly = True
        '
        'DataGridViewTextBoxColumn38
        '
        Me.DataGridViewTextBoxColumn38.DataPropertyName = "DlGirl"
        Me.DataGridViewTextBoxColumn38.HeaderText = "DlGirl"
        Me.DataGridViewTextBoxColumn38.Name = "DataGridViewTextBoxColumn38"
        Me.DataGridViewTextBoxColumn38.ReadOnly = True
        '
        'DataGridViewTextBoxColumn39
        '
        Me.DataGridViewTextBoxColumn39.DataPropertyName = "massGirl"
        Me.DataGridViewTextBoxColumn39.HeaderText = "massGirl"
        Me.DataGridViewTextBoxColumn39.Name = "DataGridViewTextBoxColumn39"
        Me.DataGridViewTextBoxColumn39.ReadOnly = True
        '
        'DataGridViewTextBoxColumn40
        '
        Me.DataGridViewTextBoxColumn40.DataPropertyName = "UserTipOp"
        Me.DataGridViewTextBoxColumn40.HeaderText = "UserTipOp"
        Me.DataGridViewTextBoxColumn40.Name = "DataGridViewTextBoxColumn40"
        Me.DataGridViewTextBoxColumn40.ReadOnly = True
        Me.DataGridViewTextBoxColumn40.Width = 83
        '
        'DataGridViewTextBoxColumn41
        '
        Me.DataGridViewTextBoxColumn41.DataPropertyName = "Tip_i"
        Me.DataGridViewTextBoxColumn41.HeaderText = "Tip_i"
        Me.DataGridViewTextBoxColumn41.Name = "DataGridViewTextBoxColumn41"
        Me.DataGridViewTextBoxColumn41.ReadOnly = True
        Me.DataGridViewTextBoxColumn41.Width = 55
        '
        'DataGridViewTextBoxColumn42
        '
        Me.DataGridViewTextBoxColumn42.DataPropertyName = "Wis_op0"
        Me.DataGridViewTextBoxColumn42.HeaderText = "Wis_op0"
        Me.DataGridViewTextBoxColumn42.Name = "DataGridViewTextBoxColumn42"
        Me.DataGridViewTextBoxColumn42.ReadOnly = True
        Me.DataGridViewTextBoxColumn42.Width = 74
        '
        'DataGridViewTextBoxColumn43
        '
        Me.DataGridViewTextBoxColumn43.DataPropertyName = "Wis_op1"
        Me.DataGridViewTextBoxColumn43.HeaderText = "Wis_op1"
        Me.DataGridViewTextBoxColumn43.Name = "DataGridViewTextBoxColumn43"
        Me.DataGridViewTextBoxColumn43.ReadOnly = True
        Me.DataGridViewTextBoxColumn43.Width = 74
        '
        'DataGridViewTextBoxColumn44
        '
        Me.DataGridViewTextBoxColumn44.DataPropertyName = "Wis_op2"
        Me.DataGridViewTextBoxColumn44.HeaderText = "Wis_op2"
        Me.DataGridViewTextBoxColumn44.Name = "DataGridViewTextBoxColumn44"
        Me.DataGridViewTextBoxColumn44.ReadOnly = True
        Me.DataGridViewTextBoxColumn44.Width = 74
        '
        'DataGridViewTextBoxColumn45
        '
        Me.DataGridViewTextBoxColumn45.DataPropertyName = "Wis_opT"
        Me.DataGridViewTextBoxColumn45.HeaderText = "Wis_opT"
        Me.DataGridViewTextBoxColumn45.Name = "DataGridViewTextBoxColumn45"
        Me.DataGridViewTextBoxColumn45.ReadOnly = True
        Me.DataGridViewTextBoxColumn45.Width = 75
        '
        'DataGridViewTextBoxColumn46
        '
        Me.DataGridViewTextBoxColumn46.DataPropertyName = "Name_mark"
        Me.DataGridViewTextBoxColumn46.HeaderText = "Name_mark"
        Me.DataGridViewTextBoxColumn46.Name = "DataGridViewTextBoxColumn46"
        Me.DataGridViewTextBoxColumn46.ReadOnly = True
        Me.DataGridViewTextBoxColumn46.Width = 89
        '
        'DataGridViewTextBoxColumn47
        '
        Me.DataGridViewTextBoxColumn47.DataPropertyName = "SigSrG"
        Me.DataGridViewTextBoxColumn47.HeaderText = "SigSrG"
        Me.DataGridViewTextBoxColumn47.Name = "DataGridViewTextBoxColumn47"
        Me.DataGridViewTextBoxColumn47.ReadOnly = True
        Me.DataGridViewTextBoxColumn47.Width = 65
        '
        'DataGridViewTextBoxColumn48
        '
        Me.DataGridViewTextBoxColumn48.DataPropertyName = "SigGol"
        Me.DataGridViewTextBoxColumn48.HeaderText = "SigGol"
        Me.DataGridViewTextBoxColumn48.Name = "DataGridViewTextBoxColumn48"
        Me.DataGridViewTextBoxColumn48.ReadOnly = True
        Me.DataGridViewTextBoxColumn48.Width = 63
        '
        'DataGridViewTextBoxColumn49
        '
        Me.DataGridViewTextBoxColumn49.DataPropertyName = "Jung"
        Me.DataGridViewTextBoxColumn49.HeaderText = "Jung"
        Me.DataGridViewTextBoxColumn49.Name = "DataGridViewTextBoxColumn49"
        Me.DataGridViewTextBoxColumn49.ReadOnly = True
        Me.DataGridViewTextBoxColumn49.Width = 55
        '
        'DataGridViewTextBoxColumn50
        '
        Me.DataGridViewTextBoxColumn50.DataPropertyName = "Alfa"
        Me.DataGridViewTextBoxColumn50.HeaderText = "Alfa"
        Me.DataGridViewTextBoxColumn50.Name = "DataGridViewTextBoxColumn50"
        Me.DataGridViewTextBoxColumn50.ReadOnly = True
        Me.DataGridViewTextBoxColumn50.Width = 50
        '
        'DataGridViewTextBoxColumn51
        '
        Me.DataGridViewTextBoxColumn51.DataPropertyName = "Ppogon"
        Me.DataGridViewTextBoxColumn51.HeaderText = "Ppogon"
        Me.DataGridViewTextBoxColumn51.Name = "DataGridViewTextBoxColumn51"
        Me.DataGridViewTextBoxColumn51.ReadOnly = True
        Me.DataGridViewTextBoxColumn51.Width = 69
        '
        'DataGridViewTextBoxColumn52
        '
        Me.DataGridViewTextBoxColumn52.DataPropertyName = "Sprwd"
        Me.DataGridViewTextBoxColumn52.HeaderText = "Sprwd"
        Me.DataGridViewTextBoxColumn52.Name = "DataGridViewTextBoxColumn52"
        Me.DataGridViewTextBoxColumn52.ReadOnly = True
        Me.DataGridViewTextBoxColumn52.Width = 62
        '
        'DataGridViewTextBoxColumn53
        '
        Me.DataGridViewTextBoxColumn53.DataPropertyName = "DiamPrwd"
        Me.DataGridViewTextBoxColumn53.HeaderText = "DiamPrwd"
        Me.DataGridViewTextBoxColumn53.Name = "DataGridViewTextBoxColumn53"
        Me.DataGridViewTextBoxColumn53.ReadOnly = True
        Me.DataGridViewTextBoxColumn53.Width = 80
        '
        'DataGridViewTextBoxColumn54
        '
        Me.DataGridViewTextBoxColumn54.DataPropertyName = "WesPogon"
        Me.DataGridViewTextBoxColumn54.HeaderText = "WesPogon"
        Me.DataGridViewTextBoxColumn54.Name = "DataGridViewTextBoxColumn54"
        Me.DataGridViewTextBoxColumn54.ReadOnly = True
        Me.DataGridViewTextBoxColumn54.Width = 85
        '
        'DataGridViewTextBoxColumn55
        '
        Me.DataGridViewTextBoxColumn55.DataPropertyName = "Tekpl"
        Me.DataGridViewTextBoxColumn55.HeaderText = "Tekpl"
        Me.DataGridViewTextBoxColumn55.Name = "DataGridViewTextBoxColumn55"
        Me.DataGridViewTextBoxColumn55.ReadOnly = True
        Me.DataGridViewTextBoxColumn55.Width = 59
        '
        'DataGridViewTextBoxColumn56
        '
        Me.DataGridViewTextBoxColumn56.DataPropertyName = "WesPogon"
        Me.DataGridViewTextBoxColumn56.HeaderText = "WesPogon"
        Me.DataGridViewTextBoxColumn56.Name = "DataGridViewTextBoxColumn56"
        Me.DataGridViewTextBoxColumn56.ReadOnly = True
        Me.DataGridViewTextBoxColumn56.Width = 85
        '
        'DataGridViewTextBoxColumn57
        '
        Me.DataGridViewTextBoxColumn57.DataPropertyName = "WesPogon"
        Me.DataGridViewTextBoxColumn57.HeaderText = "WesPogon"
        Me.DataGridViewTextBoxColumn57.Name = "DataGridViewTextBoxColumn57"
        Me.DataGridViewTextBoxColumn57.ReadOnly = True
        Me.DataGridViewTextBoxColumn57.Width = 85
        '
        'PiketajMechusl
        '
        Me.PiketajMechusl.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.PiketajMechusl.DataPropertyName = "Piketaj"
        Me.PiketajMechusl.HeaderText = "Пикетаж"
        Me.PiketajMechusl.Name = "PiketajMechusl"
        Me.PiketajMechusl.Width = 70
        '
        'TipopDataGridViewTextBoxColumn
        '
        Me.TipopDataGridViewTextBoxColumn.DataPropertyName = "Tip_op"
        Me.TipopDataGridViewTextBoxColumn.HeaderText = "Шифр пром. оп."
        Me.TipopDataGridViewTextBoxColumn.Name = "TipopDataGridViewTextBoxColumn"
        Me.TipopDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TipopDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.TipopDataGridViewTextBoxColumn.ToolTipText = "промежуточная опора характерная для данного учаська."
        Me.TipopDataGridViewTextBoxColumn.Width = 88
        '
        'NamemarkDataGridViewTextBoxColumn
        '
        Me.NamemarkDataGridViewTextBoxColumn.DataPropertyName = "Name_mark"
        Me.NamemarkDataGridViewTextBoxColumn.HeaderText = "Марка провода"
        Me.NamemarkDataGridViewTextBoxColumn.Name = "NamemarkDataGridViewTextBoxColumn"
        Me.NamemarkDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.NamemarkDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.NamemarkDataGridViewTextBoxColumn.Width = 101
        '
        'ProwodFaz
        '
        Me.ProwodFaz.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ProwodFaz.DataPropertyName = "ProwodFaz"
        Me.ProwodFaz.HeaderText = "В фазе"
        Me.ProwodFaz.Name = "ProwodFaz"
        Me.ProwodFaz.ToolTipText = "Количество проводов в фазе"
        Me.ProwodFaz.Width = 50
        '
        'Sig7TgolDataGridViewTextBoxColumn
        '
        Me.Sig7TgolDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Sig7TgolDataGridViewTextBoxColumn.DataPropertyName = "Sig7_Tgol"
        Me.Sig7TgolDataGridViewTextBoxColumn.HeaderText = "σ(Макс. нагр)"
        Me.Sig7TgolDataGridViewTextBoxColumn.Name = "Sig7TgolDataGridViewTextBoxColumn"
        Me.Sig7TgolDataGridViewTextBoxColumn.ToolTipText = "Тяжение провода при максимальной нагрузке(ньтоны на ммилиметр в 2)"
        Me.Sig7TgolDataGridViewTextBoxColumn.Width = 60
        '
        'Sig1TminDataGridViewTextBoxColumn
        '
        Me.Sig1TminDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Sig1TminDataGridViewTextBoxColumn.DataPropertyName = "Sig1_Tmin"
        Me.Sig1TminDataGridViewTextBoxColumn.HeaderText = "σ(Mин. темп)"
        Me.Sig1TminDataGridViewTextBoxColumn.Name = "Sig1TminDataGridViewTextBoxColumn"
        Me.Sig1TminDataGridViewTextBoxColumn.ToolTipText = "тяжение в проводе при минимальной температуре(ньтоны на ммилиметр в 2)"
        Me.Sig1TminDataGridViewTextBoxColumn.Visible = False
        Me.Sig1TminDataGridViewTextBoxColumn.Width = 60
        '
        'Sig1TexspDataGridViewTextBoxColumn
        '
        Me.Sig1TexspDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Sig1TexspDataGridViewTextBoxColumn.DataPropertyName = "Sig1_Texsp"
        Me.Sig1TexspDataGridViewTextBoxColumn.HeaderText = "σ(Ср. эксп)"
        Me.Sig1TexspDataGridViewTextBoxColumn.Name = "Sig1TexspDataGridViewTextBoxColumn"
        Me.Sig1TexspDataGridViewTextBoxColumn.ToolTipText = "Среднеэксплуатационное тяжение в проводе(ньтоны на ммилиметр в 2)"
        Me.Sig1TexspDataGridViewTextBoxColumn.Width = 60
        '
        'NamemarkTDataGridViewTextBoxColumn
        '
        Me.NamemarkTDataGridViewTextBoxColumn.ContextMenuStrip = Me.ContextMenuStripObm
        Me.NamemarkTDataGridViewTextBoxColumn.DataPropertyName = "Name_markT"
        Me.NamemarkTDataGridViewTextBoxColumn.HeaderText = "Марка троса"
        Me.NamemarkTDataGridViewTextBoxColumn.Name = "NamemarkTDataGridViewTextBoxColumn"
        Me.NamemarkTDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.NamemarkTDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.NamemarkTDataGridViewTextBoxColumn.Width = 89
        '
        'GabaritDataGridViewTextBoxColumn
        '
        Me.GabaritDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.GabaritDataGridViewTextBoxColumn.DataPropertyName = "Gabarit"
        Me.GabaritDataGridViewTextBoxColumn.HeaderText = "Габ."
        Me.GabaritDataGridViewTextBoxColumn.Name = "GabaritDataGridViewTextBoxColumn"
        Me.GabaritDataGridViewTextBoxColumn.Width = 45
        '
        'Sig7_TgolT
        '
        Me.Sig7_TgolT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Sig7_TgolT.DataPropertyName = "Sig7_TgolT"
        Me.Sig7_TgolT.HeaderText = "Sig7 TgolT"
        Me.Sig7_TgolT.Name = "Sig7_TgolT"
        Me.Sig7_TgolT.Width = 60
        '
        'Sig1_TexspT
        '
        Me.Sig1_TexspT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Sig1_TexspT.DataPropertyName = "Sig1_TexspT"
        Me.Sig1_TexspT.HeaderText = "Sig1 TexspT"
        Me.Sig1_TexspT.Name = "Sig1_TexspT"
        Me.Sig1_TexspT.Width = 60
        '
        'Name_markW
        '
        Me.Name_markW.DataPropertyName = "Name_markW"
        Me.Name_markW.HeaderText = "Марка ОКСН"
        Me.Name_markW.Name = "Name_markW"
        Me.Name_markW.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Name_markW.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Name_markW.Width = 90
        '
        'Sig7_TgolW
        '
        Me.Sig7_TgolW.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Sig7_TgolW.DataPropertyName = "Sig7_TgolW"
        Me.Sig7_TgolW.HeaderText = "Sig7 TgolW"
        Me.Sig7_TgolW.Name = "Sig7_TgolW"
        Me.Sig7_TgolW.Width = 60
        '
        'Sig1_TexspW
        '
        Me.Sig1_TexspW.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Sig1_TexspW.DataPropertyName = "Sig1_TexspW"
        Me.Sig1_TexspW.HeaderText = "Sig1 TexspW"
        Me.Sig1_TexspW.Name = "Sig1_TexspW"
        Me.Sig1_TexspW.Width = 60
        '
        'FrmKorrRasstWlUch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1628, 846)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ToolStripUprKorrUch)
        Me.Name = "FrmKorrRasstWlUch"
        Me.Text = "Корректировка  расстановки."
        CType(Me.RastOpDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RastOpNBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsRasst1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripObm.ResumeLayout(False)
        CType(Me.MechUslDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClszonMechuslBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WlDefParamBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStripUprKorrUch.ResumeLayout(False)
        Me.ToolStripUprKorrUch.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.Profil.ResumeLayout(False)
        Me.Profil.PerformLayout()
        CType(Me.DataGridViewPikUgod, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PiketUgodBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsProfilA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewProfil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Klimat.ResumeLayout(False)
        CType(Me.KlimatGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClsZonKlimatBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Rasstanowka.ResumeLayout(False)
        Me.Rasstanowka.PerformLayout()
        Me.Element1.ResumeLayout(False)
        CType(Me.GirlajndDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GirlajndBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ElemRasstUch1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProvodaDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProvodaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OporDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OporBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents RastOpNBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MechUslDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents ClszonMechuslBindingSource As System.Windows.Forms.BindingSource
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
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents WlDefParamBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridViewTextBoxColumn35 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn36 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn37 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NameUch As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Rasstanowka As System.Windows.Forms.TabPage
    Friend WithEvents Klimat As System.Windows.Forms.TabPage
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
    Friend WithEvents KlimatGridView As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabelGr As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabelPikEnd As System.Windows.Forms.ToolStripLabel
    Friend WithEvents PiketUgodBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Element1 As System.Windows.Forms.TabPage
    Friend WithEvents ProvodaDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents ProvodaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents OporDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents OporBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TipiDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GirlajndBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GirlajndDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents ContextMenuStripObm As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItemCop As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemIns As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UserMarkDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sprwd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiamPrwd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ppogon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SigMax As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Alfa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Jung As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SigGol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SigSrG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tekpl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ModF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ModD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserTipOpDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipiDataGridViewOporUchColumn As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents WisopDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WinosDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Wisop1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Winos1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Wisop2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Winos2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WisopTDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WinosTDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ZepnDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Profil As System.Windows.Forms.TabPage
    Friend WithEvents DataGridViewProfil As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabelWibrPiket As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TextBoxNachNum As System.Windows.Forms.TextBox
    Friend WithEvents ButtonPerenum As System.Windows.Forms.Button
    Friend WithEvents ToolStripMenuItemDel As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ToolStripUprKorrUch As System.Windows.Forms.ToolStrip
    Public WithEvents ToolStripLabelPikBeg As System.Windows.Forms.ToolStripLabel
    Public WithEvents ToolStripButtonAllOk As System.Windows.Forms.ToolStripButton
    Public WithEvents DsProfilA As OperBD.DsProfil
    Public WithEvents DsRasst1 As OperBD.dsRasst
    Public WithEvents ElemRasstUch1 As OperBD.ElemRasstUch
    Public WithEvents NameFileUch As System.Windows.Forms.ToolStripLabel
    Friend WithEvents GnwDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GnwGDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GregDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GregGolDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipopADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents TipopPDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DlGirlDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MassGirlDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NamemarkDataGridViewParamUch As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents NamemarkTDataGridViewParamUch As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DlGirlTDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MassGirlTDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Public WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewPikUgod As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewComboBoxPiketaj As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents TipDataGridViewComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
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
    Friend WithEvents CheckBoxNapr As System.Windows.Forms.CheckBox
    Friend WithEvents TextBoxSuffiks As System.Windows.Forms.TextBox
    Friend WithEvents ButtonSuffix As System.Windows.Forms.Button
    Protected WithEvents RastOpDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripButtonSohrDwg As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameGDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Zepnost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DlGirlDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MassGirlDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ssech As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PiketajDataGridViewRasstOp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipDataGridViewOpRasstColumn As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents NameTipOpor As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents nameGirl As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents NameGirlT As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents WisotaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PodwesW As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UgolPoworotDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PiketajDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
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
    Friend WithEvents PiketajMechusl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipopDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents NamemarkDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ProwodFaz As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sig7TgolDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sig1TminDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sig1TexspDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NamemarkTDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents GabaritDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sig7_TgolT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sig1_TexspT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Name_markW As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Sig7_TgolW As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sig1_TexspW As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
