<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.txtDatabase = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.grpDatabase = New System.Windows.Forms.GroupBox()
        Me.btnTestConnection = New System.Windows.Forms.Button()
        Me.grpFileLocation = New System.Windows.Forms.GroupBox()
        Me.btnBrowseWorkDir = New System.Windows.Forms.Button()
        Me.txtFileLocation = New System.Windows.Forms.TextBox()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.timer_Writer = New System.Windows.Forms.Timer(Me.components)
        Me.lblTime = New System.Windows.Forms.Label()
        Me.lblThreads = New System.Windows.Forms.Label()
        Me.btnProcessCustomers = New System.Windows.Forms.Button()
        Me.tcMain = New System.Windows.Forms.TabControl()
        Me.tabMain = New System.Windows.Forms.TabPage()
        Me.btnSaveSettings = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tvCompanyList = New System.Windows.Forms.TreeView()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFTPUploadPath = New System.Windows.Forms.TextBox()
        Me.mskFTPPassword = New System.Windows.Forms.TextBox()
        Me.txtFTPUsername = New System.Windows.Forms.TextBox()
        Me.txtFTPAddress = New System.Windows.Forms.TextBox()
        Me.lblFTPPortLabel = New System.Windows.Forms.Label()
        Me.txtFTPPort = New System.Windows.Forms.TextBox()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnUnselectAll = New System.Windows.Forms.Button()
        Me.btnSelectAll = New System.Windows.Forms.Button()
        Me.clbManufacturers = New System.Windows.Forms.CheckedListBox()
        Me.chkExcludeZeroQty = New System.Windows.Forms.CheckBox()
        Me.chkSFTP = New System.Windows.Forms.CheckBox()
        Me.chkSplitByShop = New System.Windows.Forms.CheckBox()
        Me.chkIncludeHeaderline = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.progressBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.bgWorker = New System.ComponentModel.BackgroundWorker()
        Me.grpDatabase.SuspendLayout()
        Me.grpFileLocation.SuspendLayout()
        Me.tcMain.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(55, 27)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(267, 23)
        Me.txtServer.TabIndex = 0
        '
        'txtDatabase
        '
        Me.txtDatabase.Location = New System.Drawing.Point(423, 28)
        Me.txtDatabase.Name = "txtDatabase"
        Me.txtDatabase.Size = New System.Drawing.Size(262, 23)
        Me.txtDatabase.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(7, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Server"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(356, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Database"
        '
        'grpDatabase
        '
        Me.grpDatabase.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.grpDatabase.Controls.Add(Me.btnTestConnection)
        Me.grpDatabase.Controls.Add(Me.txtServer)
        Me.grpDatabase.Controls.Add(Me.Label3)
        Me.grpDatabase.Controls.Add(Me.txtDatabase)
        Me.grpDatabase.Controls.Add(Me.Label2)
        Me.grpDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.grpDatabase.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.grpDatabase.Location = New System.Drawing.Point(10, 11)
        Me.grpDatabase.Margin = New System.Windows.Forms.Padding(10)
        Me.grpDatabase.Name = "grpDatabase"
        Me.grpDatabase.Size = New System.Drawing.Size(955, 62)
        Me.grpDatabase.TabIndex = 5
        Me.grpDatabase.TabStop = False
        Me.grpDatabase.Text = "SQL Settings"
        '
        'btnTestConnection
        '
        Me.btnTestConnection.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnTestConnection.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnTestConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTestConnection.ForeColor = System.Drawing.Color.Black
        Me.btnTestConnection.Location = New System.Drawing.Point(781, 20)
        Me.btnTestConnection.Name = "btnTestConnection"
        Me.btnTestConnection.Size = New System.Drawing.Size(151, 28)
        Me.btnTestConnection.TabIndex = 2
        Me.btnTestConnection.Text = "Connect to SQL"
        Me.btnTestConnection.UseVisualStyleBackColor = False
        '
        'grpFileLocation
        '
        Me.grpFileLocation.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.grpFileLocation.Controls.Add(Me.btnBrowseWorkDir)
        Me.grpFileLocation.Controls.Add(Me.txtFileLocation)
        Me.grpFileLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.grpFileLocation.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.grpFileLocation.Location = New System.Drawing.Point(10, 79)
        Me.grpFileLocation.Margin = New System.Windows.Forms.Padding(10)
        Me.grpFileLocation.Name = "grpFileLocation"
        Me.grpFileLocation.Size = New System.Drawing.Size(955, 65)
        Me.grpFileLocation.TabIndex = 15
        Me.grpFileLocation.TabStop = False
        Me.grpFileLocation.Text = "Export Directory"
        '
        'btnBrowseWorkDir
        '
        Me.btnBrowseWorkDir.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnBrowseWorkDir.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnBrowseWorkDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBrowseWorkDir.Location = New System.Drawing.Point(857, 25)
        Me.btnBrowseWorkDir.Name = "btnBrowseWorkDir"
        Me.btnBrowseWorkDir.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowseWorkDir.TabIndex = 4
        Me.btnBrowseWorkDir.Text = "Browse..."
        Me.btnBrowseWorkDir.UseVisualStyleBackColor = False
        '
        'txtFileLocation
        '
        Me.txtFileLocation.Location = New System.Drawing.Point(13, 25)
        Me.txtFileLocation.Name = "txtFileLocation"
        Me.txtFileLocation.Size = New System.Drawing.Size(838, 23)
        Me.txtFileLocation.TabIndex = 3
        '
        'timer_Writer
        '
        Me.timer_Writer.Interval = 30000
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.Location = New System.Drawing.Point(23, 267)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(0, 15)
        Me.lblTime.TabIndex = 20
        '
        'lblThreads
        '
        Me.lblThreads.AutoSize = True
        Me.lblThreads.Location = New System.Drawing.Point(9, 373)
        Me.lblThreads.Name = "lblThreads"
        Me.lblThreads.Size = New System.Drawing.Size(0, 15)
        Me.lblThreads.TabIndex = 21
        '
        'btnProcessCustomers
        '
        Me.btnProcessCustomers.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnProcessCustomers.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnProcessCustomers.FlatAppearance.BorderSize = 0
        Me.btnProcessCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProcessCustomers.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcessCustomers.ForeColor = System.Drawing.Color.White
        Me.btnProcessCustomers.Location = New System.Drawing.Point(368, 463)
        Me.btnProcessCustomers.Name = "btnProcessCustomers"
        Me.btnProcessCustomers.Size = New System.Drawing.Size(234, 36)
        Me.btnProcessCustomers.TabIndex = 16
        Me.btnProcessCustomers.Text = "Start TireTreads Export"
        Me.btnProcessCustomers.UseVisualStyleBackColor = False
        '
        'tcMain
        '
        Me.tcMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tcMain.Controls.Add(Me.tabMain)
        Me.tcMain.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tcMain.ItemSize = New System.Drawing.Size(96, 23)
        Me.tcMain.Location = New System.Drawing.Point(11, 7)
        Me.tcMain.Name = "tcMain"
        Me.tcMain.SelectedIndex = 0
        Me.tcMain.Size = New System.Drawing.Size(979, 539)
        Me.tcMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tcMain.TabIndex = 23
        '
        'tabMain
        '
        Me.tabMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.tabMain.Controls.Add(Me.btnSaveSettings)
        Me.tabMain.Controls.Add(Me.TabControl1)
        Me.tabMain.Controls.Add(Me.grpDatabase)
        Me.tabMain.Controls.Add(Me.btnProcessCustomers)
        Me.tabMain.Controls.Add(Me.grpFileLocation)
        Me.tabMain.Location = New System.Drawing.Point(4, 27)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMain.Size = New System.Drawing.Size(971, 508)
        Me.tabMain.TabIndex = 0
        Me.tabMain.Text = "Main"
        '
        'btnSaveSettings
        '
        Me.btnSaveSettings.Location = New System.Drawing.Point(848, 463)
        Me.btnSaveSettings.Name = "btnSaveSettings"
        Me.btnSaveSettings.Size = New System.Drawing.Size(94, 36)
        Me.btnSaveSettings.TabIndex = 24
        Me.btnSaveSettings.Text = "Save Settings"
        Me.btnSaveSettings.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Location = New System.Drawing.Point(10, 161)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(955, 296)
        Me.TabControl1.TabIndex = 23
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 27)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(947, 265)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Company Selection"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.tvCompanyList)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Location = New System.Drawing.Point(6, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(935, 252)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select A Company"
        '
        'tvCompanyList
        '
        Me.tvCompanyList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tvCompanyList.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.tvCompanyList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvCompanyList.CheckBoxes = True
        Me.tvCompanyList.FullRowSelect = True
        Me.tvCompanyList.HideSelection = False
        Me.tvCompanyList.Location = New System.Drawing.Point(6, 21)
        Me.tvCompanyList.Name = "tvCompanyList"
        Me.tvCompanyList.Size = New System.Drawing.Size(923, 225)
        Me.tvCompanyList.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.TabPage4.Controls.Add(Me.Label6)
        Me.TabPage4.Controls.Add(Me.Label5)
        Me.TabPage4.Controls.Add(Me.Label4)
        Me.TabPage4.Controls.Add(Me.Label1)
        Me.TabPage4.Controls.Add(Me.txtFTPUploadPath)
        Me.TabPage4.Controls.Add(Me.mskFTPPassword)
        Me.TabPage4.Controls.Add(Me.txtFTPUsername)
        Me.TabPage4.Controls.Add(Me.txtFTPAddress)
        Me.TabPage4.Controls.Add(Me.lblFTPPortLabel)
        Me.TabPage4.Controls.Add(Me.txtFTPPort)
        Me.TabPage4.Location = New System.Drawing.Point(4, 27)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(947, 265)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "SFTP Configuration"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(77, 163)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 15)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Path:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(51, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 15)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Password:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(48, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 15)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Username:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(46, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 15)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Hostname:"
        '
        'txtFTPUploadPath
        '
        Me.txtFTPUploadPath.Location = New System.Drawing.Point(117, 160)
        Me.txtFTPUploadPath.Name = "txtFTPUploadPath"
        Me.txtFTPUploadPath.Size = New System.Drawing.Size(160, 23)
        Me.txtFTPUploadPath.TabIndex = 9
        '
        'mskFTPPassword
        '
        Me.mskFTPPassword.Location = New System.Drawing.Point(117, 121)
        Me.mskFTPPassword.Name = "mskFTPPassword"
        Me.mskFTPPassword.Size = New System.Drawing.Size(160, 23)
        Me.mskFTPPassword.TabIndex = 8
        Me.mskFTPPassword.UseSystemPasswordChar = True
        '
        'txtFTPUsername
        '
        Me.txtFTPUsername.Location = New System.Drawing.Point(117, 80)
        Me.txtFTPUsername.Name = "txtFTPUsername"
        Me.txtFTPUsername.Size = New System.Drawing.Size(160, 23)
        Me.txtFTPUsername.TabIndex = 7
        '
        'txtFTPAddress
        '
        Me.txtFTPAddress.Location = New System.Drawing.Point(117, 39)
        Me.txtFTPAddress.Name = "txtFTPAddress"
        Me.txtFTPAddress.Size = New System.Drawing.Size(160, 23)
        Me.txtFTPAddress.TabIndex = 5
        '
        'lblFTPPortLabel
        '
        Me.lblFTPPortLabel.AutoSize = True
        Me.lblFTPPortLabel.Location = New System.Drawing.Point(303, 42)
        Me.lblFTPPortLabel.Name = "lblFTPPortLabel"
        Me.lblFTPPortLabel.Size = New System.Drawing.Size(32, 15)
        Me.lblFTPPortLabel.TabIndex = 5
        Me.lblFTPPortLabel.Text = "Port:"
        '
        'txtFTPPort
        '
        Me.txtFTPPort.Location = New System.Drawing.Point(341, 39)
        Me.txtFTPPort.Name = "txtFTPPort"
        Me.txtFTPPort.Size = New System.Drawing.Size(72, 23)
        Me.txtFTPPort.TabIndex = 6
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.TabPage5.Controls.Add(Me.Label7)
        Me.TabPage5.Controls.Add(Me.txtSearch)
        Me.TabPage5.Controls.Add(Me.btnUnselectAll)
        Me.TabPage5.Controls.Add(Me.btnSelectAll)
        Me.TabPage5.Controls.Add(Me.clbManufacturers)
        Me.TabPage5.Controls.Add(Me.chkExcludeZeroQty)
        Me.TabPage5.Controls.Add(Me.chkSFTP)
        Me.TabPage5.Controls.Add(Me.chkSplitByShop)
        Me.TabPage5.Controls.Add(Me.chkIncludeHeaderline)
        Me.TabPage5.Controls.Add(Me.GroupBox2)
        Me.TabPage5.Location = New System.Drawing.Point(4, 27)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(947, 265)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "File Options"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(463, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(135, 15)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "Search for Manufacturer"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(604, 9)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(324, 23)
        Me.txtSearch.TabIndex = 34
        '
        'btnUnselectAll
        '
        Me.btnUnselectAll.Location = New System.Drawing.Point(779, 235)
        Me.btnUnselectAll.Name = "btnUnselectAll"
        Me.btnUnselectAll.Size = New System.Drawing.Size(91, 23)
        Me.btnUnselectAll.TabIndex = 33
        Me.btnUnselectAll.Text = "Unselect All"
        Me.btnUnselectAll.UseVisualStyleBackColor = True
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Location = New System.Drawing.Point(670, 235)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(91, 23)
        Me.btnSelectAll.TabIndex = 32
        Me.btnSelectAll.Text = "Select All"
        Me.btnSelectAll.UseVisualStyleBackColor = True
        '
        'clbManufacturers
        '
        Me.clbManufacturers.CheckOnClick = True
        Me.clbManufacturers.FormattingEnabled = True
        Me.clbManufacturers.Location = New System.Drawing.Point(604, 45)
        Me.clbManufacturers.Name = "clbManufacturers"
        Me.clbManufacturers.Size = New System.Drawing.Size(324, 184)
        Me.clbManufacturers.Sorted = True
        Me.clbManufacturers.TabIndex = 31
        '
        'chkExcludeZeroQty
        '
        Me.chkExcludeZeroQty.AutoSize = True
        Me.chkExcludeZeroQty.Location = New System.Drawing.Point(6, 61)
        Me.chkExcludeZeroQty.Name = "chkExcludeZeroQty"
        Me.chkExcludeZeroQty.Size = New System.Drawing.Size(176, 19)
        Me.chkExcludeZeroQty.TabIndex = 15
        Me.chkExcludeZeroQty.Text = "Exclude 0 Quantity On Hand"
        Me.chkExcludeZeroQty.UseVisualStyleBackColor = True
        '
        'chkSFTP
        '
        Me.chkSFTP.AutoSize = True
        Me.chkSFTP.Checked = True
        Me.chkSFTP.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSFTP.Location = New System.Drawing.Point(6, 36)
        Me.chkSFTP.Name = "chkSFTP"
        Me.chkSFTP.Size = New System.Drawing.Size(94, 19)
        Me.chkSFTP.TabIndex = 14
        Me.chkSFTP.Text = "Send to SFTP"
        Me.chkSFTP.UseVisualStyleBackColor = True
        '
        'chkSplitByShop
        '
        Me.chkSplitByShop.AutoSize = True
        Me.chkSplitByShop.Location = New System.Drawing.Point(6, 86)
        Me.chkSplitByShop.Name = "chkSplitByShop"
        Me.chkSplitByShop.Size = New System.Drawing.Size(116, 19)
        Me.chkSplitByShop.TabIndex = 13
        Me.chkSplitByShop.Text = "Split File by Shop"
        Me.chkSplitByShop.UseVisualStyleBackColor = True
        Me.chkSplitByShop.Visible = False
        '
        'chkIncludeHeaderline
        '
        Me.chkIncludeHeaderline.AutoSize = True
        Me.chkIncludeHeaderline.Location = New System.Drawing.Point(6, 11)
        Me.chkIncludeHeaderline.Name = "chkIncludeHeaderline"
        Me.chkIncludeHeaderline.Size = New System.Drawing.Size(131, 19)
        Me.chkIncludeHeaderline.TabIndex = 11
        Me.chkIncludeHeaderline.Text = "Include Header Line"
        Me.chkIncludeHeaderline.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtFileName)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 204)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(306, 54)
        Me.GroupBox2.TabIndex = 30
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Filename Prefix"
        Me.GroupBox2.Visible = False
        '
        'txtFileName
        '
        Me.txtFileName.BackColor = System.Drawing.Color.White
        Me.txtFileName.Location = New System.Drawing.Point(13, 21)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(287, 23)
        Me.txtFileName.TabIndex = 10
        Me.txtFileName.Visible = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.progressBar, Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 549)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(997, 22)
        Me.StatusStrip1.TabIndex = 24
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'progressBar
        '
        Me.progressBar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(1, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.progressBar.Name = "progressBar"
        Me.progressBar.Size = New System.Drawing.Size(100, 16)
        Me.progressBar.Step = 1
        Me.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.progressBar.Visible = False
        '
        'lblStatus
        '
        Me.lblStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(982, 17)
        Me.lblStatus.Spring = True
        Me.lblStatus.Text = """"""
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'bgWorker
        '
        Me.bgWorker.WorkerReportsProgress = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(997, 571)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.tcMain)
        Me.Controls.Add(Me.lblThreads)
        Me.Controls.Add(Me.lblTime)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TireTreads Utility"
        Me.grpDatabase.ResumeLayout(False)
        Me.grpDatabase.PerformLayout()
        Me.grpFileLocation.ResumeLayout(False)
        Me.grpFileLocation.PerformLayout()
        Me.tcMain.ResumeLayout(False)
        Me.tabMain.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtServer As System.Windows.Forms.TextBox
    Friend WithEvents txtDatabase As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grpDatabase As System.Windows.Forms.GroupBox
    Friend WithEvents btnTestConnection As System.Windows.Forms.Button
    Friend WithEvents grpFileLocation As System.Windows.Forms.GroupBox
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents timer_Writer As System.Windows.Forms.Timer
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents lblThreads As System.Windows.Forms.Label
    Friend WithEvents btnProcessCustomers As System.Windows.Forms.Button
    Friend WithEvents txtFileLocation As System.Windows.Forms.TextBox
    Friend WithEvents tcMain As System.Windows.Forms.TabControl
    Friend WithEvents tabMain As System.Windows.Forms.TabPage
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents progressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents btnBrowseWorkDir As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tvCompanyList As System.Windows.Forms.TreeView
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents chkSFTP As System.Windows.Forms.CheckBox
    Friend WithEvents chkSplitByShop As System.Windows.Forms.CheckBox
    Friend WithEvents chkIncludeHeaderline As System.Windows.Forms.CheckBox
    Friend WithEvents chkExcludeZeroQty As System.Windows.Forms.CheckBox
    Friend WithEvents bgWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents txtFTPPort As System.Windows.Forms.TextBox
    Friend WithEvents lblFTPPortLabel As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFTPUploadPath As System.Windows.Forms.TextBox
    Friend WithEvents mskFTPPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtFTPUsername As System.Windows.Forms.TextBox
    Friend WithEvents txtFTPAddress As System.Windows.Forms.TextBox
    Friend WithEvents clbManufacturers As CheckedListBox
    Friend WithEvents btnUnselectAll As Button
    Friend WithEvents btnSelectAll As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtFileName As TextBox
    Friend WithEvents btnSaveSettings As Button
End Class
