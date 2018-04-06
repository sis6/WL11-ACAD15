Enum PolajDannRasp


    Dgor = 1
    Dvert = 2
    Delectr = 3
    Strela = 4
    DlinaGirlajnd = 5
    Delta = 6
    Vetrovaj = 7
    WesProvoda = 8
    Gololednaj = 9
    UgolNaklona = 10
    KoeffVetrWes = 11
    KoeffGololedWes = 12
   


End Enum
Public Class docExcelRasp
    Inherits WiwodDok.DocExcelBase
    Const ColumnZapolnenij As Integer = 2
    Const ColumnFaktRasst As Integer = 4
    Private wReshenie As RaspProvodProvod

    Sub New()
        MyBase.New("ShablonRasp.xltm")
        UstList("Схлестывание")
    End Sub

    Sub ZadatReshenie(iReshenie As RaspProvodProvod)
        wReshenie = iReshenie

    End Sub
    Sub zapolnit()
        With wReshenie
            Cells(PolajDannRasp.Delectr, ColumnZapolnenij) = .Delektr
            Cells(PolajDannRasp.Strela, ColumnZapolnenij) = Math.Round(.Strela, 2)

            Cells(PolajDannRasp.DlinaGirlajnd, ColumnZapolnenij) = .Lambda
           
            Cells(PolajDannRasp.Delta, ColumnZapolnenij) = .Delta
            Cells(PolajDannRasp.Vetrovaj, ColumnZapolnenij) = Math.Round(.P4, 3)
            Cells(PolajDannRasp.WesProvoda, ColumnZapolnenij) = Math.Round(.P1, 3)
            Cells(PolajDannRasp.Gololednaj, ColumnZapolnenij) = Math.Round(.P2, 3)
            Cells(PolajDannRasp.UgolNaklona, ColumnZapolnenij) = Math.Floor(Math.Acos(.CosNaklona) * 180 / Math.PI)
            Cells(PolajDannRasp.Dgor, ColumnFaktRasst) = Math.Round(.DgorMin, 2)
            Cells(PolajDannRasp.Dvert, ColumnFaktRasst) = Math.Round(.DvertMin, 2)
            Cells(PolajDannRasp.KoeffGololedWes, ColumnZapolnenij) = Math.Round(.Kg, 3)
            Cells(PolajDannRasp.KoeffVetrWes, ColumnZapolnenij) = Math.Round(.Kw, 3)
            Cells(PolajDannRasp.Dgor, 7) = .DgorDopust
            Cells(PolajDannRasp.Dvert, 7) = .DvertDopust
            Cells(PolajDannRasp.Dgor, 8) = .DgorPred
            Cells(PolajDannRasp.Dvert, 8) = .DvertPred

        End With


    End Sub
End Class
