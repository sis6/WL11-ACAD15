Public Enum ParamObrazDetal
    Maschtab = 0
    Sloi = 1
    List = 2
    Block = 3
    AttribBlock = 4
    MaxNumParam = 4
End Enum

Public Class FrmOformList
    Private wNameZapisiSohranenij As String = "NameZapisOform"
    'Const NameListTemplateDef As String = "891х3000"
    'Const NameSlojDef As String = "ТИЗ_Границы листов"
    'Const NameBlockDef As String = "UgESP_Рамка_v1.3"
    'Const NameBlockAttribDef As String = "-НАИМЕНОВАНИЕ_3"

    Private wSpAtrrib As List(Of String)

    Private wDefAttrib, wDefTextString As String
    '  
    Property NameZapisSohranenij As String

        Get
            Return wNameZapisiSohranenij
        End Get
        Set(value As String)
            wNameZapisiSohranenij = value
        End Set
    End Property
    ' Эти свойства наверное не нужны
    'ReadOnly Property Sloj() As String

    '    Get
    '        Try
    '            Return ComboBoxSloj.SelectedItem
    '        Catch ex As Exception
    '            Return NameSlojDef
    '        End Try

    '    End Get
    'End Property
    'ReadOnly Property List() As String
    '    Get
    '        Try
    '            Return ComboBoxList.SelectedItem
    '        Catch ex As Exception
    '            Return NameListTemplateDef
    '        End Try

    '    End Get
    'End Property
    'ReadOnly Property Block() As String
    '    Get
    '        Try
    '            Return ComboBoxBlock.SelectedItem
    '        Catch ex As Exception
    '            Return NameBlockDef
    '        End Try

    '    End Get
    'End Property
    'ReadOnly Property AttributBlock() As String
    '    Get
    '        Try
    '            Return ComboBoxAttribut.SelectedItem
    '        Catch ex As Exception
    '            Return NameBlockAttribDef
    '        End Try

    '    End Get
    'End Property
    'ReadOnly Property TextStringAttribut() As String
    '    Get
    '        Return wDefTextString
    '    End Get
    'End Property

    Private Sub FrmWiborListSlojBlock_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load





        Dim wParam As New ParamOform(wNameZapisiSohranenij)
        With wParam
            ComboBoxSloj.DataSource = .GetSpisok(ParamObrazDetal.Sloi)
            ComboBoxList.DataSource = .GetSpisok(ParamObrazDetal.List)
            ComboBoxBlock.DataSource = .GetSpisok(ParamObrazDetal.Block)

            ComboBoxMashtabPlanDetO.SelectedItem = CStr(wParam.MaschtabPlanDet)
            ComboBoxSloj.SelectedItem = wParam.NameSloj
            ComboBoxList.SelectedItem = wParam.NameListTemplate
            ComboBoxBlock.SelectedItem = wParam.NameBlock

            ' wSpAtrrib = BazfunNet.CreateEntities.MakeEntities.WseAttributBlock(ComboBoxBlock.SelectedItem)
            ComboBoxAttribut.DataSource = wParam.GetSpisok(ParamObrazDetal.AttribBlock)
            ComboBoxAttribut.SelectedItem = wParam.NameAttribBlock
        End With


    End Sub

    Private Sub ButtonОК_Click(sender As System.Object, e As System.EventArgs) Handles ButtonОК.Click
        Dim lmasstr(ParamObrazDetal.MaxNumParam) As String
        lmasstr(ParamObrazDetal.Maschtab) = CStr(ComboBoxMashtabPlanDetO.SelectedItem)
        lmasstr(ParamObrazDetal.Sloi) = CStr(ComboBoxSloj.SelectedItem)
        lmasstr(ParamObrazDetal.List) = CStr(ComboBoxList.SelectedItem)
        lmasstr(ParamObrazDetal.Block) = CStr(ComboBoxBlock.SelectedItem)
        lmasstr(ParamObrazDetal.AttribBlock) = CStr(ComboBoxAttribut.SelectedItem)
        Dim lSlowarDwg As BazDwg.dwgSlowar
        lSlowarDwg = New BazDwg.dwgSlowar(LeseSreib.GlParam)
        lSlowarDwg.ZapisW_SlowarStr(wNameZapisiSohranenij, lmasstr)
    End Sub

    Private Sub ComboBoxBlock_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBoxBlock.SelectedIndexChanged
        wSpAtrrib = BazDwg.MakeEntities.WseAttributBlock(ComboBoxBlock.SelectedItem)
        ComboBoxAttribut.DataSource = wSpAtrrib
        ComboBoxAttribut.SelectedItem = wDefAttrib
        wDefTextString = BazDwg.MakeEntities.TextStringAttributBlockLista(ComboBoxList.SelectedItem, ComboBoxBlock.SelectedItem, wDefAttrib)
    End Sub
