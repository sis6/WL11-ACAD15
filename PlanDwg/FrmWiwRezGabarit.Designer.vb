<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWiwRezGabarit
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridViewZ0 = New System.Windows.Forms.DataGridView()
        Me.DFunBindingSourceZ0 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewZ1 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DFunBindingSourcez1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewz2 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DFunBindingSourceZ2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Piketaj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ArgDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FunDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PoVertikal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DopDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Info = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridViewZ0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DFunBindingSourceZ0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewZ1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DFunBindingSourcez1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewz2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DFunBindingSourceZ2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridViewZ0
        '
        Me.DataGridViewZ0.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewZ0.AutoGenerateColumns = False
        Me.DataGridViewZ0.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.DataGridViewZ0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewZ0.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NameDataGridViewTextBoxColumn, Me.Piketaj, Me.ArgDataGridViewTextBoxColumn, Me.FunDataGridViewTextBoxColumn, Me.PoVertikal, Me.DopDataGridViewTextBoxColumn, Me.Info})
        Me.DataGridViewZ0.DataSource = Me.DFunBindingSourceZ0
        Me.DataGridViewZ0.GridColor = System.Drawing.SystemColors.ControlText
        Me.DataGridViewZ0.Location = New System.Drawing.Point(12, 25)
        Me.DataGridViewZ0.Name = "DataGridViewZ0"
        Me.DataGridViewZ0.RowHeadersVisible = False
        Me.DataGridViewZ0.Size = New System.Drawing.Size(756, 571)
        Me.DataGridViewZ0.TabIndex = 0
        '
        'DFunBindingSourceZ0
        '
        Me.DFunBindingSourceZ0.DataSource = GetType(modRasstOp.DFun)
        '
        'DataGridViewZ1
        '
        Me.DataGridViewZ1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewZ1.AutoGenerateColumns = False
        Me.DataGridViewZ1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.DataGridViewZ1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewZ1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        Me.DataGridViewZ1.DataSource = Me.DFunBindingSourcez1
        Me.DataGridViewZ1.GridColor = System.Drawing.SystemColors.ControlText
        Me.DataGridViewZ1.Location = New System.Drawing.Point(797, 25)
        Me.DataGridViewZ1.Name = "DataGridViewZ1"
        Me.DataGridViewZ1.RowHeadersVisible = False
        Me.DataGridViewZ1.Size = New System.Drawing.Size(265, 571)
        Me.DataGridViewZ1.TabIndex = 2
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Fun"
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn2.HeaderText = "Сближение до земли"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 80
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "PoVertikal"
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn3.HeaderText = "Габарит в середине"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Dop"
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn4.HeaderText = "Стрела"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 68
        '
        'DFunBindingSourcez1
        '
        Me.DFunBindingSourcez1.DataSource = GetType(modRasstOp.DFun)
        '
        'DataGridViewz2
        '
        Me.DataGridViewz2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewz2.AutoGenerateColumns = False
        Me.DataGridViewz2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.DataGridViewz2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewz2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8})
        Me.DataGridViewz2.DataSource = Me.DFunBindingSourceZ2
        Me.DataGridViewz2.GridColor = System.Drawing.SystemColors.ControlText
        Me.DataGridViewz2.Location = New System.Drawing.Point(1081, 25)
        Me.DataGridViewz2.Name = "DataGridViewz2"
        Me.DataGridViewz2.RowHeadersVisible = False
        Me.DataGridViewz2.Size = New System.Drawing.Size(256, 571)
        Me.DataGridViewz2.TabIndex = 3
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Fun"
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewTextBoxColumn6.HeaderText = "Сбижение до земли"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 80
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "PoVertikal"
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewTextBoxColumn7.HeaderText = "Габарит в середине"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 80
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Dop"
        DataGridViewCellStyle11.Format = "N2"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewTextBoxColumn8.HeaderText = "Стрела"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 68
        '
        'DFunBindingSourceZ2
        '
        Me.DFunBindingSourceZ2.DataSource = GetType(modRasstOp.DFun)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "фаза 1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(781, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "фаза 2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1078, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "фаза 3"
        '
        'NameDataGridViewTextBoxColumn
        '
        Me.NameDataGridViewTextBoxColumn.DataPropertyName = "Name"
        Me.NameDataGridViewTextBoxColumn.HeaderText = "опоры"
        Me.NameDataGridViewTextBoxColumn.Name = "NameDataGridViewTextBoxColumn"
        Me.NameDataGridViewTextBoxColumn.Width = 64
        '
        'Piketaj
        '
        Me.Piketaj.DataPropertyName = "Piketaj"
        DataGridViewCellStyle1.Format = "N1"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Piketaj.DefaultCellStyle = DataGridViewCellStyle1
        Me.Piketaj.HeaderText = "Пикетаж оп."
        Me.Piketaj.Name = "Piketaj"
        Me.Piketaj.Width = 95
        '
        'ArgDataGridViewTextBoxColumn
        '
        Me.ArgDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ArgDataGridViewTextBoxColumn.DataPropertyName = "Arg"
        DataGridViewCellStyle2.Format = "N1"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.ArgDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.ArgDataGridViewTextBoxColumn.HeaderText = "От_опоры/Дл. пролета "
        Me.ArgDataGridViewTextBoxColumn.Name = "ArgDataGridViewTextBoxColumn"
        Me.ArgDataGridViewTextBoxColumn.ReadOnly = True
        Me.ArgDataGridViewTextBoxColumn.ToolTipText = "положение экстремальной точки приведеное к длине пролета"
        '
        'FunDataGridViewTextBoxColumn
        '
        Me.FunDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.FunDataGridViewTextBoxColumn.DataPropertyName = "Fun"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.FunDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.FunDataGridViewTextBoxColumn.HeaderText = "Сближение  До земли"
        Me.FunDataGridViewTextBoxColumn.Name = "FunDataGridViewTextBoxColumn"
        Me.FunDataGridViewTextBoxColumn.ReadOnly = True
        Me.FunDataGridViewTextBoxColumn.Width = 80
        '
        'PoVertikal
        '
        Me.PoVertikal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.PoVertikal.DataPropertyName = "PoVertikal"
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.PoVertikal.DefaultCellStyle = DataGridViewCellStyle4
        Me.PoVertikal.HeaderText = "Габарит в середине "
        Me.PoVertikal.Name = "PoVertikal"
        Me.PoVertikal.Width = 90
        '
        'DopDataGridViewTextBoxColumn
        '
        Me.DopDataGridViewTextBoxColumn.DataPropertyName = "Dop"
        DataGridViewCellStyle5.Format = "N1"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.DopDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.DopDataGridViewTextBoxColumn.HeaderText = "Стрела"
        Me.DopDataGridViewTextBoxColumn.Name = "DopDataGridViewTextBoxColumn"
        Me.DopDataGridViewTextBoxColumn.Width = 68
        '
        'Info
        '
        Me.Info.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Info.DataPropertyName = "Info"
        Me.Info.HeaderText = "Info"
        Me.Info.Name = "Info"
        '
        'FrmWiwRezGabarit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1373, 608)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridViewz2)
        Me.Controls.Add(Me.DataGridViewZ1)
        Me.Controls.Add(Me.DataGridViewZ0)
        Me.Name = "FrmWiwRezGabarit"
        Me.Text = "минимальные расстояния до поверхности"
        CType(Me.DataGridViewZ0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DFunBindingSourceZ0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewZ1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DFunBindingSourcez1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewz2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DFunBindingSourceZ2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridViewZ0 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewZ1 As System.Windows.Forms.DataGridView
    Public WithEvents DFunBindingSourcez1 As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridViewz2 As System.Windows.Forms.DataGridView
    Public WithEvents DFunBindingSourceZ2 As System.Windows.Forms.BindingSource
    Friend WithEvents DFunBindingSourceZ0 As System.Windows.Forms.BindingSource
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Piketaj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ArgDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FunDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PoVertikal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DopDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Info As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
