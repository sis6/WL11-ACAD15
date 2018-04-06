Imports System.Collections.Generic

Public Class xlsImport
    Enum PolajExel
        name = 1
        piketaj = 2
        otmetka = 3
        otmetkaPr = 4
        otmetkaLw = 5
        param1 = 6
        param2 = 7
        param3 = 8
        param4 = 9
        tip = 10
        Opis = 11
        ugol = 12

    End Enum
    Private wSp As List(Of PointProf)
    Private wExcApp As Microsoft.Office.Interop.Excel.Application
    Private wlist As Microsoft.Office.Interop.Excel.Worksheet
    Public LabelInfo As Windows.Forms.Label
    Sub New(ByVal iProfil As PoSpPoint3dProf)


        wSp = iProfil.SpToshek

        '  D:\WL_11\DANNTEMPLATE
        wExcApp = New Microsoft.Office.Interop.Excel.Application
        Dim lbooks As Microsoft.Office.Interop.Excel.Workbook = wExcApp.Workbooks.Add(LeseSreib.BasePapka & "\DANNTEMPLATE\shablonWL11.xltx")
        wlist = CType(lbooks.Worksheets("Profil"), Microsoft.Office.Interop.Excel.Worksheet)
        'Dim lshets As Microsoft.Office.Interop.Excel.Worksheet = CType(ExcApp.ActiveSheet, Microsoft.Office.Interop.Excel.Worksheet)    'CType(lbooks.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)


    End Sub
    Sub zapolnit()
        Dim I As Integer = 4
        For Each el As PointProf In wSp
            LabelInfo.Text = CStr(I)
            LabelInfo.Refresh()
            With wlist
                CType(.Cells(I, 1), Microsoft.Office.Interop.Excel.Range).Value = CStr(I - 3)       'Format(lRast, "#")
                CType(.Cells(I, 2), Microsoft.Office.Interop.Excel.Range).Value = Format(el.Piketaj, "0.##")               ' Format(lRastSled, "#")
                CType(.Cells(I, 3), Microsoft.Office.Interop.Excel.Range).Value = Format(el.Otm, "0.##")
                If Not Double.IsNaN(el.OtmPr) Then CType(.Cells(I, PolajExel.otmetkaPr), Microsoft.Office.Interop.Excel.Range).Value = Format(el.OtmPr, "0.##")
                If Not Double.IsNaN(el.otmLw) Then CType(.Cells(I, PolajExel.otmetkaLw), Microsoft.Office.Interop.Excel.Range).Value = Format(el.otmLw, "0.##")
                CType(.Cells(I, PolajExel.ugol), Microsoft.Office.Interop.Excel.Range).Value = el.StrUgol                     'clsUgolPoworot.StrGradLwPr(el.Ugol)

            End With
            I += 1
        Next
        LabelInfo.Text = "Импорт завершен"
        LabelInfo.Refresh()
        wExcApp.Visible = True
    End Sub
End Class
