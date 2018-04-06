
Namespace My
    
    'Этот класс позволяет обрабатывать определенные события в классе параметров:
    ' Событие SettingChanging возникает перед изменением значения параметра.
    ' Событие PropertyChanged возникает после изменения значения параметра.
    ' Событие SettingsLoaded возникает после загрузки значений параметров.
    ' Событие SettingsSaving возникает перед сохранением значений параметров.
    Partial Public NotInheritable Class MySettings
        'ReadOnly Property BasePapkaGlobal As String
        '    Get
        '        Return My.Settings.BasePapkaGlobal
        '    End Get
        'End Property
        'ReadOnly Property BasePapkaLocal As String
        '    Get
        '        Return My.Settings.BasePapkaLocal
        '    End Get
        'End Property
    End Class
    Public Class MojSettings
		Public Shared BasePapkaGlobal As String
		'   Public Const BasePapkaLocal As String = "D:\WL_11-13"
	End Class
End Namespace
