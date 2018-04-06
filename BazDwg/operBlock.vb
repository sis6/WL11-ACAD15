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

Public Module operBlock

    Function OOtlad(ByVal x As Double, ByVal y As Double, ByVal strblockName As String, ByVal strLayerName As String) As ObjectId
        Using db As Database = Application.DocumentManager.MdiActiveDocument.Database


            Using tr As Transaction = db.TransactionManager.StartTransaction
                Try
                    Dim myBT As BlockTable = Application.DocumentManager.MdiActiveDocument.Database.BlockTableId.GetObject(OpenMode.ForRead)
                    ' Open current space for write
                    Dim myBTR As BlockTableRecord = CType(tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite), BlockTableRecord)

                    ' Insert Block
                    '     Dim blockDef As BlockTableRecord = TryCast(myBT(strblockName).GetObject(OpenMode.ForRead), BlockTableRecord)
                    Dim blkTid As ObjectId = TryCast(myBT(strblockName).GetObject(OpenMode.ForRead), BlockTableRecord).ObjectId
                    Dim myBlockDef As BlockTableRecord = blkTid.GetObject(OpenMode.ForRead)

                    Dim myBlockRef As New BlockReference(New Point3d(x, y, 0), blkTid)

                    Dim obj As ObjectId = myBTR.AppendEntity(myBlockRef)
                    tr.AddNewlyCreatedDBObject(myBlockRef, True)

                    Dim myEnt As Entity
                    ' Dim attt As String

                    Dim myBTREnum As BlockTableRecordEnumerator = myBlockDef.GetEnumerator
                    While myBTREnum.MoveNext
                        myEnt = myBTREnum.Current.GetObject(OpenMode.ForWrite)
                        If TypeOf myEnt Is AttributeDefinition Then
                            myEnt.UpgradeOpen()
                            Dim myAttDef As AttributeDefinition = CType(myEnt, AttributeDefinition)
                            Dim myAttRef As New AttributeReference

                            With myAttRef
                                myAttRef.SetAttributeFromBlock(myAttDef, myBlockRef.BlockTransform)

                                Dim BaseAttY As Double = .Position.Y
                                'смещение атрибутов относительно базового положения по вертикали
                                .Position = New Point3d(.Position.X, .Position.Y + 3, 0)
                                .TextString = "111"



                            End With
                            myBlockRef.AttributeCollection.AppendAttribute(myAttRef)
                            tr.AddNewlyCreatedDBObject(myAttRef, True)
                        End If
                    End While
                    myBlockRef.Layer = strLayerName

                    ' Set return value
                    Dim retVal As ObjectId = myBlockRef.ObjectId

                Catch ex As Exception
                    tr.Dispose()
                Finally
                    If tr.IsDisposed = False Then tr.Commit()
                End Try
            End Using ' dispose transaction
        End Using ' dispose database
    End Function
    ''by Stephen Preston
    ' <CommandMethod("AddBlockTest")> _
    Public Sub AddrefBlockTest()
        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Using lockdoc As DocumentLock = doc.LockDocument


            Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database

            Using myT As Transaction = db.TransactionManager.StartTransaction()


                'Get the block definition "Check".

                Dim blockName As String = "CHECK"


                Dim bt As BlockTable = TryCast(db.BlockTableId.GetObject(OpenMode.ForRead), BlockTable)


                Dim blockDef As BlockTableRecord = TryCast(bt(blockName).GetObject(OpenMode.ForRead), BlockTableRecord)

                'Also open modelspace - we'll be adding our BlockReference to it



                Dim ms As BlockTableRecord = TryCast(bt(BlockTableRecord.ModelSpace).GetObject(OpenMode.ForWrite), BlockTableRecord)

                'Create new BlockReference, and link it to our block definition

                Dim point As New Point3d(2.0, 4.0, 6.0)


                Using blockRef As New BlockReference(point, blockDef.ObjectId)


                    'Add the block reference to modelspace

                    ms.AppendEntity(blockRef)

                    myT.AddNewlyCreatedDBObject(blockRef, True)

                    'Iterate block definition to find all non-constant 

                    ' AttributeDefinitions

                    For Each id As ObjectId In blockDef


                        Dim obj As DBObject = id.GetObject(OpenMode.ForRead)

                        Dim attDef As AttributeDefinition = TryCast(obj, AttributeDefinition)

                        If (attDef IsNot Nothing) AndAlso (Not attDef.Constant) Then


                            'This is a non-constant AttributeDefinition 

                            'Create a new AttributeReference

                            Using attRef As New AttributeReference()


                                attRef.SetAttributeFromBlock(attDef, blockRef.BlockTransform)

                                attRef.TextString = "Hello World"

                                'Add the AttributeReference to the BlockReference

                                blockRef.AttributeCollection.AppendAttribute(attRef)


                                myT.AddNewlyCreatedDBObject(attRef, True)

                            End Using

                        End If

                    Next
                End Using

                'Our work here is done


                myT.Commit()
            End Using
        End Using
    End Sub
    ''' <summary>
    ''' выбирает все примитивы из заданого файла  чертежа и формирует список их клонов
    ''' </summary>
    ''' <param name="NameF"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Primitiw(ByVal NameF) As DBObjectCollection
        '
        If Not My.Computer.FileSystem.FileExists(NameF) Then
            Application.ShowAlertDialog("WstwkaBlockIzFile: файл " & NameF & "  отсутствует")
            Return Nothing
        End If
        Dim sourceDb As Database = New Database(False, True)
        sourceDb.ReadDwgFile(NameF, System.IO.FileShare.Read, True, "")

        '  Dim tm As Autodesk.AutoCAD.DatabaseServices.TransactionManager = sourceDb.TransactionManager
        Dim SpPrim As New DBObjectCollection

        Using myT As Transaction = sourceDb.TransactionManager.StartTransaction
            Dim Bt As BlockTable = myT.GetObject(sourceDb.BlockTableId, OpenMode.ForRead, False)
            Dim btr As BlockTableRecord = myT.GetObject(Bt(BlockTableRecord.ModelSpace), OpenMode.ForRead, False)


            For Each elId As ObjectId In btr
                SpPrim.Add(myT.GetObject(elId, OpenMode.ForRead, False).Clone)
            Next

        End Using
        sourceDb.Dispose()
        Return SpPrim
    End Function
    Public Sub WstwkaBlockIzFile(ByVal NameF As String)
        Dim lspPrim = Primitiw(NameF)
        If lspPrim Is Nothing Then Return

        Dim Ima As String = IO.Path.GetFileNameWithoutExtension(NameF)
        '    Dim dm As DocumentCollection = Application.DocumentManager
        Dim doc = Application.DocumentManager.MdiActiveDocument

        Dim DestDb As Database = doc.Database

        Using myT As Transaction = DestDb.TransactionManager.StartTransaction
            Dim Bt As BlockTable = myT.GetObject(DestDb.BlockTableId, OpenMode.ForRead, False)
            Try
                SymbolUtilityServices.ValidateSymbolName(Ima, False)
                If Bt.Has(Ima) Then
                    Application.ShowAlertDialog(Ima & " блок с таким именем существует  ")
                    Return
                End If
            Catch ex As Exception
                Application.ShowAlertDialog(Ima & " неправильное  ")
                Return
            End Try

            Bt.UpgradeOpen()
            Dim lSozdBl As New BlockTableRecord
            lSozdBl.Name = Ima
            Dim objSozdBl As ObjectId = Bt.Add(lSozdBl)
            myT.AddNewlyCreatedDBObject(lSozdBl, True)

            For Each el As Entity In lspPrim
                lSozdBl.AppendEntity(el)
                myT.AddNewlyCreatedDBObject(el, True)
            Next
            myT.Commit()
        End Using
        ' DestDb.Dispose()
        MsgBox(lspPrim.Count)
        '  LocDoc.Dispose()

        '  dm.MdiActiveDocument = doc
        doc.Editor.Regen()
    End Sub
    ''' <summary>
    ''' Импорт блоков из файла
    ''' </summary>
    ''' <param name="NameF"> Путь к файлу </param>
    ''' <remarks></remarks>
    Public Sub ImportBlockIzFile(ByVal NameF As String)
        If Not My.Computer.FileSystem.FileExists(NameF) Then
            Application.ShowAlertDialog("WstwkaBlockIzFile: файл " & NameF & "  отсутствует")
            Return
        End If

        Dim dm As DocumentCollection = Application.DocumentManager
        Dim ed As Editor = dm.MdiActiveDocument.Editor
        Dim DestDb As Database = dm.MdiActiveDocument.Database
        Dim sourceDb As Database = New Database(False, True)

        sourceDb.ReadDwgFile(NameF, System.IO.FileShare.Read, True, "")


        Dim blockIds As ObjectIdCollection = New ObjectIdCollection()
        Dim tm As DBTransMan = sourceDb.TransactionManager
        Using myT As Transaction = tm.StartTransaction
            Dim Bt As BlockTable = tm.GetObject(sourceDb.BlockTableId, OpenMode.ForRead, False)
            For Each btrId As ObjectId In Bt
                Dim btr As BlockTableRecord = tm.GetObject(btrId, OpenMode.ForRead, False)
                '     Application.ShowAlertDialog(btr.Name & " A " & btr.IsAnonymous & " La " & btr.IsLayout)

                If Not btr.IsAnonymous And Not btr.IsLayout Then

                    blockIds.Add(btrId)
                End If

                btr.Dispose()
            Next

            Dim mapping As IdMapping = New IdMapping
            sourceDb.WblockCloneObjects(blockIds, DestDb.BlockTableId, mapping, DuplicateRecordCloning.Replace, False)

            ' sourceDb.Dispose()
        End Using


        sourceDb.Dispose()


    End Sub

End Module
