Option Strict On
Option Explicit On
#If ARX_APP Then
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.DatabaseServices
#Else
Imports Teigha.Geometry
Imports Teigha.DatabaseServices
#End If



Imports BazDwg
Imports clsPrf

Public Class dwgPlanPk
    Inherits dwgPlan

#Region "Init"
    ''' <summary>
    ''' Для пересчета плана после изменения параметров отображения
    ''' </summary>
    ''' <param name="Mashtab"> коэффициэнт масштаба </param>
    ''' <param name="Ugol"> начальный уголнаправления трассы</param>
    ''' <param name="Xdwg">координата X в чертеже начала трасы  </param>
    ''' <param name="Ydwg">координата y в чертеже начала трасы </param>
    ''' <param name="iXreal"> реальная координата X </param>
    ''' <param name="iYreal">реальная координата Y </param>
    ''' <remarks></remarks>
    Public Sub ReInit(ByVal Mashtab As Integer, ByVal Ugol As Double, ByVal Xdwg As Double, ByVal Ydwg As Double, _
                        ByVal iXreal As Double, ByVal iYreal As Double)
        pKoorX = New clsKoor(Mashtab, iXreal, Xdwg)
        pKoorY = New clsKoor(Mashtab, iYreal, Ydwg)
        pShirKosogorDwg = pShirKosogor * pKoorX.Koeff
        objPl = New clsPrf.clsTrassa3d(iXreal, iYreal, Ugol, wRassTrwiw.Trassa)

        objPl.PlPiket()
        dwgOpRasstNaPlane.KoorPl(pKoorX, pKoorY)
    End Sub
    Private Sub OprSpik(ByVal iRasstTrwiw As modRasstOp.wlRasst, ByVal Mashtab As Integer, ByVal Ugol As Double, ByVal Xdwg As Double, ByVal Ydwg As Double, _
                        ByVal iXreal As Double, ByVal iYreal As Double)
        pKoorX = New clsKoor(Mashtab, iXreal, Xdwg)
        pKoorY = New clsKoor(Mashtab, iYreal, Ydwg)
        pShirKosogorDwg = pShirKosogor * pKoorX.Koeff

        objPl = New clsPrf.clsTrassa3d(iXreal, iYreal, Ugol, iRasstTrwiw.Trassa)

        objPl.PlPiket()
        SystemKommand.SoobEditor(Me.ToString & "PlPiket План трассы создан")

    End Sub
    Sub New(ByVal iRasstTrwiw As modRasstOp.wlRasst)
        MyBase.New()
        Dim msh, lUnom As Integer
        Dim ug, X, Y, lXreal, lYreal, lshirKosogor As Double
        wRassTrwiw = iRasstTrwiw
        dwgPlan.LeseParam(msh, ug, X, Y, lshirKosogor, lXreal, lYreal, lUnom) 'ширину косогора и номинальное напряжение лучше брать из параметров участка
        If wRassTrwiw.Uch(0) IsNot Nothing Then
            pShirKosogor = wRassTrwiw.Uch(0).ShirinaPofil
            lUnom = wRassTrwiw.Uch(0).Unom
        End If
        OprSpik(wRassTrwiw, msh, ug, X, Y, lXreal, lYreal) 'отлличие от базового
        clsTrass.OprOchranZon(lUnom)


        dwgOpRasstNaPlane.KoorPl(pKoorX, pKoorY)
    End Sub
