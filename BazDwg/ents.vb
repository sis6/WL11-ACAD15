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


''' <summary>
''' Coздание графических объектов в чертеже
''' </summary>
''' <remarks></remarks>
Public Class MakeEntities
#Region "Block"
    Public Shared Function WseAttributBlock(NameBlock As String) As List(Of String)
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        Dim lSpAttDef As New List(Of String)
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()

            Dim acBlkTbl As BlockTable
            acBlkTbl = CType(acTrans.GetObject(acCurDb.BlockTableId, OpenMode.ForRead), BlockTable)


            If acBlkTbl.Has(NameBlock) Then
                Dim acBlkTblRec As BlockTableRecord

                acBlkTblRec = CType(acTrans.GetObject(acBlkTbl.Item(NameBlock), OpenMode.ForRead), BlockTableRecord)
                If acBlkTblRec.HasAttributeDefinitions Then
                    For Each el As ObjectId In acBlkTblRec
                        Dim objDb As DBObject = acTrans.GetObject(el, OpenMode.ForRead)
                        If objDb.GetRXClass.DxfName = "ATTDEF" Then
                            Dim elAtrr As AttributeDefinition = CType(objDb, AttributeDefinition)
                            '   Application.ShowAlertDialog(Me.ToString & " Tag " & elAtrr.Tag & " = " & elAtrr.TextString)
                            lSpAttDef.Add(elAtrr.Tag)
                        End If



                    Next
                End If

                ' ' CType(ent, BlockReference).Name
            End If





        End Using
        Return lSpAttDef
    End Function
    Public Shared Function TextStringAttributBlock(NameBlock As String, iTag As String) As String
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        Dim lSpAttDef As New List(Of String)
        Dim lRezTextString As String = ""
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()

            Dim acBlkTbl As BlockTable
            acBlkTbl = CType(acTrans.GetObject(acCurDb.BlockTableId, OpenMode.ForRead), BlockTable)


            If acBlkTbl.Has(NameBlock) Then
                Dim acBlkTblRec As BlockTableRecord

                acBlkTblRec = CType(acTrans.GetObject(acBlkTbl.Item(NameBlock), OpenMode.ForRead), BlockTableRecord)
                If acBlkTblRec.HasAttributeDefinitions Then
                    For Each el As ObjectId In acBlkTblRec
                        Dim objDb As DBObject = acTrans.GetObject(el, OpenMode.ForRead)
                        If objDb.GetRXClass.DxfName = "ATTDEF" Then
                            Dim elAtrr As AttributeDefinition = CType(objDb, AttributeDefinition)
                            '   Application.ShowAlertDialog(Me.ToString & " Tag " & elAtrr.Tag & " = " & elAtrr.TextString)
                            If elAtrr.Tag = iTag Then
                                lRezTextString = elAtrr.TextString
                            End If

                        End If



                    Next
                End If

                ' ' CType(ent, BlockReference).Name
            End If





        End Using
        Return lRezTextString
    End Function
    Public Shared Function TextStringAttributBlockLista(NameList As String, NameBlock As String, iTag As String) As String
        Dim lsSet As SelectionSet = BazDwg.netSelectSet.WibratWListestawkiBlokow(NameList) 'выбираем все вставки в листе
        Dim lrezTextString As String = ""
        If lsSet IsNot Nothing Then
            '  если вставки присутствуют ищем нужный атрибут
            Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
            Dim acCurDb As Database = acDoc.Database
            Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()




                For Each el As ObjectId In lsSet.GetObjectIds
                    Dim ent As Entity = CType(acTrans.GetObject(el, OpenMode.ForRead), Entity) 'определили примитив
                    Dim entIns As BlockReference = CType(ent, BlockReference)  'кокретизировали до вставки
                    'определили сответствующую запись в таблице блоков 
                    Dim Lbl As BlockTableRecord
                    If entIns.IsDynamicBlock Then
                        Lbl = CType(acTrans.GetObject(entIns.DynamicBlockTableRecord, OpenMode.ForRead), BlockTableRecord)
                    Else
                        Lbl = CType(acTrans.GetObject(entIns.BlockTableRecord, OpenMode.ForRead), BlockTableRecord)
                    End If


                    Dim AttColl As AttributeCollection = entIns.AttributeCollection    'выбрали коллекцию аттрибутов
                    For Each elAtt As ObjectId In AttColl
                        Dim elAttEnt As AttributeReference = CType(acTrans.GetObject(elAtt, OpenMode.ForRead), AttributeReference)
                        If elAttEnt.Tag = iTag Then   '"-НАИМЕНОВАНИЕ_3" если нашли нужный атрибут то редактируем
                            '      Application.ShowAlertDialog(Me.ToString & " " & elAttEnt.TextString) ' CType(ent, BlockReference).Name
                            lrezTextString = elAttEnt.TextString
                            Exit For
                        End If

                    Next
                    '  Application.ShowAlertDialog(Me.ToString & "Имя блока " & Lbl.Name & " Atributow " & AttColl.Count) ' CType(ent, BlockReference).Name

                Next



            End Using
        End If
        Return lrezTextString
    End Function
    Public Shared Function WseBlock() As List(Of String)
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        Dim lSpImenBlock As New List(Of String)

        '' Start a transaction
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()

            '' Open the Block table for read
            Dim acBlkTbl As BlockTable
            acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId, OpenMode.ForRead)
            Dim lenum As SymbolTableEnumerator = acBlkTbl.GetEnumerator()
            Do While lenum.MoveNext
                Dim ltblRec As BlockTableRecord = acTrans.GetObject(lenum.Current, OpenMode.ForRead)
                If ltblRec.IsLayout Then Continue Do
                lSpImenBlock.Add(ltblRec.Name)

            Loop




            acTrans.Commit()
        End Using
        Return lSpImenBlock
    End Function
    Public Shared Function EstLiBlock(ByVal nameBl As String) As Boolean
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        Dim lpr As Boolean

        '' Start a transaction
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()

            '' Open the Block table for read
            Dim acBlkTbl As BlockTable
            acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId, _
                                         OpenMode.ForRead)
            'Dim acBlkTblRec As BlockTableRecord
            'acBlkTblRec = acTrans.GetObject(acBlkTbl(BlockTableRecord.ModelSpace), _
            '                                OpenMode.ForRead)

            lpr = acBlkTbl.Has(nameBl)


            acTrans.Commit()
        End Using
        Return lpr
    End Function
    Public Shared Function CreateWstawkBlock(ByVal Twst As Point3d, ByVal NameBl As String, Optional ByVal Ipoworot As Double = 0) As ObjectId
        '' Get the current database
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        Dim objIdRef As ObjectId

        '' Start a transaction
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()

            '' Open the Block table for read
            Dim acBlkTbl As BlockTable
            acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId, _
                                         OpenMode.ForRead)
            Dim acBlkTblRec As BlockTableRecord
            acBlkTblRec = acTrans.GetObject(acBlkTbl(BlockTableRecord.ModelSpace), _
                                            OpenMode.ForWrite)

            If acBlkTbl.Has(NameBl) Then
                Dim lBlRef As BlockReference
                Dim lblockId As ObjectId = acBlkTbl(NameBl)
                lBlRef = New BlockReference(Twst, lblockId)
                If Math.Abs(Ipoworot) > 0 Then lBlRef.Rotation = Ipoworot
                'For Each el As AttributeReference In lBlRef.AttributeCollection

                'Next
                objIdRef = acBlkTblRec.AppendEntity(lBlRef)
                acTrans.AddNewlyCreatedDBObject(lBlRef, True)
            Else
                Application.ShowAlertDialog("CreateWstawkBlock " & " Нет  блока " & NameBl)
            End If
            '  acBlkTbl.Ha()

            ' Create the MText annotation



            '' Commit the changes and dispose of the transaction
            acTrans.Commit()
        End Using
        Return objIdRef
    End Function
    Public Shared Function CreateWstawkBlockSAttr(ByVal Twst As Point3d, ByVal NameBl As String, ByVal NameAttr As String, ByVal iStrAttr As String) As ObjectId
        '' Get the current database
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        Dim objIdRef As ObjectId

        '' начали трансакцию
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()

            '' Открыли таблицу всех блоков
            Dim acBlkTbl As BlockTable = acTrans.GetObject(acCurDb.BlockTableId, OpenMode.ForRead)
            'Взяли модель как блок для записи
            Dim acBlkTblRec As BlockTableRecord = acTrans.GetObject(acBlkTbl(BlockTableRecord.ModelSpace), OpenMode.ForWrite)

            If acBlkTbl.Has(NameBl) Then
                Dim lBlRef As BlockReference
                Dim lblockId As ObjectId = acBlkTbl(NameBl)
                Dim OpredBlock As BlockTableRecord = TryCast(lblockId.GetObject(OpenMode.ForRead), BlockTableRecord)

                lBlRef = New BlockReference(Twst, lblockId)
                'For Each el As AttributeReference In lBlRef.AttributeCollection

                'Next
                objIdRef = acBlkTblRec.AppendEntity(lBlRef)
                acTrans.AddNewlyCreatedDBObject(lBlRef, True)
                Dim iskA As AttributeDefinition = Nothing
                If OpredBlock.HasAttributeDefinitions Then
                    If OpredBlock.IsDynamicBlock Then
                        Dim dynBrefColl As DynamicBlockReferencePropertyCollection = lBlRef.DynamicBlockReferencePropertyCollection
                        For Each prop As DynamicBlockReferenceProperty In dynBrefColl

                            '  Application.ShowAlertDialog(prop.PropertyName & " " & prop.Value.ToString)
                        Next
                    End If
                    For Each id As ObjectId In OpredBlock
                        If id.ObjectClass.Name = "AcDbAttributeDefinition" Then
                            Dim obj As DBObject = id.GetObject(OpenMode.ForRead)
                            Dim attDef As AttributeDefinition = TryCast(obj, AttributeDefinition)
                            If attDef.Tag = NameAttr Then
                                iskA = attDef
                            End If

                        End If

                        '  Application.ShowAlertDialog(id.ObjectClass.Name)

                    Next

                End If
                If iskA IsNot Nothing Then
                    Using attRef As New AttributeReference()


                        attRef.SetAttributeFromBlock(iskA, lBlRef.BlockTransform)

                        attRef.TextString = iStrAttr

                        'Add the AttributeReference to the BlockReference

                        lBlRef.AttributeCollection.AppendAttribute(attRef)


                        acTrans.AddNewlyCreatedDBObject(attRef, True)

                    End Using
                End If


            Else
                Application.ShowAlertDialog("CreateWstawkBlock " & " Нет  блока " & NameBl)
            End If
            '  acBlkTbl.Ha()

            ' Create the MText annotation



            '' Commit the changes and dispose of the transaction
            acTrans.Commit()
        End Using
        Return objIdRef
    End Function
