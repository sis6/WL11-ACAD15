'В классе должны быть реализованы функции
'создание словаря с заданным именем
' создание записи с заданным именем и включение ее в словарь
' извлечение записи по имени   _
'изменение записи
Option Strict On
Option Explicit On
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
Imports _AcTrx = Teigha.Runtime
Imports _AcWnd = Bricscad.Windows
Imports DBTransMan = Teigha.DatabaseServices.TransactionManager
#End If
Public Class dwgSlowar
    Protected NameSlw As String
    Protected wDatabaseDwg As Database
    Shared Function DopustImjSlowaraj(ByVal IStr As String) As String
        IStr = Trim(IStr)
        IStr = Replace(IStr, "|", "_")
        IStr = Replace(IStr, "*", "_")
        IStr = Replace(IStr, "/", "_")
        IStr = Replace(IStr, ";", "_")
        IStr = Replace(IStr, ":", "_")
        IStr = Replace(IStr, "<", "_")
        IStr = Replace(IStr, ">", "_")
        IStr = Replace(IStr, "?", "_")
        IStr = Replace(IStr, """", "_")
        IStr = Replace(IStr, ",", "_")
        IStr = Replace(IStr, "=", "_")
        IStr = Replace(IStr, "`", "_")
        Return IStr
    End Function
    Protected Function SozdatXrecord(ByVal MasDan() As TypedValue) As Xrecord
        Dim wr As New Xrecord

        Dim wrBuffer As ResultBuffer

		Try
			wrBuffer = New ResultBuffer(MasDan)
			wr.Data = wrBuffer
		Catch ex As exception
			MsgBox(Me.ToString & " SozdatXrecord " & ex.Message)
        End Try

        'MsgBox("SozdatZapis" & wr.ToString)
        Return wr
    End Function
    Protected Function LeseXrecord(ByVal Zap As Xrecord) As TypedValue()
        If Zap.Data Is Nothing Then Return Nothing
        'Zap.Data.AsArray.Length
        'Dim Razm As Int16 = CShort(UBound(Zap.Data.AsArray))
        If Zap.Data.AsArray.Length > 0 Then
            Return Zap.Data.AsArray
        Else
            Return Nothing
        End If
    End Function
    ''' <summary>
    ''' чтение из словаря с произвольной базой данных чертежаб может быть и другого файла
    ''' </summary>
    ''' <param name="NameZap"> имя записи </param>
    ''' <param name="iDatabaseDwg"> база данных чертежа </param>
    ''' <returns> возвращает считанные данные </returns>
    ''' <remarks></remarks>
    Public Function ZapisIsSlowar(ByVal NameZap As String, ByVal iDatabaseDwg As Database) As TypedValue()
        Dim pDict As DBDictionary     'Autodesk.AutoCAD.DatabaseServices.DBObject
        Dim ZapId As ObjectId
        Dim Zap As Xrecord
        Dim Md() As TypedValue = Nothing

        '  Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database
        Dim tm As DBTransMan = iDatabaseDwg.TransactionManager
        Using ta As Transaction = tm.StartTransaction()
            pDict = CType(ta.GetObject(iDatabaseDwg.NamedObjectsDictionaryId, OpenMode.ForRead), DBDictionary) 'открываем глобальный словаррь

            If pDict.Contains(NameSlw) Then
                pDict = CType(pDict.GetAt(NameSlw).GetObject(OpenMode.ForRead), DBDictionary) 'открываем словарь класса
                If pDict.Contains(NameZap) Then 'проверяем наличие записи
                    ZapId = pDict.GetAt(NameZap) 'извлекаем запись
                    Zap = CType(ZapId.GetObject(OpenMode.ForRead), Xrecord)
                    Md = LeseXrecord(Zap)
                Else
                    SystemKommand.SoobEditor(Me.ToString & " ZapisIsSlowar: Zapis_c_name " & NameZap & " не найдена в словаре " & NameSlw)
                    '  Kommand.SoobTxtWindAcad(Me.ToString & "ZapisIsSlowar: Zapis_c_name" & NameZap & " не найдена")
                End If
            Else
                SystemKommand.SoobEditor(Me.ToString & " ZapisIsSlowar Словарь " & NameSlw & " отсутствует словарь " & NameSlw)
            End If

            ta.Commit()
        End Using
        Return Md
    End Function
    ''' <summary>
    ''' чтение из словаря чертежа записи
    ''' </summary>
    ''' <param name="NameZap"> имя записи </param>
    ''' <returns> возвращает считанные данные </returns>
    ''' <remarks></remarks>
    Public Function ZapisIsSlowar(ByVal NameZap As String) As TypedValue()
        Dim pDict As DBDictionary     'Autodesk.AutoCAD.DatabaseServices.DBObject
        Dim ZapId As ObjectId
        Dim Zap As Xrecord
        Dim Md() As TypedValue = Nothing


        Dim tm As DBTransMan = wDatabaseDwg.TransactionManager
        Using ta As Transaction = tm.StartTransaction()
            pDict = CType(ta.GetObject(wDatabaseDwg.NamedObjectsDictionaryId, OpenMode.ForRead), DBDictionary) 'открываем глобальный словаррь

            If pDict.Contains(NameSlw) Then
                pDict = CType(pDict.GetAt(NameSlw).GetObject(OpenMode.ForRead), DBDictionary) 'открываем словарь класса

                If pDict.Contains(NameZap) Then 'проверяем наличие записи
                    ZapId = pDict.GetAt(NameZap) 'извлекаем запись
                    Zap = CType(ZapId.GetObject(OpenMode.ForRead), Xrecord)
                    Md = LeseXrecord(Zap)
                Else
                    SystemKommand.SoobEditor(Me.ToString & " ZapisIsSlowar: Zapis_c_name " & NameZap & " не найдена в словаре " & NameSlw)
                    '  Kommand.SoobTxtWindAcad(Me.ToString & "ZapisIsSlowar: Zapis_c_name" & NameZap & " не найдена")
                End If
            Else
                SystemKommand.SoobEditor(Me.ToString & " ZapisIsSlowar Словарь " & NameSlw & " отсутствует словарь " & NameSlw)
            End If

            ta.Commit()
        End Using
        Return Md
    End Function
#Region "Wse Zapici"
    ''' <summary>
    ''' извлекаем все записи в словаре класса
    ''' </summary>
    ''' <param name="iSpNameZap">Список имен записей.  </param>
    ''' <returns> Возвращаем коллекцию всех записей в строковом представление</returns>
    ''' <remarks></remarks>
    Public Function WseZapisIsSlowar(ByVal iSpNameZap As List(Of String)) As Collection

        Dim pDict As DBDictionary     'Autodesk.AutoCAD.DatabaseServices.DBObject
        Dim Md As New Collection
        iSpNameZap.Clear()

        '  Dim wDatabaseDwg As Database = Application.DocumentManager.MdiActiveDocument.Database
        Dim tm As DBTransMan = wDatabaseDwg.TransactionManager
        Using ta As Transaction = tm.StartTransaction()

            pDict = CType(ta.GetObject(wDatabaseDwg.NamedObjectsDictionaryId, OpenMode.ForRead), DBDictionary)
            If pDict.Contains(NameSlw) Then
                pDict = CType(pDict.GetAt(NameSlw).GetObject(OpenMode.ForRead), DBDictionary)
                For Each lentr As DictionaryEntry In pDict
                    Dim lname As String = CStr(lentr.Key)
                    Dim lobj As ObjectId = CType(lentr.Value, ObjectId)
                    Dim lXreciord As Xrecord = CType(ta.GetObject(lobj, OpenMode.ForRead), Xrecord)
                    Dim spStr As New List(Of String)
                    For Each ltv As TypedValue In lXreciord.Data
                        spStr.Add(CStr(ltv.Value))
                    Next
                    iSpNameZap.Add(lname)
                    Md.Add(spStr, lname)
                Next
            Else
                SystemKommand.SoobEditor(Me.ToString & " WseZapisIsSlowar " & NameSlw & " отсутствует словарь " & NameSlw)

            End If
            ta.Commit()
        End Using
        Return Md
    End Function
#End Region
	Private Sub UdalitZapis(ByVal NameZp As String)
		Dim pDict, PDictNew As DBDictionary    'Autodesk.AutoCAD.DatabaseServices.DBObject
		Dim pObejct As ObjectId

		'   Dim wDatabaseDwg As Database = Application.DocumentManager.MdiActiveDocument.Database
		Dim tm As DBTransMan = wDatabaseDwg.TransactionManager
		Using ta As Transaction = tm.StartTransaction()


			pDict = CType(ta.GetObject(wDatabaseDwg.NamedObjectsDictionaryId, OpenMode.ForWrite), DBDictionary)

			'       

			pObejct = pDict.GetAt(NameSlw)
			PDictNew = CType(pObejct.GetObject(OpenMode.ForWrite), DBDictionary)

			If PDictNew.Contains(NameZp) Then

				PDictNew.Remove(NameZp)
				'    tm.AddNewlyCreatedDBObject(Zap, True)
				ta.Commit()
			End If
		End Using
	End Sub
	Function IzZapis(inameZap As String) As Boolean
		Dim pDict, PDictNew As DBDictionary    'Autodesk.AutoCAD.DatabaseServices.DBObject
		Dim pObejct As ObjectId

		'   Dim wDatabaseDwg As Database = Application.DocumentManager.MdiActiveDocument.Database
		Dim tm As DBTransMan = wDatabaseDwg.TransactionManager
		Dim Lpr As Boolean
		Using ta As Transaction = tm.StartTransaction()


			pDict = CType(ta.GetObject(wDatabaseDwg.NamedObjectsDictionaryId, OpenMode.ForRead), DBDictionary)

			'       

			pObejct = pDict.GetAt(NameSlw)
			PDictNew = CType(pObejct.GetObject(OpenMode.ForRead), DBDictionary)

			Lpr = PDictNew.Contains(inameZap)


			ta.Commit()

		End Using
		Return Lpr
	End Function
	Function ZapisW_Slowar(ByVal NameZp As String, ByVal Danr() As TypedValue) As Boolean
        Dim pDict, PDictNew As DBDictionary    'Autodesk.AutoCAD.DatabaseServices.DBObject
        Dim pObejct As ObjectId
        Dim pr As Boolean = True
		Dim Zap As Xrecord
		'	If IzZapis(NameZp) Then UdalitZapis(NameZp)
		Dim tm As DBTransMan = wDatabaseDwg.TransactionManager
		Dim ta As Transaction = tm.StartTransaction()


        pDict = CType(ta.GetObject(wDatabaseDwg.NamedObjectsDictionaryId, OpenMode.ForWrite), DBDictionary)

        '        {"eLockViolation"}
        If pDict.Contains(NameSlw) Then
            pObejct = pDict.GetAt(NameSlw)
            PDictNew = CType(pObejct.GetObject(OpenMode.ForWrite), DBDictionary)
        Else
            PDictNew = New DBDictionary
            PDictNew = CType(pDict.SetAt(NameSlw, PDictNew).GetObject(OpenMode.ForWrite), DBDictionary)
            tm.AddNewlyCreatedDBObject(PDictNew, True)
        End If
        Try
            Zap = SozdatXrecord(Danr)
            '           Mprov = LeseXrecord(Zap)
            PDictNew.SetAt(NameZp, Zap)
            tm.AddNewlyCreatedDBObject(Zap, True)
            ta.Commit()
        Catch ex As InvalidOperationException
            Application.ShowAlertDialog("Me.ZapisW_Slowar " & "исключение")
            pr = False
            Exit Try
        Catch ex As Exception
            Application.ShowAlertDialog(Me.ToString & "ZapisW_Slowar" & " что то не то" & ex.GetType.ToString & vbCrLf & ex.Message)
            pr = False
            Exit Try
        Finally
            ' MsgBox("Final")
            ta.Dispose()

        End Try




        Return pr
    End Function
    ''' <summary>
    ''' записывает в словарь массив строк
    ''' </summary>
    ''' <param name="nameZap"> Имя записи </param>
    ''' <param name="msStr"> Записываемый массив строк </param>
    ''' <returns>Возвращает истину в случае удачной записи </returns>
    ''' <remarks></remarks>
    Function ZapisW_SlowarStr(ByVal nameZap As String, ByVal msStr() As String) As Boolean
        Dim Razmparam As Integer
        If msStr Is Nothing Then
            UdalitZapis(nameZap)
            Return False
        End If
        Dim Dann() As TypedValue
        Try
            Razmparam = UBound(msStr)
        Catch ex As Exception
            RazmParam = 0
            ReDim msStr(Razmparam)
            msStr(0) = ""
        End Try


        ReDim Dann(Razmparam)
        For I = 0 To RazmParam
            Dann(I) = New TypedValue(CInt(DxfCode.Text), msStr(I))
        Next
        Return ZapisW_Slowar(nameZap, Dann)



    End Function
    ''' <summary>
    ''' чтение из словаря массива строк
    ''' </summary>
    ''' <param name="NameZap"> Имя записи </param>
    ''' <returns> Возвращает массив строк сохраняемый в записи</returns>
    ''' <remarks></remarks>
    Function ZapisIzSlovarStr(ByVal NameZap As String) As String()

        Dim Danwh() As TypedValue
        Dim I, RazmParam As Integer
        Danwh = ZapisIsSlowar(NameZap) 'Считали что записано в словаре 
        If Danwh Is Nothing Then Return Nothing
        Try
            RazmParam = Danwh.Length - 1
        Catch ex As System.ArgumentNullException
            RazmParam = -1
        Catch ex As Exception
            Application.ShowAlertDialog(Me.ToString & "ZapisIzSlovarStr  " & ex.Message)
            RazmParam = -1
        End Try

        Dim SwFile() As String = Nothing  'переносим из буфера записи в массив строк
        If RazmParam > -1 Then
            ReDim SwFile(RazmParam)
            For I = 0 To RazmParam
                SwFile(I) = CStr(Danwh(I).Value)
            Next

        End If
        Return SwFile
    End Function
    Public Sub New()
        NameSlw = "SlowarDef"
        wDatabaseDwg = Application.DocumentManager.MdiActiveDocument.Database
    End Sub
    Public Sub New(ByVal Nam As String)
        NameSlw = Nam
        wDatabaseDwg = Application.DocumentManager.MdiActiveDocument.Database
    End Sub
End Class
''' <summary>
''' Класс для записи,чтения из словаря коллекции строк
''' </summary>
''' <remarks></remarks>
Public Class dwgSlowarMas
    'записывает и возвращает в словарь коллекции массивов строк
    Inherits dwgSlowar
    Private wKorenImeniZapisi As String
    Private Function ImjZapisi(ByVal I As Integer) As String
        Return Trim(wKorenImeniZapisi & I)
    End Function
    Public Sub New(ByVal iSlowar As String, ByVal iKorenImeniZapis As String)
        MyBase.New(iSlowar)
        wKorenImeniZapisi = iKorenImeniZapis
    End Sub
    Private Function MasStr(ByVal mas() As TypedValue) As String()
        Dim MaxIndex, i As Integer
        MaxIndex = UBound(mas)
        Dim wr(MaxIndex) As String
        For i = 0 To MaxIndex
            wr(i) = CStr(mas(i).Value)
        Next
        Return wr
    End Function
    Private Function StrMas(ByVal mStr() As String) As TypedValue()
        Dim MaxIndex, i As Integer
        MaxIndex = UBound(mStr)
        Dim wr(MaxIndex) As TypedValue
        For i = 0 To MaxIndex
            wr(i) = New TypedValue(DxfCode.Text, mStr(i))
        Next
        Return wr
    End Function
    Public Function CollectionIsSlowar(Optional ByVal MaxNum As Integer = 2000000000) As Collection

        Dim pDict As DBDictionary     'Autodesk.AutoCAD.DatabaseServices.DBObject
        Dim ZapId As ObjectId
        Dim Zap As Xrecord
        Dim Md() As TypedValue = Nothing
        Dim rezcoll As New Collection
        If MaxNum < 0 Then Return rezcoll

        '  Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database
        Dim tm As DBTransMan = wDatabaseDwg.TransactionManager
        Using ta As Transaction = tm.StartTransaction()

            pDict = CType(ta.GetObject(wDatabaseDwg.NamedObjectsDictionaryId, OpenMode.ForRead), DBDictionary)
            If pDict.Contains(NameSlw) Then
                pDict = CType(pDict.GetAt(NameSlw).GetObject(OpenMode.ForRead), DBDictionary)
                Dim I As Integer = 0
                '  Application.ShowAlertDialog("Записей в словаре " & pDict.Count)
                Do
                    Dim NameZ As String = ImjZapisi(I)
                    If pDict.Contains(NameZ) Then
                        '  Application.ShowAlertDialog("zapis " & NameZap & " find")
                        ZapId = pDict.GetAt(NameZ)
                        Zap = CType(ZapId.GetObject(OpenMode.ForRead), Xrecord)
                        Md = LeseXrecord(Zap)

                        rezcoll.Add(MasStr(Md))
                        I += 1
                    Else
                        Md = Nothing

                    End If
                Loop Until Md Is Nothing Or I > MaxNum
            Else
                Application.ShowAlertDialog("Словарь " & NameSlw & "отсутствует")


            End If

            ta.Commit()

        End Using
        Return rezcoll

    End Function
    Function Collection_W_Slowar(ByVal CollStr As Collection) As Boolean
        Dim pDict, PDictNew As DBDictionary    'Autodesk.AutoCAD.DatabaseServices.DBObject
        Dim pObejct As ObjectId
        Dim pr As Boolean = True
        Dim Zap As Xrecord
        '        Dim Mprov() As TypedValue

        '   Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database
        Dim tm As DBTransMan = wDatabaseDwg.TransactionManager
        Dim ta As Transaction = tm.StartTransaction()


        pDict = CType(ta.GetObject(wDatabaseDwg.NamedObjectsDictionaryId, OpenMode.ForWrite), DBDictionary)
        '        {"eLockViolation"}
        If pDict.Contains(NameSlw) Then
            pObejct = pDict.GetAt(NameSlw)
            PDictNew = CType(pObejct.GetObject(OpenMode.ForWrite), DBDictionary)
        Else
            PDictNew = New DBDictionary
            PDictNew = CType(pDict.SetAt(NameSlw, PDictNew).GetObject(OpenMode.ForWrite), DBDictionary)
            tm.AddNewlyCreatedDBObject(PDictNew, True)
        End If
        Dim I As Integer = 0
        For Each elS() As String In CollStr
            Dim Danr() As TypedValue = StrMas(elS)
            Try
                Zap = SozdatXrecord(Danr)
                '           Mprov = LeseXrecord(Zap)
                PDictNew.SetAt(ImjZapisi(I), Zap)
                tm.AddNewlyCreatedDBObject(Zap, True)

            Catch ex As InvalidOperationException
                Application.ShowAlertDialog("Me.ZapisW_Slowar " & "исключение")
                pr = False
                Exit Try
            Catch ex As Exception
                Application.ShowAlertDialog(Me.ToString & "ZapisW_Slowar" & " что то не то" & ex.GetType.ToString & vbCrLf & ex.Message)
                pr = False
                Exit Try
            Finally
                ' MsgBox("Final")

            End Try
            I += 1
        Next
        ta.Commit()
        ta.Dispose()

        Return pr
    End Function

End Class


