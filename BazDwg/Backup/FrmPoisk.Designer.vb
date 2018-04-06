<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPoisk
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPoisk))
        Me.SuspendLayout()
        '
        'frmPoisk
        '
        resources.ApplyResources(Me, "$this")
        Me.Name = "frmPoisk"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FSpLinRegionpBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FSpLinRegionpTableAdapter As OperBD.dsUprTableAdapters.fSpLinRegionpTableAdapter
    Friend WithEvents TrassLinBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridLinij As System.Windows.Forms.DataGridView
    Friend WithEvents FillByToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ObToolStripLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents UnomToolStripLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents FillByToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents UnomToolStripTextBox As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ObToolStripTextBox As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents UchastkiNBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents UchastkiNDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents RegPsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RegPsTableAdapter As OperBD.dsUprTableAdapters.RegPsTableAdapter
    Friend WithEvents PObjectESSlTableAdapter As OperBD.dsUprTableAdapters.pObjectESSlTableAdapter
    Friend WithEvents PObjectESSpTableAdapter As OperBD.dsUprTableAdapters.pObjectESSpTableAdapter
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TrassLinTableAdapter As OperBD.dsUprTableAdapters.TrassLinTableAdapter
    Friend WithEvents TESSTableAdapter As OperBD.dsUprTableAdapters.tESSTableAdapter
    Friend WithEvents UchastkiNTableAdapter As OperBD.dsUprTableAdapters.uchastkiNTableAdapter
    Friend WithEvents UnomNBS As System.Windows.Forms.BindingSource
    Friend WithEvents UnomNTableAdapter As OperBD.dsUprTableAdapters.UnomNTableAdapter
    Friend WithEvents tESSBS As System.Windows.Forms.BindingSource
    Friend WithEvents TableAdapterManager As OperBD.dsUprTableAdapters.TableAdapterManager
    Friend WithEvents Tip As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IndeksPSb As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents IndeksPSe As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridTrass As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents NameUch As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UIdUch As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataMod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents DsWibUch As OperBD.dsUpr

End Class
