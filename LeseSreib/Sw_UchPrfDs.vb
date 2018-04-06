Option Explicit On
Option Strict On
'Imports Microsoft.Office.Interop
Imports clsPrf
Imports modRasstOp
Imports OperBD
Imports System.Data
Public MustInherit Class Sw_UchPrfDs
    Protected wRasstNaUch As modRasstOp.wlUch
    Protected ReadOnly Property dsProfil As DsProfil
        Get
            Return wRasstNaUch.dsProfil
        End Get
    End Property
    Protected ReadOnly Property dsRasst As dsRasst
        Get
            Return wRasstNaUch.DsRasst
        End Get
    End Property
    Protected ReadOnly Property ElemRasstUch As ElemRasstUch
        Get
            Return wRasstNaUch.DannElemRasstUch.DataSet
        End Get
    End Property
    ReadOnly Property UchPrf() As clsPrf.clsUchPrf
        Get
            Return wRasstNaUch
        End Get
    End Property
End Class
''' <summary>
''' 'формируем из  DataSet профиля и расстановки модель профиля и расстановки
''' </summary>
''' <remarks></remarks>
Public Class Sw_IzDs_Rasst
    Inherits Sw_UchPrfDs

#Region "Чтение DataSet"
    'Protected Sub IzDsUzastok(ByVal iNameUch As String)
    '    wRasstNaUch.NameUch = iNameUch
    '    wRasstNaUch.SozdatPoDataSet()
    'End Sub
    Protected Sub IzDsRasstanowku()

        If wRasstNaUch.MaxNumPiket < 1 Then Return

        wRasstNaUch.UstParam()
        ' Условия расстановки
        For Each Murw As dsRasst.MechUslRow In dsRasst.MechUsl.Select("", "Piketaj")
            wRasstNaUch.Dob(New modRasstOp.DannZonMechusl(Murw, wRasstNaUch))
        Next
        'Опоры
        Dim op As modRasstOp.wlOpRasst
        For Each Oprw As dsRasst.rastOpNRow In dsRasst.rastOpN.Select("", "Piketaj")
            If Oprw.RowState = DataRowState.Deleted Then MsgBox(Me.ToString & "опоры " & Oprw.RowState)

            op = New wlOpRasst(Oprw, wRasstNaUch)
            If Not op Is Nothing Then
                wRasstNaUch.DobOp(op)
            End If
        Next

    End Sub
