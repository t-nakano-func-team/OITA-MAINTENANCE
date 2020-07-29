Module MOD_BATCH

#Region "バッチ用・変数"
    Friend STR_FUNC_BATCH_MAIN_ERR_STR As String '最終エラー文字列
#End Region

#Region "バッチ用・構造体"
    Public Structure SRT_INVOICE_INFO_RECORD
        Public KEY As SRT_NUMBER_SERIAL_CONTRACT
        Public EDIT As SRT_EDIT_INVOICE
    End Structure

    Public Structure SRT_BATCH_CONDITIONS 'バッチ条件
        Public RECORD() As SRT_INVOICE_INFO_RECORD
        Public DATE_INVOICE As DateTime

        Public DATE_DO_BATCH As DateTime
        Public FORM As Object
    End Structure
#End Region

    Friend Function FUNC_BACTH_MAIN(ByRef BLN_PUT As Boolean, ByRef SRT_CONDITIONS As SRT_BATCH_CONDITIONS) As Boolean
        BLN_PUT = True 'データ無しケースを考慮しない

        If Not FUNC_SYSTEM_BEGIN_TRANSACTION() Then
            STR_FUNC_BATCH_MAIN_ERR_STR = FUNC_SYSTEM_SQLGET_ERR_MESSAGE()
            Return False
        End If

        For i = 1 To (SRT_CONDITIONS.RECORD.Length - 1)
            With SRT_CONDITIONS
                If Not FUNC_MAKE_NEW_INVOICE(.RECORD(i).KEY.NUMBER_CONTRACT, .RECORD(i).KEY.SERIAL_CONTRACT, .DATE_INVOICE, .RECORD(i).EDIT) Then
                    STR_FUNC_BATCH_MAIN_ERR_STR = FUNC_SYSTEM_SQLGET_ERR_MESSAGE()
                    Call FUNC_SYSTEM_ROLLBACK_TRANSACTION()
                    Return False
                End If
            End With
        Next

        If Not FUNC_SYSTEM_COMMIT_TRANSACTION() Then
            STR_FUNC_BATCH_MAIN_ERR_STR = FUNC_SYSTEM_SQLGET_ERR_MESSAGE()
            Return False
        End If

        Return True
    End Function

End Module
