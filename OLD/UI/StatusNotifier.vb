Imports System.Windows.Forms

Public Class StatusNotifier
    Private ReadOnly statusLabel As ToolStripStatusLabel

    Public Sub New(labelControl As ToolStripStatusLabel)
        statusLabel = labelControl
    End Sub

    Public Sub Info(message As String)
        UpdateStatus("" & message)
    End Sub

    Public Sub Warn(message As String)
        UpdateStatus("" & message)
    End Sub

    Public Sub [ErrorMessage](message As String)
        UpdateStatus("" & message)
    End Sub

    Private Sub UpdateStatus(message As String)
        If statusLabel.GetCurrentParent.InvokeRequired Then
            statusLabel.GetCurrentParent.Invoke(Sub() statusLabel.Text = message)
        Else
            statusLabel.Text = message
        End If
    End Sub
End Class
