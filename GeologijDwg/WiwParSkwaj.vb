Public Class WiwParSkwaj
    Private wSkwajBeg, wSkwajEnd As SkwajnaRealDwg
    Private wtrassaDwg As ProfilBaseDwg.DwgTr
    Private wLinijProfilDwg As BazDwg.GrebenProfilDwg
    ' Private wdsGeologij As modelGeo.dsGeologij
    Private wmodelGeo As modelGeo.GeologijReal
    ''' <summary>
    ''' объект 2 смежных скважины с расположеными между ними слоями
    ''' </summary>
    ''' <param name="iTrassa"></param>
    ''' <param name="iModelGeo"></param>
    ''' <param name="IIndex"></param>
    ''' <param name="iparamGeo"></param>
    ''' <remarks></remarks>
    Sub New(iTrassa As ProfilBaseDwg.DwgTr, iModelGeo As modelGeo.GeologijReal, IIndex As Integer, iparamGeo As ParamImageGeo)
        wtrassaDwg = iTrassa
        wmodelGeo = iModelGeo
        '   wdsGeologij = iModelGeo.GetDataSet
        wLinijProfilDwg = wtrassaDwg.GetLinijDwg

        wSkwajBeg = New SkwajnaRealDwg(iTrassa, iModelGeo.GetSkwajPoIndex(IIndex), iparamGeo)
        wSkwajEnd = New SkwajnaRealDwg(iTrassa, iModelGeo.GetSkwajPoIndex(IIndex + 1), iparamGeo)

    End Sub
    Sub New(iTrassa As ProfilBaseDwg.DwgTr, iModelGeo As modelGeo.GeologijReal, iIndexB As Integer, iIndexE As Integer, iparamGeo As ParamImageGeo)
        wtrassaDwg = iTrassa
        wmodelGeo = iModelGeo
        '   wdsGeologij = iModelGeo.GetDataSet
        wLinijProfilDwg = wtrassaDwg.GetLinijDwg

        wSkwajBeg = New SkwajnaRealDwg(iTrassa, iModelGeo.GetSkwajPoIndex(iIndexB), iparamGeo)
        wSkwajEnd = New SkwajnaRealDwg(iTrassa, iModelGeo.GetSkwajPoIndex(iIndexE), iparamGeo)

    End Sub
    ReadOnly Property SkwajBeg As SkwajnaRealDwg
        Get
            Return wSkwajBeg
        End Get
    End Property
    ReadOnly Property SkwajEnd As SkwajnaRealDwg
        Get
            Return wSkwajEnd
        End Get
    End Property
    ''определяет 
    'Private Function fParamIge(IndexIge As String) As LeseGeoIzDwg.ParamIge
    '    Dim ldr = wdsGeologij.geoParamIge.FindByUidUchIndexIGE(CType(wtrassaDwg.Uchastki(1), clsPrf.clsUchPrf).UidUch, IndexIge)
    '    Return New LeseGeoIzDwg.ParamIge(ldr.PatternName, ldr.PatternScale, ldr.PatternAngle, _
    '                                     CType(ldr.wLineWeight, Autodesk.AutoCAD.DatabaseServices.LineWeight), ldr.IndexIGE, ldr.Woswrast)
    'End Function
    'Private Sub PerepisatSlojiGE(el As GranizaSlojIgeRealDwg, elProt As GranizaSlojIgeRealDwg, iglubina As Double, iglubinaProt As Double, Iparam As LeseGeoIzDwg.ParamIge)
    '    ' If el.IndexIge = modelGeo.TipOpred.IndexIgePoDefault And elProt.IndexIge = modelGeo.TipOpred.IndexIgePoDefault Then Return
    '    Dim lobjGeom As ProfilBaseDwg.dwgGeometr = wtrassaDwg.objGeom
    '    If el.IndexIge = Iparam.IndexIge Then
    '        el.WiwestiHatchIge(elProt, iglubina, iglubinaProt, wLinijProfilDwg, Iparam, True)
    '        '   el.WiwestiNameWozrastIge(elProt, iglubina, iglubinaProt, Iparam)
    '    Else
    '        MsgBox(Me.ToString & "  " & el.IndexIge)
    '    End If

    'End Sub
    'Shared Function NajtiNum(iIndexIge As String, iSp As List(Of GranizaSlojIgeRealDwg)) As Integer
    '    For i = 0 To iSp.Count - 1
    '        If iSp(i).IndexIge = iIndexIge Then Return i
    '    Next
    '    Return -1
    'End Function
    Private Function GlubinaSled(iNum As Integer, iskwajReal As SkwajnaRealDwg) As Double
        Dim lSp As List(Of GranizaSlojIgeRealDwg) = iskwajReal.GetSlojNaSkwajne
        Dim lNumber = lSp.Count - 1
        Dim lglubina As Double
        If iNum < lNumber Then
            lglubina = lSp(iNum + 1).Glubina
        Else
            lglubina = iskwajReal.Glubina
        End If
        Return lglubina
    End Function
  
    'Const ShirinaWiw = 0.3
    'Const ShirinaWiwProt = 1.0 - ShirinaWiw
    'Private Sub PerepisatW()
    '    wSkwajBeg.WiwestiSkwajWdwg()
    '    '   wSkwajBeg.wiwestiOtmetkiSloew(SkwajnaRealDwg.NameSlojDwGIndexIGE)
    '    wSkwajBeg.WiwestiMej(wSkwajEnd)

    '    Dim lSp As List(Of GranizaSlojIgeRealDwg) = wSkwajBeg.GetSlojNaSkwajne
    '    Dim lspProt As List(Of GranizaSlojIgeRealDwg) = wSkwajEnd.GetSlojNaSkwajne
    '    Dim lparam As LeseGeoIzDwg.ParamIge

    '    Dim lDeltaMejSkwaj = wSkwajEnd.Rastojnie - wSkwajBeg.Rastojnie

    '    Dim lrastTret = wSkwajBeg.Rastojnie + ShirinaWiw * lDeltaMejSkwaj
    '    Dim lotTret = wtrassaDwg.GetOtmetka(lrastTret)
    '    Dim lTochkaTret = New clsPrf.PointReal(lrastTret, lotTret)


    '    Dim lrastTretProt = wSkwajBeg.Rastojnie + ShirinaWiwProt * lDeltaMejSkwaj
    '    Dim lotTretProt = wtrassaDwg.GetOtmetka(lrastTret)
    '    Dim lTochkaTretProt = New clsPrf.PointReal(lrastTretProt, lotTretProt)



    '    Dim lSpNomerowProsmot As New List(Of Integer) ' Номера просмотренных слоев на противоположной стороне

    '    Dim lSohrGlubinSledProt As Double = wSkwajEnd.GlubinaPervogoSloj
    '    For i As Integer = 0 To lSp.Count - 1   'Цикл по слоям первой скважины 1
    '        Dim lindexIge As String = lSp(i).IndexIge
    '        lparam = fParamIge(lindexIge)
    '        'проверяем есть на противоположной стороне такоеже слой иге.
    '        Dim lindProt = -1
    '        For j As Integer = 0 To lspProt.Count - 1
    '            If lSpNomerowProsmot.IndexOf(j) >= 0 Then Continue For
    '            If lindexIge = lspProt(j).IndexIge Then
    '                lindProt = j
    '                Exit For
    '            End If

    '        Next j
    '        If lindProt > -1 Then ' существует противоположный

    '            Dim lglubinaSled = GlubinaSled(i, wSkwajBeg)
    '            Dim lglubinaSledProt = GlubinaSled(lindProt, wSkwajEnd)

    '            PerepisatSlojiGE(lSp(i), lspProt(lindProt), lglubinaSled, lglubinaSledProt, lparam)
    '            lSpNomerowProsmot.Add(lindProt)
    '            lSohrGlubinSledProt = lglubinaSledProt
    '        Else
    '            Dim lwspprot = New GranizaSlojIgeRealDwg(wtrassaDwg, wSkwajBeg.GetKoorGeo.Koeff, lTochkaTret, LinijnajProporzij(lSp(i).Glubina, lSohrGlubinSledProt, ShirinaWiw), _
    '                                                   lindexIge)
    '            Dim lglubinaSled = GlubinaSled(i, wSkwajBeg)

    '            PerepisatSlojiGE(lSp(i), lwspprot, lglubinaSled, LinijnajProporzij(lglubinaSled, lSohrGlubinSledProt, ShirinaWiw), lparam)
    '        End If
    '    Next '1
    '    '  Дальше оставшиеся слои согласую со списком расмотреных выводим на треть.
    '    Dim lSohrGlubinSled As Double = wSkwajEnd.GlubinaPervogoSloj

    '    For i As Integer = 0 To lspProt.Count - 1
    '        Dim lindexIge = lspProt(i).IndexIge
    '        lparam = fParamIge(lindexIge)
    '        If lSpNomerowProsmot.IndexOf(i) < 0 Then
    '            Dim lglubinaSled = GlubinaSled(i, wSkwajEnd)
    '            Dim lwsp = New GranizaSlojIgeRealDwg(wtrassaDwg, wSkwajBeg.GetKoorGeo.Koeff, lTochkaTretProt, LinijnajProporzij(lSohrGlubinSled, lspProt(i).Glubina, ShirinaWiwProt), _
    '                                                lindexIge)
    '            PerepisatSlojiGE(lwsp, lspProt(i), LinijnajProporzij(lglubinaSled, lSohrGlubinSled, ShirinaWiw), lglubinaSled, lparam)
    '        Else
    '            Dim llindex = NajtiNum(lindexIge, lSp)
    '            lSohrGlubinSled = GlubinaSled(llindex, wSkwajBeg)
    '        End If
    '    Next

    'End Sub

    Sub Perepisat()
       
        Dim lprWiw = wSkwajBeg.Tip = modelGeo.TipSkwajn.Ogran And wSkwajEnd.Tip = modelGeo.TipSkwajn.Ogran
        If lprWiw Then
            wSkwajBeg.WiwestiMetkuSkwajWdwg()
            Return

        End If
        wSkwajBeg.WiwestiSkwajWdwg()
        '  
        wSkwajBeg.WiwestiMej(wSkwajEnd)
        '  PerepisatSloj()
        PerepisatWseKontura()

    End Sub

    Function ObejdenitPoWsem(isp As List(Of KonturIge)) As Boolean
        For i = 0 To isp.Count - 2
            For j = i + 1 To isp.Count - 1
                Dim lw = isp(i).Obedenit(isp(j))
                If lw IsNot Nothing Then
                    'Вмест i того lw
                    isp(i) = lw
                    isp.RemoveAt(j)
                    Return True
                End If
            Next
        Next
        Return False
    End Function
    Sub PerepisatWseKontura()
        'Можно упростить функцию  WiwParSkwaj:PerepisatWseKontura Использовав только ObejdenitPoWsem(lkontOb)

        'между ограничивающей и условной не выводим
        Dim lprWiw = wSkwajBeg.Tip > modelGeo.TipSkwajn.dlajKlin And wSkwajEnd.Tip >= modelGeo.TipSkwajn.dlajKlin
        lprWiw = lprWiw Or wSkwajBeg.Tip >= modelGeo.TipSkwajn.dlajKlin And wSkwajEnd.Tip > modelGeo.TipSkwajn.dlajKlin
        If lprWiw Then Return
        ParaGranizTochek.Init(wtrassaDwg, wmodelGeo)
        Dim lKontWnesch As New List(Of KonturIge)
        Dim lKontWnutr As New List(Of KonturIge)
        Dim lp = ParaGranizTochek.SozdatSpisokPar(wSkwajBeg.GetWseGraniz, wSkwajEnd.GetWseGraniz)
        If lp.Count < 2 Then Return
        Dim lCount As Integer = lp.Count - 2
        If lp(lCount).SrawnitPoGlubine(lp(lCount + 1)) <> -1 Then lCount -= 1




        For i As Integer = 0 To lCount
            If lp(i).SrawnitPoGlubine(lp(i + 1)) = -1 Then
                '  If i < lCount Then
                lp(i).RaspedKontur(lp(i + 1), lKontWnesch, lKontWnutr)
            End If

        Next
        Dim lkontOb As New List(Of KonturIge)
        Dim j As Integer = 0
        lkontOb.Add(lKontWnesch.First)
        Do While j < lKontWnesch.Count - 1

            Dim lw = lkontOb.Last.Obedenit(lKontWnesch(j + 1))
            If lw Is Nothing Then
                lkontOb.Add(lKontWnesch(j + 1))

            Else
                lkontOb.Remove(lkontOb.Last)
                lkontOb.Add(lw)
            End If
            j += 1
        Loop
        '     Dim lwpr = ObejdenitPoWsem(lkontOb)  'нужно повторять процедуру пока не вернет ложь
        Do
            'Dim lwpr = ObejdenitPoWsem(lkontOb)  'нужно повторять процедуру пока не вернет ложь
            'If lwpr = False Then Exit Do
        Loop While ObejdenitPoWsem(lkontOb)


        For Each l As KonturIge In lkontOb
            If Not l.Equals(lkontOb.Last) Then
                GranizaSlojIgeRealDwg.WiwestiHatchIge(l, lp(0).fParamIge(l.indexige), True, True)
            Else
                GranizaSlojIgeRealDwg.WiwestiHatchIge(l, lp(0).fParamIge(l.indexige), False, True)
            End If

        Next
        For Each l As KonturIge In lKontWnutr
            GranizaSlojIgeRealDwg.WiwestiHatchIge(l, lp(0).fParamIge(l.indexige), True, True)
        Next

    End Sub
