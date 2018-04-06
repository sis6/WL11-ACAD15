<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmParam
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
		Me.lbUnom = New System.Windows.Forms.Label()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.OK_Button = New System.Windows.Forms.Button()
		Me.Mashtab = New System.Windows.Forms.ComboBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.MashtabO = New System.Windows.Forms.ComboBox()
		Me.tbPiketaj = New System.Windows.Forms.TextBox()
		Me.tbPiketajI = New System.Windows.Forms.TextBox()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.Label9 = New System.Windows.Forms.Label()
		Me.tbOtmetkaI = New System.Windows.Forms.TextBox()
		Me.tbOtmetka = New System.Windows.Forms.TextBox()
		Me.Label10 = New System.Windows.Forms.Label()
		Me.Label11 = New System.Windows.Forms.Label()
		Me.Label12 = New System.Windows.Forms.Label()
		Me.Label13 = New System.Windows.Forms.Label()
		Me.Label14 = New System.Windows.Forms.Label()
		Me.CBList = New System.Windows.Forms.ComboBox()
		Me.LabelDlina = New System.Windows.Forms.Label()
		Me.LabelMinOtm = New System.Windows.Forms.Label()
		Me.LabelMaxOtm = New System.Windows.Forms.Label()
		Me.Label15 = New System.Windows.Forms.Label()
		Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
		Me.LabelY_Zentra = New System.Windows.Forms.Label()
		Me.LabelX_Zentra = New System.Windows.Forms.Label()
		Me.Label16 = New System.Windows.Forms.Label()
		Me.Label17 = New System.Windows.Forms.Label()
		Me.LabelUnom = New System.Windows.Forms.Label()
		Me.LabelNamewl = New System.Windows.Forms.Label()
		Me.LabelNameRab = New System.Windows.Forms.Label()
		Me.Label18 = New System.Windows.Forms.Label()
		Me.Label19 = New System.Windows.Forms.Label()
		Me.Label20 = New System.Windows.Forms.Label()
		Me.ComboBoxTipGraniz = New System.Windows.Forms.ComboBox()
		Me.ComboBoxBeg = New System.Windows.Forms.ComboBox()
		Me.ComboBoxEnd = New System.Windows.Forms.ComboBox()
		Me.TextBoxBegR = New System.Windows.Forms.TextBox()
		Me.TextBoxEndR = New System.Windows.Forms.TextBox()
		Me.Label21 = New System.Windows.Forms.Label()
		Me.Label22 = New System.Windows.Forms.Label()
		Me.Label23 = New System.Windows.Forms.Label()
		Me.ComboBoxPosleZpt = New System.Windows.Forms.ComboBox()
		Me.SuspendLayout()
		'
		'lbUnom
		'
		Me.lbUnom.AutoSize = True
		Me.lbUnom.Location = New System.Drawing.Point(-1, 9)
		Me.lbUnom.Name = "lbUnom"
		Me.lbUnom.Size = New System.Drawing.Size(35, 13)
		Me.lbUnom.TabIndex = 0
		Me.lbUnom.Text = "Uном"
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(176, 9)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(22, 13)
		Me.Label1.TabIndex = 2
		Me.Label1.Text = "ВЛ"
		'
		'OK_Button
		'
		Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.OK_Button.Location = New System.Drawing.Point(993, 393)
		Me.OK_Button.Name = "OK_Button"
		Me.OK_Button.Size = New System.Drawing.Size(67, 23)
		Me.OK_Button.TabIndex = 6
		Me.OK_Button.Text = "OK"
		'
		'Mashtab
		'
		Me.Mashtab.FormattingEnabled = True
		Me.Mashtab.Items.AddRange(New Object() {"10", "50", "100", "200", "500", "1000", "2000", "5000", "10000"})
		Me.Mashtab.Location = New System.Drawing.Point(103, 80)
		Me.Mashtab.Name = "Mashtab"
		Me.Mashtab.Size = New System.Drawing.Size(112, 21)
		Me.Mashtab.TabIndex = 7
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(375, 9)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(43, 13)
		Me.Label2.TabIndex = 8
		Me.Label2.Text = "Работа"
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(2, 80)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(77, 13)
		Me.Label3.TabIndex = 9
		Me.Label3.Text = "Масштаб Гор."
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(239, 83)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(82, 13)
		Me.Label4.TabIndex = 11
		Me.Label4.Text = "Масштаб верт."
		'
		'MashtabO
		'
		Me.MashtabO.FormattingEnabled = True
		Me.MashtabO.Items.AddRange(New Object() {"10", "50", "100", "200", "250", "500", "1000", "2000", "5000", "10000"})
		Me.MashtabO.Location = New System.Drawing.Point(327, 83)
		Me.MashtabO.Name = "MashtabO"
		Me.MashtabO.Size = New System.Drawing.Size(114, 21)
		Me.MashtabO.TabIndex = 10
		'
		'tbPiketaj
		'
		Me.tbPiketaj.Location = New System.Drawing.Point(103, 182)
		Me.tbPiketaj.Name = "tbPiketaj"
		Me.tbPiketaj.Size = New System.Drawing.Size(100, 20)
		Me.tbPiketaj.TabIndex = 12
		'
		'tbPiketajI
		'
		Me.tbPiketajI.Location = New System.Drawing.Point(421, 182)
		Me.tbPiketajI.Name = "tbPiketajI"
		Me.tbPiketajI.Size = New System.Drawing.Size(100, 20)
		Me.tbPiketajI.TabIndex = 13
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Location = New System.Drawing.Point(9, 54)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(127, 13)
		Me.Label5.TabIndex = 14
		Me.Label5.Text = "Размещение в чертеже"
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Location = New System.Drawing.Point(9, 185)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(70, 13)
		Me.Label6.TabIndex = 15
		Me.Label6.Text = "Расстояние "
		'
		'Label7
		'
		Me.Label7.AutoSize = True
		Me.Label7.Location = New System.Drawing.Point(240, 185)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(164, 13)
		Me.Label7.TabIndex = 16
		Me.Label7.Text = "X в системе координат образа"
		'
		'Label8
		'
		Me.Label8.AutoSize = True
		Me.Label8.Location = New System.Drawing.Point(239, 224)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(165, 13)
		Me.Label8.TabIndex = 20
		Me.Label8.Text = "У в системе координат образа"
		'
		'Label9
		'
		Me.Label9.AutoSize = True
		Me.Label9.Location = New System.Drawing.Point(9, 221)
		Me.Label9.Name = "Label9"
		Me.Label9.Size = New System.Drawing.Size(51, 13)
		Me.Label9.TabIndex = 19
		Me.Label9.Text = "Отметка"
		'
		'tbOtmetkaI
		'
		Me.tbOtmetkaI.Location = New System.Drawing.Point(421, 224)
		Me.tbOtmetkaI.Name = "tbOtmetkaI"
		Me.tbOtmetkaI.Size = New System.Drawing.Size(100, 20)
		Me.tbOtmetkaI.TabIndex = 18
		'
		'tbOtmetka
		'
		Me.HelpProvider1.SetHelpNavigator(Me.tbOtmetka, System.Windows.Forms.HelpNavigator.Index)
		Me.tbOtmetka.Location = New System.Drawing.Point(103, 221)
		Me.tbOtmetka.Name = "tbOtmetka"
		Me.HelpProvider1.SetShowHelp(Me.tbOtmetka, True)
		Me.tbOtmetka.Size = New System.Drawing.Size(100, 20)
		Me.tbOtmetka.TabIndex = 17
		'
		'Label10
		'
		Me.Label10.AutoSize = True
		Me.Label10.Location = New System.Drawing.Point(12, 340)
		Me.Label10.Name = "Label10"
		Me.Label10.Size = New System.Drawing.Size(109, 13)
		Me.Label10.TabIndex = 21
		Me.Label10.Text = "Параметры  трассы"
		'
		'Label11
		'
		Me.Label11.AutoSize = True
		Me.Label11.Location = New System.Drawing.Point(156, 379)
		Me.Label11.Name = "Label11"
		Me.Label11.Size = New System.Drawing.Size(78, 13)
		Me.Label11.TabIndex = 25
		Me.Label11.Text = "Мин. Отметка"
		'
		'Label12
		'
		Me.Label12.AutoSize = True
		Me.Label12.Location = New System.Drawing.Point(20, 379)
		Me.Label12.Name = "Label12"
		Me.Label12.Size = New System.Drawing.Size(40, 13)
		Me.Label12.TabIndex = 23
		Me.Label12.Text = "Длина"
		'
		'Label13
		'
		Me.Label13.AutoSize = True
		Me.Label13.Location = New System.Drawing.Point(375, 379)
		Me.Label13.Name = "Label13"
		Me.Label13.Size = New System.Drawing.Size(84, 13)
		Me.Label13.TabIndex = 27
		Me.Label13.Text = "Макс. Отметка"
		'
		'Label14
		'
		Me.Label14.AutoSize = True
		Me.Label14.Location = New System.Drawing.Point(468, 88)
		Me.Label14.Name = "Label14"
		Me.Label14.Size = New System.Drawing.Size(32, 13)
		Me.Label14.TabIndex = 29
		Me.Label14.Text = "Лист"
		'
		'CBList
		'
		Me.CBList.FormattingEnabled = True
		Me.CBList.Items.AddRange(New Object() {"594", "891"})
		Me.CBList.Location = New System.Drawing.Point(524, 83)
		Me.CBList.Name = "CBList"
		Me.CBList.Size = New System.Drawing.Size(104, 21)
		Me.CBList.TabIndex = 28
		'
		'LabelDlina
		'
		Me.LabelDlina.AutoSize = True
		Me.LabelDlina.BackColor = System.Drawing.SystemColors.Window
		Me.LabelDlina.Location = New System.Drawing.Point(81, 379)
		Me.LabelDlina.Name = "LabelDlina"
		Me.LabelDlina.Size = New System.Drawing.Size(40, 13)
		Me.LabelDlina.TabIndex = 31
		Me.LabelDlina.Text = "Длина"
		'
		'LabelMinOtm
		'
		Me.LabelMinOtm.AutoSize = True
		Me.LabelMinOtm.BackColor = System.Drawing.SystemColors.Window
		Me.LabelMinOtm.Location = New System.Drawing.Point(258, 379)
		Me.LabelMinOtm.Name = "LabelMinOtm"
		Me.LabelMinOtm.Size = New System.Drawing.Size(78, 13)
		Me.LabelMinOtm.TabIndex = 32
		Me.LabelMinOtm.Text = "Мин. Отметка"
		'
		'LabelMaxOtm
		'
		Me.LabelMaxOtm.AutoSize = True
		Me.LabelMaxOtm.BackColor = System.Drawing.SystemColors.Window
		Me.LabelMaxOtm.Location = New System.Drawing.Point(493, 379)
		Me.LabelMaxOtm.Name = "LabelMaxOtm"
		Me.LabelMaxOtm.Size = New System.Drawing.Size(40, 13)
		Me.LabelMaxOtm.TabIndex = 33
		Me.LabelMaxOtm.Text = "Длина"
		'
		'Label15
		'
		Me.Label15.AutoSize = True
		Me.Label15.Location = New System.Drawing.Point(29, 130)
		Me.Label15.Name = "Label15"
		Me.Label15.Size = New System.Drawing.Size(84, 13)
		Me.Label15.TabIndex = 34
		Me.Label15.Text = "Точка профиля"
		'
		'HelpProvider1
		'
		Me.HelpProvider1.HelpNamespace = "D:\WL_11-13\Help\Form\frmParametr.htm"
		'
		'LabelY_Zentra
		'
		Me.LabelY_Zentra.AutoSize = True
		Me.LabelY_Zentra.Location = New System.Drawing.Point(630, 227)
		Me.LabelY_Zentra.Name = "LabelY_Zentra"
		Me.LabelY_Zentra.Size = New System.Drawing.Size(55, 13)
		Me.LabelY_Zentra.TabIndex = 35
		Me.LabelY_Zentra.Text = "Y.центра "
		'
		'LabelX_Zentra
		'
		Me.LabelX_Zentra.AutoSize = True
		Me.LabelX_Zentra.Location = New System.Drawing.Point(630, 189)
		Me.LabelX_Zentra.Name = "LabelX_Zentra"
		Me.LabelX_Zentra.Size = New System.Drawing.Size(55, 13)
		Me.LabelX_Zentra.TabIndex = 36
		Me.LabelX_Zentra.Text = "X. центра"
		'
		'Label16
		'
		Me.Label16.AutoSize = True
		Me.Label16.Location = New System.Drawing.Point(572, 157)
		Me.Label16.Name = "Label16"
		Me.Label16.Size = New System.Drawing.Size(181, 13)
		Me.Label16.TabIndex = 37
		Me.Label16.Text = "Центр системы координат образа"
		'
		'Label17
		'
		Me.Label17.AutoSize = True
		Me.Label17.Location = New System.Drawing.Point(112, 157)
		Me.Label17.Name = "Label17"
		Me.Label17.Size = New System.Drawing.Size(194, 13)
		Me.Label17.TabIndex = 38
		Me.Label17.Text = "Соответствие профиля и его образу "
		'
		'LabelUnom
		'
		Me.LabelUnom.AutoSize = True
		Me.LabelUnom.Location = New System.Drawing.Point(70, 9)
		Me.LabelUnom.Name = "LabelUnom"
		Me.LabelUnom.Size = New System.Drawing.Size(35, 13)
		Me.LabelUnom.TabIndex = 39
		Me.LabelUnom.Text = "Uном"
		'
		'LabelNamewl
		'
		Me.LabelNamewl.AutoSize = True
		Me.LabelNamewl.Location = New System.Drawing.Point(258, 9)
		Me.LabelNamewl.Name = "LabelNamewl"
		Me.LabelNamewl.Size = New System.Drawing.Size(22, 13)
		Me.LabelNamewl.TabIndex = 40
		Me.LabelNamewl.Text = "ВЛ"
		'
		'LabelNameRab
		'
		Me.LabelNameRab.AutoSize = True
		Me.LabelNameRab.Location = New System.Drawing.Point(514, 9)
		Me.LabelNameRab.Name = "LabelNameRab"
		Me.LabelNameRab.Size = New System.Drawing.Size(43, 13)
		Me.LabelNameRab.TabIndex = 41
		Me.LabelNameRab.Text = "Работа"
		'
		'Label18
		'
		Me.Label18.AutoSize = True
		Me.Label18.Location = New System.Drawing.Point(9, 272)
		Me.Label18.Name = "Label18"
		Me.Label18.Size = New System.Drawing.Size(64, 13)
		Me.Label18.TabIndex = 43
		Me.Label18.Text = "Тип границ"
		'
		'Label19
		'
		Me.Label19.AutoSize = True
		Me.Label19.Location = New System.Drawing.Point(236, 275)
		Me.Label19.Name = "Label19"
		Me.Label19.Size = New System.Drawing.Size(44, 13)
		Me.Label19.TabIndex = 44
		Me.Label19.Text = "Начало"
		'
		'Label20
		'
		Me.Label20.AutoSize = True
		Me.Label20.Location = New System.Drawing.Point(678, 278)
		Me.Label20.Name = "Label20"
		Me.Label20.Size = New System.Drawing.Size(38, 13)
		Me.Label20.TabIndex = 46
		Me.Label20.Text = "Конец"
		'
		'ComboBoxTipGraniz
		'
		Me.ComboBoxTipGraniz.FormattingEnabled = True
		Me.ComboBoxTipGraniz.Location = New System.Drawing.Point(94, 272)
		Me.ComboBoxTipGraniz.Name = "ComboBoxTipGraniz"
		Me.ComboBoxTipGraniz.Size = New System.Drawing.Size(104, 21)
		Me.ComboBoxTipGraniz.TabIndex = 48
		'
		'ComboBoxBeg
		'
		Me.ComboBoxBeg.FormattingEnabled = True
		Me.ComboBoxBeg.Location = New System.Drawing.Point(297, 275)
		Me.ComboBoxBeg.Name = "ComboBoxBeg"
		Me.ComboBoxBeg.Size = New System.Drawing.Size(331, 21)
		Me.ComboBoxBeg.TabIndex = 49
		'
		'ComboBoxEnd
		'
		Me.ComboBoxEnd.FormattingEnabled = True
		Me.ComboBoxEnd.Location = New System.Drawing.Point(737, 275)
		Me.ComboBoxEnd.Name = "ComboBoxEnd"
		Me.ComboBoxEnd.Size = New System.Drawing.Size(331, 21)
		Me.ComboBoxEnd.TabIndex = 50
		'
		'TextBoxBegR
		'
		Me.TextBoxBegR.Location = New System.Drawing.Point(492, 301)
		Me.TextBoxBegR.Name = "TextBoxBegR"
		Me.TextBoxBegR.Size = New System.Drawing.Size(100, 20)
		Me.TextBoxBegR.TabIndex = 51
		'
		'TextBoxEndR
		'
		Me.TextBoxEndR.Location = New System.Drawing.Point(939, 307)
		Me.TextBoxEndR.Name = "TextBoxEndR"
		Me.TextBoxEndR.Size = New System.Drawing.Size(100, 20)
		Me.TextBoxEndR.TabIndex = 52
		'
		'Label21
		'
		Me.Label21.AutoSize = True
		Me.Label21.Location = New System.Drawing.Point(396, 304)
		Me.Label21.Name = "Label21"
		Me.Label21.Size = New System.Drawing.Size(67, 13)
		Me.Label21.TabIndex = 57
		Me.Label21.Text = "Расстояние"
		'
		'Label22
		'
		Me.Label22.AutoSize = True
		Me.Label22.Location = New System.Drawing.Point(835, 315)
		Me.Label22.Name = "Label22"
		Me.Label22.Size = New System.Drawing.Size(67, 13)
		Me.Label22.TabIndex = 58
		Me.Label22.Text = "Расстояние"
		'
		'Label23
		'
		Me.Label23.AutoSize = True
		Me.Label23.Location = New System.Drawing.Point(704, 88)
		Me.Label23.Name = "Label23"
		Me.Label23.Size = New System.Drawing.Size(135, 13)
		Me.Label23.TabIndex = 60
		Me.Label23.Text = "После десятичного разд."
		'
		'ComboBoxPosleZpt
		'
		Me.ComboBoxPosleZpt.FormattingEnabled = True
		Me.ComboBoxPosleZpt.Items.AddRange(New Object() {"0", "1", "2"})
		Me.ComboBoxPosleZpt.Location = New System.Drawing.Point(869, 83)
		Me.ComboBoxPosleZpt.Name = "ComboBoxPosleZpt"
		Me.ComboBoxPosleZpt.Size = New System.Drawing.Size(75, 21)
		Me.ComboBoxPosleZpt.TabIndex = 59
		'
		'frmParam
		'
		Me.AcceptButton = Me.OK_Button
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoScroll = True
		Me.ClientSize = New System.Drawing.Size(1072, 428)
		Me.Controls.Add(Me.Label23)
		Me.Controls.Add(Me.ComboBoxPosleZpt)
		Me.Controls.Add(Me.Label22)
		Me.Controls.Add(Me.Label21)
		Me.Controls.Add(Me.TextBoxEndR)
		Me.Controls.Add(Me.TextBoxBegR)
		Me.Controls.Add(Me.ComboBoxEnd)
		Me.Controls.Add(Me.ComboBoxBeg)
		Me.Controls.Add(Me.ComboBoxTipGraniz)
		Me.Controls.Add(Me.Label20)
		Me.Controls.Add(Me.Label19)
		Me.Controls.Add(Me.Label18)
		Me.Controls.Add(Me.LabelNameRab)
		Me.Controls.Add(Me.LabelNamewl)
		Me.Controls.Add(Me.LabelUnom)
		Me.Controls.Add(Me.Label17)
		Me.Controls.Add(Me.Label16)
		Me.Controls.Add(Me.LabelX_Zentra)
		Me.Controls.Add(Me.LabelY_Zentra)
		Me.Controls.Add(Me.Label15)
		Me.Controls.Add(Me.LabelMaxOtm)
		Me.Controls.Add(Me.LabelMinOtm)
		Me.Controls.Add(Me.LabelDlina)
		Me.Controls.Add(Me.Label14)
		Me.Controls.Add(Me.CBList)
		Me.Controls.Add(Me.Label13)
		Me.Controls.Add(Me.Label11)
		Me.Controls.Add(Me.Label12)
		Me.Controls.Add(Me.Label10)
		Me.Controls.Add(Me.Label8)
		Me.Controls.Add(Me.Label9)
		Me.Controls.Add(Me.tbOtmetkaI)
		Me.Controls.Add(Me.tbOtmetka)
		Me.Controls.Add(Me.Label7)
		Me.Controls.Add(Me.Label6)
		Me.Controls.Add(Me.Label5)
		Me.Controls.Add(Me.tbPiketajI)
		Me.Controls.Add(Me.tbPiketaj)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.MashtabO)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Mashtab)
		Me.Controls.Add(Me.OK_Button)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.lbUnom)
		Me.Name = "frmParam"
		Me.Text = "Параметры вывода профиля в чертеж"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents lbUnom As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Mashtab As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MashtabO As System.Windows.Forms.ComboBox
    Friend WithEvents tbPiketaj As System.Windows.Forms.TextBox
    Friend WithEvents tbPiketajI As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tbOtmetkaI As System.Windows.Forms.TextBox
    Friend WithEvents tbOtmetka As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents CBList As System.Windows.Forms.ComboBox
    Friend WithEvents LabelDlina As System.Windows.Forms.Label
    Friend WithEvents LabelMinOtm As System.Windows.Forms.Label
    Friend WithEvents LabelMaxOtm As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents LabelY_Zentra As System.Windows.Forms.Label
    Friend WithEvents LabelX_Zentra As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents LabelUnom As System.Windows.Forms.Label
    Friend WithEvents LabelNamewl As System.Windows.Forms.Label
    Friend WithEvents LabelNameRab As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxTipGraniz As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxBeg As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxEnd As System.Windows.Forms.ComboBox
    Friend WithEvents TextBoxBegR As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxEndR As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
	Friend WithEvents Label23 As Windows.Forms.Label
	Friend WithEvents ComboBoxPosleZpt As Windows.Forms.ComboBox
End Class
