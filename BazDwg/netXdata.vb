
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

'функции реализующие работу c дополнительными данными

''' <summary>
''' запись чтение расширеных данных к примитиву
''' </summary>
''' <remarks></remarks>
Public Class clsXDATA
    Public Const regAppName As String = "ВЛ_11"

    Public Shared Function GetXDATA(ByVal DBObj As DBObject) As ResultBuffer
        Dim rb As ResultBuffer = Nothing


        rb = DBObj.XData

        Return rb
    End Function
    Public Shared Sub SetXDATA(ByVal DBObject As DBObject, ByVal rb As ResultBuffer)
        Dim tpv() As TypedValue
        tpv = rb.AsArray
        DBObject.XData = rb
    End Sub
    Public Shared Sub SetPoMasStrok(ByVal DBObject As DBObject, ByVal masStr() As String)
        Dim RazmMas As Integer = masStr.Length
        Dim tvb(RazmMas) As TypedValue
        tvb(0) = New TypedValue(1001, regAppName)
        For I As Integer = 1 To RazmMas
            tvb(I) = New TypedValue(DxfCode.ExtendedDataAsciiString, masStr(I - 1))
        Next
        Dim rb As New ResultBuffer(tvb)
        SetXDATA(DBObject, rb)
    End Sub
    Public Shared Function GetMasStrok(ByVal DBObject As DBObject) As String()
        Dim dan() As TypedValue = Nothing
        Dim s() As String = Nothing
        Dim rb As ResultBuffer = DBObject.XData

        If Not rb Is Nothing Then
            dan = rb.AsArray
            Dim razm As Integer = dan.Length - 1
            ReDim s(razm - 1)
            For i As Integer = 1 To razm
                s(i - 1) = dan(i).Value
            Next
        End If

        Return s
    End Function
    Public Shared Function ProvReg() As String
        Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database
        Dim tm As DBTransMan = db.TransactionManager
        Dim ta As Transaction = tm.StartTransaction()
        Dim lnameApp As String
        Using (ta)
            Dim Rat As RegAppTable = ta.GetObject(db.RegAppTableId, OpenMode.ForRead, False)
            If Not Rat.Has(regAppName) Then
                lnameApp = ""
            Else
                lnameApp = regAppName

            End If
            ta.Commit()
        End Using
        Return lnameApp
    End Function
    Shared Sub Init()
        Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database
        Dim tm As DBTransMan = db.TransactionManager
        Dim ta As Transaction = tm.StartTransaction()
        Using (ta)
            Dim Rat As RegAppTable = ta.GetObject(db.RegAppTableId, OpenMode.ForRead, False)
            If Not Rat.Has(regAppName) Then
                Rat.UpgradeOpen()
                Dim ratr As New RegAppTableRecord
                ratr.Name = regAppName
                Rat.Add(ratr)
                ta.AddNewlyCreatedDBObject(ratr, True)
            End If
            ta.Commit()
        End Using
    End Sub
    ''' <summary>
    ''' добавляет к примитиву расширеные данные
    ''' </summary>
    ''' <param name="iObjectId"></param>
    ''' <param name="masStrDan"></param>
    ''' <remarks></remarks>
    Shared Sub DobawitXdata(ByVal iObjectId As ObjectId, ByVal masStrDan As System.String())
        Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database
        Dim tm As DBTransMan = db.TransactionManager
        'start a transaction

        Dim ta As Transaction = tm.StartTransaction()

        Try

            Dim bt As BlockTable = tm.GetObject(db.BlockTableId, OpenMode.ForRead, False)
            Dim lObjectDb As DBObject = tm.GetObject(iObjectId, OpenMode.ForWrite, False)



            clsXDATA.SetPoMasStrok(lObjectDb, masStrDan)



            ta.Commit()
        Finally
            ta.Dispose()
        End Try

    End Sub
    ''' <summary>
    ''' читает из примитива расширенные даныые
    ''' </summary>
    ''' <param name="iObjectID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function LeseXdata(iObjectID) As String()
        Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database
        Dim tm As DBTransMan = db.TransactionManager
        Dim lmas() As String
        'start a transaction

        Dim ta As Transaction = tm.StartTransaction()

        Try

            Dim bt As BlockTable = tm.GetObject(db.BlockTableId, OpenMode.ForRead, False)
            Dim lObjectDb As DBObject = tm.GetObject(iObjectID, OpenMode.ForRead, False)



            lmas = clsXDATA.GetMasStrok(lObjectDb)



            ta.Commit()
        Finally
            ta.Dispose()
        End Try
        Return lmas
    End Function
  

    Shared Sub New()
        Init()
    End Sub
End Class




