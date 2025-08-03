<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CommonDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CommonDialog))
        Me.DoubleBufferedButton1 = New DoubleBufferedButton()
        Me.DoubleBufferedPanel2 = New DoubleBufferedPanel()
        Me.DoubleBufferedButton2 = New DoubleBufferedButton()
        Me.DoubleBufferedPictureBox1 = New DoubleBufferedPictureBox()
        Me.DoubleBufferedPictureBox2 = New DoubleBufferedPictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UaTextBox2 = New uaTextBox()
        Me.DoubleBufferedPanel2.SuspendLayout()
        CType(Me.DoubleBufferedPictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DoubleBufferedPictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DoubleBufferedButton1
        '
        Me.DoubleBufferedButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DoubleBufferedButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DoubleBufferedButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DoubleBufferedButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DoubleBufferedButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DoubleBufferedButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow
        Me.DoubleBufferedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DoubleBufferedButton1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.DoubleBufferedButton1.HoverForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.DoubleBufferedButton1.Location = New System.Drawing.Point(271, 14)
        Me.DoubleBufferedButton1.Name = "DoubleBufferedButton1"
        Me.DoubleBufferedButton1.NormalForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.DoubleBufferedButton1.PressForeColor = System.Drawing.Color.Yellow
        Me.DoubleBufferedButton1.Size = New System.Drawing.Size(120, 40)
        Me.DoubleBufferedButton1.TabIndex = 1
        Me.DoubleBufferedButton1.Text = "Evet"
        Me.DoubleBufferedButton1.UseVisualStyleBackColor = False
        '
        'DoubleBufferedPanel2
        '
        Me.DoubleBufferedPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DoubleBufferedPanel2.Controls.Add(Me.DoubleBufferedButton2)
        Me.DoubleBufferedPanel2.Controls.Add(Me.DoubleBufferedButton1)
        Me.DoubleBufferedPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DoubleBufferedPanel2.Location = New System.Drawing.Point(0, 120)
        Me.DoubleBufferedPanel2.Margin = New System.Windows.Forms.Padding(4)
        Me.DoubleBufferedPanel2.Name = "DoubleBufferedPanel2"
        Me.DoubleBufferedPanel2.Size = New System.Drawing.Size(529, 66)
        Me.DoubleBufferedPanel2.TabIndex = 1
        '
        'DoubleBufferedButton2
        '
        Me.DoubleBufferedButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DoubleBufferedButton2.BackColor = System.Drawing.Color.Transparent
        Me.DoubleBufferedButton2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DoubleBufferedButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.DoubleBufferedButton2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DoubleBufferedButton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DoubleBufferedButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DoubleBufferedButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DoubleBufferedButton2.ForeColor = System.Drawing.Color.Yellow
        Me.DoubleBufferedButton2.HoverForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.DoubleBufferedButton2.Location = New System.Drawing.Point(397, 14)
        Me.DoubleBufferedButton2.Name = "DoubleBufferedButton2"
        Me.DoubleBufferedButton2.NormalForeColor = System.Drawing.Color.Yellow
        Me.DoubleBufferedButton2.PressForeColor = System.Drawing.Color.Yellow
        Me.DoubleBufferedButton2.Size = New System.Drawing.Size(120, 40)
        Me.DoubleBufferedButton2.TabIndex = 2
        Me.DoubleBufferedButton2.Text = "Hayır"
        Me.DoubleBufferedButton2.UseVisualStyleBackColor = False
        '
        'DoubleBufferedPictureBox1
        '
        Me.DoubleBufferedPictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.DoubleBufferedPictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DoubleBufferedPictureBox1.Location = New System.Drawing.Point(0, 119)
        Me.DoubleBufferedPictureBox1.Name = "DoubleBufferedPictureBox1"
        Me.DoubleBufferedPictureBox1.Size = New System.Drawing.Size(529, 1)
        Me.DoubleBufferedPictureBox1.TabIndex = 2
        Me.DoubleBufferedPictureBox1.TabStop = False
        '
        'DoubleBufferedPictureBox2
        '
        Me.DoubleBufferedPictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.DoubleBufferedPictureBox2.Location = New System.Drawing.Point(12, 12)
        Me.DoubleBufferedPictureBox2.Name = "DoubleBufferedPictureBox2"
        Me.DoubleBufferedPictureBox2.Size = New System.Drawing.Size(64, 64)
        Me.DoubleBufferedPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.DoubleBufferedPictureBox2.TabIndex = 3
        Me.DoubleBufferedPictureBox2.TabStop = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoEllipsis = True
        Me.Label1.Location = New System.Drawing.Point(82, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(435, 64)
        Me.Label1.TabIndex = 4
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UaTextBox2
        '
        Me.UaTextBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UaTextBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.UaTextBox2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.UaTextBox2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.UaTextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.UaTextBox2.ForeColor = System.Drawing.Color.White
        Me.UaTextBox2.Location = New System.Drawing.Point(83, 52)
        Me.UaTextBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.UaTextBox2.Name = "UaTextBox2"
        Me.UaTextBox2.Size = New System.Drawing.Size(434, 26)
        Me.UaTextBox2.TabIndex = 0
        '
        'CommonDialog
        '
        Me.AcceptButton = Me.DoubleBufferedButton1
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(140, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CancelButton = Me.DoubleBufferedButton2
        Me.ClientSize = New System.Drawing.Size(529, 186)
        Me.Controls.Add(Me.UaTextBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DoubleBufferedPictureBox2)
        Me.Controls.Add(Me.DoubleBufferedPictureBox1)
        Me.Controls.Add(Me.DoubleBufferedPanel2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CommonDialog"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IntruderSense"
        Me.DoubleBufferedPanel2.ResumeLayout(False)
        CType(Me.DoubleBufferedPictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DoubleBufferedPictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DoubleBufferedButton1 As DoubleBufferedButton
    Friend WithEvents DoubleBufferedPanel2 As DoubleBufferedPanel
    Friend WithEvents DoubleBufferedPictureBox1 As DoubleBufferedPictureBox
    Friend WithEvents DoubleBufferedPictureBox2 As DoubleBufferedPictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DoubleBufferedButton2 As DoubleBufferedButton
    Friend WithEvents UaTextBox2 As uaTextBox

End Class
