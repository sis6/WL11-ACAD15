Imports GeologijDwg

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSloiIge
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridViewIgeNaTrasse = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rasstojnie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OtmetkaPrf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IndexIgeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WerhGranizaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Glubina = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NameSkwajBeg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NameSkwajEnd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SloiIGeRealBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridViewIgePoSkwaj = New System.Windows.Forms.DataGridView()
        Me.SloiIgeRealSkwajBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DwgRastOpGeoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Rastojnie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Piketaj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OtmetkaPrfDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OtmetkaNiza = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GlubinaSkwaj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IndexIgeDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridViewIgeNaTrasse, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SloiIGeRealBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewIgePoSkwaj, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SloiIgeRealSkwajBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DwgRastOpGeoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridViewIgeNaTrasse
        '
        Me.DataGridViewIgeNaTrasse.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewIgeNaTrasse.AutoGenerateColumns = False
        Me.DataGridViewIgeNaTrasse.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.DataGridViewIgeNaTrasse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewIgeNaTrasse.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Rasstojnie, Me.OtmetkaPrf, Me.IndexIgeDataGridViewTextBoxColumn, Me.WerhGranizaDataGridViewTextBoxColumn, Me.Glubina, Me.NameSkwajBeg, Me.NameSkwajEnd})
        Me.DataGridViewIgeNaTrasse.DataSource = Me.SloiIGeRealBindingSource
        Me.DataGridViewIgeNaTrasse.Location = New System.Drawing.Point(38, 21)
        Me.DataGridViewIgeNaTrasse.Name = "DataGridViewIgeNaTrasse"
        Me.DataGridViewIgeNaTrasse.RowHeadersVisible = False
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.DataGridViewIgeNaTrasse.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewIgeNaTrasse.Size = New System.Drawing.Size(650, 763)
        Me.DataGridViewIgeNaTrasse.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "NameObjekt"
        Me.Column1.HeaderText = "Опора"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 64
        '
        'Rasstojnie
        '
        Me.Rasstojnie.DataPropertyName = "Rastojnie"
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue
        Me.Rasstojnie.DefaultCellStyle = DataGridViewCellStyle1
        Me.Rasstojnie.HeaderText = "Расcт."
        Me.Rasstojnie.Name = "Rasstojnie"
        Me.Rasstojnie.ReadOnly = True
        Me.Rasstojnie.Width = 65
        '
        'OtmetkaPrf
        '
        Me.OtmetkaPrf.DataPropertyName = "OtmetkaPrf"
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue
        Me.OtmetkaPrf.DefaultCellStyle = DataGridViewCellStyle2
        Me.OtmetkaPrf.HeaderText = "Отметка"
        Me.OtmetkaPrf.Name = "OtmetkaPrf"
        Me.OtmetkaPrf.ReadOnly = True
        Me.OtmetkaPrf.Width = 76
        '
        'IndexIgeDataGridViewTextBoxColumn
        '
        Me.IndexIgeDataGridViewTextBoxColumn.DataPropertyName = "IndexIge"
        Me.IndexIgeDataGridViewTextBoxColumn.HeaderText = " ИГЭ"
        Me.IndexIgeDataGridViewTextBoxColumn.Name = "IndexIgeDataGridViewTextBoxColumn"
        Me.IndexIgeDataGridViewTextBoxColumn.ReadOnly = True
        Me.IndexIgeDataGridViewTextBoxColumn.Width = 56
        '
        'WerhGranizaDataGridViewTextBoxColumn
        '
        Me.WerhGranizaDataGridViewTextBoxColumn.DataPropertyName = "WerhGraniza"
        Me.WerhGranizaDataGridViewTextBoxColumn.HeaderText = "Отм. слоя"
        Me.WerhGranizaDataGridViewTextBoxColumn.Name = "WerhGranizaDataGridViewTextBoxColumn"
        Me.WerhGranizaDataGridViewTextBoxColumn.ReadOnly = True
        Me.WerhGranizaDataGridViewTextBoxColumn.Width = 83
        '
        'Glubina
        '
        Me.Glubina.DataPropertyName = "Glubina"
        Me.Glubina.HeaderText = "Глубина"
        Me.Glubina.Name = "Glubina"
        Me.Glubina.ReadOnly = True
        Me.Glubina.Width = 73
        '
        'NameSkwajBeg
        '
        Me.NameSkwajBeg.DataPropertyName = "NameSkwajBeg"
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Blue
        Me.NameSkwajBeg.DefaultCellStyle = DataGridViewCellStyle3
        Me.NameSkwajBeg.HeaderText = "Скв. до"
        Me.NameSkwajBeg.Name = "NameSkwajBeg"
        Me.NameSkwajBeg.ReadOnly = True
        Me.NameSkwajBeg.Width = 69
        '
        'NameSkwajEnd
        '
        Me.NameSkwajEnd.DataPropertyName = "NameSkwajEnd"
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Blue
        Me.NameSkwajEnd.DefaultCellStyle = DataGridViewCellStyle4
        Me.NameSkwajEnd.HeaderText = "Скв. после"
        Me.NameSkwajEnd.Name = "NameSkwajEnd"
        Me.NameSkwajEnd.ReadOnly = True
        Me.NameSkwajEnd.Width = 87
        '
        'SloiIGeRealBindingSource
        '
        Me.SloiIGeRealBindingSource.DataSource = GetType(GeologijDwg.GranizaSlojIgeRealDwg)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(203, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Слои под опорами(реальные единицы)"
        '
        'DataGridViewIgePoSkwaj
        '
        Me.DataGridViewIgePoSkwaj.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewIgePoSkwaj.AutoGenerateColumns = False
        Me.DataGridViewIgePoSkwaj.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.DataGridViewIgePoSkwaj.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewIgePoSkwaj.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Rastojnie, Me.Piketaj, Me.OtmetkaPrfDataGridViewTextBoxColumn, Me.OtmetkaNiza, Me.GlubinaSkwaj, Me.IndexIgeDataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn1})
        Me.DataGridViewIgePoSkwaj.DataSource = Me.SloiIgeRealSkwajBindingSource
        Me.DataGridViewIgePoSkwaj.Location = New System.Drawing.Point(702, 21)
        Me.DataGridViewIgePoSkwaj.Name = "DataGridViewIgePoSkwaj"
        DataGridViewCellStyle11.Format = "N1"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.DataGridViewIgePoSkwaj.RowsDefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewIgePoSkwaj.Size = New System.Drawing.Size(649, 763)
        Me.DataGridViewIgePoSkwaj.TabIndex = 2
        '
        'SloiIgeRealSkwajBindingSource
        '
        Me.SloiIgeRealSkwajBindingSource.DataSource = GetType(GeologijDwg.GranizaSlojIgeRealDwg)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(699, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(163, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Скважины(реальные единицы)"
        '
        'DwgRastOpGeoBindingSource
        '
        Me.DwgRastOpGeoBindingSource.DataSource = GetType(GeologijDwg.ObrazGeologiiRealDwg)
        '
        'Rastojnie
        '
        Me.Rastojnie.DataPropertyName = "Rastojnie"
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Blue
        Me.Rastojnie.DefaultCellStyle = DataGridViewCellStyle6
        Me.Rastojnie.HeaderText = "раст."
        Me.Rastojnie.Name = "Rastojnie"
        Me.Rastojnie.ReadOnly = True
        Me.Rastojnie.Width = 58
        '
        'Piketaj
        '
        Me.Piketaj.DataPropertyName = "Piketaj"
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Blue
        Me.Piketaj.DefaultCellStyle = DataGridViewCellStyle7
        Me.Piketaj.HeaderText = "Пикетаж"
        Me.Piketaj.Name = "Piketaj"
        Me.Piketaj.ReadOnly = True
        Me.Piketaj.Width = 77
        '
        'OtmetkaPrfDataGridViewTextBoxColumn
        '
        Me.OtmetkaPrfDataGridViewTextBoxColumn.DataPropertyName = "OtmetkaPrf"
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Blue
        Me.OtmetkaPrfDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle8
        Me.OtmetkaPrfDataGridViewTextBoxColumn.HeaderText = "Отметка"
        Me.OtmetkaPrfDataGridViewTextBoxColumn.Name = "OtmetkaPrfDataGridViewTextBoxColumn"
        Me.OtmetkaPrfDataGridViewTextBoxColumn.ReadOnly = True
        Me.OtmetkaPrfDataGridViewTextBoxColumn.Width = 76
        '
        'OtmetkaNiza
        '
        Me.OtmetkaNiza.DataPropertyName = "WerhGraniza"
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Blue
        Me.OtmetkaNiza.DefaultCellStyle = DataGridViewCellStyle9
        Me.OtmetkaNiza.HeaderText = "Отм. гран."
        Me.OtmetkaNiza.Name = "OtmetkaNiza"
        Me.OtmetkaNiza.ReadOnly = True
        Me.OtmetkaNiza.Width = 85
        '
        'GlubinaSkwaj
        '
        Me.GlubinaSkwaj.DataPropertyName = "Glubina"
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Blue
        Me.GlubinaSkwaj.DefaultCellStyle = DataGridViewCellStyle10
        Me.GlubinaSkwaj.HeaderText = "Глуб."
        Me.GlubinaSkwaj.Name = "GlubinaSkwaj"
        Me.GlubinaSkwaj.ReadOnly = True
        Me.GlubinaSkwaj.Width = 58
        '
        'IndexIgeDataGridViewTextBoxColumn1
        '
        Me.IndexIgeDataGridViewTextBoxColumn1.DataPropertyName = "IndexIge"
        Me.IndexIgeDataGridViewTextBoxColumn1.HeaderText = "ИГЭ"
        Me.IndexIgeDataGridViewTextBoxColumn1.Name = "IndexIgeDataGridViewTextBoxColumn1"
        Me.IndexIgeDataGridViewTextBoxColumn1.ReadOnly = True
        Me.IndexIgeDataGridViewTextBoxColumn1.Width = 53
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "NameObjekt"
        Me.DataGridViewTextBoxColumn1.FillWeight = 110.0!
        Me.DataGridViewTextBoxColumn1.HeaderText = "Смежн. Скваж"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 110
        '
        'FrmSloiIge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1363, 810)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DataGridViewIgePoSkwaj)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridViewIgeNaTrasse)
        Me.Name = "FrmSloiIge"
        Me.Text = "FrmSloiIge"
        CType(Me.DataGridViewIgeNaTrasse, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SloiIGeRealBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewIgePoSkwaj, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SloiIgeRealSkwajBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DwgRastOpGeoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridViewIgeNaTrasse As System.Windows.Forms.DataGridView
    Friend WithEvents DwgRastOpGeoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SloiIGeRealBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridViewIgePoSkwaj As System.Windows.Forms.DataGridView
    Friend WithEvents SloiIgeRealSkwajBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NameObjektDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NijGranizaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TolschinaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NameObjektDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NijGranizaDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TolschinaDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WerhGranizaDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rasstojnie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OtmetkaPrf As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IndexIgeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WerhGranizaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Glubina As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NameSkwajBeg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NameSkwajEnd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rastojnie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Piketaj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OtmetkaPrfDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OtmetkaNiza As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GlubinaSkwaj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IndexIgeDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
