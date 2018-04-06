Option Explicit On
Option Strict On
'Imports Microsoft.Office.Interop
Imports clsPrf
Imports modRasstOp
Imports OperBD
Imports System.Data

Public Class Sw_IzBD_ConstTabl

    
    Shared Sub TipWxml()
        Dim lDsProfil As New DsProfil
        Dim ltipsoor As New dsProfilTableAdapters.TipSoorTableAdapter
        Dim ltipUgod As New dsProfilTableAdapters.TipUgodTableAdapter
        Dim lTipMest As New dsProfilTableAdapters.TipMestTableAdapter
        Dim ldsElem As New ElemRasst

        ltipsoor.Fill(lDsProfil.TipSoor)
        ltipUgod.Fill(lDsProfil.TipUgod)
        lTipMest.Fill(lDsProfil.TipMest)


        lDsProfil.TipSoor.WriteXml(My.Settings.BasePapka & "\DANN\tipsoor.xml", System.Data.XmlWriteMode.WriteSchema)
        lDsProfil.TipUgod.WriteXml(My.Settings.BasePapka & "\DANN\tipugod.xml", System.Data.XmlWriteMode.WriteSchema)
        lDsProfil.TipMest.WriteXml(My.Settings.BasePapka & "\DANN\tipmest.xml", System.Data.XmlWriteMode.WriteSchema)
        '   ldsElem.WriteXml("D:\WL_11\DANN\tipelem.xml", System.Data.XmlWriteMode.WriteSchema)
    End Sub

#Region "Init"
    Sub New()


    End Sub


#End Region
End Class
