Imports Microsoft.Extensions.Hosting
Imports Microsoft.Extensions.Logging
Imports Microsoft.Extensions.Configuration

Public Class Worker
    Inherits BackgroundService

    Private ReadOnly _logger As ILogger(Of Worker)
    Private ReadOnly _config As IConfiguration
    Private ReadOnly _exporter As InventoryExporter
    Private ReadOnly _uploader As SftpUploader
    Private _intervalMinutes As Integer

    Public Sub New(logger As ILogger(Of Worker), config As IConfiguration)
        _logger = logger
        _config = config
        _exporter = New InventoryExporter(config, logger)
        _uploader = New SftpUploader(config, logger)
        _intervalMinutes = config.GetValue(Of Integer)("Worker:IntervalMinutes")
        If _intervalMinutes <= 0 Then _intervalMinutes = 1440
    End Sub

    Protected Overrides Async Function ExecuteAsync(stoppingToken As CancellationToken) As Task
        While Not stoppingToken.IsCancellationRequested
            Try
                Dim file As String = Await _exporter.CreateExportAsync(stoppingToken)
                If Not String.IsNullOrEmpty(file) Then
                    Await _uploader.UploadAsync(file, stoppingToken)
                End If
            Catch ex As Exception
                _logger.LogError(ex, "Processing failed")
            End Try

            Await Task.Delay(TimeSpan.FromMinutes(_intervalMinutes), stoppingToken)
        End While
    End Function
End Class
