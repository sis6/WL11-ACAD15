#If ARX_APP Then
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.ApplicationServices
Imports DBTransMan = Autodesk.AutoCAD.DatabaseServices.TransactionManager
Imports Autodesk.AutoCAD.ApplicationServices.Core
#Else
Imports Bricscad.ApplicationServices
Imports _AcBr = Teigha.BoundaryRepresentation
Imports _AcCm = Teigha.Colors
Imports Teigha.DatabaseServices
Imports _AcEd = Bricscad.EditorInput
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
Imports clsPrf


Public Class DwgTr
	Inherits clsPrf.clsTrass
	Public Const NameTipLinLwPr As String = "штрихпунктирнаяX2"  '"ACAD_ISO04W100" "STRICHPUNCTIRX2"  
	Public Const NameTipLinPrPr As String = "пунктирнаяX2"    '"ACAD_ISO03W100" "STRICHX2" 
	Public Const WisTextP As Double = 2.0#
	Public Const ColorLewogo As Integer = 6
	Public Const ColorPrawogo As Integer = 14
	Private Const Shir As Double = 1.5 'размер вертикальной черты наносимой на оси пикетов отметок и вспомогательных
	Public objGeom As dwgGeometr   'Shared
	Private Greben, GrebenPr, GrebenLw As ObjectId
	Private NaOsOtm, NaOsOtmLw, NaOsotmPr, NaOsPiket, NaOsSoten, NaOsUglPoworot,
		NaOsPiketUgod, ColPeresech, ColWsp As New ObjectIdCollection
	Private razmetka As New ObjectIdCollection
	Private wNameDwg As String
	Private wLinijProfilDwg As BazDwg.GrebenProfilDwg = Nothing

#Region "read only i Get"
	ReadOnly Property NameDwg As String
		Get
			Return wNameDwg
		End Get
	End Property
	Private ReadOnly Property Podpis() As clsPodpis
		Get
			Return objGeom.Podpis
		End Get
	End Property
	Private ReadOnly Property KoorP() As clsKoor
		Get
			Return objGeom.KoorP
		End Get
	End Property
	Private ReadOnly Property KoorOtm() As clsKoor
		Get
			Return objGeom.KoorOtm
		End Get
	End Property
	ReadOnly Property OsKlRasst() As Double
		Get
			Dim os As Double
			Dim wr As Double = objGeom.DwgYpoOtm(MaxOtmetka) + clsPodpis.NadProfilem
			Dim wrl = objGeom.Podpis.GranizaNadpisi + objGeom.Podpis.ShirRabObl
			If wr < wrl Then
				os = wrl
			Else
				os = wr
			End If
			Return os
		End Get
	End Property
	ReadOnly Property OsX() As Double
		Get
			Return Podpis.OsX
		End Get
	End Property

	ReadOnly Property StrFormatHor As String = "f0"
	ReadOnly Property StrformatVert As String = "f1"
	ReadOnly Property StrFormatOstSotet As String = "00"



	Public Function DwgXpoRast(ByVal Rast As Double) As Double
		Return objGeom.DwgXpoRast(Rast)
	End Function
	Public Function DwgYpoOtm(ByVal Otm As Double) As Double
		Return objGeom.DwgYpoOtm(Otm)
	End Function
	Public Function RastPoDwgX(ByVal DwgX As Double) As Double
		Return objGeom.RastPoDwgX(DwgX)
	End Function
	Public Function OtmPoDwgY(ByVal DwgY As Double) As Double
		Return objGeom.OtmPoDwgY(DwgY)
	End Function
	''' <summary>
	''' Берет основной образ профили представленого в чертеже
	''' </summary>
	''' <returns></returns>
	Private Function GetLinijProfil() As List(Of Point2d)

		Dim isp As New List(Of Point2d)
		ustBeg()
		Do
			With Piket
				Dim tprf As New Point3d(KoorP.GetDwg(RastOtNachala), KoorOtm.GetDwg(.Otmetka), 0)

				isp.Add(New Point2d(tprf.X, tprf.Y))





				Sled()

			End With
		Loop Until Piket Is Nothing
		Return isp
	End Function

	ReadOnly Property GetLinijDwg() As GrebenProfilDwg
		Get
			If wLinijProfilDwg Is Nothing Then
				wLinijProfilDwg = New GrebenProfilDwg(GetLinijProfil)
			End If
			Return wLinijProfilDwg
		End Get
	End Property
