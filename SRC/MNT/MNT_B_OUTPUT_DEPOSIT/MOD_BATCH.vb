Module MOD_BATCH

#Region "バッチ用・変数"
    Friend STR_FUNC_BATCH_MAIN_ERR_STR As String '最終エラー文字列
#End Region

#Region "バッチ用・構造体"

    Public Structure SRT_BATCH_CONDITIONS 'バッチ条件
        Public DATE_DEPOSIT_TO As DateTime
        Public PATH_FILE As String

        Public DATE_DO_BATCH As DateTime
        Public FORM As Object

        Public RET_OUTPUT_COUNT As Integer

        Public ENABLED_FILE_MOVE As Boolean
        Public FILE_PATH_MOVE As String
        Public FILE_MOVE_MAKE_DIR_UNIT As ENM_MAKE_DIR_UNIT
    End Structure

    Private Structure SRT_INFO_FILE_DETAIL
        Public CODE_ACCOUNT As Integer
        Public CODE_SUBACCOUNT As Integer
        Public KINGAKU_TOTAL As Long

        Public RATE_VAT As Decimal

        Public Function CODE_ACCOUNT_PRINT() As String

            If Me.CODE_ACCOUNT <= 0 Then
                Return ""
            End If

            Return CStr(Me.CODE_ACCOUNT)
        End Function

        Public Function CODE_SUBACCOUNT_PRINT() As String

            If Me.CODE_SUBACCOUNT <= 0 Then
                Return ""
            End If

            Return CStr(Me.CODE_SUBACCOUNT)
        End Function

    End Structure

    Private Structure SRT_INFO_FILE
        Public FLAG_HEAD As Boolean

        Public DATE_DEPOSIT As DateTime
        Public KARIKATA As SRT_INFO_FILE_DETAIL
        Public KASIKATA As SRT_INFO_FILE_DETAIL
        Public NAME_MEMO As String

        Public Function FLAG_HEAD_NAME() As String
            Dim STR_RET As String

            If Me.FLAG_HEAD Then
                STR_RET = "*"
            Else
                STR_RET = " "
            End If

            Return STR_RET
        End Function

        Public Function DATE_DEPOSIT_PRINT() As String
            Dim CUL_JP As Globalization.CultureInfo
            CUL_JP = New Globalization.CultureInfo("ja-JP", True)
            CUL_JP.DateTimeFormat.Calendar = New Globalization.JapaneseCalendar()

            Dim STR_RET As String
            'STR_RET = Me.DATE_DEPOSIT.ToString("yyMMdd", CUL_JP)
            'Dim STR_YEAR As String
            'STR_YEAR = Me.DATE_DEPOSIT.ToString("yy")

            'Dim STR_MONTH As String
            'STR_MONTH = Me.DATE_DEPOSIT.ToString("MM")
            'If STR_MONTH.Length <= 1 Then
            '    STR_MONTH = " " & STR_MONTH
            'End If

            'Dim STR_DAY As String
            'STR_DAY = Me.DATE_DEPOSIT.ToString("dd")
            'If STR_DAY.Length <= 1 Then
            '    STR_DAY = " " & STR_DAY
            'End If

            STR_RET = Me.DATE_DEPOSIT.ToString("yyMMdd")

            Return STR_RET
        End Function
    End Structure

#End Region

#Region "バッチ用・列挙定数"
    Private Enum ENM_FLAG_BALANCE
        KARIKATA = 1
        KASIKATA = 2
    End Enum
