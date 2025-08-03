Public Class OtherSettings
    Private Sub OtherSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Icon = My.Resources.hat_blue
        UaToggle1.Checked = My.Settings.start_with_windows
        UaToggle2.Checked = My.Settings.device_notifications
    End Sub
    Private Sub DoubleBufferedButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DoubleBufferedButton1.Click
        My.Settings.start_with_windows = UaToggle1.Checked
        My.Settings.device_notifications = UaToggle2.Checked
        My.Settings.Save()
        Close()
    End Sub
    Private Sub ind1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ind1.Click
        UaToggle1.Checked = Not UaToggle1.Checked
    End Sub
    Private Sub DoubleBufferedLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DoubleBufferedLabel1.Click
        UaToggle2.Checked = Not UaToggle2.Checked
    End Sub
End Class