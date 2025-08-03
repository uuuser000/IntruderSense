Imports System.Runtime.InteropServices

Public Class DoubleBufferedPictureBox
    Inherits PictureBox
    Public Sub New()
        DoubleBuffered = True
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.SetStyle(ControlStyles.DoubleBuffer, True)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        BackColor = Color.Transparent
    End Sub
End Class
Public Class DoubleBufferedPanel
    Inherits Panel
    Public Sub New()
        DoubleBuffered = True
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.SetStyle(ControlStyles.DoubleBuffer, True)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        BackColor = Color.Transparent
    End Sub
End Class
Public Class DoubleBufferedLabel
    Inherits Label
    Public Sub New()
        DoubleBuffered = True
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.SetStyle(ControlStyles.DoubleBuffer, True)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        BackColor = Color.Transparent
    End Sub
End Class
Public Class DoubleBufferedButton
    Inherits Button
    Private _NormalForeColor As Color = Color.Yellow
    Private _HoverForeColor As Color = Color.FromArgb(40, 40, 80)
    Private _PressForeColor As Color = Color.Yellow
    Public Sub New()
        DoubleBuffered = True
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.SetStyle(ControlStyles.DoubleBuffer, True)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        BackColor = Color.Transparent
        FlatStyle = Windows.Forms.FlatStyle.Flat
        FlatAppearance.BorderColor = Color.FromArgb(200, 255, 255, 0)
        FlatAppearance.MouseOverBackColor = Color.FromArgb(200, 255, 255, 0)
        FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 0, 0, 0)
        ForeColor = Color.Yellow
        Size = New Size(120, 40)
        Cursor = Cursors.Hand
    End Sub
    Private Sub DoubleBufferedButton_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        ForeColor = _PressForeColor
    End Sub
    Private Sub DoubleBufferedButton_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
        ForeColor = _NormalForeColor
    End Sub
    Private Sub DoubleBufferedButton_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove, Me.MouseUp
        If ClientRectangle.Contains(PointToClient(Cursor.Position)) Then
            ForeColor = _HoverForeColor
        End If
    End Sub
    Public Property NormalForeColor As Color
        Get
            Return _NormalForeColor
        End Get
        Set(ByVal value As Color)
            _NormalForeColor = value
        End Set
    End Property
    Public Property HoverForeColor As Color
        Get
            Return _HoverForeColor
        End Get
        Set(ByVal value As Color)
            _HoverForeColor = value
        End Set
    End Property
    Public Property PressForeColor As Color
        Get
            Return _PressForeColor
        End Get
        Set(ByVal value As Color)
            _PressForeColor = value
        End Set
    End Property
End Class
Public Class uaToggle
    Inherits Control
    Private _checked As Boolean = False
    Public Event CheckedChanged()
    Public Sub New()
        DoubleBuffered = True
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.SetStyle(ControlStyles.DoubleBuffer, True)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        BackColor = Color.Transparent
        Cursor = Cursors.Hand
    End Sub
    Private thumbwidth As UInteger
    Private br0 As New SolidBrush(Color.FromArgb(30, 30, 60))
    Private br1 As New SolidBrush(Color.FromArgb(80, 80, 160))
    Private br2 As New SolidBrush(Color.FromArgb(150, 255, 255, 0))
    Private br3 As New SolidBrush(Color.FromArgb(200, 255, 255, 0))
    Private br4 As New SolidBrush(Color.FromArgb(100, 100, 200))
    Private p0 As New Pen(Color.FromArgb(120, 120, 240))
    Private p1 As New Pen(Color.Yellow)
    Private ismousehover As Boolean = False
    Private Sub uaToggle_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        e.Graphics.FillRectangle(br0, ClientRectangle)
        If _checked Then
            If ismousehover Then
                e.Graphics.FillRectangle(br3, New Rectangle(Width - thumbwidth, 0, thumbwidth, Height))
            Else
                e.Graphics.FillRectangle(br2, New Rectangle(Width - thumbwidth, 0, thumbwidth, Height))
            End If
            e.Graphics.DrawRectangle(p1, New Rectangle(Width - thumbwidth, 0, thumbwidth - 1, Height - 1))
        Else
            If ismousehover Then
                e.Graphics.FillRectangle(br4, New Rectangle(0, 0, thumbwidth, Height))
            Else
                e.Graphics.FillRectangle(br1, New Rectangle(0, 0, thumbwidth, Height))
            End If
            e.Graphics.DrawRectangle(p0, New Rectangle(0, 0, thumbwidth - 1, Height - 1))
        End If
    End Sub
    Private Sub uaToggle_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        thumbwidth = Width * (3 / 5)
    End Sub
    Public Property Checked As Boolean
        Get
            Return _checked
        End Get
        Set(ByVal value As Boolean)
            _checked = value
            Invalidate()
        End Set
    End Property
    Private Sub uaToggle_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter
        ismousehover = True
        Invalidate()
    End Sub
    Private Sub uaToggle_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Checked = Not _checked
            RaiseEvent CheckedChanged()
        End If
    End Sub
    Private Sub uaToggle_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
        ismousehover = False
        Invalidate()
    End Sub
    ' Public Property 
