Module MOD_PRINT

#Region "帳票用・変数"
    Private STR_FILE_NAME_PRINT_DATA As String 'データファイルの名称
    Private STR_PATH_PRINT_DATA As String 'データファイルのパス
    Friend STR_FUNC_PRINT_MAIN_ERR_STR As String '最終エラー文字列
#End Region

#Region "帳票用・定数"
    Private Const CST_PRINT_DEFINITION As String = "MNT_P_CHECK_DEPOSIT" '定義体名称
    Private Const CST_PRINT_LIST_NAME As String = "入金チェックリスト"
    Private Const CST_PRINT_DATA_FILE_EXTENT As String = ".dat"
#End Region

#Region "帳票用・列挙定数"

#End Region

#Region "帳票用・構造体"
    Public Structure SRT_PRINT_CONDITIONS '印刷条件
        Public DATE_DPOSIT_FROM As DateTime
        Public DATE_DPOSIT_TO As DateTime
        Public DATE_ACTIVE_FROM As DateTime
        Public DATE_ACTIVE_TO As DateTime
        Public SERIAL_DEPOSIT_FROM As Integer
        Public SERIAL_DEPOSIT_TO As Integer
        Public CODE_OWNER_FROM As Integer
        Public CODE_OWNER_TO As Integer
        Public KIND_SORT As ENM_SYSTEM_INDIVIDUAL_KIND_SORT_CHECK_DEPOSIT
    End Structure

    Public Structure SRT_PRINT_DATA '印刷データ
        Public NUMBER_CONTRACT As Integer
        Public SERIAL_CONTRACT As Integer
        Public SERIAL_INVOICE As Integer

        Public DATE_ACTIVE As DateTime
        Public SERIAL_DEPOSIT As Integer
        Public DATE_DEPOSIT As DateTime
        Public KINGAKU_INVOICE_DETAIL As Long
        Public KINGAKU_INVOICE_VAT As Long
        Public FLAG_DEPOSIT As Integer
        Public FLAG_DEPOSIT_SUB As Integer
        Public KINGAKU_FEE_DETAIL As Long
        Public KINGAKU_FEE_VAT As Long
        Public FLAG_COST As Integer
        Public KINGAKU_COST_DETAIL As Long
        Public KINGAKU_COST_VAT As Long
        Public NAME_MEMO As String

        Public DATE_ACTIVE_INT As Integer
        Public DATE_DEPOSIT_INT As Integer
        Public CODE_OWNER As Integer
        Public CODE_OWNER_NAME As String
        Public FLAG_DEPOSIT_NAME As String
        Public FLAG_DEPOSIT_SUB_NAME As String
        Public FLAG_COST_NAME As String

        Public Function KINGAKU_INVOICE_TOTAL() As Long
            Dim LNG_RET As Long
            LNG_RET = Me.KINGAKU_INVOICE_DETAIL + Me.KINGAKU_INVOICE_VAT

            Return LNG_RET
        End Function

        Public Function KINGAKU_FEE_TOTAL() As Long
            Dim LNG_RET As Long
            LNG_RET = Me.KINGAKU_FEE_DETAIL + Me.KINGAKU_FEE_VAT

            Return LNG_RET
        End Function

        Public Function KINGAKU_COST_TOTAL() As Long
            Dim LNG_RET As Long
            LNG_RET = Me.KINGAKU_COST_DETAIL + Me.KINGAKU_COST_VAT

            Return LNG_RET
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
                .NUMBER_CONTRACT = CInt(SDR_READER.Item("NUMBER_CONTRACT"))
                .SERIAL_CONTRACT = CInt(SDR_READER.Item("SERIAL_CONTRACT"))
                .SERIAL_INVOICE = CInt(SDR_READER.Item("SERIAL_INVOICE"))

                .DATE_ACTIVE = CDate(SDR_READER.Item("DATE_ACTIVE"))
                .SERIAL_DEPOSIT = CInt(SDR_READER.Item("SERIAL_DEPOSIT"))
                .DATE_DEPOSIT = CDate(SDR_READER.Item("DATE_DEPOSIT"))
                .KINGAKU_INVOICE_DETAIL = CLng(SDR_READER.Item("KINGAKU_INVOICE_DETAIL"))
                .KINGAKU_INVOICE_VAT = CLng(SDR_READER.Item("KINGAKU_INVOICE_VAT"))
                .FLAG_DEPOSIT = CInt(SDR_READER.Item("FLAG_DEPOSIT"))
                .FLAG_DEPOSIT_SUB = CInt(SDR_READER.Item("FLAG_DEPOSIT_SUB"))
                .KINGAKU_FEE_DETAIL = CLng(SDR_READER.Item("KINGAKU_FEE_DETAIL"))
                .KINGAKU_FEE_VAT = CLng(SDR_READER.Item("KINGAKU_FEE_VAT"))
                .FLAG_COST = CInt(SDR_READER.Item("FLAG_COST"))
                .KINGAKU_COST_DETAIL = CLng(SDR_READER.Item("KINGAKU_COST_DETAIL"))
                .KINGAKU_COST_VAT = CLng(SDR_READER.Item("KINGAKU_COST_VAT"))
                .NAME_MEMO = CStr(SDR_READER.Item("NAME_MEMO"))
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
        If Not FUNC_DIR_MAKE(srtSYSTEM_TOTAL_CONFIG_SETTINGS.LIST.DIR_DATA) Then
            STR_FUNC_PRINT_MAIN_ERR_STR = str_FILE_TOOL_LAST_ERR_STRING
            Return False
        End If
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

        If Not FUNC_DIR_MAKE(srtSYSTEM_TOTAL_CONFIG_SETTINGS.LIST.DIR_ASSETS) Then
            STR_FUNC_PRINT_MAIN_ERR_STR = str_FILE_TOOL_LAST_ERR_STRING
            Return False
        End If
        If Not FUNC_COPY_LIST_DEFINITION_BIP(CST_PRINT_DEFINITION, srtSYSTEM_TOTAL_CONFIG_SETTINGS.LIST.DIR_ASSETS_SERVER, srtSYSTEM_TOTAL_CONFIG_SETTINGS.LIST.DIR_ASSETS) Then
            STR_FUNC_PRINT_MAIN_ERR_STR = CST_SYSTEM_TOTAL_LIST_ERR_MSG_8002 & Environment.NewLine & CST_PRINT_DEFINITION
            Return False
        End If

        If BLN_PREVIEW Then
            If Not FUNC_SHOW_PREVIEW_BIP(srtSYSTEM_TOTAL_CONFIG_SETTINGS.LIST.DIR_BIP_EXE, srtSYSTEM_TOTAL_CONFIG_SETTINGS.LIST.DIR_ASSETS, CST_PRINT_DEFINITION, STR_PATH_PRINT_DATA) Then
                STR_FUNC_PRINT_MAIN_ERR_STR = CST_SYSTEM_TOTAL_LIST_ERR_MSG_8004 & System.Environment.NewLine & str_FILE_TOOL_LAST_ERR_STRING
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
                    STR_FUNC_PRINT_MAIN_ERR_STR = CST_SYSTEM_TOTAL_LIST_ERR_MSG_8003 & System.Environment.NewLine & str_FILE_TOOL_LAST_ERR_STRING
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
            Call .Append("MAIN.*" & "," & System.Environment.NewLine)
            Call .Append("SUB_01.KINGAKU_INVOICE_DETAIL" & "," & System.Environment.NewLine)
            Call .Append("SUB_01.KINGAKU_INVOICE_VAT" & "" & System.Environment.NewLine)

            Call .Append("FROM" & System.Environment.NewLine)
            Call .Append("MNT_T_DEPOSIT AS MAIN WITH(NOLOCK)" & System.Environment.NewLine)

            Call .Append("INNER JOIN" & System.Environment.NewLine)
            Call .Append("MNT_T_INVOICE AS SUB_01 WITH(NOLOCK)" & System.Environment.NewLine)
            Call .Append("ON" & System.Environment.NewLine)
            Call .Append("MAIN.NUMBER_CONTRACT=SUB_01.NUMBER_CONTRACT" & System.Environment.NewLine)
            Call .Append("AND MAIN.SERIAL_CONTRACT=SUB_01.SERIAL_CONTRACT" & System.Environment.NewLine)
            Call .Append("AND MAIN.SERIAL_INVOICE=SUB_01.SERIAL_INVOICE" & System.Environment.NewLine)

            Call .Append("INNER JOIN" & System.Environment.NewLine)
            Call .Append("MNT_T_CONTRACT AS SUB_02 WITH(NOLOCK)" & System.Environment.NewLine)
            Call .Append("ON" & System.Environment.NewLine)
            Call .Append("MAIN.NUMBER_CONTRACT=SUB_02.NUMBER_CONTRACT" & System.Environment.NewLine)
            Call .Append("AND MAIN.SERIAL_CONTRACT=SUB_02.SERIAL_CONTRACT" & System.Environment.NewLine)

            Call .Append("WHERE" & System.Environment.NewLine)
            Call .Append("1 = 1" & System.Environment.NewLine)
            Dim STR_WHERE As String
            STR_WHERE = FUNC_GET_SQL_WHERE(SRT_CONDITIONS)
            Call .Append(STR_WHERE)

            Call .Append("AND NOT(" & Environment.NewLine) '全ての金額関係が0の場合は省く
            Call .Append("SUB_01.KINGAKU_INVOICE_DETAIL=" & 0 & Environment.NewLine)
            Call .Append("AND SUB_01.KINGAKU_INVOICE_VAT=" & 0 & Environment.NewLine)
            Call .Append("AND MAIN.KINGAKU_FEE_DETAIL=" & 0 & Environment.NewLine)
            Call .Append("AND MAIN.KINGAKU_FEE_VAT=" & 0 & Environment.NewLine)
            Call .Append("AND MAIN.KINGAKU_COST_DETAIL=" & 0 & Environment.NewLine)
            Call .Append("AND MAIN.KINGAKU_COST_VAT=" & 0 & Environment.NewLine)
            Call .Append(")" & Environment.NewLine)

            Call .Append("ORDER BY" & Environment.NewLine)
            Select Case SRT_CONDITIONS.KIND_SORT
                Case ENM_SYSTEM_INDIVIDUAL_KIND_SORT_CHECK_DEPOSIT.DATE_ACTIVE
                    Call .Append("MAIN.DATE_ACTIVE,MAIN.SERIAL_DEPOSIT," & System.Environment.NewLine)
                Case ENM_SYSTEM_INDIVIDUAL_KIND_SORT_CHECK_DEPOSIT.DATE_DEPOSIT
                    Call .Append("MAIN.DATE_DEPOSIT,MAIN.DATE_ACTIVE,MAIN.SERIAL_DEPOSIT," & System.Environment.NewLine)
            End Select
            Call .Append("MAIN.NUMBER_CONTRACT,MAIN.SERIAL_CONTRACT,MAIN.SERIAL_INVOICE" & System.Environment.NewLine)
        End With

        Return STR_SQL.ToString
    End Function

    Private Function FUNC_GET_SQL_WHERE(ByRef SRT_CONDITIONS As SRT_PRINT_CONDITIONS)
        Dim STR_WHERE As String
        STR_WHERE = ""

        Dim SRT_DEPOSIT_PERIOD As SRT_DATE_PERIOD
        SRT_DEPOSIT_PERIOD.DATE_FROM = SRT_CONDITIONS.DATE_DPOSIT_FROM
        SRT_DEPOSIT_PERIOD.DATE_TO = SRT_CONDITIONS.DATE_DPOSIT_TO

        Dim SRT_ACTIVE_PERIOD As SRT_DATE_PERIOD
        SRT_ACTIVE_PERIOD.DATE_FROM = SRT_CONDITIONS.DATE_ACTIVE_FROM
        SRT_ACTIVE_PERIOD.DATE_TO = SRT_CONDITIONS.DATE_ACTIVE_TO

        With SRT_CONDITIONS
            STR_WHERE &= FUNC_GET_SQL_WHERE_DATE_FROM_TO(SRT_DEPOSIT_PERIOD, "MAIN.DATE_DEPOSIT")
            STR_WHERE &= FUNC_GET_SQL_WHERE_DATE_FROM_TO(SRT_ACTIVE_PERIOD, "MAIN.DATE_ACTIVE")
            STR_WHERE &= FUNC_GET_SQL_WHERE_INT(SRT_CONDITIONS.SERIAL_DEPOSIT_FROM, "MAIN.SERIAL_DEPOSIT", ">=")
            STR_WHERE &= FUNC_GET_SQL_WHERE_INT(SRT_CONDITIONS.SERIAL_DEPOSIT_TO, "MAIN.SERIAL_DEPOSIT", "<=")
            STR_WHERE &= FUNC_GET_SQL_WHERE_INT(SRT_CONDITIONS.CODE_OWNER_FROM, "SUB_02.CODE_OWNER", ">=")
            STR_WHERE &= FUNC_GET_SQL_WHERE_INT(SRT_CONDITIONS.CODE_OWNER_TO, "SUB_02.CODE_OWNER", "<=")
        End With

        Return STR_WHERE
    End Function

    '補助情報の取得
    Private Sub SUB_REPLACE_DATA(ByRef SRT_DATA As SRT_PRINT_DATA)
        With SRT_DATA
            .CODE_OWNER = FUNC_GET_CODE_OWNER_FROM_COTRACT(.NUMBER_CONTRACT, .SERIAL_CONTRACT)
            .CODE_OWNER_NAME = FUNC_GET_NAME_OWNER_FROM_COTRACT(.NUMBER_CONTRACT, .SERIAL_CONTRACT)

            .DATE_ACTIVE_INT = FUNC_CONVERT_DATETIME_TO_NUMERIC_DATE(.DATE_ACTIVE)
            .DATE_DEPOSIT_INT = FUNC_CONVERT_DATETIME_TO_NUMERIC_DATE(.DATE_DEPOSIT)

            .FLAG_DEPOSIT_NAME = FUNC_GET_MNT_M_ACCOUNT_NAME_ACCOUNT(ENM_SYSTEM_INDIVIDUAL_FLAG_ACCOUNT.FLAG_DEPOSIT, .FLAG_DEPOSIT)
            .FLAG_DEPOSIT_SUB_NAME = FUNC_GET_MNT_M_ACCOUNT_NAME_ACCOUNT(ENM_SYSTEM_INDIVIDUAL_FLAG_ACCOUNT.KIND_PAYEE, .FLAG_DEPOSIT_SUB)
            If .FLAG_COST <= 0 Then
                .FLAG_COST_NAME = ""
            Else
                .FLAG_COST_NAME = FUNC_GET_MNT_M_ACCOUNT_NAME_ACCOUNT(ENM_SYSTEM_INDIVIDUAL_FLAG_ACCOUNT.FLAG_COST, .FLAG_COST)
            End If
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
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.NUMBER_CONTRACT))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.SERIAL_CONTRACT))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.SERIAL_INVOICE))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.DATE_ACTIVE_INT))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.SERIAL_DEPOSIT))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.DATE_DEPOSIT_INT))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.CODE_OWNER))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.CODE_OWNER_NAME))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.KINGAKU_INVOICE_DETAIL))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.KINGAKU_INVOICE_VAT))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.KINGAKU_INVOICE_TOTAL))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.FLAG_DEPOSIT))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.FLAG_DEPOSIT_NAME))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.FLAG_DEPOSIT_SUB))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.FLAG_DEPOSIT_SUB_NAME))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.KINGAKU_FEE_DETAIL))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.KINGAKU_FEE_VAT))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.KINGAKU_FEE_TOTAL))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.FLAG_COST))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.FLAG_COST_NAME))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.KINGAKU_COST_DETAIL))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.KINGAKU_COST_VAT))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.KINGAKU_COST_TOTAL))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.NAME_MEMO))
        End With
        STR_RET = FUNC_GET_ONE_ROW_LIST_CSV(STR_ROW)

        Return STR_RET
    End Function
End Module
