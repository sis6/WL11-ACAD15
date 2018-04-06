Imports OperBD

#If ARX_APP Then
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.ApplicationServices
#Else
Imports Teigha.Geometry
Imports Teigha.DatabaseServices
Imports Bricscad.ApplicationServices
#End If



Imports clsPrf
Imports BazDwg
Imports ProfilBaseDwg

''' <summary>
''' Сортировка в порядке возрастания глубин
''' </summary>
''' <remarks></remarks>
Public Class ComparatorGranizSlojIgeRealGlubin
    '
    Implements IComparer(Of GranizaSlojIgeRealDwg)

    Public Function Compare(ByVal x As GranizaSlojIgeRealDwg, ByVal y As GranizaSlojIgeRealDwg) As Integer Implements System.Collections.Generic.IComparer(Of GranizaSlojIgeRealDwg).Compare



        If Math.Abs(x.Glubina - y.Glubina) < 0.01 Then Return 0
        If x.Glubina > y.Glubina Then
            Return 1
        Else
            Return -1
        End If





    End Function

    Shared Sub SearchAndInsert( _
ByVal lis As List(Of GranizaSlojIgeRealDwg), _
ByVal insert As GranizaSlojIgeRealDwg, ByVal dc As IComparer(Of GranizaSlojIgeRealDwg))



        Dim index As Integer = lis.BinarySearch(insert, dc)

        If index < 0 Then
            index = index Xor -1
            lis.Insert(index, insert)
        End If
    End Sub
End Class
Public Class ComparatorGranizSlojIgeRealRasstojnie
    '
    Implements IComparer(Of GranizaSlojIgeRealDwg)

    Public Function Compare(ByVal x As GranizaSlojIgeRealDwg, ByVal y As GranizaSlojIgeRealDwg) As Integer Implements System.Collections.Generic.IComparer(Of GranizaSlojIgeRealDwg).Compare



        If Math.Abs(x.Rastojnie - y.Rastojnie) < modelGeo.TipOpred.MinTolschina Then Return 0
        If x.Rastojnie > y.Rastojnie Then
            Return 1
        Else
            Return -1
        End If





    End Function

    Shared Sub SearchAndInsert( _
ByVal lis As List(Of GranizaSlojIgeRealDwg), _
ByVal insert As GranizaSlojIgeRealDwg, ByVal dc As IComparer(Of GranizaSlojIgeRealDwg))



        Dim index As Integer = lis.BinarySearch(insert, dc)

        If index < 0 Then
            index = index Xor -1
            lis.Insert(index, insert)
        End If
    End Sub
End Class

Public Class Granizasloj
    Private wOtmetkaProf, wRastOtnachala, wGlubina As Double
    Private wTrassa As DwgTr
    Sub New(itrassa As DwgTr, itochka As PointReal, iGlubina As Double)
        wTrassa = itrassa
        wRastOtnachala = itochka.X
        wOtmetkaProf = itochka.Y
        wGlubina = iGlubina

    End Sub

End Class
''' <summary>
''' класс по параметрам определенным в чертеже определяет параметры слоя в реальных координатах
''' </summary>
''' <remarks> может быть ассоциирован с каким ли бо объекьтом подкоторым находиться </remarks>
Public Class GranizaSlojIgeRealDwg

    Private wIndexIge As String
    Private wOtmetkaProf, wRastOtnachala, wGlubina As Double
    Private wNameObjekt As String ' объект под которым расположен слой
    Private wTrassa As DwgTr
    Private wLinijProfilDwg As BazDwg.GrebenProfilDwg
    Private wKoeffGeo As Double
    Private wPrWiwodaZhakaIge As Boolean
    Private wNumGlobKontur As Integer
