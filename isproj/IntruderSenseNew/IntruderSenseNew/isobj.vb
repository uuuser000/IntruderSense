Imports System.IO.Ports
Public Class isobj
    Implements IDisposable
    Private WithEvents devhook As devicehook
    Private isconnected As Boolean = False
    Private comportname As String = ""
    Public Event DoorOpen()
    Public Event DoorClosed()
    Public Event Disconnected()
    Public Event NoPair()
    Private testthreadend As Boolean = True
    Private testthreadendrequest As Boolean = False
    Private magickey As String
    Private timeout As UInt16
    Private WithEvents comobj As SerialPort
    Private lastdoorstate As Byte = 255
    Private tmpstrarr() As String
    Private basari As Boolean = False
    Public Sub Dispose() Implements IDisposable.Dispose
        If Not devhook Is Nothing Then devhook.Dispose()
        GC.SuppressFinalize(Me)
    End Sub
    Public Sub Start(ByVal whitelist() As String, ByVal mk As String, ByVal tout As UInt16)
        magickey = mk
        timeout = tout
        devhook = New devicehook
        devhook.Start(whitelist)
    End Sub
    Private Sub devhook_DeviceInsert(ByVal str As String) Handles devhook.DeviceInsert
        If Not isconnected Then
            testthreadendrequest = True
            While True
                If testthreadend Then Exit While
            End While
            testthreadendrequest = False
            Dim thread As New Threading.Thread(AddressOf testport)
            thread.Start(str)
        End If
    End Sub
    Private Sub devhook_DeviceRemove(ByVal str As String) Handles devhook.DeviceRemove
        If isconnected AndAlso str = comportname Then
            disc()
        End If
    End Sub
    Function disc()
        If Not comobj Is Nothing Then comobj.Close()
        isconnected = False
        comportname = ""
        lastdoorstate = 255
        RaiseEvent Disconnected()
    End Function
    Sub testport(ByVal obj As Object)
        If Not isconnected Then
            Dim com1 As SerialPort
            Dim sw As New Stopwatch
            sw.Start()
            Try
                com1 = New SerialPort With {.BaudRate = 9600, .PortName = CType(obj, String), .ReadTimeout = timeout}
                com1.Open()
                While True
                    If testthreadendrequest Then Exit While
                    If com1.ReadLine.StartsWith(magickey) Then
                        If Not isconnected Then
                            comobj = com1
                            comportname = CType(obj, String)
                            isconnected = True
                        End If
                        Exit While
                    End If
                    If sw.ElapsedMilliseconds > timeout Then Exit While
                End While
            Catch ex As Exception
            End Try
        End If
        testthreadend = True
    End Sub
    Private Sub comobj_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles comobj.DataReceived
        Try
            tmpstrarr = comobj.ReadLine.Split("|")
            basari = True
        Catch ex As Exception
            basari = False
            disc()
        End Try
        If basari AndAlso tmpstrarr.Count = 2 AndAlso tmpstrarr(0) = magickey AndAlso IsNumeric(tmpstrarr(1)) Then
            If Not lastdoorstate = tmpstrarr(1) Then
                lastdoorstate = tmpstrarr(1)
                If lastdoorstate = 0 Then
                    RaiseEvent NoPair()
                ElseIf lastdoorstate = 1 Then
                    RaiseEvent DoorClosed()
                ElseIf lastdoorstate = 2 Then
                    RaiseEvent DoorOpen()
                End If
            End If
        End If
    End Sub
End Class