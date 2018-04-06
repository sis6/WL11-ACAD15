Imports BazDwg
Imports LeseGeoIzDwg
Imports OperBD

#If ARX_APP Then
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.DatabaseServices
#Else
Imports Teigha.Geometry
Imports Teigha.DatabaseServices
#End If

Public Class ConsistenzRealDwg
    Property tip As modelGeo.TipConsistenz
    Property Glubina As Double
    Private wotmetkaDwg As Double
    Sub New(iCons As clsHatch, iOtmetkaPrf As Double, ikoorGeo As clsKoor)
        wotmetkaDwg = iCons.OtmetkaBegPodwg
        tip = CType(ObrazGeologii.OpredNumCons(iCons), modelGeo.TipConsistenz)
        Glubina = iOtmetkaPrf - ikoorGeo.GetReal(wotmetkaDwg)
    End Sub
    Sub New(iCons As DsGeologij.geoConsistenzRow, iotmetkaprf As Double, ikoorGeo As clsKoor)
        tip = CType(iCons.Consistenz, modelGeo.TipConsistenz)
        Glubina = iCons.Glubina

        wotmetkaDwg = ikoorGeo.GetDwg(iotmetkaprf - Glubina)
    End Sub
    ''' <summary>
    ''' выводит консистенцию внутри скважины
    ''' </summary>
    ''' <param name="iXdwg"> координата в чертеже центра скважины </param>
    ''' <param name="ikoorgeo">  объект для пересчета координат образа геологии  </param>
    ''' <param name="iglubinaPosle"> глубина конца консистенции </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function WiwestiWDwg(iXdwg As Double, ikoorgeo As clsKoor, iglubinaPosle As Double) As Entity

        Dim lKontur As New Point2dCollection      'lperesUch.GetSmeschen(, ikoorGeo.Koeff * iRazrEnd.Glubina)
        Dim lshirina = iglubinaPosle - Glubina
        Dim lotmetkadwgNiz = wotmetkaDwg - ikoorgeo.Koeff * lshirina
        lKontur.Add(New Point2d(iXdwg - 1, wotmetkaDwg))
        lKontur.Add(New Point2d(iXdwg - 1, lotmetkadwgNiz))
        lKontur.Add(New Point2d(iXdwg + 1, lotmetkadwgNiz))
        lKontur.Add(New Point2d(iXdwg + 1, wotmetkaDwg))


        Dim lcolor = -1
        If tip = modelGeo.TipConsistenz.net OrElse tip = modelGeo.TipConsistenz.gl_TugPlast Then lcolor = 0

        Dim lhatch As Hatch = ParamHatch.CreatehatchPoParamHatch(SkwajnaRealDwg.NameSlojDwgConsistenz, lKontur, ObrazGeologii.ParamHatchCons(tip), lcolor, 1)
        If tip = modelGeo.TipConsistenz.gl_TugPlast Then
            Dim lp1, lp2 As Point2d


            lp1 = New Point2d(iXdwg, wotmetkaDwg)
            lp2 = New Point2d(iXdwg, lotmetkadwgNiz)

            Dim lin = dbPrim.CreateLine(lp1.X, lp1.Y, lp2.X, lp2.Y)
            lin.Layer = SkwajnaRealDwg.NameSlojDwgConsistenz
            dbPrim.Wkl(lin)
        End If

        Return lhatch
    End Function
End Class
