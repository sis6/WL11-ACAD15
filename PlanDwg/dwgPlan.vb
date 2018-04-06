Option Strict On
Option Explicit On
#If ARX_APP Then
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.ApplicationServices
Imports DBTransMan = Autodesk.AutoCAD.DatabaseServices.TransactionManager
#Else
Imports Bricscad.ApplicationServices
Imports _AcBr = Teigha.BoundaryRepresentation
Imports _AcCm = Teigha.Colors
Imports Teigha.DatabaseServices
Imports _AcEd = Bricscad.EditorInput
Imports Teigha.Geometry
Imports _AcGi = Teigha.GraphicsInterface
Imports _AcGs = Teigha.GraphicsSystem
Imports _AcPl = Bricscad.PlottingServices
Imports _AcBrx = Bricscad.Runtime
Imports _AcTrx = Teigha.Runtime
Imports _AcWnd = Bricscad.Windows
Imports DBTransMan = Teigha.DatabaseServices.TransactionManager
#End If



Imports BazDwg
Imports clsPrf

Public Class dwgPlan
   
    Protected objPl As clsPrf.clsTrassa3d
    Protected pKoorX, pKoorY As clsKoor
    Protected pShirKosogor, pShirKosogorDwg As Double
    Protected colOp, ColOtmPl, ColPl, colPlPrLw, collOhrZon, collWremOtwod As DBObjectCollection
    Protected ColIdPeresech As ObjectIdCollection
    Protected wRassTrwiw As modRasstOp.wlRasst
    Protected wOpRasstPl() As dwgOpRasstNaPlane
