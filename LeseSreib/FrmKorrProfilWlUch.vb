Option Strict On
Option Explicit On
Imports OperBD
Imports System.Windows.Forms
Imports modRasstOp

''' <summary>
''' Форма используеться для корректировки данных участка профиля
''' </summary>
''' <remarks></remarks>
Public Class FrmKorrProfilWlUch
    Private wNameDwgload As String
    Private wOprRej As New LeseSreib.clsSreibeBD
    Private wNameIstochnik As String = "сохранять в чертеже "
    Private wIzmUch As wlUch
    Private wdsRasst As dsRasst
    '  Dim wElemRasstTip As New ElemRasst
    ''' <summary>
    '''  Вспогательные переменные: начальный и конечный пикетаж участка, текуший пикет и и средняя отметка участка профиля  
    ''' </summary>
    ''' <remarks></remarks>
    Private wPikBeg, wPikEnd, wPikTek, wOtmSr As Double

	Public Property Dostup As OperBD.dostup
	Sub UstProsmotr()

		With Me
			Me.Text = "Просмотр   данных"
			Me.BackColor = Color.Aqua







			Me.ToolStripButtonAllOk.Visible = False
			ToolStripButtonSohrDwg.Visible = False


			For Each cntr As Control In .Controls
				If TypeOf cntr Is TabControl Then
					For Each lpag As TabPage In CType(cntr, TabControl).TabPages
						For Each cntr1 As Control In lpag.Controls
							If TypeOf cntr1 Is DataGridView Then
								Dim ldgv As DataGridView = CType(cntr1, DataGridView)
								ldgv.ReadOnly = True
								ldgv.AllowUserToAddRows = False
								ldgv.AllowUserToDeleteRows = False
							End If
						Next
					Next


				End If

			Next
		End With

	End Sub
	Sub OprGraniz()
        Dim ldrow() As DsProfil.ProfilARow
        ldrow = CType(DsProfilA.ProfilA.Select("", "Piketaj"), DsProfil.ProfilARow())

        Try
            wPikBeg = ldrow(0).Piketaj
        Catch ex As Exception
            wPikBeg = 0
            wPikEnd = 0
            Return
        End Try

        wPikEnd = ldrow(ldrow.Length - 1).Piketaj
        wOtmSr = (ldrow(0).Otmetka + ldrow(ldrow.Length - 1).Otmetka) * 0.5
        ToolStripLabelPikBeg.Text = Format(wPikBeg, "#.#")
        ToolStripLabelPikEnd.Text = Format(wPikEnd, "#.#")

    End Sub

