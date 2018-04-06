Imports BazDwg

#If ARX_APP Then
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.DatabaseServices
#Else
Imports Bricscad.ApplicationServices
Imports _AcBr = Teigha.BoundaryRepresentation
Imports Teigha.Colors
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
Public Class dwgPow
    Inherits clsPrf.Powerhnost
    Const SlZ3DPowerhnost As String = DwgParam.KodVer & "z3DPowerhost"
    Const SlZ3DPeresech As String = DwgParam.KodVer & "z3DPeresech"
    Private pKoorX, pKoorY, pKoorZ As clsKoor
    '  Private wShirKosogorDwg As Double
    Private ObrazPow As PolyFaceMesh
    Function Rast(ByVal iT As Point3d) As Double
        Dim lpl As Plane = ObrazPow.GetPlane

        Return (iT.OrthoProject(lpl).DistanceTo(iT))
    End Function

    Shared Sub Ochistit()
        BazDwg.createNewLayer(SlZ3DPowerhnost)
        BazDwg.createNewLayer(SlZ3DPeresech)
        BazDwg.netSelectSet.OchistitSloj(SlZ3DPowerhnost)
        BazDwg.netSelectSet.OchistitSloj(SlZ3DPeresech)
    End Sub


    Private Sub Opred(ByVal iXreal As Double, ByVal iYreal As Double, ByVal Mashtab As Integer, ByVal Xdwg As Double, ByVal Ydwg As Double)
        pKoorX = New clsKoor(Mashtab, iXreal, Xdwg)
        pKoorY = New clsKoor(Mashtab, iYreal, Ydwg)
        pKoorZ = New clsKoor(Mashtab, 0, 0)

    End Sub
    ReadOnly Property koorX As clsKoor
        Get
            Return pKoorX
        End Get
    End Property
    ReadOnly Property koorY As clsKoor
        Get
            Return pKoorY
        End Get
    End Property
    ReadOnly Property koorZ As clsKoor
        Get
            Return pKoorZ
        End Get
    End Property

    Function GetDwg(ByVal iRealTchk As Double()) As Point3d
        Return New Point3d(pKoorX.GetDwg(iRealTchk(0)), pKoorY.GetDwg(iRealTchk(1)), pKoorZ.GetDwg(iRealTchk(2)))
    End Function
    Sub New(ByVal iRasstTrwiw As modRasstOp.wlRasst, ByVal Ugol As Double, ByVal iXreal As Double, ByVal iYreal As Double, _
            ByVal Mashtab As Integer, ByVal Xdwg As Double, ByVal Ydwg As Double)
        MyBase.New(iRasstTrwiw.Trassa, Ugol, iXreal, iYreal)
       

        Opred(iXreal, iYreal, Mashtab, Xdwg, Ydwg)
        '  wShirKosogorDwg = iRasstTrwiw.Uch(0).ShirinaPofil * pKoorX.Koeff
    End Sub



    Sub WiwestiSet()
        '' берем текущий документ базу данных и старт трансакции
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database

        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
            '' открываем таблицу блоков для чтения
            Dim acBlkTbl As BlockTable
            acBlkTbl = CType(acTrans.GetObject(acCurDb.BlockTableId, _
                                         OpenMode.ForRead), BlockTable)

            '' открываем в таблице блоков запись  Model space для записи
            Dim acBlkTblRec As BlockTableRecord
            acBlkTblRec = CType(acTrans.GetObject(acBlkTbl(BlockTableRecord.ModelSpace), _
                                            OpenMode.ForWrite), BlockTableRecord)

            '' создаем поли гранную сеть
            Dim acPFaceMesh As PolyFaceMesh = New PolyFaceMesh()
            acPFaceMesh.SetDatabaseDefaults()
            acPFaceMesh.Layer = SlZ3DPowerhnost
            '' добавляем в запись таблице блоков и в  трансакцию
            acBlkTblRec.AppendEntity(acPFaceMesh)
            acTrans.AddNewlyCreatedDBObject(acPFaceMesh, True)

            '' Создаем коллекцию точек в чертеже
            Dim acPts3dPFMesh As Point3dCollection = New Point3dCollection()
            For Each lmas As Double() In Tochki
                acPts3dPFMesh.Add(New Point3d(pKoorX.GetDwg(lmas(0)), pKoorY.GetDwg(lmas(1)), pKoorZ.GetDwg(lmas(2))))
            Next

            ''Создаем Vertex и добавляем в сеть и трансакцию

            For Each acPt3d As Point3d In acPts3dPFMesh
                Dim acPMeshVer As PolyFaceMeshVertex = New PolyFaceMeshVertex(acPt3d)
                acPFaceMesh.AppendVertex(acPMeshVer)
                acTrans.AddNewlyCreatedDBObject(acPMeshVer, True)
            Next
            ' Coздаем связки 
            For Each lintmas() As Short In Fase
                Dim acFaceRec1 As FaceRecord = New FaceRecord(lintmas(0), lintmas(1), lintmas(2), lintmas(3))
                acPFaceMesh.AppendFaceRecord(acFaceRec1)
                acTrans.AddNewlyCreatedDBObject(acFaceRec1, True)
            Next


            'Dim acFaceRec2 As FaceRecord = New FaceRecord(2, 3, 6, 5)
            'acPFaceMesh.AppendFaceRecord(acFaceRec2)
            'acTrans.AddNewlyCreatedDBObject(acFaceRec2, True)

            '' Open the active viewport
            Dim acVportTblRec As ViewportTableRecord
            Try
                acVportTblRec = CType(acTrans.GetObject(acDoc.Editor.ActiveViewportId, _
                                                            OpenMode.ForWrite), ViewportTableRecord)

                '' Rotate the view direction of the current viewport
                acVportTblRec.ViewDirection = New Vector3d(-1, -1, 1)
                acDoc.Editor.UpdateTiledViewportsFromDatabase()
            Catch ex As Exception

            End Try


            '' Save the new objects to the database
            acTrans.Commit()

        End Using

    End Sub
    Sub WiwestiPolyline3d()
        '' берем текущий документ базу данных и старт трансакции
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database

        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
            '' открываем таблицу блоков для чтения
            Dim acBlkTbl As BlockTable
            acBlkTbl = CType(acTrans.GetObject(acCurDb.BlockTableId, _
                                         OpenMode.ForRead), BlockTable)

            '' открываем в таблице блоков запись  Model space для записи
            Dim acBlkTblRec As BlockTableRecord
            acBlkTblRec = CType(acTrans.GetObject(acBlkTbl(BlockTableRecord.ModelSpace), _
                                            OpenMode.ForWrite), BlockTableRecord)

            '' создаем полилинию 
            Dim acPFaceMesh As Polyline3d = New Polyline3d()
            acPFaceMesh.SetDatabaseDefaults()
            acPFaceMesh.Layer = SlZ3DPowerhnost
            '' добавляем в запись таблице блоков и в  трансакцию
            acBlkTblRec.AppendEntity(acPFaceMesh)
            acTrans.AddNewlyCreatedDBObject(acPFaceMesh, True)

            '' Создаем коллекцию точек в чертеже
            Dim acPts3dPFMesh As Point3dCollection = New Point3dCollection()
            For I As Integer = 1 To Tochki.Count - 1 Step 3
                Dim lmas() As Double = Tochki(I)
                acPts3dPFMesh.Add(New Point3d(pKoorX.GetDwg(lmas(0)), pKoorY.GetDwg(lmas(1)), pKoorZ.GetDwg(lmas(2))))
            Next

            ''Создаем Vertex и добавляем в сеть и трансакцию

            For Each acPt3d As Point3d In acPts3dPFMesh
                Dim acPMeshVer As PolylineVertex3d = New PolylineVertex3d(acPt3d)
                acPFaceMesh.AppendVertex(acPMeshVer)
                acTrans.AddNewlyCreatedDBObject(acPMeshVer, True)
            Next

            acTrans.Commit()
        End Using

    End Sub
    Sub WiwestiProvis3d(ByVal iSp As List(Of Double()))
        '' берем текущий документ базу данных и старт трансакции
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database

        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
            '' открываем таблицу блоков для чтения
            Dim acBlkTbl As BlockTable
            acBlkTbl = CType(acTrans.GetObject(acCurDb.BlockTableId, _
                                         OpenMode.ForRead), BlockTable)

            '' открываем в таблице блоков запись  Model space для записи
            Dim acBlkTblRec As BlockTableRecord
            acBlkTblRec = CType(acTrans.GetObject(acBlkTbl(BlockTableRecord.ModelSpace), _
                                            OpenMode.ForWrite), BlockTableRecord)

            '' создаем полилинию 
            Dim acPFaceMesh As Polyline3d = New Polyline3d()
            acPFaceMesh.SetDatabaseDefaults()
            acPFaceMesh.Layer = dwgopor3D.SlZ3DProwod '' ? Уместно ли лучше перенести в параметры функции
            '' добавляем в запись таблице блоков и в  трансакцию
            acBlkTblRec.AppendEntity(acPFaceMesh)
            acTrans.AddNewlyCreatedDBObject(acPFaceMesh, True)

            '' Создаем коллекцию точек в чертеже
            Dim acPts3dPFMesh As Point3dCollection = New Point3dCollection()
            For Each el As Double() In iSp

                acPts3dPFMesh.Add(GetDwg(el))
            Next

            ''Создаем Vertex и добавляем в сеть и трансакцию

            For Each acPt3d As Point3d In acPts3dPFMesh
                Dim acPMeshVer As PolylineVertex3d = New PolylineVertex3d(acPt3d)
                acPFaceMesh.AppendVertex(acPMeshVer)
                acTrans.AddNewlyCreatedDBObject(acPMeshVer, True)
            Next

            acTrans.Commit()
        End Using

    End Sub
    Sub WiwestiPeresech()
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database

        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
            '' открываем таблицу блоков для чтения
            Dim acBlkTbl As BlockTable
            acBlkTbl = CType(acTrans.GetObject(acCurDb.BlockTableId, _
                                         OpenMode.ForRead), BlockTable)

            '' открываем в таблице блоков запись  Model space для записи
            Dim acBlkTblRec As BlockTableRecord
            acBlkTblRec = CType(acTrans.GetObject(acBlkTbl(BlockTableRecord.ModelSpace), _
                                            OpenMode.ForWrite), BlockTableRecord)

            '' создаем полилинию 

            Dim acPts3dPFMesh As Point3dCollection = New Point3dCollection()
            For I As Integer = 0 To SpPeresech.Count - 1
                Dim lmas() As Double = KoorPeresech(I)
                Dim lmasW(2) As Double
                lmasW(0) = lmas(0)
                lmasW(1) = lmas(1)
                If SpPeresech(I).Razm >= 0 Then
                    lmasW(2) = SpPeresech(I).Otmetki(SpPeresech(I).Razm)
                Else
                    lmasW(2) = lmas(2) + 0.5
                End If
                Dim St As New Point3d(pKoorX.GetDwg(lmas(0)), pKoorY.GetDwg(lmas(1)), pKoorZ.GetDwg(lmas(2)))
                Dim Et As New Point3d(pKoorX.GetDwg(lmasW(0)), pKoorY.GetDwg(lmasW(1)), pKoorZ.GetDwg(lmasW(2)))
                Dim pline As New Line(St, Et)
                pline.Layer = SlZ3DPeresech
                pline.LineWeight = LineWeight.LineWeight030
                acBlkTblRec.AppendEntity(pline)
                acTrans.AddNewlyCreatedDBObject(pline, True)
                Dim acText As DBText = New DBText()

                acText.SetDatabaseDefaults()

                acText.Position = Et

                acText.Height = 5
                acText.Layer = SlZ3DPeresech
                acText.TextString = SpPeresech(I).Opis
                acBlkTblRec.AppendEntity(acText)
                acTrans.AddNewlyCreatedDBObject(acText, True)
            Next

            ''Создаем Vertex и добавляем в сеть и трансакцию




            acTrans.Commit()
        End Using
    End Sub

End Class
