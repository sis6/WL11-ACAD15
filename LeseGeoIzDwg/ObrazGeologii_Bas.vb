
#If ARX_APP Then
Imports Autodesk.AutoCAD.DatabaseServices
#Else
Imports Teigha.DatabaseServices
#End If
Imports BazDwg
Public Class WseSloiIgeDwg
    Private wParamIge As ParamIge
    Private wSlojEtogoIge As List(Of SlojIgeDwg) ' As    'List(Of SlojIgeDwg) IEnumerable(Of SlojIgeDwg) 
    Private wGlobSloi() As List(Of SlojIgeDwg)
    Private wKolwoGlSlojw As Integer
    Sub New(iParamige As ParamIge, iSpSlojwProfil As List(Of SlojIgeDwg))
        wParamIge = iParamige
        wKolwoGlSlojw = 0
        wSlojEtogoIge = (From p As SlojIgeDwg In iSpSlojwProfil Where p.IndexIge.Equals(iParamige.IndexIge) Select p).ToList
        OpredelitGSloi()
    End Sub
    
    ReadOnly Property Indexige() As String
        Get
            Return wParamIge.IndexIge
        End Get
    End Property
    Private Function AddKGlSloi(iSpWibr As List(Of SlojIgeDwg)) As Boolean
        For Each el As SlojIgeDwg In wSlojEtogoIge
            If iSpWibr.Count = 0 Then
                iSpWibr.Add(el)
                el.NumGlobSLoj = wKolwoGlSlojw
                wSlojEtogoIge.Remove(el)
                Return True
            End If
            Dim lprL = iSpWibr.Last.Rajdom(el)
            If lprL = -1 Then
                iSpWibr.Add(el)
                el.NumGlobSLoj = wKolwoGlSlojw
                wSlojEtogoIge.Remove(el)
                Return True
            Else
                Continue For
            End If


        Next
        Return False
    End Function
    Private Sub OpredelitGSloi()
        Dim lPr = False
        Dim ltekGlSloj As List(Of SlojIgeDwg) = Nothing
        Do Until wSlojEtogoIge.Count = 0
            If lPr = False Then
                ReDim Preserve wGlobSloi(wKolwoGlSlojw)
                ltekGlSloj = New List(Of SlojIgeDwg)
                wGlobSloi(wKolwoGlSlojw) = ltekGlSloj
                wKolwoGlSlojw += 1
            End If
            If ltekGlSloj IsNot Nothing Then lPr = AddKGlSloi(ltekGlSloj)
        Loop
    End Sub
#Region "Read Only"
    ReadOnly Property KolwoGlobSloew As Integer
        Get
            Return wKolwoGlSlojw
        End Get
    End Property
    ReadOnly Property Globsloj As List(Of SlojIgeDwg)()
        Get
            Return wGlobSloi
        End Get
    End Property
#End Region
End Class
Public Class ObrazGeologii_Bas
    Public Const DlinaIndexIge = 7
    Public Const DlinaWozrast = 9
    Public Const DopuskGeoDwgX As Double = 0.5
    Public Const DopuskGeoDwgY As Double = 0.1
    Public Const MinTolshinaDwg As Double = 0.1
    Public Const KritBlizostiDwg As Double = 0.1
    Public Const ShirinaObrazSkwajn As Double = 2
    Public Const OkrestnostObraz As Double = 4
    Public Const OkoloSkwajnDwg As Double = 7
    Public Const PolushirinaSdopusk = 0.5 * ShirinaObrazSkwajn + ObrazGeologii.DopuskGeoDwgX
    Public Shared ParamHatchCons() As ParamHatch = _
       {New ParamHatch("ГЛИНА", 1, 0.0, LineWeight.ByLayer),
        New ParamHatch("ГЛИНА", 5, 0.0, LineWeight.ByLayer),
        New ParamHatch("ГЛИНА", 10, 0.0, LineWeight.ByLayer),
        New ParamHatch("SOLID", 10, 0.5 * Math.PI, LineWeight.ByLayer),
        New ParamHatch("ГЛИНА", 5, 0.25 * Math.PI, LineWeight.ByLayer),
        New ParamHatch("ГЛИНА", 5, 0.75 * Math.PI, LineWeight.LineWeight030),
        New ParamHatch("SOLID", 0.5, 0.5 * Math.PI, LineWeight.ByLayer)
              }
    Protected wSpParamiGE As New List(Of ParamIge)
    Protected wSpSlojIge As New List(Of LeseGeoIzDwg.SlojIgeDwg)
    Protected wGlobalSlojIge As List(Of WseSloiIgeDwg)
