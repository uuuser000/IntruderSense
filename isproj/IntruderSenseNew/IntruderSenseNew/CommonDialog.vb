Public Class CommonDialog
    Private YesPressed As Boolean = False
    Function common(ByVal sender As Form, ByVal accentcolor As Color, ByVal backcolor1 As Color, ByVal backcolor2 As Color, ByVal singlebutton As Boolean, ByVal ico As Bitmap, ByVal title As String, ByVal body As String, ByVal txtbox As Boolean) As Boolean
        YesPressed = False
        If singlebutton Then
            DoubleBufferedButton2.Visible = False
            DoubleBufferedButton1.Left = DoubleBufferedButton1.Parent.Width - DoubleBufferedButton1.Width - 10
            DoubleBufferedButton1.Text = "Tamam"
            CancelButton = DoubleBufferedButton1
        Else
            If txtbox Then
                DoubleBufferedButton1.Text = "Tamam"
                DoubleBufferedButton2.Text = "İptal"
            Else
                DoubleBufferedButton1.Text = "Evet"
            End If
            DoubleBufferedButton2.Visible = True
            DoubleBufferedButton2.Left = DoubleBufferedButton1.Parent.Width - DoubleBufferedButton1.Width - 10
            DoubleBufferedButton1.Left = DoubleBufferedButton2.Left - DoubleBufferedButton2.Width - 10
            CancelButton = DoubleBufferedButton2
        End If
        DoubleBufferedPictureBox2.Image = ico
        CenterToScreen()
        Label1.ForeColor = accentcolor
        Text = title
        Label1.Text = body
        BackColor = backcolor1
        DoubleBufferedPictureBox1.BackColor = accentcolor
        DoubleBufferedPanel2.BackColor = backcolor2
        DoubleBufferedButton1.ForeColor = backcolor1
        DoubleBufferedButton1.NormalForeColor = backcolor1
        DoubleBufferedButton1.FlatAppearance.BorderColor = accentcolor
        DoubleBufferedButton1.BackColor = Color.FromArgb(200, accentcolor)
        DoubleBufferedButton1.FlatAppearance.MouseOverBackColor = accentcolor
        DoubleBufferedButton1.PressForeColor = accentcolor
        DoubleBufferedButton2.ForeColor = accentcolor
        DoubleBufferedButton2.NormalForeColor = accentcolor
        DoubleBufferedButton2.PressForeColor = DoubleBufferedButton1.PressForeColor
        DoubleBufferedButton2.HoverForeColor = DoubleBufferedButton1.HoverForeColor
        DoubleBufferedButton2.FlatAppearance.BorderColor = DoubleBufferedButton1.FlatAppearance.BorderColor
        DoubleBufferedButton2.FlatAppearance.MouseOverBackColor = DoubleBufferedButton1.FlatAppearance.MouseOverBackColor
        DoubleBufferedButton2.FlatAppearance.MouseDownBackColor = DoubleBufferedButton1.FlatAppearance.MouseDownBackColor
        If txtbox Then
            UaTextBox2.Visible = True
            Label1.Height = 36
            Label1.TextAlign = ContentAlignment.BottomLeft
        Else
            UaTextBox2.Visible = False
            Label1.Height = 64
            Label1.TextAlign = ContentAlignment.MiddleLeft
        End If
        ShowDialog(sender)
        Return YesPressed
    End Function
    Private Sub CommonDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DoubleBufferedButton2.DialogResult = Windows.Forms.DialogResult.None
        DoubleBufferedButton1.DialogResult = Windows.Forms.DialogResult.None
        ClientSize = New Size(480, 160)
    End Sub
    Private Sub DoubleBufferedButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DoubleBufferedButton1.Click
        YesPressed = True
        Close()
    End Sub
    Private Sub DoubleBufferedButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DoubleBufferedButton2.Click
        Close()
    End Sub



    'Public Function ShowError(ByVal sender As Form, ByVal msg As String) As Boolean
    '    Return common(sender, Color.Red, Color.FromArgb(40, 0, 0), Color.FromArgb(60, 0, 0), True, My.Resources._error, "Hata", msg, False)
    'End Function
    'Public Function ShowSuccess(ByVal sender As Form, ByVal msg As String) As Boolean
    '    Return common(sender, Color.Lime, Color.FromArgb(0, 40, 0), Color.FromArgb(0, 60, 0), True, My.Resources.success, "IntruderSense", msg, False)
    'End Function
    Public Function ShowInfo(ByVal sender As Form, ByVal msg As String) As Boolean
        Return common(sender, Color.Lime, Color.FromArgb(0, 40, 0), Color.FromArgb(0, 60, 0), True, My.Resources.about_64, "IntruderSense Hakkında", msg, False)
    End Function
    Public Function ShowYesNo(ByVal sender As Form, ByVal msg As String) As Boolean
        Return common(sender, Color.Aqua, Color.FromArgb(0, 40, 40), Color.FromArgb(0, 60, 60), False, My.Resources.que, "IntruderSense", msg, False)
    End Function
    Public Function ShowInput(ByVal sender As Form, ByVal msg As String, ByVal placeholder As String) As String
        UaTextBox2.textarea.Text = placeholder
        If common(sender, Color.Yellow, Color.FromArgb(40, 40, 0), Color.FromArgb(60, 60, 0), False, My.Resources.input, "IntruderSense", msg, True) Then
            Return UaTextBox2.textarea.Text
        Else
            Return ""
        End If
    End Function
End Class