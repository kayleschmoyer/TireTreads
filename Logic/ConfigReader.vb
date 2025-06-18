Imports System.Configuration

Public Class ConfigReader

    ' READ PROPERTIES ---------------------------

    Public Shared ReadOnly Property SqlServer As String
        Get
            Return ConfigurationManager.AppSettings("SqlServer")
        End Get
    End Property

    Public Shared ReadOnly Property Database As String
        Get
            Return ConfigurationManager.AppSettings("Database")
        End Get
    End Property

    Public Shared ReadOnly Property ExportDirectory As String
        Get
            Return ConfigurationManager.AppSettings("ExportDirectory")
        End Get
    End Property

    Public Shared ReadOnly Property FtpAddress As String
        Get
            Return ConfigurationManager.AppSettings("FtpAddress")
        End Get
    End Property

    Public Shared ReadOnly Property FtpUsername As String
        Get
            Return ConfigurationManager.AppSettings("FtpUsername")
        End Get
    End Property

    Public Shared ReadOnly Property FtpPassword As String
        Get
            Return ConfigurationManager.AppSettings("FtpPassword")
        End Get
    End Property

    Public Shared ReadOnly Property FtpPort As Integer
        Get
            Dim val As String = ConfigurationManager.AppSettings("FtpPort")
            If Integer.TryParse(val, Nothing) Then
                Return Integer.Parse(val)
            Else
                Return 22
            End If
        End Get
    End Property

    Public Shared ReadOnly Property FtpUploadPath As String
        Get
            Return ConfigurationManager.AppSettings("FtpUploadPath")
        End Get
    End Property

    ' WRITE SUPPORT -----------------------------

    Public Shared Sub SaveSetting(key As String, value As String)
        Try
            Dim config As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)

            If config.AppSettings.Settings(key) IsNot Nothing Then
                config.AppSettings.Settings(key).Value = value
            Else
                config.AppSettings.Settings.Add(key, value)
            End If

            config.Save(ConfigurationSaveMode.Modified)
            ConfigurationManager.RefreshSection("appSettings")
        Catch ex As Exception
            Throw New Exception("Failed to save setting '" & key & "': " & ex.Message, ex)
        End Try
    End Sub

    Public Shared ReadOnly Property CompanyIds As String
        Get
            Return ConfigurationManager.AppSettings("CompanyIds")
        End Get
    End Property

    Public Shared ReadOnly Property ManufacturerDescriptions As String
        Get
            Return ConfigurationManager.AppSettings("ManufacturerDescriptions")
        End Get
    End Property

    Public Shared ReadOnly Property GetConnectionString As String
        Get
            Return $"Server={SqlServer};Database={Database};Integrated Security=True;"
        End Get
    End Property


End Class
