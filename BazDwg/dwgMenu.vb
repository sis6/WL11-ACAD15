Option Strict On
Option Explicit On
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.ApplicationServices
Imports DBTransMan = Autodesk.AutoCAD.DatabaseServices.TransactionManager
Imports Autodesk.AutoCAD.Windows
Imports Autodesk.AutoCAD.Interop
Imports Autodesk.AutoCAD.Customization
''' <summary>
'''  базовый класс для работы с меню
''' </summary>
''' <remarks></remarks>
Public Class dwgMenuBase
    Protected objGlmenu As AcadMenuGroup 'группа меню программы
    Protected wse As AcadMenuGroups ' все группы меню программы
    '  Protected objSuchMenu As AcadPopupMenu
    Protected NameGr As String
   
    Private Sub SpWsehMenu()

        Dim Soob As String
        Soob = "Все меню" & vbCr

        For Each onemenu As AcadMenuGroup In wse
            With onemenu
                Soob &= .Name & " " & .MenuFileName & " Вып. меню " & .Menus.Count & " Панелей " & .Toolbars.Count & vbCr
            End With

        Next
        '   Soob &= " Текущее меню " & objGlmenu.Name
        Application.ShowAlertDialog(Soob)

    End Sub
    Private Function EstliGruppa(ByVal iNameGr As String) As Boolean
        For Each tGrMenu As AcadMenuGroup In wse
            If tGrMenu.Name = iNameGr Then Return True

        Next
        Return False
    End Function
    Private Function EstliWobjGlmenu(ByVal iName As String) As Boolean 'присутствует ли меню с заданыи именем в группе
        For Each tPopMenu As AcadPopupMenu In objGlmenu.Menus
            If tPopMenu.Name = iName Then Return True

        Next
        Return False
    End Function
    Sub New(ByVal inameGr As String)
        NameGr = inameGr

        wse = CType(Application.MenuGroups, AcadMenuGroups)
        '   MsgBox(Me.ToString & "  " & wse.Count)

        If EstliGruppa(NameGr) Then
            objGlmenu = wse.Item(NameGr)
        Else
            SystemKommand.SoobEditor(MyClass.ToString & "  отсутствует  группа меню " & NameGr)
            objGlmenu = Nothing
        End If
        'Dim acApp As AcadApplication = CType(Application.AcadApplication, AcadApplication)

        'AddHandler acApp.BeginComman 
        ' objSuchMenu = objGlmenu.Menus.Item(0)
        ' MsgBox(objSuchMenu.Name)
    End Sub
End Class

