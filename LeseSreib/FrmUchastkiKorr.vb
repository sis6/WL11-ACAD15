Option Strict Off
Imports modRasstOp
''' <summary>
''' Форма для выбора участка. Корректирвка параметров участка
''' Корректирвка данных участка
''' </summary>
''' <remarks></remarks>
Public Class FrmUchastkiKorr
    Protected wLesUch As New List(Of modRasstOp.wlUch) 'Сохраненный список участков
    Private wOprRej As New LeseSreib.clsSreibeBD
    Private wNameIstochnik As String = "сохранять в чертеже "
    Protected Sub BindingSourceZap()
        WlUchBindingSource.Clear()

        For Each elu As modRasstOp.wlUch In wLesUch
            WlUchBindingSource.Add(elu)
        Next
    End Sub
    ReadOnly Property Uchastki As List(Of modRasstOp.wlUch)
        Get
            Return wLesUch
        End Get
    End Property

    Private Sub FrmUchastkiKorr_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        With ToolStripButtonActiveUchastok
            If .Checked = True Then
              
                If WlUchBindingSource.Position < 0 Then wLesUch(0).Rasst.OprRast() Else wLesUch(0).Rasst.OprRast(WlUchBindingSource.Position)
            Else

                wLesUch(0).Rasst.OprRast()
            End If
        End With
    End Sub
   

    Private Sub FrmUprKorr_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' HelpProviderBd.SetHelpNavigator(Me, HelpNavigator.Topic)
        ' HelpProvider1.HelpNamespace = "D:\WL_11\Help\Form\frmUprKorr.htm"
        '  HelpProvider1.SetHelpNavigator(OK_Button, HelpNavigator.TopicId)
        '   HelpProvider1.SetShowHelp(OK_Button, True)
        If wRasst IsNot Nothing Then
            For i As Integer = 0 To wRasst.Trassa.MaxNumUchTr
                wLesUch.Add(wRasst.Uch(i))
            Next
        End If
        If wRasst Is Nothing Then
            ToolStripButtonOk.Visible = False

            Return
        End If
        If wRasst.Trassa.MaxNumUchTr < 0 Then ToolStripButtonOk.Visible = False
        '  LabelPrav.Text = "kkk"
        ' HelpProvider1.SetHelpString(OK_Button, "Нажмите кнопку для сохранение изменений  модели трассы")
        'HelpProvider1.SetHelpString(ButtonKorr, "Вызов формы корректировки для выбраного участка")
        If wOprRej.RejmSowmest Then wNameIstochnik = "Сохранять состав трассы  в базе данных" Else wNameIstochnik = "Сохранять состав трассы в чертеже"
        ToolStripLabelSohran.Text = "Не " & wNameIstochnik


    End Sub

    'Корректировка данных участка
    Private Sub ToolStripButtonKorr_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButtonKorr.Click
        Me.Visible = False
        ToolStripButtonActiveUchastok.Checked = False
        Dim objform As Object            '  FrmKorr   
        Dim lMaxNumUch As Integer
        Dim luchKorr As modRasstOp.wlUch
        Select Case wdostup.Prawo   'Определяем в зависимости от прав пользователей форму в которой будет проходить корректировка 
			Case OperBD.PrawoDostup.PolzTiz
				objform = New FrmKorrProfilWlUch
                CType(objform, FrmKorrProfilWlUch).Dostup = wdostup
			Case OperBD.PrawoDostup.Admin, OperBD.PrawoDostup.PolzOve
				objform = New FrmKorrRasstWlUch
                CType(objform, FrmKorrRasstWlUch).Dostup = wdostup
            Case Else
                objform = New FrmProsmotr
        End Select



        If WlUchBindingSource.Position < 0 Then
            MsgBox("Не выбран участок")
            Return
        Else

            luchKorr = wLesUch(WlUchBindingSource.Position)
            lMaxNumUch = wLesUch.Count - 1
            'If TypeOf objform Is FrmKorrRasstWlUch Then CType(objform, FrmKorrRasstWlUch).NumerRaschetUchastok = WlUchBindingSource.Position 'определяем номер актвного  участка
            ' расстановка будет строиться только для него
        End If

        objform.IzmUch = CType(luchKorr, modRasstOp.wlUch)
        If objform.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            '  Dim lpreobr As New Sw_UchPrfDS(objform.DsProfilA, objform.IzmUch.NameUch)
            Dim lpreobr As New Sw_IzDs_Rasst(objform.DsProfilA, objform.DsRasst1, objform.ElemRasstUch1, luchKorr.NameUch)
            Dim LuchPreobr As modRasstOp.wlUch = lpreobr.RasstNaUch

            wLesUch.Item(WlUchBindingSource.Position) = LuchPreobr

        End If

        '     BindingSourceZap()
        Me.Visible = True
    End Sub
    Private Sub IzmIdentifikazii()
        If String.IsNullOrEmpty(cbUnom.Text) Then     '2

            wRasst.Trassa.IzmenitIdentifikator(tbWl.Text, tbNameRab.Text, 750)
        Else
            wRasst.Trassa.IzmenitIdentifikator(tbWl.Text, tbNameRab.Text, CInt(cbUnom.Text))
        End If                                                '2e




        ' сохранение
        Dim ll As New BazDwg.SystemKommand
        If ToolStripLabelSohran.Checked = True Then       '11




            ll.Lock()
            If wOprRej.RejmSowmest Then   '22

                '  Dim dljazapisiBD As New LeseSreib.clsLeseSreibeRasstBd(wOprRej.MassGuid)
                '   wOprRej.SchreibeWSowmest(IzmUch.Rasst, _Dostup)
                wOprRej.SchreibeWSowmestOSostawe(wRasst, wdostup)
            Else
                Dim dnDwg As New LeseSreib.clsLeseSrejbRasstDwg(KorSlDann, wRasst)
                dnDwg.SaveOSostave()
            End If      '22e
            ll.Dispose()

            BazDwg.SystemKommand.Sohr()
        End If
    End Sub
    Private Sub ToolStripButtonOk_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButtonOk.Click
        DataGridViewUch.EndEdit()
        WlUchBindingSource.EndEdit()
        ''  MsgBox(" Имя уч.  " & wLesUch(0).NameUch)
        'wRasst = Nothing
        IzmIdentifikazii()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub ToolStripButtonTipDann_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButtonTipDann.Click
        Sw_IzBD_ConstTabl.TipWxml()
        Dim lTipDs As New OperBD.Sw_TipElem()
        lTipDs.WriteXml()
    End Sub

    Private Sub ToolStripLabel2_Click(sender As Object, e As EventArgs) Handles ToolStripButtonNameWL.Click
        Dim lFrmWpf As New WpfDokOborot.WinWiborIdenUchastka
        If lFrmWpf.ShowDialog() Then
            tbWl.Text = lFrmWpf.NameWL
            If Not String.IsNullOrEmpty(lFrmWpf.Dogowor) Then
                tbNameRab.Text = lFrmWpf.Dogowor
            Else
                If String.IsNullOrEmpty(tbNameRab.Text) Then tbNameRab.Text = Me.ToString
            End If

        End If
    End Sub

   

    Private Sub ToolStripLabelSohran_Click(sender As Object, e As EventArgs) Handles ToolStripLabelSohran.Click
        With ToolStripLabelSohran
            If .Checked = True Then
                .Text = wNameIstochnik
                ToolStripLabelSohran.ForeColor = Color.Green
                '  ToolStripLabelSohran.BackColor = Color.Gold
            Else

                .Text = "Не " & wNameIstochnik
                ToolStripLabelSohran.ForeColor = Color.Black
                ToolStripLabelSohran.BackColor = Color.SeaShell
            End If
        End With


    End Sub

    Private Sub ToolStripButtonActiveUchastok_CheckedChanged(sender As Object, e As EventArgs) Handles ToolStripButtonActiveUchastok.CheckedChanged
        With ToolStripButtonActiveUchastok
            If .Checked = True Then
                .Text = "Расстановку по выбраному участку"
                .ForeColor = Color.Green
                '  ToolStripLabelSohran.BackColor = Color.Gold
                '   If WlUchBindingSource.Position < 0 Then wLesUch(0).Rasst.OprRast() Else wLesUch(0).Rasst.OprRast(WlUchBindingSource.Position)
            Else

                .Text = "Расстановку по вcем участкам "
                .ForeColor = Color.Black
                .BackColor = Color.SeaShell
                '      wLesUch(0).Rasst.OprRast()
            End If
        End With
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButtonActiveUchastok.Click
        With ToolStripButtonActiveUchastok
            'If .Checked = True Then
            '    .Text = "Расстановку по выбраному участку"
            '    .ForeColor = Color.Green
            '    '  ToolStripLabelSohran.BackColor = Color.Gold
            '    '   If WlUchBindingSource.Position < 0 Then wLesUch(0).Rasst.OprRast() Else wLesUch(0).Rasst.OprRast(WlUchBindingSource.Position)
            'Else

            '    .Text = "Расстановку по вcем участкам "
            '    .ForeColor = Color.Black
            '    .BackColor = Color.SeaShell
            '    '      wLesUch(0).Rasst.OprRast()
            'End If
        End With

    End Sub

	Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripLabel1.Click

	End Sub
End Class