#Region "Конструирование и преобразование"
    ''' <summary>
    ''' Построение границы слоя в произвольной точки при заданой глубине
    ''' </summary>
    ''' <param name="itrassa"> трасса представленая в чертеже </param>
    ''' <param name="iKoeffGeo"> коеффициэнт Гео  </param>
    ''' <param name="iPointProfReal"> точка профиля  </param>
    ''' <param name="iGlubina"> глубина  </param>
    ''' <param name="iIndexIge"> индекс Игэ </param>
    ''' <remarks></remarks>
    Sub New(itrassa As DwgTr, iKoeffGeo As Double, iPointProfReal As PointReal, iGlubina As Double, iIndexIge As String, itolshina As Double)
        wTrassa = itrassa
        wLinijProfilDwg = wTrassa.GetLinijDwg
        wRastOtnachala = iPointProfReal.X
        wOtmetkaProf = iPointProfReal.Y
        wGlubina = iGlubina
        wIndexIge = iIndexIge
        wNameObjekt = "#" & CInt(wRastOtnachala)
        wPrWiwodaZhakaIge = False
        wKoeffGeo = iKoeffGeo
        If itolshina < modelGeo.TipOpred.MinTolschina Then
            wNumGlobKontur = 0
        Else
            wNumGlobKontur = CInt(itolshina)
        End If

    End Sub
    ''' <summary>
    ''' конструктор для преобразования разреза слоя из чертежа 
    ''' </summary>
    ''' <param name="itrassa" > профиль трассы представленый в черт еже </param>
    ''' <param name="iMaschtabgeo">  параметры отображения геологии в чертеже  </param>
    ''' <param name="IGrDwg"> разрез слоя в чертеже  </param>
    ''' <param name="iNameObjekt"> имя объекта (опора скважина просто точка на профиле) под которым делаеться разрез  </param>
    ''' <param name="iPointProfReal"> реальные координаты точки профиля под которым определяеться разрез  </param>
    ''' <remarks></remarks>
    Sub New(itrassa As DwgTr, iMaschtabgeo As Integer, IGrDwg As LeseGeoIzDwg.RazrezSlojIgeDwg, iNameObjekt As String, iPointProfReal As clsPrf.PointReal)
        ' iIndexIge As String, iWerhOtmIgeDwg As Double, iTolshinaDwg As Double

        wTrassa = itrassa
        wLinijProfilDwg = wTrassa.GetLinijDwg
        wRastOtnachala = iPointProfReal.X
        wOtmetkaProf = iPointProfReal.Y
        Dim lkoorGeo = SlojIgeRealDwg.GetObjektKoor(iMaschtabgeo, iPointProfReal.Y, itrassa)
        wKoeffGeo = lkoorGeo.Koeff
        wGlubina = wOtmetkaProf - lkoorGeo.GetReal(IGrDwg.YwerhDwg)
        'If IGrDwg.TolshinaDwg < LeseGeoIzDwg.ObrazGeologii.MinTolshinaDwg Then
        '    wTolshina = 0
        'Else
        '    wTolshina = 1
        'End If
        wNumGlobKontur = IGrDwg.NumGlobalSloj
        wIndexIge = IGrDwg.IndexIge



        If String.IsNullOrEmpty(iNameObjekt) Then
            wNameObjekt = "#R " & CInt(iPointProfReal.X)
            wPrWiwodaZhakaIge = False
        Else
            wNameObjekt = iNameObjekt
            wPrWiwodaZhakaIge = True
        End If






    End Sub
    ''Проверяет на наличия нескольких слоев и в соответствие с 
    ' ''' <summary>
    ' ''' Проверяет на наличия нескольких слоев с одинаковыми ИГЕ и в порядке возрастания увеличивает на 1 слои с нулевой толщиной обходит. 
    ' ''' </summary>
    ' ''' <param name="iSkwaj"> скважина для которой имееи список упорядоченных слоев. </param>
    ' ''' <remarks></remarks>
    'Sub UstanowitUrowen(iSkwaj As SkwajnaRealDwg)
    '    If wTolshina = 0 Then Return
    '    'For Each el As GranizaSlojIgeRealDwg In iSkwaj.GetSlojNaSkwajne

    '    '    If el.Glubina < wGlubina And el.IndexIge.Equals(IndexIge) Then
    '    '        wTolshina = el.Uroven + 1
    '    '    End If
    '    'Next
    'End Sub
    'Sub New(iparamgeo As ParamImageGeo, iparamhatch As LeseGeoIzDwg.ParamHatch, iWerhOtmIgeDwg As Double, iKoorOtm As clsKoor, iPointProfReal As clsPrf.PointReal, itrassa As clsTrass)

    '    wTrassa = itrassa
    '    wIndexIge = iparamhatch.StrOpis

    '    Dim ikoorgeo As clsKoor = GetObjektKoor(iparamgeo, iPointProfReal.Y, iKoorOtm)



    '    wNameObjekt = "#R " & CInt(iPointProfReal.X)

    '    wRastOtnachala = iPointProfReal.X
    '    wOtmetkaProf = iPointProfReal.Y

    '    wGlubina = wOtmetkaProf - ikoorgeo.GetReal(iWerhOtmIgeDwg)

    'End Sub
    ''' <summary>
    ''' Конструктор для построения объекта по данным ДатаСет Геология 
    ''' </summary>
    ''' <param name="itrassa"> траса профиля в    </param>
    ''' <param name="idr"> данные по слою из  ДатаСет Геология  </param>
    ''' <param name="iPointProfReal">  точка профиля под которой строиться слой  </param>
    ''' <param name="iNameObjekt"></param>
    ''' <remarks></remarks>
    Sub New(itrassa As DwgTr, iKoeffgeo As Double, idr As DsGeologij.geoSloiIgeRow, iPointProfReal As PointReal, iNameObjekt As modelGeo.SkwajnaReal, iParam As Double)
        wTrassa = itrassa
        wLinijProfilDwg = wTrassa.GetLinijDwg
        wOtmetkaProf = iPointProfReal.Y
        wRastOtnachala = iPointProfReal.X
        wGlubina = idr.Glubina
        wNumGlobKontur = CInt(idr.Tolshina)
        wKoeffGeo = iKoeffgeo
        wIndexIge = idr.IndexIGE
        If iNameObjekt Is Nothing Then
            wNameObjekt = "#R " & CInt(iPointProfReal.X)
            wPrWiwodaZhakaIge = False
        Else
            wNameObjekt = iNameObjekt.DataRowSkwaj.NumName
            If iNameObjekt.DataRowSkwaj.Tip = modelGeo.TipSkwajn.dlajKlin OrElse iNameObjekt.DataRowSkwaj.Tip = modelGeo.TipSkwajn.Uslow Then
                wPrWiwodaZhakaIge = False
            Else
                wPrWiwodaZhakaIge = True
            End If
        End If


    End Sub
    Private Sub SetRastojnie(iR As Double)
        Dim lLinij As New GrebenProfilReal(wTrassa.GetLinijProfilReal)
        Dim point As PointReal = lLinij.GetPointLinii(iR)
        wRastOtnachala = iR
        wOtmetkaProf = point.Y
    End Sub
    Sub SetRastojnie(iSkwaj As SkwajnaRealDwg)

        wRastOtnachala = iSkwaj.Rastojnie
        wOtmetkaProf = iSkwaj.Otmetka
    End Sub
#End Region
#Region "ReadOnlu"
    ReadOnly Property NameObjekt() As String
        Get
            Return wNameObjekt
        End Get
    End Property
    ''' <summary>
    ''' Отметка верхней границы слоя реальная
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Otmetka As Double
        Get
            Return wOtmetkaProf - wGlubina
        End Get

    End Property
    Property Glubina As Double
        Get
            Return wGlubina '+ 0.001 * wNumGlobKontur
        End Get

        Set(value As Double)

            wGlubina = value
        End Set
    End Property
    ReadOnly Property Uroven As Integer
        Get
            Return wNumGlobKontur
        End Get
    End Property
    ReadOnly Property OtmetkaPrf As Double
        Get
            Return wOtmetkaProf
        End Get
    End Property
    ReadOnly Property Rastojnie As Double
        Get
            Return wRastOtnachala
        End Get
    End Property
    ReadOnly Property IndexIge As String
        Get
            Return wIndexIge
        End Get
    End Property
    ReadOnly Property Piketaj() As Double
        Get
            Return wTrassa.Piketaj(wRastOtnachala)
        End Get
    End Property
    ReadOnly Property PointRealNaProfile As PointReal
        Get
            Return New PointReal(wRastOtnachala, wOtmetkaProf)
        End Get
    End Property
    ReadOnly Property KoeffGeo As Double
        Get
            Return wKoeffGeo
        End Get
    End Property
    ReadOnly Property PointPrfDwg As Point2d
        Get
            Dim lKoorRasst = wTrassa.objGeom.KoorP
            Return wLinijProfilDwg.GetPointLinii(lKoorRasst.GetDwg(wRastOtnachala))

        End Get
    End Property
    ReadOnly Property PointGrDwg As Point2d
        Get
            Dim lp = PointPrfDwg
            Return New Point2d(lp.X, lp.Y - wGlubina * wKoeffGeo)
        End Get
    End Property
    ReadOnly Property LinijPrfDwg() As GrebenProfilDwg
        Get
            Return wLinijProfilDwg
        End Get
    End Property
    Function EqualsIgeUrow(Isloj As GranizaSlojIgeRealDwg) As Boolean
        Dim l As Integer = Math.Abs(wNumGlobKontur)
        Dim ll As Integer = Math.Abs(Isloj.wNumGlobKontur)
        Return wIndexIge.Equals(Isloj.wIndexIge) AndAlso l.Equals(ll)
    End Function
    Function EqualsIge(Isloj As GranizaSlojIgeRealDwg) As Boolean

        Return wIndexIge.Equals(Isloj.wIndexIge)
    End Function