#Region "Init"
    Private Sub wInit()

        OprGraniz()
        wPikTek = wPikBeg
        ToolStripLabelWibrPiket.Text = CStr(wPikTek)

    End Sub
    ''' <summary>
    ''' Задает и читает изменяемый участок расстановки 
    ''' </summary>
    ''' <value> </value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
    Property IzmUch() As wlUch

        Get
            Return wIzmUch
        End Get
        Set(ByVal Iizmuch As wlUch)

            wIzmUch = Iizmuch
            DsProfilA.Clear()
            '   wdsRasst.Clear()
            DsProfilA = wIzmUch.dsProfil
            wdsRasst = wIzmUch.DsRasst
            DataGridViewProfil.DataSource = DsProfilA
            DataGridViewProfil.DataMember = "ProfilA"
            ClsZonKlimatBindingSource.DataSource = DsProfilA
            ClsZonKlimatBindingSource.DataMember = "TablKlimN"
            PiketUgodBindingSource.DataSource = DsProfilA
            PiketUgodBindingSource.DataMember = "PikUgodN"
            '   MsgBox("Bindung0  " & OporBindingSource.DataSource.ToString & "  М  " & OporBindingSource.DataMember)

            '    MsgBox("IzmUch " & ElemRasstUch1.oporIUch.Count)
            wInit()
            NameFileUch.Text = wIzmUch.NameUch
        End Set
    End Property
    Private Sub FrmKorr_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		wOprRej = New LeseSreib.clsSreibeBD
		If wOprRej.RejmSowmest Then
			If Not (Dostup.Prawo = PrawoDostup.PolzTiz OrElse Dostup.Prawo = PrawoDostup.AdminWL OrElse Dostup.Prawo = PrawoDostup.Admin) Then UstProsmotr()
		End If
		wNameDwgload = BazDwg.SystemKommand.NameFileDwg
		TabControl1.SelectedTab = Profil



		If Me.wOprRej.RejmSowmest = True Then wNameIstochnik = "сохранять в базе данных "
        ToolStripButtonSohrDwg.Text = "Не " & wNameIstochnik
        HelpProvider1.SetHelpNavigator(Me, HelpNavigator.Topic)
        If DsProfilA.TipSoor.Rows.Count = 0 Then
            DsProfilA.TipSoor.ReadXml(My.Settings.BasePapka & "\DANN\tipsoor.xml")
            DsProfilA.TipUgod.ReadXml(My.Settings.BasePapka & "\DANN\tipugod.xml")
            DsProfilA.TipMest.ReadXml(My.Settings.BasePapka & "\DANN\tipmest.xml")
            DsProfilA.TipSoor.AcceptChanges()
            DsProfilA.TipUgod.AcceptChanges()
            DsProfilA.TipMest.AcceptChanges()
        End If



        With IdTipSoor1
            .DataSource = DsProfilA.TipSoor
            .DisplayMember = "NameTip"
            .ValueMember = "IdTipSoor"
        End With
        With TipDataGridViewComboBoxColumn
            .DataSource = DsProfilA.TipUgod
            .DisplayMember = "NameTip"
            .ValueMember = "Tip"
        End With
        With TipMestaDataGridViewTextBoxColumn
            .DataSource = DsProfilA.TipMest
            .DisplayMember = "Kod"
            .ValueMember = "IndexM"
        End With



        With DataGridViewComboBoxPiketaj    'для выборора пикетажа в пикетаже угодий
            .DataSource = DsProfilA.ProfilA
            .ValueMember = "Piketaj"
            .DisplayMember = "Piketaj"
        End With

        DataGridViewProfil.Sort(Piketaj1, System.ComponentModel.ListSortDirection.Ascending)

        PiketUgodBindingSource.Sort = "Piketaj"

    End Sub
#End Region
   
