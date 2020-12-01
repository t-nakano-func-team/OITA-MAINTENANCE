Module MOD_SYSTEM_INDIVIDUAL_MST_SELECT

End Module

#Region "JM_M_KIND"
Public Module MOD_SYSTEM_INDIVIDUAL_MST_SELECT_JM_M_KIND

#Region "モジュール用・定数"
    Private Const CST_TABLE_NAME_DEFAULT As String = "JM_M_KIND"
#End Region

    Private SRT_CASH_GET_JM_M_KIND_NAME_KIND() As SRT_CASH_INT_INT_STR
    Public Function FUNC_GET_JM_M_KIND_NAME_KIND(
    ByVal ENM_CODE_FLAG As ENM_JM_M_KIND_CODE_FLAG,
    ByVal INT_CODE_KIND As Integer,
    Optional ByVal BLN_CASH As Boolean = False
    ) As String

        Dim STR_RET As String
        STR_RET = ""

        Dim SRT_MY_CASH() As SRT_CASH_INT_INT_STR
        SRT_MY_CASH = SRT_CASH_GET_JM_M_KIND_NAME_KIND
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

        Call SUB_ADD_CASH_INT_INT_STR(SRT_CASH_GET_JM_M_KIND_NAME_KIND, ENM_CODE_FLAG, INT_CODE_KIND, STR_RET)

        Return STR_RET
    End Function

End Module

#End Region

#Region "JM_M_USER"
Public Module MOD_SYSTEM_INDIVIDUAL_MST_SELECT_JM_M_USER

#Region "モジュール用・定数"
    Private Const CST_TABLE_NAME_DEFAULT As String = "JM_M_USER"
#End Region

    Private SRT_CASH_GET_JM_M_USER_NUMBER_USER() As SRT_CASH_INT_INT
    Public Function FUNC_GET_JM_M_USER_NUMBER_USER(
    ByVal INT_CODE_STAFF As Integer,
    Optional ByVal BLN_CASH As Boolean = False
    ) As Integer

        Dim SRT_MY_CASH() As SRT_CASH_INT_INT
        SRT_MY_CASH = SRT_CASH_GET_JM_M_USER_NUMBER_USER
        If BLN_CASH Then
            Dim INT_CASH_INDEX As Integer
            INT_CASH_INDEX = FUNC_SEARCH_CASH_INT_INT(SRT_MY_CASH, INT_CODE_STAFF)
            If INT_CASH_INDEX <> -1 Then
                Return SRT_MY_CASH(INT_CASH_INDEX).VALUE
            End If
        End If

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "NUMBER_USER"
            ReDim .WHERE(1)
            .WHERE(1).COL_NAME = "CODE_STAFF"
            .WHERE(1).VALUE = CInt(INT_CODE_STAFF)
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)
        Dim INT_RET As String
        INT_RET = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_STRING(STR_SQL)

        Call SUB_ADD_CASH_INT_INT(SRT_CASH_GET_JM_M_USER_NUMBER_USER, INT_CODE_STAFF, INT_RET)

        Return INT_RET
    End Function

End Module

#End Region

#Region "JM_M_CUSTOMER"
Public Module MOD_SYSTEM_INDIVIDUAL_MST_SELECT_JM_M_CUSTOMER

#Region "モジュール用・定数"
    Private Const CST_TABLE_NAME_DEFAULT As String = "JM_M_CUSTOMER"
#End Region

    Private SRT_CASH_GET_JM_M_CUSTOMER_NAME_CUSTOMER() As SRT_CASH_INT_INT_STR
    Public Function FUNC_GET_JM_M_CUSTOMER_NAME_CUSTOMER(
    ByVal INT_NUMBER_USER As Integer,
    ByVal INT_CODE_CUSTOMER As Integer,
    Optional ByVal BLN_CASH As Boolean = False
    ) As String

        Dim STR_RET As String
        STR_RET = ""

        Dim SRT_MY_CASH() As SRT_CASH_INT_INT_STR
        SRT_MY_CASH = SRT_CASH_GET_JM_M_CUSTOMER_NAME_CUSTOMER
        If BLN_CASH Then
            Dim INT_CASH_INDEX As Integer
            INT_CASH_INDEX = FUNC_SEARCH_CASH_INT_INT_STR(SRT_MY_CASH, INT_NUMBER_USER, INT_CODE_CUSTOMER)
            If INT_CASH_INDEX <> -1 Then
                Return SRT_MY_CASH(INT_CASH_INDEX).VALUE
            End If
        End If

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "NAME_CUSTOMER"
            ReDim .WHERE(2)
            .WHERE(1).COL_NAME = "NUMBER_USER"
            .WHERE(1).VALUE = CInt(INT_NUMBER_USER)
            .WHERE(2).COL_NAME = "CODE_CUSTOMER"
            .WHERE(2).VALUE = INT_CODE_CUSTOMER
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)
        STR_RET = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_STRING(STR_SQL)

        Call SUB_ADD_CASH_INT_INT_STR(SRT_CASH_GET_JM_M_CUSTOMER_NAME_CUSTOMER, INT_NUMBER_USER, INT_CODE_CUSTOMER, STR_RET)

        Return STR_RET
    End Function

