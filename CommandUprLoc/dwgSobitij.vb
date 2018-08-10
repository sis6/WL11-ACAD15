Option Strict On
Option Explicit On
#If ARX_APP Then
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.ApplicationServices
Imports DBTransMan = Autodesk.AutoCAD.DatabaseServices.TransactionManager
#Else
Imports Bricscad.ApplicationServices
Imports _AcBr = Teigha.BoundaryRepresentation
Imports _AcCm = Teigha.Colors
Imports Teigha.DatabaseServices
Imports Bricscad.EditorInput
Imports Teigha.Geometry
Imports _AcGi = Teigha.GraphicsInterface
Imports _AcGs = Teigha.GraphicsSystem
Imports _AcPl = Bricscad.PlottingServices
Imports _AcBrx = Bricscad.Runtime
Imports Teigha.Runtime
Imports _AcWnd = Bricscad.Windows
Imports DBTransMan = Teigha.DatabaseServices.TransactionManager
#End If



Imports BazDwg

Public Class dwgSobitij
    Inherits BazDwg.bazSobutij
    Private wop As modRasstOp.wlOpRasst

    Overloads Sub RegSob()
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        MyBase.RegSob()
        AddHandler acDoc.CommandEnded, AddressOf Me.EndKommand
        AddHandler acDoc.CommandWillStart, AddressOf Me.BegKommand
    End Sub
    Sub RegSobApp()
        AddHandler Application.BeginDoubleClick, AddressOf dwa
        AddHandler Application.SystemVariableChanged, AddressOf IzmSystemPeremen
        AddHandler Application.SystemVariableChanging, AddressOf eee
    End Sub
	Sub eee(ByVal senderObj As Object, ByVal sysVarChEvtArgs As Autodesk.AutoCAD.ApplicationServices.SystemVariableChangingEventArgs)
		'    Application.ShowAlertDialog(sysVarChEvtArgs.Name)
	End Sub
	Sub IzmSystemPeremen(ByVal senderObj As Object, ByVal sysVarChEvtArgs As Autodesk.AutoCAD.ApplicationServices.SystemVariableChangedEventArgs)
		' IzmSystemPeremen
	End Sub
	Sub dwa(ByVal sender As Object, ByVal e As BeginDoubleClickEventArgs)

        Dim rast As Double = clsKommandBase.gTrassa.RastPoDwgX(e.Location.X)
        Dim wop As modRasstOp.wlOpRasst = clsKommandBase.gRasst.wibratOporu(rast)
      
        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim lock As DocumentLock = doc.LockDocument()
        clsKommandRst.PoOporeAnkUch(wop)
        lock.Dispose()
        'Try
        '    BazDwg.CreateEntities.MakeEntities.CreateLine(e.Location.X, e.Location.Y, e.Location.X + 10, e.Location.Y + 10)
        'Catch ex As Exception
        '    Dim acdoc As Document = Application.DocumentManager.MdiActiveDocument
        '    ' acdoc.ockMode()
        '    Application.ShowAlertDialog(acdoc.Name & "  " & ex.Message & " " & acdoc.LockMode())

        'End Try

    End Sub
    Private Sub BegKommand(ByVal sender As Object, ByVal e As CommandEventArgs)

        If e.GlobalCommandName = "GRIP_STRETCH" Then

            prGommand = True
        Else
            prGommand = False
        End If
    End Sub
    Private Sub EndKommand(ByVal sender As Object, ByVal e As CommandEventArgs)

        'Application.ShowAlertDialog(" End Komm " & e.GlobalCommandName)
        If e.GlobalCommandName = "GRIP_STRETCH" Then
            prGommand = False
            If elLin IsNot Nothing Then
                '      Dim lwsp = elLin.Layer

                '      elLin.Layer = DwgParam.SlRasstOpor Then
                '  BazDwg.SystemKommand.SoobEditor("End Комманд::Проводим сдвиг")
                '   Dim rIsh As Double = gTrassa.RastPoDwgX(ellinDo.StartPoint().X)
                Dim r As Double = clsKommandBase.gTrassa.RastPoDwgX(elLin.StartPoint().X)
                Dim lNameOp As String = BazDwg.clsXDATA.GetMasStrok(elLin)(modRasstOp.wlOp.RassOp_Par.NumName)
               
                wop = clsKommandBase.gRasst.wibratOporu(lNameOp)
                '     BazDwg.SystemKommand.SoobEditor("End Комманд::опора " & wop.NumName & " c " & wop.Tip)
                If wop.Tip = 0 Then
                    clsKommandBase.gRasst.IzmPolojnii(wop, r)

                End If
                dwgWiwRasst.PerepisatOpNaprofil(wop)
                clsKommandRst.PoOporeAnkUch(wop)
                elLin = Nothing
            End If


        End If
        prGommand = True
    End Sub
    Sub New()
        MyBase.New()
        RegSob()
        RegSobApp()

    End Sub
End Class