#End Region



#Region "Вроде бы не нужное"
    'Private Shared Function WiwWDwgPoParamHatch(iNameLayer As String, iColl As Point2dCollection, wdr As modelGeo.dsGeologij.geoParamIgeRow, _
    '                            Optional iprlayer As Boolean = True) As Hatch
    '    Dim wParamHatch = New BazfunNet.ParamHatch(wdr.PatternName, wdr.PatternScale, wdr.PatternAngle, CType(wdr.wLineWeight, LineWeight))
    '    Dim lnameSl As String = iNameLayer
    '    If iprlayer = False Then lnameSl = DwgParam.LayerGeoWspomog
    '    Return ParamHatch.CreatehatchPoParamHatch(iNameLayer, iColl, wParamHatch, , , lnameSl)
    'End Function
    '  Private Sub PerepisatHatch(iNameLayer As String, iRazrEnd As GranizaSlojIgeRealDwg, iGlubina As Double, iglubinaEnd As Double _
    '                  , iPereschet As BazfunNet.GrebenProfilDwg, Iparam As modelGeo.dsGeologij.geoParamIgeRow)



    '    Dim lkontur As Point2dCollection = KonturDlaHatch(iRazrEnd, iGlubina, iglubinaEnd, iPereschet)
    '    Dim lhatch As Hatch = GranizaSlojIgeRealDwg.WiwWDwgPoParamHatch(iNameLayer, lkontur, Iparam)




    'End Sub
    ' ''' <summary>
    ' ''' Выводит отметки иге(индекс , возраст) в область ИГЭ
    ' ''' </summary>
    ' ''' <param name="irazrezEnd"> разрез конечной скважины </param>
    ' ''' <param name="iGlubina"> глубина следующего разреза в начале   </param>
    ' ''' <param name="iglubinaEnd"> глубина следующего разреза вконце в конце</param>
    ' ''' <remarks></remarks>
    'Private Sub WiwestiNameWozrastIge(irazrezEnd As GranizaSlojIgeRealDwg, _
    '                iGlubina As Double, iglubinaEnd As Double, iParam As LeseGeoIzDwg.ParamIge)
    '    Dim iKoorRasst As clsKoor = wTrassa.objGeom.KoorP
    '    Dim ikoorOtm As clsKoor = wTrassa.objGeom.KoorOtm


    '    Dim lpoint3dBeg = New Point3d(iKoorRasst.GetDwg(Rastojnie), ikoorOtm.GetDwg(OtmetkaPrf) - wKoeffGeo * Glubina, 0)  'нашли начальную  граничную точку
    '    Dim lpoint3dend = New Point3d(iKoorRasst.GetDwg(irazrezEnd.Rastojnie), ikoorOtm.GetDwg(irazrezEnd.OtmetkaPrf) - wKoeffGeo * irazrezEnd.Glubina, 0)
    '    Dim lNizpoint3dBeg = New Point3d(iKoorRasst.GetDwg(Rastojnie), ikoorOtm.GetDwg(OtmetkaPrf) - wKoeffGeo * iGlubina, 0)
    '    Dim lNizpoint3dend = New Point3d(iKoorRasst.GetDwg(irazrezEnd.Rastojnie), ikoorOtm.GetDwg(irazrezEnd.OtmetkaPrf) - wKoeffGeo * iglubinaEnd, 0)
    '    Dim lWerhpointSer = 0.5 * Slojit(lpoint3dBeg, lpoint3dend)
    '    Dim lnizpointSer = 0.5 * Slojit(lNizpoint3dBeg, lNizpoint3dend)
    '    Dim lpointSer = 0.5 * Slojit(lWerhpointSer, lnizpointSer)
    '    Dim collDb As New DBObjectCollection
    '    'Выводим номер Иге
    '    Dim jCircle As Circle = CType(BazfunNet.dbPrim.CreateCircle(lpointSer.X + 1, lpointSer.Y - 1.25, 2), Circle)
    '    Dim jent As MText = CType(BazfunNet.dbPrim.CreateMText(lpointSer, IndexIge, 3, 2.5), MText)
    '    jCircle.Layer = SkwajnaRealDwg.NameSlojDwGIndexIGE
    '    jent.Layer = SkwajnaRealDwg.NameSlojDwGIndexIGE
    '    jent.BackgroundFill = True
    '    collDb.Add(jent)
    '    collDb.Add(jCircle)

    '    Dim lwozrastMtext As MText = CType(BazfunNet.dbPrim.CreateMText(New Point3d(lpointSer.X - 1, lpointSer.Y - 4, 0), iParam.Wozrast, 3, 2.5), MText)
    '    lwozrastMtext.BackgroundFill = True
    '    lwozrastMtext.Layer = SkwajnaRealDwg.NameSlojDwGIndexIGE
    '    collDb.Add(lwozrastMtext)

    '    BazfunNet.dbPrim.Wkl(collDb)

    'End Sub
#End Region

