Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading

Public Class Rtltcp
    Public Const Hertz As Integer = 1000000

    'Gain values    :  0.0 0.9 1.4 2.7 3.7 7.7 8.7 12.5 14.4 15.7 16.6 19.7 20.7 22.9 25.4
    '                  28.0 29.7 32.8 33.8 36.4 37.2 38.6 40.2 42.1 43.4 43.9 44.5 48.0 49.6
    'Sample rates   :  0.25, 1.024, 1.536, 1.792, 1.92, 2.048, 2.16, 2.56, 2.88, 3.2 MSps
    Public Property Host As IPAddress
    Public Property Port As Integer
    Public Property Gain As UInt32
    Public Property Frequency As UInt32
    Public Property Samplerate As UInt32
    Public Property Encoder As Encoding
    Public Property Duration As Integer

    Public Event Finished(success As Boolean)
    Public Event OnRead(length As Integer)
    Public Event OnData(I As Double(), Q As Double())

    Sub New(host As String, port As Integer, duration As Integer)
        Me.Port = port
        Me.Host = Rtltcp.ToAddress(host)
        Me.Encoder = Encoding.ASCII
        Me.Duration = duration
    End Sub

    Public Sub Run(frequency As UInt32, samplerate As UInt32, gain As UInt32)
        Dim result As Boolean = False
        Me.Frequency = frequency
        Me.Samplerate = samplerate
        Me.Gain = gain
        Using socket As New TcpClient
            socket.Connect(Host, Port)
            If (socket.Connected) Then
                Using stream As NetworkStream = socket.GetStream
                    SendCommand(stream, &H1, Me.Frequency)
                    SendCommand(stream, &H2, Me.Samplerate)
                    SendCommand(stream, &H3, 1)
                    SendCommand(stream, &H4, Me.Gain)
                    result = True
                    Dim data As List(Of Double()) = Me.Separate(Me.Collect(stream))
                    socket.Close()
                    RaiseEvent OnData(data.First, data.Last)
                End Using
            End If
        End Using
        RaiseEvent Finished(result)
    End Sub

    Private Function Collect(rtltcp As Stream, Optional length As Integer = 4096) As List(Of Double)
        Dim result As New List(Of Double)
        Dim bytes As Integer
        Dim buffer(length - 1) As Byte
        Dim timer As New Stopwatch
        timer.Start()
        Do
            bytes = rtltcp.Read(buffer, 0, length)
            For i As Integer = 0 To bytes - 1 Step 2
                result.Add(BitConverter.ToInt16(buffer, i))
            Next
            RaiseEvent OnRead(bytes)
            If (timer.ElapsedMilliseconds > Me.Duration) Then Exit Do
        Loop While bytes > 0
        Return result
    End Function

    Private Function Separate(data As List(Of Double)) As List(Of Double())
        Dim result As New List(Of Double())
        Dim index As Integer = data.Count \ 2
        Dim I As Double() = New Double(index - 1) {}
        Dim Q As Double() = New Double(index - 1) {}
        For x As Integer = 0 To index - 1
            I(x) = data(x * 2)     ' I sample is at even index
            Q(x) = data(x * 2 + 1) ' Q sample is at odd index
        Next
        result.Add(I)
        result.Add(Q)
        Return result
    End Function

    Private Function SendCommand(stream As Stream, opcode As Byte, value As UInt32) As Boolean
        If (stream.CanWrite) Then
            Dim cmdBytes As Byte() = {opcode, CByte((value >> 24) And &HFF),
                                              CByte((value >> 16) And &HFF),
                                              CByte((value >> 8) And &HFF),
                                              CByte(value And &HFF)}
            stream.Write(cmdBytes, 0, cmdBytes.Length)
            Return True
        End If
        Return False
    End Function

    Public Shared Function ToAddress(host As String) As IPAddress
        Dim ipAddress As IPAddress = Nothing
        If IPAddress.TryParse(host, ipAddress) Then Return ipAddress
        Throw New ArgumentException("invalid address")
    End Function
End Class
