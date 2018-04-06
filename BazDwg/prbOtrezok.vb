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
Public Class ComparatorPrOtrezok
    'для упорядочивания точек из Autocad
    Implements IComparer(Of prbOtrezok)

    Public Function Compare(ByVal T1 As prbOtrezok, ByVal T2 As prbOtrezok) As Integer Implements System.Collections.Generic.IComparer(Of prbOtrezok).Compare


        If Math.Abs(T1.PointB.X - T2.PointB.X) < 0.01 Then Return 0
        If T1.PointB.X > T2.PointB.X Then
            Return 1
        Else
            Return -1
        End If

    End Function
End Class

''' <summary>
''' Отрезок упорядоченый по X координате
''' </summary>
''' <remarks></remarks>
Public Class prbOtrezok
    Private wPb, wPe As Point3d
    Sub New(ByVal p1 As Point3d, ByVal p2 As Point3d)
        If p1.X < p2.X Then
            wPb = p1
            wPe = p2
        Else
            wPb = p2
            wPe = p1
        End If
    End Sub
    ReadOnly Property PointB() As Point3d
        Get
            Return wPb
        End Get
    End Property
    ReadOnly Property PointE() As Point3d
        Get
            Return wPe
        End Get
    End Property
    Function PointT(ByVal ix As Double) As Point3d
        Dim lDelta As Double = wPe.X - wPb.X
        If Math.Abs(lDelta) > Double.Epsilon Then
            Dim lk As Double = (wPe.Y - wPb.Y) / lDelta

            Dim ly As Double = wPb.Y + lk * (ix - wPb.X)
            Return New Point3d(ix, ly, 0)
        End If
        Return Nothing
    End Function
End Class
