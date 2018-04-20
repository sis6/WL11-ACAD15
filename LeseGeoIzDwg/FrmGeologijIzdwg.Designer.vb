<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmGeologijIzdwg
	Inherits System.Windows.Forms.Form

	'Форма переопределяет dispose для очистки списка компонентов.
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

	'Является обязательной для конструктора форм Windows Forms
	Private components As System.ComponentModel.IContainer

	'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
	'Для ее изменения используйте конструктор форм Windows Form.  
	'Не изменяйте ее в редакторе исходного кода.
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Me.DataGridViewSkwajn = New System.Windows.Forms.DataGridView()
		Me.NameSkwajDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.YMax = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.YMin = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ZentrSkwajnDwgDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.MaxGranizaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.MinGranizaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.SkwajIzDwgPoMTextBindingSource = New System.Windows.Forms.BindingSource(Me.components)
		Me.DataGridViewSloiIge = New System.Windows.Forms.DataGridView()
		Me.nameSkwajBeg = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.IndexIge = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.RastOtNachalaDwgBeg = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.OtmetkaBegPodwg = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.OtmetkaEndPoDwg = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.nameSkwajEnd = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.HatchIdentifikatorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
		Me.DataGridViewSkwajnEntity = New System.Windows.Forms.DataGridView()
		Me.XustDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.OtmetkaUgw = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.GlubinaUgw = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.TipSkwaj = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.YustDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.YminDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.KolwoHatchDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.XmaxDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.XminDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.YmaxDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ObrazSkwajPoEntityBindingSource = New System.Windows.Forms.BindingSource(Me.components)
		Me.TabCont = New System.Windows.Forms.TabControl()
		Me.TabPage1 = New System.Windows.Forms.TabPage()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.TabPage2 = New System.Windows.Forms.TabPage()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.DataGridViewParamIge = New System.Windows.Forms.DataGridView()
		Me.Wozrast = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ComboBoxSloewIGE = New System.Windows.Forms.ComboBox()
		CType(Me.DataGridViewSkwajn, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.SkwajIzDwgPoMTextBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.DataGridViewSloiIge, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.HatchIdentifikatorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.DataGridViewSkwajnEntity, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.ObrazSkwajPoEntityBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.TabCont.SuspendLayout()
		Me.TabPage1.SuspendLayout()
		Me.TabPage2.SuspendLayout()
		CType(Me.DataGridViewParamIge, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'DataGridViewSkwajn
		'
		Me.DataGridViewSkwajn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.DataGridViewSkwajn.AutoGenerateColumns = False
		Me.DataGridViewSkwajn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
		Me.DataGridViewSkwajn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.DataGridViewSkwajn.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NameSkwajDataGridViewTextBoxColumn, Me.YMax, Me.YMin, Me.ZentrSkwajnDwgDataGridViewTextBoxColumn, Me.MaxGranizaDataGridViewTextBoxColumn, Me.MinGranizaDataGridViewTextBoxColumn})
		Me.DataGridViewSkwajn.DataSource = Me.SkwajIzDwgPoMTextBindingSource
		Me.DataGridViewSkwajn.Location = New System.Drawing.Point(6, 24)
		Me.DataGridViewSkwajn.Name = "DataGridViewSkwajn"
		DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
		DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
		DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
		DataGridViewCellStyle1.Format = "N1"
		DataGridViewCellStyle1.NullValue = Nothing
		DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.DataGridViewSkwajn.RowHeadersDefaultCellStyle = DataGridViewCellStyle1
		Me.DataGridViewSkwajn.RowHeadersVisible = False
		DataGridViewCellStyle2.Format = "N2"
		DataGridViewCellStyle2.NullValue = Nothing
		Me.DataGridViewSkwajn.RowsDefaultCellStyle = DataGridViewCellStyle2
		Me.DataGridViewSkwajn.Size = New System.Drawing.Size(467, 541)
		Me.DataGridViewSkwajn.TabIndex = 0
		'
		'NameSkwajDataGridViewTextBoxColumn
		'
		Me.NameSkwajDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
		Me.NameSkwajDataGridViewTextBoxColumn.DataPropertyName = "NameSkwaj"
		Me.NameSkwajDataGridViewTextBoxColumn.FillWeight = 120.0!
		Me.NameSkwajDataGridViewTextBoxColumn.HeaderText = "Скважина"
		Me.NameSkwajDataGridViewTextBoxColumn.Name = "NameSkwajDataGridViewTextBoxColumn"
		Me.NameSkwajDataGridViewTextBoxColumn.ReadOnly = True
		'
		'YMax
		'
		Me.YMax.DataPropertyName = "YMax"
		Me.YMax.HeaderText = "YMax"
		Me.YMax.Name = "YMax"
		Me.YMax.ReadOnly = True
		Me.YMax.Width = 59
		'
		'YMin
		'
		Me.YMin.DataPropertyName = "YMin"
		Me.YMin.HeaderText = "YMin"
		Me.YMin.Name = "YMin"
		Me.YMin.ReadOnly = True
		Me.YMin.Width = 56
		'
		'ZentrSkwajnDwgDataGridViewTextBoxColumn
		'
		Me.ZentrSkwajnDwgDataGridViewTextBoxColumn.DataPropertyName = "ZentrSkwajnDwg"
		Me.ZentrSkwajnDwgDataGridViewTextBoxColumn.HeaderText = "Центр скваж."
		Me.ZentrSkwajnDwgDataGridViewTextBoxColumn.Name = "ZentrSkwajnDwgDataGridViewTextBoxColumn"
		Me.ZentrSkwajnDwgDataGridViewTextBoxColumn.ReadOnly = True
		Me.ZentrSkwajnDwgDataGridViewTextBoxColumn.Width = 101
		'
		'MaxGranizaDataGridViewTextBoxColumn
		'
		Me.MaxGranizaDataGridViewTextBoxColumn.DataPropertyName = "MaxGraniza"
		Me.MaxGranizaDataGridViewTextBoxColumn.HeaderText = "Макс"
		Me.MaxGranizaDataGridViewTextBoxColumn.Name = "MaxGranizaDataGridViewTextBoxColumn"
		Me.MaxGranizaDataGridViewTextBoxColumn.ReadOnly = True
		Me.MaxGranizaDataGridViewTextBoxColumn.Width = 59
		'
		'MinGranizaDataGridViewTextBoxColumn
		'
		Me.MinGranizaDataGridViewTextBoxColumn.DataPropertyName = "MinGraniza"
		Me.MinGranizaDataGridViewTextBoxColumn.HeaderText = "Мин "
		Me.MinGranizaDataGridViewTextBoxColumn.Name = "MinGranizaDataGridViewTextBoxColumn"
		Me.MinGranizaDataGridViewTextBoxColumn.ReadOnly = True
		Me.MinGranizaDataGridViewTextBoxColumn.Width = 56
		'
		'SkwajIzDwgPoMTextBindingSource
		'
		Me.SkwajIzDwgPoMTextBindingSource.DataSource = GetType(LeseGeoIzDwg.ObrazSkwajn)
		'
		'DataGridViewSloiIge
		'
		Me.DataGridViewSloiIge.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.DataGridViewSloiIge.AutoGenerateColumns = False
		Me.DataGridViewSloiIge.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
		Me.DataGridViewSloiIge.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.DataGridViewSloiIge.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.nameSkwajBeg, Me.IndexIge, Me.RastOtNachalaDwgBeg, Me.OtmetkaBegPodwg, Me.OtmetkaEndPoDwg, Me.nameSkwajEnd})
		Me.DataGridViewSloiIge.DataSource = Me.HatchIdentifikatorBindingSource
		Me.DataGridViewSloiIge.Location = New System.Drawing.Point(512, 24)
		Me.DataGridViewSloiIge.Name = "DataGridViewSloiIge"
		Me.DataGridViewSloiIge.RowHeadersVisible = False
		DataGridViewCellStyle3.Format = "N2"
		DataGridViewCellStyle3.NullValue = Nothing
		Me.DataGridViewSloiIge.RowsDefaultCellStyle = DataGridViewCellStyle3
		Me.DataGridViewSloiIge.Size = New System.Drawing.Size(624, 541)
		Me.DataGridViewSloiIge.TabIndex = 1
		'
		'nameSkwajBeg
		'
		Me.nameSkwajBeg.DataPropertyName = "nameSkwajBeg"
		Me.nameSkwajBeg.HeaderText = "Скв. нач"
		Me.nameSkwajBeg.Name = "nameSkwajBeg"
		Me.nameSkwajBeg.ReadOnly = True
		Me.nameSkwajBeg.Width = 74
		'
		'IndexIge
		'
		Me.IndexIge.DataPropertyName = "IndexIge"
		Me.IndexIge.HeaderText = "ИГЭ"
		Me.IndexIge.Name = "IndexIge"
		Me.IndexIge.ReadOnly = True
		Me.IndexIge.Width = 53
		'
		'RastOtNachalaDwgBeg
		'
		Me.RastOtNachalaDwgBeg.DataPropertyName = "RastOtNachalaDwgBeg"
		Me.RastOtNachalaDwgBeg.HeaderText = "Начало"
		Me.RastOtNachalaDwgBeg.Name = "RastOtNachalaDwgBeg"
		Me.RastOtNachalaDwgBeg.ReadOnly = True
		Me.RastOtNachalaDwgBeg.Width = 69
		'
		'OtmetkaBegPodwg
		'
		Me.OtmetkaBegPodwg.DataPropertyName = "OtmetkaBegPodwg"
		Me.OtmetkaBegPodwg.HeaderText = "Отм."
		Me.OtmetkaBegPodwg.Name = "OtmetkaBegPodwg"
		Me.OtmetkaBegPodwg.ReadOnly = True
		Me.OtmetkaBegPodwg.Width = 56
		'
		'OtmetkaEndPoDwg
		'
		Me.OtmetkaEndPoDwg.DataPropertyName = "OtmetkaEndPoDwg"
		Me.OtmetkaEndPoDwg.HeaderText = "ОтмК"
		Me.OtmetkaEndPoDwg.Name = "OtmetkaEndPoDwg"
		Me.OtmetkaEndPoDwg.ReadOnly = True
		Me.OtmetkaEndPoDwg.Width = 60
		'
		'nameSkwajEnd
		'
		Me.nameSkwajEnd.DataPropertyName = "nameSkwajEnd"
		Me.nameSkwajEnd.HeaderText = "Скв. кон"
		Me.nameSkwajEnd.Name = "nameSkwajEnd"
		Me.nameSkwajEnd.ReadOnly = True
		Me.nameSkwajEnd.Width = 75
		'
		'HatchIdentifikatorBindingSource
		'
		Me.HatchIdentifikatorBindingSource.DataSource = GetType(LeseGeoIzDwg.SlojIgeDwg)
		'
		'DataGridViewSkwajnEntity
		'
		Me.DataGridViewSkwajnEntity.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.DataGridViewSkwajnEntity.AutoGenerateColumns = False
		Me.DataGridViewSkwajnEntity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
		Me.DataGridViewSkwajnEntity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.DataGridViewSkwajnEntity.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.XustDataGridViewTextBoxColumn, Me.OtmetkaUgw, Me.GlubinaUgw, Me.TipSkwaj, Me.YustDataGridViewTextBoxColumn, Me.YminDataGridViewTextBoxColumn, Me.KolwoHatchDataGridViewTextBoxColumn, Me.XmaxDataGridViewTextBoxColumn, Me.XminDataGridViewTextBoxColumn, Me.YmaxDataGridViewTextBoxColumn})
		Me.DataGridViewSkwajnEntity.DataSource = Me.ObrazSkwajPoEntityBindingSource
		Me.DataGridViewSkwajnEntity.Location = New System.Drawing.Point(6, 26)
		Me.DataGridViewSkwajnEntity.Name = "DataGridViewSkwajnEntity"
		DataGridViewCellStyle6.Format = "N1"
		DataGridViewCellStyle6.NullValue = Nothing
		Me.DataGridViewSkwajnEntity.RowsDefaultCellStyle = DataGridViewCellStyle6
		Me.DataGridViewSkwajnEntity.Size = New System.Drawing.Size(696, 532)
		Me.DataGridViewSkwajnEntity.TabIndex = 2
		'
		'XustDataGridViewTextBoxColumn
		'
		Me.XustDataGridViewTextBoxColumn.DataPropertyName = "Xust"
		Me.XustDataGridViewTextBoxColumn.HeaderText = "Xскв."
		Me.XustDataGridViewTextBoxColumn.Name = "XustDataGridViewTextBoxColumn"
		Me.XustDataGridViewTextBoxColumn.ReadOnly = True
		Me.XustDataGridViewTextBoxColumn.Width = 60
		'
		'OtmetkaUgw
		'
		Me.OtmetkaUgw.DataPropertyName = "OtmetkaUgw"
		DataGridViewCellStyle4.Format = "N1"
		Me.OtmetkaUgw.DefaultCellStyle = DataGridViewCellStyle4
		Me.OtmetkaUgw.HeaderText = "OtmetkaUgw"
		Me.OtmetkaUgw.Name = "OtmetkaUgw"
		Me.OtmetkaUgw.ReadOnly = True
		Me.OtmetkaUgw.Width = 94
		'
		'GlubinaUgw
		'
		Me.GlubinaUgw.DataPropertyName = "GlubinaUgw"
		DataGridViewCellStyle5.Format = "N1"
		DataGridViewCellStyle5.NullValue = Nothing
		Me.GlubinaUgw.DefaultCellStyle = DataGridViewCellStyle5
		Me.GlubinaUgw.HeaderText = "ГлубUgw"
		Me.GlubinaUgw.Name = "GlubinaUgw"
		Me.GlubinaUgw.ReadOnly = True
		Me.GlubinaUgw.Width = 77
		'
		'TipSkwaj
		'
		Me.TipSkwaj.DataPropertyName = "TipSkwaj"
		Me.TipSkwaj.HeaderText = "Tip"
		Me.TipSkwaj.Name = "TipSkwaj"
		Me.TipSkwaj.ReadOnly = True
		Me.TipSkwaj.Width = 47
		'
		'YustDataGridViewTextBoxColumn
		'
		Me.YustDataGridViewTextBoxColumn.DataPropertyName = "Yust"
		Me.YustDataGridViewTextBoxColumn.HeaderText = "Yскв."
		Me.YustDataGridViewTextBoxColumn.Name = "YustDataGridViewTextBoxColumn"
		Me.YustDataGridViewTextBoxColumn.ReadOnly = True
		Me.YustDataGridViewTextBoxColumn.Width = 60
		'
		'YminDataGridViewTextBoxColumn
		'
		Me.YminDataGridViewTextBoxColumn.DataPropertyName = "Ymin"
		Me.YminDataGridViewTextBoxColumn.HeaderText = "Yдна"
		Me.YminDataGridViewTextBoxColumn.Name = "YminDataGridViewTextBoxColumn"
		Me.YminDataGridViewTextBoxColumn.ReadOnly = True
		Me.YminDataGridViewTextBoxColumn.Width = 57
		'
		'KolwoHatchDataGridViewTextBoxColumn
		'
		Me.KolwoHatchDataGridViewTextBoxColumn.DataPropertyName = "KolwoHatch"
		Me.KolwoHatchDataGridViewTextBoxColumn.HeaderText = " штрих."
		Me.KolwoHatchDataGridViewTextBoxColumn.Name = "KolwoHatchDataGridViewTextBoxColumn"
		Me.KolwoHatchDataGridViewTextBoxColumn.ReadOnly = True
		Me.KolwoHatchDataGridViewTextBoxColumn.Width = 68
		'
		'XmaxDataGridViewTextBoxColumn
		'
		Me.XmaxDataGridViewTextBoxColumn.DataPropertyName = "Xmax"
		Me.XmaxDataGridViewTextBoxColumn.HeaderText = "Xmax"
		Me.XmaxDataGridViewTextBoxColumn.Name = "XmaxDataGridViewTextBoxColumn"
		Me.XmaxDataGridViewTextBoxColumn.ReadOnly = True
		Me.XmaxDataGridViewTextBoxColumn.Width = 58
		'
		'XminDataGridViewTextBoxColumn
		'
		Me.XminDataGridViewTextBoxColumn.DataPropertyName = "Xmin"
		Me.XminDataGridViewTextBoxColumn.HeaderText = "Xmin"
		Me.XminDataGridViewTextBoxColumn.Name = "XminDataGridViewTextBoxColumn"
		Me.XminDataGridViewTextBoxColumn.ReadOnly = True
		Me.XminDataGridViewTextBoxColumn.Width = 55
		'
		'YmaxDataGridViewTextBoxColumn
		'
		Me.YmaxDataGridViewTextBoxColumn.DataPropertyName = "Ymax"
		Me.YmaxDataGridViewTextBoxColumn.HeaderText = "Ymax"
		Me.YmaxDataGridViewTextBoxColumn.Name = "YmaxDataGridViewTextBoxColumn"
		Me.YmaxDataGridViewTextBoxColumn.ReadOnly = True
		Me.YmaxDataGridViewTextBoxColumn.Width = 58
		'
		'ObrazSkwajPoEntityBindingSource
		'
		Me.ObrazSkwajPoEntityBindingSource.DataSource = GetType(LeseGeoIzDwg.PostroenijSkwajEntity)
		'
		'TabCont
		'
		Me.TabCont.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.TabCont.Controls.Add(Me.TabPage1)
		Me.TabCont.Controls.Add(Me.TabPage2)
		Me.TabCont.Location = New System.Drawing.Point(12, 12)
		Me.TabCont.Name = "TabCont"
		Me.TabCont.SelectedIndex = 0
		Me.TabCont.Size = New System.Drawing.Size(1170, 597)
		Me.TabCont.TabIndex = 3
		'
		'TabPage1
		'
		Me.TabPage1.Controls.Add(Me.Label2)
		Me.TabPage1.Controls.Add(Me.Label1)
		Me.TabPage1.Controls.Add(Me.DataGridViewSkwajn)
		Me.TabPage1.Controls.Add(Me.DataGridViewSloiIge)
		Me.TabPage1.Location = New System.Drawing.Point(4, 22)
		Me.TabPage1.Name = "TabPage1"
		Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage1.Size = New System.Drawing.Size(1162, 571)
		Me.TabPage1.TabIndex = 0
		Me.TabPage1.Text = "слои скважины"
		Me.TabPage1.UseVisualStyleBackColor = True
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(574, 8)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(136, 13)
		Me.Label2.TabIndex = 3
		Me.Label2.Text = "Слои в единицах чертежа"
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(6, 8)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(164, 13)
		Me.Label1.TabIndex = 2
		Me.Label1.Text = "Скважины в единицах чертежа"
		'
		'TabPage2
		'
		Me.TabPage2.Controls.Add(Me.Label4)
		Me.TabPage2.Controls.Add(Me.Label3)
		Me.TabPage2.Controls.Add(Me.DataGridViewParamIge)
		Me.TabPage2.Controls.Add(Me.ComboBoxSloewIGE)
		Me.TabPage2.Controls.Add(Me.DataGridViewSkwajnEntity)
		Me.TabPage2.Location = New System.Drawing.Point(4, 22)
		Me.TabPage2.Name = "TabPage2"
		Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage2.Size = New System.Drawing.Size(1162, 571)
		Me.TabPage2.TabIndex = 1
		Me.TabPage2.Text = "Из чертежа"
		Me.TabPage2.UseVisualStyleBackColor = True
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(646, 13)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(90, 13)
		Me.Label4.TabIndex = 6
		Me.Label4.Text = "Параметры ИГЕ"
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(34, 10)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(245, 13)
		Me.Label3.TabIndex = 5
		Me.Label3.Text = "Скважины по примитивам в единицах чертежа"
		'
		'DataGridViewParamIge
		'
		Me.DataGridViewParamIge.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
		Me.DataGridViewParamIge.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.DataGridViewParamIge.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Wozrast})
		Me.DataGridViewParamIge.Location = New System.Drawing.Point(723, 49)
		Me.DataGridViewParamIge.Name = "DataGridViewParamIge"
		Me.DataGridViewParamIge.Size = New System.Drawing.Size(433, 441)
		Me.DataGridViewParamIge.TabIndex = 4
		'
		'Wozrast
		'
		Me.Wozrast.DataPropertyName = "Wozrast"
		Me.Wozrast.HeaderText = "Wozrast"
		Me.Wozrast.Name = "Wozrast"
		Me.Wozrast.Width = 71
		'
		'ComboBoxSloewIGE
		'
		Me.ComboBoxSloewIGE.FormattingEnabled = True
		Me.ComboBoxSloewIGE.Location = New System.Drawing.Point(887, 10)
		Me.ComboBoxSloewIGE.Name = "ComboBoxSloewIGE"
		Me.ComboBoxSloewIGE.Size = New System.Drawing.Size(121, 21)
		Me.ComboBoxSloewIGE.TabIndex = 3
		'
		'FrmGeologijIzdwg
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(1186, 621)
		Me.Controls.Add(Me.TabCont)
		Me.Name = "FrmGeologijIzdwg"
		Me.Text = "Геология из чертежа"
		CType(Me.DataGridViewSkwajn, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.SkwajIzDwgPoMTextBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.DataGridViewSloiIge, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.HatchIdentifikatorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.DataGridViewSkwajnEntity, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.ObrazSkwajPoEntityBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
		Me.TabCont.ResumeLayout(False)
		Me.TabPage1.ResumeLayout(False)
		Me.TabPage1.PerformLayout()
		Me.TabPage2.ResumeLayout(False)
		Me.TabPage2.PerformLayout()
		CType(Me.DataGridViewParamIge, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents DataGridViewSkwajn As System.Windows.Forms.DataGridView
	Friend WithEvents DataGridViewSloiIge As System.Windows.Forms.DataGridView
	Friend WithEvents DataGridViewSkwajnEntity As System.Windows.Forms.DataGridView
	Friend WithEvents TabCont As System.Windows.Forms.TabControl
	Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
	Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
	Friend WithEvents SkwajIzDwgPoMTextBindingSource As System.Windows.Forms.BindingSource
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents HatchIdentifikatorBindingSource As System.Windows.Forms.BindingSource
	Friend WithEvents ComboBoxSloewIGE As System.Windows.Forms.ComboBox
	Friend WithEvents NameSkwajDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents IdentIGeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents RastOtNachalaDWGBegDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents NachalPoYDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewParamIge As System.Windows.Forms.DataGridView
	Friend WithEvents ObrazSkwajPoEntityBindingSource As System.Windows.Forms.BindingSource
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents NameSkwajDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents YMax As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents YMin As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ZentrSkwajnDwgDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents MaxGranizaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents MinGranizaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents IndexIgeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents Wozrast As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents PatternNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents PatternScaleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents PatternAngleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents KolwoPrimDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents nameSkwajBeg As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents IndexIge As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents RastOtNachalaDwgBeg As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents OtmetkaBegPodwg As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents RastOtNachalaDWGEndDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents OtmetkaEndPoDwg As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents nameSkwajEnd As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents XustDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents OtmetkaUgw As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents GlubinaUgw As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents TipSkwaj As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents YustDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents YminDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents KolwoHatchDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents XmaxDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents XminDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents YmaxDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
