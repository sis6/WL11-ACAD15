Option Strict On
Option Explicit On

#If ARX_APP Then
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.DatabaseServices
#Else
Imports Teigha.Geometry
Imports Teigha.DatabaseServices
#End If
Imports BazDwg

Public Class dwgKrivProvis
    Private wTchkKriv As Collection
    Private wNameGroup As String
    Private wColor As Long
    Public NameKr As String = "+"
    Property SdwigX As Double
    Property SdwigY As Double

    Property TchkKriv() As Collection
        Get
            Return wTchkKriv
        End Get
        Set(ByVal iTchkkriv As Collection)
            wTchkKriv = iTchkkriv
            KrivDwg()
        End Set
    End Property

    Private Function RastDoProfil(ByVal iTrassa As clsPrf.clsTrass) As Double()
        Dim MinP, maxP As Double
        Dim tDost As Double = -1
        MinP = 10000
        maxP = -10000
        For Each oneTchk As Double() In wTchkKriv
            Dim wWis As Double = iTrassa.WisotaNad(oneTchk(0), oneTchk(1))
            If wWis < MinP Then
                MinP = wWis
                tDost = oneTchk(0)
            End If
            If wWis > maxP Then
                maxP = wWis
            End If

        Next
        Dim mas() As Double = {tDost, MinP}
        Return mas
    End Function

    Private Function RastDoProfil(ByVal iTrassa As clsPrf.clsTrass, ByVal iOrtosdwig As Double) As Double()
        Dim MinP, maxP As Double
        Dim tDost As Double = -1
        MinP = 10000
        maxP = -10000
        For Each oneTchk As Double() In wTchkKriv
            Dim wWis As Double = iTrassa.WisotaNad(oneTchk(0), oneTchk(1), iOrtosdwig)
            If wWis < MinP Then
                MinP = wWis
                tDost = oneTchk(0)
            End If
            If wWis > maxP Then
                maxP = wWis
            End If

        Next
        Dim mas() As Double = {tDost, MinP}
        Return mas
    End Function
    Private Sub KrivDwg()
        Dim colPoint2 As New Point2dCollection


        For Each oneTchk As Double() In wTchkKriv
            With clsKommandBase.gTrassa()
                Dim xdwg As Double = .DwgXpoRast(oneTchk(0) + _SdwigX)
                Dim hdwg As Double = .DwgYpoOtm(oneTchk(1) + _SdwigY)
                colPoint2.Add(New Point2d(xdwg, hdwg))

            End With



        Next
        BazDwg.MakeNeGraf.DeleteIzGroup(wNameGroup)
        Dim colprim As New ObjectIdCollection
        Dim objid As ObjectId = MakeEntities.CreateLwPolyline(colPoint2)
        colprim.Add(objid)
        Dim lntchk As Integer = CInt(colPoint2.Count / 2)
        '    Dim ltext As ObjectId = dwgText.CreateText(New Point3d(colPoint2(lntchk).X, colPoint2(lntchk).Y, 0), NameKr, 2)
        Dim ltext As ObjectId = dwgText.CreateMText(New Point3d(colPoint2(lntchk).X, colPoint2(lntchk).Y, 0), NameKr, 40, 2)
        colprim.Add(ltext)
        BazDwg.Kommand.changeColor(objid, wColor)
        BazDwg.Kommand.changeColor(ltext, wColor)
        BazDwg.Kommand.changeSloj(objid, DwgParam.SlSlujbn)
        BazDwg.Kommand.changeSloj(ltext, DwgParam.SlSlujbn)
        Dim objIdG As ObjectId = BazDwg.MakeNeGraf.InsertWGroup(colprim, wNameGroup, "Крив")

    End Sub
    ''' <summary>
    ''' создание кривой
    ''' </summary>
    ''' <param name="iName"> имя группы </param>
    ''' <param name="iColor"> цвет кривой </param>
    ''' <remarks></remarks>
    Sub New(ByVal iName As String, ByVal iColor As Long)
        wNameGroup = BazDwg.dwgSlowar.DopustImjSlowaraj(iName)
        wColor = iColor
        _SdwigX = 0
        _SdwigY = 0
    End Sub
End Class
