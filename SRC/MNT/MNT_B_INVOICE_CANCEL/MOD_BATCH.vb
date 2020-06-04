Module MOD_BATCH

#Region "バッチ用・変数"
    Friend STR_FUNC_BATCH_MAIN_ERR_STR As String '最終エラー文字列
#End Region

#Region "バッチ用・構造体"
    Public Structure SRT_BATCH_CONDITIONS 'バッチ条件
        Public INVOICE_ROW() As SRT_NUMBER_SERIAL_INVOICE

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

        For i = 1 To (SRT_CONDITIONS.INVOICE_ROW.Length - 1)
            Dim SRT_KEY As SRT_TABLE_MNT_T_INVOICE_KEY
            With SRT_CONDITIONS.INVOICE_ROW(i)
                SRT_KEY.NUMBER_CONTRACT = .NUMBER_CONTRACT
                SRT_KEY.SERIAL_CONTRACT = .SERIAL_CONTRACT
                SRT_KEY.SERIAL_INVOICE = .SERIAL_INVOICE
            End With

            If Not FUNC_DELETE_TABLE_MNT_T_INVOICE(SRT_KEY) Then
                STR_FUNC_BATCH_MAIN_ERR_STR = FUNC_SYSTEM_SQLGET_ERR_MESSAGE()
                Return False
            End If
        Next

        If Not FUNC_SYSTEM_COMMIT_TRANSACTION() Then
            STR_FUNC_BATCH_MAIN_ERR_STR = FUNC_SYSTEM_SQLGET_ERR_MESSAGE()
            Return False
        End If

        Return True
    End Function
End Module
