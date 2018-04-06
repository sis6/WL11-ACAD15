
#If ARX_APP Then
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.Runtime
Imports DBTransMan = Autodesk.AutoCAD.DatabaseServices.TransactionManager
#Else
Imports Bricscad.ApplicationServices
Imports Teigha.DatabaseServices
Imports Teigha.Geometry
Imports Teigha.Runtime
Imports DBTransMan = Teigha.DatabaseServices.TransactionManager
#End If

Imports System.Collections.Generic

''' <summary>
''' По списку Point3D строит модель профиля в требуемом формате
''' </summary>
''' <remarks></remarks>
Public Class PoSpPoint3dProf
    Const DwaPi As Double = 2.0 * Math.PI
    Private wLsp As New List(Of PointProf)
    ''' <summary>
    ''' Определяет угол в плане в I точке полилинии
    ''' </summary>
    ''' <param name="iSp"> список точек  </param>
    ''' <param name="i"> номер точке</param>
    ''' <returns>угол в радианах </returns>
    ''' <remarks></remarks>
    Public Shared Function Ugol(ByVal iSp As List(Of Point3d), ByVal i As Integer) As Double
        Dim pm1 As Point3d = iSp(i - 1)
        Dim p As Point3d = iSp(i)
        Dim pp1 As Point3d = iSp(i + 1)
        ' Dim vekm As Vector2d = New Vector2d(p.X - pm1.X, p.Y - pm1.Y)
        Dim vekm As Vector2d = New Vector2d(pm1.X - p.X, pm1.Y - p.Y)
        '  Dim vekp As Vector2d = New Vector2d(pp1.X - p.X, pp1.Y - p.Y)
        Dim vekp As Vector2d = New Vector2d(p.X - pp1.X, p.Y - pp1.Y)
        Dim w1 As Double = vekp.Angle - vekm.Angle
        Dim w2 As Double = vekm.GetAngleTo(vekp)
        If w1 > Math.PI Then w1 = w1 - DwaPi
        If w1 < -Math.PI Then w1 = w1 + DwaPi
        If Math.Abs(w2) > 1.5 Then
            Dim w4 = w1 - Math.PI
        End If
        Return Math.Sign(w1) * w2
    End Function
    ReadOnly Property SpToshek() As List(Of PointProf)
        Get
            Return wLsp
        End Get
    End Property
    Sub New(ByVal Sp As List(Of Point3d))


        Dim lPred As PointProf = Nothing

        Dim ltek As PointProf
        With Sp(0) ' первая угол неопределен
            ltek = New PointProf(.X, .Y, .Z, 0, lPred)
        End With
        wLsp.Add(ltek)
        lPred = ltek

        For I As Integer = 1 To Sp.Count - 2
            Dim lugol As Double
            lugol = Ugol(Sp, I)

            With Sp(I)
                ltek = New PointProf(.X, .Y, .Z, lugol, lPred)
            End With

            wLsp.Add(ltek)
            lPred = ltek



        Next
        With Sp(Sp.Count - 1)
            ltek = New PointProf(.X, .Y, .Z, 0, lPred)
        End With

        wLsp.Add(ltek)

    End Sub

    Function Count() As Integer
        Return wLsp.Count
    End Function

End Class

