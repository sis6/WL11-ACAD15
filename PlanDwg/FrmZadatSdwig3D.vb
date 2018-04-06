Imports modRasstOp

Public Class FrmZadatSdwig3D
    Public PervajOpor As wlOpRasst
    Public AnkUch As Rashet.wlAnkUchTr
    ReadOnly Property GabRejm As Rashet.Rejm
        Get
            Return New Rashet.Rejm("для пересечений ", CDbl(TextBoxGamma.Text), CDbl(TextBoxTemp.Text), CDbl(TextBoxSigma.Text))
        End Get
    End Property
    Private Sub OpredRejm()
        If ComboBoxGamma.SelectedIndex < 0 Then Return
        Dim ltemp As Double
        Try
            ltemp = CDbl(TextBoxTemp.Text)
        Catch ex As Exception
            Return
        End Try
        If String.IsNullOrEmpty(TextBoxTemp.Text) Then Return
        Dim lgabrejProvoda As New Rashet.Rejm("для пересечений ", AnkUch.Nagr.G(ComboBoxGamma.SelectedIndex), ltemp)
        AnkUch.RaschetPoPrivedenomuProletu(AnkUch.GabProlet.IshRejm, lgabrejProvoda, AnkUch.Nagr.Provod)
        TextBoxSigma.Text = Format(lgabrejProvoda.Sigma, "f1")
        TextBoxGamma.Text = Format(lgabrejProvoda.Gamma, "f4")
    End Sub

    Public Sub AddTochku(isdwig As SdwigPoProlety)
        SdwigPoProletyBindingSource.Add(isdwig)
    End Sub
    Public Function GetTochku(i As Integer) As SdwigPoProlety
        Return SdwigPoProletyBindingSource(i)
    End Function
    Public Function GetTochki() As System.Collections.IList


        Return SdwigPoProletyBindingSource.List
    End Function

    Private Sub FrmZadatSdwig3D_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        wGlSl = New BazDwg.dwgSlowar(Me.Name)

        Me.LabelOpor.Text = PervajOpor.NumName & "-" & PervajOpor.Sled.NumName
        Me.LabelPiketaj.Text = clsPrf.ClsPiket.StrPiketaj(PervajOpor.Piketaj)
        Me.LabelDlinaProleta.Text = Format(PervajOpor.Sled.RastOtNachala - PervajOpor.RastOtNachala, "f1")
        ComboBoxGamma.SelectedIndex = tshNagrEnum.G3
        TextBoxTemp.Text = AnkUch.GabProlet.GabRejm.Temp
        If EstliZapis() Then
            LabelOzapicb.Text = "Есть запись в словаре"
        End If
    End Sub
    Public Sub ZadatIzMasStrok(imass() As String)
        If imass Is Nothing Then Return
        If imass.Length < 5 Then Return
        SdwigPoProletyBindingSource.Clear()
        ComboBoxGamma.SelectedIndex = CInt(imass(0))
        TextBoxTemp.Text = imass(1)
        For i As Integer = 2 To imass.Length - 1 Step 3
            Dim el As New SdwigPoProlety(Double.Parse(imass(i)), CDbl(imass(i + 1)), CDbl(imass(i + 2)))
            SdwigPoProletyBindingSource.Add(el)
        Next

    End Sub
    Public Function SohranitWMassiwStrok() As String()
        Dim lmass() As String
        ReDim lmass(1 + SdwigPoProletyBindingSource.Count * 3)
        lmass(0) = ComboBoxGamma.SelectedIndex
        lmass(1) = TextBoxTemp.Text
        Dim I As Integer = 2
        For Each el As SdwigPoProlety In SdwigPoProletyBindingSource
            lmass(I) = el.OtNachala
            I += 1
            lmass(I) = el.SdwigPoperesh
            I += 1
            lmass(I) = el.Otmetka
            I += 1
        Next
        Return lmass
    End Function

    Private wGlSl


    Private Function EstliZapis() As Boolean
        Dim lmass() As String = wGlSl.ZapisIzSlovarStr(BazDwg.dwgSlowar.DopustImjSlowaraj(LabelOpor.Text))
        If lmass Is Nothing Then Return False
        If lmass.Length < 5 Then Return False
        Return True
    End Function


    Private Sub ButtonZagr_Click(sender As Object, e As EventArgs) Handles ButtonZagr.Click
        Dim lmass() As String = wGlSl.ZapisIzSlovarStr(BazDwg.dwgSlowar.DopustImjSlowaraj(LabelOpor.Text))
        ZadatIzMasStrok(lmass)
    End Sub

    Private Sub ButtonSohr_Click(sender As Object, e As EventArgs) Handles ButtonSohr.Click
        Dim lmass() As String = SohranitWMassiwStrok()
        wGlSl.ZapisW_SlowarStr(BazDwg.dwgSlowar.DopustImjSlowaraj(LabelOpor.Text), lmass)
    End Sub

    Private Sub ComboBoxGamma_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxGamma.SelectedIndexChanged
        OpredRejm()
    End Sub

    Private Sub TextBoxTemp_TextChanged(sender As Object, e As EventArgs) Handles TextBoxTemp.TextChanged
        OpredRejm()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        TextBoxGamma.ReadOnly = Not CheckBox1.Checked
        TextBoxSigma.ReadOnly = Not CheckBox1.Checked
    End Sub
End Class