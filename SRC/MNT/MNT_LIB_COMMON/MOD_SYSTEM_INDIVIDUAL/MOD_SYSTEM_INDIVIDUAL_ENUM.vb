﻿Public Module MOD_SYSTEM_INDIVIDUAL_ENUM
    'テーブルMNT_M_KINDのCODE_FLAG
    Public Enum ENM_MNT_M_KIND_CODE_FLAG
        KIND_FIXED_DATE = 10 '請求締日付
        KIND_OWNER = 11 '形式
        CODE_SECTION = 12 '部署
        KIND_RATE_VAT = 13 '消費税
        KIND_CONTRACT = 14 '契約形態
        FLAG_DEPOSIT_DONE = 15
        FLAG_OUTPUT_DONE = 16
    End Enum

    Public Enum ENM_SYSTEM_INDIVIDUAL_KIND_FIXED_DATE
        FIX_10 = 10
        FIX_20 = 20
        FIX_25 = 25
        FIX_LAST = 99
    End Enum

    Public Enum ENM_SYSTEM_INDIVIDUAL_KIND_OWNER
        NORMAL = 1
        SPOT = 2
    End Enum

    Public Enum ENM_SYSTEM_INDIVIDUAL_KIND_CONTRACT
        SPOT = 1
        REGULAR = 2
    End Enum

    Public Enum ENM_SYSTEM_INDIVIDUAL_FLAG_DEPOSIT_DONE
        NOT_DONE = 0
        DONE = 1
    End Enum

    Public Enum ENM_SYSTEM_INDIVIDUAL_FLAG_OUTPUT_DONE
        NOT_DONE = 0
        DONE = 1
    End Enum
End Module
