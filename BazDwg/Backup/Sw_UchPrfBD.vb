Option Explicit On
Option Strict Off
'Imports Microsoft.Office.Interop
Imports clsPrf
Imports modRasstOp
'Обеспечивает связь участка профиля с  DataSet представляющим БД профидей 
Public Class Sw_UchPrfBD

    Dim wUkNaUch As Guid
    Dim dsProfil As dsProfil, dsRasst As dsRasst

    Private RasstNaUch As modRasstOp.wlUch

#Region "Пикеты"
    Private Function IzBDPiket(ByVal rw As dsProfil.ProfilARow) As Boolean
        Dim objPik As New clsPiket(clsPiket.Soot(rw))
        UchPrf.Dob(objPik)
        If Not rw.IsNull("Tip") Then
            Dim objPikUg As New clsPikUgod(objPik)
            UchPrf.Dob(objPikUg)
        End If
        Return True
    End Function
    Private Sub DobPiket()
        'Добавление пикетной точки в  БД
        Dim tkElement As clsPiket
        Dim i As Integer

        For i = 0 To UchPrf.MaxNumPiket
            tkElement = UchPrf.Piket(i)
            Dim rwPiket As dsProfil.ProfilNRow

            If i < dsProfil.ProfilN.Count Then
                rwPiket = dsProfil.ProfilN.Rows(i)
            Else
                rwPiket = dsProfil.ProfilN.NewProfilNRow()
                rwPiket.UIdTchk = Guid.NewGuid
                rwPiket.UIdUch = wUkNaUch


            End If
            With tkElement

                rwPiket.NameTchk = .NamePiket     'CType(ExList.Cells(ReX, 1), Excel.Range).Value
                rwPiket.Piketaj = .Piketaj
                rwPiket.Otmetka = .Otmetka
                If .EstOtmetkaLw Then
                    rwPiket.OtmetkaLw = .OtmetkaLw
                End If
                If .EstOtmetkaPr Then
                    rwPiket.OtmetkaPr = .OtmetkaPr
                End If
                If .EstPeresech Then
                    Dim RazM As Integer
                    Dim mas() As Double
                    mas = .Peresech.Otmetki
                    Try
                        RazM = UBound(mas)
                    Catch e As Exception
                        RazM = -1
                    End Try

                    Dim rwPersch As dsProfil.OsobRow = dsProfil.Osob.FindByUIdTchk(rwPiket.UIdTchk)
                    If rwPersch Is Nothing Then
                        rwPersch = dsProfil.Osob.NewRow()
                        rwPersch.UIdTchk = rwPiket.UIdTchk

                        dsProfil.Osob.Rows.Add(rwPersch)

                    End If
                    If RazM >= 0 Then
                        rwPersch.Param1 = mas(0)
                        If RazM >= 1 Then
                            rwPersch.Param2 = mas(1)
                            If RazM >= 2 Then
                                rwPersch.Param3 = mas(2)
                                If RazM >= 3 Then
                                    rwPersch.Param4 = mas(3)
                                End If

                            End If
                        End If
                    End If

                    rwPersch.IdTipSoor = .Peresech.IdTipSoor
                    rwPersch.Opis = .Peresech.Opis
                End If
                If .EstUgolPoworota Then
                    Dim rwUgol As dsProfil.UgolPoworotaRow = dsProfil.UgolPoworota.Rows.Find(rwPiket.UIdTchk)
                    If rwUgol Is Nothing Then
                        rwUgol = dsProfil.UgolPoworota.NewRow
                        rwUgol.UIdTchk = rwPiket.UIdTchk
                        rwUgol.UgolPoworot = .UgolPoworota.StrUgolPoworota  ' 12 - столбец
                        dsProfil.UgolPoworota.Rows.Add(rwUgol)
                    End If
                    rwUgol.UgolPoworot = .UgolPoworota.StrUgolPoworota  ' 12 - столбец
                End If
            End With

            If rwPiket.RowState = DataRowState.Detached Then dsProfil.ProfilN.Rows.Add(rwPiket)


        Next
        Dim taPr As New dsProfilTableAdapters.ProfilNTableAdapter
        Dim taPer As New dsProfilTableAdapters.OsobTableAdapter
        Dim taUg As New dsProfilTableAdapters.UgolPoworotaTableAdapter
        taPr.Update(dsProfil.ProfilN)
        taPer.Update(dsProfil.Osob)
        taUg.Update(dsProfil.UgolPoworota)

    End Sub
