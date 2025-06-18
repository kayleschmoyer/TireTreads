Imports System.IO

Public Class StatusLogger
    Private ReadOnly logFilePath As String

    Public Sub New(exportDirectory As String)
        If Not Directory.Exists(exportDirectory) Then
            Directory.CreateDirectory(exportDirectory)
        End If

        Dim dateStamp As String = DateTime.Today.ToString("MM-dd-yyyy")
        Dim logFileName = $"TireTreadsLog_{dateStamp}.txt"
        logFilePath = Path.Combine(exportDirectory, logFileName)
    End Sub

    Public Sub Log(message As String, Optional isError As Boolean = False)
        Dim prefix = If(isError, "ERROR: ", "INFO: ")
        Dim fullMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {prefix}{message}{Environment.NewLine}"

        Try
            File.AppendAllText(logFilePath, fullMessage)
        Catch ex As Exception
        End Try
    End Sub

    Public ReadOnly Property LogPath As String
        Get
            Return logFilePath
        End Get
    End Property
End Class
