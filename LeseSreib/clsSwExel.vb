Option Explicit On
Option Strict Off
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Public MustInherit Class clsSwExel
    'Предоставляет интерфейс к документ Exel
    Public Shared frmSoob As frmSoob
    Public Const BegDann As Integer = 4
    Public Const sProfil = "Profil"
    Public Const sPiketUgod = "PiketUgod"
    Public Const sKlimat = "Klimat"
    Public Const srastOp = "rastOp"
    Public Const sParamUch = "ParamUch"
    Public Const sMechUsl = "MechUsl"
    Public Const sTopor = "Topor"
    Public Const sTprovod = "Tprovod"
    Public Const sTGirlajnd = "TGirlajnd"

    Private KnExel As Excel.Workbook
    Private AppExcel As Excel.Application
    Private TekList As Excel.Worksheet
    Private TekDat(,) As Object 'Считываем весь лист с заданного листа(учитывать что пустые строки и столбцы до первого не пустого символа отбрасываються. 

#Region "Init"

    Private Sub ProvList(ByVal NameL As String)

        Try
            Dim wr As Worksheet = KnExel.Worksheets(NameL)
            ' frmSoob.TextBox1.AppendText(" Ctrok " & wr.Rows.Count)
        Catch ex As System.Runtime.InteropServices.COMException
            frmSoob.TextBox1.AppendText("Отсутствует " & NameL & " Err " & ex.Message)
        Catch ex As Exception
            frmSoob.TextBox1.AppendText("Что то не то с " & NameL & " Err " & ex.Message)
        End Try


    End Sub
    Private Property DocExcel() As Excel.Workbook
        Get
            Return KnExel
        End Get
        Set(ByVal value As Excel.Workbook)
            KnExel = value

            frmSoob.TextBox1.AppendText("Knig " & AppExcel.Workbooks.Count & "   " & KnExel.Name & " " & vbCrLf)

            ProvList(sProfil)
            ProvList(sPiketUgod)
            ProvList(sKlimat)
            ProvList(srastOp)
            ProvList(sParamUch)
            ProvList(sMechUsl)
            ProvList(sTopor)
            ProvList(sTprovod)
            ProvList(sTGirlajnd)
        End Set
    End Property
    Property NameFile() As String
        Get
            Try
                Return DocExcel.FullName
            Catch ex As Exception
                Return ""
            End Try
        End Get
        Set(ByVal nameF As String)

            If My.Computer.FileSystem.FileExists(nameF) Then

                Dim RabDir = My.Computer.FileSystem.GetParentPath(nameF)

                DocExcel = AppExcel.Workbooks.Open(nameF)        'CType(AppExcel.Workbooks.Add(nameF), Excel.Workbook

            Else
                MsgBox(nameF & " не существует")

                Exit Property
            End If

        End Set

    End Property
    Sub Save(Optional ByVal PrSozdFile As Boolean = True)
        ' MsgBox()
        'Dim winCount As Integer = KnExel.Parent.Windows.Count()

        '' Insert additional code to manipulate the test.xls file here.
        '' ...

        'KnExel.Parent.Windows(winCount).Visible = True

        If PrSozdFile Then
            KnExel.Save()

        End If

        AppExcel.Visible = True

    End Sub
#End Region

#Region "Универсальные"
    Private Property UniMasStr(ByVal irow As Integer, ByVal CountCol As Integer) As String()
        Get
            Dim wrRang As Excel.Range

            Dim wrM(CountCol - 1) As String



            For Icol As Integer = 1 To CountCol
                wrRang = TekList.Cells(irow, Icol)
                If (wrRang.Value Is Nothing) Then
                    wrM(Icol - 1) = ""
                Else
                    wrM(Icol - 1) = CStr(wrRang.Value)
                End If
            Next
            Return wrM
        End Get
        Set(ByVal mStr() As String)
            Dim I As Integer

            Dim ws As String
            I = 1
            For Each ws In mStr
                Dim wr As Range = TekList.Cells(irow, I)

                wr.Value = ws
                I += 1
            Next
        End Set
    End Property
