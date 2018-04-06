Imports System
'Imports System.Windows.Forms
'#Region "Календарь"
'Public Class CalendarColumn
'    Inherits DataGridViewColumn

'    Public Sub New()
'        MyBase.New(New CalendarCell())
'    End Sub

'    Public Overrides Property CellTemplate() As DataGridViewCell
'        Get
'            Return MyBase.CellTemplate
'        End Get
'        Set(ByVal value As DataGridViewCell)

'            ' Ensure that the cell used for the template is a CalendarCell.
'            If (value IsNot Nothing) AndAlso _
'                Not value.GetType().IsAssignableFrom(GetType(CalendarCell)) _
'                Then
'                Throw New InvalidCastException("Must be a CalendarCell")
'            End If
'            MyBase.CellTemplate = value

'        End Set
'    End Property

'End Class

'Public Class CalendarCell
'    Inherits DataGridViewTextBoxCell

'    Public Sub New()
'        ' Use the short date format.
'        Me.Style.Format = "d"
'    End Sub

'    Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, _
'        ByVal initialFormattedValue As Object, _
'        ByVal dataGridViewCellStyle As DataGridViewCellStyle)

'        ' Set the value of the editing control to the current cell value.
'        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, _
'            dataGridViewCellStyle)

'        Dim ctl As CalendarEditingControl = _
'            CType(DataGridView.EditingControl, CalendarEditingControl)
'        ctl.Value = CType(Me.Value, DateTime)

'    End Sub

'    Public Overrides ReadOnly Property EditType() As Type
'        Get
'            ' Return the type of the editing contol that CalendarCell uses.
'            Return GetType(CalendarEditingControl)
'        End Get
'    End Property

'    Public Overrides ReadOnly Property ValueType() As Type
'        Get
'            ' Return the type of the value that CalendarCell contains.
'            Return GetType(DateTime)
'        End Get
'    End Property

'    Public Overrides ReadOnly Property DefaultNewRowValue() As Object
'        Get
'            ' Use the current date and time as the default value.
'            Return DateTime.Now
'        End Get
'    End Property

'End Class

'Class CalendarEditingControl
'    Inherits DateTimePicker
'    Implements IDataGridViewEditingControl

'    Private dataGridViewControl As DataGridView
'    Private valueIsChanged As Boolean = False
'    Private rowIndexNum As Integer

'    Public Sub New()
'        Me.Format = DateTimePickerFormat.Short
'    End Sub

'    Public Property EditingControlFormattedValue() As Object _
'        Implements IDataGridViewEditingControl.EditingControlFormattedValue

'        Get
'            Return Me.Value.ToShortDateString()
'        End Get

'        Set(ByVal value As Object)
'            If TypeOf value Is String Then
'                Me.Value = DateTime.Parse(CStr(value))
'            End If
'        End Set

'    End Property

'    Public Function GetEditingControlFormattedValue(ByVal context _
'        As DataGridViewDataErrorContexts) As Object _
'        Implements IDataGridViewEditingControl.GetEditingControlFormattedValue

'        Return Me.Value.ToShortDateString()

'    End Function

'    Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As  _
'        DataGridViewCellStyle) _
'        Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl

'        Me.Font = dataGridViewCellStyle.Font
'        Me.CalendarForeColor = dataGridViewCellStyle.ForeColor
'        Me.CalendarMonthBackground = dataGridViewCellStyle.BackColor

'    End Sub

'    Public Property EditingControlRowIndex() As Integer _
'        Implements IDataGridViewEditingControl.EditingControlRowIndex

'        Get
'            Return rowIndexNum
'        End Get
'        Set(ByVal value As Integer)
'            rowIndexNum = value
'        End Set

'    End Property

'    Public Function EditingControlWantsInputKey(ByVal key As Keys, _
'        ByVal dataGridViewWantsInputKey As Boolean) As Boolean _
'        Implements IDataGridViewEditingControl.EditingControlWantsInputKey

