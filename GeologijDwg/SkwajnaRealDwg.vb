Imports OperBD

#If ARX_APP Then
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.ApplicationServices
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

#End If

Imports BazDwg
Imports clsPrf

Imports LeseGeoIzDwg
Imports ProfilBaseDwg
#Const BezVer = 1


Public Class SkwajnaRealDwg
#If BezVer = 1 Then
    Public Const lKodver As String = ""
#Else
    Public Const lKodver As String = DwgParam.KodVer
#End If
    ''' <summary>
    ''' слой в которой нарисована скважин
    ''' </summary>
    ''' <remarks></remarks>
    Public Const NameSlojDwgSkwaj As String = lKodver & ParamImageGeo.LayerSkwaj
    ''' <summary>
    ''' Слои ИгЭ штриховки
    ''' </summary>
    ''' <remarks></remarks>
    Public Const NameSlojDwgIGE As String = lKodver & ParamImageGeo.LayerIGE
    ''' <summary>
    ''' условные обозначения слоев игэ глубин отметок
    ''' </summary>
    ''' <remarks></remarks>
    Public Const NameSlojDwGIndexIGE As String = lKodver & ParamImageGeo.LayerUslow
    Public Const NameSlojDwgUGW As String = lKodver & ParamImageGeo.LayerOtmUGW
    Public Const NameSlojDwgProb As String = lKodver & ParamImageGeo.LayerProba
    Public Const NameSlojDwgConsistenz As String = lKodver & ParamImageGeo.LayerConsistenz
    Public Const NameSlojDwgGrunt As String = lKodver & ParamImageGeo.LayerGrunt
    Public Const NameSlojDwgStatZond As String = lKodver & ParamImageGeo.LayerStatZond
    ' Private Const NameBlokArhiw As String = "архивная"
    Public Shared NumF As Globalization.NumberFormatInfo

    Private wNameSkwaj As String
    Private wTipSkwaj As modelGeo.TipSkwajn
    Private wRazrezDo As New List(Of GranizaSlojIgeRealDwg)
    Private wrazrezPosle As New List(Of GranizaSlojIgeRealDwg)
    Private wSpSlojwNaSkwajne As New List(Of GranizaSlojIgeRealDwg)
    Private wSpCons As New List(Of ConsistenzRealDwg)
    Private wSpProb As New List(Of ProbaPreobrRealDwg)
    Private wOtmetka, wRastOtnachala, wotmetkaNiza As Double
    Private wGlubinaUgw As Double
    Private wDataUgw As Date
    Private wPrProbUgw As Boolean
    Private wKoorRasstProfilaj, wKoorOtmProfilaj As clsKoor
    Private wKoorGeo As clsKoor  ' класс для преобразования координат отметок для гео элементов на оси скважины
    Private wGuid As Guid
    Private wParamType As LeseGeoIzDwg.ParamLine
    Private wTrassa As DwgTr
    Private wStringZondLob As String
