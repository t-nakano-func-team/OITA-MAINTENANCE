Module MOD_PRINT
#Region "帳票用・変数"
    Private STR_FILE_NAME_PRINT_DATA As String 'データファイルの名称
    Private STR_PATH_PRINT_DATA As String 'データファイルのパス
    Friend STR_FUNC_PRINT_MAIN_ERR_STR As String '最終エラー文字列
#End Region

#Region "帳票用・定数"
    Private Const CST_PRINT_DEFINITION As String = "SNT_M_USER" '定義体名称
    Private Const CST_PRINT_LIST_NAME As String = "ユーザーマスタリスト"
    Private Const CST_PRINT_DATA_FILE_EXTENT As String = ".dat"
#End Region

#Region "帳票用・列挙定数"

#End Region

#Region "帳票用・構造体"
    Public Structure SRT_PRINT_CONDITIONS '印刷条件
        '条件なし
    End Structure

    Public Structure SRT_PRINT_DATA '印刷データ
        Public CODE_STAFF As Integer
        Public NAME_STAFF As String
        Public USER_ID As String
        Public PASS_WORD As String
        Public FLAG_GRANT As Integer

        Public FLAG_GRANT_NAME As String
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

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL(SRT_CONDITIONS)

        Dim SDR_READER As SqlClient.SqlDataReader
        SDR_READER = Nothing
        If Not FUNC_SYSTEM_GET_SQL_DATA_READER(STR_SQL.ToString, SDR_READER) Then
            STR_FUNC_PRINT_MAIN_ERR_STR = str_SQL_TOOL_LAST_ERR_STRING
            Return False
        End If

        If Not SDR_READER.HasRows Then
            Call SDR_READER.Close()
            SDR_READER = Nothing
            Return True 'データなし正常終了
        End If

        BLN_PUT = True

        Dim SRT_DATA() As SRT_PRINT_DATA
        ReDim SRT_DATA(0)
        While SDR_READER.Read
            Dim INT_INDEX As Integer
            INT_INDEX = (SRT_DATA.Length)
            ReDim Preserve SRT_DATA(INT_INDEX)
            With SRT_DATA(INT_INDEX)
                .CODE_STAFF = CInt(SDR_READER.Item("CODE_STAFF"))
                .NAME_STAFF = CStr(SDR_READER.Item("NAME_STAFF"))
                .USER_ID = CStr(SDR_READER.Item("USER_ID"))
                .PASS_WORD = CStr(SDR_READER.Item("PASS_WORD"))
                .FLAG_GRANT = CInt(SDR_READER.Item("FLAG_GRANT"))

                .FLAG_GRANT_NAME = ""
            End With
        End While

        Call SDR_READER.Close()
        SDR_READER = Nothing

        For i = 1 To (SRT_DATA.Length - 1)
            Call SUB_REPLACE_DATA(SRT_DATA(i))
        Next

        Dim STW_CSV_WRITER As System.IO.StreamWriter 'ファイル出力用のIOオブジェクト
        Dim STR_ONE_ROW As String

        STR_FILE_NAME_PRINT_DATA = CST_PRINT_DEFINITION & CST_PRINT_DATA_FILE_EXTENT
        STR_PATH_PRINT_DATA = srtSYSTEM_TOTAL_CONFIG_SETTINGS.LIST.DIR_DATA & "\" & STR_FILE_NAME_PRINT_DATA

        Try
            STW_CSV_WRITER = New System.IO.StreamWriter(STR_PATH_PRINT_DATA, False, System.Text.Encoding.Default)   'ファイルライターを開く
        Catch ex As Exception
            STR_FUNC_PRINT_MAIN_ERR_STR = CST_SYSTEM_TOTAL_LIST_ERR_MSG_8001 & Environment.NewLine & STR_PATH_PRINT_DATA
            Return False
        End Try

        For intLOOP_INDEX = 1 To (SRT_DATA.Length - 1)
            STR_ONE_ROW = FUNC_GET_ONE_ROW(SRT_CONDITIONS, SRT_DATA(intLOOP_INDEX)) '1行分の情報を作成
            STW_CSV_WRITER.WriteLine(STR_ONE_ROW) 'CSVﾌｧｲﾙ書き込み
        Next

        Call STW_CSV_WRITER.Close() 'ファイルライターを閉じる

        If Not FUNC_COPY_LIST_DEFINITION_BIP(CST_PRINT_DEFINITION, srtSYSTEM_TOTAL_CONFIG_SETTINGS.LIST.DIR_ASSETS_SERVER, srtSYSTEM_TOTAL_CONFIG_SETTINGS.LIST.DIR_ASSETS) Then
            STR_FUNC_PRINT_MAIN_ERR_STR = CST_SYSTEM_TOTAL_LIST_ERR_MSG_8002 & Environment.NewLine & CST_PRINT_DEFINITION
            Return False
        End If

        If BLN_PREVIEW Then
            If Not FUNC_SHOW_PREVIEW_BIP(srtSYSTEM_TOTAL_CONFIG_SETTINGS.LIST.DIR_BIP_EXE, srtSYSTEM_TOTAL_CONFIG_SETTINGS.LIST.DIR_ASSETS, CST_PRINT_DEFINITION, STR_PATH_PRINT_DATA) Then
                STR_FUNC_PRINT_MAIN_ERR_STR = CST_SYSTEM_TOTAL_LIST_ERR_MSG_8004
                Return False
            End If
        Else
            If BLN_PUT_FILE Then
                Dim STR_FILE_PATH As String
                STR_FILE_PATH = ""
                If Not FUNC_SHOW_PUT_FILE_DIALOG(STR_FILE_PATH, CST_PRINT_LIST_NAME) Then
                    BLN_CANCEL = True
                    Return True 'ファイル出力なし正常終了
                End If
                If Not FUNC_PUT_FILE_BIP(srtSYSTEM_TOTAL_CONFIG_SETTINGS.LIST.DIR_BIP_EXE, srtSYSTEM_TOTAL_CONFIG_SETTINGS.LIST.DIR_ASSETS, CST_PRINT_DEFINITION, STR_PATH_PRINT_DATA, STR_FILE_PATH) Then
                    STR_FUNC_PRINT_MAIN_ERR_STR = CST_SYSTEM_TOTAL_LIST_ERR_MSG_8005
                    Return False
                End If
            Else
                If Not FUNC_PUT_LIST_BIP(srtSYSTEM_TOTAL_CONFIG_SETTINGS.LIST.DIR_BIP_EXE, srtSYSTEM_TOTAL_CONFIG_SETTINGS.LIST.DIR_ASSETS, CST_PRINT_DEFINITION, STR_PATH_PRINT_DATA) Then
                    STR_FUNC_PRINT_MAIN_ERR_STR = CST_SYSTEM_TOTAL_LIST_ERR_MSG_8003
                    Return False
                End If
            End If
        End If

        Return True
    End Function

    Private Function FUNC_GET_SQL(ByRef SRT_CONDITIONS As SRT_PRINT_CONDITIONS) As String
        Dim STR_SQL As System.Text.StringBuilder

        STR_SQL = New System.Text.StringBuilder
        With STR_SQL
            Call .Append("SELECT" & System.Environment.NewLine)
            Call .Append("*" & System.Environment.NewLine)
            Call .Append("FROM" & System.Environment.NewLine)
            Call .Append(strSYSTEM_PUBLIC_MNGDB_PREFIX & "MNG_M_USER WITH(NOLOCK)" & System.Environment.NewLine)
            Call .Append("WHERE" & System.Environment.NewLine)
            Call .Append("1 = 1" & System.Environment.NewLine)
            Call .Append("ORDER BY" & Environment.NewLine)
            Call .Append("CODE_STAFF" & System.Environment.NewLine)
        End With

        Return STR_SQL.ToString
    End Function

    '補助情報の取得
    Private Sub SUB_REPLACE_DATA(ByRef SRT_DATA As SRT_PRINT_DATA)
        With SRT_DATA
            .FLAG_GRANT_NAME = FUNC_GET_MNG_M_KIND_NAME_KIND(ENM_MNG_M_KIND_CODE_FLAG.FLAG_GRANT, .FLAG_GRANT)
        End With
    End Sub

    'CSV1行の文字列を取得
    Private Function FUNC_GET_ONE_ROW(
    ByRef SRT_CONDITIONS As SRT_PRINT_CONDITIONS,
    ByRef SRT_DATA As SRT_PRINT_DATA
    ) As String
        Dim STR_RET As String
        Dim STR_ROW() As String

        ReDim STR_ROW(0)
        With SRT_DATA
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.CODE_STAFF))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.NAME_STAFF))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.USER_ID))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.PASS_WORD))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.FLAG_GRANT))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.FLAG_GRANT_NAME))
        End With
        STR_RET = FUNC_GET_ONE_ROW_LIST_CSV(STR_ROW)

        Return STR_RET
    End Function
End Module
