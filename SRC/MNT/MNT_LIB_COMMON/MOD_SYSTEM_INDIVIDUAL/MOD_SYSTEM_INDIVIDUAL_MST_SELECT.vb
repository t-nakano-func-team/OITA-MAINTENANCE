﻿Public Module MOD_SYSTEM_INDIVIDUAL_MST_SELECT

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

    Private SRT_CASH_GET_MNT_M_OWNER_FLAG_OWNER() As SRT_CASH_INT_INT
    Public Function FUNC_GET_MNT_M_OWNER_FLAG_OWNER(
    ByVal INT_CODE_OWNER As Integer,
    Optional ByVal BLN_CASH As Boolean = False
    ) As Integer

        Dim SRT_MY_CASH() As SRT_CASH_INT_INT
        SRT_MY_CASH = SRT_CASH_GET_MNT_M_OWNER_FLAG_OWNER
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
            .COL_NAME = "FLAG_OWNER"
            ReDim .WHERE(1)
            .WHERE(1).COL_NAME = "CODE_OWNER"
            .WHERE(1).VALUE = INT_CODE_OWNER
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)

        Dim INT_RET As Integer
        INT_RET = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_NUMERIC(STR_SQL)

        Call SUB_ADD_CASH_INT_INT(SRT_CASH_GET_MNT_M_OWNER_FLAG_OWNER, INT_CODE_OWNER, INT_RET)

        Return INT_RET
    End Function

    Private SRT_CASH_GET_MNT_M_OWNER_CODE_POST() As SRT_CASH_INT_INT
    Public Function FUNC_GET_MNT_M_OWNER_CODE_POST(
    ByVal INT_CODE_OWNER As Integer,
    Optional ByVal BLN_CASH As Boolean = False
    ) As Integer

        Dim SRT_MY_CASH() As SRT_CASH_INT_INT
        SRT_MY_CASH = SRT_CASH_GET_MNT_M_OWNER_CODE_POST
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
            .COL_NAME = "CODE_POST"
            ReDim .WHERE(1)
            .WHERE(1).COL_NAME = "CODE_OWNER"
            .WHERE(1).VALUE = INT_CODE_OWNER
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)

        Dim INT_RET As String
        INT_RET = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_NUMERIC(STR_SQL, 0)

        Call SUB_ADD_CASH_INT_INT(SRT_CASH_GET_MNT_M_OWNER_CODE_POST, INT_CODE_OWNER, INT_RET)

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


    Private SRT_CASH_GET_MNT_M_OWNER_FLAG_INVOICE_FIXDAY() As SRT_CASH_INT_INT
    Public Function FUNC_GET_MNT_M_OWNER_FLAG_INVOICE_FIXDAY(
    ByVal INT_CODE_OWNER As Integer,
    Optional ByVal BLN_CASH As Boolean = False
    ) As Integer

        Dim SRT_MY_CASH() As SRT_CASH_INT_INT
        SRT_MY_CASH = SRT_CASH_GET_MNT_M_OWNER_FLAG_INVOICE_FIXDAY
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
            .COL_NAME = "FLAG_INVOICE_FIXDAY"
            ReDim .WHERE(1)
            .WHERE(1).COL_NAME = "CODE_OWNER"
            .WHERE(1).VALUE = INT_CODE_OWNER
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)

        Dim INT_RET As Integer
        INT_RET = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_NUMERIC(STR_SQL)

        Call SUB_ADD_CASH_INT_INT(SRT_CASH_GET_MNT_M_OWNER_FLAG_INVOICE_FIXDAY, INT_CODE_OWNER, INT_RET)

        Return INT_RET
    End Function

    Private SRT_CASH_CHECK_MNT_M_OWNER() As SRT_CASH_INT_BOOL
    Public Function FUNC_CHECK_MNT_M_OWNER(
    ByVal INT_CODE_OWNER As Integer,
    Optional ByVal BLN_CASH As Boolean = False
    ) As Integer

        Dim SRT_MY_CASH() As SRT_CASH_INT_BOOL
        SRT_MY_CASH = SRT_CASH_CHECK_MNT_M_OWNER
        If BLN_CASH Then
            Dim INT_CASH_INDEX As Integer
            INT_CASH_INDEX = FUNC_SEARCH_CASH_INT_BOOL(SRT_MY_CASH, INT_CODE_OWNER)
            If INT_CASH_INDEX <> -1 Then
                Return SRT_MY_CASH(INT_CASH_INDEX).VALUE
            End If
        End If

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "COUNT(*)"
            ReDim .WHERE(1)
            .WHERE(1).COL_NAME = "CODE_OWNER"
            .WHERE(1).VALUE = INT_CODE_OWNER
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)

        Dim INT_COUNT As Integer
        INT_COUNT = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_NUMERIC(STR_SQL, 0)

        Dim BLN_RET As Boolean
        BLN_RET = (INT_COUNT > 0)
        Call SUB_ADD_CASH_INT_BOOL(SRT_CASH_CHECK_MNT_M_OWNER, INT_CODE_OWNER, BLN_RET)

        Return BLN_RET
    End Function

    Private SRT_CASH_GET_MNT_M_OWNER_FLAG_INVALID() As SRT_CASH_INT_INT
    Public Function FUNC_GET_MNT_M_OWNER_FLAG_INVALID(
    ByVal INT_CODE_OWNER As Integer,
    Optional ByVal BLN_CASH As Boolean = False
    ) As Integer

        Dim SRT_MY_CASH() As SRT_CASH_INT_INT
        SRT_MY_CASH = SRT_CASH_GET_MNT_M_OWNER_FLAG_INVALID
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
            .COL_NAME = "FLAG_INVALID"
            ReDim .WHERE(1)
            .WHERE(1).COL_NAME = "CODE_OWNER"
            .WHERE(1).VALUE = INT_CODE_OWNER
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)

        Dim INT_RET As Integer
        INT_RET = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_NUMERIC(STR_SQL)

        Call SUB_ADD_CASH_INT_INT(SRT_CASH_GET_MNT_M_OWNER_FLAG_INVALID, INT_CODE_OWNER, INT_RET)

        Return INT_RET
    End Function

