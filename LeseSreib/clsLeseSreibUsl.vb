Option Strict On
Option Explicit On

Imports BazDwg
Imports clsPrf
Imports modRasstOp
Public Enum UslRascheta
	PrZentrTaj = 0
	IshRejName = 1
    IshRejGamma = 2
    IshRejTemp = 3
    IshRejSigma = 4
    GabRejName = 5
    GabRejGamma = 6
    GabRejTemp = 7
    GabRejSigma = 8
    PrZentrTajT = 9
    IshRejNameT = 10
    IshRejGammaT = 11
    IshRejTempT = 12
    IshRejSigmaT = 13
    GabRejNameT = 14
    GabRejGammaT = 15
    GabRejTempT = 16
    MaxNum = 16
End Enum
Public Class UslRaschetaCls
    Property NameUsl As String
    Property PrZentrTaj As Double
    Property PrZentrTajT As Double
    Property IshRejGamma As Double
    Property IshRejSigma As Double
    Property GabRejGamma As Double
    Property GabRejSigma As Double
    Property IshRejGammaT As Double
    Property IshRejSigmaT As Double
    Property GabRejGammaT As Double
    Property IshRejTemp As Double
    Property GabRejTemp As Double
    Property IshRejTempT As Double
    Property GabRejTempT As Double
    Property IshRejName As String
    Property GabRejName As String
    Property IshRejNameT As String
    Property GabRejNameT As String
    Private Function zadat(ByRef zTxt As String, ByVal def As Double) As Double
        Try
            Return CDbl(zTxt)
        Catch ex As Exception
            Return def
        End Try


    End Function

    Private Function zadat(ByRef zTxt As String, ByVal def As String) As String
        If String.IsNullOrEmpty(zTxt) Then
            Return def
        Else
            Return zTxt
        End If
    End Function
    Private Sub zadat(ByVal i As UslRascheta, ByVal val As String)
        Select Case i
            Case UslRascheta.PrZentrTaj 'Property PrZentrTaj As Double  'PrZentrTaj = 0
                PrZentrTaj = zadat(val, 20)
            Case UslRascheta.IshRejName 'Property IshRejName As String  'IshRejName = 1
                IshRejName = zadat(val, "IshRej")
            Case UslRascheta.IshRejGamma    'Property IshRejGamma As Double 'IshRejGamma = 2
                IshRejGamma = zadat(val, 0.01)
            Case UslRascheta.IshRejTemp   'Property IshRejTemp As Double 'IshRejTemp = 3
                IshRejTemp = zadat(val, -5)
            Case UslRascheta.IshRejSigma  'Property IshRejSigma As Double   'IshRejSigma = 4
                IshRejSigma = zadat(val, 0.01)
            Case UslRascheta.GabRejName  'Property GabRejName As String 'GabRejName = 5
                GabRejName = zadat(val, "GabRej")
            Case UslRascheta.GabRejGamma  'Property GabRejGamma As Double'GabRejGamma = 6 
                GabRejGamma = zadat(val, 0.01)
            Case UslRascheta.GabRejTemp    'Property GabRejTemp As Double  'GabRejTemp = 7
                GabRejTemp = zadat(val, -5)
            Case UslRascheta.GabRejSigma   'Property GabRejSigma As Double 'GabRejSigma = 8
                GabRejSigma = zadat(val, 100)
            Case UslRascheta.PrZentrTajT   'Property PrZentrTajT As Double   'PrZentrTajT = 9
                PrZentrTajT = zadat(val, 30)
            Case UslRascheta.IshRejNameT 'Property IshRejNameT As String  'IshRejNameT = 10
                IshRejNameT = zadat(val, "IshRejT")
            Case UslRascheta.IshRejGammaT    'Property IshRejGammaT As Double 'IshRejGammaT = 11
                IshRejGammaT = zadat(val, 0.1)
            Case UslRascheta.IshRejTempT  'Property IshRejTempT As Double    'IshRejTempT = 12
                IshRejTempT = zadat(val, 100)
            Case UslRascheta.IshRejSigmaT  'Property IshRejSigmaT As Double 'IshRejSigmaT = 13
                IshRejSigmaT = zadat(val, 200)
            Case UslRascheta.GabRejNameT 'Property GabRejNameT As String
                GabRejNameT = zadat(val, "GabRejT")  'GabRejNameT = 14  
            Case UslRascheta.GabRejGammaT   'Property GabRejGammaT As Double
                GabRejGammaT = zadat(val, 0.02) 'GabRejGammaT = 15 
            Case UslRascheta.GabRejTempT  'Property GabRejTempT As Double   'GabRejTempT = 16
                GabRejTempT = zadat(val, 200)
        End Select


    End Sub
    Property StrPred() As String()
        Get
            Dim lStr(UslRascheta.MaxNum) As String
            For i As Integer = 0 To UslRascheta.MaxNum
                Select Case i
                    Case UslRascheta.PrZentrTaj 'Property PrZentrTaj As Double  'PrZentrTaj = 0
                        lStr(UslRascheta.PrZentrTaj) = CStr(PrZentrTaj)
                    Case UslRascheta.IshRejName 'Property IshRejName As String  'IshRejName = 1
                        lStr(i) = IshRejName
                    Case UslRascheta.IshRejGamma    'Property IshRejGamma As Double 'IshRejGamma = 2
                        lStr(i) = CStr(IshRejGamma)
                    Case UslRascheta.IshRejTemp   'Property IshRejTemp As Double 'IshRejTemp = 3
                        lStr(i) = CStr(IshRejTemp)
                    Case UslRascheta.IshRejSigma  'Property IshRejSigma As Double   'IshRejSigma = 4
                        lStr(i) = CStr(IshRejSigma)
                    Case UslRascheta.GabRejName  'Property GabRejName As String 'GabRejName = 5
                        lStr(i) = GabRejName
                    Case UslRascheta.GabRejGamma  'Property GabRejGamma As Double'GabRejGamma = 6 
                        lStr(i) = CStr(GabRejGamma)
                    Case UslRascheta.GabRejTemp    'Property GabRejTemp As Double  'GabRejTemp = 7
                        lStr(i) = CStr(GabRejTemp)
                    Case UslRascheta.GabRejSigma   'Property GabRejSigma As Double 'GabRejSigma = 8
                        lStr(i) = CStr(GabRejSigma)
                    Case UslRascheta.PrZentrTajT   'Property PrZentrTajT As Double   'PrZentrTajT = 9
                        lStr(i) = CStr(PrZentrTajT)
                    Case UslRascheta.IshRejNameT 'Property IshRejNameT As String  'IshRejNameT = 10
                        lStr(i) = IshRejNameT
                    Case UslRascheta.IshRejGammaT    'Property IshRejGammaT As Double 'IshRejGammaT = 11
                        lStr(i) = CStr(IshRejGammaT)
                    Case UslRascheta.IshRejTempT  'Property IshRejTempT As Double    'IshRejTempT = 12
                        lStr(i) = CStr(IshRejTempT)
                    Case UslRascheta.IshRejSigmaT  'Property IshRejSigmaT As Double 'IshRejSigmaT = 13
                        lStr(i) = CStr(IshRejSigmaT)
                    Case UslRascheta.GabRejNameT 'Property GabRejNameT As String
                        lStr(i) = GabRejNameT  'GabRejNameT = 14  
                    Case UslRascheta.GabRejGammaT   'Property GabRejGammaT As Double
                        lStr(i) = CStr(GabRejGammaT) 'GabRejGammaT = 15 
                    Case UslRascheta.GabRejTempT  'Property GabRejTempT As Double   'GabRejTempT = 16
                        lStr(i) = CStr(GabRejTempT)
                End Select
            Next
            Return lStr
        End Get
        Set(ByVal value As String())
            For I As Integer = 0 To UslRascheta.MaxNum
                Dim lstr As String
                Try
                    lstr = value(I)
                Catch ex As Exception
                    lstr = ""
                End Try
                zadat(CType(I, UslRascheta), lstr)
            Next

        End Set
    End Property



End Class
Public Class clsLeseSreibUsl
    'Private wTrassa As clsTrass
    'Private wRasst As wlRasst

    Private wGlSl As dwgSlowar
    Private wNameAnkOp As List(Of String)
    ReadOnly Property Slowar As dwgSlowar
        Get
            Return wGlSl
        End Get
    End Property
    Sub New(ByVal iRasst As modRasstOp.wlRasst)
        wGlSl = New dwgSlowar(dwgSlowar.DopustImjSlowaraj(iRasst.Trassa.NameLin))
    End Sub
    Function GetZapis(ByVal NameZap As String) As String()
        Return wGlSl.ZapisIzSlovarStr(NameZap)
    End Function
    Sub SetZapis(ByVal NameZap As String, ByVal masStr As String())
        wGlSl.ZapisW_SlowarStr(NameZap, masStr)
    End Sub
End Class
