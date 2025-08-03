<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class splash
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ctr = New System.Windows.Forms.Timer(Me.components)
        Me.fade = New System.Windows.Forms.Timer(Me.components)
        Me.frame = New System.Windows.Forms.Timer(Me.components)
        Me.fadeout = New System.Windows.Forms.Timer(Me.components)
        Me.DoubleBufferedPictureBox2 = New IntruderSenseNew.DoubleBufferedPictureBox()
        Me.DoubleBufferedPictureBox1 = New IntruderSenseNew.DoubleBufferedPictureBox()
        CType(Me.DoubleBufferedPictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DoubleBufferedPictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ctr
        '
        Me.ctr.Interval = 2000
        '
        'fade
        '
        Me.fade.Interval = 10
        '
        'frame
        '
        Me.frame.Interval = 20
        '
        'fadeout
        '
        Me.fadeout.Interval = 10
        '
        'DoubleBufferedPictureBox2
        '
        Me.DoubleBufferedPictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.DoubleBufferedPictureBox2.Location = New System.Drawing.Point(80, 0)
        Me.DoubleBufferedPictureBox2.Name = "DoubleBufferedPictureBox2"
        Me.DoubleBufferedPictureBox2.Size = New System.Drawing.Size(256, 256)
        Me.DoubleBufferedPictureBox2.TabIndex = 1
        Me.DoubleBufferedPictureBox2.TabStop = False
        '
        'DoubleBufferedPictureBox1
        '
        Me.DoubleBufferedPictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.DoubleBufferedPictureBox1.Location = New System.Drawing.Point(290, 324)
        Me.DoubleBufferedPictureBox1.Name = "DoubleBufferedPictureBox1"
        Me.DoubleBufferedPictureBox1.Size = New System.Drawing.Size(640, 200)
        Me.DoubleBufferedPictureBox1.TabIndex = 0
        Me.DoubleBufferedPictureBox1.TabStop = False
        '
        'splash
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1222, 800)
        Me.Controls.Add(Me.DoubleBufferedPictureBox2)
        Me.Controls.Add(Me.DoubleBufferedPictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "splash"
        Me.Opacity = 0.0R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IntruderSense"
        Me.TopMost = True
        CType(Me.DoubleBufferedPictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DoubleBufferedPictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ctr As System.Windows.Forms.Timer
    Friend WithEvents fade As System.Windows.Forms.Timer
    Friend WithEvents frame As System.Windows.Forms.Timer
    Friend WithEvents DoubleBufferedPictureBox1 As DoubleBufferedPictureBox
    Friend WithEvents DoubleBufferedPictureBox2 As DoubleBufferedPictureBox
    Friend WithEvents fadeout As System.Windows.Forms.Timer
End Class
