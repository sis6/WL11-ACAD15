Imports LeseGeoIzDwg
Imports OperBD


#If ARX_APP Then
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.Geometry
#Else
Imports Teigha.DatabaseServices
Imports Teigha.Geometry
#End If
Class ParaInt
    Private wPer, wProt As Integer
    Sub New(iPer As Integer, iProt As Integer)
        wPer = iPer
        wProt = iProt
    End Sub
    Function Rawni(iProw As ParaInt) As Boolean
        Return wPer.Equals(iProw.wPer) And wProt.Equals(iProw.wProt)

    End Function
    Shared Function EstLiSpiske(iSp As List(Of ParaInt), iProw As ParaInt) As Boolean
        For Each el As ParaInt In iSp
            If el.Rawni(iProw) Then Return True
        Next
        Return False
    End Function

End Class
Public Class ComparatorParaGraniz
    Implements IComparer(Of ParaGranizTochek)

    Public Function Compare(ByVal x As ParaGranizTochek, ByVal y As ParaGranizTochek) As Integer Implements System.Collections.Generic.IComparer(Of ParaGranizTochek).Compare
        Return x.SrawnitPoGlubine(y)
    End Function

    Shared Function SearchAndInsert( _
ByVal lis As List(Of ParaGranizTochek), _
ByVal insert As ParaGranizTochek, ByVal dc As IComparer(Of ParaGranizTochek)) As Integer



        Dim index As Integer = lis.BinarySearch(insert, dc)
        Dim lwozwr = index
        If index < 0 Then
            index = index Xor -1
            lis.Insert(index, insert)
        End If
        Return lwozwr
    End Function
End Class
''' <summary>
''' Класс обеспечивающий работу с точками иге заданых на скважинах
''' </summary>
''' <remarks></remarks>
Public Class ParaGranizTochek
    Private wPer, wProt As GranizaSlojIgeRealDwg
    Private wspGraniz As New List(Of GranizaSlojIgeRealDwg)
    Private Shared wModelGeo As modelGeo.GeologijReal
    Private Shared wtrassaDwg As ProfilBaseDwg.DwgTr
#Region "Init"
    ''' <summary>
    ''' Задает связь с модельэ трассы и геологии общая для всех экземпляров класса
    ''' </summary>
    ''' <param name="iTrassa"></param>
    ''' <param name="imodelGeo"></param>
    ''' <remarks></remarks>
    Shared Sub Init(iTrassa As ProfilBaseDwg.DwgTr, imodelGeo As modelGeo.GeologijReal)
        wtrassaDwg = iTrassa

        wModelGeo = imodelGeo
    End Sub
    'Создает список границ слоев на скважинах расположеных между граничными на которых возможно выклинивание.
    Private Sub CreateSpisokKlin()
        If IsSlojUroven() Then Return 'нужно перенести в начало
        Dim lsp = wModelGeo.SpSkwajnNaIntervale(wPer.Rastojnie, wProt.Rastojnie)
        For Each el As modelGeo.SkwajnaReal In lsp
            If el.DataRowSkwaj.Tip <> modelGeo.TipSkwajn.dlajKlin Then Continue For
            For Each els As DsGeologij.geoSloiIgeRow In el.GetSpSlojwIge

                If CInt(els.Tolshina) <= 0 And ((wPer.IndexIge = els.IndexIGE) Or (wProt.IndexIge = els.IndexIGE)) Then  '

                    Dim lgr = New GranizaSlojIgeRealDwg(wtrassaDwg, wPer.KoeffGeo, New clsPrf.PointReal(el.Rastojnie, el.Otmetka), els.Glubina, els.IndexIGE, 0)

                    Dim lGlApr = GlubinaAprX(el.Rastojnie)

                    wspGraniz.Add(lgr)
                End If
            Next


        Next
    End Sub
    Sub New(iper As GranizaSlojIgeRealDwg, iwtor As GranizaSlojIgeRealDwg)
        wPer = iper
        wProt = iwtor
        CreateSpisokKlin()
    End Sub
    Private Function PointMejdu(iXdwg As Double) As Point2d
        Dim lGrwPer = wPer.PointGrDwg
        Dim lgrWProt = wProt.PointGrDwg
        Return BazDwg.GrebenProfilDwg.PointMejduPoint(lGrwPer, lgrWProt, iXdwg)
    End Function


