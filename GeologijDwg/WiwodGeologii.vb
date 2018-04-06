

#If ARX_APP Then
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.Geometry

#Else
Imports Teigha.DatabaseServices
Imports Teigha.Geometry
#End If
Imports BazDwg

Public Class WiwodGeologii
	Private wtrassaDwg As ProfilBaseDwg.DwgTr
	Private wLinijProfilDwg As BazDwg.GrebenProfilDwg
	Private wGeologijReal As modelGeo.GeologijReal
	Private wSpSkwajn As New List(Of SkwajnaRealDwg)
	Private wparamImagegeo As ParamImageGeo
	Shared Sub OchistWseLayerGeo(ixB As Double, ixe As Double)
		BazDwg.netSelectSet.OchistitSloj(SkwajnaRealDwg.NameSlojDwgIGE, ixB, ixe)      ' проверка требуемых слоев
		BazDwg.netSelectSet.OchistitSloj(SkwajnaRealDwg.NameSlojDwGIndexIGE, ixB, ixe)
		BazDwg.netSelectSet.OchistitSloj(SkwajnaRealDwg.NameSlojDwgSkwaj, ixB, ixe)
		BazDwg.netSelectSet.OchistitSloj(SkwajnaRealDwg.NameSlojDwgUGW, ixB, ixe)
		BazDwg.netSelectSet.OchistitSloj(SkwajnaRealDwg.NameSlojDwgProb, ixB, ixe)
		BazDwg.netSelectSet.OchistitSloj(SkwajnaRealDwg.NameSlojDwgConsistenz, ixB, ixe)
		BazDwg.netSelectSet.OchistitSloj(SkwajnaRealDwg.NameSlojDwgGrunt, ixB, ixe)
		BazDwg.netSelectSet.OchistitSloj(SkwajnaRealDwg.NameSlojDwgStatZond, ixB, ixe)
		BazDwg.netSelectSet.OchistitSloj(DwgParam.LayerGeoWspomog, ixB, ixe)

	End Sub
	Sub New(iTrassa As ProfilBaseDwg.DwgTr, iModelGeo As modelGeo.GeologijReal, iparamGeo As ParamImageGeo)
		wtrassaDwg = iTrassa
		wGeologijReal = iModelGeo
		wLinijProfilDwg = wtrassaDwg.GetLinijDwg
		wparamImagegeo = iparamGeo
		'wSkwajBeg = New SkwajnaRealDwg(iTrassa, iModelGeo.GetSkwajPoIndex(IIndex), iparamGeo)
		'wSkwajEnd = New SkwajnaRealDwg(iTrassa, iModelGeo.GetSkwajPoIndex(IIndex + 1), iparamGeo)
		For Each el As modelGeo.SkwajnaReal In wGeologijReal.SpSkwaj
			If el.DataRowSkwaj.RowState = DataRowState.Deleted OrElse el.DataRowSkwaj.RowState = DataRowState.Detached Then Continue For
			wSpSkwajn.Add(New SkwajnaRealDwg(iTrassa, el, iparamGeo))
		Next

	End Sub
	Private Function EstliSkwajna(iRast As Double) As Boolean
		Dim ldop = LeseGeoIzDwg.ObrazGeologii.OkoloSkwajnDwg / wtrassaDwg.objGeom.KoorP.Koeff
		For Each el As SkwajnaRealDwg In wSpSkwajn
			If el.Rastojnie > iRast Then
				If el.Rastojnie - iRast < 2.0 * ldop Then Return True
			Else
				If iRast - el.Rastojnie < ldop Then Return True
			End If

		Next
		Return False
	End Function
	Sub WiwestiPochwSloj()
		Dim lsp = wLinijProfilDwg.GetWseLinij
		Dim collObjectid As New ObjectIdCollection
		Dim lbeg As Double = lsp.First.X
		Dim lend As Double = lsp.Last.X
		For pr As Double = lbeg To lend Step 15
			Dim lRast = wtrassaDwg.objGeom.KoorP.GetReal(pr)
			If EstliSkwajna(lRast) Then Continue For
			Dim lpoint = wLinijProfilDwg.GetPointLinii(pr)

			Dim lobjId As ObjectId = BazDwg.MakeEntities.CreateWstawkBlock(New Point3d(lpoint.X, lpoint.Y, 0), modelGeo.TipOpred.NameBlockPochwa)
			collObjectid.Add(lobjId)
		Next
		Kommand.changeSloj(collObjectid, SkwajnaRealDwg.NameSlojDwgIGE)
	End Sub
	Sub WiwestiUgw()
		Dim lPrUgwBeg As Boolean = False
		Dim LcollPoint2d As New Point2dCollection
		Dim lcollDbObject As New DBObjectCollection
		For Each el As SkwajnaRealDwg In wSpSkwajn
			Dim lp = el.GetPointGlubinUGW
			If el.Tip >= modelGeo.TipSkwajn.dlajKlin And lp.Equals(Point2d.Origin) Then Continue For
			If lPrUgwBeg Then    '1
				If el.Tip < modelGeo.TipSkwajn.dlajKlin Then     '2
					If lp.Equals(Point2d.Origin) Then    '3

						lcollDbObject.Add(BazDwg.dbPrim.CreateLwPolyline(LcollPoint2d))

						'   MsgBox(LcollPoint2d.Count)
						LcollPoint2d.Clear()
						lPrUgwBeg = False
					Else
						LcollPoint2d.Add(lp)
					End If                                            '3
				Else
					LcollPoint2d.Add(lp)
				End If                  '2
			Else
				If lp.Equals(Point2d.Origin) Then  '2
					Continue For
				Else
					lPrUgwBeg = True
					LcollPoint2d.Add(lp)
				End If      '2
			End If     '1
		Next
		If lPrUgwBeg Then lcollDbObject.Add(BazDwg.dbPrim.CreateLwPolyline(LcollPoint2d))
		BazDwg.dbPrim.changeSloj(lcollDbObject, SkwajnaRealDwg.NameSlojDwgUGW)
		BazDwg.dbPrim.Wkl(lcollDbObject)
	End Sub
	Sub WiwestiMetkiSkwajWdwg()
		BazDwg.netSelectSet.OchistitSloj(DwgParam.LayerGeoWspomog)
		For Each el As modelGeo.SkwajnaReal In wGeologijReal.SpSkwaj
			Dim eld = New SkwajnaRealDwg(wtrassaDwg, el, wparamImagegeo)
			eld.WiwestiMetkuSkwajWdwg()
		Next
	End Sub
	''' <summary>
	''' Выводит без учета внутрених контуров 
	''' </summary>
	''' <remarks></remarks>
	Sub WiwestiWDwg()
		Dim lsyskomand As New SystemKommand

		lsyskomand.Lock()

		'  ClsCommandGeo.OchistWseLayerGeo()
		Dim lfrmsoob As New modelGeo.FrmSoob With {
			.Text = "Отрисовка геологии"
		}
		Dim iPredPosl As Integer = wGeologijReal.KolwoSkwajn - 2
		lfrmsoob.LabelWseg.Text = CStr(iPredPosl)
		lfrmsoob.Show()
		For i As Integer = 0 To iPredPosl
			Dim lDljWii As New WiwParSkwaj(wtrassaDwg, wGeologijReal, i, wparamImagegeo)
			'     lDljWii.PerepisatParuSkwajn()
			'  lDljWii.Perepisat()
			lDljWii.Perepisat()
			If i = iPredPosl Then
				lDljWii.wiwestiend()
			End If

			lfrmsoob.Label1.Text = CStr(i)
			lfrmsoob.Refresh()
		Next
		lfrmsoob.Visible = False
		lfrmsoob = Nothing
		'    Dim lGeoWiw As New GeologijDwg.WiwodGeologii(wtrassaDwg, wGeologijReal, wparamImagegeo)
		Me.WiwestiUgw()
		lsyskomand.Dispose()
		'   SystemKommand.WklOtm()
		SystemKommand.Act()
	End Sub
	''' <summary>
	''' Выводит с обработкой внутрених контуров
	''' </summary>
	''' <remarks></remarks>
	Sub WiwestiWDwgA()
		Dim lsyskomand As New SystemKommand

		lsyskomand.Lock()

		'  ClsCommandGeo.OchistWseLayerGeo()
		Dim lfrmsoob As New modelGeo.FrmSoob With {
			.Text = "Отрисовка геологии"
		}
		Dim iPosl As Integer = wGeologijReal.KolwoSkwajn - 1
		lfrmsoob.LabelWseg.Text = CStr(iPosl)
		lfrmsoob.Show()
		Dim iB = 0
		Dim ls = wGeologijReal.SpSkwaj
		For i As Integer = 1 To iPosl
			If ls(i).PriznakOtrajGraniz Then
				Dim lDljWii As New WiwParSkwaj(wtrassaDwg, wGeologijReal, iB, i, wparamImagegeo)

				lDljWii.Perepisat()

				If i = iPosl Then
					lDljWii.wiwestiend()
				End If
				iB = i
			Else
				Dim ll = New SkwajnaRealDwg(wtrassaDwg, ls(i), wparamImagegeo)
				ll.WiwestiMetkuSkwajWdwg()
			End If




			lfrmsoob.Label1.Text = CStr(i)
			lfrmsoob.Refresh()
		Next
		lfrmsoob.Visible = False
		lfrmsoob = Nothing
		'    Dim lGeoWiw As New GeologijDwg.WiwodGeologii(wtrassaDwg, wGeologijReal, wparamImagegeo)
		Me.WiwestiUgw()
		lsyskomand.Dispose()
		'   SystemKommand.WklOtm()
		SystemKommand.Act()
	End Sub
	Private Function PredWiwodIndexSkwajn(iIndex As Integer) As Integer
		Dim lskwaj = wGeologijReal.GetSkwajPoIndex(iIndex)
		Do
			If lskwaj.PriznakOtrajGraniz Then Return iIndex
			iIndex -= 1
			lskwaj = wGeologijReal.GetSkwajPoIndex(iIndex)
		Loop

	End Function
	Private Function SledWiwodIndexSkwajn(iIndex As Integer) As Integer
		Dim lskwaj = wGeologijReal.GetSkwajPoIndex(iIndex)
		Do
			If lskwaj.PriznakOtrajGraniz Then Return iIndex
			iIndex += 1
			lskwaj = wGeologijReal.GetSkwajPoIndex(iIndex)
		Loop

	End Function
	Sub WiwestiWDwg(iIndexSkwaj As Integer)
		Dim lsyskomand As New SystemKommand

		lsyskomand.Lock()

		Dim lobjGeom = wtrassaDwg.objGeom


		'проверяем индекс по ограничениям
		Dim lPredPosl As Integer = wGeologijReal.KolwoSkwajn - 2

		If iIndexSkwaj > lPredPosl Then iIndexSkwaj = lPredPosl
		If iIndexSkwaj = 0 Then iIndexSkwaj = 1

		Dim indsred = PredWiwodIndexSkwajn(iIndexSkwaj)
		Dim indexpred = PredWiwodIndexSkwajn(indsred - 1)
		Dim indSled = SledWiwodIndexSkwajn(indsred + 1)
		Dim lDljWii As New WiwParSkwaj(wtrassaDwg, wGeologijReal, indsred, indSled, wparamImagegeo)

		Dim lDljWiiPred As New WiwParSkwaj(wtrassaDwg, wGeologijReal, indexpred, indsred, wparamImagegeo)
		Dim lrastPred = lDljWiiPred.SkwajBeg.Rastojnie
		Dim lrastPredDwg = lobjGeom.DwgXpoRast(lrastPred)
		Dim lrast = lDljWii.SkwajBeg.Rastojnie
		Dim lrastDwg = lobjGeom.DwgXpoRast(lrast)
		Dim lrastPosle = lDljWii.SkwajEnd.Rastojnie
		Dim lrastPosleDwg = lobjGeom.DwgXpoRast(lrastPosle)
		OchistWseLayerGeo(lrastPredDwg + 12, lrastPosleDwg - 12)
		lDljWiiPred.PerepisatWseKontura()
		'   lDljWiiPred.PerepisatSloj()
		lDljWii.Perepisat()
		For i = indexpred + 1 To indSled - 1
			Dim ll = New SkwajnaRealDwg(wtrassaDwg, wGeologijReal.GetSkwajPoIndex(i), wparamImagegeo)
			ll.WiwestiMetkuSkwajWdwg()
		Next







		lsyskomand.Dispose()

		SystemKommand.Act()
	End Sub
End Class