End Module

#End Region

#Region "MNT_M_ACCOUNT"

Public Module MOD_SYSTEM_INDIVIDUAL_MST_SELECT_MNT_M_ACCOUNT

#Region "モジュール用・定数"
    Private Const CST_TABLE_NAME_DEFAULT As String = "MNT_M_ACCOUNT"
#End Region

    Private SRT_CASH_GET_MNT_M_ACCOUNT_NAME_KIND() As SRT_CASH_INT_INT_STR
    Public Function FUNC_GET_MNT_M_ACCOUNT_NAME_ACCOUNT(
    ByVal ENM_FLAG_ACCOUNT As ENM_SYSTEM_INDIVIDUAL_FLAG_ACCOUNT,
    ByVal INT_CODE_ACCOUNT As Integer,
    Optional ByVal BLN_CASH As Boolean = False
    ) As String

        Dim STR_RET As String
        STR_RET = ""

        Dim SRT_MY_CASH() As SRT_CASH_INT_INT_STR
        SRT_MY_CASH = SRT_CASH_GET_MNT_M_ACCOUNT_NAME_KIND
        If BLN_CASH Then
            Dim INT_CASH_INDEX As Integer
            INT_CASH_INDEX = FUNC_SEARCH_CASH_INT_INT_STR(SRT_MY_CASH, ENM_FLAG_ACCOUNT, INT_CODE_ACCOUNT)
            If INT_CASH_INDEX <> -1 Then
                Return SRT_MY_CASH(INT_CASH_INDEX).VALUE
            End If
        End If

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "NAME_ACCOUNT"
            ReDim .WHERE(2)
            .WHERE(1).COL_NAME = "FLAG_ACCOUNT"
            .WHERE(1).VALUE = CInt(ENM_FLAG_ACCOUNT.GetHashCode)
            .WHERE(2).COL_NAME = "CODE_ACCOUNT"
            .WHERE(2).VALUE = INT_CODE_ACCOUNT
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)
        STR_RET = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_STRING(STR_SQL)

        Call SUB_ADD_CASH_INT_INT_STR(SRT_CASH_GET_MNT_M_ACCOUNT_NAME_KIND, ENM_FLAG_ACCOUNT, INT_CODE_ACCOUNT, STR_RET)

        Return STR_RET
    End Function

    Private SRT_CASH_GET_MNT_M_ACCOUNT_CODE_ACCOUNT_CONNECT() As SRT_CASH_INT_INT_INT
    Public Function FUNC_GET_MNT_M_ACCOUNT_CODE_ACCOUNT_CONNECT(
    ByVal ENM_FLAG_ACCOUNT As ENM_SYSTEM_INDIVIDUAL_FLAG_ACCOUNT,
    ByVal INT_CODE_ACCOUNT As Integer,
    Optional ByVal BLN_CASH As Boolean = False
    ) As Integer

        Dim INT_RET As Integer
        INT_RET = -1

        Dim SRT_MY_CASH() As SRT_CASH_INT_INT_INT
        SRT_MY_CASH = SRT_CASH_GET_MNT_M_ACCOUNT_CODE_ACCOUNT_CONNECT
        If BLN_CASH Then
            Dim INT_CASH_INDEX As Integer
            INT_CASH_INDEX = FUNC_SEARCH_CASH_INT_INT_INT(SRT_MY_CASH, ENM_FLAG_ACCOUNT, INT_CODE_ACCOUNT)
            If INT_CASH_INDEX <> -1 Then
                Return SRT_MY_CASH(INT_CASH_INDEX).VALUE
            End If
        End If

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "CODE_ACCOUNT_CONNECT"
            ReDim .WHERE(2)
            .WHERE(1).COL_NAME = "FLAG_ACCOUNT"
            .WHERE(1).VALUE = CInt(ENM_FLAG_ACCOUNT.GetHashCode)
            .WHERE(2).COL_NAME = "CODE_ACCOUNT"
            .WHERE(2).VALUE = INT_CODE_ACCOUNT
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)
        INT_RET = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_NUMERIC(STR_SQL)

        Call SUB_ADD_CASH_INT_INT_INT(SRT_CASH_GET_MNT_M_ACCOUNT_CODE_ACCOUNT_CONNECT, ENM_FLAG_ACCOUNT, INT_CODE_ACCOUNT, INT_RET)

        Return INT_RET
    End Function

    Private SRT_CASH_GET_MNT_M_ACCOUNT_CODE_ACCOUNT_DEFAULT() As SRT_CASH_INT_INT
    Public Function FUNC_GET_MNT_M_ACCOUNT_CODE_ACCOUNT_DEFAULT(
    ByVal ENM_FLAG_ACCOUNT As ENM_SYSTEM_INDIVIDUAL_FLAG_ACCOUNT,
    Optional ByVal BLN_CASH As Boolean = False
    ) As Integer

        Dim INT_RET As Integer
        INT_RET = -1

        Dim SRT_MY_CASH() As SRT_CASH_INT_INT
        SRT_MY_CASH = SRT_CASH_GET_MNT_M_ACCOUNT_CODE_ACCOUNT_DEFAULT
        If BLN_CASH Then
            Dim INT_CASH_INDEX As Integer
            INT_CASH_INDEX = FUNC_SEARCH_CASH_INT_INT(SRT_MY_CASH, ENM_FLAG_ACCOUNT)
            If INT_CASH_INDEX <> -1 Then
                Return SRT_MY_CASH(INT_CASH_INDEX).VALUE
            End If
        End If

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "CODE_ACCOUNT"
            ReDim .WHERE(1)
            .WHERE(1).COL_NAME = "FLAG_ACCOUNT"
            .WHERE(1).VALUE = CInt(ENM_FLAG_ACCOUNT.GetHashCode)
            .ORDER_KEY = "CODE_ACCOUNT"
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)
        INT_RET = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_NUMERIC(STR_SQL)

        Call SUB_ADD_CASH_INT_INT(SRT_CASH_GET_MNT_M_ACCOUNT_CODE_ACCOUNT_DEFAULT, ENM_FLAG_ACCOUNT, INT_RET)

        Return INT_RET
    End Function

