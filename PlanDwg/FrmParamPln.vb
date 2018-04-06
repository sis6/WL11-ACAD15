#If ARX_APP Then
Imports Autodesk.AutoCAD.Geometry
#Else
Imports Teigha.Geometry
#End If

Public Class FrmParamPln
	Private wRasst As modRasstOp.wlRasst
	WriteOnly Property Rasst As modRasstOp.wlRasst
		Set(ByVal value As modRasstOp.wlRasst)
			wRasst = value
		End Set
	End Property

	Private Sub tbUgol_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbUgol.TextChanged
		Try
			mtbStrUgl.Text = clsPrf.clsUgolPoworot.StrGradLwPr(CDbl(tbUgol.Text))
		Catch ex As Exception
			MsgBox(e.ToString)
		End Try

	End Sub

	Private Sub FrmParamPln_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		Dim msh, lunom As Integer
		Dim ug, X, Y, shirkosogor, lXr, lYr As Double
		dwgPlan.LeseParam(msh, ug, X, Y, shirkosogor, lXr, lYr, lunom)
		If wRasst IsNot Nothing Then
			With wRasst.Uch(0)
				shirkosogor = .ShirinaPofil
				lunom = .Unom
			End With

		End If
		Mashtab.Text = CStr(msh)
		tbUgol.Text = CStr(ug)
		tbXdwg.Text = CStr(X)
		tbYdwg.Text = CStr(Y)
		tbXreal.Text = CStr(lXr)
		TbYreal.Text = CStr(lYr)
		ShirKosogoraLabel.Text = CStr(shirkosogor) & " м. "
		UnomLabel.Text = CStr(lunom) & " кВ "
	End Sub

	Private Sub mtbStrUgl_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles mtbStrUgl.MaskInputRejected

	End Sub

	Private Sub tbUgol_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbUgol.Validating

	End Sub

	Private Sub mtbStrUgl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtbStrUgl.Validating
		tbUgol.Text = CStr(clsPrf.clsUgolPoworot.PreobrUglLwPr(mtbStrUgl.Text))

	End Sub

	Private Sub BtOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOK.Click
		'Dim msh As Integer
		'Dim ug, X, Y As Double
		'msh = CInt(Mashtab.Text)
		'ug = CDbl(tbUgol.Text)
		'X = CDbl(tbPiketajI.Text)
		'Y = CDbl(tbOtmetkaI.Text)
		'dwgPlan.SchreibeParam(msh, ug, X, Y)


	End Sub

	Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

	End Sub

	Private Sub btWibor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btWibor.Click
		''Этот вариант очень запутаный и поэтому сделан невидимый пользователю
		'оставлен в коде для примера
		' используеться как выбор 2 точек и определения по нему начальной точке и угла поворота
		'Dim WwedTchk As Autodesk.AutoCAD.Geometry.Point3dCollection = BazfunNet.GetPointsFromUser()
		'Dim wcount As Integer = WwedTchk.Count
		'If wcount > 1 Then
		'    Dim wp1 As Autodesk.AutoCAD.Geometry.Point3d = WwedTchk.Item(wcount - 2)
		'    tbXdwg.Text = CStr(wp1.X)
		'    tbYdwg.Text = CStr(wp1.Y)
		'    If WwedTchk.Count > 2 Then
		'        Dim wp2 As Autodesk.AutoCAD.Geometry.Point3d = WwedTchk.Item(wcount - 3)
		'        Dim wug As Autodesk.AutoCAD.Geometry.Vector3d = wp1.GetVectorTo(wp2)
		'        Dim vec2 = New Autodesk.AutoCAD.Geometry.Vector2d(wp2.X - wp1.X, wp2.Y - wp1.Y)
		'        tbUgol.Text = CStr(vec2.Angle)
		'    End If
		'End If

		Dim wPoint As Point3d = BazDwg.GetOdnuPointOtPolz
		Dim wugl As Double = BazDwg.GetOdinAngleOtPolz(wPoint)
		tbUgol.Text = CStr(wugl)
		tbXdwg.Text = CStr(wPoint.X)
		tbYdwg.Text = CStr(wPoint.Y)
	End Sub

	Private Sub ButtonWiborUgla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonWiborUgla.Click
		Dim wugl As Double
		wugl = BazDwg.GetOdinAngleOtPolz()
		'Dim strSoob As String = ""
		'For Each el As Double In wugl
		'    strSoob &= " ug " & el & vbCr
		'Next
		tbUgol.Text = CStr(wugl)
		' BazfunNet.Soob(strSoob)
	End Sub

	Private Sub ButtonWiborBegTchk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonWiborBegTchk.Click
		Dim wPoint As Point3d = BazDwg.Kommand.GetOdnuPointOtPolz
		'  BazfunNet.Soob("X " & wPoint.X & " Y " & wPoint.Y)
		tbXdwg.Text = CStr(wPoint.X)
		tbYdwg.Text = CStr(wPoint.Y)
	End Sub
End Class