Public Module MOD_SYSTEM_INDIVIDUAL_ENUM
    'テーブルMNT_M_KINDのCODE_FLAG
    Public Enum ENM_MNT_M_KIND_CODE_FLAG
        KIND_FIXED_DATE = 10 '請求締日付
        KIND_OWNER = 11 '形式
        CODE_SECTION = 12 '部署
        KIND_RATE_VAT = 13 '消費税
        KIND_CONTRACT = 14 '契約形態
        FLAG_DEPOSIT_DONE = 15
        FLAG_OUTPUT_DONE = 16
        KIND_WORK = 17
        FLAG_DONE = 18 '済み／未済み　汎用
        KIND_SORT_CHECK_DEPOSIT = 19
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

    Public Enum ENM_SYSTEM_INDIVIDUAL_KIND_ACCOUNT
        KIND_DEPOSIT = 1
        KIND_COST = 2
        KIND_PAYEE = 3
    End Enum

    Public Enum ENM_SYSTEM_INDIVIDUAL_FLAG_DONE
        NOT_DONE = 0
        DONE = 1
    End Enum

    Public Enum ENM_SYSTEM_INDIVIDUAL_KIND_SORT_CHECK_DEPOSIT
        DATE_ACTIVE = 1
        DATE_DEPOSIT = 2
    End Enum
End Module
