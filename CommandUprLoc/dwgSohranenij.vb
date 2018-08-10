Imports modRasstOp
Imports ProfilBaseDwg

Public Class dwgSohranenij
    Private wSpisokRasst As New List(Of wlRasst)
    Private Ind As Integer
    Private wNameIskDwg As String
    Function FindDwg(ByVal iRasst As wlRasst) As Boolean
        Return CType(iRasst.Trassa, DwgTr).NameDwg.Equals(wNameIskDwg)
    End Function
    'Friend Shared Sub ChitatTrRasstIzSlw(ByVal iRasst As wlRasst)
    '    Dim lnamelin As String = ""
    '    Dim lunom As Integer
    '    LeseSreib.clsLeseSrejb.IzwlechDannOLini("Sohr", lnamelin, lunom)
    '    iRasst = New modRasstOp.wlRasst(New dwgTrList(lnamelin, lunom))
    '    Dim dnDwg As New LeseSreib.clsLeseSrejb("Sohr", iRasst)
    '    If dnDwg.Izwlech() Then

    '    Else
    '        iRasst = Nothing

    '    End If

    'End Sub
    'Shared Sub SohranitTrRasst(ByVal iRasst As wlRasst)
    '    Dim dnDwg As New LeseSreib.clsLeseSrejb("Sohr", iRasst)
    '    dnDwg.Save()
    'End Sub

    'ReadOnly Property gRasst As modRasstOp.wlRasst
    '    Get

    '        Return wRasst
    '    End Get
    'End Property
    'ReadOnly Property gTrassa As dwgTrList
    '    Get

    '        Return wTrassa
    '    End Get
    'End Property
    'ReadOnly Property NameDwg() As String
    '    Get
    '        Return wTrassa.NameDwg
    '    End Get
    'End Property
    Sub Dobawit()
        Dim lrasst As wlRasst
        lrasst = clsKommandBase.gRasst
        wNameIskDwg = CType(clsKommandBase.gTrassa, DwgTr).NameDwg
        Dim lind = wSpisokRasst.FindIndex(AddressOf FindDwg)
        If lind >= 0 Then
            wSpisokRasst(lind) = lrasst
        Else
            wSpisokRasst.Add(lrasst)
        End If
        '    SohranitTrRasst(lrasst)

    End Sub
    Function Izwlech(ByVal iNameDwg As String) As wlRasst
        wNameIskDwg = iNameDwg
        Dim lind = wSpisokRasst.FindIndex(AddressOf FindDwg)
        If lind >= 0 Then
            Dim lrasst As wlRasst = wSpisokRasst(lind)


            '    ChitatTrRasstIzSlw(lrasst)

            Return lrasst
        Else
            Return Nothing
        End If
    End Function
    Sub udalit(ByVal iNameDwg As String)
        wNameIskDwg = iNameDwg
        Dim lind = wSpisokRasst.FindIndex(AddressOf FindDwg)
        If lind >= 0 Then


            wSpisokRasst.RemoveAt(lind)




        End If
    End Sub
    Public Sub New()
        ' MsgBox(Me.ToString & " создан  ")
    End Sub

    Protected Overrides Sub Finalize()
        '  MsgBox(Me.ToString & " удален  ")
        MyBase.Finalize()

    End Sub
End Class