#End Region
#Region "Wiwesti"
	Private Sub WiwestiSotni(iPikBeg As clsPrf.ClsPiket, iPikEnd As clsPrf.ClsPiket)
		Dim Col As Collection = GetSotni()
		Dim elcol As clsPrf.clsSootTrUch
		For Each elcol In Col
			Dim lrast = elcol.RastOtNachala
			If lrast < iPikBeg.RastOtnachala Then Continue For
			If lrast > iPikEnd.RastOtnachala Then Exit For
			Dim tWstSot As New Point3d(KoorP.GetDwg(elcol.RastOtNachala), Podpis.OsSotenPik, 0)
			Dim twstSotL As New Point3d(tWstSot.X, Podpis.OsPiket, 0)
			Dim twstSotLe As New Point3d(tWstSot.X, Podpis.OsOtmetok, 0)

			NaOsSoten.Add(MakeEntities.CreateLine(twstSotL, twstSotLe))
			NaOsSoten.Add(dwgText.CreateText(New Point3d(tWstSot.X, tWstSot.Y + 1, 0), elcol.strInf, 2))
			ColWsp.Add(MakeEntities.CreateLine(tWstSot.X, Podpis.PolGrafAbr - 2.0 * Shir, tWstSot.X, Podpis.PolGrafAbr + 2.0 * Shir))
		Next
	End Sub
	Private Sub WiwestiSotni()
		Dim Col As Collection = GetSotni()
		Dim elcol As clsPrf.clsSootTrUch
		For Each elcol In Col
			Dim tWstSot As New Point3d(KoorP.GetDwg(elcol.RastOtNachala), Podpis.OsSotenPik, 0)
			Dim twstSotL As New Point3d(tWstSot.X, Podpis.OsPiket, 0)
			Dim twstSotLe As New Point3d(tWstSot.X, Podpis.OsOtmetok, 0)

			NaOsSoten.Add(MakeEntities.CreateLine(twstSotL, twstSotLe))
			NaOsSoten.Add(dwgText.CreateText(New Point3d(tWstSot.X, tWstSot.Y + 1, 0), elcol.strInf, 2))
			ColWsp.Add(MakeEntities.CreateLine(tWstSot.X, Podpis.PolGrafAbr - 2.0 * Shir, tWstSot.X, Podpis.PolGrafAbr + 2.0 * Shir))
		Next
	End Sub
	Private Sub WiwestiPiket(ByVal tPrf As Point3d, ByVal iPiket As ClsPiket)
		Dim strPik As String
		Dim PolPoX = tPrf.X
		Dim tprfPikT As New Point3d(PolPoX + 1, Podpis.OsPiket + 2, 0)
		'Dim ost As Double
		'ost = iPiket.Piketaj() Mod 100
		'strPik = Format(Math.Round(ost), "00")
		Dim lstr = ClsPiket.PiketnaSotIost(iPiket.Piketaj, _StrFormatOstSotet)
		strPik = lstr(1)
		If strPik <> _StrFormatOstSotet Then NaOsPiket.Add(BazDwg.dwgText.CreateTextV(tprfPikT, strPik, 2)) '

		NaOsPiket.Add(MakeEntities.CreateLine(PolPoX, Podpis.OsPiket, PolPoX, Podpis.OsPiket + Shir))
		NaOsPiket.Add(MakeEntities.CreateLine(PolPoX, Podpis.OsOtmetok, PolPoX, Podpis.OsOtmetok - Shir))
		ColWsp.Add(MakeEntities.CreateLine(PolPoX, Podpis.PolGrafAbr - Shir, PolPoX, Podpis.PolGrafAbr + Shir))
	End Sub
	Private Sub WiwestiOtm(ByVal tPrf As Point3d, ByVal Piket As clsPrf.ClsPiket)

		With Piket
			Dim tOtm As New Point3d(tPrf.X, Podpis.OsOtmetok, 0)
			NaOsOtm.Add(dwgText.CreateTextV(tOtm, Format(.Otmetka, _StrformatVert), 2))
			If .EstOtmetkaLw Then
				Dim tOtmLw As New Point3d(tPrf.X, Podpis.OsOtmetokLw, 0)
				NaOsOtmLw.Add(dwgText.CreateTextV(tOtmLw, Format(.OtmetkaLw, _StrformatVert), 2))
			End If
			If .EstOtmetkaPr Then
				Dim tOtmPr As New Point3d(tPrf.X, Podpis.OsOtmetokPr, 0)
				NaOsotmPr.Add(dwgText.CreateTextV(tOtmPr, Format(.OtmetkaPr, _StrformatVert), 2))
			End If

		End With
	End Sub
	Private Sub WiwestiPikUgod()
		Dim coll = PikUgods() 'выборка всех пикетажей угодий

		' Application.ShowAlertDialog(coll.Count)
		Dim lPrNeWiw As Boolean = True
		For Each pikUg As clsPrf.clsPikUgod In coll
			If lPrNeWiw Then 'первый пикетаж угодий должен сопадать с началом поэтому не выводим
				lPrNeWiw = False
				Continue For
			End If
			Dim ost As Double = pikUg.keyPiketaj Mod 100

			Dim strPik As String = Format(Math.Round(ost), StrFormatOstSotet)

			Dim rastDwg As Double = KoorP.GetDwg(pikUg.RastOtnachalaKey)
			NaOsPiketUgod.Add(dwgText.CreateTextV(New Point3d(rastDwg - 1, Podpis.OsUgodij + 1, 0), strPik, 2))
			NaOsPiketUgod.Add(MakeEntities.CreateLine(rastDwg, Podpis.OsUgodij, rastDwg, Podpis.OsAbris))

		Next
	End Sub
	Private Sub WiwestiPikUgod(iPikBeg As clsPrf.ClsPiket, iPikEnd As clsPrf.ClsPiket)
		Dim coll = PikUgods() 'выборка всех пикетажей угодий

		' Application.ShowAlertDialog(coll.Count)

		For Each pikUg As clsPrf.clsPikUgod In coll
			Dim lrast = pikUg.RastOtnachalaKey
			If lrast < iPikBeg.RastOtnachala Then Continue For ' iPikBeg.MensheR(lrast) = 1 
			If lrast > iPikEnd.RastOtnachala Then Exit For


			Dim ost As Double = pikUg.keyPiketaj Mod 100

			Dim strPik As String = Format(Math.Round(ost), "00")

			Dim rastDwg As Double = KoorP.GetDwg(pikUg.RastOtnachalaKey)
			NaOsPiketUgod.Add(dwgText.CreateTextV(New Point3d(rastDwg - 1, Podpis.OsUgodij + 1, 0), strPik, 2))
			NaOsPiketUgod.Add(MakeEntities.CreateLine(rastDwg, Podpis.OsUgodij, rastDwg, Podpis.OsAbris))

		Next
	End Sub
	Private Sub wiwestiGrUchastkow()
		Dim dwgYmax = objGeom.DwgYpoOtm(MaxOtmetka)
		For i As Integer = 0 To MaxNumUchTr
			Dim xdwg = objGeom.DwgXpoRast(RasstGrUch(i))
			ColWsp.Add(MakeEntities.CreateLine(xdwg, Podpis.OsX, xdwg, dwgYmax))
		Next
	End Sub
	Sub PodgotodkaWiwodaObraz()
		BazDwg.netSelectSet.OchistitSloj(DwgParam.SlProfilPiketaj)
		BazDwg.netSelectSet.OchistitSloj(DwgParam.SlProfil)
		BazDwg.netSelectSet.OchistitSloj(DwgParam.SlProfilLw)
		BazDwg.netSelectSet.OchistitSloj(DwgParam.SlProfilPr)
		BazDwg.netSelectSet.OchistitSloj(DwgParam.SlProfilPodpis)
		BazDwg.netSelectSet.OchistitSloj(DwgParam.SlPofilOsoben)
		BazDwg.netSelectSet.OchistitSloj(DwgParam.SlPofilUglPoworot)
		BazDwg.netSelectSet.OchistitSloj(DwgParam.SlProfilWspomogP)
		BazDwg.netSelectSet.OchistitSloj(DwgParam.SlProfilKlimat)
		BazDwg.netSelectSet.OchistitSloj(DwgParam.SlProfilPiketUgod)

		Kommand.createNewLayer(DwgParam.SlProfilPiketaj)
		Kommand.createNewLayer(DwgParam.SlProfilLw)
		Kommand.createNewLayer(DwgParam.SlProfilPr)
		Kommand.createNewLayer(DwgParam.SlProfil)
		Kommand.createNewLayer(DwgParam.SlProfilPodpis)
		Kommand.createNewLayer(DwgParam.SlPofilUglPoworot, 1)
		Kommand.createNewLayer(DwgParam.SlPofilOsoben)
		Kommand.createNewLayerNePrint(DwgParam.SlProfilWspomogP)
		Kommand.createNewLayer(DwgParam.SlProfilKlimat, 3)
		Kommand.createNewLayer(DwgParam.SlProfilPiketUgod)
		Kommand.SetObjectLinetype(NameTipLinLwPr)
		Kommand.SetObjectLinetype(NameTipLinPrPr)
		Kommand.SetObjectLinetype(dwgPeresech.NameTipLinUWW)
		dwgPeresech.ProvBlock()
		dwgUgolPow.Mesto = Podpis.OsUglowPoworota
		dwgPeresech.Mesto = Podpis.OsX
		wLinijProfilDwg = Nothing
	End Sub

	''' <summary>
	''' Выводит образ профиля в модель
	''' </summary>
	''' <remarks></remarks>
	Public Sub ObrazPrfw()
		Dim col2p, ColLw, ColPr As New Point2dCollection 'коллекции точек основного . правого , левого профиля
		PodgotodkaWiwodaObraz()
		ustBeg()
		Dim UgPred As dwgUgolPow = Nothing
		Do
			With Piket
				Dim tprf As New Point3d(KoorP.GetDwg(RastOtNachala), KoorOtm.GetDwg(.Otmetka), 0)

				col2p.Add(New Point2d(tprf.X, tprf.Y))
				If Piket.EstOtmetkaLw Then
					ColLw.Add(New Point2d(tprf.X, KoorOtm.GetDwg(.OtmetkaLw)))
				Else
					ColLw.Add(New Point2d(tprf.X, tprf.Y))
				End If
				If Piket.EstOtmetkaPr Then
					ColPr.Add(New Point2d(tprf.X, KoorOtm.GetDwg(.OtmetkaPr)))
				Else
					ColPr.Add(New Point2d(tprf.X, tprf.Y))
				End If


				If .EstUgolPoworota Then
					Dim ugDwg As New dwgUgolPow(Piket.GetUgolPoworota)
					ugDwg.WiwestiNaDwg(tprf.X, NaOsUglPoworot)
					If Not UgPred Is Nothing Then
						ugDwg.WiwestiMejNaDwg(UgPred, NaOsUglPoworot)
					Else
						ugDwg.WiwestiOtTchk(0, KoorP.GetDwg(0), NaOsUglPoworot)
					End If
					UgPred = ugDwg
				End If

				If .EstPeresech Then
					Dim objPeresech As New dwgPeresech(Piket, Piket.Peresech)
					objPeresech.Wiwesti(tprf, ColPeresech, .Piketaj)
				End If
				' для пикетов с именем начинающимся на  # не выводим подписи
				If Not Piket.NamePiket Like "[#]*" Then   'Not String.IsNullOrEmpty(Piket.NamePiket)
					WiwestiPiket(tprf, Piket)
					WiwestiOtm(tprf, Piket)
				End If

				Sled()

			End With
		Loop Until Piket Is Nothing

		If UgPred IsNot Nothing Then
			UgPred.WiwestiOtTchk(Dlina, KoorP.GetDwg(Dlina), NaOsUglPoworot)
		End If


		WiwestiSotni()
		WiwestiPikUgod()
		Dim Klm As New dwgWiwKlimat(Me)
		' Klm.Wiw(30, 0.5 * Me.Dlina)
		Klm.Wiw()
		Kommand.changeSloj(Klm.ObrazWiwod, DwgParam.SlProfilKlimat)
		Podpis.Osi(KoorP.GetDwg(Dlina), Podpis.OsX)
		Podpis.WiwestiWsp(KoorP.GetDwg(Dlina), ColWsp)
		Podpis.wiwestiPodpis(KoorP.GetDwg(Dlina), Me)
		wiwestiGrUchastkow()

		ZawershitWiwod(col2p, ColPr, ColLw)
		'   Zoom(New Point3d(), New Point3d(), New Point3d(), 1.01075)

	End Sub

	''' <summary>
	''' Выводит участок трасы профиля
	''' </summary>
	''' <param name="iPikBeg">  начальный пикет участка </param>
	''' <param name="iPikEnd"> конечный пикет участка</param>
	''' <remarks></remarks>
	Public Sub ObrazPrfw(iPikBeg As clsPrf.ClsPiket, iPikEnd As clsPrf.ClsPiket)
		Dim col2p, ColLw, ColPr As New Point2dCollection 'коллекции точек основного . правого , левого профиля
		PodgotodkaWiwodaObraz()
		ustBeg(iPikBeg)
		Dim UgPred As dwgUgolPow = Nothing
		Do
			With Piket
				Dim tprf As New Point3d(KoorP.GetDwg(RastOtNachala), KoorOtm.GetDwg(.Otmetka), 0)

				col2p.Add(New Point2d(tprf.X, tprf.Y))
				If Piket.EstOtmetkaLw Then
					ColLw.Add(New Point2d(tprf.X, KoorOtm.GetDwg(.OtmetkaLw)))
				Else
					ColLw.Add(New Point2d(tprf.X, tprf.Y))
				End If
				If Piket.EstOtmetkaPr Then
					ColPr.Add(New Point2d(tprf.X, KoorOtm.GetDwg(.OtmetkaPr)))
				Else
					ColPr.Add(New Point2d(tprf.X, tprf.Y))
				End If


				If .EstUgolPoworota Then
					Dim ugDwg As New dwgUgolPow(Piket.GetUgolPoworota)
					ugDwg.WiwestiNaDwg(tprf.X, NaOsUglPoworot)
					If Not UgPred Is Nothing Then
						ugDwg.WiwestiMejNaDwg(UgPred, NaOsUglPoworot)
					Else
						ugDwg.WiwestiOtTchk(0, KoorP.GetDwg(iPikBeg.RastOtnachala), NaOsUglPoworot)
					End If
					UgPred = ugDwg
				End If

				If .EstPeresech Then
					Dim objPeresech As New dwgPeresech(Piket, Piket.Peresech)
					objPeresech.Wiwesti(tprf, ColPeresech, .Piketaj)
				End If
				' для пикетов с именем начинающимся на  # не выводим подписи
				If Not Piket.NamePiket Like "[#]*" Then   'Not String.IsNullOrEmpty(Piket.NamePiket)
					WiwestiPiket(tprf, Piket)
					WiwestiOtm(tprf, Piket)
				End If

				Sled()
				If Piket Is Nothing Then Exit Do
			End With
		Loop Until Piket.RastOtnachala > iPikEnd.RastOtnachala

		If UgPred IsNot Nothing Then
			UgPred.WiwestiOtTchk(iPikEnd.RastOtnachala, KoorP.GetDwg(iPikEnd.RastOtnachala), NaOsUglPoworot)
		End If


		WiwestiSotni(iPikBeg, iPikEnd)
		WiwestiPikUgod(iPikBeg, iPikEnd)
		Dim Klm As New dwgWiwKlimat(Me)
		' Klm.Wiw(30, 0.5 * Me.Dlina)
		Klm.Wiw(iPikBeg.RastOtnachala, iPikEnd.RastOtnachala)
		Kommand.changeSloj(Klm.ObrazWiwod, DwgParam.SlProfilKlimat)
		Podpis.Osi(KoorP.GetDwg(iPikEnd.RastOtnachala), Podpis.OsX)
		Podpis.WiwestiWsp(KoorP.GetDwg(iPikEnd.RastOtnachala), ColWsp)
		Podpis.wiwestiPodpis(KoorP.GetDwg(iPikEnd.RastOtnachala), Me)
		'   wiwestiGrUchastkow()

		ZawershitWiwod(col2p, ColPr, ColLw)
		'   Zoom(New Point3d(), New Point3d(), New Point3d(), 1.01075)

	End Sub
	''' <summary>
	''' Выводит образ профиля в зависимости от представления деталь или весь профиль
	''' </summary>
	''' <remarks></remarks>
	Public Sub ObrazPrf()
		If Me.objGeom.obrParam.TipGraniz = ParamTrass.TipDetal Then
			Dim lPikBeg As clsPrf.ClsPiket = Me.Piket(Me.objGeom.obrParam.BegUch)
			Dim lpikEnd As clsPrf.ClsPiket = Me.Piket(Me.objGeom.obrParam.EndUch)
			If lPikBeg Is Nothing OrElse lpikEnd Is Nothing Then
				Application.ShowAlertDialog(Me.ToString & " Не найдены границы детали")
				Return
			End If
			ObrazPrfw(lPikBeg, lpikEnd)
		Else
			ObrazPrfw()

		End If
	End Sub

	Sub ZawershitWiwod(col2p As Point2dCollection, colPr As Point2dCollection, colLw As Point2dCollection)
		Kommand.changeSloj(MakeEntities.CreateMasLineY(col2p, Podpis.OsX), DwgParam.SlProfil)

		GrebenPr = MakeEntities.CreateLwPolyline(colPr)
		Kommand.changeSloj(GrebenPr, DwgParam.SlProfilPr)
		Kommand.changeTipLin(GrebenPr, NameTipLinPrPr)
		Kommand.changeColor(GrebenPr, ColorPrawogo) 'перекрасили правый

		GrebenLw = MakeEntities.CreateLwPolyline(colLw)
		Kommand.changeSloj(GrebenLw, DwgParam.SlProfilLw)
		Kommand.changeTipLin(GrebenLw, NameTipLinLwPr)
		Kommand.changeColor(GrebenLw, ColorLewogo) 'перекрасили левый

		Greben = MakeEntities.CreateLwPolyline(col2p)
		Kommand.changeSloj(Greben, DwgParam.SlProfil)


		Kommand.changeSloj(NaOsPiket, DwgParam.SlProfilPiketaj)
		Kommand.changeSloj(NaOsSoten, DwgParam.SlProfilPiketaj)
		Kommand.changeSloj(Podpis.CollPrim, DwgParam.SlProfilPodpis)
		Kommand.changeSloj(NaOsOtmLw, DwgParam.SlProfilPiketaj)
		Kommand.changeSloj(NaOsotmPr, DwgParam.SlProfilPiketaj)
		Kommand.changeSloj(NaOsOtm, DwgParam.SlProfilPiketaj)
		Kommand.changeSloj(NaOsPiketUgod, DwgParam.SlProfilPiketUgod)
		Kommand.changeSloj(NaOsUglPoworot, DwgParam.SlPofilUglPoworot)
		Kommand.changeSloj(ColPeresech, DwgParam.SlPofilOsoben)
		Kommand.changeSloj(ColWsp, DwgParam.SlProfilWspomogP)

	End Sub
	Sub WiwTolkoKlim()
		BazDwg.netSelectSet.OchistitSloj(DwgParam.SlProfilKlimat)
		Kommand.createNewLayer(DwgParam.SlProfilKlimat, 3)
		Dim Klm As New dwgWiwKlimat(Me)
		Klm.Wiw()
		Kommand.changeSloj(Klm.ObrazWiwod, DwgParam.SlProfilKlimat)
	End Sub