'        ' Let the DateTimePicker handle the keys listed.
'        Select Case key And Keys.KeyCode
'            Case Keys.Left, Keys.Up, Keys.Down, Keys.Right, _
'                Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp

'                Return True

'            Case Else
'                Return Not dataGridViewWantsInputKey
'        End Select

'    End Function

'    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) _
'        Implements IDataGridViewEditingControl.PrepareEditingControlForEdit

'        ' No preparation needs to be done.

'    End Sub

'    Public ReadOnly Property RepositionEditingControlOnValueChange() _
'        As Boolean Implements _
'        IDataGridViewEditingControl.RepositionEditingControlOnValueChange

'        Get
'            Return False
'        End Get

'    End Property

'    Public Property EditingControlDataGridView() As DataGridView _
'        Implements IDataGridViewEditingControl.EditingControlDataGridView

'        Get
'            Return dataGridViewControl
'        End Get
'        Set(ByVal value As DataGridView)
'            dataGridViewControl = value
'        End Set

'    End Property

'    Public Property EditingControlValueChanged() As Boolean _
'        Implements IDataGridViewEditingControl.EditingControlValueChanged

'        Get
'            Return valueIsChanged
'        End Get
'        Set(ByVal value As Boolean)
'            valueIsChanged = value
'        End Set

'    End Property

'    Public ReadOnly Property EditingControlCursor() As Cursor _
'        Implements IDataGridViewEditingControl.EditingPanelCursor

'        Get
'            Return MyBase.Cursor
'        End Get

'    End Property

'    Protected Overrides Sub OnValueChanged(ByVal eventargs As EventArgs)

'        ' Notify the DataGridView that the contents of the cell have changed.
'        valueIsChanged = True
'        Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
'        MyBase.OnValueChanged(eventargs)

'    End Sub

'End Class
'#End Region
Public Class MaskedTextBoxColumn
    Inherits DataGridViewColumn

    Public Sub New()
        MyBase.New(New MaskedTextBoxCell())
    End Sub

    Public Overrides Property CellTemplate() As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(ByVal value As DataGridViewCell)

            ' Ensure that the cell used for the template is a CalendarCell.
            If (value IsNot Nothing) AndAlso _
                Not value.GetType().IsAssignableFrom(GetType(MaskedTextBoxCell)) _
                Then
                Throw New InvalidCastException("Must be a CalendarCell")
            End If
            MyBase.CellTemplate = value

        End Set
    End Property

End Class

Public Class MaskedTextBoxCell
    Inherits DataGridViewTextBoxCell

    Public Sub New()
        ' Use the short date format.
        ' Me.Style.Format = "d"
    End Sub

    Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, _
        ByVal initialFormattedValue As Object, _
        ByVal dataGridViewCellStyle As DataGridViewCellStyle)

        ' Set the value of the editing control to the current cell value.
        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, _
            dataGridViewCellStyle)

        Dim ctl As MaskedTextBoxEditingControl = _
            CType(DataGridView.EditingControl, MaskedTextBoxEditingControl)

        ctl.Text = Me.Value.ToString()
        ctl.Mask = "L999\°99'99"
    End Sub

    Public Overrides ReadOnly Property EditType() As Type
        Get
            ' Return the type of the editing contol that CalendarCell uses.
            Return GetType(MaskedTextBoxEditingControl)
        End Get
    End Property

    Public Overrides ReadOnly Property ValueType() As Type
        Get
            ' Return the type of the value that CalendarCell contains.
            Return GetType(String)
        End Get
    End Property

    Public Overrides ReadOnly Property DefaultNewRowValue() As Object
        Get
            ' Use the current date and time as the default value.
            Return ""
        End Get
    End Property

End Class

