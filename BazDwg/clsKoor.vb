Public Class clsKoor
    'Диапазон масштабов ValueE = K*ValueR
    '` 1:50 - K = 20
    '  1:100  k 10
    ' I = N   k 1000.0/N
    Private wMaschtab As Integer
    Private wKoeffMaschtaba As Double
    Private wNameMaschtab As String
    Private A As Double

    Public Sub New(ByVal zN As Integer, ByVal iKoorReal As Double, ByVal iKoorDwg As Double)
        wMaschtab = zN
        wKoeffMaschtaba = 1000.0 / CDbl(wMaschtab)

        A = iKoorDwg - wKoeffMaschtaba * iKoorReal
    End Sub
    Public Sub New(ByVal ikoeff As Double, ByVal iKoorReal As Double, ByVal iKoorDwg As Double)

        wKoeffMaschtaba = ikoeff
        wMaschtab = 1000.0 / wKoeffMaschtaba


        A = iKoorDwg - wKoeffMaschtaba * iKoorReal
    End Sub
    ReadOnly Property Koeff() As Double
        Get
            Return wKoeffMaschtaba
        End Get
    End Property
    ReadOnly Property NameMaschtab() As String
        Get
            Return "1:" & CStr(wMaschtab)
        End Get
    End Property
    ReadOnly Property Maschtab() As Integer
        Get
            Return wMaschtab
        End Get
    End Property
    'ReadOnly Property RealOsn As Double
    '    Get
    '        Return kR
    '    End Get
    'End Property
    Function GetReal(ByVal KoorDwg As Double) As Double
        Return (KoorDwg - A) / wKoeffMaschtaba
    End Function
    Function GetDwg(ByVal KoorReal As Double) As Double
        Return A + wKoeffMaschtaba * KoorReal
    End Function
End Class
