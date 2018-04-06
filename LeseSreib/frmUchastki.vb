Option Strict On
Option Explicit On
Option Compare Text
Public Class frmUchastki


    Private wTrassa As clsPrf.clsTrass
    Protected wRasst As modRasstOp.wlRasst
    Protected wdostup As New OperBD.dostup
    ''' <summary>
    ''' Задание полной модели расстановки
    ''' </summary>
    ''' <value>рсстановка с которой надо произвести действия  </value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Rasst() As modRasstOp.wlRasst
        Get
            Return wRasst
        End Get
        Set(ByVal value As modRasstOp.wlRasst)
            If value IsNot Nothing Then
                wRasst = value
                wTrassa = wRasst.Trassa
                cbUnom.Text = CStr(wTrassa.Unom)
                    tbWl.Text = wTrassa.NameLin
                tbNameRab.Text = wTrassa.NameRab

            End If

        End Set
    End Property
    Private Sub frmUchastki_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LabelImja.Text = My.User.Name
        LabelPrav.Text = wdostup.ImajPolzBD
        If wRasst IsNot Nothing Then
            LabelrDataSohr.Text = wRasst.DataSohr
            LabelrPolzSohr.Text = wRasst.PolzSohr
        End If

        If Not wTrassa Is Nothing Then

            With wTrassa

                LabelDlina.Text = Format(.Dlina, "#.##")
                LabelMinOtm.Text = Format(.MinOtmetka, "#.##")
                LabelMaxOtm.Text = Format(.MaxOtmetka, "#.##")
                LabelpDataSohr.Text = .DataSohr
                LabelpPolzSohr.Text = .PolzSohr
                For Each elu As modRasstOp.wlUch In .Uchastki
                    WlUchBindingSource.Add(elu)
                Next


            End With
        End If


        HelpProvider1.SetHelpNavigator(Me, HelpNavigator.Topic)
    End Sub

    Private Sub btSohr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSohr.Click
        'Autodesk.AutoCAD.Windows.OpenFileDialog("Cохранить в файле", CStr(lbSpUchasnkow.SelectedItem), "xls;xlt;xlsx", "dialname", Autodesk.AutoCAD.Windows.OpenFileDialog.OpenFileDialogFlags.AllowAnyExtension)
        If WlUchBindingSource.Position < 0 Then
            MsgBox("Не выбран участок")
            Return
        Else
            wTrassa.NumUch = WlUchBindingSource.Position
        End If
        Dim DialDlaSohr As New SaveFileDialog
        Dim wibrFile As String = ""
        'DialDlaSohr. 
        DialDlaSohr.Filter = "Excel файлы (*.xls)|*.xls|All files (*.*)|*.*"
        DialDlaSohr.RestoreDirectory = True
        LeseSreib.clsSwExel.frmSoob = New LeseSreib.frmSoob
        If DialDlaSohr.ShowDialog = Windows.Forms.DialogResult.OK Then
            wibrFile = DialDlaSohr.FileName
        End If
        MsgBox("Выбрано " & wibrFile)
        If wibrFile <> "" Then
            Dim www As New LeseSreib.Sw_UchPrfExel(wibrFile, CType(wTrassa.UchTr, modRasstOp.wlUch), wTrassa.NameLin, wTrassa.Unom)
            www.UchastokW_Exel()
            www.Save()
            MsgBox(www.NameFile)
            '     www.Quit()

        End If
    End Sub
    Private Sub BtSohrPoshablon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSohrPoshablon.Click
        If WlUchBindingSource.Position < 0 Then
            MsgBox("Не выбран участок")
            Return
        Else
            wTrassa.NumUch = WlUchBindingSource.Position
        End If
		Dim lExcApp As New Microsoft.Office.Interop.Excel.Application

		Dim lbooks As Microsoft.Office.Interop.Excel.Workbook = lExcApp.Workbooks.Add(My.Settings.BasePapka & "\DANN" & "\shablonWL11.xltx")
		'	lExcApp.Visible = True
		'Dim lshets As Microsoft.Office.Interop.Excel.Worksheet = CType(ExcApp.ActiveSheet, Microsoft.Office.Interop.Excel.Worksheet)    'CType(lbooks.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
		' lExcApp.Visible = True
		Dim LwlUch As New LeseSreib.Sw_UchPrfExel(lbooks, CType(wTrassa.UchTr, modRasstOp.wlUch), wTrassa.NameLin, wTrassa.Unom)
        LwlUch.UchastokW_Exel()
        lExcApp.Visible = True
    End Sub
    Private Sub BtProsmotr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtProsmotr.Click

        Dim objform As New modRasstOp.FrmProsmotr
        objform.RasstNaTrasse = wRasst
        objform.Show()

    End Sub
    Private Sub BtProsmotrUch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtProsmotrUch.Click
        Dim objform As New FrmKorrRasstWlUch
        With objform
            objform.Text = "Просмотр  данных данных"
            objform.BackColor = Color.Aqua


            objform.TextBoxNachNum.Visible = False
            .ButtonPerenum.Visible = False




            objform.ToolStripButtonAllOk.Visible = False

            For Each cntr As Control In .Controls
                If TypeOf cntr Is TabControl Then
                    For Each lpag As TabPage In CType(cntr, TabControl).TabPages
                        For Each cntr1 As Control In lpag.Controls
                            If TypeOf cntr1 Is DataGridView Then
                                Dim ldgv As DataGridView = CType(cntr1, DataGridView)
                                ldgv.ReadOnly = True
                                ldgv.AllowUserToAddRows = False
                                ldgv.AllowUserToDeleteRows = False
                            End If
                        Next
                    Next


                End If

            Next
        End With
        If WlUchBindingSource.Position < 0 Then
            MsgBox("Не выбран участок")
            Return
        Else
            wTrassa.NumUch = WlUchBindingSource.Position
        End If
        objform.IzmUch = CType(wTrassa.UchTr, modRasstOp.wlUch)
        objform.Show()


    End Sub

    Private Sub KnopkiBtDostup(ByVal iStEnable As Boolean)
        For Each el As Control In Me.Controls
            If el.Name Like "bt*" Then
                el.Enabled = iStEnable
            End If
        Next
    End Sub
    Private Sub WlUchBindingSource_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WlUchBindingSource.CurrentChanged
        If wRasst Is Nothing OrElse wRasst.Trassa.MaxNumUchTr < WlUchBindingSource.Position Then
            MsgBox(Me.ToString & "frmuchastki.WlUchBindingSource_CurrentChanged   участок не включен в расстановку")
            KnopkiBtDostup(False)
        Else
            'If wRasst.Trassa.MaxNumUchTr < WlUchBindingSource.Position Then
            '    MsgBox(Me.ToString & "frmuchastki.WlUchBindingSource_CurrentChanged  участок не включен в расстановку")
            KnopkiBtDostup(True)
            'End If
        End If
        If WlUchBindingSource.Position = -1 Then
            LabelNameuch.Text = "Ничего"
        Else
            LabelNameuch.Text = CType(WlUchBindingSource.Current, modRasstOp.wlUch).NameUch
        End If
    End Sub

  
End Class