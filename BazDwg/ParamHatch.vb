#If ARX_APP Then
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.ApplicationServices
Imports DBTransMan = Autodesk.AutoCAD.DatabaseServices.TransactionManager
Imports Autodesk.AutoCAD.EditorInput
Imports Autodesk.AutoCAD.Colors
#Else
Imports Bricscad.ApplicationServices
Imports _AcBr = Teigha.BoundaryRepresentation
Imports Teigha.Colors
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

Public Class ParamHatch
    Private wPatternName As String
    Private wPatternScale, wPatternAngle As Double
    Private wLineWeight As LineWeight

    Sub New(iHatch As Hatch)

        wPatternScale = iHatch.PatternScale
        wPatternName = iHatch.PatternName
        wPatternAngle = iHatch.PatternAngle
        wLineWeight = iHatch.LineWeight
    End Sub
    Sub New(iPatternName As String, iPatternScale As Double, iPatternAngle As Double, iLineWeight As LineWeight)
        wLineWeight = iLineWeight
        wPatternScale = iPatternScale
        wPatternName = iPatternName
        wPatternAngle = iPatternAngle
    End Sub
    ReadOnly Property PatternName As String
        Get
            Return Strings.LCase(wPatternName)
        End Get
    End Property
    ReadOnly Property PatternScale As Double
        Get
            Return wPatternScale
        End Get
    End Property
    ReadOnly Property PatternAngle As Double
        Get
            Return wPatternAngle
        End Get
    End Property
	ReadOnly Property LineWeight As LineWeight
		Get
			Return wLineWeight
		End Get
	End Property
	ReadOnly Property StrOpis() As String
        Get
            Return wPatternName & " " & Format(wPatternScale, "f2") & " " & Format(wPatternAngle, "f2") & " " & CStr(wLineWeight)
        End Get
    End Property
    Function equalsParam(lhatch As Hatch) As Boolean

        Return lhatch.PatternName = wPatternName And lhatch.PatternScale.Equals(wPatternScale) And lhatch.PatternAngle.Equals(wPatternAngle)

    End Function