#Region "в дальнейшем убрать  закоментировано "
    ' Private Sub PerepisatSloj()
    '    If wSkwajBeg.Tip > modelGeo.TipSkwajn.Uslow And wSkwajEnd.Tip >= modelGeo.TipSkwajn.Uslow Then Return
    '    If wSkwajBeg.Tip >= modelGeo.TipSkwajn.Uslow And wSkwajEnd.Tip > modelGeo.TipSkwajn.Uslow Then Return


    '    ParaGranizTochek.Init(wtrassaDwg, wmodelGeo)
    '    Dim lp = ParaGranizTochek.SozdatSpisokPar(wSkwajBeg.GetWseGraniz, wSkwajEnd.GetWseGraniz)

    '    Dim lCount As Integer = lp.Count - 2
    '    If lp(lCount).SrawnitPoGlubine(lp(lCount + 1)) <> -1 Then lCount -= 1




    '    For i As Integer = 0 To lCount
    '        If lp(i).SrawnitPoGlubine(lp(i + 1)) = -1 Then
    '            If i < lCount Then
    '                lp(i).WiwestiDwg(lp(i + 1), True)

    '            Else
    '                lp(i).WiwestiDwg(lp(i + 1), False)
    '            End If
    '        End If




    '    Next
    'End Sub

    'Sub Perepisat0()
    '    Dim lprWiw = wSkwajBeg.Tip > modelGeo.TipSkwajn.Uslow And wSkwajEnd.Tip >= modelGeo.TipSkwajn.Uslow
    '    lprWiw = lprWiw Or wSkwajBeg.Tip >= modelGeo.TipSkwajn.Uslow And wSkwajEnd.Tip > modelGeo.TipSkwajn.Uslow
    '    If lprWiw Then
    '        wSkwajBeg.WiwestiMetkuSkwajWdwg()
    '        Return

    '    End If
    '    wSkwajBeg.WiwestiSkwajWdwg()
    '    '  
    '    wSkwajBeg.WiwestiMej(wSkwajEnd)
    '    'ParaGranizTochek.Init(wtrassaDwg, wmodelGeo)
    '    'Dim lp = ParaGranizTochek.SozdatSpisokPar(wSkwajBeg.GetWseGraniz, wSkwajEnd.GetWseGraniz)

    '    'Dim lCount As Integer = lp.Count - 2
    '    'If lp(lCount).SrawnitPoGlubine(lp(lCount + 1)) <> -1 Then lCount -= 1




    '    'For i As Integer = 0 To lCount
    '    '    If lp(i).SrawnitPoGlubine(lp(i + 1)) = -1 Then
    '    '        If i < lCount Then
    '    '            lp(i).WiwestiDwg0(lp(i + 1), True)

    '    '        Else
    '    '            lp(i).WiwestiDwg0(lp(i + 1), False)
    '    '        End If
    '    '    End If
    '    'Next
    '    PerepisatWseKontura()
    'End Sub
    'Private Sub PerepisatSloj0()
    '    If wSkwajBeg.Tip > modelGeo.TipSkwajn.Uslow And wSkwajEnd.Tip >= modelGeo.TipSkwajn.Uslow Then Return
    '    If wSkwajBeg.Tip >= modelGeo.TipSkwajn.Uslow And wSkwajEnd.Tip > modelGeo.TipSkwajn.Uslow Then Return


    '    ParaGranizTochek.Init(wtrassaDwg, wmodelGeo)
    '    Dim lp = ParaGranizTochek.SozdatSpisokPar(wSkwajBeg.GetWseGraniz, wSkwajEnd.GetWseGraniz)

    '    Dim lCount As Integer = lp.Count - 2
    '    If lp(lCount).SrawnitPoGlubine(lp(lCount + 1)) <> -1 Then lCount -= 1




    '    For i As Integer = 0 To lCount
    '        If lp(i).SrawnitPoGlubine(lp(i + 1)) = -1 Then
    '            If i < lCount Then
    '                lp(i).WiwestiDwg0(lp(i + 1), True)

    '            Else
    '                lp(i).WiwestiDwg0(lp(i + 1), False)
    '            End If
    '        End If




    '    Next
    'End Sub

