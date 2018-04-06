Public Class PointProf
    Public Property X As Double
    Public Property Y As Double
    Public Property Otm As Double
    Public Property Ugol As Double
    Public Property OtmPr As Double
    Public Property otmLw As Double
    Public Property PiketajPr As Double
    Public Property PiketajLw As Double
    Private wPred, wSled As PointProf
    Private wPiketaj As Double

    ReadOnly Property Piketaj As Double
        Get
            Return wPiketaj
        End Get
    End Property

    Sub New(ByVal iX As Double, ByVal iY As Double, ByVal iZ As Double, ByVal iYgol As Double, ByVal iPred As PointProf)
        _X = iX
        _y = iY
        _Otm = iZ
        _Ugol = iYgol
        wPred = iPred
        _OtmPr = Double.NaN
        _otmLw = Double.NaN
        If iPred IsNot Nothing Then
            iPred.wSled = Me
            Dim dX, dY As Double
            dX = _X - wPred.X
            dY = _y - wPred.y
            wPiketaj = iPred.wPiketaj + Math.Sqrt(dX * dX + dY * dY)
        Else
            wPiketaj = 0
        End If


    End Sub
    ReadOnly Property StrUgol() As String
        Get
            If Math.Abs(Ugol) > 0.0001 Then
                Return clsPrf.clsUgolPoworot.StrGradLwPr(Ugol)
            Else
                Return ""
            End If

        End Get
    End Property
End Class

