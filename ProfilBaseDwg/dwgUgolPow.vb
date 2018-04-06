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
Public Class dwgUgolPow
    Private UgolPoworota As clsPrf.clsUgolPoworot
    ' Private RastOtNachala As Double
    Private Const ShirStrelki As Double = 2
    Private UgolLewo As Boolean
    Private TockaWstawki, TwstawkiDo, TwstawkiPosle As Point3d
    Private Shared Os, PolGraf As Double
    Private wTrDwg As DwgTr
    ReadOnly Property RastOtNachala As Double
        Get
            Return UgolPoworota.Piket.RastOtnachala
        End Get
    End Property
    Shared WriteOnly Property Mesto() As Double
        Set(ByVal value As Double)
            Os = value
            PolGraf = Os + 5
        End Set
    End Property
    Sub New(ByVal Ugol As clsPrf.clsUgolPoworot)
        UgolPoworota = Ugol
        wTrDwg = Ugol.Piket.UchPrf.Trassa

        With UgolPoworota
            If Chr(Asc(.StrUgolPoworota)) = "л" Or Chr(Asc(.StrUgolPoworota)) = "Л" Then
                UgolLewo = True
            Else
                UgolLewo = False
            End If
        End With
    End Sub
    Private Function StrUglaNaDwg() As String

        Dim StrWsp = Mid(UgolPoworota.StrUgolPoworota, 2)
        StrWsp = Replace(StrWsp, "g", "°")
        StrWsp = Replace(StrWsp, ":", "'")
        If UgolLewo Then
            StrWsp = "Лево" & StrWsp
        Else
            StrWsp = "Право" & StrWsp
        End If
        Return StrWsp

    End Function

  
    Sub WiwestiNaDwg(ByVal KoorPoX As Double, ByVal colel As ObjectIdCollection)
        '  ТИЗ-О-стрелка
        If UgolLewo Then
            TockaWstawki = New Point3d(KoorPoX, Os, 0)
        Else
            TockaWstawki = New Point3d(KoorPoX, Os + 10, 0)
        End If
        Dim TWstawkiName, TWstawkiPiket, TwstawkiUgla As Point3d
        TWstawkiName = New Point3d(TockaWstawki.X - 10, PolGraf + 1, 0)    'PolGraf + 1
        TwstawkiDo = New Point3d(TockaWstawki.X - ShirStrelki, PolGraf, 0)
        TwstawkiPosle = New Point3d(TockaWstawki.X + ShirStrelki, PolGraf, 0)
        If UgolLewo Then
            TWstawkiPiket = New Point3d(TockaWstawki.X + ShirStrelki, Os + 1, 0)
            TwstawkiUgla = New Point3d(TockaWstawki.X, PolGraf + 1, 0)
        Else
            TWstawkiPiket = New Point3d(TockaWstawki.X, Os + 1, 0)
            TwstawkiUgla = New Point3d(TockaWstawki.X + ShirStrelki, PolGraf + 1, 0)
        End If


        'стрелку угла поллилинией
        Dim colStr As New Point2dCollection
        colStr.Add(New Point2d(TwstawkiDo.X, TwstawkiDo.Y))
        colStr.Add(New Point2d(TockaWstawki.X, TockaWstawki.Y))
        colStr.Add(New Point2d(TwstawkiPosle.X, TwstawkiPosle.Y))
		'добавляем примитивы
		colel.Add(BazDwg.MakeEntities.CreateLwPolyline(colStr))
		'If wTrDwg.objGeom.obrParam.PosleZpt > 0 Then
		colel.Add(BazDwg.dwgText.CreateText(TWstawkiPiket, UgolPoworota.StrPiketaj(wTrDwg.StrFormatOstSotet), DwgTr.WisTextP))
		'Else
		'	colel.Add(BazDwg.dwgText.CreateText(TWstawkiPiket, UgolPoworota.StrPiketaj(), DwgTr.WisTextP))
		'End If

		colel.Add(BazDwg.dwgText.CreateText(TWstawkiName, UgolPoworota.Piket.NamePiket, DwgTr.WisTextP))
        colel.Add(BazDwg.dwgText.CreateText(TwstawkiUgla, StrUglaNaDwg, DwgTr.WisTextP))
        If UgolLewo Then
            colel.Add(BazDwg.MakeEntities.CreateWstawkBlock(New Point3d(KoorPoX, wTrDwg.objGeom.Podpis.PolGrafAbr, 0), "ТИЗ-О-стрелка"))
        Else
            colel.Add(BazDwg.MakeEntities.CreateWstawkBlock(New Point3d(KoorPoX, wTrDwg.objGeom.Podpis.PolGrafAbr, 0), "ТИЗ-О-стрелка", -Math.PI * 0.5))
        End If

    End Sub
    Sub WiwestiMejNaDwg(ByVal UgPred As dwgUgolPow, ByVal colel As ObjectIdCollection)
		'  Dim Delta As Long = CLng(UgolPoworota.Piket.Piketaj) - CLng(UgPred.UgolPoworota.Piket.Piketaj) 
		Dim lDelta = UgolPoworota.DeltaDoUgla(UgPred.UgolPoworota)
		' Delta по пикетажубудет неправильно. А по расстоянию то при округление Delta не будет совпадать с разностью пикетажей. 
		Dim Ser As Double = (UgPred.TwstawkiPosle.X + TwstawkiDo.X) / 2
        Dim TockaWstTxt As New Point3d(Ser - 5, Os + 1, 0)
        colel.Add(BazDwg.MakeEntities.CreateLine(UgPred.TwstawkiPosle, TwstawkiDo))
		colel.Add(BazDwg.dwgText.CreateText(TockaWstTxt, Format(lDelta, wTrDwg.StrFormatHor), DwgTr.WisTextP))
	End Sub
    Sub WiwestiOtTchk(ByVal iRasst As Double, ByVal iRasstEkr As Double, ByVal colel As ObjectIdCollection)
		'Dim Delta As Long = CLng(RastOtNachala) - CLng(iRasst)
		Dim Delta As Double = RastOtNachala - iRasst
		If Math.Abs(Delta) < 2 Then Return
        Dim Ser As Double = (iRasstEkr + TwstawkiDo.X) / 2
        Dim TockaWstTxt As New Point3d(Ser - 5, Os + 1, 0)
        Dim TochkaBeg As New Point3d(iRasstEkr, PolGraf, 0)
        If Delta > 0 Then
            colel.Add(BazDwg.MakeEntities.CreateLine(TochkaBeg, TwstawkiDo))
			colel.Add(BazDwg.dwgText.CreateText(TockaWstTxt, Format(Delta, wTrDwg.StrFormatHor), DwgTr.WisTextP, 10))
		Else
            colel.Add(BazDwg.MakeEntities.CreateLine(TochkaBeg, TwstawkiPosle))
			colel.Add(BazDwg.dwgText.CreateText(TockaWstTxt, Format(-Delta, wTrDwg.StrFormatHor), DwgTr.WisTextP, 10))

		End If



    End Sub
End Class
