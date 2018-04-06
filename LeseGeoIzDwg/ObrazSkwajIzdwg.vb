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


''' <summary>
''' Образ скважины в чертеже (имя береться из надписи в подвале профиля ) положение центра и глубина из анализа полилиний представляющую скважину.
''' </summary>
''' <remarks></remarks>
Public Class ObrazSkwajn


    Private wXdwg, wglubinaDwg, wYmax As Double 'Примечание Умакс должна одназначно определяться по X
    Private wSpPrimGraniz As List(Of Entity)    ' примитивы образующие скважину
    Private wSpHatchKons As List(Of clsHatch)    ' штриховки представляющие консистенции.
    Private wSpProb As List(Of ProbaDwg) ' список проб монолитов

    Private wName As String     '  имя скважины
    Private wTipSkwaj As modelGeo.TipSkwajn
    Private wIsArhiw As Boolean
    Private wSpSlojw As New List(Of SlojIgeDwg)   'Слои начало которых совладает с  скважины
    Private wSpSlojwPeresech As New List(Of SlojIgeDwg)   'Слои которые пересекает скважина.
    Private wSpslojwEnd As New List(Of SlojIgeDwg) ' Слои конец которых совпадает со скважиной
    Private wSpRazrezowNaSkwajne As New List(Of RazrezSlojIgeDwg)
    Private wUgw As UgwDwgClass     '     представление образа отметки проб
    Private wspOtmetok As New List(Of Double)
    Private wspGlubin As New List(Of Double)
    Private wCompHatchIdent As New LeseGeoIzDwg.ComparatorSlojIgeDwg
    Private wCompHatchIdentEnd As New LeseGeoIzDwg.ComparatorSlojIgeDwgEnd
    Private wCompRazrez As New LeseGeoIzDwg.ComparatorRazrezSlojIgeDwgY
    Private wMtext As MText 'примитив Autocad из которого береться имя скважины.
