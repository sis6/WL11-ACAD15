Imports BazDwg
Imports OperBD

#If ARX_APP Then
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.DatabaseServices
#Else
Imports Teigha.Geometry
Imports Teigha.DatabaseServices
#End If

Public Class ProbaPreobrRealDwg
    Property Tip As Boolean
    Property Glubina As Double
    Property Consistezij As Integer
    Private wOtmetkaDwg As Double
    Sub New(iproba As LeseGeoIzDwg.ProbaDwg, iOtmetkaPrf As Double, iKoorGeo As clsKoor)
        wOtmetkaDwg = iproba.OtmetkaDwg
        Tip = iproba.Tip
        Consistezij = iproba.Consistezij
        Glubina = iOtmetkaPrf - iKoorGeo.GetReal(wOtmetkaDwg)
    End Sub
    Sub New(iProba As DsGeologij.geoMonolitRow, iotmetkaPrf As Double, ikoorGeo As clsKoor)
        Tip = CBool(iProba.IdTipMonolit)
        Glubina = iProba.Glubina
        Consistezij = iProba.IdConsistenz
        wOtmetkaDwg = ikoorGeo.GetDwg(iotmetkaPrf - Glubina)
    End Sub
    Function WiwestiWDwg(iXdwg As Double) As Entity
        Dim lpoly As New Polyline
        If Tip Then
            lpoly.AddVertexAt(0, New Point2d(iXdwg, wOtmetkaDwg), 0, 2, 2)
        Else
            lpoly.AddVertexAt(0, New Point2d(iXdwg, wOtmetkaDwg), 0, 0, 2)
        End If
        lpoly.AddVertexAt(1, New Point2d(iXdwg, wOtmetkaDwg - 2), 0, 0, 0)
        lpoly.Layer = SkwajnaRealDwg.NameSlojDwgProb
        Return lpoly
    End Function

End Class
