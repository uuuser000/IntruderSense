Public Class splash
    Dim intro As New List(Of UInt16) From {90, 7, 30, 30, 70, 7, 30, 30, 50, 12, 40, 40, 44, 32, 40, 40, 52, 52, 40, 40, 57, 82, 30, 30, 37, 97, 30, 30, 17, 97, 30, 30, 0, 84, 40, 40, 118, 67, 30, 30, 138, 57, 30, 30, 148, 37, 30, 30, 128, 32, 30, 30, 108, 42, 30, 30, 95, 62, 30, 30, 90, 82, 40, 40, 120, 92, 30, 30, 140, 82, 30, 30, 160, 67, 30, 30, 180, 52, 30, 30, 190, 32, 30, 30, 180, 72, 30, 30, 170, 92, 30, 30, 195, 62, 30, 30, 210, 47, 30, 30, 230, 32, 40, 40, 235, 62, 30, 30, 230, 82, 40, 40, 260, 77, 30, 30, 275, 62, 30, 30, 290, 47, 30, 30, 305, 32, 30, 30, 298, 72, 30, 30, 295, 92, 30, 30, 280, 102, 30, 30, 260, 102, 30, 30, 280, 82, 30, 30, 310, 67, 30, 30, 330, 67, 30, 30, 350, 67, 30, 30, 370, 57, 30, 30, 385, 42, 30, 30, 380, 32, 30, 30, 360, 37, 30, 30, 340, 47, 40, 40, 330, 87, 30, 30, 345, 92, 30, 30, 365, 87, 30, 30, 385, 77, 30, 30, 405, 62, 30, 30, 420, 47, 30, 30}
    Const carpan As Byte = 141
    Dim br As New SolidBrush(Color.FromArgb(0, 32, 96))
    Dim introend As Boolean = False
    Private Sub splash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Icon = My.Resources.hat_black
        DoubleBuffered = True
        SetStyle(ControlStyles.ResizeRedraw, True)
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.DoubleBuffer, True)
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.BackColor = Color.Black
        If Not DwmExtendFrameIntoClientArea(Me.Handle, New Padding(-1, 0, 0, 0)) = 0 Then TransparencyKey = BackColor
    End Sub
    <Runtime.InteropServices.DllImport("dwmapi.dll")>
    Public Shared Function DwmExtendFrameIntoClientArea(ByVal hWnd As IntPtr, ByRef pMarinset As Padding) As Integer
    End Function
    Private Sub splash_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        e.Graphics.DrawImage(My.Resources.splash, 0, 80)
    End Sub
    Private Sub splash_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Top -= 40
        frame.Start()
        fade.Start()
        Application.DoEvents()
    End Sub
    Private Sub fade_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fade.Tick
        If Opacity = 1 Then
            fade.Stop()
        Else
            Opacity += 0.05
        End If
    End Sub
    Private Sub frame_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frame.Tick
        If intro.Count = 0 Then
            introend = True
            frame.Stop()
            ctr.Start()
            Invalidate()
        Else
            intro.RemoveRange(0, 4)
            DoubleBufferedPictureBox1.Invalidate()
        End If
    End Sub
    Private Sub ctr_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctr.Tick
        ctr.Stop()
        fadeout.Start()
    End Sub
    Private Sub DoubleBufferedPictureBox1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DoubleBufferedPictureBox1.Paint
        e.Graphics.DrawImage(My.Resources.logo, 0, 0, CInt(454 * (carpan / 100)), CInt(142 * (carpan / 100)))
        e.Graphics.DrawImage(My.Resources.intruder, 168, 0)
        For i = 0 To intro.Count - 1 Step 4
            e.Graphics.FillEllipse(br, New Rectangle(intro(i) * (carpan / 100), intro(i + 1) * (carpan / 100), intro(i + 2) * (carpan / 100), intro(i + 3) * (carpan / 100)))
        Next
    End Sub
    Private Sub fadeout_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fadeout.Tick
        If Opacity = 0 Then
            fade.Stop()
            Hide()
            MainForm.Show()
            MainForm.Activate()
            Dispose()
        Else
            Opacity -= 0.05
        End If
    End Sub
End Class