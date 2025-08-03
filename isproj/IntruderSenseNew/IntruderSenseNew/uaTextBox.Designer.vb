<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uaTextBox
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.textarea = New System.Windows.Forms.TextBox()
        Me.DoubleBufferedPictureBox1 = New DoubleBufferedPictureBox()
        Me.DoubleBufferedPictureBox2 = New DoubleBufferedPictureBox()
        Me.DoubleBufferedPictureBox3 = New DoubleBufferedPictureBox()
        Me.DoubleBufferedPictureBox4 = New DoubleBufferedPictureBox()
        CType(Me.DoubleBufferedPictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DoubleBufferedPictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DoubleBufferedPictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DoubleBufferedPictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'textarea
        '
        Me.textarea.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textarea.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.textarea.Location = New System.Drawing.Point(4, 4)
        Me.textarea.Margin = New System.Windows.Forms.Padding(4)
        Me.textarea.Name = "textarea"
        Me.textarea.Size = New System.Drawing.Size(557, 16)
        Me.textarea.TabIndex = 0
        '
        'DoubleBufferedPictureBox1
        '
        Me.DoubleBufferedPictureBox1.BackColor = System.Drawing.Color.Black
        Me.DoubleBufferedPictureBox1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.DoubleBufferedPictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.DoubleBufferedPictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.DoubleBufferedPictureBox1.Name = "DoubleBufferedPictureBox1"
        Me.DoubleBufferedPictureBox1.Size = New System.Drawing.Size(565, 1)
        Me.DoubleBufferedPictureBox1.TabIndex = 1
        Me.DoubleBufferedPictureBox1.TabStop = False
        '
        'DoubleBufferedPictureBox2
        '
        Me.DoubleBufferedPictureBox2.BackColor = System.Drawing.Color.Black
        Me.DoubleBufferedPictureBox2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.DoubleBufferedPictureBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DoubleBufferedPictureBox2.Location = New System.Drawing.Point(0, 23)
        Me.DoubleBufferedPictureBox2.Name = "DoubleBufferedPictureBox2"
        Me.DoubleBufferedPictureBox2.Size = New System.Drawing.Size(565, 1)
        Me.DoubleBufferedPictureBox2.TabIndex = 2
        Me.DoubleBufferedPictureBox2.TabStop = False
        '
        'DoubleBufferedPictureBox3
        '
        Me.DoubleBufferedPictureBox3.BackColor = System.Drawing.Color.Black
        Me.DoubleBufferedPictureBox3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.DoubleBufferedPictureBox3.Dock = System.Windows.Forms.DockStyle.Left
        Me.DoubleBufferedPictureBox3.Location = New System.Drawing.Point(0, 1)
        Me.DoubleBufferedPictureBox3.Name = "DoubleBufferedPictureBox3"
        Me.DoubleBufferedPictureBox3.Size = New System.Drawing.Size(1, 22)
        Me.DoubleBufferedPictureBox3.TabIndex = 3
        Me.DoubleBufferedPictureBox3.TabStop = False
        '
        'DoubleBufferedPictureBox4
        '
        Me.DoubleBufferedPictureBox4.BackColor = System.Drawing.Color.Black
        Me.DoubleBufferedPictureBox4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.DoubleBufferedPictureBox4.Dock = System.Windows.Forms.DockStyle.Right
        Me.DoubleBufferedPictureBox4.Location = New System.Drawing.Point(564, 1)
        Me.DoubleBufferedPictureBox4.Name = "DoubleBufferedPictureBox4"
        Me.DoubleBufferedPictureBox4.Size = New System.Drawing.Size(1, 22)
        Me.DoubleBufferedPictureBox4.TabIndex = 4
        Me.DoubleBufferedPictureBox4.TabStop = False
        '
        'uaTextBox
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.DoubleBufferedPictureBox4)
        Me.Controls.Add(Me.DoubleBufferedPictureBox3)
        Me.Controls.Add(Me.DoubleBufferedPictureBox2)
        Me.Controls.Add(Me.DoubleBufferedPictureBox1)
        Me.Controls.Add(Me.textarea)
        Me.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "uaTextBox"
        Me.Size = New System.Drawing.Size(565, 24)
        CType(Me.DoubleBufferedPictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DoubleBufferedPictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DoubleBufferedPictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DoubleBufferedPictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents textarea As System.Windows.Forms.TextBox
    Friend WithEvents DoubleBufferedPictureBox1 As DoubleBufferedPictureBox
    Friend WithEvents DoubleBufferedPictureBox2 As DoubleBufferedPictureBox
    Friend WithEvents DoubleBufferedPictureBox3 As DoubleBufferedPictureBox
    Friend WithEvents DoubleBufferedPictureBox4 As DoubleBufferedPictureBox

End Class
