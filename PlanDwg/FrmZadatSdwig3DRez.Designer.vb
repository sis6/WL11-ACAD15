<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmZadatSdwig3DRez
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DFunBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LabelNameOp = New System.Windows.Forms.Label()
        Me.LabelSigma = New System.Windows.Forms.Label()
        Me.Сигма = New System.Windows.Forms.Label()
        Me.LabelGamma = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LabelTemp = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ArgDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FunDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PoVertikalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GabaritDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GabaritSerDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DopDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DFunBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NameDataGridViewTextBoxColumn, Me.ArgDataGridViewTextBoxColumn, Me.FunDataGridViewTextBoxColumn, Me.PoVertikalDataGridViewTextBoxColumn, Me.GabaritDataGridViewTextBoxColumn, Me.GabaritSerDataGridViewTextBoxColumn, Me.DopDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.DFunBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = """"""
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.Location = New System.Drawing.Point(12, 73)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(859, 440)
        Me.DataGridView1.TabIndex = 0
        '
        'DFunBindingSource
        '
        Me.DFunBindingSource.DataSource = GetType(modRasstOp.DFun)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(56, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Опора"
        '
        'LabelNameOp
        '
        Me.LabelNameOp.AutoSize = True
        Me.LabelNameOp.Location = New System.Drawing.Point(128, 13)
        Me.LabelNameOp.Name = "LabelNameOp"
        Me.LabelNameOp.Size = New System.Drawing.Size(39, 13)
        Me.LabelNameOp.TabIndex = 2
        Me.LabelNameOp.Text = "Опора"
        '
        'LabelSigma
        '
        Me.LabelSigma.AutoSize = True
        Me.LabelSigma.Location = New System.Drawing.Point(128, 40)
        Me.LabelSigma.Name = "LabelSigma"
        Me.LabelSigma.Size = New System.Drawing.Size(39, 13)
        Me.LabelSigma.TabIndex = 4
        Me.LabelSigma.Text = "Сигма"
        '
        'Сигма
        '
        Me.Сигма.AutoSize = True
        Me.Сигма.Location = New System.Drawing.Point(56, 40)
        Me.Сигма.Name = "Сигма"
        Me.Сигма.Size = New System.Drawing.Size(39, 13)
        Me.Сигма.TabIndex = 3
        Me.Сигма.Text = "Сигма"
        '
        'LabelGamma
        '
        Me.LabelGamma.AutoSize = True
        Me.LabelGamma.Location = New System.Drawing.Point(286, 40)
        Me.LabelGamma.Name = "LabelGamma"
        Me.LabelGamma.Size = New System.Drawing.Size(41, 13)
        Me.LabelGamma.TabIndex = 6
        Me.LabelGamma.Text = "Гамма"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(214, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Гамма"
        '
        'LabelTemp
        '
        Me.LabelTemp.AutoSize = True
        Me.LabelTemp.Location = New System.Drawing.Point(465, 40)
        Me.LabelTemp.Name = "LabelTemp"
        Me.LabelTemp.Size = New System.Drawing.Size(74, 13)
        Me.LabelTemp.TabIndex = 8
        Me.LabelTemp.Text = "Температура"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(366, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Температура"
        '
        'NameDataGridViewTextBoxColumn
        '
        Me.NameDataGridViewTextBoxColumn.DataPropertyName = "Name"
        Me.NameDataGridViewTextBoxColumn.HeaderText = "Провод"
        Me.NameDataGridViewTextBoxColumn.Name = "NameDataGridViewTextBoxColumn"
        Me.NameDataGridViewTextBoxColumn.Width = 76
        '
        'ArgDataGridViewTextBoxColumn
        '
        Me.ArgDataGridViewTextBoxColumn.DataPropertyName = "Arg"
        Me.ArgDataGridViewTextBoxColumn.HeaderText = "Расстояние от начала пролета"
        Me.ArgDataGridViewTextBoxColumn.Name = "ArgDataGridViewTextBoxColumn"
        Me.ArgDataGridViewTextBoxColumn.ReadOnly = True
        Me.ArgDataGridViewTextBoxColumn.Width = 153
        '
        'FunDataGridViewTextBoxColumn
        '
        Me.FunDataGridViewTextBoxColumn.DataPropertyName = "Fun"
        Me.FunDataGridViewTextBoxColumn.HeaderText = "Сближение с проводом"
        Me.FunDataGridViewTextBoxColumn.Name = "FunDataGridViewTextBoxColumn"
        Me.FunDataGridViewTextBoxColumn.ReadOnly = True
        Me.FunDataGridViewTextBoxColumn.Width = 104
        '
        'PoVertikalDataGridViewTextBoxColumn
        '
        Me.PoVertikalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.PoVertikalDataGridViewTextBoxColumn.DataPropertyName = "PoVertikal"
        Me.PoVertikalDataGridViewTextBoxColumn.HeaderText = "Сближение по вертикали"
        Me.PoVertikalDataGridViewTextBoxColumn.Name = "PoVertikalDataGridViewTextBoxColumn"
        Me.PoVertikalDataGridViewTextBoxColumn.Width = 120
        '
        'GabaritDataGridViewTextBoxColumn
        '
        Me.GabaritDataGridViewTextBoxColumn.DataPropertyName = "Gabarit"
        Me.GabaritDataGridViewTextBoxColumn.HeaderText = "Отметка точки"
        Me.GabaritDataGridViewTextBoxColumn.Name = "GabaritDataGridViewTextBoxColumn"
        Me.GabaritDataGridViewTextBoxColumn.Width = 110
        '
        'GabaritSerDataGridViewTextBoxColumn
        '
        Me.GabaritSerDataGridViewTextBoxColumn.DataPropertyName = "GabaritSer"
        Me.GabaritSerDataGridViewTextBoxColumn.HeaderText = "Сдвиг поперечный"
        Me.GabaritSerDataGridViewTextBoxColumn.Name = "GabaritSerDataGridViewTextBoxColumn"
        Me.GabaritSerDataGridViewTextBoxColumn.Width = 130
        '
        'DopDataGridViewTextBoxColumn
        '
        Me.DopDataGridViewTextBoxColumn.DataPropertyName = "Dop"
        Me.DopDataGridViewTextBoxColumn.HeaderText = "Длина пролета провода"
        Me.DopDataGridViewTextBoxColumn.Name = "DopDataGridViewTextBoxColumn"
        Me.DopDataGridViewTextBoxColumn.Width = 159
        '
        'FrmZadatSdwig3DRez
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(883, 525)
        Me.Controls.Add(Me.LabelTemp)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LabelGamma)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LabelSigma)
        Me.Controls.Add(Me.Сигма)
        Me.Controls.Add(Me.LabelNameOp)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "FrmZadatSdwig3DRez"
        Me.Text = "FrmZadatSdwig3DRez"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DFunBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DFunBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LabelNameOp As System.Windows.Forms.Label
    Friend WithEvents LabelSigma As System.Windows.Forms.Label
    Friend WithEvents Сигма As System.Windows.Forms.Label
    Friend WithEvents LabelGamma As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LabelTemp As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents NameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ArgDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FunDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PoVertikalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GabaritDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GabaritSerDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DopDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
