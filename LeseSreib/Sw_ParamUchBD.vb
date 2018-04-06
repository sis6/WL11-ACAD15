'Imports System.Runtime.InteropServices
'<Guid("936DA01F-9ABD-4d9d-80C7-02AF85C822A8")> _
'Public Class Sw_ParamUchBD
'    Private wDsupr As New OperBD.dsUpr
'    Private taUch As New OperBD.dsUprTableAdapters.uchastkiNTableAdapter

'    Private wRowOuch As OperBD.dsUpr.uchastkiNRow = Nothing

'    Private wUnom As Integer

'    Private Sub Init(ByVal iUidUch As Guid)
'        If iUidUch.Equals(Guid.Empty) Then Return
'        Try
'            '  taDataUch.Fill(wDsupr.DataUchastka, iUidUch)
'            taUch.FillBy(wDsupr.uchastkiN, iUidUch)
'        Catch ex As Exception
'            MsgBox(Me.ToString & " идентификатор участка  " & iUidUch.ToString & " не верно задан ")
'        End Try
'        If wDsupr.uchastkiN.Rows.Count = 0 Then
'            MsgBox(Me.ToString & " участок  с " & iUidUch.ToString & " отсутствует в БД ")
'        Else

'            wRowOuch = wDsupr.uchastkiN.Rows(0)
'        End If
'    End Sub

'    Sub New(ByVal iUidUch As Guid, Optional ByVal iUnom As Integer = 750)
'        wUnom = iUnom
'        Init(iUidUch)
'        If wRowOuch IsNot Nothing Then wUnom = wRowOuch.Unom
'    End Sub


'    ReadOnly Property UidUch() As Guid
'        Get
'            Try
'                Return wRowOuch.UIdUch
'            Catch ex As Exception
'                Return Guid.Empty
'            End Try

'        End Get
'    End Property
'    ReadOnly Property nameUch As String
'        Get
'            Return wRowOuch.NameUch
'        End Get
'    End Property
'    Sub IzmPodkl(ByVal iStrpodkl As String)
'        OperBD.IzmPodklDsUpr(taUch, Nothing, iStrpodkl)

'    End Sub
'    Property Shirina As Double

'        Get
'            Try
'                Return wRowOuch.Shirina
'            Catch ex As Exception
'                clsPrf.clsUchPrf.DefSirinaProfil(wUnom)
'            End Try


'        End Get
'        Set(ByVal iShirina As Double)
'            wRowOuch.Shirina = iShirina
'        End Set
'    End Property
'    Sub Delete()
'        wRowOuch.Delete()
'        '    wDsupr.AcceptChanges()
'    End Sub
'    Sub update()
'        taUch.Update(wDsupr.uchastkiN)

'    End Sub
'End Class
