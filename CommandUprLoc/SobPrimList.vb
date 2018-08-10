

#If ARX_APP Then
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.ApplicationServices
Imports DBTransMan = Autodesk.AutoCAD.DatabaseServices.TransactionManager
Imports Autodesk.AutoCAD.Runtime
#Else
Imports Bricscad.ApplicationServices
Imports Teigha.DatabaseServices
Imports Teigha.Runtime
'Imports Bricscad.EditorInput
'Imports Teigha.Geometry
'Imports _AcGi = Teigha.GraphicsInterface
'Imports _AcGs = Teigha.GraphicsSystem
'Imports _AcPl = Bricscad.PlottingServices
'Imports _AcBrx = Bricscad.Runtime
'Imports _AcTrx = Teigha.Runtime
'Imports _AcWnd = Bricscad.Windows
Imports DBTransMan = Teigha.DatabaseServices.TransactionManager
#End If
Imports BazDwg

Public Class SobPrimList
	Private elList As New Collection
	Sub New()
		NalineSloj()
	End Sub
	'Sub ListDwg()
	'    '' Get the current document and database, and start a transaction
	'    Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
	'    Dim acCurDb As Database = acDoc.Database
	'    Dim Str_oth As String = "Kommand:ListDwg Листы " & vbCrLf

	'    Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()

	'        Dim D As DBDictionary
	'        Dim Dinum As DbDictionaryEnumerator
	'        Dim acLayoutMgr As LayoutManager = LayoutManager.Current



	'        D = CType(acTrans.GetObject(acCurDb.LayoutDictionaryId, OpenMode.ForRead), DBDictionary)



	'        Dinum = D.GetEnumerator

	'        Do While Dinum.MoveNext()
	'            ' MsgBox("S " & "k " &  & "  Z  " & )

	'            If Dinum.Key <> "Model" Then
	'                Dim lLayout As DBObject = CType(acTrans.GetObject(acLayoutMgr.GetLayoutId(Dinum.Key), OpenMode.ForRead), DBObject)
	'                elList.Add(lLayout)
	'                ' lLayout.UpgradeOpen()
	'                AddHandler lLayout.Modified, AddressOf AnalImeni
	'                AddHandler lLayout.ObjectClosed, AddressOf AnalImeni
	'                AddHandler lLayout.Erased, AddressOf AnalImeni

	'            End If

	'        Loop

	'        '' Get a copy of the PlotSettings from the layout


	'        acTrans.Commit()
	'    End Using


	'End Sub
	Private Sub SetEntityObr(ByVal spObjid As ObjectId())

		Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database
		Dim tm As DBTransMan = db.TransactionManager
		'start a transaction
		Dim ta As Transaction = tm.StartTransaction()
		For Each objId As ObjectId In spObjid
			Dim ent As Entity = CType(tm.GetObject(objId, OpenMode.ForWrite, True), Entity)
			AddHandler ent.OpenedForModify, AddressOf Doizmenen
			AddHandler ent.Modified, AddressOf Izmenen
		Next


		ta.Commit()



		ta.Dispose()

	End Sub
	Private Sub NalineSloj()
		SetEntityObr(BazDwg.netSelectSet.WibratNaSloiWmodeleElement(DwgParam.SlProfilPiketaj, "LINE"))

	End Sub
	Private KoorXDo, koorxPosle As Double
	Sub Doizmenen(ByVal Send As Object, ByVal e As EventArgs)
		Dim llin As Line = CType(Send, Line)
		Dim r As RXClass = llin.GetRXClass()  ' .DxfName
		KoorXDo = llin.StartPoint.X
		Dim realX As Double = clsKommandBase.gTrassa.objGeom.RastPoDwgX(KoorXDo)
		Dim lpik As clsPrf.ClsPiket = clsKommandBase.gTrassa.Piket(realX)
		Application.ShowAlertDialog("doIzmenenij  Имя " & r.Name & " " & r.DxfName)
	End Sub
	Sub Izmenen(ByVal Send As Object, ByVal e As EventArgs)
		Dim llin As Line = CType(Send, Line)
		Dim r As RXClass = CType(Send, Entity).GetRXClass()  ' .DxfName
		koorxPosle = llin.StartPoint.X
		Application.ShowAlertDialog("коор  do  " & KoorXDo & "  posle " & koorxPosle)
	End Sub
End Class
