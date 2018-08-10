Option Strict On
Option Explicit On

#If ARX_APP Then
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.Geometry
#Else
Imports Teigha.Geometry
Imports Teigha.DatabaseServices
Imports Bricscad.ApplicationServices
#End If


Imports BazDwg
Imports clsPrf
Imports ProfilBaseDwg

Public Class dwgWiwRasst
    'реализация функционала приложения по инициализации и вывода профиля

#Region "Загрузки"
    Public Shared Function ProvZagruzki() As Boolean
        If clsKommandBase.gRasst Is Nothing Then
            Application.ShowAlertDialog("трасса не загружена ")
            Return False
        Else
            Return True
        End If
    End Function

#End Region
#Region "wiwod"

#Region "Расстановка"
    Public Shared Sub wiwOpNaProfilw(iPiketBeg As clsPrf.ClsPiket, iPiketEnd As clsPrf.ClsPiket)
        If Not ProvZagruzki() Then Return

        BazDwg.netSelectSet.OchistitSloj(DwgParam.SlRasstOpor)
        BazDwg.netSelectSet.OchistitSloj(DwgParam.SlRasstUslow)

        Kommand.createNewLayer(DwgParam.SlRasstOpor, 1)
        Kommand.createNewLayer(DwgParam.SlRasstUslow)
        Kommand.createNewLayerNePrint(DwgParam.SlSlujbn)

        '   Dim opPrtek As DwgRstOpTr = Nothing

        For Each op As modRasstOp.wlOpRasst In clsKommandBase.gRasst.opColl
            If op.RastOtNachala < iPiketBeg.RastOtnachala Then Continue For
            If op.RastOtNachala > iPiketEnd.RastOtnachala Then Exit For
            Dim opNaprf As New dwgObrazOporRasst(op)
            opNaprf.wiwestiOP_Profil()

        Next
    End Sub
    Public Shared Sub wiwOpNaProfilw()

        If Not ProvZagruzki() Then Return

        BazDwg.netSelectSet.OchistitSloj(DwgParam.SlRasstOpor)
        BazDwg.netSelectSet.OchistitSloj(DwgParam.SlRasstUslow)

        Kommand.createNewLayer(DwgParam.SlRasstOpor, 1)
        Kommand.createNewLayer(DwgParam.SlRasstUslow)
        Kommand.createNewLayerNePrint(DwgParam.SlSlujbn)

        Dim opPrtek As dwgObrazOporRasst = Nothing
        Dim op As modRasstOp.wlOpRasst
        For Each op In clsKommandBase.gRasst.opColl
            Dim opNaprf As New dwgObrazOporRasst(op)
            opNaprf.wiwestiOP_Profil()
            '   MsgBox(opNaprf.Opora.rstUch.UchTr.NameUch & "Выведена " & op.NumName)

            opPrtek = opNaprf
        Next
    End Sub
    Public Shared Sub wiwOtmetokNijnihfaz(iPiketBeg As clsPrf.ClsPiket, iPiketEnd As clsPrf.ClsPiket, iCollDbObject As DBObjectCollection)
        Dim naprMleader As Double = 5
        For Each op As modRasstOp.wlOpRasst In clsKommandBase.gRasst.opColl
            If op.RastOtNachala < iPiketBeg.RastOtnachala Then Continue For
            If op.RastOtNachala > iPiketEnd.RastOtnachala Then Exit For

            Dim opNaprf As New dwgObrazOporRasst(op)
            iCollDbObject.Add(opNaprf.WiwestiOtmetkuNijnegoProvod(naprMleader))
            iCollDbObject.Add(opNaprf.WiwestiOtmetkuZemli(naprMleader))
            '  naprMleader = -naprMleader

        Next
    End Sub


    Public Shared Sub wiwOpNaProfil()
        If clsKommandBase.gTrassa.objGeom.obrParam.TipGraniz = ParamTrass.TipDetal Then

            Dim lPikBeg As clsPrf.ClsPiket = clsKommandBase.gTrassa.Piket(clsKommandBase.gTrassa.objGeom.obrParam.BegUch)
            Dim lpikEnd As clsPrf.ClsPiket = clsKommandBase.gTrassa.Piket(clsKommandBase.gTrassa.objGeom.obrParam.EndUch)
            dwgWiwRasst.wiwOpNaProfilw(lPikBeg, lpikEnd)
        Else
            dwgWiwRasst.wiwOpNaProfilw()

        End If
    End Sub

    Public Shared Sub PerepisatOpNaprofil(ByVal Iop As modRasstOp.wlOpRasst)
        Dim lOpPred As modRasstOp.wlOpRasst, lopSled As modRasstOp.wlOpRasst
        Dim lo As dwgObrazOporRasst
        lOpPred = Iop.Pred
        lopSled = Iop.Sled
        '     BazDwg.SystemKommand.SoobEditor(" PerepisatOpNaprofil:: начали  переписывать ")
        If lOpPred IsNot Nothing Then
            lo = New dwgObrazOporRasst(lOpPred)
            lo.wiwestiOP_Profil()
            '      BazDwg.SystemKommand.SoobEditor(" PerepisatOpNaprofil::   переписыли пред ")
        End If
        lo = New dwgObrazOporRasst(Iop)
        lo.wiwestiOP_Profil()
        If lopSled IsNot Nothing Then
            lo = New dwgObrazOporRasst(lopSled)
            lo.wiwestiOP_Profil()
            '     BazDwg.SystemKommand.SoobEditor(" PerepisatOpNaprofil::   переписыли след ")
        End If
        '   BazDwg.SystemKommand.SoobEditor(" PerepisatOpNaprofil::  опора переписана ")

    End Sub
    Private Shared Sub WiwDannOAnkUch()
        Dim lAnkUchBeg As dwgObrazOporRasst = Nothing
        Dim lankUchEnd As dwgObrazOporRasst = Nothing
        Dim DwgYDl As Double = clsKommandBase.gTrassa.objGeom.Podpis.OsDlinAnkUch
        Dim DwgYDPrived As Double = clsKommandBase.gTrassa.objGeom.Podpis.OsPrivedAnkUch
        Dim DwgYdlT As Double = DwgYDl + 1
        Dim DwgYDPrivedT As Double = DwgYDPrived + 1
        Dim DwgYUgl As Double = clsKommandBase.gTrassa.objGeom.Podpis.OsUglowPoworota
        Dim CollId As New DBObjectCollection
        For Each op As modRasstOp.wlOpRasst In clsKommandBase.gRasst.opColl

            If op.Tip > 0 Then
                '     Application.ShowAlertDialog("operazii WiwDannOAnkUch " & op.NumName)
                If lAnkUchBeg Is Nothing Then
                    lAnkUchBeg = CType(op.Obraz, dwgObrazOporRasst)
                    CollId.Add(dbPrim.CreateLine(lAnkUchBeg.DwgX, DwgYDl, lAnkUchBeg.DwgX, DwgYUgl))
                Else
                    If lankUchEnd IsNot Nothing Then lAnkUchBeg = lankUchEnd
                    'If op.Obraz IsNot Nothing Then

                    '    Application.ShowAlertDialog("operazii WiwDannOAnkUch " & op.Obraz.GetType().ToString)
                    lankUchEnd = CType(op.Obraz, dwgObrazOporRasst)
                    '    Else
                    '    ' Application.ShowAlertDialog("operazii WiwDannOAnkUch " & op.NumName)
                    'End If

                    Dim lAnkUch As Rashet.wlAnkUch = New Rashet.wlAnkUch(lAnkUchBeg.Opora, lankUchEnd.Opora)
                    CollId.Add(dbPrim.CreateLine(lankUchEnd.DwgX, DwgYDl, lankUchEnd.DwgX, DwgYUgl))
                    Dim lXDwgWiwTxt As Double = lAnkUchBeg.DwgX + 0.5 * (lankUchEnd.DwgX - lAnkUchBeg.DwgX) - 4
                    Dim lpiketajPred As Double = lAnkUchBeg.Opora.PiketajOporW_SledUchastke
                    If lpiketajPred < 0 Then lpiketajPred = lAnkUchBeg.Opora.Piketaj
                    CollId.Add(dbPrim.CreateText(New Point3d(lXDwgWiwTxt, DwgYdlT, 0), Format(CLng(lankUchEnd.Opora.Piketaj) - CLng(lpiketajPred), "#."), dwgObrazOporRasst.WisTextR))
                    If lAnkUch.MaxnumProleta > 0 Then
                        CollId.Add(dbPrim.CreateText(New Point3d(lXDwgWiwTxt, DwgYDPrivedT, 0), Format(lAnkUch.DlinaPrivedProleta, "#."), dwgObrazOporRasst.WisTextR))
                    Else
                        CollId.Add(dbPrim.CreateText(New Point3d(lXDwgWiwTxt, DwgYDPrivedT, 0), "--", 3))
                    End If

                End If



            End If

        Next
        dbPrim.changeSloj(CollId, DwgParam.SlRasstOpor)
        dbPrim.Wkl(CollId)
    End Sub
    ''' <summary>
    ''' Вывод только расстановки опор
    ''' </summary>
    ''' <remarks></remarks>
    Shared Sub WiwRasstNaProfil()
        Dim objMechUsl As New dwgWiwMechusl(clsKommandBase.gRasst)
        If clsKommandBase.gTrassa.objGeom.obrParam.TipGraniz = ParamTrass.TipDetal Then

            Dim lPikBeg As clsPrf.ClsPiket = clsKommandBase.gTrassa.Piket(clsKommandBase.gTrassa.objGeom.obrParam.BegUch)
            Dim lpikEnd As clsPrf.ClsPiket = clsKommandBase.gTrassa.Piket(clsKommandBase.gTrassa.objGeom.obrParam.EndUch)
            dwgWiwRasst.wiwOpNaProfilw(lPikBeg, lpikEnd)
            objMechUsl.Wiw(lPikBeg.RastOtnachala, lpikEnd.RastOtnachala)
        Else
            dwgWiwRasst.wiwOpNaProfilw()

            WiwDannOAnkUch()
            objMechUsl.Wiw()
        End If




        Kommand.changeSloj(objMechUsl.ObrazWiwod, DwgParam.SlRasstUslow)


    End Sub

#End Region

#End Region

    Public Sub New()

    End Sub
End Class