#End Region
    Public Shared Function CreateLeader(ByVal Twst As Point3d, ByVal h As Double, Optional ByVal StrTxt As String = "") As ObjectId

        '' Get the current database
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        Dim objled As ObjectId
        Dim acMText As MText
        '' Start a transaction
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()

            '' Open the Block table for read
            Dim acBlkTbl As BlockTable
            acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId, _
                                         OpenMode.ForRead)

            '' Open the Block table record Model space for write
            Dim acBlkTblRec As BlockTableRecord
            acBlkTblRec = acTrans.GetObject(acBlkTbl(BlockTableRecord.ModelSpace), _
                                            OpenMode.ForWrite)
            ' Create the MText annotation
            If String.IsNullOrEmpty(StrTxt) Then StrTxt = "noy"
            acMText = New MText()
            acMText.SetDatabaseDefaults()
            acMText.Contents = StrTxt
            acMText.Location = New Point3d(Twst.X, Twst.Y - 2, 0)
            acMText.Height = h - 2

            '' Add the new object to Model space and the transaction
            acBlkTblRec.AppendEntity(acMText)
            acTrans.AddNewlyCreatedDBObject(acMText, True)




            '' Create the leader
            Dim acLdr As Leader = New Leader()
            acLdr.SetDatabaseDefaults()
            acLdr.AppendVertex(Twst)
            acLdr.AppendVertex(New Point3d(Twst.X, Twst.Y - h, 0))
            acLdr.AppendVertex(New Point3d(Twst.X + 2 * h, Twst.Y - h, 0))
            acLdr.HasArrowHead = True

            '' Add the new object to Model space and the transaction
            objled = acBlkTblRec.AppendEntity(acLdr)
            acTrans.AddNewlyCreatedDBObject(acLdr, True)
            ' Attach the annotation after the leader object is added

            acLdr.Annotation = acMText.ObjectId
            acLdr.EvaluateLeader()


            '' Commit the changes and dispose of the transaction
            acTrans.Commit()
        End Using
        Return objled
    End Function
    Public Shared Function CreateLeader(ByVal Twst As Point3d, ByVal h As Double, ByVal objTxt As ObjectId) As ObjectId
        '' Get the current database
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        Dim objled As ObjectId

        '' Start a transaction
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()

            '' Open the Block table for read
            Dim acBlkTbl As BlockTable
            acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId, _
                                         OpenMode.ForRead)

            '' Open the Block table record Model space for write
            Dim acBlkTblRec As BlockTableRecord
            acBlkTblRec = acTrans.GetObject(acBlkTbl(BlockTableRecord.ModelSpace), _
                                            OpenMode.ForWrite)
            ' Create the MText annotation




            '' Create the leader
            Dim acLdr As Leader = New Leader()
            acLdr.SetDatabaseDefaults()
            acLdr.AppendVertex(Twst)
            acLdr.AppendVertex(New Point3d(Twst.X, Twst.Y - h, 0))
            ' acLdr.AppendVertex(New Point3d(Twst.X + 1.1, Twst.Y - h, 0))
            acLdr.HasArrowHead = True

            '' Add the new object to Model space and the transaction
            objled = acBlkTblRec.AppendEntity(acLdr)
            acTrans.AddNewlyCreatedDBObject(acLdr, True)
            ' Attach the annotation after the leader object is added

            acLdr.Annotation = objTxt
            acLdr.EvaluateLeader()


            '' Commit the changes and dispose of the transaction
            acTrans.Commit()
        End Using
        Return objled
    End Function
    Public Shared Function CreateLine(ByVal Xb As Double, ByVal Yb As Double, ByVal Xe As Double, ByVal Ye As Double) As ObjectId
        Dim startpt As New Point3d(Xb, Yb, 0.0)
        Dim endpt As New Point3d(Xe, Ye, 0.0)
        Dim pLine As New Line(startpt, endpt)

        Dim lineid As ObjectId
        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        '  Dim lock As DocumentLock = doc.LockDocument()

        Dim db As Database = doc.Database



        Dim tm As DBTransMan = db.TransactionManager
        Dim ta As Transaction = tm.StartTransaction()
        Try
            Dim bt As BlockTable = tm.GetObject(db.BlockTableId, OpenMode.ForRead, False)
            Dim btr As BlockTableRecord = tm.GetObject(bt(BlockTableRecord.ModelSpace), OpenMode.ForWrite, False)
            lineid = btr.AppendEntity(pLine)
            tm.AddNewlyCreatedDBObject(pLine, True)
            ta.Commit()
        Finally
            ta.Dispose()
            '  lock.Dispose()
        End Try
        Return lineid
    End Function
    Public Shared Function CreateNakl(ByVal X As Double, ByVal Y As Double, ByVal Dlina As Double, ByVal Ugol As Double) As ObjectId
        'Выводит отрезок длиной Dlina под углом Ugol , середина точка X,Y
        Dim Dcos, Dsin, lxb, lyb, lxe, lye As Double
        Dlina /= 2
        Dcos = Dlina * Math.Cos(Ugol)
        Dsin = Dlina * Math.Sin(Ugol)

        lxb = X + Dcos
        lyb = Y + Dsin
        lxe = X - Dcos
        lye = Y - Dsin
        Return CreateLine(lxb, lyb, lxe, lye)

    End Function
    Public Shared Function CreateNakl(ByVal X As Double, ByVal Y As Double, ByVal DlinaP As Double, ByVal DlinaM As Double, ByVal Ugol As Double) As ObjectId
        'Выводит отрезок длиной DlinaP+DlinaM под углом Ugol ,  точка X,Y делит в соотношение DlinaP : DlinaM
        Dim Dcos, Dsin, lxb, lyb, lxe, lye As Double

        Dcos = Math.Cos(Ugol)
        Dsin = Math.Sin(Ugol)

        lxb = X + DlinaP * Dcos
        lyb = Y + DlinaP * Dsin
        lxe = X - DlinaM * Dcos
        lye = Y - DlinaM * Dsin
        Return CreateLine(lxb, lyb, lxe, lye)

    End Function
    Public Shared Function CreateNakl(ByVal X As Double, ByVal Y As Double, ByVal Dlina As Double, ByVal Ugol As Double, ByRef Xe As Double, ByRef ye As Double) As ObjectId
        'Выводит отрезок длиной Dlina под углом Ugol , из точки X,Y Xe ye конечная точка
        Dim Dcos, Dsin As Double

        Dcos = Math.Cos(Ugol)
        Dsin = Math.Sin(Ugol)


        Xe = X - Dlina * Dcos
        ye = Y - Dlina * Dsin
        Return CreateLine(X, Y, Xe, ye)

    End Function
    Public Shared Function CreateLine(ByVal Xb As Double, ByVal Yb As Double, ByVal Xe As Double, ByVal Ye As Double, ByVal Opis() As String) As ObjectId
        Dim startpt As New Point3d(Xb, Yb, 0.0)
        Dim endpt As New Point3d(Xe, Ye, 0.0)
        Dim pLine As New Line(startpt, endpt)
        clsXDATA.SetPoMasStrok(pLine, Opis)
        Dim lineid As ObjectId
        Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database
        Dim tm As DBTransMan = db.TransactionManager
        Dim ta As Transaction = tm.StartTransaction()
        Try
            Dim bt As BlockTable = tm.GetObject(db.BlockTableId, OpenMode.ForRead, False)
            Dim btr As BlockTableRecord = tm.GetObject(bt(BlockTableRecord.ModelSpace), OpenMode.ForWrite, False)
            lineid = btr.AppendEntity(pLine)
            tm.AddNewlyCreatedDBObject(pLine, True)
            ta.Commit()
        Finally
            ta.Dispose()
        End Try
        Return lineid
    End Function
    Public Shared Function CreateLine(ByVal startpt As Point3d, ByVal endpt As Point3d) As ObjectId


        Dim pLine As New Line(startpt, endpt)

        Dim lineid As ObjectId
        Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database
        Dim tm As DBTransMan = db.TransactionManager
        Dim ta As Transaction = tm.StartTransaction()
        Try
            Dim bt As BlockTable = tm.GetObject(db.BlockTableId, OpenMode.ForRead, False)
            Dim btr As BlockTableRecord = tm.GetObject(bt(BlockTableRecord.ModelSpace), OpenMode.ForWrite, False)

            lineid = btr.AppendEntity(pLine)
            tm.AddNewlyCreatedDBObject(pLine, True)
            ta.Commit()
        Finally
            ta.Dispose()
        End Try
        Return lineid
    End Function
    Public Shared Function CreateMasLineY(ByVal mas As Point2dCollection, ByVal Y As Double) As ObjectIdCollection
        'Dim startpt As New Point3d(Xb, Yb, 0.0)
        'Dim endpt As New Point3d(Xe, Ye, 0.0)
        Dim pLine As Line
        Dim TekPoint As Point2d
        Dim RetColl As New ObjectIdCollection

        Dim lineid As ObjectId
        Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database
        Dim tm As DBTransMan = db.TransactionManager
        Dim ta As Transaction = tm.StartTransaction()
        Try
            Dim bt As BlockTable = tm.GetObject(db.BlockTableId, OpenMode.ForRead, False)
            For Each TekPoint In mas
                Dim btr As BlockTableRecord = tm.GetObject(bt(BlockTableRecord.ModelSpace), OpenMode.ForWrite, False)
                pLine = New Line(New Point3d(TekPoint.X, TekPoint.Y, 0), New Point3d(TekPoint.X, Y, 0))
                lineid = btr.AppendEntity(pLine)
                tm.AddNewlyCreatedDBObject(pLine, True)
                RetColl.Add(lineid)
            Next
            ta.Commit()
        Finally
            ta.Dispose()
        End Try
        Return RetColl
    End Function
    Public Shared Function CreateLwPolyline(ByVal Mas As Point2dCollection) As ObjectId

        Dim pline As New Polyline 'Poly2dType.SimplePoly, Mas, False, 1, 1, b
        Dim PlineId As ObjectId
        Dim i As Integer
        For i = 0 To Mas.Count - 1
            pline.AddVertexAt(i, Mas.Item(i), 0.0, 0, 0)
        Next

        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        '  Dim lock As DocumentLock = doc.LockDocument()
        Dim db As Database = doc.Database

        Dim tm As DBTransMan = db.TransactionManager
        'start a transaction
        Dim ta As Transaction = tm.StartTransaction
        Try
            Dim bt As BlockTable = tm.GetObject(db.BlockTableId, OpenMode.ForRead, False)
            Dim btr As BlockTableRecord = tm.GetObject(bt(BlockTableRecord.ModelSpace), OpenMode.ForWrite, False)

            PlineId = btr.AppendEntity(pline)
            tm.AddNewlyCreatedDBObject(pline, True)
            ta.Commit()
        Finally
            ta.Dispose()
            '  lock.Dispose()
        End Try
        Return PlineId
    End Function
    Public Shared Function CreateLwPolyline(ByVal Mas As Point2dCollection, ByVal Ugol As Double, ByVal BazePoint As Point3d) As ObjectId
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim pline As New Polyline 'Poly2dType.SimplePoly, Mas, False, 1, 1, b
        Dim PlineId As ObjectId
        Dim i As Integer
        For i = 0 To Mas.Count - 1
            pline.AddVertexAt(i, Mas.Item(i), 0.0, 0, 0)
        Next
        Dim curUCSMatrix As Matrix3d = acDoc.Editor.CurrentUserCoordinateSystem
        Dim curUCS As CoordinateSystem3d = curUCSMatrix.CoordinateSystem3d
        pline.TransformBy(Matrix3d.Rotation(Ugol, curUCS.Zaxis, BazePoint))
        Dim db As Database = acDoc.Database

        Dim tm As DBTransMan = db.TransactionManager
        'start a transaction
        Dim ta As Transaction = tm.StartTransaction
        Try
            Dim bt As BlockTable = tm.GetObject(db.BlockTableId, OpenMode.ForRead, False)
            Dim btr As BlockTableRecord = tm.GetObject(bt(BlockTableRecord.ModelSpace), OpenMode.ForWrite, False)

            PlineId = btr.AppendEntity(pline)
            tm.AddNewlyCreatedDBObject(pline, True)
            ta.Commit()
        Finally
            ta.Dispose()
        End Try
        Return PlineId
    End Function
    Public Shared Function CreateLwPolyline(ByVal Mas As Point2dCollection, ByVal bug As Double, ByVal shirB As Double, ByVal shirE As Double) As ObjectId

        Dim pline As New Polyline 'Poly2dType.SimplePoly, Mas, False, 1, 1, b
        Dim PlineId As ObjectId
        Dim i As Integer
        For i = 0 To Mas.Count - 1
            pline.AddVertexAt(i, Mas.Item(i), bug, shirB, shirE)
        Next

        Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database

        Dim tm As DBTransMan = db.TransactionManager
        'start a transaction
        Dim ta As Transaction = tm.StartTransaction
        Try
            Dim bt As BlockTable = tm.GetObject(db.BlockTableId, OpenMode.ForRead, False)
            Dim btr As BlockTableRecord = tm.GetObject(bt(BlockTableRecord.ModelSpace), OpenMode.ForWrite, False)

            PlineId = btr.AppendEntity(pline)
            tm.AddNewlyCreatedDBObject(pline, True)
            ta.Commit()
        Finally
            ta.Dispose()
        End Try
        Return PlineId
    End Function
    Public Shared Function CreateSpline(ByVal Mas As Point3dCollection) As ObjectId

        Dim pline As New Spline(Mas, 7, 0.01)  'Poly2dType.SimplePoly, Mas, False, 1, 1, b
        Dim PlineId As ObjectId

        Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database

        Dim tm As DBTransMan = db.TransactionManager
        'start a transaction
        Dim ta As Transaction = tm.StartTransaction
        Try
            Dim bt As BlockTable = tm.GetObject(db.BlockTableId, OpenMode.ForRead, False)
            Dim btr As BlockTableRecord = tm.GetObject(bt(BlockTableRecord.ModelSpace), OpenMode.ForWrite, False)

            PlineId = btr.AppendEntity(pline)
            tm.AddNewlyCreatedDBObject(pline, True)
            ta.Commit()
        Finally
            ta.Dispose()
        End Try
        Return PlineId
    End Function
    Public Shared Function CreateCircle(ByVal X As Double, ByVal Y As Double, ByVal Rad As Double) As ObjectId
        Dim center As New Point3d(X, Y, 0.0)
        Dim normal As New Vector3d(0.0, 0.0, 1.0)
        Dim pcirc As New Circle(center, normal, Rad)
        Dim Circid As ObjectId
        '   pcirc.Thickness = Rad / 2.0
        Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database
        Dim tm As DBTransMan = db.TransactionManager
        'start a transaction
        Dim ta As Transaction = tm.StartTransaction
        Try
            Dim bt As BlockTable = tm.GetObject(db.BlockTableId, OpenMode.ForRead, False)
            Dim btr As BlockTableRecord = tm.GetObject(bt(BlockTableRecord.ModelSpace), OpenMode.ForWrite, False)
            Circid = btr.AppendEntity(pcirc)
            tm.AddNewlyCreatedDBObject(pcirc, True)
            ta.Commit()
        Finally
            ta.Dispose()
        End Try
        Return Circid
    End Function



