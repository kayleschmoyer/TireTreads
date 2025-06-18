Imports System.Linq

Public Module SqlQueries
    Public Function GetInventoryQuery(excludedBrands As String()) As String
        Dim brandFilter As String = If(excludedBrands IsNot Nothing AndAlso excludedBrands.Length > 0,
            "AND D.DESCRIPTION NOT IN (" & String.Join(",", excludedBrands.Select(Function(b) "'" & b.Replace("'", "''") & "'")) & ")",
            String.Empty)

        Return $"
        SELECT DISTINCT
               I.COMPANY AS STORE_ID,
               D.DESCRIPTION AS BRAND_NAME,
               I.ITEM_NUMBER AS ITEM_CODE,
               I.QTY_ON_HAND AS STOCK,
               I.PART_PRICE AS PRICE,
               I.FET
        FROM ITEM I
        INNER JOIN MASTER M ON I.VENDOR_NUMBER = M.VENDOR_CODE AND I.ITEM_NUMBER = M.PART_NUMBER
        LEFT JOIN MFGDESCRIPTION D ON I.VENDOR_NUMBER = D.VENDOR_CODE
        WHERE M.TIRE_PART = 1
          AND D.HASTIRES = 1
          AND D.ENABLED = 1
          AND M.DISABLED = 0
          {brandFilter}
        ORDER BY STORE_ID ASC, BRAND_NAME ASC"
    End Function
End Module
