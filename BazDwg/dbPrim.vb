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


Imports BazDwg
''' <summary>
''' Функции создающие примитивы "Entity" , для последующего группового включения в базу данных чертежа
''' </summary>
''' <remarks></remarks>
Public Class dbPrim
	Shared wObjectIdStyl As ObjectId = ObjectId.Null
	Shared wObjectIdMlyderStyl As ObjectId = ObjectId.Null
	Shared TextHeightStyle As Double = 4
	Shared DopuskY As Double = 0.1
	Shared ReadOnly Property ObjectIdStyle As ObjectId
		Get
			Return wObjectIdStyl
		End Get
	End Property
	Shared ReadOnly Property TextStil() As TextStyleTableRecord
		Get
			Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
			Dim acCurDb As Database = acDoc.Database


			'' Start a transaction
			Using lacTrans As Transaction = acCurDb.TransactionManager.StartTransaction()




				Try


					Dim tt As TextStyleTableRecord = lacTrans.GetObject(wObjectIdStyl, OpenMode.ForRead)
					Return tt.Clone

				Catch ex As Exception
					Application.ShowAlertDialog("dbPrim.TextStil   стиль не установлен " & ex.Message)

					Return Nothing
				End Try
			End Using
		End Get
	End Property
	''' <summary>
	''' Определяет объектный идентификатор стиля и определяет высоту текста
	''' </summary>
	''' <param name="nameSt">Имя стиля </param>
	''' <remarks> если высота не задана то принимает 3.5</remarks>
	Public Shared Sub UstStil(ByVal nameSt As String)
		Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
		Dim acCurDb As Database = acDoc.Database


		'' Start a transaction
		Using lacTrans As Transaction = acCurDb.TransactionManager.StartTransaction()


			Dim tst As TextStyleTable 'устанваем стиль текста

			tst = lacTrans.GetObject(acCurDb.TextStyleTableId(), OpenMode.ForRead) ' извлекли таблицу стилей
			Try
				'   Return tst.Item(nameSt) 'взяли объект стиль и присвоили его текстовому примитиву
				wObjectIdStyl = tst.Item(nameSt)
				Dim tt As TextStyleTableRecord = lacTrans.GetObject(wObjectIdStyl, OpenMode.ForRead)
				TextHeightStyle = tt.TextSize
				If TextHeightStyle < 0.01 Then TextHeightStyle = 4.0

			Catch ex As Exception
				Application.ShowAlertDialog("dbPrim.UstStil   Нет стиля " & nameSt & " " & ex.Message)

			End Try
		End Using
	End Sub
	Public Shared Function UstMliderStil(ByVal nameSt As String) As ObjectId
		Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
		Dim acCurDb As Database = acDoc.Database


		'' Start a transaction
		Using lacTrans As Transaction = acCurDb.TransactionManager.StartTransaction()

			Dim l As ObjectId
			Dim tst As DBDictionary   'устанваем стиль текста

			tst = lacTrans.GetObject(acCurDb.MLeaderStyleDictionaryId, OpenMode.ForRead) ' извлекли таблицу стилей
			Try
				'   Return tst.Item(nameSt) 'взяли объект стиль и присвоили его текстовому примитиву
				l = tst.Item(nameSt)


			Catch ex As Exception
				Application.ShowAlertDialog("dbPrim.UstMliderStil   Нет стиля мультивыносок " & nameSt & " " & ex.Message)

			End Try
			Return l
		End Using

	End Function
	Shared Sub PeremestitNaPlan(iEnt As Entity, iPered As Boolean)
		Dim doc = Application.DocumentManager.MdiActiveDocument
		Dim db = doc.Database

		Using tr = db.TransactionManager.StartTransaction()



			Dim block As BlockTableRecord = tr.GetObject(iEnt.BlockId, OpenMode.ForRead)

			Dim drawOrder As DrawOrderTable = tr.GetObject(block.DrawOrderTableId, OpenMode.ForWrite)

			Dim ids As New ObjectIdCollection
			ids.Add(iEnt.ObjectId)
			If iPered Then
				drawOrder.MoveToTop(ids)
			Else
				drawOrder.MoveToBottom(ids)
			End If


			tr.Commit()
		End Using




	End Sub
#Region "line"
	Public Shared Function CreateLine(ByVal Xb As Double, ByVal Yb As Double, ByVal Xe As Double, ByVal Ye As Double) As Entity
		Dim startpt As New Point3d(Xb, Yb, 0.0)
		Dim endpt As New Point3d(Xe, Ye, 0.0)
		Dim pLine As New Line(startpt, endpt)


		Return pLine
	End Function
	''' <summary>
	''' Выводит линию и записывает массив строк в расширенные данные
	''' </summary>
	''' <param name="Xb"></param>
	''' <param name="Yb"></param>
	''' <param name="Xe"></param>
	''' <param name="Ye"></param>
	''' <param name="Opis"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Shared Function CreateLine(ByVal Xb As Double, ByVal Yb As Double, ByVal Xe As Double, ByVal Ye As Double, ByVal Opis() As String) As Entity
		Dim startpt As New Point3d(Xb, Yb, 0.0)
		Dim endpt As New Point3d(Xe, Ye, 0.0)
		Dim pLine As New Line(startpt, endpt)
		clsXDATA.SetPoMasStrok(pLine, Opis)

		Return pLine
	End Function
	Public Shared Function CreateNakl(ByVal X As Double, ByVal Y As Double, ByVal Dlina As Double, ByVal Ugol As Double) As Entity
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
	Public Shared Function CreateNakl(ByVal X As Double, ByVal Y As Double, ByVal DlinaP As Double, ByVal DlinaM As Double, ByVal Ugol As Double) As Entity
		' Выводит отрезок длиной DlinaP+DlinaM под углом Ugol ,  точка X,Y делит в соотношение DlinaP : DlinaM
		Dim Dcos, Dsin, lxb, lyb, lxe, lye As Double

		Dcos = Math.Cos(Ugol)
		Dsin = Math.Sin(Ugol)

		lxb = X + DlinaP * Dcos
		lyb = Y + DlinaP * Dsin
		lxe = X - DlinaM * Dcos
		lye = Y - DlinaM * Dsin
		Return CreateLine(lxb, lyb, lxe, lye)

	End Function
	Public Shared Function CreateNakl(ByVal X As Double, ByVal Y As Double, ByVal Dlina As Double, ByVal Ugol As Double, ByRef Xe As Double, ByRef ye As Double) As Entity
		'Выводит отрезок длиной Dlina под углом Ugol , из точки X,Y Xe ye конечная точка
		Dim Dcos, Dsin As Double

		Dcos = Math.Cos(Ugol)
		Dsin = Math.Sin(Ugol)


		Xe = X - Dlina * Dcos
		ye = Y - Dlina * Dsin
		Return CreateLine(X, Y, Xe, ye)

	End Function
#End Region
#Region "text"
	Public Shared Function CreateText(ByVal Position As Point3d, ByVal StrTexta As String, ByVal Height As Double) As Entity
		'' Выводит однострочный текст заданной высоты



		Dim acText As DBText = New DBText()

		acText.SetDatabaseDefaults()

		acText.Position = Position

		acText.Height = Height

		acText.TextString = StrTexta

		Return acText
	End Function

	Public Shared Function CreateTextV(ByVal Position As Point3d, ByVal StrTexta As String, ByVal Height As Double) As Entity
		'' Get the current document and database


		'' Create a single-line text object
		Dim acText As DBText = New DBText()
		acText.SetDatabaseDefaults()
		acText.Position = Position
		acText.Height = Height
		acText.TextString = StrTexta
		acText.Rotation = Math.PI / 2


		Return acText
	End Function
	Public Shared Function CreateTextUg(ByVal Position As Point3d, ByVal StrTexta As String, ByVal Height As Double, ByVal ugol As Double) As Entity
		'' Get the current document and database


		Dim acText As DBText = New DBText()
		acText.SetDatabaseDefaults()
		acText.Position = Position
		acText.Height = Height
		acText.TextString = StrTexta
		acText.Rotation = ugol


		Return acText
	End Function
	Public Shared Function CreateMText(ByVal tWstawka As Point3d, ByVal StrTxt As String, ByVal Shir As Double, ByVal Wis As Double) As Entity
		Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
		If wObjectIdStyl = ObjectId.Null Then UstStil("UgESP") 'если не найден находим указатель на стиль

		'' Create a multiline text object
		Dim acMText As MText = New MText()
		acMText.SetDatabaseDefaults()
		acMText.Location = tWstawka
		acMText.Width = Shir
		acMText.TextStyleId = wObjectIdStyl
		acMText.TextHeight = Wis ' GlobParam.WisTexta
		acMText.Contents = StrTxt
		'    acMText.BackgroundScaleFactor = 1
		Try
			acMText.LineSpaceDistance = 4
		Catch ex As Exception

		End Try




		Return acMText
	End Function
#End Region
	Public Shared Function CreateMLeader(ByVal PointWstText As Point3d, ByVal PointWstMlider As Point3d, ByVal sTxt As String, Optional ByVal iTextHeight As Double = -1) As Entity

		If wObjectIdStyl = ObjectId.Null Then UstStil("UgESP") 'если не найден находим указатель на стиль
		If wObjectIdMlyderStyl = ObjectId.Null Then wObjectIdMlyderStyl = UstMliderStil("UgESP")


		Dim NumLines As Integer = 1


		'' Create the leader
		Dim acLdr As MLeader = New MLeader()

		'      Dim vec As Vector3d = endT - BegT
		'      vec = vec.RotateBy(0, acLdr.Normal)
		'Dim landPt As Point3d = BegT + vec
		Dim ldnum As Integer = acLdr.AddLeader()
		Dim lnnum As Integer = acLdr.AddLeaderLine(ldnum)
		acLdr.AddFirstVertex(lnnum, PointWstMlider)                   'landPt
		acLdr.AddLastVertex(lnnum, PointWstText)
		acLdr.LeaderLineType = LeaderType.StraightLeader

		acLdr.SetDatabaseDefaults()
		'  acLdr.MLeaderStyle = 
		acLdr.ContentType = ContentType.MTextContent
		If wObjectIdMlyderStyl <> ObjectId.Null Then
			acLdr.MLeaderStyle = wObjectIdMlyderStyl

		End If


		Dim mt As New MText()
		mt.Contents = sTxt
		mt.Width = 0
		mt.BackgroundFill = True
		mt.BackgroundScaleFactor = 1
		If wObjectIdStyl <> ObjectId.Null Then
			mt.TextStyleId = wObjectIdStyl
			mt.TextHeight = TextHeightStyle
		End If
		If iTextHeight < 0 Then
			mt.TextHeight = TextHeightStyle
		Else
			mt.TextHeight = iTextHeight
		End If

		mt.Color = acLdr.TextColor
		mt.LineWeight = acLdr.LineWeight
		'mt.Direction = New Vector3d(-1, 0, 0)
		'   mt.SetAttachmentMovingLocation(AttachmentPoint.BaseLeft)
		acLdr.MText = mt
		acLdr.TextLocation = PointWstText

		'' Commit the changes and dispose of the transaction


		Return acLdr
	End Function
	Private Shared Function CreateMLeaderText(ByVal BegT As Point3d, ByVal endT As Point3d,
										  ByVal sTxt As String, Optional ByVal iTextHeight As Double = -1) As Entity

		If wObjectIdStyl = ObjectId.Null Then UstStil("UgESP") 'если не найден находим указатель на стиль
		If wObjectIdMlyderStyl = ObjectId.Null Then wObjectIdMlyderStyl = UstMliderStil("UgESP")


		Dim NumLines As Integer = 1


		'' Create the leader
		Dim acLdr As MLeader = New MLeader()

		Dim vec As Vector3d = endT - BegT
		vec = vec.RotateBy(0, acLdr.Normal)
		Dim landPt As Point3d = BegT + vec
		Dim ldnum As Integer = acLdr.AddLeader()
		Dim lnnum As Integer = acLdr.AddLeaderLine(ldnum)
		acLdr.AddFirstVertex(lnnum, landPt)           ' landPt
		acLdr.AddLastVertex(lnnum, BegT)

		acLdr.LeaderLineType = LeaderType.StraightLeader
		acLdr.SetDatabaseDefaults()
		'  acLdr.MLeaderStyle = 
		acLdr.ContentType = ContentType.ToleranceContent
		If wObjectIdMlyderStyl <> ObjectId.Null Then
			acLdr.MLeaderStyle = wObjectIdMlyderStyl

		End If

		Dim mt As New MText()
		mt.Contents = sTxt

		mt.Width = 0
		mt.BackgroundFill = True

		If wObjectIdStyl <> ObjectId.Null Then
			mt.TextStyleId = wObjectIdStyl
			mt.TextHeight = TextHeightStyle
		End If
		If iTextHeight < 0 Then
			mt.TextHeight = TextHeightStyle
		Else
			mt.TextHeight = iTextHeight
		End If
		' mt.TextHeight = 3
		mt.Color = acLdr.TextColor
		mt.LineWeight = acLdr.LineWeight
		'mt.Direction = New Vector3d(-1, 0, 0)
		'   mt.SetAttachmentMovingLocation(AttachmentPoint.BaseLeft)
		acLdr.MText = mt
		'   acLdr.TextLocation = TwstTexta

		'' Commit the changes and dispose of the transaction


		Return acLdr
	End Function
	''' <summary>
	''' Функция включающая в базу данных чережа Коллекцию примитивов
	''' </summary>
	''' <param name="sp"> коллекция созданных примитивов </param>
	''' <returns> возвращает коллекцию идентификаторов созданных объектов </returns>
	''' <remarks></remarks>
	Shared Function Wkl(ByVal sp As DBObjectCollection) As ObjectIdCollection
		Dim SpId As New ObjectIdCollection

		Dim doc As Document = Application.DocumentManager.MdiActiveDocument
		Dim db As Database = doc.Database
		Dim tm As DBTransMan = db.TransactionManager
		Dim ta As Transaction = tm.StartTransaction()
		Try
			For Each el As Entity In sp
				Dim bt As BlockTable = CType(tm.GetObject(db.BlockTableId, OpenMode.ForRead, False), BlockTable)
				Dim btr As BlockTableRecord = CType(tm.GetObject(bt(BlockTableRecord.ModelSpace), OpenMode.ForWrite, False), BlockTableRecord)
				SpId.Add(btr.AppendEntity(el))
				tm.AddNewlyCreatedDBObject(el, True)

			Next
			ta.Commit()
		Finally
			ta.Dispose()
			'  lock.Dispose()
		End Try
		Return SpId
	End Function
	Shared Function Wkl(ByVal sp As List(Of Entity)) As ObjectIdCollection
		Dim SpId As New ObjectIdCollection

		Dim doc As Document = Application.DocumentManager.MdiActiveDocument
		Dim db As Database = doc.Database
		Dim tm As DBTransMan = db.TransactionManager
		Dim ta As Transaction = tm.StartTransaction()
		Try
			For Each el As Entity In sp
				Dim bt As BlockTable = CType(tm.GetObject(db.BlockTableId, OpenMode.ForRead, False), BlockTable)
				Dim btr As BlockTableRecord = CType(tm.GetObject(bt(BlockTableRecord.ModelSpace), OpenMode.ForWrite, False), BlockTableRecord)
				SpId.Add(btr.AppendEntity(el))
				tm.AddNewlyCreatedDBObject(el, True)

			Next
			ta.Commit()
		Finally
			ta.Dispose()
			'  lock.Dispose()
		End Try
		Return SpId
	End Function
	Shared Function Wkl(ByVal iDbObject As DBObject) As ObjectIdCollection
		Dim SpId As New ObjectIdCollection

		Dim doc As Document = Application.DocumentManager.MdiActiveDocument
		Dim db As Database = doc.Database
		Dim tm As DBTransMan = db.TransactionManager
		Dim ta As Transaction = tm.StartTransaction()
		Try

			Dim bt As BlockTable = CType(tm.GetObject(db.BlockTableId, OpenMode.ForRead, False), BlockTable)
			Dim btr As BlockTableRecord = CType(tm.GetObject(bt(BlockTableRecord.ModelSpace), OpenMode.ForWrite, False), BlockTableRecord)
			SpId.Add(btr.AppendEntity(iDbObject))
			tm.AddNewlyCreatedDBObject(iDbObject, True)


			ta.Commit()
		Finally
			ta.Dispose()
			'  lock.Dispose()
		End Try
		Return SpId
	End Function
	Shared Sub DeleteIzDwg(iSpGraniz As List(Of DBObject))

		Dim doc As Document = Application.DocumentManager.MdiActiveDocument
		Dim db As Database = doc.Database
		Dim ed As Editor = doc.Editor
		Using tx As Transaction = db.TransactionManager.StartTransaction
			Dim acBlkTbl As BlockTable
			acBlkTbl = CType(tx.GetObject(db.BlockTableId,
										 OpenMode.ForRead), BlockTable)
			Dim btr As BlockTableRecord = CType(tx.GetObject(acBlkTbl(BlockTableRecord.ModelSpace), OpenMode.ForWrite), BlockTableRecord)


			For Each el As Entity In iSpGraniz
				Dim elDb As DBObject = el.ObjectId.GetObject(OpenMode.ForWrite)
				elDb.Erase()
			Next






			tx.Commit()

		End Using

	End Sub
	Shared Sub DeleteIzDwg(iEntity As Entity)

		Dim doc As Document = Application.DocumentManager.MdiActiveDocument
		Dim db As Database = doc.Database
		Dim ed As Editor = doc.Editor
		Using tx As Transaction = db.TransactionManager.StartTransaction
			Dim acBlkTbl As BlockTable
			acBlkTbl = CType(tx.GetObject(db.BlockTableId,
										 OpenMode.ForRead), BlockTable)
			Dim btr As BlockTableRecord = CType(tx.GetObject(acBlkTbl(BlockTableRecord.ModelSpace), OpenMode.ForWrite), BlockTableRecord)



			Dim DBObject1 As DBObject = iEntity.ObjectId.GetObject(OpenMode.ForWrite)

			DBObject1.Erase()


			tx.Commit()

		End Using

	End Sub
#Region "PolyLine"
	Public Shared Function CreateLwPolyline(ByVal Mas As Point2dCollection) As Entity

		Dim pline As New Polyline 'Poly2dType.SimplePoly, Mas, False, 1, 1, b

		Dim i As Integer
		For i = 0 To Mas.Count - 1
			pline.AddVertexAt(i, Mas.Item(i), 0.0, 0, 0)
		Next

		Return pline
	End Function
	Public Shared Function CreateLwPolyline(ByVal Mas As Point2dCollection, ByVal Ugol As Double, ByVal BazePoint As Point3d) As Entity
		Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
		Dim pline As New Polyline 'Poly2dType.SimplePoly, Mas, False, 1, 1, b

		Dim i As Integer
		For i = 0 To Mas.Count - 1
			pline.AddVertexAt(i, Mas.Item(i), 0.0, 0, 0)
		Next
		Dim curUCSMatrix As Matrix3d = acDoc.Editor.CurrentUserCoordinateSystem
		Dim curUCS As CoordinateSystem3d = curUCSMatrix.CoordinateSystem3d
		pline.TransformBy(Matrix3d.Rotation(Ugol, curUCS.Zaxis, BazePoint))
		Dim db As Database = acDoc.Database

		Return pline
	End Function
	Public Shared Function CreateLwPolyline(ByVal Mas As Point2dCollection, ByVal bug As Double, ByVal shirB As Double, ByVal shirE As Double) As Entity

		Dim pline As New Polyline 'Poly2dType.SimplePoly, Mas, False, 1, 1, b

		Dim i As Integer
		For i = 0 To Mas.Count - 1
			pline.AddVertexAt(i, Mas.Item(i), bug, shirB, shirE)
		Next


		Return pline
	End Function
	Public Shared Sub changeSloj(ByVal centDb As DBObjectCollection, ByVal newSl As String)
		'Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database
		'Dim tm As DBTransMan = db.TransactionManager
		''start a transaction
		'Dim ta As Transaction = tm.StartTransaction()
		Try

			For Each entDb As Entity In centDb

				entDb.Layer = newSl
			Next

		Catch ex As Exception
			Console.WriteLine("dbprim " & " changeSloj " & ex.Message)
		Finally

		End Try
	End Sub
#End Region
	Public Shared Function CreateCircle(ByVal X As Double, ByVal Y As Double, ByVal Rad As Double) As Entity
		Dim center As New Point3d(X, Y, 0.0)
		Dim normal As New Vector3d(0.0, 0.0, 1.0)
		Dim pcirc As New Circle(center, normal, Rad)

		Return pcirc
	End Function
#Region "Ozenki"
	Shared Function DaljnalPoX(iEntity As Entity) As Double
		Dim lgr As Extents3d = iEntity.GeometricExtents


		Return Math.Max(lgr.MaxPoint.X, lgr.MinPoint.X)
	End Function
	Shared Function BlijnajPoX(iEntity As Entity) As Double
		Dim lgr As Extents3d = iEntity.GeometricExtents


		Return Math.Min(lgr.MaxPoint.X, lgr.MinPoint.X)
	End Function
	Shared Function IzStrChislo(iStr As String) As Double
		Dim lStrChisl As String = "0"
		Dim PrTochki As Boolean = False
		For Each el As Char In iStr

			If Char.IsDigit(el) Then
				lStrChisl &= el
			Else
				Select Case (el)
					Case CChar(".")
						If PrTochki Then Exit For
						lStrChisl &= "."
						PrTochki = True
					Case CChar(",")
						If PrTochki Then Exit For
						lStrChisl &= "."
						PrTochki = True
						'Case CChar(" ")
						'    Exit For
					Case Else
						Exit For

				End Select
			End If
		Next
		Return Val(lStrChisl)
	End Function
	Shared Function MejduX(iHatch As Entity, iPoint As Point3d) As Boolean
		Return MejduX(iHatch, iPoint.X)
	End Function
	Shared Function MejduX(iHatch As Entity, iX As Double) As Boolean
		Dim lgr As Extents3d = iHatch.GeometricExtents
		'
		If Math.Sign(lgr.MaxPoint.X - iX) * Math.Sign(lgr.MinPoint.X - iX) < 0 _
			Then Return True Else Return False
	End Function
	Shared Function GetLinePeresech(ihatch As Entity, iX As Double) As Line
		If MejduX(ihatch, iX) Then
			Dim l() As Double = dbPrim.IntervalPoY(ihatch)
			Return New Line(New Point3d(iX, l(0) - DopuskY, 0), New Point3d(iX, l(1) + DopuskY, 0))
		Else
			Return Nothing
		End If
	End Function
	''' <summary>
	''' Возвращает интервал по у заведомо включаюший заданый примитив
	''' </summary>
	''' <param name="iEntity"> заданый примитив  </param>
	''' <returns></returns>
	''' <remarks></remarks>
	Shared Function IntervalPoY(iEntity As Entity) As Double()
		Dim lgr As Extents3d = iEntity.GeometricExtents
		Dim lGrpar(1) As Double ' 0 минимум 1 максимум
		lGrpar(0) = Math.Min(lgr.MaxPoint.Y, lgr.MinPoint.Y)
		lGrpar(1) = Math.Max(lgr.MaxPoint.Y, lgr.MinPoint.Y)
		Return lGrpar

	End Function
	Shared Function ZentrEntity(iEntity As Entity) As Point3d
		Dim lgr As Extents3d = iEntity.GeometricExtents

		Return New Point3d(0.5 * (lgr.MaxPoint.X + lgr.MinPoint.X), 0.5 * (lgr.MaxPoint.Y + lgr.MinPoint.Y), lgr.MaxPoint.Z)
	End Function
	Shared Function DistanzeX(iA As Hatch, ib As Hatch) As Double
		Dim lmaxA = Math.Max(iA.GeometricExtents.MaxPoint.X, iA.GeometricExtents.MinPoint.X)
		Dim lminb = Math.Min(ib.GeometricExtents.MaxPoint.X, ib.GeometricExtents.MinPoint.X)
		Return Math.Abs(lmaxA - lminb)



	End Function
	Shared Function Distanze(iA As Polyline, ib As Polyline) As Double
		Dim lmin = 10000.0
		For i As Integer = 0 To ib.NumberOfVertices - 1
			Dim lpoint As Point3d = iA.GetClosestPointTo(ib.GetPoint3dAt(i), False)
			Dim lrem = lpoint.DistanceTo(ib.GetPoint3dAt(i))
			If lrem < lmin Then
				lmin = lrem
			End If
		Next
		Return lmin
	End Function
	''' <summary>
	''' длина примитива о ограничевающей области.
	''' </summary>
	''' <param name="iA"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	Shared Function DlinaPoX(iA As Entity) As Double
		Dim lmaxA = Math.Max(iA.GeometricExtents.MaxPoint.X, iA.GeometricExtents.MinPoint.X)
		Dim lminb = Math.Min(iA.GeometricExtents.MaxPoint.X, iA.GeometricExtents.MinPoint.X)
		Return lmaxA - lminb


	End Function
	Shared Function DistanzeY(iA As Entity, ib As Entity) As Double
		Dim lmaxAY = Math.Min(iA.GeometricExtents.MaxPoint.Y, iA.GeometricExtents.MinPoint.Y)
		Dim lminbY = Math.Min(ib.GeometricExtents.MaxPoint.Y, ib.GeometricExtents.MinPoint.Y)

		Return Math.Abs(lmaxAY - lminbY)
	End Function
#End Region
End Class
Public Class Znaki
	Public Const Kor3 As Double = 1.7320508
	Public Const Kor2 As Double = 1.41421356
	Public Shared Function CreateTreg(ByVal X As Double, ByVal Y As Double, ByVal L As Double, ByVal H As Double) As Entity
		'Выводится треугольник вершина вниз высота Н основание 2L
		Dim mas As New Point2dCollection
		mas.Add(New Point2d(X, Y))
		mas.Add(New Point2d(X - L, Y + H))
		mas.Add(New Point2d(X + L, Y + H))
		mas.Add(New Point2d(X, Y))
		Return dbPrim.CreateLwPolyline(mas)

	End Function
	Public Shared Function CreateTregW(ByVal X As Double, ByVal Y As Double, ByVal L As Double, ByVal H As Double) As Entity
		'Выводится треугольник вершина вверх высота Н основание 2L
		Dim mas As New Point2dCollection
		mas.Add(New Point2d(X, Y + H))
		mas.Add(New Point2d(X - L, Y))
		mas.Add(New Point2d(X + L, Y))
		mas.Add(New Point2d(X, Y + H))
		Return dbPrim.CreateLwPolyline(mas)

	End Function
	Public Shared Function CreateKrug(ByVal X As Double, ByVal Y As Double, ByVal Rad As Double) As Entity
		Dim mas As New Point2dCollection
		mas.Add(New Point2d(X, Y - 0.5 * Rad))
		mas.Add(New Point2d(X, Y + 0.5 * Rad))
		mas.Add(New Point2d(X, Y - 0.5 * Rad))
		Return dbPrim.CreateLwPolyline(mas, 1.0, Rad, Rad)
	End Function
	Public Shared Function CreatePrTreg(ByVal X As Double, ByVal Y As Double, ByVal rwp As Double, ByVal Ugol As Double) As Entity
		'Выводится треугольник вершина вниз высота Н основание 2L
		Dim mas As New Point2dCollection
		Dim Pointb As New Point2d(X, Y + 2 * rwp)
		mas.Add(Pointb)
		mas.Add(New Point2d(X - Kor3 * rwp, Y - rwp))
		mas.Add(New Point2d(X + Kor3 * rwp, Y - rwp))
		mas.Add(Pointb)
		'Dim ok As Entity
		'Dim matr As Matrix2d

		Return (dbPrim.CreateLwPolyline(mas, Ugol, New Point3d(X, Y, 0)))

	End Function
	Public Shared Function CreatePrjamoygolnik(ByVal X As Double, ByVal Y As Double, ByVal Wis As Double, ByVal Shir As Double) As Entity
		'Выводится прямоугольник вершина  высота Н основание 2L
		Dim mas As New Point2dCollection
		Dim Pointb As New Point2d(X, Y)
		mas.Add(Pointb)
		mas.Add(New Point2d(X, Y + Wis))

		'Dim ok As Entity
		'Dim matr As Matrix2d

		Return dbPrim.CreateLwPolyline(mas, 0.0, Shir, Shir)

	End Function
End Class
