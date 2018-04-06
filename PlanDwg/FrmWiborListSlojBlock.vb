Public Class FrmWiborListSlojBlock
    Const NameZapisiSohrWib As String = "SlojGraniz"
    Const NameListTemplateDef As String = "891х3000"
    Const NameSlojDef As String = "ТИЗ_Границы листов"
    Const NameBlockDef As String = "UgESP_Рамка_v1.3"
    Const NameBlockAttribDef As String = "-НАИМЕНОВАНИЕ_3"

    Private wSpsloj, wSpList, wSpBlock, wSpAtrrib As List(Of String)

    Private wDefAttrib, wDefTextString As String
    Private wSlowarDwg As BazDwg.dwgSlowar
    ReadOnly Property Sloj() As String

        Get
            Try
                Return ComboBoxSloj.SelectedItem
            Catch ex As Exception
                Return NameSlojDef
            End Try

        End Get
    End Property
    ReadOnly Property List() As String
        Get
            Try
                Return ComboBoxList.SelectedItem
            Catch ex As Exception
                Return NameListTemplateDef
            End Try

        End Get
    End Property
    ReadOnly Property Block() As String
        Get
            Try
                Return ComboBoxBlock.SelectedItem
            Catch ex As Exception
                Return NameBlockDef
            End Try

        End Get
    End Property
    ReadOnly Property AttributBlock() As String
        Get
            Try
                Return ComboBoxAttribut.SelectedItem
            Catch ex As Exception
                Return NameBlockAttribDef
            End Try

        End Get
    End Property
    ReadOnly Property TextStringAttribut() As String
        Get
            Return wDefTextString
        End Get
    End Property
    ReadOnly Property ScaleList() As Double
        Get
            Select Case ComboBoxMaschnab.SelectedIndex
                Case 0
                    Return 2.0
                Case 1
                    Return 1.0
                Case Else
                    Return 0.5

            End Select

        End Get
    End Property
    Private Sub FrmWiborListSlojBlock_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        wSlowarDwg = New BazDwg.dwgSlowar(Me.Name)
        wSpsloj = BazDwg.Kommand.SpisokLayerNames
        wSpsloj.Sort()

        wSpList = BazDwg.clsList.SpisokLayoutImen
        wSpList.Sort()

        wSpBlock = BazDwg.MakeEntities.WseBlock
        wSpBlock.Sort()
        ComboBoxSloj.DataSource = wSpsloj
        ComboBoxList.DataSource = wSpList
        ComboBoxBlock.DataSource = wSpBlock
        Dim lMasStr() As String = wSlowarDwg.ZapisIzSlovarStr(NameZapisiSohrWib)

        If lMasStr IsNot Nothing Then
            Dim lcount As Integer = lMasStr.Length
            If lcount > 0 Then ComboBoxSloj.SelectedItem = lMasStr(0)
            If lcount > 1 Then ComboBoxList.SelectedItem = lMasStr(1)
            If lcount > 2 Then
                ComboBoxBlock.SelectedItem = lMasStr(2)
                wSpAtrrib = BazDwg.MakeEntities.WseAttributBlock(ComboBoxBlock.SelectedItem)
                ComboBoxAttribut.DataSource = wSpAtrrib
                If lcount > 3 Then
                    wDefAttrib = lMasStr(3)
                    ComboBoxAttribut.SelectedItem = wDefAttrib
                    wDefTextString = BazDwg.MakeEntities.TextStringAttributBlockLista(lMasStr(1), lMasStr(2), wDefAttrib)
                End If

            End If
            ComboBoxMaschnab.SelectedIndex = 2
        End If
    End Sub

    Private Sub ButtonОК_Click(sender As System.Object, e As System.EventArgs) Handles ButtonОК.Click
        Dim lmasstr(3) As String
        lmasstr(0) = CStr(ComboBoxSloj.SelectedItem)
        lmasstr(1) = CStr(ComboBoxList.SelectedItem)
        lmasstr(2) = CStr(ComboBoxBlock.SelectedItem)
        lmasstr(3) = CStr(ComboBoxAttribut.SelectedItem)
        wSlowarDwg.ZapisW_SlowarStr(NameZapisiSohrWib, lmasstr)
    End Sub

    Private Sub ComboBoxBlock_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBoxBlock.SelectedIndexChanged
        wSpAtrrib = BazDwg.MakeEntities.WseAttributBlock(ComboBoxBlock.SelectedItem)
        ComboBoxAttribut.DataSource = wSpAtrrib
        ComboBoxAttribut.SelectedItem = wDefAttrib
        wDefTextString = BazDwg.MakeEntities.TextStringAttributBlockLista(ComboBoxList.SelectedItem, ComboBoxBlock.SelectedItem, wDefAttrib)
    End Sub
End Class