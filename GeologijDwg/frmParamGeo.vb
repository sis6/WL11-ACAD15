Imports System.Windows.Forms
Imports LeseSreib

Public Class frmParamGeo
    Private wParamGeo As ParamImageGeo
    '  Private wtrassa As DwgTr
    Private wSpsloj As List(Of String)
  
    WriteOnly Property Sloj() As List(Of String)
        Set(ByVal value As List(Of String))
            value.Sort()
            wSpsloj = value
        End Set
    End Property
    Private Sub frmPrmPrf_HelpRequested(ByVal sender As Object, ByVal hlpevent As System.Windows.Forms.HelpEventArgs) Handles Me.HelpRequested

        '  Help.ShowHelp(Me, HelpProvider1.HelpNamespace, HelpProvider1.GetHelpKeyword(Me))
    End Sub
    Private Sub frmParam_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        HelpProvider1.SetHelpNavigator(Me, HelpNavigator.Topic)
        '  HelpProvider1.SetHelpKeyword(Me, "Parametr")

        wParamGeo = New ParamImageGeo()
        Mashtab.Text = Str(wParamGeo.Maschtab)
        ComboBoxLauerIGE.DataSource = wSpsloj
        ComboBoxLauerIGE.SelectedItem = wParamGeo.NameSlojDwgIGE
        Dim LSpSlojSkwaj As List(Of String)
        LSpSlojSkwaj = wSpsloj.GetRange(0, wSpsloj.Count)

        ComboBoxLayerSkwajn.DataSource = LSpSlojSkwaj
        ComboBoxLayerSkwajn.SelectedItem = wParamGeo.NameSlojDwgSkwaj

        ComboBoxlayerNameIGE.DataSource = wSpsloj.GetRange(0, wSpsloj.Count)
        ComboBoxlayerNameIGE.SelectedItem = wParamGeo.NameSlojDwGUslownie
    End Sub
    Private Sub Mashtab_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mashtab.SelectedIndexChanged
        Dim lm As Integer = CInt(Mashtab.SelectedItem)
        Dim w As Double = 120.0 + 100000.0 / lm + 15.0

    End Sub
    Private Sub OK_Button_Click(sender As System.Object, e As System.EventArgs) Handles OK_Button.Click
        With wParamGeo
            .Maschtab = CInt(Mashtab.Text)
            .NameSlojDwgIGE = CStr(ComboBoxLauerIGE.SelectedItem)
            .NameSlojDwgSkwaj = CStr(ComboBoxLayerSkwajn.SelectedItem)
            .NameSlojDwGUslownie = CStr(ComboBoxlayerNameIGE.SelectedItem)
            .SchreibeParam()

        End With
    End Sub




    Private Sub ComboBoxLauer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxLauerIGE.SelectedIndexChanged

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxLayerSkwajn.SelectedIndexChanged

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub ComboBoxlayerNameIGE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxlayerNameIGE.SelectedIndexChanged

    End Sub
End Class