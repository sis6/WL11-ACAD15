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
Imports BazDwg

Public Class clsPodpis
    Private DlinaZagH As Double
    Private Const OtstupX As Double = 20, OtstupY As Double = 10
	Private Const DlinaZagX As Double = 50.0
	Public Const ShirinaNadpisi As Double = 80
    Public Const OsY As Double = DlinaZagX + OtstupX
    Public Const NadProfilem As Double = 190
    Public Const ShirWiwKlRasst As Double = 40
    Public PodpisKoor(0 To 18) As Double, PodpisName(0 To 18) As String
    Private oform As New ObjectIdCollection
    Private wPolGrafAbr As Double
    Private wShirProf As Double = 300  '- максимально допустимое расстояние между минимумом и максимумом отметки профиля участка попадающего в видовой экран
    Private wShirRabObl As Double = 500 ' ширина видового экрана отражающий профиль
    Private ShirinaLista As Double
    ' ширина листа = OsX + ShirinaNadpisi + ShitRabОбласти + ShirZonWiw
    Private Sub UstShirRabOblasti()
        wShirRabObl = ShirinaLista - OsX - ShirWiwKlRasst - ShirinaNadpisi - OtstupY
        If wShirRabObl > 500 Then
            wShirProf = wShirRabObl - NadProfilem
        Else
            wShirProf = 0.6 * wShirRabObl
        End If
        '  Application.ShowAlertDialog(Me.ToString & " UstShirRabOblasti " & wShirRabObl & " P " & wShirProf)
    End Sub
    ReadOnly Property ShirRabObl() As Double
        Get
            Return wShirRabObl
        End Get
    End Property
    ReadOnly Property ShirProf() As Double
        Get
            Return wShirProf
        End Get
    End Property
    ReadOnly Property GranizaNadpisi() As Double
        Get
            Return OsX + ShirinaNadpisi
        End Get
    End Property

    ReadOnly Property PolGrafAbr() As Double
        Get
            Return wPolGrafAbr
        End Get
    End Property
    ReadOnly Property OsX() As Double

        Get
            Return PodpisKoor(14)
        End Get
    End Property
    ReadOnly Property OsPiket() As Double
        Get
            Return PodpisKoor(8) + 5
        End Get
    End Property
    ReadOnly Property OsSotenPik() As Double
        Get
            Return PodpisKoor(8)
        End Get
    End Property
    ReadOnly Property OsOtmetok() As Double
        Get
            Return PodpisKoor(9)
        End Get
    End Property
    ReadOnly Property OsOtmetokLw() As Double
        Get
            Return PodpisKoor(10)
        End Get
    End Property
    ReadOnly Property OsOtmetokPr() As Double
        Get
            Return PodpisKoor(7)
        End Get
    End Property
    ReadOnly Property OsUglowPoworota() As Double
        Get
            Return PodpisKoor(6)
        End Get
    End Property
    ReadOnly Property OsUgodij() As Double
        Get
            Return PodpisKoor(11)
        End Get
    End Property
    ReadOnly Property OsAbris() As Double
        Get
            Return PodpisKoor(12)
        End Get
    End Property
    ReadOnly Property OsDlinAnkUch As Double
        Get
            Return PodpisKoor(4)
        End Get
    End Property
    ReadOnly Property OsPrivedAnkUch As Double
        Get
            Return PodpisKoor(5)
        End Get
    End Property
    ''' <summary>
    ''' Выводит координатные оси в чертеже с центром (X-OsY , Y - osX
    ''' </summary>
    ''' <param name="EndX"></param>
    ''' <param name="EndY"></param>
    ''' <remarks></remarks>
    Public Sub Osi(ByVal EndX As Double, ByVal EndY As Double)
        oform.Add(MakeEntities.CreateLine(OsY, OsX, EndX, OsX))
        oform.Add(MakeEntities.CreateLine(OsY, OsX, clsPodpis.OsY, EndY))
    End Sub

    Private Sub InitPodpis(ByVal Koeff As Double)


        PodpisKoor(0) = OtstupY
        PodpisName(0) = "Особые:условия"
        PodpisKoor(1) = OtstupY + 10  '20
        PodpisName(1) = "Расстояние между:выработками"
        PodpisKoor(2) = PodpisKoor(1) + 10  '30
        PodpisName(2) = "Норм. показ."
        PodpisKoor(3) = PodpisKoor(2) + 5   '35
        PodpisName(3) = "Агрес. подзем. вод"
        PodpisKoor(4) = PodpisKoor(3) + 5   '40
        PodpisName(4) = "Длина анкерного уч-ка"
        PodpisKoor(5) = PodpisKoor(4) + 5  '45
        PodpisName(5) = "Приведенный пролет"
        PodpisKoor(6) = PodpisKoor(5) + 5 '50
        PodpisName(6) = "Углы, прямые:километры"
        PodpisKoor(7) = PodpisKoor(6) + 10 '60
        PodpisName(7) = "Отметки правого:профиля"
        PodpisKoor(8) = PodpisKoor(7) + 10 '70
        PodpisName(8) = "Пикетаж"
        PodpisKoor(9) = PodpisKoor(8) + 15 '85
        PodpisName(9) = "Отметки оси"
        PodpisKoor(10) = PodpisKoor(9) + 15 '100
        PodpisName(10) = "Отметки левого:профиля"
        PodpisKoor(11) = PodpisKoor(10) + 10 '110
        PodpisName(11) = "Пикетаж угодий"
        PodpisKoor(12) = PodpisKoor(11) + 10 '120
        PodpisName(12) = "Абрис"
        PodpisKoor(15) = PodpisKoor(8) + 5 ' Для отделения отметок сотен
        PodpisKoor(13) = PodpisKoor(12) + Koeff * 100 + 10 '180
        wPolGrafAbr = (PodpisKoor(12) + PodpisKoor(13)) / 2
        PodpisName(13) = "Границы районов"
        PodpisKoor(14) = PodpisKoor(13) + 5
        PodpisName(14) = "Ось X"
        DlinaZagH = PodpisKoor(14) - PodpisKoor(0)
        PodpisKoor(16) = PodpisKoor(12) + 5
        PodpisKoor(17) = PodpisKoor(13) - 5
        PodpisKoor(18) = (PodpisKoor(16) + PodpisKoor(17)) / 2.0#
        UstShirRabOblasti()
    End Sub

    Private Sub New()

    End Sub
    Private Sub New(ByVal koeff As Double)
        ShirinaLista = 891
        InitPodpis(koeff)

    End Sub
    Public Sub New(ByVal koeff As Double, ByVal List As Double)
        ShirinaLista = List
        InitPodpis(koeff)

    End Sub
    Private Sub TextWGwadRat(ByVal iOtstupX As Double, ByVal Iq As Integer)
        Dim Wis As Double = PodpisKoor(Iq + 1) - PodpisKoor(Iq)
        Dim wisTxt As Double
        Dim lDlZag = DlinaZagX - iOtstupX + OtstupX
        Select Case Wis
            Case Is < 10
                wisTxt = 3
            Case Is < 16
                wisTxt = 3.3
            Case Else
                wisTxt = 5
        End Select
        Dim StrTexta() As String = Strings.Split(PodpisName(Iq), ":") 'определяем количество выводимых строк
        If StrTexta.Length <= 1 Then
            Dim WstText As New Point3d(iOtstupX + 1, PodpisKoor(Iq) + 0.5 * (Wis - wisTxt), 0)

            oform.Add(dwgText.CreateText(WstText, PodpisName(Iq), wisTxt, lDlZag - 1))
        Else
            Dim wstText, wstText1 As Point3d
            wstText = New Point3d(iOtstupX + 1, PodpisKoor(Iq) + 0.75 * Wis - 0.5 * wisTxt, 0)
            wstText1 = New Point3d(iOtstupX + 1, PodpisKoor(Iq) + 0.25 * Wis - 0.5 * wisTxt, 0)
            oform.Add(dwgText.CreateText(wstText, StrTexta(0), wisTxt, lDlZag - 1))
            oform.Add(dwgText.CreateText(wstText1, StrTexta(1), wisTxt, lDlZag - 1))
        End If
    End Sub
    Private Sub GwadRat(ByVal Iq As Integer)
        Dim grT As New Point2dCollection
        Dim Wis As Double = PodpisKoor(Iq + 1) - PodpisKoor(Iq)
        Dim wisTxt As Double = 3
        grT.Add(New Point2d(OtstupX, PodpisKoor(Iq + 1)))
        grT.Add(New Point2d(OtstupX, PodpisKoor(Iq)))
        grT.Add(New Point2d(OtstupX + DlinaZagX, PodpisKoor(Iq)))
        grT.Add(New Point2d(OtstupX + DlinaZagX, PodpisKoor(Iq + 1)))
        oform.Add(MakeEntities.CreateLwPolyline(grT))
        TextWGwadRat(OtstupX, Iq)



    End Sub
    Private Sub GwadRat(ByVal Iq As Integer, ByVal OtNachala As Double)
        Dim grT As New Point2dCollection
        Dim lotstupX As Double = OtstupX + OtNachala
        grT.Add(New Point2d(lotstupX, PodpisKoor(Iq + 1)))
        grT.Add(New Point2d(lotstupX, PodpisKoor(Iq)))
        grT.Add(New Point2d(OtstupX + DlinaZagX, PodpisKoor(Iq)))
        grT.Add(New Point2d(OtstupX + DlinaZagX, PodpisKoor(Iq + 1)))
        oform.Add(MakeEntities.CreateLwPolyline(grT))
        TextWGwadRat(lotstupX, Iq)
    End Sub
    Private Sub ZagGeolog()
        Dim grT As New Point2dCollection
        Dim DlTxt As Double = PodpisKoor(4) - PodpisKoor(0) - 2
        grT.Add(New Point2d(OtstupX, PodpisKoor(4)))
        grT.Add(New Point2d(OtstupX, PodpisKoor(0)))
        grT.Add(New Point2d(OtstupX + 20, PodpisKoor(0)))
        grT.Add(New Point2d(OtstupX + 20, PodpisKoor(4)))
        oform.Add(MakeEntities.CreateLwPolyline(grT))
        Dim WstText As New Point3d(OtstupX + 6, PodpisKoor(0) + 1, 0)
        oform.Add(dwgText.CreateTextV(WstText, "Инженерно-", 4, DlTxt))
        WstText = New Point3d(OtstupX + 12, PodpisKoor(0) + 1, 0)
        oform.Add(dwgText.CreateTextV(WstText, "геологическая", 4, DlTxt))
        WstText = New Point3d(OtstupX + 18, PodpisKoor(0) + 1, 0)
        oform.Add(dwgText.CreateTextV(WstText, "характеристика", 4, DlTxt))
    End Sub
    Sub wiwestiPodpis(ByVal DlinaPodw As Double, ByVal iDwgTr As DwgTr)
        Dim I As Integer
        Dim lBegLin As Double = OtstupX + DlinaZagX
        Dim lEndLin As Double = DlinaPodw
        ZagGeolog()
        For I = 0 To 13
            If I <= 3 Then
                GwadRat(I, 20)
            Else
                GwadRat(I)
            End If

            oform.Add(MakeEntities.CreateLine(lBegLin, PodpisKoor(I), lEndLin, PodpisKoor(I)))
        Next
        oform.Add(MakeEntities.CreateLine(lBegLin, PodpisKoor(13) - 5, lEndLin, PodpisKoor(13) - 5)) 'линия ниже  землепользователей
        oform.Add(MakeEntities.CreateLine(lBegLin, PodpisKoor(12) + 5, lEndLin, PodpisKoor(12) + 5)) 'линия выше абрис 

        oform.Add(MakeEntities.CreateLine(lBegLin, OsPiket(), lEndLin, OsPiket()))
        oform.Add(MakeEntities.CreateLine(OtstupX, OsX(), lBegLin, OsX())) 'завершить полилинию землеполльзователь
        Dim lVwiw As Double = OsX() + 7
        Dim lwstTxt As New Point3d(OtstupX, lVwiw, 0)
        oform.Add(dwgText.CreateText(lwstTxt, "В. " & iDwgTr.objGeom.KoorOtm.NameMaschtab, 3))
        lVwiw += 5
        lwstTxt = New Point3d(OtstupX, lVwiw, 0)
        oform.Add(dwgText.CreateText(lwstTxt, "Г. " & iDwgTr.objGeom.KoorP.NameMaschtab, 3))
        lVwiw += 5
        lwstTxt = New Point3d(OtstupX, lVwiw, 0)
        oform.Add(dwgText.CreateText(lwstTxt, "Масштаб:", 3))

        lVwiw += 6
        lwstTxt = New Point3d(OtstupX, lVwiw, 0)
        Dim el As ObjectId = dwgText.CreateText(lwstTxt, "Левый профиль", 3)
        Dim elLin As ObjectId = MakeEntities.CreateLine(OtstupX, lVwiw - 1, OtstupX + 40, lVwiw - 1)
        BazDwg.Kommand.changeColor(el, DwgTr.ColorLewogo)
        BazDwg.Kommand.changeColor(elLin, DwgTr.ColorLewogo)
        BazDwg.Kommand.changeTipLin(elLin, DwgTr.NameTipLinLwPr)
        oform.Add(el)
        oform.Add(elLin)
        lVwiw += 6
        lwstTxt = New Point3d(OtstupX, lVwiw, 0)
        el = dwgText.CreateText(lwstTxt, "Правый профиль", 3)
        elLin = MakeEntities.CreateLine(OtstupX, lVwiw - 1, OtstupX + 40, lVwiw - 1)
        BazDwg.Kommand.changeColor(el, DwgTr.ColorPrawogo)
        BazDwg.Kommand.changeColor(elLin, DwgTr.ColorPrawogo)
        BazDwg.Kommand.changeTipLin(elLin, DwgTr.NameTipLinPrPr)
        oform.Add(el)
        oform.Add(elLin)
    End Sub
    ReadOnly Property CollPrim() As ObjectIdCollection
        Get
            Return oform
        End Get
    End Property
    Sub WiwestiWsp(ByVal DlinaPodW As Double, ByVal Collwsp As ObjectIdCollection)
        Collwsp.Add(MakeEntities.CreateLine(OtstupX + DlinaZagX, GranizaNadpisi, DlinaPodW, GranizaNadpisi))
        Collwsp.Add(MakeEntities.CreateLine(OtstupX + DlinaZagX, PolGrafAbr, DlinaPodW, PolGrafAbr))
    End Sub
End Class
