Module MOD_PRINT

#Region "帳票用・変数"
    Private STR_FILE_NAME_PRINT_DATA As String 'データファイルの名称
    Private STR_PATH_PRINT_DATA As String 'データファイルのパス
    Friend STR_FUNC_PRINT_MAIN_ERR_STR As String '最終エラー文字列
#End Region

#Region "帳票用・定数"
    Private Const CST_PRINT_DEFINITION As String = "MNT_P_PLAN_INVOICE" '定義体名称
    Private Const CST_PRINT_LIST_NAME As String = "請求予定一覧表"
    Private Const CST_PRINT_DATA_FILE_EXTENT As String = ".dat"
#End Region

#Region "帳票用・列挙定数"

#End Region

#Region "帳票用・構造体"
    Public Structure SRT_PRINT_CONDITIONS '印刷条件
        Public DATE_INVOICE_FROM As DateTime
        Public DATE_INVOICE_TO As DateTime
        Public KIND_CONTRACT As Integer
        Public CODE_OWNER_FROM As Integer
        Public CODE_OWNER_TO As Integer

    End Structure

    Public Structure SRT_PRINT_DATA '印刷データ
        Public NUMBER_CONTRACT As Integer
        Public SERIAL_CONTRACT As Integer

        Public KIND_CONTRACT As Integer
        Public DATE_CONTRACT As DateTime
        Public CODE_OWNER As Integer
        Public CODE_SECTION As Integer
        Public CODE_WORK As Integer
        Public NAME_CONTRACT As String
        Public DATE_WORK_FROM As DateTime
        Public DATE_WORK_TO As DateTime
        Public DATE_INVOICE_BASE As DateTime
        Public SPAN_INVOICE As Integer
        Public COUNT_INVOICE As Integer
        Public NUMBER_LIST_INVOICE As Integer
        Public KINGAKU_CONTRACT As Long
        Public NAME_MEMO As String

        Public KIND_CONTRACT_NAME As String
        Public DATE_CONTRACT_INT As Integer
        Public CODE_OWNER_NAME As String
        Public CODE_SECTION_NAME As String
        Public CODE_WORK_NAME As String
        Public DATE_WORK_FROM_INT As Integer
        Public DATE_WORK_TO_INT As Integer
        Public DATE_INVOICE_BASE_INT As Integer

        Public Function NUMBER_CONTRACT_PRINT() As String
            Dim STR_NUMBER_CONTRACT As String
            STR_NUMBER_CONTRACT = Format(Me.NUMBER_CONTRACT, New String("0", INT_SYSTEM_NUMBER_CONTRACT_MAX_LENGTH))

            Dim STR_SERIAL_CONTRACT As String
            STR_SERIAL_CONTRACT = Format(Me.SERIAL_CONTRACT, New String("0", INT_SYSTEM_SERIAL_CONTRACT_MAX_LENGTH))

            Dim STR_RET As String
            STR_RET = ""
            STR_RET &= STR_NUMBER_CONTRACT
            STR_RET &= "-"
            STR_RET &= STR_SERIAL_CONTRACT

            Return STR_RET
        End Function
    End Structure
#End Region

    '印刷処理
    Public Function FUNC_PRINT_MAIN(
    ByRef BLN_PUT As Boolean,
    ByRef BLN_CANCEL As Boolean,
    ByRef SRT_CONDITIONS As SRT_PRINT_CONDITIONS,
    ByVal BLN_PREVIEW As Boolean,
    ByVal BLN_PUT_FILE As Boolean
    ) As Boolean
        '初期化
        STR_FUNC_PRINT_MAIN_ERR_STR = ""
        BLN_PUT = False
        BLN_CANCEL = False

        Return True
    End Function
End Module
