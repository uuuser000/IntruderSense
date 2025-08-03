Public Class Form1
    Private Sub cls() Handles Me.MouseDown, Me.LostFocus, Me.KeyDown, Button1.Click
        End
    End Sub
    Private Sub fadein_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fadein.Tick
        If Opacity > 0.9 Then
            fadein.Stop()
            fadein.Dispose()
        Else
            Opacity += 0.2
        End If
    End Sub
End Class
