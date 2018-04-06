Imports System.Windows.Forms
Imports LeseSreib

Public Class frmParam
    Private wParamTrass As ParamTrass
    Private wtrassa As DwgTr
    WriteOnly Property Trassa As DwgTr
        Set(value As DwgTr)
            wtrassa = value
			If wtrassa Is Nothing Then
				Dim lg = New dwgGeometr
				ParamTrass = lg.obrParam
				Me.LabelUnom.Text = " Неопр "
				Me.LabelNamewl.Text = "Данных о растановке нет"
				Me.LabelNameRab.Text = "Данных нет"

				Return
			End If
			Me.ComboBoxPosleZpt.Enabled = False
			Me.LabelUnom.Text = CStr(wtrassa.Unom)
            Me.LabelNamewl.Text = wtrassa.NameLin
            Me.LabelNameRab.Text = wtrassa.NameRab
            If wtrassa.objGeom Is Nothing Then
                Dim lg = New dwgGeometr
                ParamTrass = lg.obrParam
                Return
            End If
            ParamTrass = wtrassa.objGeom.obrParam
        End Set
    End Property
    Private Sub WwodParametrDedal(iPiznak As Boolean)
        ComboBoxBeg.Visible = iPiznak
        ComboBoxEnd.Visible = iPiznak
        TextBoxBegR.Visible = iPiznak
        TextBoxEndR.Visible = iPiznak
        Label19.Visible = iPiznak
        Label20.Visible = iPiznak
        Label21.Visible = iPiznak
        Label22.Visible = iPiznak
      
    End Sub
    Private WriteOnly Property ParamTrass As ParamTrass
        Set(value As ParamTrass)
            wParamTrass = value
            ComboBoxTipGraniz.Items.Add("")
            ComboBoxTipGraniz.Items.Add(ProfilBaseDwg.ParamTrass.TipDetal)

            With wParamTrass
                If wtrassa IsNot Nothing Then
                    Dim lSp = wtrassa.GetPiketi                                '    wtrassa.GetPiketiSnAme()
                    Dim lspClon As New List(Of clsPrf.ClsPiket)(lSp)
                    ComboBoxBeg.DataSource = lSp
                    ComboBoxEnd.DataSource = lspClon
                    ComboBoxBeg.ValueMember = "RastOtnachala"
                    ComboBoxBeg.DisplayMember = "UchPiketaj"
                    ComboBoxEnd.ValueMember = "RastOtnachala"
                    ComboBoxEnd.DisplayMember = "UchPiketaj"

                    ComboBoxBeg.Text = CStr(.BegUch)
                    ComboBoxEnd.Text = CStr(.EndUch)
                    ComboBoxTipGraniz.Text = .TipGraniz
                    If ComboBoxTipGraniz.Text = "" Then
                        WwodParametrDedal(False)
                       
                    Else
                        WwodParametrDedal(True)
                       

                    End If

                Else

                    ComboBoxTipGraniz.Visible = False
                    WwodParametrDedal(False)
                End If



                '  frmObj.tbUch.Text = .Rabota
                Me.Mashtab.Text = CStr(.Maschtab)
                Me.MashtabO.Text = CStr(.MaschtabO)
                Me.tbPiketaj.Text = CStr(.BegTr)
                Me.tbPiketajI.Text = CStr(.BegTrI)
                Me.tbOtmetka.Text = CStr(.BegOtm)
                Me.tbOtmetkaI.Text = CStr(.BegOtmI)
				Me.CBList.Text = CStr(.ShirinaLista)
				Me.ComboBoxPosleZpt.Text = CStr(.PosleZpt)
			End With

        End Set
    End Property
    Private Sub frmPrmPrf_HelpRequested(ByVal sender As Object, ByVal hlpevent As System.Windows.Forms.HelpEventArgs) Handles Me.HelpRequested

        '  Help.ShowHelp(Me, HelpProvider1.HelpNamespace, HelpProvider1.GetHelpKeyword(Me))
    End Sub
    Private Sub frmParam_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        HelpProvider1.SetHelpNavigator(Me, HelpNavigator.Topic)
        '  HelpProvider1.SetHelpKeyword(Me, "Parametr")

        LabelX_Zentra.Text = CStr(clsPodpis.OsY)
        If wParamTrass.TipGraniz = "" Then WwodParametrDedal(False)

        If wtrassa IsNot Nothing Then

            With wtrassa

                LabelDlina.Text = Format(.Dlina, "#.#")
                LabelMinOtm.Text = Format(.MinOtmetka, "#.##")
                LabelMaxOtm.Text = Format(.MaxOtmetka, "#.##")


            End With
        End If
    End Sub
    Private Sub Mashtab_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mashtab.SelectedIndexChanged
        Dim lm As Integer = CInt(Mashtab.SelectedItem)
        Dim w As Double = 120.0 + 100000.0 / lm + 15.0
        LabelY_Zentra.Text = CStr(w)
    End Sub
    Private Sub OK_Button_Click(sender As System.Object, e As System.EventArgs) Handles OK_Button.Click
        With wParamTrass
            If wtrassa IsNot Nothing Then
                .TipGraniz = ComboBoxTipGraniz.Text
                .BegUch = ComboBoxBeg.Text
                .EndUch = ComboBoxEnd.Text
            End If


            .Maschtab = CInt(Mashtab.Text)
            .MaschtabO = CInt(MashtabO.Text)
            .BegTr = CDbl(tbPiketaj.Text)
            .BegTrI = CDbl(tbPiketajI.Text)
            .BegOtm = CDbl(tbOtmetka.Text)
            .BegOtmI = CDbl(tbOtmetkaI.Text)
			.ShirinaLista = CDbl(CBList.Text)
			.PosleZpt = CInt(ComboBoxPosleZpt.Text)
			.SchreibeParam()

        End With
    End Sub
    Private Sub ComboBoxTipGraniz_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBoxTipGraniz.SelectedIndexChanged
        If ComboBoxTipGraniz.Text = ProfilBaseDwg.ParamTrass.TipDetal Then
            WwodParametrDedal(True)

        Else
            WwodParametrDedal(False)

        End If
    End Sub

    Private Sub ComboBoxBeg_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBoxBeg.SelectedIndexChanged
        '  MsgBox(Me.ToString & " V " & Me.Visible)
        '  If Me.Visible = False Then Return
        If wtrassa IsNot Nothing Then
            Dim lPiket As clsPrf.ClsPiket
            Try
                lPiket = wtrassa.Piket(CDbl(ComboBoxBeg.SelectedValue))
                ComboBoxEnd.SelectedIndex = ComboBoxBeg.SelectedIndex
            Catch ex As Exception
                Return
            End Try

            '      wParamTrass.BegTr = Int(lPiket.RastOtnachala)
            tbPiketaj.Text = CStr(wParamTrass.BegTr)
            ' MsgBox(Me.ToString & " Begtr " & wParamTrass.BegTr)
            TextBoxBegR.Text = Format(lPiket.RastOtnachala, "f1")
          
        End If
    End Sub
    Private Sub ComboBoxEnd_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBoxEnd.SelectedIndexChanged
        '  MsgBox(Me.ToString & " V " & Me.Visible)
        '    If Me.Visible = False Then Return
        If wtrassa IsNot Nothing Then
            Dim lPiket As clsPrf.ClsPiket
            Try
                lPiket = wtrassa.Piket(CDbl(ComboBoxEnd.SelectedValue))
            Catch ex As Exception
                Return
            End Try


            ' MsgBox(Me.ToString & " Begtr " & wParamTrass.BegTr)
            TextBoxEndR.Text = Format(lPiket.RastOtnachala, "f1")
         
        End If
    End Sub

    Private Sub MashtabO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MashtabO.SelectedIndexChanged

    End Sub
End Class