#If ARX_APP Then
Imports Autodesk.AutoCAD.DatabaseServices
Imports _AcTrx = Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.ApplicationServices
Imports DBTransMan = Autodesk.AutoCAD.DatabaseServices.TransactionManager
Imports Autodesk.AutoCAD.EditorInput
Imports Autodesk.AutoCAD.Colors
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



'Функции работы только с профилем
Public Module Kommand
	Function Slojit(A As Point3d, B As Point3d) As Point3d
		Return New Point3d(A.X + B.X, A.Y + B.Y, A.Z + B.Z)
	End Function
	Public Sub UstTchk(ByVal X As Double, ByVal Y As Double, ByVal Dlina As Double, ByVal Ugol As Double, ByRef Xe As Double, ByRef ye As Double)
		'находит  точку на расстояние  Dlina от заданой под углом Ugol , из точки X,Y Xe ye конечная точка
		Dim Dcos, Dsin As Double

		Dcos = Math.Cos(Ugol)
		Dsin = Math.Sin(Ugol)


		Xe = X - Dlina * Dcos
		ye = Y - Dlina * Dsin
	End Sub
	Public Function UstTchk(ByVal X As Double, ByVal Y As Double, ByVal Dlina As Double, ByVal Ugol As Double) As Point2d
		'находит  точку на расстояние  Dlina от заданой под углом Ugol , из точки X,Y Xe ye конечная точка
		Dim Dcos, Dsin As Double
		Dim xe, ye As Double
		Dcos = Math.Cos(Ugol)
		Dsin = Math.Sin(Ugol)


		xe = X - Dlina * Dcos
		ye = Y - Dlina * Dsin
		Return New Point2d(xe, ye)
	End Function
	Sub Wiswetit(ByVal collObjectId As ObjectIdCollection)
		Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database

		Dim ta As Transaction = db.TransactionManager.StartTransaction()
		Try
			For Each ind As ObjectId In collObjectId

				CType(ta.GetObject(ind, OpenMode.ForWrite), Entity).Highlight()
			Next


			ta.Commit()
		Finally
			ta.Dispose()
		End Try



	End Sub

