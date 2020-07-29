Module MOD_BATCH

#Region "バッチ用・変数"
    Friend STR_FUNC_BATCH_MAIN_ERR_STR As String '最終エラー文字列
#End Region

#Region "バッチ用・構造体"
    Public Structure SRT_BATCH_CONDITIONS 'バッチ条件
        Public YYYYMM_B_MONTH As Integer

        Public DATE_DO_BATCH As DateTime
        Public FORM As Object

        Public RET_DELETE_CONTENT_COUNT As Integer
    End Structure

#End Region

    Friend Function FUNC_BACTH_MAIN(ByRef BLN_PUT As Boolean, ByRef SRT_CONDITIONS As SRT_BATCH_CONDITIONS) As Boolean

        BLN_PUT = True 'データ無しケースを考慮しない
        SRT_CONDITIONS.RET_DELETE_CONTENT_COUNT = 0

        If Not FUNC_SYSTEM_BEGIN_TRANSACTION() Then
            STR_FUNC_BATCH_MAIN_ERR_STR = FUNC_SYSTEM_SQLGET_ERR_MESSAGE()
            Return False
        End If

        '月次年月更新
        If Not FUNC_UPDATE_MNG_M_MONTH_CODE_YYYYMM(CST_SYSTEM_INDIVIDUAL_SYSTEM_CODE, SRT_CONDITIONS.YYYYMM_B_MONTH) Then
            STR_FUNC_BATCH_MAIN_ERR_STR = str_SQL_TOOL_LAST_ERR_STRING
            Call FUNC_SYSTEM_ROLLBACK_TRANSACTION()
        End If

        If Not FUNC_SYSTEM_COMMIT_TRANSACTION() Then
            STR_FUNC_BATCH_MAIN_ERR_STR = FUNC_SYSTEM_SQLGET_ERR_MESSAGE()
            Return False
        End If

        Return True
    End Function
End Module
