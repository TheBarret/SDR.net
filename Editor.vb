Imports System.Threading

Public Class Editor


    'Gain values    :  0.0 0.9 1.4 2.7 3.7 7.7 8.7 12.5 14.4 15.7 16.6 19.7 20.7 22.9 25.4
    '                  28.0 29.7 32.8 33.8 36.4 37.2 38.6 40.2 42.1 43.4 43.9 44.5 48.0 49.6
    'Sample rates   :  0.25, 1.024, 1.536, 1.792, 1.92, 2.048, 2.16, 2.56, 2.88, 3.2 MSps
    '                  SR 250000 Hz / F 100000000 = 100Mhz
    Public WithEvents Device As Rtltcp

    Private Sub Editor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Device = New Rtltcp("192.168.2.3", 10080, 25)
    End Sub

    Private Sub bConnect_Click(sender As Object, e As EventArgs) Handles bConnect.Click
        Me.UpdateUI(False)
        Dim freq As UInt32 = UInteger.Parse(Me.tbFreq.Text.Replace(".", String.Empty))
        Dim samp As UInt32 = UInteger.Parse(Me.tbSamples.Text.Replace(".", String.Empty))
        Dim gain As UInt32 = UInteger.Parse(Me.tbGain.Text.Replace(".", String.Empty))
        Call New Thread(Sub() Me.Device.Run(freq, samp, gain)).Start()
    End Sub

    Private Sub Device_Finished(success As Boolean) Handles Device.Finished
        Me.UpdateTitle(String.Format("Spectrumizer"))
        Me.UpdateUI(True)
    End Sub

    Private Sub Device_OnRead(length As Integer) Handles Device.OnRead
        Me.UpdateTitle(String.Format("Spectrumizer - {0} bytes received...", length))
    End Sub

    Private Sub Device_OnData(I() As Double, Q() As Double) Handles Device.OnData
        Me.UpdateTitle(String.Format("Spectrumizer - Plotting I..."))
        Me.UpdateGraph(I, 0)
        Me.UpdateTitle(String.Format("Spectrumizer - Plotting Q..."))
        Me.UpdateGraph(Q, 1)
    End Sub

    Private Sub UpdateUI(state As Boolean)
        If (Me.InvokeRequired) Then
            Me.Invoke(Sub() Me.UpdateUI(state))
        Else
            Me.bConnect.Enabled = state
            Me.tbFreq.Enabled = state
            Me.tbSamples.Enabled = state
            Me.tbGain.Enabled = state
            Me.tbHost.Enabled = state
            Me.tbPort.Enabled = state
        End If
    End Sub

    Private Sub UpdateTitle(text As String)
        If (Me.InvokeRequired) Then
            Me.Invoke(Sub() Me.UpdateTitle(text))
        Else
            Me.Text = text
        End If
    End Sub

    Private Sub UpdateGraph(values As Double(), index As Integer)
        If (Me.InvokeRequired) Then
            Me.Invoke(Sub() Me.UpdateGraph(values, index))
        Else
            Select Case index
                Case 0 : Me.IPlot.BackgroundImage = New Graph().Plot(values, Me.IPlot.ClientRectangle, String.Format("I Channel {0}MHz {1}Hz ", Me.Device.Frequency / Rtltcp.Hertz, Me.Device.Samplerate / 100))
                Case 1 : Me.QPlot.BackgroundImage = New Graph().Plot(values, Me.IPlot.ClientRectangle, String.Format("Q Channel {0}MHz {1}Hz ", Me.Device.Frequency / Rtltcp.Hertz, Me.Device.Samplerate / 100))
            End Select
        End If
    End Sub


End Class
