Imports System
Imports System.Runtime.InteropServices
#If ARX_APP Then
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.ApplicationServices
Imports DBTransMan = Autodesk.AutoCAD.DatabaseServices.TransactionManager
Imports Autodesk.AutoCAD.EditorInput
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
Imports _AcTrx = Teigha.Runtime
Imports _AcWnd = Bricscad.Windows
Imports DBTransMan = Teigha.DatabaseServices.TransactionManager
#End If

'Imports System
'Imports System.Runtime.InteropServices
'Imports Autodesk.AutoCAD.Runtime
'Imports Autodesk.AutoCAD.ApplicationServices
'Imports Autodesk.AutoCAD.EditorInput
'Namespace HelloWorld
'    Public Class PointMon
'        ' Команда запуска PointMonitor
'        <CommandMethod("P_START")> _
'        Public Sub PMON_START()
'            Dim ed As Autodesk.AutoCAD.EditorInput.Editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor
'            AddHandler ed.PointMonitor, AddressOf callback_PointMonitor
'            m_point = True
'        End Sub
'        ' Команда остановки PointMonitor
'        <CommandMethod("P_END")> _
'        Public Sub PMON_END()
'            Dim ed As Autodesk.AutoCAD.EditorInput.Editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor
'            If m_point Then
'                RemoveHandler ed.PointMonitor, AddressOf callback_PointMonitor
'                m_point = False
'            End If
'        End Sub
'        ' Получение текущей координаты курсора в WCS (сохраненной из PointMonitor)
'        <CommandMethod("GetCoord")> _
'        Public Sub GetCoord()
'            Dim ed As Autodesk.AutoCAD.EditorInput.Editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor
'            ed.WriteMessage("" & Chr(10) & "Point in WCS = {0}", computed_point)
'        End Sub
'        Private Sub callback_PointMonitor(ByVal sender As Object, ByVal e As PointMonitorEventArgs)
'            Dim ed As Autodesk.AutoCAD.EditorInput.Editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor
'            computed_point = e.Context.ComputedPoint
'        End Sub
'        Shared m_point As Boolean = False
'        Shared computed_point As Autodesk.AutoCAD.Geometry.Point3d
'    End Class
'End Namespace


Public Class PointMon
    ' Команда запуска PointMonitor

    Public Sub PMON_START()
		Dim ed As Editor = Application.DocumentManager.MdiActiveDocument.Editor
		AddHandler ed.PointMonitor, AddressOf callback_PointMonitor
        m_point = True
    End Sub
    ' Команда остановки PointMonitor

    Public Sub PMON_END()
		Dim ed As Editor = Application.DocumentManager.MdiActiveDocument.Editor
		If m_point Then
            RemoveHandler ed.PointMonitor, AddressOf callback_PointMonitor
            m_point = False
        End If
    End Sub
    ' Получение текущей координаты курсора в WCS (сохраненной из PointMonitor)

    Public Sub GetCoord()
        Dim ed As Editor = Application.DocumentManager.MdiActiveDocument.Editor
        ed.WriteMessage("" & Chr(10) & "Point in WCS = {0}", computed_point)
    End Sub
    Public Function Koor() As Point3d
        Return computed_point
    End Function
    Private Sub callback_PointMonitor(ByVal sender As Object, ByVal e As PointMonitorEventArgs)
        Dim ed As Editor = Application.DocumentManager.MdiActiveDocument.Editor
        computed_point = e.Context.ComputedPoint
    End Sub
    Shared m_point As Boolean = False
    Shared computed_point As Point3d
End Class

