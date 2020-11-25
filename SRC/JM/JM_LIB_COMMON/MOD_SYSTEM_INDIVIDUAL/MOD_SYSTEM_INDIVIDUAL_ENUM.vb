Public Module MOD_SYSTEM_INDIVIDUAL_ENUM
    'テーブルJM_M_KINDのCODE_FLAG
    Public Enum ENM_JM_M_KIND_CODE_FLAG
        FLAG_INVOICE_FIXDAY = 10 '請求締日付
        FLAG_OWNER = 11 '形式
        KIND_RATE_VAT = 13 '消費税
        FLAG_CONTRACT = 14 '契約形態
        FLAG_DEPOSIT_DONE = 15
        FLAG_OUTPUT = 16
        FLAG_WORK = 17
        FLAG_DONE = 18 '済み／未済み　汎用
        KIND_SORT_CHECK_DEPOSIT = 19
        KIND_TARGET_RECEIVABLE = 20 '未収金対象
        FLAG_ACCOUNT = 21 '科目種別
        FLAG_INVALID = 22 '有効無効フラグ
        FLAG_INVALID_SHORT = 23 '有効無効フラグ（短）
        FLAG_CONTINUE = 24 '自動継続
        FLAG_INVOICE_METHOD = 25 '請求方法
    End Enum

    Public Enum ENM_SYSTEM_INDIVIDUAL_FLAG_INVOICE_FIXDAY
        FIX_10 = 10
        FIX_20 = 20
        FIX_25 = 25
        FIX_LAST = 99
    End Enum

    Public Enum ENM_SYSTEM_INDIVIDUAL_FLAG_OWNER
        NORMAL = 1
        SPOT = 2
    End Enum

    Public Enum ENM_SYSTEM_INDIVIDUAL_FLAG_CONTRACT
        REGULAR = 1
        SPOT = 2
    End Enum

    Public Enum ENM_SYSTEM_INDIVIDUAL_FLAG_DEPOSIT_DONE
        NOT_DONE = 0
        DONE = 1
    End Enum

    Public Enum ENM_SYSTEM_INDIVIDUAL_FLAG_OUTPUT
        NOT_DONE = 0
        DONE = 1
    End Enum

    Public Enum ENM_SYSTEM_INDIVIDUAL_FLAG_ACCOUNT
        FLAG_SALE = 1
        FLAG_DEPOSIT = 2
        FLAG_COST = 3
        KIND_PAYEE = 4
        KIND_VAT = 5
        KIND_FEE = 6
    End Enum

    Public Enum ENM_SYSTEM_INDIVIDUAL_FLAG_DONE
        NOT_DONE = 0
        DONE = 1
    End Enum

    Public Enum ENM_SYSTEM_INDIVIDUAL_KIND_SORT_CHECK_DEPOSIT
        DATE_ACTIVE = 1
        DATE_DEPOSIT = 2
    End Enum

    Public Enum ENM_SYSTEM_INDIVIDUAL_FLAG_WORK
        ALWAYS = 1
        REGULAR = 2
    End Enum

    Public Enum ENM_SYSTEM_INDIVIDUAL_KIND_TARGET_RECEIVABLE
        BALANCE_HAVE = 1
        BALANCE_NONE = 2
    End Enum

    Public Enum ENM_SYSTEM_INDIVIDUAL_FLAG_INVALID
        NORMAL = 0
        DELETE = 1
    End Enum

    Public Enum ENM_SYSTEM_INDIVIDUAL_FLAG_CONTINUE
        NO_CONTINUE = 0 '継続しない
        AUTO_CONTINUE = 1 '自動継続
    End Enum

    Public Enum ENM_SYSTEM_INDIVIDUAL_FLAG_INVOICE_METHOD
        NONE = 0
    End Enum

    Public Enum ENM_MAKE_DIR_UNIT 'ディレクトリ作成単位
        NONE = 0
        YEARLY = 1
        MONTHLY = 2
        DAYLY = 3
    End Enum
End Module