#End Region
#Region "S Lista"
    Protected Function Ust(ByVal NameList As String) As Boolean

        Try
            TekList = KnExel.Worksheets(NameList)

        Catch ex As Exception
            TekList = Nothing
            TekDat = Nothing
            Return False
        End Try
        TekDat = TekList.UsedRange.Value

        Return True
    End Function
    Sub DobList(ByVal NameList As String)

        Dim lList As Worksheet = KnExel.Worksheets.Add()
        lList.Name = NameList
        TekList = lList

    End Sub
  
    Protected Property ListMasStr(ByVal irow As Integer, ByVal CountCol As Integer) As String()
        Get
            ' Dim wrRang As Excel.Range
            Dim wrM(CountCol - 1) As String
            ' Dim Rajd As Range = TekList.Rows(irow)
            '   MsgBox(irow & "Kolwo " & CountCol)
            For Icol As Integer = 0 To CountCol - 1

                Try
                    wrM(Icol) = TekDat(irow, Icol + 1)
                Catch ex As Exception
                    wrM(Icol) = ""
                End Try

            Next

            If irow Mod 100 = 0 Then frmSoob.TextBox1.AppendText(TekList.Name & " " & irow)
            '  frmSoob.TextBox1.AppendText(" " & wrM(0) & " " & wrM(1))
            Return wrM
        End Get
        Set(ByVal mStr() As String)
            Dim I As Integer = 1

            For Each ws As String In mStr
                Dim wr As Range = TekList.Cells(irow, I)
                wr.Value = ws
                I += 1
            Next
        End Set
    End Property
  

    Function LeseDann(ByVal NameList As String, ByVal Kolwo As Integer) As Collection
        Dim Coll As New Collection

        If Ust(NameList) Then

            Dim wS() As String, Ir As Integer = 4
            Do
                wS = ListMasStr(Ir, Kolwo)
                If (wS(0) = "") Then Exit Do
                Coll.Add(wS)
                Ir += 1
            Loop
        End If
        Return Coll
    End Function
    Sub SreibDann(ByVal NameList As String, ByVal Kolwo As Integer, ByVal Coll As Collection)
        Dim Ir As Integer = 4

        If Not Ust(NameList) Then
            DobList(NameList)
          
        End If
        For Each s() As String In Coll
            ListMasStr(Ir, Kolwo) = s
            Ir += 1
        Next
    End Sub
#End Region
#Region "Global"
    Property NameUch() As String
        Get

            Try
                Return KnExel.Worksheets(sProfil).Cells(1, 10).value.ToString()
            Catch ex As NullReferenceException
                Return ""
            Catch ex As Exception
                MsgBox(ex.Message)
                Return ""
            End Try

        End Get
        Set(ByVal value As String)
            KnExel.Worksheets(sProfil).Cells(1, 10).value = value
        End Set
    End Property
    Property NameLin() As String
        Get
            Try
                Return KnExel.Worksheets(sProfil).Cells(1, 4).value.ToString()
            Catch ex As NullReferenceException
                Return ""
            Catch ex As Exception
                MsgBox(ex.Message)
                Return ""
            End Try

        End Get
        Set(ByVal value As String)
            KnExel.Worksheets(sProfil).Cells(1, 4).value = value
        End Set
    End Property
    Private Function ProvUnom(ByVal iunom As Integer) As Integer
        Dim masUnom() As Integer = {35, 110, 220, 330, 500, 750}
        Dim delta, rezUnom As Integer
        delta = 1000
        rezUnom = 35
        iunom = Math.Abs(iunom)
        For Each elU As Integer In masUnom
            If Math.Abs(elU - iunom) < delta Then
                rezUnom = elU
                delta = Math.Abs(elU - iunom)
            End If
        Next
        Return rezUnom
    End Function
    Property Unom() As Integer
        Get

            Try
                Dim lunom As Integer
                lunom = KnExel.Worksheets(sProfil).Cells(1, 12).value
                Return ProvUnom(lunom)
            Catch ex As Exception
                Return 110
            End Try
        End Get
        Set(ByVal value As Integer)
            KnExel.Worksheets(sProfil).Cells(1, 12).value = ProvUnom(value)
        End Set
    End Property

    Public Sub New(ByVal iAppExcel As Excel.Application)
        AppExcel = iAppExcel

    End Sub
    Public Sub New(ByVal iBook As Excel.Workbook)
        KnExel = iBook
        AppExcel = iBook.Application
    End Sub
#End Region
    'Runtime.InteropServices.DllImport("user32")
    Public Sub Quit()
        KnExel.Close()

        AppExcel.Quit()
        '  GetWindowThreadProcessId(appexcel.Application , 
    End Sub
    'Protected Overrides Sub Finalize()
    '    AppExcel.Quit()
    '    MyBase.Finalize()
    'End Sub
End Class
