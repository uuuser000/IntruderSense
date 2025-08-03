Imports System.Management
Public Class devicehook
    Implements IDisposable
    Public Sub Dispose() Implements IDisposable.Dispose
        m_MediaConnectWatcher.Stop()
        GC.SuppressFinalize(Me)
    End Sub
    Private WithEvents m_MediaConnectWatcher As New ManagementEventWatcher With {.Query = New WqlEventQuery("SELECT * FROM __InstanceOperationEvent WITHIN 1 WHERE TargetInstance ISA 'Win32_PnPEntity'")}
    Public whitelist() As String = {"303a/1001"}
    Public Event DeviceInsert(ByVal str As String)
    Public Event DeviceRemove(ByVal str As String)
    Sub Start(ByVal wl() As String)
        whitelist = wl
        m_MediaConnectWatcher.Start()
        Dim str As String
        For Each controllerObj As ManagementObject In New ManagementObjectSearcher("select * from Win32_PnPEntity").Get
            str = chk(controllerObj)
            If str.Length > 0 Then
                RaiseEvent DeviceInsert(str)
            End If
        Next
    End Sub
    Private Function chk(ByVal obj As ManagementBaseObject) As String
        Dim str As String = obj("DeviceID").ToString.ToLowerInvariant
        Dim devid As String
        If str.StartsWith("usb\vid_") Then
            str = str.Remove(0, 8)
            devid = str.Substring(0, 4)
            str = str.Remove(0, 5)
            If str.StartsWith("pid_") Then
                str = str.Remove(0, 4)
                devid = devid & "/" & str.Substring(0, 4)
                If whitelist.Contains(devid) Then
                    Dim strarr() As String
                    strarr = obj("Caption").ToString.Split(" ")
                    str = strarr(strarr.Count - 1).ToLowerInvariant
                    If str.StartsWith("(com") AndAlso str.EndsWith(")") Then
                        str = str.Replace("(", "").Replace(")", "")
                        Return str
                    End If
                End If
            End If
        End If
        Return ""
    End Function
    Private Sub Arrived(ByVal sender As Object, ByVal e As System.Management.EventArrivedEventArgs) Handles m_MediaConnectWatcher.EventArrived
        Dim str As String
        Select Case e.NewEvent.ClassPath.ClassName
            Case "__InstanceCreationEvent"
                str = chk(e.NewEvent("TargetInstance"))
                If str.Length > 0 Then RaiseEvent DeviceInsert(str)
            Case "__InstanceDeletionEvent"
                str = chk(e.NewEvent("TargetInstance"))
                If str.Length > 0 Then RaiseEvent DeviceRemove(str)
        End Select
    End Sub
End Class