Option Explicit On
Option Strict Off
Imports clsPrf
Imports modRasstOp
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports OperBD

'Обеспечивает связь участка профиля с  Exel файлом
Public Class Sw_UchPrfExel
    Inherits clsSwExel
    Private RasstNaUch As modRasstOp.wlUch
    'Private wZon As New List(Of clsZon)
    'Private wSrZon As New ComparatorZon
    'Sub Dob(ByVal izon As clsZon)
    '    Dim index As Integer = wZon.BinarySearch(izon, wSrZon)
    '    If index < 0 Then
    '        index = index Xor -1
    '        wZon.Insert(index, izon)
    '    End If

    'End Sub
#Region "DannElemRastUch"
    Private Sub LeseDannElemRasst()
        RasstNaUch.SetElemRasstUch(LeseDann(sTprovod, DannElemRasstUch.MaxParamProvoda + 1), LeseDann(sTopor, DannElemRasstUch.MaxParamOpor + 1), _
                                   LeseDann(sTGirlajnd, DannElemRasstUch.PolajGirland.Razm + 1))
    End Sub
    Private Sub SreibDannElemRasst()
        SreibDann(sTprovod, DannElemRasstUch.MaxParamProvoda + 1, RasstNaUch.GetProvodUch)
        SreibDann(sTopor, DannElemRasstUch.MaxParamOpor + 1, RasstNaUch.GetOporUch)
        SreibDann(sTGirlajnd, DannElemRasstUch.PolajGirland.Razm + 1, RasstNaUch.GetGirlajndUch)
    End Sub
#End Region

#Region "чтение из Exel"
    Private Function IzExcelPiket(ByVal Ir As Integer, IcollStrok As Collection) As Boolean
        Dim MasStr() As String
        MasStr = ListMasStr(Ir, 12)
        If String.IsNullOrEmpty(MasStr(1)) Then
            Return False
        Else
            IcollStrok.Add(MasStr)
        End If
        'Dim objPik As New clsPiket(MasStr, Uch)
        'Uch.Dob(objPik)
        Return True
    End Function
    'Private Function IzExcelPikUgod(ByVal Ir As Integer) As Boolean
    '    Dim MasStr() As String
    '    MasStr = ListMasStr(Ir, 2)
    '    If String.IsNullOrEmpty(MasStr(0)) Then
    '        Return False
    '    End If
    '    Dim objUgod As New clsPrf.clsPikUgod(MasStr)
    '    Uch.Dob(objUgod)
    '    Return True
    'End Function
    Private Function LeseOpor(ByVal I As Integer) As modRasstOp.wlOpRasst
        Dim NumName As String
        Dim mas() As String
        mas = ListMasStr(I, 9)
        NumName = mas(0)
        '     If I = 10 Then MsgBox(I & "    " & NumName)
        If String.IsNullOrEmpty(NumName) Then
            Return Nothing
        Else
            Dim elDataRow As dsRasst.rastOpNRow = RasstUchWL.DsRasst.rastOpN.NewrastOpNRow
            wlOp.MasStr_DataRow(mas, elDataRow)
            elDataRow.UIdUch = RasstUchWL.UidUch
            RasstNaUch.DsRasst.rastOpN.AddrastOpNRow(elDataRow)
            Dim lop As wlOpRasst = New modRasstOp.wlOpRasst(elDataRow, RasstUchWL)
            If lop.DannOpor.Dann IsNot Nothing Then
                Return lop
            Else
                Return Nothing
            End If

        End If
    End Function
    Private Function leseMechUsl(ByVal I As Integer) As Boolean
        Dim MasStr() As String = ListMasStr(I, 11)
        If MasStr(0) = "" Then Return False
        Dim lPiketaj As Double = PreobrStr(MasStr(0), 0.0)
        'Dim tpik As clsPiket = Uch.Piket(lPiketaj)
        'If Not tpik Is Nothing Then
        Dim lrw As OperBD.dsRasst.MechUslRow = RasstNaUch.DsRasst.MechUsl.NewMechUslRow
        DannZonMechusl.MasStr_DataRow(MasStr, lrw)
        lrw.UidUch = RasstUchWL.UidUch
        lrw.UIndtaj = Guid.NewGuid
        RasstNaUch.DsRasst.MechUsl.AddMechUslRow(lrw)
        Dim zMechUsl As New modRasstOp.DannZonMechusl(lrw, RasstUchWL)
        ' zMechUsl.Piket = tpik
        RasstNaUch.Dob(zMechUsl)

        'End If
        Return True
    End Function
    Sub IzExcelRasstanowku()
        Dim Iwl As Integer
        LeseDannElemRasst()
        Dim op As modRasstOp.wlOpRasst
        Ust(sParamUch)
        RasstNaUch.SozdatParam(ListMasStr(4, 12))
        'If String.IsNullOrEmpty(RasstNaUch.DefParam.NameTipOporA) Then
        '    RasstNaUch.DefParam.NameTipOporA = RasstNaUch.DannElemRasstUch.TipDefAnkOp

        'End If
        If Uch.MaxNumPiket < 2 Then Return
        Iwl = 4
        Ust(sMechUsl)
        Do Until Iwl > 100


            If Not leseMechUsl(Iwl) Then Exit Do

            Iwl += 1
        Loop

        Iwl = 4
        Ust(srastOp)
        Do Until Iwl > 1100


            '      If Iwl >= 9 Then MsgBox(Iwl & "    ")
            op = LeseOpor(Iwl)
            '    If Iwl >= 9 Then MsgBox(Iwl & " N " & op.NumName)
            If op Is Nothing Then
                Exit Do

            End If
            '     If Iwl >= 9 Then MsgBox(Iwl & " S " & op.NumName)
            RasstNaUch.DobOp(op)
            '    If Iwl >= 9 Then MsgBox(Iwl & " К " & op.NumName)
            Iwl += 1

        Loop
        RasstNaUch.DsRasst.AcceptChanges() 'для единообразия с профилем, при чтение из Excel ни о какой связи с БД речи не идет, но может затем и стоит использовать этот признак.  
    End Sub

    Public Sub IzExelUzastok()
        Dim I As Integer
        Dim lCollPiket, lcollKlimat, lcollUgod As New Collection
        Uch.NameUch = NameUch
        I = 4
        If Not Ust(sProfil) Then Exit Sub
        Do While IzExcelPiket(I, lCollPiket)
            I += 1
        Loop
        If I < 5 Then
            MsgBox("Задано мало пикетных точек = " & I)
            Return
        End If

        If Ust(sKlimat) Then

            For I = 4 To 150

                Dim MasStr() As String = ListMasStr(I, 10)

                '  frmSoob.TextBox1.AppendText("Piket K" & MasStr(0) & vbCrLf)
                If String.IsNullOrEmpty(MasStr(0)) Then
                    Exit For
                Else
                    lcollKlimat.Add(MasStr)
                End If

            Next

        End If
        '  frmSoob.TextBox1.AppendText("Klimat " & vbCrLf)
        If Ust(sPiketUgod) Then
            For I = 4 To 30000
                Dim MasStr() As String = ListMasStr(I, 2)

                If String.IsNullOrEmpty(MasStr(0)) Then
                    Exit For
                Else
                    lcollUgod.Add(MasStr)
                End If

            Next
        End If
        Uch.SetPoStrPred(lCollPiket, lcollKlimat, lcollUgod)
        ' frmSoob.TextBox1.AppendText("пикетаж угодий " & vbCrLf)

    End Sub
    Public Sub IzExcel()
        IzExelUzastok()

        IzExcelRasstanowku()
    End Sub
