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

Public Class ObrazGeologii
    Inherits ObrazGeologii_Bas
    Private wSpSkwaj As New List(Of LeseGeoIzDwg.ObrazSkwajn)
    Private wSpMejSkwajn As New List(Of Integer)


#Region "ReadOnly"

    ReadOnly Property SpSkwajn() As List(Of ObrazSkwajn)
        Get
            Return wSpSkwaj
        End Get
    End Property
    ''' <summary>
    ''' Список всех наименований Игэ.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetSpisokNaimenowanij() As List(Of String)
        Dim lSpisok As New List(Of String)
        For Each el As SlojIgeDwg In GetSloiIge()
            SearchAndInsert(lSpisok, el.IndexIge)
        Next
        Return lSpisok
    End Function
    Function GetSpisokParamIge() As List(Of ParamIge)

        Return wSpParamiGE
    End Function
#End Region

#Region "Построение Konstructor"
    Private Sub utochit()
        'Проверяет на наличие повторов Игэ  Разные штриховки с одинаковыми ИГЭ
        Dim lpr = True
        Do While lpr
            lpr = False
            For Each el As ParamIge In wSpParamiGE
                Dim l = From p As ParamIge In wSpParamiGE Where p.IndexIge = el.IndexIge Select p
                Dim ll = l.ToArray

                If ll IsNot Nothing Then
                    Dim lrazm = ll.Count
                    If lrazm > 1 Then
                        For i = 0 To ll.Count - 1
                            If Not el.Equals(ll(i)) Then
                                ll(i).SetIndexIge(ll(i).IndexIge & "#" & CStr(i))
                                lpr = True
                            End If


                        Next

                        Exit For

                    End If
                End If

            Next
        Loop
    End Sub
    Private Sub UstSpisokParamIge()

        Dim dc As New ComparatorParamIge
        Dim dcIm As New ComparatorIndexIge
        Dim lPost As Integer = 0
        For Each el As SlojIgeDwg In GetSloiIge()
            ComparatorParamIge.SearchAndInsert(wSpParamiGE, New ParamIge(el, modelGeo.TipOpred.WozwrastPoDefault), dc)
        Next
        '   Dim lParam = New ParamIge(el, modelGeo.TipOpred.WozwrastPoDefault)
        Dim lmasSp(wSpParamiGE.Count) As List(Of SlojIgeDwg)
        For i As Integer = 0 To wSpParamiGE.Count
            lmasSp(i) = New List(Of SlojIgeDwg)
        Next
        For Each el As SlojIgeDwg In GetSloiIge()
            Dim ind = wSpParamiGE.BinarySearch(New ParamIge(el, modelGeo.TipOpred.WozwrastPoDefault), dc)

            If ind > -1 Then

                lmasSp(ind).Add(el)
            Else
                MsgBox(Me.ToString & "   " & el.IndexIge)

            End If



        Next



        utochit()
        For i As Integer = 0 To wSpParamiGE.Count
            If lmasSp(i).Count > 0 Then
                If Not wSpParamiGE(i).IndexIge.Equals(lmasSp(i)(0)) Then
                    For Each el As SlojIgeDwg In lmasSp(i)
                        el.SetIndex(wSpParamiGE(i).IndexIge)
                    Next
                End If

            End If


        Next
    End Sub

    Private Sub UstWozrastParamIge(iMtextWozrast As List(Of MText))


        ' добавление возраста в параметр ИГЭ 
        For Each el As SlojIgeDwg In GetSloiIge()
            For Each elm As MText In iMtextWozrast
                If el.Wnutri(elm) Then
                    For Each elp As ParamIge In wSpParamiGE
                        If elp.IndexIge = el.IndexIge Then elp.Wozrast = elm.Text
                    Next
                End If

            Next
        Next

    End Sub
  

    Shared Sub OpredelitOtmetkiGlubiniIgeNaSkwajne(iMtext As List(Of MText), iSpObraz As List(Of PostroenijSkwajEntity))
        For Each el As PostroenijSkwajEntity In iSpObraz
            For Each elm As MText In iMtext
                If el.AddMtextOtmetokGlubin(elm) Then
                    Dim d = elm.Text

                End If
            Next
            For Each elm1 As MText In el.GetGlubin
                iMtext.Remove(elm1)
            Next
            For Each elm1 As MText In el.GetOtmetki
                iMtext.Remove(elm1)
            Next
        Next


    End Sub
    Shared Sub OpredelitOtmetkiGlubiniIgeNaSkwajne(iMLeder As List(Of Entity), iSpObraz As List(Of PostroenijSkwajEntity))
        For Each el As PostroenijSkwajEntity In iSpObraz
            Dim lelWkl As New List(Of MLeader)
            For Each elm As MLeader In iMLeder
                If el.AddMtextOtmetokGlubin(elm) Then
                    lelWkl.Add(elm)
                End If

            Next
            For Each elm1 As MLeader In lelWkl
                iMLeder.Remove(elm1)
            Next

        Next


    End Sub
    Private Sub PostroitSpisokSkwajn(iMtextImenaSkwajn As List(Of MText), iSpZnakowSkwal As List(Of Entity), iSpObraz As List(Of PostroenijSkwajEntity))
        Dim lskwajPred As ObrazSkwajn = Nothing
        For Each el As LeseGeoIzDwg.PostroenijSkwajEntity In iSpObraz
            Dim lSkwaj = New ObrazSkwajn(el)
            Dim lbliz As Double = lSkwaj.NajtiImj(iMtextImenaSkwajn)

            Dim lblizBl As Double = lSkwaj.OpredTip(iSpZnakowSkwal)
            Dim Lmejdu = 100.0
            If lskwajPred IsNot Nothing Then
                Lmejdu = lSkwaj.ZentrSkwajnDwg - lskwajPred.ZentrSkwajnDwg
            End If

            wSpSkwaj.Add(lSkwaj)
            lskwajPred = lSkwaj
            If Math.Abs(lbliz) > 0.25 * Lmejdu Then
                Application.ShowAlertDialog(Me.ToString & "Имя скважины " & lSkwaj.NameSkwaj & " расположенjq на чертеже в X " & Format(lSkwaj.ZentrSkwajnDwg, "f1") _
                                            & " слишком далеко от центра образа скважины  delta " & Format(lbliz, "f1"))
            Else
                iMtextImenaSkwajn.Remove(lSkwaj.GetMtextImeni)
            End If
        Next
        If iMtextImenaSkwajn.Count > 0 Then
            Dim lstr As String = "Имена Cкважин с X(в единицах чертежа) следует проверить.  " & vbCr
            For Each el As MText In iMtextImenaSkwajn
                lstr &= el.Text & "  " & Format(el.Location.X, "f1") & vbCr

            Next
            Application.ShowAlertDialog(Me.ToString & " " & lstr)

        End If
    End Sub

    ''' <summary>
    ''' Построение по примитивам представляющем геологию модели образа геологии
    ''' </summary>
    ''' <param name="SpEntHatcH"> Список штриховок в слое Гео_штрих </param>
    ''' <param name="SpMtext"> Список мультитекстов слоя гео условные  </param>
    ''' <param name="iSpObraz"> список  образов скважин созданых из примитивов чертежа  </param>
    ''' <remarks></remarks>
    Sub New(SpEntHatcH As List(Of Entity), SpMtext As List(Of Entity), iSpZnakowBlock As List(Of Entity), iSpObraz As List(Of PostroenijSkwajEntity))
        Dim lSpClsHatchIGE As List(Of clsHatch) = SozdatSpisokClsHatch(SpEntHatcH)     'Определяем ограничения границы  штриховок ИГЭ
        Dim lWsegoHatchIge As Integer = lSpClsHatchIGE.Count      'количество штриховок ИГЕ нужно  для контроля результата


        Dim lComporatorMtext As New ComparatorPoMtext

        Dim lSpMtextSloj As New List(Of MText) 'Все мультитексты, которыми записан номер слоя ИгЭ 
        Dim lMtextOtmetokIGlubin As New List(Of MText) 'отбираються мультитексты отметок и глубин слоев на скважине
        Dim lMtextImenaSkwajn As New List(Of MText) 'наименования скважин
        Dim lMtextWozwrast As New List(Of MText) ' Обозначение возвраста
        For Each elm As MText In SpMtext      'Выборка из Мтекст слоя гео_условные
            If Char.IsDigit(elm.Text(0)) AndAlso Strings.InStr(elm.Text, ",") < 1 AndAlso Strings.InStr(elm.Text, ".") < 1 Then 'Ищем мульти тексты с наименванием  слоя ИГЭ  в имене слоя ИГЕ отсутствует запятая

                ComparatorPoMtext.SearchAndInsert(lSpMtextSloj, elm, lComporatorMtext)
                Continue For


            End If
            'Ищем имена  скважин 

            If ObrazSkwajn.ProwImeniSkwaj(elm) > 0 Then  ' Strings.InStr(lw, "скв.") > 0 OrElse Strings.InStr(lw, "cкв.") > 0 OrElse Strings.InStr(lw, "ш.") > 0 OrElse Strings.InStr(lw, "обн.") > 0 
                ' bPolyLineIPoint.ComparatorObrazSkwajnPoX.SearchAndInsert(wSpSkwaj, New bPolyLineIPoint.ObrazSkwajn(elm), lCompSkwajPoMText)
                BazDwg.ComparatorPoMtext.SearchAndInsert(lMtextImenaSkwajn, elm, lComporatorMtext)
                Continue For
            End If
            'отметки глубины
            If Char.IsDigit(elm.Text(0)) Then
                lMtextOtmetokIGlubin.Add(elm)
            End If
            If Char.IsLetter(elm.Text(0)) Then
                ComparatorPoMtext.SearchAndInsert(lMtextWozwrast, elm, lComporatorMtext)
            End If

        Next

        Dim lWsegoIdentifikatorIge As Integer = lSpMtextSloj.Count
        Dim lwsegoGlubinOtmetok As Integer = lMtextOtmetokIGlubin.Count
        Dim lwsegonaimenowanijSkwajn = lMtextImenaSkwajn.Count




        OpredelitOtmetkiGlubiniIgeNaSkwajne(lMtextOtmetokIGlubin, iSpObraz)

        PostroitSpisokSkwajn(lMtextImenaSkwajn, iSpZnakowBlock, iSpObraz)  'построили список скважин имеющих имена.




        Dim lSpisokNeopredIdentifikator = OpredelitSloiIge(lSpClsHatchIGE, lSpMtextSloj)
        'Dim l = From p As SlojIgeDwg In wSpSlojIge Where p.IndexIge = modelGeo.TipOpred.IndexIgePoDefault Select p

        'Dim lk = l.Count
        UstWozrastParamIge(lMtextWozwrast)
        RaspredPoIge()


        Dim lSoob As String = "Определено имен скважин " & lwsegonaimenowanijSkwajn _
                              & vbCr & "Скважин представленых в чертеже " & wSpSkwaj.Count _
                          & vbCr & "Определено слоев (штриховка идентификатор) " & wSpSlojIge.Count & "  Из " & lWsegoHatchIge _
                          & vbCr & " не использовались идентификаторов ИГЭ " & lSpisokNeopredIdentifikator.Count & " из " & lWsegoIdentifikatorIge _
                         & vbCr & "Всех  идетификаторов мульти текстов в слое Гео_условные" & SpMtext.Count _
                               & vbCr & "мульти текстов возвраста" & lMtextWozwrast.Count _
                         & vbCr & "неопределили  отметок и глубин " & lMtextOtmetokIGlubin.Count & " Из  " & lwsegoGlubinOtmetok

        Application.ShowAlertDialog(lSoob)
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="iGreben"></param>
    ''' <remarks></remarks>
    Sub UstanowitMej(iGreben As BazDwg.GrebenProfilDwg)
        Dim lCompObrazSkwajPoX As New LeseGeoIzDwg.ComparatorObrazSkwajnPoX
        For Each iX As Integer In wSpMejSkwajn

            LeseGeoIzDwg.ComparatorObrazSkwajnPoX.SearchAndInsert(wSpSkwaj, New ObrazSkwajn(iX, iGreben, Me), lCompObrazSkwajPoX)
        Next
        Dim lSkwajPred As ObrazSkwajn = Nothing
        For Each el As ObrazSkwajn In wSpSkwaj
            If lSkwajPred IsNot Nothing Then
                If Not Me.IsSlojIgeDwgWTochke(0.5 * (el.ZentrSkwajnDwg + lSkwajPred.ZentrSkwajnDwg)) Then

                    lSkwajPred.UstTipOgran()
                    el.UstTipOgran()
                End If
            End If
            lSkwajPred = el
        Next

    End Sub
    Shared Function NajtiPodobnuj(ispclshatch As List(Of SlojIgeDwg), iHatchIdent As clsHatch) As clsHatch

        Dim lhatchZadan As Hatch = iHatchIdent.GetHatch
        For Each ehatch As clsHatch In ispclshatch

            If ehatch.NeRawnPoParam(iHatchIdent) Then Continue For

            Return ehatch




        Next
        Return Nothing

    End Function
    Function najtiParamIGe(iclshatch As clsHatch) As ParamIge
        For Each el As ParamIge In wSpParamiGE
            If el.equalsParam(iclshatch.GetHatch()) Then Return el
        Next
        Return Nothing
    End Function

    Private Shared Function NajtiBlijajshuj(ispclshatch As List(Of clsHatch), iHatchIdent As SlojIgeDwg) As clsHatch
        'Находит рядом расположеную штриховку с неидентифицированным номером ИГЭ
        Dim lRastMin As Double = 10000.0
        Dim lHatchMin As clsHatch = Nothing

        For Each ehatch As clsHatch In ispclshatch

            If ehatch.NeRawnPoParam(iHatchIdent) Then Continue For


            Dim lrastX1 As Double = dbPrim.DistanzeX(ehatch.GetHatch, iHatchIdent.GetHatch)
            Dim lrastX2 As Double = dbPrim.DistanzeX(iHatchIdent.GetHatch, ehatch.GetHatch)
            Dim lrastX As Double = Math.Min(lrastX1, lrastX2)
            '  Dim lrastY As Double = HatchIdentifikator.DistanzeY(ehatch, lhatchZadan)
            If lrastX < lRastMin Then
                lHatchMin = ehatch
                lRastMin = lrastX
            End If
        Next
        Return lHatchMin
    End Function

    Private Shared Function NajtiBlijajshuj(iSpSlojIge As List(Of SlojIgeDwg), iHatchIdent As clsHatch) As clsHatch
        'Находит идентифицированый слой иге ближайший к заданой штриховки
        Dim lRastMin As Double = 10000.0
        Dim lHatchMin As clsHatch = Nothing

        For Each ehatch As clsHatch In iSpSlojIge

            If ehatch.NeRawnPoParam(iHatchIdent) Then Continue For


            Dim lrastX1 As Double = dbPrim.DistanzeX(ehatch.GetHatch, iHatchIdent.GetHatch)
            Dim lrastX2 As Double = dbPrim.DistanzeX(iHatchIdent.GetHatch, ehatch.GetHatch)
            Dim lrastX As Double = Math.Min(lrastX1, lrastX2)
            '  Dim lrastY As Double = HatchIdentifikator.DistanzeY(ehatch, lhatchZadan)
            If lrastX < lRastMin Then
                lHatchMin = ehatch
                lRastMin = lrastX
            End If
        Next
        Return lHatchMin
    End Function
    Dim wCompHatchIdent As New LeseGeoIzDwg.ComparatorSlojIgeDwg
    Private Function DobawitWSpisokPodobnie(iSpclsHatch As List(Of clsHatch), iSlojIgeDwg As SlojIgeDwg) As List(Of clsHatch)
        Dim lSpNeWkl As New List(Of clsHatch)
        For Each el As clsHatch In iSpclsHatch
            If el.NeRawnPoParam(iSlojIgeDwg) Then
                lSpNeWkl.Add(el)
            Else
                Dim lSlojIgeDwg As New LeseGeoIzDwg.SlojIgeDwg(el, iSlojIgeDwg.IndexIge)
                lSlojIgeDwg.OpredGranSloj(wSpSkwaj, wSpMejSkwajn)
                LeseGeoIzDwg.ComparatorSlojIgeDwg.SearchAndInsert(wSpSlojIge, lSlojIgeDwg, wCompHatchIdent) ' Вставляем в список слоев ИГЭ
            End If
        Next
        Return lSpNeWkl
    End Function
    Private Function OpredelitSloiIge(iSpclsHatch As List(Of clsHatch), iSpMtextSloj As List(Of MText)) As List(Of MText)
        'связывает штриховки с номерами ИгЭ
        Dim lSpisokNeopredIdentifikator As New List(Of MText)

        '  Dim lIcountOtl As Integer = 0
        Dim lFrmSoob As New modelGeo.FrmSoob
        lFrmSoob.LabelWseg.Text = CStr(iSpclsHatch.Count)
        lFrmSoob.Show()

        Dim lSlojIgeDwg As SlojIgeDwg = Nothing
        Do Until iSpMtextSloj.Count = 0     '   Ищем все штриховки в которых записан номер ИГЭ
            Dim elm1 As MText = iSpMtextSloj(0)  '  Выбрали  мультитекст
            '   Dim owrS = CInt(elm1.Location.X)  'для отладки

            For Each elH As clsHatch In iSpclsHatch      ' Цикл по штриховкам представляющих ИГЭ
                'Dim olRb = elH.RastOtNachalaDwgBeg для отладки
                'Dim olRe = elH.RastOtNachalaDWGEnd
                If elH.Wnutri(elm1) Then
                    '                Dim wr = elH.GetPeresecheniePl(elm1.Location.X)
                    lSlojIgeDwg = New LeseGeoIzDwg.SlojIgeDwg(elH, elm1)
                    lSlojIgeDwg.OpredGranSloj(wSpSkwaj, wSpMejSkwajn)


                    LeseGeoIzDwg.ComparatorSlojIgeDwg.SearchAndInsert(wSpSlojIge, lSlojIgeDwg, wCompHatchIdent) ' Вставляем в список слоев ИГЭ
                    iSpclsHatch.Remove(elH) ' Удаляем штриховку ис списка найденых
                    iSpMtextSloj.Remove(elm1) ' Удаляем мультитекст списка найденых

                    Continue Do
                    '     End If

                End If
            Next
            ' Для мультитекста не найдена штриховка удаляем из списка найденых в чертеже и добавляем в список неопределившихся идентификаторов.
            iSpMtextSloj.Remove(elm1)

            lSpisokNeopredIdentifikator.Add(elm1)
        Loop
        UstSpisokParamIge()
        ' Доутачняем список слоев ИГЭ по параметрам уже найденым.
        Do Until iSpclsHatch.Count = 0  ' 
            Dim blijzHatch As clsHatch = Nothing  ' ближайшая штриховка с подходящими параметрами
            Dim lOpredSlojIgeDwg As LeseGeoIzDwg.SlojIgeDwg = Nothing  ' Определеный образ слоя ИГЭ в чертеже 

            For Each elm As clsHatch In iSpclsHatch
                'Dim elIgeBlij = CType(NajtiPodobnuj(wSpSlojIge, elm), SlojIgeDwg)
                Dim lparam = najtiParamIGe(elm)
                If lparam IsNot Nothing Then
                    lOpredSlojIgeDwg = New LeseGeoIzDwg.SlojIgeDwg(elm, lparam.IndexIge)
                    lOpredSlojIgeDwg.OpredGranSloj(wSpSkwaj, wSpMejSkwajn)
                    blijzHatch = elm
                    Exit For
                End If



            Next

            If lOpredSlojIgeDwg Is Nothing Then
                Exit Do
            Else
                iSpclsHatch.Remove(blijzHatch)
                lFrmSoob.Label1.Text = CStr(iSpclsHatch.Count)
                lFrmSoob.Label1.Refresh()
                LeseGeoIzDwg.ComparatorSlojIgeDwg.SearchAndInsert(wSpSlojIge, lOpredSlojIgeDwg, wCompHatchIdent)
            End If
        Loop
        Dim lSp As New List(Of SlojIgeDwg)
        For Each ehatch As clsHatch In iSpclsHatch  ' доопределяем оставшиеся слои 
            If lSp.Count = 0 Then
                Dim lindiGE = "#0" & Strings.Left(ehatch.OpredParamHatch.PatternName, 2)
                Dim elhatchIdent As New LeseGeoIzDwg.SlojIgeDwg(ehatch, lindiGE)    'modelGeo.TipOpred.IndexIgePoDefault
                elhatchIdent.OpredGranSloj(wSpSkwaj, wSpMejSkwajn)
                LeseGeoIzDwg.ComparatorSlojIgeDwg.SearchAndInsert(wSpSlojIge, elhatchIdent, wCompHatchIdent)
                lSp.Add(elhatchIdent)
                wSpParamiGE.Add(New ParamIge(elhatchIdent, modelGeo.TipOpred.WozwrastPoDefault))

            Else
                Dim lobraz As SlojIgeDwg = Nothing
                Dim lp = najtiParamIGe(ehatch)
                'For Each eel As SlojIgeDwg In lSp
                '    If Not eel.NeRawnPoParam(ehatch) Then
                '        lobraz = eel
                '        Exit For
                '    End If
                'Next
                If lp IsNot Nothing Then
                    Dim elhatchIdent As New LeseGeoIzDwg.SlojIgeDwg(ehatch, lp.IndexIge)    'modelGeo.TipOpred.IndexIgePoDefault

                    elhatchIdent.OpredGranSloj(wSpSkwaj, wSpMejSkwajn)
                    LeseGeoIzDwg.ComparatorSlojIgeDwg.SearchAndInsert(wSpSlojIge, elhatchIdent, wCompHatchIdent)
                Else
                    Dim lindiGE = "#" & lSp.Count & Strings.Left(ehatch.OpredParamHatch.PatternName, 2)
                    Dim elhatchIdent As New LeseGeoIzDwg.SlojIgeDwg(ehatch, lindiGE)    'modelGeo.TipOpred.IndexIgePoDefault
                    elhatchIdent.OpredGranSloj(wSpSkwaj, wSpMejSkwajn)
                    LeseGeoIzDwg.ComparatorSlojIgeDwg.SearchAndInsert(wSpSlojIge, elhatchIdent, wCompHatchIdent)
                    lSp.Add(elhatchIdent)
                    wSpParamiGE.Add(New ParamIge(elhatchIdent, modelGeo.TipOpred.WozwrastPoDefault))
                End If


            End If

        Next
        lFrmSoob.Close()
        Return lSpisokNeopredIdentifikator
    End Function

