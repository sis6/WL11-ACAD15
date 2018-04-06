#If ARX_APP Then
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.EditorInput
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.Customization
#Else
Imports Bricscad.ApplicationServices
Imports Teigha.DatabaseServices
Imports Bricscad.EditorInput
Imports Teigha.Geometry
Imports Bricscad.Runtime
Imports Teigha.Runtime
Imports _AcWnd = Bricscad.Windows
Imports DBTransMan = Teigha.DatabaseServices.TransactionManager
#End If


Imports System
Imports System.Collections.Specialized


Public Class dwgMenuCui
    Private Shared wBasePapka As String = ""
    Private myCuiFile As String = wBasePapka & "\AnkUch.cuix"
	' Private myCuiFileToSend As String = wBasePapka & "\AnkUch.cuix"
	'Private myCuiSectionName As String = "AnkUch"
	'Shared WriteOnly Property BasePapka() As String
	'       Set(iBasePapka As String)
	'           wBasePapka = iBasePapka
	'       End Set
	'   End Property
	Public Sub WigrMenuCui()

    End Sub
   '  Public Event Zakrit(Inum As Integer)
    Public Sub UdalMenuCui()
     

        'If System.IO.File.Exists(myCuiFile) Then
        '    System.IO.File.Delete(myCuiFile)
        'End If
        '   RaiseEvent Zakrit(5)

    End Sub
    Public Sub BuildMenuCui(iNameMenu As String)
      

    End Sub
    Shared Sub LoadMyCui(cuiFile As String)
        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim oldCmdEcho As Object = Application.GetSystemVariable("CMDECHO")
        Dim oldFileDia As Object = Application.GetSystemVariable("FILEDIA")

        'Application.SetSystemVariable("FILEDIA", 0)
        'Application.SetSystemVariable("CMDECHO", 0)
        doc.SendStringToExecute("(setvar ""FILEDIA"" " & " 0 )(princ) ", False, False, False)
        doc.SendStringToExecute("(setvar ""CMDECHO"" " & " 0 )(princ) ", False, False, False)

        doc.SendStringToExecute("_.cuiload " & cuiFile & " ", False, False, False)

        doc.SendStringToExecute("(setvar ""FILEDIA"" " & oldFileDia.ToString() & ")(princ) ", False, False, False)
        doc.SendStringToExecute("(setvar ""CMDECHO"" " & oldCmdEcho.ToString() & ")(princ) ", False, False, False)

        Dim oldFileDia1 As Object = Application.GetSystemVariable("FILEDIA")
        Do Until oldFileDia1.ToString = oldFileDia.ToString

            Application.SetSystemVariable("FILEDIA", CInt(oldFileDia))
            Application.SetSystemVariable("CMDECHO", CInt(oldCmdEcho))
            oldFileDia1 = Application.GetSystemVariable("FILEDIA")
        Loop
    End Sub
    Shared Sub UnLoadMyCui(cuiFile As String)
        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        If doc Is Nothing Then Return
        Dim oldCmdEcho As Object = Application.GetSystemVariable("CMDECHO")
        Dim oldFileDia As Object = Application.GetSystemVariable("FILEDIA")

        'Application.SetSystemVariable("FILEDIA", 0)
        'Application.SetSystemVariable("CMDECHO", 0)
        doc.SendStringToExecute("(setvar ""FILEDIA"" " & " 0 )(princ) ", False, False, False)
        doc.SendStringToExecute("(setvar ""CMDECHO"" " & " 0 )(princ) ", False, False, False)

        doc.SendStringToExecute("_.cuiunload " & cuiFile & " ", False, False, False)


        doc.SendStringToExecute("(setvar ""FILEDIA"" " & oldFileDia.ToString() & ")(princ) ", False, False, False)
        doc.SendStringToExecute("(setvar ""CMDECHO"" " & oldCmdEcho.ToString() & ")(princ) ", False, False, False)
        '      doc.SendStringToExecute("(setvar ""FILEDIA"" " & " 1 )(princ) ", False, False, False)

        Dim oldFileDia1 As Object = Application.GetSystemVariable("FILEDIA")
        Do Until oldFileDia1.ToString = oldFileDia.ToString
            Application.SetSystemVariable("FILEDIA", CShort(oldFileDia))
            Application.SetSystemVariable("CMDECHO", CShort(oldCmdEcho))
            oldFileDia1 = Application.GetSystemVariable("FILEDIA")
        Loop
    End Sub

End Class
