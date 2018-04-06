<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProwod
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ProwodaNBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TipElWl_06 = New Global.BD_WL_O6.TipElWl_06()
        Me.ProwodaNTableAdapter = New TipElWl_06TableAdapters.prowodaNTableAdapter()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Labelmarkf = New System.Windows.Forms.Label()
        Me.buttonPeredach = New System.Windows.Forms.Button()
        Me.NamemarkDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SprwdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DiamPrwdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PpogonDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SigMaxDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AlfaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JungDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SigGolDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SigSrGDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TekplDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ModFDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ModDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProwodaNBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TipElWl_06, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NamemarkDataGridViewTextBoxColumn, Me.SprwdDataGridViewTextBoxColumn, Me.DiamPrwdDataGridViewTextBoxColumn, Me.PpogonDataGridViewTextBoxColumn, Me.SigMaxDataGridViewTextBoxColumn, Me.AlfaDataGridViewTextBoxColumn, Me.JungDataGridViewTextBoxColumn, Me.SigGolDataGridViewTextBoxColumn, Me.SigSrGDataGridViewTextBoxColumn, Me.TekplDataGridViewTextBoxColumn, Me.ModFDataGridViewTextBoxColumn, Me.ModDDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.ProwodaNBindingSource
        Me.DataGridView1.Location = New System.Drawing.Point(12, 24)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1309, 562)
        Me.DataGridView1.TabIndex = 0
        '
        'ProwodaNBindingSource
        '
        Me.ProwodaNBindingSource.DataMember = "prowodaN"
        Me.ProwodaNBindingSource.DataSource = Me.TipElWl_06
        '
        'TipElWl_06
        '
        Me.TipElWl_06.DataSetName = "TipElWl_06"
        Me.TipElWl_06.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ProwodaNTableAdapter
        '
        Me.ProwodaNTableAdapter.ClearBeforeFill = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Выбрана"
        '
        'Labelmarkf
        '
        Me.Labelmarkf.AutoSize = True
        Me.Labelmarkf.Location = New System.Drawing.Point(93, 5)
        Me.Labelmarkf.Name = "Labelmarkf"
        Me.Labelmarkf.Size = New System.Drawing.Size(52, 13)
        Me.Labelmarkf.TabIndex = 2
        Me.Labelmarkf.Text = "Выбрана"
        '
        'buttonPeredach
        '
        Me.buttonPeredach.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.buttonPeredach.Location = New System.Drawing.Point(287, 0)
        Me.buttonPeredach.Name = "buttonPeredach"
        Me.buttonPeredach.Size = New System.Drawing.Size(75, 23)
        Me.buttonPeredach.TabIndex = 3
        Me.buttonPeredach.Text = "Передать"
        Me.buttonPeredach.UseVisualStyleBackColor = True
        '
        'NamemarkDataGridViewTextBoxColumn
        '
        Me.NamemarkDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.NamemarkDataGridViewTextBoxColumn.DataPropertyName = "Name_mark"
        Me.NamemarkDataGridViewTextBoxColumn.HeaderText = "Name_mark"
        Me.NamemarkDataGridViewTextBoxColumn.Name = "NamemarkDataGridViewTextBoxColumn"
        '
        'SprwdDataGridViewTextBoxColumn
        '
        Me.SprwdDataGridViewTextBoxColumn.DataPropertyName = "Sprwd"
        Me.SprwdDataGridViewTextBoxColumn.HeaderText = "Sprwd"
        Me.SprwdDataGridViewTextBoxColumn.Name = "SprwdDataGridViewTextBoxColumn"
        Me.SprwdDataGridViewTextBoxColumn.Width = 62
        '
        'DiamPrwdDataGridViewTextBoxColumn
        '
        Me.DiamPrwdDataGridViewTextBoxColumn.DataPropertyName = "DiamPrwd"
        Me.DiamPrwdDataGridViewTextBoxColumn.HeaderText = "DiamPrwd"
        Me.DiamPrwdDataGridViewTextBoxColumn.Name = "DiamPrwdDataGridViewTextBoxColumn"
        Me.DiamPrwdDataGridViewTextBoxColumn.Width = 80
        '
        'PpogonDataGridViewTextBoxColumn
        '
        Me.PpogonDataGridViewTextBoxColumn.DataPropertyName = "Ppogon"
        Me.PpogonDataGridViewTextBoxColumn.HeaderText = "Ppogon"
        Me.PpogonDataGridViewTextBoxColumn.Name = "PpogonDataGridViewTextBoxColumn"
        Me.PpogonDataGridViewTextBoxColumn.Width = 69
        '
        'SigMaxDataGridViewTextBoxColumn
        '
        Me.SigMaxDataGridViewTextBoxColumn.DataPropertyName = "SigMax"
        Me.SigMaxDataGridViewTextBoxColumn.HeaderText = "SigMax"
        Me.SigMaxDataGridViewTextBoxColumn.Name = "SigMaxDataGridViewTextBoxColumn"
        Me.SigMaxDataGridViewTextBoxColumn.Width = 67
        '
        'AlfaDataGridViewTextBoxColumn
        '
        Me.AlfaDataGridViewTextBoxColumn.DataPropertyName = "Alfa"
        Me.AlfaDataGridViewTextBoxColumn.HeaderText = "Alfa"
        Me.AlfaDataGridViewTextBoxColumn.Name = "AlfaDataGridViewTextBoxColumn"
        Me.AlfaDataGridViewTextBoxColumn.Width = 50
        '
        'JungDataGridViewTextBoxColumn
        '
        Me.JungDataGridViewTextBoxColumn.DataPropertyName = "Jung"
        Me.JungDataGridViewTextBoxColumn.HeaderText = "Jung"
        Me.JungDataGridViewTextBoxColumn.Name = "JungDataGridViewTextBoxColumn"
        Me.JungDataGridViewTextBoxColumn.Width = 55
        '
        'SigGolDataGridViewTextBoxColumn
        '
        Me.SigGolDataGridViewTextBoxColumn.DataPropertyName = "SigGol"
        Me.SigGolDataGridViewTextBoxColumn.HeaderText = "SigGol"
        Me.SigGolDataGridViewTextBoxColumn.Name = "SigGolDataGridViewTextBoxColumn"
        Me.SigGolDataGridViewTextBoxColumn.Width = 63
        '
        'SigSrGDataGridViewTextBoxColumn
        '
        Me.SigSrGDataGridViewTextBoxColumn.DataPropertyName = "SigSrG"
        Me.SigSrGDataGridViewTextBoxColumn.HeaderText = "SigSrG"
        Me.SigSrGDataGridViewTextBoxColumn.Name = "SigSrGDataGridViewTextBoxColumn"
        Me.SigSrGDataGridViewTextBoxColumn.Width = 65
        '
        'TekplDataGridViewTextBoxColumn
        '
        Me.TekplDataGridViewTextBoxColumn.DataPropertyName = "Tekpl"
        Me.TekplDataGridViewTextBoxColumn.HeaderText = "Tekpl"
        Me.TekplDataGridViewTextBoxColumn.Name = "TekplDataGridViewTextBoxColumn"
        Me.TekplDataGridViewTextBoxColumn.Width = 59
        '
        'ModFDataGridViewTextBoxColumn
        '
        Me.ModFDataGridViewTextBoxColumn.DataPropertyName = "ModF"
        Me.ModFDataGridViewTextBoxColumn.HeaderText = "ModF"
        Me.ModFDataGridViewTextBoxColumn.Name = "ModFDataGridViewTextBoxColumn"
        Me.ModFDataGridViewTextBoxColumn.Width = 59
        '
        'ModDDataGridViewTextBoxColumn
        '
        Me.ModDDataGridViewTextBoxColumn.DataPropertyName = "ModD"
        Me.ModDDataGridViewTextBoxColumn.HeaderText = "ModD"
        Me.ModDDataGridViewTextBoxColumn.Name = "ModDDataGridViewTextBoxColumn"
        Me.ModDDataGridViewTextBoxColumn.Width = 61
        '
        'FrmProwod
        '
        Me.AcceptButton = Me.buttonPeredach
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1344, 598)
        Me.Controls.Add(Me.buttonPeredach)
        Me.Controls.Add(Me.Labelmarkf)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "FrmProwod"
        Me.Text = "FrmProwod"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProwodaNBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TipElWl_06, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents TipElWl_06 As Global.BD_WL_O6.TipElWl_06
    Friend WithEvents ProwodaNBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProwodaNTableAdapter As TipElWl_06TableAdapters.prowodaNTableAdapter
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Labelmarkf As System.Windows.Forms.Label
    Friend WithEvents buttonPeredach As System.Windows.Forms.Button
    Friend WithEvents NamemarkDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SprwdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiamPrwdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PpogonDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SigMaxDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AlfaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JungDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SigGolDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SigSrGDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TekplDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ModFDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ModDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