End Module

#End Region

#Region "MNT_M_MAINTENANCE"

Public Module MOD_SYSTEM_INDIVIDUAL_MST_SELECT_MNT_M_MAINTENANCE

#Region "モジュール用・定数"
    Private Const CST_TABLE_NAME_DEFAULT As String = "MNT_M_MAINTENANCE"
#End Region

    Private SRT_CASH_GET_MNT_M_MAINTENANCE_FLAG_WORK() As SRT_CASH_INT_INT
    Public Function FUNC_GET_MNT_M_MAINTENANCE_FLAG_WORK(
    ByVal INT_CODE_MAINTENANCE As Integer,
    Optional ByVal BLN_CASH As Boolean = False
    ) As Integer

        Dim SRT_MY_CASH() As SRT_CASH_INT_INT
        SRT_MY_CASH = SRT_CASH_GET_MNT_M_MAINTENANCE_FLAG_WORK
        If BLN_CASH Then
            Dim INT_CASH_INDEX As Integer
            INT_CASH_INDEX = FUNC_SEARCH_CASH_INT_INT(SRT_MY_CASH, INT_CODE_MAINTENANCE)
            If INT_CASH_INDEX <> -1 Then
                Return SRT_MY_CASH(INT_CASH_INDEX).VALUE
            End If
        End If

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "FLAG_WORK"
            ReDim .WHERE(1)
            .WHERE(1).COL_NAME = "CODE_MAINTENANCE"
            .WHERE(1).VALUE = INT_CODE_MAINTENANCE
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)

        Dim INT_RET As Integer
        INT_RET = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_NUMERIC(STR_SQL)

        Call SUB_ADD_CASH_INT_INT(SRT_CASH_GET_MNT_M_MAINTENANCE_FLAG_WORK, INT_CODE_MAINTENANCE, INT_RET)

        Return INT_RET
    End Function

    Private SRT_CASH_GET_MNT_M_MAINTENANCE_NAME_MAINTENANCE() As SRT_CASH_INT_STR
    Public Function FUNC_GET_MNT_M_MAINTENANCE_NAME_MAINTENANCE(
    ByVal INT_CODE_MAINTENANCE As Integer,
    Optional ByVal BLN_CASH As Boolean = False
    ) As String

        Dim SRT_MY_CASH() As SRT_CASH_INT_STR
        SRT_MY_CASH = SRT_CASH_GET_MNT_M_MAINTENANCE_NAME_MAINTENANCE
        If BLN_CASH Then
            Dim INT_CASH_INDEX As Integer
            INT_CASH_INDEX = FUNC_SEARCH_CASH_INT_STR(SRT_MY_CASH, INT_CODE_MAINTENANCE)
            If INT_CASH_INDEX <> -1 Then
                Return SRT_MY_CASH(INT_CASH_INDEX).VALUE
            End If
        End If

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "NAME_MAINTENANCE"
            ReDim .WHERE(1)
            .WHERE(1).COL_NAME = "CODE_MAINTENANCE"
            .WHERE(1).VALUE = INT_CODE_MAINTENANCE
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)

        Dim STR_RET As String
        STR_RET = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_STRING(STR_SQL)

        Call SUB_ADD_CASH_INT_STR(SRT_CASH_GET_MNT_M_MAINTENANCE_NAME_MAINTENANCE, INT_CODE_MAINTENANCE, STR_RET)

        Return STR_RET
    End Function
