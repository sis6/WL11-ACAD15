Partial Class dsUpr
    Partial Class FileExcelDataTable

        Private Sub FileExcelDataTable_FileExcelRowChanging(ByVal sender As System.Object, ByVal e As FileExcelRowChangeEvent) Handles Me.FileExcelRowChanging

        End Sub

    End Class

    Partial Class uchastkiNDataTable

        Private Sub uchastkiNDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.IdUchColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

    Partial Class RegPsDataTable

        Private Sub RegPsDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.IndeksColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

    Partial Class pObjectESSlDataTable

        Private Sub pObjectESSlDataTable_pObjectESSlRowChanging(ByVal sender As System.Object, ByVal e As pObjectESSlRowChangeEvent) Handles Me.pObjectESSlRowChanging

        End Sub

    End Class

End Class

Namespace dsUprTableAdapters

    Partial Class FileExcelTableAdapter

    End Class

    Partial Public Class pObjectESSlTableAdapter
    End Class
End Namespace