#Region "Init"

    Private Sub OprUgl(ByVal iRasstTrwiw As modRasstOp.wlRasst, ByVal Mashtab As Integer, ByVal Ugol As Double, ByVal Xdwg As Double, ByVal Ydwg As Double, _
                        ByVal iXreal As Double, ByVal iYreal As Double)
        pKoorX = New clsKoor(Mashtab, iXreal, Xdwg)
        pKoorY = New clsKoor(Mashtab, iYreal, Ydwg)
        pShirKosogorDwg = pShirKosogor * pKoorX.Koeff

        '
        objPl = New clsPrf.clsTrassa3d(iXreal, iYreal, Ugol, iRasstTrwiw.Trassa)
        ' objPl.UglPow(wRassTrwiw.objTr)
        objPl.UglPow()
        SystemKommand.SoobEditor(Me.ToString & "PlUglPow План трассы создан")

    End Sub
    Sub New(ByVal iRasstTrwiw As modRasstOp.wlRasst)
        MyClass.New()
        Dim msh, lUnom As Integer
        Dim ug, X, Y, lXreal, lYreal, lshirKosogor As Double
        wRassTrwiw = iRasstTrwiw
        dwgPlan.LeseParam(msh, ug, X, Y, lshirKosogor, lXreal, lYreal, lUnom) 'ширину косогора и номинальное напряжение лучше брать из параметров участка
        If wRassTrwiw.Uch(0) IsNot Nothing Then
            pShirKosogor = wRassTrwiw.Uch(0).ShirinaPofil
            lUnom = wRassTrwiw.Uch(0).Unom
        End If
        OprUgl(wRassTrwiw, msh, ug, X, Y, lXreal, lYreal)
        clsTrass.OprOchranZon(lUnom)


        dwgOpRasstNaPlane.KoorPl(pKoorX, pKoorY)
    End Sub
    Sub New()
        Kommand.createNewLayer(DwgParam.SlPlan)
        Kommand.createNewLayer(DwgParam.SlPlanPrLw)
        Kommand.createNewLayer(DwgParam.SlPlanOtmetok)

        Kommand.createNewLayer(DwgParam.SlPlanOpor)
        Kommand.createNewLayer(DwgParam.SlPlanPeresech)
        Kommand.createNewLayer(DwgParam.SlPlanOhranZon)
    End Sub
    Sub Ochistit()
        Kommand.OchistSlojMod(DwgParam.SlPlan)
        Kommand.OchistSlojMod(DwgParam.SlPlanPrLw)
        Kommand.OchistSlojMod(DwgParam.SlPlanPeresech)
        Kommand.OchistSlojMod(DwgParam.SlPlanOtmetok)

        Kommand.OchistSlojMod(DwgParam.SlPlanOpor)
        Kommand.OchistSlojMod(DwgParam.SlPlanOtwodPost)
        Kommand.OchistSlojMod(DwgParam.SlPlanOtwodWrem)
        Kommand.OchistSlojMod(DwgParam.SlPlanOhranZon)
    End Sub
    Public Sub InitColl(ByRef iColl As DBObjectCollection)
        If iColl Is Nothing Then
            iColl = New DBObjectCollection
        Else
            iColl.Clear()
        End If
    End Sub
    Shared Sub LeseParam(ByRef Mashtab As Integer, ByRef Ugol As Double, ByRef Xdwg As Double, ByRef Ydwg As Double, ByRef ShirKosogor As Double,
                         ByRef Xreal As Double, ByRef Yreal As Double, ByRef Unom As Integer)
        Dim SlParam As New dwgSlowar(LeseSreib.GlParam)
        Dim Danwh() As TypedValue
        Dim KolwoParam As Integer
        Danwh = SlParam.ZapisIsSlowar(LeseSreib.ZpParamPlana)
        If Danwh Is Nothing Then
            KolwoParam = -1
        Else
            KolwoParam = UBound(Danwh)
        End If
        Mashtab = 1000
        Ugol = 0
        Xdwg = 0
        Ydwg = 0
        Unom = 220
        ShirKosogor = 11


        If KolwoParam >= 0 Then Mashtab = CInt(Danwh(0).Value)
        If KolwoParam >= 1 Then Ugol = CDbl(Danwh(1).Value)
        If KolwoParam >= 2 Then Xdwg = CDbl(Danwh(2).Value)
        If KolwoParam >= 3 Then Ydwg = CDbl(Danwh(3).Value)
        If KolwoParam >= 4 Then ShirKosogor = CDbl(Danwh(4).Value)
        If KolwoParam >= 5 Then Xreal = CDbl(Danwh(5).Value)
        If KolwoParam >= 6 Then Yreal = CDbl(Danwh(6).Value)
        If KolwoParam >= 7 Then Unom = CInt(Danwh(7).Value)
        SlParam = Nothing

    End Sub
    Shared Sub SchreibeParam(ByVal Mashtab As Integer, ByVal Ugol As Double, ByVal Xdwg As Double, ByVal Ydwg As Double, ByVal Shirkosogor As Double, _
                               ByVal Xreal As Double, ByVal Yreal As Double, ByVal Unom As Integer)
        Dim SlParam As New dwgSlowar(LeseSreib.GlParam)
        Dim Danr(7) As TypedValue
        Danr(0) = New TypedValue(CInt(DxfCode.Int32), Mashtab)
        Danr(1) = New TypedValue(CInt(DxfCode.Real), Ugol)
        Danr(2) = New TypedValue(CInt(DxfCode.Real), Xdwg)
        Danr(3) = New TypedValue(CInt(DxfCode.Real), Ydwg)
        Danr(4) = New TypedValue(CInt(DxfCode.Real), Shirkosogor)
        Danr(5) = New TypedValue(CInt(DxfCode.Real), Xreal)
        Danr(6) = New TypedValue(CInt(DxfCode.Real), Yreal)
        Danr(7) = New TypedValue(CInt(DxfCode.Int32), Unom)
        SlParam.ZapisW_Slowar(LeseSreib.ZpParamPlana, Danr)
        SlParam = Nothing
    End Sub
