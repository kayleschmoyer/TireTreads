Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class CompanyLoader
    Public Shared Sub LoadCompanyTreeView(tvCompanyList As TreeView, connStr As String, logger As StatusLogger, notifier As StatusNotifier)
        Try
            logger.Log("Loading company tree from database...")
            notifier.Info("Loading company list...")

            tvCompanyList.Nodes.Clear()
            Dim rootNode As New TreeNode("All Shops")
            tvCompanyList.Nodes.Add(rootNode)

            Using conn As New SqlConnection(connStr)
                Dim cmd As New SqlCommand(SqlQueries.GetCompanies, conn)
                conn.Open()

                Dim reader = cmd.ExecuteReader()

                Dim currentAreaNode As TreeNode = Nothing
                Dim currentDistrictNode As TreeNode = Nothing
                Dim lastArea As String = ""
                Dim lastDistrict As String = ""

                While reader.Read()
                    Dim areaTitle = reader("AREA_TITLE").ToString().Trim()
                    Dim districtTitle = reader("DISTRICT_TITLE").ToString().Trim()
                    Dim companyNum = reader("COMPANY_NUMBER").ToString().Trim()
                    Dim aliasName = reader("COMPANY_ALIAS").ToString().Trim()

                    If areaTitle <> lastArea Then
                        currentAreaNode = New TreeNode(areaTitle)
                        rootNode.Nodes.Add(currentAreaNode)
                        lastArea = areaTitle
                        lastDistrict = ""
                    End If

                    If districtTitle <> lastDistrict Then
                        currentDistrictNode = New TreeNode(districtTitle)
                        currentAreaNode.Nodes.Add(currentDistrictNode)
                        lastDistrict = districtTitle
                    End If

                    If Not String.IsNullOrWhiteSpace(companyNum) Then
                        Dim display = companyNum & " - " & aliasName
                        Dim companyNode As New TreeNode(display)
                        companyNode.Name = companyNum
                        currentDistrictNode.Nodes.Add(companyNode)
                    End If
                End While
            End Using

            tvCompanyList.ExpandAll()
            If rootNode.Nodes.Count > 0 Then
                tvCompanyList.SelectedNode = rootNode.Nodes(0)
            End If

            logger.Log("Company tree loaded successfully.")
            notifier.Info("Company list loaded.")
        Catch ex As Exception
            logger.Log("Failed to load company tree: " & ex.Message, True)
            notifier.ErrorMessage("❌ Unable to load company list. Please check the connection or logs.")
        End Try
    End Sub
End Class
