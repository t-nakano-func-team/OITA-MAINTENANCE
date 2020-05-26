Public Module MOD_SYSTEM_INDIVIDUAL_MST_SELECT

End Module

#Region "MNT_M_KIND"
Public Module MOD_SYSTEM_INDIVIDUAL_MST_SELECT_MNT_M_KIND

#Region "モジュール用・定数"
    Private Const CST_TABLE_NAME_DEFAULT As String = "MNT_M_KIND"
#End Region

    Private SRT_CASH_GET_MNT_M_KIND_NAME_KIND() As SRT_CASH_INT_INT_STR
    Public Function FUNC_GET_MNT_M_KIND_NAME_KIND(
    ByVal ENM_CODE_FLAG As ENM_MNT_M_KIND_CODE_FLAG,
    ByVal INT_CODE_KIND As Integer,
    Optional ByVal BLN_CASH As Boolean = False
    ) As String

        Dim STR_RET As String
        STR_RET = ""

        Dim SRT_MY_CASH() As SRT_CASH_INT_INT_STR
        SRT_MY_CASH = SRT_CASH_GET_MNT_M_KIND_NAME_KIND
        If BLN_CASH Then
            Dim INT_CASH_INDEX As Integer
            INT_CASH_INDEX = FUNC_SEARCH_CASH_INT_INT_STR(SRT_MY_CASH, ENM_CODE_FLAG, INT_CODE_KIND)
            If INT_CASH_INDEX <> -1 Then
                Return SRT_MY_CASH(INT_CASH_INDEX).VALUE
            End If
        End If

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "NAME_KIND"
            ReDim .WHERE(2)
            .WHERE(1).COL_NAME = "CODE_FLAG"
            .WHERE(1).VALUE = CInt(ENM_CODE_FLAG.GetHashCode)
            .WHERE(2).COL_NAME = "CODE_KIND"
            .WHERE(2).VALUE = INT_CODE_KIND
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)
        STR_RET = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_STRING(STR_SQL)

        Call SUB_ADD_CASH_INT_INT_STR(SRT_CASH_GET_MNT_M_KIND_NAME_KIND, ENM_CODE_FLAG, INT_CODE_KIND, STR_RET)

        Return STR_RET
    End Function

End Module

#End Region

#Region "MNT_M_OWNER"
Public Module MOD_SYSTEM_INDIVIDUAL_MST_SELECT_MNT_M_OWNER

#Region "モジュール用・定数"
    Private Const CST_TABLE_NAME_DEFAULT As String = "MNT_M_OWNER"
