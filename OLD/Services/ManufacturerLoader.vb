Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class ManufacturerLoader
    Public Shared Sub LoadManufacturerList(clb As CheckedListBox, connStr As String, logger As StatusLogger, notifier As StatusNotifier, mainForm As frmMain)
        Try
            clb.Items.Clear()
            logger.Log("Loading manufacturers...")

            Dim manufacturers As New List(Of String)

            Using conn As New SqlConnection(connStr)
                conn.Open()
                Using cmd As New SqlCommand(SqlQueries.GetManufacturers, conn)
                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim name As String = reader("DESCRIPTION").ToString().Trim()
                            If Not String.IsNullOrWhiteSpace(name) Then
                                manufacturers.Add(name)
                                clb.Items.Add(name, True)
                            End If
                        End While
                    End Using
                End Using
            End Using

            ' Store full list in frmMain for filtering
            mainForm.allManufacturers = manufacturers

            notifier.Info("✅ Manufacturers loaded.")
            logger.Log("Manufacturers loaded.")
        Catch ex As Exception
            logger.Log("Failed to load manufacturers: " & ex.Message, True)
            notifier.ErrorMessage("❌ Failed to load manufacturers.")
        End Try
    End Sub
End Class
