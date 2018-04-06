#If ARX_APP Then
Imports Autodesk.AutoCAD.DatabaseServices
#Else
Imports Teigha.DatabaseServices
#End If
Imports BazDwg
Public Class ParamImageGeo
    Public Const HtxtGeo As Double = 4.0
    ''' <summary>
    ''' слой в которой нарисована скважин
    ''' </summary>
    ''' <remarks></remarks>
    Public Const LayerSkwaj As String = "ГЕО_Скважина"
    ''' <summary>
    ''' Слои ИгЭ штриховки
    ''' </summary>
    ''' <remarks></remarks>
    Public Const LayerIGE As String = "ГЕО_Штриховка"
    ''' <summary>
    ''' условные обозначения слоев игэ глубин отметок
    ''' </summary>
    ''' <remarks></remarks>
    Public Const LayerUslow As String = "ГЕО_Условные"
    Public Const LayerProba As String = "ГЕО_Проба"
    Public Const LayerOtmUGW As String = "ГЕО_ОтмУПВ"
    Public Const LayerConsistenz As String = "ГЕО_Консистенция"
    Public Const LayerGrunt As String = "ГЕО_Грунт"
    Public Const LayerStatZond As String = "ГЕО_Зондирование"
    Private wMaschtab As Integer
    Private wKoeffGeo As Double
    '  Dim ss = SkwajnaRealDwg.NameSlojDwgIGE
    Public NameSlojDwgSkwaj As String = LayerSkwaj
    Public NameSlojDwgIGE As String = LayerIGE
    Public NameSlojDwGUslownie As String = LayerUslow
    Public wNameSlojDwgUGrunWod As String = LayerOtmUGW
    Public wNameSlojDwgProba As String = LayerProba
    Const wNameZapis As String = "ParamImageGeo"
#Region "Property"
    Property Maschtab() As Integer
        Get
            Return wMaschtab
        End Get
        Set(ByVal value As Integer)
            wMaschtab = value
            wKoeffGeo = 1000.0 / wMaschtab
        End Set

    End Property
    ReadOnly Property KoeffGeo() As Double
        Get
            Return wKoeffGeo
        End Get


    End Property

#End Region
	Private Sub LeseParam()

		Dim SlParam As New dwgSlowar(LeseSreib.GlParam)
		Dim Danwh() As TypedValue
		Dim lKolwoParam As Integer
		Danwh = SlParam.ZapisIsSlowar(wNameZapis)
		If Danwh Is Nothing Then
			lKolwoParam = -1
		Else
			lKolwoParam = UBound(Danwh)
		End If
		Maschtab = 200

		If lKolwoParam >= 0 Then Maschtab = CInt(Danwh(0).Value)
		If lKolwoParam >= 1 Then NameSlojDwgIGE = CStr(Danwh(1).Value)
		If lKolwoParam >= 2 Then NameSlojDwgSkwaj = CStr(Danwh(2).Value)
		If lKolwoParam >= 3 Then NameSlojDwGUslownie = CStr(Danwh(3).Value)
		'If KolwoParam >= 9 Then wShirinaLista = CDbl(Danwh(9).Value)
	End Sub
	Sub SchreibeParam()
        Dim SlParam As New dwgSlowar(LeseSreib.GlParam)
        Dim Danr(3) As TypedValue
        'Danr(0) = New TypedValue(CInt(DxfCode.Text), wEndUch)
        'Danr(1) = New TypedValue(CInt(DxfCode.Text), wBegUch)
        'Danr(2) = New TypedValue(CInt(DxfCode.Text), wTipGraniz)
        Danr(0) = New TypedValue(CInt(DxfCode.Int32), wMaschtab)
        Danr(1) = New TypedValue(CInt(DxfCode.Text), NameSlojDwgIGE)
        Danr(2) = New TypedValue(CInt(DxfCode.Text), NameSlojDwgSkwaj)
        Danr(3) = New TypedValue(CInt(DxfCode.Text), NameSlojDwGUslownie)
        'Danr(7) = New TypedValue(CInt(DxfCode.Real), wBegOtm)
        'Danr(8) = New TypedValue(CInt(DxfCode.Real), wBegOtmI)
        'Danr(9) = New TypedValue(CInt(DxfCode.Real), wShirinaLista)
        SlParam.ZapisW_Slowar(wNameZapis, Danr)

    End Sub
    Public Sub New()
        LeseParam()

    End Sub
End Class