End Module

#End Region

#Region "MNT_M_SECTION"
Public Module MOD_SYSTEM_INDIVIDUAL_MST_SELECT_MNT_M_SECTION

#Region "モジュール用・定数"
    Private Const CST_TABLE_NAME_DEFAULT As String = "MNT_M_SECTION"
#End Region

    Private SRT_CASH_GET_MNT_M_SECTION_NAME_SECTION() As SRT_CASH_INT_STR
    Public Function FUNC_GET_MNT_M_SECTION_NAME_SECTION(
    ByVal INT_CODE_SECTION As Integer,
    Optional ByVal BLN_CASH As Boolean = False
    ) As String

        Dim SRT_MY_CASH() As SRT_CASH_INT_STR
        SRT_MY_CASH = SRT_CASH_GET_MNT_M_SECTION_NAME_SECTION
        If BLN_CASH Then
            Dim INT_CASH_INDEX As Integer
            INT_CASH_INDEX = FUNC_SEARCH_CASH_INT_STR(SRT_MY_CASH, INT_CODE_SECTION)
            If INT_CASH_INDEX <> -1 Then
                Return SRT_MY_CASH(INT_CASH_INDEX).VALUE
            End If
        End If

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "NAME_SECTION"
            ReDim .WHERE(1)
            .WHERE(1).COL_NAME = "CODE_SECTION"
            .WHERE(1).VALUE = INT_CODE_SECTION
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)

        Dim STR_RET As String
        STR_RET = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_STRING(STR_SQL)

        Call SUB_ADD_CASH_INT_STR(SRT_CASH_GET_MNT_M_SECTION_NAME_SECTION, INT_CODE_SECTION, STR_RET)

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

    Public Function FUNC_GET_MNT_T_CONTRACT_MAX_SERIAL_CONTRACT(
    ByVal INT_NUMBER_CONTRACT As Integer
    ) As Integer

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "MAX(SERIAL_CONTRACT)"
            ReDim .WHERE(1)
            .WHERE(1).COL_NAME = "NUMBER_CONTRACT"
            .WHERE(1).VALUE = INT_NUMBER_CONTRACT
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

