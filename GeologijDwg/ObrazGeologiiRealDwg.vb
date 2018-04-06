Imports OperBD
#If ARX_APP Then
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.DatabaseServices
#Else
Imports Teigha.Geometry
Imports Teigha.DatabaseServices
#End If






Imports modRasstOp
Imports LeseGeoIzDwg

Imports clsPrf
Imports BazDwg
Imports ProfilBaseDwg
Imports modelGeo



''' <summary>
''' КЛАСС связи растановки  на профили и геологии связь реальные и dwg координаты 
''' </summary>
''' <remarks></remarks>
Public Class ObrazGeologiiRealDwg

    '  Private wObrazGeolog As LeseGeoIzDwg.ObrazGeoloGii ' наверное должен остаться только в констукторе.
    Private wSpSkwajn As New List(Of SkwajnaRealDwg)
    Private wSpParamIge As New List(Of LeseGeoIzDwg.ParamIge)
    Private wparam As New ParamImageGeo
    Private wRasst As modRasstOp.wlRasst
    Private wTrassaDwg As DwgTr
    Private wLinijProfilDwg As BazDwg.GrebenProfilDwg
    Private wKoorRasst, wKoorOtm As clsKoor
#Region "Конструирование"
    Private Sub New(igrasst As wlRasst)
        wRasst = igrasst
        wTrassaDwg = CType(wRasst.Trassa, DwgTr)
        wKoorRasst = wTrassaDwg.objGeom.KoorP
        wKoorOtm = wTrassaDwg.objGeom.KoorOtm
        wLinijProfilDwg = wTrassaDwg.GetLinijDwg
    End Sub
    Sub New(igrasst As wlRasst, iObrazGeologij As ObrazGeologii)
        Me.New(igrasst)

        '   wObrazProfilaj = CType(wRasst.Trassa, DwgTr)
        '  wObrazGeolog = iObrazGeologij
        For Each el As ObrazSkwajn In iObrazGeologij.SpSkwajn
            wSpSkwajn.Add(New SkwajnaRealDwg(CType(wRasst.Trassa, ProfilBaseDwg.DwgTr), el, wparam))

        Next
        wSpParamIge = iObrazGeologij.GetSpisokParamIge()
    End Sub
	'Sub New(igrasst As wlRasst, ids As modelGeo.dsGeologij)
	'    Me.New(igrasst)

	'    For Each el As modelGeo.dsGeologij.geoSkwajRow In ids.geoSkwaj
	'        Dim lskwReal As New modelGeo.SkwajnaReal(ids, el, wRasst.Trassa)
	'        wSpSkwajn.Add(New SkwajnaRealDwg(CType(wRasst.Trassa, ProfilBaseDwg.DwgTr), lskwReal, wparam))

	'    Next
	'    ' построение списка парам ИГЭ
	'    For Each el As modelGeo.dsGeologij.geoParamIgeRow In ids.geoParamIge
	'        With el
	'            wSpParamIge.Add(New LeseGeoIzDwg.ParamIge(.PatternName, .PatternScale, .PatternAngle, _
	'                                                      CType(.wLineWeight, Autodesk.AutoCAD.DatabaseServices.LineWeight), .IndexIGE, .Woswrast))

	'        End With


	'    Next

	'End Sub
	'Sub addSkwajn(iindex As Integer, iSkwaj As SkwajnaRealDwg)
	'    If iindex < 0 Then
	'        wSpSkwajn.Add(iSkwaj)
	'        Return
	'    End If
	'    wSpSkwajn.Insert(iindex, iSkwaj)

	'End Sub
	'Sub ZapSkwajn(iindex As Integer, iSkwaj As SkwajnaRealDwg)
	'       wSpSkwajn(iindex) = iSkwaj

	'   End Sub
