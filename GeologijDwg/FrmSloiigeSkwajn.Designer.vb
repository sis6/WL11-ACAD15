Imports GeologijDwg

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSloiigeSkwajn
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
        Me.DataGridViewIgeskwajBeg = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Glubina = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IndexIgeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SloiIgeRealSkwajBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TextBoxName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBoxRast = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBoxPiketaj = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBoxOtmetka = New System.Windows.Forms.TextBox()
        Me.DataGridViewIgeskwaEnd = New System.Windows.Forms.DataGridView()
        Me.Rastojnie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TolschinaEnd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NameSkwajBeg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SloiIgeRealSkwajEndBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ButtonOk = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBoxGlubina = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewParamIge = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RazrezIgeRealSkwajBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ButtonPerep = New System.Windows.Forms.Button()
        CType(Me.DataGridViewIgeskwajBeg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SloiIgeRealSkwajBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewIgeskwaEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SloiIgeRealSkwajEndBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RazrezIgeRealSkwajBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridViewIgeskwajBeg
        '
        Me.DataGridViewIgeskwajBeg.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewIgeskwajBeg.AutoGenerateColumns = False
        Me.DataGridViewIgeskwajBeg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.DataGridViewIgeskwajBeg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewIgeskwajBeg.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn9, Me.Glubina, Me.IndexIgeDataGridViewTextBoxColumn, Me.DataGridViewTextBoxColumn8})
        Me.DataGridViewIgeskwajBeg.DataSource = Me.SloiIgeRealSkwajBindingSource
        Me.DataGridViewIgeskwajBeg.Location = New System.Drawing.Point(99, 44)
        Me.DataGridViewIgeskwajBeg.Name = "DataGridViewIgeskwajBeg"
        DataGridViewCellStyle1.Format = "N1"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.DataGridViewIgeskwajBeg.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewIgeskwajBeg.Size = New System.Drawing.Size(414, 210)
        Me.DataGridViewIgeskwajBeg.TabIndex = 3
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "Rastojnie"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Гран. слоя"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 86
        '
        'Glubina
        '
        Me.Glubina.DataPropertyName = "Glubina"
        Me.Glubina.HeaderText = "Глубина"
        Me.Glubina.Name = "Glubina"
        Me.Glubina.ReadOnly = True
        Me.Glubina.Width = 73
        '
        'IndexIgeDataGridViewTextBoxColumn
        '
        Me.IndexIgeDataGridViewTextBoxColumn.DataPropertyName = "IndexIge"
        Me.IndexIgeDataGridViewTextBoxColumn.HeaderText = "ИГЭ"
        Me.IndexIgeDataGridViewTextBoxColumn.Name = "IndexIgeDataGridViewTextBoxColumn"
        Me.IndexIgeDataGridViewTextBoxColumn.ReadOnly = True
        Me.IndexIgeDataGridViewTextBoxColumn.Width = 53
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "NameObjekt"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Скваж->"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 74
        '
        'SloiIgeRealSkwajBindingSource
        '
        Me.SloiIgeRealSkwajBindingSource.DataSource = GetType(GeologijDwg.GranizaSlojIgeRealDwg)
        '
        'TextBoxName
        '
        Me.TextBoxName.Location = New System.Drawing.Point(84, 6)
        Me.TextBoxName.Name = "TextBoxName"
        Me.TextBoxName.Size = New System.Drawing.Size(88, 20)
        Me.TextBoxName.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "скважина"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(178, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "растояние"
        '
        'TextBoxRast
        '
        Me.TextBoxRast.Location = New System.Drawing.Point(253, 5)
        Me.TextBoxRast.Name = "TextBoxRast"
        Me.TextBoxRast.Size = New System.Drawing.Size(89, 20)
        Me.TextBoxRast.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(373, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "пикетаж"
        '
        'TextBoxPiketaj
        '
        Me.TextBoxPiketaj.Location = New System.Drawing.Point(429, 3)
        Me.TextBoxPiketaj.Name = "TextBoxPiketaj"
        Me.TextBoxPiketaj.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxPiketaj.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(591, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Отметка Проф."
        '
        'TextBoxOtmetka
        '
        Me.TextBoxOtmetka.Location = New System.Drawing.Point(682, 5)
        Me.TextBoxOtmetka.Name = "TextBoxOtmetka"
        Me.TextBoxOtmetka.Size = New System.Drawing.Size(68, 20)
        Me.TextBoxOtmetka.TabIndex = 10
        '
        'DataGridViewIgeskwaEnd
        '
        Me.DataGridViewIgeskwaEnd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewIgeskwaEnd.AutoGenerateColumns = False
        Me.DataGridViewIgeskwaEnd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.DataGridViewIgeskwaEnd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewIgeskwaEnd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Rastojnie, Me.TolschinaEnd, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn3, Me.NameSkwajBeg})
        Me.DataGridViewIgeskwaEnd.DataSource = Me.SloiIgeRealSkwajEndBindingSource
        Me.DataGridViewIgeskwaEnd.Location = New System.Drawing.Point(99, 272)
        Me.DataGridViewIgeskwaEnd.Name = "DataGridViewIgeskwaEnd"
        DataGridViewCellStyle2.Format = "N1"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.DataGridViewIgeskwaEnd.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewIgeskwaEnd.Size = New System.Drawing.Size(402, 250)
        Me.DataGridViewIgeskwaEnd.TabIndex = 12
        '
        'Rastojnie
        '
        Me.Rastojnie.DataPropertyName = "Rastojnie"
        Me.Rastojnie.HeaderText = "Гран. Слоя"
        Me.Rastojnie.Name = "Rastojnie"
        Me.Rastojnie.ReadOnly = True
        Me.Rastojnie.Width = 87
        '
        'TolschinaEnd
        '
        Me.TolschinaEnd.DataPropertyName = "Glubina"
        Me.TolschinaEnd.HeaderText = "Глубина"
        Me.TolschinaEnd.Name = "TolschinaEnd"
        Me.TolschinaEnd.ReadOnly = True
        Me.TolschinaEnd.Width = 73
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "WerhGraniza"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Отм. слоя"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 83
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "IndexIge"
        Me.DataGridViewTextBoxColumn3.HeaderText = "ИГЭ"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 53
        '
        'NameSkwajBeg
        '
        Me.NameSkwajBeg.DataPropertyName = "NameObjekt"
        Me.NameSkwajBeg.HeaderText = "Скваж. <-"
        Me.NameSkwajBeg.Name = "NameSkwajBeg"
        Me.NameSkwajBeg.ReadOnly = True
        Me.NameSkwajBeg.Width = 80
        '
        'SloiIgeRealSkwajEndBindingSource
        '
        Me.SloiIgeRealSkwajEndBindingSource.DataSource = GetType(GeologijDwg.GranizaSlojIgeRealDwg)
        '
        'ButtonOk
        '
        Me.ButtonOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ButtonOk.Location = New System.Drawing.Point(897, 525)
        Me.ButtonOk.Name = "ButtonOk"
        Me.ButtonOk.Size = New System.Drawing.Size(164, 23)
        Me.ButtonOk.TabIndex = 13
        Me.ButtonOk.Text = "переписать со сдвигом"
        Me.ButtonOk.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(793, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Глубина"
        '
        'TextBoxGlubina
        '
        Me.TextBoxGlubina.Location = New System.Drawing.Point(859, 5)
        Me.TextBoxGlubina.Name = "TextBoxGlubina"
        Me.TextBoxGlubina.Size = New System.Drawing.Size(66, 20)
        Me.TextBoxGlubina.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Слои Иге после"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 272)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Слои Иге до"
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewParamIge, Me.DataGridViewTextBoxColumn11})
        Me.DataGridView1.DataSource = Me.RazrezIgeRealSkwajBindingSource
        Me.DataGridView1.Location = New System.Drawing.Point(616, 60)
        Me.DataGridView1.Name = "DataGridView1"
        DataGridViewCellStyle3.Format = "N1"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.Size = New System.Drawing.Size(414, 210)
        Me.DataGridView1.TabIndex = 18
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Rastojnie"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Гран. слоя"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 86
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Glubina"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Глубина"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 73
        '
        'DataGridViewParamIge
        '
        Me.DataGridViewParamIge.DataPropertyName = "IndexIge"
        Me.DataGridViewParamIge.HeaderText = "ИГЭ"
        Me.DataGridViewParamIge.Name = "DataGridViewParamIge"
        Me.DataGridViewParamIge.ReadOnly = True
        Me.DataGridViewParamIge.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewParamIge.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewParamIge.Width = 53
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "NameObjekt"
        Me.DataGridViewTextBoxColumn11.HeaderText = "Скваж->"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Width = 74
        '
        'RazrezIgeRealSkwajBindingSource
        '
        Me.RazrezIgeRealSkwajBindingSource.DataSource = GetType(GeologijDwg.GranizaSlojIgeRealDwg)
        '
        'ButtonPerep
        '
        Me.ButtonPerep.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.ButtonPerep.Location = New System.Drawing.Point(675, 525)
        Me.ButtonPerep.Name = "ButtonPerep"
        Me.ButtonPerep.Size = New System.Drawing.Size(75, 23)
        Me.ButtonPerep.TabIndex = 19
        Me.ButtonPerep.Text = "переписать"
        Me.ButtonPerep.UseVisualStyleBackColor = True
        '
        'FrmSloiigeSkwajn
        '
        Me.AcceptButton = Me.ButtonOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1098, 560)
        Me.Controls.Add(Me.ButtonPerep)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBoxGlubina)
        Me.Controls.Add(Me.ButtonOk)
        Me.Controls.Add(Me.DataGridViewIgeskwaEnd)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBoxOtmetka)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBoxPiketaj)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBoxRast)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxName)
        Me.Controls.Add(Me.DataGridViewIgeskwajBeg)
        Me.Name = "FrmSloiigeSkwajn"
        Me.Text = "FrmSloiigeSkwajn"
        CType(Me.DataGridViewIgeskwajBeg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SloiIgeRealSkwajBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewIgeskwaEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SloiIgeRealSkwajEndBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RazrezIgeRealSkwajBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridViewIgeskwajBeg As System.Windows.Forms.DataGridView
    Friend WithEvents SloiIgeRealSkwajBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TextBoxName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBoxRast As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBoxPiketaj As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBoxOtmetka As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewIgeskwaEnd As System.Windows.Forms.DataGridView
    Friend WithEvents SloiIgeRealSkwajEndBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ButtonOk As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBoxGlubina As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TolschinaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NijGranizaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Glubina As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WerhGranizaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IndexIgeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rastojnie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TolschinaEnd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NameSkwajBeg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents RazrezIgeRealSkwajBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ButtonPerep As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewParamIge As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
