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
'Public Class dwgTrList
'    Inherits DwgTr


'    Public Sub New(ByVal iNameLin As String, ByVal inameRab As String, ByVal iUnom As Integer)
'        MyBase.New(iNameLin, inameRab, iUnom)
'    End Sub
'End Class
Public Class dwgTrListName
	Private wTrassaDwg As DwgTr
	Private EkranZag, EkranPodpis, EkranDann As dwgWidEkran
	Private ColEkranProfil As New Collection
	Private Const OtstupOtBegIEndLista As Double = 20

	Private NameList As String
	ReadOnly Property BeginProfilList() As Double
		Get
			Return clsPodpis.OsY + OtstupOtBegIEndLista
		End Get
	End Property
	Private Sub EkraniPost(ByVal EkranXb As Double, ByVal EkranXe As Double)
		Dim TnizZag, TWerhZag, TnizPodP, TwerhPodpis As Point2d 'левый нижний и правый верхние точки области модели выводимой в лист
		Dim NizZag, nizPodp As Point3d ', нижние левые точки области листа в которые отображаеться участок профиля
		Dim lSdwigGranizOtLinii As Double = 0.00 'Необходимо чтобы линия ограничивающея заголовок подписи была видна при печати
		TnizZag = New Point2d(0, 0) ' заголовок подвала
		TWerhZag = New Point2d(clsPodpis.OsY + lSdwigGranizOtLinii, wTrassaDwg.OsX + 35) ' 35 добавили чтобы на экраны полпала область вывода масштаба и размера листа
		NizZag = New Point3d(0, 0, 0)
		TnizPodP = New Point2d(EkranXb - OtstupOtBegIEndLista, 0)
		TwerhPodpis = New Point2d(EkranXe + OtstupOtBegIEndLista, wTrassaDwg.OsX + clsPodpis.ShirinaNadpisi)
		nizPodp = New Point3d(BeginProfilList - OtstupOtBegIEndLista + lSdwigGranizOtLinii, 0, 0)   'clsPodpis.OsY
		EkranZag = New dwgWidEkran(TnizZag, TWerhZag, NizZag)
		EkranPodpis = New dwgWidEkran(TnizPodP, TwerhPodpis, nizPodp)
	End Sub
	Private Sub EkranWiwDann(ByVal EkranXb As Double, ByVal EkranXe As Double, ByVal EkranY As Double)
		Dim TnizDan, TwerhDann As Point2d 'левый нижний и правый верхние точки области модели выводимой в лист
		Dim Nizdan As Point3d ', нижние левые точки области листа в которые отображаеться участок modeli
		TnizDan = New Point2d(EkranXb - OtstupOtBegIEndLista, wTrassaDwg.OsKlRasst)
		TwerhDann = New Point2d(EkranXe + OtstupOtBegIEndLista, TnizDan.Y + clsPodpis.ShirWiwKlRasst)
		Nizdan = New Point3d(BeginProfilList - OtstupOtBegIEndLista, wTrassaDwg.OsX + clsPodpis.ShirinaNadpisi + wTrassaDwg.objGeom.Podpis.ShirRabObl, 0) 'clsPodpis.OsY
		EkranDann = New dwgWidEkran(TnizDan, TwerhDann, Nizdan)
	End Sub
	Private Function Ekrani(ByVal EkranX1 As Double, ByVal EkranX2 As Double, ByVal EkranY As Double, ByVal BegX_Na_liste As Double) As dwgWidEkran

		Dim TnizOblPrf, TwerhOblPrf As Point2d
		Dim NizoblPrf As Point3d
		Dim EkranProfil As dwgWidEkran



		TnizOblPrf = New Point2d(EkranX1, EkranY)
		TwerhOblPrf = New Point2d(EkranX2, EkranY + wTrassaDwg.objGeom.Podpis.ShirRabObl)
		NizoblPrf = New Point3d(BegX_Na_liste, wTrassaDwg.OsX + clsPodpis.ShirinaNadpisi, 0)


		EkranProfil = New dwgWidEkran(TnizOblPrf, TwerhOblPrf, NizoblPrf)
		Return EkranProfil

	End Function
	Private Function WiwestiEkran() As ObjectIdCollection
		Dim colekr As New ObjectIdCollection
		Dim EkranProfil As dwgWidEkran
		If NameList <> "" Then
			clsList.ListTek(NameList)
		End If

		'   OchistSlojList(DwgParam.SlProfilWidEkran)
		colekr.Add(EkranZag.WiwestiNaList())
		colekr.Add(EkranPodpis.WiwestiNaList())
		colekr.Add(EkranDann.WiwestiNaList())

		For Each EkranProfil In ColEkranProfil
			colekr.Add(EkranProfil.WiwestiNaList())

		Next
		Return colekr
	End Function
	Public Sub ObrazProfilWlist(ByVal Rast As Collection)
		Dim GrDwg(), OtmMaxDwg() As Double

		'размещение на листах
		Dim KolwEkrProfil = Rast.Count - 1
		If KolwEkrProfil < 0 Then
			KolwEkrProfil = 0
			Rast.Add(wTrassaDwg.Dlina)
		End If
		If KolwEkrProfil = 0 Then
			KolwEkrProfil = 1
			Rast.Add(0, , 1)
		End If
		'Вывод экранов участков трассы 
		ReDim GrDwg(KolwEkrProfil)
		ReDim OtmMaxDwg(KolwEkrProfil)
		Dim tekRast, tekpred As Double
		Dim I As Integer = 0
		Dim BegNaListe = BeginProfilList
		For Each tekRast In Rast
			GrDwg(I) = wTrassaDwg.DwgXpoRast(tekRast)
			If I > 0 Then
				Dim MinO, maxO, MinR, MaxR As Double
				Dim EkranMin, EkranMax As Double
				Dim lsoobMenNadpisi As String = ""
				Dim lSoob As String = ""
				wTrassaDwg.ExtrNaIntervale(tekpred, tekRast, MinO, maxO, MinR, MaxR)
				OtmMaxDwg(I) = wTrassaDwg.DwgYpoOtm(maxO) - wTrassaDwg.objGeom.Podpis.ShirProf
				If OtmMaxDwg(I) < wTrassaDwg.objGeom.Podpis.GranizaNadpisi Then
					OtmMaxDwg(I) = wTrassaDwg.objGeom.Podpis.GranizaNadpisi
				End If
				EkranMax = wTrassaDwg.DwgYpoOtm(maxO)
				EkranMin = wTrassaDwg.DwgYpoOtm(MinO)
				'проверки заполнения видовых экранов
				If EkranMin < wTrassaDwg.objGeom.Podpis.GranizaNadpisi Then


					lsoobMenNadpisi &= "Минимальная отметка чертежа " & EkranMin & " в видовом экране меньше отметки надписи " & wTrassaDwg.objGeom.Podpis.GranizaNadpisi & vbCr
				End If

				If EkranMax - EkranMin > wTrassaDwg.objGeom.Podpis.ShirProf Then
					lSoob &= "Профиль в видовом экране выходит за границы допустимой области " & vbCr _
										 & " Мин отм в чертеже" & EkranMin & " Мак отметка  в чертеже" & EkranMax & vbCr _
												& "Мин. отметка " & MinO & " на расстояние " & MinR & " Макс. отметка" & maxO & " на расстояние " & MaxR & vbCr _
												& " Допустимая разность " & wTrassaDwg.objGeom.Podpis.ShirProf / wTrassaDwg.objGeom.KoorOtm.Koeff()
				End If

				If Not (String.IsNullOrEmpty(lSoob) And String.IsNullOrEmpty(lsoobMenNadpisi)) Then
					Application.ShowAlertDialog("  Лист " & NameList & vbCr _
												& "границы видового экрана " & I & " " & tekpred & "  " & tekRast & vbCr & lsoobMenNadpisi & vbCr & lSoob)

				End If
				Dim wGre, wGrb, wBeg As Double 'вспомогательные переменные обеспечивающие увеличение экранов в начале и конце листа для лучшего охвата
				wGrb = GrDwg(I - 1)
				wGre = GrDwg(I)
				wBeg = BegNaListe
				If I = 1 Then


					wGrb = wGrb - OtstupOtBegIEndLista
					wBeg = wBeg - OtstupOtBegIEndLista

				End If
				If I = Rast.Count - 1 Then
					wGre = wGre + OtstupOtBegIEndLista
				End If
				ColEkranProfil.Add(Ekrani(wGrb, wGre, OtmMaxDwg(I), wBeg))
				BegNaListe += (GrDwg(I) - GrDwg(I - 1))
			End If
			tekpred = tekRast
			I += 1
		Next

		EkraniPost(GrDwg(0), GrDwg(KolwEkrProfil))
		EkranWiwDann(GrDwg(0), GrDwg(KolwEkrProfil), wTrassaDwg.DwgYpoOtm(wTrassaDwg.MaxOtmetka))

		Dim ColVports As ObjectIdCollection
		ColVports = WiwestiEkran()
		Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage("ObrazProfilWlist- " & "Экранов " & NameList & " " & ColVports.Count & vbCrLf)
		Kommand.changeSloj(ColVports, DwgParam.SlProfilWidEkran)
		SystemKommand.Zoom(New Point3d(), New Point3d(), New Point3d(), 1.01075)
	End Sub
	ReadOnly Property ZentrDannList() As Point3d
		Get
			Return EkranDann.ZentrWListe
		End Get
	End Property
	ReadOnly Property ZentrPodpisiList() As Point3d
		Get
			Return EkranPodpis.ZentrWListe
		End Get
	End Property
	Public Sub New(ByVal iTrassa As DwgTr, ByVal nameLayout As String)
		wTrassaDwg = iTrassa
		NameList = nameLayout

	End Sub
End Class

