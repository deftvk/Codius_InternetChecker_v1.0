Imports System.Text.RegularExpressions
Imports IWshRuntimeLibrary
Imports System.IO
Public Class AppConfig
    Shared autorunRegPath As String = "SOFTWARE\Microsoft\Windows\CurrentVersion\Run"
    Public Shared Function SetAutorun(Autorun As Boolean, Optional IsCurrentUser As Boolean = True) As Boolean
        Dim regkeyAutorun As Microsoft.Win32.RegistryKey = GetRegistryKey(IsCurrentUser)
        Try
            If Autorun Then
                regkeyAutorun.SetValue(Application.ProductName, Application.ExecutablePath)
            Else
                regkeyAutorun.DeleteValue(Application.ProductName)
            End If
            regkeyAutorun.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return False
    End Function
    Public Shared ReadOnly Property GetAutorunState(Optional IsCurrentUser As Boolean = True) As Boolean
        Get
            Dim regkeyAutorun As Microsoft.Win32.RegistryKey = GetRegistryKey(IsCurrentUser)
            Try
                Dim value As Object = regkeyAutorun.GetValue(Application.ProductName)
                If value IsNot Nothing Then
                    If value = Application.ExecutablePath Then
                        Return True
                    Else
                        Dim result As DialogResult = MsgBox("Найден ключ автозапуска для одноименного приложения расположенного в другом месте." + _
                                                          vbNewLine + value.ToString + vbNewLine + "Удалить?", vbYesNo)
                        If result = DialogResult.Yes Then regkeyAutorun.DeleteValue(Application.ProductName)
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Return False
        End Get
    End Property
    Private Shared Function GetRegistryKey(Optional IsCurrentUser As Boolean = True) As Microsoft.Win32.RegistryKey
        Dim regkeyAutorun As Microsoft.Win32.RegistryKey
        If IsCurrentUser Then
            regkeyAutorun = My.Computer.Registry.CurrentUser.OpenSubKey(autorunRegPath, True)
        Else
            ' Если программа запущена не с правами администратора, то здесь выпадет ошибка
            regkeyAutorun = My.Computer.Registry.LocalMachine.OpenSubKey(autorunRegPath, True)
        End If
        Return regkeyAutorun
    End Function

    Public Shared Function SetAutorunAsShortcut(Autorun As Boolean, Optional IsCurrentUser As Boolean = True)
        If Autorun Then
            Return AppConfig.Shortcut.Create(Environment.SpecialFolder.Startup, Application.ExecutablePath)
        Else
            Return AppConfig.Shortcut.Delete(Environment.SpecialFolder.Startup, Application.ExecutablePath)
        End If
    End Function

    Public Class Shortcut
        Public Shared Function Create(folder As Environment.SpecialFolder, filename As String) As Boolean
            Dim fiShellLink As FileInfo = GetShellLinkFileInfo(folder, filename)

            Try
                If Not Exists(folder, filename) Then
                    Dim shell As New WshShell
                    Dim link As IWshShortcut = shell.CreateShortcut(fiShellLink.FullName)
                    link.TargetPath = Application.ExecutablePath
                    link.WorkingDirectory = Application.StartupPath
                    'link.WindowStyle = 1
                    'link.IconLocation = Application.ExecutablePath & ", 0"
                    'link.Arguments = Empty.String
                    link.Save()
                Else
                    Return True
                End If
            Catch ex As Exception
                MsgBox("Проблемы с созданием ярлыка: " + fiShellLink.FullName)
            End Try
            Return False
        End Function
        Public Shared Function Delete(folder As Environment.SpecialFolder, filename As String) As Boolean
            If Exists(folder, filename) Then
                Dim fiShellLink As FileInfo = GetShellLinkFileInfo(folder, filename)
                Try
                    fiShellLink.Delete()
                    Return True
                Catch ex As Exception
                    MsgBox("Проблемы с созданием ярлыка: " + fiShellLink.FullName)
                    Return False
                End Try
            End If
            Return True
        End Function
        Public Shared Function Exists(folder As Environment.SpecialFolder, filename As String) As Boolean
            Dim fiShellLink As FileInfo = GetShellLinkFileInfo(folder, filename)
            Return fiShellLink.Exists
        End Function
        Private Shared Function GetShellLinkFileInfo(folder As Environment.SpecialFolder, filename As String) As FileInfo
            Dim fiApp As FileInfo = New FileInfo(filename)
            Dim slFileName As String = fiApp.Name.Substring(0, fiApp.Name.Length - fiApp.Extension.Length) + ".lnk"
            Dim slPath As String = IO.Path.Combine(Environment.GetFolderPath(folder), slFileName)
            Return New FileInfo(slPath)
        End Function

    End Class
End Class
Public Class AppActions
    Public Shared Sub GoToLink(ByVal link As String)
        ПерейтиПоСсылке(link)
    End Sub
    Public Shared Sub ПерейтиПоСсылке(ByVal link As String)
        Dim links() As String = IIf(link.IndexOf(vbNewLine) > -1, _
                                        link.Split(vbNewLine), _
                                        link.Replace(",", ";").Split(";"))

        For Each lnk As String In links
            lnk = lnk.Trim
            If Not String.IsNullOrEmpty(lnk) Then
                If Not lnk.StartsWith("mailto:") Then
                    If Regex.Matches(lnk, "[\w\d.\-_]+@[\w\d.\-_]+\.\w+").Count > 0 Then
                        lnk = "mailto:" + lnk
                    Else
                        If Not lnk.StartsWith("http") Then
                            lnk = "http://" + lnk
                        End If
                    End If
                End If
                Try
                    System.Diagnostics.Process.Start(lnk)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End If
        Next
    End Sub
End Class

