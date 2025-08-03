Public Class MacroDialog
    Public editingstg As Boolean
    Private Sub MacroDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Icon = My.Resources.hat_blue
        DoubleBufferedListView1.SmallImageList = svcwindow.imlst
        DoubleBufferedListView2.SmallImageList = svcwindow.imlst
      lwsetsize
    End Sub
    Public Shared Sub ShowMacroDialog(ByVal prt As Form, ByVal which As Boolean)
        Using dlg As New MacroDialog
            dlg.editingstg = which
            Dim str As String
            Dim str2 As String
            If which Then
                dlg.loadsettingsopen()
            Else
                dlg.loadsettingsclosed()
            End If
            dlg.msgactivelabelset()
            dlg.ShowDialog(prt)
        End Using
    End Sub
    Sub lwsetsize()
        If Not WindowState = FormWindowState.Minimized Then
            If DoubleBufferedListView1.Columns.Count > 0 Then DoubleBufferedListView1.Columns(0).Width = DoubleBufferedListView1.Width - SystemInformation.VerticalScrollBarWidth
            If DoubleBufferedListView2.Columns.Count > 0 Then DoubleBufferedListView2.Columns(0).Width = DoubleBufferedListView2.Width - SystemInformation.VerticalScrollBarWidth
        End If
    End Sub
    Sub loadsettingsclosed()
        Dim str As String
        Dim str2 As String
        Text = "Kapı Kapanınca Olacakları Ayarla"
        UaToggle1.Checked = My.Settings.stg_closed_notify
        UaToggle2.Checked = My.Settings.stg_closed_sound
        UaToggle3.Checked = My.Settings.stg_closed_desktop
        UaToggle5.Checked = My.Settings.stg_closed_active
        If My.Settings.stg_closed_message.Length > 0 Then
            UaToggle4.Checked = True
            UaTextBox1.textarea.Text = My.Settings.stg_closed_message
        End If
        If My.Settings.stg_closed_power = svcwindow.enum_power.Lock Then
            DoubleBufferedRadioButton2.Checked = True
        ElseIf My.Settings.stg_closed_power = svcwindow.enum_power.Reset Then
            DoubleBufferedRadioButton4.Checked = True
        ElseIf My.Settings.stg_closed_power = svcwindow.enum_power.ResetNow Then
            DoubleBufferedRadioButton6.Checked = True
        ElseIf My.Settings.stg_closed_power = svcwindow.enum_power.Shutdown Then
            DoubleBufferedRadioButton3.Checked = True
        ElseIf My.Settings.stg_closed_power = svcwindow.enum_power.ShutdownNow Then
            DoubleBufferedRadioButton5.Checked = True
        ElseIf My.Settings.stg_closed_power = svcwindow.enum_power.Bsod Then
            DoubleBufferedRadioButton7.Checked = True
        End If
        For Each x As String In My.Settings.stg_closed_process
            str = x
            If str.StartsWith("!") Then
                str = str.Remove(0, 1)
                str2 = "!"
            Else
                str2 = ""
            End If
            DoubleBufferedListView1.Items.Add(New ListViewItem({str, str2}, "a"))
        Next
        For Each x As String In My.Settings.stg_closed_kill
            DoubleBufferedListView2.Items.Add(New ListViewItem({x}, "b"))
        Next
    End Sub
    Sub loadsettingsopen()
        Dim str As String
        Dim str2 As String
        Text = "Kapı Açılınca Olacakları Ayarla"
        UaToggle1.Checked = My.Settings.stg_open_notify
        UaToggle2.Checked = My.Settings.stg_open_sound
        UaToggle3.Checked = My.Settings.stg_open_desktop
        UaToggle5.Checked = My.Settings.stg_open_active
        If My.Settings.stg_open_message.Length > 0 Then
            UaToggle4.Checked = True
            UaTextBox1.textarea.Text = My.Settings.stg_open_message
        End If
        If My.Settings.stg_open_power = svcwindow.enum_power.Lock Then
            DoubleBufferedRadioButton2.Checked = True
        ElseIf My.Settings.stg_open_power = svcwindow.enum_power.Reset Then
            DoubleBufferedRadioButton4.Checked = True
        ElseIf My.Settings.stg_open_power = svcwindow.enum_power.ResetNow Then
            DoubleBufferedRadioButton6.Checked = True
        ElseIf My.Settings.stg_open_power = svcwindow.enum_power.Shutdown Then
            DoubleBufferedRadioButton3.Checked = True
        ElseIf My.Settings.stg_open_power = svcwindow.enum_power.ShutdownNow Then
            DoubleBufferedRadioButton5.Checked = True
        ElseIf My.Settings.stg_open_power = svcwindow.enum_power.Bsod Then
            DoubleBufferedRadioButton7.Checked = True
        End If
        For Each x As String In My.Settings.stg_open_process
            Str = x
            If Str.StartsWith("!") Then
                Str = Str.Remove(0, 1)
                str2 = "!"
            Else
                str2 = ""
            End If
            DoubleBufferedListView1.Items.Add(New ListViewItem({str, str2}, "a"))
        Next
        For Each x As String In My.Settings.stg_open_kill
            DoubleBufferedListView2.Items.Add(New ListViewItem({x}, "b"))
        Next
    End Sub
    Sub savesettingsopen()
        Dim str As String
        My.Settings.stg_open_active = UaToggle5.Checked
        My.Settings.stg_open_notify = UaToggle1.Checked
        My.Settings.stg_open_sound = UaToggle2.Checked
        My.Settings.stg_open_desktop = UaToggle3.Checked
        If UaToggle4.Checked AndAlso UaTextBox1.textarea.TextLength > 0 Then
            My.Settings.stg_open_message = UaTextBox1.textarea.Text
        Else
            My.Settings.stg_open_message = ""
        End If
        If DoubleBufferedRadioButton2.Checked Then
            My.Settings.stg_open_power = svcwindow.enum_power.Lock
        ElseIf DoubleBufferedRadioButton3.Checked Then
            My.Settings.stg_open_power = svcwindow.enum_power.Shutdown
        ElseIf DoubleBufferedRadioButton4.Checked Then
            My.Settings.stg_open_power = svcwindow.enum_power.Reset
        ElseIf DoubleBufferedRadioButton5.Checked Then
            My.Settings.stg_open_power = svcwindow.enum_power.ShutdownNow
        ElseIf DoubleBufferedRadioButton6.Checked Then
            My.Settings.stg_open_power = svcwindow.enum_power.ResetNow
        ElseIf DoubleBufferedRadioButton7.Checked Then
            My.Settings.stg_open_power = svcwindow.enum_power.Bsod
        Else
            My.Settings.stg_open_power = svcwindow.enum_power.NoAction
        End If
        My.Settings.stg_open_process.Clear()
        For Each x As ListViewItem In DoubleBufferedListView1.Items
            str = x.SubItems(0).Text
            If x.SubItems(1).Text = "!" Then str = "!" & str
            My.Settings.stg_open_process.Add(str)
        Next
        My.Settings.stg_open_kill.Clear()
        For Each x As ListViewItem In DoubleBufferedListView2.Items
            str = x.SubItems(0).Text
            My.Settings.stg_open_kill.Add(str)
        Next
    End Sub
    Sub savesettingsclosed()
        Dim str As String
        My.Settings.stg_closed_active = UaToggle5.Checked
        My.Settings.stg_closed_notify = UaToggle1.Checked
        My.Settings.stg_closed_sound = UaToggle2.Checked
        My.Settings.stg_closed_desktop = UaToggle3.Checked
        If UaToggle4.Checked AndAlso UaTextBox1.textarea.TextLength > 0 Then
            My.Settings.stg_closed_message = UaTextBox1.textarea.Text
        Else
            My.Settings.stg_closed_message = ""
        End If
        If DoubleBufferedRadioButton2.Checked Then
            My.Settings.stg_closed_power = svcwindow.enum_power.Lock
        ElseIf DoubleBufferedRadioButton3.Checked Then
            My.Settings.stg_closed_power = svcwindow.enum_power.Shutdown
        ElseIf DoubleBufferedRadioButton4.Checked Then
            My.Settings.stg_closed_power = svcwindow.enum_power.Reset
        ElseIf DoubleBufferedRadioButton5.Checked Then
            My.Settings.stg_closed_power = svcwindow.enum_power.ShutdownNow
        ElseIf DoubleBufferedRadioButton6.Checked Then
            My.Settings.stg_closed_power = svcwindow.enum_power.ResetNow
        ElseIf DoubleBufferedRadioButton7.Checked Then
            My.Settings.stg_closed_power = svcwindow.enum_power.Bsod
        Else
            My.Settings.stg_closed_power = svcwindow.enum_power.NoAction
        End If
        My.Settings.stg_closed_process.Clear()
        For Each x As ListViewItem In DoubleBufferedListView1.Items
            str = x.SubItems(0).Text
            If x.SubItems(1).Text = "!" Then str = "!" & str
            My.Settings.stg_closed_process.Add(str)
        Next
        My.Settings.stg_closed_kill.Clear()
        For Each x As ListViewItem In DoubleBufferedListView2.Items
            str = x.SubItems(0).Text
            My.Settings.stg_closed_kill.Add(str)
        Next
    End Sub
    Private Sub ind1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ind1.Click
        UaToggle1.Checked = Not UaToggle1.Checked
    End Sub

    Private Sub DoubleBufferedLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DoubleBufferedLabel1.Click
        UaToggle2.Checked = Not UaToggle2.Checked
    End Sub

    Private Sub DoubleBufferedLabel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DoubleBufferedLabel2.Click
        UaToggle3.Checked = Not UaToggle3.Checked
    End Sub

    Private Sub DoubleBufferedLabel3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DoubleBufferedLabel3.Click
        UaToggle4.Checked = Not UaToggle4.Checked
        msgactivelabelset()
    End Sub

    Private Sub DoubleBufferedButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DoubleBufferedButton2.Click
        Close()
    End Sub

    Private Sub DoubleBufferedButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DoubleBufferedButton1.Click
        If editingstg Then
            savesettingsopen()
        Else
            savesettingsclosed()
        End If
        My.Settings.Save()
        Close()
    End Sub




    Private Sub DoubleBufferedButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DoubleBufferedButton4.Click, ToolStripMenuItem1.Click
        Dim str As String = CommonDialog.ShowInput(Me, "Kapatılacak process'in adını girin : ", "")
        str = str.ToLowerInvariant.Trim
        If str.EndsWith(".exe") Then str = str.Substring(0, str.Length - 4)
        If str.Length > 0 Then
            DoubleBufferedListView2.Items.Add(New ListViewItem({str}, "b"))
        End If
    End Sub
    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        DoubleBufferedListView2.Items.RemoveAt(DoubleBufferedListView2.SelectedItems(0).Index)
    End Sub
    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        If CommonDialog.ShowYesNo(Me, "Listeyi Temizle?") Then DoubleBufferedListView2.Clear()
    End Sub
    Private Sub ContextMenuStrip2_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip2.Opening
        ToolStripMenuItem2.Visible = DoubleBufferedListView2.SelectedItems.Count > 0
        ToolStripMenuItem3.Visible = DoubleBufferedListView2.Items.Count > 0
    End Sub


    Private Sub DoubleBufferedButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DoubleBufferedButton3.Click, EkleToolStripMenuItem.Click
        Using dlg As New RunProcessDialog
            dlg.ShowDialog(Me)
            If dlg.OkPressed Then
                Dim str2 As String = ""
                If dlg.DoubleBufferedRadioButton4.Checked Then str2 = "!"
                DoubleBufferedListView1.Items.Add(New ListViewItem({dlg.UaTextBox1.textarea.Text & "|" & dlg.UaTextBox2.textarea.Text, str2}, "a"))
            End If
        End Using
    End Sub
    Private Sub SilToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SilToolStripMenuItem.Click
        DoubleBufferedListView1.Items.RemoveAt(DoubleBufferedListView1.SelectedItems(0).Index)
    End Sub
    Private Sub TemizleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TemizleToolStripMenuItem.Click
        If CommonDialog.ShowYesNo(Me, "Listeyi Temizle?") Then DoubleBufferedListView1.Clear()
    End Sub
    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        SilToolStripMenuItem.Visible = DoubleBufferedListView1.SelectedItems.Count > 0
        TemizleToolStripMenuItem.Visible = DoubleBufferedListView1.Items.Count > 0
    End Sub
    Private Sub UaTextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles UaTextBox1.GotFocus
        AcceptButton = Nothing
    End Sub
    Private Sub UaTextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles UaTextBox1.LostFocus
        AcceptButton = DoubleBufferedButton1
    End Sub
    Private Sub MacroDialog_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        lwsetsize()
    End Sub
    Private Sub DoubleBufferedLabel9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DoubleBufferedLabel9.Click
        UaToggle5.Checked = Not UaToggle5.Checked
    End Sub
    Private Sub UaToggle4_CheckedChanged() Handles UaToggle4.CheckedChanged
        msgactivelabelset()
    End Sub
    Sub msgactivelabelset()
        If UaToggle4.Checked Then
            DoubleBufferedLabel3.Text = "Aktif"
        Else
            DoubleBufferedLabel3.Text = "Pasif"
        End If
    End Sub
End Class