End Class
Public Class DoubleBufferedRadioButton
    Inherits RadioButton
    Public Sub New()
        DoubleBuffered = True
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.SetStyle(ControlStyles.DoubleBuffer, True)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        BackColor = Color.Transparent
        Appearance = Windows.Forms.Appearance.Button
        FlatStyle = Windows.Forms.FlatStyle.Flat
        FlatAppearance.BorderColor = Color.FromArgb(200, 255, 255, 0)
        FlatAppearance.CheckedBackColor = Color.FromArgb(200, 255, 255, 0)
        ForeColor = Color.Yellow
        MyBase.AutoSize = False
        Size = New Size(120, 40)
        kurwa()
    End Sub
    Function kurwa()
        If Checked Then
            FlatAppearance.MouseOverBackColor = Color.FromArgb(200, 255, 255, 0)
            ForeColor = Color.FromArgb(40, 40, 80)
            FlatAppearance.MouseDownBackColor = Color.FromArgb(200, 255, 255, 0)
        Else
            FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 255, 255, 0)
            ForeColor = Color.Yellow
            FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 0, 0, 0)
        End If
    End Function
    Private Sub DoubleBufferedRadioButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.CheckedChanged
        kurwa()
    End Sub
    Private Sub DoubleBufferedRadioButton_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter, Me.MouseUp
        If Not Checked Then
            ForeColor = Color.FromArgb(40, 40, 80)
        End If
    End Sub
    Private Sub DoubleBufferedRadioButton_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave, Me.MouseDown
        If Not Checked Then
            ForeColor = Color.Yellow
        End If
    End Sub