#Region "Построения"
    ''' <summary>
    ''' по списку границ и списку глубин возвращает нижнею и верхнею границу профиля в координатах чертежа.
    ''' </summary>
    ''' <param name="ispGraniz"> список границ </param>
    ''' <param name="iSpGlubin"> список глубин </param>
    ''' <returns> возвращает два списка 0 точки верхнего  слоя 1- точки нижнего слоя </returns>
    ''' <remarks>  список глубин должен быть в той же точке что и разрез  </remarks>
    Shared Function LinijGraniz(ispGraniz As List(Of GranizaSlojIgeRealDwg), iSpGlubin As List(Of Double)) As List(Of Point2d)()
        Dim lLin(1) As List(Of Point2d)
        Dim lKoorRasst = ispGraniz(0).wTrassa.objGeom.KoorP
        Dim lGrDwg = ispGraniz(0).LinijPrfDwg
        Dim lkoeff = ispGraniz(0).wKoeffGeo
        lLin(0) = New List(Of Point2d)
        lLin(1) = New List(Of Point2d)

        Dim lComp As New BazDwg.ComparatorPoint2dPoX
        For i As Integer = 0 To ispGraniz.Count - 2
            Dim lUchLin As List(Of Point2d) = lGrDwg.GetUchastokLinii(lKoorRasst.GetDwg(ispGraniz(i).Rastojnie), lKoorRasst.GetDwg(ispGraniz(i + 1).Rastojnie))
            Dim lperesUch As New GrebenProfilDwg(lUchLin)
            Dim lWerhKontur As List(Of Point2d) = lperesUch.GetSmeschen(lkoeff * ispGraniz(i).Glubina, lkoeff * ispGraniz(i + 1).Glubina)
            Dim lNijnKontur As List(Of Point2d) = lperesUch.GetSmeschen(lkoeff * iSpGlubin(i), lkoeff * iSpGlubin(i + 1))
            For J As Integer = 0 To lWerhKontur.Count - 1
                ComparatorPoint2dPoX.SearchAndInsert(lLin(0), lWerhKontur(J), lComp)
                ComparatorPoint2dPoX.SearchAndInsert(lLin(1), lNijnKontur(J), lComp)
            Next


        Next
        Return lLin
    End Function
    ' ''' <summary>
    ' ''' Формирует коллекцию точек образующую границу образа слоя ИГЭ
    ' ''' </summary>
    ' ''' <param name="iRazrEnd"> разрез конечной скважины</param>
    ' ''' <param name="iGlubina"></param>
    ' ''' <param name="iglubinaEnd"></param>
    ' ''' <param name="iPereschet">  гребенка профиля в координатах чертежа   </param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Function KonturDlaHatchG(iRazrEnd As GranizaSlojIgeRealDwg, iGlubina As Double, iglubinaEnd As Double) As Point2dCollection

    '    Dim lKoorRasst = wTrassa.objGeom.KoorP
    '    Dim lUchLin As List(Of Point2d) = wLinijProfilDwg.GetUchastokLinii(lKoorRasst.GetDwg(Rastojnie), lKoorRasst.GetDwg(iRazrEnd.Rastojnie))
    '    Dim lperesUch As New GrebenProfilDwg(lUchLin, True)
    '    Dim lWerhKontur As List(Of Point2d) = lperesUch.GetSmeschen(wKoeffGeo * Glubina, wKoeffGeo * iRazrEnd.Glubina)
    '    Dim lNijnKontur As List(Of Point2d) = lperesUch.GetSmeschen(wKoeffGeo * iGlubina, wKoeffGeo * iglubinaEnd)

    '    Dim lkontur As New Point2dCollection
    '    For Each el As Point2d In lWerhKontur
    '        lkontur.Add(el)
    '    Next
    '    lNijnKontur.Reverse()
    '    For Each el As Point2d In lNijnKontur
    '        lkontur.Add(el)
    '    Next
    '    Return lkontur




    'End Function
    ''' <summary>
    ''' Формирует коллекцию точек образующую границу образа слоя ИГЭ , апроксимация границы слоя зависит от глубины
    ''' </summary>
    ''' <param name="iRazrEnd"> разрез конечной скважины</param>
    ''' <param name="iGlubina"> начальная глубина нижней границы слоя  </param>
    ''' <param name="iglubinaEnd"> конечная глубина нижней границы слоя  </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function KonturDlaHatch(iRazrEnd As GranizaSlojIgeRealDwg, iGlubina As Double, iglubinaEnd As Double) As Point2dCollection

        Dim lKoorRasst = wTrassa.objGeom.KoorP
        Dim lUchLin As List(Of Point2d) = wLinijProfilDwg.GetUchastokLinii(lKoorRasst.GetDwg(Rastojnie), lKoorRasst.GetDwg(iRazrEnd.Rastojnie))
        Dim lperesUch As New GrebenProfilDwg(lUchLin)
        Dim lpr As Boolean = True
        If Glubina < 1 And iRazrEnd.Glubina < 1 Then lpr = False
        If lpr Then lperesUch.UstLinApr()

        Dim lWerhKontur As List(Of Point2d) = lperesUch.GetSmeschen(wKoeffGeo * Glubina, wKoeffGeo * iRazrEnd.Glubina)

        If lpr = False Then lperesUch.UstLinApr()
        Dim lNijnKontur As List(Of Point2d) = lperesUch.GetSmeschen(wKoeffGeo * iGlubina, wKoeffGeo * iglubinaEnd)

        Dim lkontur As New Point2dCollection
        For Each el As Point2d In lWerhKontur
            lkontur.Add(el)
        Next
        lNijnKontur.Reverse()
        For Each el As Point2d In lNijnKontur
            lkontur.Add(el)
        Next
        Return lkontur




    End Function
    ''' <summary>
    ''' Формирует cписки точек точек образующую границу образа слоя ИГЭ , апроксимация границы слоя зависит от глубины
    ''' </summary>
    ''' <param name="iRazrEnd"> разрез конечной скважины</param>
    ''' <param name="iRast"> Растояние на от начала слоя.  </param>
    ''' <returns> возвращает массив списков точек 0 - верхняя граница 1-нижняя граница</returns>
    ''' <remarks></remarks>
    Function PointNaGranizDlaHatch(iRazrEnd As GranizaSlojIgeRealDwg, iRast As Double) As Point2d

        Dim lKoorRasst = wTrassa.objGeom.KoorP
        Dim lUchLin As List(Of Point2d) = wLinijProfilDwg.GetUchastokLinii(lKoorRasst.GetDwg(Rastojnie), lKoorRasst.GetDwg(iRazrEnd.Rastojnie))
        Dim lperesUch As New GrebenProfilDwg(lUchLin)
        Dim lpr As Boolean = True
        If Glubina < 1 And iRazrEnd.Glubina < 1 Then lpr = False
        If lpr Then lperesUch.UstLinApr()
        Dim lPoint As Point2d = lperesUch.GetSmeschenPoint(wKoeffGeo * Glubina, wKoeffGeo * iRazrEnd.Glubina, lKoorRasst.GetDwg(iRast))



        Return lPoint




    End Function
    ''' <summary>
    ''' Формирует cписки точек точек образующую границу образа слоя ИГЭ , апроксимация границы слоя зависит от глубины
    ''' </summary>
    ''' <param name="iRazrEnd"> разрез конечной скважины</param>
    ''' <param name="iGlubinaNijn"> начальная глубина нижней границы слоя  </param>
    ''' <param name="iglubinaEndNijn"> конечная глубина нижней границы слоя  </param>
    ''' <returns> возвращает массив списков точек 0 - верхняя граница 1-нижняя граница</returns>
    ''' <remarks></remarks>
    Function GranizDlaHatch(iRazrEnd As GranizaSlojIgeRealDwg, iGlubinaNijn As Double, iglubinaEndNijn As Double) As List(Of Point2d)()
        '    If Math.Abs(wGlubina - iGlubinaNijn) + Math.Abs(iRazrEnd.Glubina - iglubinaEndNijn) < modelGeo.TipOpred.MinTolschina Then Return Nothing
        Dim lKoorRasst = wTrassa.objGeom.KoorP
        Dim lUchLin As List(Of Point2d) = wLinijProfilDwg.GetUchastokLinii(lKoorRasst.GetDwg(Rastojnie), lKoorRasst.GetDwg(iRazrEnd.Rastojnie))

        Dim lperesUch As New GrebenProfilDwg(lUchLin)
        Dim lpr As Boolean = True
        If Glubina < 1 And iRazrEnd.Glubina < 1 Then lpr = False
        If lpr Then
            lperesUch.UstLinApr()
        Else
            Dim jj = Glubina
        End If


        Dim lWerhKontur As List(Of Point2d) = lperesUch.GetSmeschen(wKoeffGeo * Glubina, wKoeffGeo * iRazrEnd.Glubina)

        If lpr = False Then lperesUch.UstLinApr()
        Dim lNijnKontur As List(Of Point2d) = lperesUch.GetSmeschen(wKoeffGeo * iGlubinaNijn, wKoeffGeo * iglubinaEndNijn)


        'For Each el As Point2d In lNijnKontur
        '    lkontur.Add(el)
        'Next
        Dim Lgr(1) As List(Of Point2d)
        Lgr(0) = lWerhKontur
        Lgr(1) = lNijnKontur
        Return Lgr




    End Function

    '''<summary>  ФФормирует cписки точек точек образующую границу образа слоя ИГЭ , апроксимация границы слоя зависит от глубины
    ''' </summary>
    '''<param name="iKoeffGeo"> коэффициэнт преобразования геологии </param>
    ''' <param name="iperesUch"> образ профиля в чертеже </param> 
    '''<param name="iglubinaEndWerh"> начальная глубина нижней границы слоя  </param>
    '''<param name="iGlubinaNijn"> начальная глубина нижней границы слоя  </param>
    ''' <param name="iglubinaEndNijn"> конечная глубина нижней границы слоя  </param>
    ''' <returns> возвращает массив списков точек 0 - верхняя граница 1-нижняя граница</returns>
    ''' <remarks></remarks>
    Shared Function GranizDlaHatch(iKoeffGeo As Double, iperesUch As GrebenProfilDwg, _
                                   iGlubinaWerh As Double, iglubinaEndWerh As Double, iGlubinaNijn As Double, iglubinaEndNijn As Double) As List(Of Point2d)()

        Dim lperesuch As New GrebenProfilDwg(iperesUch.GetWseLinij)
        Dim lpr As Boolean = True
        If iGlubinaWerh < 1 And iglubinaEndWerh < 1 Then lpr = False
        If lpr Then lperesuch.UstLinApr()
        Dim lWerhKontur As List(Of Point2d) = lperesuch.GetSmeschen(iKoeffGeo * iGlubinaWerh, iKoeffGeo * iglubinaEndWerh)

        If lpr = False Then lperesuch.UstLinApr()
        Dim lNijnKontur As List(Of Point2d) = lperesuch.GetSmeschen(iKoeffGeo * iGlubinaNijn, iKoeffGeo * iglubinaEndNijn)


        Dim Lgr(1) As List(Of Point2d)
        Lgr(0) = lWerhKontur
        Lgr(1) = lNijnKontur
        Return Lgr




    End Function


    Const KritRazmerHatch As Double = 9
    Private Function NaKonture(iKontur As Point2dCollection, iX As Double) As Double()
        Dim lY(1) As Double
        Dim lcount = iKontur.Count \ 2
        Dim maxnum = iKontur.Count - 1
        If iKontur(lcount).X < iX Then
            lY(0) = iKontur(lcount - 1).Y
            lY(1) = iKontur(maxnum - lcount + 1).Y
        End If
        For i = 0 To lcount - 1
            If Math.Abs(iKontur(i).X - iX) < LeseGeoIzDwg.ObrazGeologii_Bas.DopuskGeoDwgX Then
                lY(0) = iKontur(i).Y
                lY(1) = iKontur(maxnum - i).Y
            Else
                If iKontur(i).X > iX Then
                    If i = 0 Then
                        lY(0) = iKontur(0).Y
                        lY(1) = iKontur(maxnum).Y
                    Else
                        Dim lpw = BazDwg.GrebenProfilDwg.PointMejduPoint(iKontur(i - 1), iKontur(i), iX)
                        Dim lpn = BazDwg.GrebenProfilDwg.PointMejduPoint(iKontur(maxnum - i + 1), iKontur(maxnum - i), iX)
                        lY(0) = lpw.Y
                        lY(1) = lpn.Y
                    End If
                End If

            End If
        Next
        Return lY
    End Function
    Private Function MestoWstawki(iKontur As Point2dCollection, ByRef ldist As Double) As Point2d
        Dim lpoint1, lpoint2 As Point2d
        'проверяем можно ли поставить в середине слоя

        Dim lcount = iKontur.Count \ 2
        Dim maxnum = iKontur.Count - 1
        Dim GrB = iKontur(0).X
        Dim GrE = iKontur(lcount - 1).X
        Dim ldx = GrE - GrB
        ldist = 0
        Dim lXser = GrB + 0.5 * ldx
        Dim lmas = NaKonture(iKontur, lXser)
        ldist = Math.Abs(lmas(0) - lmas(1))
        If ldist > KritRazmerHatch Then
            If ldx < ldist Then ldist = ldx
            Return New Point2d(lXser, 0.5 * (lmas(0) + lmas(1)))
        End If

        'если не получилось по первому способу ищем точу с наиболее большой шириной в пикетных точках 
        If iKontur.Count > 4 Then
            Dim lmax As Integer = 0

            For i = 1 To lcount - 2
                If iKontur(i).X - GrB < KritRazmerHatch / 2 OrElse GrE - iKontur(i).X < KritRazmerHatch / 2 Then Continue For
                Dim lw = Math.Abs(iKontur(i).Y - iKontur(maxnum - i).Y)
                If lw > ldist Then
                    ldist = lw
                    lmax = i
                End If
            Next
            If ldx < ldist Then ldist = ldx
            lpoint1 = iKontur(lmax)
            lpoint2 = iKontur(maxnum - lmax)
            If lmax > 0 Then Return New Point2d(lpoint1.X, 0.5 * (lpoint1.Y + lpoint2.Y))

        End If
        Dim Xsum = 0.0, Ysum = 0.0
        'если не подходит ставми в центр масс 
        For Each el As Point2d In iKontur
            Xsum += el.X
            Ysum += el.Y
        Next
        lXser = Xsum / iKontur.Count
        lmas = NaKonture(iKontur, lXser)
        ldist = Math.Abs(lmas(0) - lmas(1))

        ldist = Math.Abs(lpoint1.Y - lpoint2.Y)
        If ldx < ldist Then ldist = ldx
        Return New Point2d(lXser, 0.5 * (lmas(0) + lmas(1)))



    End Function