#End Region
#Region "Plan"
    Overridable Sub WiwPlana()
        InitColl(ColPl)
        Kommand.OchistSlojMod(DwgParam.SlPlan)

        objPl.UstBeg()
        Dim objUg As clsPrf.clsPiket3d = objPl.UglTplan()
        Do Until objUg Is Nothing
            '  Debug.Print(objUg.X & "  " & I)
            ' WiwStPlana(objUg, colPl)
            WiwStPlana(objUg, ColPl)
            objPl.SledT()
            objUg = objPl.UglTplan()
        Loop
        Dim ColSoten = UstRazbNaSotni()
        For Each el As clsSootTrUch In ColSoten
            wiwSotn(8, el, ColPl)
        Next
        dbPrim.changeSloj(ColPl, DwgParam.SlPlan)
        dbPrim.Wkl(ColPl)
    End Sub
    Sub FormPolyLine()
        InitColl(ColPl)
        Kommand.OchistSlojMod(DwgParam.SlPlan)

        objPl.UstBeg()
        Dim objUg As clsPrf.clsPiket3d = objPl.UglTplan()
        Dim CollTochek As New Point2dCollection
        Do Until objUg Is Nothing
            CollTochek.Add(New Point2d(pKoorX.GetDwg(objUg.X), pKoorY.GetDwg(objUg.Yp)))

            objPl.SledT()
            objUg = objPl.UglTplan()
        Loop
        Dim objIdPolylinr = MakeEntities.CreateLwPolyline(CollTochek)
        Kommand.changeSloj(objIdPolylinr, DwgParam.SlPlan)

    End Sub

    Protected Function UstRazbNaSotni() As Collection
        objPl.UstBeg()
        Dim objUg As clsPrf.clsPiket3d = objPl.UglTplan()
        Dim el As clsPrf.clsSootTrUch
        Dim ColSoten As Collection = wRassTrwiw.Trassa.GetSotni()

        For Each el In ColSoten
            Do Until objUg.Piket.MensheR(el.RastOtNachala) >= 0                                                       'Wnutri(el.RastOtNachala) 'пока  не переходит на другой участок
                objPl.SledT()
                objUg = objPl.UglTplan()
                If objUg Is Nothing Then
                    MsgBox("objug nothing " & el.RastOtNachala)
                    GoTo KON
                End If
                'I += 1

            Loop
            Dim lk() As Double
            lk = objUg.KoorPk(el.RastOtNachala)
            el.UstKooR(lk)
            el.Ugol = objUg.Ugol

        Next
