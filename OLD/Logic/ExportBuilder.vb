Imports System.Data.SqlClient
Imports System.IO
Imports System.Linq

Public Class ExportBuilder
    Public Shared Function ExportInventoryData(
        connStr As String,
        selectedCompanyIds As List(Of String),
        exportPath As String,
        filePrefix As String,
        splitByShop As Boolean,
        excludeZeroQty As Boolean,
        includeHeaders As Boolean,
        selectedManufacturers As List(Of String),
        logger As StatusLogger,
        notifier As StatusNotifier
    ) As List(Of String)

        Dim createdFiles As New List(Of String)()

        Try
            If selectedCompanyIds.Count = 0 Then
                logger.Log("No companies were selected for export.")
                Return createdFiles
            End If

            Dim sql = SqlQueries.GetInventoryQuery(selectedCompanyIds, selectedManufacturers)

            Dim dt As New DataTable
            Using conn As New SqlConnection(connStr)
                conn.Open()
                Using da As New SqlDataAdapter(sql, conn)
                    da.Fill(dt)
                End Using
            End Using

            logger.Log($"Data loaded: {dt.Rows.Count} rows.")

            If excludeZeroQty AndAlso dt.Rows.Count > 0 Then
                Dim filteredRows = dt.Select("STOCK > 0")
                If filteredRows.Length = 0 Then
                    logger.Log("No items with quantity > 0 after filtering.")
                    Return createdFiles
                End If
                dt = filteredRows.CopyToDataTable()
                logger.Log($"Rows after zero-qty filter: {dt.Rows.Count}")
            End If

            If dt.Rows.Count = 0 Then
                logger.Log("No data available after filtering. No files will be created.")
                Return createdFiles
            End If

            ' Sort by STORE_ID, then BRAND_NAME
            Dim sortedRows = dt.AsEnumerable().
                OrderBy(Function(r) r("STORE_ID").ToString()).
                ThenBy(Function(r) r("BRAND_NAME").ToString()).
                ToList()

            If splitByShop Then
                Dim shopGroups = sortedRows.GroupBy(Function(r) r("STORE_ID").ToString())
                For Each shopGroup In shopGroups
                    Dim filePath = Path.Combine(exportPath, $"{filePrefix}_19-{shopGroup.Key}.csv")
                    WriteCsv(filePath, shopGroup.ToList(), includeHeaders, logger)
                    createdFiles.Add(filePath)
                    logger.Log($"File created: {filePath}")
                Next
            Else
                Dim filePath = Path.Combine(exportPath, $"{filePrefix}_AllShops.csv")
                WriteCsv(filePath, sortedRows, includeHeaders, logger)
                createdFiles.Add(filePath)
                logger.Log($"File created: {filePath}")
            End If

        Catch ex As Exception
            logger.Log("Export failed: " & ex.Message, True)
            Throw
        End Try

        Return createdFiles
    End Function

    Private Shared Sub WriteCsv(path As String, rows As List(Of DataRow), includeHeaders As Boolean, logger As StatusLogger)
        Using writer As New StreamWriter(path)
            If includeHeaders Then
                writer.WriteLine("STORE_ID,BRAND_NAME,ITEM_CODE,STOCK,PRICE,FET")
            End If

            For Each row In rows
                Dim line = String.Join(",", {
                    "19-" & row("STORE_ID").ToString(),
                    row("BRAND_NAME").ToString(),
                    row("ITEM_CODE").ToString(),
                    FormatNumber(row("STOCK"), 2),
                    FormatNumber(row("PRICE"), 4),
                    FormatNumber(row("FET"), 4)
                })

                writer.WriteLine(line)
                logger.Log("WRITE: " & line)
            Next
        End Using
    End Sub
End Class