#End Region
    Shared Sub WiwestiNameWozrastIge(lpointSer As Point2d, iParam As LeseGeoIzDwg.ParamIge)
        Dim lrad = 2.0
        Dim lwis = 2.5
        Dim lshirBase = 3.0

        Dim lpointSer3d = New Point3d(lpointSer.X, lpointSer.Y, 0)


        Dim collDb As New DBObjectCollection
        'Выводим номер Иге
        Dim jCircle As Circle = CType(BazDwg.dbPrim.CreateCircle(lpointSer.X + 1.5, lpointSer.Y - 1.5, lrad), Circle)
        Dim lMText As MText = CType(BazDwg.dbPrim.CreateMText(lpointSer3d, iParam.IndexIge, lshirBase, lwis), MText)
        jCircle.Layer = SkwajnaRealDwg.NameSlojDwGIndexIGE
        lMText.Layer = SkwajnaRealDwg.NameSlojDwGIndexIGE
        lMText.BackgroundFill = True
        lMText.BackgroundScaleFactor = 1
        '   lMText.Attachment = AttachmentPoint.TopCenter
        lMText.SetAttachmentMovingLocation(AttachmentPoint.TopCenter)
        Dim lshir = lMText.ActualWidth
        Dim lshir1 = dbPrim.DlinaPoX(jCircle)
        If lshir > 2.88 Then
           
            '    My.Application.Culture.NumberFormat.NumberDecimalSeparator = "."

            Dim lstr = "\T0.75;\W" & (2.88 / lshir).ToString("f2", SkwajnaRealDwg.NumF) & ";"
            lMText.Contents = lstr & lMText.Contents
            '  lMText.Attachment = AttachmentPoint.TopRight
        End If

        collDb.Add(lMText)
        collDb.Add(jCircle)
        If Not (iParam.Wozrast.Equals(modelGeo.TipOpred.WozwrastPoDefault) OrElse String.IsNullOrEmpty(iParam.Wozrast)) Then
            Dim lwozrastMtext As MText = CType(BazDwg.dbPrim.CreateMText(New Point3d(lpointSer.X - 1, lpointSer.Y - 3.6, 0), iParam.Wozrast, lshirBase, lwis), MText)
            lwozrastMtext.BackgroundFill = True
            lwozrastMtext.BackgroundScaleFactor = 1
            lwozrastMtext.Layer = SkwajnaRealDwg.NameSlojDwGIndexIGE
            collDb.Add(lwozrastMtext)
        End If


        BazDwg.dbPrim.Wkl(collDb)

    End Sub
    Shared Sub WiwestiHatchIge(Ikontur As KonturIge, Iparam As LeseGeoIzDwg.ParamIge, iPrLayer As Boolean, iPrWiwZnakaIge As Boolean)

        Dim lkontur = Ikontur.KonturW
        If lkontur.Count > 2 Then
            Dim lnameSl = SkwajnaRealDwg.NameSlojDwgGrunt
            If iPrLayer = False Then lnameSl = BazDwg.DwgParam.LayerGeoWspomog '
            Dim lcolor = -1
            If Iparam.IndexIge = modelGeo.TipOpred.IndexIgePoDefault Then lcolor = 1
            Dim lhatch As Hatch = ParamHatch.CreatehatchPoParamHatchL(SkwajnaRealDwg.NameSlojDwgIGE, lkontur, Iparam, lnameSl, BazDwg.DwgParam.LayerGeoWspomog, lcolor, )
            '    Dim l = lhatch.GetLoopAt(0)
            '    dbPrim.PeremestitNaZadnijPlan(lhatch)
            Dim ldist As Double
            Dim lcentr = Ikontur.Centr(ldist)
            If ldist > KritRazmerHatch Then
                If iPrWiwZnakaIge Then WiwestiNameWozrastIge(lcentr, Iparam)
            End If

        Else
            BazDwg.SystemKommand.Soob(" контур образован малым количеством точек " & lkontur.Count & " Слой " & Iparam.IndexIge & " в  " & " до ")
        End If


    End Sub
