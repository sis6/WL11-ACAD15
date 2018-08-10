
#If ARX_APP Then
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.DatabaseServices

#Else

Imports Teigha.DatabaseServices

Imports Teigha.Geometry


#End If


Imports Rashet
Imports BazDwg

Imports ProfilBaseDwg

''' <summary>
''' Класс предназначен для вывода в чертеж таблицы результатов расчета
''' </summary>
''' <remarks></remarks>
Public Class dwgWiwRezRascheta

    Const KolwoStolbzow As Integer = 8

    Private wStrokiTabl(,) As String
    Private wAnkUch As Rashet.wlAnkUch
    Private wColllReshenie As Collection
    Private wOpDwgBeg, wOpDwgEnd As dwgObrazOporRasst
    Private wOs As Double
    Private wNameSlRazmeschenij As String
    Sub New(iTrassa As DwgTr, IankUch As wlAnkUch, iRezRaschet As UrSostAuI(Of modRasstOp.rstProlet))
        wOs = iTrassa.OsKlRasst - 10
        wAnkUch = IankUch
        wColllReshenie = iRezRaschet.Reshenie
        wOpDwgBeg = New dwgObrazOporRasst(IankUch.BegOpAnkUch)
        wOpDwgEnd = New dwgObrazOporRasst(IankUch.EndOpAnkUch)
        wNameSlRazmeschenij = DwgParam.SlRasstRezRashet
    End Sub
    WriteOnly Property SlojRazmeschenij As String
        Set(value As String)
            wNameSlRazmeschenij = value
        End Set
    End Property
