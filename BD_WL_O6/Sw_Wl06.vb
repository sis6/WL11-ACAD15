Imports clsPrf
Imports modRasstOp

Public Class Sw_Wl06
    Private wNameUch, wNameLin As String
    Private dsProfil As DsPrf_06, dsRasst As DsRass_06
    Private wUnom As Integer
    Private wRasstNaUch As modRasstOp.wlUch
    'Dim ad As New DsPrf_06TableAdapters.ProfilNTableAdapter
    'Dim adK As New DsPrf_06TableAdapters.TablKlimNTableAdapter
    'Dim adPikugod As New DsPrf_06TableAdapters.PikUgodNTableAdapter
    'Dim addefp As New DsRass_06TableAdapters.ParamUchNTableAdapter
    'Dim adopor As New DsRass_06TableAdapters.rastOpNTableAdapter
    'Dim admu As New DsRass_06TableAdapters.MechUslTableAdapter
#Region "profil"
    ReadOnly Property Unom As Integer
        Get
            Return wUnom
        End Get
    End Property
	ReadOnly Property UchPrf() As clsUchPrf
		Get
			Return wRasstNaUch.UchTr
		End Get
	End Property
	ReadOnly Property DsProfil06 As DsPrf_06
		Get
			Return dsProfil
		End Get
	End Property
	ReadOnly Property DsRasst06 As DsRass_06
		Get
			Return dsRasst
		End Get
	End Property
	Private Function IzBDPiket(ByVal rw As DsPrf_06.ProfilNRow) As String()

        Return ClsPiket.Soot(rw)
    End Function
    Private Function IzBDKlimat(ByVal Ir As DsPrf_06.TablKlimNRow) As String()
        Dim wrmas() As String = {"", "", "", "", "", "", "", "", "", ""}
        '                         0  1   2    3   4   5   6   7   8   9  10  11
        With Ir
            wrmas(KlimatPar.piketaj) = CStr(.Rast)
            wrmas(KlimatPar.StGolEkw) = CStr(.StGolEkw)
            wrmas(KlimatPar.StGolUsl) = CStr(.StGolUsl)
            wrmas(KlimatPar.Texsp) = CStr(.Texsp)
            wrmas(KlimatPar.Tgol) = CStr(.Tgol)
            wrmas(KlimatPar.Tmin) = CStr(.Tmin)
            wrmas(KlimatPar.Tmax) = CStr(.Tmax)
            wrmas(KlimatPar.NaporVetra) = CStr(.NaporVetra)
            wrmas(KlimatPar.NapPriGol) = CStr(.NapPriGol)
            wrmas(KlimatPar.TipMesta) = CStr(.TipMesta)
        End With
        Return wrmas
    End Function
    Private Function IzBDPikUgod(ByVal Ir As DsPrf_06.PikUgodNRow) As String()
        Dim wmasStr(1) As String
        wmasStr(0) = CStr(Ir.Piketaj)
        wmasStr(1) = "0"
        Return wmasStr


    End Function

    Private Sub IzBdUzastok()
        Dim CollPik, CollKlimat, collUgod As New Collection

        UchPrf.NameUch = wNameUch
       
        For Each elrow As DsPrf_06.ProfilNRow In dsProfil.ProfilN.Rows
            '    IzBDPiket(elrow)
            CollPik.Add(ClsPiket.Soot(elrow))
        Next

       
        For Each elrow As DsPrf_06.TablKlimNRow In dsProfil.TablKlimN.Rows
            CollKlimat.Add(IzBDKlimat(elrow))
        Next
        '   adPikugod.Fill(DsProfil.PikUgodN, wNameUch, wNameLin)
        For Each elrow As DsPrf_06.PikUgodNRow In dsProfil.PikUgodN.Rows
            collUgod.Add(IzBDPikUgod(elrow))
        Next
        UchPrf.SetPoStrPred(CollPik, CollKlimat, collUgod)

    End Sub
#End Region

