Option Strict On
Option Explicit On

#If ARX_APP Then
Imports Autodesk.AutoCAD.DatabaseServices
#Else
Imports Teigha.DatabaseServices
#End If
Imports BazDwg
Public Class dwgGranizList
    Private Rast As Double
    Private Name As String

    Property RastotNach() As Double
        Get
            Return Rast
        End Get
        Set(ByVal value As Double)
            Rast = value
        End Set
    End Property
    Property NameList() As String
        Get
            Return Name
        End Get
        Set(ByVal value As String)
            Name = value
        End Set

    End Property
    Public Sub New(ByVal iRast As Double, ByVal iname As String)
        Rast = iRast
        Name = iname
    End Sub
    Public Sub New()

    End Sub
End Class
Public Class dwgSpGranizList
    Protected colGr As New Collection
    Const Graniz As String = "Graniz"
    ReadOnly Property Count() As Integer
        Get
            Return colGr.Count
        End Get
    End Property

    ReadOnly Property SpGraniz() As Collection
        Get
            Return colGr
        End Get
    End Property
    ReadOnly Property NameLists() As Collection
        Get
            Dim Wcol As New Collection, elGr As dwgGranizList
            For Each elGr In colGr
                Wcol.Add(elGr.NameList)
            Next
            Return Wcol
        End Get
    End Property
    Sub Save()
        Dim SlParam As New dwgSlowar(LeseSreib.GlParam)
        Dim lGraniz() As TypedValue
        Dim oneGr As dwgGranizList
        ReDim lGraniz(2 * colGr.Count - 1)

        Dim I = 0
        For Each oneGr In colGr
            lGraniz(I) = New TypedValue(CInt(DxfCode.Real), oneGr.RastotNach)
            I += 1
            lGraniz(I) = New TypedValue(CInt(DxfCode.Text), oneGr.NameList)
            I += 1
        Next
        'Dim Wsp(0) As TypedValue
        'Wsp(0) = New TypedValue(CInt(DxfCode.Real), 21)
        SlParam.ZapisW_Slowar(Graniz, lGraniz)
    End Sub
    Sub Izwlech()
        Dim SlParam As New dwgSlowar(LeseSreib.GlParam)
        Dim lGraniz() As TypedValue

        lGraniz = SlParam.ZapisIsSlowar(Graniz)
        Dim RazmParGr As Integer
        Try
            RazmParGr = UBound(lGraniz)
        Catch ex As Exception
            RazmParGr = -1
        End Try


        For I = 0 To RazmParGr Step 2
            colGr.Add(New dwgGranizList(CDbl(lGraniz(I).Value), CStr(lGraniz(I + 1).Value)))
        Next



    End Sub

    Sub Dob(ByVal gr As dwgGranizList)
        Dim elGr As dwgGranizList
        Dim I As Integer
        If gr.NameList = "" Then Return
        I = 1
        For Each elGr In colGr

            If elGr.NameList = gr.NameList Then
                If elGr.RastotNach < gr.RastotNach Or Math.Abs(elGr.RastotNach - gr.RastotNach) < 1 Then
                    colGr.Remove(I)
                Else
                    Exit Sub
                End If
            End If
            I += 1
        Next
        I = 1
        For Each elGr In colGr
            If elGr.RastotNach > gr.RastotNach Then
                colGr.Add(gr, , I)
                Exit Sub
            End If
            I += 1
        Next
        colGr.Add(gr)
    End Sub


    Public Sub New()

    End Sub
End Class
Public Class dwgSpGranizTr
    Inherits dwgSpGranizList
    Dim objTr As ProfilBaseDwg.DwgTr
    Overloads ReadOnly Property NameLists() As Collection
        Get
            Dim Wcol As New Collection, elGr As dwgGranizList
            For Each elGr In colGr
                If elGr.RastotNach < objTr.Dlina Then
                    Wcol.Add(elGr.NameList)
                Else
                    Wcol.Add(elGr.NameList)
                    Return Wcol
                End If

            Next
            Return Wcol
        End Get
    End Property
    Sub GranLista(ByVal NameList As String, ByRef Grb As Double, ByRef Gre As Double)
        Dim elGr As dwgGranizList
        Dim I As Integer = 0
        Grb = 0
        Gre = 0
        For Each elGr In colGr
            If elGr.RastotNach >= objTr.Dlina Then Exit Sub
            If elGr.NameList = NameList Then

                Grb = elGr.RastotNach
                I += 1
                Exit For
            End If

            I += 1
        Next
        If I > 0 Then
            If I < colGr.Count Then
                Gre = CType(colGr.Item(I + 1), dwgGranizList).RastotNach
            Else
                Gre = objTr.Dlina
            End If
        End If

    End Sub
    Sub New(ByVal wTrassa As ProfilBaseDwg.DwgTr)
        objTr = wTrassa
    End Sub
End Class
Public Class dwgSpGranizVidEkran
    Const GrEkranow As String = "GranEkranow"
    Const MinShirEkran As Double = 10
    Private CollRast As New Collection
    Sub Dob(ByVal irast As Double)
        Dim I As Integer, tRast As Double
        I = 1
        For Each tRast In CollRast
            If Math.Abs(tRast - irast) < MinShirEkran Then
                Exit Sub
            End If
            If irast < tRast Then
                CollRast.Add(irast, , I)
                Exit Sub
            End If
            I += 1
        Next
        CollRast.Add(irast)
    End Sub
    ReadOnly Property Rast() As Collection
        Get
            Return CollRast
        End Get
    End Property
    Public Sub Save()
        Dim SlParam As New dwgSlowar(LeseSreib.GlParam)
        Dim lGraniz() As TypedValue

        ReDim lGraniz(CollRast.Count - 1)

        Dim I As Integer
        For I = 0 To CollRast.Count - 1
            lGraniz(I) = New TypedValue(CInt(DxfCode.Real), CollRast.Item(I + 1))

        Next

        SlParam.ZapisW_Slowar(GrEkranow, lGraniz)
    End Sub
    Sub Izwlech()
        Dim SlParam As New dwgSlowar(LeseSreib.GlParam)
        Dim lGraniz() As TypedValue
        Dim RazmParGr As Integer
        lGraniz = SlParam.ZapisIsSlowar(GrEkranow)


        Try

            RazmParGr = UBound(lGraniz)
        Catch ex As Exception
            RazmParGr = -1
        End Try

        'MsgBox(RazmParGr)
        For I = 0 To RazmParGr
            Dob(CDbl(lGraniz(I).Value))
        Next
    End Sub
    Function EkranDiapazon(ByVal Rb As Double, ByVal Re As Double) As Collection
        Dim colWozwr As New Collection
        colWozwr.Add(Rb)
        For Each wrr As Double In CollRast
            If wrr > (Rb + MinShirEkran) And wrr < (Re - MinShirEkran) Then
                colWozwr.Add(wrr)


            End If
            If wrr > Re Then Exit For
        Next
        colWozwr.Add(Re)
        Return colWozwr
    End Function

    Public Sub New()

    End Sub
End Class
