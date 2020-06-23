Public Module MOD_SYSTEM_TOTAL_ENTRY_TOOL

    Public Function FUNC_GET_KINGAKU_VAT_FROM_DETAIL(ByVal LNG_DETAIL As Long, ByVal DAT_CALC As DateTime) As Long '消費税の計算（本体金額から）
        Dim DEC_RATE As Decimal

        Dim LNG_CALC As Long
        Dim INT_MINUS As Integer
        If LNG_DETAIL < 0 Then
            LNG_CALC = -1 * LNG_DETAIL
            INT_MINUS = -1
        Else
            LNG_CALC = LNG_DETAIL
            INT_MINUS = 1
        End If

        DEC_RATE = FUNC_SYSTEM_TOTAL_GET_RATE_VAT(DAT_CALC)
        Dim DEC_TEMP As Decimal
        DEC_TEMP = CDec(LNG_CALC) * DEC_RATE
        DEC_TEMP /= 100

        Dim LNG_RET As Long
        'LNG_RET = CLng(Math.Round(DEC_TEMP, MidpointRounding.AwayFromZero)) '四捨五入
        LNG_RET = CLng(Math.Floor(DEC_TEMP)) '切捨


        LNG_RET = INT_MINUS * LNG_RET
        Return LNG_RET
    End Function

    Public Function FUNC_SYSTEM_TOTAL_GET_RATE_VAT(ByVal DAT_CALC As DateTime) As Decimal

        For i = 1 To (SRT_MNG_M_RATE_VAT_RECORD.Length - 1)
            With SRT_MNG_M_RATE_VAT_RECORD(i)
                If .DATA.DATE_START <= DAT_CALC And DAT_CALC <= .DATA.DATE_END Then
                    Dim DEC_RATE As Decimal
                    DEC_RATE = FUNC_GET_MNG_M_VALUE_VALUE_KIND(ENM_MNG_M_KIND_CODE_FLAG.FLAG_RATE_VAT, .DATA.FLAG_RATE_VAT, True)
                    Return DEC_RATE
                End If
            End With
        Next

        Return 0.00
    End Function
End Module
