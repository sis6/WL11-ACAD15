Imports BazDwg

Public Module GlobParam
	Public Const Eps As Double = 0.000001


	',ISO штриховая (дл. промежутки) __    __    __    __    __    __
	'A,12,-18
	'*,ISO ш/пункт. (дл. штрихи) ____ . ____ . ____ . ____ . _


	'Public gRejRab As New Object
	Public gDostup As OperBD.dostup
	Public Function ProvZagruzki() As Boolean
        If clsKommandBase.gRasst Is Nothing Then
            BazDwg.SystemKommand.Soob("трасса не загружена ")
            Return False
        Else
            Return True
        End If
    End Function



End Module
