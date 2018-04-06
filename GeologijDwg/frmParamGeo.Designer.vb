<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmParamGeo
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
        Me.Mashtab = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.LabelNameRab = New System.Windows.Forms.Label()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.ComboBoxLauerIGE = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboBoxLayerSkwajn = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboBoxlayerNameIGE = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Mashtab
        '
        Me.Mashtab.FormattingEnabled = True
        Me.Mashtab.Items.AddRange(New Object() {"10", "50", "100", "200", "500", "1000", "2000", "5000", "10000"})
        Me.Mashtab.Location = New System.Drawing.Point(131, 77)
        Me.Mashtab.Name = "Mashtab"
        Me.Mashtab.Size = New System.Drawing.Size(112, 21)
        Me.Mashtab.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(2, 9)
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
        Me.Label3.Size = New System.Drawing.Size(103, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Масштаб Геологии"
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "D:\WL_11-13\Help\Form\frmParametr.htm"
        '
        'LabelNameRab
        '
        Me.LabelNameRab.AutoSize = True
        Me.LabelNameRab.Location = New System.Drawing.Point(128, 9)
        Me.LabelNameRab.Name = "LabelNameRab"
        Me.LabelNameRab.Size = New System.Drawing.Size(43, 13)
        Me.LabelNameRab.TabIndex = 41
        Me.LabelNameRab.Text = "Работа"
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OK_Button.Location = New System.Drawing.Point(785, 395)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 42
        Me.OK_Button.Text = "OK"
        '
        'ComboBoxLauerIGE
        '
        Me.ComboBoxLauerIGE.FormattingEnabled = True
        Me.ComboBoxLauerIGE.Location = New System.Drawing.Point(276, 122)
        Me.ComboBoxLauerIGE.Name = "ComboBoxLauerIGE"
        Me.ComboBoxLauerIGE.Size = New System.Drawing.Size(945, 21)
        Me.ComboBoxLauerIGE.TabIndex = 43
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 125)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 13)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Слой_Штриховок"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(2, 163)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 13)
        Me.Label4.TabIndex = 46
        Me.Label4.Text = "Слой_Скважин"
        '
        'ComboBoxLayerSkwajn
        '
        Me.ComboBoxLayerSkwajn.FormattingEnabled = True
        Me.ComboBoxLayerSkwajn.Location = New System.Drawing.Point(276, 160)
        Me.ComboBoxLayerSkwajn.Name = "ComboBoxLayerSkwajn"
        Me.ComboBoxLayerSkwajn.Size = New System.Drawing.Size(945, 21)
        Me.ComboBoxLayerSkwajn.TabIndex = 45
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(2, 199)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(268, 13)
        Me.Label5.TabIndex = 48
        Me.Label5.Text = "Слой_условных обозначений( Имя ИГЭ, Скважины)"
        '
        'ComboBoxlayerNameIGE
        '
        Me.ComboBoxlayerNameIGE.FormattingEnabled = True
        Me.ComboBoxlayerNameIGE.Location = New System.Drawing.Point(276, 212)
        Me.ComboBoxlayerNameIGE.Name = "ComboBoxlayerNameIGE"
        Me.ComboBoxlayerNameIGE.Size = New System.Drawing.Size(945, 21)
        Me.ComboBoxlayerNameIGE.TabIndex = 47
        '
        'frmParamGeo
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1252, 446)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ComboBoxlayerNameIGE)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ComboBoxLayerSkwajn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBoxLauerIGE)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.LabelNameRab)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Mashtab)
        Me.Name = "frmParamGeo"
        Me.Text = "Параметры отражения геологических данных"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Mashtab As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents LabelNameRab As System.Windows.Forms.Label
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents ComboBoxLauerIGE As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxLayerSkwajn As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxlayerNameIGE As System.Windows.Forms.ComboBox
End Class
