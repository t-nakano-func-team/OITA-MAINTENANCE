Public Module MOD_SYSTEM_TOTAL_MST_UPDATE

End Module

#Region "MNG_M_MONTH"
Public Module MOD_SYSTEM_TOTAL_MST_UPDATE_MNG_M_MONTH

#Region "モジュール用・定数"
    Private Const CST_TABLE_NAME_DEFAULT As String = "MNG_M_MONTH"
#End Region

    Public Function FUNC_UPDATE_MNG_M_MONTH_CODE_YYYYMM(
    ByVal INT_CODE_SYSTEM As Integer,
    ByVal INT_CODE_YYYYMM As Integer
    ) As Boolean
        Dim STR_SQL As System.Text.StringBuilder

        STR_SQL = New System.Text.StringBuilder
        With STR_SQL
            Call .Append("UPDATE" & System.Environment.NewLine)
            Call .Append(strSYSTEM_PUBLIC_MNGDB_PREFIX & CST_TABLE_NAME_DEFAULT & System.Environment.NewLine)
            Call .Append("SET" & System.Environment.NewLine)
            Call .Append("CODE_YYYYMM=" & INT_CODE_YYYYMM & System.Environment.NewLine)
            Call .Append("WHERE" & System.Environment.NewLine)
            Call .Append("CODE_SYSTEM=" & INT_CODE_SYSTEM & System.Environment.NewLine)
        End With

        If Not FUNC_SYSTEM_DO_SQL_EXECUTE(STR_SQL.ToString) Then
            Return False
        End If

        Return True
    End Function

End Module

#End Region
