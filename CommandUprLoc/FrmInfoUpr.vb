#If ARX_APP Then
Imports Autodesk.AutoCAD.ApplicationServices
#Else
Imports Bricscad.ApplicationServices
#End If



Public Class FrmInfoUpr
#Region "Для всего"
    Private Sub ToolStripButtonDobPrmOP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonDobPrmOP.Click
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        acDoc.SendStringToExecute("DobPromOp ", True, False, False)
    End Sub
    Private Sub ToolStripButtonRasst1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonRasst1.Click
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        acDoc.SendStringToExecute("rasstabit1 ", True, False, False)
    End Sub
    Private Sub ToolStripButtonRasst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonRasst.Click
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        acDoc.SendStringToExecute("rasstabit ", True, False, False)
    End Sub
    Private Sub ToolStripButtonUdalPromOp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonUdalPromOp.Click
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        acDoc.SendStringToExecute("UdalPromOp ", True, False, False)
    End Sub
#End Region

#Region "Provod"


    Private Sub ToolStripButtonNagr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonNagr.Click
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        acDoc.SendStringToExecute("Nagruzki ", True, False, False)
        '  acDoc.SendStringToExecute("._zoom _all ", True, False, False)
        '  Me.StartPosition
    End Sub


    Private Sub ToolStripButtonGabRejm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonGabRejm.Click
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        acDoc.SendStringToExecute("Raschet ", True, False, False)
    End Sub
    Private Sub ToolStripButtonZadatRejm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonZadatRejm.Click
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        acDoc.SendStringToExecute("ZadatUslow ", True, False, False)
    End Sub

    Private Sub ToolStripButtonZadatPrsh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonZadatPrsh.Click
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        acDoc.SendStringToExecute("ZadPeresesh ", True, False, False)
    End Sub

    Private Sub ToolStripButtonRashZadaRej_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonRashZadaRej.Click
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        acDoc.SendStringToExecute("RaschetPoZad ", True, False, False)
    End Sub

    Private Sub ToolStripButtonRschPrsh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonRschPrsh.Click
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        acDoc.SendStringToExecute("Pereseshenij ", True, False, False)
    End Sub

    Private Sub ToolStripButtonAwRejm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonAwRejm.Click
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        acDoc.SendStringToExecute("RaschetAw ", True, False, False)
    End Sub
#End Region
#Region "Tros"


    Private Sub ToolStripMenuItemGabRej_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemGabRej.Click
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        acDoc.SendStringToExecute("RaschetRejTros ", True, False, False)
    End Sub

    Private Sub ToolStripMenuItemZadRejm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemZadRejm.Click
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        acDoc.SendStringToExecute("RaschetRejTrosZad ", True, False, False)
    End Sub

    Private Sub ToolStripDropDownButtonTros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripDropDownButtonTros.Click

    End Sub

    Private Sub NagrToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NagrToolStripMenuItem.Click
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        acDoc.SendStringToExecute("NagruzkiT ", True, False, False)
    End Sub

    Private Sub ZadatToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZadatToolStripMenuItem.Click
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        acDoc.SendStringToExecute("ZadatUslowT ", True, False, False)
    End Sub

    Private Sub RashetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RashetToolStripMenuItem.Click
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        acDoc.SendStringToExecute("RaschetPoZadT ", True, False, False)
    End Sub
#End Region


    Private Sub ToolStripMenuItemNagrWols_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemNagrWols.Click
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        acDoc.SendStringToExecute("NagruzkiW ", True, False, False)
    End Sub

    Private Sub RasshetWToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RasshetWToolStripMenuItem.Click
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        acDoc.SendStringToExecute("RaschetW ", True, False, False)
    End Sub

    Private Sub FrmInfoUpr_Load(sender As Object, e As System.EventArgs) Handles Me.Load

    End Sub


End Class