#End Region

    Friend Function FUNC_BACTH_MAIN(ByRef BLN_PUT As Boolean, ByRef SRT_CONDITIONS As SRT_BATCH_CONDITIONS) As Boolean

        If Not FUNC_FILE_DELETE(SRT_CONDITIONS.PATH_FILE) Then
            STR_FUNC_BATCH_MAIN_ERR_STR = str_FILE_TOOL_LAST_ERR_STRING
            Return False
        End If

        SRT_CONDITIONS.RET_OUTPUT_COUNT = 0

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL(SRT_CONDITIONS)

        Dim SDR_READER As SqlClient.SqlDataReader
        SDR_READER = Nothing
        If Not FUNC_SYSTEM_GET_SQL_DATA_READER(STR_SQL.ToString, SDR_READER) Then
            STR_FUNC_BATCH_MAIN_ERR_STR = str_SQL_TOOL_LAST_ERR_STRING
            Return False
        End If

        If Not SDR_READER.HasRows Then
            Call SDR_READER.Close()
            SDR_READER = Nothing
            Return True 'データなし正常終了
        End If

        Dim SRT_DEPOSIT() As SRT_TABLE_MNT_T_DEPOSIT '対象の契約すべて（定期かつ自動更新かつ契約連番が最大）
        ReDim SRT_DEPOSIT(0)
        While SDR_READER.Read
            Dim INT_INDEX As Integer
            INT_INDEX = (SRT_DEPOSIT.Length)
            ReDim Preserve SRT_DEPOSIT(INT_INDEX)
            If INT_INDEX Mod 5 = 0 Then Call SUB_PUT_GUIDE(SRT_CONDITIONS.FORM, "入金取得中：" & INT_INDEX)

            With SRT_DEPOSIT(INT_INDEX).KEY
                .NUMBER_CONTRACT = CInt(SDR_READER.Item("NUMBER_CONTRACT"))
                .SERIAL_CONTRACT = CInt(SDR_READER.Item("SERIAL_CONTRACT"))
                .SERIAL_INVOICE = CInt(SDR_READER.Item("SERIAL_INVOICE"))
            End With
            With SRT_DEPOSIT(INT_INDEX).DATA
                .DATE_DEPOSIT = CDate(SDR_READER.Item("DATE_DEPOSIT"))
                .FLAG_SALE = CInt(SDR_READER.Item("FLAG_SALE"))
                .FLAG_DEPOSIT = CInt(SDR_READER.Item("FLAG_DEPOSIT"))
                .FLAG_DEPOSIT_SUB = CInt(SDR_READER.Item("FLAG_DEPOSIT_SUB"))
                .KINGAKU_FEE_DETAIL = CLng(SDR_READER.Item("KINGAKU_FEE_DETAIL"))
                .KINGAKU_FEE_VAT = CLng(SDR_READER.Item("KINGAKU_FEE_VAT"))
                .FLAG_COST = CInt(SDR_READER.Item("FLAG_COST"))
                .KINGAKU_COST_DETAIL = CLng(SDR_READER.Item("KINGAKU_COST_DETAIL"))
                .KINGAKU_COST_VAT = CLng(SDR_READER.Item("KINGAKU_COST_VAT"))
                .NAME_MEMO = CStr(SDR_READER.Item("NAME_MEMO"))
                .SERIAL_DEPOSIT = CInt(SDR_READER.Item("SERIAL_DEPOSIT"))
                .FLAG_OUTPUT = CInt(SDR_READER.Item("FLAG_OUTPUT"))
                .DATE_ACTIVE = CDate(SDR_READER.Item("DATE_ACTIVE"))
                .CODE_EDIT_STAFF = CInt(SDR_READER.Item("CODE_EDIT_STAFF"))
                .DATE_EDIT = CDate(SDR_READER.Item("DATE_EDIT"))
            End With
        End While

        Call SDR_READER.Close()
        SDR_READER = Nothing

        BLN_PUT = True
        SRT_CONDITIONS.RET_OUTPUT_COUNT = (SRT_DEPOSIT.Length - 1)

        'ファイル情報作成
        Dim SRT_FILE_ROW() As SRT_INFO_FILE
        ReDim SRT_FILE_ROW(0)
        For i = 1 To (SRT_DEPOSIT.Length - 1)
            Dim SRT_FILE_DEPOSIT() As SRT_INFO_FILE
            SRT_FILE_DEPOSIT = FUNC_GET_FILE_INFO(SRT_DEPOSIT(i))
            For j = 1 To (SRT_FILE_DEPOSIT.Length - 1)
                Dim INT_INDEX As Integer
                INT_INDEX = SRT_FILE_ROW.Length
                ReDim Preserve SRT_FILE_ROW(INT_INDEX)
                SRT_FILE_ROW(INT_INDEX) = SRT_FILE_DEPOSIT(j)
            Next
        Next

        Dim STW_CSV_WRITER As System.IO.StreamWriter 'ファイル出力用のIOオブジェクト
        Try
            STW_CSV_WRITER = New System.IO.StreamWriter(SRT_CONDITIONS.PATH_FILE, False, System.Text.Encoding.Default)   'ファイルライターを開く
        Catch ex As Exception
            STR_FUNC_BATCH_MAIN_ERR_STR = CST_SYSTEM_TOTAL_LIST_ERR_MSG_8001 & Environment.NewLine & SRT_CONDITIONS.PATH_FILE
            Return False
        End Try

        For i = 1 To (SRT_FILE_ROW.Length - 1)
            Dim STR_ROW_ONE As String
            STR_ROW_ONE = FUNC_GET_ROW_ONE(SRT_FILE_ROW(i))
            Call STW_CSV_WRITER.WriteLine(STR_ROW_ONE) 'CSVﾌｧｲﾙ書き込み
        Next

        Call STW_CSV_WRITER.Close() 'ファイルライターを閉じる

        Dim INT_INDEX_MAX As Integer
        INT_INDEX_MAX = (SRT_DEPOSIT.Length - 1)

        If Not FUNC_SYSTEM_BEGIN_TRANSACTION() Then
            STR_FUNC_BATCH_MAIN_ERR_STR = FUNC_SYSTEM_SQLGET_ERR_MESSAGE()
            Return False
        End If

        For i = 1 To (SRT_DEPOSIT.Length - 1)
            If i Mod 5 = 0 Then Call SUB_PUT_GUIDE(SRT_CONDITIONS.FORM, "入金更新中：" & i & "/" & INT_INDEX_MAX)
            With SRT_DEPOSIT(i).KEY
                If Not FUNC_UPDATE_DEPOSIT_FLAG_OUTPUT(.NUMBER_CONTRACT, .SERIAL_CONTRACT, .SERIAL_INVOICE, ENM_SYSTEM_INDIVIDUAL_FLAG_OUTPUT.DONE) Then
                    STR_FUNC_BATCH_MAIN_ERR_STR = FUNC_SYSTEM_SQLGET_ERR_MESSAGE()
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

