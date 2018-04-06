<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUchastkiKorr
    Inherits LeseSreib.frmUchastki

    'Форма переопределяет dispose для очистки списка компонент.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form. 
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUchastkiKorr))
		Me.ToolStripUpr = New System.Windows.Forms.ToolStrip()
		Me.ToolStripButtonNameWL = New System.Windows.Forms.ToolStripButton()
		Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
		Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
		Me.ToolStripButtonOk = New System.Windows.Forms.ToolStripButton()
		Me.ToolStripButtonTipDann = New System.Windows.Forms.ToolStripButton()
		Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
		Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
		Me.ToolStripLabelSohran = New System.Windows.Forms.ToolStripButton()
		Me.ToolStripButton1 = New System.Windows.Forms.ToolStripSeparator()
		Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
		Me.ToolStripButtonKorr = New System.Windows.Forms.ToolStripButton()
		Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSeparator()
		Me.ToolStripButtonActiveUchastok = New System.Windows.Forms.ToolStripButton()
		CType(Me.WlUchBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.ToolStripUpr.SuspendLayout()
		Me.SuspendLayout()
		'
		'ToolStripUpr
		'
		Me.ToolStripUpr.BackColor = System.Drawing.SystemColors.ControlLightLight
		Me.ToolStripUpr.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonNameWL, Me.ToolStripSeparator2, Me.ToolStripSeparator1, Me.ToolStripButtonOk, Me.ToolStripButtonTipDann, Me.ToolStripLabel1, Me.ToolStripSeparator3, Me.ToolStripLabelSohran, Me.ToolStripButton1, Me.ToolStripSeparator4, Me.ToolStripButtonKorr, Me.ToolStripSplitButton1, Me.ToolStripButtonActiveUchastok})
		Me.ToolStripUpr.Location = New System.Drawing.Point(0, 0)
		Me.ToolStripUpr.Name = "ToolStripUpr"
		Me.ToolStripUpr.Size = New System.Drawing.Size(1366, 25)
		Me.ToolStripUpr.TabIndex = 63
		Me.ToolStripUpr.Text = "ToolStrip1"
		'
		'ToolStripButtonNameWL
		'
		Me.ToolStripButtonNameWL.Image = CType(resources.GetObject("ToolStripButtonNameWL.Image"), System.Drawing.Image)
		Me.ToolStripButtonNameWL.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.ToolStripButtonNameWL.Name = "ToolStripButtonNameWL"
		Me.ToolStripButtonNameWL.Size = New System.Drawing.Size(92, 22)
		Me.ToolStripButtonNameWL.Text = "__Выбор ВЛ"
		'
		'ToolStripSeparator2
		'
		Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
		Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
		'
		'ToolStripSeparator1
		'
		Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
		Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
		'
		'ToolStripButtonOk
		'
		Me.ToolStripButtonOk.Image = CType(resources.GetObject("ToolStripButtonOk.Image"), System.Drawing.Image)
		Me.ToolStripButtonOk.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.ToolStripButtonOk.Name = "ToolStripButtonOk"
		Me.ToolStripButtonOk.Size = New System.Drawing.Size(74, 22)
		Me.ToolStripButtonOk.Text = "Принять"
		Me.ToolStripButtonOk.ToolTipText = "Нажмите эту кнопку для сохранение изменений идентификатора  модели трассы(Имя вл," &
	" работа, Uном, имя участков) "
		'
		'ToolStripButtonTipDann
		'
		Me.ToolStripButtonTipDann.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
		Me.ToolStripButtonTipDann.Image = CType(resources.GetObject("ToolStripButtonTipDann.Image"), System.Drawing.Image)
		Me.ToolStripButtonTipDann.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.ToolStripButtonTipDann.Name = "ToolStripButtonTipDann"
		Me.ToolStripButtonTipDann.Size = New System.Drawing.Size(156, 22)
		Me.ToolStripButtonTipDann.Text = "Обновить определения"
		Me.ToolStripButtonTipDann.ToolTipText = "Считывает из базы типыпересечений.угодий и сохраняет на диске как xml"
		'
		'ToolStripLabel1
		'
		Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
		Me.ToolStripLabel1.Name = "ToolStripLabel1"
		Me.ToolStripLabel1.Size = New System.Drawing.Size(107, 22)
		Me.ToolStripLabel1.Text = "Вспомогательные"
		'
		'ToolStripSeparator3
		'
		Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
		Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
		'
		'ToolStripLabelSohran
		'
		Me.ToolStripLabelSohran.BackColor = System.Drawing.Color.SeaShell
		Me.ToolStripLabelSohran.CheckOnClick = True
		Me.ToolStripLabelSohran.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
		Me.ToolStripLabelSohran.Image = CType(resources.GetObject("ToolStripLabelSohran.Image"), System.Drawing.Image)
		Me.ToolStripLabelSohran.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.ToolStripLabelSohran.Name = "ToolStripLabelSohran"
		Me.ToolStripLabelSohran.Size = New System.Drawing.Size(141, 22)
		Me.ToolStripLabelSohran.Text = "Сохранить                        "
		Me.ToolStripLabelSohran.ToolTipText = "Переключает режим сохранение параметров(имя вл, работа учпстки и т.д)  трассы"
		'
		'ToolStripButton1
		'
		Me.ToolStripButton1.Name = "ToolStripButton1"
		Me.ToolStripButton1.Size = New System.Drawing.Size(6, 25)
		'
		'ToolStripSeparator4
		'
		Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
		Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
		'
		'ToolStripButtonKorr
		'
		Me.ToolStripButtonKorr.Image = CType(resources.GetObject("ToolStripButtonKorr.Image"), System.Drawing.Image)
		Me.ToolStripButtonKorr.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.ToolStripButtonKorr.Name = "ToolStripButtonKorr"
		Me.ToolStripButtonKorr.Size = New System.Drawing.Size(227, 22)
		Me.ToolStripButtonKorr.Text = "Корректировка выбранного участка"
		Me.ToolStripButtonKorr.ToolTipText = "Вызов формы корректировки для выбраного участка"
		'
		'ToolStripSplitButton1
		'
		Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
		Me.ToolStripSplitButton1.Size = New System.Drawing.Size(6, 25)
		'
		'ToolStripButtonActiveUchastok
		'
		Me.ToolStripButtonActiveUchastok.BackColor = System.Drawing.Color.SeaShell
		Me.ToolStripButtonActiveUchastok.CheckOnClick = True
		Me.ToolStripButtonActiveUchastok.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
		Me.ToolStripButtonActiveUchastok.Image = CType(resources.GetObject("ToolStripButtonActiveUchastok.Image"), System.Drawing.Image)
		Me.ToolStripButtonActiveUchastok.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.ToolStripButtonActiveUchastok.Name = "ToolStripButtonActiveUchastok"
		Me.ToolStripButtonActiveUchastok.Size = New System.Drawing.Size(180, 22)
		Me.ToolStripButtonActiveUchastok.Text = "Расстановку по вcем участкам"
		Me.ToolStripButtonActiveUchastok.ToolTipText = "Порядок формирования модели расстановки  по опорам всех участков и ли только по о" &
	"порам выбраного "
		'
		'FrmUchastkiKorr
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.ClientSize = New System.Drawing.Size(1366, 702)
		Me.Controls.Add(Me.ToolStripUpr)
		Me.HelpProvider1.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
		Me.HelpProvider1.SetHelpString(Me, "Форма просмотра и корректировки состава трассы ")
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "FrmUchastkiKorr"
		Me.HelpProvider1.SetShowHelp(Me, True)
		Me.Text = "Параметры и состав трассы "
		Me.Controls.SetChildIndex(Me.tbWl, 0)
		Me.Controls.SetChildIndex(Me.tbNameRab, 0)
		Me.Controls.SetChildIndex(Me.cbUnom, 0)
		Me.Controls.SetChildIndex(Me.ToolStripUpr, 0)
		CType(Me.WlUchBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ToolStripUpr.ResumeLayout(False)
		Me.ToolStripUpr.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents ToolStripUpr As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSplitButton1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButtonOk As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButtonTipDann As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonNameWL As System.Windows.Forms.ToolStripButton
    Public WithEvents ToolStripLabelSohran As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButtonKorr As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButtonActiveUchastok As System.Windows.Forms.ToolStripButton

End Class
