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
Imports Bricscad.Runtime
Imports _AcTrx = Teigha.Runtime
Imports _AcWnd = Bricscad.Windows
Imports DBTransMan = Teigha.DatabaseServices.TransactionManager
#End If

Imports System.Collections.Generic
'Imports System.Core
'Imports System.Xml.Linq

Public Class SwajzPolylineRasst
	Private wPolyline As Polyline   'полилиния на которую выноситься профиль и расстановка
	Private wRasst As modRasstOp.wlRasst
	Private wSpDistanze As New List(Of Double)
	Private wSpTchk As New List(Of Point3d)  'координаты вершин полилинии
	Private wSpSeg As New List(Of LineSegment3d)
	Private wRasstProfWershinah As New List(Of Double)  'растояние в смысле профиля от начала профиля до вершин полилинии
	Private wPiketProfilWershin As New List(Of clsPrf.ClsPiket)  'cоответствие пикетам вершинам полилинии
	Private wKolwo As Integer
	' Private wKoeffNormTrassaPolyline As Double
#Region "Init"
	Sub New(irasst As modRasstOp.wlRasst, iPolyline As Polyline)
		wPolyline = iPolyline
		wRasst = irasst
		InitWsePolylineline()
		UstanowitPiketWershin()

	End Sub
	Private Sub InitWsePolylineline()

		'  Строим вспомогательные списки точек и дистанций полилинии.
		Dim i As Integer = 0

		wKolwo = wPolyline.NumberOfVertices
		Do Until i = wKolwo
			Dim lpoint As Point3d = wPolyline.GetPoint3dAt(i)
			wSpTchk.Add(lpoint)
			wSpDistanze.Add(wPolyline.GetDistAtPoint(lpoint))
			Try
				Dim wsp As Vector3d = wPolyline.GetLineSegmentAt(i).Direction
				wSpSeg.Add(wPolyline.GetLineSegmentAt(i))

			Catch ex As Exception
				'     MsgBox(Me.ToString & " Для " & i & " нет сегмента ")
			End Try

			i += 1
		Loop
		' MsgBox(Me.ToString & " T  " & wSpTchk.Count & " D " & wSpDistanze.Count & " S " & wSpSeg.Count)
	End Sub
	Private Sub UstanowitPiketWershin()
		For I As Integer = 0 To wSpDistanze.Count - 1
			Dim lPiket As clsPrf.ClsPiket = wRasst.Trassa.Piket(wSpDistanze(I))
			wRasstProfWershinah.Add(lPiket.RastOtnachala)
			wPiketProfilWershin.Add(lPiket)
		Next
	End Sub
