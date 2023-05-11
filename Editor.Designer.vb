<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Editor
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
        Me.tbHost = New System.Windows.Forms.TextBox()
        Me.tbPort = New System.Windows.Forms.TextBox()
        Me.bConnect = New System.Windows.Forms.Button()
        Me.tbFreq = New System.Windows.Forms.TextBox()
        Me.tbSamples = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbGain = New System.Windows.Forms.TextBox()
        Me.QPlot = New Spectrumizer.Canvas()
        Me.IPlot = New Spectrumizer.Canvas()
        Me.SuspendLayout()
        '
        'tbHost
        '
        Me.tbHost.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbHost.Location = New System.Drawing.Point(12, 28)
        Me.tbHost.Name = "tbHost"
        Me.tbHost.Size = New System.Drawing.Size(245, 20)
        Me.tbHost.TabIndex = 0
        Me.tbHost.Text = "192.168.2.3"
        '
        'tbPort
        '
        Me.tbPort.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPort.Location = New System.Drawing.Point(263, 28)
        Me.tbPort.Name = "tbPort"
        Me.tbPort.Size = New System.Drawing.Size(81, 20)
        Me.tbPort.TabIndex = 1
        Me.tbPort.Text = "10080"
        '
        'bConnect
        '
        Me.bConnect.Location = New System.Drawing.Point(789, 12)
        Me.bConnect.Name = "bConnect"
        Me.bConnect.Size = New System.Drawing.Size(91, 75)
        Me.bConnect.TabIndex = 2
        Me.bConnect.Text = "Capture"
        Me.bConnect.UseVisualStyleBackColor = True
        '
        'tbFreq
        '
        Me.tbFreq.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbFreq.Location = New System.Drawing.Point(12, 67)
        Me.tbFreq.Name = "tbFreq"
        Me.tbFreq.Size = New System.Drawing.Size(160, 20)
        Me.tbFreq.TabIndex = 3
        Me.tbFreq.Text = "100.000.000"
        '
        'tbSamples
        '
        Me.tbSamples.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSamples.Location = New System.Drawing.Point(178, 67)
        Me.tbSamples.Name = "tbSamples"
        Me.tbSamples.Size = New System.Drawing.Size(102, 20)
        Me.tbSamples.TabIndex = 4
        Me.tbSamples.Text = "250.000"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Server"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(260, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Port"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Frequency (Hz)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(175, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Samplerate (Hz)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(283, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Gain"
        '
        'tbGain
        '
        Me.tbGain.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbGain.Location = New System.Drawing.Point(286, 67)
        Me.tbGain.Name = "tbGain"
        Me.tbGain.Size = New System.Drawing.Size(58, 20)
        Me.tbGain.TabIndex = 10
        Me.tbGain.Text = "20.0"
        '
        'QPlot
        '
        Me.QPlot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.QPlot.Location = New System.Drawing.Point(12, 364)
        Me.QPlot.Name = "QPlot"
        Me.QPlot.Size = New System.Drawing.Size(868, 265)
        Me.QPlot.TabIndex = 12
        '
        'IPlot
        '
        Me.IPlot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.IPlot.Location = New System.Drawing.Point(12, 93)
        Me.IPlot.Name = "IPlot"
        Me.IPlot.Size = New System.Drawing.Size(868, 265)
        Me.IPlot.TabIndex = 11
        '
        'Editor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(892, 642)
        Me.Controls.Add(Me.QPlot)
        Me.Controls.Add(Me.IPlot)
        Me.Controls.Add(Me.tbGain)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbSamples)
        Me.Controls.Add(Me.tbFreq)
        Me.Controls.Add(Me.bConnect)
        Me.Controls.Add(Me.tbPort)
        Me.Controls.Add(Me.tbHost)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Editor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Spectrumizer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tbHost As TextBox
    Friend WithEvents tbPort As TextBox
    Friend WithEvents bConnect As Button
    Friend WithEvents tbFreq As TextBox
    Friend WithEvents tbSamples As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents tbGain As TextBox
    Friend WithEvents IPlot As Canvas
    Friend WithEvents QPlot As Canvas
End Class