End Class
''' <summary>
''' Класс для чтения параметров оформления границ деталей
''' </summary>
''' <remarks></remarks>
Public Class ParamOform
    'Const NameListTemplateDef As String = "891х3000"
    'Const NameSlojDef As String = "ТИЗ_Границы листов"
    'Const NameBlockDef As String = "UgESP_Рамка_v1.3"
    'Const NameBlockAttribDef As String = "-НАИМЕНОВАНИЕ_3"

    Private wNameListTemplate As String                '       =               "891х3000"
    Private wNameSloj As String                       '   =      "ТИЗ_Границы листов"
    Private wNameBlock As String '= "UgESP_Рамка_v1.3"    
    Private wNameAttribBlock As String '= "-НАИМЕНОВАНИЕ_3"
    Private wTextAtribut As String
    Private wMaschtabPlanDet As Integer
    Private wSpsloj, wSpList, wSpBlock, wSpAtrrib As List(Of String)
    Function GetSpisok(IndSp As ParamObrazDetal) As List(Of String)
        Select Case IndSp
            Case ParamObrazDetal.Sloi
                Return wSpsloj
            Case ParamObrazDetal.List
                Return wSpList
            Case ParamObrazDetal.Block
                Return wSpBlock
            Case ParamObrazDetal.AttribBlock
                Return wSpAtrrib
            Case Else
                Return Nothing
        End Select
    End Function

    ReadOnly Property NameSloj() As String
        Get
            Return wNameSloj
        End Get
    End Property
    ReadOnly Property NameListTemplate() As String
        Get
            Return wNameListTemplate
        End Get
    End Property
    ReadOnly Property NameBlock() As String
        Get
            Return wNameBlock
        End Get
    End Property
    ReadOnly Property NameAttribBlock() As String
        Get
            Return wNameAttribBlock
        End Get
    End Property
    ReadOnly Property TextAtribut() As String
        Get
            Return wTextAtribut
        End Get
    End Property
    ReadOnly Property MaschtabPlanDet() As Integer
        Get
            Return wMaschtabPlanDet
        End Get
    End Property
    Sub New(iNameZapisiSohranenij As String)
        Dim lSlowarDwg = New BazDwg.dwgSlowar(LeseSreib.GlParam)
        Dim lMasStr() As String = lSlowarDwg.ZapisIzSlovarStr(iNameZapisiSohranenij)

        wSpsloj = BazDwg.Kommand.SpisokLayerNames
        wSpsloj.Sort()

        wSpList = BazDwg.clsList.SpisokLayoutImen
        wSpList.Sort()

        wSpBlock = BazDwg.MakeEntities.WseBlock
        wSpBlock.Sort()
        wMaschtabPlanDet = 1000
        wNameSloj = wSpsloj(0)
        wNameListTemplate = wSpList(0)
        wNameBlock = wSpBlock(0)
        If lMasStr IsNot Nothing Then
            Dim lcount As Integer = lMasStr.Length
            'masschtab
            If lcount > ParamObrazDetal.Maschtab Then
                Try
                    wMaschtabPlanDet = CInt(lMasStr(ParamObrazDetal.Maschtab))
                Catch ex As Exception
                    wMaschtabPlanDet = 1000
                End Try

            End If

            If lcount > ParamObrazDetal.Sloi Then
                If wSpsloj.Contains(lMasStr(ParamObrazDetal.Sloi)) Then
                    wNameSloj = lMasStr(ParamObrazDetal.Sloi) '   ComboBoxSloj.SelectedItem = 

                End If

                If lcount > ParamObrazDetal.List Then
                    If wSpList.Contains(lMasStr(ParamObrazDetal.List)) Then
                        wNameListTemplate = lMasStr(ParamObrazDetal.List) 'ComboBoxList.SelectedItem

                    End If
                End If

            End If

            If lcount > ParamObrazDetal.Block Then
                If wSpBlock.Contains(lMasStr(ParamObrazDetal.Block)) Then
                    wNameBlock = lMasStr(ParamObrazDetal.Block)   '          ComboBoxBlock.SelectedItem     
                    wSpAtrrib = BazDwg.MakeEntities.WseAttributBlock(wNameBlock)
                    wSpAtrrib = BazDwg.MakeEntities.WseAttributBlock(wNameBlock)

                End If
            End If

            If wSpAtrrib IsNot Nothing Then
                If lcount > ParamObrazDetal.AttribBlock Then
                    If wSpAtrrib.Contains(lMasStr(ParamObrazDetal.AttribBlock)) Then
                        wNameAttribBlock = lMasStr(ParamObrazDetal.AttribBlock)  '                          ComboBoxAttribut.SelectedItem = wDefAttrib
                        If String.IsNullOrEmpty(wNameListTemplate) OrElse String.IsNullOrEmpty(wNameBlock) Then Return
                        wTextAtribut = BazDwg.MakeEntities.TextStringAttributBlockLista(wNameListTemplate, wNameBlock, wNameAttribBlock)
                    End If

                End If
            End If


        End If

    End Sub

End Class