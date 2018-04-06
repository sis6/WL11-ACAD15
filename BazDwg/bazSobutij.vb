
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

Public Class bazSobutij
    Protected prGommand As Boolean
    Protected elLin As Line
    Protected Ustli As Boolean
    'Protected pNameOp As String, ellinDo
    Sub RegSob()
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database

        AddHandler acCurDb.ObjectModified, AddressOf Izm
        AddHandler acCurDb.ObjectOpenedForModify, AddressOf Zap
        Ustli = True
    End Sub
    Sub RemoveSob()
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database

        RemoveHandler acCurDb.ObjectModified, AddressOf Izm
        RemoveHandler acCurDb.ObjectOpenedForModify, AddressOf Zap
        Ustli = False
    End Sub
    'Public Sub EndKommand(ByVal sender As Object, ByVal e As CommandEventArgs)

    '    'Application.ShowAlertDialog(" End Komm " & e.GlobalCommandName)
    '    If e.GlobalCommandName = "GRIP_STRETCH" Then
    '        prGommand = False
    '        If Not elLin Is Nothing Then
    '            Application.ShowAlertDialog("Передвинута в " & elLin.StartPoint.X & vbCr & clsXDATA.GetMasStrok(elLin)(0) & "  Do " & ellinDo.StartPoint().X)
    '        End If
    '    End If
    'End Sub
    Private Sub Izm(ByVal senderObj As Object, ByVal evtArgs As ObjectEventArgs)
        Dim dn As DBObject = evtArgs.DBObject

        '   elLin = Nothing
        If prGommand Then
            Dim lwS = dn.GetRXClass().DxfName
            If dn.GetRXClass().DxfName = "LINE" And dn.XData IsNot Nothing Then
                elLin = CType(dn.Clone, Line)
                '     BazfunNet.SystemKommand.SoobEditor("Линия установлена")
                '    pNameOp = BazDwg.clsXDATA.GetMasStrok(elLin)(0)
            Else
                If lwS = "LINE" Then
                    elLin = Nothing
                    '    pNameOp = String.Empty
                End If

            End If
        End If
    End Sub
    Private Sub Zap(ByVal senderObj As Object, ByVal evtArgs As ObjectEventArgs)
        'Функция обрабатывает до начала модификации может быть использована для других элементов 
        'Dim dn As DBObject = evtArgs.DBObject
        '' ellinDo = Nothing
        'If prGommand Then
        '    If dn.GetRXClass().DxfName = "LINE" And dn.XData IsNot Nothing Then
        '        '  ellinDo = CType(dn.Clone, Line)
        '    End If
        'End If
    End Sub
    Sub New()
        Ustli = False
    End Sub
End Class
Public Class ExspSob
    Dim objOtsl As New BazDwg.PointMon
    Sub RegSob()
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument

        Dim acCurDb As Database = acDoc.Database
        AddHandler acDoc.ImpliedSelectionChanged, AddressOf wib
        AddHandler acCurDb.ObjectModified, AddressOf Izm
        AddHandler acCurDb.ObjectOpenedForModify, AddressOf Zap
        AddHandler acDoc.CommandWillStart, AddressOf Me.BegKommand
    End Sub
    Public Sub BegKommand(ByVal sender As Object, ByVal e As CommandEventArgs)
        ' Application.ShowAlertDialog(e.GlobalCommandName)
        '  MsgBox(" BegKommand  " & e.GlobalCommandName)
        'If e.GlobalCommandName = "GRIP_STRETCH" Then
        '    prGommand = True
        'Else
        '    prGommand = False
        'End If
    End Sub
    Dim prWib As Boolean = False
    Public Sub wib(ByVal sender As Object, ByVal e As System.EventArgs)

        'MsgBox(" e " & e.ToString() & " sender " & sender.ToString)
        '  Application.DocumentManager.MdiActiveDocument.
        ' Editor.PointToScreen()
        prWib = True

        '  Dim Pol As Point3d = Application.DocumentManager.MdiActiveDocument.Editor.PointToWorld(Application.DocumentManager.MdiActiveDocument.Window.Location)
        MsgBox(" e " & objOtsl.Koor.X)
    End Sub

    Public Sub Zap(ByVal senderObj As Object, ByVal evtArgs As ObjectEventArgs)

        Dim dn As DBObject = Nothing

        '  MsgBox(" Izm  " & evtArgs.DBObject.GetRXClass().DxfName)
        '   Dim lDxfname = evtArgs.DBObject.GetRXClass().DxfName
        If evtArgs.DBObject.GetRXClass().DxfName = "LINE" Then
            dn = evtArgs.DBObject

            Dim ellin As Line = CType(dn.Clone, Line)
            If ellin.Layer = "V11piketaj" And prWib = True Then
                MsgBox(" Zap  " & ellin.EndPoint.X)
                prWib = False
            End If
        End If


    End Sub
    Public Sub Izm(ByVal senderObj As Object, ByVal evtArgs As ObjectEventArgs)

        'Dim dn As DBObject = Nothing

        ''  MsgBox(" Izm  " & evtArgs.DBObject.GetRXClass().DxfName)
        ''   Dim lDxfname = evtArgs.DBObject.GetRXClass().DxfName
        'If evtArgs.DBObject.GetRXClass().DxfName = "LINE" Then
        '    dn = evtArgs.DBObject
        '    Dim ellin As Line = CType(dn.Clone, Line)
        '    If ellin.Layer = "V11piketaj" And prWib = True Then
        '        MsgBox(" Izm  " & ellin.EndPoint.Y)
        '        prWib = False
        '    End If

        'If Not dn.XData Is Nothing Then
        '    'Dim nDb As Database = TryCast(senderObj, Database)
        '    'Dim tm As DBTransMan = nDb.TransactionManager
        '    'Dim ta As Transaction = tm.StartTransaction()
        '    'Try
        '    '    elLin = tm.GetObject(dn.ObjectId, OpenMode.ForRead, False)

        '    '    ta.Commit()
        '    'Finally
        '    '    ta.Dispose()
        '    'End Try
        '    elLin = CType(dn, Line)
        'End If

        'End If

    End Sub
    Sub New()
        RegSob()
        objOtsl.PMON_START()
    End Sub

    Protected Overrides Sub Finalize()
        objOtsl.PMON_END()
        MyBase.Finalize()
    End Sub
End Class