#Region "MNT_T_INVOICE"
Public Module MOD_SYSTEM_INDIVIDUAL_MST_SELECT_MNT_T_INVOICE

#Region "モジュール用・定数"
    Private Const CST_TABLE_NAME_DEFAULT As String = "MNT_T_INVOICE"
#End Region

    '最大請求連番取得
    Public Function FUNC_GET_MNT_T_INVOICE_MAX_SERIAL_INVOICE(
    ByVal INT_NUMBER_CONTRACT As Integer, ByVal INT_SERIAL_CONTRACT As Integer
    ) As Integer

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "MAX(SERIAL_INVOICE)"
            ReDim .WHERE(2)
            .WHERE(1).COL_NAME = "NUMBER_CONTRACT"
            .WHERE(1).VALUE = INT_NUMBER_CONTRACT
            .WHERE(2).COL_NAME = "SERIAL_CONTRACT"
            .WHERE(2).VALUE = INT_SERIAL_CONTRACT
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)

        Dim INT_RET As Integer
        INT_RET = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_NUMERIC(STR_SQL, 0)

        Return INT_RET
    End Function

    '該当月請求チェック
    Public Function FUNC_CHECK_MNT_T_INVOICE_DATE_INVOICE_PERIOD(
    ByVal INT_NUMBER_CONTRACT As Integer, ByVal INT_SERIAL_CONTRACT As Integer,
    ByVal DAT_DATE_FROM As DateTime, ByVal DAT_DATE_TO As DateTime
    ) As Boolean


        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "COUNT(*)"
            ReDim .WHERE(1)
            .WHERE(1).COL_NAME = "NUMBER_CONTRACT"
            .WHERE(1).VALUE = INT_NUMBER_CONTRACT
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As System.Text.StringBuilder
        STR_SQL = New System.Text.StringBuilder
        With STR_SQL
            Call .Append("SELECT" & System.Environment.NewLine)
            Call .Append("COUNT(*)" & System.Environment.NewLine)
            Call .Append("FROM" & System.Environment.NewLine)
            Call .Append(CST_TABLE_NAME_DEFAULT & System.Environment.NewLine)
            Call .Append("WHERE" & System.Environment.NewLine)
            Call .Append("1=1" & System.Environment.NewLine)
            Call .Append(FUNC_GET_SQL_WHERE_INT(INT_NUMBER_CONTRACT, "NUMBER_CONTRACT", "="))
            Call .Append(FUNC_GET_SQL_WHERE_INT(INT_SERIAL_CONTRACT, "SERIAL_CONTRACT", "="))
            Dim SRT_DATE_INVOICE As SRT_DATE_PERIOD
            SRT_DATE_INVOICE.DATE_FROM = DAT_DATE_FROM
            SRT_DATE_INVOICE.DATE_TO = DAT_DATE_TO
            Call .Append(FUNC_GET_SQL_WHERE_DATE_FROM_TO(SRT_DATE_INVOICE, "DATE_INVOICE"))
        End With

        Dim INT_CNT As Integer
        INT_CNT = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_NUMERIC(STR_SQL.ToString, 0)

        Dim BLN_RET As Boolean
        BLN_RET = (INT_CNT > 0)

        Return BLN_RET
    End Function

    Private SRT_CASH_GET_MNT_T_INVOICE_KINGAKU_INVOICE_DETAIL() As SRT_CASH_INT_INT_INT_LONG
    Public Function FUNC_GET_MNT_T_INVOICE_KINGAKU_INVOICE_DETAIL(
    ByVal INT_NUMBER_CONTRACT As Integer, ByVal INT_SERIAL_CONTRACT As Integer, ByVal INT_SERIAL_INVOICE As Integer,
    Optional ByVal BLN_CASH As Boolean = False
    ) As Long

        Dim SRT_MY_CASH() As SRT_CASH_INT_INT_INT_LONG
        SRT_MY_CASH = SRT_CASH_GET_MNT_T_INVOICE_KINGAKU_INVOICE_DETAIL
        If BLN_CASH Then
            Dim INT_CASH_INDEX As Integer
            INT_CASH_INDEX = FUNC_SEARCH_CASH_INT_INT_INT_LONG(SRT_MY_CASH, INT_NUMBER_CONTRACT, INT_SERIAL_CONTRACT, INT_SERIAL_INVOICE)
            If INT_CASH_INDEX <> -1 Then
                Return SRT_MY_CASH(INT_CASH_INDEX).VALUE
            End If
        End If

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "KINGAKU_INVOICE_DETAIL"
            ReDim .WHERE(3)
            .WHERE(1).COL_NAME = "NUMBER_CONTRACT"
            .WHERE(1).VALUE = INT_NUMBER_CONTRACT
            .WHERE(2).COL_NAME = "SERIAL_CONTRACT"
            .WHERE(2).VALUE = INT_SERIAL_CONTRACT
            .WHERE(3).COL_NAME = "SERIAL_INVOICE"
            .WHERE(3).VALUE = INT_SERIAL_INVOICE
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)

        Dim LNG_RET As Long
        LNG_RET = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_NUMERIC(STR_SQL, 0)

        Call SUB_ADD_CASH_INT_INT_INT_LONG(SRT_CASH_GET_MNT_T_INVOICE_KINGAKU_INVOICE_DETAIL, INT_NUMBER_CONTRACT, INT_SERIAL_CONTRACT, INT_SERIAL_INVOICE, LNG_RET)

        Return LNG_RET
    End Function


    Private SRT_CASH_GET_MNT_T_INVOICE_KINGAKU_INVOICE_VAT() As SRT_CASH_INT_INT_INT_LONG
    Public Function FUNC_GET_MNT_T_INVOICE_KINGAKU_INVOICE_VAT(
    ByVal INT_NUMBER_CONTRACT As Integer, ByVal INT_SERIAL_CONTRACT As Integer, ByVal INT_SERIAL_INVOICE As Integer,
    Optional ByVal BLN_CASH As Boolean = False
    ) As Long

        Dim SRT_MY_CASH() As SRT_CASH_INT_INT_INT_LONG
        SRT_MY_CASH = SRT_CASH_GET_MNT_T_INVOICE_KINGAKU_INVOICE_VAT
        If BLN_CASH Then
            Dim INT_CASH_INDEX As Integer
            INT_CASH_INDEX = FUNC_SEARCH_CASH_INT_INT_INT_LONG(SRT_MY_CASH, INT_NUMBER_CONTRACT, INT_SERIAL_CONTRACT, INT_SERIAL_INVOICE)
            If INT_CASH_INDEX <> -1 Then
                Return SRT_MY_CASH(INT_CASH_INDEX).VALUE
            End If
        End If

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "KINGAKU_INVOICE_VAT"
            ReDim .WHERE(3)
            .WHERE(1).COL_NAME = "NUMBER_CONTRACT"
            .WHERE(1).VALUE = INT_NUMBER_CONTRACT
            .WHERE(2).COL_NAME = "SERIAL_CONTRACT"
            .WHERE(2).VALUE = INT_SERIAL_CONTRACT
            .WHERE(3).COL_NAME = "SERIAL_INVOICE"
            .WHERE(3).VALUE = INT_SERIAL_INVOICE
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)

        Dim LNG_RET As Long
        LNG_RET = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_NUMERIC(STR_SQL, 0)

        Call SUB_ADD_CASH_INT_INT_INT_LONG(SRT_CASH_GET_MNT_T_INVOICE_KINGAKU_INVOICE_VAT, INT_NUMBER_CONTRACT, INT_SERIAL_CONTRACT, INT_SERIAL_INVOICE, LNG_RET)

        Return LNG_RET
    End Function


    Private SRT_CASH_GET_MNT_T_INVOICE_DATE_INVOICE() As SRT_CASH_INT_INT_INT_DATE
    Public Function FUNC_GET_MNT_T_INVOICE_DATE_INVOICE(
    ByVal INT_NUMBER_CONTRACT As Integer, ByVal INT_SERIAL_CONTRACT As Integer, ByVal INT_SERIAL_INVOICE As Integer,
    Optional ByVal BLN_CASH As Boolean = False
    ) As DateTime

        Dim SRT_MY_CASH() As SRT_CASH_INT_INT_INT_DATE
        SRT_MY_CASH = SRT_CASH_GET_MNT_T_INVOICE_DATE_INVOICE
        If BLN_CASH Then
            Dim INT_CASH_INDEX As Integer
            INT_CASH_INDEX = FUNC_SEARCH_CASH_INT_INT_INT_DATE(SRT_MY_CASH, INT_NUMBER_CONTRACT, INT_SERIAL_CONTRACT, INT_SERIAL_INVOICE)
            If INT_CASH_INDEX <> -1 Then
                Return SRT_MY_CASH(INT_CASH_INDEX).VALUE
            End If
        End If

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "DATE_INVOICE"
            ReDim .WHERE(3)
            .WHERE(1).COL_NAME = "NUMBER_CONTRACT"
            .WHERE(1).VALUE = INT_NUMBER_CONTRACT
            .WHERE(2).COL_NAME = "SERIAL_CONTRACT"
            .WHERE(2).VALUE = INT_SERIAL_CONTRACT
            .WHERE(3).COL_NAME = "SERIAL_INVOICE"
            .WHERE(3).VALUE = INT_SERIAL_INVOICE
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)

        Dim DAT_RET As DateTime
        DAT_RET = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_DATETIME(STR_SQL)

        Call SUB_ADD_CASH_INT_INT_INT_DATE(SRT_CASH_GET_MNT_T_INVOICE_DATE_INVOICE, INT_NUMBER_CONTRACT, INT_SERIAL_CONTRACT, INT_SERIAL_INVOICE, DAT_RET)

        Return DAT_RET
    End Function

    Private SRT_CASH_GET_MNT_T_INVOICE_COUNT() As SRT_CASH_INT_INT_INT
    Public Function FUNC_GET_MNT_T_INVOICE_COUNT(
    ByVal INT_NUMBER_CONTRACT As Integer, ByVal INT_SERIAL_CONTRACT As Integer,
    Optional ByVal BLN_CASH As Boolean = False
    ) As Long

        Dim SRT_MY_CASH() As SRT_CASH_INT_INT_INT
        SRT_MY_CASH = SRT_CASH_GET_MNT_T_INVOICE_COUNT
        If BLN_CASH Then
            Dim INT_CASH_INDEX As Integer
            INT_CASH_INDEX = FUNC_SEARCH_CASH_INT_INT_INT(SRT_MY_CASH, INT_NUMBER_CONTRACT, INT_SERIAL_CONTRACT)
            If INT_CASH_INDEX <> -1 Then
                Return SRT_MY_CASH(INT_CASH_INDEX).VALUE
            End If
        End If

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "COUNT(*)"
            ReDim .WHERE(2)
            .WHERE(1).COL_NAME = "NUMBER_CONTRACT"
            .WHERE(1).VALUE = INT_NUMBER_CONTRACT
            .WHERE(2).COL_NAME = "SERIAL_CONTRACT"
            .WHERE(2).VALUE = INT_SERIAL_CONTRACT
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)

        Dim INT_RET As Long
        INT_RET = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_NUMERIC(STR_SQL, 0)

        Call SUB_ADD_CASH_INT_INT_INT(SRT_CASH_GET_MNT_T_INVOICE_COUNT, INT_NUMBER_CONTRACT, INT_SERIAL_CONTRACT, INT_RET)

        Return INT_RET
    End Function