#End Region
#Region "Poisk"
    Dim lXdwg As Double
    Private Function KritPoiska(iSqj As ObrazSkwajn) As Boolean
        If iSqj.ZentrSkwajnDwg >= lXdwg Then Return True Else Return False
    End Function
    Function GetIndexSkwajnPosle(iXdwg As Double) As Integer
        lXdwg = iXdwg
        Return wSpSkwaj.FindIndex(AddressOf KritPoiska)



    End Function
    Function GetSkwajnPosle(iXdwg As Double) As ObrazSkwajn
        lXdwg = iXdwg
        Dim lindex = wSpSkwaj.FindIndex(AddressOf KritPoiska)
        If lindex > -1 Then
            Return wSpSkwaj(lindex)
        Else
            Return Nothing
        End If


    End Function
    Function GetSkwajnDo(iXdwg As Double) As ObrazSkwajn
        lXdwg = iXdwg
        Dim lindex = wSpSkwaj.FindIndex(AddressOf KritPoiska)
        If lindex < 0 Then Return wSpSkwaj.Last
        If lindex = 0 Then Return Nothing
        Return wSpSkwaj(lindex - 1)
    End Function
#End Region
#Region "Геология в окрестностях точки Dwg"
    Private Function PointNaSkajne(iX As Double) As ObrazSkwajn
        'Если точка находиться на образе скважины то возвращает его иначе ничего.
        For Each el As LeseGeoIzDwg.ObrazSkwajn In wSpSkwaj
            If Math.Abs(iX - el.ZentrSkwajnDwg) <= LeseGeoIzDwg.ObrazGeologii.ShirinaObrazSkwajn + LeseGeoIzDwg.ObrazGeologii.DopuskGeoDwgX Then
                Return el
            End If
        Next
        Return Nothing
    End Function
    ''' <summary>
    ''' Находит слои Игэ расположеные под заданой точкой разрез по X
    ''' </summary>
    ''' <param name="iPoint"> заданая точка чертежа </param>
    ''' <returns>  Список образ разрезов слоев ИГэ в точке упорядоченый по возрастанию отметок. </returns>
    ''' <remarks></remarks>
    Function SpisokSlojIgeDwgWTochke(iPoint As Point3d) As List(Of RazrezSlojIgeDwg)
        Dim lCompSl As New LeseGeoIzDwg.ComparatorRazrezSlojIgeDwgY     ' Компаратор по  разрезов слоям игэ в чертеже
        Dim SpisokSlojw As New List(Of LeseGeoIzDwg.RazrezSlojIgeDwg)
        Dim lpoint As Point3d '= iPoint  '= ProvRaspolojenij(iPoint)
        Dim Lskwaj As ObrazSkwajn = PointNaSkajne(iPoint.X)
        If Lskwaj IsNot Nothing Then 'Если скважина совпадает с точкой то выводим разрезы подней
            For Each el As SlojIgeDwg In Lskwaj.SlojBeg
                SpisokSlojw.Add(New RazrezSlojIgeDwg(el))
            Next
            If SpisokSlojw.Count > 0 Then Return SpisokSlojw
        End If
        If Lskwaj IsNot Nothing Then 'Если скважина совпадает с точкой и ничего ненайдено то сдвигаем точку на ширину скважины 
            lpoint = New Point3d(Lskwaj.MinGraniza - DopuskGeoDwgX, iPoint.Y, iPoint.Z)   'эту if можно объеденить с предыдущей.
        Else
            lpoint = iPoint
        End If
        Dim lwsp = CInt(iPoint.X)

        For Each el As SlojIgeDwg In wSpSlojIge   '  Проходим по списку ИГЭ найденых слоев
            Dim lrazrez As RazrezSlojIgeDwg = Nothing
            If el.MejduX(lpoint.X) Then ' Для точек которые находяться в границах слоя получакм разрез 
                lrazrez = New LeseGeoIzDwg.RazrezSlojIgeDwg(lpoint.X, el)
            Else
                If Math.Abs(lwsp - CInt(el.RastOtNachalaDwgBeg)) < 2 Then
                    lrazrez = New LeseGeoIzDwg.RazrezSlojIgeDwg(el)

                Else
                    If Math.Abs(lwsp - CInt(el.RastOtNachalaDWGEnd)) < 2 Then
                        lrazrez = New LeseGeoIzDwg.RazrezSlojIgeDwg(el, True)
                    End If

                End If

            End If
            If lrazrez IsNot Nothing Then
                LeseGeoIzDwg.ComparatorRazrezSlojIgeDwgY.SearchAndInsert(SpisokSlojw, lrazrez, lCompSl)
            End If


        Next


        Return SpisokSlojw
    End Function
    ''' <summary>
    ''' проверяет есть ли слои Игэ в точке
    ''' </summary>
    ''' <param name="iXdwg"> заданая точка чертежа </param>
    ''' <returns>  Список образ разрезов слоев ИГэ в точке </returns>
    ''' <remarks></remarks>
    Private Function IsSlojIgeDwgWTochke(iXdwg As Double) As Boolean


        Dim lXdwg As Double '= iPoint  '= ProvRaspolojenij(iPoint)
        Dim Lskwaj As ObrazSkwajn = PointNaSkajne(iXdwg)
        If Lskwaj IsNot Nothing Then 'Если скважина совпадает с точкой то выводим разрезы подней
            Return True
        End If
        If Lskwaj IsNot Nothing Then 'Если скважина совпадает с точкой и ничего ненайдено то сдвигаем точку на ширину скважины 
            lXdwg = Lskwaj.MinGraniza - DopuskGeoDwgX
        Else
            lXdwg = iXdwg
        End If


        For Each el As SlojIgeDwg In wSpSlojIge   '  Проходим по списку ИГЭ найденых слоев

            If el.MejduX(lXdwg) Then ' Для точек которые находяться в границах слоя получакм разрез 
                Return True
            End If


        Next


        Return False
    End Function


    ''' <summary>
    ''' Определяет образ скважины после заданой координаты по X чертежа .
    ''' </summary>
    ''' <param name="iXdwg">  заданая координата  </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function OpredSkwajnuPosle(iXdwg As Double) As ObrazSkwajn
        Dim lIndexPosle As Integer = GetIndexSkwajnPosle(iXdwg)
        Dim lskwaj As ObrazSkwajn
        '  Dim lSpSpslojwPoSkwajne As New List(Of SlojIgeRealDwg)
        If lIndexPosle > -1 Then
            lskwaj = SpSkwajn(lIndexPosle)
        Else

            lskwaj = SpSkwajn(SpSkwajn.Count - 1)

        End If

        Return lskwaj

    End Function
#End Region
End Class