#Region "Конструирование"


    Private Sub NameSkwajPoStroke(iShodText As String)
        Dim lname As String = ""
        Dim lindex As Integer = Strings.InStr(iShodText, ".")
        Dim lWspStr As String = iShodText.Substring(lindex)
        '   Char.IsPunctuation(".")

        For Each c As Char In lWspStr
            If c.Equals(CChar("\")) Then
                Exit For
            End If
            If Char.IsLetterOrDigit(c) OrElse Char.IsPunctuation(c) Then
                lname &= c
                Continue For
            Else
                c = CChar("_")
                Exit For
            End If
        Next

        wName = lname

    End Sub
    Private Sub OpredTipIsBlock(ibl As BlockReference)
        Dim i As Integer
        For i = 0 To modelGeo.TipOpred.NameBlok.Count - 1
            If ibl.Name.Equals(modelGeo.TipOpred.NameBlok(i)) Then
                wTipSkwaj = CType(i, modelGeo.TipSkwajn)
                wIsArhiw = False
                Return
            End If
            If ibl.Name.Equals(modelGeo.TipOpred.NameBlokArhiv) Then
                wTipSkwaj = modelGeo.TipSkwajn.RazwedSqwaj
                wIsArhiw = True
                Return
            End If
            wIsArhiw = False
        Next
    End Sub
    Sub New(iObraz As PostroenijSkwajEntity)
        With iObraz
            wXdwg = .Xust
            wYmax = .Ymax
            wglubinaDwg = .Ymax - .Ymin
            wSpPrimGraniz = .GetSpPrim
            wSpProb = .GetSpProb
            wUgw = .GetUgw
            For Each el As MText In .GetGlubin
                wspGlubin.Add(dbPrim.IzStrChislo(el.Text))
            Next
            For Each el As MText In .GetOtmetki
                wspOtmetok.Add(dbPrim.IzStrChislo(el.Text))
            Next
            wSpHatchKons = .GetHatchconsistenz
        End With

    End Sub
    Sub New(iX As Double, iGrebenWdwg As BazDwg.GrebenProfilDwg, iObraz As ObrazGeoloGii)

        wXdwg = iX
        wYmax = iGrebenWdwg.GetPointLinii(iX).Y
        'wglubinaDwg = .Ymax - .Ymin
        wSpRazrezowNaSkwajne = iObraz.SpisokSlojIgeDwgWTochke(New Point3d(iX, wYmax, 0))
        '   wSpRazrezowNaSkwajne.Sort(wCompRazrez)
        '  wSpRazrezowNaSkwajne.Max(Function(lsl ) lsl.YnizDwg 
        wglubinaDwg = wYmax - wSpRazrezowNaSkwajne.Min(Function(lsl) lsl.YnizDwg)   ' wSpRazrezowNaSkwajne.First.YnizDwg
        wTipSkwaj = modelGeo.TipSkwajn.dlajKlin
        wName = "#" & iX
    End Sub
    Sub UstTipOgran()
        wTipSkwaj = modelGeo.TipSkwajn.Ogran
    End Sub
    Sub AddSloj(iHatchIdent As SlojIgeDwg)
        '  wSpSlojw.Add(iHatchIdent)
        LeseGeoIzDwg.ComparatorSlojIgeDwg.SearchAndInsert(wSpSlojw, iHatchIdent, wCompHatchIdent)
    End Sub
    Sub AddSlojPeresech(iHatchIdent As SlojIgeDwg)
        '  wSpSlojw.Add(iHatchIdent)
        LeseGeoIzDwg.ComparatorSlojIgeDwg.SearchAndInsert(wSpSlojwPeresech, iHatchIdent, wCompHatchIdent)
    End Sub
    Sub AddSlojEnd(iHatchIdent As SlojIgeDwg)
        '  wSpSlojw.Add(iHatchIdent)
        LeseGeoIzDwg.ComparatorSlojIgeDwg.SearchAndInsert(wSpslojwEnd, iHatchIdent, wCompHatchIdentEnd)
    End Sub

    Sub AddRazrez(iRazrez As RazrezSlojIgeDwg)
        If iRazrez.TolshinaDwg > ObrazGeologii.DopuskGeoDwgY Then
            LeseGeoIzDwg.ComparatorRazrezSlojIgeDwgY.SearchAndInsert(wSpRazrezowNaSkwajne, iRazrez, wCompRazrez)

        End If

    End Sub


    Sub OpredRazrezNaSkwajne()

        For Each el As SlojIgeDwg In wSpSlojw
            AddRazrez(New RazrezSlojIgeDwg(el))
        Next
        For Each el As SlojIgeDwg In wSpslojwEnd
            If EstliRazrez(el.IndexIge) Then Continue For
            AddRazrez(New RazrezSlojIgeDwg(el, True))
        Next
        For Each el As SlojIgeDwg In wSpSlojwPeresech
            If EstliRazrez(el) Then Continue For
            AddRazrez(New RazrezSlojIgeDwg(Me.ZentrSkwajnDwg, el))
        Next




    End Sub
#End Region
#Region "Readonlu"
    ReadOnly Property NameSkwaj() As String
        Get
            Return wName
        End Get
    End Property
    ReadOnly Property ZentrSkwajnDwg() As Double
        Get
            Return wXdwg
        End Get
    End Property
    ReadOnly Property YMax As Double
        Get
            If wYmax = 0 Then
                Return GtanizaWerhSlojw()
            Else
                Return wYmax
            End If



        End Get
    End Property
    ReadOnly Property YMin As Double
        Get
            Try
                Return YMax - wglubinaDwg
            Catch ex As Exception
                Return GtanizaNijnSlojw()
            End Try

        End Get
    End Property
    ReadOnly Property MaxGraniza() As Double
        Get

            Return wXdwg + 0.5 * ObrazGeoloGii.ShirinaObrazSkwajn

        End Get
    End Property
    ReadOnly Property MinGraniza() As Double
        Get

            Return wXdwg - 0.5 * ObrazGeoloGii.ShirinaObrazSkwajn

        End Get
    End Property
    ReadOnly Property GlubinaUgw() As Double
        Get
            Return wUgw.Glubina
        End Get

    End Property
    ReadOnly Property DataUgw() As Date
		Get
			Try
				Return wUgw.DataProbUgw
			Catch ex As Exception
				Return Date.MinValue
			End Try

		End Get
	End Property
    ReadOnly Property PrProbUgw() As Boolean
        Get
            Return wUgw.PriznakProbUgw
        End Get
    End Property
    ReadOnly Property TipSkwaj As modelGeo.TipSkwajn
        Get
            Return wTipSkwaj
        End Get
    End Property
    ReadOnly Property IsArhiw() As Boolean
        Get
            Return wIsArhiw
        End Get
    End Property

    ''' <summary>
    ''' Слои начало которых совладает с  скважиной
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function SlojBeg() As List(Of SlojIgeDwg)


        Return wSpSlojw
    End Function
    ''' <summary>
    ''' Слои конец которых совпадает со скважиной
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function SlojEnd() As List(Of SlojIgeDwg)
        Return wSpslojwEnd
    End Function
    Function GetRazrezDwg() As List(Of RazrezSlojIgeDwg)
        ' wSpRazrezowNaSkwajne  упорядочен по возрастанию отметки в чертеже
        Return wSpRazrezowNaSkwajne
    End Function
    Private Function GtanizaWerhSlojw() As Double
        If wSpRazrezowNaSkwajne.Count > 0 Then
            Return wSpRazrezowNaSkwajne.Last.YwerhDwg
        Else

            Return 0

        End If
    End Function
    Private Function GtanizaNijnSlojw() As Double
        If wSpRazrezowNaSkwajne.Count > 0 Then
            Return wSpRazrezowNaSkwajne.First.YnizDwg
        Else

            Return 0

        End If
    End Function
    Function EstliRazrez(IindexIge As String) As Boolean
        For Each el As RazrezSlojIgeDwg In wSpRazrezowNaSkwajne
            If el.IndexIge = IindexIge Then Return True
        Next
        Return False
    End Function
    Function EstliRazrez(ISloj As SlojIgeDwg) As Boolean
        For Each el As RazrezSlojIgeDwg In wSpRazrezowNaSkwajne
            If el.Equals(ISloj) Then Return True
        Next
        Return False
    End Function

    Friend Function GetMtextImeni() As MText
        Return wMtext
    End Function
    Private ReadOnly Property EntityObrazez() As Entity
        Get

            For Each el As Entity In wSpPrimGraniz
                If el.Linetype = "HIDDEN" Then Return el
            Next
            Try
                Return wSpPrimGraniz(0)
            Catch ex As Exception
                Return Nothing
            End Try

        End Get
    End Property
    ''' <summary>
    ''' Отметки слоев по считаным мтекстовым примитивам. Последняя должна быть отметка низа скважины 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetOtmetkiPoTxt() As List(Of Double)
        Return wspOtmetok
    End Function
    ''' <summary>
    ''' Глубины слоев по считаным  примитивам. Последняя должна быть глубина скважины  
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetGlubinReal() As List(Of Double)
        Return wspGlubin
    End Function
    Function GetProb() As List(Of ProbaDwg)
        Return wSpProb
    End Function
    Function getConsistenz() As List(Of clsHatch)
        Return wSpHatchKons
    End Function

#End Region

#Region "Poisk"
    Private Function Krit(el As MText) As Boolean
        If wXdwg < el.Location.X Then Return True
        Return False

    End Function
    Private Function Krit(el As Entity) As Boolean
        If wXdwg < CType(el, BlockReference).Position.X Then Return True
        Return False

    End Function
    ''' <summary>
    ''' ищет текстовой маркер скважины 
    ''' </summary>
    ''' <param name="iLm"> мультитекст  </param>
    ''' <returns> возвращает номер в строке скоторого начинаеться марке , если маркера нет то 0 </returns>
    ''' <remarks></remarks>
    Shared Function ProwImeniSkwaj(iLm As MText) As Integer
        Dim lw = iLm.Contents.ToLower
        Dim lpoz = Strings.InStr(lw, "скв.")
        If lpoz > 0 Then Return lpoz
        lpoz = Strings.InStr(lw, "cкв.")
        If lpoz > 0 Then Return lpoz
        lpoz = Strings.InStr(lw, "ш.")
        If lpoz > 0 Then Return lpoz
        lpoz = Strings.InStr(lw, "обн.")
        If lpoz > 0 Then Return lpoz
        Return 0
    End Function

    Function NajtiImj(iSpImenSkwajn As List(Of MText)) As Double

        If iSpImenSkwajn.Count = 0 Then
            wName = Format(wXdwg, "f0")
            Return 0
        End If
        Dim lIndex As Integer = iSpImenSkwajn.FindIndex(AddressOf Krit)
        If lIndex = 0 Then
            wMtext = iSpImenSkwajn.First
        Else
            If lIndex = -1 Then
                wMtext = iSpImenSkwajn.Last()
            Else
                Dim lm1 = iSpImenSkwajn(lIndex - 1)
                Dim ls = iSpImenSkwajn(lIndex)
                If Math.Abs(lm1.Location.X - wXdwg) < Math.Abs(ls.Location.X - wXdwg) Then
                    wMtext = lm1
                Else
                    wMtext = ls
                End If
            End If

        End If




        Dim lwsp = wMtext.Contents.Substring(ProwImeniSkwaj(wMtext))
        NameSkwajPoStroke(lwsp)
        Dim w As Double = wXdwg - wMtext.Location.X
        Dim w1 As Double = wXdwg - wMtext.GeometricExtents.MaxPoint.X
        If Math.Abs(w1) < Math.Abs(w) Then w = w1
        w1 = wXdwg - wMtext.GeometricExtents.MinPoint.X
        If Math.Abs(w1) < Math.Abs(w) Then w = w1

        Return w

    End Function
    Function OpredTip(iSpZnakowSkwaj As List(Of Entity)) As Double
        If iSpZnakowSkwaj.Count = 0 Then Return wXdwg
        Dim lInsert As BlockReference
        Dim lIndex As Integer = iSpZnakowSkwaj.FindIndex(AddressOf Krit)
        If lIndex = 0 Then
            lInsert = CType(iSpZnakowSkwaj.First, BlockReference)
        Else
            If lIndex = -1 Then
                lInsert = CType(iSpZnakowSkwaj.Last(), BlockReference)
            Else
                Dim lm1 As BlockReference = CType(iSpZnakowSkwaj(lIndex - 1), BlockReference)
                Dim ls As BlockReference = CType(iSpZnakowSkwaj(lIndex), BlockReference)
                If Math.Abs(lm1.Position.X - wXdwg) < Math.Abs(ls.Position.X - wXdwg) Then
                    lInsert = lm1
                Else
                    lInsert = ls
                End If
            End If

        End If





        OpredTipIsBlock(lInsert)
        Dim w As Double = wXdwg - lInsert.Position.X


        Return w

    End Function
#End Region

   

 





End Class

''' <summary>
''' находит группы близких полилиний и линий и по ним определяет параметры  скважины
''' </summary>
''' <remarks></remarks>
Public Class PostroenijSkwajEntity

    Private wSpPrimGraniz As New List(Of Entity)
    Private wspOtmetok As New List(Of MText)
    Private wspGlubinMtext As New List(Of MText)

    Private wSpHatchCons As New List(Of clsHatch)
    Private wSpProb As New List(Of ProbaDwg)
    Private wGlubinaGruntWod As MText
    Private wOtmetkaGruntwod As MText
    Private wPrProbGruntWod As Entity
    ' Private wUgwDwg As UgwDwgClass
    Private wXmin, wXmax, wYmin, wYmax As Double
#Region "Построение"
    Private Sub Uchest(iP As Point3d)
        wXmin = Math.Min(iP.X, wXmin)
        wXmax = Math.Max(iP.X, wXmax)

        wYmin = Math.Min(iP.Y, wYmin)
        wYmax = Math.Max(iP.Y, wYmax)
    End Sub
    Private Function Prinadlejt(ip As Point3d) As Boolean
        Dim lXc = 0.5 * (wXmin + wXmax)

        If Math.Abs(lXc - ip.X) < 2 * ObrazGeoloGii.ShirinaObrazSkwajn + 0.01 Then ' если точка находиться в области скважины учитываем ее в параметрах
            Uchest(ip)

            Return True
        End If
        Return False
    End Function
    Private Function PointOkrestnosti(Ix As Double, iY As Double) As Boolean
        If iY > wYmax + ObrazGeoloGii.OkrestnostObraz OrElse iY < wYmin - ObrazGeoloGii.OkrestnostObraz Then Return False

        If wXmin - Ix > ObrazGeoloGii.OkrestnostObraz OrElse Ix - wXmax > ObrazGeoloGii.OkrestnostObraz Then Return False
        Return True
    End Function
    Private Function AddLine(iLine As Line) As Boolean
        If Prinadlejt(iLine.StartPoint) Then
            Prinadlejt(iLine.EndPoint)
            wSpPrimGraniz.Add(iLine)
            Return True
        Else
            If Prinadlejt(iLine.EndPoint) Then
                wSpPrimGraniz.Add(iLine)
                Return True
            End If
        End If
        Return False
    End Function
    Private Function AddPoliline(iPolyLine As Polyline) As Boolean
        Dim lPriznak As Boolean = False
        For I As Integer = 0 To iPolyLine.NumberOfVertices - 1
            If Prinadlejt(iPolyLine.GetPoint3dAt(I)) Then lPriznak = True
        Next
        If lPriznak Then wSpPrimGraniz.Add(iPolyLine)
        Return lPriznak
    End Function
    Private Function AddPoliline2d(iPolyLine As Polyline2d) As Boolean
        Dim lPriznak As Boolean = False

        For I As Integer = 0 To CInt(iPolyLine.EndParam)
            If Prinadlejt(iPolyLine.GetPointAtParameter(I)) Then lPriznak = True
        Next
        If lPriznak Then wSpPrimGraniz.Add(iPolyLine)
        Return lPriznak
    End Function
    Private Sub SozdanieSkwaj(iPoint As Point3d)
        wXmin = iPoint.X
        wXmax = wXmin
        wYmin = iPoint.Y
        wYmax = wYmin
    End Sub
    Function AddEntity(el As Entity) As Boolean
        Dim ly = dbPrim.ZentrEntity(el).Y
        If ly < 200 Or ly > 800 Then Return False
        If TypeOf el Is Line Then
            Dim lElLine = CType(el, Line)
            If wSpPrimGraniz.Count = 0 Then
                SozdanieSkwaj(lElLine.StartPoint)
                Uchest(lElLine.EndPoint)
                wSpPrimGraniz.Add(el)
                Return True
            End If
            Return AddLine(lElLine)
        Else
            If TypeOf el Is Polyline Then
                Dim lElPolyline = CType(el, Polyline)
                If wSpPrimGraniz.Count = 0 Then
                    SozdanieSkwaj(lElPolyline.StartPoint)
                    For I As Integer = 0 To lElPolyline.NumberOfVertices - 1
                        Prinadlejt(lElPolyline.GetPoint3dAt(I))
                    Next
                    wSpPrimGraniz.Add(el)
                    Return True
                Else

                    Return AddPoliline(lElPolyline)

                End If
            End If
        End If
        If TypeOf el Is Polyline2d Then
            Dim lElPolyline = CType(el, Polyline2d)
            If wSpPrimGraniz.Count = 0 Then
                SozdanieSkwaj(lElPolyline.StartPoint)
                For I As Integer = 0 To CInt(lElPolyline.EndParam)
                    Prinadlejt(lElPolyline.GetPointAtParameter(I))
                Next
                wSpPrimGraniz.Add(el)
                Return True
            Else

                Return AddPoliline2d(lElPolyline)

            End If
        End If
        Return False

    End Function
    Function AddHatch(el As clsHatch) As Boolean
        If el.MejduX(Xust) Then
            wSpHatchCons.Add(el)
            wSpHatchCons.Sort(AddressOf ObrazGeoloGii.SrawneniePoY)
            Return True
        End If
        Return False

    End Function
    Private wComp As New ComparatorPoMtextY
    Private Const KritBlizostiGlub = ObrazGeologii.OkoloSkwajnDwg
    ''' <summary>
    ''' Выбор мультитекста в котором записана или отметка слоя или глубина.   Добавляет мультитексты отметок и глубин 
    ''' </summary>
    ''' <param name="el"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function AddMtextOtmetokGlubin(el As MText) As Boolean
        'Стоит – ли для глубин и отметок провернуть такойже прием как и для УПВ
        Dim lgrY As Double = dbPrim.ZentrEntity(el).Y
        If lgrY > Ymax + KritBlizostiGlub Then Return False
        If lgrY < Ymin - KritBlizostiGlub Then Return False
        Dim lgr As Double = dbPrim.DaljnalPoX(el)
        lgr = wXmin - lgr


        If lgr > 0 And lgr < KritBlizostiGlub Then

            ComparatorPoMtextY.SearchAndInsert(wspOtmetok, el, wComp)
            Return True
        End If
        lgr = dbPrim.BlijnajPoX(el) - wXmax
        If lgr > 0 And lgr < KritBlizostiGlub Then
            ComparatorPoMtextY.SearchAndInsert(wspGlubinMtext, el, wComp)
            Return True
        End If
        Return False
    End Function
    Function AddMtextOtmetokGlubin(iMleader As MLeader) As Boolean
        Dim el As MText = iMleader.MText
        Return AddMtextOtmetokGlubin(el)

    End Function

    Private wcomparatorProb As New ComparatorPoProbamDwg
    Function TipProb(iznak As Entity) As Boolean
        Dim lstartWidth, lendWidth As Double
        If TypeOf (iznak) Is Polyline2d Then


            Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
            Dim acCurDb As Database = acDoc.Database


            '' Start a transaction
            Using tr As Transaction = acCurDb.TransactionManager.StartTransaction()
                For Each vertId As ObjectId In CType(iznak, Polyline2d)
                    Dim vert As Vertex2d = CType(tr.GetObject(vertId, OpenMode.ForRead), Vertex2d)
                    If vert.StartWidth > lstartWidth Then lstartWidth = vert.StartWidth
                    If vert.EndWidth > lendWidth Then lendWidth = vert.EndWidth
                Next
            End Using
        Else
            If TypeOf (iznak) Is Polyline Then
                Dim lPoly As Polyline = CType(iznak, Polyline)
                For i As Integer = 0 To lPoly.NumberOfVertices - 1
                    Dim lwEnd = lPoly.GetEndWidthAt(i)
                    Dim lwStart = lPoly.GetStartWidthAt(i)
                    If lwStart > lstartWidth Then lstartWidth = lwStart
                    If lwEnd > lendWidth Then lendWidth = lwEnd
                Next
            End If


        End If
        If lstartWidth >= 2 And lendWidth >= 2 Then
            Return True
        Else
            If lstartWidth >= 2 Or lendWidth >= 2 Then
                Return False
            Else
                Return False
            End If
        End If

    End Function
    Function OpredelitGons(iOtmetka As Double) As Integer
        For Each el As clsHatch In wSpHatchCons
            If el.OtmetkaBegPodwg > iOtmetka Then
                Return ObrazGeoloGii.OpredNumCons(el)
            End If
        Next
        Return 0
    End Function
    Function AddProba(iZnak As Entity) As Boolean

        Dim ldelta As Double = dbPrim.BlijnajPoX(iZnak) - wXmax
        Dim ldeltaY As Double = dbPrim.ZentrEntity(iZnak).Y
        Dim lotmetka As Double
        If ldelta < 0 OrElse ldelta > ObrazGeoloGii.OkrestnostObraz Then Return False
        If ldeltaY > wYmax OrElse ldeltaY < Ymin Then Return False

        If TypeOf (iZnak) Is Polyline2d Then
            Dim lznak = CType(iZnak, Polyline2d)
            If lznak.Length > 3 Then Return False
            lotmetka = lznak.StartPoint.Y
        Else
            If TypeOf (iZnak) Is Polyline Then
                Dim lznak = CType(iZnak, Polyline)
                If lznak.Length > 3 Then Return False
                lotmetka = lznak.StartPoint.Y
            Else
                Return False
            End If
        End If




        Dim lrez As Boolean = TipProb(iZnak)


        Dim lproba As New ProbaDwg(lotmetka)

        lproba.Tip = TipProb(iZnak)
        lproba.Consistezij = OpredelitGons(lotmetka)



        wcomparatorProb.SearchAndInsert(wSpProb, lproba)
        Return True
    End Function
    Function addOtmetGlubGruntWod(izapis As MText) As Boolean
        Dim lgr As Double = dbPrim.DaljnalPoX(izapis)
        If UgwDwgClass.ProverkaPriznakaOtmetok(izapis) Then
            lgr = wXmin - lgr
            If lgr < 2 * ObrazGeologii.OkoloSkwajnDwg And lgr > 0 Then
                wOtmetkaGruntwod = izapis
                Return True
            Else
                Return False
            End If
        End If

        lgr = dbPrim.BlijnajPoX(izapis) - wXmax
        If lgr < 2 * ObrazGeologii.OkoloSkwajnDwg And lgr > 0 Then
            wGlubinaGruntWod = izapis
            Return True
        End If
        Return False
    End Function
    ''' <summary>
    ''' Esli есть признак отметки и он лежит в допустимой позиции то положительное число  если в недопустимой -0.1   иначе -1
    ''' </summary>
    ''' <param name="izapis"> анализируемый мульти текст   </param>
    ''' <param name="ikrit"> критерий близости. </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function addOtmetGruntWod(izapis As MText, ikrit As Double) As Double
        Dim lgr As Double = dbPrim.DaljnalPoX(izapis)

        lgr = wXmin - lgr
        If lgr < ikrit And lgr > 0 Then
            wOtmetkaGruntwod = izapis
            Return lgr
        Else
            Return -1
        End If



    End Function
    Function addGlubintWod(izapis As MText, ikrit As Double) As Double



        Dim lgr = dbPrim.BlijnajPoX(izapis) - wXmax
        If lgr < ikrit And lgr > 0 Then
            wGlubinaGruntWod = izapis
            Return lgr
        End If
        Return -1.0
    End Function
    Function addPriznakProbGruntWod(izapis As Entity) As Boolean
        Dim lgr As Double = dbPrim.BlijnajPoX(izapis) - wXmax



        If lgr < ObrazGeologii.OkoloSkwajnDwg And lgr > 0 Then
            wPrProbGruntWod = izapis
            Return True
        End If
        Return False
    End Function
#End Region
#Region "Read only Get"
    ReadOnly Property Xust() As Double
        Get
            Return 0.5 * (wXmin + wXmax)
        End Get

    End Property
    ReadOnly Property Yust() As Double
        Get
            Return wYmax
        End Get

    End Property
    ReadOnly Property Ymax() As Double
        Get
            Return wYmax
        End Get

    End Property
    ReadOnly Property Ymin() As Double
        Get
            Return wYmin
        End Get

    End Property
    ReadOnly Property Xmin() As Double
        Get
            Return wXmin
        End Get

    End Property
    ReadOnly Property Xmax() As Double
        Get
            Return wXmax
        End Get

    End Property

    ReadOnly Property KolwoPrim() As Integer
        Get
            Return wSpPrimGraniz.Count
        End Get
    End Property
    ReadOnly Property KolwoHatch() As Integer
        Get
            Return wSpHatchCons.Count

        End Get
    End Property
    'ReadOnly Property TipSkwaj() As Integer
    '    Get
    '        Dim ltip As Integer = 0
    '        For Each el As Entity In wSpPrimGraniz
    '            If el.Linetype <> "ByLayer" Then
    '                ltip = 1
    '            End If

    '        Next

    '        Return ltip
    '    End Get
    'End Property
    'ReadOnly Property DataProbUgw() As String
    '    Get
    '        If wUgwDwg Is Nothing Then wUgwDwg = New UgwDwgClass(wGlubinaGruntWod, wOtmetkaGruntwod)
    '        If wUgwDwg.DataProbUgw.Equals(Date.MinValue) Then Return ""
    '        Return wUgwDwg.DataProbUgw.ToString("d")
    '    End Get
    'End Property
    ReadOnly Property OtmetkaUgw() As String
        Get
            If wOtmetkaGruntwod IsNot Nothing Then
                Return wOtmetkaGruntwod.Text
            Else
                Return String.Empty
            End If

        End Get
    End Property
    ReadOnly Property GlubinaUgw() As String
        Get
            If wGlubinaGruntWod IsNot Nothing Then
                Return wGlubinaGruntWod.Text
            Else
                Return String.Empty
            End If

        End Get
    End Property
    ''' <summary>
    ''' Возвращает список примитивовов представляющих скважину
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetSpPrim() As List(Of Entity)
        Return wSpPrimGraniz
    End Function
    ''' <summary>
    ''' список проб на скважине
    ''' </summary>
    ''' <remarks></remarks>
    Function GetSpProb() As List(Of ProbaDwg)
        Return wSpProb
    End Function
    Function GetUgw() As UgwDwgClass
        Return New UgwDwgClass(wGlubinaGruntWod, wOtmetkaGruntwod, wPrProbGruntWod)
    End Function
    ''' <summary>
    ''' Возвращает список Мтехт которым записаны глубины
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetOtmetki() As List(Of MText)
        Return wspOtmetok
    End Function
    Function GetGlubin() As List(Of MText)
        Return wspGlubinMtext
    End Function
    Function GetHatchconsistenz() As List(Of clsHatch)

        Return wSpHatchCons


    End Function
#End Region
    Sub New()

    End Sub


End Class