#End Region
#Region "Гео"
	Const SlGeo As String = "v11SlGeoProfil"
	Const SlGeoPiketaj As String = "v11SlGeoPiketaj"
	Public Sub ObrazPrfGeo()

		Dim col2p, Collw, ColPr As New Point2dCollection 'коллекции точек основного . правого , левого профиля

		BazDwg.netSelectSet.OchistitSloj(SlGeo)
		BazDwg.netSelectSet.OchistitSloj(SlGeoPiketaj)

		Kommand.createNewLayer(SlGeo)
		Kommand.createNewLayer(SlGeoPiketaj)
		ustBeg()  'установили начало


		Do
			With Piket

				Dim tprf As New Point3d(KoorP.GetDwg(RastOtNachala), KoorOtm.GetDwg(.Otmetka), 0) ' точка на чертеже соответствующая пикетной точке
				' определяем координаты в черетеже соответствующие левому и правому профилю
				col2p.Add(New Point2d(tprf.X, tprf.Y))
				If Piket.EstOtmetkaLw Then
					Collw.Add(New Point2d(tprf.X, KoorOtm.GetDwg(.OtmetkaLw)))
				Else
					Collw.Add(New Point2d(tprf.X, tprf.Y))
				End If
				If Piket.EstOtmetkaPr Then
					ColPr.Add(New Point2d(tprf.X, KoorOtm.GetDwg(.OtmetkaPr)))
				Else
					ColPr.Add(New Point2d(tprf.X, tprf.Y))
				End If






				Sled()

			End With
		Loop Until Piket Is Nothing






		Kommand.changeSloj(MakeEntities.CreateMasLineY(col2p, Podpis.OsX), SlGeoPiketaj)


		GrebenPr = MakeEntities.CreateLwPolyline(ColPr)
		Kommand.changeSloj(GrebenPr, SlGeo)
		Kommand.changeTipLin(GrebenPr, NameTipLinPrPr)
		Kommand.changeColor(GrebenPr, ColorPrawogo) 'перекрасили правый

		GrebenLw = MakeEntities.CreateLwPolyline(Collw)
		Kommand.changeSloj(GrebenLw, SlGeo)
		Kommand.changeTipLin(GrebenLw, NameTipLinLwPr)
		Kommand.changeColor(GrebenLw, ColorLewogo) 'перекрасили левый

		Greben = MakeEntities.CreateLwPolyline(col2p)
		Kommand.changeSloj(Greben, SlGeo)












	End Sub


