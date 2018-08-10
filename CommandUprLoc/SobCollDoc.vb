
#If ARX_APP Then
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.Runtime
#Else
Imports Bricscad.ApplicationServices
Imports _AcBr = Teigha.BoundaryRepresentation
Imports _AcCm = Teigha.Colors
Imports Teigha.DatabaseServices
Imports Bricscad.EditorInput
Imports Teigha.Geometry
Imports _AcGi = Teigha.GraphicsInterface
Imports _AcGs = Teigha.GraphicsSystem
Imports _AcPl = Bricscad.PlottingServices
Imports _AcBrx = Bricscad.Runtime
Imports _AcTrx = Teigha.Runtime
Imports _AcWnd = Bricscad.Windows
Imports DBTransMan = Teigha.DatabaseServices.TransactionManager
#End If
Public Class SobCollDoc
    '  Private Lmen As New BazDwg.dwgMenuUpr
    Private Shared wSohr As New dwgSohranenij
    Shared ReadOnly Property SohranenRasst As dwgSohranenij
        Get
            Return wSohr
        End Get
    End Property

    Sub New()
		AddHandler Application.DocumentManager.DocumentActivated,
			AddressOf docColDocAct
		AddHandler Application.DocumentManager.DocumentToBeDeactivated,
		   AddressOf docColDocDeAct
		AddHandler Application.DocumentManager.DocumentCreated,
			AddressOf SozdanDoc
		AddHandler Application.DocumentManager.DocumentLockModeChanged,
		AddressOf docDocumentLockModeChanged
		Dim lsob As New SobDoc
    End Sub
    Public Sub SozdanDoc(ByVal senderObj As Object, _
                            ByVal docColDocActEvtArgs As DocumentCollectionEventArgs)
        Dim lsob As New SobDoc
        clsKommandRst.SkrutMenuUch()
    End Sub

    Public Sub docColDocAct(ByVal senderObj As Object, _
                            ByVal docColDocActEvtArgs As DocumentCollectionEventArgs)
		Dim lSoob As String

		Try
			If docColDocActEvtArgs.Document IsNot Nothing Then
				lSoob = Me.ToString & " Активирован " & docColDocActEvtArgs.Document.Name & vbCr
			Else
				Return
			End If

		Catch ex As Exception
			Return
		End Try


		'  BazDwg.Kommand.SoobEditor(lSoob)

		clsKommandRst.SkrutMenuUch()

		Dim lWspRast = wSohr.Izwlech(docColDocActEvtArgs.Document.Name)

        If lWspRast IsNot Nothing Then
        clsKommandBase.gRasst = lWspRast


		End If
        BazDwg.SystemKommand.SoobEditor(lSoob)

    End Sub
    Public Sub docColDocDeAct(ByVal senderObj As Object, _
                           ByVal docColDocActEvtArgs As DocumentCollectionEventArgs)
        Dim lSoob = " Деактивирован " & docColDocActEvtArgs.Document.Name & vbCr
        '    clsKommandRst.SkrutMenuUch()
        If clsKommandBase.gRasst IsNot Nothing Then   'And gRasst.PrIzm
			If clsKommandBase.gRasst.PrIzm(False) Then lSoob &= "В чертеже  не сохранены изменения профиля и расстановки "
			wSohr.Dobawit()
			clsKommandBase.gRasst = Nothing

        End If
        BazDwg.SystemKommand.SoobEditor(lSoob)

	End Sub
	Public Sub docDocumentLockModeChanged(ByVal senderObj As Object, e As DocumentLockModeChangedEventArgs)
		'If String.Compare(e.GlobalCommandName, "WCLOSE", True) = 0 Then
		'	If clsKommandBase.gRasst.PrIzm(True) Then e.Veto()
		'End If

		'	If String.Compare(e.GlobalCommandName, "QUIT", True) = 0 Then
		'	If clsKommandBase.gRasst.PrIzm(True) Then e.Veto()

		'End If

	End Sub


End Class
Public Class SobDoc
    ' Private acDoc As Document
    Private wNamewipCommand As String
	Sub New()
		Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
		If acDoc Is Nothing Then Return
		AddHandler acDoc.BeginDocumentClose, AddressOf docBeginDocClose
		AddHandler acDoc.CommandWillStart, AddressOf DocCommand
		AddHandler acDoc.CommandEnded, AddressOf DocEndCommand
		'  AddHandler acDoc., AddressOf DocCommand1

	End Sub
	Sub Sohr()
		If False Then
			If gDostup.Prawo = OperBD.PrawoDostup.PolzOve Then
				clsKommandBase.ZapisRasstWSohran()
			Else
				If gDostup.Prawo = OperBD.PrawoDostup.PolzTiz Then
					clsKommandBase.ZapisTrassaWSohran()
				End If

			End If

		Else
			Dim l As New BazDwg.SystemKommand
			l.Lock()
			clsKommandBase.SohranitTrassRasstW_Dwg()
			l.Dispose()
		End If
	End Sub

	Public Sub docBeginDocClose(ByVal senderObj As Object,
                                ByVal docBegClsEvtArgs As DocumentBeginCloseEventArgs)
        clsKommandRst.SkrutMenuUch()
        If clsKommandBase.gRasst Is Nothing Then Return
		If clsKommandBase.gRasst.PrIzm(True) Then       ' 1
			If System.Windows.Forms.MessageBox.Show(
						"  В " & Application.DocumentManager.MdiActiveDocument.Name & " не сохраненные изменения расстановки" &
						vbLf & "Сохранить?", Me.ToString & "  WL11_AcadLoc:docBeginDocClose",
						System.Windows.Forms.MessageBoxButtons.YesNo) =
					System.Windows.Forms.DialogResult.Yes Then                  '2
				Sohr()
				BazDwg.SystemKommand.Sohr()

			End If      '2



		End If
		SobCollDoc.SohranenRasst.udalit(Application.DocumentManager.MdiActiveDocument.Name)
		clsKommandBase.gRasst = Nothing
	End Sub
    Public Sub DocCommand(ByVal sender As Object, ByVal args As CommandEventArgs)
		'   MsgBox(Me.ToString & " " & args.GlobalCommandName)
		'    If args.GlobalCommandName = "WIBORNASLOAJH" Then MsgBox(Me.ToString & " " & args.GlobalCommandName)

		'Dim lname As String = args.GlobalCommandName
		'If lname = "KORRDANNUCH" Then   'KorrDannUch
		'    MsgBox("NameDo " & Application.DocumentManager.MdiActiveDocument.Name)
		'End If
		'MsgBox(Me.ToString & " DocCommand " & args.GlobalCommandName)

	End Sub
    Public Sub DocEndCommand(ByVal sender As Object, ByVal args As CommandEventArgs)
        Dim lname As String = args.GlobalCommandName
		If lname = "SAVEAS" Then
			clsKommandBase.gTrassa.SootNameDwg()
			MsgBox("Учли изменение имени чертежа в модели трассы " & Application.DocumentManager.MdiActiveDocument.Name & " Gt " & clsKommandBase.gTrassa.NameDwg)
		End If
		'If lname = "QUIT" Then
		'	MsgBox("Конец " & lname)
		'End If
	End Sub



    'Protected Overrides Sub Finalize()
    '    RemoveHandler acDoc.BeginDocumentClose, AddressOf docBeginDocClose
    '    RemoveHandler acDoc.CommandWillStart, AddressOf DocCommand
    'End Sub
End Class