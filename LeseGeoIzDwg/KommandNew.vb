
Imports System.Collections.Generic
#If ARX_APP Then
Imports Autodesk.AutoCAD.Geometry
#Else
Imports Teigha.Geometry
#End If
'Функции работы только с профилем
Public Module KommandNew
   

    ''' <summary>
    ''' для упорядочивания образа слоев по началу
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ComparatorSlojIgeDwg
        '
        Implements IComparer(Of SlojIgeDwg)

        Public Function Compare(ByVal x As SlojIgeDwg, ByVal y As SlojIgeDwg) As Integer Implements System.Collections.Generic.IComparer(Of SlojIgeDwg).Compare


            If Math.Abs(x.RastOtNachalaDwgBeg - y.RastOtNachalaDwgBeg) < ObrazGeoloGii.DopuskGeoDwgX Then
                If Math.Abs(x.OtmetkaBegPodwg - y.OtmetkaBegPodwg) < ObrazGeoloGii.KritBlizostiDwg Then
                    If Math.Abs(x.OtmetkaEndPoDwg - y.OtmetkaEndPoDwg) < ObrazGeoloGii.KritBlizostiDwg Then
                        Return 0
                    Else
                        Return x.OtmetkaEndPoDwg.CompareTo(y.OtmetkaEndPoDwg)
                    End If
                Else
                    Return x.OtmetkaBegPodwg.CompareTo(y.OtmetkaBegPodwg)
                End If




            End If

            Return x.RastOtNachalaDwgBeg.CompareTo(y.RastOtNachalaDwgBeg)


        End Function

        Shared Sub SearchAndInsert( _
ByVal lis As List(Of SlojIgeDwg), _
ByVal insert As SlojIgeDwg, ByVal dc As IComparer(Of SlojIgeDwg))



            Dim index As Integer = lis.BinarySearch(insert, dc)

            If index < 0 Then
                index = index Xor -1
                lis.Insert(index, insert)
            End If
        End Sub
    End Class
    ''' <summary>
    ''' упорядочивание образов слоев по конечной границы
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ComparatorSlojIgeDwgEnd
        'для упорядочивания точек из Autocad
        Implements IComparer(Of SlojIgeDwg)

        Public Function Compare(ByVal x As SlojIgeDwg, ByVal y As SlojIgeDwg) As Integer Implements System.Collections.Generic.IComparer(Of SlojIgeDwg).Compare


            If Math.Abs(x.RastOtNachalaDWGEnd - y.RastOtNachalaDWGEnd) < ObrazGeoloGii.DopuskGeoDwgX Then
                If Math.Abs(x.OtmetkaEndPoDwg - y.OtmetkaEndPoDwg) < ObrazGeoloGii.KritBlizostiDwg Then Return 0
                Return x.OtmetkaEndPoDwg.CompareTo(y.OtmetkaEndPoDwg)


            End If

            Return x.RastOtNachalaDWGEnd.CompareTo(y.RastOtNachalaDWGEnd)
            Return 1


        End Function
    End Class
    Sub SearchAndInsert( _
ByVal lis As List(Of String), _
ByVal insert As String)
        Dim index As Integer = lis.BinarySearch(insert)

        If index < 0 Then
            index = index Xor -1
            lis.Insert(index, insert)
        End If
    End Sub
    ''' <summary>
    ''' Упорядочивание образов разрезов слоев в чертеже по Y.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ComparatorRazrezSlojIgeDwgY
        'для упорядочивания слоев в порядке 
        Implements IComparer(Of RazrezSlojIgeDwg)

        Public Function Compare(ByVal x As RazrezSlojIgeDwg, ByVal y As RazrezSlojIgeDwg) As Integer Implements System.Collections.Generic.IComparer(Of RazrezSlojIgeDwg).Compare


            If Math.Abs(x.YwerhDwg - y.YwerhDwg) < 0.1 Then
                '  Return y.Tolshina.CompareTo(x.Tolshina)
                Return 0
            End If

            
            Return x.YwerhDwg.CompareTo(y.YwerhDwg)
            '  End If



        End Function
        Shared Sub SearchAndInsert( _
 ByVal lis As List(Of RazrezSlojIgeDwg), _
 ByVal insert As RazrezSlojIgeDwg, ByVal dc As ComparatorRazrezSlojIgeDwgY)
            Dim index As Integer = lis.BinarySearch(insert, dc)
            If index < 0 Then
                index = index Xor -1
                lis.Insert(index, insert)
            End If
        End Sub
    End Class
    Public Class ComparatorPoProbamDwg
        'для упорядочивания слоев в порядке убывания 
        Implements IComparer(Of ProbaDwg)
        Public Function Compare(ByVal x As ProbaDwg, ByVal y As ProbaDwg) As Integer Implements System.Collections.Generic.IComparer(Of ProbaDwg).Compare
            'If x Is Nothing Then Return -1
            'If y Is Nothing Then Return 1
            '   Меньше нуля

            'Этот экземпляр меньше параметра value.

            Return -x.OtmetkaDwg.CompareTo(y.OtmetkaDwg)
            'If x.OtmetkaDwg > y.OtmetkaDwg Then
            '    Return 1
            'Else
            '    Return -1
            'End If
            '   Return 1
        End Function
        Sub SearchAndInsert(ByVal lis As List(Of ProbaDwg), ByVal insert As ProbaDwg)
            Dim index As Integer = lis.BinarySearch(insert, Me)

            If index < 0 Then
                index = index Xor -1
                lis.Insert(index, insert)
            End If
        End Sub
    End Class
    ''' <summary>
    ''' упорядочивание образов скважин по X 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ComparatorObrazSkwajnPoX

        Implements IComparer(Of ObrazSkwajn)

        Public Function Compare(ByVal x As ObrazSkwajn, ByVal y As ObrazSkwajn) As Integer Implements System.Collections.Generic.IComparer(Of ObrazSkwajn).Compare


            If Math.Abs(x.ZentrSkwajnDwg - y.ZentrSkwajnDwg) < 0.01 Then Return 0
            If x.ZentrSkwajnDwg > y.ZentrSkwajnDwg Then
                Return 1
            Else
                Return -1
            End If

        End Function
        Shared Sub SearchAndInsert( _
      ByVal lis As List(Of ObrazSkwajn), _
      ByVal insert As ObrazSkwajn, ByVal dc As ComparatorObrazSkwajnPoX)



            Dim index As Integer = lis.BinarySearch(insert, dc)

            If index < 0 Then
                index = index Xor -1
                lis.Insert(index, insert)
            End If
        End Sub
    End Class
    ''' <summary>
    ''' Упорядочивание построеных по примитивам скважин.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ComparatorSkwajn
        '
        Implements IComparer(Of PostroenijSkwajEntity)

        Public Function Compare(ByVal x As PostroenijSkwajEntity, ByVal y As PostroenijSkwajEntity) As Integer Implements System.Collections.Generic.IComparer(Of PostroenijSkwajEntity).Compare


            If Math.Abs(x.Xust - y.Xust) < 0.01 Then Return 0
            If x.Xust > y.Xust Then
                Return 1
            Else
                Return -1
            End If

        End Function
        Shared Sub SearchAndInsert( _
ByVal lis As List(Of LeseGeoIzDwg.PostroenijSkwajEntity), _
ByVal insert As LeseGeoIzDwg.PostroenijSkwajEntity, ByVal dc As LeseGeoIzDwg.ComparatorSkwajn)



            Dim index As Integer = lis.BinarySearch(insert, dc)

            If index < 0 Then
                index = index Xor -1
                lis.Insert(index, insert)
            End If
        End Sub
    End Class
    Public Class ComparatorParamIge
        'для упорядочивания парамтров слоев ИГЭ
        Implements IComparer(Of ParamIge)
        'Public Shared Function CompareHatch(X As ParamIge, Y As BazfunNet.ParamHatch) As Integer
        '    If X.PatternName.CompareTo(Y.PatternName) <> 0 Then Return 1
        '    If X.PatternScale.CompareTo(Y.PatternScale) <> 0 Then Return 1 ' X.PatternScale.CompareTo(Y.PatternScale)
        '    If X.PatternAngle.CompareTo(Y.PatternAngle) <> 0 Then Return 1 'X.PatternAngle.CompareTo(Y.PatternAngle)
        '    Return 0
        'End Function
        Public Function Compare(ByVal x As ParamIge, ByVal y As ParamIge) As Integer Implements System.Collections.Generic.IComparer(Of ParamIge).Compare
            Dim retval As Integer = x.IndexIge.CompareTo(y.IndexIge)
            If retval = 0 Then
                Dim retvalName As Integer = x.PatternName.CompareTo(y.PatternName)
                If retvalName = 0 Then
                    Dim retvalScale As Integer = x.PatternScale.CompareTo(y.PatternScale)
                    If retvalScale = 0 Then
                        Return x.PatternAngle.CompareTo(y.PatternAngle)
                    Else
                        Return retvalScale
                    End If
                Else
                    Return retvalName
                End If

            Else
                Return retval
            End If



        End Function
        Shared Sub SearchAndInsert( _
ByVal lis As List(Of LeseGeoIzDwg.ParamIge), _
ByVal insert As LeseGeoIzDwg.ParamIge, ByVal dc As LeseGeoIzDwg.ComparatorParamIge)



            Dim index As Integer = lis.BinarySearch(insert, dc)

            If index < 0 Then
                index = index Xor -1
                lis.Insert(index, insert)
            End If
        End Sub
    End Class
    Public Class ComparatorIndexIge
        'для упорядочивания парамтров слоев ИГЭ
        Implements IComparer(Of ParamIge)
       
        Public Function Compare(ByVal x As ParamIge, ByVal y As ParamIge) As Integer Implements System.Collections.Generic.IComparer(Of ParamIge).Compare
            Dim retval As Integer = x.IndexIge.CompareTo(y.IndexIge)
            Return retval
            'If retval = 0 Then
            '    Dim retvalName As Integer = x.PatternName.CompareTo(y.PatternName)
            '    If retvalName = 0 Then
            '        Dim retvalScale As Integer = x.PatternScale.CompareTo(y.PatternScale)
            '        If retvalScale = 0 Then
            '            Return x.PatternAngle.CompareTo(y.PatternAngle)
            '        Else
            '            Return retvalScale
            '        End If
            '    Else
            '        Return retvalName
            '    End If

            'Else
            '    Return retval
            'End If



        End Function
        Shared Sub SearchAndInsert( _
ByVal lis As List(Of LeseGeoIzDwg.ParamIge), _
ByVal insert As LeseGeoIzDwg.ParamIge, ByVal dc As LeseGeoIzDwg.ComparatorIndexIge)



            Dim index As Integer = lis.BinarySearch(insert, dc)

            If index < 0 Then
                index = index Xor -1
                lis.Insert(index, insert)
            End If
        End Sub
    End Class

    'Public Class ComparatorSlojGeoX
    '    'для упорядочивания точек из Autocad
    '    Implements IComparer(Of RazrezSlojIgeDwg)

    '    Public Function Compare(ByVal x As RazrezSlojIgeDwg, ByVal y As RazrezSlojIgeDwg) As Integer Implements System.Collections.Generic.IComparer(Of RazrezSlojIgeDwg).Compare


    '        If Math.Abs(x.Xsloj - y.Xsloj) < 0.01 Then
    '            If Math.Abs(x.YnizDwg - y.YnizDwg) < 0.01 Then Return 0
    '            If x.YnizDwg < y.YnizDwg Then
    '                Return 1
    '            Else
    '                Return -1
    '            End If
    '        End If

    '        If x.Xsloj > x.YnizDwg Then
    '            Return 1
    '        Else
    '            Return -1
    '        End If

    '    End Function
    'End Class
    ''' <summary>
    ''' находит пересечения со штриховкой представляющей геологический слой 
    ''' прямо проходящей через заданную точку параллейно оси OX
    ''' </summary>
    ''' <param name="iHatchIdentfikator"> обертка штриховка(HatchIdentifikator) приведеная  представляющая геологический слой c определенным идентификатором слоя </param>
    ''' <param name="iPoint"> заданая точка </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function PeresechenieLineHatch(iHatchIdentfikator As SlojIgeDwg, iPoint As Point3d) As RazrezSlojIgeDwg
        Return New RazrezSlojIgeDwg(iPoint.X, iHatchIdentfikator)
    End Function
    ' ''' <summary>
    ' ''' находит пересечения со штриховкой представляющей геологический слой 
    ' ''' прямо проходящей через заданную точку параллейно оси OX
    ' ''' </summary>
    ' ''' <param name="iHatch"> штриховка представляющая геологический слой </param>
    ' ''' <param name="iPoint"> заданая точка </param>
    ' ''' <returns></returns>
    ' ''' <remarks> для произвольной штриховки </remarks>
    'Private Function PeresechenieLineHatch(iHatch As Hatch, iPoint As Point3d) As RazrezSlojIgeDwg

    '    Return New RazrezSlojIgeDwg(iPoint.X, iHatch)
    'End Function
    Sub SearchAndInsert(Of T)(ByVal lis As List(Of T), ByVal insert As T)



        Dim index As Integer = lis.BinarySearch(insert)

        If index < 0 Then
            index = index Xor -1
            lis.Insert(index, insert)
        End If
    End Sub

End Module
