Public Class svcwindow
    Dim SplashShown As Boolean = False
    Public doorstatus As enum_doorstatus = enum_doorstatus.NoData
    Public devicestatus As enum_devicestatus = enum_devicestatus.UsbNotConnected
    WithEvents iso As New isobj
    Public appready As Boolean = False
    Dim safemode As Boolean = False

    Private Sub svcwindow_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        iso.Dispose()
    End Sub

    Private Sub svcwindow_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Hide()
        Icon = My.Resources.hat_blue

        iso.Start({"303a/1001"}, "is38kfy", 30000)


        imlst.Images.Add("a", My.Resources.window_dialog_24)
        imlst.Images.Add("b", My.Resources.sign_forbidden_24)




        NotifyIcon1.Icon = My.Resources.hat_black
        NotifyIcon1.Visible = True

        Dim args() As String = Environment.GetCommandLineArgs
        appready = True
        If Not (args.Count > 1 AndAlso args(1).Trim.ToLowerInvariant = "nogui") Then
            opengui()
        End If



    End Sub
    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        opengui()
    End Sub
    Sub opengui()
        If Not appready Then Exit Sub
        If MainForm.Visible Then
            If Not MainForm.WindowState = FormWindowState.Normal Then MainForm.WindowState = FormWindowState.Normal
            MainForm.Activate()
            If Not MainForm.WindowState = FormWindowState.Normal Then MainForm.WindowState = FormWindowState.Normal
        Else
            If splash.Visible Then Exit Sub
            If SplashShown Then
                MainForm.Show()
                MainForm.Activate()
            Else
                splash.Show()
                SplashShown = True
                splash.Activate()
            End If
        End If
    End Sub
    Enum enum_devicestatus As Byte
        UsbNotConnected = 0
        BluetoothNotConnected = 1
        Ok = 2
    End Enum
    Enum enum_doorstatus As Byte
        NoData = 0
        DoorOpen = 1
        DoorClosed = 2
    End Enum
    Enum enum_power As Byte
        NoAction = 0
        Shutdown = 1
        ShutdownNow = 2
        Reset = 3
        ResetNow = 4
        Bsod = 5
        Lock = 6
    End Enum






    Private Sub iso_Disconnected() Handles iso.Disconnected
        If Not doorstatus = enum_doorstatus.NoData OrElse Not devicestatus = enum_devicestatus.UsbNotConnected Then
            doorstatus = enum_doorstatus.NoData
            devicestatus = enum_devicestatus.UsbNotConnected
            NotifyIcon1.Icon = My.Resources.hat_black
            NotifyIcon1.Text = "USB cihaz algılanmadı."
            MainForm.ind0.Visible = False
            MainForm.ind1.Visible = False
            If My.Settings.device_notifications Then
                If My.Settings.stg_open_notify Then StartProcess(Application.StartupPath & "\notify.exe", "0") 'usb disconnected
                If My.Settings.stg_open_sound Then My.Computer.Audio.Play(My.Resources._0, AudioPlayMode.Background)
            End If
        End If
    End Sub
    Private Sub iso_NoPair() Handles iso.NoPair
        If Not doorstatus = enum_doorstatus.NoData OrElse Not devicestatus = enum_devicestatus.BluetoothNotConnected Then
            If My.Settings.device_notifications Then
                If devicestatus = enum_devicestatus.Ok Then
                    If My.Settings.stg_open_notify Then StartProcess(Application.StartupPath & "\notify.exe", "2") 'bluetooth disconnected
                    If My.Settings.stg_open_sound Then My.Computer.Audio.Play(My.Resources._2, AudioPlayMode.Background)
                Else
                    If My.Settings.stg_open_notify Then StartProcess(Application.StartupPath & "\notify.exe", "1") 'usb insert
                    If My.Settings.stg_open_sound Then My.Computer.Audio.Play(My.Resources._2, AudioPlayMode.Background)
                End If
            End If
            doorstatus = enum_doorstatus.NoData
            devicestatus = enum_devicestatus.BluetoothNotConnected
            NotifyIcon1.Icon = My.Resources.hat_red
            NotifyIcon1.Text = "Bluetooth bağlantısı kurulamadı."
            MainForm.ind0.Visible = False
            MainForm.ind1.Visible = False
        End If
    End Sub

    Private Sub iso_DoorClosed() Handles iso.DoorClosed
        If Not doorstatus = enum_doorstatus.DoorClosed OrElse Not devicestatus = enum_devicestatus.Ok Then
            Dim bool As Boolean = False
            If My.Settings.device_notifications AndAlso Not devicestatus = enum_devicestatus.Ok Then bool = True
            doorstatus = enum_doorstatus.DoorClosed
            devicestatus = enum_devicestatus.Ok
            NotifyIcon1.Icon = My.Resources.hat_green
            NotifyIcon1.Text = "Kapı kapalı."
            Dim thread As New Threading.Thread(AddressOf runMacrosClosed)
            thread.Start(bool)
        End If
    End Sub
    Private Sub iso_DoorOpen() Handles iso.DoorOpen
        If Not doorstatus = enum_doorstatus.DoorOpen OrElse Not devicestatus = enum_devicestatus.Ok Then
            Dim bool As Boolean = False
            If My.Settings.device_notifications AndAlso Not devicestatus = enum_devicestatus.Ok Then bool = True
            doorstatus = enum_doorstatus.DoorOpen
            devicestatus = enum_devicestatus.Ok
            NotifyIcon1.Icon = My.Resources.hat_blue
            NotifyIcon1.Text = "Kapı açık."
            Dim thread As New Threading.Thread(AddressOf runMacrosOpen)
            thread.Start(bool)
        End If
    End Sub
    Private Sub ÇıkışToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ÇıkışToolStripMenuItem.Click
        Close()
    End Sub
    Private Sub ArayüzüAçToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArayüzüAçToolStripMenuItem.Click
        opengui()
    End Sub
    Private Declare Function LockWorkStation Lib "user32.dll" () As Long


    Sub runMacrosOpen(ByVal obj As Object)
        If My.Settings.stg_open_active Then
            If obj Then
                StartProcess(Application.StartupPath & "\notify.exe", "3") 'bluetooth connected
                My.Computer.Audio.Play(My.Resources._1, AudioPlayMode.Background)
            Else
                If My.Settings.stg_open_notify Then StartProcess(Application.StartupPath & "\notify.exe", "5")
                If My.Settings.stg_open_sound Then My.Computer.Audio.Play(My.Resources.a, AudioPlayMode.Background)
            End If
            If My.Settings.stg_open_desktop Then uaVirus.Screen.ShowDesktop()

            If My.Settings.stg_open_message.Length > 0 Then StartProcess(Application.StartupPath & "\msg.exe", Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(My.Settings.stg_open_message)))

            If My.Settings.stg_open_power = svcwindow.enum_power.Bsod Then
                If Not safemode Then uaVirus.Bsod.PerformBsod()
            ElseIf My.Settings.stg_open_power = svcwindow.enum_power.Lock Then
                LockWorkStation()
            ElseIf My.Settings.stg_open_power = svcwindow.enum_power.Shutdown Then
                If Not safemode Then uaVirus.Shutdown.ShutdownComputer()
            ElseIf My.Settings.stg_open_power = svcwindow.enum_power.ShutdownNow Then
                If Not safemode Then uaVirus.Bsod.ShutdownImmediately()
            ElseIf My.Settings.stg_open_power = svcwindow.enum_power.Reset Then
                If Not safemode Then uaVirus.Shutdown.RestartComputer()
            ElseIf My.Settings.stg_open_power = svcwindow.enum_power.ResetNow Then
                If Not safemode Then uaVirus.Bsod.RestartImmediately()
            End If

            For Each x As String In My.Settings.stg_open_process
                xproc(x)
            Next

            For Each x As String In My.Settings.stg_open_kill
                KillProcess(x)
            Next


        End If


    End Sub
    Sub runMacrosClosed(ByVal obj As Object)
        If My.Settings.stg_closed_active Then
            If obj Then
                StartProcess(Application.StartupPath & "\notify.exe", "3") 'bluetooth connected
                My.Computer.Audio.Play(My.Resources._1, AudioPlayMode.Background)
            Else
                If My.Settings.stg_closed_notify Then StartProcess(Application.StartupPath & "\notify.exe", "4")
                If My.Settings.stg_closed_sound Then My.Computer.Audio.Play(My.Resources.b, AudioPlayMode.Background)
            End If

            If My.Settings.stg_closed_desktop Then uaVirus.Screen.ShowDesktop()

            If My.Settings.stg_closed_message.Length > 0 Then StartProcess(Application.StartupPath & "\msg.exe", Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(My.Settings.stg_closed_message)))

            If My.Settings.stg_closed_power = svcwindow.enum_power.Bsod Then
                If Not safemode Then uaVirus.Bsod.PerformBsod()
            ElseIf My.Settings.stg_closed_power = svcwindow.enum_power.Lock Then
                LockWorkStation()
            ElseIf My.Settings.stg_closed_power = svcwindow.enum_power.Shutdown Then
                If Not safemode Then uaVirus.Shutdown.ShutdownComputer()
            ElseIf My.Settings.stg_closed_power = svcwindow.enum_power.ShutdownNow Then
                If Not safemode Then uaVirus.Bsod.ShutdownImmediately()
            ElseIf My.Settings.stg_closed_power = svcwindow.enum_power.Reset Then
                If Not safemode Then uaVirus.Shutdown.RestartComputer()
            ElseIf My.Settings.stg_closed_power = svcwindow.enum_power.ResetNow Then
                If Not safemode Then uaVirus.Bsod.RestartImmediately()
            End If

            For Each x As String In My.Settings.stg_closed_process
                xproc(x)
            Next

            For Each x As String In My.Settings.stg_closed_kill
                KillProcess(x)
            Next


        End If

    End Sub







    Public Shared Function xproc(ByVal str As String)
        Dim ishidden As Boolean = False
        If str.StartsWith("!") Then
            ishidden = True
            str = str.Remove(0, 1)
        End If
        Dim path As String = str.Split("|")(0)
        Dim arg As String = str.Split("|")(1)
        If ishidden Then
            StartProcess(path, arg, True)
        Else
            StartProcess(path, arg, False)
        End If
    End Function



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