#End Region
#Region "Klimat"
    'Извлечение данных о Климате
    Private Function IzBDKlimat(ByVal Ir As dsProfil.TablKlimNRow) As Boolean


        Dim piketaj As Double = Ir.Piketaj


        Dim wPik As clsPiket
        wPik = UchPrf.Piket(piketaj)
        If Not (wPik Is Nothing) Then
            Dim objKlim As New clsZonKlimat
            With Ir
                objKlim.Ustanovit(.StGolEkw, .StGolUsl, .Texsp, .Tgol, .Tmin, .Tmax, .NaporVetra, .NapPriGol, .TipMesta)
            End With
            objKlim.Piket = wPik
            UchPrf.Dob(objKlim)



            Return True
        Else
            Return False
        End If
      
    End Function
    Private Sub DobKlimBD()

        Dim tkKlimat As clsPrf.clsZonKlimat
        Dim i As Integer
        tkKlimat = UchPrf.BegKlimZon
        i = 0
        Do Until tkKlimat Is Nothing

            If i < dsProfil.TablKlimN.Count Then
                Dim dklim As dsProfil.TablKlimNRow
                dklim = dsProfil.TablKlimN.Rows(i)
                With dklim
                    .Piketaj = tkKlimat.Piketaj
                    .StGolEkw = tkKlimat.StGolEkw
                    .StGolUsl = tkKlimat.StGolUsl
                    .Texsp = tkKlimat.Texsp
                    .Tgol = tkKlimat.Tgol
                    .Tmax = tkKlimat.Tmax
                    .Tmin = tkKlimat.Tmin
                    .NaporVetra = tkKlimat.Napor
                    .NapPriGol = tkKlimat.NaporPrGol
                End With
            Else
                With tkKlimat
                    dsProfil.TablKlimN.AddTablKlimNRow(Guid.NewGuid, wUkNaUch, .Piketaj, .StGolEkw, .StGolUsl, .Texsp, .Tgol, .Tmin, .Tmax, _
                                                       .Napor, .NaporPrGol, .TipMesta)

                End With

            End If
            i += 1
            '  MyBase.UniMasStr(sKlimat, RjadKlim, 10) = tkKlimat.GetStrPred
            tkKlimat = tkKlimat.Sled
        Loop
        Dim taklim As New dsProfilTableAdapters.TablKlimNTableAdapter
        taklim.Update(dsProfil.TablKlimN)
    End Sub
#End Region
#Region "ПикетажУгод"

    Private Sub DobPikUgod()
        Dim tkElement As clsPikUgod
        Dim i As Integer
        For i = 0 To UchPrf.MaxNumPiketUgod
            tkElement = UchPrf.PiketUgod(i)
            If i < dsProfil.PikUgodN.Count Then
                Dim rwPikugod As dsProfil.PikUgodNRow = dsProfil.PikUgodN.Rows(i)
                With rwPikugod
                    .Piketaj = tkElement.Piketaj

                End With
            Else

                dsProfil.PikUgodN.AddPikUgodNRow(dsProfil.ProfilN.FindByUIdTchk(tkElement.Piket.UkNaPiket()), tkElement.Piketaj, 0)
            End If
        Next i
        Dim tapikUgod As New dsProfilTableAdapters.PikUgodNTableAdapter
        tapikUgod.Update(dsProfil.PikUgodN)
    End Sub



#End Region

