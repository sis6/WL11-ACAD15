#If ARX_APP Then
Imports Autodesk.AutoCAD.DatabaseServices
#Else
Imports Teigha.DatabaseServices
#End If

Public Class UgwDwgClass
    Private wGlubinaGruntWod As MText
    Private wOtmetkaGruntwod As MText
    Private WOtmetka, wGlubina As Double
    Private wPrizhakProbUgw As Boolean
    Private wDataPob As Date
    Shared Function ProverkaPriznakaOtmetok(wOtmetka As MText) As Boolean
        Dim lstr As String = wOtmetka.Text
        Dim lrazd As String = "▼"
        '   If lstr.IndexOf(lrazd) > 0 Then Return True Else Return False
        Return lstr.IndexOf(lrazd) > 0

    End Function
    Function PreobrGlubin() As Double
        Dim lstr As String = wGlubinaGruntWod.Text

        Return Val(lstr.Replace(",", "."))
    End Function
    Function OpredDate() As Date
        Dim lstr As String = wOtmetkaGruntwod.Text
        Dim lrazd As String = "▼"
        Dim ind = lstr.LastIndexOf(lrazd)
        Dim lStrDat As String = lstr.Substring(ind + 1).Trim
        Dim lstrOtmetok As String = lstr.Substring(0, ind)

        WOtmetka = Val(lstrOtmetok.Replace(",", "."))

        Dim ldate = CDate(lStrDat)
        Return ldate

    End Function
    Shared Function TextOtmetok(iOtm As Double, idat As Date) As String
        Return "\pxse0.6,gr;" & Format(iOtm, "f2") & "{\fArial|b0|i0|c204|p34;\H0.8333x;\W1.2;▼}\P\pb0.25;{\O" & idat & "}"
    End Function
    Sub New(Iglubin As MText, iOtmetok As MText, Optional iPrProb As Entity = Nothing)
        wGlubinaGruntWod = Iglubin
        wOtmetkaGruntwod = iOtmetok
        If Iglubin IsNot Nothing Then
            wGlubina = PreobrGlubin()
        Else
            wGlubina = Double.NaN
        End If
        If iOtmetok IsNot Nothing Then
            wDataPob = OpredDate()
        Else
            WOtmetka = Double.NaN
            wDataPob = Date.MinValue
        End If
        If iPrProb Is Nothing Then
            wPrizhakProbUgw = False
        Else
            wPrizhakProbUgw = True
        End If
    End Sub
    ReadOnly Property Glubina() As Double
        Get
            Return wGlubina
        End Get
    End Property
    ReadOnly Property Otmetka() As Double
        Get
            Return WOtmetka
        End Get
    End Property
    ReadOnly Property DataProbUgw() As Date
        Get
            Return wDataPob
        End Get
    End Property
    ReadOnly Property PriznakProbUgw As Boolean
        Get
            Return wPrizhakProbUgw
        End Get
    End Property
End Class
