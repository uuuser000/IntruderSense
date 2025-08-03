Public Class Form1
    Private Sub fadein_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fadein.Tick
        If Opacity = 1 Then
            fadein.Stop()
            fadein.Dispose()
        Else
            Opacity += 0.1
        End If
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Left = My.Computer.Screen.WorkingArea.Width - Width - 10
        Top = My.Computer.Screen.WorkingArea.Height
    End Sub
    Private Sub movein_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles movein.Tick
        If Top < My.Computer.Screen.WorkingArea.Height - Height Then
            Top = My.Computer.Screen.WorkingArea.Height - Height - 10
            movein.Stop()
            movein.Dispose()
        Else
            Top -= 10
        End If
    End Sub
    Private Sub timeout_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timeout.Tick
        timeout.Stop()
        fadeout.Start()
        timeout.Dispose()
    End Sub
    Private Sub fadeout_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fadeout.Tick
        If Opacity = 0 Then
            End
        Else
            Opacity -= 0.1
        End If
    End Sub
End Class
