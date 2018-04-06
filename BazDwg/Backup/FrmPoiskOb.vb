Public Class FrmUchprf
    Dim wuknauch As Guid
    Dim uch As modRasstOp.wlUch
    Dim Trassa As clsPrf.clsTrass
    Dim Rasst As modRasstOp.wlRasstTrass
    Dim rwUch As dsUpr.uchastkiNRow
    Dim rwFileUch As dsUpr.FileExcelRow
    WriteOnly Property RowFileUch() As dsUpr.FileExcelRow
        Set(ByVal value As dsUpr.FileExcelRow)
            rwFileUch = value
            NameFileUch.Text = rwFileUch.PutExel

            Trassa = New clsPrf.clsTrass
            Trassa.DobUch(LeseSreib.ModIsp.LeseDann(rwFileUch.PutExel).UchTr)
            Rasst = New modRasstOp.wlRasstTrass(Trassa)
            Rasst.OprRast()
            zapolnit()
        End Set
    End Property

    WriteOnly Property RowUch(Optional ByVal Pr As Boolean = True) As dsUpr.uchastkiNRow
        Set(ByVal value As dsUpr.uchastkiNRow)
            rwUch = value

            NameUch.Text = rwUch.NameUch
            If Pr Then
                UkNauch = rwUch.UIdUch
            Else
                wuknauch = rwUch.UIdUch
            End If

        End Set
    End Property
    Private Sub zapolnit()
        With CType(Rasst.objTr.Uchastki(1), clsPrf.clsUchPrf)

            Dim tpik As clsPrf.clsPiket = .BegUch
            Dim tklim As clsPrf.clsZonKlimat = .BegKlimZon
            Do Until tpik Is Nothing
                ClsPiketBindingSource.Add(tpik)
                tpik = tpik.Sled
            Loop
            Do Until tklim Is Nothing
                ClsZonKlimatBindingSource.Add(tklim)
                tklim = tklim.Sled
            Loop
        End With
        With CType(Rasst.objTr.Uchastki(1), modRasstOp.wlUch)
            .UstBeg()
            Dim topor As modRasstOp.wlOpTrass = .Opora
            Do Until topor Is Nothing
                RastOpNBindingSource.Add(topor)
                .NaSled()
                topor = .Opora
            Loop
            Dim tmu As modRasstOp.ClszonMechusl = .BegMechUslZon
            Do Until tmu Is Nothing
                ClszonMechuslBindingSource.Add(tmu)
                tmu = tmu.Sled
            Loop
            WlDefParamBindingSource.Add(.DefParam)
        End With
    End Sub
    Property UkNauch() As Guid
        Get
            Return wuknauch
        End Get
        Set(ByVal value As Guid)
            wuknauch = value
            Dim Preobr As New Sw_UchPrfBD(wuknauch)
            Trassa = New clsPrf.clsTrass


            Preobr.IzBD_Wse()
            Trassa.DobUch(Preobr.UchPrf)

            Rasst = New modRasstOp.wlRasstTrass(Trassa)
            Rasst.OprRast()
            ' CType(Rasst.objTr.Uchastki(0), clsPrf.clsUchPrf)
            zapolnit()

        End Set

    End Property
    

    Private Sub ProfilDataGridView_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles ProfilDataGridView.DataError
        If e.RowIndex < ProfilDataGridView.NewRowIndex Then

            MsgBox(e.RowIndex & " " & e.ColumnIndex & " " & e.Exception.Message)
        End If
    End Sub

    Private Sub ProfilDataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ProfilDataGridView.CellContentClick
        If ProfilDataGridView.Columns(e.ColumnIndex).Name = "EstPeresech" Then
            If ProfilDataGridView.Rows(e.RowIndex).Cells("EstPeresech").Value = True Then
                Dim obj As clsPrf.clsPeresech = CType(ClsPiketBindingSource.Item(e.RowIndex), clsPrf.clsPiket).Peresech
                MsgBox(obj.IdTipSoor)
            End If
        End If
    End Sub

    Private Sub RastOpDataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles RastOpDataGridView.CellContentClick

    End Sub

    Private Sub ProfilDataGridView_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ProfilDataGridView.RowEnter
        
    End Sub

    Private Sub ProfilDataGridView_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ProfilDataGridView.CurrentCellChanged
        ClsPeresechBindingSource.Clear()
        UgPovorot.Text = ""
        With ProfilDataGridView
            If .CurrentRow IsNot Nothing Then
                If .CurrentRow.Cells("EstPeresech").Value = True Then

                    ClsPeresechBindingSource.Add(CType(ClsPiketBindingSource.Item(.CurrentRow.Index), clsPrf.clsPiket).Peresech)
                End If
                If .CurrentRow.Cells("EstUgolPoworota").Value = True Then
                    UgPovorot.Text = CType(ClsPiketBindingSource.Item(.CurrentRow.Index), clsPrf.clsPiket).UgolPoworota.StrUgolPoworota
                End If
            End If
        End With
    End Sub

    Private Sub SohrWBD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SohrWBD.Click
        Dim Preobr As New Sw_UchPrfBD(wuknauch)
        Preobr.RasstUchWL = CType(Trassa.Uchastki(1), modRasstOp.wlUch)
        Preobr.UchastokW_BD()
    End Sub

    Private Sub UgPovorot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UgPovorot.Click

    End Sub
End Class