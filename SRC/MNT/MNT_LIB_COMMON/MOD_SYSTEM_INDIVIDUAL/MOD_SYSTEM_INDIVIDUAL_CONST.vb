﻿Public Module MOD_SYSTEM_INDIVIDUAL_CONST

#Region "最小値・最大値関連"

    'オーナーコード
    Public Const CST_SYSTEM_CODE_OWNER_MIN_VALUE As Integer = 1
    Public Const CST_SYSTEM_CODE_OWNER_MAX_VALUE As Integer = 999999
    Public INT_SYSTEM_CODE_OWNER_MAX_LENGTH As Integer = (CST_SYSTEM_CODE_OWNER_MAX_VALUE.ToString.Length)

    '契約番号
    Public Const CST_SYSTEM_NUMBER_CONTRACT_MIN_VALUE As Integer = 1
    Public Const CST_SYSTEM_NUMBER_CONTRACT_MAX_VALUE As Integer = 999999
    Public INT_SYSTEM_NUMBER_CONTRACT_MAX_LENGTH As Integer = (CST_SYSTEM_NUMBER_CONTRACT_MAX_VALUE.ToString.Length)

    '契約連番
    Public Const CST_SYSTEM_SERIAL_CONTRACT_MIN_VALUE As Integer = 1
    Public Const CST_SYSTEM_SERIAL_CONTRACT_MAX_VALUE As Integer = 99
    Public INT_SYSTEM_SERIAL_CONTRACT_MAX_LENGTH As Integer = (CST_SYSTEM_SERIAL_CONTRACT_MAX_VALUE.ToString.Length)

#End Region

#Region "種別特定関連"
    Public Const CST_SYSTEM_ACCOUNT_CODE_KIND_ORDINARY_DEPOSIT As Integer = 1 '普通預金
#End Region

End Module
