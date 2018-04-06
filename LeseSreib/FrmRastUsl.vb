''' <summary>
''' В словаре сохраняються параметры заданого режима, для реальных расчетов важен приведеный центр 
''' </summary>
''' <remarks></remarks>
Public Class FrmRastUsl
    Private wSlowarSDann As clsLeseSreibUsl
    Private wRasst As modRasstOp.wlRasst
    Property Rasst As modRasstOp.wlRasst

        Get
            Return wRasst
        End Get
        Set(ByVal value As modRasstOp.wlRasst)
            wRasst = value
            wSlowarSDann = New clsLeseSreibUsl(wRasst)  '
            Dim spImen As New List(Of String)
            Dim zap As Collection = wSlowarSDann.Slowar.WseZapisIsSlowar(spImen)
            For Each lstr As String In spImen
                Dim mas() As String = CType(zap.Item(lstr), List(Of String)).ToArray
                Dim lusl = New UslRaschetaCls()
                lusl.StrPred = mas
                lusl.NameUsl = lstr
                UslRaschetaClsBindingSource.Add(lusl)
            Next


        End Set
    End Property
    Private Sub DataGridViewRastUsl_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewRastUsl.CellContentClick

    End Sub

    Private Sub FrmRastUsl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        UslRaschetaClsBindingSource.EndEdit()
        Dim lsysKomand As New BazDwg.SystemKommand
        lsysKomand.Lock()
        For Each el As UslRaschetaCls In UslRaschetaClsBindingSource
            ' wSlowarSDann.Slowar.ZapisW_SlowarStr(el.NameUsl, el.StrPred)
            wSlowarSDann.SetZapis(el.NameUsl, el.StrPred)
        Next
        lsysKomand.Dispose()
    End Sub
End Class