#Region "内部処理"

    Private Function FUNC_GET_SQL(ByRef SRT_CONDITIONS As SRT_BATCH_CONDITIONS) As String
        Dim STR_SQL As System.Text.StringBuilder

        STR_SQL = New System.Text.StringBuilder
        With STR_SQL
            Call .Append("SELECT" & System.Environment.NewLine)
            Call .Append("MAIN.*" & System.Environment.NewLine)
            Call .Append("FROM" & System.Environment.NewLine)
            Call .Append("MNT_T_DEPOSIT AS MAIN WITH(NOLOCK)" & System.Environment.NewLine)

            Call .Append("INNER JOIN" & System.Environment.NewLine)
            Call .Append("MNT_T_CONTRACT AS SUB_01 WITH(NOLOCK)" & System.Environment.NewLine)
            Call .Append("ON" & System.Environment.NewLine)
            Call .Append("MAIN.NUMBER_CONTRACT=SUB_01.NUMBER_CONTRACT" & System.Environment.NewLine)
            Call .Append("AND MAIN.SERIAL_CONTRACT=SUB_01.SERIAL_CONTRACT" & System.Environment.NewLine)

            Call .Append("WHERE" & System.Environment.NewLine)
            Call .Append("1 = 1" & System.Environment.NewLine)
            Call .Append("AND MAIN.FLAG_OUTPUT=" & ENM_SYSTEM_INDIVIDUAL_FLAG_OUTPUT.NOT_DONE & System.Environment.NewLine) '定期
            Call .Append("AND MAIN.DATE_DEPOSIT<=" & FUNC_ADD_ENCLOSED_SCOT(SRT_CONDITIONS.DATE_DEPOSIT_TO.ToShortDateString) & System.Environment.NewLine) '自動継続

            Call .Append("ORDER BY" & Environment.NewLine)
            Call .Append("MAIN.DATE_DEPOSIT,SUB_01.CODE_OWNER,MAIN.NUMBER_CONTRACT,MAIN.SERIAL_CONTRACT,MAIN.SERIAL_INVOICE" & System.Environment.NewLine)
        End With

        Return STR_SQL.ToString
    End Function

    Private Function FUNC_GET_FILE_INFO(ByRef SRT_DATA As SRT_TABLE_MNT_T_DEPOSIT) As SRT_INFO_FILE()
        Dim SRT_RET() As SRT_INFO_FILE
        ReDim SRT_RET(0)

        Dim STR_NAME_OWNER As String
        STR_NAME_OWNER = FUNC_GET_NAME_OWNER_FROM_COTRACT(SRT_DATA.KEY.NUMBER_CONTRACT, SRT_DATA.KEY.SERIAL_CONTRACT)

        Dim SRT_INVOICE As SRT_TABLE_MNT_T_INVOICE
        With SRT_INVOICE.KEY
            .NUMBER_CONTRACT = SRT_DATA.KEY.NUMBER_CONTRACT
            .SERIAL_CONTRACT = SRT_DATA.KEY.SERIAL_CONTRACT
            .SERIAL_INVOICE = SRT_DATA.KEY.SERIAL_INVOICE
        End With
        SRT_INVOICE.DATA = Nothing
        Call FUNC_SELECT_TABLE_MNT_T_INVOICE(SRT_INVOICE.KEY, SRT_INVOICE.DATA)
        Dim LNG_KINGAKU_INVOICE_TOTAL As Long
        LNG_KINGAKU_INVOICE_TOTAL = SRT_INVOICE.DATA.KINGAKU_INVOICE_DETAIL + SRT_INVOICE.DATA.KINGAKU_INVOICE_VAT

        Dim LNG_KINGAKU_FEE_TOTAL As Long
        LNG_KINGAKU_FEE_TOTAL = SRT_DATA.DATA.KINGAKU_FEE_DETAIL + SRT_DATA.DATA.KINGAKU_FEE_VAT

        Dim LNG_KINGAKU_COST_TOTAL As Long
        LNG_KINGAKU_COST_TOTAL = SRT_DATA.DATA.KINGAKU_COST_DETAIL + SRT_DATA.DATA.KINGAKU_COST_VAT

        Dim LNG_KINGAKU_DEPOSIT_TOTAL As Long
        LNG_KINGAKU_DEPOSIT_TOTAL = LNG_KINGAKU_INVOICE_TOTAL - LNG_KINGAKU_FEE_TOTAL - LNG_KINGAKU_COST_TOTAL

        Dim INT_INDEX As Integer
        '1行目(本体&入金種別)
        INT_INDEX = SRT_RET.Length
        ReDim Preserve SRT_RET(INT_INDEX)
        With SRT_RET(INT_INDEX)
            .FLAG_HEAD = True
            .DATE_DEPOSIT = SRT_DATA.DATA.DATE_DEPOSIT
            .NAME_MEMO = STR_NAME_OWNER
        End With
        With SRT_RET(INT_INDEX).KARIKATA
            .CODE_ACCOUNT = FUNC_GET_MNT_M_ACCOUNT_CODE_ACCOUNT_CONNECT(ENM_SYSTEM_INDIVIDUAL_FLAG_ACCOUNT.FLAG_DEPOSIT, SRT_DATA.DATA.FLAG_DEPOSIT)
            .CODE_SUBACCOUNT = FUNC_GET_MNT_M_ACCOUNT_CODE_ACCOUNT_CONNECT(ENM_SYSTEM_INDIVIDUAL_FLAG_ACCOUNT.KIND_PAYEE, SRT_DATA.DATA.FLAG_DEPOSIT)
            .KINGAKU_TOTAL = LNG_KINGAKU_DEPOSIT_TOTAL
            If .CODE_ACCOUNT <= 0 Then
                .KINGAKU_TOTAL = 0
            End If
            .RATE_VAT = FUNC_SYSTEM_TOTAL_GET_RATE_VAT(SRT_DATA.DATA.DATE_DEPOSIT)
        End With
        With SRT_RET(INT_INDEX).KASIKATA
            .CODE_ACCOUNT = FUNC_GET_MNT_M_ACCOUNT_CODE_ACCOUNT_CONNECT(ENM_SYSTEM_INDIVIDUAL_FLAG_ACCOUNT.FLAG_SALE, SRT_DATA.DATA.FLAG_SALE)
            .CODE_SUBACCOUNT = 0
            .KINGAKU_TOTAL = LNG_KINGAKU_INVOICE_TOTAL
            .RATE_VAT = FUNC_SYSTEM_TOTAL_GET_RATE_VAT(SRT_DATA.DATA.DATE_DEPOSIT)
        End With

        '2行目(手数料)
        If SRT_DATA.DATA.KINGAKU_FEE_DETAIL <> 0 Then
            INT_INDEX = SRT_RET.Length
            ReDim Preserve SRT_RET(INT_INDEX)
            With SRT_RET(INT_INDEX)
                .FLAG_HEAD = False
                .DATE_DEPOSIT = SRT_DATA.DATA.DATE_DEPOSIT
                .NAME_MEMO = STR_NAME_OWNER
            End With
            With SRT_RET(INT_INDEX).KARIKATA
                .CODE_ACCOUNT = FUNC_GET_MNT_M_ACCOUNT_CODE_ACCOUNT_CONNECT(ENM_SYSTEM_INDIVIDUAL_FLAG_ACCOUNT.KIND_FEE, CST_SYSTEM_ACCOUNT_CODE_KIND_ORDINARY_FEE)
                .CODE_SUBACCOUNT = 0
                .KINGAKU_TOTAL = SRT_DATA.DATA.KINGAKU_FEE_DETAIL
                .RATE_VAT = FUNC_SYSTEM_TOTAL_GET_RATE_VAT(SRT_DATA.DATA.DATE_DEPOSIT)
            End With
            With SRT_RET(INT_INDEX).KASIKATA
                .CODE_ACCOUNT = 0
                .CODE_SUBACCOUNT = 0
                .KINGAKU_TOTAL = 0
                .RATE_VAT = FUNC_SYSTEM_TOTAL_GET_RATE_VAT(SRT_DATA.DATA.DATE_DEPOSIT)
            End With
        End If

        '3行目(手数料-消費税)
        If SRT_DATA.DATA.KINGAKU_FEE_VAT <> 0 Then
            INT_INDEX = SRT_RET.Length
            ReDim Preserve SRT_RET(INT_INDEX)
            With SRT_RET(INT_INDEX)
                .FLAG_HEAD = False
                .DATE_DEPOSIT = SRT_DATA.DATA.DATE_DEPOSIT
                .NAME_MEMO = STR_NAME_OWNER
            End With
            With SRT_RET(INT_INDEX).KARIKATA
                .CODE_ACCOUNT = FUNC_GET_MNT_M_ACCOUNT_CODE_ACCOUNT_CONNECT(ENM_SYSTEM_INDIVIDUAL_FLAG_ACCOUNT.KIND_VAT, CST_SYSTEM_ACCOUNT_CODE_KIND_ORDINARY_VAT)
                .CODE_SUBACCOUNT = 0
                .KINGAKU_TOTAL = SRT_DATA.DATA.KINGAKU_FEE_VAT
                .RATE_VAT = FUNC_SYSTEM_TOTAL_GET_RATE_VAT(SRT_DATA.DATA.DATE_DEPOSIT)
            End With
            With SRT_RET(INT_INDEX).KASIKATA
                .CODE_ACCOUNT = 0
                .CODE_SUBACCOUNT = 0
                .KINGAKU_TOTAL = 0
                .RATE_VAT = FUNC_SYSTEM_TOTAL_GET_RATE_VAT(SRT_DATA.DATA.DATE_DEPOSIT)
            End With
        End If

        '4行目(費用)
        Dim INT_CODE_ACCOUNT_CONNECT_COST As Integer
        INT_CODE_ACCOUNT_CONNECT_COST = FUNC_GET_MNT_M_ACCOUNT_CODE_ACCOUNT_CONNECT(ENM_SYSTEM_INDIVIDUAL_FLAG_ACCOUNT.FLAG_COST, SRT_DATA.DATA.FLAG_COST)
        If SRT_DATA.DATA.KINGAKU_COST_DETAIL <> 0 And INT_CODE_ACCOUNT_CONNECT_COST > 0 Then
            INT_INDEX = SRT_RET.Length
            ReDim Preserve SRT_RET(INT_INDEX)
            With SRT_RET(INT_INDEX)
                .FLAG_HEAD = False
                .DATE_DEPOSIT = SRT_DATA.DATA.DATE_DEPOSIT
                .NAME_MEMO = STR_NAME_OWNER
            End With
            With SRT_RET(INT_INDEX).KARIKATA
                .CODE_ACCOUNT = INT_CODE_ACCOUNT_CONNECT_COST
                .CODE_SUBACCOUNT = 0
                .KINGAKU_TOTAL = SRT_DATA.DATA.KINGAKU_COST_DETAIL
                .RATE_VAT = FUNC_SYSTEM_TOTAL_GET_RATE_VAT(SRT_DATA.DATA.DATE_DEPOSIT)
            End With
            With SRT_RET(INT_INDEX).KASIKATA
                .CODE_ACCOUNT = 0
                .CODE_SUBACCOUNT = 0
                .KINGAKU_TOTAL = 0
                .RATE_VAT = FUNC_SYSTEM_TOTAL_GET_RATE_VAT(SRT_DATA.DATA.DATE_DEPOSIT)
            End With
        End If

        '5行目(費用-消費税)
        If SRT_DATA.DATA.KINGAKU_COST_VAT <> 0 Then
            INT_INDEX = SRT_RET.Length
            ReDim Preserve SRT_RET(INT_INDEX)
            With SRT_RET(INT_INDEX)
                .FLAG_HEAD = False
                .DATE_DEPOSIT = SRT_DATA.DATA.DATE_DEPOSIT
                .NAME_MEMO = STR_NAME_OWNER
            End With
            With SRT_RET(INT_INDEX).KARIKATA
                .CODE_ACCOUNT = FUNC_GET_MNT_M_ACCOUNT_CODE_ACCOUNT_CONNECT(ENM_SYSTEM_INDIVIDUAL_FLAG_ACCOUNT.KIND_VAT, CST_SYSTEM_ACCOUNT_CODE_KIND_ORDINARY_VAT)
                .CODE_SUBACCOUNT = 0
                .KINGAKU_TOTAL = SRT_DATA.DATA.KINGAKU_COST_VAT
                .RATE_VAT = FUNC_SYSTEM_TOTAL_GET_RATE_VAT(SRT_DATA.DATA.DATE_DEPOSIT)
            End With
            With SRT_RET(INT_INDEX).KASIKATA
                .CODE_ACCOUNT = 0
                .CODE_SUBACCOUNT = 0
                .KINGAKU_TOTAL = 0
                .RATE_VAT = FUNC_SYSTEM_TOTAL_GET_RATE_VAT(SRT_DATA.DATA.DATE_DEPOSIT)
            End With
        End If

        Return SRT_RET

    End Function

    Private Function FUNC_GET_ROW_ONE(ByRef SRT_DATA As SRT_INFO_FILE) As String
        Dim STR_RET As String
        STR_RET = ""
        With SRT_DATA
            STR_RET &= .FLAG_HEAD_NAME & ","
            STR_RET &= " " & "," '空白
            STR_RET &= .DATE_DEPOSIT_PRINT & ","
            STR_RET &= "      " & "," '空白
        End With
        With SRT_DATA.KARIKATA
            STR_RET &= "    " & "," '空白
            STR_RET &= FUNC_APPEND_LEFT_CHAR(.CODE_ACCOUNT_PRINT, 4) & ","
            STR_RET &= FUNC_APPEND_LEFT_CHAR(.CODE_SUBACCOUNT_PRINT, 4) & ","
            STR_RET &= FUNC_APPEND_LEFT_CHAR(.KINGAKU_TOTAL, 11) & ","
            STR_RET &= "          " & "," '空白
            STR_RET &= " " & "," '空白
            STR_RET &= " " & 0 & "," '0
            STR_RET &= CInt(.RATE_VAT) & ","
        End With
        With SRT_DATA.KASIKATA
            STR_RET &= "    " & "," '空白
            STR_RET &= FUNC_APPEND_LEFT_CHAR(.CODE_ACCOUNT_PRINT, 4) & ","
            STR_RET &= FUNC_APPEND_LEFT_CHAR(.CODE_SUBACCOUNT_PRINT, 4) & ","
            STR_RET &= FUNC_APPEND_LEFT_CHAR(.KINGAKU_TOTAL, 11) & ","
            STR_RET &= "          " & "," '空白
            STR_RET &= " " & "," '空白
            STR_RET &= " " & 0 & "," '0
            STR_RET &= CInt(.RATE_VAT) & ","
        End With
        With SRT_DATA
            STR_RET &= .NAME_MEMO & ""
        End With


        Return STR_RET
    End Function

    Private Function FUNC_APPEND_LEFT_CHAR(ByVal STR_BASE As String, ByVal INT_APPEND As Integer) As String
        Dim STR_APPEND As String
        STR_APPEND = New String(" ", INT_APPEND)

        Dim STR_TEMP As String
        STR_TEMP = STR_APPEND & STR_BASE

        Dim STR_RET As String
        STR_RET = STR_TEMP.Substring(STR_BASE.Length, INT_APPEND)

        Return STR_RET
    End Function
