
#If ARX_APP Then
Imports Autodesk.AutoCAD.EditorInput
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.ApplicationServices
#Else
Imports Bricscad.EditorInput
Imports Teigha.DatabaseServices
Imports Bricscad.ApplicationServices
#End If
Public Class PolylinePlanTrass
    Private wDocument As Document = Application.DocumentManager.MdiActiveDocument
    Private wEditor As Editor = wDocument.Editor
    Function WiborPolyline() As Polyline

        Dim l As New PromptSelectionOptions()
        l.MessageForAdding = "Выбери полилинию трассы"

        Dim result As PromptSelectionResult = wEditor.GetSelection(l)
        If (result.Status = PromptStatus.OK) Then

            Dim acSset As SelectionSet = result.Value

            Dim lspent As List(Of Entity) = BazDwg.GetEntity(acSset.GetObjectIds)
            If lspent Is Nothing Then
                Application.ShowAlertDialog("не выбрано ")
                Return Nothing
            End If
            Dim lObjSwajzRasstPolyline As SwajzPolylineRasst = Nothing
            For Each el As Entity In lspent

                If el.GetRXClass().DxfName <> "LWPOLYLINE" Then Continue For

                Return CType(el, Polyline)

            Next


            Application.ShowAlertDialog("не выбрано ни одной полилинии")
            Return Nothing

        Else
            Application.ShowAlertDialog("Ничего")
            Return Nothing
        End If
    End Function
End Class
