<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOpora
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
        Me.TipopDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WisopDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Wisop1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Wisop2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WisopTDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ZepnDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipiDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdUnomDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OporiBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TipElWl_06 = New Global.BD_WL_O6.TipElWl_06()
        Me.OporiTableAdapter = New TipElWl_06TableAdapters.oporiTableAdapter()
        Me.buttonPeredach = New System.Windows.Forms.Button()
        Me.LabelShifrOp = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxPoisk = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OporiBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TipElWl_06, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TipopDataGridViewTextBoxColumn, Me.WisopDataGridViewTextBoxColumn, Me.Wisop1DataGridViewTextBoxColumn, Me.Wisop2DataGridViewTextBoxColumn, Me.WisopTDataGridViewTextBoxColumn, Me.ZepnDataGridViewTextBoxColumn, Me.TipiDataGridViewTextBoxColumn, Me.IdUnomDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.OporiBindingSource
        Me.DataGridView1.Location = New System.Drawing.Point(21, 33)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1262, 516)
        Me.DataGridView1.TabIndex = 0
        '
        'TipopDataGridViewTextBoxColumn
        '
        Me.TipopDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TipopDataGridViewTextBoxColumn.DataPropertyName = "Tip_op"
        Me.TipopDataGridViewTextBoxColumn.HeaderText = "Шифр опоры"
        Me.TipopDataGridViewTextBoxColumn.Name = "TipopDataGridViewTextBoxColumn"
        '
        'WisopDataGridViewTextBoxColumn
        '
        Me.WisopDataGridViewTextBoxColumn.DataPropertyName = "Wis_op"
        Me.WisopDataGridViewTextBoxColumn.HeaderText = "Wis_op"
        Me.WisopDataGridViewTextBoxColumn.Name = "WisopDataGridViewTextBoxColumn"
        '
        'Wisop1DataGridViewTextBoxColumn
        '
        Me.Wisop1DataGridViewTextBoxColumn.DataPropertyName = "Wis_op1"
        Me.Wisop1DataGridViewTextBoxColumn.HeaderText = "Wis_op1"
        Me.Wisop1DataGridViewTextBoxColumn.Name = "Wisop1DataGridViewTextBoxColumn"
        '
        'Wisop2DataGridViewTextBoxColumn
        '
        Me.Wisop2DataGridViewTextBoxColumn.DataPropertyName = "Wis_op2"
        Me.Wisop2DataGridViewTextBoxColumn.HeaderText = "Wis_op2"
        Me.Wisop2DataGridViewTextBoxColumn.Name = "Wisop2DataGridViewTextBoxColumn"
        '
        'WisopTDataGridViewTextBoxColumn
        '
        Me.WisopTDataGridViewTextBoxColumn.DataPropertyName = "Wis_opT"
        Me.WisopTDataGridViewTextBoxColumn.HeaderText = "Wis_opT"
        Me.WisopTDataGridViewTextBoxColumn.Name = "WisopTDataGridViewTextBoxColumn"
        '
        'ZepnDataGridViewTextBoxColumn
        '
        Me.ZepnDataGridViewTextBoxColumn.DataPropertyName = "Zepn"
        Me.ZepnDataGridViewTextBoxColumn.HeaderText = "Zepn"
        Me.ZepnDataGridViewTextBoxColumn.Name = "ZepnDataGridViewTextBoxColumn"
        '
        'TipiDataGridViewTextBoxColumn
        '
        Me.TipiDataGridViewTextBoxColumn.DataPropertyName = "Tip_i"
        Me.TipiDataGridViewTextBoxColumn.HeaderText = "Tip_i"
        Me.TipiDataGridViewTextBoxColumn.Name = "TipiDataGridViewTextBoxColumn"
        '
        'IdUnomDataGridViewTextBoxColumn
        '
        Me.IdUnomDataGridViewTextBoxColumn.DataPropertyName = "IdUnom"
        Me.IdUnomDataGridViewTextBoxColumn.HeaderText = "IdUnom"
        Me.IdUnomDataGridViewTextBoxColumn.Name = "IdUnomDataGridViewTextBoxColumn"
        '
        'OporiBindingSource
        '
        Me.OporiBindingSource.DataMember = "opori"
        Me.OporiBindingSource.DataSource = Me.TipElWl_06
        '
        'TipElWl_06
        '
        Me.TipElWl_06.DataSetName = "TipElWl_06"
        Me.TipElWl_06.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'OporiTableAdapter
        '
        Me.OporiTableAdapter.ClearBeforeFill = True
        '
        'buttonPeredach
        '
        Me.buttonPeredach.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.buttonPeredach.Location = New System.Drawing.Point(311, 4)
        Me.buttonPeredach.Name = "buttonPeredach"
        Me.buttonPeredach.Size = New System.Drawing.Size(75, 23)
        Me.buttonPeredach.TabIndex = 6
        Me.buttonPeredach.Text = "Передать"
        Me.buttonPeredach.UseVisualStyleBackColor = True
        '
        'LabelShifrOp
        '
        Me.LabelShifrOp.AutoSize = True
        Me.LabelShifrOp.Location = New System.Drawing.Point(117, 9)
        Me.LabelShifrOp.Name = "LabelShifrOp"
        Me.LabelShifrOp.Size = New System.Drawing.Size(52, 13)
        Me.LabelShifrOp.TabIndex = 5
        Me.LabelShifrOp.Text = "Выбрана"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(59, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Выбрана"
        '
        'TextBoxPoisk
        '
        Me.TextBoxPoisk.Location = New System.Drawing.Point(582, 7)
        Me.TextBoxPoisk.Name = "TextBoxPoisk"
        Me.TextBoxPoisk.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxPoisk.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(481, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Фильтр"
        '
        'FrmOpora
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1333, 594)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBoxPoisk)
        Me.Controls.Add(Me.buttonPeredach)
        Me.Controls.Add(Me.LabelShifrOp)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "FrmOpora"
        Me.Text = "FrmOpora"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OporiBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TipElWl_06, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents TipElWl_06 As Global.BD_WL_O6.TipElWl_06
    Friend WithEvents OporiBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents OporiTableAdapter As TipElWl_06TableAdapters.oporiTableAdapter
    Friend WithEvents TipopDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WisopDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Wisop1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Wisop2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WisopTDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ZepnDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipiDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdUnomDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents buttonPeredach As System.Windows.Forms.Button
    Friend WithEvents LabelShifrOp As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxPoisk As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