End Class
Public Class DoubleBufferedListView
    Inherits ListView
    Public Sub New()
        DoubleBuffered = True
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.SetStyle(ControlStyles.DoubleBuffer, True)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        BackColor = Color.Transparent
        OwnerDraw = True
        BorderStyle = Windows.Forms.BorderStyle.None
        BackColor = Color.FromArgb(40, 40, 80)
        FullRowSelect = True
        HeaderStyle = ColumnHeaderStyle.None
        View = Windows.Forms.View.Details
    End Sub
    Protected Overrides Sub WndProc(ByRef m As Message)
        Select Case m.Msg
            Case &H83
                Dim style As Integer = CInt(GetWindowLong(Me.Handle, GWL_STYLE))
                If (style And WS_HSCROLL) = WS_HSCROLL Then SetWindowLong(Me.Handle, GWL_STYLE, style And Not WS_HSCROLL)
                MyBase.WndProc(m)
            Case Else
                MyBase.WndProc(m)
        End Select
    End Sub
    Const GWL_STYLE As Integer = -16
    Const WS_HSCROLL As Integer = &H100000
    Public Shared Function GetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer) As Integer
        If IntPtr.Size = 4 Then
            Return CInt(GetWindowLong32(hWnd, nIndex))
        Else
            Return CInt(CLng(GetWindowLongPtr64(hWnd, nIndex)))
        End If
    End Function
    Public Shared Function SetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As Integer
        If IntPtr.Size = 4 Then
            Return CInt(SetWindowLongPtr32(hWnd, nIndex, dwNewLong))
        Else
            Return CInt(CLng(SetWindowLongPtr64(hWnd, nIndex, dwNewLong)))
        End If
    End Function
    <DllImport("user32.dll", EntryPoint:="GetWindowLong", CharSet:=CharSet.Auto)>
    Public Shared Function GetWindowLong32(ByVal hWnd As IntPtr, ByVal nIndex As Integer) As IntPtr
    End Function
    <DllImport("user32.dll", EntryPoint:="GetWindowLongPtr", CharSet:=CharSet.Auto)>
    Public Shared Function GetWindowLongPtr64(ByVal hWnd As IntPtr, ByVal nIndex As Integer) As IntPtr
    End Function
    <DllImport("user32.dll", EntryPoint:="SetWindowLong", CharSet:=CharSet.Auto)>
    Public Shared Function SetWindowLongPtr32(ByVal hWnd As IntPtr, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As IntPtr
    End Function
    <DllImport("user32.dll", EntryPoint:="SetWindowLongPtr", CharSet:=CharSet.Auto)>
    Public Shared Function SetWindowLongPtr64(ByVal hWnd As IntPtr, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As IntPtr
    End Function
    Private br0 As New SolidBrush(Color.FromArgb(35, 35, 70))
    Private br1 As New SolidBrush(Color.FromArgb(150, 255, 255, 0))
    Private br2 As New SolidBrush(Color.FromArgb(50, 255, 255, 0))
    Private br3 As New SolidBrush(Color.Yellow)
    Private br4 As New SolidBrush(Color.Gainsboro)
    Private p0 As New Pen(Color.Yellow)
    Dim fnt As New Font("microsoft sans serif", 14, FontStyle.Regular, GraphicsUnit.Pixel)
    Private Sub DoubleBufferedListView_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawListViewItemEventArgs) Handles Me.DrawItem
        Dim rect As Rectangle = e.Bounds
        rect.Width += SystemInformation.VerticalScrollBarWidth
        If e.ItemIndex Mod 2 = 0 Then e.Graphics.FillRectangle(br0, rect)
        rect.Width -= (2 * SystemInformation.VerticalScrollBarWidth) + 4
        rect.X += 10
        If SelectedItems.Contains(e.Item) Then
            If mousehoveritem Is e.Item Then
                e.Graphics.FillRectangle(br3, rect)
                rect.Height -= 1
                e.Graphics.DrawRectangle(p0, rect)
            Else
                e.Graphics.FillRectangle(br1, rect)
                rect.Height -= 1
                e.Graphics.DrawRectangle(p0, rect)
            End If
            e.Graphics.DrawString(e.Item.SubItems(0).Text, fnt, br0, e.Bounds.X + 44, e.Bounds.Y + 7)
        Else
            If mousehoveritem Is e.Item Then
                e.Graphics.FillRectangle(br2, rect)
                rect.Height -= 1
                e.Graphics.DrawRectangle(p0, rect)
                e.Graphics.DrawString(e.Item.SubItems(0).Text, fnt, br3, e.Bounds.X + 44, e.Bounds.Y + 7)
            Else
                If e.ItemIndex Mod 2 = 0 Then e.Graphics.FillRectangle(br0, rect)
                e.Graphics.DrawString(e.Item.SubItems(0).Text, fnt, br4, e.Bounds.X + 44, e.Bounds.Y + 7)
            End If
        End If
        If SmallImageList.Images.ContainsKey(e.Item.ImageKey) Then e.Graphics.DrawImage(SmallImageList.Images(e.Item.ImageKey), e.Bounds.X + 16, e.Bounds.Y + 4, 24, 24)
    End Sub
    Dim mousehoveritem As ListViewItem
    Private Sub DoubleBufferedListView_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
        If Not mousehoveritem Is Nothing Then RedrawItems(mousehoveritem.Index, mousehoveritem.Index, True)
        mousehoveritem = Nothing
    End Sub
    Private Sub DoubleBufferedListView_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If Not mousehoveritem Is GetItemAt(e.X, e.Y) Then
            If Not mousehoveritem Is Nothing Then RedrawItems(mousehoveritem.Index, mousehoveritem.Index, True)
            mousehoveritem = GetItemAt(e.X, e.Y)
            If Not mousehoveritem Is Nothing Then RedrawItems(mousehoveritem.Index, mousehoveritem.Index, True)
        End If
    End Sub
    'Sub rfr()
    '    If Not TopItem Is Nothing Then
    '        Dim it As ListViewItem = GetItemAt(0, Height)
    '        If it Is Nothing Then
    '            RedrawItems(TopItem.Index, Items.Count - 1, True)
    '        Else
    '            RedrawItems(TopItem.Index, it.Index, True)
    '        End If
    '    End If
    'End Sub
End Class