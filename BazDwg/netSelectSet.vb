

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



Public Class netSelectSet
    Shared Function WibratNaSloiWmodele(ByVal NameSl As String) As ObjectId()
        Dim acDocEd As Editor = Application.DocumentManager.MdiActiveDocument.Editor
        Dim acTypValAr(1) As TypedValue

        acTypValAr.SetValue(New TypedValue(DxfCode.LayerName, NameSl), 0)
        acTypValAr.SetValue(New TypedValue(DxfCode.LayoutName, "Model"), 1)
        Dim acSelFtr As SelectionFilter = New SelectionFilter(acTypValAr)
        Dim acSSPrompt As PromptSelectionResult
        acSSPrompt = acDocEd.SelectAll(acSelFtr)
        If acSSPrompt.Status = PromptStatus.OK Then
            Dim acSSet As SelectionSet = acSSPrompt.Value
            ' Application.ShowAlertDialog("Kommand:WibratAll " & "Количество выбранных объектов: " & acSSet.Count.ToString())

            Return acSSet.GetObjectIds()
        Else
            '    Application.ShowAlertDialog("Kommand:WibratAll " & "Количество выбранных объектов: 0")
        End If
        Return Nothing

    End Function

    ''' <summary>
    ''' Выбирает все элементы заданого типа на заданом слое в пространстве модели
    ''' </summary>
    ''' <param name="NameSl"> заданый слой </param>
    ''' <param name="NameElem"> тип элемента DXF </param>
    ''' <returns> Возвращает массив объектных ИД </returns>
    ''' <remarks></remarks>
    Shared Function WibratNaSloiWmodeleElement(ByVal NameSl As String, ByVal NameElem As String) As ObjectId()
        Dim acDocEd As Editor = Application.DocumentManager.MdiActiveDocument.Editor
        Dim acTypValAr(2) As TypedValue
        acTypValAr.SetValue(New TypedValue(DxfCode.Start, NameElem), 0)
        acTypValAr.SetValue(New TypedValue(DxfCode.LayerName, NameSl), 1)
        acTypValAr.SetValue(New TypedValue(DxfCode.LayoutName, "Model"), 2)
        Dim acSelFtr As SelectionFilter = New SelectionFilter(acTypValAr)
        Dim acSSPrompt As PromptSelectionResult
        acSSPrompt = acDocEd.SelectAll(acSelFtr)
        If acSSPrompt.Status = PromptStatus.OK Then
            Dim acSSet As SelectionSet = acSSPrompt.Value
            ' Application.ShowAlertDialog("Kommand:WibratAll " & "Количество выбранных объектов: " & acSSet.Count.ToString())
            Return acSSet.GetObjectIds()
        Else
            '    Application.ShowAlertDialog("Kommand:WibratAll " & "Количество выбранных объектов: 0")
        End If
        Return Nothing

    End Function
    Shared Function WibratNaSloiWmodeleWstawkiBlock(ByVal NameSl As String, ByVal NameBlock As String) As ObjectId()
        Dim acDocEd As Editor = Application.DocumentManager.MdiActiveDocument.Editor
        Dim acTypValAr(2) As TypedValue
        acTypValAr.SetValue(New TypedValue(DxfCode.BlockName, NameBlock), 0)
        acTypValAr.SetValue(New TypedValue(DxfCode.LayerName, NameSl), 1)
        acTypValAr.SetValue(New TypedValue(DxfCode.LayoutName, "Model"), 2)
        Dim acSelFtr As SelectionFilter = New SelectionFilter(acTypValAr)
        Dim acSSPrompt As PromptSelectionResult
        acSSPrompt = acDocEd.SelectAll(acSelFtr)
        If acSSPrompt.Status = PromptStatus.OK Then
            Dim acSSet As SelectionSet = acSSPrompt.Value
            ' Application.ShowAlertDialog("Kommand:WibratAll " & "Количество выбранных объектов: " & acSSet.Count.ToString())
            Return acSSet.GetObjectIds()
        Else
            '    Application.ShowAlertDialog("Kommand:WibratAll " & "Количество выбранных объектов: 0")
        End If
        Return Nothing

    End Function
    Shared Function WibratNaSloiWmodeleElement(ByVal NameSl As String, ByVal NameElem As String, NameElem1 As String) As ObjectId()
        Dim acDocEd As Editor = Application.DocumentManager.MdiActiveDocument.Editor
        Dim acTypValAr(5) As TypedValue
        acTypValAr.SetValue(New TypedValue(DxfCode.Operator, "<OR"), 0)
        acTypValAr.SetValue(New TypedValue(DxfCode.Start, NameElem), 1)
        acTypValAr.SetValue(New TypedValue(DxfCode.Start, NameElem1), 2)
        acTypValAr.SetValue(New TypedValue(DxfCode.Operator, "OR>"), 3)
        acTypValAr.SetValue(New TypedValue(DxfCode.LayerName, NameSl), 4)
        acTypValAr.SetValue(New TypedValue(DxfCode.LayoutName, "Model"), 5)
        Dim acSelFtr As SelectionFilter = New SelectionFilter(acTypValAr)
        Dim acSSPrompt As PromptSelectionResult
        acSSPrompt = acDocEd.SelectAll(acSelFtr)
        If acSSPrompt.Status = PromptStatus.OK Then
            Dim acSSet As SelectionSet = acSSPrompt.Value
            ' Application.ShowAlertDialog("Kommand:WibratAll " & "Количество выбранных объектов: " & acSSet.Count.ToString())
            Return acSSet.GetObjectIds()
        Else
            '    Application.ShowAlertDialog("Kommand:WibratAll " & "Количество выбранных объектов: 0")
        End If
        Return Nothing

    End Function
    Shared Function WibratNaSloiWmodeleElementNaLinii(ByVal NameSl As String, ByVal NameElem As String, IPointBeg As Point3d, iPointEnd As Point3d) As ObjectId()
        Dim acDocEd As Editor = Application.DocumentManager.MdiActiveDocument.Editor
        Dim acTypValAr(2) As TypedValue
        Dim lLinij As New Point3dCollection
        'Установка линии
        lLinij.Add(IPointBeg)
        lLinij.Add(iPointEnd)
        'Установка фильтра
        acTypValAr.SetValue(New TypedValue(DxfCode.Start, NameElem), 0)
        acTypValAr.SetValue(New TypedValue(DxfCode.LayerName, NameSl), 1)
        acTypValAr.SetValue(New TypedValue(DxfCode.LayoutName, "Model"), 2)
        Dim acSelFtr As SelectionFilter = New SelectionFilter(acTypValAr)

        Dim acSSPrompt As PromptSelectionResult
        acSSPrompt = acDocEd.SelectFence(lLinij, acSelFtr)
        If acSSPrompt.Status = PromptStatus.OK Then
            Dim acSSet As SelectionSet = acSSPrompt.Value
            ' Application.ShowAlertDialog("Kommand:WibratAll " & "Количество выбранных объектов: " & acSSet.Count.ToString())
            Return acSSet.GetObjectIds()
        Else
            '    Application.ShowAlertDialog("Kommand:WibratAll " & "Количество выбранных объектов: 0")
        End If
        Return Nothing

    End Function

    Private Shared Function WibratNaSloe(ByVal Namesl As String) As ObjectIdCollection
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        Dim rez As New ObjectIdCollection
        '' Start a transaction
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()


            Dim acSSPrompt As PromptSelectionResult = acDoc.Editor.GetSelection()


            If acSSPrompt.Status = PromptStatus.OK Then

                Dim acSSet As SelectionSet = acSSPrompt.Value


                For Each acSSObj As SelectedObject In acSSet



                    If Not IsDBNull(acSSObj) Then

                        '' Open the selected object for write

                        Dim acEnt As Entity = acTrans.GetObject(acSSObj.ObjectId, OpenMode.ForWrite)



                        If Not IsDBNull(acEnt) And acEnt.Layer = Namesl Then


                            rez.Add(acSSObj.ObjectId)


                        End If

                    End If

                Next



                '' Save the new object to the database

                acTrans.Commit()


            End If



            '' Dispose of the transaction

        End Using
        Return rez
    End Function
    ''' <summary>
    ''' Выбирает все элементы заданого типа на заданом слое в чертеже
    ''' </summary>
    ''' <param name="iNamesloj"> заданый слой </param>
    ''' <param name="iNameElement"> тип элемента DXF </param>
    ''' <returns> Возвращает  объект выбора </returns>
    ''' <remarks></remarks>
    Shared Function WibratNaSloeElement(ByVal iNamesloj As String, iNameElement As String) As SelectionSet
        Dim acDocEd As Editor = Application.DocumentManager.MdiActiveDocument.Editor ''Получение редактора текущего документа
        '' Создание массива TypedValue для определение критериев фильтра  
        Dim acTypValAr(1) As TypedValue
        acTypValAr.SetValue(New TypedValue(DxfCode.LayerName, iNamesloj), 0)
        acTypValAr.SetValue(New TypedValue(DxfCode.Start, iNameElement), 1)
        '' Назначение критериев фильтра объекту SelectionFilter  17:    
        Dim acSelFtr As SelectionFilter = New SelectionFilter(acTypValAr)
        '' Запрос выбора объектов на чертеже  20:  
        Dim acSSPrompt As PromptSelectionResult = acDocEd.SelectAll(acSelFtr)
        '' Если статус запрса OK, объекты выбраны
        If acSSPrompt.Status = PromptStatus.OK Then
            Dim acSSet As SelectionSet = acSSPrompt.Value
            ' Application.ShowAlertDialog("netSelectSet:WibratNaSloeElementl " & "Количество выбранных объектов: " & acSSet.Count.ToString())
            Return acSSet
        Else
            ' Application.ShowAlertDialog("netSelectSet:WibratNaSloeElementl " & "Количество выбранных объектов: " & acSSet.Count.ToString())

            Return Nothing
        End If

    End Function
    ''' <summary>
    ''' Выбираем в заданом листе вставки блоков 
    ''' </summary>
    ''' <param name="inamelayout"> имя заданого листа </param>
    ''' <returns> возвращает объект выбора </returns>
    ''' <remarks></remarks>
    Shared Function WibratWListestawkiBlokow(inamelayout As String) As SelectionSet
        ''Получение редактора текущего документа
        Dim acDocEd As Editor = Application.DocumentManager.MdiActiveDocument.Editor
        '' Создание массива TypedValue для определение критериев фильтра  
        Dim acTypValAr(1) As TypedValue
        acTypValAr.SetValue(New TypedValue(DxfCode.Start, "INSERT"), 0)
        acTypValAr.SetValue(New TypedValue(DxfCode.LayoutName, inamelayout), 1)
        '  acTypValAr.SetValue(New TypedValue(DxfCode.BlockName, iNameBlock), 1)
        '' Назначение критериев фильтра объекту SelectionFilter  17:    
        Dim acSelFtr As SelectionFilter = New SelectionFilter(acTypValAr)

        '' Запрос выбора объектов на чертеже  20:  
        Dim acSSPrompt As PromptSelectionResult
        '  acSSPrompt = acDocEd.SelectCrossingPolygon(iPolyGon, acSelFtr)
        acSSPrompt = acDocEd.SelectAll(acSelFtr)   '
        '' Если статус запрса OK, объекты выбраны
        If acSSPrompt.Status = PromptStatus.OK Then

            Dim acSSet As SelectionSet = acSSPrompt.Value
            '            Application.ShowAlertDialog("Количество выбранных объектов: " & _
            'acSSet.Count.ToString())
            Return acSSet
        Else
            'Application.ShowAlertDialog("Количество выбранных объектов: 0" & acSSPrompt.Status)

            Return Nothing
        End If

    End Function
    Public Shared Sub FilterSelectionSet(ByVal iPt1 As Point3d, ByVal ipt2 As Point3d, ByVal iNameSl As String)
        ''Получение редактора текущего документа
        Dim acDocEd As Editor = Application.DocumentManager.MdiActiveDocument.Editor
        '' Создание массива TypedValue для определение критериев фильтра  
        Dim acTypValAr(0) As TypedValue
        acTypValAr.SetValue(New TypedValue(DxfCode.LayerName, iNameSl), 0)
        '' Назначение критериев фильтра объекту SelectionFilter  17:    
        Dim acSelFtr As SelectionFilter = New SelectionFilter(acTypValAr)

        '' Запрос выбора объектов на чертеже  20:  
        Dim acSSPrompt As PromptSelectionResult
        '  acSSPrompt = acDocEd.SelectCrossingPolygon(iPolyGon, acSelFtr)
        acSSPrompt = acDocEd.SelectCrossingWindow(iPt1, ipt2, acSelFtr)
        '' Если статус запрса OK, объекты выбраны
        If acSSPrompt.Status = PromptStatus.OK Then
            Dim acSSet As SelectionSet = acSSPrompt.Value
            Application.ShowAlertDialog("Количество выбранных объектов: " & _
acSSet.Count.ToString())
        Else
            Application.ShowAlertDialog("Количество выбранных объектов: 0")


        End If
    End Sub
    Private Shared Sub OchistitNabor(inabor As SelectionSet)
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Using acTrans As Transaction = acDoc.Database.TransactionManager.StartTransaction()
            For Each el As SelectedObject In inabor
                If Not IsDBNull(el) Then
                    Try

                        Dim lEnt As Entity = acTrans.GetObject(el.ObjectId, OpenMode.ForWrite)
                        lEnt.Erase()
                    Catch ex As Exception
                        Continue For

                    End Try

                End If
            Next
            acTrans.Commit()
        End Using
    End Sub
    Shared Function Mejdu(iX As Double, iXb As Double, iXe As Double) As Boolean
        Return iX > iXb AndAlso iX < iXe
    End Function
    Private Shared Sub OchistitNabor(inabor As SelectionSet, iXb As Double, iXe As Double)
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Using acTrans As Transaction = acDoc.Database.TransactionManager.StartTransaction()
            For Each el As SelectedObject In inabor
                If Not IsDBNull(el) Then
                    Try

                        Dim lEnt As Entity = acTrans.GetObject(el.ObjectId, OpenMode.ForWrite)
                        Dim lXe = lEnt.GeometricExtents.MaxPoint.X
                        Dim lXb = lEnt.GeometricExtents.MinPoint.X
                        If lXe < lXb Then
                            lXe = lXb
                            lXb = lEnt.GeometricExtents.MaxPoint.X
                        End If
                        If Mejdu(lXb, iXb, iXe) OrElse Mejdu(lXe, iXb, iXe) Then

                            lEnt.Erase()
                        End If
                    Catch ex As Exception
                        Continue For

                    End Try

                End If
            Next
            acTrans.Commit()
        End Using
    End Sub

    'Private Sub OchistitObjectIdCollection(iObjectIdColl As ObjectIdCollection)
    '    Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
    '    Using acTrans As Transaction = acDoc.Database.TransactionManager.StartTransaction()
    '        For Each el As ObjectId In iObjectIdColl

    '            Try
    '                Dim lEnt = el.GetObject(OpenMode.ForWrite)
    '                lEnt.Erase()
    '            Catch ex As Exception
    '                Continue For

    '            End Try


    '        Next
    '        acTrans.Commit()
    '    End Using
    'End Sub
    Shared Sub OchistitSloj(iNameSloj As String)
        ''Получение редактора текущего документа
        Dim acDocEd As Editor = Application.DocumentManager.MdiActiveDocument.Editor
        '' Создание массива TypedValue для определение критериев фильтра  
        Dim acTypValAr(0) As TypedValue
        acTypValAr.SetValue(New TypedValue(DxfCode.LayerName, iNameSloj), 0)
        '' Назначение критериев фильтра объекту SelectionFilter  17:    
        Dim acSelFtr As SelectionFilter = New SelectionFilter(acTypValAr)

        '' Запрос выбора объектов на чертеже  20:  
        Dim acSSPrompt As PromptSelectionResult
        '  acSSPrompt = acDocEd.SelectCrossingPolygon(iPolyGon, acSelFtr)
        acSSPrompt = acDocEd.SelectAll(acSelFtr)
        '' Если статус запрса OK, объекты выбраны
        If acSSPrompt.Status = PromptStatus.OK Then
            Dim acSSet As SelectionSet = acSSPrompt.Value

            OchistitNabor(acSSet)

        End If
    End Sub
    Shared Sub OchistitSloj(iNameSloj As String, iXb As Double, iXe As Double)
        ''Получение редактора текущего документа
        Dim acDocEd As Editor = Application.DocumentManager.MdiActiveDocument.Editor
        '' Создание массива TypedValue для определение критериев фильтра  
        Dim acTypValAr(0) As TypedValue
        acTypValAr.SetValue(New TypedValue(DxfCode.LayerName, iNameSloj), 0)
        '' Назначение критериев фильтра объекту SelectionFilter  17:    
        Dim acSelFtr As SelectionFilter = New SelectionFilter(acTypValAr)

        '' Запрос выбора объектов на чертеже  20:  
        Dim acSSPrompt As PromptSelectionResult
        '  acSSPrompt = acDocEd.SelectCrossingPolygon(iPolyGon, acSelFtr)
        acSSPrompt = acDocEd.SelectAll(acSelFtr)
        '' Если статус запрса OK, объекты выбраны
        If acSSPrompt.Status = PromptStatus.OK Then
            Dim acSSet As SelectionSet = acSSPrompt.Value

            OchistitNabor(acSSet, iXb, iXe)

        End If
    End Sub
    Public Function WibratEntityXdata(NameElem As String) As ObjectId()
        '' Получение редактора текущего документа
        Dim acDocEd As Editor = Application.DocumentManager.MdiActiveDocument.Editor

        '' Создание массива из TypedValue для определения критериев фильтра
        Dim acTypValAr(1) As TypedValue
        acTypValAr.SetValue(New TypedValue(DxfCode.Start, NameElem), 0)
        acTypValAr.SetValue(New TypedValue(DxfCode.ExtendedDataRegAppName, clsXDATA.regAppName), 1)

        '' Назначение критериев фильтра объекту SelectionFilter
        Dim acSelFtr As SelectionFilter = New SelectionFilter(acTypValAr)

        '' Запрос выбора объектов на чертеже
        Dim acSSPrompt As PromptSelectionResult
        acSSPrompt = acDocEd.GetSelection(acSelFtr)

        '' Если статус запроса ОК, объекты были выбраны
        If acSSPrompt.Status = PromptStatus.OK Then
            Dim acSSet As SelectionSet = acSSPrompt.Value
            Application.ShowAlertDialog("Количество выбранных объектов: " & _
                                           acSSet.Count.ToString())
            Return acSSet.GetObjectIds

        Else
            Application.ShowAlertDialog("Количество выбранных объектов: 0")
            Return Nothing
        End If

    End Function
End Class
