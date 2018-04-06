Option Strict On
Option Explicit On
Imports System.Windows.Forms

Public Class frmWwdGrList
    Public SpGr As dwgSpGranizList
    Public SpGrVid As dwgSpGranizVidEkran
    Dim wtrassa As DwgTr
    
    Property Trassa As DwgTr
        Set(value As DwgTr)
            wtrassa = value
        End Set
        Get
            Return wtrassa
        End Get

    End Property
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewListov.CellContentClick

    End Sub
    Private Sub zapolnit()
        For Each luch As clsPrf.clsUchPrf In wtrassa.Uchastki

            With luch                                      'CType(Rasst.objTr.Uchastki(1), clsPrf.clsUchPrf)

                Dim tpik As clsPrf.ClsPiket = .BegUch
                ' StrUch &= " " & tpik.RastOtnachala
                Dim tklim As clsPrf.clsZonKlimat = .BegKlimZon
                ListBoxUch.Items.Add(.NameUch & " | " & Format(tpik.RastOtnachala, "#.#"))
                Do Until tklim Is Nothing
                    ClsZonKlimatBindingSource.Add(tklim)
                    tklim = CType(tklim.Sled, clsPrf.clsZonKlimat)
                Loop
                Do Until tpik Is Nothing
                    If tpik.EstUgolPoworota Then
                        clsPiketBindingSource.Add(tpik)
                    End If
                    tpik = tpik.Sled
                Loop
            End With
        Next

        LabelWisPrfWidEkran.Text &= " " & wtrassa.objGeom.Podpis.ShirProf / wtrassa.objGeom.KoorOtm.Koeff()


    End Sub
    Private Sub ButtonOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOk.Click
        SpGr = Nothing
        SpGr = New dwgSpGranizList
        SpGrVid = Nothing
        SpGrVid = New dwgSpGranizVidEkran
        With ClsGranizBindingSource
            Dim I As Integer = 0
            If .Count > 0 Then
                .MoveFirst()
                Do
                    Dim tList As dwgGranizList = CType(.Current, dwgGranizList)
                    tList.RastotNach = wtrassa.UtochnitGraniz(tList.RastotNach)
                    SpGr.Dob(tList)
                    SpGrVid.Dob(tList.RastotNach)
                    .MoveNext()
                    I += 1
                Loop Until I >= .Count

            End If

        End With

        For Each rw As DataGridViewRow In DataGridViewVid.Rows
            Dim wD As Double = CDbl(rw.Cells(0).Value)
            wD = wtrassa.UtochnitGraniz(wD)
            SpGrVid.Dob(wD)
        Next

    End Sub

    Private Sub frmWwdGrList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '  Dim oneGr As dwgGranizList
        zapolnit()
        SpGr.Izwlech()
        SpGrVid.Izwlech()
        Dim ColLst As Collection
        ColLst = BazDwg.clsList.ListDwg()
        For Each wStr In SpGr.NameLists
            ColLst.Add(wStr)
        Next
        With Me.NameListDataGridViewTextBoxColumn.Items
            Dim str As String
            For Each str In ColLst
                If Not .Contains(str) Then
                    .Add(str)
                End If
            Next
        End With

        For Each oneGr As dwgGranizList In SpGr.SpGraniz
            ClsGranizBindingSource.Add(oneGr)
        Next
        If SpGrVid IsNot Nothing Then
            For Each r As Double In SpGrVid.Rast
                DataGridViewVid.Rows.Add(r)
            Next

        End If

    End Sub

   
End Class