#End Region
	''' <summary>
	''' Возвращает Список слоев ИГЭ под опорй с привязкой к реальным координатам.
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Function GetSloiIgePodOporami(iObrazGeolog As LeseGeoIzDwg.ObrazGeologii) As List(Of GranizaSlojIgeRealDwg)
        Dim lSpSlojwTrass As New List(Of GranizaSlojIgeRealDwg)

        For Each op As wlOpRasst In wRasst.opColl
            Dim lPointOsnDwg As Point3d

            Dim Xdwg = wKoorRasst.GetDwg(op.RastOtNachala)
            Dim Ydwg = wKoorOtm.GetDwg(op.Otmetka)
            lPointOsnDwg = New Point3d(Xdwg, Ydwg, 0)

            Dim LPointOpor = New PointReal(op.RastOtNachala, op.Otmetka)
            Dim lsp As List(Of LeseGeoIzDwg.RazrezSlojIgeDwg) = iObrazGeolog.SpisokSlojIgeDwgWTochke(lPointOsnDwg)  'взяли список образов слоев в точке 
            lsp.Sort(AddressOf RazrezSlojIgeDwg.SrawnitPoYwerh)   'сортировка во возрастанию отметки
            lsp.Reverse()  ' перестройка по возрастанию глубины
            For Each sl As RazrezSlojIgeDwg In lsp

                Dim lreal = New GranizaSlojIgeRealDwg(CType(wRasst.Trassa, ProfilBaseDwg.DwgTr), wparam.Maschtab, sl, op.NumName, LPointOpor)
                lSpSlojwTrass.Add(CType(lreal, GranizaSlojIgeRealDwg))
            Next

        Next
        Return lSpSlojwTrass
    End Function
    ' ''' <summary>
    ' ''' Функция как-то апроксимирует список слоев в центре скважины
    ' ''' </summary>
    ' ''' <param name="IRast"> растояние то точки скважины  </param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Private Function GetSloiIgePodTochkoj(IRast As Double) As List(Of GranizaSlojIgeRealDwg)
    '    Dim lSpSlojwWtochki As New List(Of GranizaSlojIgeRealDwg)

    '    Dim lLini As New GrebenProfilReal(wRasst.Trassa.GetLinijProfilReal)
    '    Dim lTochkaProfil = lLini.GetPointLinii(IRast)
    '    'находим скважину до и после точки
    '    Dim lindPred As Integer
    '    Dim lInd = GetIndexSkwajnPosle(IRast)
    '    If lInd > 0 Then
    '        lindPred = lInd - 1
    '    Else
    '        Return wSpSkwajn.First.GetSlojNaSkwajne()
    '    End If
    '    Dim linMej As New GrebenProfilReal(lLini.GetUchastokLinii(wSpSkwajn(lindPred).Rastojnie, wSpSkwajn(lInd).Rastojnie))
    '    Dim lSloiPred As List(Of GranizaSlojIgeRealDwg) = wSpSkwajn(lindPred).GetSlojNaSkwajne

    '    Dim LglubinaPred = lSloiPred.First.Glubina
    '    For Each el As GranizaSlojIgeRealDwg In lSloiPred
    '        Dim linMejSmesh As GrebenProfilReal
    '        Dim elprot As GranizaSlojIgeRealDwg = wSpSkwajn(lInd).GetPoIgeSlojNaSkwajne(el.IndexIge)
    '        If elprot Is Nothing Then
    '            lSpSlojwWtochki.Add(New GranizaSlojIgeRealDwg(CType(wRasst.Trassa, DwgTr), wparam.KoeffGeo, lTochkaProfil, el.Glubina, el.IndexIge))
    '        Else
    '            linMejSmesh = New GrebenProfilReal(linMej.GetSmeschen(el.Glubina, elprot.Glubina))
    '            Dim lTochka = linMejSmesh.GetPointLinii(IRast)
    '            lSpSlojwWtochki.Add(New GranizaSlojIgeRealDwg(CType(wRasst.Trassa, DwgTr), wparam.KoeffGeo, lTochkaProfil, lTochkaProfil.Y - lTochka.Y, el.IndexIge))
    '            LglubinaPred = lTochkaProfil.Y - lTochka.Y
    '        End If

    '    Next
    '    Return lSpSlojwWtochki
    'End Function