#Region "Rasst"
    Private Function ObjWstr(ByVal El As Object) As String
        Try
            Return CStr(El)
        Catch ex As Exception
            Return ""
        End Try

    End Function

    Private Function wRow_BD(ByVal rw As DataRow) As String()
        Dim wStr() As String

        wStr = Array.ConvertAll(Of Object, String)(rw.ItemArray, New Converter(Of Object, String)(AddressOf ObjWstr))

        Return wStr
    End Function
    Private Function TablWColl(ByVal dt As DataTable) As Collection
        Dim lcoll As New Collection
        For Each rw As DataRow In dt.Rows
            lcoll.Add(wRow_BD(rw))
        Next
        Return lcoll
    End Function

    Private Function ProvNaStr(ByVal irw As DsRass_06.rastOpNRow, ByVal NamePol As String) As String
        Try
            Return CStr(irw.Item(NamePol))
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Private Function LeseOporIzBD(ByVal irw As DsRass_06.rastOpNRow) As modRasstOp.wlOp
        Dim NumName As String
        NumName = irw.NumName
        ''  MsgBox(NumName)
        If NumName = "" Then
            Return Nothing
        Else
            'D новой БД гирлянда будет задаваться именем, которое ключ в таблице гирлянд "" - имя гирлянды по умолчанию
            Dim Girl, GirlT As String
            Girl = ""
            GirlT = ""


            With irw

                Return New wlOpRasst(wRasstNaUch.DsRasst.rastOpN.AddrastOpNRow(.Tip_op, 0, NumName, .Tip, 0,
                                                                                     Guid.NewGuid, wRasstNaUch.UidUch, .Dlina, "", "", "", 0, Now(), My.User.Name, CSng(wlOp.DefPodwesW(wRasstNaUch.Unom))), wRasstNaUch)
            End With
        End If
    End Function
    Private Sub leseMechUslIzBD(ByVal Irw As DsRass_06.MechUslRow)

        Dim lPiketaj As Double = Irw.Rast
        Dim tpik As ClsPiket = UchPrf.Piket(lPiketaj)
        If Not tpik Is Nothing Then
            With Irw
				Dim SigSrDljOksn, SigMaxDljOKSN As Single
				SigMaxDljOKSN = 200
				SigSrDljOksn = 120
				If String.IsNullOrEmpty(.Name_markT) Then
                    SigMaxDljOKSN = .Sig7_Tgol
					SigSrDljOksn = .Sig1_Texsp
				Else
                    If .Sig7_TgolT < 2 Then
                        .Sig7_TgolT = 200
                        SigMaxDljOKSN = .Sig7_TgolT
                    End If
                    If .Sig1_TexspT < 2 Then
                        .Sig1_TexspT = 180
                        SigSrDljOksn = .Sig1_TexspT
                    End If
                End If
                Dim lrw As OperBD.dsRasst.MechUslRow
                lrw = wRasstNaUch.DsRasst.MechUsl.AddMechUslRow(Guid.NewGuid, wRasstNaUch.UidUch, .Sig1_Tmin, .Sig1_Texsp, .Sig7_Tgol, .Sig1_TexspT, .Sig7_TgolT, .Name_mark,
                                                                .Name_markT, .Tip_op, .Gabarit, .Rast, Now, My.User.Name, 1, .Name_markT, SigSrDljOksn, SigMaxDljOKSN)

                Dim zMechUsl As New modRasstOp.DannZonMechusl(lrw, wRasstNaUch)
                wRasstNaUch.Dob(zMechUsl)
            End With
        End If


    End Sub
    Private Sub IzBDRasstanowku()
        Dim op As modRasstOp.wlOpRasst
        Dim prow As DsRass_06.ParamUchNRow
        '   Dim prmuch As New DsRass_06TableAdapters.ParamUchNTableAdapter
        Dim collG As New Collection 'Пустая коллекция имитирующая набор используемых гирлянд . гирлянды из вл_6 не переносяться
       
        wRasstNaUch.SetElemRasstUch(TablWColl(dsRasst.WseMarkiProvod1), TablWColl(dsRasst.WseTipOpor), collG)
        'Параметры участка
        '    prmuch.Fill(dsRasst.ParamUchN, wNameUch, wNameLin)
        Try
            prow = CType(dsRasst.ParamUchN.Rows(0), DsRass_06.ParamUchNRow)
            With prow
                wRasstNaUch.DsRasst.ParamUchN.AddParamUchNRow(.Gnw, .GnwG, .Greg, .GregGol, .Tip_opA, .Tip_opP, .DlGirl, .MassGirl, .Name_mark, .Name_markT, _
                                                                               .DlGirlT, .MassGirlT, wRasstNaUch.UidUch, Now(), My.User.Name)
                wRasstNaUch.UstParam()
            End With
        Catch ex As Exception
            With wRasstNaUch
                Dim lunom = wRasstNaUch.Unom
                wRasstNaUch.SozdatParam()
            End With

        End Try
        ' Условия расстановки
        For Each Murw As DsRass_06.MechUslRow In dsRasst.MechUsl.Rows
            leseMechUslIzBD(Murw)
        Next
        ''Опоры
        For Each Oprw As DsRass_06.rastOpNRow In dsRasst.rastOpN.Rows
            op = CType(LeseOporIzBD(Oprw), wlOpRasst)
            If Not op Is Nothing Then
                wRasstNaUch.DobOp(op)
            End If
        Next
    End Sub
