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
Public Class dwgWiwMechusl

    Inherits dwgWiwZon


    Private tmechUsl As modRasstOp.DannZonMechusl
    Private WiwRasst As modRasstOp.wlRasst

    Shared Function SigmaGrech(ByVal Spod As String) As String
        Return "{\fTimes New Roman|b0|i0|c204|p0;\H1.5x;\U+03c3\ftxt|c204;\H0.2x;" & Spod & "}"
    End Function
    Shared Function RazmSigma() As String
        RazmSigma = "Н/мм" & "{\fTimes New Roman|b0|i0|c204|p0;\H0.875x;\U+00B2}"
    End Function
#Region "Tros"
    Private Shared Function WiwodTxtSigmaTros(ByVal iSigmaTr As Double) As String
        Dim wsp As String
        If iSigmaTr < 0 Then

            wsp = "\H0.5x;-по расчету"                                 '& Format(tmechUsl.SigT(2), "000.0") & RazmSigma()
        Else
            wsp = "\H0.875x;=" & Format(iSigmaTr, "f1") & RazmSigma()
        End If
        WiwodTxtSigmaTros = wsp
    End Function
    Private Function WiwodTxtTrosa() As String
        Dim StrWsp As String = "Трос " & Trim(tmechUsl.Name_markT)
        StrWsp &= SigmaGrech("тр.") & WiwodTxtSigmaTros(tmechUsl.SigMaxTrosa)
        Return StrWsp
    End Function
    Shared Function WiwodTxtTrosa(ByVal iAnkuch As Rashet.wlAnkUchTr) As String
        Dim StrWsp As String = "Трос " & Trim(iAnkuch.Mechusl.Name_markT) & " " & SigmaGrech("тр.") & WiwodTxtSigmaTros(iAnkuch.RejTrMaxNagr.Sigma)
        Return StrWsp
    End Function
#End Region
    Private Function WiwodTxt() As String    'EkrX - Xpred
        Dim StrWsp As String
        StrWsp = "Провод " & Trim(tmechUsl.Name_mark) & "\P" & vbCr & SigmaGrech("пр. макс.") & "=" & Format(tmechUsl.Sig(2), "f1") & RazmSigma()
        Return StrWsp
    End Function
    Shared Sub OpredRazm(ByVal Xbeg As Double, ByVal ShirZon As Double, _
        ByRef Xwst As Double, ByRef iWidth As Double, ByRef iheight As Double)
        iWidth = Width
        iheight = height
        If ShirZon > Width Then
            Xwst = Xbeg + 0.5 * (ShirZon - Width)
        Else
            Xwst = Xbeg
            iWidth = ShirZon
            iheight = height * ShirZon / Width
            iheight = 0.5 * Fix(2 * iheight)
        End If
    End Sub

    Private Sub NaDwg(ByVal Xwst As Double, ByVal ShirZon As Double)

        Dim TchkWst As Point3d
        Dim lWidth As Double = Width
        Dim lheight As Double = height
        Dim Ywst As Double = osZon + 3.5 * height
        If ShirZon > Width Then
            TchkWst = New Point3d(Xwst + 0.5 * (ShirZon - Width), Ywst, 0)
        Else
            TchkWst = New Point3d(Xwst, Ywst, 0)
            lWidth = ShirZon
            lheight = height * ShirZon / Width
            lheight = 0.5 * Fix(2 * lheight)
            Ywst = osZon + 3.5 * lheight
        End If
        Obraz.Add(BazDwg.dwgText.CreateMText(TchkWst, WiwodTxt(), lWidth, lheight))
    End Sub


    Sub Wiw(iRastBeg As Double, iRastEnd As Double)
        Dim lDwgBegZon, lDwgGrZon As Double
        Dim IndexBeg, IndexEnd As Integer
        Dim lRastSled As Double
        Dim lSp = WiwRasst.WseMechZonTrass()
        IndexBeg = clsPrf.clsTrass.NajtiIndexZon(lSp, iRastBeg)
        IndexEnd = clsPrf.clsTrass.NajtiIndexZon(lSp, iRastEnd)
        For I As Integer = IndexBeg To IndexEnd
            tmechUsl = CType(lSp(I), modRasstOp.DannZonMechusl)
            If I = IndexEnd Then
                lRastSled = iRastEnd
            Else
                lRastSled = lSp(I + 1).RastOtnachala
            End If
            lDwgBegZon = WiwTrassa.DwgXpoRast(iRastBeg)
            lDwgGrZon = WiwTrassa.DwgXpoRast(lRastSled)
            Obraz.Add(BazDwg.MakeEntities.CreateLine(lDwgBegZon, osZon, lDwgGrZon, osZon))
            WiwGrZon(lDwgBegZon)
            NaDwg(lDwgBegZon, lDwgGrZon - lDwgBegZon)
            iRastBeg = lRastSled
        Next
        WiwGrZon(lDwgGrZon)
    End Sub
    Sub Wiw()
        Dim I As Integer = 0
        Dim SledZon As modRasstOp.DannZonMechusl
        Dim GrZon, DwgGrZon, DwgBegZon As Double
        'Dim wiwTrassa As DwgTr = WiwRasst.objTr
        WiwTrassa.NumUch = I
        '   Dim RasstNauch As modRasstOp.wlUch = wiwTrassa.UchTr
        tmechUsl = CType(WiwTrassa.UchTr, modRasstOp.wlUch).BegMechUslZon
        '  tmechUsl = RasstNauch.BegMechUslZon
        Do Until tmechUsl Is Nothing

            SledZon = CType(tmechUsl.Sled, modRasstOp.DannZonMechusl)

			' Try
			'GrZon = SledZon.RastOtnachala
			' Catch ex As Exception
			If SledZon Is Nothing Then
Sled:           If I < WiwTrassa.MaxNumUchTr Then
					I += 1
					WiwTrassa.NumUch = I
					If CType(WiwTrassa.UchTr, modRasstOp.wlUch).BegMechUslZon IsNot Nothing Then
						SledZon = CType(WiwTrassa.UchTr, modRasstOp.wlUch).BegMechUslZon
						GrZon = SledZon.RastOtnachala
					Else
						GoTo Sled
					End If

				Else
					GrZon = WiwTrassa.Dlina
				End If
			Else
				GrZon = SledZon.RastOtnachala
			End If
			'   End Try
			DwgBegZon = WiwTrassa.DwgXpoRast(tmechUsl.RastOtnachala)
            DwgGrZon = WiwTrassa.DwgXpoRast(GrZon)
            Obraz.Add(BazDwg.MakeEntities.CreateLine(DwgBegZon, osZon, DwgGrZon, osZon))
            WiwGrZon(DwgBegZon)
            '  MsgBox(tmechUsl.Piketaj & " " & I)
            NaDwg(DwgBegZon, DwgGrZon - DwgBegZon)
            tmechUsl = SledZon

        Loop
        WiwGrZon(DwgGrZon)

    End Sub
    Public Sub New(ByVal iWiwRasst As modRasstOp.wlRasst)

        MyBase.New(CType(iWiwRasst.Trassa, DwgTr), CType(iWiwRasst.Trassa, DwgTr).OsKlRasst)
        WiwRasst = iWiwRasst


    End Sub

End Class
