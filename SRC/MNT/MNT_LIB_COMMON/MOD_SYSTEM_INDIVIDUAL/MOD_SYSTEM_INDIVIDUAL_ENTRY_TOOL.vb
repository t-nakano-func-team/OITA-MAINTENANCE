Public Module MOD_SYSTEM_INDIVIDUAL_ENTRY_TOOL

#Region "名称取得"
    Public Sub SUB_GET_NAME_OWNER_INPUT(ByRef TXT_INPUT As System.Windows.Forms.TextBox)
        Dim CTL_NAME As System.Windows.Forms.Label
        CTL_NAME = FUNC_GET_CONTROL_NAME_LABEL(TXT_INPUT, False)
        If CTL_NAME Is Nothing Then
            Exit Sub
        End If
        CTL_NAME.Text = ""

        If Not IsNumeric(TXT_INPUT.Text) Then
            Exit Sub
        End If
        Dim INT_CODE As Integer
        INT_CODE = CInt(TXT_INPUT.Text)

        CTL_NAME.Text = FUNC_GET_MNT_M_OWNER_NAME_OWNER(INT_CODE, True)
    End Sub
#End Region

#Region "CONTRACT"
    Public Function FUNC_GET_NUMBER_CONTRACT_NEW(ByVal BLN_CASH As Boolean) As Integer
        Dim INT_RET As Integer

        INT_RET = 0

        INT_RET = FUNC_GET_MNT_T_CONTRACT_MAX_NUMBER_CONTRACT()
        INT_RET += 1

        'For i = CST_SYSTEM_NUMBER_CONTRACT_MIN_VALUE To CST_SYSTEM_NUMBER_CONTRACT_MAX_VALUE
        '    Dim BLN_CHECK As Boolean
        '    BLN_CHECK = FUNC_CHECK_MNT_T_CONTRACT_NUMBER_CONTRACT(i)
        '    If Not BLN_CHECK Then
        '        INT_RET = i
        '        Exit For
        '    End If
        'Next

        Return INT_RET
    End Function

    Public Function FUNC_GET_KIND_CONTRACT_SORT_ID(ByVal INT_KIND_CONTRACT As Integer) As Integer
        Dim INT_RET As Integer

        Select Case INT_KIND_CONTRACT
            Case ENM_SYSTEM_INDIVIDUAL_KIND_CONTRACT.REGULAR
                INT_RET = 1
            Case ENM_SYSTEM_INDIVIDUAL_KIND_CONTRACT.SPOT
                INT_RET = 2
            Case Else
                INT_RET = 0
        End Select

        Return INT_RET
    End Function
#End Region

