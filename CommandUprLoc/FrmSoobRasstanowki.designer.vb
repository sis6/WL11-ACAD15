<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSoobRasstanowki
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
        Me.LabelTekStrok = New System.Windows.Forms.Label()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.LabelKolwoStrok = New System.Windows.Forms.Label()
        Me.LabelNameAnk = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LabelTekStrok
        '
        Me.LabelTekStrok.AutoSize = True
        Me.LabelTekStrok.Location = New System.Drawing.Point(28, 84)
        Me.LabelTekStrok.Name = "LabelTekStrok"
        Me.LabelTekStrok.Size = New System.Drawing.Size(62, 13)
        Me.LabelTekStrok.TabIndex = 0
        Me.LabelTekStrok.Text = "тек строка"
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(31, 44)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(210, 23)
        Me.ProgressBar.TabIndex = 1
        '
        'LabelKolwoStrok
        '
        Me.LabelKolwoStrok.AutoSize = True
        Me.LabelKolwoStrok.Location = New System.Drawing.Point(109, 84)
        Me.LabelKolwoStrok.Name = "LabelKolwoStrok"
        Me.LabelKolwoStrok.Size = New System.Drawing.Size(76, 13)
        Me.LabelKolwoStrok.TabIndex = 2
        Me.LabelKolwoStrok.Text = "Колво строка"
        '
        'LabelNameAnk
        '
        Me.LabelNameAnk.AutoSize = True
        Me.LabelNameAnk.Location = New System.Drawing.Point(43, 9)
        Me.LabelNameAnk.Name = "LabelNameAnk"
        Me.LabelNameAnk.Size = New System.Drawing.Size(62, 13)
        Me.LabelNameAnk.TabIndex = 3
        Me.LabelNameAnk.Text = "Имя анкер"
        '
        'FrmSoobRasstanowki
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(323, 117)
        Me.Controls.Add(Me.LabelNameAnk)
        Me.Controls.Add(Me.LabelKolwoStrok)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.LabelTekStrok)
        Me.KeyPreview = True
        Me.Name = "FrmSoobRasstanowki"
        Me.Text = "Расчет и оформоление документа"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelTekStrok As System.Windows.Forms.Label
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents LabelKolwoStrok As System.Windows.Forms.Label
    Friend WithEvents LabelNameAnk As System.Windows.Forms.Label
End Class
