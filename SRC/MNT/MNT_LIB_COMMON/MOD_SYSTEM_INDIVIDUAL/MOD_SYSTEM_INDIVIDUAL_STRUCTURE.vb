﻿Public Module MOD_SYSTEM_INDIVIDUAL_STRUCTURE

#Region "構造体：契約"
    Public Structure SRT_NUMBER_SERIAL_CONTRACT
        Public NUMBER_CONTRACT As Integer
        Public SERIAL_CONTRACT As Integer
    End Structure
#End Region

#Region "構造体：請求"
    Public Structure SRT_NUMBER_SERIAL_INVOICE
        Public NUMBER_CONTRACT As Integer
        Public SERIAL_CONTRACT As Integer
        Public SERIAL_INVOICE As Integer
    End Structure
#End Region

#Region "構造体：期間"
    Public Structure SRT_DATE_PERIOD
        Public DATE_FROM As DateTime
        Public DATE_TO As DateTime
    End Structure

    Public Structure SRT_YYYYMM_PERIOD
        Public YYYYMM_FROM As Integer
        Public YYYYMM_TO As Integer
    End Structure
#End Region

End Module