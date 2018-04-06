#If ARX_APP Then
Imports Autodesk.AutoCAD.DatabaseServices
Imports _AcTrx =Autodesk.AutoCAD.Runtime
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
''' класс функции вывода текста в чертеж 
''' </summary>
''' <remarks></remarks>
Public Class dwgText
    Private Shared Function UstStil(ByVal lacTrans As Transaction, ByVal lDb As Database, ByVal nameSt As String) As ObjectId
        Dim tst As TextStyleTable 'устанваем стиль текста
        tst = lacTrans.GetObject(lDb.TextStyleTableId(), OpenMode.ForRead) ' извлекли таблицу стилей
        Try
            Return tst.Item(nameSt) 'взяли объект стиль и присвоили его текстовому примитиву

        Catch ex As Exception
            Application.ShowAlertDialog("Нет стиля " & nameSt & " " & ex.Message)
            Return Nothing
        End Try
    End Function
    Private Shared Sub UstWidthFaktor(ByVal acText As DBText, ByVal accurDb As Database, ByVal acTrans As Transaction)
        Dim acTextStyleTblRec As TextStyleTableRecord
        acTextStyleTblRec = acTrans.GetObject(accurDb.Textstyle, _
                                              OpenMode.ForRead)
        acText.WidthFactor = acTextStyleTblRec.XScale
    End Sub
    Public Shared Function CreateText(ByVal Position As Point3d, ByVal StrTexta As String, ByVal Height As Double) As ObjectId
        '' Выводит однострочный текст заданной высоты
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        Dim ind As ObjectId

        '' Start a transaction

        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()

            '' Открыть таблицу блоков для чтения

            Dim acBlkTbl As BlockTable

            acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId, OpenMode.ForRead)

            '' Открыть таблицу записей пространства модели для записи

            Dim acBlkTblRec As BlockTableRecord

            acBlkTblRec = acTrans.GetObject(acBlkTbl(BlockTableRecord.ModelSpace), OpenMode.ForWrite)



            '' Создать однострочный текстовой примитив

            Dim acText As DBText = New DBText()

            acText.SetDatabaseDefaults()
            '   acText.TextStyleId = acCurDb.Textstyle
            '  acText.SetFromStyle()

            acText.Position = Position

            acText.Height = Height
            acText.TextString = StrTexta

            UstWidthFaktor(acText, acCurDb, acTrans)

            ind = acBlkTblRec.AppendEntity(acText)

            acTrans.AddNewlyCreatedDBObject(acText, True)



            '' Save the changes and dispose of the transaction

            acTrans.Commit()

        End Using
        Return ind
    End Function
    Private Shared Function GrTexta(ByVal acText As DBText, ByVal Shir As Double) As Boolean
        Dim box As Extents3d
        Try
            box = acText.GeometricExtents 'берем ограничивающий прямоугольник

        Catch ex As Exception
            ' Application.ShowAlertDialog("Не определен размер " & StrTexta)
            Return True
        End Try
        Dim ShirReal = box.MaxPoint.X - box.MinPoint.X
        If ShirReal < Shir Then Return True Else Return False
    End Function
    ''' <summary>
    ''' определяет область расположение элемента
    ''' </summary>
    ''' <param name="Iid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DlinaEl(ByVal Iid As ObjectId) As Extents3d
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        Dim indBD As Entity
        Dim lbox As Extents3d
        '' Start a transaction
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()

            '' Open the Block table for read

            indBD = acTrans.GetObject(Iid, OpenMode.ForRead)

            Try
                lbox = indBD.GeometricExtents 'берем ограничивающий прямоугольник

            Catch ex As _AcTrx.Exception
                ' Application.ShowAlertDialog("Не определен размер " & StrTexta)
                Return Nothing
            End Try
            Return lbox



            '' Save the changes and dispose of the transaction
            acTrans.Commit()
        End Using
    End Function
    Public Shared Function CreateText(ByVal Position As Point3d, ByVal StrTexta As String, ByVal Height As Double, ByVal Shir As Double) As ObjectId
        '' Выводит однострочный текст в область не больше заданой щирины
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        Dim ind As ObjectId

        '' Start a transaction
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()

            '' Open the Block table for read
            Dim acBlkTbl As BlockTable
            acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId, OpenMode.ForRead)

            '' Open the Block table record Model space for write
            Dim acBlkTblRec As BlockTableRecord
            acBlkTblRec = acTrans.GetObject(acBlkTbl(BlockTableRecord.ModelSpace), OpenMode.ForWrite)

            '' Create a single-line text object
            Dim acText As DBText = New DBText()
            acText.SetDatabaseDefaults()

            acText.Position = Position
            acText.Height = Height
            acText.TextString = StrTexta
            UstWidthFaktor(acText, acCurDb, acTrans)
            'Dim box As Extents3d
            'Try
            '    box = acText.GeometricExtents 'берем ограничивающий прямоугольник

            'Catch ex As Autodesk.AutoCAD.Runtime.Exception
            '    ' Application.ShowAlertDialog("Не определен размер " & StrTexta)
            '    box = New Extents3d(Position, New Point3d(Position.X + 3, Position.Y + Height, 0))
            'End Try
            'Dim ShirReal = box.MaxPoint.X - box.MinPoint.X

            If Not GrTexta(acText, Shir) Then
                acText.HorizontalMode = TextHorizontalMode.TextFit
                Dim PointAl As New Point3d(Position.X + Shir, Position.Y, Position.Z)
                acText.AlignmentPoint = PointAl
            End If
            Try
                acText.TextStyleId = UstStil(acTrans, acCurDb, "UgESP") 'взяли объект стиль и присвоили его текстовому примитиву
            Catch
                Debug.Print("не установлен стиль")
            End Try

            ' acText.TextStyleName
            ind = acBlkTblRec.AppendEntity(acText)

            acTrans.AddNewlyCreatedDBObject(acText, True)

            '' Save the changes and dispose of the transaction
            acTrans.Commit()
        End Using
        Return ind
    End Function
    Public Shared Function CreateTextV(ByVal Position As Point3d, ByVal StrTexta As String, ByVal Height As Double) As ObjectId
        '' Get the current document and database
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        Dim ind As ObjectId
        '' Start a transaction
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
            '' Open the Block table for read
            Dim acBlkTbl As BlockTable
            acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId, OpenMode.ForRead)
            '' Open the Block table record Model space for write
            Dim acBlkTblRec As BlockTableRecord
            acBlkTblRec = acTrans.GetObject(acBlkTbl(BlockTableRecord.ModelSpace), OpenMode.ForWrite)
            '' Create a single-line text object
            Dim acText As DBText = New DBText()
            acText.SetDatabaseDefaults()
            acText.Position = Position
            acText.Height = Height
            acText.TextString = StrTexta
            acText.Rotation = Math.PI / 2
            UstWidthFaktor(acText, acCurDb, acTrans)
            ind = acBlkTblRec.AppendEntity(acText)

            acTrans.AddNewlyCreatedDBObject(acText, True)
            '' Save the changes and dispose of the transaction
            acTrans.Commit()
        End Using
        Return ind
    End Function
    Public Shared Function CreateTextUg(ByVal Position As Point3d, ByVal StrTexta As String, ByVal Height As Double, ByVal ugol As Double) As ObjectId
        '' Get the current document and database
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        Dim ind As ObjectId
        '' Start a transaction
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
            '' Open the Block table for read
            Dim acBlkTbl As BlockTable
            acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId, OpenMode.ForRead)
            '' Open the Block table record Model space for write
            Dim acBlkTblRec As BlockTableRecord
            acBlkTblRec = acTrans.GetObject(acBlkTbl(BlockTableRecord.ModelSpace), OpenMode.ForWrite)
            '' Create a single-line text object
            Dim acText As DBText = New DBText()
            acText.SetDatabaseDefaults()
            acText.Position = Position
            acText.Height = Height
            acText.TextString = StrTexta
            acText.Rotation = ugol
            UstWidthFaktor(acText, acCurDb, acTrans)
            ind = acBlkTblRec.AppendEntity(acText)

            acTrans.AddNewlyCreatedDBObject(acText, True)
            '' Save the changes and dispose of the transaction
            acTrans.Commit()
        End Using
        Return ind
    End Function
    Public Shared Function CreateTextV(ByVal Position As Point3d, ByVal StrTexta As String, ByVal Height As Double, ByVal Shir As Double) As ObjectId
        '' Get the current document and database
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        Dim ind As ObjectId
        '' Start a transaction
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
            '' Open the Block table for read
            Dim acBlkTbl As BlockTable
            acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId, OpenMode.ForRead)
            '' Open the Block table record Model space for write
            Dim acBlkTblRec As BlockTableRecord
            acBlkTblRec = acTrans.GetObject(acBlkTbl(BlockTableRecord.ModelSpace), OpenMode.ForWrite)
            '' Create a single-line text object
            Dim acText As DBText = New DBText()
            acText.SetDatabaseDefaults()
            acText.Position = Position
            acText.Height = Height
            acText.TextString = StrTexta
            If GrTexta(acText, Shir) Then
                acText.Rotation = Math.PI / 2
            Else
                acText.HorizontalMode = TextHorizontalMode.TextFit
                Dim PointAl As New Point3d(Position.X, Position.Y + Shir, Position.Z)
                acText.AlignmentPoint = PointAl
            End If
            UstWidthFaktor(acText, acCurDb, acTrans)
            ind = acBlkTblRec.AppendEntity(acText)

            acTrans.AddNewlyCreatedDBObject(acText, True)
            '' Save the changes and dispose of the transaction
            acTrans.Commit()
        End Using
        Return ind
    End Function
    Public Shared Function CreateMText(ByVal tWstawka As Point3d, ByVal StrTxt As String, ByVal Shir As Double, ByVal Wis As Double) As ObjectId
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        '' Start a transaction
        Dim ind As ObjectId
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()

            '' Open the Block table for read
            Dim acBlkTbl As BlockTable
            acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId, _
                                         OpenMode.ForRead)

            '' Open the Block table record Model space for write
            Dim acBlkTblRec As BlockTableRecord
            acBlkTblRec = acTrans.GetObject(acBlkTbl(BlockTableRecord.ModelSpace), _
                                            OpenMode.ForWrite)

            '' Create a multiline text object
            Dim acMText As MText = New MText()
            acMText.SetDatabaseDefaults()
            acMText.Location = tWstawka
            acMText.Width = Shir
            '  acMText. = Wis
            Try
                acMText.TextHeight = Wis  ' GlobParam.WisTexta
            Catch ex As Exception

            End Try


            Try
                acMText.LineSpaceDistance = Wis + 1 ' возможность выставить расстояния между строками зависит от ывысоты текса не любое возможно?
            Catch ex As Exception

            End Try

            Try
                acMText.TextStyleId = UstStil(acTrans, acCurDb, "UgEsp")
            Catch ex As Exception
                Debug.Print("не установлен стиль")
            End Try
            acMText.Contents = StrTxt
            ind = acBlkTblRec.AppendEntity(acMText)
            acTrans.AddNewlyCreatedDBObject(acMText, True)

            '' Save the changes and dispose of the transaction
            acTrans.Commit()
        End Using
        Return ind
    End Function
End Class