#Region "Shared"
    ''' <summary>
    ''' Создает штириховку по заданой коллекции точек 
    ''' </summary>
    ''' <param name="iNameLayer"> слой расположения штриховки  </param>
    ''' <param name="iColl"> коллекция точек границ штриховки </param>
    ''' <param name="wparamhatch">  параметры штриховки  </param>
    ''' <param name="icolor"> цвет штриховки </param>
    ''' <param name="icolorFon"> цвет фона штриховки </param>
    ''' <param name="iSlojPlline">  лауер ограничивающий   полилинии если пуст  - тот же лауер что и штриховка   </param>
    ''' <returns> возвращает объект штриховка </returns>
    ''' <remarks> 2016-12-7  для вывода консистенций</remarks>
    Shared Function CreatehatchPoParamHatch(iNameLayer As String, iColl As Point2dCollection, wparamhatch As ParamHatch, _
                                  Optional icolor As Integer = -1, Optional icolorFon As Integer = 0, Optional iSlojPlline As String = "") As Hatch

        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = doc.Database
        Dim ed As Editor = doc.Editor
        Dim oHatch As Hatch
        Using tx As Transaction = db.TransactionManager.StartTransaction
            Dim acBlkTbl As BlockTable
            acBlkTbl = CType(tx.GetObject(db.BlockTableId, _
                                         OpenMode.ForRead), BlockTable)
            Dim btr As BlockTableRecord = CType(tx.GetObject(acBlkTbl(BlockTableRecord.ModelSpace), OpenMode.ForWrite), BlockTableRecord)
            Dim i As Integer = 0
            Dim pline As New Polyline
            For Each el As Point2d In iColl
                pline.AddVertexAt(i, el, 0, 0, 0)
                i += 1
            Next
            If String.IsNullOrEmpty(iSlojPlline) Then
                pline.Layer = iNameLayer
            Else
                pline.Layer = iSlojPlline
            End If
            'pline.SetEndWidthAt(1, 0.2)
            'pline.SetStartWidthAt(1, 0.2)

            pline.Closed = True

            Dim pLineId As ObjectId


            pLineId = btr.AppendEntity(pline)


            tx.AddNewlyCreatedDBObject(pline, True)

            Dim objPolyline As New ObjectIdCollection
            objPolyline.Add(pLineId)

            'oHatch.

            oHatch = New Hatch()
            oHatch.SetDatabaseDefaults()
            oHatch.Normal = New Vector3d(0.0, 0.0, 1.0)
            oHatch.LineWeight = wparamhatch.LineWeight
            '    oHatch.PatternAngle = wparamhatch.PatternAngle

            oHatch.PatternScale = wparamhatch.PatternScale
            oHatch.PatternAngle = wparamhatch.PatternAngle
            oHatch.Origin = iColl(0)
            oHatch.SetHatchPattern(HatchPatternType.PreDefined, wparamhatch.PatternName)    'Strings.UCase(wparamhatch.PatternName)



            '  oHatch.Set = 1
            oHatch.Layer = iNameLayer

            If icolor > -1 Then
                If icolor = 0 Then
                    Dim lcolor = Color.FromColor(Drawing.Color.White)

                    oHatch.Color = lcolor
                Else
                    oHatch.ColorIndex = icolor
                End If


            End If


            If icolorFon > 0 Then
                Dim lcolor = Color.FromColor(Drawing.Color.White)

                oHatch.BackgroundColor = lcolor


            End If

            btr.AppendEntity(oHatch)


            tx.AddNewlyCreatedDBObject(oHatch, True)


            ' Вот теперь можно сделать штриховку ассоциативной

            oHatch.Associative = True


            oHatch.AppendLoop(HatchLoopTypes.Default, objPolyline)


            oHatch.EvaluateHatch(True)

            Dim block As BlockTableRecord = tx.GetObject(oHatch.BlockId, OpenMode.ForRead)

            Dim drawOrder As DrawOrderTable = tx.GetObject(block.DrawOrderTableId, OpenMode.ForWrite)

            Dim ids As New ObjectIdCollection
            Dim idsOp As New ObjectIdCollection
            idsOp.Add(pLineId)
            ids.Add(oHatch.ObjectId)
            drawOrder.MoveToBottom(ids)
            If icolorFon > 0 Then
                drawOrder.MoveToTop(ids)
                drawOrder.MoveToTop(idsOp)
            Else

            End If




            tx.Commit()

        End Using
        Return oHatch
    End Function
    Shared Function ProvVertikali(iLine As Line) As Boolean
        '      Dim lw = iLine.Angle
        If Math.Abs(iLine.StartPoint.X - iLine.EndPoint.X) < 0.01 Then
            Return True
        End If

        Return False
    End Function
    ''' <summary>
    ''' Создает штириховку по заданой коллекции точек 
    ''' </summary>
    ''' <param name="iLayerHatch"> слой расположения штриховки  </param>
    ''' <param name="iColl"> коллекция точек границ штриховки </param>
    ''' <param name="wparamhatch">  параметры штриховки  </param>
    ''' <param name=" iLayerGraniz">  лауер ограничивающий   полилинии если пуст  - тот же лауер что и штриховка   </param>
    ''' <param name="ilayerSlyjb">  лауер Служебный   </param>
    ''' <param name="icolor"> цвет штриховки </param>
    ''' <param name="icolorFon"> цвет фона штриховки </param>
    ''' <returns> возвращает объект штриховка, граница из отрезков вертикали в другом слое   </returns>
    ''' <remarks> 2016-12-7 </remarks>
    Private Shared Function CreatehatchPoParamHatchL(iLayerHatch As String, iColl As Point2dCollection, wparamhatch As ParamHatch, _
                                 iLayerGraniz As String, ilayerSlyjb As String, Optional icolor As Integer = -1, Optional icolorFon As Integer = 0) As Hatch

        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = doc.Database
        Dim ed As Editor = doc.Editor
        Dim oHatch As Hatch
        Using tx As Transaction = db.TransactionManager.StartTransaction
            Dim acBlkTbl As BlockTable
            acBlkTbl = CType(tx.GetObject(db.BlockTableId, _
                                         OpenMode.ForRead), BlockTable)
            Dim btr As BlockTableRecord = CType(tx.GetObject(acBlkTbl(BlockTableRecord.ModelSpace), OpenMode.ForWrite), BlockTableRecord)
            Dim i As Integer = 0
            Dim lline As Line
            Dim objectIdSozdan As New ObjectIdCollection
            For Each el As Point2d In iColl
                If i < iColl.Count - 1 Then
                    Dim lelS = iColl(i + 1)
                    lline = New Line(New Point3d(el.X, el.Y, 0), New Point3d(lelS.X, lelS.Y, 0))
                Else
                    Dim lel0 = iColl(0)
                    lline = New Line(New Point3d(el.X, el.Y, 0), New Point3d(lel0.X, lel0.Y, 0))
                End If
                If ProvVertikali(lline) Then
                    lline.Layer = ilayerSlyjb
                Else
                    lline.Layer = iLayerGraniz
                End If

                Dim lLineId = btr.AppendEntity(lline)
                tx.AddNewlyCreatedDBObject(lline, True)
                objectIdSozdan.Add(lLineId)
                i += 1

            Next



            oHatch = New Hatch()
            oHatch.SetDatabaseDefaults()
            oHatch.Normal = New Vector3d(0.0, 0.0, 1.0)
            oHatch.LineWeight = wparamhatch.LineWeight
            oHatch.PatternScale = wparamhatch.PatternScale
            oHatch.PatternAngle = wparamhatch.PatternAngle
            oHatch.SetHatchPattern(HatchPatternType.PreDefined, wparamhatch.PatternName)
            '  oHatch.Set = 1
            oHatch.Layer = iLayerHatch

            If icolor > -1 Then oHatch.ColorIndex = icolor
            If icolorFon > 0 Then
                Dim lcolor = Color.FromColor(Drawing.Color.White)

                oHatch.BackgroundColor = lcolor

            End If

            btr.AppendEntity(oHatch)
            tx.AddNewlyCreatedDBObject(oHatch, True)

            ' Вот теперь можно сделать штриховку ассоциативной
            oHatch.Associative = True
            ' Первым добавляемым контуром должен быть внешний контур, который определяет границы заполняемые штриховкой. 
            'Для добавления внешнего контура, используйте метод AppendLoop с константой HatchLoopTypes.Outermost для типа добавляемого контура.
            'После определения внешнего контура, вы можете продолжить добавлять дополнительные контуры.
            ' Для добавления внутренних контуров используется метод AppendLoop с константой HatchLoopTypes.Default.
            Try
                oHatch.AppendLoop(HatchLoopTypes.Outermost, objectIdSozdan)
            Catch ex As Exception   'если чтоо не так
                Dim wColl As New Point2dCollection
                Dim lp = iColl(iColl.Count / 2)
                wColl.Add(lp)
                wColl.Add(New Point2d(lp.X + 10, lp.Y))
                wColl.Add(New Point2d(lp.X + 10, lp.Y - 10))
                wColl.Add(New Point2d(lp.X, lp.Y - 10))
                Dim wobjectIdSozdan As New ObjectIdCollection
                Dim lwsp As Polyline = BazDwg.dbPrim.CreateLwPolyline(wColl)
                lwsp.Closed = True
                Dim lpLId = btr.AppendEntity(lwsp)
                tx.AddNewlyCreatedDBObject(lwsp, True)
                wobjectIdSozdan.Add(lpLId)
                oHatch.AppendLoop(HatchLoopTypes.Default, wobjectIdSozdan)
                Dim lkont As Polyline = BazDwg.dbPrim.CreateLwPolyline(iColl)
                lkont.Closed = True
                Dim lkontId = btr.AppendEntity(lkont)
                tx.AddNewlyCreatedDBObject(lkont, True)
                '    Return Nothing
            End Try



            oHatch.EvaluateHatch(True)
            'Определяем положение в чертеже на передний или на задний план
            Dim block As BlockTableRecord = tx.GetObject(oHatch.BlockId, OpenMode.ForRead)

            Dim drawOrder As DrawOrderTable = tx.GetObject(block.DrawOrderTableId, OpenMode.ForWrite)

            objectIdSozdan.Add(oHatch.ObjectId)

            If icolorFon > 0 Then
                drawOrder.MoveToTop(objectIdSozdan)
            Else
                drawOrder.MoveToBottom(objectIdSozdan)
            End If




            tx.Commit()

        End Using
        Return oHatch
    End Function
    Shared Function CreatehatchPoParamHatchL(iLayerHatch As String, iSp As List(Of Point2d), wparamhatch As ParamHatch, _
                                iLayerGraniz As String, ilayerSlyjb As String, Optional icolor As Integer = -1, Optional icolorFon As Integer = 0) As Hatch
        Dim lcoll As New Point2dCollection(iSp.ToArray)

        Return CreatehatchPoParamHatchL(iLayerHatch, lcoll, wparamhatch, iLayerGraniz, ilayerSlyjb, icolor, icolorFon)
    End Function
    ''' <summary>
    ''' создание штриховки только по коллекции точек ,бес создания границ
    ''' </summary>
    ''' <param name="iNameLayer">  слой штоиховки</param>
    ''' <param name="wHatch">   параметры штриховки </param>
    ''' <param name="iColl">коллекция точек  </param>
    ''' <param name="lcollDouble"> коллекция реальных чисел по размеру совпадает с коллкцией точек не понял для чего лучше все числа 1 1  </param>
    ''' <returns></returns>
    ''' <remarks>  не получаеться плотного заполнения контура  </remarks>
    Shared Function GreateHatchPoPoint(iNameLayer As String, wHatch As ParamHatch, iColl As Point2dCollection, lcollDouble As DoubleCollection) As Hatch

        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = doc.Database
        Dim ed As Editor = doc.Editor
        Dim oHatch As Hatch
        Using tx As Transaction = db.TransactionManager.StartTransaction
            Dim acBlkTbl As BlockTable
            acBlkTbl = CType(tx.GetObject(db.BlockTableId, _
                                         OpenMode.ForRead), BlockTable)
            Dim btr As BlockTableRecord = CType(tx.GetObject(acBlkTbl(BlockTableRecord.ModelSpace), OpenMode.ForWrite), BlockTableRecord)


            oHatch = New Hatch()

            oHatch.Normal = New Vector3d(0.0, 0.0, 1.0)




            oHatch.PatternScale = wHatch.PatternScale


            oHatch.SetHatchPattern(HatchPatternType.PreDefined, wHatch.PatternName)


            ' oHatch.ColorIndex = 1
            oHatch.Layer = iNameLayer

            oHatch.ColorIndex = 10


            btr.AppendEntity(oHatch)


            tx.AddNewlyCreatedDBObject(oHatch, True)


            ' Вот теперь можно сделать штриховку ассоциативной


            oHatch.Associative = True
            ' Первым добавляемым контуром должен быть внешний контур, который определяет границы заполняемые штриховкой. 
            'Для добавления внешнего контура, используйте метод AppendLoop с константой HatchLoopTypes.Outermost для типа добавляемого контура.
            'После определения внешнего контура, вы можете продолжить добавлять дополнительные контуры.
            ' Для добавления внутренних контуров используется метод AppendLoop с константой HatchLoopTypes.Default.
            oHatch.AppendLoop(HatchLoopTypes.Outermost, iColl, lcollDouble)

            oHatch.EvaluateHatch(True)

            tx.Commit()

        End Using
        Return oHatch
    End Function

    Shared Function PoCurve2DPolyLineLW(colCurve As Curve2dCollection) As Polyline
        Dim lPolyline As New Polyline
        lPolyline.Closed = True
        Dim i As Integer = 0
        For Each el As Curve2d In colCurve
            If TypeOf (el) Is LineSegment2d Then
                Dim lsegment As LineSegment2d = CType(el, LineSegment2d)


                lPolyline.AddVertexAt(i, el.StartPoint, 0, 0, 0)
                i += 1
                'lPolyline.AddVertexAt(i, el.EndPoint, 0, 0, 0)
                'i += 1

            End If


        Next
        Return lPolyline
    End Function
    Shared Function PoBugle2DPolyLineLW(collBugle As BulgeVertexCollection) As Polyline
        Dim lPolyline As New Polyline
        lPolyline.Closed = True
        Dim i As Integer = 0


        For Each el As BulgeVertex In collBugle
            lPolyline.AddVertexAt(i, el.Vertex, 0, 0, 0)

            i += 1
        Next
        Return lPolyline
    End Function
    Shared Function PeresechenieLineHatch(iHatch As Hatch, iX As Double) As Double()
        Dim lline As Line = dbPrim.GetLinePeresech(iHatch, iX)

        Dim lKolwoLoop As Integer = iHatch.NumberOfLoops
        Dim lNameHatch As String = iHatch.PatternName
        '   Application.ShowAlertDialog(.LoopType.ToString)
        Dim lhatchLoop As HatchLoop = Nothing
        Dim YperCurv() As Double = {100000, -100000}

        For J As Integer = 0 To lKolwoLoop - 1
            lhatchLoop = iHatch.GetLoopAt(J)
            'If Not CBool(lhatchLoop.LoopType And HatchLoopTypes.External) Then
            '    Continue For
            'End If
            Dim lhatchLoopBulge As BulgeVertexCollection = lhatchLoop.Polyline
            Dim lhatchCurves As Curve2dCollection = lhatchLoop.Curves
            Dim colPointCurves As New Point3dCollection
            Dim lIndex As Integer = 0
            If lhatchLoopBulge IsNot Nothing Then

                Dim lPolyline As Polyline = PoBugle2DPolyLineLW(lhatchLoopBulge)

                lPolyline.IntersectWith(lline, Intersect.OnBothOperands, colPointCurves, IntPtr.Zero, IntPtr.Zero)
                For Each el As Point3d In colPointCurves
                    If el.Y < YperCurv(0) Then YperCurv(0) = el.Y
                    If el.Y > YperCurv(1) Then YperCurv(1) = el.Y
                Next

            Else


                Dim lPolyline As Polyline = PoCurve2DPolyLineLW(lhatchCurves)
                lPolyline.IntersectWith(lline, Intersect.OnBothOperands, colPointCurves, IntPtr.Zero, IntPtr.Zero)
                For Each el As Point3d In colPointCurves
                    If el.Y < YperCurv(0) Then YperCurv(0) = el.Y
                    If el.Y > YperCurv(1) Then YperCurv(1) = el.Y
                Next
                '  Return New SlojGeo(Math.Abs(YperCurv(1) - YperCurv(0)), lNameHatch)
            End If
        Next
        Return YperCurv

    End Function
#End Region
End Class

