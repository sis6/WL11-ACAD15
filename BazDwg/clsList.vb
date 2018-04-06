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
'Imports AcAp = Autodesk.AutoCAD.ApplicationServices.Application

Public Class clsList
   
    ''' <summary>
    ''' Если листа нет то он создаеться
    ''' </summary>
    ''' <param name="iname"> имя листа </param>
    ''' <param name="iPrSozdanijViewPort"> если True то при создании листа создаеться вид </param>
    ''' <remarks></remarks>
    Public Shared Sub CreateLayot(iname As String, iPrSozdanijViewPort As Boolean)

        Dim ed As Editor = Application.DocumentManager.MdiActiveDocument.Editor
        Dim db As Database = HostApplicationServices.WorkingDatabase
        db.TileMode = False
        Try

            Using tr As Transaction = db.TransactionManager.StartTransaction()

                Dim layouts As DBDictionary = tr.GetObject(db.LayoutDictionaryId, OpenMode.ForWrite)



				If layouts.Contains(iname) Then GoTo kon
                Dim layoutId As ObjectId = LayoutManager.Current.CreateLayout(iname)
                LayoutManager.Current.CurrentLayout = iname



                If Not iPrSozdanijViewPort Then GoTo kon


                ' определяем  the maximum viewport size
                Dim lay As Layout = tr.GetObject(layoutId, OpenMode.ForWrite)
                '   Point2d()
                Dim minPt, maxPt, pSize As Point2d
                minPt = lay.PlotPaperMargins.MinPoint
                maxPt = lay.PlotPaperMargins.MaxPoint
                pSize = lay.PlotPaperSize
                Dim width, height As Double
                If lay.PlotRotation / 2 = 0 Then

                    width = pSize.X - maxPt.X - minPt.X
                    height = pSize.Y - maxPt.Y - minPt.Y

                Else

                    width = pSize.Y - maxPt.Y - minPt.Y
                    height = pSize.X - maxPt.X - minPt.X

                End If
                ' add the viewport to the layout BlockTableRecord
                Dim btr As BlockTableRecord = tr.GetObject(lay.BlockTableRecordId, OpenMode.ForWrite)
                Dim vp As Viewport = New Viewport()
                vp.Width = width
                vp.Height = height
                vp.CenterPoint = New Point3d(width / 2.0, height / 2.0, 0.0)
                btr.AppendEntity(vp)
                tr.AddNewlyCreatedDBObject(vp, True)
