#If ARX_APP Then
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.ApplicationServices
Imports DBTransMan = Autodesk.AutoCAD.DatabaseServices.TransactionManager
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
Public Class dwgPeresech
    Public Const NameTipLinUWW As String = "штриховая2"   '  "невидимая" штриховая2
    Const NameBlockTIZ_D_GWW As String = "ТИЗ-Д-ГВВ"
    Const NameBlockTIZ__StworZnak As String = "ТИЗ-О-створный знак"
    Const NameBlockTIZ__PolotnoAd As String = "ТИЗ-Д-отметка полотна а.д. или головки рельса"
    Const NameBlockTIZ_Strelka As String = "ТИЗ-О-стрелка"
	'Const NamefileTIZ_D_GWW As String = "D:\WL_11\DANN\ТИЗ-Д-ГВВ.dwg"
	'Const NamefileTIZ__StworZnak As String = "D:\WL_11\DANN\ТИЗ-О-створный знак.dwg"
	'Const NamefileTIZ__PolotnoAd As String = "D:\WL_11\DANN\ТИЗ-Д-отметка полотна а.д. или головки рельса.dwg"
	'Const NamefileTIZ_Strelka As String = "D:\WL_11\DANN\ТИЗ-О-стрелка.dwg"
	'Public PutFileBlock As String = My.MySettings.Default.BasePapkaGlobal & "\DANN\bloki.dwg" 'ProfilBaseDwg.My.MySettings.     
	Public Shared Sub ProvBlock()
		Dim PutFileBlock As String = My.MySettings.Default.BasePapkaGlobal & "\DANN\bloki.dwg" 'ProfilBaseDwg.My.MySettings. 
		If Not BazDwg.MakeEntities.EstLiBlock(NameBlockTIZ_D_GWW) Then
            BazDwg.operBlock.ImportBlockIzFile(PutFileBlock)
            Return
        End If

        If Not BazDwg.MakeEntities.EstLiBlock(NameBlockTIZ__StworZnak) Then
            BazDwg.operBlock.ImportBlockIzFile(PutFileBlock)
            Return
        End If

        If Not BazDwg.MakeEntities.EstLiBlock(NameBlockTIZ__PolotnoAd) Then
            BazDwg.operBlock.ImportBlockIzFile(PutFileBlock)
            Return
        End If

        If Not BazDwg.MakeEntities.EstLiBlock(NameBlockTIZ_Strelka) Then
            BazDwg.operBlock.ImportBlockIzFile(PutFileBlock)
            Return
        End If


    End Sub
    Public Enum TipPeresech
        нет = 0
        ВЛ = 1
        Жд = 2
        Жилыесооружения = 3
        Производственныесооружения = 4
        Линиисвязиитп = 5
        Автомобильныедороги = 6
        ТролТрамЛинии = 7
        Судоходные = 8
        Несудоходные = 9
        СтоянкиСудов = 10
        Мосты = 11
        ПлотиныДамбы = 12
        Прочие = 13
        Геодез = 14
    End Enum
    Private wPiket As clsPrf.ClsPiket
    Private Prsch As clsPrf.clsPeresech
    Private wDwgtr As DwgTr
    Private Shared Os As Double
    Private Const Shir As Double = 2
    Private ReadOnly Property RastOtNachala As Double
        Get
            Return wPiket.RastOtnachala
        End Get
    End Property
    Public Shared WriteOnly Property Mesto() As Double
        Set(ByVal value As Double)
            Os = value
        End Set
    End Property
    Sub New(ByVal iPiket As clsPrf.ClsPiket, ByVal iPeresech As clsPrf.clsPeresech)
        Prsch = iPeresech
        wPiket = iPiket
        wDwgtr = iPiket.UchPrf.Trassa
    End Sub
    Sub RasstGr(ByVal iOtm As Double, ByRef iRpred As Double, ByRef iRsled As Double)
        Dim lPikPred As clsPrf.ClsPiket = wPiket
        Dim lPikSled As clsPrf.ClsPiket = wPiket
        Do Until lPikPred Is Nothing
            If lPikPred.Otmetka > iOtm Then
                Exit Do
            Else
                lPikPred = lPikPred.Pred
            End If

        Loop

        Do Until lPikSled Is Nothing
            If lPikSled.Otmetka > iOtm Then
                Exit Do
            Else
                lPikSled = lPikSled.Sled
            End If

        Loop
        If lPikPred IsNot Nothing Then
            iRpred = lPikPred.RasstPoOtmSled(iOtm)
        Else
            iRpred = wPiket.UchPrf.BegUch.RastOtnachala
        End If
        If lPikSled IsNot Nothing Then
            iRsled = lPikSled.RasstPoOtmPred(iOtm)
        Else
            iRsled = wPiket.UchPrf.EndUch.RastOtnachala
        End If

    End Sub
    Private Sub WiwestiOtmetki(ByVal tPrf As Point3d, ByVal ColEl As ObjectIdCollection)
        If Prsch.Razm >= 0 Then
            Dim colSt As New Point2dCollection
            Dim I As Integer

            colSt.Add(New Point2d(tPrf.X, tPrf.Y))
            For I = 0 To Prsch.Razm

                Dim OtmPer As Double = wDwgtr.DwgYpoOtm(Prsch.Otmetki(I))
                ColEl.Add(BazDwg.MakeEntities.CreateLine(tPrf.X - Shir, OtmPer, tPrf.X + Shir, OtmPer))
                colSt.Add(New Point2d(tPrf.X, OtmPer))
            Next
            ColEl.Add(BazDwg.MakeEntities.CreateLwPolyline(colSt))

        End If
    End Sub

    Sub Wiwesti(ByVal tPrf As Point3d, ByVal ColEl As ObjectIdCollection, ByVal Piketaj As Double)
        ' If Prsch.Razm < 0 Then ColEl.Add(BazfunNet.CreateEntities.MakeEntities.CreateCircle(tPrf.X, tPrf.Y, 1)) ' If Prsch.razm < 0 Then
        Dim builderStrWiw As New System.Text.StringBuilder
        If String.IsNullOrWhiteSpace(Prsch.Opis) Then 'Выводить о пересечение только если есть описание 2015.9.8
            builderStrWiw.Append(" ")
        Else
			Dim lstr = clsPrf.ClsPiket.PiketnaSotIost(Piketaj, wDwgtr.StrFormatHor)

			builderStrWiw.Append("+")
            builderStrWiw.Append(lstr(1))     'Format(Math.Round(Piketaj Mod 100), "00")
            builderStrWiw.Append(" ")
            builderStrWiw.Append(Prsch.Opis)
        End If
        Dim lelTxt As ObjectId = BazDwg.dwgText.CreateTextV(New Point3d(tPrf.X, Os, 0), builderStrWiw.ToString, 2, clsPodpis.ShirinaNadpisi)
        ColEl.Add(lelTxt)

        Select Case Prsch.IdTipSoor
            Case TipPeresech.Несудоходные, TipPeresech.Судоходные
                Dim GrPred, GrSled As Double
                If Prsch.Razm >= 0 Then
                    RasstGr(Prsch.Otmetki(0), GrPred, GrSled)
                    Dim lEkrPred, lEkrSled, lotmEkr As Double
					With wDwgtr
						lEkrPred = .DwgXpoRast(GrPred)
						lEkrSled = .DwgXpoRast(GrSled)
						lotmEkr = .DwgYpoOtm(Prsch.Otmetki(0))
					End With
					' Выводим линию
					Dim elurez As ObjectId = BazDwg.MakeEntities.CreateLine(lEkrPred, lotmEkr, lEkrSled, lotmEkr)
					ColEl.Add(elurez)

					BazDwg.Kommand.changeTipLin(elurez, NameTipLinUWW)
					' Вставляем блок с атрибутами

					Dim lTextAttr = "ГВВ 1%=" & Format(Prsch.Otmetki(0), "0.00") & "м БС"
					If wPiket.UchPrf.Unom < 330 Then
						lTextAttr = "ГВВ 2%=" & Format(Prsch.Otmetki(0), "0.00") & "м БС"
					End If
					Dim lwstwkId As ObjectId =
						BazDwg.MakeEntities.CreateWstawkBlockSAttr(New Point3d(tPrf.X, lotmEkr, 0), "ТИЗ-Д-ГВВ", "ГВВ", lTextAttr)
					ColEl.Add(lwstwkId)
                    BazDwg.changeColor(elurez, 5)
                    BazDwg.changeColor(lwstwkId, 5)
                End If
            Case 14
                Dim exs As Extents3d = BazDwg.dwgText.DlinaEl(lelTxt)
                Dim lY = Math.Max(exs.MaxPoint.Y, exs.MinPoint.Y)
                ColEl.Add(BazDwg.MakeEntities.CreateWstawkBlock(New Point3d(tPrf.X, lY + 10, 0), "ТИЗ-О-створный знак"))
            Case TipPeresech.Автомобильныедороги, TipPeresech.Жд
                ColEl.Add(BazDwg.MakeEntities.CreateWstawkBlockSAttr(New Point3d(tPrf.X, tPrf.Y, 0), _
                                                                                       "ТИЗ-Д-отметка полотна а.д. или головки рельса", "ГР", Format(wPiket.Otmetka, "#.0")))
                WiwestiOtmetki(tPrf, ColEl)
            Case Else
                'If Prsch.Razm >= 0 Then
                '    Dim colSt As New Point2dCollection
                '    Dim I As Integer

                '    colSt.Add(New Point2d(tPrf.X, tPrf.Y))
                '    For I = 0 To Prsch.Razm

                '        Dim OtmPer As Double = gTrassa.DwgYpoOtm(Prsch.Otmetki(I))
                '        ColEl.Add(BazfunNet.CreateEntities.MakeEntities.CreateLine(tPrf.X - Shir, OtmPer, tPrf.X + Shir, OtmPer))
                '        colSt.Add(New Point2d(tPrf.X, OtmPer))
                '    Next
                '    ColEl.Add(BazfunNet.CreateEntities.MakeEntities.CreateLwPolyline(colSt))
                'Else
                '    ' ColEl.Add(BazfunNet.CreateEntities.MakeEntities.CreateCircle(tPrf.X, tPrf.Y, 1))
                'End If
                WiwestiOtmetki(tPrf, ColEl)
        End Select





    End Sub
End Class