#Region "請求関連"
    Public Function FUNC_MAKE_NEW_INVOICE(
    ByVal INT_NUMBER_CONTRACT As Integer, ByVal INT_SERIAL_CONTRACT As Integer, ByVal DAT_DATE_INVOICE As DateTime,
    ByVal SRT_EDIT As SRT_EDIT_INVOICE
    ) As Boolean

        Dim SRT_RECORD_CONTRACT As SRT_TABLE_MNT_T_CONTRACT
        With SRT_RECORD_CONTRACT.KEY
            .NUMBER_CONTRACT = INT_NUMBER_CONTRACT
            .SERIAL_CONTRACT = INT_SERIAL_CONTRACT
        End With
        SRT_RECORD_CONTRACT.DATA = Nothing
        If Not FUNC_SELECT_TABLE_MNT_T_CONTRACT(SRT_RECORD_CONTRACT.KEY, SRT_RECORD_CONTRACT.DATA) Then
            Return False
        End If

        Dim INT_SERIAL_INVOICE_MAX As Integer
        INT_SERIAL_INVOICE_MAX = FUNC_GET_MNT_T_INVOICE_MAX_SERIAL_INVOICE(INT_NUMBER_CONTRACT, INT_SERIAL_CONTRACT)

        Dim SRT_RECORD As SRT_TABLE_MNT_T_INVOICE
        With SRT_RECORD.KEY
            .NUMBER_CONTRACT = INT_NUMBER_CONTRACT
            .SERIAL_CONTRACT = INT_SERIAL_CONTRACT
            .SERIAL_INVOICE = (INT_SERIAL_INVOICE_MAX + 1)
        End With

        With SRT_RECORD.DATA
            .DATE_INVOICE = DAT_DATE_INVOICE
            Dim BLN_EDIT As Boolean
            BLN_EDIT = FUNC_CHECK_EDIT_INVOICE(SRT_EDIT)
            If BLN_EDIT Then
                .CODE_SECTION = SRT_EDIT.CODE_SECTION
                .KINGAKU_INVOICE_DETAIL = SRT_EDIT.KINGAKU_INVOICE_DETAIL
                .KINGAKU_INVOICE_VAT = SRT_EDIT.KINGAKU_INVOICE_VAT
            Else
                .CODE_SECTION = SRT_RECORD_CONTRACT.DATA.CODE_SECTION
                .KINGAKU_INVOICE_DETAIL = SRT_RECORD_CONTRACT.DATA.KINGAKU_CONTRACT
                .KINGAKU_INVOICE_VAT = FUNC_GET_KINGAKU_VAT_FROM_DETAIL(.KINGAKU_INVOICE_DETAIL, .DATE_INVOICE)
            End If
        End With

        If Not FUNC_INSERT_TABLE_MNT_T_INVOICE(SRT_RECORD) Then
            Return False
        End If

        Return True
    End Function

    Private Function FUNC_CHECK_EDIT_INVOICE(ByVal SRT_EDIT As SRT_EDIT_INVOICE) As Boolean

        If Not SRT_EDIT.CEHCK_EDIT Then
            Return False
        End If

        Return True
    End Function

    Public Function FUNC_GET_INVOICE_FROM_REGULAR(
    ByVal INT_YEAR As Integer, ByVal INT_MONTH As Integer,
    ByVal DAT_DATE_INVOICE_FROM As DateTime, ByVal DAT_DATE_INVOICE_TO As DateTime,
    ByVal INT_CODE_OWNER As Integer, ByVal INT_NUMBER_LIST_INVOICE As Integer
    ) As SRT_NUMBER_SERIAL_INVOICE()

        Dim DAT_DATE_INVOICE_KEY_FROM As DateTime
        DAT_DATE_INVOICE_KEY_FROM = New DateTime(INT_YEAR, INT_MONTH, 1)
        Dim DAT_DATE_INVOICE_KEY_TO As DateTime
        DAT_DATE_INVOICE_KEY_TO = FUNC_GET_DATE_LASTMONTH(DAT_DATE_INVOICE_KEY_FROM)

        Dim STR_SQL As System.Text.StringBuilder
        STR_SQL = New System.Text.StringBuilder
        With STR_SQL
            Call .Append("SELECT" & Environment.NewLine)
            Call .Append("MAIN.NUMBER_CONTRACT" & "," & Environment.NewLine)
            Call .Append("MAIN.SERIAL_CONTRACT" & "," & Environment.NewLine)
            Call .Append("MAIN.SERIAL_INVOICE" & "" & Environment.NewLine)
            Call .Append("FROM" & Environment.NewLine)
            Call .Append("(" & Environment.NewLine)
            Call .Append("SELECT" & Environment.NewLine)
            Call .Append("*" & Environment.NewLine)
            Call .Append("FROM" & Environment.NewLine)
            Call .Append("MNT_T_INVOICE WITH(NOLOCK)" & Environment.NewLine)
            Call .Append("WHERE" & Environment.NewLine)
            Call .Append("1=1" & Environment.NewLine)
            Call .Append("AND DATE_INVOICE>=" & FUNC_ADD_ENCLOSED_SCOT(DAT_DATE_INVOICE_FROM.ToShortDateString) & Environment.NewLine)
            Call .Append("AND DATE_INVOICE<=" & FUNC_ADD_ENCLOSED_SCOT(DAT_DATE_INVOICE_TO.ToShortDateString) & Environment.NewLine)
            Call .Append("AND DATE_INVOICE>=" & FUNC_ADD_ENCLOSED_SCOT(DAT_DATE_INVOICE_KEY_FROM.ToShortDateString) & Environment.NewLine)
            Call .Append("AND DATE_INVOICE<=" & FUNC_ADD_ENCLOSED_SCOT(DAT_DATE_INVOICE_KEY_TO.ToShortDateString) & Environment.NewLine)
            Call .Append(") AS MAIN" & Environment.NewLine)
            Call .Append("INNER JOIN" & Environment.NewLine)
            Call .Append("(" & Environment.NewLine)
            Call .Append("SELECT" & Environment.NewLine)
            Call .Append("*" & Environment.NewLine)
            Call .Append("FROM" & Environment.NewLine)
            Call .Append("MNT_T_CONTRACT WITH(NOLOCK)" & Environment.NewLine)
            Call .Append("WHERE" & Environment.NewLine)
            Call .Append("1=1" & Environment.NewLine)
            Call .Append("AND CODE_OWNER=" & INT_CODE_OWNER & Environment.NewLine)
            Call .Append("AND NUMBER_LIST_INVOICE=" & INT_NUMBER_LIST_INVOICE & Environment.NewLine)
            Call .Append(") AS SUB_01" & Environment.NewLine)
            Call .Append("ON" & Environment.NewLine)
            Call .Append("MAIN.NUMBER_CONTRACT=SUB_01.NUMBER_CONTRACT" & Environment.NewLine)
            Call .Append("AND MAIN.SERIAL_CONTRACT=SUB_01.SERIAL_CONTRACT" & Environment.NewLine)
            Call .Append("ORDER BY" & Environment.NewLine)
            Call .Append("NUMBER_CONTRACT,SERIAL_CONTRACT,SERIAL_INVOICE" & Environment.NewLine)
        End With

        Dim SRT_RET() As SRT_NUMBER_SERIAL_INVOICE
        ReDim SRT_RET(0)

        Dim SDR_READER As SqlClient.SqlDataReader
        SDR_READER = Nothing
        If Not FUNC_SYSTEM_GET_SQL_DATA_READER(STR_SQL.ToString, SDR_READER) Then
            SDR_READER = Nothing
            Return SRT_RET
        End If

        If Not SDR_READER.HasRows Then
            Call SDR_READER.Close()
            SDR_READER = Nothing
            Return SRT_RET
        End If

        Dim INT_INDEX As Integer
        INT_INDEX = 0
        While SDR_READER.Read
            INT_INDEX += 1
            ReDim Preserve SRT_RET(INT_INDEX)
            With SRT_RET(INT_INDEX)
                .NUMBER_CONTRACT = CInt(SDR_READER.Item("NUMBER_CONTRACT"))
                .SERIAL_CONTRACT = CInt(SDR_READER.Item("SERIAL_CONTRACT"))
                .SERIAL_INVOICE = CInt(SDR_READER.Item("SERIAL_INVOICE"))
            End With
        End While

        Call SDR_READER.Close()
        SDR_READER = Nothing

        Return SRT_RET
    End Function

    Public Function FUNC_GET_TOTAL_KINGAKU_INVOICE_FROM_REGULAR(
    ByVal INT_YEAR As Integer, ByVal INT_MONTH As Integer,
    ByVal DAT_DATE_INVOICE_FROM As DateTime, ByVal DAT_DATE_INVOICE_TO As DateTime,
    ByVal INT_CODE_OWNER As Integer, ByVal INT_NUMBER_LIST_INVOICE As Integer
    ) As Long

        Dim SRT_KEY() As SRT_NUMBER_SERIAL_INVOICE

        SRT_KEY = FUNC_GET_INVOICE_FROM_REGULAR(INT_YEAR, INT_MONTH, DAT_DATE_INVOICE_FROM, DAT_DATE_INVOICE_TO, INT_CODE_OWNER, INT_NUMBER_LIST_INVOICE)

        Dim LNG_KINGAKU_DETAIL_TOTAL As Long
        LNG_KINGAKU_DETAIL_TOTAL = 0
        Dim LNG_KINGAKU_VAT_TOTAL As Long
        LNG_KINGAKU_VAT_TOTAL = 0
        For i = 1 To (SRT_KEY.Length - 1)
            With SRT_KEY(i)
                Dim LNG_KINGAKU_DETAIL As Long
                LNG_KINGAKU_DETAIL = FUNC_GET_MNT_T_INVOICE_KINGAKU_INVOICE_DETAIL(.NUMBER_CONTRACT, .SERIAL_CONTRACT, .SERIAL_INVOICE, True)
                Dim LNG_KINGAKU_VAT As Long
                LNG_KINGAKU_VAT = FUNC_GET_MNT_T_INVOICE_KINGAKU_INVOICE_VAT(.NUMBER_CONTRACT, .SERIAL_CONTRACT, .SERIAL_INVOICE, True)

                LNG_KINGAKU_DETAIL_TOTAL += LNG_KINGAKU_DETAIL
                LNG_KINGAKU_VAT_TOTAL += LNG_KINGAKU_VAT
            End With
        Next

        Dim LNG_RET As Long
        LNG_RET = LNG_KINGAKU_DETAIL_TOTAL + LNG_KINGAKU_VAT_TOTAL
        Return LNG_RET
    End Function

    Public Function FUNC_GET_INVOICE_RECORD_ALL(ByVal INT_NUMBER_CONTRACT As Integer, ByVal INT_SERIAL_CONTRACT As Integer) As SRT_TABLE_MNT_T_INVOICE()

        Dim STR_SQL As System.Text.StringBuilder
        STR_SQL = New System.Text.StringBuilder
        With STR_SQL
            .Append("SELECT" & System.Environment.NewLine)
            .Append("*" & System.Environment.NewLine)
            .Append("FROM" & System.Environment.NewLine)
            .Append("MNT_T_INVOICE WITH(NOLOCK)" & System.Environment.NewLine)
            .Append("WHERE" & System.Environment.NewLine)
            .Append("1=1" & System.Environment.NewLine)
            .Append("AND NUMBER_CONTRACT=" & INT_NUMBER_CONTRACT & System.Environment.NewLine)
            .Append("AND SERIAL_CONTRACT=" & INT_SERIAL_CONTRACT & System.Environment.NewLine)
            .Append("ORDER BY" & System.Environment.NewLine)
            .Append("NUMBER_CONTRACT,SERIAL_CONTRACT,SERIAL_INVOICE" & System.Environment.NewLine)
        End With

        Dim SRT_RET() As SRT_TABLE_MNT_T_INVOICE
        ReDim SRT_RET(0)

        Dim SDR_READER As SqlClient.SqlDataReader
        SDR_READER = Nothing
        If Not FUNC_SYSTEM_GET_SQL_DATA_READER(STR_SQL.ToString, SDR_READER) Then
            SDR_READER = Nothing
            Return SRT_RET
        End If

        If Not SDR_READER.HasRows Then
            Call SDR_READER.Close()
            SDR_READER = Nothing
            Return SRT_RET
        End If

        While SDR_READER.Read
            Dim INT_INDEX As Integer
            INT_INDEX = SRT_RET.Length
            ReDim Preserve SRT_RET(INT_INDEX)
            With SRT_RET(INT_INDEX).KEY
                .NUMBER_CONTRACT = CInt(SDR_READER.Item("NUMBER_CONTRACT"))
                .SERIAL_CONTRACT = CInt(SDR_READER.Item("SERIAL_CONTRACT"))
                .SERIAL_INVOICE = CInt(SDR_READER.Item("SERIAL_INVOICE"))
            End With
            With SRT_RET(INT_INDEX).DATA
                .DATE_INVOICE = CDate(SDR_READER.Item("DATE_INVOICE"))
                .KINGAKU_INVOICE_DETAIL = CLng(SDR_READER.Item("KINGAKU_INVOICE_DETAIL"))
                .KINGAKU_INVOICE_VAT = CLng(SDR_READER.Item("KINGAKU_INVOICE_VAT"))
            End With
        End While

        Call SDR_READER.Close()
        SDR_READER = Nothing

        Return SRT_RET
    End Function

    Public Function FUNC_GET_KINGAKU_INVOICE_FROM_DATE_FROM_TO(
    ByVal INT_NUMBER_CONTRACT As Integer, ByVal INT_SERIAL_CONTRACT As Integer,
    ByVal DAT_DATE_CALC_FROM As DateTime, ByVal DAT_DATE_CALC_TO As DateTime
    ) As Long
        Dim STR_SQL As System.Text.StringBuilder
        STR_SQL = New System.Text.StringBuilder
        With STR_SQL
            .Append("SELECT" & System.Environment.NewLine)
            .Append("SUM(KINGAKU_INVOICE_DETAIL+KINGAKU_INVOICE_VAT)" & System.Environment.NewLine)
            .Append("FROM" & System.Environment.NewLine)
            .Append("MNT_T_INVOICE WITH(NOLOCK)" & System.Environment.NewLine)
            .Append("WHERE" & System.Environment.NewLine)
            .Append("1=1" & System.Environment.NewLine)
            .Append(FUNC_GET_SQL_WHERE_INT(INT_NUMBER_CONTRACT, "NUMBER_CONTRACT", "="))
            .Append(FUNC_GET_SQL_WHERE_INT(INT_SERIAL_CONTRACT, "SERIAL_CONTRACT", "="))
            Dim SRT_CALC_PERIOD As SRT_DATE_PERIOD
            SRT_CALC_PERIOD.DATE_FROM = DAT_DATE_CALC_FROM
            SRT_CALC_PERIOD.DATE_TO = DAT_DATE_CALC_TO
            .Append(FUNC_GET_SQL_WHERE_DATE_FROM_TO(SRT_CALC_PERIOD, "DATE_INVOICE"))
        End With

        Dim LNG_RET As Integer
        LNG_RET = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_NUMERIC(STR_SQL.ToString, 0)

        Return LNG_RET
    End Function

    '(次回)請求予定日の取得
    Public Function FUNC_GET_DATE_INVOICE_PLAN(ByVal INT_NUMBER_CONTRACT As Integer, ByVal INT_SERIAL_CONTRACT As Integer) As DateTime
        Dim SRT_CONTRACT As SRT_TABLE_MNT_T_CONTRACT
        With SRT_CONTRACT.KEY
            .NUMBER_CONTRACT = INT_NUMBER_CONTRACT
            .SERIAL_CONTRACT = INT_SERIAL_CONTRACT
        End With
        SRT_CONTRACT.DATA = Nothing
        Call FUNC_SELECT_TABLE_MNT_T_CONTRACT(SRT_CONTRACT.KEY, SRT_CONTRACT.DATA)

        Dim INT_SERIAL_INVOICE_MAX As Integer
        INT_SERIAL_INVOICE_MAX = FUNC_GET_MNT_T_INVOICE_MAX_SERIAL_INVOICE(INT_NUMBER_CONTRACT, INT_SERIAL_CONTRACT)
        If INT_SERIAL_INVOICE_MAX <= 0 Then '一度も請求されていないなら
            Return SRT_CONTRACT.DATA.DATE_INVOICE_BASE '請求基準日
        End If

        If SRT_CONTRACT.DATA.COUNT_INVOICE <= INT_SERIAL_INVOICE_MAX Then 'すべての請求が完了している場合は
            Return cstVB_DATE_MAX '最大（到達できない）日付
        End If

        '請求途中の場合
        Dim DAT_DATE_INVOICE_LAST As DateTime
        DAT_DATE_INVOICE_LAST = FUNC_GET_MNT_T_INVOICE_DATE_INVOICE(INT_NUMBER_CONTRACT, INT_SERIAL_CONTRACT, INT_SERIAL_INVOICE_MAX) '最終請求日を取得

        Dim INT_YYYYMM_INVOICE_LAST As Integer
        INT_YYYYMM_INVOICE_LAST = FUNC_GET_YYYYMM_FROM_DATE(DAT_DATE_INVOICE_LAST) '年月に変換

        Dim INT_YYYYMM_INVOICE_PLAN As Integer
        INT_YYYYMM_INVOICE_PLAN = FUNC_ADD_MONTH_YYYYMM(INT_YYYYMM_INVOICE_LAST, SRT_CONTRACT.DATA.SPAN_INVOICE) '請求スパンを+

        Dim INT_YEAR As Integer
        INT_YEAR = FUNC_GET_YYYY_FROM_YYYYMM(INT_YYYYMM_INVOICE_PLAN) '年をパース
        Dim INT_MONTH As Integer
        INT_MONTH = FUNC_GET_MM_FROM_YYYYMM(INT_YYYYMM_INVOICE_PLAN) '月をパース

        Dim INT_DAY As Integer
        INT_DAY = SRT_CONTRACT.DATA.DATE_INVOICE_BASE.Day

        Dim DAT_RET As DateTime
        If INT_DAY >= 28 Then '28日以降が基準なら
            Dim DAT_CALC As DateTime
            DAT_CALC = New DateTime(INT_YEAR, INT_MONTH, 1)
            DAT_RET = FUNC_GET_DATE_LASTMONTH(DAT_CALC) '月末を算出
        Else
            DAT_RET = New DateTime(INT_YEAR, INT_MONTH, INT_DAY)
        End If

        Return DAT_RET
    End Function

    '該当契約の全ての請求情報を削除する。（入金も同時削除）
    Public Function FUNC_DELETE_INVOICE_CONTRACT(ByVal INT_NUMBER_CONTRACT As Integer, ByVal INT_SERIAL_CONTRACT As Integer) As Boolean
        Dim STR_SQL As System.Text.StringBuilder
        STR_SQL = New System.Text.StringBuilder
        With STR_SQL
            Call .Append("DELETE" & System.Environment.NewLine)
            Call .Append("FROM" & System.Environment.NewLine)
            Call .Append("MNT_T_INVOICE WITH(ROWLOCK)" & System.Environment.NewLine)
            Call .Append("WHERE" & System.Environment.NewLine)
            Call .Append("1=1" & System.Environment.NewLine)
            Call .Append("AND NUMBER_CONTRACT=" & INT_NUMBER_CONTRACT & System.Environment.NewLine)
            Call .Append("AND SERIAL_CONTRACT=" & INT_SERIAL_CONTRACT & System.Environment.NewLine)
        End With

        If Not FUNC_SYSTEM_DO_SQL_EXECUTE(STR_SQL.ToString) Then
            Return False
        End If

        Return True
    End Function
