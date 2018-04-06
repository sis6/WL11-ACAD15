<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmParamPln
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
        Me.Mashtab = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbXdwg = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbYdwg = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbUgol = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.mtbStrUgl = New System.Windows.Forms.MaskedTextBox()
        Me.btWibor = New System.Windows.Forms.Button()
        Me.BtOK = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbXreal = New System.Windows.Forms.TextBox()
        Me.TbYreal = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.ButtonWiborUgla = New System.Windows.Forms.Button()
        Me.ButtonWiborBegTchk = New System.Windows.Forms.Button()
        Me.UnomLabel = New System.Windows.Forms.Label()
        Me.ShirKosogoraLabel = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Mashtab
        '
        Me.Mashtab.FormattingEnabled = True
        Me.Mashtab.Items.AddRange(New Object() {"10", "50", "100", "200", "500", "1000", "2000", "5000", "10000"})
        Me.Mashtab.Location = New System.Drawing.Point(104, 252)
        Me.Mashtab.Name = "Mashtab"
        Me.Mashtab.Size = New System.Drawing.Size(121, 21)
        Me.Mashtab.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 252)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Масштаб "
        '
        'tbXdwg
        '
        Me.tbXdwg.Location = New System.Drawing.Point(233, 175)
        Me.tbXdwg.Name = "tbXdwg"
        Me.tbXdwg.Size = New System.Drawing.Size(100, 20)
        Me.tbXdwg.TabIndex = 28
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 178)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 13)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "Координата X"
        '
        'tbYdwg
        '
        Me.tbYdwg.Location = New System.Drawing.Point(233, 211)
        Me.tbYdwg.Name = "tbYdwg"
        Me.tbYdwg.Size = New System.Drawing.Size(100, 20)
        Me.tbYdwg.TabIndex = 30
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 214)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 13)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "Координата Y"
        '
        'tbUgol
        '
        Me.tbUgol.Location = New System.Drawing.Point(104, 97)
        Me.tbUgol.Name = "tbUgol"
        Me.tbUgol.Size = New System.Drawing.Size(100, 20)
        Me.tbUgol.TabIndex = 32
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(7, 100)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 13)
        Me.Label11.TabIndex = 33
        Me.Label11.Text = "Угол поворота"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(155, 13)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Положение  начальной точки"
        '
        'mtbStrUgl
        '
        Me.mtbStrUgl.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.mtbStrUgl.Location = New System.Drawing.Point(224, 97)
        Me.mtbStrUgl.Mask = "L999\°99'99"
        Me.mtbStrUgl.Name = "mtbStrUgl"
        Me.mtbStrUgl.Size = New System.Drawing.Size(100, 20)
        Me.mtbStrUgl.TabIndex = 35
        '
        'btWibor
        '
        Me.HelpProvider1.SetHelpString(Me.btWibor, "указанием двух точек выбираем начало направление и  трассы ВЛ. ")
        Me.btWibor.Location = New System.Drawing.Point(9, 349)
        Me.btWibor.Name = "btWibor"
        Me.HelpProvider1.SetShowHelp(Me.btWibor, True)
        Me.btWibor.Size = New System.Drawing.Size(195, 23)
        Me.btWibor.TabIndex = 36
        Me.btWibor.Text = "Выбор начала угла поворота ВЛ"
        Me.btWibor.UseVisualStyleBackColor = True
        '
        'BtOK
        '
        Me.BtOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtOK.Location = New System.Drawing.Point(332, 451)
        Me.BtOK.Name = "BtOK"
        Me.BtOK.Size = New System.Drawing.Size(75, 23)
        Me.BtOK.TabIndex = 37
        Me.BtOK.Text = "ОК"
        Me.BtOK.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(165, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Ширина косогора"
        '
        'tbXreal
        '
        Me.tbXreal.Location = New System.Drawing.Point(104, 171)
        Me.tbXreal.Name = "tbXreal"
        Me.tbXreal.Size = New System.Drawing.Size(100, 20)
        Me.tbXreal.TabIndex = 40
        '
        'TbYreal
        '
        Me.TbYreal.Location = New System.Drawing.Point(104, 207)
        Me.TbYreal.Name = "TbYreal"
        Me.TbYreal.Size = New System.Drawing.Size(100, 20)
        Me.TbYreal.TabIndex = 41
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(101, 142)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "На местности"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(230, 142)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "На чертеже"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "Uном"
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "D:\WL_11\Help\Form\frmParamPln.htm"
        '
        'ButtonWiborUgla
        '
        Me.HelpProvider1.SetHelpString(Me.ButtonWiborUgla, "Указанием двух точек выбираем направление трасы вл. Первая точка у начала ВЛ")
        Me.ButtonWiborUgla.Location = New System.Drawing.Point(8, 378)
        Me.ButtonWiborUgla.Name = "ButtonWiborUgla"
        Me.HelpProvider1.SetShowHelp(Me.ButtonWiborUgla, True)
        Me.ButtonWiborUgla.Size = New System.Drawing.Size(195, 23)
        Me.ButtonWiborUgla.TabIndex = 51
        Me.ButtonWiborUgla.Text = "Выбор только угла поворота ВЛ"
        Me.ButtonWiborUgla.UseVisualStyleBackColor = True
        '
        'ButtonWiborBegTchk
        '
        Me.HelpProvider1.SetHelpString(Me.ButtonWiborBegTchk, " Указывкм точку начала ВЛ ")
        Me.ButtonWiborBegTchk.Location = New System.Drawing.Point(8, 420)
        Me.ButtonWiborBegTchk.Name = "ButtonWiborBegTchk"
        Me.HelpProvider1.SetShowHelp(Me.ButtonWiborBegTchk, True)
        Me.ButtonWiborBegTchk.Size = New System.Drawing.Size(194, 23)
        Me.ButtonWiborBegTchk.TabIndex = 52
        Me.ButtonWiborBegTchk.Text = "Выбор только начала ВЛ"
        Me.ButtonWiborBegTchk.UseVisualStyleBackColor = True
        '
        'UnomLabel
        '
        Me.UnomLabel.AutoSize = True
        Me.UnomLabel.Location = New System.Drawing.Point(64, 9)
        Me.UnomLabel.Name = "UnomLabel"
        Me.UnomLabel.Size = New System.Drawing.Size(39, 13)
        Me.UnomLabel.TabIndex = 46
        Me.UnomLabel.Text = "Label9"
        '
        'ShirKosogoraLabel
        '
        Me.ShirKosogoraLabel.AutoSize = True
        Me.ShirKosogoraLabel.Location = New System.Drawing.Point(279, 9)
        Me.ShirKosogoraLabel.Name = "ShirKosogoraLabel"
        Me.ShirKosogoraLabel.Size = New System.Drawing.Size(45, 13)
        Me.ShirKosogoraLabel.TabIndex = 47
        Me.ShirKosogoraLabel.Text = "Label10"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(116, 81)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 13)
        Me.Label9.TabIndex = 48
        Me.Label9.Text = "В радианах"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(243, 81)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 13)
        Me.Label10.TabIndex = 49
        Me.Label10.Text = "В градусах"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 307)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(164, 39)
        Me.Label12.TabIndex = 50
        Me.Label12.Text = "Укажите точку начала ВЛ" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " и точку на первом пролете ВЛ" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "для указания направления"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(7, 404)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(138, 13)
        Me.Label13.TabIndex = 53
        Me.Label13.Text = "Укажите точку начала ВЛ"
        '
        'FrmParamPln
        '
        Me.AcceptButton = Me.BtOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(419, 486)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.ButtonWiborBegTchk)
        Me.Controls.Add(Me.ButtonWiborUgla)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ShirKosogoraLabel)
        Me.Controls.Add(Me.UnomLabel)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TbYreal)
        Me.Controls.Add(Me.tbXreal)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtOK)
        Me.Controls.Add(Me.btWibor)
        Me.Controls.Add(Me.mtbStrUgl)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.tbUgol)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.tbYdwg)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tbXdwg)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Mashtab)
        Me.HelpButton = True
        Me.HelpProvider1.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmParamPln"
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.Text = "Параметры отображения плана"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents mtbStrUgl As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btWibor As System.Windows.Forms.Button
    Friend WithEvents BtOK As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents Mashtab As System.Windows.Forms.ComboBox
    Public WithEvents tbXdwg As System.Windows.Forms.TextBox
    Public WithEvents tbYdwg As System.Windows.Forms.TextBox
    Public WithEvents tbUgol As System.Windows.Forms.TextBox
    Public WithEvents tbXreal As System.Windows.Forms.TextBox
    Public WithEvents TbYreal As System.Windows.Forms.TextBox
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents UnomLabel As System.Windows.Forms.Label
    Friend WithEvents ShirKosogoraLabel As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ButtonWiborUgla As System.Windows.Forms.Button
    Friend WithEvents ButtonWiborBegTchk As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
