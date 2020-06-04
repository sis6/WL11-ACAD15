Option Strict On
Option Explicit On
Imports OperBD
Imports System.Windows.Forms

''' <summary>
''' Форма используеться для корректировки данных участка профиля
''' </summary>
''' <remarks></remarks>
Public Class FrmKorrRasstWlUch

    Private wNameDwgload As String
    Private wOprRej As New LeseSreib.clsSreibeBD
    Private wNameIstochnik As String = "сохранять в чертеже "
    Private wIzmUch As modRasstOp.wlUch

	Private wElemRasstTip As New ElemRasst
	''' <summary>
	'''  Вспогательные переменные: начальный и конечный пикетаж участка, текуший пикет и и средняя отметка участка профиля  
	''' </summary>
	''' <remarks></remarks>
	Private wPikBeg, wPikEnd, wPikTek, wOtmSr As Double
    ''' <summary>
    ''' ДатаСет данных о опорах и проводах используемых на участке
    ''' </summary>
    ''' <remarks></remarks>
    Private wElemRastUch As ElemRasstUch

	Public Property Dostup As OperBD.dostup
	''' <summary>
	''' Форма переводиться в режим просмотра
	''' </summary>
	Sub UstProsmotr()

        With Me
			Me.Text = "Просмотр   данных"
			Me.BackColor = Color.Aqua




            Me.TextBoxNachNum.Visible = False
            .ButtonPerenum.Visible = False





            Me.ToolStripButtonAllOk.Visible = False
			ToolStripButtonSohrDwg.Visible = False


			For Each cntr As Control In .Controls
				If TypeOf cntr Is TabControl Then
					'		MsgBox(Me.ToString & " " & cntr.Name)
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
        OporBindingSource.DataSource = ElemRasstUch1
        OporBindingSource.DataMember = "oporiUch"
        ProvodaBindingSource.DataSource = ElemRasstUch1
        ProvodaBindingSource.DataMember = "prowodaUch"
        GirlajndBindingSource.DataSource = ElemRasstUch1
        GirlajndBindingSource.DataMember = "Girjlanduch"
        DataGridViewProfil.DataSource = DsProfilA
        DataGridViewProfil.DataMember = "ProfilA"
        PiketUgodBindingSource.DataSource = DsProfilA
        PiketUgodBindingSource.DataMember = "PikUgodN"
        Me.ClsZonKlimatBindingSource.DataMember = "TablKlimN"
        Me.ClsZonKlimatBindingSource.DataSource = Me.DsProfilA
        ClszonMechuslBindingSource.DataSource = DsRasst1
        RastOpNBindingSource.DataSource = DsRasst1
        WlDefParamBindingSource.DataSource = DsRasst1
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
    Property IzmUch() As modRasstOp.wlUch

        Get
            Return wIzmUch
        End Get
        Set(ByVal Iizmuch As modRasstOp.wlUch)
            wIzmUch = Iizmuch

            DsProfilA = wIzmUch.dsProfil
            DsRasst1 = wIzmUch.DsRasst
            ElemRasstUch1 = wIzmUch.DannElemRasstUch.DataSet
            '  MsgBox("IzmUch " & ElemRasstUch1.oporIUch.Count & " Пик " & DsProfilA.ProfilA.Count)
            wInit()
            NameFileUch.Text = wIzmUch.NameUch
        End Set
    End Property



	Private Sub FrmKorr_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TabControl1.SelectedTab = Rasstanowka
		wOprRej = New LeseSreib.clsSreibeBD

		If wOprRej.RejmSowmest Then
			If Not (Dostup.Prawo = PrawoDostup.PolzOve OrElse Dostup.Prawo = PrawoDostup.Admin) Then UstProsmotr()
		End If

		wNameDwgload = BazDwg.SystemKommand.NameFileDwg
        If Me.wOprRej.RejmSowmest = True Then wNameIstochnik = "сохранять в базе данных "
        ToolStripButtonSohrDwg.Text = "Не " & wNameIstochnik
        HelpProvider1.SetHelpNavigator(Me, HelpNavigator.Topic)
        '  MsgBox("iiiii " & lBasePapka & "\DANN\tipsoor.xml")
        If DsProfilA.TipSoor.Rows.Count = 0 Then
            DsProfilA.TipSoor.ReadXml(My.Settings.BasePapka & "\DANN\tipsoor.xml")
            '    MsgBox("lll;; " & lBasePapka)
            DsProfilA.TipUgod.ReadXml(My.Settings.BasePapka & "\DANN\tipugod.xml")
            DsProfilA.TipMest.ReadXml(My.Settings.BasePapka & "\DANN\tipmest.xml")
            '   MsgBox(";;;; " & lBasePapka)
            DsProfilA.TipSoor.AcceptChanges()
            DsProfilA.TipUgod.AcceptChanges()
            DsProfilA.TipMest.AcceptChanges()
        End If

        wElemRasstTip = New Sw_TipElem().ElemRasstTip


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
        With TipiDataGridViewOporUchColumn ' "OporUch
            .DataSource = wElemRasstTip.TipOp
            .ValueMember = "NumOp"
            .DisplayMember = "NameOp"
        End With
        With TipDataGridViewOpRasstColumn ' "RasstOp
            .DataSource = wElemRasstTip.TipOp
            .ValueMember = "NumOp"
            .DisplayMember = "NameOp"
        End With
        If ElemRasstUch1 IsNot Nothing Then
            wElemRastUch = New ElemRasstUch
            ' wElemRastUch = CType(ElemRasstUch1.Copy, ElemRasstUch)
            '  Dim lGuid As Guid = CType(ElemRasstUch1.Girjlanduch.Rows(0), ElemRasstUch.GirjlanduchRow).UidUch
            wElemRastUch.Girjlanduch.AddGirjlanduchRow(wIzmUch.UidUch, "", "uni", CSng(wIzmUch.DefParam.Girl.DlGirl), CSng(wIzmUch.DefParam.Girl.MassGirl), 100, Now(), "для нуля", 1, 0)
            wElemRastUch.Girjlanduch.Merge(ElemRasstUch1.Girjlanduch.Copy)
            wElemRastUch.oporIUch.Merge(ElemRasstUch1.oporIUch.Copy)
            wElemRastUch.prowodaUch.Merge(ElemRasstUch1.prowodaUch.Copy)
            With NameTipOpor
                .DataSource = wElemRastUch.oporIUch
                .ValueMember = "UserTipOp"
                .DisplayMember = "UserTipOp"
            End With
            With TipopADataGridViewTextBoxColumn ' ParamUch
                .DataSource = wElemRastUch.oporIUch.Select("Tip_i > 0")
                .ValueMember = "UserTipOp"
                .DisplayMember = "UserTipOp"
            End With
            With TipopPDataGridViewTextBoxColumn
                .DataSource = wElemRastUch.oporIUch.Select("Tip_i = 0")
                .ValueMember = "UserTipOp"
                .DisplayMember = "UserTipOp"
            End With
            With NamemarkTDataGridViewParamUch
                .DataSource = wElemRastUch.prowodaUch
                .ValueMember = "UserMark"
                .DisplayMember = "UserMark"
            End With
            With NamemarkDataGridViewParamUch
                .DataSource = wElemRastUch.prowodaUch
                .ValueMember = "UserMark"
                .DisplayMember = "UserMark"
            End With
            With Name_markW
                .DataSource = wElemRastUch.prowodaUch
                .ValueMember = "UserMark"
                .DisplayMember = "UserMark"
            End With
            With TipopDataGridViewTextBoxColumn  ' mechUsl
                .DataSource = wElemRastUch.oporIUch.Select("Tip_i = 0")
                .ValueMember = "UserTipOp"
                .DisplayMember = "UserTipOp"
            End With
            With NamemarkDataGridViewTextBoxColumn
                .DataSource = wElemRastUch.prowodaUch
                .ValueMember = "UserMark"
                .DisplayMember = "UserMark"
            End With
            With NamemarkTDataGridViewTextBoxColumn
                .DataSource = wElemRastUch.prowodaUch
                .ValueMember = "UserMark"
                .DisplayMember = "UserMark"
            End With
            With nameGirl
                .DataSource = wElemRastUch.Girjlanduch
                .ValueMember = "NameG"
                .DisplayMember = "NameG"
            End With
            With NameGirlT
                .DataSource = wElemRastUch.Girjlanduch
                .ValueMember = "NameG"
                .DisplayMember = "NameG"
            End With

        End If


        '     MsgBox("Bindung1  " & OporBindingSource.DataSource.ToString & " М  " & OporBindingSource.DataMember)
        'Заголовки столбцов проводов
        Me.UserMarkDataGridViewTextBoxColumn.HeaderText = "Марка провода"

        Me.TipP.HeaderText = "Тип пров."
        Me.Sprwd.HeaderText = "Сечен. ,мм²"
        Me.DiamPrwd.HeaderText = "Диам. ,мм"
        Me.Ppogon.HeaderText = "Масса пог.кг/м"
        Me.SigMax.HeaderText = "σMax"
        Me.Alfa.HeaderText = "α, 10E-6/˚"
        Me.Jung.HeaderText = "Юнг,ГПа(Н/мм² 10E3)"
        Me.SigGol.HeaderText = "σ,гол. Н/мм²"
        Me.SigSrG.HeaderText = "σ,ср. год. Н/мм²"
        Me.Tekpl.HeaderText = "Тэксп,˚"
        Me.ModF.HeaderText = "F,ГПа(Н/мм² 10E3)"
        Me.ModD.HeaderText = "D,ГПа(Н/мм² 10E3)"
        HelpProvider1.HelpNamespace = My.Settings.BasePapka & "\Help\Form\FrmKorrRasstWlUch.htm"
    End Sub
#End Region
   
#Region "DataGriDViewProfil"
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


            If CInt(w.Value) = 0 And String.IsNullOrEmpty(w1.Value.ToString) Then w.Value = DBNull.Value
        End If
        ' wBuf.ZapisatCellDataGrid(DataGridViewProfil, e.RowIndex, e.ColumnIndex)

    End Sub
    Private Sub DataGridViewProfil_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles DataGridViewProfil.UserDeletedRow
        OprGraniz()

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

#End Region
#Region "Klimat"
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


        'If DataGridViewPikUgod.CurrentCell.ColumnIndex = 0 Then
        '    'ComboBoxPik.Visible = True пример как комбобох перекрывает ячейку ввода

        '    'ComboBoxPik.Parent = e.Control.Parent
        '    'ComboBoxPik.Bounds = e.Control.Bounds
        '    'If lPikUgodrow IsNot Nothing Then
        '    '    ComboBoxPik.Text = CStr(lPikUgodrow.Piketaj)
        '    'Else
        '    '    ComboBoxPik.SelectedIndex = 0
        '    'End If

        '    'ComboBoxPik.Focus()

        '    'If ComboBoxPik.SelectedIndex < 0 Then ComboBoxPik.Text = CStr(lPikUgodrow.Piketaj)
        'End If


    End Sub



#End Region
#Region "RastOpDataGridView"
    Private Sub ButtonPerenum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPerenum.Click
        Dim lnewnum As Integer
        Dim lNaprPerenum As Integer = 1
        If CheckBoxNapr.Checked Then lNaprPerenum = -1
        Try
            lnewnum = CInt(TextBoxNachNum.Text)
        Catch ex As Exception
            MsgBox(Me.Name & " неправильно задан начальный номер  ")
            Return
        End Try
        Dim I As Integer = lnewnum
        For Each el As dsRasst.rastOpNRow In DsRasst1.rastOpN.Select("", "Piketaj")
            Dim lnumname As String = CStr(I)

            ' lnumname = IzmUch.DopustimoeImj(lnumname)
            el.NumName = lnumname
            I += lNaprPerenum
        Next


    End Sub
    Private Sub ButtonSuffix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSuffix.Click
        Dim lsuffix As String = TextBoxSuffiks.Text
        For Each el As dsRasst.rastOpNRow In DsRasst1.rastOpN.Rows
            el.NumName &= lsuffix

        Next
    End Sub


    Private Sub RastOpDataGridView_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles RastOpDataGridView.CellEndEdit
        Dim lRastOprow As dsRasst.rastOpNRow = CType(CType(RastOpNBindingSource.Current, DataRowView).Row, dsRasst.rastOpNRow)
        'MsgBox("RastOpDataGridView_CellEndEdit " & lRastOprow.Piketaj)
        lRastOprow.Polz = My.User.Name
        lRastOprow.DataI = Now()
        RastOpDataGridView.EndEdit()

    End Sub

    Private Sub RastOpDataGridView_ColumnSortModeChanged(sender As Object, e As DataGridViewColumnEventArgs) Handles RastOpDataGridView.ColumnSortModeChanged

    End Sub

	Private Sub RastOpDataGridView_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles RastOpDataGridView.DataError
		If e.ColumnIndex = 3 Then
			'RastOpDataGridView.CurrentRow.Cells(e.ColumnIndex).Value = "DefProw"
			e.Cancel = True
		Else
			clsPrf.Obrabot(sender, e)
		End If


		'RastOpDataGridView.CurrentRow.Cells(e.ColumnIndex).Value = "u"
		'	MsgBox(Me.ToString() & "  " & e.ColumnIndex)




	End Sub
	Private Sub RastOpDataGridView_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles RastOpDataGridView.DefaultValuesNeeded
        Dim lRastOprow As dsRasst.rastOpNRow = CType(CType(RastOpNBindingSource.Current, DataRowView).Row, dsRasst.rastOpNRow)
        'If e.Row.Index = 0 Then
        '    '   MsgBox(Me.ToString & "  RastOpDataGridView_DefaultValuesNeeded  " & RastOpNBindingSource.Count & " " & RastOpDataGridView.RowCount)
        '    MsgBox(Me.ToString & " " & e.ToString & " DefaultValuesNeeded  Bin " & RastOpNBindingSource.Count & " View" & RastOpDataGridView.RowCount)

        'End If

        lRastOprow.UIdRast = Guid.NewGuid
        Try
            lRastOprow.UIdUch = wIzmUch.UidUch
        Catch ex As Exception
            lRastOprow.UIdUch = Guid.Empty
        End Try
        With lRastOprow

            .Polz = My.User.Name
            .DataI = Now
            If e.Row.Index = 0 Then
                .Tip = 1
                .Piketaj = CSng(wPikBeg)
                .NumName = "1"
            Else
                .Tip = 0
                .Piketaj = CSng(wPikEnd)
                .NumName = "*"
            End If

        End With

    End Sub



#End Region
#Region "MechUsl"

    Private Sub MechUslDataGridView_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles MechUslDataGridView.CellEndEdit
        Dim lMechUslrow As dsRasst.MechUslRow = CType(CType(ClszonMechuslBindingSource.Current, DataRowView).Row, dsRasst.MechUslRow)
        ' MsgBox("CellendEdit" & e.RowIndex)
        lMechUslrow.Polz = My.User.Name
        lMechUslrow.DataI = Now
    End Sub

    Private Sub MechUslDataGridView_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles MechUslDataGridView.DataError
		If e.ColumnIndex <> 1 Then
			clsPrf.Obrabot(sender, e)
		End If


	End Sub
    Private Sub MechUslDataGridView_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles MechUslDataGridView.DefaultValuesNeeded
        Dim lMechUslrow As dsRasst.MechUslRow = CType(CType(ClszonMechuslBindingSource.Current, DataRowView).Row, dsRasst.MechUslRow)
        lMechUslrow.UIndtaj = Guid.NewGuid
        Try
            lMechUslrow.UidUch = wIzmUch.UidUch
        Catch ex As Exception
            lMechUslrow.UidUch = Guid.Empty
        End Try
        With lMechUslrow
            .Piketaj = CSng(wPikTek)
            .Sig1_Texsp = 100
            .Sig1_Tmin = 120
            .Sig7_Tgol = 120
            .Sig7_TgolT = 200
            .ProwodFaz = wIzmUch.DefProvodowfaz
            .Sig1_TexspT = 180
            .Sig1_TexspW = 100
            .Sig7_TgolW = 200
            .Gabarit = 6.5
            .Polz = My.User.Name
            .DataI = Now
        End With

    End Sub
#End Region
    Private Sub Rasstanowka_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rasstanowka.Enter
        If ElemRasstUch1 IsNot Nothing Then
            wElemRastUch = CType(ElemRasstUch1.Copy, ElemRasstUch)
            With NameTipOpor
                .DataSource = wElemRastUch.oporIUch
                .ValueMember = "UserTipOp"
                .DisplayMember = "UserTipOp"
            End With
            With TipopADataGridViewTextBoxColumn ' ParamUch
                .DataSource = wElemRastUch.oporIUch.Select("Tip_i > 0")
                .ValueMember = "UserTipOp"
                .DisplayMember = "UserTipOp"
            End With
            With TipopPDataGridViewTextBoxColumn
                .DataSource = wElemRastUch.oporIUch.Select("Tip_i = 0")
                .ValueMember = "UserTipOp"
                .DisplayMember = "UserTipOp"
            End With
            With NamemarkTDataGridViewParamUch
                .DataSource = wElemRastUch.prowodaUch
                .ValueMember = "UserMark"
                .DisplayMember = "UserMark"
            End With
            With NamemarkDataGridViewParamUch
                .DataSource = wElemRastUch.prowodaUch
                .ValueMember = "UserMark"
                .DisplayMember = "UserMark"
            End With
            With Name_markW
                .DataSource = wElemRastUch.prowodaUch
                .ValueMember = "UserMark"
                .DisplayMember = "UserMark"
            End With
            With TipopDataGridViewTextBoxColumn  ' mechUsl
                .DataSource = wElemRastUch.oporIUch.Select("Tip_i = 0")
                .ValueMember = "UserTipOp"
                .DisplayMember = "UserTipOp"
            End With
            With NamemarkDataGridViewTextBoxColumn
                .DataSource = wElemRastUch.prowodaUch
                .ValueMember = "UserMark"
                .DisplayMember = "UserMark"
            End With
            With NamemarkTDataGridViewTextBoxColumn
                .DataSource = wElemRastUch.prowodaUch
                .ValueMember = "UserMark"
                .DisplayMember = "UserMark"
            End With
            With nameGirl
                .DataSource = wElemRastUch.Girjlanduch
                .ValueMember = "NameG"
                .DisplayMember = "NameG"
            End With
            With NameGirlT
                .DataSource = wElemRastUch.Girjlanduch
                .ValueMember = "NameG"
                .DisplayMember = "NameG"
            End With

        End If
    End Sub
#Region "Element"


#Region "орорi"

    Private Function ProvOpor(ByVal ShifrOp As String) As Integer
        Dim lKlw = DsRasst1.rastOpN.Select("Tip_op = '" & ShifrOp & "'").Length
        lKlw += DsRasst1.MechUsl.Select("Tip_op = '" & ShifrOp & "'").Length
        Dim lwrwParam = CType(DsRasst1.ParamUchN.Rows(0), dsRasst.ParamUchNRow)
        If lwrwParam.Tip_opA = ShifrOp Then lKlw += 1
        If lwrwParam.Tip_opP = ShifrOp Then lKlw += 1
        Return lKlw
    End Function
    Private Sub IzmenitShifrOpor(ByVal ShifrOp As String, ByVal ShifrOpNew As String)
        Dim lRowRast() As dsRasst.rastOpNRow = CType(DsRasst1.rastOpN.Select("Tip_op = '" & ShifrOp & "'"), dsRasst.rastOpNRow())
        For Each el As dsRasst.rastOpNRow In lRowRast
            el.Tip_op = ShifrOpNew
        Next
        Dim lRowMechusl() As dsRasst.MechUslRow = CType(DsRasst1.MechUsl.Select("Tip_op = '" & ShifrOp & "'"), dsRasst.MechUslRow())
        For Each el As dsRasst.MechUslRow In lRowMechusl
            el.Tip_op = ShifrOpNew
        Next
        Dim lwrwParam = CType(DsRasst1.ParamUchN.Rows(0), dsRasst.ParamUchNRow)
        If lwrwParam.Tip_opA = ShifrOp Then lwrwParam.Tip_opA = ShifrOpNew
        If lwrwParam.Tip_opP = ShifrOp Then lwrwParam.Tip_opP = ShifrOpNew
    End Sub
    Private Sub OporDataGridView_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles OporDataGridView.DataError
        clsPrf.Obrabot(sender, e)
    End Sub

    Private Sub OporDataGridView_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles OporDataGridView.CellEndEdit
        OporDataGridView.Rows(e.RowIndex).ErrorText = String.Empty
        Dim lOporrow As ElemRasstUch.oporIUchRow = CType(CType(OporBindingSource.Current, DataRowView).Row, ElemRasstUch.oporIUchRow)
        lOporrow.Polz = My.User.Name
        lOporrow.DataI = Now
    End Sub
    Private Sub OporDataGridView_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles OporDataGridView.CellValidating
        If OporDataGridView.Rows(e.RowIndex).IsNewRow Then Return

        If OporDataGridView.Columns(e.ColumnIndex).Name = "UserTipOpDataGridViewTextBoxColumn" Then
            Dim lcell As DataGridViewCell = OporDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex)
            If CStr(lcell.Value) <> CStr(e.FormattedValue) Then

                If ProvOpor(CStr(lcell.Value)) = 0 Then Return
                If MsgBox("На шифр " & CStr(lcell.Value) & "  есть ссылки в модели расстановки." & vbCr & _
                          " <OK> - изменить ссылки на " & CStr(e.FormattedValue), MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    IzmenitShifrOpor(CStr(lcell.Value), CStr(e.FormattedValue))
                Else
                    e.Cancel = True
					OporDataGridView.EditingControl.Text = lcell.Value.ToString
					' OporDataGridView.Rows(e.RowIndex).
					'   OporDataGridView.Rows(e.RowIndex).ErrorText = "Не допустимо изменять шифр опоры   " & CStr(lcell.Value)
					'  OporDataGridView.Rows(e.RowIndex).ErrorText
					'  OporDataGridView.EndEdit()
				End If


            End If
        End If
    End Sub
    Private Sub OporDataGridView_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles OporDataGridView.UserDeletingRow
        Dim lcell As DataGridViewCell = e.Row.Cells("UserTipOpDataGridViewTextBoxColumn")
        If ProvOpor(CStr(lcell.Value)) = 0 Then Return


        e.Cancel = True

        e.Row.ErrorText = "Не допустимо удалять строку с  шифром опоры   " & CStr(lcell.Value)
    End Sub
    Private Sub OporDataGridView_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles OporDataGridView.DefaultValuesNeeded
        Dim lOporrow As ElemRasstUch.oporIUchRow = CType(CType(OporBindingSource.Current, DataRowView).Row, ElemRasstUch.oporIUchRow)
        Dim lfrm As New modRasstOp.FrmTipElemOpori
        Dim loporT As ElemRasst.oporiRow = Nothing
        lfrm.ElemRasstTip = wElemRasstTip
        If lfrm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            loporT = lfrm.Opor
        Else
            'Try
            '    loporT = CType(wElemRasstTip.opori.Select("IdUnom = " & wIzmUch.Unom)(0), ElemRasst.oporiRow)
            'Catch ex As Exception
            '    loporT = Nothing
            'End Try
            CType(OporBindingSource.Current, DataRowView).Delete()
            Return
        End If
        Try
            lOporrow.UidUch = wIzmUch.UidUch
        Catch ex As Exception
            lOporrow.UidUch = Guid.Empty
        End Try
        If loporT Is Nothing Then
            With lOporrow
                .UserTipOp = "nowOp"
                .Wis_op = 20
                .Wis_op1 = 25
                .Wis_op2 = 25
                .Wis_opT = 30
                .Polz = My.User.Name
                .DataI = Now
                .Tip_i = 0
                .Winos = 0
                .Winos1 = 0
                .Winos2 = 0
                .WinosT = 0
                .Zepn = 1
            End With
        Else
            With lOporrow
                .UserTipOp = loporT.Tip_op
                .Wis_op = loporT.Wis_op
                Try
                    .Wis_op1 = loporT.Wis_op1
                Catch ex As Exception
                    .Wis_op1 = .Wis_op
                End Try
                Try
                    .Wis_op2 = loporT.Wis_op2
                Catch ex As Exception
                    .Wis_op2 = .Wis_op1
                End Try
                Try
                    .Wis_opT = loporT.Wis_opT
                Catch ex As Exception
                    .Wis_opT = .Wis_op2
                End Try
                Try
                    .Winos = loporT.Winos
                Catch ex As Exception
                    .Winos = 0
                End Try
                Try
                    .Winos1 = loporT.Winos1
                Catch ex As Exception
                    .Winos1 = .Winos
                End Try

                Try
                    .Winos2 = loporT.Winos2
                Catch ex As Exception
                    .Winos2 = .Winos1
                End Try
                Try
                    .WinosT = loporT.WinosT
                Catch ex As Exception
                    .WinosT = .Winos2
                End Try
                .Tip_i = loporT.Tip_i

                Try
                    .Zepn = loporT.Zepn
                Catch ex As Exception
                    .Zepn = 1
                End Try



                .Polz = My.User.Name
                .DataI = Now

            End With
        End If
        Try
            OporBindingSource.EndEdit()
        Catch ex As System.Data.ConstraintException
            If MsgBox("Добавить с дополненным именем", MsgBoxStyle.OkCancel, ex.Message) = MsgBoxResult.Ok Then
                lOporrow.UserTipOp &= "dd"
                OporBindingSource.EndEdit()
            Else
                OporBindingSource.CancelEdit()
            End If

            Exit Try
        Catch ex As Exception
            MsgBox("Объект  " & loporT.Tip_op & " не удалось добавить " & ex.GetType.ToString & ex.Message)
            OporBindingSource.CancelEdit()
        End Try


    End Sub
#End Region
#Region "prowoda"
    Private Function ProvProvod(ByVal MarkaPr As String) As Integer
        Dim lKlw = DsRasst1.MechUsl.Select("Name_mark = '" & MarkaPr & "' or Name_markT = '" & MarkaPr & "' or Name_markW = '" & MarkaPr & "'").Length
        Dim lwrwParam = CType(DsRasst1.ParamUchN.Rows(0), dsRasst.ParamUchNRow)
        If lwrwParam.Name_mark = MarkaPr Then lKlw += 1
        If lwrwParam.Name_markT = MarkaPr Then lKlw += 1
        Return lKlw
    End Function
    Private Sub IzmenitShifrProvoda(ShifrProvod As String, ShifrProwodNew As String)
        Dim lrowmechUslPr() As dsRasst.MechUslRow = CType(DsRasst1.MechUsl.Select("Name_mark = '" & ShifrProvod & "'"), dsRasst.MechUslRow())
        For Each el As dsRasst.MechUslRow In lrowmechUslPr
            el.Name_mark = ShifrProwodNew
        Next
        Dim lrowmechUslTr() As dsRasst.MechUslRow = CType(DsRasst1.MechUsl.Select("Name_markT = '" & ShifrProvod & "'"), dsRasst.MechUslRow())
        For Each el As dsRasst.MechUslRow In lrowmechUslTr
            el.Name_markT = ShifrProwodNew
        Next
        Dim lrowmechUslW() As dsRasst.MechUslRow = CType(DsRasst1.MechUsl.Select("Name_markW = '" & ShifrProvod & "'"), dsRasst.MechUslRow())
        For Each el As dsRasst.MechUslRow In lrowmechUslW
            el.Name_markW = ShifrProwodNew
        Next
        Dim lwrwParam = CType(DsRasst1.ParamUchN.Rows(0), dsRasst.ParamUchNRow)
        If lwrwParam.Name_mark = ShifrProvod Then lwrwParam.Name_mark = ShifrProwodNew
        If lwrwParam.Name_markT = ShifrProvod Then lwrwParam.Name_markT = ShifrProwodNew
    End Sub



    Private Sub ProvodaDataGridView_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles ProvodaDataGridView.DataError
        clsPrf.Obrabot(sender, e)
    End Sub
    Private Sub ProvodaDataGridView_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ProvodaDataGridView.CellEndEdit
        ProvodaDataGridView.Rows(e.RowIndex).ErrorText = String.Empty
        Dim lprovrow As ElemRasstUch.prowodaUchRow = CType(CType(ProvodaBindingSource.Current, DataRowView).Row, ElemRasstUch.prowodaUchRow)
        lprovrow.Polz = My.User.Name
        lprovrow.DataI = Now
    End Sub
    Private Sub ProvodaDataGridView_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles ProvodaDataGridView.CellValidating
        If ProvodaDataGridView.Rows(e.RowIndex).IsNewRow Then Return


        If ProvodaDataGridView.Columns(e.ColumnIndex).Name = "UserMarkDataGridViewTextBoxColumn" Then
            Dim lcell As DataGridViewCell = ProvodaDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex)
            Dim lUserMark As String = CStr(lcell.Value)
            If lUserMark <> CStr(e.FormattedValue) Then

                If ProvProvod(lUserMark) = 0 Then Return
				If MsgBox("На шифр " & CStr(lcell.Value) & "  есть ссылки в модели расстановки." & vbCr &
						 " <OK> - изменить ссылки на " & CStr(e.FormattedValue), MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
					IzmenitShifrProvoda(CStr(lcell.Value), CStr(e.FormattedValue))
				Else
					ProvodaDataGridView.EditingControl.Text = lUserMark
					'	ProvodaDataGridView.EditingControl.
					'lcell.e
					e.Cancel = True
					'	ProvodaDataGridView.e

				End If
                '  ProvodaDataGridView.Rows(e.RowIndex).ErrorText = "Не допустимо изменять марку провода   " & lUserMark

            End If
        End If
    End Sub
    Private Sub ProvodaDataGridView_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles ProvodaDataGridView.DefaultValuesNeeded
        Dim lprovrow As ElemRasstUch.prowodaUchRow = CType(CType(ProvodaBindingSource.Current, DataRowView).Row, ElemRasstUch.prowodaUchRow)
        Dim lelpr As ElemRasst.prowodaRow = Nothing
        Try
            lprovrow.UidUch = wIzmUch.UidUch
        Catch ex As Exception
            lprovrow.UidUch = Guid.Empty
        End Try
        Dim lfrm As New modRasstOp.frmTipElemProvod
        lfrm.ElemRasstTip = wElemRasstTip

        If lfrm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            lelpr = lfrm.Provod
            If lelpr Is Nothing Then lelpr = wElemRasstTip.prowoda(1)
        Else
            '
            CType(ProvodaBindingSource.Current, DataRowView).Delete()
            Return

        End If

        With lprovrow
            .Alfa = lelpr.Alfa
            .DiamPrwd = lelpr.DiamPrwd
            .Sprwd = lelpr.Sprwd
            .Ppogon = lelpr.Ppogon
            .SigGol = lelpr.SigGol
            .SigSrG = lelpr.SigSrG
            .Jung = lelpr.Jung
            .ModD = lelpr.ModD
            .ModF = lelpr.ModF
            .UserMark = lelpr.Name_mark
            .TipP = lelpr.TipP
            .SigMax = lelpr.SigMax
            .Tekpl = lelpr.Tekpl



        End With
        Try
            ProvodaBindingSource.EndEdit()
        Catch ex As System.Data.ConstraintException
            If MsgBox("Добавить с дополненным именем", MsgBoxStyle.OkCancel, ex.Message) = MsgBoxResult.Ok Then
                lprovrow.UserMark &= "dd"
                ProvodaBindingSource.EndEdit()
            Else
                ProvodaBindingSource.CancelEdit()
            End If

            Exit Try
        Catch ex As Exception
            MsgBox("Объект  " & lelpr.Name_mark & " не удалось добавить " & ex.GetType.ToString & ex.Message)
            ProvodaBindingSource.CancelEdit()
        End Try

    End Sub
    Private Sub ProvodaDataGridView_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles ProvodaDataGridView.UserDeletingRow
        Dim lcell As DataGridViewCell = e.Row.Cells("UserMarkDataGridViewTextBoxColumn")
        If ProvProvod(CStr(lcell.Value)) = 0 Then

            Return
        End If

        e.Cancel = True

        e.Row.ErrorText = "Не допустимо удалять строку с  маркой провода   " & CStr(lcell.Value)
    End Sub
#End Region
#Region "Girlajnd"


    Private Sub GirlajndDataGridView_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GirlajndDataGridView.CellEndEdit
        GirlajndDataGridView.Rows(e.RowIndex).ErrorText = String.Empty
    End Sub
    Private Sub GirlajndDataGridView_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GirlajndDataGridView.CellValidating
        If GirlajndDataGridView.Rows(e.RowIndex).IsNewRow Then Return
        If GirlajndDataGridView.Columns(e.ColumnIndex).Name = "NameGDataGridViewTextBoxColumn" Then
            Dim lcell As DataGridViewCell = GirlajndDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex)
            Dim lnameGirl = CStr(lcell.Value)
            If lnameGirl = "nowGirl" Then Return
            If lnameGirl <> CStr(e.FormattedValue) Then
                Dim lwdr() As DataRow = DsRasst1.rastOpN.Select("NameGirl = " & "'" & lnameGirl & "' or NameGirlT= " & "'" & lnameGirl & "'")

                If lwdr.Length = 0 Then Return
                e.Cancel = True
                GirlajndDataGridView.Rows(e.RowIndex).ErrorText = "Не допустимо менять имя гирлянды " & lnameGirl
            End If

        End If

    End Sub

    Private Sub GirlajndDataGridView_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles GirlajndDataGridView.DataError
        clsPrf.Obrabot(sender, e)
    End Sub
    Private Sub GirlajndDataGridView_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles GirlajndDataGridView.DefaultValuesNeeded
        Dim lGirlandrow As ElemRasstUch.GirjlanduchRow = CType(CType(GirlajndBindingSource.Current, DataRowView).Row, ElemRasstUch.GirjlanduchRow)

        Try
            lGirlandrow.UidUch = wIzmUch.UidUch
        Catch ex As Exception
            lGirlandrow.UidUch = Guid.Empty
        End Try
        With lGirlandrow
            .NameG = "nowGirl"

            .Polz = My.User.Name
            .DataI = Now
            .Tip = "pr"
            .MassGirl = 100
            .DlGirl = 1
            .Zepnost = wIzmUch.DefProvodowfaz
            .Ssech = 1
        End With


    End Sub
    Private Sub GirlajndDataGridView_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles GirlajndDataGridView.UserDeletingRow
        Dim lcell As DataGridViewCell = e.Row.Cells("NameGDataGridViewTextBoxColumn")
        Dim lwdr() As DataRow = DsRasst1.rastOpN.Select("NameGirl = " & "'" & CStr(lcell.Value) & "' or NameGirlT= " & "'" & CStr(lcell.Value) & "'")

        If lwdr.Length = 0 Then Return
        e.Cancel = True
        e.Row.ErrorText = "Не допустимо удалять строку с именем гирлянды " & CStr(lcell.Value)
    End Sub
#End Region
#End Region
#Region "Knopki"

    Protected Sub EndEdit()

        If RastOpNBindingSource.Count > 1 Then
            RastOpDataGridView.Sort(PiketajDataGridViewRasstOp, System.ComponentModel.ListSortDirection.Ascending) 'чтобы при сортировки не добавлялась умалчиваемая опора.
        End If

        RastOpDataGridView.EndEdit()
        RastOpNBindingSource.EndEdit()

        DataGridView2.EndEdit()
        WlDefParamBindingSource.EndEdit()

        MechUslDataGridView.Sort(PiketajMechusl, System.ComponentModel.ListSortDirection.Ascending)
        MechUslDataGridView.EndEdit()
        ClszonMechuslBindingSource.EndEdit()


        OporDataGridView.EndEdit()
        OporBindingSource.EndEdit()

        ProvodaDataGridView.EndEdit()
        ProvodaBindingSource.EndEdit()

        GirlajndDataGridView.EndEdit()
        GirlajndBindingSource.EndEdit()
    End Sub
    Private Sub ToolStripButtonAllOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonAllOk.Click
        '   MsgBox(sender.ToString & " AllOk  Bin " & RastOpNBindingSource.Count & " View" & RastOpDataGridView.RowCount)
        If RastOpNBindingSource.Count = 1 Then RastOpNBindingSource.CancelEdit()
        EndEdit()
        If wIzmUch.DsRasst.rastOpN.Count > 0 Then
            Dim ldanns() As dsRasst.rastOpNRow = CType(wIzmUch.DsRasst.rastOpN.Select("", "Piketaj DESC"), dsRasst.rastOpNRow())
            If ldanns.Length > 0 Then
                Dim lDannOp As dsRasst.rastOpNRow = ldanns(0)
                Dim ldannPervOp As dsRasst.rastOpNRow = ldanns(ldanns.Length - 1)

                Dim lsoob As String = ""
                If ldanns.Length = 1 Then lsoob = " меньше 2  опор "
                If ldannPervOp.Tip = 0 Then lsoob = Me.ToString & "Участок " & wIzmUch.NameUch & " первая опора " & ldannPervOp.NumName & " не анкерная " & vbCr
                If lDannOp.Tip = 0 Then lsoob &= "  Последняя опора " & lDannOp.NumName & " Не Анкерная "

                If lsoob <> "" Then MsgBox(Me.ToString & "  Участок " & wIzmUch.NameUch & lsoob)
            End If

        End If

        'End If
        wIzmUch.PereschitatPosleKorrRasst()
        '      If wNumActiwUch < 0 Then wIzmUch.Rasst.OprRast() Else wIzmUch.Rasst.OprRast(wNumActiwUch)
        If ToolStripButtonSohrDwg.Checked Then
            If BazDwg.SystemKommand.NameFileDwg <> wNameDwgload Then
                BazDwg.SystemKommand.Soob(Me.ToString & "Файл чертежа загрузки " & wNameDwgload & " не соответствует файлу чертежа сохранения " & vbCr _
                                             & "Перейдите в чертеж загрузки")
                Return
            End If
            Dim ll As New BazDwg.SystemKommand
            ll.Lock()
            If wOprRej.RejmSowmest Then
                '   Dim dljazapisiBD As New LeseSreib.clsLeseSreibeRasstBd(wOprRej.MassGuid)
                wOprRej.SchreibeRasstWSowmest(IzmUch.Rasst, _Dostup)

            Else
                Dim dnDwg As New LeseSreib.clsLeseSrejbRasstDwg(KorSlDann, IzmUch.Rasst)
                dnDwg.Save()
            End If
            ll.Dispose()
			If Not IzmUch.PrIzm(False) Then BazDwg.SystemKommand.Sohr()
		End If

        If Not Me.Modal Then wIzmUch.Rasst.OprRast()
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

    Private Sub ToolStripMenuItemCop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemCop.Click
        '  Dim lGr As DataGridView = CType(Me.ActiveControl, DataGridView)
        If TypeOf (Me.ActiveControl) Is DataGridViewComboBoxEditingControl Then
            Dim lGr As DataGridViewComboBoxEditingControl = CType(Me.ActiveControl, DataGridViewComboBoxEditingControl)

            Clipboard.SetText(CStr(lGr.EditingControlFormattedValue))
        End If
        'MsgBox(lGr.SelectedCells(0).Value)
        'Clipboard.SetText(CStr(lGr.SelectedCells(0).Value))
    End Sub
    Private Sub ToolStripMenuItemIns_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemIns.Click
        If TypeOf (Me.ActiveControl) Is DataGridViewComboBoxEditingControl Then
            Dim lGr As DataGridViewComboBoxEditingControl = CType(Me.ActiveControl, DataGridViewComboBoxEditingControl)
            lGr.EditingControlDataGridView.SelectedCells(0).Value = Clipboard.GetText()
            lGr.EditingControlDataGridView.EndEdit()
        End If

    End Sub
    Private Sub DataGridView2_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView2.DataError
        e.Cancel = True
    End Sub
    Private Sub ContextMenuStripObm_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStripObm.Opening
        If TypeOf (Me.ActiveControl) Is DataGridView Then
            e.Cancel = True
        End If
    End Sub
    Private Sub ToolStripMenuItemDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemDel.Click
        If TypeOf (Me.ActiveControl) Is DataGridViewComboBoxEditingControl Then
            Dim lGr As DataGridViewComboBoxEditingControl = CType(Me.ActiveControl, DataGridViewComboBoxEditingControl)

            lGr.EditingControlDataGridView.SelectedCells(0).Value = ""
            lGr.EditingControlDataGridView.EndEdit()
            'CType(lGr.EditingControlDataGridView.DataSource, BindingSource).EndEdit()
        End If
    End Sub











End Class