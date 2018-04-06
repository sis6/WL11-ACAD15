Public Class FrmWiwRezRasp
    Private wSp() As RaspProvodProvod
    Sub AddRez(ByVal iRez As RaspProvodProvod)
        RaspProvodTrosBindingSource.Add(iRez)

        '    RaspProvodTrosBindingSource.Add(iRez)
    End Sub

    Private Sub DataGridViewRez_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridViewRez.CellFormatting
        If DataGridViewRez.Columns(e.ColumnIndex).Name = FazaDataGridViewTextBoxColumn.Name Or DataGridViewRez.Columns(e.ColumnIndex).Name = FazaWtor.Name Then
            Select Case CInt(e.Value)
                Case 0, 1, 2
                    e.Value = CStr(CInt(e.Value) + 1)
                Case modRasstOp.Fazi.tros
                    e.Value = "трос"
                Case modRasstOp.Fazi.opt
                    e.Value = "ОКСН"
                Case Else
                    e.Value = "неопред"
            End Select

        End If

    End Sub

    Private Sub DataGridViewRez_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridViewRez.ColumnHeaderMouseClick

    End Sub

    Private Sub ButtonWExcel_Click(sender As Object, e As EventArgs) Handles ButtonWExcel.Click
        Dim lDocExcel As New docExcelRasp()
        If RaspProvodTrosBindingSource.Current IsNot Nothing Then
            lDocExcel.ZadatReshenie(RaspProvodTrosBindingSource.Current)
            lDocExcel.zapolnit()
            lDocExcel.wiwesti()
        End If


    End Sub
    Private PriznakWib As Boolean = False
    Private Sub ButtonWibrat_Click(sender As Object, e As EventArgs) Handles ButtonWibrat.Click
        'For i As Integer = 0 To RaspProvodTrosBindingSource.Count - 1
        '    Dim el As RaspProvodProvod = RaspProvodTrosBindingSource.Item(i)
        '    If el.Kriterij > 1 Then RaspProvodTrosBindingSource.Remove(el)
        'Next
        'RaspProvodTrosBindingSource.Filter = "Kriterij < 1"
        'RaspProvodTrosBindingSource.ResetBindings(False)
        If PriznakWib = False Then
            ButtonWibrat.Text = "Выбрать все"
            PriznakWib = True
            RaspProvodTrosBindingSource.MoveFirst()

            Do
                ' If RaspProvodTrosBindingSource.Position + 1 = RaspProvodTrosBindingSource.Count Then Return
                Dim el As RaspProvodProvod = RaspProvodTrosBindingSource.Current
                If el Is Nothing Then Return
                If el.Kriterij > 1 Then
                    RaspProvodTrosBindingSource.Remove(el)
                    If RaspProvodTrosBindingSource.Position = RaspProvodTrosBindingSource.Count Then Return
                Else
                    If RaspProvodTrosBindingSource.Position + 1 < RaspProvodTrosBindingSource.Count Then
                        RaspProvodTrosBindingSource.MoveNext()
                    Else
                        Return
                    End If




                End If




            Loop
        Else
            ButtonWibrat.Text = "Выбрать нарушения"
            PriznakWib = False
            RaspProvodTrosBindingSource.DataSource = wSp.ToList
        End If


    End Sub

    Private Sub FrmWiwRezRasp_Load(sender As Object, e As EventArgs) Handles Me.Load
        ReDim wSp(RaspProvodTrosBindingSource.Count - 1)
        RaspProvodTrosBindingSource.CopyTo(wSp, 0)
      
    End Sub
End Class