#End Region
#Region "Glob"
    Sub New(ByVal iNameuch As String, ByVal iNameLin As String)
        Dim aLin As New DsPrf_06TableAdapters.LinijTableAdapter

        Dim ad As New DsPrf_06TableAdapters.ProfilNTableAdapter
        Dim adK As New DsPrf_06TableAdapters.TablKlimNTableAdapter
        Dim adPikugod As New DsPrf_06TableAdapters.PikUgodNTableAdapter

        Dim adprmuch As New DsRass_06TableAdapters.ParamUchNTableAdapter
        Dim adopor As New DsRass_06TableAdapters.rastOpNTableAdapter
        Dim admech As New DsRass_06TableAdapters.MechUslTableAdapter

        dsProfil = New DsPrf_06
        dsRasst = New DsRass_06
        wRasstNaUch = New wlUch(Guid.Empty)
        aLin.Fill(dsProfil.Linij, iNameLin)
        If dsProfil.Linij.Rows.Count > 0 Then
            wUnom = CType(dsProfil.Linij.Rows(0), DsPrf_06.LinijRow).Unom
        Else
            wUnom = 110

        End If



        wNameLin = iNameLin
        wNameUch = iNameuch
        ad.Fill(dsProfil.ProfilN, wNameUch, wNameLin)
        adK.Fill(dsProfil.TablKlimN, wNameUch, wNameLin)
        adPikugod.Fill(dsProfil.PikUgodN, wNameUch, wNameLin)
        IzBdUzastok()
        Dim lAdOp As New DsRass_06TableAdapters.WseTipOporTableAdapter
        Dim lAdprov As New DsRass_06TableAdapters.WseMarkiProvod1TableAdapter
        lAdOp.Fill(dsRasst.WseTipOpor, wNameUch, wNameLin)
        lAdprov.Fill(dsRasst.WseMarkiProvod1, wNameUch, wNameLin)
        adprmuch.Fill(dsRasst.ParamUchN, wNameUch, wNameLin)
        adopor.Fill(dsRasst.rastOpN, wNameUch, wNameLin)
        admech.Fill(dsRasst.MechUsl, wNameUch, wNameLin)
        IzBDRasstanowku()

    End Sub
    Sub New(ByVal iNameuch As String, ByVal iNameLin As String, ByVal iBegPik As Double, ByVal iEndPik As Double)
        Dim aLin As New DsPrf_06TableAdapters.LinijTableAdapter

        Dim zBegPik As Double = Int(iBegPik) - 1
        Dim zEndPik As Double = Int(iEndPik) + 2 ' целые границы. включающие в себя переданные 
        Dim ad As New DsPrf_06TableAdapters.ProfilNTableAdapter
        Dim adK As New DsPrf_06TableAdapters.TablKlimNTableAdapter
        Dim adPikugod As New DsPrf_06TableAdapters.PikUgodNTableAdapter

        Dim adprmuch As New DsRass_06TableAdapters.ParamUchNTableAdapter
        Dim adopor As New DsRass_06TableAdapters.rastOpNTableAdapter
        Dim admech As New DsRass_06TableAdapters.MechUslTableAdapter

        dsProfil = New DsPrf_06
        dsRasst = New DsRass_06

        wRasstNaUch = New wlUch(Guid.Empty)
        aLin.Fill(dsProfil.Linij, iNameLin)
        If dsProfil.Linij.Rows.Count > 0 Then
            wUnom = CType(dsProfil.Linij.Rows(0), DsPrf_06.LinijRow).Unom
        Else
            wUnom = 110

        End If
        wNameLin = iNameLin
        wNameUch = iNameuch
        ad.FillBy(dsProfil.ProfilN, wNameUch, wNameLin, CSng(zBegPik), CSng(zEndPik))
        iBegPik = CType(dsProfil.ProfilN.First, DsPrf_06.ProfilNRow).Piketaj
        iEndPik = CType(dsProfil.ProfilN.Last, DsPrf_06.ProfilNRow).Piketaj
        Dim begKlim As Double = CDbl(adK.GrKlimZon(iNameuch, iNameLin, CSng(iBegPik + 0.5))) - 0.1 'для отстройки неточностей округления
        Dim begMechUsl As Double = CDbl(admech.GrMechUsl(iNameuch, iNameLin, CSng(iBegPik + 0.5))) - 0.1
        ' MsgBox(begKlim)
        'CSng(adK.GrKlimZon(iNameuch, iNameLin, CSng(iBegPik)).GetType.ToString)
        ad.FillBy(dsProfil.ProfilN, wNameUch, wNameLin, CSng(zBegPik), CSng(zEndPik))
        adK.FillBy(dsProfil.TablKlimN, wNameUch, wNameLin, CSng(begKlim), CSng(iEndPik))
        adPikugod.FillBy(dsProfil.PikUgodN, wNameUch, wNameLin, CSng(iBegPik), CSng(iEndPik))
        IzBdUzastok()
        Dim lAdOp As New DsRass_06TableAdapters.WseTipOporTableAdapter
        Dim lAdprov As New DsRass_06TableAdapters.WseMarkiProvod1TableAdapter
        lAdOp.Fill(dsRasst.WseTipOpor, wNameUch, wNameLin)
        lAdprov.Fill(dsRasst.WseMarkiProvod1, wNameUch, wNameLin)
        adprmuch.Fill(dsRasst.ParamUchN, wNameUch, wNameLin)
        adopor.FillBy(dsRasst.rastOpN, wNameUch, wNameLin, CSng(zBegPik), CSng(zEndPik))
        admech.FillBy(dsRasst.MechUsl, wNameUch, wNameLin, CSng(begMechUsl), CSng(iEndPik))
        IzBDRasstanowku()
    End Sub
    ReadOnly Property UchWL() As wlUch
        Get
            Return wRasstNaUch

        End Get
    End Property
#End Region

End Class