#End Region


	ReadOnly Property Opori() As Collection
		Get
			Return wRasst.opColl

		End Get
	End Property

	''' <summary>
	''' по расстоянию по трассе профиля находит растояние на поллилинии
	''' такое чтобы точка полилинии была на таком же расстояние от вершины полилинии как и от пикетной точки профиля  
	''' </summary>
	''' <param name="ir"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	Function RastPoTraseToDistanzePolyline(ir As Double) As Double
		If ir <= 0 Then Return 0
		Dim index As Integer = wRasstProfWershinah.BinarySearch(ir)
		If index >= 0 Then Return wSpDistanze(index)

		index = index Xor -1

		If index = wKolwo Then Return wSpDistanze.Last
		index -= 1
		Return ir - wRasstProfWershinah(index) + wSpDistanze(index)



	End Function
	Function DistanzePolylineToPiketajProfilaj(iDistanze As Double) As Double
		If iDistanze <= 0 Then Return CType(wRasst.Trassa.Uchastki(1), clsPrf.clsUchPrf).BegUch.Piketaj
		Dim index As Integer = wSpDistanze.BinarySearch(iDistanze)
		If index >= 0 Then Return wPiketProfilWershin(index).Piketaj

		index = index Xor -1

		If index = wKolwo Then Return wPiketProfilWershin.Last.Piketaj
		index -= 1
		Return iDistanze - wSpDistanze(index) + wPiketProfilWershin(index).Piketaj
	End Function
	Function DistanzePolylineToPiketDo(iDistanze As Double) As clsPrf.ClsPiket
		If iDistanze <= 0 Then Return CType(wRasst.Trassa.Uchastki(1), clsPrf.clsUchPrf).BegUch
		Dim index As Integer = wSpDistanze.BinarySearch(iDistanze)
		If index >= 0 Then Return wPiketProfilWershin(index)

		index = index Xor -1

		If index = wKolwo Then Return wPiketProfilWershin.Last
		index -= 1
		Return wPiketProfilWershin(index)
	End Function
	Function DistanzePolylineToPiketPosle(iDistanze As Double) As clsPrf.ClsPiket
		If iDistanze <= 0 Then Return CType(wRasst.Trassa.Uchastki(1), clsPrf.clsUchPrf).BegUch
		Dim index As Integer = wSpDistanze.BinarySearch(iDistanze)
		If index >= 0 Then Return wPiketProfilWershin(index)

		index = index Xor -1

		If index = wKolwo Then Return wPiketProfilWershin.Last

		Return wPiketProfilWershin(index)
	End Function
	Function DistanzePolylineToRasstProfilaj(iDistanze As Double) As Double
		If iDistanze <= 0 Then Return 0
		Dim index As Integer = wSpDistanze.BinarySearch(iDistanze)
		If index >= 0 Then Return wPiketProfilWershin(index).RastOtnachala

		index = index Xor -1

		If index = wKolwo Then Return wPiketProfilWershin.Last.RastOtnachala
		index -= 1
		Return iDistanze - wSpDistanze(index) + wPiketProfilWershin(index).RastOtnachala
	End Function
	Function DirectionWTchk(iR As Double) As Vector3d
		Dim index As Integer = wSpDistanze.BinarySearch(iR)
		If index < 0 Then index = index Xor -1
		If index = wKolwo Then
			Return New Vector3d(1, 0, 0)
		End If
		If index > 0 Then
			Return wSpSeg(index - 1).Direction
		Else
			Return New Vector3d(1, 0, 0)
		End If

	End Function

	'Function WsePointLwPolylinePoSpRast(ByVal iSp As List(Of Double)) As List(Of Point3d)
	'    Dim lSpTchk As New List(Of Point3d)


	'    Dim ldlina As Double

	'    ldlina = wPolyline.Length
	'    For Each wrr As Double In iSp

	'        If wrr > ldlina Then Exit For
	'        '  lSpTchk.Add(www.GetPointAtParameter(wrli / ldlina))
	'        lSpTchk.Add(wPolyline.GetPointAtDist(wrr))

	'        ' www.GetPointAtDist()
	'        ' If wrr > ldlina Then Exit For
	'    Next
	'    Return lSpTchk
	'End Function
#Region "Read onlu Get "
	Function WsePointLwPolylineOpor() As List(Of Point3d)
		Dim lpoint As New List(Of Point3d)
		For Each el_op As modRasstOp.wlOpRasst In wRasst.opColl
			Dim lIndexWerShin As Integer = NajtiBlijaischujVerShinu(el_op.RastOtNachala)
			If Math.Abs(wSpDistanze(lIndexWerShin) - el_op.RastOtNachala) < 2 Then
				lpoint.Add(wSpTchk(lIndexWerShin))
			Else
				Dim lRast = RastPoTraseToDistanzePolyline(el_op.RastOtNachala)
				Try
					lpoint.Add(wPolyline.GetPointAtDist(lRast))
				Catch ex As Exception
					lpoint.Add(wPolyline.EndPoint)
					If el_op.RastOtNachala - wPolyline.Length > 10 Then
						MsgBox("Длина трассы плана меньше расстояния до последней опоры:" & vbCr _
							   & "Длина трассы плана  " & Format(wPolyline.Length, "f1") & vbCr _
							   & "Растояние до опоры " & el_op.NumName & "  " & Format(el_op.RastOtNachala, "f1") & vbCr _
							   & "Опора установлена в конце трассы")
					End If
				End Try

				'    If lRast < wPolyline.Length Then
				'        
				'    Else
				'        lpoint.Add(wPolyline.EndPoint)
				'        If lRast - wPolyline.Length > 10 Then
				'            MsgBox("Длина трассы плана меньше расстояния до последней опоры:" & vbCr _
				'                   & "Длина трассы плана  " & wPolyline.Length & vbCr _
				'                   & "Растояние до опоры " & el_op.NumName & "  " & Format(el_op.RastOtNachala, "f1") & vbCr _
				'                   & "Опора установлена в конце трассы")
				'        End If
				'    End If

			End If

		Next
		Return lpoint
	End Function
	ReadOnly Property Tchk() As List(Of Point3d)
		Get
			Return wSpTchk
		End Get
	End Property
	ReadOnly Property Distanze() As List(Of Double)
		Get
			Return wSpDistanze
		End Get
	End Property

	Function Ugol(index As Integer) As Double
		Dim lvectorPred As Vector3d
		Dim lugol As Double
		If index = 0 Then
			lvectorPred = New Vector3d(1, 0, 0)
		Else
			lvectorPred = wSpSeg(index - 1).Direction
		End If
		If index < wKolwo - 1 Then
			lugol = wSpSeg(index).Direction.GetAngleTo(lvectorPred)
		Else
			lugol = 0
		End If

		'   Dim str = clsPrf.clsUgolPoworot.StrGradLwPr(lugol)
		'   Return clsPrf.clsUgolPoworot.StrGradLwPr(lugol)
		Return lugol

	End Function
	ReadOnly Property Tchk(index As Integer) As Point3d
		Get
			If index < 0 Then Return wSpTchk(0)

			If index < wKolwo - 1 Then
				Return wSpTchk(index)
			Else
				Return wSpTchk.Last
			End If

		End Get
	End Property






	Function NajtiBlijaischujVerShinu(iR As Double) As Integer

		Dim index As Integer = wSpDistanze.BinarySearch(iR)
		If index < 0 Then
			index = index Xor -1
			If index = wKolwo Then Return index - 1
			If index > 0 Then
				If iR - wSpDistanze(index - 1) < wSpDistanze(index) - iR Then
					index -= 1
				End If

			End If
		End If
		Return index
	End Function




	ReadOnly Property LwPolyLine As Polyline
		Get
			Return wPolyline
		End Get
	End Property
	ReadOnly Property BegTrass() As clsPrf.ClsPiket
		Get
			Return CType(wRasst.Trassa.Uchastki(1), clsPrf.clsUchPrf).BegUch
		End Get
	End Property
	ReadOnly Property EndTrass() As clsPrf.ClsPiket
		Get
			Return CType(wRasst.Trassa.Uchastki(wRasst.Trassa.Uchastki.Count), clsPrf.clsUchPrf).EndUch
		End Get
	End Property
#End Region
#Region "Poisk"
	Private wKriterij As Double
	Private Function ProvNaBolsche(iR As Double) As Boolean
		If iR > wKriterij Then
			Return True
		Else
			Return False
		End If


	End Function
	Function GetPointPolyLinePiketaDo(iPiket As clsPrf.ClsPiket) As Point3d
		wKriterij = iPiket.RastOtnachala
		Dim lindex As Integer = wSpDistanze.FindIndex(AddressOf ProvNaBolsche)
		If lindex < 0 Then
			Return wSpTchk.Last()
		Else
			If lindex = 0 Then
				Return Nothing
			Else
				Return wSpTchk(lindex - 1)
			End If
		End If

	End Function
	Function GetPointPolyLinePiketaPosle(iPiket As clsPrf.ClsPiket) As Point3d
		wKriterij = iPiket.RastOtnachala
		Dim lindex As Integer = wSpDistanze.FindIndex(AddressOf ProvNaBolsche)
		If lindex < 0 Then
			Return Nothing
		Else
			If lindex = 0 Then
				Return wSpTchk.First()
			Else
				Return wSpTchk(lindex)
			End If
		End If

	End Function
	Function GetIndexPolyLinePosle(iRasstOtnachala As Double) As Integer
		wKriterij = iRasstOtnachala
		Return wSpDistanze.FindIndex(AddressOf ProvNaBolsche)


	End Function
#End Region
End Class
Public Class DwgRasstNaPolyline
	Private wSlPlanUglow, wSlplanSoten, wslPlanPeresech, wSlPlanOpor As String
	Private wRasst As modRasstOp.wlRasst
	Private wTrassa As clsPrf.clsTrass

	Private acDoc As Document = Application.DocumentManager.MdiActiveDocument
	Private ed As Editor = acDoc.Editor
	Private MatrPr As Matrix3d = ed.CurrentUserCoordinateSystem
	Private Matr As Matrix3d = MatrPr.Inverse
	Sub New(iRasst As modRasstOp.wlRasst, iSlPlanUglow As String, iSlplanSoten As String, islPlanPeresech As String, Optional iSlPlanOpor As String = "")
		wRasst = iRasst
		wTrassa = iRasst.Trassa
		wSlPlanUglow = iSlPlanUglow
		wSlplanSoten = iSlplanSoten
		If iSlPlanOpor = "" Then wSlPlanOpor = BazDwg.DwgParam.SlPlanOpor Else wSlPlanOpor = iSlPlanOpor
		wslPlanPeresech = islPlanPeresech
	End Sub
	Private Function NajtiSwajzPolylineRasst() As SwajzPolylineRasst
		If wRasst Is Nothing Then
			Application.ShowAlertDialog("загрузите данные")
			Return Nothing
		End If

		Dim result As PromptSelectionResult = ed.GetSelection()
		If (result.Status = PromptStatus.OK) Then

			Dim acSset As SelectionSet = result.Value

			Dim lspent As List(Of Entity) = BazDwg.GetEntity(acSset.GetObjectIds)
			If lspent Is Nothing Then
				Application.ShowAlertDialog("не выбрано ")
				Return Nothing
			End If
			Dim lObjSwajzRasstPolyline As SwajzPolylineRasst = Nothing
			For Each el As Entity In lspent

				If el.GetRXClass().DxfName <> "LWPOLYLINE" Then Continue For
				lObjSwajzRasstPolyline = New SwajzPolylineRasst(wRasst, CType(el, Polyline))
				Return lObjSwajzRasstPolyline

			Next


			Application.ShowAlertDialog("не выбрано ни одной полилинии")
			Return Nothing

		Else
			Application.ShowAlertDialog("Ничего")
			Return Nothing
		End If
	End Function
	Public Sub ProfNaPolyline() ' This method can have any name


		Dim lObjSwajzRasstPolyline As SwajzPolylineRasst = NajtiSwajzPolylineRasst()
		If lObjSwajzRasstPolyline Is Nothing Then Return

		Dim colldbUglow As New DBObjectCollection
		Dim colldbSoten As New DBObjectCollection
		Dim colldbPeresech As New DBObjectCollection


		BazDwg.Kommand.UstanowitLineWeightLayer(wSlPlanUglow, LineWeight.LineWeight030)
		BazDwg.Kommand.UstanowitColorLayer(wSlPlanUglow, 1)
		BazDwg.Kommand.UstanowitLineWeightLayer(wSlplanSoten, LineWeight.LineWeight030)
		BazDwg.Kommand.UstanowitColorLayer(wSlplanSoten, 1)
		'   BazfunNet.Kommand.createNewLayer(SlSoten, 1)
		BazDwg.Kommand.createNewLayer(wslPlanPeresech)

		BazDwg.netSelectSet.OchistitSloj((wSlPlanUglow))
		BazDwg.netSelectSet.OchistitSloj((wSlplanSoten))
		BazDwg.netSelectSet.OchistitSloj((wslPlanPeresech))
		BazDwg.dbPrim.UstStil("UgESP_ТИЗ")

		' Вывод углов поворота
		Dim el_pred As Double = 0
		Dim index As Integer = 0

		For Each elp As Point3d In lObjSwajzRasstPolyline.Tchk 'Предполагаем что любо угол поворота близок к вершине полилинии 
			Dim lRastajnie As Double = lObjSwajzRasstPolyline.Distanze(index) ' нашли расстояние до очередной вершины

			With wTrassa
				Dim lpik As clsPrf.ClsPiket = .GetPiketBlijaj(lRastajnie)              '.Piket(lRastajnie) 'нашли ближайший пекет к заданой точки
				If lpik IsNot Nothing Then

					If lpik.EstUgolPoworota Then      'если есть угол поворота то отражаем в вершине полилини
						Dim elP_mest As Point3d = elp.TransformBy(Matr) ' clsPrf.clsPiket.StrPiketaj(lpik.Piketaj)
						Dim lStrText As String = lpik.NamePiket & " " & lpik.GetUgolPoworota.StrUglLewoPrawo & "\P" &
												lpik.StrPiketaj(AddressOf clsPrf.ClsPiket.StrPiketaj) & "\P" &
													  "X=" & Format(elP_mest.Y, "f2") & "\P" & "Y=" & Format(elP_mest.X, "f2")
						Dim elMleader As MLeader = CType(BazDwg.dbPrim.CreateMLeader(New Point3d(elp.X - 20, elp.Y + 60, 0), elp, lStrText), MLeader)

						elMleader.Layer = wSlPlanUglow

						colldbUglow.Add(elMleader)


					End If

					'   .Sled()
				End If
			End With
			index += 1
		Next
		'Вывод отметок сотен
		Dim ColSoten As Collection = wTrassa.GetSotni() ' нашли коллекцию сотен
		Dim ltxtStyl As TextStyleTableRecord = BazDwg.dbPrim.TextStil
		For Each els As clsPrf.clsSootTrUch In ColSoten

			Dim lNormRasstOtnachala As Double = lObjSwajzRasstPolyline.RastPoTraseToDistanzePolyline(els.RastOtNachala)
			Dim PointSot As Point3d = lObjSwajzRasstPolyline.LwPolyLine.GetPointAtDist(lNormRasstOtnachala)
			Dim ldirect As Vector3d = lObjSwajzRasstPolyline.DirectionWTchk(lNormRasstOtnachala)
			Dim wugol As Double = New Vector2d(ldirect.X, ldirect.Y).Angle


			Dim lorto As Vector3d = ldirect.GetPerpendicularVector


			Dim lPointGr As Point3d = New Point3d(PointSot.X + 5 * lorto.X, PointSot.Y + 5 * lorto.Y, 0) 'cоздаем отметку в сотни
			Dim lPointGr1 As Point3d = New Point3d(PointSot.X - 5 * lorto.X, PointSot.Y - 5 * lorto.Y, 0)
			colldbSoten.Add(BazDwg.dbPrim.CreateLine(lPointGr1.X, lPointGr1.Y, lPointGr.X, lPointGr.Y))



			Dim prText As DBText
			If lPointGr.Y > lPointGr1.Y Then ' выводим текст у границу где  Y больше 
				prText = CType(BazDwg.dbPrim.CreateText(lPointGr, "ПК" & Fix((els.Piketaj + 1) / 100), 4), DBText)
			Else
				prText = CType(BazDwg.dbPrim.CreateText(lPointGr1, "ПК" & Fix((els.Piketaj + 1) / 100), 4), DBText)
			End If
			If wugol > 0.5 * Math.PI And wugol < 1.5 * Math.PI Then
				prText.Rotation = wugol - Math.PI
			Else
				prText.Rotation = wugol
			End If
			prText.TextStyleId = BazDwg.dbPrim.ObjectIdStyle

			Dim ldl As Double = 0.7 * Math.Abs(prText.GeometricExtents.MaxPoint.DistanceTo(prText.GeometricExtents.MinPoint)) 'определяем длину текста

			lPointGr = New Point3d(PointSot.X + 6.7 * lorto.X, PointSot.Y + 6.7 * lorto.Y, 0) 'сдвигаем границу для отступа текста
			lPointGr1 = New Point3d(PointSot.X - 6.7 * lorto.X, PointSot.Y - 6.7 * lorto.Y, 0) 'сдвигаем границу для отступа текста

			Dim lpointTxt, lpointTxt1 As Point3d

			If lPointGr.Y > lPointGr1.Y Then 'окончательно определяем точки вставки , что бы текст был над серидиной отметк и шел от меньшего   

				lpointTxt = New Point3d(lPointGr.X + 0.5 * ldl * ldirect.X, lPointGr.Y + 0.5 * ldl * ldirect.Y, 0)
				lpointTxt1 = New Point3d(lPointGr.X - 0.5 * ldl * ldirect.X, lPointGr.Y - 0.5 * ldl * ldirect.Y, 0)

			Else

				lpointTxt = New Point3d(lPointGr1.X + 0.5 * ldl * ldirect.X, lPointGr1.Y + 0.5 * ldl * ldirect.Y, 0)
				lpointTxt1 = New Point3d(lPointGr1.X - 0.5 * ldl * ldirect.X, lPointGr1.Y - 0.5 * ldl * ldirect.Y, 0)

			End If

			If lpointTxt.X > lpointTxt1.X Then
				lpointTxt = lpointTxt1
			End If

			prText.Position = lpointTxt
			prText.Justify = AttachmentPoint.BaseLeft
			prText.Oblique = ltxtStyl.ObliquingAngle
			prText.WidthFactor = 0.7
			colldbSoten.Add(prText)


		Next
		'Пересечения
		wTrassa.ustBeg()
		Dim lPikPeresesh As clsPrf.ClsPiket = wTrassa.Piket
		Do Until lPikPeresesh Is Nothing
			Dim lNormRasstOtnachala As Double = lObjSwajzRasstPolyline.RastPoTraseToDistanzePolyline(lPikPeresesh.RastOtnachala)
			If lPikPeresesh.EstPeresech AndAlso lPikPeresesh.Peresech.IdTipSoor < 14 Then
				Try
					Dim lpoint = lObjSwajzRasstPolyline.LwPolyLine.GetPointAtDist(lNormRasstOtnachala)
					Dim ldirect As Vector3d = lObjSwajzRasstPolyline.DirectionWTchk(lNormRasstOtnachala)
					Dim lorto As Vector3d = ldirect.GetPerpendicularVector
					colldbPeresech.Add(BazDwg.dbPrim.CreateMLeader(New Point3d(lpoint.X + 20 * lorto.X, lpoint.Y + 60 * lorto.Y, 0), lpoint, clsPrf.ClsPiket.StrPiketaj(lPikPeresesh.Piketaj) & "\P"))
				Catch ex As Exception

				End Try

			End If
			wTrassa.Sled()
			lPikPeresesh = wTrassa.Piket
		Loop


		BazDwg.dbPrim.Wkl(colldbUglow)
		BazDwg.dbPrim.changeSloj(colldbSoten, wSlplanSoten)
		BazDwg.dbPrim.Wkl(colldbSoten)
		BazDwg.dbPrim.changeSloj(colldbPeresech, wslPlanPeresech)
		BazDwg.dbPrim.Wkl(colldbPeresech)


	End Sub
	''' <summary>
	''' Выводит в  над точкой  полилинии соответсьтвующий заданой точки трасы расстановки надпись параллейно сегменту, которому принадежит эта точка 
	''' </summary>
	''' <param name="iR"> расстояние от начала трасы </param>
	''' <param name="iTxt">выводимый тект </param>
	''' <param name="iObjSwajzRasstPolyline"> объект обеспечивающий связь полилинии с профилем и   расстановкой на нем. </param>
	''' <returns> возвращает примитив текста </returns>
	''' <remarks></remarks>
	Shared Function WiwestiNadSegmentomPolyline(iR As Double, iTxt As String, iObjSwajzRasstPolyline As SwajzPolylineRasst) As DBText
		Dim lNormRasstOtnachala As Double = iObjSwajzRasstPolyline.RastPoTraseToDistanzePolyline(iR)
		Dim PointSot As Point3d = iObjSwajzRasstPolyline.LwPolyLine.GetPointAtDist(lNormRasstOtnachala)
		Dim ldirect As Vector3d = iObjSwajzRasstPolyline.DirectionWTchk(lNormRasstOtnachala)
		Dim wugol As Double = New Vector2d(ldirect.X, ldirect.Y).Angle
		If String.IsNullOrEmpty(iTxt) Then iTxt = "pusto"

		Dim lorto As Vector3d = ldirect.GetPerpendicularVector


		Dim lPointGr As Point3d = New Point3d(PointSot.X + 5 * lorto.X, PointSot.Y + 5 * lorto.Y, 0) 'cоздаем отметку в сотни
		Dim lPointGr1 As Point3d = New Point3d(PointSot.X - 5 * lorto.X, PointSot.Y - 5 * lorto.Y, 0)


		'   Dim ltxtStyl As TextStyleTableRecord = BazfunNet.dbPrim.TextStil

		Dim prText As DBText
		If lPointGr.Y > lPointGr1.Y Then ' выводим текст у границу где  Y больше 
			prText = CType(BazDwg.dbPrim.CreateText(lPointGr, iTxt, 4), DBText)
		Else
			prText = CType(BazDwg.dbPrim.CreateText(lPointGr1, iTxt, 4), DBText)
		End If
		If wugol > 0.5 * Math.PI And wugol < 1.5 * Math.PI Then
			prText.Rotation = wugol - Math.PI
		Else
			prText.Rotation = wugol
		End If
		prText.TextStyleId = BazDwg.dbPrim.ObjectIdStyle

		Dim ldl As Double = 0.7 * Math.Abs(prText.GeometricExtents.MaxPoint.DistanceTo(prText.GeometricExtents.MinPoint)) 'определяем длину текста

		lPointGr = New Point3d(PointSot.X + 6.7 * lorto.X, PointSot.Y + 6.7 * lorto.Y, 0) 'сдвигаем границу для отступа текста
		lPointGr1 = New Point3d(PointSot.X - 6.7 * lorto.X, PointSot.Y - 6.7 * lorto.Y, 0) 'сдвигаем границу для отступа текста

		Dim lpointTxt, lpointTxt1 As Point3d

		If lPointGr.Y > lPointGr1.Y Then 'окончательно определяем точки вставки , что бы текст был над серидиной отметк и шел от меньшего   

			lpointTxt = New Point3d(lPointGr.X + 0.5 * ldl * ldirect.X, lPointGr.Y + 0.5 * ldl * ldirect.Y, 0)
			lpointTxt1 = New Point3d(lPointGr.X - 0.5 * ldl * ldirect.X, lPointGr.Y - 0.5 * ldl * ldirect.Y, 0)

		Else

			lpointTxt = New Point3d(lPointGr1.X + 0.5 * ldl * ldirect.X, lPointGr1.Y + 0.5 * ldl * ldirect.Y, 0)
			lpointTxt1 = New Point3d(lPointGr1.X - 0.5 * ldl * ldirect.X, lPointGr1.Y - 0.5 * ldl * ldirect.Y, 0)

		End If

		If lpointTxt.X > lpointTxt1.X Then
			lpointTxt = lpointTxt1
		End If
		prText.Position = lpointTxt
		Return prText
	End Function
	''' <summary>
	''' Выводит расстановку на полилинии.
	''' </summary>
	''' <remarks></remarks>
	Public Sub RasstNaPolyline() ' This method can have any name

		Dim lObjSwajzRasstPolyline As SwajzPolylineRasst = NajtiSwajzPolylineRasst()
		If lObjSwajzRasstPolyline Is Nothing Then Return
		BazDwg.dbPrim.UstStil("UgESP")
		Dim lSpPointPolyline As List(Of Point3d) = Nothing


		lSpPointPolyline = lObjSwajzRasstPolyline.WsePointLwPolylineOpor()
		Dim colldb As New DBObjectCollection
		Dim collId As ObjectIdCollection
		Dim el_pred As modRasstOp.wlOpRasst = Nothing

		For i = 0 To lSpPointPolyline.Count - 1
			Dim wT As Point3d = lSpPointPolyline(i)
			Dim wOpRasst As modRasstOp.wlOpRasst = CType(lObjSwajzRasstPolyline.Opori(i + 1), modRasstOp.wlOpRasst)
			Dim iRazm As Double = 1
			With wOpRasst
				colldb.Add(BazDwg.dbPrim.CreateNakl(wT.X, wT.Y, iRazm, iRazm, .UgolPoworotaOp))
				colldb.Add(BazDwg.Znaki.CreateKrug(wT.X, wT.Y, 0.5 * iRazm))
				If wOpRasst.Tip > 0 Then
					colldb.Add(BazDwg.Znaki.CreatePrTreg(wT.X, wT.Y, iRazm, .UgolPoworotaOp))

				End If

				colldb.Add(BazDwg.dbPrim.CreateMLeader(New Point3d(wT.X + 10, wT.Y + 30, 0), wT, CStr(.NumName) & "\P" &
											  CStr(.UserTipOp) & "\P" & clsPrf.ClsPiket.StrPiketaj(.Piketaj)))

			End With


			If el_pred IsNot Nothing Then
				Dim lprText As DBText = WiwestiNadSegmentomPolyline(0.5 * (el_pred.RastOtNachala + wOpRasst.RastOtNachala),
																	Format(wOpRasst.RastOtNachala - el_pred.RastOtNachala, "f0"), lObjSwajzRasstPolyline)

				lprText.Justify = AttachmentPoint.BaseLeft
				'   lprText.Oblique =                       ltxtStyl.ObliquingAngle
				lprText.WidthFactor = 0.7
				colldb.Add(lprText)
			End If

			el_pred = wOpRasst

		Next

		BazDwg.Kommand.createNewLayer(wSlPlanOpor, 1)
		BazDwg.netSelectSet.OchistitSloj(wSlPlanOpor)

		collId = BazDwg.dbPrim.Wkl(colldb)
		BazDwg.Kommand.changeSloj(collId, wSlPlanOpor)




	End Sub
	''' <summary>
	''' Выводит расстановку на полилинии.
	''' </summary>
	''' <remarks></remarks>
	Public Sub KoorOporNaPolyline(iNameSl As String) ' This method can have any name

		Dim lObjSwajzRasstPolyline As SwajzPolylineRasst = NajtiSwajzPolylineRasst()
		If lObjSwajzRasstPolyline Is Nothing Then Return
		BazDwg.dbPrim.UstStil("UgESP")
		Dim lSpPointPolyline As List(Of Point3d) = Nothing


		lSpPointPolyline = lObjSwajzRasstPolyline.WsePointLwPolylineOpor() 'Нашли все точки полилинии на которых стоит опора.
		Dim colldb As New DBObjectCollection
		Dim collId As ObjectIdCollection
		Dim el_pred As modRasstOp.wlOpRasst = Nothing

		For i = 0 To lSpPointPolyline.Count - 1
			Dim wT As Point3d = lSpPointPolyline(i)
			Dim wOpRasst As modRasstOp.wlOpRasst = CType(lObjSwajzRasstPolyline.Opori(i + 1), modRasstOp.wlOpRasst)
			Dim iRazm As Double = 1
			With wOpRasst
				'colldb.Add(BazfunNet.dbPrim.CreateNakl(wT.X, wT.Y, iRazm, iRazm, .UgolPoworotaOp))
				'colldb.Add(BazfunNet.Znaki.CreateKrug(wT.X, wT.Y, 0.5 * iRazm))
				'If wOpRasst.Tip > 0 Then
				'    colldb.Add(BazfunNet.Znaki.CreatePrTreg(wT.X, wT.Y, iRazm, .UgolPoworotaOp))

				'End If

				colldb.Add(BazDwg.dbPrim.CreateMLeader(New Point3d(wT.X - 10, wT.Y - 30, 0), wT, " X " & Format(wT.Y, "f2") & "\P" &
											   " Y " & Format(wT.X, "f2")))

			End With


			'If el_pred IsNot Nothing Then
			'    Dim lprText As DBText = WiwestiNadSegmentomPolyline(0.5 * (el_pred.RastOtNachala + wOpRasst.RastOtNachala),
			'                                                        Format(wOpRasst.RastOtNachala - el_pred.RastOtNachala, "f0"), lObjSwajzRasstPolyline)

			'    lprText.Justify = AttachmentPoint.BaseLeft
			'    '   lprText.Oblique =                       ltxtStyl.ObliquingAngle
			'    lprText.WidthFactor = 0.7
			'    colldb.Add(lprText)
			'End If

			el_pred = wOpRasst

		Next

		BazDwg.Kommand.createNewLayer(iNameSl)
		BazDwg.netSelectSet.OchistitSloj(iNameSl)
		For Each el As Entity In colldb
			el.Layer = iNameSl
		Next
		collId = BazDwg.dbPrim.Wkl(colldb)





	End Sub

End Class