#End Region
    Sub wiwestiBeg()
        wSkwajBeg.WiwestiSkwajWdwg()
        '  wSkwajBeg.wiwestiOtmetkiSloew(SkwajnaRealDwg.NameSlojDwGIndexIGE)
    End Sub
    Sub wiwestiend()
        wSkwajEnd.WiwestiSkwajWdwg()
        '   wSkwajEnd.wiwestiOtmetkiSloew(SkwajnaRealDwg.NameSlojDwGIndexIGE)
    End Sub
    'Private Function GlubinaXdwg(iX As Double, iGlubinaBeg As Double, iglubinaEnd As Double) As Double


    '    If iX < wSkwajBeg.Rastojnie Then Return iGlubinaBeg
    '    If iX > wSkwajEnd.Rastojnie Then Return iglubinaEnd
    '    Dim delta As Double = iX - wSkwajBeg.Rastojnie

    '    Return iGlubinaBeg + delta * (iglubinaEnd - iGlubinaBeg) / (wSkwajEnd.Rastojnie - wSkwajBeg.Rastojnie)
    'End Function

    'Private Function GetSloiIgeMejdyW(iRasst As Double) As List(Of GranizaSlojIgeRealDwg)
    '    Dim lSp As List(Of GranizaSlojIgeRealDwg) = wSkwajBeg.GetSlojNaSkwajne
    '    Dim lspProt As List(Of GranizaSlojIgeRealDwg) = wSkwajEnd.GetSlojNaSkwajne
    '    Dim lspSlojwMejdu As New List(Of GranizaSlojIgeRealDwg)
    '    Dim lparam As LeseGeoIzDwg.ParamIge
    '    Dim lcomparator As New ComparatorGranizSlojIgeRealGlubin
    '    Dim lDeltaMejSkwaj = wSkwajEnd.Rastojnie - wSkwajBeg.Rastojnie

    '    If iRasst < wSkwajBeg.Rastojnie Or iRasst > wSkwajEnd.Rastojnie Then iRasst = wSkwajBeg.Rastojnie + 0.5 * lDeltaMejSkwaj


    '    Dim lotMejdu = wtrassaDwg.GetOtmetka(iRasst)
    '    Dim lTochkaMejdu = New clsPrf.PointReal(iRasst, lotMejdu)






    '    Dim lSpNomerowProsmot As New List(Of Integer)
    '    Dim lSohrGlubinSledProt As Double = wSkwajEnd.GlubinaPervogoSloj

    '    For i As Integer = 0 To lSp.Count - 1
    '        Dim lindexIge As String = lSp(i).IndexIge
    '        lparam = fParamIge(lindexIge)
    '        'проверяем есть на противоположной стороне такоеже слой иге.
    '        Dim lindProt = -1
    '        For j As Integer = 0 To lspProt.Count - 1
    '            If lSpNomerowProsmot.IndexOf(j) >= 0 Then Continue For
    '            If lindexIge = lspProt(j).IndexIge Then
    '                lindProt = j
    '                Exit For
    '            End If

    '        Next j




    '        If lindProt > -1 Then ' существует противоположный

    '            Dim lglubinaSled = GlubinaSled(i, wSkwajBeg)
    '            Dim lglubinaSledProt = GlubinaSled(lindProt, wSkwajEnd)


    '            Dim lwspprot = New GranizaSlojIgeRealDwg(wtrassaDwg, wSkwajBeg.GetKoorGeo.Koeff, lTochkaMejdu, GlubinaXdwg(iRasst, lSp(i).Glubina, lspProt(lindProt).Glubina), _
    '                                                 lindexIge)
    '            lspSlojwMejdu.Add(lwspprot)
    '            ComparatorGranizSlojIgeRealGlubin.SearchAndInsert(lspSlojwMejdu, lwspprot, lcomparator)
    '            lSohrGlubinSledProt = lglubinaSledProt
    '            lSpNomerowProsmot.Add(lindProt)
    '        Else
    '            Dim lwspprot = New GranizaSlojIgeRealDwg(wtrassaDwg, wSkwajBeg.GetKoorGeo.Koeff, lTochkaMejdu, GlubinaXdwg(iRasst, lSp(i).Glubina, lSohrGlubinSledProt), _
    '                                                   lindexIge)
    '            ComparatorGranizSlojIgeRealGlubin.SearchAndInsert(lspSlojwMejdu, lwspprot, lcomparator)
    '            Dim lglubinaSled = GlubinaSled(i, wSkwajBeg)


    '        End If
    '    Next

    '    Dim lSohrGlubinSled As Double = wSkwajEnd.GlubinaPervogoSloj
    '    For i As Integer = 0 To lspProt.Count - 1
    '        Dim lindexIge = lspProt(i).IndexIge
    '        lparam = fParamIge(lindexIge)
    '        If lSpNomerowProsmot.IndexOf(i) < 0 Then
    '            Dim lglubinaSled = GlubinaSled(i, wSkwajEnd)
    '            Dim lwsp = New GranizaSlojIgeRealDwg(wtrassaDwg, wSkwajBeg.GetKoorGeo.Koeff, lTochkaMejdu, GlubinaXdwg(iRasst, lSohrGlubinSled, lspProt(i).Glubina), _
    '                                                lindexIge)
    '            ComparatorGranizSlojIgeRealGlubin.SearchAndInsert(lspSlojwMejdu, lwsp, lcomparator)

    '        Else
    '            Dim llindex = NajtiNum(lindexIge, lSp)
    '            lSohrGlubinSled = GlubinaSled(llindex, wSkwajBeg)
    '        End If
    '    Next
    '    ParaGraniz.Init(wtrassaDwg, wdsGeologij)
    '    Dim lp = ParaGraniz.SozdatSpisokPar(lSp, lspProt)
    '    Return lspSlojwMejdu
    'End Function
    Function GetSloiIgeMejdy(iRasst As Double, ByRef pGlub As Double) As List(Of GranizaSlojIgeRealDwg)
        Dim lSp As List(Of GranizaSlojIgeRealDwg) = wSkwajBeg.GetWseGraniz
        Dim lspProt As List(Of GranizaSlojIgeRealDwg) = wSkwajEnd.GetWseGraniz
        Dim lspSlojwMejdu As New List(Of GranizaSlojIgeRealDwg)

        Dim lcomparator As New ComparatorGranizSlojIgeRealGlubin
        Dim lDeltaMejSkwaj = wSkwajEnd.Rastojnie - wSkwajBeg.Rastojnie

        If iRasst < wSkwajBeg.Rastojnie Or iRasst > wSkwajEnd.Rastojnie Then iRasst = wSkwajBeg.Rastojnie + 0.5 * lDeltaMejSkwaj


        Dim lotMejdu = wtrassaDwg.GetOtmetka(iRasst)
        Dim lTochkaMejdu = New clsPrf.PointReal(iRasst, lotMejdu)



        ParaGranizTochek.Init(wtrassaDwg, wmodelGeo)
        Dim lp = ParaGranizTochek.SozdatSpisokPar(lSp, lspProt)
        For i As Integer = 0 To lp.Count - 2
            If lp(i).SrawnitPoGlubine(lp(i + 1)) = -1 Then

                Dim wSp As List(Of GranizaSlojIgeRealDwg) = lp(i).SloiMejdu(lp(i + 1), lTochkaMejdu)
                For Each el As GranizaSlojIgeRealDwg In wSp
                    ComparatorGranizSlojIgeRealGlubin.SearchAndInsert(lspSlojwMejdu, el, lcomparator)
                Next

            End If




        Next
        pGlub = lp.Last.GlubinaAprX(lTochkaMejdu.X)
        Return lspSlojwMejdu
    End Function
End Class
