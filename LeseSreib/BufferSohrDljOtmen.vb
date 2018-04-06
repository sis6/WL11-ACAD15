''' <summary>
''' Класс предназначен для сохранения старых значений измененных величин и их восстановления(отмена операций редактирования в DataGridVien)
''' </summary>
''' <remarks></remarks>
Public Class ZapisBufferSohrDljOtmen
    Private wGdeIzmeneno As DataGridView  ' 
    Private wCell As DataGridViewCell
    Private wZnachenie As Object
    Private wDataRow As DataRow
    Private wRow, wColumn As Integer
    Private wUpr As ToolStripDropDownButton
    Sub New(ByVal iGde As DataGridViewCell, ByVal iChto As Object)
		wGdeIzmeneno = Nothing

		wCell = iGde
        wZnachenie = iChto
        wDataRow = Nothing
    End Sub
    Sub New(ByVal iDataGrid As DataGridView, ByVal iRowNum As Integer, ByVal iRow As DataGridViewRow)
        wGdeIzmeneno = iDataGrid
        wRow = iRowNum
        Dim rww As DataRow = CType(iRow.DataBoundItem, DataRowView).Row

        '  wDataRow = CType(wGdeIzmeneno.DataSource, OperBD.DsProfil).ProfilA.NewProfilARow()
        wDataRow = rww.Table.NewRow
        With wDataRow

            Dim ir As Integer = .Table.Columns.Count - 1
            For i As Integer = 0 To ir
                .Item(i) = rww.Item(i)
            Next

        End With

        wZnachenie = Nothing
    End Sub
    Sub WosstanowitDataGridView()
        wCell.Value = wZnachenie

    End Sub
    Sub WosstanowitDataGridViewRow()
        '  MsgBox("WosstanowitDataGridViewRow " & wGdeIzmeneno.DataSource.name)
        If TypeOf wGdeIzmeneno.DataSource Is OperBD.DsProfil Then
            CType(wGdeIzmeneno.DataSource, OperBD.DsProfil).ProfilA.Rows.InsertAt(wDataRow, wRow)
        Else
            Dim lbindigsource As BindingSource = CType(wGdeIzmeneno.DataSource, System.Windows.Forms.BindingSource)
            Select Case lbindigsource.DataMember
                Case "rastOpN"
                    CType(lbindigsource.DataSource, OperBD.dsRasst).rastOpN.Rows.InsertAt(wDataRow, wRow)
                Case "TablKlimN"
                    CType(lbindigsource.DataSource, OperBD.DsProfil).TablKlimN.Rows.InsertAt(wDataRow, wRow)
                Case "PikUgodN"
                    CType(lbindigsource.DataSource, OperBD.DsProfil).PikUgodN.Rows.InsertAt(wDataRow, wRow)
                Case "MechUsl"
                    CType(lbindigsource.DataSource, OperBD.dsRasst).MechUsl.Rows.InsertAt(wDataRow, wRow)
                Case "oporIUch"
                    CType(lbindigsource.DataSource, OperBD.ElemRasstUch).oporIUch.Rows.InsertAt(wDataRow, wRow)
                Case "prowodaUch"
                    CType(lbindigsource.DataSource, OperBD.ElemRasstUch).prowodaUch.Rows.InsertAt(wDataRow, wRow)
            End Select



        End If


    End Sub
    ReadOnly Property DataRowGrida() As Object
        Get
            Return wDataRow
        End Get
    End Property

End Class

Public Class BufferSohrDljOtmen
    Private wSpisokKorrektir As New List(Of ZapisBufferSohrDljOtmen)
    Private wUpr As ToolStripDropDownButton
    WriteOnly Property Uprawlenie As ToolStripDropDownButton
        Set(ByVal value As ToolStripDropDownButton)
            wUpr = value
            wUpr.Visible = False
        End Set
    End Property

    Sub ZapisatCellDataGrid(ByVal iDtCell As DataGridViewCell, ByVal iChto As Object)
        wUpr.Visible = True
        wSpisokKorrektir.Add(New ZapisBufferSohrDljOtmen(iDtCell, iChto))
    End Sub
    Sub ZapisatRowDataGrid(ByVal iDt As DataGridView, ByVal iRowNum As Integer, ByVal iDtRow As DataGridViewRow)
        wUpr.Visible = True
        wSpisokKorrektir.Add(New ZapisBufferSohrDljOtmen(iDt, iRowNum, iDtRow))
    End Sub
    'Sub WipisatCelDataGrid()

    '    If wSpisokKorrektir.Count > 0 Then
    '        wSpisokKorrektir(wSpisokKorrektir.Count - 1).WosstanowitDataGridView()
    '        wSpisokKorrektir.RemoveAt(wSpisokKorrektir.Count - 1)
    '    End If
    'End Sub
    Sub WipisatCelDataGridRow()
        Dim lcount = wSpisokKorrektir.Count
        If lcount > 0 Then
            wUpr.Visible = True
            Dim lzap As ZapisBufferSohrDljOtmen = wSpisokKorrektir(wSpisokKorrektir.Count - 1)
            If lzap.DataRowGrida Is Nothing Then
                lzap.WosstanowitDataGridView()
            Else
                lzap.WosstanowitDataGridViewRow()

            End If

            wSpisokKorrektir.RemoveAt(wSpisokKorrektir.Count - 1)


        End If
        If wSpisokKorrektir.Count < 1 Then wUpr.Visible = False
    End Sub
    Function GetCelDataGridRow() As Object
        Dim lcount = wSpisokKorrektir.Count
        If lcount > 0 Then
            Dim lzap As ZapisBufferSohrDljOtmen = wSpisokKorrektir(lcount - 1)

            Return lzap.DataRowGrida


        End If
        Return Nothing
    End Function
End Class