#End Region

    Private SRT_CASH_GET_MNT_M_OWNER_NAME_OWNER() As SRT_CASH_INT_STR
    Public Function FUNC_GET_MNT_M_OWNER_NAME_OWNER(
    ByVal INT_CODE_OWNER As Integer,
    Optional ByVal BLN_CASH As Boolean = False
    ) As String

        Dim SRT_MY_CASH() As SRT_CASH_INT_STR
        SRT_MY_CASH = SRT_CASH_GET_MNT_M_OWNER_NAME_OWNER
        If BLN_CASH Then
            Dim INT_CASH_INDEX As Integer
            INT_CASH_INDEX = FUNC_SEARCH_CASH_INT_STR(SRT_MY_CASH, INT_CODE_OWNER)
            If INT_CASH_INDEX <> -1 Then
                Return SRT_MY_CASH(INT_CASH_INDEX).VALUE
            End If
        End If

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "NAME_OWNER"
            ReDim .WHERE(1)
            .WHERE(1).COL_NAME = "CODE_OWNER"
            .WHERE(1).VALUE = INT_CODE_OWNER
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)

        Dim STR_RET As String
        STR_RET = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_STRING(STR_SQL)

        Call SUB_ADD_CASH_INT_STR(SRT_CASH_GET_MNT_M_OWNER_NAME_OWNER, INT_CODE_OWNER, STR_RET)

        Return STR_RET
    End Function

    Private SRT_CASH_GET_MNT_M_OWNER_KIND_OWNER() As SRT_CASH_INT_INT
    Public Function FUNC_GET_MNT_M_OWNER_KIND_OWNER(
    ByVal INT_CODE_OWNER As Integer,
    Optional ByVal BLN_CASH As Boolean = False
    ) As Integer

        Dim SRT_MY_CASH() As SRT_CASH_INT_INT
        SRT_MY_CASH = SRT_CASH_GET_MNT_M_OWNER_KIND_OWNER
        If BLN_CASH Then
            Dim INT_CASH_INDEX As Integer
            INT_CASH_INDEX = FUNC_SEARCH_CASH_INT_INT(SRT_MY_CASH, INT_CODE_OWNER)
            If INT_CASH_INDEX <> -1 Then
                Return SRT_MY_CASH(INT_CASH_INDEX).VALUE
            End If
        End If

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "KIND_OWNER"
            ReDim .WHERE(1)
            .WHERE(1).COL_NAME = "CODE_OWNER"
            .WHERE(1).VALUE = INT_CODE_OWNER
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)

        Dim INT_RET As Integer
        INT_RET = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_NUMERIC(STR_SQL)

        Call SUB_ADD_CASH_INT_INT(SRT_CASH_GET_MNT_M_OWNER_KIND_OWNER, INT_CODE_OWNER, INT_RET)

        Return INT_RET
    End Function


    Private SRT_CASH_GET_MNT_M_OWNER_NAME_ADDRESS_01() As SRT_CASH_INT_STR
    Public Function FUNC_GET_MNT_M_OWNER_NAME_ADDRESS_01(
    ByVal INT_CODE_OWNER As Integer,
    Optional ByVal BLN_CASH As Boolean = False
    ) As String

        Dim SRT_MY_CASH() As SRT_CASH_INT_STR
        SRT_MY_CASH = SRT_CASH_GET_MNT_M_OWNER_NAME_ADDRESS_01
        If BLN_CASH Then
            Dim INT_CASH_INDEX As Integer
            INT_CASH_INDEX = FUNC_SEARCH_CASH_INT_STR(SRT_MY_CASH, INT_CODE_OWNER)
            If INT_CASH_INDEX <> -1 Then
                Return SRT_MY_CASH(INT_CASH_INDEX).VALUE
            End If
        End If

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "NAME_ADDRESS_01"
            ReDim .WHERE(1)
            .WHERE(1).COL_NAME = "CODE_OWNER"
            .WHERE(1).VALUE = INT_CODE_OWNER
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)

        Dim STR_RET As String
        STR_RET = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_STRING(STR_SQL)

        Call SUB_ADD_CASH_INT_STR(SRT_CASH_GET_MNT_M_OWNER_NAME_ADDRESS_01, INT_CODE_OWNER, STR_RET)

        Return STR_RET
    End Function

    Private SRT_CASH_GET_MNT_M_OWNER_NAME_ADDRESS_02() As SRT_CASH_INT_STR
    Public Function FUNC_GET_MNT_M_OWNER_NAME_ADDRESS_02(
    ByVal INT_CODE_OWNER As Integer,
    Optional ByVal BLN_CASH As Boolean = False
    ) As String

        Dim SRT_MY_CASH() As SRT_CASH_INT_STR
        SRT_MY_CASH = SRT_CASH_GET_MNT_M_OWNER_NAME_ADDRESS_02
        If BLN_CASH Then
            Dim INT_CASH_INDEX As Integer
            INT_CASH_INDEX = FUNC_SEARCH_CASH_INT_STR(SRT_MY_CASH, INT_CODE_OWNER)
            If INT_CASH_INDEX <> -1 Then
                Return SRT_MY_CASH(INT_CASH_INDEX).VALUE
            End If
        End If

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "NAME_ADDRESS_02"
            ReDim .WHERE(1)
            .WHERE(1).COL_NAME = "CODE_OWNER"
            .WHERE(1).VALUE = INT_CODE_OWNER
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)

        Dim STR_RET As String
        STR_RET = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_STRING(STR_SQL)

        Call SUB_ADD_CASH_INT_STR(SRT_CASH_GET_MNT_M_OWNER_NAME_ADDRESS_02, INT_CODE_OWNER, STR_RET)

        Return STR_RET
    End Function

End Module

#End Region

#Region "MNT_T_CONTRACT"

Public Module MOD_SYSTEM_INDIVIDUAL_MST_SELECT_MNT_T_CONTRACT

#Region "モジュール用・定数"
    Private Const CST_TABLE_NAME_DEFAULT As String = "MNT_T_CONTRACT"
#End Region

    '契約番号チェック
    Private SRT_CASH_CHECK_MNT_T_CONTRACT_NUMBER_CONTRACT() As SRT_CASH_INT_BOOL
    Public Function FUNC_CHECK_MNT_T_CONTRACT_NUMBER_CONTRACT(
    ByVal INT_NUMBER_CONTRACT As Integer,
    Optional ByVal BLN_CASH As Boolean = False
    ) As Boolean

        Dim SRT_MY_CASH() As SRT_CASH_INT_BOOL
        SRT_MY_CASH = SRT_CASH_CHECK_MNT_T_CONTRACT_NUMBER_CONTRACT
        If BLN_CASH Then
            Dim INT_CASH_INDEX As Integer
            INT_CASH_INDEX = FUNC_SEARCH_CASH_INT_BOOL(SRT_MY_CASH, INT_NUMBER_CONTRACT)
            If INT_CASH_INDEX <> -1 Then
                Return SRT_MY_CASH(INT_CASH_INDEX).VALUE
            End If
        End If

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "COUNT(*)"
            ReDim .WHERE(1)
            .WHERE(1).COL_NAME = "NUMBER_CONTRACT"
            .WHERE(1).VALUE = INT_NUMBER_CONTRACT
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)

        Dim INT_CNT As Integer
        INT_CNT = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_NUMERIC(STR_SQL, 0)

        Dim BLN_RET As Boolean
        BLN_RET = (INT_CNT > 0)
        Call SUB_ADD_CASH_INT_BOOL(SRT_CASH_CHECK_MNT_T_CONTRACT_NUMBER_CONTRACT, INT_NUMBER_CONTRACT, BLN_RET)

        Return BLN_RET
    End Function

    '最大契約番号取得
    Public Function FUNC_GET_MNT_T_CONTRACT_MAX_NUMBER_CONTRACT(
    ) As Integer

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "MAX(NUMBER_CONTRACT)"
            ReDim .WHERE(0)
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)

        Dim INT_RET As Integer
        INT_RET = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_NUMERIC(STR_SQL, 0)

        Return INT_RET
    End Function
End Module


#End Region