#Region "Konstruirowanie"
    Private Sub CreateSloiIge(iSpclsHatch As List(Of clsHatch), iSpParamIge As List(Of ParamIge))
        wSpParamiGE = iSpParamIge
        Dim lSpisokNeUstanowl As New List(Of clsHatch)
        Dim wCompHatchIdent As New LeseGeoIzDwg.ComparatorSlojIgeDwg
        '  Dim lIcountOtl As Integer = 0

        Dim lSlojIgeDwg As SlojIgeDwg = Nothing
        For Each elm1 In iSpclsHatch     '  

            Dim lPr = True

            For Each elH As ParamIge In iSpParamIge      ' Цикл по штриховкам представляющих ИГЭ
                If elm1.NeRawnPoParam(elH) Then Continue For


                lSlojIgeDwg = New LeseGeoIzDwg.SlojIgeDwg(elm1, elH.IndexIge)




                LeseGeoIzDwg.ComparatorSlojIgeDwg.SearchAndInsert(wSpSlojIge, lSlojIgeDwg, wCompHatchIdent) ' Вставляем в список слоев ИГЭ

                lPr = False

                Exit For
                '     
                If lPr Then lSpisokNeUstanowl.Add(elm1)

            Next




        Next




    End Sub
    Sub New()

    End Sub
    Sub RaspredPoIge()

        wGlobalSlojIge = New List(Of WseSloiIgeDwg)
        For Each el As ParamIge In wSpParamiGE
            wGlobalSlojIge.Add(New WseSloiIgeDwg(el, wSpSlojIge))
        Next



    End Sub
#End Region
#Region "Shared"
    Shared Function SozdatSpisokClsHatch(iSpEntity As List(Of Entity)) As List(Of clsHatch)
        Dim lSpClsHatch As New List(Of clsHatch)
        For Each elh As Hatch In iSpEntity
            Dim lclsHatch As clsHatch = Nothing
            Try
                lclsHatch = New clsHatch(elh)
            Catch ex As Exception
                lclsHatch = Nothing
            End Try


            If lclsHatch IsNot Nothing AndAlso lclsHatch.GetOgranHatch IsNot Nothing Then
                lSpClsHatch.Add(lclsHatch)
            End If

        Next
        Return lSpClsHatch
    End Function
    Shared Function OpredNumCons(izadHatch As clsHatch) As Integer
        Dim i As Integer = 0
        For Each el As ParamHatch In ParamHatchCons
            If el.equalsParam(izadHatch.GetHatch) Then Return i
            i += 1
        Next
        Return 0
    End Function


    ''' <summary>
    ''' Сравнение двух штриховок для упорядочивания по возрастанию
    ''' </summary>
    ''' <param name="xHatch"> первая штриховка  </param>
    ''' <param name="yHatch">вторая штриховка </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function SrawneniePoY(xHatch As clsHatch, yHatch As clsHatch) As Integer
        If xHatch Is Nothing Then Return 1
        If yHatch Is Nothing Then Return -1

        If xHatch.OtmetkaBegPodwg < yHatch.OtmetkaBegPodwg Then
            Return 1
        Else
            Return -1
        End If


    End Function
#End Region
    Function GetRaspredPoIge() As List(Of WseSloiIgeDwg)
        Return wGlobalSlojIge
    End Function
    Function GetSloiIge() As List(Of LeseGeoIzDwg.SlojIgeDwg)

        Return wSpSlojIge

    End Function
End Class
