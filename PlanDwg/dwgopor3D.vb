#If ARX_APP Then
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.DatabaseServices
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
Imports modRasstOp
Imports BazDwg
''' <summary>
''' класс реализующий непосредственный вывод в чертеж образа опоры3д
''' </summary>
''' <remarks></remarks>
Public Class dwgopor3D
    Inherits opor3D
    Public Const SlZ3Dopor As String = DwgParam.KodVer & "z3Dopora"  'В дальнейшем сделать приватными
    Public Const SlZ3DProwod As String = DwgParam.KodVer & "z3Dprowod"
    Private wPow As dwgPow
    Sub New(ByVal opRast As modRasstOp.wlOpRasst, ByVal Pow As dwgPow)
        MyBase.new(opRast, Pow)
        wPow = Pow
    End Sub
    Shared Sub Ochistit()
        BazDwg.netSelectSet.OchistitSloj(SlZ3Dopor)
        BazDwg.netSelectSet.OchistitSloj(SlZ3DProwod)
    End Sub
    Private Function DwgTrawers(ByVal I As Fazi) As Line ' Создаем отрезок соответствующий траверсе
        Dim losn(2) As Double
        losn(0) = Me.KoorOp(0)
        losn(1) = KoorOp(1)
        losn(2) = Trawers(I)(2)
        Dim begt As Point3d = wPow.GetDwg(losn)
        Dim endT As Point3d = wPow.GetDwg(Trawers(I))
        Return New Line(begt, endT)
    End Function

    'Private Function Trawersa(ByVal pr As String) As Line
    '    Dim ldelta As Double
    '    Select Case pr
    '        Case "0"
    '            ldelta = wOpRasst.DannOpor.Trawers(Fazi.faz0)
    '        Case "1"
    '            ldelta = wOpRasst.DannOpor.Trawers(Fazi.faz1)
    '        Case "2"
    '            ldelta = wOpRasst.DannOpor.Trawers(Fazi.faz2)
    '        Case Else
    '            ldelta = wOpRasst.DannOpor.Trawers(Fazi.tros)

    '    End Select


    '    Dim lotmf = wOpRasst.OtmetkaWerha(pr)
    '    Dim lk As Double()
    '    Dim losn(2) As Double
    '    If NaUgluLi() Then
    '        lk = wPiket3d.OrtoTchkUg(ldelta)
    '    Else
    '        lk = wPiket3d.OrtoTchk(wOpRasst.RastOtNachala, ldelta)
    '    End If
    '    lk(2) = lotmf
    '    losn(0) = wKoor(0)
    '    losn(1) = wKoor(1)
    '    losn(2) = lotmf
    '    Dim begt As Point3d = wPow.GetDwg(losn)
    '    Dim endT As Point3d = wPow.GetDwg(lk)
    '    Return New Line(begt, endT)
    'End Function
    ''' <summary>
    ''' выводит опору в чертеж на поверхность трассы
    ''' </summary>
    ''' <remarks></remarks>
    Sub wiwestiOp()
        Dim losnOp As Point3d = wPow.GetDwg(KoorOp)
        Dim lwerop As Point3d = New Point3d(losnOp.X, losnOp.Y, wPow.koorZ.GetDwg(OpRasst.OtmetkaWerhaT))
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database

        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()


            '' открываем таблицу блоков для чтения
            Dim acBlkTbl As BlockTable
            acBlkTbl = CType(acTrans.GetObject(acCurDb.BlockTableId, _
                                         OpenMode.ForRead), BlockTable)

            '' открываем в таблице блоков запись  Model space для записи
            Dim acBlkTblRec As BlockTableRecord
            acBlkTblRec = CType(acTrans.GetObject(acBlkTbl(BlockTableRecord.ModelSpace), _
                                            OpenMode.ForWrite), BlockTableRecord)




            Dim pline As New Line(losnOp, lwerop)
            pline.Layer = SlZ3Dopor
            pline.LineWeight = LineWeight.LineWeight030
            acBlkTblRec.AppendEntity(pline)
            acTrans.AddNewlyCreatedDBObject(pline, True)


            For i As Integer = 0 To 3
                ' Dim lpr As String
                '  If i > 2 Then lpr = "t" Else lpr = CStr(i)
                Dim ltraw As Line = DwgTrawers(CType(i, Fazi))
                ltraw.Layer = SlZ3Dopor
                acBlkTblRec.AppendEntity(ltraw)
                acTrans.AddNewlyCreatedDBObject(ltraw, True)
            Next
            'Dim ltraw As Line = Trawersa("0")
            'ltraw.Layer = Slopor3d
            'ltraw.LineWeight = LineWeight.LineWeight040

            'acBlkTblRec.AppendEntity(ltraw)
            'acTrans.AddNewlyCreatedDBObject(ltraw, True)

            Dim acText As DBText = New DBText()

            acText.SetDatabaseDefaults()

            acText.Position = lwerop

            acText.Height = 5
            acText.Layer = SlZ3Dopor
            acText.TextString = OpRasst.NumName & " " & OpRasst.UserTipOp
            acBlkTblRec.AppendEntity(acText)
            acTrans.AddNewlyCreatedDBObject(acText, True)


            ''Создаем Vertex и добавляем в сеть и трансакцию




            acTrans.Commit()
        End Using
    End Sub
#Region "Prolet"
    ''' <summary>
    ''' Выводит кривые провисания для всех фаз  пролета образуемого данной опорой и предыдущей с заданными сигма и гамма
    ''' </summary>
    ''' <param name="IopPred"> предыдущая опора </param>
    ''' <param name="iSigma"> сигма </param>
    ''' <param name="iGamma"> гамма</param>
    ''' <remarks></remarks>
    Sub WiwestiProwis(ByVal IopPred As dwgopor3D, ByVal iSigma As Double, ByVal iGamma As Double)
        For i As Integer = 0 To 2
            Dim lprolet As New modRasstOp.tshprolet3D(IopPred.Trawers(CType(i, Fazi)), Trawers(CType(i, Fazi)), iSigma, iGamma)
            wPow.WiwestiProvis3d(lprolet.ProviProwod3d(100))
        Next

    End Sub
    ''' <summary>
    ''' Выводит кривые провисания для троса  пролета образуемого данной опорой и предыдущей с заданными сигма и гамма
    ''' </summary>
    ''' <param name="IopPred"></param>
    ''' <param name="iSigma"></param>
    ''' <param name="iGamma"></param>
    ''' <remarks></remarks>
    Sub WiwestiProwisTr(ByVal IopPred As dwgopor3D, ByVal iSigma As Double, ByVal iGamma As Double)

        Dim lprolet As New modRasstOp.tshprolet3D(IopPred.Trawers(Fazi.tros), Trawers(Fazi.tros), iSigma, iGamma)
        wPow.WiwestiProvis3d(lprolet.ProviProwod3d(100))


    End Sub

#End Region
End Class
