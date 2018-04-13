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
Public Class dwgWiwZon
    Protected Const RazmStrihGr As Double = 3
    Protected Const Width As Double = 100 'Ширина вывода мультииекста
    Protected Const height As Double = 5  'Высота строки текста
    '  Protected os As Double
    Protected osZon As Double
    Protected Obraz As New ObjectIdCollection
    Protected WiwTrassa As DwgTr

    ReadOnly Property ObrazWiwod() As ObjectIdCollection
        Get
            Return Obraz
        End Get
    End Property
    Protected Sub WiwGrZon(ByVal Dwgx As Double)
        Obraz.Add(BazDwg.MakeEntities.CreateLine(Dwgx - RazmStrihGr, osZon - RazmStrihGr, Dwgx + RazmStrihGr, osZon + RazmStrihGr))
    End Sub
    Public Sub New(ByVal iWiwTrassa As DwgTr, ByVal iOs As Double)
        WiwTrassa = iWiwTrassa
        osZon = iOs

    End Sub
End Class
Public Class dwgWiwKlimat
    Inherits dwgWiwZon


    Private tKlimat As clsPrf.clsZonKlimat




    'Shared WriteOnly Property Mesto() As Double
    '    Set(ByVal value As Double)
    '        os = value + NadProfilem

    '    End Set


    'End Property
    Private Function StrTipMesta() As String
        Return "Тип мест. " & Chr(Asc("A") + tKlimat.TipMesta)
    End Function
    Private Function StrTemp() As String
        With tKlimat
            Return "Т.°С:макс " & Format(.Tmax, "00") & "мин " & Format(.Tmin, "#00") _
                                       & "гол " & Format(.Tgol, "#0") & ":cр. год " & Format(.Texsp, "00") & vbCrLf
        End With
    End Function
    Private Function StrStGol(ByVal St As Double) As String

        Return "в{\H0.5x;э}=" & Format(St, "00") & "мм"
    End Function
    Private Sub NaDwg(ByVal Xwst As Double, ByVal ShirZon As Double) 'StGolNapVetra

        Dim TchkWst As Point3d
        Dim StrWsp As String
        Dim lWidth As Double = Width
        Dim lheight As Double = height
        Dim Ywst As Double = osZon + 2.5 * height
        If ShirZon > Width Then
            TchkWst = New Point3d(Xwst + ShirZon / 2 - Width / 2, Ywst, 0)
        Else
            TchkWst = New Point3d(Xwst, Ywst, 0)
            lWidth = ShirZon
            lheight = 0.5 * Fix(2 * height * ShirZon / Width)

        End If
        With tKlimat
            StrWsp = "в{\H0.5x;э}=" & Format(.StGolEkw, "00") & "мм;"

            StrWsp = StrWsp & " W{\H0.5x;о}=" & Format(.Napor, "000") & "Па, " _
            & "W{\H0.5x;г}=" & Format(.NaporPrGol, "000") & "Па."
        End With

        Obraz.Add(BazDwg.dwgText.CreateMText(TchkWst, StrWsp, lWidth, lheight))



    End Sub

    Sub Wiw(iRastBeg As Double, iRastEnd As Double)
        Dim lDwgBegZon, lDwgGrZon As Double
        Dim IndexBeg, IndexEnd As Integer
        Dim lRastSled As Double
        Dim lSp = WiwTrassa.WseKlimZonTrass()
        IndexBeg = clsPrf.clsTrass.NajtiIndexZon(lSp, iRastBeg)
        IndexEnd = clsPrf.clsTrass.NajtiIndexZon(lSp, iRastEnd)
        For I As Integer = IndexBeg To IndexEnd
            tKlimat = CType(lSp(I), clsPrf.clsZonKlimat)
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
        Dim SledZon As clsPrf.clsZonKlimat
        Dim GrZon, DwgGrZon, DwgBegZon As Double
        tKlimat = WiwTrassa.BegKlimZon
        Do Until tKlimat Is Nothing
            SledZon = CType(tKlimat.Sled, clsPrf.clsZonKlimat)

			' Try
			'GrZon = SledZon.RastOtnachala
			'   Catch ex As Exception
			If SledZon Is Nothing Then
Sled:           If I < WiwTrassa.MaxNumUchTr Then
					I += 1
					WiwTrassa.NumUch = I
					If WiwTrassa.UchTr.BegKlimZon IsNot Nothing Then
						SledZon = WiwTrassa.UchTr.BegKlimZon
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
			DwgBegZon = WiwTrassa.DwgXpoRast(tKlimat.RastOtnachala)
            DwgGrZon = WiwTrassa.DwgXpoRast(GrZon)
            Obraz.Add(BazDwg.MakeEntities.CreateLine(DwgBegZon, osZon, DwgGrZon, osZon))
            WiwGrZon(DwgBegZon)
            NaDwg(DwgBegZon, DwgGrZon - DwgBegZon)
            tKlimat = SledZon

        Loop
        WiwGrZon(DwgGrZon)

    End Sub
    Public Sub New(ByVal iWiwTrassa As DwgTr)
        MyBase.New(iWiwTrassa, iWiwTrassa.OsKlRasst + clsPodpis.ShirWiwKlRasst / 2 + 5)


    End Sub
End Class
