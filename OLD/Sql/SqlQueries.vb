Public Module SqlQueries

    Public Const GetCompanies As String = "
        SELECT C.COMPANY_NUMBER, C.COMPANY_ALIAS,
               ISNULL(D.TITLE, '') AS DISTRICT_TITLE,
               ISNULL(A.TITLE, '') AS AREA_TITLE
        FROM COMPANY C
        LEFT JOIN DISTRICT D ON C.DISTRICT = D.DISTRICT_NUMBER
        LEFT JOIN AREA A ON C.AREA = A.AREA_NUMBER
        ORDER BY AREA_TITLE, DISTRICT_TITLE, C.COMPANY_NUMBER"
    Public Function GetInventoryQuery(companyIds As List(Of String), manufacturers As List(Of String)) As String
        Dim companyPlaceholders = String.Join(",", companyIds.Select(Function(id) $"'{id}'"))
        Dim brandPlaceholders = String.Join(",", manufacturers.Select(Function(name) $"'{name.Replace("'", "''")}'"))

        Return $"
        SELECT DISTINCT
               I.COMPANY AS STORE_ID,
               D.DESCRIPTION AS BRAND_NAME,
               I.ITEM_NUMBER AS ITEM_CODE,
               I.QTY_ON_HAND AS STOCK,
               I.PART_PRICE AS PRICE,
               I.FET
        FROM ITEM I
        INNER JOIN MASTER M ON I.VENDOR_NUMBER = M.VENDOR_CODE  AND I.ITEM_NUMBER = M.PART_NUMBER 
        lEFT JOIN MFGDESCRIPTION D 
            ON I.VENDOR_NUMBER = D.VENDOR_CODE
        WHERE I.COMPANY IN ({companyPlaceholders})
          AND D.DESCRIPTION IN ({brandPlaceholders})
          AND M.TIRE_PART = 1
          AND D.HASTIRES = 1
          AND D.ENABLED = 1
          AND M.DISABLED = 0
        ORDER BY STORE_ID ASC, BRAND_NAME ASC"
    End Function

    Public Const GetManufacturers As String = "
    SELECT DESCRIPTION
    FROM MFGDESCRIPTION
    WHERE HASTIRES = 1 AND ENABLED = 1 AND DESCRIPTION IS NOT NULL AND LTRIM(RTRIM(DESCRIPTION)) <> ''
    ORDER BY DESCRIPTION ASC"

End Module