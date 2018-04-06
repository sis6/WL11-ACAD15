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

Public Class dwgWidEkran
    Protected wModShir, wModWis As Double ' ширина и высота области модели
    Protected wShir, wWis As Double ' ширина и высота видоваого экрана
    Protected ZentrWid As Point2d  ' координаты цента обласити отражаемой в видовой экран в модели
    Protected pZentr As Point3d     ' zentr видового экрана в пространстве листа
    Protected Sub New(ByVal nizl As Point2d, ByVal werhP As Point2d)
        wModWis = werhP.Y - nizl.Y
        wModShir = werhP.X - nizl.X
        ZentrWid = New Point2d(nizl.X + wModShir / 2, nizl.Y + wModWis / 2)
    End Sub
    ''' <summary>
    ''' Видовой экран отображаемый на лист из модели
    ''' </summary>
    ''' <param name="NizL"> Низшая левая точка области модели отображаемая в видовом экране листа </param>
    ''' <param name="WerhP"> верхняя правая точка области </param>
    ''' <param name="NizNaListe">Низшая левая точка на листе </param>
    ''' <remarks></remarks>
    Sub New(ByVal NizL As Point2d, ByVal WerhP As Point2d, ByVal NizNaListe As Point3d)
        MyClass.New(NizL, WerhP)
        wShir = wModShir
        wWis = wModWis
        pZentr = New Point3d(NizNaListe.X + wShir / 2, NizNaListe.Y + wWis / 2, 0)
    End Sub
    ReadOnly Property ZentrWListe As Point3d
        Get
            Return pZentr
        End Get
    End Property
    ''' <summary>
    ''' Выводит на текущий лист экран без масштабирования
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function WiwestiNaList() As ObjectId
        Dim acVPort As New Viewport

        Dim VPortId As ObjectId
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = acDoc.Database
        'Dim tm As DBTransMan = db.TransactionManager
        Dim ta As Transaction = db.TransactionManager.StartTransaction()
        Try
            Dim bt As BlockTable = ta.GetObject(db.BlockTableId, OpenMode.ForRead, False)
            Dim btr As BlockTableRecord = ta.GetObject(bt(BlockTableRecord.PaperSpace), OpenMode.ForWrite, False)
            Application.SetSystemVariable("TILEMODE", 0)
            acDoc.Editor.SwitchToPaperSpace()

            VPortId = btr.AppendEntity(acVPort)
            ta.AddNewlyCreatedDBObject(acVPort, True)

            acVPort.Width = wShir
            acVPort.Height = wWis
            acVPort.ViewHeight = wWis
            acVPort.CenterPoint = pZentr
            acVPort.ViewCenter = ZentrWid
            '  acVPort.ViewTarget = tmodel
            acVPort.On = True
            acVPort.Locked = True
            ta.Commit()

        Finally
            ta.Dispose()
        End Try

        Return VPortId
    End Function
    Private Function CreateViewPort(ByVal tmodel As Point2d, ByVal Shir As Double, ByVal wis As Double, ByVal NameLst As String) As ObjectId

        Dim acVPort As New Viewport

        Dim lObjectid As ObjectId
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = acDoc.Database
        '  Dim tm As DBTransMan = db.TransactionManager
        Dim ta As Transaction = db.TransactionManager.StartTransaction()
        Try
            Dim bt As BlockTable = db.TransactionManager.GetObject(db.BlockTableId, OpenMode.ForRead, False)

            Dim btRecortLista As BlockTableRecord = db.TransactionManager.GetObject(bt(clsList.nameBlockLista(NameLst)), OpenMode.ForWrite, False)


            lObjectid = btRecortLista.AppendEntity(acVPort)
            db.TransactionManager.AddNewlyCreatedDBObject(acVPort, True)
            acVPort.Width = Shir
            acVPort.Height = wis
            acVPort.ViewHeight = wis
            acVPort.CenterPoint = pZentr
            acVPort.ViewCenter = tmodel
            'acVPort.StandardScale = StandardScaleType.CustomScale
            'acVPort.CustomScale = 1
            acVPort.On = True
            acVPort.Locked = True

            ta.Commit()
        Finally
            ta.Dispose()
        End Try
        Return lObjectid
    End Function

End Class
Public Class dwgWidEkranScale
    Inherits dwgWidEkran
    Public Shared NameSlojVidEkran As String = ""
    Private wScale As Double
    Private wNizVoprtList As Point3d
    ReadOnly Property Scale() As Double
        Get
            Return wScale
        End Get
    End Property
    Sub New(ByVal NizL As Point2d, ByVal WerhP As Point2d, ByVal NizNaListe As Point3d, iScale As Double)
        MyBase.New(NizL, WerhP)
        wNizVoprtList = NizNaListe
        wScale = iScale
        wShir = wModShir * wScale
        wWis = wModWis * wScale
        pZentr = New Point3d(NizNaListe.X + wShir / 2, NizNaListe.Y + wWis / 2, 0)

    End Sub

    Private Function CreateViewPortClip(DlajClip As Point2dCollection) As ObjectId

        Dim acVPort As New Viewport

        Dim VPortId As ObjectId
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = acDoc.Database
        'Dim tm As DBTransMan = db.TransactionManager
        Dim ta As Transaction = db.TransactionManager.StartTransaction()
        Try
            Dim bt As BlockTable = ta.GetObject(db.BlockTableId, OpenMode.ForRead, False)
            Dim btRecordLauer As BlockTableRecord = ta.GetObject(bt(BlockTableRecord.PaperSpace), OpenMode.ForWrite, False)

            ' Application.SetSystemVariable("TILEMODE", 0)
            Dim entPolyline = New Polyline()
            For i As Integer = 0 To DlajClip.Count - 1
                entPolyline.AddVertexAt(i, DlajClip(i), 0.0, 0, 0)

            Next
            entPolyline.Closed = True
            If Not String.IsNullOrEmpty(NameSlojVidEkran) Then
                entPolyline.Layer = NameSlojVidEkran
            End If
            Dim ObjectIdPl = btRecordLauer.AppendEntity(entPolyline)
            ta.AddNewlyCreatedDBObject(entPolyline, True)
            '    acDoc.Editor.SwitchToPaperSpace()

            VPortId = btRecordLauer.AppendEntity(acVPort)
            ta.AddNewlyCreatedDBObject(acVPort, True)
            '  acVPort.CustomScale = wScale
            '    acVPort.StandardScale = StandardScaleType.CustomScale

            acVPort.Width = wShir
            acVPort.Height = wWis
            acVPort.ViewHeight = wWis
            acVPort.CenterPoint = pZentr
            acVPort.ViewCenter = ZentrWid
            '  acVPort.ViewTarget = tmodel
            '  acVPort.StandardScale = StandardScaleType.CustomScale
            acVPort.CustomScale = wScale
            If Not String.IsNullOrEmpty(NameSlojVidEkran) Then
                acVPort.Layer = NameSlojVidEkran
            End If
            acVPort.NonRectClipEntityId = ObjectIdPl
            acVPort.NonRectClipOn = True
            acVPort.On = True
            acVPort.Locked = True
            ta.Commit()
        Finally
            ta.Dispose()
        End Try
        Return VPortId
    End Function
    Public Function WiwestiNaListClip(CollPoint2d As Point2dCollection) As ObjectId
        Dim lCollClip As New Point2dCollection
        For Each elP As Point2d In CollPoint2d
            lCollClip.Add(New Point2d((elP.X - wNizVoprtList.X) * wScale + wNizVoprtList.X, (elP.Y - wNizVoprtList.Y) * wScale + wNizVoprtList.Y))
        Next
        Return CreateViewPortClip(lCollClip)
    End Function
End Class
