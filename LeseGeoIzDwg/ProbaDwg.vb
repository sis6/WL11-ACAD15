Public Class ProbaDwg
    Property Tip As Boolean
    Private wOtmetkaDwg As Double
    Property Consistezij As Integer
    Property OtmetkaDwg As Double
        Get
            Return wotmetkaDwg
        End Get
        Set(value As Double)
            wOtmetkaDwg = value
        End Set
    End Property
    Sub New(iOtmetka As Double)
        wOtmetkaDwg = iOtmetka
    End Sub
End Class