End Module

#End Region

#Region "JM_M_CONNECTION"
Public Module MOD_SYSTEM_INDIVIDUAL_MST_SELECT_JM_M_CONNECTION

#Region "モジュール用・定数"
    Private Const CST_TABLE_NAME_DEFAULT As String = "JM_M_CONNECTION"
#End Region

    Private SRT_CASH_GET_JM_M_CONNECTION_NAME_CONNECTION() As SRT_CASH_INT_STR
    Public Function FUNC_GET_JM_M_CONNECTION_NAME_CONNECTION(
    ByVal INT_CODE_CONNECTION As Integer,
    Optional ByVal BLN_CASH As Boolean = False
    ) As String

        Dim STR_RET As String
        STR_RET = ""

        Dim SRT_MY_CASH() As SRT_CASH_INT_STR
        SRT_MY_CASH = SRT_CASH_GET_JM_M_CONNECTION_NAME_CONNECTION
        If BLN_CASH Then
            Dim INT_CASH_INDEX As Integer
            INT_CASH_INDEX = FUNC_SEARCH_CASH_INT_STR(SRT_MY_CASH, INT_CODE_CONNECTION)
            If INT_CASH_INDEX <> -1 Then
                Return SRT_MY_CASH(INT_CASH_INDEX).VALUE
            End If
        End If

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "NAME_CONNECTION"
            ReDim .WHERE(1)
            .WHERE(1).COL_NAME = "CODE_CONNECTION"
            .WHERE(1).VALUE = CInt(INT_CODE_CONNECTION)
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)
        STR_RET = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_STRING(STR_SQL)

        Call SUB_ADD_CASH_INT_STR(SRT_CASH_GET_JM_M_CONNECTION_NAME_CONNECTION, INT_CODE_CONNECTION, STR_RET)

        Return STR_RET
    End Function

End Module

#End Region

#Region "JM_M_CONNECTION_AUX"
Public Module MOD_SYSTEM_INDIVIDUAL_MST_SELECT_JM_M_CONNECTION_AUX

#Region "モジュール用・定数"
    Private Const CST_TABLE_NAME_DEFAULT As String = "JM_M_CONNECTION_AUX"
#End Region

    Private SRT_CASH_GET_JM_M_CONNECTION_CODE_CONNECTION_REV() As SRT_CASH_INT_INT
    Public Function FUNC_GET_JM_M_CONNECTION_CODE_CONNECTION_REV(
    ByVal INT_CODE_CONNECTION As Integer,
    Optional ByVal BLN_CASH As Boolean = False
    ) As Integer

        Dim SRT_MY_CASH() As SRT_CASH_INT_INT
        SRT_MY_CASH = SRT_CASH_GET_JM_M_CONNECTION_CODE_CONNECTION_REV
        If BLN_CASH Then
            Dim INT_CASH_INDEX As Integer
            INT_CASH_INDEX = FUNC_SEARCH_CASH_INT_INT(SRT_MY_CASH, INT_CODE_CONNECTION)
            If INT_CASH_INDEX <> -1 Then
                Return SRT_MY_CASH(INT_CASH_INDEX).VALUE
            End If
        End If

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "CODE_CONNECTION_REV"
            ReDim .WHERE(1)
            .WHERE(1).COL_NAME = "CODE_CONNECTION"
            .WHERE(1).VALUE = CInt(INT_CODE_CONNECTION)
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)

        Dim INT_RET As String
        INT_RET = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_NUMERIC(STR_SQL)

        Call SUB_ADD_CASH_INT_INT(SRT_CASH_GET_JM_M_CONNECTION_CODE_CONNECTION_REV, INT_CODE_CONNECTION, INT_RET)

        Return INT_RET
    End Function
End Module

#End Region