#If ARX_APP Then
Imports Autodesk.AutoCAD.Geometry
#Else
Imports Teigha.Geometry
#End If


Enum IndexGraniz
    Werchnaj = 0
    Nijnaj = 1

End Enum
Class ComparatorEqualsPoint2d
    Implements IEqualityComparer(Of Point2d)


    Public Function Equals1(x As Point2d, y As Point2d) As Boolean Implements IEqualityComparer(Of Point2d).Equals
        If x.GetDistanceTo(y) < LeseGeoIzDwg.ObrazGeologii.KritBlizostiDwg Then Return True
        Return False
    End Function

    Public Function GetHashCode1(obj As Point2d) As Integer Implements IEqualityComparer(Of Point2d).GetHashCode
        Return obj.GetHashCode()
    End Function
End Class
''' <summary>
''' класс представляющий контур игэ выводимый в чертеж
''' </summary>
''' <remarks></remarks>
Public Class KonturIge
    ' Private wKonturWneh As KonturIge
    Private wWerh, wNiz As List(Of Point2d)
    Private wIndexIge As String
    Private wUroven As Integer
    Private wPointGrBeg, wPointGrEnd As Point2d
    ''' <summary>
    ''' контур штриховки
    ''' </summary>
    ''' <param name="iGran"> границы между которыми определяем контур штриховки </param>
    ''' <param name="iwerh"> список точек верхней границы </param>
    ''' <param name="iniz"> список точек нижней границы</param>
    ''' <param name="iPrWibGraniz"> параметры какой границы берем для определения параметров штриховки Истина - начальной </param>
    ''' <remarks></remarks>
    Sub New(iGran As GranizIge, iwerh As List(Of Point2d), iniz As List(Of Point2d), iPrWibGraniz As Boolean)
        wWerh = iwerh
        wNiz = iniz
        If iPrWibGraniz Then
            wIndexIge = iGran.IndexIgeBeg
            wUroven = iGran.UrovenBeg
        Else
            wIndexIge = iGran.IndexIgeProt
            wUroven = iGran.UrovenProt
        End If

        wPointGrBeg = iGran.PointBeg
        wPointGrEnd = iGran.PointEnd

    End Sub
    Private Sub New(iKontur As KonturIge, iwerh As List(Of Point2d), iniz As List(Of Point2d))
        wWerh = iwerh
        wNiz = iniz
        wIndexIge = iKontur.wIndexIge
        wUroven = iKontur.wUroven
        wPointGrBeg = iKontur.wPointGrBeg
        wPointGrEnd = iKontur.wPointGrEnd
    End Sub
    'Private Property KonturWneh() As KonturIge
  
    Function IsSlojUroven(b As KonturIge) As Boolean
        Return wIndexIge.Equals(b.wIndexIge) AndAlso Math.Abs(wUroven) = Math.Abs(b.wUroven)
    End Function
    ''' <summary>
    ''' объеденяет контура в один если имеют одинаковый ИГЭ и сопркасаеться нижняя граница одного и верхнея другого
    ''' </summary>
    ''' <param name="b"></param>
    ''' <returns> возвращает объедененый контур </returns>
    ''' <remarks></remarks>
    Function Obedenit(b As KonturIge) As KonturIge

        If Me.wIndexIge = b.wIndexIge Then   '          'IsSlojP(b)
            Dim lSpWerh, lSpBniz As List(Of Point2d)
            lSpWerh = New List(Of Point2d)(wWerh)
            lSpBniz = New List(Of Point2d)(b.wNiz)

            Dim lcNiz = wNiz.Count
            Dim NizMinusBwerh = New List(Of Point2d)(wNiz.Except(b.wWerh, New ComparatorEqualsPoint2d()))
            Dim lcnmb = NizMinusBwerh.Count
            If lcNiz = lcnmb Then Return Nothing

            Dim BwerhMinusNiz = New List(Of Point2d)(b.wWerh.Except(wNiz, New ComparatorEqualsPoint2d()))

            '   Dim lbmn = BwerhMinusNiz.Count

            If lcnmb = 0 Then      'NizMinusBwerh.Count = 0
                Return New KonturIge(Me, lSpWerh, New List(Of Point2d)(b.wNiz))
            End If
            If BwerhMinusNiz.Count = 0 Then

                If Math.Abs(NizMinusBwerh.Last.X - wWerh.First.X) < 1 Then

                    NizMinusBwerh.Insert(0, b.wWerh.First)
                    lSpBniz.AddRange(NizMinusBwerh)
                Else

                    NizMinusBwerh.Add(b.wWerh.Last)
                    lSpBniz.InsertRange(0, NizMinusBwerh)
                End If



                Return New KonturIge(Me, lSpWerh, lSpBniz)
            Else

                Return New KonturIge(Me, lSpWerh, New List(Of Point2d)(b.wNiz)) '     
            End If




        End If
        Return Nothing

    End Function
    ReadOnly Property KonturW As List(Of Point2d)
        Get
            Dim lKontur As List(Of Point2d)
            lKontur = New List(Of Point2d)(wWerh)
            lKontur.AddRange(wNiz)
            Return lKontur
        End Get
    End Property
    ReadOnly Property indexige As String
        Get
            Return wIndexIge
        End Get
    End Property
  
    ''' <summary>
    ''' Возвращает отметки пересекаемых границ контура в порядке возрастания Y
    ''' </summary>
    ''' <param name="iSp"> список точек границ контура </param>
    ''' <param name="iX"> X  координата точки </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function Peresechnie(iSp As List(Of Point2d), iX As Double) As List(Of Double)
        Dim lwsp As New List(Of Double)
        For i As Integer = 0 To iSp.Count - 2
            Dim elpred = iSp(i)
            Dim el = iSp(i + 1)
            If el.X < elpred.X Then
                elpred = el
                el = iSp(i)
            End If

            If iX >= elpred.X And iX <= el.X Then
                Dim l = BazDwg.GrebenProfilDwg.PointMejduPoint(elpred, el, iX)
                LeseGeoIzDwg.SearchAndInsert(Of Double)(lwsp, l.Y)
            End If
        Next
        Return lwsp
    End Function
    Private Const otstup As Double = LeseGeoIzDwg.ObrazGeologii.OkoloSkwajnDwg + 2
    ''' <summary>
    ''' находит точку в ниболее широкой части слоя, желательно не меньше rdist
    ''' </summary>
    ''' <param name="rDist"> критерий после выполнение функции ширина слоя в найденой точке </param>
    ''' <returns> возвращает найденую точку </returns>
    ''' <remarks></remarks>
    Function Centr(ByRef rDist As Double) As Point2d
        Dim lXb = wPointGrBeg.X
        Dim lxe = wPointGrEnd.X

        '  Dim lzentr = Point2d.Origin
        Dim lzentr = 0.5 * (wPointGrBeg + wPointGrEnd.GetAsVector)
        Dim lspProsmotr = wWerh.GetRange(0, wWerh.Count)
        For i As Integer = 0 To wWerh.Count - 2  'дополняем промежуточными точками чтобы расширить область поиска места для вывода индекса
            Dim lelb = wWerh(i)
            Dim lele = wWerh(i + 1)
            lspProsmotr.Add(BazDwg.GrebenProfilDwg.Slojt(0.25 * lelb, 0.75 * lele))
            lspProsmotr.Add(0.5 * (wWerh.First + wWerh.Last.GetAsVector))
            lspProsmotr.Add(BazDwg.GrebenProfilDwg.Slojt(0.75 * lelb, 0.25 * lele))
        Next

        For Each el As Point2d In lspProsmotr
            If el.X - lXb < otstup OrElse lxe - el.X < otstup Then Continue For
            Dim lwerh = Peresechnie(wWerh, el.X)
            If lwerh.Count <> 1 Then Continue For
            Dim lniz = Peresechnie(wNiz, el.X)
            If lniz.Count <> 1 Then Continue For

            Dim lotrNjn = New Point2d(el.X, lniz.Last)
            Dim ld = el.GetDistanceTo(lotrNjn)
            If ld > rDist Then
                rDist = ld
                lzentr = BazDwg.GrebenProfilDwg.Slojt(0.75 * el, 0.25 * lotrNjn)

            End If
        Next
        Return lzentr
    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
Public Class GranizIge
    Private wWerhnajPara As ParaGranizTochek
    Private wNijnajPara As ParaGranizTochek
    Private wSlojWnutri As GranizaSlojIgeRealDwg
    Private WGranizaWneschnaj() As List(Of Point2d)
    Private WGranizaWnutrjanaj() As List(Of Point2d)
    Private wpointWerh, wpointNijn, wpointwstawki As Point2d
    Private wdistWerh, wdistNiz As Double
    Private WspKontur As New List(Of KonturIge)
    Sub New(iWerhnajPara As ParaGranizTochek, iNijnajjPara As ParaGranizTochek, iWnutrGr As GranizaSlojIgeRealDwg)
        wWerhnajPara = iWerhnajPara
        wNijnajPara = iNijnajjPara

        With wWerhnajPara
            WGranizaWneschnaj = .Beg.GranizDlaHatch(.Prot, wNijnajPara.Beg.Glubina, wNijnajPara.Prot.Glubina)
        End With
        If iWnutrGr IsNot Nothing Then
            wSlojWnutri = iWnutrGr
            wpointwstawki = wSlojWnutri.PointNaGranizDlaHatch(wWerhnajPara.Prot, wSlojWnutri.Rastojnie)
            With wWerhnajPara

                wpointWerh = .Beg.PointNaGranizDlaHatch(.Prot, iWnutrGr.Rastojnie)
            End With
            With wNijnajPara

                wpointNijn = .Beg.PointNaGranizDlaHatch(.Prot, iWnutrGr.Rastojnie)
            End With
            wdistWerh = wpointWerh.GetDistanceTo(wpointwstawki)
            wdistNiz = wpointNijn.GetDistanceTo(wpointwstawki)
        End If
    End Sub
    ''' <summary>
    ''' Точка на верхней границе игэ соответствующая точки выклинивания
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property PointW() As Point2d
        Get
            Return wpointWerh
        End Get
    End Property
    ''' <summary>
    ''' Точка на нижней границе игэ соответствующая точки выклинивания
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property PointN() As Point2d
        Get
            Return wpointNijn
        End Get
    End Property
    ''' <summary>
    ''' точка выклинивания
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property PointWstawki() As Point2d
        Get
            Return wpointwstawki
        End Get
    End Property
    ReadOnly Property IndexIgeBeg() As String
        Get
            Return wWerhnajPara.Beg.IndexIge
        End Get

    End Property
    ReadOnly Property UrovenBeg() As Integer
        Get
            Return wWerhnajPara.Beg.Uroven
        End Get

    End Property
    ReadOnly Property IndexIgeProt() As String
        Get
            Return wWerhnajPara.Prot.IndexIge
        End Get

    End Property
    ReadOnly Property UrovenProt() As Integer
        Get
            Return wWerhnajPara.Prot.Uroven
        End Get

    End Property
    ''' <summary>
    ''' Направление выклинивания
    ''' </summary>
    ''' <value></value>
    ''' <returns> 0 - нет выклинивания 1- выклинивание от начала -1 - выклинивание отконца  </returns>
    ''' <remarks></remarks>
    ReadOnly Property Napr() As Integer
        Get
            If wSlojWnutri Is Nothing Then Return 0
            If wWerhnajPara.Beg.IndexIge = wSlojWnutri.IndexIge And TolschinaBeg > modelGeo.TipOpred.MinTolschina Then Return 1
            If wWerhnajPara.Prot.IndexIge = wSlojWnutri.IndexIge And TolschinaEnd > modelGeo.TipOpred.MinTolschina Then Return -1
            Return 0
        End Get
    End Property
    Private Function Widelit(iSp1 As List(Of Point2d), isp2 As List(Of Point2d)) As List(Of Point2d)
        Dim lsp As New List(Of Point2d)
        Dim aPer = isp2.Last
        lsp.Add(aPer)
        For Each el As Point2d In iSp1
            If el.X > aPer.X Then lsp.Add(el)
        Next
        Return lsp
    End Function
    Private Function WidelitM(iSp1 As List(Of Point2d), isp2 As List(Of Point2d)) As List(Of Point2d)
        Dim lsp As New List(Of Point2d)
        Dim aPosl = isp2.First

        For Each el As Point2d In iSp1
            If el.X < aPosl.X Then lsp.Add(el)
        Next
        lsp.Add(aPosl)
        Return lsp
    End Function
    Private Sub Napr0()

        Dim W = New List(Of Point2d)(WGranizaWneschnaj(IndexGraniz.Werchnaj))
        Dim N = New List(Of Point2d)(WGranizaWneschnaj(IndexGraniz.Nijnaj))

        If TolschinaBeg > modelGeo.TipOpred.MinTolschina And TolschinaEnd > modelGeo.TipOpred.MinTolschina And Not wWerhnajPara.IsSloj Then
            'противоположные разрезы имеют разное игэ и отличные отнуля толщины
            Dim ldiag = New List(Of Point2d)()
            ldiag.Add(N.Last)
            ldiag.Add(W.First())

            WspKontur.Add(New KonturIge(Me, W, ldiag, False))   ' wWerhnajPara.Prot.IndexIge
            Dim ldiag1 = New List(Of Point2d)(ldiag)
            ldiag1.Reverse()
            N.Reverse()
            WspKontur.Add(New KonturIge(Me, ldiag1, N, True))   'wWerhnajPara.Beg.IndexIge
            Return

        End If

        N.Reverse()
        If wWerhnajPara.IsSloj Then 'одинаковые ИГЭ
            WspKontur.Add(New KonturIge(Me, W, N, True))   'wWerhnajPara.Beg.IndexIge
        Else
            'разные игэ , но одна из толщин близка к нулю
            If TolschinaBeg <= modelGeo.TipOpred.MinTolschina Then
                WspKontur.Add(New KonturIge(Me, W, N, False))    'wWerhnajPara.Prot.IndexIge
            Else
                WspKontur.Add(New KonturIge(Me, W, N, True))   'wWerhnajPara.Beg.IndexIge
            End If
        End If

        'If TolschinaBeg <= modelGeo.TipOpred.KritBlizosti Then
        '    WspKontur.Add(New KonturIge(Me, W, N, False))    'wWerhnajPara.Prot.IndexIge

        'Else
        '    WspKontur.Add(New KonturIge(Me, W, N, True))   'wWerhnajPara.Beg.IndexIge
        'End If

        Return
    End Sub
    Private Sub WnutrKontur(iw As List(Of Point2d), inn As List(Of Point2d), iPrWibGraniz As Boolean)
        Dim nnd = New List(Of Point2d)(inn)
        Dim wwd = New List(Of Point2d)(iw)
        nnd.Reverse()
        WspKontur.Add(New KonturIge(Me, wwd, nnd, iPrWibGraniz))
    End Sub

    Private Sub Napr1()
        'внутрений контур
        WGranizaWnutrjanaj = wWerhnajPara.Beg.GranizDlaHatch(wSlojWnutri, wNijnajPara.Beg.Glubina, wSlojWnutri.Glubina) 'получили границы внутреннего контурп от начала пары то точки
        'верхняя ^нижняя  l = w + ^n


        Dim W = New List(Of Point2d)(WGranizaWneschnaj(IndexGraniz.Werchnaj))
        Dim N = New List(Of Point2d)(WGranizaWneschnaj(IndexGraniz.Nijnaj))
        Dim ww = New List(Of Point2d)(WGranizaWnutrjanaj(IndexGraniz.Werchnaj))
        Dim nn = New List(Of Point2d)(WGranizaWnutrjanaj(IndexGraniz.Nijnaj))
        WnutrKontur(ww, nn, True)

        If wdistWerh > modelGeo.TipOpred.MinTolschina AndAlso wdistNiz > modelGeo.TipOpred.MinTolschina Then 'отличные от нуля толшины по обеим сторонам 
            ' lW = W  : ln = ^N +n +^w 


            N.Reverse()
            N.AddRange(nn)
            ww.Reverse()
            N.AddRange(ww)
        Else

            If wdistWerh < modelGeo.TipOpred.MinTolschina Then 'внутренняя точка лежит нам верхней границы пары
                '  lW = W U w    lN = ^N + n
                W = Widelit(W, ww)
                N.Reverse()
                N.AddRange(nn)
            Else
                '
                N = Widelit(N, nn)                                                                     'N.Union(nn, New ComparatorEqualsPoint2d)
                ww.Reverse()
                N.Reverse()
                N.AddRange(ww)

            End If
        End If
        '     WspKontur.First.KonturWneh = New KonturIge(Me, W, N, wWerhnajPara.Prot.IndexIge)
        WspKontur.Add(New KonturIge(Me, W, N, False))   ' wWerhnajPara.Prot.IndexIge
    End Sub
    Private Sub NaprM1()
        'внутрений контур
        WGranizaWnutrjanaj = wSlojWnutri.GranizDlaHatch(wWerhnajPara.Prot, wSlojWnutri.Glubina, wNijnajPara.Prot.Glubina) 'получили границы внутреннего контурп от точки до конца пары 

        Dim W = New List(Of Point2d)(WGranizaWneschnaj(IndexGraniz.Werchnaj))
        Dim N = New List(Of Point2d)(WGranizaWneschnaj(IndexGraniz.Nijnaj))
        Dim ww = New List(Of Point2d)(WGranizaWnutrjanaj(IndexGraniz.Werchnaj))
        Dim nn = New List(Of Point2d)(WGranizaWnutrjanaj(IndexGraniz.Nijnaj))
        WnutrKontur(ww, nn, False)   'wWerhnajPara.Prot.IndexIge



        If wdistWerh > modelGeo.TipOpred.MinTolschina AndAlso wdistNiz > modelGeo.TipOpred.MinTolschina Then
            'Нижняя   lw = w : lN   ^w + n +^N
            N.Reverse()
            N.InsertRange(0, nn)
            ww.Reverse()
            N.InsertRange(0, ww)



        Else
            If wdistWerh < modelGeo.TipOpred.MinTolschina Then
                ' lW = w U W   : lN    = n + ^N

                W = WidelitM(W, ww)                                          ' W.Union(ww, New ComparatorEqualsPoint2d)

                N.Reverse()
                N.InsertRange(0, nn)
            Else   ' lw = W : lN  = ^w + ^(NUnn)
                N = WidelitM(N, nn)                                                         '    N.Union(nn, New ComparatorEqualsPoint2d)
                N.Reverse()
                ww.Reverse()
                N.InsertRange(0, ww)
            End If

        End If




        '   WspKontur.First.KonturWneh = New KonturIge(Me, W, N, wWerhnajPara.Beg.IndexIge)
        WspKontur.Add(New KonturIge(Me, W, N, True)) ' wWerhnajPara.Beg.IndexIge

    End Sub
    Sub OpredelitKontur()
        Select Case Napr
            Case 0
                Napr0()
            Case 1
                Napr1()
            Case Else
                NaprM1()
        End Select
        'Варианты построения
        '  0 ИГЭ начала и конца пары совпадаеет внутрений контур отсутствует, внутреняя точка неучитываеться никак  napr0
        ' 1 Толщина начала  отлична от нуля, толщина конца нуль  и игэ внутреней точки не совпадает с  иге начала или внутреней точки нет napr0
        ' 2 Толщина конца  отлична от нуля, толщина начала нуль  и игэ внутреней точки не совпадает с  иге конца или внутреней точки нет napr0
        ' 3 Толщина начала и конца отличны от нуля и игэ внутреней точки отличаеться от иге начала и конца в этом случае внутренняя точка исключаеться
        ' 4  Игэ начала и конца разные
        ' 4.1 Толщина начала  отлична от нуля и игэ внутреней точки совпадает с  иге начала  
        ' 4.1.1 внутренняя точка не лежит нина одной границы   napr1
        ' 4.1.2 внутренняя точка  лежит на верхней  границы    napr1
        ' 4.1.3 внутренняя точка  лежит на нижней   границе     napr1

        ' 4.2 Толщина конца  отлична от нуля и игэ внутреней точки совпадает с  иге конца 
        ' 4.2.1 внутренняя точка не лежит нина одной границы naprM1
        ' 4.2.2 внутренняя точка  лежит на верхней  границы   naprM1
        ' 4.2.1 внутренняя точка  лежит на нижней   границе   naprM1




    End Sub
    Private Function ZentrWnesh() As Point2d
        Dim lpb = WGranizaWneschnaj(IndexGraniz.Werchnaj).First
        Dim lpe = WGranizaWneschnaj(IndexGraniz.Werchnaj).Last
        Dim lpNb = WGranizaWneschnaj(IndexGraniz.Nijnaj).First
        Dim lpNe = WGranizaWneschnaj(IndexGraniz.Nijnaj).Last
        Dim maxdist = 0
        Dim lrazrN, lrazrW As Point2d
        For I = 1 To WGranizaWneschnaj(IndexGraniz.Werchnaj).Count - 2
            Dim elW = WGranizaWneschnaj(IndexGraniz.Werchnaj)(I)
            Dim elN = WGranizaWneschnaj(IndexGraniz.Nijnaj)(I)
            If Math.Abs(elW.X - lpb.X) < LeseGeoIzDwg.ObrazGeologii.OkoloSkwajnDwg OrElse Math.Abs(elW.X - lpe.X) < LeseGeoIzDwg.ObrazGeologii.OkoloSkwajnDwg Then Continue For
            Dim lwsp = Math.Abs(elW.Y - elN.Y)
            If lwsp > maxdist Then
                lrazrW = elW
                lrazrN = elN
            End If
        Next
    End Function
    ReadOnly Property TolschinaBeg As Double
        Get
            Return wNijnajPara.Beg.Glubina - wWerhnajPara.Beg.Glubina
        End Get
    End Property
    ReadOnly Property TolschinaEnd As Double
        Get
            Return wNijnajPara.Prot.Glubina - wWerhnajPara.Prot.Glubina
        End Get
    End Property
    Private ReadOnly Property IgeBeg As String
        Get
            Return wWerhnajPara.Beg.IndexIge
        End Get

    End Property
    Private ReadOnly Property IgeEnd As String
        Get
            Return wWerhnajPara.Prot.IndexIge
        End Get
    End Property
    ReadOnly Property Wnutri() As Boolean
        Get
            If wSlojWnutri Is Nothing Then Return False
            Dim l = wpointNijn.GetDistanceTo(wpointWerh)
            If wdistNiz <= l And wdistWerh <= l Then Return True
            Return False
        End Get
    End Property
    ReadOnly Property KonturdlajWiw() As List(Of KonturIge)
        Get
            Return WspKontur
        End Get
    End Property
    ReadOnly Property PointBeg As Point2d
        Get
            Return WGranizaWneschnaj(IndexGraniz.Werchnaj).First
        End Get
    End Property
    ReadOnly Property PointEnd As Point2d
        Get
            Return WGranizaWneschnaj(IndexGraniz.Werchnaj).Last
        End Get
    End Property
End Class
