Public Module MOD_SYSTEM_INDIVIDUAL_CONST

#Region "最小値・最大値関連"

    '顧客コード
    Public Const CST_SYSTEM_CODE_CUSTOMER_MIN_VALUE As Integer = 1
    Public Const CST_SYSTEM_CODE_CUSTOMER_MAX_VALUE As Integer = 999999
    Public INT_SYSTEM_CODE_CUSTOMER_MAX_LENGTH As Integer = (CST_SYSTEM_CODE_CUSTOMER_MAX_VALUE.ToString.Length)

#End Region

#Region "種別特定関連"

#End Region

＃Region "システムコード"
    Public Const CST_SYSTEM_INDIVIDUAL_SYSTEM_CODE = 2 '人脈管理
#End Region

End Module