#End Region


	''' <summary>
	''' Записывает имя чертежа в образ трассы. При переименовании чертежа
	''' </summary>
	''' <remarks></remarks>
	Sub SootNameDwg()
		Dim oldname As String = wNameDwg
		wNameDwg = Application.DocumentManager.MdiActiveDocument.Name

	End Sub
	Public Sub New(ByVal iNameLin As String, ByVal iNamerab As String, ByVal iUnom As Integer)
		MyBase.New(iNameLin, iNamerab, iUnom)
		objGeom = New dwgGeometr
		wNameDwg = Application.DocumentManager.MdiActiveDocument.Name
		If objGeom.obrParam.PosleZpt > 0 Then
			_StrformatVert = "f2"
			If objGeom.obrParam.PosleZpt > 1 Then
				_StrFormatHor = "f2"
				_StrFormatOstSotet = "00.00"
			Else
				_StrFormatHor = "f1"
				_StrFormatOstSotet = "00.0"
			End If
		End If


	End Sub

	Protected Overrides Sub Finalize()
		'Sobitie = Nothing
		'gSobDoc = Nothing
	End Sub
End Class
'Public Class dwgTrList
'    Inherits DwgTr
'    Private EkranZag, EkranPodpis, EkranDann As dwgWidEkran
'    Private ColEkranProfil As New Collection
'    Private ShirProf As Double = 300
'    Private ShirRabObl As Double = 500

