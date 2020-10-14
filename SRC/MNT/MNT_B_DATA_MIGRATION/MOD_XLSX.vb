Module MOD_XLSX

#Region "変数"
    Private BOK_XLSX As ClosedXML.Excel.XLWorkbook
    Private SHT_READ As ClosedXML.Excel.IXLWorksheet
#End Region

    Public Function FUNC_INIT_XLS(ByVal STR_PATH As String, Optional ByVal INT_NUMBER_SEET As Integer = 1) As Boolean

        Try
            BOK_XLSX = New ClosedXML.Excel.XLWorkbook(STR_PATH)
        Catch ex As Exception
            Return False
        End Try

        SHT_READ = BOK_XLSX.Worksheet(INT_NUMBER_SEET) 'デフォルトシート

        Return True
    End Function

    Public Function FUNC_GET_VALUE_XLSX(ByVal INT_ROW As Integer, ByVal INT_COL As Integer) As String
        Dim CEL_READ As ClosedXML.Excel.IXLCell
        Try
            CEL_READ = SHT_READ.Cell(INT_ROW, INT_COL)
        Catch ex As Exception
            Return False
        End Try

        Dim STR_RET As String
        STR_RET = CEL_READ.Value
        CEL_READ = Nothing

        Return STR_RET
    End Function

    Public Function FUNC_END_XLS() As Boolean
        SHT_READ = Nothing

        Call BOK_XLSX.Dispose()
        BOK_XLSX = Nothing

        Return True
    End Function
End Module