#End Region
    ''' <summary>
    ''' создает список пар границ начала отрисовки слоя Игэ(не пересекающихся)
    ''' </summary>
    ''' <param name="iSpOdin"> список границ на первой скважине включая дно </param>
    ''' <param name="iSpProt">  список границ на противоположной скважине включая дно </param>
    ''' <returns></returns>
    ''' <remarks>  2016-12-07  </remarks>
    Shared Function SozdatSpisokPar(iSpOdin As List(Of GranizaSlojIgeRealDwg), iSpProt As List(Of GranizaSlojIgeRealDwg)) As List(Of ParaGranizTochek)

        Dim lcomp As New ComparatorParaGraniz
        Dim lSpPar As New List(Of ParaGranizTochek)
        Dim lProsmotrProt As New List(Of Integer)
        Dim lWnutrPar As New List(Of ParaInt)
        Dim lProsmotr As New List(Of Integer)
        ' Soglasowat(iSpOdin, iSpProt)
        For Each el As GranizaSlojIgeRealDwg In iSpOdin
            Dim lindProt = -1
            For j As Integer = 0 To iSpProt.Count - 1
                '   If lProsmotrProt.IndexOf(j) >= 0 Then Continue For
                Dim lelProt = iSpProt(j)
                If el.IndexIge.Equals(lelProt.IndexIge) AndAlso el.Uroven.Equals(Math.Abs(lelProt.Uroven)) Then  'And (el.Uroven.Equals(lelProt.Uroven) OrElse Math.Abs(el.Glubina - iSpProt(j).Glubina) < 0.25 * iSpOdin.Last.Glubi
                    lindProt = j
                    Exit For
                End If

            Next j
            If lindProt > -1 Then  'противоположный существует   1

                Dim indWkl = iSpOdin.IndexOf(el)
                If ParaInt.EstLiSpiske(lWnutrPar, New ParaInt(indWkl, lindProt)) Then Continue For 'если внутренняя то не рассматриваем
                Dim lind = ComparatorParaGraniz.SearchAndInsert(lSpPar, New ParaGranizTochek(el, iSpProt(lindProt)), lcomp)
                If lind < 0 Then      ' включили пару       2

                    lProsmotrProt.Add(lindProt)
                    lProsmotr.Add(indWkl)
                    For ii = indWkl + 1 To iSpOdin.Count - 1
                        lWnutrPar.Add(New ParaInt(ii, lindProt))
                    Next
                    For jj = lindProt + 1 To iSpProt.Count - 1
                        lWnutrPar.Add(New ParaInt(indWkl, jj))
                    Next
                End If    '3


            End If

        Next 'включили все границы где есть противоположные
        For i As Integer = 0 To iSpOdin.Count - 1
            For j As Integer = 0 To iSpProt.Count - 1

                If ParaInt.EstLiSpiske(lWnutrPar, New ParaInt(i, j)) Then Continue For 'если внутренняя то не рассматриваем
                Dim lPrI = lProsmotr.IndexOf(i)
                Dim lPrJ = lProsmotrProt.IndexOf(j)

                If lPrI < 0 Or lPrJ < 0 Then  'если какаято отметка не входит в список пар добавляем ее

                    Dim lPrWkl = ComparatorParaGraniz.SearchAndInsert(lSpPar, New ParaGranizTochek(iSpOdin(i), iSpProt(j)), lcomp)
                    If lPrWkl < 0 Then
                        If lPrI < 0 Then lProsmotr.Add(i)
                        If lPrJ < 0 Then lProsmotrProt.Add(j)
                    End If
                End If
            Next 'j
        Next 'i
        Return lSpPar
    End Function

    ''' <summary>
    ''' проверяем попадаетли выбраная точка в слой
    ''' </summary>
    ''' <param name="iSledPara"> нижняя пара границы слоя </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function UtochnitKlin(iSledPara As ParaGranizTochek) As List(Of GranizaSlojIgeRealDwg)
        Dim lwsp As New List(Of GranizaSlojIgeRealDwg)
        For Each el As GranizaSlojIgeRealDwg In wspGraniz
            Dim lPointPrfDwg = el.PointPrfDwg  'Образ точки на профиле
            Dim lpointGrDwg = el.PointGrDwg    'образ границы слоя
            Dim ltW = PointMejdu(lPointPrfDwg.X)
            Dim ltN = iSledPara.PointMejdu(lPointPrfDwg.X)
            Dim lShirina = ltW - ltN
            Dim lDopusk = 0.2 * lShirina.Y
            '      Dim lgrI = New GranizIge(Me, iSledPara, el)


            If lpointGrDwg.Y > ltW.Y And lpointGrDwg.Y < ltW.Y + lDopusk Then
                Dim lgr = New GranizaSlojIgeRealDwg(wtrassaDwg, wPer.KoeffGeo, New clsPrf.PointReal(el.Rastojnie, el.OtmetkaPrf), el.Glubina + (lpointGrDwg.Y - ltW.Y) / wPer.KoeffGeo, _
                                                    el.IndexIge, 0)
                lwsp.Add(lgr)
                Continue For
            End If
            If lpointGrDwg.Y < ltN.Y And lpointGrDwg.Y > ltN.Y - lDopusk Then    '- lotm + lotmN
                Dim lgr = New GranizaSlojIgeRealDwg(wtrassaDwg, wPer.KoeffGeo, New clsPrf.PointReal(el.Rastojnie, el.OtmetkaPrf), el.Glubina + (lpointGrDwg.Y - ltN.Y) / wPer.KoeffGeo, _
                                                    el.IndexIge, 0)
                lwsp.Add(lgr)
                Continue For
            End If
            If lpointGrDwg.Y < ltW.Y And lpointGrDwg.Y > ltN.Y Then
                lwsp.Add(el)
                Continue For
            End If

        Next
        Return lwsp
    End Function
    ''' <summary>
    ''' по индексу ИГЭ возвращает объект с параметрами ИГЭ
    ''' </summary>
    ''' <param name="IndexIge"> Индекс ИГЭ </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function fParamIge(IndexIge As String) As LeseGeoIzDwg.ParamIge
        Dim ldr As DsGeologij.geoParamIgeRow

        Try
            ldr = wModelGeo.GetDataSet.geoParamIge.FindByUidUchIndexIGE(CType(wtrassaDwg.Uchastki(1), clsPrf.clsUchPrf).UidUch, IndexIge)
        Catch ex As Exception
            MsgBox(Me.ToString & " fParamIge " & IndexIge & " не найденна запись ")
            ldr = Nothing
        End Try

        If ldr IsNot Nothing Then
            Try
                Return New LeseGeoIzDwg.ParamIge(ldr.PatternName, ldr.PatternScale, ldr.PatternAngle, _
                                                                   CType(ldr.wLineWeight, LineWeight), ldr.IndexIGE, ldr.Woswrast)
            Catch ex As Exception
                MsgBox(Me.ToString & " fParamIge " & IndexIge & " не найденна штриховка ")

                Return New LeseGeoIzDwg.ParamIge(modelGeo.TipOpred.NamePatternIgePodefault, modelGeo.TipOpred.ScaleDefault * 2.0, 0, _
                                                 CType(-1, LineWeight), IndexIge, "")
            End Try

        End If
        '  Dim l = IndexIge
        Dim lt = wModelGeo.GetDataSet.geoParamIge
        Dim lp = From p As DsGeologij.geoParamIgeRow In lt Where p.IndexIGE = IndexIge Select p

        If lp.Count > 0 Then
            ldr = lp(0)
            Return New LeseGeoIzDwg.ParamIge(ldr.PatternName, ldr.PatternScale, ldr.PatternAngle, _
                                                              CType(ldr.wLineWeight, LineWeight), ldr.IndexIGE, ldr.Woswrast)
        Else
            Return New LeseGeoIzDwg.ParamIge(modelGeo.TipOpred.NamePatternIgePodefault, modelGeo.TipOpred.ScaleDefault * 2.0, 0, _
                                                     CType(-1, LineWeight), IndexIge, "")
        End If




    End Function

    ''' <summary>
    ''' Сравнивает глубины пар Если ниже обе точки то 1 если выше -1 , если одна выше другая ниже то ноль
    ''' </summary>
    ''' <param name="iParaGraniz"></param>
    ''' <returns></returns>
    ''' <remarks> если линия соеденяющая пару точек идет ниже то 1 выше -1 , если пересекаеться то 0  </remarks>
    Function SrawnitPoGlubine(iParaGraniz As ParaGranizTochek) As Integer

        Dim lglubina = wPer.Glubina '+ 0.001 * wPer.Uroven
        Dim lglubinaSraw = iParaGraniz.wPer.Glubina '+ 0.001 * iParaGraniz.wPer.Uroven
        Dim lglubinaProt = wProt.Glubina '+ 0.001 * wProt.Uroven
        Dim lglubinaSrawProt = iParaGraniz.wProt.Glubina '+ 0.001 * iParaGraniz.wProt.Uroven
        Dim lSign = Math.Sign(lglubina - lglubinaSraw) + Math.Sign(lglubinaProt - lglubinaSrawProt)
        If lglubina = lglubinaSraw And lglubinaProt = lglubinaSrawProt Then Return 0
        If lSign > 0 Then
            Return 1
        Else
            If lSign < 0 Then
                Return -1
            Else
                Return 0
            End If
        End If


    End Function

    ''' <summary>
    ''' распределяет контура слоев ИГЭ по спискам внешний - контура полностью ограничивающие слой между точками и внутреними - граничная точка лежит внутри слоя (выклинивание)
    ''' </summary>
    ''' <param name="isledPara"> следущая пара в грничных точек(нижняя) </param>
    ''' <param name="iWnesch"> список внешних контуров </param>
    ''' <param name="iWnutr">список внутряных </param>
    ''' <remarks></remarks>
    Sub RaspedKontur(isledPara As ParaGranizTochek, iWnesch As List(Of KonturIge), iWnutr As List(Of KonturIge))
        Dim lw As GranizIge
        Dim wgl = isledPara.Beg.Glubina
        Dim iWnutrSloj = UtochnitKlin(isledPara)
        If iWnutrSloj.Count > 0 Then
            lw = New GranizIge(Me, isledPara, iWnutrSloj(0))

        Else
            lw = New GranizIge(Me, isledPara, Nothing)
            lw.OpredelitKontur()
            iWnesch.AddRange(lw.KonturdlajWiw)
            Return

        End If
        lw.OpredelitKontur()
        If lw.KonturdlajWiw.Count = 0 Then Return
        'If lw.KonturdlajWiw.First.KonturWneh IsNot Nothing Then
        '    iWnutr.Add(lw.KonturdlajWiw.First)
        '    iWnesch.Add(lw.KonturdlajWiw.Last)
        'Else
        If lw.KonturdlajWiw.Count = 1 Then
            iWnesch.Add(lw.KonturdlajWiw.First)
        Else
            iWnesch.Add(lw.KonturdlajWiw.First)
            iWnesch.Add(lw.KonturdlajWiw.Last)
        End If
        ' End If

    End Sub
    ''' <summary>
    ''' Апроксимирует разрезы слоя ИГЭ между точками
    ''' </summary>
    ''' <param name="iSledPara">нижняя пара границ </param>
    ''' <param name="iTochkaMejdu"> точка на профиле в реальных координатах </param>
    ''' <returns> список разрезов слоя может содержать один или два элемента  </returns>
    ''' <remarks></remarks>
    Function SloiMejdu(iSledPara As ParaGranizTochek, iTochkaMejdu As clsPrf.PointReal) As List(Of GranizaSlojIgeRealDwg)
        Dim lSp As New List(Of GranizaSlojIgeRealDwg)
        Dim lG = GlubinaAprX(iTochkaMejdu.X)  'Глубина начала слоя в точке
        Dim lgSled = iSledPara.GlubinaAprX(iTochkaMejdu.X)  'Глубина начала следующего слоя в точке
        Dim lT = lgSled - lG   'Толщина начала слоя в точке
        If IsSloj() Then
            Dim lparam = fParamIge(wPer.IndexIge)

            Dim w = New GranizaSlojIgeRealDwg(wtrassaDwg, Me.wPer.KoeffGeo, iTochkaMejdu, lG, lparam.IndexIge, wPer.Uroven)
            lSp.Add(w)
        Else
            If Math.Abs(wPer.Glubina - iSledPara.wPer.Glubina) < ObrazGeologii.KritBlizostiDwg Then
                Dim lparam = fParamIge(wProt.IndexIge)

                Dim w = New GranizaSlojIgeRealDwg(wtrassaDwg, Me.wPer.KoeffGeo, iTochkaMejdu, lG, lparam.IndexIge, wProt.Uroven)
                lSp.Add(w)
            Else
                If Math.Abs(wProt.Glubina - iSledPara.wProt.Glubina) < ObrazGeologii.KritBlizostiDwg Then
                    Dim lparam = fParamIge(wPer.IndexIge)
                    Dim w = New GranizaSlojIgeRealDwg(wtrassaDwg, Me.wPer.KoeffGeo, iTochkaMejdu, lG, lparam.IndexIge, wPer.Uroven)
                    lSp.Add(w)
                Else    'Противоположный с другим ИГЭ и отличной от нуля толщиной
                    Dim lparam = fParamIge(wPer.IndexIge)
                    Dim w = New GranizaSlojIgeRealDwg(wtrassaDwg, Me.wPer.KoeffGeo, iTochkaMejdu, lG, lparam.IndexIge, wPer.Uroven)
                    lSp.Add(w)
                    Dim lparamProt = fParamIge(wProt.IndexIge)
                    Dim lwsp As New GranizaSlojIgeRealDwg(wtrassaDwg, wPer.KoeffGeo, wPer.PointRealNaProfile, iSledPara.wPer.Glubina, wProt.IndexIge, wProt.Uroven)
                    Dim wp As New ParaGranizTochek(lwsp, wProt)
                    Dim w1 = New GranizaSlojIgeRealDwg(wtrassaDwg, Me.wPer.KoeffGeo, iTochkaMejdu, wp.GlubinaAprX(iTochkaMejdu.X), lparamProt.IndexIge, wProt.Uroven)
                    lSp.Add(w1)
                End If
            End If

        End If
        Return lSp
    End Function
#Region "Инфо ReadOnly"
    Function GlubinaAprX(iX As Double) As Double


        If iX < wPer.Rastojnie Then Return wPer.Glubina
        If iX > wProt.Rastojnie Then Return wProt.Glubina
        Dim delta As Double = iX - wPer.Rastojnie

        Return wPer.Glubina + delta * (wProt.Glubina - wPer.Glubina) / (wProt.Rastojnie - wPer.Rastojnie)
    End Function
    Function OtmetkaAprX(iX As Double) As Double


        If iX < wPer.Rastojnie Then Return wPer.Otmetka
        If iX > wProt.Rastojnie Then Return wProt.Otmetka
        Dim delta As Double = iX - wPer.Rastojnie

        Return wPer.Otmetka + delta * (wProt.Otmetka - wPer.Otmetka) / (wProt.Rastojnie - wPer.Rastojnie)
    End Function
    Function OtmetkaPrfAprX(iX As Double) As Double


        If iX < wPer.Rastojnie Then Return wPer.OtmetkaPrf
        If iX > wProt.Rastojnie Then Return wProt.OtmetkaPrf
        Dim delta As Double = iX - wPer.Rastojnie

        Return wPer.OtmetkaPrf + delta * (wProt.OtmetkaPrf - wPer.OtmetkaPrf) / (wProt.Rastojnie - wPer.Rastojnie)
    End Function
    ReadOnly Property Beg As GranizaSlojIgeRealDwg
        Get
            Return wPer
        End Get

    End Property
    ReadOnly Property Prot As GranizaSlojIgeRealDwg
        Get
            Return wProt
        End Get

    End Property
    ''' <summary>
    ''' проверяет совпадает ли иге слоев пары
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function IsSloj() As Boolean
        Return wPer.IndexIge.Equals(wProt.IndexIge)
    End Function
    ''' <summary>
    ''' проверяет совпадает ли иге слоев пары с учетом уровня
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function IsSlojUroven() As Boolean
        Return wPer.IndexIge.Equals(wProt.IndexIge) AndAlso Math.Abs(wPer.Uroven) = Math.Abs(wProt.Uroven)
    End Function


#End Region
#Region "Ubrat potom "
    Private Function SlojNije(IGrSloj As GranizaSlojIgeRealDwg) As Boolean
        Dim lgl = GlubinaAprX(IGrSloj.Rastojnie)
        Return IGrSloj.Glubina > lgl
    End Function
    Private Function KonturaWnesch(iSledPara As ParaGranizTochek) As KonturIge
        Dim lw As GranizIge
        Dim iWnutrSloj = UtochnitKlin(iSledPara)

        If iWnutrSloj.Count > 0 Then
            lw = New GranizIge(Me, iSledPara, iWnutrSloj(0))

        Else
            lw = New GranizIge(Me, iSledPara, Nothing)

        End If
        lw.OpredelitKontur()
        If lw.TolschinaBeg < modelGeo.TipOpred.MinTolschina AndAlso lw.TolschinaEnd < modelGeo.TipOpred.MinTolschina Then Return Nothing
        Return lw.KonturdlajWiw.Last
    End Function
    Private Function KonturWnutr(isledPara As ParaGranizTochek) As KonturIge
        Dim lw As GranizIge
        Dim iWnutrSloj = UtochnitKlin(isledPara)

        If iWnutrSloj.Count > 0 Then
            lw = New GranizIge(Me, isledPara, iWnutrSloj(0))

        Else
            Return Nothing

        End If
        lw.OpredelitKontur()
        If lw.TolschinaBeg < modelGeo.TipOpred.MinTolschina AndAlso lw.TolschinaEnd < modelGeo.TipOpred.MinTolschina Then Return Nothing
        If lw.KonturdlajWiw.Count > 1 Then Return lw.KonturdlajWiw.First
        Return Nothing
    End Function


#End Region


End Class