KON:    Return ColSoten
    End Function
    Private Sub WiwStPlana(ByVal objUg As clsPrf.clsPiket3d, ByVal collPrim As DBObjectCollection)

        With objUg
            Dim Xdwg As Double = pKoorX.GetDwg(.X)
            Dim Ydwg As Double = pKoorY.GetDwg(.Yp)
            If .Sled Is Nothing Then
                collPrim.Add(dbPrim.CreateCircle(Xdwg, Ydwg, 15))
            Else
                collPrim.Add(dbPrim.CreateLine(Xdwg, Ydwg, pKoorX.GetDwg(.Sled.X), pKoorY.GetDwg(.Sled.Yp)))
                collPrim.Add(dbPrim.CreateText(New Point3d(Xdwg - 5, Ydwg - 5, 0), "X = " & Format(.X, "#.#") & " Y " & Format(.Yp, "#.#"), 3))
                collPrim.Add(dbPrim.CreateText(New Point3d(Xdwg - 10, Ydwg - 10, 0), "Dlina = " & Format(.Dlina, "#.#") & " Угол " & clsUgolPoworot.StrGradLwPr(.DirectUgol - .Ugol), 3))
                If .Pred Is Nothing Then
                    collPrim.Add(dbPrim.CreateText(New Point3d(Xdwg - 25, Ydwg, 0), "начало = " & CType(objUg, clsTrassa3d).Dlina, 3))
                Else
                    collPrim.Add(dbPrim.CreateText(New Point3d(Xdwg - 15, Ydwg - 15, 0), "Пикетаж = " & Format(.Piketaj, "#.#") & " Имя " & .Name, 3))
                End If

            End If

        End With
    End Sub

    Protected Sub wiwSotn(ByVal dl As Double, ByVal t As clsSootTrUch, ByVal coll As DBObjectCollection)
        Dim PiDelNa2, ugb, uge, lxb, lxe, lzb, lze As Double
        PiDelNa2 = Math.PI / 2
        ugb = t.Ugol + PiDelNa2
        uge = t.Ugol - PiDelNa2
        lxb = pKoorX.GetDwg(t.X) + dl * Math.Cos(ugb)
        lzb = pKoorY.GetDwg(t.Y) + dl * Math.Sin(ugb)
        lxe = pKoorX.GetDwg(t.X) + dl * Math.Cos(uge)
        lze = pKoorY.GetDwg(t.Y) + dl * Math.Sin(uge)
        Dim wug As Double = t.Ugol Mod (Math.PI / 2.0)
        'If t.Ugol > Math.PI Then
        '    wug = t.Ugol - Math.PI
        'Else
        '    wug = t.Ugol
        'End If
        coll.Add(dbPrim.CreateLine(lxb, lzb, lxe, lze))
        coll.Add(dbPrim.CreateTextUg(New Point3d(lxe, lze, 0), "ПК" & Fix((t.Piketaj + 1) / 100), 3, wug))
        coll.Add(dbPrim.CreateText(New Point3d(lxb, lzb, 0), "ПК" & Fix((t.Piketaj + 1) / 100), 3))
    End Sub
#End Region
#Region "Opor"
    Private Sub UstOp()
        objPl.UstBeg()
        ReDim wOpRasstPl(wRassTrwiw.opColl.Count - 1)
        Dim objUg As clsPrf.clsPiket3d = objPl.UglTplan()
        Dim el As modRasstOp.wlOpRasst
        Dim I As Integer = 0
        For Each el In wRassTrwiw.opColl
            Do Until objUg.Piket.MensheR(el.RastOtNachala) >= 0  'Цикл пока не найдем пикетную точку такую чтобы расстояние до опоры было меньше или близко кней.
                objPl.SledT()
                objUg = objPl.UglTplan()

            Loop


            wOpRasstPl(I) = New dwgOpRasstNaPlane(objUg, el)
            I += 1
        Next
    End Sub
    Sub WiwOpPlana()

        Kommand.OchistSlojMod(DwgParam.SlPlanOpor)
        Dim lop As dwgOpRasstNaPlane = Nothing
        InitColl(colOp)

        UstOp()
        For Each el As dwgOpRasstNaPlane In wOpRasstPl
            '    MsgBox(el.TchkPlana.Piketaj)
            el.Wiwop(colOp, 1, lop)
            lop = el
        Next

        dbPrim.changeSloj(colOp, DwgParam.SlPlanOpor)
        dbPrim.Wkl(colOp)

    End Sub

#End Region
    Sub wiwProekzij()
        Dim colProekOp As New DBObjectCollection
        Kommand.createNewLayer(DwgParam.SlPlanOtwodPost)
        Kommand.OchistSlojMod(DwgParam.SlPlanOtwodPost)
        For Each el As dwgOpRasstNaPlane In wOpRasstPl
            '    MsgBox(el.TchkPlana.Piketaj)
            el.WiwProekOpor(colProekOp)
        Next

        dbPrim.changeSloj(colProekOp, DwgParam.SlPlanOtwodPost)
        dbPrim.Wkl(colProekOp)

    End Sub