#Region "opor"
    Private Function ProvNaStr(ByVal irw As dsRasst.rastOpNRow, ByVal NamePol As String) As String
        Try
            Return irw.Item(NamePol)
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Function LeseOpor(ByVal irw As dsRasst.rastOpNRow) As modRasstOp.wlOpTrass
        Dim NumName As String
        NumName = irw.NumName
        ''  MsgBox(NumName)
        If NumName = "" Then
            Return Nothing
        Else
            'D новой БД гирлянда будет задаваться именем, которое ключ в таблице гирлянд "" - имя гирлянды по умолчанию
            Dim Girl, GirlT As String
            Try
                Girl = irw.NameGirl
            Catch ex As Exception
                Girl = ""
            End Try

            Try
                GirlT = irw.NameGirlT
            Catch ex As Exception
                GirlT = ""
            End Try


            With irw
                Return New modRasstOp.wlOpTrass(New wlOp(NumName, .Tip, .Tip_op, .Piketaj, .Wisota, Girl, GirlT, ProvNaStr(irw, "UgolPoworot")), RasstUchWL)
            End With
        End If
    End Function
    Private Sub leseMechUsl(ByVal Irw As dsRasst.MechUslRow)

        Dim lPiketaj As Double = Irw.Rast
        Dim tpik As clsPiket = UchPrf.Piket(lPiketaj)
        If Not tpik Is Nothing Then
            With Irw
                Dim zMechUsl As New modRasstOp.ClszonMechusl(lPiketaj, .Sig1_Tmin, .Sig1_Texsp, .Sig7_Tgol, .Sig1_TminT, .Sig1_TexspT, .Sig7_TgolT _
                                                             , .Name_mark, .Name_markT, .Tip_op, .Gabarit)
                zMechUsl.Piket = tpik
                RasstNaUch.Dob(zMechUsl)
            End With
        End If


    End Sub
    Private Sub IzBDRasstanowku()

        Dim op As modRasstOp.wlOpTrass

        Dim prmuch As New dsRasstTableAdapters.ParamUchNTableAdapter

        'Параметры участка
        prmuch.Fill(dsRasst.ParamUchN, wUkNaUch)
        Dim prow As dsRasst.ParamUchNRow = dsRasst.ParamUchN.Rows(0)
        With prow
            RasstNaUch.UstParam(New wlDefParam(.Gnw, .GnwG, .Greg, .GregGol, .Tip_opA, .Tip_opP, .Name_mark, .Name_markT, _
                                               .DlGirl, .MassGirl, .DlGirlT, .DlGirlT))
        End With
        'Опоры
        Dim adOpor As New dsRasstTableAdapters.rastOpNTableAdapter
        adOpor.Fill(dsRasst.rastOpN, wUkNaUch)
        For Each Oprw As dsRasst.rastOpNRow In dsRasst.rastOpN.Rows
            op = LeseOpor(Oprw)
            If Not op Is Nothing Then
                RasstNaUch.DobOp(op)
            End If
        Next
        ' Условия расстановки
        Dim adMech As New dsRasstTableAdapters.MechUslTableAdapter
        adMech.Fill(dsRasst.MechUsl, wUkNaUch)
        For Each Murw As dsRasst.MechUslRow In dsRasst.MechUsl.Rows
            leseMechUsl(Murw)

        Next


    End Sub
    Private Sub RasstanowkuWBD()
        With RasstNaUch.DefParam
            If dsRasst.ParamUchN.Count = 0 Then
                dsRasst.ParamUchN.AddParamUchNRow(.nKoeff.Gnw, .nKoeff.GnwG, .nKoeff.Greg, .nKoeff.GregGol, .NameTipOporA, .NameTipOporP, .Girl.DlGirl, .Girl.MassGirl, _
                .MarkaPr, .MarkaT, .GirlT.DlGirl, .GirlT.MassGirl, wUkNaUch)
            Else
                Dim rwdefp As dsRasst.ParamUchNRow = dsRasst.ParamUchN.Rows(0)
                rwdefp.Gnw = .nKoeff.Gnw
                rwdefp.GnwG = .nKoeff.GnwG
                rwdefp.Greg = .nKoeff.Greg
                rwdefp.GregGol = .nKoeff.GregGol
                rwdefp.Tip_opA = .NameTipOporA
                rwdefp.Tip_opP = .NameTipOporP
                rwdefp.DlGirl = .Girl.DlGirl
                rwdefp.MassGirl = .Girl.MassGirl()
                rwdefp.Name_markT = .MarkaT
                rwdefp.Name_mark = .MarkaPr
                rwdefp.Name_markT = .MarkaT
                rwdefp.DlGirlT = .GirlT.DlGirl
                rwdefp.MassGirlT = .GirlT.MassGirl()

            End If
        End With

        For i1 As Integer = 1 To RasstNaUch.Count
            With RasstNaUch.Opora(i1)
                If i1 <= dsRasst.rastOpN.Count Then
                    Dim rwop As dsRasst.rastOpNRow = dsRasst.rastOpN.Rows(i1 - 1)

                    rwop.Piketaj = .Piketaj
                    rwop.NumName = .NumName
                    rwop.Tip = .Tip
                    rwop.Tip_op = .NameTipOpor
                    rwop.Wisota = .DelaWis
                    rwop.UgolPoworot = .StrUgolPoworot
                    rwop.NameGirl = .nameGirl
                    rwop.NameGirlT = .NameGirlT

                Else
                    dsRasst.rastOpN.AddrastOpNRow(.NameTipOpor, .DelaWis, .NumName, .Tip, 0, Guid.NewGuid, wUkNaUch, .Piketaj, .nameGirl, .NameGirlT, .StrUgolPoworot)

                End If
            End With
        Next
        Dim tkMechUsl As ClszonMechusl
        Dim i As Integer
        tkMechUsl = RasstNaUch.BegMechUslZon
        i = 0
        Do Until tkMechUsl Is Nothing
            With tkMechUsl
                If i < dsRasst.MechUsl.Count Then
                    Dim dmu As dsRasst.MechUslRow
                    dmu = dsRasst.MechUsl.Rows(i)

                    dmu.Rast = .Piketaj
                    dmu.Sig1_Tmin = .Sig(2)
                    dmu.Sig1_Texsp = .Sig(0)
                    dmu.Sig7_Tgol = .Sig(1)
                    dmu.Sig1_TminT = .SigT(2)
                    dmu.Sig1_TexspT = .SigT(0)
                    dmu.Sig7_TgolT = .SigT(1)
                    dmu.Name_mark = .Name_mark
                    dmu.Name_markT = .Name_markT
                    dmu.Tip_op = .Tip_op
                    dmu.Gabarit = .Gabarit
                    dmu.DataW = Now()


                Else

                    dsRasst.MechUsl.AddMechUslRow(.Sig(2), .Sig(0), .Sig(1), .SigT(2), .SigT(0), .SigT(1), .Name_mark, .Name_markT, .Tip_op, _
                                                  .Gabarit, .Piketaj, Now(), "MyS", wUkNaUch, Guid.NewGuid)




                End If
            End With
                i += 1
                '  MyBase.UniMasStr(sKlimat, RjadKlim, 10) = tkKlimat.GetStrPred
            tkMechUsl = tkMechUsl.Sled
        Loop
        Dim tadefp As New dsRasstTableAdapters.ParamUchNTableAdapter
        tadefp.Update(dsRasst.ParamUchN)
        Dim taopor As New dsRasstTableAdapters.rastOpNTableAdapter
        taopor.Update(dsRasst.rastOpN)
        Dim tamu As New dsRasstTableAdapters.MechUslTableAdapter
        tamu.Update(dsRasst.MechUsl)

    End Sub