#End Region

#Region "内部処理-汎用"
    Private Sub SUB_PUT_GUIDE(ByRef objFORM As Object, ByVal strGUIDE As String)
        Call objFORM.SUB_PUT_PROGRESS_GUIDE(strGUIDE)
    End Sub
#End Region

    Friend Function FUNC_BATCH_MAIN_BACKUP(
    ByRef BLN_PUT As Boolean,
    ByRef SRT_CONDITIONS As SRT_BATCH_CONDITIONS
    ) As Boolean
        If Not SRT_CONDITIONS.ENABLED_FILE_MOVE Then
            Return True '処理なし正常終了
        End If

        If Not FUNC_DIR_CHECK(SRT_CONDITIONS.FILE_PATH_MOVE) Then
            STR_FUNC_BATCH_MAIN_ERR_STR = "バックアップディレクトリ" & System.Environment.NewLine & SRT_CONDITIONS.FILE_PATH_MOVE & System.Environment.NewLine & "が存在しません"
            Return False
        End If

        Dim STR_MAKE_DIR As String
        Select Case SRT_CONDITIONS.FILE_MOVE_MAKE_DIR_UNIT
            Case ENM_MAKE_DIR_UNIT.NONE
                STR_MAKE_DIR = ""
            Case ENM_MAKE_DIR_UNIT.YEARLY
                STR_MAKE_DIR = SRT_CONDITIONS.DATE_DO_BATCH.Year
            Case ENM_MAKE_DIR_UNIT.MONTHLY
                STR_MAKE_DIR = FUNC_GET_YYYYMM_FROM_DATE(SRT_CONDITIONS.DATE_DO_BATCH)
            Case ENM_MAKE_DIR_UNIT.DAYLY
                STR_MAKE_DIR = Format(SRT_CONDITIONS.DATE_DO_BATCH, "yyyyMMdd")
            Case Else
                STR_MAKE_DIR = ""
        End Select

        Dim STR_MAKE_DIR_PATH As String
        If STR_MAKE_DIR = "" Then
            STR_MAKE_DIR_PATH = SRT_CONDITIONS.FILE_PATH_MOVE
        Else
            STR_MAKE_DIR_PATH = SRT_CONDITIONS.FILE_PATH_MOVE & "\" & STR_MAKE_DIR
        End If

        If Not FUNC_DIR_CHECK(STR_MAKE_DIR_PATH) Then '存在しない場合は
            If Not FUNC_DIR_MAKE(STR_MAKE_DIR_PATH) Then '作成
                STR_FUNC_BATCH_MAIN_ERR_STR = str_FILE_TOOL_LAST_ERR_STRING
                Return False
            End If
        End If

        Dim STR_FILE_NAME As String
        STR_FILE_NAME = FUNC_PATH_TO_FILENAME(SRT_CONDITIONS.PATH_FILE)

        Dim STR_FILE_PATH_BACKUP As String
        STR_FILE_PATH_BACKUP = STR_MAKE_DIR_PATH & "\" & STR_FILE_NAME

        Const CST_MAX_INDEX As Integer = 99
        For i = 0 To CST_MAX_INDEX
            Dim STR_TEMP As String
            STR_TEMP = STR_FILE_PATH_BACKUP & If(i = 0, "", "_" & Format(i, "00"))
            If Not FUNC_FILE_CHECK(STR_TEMP) Then
                Exit For
            End If
        Next

        If Not FUNC_FILE_COPY(SRT_CONDITIONS.PATH_FILE, STR_FILE_PATH_BACKUP) Then
            STR_FUNC_BATCH_MAIN_ERR_STR = str_FILE_TOOL_LAST_ERR_STRING
            Return False
        End If

        Return True
    End Function

End Module
