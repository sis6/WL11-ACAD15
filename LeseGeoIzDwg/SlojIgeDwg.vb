#If ARX_APP Then
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.DatabaseServices

#Else
Imports Teigha.Geometry
Imports Teigha.DatabaseServices

#End If


Imports BazDwg

''' <summary>
''' Образ слоя в чертеже по штриховки строиться контур определяеться номерт ИГЭ и граничнвые скважины
''' </summary>
''' <remarks></remarks>
Public Class SlojIgeDwg
    Inherits clsHatch
    Private wIdent As String = modelGeo.TipOpred.IndexIgePoDefault
    Private wWozrast As String = modelGeo.TipOpred.WozwrastPoDefault
    Private wSkwajBeg, wSkwajEnd As ObrazSkwajn
    ' Private wMtext As MText  ' Примитив мультитекст в который занесен ИГЭ

#Region "Postroenie konstruktor"
    Property NumGlobSLoj As Integer
    Sub New(iHatch As clsHatch, iIdent As String)
        MyBase.New(iHatch)

        wIdent = iIdent

    End Sub
    Sub New(iHatch As clsHatch, iMtextIdent As MText)
        MyBase.New(iHatch)
        '   wMtext = iMtextIdent
        wIdent = Strings.Left(iMtextIdent.Text, ObrazGeologii_Bas.DlinaIndexIge)

    End Sub
    ''' <summary>
    ''' определяет условия на границах слоя скважины если они есть 
    ''' определяет точки выклинивая и ограничения в 
    ''' </summary>
    ''' <param name="SpSkwaj"> список образов скважин по линейным примитивам </param>
    ''' <param name="SpProm"> список точек в координатах профиля граничных точек слоев несовпадающих с скважинами   </param>
    ''' <remarks></remarks>
    Sub OpredGranSloj(SpSkwaj As List(Of ObrazSkwajn), SpProm As List(Of Integer))
        Dim lminRast As Double = ObrazGeoloGii.ShirinaObrazSkwajn
        Dim lminRastEnd As Double = ObrazGeoloGii.ShirinaObrazSkwajn
        '  Dim Lws As New List(Of SlojIgeDwg)
        Dim lwHatch = Me.GetHatch()

        'ЦИКЛ ПО СКВАЖИНАМ находим все слои расположеные около скважин так и подними   
        For Each el As ObrazSkwajn In SpSkwaj  'Много лишних проверок
            If Math.Abs(RastOtNachalaDwgBeg - el.ZentrSkwajnDwg) < lminRast Then

                lminRast = Math.Abs(RastOtNachalaDwgBeg - el.ZentrSkwajnDwg)
                wSkwajBeg = el
                If Me.LinijBegLi Then wSkwajBeg.AddSloj(Me)
                Continue For
            End If
            If Math.Abs(RastOtNachalaDWGEnd - el.ZentrSkwajnDwg) < lminRastEnd Then

                lminRastEnd = Math.Abs(RastOtNachalaDWGEnd - el.ZentrSkwajnDwg)
                wSkwajEnd = el
                wSkwajEnd.AddSlojEnd(Me)
                Continue For
            End If
            If Me.MejduX(el.ZentrSkwajnDwg) Then
                ' 
                el.AddSlojPeresech(Me)
            End If



        Next
        If wSkwajBeg Is Nothing AndAlso wSkwajEnd Is Nothing Then Return
        If wSkwajBeg Is Nothing Then
            SearchAndInsert(Of Integer)(SpProm, CInt(RastOtNachalaDwgBeg))
      
        End If
        If wSkwajEnd Is Nothing Then
            SearchAndInsert(Of Integer)(SpProm, CInt(RastOtNachalaDWGEnd))

        End If
        '    i = SpProm.Count
    End Sub
    Friend Sub SetIndex(iInd As String)
        wIdent = iInd
    End Sub
#End Region
#Region "read onlu Get"
    ReadOnly Property nameSkwajBeg() As String
        Get
            If wSkwajBeg Is Nothing Then
                Return "#" & CInt(RastOtNachalaDwgBeg)
            Else
                Return wSkwajBeg.NameSkwaj
            End If

        End Get
    End Property
    ReadOnly Property nameSkwajEnd() As String
        Get
            If wSkwajEnd Is Nothing Then
                Return "#" & CInt(RastOtNachalaDWGEnd)
            Else
                Return wSkwajEnd.NameSkwaj
            End If

        End Get
    End Property
    ReadOnly Property IndexIge() As String
        Get
            Return wIdent
        End Get
    End Property
    'Function GetSkwajBeg() As ObrazSkwajn
    '    Return wSkwajBeg
    'End Function
    'Function GetSkwajEnd() As ObrazSkwajn
    '    Return wSkwajEnd
    'End Function
    Function GetParaMIge() As ParamIge
        Return New ParamIge(Me, wWozrast)
    End Function
#End Region
    'Private Sub WirownjtPoGranizamSkwaj()

    '    '   Dim wpolyline = wslojIge.GetWneschyijkontur
    '    Dim walgD = GetOgranHatch.GetAlgDjris
    '    Dim lRazrezBeg As Razrez = GetOgranHatch.LewPeresechenie()
    '    Dim lrazrezEnd As Razrez = GetOgranHatch.PrawPeresechenie
    '    Dim niz As List(Of Point2d) = walgD.GetNijnijGraniza
    '    Dim werh As List(Of Point2d) = walgD.GetWerhGraniza

    '    If wSkwajBeg IsNot Nothing Then


    '        niz.Insert(0, New Point2d(wSkwajBeg.ZentrSkwajnDwg, lRazrezBeg.MinTochka2D.Y))

    '        werh.Add(New Point2d(wSkwajBeg.ZentrSkwajnDwg, lRazrezBeg.MaxTochka2D.Y))
    '    End If

    '    If wSkwajEnd IsNot Nothing Then

    '        niz.Add(New Point2d(wSkwajEnd.ZentrSkwajnDwg, lrazrezEnd.MinTochka2D.Y))

    '        werh.Insert(0, New Point2d(wSkwajEnd.ZentrSkwajnDwg, lrazrezEnd.MaxTochka2D.Y))
    '    End If

    '    walgD.SozdatPoWerhNizu()

    'End Sub
    'Sub UstanowitIgeWozwrast(iSpParamIge As List(Of ParamIge))
    '    Dim lparamhatch As New ParamHatch(GetHatch())
    '    For Each el As ParamIge In iSpParamIge
    '        If ComparatorParamIge.CompareHatch(el, lparamhatch) = 0 Then
    '            wIdent = el.IndexIge
    '            wWozrast = el.Wozrast
    '        End If
    '    Next
    'End Sub

End Class



''' <summary>
''' Разрез слоя   в чертеже, по  заданой координате Ч 
''' </summary>
''' <remarks></remarks>
Public Class RazrezSlojIgeDwg
    Private wYNizDwg As Double 'нижняя точка слоя
    Private wYwerhDwg As Double
    Private wXsloj As Double
    'Private wHsloj As Double
    Private wSlojIgeDwg As SlojIgeDwg
#Region "Konstruirowanie"
    'Sub New(iX As Double, iYwerh As Double, iYniz As Double)
    '    wXsloj = iX
    '    wYwerhDwg = iYwerh
    '    wYNizDwg = iYniz


    'End Sub
    'Sub New(iX As Double, iHatch As Hatch)
    '    wSlojIgeDwg = New SlojIgeDwg(New clsHatch(iHatch), ParamIge.IndexIgePoDefault)
    '    Dim YperCurv() As Double = ObrazGeoloGii.PeresechenieLineHatch(iHatch, iX)
    '    ' wParamIge = wslojIgeDwg.GetParaMIge
    '    ' New ParamIge(iHatch.PatternName, iHatch.PatternScale, iHatch.PatternAngle, iHatch.LineWeight, ParamIge.IndexIgePoDefault, ParamIge.WozwrastPoDefault)
    '    wXsloj = iX
    '    wYNizDwg = YperCurv(0)
    '    wYwerhDwg = YperCurv(1)
    '    ' wHsloj = YperCurv(1) - YperCurv(0)
    'End Sub
    Sub New(iX As Double, iSlojIgeDwg As SlojIgeDwg)
        wSlojIgeDwg = iSlojIgeDwg
        Dim lclshatch As clsHatch = CType(iSlojIgeDwg, clsHatch)
        Dim lrazrez As Razrez = lclshatch.GetPeresecheniePl(iX)

        wXsloj = iX
        wYNizDwg = lrazrez.MinTochka2D.Y
        wYwerhDwg = lrazrez.MaxTochka2D.Y
        ' wHsloj = lrazrez.Tolschina

    End Sub
    Sub New(iSlojIgeDwg As SlojIgeDwg)
        'wSlojIgeDwg = iSlojIgeDwg
        'Dim lOgra As OgranHatch = iSlojIgeDwg.GetOgranHatch
        'With lOgra.LewPeresechenie
        '    wXsloj = .MaxTochka.X
        '    wYNizDwg = .MinTochka.Y
        '    wYwerhDwg = .MaxTochka.Y
        '    '        wHsloj = wYwerhDwg - wYNizDwg

        'End With
        Me.New(iSlojIgeDwg.RastOtNachalaDwgBeg, iSlojIgeDwg)
    End Sub
    Sub New(iSlojIgeDwg As SlojIgeDwg, PrKonza As Boolean)
     
        Me.New(iSlojIgeDwg.RastOtNachalaDWGEnd, iSlojIgeDwg)
    End Sub
    'Sub SetGlubinu(iYotchetaDwg As Double, IglubinaDwg As Double)
    '    wYwerhDwg = iYotchetaDwg - IglubinaDwg
    '    If wYwerhDwg < wYNizDwg Then wYNizDwg = wYwerhDwg
    'End Sub

#End Region
#Region "ReadOnly Get"
    'Function equalsSl(iSloj As RazrezSlojIgeDwg) As Boolean
    '    Return wSlojIgeDwg.Equals(iSloj)
    'End Function
    ReadOnly Property PatternNameSloj() As String
        Get
            Try
                Return wSlojIgeDwg.GetParaMIge.PatternName
            Catch ex As Exception
                Return ""
            End Try

        End Get
    End Property

    ''' <summary>
    ''' координата нижней точки в чертеже
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property YnizDwg As Double
        Get
            Return wYNizDwg
        End Get
    End Property
    ReadOnly Property YwerhDwg As Double
        Get
            Return wYwerhDwg
        End Get
    End Property
    ReadOnly Property TolshinaDwg As Double
        Get
            Return wYwerhDwg - wYNizDwg
        End Get
    End Property
    ReadOnly Property Xsloj As Double
        Get
            Return wXsloj
        End Get
    End Property
    ReadOnly Property IndexIge() As String
        Get
            Try
                Return wSlojIgeDwg.IndexIge
            Catch ex As Exception
                Return modelGeo.TipOpred.IndexIgePoDefault
            End Try

        End Get
    End Property
    ReadOnly Property NumGlobalSloj As Integer
        Get
            If TolshinaDwg < ObrazGeologii.KritBlizostiDwg Then
                Return -wSlojIgeDwg.NumGlobSLoj
            Else
                Return wSlojIgeDwg.NumGlobSLoj
            End If

        End Get
    End Property

#End Region


    Shared Function SrawnitPoYwerh(xDwgSloj As RazrezSlojIgeDwg, yDwgSloj As RazrezSlojIgeDwg) As Integer

        Return xDwgSloj.YwerhDwg.CompareTo(yDwgSloj.YwerhDwg)


    End Function
End Class




