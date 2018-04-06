<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmZadatSdwig3D
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LabelOpor = New System.Windows.Forms.Label()
        Me.LabelRasst = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LabelPiketaj = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LabelDlinaProleta = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboBoxGamma = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBoxTemp = New System.Windows.Forms.TextBox()
        Me.ButtonZagr = New System.Windows.Forms.Button()
        Me.ButtonSohr = New System.Windows.Forms.Button()
        Me.LabelOzapicb = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBoxGamma = New System.Windows.Forms.TextBox()
        Me.TextBoxSigma = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.OtNachalaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SdwigPopereshDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OtmetkaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SdwigPoProletyBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SdwigPoProletyBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(70, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Пролет"
        '
        'LabelOpor
        '
        Me.LabelOpor.AutoSize = True
        Me.LabelOpor.Location = New System.Drawing.Point(115, 13)
        Me.LabelOpor.Name = "LabelOpor"
        Me.LabelOpor.Size = New System.Drawing.Size(36, 13)
        Me.LabelOpor.TabIndex = 1
        Me.LabelOpor.Text = "Oporа"
        '
        'LabelRasst
        '
        Me.LabelRasst.AutoSize = True
        Me.LabelRasst.Location = New System.Drawing.Point(573, 13)
        Me.LabelRasst.Name = "LabelRasst"
        Me.LabelRasst.Size = New System.Drawing.Size(61, 13)
        Me.LabelRasst.TabIndex = 3
        Me.LabelRasst.Text = "Растояние"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(341, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(203, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Растояние по профилю заданой точкм"
        '
        'ButtonOK
        '
        Me.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ButtonOK.Location = New System.Drawing.Point(486, 354)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(75, 23)
        Me.ButtonOK.TabIndex = 8
        Me.ButtonOK.Text = "Расчет"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(164, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Пикетаж левой опоры пролета"
        '
        'LabelPiketaj
        '
        Me.LabelPiketaj.AutoSize = True
        Me.LabelPiketaj.Location = New System.Drawing.Point(201, 49)
        Me.LabelPiketaj.Name = "LabelPiketaj"
        Me.LabelPiketaj.Size = New System.Drawing.Size(36, 13)
        Me.LabelPiketaj.TabIndex = 10
        Me.LabelPiketaj.Text = "пикет"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Выбрано"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 77)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(123, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Задать режим расчета"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(270, 49)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Длина пролета"
        '
        'LabelDlinaProleta
        '
        Me.LabelDlinaProleta.AutoSize = True
        Me.LabelDlinaProleta.Location = New System.Drawing.Point(385, 49)
        Me.LabelDlinaProleta.Name = "LabelDlinaProleta"
        Me.LabelDlinaProleta.Size = New System.Drawing.Size(42, 13)
        Me.LabelDlinaProleta.TabIndex = 17
        Me.LabelDlinaProleta.Text = "пролет"
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OtNachalaDataGridViewTextBoxColumn, Me.SdwigPopereshDataGridViewTextBoxColumn, Me.OtmetkaDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.SdwigPoProletyBindingSource
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.Format = "N1"
        DataGridViewCellStyle1.NullValue = Nothing
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.Location = New System.Drawing.Point(17, 189)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(393, 325)
        Me.DataGridView1.TabIndex = 18
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 173)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(140, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Задать точки для анализа"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(309, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Гамма(Удельная нагрузка приведеная к сечению провода)"
        '
        'ComboBoxGamma
        '
        Me.ComboBoxGamma.FormattingEnabled = True
        Me.ComboBoxGamma.Items.AddRange(New Object() {"γ1", "γ2", "γ3", "γ4", "γ4a", "γ5", "γ6", "γ6a", "γ7"})
        Me.ComboBoxGamma.Location = New System.Drawing.Point(344, 98)
        Me.ComboBoxGamma.Name = "ComboBoxGamma"
        Me.ComboBoxGamma.Size = New System.Drawing.Size(66, 21)
        Me.ComboBoxGamma.TabIndex = 21
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(442, 98)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 13)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "температура"
        '
        'TextBoxTemp
        '
        Me.TextBoxTemp.Location = New System.Drawing.Point(528, 95)
        Me.TextBoxTemp.Name = "TextBoxTemp"
        Me.TextBoxTemp.Size = New System.Drawing.Size(59, 20)
        Me.TextBoxTemp.TabIndex = 23
        '
        'ButtonZagr
        '
        Me.ButtonZagr.Location = New System.Drawing.Point(486, 232)
        Me.ButtonZagr.Name = "ButtonZagr"
        Me.ButtonZagr.Size = New System.Drawing.Size(75, 23)
        Me.ButtonZagr.TabIndex = 24
        Me.ButtonZagr.Text = "загрузить"
        Me.ButtonZagr.UseVisualStyleBackColor = True
        '
        'ButtonSohr
        '
        Me.ButtonSohr.Location = New System.Drawing.Point(486, 292)
        Me.ButtonSohr.Name = "ButtonSohr"
        Me.ButtonSohr.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSohr.TabIndex = 25
        Me.ButtonSohr.Text = "Сохранить"
        Me.ButtonSohr.UseVisualStyleBackColor = True
        '
        'LabelOzapicb
        '
        Me.LabelOzapicb.AutoSize = True
        Me.LabelOzapicb.Location = New System.Drawing.Point(483, 189)
        Me.LabelOzapicb.Name = "LabelOzapicb"
        Me.LabelOzapicb.Size = New System.Drawing.Size(118, 13)
        Me.LabelOzapicb.TabIndex = 26
        Me.LabelOzapicb.Text = "Записи в словаре нет"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(171, 136)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 13)
        Me.Label10.TabIndex = 29
        Me.Label10.Text = "Гамма"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(371, 137)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 13)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "Сигма"
        '
        'TextBoxGamma
        '
        Me.TextBoxGamma.Location = New System.Drawing.Point(245, 134)
        Me.TextBoxGamma.Name = "TextBoxGamma"
        Me.TextBoxGamma.ReadOnly = True
        Me.TextBoxGamma.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxGamma.TabIndex = 31
        '
        'TextBoxSigma
        '
        Me.TextBoxSigma.Location = New System.Drawing.Point(433, 134)
        Me.TextBoxSigma.Name = "TextBoxSigma"
        Me.TextBoxSigma.ReadOnly = True
        Me.TextBoxSigma.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxSigma.TabIndex = 32
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(17, 136)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(129, 17)
        Me.CheckBox1.TabIndex = 33
        Me.CheckBox1.Text = "Задать явно режим "
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'OtNachalaDataGridViewTextBoxColumn
        '
        Me.OtNachalaDataGridViewTextBoxColumn.DataPropertyName = "OtNachala"
        Me.OtNachalaDataGridViewTextBoxColumn.HeaderText = "От левой опоры(м.)"
        Me.OtNachalaDataGridViewTextBoxColumn.Name = "OtNachalaDataGridViewTextBoxColumn"
        Me.OtNachalaDataGridViewTextBoxColumn.Width = 119
        '
        'SdwigPopereshDataGridViewTextBoxColumn
        '
        Me.SdwigPopereshDataGridViewTextBoxColumn.DataPropertyName = "SdwigPoperesh"
        Me.SdwigPopereshDataGridViewTextBoxColumn.HeaderText = "Поперечный сдвиг(м.)"
        Me.SdwigPopereshDataGridViewTextBoxColumn.Name = "SdwigPopereshDataGridViewTextBoxColumn"
        Me.SdwigPopereshDataGridViewTextBoxColumn.Width = 132
        '
        'OtmetkaDataGridViewTextBoxColumn
        '
        Me.OtmetkaDataGridViewTextBoxColumn.DataPropertyName = "Otmetka"
        Me.OtmetkaDataGridViewTextBoxColumn.HeaderText = "Отметка(м.)"
        Me.OtmetkaDataGridViewTextBoxColumn.Name = "OtmetkaDataGridViewTextBoxColumn"
        Me.OtmetkaDataGridViewTextBoxColumn.Width = 93
        '
        'SdwigPoProletyBindingSource
        '
        Me.SdwigPoProletyBindingSource.DataSource = GetType(PlanDwg.SdwigPoProlety)
        '
        'FrmZadatSdwig3D
        '
        Me.AcceptButton = Me.ButtonOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(683, 526)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.TextBoxSigma)
        Me.Controls.Add(Me.TextBoxGamma)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.LabelOzapicb)
        Me.Controls.Add(Me.ButtonSohr)
        Me.Controls.Add(Me.ButtonZagr)
        Me.Controls.Add(Me.TextBoxTemp)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ComboBoxGamma)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.LabelDlinaProleta)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LabelPiketaj)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.LabelRasst)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LabelOpor)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmZadatSdwig3D"
        Me.Text = "задать сдвиг 3D"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SdwigPoProletyBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents LabelOpor As System.Windows.Forms.Label
    Public WithEvents LabelRasst As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ButtonOK As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents LabelPiketaj As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents LabelDlinaProleta As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents SdwigPoProletyBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxGamma As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextBoxTemp As System.Windows.Forms.TextBox
    Friend WithEvents ButtonZagr As System.Windows.Forms.Button
    Friend WithEvents ButtonSohr As System.Windows.Forms.Button
    Friend WithEvents LabelOzapicb As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBoxGamma As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxSigma As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents OtNachalaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SdwigPopereshDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OtmetkaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
