<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRastUsl
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
        Me.DataGridViewRastUsl = New System.Windows.Forms.DataGridView()
        Me.IshRejGamma = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TextBoxNameIsh = New System.Windows.Forms.TextBox()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.PrivedZent = New System.Windows.Forms.TabPage()
        Me.Provod = New System.Windows.Forms.TabPage()
        Me.Tros = New System.Windows.Forms.TabPage()
        Me.DataGridViewProvod = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTros = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NameUsl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrZentrTajDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrZentrTajTDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IshRejNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IshRejSigmaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IshRejTempDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GabRejNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GabRejGammaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GabRejSigmaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GabRejTempDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IshRejNameTDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IshRejGammaTDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IshRejSigmaTDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IshRejTempTDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GabRejNameTDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GabRejGammaTDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GabRejTempTDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UslRaschetaClsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridViewRastUsl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.PrivedZent.SuspendLayout()
        Me.Provod.SuspendLayout()
        Me.Tros.SuspendLayout()
        CType(Me.DataGridViewProvod, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewTros, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UslRaschetaClsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridViewRastUsl
        '
        Me.DataGridViewRastUsl.AllowUserToDeleteRows = False
        Me.DataGridViewRastUsl.AutoGenerateColumns = False
        Me.DataGridViewRastUsl.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.DataGridViewRastUsl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewRastUsl.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NameUsl, Me.PrZentrTajDataGridViewTextBoxColumn, Me.PrZentrTajTDataGridViewTextBoxColumn, Me.IshRejNameDataGridViewTextBoxColumn, Me.IshRejGamma, Me.IshRejSigmaDataGridViewTextBoxColumn, Me.IshRejTempDataGridViewTextBoxColumn, Me.GabRejNameDataGridViewTextBoxColumn, Me.GabRejGammaDataGridViewTextBoxColumn, Me.GabRejSigmaDataGridViewTextBoxColumn, Me.GabRejTempDataGridViewTextBoxColumn, Me.IshRejNameTDataGridViewTextBoxColumn, Me.IshRejGammaTDataGridViewTextBoxColumn, Me.IshRejSigmaTDataGridViewTextBoxColumn, Me.IshRejTempTDataGridViewTextBoxColumn, Me.GabRejNameTDataGridViewTextBoxColumn, Me.GabRejGammaTDataGridViewTextBoxColumn, Me.GabRejTempTDataGridViewTextBoxColumn})
        Me.DataGridViewRastUsl.DataSource = Me.UslRaschetaClsBindingSource
        Me.DataGridViewRastUsl.Location = New System.Drawing.Point(17, 26)
        Me.DataGridViewRastUsl.Name = "DataGridViewRastUsl"
        Me.DataGridViewRastUsl.Size = New System.Drawing.Size(1302, 333)
        Me.DataGridViewRastUsl.TabIndex = 0
        '
        'IshRejGamma
        '
        Me.IshRejGamma.DataPropertyName = "IshRejGamma"
        Me.IshRejGamma.HeaderText = "(И.Р.)Gav"
        Me.IshRejGamma.Name = "IshRejGamma"
        Me.IshRejGamma.Width = 79
        '
        'TextBoxNameIsh
        '
        Me.TextBoxNameIsh.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UslRaschetaClsBindingSource, "NameUsl", True))
        Me.TextBoxNameIsh.Location = New System.Drawing.Point(247, 12)
        Me.TextBoxNameIsh.Name = "TextBoxNameIsh"
        Me.TextBoxNameIsh.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxNameIsh.TabIndex = 1
        '
        'ButtonOK
        '
        Me.ButtonOK.Location = New System.Drawing.Point(663, 12)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(75, 23)
        Me.ButtonOK.TabIndex = 2
        Me.ButtonOK.Text = "Сохранить"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.PrivedZent)
        Me.TabControl1.Controls.Add(Me.Provod)
        Me.TabControl1.Controls.Add(Me.Tros)
        Me.TabControl1.Location = New System.Drawing.Point(12, 41)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1347, 441)
        Me.TabControl1.TabIndex = 3
        '
        'PrivedZent
        '
        Me.PrivedZent.Controls.Add(Me.DataGridViewRastUsl)
        Me.PrivedZent.Location = New System.Drawing.Point(4, 22)
        Me.PrivedZent.Name = "PrivedZent"
        Me.PrivedZent.Padding = New System.Windows.Forms.Padding(3)
        Me.PrivedZent.Size = New System.Drawing.Size(1339, 415)
        Me.PrivedZent.TabIndex = 0
        Me.PrivedZent.Text = "Приведеные центры"
        Me.PrivedZent.UseVisualStyleBackColor = True
        '
        'Provod
        '
        Me.Provod.Controls.Add(Me.DataGridViewProvod)
        Me.Provod.Location = New System.Drawing.Point(4, 22)
        Me.Provod.Name = "Provod"
        Me.Provod.Padding = New System.Windows.Forms.Padding(3)
        Me.Provod.Size = New System.Drawing.Size(1339, 415)
        Me.Provod.TabIndex = 1
        Me.Provod.Text = "Режимы провода"
        Me.Provod.UseVisualStyleBackColor = True
        '
        'Tros
        '
        Me.Tros.Controls.Add(Me.DataGridViewTros)
        Me.Tros.Location = New System.Drawing.Point(4, 22)
        Me.Tros.Name = "Tros"
        Me.Tros.Size = New System.Drawing.Size(1339, 415)
        Me.Tros.TabIndex = 2
        Me.Tros.Text = "Режимы троса"
        Me.Tros.UseVisualStyleBackColor = True
        '
        'DataGridViewProvod
        '
        Me.DataGridViewProvod.AllowUserToDeleteRows = False
        Me.DataGridViewProvod.AutoGenerateColumns = False
        Me.DataGridViewProvod.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.DataGridViewProvod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewProvod.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn11})
        Me.DataGridViewProvod.DataSource = Me.UslRaschetaClsBindingSource
        Me.DataGridViewProvod.Location = New System.Drawing.Point(25, 30)
        Me.DataGridViewProvod.Name = "DataGridViewProvod"
        Me.DataGridViewProvod.Size = New System.Drawing.Size(1003, 333)
        Me.DataGridViewProvod.TabIndex = 1
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "IshRejGamma"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Гамма"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 66
        '
        'DataGridViewTros
        '
        Me.DataGridViewTros.AllowUserToDeleteRows = False
        Me.DataGridViewTros.AutoGenerateColumns = False
        Me.DataGridViewTros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.DataGridViewTros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewTros.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn16, Me.DataGridViewTextBoxColumn17, Me.DataGridViewTextBoxColumn18, Me.DataGridViewTextBoxColumn19, Me.DataGridViewTextBoxColumn20})
        Me.DataGridViewTros.DataSource = Me.UslRaschetaClsBindingSource
        Me.DataGridViewTros.Location = New System.Drawing.Point(14, 17)
        Me.DataGridViewTros.Name = "DataGridViewTros"
        Me.DataGridViewTros.Size = New System.Drawing.Size(1003, 333)
        Me.DataGridViewTros.TabIndex = 2
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "IshRejGammaT"
        Me.DataGridViewTextBoxColumn15.HeaderText = "Гамма"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.Width = 66
        '
        'NameUsl
        '
        Me.NameUsl.DataPropertyName = "NameUsl"
        Me.NameUsl.HeaderText = "Имя"
        Me.NameUsl.Name = "NameUsl"
        Me.NameUsl.Width = 54
        '
        'PrZentrTajDataGridViewTextBoxColumn
        '
        Me.PrZentrTajDataGridViewTextBoxColumn.DataPropertyName = "PrZentrTaj"
        Me.PrZentrTajDataGridViewTextBoxColumn.HeaderText = "Ц.Т"
        Me.PrZentrTajDataGridViewTextBoxColumn.Name = "PrZentrTajDataGridViewTextBoxColumn"
        Me.PrZentrTajDataGridViewTextBoxColumn.Width = 50
        '
        'PrZentrTajTDataGridViewTextBoxColumn
        '
        Me.PrZentrTajTDataGridViewTextBoxColumn.DataPropertyName = "PrZentrTajT"
        Me.PrZentrTajTDataGridViewTextBoxColumn.HeaderText = "Ц.Ттр"
        Me.PrZentrTajTDataGridViewTextBoxColumn.Name = "PrZentrTajTDataGridViewTextBoxColumn"
        Me.PrZentrTajTDataGridViewTextBoxColumn.Width = 61
        '
        'IshRejNameDataGridViewTextBoxColumn
        '
        Me.IshRejNameDataGridViewTextBoxColumn.DataPropertyName = "IshRejName"
        Me.IshRejNameDataGridViewTextBoxColumn.HeaderText = "(И.Р)Имя"
        Me.IshRejNameDataGridViewTextBoxColumn.Name = "IshRejNameDataGridViewTextBoxColumn"
        Me.IshRejNameDataGridViewTextBoxColumn.Width = 78
        '
        'IshRejSigmaDataGridViewTextBoxColumn
        '
        Me.IshRejSigmaDataGridViewTextBoxColumn.DataPropertyName = "IshRejSigma"
        Me.IshRejSigmaDataGridViewTextBoxColumn.HeaderText = "(И.Р)Sig"
        Me.IshRejSigmaDataGridViewTextBoxColumn.Name = "IshRejSigmaDataGridViewTextBoxColumn"
        Me.IshRejSigmaDataGridViewTextBoxColumn.Width = 71
        '
        'IshRejTempDataGridViewTextBoxColumn
        '
        Me.IshRejTempDataGridViewTextBoxColumn.DataPropertyName = "IshRejTemp"
        Me.IshRejTempDataGridViewTextBoxColumn.HeaderText = "(И.Р)Т"
        Me.IshRejTempDataGridViewTextBoxColumn.Name = "IshRejTempDataGridViewTextBoxColumn"
        Me.IshRejTempDataGridViewTextBoxColumn.Width = 63
        '
        'GabRejNameDataGridViewTextBoxColumn
        '
        Me.GabRejNameDataGridViewTextBoxColumn.DataPropertyName = "GabRejName"
        Me.GabRejNameDataGridViewTextBoxColumn.HeaderText = "(Г.Р.)Имя"
        Me.GabRejNameDataGridViewTextBoxColumn.Name = "GabRejNameDataGridViewTextBoxColumn"
        Me.GabRejNameDataGridViewTextBoxColumn.Width = 79
        '
        'GabRejGammaDataGridViewTextBoxColumn
        '
        Me.GabRejGammaDataGridViewTextBoxColumn.DataPropertyName = "GabRejGamma"
        Me.GabRejGammaDataGridViewTextBoxColumn.HeaderText = "(Г.Р.)Gam"
        Me.GabRejGammaDataGridViewTextBoxColumn.Name = "GabRejGammaDataGridViewTextBoxColumn"
        Me.GabRejGammaDataGridViewTextBoxColumn.Width = 79
        '
        'GabRejSigmaDataGridViewTextBoxColumn
        '
        Me.GabRejSigmaDataGridViewTextBoxColumn.DataPropertyName = "GabRejSigma"
        Me.GabRejSigmaDataGridViewTextBoxColumn.HeaderText = "(Г.Р.)Sig"
        Me.GabRejSigmaDataGridViewTextBoxColumn.Name = "GabRejSigmaDataGridViewTextBoxColumn"
        Me.GabRejSigmaDataGridViewTextBoxColumn.Width = 72
        '
        'GabRejTempDataGridViewTextBoxColumn
        '
        Me.GabRejTempDataGridViewTextBoxColumn.DataPropertyName = "GabRejTemp"
        Me.GabRejTempDataGridViewTextBoxColumn.HeaderText = "(Г.Р.)T"
        Me.GabRejTempDataGridViewTextBoxColumn.Name = "GabRejTempDataGridViewTextBoxColumn"
        Me.GabRejTempDataGridViewTextBoxColumn.Width = 64
        '
        'IshRejNameTDataGridViewTextBoxColumn
        '
        Me.IshRejNameTDataGridViewTextBoxColumn.DataPropertyName = "IshRejNameT"
        Me.IshRejNameTDataGridViewTextBoxColumn.HeaderText = "(И.Р)ИмяT"
        Me.IshRejNameTDataGridViewTextBoxColumn.Name = "IshRejNameTDataGridViewTextBoxColumn"
        Me.IshRejNameTDataGridViewTextBoxColumn.Width = 85
        '
        'IshRejGammaTDataGridViewTextBoxColumn
        '
        Me.IshRejGammaTDataGridViewTextBoxColumn.DataPropertyName = "IshRejGammaT"
        Me.IshRejGammaTDataGridViewTextBoxColumn.HeaderText = "(И.Р)GamT"
        Me.IshRejGammaTDataGridViewTextBoxColumn.Name = "IshRejGammaTDataGridViewTextBoxColumn"
        Me.IshRejGammaTDataGridViewTextBoxColumn.Width = 85
        '
        'IshRejSigmaTDataGridViewTextBoxColumn
        '
        Me.IshRejSigmaTDataGridViewTextBoxColumn.DataPropertyName = "IshRejSigmaT"
        Me.IshRejSigmaTDataGridViewTextBoxColumn.HeaderText = "(И.Р)SigT"
        Me.IshRejSigmaTDataGridViewTextBoxColumn.Name = "IshRejSigmaTDataGridViewTextBoxColumn"
        Me.IshRejSigmaTDataGridViewTextBoxColumn.Width = 78
        '
        'IshRejTempTDataGridViewTextBoxColumn
        '
        Me.IshRejTempTDataGridViewTextBoxColumn.DataPropertyName = "IshRejTempT"
        Me.IshRejTempTDataGridViewTextBoxColumn.HeaderText = "(И.Р)TT"
        Me.IshRejTempTDataGridViewTextBoxColumn.Name = "IshRejTempTDataGridViewTextBoxColumn"
        Me.IshRejTempTDataGridViewTextBoxColumn.Width = 70
        '
        'GabRejNameTDataGridViewTextBoxColumn
        '
        Me.GabRejNameTDataGridViewTextBoxColumn.DataPropertyName = "GabRejNameT"
        Me.GabRejNameTDataGridViewTextBoxColumn.HeaderText = "(Г.Р.)ИМяT"
        Me.GabRejNameTDataGridViewTextBoxColumn.Name = "GabRejNameTDataGridViewTextBoxColumn"
        Me.GabRejNameTDataGridViewTextBoxColumn.Width = 87
        '
        'GabRejGammaTDataGridViewTextBoxColumn
        '
        Me.GabRejGammaTDataGridViewTextBoxColumn.DataPropertyName = "GabRejGammaT"
        Me.GabRejGammaTDataGridViewTextBoxColumn.HeaderText = "(Г.Р.)GamT"
        Me.GabRejGammaTDataGridViewTextBoxColumn.Name = "GabRejGammaTDataGridViewTextBoxColumn"
        Me.GabRejGammaTDataGridViewTextBoxColumn.Width = 86
        '
        'GabRejTempTDataGridViewTextBoxColumn
        '
        Me.GabRejTempTDataGridViewTextBoxColumn.DataPropertyName = "GabRejTempT"
        Me.GabRejTempTDataGridViewTextBoxColumn.HeaderText = "(Г.Р.)TT"
        Me.GabRejTempTDataGridViewTextBoxColumn.Name = "GabRejTempTDataGridViewTextBoxColumn"
        Me.GabRejTempTDataGridViewTextBoxColumn.Width = 71
        '
        'UslRaschetaClsBindingSource
        '
        Me.UslRaschetaClsBindingSource.DataSource = GetType(LeseSreib.UslRaschetaCls)
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "NameUsl"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Имя"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 54
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "PrZentrTaj"
        Me.DataGridViewTextBoxColumn2.HeaderText = "центр тяжести провода"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 138
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "PrZentrTajT"
        Me.DataGridViewTextBoxColumn3.HeaderText = "центр тяжести троса"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 126
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "IshRejName"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Исходный режим"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 110
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "IshRejSigma"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Сигма"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 64
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "IshRejTemp"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Температура"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 99
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "GabRejName"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Габаритный режим"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 119
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "GabRejGamma"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Гамма"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Width = 66
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "GabRejTemp"
        Me.DataGridViewTextBoxColumn11.HeaderText = "Температура"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Width = 99
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "NameUsl"
        Me.DataGridViewTextBoxColumn10.HeaderText = "Имя"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Width = 54
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "PrZentrTaj"
        Me.DataGridViewTextBoxColumn12.HeaderText = "центр тяжести провода"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Width = 138
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "PrZentrTajT"
        Me.DataGridViewTextBoxColumn13.HeaderText = "центр тяжести троса"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.Width = 126
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "IshRejNameT"
        Me.DataGridViewTextBoxColumn14.HeaderText = "Исходный режим"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.Width = 110
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "IshRejSigmaT"
        Me.DataGridViewTextBoxColumn16.HeaderText = "Сигма"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.Width = 64
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "IshRejTempT"
        Me.DataGridViewTextBoxColumn17.HeaderText = "Температура"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.Width = 99
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "GabRejNameT"
        Me.DataGridViewTextBoxColumn18.HeaderText = "Габаритный режим"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.Width = 119
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "GabRejGammaT"
        Me.DataGridViewTextBoxColumn19.HeaderText = "Гамма"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.Width = 66
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "GabRejTempT"
        Me.DataGridViewTextBoxColumn20.HeaderText = "Температура"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.Width = 99
        '
        'FrmRastUsl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1371, 511)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.TextBoxNameIsh)
        Me.Name = "FrmRastUsl"
        Me.Text = "Заданые расчетные условия"
        CType(Me.DataGridViewRastUsl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.PrivedZent.ResumeLayout(False)
        Me.Provod.ResumeLayout(False)
        Me.Tros.ResumeLayout(False)
        CType(Me.DataGridViewProvod, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewTros, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UslRaschetaClsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridViewRastUsl As System.Windows.Forms.DataGridView
    Friend WithEvents UslRaschetaClsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents NameUsl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrZentrTajDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrZentrTajTDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IshRejNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IshRejGamma As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IshRejSigmaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IshRejTempDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GabRejNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GabRejGammaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GabRejSigmaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GabRejTempDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IshRejNameTDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IshRejGammaTDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IshRejSigmaTDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IshRejTempTDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GabRejNameTDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GabRejGammaTDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GabRejTempTDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TextBoxNameIsh As System.Windows.Forms.TextBox
    Friend WithEvents ButtonOK As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents PrivedZent As System.Windows.Forms.TabPage
    Friend WithEvents Provod As System.Windows.Forms.TabPage
    Friend WithEvents DataGridViewProvod As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tros As System.Windows.Forms.TabPage
    Friend WithEvents DataGridViewTros As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
