Imports System.ComponentModel
Imports System.IO
Imports System.Reflection
Imports System
Imports System.Xml.Serialization

Public Class frmMain
    Friend allManufacturers As New List(Of String)
    Private logger As StatusLogger
    Private notifier As StatusNotifier
    Private connstr As String

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim args = Environment.GetCommandLineArgs()
        Dim Assembly As Assembly = Assembly.GetExecutingAssembly
        Dim AssemblyName As AssemblyName = Assembly.GetName
        Dim version As Version = AssemblyName.Version
        Me.Text = Me.Text & " " & version.ToString
        txtServer.Text = ConfigReader.SqlServer
        txtDatabase.Text = ConfigReader.Database
        txtFileLocation.Text = ConfigReader.ExportDirectory
        txtFTPAddress.Text = ConfigReader.FtpAddress
        txtFTPUsername.Text = ConfigReader.FtpUsername
        mskFTPPassword.Text = ConfigReader.FtpPassword
        txtFTPPort.Text = ConfigReader.FtpPort.ToString()
        txtFTPUploadPath.Text = ConfigReader.FtpUploadPath

        logger = New StatusLogger(txtFileLocation.Text)
        notifier = New StatusNotifier(lblStatus)

        chkExcludeZeroQty.Checked = True
        chkSFTP.Checked = True
        chkIncludeHeaderline.Checked = True

        logger.Log("Initializing form...")
        notifier.Info("Form loaded.")

        AddHandler tvCompanyList.AfterCheck, AddressOf tvCompanyList_AfterCheck
    End Sub

    Private Sub btnTestConnection_Click(sender As Object, e As EventArgs) Handles btnTestConnection.Click
        logger.Log("Testing SQL connection...")

        If String.IsNullOrWhiteSpace(txtServer.Text) OrElse String.IsNullOrWhiteSpace(txtDatabase.Text) Then
            notifier.Warn("Please enter both Server and Database.")
            Return
        End If

        connstr = SqlConnector.BuildConnectionString(txtServer.Text, txtDatabase.Text)

        Try
            If SqlConnector.TestConnection(connstr, notifier, logger) Then
                CompanyLoader.LoadCompanyTreeView(tvCompanyList, connstr, logger, notifier)
                ManufacturerLoader.LoadManufacturerList(clbManufacturers, connstr, logger, notifier, Me)
                logger.Log("SQL connection successful.")
                notifier.Info("✅ Connected to SQL.")
            End If
        Catch ex As Exception
            logger.Log("Connection failed: " & ex.Message, True)
            notifier.ErrorMessage("❌ Connection failed. Check logs for details.")
        End Try
    End Sub

    Private Sub btnBrowseWorkDir_Click(sender As Object, e As EventArgs) Handles btnBrowseWorkDir.Click
        Using dlg As New FolderBrowserDialog With {.Description = "Select Export Directory", .SelectedPath = txtFileLocation.Text}
            If dlg.ShowDialog() = DialogResult.OK Then
                txtFileLocation.Text = dlg.SelectedPath
                logger.Log("Directory selected: " & dlg.SelectedPath)
                notifier.Info("Directory selected.")
            End If
        End Using
    End Sub

    Private Function ValidateInputs() As Boolean
        If String.IsNullOrWhiteSpace(txtServer.Text) Then
            notifier.Warn("SQL Server name is required.")
            txtServer.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtDatabase.Text) Then
            notifier.Warn("Database name is required.")
            txtDatabase.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtFileLocation.Text) OrElse Not Directory.Exists(txtFileLocation.Text) Then
            notifier.Warn("Valid export directory is required.")
            txtFileLocation.Focus()
            Return False
        End If

        If chkSFTP.Checked Then
            If String.IsNullOrWhiteSpace(txtFTPAddress.Text) Then
                notifier.Warn("FTP address is required.")
                txtFTPAddress.Focus()
                Return False
            End If

            If String.IsNullOrWhiteSpace(txtFTPUsername.Text) Then
                notifier.Warn("FTP username is required.")
                txtFTPUsername.Focus()
                Return False
            End If

            If String.IsNullOrWhiteSpace(mskFTPPassword.Text) Then
                notifier.Warn("FTP password is required.")
                mskFTPPassword.Focus()
                Return False
            End If

            Dim port As Integer
            If Not Integer.TryParse(txtFTPPort.Text, port) OrElse port <= 0 OrElse port > 65535 Then
                notifier.Warn("FTP port must be a number between 1 and 65535.")
                txtFTPPort.Focus()
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub btnProcessCustomers_Click(sender As Object, e As EventArgs) Handles btnProcessCustomers.Click
        If String.IsNullOrWhiteSpace(connstr) Then
            notifier.ErrorMessage("❌ Please connect to SQL first.")
            Return
        End If

        If Not ValidateInputs() Then Exit Sub

        If GetSelectedCompanyIds().Count = 0 Then
            notifier.Warn("⚠ Please select at least one company.")
            Return
        End If

        If chkSFTP.Checked Then
            If String.IsNullOrWhiteSpace(txtFTPAddress.Text) OrElse
               String.IsNullOrWhiteSpace(txtFTPUsername.Text) OrElse
               String.IsNullOrWhiteSpace(mskFTPPassword.Text) OrElse
               String.IsNullOrWhiteSpace(txtFTPUploadPath.Text) Then
                notifier.ErrorMessage("❌ SFTP settings are incomplete.")
                Return
            End If

            Dim portTest As Integer
            If Not Integer.TryParse(txtFTPPort.Text, portTest) Then
                notifier.ErrorMessage("❌ Invalid port number.")
                Return
            End If
        End If

        notifier.Info("Processing export...")
        progressBar.Visible = True
        btnProcessCustomers.Enabled = False

        bgWorker.RunWorkerAsync()
    End Sub

    Private Sub bgWorker_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgWorker.DoWork
        Try
            notifier = New StatusNotifier(lblStatus)
            logger = New StatusLogger(txtFileLocation.Text)

            Dim companyIds = GetSelectedCompanyIds()
            Dim selectedManufacturers As New List(Of String)
            For Each item In clbManufacturers.CheckedItems
                selectedManufacturers.Add(item.ToString())
            Next

            Dim filePrefix = OptionsHelper.GetExportPrefix(txtFileName)

            Dim createdFiles = ExportBuilder.ExportInventoryData(
                connstr,
                companyIds,
                txtFileLocation.Text,
                filePrefix,
                chkSplitByShop.Checked,
                chkExcludeZeroQty.Checked,
                chkIncludeHeaderline.Checked,
                selectedManufacturers,
                logger,
                notifier
            )

            If chkSFTP.Checked Then
                Dim sftp = New SftpService(txtFTPAddress.Text, txtFTPUsername.Text, mskFTPPassword.Text, TryParsePort(txtFTPPort.Text))
                For Each file In createdFiles
                    Dim remotePath = txtFTPUploadPath.Text.Trim().TrimEnd("/"c) & "/Stock_19.csv"
                    sftp.UploadFile(file, remotePath, notifier, logger)
                    logger.Log("Uploaded: " & remotePath)
                Next
            End If
            e.Result = createdFiles

        Catch ex As Exception
            e.Result = ex
        End Try
    End Sub

    Private Sub bgWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgWorker.RunWorkerCompleted
        progressBar.Visible = False
        lblStatus.Text = ""
        btnProcessCustomers.Enabled = True

        If TypeOf e.Result Is Exception Then
            Dim ex As Exception = DirectCast(e.Result, Exception)
            logger.Log("Export failed: " & ex.Message, True)
            notifier.ErrorMessage("❌ Export failed. See log for details.")

            Dim logPath As String = logger.LogPath
            If File.Exists(logPath) Then
                Dim result = MessageBox.Show(
                    $"Export failed: {ex.Message}{Environment.NewLine}{Environment.NewLine}Do you want to open the log file?",
                    "Export Error",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error
                )
                If result = DialogResult.Yes Then
                    Process.Start("explorer.exe", $"/select,""{logPath}""")
                End If
            Else
                MessageBox.Show("The log file could not be found.", "Log Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            Dim createdFiles = TryCast(e.Result, List(Of String))
            If createdFiles Is Nothing OrElse createdFiles.Count = 0 Then
                notifier.Info("⚠ Export completed, but no data matched the selected criteria.")
            Else
                logger.Log("Export completed successfully.")
                notifier.Info("✅ Export completed.")
                MessageBox.Show("Export completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private isProgrammaticallyChecking As Boolean = False

    Private Sub tvCompanyList_AfterCheck(sender As Object, e As TreeViewEventArgs)
        If isProgrammaticallyChecking OrElse e.Action = TreeViewAction.Unknown Then Return
        isProgrammaticallyChecking = True
        CheckAllChildNodes(e.Node, e.Node.Checked)
        UpdateParentCheckState(e.Node)
        isProgrammaticallyChecking = False
    End Sub

    Private Sub CheckAllChildNodes(node As TreeNode, isChecked As Boolean)
        For Each child As TreeNode In node.Nodes
            child.Checked = isChecked
            If child.Nodes.Count > 0 Then
                CheckAllChildNodes(child, isChecked)
            End If
        Next
    End Sub

    Private Sub UpdateParentCheckState(node As TreeNode)
        Dim parent = node.Parent
        If parent Is Nothing Then Exit Sub
        Dim allChecked = parent.Nodes.Cast(Of TreeNode)().All(Function(n) n.Checked)
        parent.Checked = allChecked
        UpdateParentCheckState(parent)
    End Sub

    Private Function GetSelectedCompanyIds() As List(Of String)
        Dim selected As New List(Of String)
        For Each root In tvCompanyList.Nodes
            CollectCompanyNodes(DirectCast(root, TreeNode), selected, True)
        Next
        Return selected
    End Function

    Private Sub CollectCompanyNodes(node As TreeNode, ByRef list As List(Of String), requireChecked As Boolean)
        If node.Nodes.Count = 0 AndAlso Not String.IsNullOrWhiteSpace(node.Name) Then
            If Not requireChecked OrElse node.Checked Then list.Add(node.Name)
        End If
        For Each child As TreeNode In node.Nodes
            CollectCompanyNodes(child, list, requireChecked)
        Next
    End Sub

    Private Function TryParsePort(text As String) As Integer
        Dim port As Integer
        If Integer.TryParse(text, port) Then Return port
        logger.Log("Invalid SFTP port. Defaulting to 22.")
        notifier.Warn("Invalid SFTP port. Using 22.")
        Return 22
    End Function

    Private Sub btnSelectAll_Click(sender As Object, e As EventArgs) Handles btnSelectAll.Click
        For i As Integer = 0 To clbManufacturers.Items.Count - 1
            clbManufacturers.SetItemChecked(i, True)
        Next
    End Sub

    Private Sub btnUnselectAll_Click(sender As Object, e As EventArgs) Handles btnUnselectAll.Click
        For i As Integer = 0 To clbManufacturers.Items.Count - 1
            clbManufacturers.SetItemChecked(i, False)
        Next
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim filter = txtSearch.Text.Trim().ToLower()
        clbManufacturers.Items.Clear()
        For Each mfg In allManufacturers
            If mfg.ToLower().Contains(filter) Then
                clbManufacturers.Items.Add(mfg)
            End If
        Next
    End Sub

    Private Sub btnSaveSettings_Click(sender As Object, e As EventArgs) Handles btnSaveSettings.Click
        Try
            ConfigReader.SaveSetting("SqlServer", txtServer.Text)
            ConfigReader.SaveSetting("Database", txtDatabase.Text)
            ConfigReader.SaveSetting("ExportDirectory", txtFileLocation.Text)

            ConfigReader.SaveSetting("FtpAddress", txtFTPAddress.Text)
            ConfigReader.SaveSetting("FtpUsername", txtFTPUsername.Text)
            ConfigReader.SaveSetting("FtpPassword", mskFTPPassword.Text)
            ConfigReader.SaveSetting("FtpPort", txtFTPPort.Text)
            ConfigReader.SaveSetting("FtpUploadPath", txtFTPUploadPath.Text)

            notifier.Info("✅ Settings saved.")
            MessageBox.Show("Settings saved successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            notifier.ErrorMessage("❌ Failed to save settings.")
            MessageBox.Show("Error saving settings: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
