Public Class RunProcessDialog
    Public OkPressed As Boolean = False
    Private Sub CommonDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DoubleBufferedButton2.DialogResult = Windows.Forms.DialogResult.None
        DoubleBufferedButton1.DialogResult = Windows.Forms.DialogResult.None
    End Sub
    Private Sub DoubleBufferedButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DoubleBufferedButton1.Click
        OkPressed = True
        Close()
    End Sub
    Private Sub DoubleBufferedButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DoubleBufferedButton2.Click
        Close()
    End Sub
    Private Sub DoubleBufferedButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DoubleBufferedButton3.Click
        Using dlg As New OpenFileDialog
            dlg.Title = "Aç"
            dlg.Filter = "Tüm Dosyalar|*.*"
            If dlg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                UaTextBox1.textarea.Text = dlg.FileName
            End If
        End Using
    End Sub
End Class