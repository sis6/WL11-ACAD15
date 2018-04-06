Imports modRasstOp

#If ARX_APP Then
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.DatabaseServices
#Else
Imports Teigha.Geometry
Imports Teigha.DatabaseServices
#End If

Imports System.Text
Public Class SdwigPoProlety
	Public Property OtNachala As Double
	Public Property SdwigPoperesh As Double
	Public Property Otmetka As Double
	Sub New()

	End Sub
	Sub New(iOtnachala As Double, iSdwigPoperech As Double, iOtmetka As Double)
		_OtNachala = iOtnachala
		_SdwigPoperesh = iSdwigPoperech
		_Otmetka = iOtmetka
	End Sub

End Class


Public Class Prolet3D
	Implements modRasstOp.iProlet
	Private wOpBeg, wopEnd As opor3D
	Private wRejmRasch As Rashet.Rejm   ', wRejmRaschT
	Private wDlinaProlet, wBegRast, wEndRast As Double 'Длина пролета по центальной линии профиля, растояние начальной и конечной опоры пролета  
	Private wnumF As modRasstOp.Fazi = 0
	Private wTshProlet3D As modRasstOp.tshprolet3D
	Private wProekOsi As BazDwg.myLine2D
#Region "Read onlu"
	ReadOnly Property Faza As Fazi Implements iProlet.Faza
		Get
			Return wnumF
		End Get
	End Property
	ReadOnly Property Girl() As modRasstOp.rstGirl Implements modRasstOp.iProlet.Girl
		Get
			Return wOpBeg.OpRasst.Girlajnda
		End Get
	End Property
	ReadOnly Property tshprolet As modRasstOp.tshprolet Implements modRasstOp.iProlet.TshProlet
		Get
			Return CType(wTshProlet3D, modRasstOp.tshprolet)
		End Get
	End Property
	ReadOnly Property OpBeg As modRasstOp.wlOpRasst Implements modRasstOp.iProlet.OpBeg
		Get
			Return wOpBeg.OpRasst
		End Get
	End Property
	ReadOnly Property OpEnd As modRasstOp.wlOpRasst Implements modRasstOp.iProlet.opEnd
		Get
			Return wopEnd.OpRasst
		End Get
	End Property
#End Region
	'ReadOnly Property NumF As modRasstOp.Fazi

	'    Get
	'        Return wnumF
	'    End Get

	'End Property
	''' <summary>
	''' Конструктор создания образа пролета в 3D
	''' </summary>
	''' <param name="iopBeg"> начальная опора пролета  </param>
	''' <param name="iopEnd"> конечная опора пролета </param>
	''' <param name="iRej">  режим работы провода  </param>
	''' <param name="ifaz"> фаза  </param>
	''' <remarks></remarks>
	Sub New(ByVal iopBeg As opor3D, ByVal iopEnd As opor3D, ByVal iRej As Rashet.Rejm, ByVal ifaz As modRasstOp.Fazi)
		wOpBeg = iopBeg
		wopEnd = iopEnd
		wRejmRasch = iRej
		'  wRejmRaschT = irejT
		wnumF = ifaz
		wBegRast = wOpBeg.OpRasst.RastOtNachala
		wEndRast = wopEnd.OpRasst.RastOtNachala
		wDlinaProlet = wEndRast - wBegRast
		wTshProlet3D = New modRasstOp.tshprolet3D(wOpBeg.Trawers(wnumF), wopEnd.Trawers(wnumF), wRejmRasch.Sigma, wRejmRasch.Gamma)
		wProekOsi = New BazDwg.myLine2D(New Point2d(wOpBeg.KoorOp(0), wOpBeg.KoorOp(1)), New Point2d(wopEnd.KoorOp(0), wopEnd.KoorOp(1)))
		'  wdeltaTrawers = (wopEnd.wDlProekziiTrawers(wnumF) - wOpBeg.wDlProekziiTrawers(wnumF)) / (wEndRast - wBegRast)
	End Sub

