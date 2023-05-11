Imports System.Drawing.Drawing2D

Public Class Graph
    Public Property Font As Font
    Sub New()
        Me.Font = New Font("Consolas", 8, FontStyle.Bold)
    End Sub
    Public Function Plot(data As Double(), bounds As Rectangle, label As String) As Bitmap
        Dim bitmap As New Bitmap(bounds.Width, bounds.Height)
        Using g As Graphics = Graphics.FromImage(bitmap)
            g.SmoothingMode = SmoothingMode.AntiAlias
            g.Clear(Color.White)
            Me.DrawData(g, data, bounds)
            Me.DrawAxes(g, bounds, label)
        End Using
        Return bitmap
    End Function

    Private Sub DrawAxes(g As Graphics, bounds As Rectangle, label As String)
        Using pen As New Pen(Color.Black)
            g.DrawLine(pen, bounds.Left, bounds.Bottom \ 2, bounds.Right, bounds.Bottom \ 2)
            g.DrawLine(pen, bounds.Left, bounds.Top, bounds.Left, bounds.Bottom)
            ' Label
            g.FillRectangle(Brushes.White, 10, 10, 200, 12)
            g.DrawString(label, Me.Font, Brushes.Black, 10, 10)
        End Using
    End Sub

    Private Sub DrawData(g As Graphics, data As Double(), bounds As Rectangle)
        Dim scaleX As Double = bounds.Width / (data.Length - 1)
        Dim scaleY As Double = (bounds.Height / 2)
        Dim yOffset As Double = bounds.Height / 2
        Using p As New Pen(Color.Blue, 1)
            For i As Integer = 0 To data.Length - 2
                Dim x1 As Double = bounds.Left + i * scaleX
                Dim y1 As Double = yOffset - data(i) * scaleY
                Dim x2 As Double = bounds.Left + (i + 1) * scaleX
                Dim y2 As Double = yOffset - data(i + 1) * scaleY
                g.DrawLine(p, CSng(x1), CSng(y1), CSng(x2), CSng(y2))
            Next

        End Using
    End Sub
End Class
