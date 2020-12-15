﻿Public Module MOD_SYSTEM_INDIVIDUAL_CONST

#Region "最小値・最大値関連"

    'オーナーコード
    Public Const CST_SYSTEM_CODE_OWNER_MIN_VALUE As Integer = 1
    Public Const CST_SYSTEM_CODE_OWNER_MAX_VALUE As Integer = 999999
    Public INT_SYSTEM_CODE_OWNER_MAX_LENGTH As Integer = (CST_SYSTEM_CODE_OWNER_MAX_VALUE.ToString.Length)

    '作業コード
    Public Const CST_SYSTEM_CODE_MAINTENANCE_MIN_VALUE As Integer = 1
    Public Const CST_SYSTEM_CODE_MAINTENANCE_MAX_VALUE As Integer = 9999
    Public INT_SYSTEM_CODE_MAINTENANCE_MAX_LENGTH As Integer = (CST_SYSTEM_CODE_MAINTENANCE_MAX_VALUE.ToString.Length)

    '部署コード
    Public Const CST_SYSTEM_CODE_SECTION_MIN_VALUE As Integer = 1
    Public Const CST_SYSTEM_CODE_SECTIONK_MAX_VALUE As Integer = 999
    Public INT_SYSTEM_CODE_SECTION_MAX_LENGTH As Integer = (CST_SYSTEM_CODE_SECTIONK_MAX_VALUE.ToString.Length)

    '科目コード
    Public Const CST_SYSTEM_CODE_ACCOUNT_MIN_VALUE As Integer = 1
    Public Const CST_SYSTEM_CODE_ACCOUNT_MAX_VALUE As Integer = 9999
    Public INT_SYSTEM_CODE_ACCOUNT_MAX_LENGTH As Integer = (CST_SYSTEM_CODE_ACCOUNT_MAX_VALUE.ToString.Length)

    '科目連携コード
    Public Const CST_SYSTEM_CODE_ACCOUNT_CONNECT_MIN_VALUE As Integer = 1
    Public Const CST_SYSTEM_CODE_ACCOUNT_CONNECT_MAX_VALUE As Integer = 9999
    Public INT_SYSTEM_CODE_ACCOUNT_CONNECT_MAX_LENGTH As Integer = (CST_SYSTEM_CODE_ACCOUNT_CONNECT_MAX_VALUE.ToString.Length)

    '種別コード
    Public Const CST_SYSTEM_CODE_KIND_MIN_VALUE As Integer = 1
    Public Const CST_SYSTEM_CODE_KIND_MAX_VALUE As Integer = 99
    Public INT_SYSTEM_CODE_KIND_MAX_LENGTH As Integer = (CST_SYSTEM_CODE_KIND_MAX_VALUE.ToString.Length)

    '契約番号
    Public Const CST_SYSTEM_NUMBER_CONTRACT_MIN_VALUE As Integer = 1
    Public Const CST_SYSTEM_NUMBER_CONTRACT_MAX_VALUE As Integer = 999999
    Public INT_SYSTEM_NUMBER_CONTRACT_MAX_LENGTH As Integer = (CST_SYSTEM_NUMBER_CONTRACT_MAX_VALUE.ToString.Length)

    '契約連番
    Public Const CST_SYSTEM_SERIAL_CONTRACT_MIN_VALUE As Integer = 1
    Public Const CST_SYSTEM_SERIAL_CONTRACT_MAX_VALUE As Integer = 99
    Public INT_SYSTEM_SERIAL_CONTRACT_MAX_LENGTH As Integer = (CST_SYSTEM_SERIAL_CONTRACT_MAX_VALUE.ToString.Length)

    '請求書番号
    Public Const CST_SYSTEM_NUMBER_LIST_INVOICE_MIN_VALUE As Integer = 1
    Public Const CST_SYSTEM_NUMBER_LIST_INVOICE_MAX_VALUE As Integer = 99
    Public INT_SYSTEM_NUMBER_LIST_INVOICE_MAX_LENGTH As Integer = (CST_SYSTEM_NUMBER_LIST_INVOICE_MAX_VALUE.ToString.Length)

    '入金連番
    Public Const CST_SYSTEM_SERIAL_DEPOSIT_MIN_VALUE As Integer = 1
    Public Const CST_SYSTEM_SERIAL_DEPOSIT_MAX_VALUE As Integer = 999
    Public INT_SYSTEM_SERIAL_DEPOSIT_MAX_LENGTH As Integer = (CST_SYSTEM_SERIAL_DEPOSIT_MAX_VALUE.ToString.Length)
#End Region

#Region "種別特定関連"
    Public Const CST_SYSTEM_ACCOUNT_CODE_KIND_ORDINARY_DEPOSIT As Integer = 1 '普通預金
    Public Const CST_SYSTEM_ACCOUNT_CODE_KIND_ORDINARY_VAT As Integer = 1 '仮払消費税
    Public Const CST_SYSTEM_ACCOUNT_CODE_KIND_ORDINARY_FEE As Integer = 1 '支払手数料

#End Region

＃Region "システムコード"
    Public Const CST_SYSTEM_INDIVIDUAL_SYSTEM_CODE = 1 '基幹業務
#End Region

End Module