#Region "DataGriDViewProfil"
    Private Sub DataGridViewProfil_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DataGridViewProfil.DataError
       
        clsPrf.Obrabot(sender, e)
    End Sub
    Private Sub DataGridViewProfil_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewProfil.CellEndEdit
        If DataGridViewProfil.Columns(e.ColumnIndex).Name = "OpisDataGridViewTextBoxColumn1" Then
            '  IdTipSoor1.
            Dim w1 As DataGridViewTextBoxCell = CType(DataGridViewProfil.Rows(e.RowIndex).Cells("OpisDataGridViewTextBoxColumn1"), DataGridViewTextBoxCell)
            If DBNull.Value.Equals(w1.Value) Then Return
            Dim w As DataGridViewComboBoxCell = CType(DataGridViewProfil.Rows(e.RowIndex).Cells("IdTipSoor1"), DataGridViewComboBoxCell)
            If DBNull.Value.Equals(w.Value) Then
                w.Value = 13 'CType(DsProfilA.TipSoor.Rows(12), DsProfil.TipSoorRow).IdTipSoor 
            End If

        End If

        If DataGridViewProfil.Columns(e.ColumnIndex).Name = "IdTipSoor1" Then
            '  IdTipSoor1.
            Dim w1 As DataGridViewTextBoxCell = CType(DataGridViewProfil.Rows(e.RowIndex).Cells("OpisDataGridViewTextBoxColumn1"), DataGridViewTextBoxCell)

            Dim w As DataGridViewComboBoxCell = CType(DataGridViewProfil.Rows(e.RowIndex).Cells("IdTipSoor1"), DataGridViewComboBoxCell)
            ' Dim lw As DataGridViewComboBoxCell = CType(DataGridViewProfil.Rows(e.RowIndex - 1).Cells("IdTipSoor1"), DataGridViewComboBoxCell)
            If w.Value.Equals(DBNull.Value) Then Return
            '  Integer.TryParse()
            If CInt(w.Value) = 0 And String.IsNullOrEmpty(w1.Value.ToString) Then w.Value = DBNull.Value
        End If

        If DataGridViewProfil.Columns(e.ColumnIndex).Name = "UgolPoworotDataGridViewTextBoxColumn2" Then
            Dim w As DataGridViewTextBoxCell = CType(DataGridViewProfil.Rows(e.RowIndex).Cells("UgolPoworotDataGridViewTextBoxColumn2"), DataGridViewTextBoxCell)
            If clsPrf.clsUgolPoworot.Pozizij1Zifr(CStr(w.FormattedValue)) < 0 Then
                w.Value = ""
            End If

        End If

        ' wBuf.ZapisatCellDataGrid(DataGridViewProfil, e.RowIndex, e.ColumnIndex)

    End Sub
    Private Sub DataGridViewProfil_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles DataGridViewProfil.UserDeletedRow
        OprGraniz()
        ' e.Row.Cells(1).OwningColumn.Name
        ' MsgBox(e.Row.Cells(1).OwningColumn.Name & "   " & e.Row.Cells(1).OwningColumn.DataPropertyName & "  " & e.Row.Cells(1).Value.ToString)

        ' Dim lind = PiketUgodBindingSource.Find("Piketaj", e.Row.Cells("Piketaj1"))
        '   If lind >= 0 Then PiketUgodBindingSource.RemoveAt(lind)

    End Sub
    Private Sub DataGridViewProfil_UserDeletingRow(sender As Object, e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles DataGridViewProfil.UserDeletingRow
        '  MsgBox(e.Row.Cells(1).OwningColumn.Name & "   " & e.Row.Cells(1).OwningColumn.DataPropertyName & "  " & e.Row.Cells(1).Value.ToString)
        Dim lind = PiketUgodBindingSource.Find("Piketaj", e.Row.Cells("Piketaj1").Value)
        If lind >= 0 Then PiketUgodBindingSource.RemoveAt(lind)
    End Sub
    Private Sub DataGridViewProfil_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles DataGridViewProfil.DefaultValuesNeeded
        Dim crow As DataGridViewRow = e.Row
        crow.Cells("UIdTchk1").Value = Guid.NewGuid

        Try
            crow.Cells("UIdUch1").Value = wIzmUch.UidUch
        Catch ex As Exception
            crow.Cells("UIdUch1").Value = Guid.Empty
        End Try

        crow.Cells("Piketaj1").Value = CSng(wPikEnd + 50)
        crow.Cells("Otmetka1").Value = CSng(wOtmSr)

    End Sub
    Private Sub DataGridViewProfil_RowValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewProfil.RowValidated
        OprGraniz()
    End Sub
    Private Sub DataGridViewProfil_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewProfil.RowEnter
        wPikTek = CDbl(DataGridViewProfil.Rows(e.RowIndex).Cells("Piketaj1").Value)
        ToolStripLabelWibrPiket.Text = CStr(wPikTek)
    End Sub
    Private Sub DataGridViewProfil_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewProfil.CellContentClick
        If e.ColumnIndex = 1 Then
            Try
                TextBoxBegSdwig.Text = CStr(Int(DataGridViewProfil.Rows(e.RowIndex).Cells(e.ColumnIndex).Value))
            Catch ex As Exception
                TextBoxBegSdwig.Text = ToolStripLabelPikBeg.Text
            End Try

        End If
    End Sub
#Region "Knopki izmenenij"
    Private Sub ButtonSdwigPik_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSdwigPik.Click
        Dim lsdwig As Single
        Dim lPikBeginSdwig As Integer
        Try
            lsdwig = CSng(TextBoxSdwig.Text)
        Catch ex As Exception
            MsgBox(Me.Name & " неправильно задана величина сдвига  ")
            Return
        End Try
        Try
            lPikBeginSdwig = CInt(Int(TextBoxBegSdwig.Text))
        Catch ex As Exception
            lPikBeginSdwig = CInt(wPikBeg)
        End Try

        For Each el As DsProfil.ProfilARow In DsProfilA.ProfilA.Rows
            If el.Piketaj >= lPikBeginSdwig Then el.Piketaj += lsdwig
        Next
        OprGraniz()
        For Each el As DsProfil.PikUgodNRow In DsProfilA.PikUgodN.Rows
            If el.Piketaj >= lPikBeginSdwig Then el.Piketaj += lsdwig
        Next
        For Each el As DsProfil.TablKlimNRow In DsProfilA.TablKlimN.Rows
            If el.Piketaj >= lPikBeginSdwig Then el.Piketaj += lsdwig
        Next
        For Each el As dsRasst.rastOpNRow In wdsRasst.rastOpN.Rows
            If el.Piketaj >= lPikBeginSdwig Then el.Piketaj += lsdwig
        Next
        For Each el As dsRasst.MechUslRow In wdsRasst.MechUsl.Rows
            If el.Piketaj >= lPikBeginSdwig Then el.Piketaj += lsdwig
        Next
    End Sub
    Private Sub ButtonObmPrnaLew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonObmPrnaLew.Click
        For Each el As DsProfil.ProfilARow In DsProfilA.ProfilA.Rows
            Dim wr As Single
            If el.IsOtmetkaLwNull And el.IsOtmetkaPrNull Then Continue For
            If el.IsOtmetkaLwNull Then
                wr = el.OtmetkaPr
                el.SetOtmetkaPrNull()
                el.OtmetkaLw = wr
                Continue For
            End If

            If el.IsOtmetkaPrNull Then
                wr = el.OtmetkaLw
                el.SetOtmetkaLwNull()
                el.OtmetkaPr = wr
                Continue For
            End If
            wr = el.OtmetkaLw
            el.OtmetkaLw = el.OtmetkaPr
            el.OtmetkaPr = wr
        Next
    End Sub
    Private Sub ButtonIzmOtm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonIzmOtm.Click
        Dim lIzmOtm As Single
        Try
            lIzmOtm = CSng(TextBoxIzmOtm.Text)
        Catch ex As Exception
            MsgBox(Me.Name & " неправильно задана величина изменения отметок  ")
            Return
        End Try


        For Each el As DsProfil.ProfilARow In DsProfilA.ProfilA.Rows
            el.Otmetka += lIzmOtm
            If Not el.IsOtmetkaPrNull Then el.OtmetkaPr += lIzmOtm
            If Not el.IsOtmetkaLwNull Then el.OtmetkaLw += lIzmOtm
            If Not el.IsParam1Null Then el.Param1 += lIzmOtm
            If Not el.IsParam2Null Then el.Param2 += lIzmOtm
            If Not el.IsParam3Null Then el.Param3 += lIzmOtm
            If Not el.IsParam4Null Then el.Param4 += lIzmOtm
        Next
    End Sub
    Private Sub IzmZon(ByVal tb As DataTable, ByVal lsdwig As Single)
        Dim elPred As DataRow = Nothing
        For Each el As DataRow In tb.Select("", "Piketaj")
            If elPred IsNot Nothing Then
                elPred("Piketaj") = lsdwig - CType(el("Piketaj"), Single)
            End If
            elPred = el
        Next
        elPred("Piketaj") = CSng(wPikBeg)
    End Sub
    Private Sub ButtonInversij_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonInversij.Click
        Dim lsdwig As Single = CSng(wPikBeg + wPikEnd)
        For Each el As DsProfil.ProfilARow In DsProfilA.ProfilA.Rows
            el.Piketaj = lsdwig - el.Piketaj
            If el.IsOtmetkaLwNull Then
                If Not el.IsOtmetkaPrNull Then
                    el.OtmetkaLw = el.OtmetkaPr
                    el.SetOtmetkaPrNull()
                End If
            Else
                If el.IsOtmetkaPrNull Then
                    el.OtmetkaPr = el.OtmetkaLw
                    el.SetOtmetkaLwNull()
                Else
                    Dim wr = el.OtmetkaPr
                    el.OtmetkaPr = el.OtmetkaLw
                    el.OtmetkaLw = wr
                End If
            End If
            If Not el.IsUgolPoworotNull Then
                Dim lpervS As Char = el.UgolPoworot.Chars(0)
                If clsPrf.clsUgolPoworot.ZnakPrawoLewo(el.UgolPoworot) = "Л" Then
                    el.UgolPoworot = el.UgolPoworot.Replace(lpervS, "П")

                Else
                    el.UgolPoworot = el.UgolPoworot.Replace(lpervS, "Л")
                End If
            End If
        Next
        For Each el As dsRasst.rastOpNRow In wdsRasst.rastOpN.Rows
            el.Piketaj = lsdwig - el.Piketaj
        Next
        'пикетаж угодий
        Dim elPikUgodPred As DsProfil.PikUgodNRow = Nothing
        For Each el As DsProfil.PikUgodNRow In DsProfilA.PikUgodN.Select("", "Piketaj")
            If elPikUgodPred IsNot Nothing Then
                elPikUgodPred.Piketaj = lsdwig - el.Piketaj
            End If
            elPikUgodPred = el
        Next
        elPikUgodPred.Piketaj = CSng(wPikBeg)

        'климат
        Dim elTablklimPred As DsProfil.TablKlimNRow = Nothing
        For Each el As DsProfil.TablKlimNRow In DsProfilA.TablKlimN.Select("", "Piketaj")
            If elTablklimPred IsNot Nothing Then
                elTablklimPred.Piketaj = lsdwig - el.Piketaj
            End If
            elTablklimPred = el

        Next
        elTablklimPred.Piketaj = CSng(wPikBeg)
        'mechusl
        IzmZon(wdsRasst.MechUsl, lsdwig)
        DataGridViewProfil.Sort(Piketaj1, System.ComponentModel.ListSortDirection.Ascending)
        DataGridViewPikUgod.Sort(DataGridViewComboBoxPiketaj, System.ComponentModel.ListSortDirection.Ascending)

        KlimatGridView.Sort(PiketajDataGridViewKlimzon, System.ComponentModel.ListSortDirection.Ascending)
    End Sub
#End Region
#End Region
#Region "Klimat"

    Private Sub KlimatGridView_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles KlimatGridView.DataError
        clsPrf.Obrabot(sender, e)
    End Sub




    Private Sub KlimatGridView_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles KlimatGridView.DefaultValuesNeeded
        Dim lKlrow As DsProfil.TablKlimNRow = CType(CType(ClsZonKlimatBindingSource.Current, DataRowView).Row, DsProfil.TablKlimNRow)
        lKlrow.UIdKlim = Guid.NewGuid
        Try
            lKlrow.UIdUch = wIzmUch.UidUch
        Catch ex As Exception
            lKlrow.UIdUch = Guid.Empty
        End Try

        lKlrow.Piketaj = CType(wPikBeg, Single)
        lKlrow.Polz = My.User.Name
        lKlrow.DataW = Now
        ' KlimatGridView.Rows(0).HeaderCell     ' HeaderCell()
    End Sub
#End Region
#Region "PiketUgod"



    Private Sub DataGridViewPikUgod_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridViewPikUgod.DataError
        If e.ColumnIndex = 0 Then
            If DataGridViewComboBoxPiketaj.DataSource Is Nothing Then Return
            '    DataGridViewComboBoxPiketaj.DataSource
            '   Dim lPikUgodrow As DsProfil.PikUgodNRow = CType(CType(PiketUgodBindingSource.Find, DsProfil.PikUgodNRow)
            Dim wr As Double = CDbl(DataGridViewPikUgod.Rows(e.RowIndex).Cells(0).Value)
            MsgBox("DataGridViewPikUgod " & " и " & wr & " не соответствует ни одному пикету " & e.Exception.Message)
            Dim wr1 As Double = CType(DsProfilA.ProfilA.Select("Piketaj > " & CStr(wr))(0), DsProfil.ProfilARow).Piketaj
            DataGridViewPikUgod.Rows(e.RowIndex).Cells(0).Value = wr1 '     CType(CType(DataGridViewComboBoxPiketaj.Items(0), DataRowView).Row, DsProfil.ProfilARow).Piketaj
            '  DataGridViewPikUgod.Rows(e.RowIndex).Cells(0).Value = DataGridViewComboBoxPiketaj.Items(0)
        End If
    End Sub
    Private Sub DataGridViewPikUgod_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles DataGridViewPikUgod.DefaultValuesNeeded
        Dim lPikUgodrow As DsProfil.PikUgodNRow = CType(CType(PiketUgodBindingSource.Current, DataRowView).Row, DsProfil.PikUgodNRow)
        Dim lKlwEl As Integer = PiketUgodBindingSource.Count
        Dim lpikw1 As DsProfil.PikUgodNRow = Nothing
        If lKlwEl >= 2 Then
            lpikw1 = CType(CType(PiketUgodBindingSource.List(PiketUgodBindingSource.Count - 2), DataRowView).Row, DsProfil.PikUgodNRow)
        End If

        Try
            lPikUgodrow.UidUch = wIzmUch.UidUch
        Catch ex As Exception
            lPikUgodrow.UidUch = Guid.Empty
        End Try
        lPikUgodrow.Tip = 0
        Try
            lPikUgodrow.Piketaj = CType(wPikTek, Single)         '
        Catch ex As Exception
            lPikUgodrow.Piketaj = lpikw1.Piketaj
        End Try

        lPikUgodrow.UIdUgod = Guid.NewGuid

    End Sub

    Private Sub DataGridViewPikUgod_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs)
        Dim lPikUgodrow As DsProfil.PikUgodNRow = CType(CType(PiketUgodBindingSource.Current, DataRowView).Row, DsProfil.PikUgodNRow)





    End Sub



