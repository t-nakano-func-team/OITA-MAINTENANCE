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

End Module