#Region "Определение"
	''' <summary>
	''' Определение минимального расстояния до поверхности
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Function OpredMinRastDoPow() As DFun
		Dim lMinRastpop, ldostigMinPop As Double
		lMinRastpop = 100000.0
		Dim lRastPoVertirtikali As Double
		Dim lbegProlPop As clsPrf.clsPiket3d = wOpBeg.Piket3d.Pred   ' пикет предшествующий опоре
		If lbegProlPop Is Nothing Then lbegProlPop = wOpBeg.Piket3d
		Dim lsp As List(Of Double()) = wTshProlet3D.ProviProwod3d(150)   'провисание провода
		'  Dim PlLinProv As New BazfunNet.myPolyline3d(lsp)     ' определили 3д полилинию

		For Each lKoorPr() As Double In lsp        ' по всем точкам провода определяем расстояние до поверхности

			Dim lproekz As New Point2d(lKoorPr(0), lKoorPr(1))
			Dim lparametr As Double = wProekOsi.ParametrOrto(lproekz) 'определили основание перпендикуляра на проекцию пролета плоскость XY


			If lparametr > 0 And lparametr < 1 Then ' если в пределах основного пролет определяем минимум 
				Dim lTr As Double = wBegRast + lparametr * wDlinaProlet


				Dim lpop As List(Of Double()) = clsPrf.Powerhnost.NajtiPopereschik(lTr, lbegProlPop)  ' нашли поперечную линию
				Dim lrasstPop As Double = New BazDwg.myPolyline3d(lpop).Distance(New Point3d(lKoorPr))
				If Math.Abs(lparametr - 0.5) < 0.01 Then
					lRastPoVertirtikali = lKoorPr(2) - lpop(1)(2)
				End If

				If lrasstPop < lMinRastpop Then
					lMinRastpop = lrasstPop
					ldostigMinPop = lTr
					'wrOtmPow = lKoorPow(2)
				End If

			End If

		Next
		Dim rez As New DFun((ldostigMinPop - wBegRast) / wDlinaProlet, lMinRastpop)
		rez.Dop = wTshProlet3D.StrelaMax    '                           wOpBeg.OpRasst.Piketaj + ldostigMinPop - wOpBeg.OpRasst.RastOtNachala
		rez.Name = wOpBeg.OpRasst.NumName
		rez.Piketaj = wOpBeg.OpRasst.Piketaj
		rez.PoVertikal = lRastPoVertirtikali
		Return rez
	End Function

	Function OpredMinRastProvodTros(ByVal iRejmRaschT As Rashet.Rejm) As DFun


		Dim lprolettr As New modRasstOp.tshprolet3D(wOpBeg.Trawers(modRasstOp.Fazi.tros), wopEnd.Trawers(modRasstOp.Fazi.tros), iRejmRaschT.Sigma, iRejmRaschT.Gamma)




		Dim Plprovod As New BazDwg.myPolyline3d(lprolettr.ProviProwod3d(CInt(wDlinaProlet)))
		Dim Pltros As New BazDwg.myPolyline3d(wTshProlet3D.ProviProwod3d(CInt(wDlinaProlet)))

		Dim dl As Line = Plprovod.Distance(Pltros)
		Dim Lseredina() As Double = Plprovod.DistanceGVTochka(Pltros, 0.5)
		Dim lpar As Double = dl.StartPoint.X - wOpBeg.KoorOp(0)        '- wOpBeg.OpRasst.RastOtNachala
		Dim rez As New DFun(lpar, dl.Length)
		rez.GabaritSer = Lseredina(0)                       'lprolettr.StrelaMax                'wOpBeg.OpRasst.Piketaj + lpar - wOpBeg.OpRasst.RastOtNachala
		rez.PoVertikal = Lseredina(2)
		rez.Name = wOpBeg.OpRasst.NumName
		rez.Piketaj = wOpBeg.OpRasst.Piketaj
		Return rez
	End Function
	Function OpredMinRastProvodProvod(ByVal iNumF As Fazi) As DFun


		Dim lproletI As New modRasstOp.tshprolet3D(wOpBeg.Trawers(iNumF), wopEnd.Trawers(iNumF), wRejmRasch.Sigma, wRejmRasch.Gamma)




		Dim Plprovod As New BazDwg.myPolyline3d(wTshProlet3D.ProviProwod3d(CInt(wDlinaProlet * 2)))
		Dim PlprovodI As New BazDwg.myPolyline3d(lproletI.ProviProwod3d(CInt(wDlinaProlet * 2)))

		Dim d As Line = Plprovod.Distance(PlprovodI)
		Dim lpar = d.StartPoint.X + wBegRast

		Dim rez As New DFun(lpar, d.Length)
		rez.Dop = wOpBeg.OpRasst.Piketaj + d.StartPoint.X
		rez.Name = wOpBeg.OpRasst.NumName
		Return rez
	End Function
	''' <summary>
	''' Определение смещения провода в середине пролета
	''' </summary>
	''' <param name="iNumF"> фаза  с которым ищется смещение</param>
	''' <param name="iRejRascheta"> режим работы провода скоторым ищется смещение </param>
	''' <returns></returns>
	''' <remarks></remarks>
	Function OpredPolSmeshPoFaziRejm(ByVal iNumF As Fazi, iRejRascheta As Rashet.Rejm) As Smeshenie
		Dim lproletI As New modRasstOp.tshprolet3D(wOpBeg.Trawers(iNumF), wopEnd.Trawers(iNumF), iRejRascheta.Sigma, iRejRascheta.Gamma)

		Dim Plprovod As New BazDwg.myPolyline3d(wTshProlet3D.ProviProwod3d(CInt(wDlinaProlet * 2)))
		Dim PlprovodI As New BazDwg.myPolyline3d(lproletI.ProviProwod3d(CInt(wDlinaProlet * 2)))

		Dim d() As Double = Plprovod.DistanceGVTochka(PlprovodI, 0.5)
		Dim rez As New Smeshenie
		rez.SmeshGor = d(1)
		rez.SmeshVert = d(2)

		'   rez.Strela = Math.Max(wTshProlet3D.StrelaMax, lproletI.StrelaMax)  ' находим максимальную стрелу для  смещенных пролетов  пролетов
		rez.Strela = wTshProlet3D.StrelaMax
		rez.CosNaklon = Math.Min(wTshProlet3D.CosUglaNakl, lproletI.CosUglaNakl)
		Return rez
	End Function
	Function OpredPolSmeshProvodProvod(ByVal iNumF As Fazi) As Smeshenie
		Return OpredPolSmeshPoFaziRejm(iNumF, wRejmRasch)

	End Function
	Function OpredMinSmeshPoFaziRejm(ByVal iNumF As Fazi, iRejRascheta As Rashet.Rejm) As Smeshenie
		Dim lproletI As New modRasstOp.tshprolet3D(wOpBeg.Trawers(iNumF), wopEnd.Trawers(iNumF), iRejRascheta.Sigma, iRejRascheta.Gamma)

		Dim Plprovod As New BazDwg.myPolyline3d(wTshProlet3D.ProviProwod3d(CInt(wDlinaProlet * 2)))
		Dim PlprovodI As New BazDwg.myPolyline3d(lproletI.ProviProwod3d(CInt(wDlinaProlet * 2)))

		Dim d() As Double = Plprovod.DistanceGV(PlprovodI)
		Dim rez As New Smeshenie
		rez.SmeshGor = d(1)
		rez.SmeshVert = d(2)

		'   rez.Strela = Math.Max(wTshProlet3D.StrelaMax, lproletI.StrelaMax)  ' находим максимальную стрелу для  смещенных пролетов  пролетов
		rez.Strela = wTshProlet3D.StrelaMax
		rez.CosNaklon = Math.Min(wTshProlet3D.CosUglaNakl, lproletI.CosUglaNakl)
		Return rez
	End Function
	Function OpredMinSmeshProvodProvod(ByVal iNumF As Fazi) As Smeshenie
		Return OpredMinSmeshPoFaziRejm(iNumF, wRejmRasch)

	End Function

	Private Function LinePeresech(ByVal iPiket As clsPrf.clsPiket3d, ByVal fi As Double) As BazDwg.myLine3D
		Dim lpb(), lpe() As Double

		If iPiket.EstPeresech Then
			lpb = iPiket.PodUglom(fi, iPiket.Piket.Peresech.maxOtmetka)
			lpe = iPiket.PodUglom(fi - Math.PI, iPiket.Piket.Peresech.maxOtmetka)
		Else
			lpb = iPiket.PodUglom(fi, iPiket.Piket.Otmetka)
			lpe = iPiket.PodUglom(fi - Math.PI, iPiket.Piket.Otmetka)
		End If
		Return New BazDwg.myLine3D(New Point3d(lpb(0), lpb(1), lpb(2)), New Point3d(lpe(0), lpe(1), lpe(2)))
	End Function
	''' <summary>
	''' Находим минимальное расстояние  между точкой в пространстве и и прямой проходящей через пикет , а в случае пересечения через ее высшую отметку 
	''' </summary>
	''' <param name="iLinPersch"> отрезок линии пересекающий пикетную точку </param>
	''' <param name="iTchk"> заданая точка в пространстве </param>
	''' <returns></returns>
	''' <remarks></remarks>
	Private Function bliz(iLinPersch As BazDwg.myLine3D, ByVal iTchk() As Double) As Double

		Return iLinPersch.Distance(New Point3d(iTchk(0), iTchk(1), iTchk(2)))
	End Function
	Private Function PoPiketPiket3D(ByVal IPiket As clsPrf.ClsPiket) As clsPrf.clsPiket3d
		Dim lp3d As clsPrf.clsPiket3d = wOpBeg.Piket3d
		Do Until lp3d Is wopEnd
			If lp3d.Piket Is IPiket Then Return lp3d
			lp3d = lp3d.Sled
		Loop
		Return Nothing
	End Function
	''' <summary>
	''' определяет минимальное расстояние от провода пролета  до пересечени
	''' </summary>
	''' <param name="iPeresech"> пересекаемый объект </param>
	''' <returns></returns>
	''' <remarks> полагаем что пересечение проходит под линией перпендикулярно трассе </remarks>
	Function OpredRastPeresech(ByVal iPeresech As Rashet.wlperesech) As DFun
		If iPeresech.OpBeg IsNot wOpBeg.OpRasst Then Return New DFun(10000, 10000)

		Dim lMinRast, ldostigMin, lPoOtm As Double

		lMinRast = 100000.0
		Dim lPiket3Dpersch As clsPrf.clsPiket3d = PoPiketPiket3D(iPeresech.Piket)   ' нашли образ пикета в 3д  соответствующий пересечению
		If lPiket3Dpersch Is Nothing Then
			MsgBox(Me.ToString & "не найден в модели пикет для пересечения  " & iPeresech.IdTipSoor & " ПК  " & iPeresech.Piket.Piketaj)
		End If
		Dim lPeket3dpred = lPiket3Dpersch.Pred
		If lPeket3dpred Is Nothing Then lPeket3dpred = lPiket3Dpersch
		Dim lLinePeresech As BazDwg.myLine3D = LinePeresech(lPiket3Dpersch, Math.PI * 0.5)   ' построили линию проходящую через вершину пересечения

		For tr As Double = Math.Max(lPiket3Dpersch.Piket.RastOtnachala - 4, lPeket3dpred.Piket.RastOtnachala) To _
			Math.Min(lPiket3Dpersch.Piket.RastOtnachala + 4, lPiket3Dpersch.Sled.Piket.RastOtnachala)     ' 


			Dim lKoorPr() As Double = wTshProlet3D.ProviProwod3d(tr - wBegRast)

			Dim lPointBliz = lLinePeresech.GetBlijajshuj(New Point3d(lKoorPr))
			Dim lrasst As Double = lLinePeresech.Distance(New Point3d(lKoorPr))
			If lrasst < lMinRast Then
				lMinRast = lrasst
				ldostigMin = tr
				lPoOtm = lKoorPr(2) - lPointBliz.Z

			End If
		Next
		'  lpersch = lpersch.Sled
		'lpersch.Piket.Peresech.maxOtmetka
		Dim rez As New DFun(ldostigMin, lMinRast)

		rez.Dop = lPiket3Dpersch.Piket.RastOtnachala
		rez.Info = iPeresech.NamePeresechenij

		rez.Gabarit = lPoOtm
		Return rez
	End Function

	Function GabaritNadTochkoj(iRasstOtnachalа As Double, ByVal iPoint As Point3d) As DFun


		Dim lMinRast, lPointProvod, lGabPoOtm As Double

		lMinRast = 100000.0


		For tr As Double = Math.Max(iRasstOtnachalа - 5, wBegRast) To Math.Min(iRasstOtnachalа + 5, wEndRast) Step 0.1
			'  lBegProl = IopPred.wPiket3d

			Dim lKoorPr() As Double = wTshProlet3D.ProviProwod3d(tr - wBegRast)
			Dim lrasst As Double = iPoint.DistanceTo(New Point3d(lKoorPr))
			If lrasst < lMinRast Then
				lMinRast = lrasst
				lPointProvod = tr
				lGabPoOtm = lKoorPr(2) - iPoint.Z

			End If
		Next
		'  lpersch = lpersch.Sled

		Dim rez As New DFun(lPointProvod - wBegRast, lMinRast)

		rez.Dop = wTshProlet3D.Dlina
		rez.PoVertikal = lGabPoOtm
		Return rez
	End Function

	''' <summary>
	''' находит в пролете ближайшее к проводу пересечение
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Function BlijajsheePeresechnie() As DFun

		Dim lprolet As New modRasstOp.tshprolet3D(wOpBeg.Trawers(wnumF), wopEnd.Trawers(wnumF), wRejmRasch.Sigma, wRejmRasch.Gamma) ' Определили пролет

		Dim lMinRast, LdostigMin, lRastDoPeresech, lGabPoOtm As Double
		Dim wInfo As String = "_"
		lMinRast = 100000.0
		Dim lpersch As clsPrf.clsPiket3d = wOpBeg.Piket3d

		Do Until lpersch Is wopEnd.Piket3d  ' Цикл по всем пикетам
			Dim lpred As clsPrf.clsPiket3d = lpersch.Pred
			If lpred Is Nothing Then lpred = lpersch
			Dim lOtreprPeresech = LinePeresech(lpersch, Math.PI * 0.5)
			For tr As Double = Math.Max(lpred.Piket.RastOtnachala, lpersch.Piket.RastOtnachala - 4) To Math.Min(lpersch.Piket.RastOtnachala + 4, lpersch.Sled.Piket.RastOtnachala)
				'  lBegProl = IopPred.wPiket3d

				Dim lKoorPr() As Double = lprolet.ProviProwod3d(tr - wBegRast)
				Dim lPointBliz = lOtreprPeresech.GetBlijajshuj(New Point3d(lKoorPr))
				Dim lrasst As Double = lOtreprPeresech.Distance(New Point3d(lKoorPr))
				If lrasst < lMinRast Then
					lMinRast = lrasst
					LdostigMin = tr
					lRastDoPeresech = lpersch.Piket.RastOtnachala
					wInfo = lpersch.Piket.Peresech.NamePeresechenij
					lGabPoOtm = lKoorPr(2) - lPointBliz.Z
				End If
			Next
			lpersch = lpersch.Sled
		Loop

		'  lBegProl = IopPred.wPiket3d


		Dim rez As New DFun(LdostigMin, lMinRast)
		rez.Dop = lRastDoPeresech
		rez.Info = wInfo
		rez.Gabarit = lGabPoOtm
		Return rez
	End Function

#End Region
End Class