''' <summary>
''' Вывод и формирование дополнительного меню и панели инструментов
''' </summary>
''' <remarks></remarks>
Public Class dwgMenu
    Inherits dwgMenuBase


    Private Function EstliWToolsBar(ByVal iName As String) As Boolean
        For Each tpopupMenu As AcadPopupMenu In CType(Application.MenuBar, AcadMenuBar)
            If tpopupMenu.Name = iName Then Return True
        Next
        Return False
    End Function

    Public Sub DobMenu(ByVal NameAnkUch As String, ByVal PrTr As Boolean)
        If objGlmenu Is Nothing Then Return
        If objGlmenu.Menus.Count = 1 Then
            Dim dobmenu As AcadPopupMenu = objGlmenu.Menus.Add(NameAnkUch)

            Dim I As Integer = 1

            dobmenu.AddMenuItem(I, "Нагрузки", Chr(3) & Chr(3) & Chr(95) & "Nagruzki" & Chr(32))
            I += 1
            dobmenu.AddSeparator(I)
            I += 1
            dobmenu.AddMenuItem(I, "Доб. пром. опору", Chr(3) & Chr(3) & Chr(95) & "DobPromOp" & Chr(32)) 'UdalPromOp
            I += 1
            dobmenu.AddSeparator(I)
            I += 1
            dobmenu.AddMenuItem(I, "Удал. пром. опору", Chr(3) & Chr(3) & Chr(95) & "UdalPromOp" & Chr(32))
            I += 1
            dobmenu.AddSeparator(I)
            I += 1
            dobmenu.AddMenuItem(I, "Расставить кроме первых ", Chr(3) & Chr(3) & Chr(95) & "rasstabit1" & Chr(32))
            I += 1
            dobmenu.AddSeparator(I)
            I += 1
            dobmenu.AddMenuItem(I, "Расставить все", Chr(3) & Chr(3) & Chr(95) & "rasstabit" & Chr(32))
            I += 1
            dobmenu.AddSeparator(I)
            I += 1
            dobmenu.AddMenuItem(I, "Расчет габарит. режима", Chr(3) & Chr(3) & Chr(95) & "Raschet" & Chr(32))
            I += 1
            dobmenu.AddSeparator(I)
            I += 1
            dobmenu.AddMenuItem(I, "Задать режим", Chr(3) & Chr(3) & Chr(95) & "ZadatUslow" & Chr(32))
            I += 1
            dobmenu.AddSeparator(I)
            I += 1
            dobmenu.AddMenuItem(I, "Расчет заданого режима", Chr(3) & Chr(3) & Chr(95) & "RaschetPoZad" & Chr(32))
            I += 1
            dobmenu.AddSeparator(I)
            I += 1
            dobmenu.AddMenuItem(I, "Расчет пересечений", Chr(3) & Chr(3) & Chr(95) & "Pereseshenij" & Chr(32))
            I += 1
            dobmenu.AddSeparator(I)
            I += 1
            dobmenu.AddMenuItem(I, "Задать пересечения", Chr(3) & Chr(3) & Chr(95) & "ZadPeresesh" & Chr(32))
            I += 1
            dobmenu.AddSeparator(I)
            I += 1
            dobmenu.AddMenuItem(I, "Аварийный режим", Chr(3) & Chr(3) & Chr(95) & "RaschetAw" & Chr(32))
            I += 1
            dobmenu.AddSeparator(I)
            I += 1
            If PrTr Then
                Dim SubmenuTros As AcadPopupMenu = dobmenu.AddSubMenu(I, "Трос")
                I += 1
                dobmenu.AddSeparator(I)
                I += 1
                SubmenuTros.AddMenuItem(1, "Опр. по габ. режиму", Chr(3) & Chr(3) & Chr(95) & "RaschetRejTros" & Chr(32))
                SubmenuTros.AddSeparator(2)    'RaschetRejTrosZad
                SubmenuTros.AddMenuItem(3, "Опр. по  зад. режиму", Chr(3) & Chr(3) & Chr(95) & "RaschetRejTrosZad" & Chr(32))
                SubmenuTros.AddSeparator(4)    'RaschetRejTrosZad
                SubmenuTros.AddMenuItem(5, "Нагрузки на трос", Chr(3) & Chr(3) & Chr(95) & "NagruzkiT" & Chr(32))
                SubmenuTros.AddSeparator(6)    'RaschetNagr
                SubmenuTros.AddMenuItem(7, "Задать режим троса ", Chr(3) & Chr(3) & Chr(95) & "ZadatUslowT" & Chr(32))
                SubmenuTros.AddSeparator(8)    'Задать режим
                SubmenuTros.AddMenuItem(9, "Расчет зад.(трос) ", Chr(3) & Chr(3) & Chr(95) & "RaschetPoZadT" & Chr(32))
                SubmenuTros.AddSeparator(10)    'Расчет заданого
            End If


            ' MsgBox(ind)
            dobmenu.InsertInMenuBar(CType(Application.MenuBar, AcadMenuBar).Count + 1)
        Else
            Dim dobmenu As AcadPopupMenu = CType(objGlmenu.Menus(1), AcadPopupMenu)
            If Not EstliWToolsBar(dobmenu.Name) Then

                dobmenu.InsertInMenuBar(CType(Application.MenuBar, AcadMenuBar).Count + 1)
            End If


            If NameAnkUch <> dobmenu.Name Then dobmenu.Name = NameAnkUch

        End If

    End Sub
    Public Sub SkrutMenu(ByVal NameAnkUch As String)
        If EstliWToolsBar(NameAnkUch) Then
            CType(objGlmenu.Menus(1), AcadPopupMenu).RemoveFromMenuBar()
        End If
    End Sub
    Sub V_Toolbars(ByVal Name As String, Optional ByVal PrVid As Boolean = True)
        objGlmenu.Toolbars.Item(Name).Visible = PrVid
    End Sub
    Sub V_Toolbars()
        If objGlmenu Is Nothing Then Return
        For I As Integer = 0 To objGlmenu.Toolbars.Count - 1
            objGlmenu.Toolbars.Item(I).Visible = True
        Next

    End Sub

    Sub New()
        MyBase.new("PROFIL_NET")
    End Sub
End Class
Public Class dwgMenuUpr
    '  Inherits dwgMenu
    Private Const wNameMenu As String = "ВЛ_11A"
    Private Const wNameMenuOIZ As String = "ВЛ_11ОИЗ"
    Private wWL11menu, wWL11menuOIZ As AcadPopupMenu


    Sub Udalit()
        Dim lmnBar As AcadMenuBar = CType(Application.MenuBar, AcadMenuBar)

        For i = 0 To lmnBar.Count - 1
            Dim lpopupmenu As AcadPopupMenu = CType(lmnBar.Item(i), AcadPopupMenu)
            If lpopupmenu.Name = wNameMenu Then
                lpopupmenu.RemoveFromMenuBar()
                wWL11menu = lpopupmenu
                Exit For
            End If
        Next
        For i = 0 To lmnBar.Count - 1
            Dim lpopupmenu As AcadPopupMenu = CType(lmnBar.Item(i), AcadPopupMenu)
            If lpopupmenu.Name = wNameMenuOIZ Then
                lpopupmenu.RemoveFromMenuBar()
                wWL11menuOIZ = lpopupmenu
                Return
            End If
        Next

    End Sub
    Private Function Proverit(ByVal iNameMenu As String) As Boolean
        Dim lmnBar As AcadMenuBar = CType(Application.MenuBar, AcadMenuBar)

        For i = 0 To lmnBar.Count - 1

            If CType(lmnBar.Item(i), AcadPopupMenu).Name = iNameMenu Then
                Return True
            End If
        Next
        Return False
    End Function
    Sub Dobawit()
        If wWL11menu IsNot Nothing Then
            If Not Proverit(wNameMenu) Then wWL11menu.InsertInMenuBar(CType(Application.MenuBar, AcadMenuBar).Count + 1)
        End If
        If wWL11menuOIZ IsNot Nothing Then
            If Not Proverit(wNameMenuOIZ) Then wWL11menuOIZ.InsertInMenuBar(CType(Application.MenuBar, AcadMenuBar).Count + 1)
        End If
    End Sub
End Class