End Module

#End Region

#Region "MNT_T_DEPOSIT"
Public Module MOD_SYSTEM_INDIVIDUAL_MST_SELECT_MNT_T_DEPOSIT

#Region "モジュール用・定数"
    Private Const CST_TABLE_NAME_DEFAULT As String = "MNT_T_DEPOSIT"
#End Region
    '最大入金連番
    Public Function FUNC_GET_MNT_T_DEPOSIT_MAX_SERIAL_DEPOSIT(
    ByVal DAT_DATE_ACTIVE As DateTime
    ) As Integer

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "MAX(SERIAL_DEPOSIT)"
            ReDim .WHERE(1)
            .WHERE(1).COL_NAME = "DATE_ACTIVE"
            .WHERE(1).VALUE = DAT_DATE_ACTIVE
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)

        Dim INT_RET As Integer
        INT_RET = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_NUMERIC(STR_SQL, 0)

        Return INT_RET
    End Function

    Private SRT_CASH_GET_MNT_T_DEPOSIT_COUNT() As SRT_CASH_INT_INT_INT
    Public Function FUNC_GET_MNT_T_DEPOSIT_COUNT(
    ByVal INT_NUMBER_CONTRACT As Integer, ByVal INT_SERIAL_CONTRACT As Integer,
    Optional ByVal BLN_CASH As Boolean = False
    ) As Long

        Dim SRT_MY_CASH() As SRT_CASH_INT_INT_INT
        SRT_MY_CASH = SRT_CASH_GET_MNT_T_DEPOSIT_COUNT
        If BLN_CASH Then
            Dim INT_CASH_INDEX As Integer
            INT_CASH_INDEX = FUNC_SEARCH_CASH_INT_INT_INT(SRT_MY_CASH, INT_NUMBER_CONTRACT, INT_SERIAL_CONTRACT)
            If INT_CASH_INDEX <> -1 Then
                Return SRT_MY_CASH(INT_CASH_INDEX).VALUE
            End If
        End If

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "COUNT(*)"
            ReDim .WHERE(2)
            .WHERE(1).COL_NAME = "NUMBER_CONTRACT"
            .WHERE(1).VALUE = INT_NUMBER_CONTRACT
            .WHERE(2).COL_NAME = "SERIAL_CONTRACT"
            .WHERE(2).VALUE = INT_SERIAL_CONTRACT
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)

        Dim INT_RET As Long
        INT_RET = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_NUMERIC(STR_SQL, 0)

        Call SUB_ADD_CASH_INT_INT_INT(SRT_CASH_GET_MNT_T_DEPOSIT_COUNT, INT_NUMBER_CONTRACT, INT_SERIAL_CONTRACT, INT_RET)

        Return INT_RET
    End Function

End Module

#End Region