End Class
Public Class MakeNeGraf


    Shared Function InsertWGroup(ByVal objIds As ObjectIdCollection, ByVal keyName As String, ByVal pGroupName As System.String) As ObjectId
        Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database
        Dim tm As DBTransMan = db.TransactionManager
        'start a transaction

        Dim ta As Transaction = tm.StartTransaction()
        Dim gp As Group, IndGr As ObjectId
        Try

            Dim dict As DBDictionary = tm.GetObject(db.GroupDictionaryId, OpenMode.ForRead, True)
            If dict.Contains(keyName) Then
                IndGr = dict.GetAt(keyName)
                gp = CType(ta.GetObject(IndGr, OpenMode.ForWrite), Group)
            Else
                dict.UpgradeOpen()
                gp = New Group(pGroupName, True)
                IndGr = dict.SetAt(keyName, gp)
                tm.AddNewlyCreatedDBObject(gp, True)
                gp = CType(IndGr.GetObject(OpenMode.ForWrite), Group)
            End If



            Dim thisId As ObjectId
            For Each thisId In objIds
                gp.Append(thisId)
            Next

            ta.Commit()
        Finally
            ta.Dispose()
        End Try
        Return IndGr
    End Function
    Shared Sub DobWGroupXdata(ByVal keyName As String, ByVal masStrDan As System.String())
        Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database
        Dim tm As DBTransMan = db.TransactionManager
        'start a transaction

        Dim ta As Transaction = tm.StartTransaction()
        Dim gp As Group, IndGr As ObjectId
        Try

            Dim dict As DBDictionary = tm.GetObject(db.GroupDictionaryId, OpenMode.ForRead, True)
            If dict.Contains(keyName) Then
                IndGr = dict.GetAt(keyName)
                gp = CType(ta.GetObject(IndGr, OpenMode.ForWrite), Group)
            Else
                dict.UpgradeOpen()
                gp = New Group("r" & keyName, True)
                IndGr = dict.SetAt(keyName, gp)
                tm.AddNewlyCreatedDBObject(gp, True)
                gp = CType(IndGr.GetObject(OpenMode.ForWrite), Group)
            End If

            clsXDATA.SetPoMasStrok(gp, masStrDan)



            ta.Commit()
        Finally
            ta.Dispose()
        End Try

    End Sub

    Shared Function ChitXdataIzGroup(ByVal keyName As String) As System.String()
        Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database
        Dim tm As DBTransMan = db.TransactionManager
        Dim masStr() As String = {""}
        'start a transaction

        Dim ta As Transaction = tm.StartTransaction()
        Dim gp As Group, IndGr As ObjectId
        Try

            Dim dict As DBDictionary = tm.GetObject(db.GroupDictionaryId, OpenMode.ForRead, True)
            If dict.Contains(keyName) Then
                IndGr = dict.GetAt(keyName)
                gp = CType(ta.GetObject(IndGr, OpenMode.ForRead), Group)
                masStr = clsXDATA.GetMasStrok(gp)
            End If





            ta.Commit()
        Finally
            ta.Dispose()
        End Try
        Return masStr
    End Function
    Shared Sub DeleteGroup(ByVal keyName As String)
        Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database
        Dim tm As DBTransMan = db.TransactionManager
        'start a transaction

        Dim ta As Transaction = tm.StartTransaction()
        '  Dim gp As Group, IndGr As ObjectId
        Try

            Dim dict As DBDictionary = tm.GetObject(db.GroupDictionaryId, OpenMode.ForWrite, True)
            If dict.Contains(keyName) Then
                dict.Remove(keyName)


            End If




            ta.Commit()
        Finally
            ta.Dispose()
        End Try
    End Sub
    Shared Sub DeleteIzGroup(ByVal keyName As String)
        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        ' Dim lock As DocumentLock = doc.LockDocument()
        Dim db As Database = doc.Database
        Dim tm As DBTransMan = db.TransactionManager
        'start a transaction

        Dim ta As Transaction = tm.StartTransaction()
        Dim gp As Group, IndGr As ObjectId

        Try

            Dim dict As DBDictionary = tm.GetObject(db.GroupDictionaryId, OpenMode.ForRead, True)
            If dict.Contains(keyName) Then
                IndGr = dict.GetAt(keyName)
                gp = CType(ta.GetObject(IndGr, OpenMode.ForWrite), Group)
                Dim thisId As ObjectId
                For Each thisId In gp.GetAllEntityIds
                    thisId.GetObject(OpenMode.ForWrite).Erase()
                Next

                gp.Clear()

            End If



            ta.Commit()
        Finally
            ' lock.Dispose()
            ta.Dispose()
        End Try
    End Sub

    Public Sub New()

    End Sub
