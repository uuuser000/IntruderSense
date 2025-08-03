Imports Microsoft.Win32
Public Class Form1
    Dim installationpath As String
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Icon = My.Resources.hat_blue
        installationpath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) & "\IntruderSense\"
        If Not IO.Directory.Exists(installationpath) Then
            Button3.Location = Button2.Location
            Button2.Dispose()
            Button1.Text = "Kur"
        End If
        ClientSize = New Size(640, 480)
        CenterToScreen()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Close()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Enabled = False
        install()
        Enabled = True
        End
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Enabled = False
        uninstall()
        Enabled = True
        MsgBox("Kaldırma tamamlandı.", MsgBoxStyle.Information)
        End
    End Sub


    Sub delfil(ByVal str As String)
        If IO.File.Exists(installationpath & "\" & str & ".exe") Then
            Try
                KillProcess(str)
            Catch ex As Exception
            End Try
            Try
                IO.File.Delete(installationpath & "\" & str & ".exe")
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Function CreateShortCut(ByVal TargetName As String, ByVal ShortCutPath As String, ByVal ShortCutName As String) As Boolean
        Try
            Dim oLink As Object = CreateObject("WScript.Shell").CreateShortcut(ShortCutPath & "\" & ShortCutName & ".lnk")
            oLink.TargetPath = TargetName
            oLink.WindowStyle = 1
            oLink.Save()
        Catch ex As Exception
        End Try
    End Function


    Sub install()
        uninstall()
        If Not IO.Directory.Exists(installationpath) Then IO.Directory.CreateDirectory(installationpath)
        My.Computer.FileSystem.WriteAllBytes(installationpath & "intrudersense.exe", My.Resources.IntruderSenseNew, False)
        My.Computer.FileSystem.WriteAllBytes(installationpath & "msg.exe", My.Resources.msg, False)
        My.Computer.FileSystem.WriteAllBytes(installationpath & "notify.exe", My.Resources.notify, False)
        Dim regKey As Microsoft.Win32.RegistryKey
        regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
        regKey.SetValue("IntruderSense", """" & installationpath & "intrudersense.exe" & """" & " nogui")
        regKey.Close()
        CreateShortCut(installationpath & "intrudersense.exe", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "IntruderSense")
        Process.Start(installationpath & "intrudersense.exe")
    End Sub
    Sub uninstall()
        Dim regKey As Microsoft.Win32.RegistryKey
        regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
        regKey.DeleteValue("IntruderSense", False)
        regKey.Close()
        If IO.Directory.Exists(installationpath) Then
            delfil("intrudersense")
            delfil("msg")
            delfil("notify")
            IO.Directory.Delete(installationpath)
        End If
        Try
            Dim str As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\IntruderSense.lnk"
            If IO.File.Exists(str) Then IO.File.Delete(str)
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Function StartProcess(ByVal path As String, Optional ByVal args As String = "", Optional ByVal hidden As Boolean = False, _
Optional ByVal waitforexit As Boolean = False, Optional ByVal workingdir As String = "")
        On Error Resume Next
        Using p As New Process
            p.StartInfo.FileName = path
            If args.Length > 0 Then p.StartInfo.Arguments = args
            If hidden Then
                p.StartInfo.CreateNoWindow = True
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            End If
            If workingdir.Length > 0 Then p.StartInfo.WorkingDirectory = workingdir
            p.Start()
            If waitforexit Then p.WaitForExit()
        End Using
    End Function
    Public Shared Function KillProcess(ByVal procname As String)
        On Error Resume Next
        Dim str As String = procname
        If str.ToLowerInvariant.EndsWith(".exe") Then str = str.Substring(0, str.Length - 4)
        Dim i As Integer = 0
        For p = 0 To 1
            i = Process.GetProcessesByName(str).Count
            For x = 0 To i - 1
                Process.GetProcessesByName(str)(0).Kill()
            Next
        Next
        For p = 0 To 1
            i = Process.GetProcessesByName(str).Count
            For x = 0 To i - 1
                StartProcess("taskkill", "/f /t /im " & procname, True, True)
            Next
        Next
    End Function


End Class
