Module MOD_PRINT

#Region "帳票用・変数"
    Private STR_FILE_NAME_PRINT_DATA As String 'データファイルの名称
    Private STR_PATH_PRINT_DATA As String 'データファイルのパス
    Friend STR_FUNC_PRINT_MAIN_ERR_STR As String '最終エラー文字列
#End Region

#Region "帳票用・定数"
    Private Const CST_PRINT_DEFINITION As String = "MNT_P_LEDGER_RECEIVABLE" '定義体名称
    Private Const CST_PRINT_LIST_NAME As String = "未収金台帳"
    Private Const CST_PRINT_DATA_FILE_EXTENT As String = ".dat"
#End Region

#Region "帳票用・列挙定数"

#End Region

#Region "帳票用・構造体"
    Public Structure SRT_PRINT_CONDITIONS '印刷条件
        Public DATE_CONTRACT_FROM As DateTime
        Public DATE_CONTRACT_TO As DateTime
        Public CODE_SECTION As Integer
        Public FLAG_CONTRACT As Integer
        Public CODE_OWNER_FROM As Integer
        Public CODE_OWNER_TO As Integer
        Public DATE_CALC_FROM As DateTime
        Public DATE_CALC_TO As DateTime
        Public CODE_MAINTENANCE_FROM As Integer
        Public CODE_MAINTENANCE_TO As Integer
        Public KIND_TARGET_RECEIVABLE As Integer
    End Structure

    Public Structure SRT_PRINT_DATA '印刷データ
        Public CODE_SECTION As Integer
        Public FLAG_CONTRACT As Integer
        Public CODE_OWNER As Integer
        Public NUMBER_CONTRACT As Integer
        Public SERIAL_CONTRACT As Integer
        Public NAME_CONTRACT As String
        Public DATE_CONTRACT As DateTime
        Public FLAG_INVOICE_METHOD As Integer
        Public COUNT_INVOICE As Integer
        Public KINGAKU_CONTRACT As Long

        Public KINGAKU_INVOICE_BEFORE As Long
        Public KINGAKU_INVOICE_CURRENT As Long
        Public KINGAKU_INVOICE_PROSPECT_TOTAL As Long
        Public KINGAKU_INVOICE_TOTAL As Long
        Public KINGAKU_DEPOSIT_TOTAL As Long
        Public KINGAKU_RECEIVABLE As Long

        Public CODE_SECTION_NAME As String
        Public FLAG_CONTRACT_NAME As String
        Public CODE_OWNER_NAME As String
        Public DATE_CONTRACT_INT As Integer
        Public FLAG_INVOICE_METHOD_NAME As String
        Public NUMBER_BREAK As Integer

        Public Function NUMBER_CONTRACT_VEIW() As String
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
                .CODE_SECTION = CInt(SDR_READER.Item("CODE_SECTION"))
                .FLAG_CONTRACT = CInt(SDR_READER.Item("FLAG_CONTRACT"))
                .NUMBER_CONTRACT = CInt(SDR_READER.Item("NUMBER_CONTRACT"))
                .SERIAL_CONTRACT = CInt(SDR_READER.Item("SERIAL_CONTRACT"))
                .CODE_OWNER = CInt(SDR_READER.Item("CODE_OWNER"))
                .NAME_CONTRACT = CStr(SDR_READER.Item("NAME_CONTRACT"))
                .DATE_CONTRACT = CDate(SDR_READER.Item("DATE_CONTRACT"))
                .FLAG_INVOICE_METHOD = CInt(SDR_READER.Item("FLAG_INVOICE_METHOD"))
                .COUNT_INVOICE = CInt(SDR_READER.Item("COUNT_INVOICE"))
                .KINGAKU_CONTRACT = CLng(SDR_READER.Item("KINGAKU_CONTRACT"))
                .KINGAKU_INVOICE_TOTAL = CLng(SDR_READER.Item("KINGAKU_INVOICE_TOTAL"))
                .KINGAKU_DEPOSIT_TOTAL = CLng(SDR_READER.Item("KINGAKU_DEPOSIT_TOTAL"))
            End With
        End While

        Call SDR_READER.Close()
        SDR_READER = Nothing

        Dim INT_CODE_SECTION_BEFORE As Integer
        INT_CODE_SECTION_BEFORE = -1
        Dim INT_FLAG_CONTRACT_BEFORE As Integer
        INT_FLAG_CONTRACT_BEFORE = -1

        Dim INT_NUMBER_BREAK As Integer
        INT_NUMBER_BREAK = 0
        For i = 1 To (SRT_DATA.Length - 1)
            If (INT_CODE_SECTION_BEFORE <> SRT_DATA(i).CODE_SECTION) _
                Or (INT_FLAG_CONTRACT_BEFORE <> SRT_DATA(i).FLAG_CONTRACT) Then
                INT_NUMBER_BREAK += 1
            End If
            Call SUB_REPLACE_DATA(SRT_CONDITIONS, SRT_DATA(i), INT_NUMBER_BREAK)

            INT_CODE_SECTION_BEFORE = SRT_DATA(i).CODE_SECTION
            INT_FLAG_CONTRACT_BEFORE = SRT_DATA(i).FLAG_CONTRACT
        Next

        STR_FILE_NAME_PRINT_DATA = CST_PRINT_DEFINITION & CST_PRINT_DATA_FILE_EXTENT
        If Not FUNC_DIR_MAKE(srtSYSTEM_TOTAL_CONFIG_SETTINGS.LIST.DIR_DATA) Then
            STR_FUNC_PRINT_MAIN_ERR_STR = str_FILE_TOOL_LAST_ERR_STRING
            Return False
        End If
        STR_PATH_PRINT_DATA = srtSYSTEM_TOTAL_CONFIG_SETTINGS.LIST.DIR_DATA & "\" & STR_FILE_NAME_PRINT_DATA

        Dim STW_CSV_WRITER As System.IO.StreamWriter 'ファイル出力用のIOオブジェクト

        Try
            STW_CSV_WRITER = New System.IO.StreamWriter(STR_PATH_PRINT_DATA, False, System.Text.Encoding.Default)   'ファイルライターを開く
        Catch ex As Exception
            STR_FUNC_PRINT_MAIN_ERR_STR = CST_SYSTEM_TOTAL_LIST_ERR_MSG_8001 & Environment.NewLine & STR_PATH_PRINT_DATA
            Return False
        End Try

        Dim STR_ONE_ROW As String
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
            Call .Append("SUB_01.CODE_OWNER" & "," & System.Environment.NewLine)
            Call .Append("SUB_01.CODE_MAINTENANCE" & "," & System.Environment.NewLine)
            Call .Append("SUB_01.FLAG_CONTRACT" & "," & System.Environment.NewLine)
            Call .Append("SUB_01.DATE_CONTRACT" & "," & System.Environment.NewLine)
            Call .Append("SUB_01.NAME_CONTRACT" & "," & System.Environment.NewLine)
            Call .Append("SUB_01.FLAG_INVOICE_METHOD" & "," & System.Environment.NewLine)
            Call .Append("SUB_01.COUNT_INVOICE" & "," & System.Environment.NewLine)
            Call .Append("SUB_01.KINGAKU_CONTRACT" & "," & System.Environment.NewLine)
            Call .Append("SUB_01.NAME_MEMO" & "" & System.Environment.NewLine)

            Call .Append("FROM" & System.Environment.NewLine)

            Call .Append("(" & System.Environment.NewLine)
            Call .Append("SELECT" & System.Environment.NewLine)
            Call .Append("CODE_SECTION" & "," & System.Environment.NewLine)
            Call .Append("NUMBER_CONTRACT" & "," & System.Environment.NewLine)
            Call .Append("SERIAL_CONTRACT" & "," & System.Environment.NewLine)
            Call .Append("SUM(KINGAKU_INVOICE_DETAIL + KINGAKU_INVOICE_VAT) AS KINGAKU_INVOICE_TOTAL" & "," & System.Environment.NewLine)
            Call .Append("SUM((KINGAKU_INVOICE_DETAIL + KINGAKU_INVOICE_VAT)*RATE_DEPOSIT) AS KINGAKU_DEPOSIT_TOTAL" & "" & System.Environment.NewLine)
            Call .Append("FROM" & System.Environment.NewLine)

            Call .Append("(" & System.Environment.NewLine)
            Call .Append("SELECT" & System.Environment.NewLine)
            Call .Append("MAIN.*" & "," & System.Environment.NewLine)
            Call .Append("IIF(SUB_01.NUMBER_CONTRACT Is NULL, 0, 1) As RATE_DEPOSIT" & "" & System.Environment.NewLine)
            Call .Append("FROM" & System.Environment.NewLine)
            Call .Append("MNT_T_INVOICE AS MAIN WITH(NOLOCK)" & System.Environment.NewLine)
            Call .Append("LEFT JOIN" & System.Environment.NewLine)
            Call .Append("MNT_T_DEPOSIT AS SUB_01 WITH(NOLOCK)" & System.Environment.NewLine)
            Call .Append("ON" & System.Environment.NewLine)
            Call .Append("MAIN.NUMBER_CONTRACT=SUB_01.NUMBER_CONTRACT" & System.Environment.NewLine)
            Call .Append("AND MAIN.SERIAL_CONTRACT=SUB_01.SERIAL_CONTRACT" & System.Environment.NewLine)
            Call .Append("AND MAIN.SERIAL_INVOICE=SUB_01.SERIAL_INVOICE" & System.Environment.NewLine)
            Call .Append(") AS MAIN" & System.Environment.NewLine)

            Call .Append("GROUP BY" & System.Environment.NewLine)
            Call .Append("CODE_SECTION,NUMBER_CONTRACT,SERIAL_CONTRACT" & System.Environment.NewLine)
            Call .Append(") AS MAIN" & System.Environment.NewLine)

            Call .Append("INNER JOIN" & System.Environment.NewLine)
            Call .Append("MNT_T_CONTRACT AS SUB_01 WITH(NOLOCK)" & System.Environment.NewLine)
            Call .Append("ON" & System.Environment.NewLine)
            Call .Append("MAIN.NUMBER_CONTRACT=SUB_01.NUMBER_CONTRACT" & System.Environment.NewLine)
            Call .Append("AND MAIN.SERIAL_CONTRACT=SUB_01.SERIAL_CONTRACT" & System.Environment.NewLine)

            Call .Append("INNER JOIN" & System.Environment.NewLine)
            Call .Append("(" & System.Environment.NewLine)
            Call .Append("SELECT" & System.Environment.NewLine)
            Call .Append("NUMBER_CONTRACT" & "," & System.Environment.NewLine)
            Call .Append("SERIAL_CONTRACT" & "" & System.Environment.NewLine)
            Call .Append("FROM" & System.Environment.NewLine)
            Call .Append("MNT_T_INVOICE WITH(NOLOCK)" & System.Environment.NewLine)
            Call .Append("WHERE" & System.Environment.NewLine)
            Call .Append("1=1" & System.Environment.NewLine)
            Dim SRT_CALC_PERIOD As SRT_DATE_PERIOD
            SRT_CALC_PERIOD.DATE_FROM = SRT_CONDITIONS.DATE_CALC_FROM
            SRT_CALC_PERIOD.DATE_TO = SRT_CONDITIONS.DATE_CALC_TO
            Call .Append(FUNC_GET_SQL_WHERE_DATE_FROM_TO(SRT_CALC_PERIOD, "DATE_INVOICE"))
            Call .Append("GROUP BY" & System.Environment.NewLine)
            Call .Append("NUMBER_CONTRACT,SERIAL_CONTRACT" & System.Environment.NewLine)
            Call .Append(") AS SUB_02" & System.Environment.NewLine)
            Call .Append("ON" & System.Environment.NewLine)
            Call .Append("MAIN.NUMBER_CONTRACT=SUB_02.NUMBER_CONTRACT" & System.Environment.NewLine)
            Call .Append("AND MAIN.SERIAL_CONTRACT=SUB_02.SERIAL_CONTRACT" & System.Environment.NewLine)

            Call .Append("WHERE" & System.Environment.NewLine)
            Call .Append("1 = 1" & System.Environment.NewLine)
            Dim STR_WHERE As String
            STR_WHERE = FUNC_GET_SQL_WHERE(SRT_CONDITIONS)
            Call .Append(STR_WHERE)
            Call .Append("ORDER BY" & Environment.NewLine)
            Call .Append("MAIN.CODE_SECTION,SUB_01.FLAG_CONTRACT,SUB_01.CODE_OWNER,MAIN.NUMBER_CONTRACT,MAIN.SERIAL_CONTRACT" & System.Environment.NewLine)
        End With

        Return STR_SQL.ToString
    End Function

    Private Function FUNC_GET_SQL_WHERE(ByRef SRT_CONDITIONS As SRT_PRINT_CONDITIONS)
        Dim STR_WHERE As String
        STR_WHERE = ""

        Dim SRT_CONTRACT_PERIOD As SRT_DATE_PERIOD
        SRT_CONTRACT_PERIOD.DATE_FROM = SRT_CONDITIONS.DATE_CONTRACT_FROM
        SRT_CONTRACT_PERIOD.DATE_TO = SRT_CONDITIONS.DATE_CONTRACT_TO

        With SRT_CONDITIONS
            If .FLAG_CONTRACT > 0 Then
                STR_WHERE &= FUNC_GET_SQL_WHERE_INT(SRT_CONDITIONS.FLAG_CONTRACT, "SUB_01.FLAG_CONTRACT", "=")
            End If
            STR_WHERE &= FUNC_GET_SQL_WHERE_DATE_FROM_TO(SRT_CONTRACT_PERIOD, "SUB_01.DATE_CONTRACT")
            STR_WHERE &= FUNC_GET_SQL_WHERE_INT(SRT_CONDITIONS.CODE_OWNER_FROM, "SUB_01.CODE_OWNER", ">=")
            STR_WHERE &= FUNC_GET_SQL_WHERE_INT(SRT_CONDITIONS.CODE_OWNER_TO, "SUB_01.CODE_OWNER", "<=")
            If .CODE_SECTION >= 0 Then
                STR_WHERE &= FUNC_GET_SQL_WHERE_INT(SRT_CONDITIONS.CODE_SECTION, "MAIN.CODE_SECTION", "=")
            End If
            STR_WHERE &= FUNC_GET_SQL_WHERE_INT(SRT_CONDITIONS.CODE_MAINTENANCE_FROM, "SUB_01.CODE_MAINTENANCE", ">=")
            STR_WHERE &= FUNC_GET_SQL_WHERE_INT(SRT_CONDITIONS.CODE_MAINTENANCE_TO, "SUB_01.CODE_MAINTENANCE", "<=")
            Select Case .KIND_TARGET_RECEIVABLE
                Case ENM_SYSTEM_INDIVIDUAL_KIND_TARGET_RECEIVABLE.BALANCE_HAVE
                    STR_WHERE &= FUNC_GET_SQL_WHERE_INT(0, "(MAIN.KINGAKU_INVOICE_TOTAL-MAIN.KINGAKU_DEPOSIT_TOTAL)", "<>")
                Case ENM_SYSTEM_INDIVIDUAL_KIND_TARGET_RECEIVABLE.BALANCE_NONE
                    STR_WHERE &= FUNC_GET_SQL_WHERE_INT(0, "(MAIN.KINGAKU_INVOICE_TOTAL-MAIN.KINGAKU_DEPOSIT_TOTAL)", "=")
                Case Else
                    'スルー
            End Select
        End With

        Return STR_WHERE
    End Function

    '補助情報の取得
    Private Sub SUB_REPLACE_DATA(ByRef SRT_CONDITIONS As SRT_PRINT_CONDITIONS, ByRef SRT_DATA As SRT_PRINT_DATA, ByVal INT_NUMBER_BREAK As Integer)
        With SRT_DATA
            .NUMBER_BREAK = INT_NUMBER_BREAK

            .CODE_SECTION_NAME = FUNC_GET_MNT_M_SECTION_NAME_SECTION(.CODE_SECTION)
            .FLAG_CONTRACT_NAME = FUNC_GET_MNT_M_KIND_NAME_KIND(ENM_MNT_M_KIND_CODE_FLAG.FLAG_CONTRACT, .FLAG_CONTRACT)
            .CODE_OWNER_NAME = FUNC_GET_NAME_OWNER_FROM_COTRACT(.NUMBER_CONTRACT, .SERIAL_CONTRACT)
            .DATE_CONTRACT_INT = FUNC_CONVERT_DATETIME_TO_NUMERIC_DATE(.DATE_CONTRACT)

            .FLAG_INVOICE_METHOD_NAME = FUNC_GET_MNT_M_KIND_NAME_KIND(ENM_MNT_M_KIND_CODE_FLAG.FLAG_INVOICE_METHOD, .FLAG_INVOICE_METHOD, True)

            Dim LNG_KINGAKU_CONTRACT_VAT As Long
            LNG_KINGAKU_CONTRACT_VAT = FUNC_GET_KINGAKU_VAT_FROM_DETAIL(.KINGAKU_CONTRACT, .DATE_CONTRACT)
            Dim LNG_KINGA_CONTRACT_TOTAL As Long
            LNG_KINGA_CONTRACT_TOTAL = .KINGAKU_CONTRACT + LNG_KINGAKU_CONTRACT_VAT
            .KINGAKU_INVOICE_PROSPECT_TOTAL = CLng(LNG_KINGA_CONTRACT_TOTAL * .COUNT_INVOICE)

            Dim DAT_DATE_CALC_BEFORE_TO As DateTime
            DAT_DATE_CALC_BEFORE_TO = SRT_CONDITIONS.DATE_CALC_FROM.AddDays(-1)
            Dim DAT_DATE_CALC_BEFORE_FROM As DateTime
            DAT_DATE_CALC_BEFORE_FROM = FUNC_GET_DATE_FIRSMONTH(DAT_DATE_CALC_BEFORE_TO)

            Dim INT_SERIAL_INVOICE_BEFORE As Integer
            INT_SERIAL_INVOICE_BEFORE = FUNC_GET_INVOICE_DATE_INVOICE_BEFORE(.NUMBER_CONTRACT, .SERIAL_CONTRACT, DAT_DATE_CALC_BEFORE_TO)
            If INT_SERIAL_INVOICE_BEFORE > 0 Then
                Dim SRT_INVOICE As SRT_TABLE_MNT_T_INVOICE
                SRT_INVOICE.KEY.NUMBER_CONTRACT = .NUMBER_CONTRACT
                SRT_INVOICE.KEY.SERIAL_CONTRACT = .SERIAL_CONTRACT
                SRT_INVOICE.KEY.SERIAL_INVOICE = INT_SERIAL_INVOICE_BEFORE
                SRT_INVOICE.DATA = Nothing
                Call FUNC_SELECT_TABLE_MNT_T_INVOICE(SRT_INVOICE.KEY, SRT_INVOICE.DATA)
                .KINGAKU_INVOICE_BEFORE = SRT_INVOICE.DATA.KINGAKU_INVOICE_DETAIL + SRT_INVOICE.DATA.KINGAKU_INVOICE_VAT
            Else
                .KINGAKU_INVOICE_BEFORE = FUNC_GET_KINGAKU_INVOICE_FROM_DATE_FROM_TO(.NUMBER_CONTRACT, .SERIAL_CONTRACT, DAT_DATE_CALC_BEFORE_FROM, DAT_DATE_CALC_BEFORE_TO)
            End If
            .KINGAKU_INVOICE_CURRENT = FUNC_GET_KINGAKU_INVOICE_FROM_DATE_FROM_TO(.NUMBER_CONTRACT, .SERIAL_CONTRACT, SRT_CONDITIONS.DATE_CALC_FROM, SRT_CONDITIONS.DATE_CALC_TO)
            .KINGAKU_RECEIVABLE = .KINGAKU_INVOICE_TOTAL - .KINGAKU_DEPOSIT_TOTAL
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
        With SRT_CONDITIONS
            Dim INT_DATE_CALC_FROM As Integer
            INT_DATE_CALC_FROM = FUNC_CONVERT_DATETIME_TO_NUMERIC_DATE(.DATE_CALC_FROM)
            Dim INT_DATE_CALC_TO As Integer
            INT_DATE_CALC_TO = FUNC_CONVERT_DATETIME_TO_NUMERIC_DATE(.DATE_CALC_TO)

            Call SUB_ADD_STR_ROW(STR_ROW, CStr(INT_DATE_CALC_FROM))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(INT_DATE_CALC_TO))
        End With
        With SRT_DATA
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.NUMBER_BREAK))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.CODE_SECTION))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.CODE_SECTION_NAME))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.FLAG_CONTRACT))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.FLAG_CONTRACT_NAME))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.CODE_OWNER))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.CODE_OWNER_NAME))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.NUMBER_CONTRACT))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.SERIAL_CONTRACT))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.NUMBER_CONTRACT_VEIW))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.FLAG_INVOICE_METHOD_NAME))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.NAME_CONTRACT))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.KINGAKU_CONTRACT))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.COUNT_INVOICE))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.KINGAKU_INVOICE_PROSPECT_TOTAL))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.KINGAKU_INVOICE_BEFORE))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.KINGAKU_INVOICE_CURRENT))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.KINGAKU_INVOICE_TOTAL))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.KINGAKU_DEPOSIT_TOTAL))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.KINGAKU_RECEIVABLE))
        End With
        STR_RET = FUNC_GET_ONE_ROW_LIST_CSV(STR_ROW)

        Return STR_RET
    End Function
End Module
