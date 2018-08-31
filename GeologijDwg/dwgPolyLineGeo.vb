
#If ARX_APP Then
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.EditorInput
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
Imports System.Collections.Generic
Imports BazDwg
Imports modelGeo
Imports Autodesk.AutoCAD.Colors
'Imports Autodesk.AutoCAD.ApplicationServices.Core

Public Class SwajzPolylineTrassa
	Private wPolyline As Polyline   'полилиния на которую выноситься профиль и расстановка
	Private wTrassa As clsPrf.clsTrass
	Private wSpDistanze As New List(Of Double)  'растояние от начала полилинии до вершин полилинии
	Private wSpTchk As New List(Of Point3d)  'координаты вершин полилинии
	Private wSpSeg As New List(Of LineSegment3d)
	Private wRasstProfWershinah As New List(Of Double)  'растояние в смысле профиля от начала профиля до вершин полилинии
	Private wPiketProfilWershin As New List(Of clsPrf.ClsPiket)  'cоответствие пикетам вершинам полилинии каждой вершине находим ближайший пикет
	Private wKolwo As Integer     'количество вершин полилинии
	' Private wKoeffNormTrassaPolyline As Double
#Region "Init"
	Sub New(iTrassa As clsPrf.clsTrass, iPolyline As Polyline)
		wPolyline = iPolyline
		wTrassa = iTrassa
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
			Dim lPiket As clsPrf.ClsPiket = wTrassa.Piket(wSpDistanze(I))
			wRasstProfWershinah.Add(lPiket.RastOtnachala)
			wPiketProfilWershin.Add(lPiket)
		Next
	End Sub
#End Region




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
		If iDistanze <= 0 Then Return CType(wTrassa.Uchastki(1), clsPrf.clsUchPrf).BegUch.Piketaj
		Dim index As Integer = wSpDistanze.BinarySearch(iDistanze)
		If index >= 0 Then Return wPiketProfilWershin(index).Piketaj

		index = index Xor -1

		If index = wKolwo Then Return wPiketProfilWershin.Last.Piketaj
		index -= 1
		Return iDistanze - wSpDistanze(index) + wPiketProfilWershin(index).Piketaj
	End Function
	Function DistanzePolylineToPiketDo(iDistanze As Double) As clsPrf.ClsPiket
		If iDistanze <= 0 Then Return CType(wTrassa.Uchastki(1), clsPrf.clsUchPrf).BegUch
		Dim index As Integer = wSpDistanze.BinarySearch(iDistanze)
		If index >= 0 Then Return wPiketProfilWershin(index)

		index = index Xor -1

		If index = wKolwo Then Return wPiketProfilWershin.Last
		index -= 1
		Return wPiketProfilWershin(index)
	End Function
	Function DistanzePolylineToPiketPosle(iDistanze As Double) As clsPrf.ClsPiket
		If iDistanze <= 0 Then Return CType(wTrassa.Uchastki(1), clsPrf.clsUchPrf).BegUch
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


#Region "Read onlu Get "

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

	Function WsePointLwPolyline(iSpobjectow As IEnumerable(Of clsPrf.IObjectTrass)) As List(Of Point3d)
		Dim lpoint As New List(Of Point3d)
		For Each el As clsPrf.IObjectTrass In iSpobjectow
			Dim lIndexWerShin As Integer = NajtiBlijaischujVerShinu(el.Rastojnie)
			If Math.Abs(wSpDistanze(lIndexWerShin) - el.Rastojnie) < 2 Then
				lpoint.Add(wSpTchk(lIndexWerShin))
			Else
				Dim llRast = RastPoTraseToDistanzePolyline(el.Rastojnie)
				Try
					lpoint.Add(wPolyline.GetPointAtDist(llRast))
				Catch ex As Exception
					lpoint.Add(wPolyline.EndPoint)
					If llRast - wPolyline.Length > 10 Then
						MsgBox(Me.ToString & "WsePointLwPolyline" & "Длина трассы плана меньше расстояния до последней точки:" & vbCr _
							   & "Длина трассы плана  " & Format(wPolyline.Length, "f1") & vbCr _
							   & "Растояние до последней точки " & llRast & "  " & Format(iSpobjectow.Last, "f1") & vbCr _
							   & "точка в конце  трассы")
					End If
				End Try



			End If

		Next
		Return lpoint
	End Function


	ReadOnly Property LwPolyLine As Polyline
		Get
			Return wPolyline
		End Get
	End Property
	ReadOnly Property BegTrass() As clsPrf.ClsPiket
		Get
			Return CType(wTrassa.Uchastki(1), clsPrf.clsUchPrf).BegUch
		End Get
	End Property
	ReadOnly Property EndTrass() As clsPrf.ClsPiket
		Get
			Return CType(wTrassa.Uchastki(wTrassa.Uchastki.Count), clsPrf.clsUchPrf).EndUch
		End Get
	End Property