#Region "Sloj"
	''' <summary>
	''' Устанавливает толщину линий слоя, если такого нет то предварительно создаетьс 
	''' </summary>
	''' <param name="NameSl"></param>
	''' <param name="ilw"></param>
	''' <remarks></remarks>
	Public Sub UstanowitLineWeightLayer(ByVal NameSl As String, ilw As LineWeight)
		Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database
		Dim tm As DBTransMan = db.TransactionManager
		Dim ta As Transaction = tm.StartTransaction()
		Dim LTRec As LayerTableRecord
		Try
			Dim LT As LayerTable = tm.GetObject(db.LayerTableId, OpenMode.ForRead, False)
			If LT.Has(NameSl) = False Then
				LTRec = New LayerTableRecord()
				LTRec.Name = NameSl
				LT.UpgradeOpen()
				LT.Add(LTRec)
				tm.AddNewlyCreatedDBObject(LTRec, True)
			Else
				LTRec = tm.GetObject(LT.Item(NameSl), OpenMode.ForWrite)

			End If
			LTRec.LineWeight = ilw


			ta.Commit()
		Finally
			ta.Dispose()
		End Try
	End Sub
	''' <summary>
	''' Устанавливает zwet  слоя, если такого нет то предварительно создаетьс 
	''' </summary>
	''' <param name="NameSl"></param>
	''' <param name="iColor"></param>
	''' <remarks></remarks>
	Public Sub UstanowitColorLayer(ByVal NameSl As String, iColor As Integer)
		Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database
		Dim tm As DBTransMan = db.TransactionManager
		Dim ta As Transaction = tm.StartTransaction()
		Dim LTRec As LayerTableRecord
		Try
			Dim LT As LayerTable = tm.GetObject(db.LayerTableId, OpenMode.ForRead, False)
			If LT.Has(NameSl) = False Then
				LTRec = New LayerTableRecord()
				LTRec.Name = NameSl
				LTRec.Color = Color.FromColorIndex(ColorMethod.ByAci, iColor)
				LT.UpgradeOpen()
				LT.Add(LTRec)
				tm.AddNewlyCreatedDBObject(LTRec, True)
			Else
				LTRec = tm.GetObject(LT.Item(NameSl), OpenMode.ForWrite)

			End If
			LTRec.Color = Color.FromColorIndex(ColorMethod.ByAci, iColor)


			ta.Commit()
		Finally
			ta.Dispose()
		End Try
	End Sub
	Public Sub createNewLayer(ByVal NameSl As String)
		Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database
		Dim tm As DBTransMan = db.TransactionManager
		Dim ta As Transaction = tm.StartTransaction()
		Try
			Dim LT As LayerTable = tm.GetObject(db.LayerTableId, OpenMode.ForRead, False)
			If LT.Has(NameSl) = False Then
				Dim LTRec As New LayerTableRecord()
				LTRec.Name = NameSl

				LT.UpgradeOpen()
				LT.Add(LTRec)
				tm.AddNewlyCreatedDBObject(LTRec, True)
				ta.Commit()
			End If
		Finally
			ta.Dispose()
		End Try
	End Sub
	Public Sub createNewLayer(ByVal NameSl As String, ByVal iColor As Integer)
		Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database
		Dim tm As DBTransMan = db.TransactionManager
		Dim ta As Transaction = tm.StartTransaction()
		Try
			Dim LT As LayerTable = tm.GetObject(db.LayerTableId, OpenMode.ForRead, False)
			If LT.Has(NameSl) = False Then
				Dim LTRec As New LayerTableRecord()
				LTRec.Name = NameSl

				LTRec.Color = Color.FromColorIndex(ColorMethod.ByAci, iColor)

				LT.UpgradeOpen()
				LT.Add(LTRec)
				tm.AddNewlyCreatedDBObject(LTRec, True)
				ta.Commit()
			End If
		Finally
			ta.Dispose()
		End Try
	End Sub
	''' <summary>
	''' Создает новый слой непечатаемым, а если такой слой существует то делает его непечатаемым
	''' </summary>
	''' <param name="NameSl"></param>
	''' <remarks></remarks>
	Public Sub createNewLayerNePrint(ByVal NameSl As String, Optional icolor As Integer = 0, Optional iLinew As LineWeight = -3)
		'' Get the current document and database
		Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
		Dim acCurDb As Database = acDoc.Database

		'' Start a transaction
		Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()

			'' Open the Layer table for read
			Dim acLyrTbl As LayerTable
			acLyrTbl = acTrans.GetObject(acCurDb.LayerTableId,
										 OpenMode.ForRead)
			Dim acLyrTblRec As LayerTableRecord
			If acLyrTbl.Has(NameSl) = False Then
				acLyrTblRec = New LayerTableRecord()
				'' Assign the layer a name
				acLyrTblRec.Name = NameSl
				'' Upgrade the Layer table for write
				acLyrTbl.UpgradeOpen()
				'' Append the new layer to the Layer table and the transaction
				acLyrTbl.Add(acLyrTblRec)
				acTrans.AddNewlyCreatedDBObject(acLyrTblRec, True)
			Else
				acLyrTblRec = acTrans.GetObject(acLyrTbl(NameSl),
											   OpenMode.ForWrite)
			End If

			'' Turn the layer off
			acLyrTblRec.IsPlottable = False
			If icolor > 0 Then acLyrTblRec.Color = Color.FromColorIndex(ColorMethod.ByAci, icolor)
			If iLinew > -3 Then acLyrTblRec.LineWeight = iLinew

			'' Save the changes and dispose of the transaction
			acTrans.Commit()
		End Using
	End Sub

	Public Function SpisokLayerNames() As List(Of String)
		'' Get the current document and database
		Dim lSp As New List(Of String)
		Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
		Dim acCurDb As Database = acDoc.Database

		'' Start a transaction
		Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()

			'' Open the Layer table for read
			Dim acLyrTbl As LayerTable
			acLyrTbl = acTrans.GetObject(acCurDb.LayerTableId,
										 OpenMode.ForRead)

			Dim sLayerNames As String = ""

			For Each acObjId As ObjectId In acLyrTbl
				Dim acLyrTblRec As LayerTableRecord
				acLyrTblRec = acTrans.GetObject(acObjId,
												OpenMode.ForRead)

				lSp.Add(acLyrTblRec.Name)
			Next



			'' Dispose of the transaction
		End Using
		Return lSp
	End Function
	Public Sub EraseLayer(ByVal LayerName As String)

		'' Get the current document and database

		Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
		Dim acCurDb As Database = acDoc.Database

		'' Start a transaction

		Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()

			'' Open the Layer table for read

			Dim acLyrTbl As LayerTable
			acLyrTbl = acTrans.GetObject(acCurDb.LayerTableId, OpenMode.ForRead)







			If acLyrTbl.Has(LayerName) = True Then

				'' Check to see if it is safe to erase layer

				Dim acObjIdColl As ObjectIdCollection = New ObjectIdCollection()

				acObjIdColl.Add(acLyrTbl(LayerName))

				acCurDb.Purge(acObjIdColl)



				If acObjIdColl.Count > 0 Then

					Dim acLyrTblRec As LayerTableRecord

					acLyrTblRec = acTrans.GetObject(acObjIdColl(0), OpenMode.ForWrite)



					Try

						'' Erase the unreferenced layer

						acLyrTblRec.Erase(True)



						'' Save the changes and dispose of the transaction

						acTrans.Commit()

					Catch Ex As _AcTrx.Exception

						'' Layer could not be deleted

						Application.ShowAlertDialog("Error:\n" + Ex.Message)

					End Try

				End If

			End If

		End Using

	End Sub
	Public Sub LockLayer(ByVal LayerName As String, ByVal Pr As Boolean)

		Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
		Dim acCurDb As Database = acDoc.Database

		Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()

			'' Open the Layer table for read

			Dim acLyrTbl As LayerTable
			acLyrTbl = acTrans.GetObject(acCurDb.LayerTableId, OpenMode.ForRead)

			If acLyrTbl.Has(LayerName) = True Then

				Dim acLayer As LayerTableRecord

				Dim ObjIdLayer As ObjectId = acLyrTbl(LayerName)

				acLayer = acTrans.GetObject(acLyrTbl(LayerName),
										  OpenMode.ForWrite)



				acLayer.IsLocked = Pr





				'' Save the changes and dispose of the transaction

				acTrans.Commit()


			End If

		End Using

	End Sub
#End Region
#Region "Ochistki"
	Public Sub OchistWseModel()

		Dim Col As New ObjectIdCollection
		Dim Count As Integer
		Dim lineid As ObjectId
		Dim Ent As Entity
		Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database
		Dim tm As DBTransMan = db.TransactionManager
		Dim ta As Transaction = tm.StartTransaction()
		Try
			Dim bt As BlockTable = tm.GetObject(db.BlockTableId, OpenMode.ForRead, False)
			Dim btr As BlockTableRecord = tm.GetObject(bt(BlockTableRecord.ModelSpace), OpenMode.ForWrite, False)
			Dim InumBtr As BlockTableRecordEnumerator = btr.GetEnumerator
			Do While InumBtr.MoveNext
				lineid = InumBtr.Current
				Count += 1
				Col.Add(lineid)
			Loop
			For Each lineid In Col
				Ent = lineid.GetObject(OpenMode.ForWrite)

				Ent.Erase()

			Next
			ta.Commit()
		Finally
			ta.Dispose()
		End Try
		' Application.ShowAlertDialog(Count)
	End Sub

	Private Sub OchistSloj(ByVal NameSl As String)

		Dim Col As New ObjectIdCollection
		Dim Count As Integer
		Dim lineid As ObjectId
		Dim Ent As Entity
		Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database
		Dim tm As DBTransMan = db.TransactionManager
		Dim ta As Transaction = tm.StartTransaction()
		Try
			Dim bt As BlockTable = tm.GetObject(db.BlockTableId, OpenMode.ForRead, False)
			Dim btr As BlockTableRecord = tm.GetObject(bt(BlockTableRecord.ModelSpace), OpenMode.ForRead, False)
			Dim InumBtr As BlockTableRecordEnumerator = btr.GetEnumerator

			Do While InumBtr.MoveNext
				lineid = InumBtr.Current
				Count += 1
				Col.Add(lineid)

			Loop
			For Each lineid In Col
				Try
					Ent = lineid.GetObject(OpenMode.ForWrite)
				Catch ex As Exception
					Continue For
				End Try

				If Ent.Layer = NameSl Then
					Ent.Erase()
				End If
			Next
			ta.Commit()
		Finally
			ta.Dispose()
		End Try
		' Application.ShowAlertDialog(Count)
	End Sub
	Public Sub OchistSlojMod(ByVal NameSl As String)




		Dim Ent As Entity
		Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database
		Dim tm As DBTransMan = db.TransactionManager
		Dim mas() As ObjectId = netSelectSet.WibratNaSloiWmodele(NameSl)
		If mas Is Nothing Then Return
		Dim ta As Transaction = tm.StartTransaction()

		Try
			'Dim bt As BlockTable = tm.GetObject(db.BlockTableId, OpenMode.ForRead, False)
			'Dim btr As BlockTableRecord = tm.GetObject(bt(BlockTableRecord.ModelSpace), OpenMode.ForRead, False)


			For Each lineid As ObjectId In mas
				Try

					Ent = ta.GetObject(lineid, OpenMode.ForWrite)
				Catch ex As Exception
					Continue For
				End Try

				If Ent.Layer = NameSl Then
					Ent.Erase()
				End If
			Next
			ta.Commit()
		Finally
			ta.Dispose()
		End Try

	End Sub

	Public Sub OchistSlojList(ByVal NameSl As String)

		Dim Col As New ObjectIdCollection
		Dim Count As Integer
		Dim lineid As ObjectId
		Dim Ent As Entity
		Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database
		Dim tm As DBTransMan = db.TransactionManager
		Dim ta As Transaction = tm.StartTransaction()
		Try
			Dim bt As BlockTable = tm.GetObject(db.BlockTableId, OpenMode.ForRead, False)
			Dim btr As BlockTableRecord = tm.GetObject(bt(BlockTableRecord.PaperSpace), OpenMode.ForWrite, False)
			Dim InumBtr As BlockTableRecordEnumerator = btr.GetEnumerator

			Do While InumBtr.MoveNext
				lineid = InumBtr.Current
				Count += 1
				Col.Add(lineid)
			Loop
			For Each lineid In Col
				Ent = lineid.GetObject(OpenMode.ForWrite)
				If Ent.Layer = NameSl Then
					Ent.Erase()
				End If
			Next
			ta.Commit()
		Finally
			ta.Dispose()
		End Try
		' Application.ShowAlertDialog(Count)
	End Sub
	Public Sub OchistSlojList(ByVal NameSl As String, ByVal Namelist As String)

		Dim Col As New ObjectIdCollection
		Dim Count As Integer
		Dim lineid As ObjectId
		Dim Ent As Entity

		Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database
		Dim tm As DBTransMan = db.TransactionManager
		Dim ta As Transaction = tm.StartTransaction()
		Dim acLayoutMgr As LayoutManager
		acLayoutMgr = LayoutManager.Current




		Try
			Dim acLayout As Layout = ta.GetObject(acLayoutMgr.GetLayoutId(Namelist),
													   OpenMode.ForRead)
			Dim bt As BlockTable = tm.GetObject(db.BlockTableId, OpenMode.ForRead, False)
			Dim btr As BlockTableRecord = tm.GetObject(acLayout.BlockTableRecordId, OpenMode.ForWrite, False)
			Dim InumBtr As BlockTableRecordEnumerator = btr.GetEnumerator

			Do While InumBtr.MoveNext
				lineid = InumBtr.Current
				Count += 1
				Col.Add(lineid)
			Loop
			For Each lineid In Col
				Ent = lineid.GetObject(OpenMode.ForWrite)
				If Ent.Layer = NameSl Then
					Ent.Erase()
				End If
			Next
			ta.Commit()
		Catch ex As Exception
			Application.ShowAlertDialog("OchistSlojList чтото с листом " & Namelist & "  " & ex.Message)

		Finally
			ta.Dispose()
		End Try
		' Application.ShowAlertDialog(Count)
	End Sub
#End Region

#Region "от ппользователей"
	''' <summary>
	''' Ввод одного угла
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Function GetOdinAngleOtPolz() As Double
		Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
		Dim acCurDb As Database = acDoc.Database
		Dim pDblRes As PromptDoubleResult
		Dim pAnglOpts As PromptAngleOptions = New PromptAngleOptions("")
		Dim ptPred As New Point3d(0, 0, 0)

		Do
			pAnglOpts.Message = vbLf & "укажите направление двумя точками "
			'pAnglOpts.UseBasePoint = True
			'pAnglOpts.BasePoint = ptPred
			pDblRes = acDoc.Editor.GetAngle(pAnglOpts)
			'  acDoc.Editor.GetCorner()

			' '' Exit if the user presses ESC or cancels the command
			'   MsgBox(pPtRes.Value.X)
			' '' Prompt for the end point
			'pPtOpts.Message = vbLf & "Введите конец "
			'pPtRes = acDoc.Editor.GetPoint(pPtOpts)
			If pDblRes.Status <> PromptStatus.Cancel Then

				Exit Do
			Else
				''  lprim.CreateLine(ptPred, pPtRes.Value)
				'acDoc.Editor.DrawVector(ptPred, pPtRes.Value, 11, True)
				'ptPred = pPtRes.Value

			End If
		Loop

		Return pDblRes.Value
	End Function
	Function GetOdinAngleOtPolz(ByVal iTchk As Point3d) As Double
		Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
		Dim acCurDb As Database = acDoc.Database
		Dim pDblRes As PromptDoubleResult
		Dim pAnglOpts As PromptAngleOptions = New PromptAngleOptions("")
		'  Dim ptPred As New Point3d(0, 0, 0)

		Do
			pAnglOpts.Message = vbLf & "укажите направление двумя точками "
			pAnglOpts.UseBasePoint = True
			pAnglOpts.BasePoint = iTchk
			pDblRes = acDoc.Editor.GetAngle(pAnglOpts)
			'  acDoc.Editor.GetCorner()

			' '' Exit if the user presses ESC or cancels the command
			'   MsgBox(pPtRes.Value.X)
			' '' Prompt for the end point
			'pPtOpts.Message = vbLf & "Введите конец "
			'pPtRes = acDoc.Editor.GetPoint(pPtOpts)
			If pDblRes.Status <> PromptStatus.Cancel Then

				Exit Do
			Else
				''  lprim.CreateLine(ptPred, pPtRes.Value)
				'acDoc.Editor.DrawVector(ptPred, pPtRes.Value, 11, True)
				'ptPred = pPtRes.Value

			End If
		Loop

		Return pDblRes.Value
	End Function
	''' <summary>
	''' Ввод одной точки
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Function GetOdnuPointOtPolz() As Point3d
		'' Get the current database and start the Transaction Manager
		Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
		Dim acCurDb As Database = acDoc.Database
		Dim pPtRes As PromptPointResult
		Dim pPtOpts As PromptPointOptions = New PromptPointOptions("")
		'    Dim ptPred As New Point3d(0, 0, 0)
		Dim RezTchk As New Point3dCollection
		Do
			pPtOpts.Message = vbLf & "Введите точку "
			pPtRes = acDoc.Editor.GetPoint(pPtOpts)
			RezTchk.Add(pPtRes.Value)
			If pPtRes.Status <> PromptStatus.Cancel Then
				Exit Do

			End If
		Loop
		Return pPtRes.Value
	End Function

	''' <summary>
	''' Ввод нескольких точек заканчиваеться ESC
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Function GetPointsFromUser() As Point3dCollection
		Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
		Dim acCurDb As Database = acDoc.Database
		Dim pPtRes As PromptPointResult
		Dim pPtOpts As PromptPointOptions = New PromptPointOptions("")
		Dim ptPred As New Point3d(0, 0, 0)
		Dim RezTchk As New Point3dCollection
		' Dim lprim As New BazfunNet.CreateEntities.MakeEntities 'в этом классе функции нужно сделать Shared
		'' Prompt for the start point
		Do
			pPtOpts.Message = vbLf & "Введите точку "
			pPtOpts.UseBasePoint = True
			pPtOpts.BasePoint = ptPred
			pPtRes = acDoc.Editor.GetPoint(pPtOpts)

			RezTchk.Add(pPtRes.Value)
			' '' Exit if the user presses ESC or cancels the command
			'   MsgBox(pPtRes.Value.X)
			' '' Prompt for the end point
			'pPtOpts.Message = vbLf & "Введите конец "
			'pPtRes = acDoc.Editor.GetPoint(pPtOpts)
			If pPtRes.Status = PromptStatus.Cancel Then
				Exit Do
			Else
				'  lprim.CreateLine(ptPred, pPtRes.Value)
				acDoc.Editor.DrawVector(ptPred, pPtRes.Value, 11, True)
				ptPred = pPtRes.Value

			End If
		Loop Until (pPtRes.Status = PromptStatus.Cancel)

		Return RezTchk
	End Function
	''' <summary>
	''' Ввод одной точки от пользоввателя
	''' </summary>
	''' <returns>возвращает коллекцию 0 элемент введненая точка</returns>
	''' <remarks></remarks>
	Function GetPointOtPolz() As Point3dCollection
		'' Get the current database and start the Transaction Manager
		Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
		Dim acCurDb As Database = acDoc.Database
		Dim pPtRes As PromptPointResult
		Dim pPtOpts As PromptPointOptions = New PromptPointOptions("")
		'  Dim ptPred As New Point3d(0, 0, 0)
		Dim RezTchk As New Point3dCollection
		Do
			pPtOpts.Message = vbLf & "Введите точку "
			pPtRes = acDoc.Editor.GetPoint(pPtOpts)
			RezTchk.Add(pPtRes.Value)
			If pPtRes.Status = PromptStatus.OK Then
				Exit Do
			Else
				RezTchk.Clear()
			End If
		Loop
		Return RezTchk
	End Function
