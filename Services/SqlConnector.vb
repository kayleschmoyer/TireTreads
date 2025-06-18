Imports System.Configuration
Imports System.Data.SqlClient

Public Class SqlConnector
    Public Shared Function BuildConnectionString(server As String, database As String) As String
        Dim username = ConfigurationManager.AppSettings("SqlUsername")
        Dim password = ConfigurationManager.AppSettings("SqlPassword")
        Return $"Server={server};Database={database};User Id={username};Password={password};"
    End Function

    Public Shared Function TestConnection(connStr As String, Optional notifier As StatusNotifier = Nothing, Optional logger As StatusLogger = Nothing) As Boolean
        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()
            End Using

            notifier?.Info("✅ Connected to SQL Server.")
            logger?.Log("Test connection successful.")
            Return True

        Catch ex As Exception
            notifier?.ErrorMessage("❌ Could not connect to SQL Server. Please verify your settings.")
            logger?.Log("Test connection failed: " & ex.Message, True)
            Return False
        End Try
    End Function

    Public Shared Function OpenConnection(connStr As String) As SqlConnection
        Dim conn As New SqlConnection(connStr)
        conn.Open()
        Return conn
    End Function
End Class
