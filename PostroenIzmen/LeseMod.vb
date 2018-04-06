Imports modRasstOp
Imports System.Collections.Generic

''' <summary>
''' Читает модель из словарей глобальной расстановки b jgthfwbb c ytq
''' </summary>
''' <remarks></remarks>
Public Class LeseMod
    Private wRasst As modRasstOp.wlRasst
    ''' <summary>
    ''' Читает расстановку из глобального словаря
    ''' </summary>
    ''' <remarks></remarks>
    Sub LeseIsDwg()
        Dim lnamelin As String = ""
        Dim lunom As Integer
        Dim lnamerab As String = ""
        LeseSreib.clsLeseSrejbRasstDwg.IzwlechDannOLini(LeseSreib.KorSlDann, lnamelin, lnamerab, lunom)

        wRasst = New modRasstOp.wlRasst(New clsPrf.clsTrass(lnamelin, lnamerab, lunom))
        Dim dnDwg As New LeseSreib.clsLeseSrejbRasstDwg(LeseSreib.KorSlDann, wRasst)
        If Not dnDwg.Izwlech() Then wRasst = Nothing

    End Sub
    ''' <summary>
    ''' Список расстояний опор от начала расстановки
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property RastOp() As List(Of Double)
        Get
            Dim lrast As New List(Of Double)
            For Each el_op As modRasstOp.wlOpRasst In wRasst.opColl
                lrast.Add(el_op.RastOtNachala)
            Next
            Return lrast

        End Get
    End Property
    Sub New()
        Dim wdostup As New OperBD.dostup
        LeseIsDwg()
    End Sub
    Sub New(ByVal iRasst As wlRasst)
        wRasst = iRasst
    End Sub
    ReadOnly Property NotRasst As Boolean
        Get
            Return wRasst Is Nothing
        End Get
    End Property
    ''' <summary>
    ''' Возвращает расстановку(с профилем) 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Rasst() As modRasstOp.wlRasst
        Get
            Return wRasst
        End Get
    End Property
    ReadOnly Property Opori() As Collection
        Get
            Return wRasst.opColl
        End Get
    End Property

End Class
