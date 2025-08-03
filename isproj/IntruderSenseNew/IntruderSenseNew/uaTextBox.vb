Public Class uaTextBox
    Private Sub uaTextBox_BackColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.BackColorChanged
        If Not BackColor.A = 255 Then BackColor = Color.FromArgb(255, BackColor)
        textarea.BackColor = BackColor

    End Sub
    Private Sub uaTextBox_GotFocus() Handles Me.GotFocus, Me.MouseDown, DoubleBufferedPictureBox1.MouseDown, DoubleBufferedPictureBox1.GotFocus, DoubleBufferedPictureBox2.MouseDown, DoubleBufferedPictureBox2.GotFocus, DoubleBufferedPictureBox3.MouseDown, DoubleBufferedPictureBox3.GotFocus, DoubleBufferedPictureBox4.MouseDown, DoubleBufferedPictureBox4.GotFocus
        textarea.Select()
    End Sub
    Private Sub uaTextBox_ForeColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ForeColorChanged
        textarea.ForeColor = ForeColor
    End Sub
    Public Property BorderColor As Color
        Get
            Return DoubleBufferedPictureBox1.BackColor
        End Get
        Set(ByVal value As Color)
            DoubleBufferedPictureBox1.BackColor = value
            DoubleBufferedPictureBox2.BackColor = value
            DoubleBufferedPictureBox3.BackColor = value
            DoubleBufferedPictureBox4.BackColor = value
        End Set
    End Property
    Private Sub uaTextBox_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        textarea.Width = Width - 8
        textarea.Height = Height - 2
    End Sub
    Public Sub New()
        InitializeComponent()
        textarea.AutoSize = False
        textarea.Location = New Point(4, 4)
    End Sub
    Public Property Multiline As Boolean
        Get
            Return textarea.Multiline
        End Get
        Set(ByVal value As Boolean)
            textarea.Multiline = value
        End Set
    End Property
End Class
