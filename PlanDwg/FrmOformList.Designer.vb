<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOformList
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
        Me.ComboBoxSloj = New System.Windows.Forms.ComboBox()
        Me.ComboBoxList = New System.Windows.Forms.ComboBox()
        Me.ComboBoxBlock = New System.Windows.Forms.ComboBox()
        Me.ComboBoxAttribut = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ButtonОК = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboBoxMashtabPlanDetO = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'ComboBoxSloj
        '
        Me.ComboBoxSloj.FormattingEnabled = True
        Me.ComboBoxSloj.Location = New System.Drawing.Point(105, 12)
        Me.ComboBoxSloj.Name = "ComboBoxSloj"
        Me.ComboBoxSloj.Size = New System.Drawing.Size(198, 21)
        Me.ComboBoxSloj.TabIndex = 0
        '
        'ComboBoxList
        '
        Me.ComboBoxList.FormattingEnabled = True
        Me.ComboBoxList.Location = New System.Drawing.Point(105, 39)
        Me.ComboBoxList.Name = "ComboBoxList"
        Me.ComboBoxList.Size = New System.Drawing.Size(198, 21)
        Me.ComboBoxList.TabIndex = 1
        '
        'ComboBoxBlock
        '
        Me.ComboBoxBlock.FormattingEnabled = True
        Me.ComboBoxBlock.Location = New System.Drawing.Point(105, 77)
        Me.ComboBoxBlock.Name = "ComboBoxBlock"
        Me.ComboBoxBlock.Size = New System.Drawing.Size(198, 21)
        Me.ComboBoxBlock.TabIndex = 2
        '
        'ComboBoxAttribut
        '
        Me.ComboBoxAttribut.FormattingEnabled = True
        Me.ComboBoxAttribut.Location = New System.Drawing.Point(183, 150)
        Me.ComboBoxAttribut.Name = "ComboBoxAttribut"
        Me.ComboBoxAttribut.Size = New System.Drawing.Size(198, 21)
        Me.ComboBoxAttribut.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Слой"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Лист"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Блок"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(102, 119)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Атрибут блока"
        '
        'ButtonОК
        '
        Me.ButtonОК.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ButtonОК.Location = New System.Drawing.Point(306, 311)
        Me.ButtonОК.Name = "ButtonОК"
        Me.ButtonОК.Size = New System.Drawing.Size(75, 23)
        Me.ButtonОК.TabIndex = 8
        Me.ButtonОК.Text = "ОК"
        Me.ButtonОК.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 219)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(145, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Масштаб плановой детали."
        '
        'ComboBoxMashtabPlanDetO
        '
        Me.ComboBoxMashtabPlanDetO.FormattingEnabled = True
        Me.ComboBoxMashtabPlanDetO.Items.AddRange(New Object() {"10", "50", "100", "200", "500", "1000", "2000", "5000", "10000"})
        Me.ComboBoxMashtabPlanDetO.Location = New System.Drawing.Point(183, 216)
        Me.ComboBoxMashtabPlanDetO.Name = "ComboBoxMashtabPlanDetO"
        Me.ComboBoxMashtabPlanDetO.Size = New System.Drawing.Size(114, 21)
        Me.ComboBoxMashtabPlanDetO.TabIndex = 12
        '
        'FrmOformList
        '
        Me.AcceptButton = Me.ButtonОК
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(409, 361)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ComboBoxMashtabPlanDetO)
        Me.Controls.Add(Me.ButtonОК)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBoxAttribut)
        Me.Controls.Add(Me.ComboBoxBlock)
        Me.Controls.Add(Me.ComboBoxList)
        Me.Controls.Add(Me.ComboBoxSloj)
        Me.Name = "FrmOformList"
        Me.Text = "Параметры оформления листа"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboBoxSloj As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxList As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxBlock As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxAttribut As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ButtonОК As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxMashtabPlanDetO As System.Windows.Forms.ComboBox
End Class
