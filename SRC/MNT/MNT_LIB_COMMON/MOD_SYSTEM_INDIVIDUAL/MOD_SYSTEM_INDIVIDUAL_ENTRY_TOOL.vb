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
#End Region
End Module