End Class
'Public Class Znaki
'    Public Const Kor3 As Double = 1.7320508
'    Public Const Kor2 As Double = 1.41421356
'    Public Shared Function CreateTreg(ByVal X As Double, ByVal Y As Double, ByVal L As Double, ByVal H As Double) As ObjectId
'        'Выводится треугольник вершина вниз высота Н основание 2L
'        Dim mas As New Point2dCollection
'        mas.Add(New Point2d(X, Y))
'        mas.Add(New Point2d(X - L, Y + H))
'        mas.Add(New Point2d(X + L, Y + H))
'        mas.Add(New Point2d(X, Y))
'        Return MakeEntities.CreateLwPolyline(mas)

'    End Function
'    Public Shared Function CreateTregW(ByVal X As Double, ByVal Y As Double, ByVal L As Double, ByVal H As Double) As ObjectId
'        'Выводится треугольник вершина вверх высота Н основание 2L
'        Dim mas As New Point2dCollection
'        mas.Add(New Point2d(X, Y + H))
'        mas.Add(New Point2d(X - L, Y))
'        mas.Add(New Point2d(X + L, Y))
'        mas.Add(New Point2d(X, Y + H))
'        Return MakeEntities.CreateLwPolyline(mas)

'    End Function
'    Public Shared Function CreateKrug(ByVal X As Double, ByVal Y As Double, ByVal Rad As Double) As ObjectId
'        Dim mas As New Point2dCollection
'        mas.Add(New Point2d(X, Y - 0.5 * Rad))
'        mas.Add(New Point2d(X, Y + 0.5 * Rad))
'        mas.Add(New Point2d(X, Y - 0.5 * Rad))
'        Return CreateEntities.MakeEntities.CreateLwPolyline(mas, 1.0, Rad, Rad)
'    End Function
'    Public Shared Function CreatePrTreg(ByVal X As Double, ByVal Y As Double, ByVal rwp As Double, ByVal Ugol As Double) As ObjectId
'        'Выводится треугольник вершина вниз высота Н основание 2L
'        Dim mas As New Point2dCollection
'        Dim Pointb As New Point2d(X, Y + 2 * rwp)
'        mas.Add(Pointb)
'        mas.Add(New Point2d(X - Kor3 * rwp, Y - rwp))
'        mas.Add(New Point2d(X + Kor3 * rwp, Y - rwp))
'        mas.Add(Pointb)
'        'Dim ok As Entity
'        'Dim matr As Matrix2d