#End Region
    Public Sub New()

    End Sub
    ''' <summary>
    ''' формируем по DataSetам данным  участок трасы ВЛ
    ''' </summary>
    ''' <param name="dsPrfA"> объедененные данные профиля </param>
    ''' <param name="idsRasst"> расстановка </param>
    ''' <param name="dsElem"> опоры провода гирлянды  участка </param>
    ''' <param name="iNameUch"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal dsPrfA As DsProfil, ByVal idsRasst As dsRasst, ByVal dsElem As ElemRasstUch, ByVal iNameUch As String)
        wRasstNaUch = New wlUch(dsPrfA, idsRasst, dsElem)
        '   IzDsUzastok(iNameUch)
        wRasstNaUch.NameUch = iNameUch

    End Sub
    ReadOnly Property RasstNaUch() As modRasstOp.wlUch
        Get
            Return wRasstNaUch
        End Get
    End Property

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
Public Class Sw_IzRasst_DS 'Запись из участка профиля dataSet
    Inherits Sw_UchPrfDs
    '   Private wUidUch As Guid
    Private Sub PiketN(ielPik As DsProfil.ProfilNRow, ielPikA As DsProfil.ProfilARow)
        With ielPikA
            ielPik.Piketaj = .Piketaj
            ielPik.Otmetka = .Otmetka
            If .IsNameTchkNull Then
                ielPik.SetNameTchkNull()
            Else
                ielPik.NameTchk = .NameTchk
            End If
            If .IsOtmetkaPrNull Then
                ielPik.SetOtmetkaPrNull()
            Else
                ielPik.OtmetkaPr = .OtmetkaPr
            End If
            If .IsOtmetkaLwNull Then
                ielPik.SetOtmetkaLwNull()
            Else
                ielPik.OtmetkaLw = .OtmetkaLw
            End If

        End With
    End Sub
    Private Sub OsobN(ielPer As DsProfil.OsobRow, ielPikA As DsProfil.ProfilARow)
        With ielPikA
            ielPer.IdTipSoor = .IdTipSoor
            If Not .IsParam1Null Then ielPer.Param1 = .Param1
            If Not .IsParam2Null Then ielPer.Param2 = .Param2
            If Not .IsParam3Null Then ielPer.Param3 = .Param3
            If Not .IsParam4Null Then ielPer.Param4 = .Param4
            If Not .IsOpisNull Then ielPer.Opis = .Opis
            If Not .IsHorizontDanNull Then ielPer.HorizontDan = .HorizontDan
        End With
    End Sub
    Private Sub DobPiket()
        'Добавление пикетной точки в  БД
        Dim lElPiket As ClsPiket = UchPrf.BegUch
        Dim i As Integer = 0
        For Each el As OperBD.DsProfil.ProfilNRow In wRasstNaUch.dsProfil.ProfilN
            'Так как profilA
            Dim ela As OperBD.DsProfil.ProfilARow = wRasstNaUch.dsProfil.ProfilA.FindByUIdTchk(el.UIdTchk)
            If ela Is Nothing OrElse ela.RowState = DataRowState.Deleted Then
                el.Delete()
            End If
        Next
        'можно иначе но тогда цикл надо проводить не по пикетам а по Rows profilA
        Do Until lElPiket Is Nothing   'цикл по пикетам участка

            Dim lUidTchk As Guid = lElPiket.DataRowPiket.UIdTchk
            Dim elProfilNRow As DsProfil.ProfilNRow = dsProfil.ProfilN.FindByUIdTchk(lUidTchk)


            Select Case (lElPiket.DataRowPiket.RowState)

                Case DataRowState.Deleted 'если удалено
                    If elProfilNRow IsNot Nothing Then elProfilNRow.Delete()
                    'сюда никогда не попадет
                Case DataRowState.Modified

                    PiketN(elProfilNRow, lElPiket.DataRowPiket)


                    'угол поворота
                    Dim elUg As DsProfil.UgolPoworotaRow = dsProfil.UgolPoworota.FindByUIdTchk(lUidTchk)
                    If lElPiket.EstUgolPoworota Then

                        If elUg IsNot Nothing Then
                            elUg.UgolPoworot = lElPiket.DataRowPiket.UgolPoworot
                        Else
                            elUg = dsProfil.UgolPoworota.AddUgolPoworotaRow(elProfilNRow, lElPiket.DataRowPiket.UgolPoworot)
                        End If
                    Else
                        If elUg IsNot Nothing Then elUg.Delete()
                    End If
                    'пересечение
                    Dim elPer As DsProfil.OsobRow = dsProfil.Osob.FindByUIdTchk(lUidTchk)
                    If lElPiket.EstPeresech Then

                        If elPer IsNot Nothing Then


                            OsobN(elPer, lElPiket.DataRowPiket)

                        Else
                            elPer = dsProfil.Osob.NewOsobRow
                            With lElPiket.DataRowPiket
                                elPer.UIdTchk = .UIdTchk
                                OsobN(elPer, lElPiket.DataRowPiket)
                            End With
                            dsProfil.Osob.AddOsobRow(elPer)
                        End If
                    Else
                        If elPer IsNot Nothing Then elPer.Delete()
                    End If
                Case DataRowState.Added
                    elProfilNRow = dsProfil.ProfilN.NewProfilNRow

                    With lElPiket.DataRowPiket
                        elProfilNRow.UIdTchk = .UIdTchk
                        elProfilNRow.UIdUch = .UIdUch
                        PiketN(elProfilNRow, lElPiket.DataRowPiket)

                    End With
                    dsProfil.ProfilN.AddProfilNRow(elProfilNRow)
                    If lElPiket.EstUgolPoworota Then dsProfil.UgolPoworota.AddUgolPoworotaRow(elProfilNRow, lElPiket.DataRowPiket.UgolPoworot)
                    If lElPiket.EstPeresech Then
                        Dim elper As DsProfil.OsobRow = dsProfil.Osob.NewOsobRow
                        elper.UIdTchk = lUidTchk
                        OsobN(elper, lElPiket.DataRowPiket)
                        dsProfil.Osob.AddOsobRow(elper)
                    End If

            End Select
            lElPiket = lElPiket.Sled
        Loop



    End Sub
    Protected Sub ProfilwDS()
        DobPiket()
        dsProfil.ProfilA.AcceptChanges()
    End Sub
    ''' <summary>
    ''' для заполнения данных в ДатаСет для коррекции
    ''' </summary>
    ''' <param name="iRasstnauch"></param>
    ''' <remarks></remarks>
    Sub New(ByVal iRasstnauch As wlUch)
        wRasstNaUch = iRasstnauch
        '   wUidUch = iRasstnauch.UidUch
        Dim lm() As DsProfil.ProfilARow = CType(dsProfil.ProfilA.Select("", "Piketaj"), OperBD.DsProfil.ProfilARow())
        'Что бы учесть все вновь добавленые и отсечь удаленые предварительный Селект
        Dim lBegPik As Double = CType(lm(0), DsProfil.ProfilARow).Piketaj
        Dim lEndPik As Double = CType(lm(lm.Length - 1), DsProfil.ProfilARow).Piketaj
    End Sub


    Protected Sub OchistTableUch(ByVal dt As DataTable)
        For Each eldt As DataRow In dt.Rows
            If eldt.RowState = DataRowState.Unchanged Then
                eldt.Delete()

            End If
        Next

    End Sub


End Class