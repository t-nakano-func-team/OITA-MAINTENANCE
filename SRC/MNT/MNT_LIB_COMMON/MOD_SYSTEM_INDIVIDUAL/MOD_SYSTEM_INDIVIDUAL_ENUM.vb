Public Module MOD_SYSTEM_INDIVIDUAL_ENUM
    'テーブルMNT_M_KINDのCODE_FLAG
    Public Enum ENM_MNT_M_KIND_CODE_FLAG
        KIND_FIXED_DATE = 10 '請求締日付
        KIND_OWNER = 11 '形式
        CODE_SECTION = 12 '部署
    End Enum

    Public Enum ENM_SYSTEM_INDIVIDUAL_KIND_OWNER
        NORMAL = 1
        SPOT = 2
    End Enum

    Public Enum ENM_SYSTEM_INDIVIDUAL_KIND_CONTRACT
        SPOT = 1
        REGULAR = 2
    End Enum

End Module