#Region "вывод таблиц"


    Private Sub SozdatDannTabl()
        Dim lRazmtabl As Integer = wColllReshenie.Count
        Dim lNumStr As Integer = 0
        Dim lPiketajPred As Double = wAnkUch.BegOpAnkUch.Piketaj

        ReDim wStrokiTabl(lRazmtabl, KolwoStolbzow)
        'wStrokiTabl(lNumStr, 0) = "Исх. реж."
        'wStrokiTabl(lNumStr, 1) = "σ =" & Format(wAnkUch.gpIshRej.Sigma, "f1") & "Н/мм²"
        'wStrokiTabl(lNumStr, 2) = "γ = " & Format(wAnkUch.gpIshRej.Gamma, "f2") & "Н/м•мм²"
        'wStrokiTabl(lNumStr, 3) = "t =" & Format(wAnkUch.gpIshRej.Temp, "f0") & "˚"
        'wStrokiTabl(lNumStr, 4) = " -> "
        'wStrokiTabl(lNumStr, 5) = "Габ. реж."
        'wStrokiTabl(lNumStr, 6) = "σ =" & Format(wAnkUch.gpGabRej.Sigma, "f1") & "Н/мм²"
        'wStrokiTabl(lNumStr, 7) = "γ = " & Format(wAnkUch.gpGabRej.Gamma, "f2") & "Н/м•мм²"
        'wStrokiTabl(lNumStr, 8) = "t =" & Format(wAnkUch.gpIshRej.Temp, "f0") & "˚"
        ''   wStrokiTabl(lNumStr, 9) = "___"
        'lNumStr += 1
        ' wStrokiTabl(lNumStr, 0) = "N"
        wStrokiTabl(lNumStr, 0) = "№ опоры"
        wStrokiTabl(lNumStr, 1) = "Тип опоры "
        wStrokiTabl(lNumStr, 2) = "Пикет, м"
        wStrokiTabl(lNumStr, 3) = "Длина пролета, м"

        wStrokiTabl(lNumStr, 4) = "Вес. пролет, м"
        wStrokiTabl(lNumStr, 5) = "Ветр. пролет, м"  ' ветровой
        wStrokiTabl(lNumStr, 6) = "Нагр. верт., Н"
        wStrokiTabl(lNumStr, 7) = "Нагр. гор., Н"
        wStrokiTabl(lNumStr, 8) = "Откл гирл., м"
        lNumStr += 1
        For Each el As Rashet.rstRezReshUrSost In wColllReshenie
            Dim lDlpred = el.Piketaj - lPiketajPred
            ' wStrokiTabl(lNumStr, 0) = CStr(lNumStr)
            wStrokiTabl(lNumStr, 0) = el.Numname
            wStrokiTabl(lNumStr, 1) = el.TipOpor
            wStrokiTabl(lNumStr, 2) = clsPrf.ClsPiket.PiketWstr(el.Piketaj)
            wStrokiTabl(lNumStr, 3) = Format(lDlpred, "F0")

            wStrokiTabl(lNumStr, 4) = Format(el.WesProlet, "F1")
            wStrokiTabl(lNumStr, 5) = Format(0.5 * (el.DlinaProleta + lDlpred), "F1")  ' ветровой
            wStrokiTabl(lNumStr, 6) = Format(el.NagrV, "F0")
            wStrokiTabl(lNumStr, 7) = Format(el.NagrH, "F0")
            wStrokiTabl(lNumStr, 8) = Format(el.Otkl, "F2")
            lPiketajPred = el.Piketaj
            lNumStr += 1
        Next
    End Sub
    ''' <summary>
    ''' формирует строку для вывода над таблицей
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function StrRejm() As String
        Dim lStr(KolwoStolbzow) As String
        lStr(0) = "Исх. реж."
        lStr(1) = "{\H1.2x;σ}=" & Format(wAnkUch.gpIshRej.Sigma, "f1") & "Н/мм²"
        lStr(2) = "γ=" & Format(wAnkUch.gpIshRej.Gamma, "f2") & "Н/м•мм²"
        lStr(3) = "t=" & Format(wAnkUch.gpIshRej.Temp, "f0") & "˚"
        lStr(4) = " "
        lStr(5) = "Габ. реж."
        lStr(6) = "σ=" & Format(wAnkUch.gpGabRej.Sigma, "f1") & "Н/мм²"
        lStr(7) = "γ=" & Format(wAnkUch.gpGabRej.Gamma, "f2") & "Н/м•мм²"
        lStr(8) = "t=" & Format(wAnkUch.gpIshRej.Temp, "f0") & "˚"
        ' lStr(9) = "___"
        ' Return lStr
        Return Strings.Join(lStr, " ")
    End Function
    ''' <summary>
    ''' формирует строку для вывода над таблицей используя внутренние функции класса Rejm
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function StrRejm2() As String
        Return wAnkUch.gpIshRej.StrWiwodParam("Исх. реж.") & wAnkUch.gpGabRej.StrWiwodParam(" Габ. реж.")
    End Function
    ''' <summary>
    ''' Обеспечивает вывод в чертеж таблицы с результатами расчета решения уравнения состояний в режиме полученом при определение габаритного пролета
    ''' выво даблице надначальной  опорой анкерного участка
    ''' </summary>
    ''' <remarks></remarks>
    Sub WiwodWDwg()
        SozdatDannTabl()
        Dim ShirStolbzow() As Double = {20, 40}
        Dim Obraz As New ObjectIdCollection
        Dim OtstupOtGranizLista As Double = 40

        Kommand.createNewLayer(wNameSlRazmeschenij) 'проверяем наличие нужного слое если надо то его создаем
        ' Kommand.OchistSloj(GlobParamRst.SlRezRashet)





        Dim ShirLista = clsKommandBase.gTrassa.objGeom.obrParam.ShirinaLista
        Dim lGrTrass = clsKommandBase.gTrassa.DwgXpoRast(clsKommandBase.gTrassa.Dlina)
        ' Dim wOsX As Double = gTrassa.objGeom.Podpis.OsX
        Dim PoXWiw As Double = wOpDwgBeg.DwgX
        Dim PoYwiw As Double = wOs - 5

        Obraz.Add(dwgText.CreateMText(New Point3d(PoXWiw, PoYwiw, 0), StrRejm2, 270, 4))
        Obraz.Add(MakeEntitesLista.CreateTable(New Point3d(PoXWiw, PoYwiw - 7, 0), ShirStolbzow, wStrokiTabl,
                                               "Весовые и ветровые пролеты: Опора № " & wOpDwgBeg.Opora.NumName & " - Опора № " & wOpDwgEnd.Opora.NumName, ""))



        Kommand.changeSloj(Obraz, wNameSlRazmeschenij)
    End Sub

#End Region
End Class