#End Region
#Region "Изменение параметров"

	Public Sub changeColor(ByVal entId As ObjectId, ByVal newColor As Long)
		Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database
		Dim tm As DBTransMan = db.TransactionManager
		'start a transaction
		Dim ta As Transaction = tm.StartTransaction()
		Try
			Dim ent As Entity = tm.GetObject(entId, OpenMode.ForWrite, True)
			ent.ColorIndex = newColor
			ta.Commit()
		Catch
			Console.WriteLine("Error in setting the color for the entity")
		Finally
			ta.Dispose()
		End Try
	End Sub
	Public Sub SetObjectLinetype(ByVal NameTipLine As String)
		'' Get the current document and database
		Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
		Dim acCurDb As Database = acDoc.Database
		'' Start a transaction
		Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()

			'' Open the Linetype table for read

			Dim acLineTypTbl As LinetypeTable

			acLineTypTbl = acTrans.GetObject(acCurDb.LinetypeTableId, OpenMode.ForRead)


			Dim sLineTypName As String = NameTipLine


			If acLineTypTbl.Has(sLineTypName) = False Then
				Try
					acCurDb.LoadLineTypeFile(sLineTypName, "acad.lin")
				Catch exA As _AcTrx.Exception
					Application.ShowAlertDialog("Типа линий " & sLineTypName & " нет в файле  Acad.lin" & vbCrLf &
												exA.Message)
					'                    was unhandled by user code  Message = "eUndefinedLineType"                         '                    Source = "acdbmgd"
				Catch ex As System.Exception
					Application.ShowAlertDialog("Системное " & ex.StackTrace & vbCrLf & ex.Message)
					'          

				End Try
			End If

			'' Open the Block table for read
			Dim acBlkTbl As BlockTable

			acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId, OpenMode.ForRead)

			'' Save the changes and dispose of the transaction

			acTrans.Commit()

		End Using

	End Sub
	Public Sub changeSloj(ByVal entId As ObjectId, ByVal newSl As String)
		Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database
		Dim tm As DBTransMan = db.TransactionManager
		'start a transaction
		Dim ta As Transaction = tm.StartTransaction()
		Try
			Dim ent As Entity = tm.GetObject(entId, OpenMode.ForWrite, True)
			ent.Layer = newSl
			ta.Commit()
		Catch
			Application.ShowAlertDialog("Cлой " & newSl & " не установлен")
		Finally
			ta.Dispose()
		End Try
	End Sub
	Public Sub changeSloj(ByVal centId As ObjectIdCollection, ByVal newSl As String)
		Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database
		Dim tm As DBTransMan = db.TransactionManager
		'start a transaction
		Dim ta As Transaction = tm.StartTransaction()
		Try
			Dim entId As ObjectId
			For Each entId In centId
				Dim ent As Entity = tm.GetObject(entId, OpenMode.ForWrite, True)
				ent.Layer = newSl
			Next
			ta.Commit()
		Catch
			Console.WriteLine("ошибка в установление  слоя примитива" & newSl)
		Finally
			ta.Dispose()
		End Try
	End Sub
	Public Sub changeTipLin(ByVal entId As ObjectId, ByVal newTipLin As String)
		Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database
		Dim tm As DBTransMan = db.TransactionManager
		'start a transaction
		Dim ta As Transaction = tm.StartTransaction()
		Try
			Dim ent As Entity = tm.GetObject(entId, OpenMode.ForWrite, True)
			ent.Linetype = newTipLin
			ta.Commit()
		Catch
			Console.WriteLine("Error in setting the layer for the entity")
		Finally
			ta.Dispose()
		End Try
	End Sub