#Region "Otwod"
    Sub wiwOchranZon()

        InitColl(collOhrZon)
        Kommand.OchistSlojMod(DwgParam.SlPlanOhranZon)
        Dim lTchkOchranZon, ltchkOchranZon2, ltchkFaz, ltchkFaz2 As New Point2dCollection
        For Each el As dwgOpRasstNaPlane In wOpRasstPl
            Dim tR As Point2d = el.GrTchkOhranZonP()
            Dim tr2 As Point2d = el.GrTchkOhranZonM()
            Dim trf As Point2d = el.GrTchkProvodP()
            Dim trf2 As Point2d = el.GrTchkProvodM()
            lTchkOchranZon.Add(New Point2d(pKoorX.GetDwg(tR.X), pKoorY.GetDwg(tR.Y)))
            ltchkOchranZon2.Add((New Point2d(pKoorX.GetDwg(tr2.X), pKoorY.GetDwg(tr2.Y))))
            ltchkFaz.Add(New Point2d(pKoorX.GetDwg(trf.X), pKoorY.GetDwg(trf.Y)))
            ltchkFaz2.Add(New Point2d(pKoorX.GetDwg(trf2.X), pKoorY.GetDwg(trf2.Y)))
        Next
        Dim lrazm As Integer = ltchkOchranZon2.Count - 1
        For J As Integer = 0 To lrazm
            lTchkOchranZon.Add(ltchkOchranZon2.Item(lrazm - J))
        Next
        collOhrZon.Add(dbPrim.CreateLwPolyline(lTchkOchranZon))
        ' collOhrZon.Add(dbPrim.CreateLwPolyline(ltchkOchranZon2))
        collOhrZon.Add(dbPrim.CreateLwPolyline(ltchkFaz))
        collOhrZon.Add(dbPrim.CreateLwPolyline(ltchkFaz2))
        dbPrim.changeSloj(collOhrZon, DwgParam.SlPlanOhranZon)
        dbPrim.Wkl(collOhrZon)
    End Sub
    Sub wiwWremenOtwod()
        createNewLayer(DwgParam.SlPlanOtwodWrem)
        InitColl(collWremOtwod)
        Dim Maxnumpols As Integer = 0
        Kommand.OchistSlojMod(DwgParam.SlPlanOtwodWrem)
        Dim lTchkWremOtwod(2), lWsp(2) As Point2dCollection
        For I As Integer = 0 To 2
            lTchkWremOtwod(I) = New Point2dCollection
            lWsp(I) = New Point2dCollection
        Next
        For Each el As dwgOpRasstNaPlane In wOpRasstPl
            For I As Integer = 0 To Maxnumpols
                Dim tr() As Point2d
                If Maxnumpols = 0 Then tr = el.GrtchkWremZon(3) Else tr = el.GrtchkWremZon(I)

                lTchkWremOtwod(I).Add(New Point2d(pKoorX.GetDwg(tr(0).X), pKoorY.GetDwg(tr(0).Y)))
                lWsp(I).Add(New Point2d(pKoorX.GetDwg(tr(1).X), pKoorY.GetDwg(tr(1).Y)))
            Next

        Next
        For I As Integer = 0 To Maxnumpols
            Dim lrazm As Integer = lWsp(I).Count - 1
            For J As Integer = 0 To lrazm
                lTchkWremOtwod(I).Add(lWsp(I).Item(lrazm - J))
            Next
            collWremOtwod.Add(dbPrim.CreateLwPolyline(lTchkWremOtwod(I)))
        Next
        dbPrim.changeSloj(collWremOtwod, DwgParam.SlPlanOtwodWrem)
        dbPrim.Wkl(collWremOtwod)
    End Sub

#End Region

#Region "read only"
    ReadOnly Property OpRasstPl() As Integer
        Get
            Try
                Return wOpRasstPl.Length
            Catch ex As Exception
                Return -1
            End Try

        End Get
    End Property
    ReadOnly Property Rasst() As modRasstOp.wlRasst
        Get
            Return wRassTrwiw
        End Get
    End Property
#End Region

  



End Class
