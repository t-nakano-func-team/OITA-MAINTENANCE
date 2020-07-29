Module MOD_PRINT

#Region "帳票用・変数"
    Private STR_FILE_NAME_PRINT_DATA As String 'データファイルの名称
    Private STR_PATH_PRINT_DATA As String 'データファイルのパス
    Friend STR_FUNC_PRINT_MAIN_ERR_STR As String '最終エラー文字列
#End Region

#Region "帳票用・定数"
    Private Const CST_PRINT_DEFINITION As String = "MNT_P_DETAIL_CONTRACT" '定義体名称
    Private Const CST_PRINT_LIST_NAME As String = "契約一覧表"
    Private Const CST_PRINT_DATA_FILE_EXTENT As String = ".dat"
#End Region

#Region "帳票用・列挙定数"

#End Region

#Region "帳票用・構造体"
    Public Structure SRT_PRINT_CONDITIONS '印刷条件
        Public DATE_CONTRACT_FROM As DateTime
        Public DATE_CONTRACT_TO As DateTime
        Public DATE_ACTIVE_FROM As DateTime
        Public DATE_ACTIVE_TO As DateTime
        Public FLAG_CONTRACT As Integer
        Public CODE_OWNER_FROM As Integer
        Public CODE_OWNER_TO As Integer
        Public NAME_OWNER As String
    End Structure

    Public Structure SRT_PRINT_DATA '印刷データ
        Public NUMBER_CONTRACT As Integer
        Public SERIAL_CONTRACT As Integer

        Public FLAG_CONTRACT As Integer
        Public DATE_CONTRACT As DateTime
        Public CODE_OWNER As Integer
        Public CODE_SECTION As Integer
        Public CODE_MAINTENANCE As Integer
        Public NAME_CONTRACT As String
        Public DATE_MAINTENANCE_START As DateTime
        Public DATE_MAINTENANCE_END As DateTime
        Public DATE_INVOICE_BASE As DateTime
        Public SPAN_INVOICE As Integer
        Public COUNT_INVOICE As Integer
        Public NUMBER_LIST_INVOICE As Integer
        Public KINGAKU_CONTRACT As Long
        Public NAME_MEMO As String

        Public FLAG_CONTRACT_NAME As String
        Public DATE_CONTRACT_INT As Integer
        Public CODE_OWNER_NAME As String
        Public CODE_SECTION_NAME As String
        Public CODE_MAINTENANCE_NAME As String
        Public DATE_MAINTENANCE_START_INT As Integer
        Public DATE_MAINTENANCE_END_INT As Integer
        Public DATE_INVOICE_BASE_INT As Integer

        Public NUMBER_BREAK As Integer

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

                .FLAG_CONTRACT = CInt(SDR_READER.Item("FLAG_CONTRACT"))
                .DATE_CONTRACT = CDate(SDR_READER.Item("DATE_CONTRACT"))
                .CODE_OWNER = CInt(SDR_READER.Item("CODE_OWNER"))
                .CODE_SECTION = CInt(SDR_READER.Item("CODE_SECTION"))
                .CODE_MAINTENANCE = CInt(SDR_READER.Item("CODE_MAINTENANCE"))
                .NAME_CONTRACT = CStr(SDR_READER.Item("NAME_CONTRACT"))
                .DATE_MAINTENANCE_START = CDate(SDR_READER.Item("DATE_MAINTENANCE_START"))
                .DATE_MAINTENANCE_END = CDate(SDR_READER.Item("DATE_MAINTENANCE_END"))
                .DATE_INVOICE_BASE = CDate(SDR_READER.Item("DATE_INVOICE_BASE"))
                .SPAN_INVOICE = CInt(SDR_READER.Item("SPAN_INVOICE"))
                .COUNT_INVOICE = CInt(SDR_READER.Item("COUNT_INVOICE"))
                .NUMBER_LIST_INVOICE = CInt(SDR_READER.Item("NUMBER_LIST_INVOICE"))
                .KINGAKU_CONTRACT = CLng(SDR_READER.Item("KINGAKU_CONTRACT"))
                .NAME_MEMO = CStr(SDR_READER.Item("NAME_MEMO"))
            End With
        End While

        Call SDR_READER.Close()
        SDR_READER = Nothing

        Dim INT_FLAG_CONTRACT_BEFORE As Integer
        INT_FLAG_CONTRACT_BEFORE = -1

        Dim INT_NUMBER_BREAK As Integer
        INT_NUMBER_BREAK = 0
        For i = 1 To (SRT_DATA.Length - 1)
            If INT_FLAG_CONTRACT_BEFORE <> SRT_DATA(i).FLAG_CONTRACT Then
                INT_NUMBER_BREAK += 1
            End If
            Call SUB_REPLACE_DATA(SRT_DATA(i), INT_NUMBER_BREAK)
            INT_FLAG_CONTRACT_BEFORE = SRT_DATA(i).FLAG_CONTRACT
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
            Call .Append("MAIN.*" & "" & System.Environment.NewLine)

            Call .Append("FROM" & System.Environment.NewLine)
            Call .Append("MNT_T_CONTRACT AS MAIN WITH(NOLOCK)" & System.Environment.NewLine)

            Call .Append("LEFT JOIN" & System.Environment.NewLine)
            Call .Append("MNT_T_CONTRACT_SPOT AS SUB_01 WITH(NOLOCK)" & System.Environment.NewLine)
            Call .Append("ON" & System.Environment.NewLine)
            Call .Append("MAIN.NUMBER_CONTRACT=SUB_01.NUMBER_CONTRACT" & System.Environment.NewLine)
            Call .Append("AND MAIN.SERIAL_CONTRACT=SUB_01.SERIAL_CONTRACT" & System.Environment.NewLine)

            Call .Append("WHERE" & System.Environment.NewLine)
            Call .Append("1 = 1" & System.Environment.NewLine)
            Dim STR_WHERE As String
            STR_WHERE = FUNC_GET_SQL_WHERE(SRT_CONDITIONS)
            Call .Append(STR_WHERE)
            Call .Append("ORDER BY" & Environment.NewLine)
            Call .Append("MAIN.FLAG_CONTRACT,MAIN.NUMBER_CONTRACT,MAIN.SERIAL_CONTRACT" & System.Environment.NewLine)
        End With

        Return STR_SQL.ToString
    End Function


    Private Function FUNC_GET_SQL_WHERE(ByRef SRT_CONDITIONS As SRT_PRINT_CONDITIONS)
        Dim STR_WHERE As String
        STR_WHERE = ""

        Dim SRT_CONTRACT_PERIOD As SRT_DATE_PERIOD
        SRT_CONTRACT_PERIOD.DATE_FROM = SRT_CONDITIONS.DATE_CONTRACT_FROM
        SRT_CONTRACT_PERIOD.DATE_TO = SRT_CONDITIONS.DATE_CONTRACT_TO

        Dim SRT_ACTIVE_PERIOD As SRT_DATE_PERIOD
        SRT_ACTIVE_PERIOD.DATE_FROM = SRT_CONDITIONS.DATE_ACTIVE_FROM
        SRT_ACTIVE_PERIOD.DATE_TO = SRT_CONDITIONS.DATE_ACTIVE_TO

        With SRT_CONDITIONS
            If .FLAG_CONTRACT > 0 Then
                STR_WHERE &= FUNC_GET_SQL_WHERE_INT(SRT_CONDITIONS.FLAG_CONTRACT, "MAIN.FLAG_CONTRACT", "=")
            End If
            STR_WHERE &= FUNC_GET_SQL_WHERE_DATE_FROM_TO(SRT_CONTRACT_PERIOD, "MAIN.DATE_CONTRACT")
            STR_WHERE &= FUNC_GET_SQL_WHERE_DATE_FROM_TO(SRT_ACTIVE_PERIOD, "MAIN.DATE_ACTIVE")
            STR_WHERE &= FUNC_GET_SQL_WHERE_INT(SRT_CONDITIONS.CODE_OWNER_FROM, "MAIN.CODE_OWNER", ">=")
            STR_WHERE &= FUNC_GET_SQL_WHERE_INT(SRT_CONDITIONS.CODE_OWNER_TO, "MAIN.CODE_OWNER", "<=")
        End With

        Return STR_WHERE
    End Function

    '補助情報の取得
    Private Sub SUB_REPLACE_DATA(ByRef SRT_DATA As SRT_PRINT_DATA, ByVal INT_NUMBER_BREAK As Integer)
        With SRT_DATA
            .NUMBER_BREAK = INT_NUMBER_BREAK

            .FLAG_CONTRACT_NAME = FUNC_GET_MNT_M_KIND_NAME_KIND(ENM_MNT_M_KIND_CODE_FLAG.FLAG_CONTRACT, .FLAG_CONTRACT, True)
            .DATE_CONTRACT_INT = FUNC_CONVERT_DATETIME_TO_NUMERIC_DATE(.DATE_CONTRACT)
            .CODE_OWNER_NAME = FUNC_GET_NAME_OWNER_FROM_COTRACT(.NUMBER_CONTRACT, .SERIAL_CONTRACT)
            .CODE_SECTION_NAME = FUNC_GET_MNT_M_SECTION_NAME_SECTION(.CODE_SECTION, True)
            .CODE_MAINTENANCE_NAME = FUNC_GET_MNT_M_MAINTENANCE_NAME_MAINTENANCE(.CODE_MAINTENANCE, True)
            .DATE_MAINTENANCE_START_INT = FUNC_CONVERT_DATETIME_TO_NUMERIC_DATE(.DATE_MAINTENANCE_START)
            .DATE_MAINTENANCE_END_INT = FUNC_CONVERT_DATETIME_TO_NUMERIC_DATE(.DATE_MAINTENANCE_END)
            .DATE_INVOICE_BASE_INT = FUNC_CONVERT_DATETIME_TO_NUMERIC_DATE(.DATE_INVOICE_BASE)
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
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.NUMBER_BREAK))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.FLAG_CONTRACT))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.FLAG_CONTRACT_NAME))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.NUMBER_CONTRACT))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.SERIAL_CONTRACT))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.NUMBER_CONTRACT_PRINT))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.DATE_CONTRACT_INT))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.CODE_OWNER))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.CODE_OWNER_NAME))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.CODE_SECTION))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.CODE_SECTION_NAME))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.CODE_MAINTENANCE))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.CODE_MAINTENANCE_NAME))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.NAME_CONTRACT))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.DATE_MAINTENANCE_START_INT))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.DATE_MAINTENANCE_END_INT))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.DATE_INVOICE_BASE_INT))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.SPAN_INVOICE))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.COUNT_INVOICE))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.NUMBER_LIST_INVOICE))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.KINGAKU_CONTRACT))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.NAME_MEMO))
        End With
        STR_RET = FUNC_GET_ONE_ROW_LIST_CSV(STR_ROW)

        Return STR_RET
    End Function
End Module
