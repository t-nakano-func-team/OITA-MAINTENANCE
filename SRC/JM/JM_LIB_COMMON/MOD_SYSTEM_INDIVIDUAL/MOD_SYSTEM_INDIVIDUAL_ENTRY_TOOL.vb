Public Module MOD_SYSTEM_INDIVIDUAL_ENTRY_TOOL

#Region "名称取得"
    Public Sub SUB_GET_NAME_CUSTOMER_INPUT(ByRef TXT_INPUT As System.Windows.Forms.TextBox)
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

        CTL_NAME.Text = FUNC_GET_JM_M_CUSTOMER_NAME_CUSTOMER(INT_SYSTEM_INDIVIDUAL_NUMBER_USER, INT_CODE, True)
    End Sub
#End Region

#Region "関連性関係"
    Public Function FUNC_GET_CODE_CONNECTION_REV(ByVal INT_CODE_CONNECTION As Integer) As Integer
        Dim INT_CODE_CONNECTION_REV_MST As Integer
        INT_CODE_CONNECTION_REV_MST = FUNC_GET_JM_M_CONNECTION_CODE_CONNECTION_REV(INT_CODE_CONNECTION, True)

        Dim INT_RET As Integer
        If INT_CODE_CONNECTION_REV_MST <= 0 Then
            INT_RET = INT_CODE_CONNECTION
        Else
            INT_RET = INT_CODE_CONNECTION_REV_MST
        End If

        Return INT_RET
    End Function

#End Region
End Module