#Region "Get"
    ' ''' <summary>
    ' ''' Возвращает список слоев в скважине с привязкой к реальным координатам
    ' ''' </summary>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Friend Function GetSlojIgeNaSkwajnah() As List(Of SlojIgeRealDwg)
    '    Dim lSpslojwPoSkwajnami As New List(Of SlojIgeRealDwg)
    '    For Each el As ObrazSkwajn In wObrazGeolog.SpSkwajn
    '        Dim lrBeg = wKoorRasst.GetReal(el.ZentrSkwajnDwg)
    '        Dim lotmBeg = wRasst.Trassa.GetOtmetka(lrBeg)


    '        For Each elh As SlojIgeDwg In el.SlojBeg
    '            Dim lotmetka As Double = wKoorOtm.GetReal(el.YMax)
    '            '    Dim lKoor As New clsKoor(wparam.Maschtab, lotmetka, el.YMax)
    '            Dim lrEnd = wKoorRasst.GetReal(elh.RastOtNachalaDWGEnd)
    '            Dim lotmEnd = wRasst.Trassa.GetOtmetka(lrEnd)
    '            lSpslojwPoSkwajnami.Add(New SlojIgeRealDwg(wparam, elh, CType(wRasst.Trassa, ProfilBaseDwg.DwgTr), _
    '                                                       New PointReal(lrBeg, lotmBeg), New PointReal(lrEnd, lotmBeg)))
    '        Next

    '    Next
    '    Return lSpslojwPoSkwajnami
    'End Function
    ReadOnly Property LinijProfilDwg() As BazDwg.GrebenProfilDwg
        Get
            Return wLinijProfilDwg
        End Get
    End Property
    Friend Function GetSlojIgeNaSkwajnah() As List(Of GranizaSlojIgeRealDwg)
        Dim lSpslojwPoSkwajnami As New List(Of GranizaSlojIgeRealDwg)
        For Each el As SkwajnaRealDwg In wSpSkwajn
            Dim lrBeg = el.Rastojnie  '                           wKoorRasst.GetReal(el.ZentrSkwajnDwg)
            Dim lotmBeg = wRasst.Trassa.GetOtmetka(lrBeg)


            For Each elh As GranizaSlojIgeRealDwg In el.GetSlojNaSkwajne

                lSpslojwPoSkwajnami.Add(elh)

            Next

        Next
        Return lSpslojwPoSkwajnami
    End Function
    ''' <summary>
    ''' Возвращает список скважин с привязкой к реальным координатам.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetSkwajnRealDwg() As List(Of SkwajnaRealDwg)
        Return wSpSkwajn
    End Function
    Function GetSpParamIge() As List(Of LeseGeoIzDwg.ParamIge)
        Return wSpParamIge
    End Function
    Private Function GetParamIge(iIndexIge As String) As ParamIge
        For Each el As ParamIge In wSpParamIge
            If el.IndexIge = iIndexIge Then Return el
        Next
        Return Nothing
    End Function
    ''' <summary>
    ''' Определяет образ скважины после заданому растоянию  от начала профиля .
    ''' </summary>
    ''' <param name="iRast">  заданая координата  </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function OpredWTochkeReal(iRast As Double) As SkwajnaRealDwg
        Dim lIndexPosle As Integer = GetIndexSkwajnPosle(iRast)
        Dim lskwaj As SkwajnaRealDwg
        '  Dim lSpSpslojwPoSkwajne As New List(Of SlojIgeRealDwg)
        If lIndexPosle > -1 Then
            lskwaj = wSpSkwajn(lIndexPosle)
        Else

            lskwaj = wSpSkwajn.Last

        End If

        Return lskwaj

    End Function

    'Function GetRasstanowku() As wlRasst
    '    Return wRasst
    'End Function
#End Region
#Region "Poisk"
    Dim KritRast As Double
    Private Function KritPoiska(iSqj As SkwajnaRealDwg) As Boolean
        If iSqj.Rastojnie >= KritRast Then Return True Else Return False
    End Function
    Function GetIndexSkwajnPosle(iRast As Double) As Integer
        KritRast = iRast
        Return wSpSkwajn.FindIndex(AddressOf KritPoiska)



    End Function
    Function GetSkwajnPosle(iRast As Double) As SkwajnaRealDwg
        KritRast = iRast
        Dim lindex = wSpSkwajn.FindIndex(AddressOf KritPoiska)
        If lindex > -1 Then
            Return wSpSkwajn(lindex)
        Else
            Return Nothing
        End If


    End Function
    Function GetSkwajnDo(iRast As Double) As SkwajnaRealDwg
        KritRast = iRast
        Dim lindex = wSpSkwajn.FindIndex(AddressOf KritPoiska)
        If lindex < 0 Then Return wSpSkwajn.Last
        If lindex = 0 Then Return Nothing
        Return wSpSkwajn(lindex - 1)
    End Function
