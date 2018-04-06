Public Class RaspProvodProvod
    Private wProlet As Prolet3D
    Private wI_Faz As modRasstOp.Fazi
    Private wNagr As modRasstOp.tshNagr
    Private wDelectr, wDgorPred, wDvertPred As Double
    Private wDgorMin, wDvertMin, wStrela, wCosUglaNaklona As Double
    ' Private wSmeshPr As modRasstOp.Smeshenie
    Private wLambda, wdelta As Double
    Private wKoeff As modRasstOp.RaspProvodTrosKoeff
    Const Cos10Grad As Double = 0.9877
    ReadOnly Property Kriterij() As Double
        Get
            Dim lgor As Double = wDgorMin / wDgorPred
            Dim lvert As Double = wDvertMin / wDvertPred
            Return lgor * lgor + lvert * lvert
        End Get
    End Property
    ReadOnly Property P4() As Double
        Get
            Return wNagr.P4
        End Get
    End Property
    ReadOnly Property P1() As Double
        Get
            Return wNagr.P1
        End Get
    End Property
    ReadOnly Property P2() As Double
        Get
            Return wNagr.P2
        End Get
    End Property
    ReadOnly Property Kw() As Double
        Get
            Return wKoeff.Kw(P4 / P1)
        End Get
    End Property
    ReadOnly Property Kg As Double
        Get
            Return wKoeff.Kg(P2 / P1, wStrela)

        End Get
    End Property
    ReadOnly Property CosNaklona() As Double
        Get
            Return wCosUglaNaklona
        End Get
    End Property
    ReadOnly Property Strela As Double
        Get
            Return wStrela
        End Get
    End Property
    ReadOnly Property NameOpBeg As String
        Get
            Return wProlet.OpBeg.NumName
        End Get
    End Property
    ReadOnly Property NameOpEnd As String
        Get
            Return wProlet.OpEnd.NumName
        End Get
    End Property
    ReadOnly Property Faza() As modRasstOp.Fazi
        Get
            Return wProlet.Faza
        End Get
    End Property
    ReadOnly Property FazaWtor() As modRasstOp.Fazi
        Get
            Return wI_Faz
        End Get
    End Property
    ReadOnly Property Delta As Double
        Get
            Return wdelta
        End Get
    End Property
    ''' <summary>
    ''' длина поддерживающей гирлянды
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Lambda As Double
        Get
            Return wLambda
        End Get
    End Property
    ''' <summary>
    ''' Расстояние для внутренних перенапряжений
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Delektr As Double
        Get
            Return wDelectr
        End Get
    End Property
    ''' <summary>
    ''' минимальное расстояние между несмещенными проводами при горисонтальном расположение 2.5.88
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property DgorPred() As Double
        Get
            Return wDgorPred
        End Get
    End Property
    ''' <summary>
    ''' минимальное расстояние между несмещенными проводами при вертикальном  расположение 2.5.89
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property DvertPred() As Double
        Get
            Return wDvertPred
        End Get
    End Property
    ''' <summary>
    ''' минимальное фактическое расстояние по горизонтали
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property DgorMin() As Double
        Get
            Return wDgorMin
        End Get
    End Property
    ''' <summary>
    ''' минимальное фактическое расстояние по вертикали
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property DvertMin() As Double
        Get
            Return wDvertMin
        End Get
    End Property
    ''' <summary>
    ''' допустимое расстояние по вертикали
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property DvertDopust() As Double
        Get
            If DgorPred < DvertPred Then
                Dim lInter = modRasstOp.RaspProvodTrosKoeff.UstDmenDbol(DgorPred, DvertPred)
                Return lInter.GetKoeff(wDgorMin)
                Return wDvertMin
            Else
                'Dim lInter = modRasstOp.RaspProvodTrosKoeff.UstDbolDbmen(DgorPred, DvertPred)
                'Return lInter.GetKoeff(wDgorMin)
                Return wDvertMin
            End If
        End Get
    End Property
    ''' <summary>
    ''' домустимое расстояние  по горизонтали
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property DgorDopust() As Double
        Get
            If DgorPred < DvertPred Then
                'Dim lInter = modRasstOp.RaspProvodTrosKoeff.UstDmenDbol(DvertPred, DgorPred)
                'Return lInter.GetKoeff(wDvertMin)
                Return wDgorMin
            Else
                Dim lInter = modRasstOp.RaspProvodTrosKoeff.UstDbolDbmen(DvertPred, DgorPred)
                Return lInter.GetKoeff(wDvertMin)
            End If
        End Get
    End Property
    Private Sub OpredLambdaSigma(ByVal iUnom As Integer)

        If wProlet.OpBeg.Tip > 0 And wProlet.OpEnd.Tip > 0 Then
            If iUnom = 35 Then
                wdelta = 0.25
            Else
                wdelta = 0.5
            End If
            wLambda = 0
        Else
            wdelta = 0
            wLambda = (wProlet.OpBeg.DlinaKrep + wProlet.OpEnd.DlinaKrep) * 0.5
        End If
    End Sub
    Private Sub OpredPred()
        wDelectr = modRasstOp.RaspProvodTrosKoeff.MinRastWnutrPereNapr(wProlet.OpBeg.rstUch.Unom)
        Dim lwsp = Math.Sqrt(Strela + wLambda)
        wDgorPred = wDelectr + Kw * lwsp - wdelta
        If CosNaklona < Cos10Grad Then wDvertPred = (wDelectr + Kg * lwsp - wdelta) / CosNaklona Else wDvertPred = (wDelectr + Kg * lwsp - wdelta)

    End Sub
  
    Sub New(ByVal iankUch As Rashet.wlAnkUchTr, ByVal iProlet As Prolet3D)
        If iProlet.Faza = modRasstOp.Fazi.tros Then wNagr = iankUch.NagrT Else wNagr = iankUch.Nagr
        wProlet = iProlet
        OpredLambdaSigma(iProlet.OpBeg.rstUch.Unom)
        wKoeff = New modRasstOp.RaspProvodTrosKoeff

    End Sub
    ''' <summary>
    ''' Определяет минимальное сближение между проводом с заданой фазой
    ''' </summary>
    ''' <remarks></remarks>
    Sub Sfazoj(ifaz As modRasstOp.Fazi)


        wI_Faz = ifaz
        If wI_Faz <> wProlet.Faza Then
            Dim lsmech As modRasstOp.Smeshenie = wProlet.OpredPolSmeshProvodProvod(wI_Faz)
            wDgorMin = lsmech.SmeshGor
            wDvertMin = lsmech.SmeshVert
            wStrela = lsmech.Strela
            wCosUglaNaklona = lsmech.CosNaklon

            OpredPred()
        Else
            wDgorMin = 0
            wDvertMin = 0
            wStrela = 0
            wDgorPred = 0
            wDvertMin = 0
            wCosUglaNaklona = 1
        End If


    End Sub

    ''' <summary>
    ''' Определяет минимальное сближение между проводом с заданой фазой
    ''' </summary>
    ''' <remarks></remarks>
    Sub SfazojInojRejm(ifaz As modRasstOp.Fazi, iInojRejm As Rashet.Rejm)


        wI_Faz = ifaz
        If wI_Faz <> wProlet.Faza Then
            Dim lsmech As modRasstOp.Smeshenie = wProlet.OpredPolSmeshPoFaziRejm(wI_Faz, iInojRejm)
            wDgorMin = lsmech.SmeshGor
            wDvertMin = lsmech.SmeshVert
            wStrela = lsmech.Strela
            wCosUglaNaklona = lsmech.CosNaklon

            OpredPred()
        Else
            wDgorMin = 0
            wDvertMin = 0
            wStrela = 0
            wDgorPred = 0
            wDvertMin = 0
            wCosUglaNaklona = 1
        End If


    End Sub
End Class
