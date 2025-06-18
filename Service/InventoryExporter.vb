Imports Microsoft.Extensions.Configuration
Imports Microsoft.Extensions.Logging
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text

Public Class InventoryExporter
    Private ReadOnly _config As IConfiguration
    Private ReadOnly _logger As ILogger

    Public Sub New(config As IConfiguration, logger As ILogger)
        _config = config
        _logger = logger
    End Sub

    Public Async Function CreateExportAsync(token As CancellationToken) As Task(Of String)
        Dim connStr = _config.GetConnectionString("Sql")
        Dim exportDir = _config("Export:Directory")
        Dim remoteName = _config("Export:RemoteFileName")
        If String.IsNullOrEmpty(remoteName) Then remoteName = "Stock_19.csv"
        Dim excluded = _config.GetSection("Export:ExcludedBrands").Get(Of String())()
        If excluded Is Nothing Then excluded = Array.Empty(Of String)()

        Directory.CreateDirectory(exportDir)

        Dim filePath = Path.Combine(exportDir, remoteName)

        Using conn As New SqlConnection(connStr), _
              cmd As New SqlCommand(SqlQueries.GetInventoryQuery(excluded), conn)
            conn.Open()
            Dim table As New DataTable()
            Using da As New SqlDataAdapter(cmd)
                da.Fill(table)
            End Using

            If table.Rows.Count = 0 Then
                _logger.LogInformation("No data to export")
                Return String.Empty
            End If

            Using writer As New StreamWriter(filePath, False, Encoding.UTF8)
                Await writer.WriteLineAsync("STORE_ID,BRAND_NAME,ITEM_CODE,STOCK,PRICE,FET")
                For Each row As DataRow In table.Rows
                    Dim line = String.Join(","c, New String() {
                        row("STORE_ID").ToString(),
                        row("BRAND_NAME").ToString(),
                        row("ITEM_CODE").ToString(),
                        String.Format("{0:0.##}", row("STOCK")),
                        String.Format("{0:0.####}", row("PRICE")),
                        String.Format("{0:0.####}", row("FET"))
                    })
                    Await writer.WriteLineAsync(line)
                Next
            End Using
        End Using

        _config("Export:GeneratedFile") = filePath
        _config("Export:RemoteFile") = remoteName

        _logger.LogInformation($"Export created: {filePath}")
        Return filePath
    End Function
End Class