#End Region
    ''' <summary>
    ''' Вывод плана со всеми пикетными точками
    ''' </summary>
    ''' <remarks></remarks>
    Overloads Sub WiwPlana()
        ColPl = New DBObjectCollection
        ColOtmPl = New DBObjectCollection

        colPlPrLw = New DBObjectCollection
        ColIdPeresech = New ObjectIdCollection

        BazDwg.netSelectSet.OchistitSloj(DwgParam.SlPlan)
        BazDwg.netSelectSet.OchistitSloj(DwgParam.SlPlanOtmetok)
        BazDwg.netSelectSet.OchistitSloj(DwgParam.SlPlanPeresech)
        BazDwg.netSelectSet.OchistitSloj(DwgParam.SlPlanPrLw)
        objPl.UstBeg()
        Dim objUg As clsPrf.clsPiket3d = objPl.UglTplan()
        Do Until objUg Is Nothing
            '  Debug.Print(objUg.X & "  " & I)
            ' WiwStPlana(objUg, colPl)
            WiwStPlana(objUg)
            objPl.SledT()
            objUg = objPl.UglTplan()
        Loop
        Dim ColSoten = UstRazbNaSotni()
        For Each el As clsSootTrUch In ColSoten
            wiwSotn(8, el, colPl)
        Next
        dbPrim.changeSloj(ColPl, DwgParam.SlPlan)
        dbPrim.changeSloj(ColOtmPl, DwgParam.SlPlanOtmetok)

        dbPrim.changeSloj(colPlPrLw, DwgParam.SlPlanPrLw)
        dbPrim.Wkl(ColPl)
        dbPrim.Wkl(ColOtmPl)
        dbPrim.Wkl(colPlPrLw)
        Kommand.changeSloj(ColIdPeresech, DwgParam.SlPlanPeresech)

    End Sub
    Private Sub Kosogor(ByVal Xdwg As Double, ByVal ydwg As Double, ByVal objUg As clsPrf.clsPiket3d)
        Dim lxe, lye As Double
        With objUg
            If .Piket.EstOtmetkaLw Then

                colPlPrLw.Add(dbPrim.CreateNakl(Xdwg, ydwg, pShirKosogorDwg, .Ugol - 0.5 * Math.PI, lxe, lye))
                colPlPrLw.Add(dbPrim.CreateText(New Point3d(lxe, lye, 0), Format(.Piket.OtmetkaLw, "#.##"), 2))
            End If
            If .Piket.EstOtmetkaPr Then

                colPlPrLw.Add(dbPrim.CreateNakl(Xdwg, ydwg, pShirKosogorDwg, .Ugol + 0.5 * Math.PI, lxe, lye))
                colPlPrLw.Add(dbPrim.CreateText(New Point3d(lxe, lye, 0), Format(.Piket.OtmetkaPr, "#.##"), 2))
            End If
        End With
    End Sub
    Private Sub KosogorUglPoworot(ByVal Xdwg As Double, ByVal ydwg As Double, ByVal objUg As clsPrf.clsPiket3d, ByVal napr As Integer)
        Dim xe, ye As Double
        With objUg
            Dim PiNaDwa = napr * 0.5 * Math.PI
            Dim wX, wY, wXd, wYD As Double
            Kommand.UstTchk(Xdwg, ydwg, pShirKosogorDwg, .Ugol + PiNaDwa, wX, wY)
            Kommand.UstTchk(Xdwg, ydwg, pShirKosogorDwg, .DirectUgol + PiNaDwa, wXd, wYD)
            xe = 0.5 * (wX + wXd)
            ye = 0.5 * (wY + wYD)
            colPlPrLw.Add(dbPrim.CreateLine(Xdwg, ydwg, xe, ye))
            If napr < 0 Then
                colPlPrLw.Add(dbPrim.CreateText(New Point3d(xe, ye, 0), Format(.Piket.OtmetkaLw, "#.##"), 2))
            Else
                colPlPrLw.Add(dbPrim.CreateText(New Point3d(xe, ye, 0), Format(.Piket.OtmetkaPr, "#.##"), 2))
            End If




        End With
    End Sub
    Private Sub WiwStPlana(ByVal objUg As clsPrf.clsPiket3d)

        With objUg
            Dim Xdwg As Double = pKoorX.GetDwg(.X)
            Dim Ydwg As Double = pKoorY.GetDwg(.Yp)
            If .Sled Is Nothing Then
                ColPl.Add(dbPrim.CreateNakl(Xdwg, Ydwg, 20, .Ugol + 0.5 * Math.PI))
            Else
                ColPl.Add(dbPrim.CreateLine(Xdwg, Ydwg, pKoorX.GetDwg(.Sled.X), pKoorY.GetDwg(.Sled.Yp)))
            End If
            If .EstUgolPoworota Then
                ColPl.Add(dbPrim.CreateText(New Point3d(Xdwg - 1, Ydwg - 4, 0), "X = " & Format(.X, "#.#") & " Y " & Format(.Yp, "#.#"), 2))
                ColPl.Add(dbPrim.CreateText(New Point3d(Xdwg - 1, Ydwg - 7, 0), .Name & " Угол " & clsUgolPoworot.StrGradLwPr(.DirectUgol - .Ugol), 3))
                If objUg.Piket.EstOtmetkaLw Then
                    KosogorUglPoworot(Xdwg, Ydwg, objUg, -1)
                End If
                If objUg.Piket.EstOtmetkaPr Then
                    KosogorUglPoworot(Xdwg, Ydwg, objUg, 1)
                End If
            Else
                Kosogor(Xdwg, Ydwg, objUg)


            End If
            ColPl.Add(dbPrim.CreateNakl(Xdwg, Ydwg, 10, .Ugol + 0.25 * Math.PI))
            ColOtmPl.Add(dbPrim.CreateText(New Point3d(Xdwg, Ydwg, 0), Format(.Otm, "#.##"), 3))
            If .EstPeresech Then
                Dim lobj As ObjectId = dwgText.CreateMText(New Point3d(Xdwg + 1, Ydwg - 1, 0), ClsPiket.StrPiketaj(.Piketaj), 10, 3)
                ColIdPeresech.Add(MakeEntities.CreateLeader(New Point3d(Xdwg, Ydwg, 0), 4, lobj))
                ' colPeresech.Add(GlobParam.clstxt.CreateText(New Point3d(Xdwg + 1, Ydwg - 4, 0), clsPiket.StrPiketaj(.Piketaj), 3))
                ColIdPeresech.Add(lobj)
            End If

        End With
    End Sub


End Class