kon:            tr.Commit()
            End Using
        Catch ex As System.Exception

            ed.WriteMessage("\nError: " + ex.Message)

        End Try

    End Sub
    ''' <summary>
    ''' копирует существующий лист с новым именем если его нет
    ''' </summary>
    ''' <param name="CopyName">имя копируемого листа  </param>
    ''' <param name="newName"> новое имя</param>
    ''' <returns> Возвращает true если лист скопирован или существует лист с таким именем и false лист для копирования отсутствует в чертеже </returns>
    ''' <remarks></remarks>
    Public Shared Function CopyLayout(CopyName As String, newName As String) As Boolean
        Dim db As Database = HostApplicationServices.WorkingDatabase
        Using trx As Transaction = db.TransactionManager.StartTransaction() 'трансакция в текущем файле
            Dim acLayoutMgr As LayoutManager = LayoutManager.Current
            Dim layouts As DBDictionary = trx.GetObject(db.LayoutDictionaryId, OpenMode.ForWrite)
            If Not layouts.Contains(CopyName) Then Return False
            If Not layouts.Contains(newName) Then
                acLayoutMgr.CopyLayout(CopyName, newName)
                trx.Commit()
            End If

        End Using
        Return True
    End Function
    ''' <summary>
    ''' копирование параметров листа 
    ''' </summary>
    ''' <param name="NameFile"></param>
    ''' <param name="NameList"></param>
    ''' <remarks></remarks>
    Public Shared Function CopyExternalLayout(NameFile As String, NameList As String) As Boolean
        '("C:\Test\PageSetup.dwg"
        Dim db As Database = HostApplicationServices.WorkingDatabase
        Dim stdDb As Database = New Database()   'база данных внешнего файла
        stdDb.ReadDwgFile(NameFile, FileOpenMode.OpenForReadAndAllShare, False, "") 'чтение данных внешнего файла

        Using trx As Transaction = db.TransactionManager.StartTransaction() 'трансакция в текущем файле
            Using stdTrx As Transaction = stdDb.TransactionManager.StartTransaction()  'транс акция во внешнем файле

                Dim stdLayoutDictionary As DBDictionary = stdDb.LayoutDictionaryId.GetObject(OpenMode.ForRead)    'словарь листов внешнего файла
                If Not stdLayoutDictionary.Contains(NameList) Then Return False
                Dim stdLayout As Layout = stdLayoutDictionary.GetAt(NameList).GetObject(OpenMode.ForRead) 'выбор листа во внешнем файле для копировани

                Dim LayoutDictionare As DBDictionary = db.LayoutDictionaryId.GetObject(OpenMode.ForRead)
                If LayoutDictionare.Contains(NameList) Then Return True

                Dim layoutId As ObjectId = LayoutManager.Current.CreateLayout(NameList) 'добавили лист с таким именем
                LayoutManager.Current.CurrentLayout = NameList  ' сделали его текущим 

                Dim paperspace As BlockTableRecord = SymbolUtilityServices.GetBlockPaperSpaceId(db).GetObject(OpenMode.ForRead) 'запись в таблице блоков в текущем файле 
                Dim layout As Layout = paperspace.LayoutId.GetObject(OpenMode.ForWrite) 'текущий лист в текущем файле

                'For Each el As ObjectId In layout.GetViewports() 'удаляем лишние VPort
                '    Dim elpr As Viewport = trx.GetObject(el, OpenMode.ForWrite)
                '    elpr.Erase()
                'Next
                layout.CopyFrom(stdLayout) 'копируем параметры  листа
                '    layout.LayoutName = stdLayout.LayoutName
            End Using

            trx.Commit()

        End Using
        Return True
    End Function
#Region "List"
    Public Sub NewNameTekList(ByVal NewName As String)
        '' Get the current document and database, and start a transaction
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database

        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()

            Dim acLayoutMgr As LayoutManager = LayoutManager.Current

            '' Возьмем текущий лист
            Dim acLayout As Layout = acTrans.GetObject(acLayoutMgr.GetLayoutId(acLayoutMgr.CurrentLayout), OpenMode.ForRead)



            acDoc.Editor.WriteMessage(vbLf & "NewNameTekList  Текуший лист: " & acLayout.LayoutName)




            acLayout.UpgradeOpen()    ' откроем для обновления
            acLayout.LayoutName = NewName

            '' Output the name of the new device assigned to the layout
            acDoc.Editor.WriteMessage(vbLf & "NewNameTekList   имя листа: " & acLayout.LayoutName)


            '' Зафиксируем изменения в БД чертежа
            acTrans.Commit()
        End Using
    End Sub
    ''' <summary>
    ''' Определяем имя блока сответствующего листа
    ''' </summary>
    ''' <param name="NameList">наименование листа  </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function nameBlockLista(ByVal NameList As String) As String

        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database

        Dim wNameBl As String = ""
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()

            Dim acLayoutMgr As LayoutManager = LayoutManager.Current '' Получаем the Layout Manager


            '' Get the current layout and output its name in the Command Line window
            Dim acLayout As Layout = Nothing
            Try
                acLayout = acTrans.GetObject(acLayoutMgr.GetLayoutId(NameList), OpenMode.ForRead) 'Получаем объект лист
                Dim BlockTableRecordOlayuot As BlockTableRecord = acTrans.GetObject(acLayout.BlockTableRecordId, OpenMode.ForRead)
                wNameBl = BlockTableRecordOlayuot.Name
            Catch ex As Exception
                Application.ShowAlertDialog(" NameblockLista  Лист " & NameList & vbCrLf & ex.Message)
            End Try



            acTrans.Commit()
        End Using
        Return wNameBl
    End Function
    Shared Sub ListTek(ByVal NameList As String)
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database

        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
            '' Reference the Layout Manager
            Dim acLayoutMgr As LayoutManager
            acLayoutMgr = LayoutManager.Current

            '' Get the current layout and output its name in the Command Line window
            Try
                acLayoutMgr.CurrentLayout = NameList
            Catch ex As Exception
                Application.ShowAlertDialog("Kommand:ListTek Лист  " & NameList & " не установлен " & vbCr & ex.Message)
            End Try






            '' Save the new objects to the database
            acTrans.Commit()
        End Using

    End Sub
    ''' <summary>
    ''' Ввозвращает колекцию имен листов, выводит в файл протокола отчет в виде "Имя" "Тип" "Имя блока"
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function ListDwg() As Collection
        '' Get the current document and database, and start a transaction
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        Dim Str_oth As String = "Kommand:ListDwg Листы " & vbCrLf
        Dim NameLists As New Collection
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()

            Dim D As DBDictionary
            Dim Dinum As DbDictionaryEnumerator


            D = acTrans.GetObject(acCurDb.LayoutDictionaryId, OpenMode.ForRead)



            Dinum = D.GetEnumerator

            Do While Dinum.MoveNext()
                ' MsgBox("S " & "k " &  & "  Z  " & )
                Str_oth = Str_oth & " Name " & Dinum.Key & " Tip " & Dinum.Value.ObjectClass.DxfName & vbCrLf & nameBlockLista(Dinum.Key) & vbCrLf
                If Dinum.Key <> "Model" Then
                    NameLists.Add(Dinum.Key)
                End If

            Loop

            '' Get a copy of the PlotSettings from the layout


            acTrans.Commit()
        End Using
        SystemKommand.SoobEditor(Str_oth)
        Return NameLists
    End Function
    Shared Function SpisokLayoutImen() As List(Of String)
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database

        Dim lNameLists As New List(Of String)
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()

            Dim D As DBDictionary
            Dim Dinum As DbDictionaryEnumerator


            D = acTrans.GetObject(acCurDb.LayoutDictionaryId, OpenMode.ForRead)



            Dinum = D.GetEnumerator

            Do While Dinum.MoveNext()
               
                If Dinum.Key <> "Model" Then
                    lNameLists.Add(Dinum.Key)
                End If

            Loop

            '' Get a copy of the PlotSettings from the layout


            acTrans.Commit()
        End Using

        Return lNameLists
    End Function
#End Region


End Class