'    Private Sub EkraniPost(ByVal EkranXb As Double, ByVal EkranXe As Double)
'        Dim TnizZag, TWerhZag, TnizPodP, TwerhPodpis As Point2d 'левый нижний и правый верхние точки области модели выводимой в лист
'        Dim NizZag, nizPodp As Point3d ', нижние левые точки области листа в которые отображаеться участок профиля

'        TnizZag = New Point2d(0, 0) ' заголовок подвала
'        TWerhZag = New Point2d(clsPodpis.OsY, OsX)
'        NizZag = New Point3d(0, 0, 0)
'        TnizPodP = New Point2d(EkranXb, 0)
'        TwerhPodpis = New Point2d(EkranXe, Podpis.GranizaNadpisi)
'        nizPodp = New Point3d(clsPodpis.OsY, 0, 0)
'        EkranZag = New dwgWidEkran(TnizZag, TWerhZag, NizZag)
'        EkranPodpis = New dwgWidEkran(TnizPodP, TwerhPodpis, nizPodp)
'    End Sub
'    Private Sub EkranWiwDann(ByVal EkranXb As Double, ByVal EkranXe As Double, ByVal EkranY As Double)
'        Dim TnizDan, TwerhDann As Point2d 'левый нижний и правый верхние точки области модели выводимой в лист
'        Dim Nizdan As Point3d ', нижние левые точки области листа в которые отображаеться участок modeli
'        TnizDan = New Point2d(EkranXb, EkranY + dwgWiwKlimat.NadProfilem)
'        TwerhDann = New Point2d(EkranXe, TnizDan.Y + dwgWiwKlimat.ShirZonWiw)
'        Nizdan = New Point3d(clsPodpis.OsY, Podpis.GranizaNadpisi + ShirRabObl, 0)
'        EkranDann = New dwgWidEkran(TnizDan, TwerhDann, Nizdan)
'    End Sub
'    Private Function Ekrani(ByVal EkranX1 As Double, ByVal EkranX2 As Double, ByVal EkranY As Double, ByVal BegX_Na_liste As Double) As dwgWidEkran

