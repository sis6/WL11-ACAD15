<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWiwRezGabaritTros
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridViewZ0 = New System.Windows.Forms.DataGridView()
        Me.DFunBindingSourceZ0 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DFunBindingSourceZ2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DFunBindingSourcez1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.NameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Piketaj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ArgDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FunDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DopDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PoVertikal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Info = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Info2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridViewZ0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DFunBindingSourceZ0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DFunBindingSourceZ2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DFunBindingSourcez1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridViewZ0
        '
        Me.DataGridViewZ0.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewZ0.AutoGenerateColumns = False
        Me.DataGridViewZ0.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.DataGridViewZ0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewZ0.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NameDataGridViewTextBoxColumn, Me.Piketaj, Me.ArgDataGridViewTextBoxColumn, Me.FunDataGridViewTextBoxColumn, Me.DopDataGridViewTextBoxColumn, Me.PoVertikal, Me.Info, Me.Info2})
        Me.DataGridViewZ0.DataSource = Me.DFunBindingSourceZ0
        Me.DataGridViewZ0.GridColor = System.Drawing.SystemColors.ControlText
        Me.DataGridViewZ0.Location = New System.Drawing.Point(12, 25)
        Me.DataGridViewZ0.Name = "DataGridViewZ0"
        Me.DataGridViewZ0.RowHeadersVisible = False
        Me.DataGridViewZ0.Size = New System.Drawing.Size(1130, 571)
        Me.DataGridViewZ0.TabIndex = 0
        '
        'DFunBindingSourceZ0
        '
        Me.DFunBindingSourceZ0.DataSource = GetType(modRasstOp.DFun)
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
        Me.Label3.Location = New System.Drawing.Point(1058, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "фаза 3"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Info"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Info"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DFunBindingSourceZ2
        '
        Me.DFunBindingSourceZ2.DataSource = GetType(modRasstOp.DFun)
        '
        'DFunBindingSourcez1
        '
        Me.DFunBindingSourcez1.DataSource = GetType(modRasstOp.DFun)
        '
        'NameDataGridViewTextBoxColumn
        '
        Me.NameDataGridViewTextBoxColumn.DataPropertyName = "Name"
        Me.NameDataGridViewTextBoxColumn.HeaderText = "Опоры"
        Me.NameDataGridViewTextBoxColumn.Name = "NameDataGridViewTextBoxColumn"
        Me.NameDataGridViewTextBoxColumn.Width = 66
        '
        'Piketaj
        '
        Me.Piketaj.DataPropertyName = "Piketaj"
        Me.Piketaj.HeaderText = "Пикет опоры"
        Me.Piketaj.Name = "Piketaj"
        Me.Piketaj.Width = 98
        '
        'ArgDataGridViewTextBoxColumn
        '
        Me.ArgDataGridViewTextBoxColumn.DataPropertyName = "Arg"
        DataGridViewCellStyle1.Format = "N1"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.ArgDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.ArgDataGridViewTextBoxColumn.HeaderText = "Расстояние до мин. сближения "
        Me.ArgDataGridViewTextBoxColumn.Name = "ArgDataGridViewTextBoxColumn"
        Me.ArgDataGridViewTextBoxColumn.ReadOnly = True
        Me.ArgDataGridViewTextBoxColumn.ToolTipText = "растояние экстермальной точки от левой опоры"
        Me.ArgDataGridViewTextBoxColumn.Width = 124
        '
        'FunDataGridViewTextBoxColumn
        '
        Me.FunDataGridViewTextBoxColumn.DataPropertyName = "Fun"
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.FunDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.FunDataGridViewTextBoxColumn.HeaderText = "Мин. сближение"
        Me.FunDataGridViewTextBoxColumn.Name = "FunDataGridViewTextBoxColumn"
        Me.FunDataGridViewTextBoxColumn.ReadOnly = True
        Me.FunDataGridViewTextBoxColumn.ToolTipText = "Минимальное сближение"
        Me.FunDataGridViewTextBoxColumn.Width = 105
        '
        'DopDataGridViewTextBoxColumn
        '
        Me.DopDataGridViewTextBoxColumn.DataPropertyName = "GabaritSer"
        DataGridViewCellStyle3.Format = "N1"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.DopDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.DopDataGridViewTextBoxColumn.HeaderText = "Сближение в середине"
        Me.DopDataGridViewTextBoxColumn.Name = "DopDataGridViewTextBoxColumn"
        Me.DopDataGridViewTextBoxColumn.Width = 93
        '
        'PoVertikal
        '
        Me.PoVertikal.DataPropertyName = "PoVertikal"
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.PoVertikal.DefaultCellStyle = DataGridViewCellStyle4
        Me.PoVertikal.HeaderText = "Сближение по вертикали"
        Me.PoVertikal.Name = "PoVertikal"
        Me.PoVertikal.Width = 146
        '
        'Info
        '
        Me.Info.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Info.DataPropertyName = "Info"
        Me.Info.HeaderText = "Info"
        Me.Info.Name = "Info"
        '
        'Info2
        '
        Me.Info2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Info2.DataPropertyName = "Info2"
        Me.Info2.HeaderText = "Info2"
        Me.Info2.Name = "Info2"
        '
        'FrmWiwRezGabaritTros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1165, 608)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridViewZ0)
        Me.Name = "FrmWiwRezGabaritTros"
        Me.Text = "минимальные сближения провод трос."
        CType(Me.DataGridViewZ0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DFunBindingSourceZ0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DFunBindingSourceZ2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DFunBindingSourcez1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridViewZ0 As System.Windows.Forms.DataGridView
    Public WithEvents DFunBindingSourcez1 As System.Windows.Forms.BindingSource
    Public WithEvents DFunBindingSourceZ2 As System.Windows.Forms.BindingSource
    Friend WithEvents DFunBindingSourceZ0 As System.Windows.Forms.BindingSource
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Piketaj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ArgDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FunDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DopDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PoVertikal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Info As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Info2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
