<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWiwRezRasp
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridViewRez = New System.Windows.Forms.DataGridView()
        Me.LabelUnom = New System.Windows.Forms.Label()
        Me.LabelDel = New System.Windows.Forms.Label()
        Me.ButtonWExcel = New System.Windows.Forms.Button()
        Me.ButtonWibrat = New System.Windows.Forms.Button()
        Me.RaspProvodTrosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.NameOpBegDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NameOpEndDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FazaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FazaWtor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.P4DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.P1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.P2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KwDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KgDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CosNaklonaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StrelaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgorPredDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DvertPredDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgorMinDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DvertMinDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgorDopustDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DvertDopustDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kriterij = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridViewRez, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RaspProvodTrosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridViewRez
        '
        Me.DataGridViewRez.AutoGenerateColumns = False
        Me.DataGridViewRez.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.DataGridViewRez.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewRez.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NameOpBegDataGridViewTextBoxColumn, Me.NameOpEndDataGridViewTextBoxColumn, Me.FazaDataGridViewTextBoxColumn, Me.FazaWtor, Me.P4DataGridViewTextBoxColumn, Me.P1DataGridViewTextBoxColumn, Me.P2DataGridViewTextBoxColumn, Me.KwDataGridViewTextBoxColumn, Me.KgDataGridViewTextBoxColumn, Me.CosNaklonaDataGridViewTextBoxColumn, Me.StrelaDataGridViewTextBoxColumn, Me.DgorPredDataGridViewTextBoxColumn, Me.DvertPredDataGridViewTextBoxColumn, Me.DgorMinDataGridViewTextBoxColumn, Me.DvertMinDataGridViewTextBoxColumn, Me.DgorDopustDataGridViewTextBoxColumn, Me.DvertDopustDataGridViewTextBoxColumn, Me.Kriterij})
        Me.DataGridViewRez.DataSource = Me.RaspProvodTrosBindingSource
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewRez.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewRez.Location = New System.Drawing.Point(12, 34)
        Me.DataGridViewRez.Name = "DataGridViewRez"
        Me.DataGridViewRez.RowHeadersVisible = False
        Me.DataGridViewRez.Size = New System.Drawing.Size(1288, 461)
        Me.DataGridViewRez.TabIndex = 0
        '
        'LabelUnom
        '
        Me.LabelUnom.AutoSize = True
        Me.LabelUnom.Location = New System.Drawing.Point(12, 4)
        Me.LabelUnom.Name = "LabelUnom"
        Me.LabelUnom.Size = New System.Drawing.Size(35, 13)
        Me.LabelUnom.TabIndex = 1
        Me.LabelUnom.Text = "Unom"
        '
        'LabelDel
        '
        Me.LabelDel.AutoSize = True
        Me.LabelDel.Location = New System.Drawing.Point(226, 4)
        Me.LabelDel.Name = "LabelDel"
        Me.LabelDel.Size = New System.Drawing.Size(54, 13)
        Me.LabelDel.TabIndex = 2
        Me.LabelDel.Text = "Д электр"
        '
        'ButtonWExcel
        '
        Me.ButtonWExcel.Location = New System.Drawing.Point(411, -1)
        Me.ButtonWExcel.Name = "ButtonWExcel"
        Me.ButtonWExcel.Size = New System.Drawing.Size(75, 23)
        Me.ButtonWExcel.TabIndex = 3
        Me.ButtonWExcel.Text = "Документ"
        Me.ButtonWExcel.UseVisualStyleBackColor = True
        '
        'ButtonWibrat
        '
        Me.ButtonWibrat.Location = New System.Drawing.Point(1124, -1)
        Me.ButtonWibrat.Name = "ButtonWibrat"
        Me.ButtonWibrat.Size = New System.Drawing.Size(166, 23)
        Me.ButtonWibrat.TabIndex = 4
        Me.ButtonWibrat.Text = "Выбрать нарушения"
        Me.ButtonWibrat.UseVisualStyleBackColor = True
        '
        'RaspProvodTrosBindingSource
        '
        Me.RaspProvodTrosBindingSource.DataSource = GetType(PlanDwg.RaspProvodProvod)
        Me.RaspProvodTrosBindingSource.Filter = "Kriterij < 1"
        '
        'NameOpBegDataGridViewTextBoxColumn
        '
        Me.NameOpBegDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.NameOpBegDataGridViewTextBoxColumn.DataPropertyName = "NameOpBeg"
        Me.NameOpBegDataGridViewTextBoxColumn.HeaderText = "Нач. Оп."
        Me.NameOpBegDataGridViewTextBoxColumn.Name = "NameOpBegDataGridViewTextBoxColumn"
        Me.NameOpBegDataGridViewTextBoxColumn.ReadOnly = True
        '
        'NameOpEndDataGridViewTextBoxColumn
        '
        Me.NameOpEndDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.NameOpEndDataGridViewTextBoxColumn.DataPropertyName = "NameOpEnd"
        Me.NameOpEndDataGridViewTextBoxColumn.HeaderText = "Кон. Оп"
        Me.NameOpEndDataGridViewTextBoxColumn.Name = "NameOpEndDataGridViewTextBoxColumn"
        Me.NameOpEndDataGridViewTextBoxColumn.ReadOnly = True
        Me.NameOpEndDataGridViewTextBoxColumn.Width = 80
        '
        'FazaDataGridViewTextBoxColumn
        '
        Me.FazaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.FazaDataGridViewTextBoxColumn.DataPropertyName = "Faza"
        Me.FazaDataGridViewTextBoxColumn.HeaderText = "Фаза"
        Me.FazaDataGridViewTextBoxColumn.Name = "FazaDataGridViewTextBoxColumn"
        Me.FazaDataGridViewTextBoxColumn.ReadOnly = True
        Me.FazaDataGridViewTextBoxColumn.Width = 50
        '
        'FazaWtor
        '
        Me.FazaWtor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.FazaWtor.DataPropertyName = "FazaWtor"
        Me.FazaWtor.HeaderText = "С фазой"
        Me.FazaWtor.Name = "FazaWtor"
        Me.FazaWtor.ReadOnly = True
        Me.FazaWtor.Width = 55
        '
        'P4DataGridViewTextBoxColumn
        '
        Me.P4DataGridViewTextBoxColumn.DataPropertyName = "P4"
        Me.P4DataGridViewTextBoxColumn.HeaderText = "P4"
        Me.P4DataGridViewTextBoxColumn.Name = "P4DataGridViewTextBoxColumn"
        Me.P4DataGridViewTextBoxColumn.ReadOnly = True
        Me.P4DataGridViewTextBoxColumn.Width = 45
        '
        'P1DataGridViewTextBoxColumn
        '
        Me.P1DataGridViewTextBoxColumn.DataPropertyName = "P1"
        Me.P1DataGridViewTextBoxColumn.HeaderText = "P1"
        Me.P1DataGridViewTextBoxColumn.Name = "P1DataGridViewTextBoxColumn"
        Me.P1DataGridViewTextBoxColumn.ReadOnly = True
        Me.P1DataGridViewTextBoxColumn.Width = 45
        '
        'P2DataGridViewTextBoxColumn
        '
        Me.P2DataGridViewTextBoxColumn.DataPropertyName = "P2"
        Me.P2DataGridViewTextBoxColumn.HeaderText = "P2"
        Me.P2DataGridViewTextBoxColumn.Name = "P2DataGridViewTextBoxColumn"
        Me.P2DataGridViewTextBoxColumn.ReadOnly = True
        Me.P2DataGridViewTextBoxColumn.Width = 45
        '
        'KwDataGridViewTextBoxColumn
        '
        Me.KwDataGridViewTextBoxColumn.DataPropertyName = "Kw"
        DataGridViewCellStyle1.Format = "N3"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.KwDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.KwDataGridViewTextBoxColumn.HeaderText = "Kw"
        Me.KwDataGridViewTextBoxColumn.Name = "KwDataGridViewTextBoxColumn"
        Me.KwDataGridViewTextBoxColumn.ReadOnly = True
        Me.KwDataGridViewTextBoxColumn.Width = 47
        '
        'KgDataGridViewTextBoxColumn
        '
        Me.KgDataGridViewTextBoxColumn.DataPropertyName = "Kg"
        DataGridViewCellStyle2.Format = "N3"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.KgDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.KgDataGridViewTextBoxColumn.HeaderText = "Kg"
        Me.KgDataGridViewTextBoxColumn.Name = "KgDataGridViewTextBoxColumn"
        Me.KgDataGridViewTextBoxColumn.ReadOnly = True
        Me.KgDataGridViewTextBoxColumn.Width = 45
        '
        'CosNaklonaDataGridViewTextBoxColumn
        '
        Me.CosNaklonaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.CosNaklonaDataGridViewTextBoxColumn.DataPropertyName = "CosNaklona"
        Me.CosNaklonaDataGridViewTextBoxColumn.HeaderText = "Cos(накл)"
        Me.CosNaklonaDataGridViewTextBoxColumn.Name = "CosNaklonaDataGridViewTextBoxColumn"
        Me.CosNaklonaDataGridViewTextBoxColumn.ReadOnly = True
        Me.CosNaklonaDataGridViewTextBoxColumn.Width = 70
        '
        'StrelaDataGridViewTextBoxColumn
        '
        Me.StrelaDataGridViewTextBoxColumn.DataPropertyName = "Strela"
        Me.StrelaDataGridViewTextBoxColumn.HeaderText = "Стрела"
        Me.StrelaDataGridViewTextBoxColumn.Name = "StrelaDataGridViewTextBoxColumn"
        Me.StrelaDataGridViewTextBoxColumn.ReadOnly = True
        Me.StrelaDataGridViewTextBoxColumn.Width = 68
        '
        'DgorPredDataGridViewTextBoxColumn
        '
        Me.DgorPredDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DgorPredDataGridViewTextBoxColumn.DataPropertyName = "DgorPred"
        Me.DgorPredDataGridViewTextBoxColumn.HeaderText = "Dгор"
        Me.DgorPredDataGridViewTextBoxColumn.Name = "DgorPredDataGridViewTextBoxColumn"
        Me.DgorPredDataGridViewTextBoxColumn.ReadOnly = True
        Me.DgorPredDataGridViewTextBoxColumn.Width = 50
        '
        'DvertPredDataGridViewTextBoxColumn
        '
        Me.DvertPredDataGridViewTextBoxColumn.DataPropertyName = "DvertPred"
        Me.DvertPredDataGridViewTextBoxColumn.HeaderText = "Dверт"
        Me.DvertPredDataGridViewTextBoxColumn.Name = "DvertPredDataGridViewTextBoxColumn"
        Me.DvertPredDataGridViewTextBoxColumn.ReadOnly = True
        Me.DvertPredDataGridViewTextBoxColumn.Width = 63
        '
        'DgorMinDataGridViewTextBoxColumn
        '
        Me.DgorMinDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DgorMinDataGridViewTextBoxColumn.DataPropertyName = "DgorMin"
        Me.DgorMinDataGridViewTextBoxColumn.HeaderText = "Смещ.гор.(пол. пролета)"
        Me.DgorMinDataGridViewTextBoxColumn.Name = "DgorMinDataGridViewTextBoxColumn"
        Me.DgorMinDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DvertMinDataGridViewTextBoxColumn
        '
        Me.DvertMinDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DvertMinDataGridViewTextBoxColumn.DataPropertyName = "DvertMin"
        Me.DvertMinDataGridViewTextBoxColumn.HeaderText = "Смещ.верт(пол. пролета) "
        Me.DvertMinDataGridViewTextBoxColumn.Name = "DvertMinDataGridViewTextBoxColumn"
        Me.DvertMinDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DgorDopustDataGridViewTextBoxColumn
        '
        Me.DgorDopustDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DgorDopustDataGridViewTextBoxColumn.DataPropertyName = "DgorDopust"
        Me.DgorDopustDataGridViewTextBoxColumn.HeaderText = "Смещ.гор (допуст)"
        Me.DgorDopustDataGridViewTextBoxColumn.Name = "DgorDopustDataGridViewTextBoxColumn"
        Me.DgorDopustDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DvertDopustDataGridViewTextBoxColumn
        '
        Me.DvertDopustDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DvertDopustDataGridViewTextBoxColumn.DataPropertyName = "DvertDopust"
        Me.DvertDopustDataGridViewTextBoxColumn.HeaderText = "Смещ.верт (допуст)"
        Me.DvertDopustDataGridViewTextBoxColumn.Name = "DvertDopustDataGridViewTextBoxColumn"
        Me.DvertDopustDataGridViewTextBoxColumn.ReadOnly = True
        '
        'Kriterij
        '
        Me.Kriterij.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Kriterij.DataPropertyName = "Kriterij"
        Me.Kriterij.HeaderText = "Критерий"
        Me.Kriterij.Name = "Kriterij"
        Me.Kriterij.ReadOnly = True
        Me.Kriterij.Width = 60
        '
        'FrmWiwRezRasp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1312, 524)
        Me.Controls.Add(Me.ButtonWibrat)
        Me.Controls.Add(Me.ButtonWExcel)
        Me.Controls.Add(Me.LabelDel)
        Me.Controls.Add(Me.LabelUnom)
        Me.Controls.Add(Me.DataGridViewRez)
        Me.Name = "FrmWiwRezRasp"
        Me.Text = "FrmWiwRezRasp"
        CType(Me.DataGridViewRez, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RaspProvodTrosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridViewRez As System.Windows.Forms.DataGridView
    Friend WithEvents RaspProvodTrosBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SfazojDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Public WithEvents LabelDel As System.Windows.Forms.Label
    Public WithEvents LabelUnom As System.Windows.Forms.Label
    Friend WithEvents ButtonWExcel As System.Windows.Forms.Button
    Friend WithEvents ButtonWibrat As System.Windows.Forms.Button
    Friend WithEvents NameOpBegDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NameOpEndDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FazaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FazaWtor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents P4DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents P1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents P2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KwDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KgDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CosNaklonaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StrelaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgorPredDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DvertPredDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgorMinDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DvertMinDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgorDopustDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DvertDopustDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Kriterij As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
