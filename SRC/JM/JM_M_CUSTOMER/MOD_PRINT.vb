Module MOD_PRINT


#Region "帳票用・変数"
    Private STR_FILE_NAME_PRINT_DATA As String 'データファイルの名称
    Private STR_PATH_PRINT_DATA As String 'データファイルのパス
    Friend STR_FUNC_PRINT_MAIN_ERR_STR As String '最終エラー文字列
#End Region

#Region "帳票用・定数"
    Private Const CST_PRINT_DEFINITION As String = "MNT_M_OWNER" '定義体名称
    Private Const CST_PRINT_LIST_NAME As String = "オーナーマスタリスト"
    Private Const CST_PRINT_DATA_FILE_EXTENT As String = ".dat"
#End Region

#Region "帳票用・列挙定数"

#End Region

#Region "帳票用・構造体"
    Public Structure SRT_PRINT_CONDITIONS '印刷条件
        '条件なし
    End Structure

    Public Structure SRT_PRINT_DATA '印刷データ
        Public CODE_OWNER As Integer
        Public NAME_OWNER As String
        Public KANA_OWNER As String
        Public FLAG_OWNER As Integer
        Public CODE_POST As Integer
        Public NAME_ADDRESS_01 As String
        Public NAME_ADDRESS_02 As String
        Public FLAG_INVOICE_FIXDAY As Integer
        Public FLAG_INVALID As Integer

        Public FLAG_OWNER_NAME As String
        Public CODE_POST_VIEW As String
        Public FLAG_INVOICE_FIXDAY_NAME As String
        Public FLAG_INVALID_NAME As String
    End Structure
#End Region

    Public Function FUNC_PRINT_MAIN(
    ByRef BLN_PUT As Boolean,
    ByRef BLN_CANCEL As Boolean,
    ByRef SRT_CONDITIONS As SRT_PRINT_CONDITIONS,
    ByVal BLN_PREVIEW As Boolean,
    ByVal BLN_PUT_FILE As Boolean
    ) As Boolean
        Return True
    End Function
End Module