#End Region
#Region "Formitowat DataSet"
    Shared Sub ParamIgeWDataSet(ids As DsGeologij, idatarRowParamIge As DsGeologij.geoParamIgeRow, el As ParamIge, luiduch As Guid)
        With idatarRowParamIge
            .UidUch = luiduch
            .IndexIGE = modelGeo.GeologijReal.PodobratIge(ids, el.IndexIge, luiduch)
            .PatternAngle = el.PatternAngle
            .PatternScale = el.PatternScale
            .PatternName = el.PatternName
            .Woswrast = Strings.Left(el.Wozrast, ObrazGeologii_Bas.DlinaWozrast)
            .wLineWeight = el.LineWeight

            ids.geoParamIge.AddgeoParamIgeRow(idatarRowParamIge)

        End With
    End Sub
    ''' <summary>
    ''' Извлекает параметры отображения в чертеже и сохраняет в DataSet
    ''' </summary>
    ''' <param name="ids">  Сохраненая модель геологии   </param>
    ''' <remarks></remarks>
    Private Sub IzwlechParamIgeWDataSet(ids As DsGeologij)
        Dim lUidUch = CType(wRasst.Trassa.Uchastki(1), clsPrf.clsUchPrf).UidUch
        For Each el As LeseGeoIzDwg.ParamIge In wSpParamIge
            Dim LDrParam As DsGeologij.geoParamIgeRow = ids.geoParamIge.NewgeoParamIgeRow
            'With LDrParam
            '    .UidUch = lUidUch
            '    .IndexIGE = el.IndexIge
            '    .PatternAngle = el.PatternAngle
            '    .PatternScale = el.PatternScale
            '    .PatternName = el.PatternName
            '    .Woswrast = el.Wozrast
            '    .wLineWeight = el.LineWeight
            '    If ids.geoParamIge.FindByUidUchIndexIGE(.UidUch, .IndexIGE) Is Nothing Then
            '        ids.geoParamIge.AddgeoParamIgeRow(LDrParam)
            '    Else
            '        BazfunNet.SystemKommand.Soob(Me.ToString & "IzwlechParamIgeWDataSet:      Повтор ИГЕ не включаеться " & .IndexIGE & " штрих " & .PatternName _
            '                                    & " угол " & .PatternAngle & " масштаб " & .PatternScale)
            '    End If
            'End With
            ParamIgeWDataSet(ids, LDrParam, el, lUidUch)
        Next
        Dim ldr = ids.geoParamIge.FindByUidUchIndexIGE(lUidUch, modelGeo.TipOpred.IndexIgePoDefault)
        If ldr Is Nothing Then
            Dim el As New ParamIge
            Dim LDrParam As DsGeologij.geoParamIgeRow = ids.geoParamIge.NewgeoParamIgeRow
            ParamIgeWDataSet(ids, LDrParam, el, lUidUch)
        End If

    End Sub
    Sub ZapolnitDsGeologii(iDsGeo As DsGeologij)
        For Each sel As SkwajnaRealDwg In wSpSkwajn    '                  ''Это можно внутрь класса?
            sel.ustanowitDatarow(iDsGeo)
        Next
        IzwlechParamIgeWDataSet(iDsGeo)
        iDsGeo.AcceptChanges()
    End Sub
#End Region



    'Private Function EstliSkwajna(iRast As Double) As Boolean
    '    Dim ldop = ObrazGeoloGii.OkoloSkwajnDwg / wTrassaDwg.objGeom.KoorP.Koeff
    '    For Each el As SkwajnaRealDwg In wSpSkwajn
    '        If el.Rastojnie > iRast Then
    '            If el.Rastojnie - iRast < 2.0 * ldop Then Return True
    '        Else
    '            If iRast - el.Rastojnie < ldop Then Return True
    '        End If

    '    Next
    '    Return False
    'End Function
    'Sub WiwestiPochwSloj()
    '    Dim lsp = wLinijProfilDwg.GetWseLinij
    '    Dim collObjectid As New ObjectIdCollection
    '    Dim lbeg As Double = lsp.First.X
    '    Dim lend As Double = lsp.Last.X
    '    For pr As Double = lbeg To lend Step 15
    '        Dim lRast = wTrassaDwg.objGeom.KoorP.GetReal(pr)
    '        If EstliSkwajna(lRast) Then Continue For
    '        Dim lpoint = wLinijProfilDwg.GetPointLinii(pr)

    '        Dim lobjId As ObjectId = BazDwg.MakeEntities.CreateWstawkBlock(New Point3d(lpoint.X, lpoint.Y, 0), modelGeo.TipOpred.NameBlockPochwa)
    '        collObjectid.Add(lobjId)
    '    Next
    '    Kommand.changeSloj(collObjectid, SkwajnaRealDwg.NameSlojDwgIGE)
    'End Sub
End Class
