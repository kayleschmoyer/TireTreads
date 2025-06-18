Imports System.IO
Imports Renci.SshNet

Public Class SftpService
    Private ReadOnly host As String
    Private ReadOnly username As String
    Private ReadOnly password As String
    Private ReadOnly port As Integer

    Public Sub New(host As String, username As String, password As String, Optional port As Integer = 22)
        Me.host = host
        Me.username = username
        Me.password = password
        Me.port = port
    End Sub

    Public Sub UploadFile(localPath As String, remotePath As String, notifier As StatusNotifier, logger As StatusLogger)
        Try
            Using client As New SftpClient(host, port, username, password)
                client.Connect()

                If Not client.IsConnected Then
                    Throw New Exception("Could not connect to SFTP server.")
                End If

                Using fs As New FileStream(localPath, FileMode.Open)
                    client.UploadFile(fs, remotePath)
                End Using

                client.Disconnect()
                notifier.Info($"Uploaded: {Path.GetFileName(remotePath)}")
            End Using
        Catch ex As Exception
            logger.Log("SFTP Upload failed: " & ex.Message, True)
            Throw New Exception("SFTP upload failed: " & ex.Message)
        End Try
    End Sub
End Class
