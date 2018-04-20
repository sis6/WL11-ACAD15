#If ARX_APP Then
Imports Autodesk.AutoCAD.DatabaseServices
#Else
Imports Teigha.DatabaseServices
#End If
Imports BazDwg

Public Class ParamLine
    Private wLinetype As String
    Private wLinetypeScale As Double
    Private wLineWeight As LineWeight
    Sub New(elobr As Entity)
        If elobr Is Nothing Then
            wLinetype = "ByLayer"
            wLinetypeScale = 1
            wLineWeight = LineWeight.ByLayer
        Else
            wLinetype = elobr.Linetype
            wLinetypeScale = elobr.LinetypeScale
            wLineWeight = elobr.LineWeight
        End If

    End Sub
    Sub New()
        wLinetype = "ByLayer"
        wLinetypeScale = 1
        wLineWeight = LineWeight.ByLayer
    End Sub
#Region "ReadOnlu"
    ReadOnly Property Linetype As String
        Get
            Return wLinetype
        End Get
    End Property
    ReadOnly Property LinetypeScale As Double
        Get
            Return wLinetypeScale
        End Get
    End Property
    ReadOnly Property LineWeight As LineWeight
        Get
            Return wLineWeight
        End Get
    End Property
#End Region
End Class
Public Class fizMechParam
    Public Plotnost, DawlenieC, Figrad As Double
    Sub New()
        Plotnost = Double.NaN
        DawlenieC = Double.NaN
        Figrad = Double.NaN
    End Sub
End Class

Public Class fizMechIge
	Private IndexOpisanie As Integer
	Private wNormFizMech, wNesSposobFizMech, wDeformFizMech As New fizMechParam
	Private wNormJun As Double
	Private wRo, wRc As Double
	Private StrojGruppa As String

End Class
Public Class ParamIge
	Inherits ParamHatch

	Private wIndexIge As String
	Private wStrWozrast As String
    Public ReadOnly Property IndexIge() As String
        Get
            Return wIndexIge
        End Get
    End Property
    Public Sub SetIndexIge(iIndexIge As String)
        wIndexIge = iIndexIge
    End Sub
    Public Property Wozrast As String

        Get

            Return wStrWozrast
        End Get
        Set(value As String)
            wStrWozrast = value
        End Set
    End Property
    'Public Function GetParamIgeRow() As modelGeo.dsGeologij.geoParamIgeRow
    '    Dim l = modelGeo.dsGeologij.geoParamIgeRow.
    'End Function


    Sub New(iSl As SlojIgeDwg, iStrtWozrast As String)
        MyBase.New(iSl.GetHatch.PatternName, iSl.GetHatch.PatternScale, iSl.GetHatch.PatternAngle, CType(iSl.GetHatch.LineWeight, LineWeight))
        wIndexIge = iSl.IndexIge
        wStrWozrast = iStrtWozrast
    End Sub
    Sub New(iPatternName As String, iPatternScale As Double, iPatternAngle As Double, iLineWeight As LineWeight, _
            iIndexIge As String, iWozrast As String)
        MyBase.New(iPatternName, iPatternScale, iPatternAngle, iLineWeight)
        wIndexIge = iIndexIge
        wStrWozrast = iWozrast
    End Sub
	Sub New()
		MyBase.New(modelGeo.TipOpred.NamePatternIgePodefault, modelGeo.TipOpred.ScaleDefault,
				  modelGeo.TipOpred.AngleDefault, CType(modelGeo.TipOpred.LineWeightDefault, LineWeight))
		wIndexIge = modelGeo.TipOpred.IndexIgePoDefault
		wStrWozrast = modelGeo.TipOpred.WozwrastPoDefault
	End Sub

End Class