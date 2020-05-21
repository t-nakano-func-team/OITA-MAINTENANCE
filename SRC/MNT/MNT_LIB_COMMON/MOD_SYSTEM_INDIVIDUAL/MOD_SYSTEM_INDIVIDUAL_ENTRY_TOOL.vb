Public Module MOD_SYSTEM_INDIVIDUAL_ENTRY_TOOL

#Region "CONTRACT"
    Public Function FUNC_GET_NUMBER_CONTRACT_NEW(ByVal BLN_CASH As Boolean) As Integer
        Dim INT_RET As Integer

        INT_RET = 0

        For i = CST_SYSTEM_NUMBER_CONTRACT_MIN_VALUE To CST_SYSTEM_NUMBER_CONTRACT_MAX_VALUE
            Dim BLN_CHECK As Boolean
            BLN_CHECK = False

            If Not BLN_CHECK Then
                INT_RET = i
                Exit For
            End If
        Next

        Return INT_RET
    End Function
#End Region

End Module