#End Region
End Class
Public Class dwgPolyLineGeo
	Private wTrassa As clsPrf.clsTrass
	Private wModGeologii As modelGeo.GeologijReal
	Private acDoc As Document = Application.DocumentManager.MdiActiveDocument
	Private ed As Editor = acDoc.Editor
	Private MatrPr As Matrix3d = ed.CurrentUserCoordinateSystem
	Private Matr As Matrix3d = MatrPr.Inverse
	Shared Function NajtiSwajzPolylineTrassa(iTrassa As clsPrf.clsTrass) As SwajzPolylineTrassa

		Dim led As Editor = Application.DocumentManager.MdiActiveDocument.Editor

		Dim result As PromptSelectionResult = led.GetSelection()
		If (result.Status = PromptStatus.OK) Then

			Dim acSset As SelectionSet = result.Value

			Dim lspent As List(Of Entity) = BazDwg.GetEntity(acSset.GetObjectIds)
			If lspent Is Nothing Then
				Application.ShowAlertDialog("не выбрано ")
				Return Nothing
			End If
			Dim lObjSwajzRasstPolyline As SwajzPolylineTrassa = Nothing
			For Each el As Entity In lspent

				If el.GetRXClass().DxfName <> "LWPOLYLINE" Then Continue For
				lObjSwajzRasstPolyline = New SwajzPolylineTrassa(iTrassa, CType(el, Polyline))
				Return lObjSwajzRasstPolyline

			Next


			Application.ShowAlertDialog("не выбрано ни одной полилинии")
			Return Nothing

		Else
			Application.ShowAlertDialog("Ничего")
			Return Nothing
		End If
	End Function
	'Shared Function WiwestiNadSegmentomPolyline(iR As Double, iTxt As String, iObjSwajzRasstPolyline As SwajzPolylineTrassa) As DBText
	'    Dim lNormRasstOtnachala As Double = iObjSwajzRasstPolyline.RastPoTraseToDistanzePolyline(iR)
	'    Dim PointSot As Point3d = iObjSwajzRasstPolyline.LwPolyLine.GetPointAtDist(lNormRasstOtnachala)
	'    Dim ldirect As Vector3d = iObjSwajzRasstPolyline.DirectionWTchk(lNormRasstOtnachala)
	'    Dim wugol As Double = New Vector2d(ldirect.X, ldirect.Y).Angle
	'    If String.IsNullOrEmpty(iTxt) Then iTxt = "pusto"

	'    Dim lorto As Vector3d = ldirect.GetPerpendicularVector


	'    Dim lPointGr As Point3d = New Point3d(PointSot.X + 5 * lorto.X, PointSot.Y + 5 * lorto.Y, 0) 'cоздаем отметку в сотни
	'    Dim lPointGr1 As Point3d = New Point3d(PointSot.X - 5 * lorto.X, PointSot.Y - 5 * lorto.Y, 0)



	'    Dim prText As DBText
	'    If lPointGr.Y > lPointGr1.Y Then ' выводим текст у границу где  Y больше 
	'        prText = CType(BazfunNet.dbPrim.CreateText(lPointGr, iTxt, 4), DBText)
	'    Else
	'        prText = CType(BazfunNet.dbPrim.CreateText(lPointGr1, iTxt, 4), DBText)
	'    End If
	'    If wugol > 0.5 * Math.PI And wugol < 1.5 * Math.PI Then
	'        prText.Rotation = wugol - Math.PI
	'    Else
	'        prText.Rotation = wugol
	'    End If
	'    prText.TextStyleId = BazfunNet.dbPrim.ObjectIdStyle

	'    Dim ldl As Double = 0.7 * Math.Abs(prText.GeometricExtents.MaxPoint.DistanceTo(prText.GeometricExtents.MinPoint)) 'определяем длину текста

	'    lPointGr = New Point3d(PointSot.X + 6.7 * lorto.X, PointSot.Y + 6.7 * lorto.Y, 0) 'сдвигаем границу для отступа текста
	'    lPointGr1 = New Point3d(PointSot.X - 6.7 * lorto.X, PointSot.Y - 6.7 * lorto.Y, 0) 'сдвигаем границу для отступа текста

	'    Dim lpointTxt, lpointTxt1 As Point3d

	'    If lPointGr.Y > lPointGr1.Y Then 'окончательно определяем точки вставки , что бы текст был над серидиной отметк и шел от меньшего   

	'        lpointTxt = New Point3d(lPointGr.X + 0.5 * ldl * ldirect.X, lPointGr.Y + 0.5 * ldl * ldirect.Y, 0)
	'        lpointTxt1 = New Point3d(lPointGr.X - 0.5 * ldl * ldirect.X, lPointGr.Y - 0.5 * ldl * ldirect.Y, 0)

	'    Else

	'        lpointTxt = New Point3d(lPointGr1.X + 0.5 * ldl * ldirect.X, lPointGr1.Y + 0.5 * ldl * ldirect.Y, 0)
	'        lpointTxt1 = New Point3d(lPointGr1.X - 0.5 * ldl * ldirect.X, lPointGr1.Y - 0.5 * ldl * ldirect.Y, 0)

	'    End If

	'    If lpointTxt.X > lpointTxt1.X Then
	'        lpointTxt = lpointTxt1
	'    End If
	'    prText.Position = lpointTxt
	'    Return prText
	'End Function


	Sub New(iModGeologii As modelGeo.GeologijReal)
		wModGeologii = iModGeologii
		wTrassa = wModGeologii.Trassa
	End Sub
	Private Function GetRasstojnijDoSkwajn() As List(Of Double)
		Dim lT As New List(Of Double)
		For Each el As modelGeo.SkwajnaReal In wModGeologii.SpSkwaj
			lT.Add(el.Rastojnie)
		Next
		Return lT
	End Function
	Shared Function WiwestiOkoloSegmentomPolyline(iR As Double, iTxt As String, iObjSwajzRasstPolyline As SwajzPolylineTrassa, iSdwig As Double) As DBText
		Dim lNormRasstOtnachala As Double = iObjSwajzRasstPolyline.RastPoTraseToDistanzePolyline(iR)
		Dim PointSot As Point3d = iObjSwajzRasstPolyline.LwPolyLine.GetPointAtDist(lNormRasstOtnachala)
		Dim ldirect As Vector3d = iObjSwajzRasstPolyline.DirectionWTchk(lNormRasstOtnachala)
		Dim wugol As Double = New Vector2d(ldirect.X, ldirect.Y).Angle
		If String.IsNullOrEmpty(iTxt) Then iTxt = "pusto"

		Dim lorto As Vector3d = ldirect.GetPerpendicularVector
		Dim lpointGr = PointSot + lorto
		Dim lpointGr1 = PointSot - lorto


		Dim prText As DBText
		If lpointGr.Y < lpointGr1.Y Then ' выводим текст у границу где  Y больше 
			lpointGr = lpointGr1
		End If
		prText = CType(BazDwg.dbPrim.CreateText(lpointGr, iTxt, ParamImageGeo.HtxtGeo), DBText)
		If wugol > 0.5 * Math.PI And wugol < 1.5 * Math.PI Then
			prText.Rotation = wugol - Math.PI
		Else
			prText.Rotation = wugol
		End If
		prText.TextStyleId = BazDwg.dbPrim.ObjectIdStyle

		Dim ldl As Double = 0.7 * Math.Abs(prText.GeometricExtents.MaxPoint.DistanceTo(prText.GeometricExtents.MinPoint)) 'определяем длину текста

		Dim lpointTxt, lpointTxt1 As Point3d

		'окончательно определяем точки вставки , что бы текст был над серидиной отметк и шел от меньшего   
		lpointTxt = lpointGr + 0.5 * ldl * ldirect
		lpointTxt1 = lpointGr - 0.5 * ldl * ldirect


		If lpointTxt.X > lpointTxt1.X Then
			lpointTxt = lpointTxt1
		End If

		prText.Position = lpointTxt + iSdwig * lorto
		Return prText
	End Function


	'Sub New(iModGeologii As modelGeo.GeologijReal)
	'    wModGeologii = iModGeologii
	'    wTrassa = wModGeologii.Trassa
	'End Sub
	'Private Function GetRasstojnijDoSkwajn() As List(Of Double)
	'    Dim lT As New List(Of Double)
	'    For Each el As modelGeo.SkwajnaReal In wModGeologii.SpSkwaj
	'        lT.Add(el.Rastojnie)
	'    Next
	'    Return lT
	'End Function
	Private Sub WiwestiSkwaj(iskwaj As modelGeo.SkwajnaReal, iPointWstawki As Point3d)


		Dim lpointwstawkiName As New Point3d(iPointWstawki.X + 1, iPointWstawki.Y - 5, 0)

		Dim lobjId As ObjectId = BazDwg.MakeEntities.CreateWstawkBlock(iPointWstawki, modelGeo.TipOpred.NameBlok(iskwaj.Tip))

		Dim lNameMtext As MText = CType(dbPrim.CreateMText(lpointwstawkiName, SkwajnaRealDwg.NameSqwajnawiw(iskwaj.NumName, iskwaj.Otmetka), 10, 2.5), MText)
		lNameMtext.Layer = DwgParam.slPlanGeologij
		'  lNameMtext.ColorIndex = 10
		BazDwg.changeSloj(lobjId, DwgParam.slPlanGeologij)
		'   BazfunNet.changeColor(lobjId, 11)
		dbPrim.Wkl(lNameMtext)
	End Sub
	Public Sub GeologijNaPolyline()
		Dim lObjSwajzTrassPolyline As SwajzPolylineTrassa = NajtiSwajzPolylineTrassa(wTrassa)
		If lObjSwajzTrassPolyline Is Nothing Then Return
		BazDwg.dbPrim.UstStil("UgESP")
		Dim lSpPointPolyline As List(Of Point3d) = Nothing

		BazDwg.Kommand.createNewLayer(DwgParam.slPlanGeologij, Color.FromColor(Drawing.Color.Aqua).ColorIndex)
		BazDwg.Kommand.createNewLayerNePrint(DwgParam.SlPlanGeoWspomog, Color.FromColor(Drawing.Color.BlueViolet).ColorIndex)
		BazDwg.netSelectSet.OchistitSloj(DwgParam.slPlanGeologij)
		BazDwg.netSelectSet.OchistitSloj(DwgParam.SlPlanGeoWspomog)
		Dim lsp As List(Of SkwajnaReal) = wModGeologii.GetAktualSkwajn
		lSpPointPolyline = lObjSwajzTrassPolyline.WsePointLwPolyline(lsp)

		Dim colldb As New DBObjectCollection

		Dim el_pred As modelGeo.SkwajnaReal = Nothing

		For i = 0 To lSpPointPolyline.Count - 1
			Dim lT As Point3d = lSpPointPolyline(i)
			Dim lskwaj As modelGeo.SkwajnaReal = lsp(i)
			Dim iRazm As Double = 1

			WiwestiSkwaj(lskwaj, lT)
			With lskwaj
				Dim lMleader = BazDwg.dbPrim.CreateMLeader(New Point3d(lT.X, lT.Y - 20, 0), lT, "Отметка" & "\P" &
											  Format(.Otmetka, "f1") & "\P" & clsPrf.ClsPiket.StrPiketaj(.Piketaj))
				lMleader.Layer = DwgParam.SlPlanGeoWspomog
				colldb.Add(lMleader)
			End With


			If el_pred IsNot Nothing Then
				Dim lprText As DBText = WiwestiOkoloSegmentomPolyline(0.5 * (el_pred.Rastojnie + lskwaj.Rastojnie),
																	Format(lskwaj.Rastojnie - el_pred.Rastojnie, "f0"), lObjSwajzTrassPolyline, -2 * ParamImageGeo.HtxtGeo)

				lprText.Justify = AttachmentPoint.BaseLeft
				'   lprText.Oblique =                       ltxtStyl.ObliquingAngle
				lprText.Layer = DwgParam.SlPlanGeoWspomog
				lprText.WidthFactor = 0.7
				colldb.Add(lprText)
			End If

			el_pred = lskwaj

		Next


		BazDwg.dbPrim.Wkl(colldb)


	End Sub

End Class
