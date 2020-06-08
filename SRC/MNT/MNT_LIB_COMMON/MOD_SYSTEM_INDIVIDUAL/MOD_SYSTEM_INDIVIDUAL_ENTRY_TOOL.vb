Public Module MOD_SYSTEM_INDIVIDUAL_ENTRY_TOOL

#Region "名称取得"
    Public Sub SUB_GET_NAME_OWNER_INPUT(ByRef TXT_INPUT As System.Windows.Forms.TextBox)
        Dim CTL_NAME As System.Windows.Forms.Label
        CTL_NAME = FUNC_GET_CONTROL_NAME_LABEL(TXT_INPUT)
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
#End Region

#Region "請求関連"
    Public Function FUNC_MAKE_NEW_INVOICE(
    ByVal INT_NUMBER_CONTRACT As Integer, ByVal INT_SERIAL_CONTRACT As Integer, ByVal DAT_DATE_INVOICE As DateTime
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
            .KINGAKU_INVOICE_DETAIL = SRT_RECORD_CONTRACT.DATA.KINGAKU_CONTRACT
            .KINGAKU_INVOICE_VAT = FUNC_GET_KINGAKU_VAT_FROM_DETAIL(.KINGAKU_INVOICE_DETAIL, .DATE_INVOICE)
            .FLAG_DEPOSIT_DONE = ENM_SYSTEM_INDIVIDUAL_FLAG_DEPOSIT_DONE.NOT_DONE
            .DATE_DEPOSIT = cstVB_DATE_MAX
            .KINGAKU_FEE_DETAIL = 0
            .KINGAKU_FEE_VAT = 0
            .FLAG_OUTPUT_DONE = ENM_SYSTEM_INDIVIDUAL_FLAG_DEPOSIT_DONE.NOT_DONE
        End With

        If Not FUNC_INSERT_TABLE_MNT_T_INVOICE(SRT_RECORD) Then
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

    Public Function FUNC_GETTOTAL_KINGAKU_INVOICE_FROM_REGULAR(
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
#End Region
End Module
