Imports System.Windows.Forms

Public Class frmFileParamGeo

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btWibratExel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btWibratExel.Click

        OpenFileDialog1.Filter = "Параметры Слоев ИГЭ в doc|*.doc|Параметры Слоев ИГЭ docx|*.docx"
        OpenFileDialog1.DefaultExt = "doc"
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ' MsgBox(OpenFileDialog1.FileName)
            ListBoxSpFile.Items.Add(OpenFileDialog1.FileName)
        
        End If
    End Sub

    Private Sub btUdalit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btUdalit.Click
        If ListBoxSpFile.SelectedIndex > -1 Then
            ListBoxSpFile.Items.RemoveAt(ListBoxSpFile.SelectedIndex)
        End If
    End Sub
End Class