'        Dim TnizOblPrf, TwerhOblPrf As Point2d
'        Dim NizoblPrf As Point3d
'        Dim EkranProfil As dwgWidEkran



'        TnizOblPrf = New Point2d(EkranX1, EkranY)
'        TwerhOblPrf = New Point2d(EkranX2, EkranY + ShirRabObl)
'        NizoblPrf = New Point3d(BegX_Na_liste, Podpis.GranizaNadpisi, 0)


'        EkranProfil = New dwgWidEkran(TnizOblPrf, TwerhOblPrf, NizoblPrf)
'        Return EkranProfil

'    End Function
'    Private Function WiwestiEkran() As ObjectIdCollection
'        Dim colekr As New ObjectIdCollection
'        Dim EkranProfil As dwgWidEkran
'        colekr.Add(EkranZag.WiwestiNaList)
'        colekr.Add(EkranPodpis.WiwestiNaList)
'        colekr.Add(EkranDann.WiwestiNaList)
'        For Each EkranProfil In ColEkranProfil
'            colekr.Add(EkranProfil.WiwestiNaList)
'        Next
'        Return colekr
'    End Function
'    Private Sub WiwestiEkran(ByVal NameBlkLst As String)


'        'Dim colekr As New Collection
'        'colekr.Add(EkranZag.WiwestiNaList(NameBlkLst))
'        'colekr.Add(EkranPodpis.WiwestiNaList(NameBlkLst))
'        'colekr.Add(EkranProfil.WiwestiNaList(NameBlkLst))