#End Region
#Region "Knopki"
    Protected Sub EndEdit()
        DataGridViewProfil.Sort(Piketaj1, System.ComponentModel.ListSortDirection.Ascending)
        DataGridViewProfil.EndEdit()

        KlimatGridView.Sort(PiketajDataGridViewKlimzon, System.ComponentModel.ListSortDirection.Ascending)
        KlimatGridView.EndEdit()
        ClsZonKlimatBindingSource.EndEdit()

        DataGridViewPikUgod.Sort(DataGridViewComboBoxPiketaj, System.ComponentModel.ListSortDirection.Ascending)
        DataGridViewPikUgod.EndEdit()
        ' PiketUgodBindingSource.MoveFirst()
        PiketUgodBindingSource.EndEdit()


    End Sub
    Private Function NumIzmUchastka() As Integer
        Dim wtrassa As clsPrf.clsTrass = IzmUch.Rasst.Trassa
        For i As Integer = 0 To wtrassa.MaxNumUchTr
            If wtrassa.Uchastki(i + 1).Equals(IzmUch) Then Return i
        Next
        Return -1
    End Function
    Private Sub ToolStripButtonAllOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonAllOk.Click


        EndEdit()

        Dim wtrassa As clsPrf.clsTrass = IzmUch.Rasst.Trassa

        wIzmUch.PereschitatPosleKorr()

        wtrassa.Pereschitat()

        wIzmUch.Rasst.OprRast()
        '    MsgBox(" номер уч " & NumIzmUchastka())
        If ToolStripButtonSohrDwg.Checked = False Then Return
        If BazDwg.SystemKommand.NameFileDwg <> wNameDwgload Then
            BazDwg.SystemKommand.Soob(Me.ToString & "Файл чертежа загрузки " & wNameDwgload & " не соответствует файлу чертежа сохранения " & vbCr _
                                         & "Перейдите в чертеж загрузки")
            Return
        End If
        Dim ll As New BazDwg.SystemKommand

        ll.Lock()
        If wOprRej.RejmSowmest Then

			wOprRej.SchreibeTrassWSowmest(IzmUch.Rasst, _Dostup)
        Else
            Dim dnDwg As New LeseSreib.clsLeseSrejbRasstDwg(KorSlDann, IzmUch.Rasst)
            dnDwg.Save()
        End If
        ll.Dispose()

        BazDwg.SystemKommand.Sohr()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
    Private Sub ToolStripButtonSohrDwg_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButtonSohrDwg.Click
        ToolStripButtonSohrDwg.Checked = Not ToolStripButtonSohrDwg.Checked


        If ToolStripButtonSohrDwg.Checked = True Then
            ToolStripButtonSohrDwg.Text = wNameIstochnik
            ToolStripButtonSohrDwg.ForeColor = Color.Black
        Else
            ToolStripButtonSohrDwg.Text = "не " & wNameIstochnik
            ToolStripButtonSohrDwg.ForeColor = Color.Gray
        End If
    End Sub
#End Region





    Private Sub TextBoxSdwig_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSdwig.TextChanged

    End Sub

    Private Sub DataGridViewProfil_CellParsing(sender As Object, e As DataGridViewCellParsingEventArgs) Handles DataGridViewProfil.CellParsing
        'Dim d As Double = clsPrf.Slujba.PreobrStr(e.Value.ToString, 0.0)
        'e.Value = d

        'DataGridViewProfil.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = d
        'Dim dw = DataGridViewProfil.Rows(e.RowIndex).Cells(e.ColumnIndex).FormattedValue
        '' DataGridViewProfil.Rows(e.RowIndex).Cells(e.ColumnIndex).
        'MsgBox("CellParsing " & e.Value.ToString & "  " & dw.ToString)
        'e.ParsingApplied = False
    End Sub

   

  
End Class