#End Region
#Region "участок  в Exel"
    Private Sub DobKlimExel()
        SreibDann(sKlimat, 10, Uch.GetStrPredKlim())
    End Sub
    Private Sub DobPikUgod()
        SreibDann(sPiketUgod, 2, Uch.GetStrPredUgod())
    End Sub
    Private Sub DobPiket()
        SreibDann(sProfil, 12, Uch.GetStrPredPik())
    End Sub

    Private Sub RasstanowkuWExcel()
        Dim Iwl As Integer
        'Dim op As modRasstOp.wlOpTrass
        Ust(sParamUch)
        ListMasStr(4, 12) = RasstNaUch.DefParam.GetStrPred()




        Iwl = 4
        Ust(srastOp)
        For Each Opis As String() In RasstNaUch.GetStrPred
            ListMasStr(Iwl, 8) = Opis
            Iwl += 1
        Next

        Iwl = 4
        Ust(sMechUsl)
        For Each Opis As String() In RasstNaUch.GetStrPredMechUsl
            ListMasStr(Iwl, 11) = Opis
            Iwl += 1
        Next
    End Sub
    Sub UchastokW_Exel()
        NameUch = Uch.NameUch
        DobPiket()
        DobKlimExel()
        DobPikUgod()
        RasstanowkuWExcel()
        SreibDannElemRasst()
        ' Save()
    End Sub
#End Region

    ReadOnly Property RasstUchWL() As modRasstOp.wlUch
        Get
            Return RasstNaUch
        End Get
    End Property
    ReadOnly Property Uch() As clsUchPrf
        Get
            Return RasstNaUch
        End Get
    End Property
    Public Sub New(ByVal PutKFile As String, ByVal iRasstUch As wlUch, ByVal iNameWl As String, ByVal iUnom As Integer) ' для записи в выбраный  файл 
        MyBase.New(New Excel.Application)
        NameFile = PutKFile
        RasstNaUch = iRasstUch
        NameLin = iNameWl
        Unom = iUnom
    End Sub
    Public Sub New(ByVal iBook As Excel.Workbook, ByVal iRasstUch As wlUch, ByVal iNameWl As String, ByVal iUnom As Integer) ' для записи в файл созданый по шаблону
        MyBase.New(iBook)
        RasstNaUch = iRasstUch
        NameLin = iNameWl
        Unom = iUnom
    End Sub
    Public Sub New(ByVal iAppExcel As Excel.Application)
        MyBase.New(iAppExcel)
        RasstNaUch = New wlUch(Guid.Empty)
    End Sub
    Public Sub New(ByVal iAppExcel As Excel.Application, ByVal Uch As clsPrf.clsUchPrf) ' для чтения только расстановки
        MyBase.New(iAppExcel)
        RasstNaUch = New wlUch(Uch)
    End Sub
End Class
