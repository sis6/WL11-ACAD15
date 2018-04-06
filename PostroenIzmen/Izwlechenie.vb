Imports System.Collections.Generic



#If ARX_APP Then
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.Geometry
Imports DBTransMan = Autodesk.AutoCAD.DatabaseServices.TransactionManager
#Else
Imports Bricscad.ApplicationServices
Imports Teigha.DatabaseServices
Imports Teigha.Geometry
Imports DBTransMan = Teigha.DatabaseServices.TransactionManager
#End If



Public Module Izwlechenie
    ''' <summary>
    ''' извлекает все точки трехмерной полилинии 
    ''' </summary>
    ''' <param name="el"> 3d-полилиния  </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function WsePointPolyline3d(ByVal el As Entity) As List(Of Point3d)
        Dim lSpTchk As New List(Of Point3d)
        '  Dim lComparator As New ComparatorPoint
        Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database
        Dim tm As DBTransMan = db.TransactionManager
        Using ta As Transaction = tm.StartTransaction()
            Dim i As Integer = 0

            Dim pl3d As Polyline3d = CType(el, Polyline3d)

            '   pl3d.
            For Each lobj As ObjectId In pl3d
                Dim lvt3 As PolylineVertex3d = CType(ta.GetObject(lobj, OpenMode.ForRead), PolylineVertex3d)
                lSpTchk.Add(lvt3.Position)

                ' lvt3.

            Next
        End Using

        Return lSpTchk
    End Function
End Module
