Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.DatabaseServices

Public Class dwgOpRasstNaPolyLine
    Private wOpRasst As modRasstOp.wlOpRasst
    Private wXdwg, wYdwg As Double

#Region "Init"
    ''' <summary>
    ''' создает класс опоры расстановки с связью с полилинией
    ''' </summary>
    ''' <param name="iTchkPolylin"></param>
    ''' <param name="iOpRasst"></param>
    ''' <remarks></remarks>
    Sub New(ByVal iTchkPolylin As Point3d, ByVal iOpRasst As Object)
        wOpRasst = CType(iOpRasst, modRasstOp.wlOpRasst)
        wXdwg = iTchkPolylin.X
        wYdwg = iTchkPolylin.Y
    End Sub

    ReadOnly Property RasstOtNachala() As Double
        Get
            Return wOpRasst.RastOtNachala
        End Get
    End Property


#End Region
   
#Region "Obraz na DWg"
    ''' <summary>
    ''' ВЫводит образ опоры в точке полилинии
    ''' </summary>
    ''' <param name="coll"></param>
    ''' <param name="Razm"></param>
    ''' <remarks></remarks>
    Public Sub Wiwop(ByVal coll As DBObjectCollection, Optional ByVal Razm As Double = 1)

        With wOpRasst
            coll.Add(BazfunNet.dbPrim.CreateNakl(wXdwg, wYdwg, Razm, Razm, .UgolPoworotaOp))
            coll.Add(BazfunNet.Znaki.CreateKrug(wXdwg, wYdwg, 0.5 * Razm))
            If wOpRasst.Tip > 0 Then
                coll.Add(BazfunNet.Znaki.CreatePrTreg(wXdwg, wYdwg, Razm, .UgolPoworotaOp))

            End If

            coll.Add(BazfunNet.dbPrim.CreateMLeader(New Point3d(wXdwg + 10, wYdwg + 30, 0), New Point3d(wXdwg, wYdwg, 0), CStr(.NumName) & "\P" &
                                          CStr(.UserTipOp) & "\P" & clsPrf.clsPiket.StrPiketaj(.Piketaj)))

        End With

    End Sub
   
#End Region
End Class
