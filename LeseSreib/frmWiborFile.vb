Imports System.Windows.Forms

Public Class frmWiborFile

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btWibratExel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btWibratExel.Click

        OpenFileDialog1.Filter = "Описание профиля в 97-2003|*.xls|Описание профиля Excel|*.xlsx"
        OpenFileDialog1.DefaultExt = "xls"
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ' MsgBox(OpenFileDialog1.FileName)
            lbSpFile.Items.Add(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub btUdalit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btUdalit.Click
        If lbSpFile.SelectedIndex > -1 Then
            lbSpFile.Items.RemoveAt(lbSpFile.SelectedIndex)
        End If
    End Sub
End Class