#End Region
#Region "чтение из BD"
    Private Sub IzBdUzastok()

        Dim ad As New dsProfilTableAdapters.ProfilATableAdapter
        UchPrf.NameUch = wUkNaUch.ToString
        ad.Fill(dsProfil.ProfilA, wUkNaUch)
        ' dsProfil.  
        For Each trow As dsProfil.ProfilARow In dsProfil.ProfilA.Rows
            IzBDPiket(trow)
        Next
     
        Dim adK As New dsProfilTableAdapters.TablKlimNTableAdapter
        adK.Fill(dsProfil.TablKlimN, wUkNaUch)
        For Each trow As dsProfil.TablKlimNRow In dsProfil.TablKlimN.Rows
            IzBDKlimat(trow)
        Next

     


    End Sub
    Public Sub IzBD_Wse()
        IzBdUzastok()
        IzBDRasstanowku()
    End Sub
#End Region
#Region "участок  в BD"
    Sub UchastokW_BD()
        DobPiket()
        DobKlimBD()
        DobPikUgod()
        RasstanowkuWBD()
    End Sub
#End Region
    
    Property RasstUchWL() As modRasstOp.wlUch
        Get
            Return RasstNaUch
        End Get
        Set(ByVal value As modRasstOp.wlUch)
            RasstNaUch = value
        End Set

    End Property
    ReadOnly Property UchPrf() As clsUchPrf
        Get
            Return RasstNaUch
        End Get
    End Property
  
    Public Sub New()
        ' UchPrf = New clsUchPrf
        RasstNaUch = New wlUch
    End Sub
    Public Sub New(ByVal iUkNaUch As Guid)
        MyClass.New()
        wUkNaUch = iUkNaUch
        MsgBox(MyClass.ToString & "  " & wUkNaUch.ToString)
        dsProfil = New dsProfil
        dsRasst = New dsRasst

    End Sub

End Class
