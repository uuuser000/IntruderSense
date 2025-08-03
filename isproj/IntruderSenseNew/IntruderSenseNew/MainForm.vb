Public Class MainForm
    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ClientSize = New Size(1024, 768)
        setusb(False)
        setbt(False)
        Icon = My.Resources.hat_black
        CenterToScreen()
        statuswatcher.Start()
    End Sub


    Dim devicestatus As svcwindow.enum_devicestatus = Nothing
    Dim doorstatus As svcwindow.enum_doorstatus = Nothing
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles statuswatcher.Tick
        If Not devicestatus = svcwindow.devicestatus OrElse Not doorstatus = svcwindow.doorstatus Then
            devicestatus = svcwindow.devicestatus
            doorstatus = svcwindow.doorstatus
            statuschange()
        End If
    End Sub
    Sub setusb(ByVal bool As Boolean)
        If bool Then
            DoubleBufferedPictureBox6.Image = My.Resources.tick
            DoubleBufferedPictureBox7.BackColor = Color.Lime
            DoubleBufferedLabel1.Text = "USB Cihaz Bağlı"
            DoubleBufferedLabel1.ForeColor = Color.Lime
        Else
            DoubleBufferedPictureBox6.Image = My.Resources.x
            DoubleBufferedPictureBox7.BackColor = Color.Red
            DoubleBufferedLabel1.Text = "USB Cihaz Algılanmadı"
            DoubleBufferedLabel1.ForeColor = Color.Red
        End If
    End Sub
    Sub setbt(ByVal bool As Boolean)
        If bool Then
            DoubleBufferedPictureBox9.Image = My.Resources.tick
            DoubleBufferedPictureBox8.BackColor = Color.Lime
            DoubleBufferedLabel2.Text = "Bluetooth Bağlı"
            DoubleBufferedLabel2.ForeColor = Color.Lime
        Else
            DoubleBufferedPictureBox9.Image = My.Resources.x
            DoubleBufferedPictureBox8.BackColor = Color.Red
            DoubleBufferedLabel2.Text = "Bluetooth Bağlantısı Kurulmadı"
            DoubleBufferedLabel2.ForeColor = Color.Red
        End If
    End Sub
    Sub statuschange()
        If devicestatus = svcwindow.enum_devicestatus.Ok Then
            If doorstatus = svcwindow.enum_doorstatus.DoorClosed Then
                ind0.Image = My.Resources.door_closed
                ind1.Text = "Kapı Kapalı"
                ind1.ForeColor = Color.FromArgb(160, 120, 255)
                Icon = My.Resources.hat_green
            Else
                ind0.Image = My.Resources.door_open
                ind1.Text = "Kapı Açık"
                ind1.ForeColor = Color.Red
                Icon = My.Resources.hat_blue
            End If
            ind0.Visible = True
            ind1.Visible = True
            setusb(True)
            setbt(True)
        Else
            ind0.Visible = False
            ind1.Visible = False
            setbt(False)
            If devicestatus = svcwindow.enum_devicestatus.BluetoothNotConnected Then
                setusb(True)
                Icon = My.Resources.hat_red
            Else
                setusb(False)
                Icon = My.Resources.hat_black
            End If
        End If
    End Sub

    Private Sub DoubleBufferedButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DoubleBufferedButton5.Click
        MacroDialog.ShowMacroDialog(Me, True)
    End Sub

    Private Sub DoubleBufferedButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DoubleBufferedButton8.Click
        MacroDialog.ShowMacroDialog(Me, False)
    End Sub

    Private Sub DoubleBufferedButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DoubleBufferedButton6.Click
        Using dlg As New OtherSettings
            dlg.ShowDialog(Me)
        End Using
    End Sub
    Private Sub DoubleBufferedButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DoubleBufferedButton7.Click
        CommonDialog.ShowInfo(Me, "IntruderSense v1.0 - Gömülü Sistemler Dersi Projesi" & vbNewLine & vbNewLine & "Osman Umut SAĞLAM  &&  Tarık Buğra AYAN")
    End Sub
End Class