#End Region

#Region "入金関連"
    Public Function FUNC_GET_KINGAKU_DEPOSIT_FROM_SECTION(
    ByVal INT_NUMBER_CONTRACT As Integer, ByVal INT_SERIAL_CONTRACT As Integer,
    ByVal INT_CODE_SECTION As Integer
    ) As Long
        Dim STR_SQL As System.Text.StringBuilder
        STR_SQL = New System.Text.StringBuilder
        With STR_SQL
            .Append("SELECT" & System.Environment.NewLine)
            .Append("SUM(KINGAKU_INVOICE_DETAIL+KINGAKU_INVOICE_VAT) AS KINGAKU_INVOICE" & System.Environment.NewLine)
            .Append("FROM" & System.Environment.NewLine)
            .Append("MNT_T_INVOICE AS MAIN WITH(NOLOCK)" & System.Environment.NewLine)
            .Append("INNER JOIN" & System.Environment.NewLine)
            .Append("MNT_T_DEPOSIT AS SUB_01 WITH(NOLOCK)" & System.Environment.NewLine)
            .Append("ON" & System.Environment.NewLine)
            .Append("MAIN.NUMBER_CONTRACT=SUB_01.NUMBER_CONTRACT" & System.Environment.NewLine)
            .Append("AND MAIN.SERIAL_CONTRACT=SUB_01.SERIAL_CONTRACT" & System.Environment.NewLine)
            .Append("AND MAIN.SERIAL_INVOICE=SUB_01.SERIAL_INVOICE" & System.Environment.NewLine)
            .Append("WHERE" & System.Environment.NewLine)
            .Append("1=1" & System.Environment.NewLine)
            .Append("AND MAIN.NUMBER_CONTRACT=" & INT_NUMBER_CONTRACT & System.Environment.NewLine)
            .Append("And MAIN.SERIAL_CONTRACT=" & INT_SERIAL_CONTRACT & System.Environment.NewLine)
            .Append("AND MAIN.CODE_SECTION=" & INT_CODE_SECTION & System.Environment.NewLine)
        End With

        Dim LNG_RET As Integer
        LNG_RET = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_NUMERIC(STR_SQL.ToString, 0)
        Return LNG_RET
    End Function

    Public Function FUNC_GET_FLAG_DEPOSIT_DONE(ByVal INT_NUMBER_CONTRACT As Integer, ByVal INT_SERIAL_CONTRACT As Integer, ByVal INT_SERIAL_INVOICE As Integer) As Integer
        Dim SRT_RECORD As SRT_TABLE_MNT_T_DEPOSIT_KEY
        With SRT_RECORD
            .NUMBER_CONTRACT = INT_NUMBER_CONTRACT
            .SERIAL_CONTRACT = INT_SERIAL_CONTRACT
            .SERIAL_INVOICE = INT_SERIAL_INVOICE
        End With

        Dim BLN_RET As Boolean
        BLN_RET = FUNC_CHECK_TABLE_MNT_T_DEPOSIT(SRT_RECORD)

        Dim INT_RET As Integer
        INT_RET = FUNC_CAST_BOOL_TO_INT(BLN_RET)

        Return INT_RET
    End Function

    Public Function FUNC_GET_DEPOSIT_RECORD_ALL(ByVal INT_NUMBER_CONTRACT As Integer, ByVal INT_SERIAL_CONTRACT As Integer) As SRT_TABLE_MNT_T_DEPOSIT()

        Dim STR_SQL As System.Text.StringBuilder
        STR_SQL = New System.Text.StringBuilder
        With STR_SQL
            .Append("SELECT" & System.Environment.NewLine)
            .Append("*" & System.Environment.NewLine)
            .Append("FROM" & System.Environment.NewLine)
            .Append("MNT_T_DEPOSIT WITH(NOLOCK)" & System.Environment.NewLine)
            .Append("WHERE" & System.Environment.NewLine)
            .Append("1=1" & System.Environment.NewLine)
            .Append("AND NUMBER_CONTRACT=" & INT_NUMBER_CONTRACT & System.Environment.NewLine)
            .Append("AND SERIAL_CONTRACT=" & INT_SERIAL_CONTRACT & System.Environment.NewLine)
            .Append("ORDER BY" & System.Environment.NewLine)
            .Append("NUMBER_CONTRACT,SERIAL_CONTRACT,SERIAL_INVOICE" & System.Environment.NewLine)
        End With

        Dim SRT_RET() As SRT_TABLE_MNT_T_DEPOSIT
        ReDim SRT_RET(0)

        Dim SDR_READER As SqlClient.SqlDataReader
        SDR_READER = Nothing
        If Not FUNC_SYSTEM_GET_SQL_DATA_READER(STR_SQL.ToString, SDR_READER) Then
            SDR_READER = Nothing
            Return SRT_RET
        End If

        If Not SDR_READER.HasRows Then
            Call SDR_READER.Close()
            SDR_READER = Nothing
            Return SRT_RET
        End If

        While SDR_READER.Read
            Dim INT_INDEX As Integer
            INT_INDEX = SRT_RET.Length
            ReDim Preserve SRT_RET(INT_INDEX)
            With SRT_RET(INT_INDEX).KEY
                .NUMBER_CONTRACT = CInt(SDR_READER.Item("NUMBER_CONTRACT"))
                .SERIAL_CONTRACT = CInt(SDR_READER.Item("SERIAL_CONTRACT"))
                .SERIAL_INVOICE = CInt(SDR_READER.Item("SERIAL_INVOICE"))
            End With
            With SRT_RET(INT_INDEX).DATA
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

        Return SRT_RET
    End Function

    Public Function FUNC_MAKE_NEW_DEPOSIT(ByVal INT_NUMBER_CONTRACT As Integer, ByVal INT_SERIAL_CONTRACT As Integer, ByVal INT_SERIAL_INVOICE As Integer, ByVal DAT_DETE_DEPOSIT As DateTime) As Boolean
        Dim SRT_RECORD As SRT_TABLE_MNT_T_DEPOSIT

        With SRT_RECORD.KEY
            .NUMBER_CONTRACT = INT_NUMBER_CONTRACT
            .SERIAL_CONTRACT = INT_SERIAL_CONTRACT
            .SERIAL_INVOICE = INT_SERIAL_INVOICE
        End With

        If Not FUNC_DELETE_TABLE_MNT_T_DEPOSIT(SRT_RECORD.KEY) Then
            Return False
        End If

        With SRT_RECORD.DATA
            .DATE_DEPOSIT = DAT_DETE_DEPOSIT
            .FLAG_SALE = 1 '未収
            .FLAG_DEPOSIT = 1 '普通預金
            .FLAG_DEPOSIT_SUB = 1 '大分銀行東支店
            .KINGAKU_FEE_DETAIL = 0
            .KINGAKU_FEE_VAT = 0
            .FLAG_COST = 0
            .KINGAKU_COST_DETAIL = 0
            .KINGAKU_COST_VAT = 0
            .FLAG_OUTPUT = ENM_SYSTEM_INDIVIDUAL_FLAG_DEPOSIT_DONE.DONE '完了扱い
            .NAME_MEMO = "自動生成"
            .DATE_ACTIVE = .DATE_DEPOSIT '入金同日に処理したものとする
            .SERIAL_DEPOSIT = FUNC_GET_MNT_T_DEPOSIT_MAX_SERIAL_DEPOSIT(.DATE_ACTIVE) + 1
            .CODE_EDIT_STAFF = srtSYSTEM_TOTAL_COMMANDLINE.CODE_STAFF
            .DATE_EDIT = System.DateTime.Today
        End With

        If Not FUNC_INSERT_TABLE_MNT_T_DEPOSIT(SRT_RECORD) Then
            Return False
        End If

        Return True
    End Function