'        Return (MakeEntities.CreateLwPolyline(mas, Ugol, New Point3d(X, Y, 0)))

'    End Function
'End Class
Public Class MakeEntitesLista
    Public Shared Function CreateLine(ByVal Xb As Double, ByVal Yb As Double, ByVal Xe As Double, ByVal Ye As Double, ByVal Namelist As String) As ObjectId
        Dim startpt As New Point3d(Xb, Yb, 0.0)
        Dim endpt As New Point3d(Xe, Ye, 0.0)
        Dim pLine As New Line(startpt, endpt)

        Dim lineid As ObjectId
        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        '  Dim lock As DocumentLock = doc.LockDocument()

        Dim db As Database = doc.Database



        Dim tm As DBTransMan = db.TransactionManager
        Dim ta As Transaction = tm.StartTransaction()
        Try
            Dim bt As BlockTable = tm.GetObject(db.BlockTableId, OpenMode.ForRead, False)
            Dim btr As BlockTableRecord = tm.GetObject(bt(clsList.nameBlockLista(Namelist)), OpenMode.ForWrite, False)
            lineid = btr.AppendEntity(pLine)
            tm.AddNewlyCreatedDBObject(pLine, True)
            ta.Commit()
        Finally
            ta.Dispose()
            '  lock.Dispose()
        End Try
        Return lineid
    End Function
    Private Shared Function UstStilT(ByVal lacTrans As Transaction, ByVal lDb As Database, ByVal nameTablStil As String) As ObjectId
        'функция проверяет наличие табличного стиля с именем
        Dim tst As DBDictionary   'устанваем стиль текста
        tst = lacTrans.GetObject(lDb.TableStyleDictionaryId, OpenMode.ForRead) ' извлекли словарь табличных стилей 
        If tst.Contains(nameTablStil) Then
            Return tst.GetAt(nameTablStil)
        Else
            Application.ShowAlertDialog("UstStilT" & "  отсутствует  стиль таблиц " & nameTablStil & "  в чертеже ")
            Return ObjectId.Null
        End If

    End Function
    ''' <summary>
    ''' Создает таблицу в пространстве модели илиста
    ''' </summary>
    ''' <param name="Position"> точка вывода таблиц верхней правый угол </param>
    ''' <param name="ShirColums">  ширина колонок </param>
    ''' <param name="masStr"> выводимые данные </param>
    ''' <param name="Zagolowok">заголовок таблицы </param>
    ''' <param name="Namelist">имя лист если пуст то модель </param>
    ''' <returns>Возвращает iD созданой таблицы </returns>
    ''' <remarks></remarks>
    Public Shared Function CreateTable(ByVal Position As Point3d, ByVal ShirColums As Double, ByVal masStr As String(,), ByVal Zagolowok As String, ByVal Namelist As String) As ObjectId
        If Not String.IsNullOrEmpty(Namelist) Then
            Dim lnameBlockLista As String = clsList.nameBlockLista(Namelist)
            If String.IsNullOrEmpty(lnameBlockLista) Then
                Application.ShowAlertDialog("MakeEntitesLista" & "  CreateTable " & " Лист " & Namelist & " отсутствует в чертеже ")
                Return Nothing
            End If

        End If

        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = doc.Database
        Dim tb As New Table()
        Dim lNumrows = masStr.GetUpperBound(0)
        Dim lnumColumns = masStr.GetUpperBound(1)
        '    Application.ShowAlertDialog("MakeEntitesLista " & "CreateTable Ctrok " & lNumrows & " Столбцов " & lnumColumns)


        tb.SetSize(lNumrows + 2, lnumColumns + 1) 'устанавливаем количество строк и столбцов в таблице. Для секщл 2 так как добавляем заголовок 

        '     tb.SetRowHeight(4.0)
        tb.SetColumnWidth(ShirColums)
        tb.Position = Position
        tb.Cells(0, 0).TextString = Zagolowok

        For I As Integer = 1 To tb.Rows.Count - 1
            For J As Integer = 0 To tb.Columns.Count - 1

                '  tb.Cells(I, J).TextHeight = 2.0
                tb.Cells(I, J).TextString = masStr(I - 1, J)
                tb.Cells(I, J).Alignment = CellAlignment.MiddleCenter

            Next
        Next

        tb.GenerateLayout()
        Dim TbId As ObjectId
        Dim tm As DBTransMan = db.TransactionManager
        Dim ta As Transaction = tm.StartTransaction()
        Using ta
            tb.TableStyle = UstStilT(ta, db, "UgESP")
            If tb.TableStyle = ObjectId.Null Then tb.TableStyle = db.Tablestyle
            Dim bt As BlockTable = tm.GetObject(db.BlockTableId, OpenMode.ForRead, False)
            Dim btr As BlockTableRecord
            If String.IsNullOrEmpty(Namelist) Then
                btr = tm.GetObject(bt(BlockTableRecord.ModelSpace), OpenMode.ForWrite, False)
            Else
                btr = tm.GetObject(bt(clsList.nameBlockLista(Namelist)), OpenMode.ForWrite, False)
            End If

            TbId = btr.AppendEntity(tb)
            tm.AddNewlyCreatedDBObject(tb, True)
            ta.Commit()


            Return TbId

        End Using

    End Function

    ''' <summary>
    ''' Создает таблицу в пространстве модели илиста
    ''' </summary>
    ''' <param name="Position"> точка вывода таблиц верхней правый угол </param>
    ''' <param name="ShirColums"> массив ширина колонок </param>
    ''' <param name="masStr"> выводимые данные </param>
    ''' <param name="Zagolowok">заголовок таблицы </param>
    ''' <param name="Namelist">имя лист если пуст то модель </param>
    ''' <returns>Возвращает iD созданой таблицы </returns>
    ''' <remarks></remarks>
    Public Shared Function CreateTable(ByVal Position As Point3d, ByVal ShirColums As Double(), ByVal masStr As String(,), ByVal Zagolowok As String, ByVal Namelist As String) As ObjectId
        If Not String.IsNullOrEmpty(Namelist) Then
            Dim lnameBlockLista As String = clsList.nameBlockLista(Namelist)
            If String.IsNullOrEmpty(lnameBlockLista) Then
                Application.ShowAlertDialog("MakeEntitesLista" & "  CreateTable " & " Лист " & Namelist & " отсутствует в чертеже ")
                Return Nothing
            End If

        End If

        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = doc.Database
        Dim tb As New Table()
        Dim lNumrows = masStr.GetUpperBound(0)
        Dim lnumColumns = masStr.GetUpperBound(1)
        '    Application.ShowAlertDialog("MakeEntitesLista " & "CreateTable Ctrok " & lNumrows & " Столбцов " & lnumColumns)
        '   tb.TableStyle = db.Tablestyle

        tb.SetSize(lNumrows + 2, lnumColumns + 1) 'устанавливаем количество строк и столбцов в таблице. Для секщл 2 так как добавляем заголовок 
        tb.SetColumnWidth(30)
        '     tb.SetRowHeight(4.0)
        Dim Istb As Integer = 0
        For Each eD As Double In ShirColums
            ' tb.SetColumnWidth(Istb, ShirColums(Istb))
            tb.Columns(Istb).Width = eD
            If Istb < lnumColumns Then
                Istb += 1
            End If
        Next

        tb.Position = Position
        tb.Cells(0, 0).TextString = Zagolowok

        For I As Integer = 1 To tb.Rows.Count - 1
            For J As Integer = 0 To tb.Columns.Count - 1

                '  tb.Cells(I, J).TextHeight = 2.0
                tb.Cells(I, J).TextString = masStr(I - 1, J)
                tb.Cells(I, J).Alignment = CellAlignment.MiddleCenter

            Next
        Next

        tb.GenerateLayout()
        Dim TbId As ObjectId
        Dim tm As DBTransMan = db.TransactionManager
        Dim ta As Transaction = tm.StartTransaction()
        Using ta
            tb.TableStyle = UstStilT(ta, db, "UgESP")
            If tb.TableStyle = ObjectId.Null Then tb.TableStyle = db.Tablestyle
            Dim bt As BlockTable = tm.GetObject(db.BlockTableId, OpenMode.ForRead, False)
            Dim btr As BlockTableRecord
            If String.IsNullOrEmpty(Namelist) Then
                btr = tm.GetObject(bt(BlockTableRecord.ModelSpace), OpenMode.ForWrite, False)
            Else
                btr = tm.GetObject(bt(clsList.nameBlockLista(Namelist)), OpenMode.ForWrite, False)
            End If

            TbId = btr.AppendEntity(tb)
            tm.AddNewlyCreatedDBObject(tb, True)
            ta.Commit()


            Return TbId

        End Using

    End Function
End Class



