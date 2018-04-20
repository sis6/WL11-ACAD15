Imports System
Imports System.Collections.Generic
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

Public Class ComparatorPointPoX
	'для упорядочивания точек из Autocad
	Implements IComparer(Of Point3d)

	Public Function Compare(ByVal x As Point3d, ByVal y As Point3d) As Integer Implements System.Collections.Generic.IComparer(Of Point3d).Compare


		If Math.Abs(x.X - y.X) < 0.1 Then Return 0
		If x.X > y.X Then
			Return 1
		Else
			Return -1
		End If

	End Function
End Class
Public Class ComparatorPoint2dPoX
    'для упорядочивания точек из Autocad
    Implements IComparer(Of Point2d)

    Public Function Compare(ByVal x As Point2d, ByVal y As Point2d) As Integer Implements System.Collections.Generic.IComparer(Of Point2d).Compare
        Return x.X.CompareTo(y.X)

        'If Math.Abs(x.X - y.X) < 0.01 Then Return 0


        'If x.X > y.X Then
        '    Return 1
        'Else
        '    Return -1
        'End If

    End Function
    Shared Sub SearchAndInsert( _
ByVal lis As List(Of Point2d), _
ByVal insert As Point2d, ByVal dc As ComparatorPoint2dPoX)



        Dim index As Integer = lis.BinarySearch(insert, dc)

        If index < 0 Then
            index = index Xor -1
            lis.Insert(index, insert)
        End If
    End Sub


End Class
Public Class ComparatorPoint2dXY
    'для упорядочивания точек из Autocad
    Implements IComparer(Of Point2d)
    Private wDopusk As Double = 0.5
    Public Function Compare(ByVal x As Point2d, ByVal y As Point2d) As Integer Implements System.Collections.Generic.IComparer(Of Point2d).Compare


        If Math.Abs(x.X - y.X) < wDopusk Then
            If Math.Abs(x.Y - y.Y) < wDopusk Then Return 0
            If x.Y > y.Y Then
                Return 1
            Else
                Return -1
            End If
        End If


        If x.X > y.X Then
            Return 1
        Else
            Return -1
        End If

    End Function
    Shared Sub SearchAndInsert( _
ByVal lis As List(Of Point2d), _
ByVal insert As Point2d, ByVal dc As ComparatorPoint2dXY)



        Dim index As Integer = lis.BinarySearch(insert, dc)

        If index < 0 Then
            index = index Xor -1
            lis.Insert(index, insert)
        End If
    End Sub
    Shared Sub AddWSpisok(lis As List(Of Point2d), iPoint As Point2d, dc As ComparatorPoint2dXY)
        Dim index As Integer = lis.BinarySearch(iPoint, dc)
        If index < 0 Then lis.Add(iPoint)
    End Sub

End Class
''' <summary>
''' компаратор упорядочивает по возрастанию X , при близких X по Возрастанию У 
''' </summary>
''' <remarks> Для mtext  </remarks>
Public Class ComparatorPoMtext
    'для упорядочивания точек из Autocad
    Implements IComparer(Of MText)

    Public Function Compare(ByVal x As MText, ByVal y As MText) As Integer Implements System.Collections.Generic.IComparer(Of MText).Compare


        If Math.Abs(x.Location.X - y.Location.X) < 0.01 Then
            If Math.Abs(x.Location.Y - y.Location.Y) < 0.01 Then Return 0
            If x.Location.Y < y.Location.Y Then
                Return 1
            Else
                Return -1
            End If
        End If

        If x.Location.X > y.Location.X Then
            Return 1
        Else
            Return -1
        End If

    End Function
    Shared Sub SearchAndInsert( _
ByVal lis As List(Of MText), _
ByVal insert As MText, ByVal dc As ComparatorPoMtext)



        Dim index As Integer = lis.BinarySearch(insert, dc)

        If index < 0 Then
            index = index Xor -1
            lis.Insert(index, insert)
        End If
    End Sub



End Class
Public Class ComparatorPoMtextY
    'для упорядочивания точек из Autocad
    Implements IComparer(Of MText)

    Public Function Compare(ByVal x As MText, ByVal y As MText) As Integer Implements System.Collections.Generic.IComparer(Of MText).Compare


        'If Math.Abs(x.Location.X - y.Location.X) < 0.01 Then
        '    If Math.Abs(x.Location.Y - y.Location.Y) < 0.01 Then Return 0
        '    If x.Location.Y < y.Location.Y Then
        '        Return 1
        '    Else
        '        Return -1
        '    End If
        'End If
        Return y.Location.Y.CompareTo(x.Location.Y)


    End Function
    Shared Sub SearchAndInsert( _
ByVal lis As List(Of MText), _
ByVal insert As MText, ByVal dc As ComparatorPoMtextY)



        Dim index As Integer = lis.BinarySearch(insert, dc)

        If index < 0 Then
            index = index Xor -1
            lis.Insert(index, insert)
        End If
    End Sub



End Class
''' <summary>
''' компаратор упорядочивает попримитивоц из Autocad по возрастанию X , Extendet 
''' </summary>
''' <remarks> Для Entity  </remarks>
Public Class ComparatorEntity
    'для упорядочивания примитивоц из Autocad
    Implements IComparer(Of Entity)
    Private Function MinX(iEnt As Entity) As Double
        With iEnt.GeometricExtents
            Return Math.Min(.MinPoint.X, .MaxPoint.X)
        End With

    End Function
    Public Function Compare(ByVal x As Entity, ByVal y As Entity) As Integer Implements System.Collections.Generic.IComparer(Of Entity).Compare




        If MinX(x) > MinX(y) Then
            Return 1
        Else
            Return -1
        End If
        Return 0
    End Function
    Shared Sub SearchAndInsert( _
ByVal lis As List(Of Entity), _
ByVal insert As Entity, ByVal dc As ComparatorEntity)



        Dim index As Integer = lis.BinarySearch(insert, dc)

        If index < 0 Then
            index = index Xor -1
            lis.Insert(index, insert)
        End If
    End Sub



End Class