#Region "konstruirowanie postroenie izmenenie"
    'Friend Shared Function NajtiSlojPoIge(iIndexIge As String, iSpisok As List(Of SlojIgeRealDwg)) As SlojIgeRealDwg
    '    For Each el As SlojIgeRealDwg In iSpisok
    '        If el.GetRazrezBeg.IndexIge = iIndexIge Then Return el
    '    Next
    '    Return Nothing
    'End Function

    Private Sub New(iTrassa As DwgTr)
        wTrassa = iTrassa
        wKoorRasstProfilaj = wTrassa.objGeom.KoorP
        wKoorOtmProfilaj = wTrassa.objGeom.KoorOtm


    End Sub
    ''' <summary>
    ''' Конструктор создающий объект связи образа скважины в чертеже и в моделе
    ''' </summary>
    ''' <param name="iTrassa"> трасса профиля  </param>
    ''' <param name="iSkwaj">  образ скважины по чертежу  </param>
    ''' <param name="iParamGeo"> парамеры представления геологие в чертеже  </param>
    ''' <remarks></remarks>
    Sub New(iTrassa As DwgTr, iSkwaj As LeseGeoIzDwg.ObrazSkwajn, iParamGeo As ParamImageGeo)
        Me.New(iTrassa)
        Dim lpointReal = SlojIgeRealDwg.PointProfilPoXdwg(iTrassa, iSkwaj.ZentrSkwajnDwg) 'отметку устья скважины в координатах профиля
        wRastOtnachala = lpointReal.X
        wOtmetka = lpointReal.Y
        wKoorGeo = New clsKoor(iParamGeo.Maschtab, wOtmetka, iSkwaj.YMax) ' объект длля преобразования координат в на скважине
        wotmetkaNiza = wKoorGeo.GetReal(iSkwaj.YMin)                       ' отметка низа(забоя) в координатах профиля   
        '    Dim wotmetkaNiza1 = wOtmetka - (iSkwaj.YMax - iSkwaj.YMin) / iParamGeo.KoeffGeo
        wGuid = wTrassa.UchTrassPoRastojnij(wRastOtnachala).UidUch

        Dim lSpslojwIgeBeg As New List(Of SlojIgeRealDwg)
        Dim lSpslojwIgeEnd As New List(Of SlojIgeRealDwg)




        wNameSkwaj = iSkwaj.NameSkwaj  '    получаем имя скважины считаное из чертежа

        ' получаем расположение скважины от начала профиля




        If iSkwaj.SlojBeg IsNot Nothing Then   ' расматриваем слои  для которых скважина в начале


            For Each elh As LeseGeoIzDwg.SlojIgeDwg In iSkwaj.SlojBeg
                Dim lrast As Double = wKoorRasstProfilaj.GetReal(elh.RastOtNachalaDWGEnd)
                Dim lotm As Double = iTrassa.GetOtmetka(lrast)
                lSpslojwIgeBeg.Add(New SlojIgeRealDwg(iTrassa, iParamGeo, elh, lpointReal))
                wrazrezPosle.Add(lSpslojwIgeBeg.Last.GetRazrezEnd)

            Next

        End If
        If iSkwaj.SlojEnd IsNot Nothing Then  ' расcматриваем слои для которых скважина в конце  
            For Each elh As LeseGeoIzDwg.SlojIgeDwg In iSkwaj.SlojEnd

                lSpslojwIgeEnd.Add(New SlojIgeRealDwg(iTrassa, iParamGeo, elh, Nothing, lpointReal))

                wRazrezDo.Add(lSpslojwIgeEnd.Last.GetRazrezBeg)

            Next
        Else

        End If
        wParamType = New LeseGeoIzDwg.ParamLine() ' Определяем по свойству примитива представляющую скважину ее тип Уточнить у геологов.iSkwaj.EntityObrazez
        wTipSkwaj = iSkwaj.TipSkwaj
        iSkwaj.OpredRazrezNaSkwajne()

        For Each el As RazrezSlojIgeDwg In iSkwaj.GetRazrezDwg
            Dim ell As New GranizaSlojIgeRealDwg(iTrassa, iParamGeo.Maschtab, el, Me.nameSkaj, lpointReal)
            wSpSlojwNaSkwajne.Add(ell)
        Next el

        ' Dim lwKolwo = 0

        Dim lSpGlubin = iSkwaj.GetGlubinReal()

        If lSpGlubin.Count - 1 = wSpSlojwNaSkwajne.Count Then
            Dim MaxNumGlub = lSpGlubin.Count - 2
            For I As Integer = 0 To MaxNumGlub
                Dim elg = lSpGlubin(MaxNumGlub - I)

                Dim lel = wSpSlojwNaSkwajne(I)

                lel.Glubina = elg



            Next I
        Else
            For I As Integer = 0 To lSpGlubin.Count - 2
                Dim elg = lSpGlubin(I)
                Dim elt = lSpGlubin(I + 1) - lSpGlubin(I)
                Dim rez As Double
                Dim lel = WibratBlijshee(elg, rez)
                If rez < 0.5 Then
                    lel.Glubina = elg
                Else
                    '  Dim linf = lSpGlubin.IndexOf(elg)

                    wSpSlojwNaSkwajne.Add(New GranizaSlojIgeRealDwg(iTrassa, wKoorGeo.Koeff, lpointReal, elg, modelGeo.TipOpred.IndexIgePoDefault, 1))
                End If
                '    lwKolwo += 1

            Next
        End If

        Dim lComp As New ComparatorGranizSlojIgeRealGlubin
        wSpSlojwNaSkwajne.Sort(lComp)    'сортируем слои под скважиной.
        If wTipSkwaj >= modelGeo.TipSkwajn.dlajKlin Then Return
        If lSpGlubin.Count > 0 Then
            Dim lGlSkwaj = lSpGlubin.Last
            If Math.Abs(lGlSkwaj - Glubina) < 1 Then
                wotmetkaNiza = wOtmetka - lGlSkwaj
            End If
        End If




        Try
            For Each el As LeseGeoIzDwg.ProbaDwg In iSkwaj.GetProb
                wSpProb.Add(New ProbaPreobrRealDwg(el, wOtmetka, wKoorGeo))
            Next
        Catch ex As Exception

        End Try

        wGlubinaUgw = iSkwaj.GlubinaUgw
        wDataUgw = iSkwaj.DataUgw
        wPrProbUgw = iSkwaj.PrProbUgw
        For Each el As clsHatch In iSkwaj.getConsistenz
            wSpCons.Add(New ConsistenzRealDwg(el, wOtmetka, wKoorGeo))
        Next
        'For Each el As GranizaSlojIgeRealDwg In wSpSlojwNaSkwajne
        '    el.UstanowitUrowen(Me)
        'Next
    End Sub
    Sub New(iTrassa As DwgTr, iRazrezDwg As List(Of LeseGeoIzDwg.RazrezSlojIgeDwg), iParamGeo As ParamImageGeo)
        Me.New(iTrassa)
        wRastOtnachala = wKoorRasstProfilaj.GetReal(iRazrezDwg(0).Xsloj)     ' получаем расположение скважины от начала профиля
        wGuid = wTrassa.UchTrassPoRastojnij(wRastOtnachala).UidUch
        wOtmetka = iTrassa.GetOtmetka(wRastOtnachala)              'отметку устья скважины в координатах профиля
        Dim lotmetkaDwg = wKoorOtmProfilaj.GetDwg(wOtmetka)
        wKoorGeo = New clsKoor(iParamGeo.Maschtab, wOtmetka, lotmetkaDwg) ' объект длля преобразования координат в на скважине
        wotmetkaNiza = wKoorGeo.GetReal(iRazrezDwg.Last.YnizDwg)                       ' отметка низа(забоя) в координатах профиля

        wNameSkwaj = "#" & CInt(wRastOtnachala)    '    задаем имя скваж
        wTipSkwaj = modelGeo.TipSkwajn.dlajKlin
        wParamType = New LeseGeoIzDwg.ParamLine() ' Определяем тип отрисовки скважин Уточнить у геологов.






        For Each el As RazrezSlojIgeDwg In iRazrezDwg    ' По слоям у которых скважина в начале опрделяем список слоев на скважине
            wSpSlojwNaSkwajne.Add(New GranizaSlojIgeRealDwg(iTrassa, iParamGeo.Maschtab, el, "", New PointReal(wRastOtnachala, wOtmetka)))

        Next




    End Sub
    Sub New(iTrassa As DwgTr, iRasst As Double, iParamGeo As ParamImageGeo)
        Me.New(iTrassa)
        wGuid = wTrassa.UchTrassPoRastojnij(iRasst).UidUch

        wNameSkwaj = "#" & CInt(iRasst)    '    задаем имя скваж
        wTipSkwaj = modelGeo.TipSkwajn.dlajKlin
        wParamType = New LeseGeoIzDwg.ParamLine() ' Определяем тип отрисовки скважин Уточнить у геологов.
        wRastOtnachala = iRasst    ' получаем расположение скважины от начала профиля
        wOtmetka = iTrassa.GetOtmetka(wRastOtnachala)              'отметку устья скважины в координатах профиля
        Dim lotmetkaDwg = wKoorOtmProfilaj.GetDwg(wOtmetka)
        wKoorGeo = New clsKoor(iParamGeo.Maschtab, wOtmetka, lotmetkaDwg) ' объект длля преобразования координат в на скважине
        wotmetkaNiza = wOtmetka - 10                     ' отметка низа(забоя) в координатах профиля




        ' По умолчанию создаем слои

        wSpSlojwNaSkwajne.Add(New GranizaSlojIgeRealDwg(iTrassa, wKoorGeo.Koeff, New PointReal(wRastOtnachala, wOtmetka), 0.3, modelGeo.TipOpred.IndexIgePoDefault, 1))





    End Sub
    ''' <summary>
    ''' Конструктор создающий объект связи модели скважины и ее образа скважины в чертеже 
    ''' </summary>
    ''' <param name="iTrassa">трасса профиля </param>
    ''' <param name="iSkwaj"> предсравление скважины в моделе  </param>
    ''' <param name="iParamGeo"></param>
    ''' <remarks></remarks>
    Sub New(iTrassa As DwgTr, iSkwaj As modelGeo.SkwajnaReal, iParamGeo As ParamImageGeo)
        Me.New(iTrassa)
		Try
			wGuid = iSkwaj.DataRowSkwaj.UIdUch
		Catch ex As Exception
			MsgBox(Me.ToString & " new " & iSkwaj.DataRowSkwaj.RowState)
		End Try


		wNameSkwaj = iSkwaj.DataRowSkwaj.NumName   ' передача параметров скважины
		If Not iSkwaj.DataRowSkwaj.IsGlubGruntWodNull() Then
			Try
				wDataUgw = iSkwaj.DataRowSkwaj.DataGlubGrunt
			Catch ex As Exception
				wDataUgw = Date.MinValue
			End Try

			wGlubinaUgw = iSkwaj.DataRowSkwaj.GlubGruntWod
		Else
			wGlubinaUgw = Double.NaN
            wDataUgw = Date.MinValue
        End If
        wPrProbUgw = iSkwaj.DataRowSkwaj.PrProbWod
        wRastOtnachala = iSkwaj.Rastojnie
        wOtmetka = iTrassa.GetOtmetka(wRastOtnachala)
        wotmetkaNiza = wOtmetka - iSkwaj.DataRowSkwaj.Glubina
        wKoorGeo = New clsKoor(iParamGeo.Maschtab, wOtmetka, wKoorOtmProfilaj.GetDwg(wOtmetka)) ' объект длля преобразования координат в на скважине
        wParamType = New LeseGeoIzDwg.ParamLine() ' тип линии которыми выводиться скважина
        wTipSkwaj = CType(iSkwaj.DataRowSkwaj.Tip, modelGeo.TipSkwajn)
        For Each el As DsGeologij.geoSloiIgeRow In iSkwaj.GetSpSlojwIge  '  формируем слои ИГЭ
			If el.RowState = DataRowState.Deleted OrElse el.RowState = DataRowState.Detached Then Continue For
			wSpSlojwNaSkwajne.Add(New GranizaSlojIgeRealDwg(iTrassa, iParamGeo.KoeffGeo, el, New PointReal(wRastOtnachala, wOtmetka), iSkwaj, 0))

        Next

        '    Dim lComp As New ComparatorGranizSlojIgeRealGlubin
        '  wSpSlojwNaSkwajne.Sort(lComp)   ' упорядочиваем п глубине наверное не нужно в моделе уже упорядочено
        For Each el As DsGeologij.geoMonolitRow In iSkwaj.GetSpProb  '    пробы монолиты
            wSpProb.Add(New ProbaPreobrRealDwg(el, wOtmetka, wKoorGeo))
        Next
        For Each el As DsGeologij.geoConsistenzRow In iSkwaj.GetSpConsistenz
            If el.RowState = DataRowState.Deleted Then Continue For
            wSpCons.Add(New ConsistenzRealDwg(el, wOtmetka, wKoorGeo))
        Next
        wStringZondLob = iSkwaj.DataRowSkwaj.ZondLob
    End Sub

    Private Function WibratBlijshee(iGlubinadwg As Double, ByRef wspMin As Double) As GranizaSlojIgeRealDwg
        wspMin = Glubina
        Dim elD As GranizaSlojIgeRealDwg = Nothing
        For Each el As GranizaSlojIgeRealDwg In wSpSlojwNaSkwajne
            Dim deltaGlub = el.Glubina - iGlubinadwg
            If Math.Abs(deltaGlub) < wspMin Then
                wspMin = Math.Abs(deltaGlub)
                elD = el
            End If



        Next
        Return elD
    End Function
    Sub DobawitRazrez(iSp As List(Of GranizaSlojIgeRealDwg))
        For Each el As GranizaSlojIgeRealDwg In iSp
            wSpSlojwNaSkwajne.Add(New GranizaSlojIgeRealDwg(wTrassa, wKoorGeo.Koeff, el.PointRealNaProfile, el.Glubina, el.IndexIge, el.Uroven))
        Next
    End Sub




    ''' <summary>
    ''' устанавливает новое расстояние от начала трассы
    ''' </summary>
    ''' <param name="iR"></param>
    ''' <remarks></remarks>
    Private Sub SetRastojnie(iR As Double)
        Dim lglubina = wOtmetka - wotmetkaNiza
        Dim lLinij As New GrebenProfilReal(wTrassa.GetLinijProfilReal)
        Dim point As PointReal = lLinij.GetPointLinii(iR)
        Dim lYdwg = wKoorOtmProfilaj.GetDwg(wOtmetka) 'координата скважины в чертеже
        Dim lydwgPosleIzm As Double = wKoorOtmProfilaj.GetDwg(point.Y)
        Dim lm = wKoorGeo.Maschtab

        wKoorGeo = New clsKoor(lm, point.Y, lydwgPosleIzm)

        wRastOtnachala = iR
        wOtmetka = point.Y
        wotmetkaNiza = wOtmetka - lglubina
        For Each el As GranizaSlojIgeRealDwg In wSpSlojwNaSkwajne
            el.SetRastojnie(Me)
        Next

    End Sub
#End Region
#Region "Get "
    ''' <summary>
    ''' Конец слоя который ннчинаеться на скважине
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function GetSloiIgePosle() As List(Of GranizaSlojIgeRealDwg)
        Return wrazrezPosle

    End Function
    ''' <summary>
    ''' начало слоя который заканчиваеться на скважине
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function GetSloiIgeDo() As List(Of GranizaSlojIgeRealDwg)
        Return wRazrezDo

    End Function
    Function GetSlojNaSkwajne() As List(Of GranizaSlojIgeRealDwg)
        Return wSpSlojwNaSkwajne

    End Function
    ''' <summary>
    ''' Все слои на скважине +  дно
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetWseGraniz() As List(Of GranizaSlojIgeRealDwg)
        If wSpSlojwNaSkwajne.Count > 0 Then
            Dim ls = wSpSlojwNaSkwajne.GetRange(0, wSpSlojwNaSkwajne.Count)
            Dim lSlojIgePosl = ls.Last
            ls.Add(New GranizaSlojIgeRealDwg(wTrassa, wKoorGeo.Koeff, New PointReal(wRastOtnachala, wOtmetka), Glubina, lSlojIgePosl.IndexIge, 0))
            Return ls
        Else
            Dim ls = New List(Of GranizaSlojIgeRealDwg)
            ls.Add(New GranizaSlojIgeRealDwg(wTrassa, wKoorGeo.Koeff, New PointReal(wRastOtnachala, wOtmetka), Glubina, modelGeo.TipOpred.IndexIgePoDefault, 0))
            Return ls
        End If

    End Function
    Function GetSled(iRazr As GranizaSlojIgeRealDwg) As GranizaSlojIgeRealDwg
        Dim lindex = wSpSlojwNaSkwajne.IndexOf(iRazr)
        If lindex < 0 Then Return Nothing
        If lindex = wSpSlojwNaSkwajne.Count - 1 Then

            Return New GranizaSlojIgeRealDwg(wTrassa, wKoorGeo.Koeff, New PointReal(wRastOtnachala, wOtmetka), Glubina, wSpSlojwNaSkwajne.Last.IndexIge, 0)  'modelGeo.TipOpred.IndexIgeDna
        Else
            Return wSpSlojwNaSkwajne(lindex + 1)
        End If
    End Function
    Function GetPred(iRazr As GranizaSlojIgeRealDwg) As GranizaSlojIgeRealDwg
        Dim lindex = wSpSlojwNaSkwajne.IndexOf(iRazr)
        If lindex < 0 Then Return Nothing
        If lindex = 0 Then
            Return New GranizaSlojIgeRealDwg(wTrassa, wKoorGeo.Koeff, New PointReal(wRastOtnachala, wOtmetka), 0, modelGeo.TipOpred.IndexIgePoDefault, 0)
        Else
            Return wSpSlojwNaSkwajne(lindex - 1)
        End If
    End Function
    Function GetKoorGeo() As clsKoor
        Return wKoorGeo
    End Function

    Function GetPoIgeSlojNaSkwajne(iIndIge As String) As GranizaSlojIgeRealDwg
        For Each el As GranizaSlojIgeRealDwg In wSpSlojwNaSkwajne
            If el.IndexIge = iIndIge Then Return el
        Next
        Return Nothing
    End Function

#End Region
#Region "read onlu"
    '  ReadOnly GlubinaUgw As Double 
    ReadOnly Property Rastojnie As Double
        Get
            Return wRastOtnachala
        End Get
    End Property
    ReadOnly Property Piketaj() As Double
        Get
            Return wTrassa.Piketaj(wRastOtnachala)
        End Get
    End Property
    ReadOnly Property Otmetka As Double
        Get
            Return wOtmetka
        End Get
    End Property
    ReadOnly Property nameSkaj As String
        Get
            Return wNameSkwaj
        End Get
    End Property
    ReadOnly Property OtmetkaNiza() As Double
        Get
            Return wotmetkaNiza
        End Get
    End Property
    ReadOnly Property Glubina As Double
        Get
            Return wOtmetka - OtmetkaNiza
        End Get
    End Property
    ReadOnly Property GlubinaPervogoSloj() As Double
        Get
            Try
                Return wSpSlojwNaSkwajne(0).Glubina
            Catch ex As Exception
                Return 0
            End Try

        End Get
    End Property
    ReadOnly Property Tip() As modelGeo.TipSkwajn
        Get
            Return wTipSkwaj
        End Get
    End Property
    ReadOnly Property PrProbUgw As Boolean
        Get
            Return wPrProbUgw
        End Get
    End Property

#End Region
    Function ustanowitDatarow(ds As DsGeologij) As DsGeologij.geoSkwajRow
        Dim l As DsGeologij.geoSkwajRow = ds.geoSkwaj.NewgeoSkwajRow   'записали скважину
        With l
            .UidSkwaj = Guid.NewGuid
            .NumName = wNameSkwaj
            .Glubina = wOtmetka - wotmetkaNiza
            .Piketaj = Piketaj
            .Tip = wTipSkwaj
            .UIdUch = wGuid
            .Rasst = wRastOtnachala
            If wGlubinaUgw = 0 Then
                .SetDataGlubGruntNull()
                .SetGlubGruntWodNull()
                .PrProbWod = False
            Else
                .DataGlubGrunt = wDataUgw
                .GlubGruntWod = wGlubinaUgw
                .PrProbWod = wPrProbUgw
            End If

        End With
        ds.geoSkwaj.AddgeoSkwajRow(l)
        'смотрим список Beg затем дополняем если есть отличные End.
        'For Each el As SlojIgeRealDwg In wSpslojwIgeBeg
        '    Dim lsl As modelGeo.dsGeologij.geoSloiIgeRow = ds.geoSloiIge.NewgeoSloiIgeRow
        '    With lsl
        '        lsl.UidSkwaj = l.UidSkwaj
        '        lsl.UidSloj = Guid.NewGuid
        '        .Glubina = el.OtmetkaPrf - el.WerhGraniza
        '        .IndexIGE = el.IndexIge
        '    End With
        '    ds.geoSloiIge.AddgeoSloiIgeRow(lsl)
        'Next
        For Each el As GranizaSlojIgeRealDwg In GetSlojNaSkwajne()     'записали слои ИГЭ на ней
            Dim lsl As DsGeologij.geoSloiIgeRow = ds.geoSloiIge.NewgeoSloiIgeRow
            With lsl
                lsl.UidSkwaj = l.UidSkwaj
                lsl.UidSloj = Guid.NewGuid
                .Glubina = el.Glubina
                .IndexIGE = el.IndexIge
                .Tolshina = el.Uroven
            End With
            ds.geoSloiIge.AddgeoSloiIgeRow(lsl)
        Next
        For Each el As ConsistenzRealDwg In wSpCons
            Dim lcons As DsGeologij.geoConsistenzRow = ds.geoConsistenz.NewgeoConsistenzRow
            With lcons
                .UidSkwaj = l.UidSkwaj
                .Consistenz = el.tip
                .Glubina = el.Glubina
            End With
            ds.geoConsistenz.AddgeoConsistenzRow(lcons)

        Next
        For Each el As ProbaPreobrRealDwg In wSpProb      'Записали пробы монолиты
            Dim lpr As DsGeologij.geoMonolitRow = ds.geoMonolit.NewgeoMonolitRow
            With lpr
                .UidSkwaj = l.UidSkwaj
                .IdTipMonolit = el.Tip
                .IdConsistenz = el.Consistezij
                .Glubina = el.Glubina
            End With
            ds.geoMonolit.AddgeoMonolitRow(lpr)
        Next
        Return l
    End Function
#Region "wiwod"

	'Public PutFileBlockGeo As String = ProfilBaseDwg.My.MojSettings.BasePapkaGlobal & "\DANN\blokiGeo.dwg"
	Shared Sub ProvBlock()
		Dim PutFileBlockGeo As String = ProfilBaseDwg.My.MySettings.Default.BasePapkaGlobal & "\DANN\blokiGeo.dwg"
		NumF = New Globalization.CultureInfo("en-US", False).NumberFormat
		NumF.NumberDecimalSeparator = "."
		For Each el As String In modelGeo.TipOpred.NameBlok
			If Not BazDwg.MakeEntities.EstLiBlock(el) Then
				BazDwg.operBlock.ImportBlockIzFile(PutFileBlockGeo)
				Return
			End If
		Next


		If Not BazDwg.MakeEntities.EstLiBlock(modelGeo.TipOpred.NameBlokArhiv) Then
			BazDwg.operBlock.ImportBlockIzFile(PutFileBlockGeo)
			Return
		End If

		If Not BazDwg.MakeEntities.EstLiBlock(modelGeo.TipOpred.NameBlockPochwa) Then
			BazDwg.operBlock.ImportBlockIzFile(PutFileBlockGeo)
			Return
		End If
		If Not BazDwg.MakeEntities.EstLiBlock(modelGeo.TipOpred.NameBlockOsiZond) Then
			BazDwg.operBlock.ImportBlockIzFile(PutFileBlockGeo)
			Return
		End If
		If Not BazDwg.MakeEntities.EstLiBlock(modelGeo.TipOpred.NameBlockTockaZond) Then
			BazDwg.operBlock.ImportBlockIzFile(PutFileBlockGeo)
			Return
		End If

	End Sub

	Private Sub WiwestiNaAbris(iNamesloj As String, iXskwajPoX As Double)

        Dim lPointWstawki As New Point3d(iXskwajPoX, wTrassa.objGeom.Podpis.PolGrafAbr, 0)
        Dim lpointwstawkiName As New Point3d(lPointWstawki.X + 1, lPointWstawki.Y - 5, 0)

        Dim lobjId As ObjectId = BazDwg.MakeEntities.CreateWstawkBlock(lPointWstawki, modelGeo.TipOpred.NameBlok(wTipSkwaj))

        Dim lNameMtext As MText = CType(dbPrim.CreateMText(lpointwstawkiName, NameSqwajnawiw, 10, 2.5), MText)
        lNameMtext.Layer = iNamesloj
        '  lNameMtext.ColorIndex = 10
        BazDwg.changeSloj(lobjId, iNamesloj)
        '   BazfunNet.changeColor(lobjId, 11)
        dbPrim.Wkl(lNameMtext)
    End Sub

    Function GetPointGlubinUGW() As Point2d
        If Not Double.IsNaN(wGlubinaUgw) Then
            Dim lyMeSkwaj = wKoorGeo.GetDwg(wOtmetka - wGlubinaUgw)
            Dim lXDwgBeg = wKoorRasstProfilaj.GetDwg(wRastOtnachala)
            Return New Point2d(lXDwgBeg, lyMeSkwaj)
        Else
            Return Point2d.Origin
        End If
    End Function
    Sub WiwestiMej(iSkwaj As SkwajnaRealDwg)
        If iSkwaj Is Nothing Then Return
        Dim lYdwg = wTrassa.objGeom.Podpis.PodpisKoor(1)
        Dim lYdwgWerh = wTrassa.objGeom.Podpis.PodpisKoor(2)
        Dim lXDwgBeg = wKoorRasstProfilaj.GetDwg(wRastOtnachala)
        Dim lXDwgEnd = wKoorRasstProfilaj.GetDwg(iSkwaj.wRastOtnachala)


        'If Not Double.IsNaN(wGlubinaUgw) And Not Double.IsNaN(iSkwaj.wGlubinaUgw) Then
        '    Dim lyMeSkwaj = wKoorGeo.GetDwg(wOtmetka - wGlubinaUgw)
        '    Dim lyIskwaj = iSkwaj.wKoorGeo.GetDwg(iSkwaj.wOtmetka - iSkwaj.wGlubinaUgw)
        '    Dim linUgw = BazfunNet.dbPrim.CreateLine(lXDwgBeg, lyMeSkwaj, lXDwgEnd, lyIskwaj)
        '    linUgw.Layer = NameSlojDwgUGW
        '    BazfunNet.dbPrim.Wkl(linUgw)
        'End If


        Dim ColDbOb As New DBObjectCollection
        ColDbOb.Add(BazDwg.dbPrim.CreateLine(lXDwgBeg, lYdwg, lXDwgBeg, lYdwgWerh))
        ColDbOb.Add(BazDwg.dbPrim.CreateLine(lXDwgEnd, lYdwg, lXDwgEnd, lYdwgWerh))
        Dim lDeltaDwg = lXDwgEnd - lXDwgBeg
        Dim lDelta = iSkwaj.wRastOtnachala - wRastOtnachala
        Dim lStrtexta = Format(lDelta, "f0")
        Dim lTextNadStrokoj = lYdwg + 3
        Dim lText As DBText = CType(BazDwg.dbPrim.CreateText(New Point3d(lXDwgBeg, lTextNadStrokoj, 0), lStrtexta, DwgTr.WisTextP), DBText)
        Dim lDlTexta = dbPrim.DlinaPoX(lText)
        If lDlTexta < lDeltaDwg Then
            lText.Position = New Point3d(lXDwgBeg + 0.5 * (lDeltaDwg - lDlTexta), lTextNadStrokoj, 0)
        Else
            lText.Justify = AttachmentPoint.BaseLeft
            Try
                lText.AlignmentPoint = New Point3d(lXDwgEnd, lTextNadStrokoj, 0)
            Catch ex As Exception

            End Try

        End If
        ColDbOb.Add(lText)
        For Each el As Entity In ColDbOb
            el.Layer = NameSlojDwgSkwaj
            '  el.ColorIndex = 4
        Next
        dbPrim.Wkl(ColDbOb)
    End Sub
    Sub WiwestiMetkuSkwajWdwg()
        Dim lWerhDwg As Double = wKoorGeo.GetDwg(wOtmetka)
        Dim lXdwg As Double = wKoorRasstProfilaj.GetDwg(wRastOtnachala)


        Dim lsp As New List(Of Entity)
        Dim lwst As Point3d = New Point3d(lXdwg, lWerhDwg, 0)               '
        Dim ltxt As Point3d = New Point3d(lXdwg + Okr, lWerhDwg + 12, 0) ' точка вставки текста названия скважины временно
        Dim elMlidname As MLeader = CType(dbPrim.CreateMLeader(ltxt, lwst, NameSqwajnawiw, 2.5), MLeader)
        elMlidname.Layer = DwgParam.LayerGeoWspomog
        lsp.Add(elMlidname)




        BazDwg.dbPrim.Wkl(lsp)

    End Sub
    Private Const otstupProb As Double = ObrazGeologii.OkrestnostObraz - 1
    Sub WiwestiSkwajWdwg()
        Dim lWerhDwg As Double = wKoorGeo.GetDwg(wOtmetka)
        Dim lXdwg As Double = wKoorRasstProfilaj.GetDwg(wRastOtnachala)
        Dim lnizOtmDwg As Double = wKoorGeo.GetDwg(wotmetkaNiza)

        Dim lsp As New List(Of Entity)
        Dim lwst As Point3d = New Point3d(lXdwg, lWerhDwg, 0)               '
        Dim ltxt As Point3d = New Point3d(lXdwg + Okr, lWerhDwg + 12, 0) ' точка вставки текста названия скважины временно
        Dim elMlidname As MLeader = CType(dbPrim.CreateMLeader(ltxt, lwst, NameSqwajnawiw, 2.5), MLeader)
        elMlidname.Layer = DwgParam.LayerGeoWspomog
        lsp.Add(elMlidname)

        If wTipSkwaj < modelGeo.TipSkwajn.dlajKlin Then   '1
            Dim collPoint As New Point2dCollection


            collPoint.Add(New Point2d(lXdwg - 1, lWerhDwg))
            collPoint.Add(New Point2d(lXdwg - 1, lnizOtmDwg))
            collPoint.Add(New Point2d(lXdwg + 1, lnizOtmDwg))
            collPoint.Add(New Point2d(lXdwg + 1, lWerhDwg))

            Dim lPolyLine As Entity = BazDwg.dbPrim.CreateLwPolyline(collPoint)
            lPolyLine.Layer = NameSlojDwgSkwaj

            If wParamType IsNot Nothing Then   '2
                With wParamType
                    lPolyLine.Linetype = .Linetype
                    lPolyLine.LinetypeScale = .LinetypeScale
                    lPolyLine.LineWeight = .LineWeight
                End With

            End If                 '2


            lsp.Add(lPolyLine)
            wiwestiOtmetkiSloew()
            WiwestiNaAbris(NameSlojDwGIndexIGE, lXdwg)

            Dim elcons As ConsistenzRealDwg = wSpCons.FirstOrDefault

            For i As Integer = 1 To wSpCons.Count - 1
                elcons.WiwestiWDwg(lXdwg, wKoorGeo, wSpCons(i).Glubina)
                elcons = wSpCons(i)
            Next
            If elcons IsNot Nothing Then elcons.WiwestiWDwg(lXdwg, wKoorGeo, Glubina)




            For Each el As ProbaPreobrRealDwg In wSpProb
                lsp.Add(el.WiwestiWDwg(lXdwg + otstupProb))
            Next
            '  Вывод УГВ
            If Not Double.IsNaN(wGlubinaUgw) Then   '2
                Dim lOtmetkaUGW As Double = wOtmetka - wGlubinaUgw
                Dim lOtmetkaUgwDwg As Double = wKoorGeo.GetDwg(lOtmetkaUGW)
                Dim lMtOtmUgw As MText = CType(BazDwg.dbPrim.CreateMText(New Point3d(lXdwg - 16, lOtmetkaUgwDwg + 1, 0), LeseGeoIzDwg.UgwDwgClass.TextOtmetok(lOtmetkaUGW, wDataUgw), 12, 2.0), MText)
                lMtOtmUgw.Layer = NameSlojDwgUGW
                lMtOtmUgw.BackgroundFill = True
                lMtOtmUgw.BackgroundScaleFactor = 1
                Dim lSdwigGlub As Double = 2.5
                If wPrProbUgw Then                          '3
                    Dim lZnUGW As Polyline = CType(Znaki.CreateKrug(lXdwg + lSdwigGlub, lOtmetkaUgwDwg - 1, 1), Polyline)
                    lSdwigGlub += 2
                    lZnUGW.Layer = NameSlojDwgUGW
                    lsp.Add(lZnUGW)
                End If        '3

                Dim lMtGlubUgw As MText = CType(BazDwg.dbPrim.CreateMText(New Point3d(lXdwg + lSdwigGlub, lOtmetkaUgwDwg + 1, 0), Format(wGlubinaUgw, "f2"), 6, 2.0), MText)
                lMtGlubUgw.Layer = NameSlojDwgUGW
                lMtGlubUgw.BackgroundFill = True
                lMtGlubUgw.BackgroundScaleFactor = 1
                lsp.Add(lMtGlubUgw)
                lsp.Add(lMtOtmUgw)
            End If   '2



        End If    '1



        BazDwg.dbPrim.Wkl(lsp)
        Dim lwsp As New modelGeo.StatZond(wStringZondLob)
        WiwestiGrafik(lwsp.GetGrafik)
    End Sub
    Shared Function NameSqwajnawiw(iname As String, iOtmetka As Double) As String
        Dim s1 = "{\Lскв."
        Dim S2 = "\P}"
        Return s1 & iname & S2 & Format(iOtmetka, "f2")


    End Function
    Private Function NameSqwajnawiw() As String
        Dim s1 = "{\Lскв."
        Dim S2 = "\P}"
        Return s1 & wNameSkwaj & S2 & Format(wOtmetka, "f2")


    End Function
    Private Function NameTochkiZond() As String
        Dim s1 = "{\Lс.з."

        Return s1 & wNameSkwaj


    End Function
    Private Sub OformStatZond(izentrX As Double, izentrY As Double)
        Dim lPointWstawki As New Point3d(izentrX + 5, wTrassa.objGeom.Podpis.PolGrafAbr, 0)
        Dim lpointwstawkiName As New Point3d(lPointWstawki.X + 1, lPointWstawki.Y + 5, 0)
        Dim lobjectIdCol As New ObjectIdCollection
        Dim lPointWstawkiOsi As New Point3d(izentrX, izentrY, 0)
        lobjectIdCol.Add(BazDwg.MakeEntities.CreateWstawkBlock(lPointWstawkiOsi, modelGeo.TipOpred.NameBlockOsiZond))
        lobjectIdCol.Add(BazDwg.MakeEntities.CreateWstawkBlock(lPointWstawki, modelGeo.TipOpred.NameBlockTockaZond))
        lobjectIdCol.Add(BazDwg.dwgText.CreateMText(lpointwstawkiName, NameTochkiZond, 10, 2.5))
        BazDwg.changeSloj(lobjectIdCol, NameSlojDwgStatZond)
    End Sub
    Sub WiwestiGrafik(iSp As List(Of Double()))

        If iSp Is Nothing Then Return
        Dim lmaschtabX = 2.0
        Dim spPolyLineGr As New List(Of Point2dCollection)
        Dim lZentrX As Double = wKoorRasstProfilaj.GetDwg(wRastOtnachala) + 1 'положение центра скважины в чертеже по X
        Dim lZentrY As Double = wKoorOtmProfilaj.GetDwg(wOtmetka)
        Dim predGug As Double = 0.0
        Dim lcol As Point2dCollection = Nothing
        For Each el As Double() In iSp
            If predGug = 0 And el(1) > 0 Then
                lcol = New Point2dCollection
                lcol.Add(New Point2d(lZentrX + lmaschtabX * el(1), lZentrY - Me.wKoorGeo.Koeff * el(0)))
                predGug = el(1)
                Continue For
            End If
            If predGug > 0 And el(1) = 0 Then
                spPolyLineGr.Add(lcol)
                predGug = el(1)
                Continue For
            End If
            If predGug = 0 And el(1) = 0 Then

                predGug = el(1)
                Continue For
            End If
            lcol.Add(New Point2d(lZentrX + lmaschtabX * el(1), lZentrY - Me.wKoorGeo.Koeff * el(0)))
            predGug = el(1)
        Next
        If predGug > 0 Then spPolyLineGr.Add(lcol)
        OformStatZond(lZentrX, lZentrY)
        Dim CollPrim As New DBObjectCollection
        For Each elp As Point2dCollection In spPolyLineGr
            Dim ldb = dbPrim.CreateLwPolyline(elp)
            ldb.Layer = NameSlojDwgStatZond
            CollPrim.Add(ldb)
        Next
        dbPrim.Wkl(CollPrim)
    End Sub
    Const Okr As Double = ObrazGeologii_Bas.PolushirinaSdopusk
    Const Strelka As Double = 0.0
    Const hWisTxt As Double = 2.5
    '  Dim lniz As Double = wKoorGeo.GetDwg(iotmSloj)
    Private Sub WiwestiOtmGlub(lniz As Double, lgrDo As Double, lgrPosle As Double, _
                               iOtm As Double, iGlub As Double, coll As DBObjectCollection)


        Dim lwst = New Point3d(lgrDo, lniz, 0)
        Dim ltxt = New Point3d(lgrDo - Okr, lniz, 0)  '+ lPoluHtxt
        Dim lwstGl = New Point3d(lgrPosle, lniz, 0)
        Dim ltxtGl = New Point3d(lgrPosle + Okr, lniz, 0)   '+ lPoluHtxt
        Dim strOtmNiza = Format(iOtm, "f2")
        Dim strGlubin = Format(iGlub, "f1")

        Dim lMlidOtmNiza As MLeader = CType(dbPrim.CreateMLeader(ltxt, lwst, strOtmNiza, hWisTxt), MLeader)
        With lMlidOtmNiza
            .DoglegLength = 0 'полка 
            .LandingGap = 0 '      отступ полка 
            .Layer = SkwajnaRealDwg.NameSlojDwGIndexIGE
            .ArrowSize = Strelka
            .TextAlignmentType = TextAlignmentType.RightAlignment
            .TextLocation = ltxt
            .SetTextAttachmentType(TextAttachmentType.AttachmentMiddle, LeaderDirectionType.LeftLeader)
            .SetTextAttachmentType(TextAttachmentType.AttachmentMiddle, LeaderDirectionType.RightLeader)
            '     .GeometricExtents.
            .MoveMLeader(-ObrazGeologii_Bas.OkoloSkwajnDwg * Vector3d.XAxis, MoveType.MoveContentAndDoglegPoints)
            '  .MText.BackgroundScaleFactor = 1
        End With
        Dim lMlidGlubin As MLeader = CType(dbPrim.CreateMLeader(ltxtGl, lwstGl, strGlubin, hWisTxt), MLeader)
        With lMlidGlubin
            .DoglegLength = 0 'полка 
            .LandingGap = 0 '      отступ полка 
            .Layer = lMlidOtmNiza.Layer
            .ArrowSize = Strelka
            .TextAlignmentType = TextAlignmentType.LeftAlignment
            .TextLocation = ltxtGl
            '    .TextAttachmentType = TextAttachmentType.AttachmentMiddle
            .SetTextAttachmentType(TextAttachmentType.AttachmentMiddle, LeaderDirectionType.LeftLeader)
            .SetTextAttachmentType(TextAttachmentType.AttachmentMiddle, LeaderDirectionType.RightLeader)
            '   .MText.BackgroundScaleFactor = 1
            .MoveMLeader(0.1 * Vector3d.XAxis, MoveType.MoveContentAndDoglegPoints)
        End With





        coll.Add(lMlidOtmNiza)
        coll.Add(lMlidGlubin)
    End Sub
    Private Sub wiwestiOtmetkiSloew()
        Dim inamelayer = SkwajnaRealDwg.NameSlojDwGIndexIGE
        Dim lHtxt As Double = 2.5
        Dim lPoluHtxt = 0.5 * lHtxt
        Dim coll As New DBObjectCollection '   коллекция для включения примитивов
        Dim lzentrX As Double = wKoorRasstProfilaj.GetDwg(wRastOtnachala)  'положение центра скважины в чертеже по X
        Dim lyust As Double = wKoorOtmProfilaj.GetDwg(wOtmetka)                        ' положение центра скважины по у


        Dim lgrDo = lzentrX - 1      'Границы скважины
        Dim lgrPosle = lzentrX + 1
        Dim elPred As GranizaSlojIgeRealDwg = Nothing
        For Each el As GranizaSlojIgeRealDwg In wSpSlojwNaSkwajne
            Dim lTolshina = 1.0
            If elPred IsNot Nothing Then lTolshina = el.Glubina - elPred.Glubina
            If lTolshina < ObrazGeologii.DopuskGeoDwgX Then Continue For
            WiwestiOtmGlub(lyust - el.Glubina * wKoorGeo.Koeff, lgrDo, lgrPosle, el.Otmetka, el.Glubina, coll)

            elPred = el
        Next
        'Выводим отметки и глубины дна скважины
        WiwestiOtmGlub(wKoorGeo.GetDwg(wotmetkaNiza), lgrDo, lgrPosle, wotmetkaNiza, Glubina, coll)

        dbPrim.Wkl(coll)

    End Sub
    'Private Sub wiwOtmGlub(iZentrPoX, iZentrPoy)
    '    Dim lpointWstawkiDo As New Point3d(lgrDo, lyust - el.Glubina * wKoorGeo.Koeff, 0)   ' точка границы слоя+ lPoluHtxt
    '    Dim lpointWstawkiposle As New Point3d(lgrPosle, lpointWstawkiDo.Y, 0)   ' точка границы слоя
    '    Dim lpointtext As New Point3d(lgrDo - Okr, lpointWstawkiDo.Y + lHtxt, 0)
    '    Dim lpointtextGl As New Point3d(lgrPosle + Okr, lpointWstawkiDo.Y + lHtxt, 0) ' точка вставки текста глубин 



    '    Dim lStrTexta = Format(el.Otmetka, "f2")
    '    Dim lStrTextaGlub = Format(el.Glubina, "f1")

    '    Dim elMlidGl As MLeader = CType(dbPrim.CreateMLeader(lpointtextGl, lpointWstawkiposle, lStrTextaGlub, lHtxt), MLeader)
    '    With elMlidGl
    '        .Layer = inamelayer
    '        .ArrowSize = Strelka

    '    End With






    '    Dim elMlidOtm As MLeader = CType(dbPrim.CreateMLeader(lpointtext, lpointWstawkiDo, lStrTexta, lHtxt), MLeader)
    '    With elMlidOtm
    '        .Layer = inamelayer
    '        .ArrowSize = Strelka

    '        '    .TextAttachmentDirection = TextAttachmentDirection.AttachmentHorizontal
    '        .TextAlignmentType = TextAlignmentType.RightAlignment

    '        ' .TextAttachmentType = TextAttachmentType.AttachmentBottomOfBottom


    '        'Dim wP As Point3d = .TextLocation
    '        'Dim l = .MText.ActualHeight
    '        '    .TextLocation = New Point3d(lgrDo - l, lpointtext.Y, 0)

    '        '      .MoveMLeader(-l * Vector3d.XAxis, MoveType.MoveContentAndDoglegPoints)

    '    End With


    '    coll.Add(elMlidOtm)
    '    coll.Add(elMlidGl)
    'End Sub
#End Region



End Class