#If Staroe Then
Private Sub WiwestiNameWozrastIge(iKontur As Point2dCollection, iParam As LeseGeoIzDwg.ParamIge)


        Dim lDistanze As Double

        Dim lpointSer = MestoWstawki(iKontur, lDistanze)
        If lDistanze < KritRazmerHatch Then Return
        lpointSer = New Point2d(lpointSer.X, lpointSer.Y + 3.3)
        Dim lpointSer3d = New Point3d(lpointSer.X, lpointSer.Y, 0)


        Dim collDb As New DBObjectCollection
        'Выводим номер Иге
        Dim jCircle As Circle = CType(BazfunNet.dbPrim.CreateCircle(lpointSer.X + 1.5, lpointSer.Y - 1.5, 2), Circle)
        Dim lMText As MText = CType(BazfunNet.dbPrim.CreateMText(lpointSer3d, iParam.IndexIge, 3, 2.5), MText)
        jCircle.Layer = SkwajnaRealDwg.NameSlojDwGIndexIGE
        lMText.Layer = SkwajnaRealDwg.NameSlojDwGIndexIGE
        lMText.BackgroundFill = True
        lMText.BackgroundScaleFactor = 1
        '   lMText.Attachment = AttachmentPoint.TopCenter
        lMText.SetAttachmentMovingLocation(AttachmentPoint.TopCenter)
        Dim lshir = lMText.ActualWidth
        Dim lshir1 = dbPrim.DlinaPoX(jCircle)
        If lshir > 2.88 Then
            Dim lstr = "\T0.75;\W" & Format(2.88 / lshir, "f2") & ";"
            lMText.Contents = lstr & lMText.Contents
            '  lMText.Attachment = AttachmentPoint.TopRight
        End If

        collDb.Add(lMText)
        collDb.Add(jCircle)
        If Not (iParam.Wozrast.Equals(modelGeo.TipOpred.WozwrastPoDefault) OrElse String.IsNullOrEmpty(iParam.Wozrast)) Then
            Dim lwozrastMtext As MText = CType(BazfunNet.dbPrim.CreateMText(New Point3d(lpointSer.X - 1, lpointSer.Y - 3.6, 0), iParam.Wozrast, 3, 2.5), MText)
            lwozrastMtext.BackgroundFill = True
            lwozrastMtext.BackgroundScaleFactor = 1
            lwozrastMtext.Layer = SkwajnaRealDwg.NameSlojDwGIndexIGE
            collDb.Add(lwozrastMtext)
        End If


        BazfunNet.dbPrim.Wkl(collDb)

    End Sub
    ''' <summary>
    ''' Выводит штриховку ИГЭ
    ''' </summary>
    ''' <param name="iRazrEnd"> Граница противоположного слоя  </param>
    ''' <param name="iGlubina"> низ выводимого слоя </param>
    ''' <param name="iglubinaEnd"> низ противоположного слоя </param>
    ''' <param name="Iparam"></param>
    ''' <param name="iPrLayer"> True - во вспомогательном иначе в ГеоГрунт  </param>
    ''' <remarks></remarks>
    Private Sub WiwestiHatchIge(iRazrEnd As GranizaSlojIgeRealDwg, iGlubina As Double, iglubinaEnd As Double, _
                      Iparam As LeseGeoIzDwg.ParamIge, iPrLayer As Boolean)
        If Math.Abs(wGlubina - iGlubina) + Math.Abs(iRazrEnd.Glubina - iglubinaEnd) < modelGeo.TipOpred.MinTolschina Then Return
        Dim lkontur As Point2dCollection = KonturDlaHatch(iRazrEnd, iGlubina, iglubinaEnd)
        If lkontur.Count > 2 Then
            Dim lnameSl = SkwajnaRealDwg.NameSlojDwgGrunt
            If iPrLayer = False Then lnameSl = BazfunNet.DwgParam.LayerGeoWspomog '
            Dim lcolor = -1
            If Iparam.IndexIge = modelGeo.TipOpred.IndexIgePoDefault Then lcolor = 1
            Dim lhatch As Hatch = ParamHatch.CreatehatchPoParamHatchL(SkwajnaRealDwg.NameSlojDwgIGE, lkontur, Iparam, lnameSl, BazfunNet.DwgParam.LayerGeoWspomog, lcolor, )
            '    Dim l = lhatch.GetLoopAt(0)
            '    dbPrim.PeremestitNaZadnijPlan(lhatch)
            If wPrWiwodaZhakaIge Then WiwestiNameWozrastIge(lkontur, Iparam)
        Else
            BazfunNet.SystemKommand.Soob(Me.ToString & " контур образован малым количеством точек " & lkontur.Count & " Слой " & Me.IndexIge & " в  " & Me.Piketaj & " до " & iRazrEnd.Piketaj)
        End If
  End Sub
 Sub WiwestiHatchIge(lkontur As Point2dCollection, Iparam As LeseGeoIzDwg.ParamIge, iPrLayer As Boolean)

        '   Dim lkontur = Ikontur.KonturW
        If lkontur.Count > 2 Then
            Dim lnameSl = SkwajnaRealDwg.NameSlojDwgGrunt
            If iPrLayer = False Then lnameSl = BazfunNet.DwgParam.LayerGeoWspomog '
            Dim lcolor = -1
            If Iparam.IndexIge = modelGeo.TipOpred.IndexIgePoDefault Then lcolor = 1
            Dim lhatch As Hatch = ParamHatch.CreatehatchPoParamHatchL(SkwajnaRealDwg.NameSlojDwgIGE, lkontur, Iparam, lnameSl, BazfunNet.DwgParam.LayerGeoWspomog, lcolor, )
            '    Dim l = lhatch.GetLoopAt(0)
            '    dbPrim.PeremestitNaZadnijPlan(lhatch)
            If wPrWiwodaZhakaIge Then WiwestiNameWozrastIge(lkontur, Iparam)
        Else
            BazfunNet.SystemKommand.Soob(Me.ToString & " контур образован малым количеством точек " & lkontur.Count & " Слой " & Me.IndexIge & " в  " & Me.Piketaj & " до ")
        End If





    End Sub
#End If







    'Sub WiwestiHatchIge(Ikontur As KonturIge, Iparam As LeseGeoIzDwg.ParamIge, iPrLayer As Boolean)

    '    WiwestiHatchIge(Ikontur, Iparam, iPrLayer, wPrWiwodaZhakaIge)
    'End Sub
    'Private Shared Function PerepisatHatchCons(iNameLayer As String, ikoorGeo As clsKoor, iglubina As Double, iglubinapred As Double, iPointZent As Point2d, _
    '                       Iparam As BazfunNet.ParamHatch) As Entity

    '    '   Dim lPointZent As Point2d = iPereschet.GetPointLinii(iKoorRasst.GetDwg(Rastojnie))

    '    Dim lKontur As New Point2dCollection      'lperesUch.GetSmeschen(, ikoorGeo.Koeff * iRazrEnd.Glubina)
    '    lKontur.Add(New Point2d(iPointZent.X - 1, iPointZent.Y - ikoorGeo.Koeff * iglubina))
    '    lKontur.Add(New Point2d(iPointZent.X - 1, iPointZent.Y - ikoorGeo.Koeff * iglubinapred))
    '    lKontur.Add(New Point2d(iPointZent.X + 1, iPointZent.Y - ikoorGeo.Koeff * iglubinapred))
    '    lKontur.Add(New Point2d(iPointZent.X + 1, iPointZent.Y - ikoorGeo.Koeff * iglubina))




    '    Dim lhatch As Hatch = ParamHatch.CreatehatchPoParamHatch(iNameLayer, lKontur, Iparam, , 1)


    '    Return lhatch

    'End Function

End Class
''' <summary>
''' определение реальных параметров слоев под скважинами.
''' </summary>
''' <remarks></remarks>
Friend Class SlojIgeRealDwg
    Private wRazrezBeg, wRazrezEnd As GranizaSlojIgeRealDwg
    Private wSpGraniz As List(Of GranizaSlojIgeRealDwg)

#Region "Shared"
    ''' <summary>
    ''' Находит точку профиля по координате X в чертеже
    ''' </summary>
    ''' <param name="iTrassa"> модель трассы выведеная в чертеж </param>
    ''' <param name="iXdwg">  координата X точки чертежа  </param>
    ''' <returns>  возвращает точку в системе координат профиля (растояние от начала, отметка) </returns>
    ''' <remarks></remarks>
    Shared Function PointProfilPoXdwg(iTrassa As DwgTr, iXdwg As Double) As PointReal
        Dim lrastbeg = iTrassa.RastPoDwgX(iXdwg)
        Dim lotmbeg = iTrassa.GetOtmetka(lrastbeg)
        Return New PointReal(lrastbeg, lotmbeg)
    End Function
    ''' <summary>
    ''' формирует объект для пересчета отметок геологии в координаты чертежа
    ''' </summary>
    ''' <param name="imaschtabGeo"> масштаб целое(200, 500, 1000) </param>
    ''' <param name="iOtmetkaProf"> отметка профиля в координатах профиля </param>
    ''' <param name="iTrassa"> модель трассы выведеная в чертеж  </param>
    ''' <returns> возвращает объект для пересчета метрических параметров геологии в координаты чертежа </returns>
    ''' <remarks></remarks>
    Shared Function GetObjektKoor(imaschtabGeo As Integer, iOtmetkaProf As Double, iTrassa As DwgTr) As clsKoor
        'неудачно для каждого слоя нужно пересчитывать.
        Dim lOtmetkaDwg = iTrassa.DwgYpoOtm(iOtmetkaProf)
        Return New clsKoor(imaschtabGeo, iOtmetkaProf, lOtmetkaDwg)

    End Function
    'Shared Function KoorGeoPoxDwg(iparamgeo As ParamImageGeo, itrassa As DwgTr, ixdwg As Double) As clsKoor
    '    Dim lOtmPrfReal = itrassa.GetOtmetka(itrassa.RastPoDwgX(ixdwg))
    '    Dim lOtmetkaDwg = itrassa.DwgYpoOtm(lOtmPrfReal)
    '    Return New clsKoor(iparamgeo.Maschtab, lOtmPrfReal, lOtmetkaDwg)
    'End Function
    'Shared Function SdelatKontur(iWerh As List(Of Point2d), iNijn As List(Of Point2d)) As Point2dCollection

    '    Dim lkontur As New Point2dCollection
    '    For Each el As Point2d In iWerh
    '        lkontur.Add(el)
    '    Next
    '    iNijn.Reverse()
    '    For Each el As Point2d In iNijn
    '        lkontur.Add(el)
    '    Next
    '    Return lkontur
    'End Function
