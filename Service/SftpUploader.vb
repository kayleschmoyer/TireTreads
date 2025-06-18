Imports Microsoft.Extensions.Configuration
Imports Microsoft.Extensions.Logging
Imports Renci.SshNet
Imports System.IO

Public Class SftpUploader
    Private ReadOnly _config As IConfiguration
    Private ReadOnly _logger As ILogger

    Public Sub New(config As IConfiguration, logger As ILogger)
        _config = config
        _logger = logger
    End Sub

    Public Async Function UploadAsync(file As String, token As CancellationToken) As Task
        Dim host = _config("Sftp:Host")
        Dim username = _config("Sftp:Username")
        Dim password = _config("Sftp:Password")
        Dim port = _config.GetValue(Of Integer)("Sftp:Port", 22)
        Dim path = If(_config("Sftp:UploadPath"), "/")
        Dim remoteName = If(_config("Export:RemoteFile"), Path.GetFileName(file))

        Using client As New SftpClient(host, port, username, password)
            client.Connect()
            If Not client.IsConnected Then
                Throw New IOException("Could not connect to SFTP server")
            End If

            Using fs = File.OpenRead(file)
                Dim remotePath = Path.Combine(path.TrimEnd("/"c), remoteName).Replace("\", "/")
                client.UploadFile(fs, remotePath)
                client.Disconnect()
                _logger.LogInformation($"Uploaded {remotePath}")
            End Using
        End Using
    End Function
End Class