Class MaskedTextBoxEditingControl
    Inherits MaskedTextBox
    Implements IDataGridViewEditingControl

    Private dataGridViewControl As DataGridView
    Private valueIsChanged As Boolean = False
    Private rowIndexNum As Integer

    Public Sub New()
        '   Me.Format = DateTimePickerFormat.Short
    End Sub

    Public Property EditingControlFormattedValue() As Object _
        Implements IDataGridViewEditingControl.EditingControlFormattedValue

        Get
            Return Me.Text
        End Get

        Set(ByVal value As Object)
            If TypeOf value Is String Then
                Me.Text = value.ToString
            End If
        End Set

    End Property

    Public Function GetEditingControlFormattedValue(ByVal context _
        As DataGridViewDataErrorContexts) As Object _
        Implements IDataGridViewEditingControl.GetEditingControlFormattedValue

        Return EditingControlFormattedValue

    End Function

    Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As  _
        DataGridViewCellStyle) _
        Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl

        Me.Font = dataGridViewCellStyle.Font
        Me.ForeColor = dataGridViewCellStyle.ForeColor
        Me.BackColor = dataGridViewCellStyle.BackColor

    End Sub

    Public Property EditingControlRowIndex() As Integer _
        Implements IDataGridViewEditingControl.EditingControlRowIndex

        Get
            Return rowIndexNum
        End Get
        Set(ByVal value As Integer)
            rowIndexNum = value
        End Set

    End Property

    Public Function EditingControlWantsInputKey(ByVal key As Keys, _
        ByVal dataGridViewWantsInputKey As Boolean) As Boolean _
        Implements IDataGridViewEditingControl.EditingControlWantsInputKey

        ' Let the DateTimePicker handle the keys listed.
        Select Case key And Keys.KeyCode
            Case Keys.Left, Keys.Up, Keys.Down, Keys.Right, _
                Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp

                Return True

            Case Else
                Return Not dataGridViewWantsInputKey
        End Select

    End Function

    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) _
        Implements IDataGridViewEditingControl.PrepareEditingControlForEdit

        ' No preparation needs to be done.

    End Sub

    Public ReadOnly Property RepositionEditingControlOnValueChange() _
        As Boolean Implements _
        IDataGridViewEditingControl.RepositionEditingControlOnValueChange

        Get
            Return False
        End Get

    End Property

    Public Property EditingControlDataGridView() As DataGridView _
        Implements IDataGridViewEditingControl.EditingControlDataGridView

        Get
            Return dataGridViewControl
        End Get
        Set(ByVal value As DataGridView)
            dataGridViewControl = value
        End Set

    End Property

    Public Property EditingControlValueChanged() As Boolean _
        Implements IDataGridViewEditingControl.EditingControlValueChanged

        Get
            Return valueIsChanged
        End Get
        Set(ByVal value As Boolean)
            valueIsChanged = value
        End Set

    End Property

    Public ReadOnly Property EditingControlCursor() As Cursor _
        Implements IDataGridViewEditingControl.EditingPanelCursor

        Get
            Return MyBase.Cursor
        End Get

    End Property

    Protected Overrides Sub OnTextChanged(ByVal eventargs As EventArgs)

        ' Notify the DataGridView that the contents of the cell have changed.
        valueIsChanged = True
        Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
        MyBase.OnTextChanged(eventargs)

    End Sub

End Class

'Public Class Form1
'    Inherits Form

'    Private dataGridView1 As New DataGridView()

'    <STAThreadAttribute()> _
'    Public Shared Sub Main()
'        Application.Run(New Form1())
'    End Sub

'    Public Sub New()
'        Me.dataGridView1.Dock = DockStyle.Fill
'        Me.Controls.Add(Me.dataGridView1)
'        Me.Text = "DataGridView calendar column demo"
'    End Sub

'    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) _
'        Handles Me.Load

'        Dim col As New CalendarColumn()
'        Me.dataGridView1.Columns.Add(col)
'        Me.dataGridView1.RowCount = 5
'        Dim row As DataGridViewRow
'        For Each row In Me.dataGridView1.Rows
'            row.Cells(0).Value = DateTime.Now
'        Next row

'    End Sub

'End Class
