Public Class OptionsHelper
    Public Shared Function GetExportPrefix(txtFileName As TextBox) As String
        Dim prefix As String = ""
        If txtFileName.InvokeRequired Then
            txtFileName.Invoke(New MethodInvoker(Sub()
                                                     prefix = txtFileName.Text.Trim()
                                                 End Sub))
        Else
            prefix = txtFileName.Text.Trim()
        End If

        If String.IsNullOrWhiteSpace(prefix) Then
            prefix = "TireTreads"
        End If

        Return prefix
    End Function

    Public Shared Function ValidateExportDirectory(directoryPath As String, logger As StatusLogger, notifier As StatusNotifier) As Boolean
        logger.Log("Validating export directory path...")

        If String.IsNullOrWhiteSpace(directoryPath) Then
            notifier.Warn("Please select an export directory.")
            logger.Log("Export directory not specified.", True)
            Return False
        End If

        If Not IO.Directory.Exists(directoryPath) Then
            notifier.ErrorMessage("The selected export folder does not exist.")
            logger.Log("Directory does not exist: " & directoryPath, True)
            Return False
        End If

        logger.Log("Directory is valid: " & directoryPath)
        notifier.Info("Export directory is valid.")
        Return True
    End Function
End Class