'    End Sub

'    Public Sub ObrazProfilWlist(ByVal Rast As Collection)
'        Dim GrDwg(), OtmMaxDwg() As Double
'        OchistSlojList(GlobParam.SlWspomogP)
'        'размещение на листах
'        Dim KolwEkrProfil = Rast.Count - 1
'        If KolwEkrProfil = 0 Then
'            KolwEkrProfil = 1
'            Rast.Add(0, , 1)
'        End If
'        'Вывод экранов участков трассы 
'        ReDim GrDwg(KolwEkrProfil)
'        ReDim OtmMaxDwg(KolwEkrProfil)
'        Dim tekRast, tekpred As Double
'        Dim I As Integer = 0
'        Dim BegNaListe = clsPodpis.OsY
'        For Each tekRast In Rast
'            GrDwg(I) = DwgXpoRast(tekRast)
'            If I > 0 Then
'                Dim MinO, maxO As Double
'                Dim EkranMin As Double
'                ExtrOtmNaIntervale(tekpred, tekRast, MinO, maxO)
'                OtmMaxDwg(I) = DwgYpoOtm(maxO) - ShirProf
'                EkranMin = DwgYpoOtm(MinO)
'                If EkranMin < OtmMaxDwg(I) Then
'                    Application.ShowAlertDialog("Профиль не помещаеться на экран в листе " & tekpred & "  " & tekRast _
'                                                & " " & EkranMin & " " & OtmMaxDwg(I) & " для " & I)
'                End If
'                ColEkranProfil.Add(Ekrani(GrDwg(I - 1), GrDwg(I), OtmMaxDwg(I), BegNaListe))
'                BegNaListe += (GrDwg(I) - GrDwg(I - 1))
'            End If
'            tekpred = tekRast
'            I += 1
'        Next

'        EkraniPost(GrDwg(0), GrDwg(KolwEkrProfil))
'        EkranWiwDann(GrDwg(0), GrDwg(KolwEkrProfil), DwgYpoOtm(MaxOtmetka))

'        Dim ColVports As ObjectIdCollection
'        ColVports = WiwestiEkran()
'        OpPrim.changeSloj(ColVports, GlobParam.SlWspomogP)

'    End Sub
'End Class