#End Region

#Region "オーナー関連"
    Public Function FUNC_GET_CODE_OWNER_FROM_COTRACT(ByVal INT_NUMBER_COTRACT As Integer, ByVal INT_SERIAL_CONTRACT As Integer) As Integer
        Dim BLN_CHASH As Boolean
        BLN_CHASH = True

        Dim SRT_CONTRACT As SRT_TABLE_MNT_T_CONTRACT
        With SRT_CONTRACT.KEY
            .NUMBER_CONTRACT = INT_NUMBER_COTRACT
            .SERIAL_CONTRACT = INT_SERIAL_CONTRACT
        End With

        SRT_CONTRACT.DATA = Nothing
        If Not FUNC_SELECT_TABLE_MNT_T_CONTRACT(SRT_CONTRACT.KEY, SRT_CONTRACT.DATA, BLN_CHASH) Then
            Return -1
        End If

        Dim INT_RET As Integer
        INT_RET = SRT_CONTRACT.DATA.CODE_OWNER

        Return INT_RET
    End Function

    Public Function FUNC_GET_NAME_OWNER_FROM_COTRACT(ByVal INT_NUMBER_COTRACT As Integer, ByVal INT_SERIAL_CONTRACT As Integer) As String
        Dim BLN_CHASH As Boolean
        BLN_CHASH = True

        Dim SRT_CONTRACT As SRT_TABLE_MNT_T_CONTRACT
        With SRT_CONTRACT.KEY
            .NUMBER_CONTRACT = INT_NUMBER_COTRACT
            .SERIAL_CONTRACT = INT_SERIAL_CONTRACT
        End With

        SRT_CONTRACT.DATA = Nothing
        If Not FUNC_SELECT_TABLE_MNT_T_CONTRACT(SRT_CONTRACT.KEY, SRT_CONTRACT.DATA, BLN_CHASH) Then
            Return ""
        End If

        Dim STR_RET As String

        With SRT_CONTRACT.DATA
            If .KIND_CONTRACT = ENM_SYSTEM_INDIVIDUAL_KIND_CONTRACT.REGULAR Then
                STR_RET = FUNC_GET_MNT_M_OWNER_NAME_OWNER(.CODE_OWNER, BLN_CHASH)
                Return STR_RET
            End If
        End With

        Dim SRT_CONTRACT_SPOT As SRT_TABLE_MNT_T_CONTRACT_SPOT
        With SRT_CONTRACT_SPOT.KEY
            .NUMBER_CONTRACT = INT_NUMBER_COTRACT
            .SERIAL_CONTRACT = INT_SERIAL_CONTRACT
        End With
        SRT_CONTRACT_SPOT.DATA = Nothing
        If Not FUNC_SELECT_TABLE_MNT_T_CONTRACT_SPOT(SRT_CONTRACT_SPOT.KEY, SRT_CONTRACT_SPOT.DATA) Then
            Return ""
        End If

        STR_RET = SRT_CONTRACT_SPOT.DATA.NAME_OWNER
        Return STR_RET
    End Function
#End Region

End Module
