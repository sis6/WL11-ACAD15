
Imports System.Runtime.InteropServices
#If ARX_APP Then
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.ApplicationServices
Imports DBTransMan = Autodesk.AutoCAD.DatabaseServices.TransactionManager
Imports Autodesk.AutoCAD.EditorInput
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
Imports Teigha.Runtime
Imports _AcWnd = Bricscad.Windows
Imports DBTransMan = Teigha.DatabaseServices.TransactionManager
#End If


'[DllImport] "accore.dll"]
Public Class SystemKommand
    <DllImport("accore.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.StdCall, EntryPoint:="acedCmd")>
    Public Shared Function acedCmd(vlist As System.IntPtr) As Integer

    End Function
    Private wlock As DocumentLock
    Public Shared Sub Zoom(ByVal pMin As Point3d, ByVal pMax As Point3d, ByVal pCenter As Point3d, ByVal dFactor As Double)

        '' Get the current document and database

        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument

        Dim acCurDb As Database = acDoc.Database

        Dim nCurVport As Integer = System.Convert.ToInt32(Application.GetSystemVariable("CVPORT"))

        '' Get the extents of the current space when no points 

        '' or only a center point is provided

        '' Check to see if Model space is current

        If acCurDb.TileMode = True Then

            If pMin.Equals(New Point3d()) = True And pMax.Equals(New Point3d()) = True Then

                pMin = acCurDb.Extmin

                pMax = acCurDb.Extmax

            End If

        Else
            '' Check to see if Paper space is current

            If nCurVport = 1 Then

                If pMin.Equals(New Point3d()) = True And pMax.Equals(New Point3d()) = True Then

                    pMin = acCurDb.Pextmin

                    pMax = acCurDb.Pextmax

                End If
            Else

                '' Get the extents of Model space
                If pMin.Equals(New Point3d()) = True And pMax.Equals(New Point3d()) = True Then

                    pMin = acCurDb.Extmin

                    pMax = acCurDb.Extmax

                End If
            End If
        End If

        '' Start a transaction
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()

            '' Get the current view
            Using acView As ViewTableRecord = acDoc.Editor.GetCurrentView()

                Dim eExtents As Extents3d


                '' Translate WCS coordinates to DCS
                Dim matWCS2DCS As Matrix3d

                matWCS2DCS = Matrix3d.PlaneToWorld(acView.ViewDirection)

                matWCS2DCS = Matrix3d.Displacement(acView.Target - Point3d.Origin) * matWCS2DCS

                matWCS2DCS = Matrix3d.Rotation(-acView.ViewTwist, acView.ViewDirection, acView.Target) * matWCS2DCS

                '' If a center point is specified, define the 
                '' min and max point of the extents
                '' for Center and Scale modes
                If pCenter.DistanceTo(Point3d.Origin) <> 0 Then

                    pMin = New Point3d(pCenter.X - (acView.Width / 2), pCenter.Y - (acView.Height / 2), 0)

                    pMax = New Point3d((acView.Width / 2) + pCenter.X, (acView.Height / 2) + pCenter.Y, 0)

                End If

                '' Create an extents object using a line
                Using acLine As Line = New Line(pMin, pMax)

                    eExtents = New Extents3d(acLine.Bounds.Value.MinPoint, acLine.Bounds.Value.MaxPoint)

                End Using

                '' Calculate the ratio between the width and height of the current view

                Dim dViewRatio As Double

                dViewRatio = (acView.Width / acView.Height)

                '' Tranform the extents of the view

                matWCS2DCS = matWCS2DCS.Inverse()

                eExtents.TransformBy(matWCS2DCS)

                Dim dWidth As Double
                Dim dHeight As Double
                Dim pNewCentPt As Point2d

                '' Check to see if a center point was provided (Center and Scale modes)
                If pCenter.DistanceTo(Point3d.Origin) <> 0 Then
                    dWidth = acView.Width
                    dHeight = acView.Height

                    If dFactor = 0 Then
                        pCenter = pCenter.TransformBy(matWCS2DCS)
                    End If

                    pNewCentPt = New Point2d(pCenter.X, pCenter.Y)

                Else '' Working in Window, Extents and Limits mode

                    '' Calculate the new width and height of the current view

                    dWidth = eExtents.MaxPoint.X - eExtents.MinPoint.X
                    dHeight = eExtents.MaxPoint.Y - eExtents.MinPoint.Y

                    '' Get the center of the view
                    pNewCentPt = New Point2d(((eExtents.MaxPoint.X + eExtents.MinPoint.X) * 0.5), ((eExtents.MaxPoint.Y + eExtents.MinPoint.Y) * 0.5))
                End If

                '' Check to see if the new width fits in current window
                If dWidth > (dHeight * dViewRatio) Then dHeight = dWidth / dViewRatio

                '' Resize and scale the view

                If dFactor <> 0 Then

                    acView.Height = dHeight * dFactor

                    acView.Width = dWidth * dFactor

                End If

                '' Set the center of the view
                acView.CenterPoint = pNewCentPt

                '' Set the current view
                acDoc.Editor.SetCurrentView(acView)

            End Using
            '' Commit the changes
            acTrans.Commit()
        End Using
    End Sub
    Public Shared Sub Soob(ByVal txtSoob As String)
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Application.ShowAlertDialog(txtSoob & vbCr & "  Чертеж   " & acDoc.Name)
    End Sub
    Public Shared Sub SoobEditor(ByVal txtSoob As String)
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        acDoc.Editor.WriteMessage(txtSoob & vbCrLf)

    End Sub
    Public Shared Sub Sohr()
        Dim lacDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim lName As String = lacDoc.Name


		Dim llock = Application.DocumentManager.MdiActiveDocument.LockDocument()
		'   Dim llock = lacDoc.LockDocument()
		'   lacDoc.Database.SaveAs(lName, True, DwgVersion.Current, lacDoc.Database.SecurityParameters)
		'  lacDoc.SendStringToExecute("_QSAVE ", True, False, False)
		'   llock.Dispose()
		'     lacDoc.Database.Save()


	End Sub
    Public Sub Lock()
        wlock = Application.DocumentManager.MdiActiveDocument.LockDocument()
    End Sub
    Public Sub Dispose()
        wlock.Dispose()
    End Sub
    Shared Sub Act()
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        acDoc.Editor.Regen()


    End Sub

    Shared ReadOnly Property NameFileDwg() As String
        Get
            Return Application.DocumentManager.MdiActiveDocument.Name
        End Get
    End Property


    'Shared Sub OtmenitOtm()
    '    If Application.DocumentManager.IsApplicationContext = False Then
    '        Dim rb As New ResultBuffer
    '        rb.Add(New TypedValue(5005, "UNDO"))
    '        rb.Add(New TypedValue(5005, "CONTROL"))
    '        rb.Add(New TypedValue(5005, "NONE"))
    '        acedCmd(rb.UnmanagedObject)
    '    End If


    'End Sub
    Shared Sub OtmenitOtmA()
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        acDoc.SendStringToExecute("_UNDO _CONTROL _NONE ", True, False, False)


    End Sub
    Shared Sub WklOtm()
        Dim rb As New ResultBuffer
        rb.Add(New TypedValue(5005, "_UNDO "))
        '   rb.Add(New TypedValue(5005, "_CONTROL"))
        rb.Add(New TypedValue(5005, "_ALL"))
        acedCmd(rb.UnmanagedObject)

    End Sub
    Shared Sub WklOtmA()
         Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        acDoc.SendStringToExecute("_UNDO  _ALL ", True, False, False)
    End Sub
    Shared Function SysGetValue(iValue As String) As Integer
        '   Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Return Application.GetSystemVariable(iValue)
    End Function
    'Shared Sub UserIntrac()
    '    Dim acend As EditorUserInteraction = Application.DocumentManager.MdiActiveDocument.Editor.StartUserInteraction()
    '    Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
    '    acDoc.SendStringToExecute("_UNDO _CONTROL _NONE ", True, False, False)
    '    acend.End()
    'End Sub
End Class