#End Region
    ' Private wPiketaj, wpiketajEnd As Double
    ''' <summary>
    ''' Пересчет слоя ИГЭ полученого  из чертежа к реальным координатам
    ''' </summary>
    ''' <param name="iparam">  Параметры образа геологии  </param>
    ''' <param name="iSlojIgeDwg"> Слой Иге в чертеже    </param>
    ''' <param name="iTrassa">  трасса профиля </param>
    ''' <remarks></remarks>
    Sub New(iTrassa As DwgTr, iparam As ParamImageGeo, iSlojIgeDwg As LeseGeoIzDwg.SlojIgeDwg, Optional ipointBeg As PointReal = Nothing, Optional ipointEnd As PointReal = Nothing)
        If ipointBeg Is Nothing Then ipointBeg = PointProfilPoXdwg(iTrassa, iSlojIgeDwg.RastOtNachalaDwgBeg)
        If ipointEnd Is Nothing Then ipointEnd = PointProfilPoXdwg(iTrassa, iSlojIgeDwg.RastOtNachalaDWGEnd)
        Dim lrB = New LeseGeoIzDwg.RazrezSlojIgeDwg(iSlojIgeDwg)
        wRazrezBeg = New GranizaSlojIgeRealDwg(iTrassa, iparam.Maschtab, lrB, iSlojIgeDwg.nameSkwajBeg, ipointBeg)
        Dim lre = New LeseGeoIzDwg.RazrezSlojIgeDwg(iSlojIgeDwg, True)
        wRazrezEnd = New GranizaSlojIgeRealDwg(iTrassa, iparam.Maschtab, lre, iSlojIgeDwg.nameSkwajEnd, ipointEnd)
        wSpGraniz = New List(Of GranizaSlojIgeRealDwg)
        wSpGraniz.Add(wRazrezBeg)
        wSpGraniz.Add(wRazrezEnd)

        With iTrassa

            '  wPiketaj = .Piketaj(Rastojnie)
            '     wpiketajEnd = .Piketaj(wRazrezEnd.Rastojnie)
        End With

    End Sub
#Region "Read onlu"
    'ReadOnly Property RastojnieBeg As Double
    '    Get

    '        Return Rastojnie
    '    End Get
    'End Property
    'ReadOnly Property RastojnieEnd As Double
    '    Get
    '        Return wRazrezEnd.Rastojnie
    '    End Get
    'End Property
    'ReadOnly Property OtmetkaPrfEnd As Double
    '    Get
    '        Return wRazrezEnd.OtmetkaPrf
    '    End Get
    'End Property
    'ReadOnly Property strPiketaj As String
    '    Get
    '        Return clsPrf.clsPiket.StrPiketaj(MyBase.Piketaj)
    '    End Get
    'End Property
    'ReadOnly Property WerhGranizaEnd As Double
    '    Get
    '        Return wRazrezEnd.WerhGraniza
    '    End Get
    'End Property
    'ReadOnly Property GlubinaEnd As Double
    '    Get
    '        Return wRazrezEnd.Glubina
    '    End Get
    'End Property
    'ReadOnly Property OtmetkaBegDwg(ikoorOtm As clsKoor, koeffGeo As Double) As Double
    '    Get
    '        Dim lOtmetkaProfDwg As Double = ikoorOtm.GetDwg(OtmetkaPrf)


    '        Return lOtmetkaProfDwg - koeffGeo * Glubina
    '    End Get
    'End Property


    'ReadOnly Property NameSkwajBeg As String
    '    Get
    '        Return NameObjekt
    '    End Get
    'End Property
    'ReadOnly Property NameSkwajEnd As String
    '    Get
    '        Return wRazrezEnd.NameObjekt
    '    End Get
    'End Property
#End Region
    Function GetRazrezEnd() As GranizaSlojIgeRealDwg
        Return wRazrezEnd
    End Function
    Function GetRazrezBeg() As GranizaSlojIgeRealDwg
        Return wRazrezBeg
    End Function





End Class