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
Public Class dwgGeometr
    'класс инкапсулирует работу с координатами профиля, создается как общая компонента dwgtr по данным записанным в словаре 
    'после изменение данных в форме перезаписываеться создается по новой 
    Public Podpis As clsPodpis
    Public KoorP, KoorOtm As clsKoor
    Public obrParam As ParamTrass
    Public Function DwgXpoRast(ByVal Rast As Double) As Double
        Return KoorP.GetDwg(Rast)
    End Function
    Public Function DwgYpoOtm(ByVal Otm As Double) As Double
        Return KoorOtm.GetDwg(Otm)
    End Function
    Public Function RastPoDwgX(ByVal DwgX As Double) As Double
        Return KoorP.GetReal(DwgX)
    End Function
    Public Function OtmPoDwgY(ByVal DwgY As Double) As Double
        Return KoorOtm.GetReal(DwgY)
    End Function
    Public Sub New()
        obrParam = New ParamTrass
        KoorP = New clsKoor(obrParam.Maschtab, obrParam.BegTr, obrParam.BegTrI + clsPodpis.OsY)
        '  If KoorP.Koeff < 0.5 Then
        Podpis = New clsPodpis(KoorP.Koeff, obrParam.ShirinaLista)
        ' Else

        '  Podpis = New clsPodpis(0.5, obrParam.ShirinaLista)
        ' End If



        KoorOtm = New clsKoor(obrParam.MaschtabO, obrParam.BegOtm, obrParam.BegOtmI + Podpis.OsX)
    End Sub
End Class
Public Class ParamTrass
    Private wTipGraniz, wBegUch, wEndUch As String
    Private wMaschtab, wMaschtabO As Integer
    Private wShirinaLista As Double
	Private wPosleZpt As Integer
	Private wBegTr, wBegTrI, wBegOtm, wBegOtmI As Double
    Public Const TipDetal As String = "Деталь"
#Region "Property"
    Public Rabota As String

    Property EndUch() As String
        Get
            Return wEndUch
        End Get
        Set(ByVal value As String)
            wEndUch = value
        End Set

    End Property
    Property BegUch() As String
        Get
            Return wBegUch
        End Get
        Set(ByVal value As String)
            wBegUch = value
        End Set
    End Property
    Property TipGraniz() As String
        Get
            If wTipGraniz <> TipDetal Then Return "" Else Return wTipGraniz
            Return wTipGraniz
        End Get
        Set(ByVal value As String)
            wTipGraniz = value
        End Set
    End Property
    Property Maschtab() As Integer
        Get
            Return wMaschtab
        End Get
        Set(ByVal value As Integer)
            wMaschtab = value
        End Set

    End Property
    Property MaschtabO() As Integer
        Get
            Return wMaschtabO
        End Get
        Set(ByVal value As Integer)
            wMaschtabO = value
        End Set
    End Property
    Property BegTr() As Double
        Get
            Return wBegTr
        End Get
        Set(ByVal value As Double)
            wBegTr = value
        End Set
    End Property
    Property BegTrI() As Double
        Get
            Return wBegTrI
        End Get
        Set(ByVal value As Double)
            wBegTrI = value
        End Set
    End Property
    Property BegOtm() As Double
        Get
            Return wBegOtm
        End Get
        Set(ByVal value As Double)
            wBegOtm = value
        End Set
    End Property
    Property BegOtmI() As Double
        Get
            Return wBegOtmI
        End Get
        Set(ByVal value As Double)
            wBegOtmI = value
        End Set
    End Property
	Property ShirinaLista() As Double
		Get
			Return wShirinaLista
		End Get
		Set(ByVal value As Double)
			wShirinaLista = value
		End Set
	End Property
	Property PosleZpt() As Integer
		Get
			Return wPosleZpt
		End Get
		Set(ByVal value As Integer)
			wPosleZpt = value
		End Set
	End Property
#End Region
	Private Sub LeseParam()
        Dim SlParam As New dwgSlowar(LeseSreib.GlParam)
        Dim Danwh() As TypedValue
        Dim KolwoParam As Integer
        Danwh = SlParam.ZapisIsSlowar(LeseSreib.ZpParam)
        If Danwh Is Nothing Then
            KolwoParam = -1
        Else
            KolwoParam = UBound(Danwh)
        End If
        wEndUch = ""
        wBegUch = ""
        wTipGraniz = ""
        wMaschtab = 10000
        wMaschtabO = 2000
        wBegTr = 0
        wBegTrI = 100
        wBegOtm = 10
        wBegOtmI = 100
        wShirinaLista = 891
		wPosleZpt = 0


		If KolwoParam >= 0 Then wEndUch = CStr(Danwh(0).Value)
        If KolwoParam >= 1 Then wBegUch = Danwh(1).Value.ToString
        If KolwoParam >= 2 Then wTipGraniz = Danwh(2).Value.ToString
        If KolwoParam >= 3 Then wMaschtab = CInt(Danwh(3).Value)
        If KolwoParam >= 4 Then wMaschtabO = CInt(Danwh(4).Value)
        If KolwoParam >= 5 Then wBegTr = CDbl(Danwh(5).Value)
        If KolwoParam >= 6 Then wBegTrI = CDbl(Danwh(6).Value)
        If KolwoParam >= 7 Then wBegOtm = CDbl(Danwh(7).Value)
        If KolwoParam >= 8 Then wBegOtmI = CDbl(Danwh(8).Value)
		If KolwoParam >= 9 Then wShirinaLista = CDbl(Danwh(9).Value)
		If KolwoParam >= 10 Then wPosleZpt = CInt(Danwh(10).Value)
	End Sub
    Sub SchreibeParam()
        Dim SlParam As New dwgSlowar(LeseSreib.GlParam)
		Dim Danr(10) As TypedValue
		Danr(0) = New TypedValue(CInt(DxfCode.Text), wEndUch)
        Danr(1) = New TypedValue(CInt(DxfCode.Text), wBegUch)
        Danr(2) = New TypedValue(CInt(DxfCode.Text), wTipGraniz)
        Danr(3) = New TypedValue(CInt(DxfCode.Int32), wMaschtab)
        Danr(4) = New TypedValue(CInt(DxfCode.Int32), wMaschtabO)
        Danr(5) = New TypedValue(CInt(DxfCode.Real), wBegTr)
        Danr(6) = New TypedValue(CInt(DxfCode.Real), wBegTrI)
        Danr(7) = New TypedValue(CInt(DxfCode.Real), wBegOtm)
        Danr(8) = New TypedValue(CInt(DxfCode.Real), wBegOtmI)
		Danr(9) = New TypedValue(CInt(DxfCode.Real), wShirinaLista)
		Danr(10) = New TypedValue(CInt(DxfCode.Int32), wPosleZpt)
		SlParam.ZapisW_Slowar(LeseSreib.ZpParam, Danr)

    End Sub

    Public Sub New()
        LeseParam()

    End Sub
End Class

