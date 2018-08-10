#If ARX_APP Then
Imports Autodesk.AutoCAD.DatabaseServices
#Else
Imports Teigha.DatabaseServices
#End If



Imports BazDwg
Imports clsPrf.Slujba

Module Aotlad
    Public Const NameSlowar As String = "PredOtkl"
    Public Const NavtZapProwod As String = "prowod"
    Public Const NavtZapTros As String = "tros"
    Function PreobrList_MassivTypedValue(iSp As List(Of clsPrf.ParaDoubleString)) As TypedValue()
        Dim lmassTypedValue() As TypedValue
        Dim irazm = 2 * iSp.Count - 1
        ReDim lmassTypedValue(irazm)
        Dim i = 0
        For Each el As ParaDoubleString In iSp
            lmassTypedValue(i) = New TypedValue(DxfCode.Text, el.Name)
            i += 1
            lmassTypedValue(i) = New TypedValue(DxfCode.Real, el.Value)
            i += 1
        Next
        Return lmassTypedValue

    End Function
    Function PreobrMassivTypedValue_List(MassivTyped() As TypedValue) As List(Of ParaDoubleString)
        Dim lList As New List(Of ParaDoubleString)
        If MassivTyped Is Nothing Then Return lList
        For i As Integer = 0 To MassivTyped.Length - 1 Step 2
            lList.Add(New ParaDoubleString(CStr(MassivTyped(i).Value), CDbl(MassivTyped(i + 1).Value)))
        Next
        Return lList
    End Function
    Sub ZapisW_Slowar(ISp As List(Of ParaDoubleString), nameSl As String, nameZap As String)
        Dim lSlowar As New dwgSlowar(nameSl)
        lSlowar.ZapisW_Slowar(nameZap, PreobrList_MassivTypedValue(ISp))

    End Sub
    Function LeseIzSlowara(nameSl As String, namezap As String) As List(Of ParaDoubleString)
        Dim lSlowar As New dwgSlowar(nameSl)
        Return PreobrMassivTypedValue_List(lSlowar.ZapisIsSlowar(namezap))
    End Function
    Sub ZapisWSlowatInT(Ipar As Integer, nameSl As String, namezap As String)
        Dim lSlowar As New dwgSlowar(nameSl)
        Dim lMasTypedValue(0) As TypedValue
        lMasTypedValue(0) = New TypedValue(DxfCode.Int16, Ipar)
        lSlowar.ZapisW_Slowar(namezap, lMasTypedValue)
    End Sub
    Function LeseizSlowarInt(nameSl As String, NameZap As String) As Integer
        Dim lslowar As New dwgSlowar(nameSl)
        Dim lmasTypedValue() = lslowar.ZapisIsSlowar(NameZap)
        If lmasTypedValue Is Nothing Then Return CInt(lmasTypedValue(0).Value)
        Return CInt(lmasTypedValue(0).Value)
    End Function


End Module
