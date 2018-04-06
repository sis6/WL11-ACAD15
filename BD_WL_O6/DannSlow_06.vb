Imports BazDwg

Public Class DannSlow_06
    Public Const NameDict As String = "profil"
    Const NameZapWL As String = "NameLin"
    Const KorZapUch As String = "NameUch"
    Private wNamelin, wnameUch As String
    Private wKoeffX, wkoeffH, wOtmMin, wOtmBeg, wBegUch, wEndUch As Double
    Private wRazmPar As Integer
    Private Function Mashtab(ByVal Koeff As Double) As Integer
        Select Koeff
            Case Is > 19.99

                Return 50
            Case Is > 9.99
                Return 100
            Case Is > 4.99

                Return 200
            Case Is > 1.99
                Return 500
            Case Is > 0.99
                Return 1000
            Case Is > 0.499
                Return 2000

            Case Else
                Return 5000
        End Select
    End Function
    ReadOnly Property NameUch As String
        Get
            Return wnameUch
        End Get
    End Property
    ReadOnly Property NameLin As String
        Get
            Return wNamelin
        End Get
    End Property
    ReadOnly Property BegUch As Double
        Get
            Return wBegUch
        End Get
    End Property
    ReadOnly Property EndUch As Double
        Get
            Return wEndUch
        End Get
    End Property
    ReadOnly Property MashtabX As Integer
        Get
            Return Mashtab(wKoeffX)
        End Get
    End Property
    ReadOnly Property MashtabH As Integer
        Get
            Return Mashtab(wkoeffH)
        End Get
    End Property
    ReadOnly Property OtmMin As Double
        Get
            Return wOtmMin
        End Get
    End Property
    ReadOnly Property Dwg06 As Boolean
        Get
            If wRazmPar <= 0 Then Return False
            Return True


        End Get
    End Property

    Public Sub Izwlech()
        Dim SlParam As New dwgSlowar(NameDict)
        Dim lDann() As String

        lDann = SlParam.ZapisIzSlovarStr(NameZapWL)

        Try
            wRazmPar = UBound(lDann)
        Catch ex As Exception
            wRazmPar = -1
            Exit Sub
        End Try
        If wRazmPar <= 0 Then Exit Sub

        wNamelin = lDann(0)

        If wRazmPar > 0 Then
            wnameUch = lDann(1)
        End If
        If wRazmPar > 2 Then
            wKoeffX = CDbl(lDann(3))
        End If
        If wRazmPar > 3 Then
            wkoeffH = CDbl(lDann(4))
        End If
        If wRazmPar > 4 Then
            wOtmMin = CDbl(lDann(5))
        End If
        If wRazmPar > 5 Then
            wEndUch = CDbl(lDann(6))
        End If
        Dim lBeg() As String = SlParam.ZapisIzSlovarStr(KorZapUch & "0")
        wOtmBeg = CDbl(lBeg(0))
        wBegUch = CDbl(lBeg(1))
    End Sub
End Class