#End Region
#Region "выбраные наборы"
	Public Sub SearchAndInsert(
		ByVal lis As List(Of Point3d),
		ByVal insert As Point3d, ByVal dc As ComparatorPoint)



		Dim index As Integer = lis.BinarySearch(insert, dc)

		If index < 0 Then
			index = index Xor -1
			lis.Insert(index, insert)
		End If
	End Sub
	Private Sub SearchAndInsert(
		ByVal lis As List(Of prbOtrezok),
		ByVal insert As prbOtrezok, ByVal dc As ComparatorPrOtrezok)



		Dim index As Integer = lis.BinarySearch(insert, dc)

		If index < 0 Then
			index = index Xor -1
			lis.Insert(index, insert)
		End If
	End Sub

	Function GetEntity(ByVal spObjid As ObjectId()) As List(Of Entity)
		Dim lSpEnt As New List(Of Entity)
		If spObjid Is Nothing Then Return lSpEnt
		Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database
		Dim tm As DBTransMan = db.TransactionManager
		'start a transaction
		Dim ta As Transaction = tm.StartTransaction()
		For Each objId As ObjectId In spObjid
			Dim ent As Entity = tm.GetObject(objId, OpenMode.ForWrite, True)
			lSpEnt.Add(ent)
		Next


		ta.Commit()

		Console.WriteLine("Error in setting the layer for the entity")

		ta.Dispose()
		Return lSpEnt
	End Function

	Function WibratAllPoint(ByVal NameSl As String) As List(Of Point3d) ' по по линиям и легким полилиниям выбирает все граничные точки и упорядочивает их
		Dim lSpTchk As New List(Of Point3d)
		Dim lComparator As New ComparatorPoint

		Dim acDocEd As Editor = Application.DocumentManager.MdiActiveDocument.Editor
		'' Создание массива из TypedValue дляопределения условий фильтра  
		Dim acTypValAr(0) As TypedValue
		acTypValAr.SetValue(New TypedValue(DxfCode.LayerName, NameSl), 0)
		'' Назначение критериев фильтра объекту SelectionFilter    
		Dim acSelFtr As SelectionFilter = New SelectionFilter(acTypValAr)
		'' Запрос выбора объектов на чертеже  21:   
		Dim acSSPrompt As PromptSelectionResult

		acSSPrompt = acDocEd.SelectAll(acSelFtr)

		'' Если статус запроса ОК, объекты были выбраны  
		If acSSPrompt.Status = PromptStatus.OK Then
			Dim acSSet As SelectionSet = acSSPrompt.Value
			Application.ShowAlertDialog("Kommand:WibratAllPoint " & "Количество выбранных объектов: " &
										acSSet.Count.ToString())
			Dim lspent As List(Of Entity) = GetEntity(acSSet.GetObjectIds)
			For Each el As Entity In lspent
				Select Case el.GetRXClass().DxfName
					Case "LWPOLYLINE"
						Dim i As Integer = 0
						Do

							Dim www As Polyline = CType(el, Polyline)
							If www.GetPoint3dAt(i) = www.EndPoint Then
								SearchAndInsert(lSpTchk, www.EndPoint, lComparator)
								Exit Do
							Else
								SearchAndInsert(lSpTchk, www.GetPoint3dAt(i), lComparator)
							End If
							i += 1
						Loop
					Case "LINE"
						Dim wrLine As Line = CType(el, Line)
						SearchAndInsert(lSpTchk, wrLine.StartPoint, lComparator)
						SearchAndInsert(lSpTchk, wrLine.EndPoint, lComparator)
					Case Else

				End Select
			Next
			Return lSpTchk
		Else
			Application.ShowAlertDialog("Kommand:WibratAllPoint Количество выбранных объектов: 0")
		End If
		Return Nothing

	End Function
	Function WibratAllOtrezki(ByVal NameSl As String) As List(Of prbOtrezok) ' по по линиям и легким полилиниям выбирает все граничные точки и упорядочивает их
		Dim lSpOtrezkow As New List(Of prbOtrezok)
		Dim lComparator As New ComparatorPrOtrezok

		Dim acDocEd As Editor = Application.DocumentManager.MdiActiveDocument.Editor
		'' Создание массива из TypedValue дляопределения условий фильтра  
		Dim acTypValAr(0) As TypedValue
		acTypValAr.SetValue(New TypedValue(DxfCode.LayerName, NameSl), 0)
		'' Назначение критериев фильтра объекту SelectionFilter    
		Dim acSelFtr As SelectionFilter = New SelectionFilter(acTypValAr)
		'' Запрос выбора объектов на чертеже  21:   
		Dim acSSPrompt As PromptSelectionResult

		acSSPrompt = acDocEd.SelectAll(acSelFtr)

		'' Если статус запроса ОК, объекты были выбраны  
		If acSSPrompt.Status = PromptStatus.OK Then
			Dim acSSet As SelectionSet = acSSPrompt.Value
			Application.ShowAlertDialog("Количество выбранных объектов: " &
										acSSet.Count.ToString())
			Dim lspent As List(Of Entity) = GetEntity(acSSet.GetObjectIds)
			For Each el As Entity In lspent
				Select Case el.GetRXClass().DxfName
					Case "LWPOLYLINE"
						Dim lwPlLine As Polyline = CType(el, Polyline)
						Dim lpred As Point3d = lwPlLine.GetPoint3dAt(0)
						Dim i As Integer = 1
						Do
							Dim lpoint As Point3d = lwPlLine.GetPoint3dAt(i)

							Dim lotrez As New prbOtrezok(lpred, lpoint)
							SearchAndInsert(lSpOtrezkow, lotrez, lComparator)
							If lpoint = lwPlLine.EndPoint Then
								Exit Do
							Else
								lpred = lpoint
								i += 1
							End If




						Loop
					Case "LINE"
						Dim wrLine As Line = CType(el, Line)

						SearchAndInsert(lSpOtrezkow, New prbOtrezok(wrLine.StartPoint, wrLine.EndPoint), lComparator)

					Case Else

				End Select
			Next
			Return lSpOtrezkow
		Else
			Application.ShowAlertDialog("WibratAllPoint Количество выбранных объектов: 0")
		End If
		Return Nothing

	End Function

	Function WibranNab() As List(Of Point3d)
		Dim lSpisok As New List(Of Point3d)
		Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
		Dim acCurDb As Database = acDoc.Database
		Dim acDocEd As Editor = acDoc.Editor
		'' Получение набора предварительного выбора (PickFirst)  
		Dim acSSPrompt As PromptSelectionResult
		acSSPrompt = acDocEd.SelectImplied()
		Dim acSSet As SelectionSet = Nothing

		'' Если статус запроса OK, объекты были выбраны перед запуском команды 
		If acSSPrompt.Status = PromptStatus.OK Then
			acSSet = acSSPrompt.Value

			'    Application.ShowAlertDialog("Количество объектов в наборе Pickfirst: " & _
			'                                acSSet.Count.ToString())
		Else
			'   ' Application.ShowAlertDialog("Количество объектов в наборе Pickfirst: 0")
			Return lSpisok
		End If

		Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
			For Each acSSObj As SelectedObject In acSSet
				'' Проверка, нужно убедится в правильности полученного объекта
				If Not IsDBNull(acSSObj) Then
					'' Открытие объекта для записи
					Dim acEnt As Entity = acTrans.GetObject(acSSObj.ObjectId,
															 OpenMode.ForRead)
					'  Dim wwwww As String = acEnt.GetRXClass().DxfName
					If Not IsDBNull(acEnt) Then
						If acEnt.GetRXClass().DxfName = "LWPOLYLINE" Then

							Dim i As Integer = 0
							Do

								Dim www As Polyline = CType(acEnt, Polyline)

								If www.GetPoint3dAt(i) = www.EndPoint Then
									lSpisok.Add(www.EndPoint)
									Exit Do
								Else
									lSpisok.Add(www.GetPoint3dAt(i))
								End If
								i += 1
							Loop
						Else
							If acEnt.GetRXClass().DxfName = "LINE" Then
								Dim wrLine As Line = CType(acEnt, Line)
								If wrLine.StartPoint.X <= wrLine.EndPoint.X Then
									lSpisok.Add(wrLine.StartPoint)
									lSpisok.Add(wrLine.EndPoint)
								Else
									lSpisok.Add(wrLine.EndPoint)
									lSpisok.Add(wrLine.StartPoint)
								End If
							End If
						End If
					End If
				End If
			Next
			acTrans.Commit()
		End Using
		Return lSpisok
	End Function
	Function Wibrano(ByVal iSloj As String) As List(Of Double)
		Dim lSpisok As New List(Of Double)
		Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
		Dim acCurDb As Database = acDoc.Database
		Dim acDocEd As Editor = acDoc.Editor
		'' Получение набора предварительного выбора (PickFirst)  
		Dim acSSPrompt As PromptSelectionResult
		acSSPrompt = acDocEd.SelectImplied()
		Dim acSSet As SelectionSet = Nothing

		'' Если статус запроса OK, объекты были выбраны перед запуском команды 
		If acSSPrompt.Status = PromptStatus.OK Then
			acSSet = acSSPrompt.Value

			'    Application.ShowAlertDialog("Количество объектов в наборе Pickfirst: " & _
			'                                acSSet.Count.ToString())
		Else
			'   ' Application.ShowAlertDialog("Количество объектов в наборе Pickfirst: 0")
			Return lSpisok
		End If

		Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
			For Each acSSObj As SelectedObject In acSSet
				'' Проверка, нужно убедится в правильности полученного объекта
				If Not IsDBNull(acSSObj) Then
					'' Открытие объекта для записи
					Dim acEnt As Entity = acTrans.GetObject(acSSObj.ObjectId,
															 OpenMode.ForRead)
					If Not IsDBNull(acEnt) Then
						If acEnt.Layer = iSloj And acEnt.GetRXClass().DxfName = "LINE" Then
							lSpisok.Add(CType(acEnt, Line).StartPoint.X)
						End If
					End If
				End If
			Next
			acTrans.Commit()
		End Using
		Return lSpisok
	End Function
	Public Sub CheckForPickfirstSelection()
		'' Получение текущего документа  
		Dim acDocEd As Editor = Application.DocumentManager.MdiActiveDocument.Editor

		'' Получение набора предварительного выбора (PickFirst)  
		Dim acSSPrompt As PromptSelectionResult
		acSSPrompt = acDocEd.SelectImplied()
		Dim acSSet As SelectionSet

		'' Если статус запроса OK, объекты были выбраны перед запуском команды 
		If acSSPrompt.Status = PromptStatus.OK Then
			acSSet = acSSPrompt.Value

			Application.ShowAlertDialog("Количество объектов в наборе Pickfirst: " &
										acSSet.Count.ToString())
		Else
			Application.ShowAlertDialog("Количество объектов в наборе Pickfirst: 0")
		End If

		'' Очистка набора PickFirst  
		Dim idarrayEmpty() As ObjectId = Nothing
		acDocEd.SetImpliedSelection(idarrayEmpty)

		'' Запрос выбора объектов на чертеже  
		acSSPrompt = acDocEd.GetSelection()



		'' Если статус запроса OK, объекты были выбраны  

		If acSSPrompt.Status = PromptStatus.OK Then
			acSSet = acSSPrompt.Value

			Application.ShowAlertDialog("Количество выбранных объектов: " &
										acSSet.Count.ToString())
		Else
			Application.ShowAlertDialog("Количество выбранных объектов: 0")
		End If
	End Sub
#End Region
End Module
