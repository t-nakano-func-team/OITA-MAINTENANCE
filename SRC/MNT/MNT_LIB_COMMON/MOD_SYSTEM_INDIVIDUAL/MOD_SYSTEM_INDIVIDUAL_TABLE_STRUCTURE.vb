﻿Module MOD_SYSTEM_INDIVIDUAL_TABLE_STRUCTURE

End Module

#Region "MNT_M_OWNER"

Public Module MOD_SYSTEM_INDIVIUAL_TABLE_STRUCTURE_MNT_M_OWNER

#Region "モジュール用・定数"
    Private Const CST_TABLE_NAME_DEFAULT As String = "MNT_M_OWNER"
#End Region

#Region "KEY"
    Public Structure SRT_TABLE_MNT_M_OWNER_KEY
        Public CODE_OWNER As Integer
    End Structure
#End Region

#Region "DATA"
    Public Structure SRT_TABLE_MNT_M_OWNER_DATA
        Public NAME_OWNER As String
        Public KANA_OWNER As String
        Public FLAG_OWNER As Integer
        Public CODE_POST As Integer
        Public NAME_ADDRESS_01 As String
        Public NAME_ADDRESS_02 As String
        Public FLAG_INVOICE_FIXDAY As Integer
        Public FLAG_INVALID As Integer
        Public CODE_EDIT_STAFF As Integer
        Public DATE_EDIT As DateTime
    End Structure
#End Region

    Public Structure SRT_TABLE_MNT_M_OWNER
        Public KEY As SRT_TABLE_MNT_M_OWNER_KEY
        Public DATA As SRT_TABLE_MNT_M_OWNER_DATA
    End Structure

#Region "CASH"
    Private CASH_TABLE() As SRT_TABLE_MNT_M_OWNER

    Private Function FUNC_SEARCH_CASH(
    ByRef SRT_CASH() As SRT_TABLE_MNT_M_OWNER, ByRef SRT_KEY As SRT_TABLE_MNT_M_OWNER_KEY
    ) As Integer


        If IsNothing(SRT_CASH) Then
            Return -1
        End If

        For i = LBound(SRT_CASH) To UBound(SRT_CASH)
            With SRT_CASH(i)
                If .KEY.CODE_OWNER = SRT_KEY.CODE_OWNER Then
                    Return i
                End If
            End With
        Next

        Return -1
    End Function

    Private Sub SUB_ADD_CASH(
    ByRef SRT_CASH() As SRT_TABLE_MNT_M_OWNER, ByRef SRT_CASH_ON As SRT_TABLE_MNT_M_OWNER
    )
        Dim INT_SERACH As Integer
        INT_SERACH = FUNC_SEARCH_CASH(SRT_CASH, SRT_CASH_ON.KEY)
        If INT_SERACH <> -1 Then
            Exit Sub
        End If

        Dim INT_INDEX As Integer
        If IsNothing(SRT_CASH) Then
            INT_INDEX = 0
        Else
            INT_INDEX = UBound(SRT_CASH) + 1
        End If
        ReDim Preserve SRT_CASH(INT_INDEX)

        SRT_CASH(INT_INDEX) = SRT_CASH_ON
    End Sub
#End Region

#Region "SELECT"
    Public Function FUNC_SELECT_TABLE_MNT_M_OWNER(
    ByRef SRT_DATA As SRT_TABLE_MNT_M_OWNER_KEY,
    ByRef SRT_RET As SRT_TABLE_MNT_M_OWNER_DATA,
    Optional ByVal BLN_CASH As Boolean = False
    ) As Boolean

        With SRT_RET
            .NAME_OWNER = ""
            .KANA_OWNER = ""
            .FLAG_OWNER = -1
            .CODE_POST = 0
            .NAME_ADDRESS_01 = ""
            .NAME_ADDRESS_02 = ""
            .FLAG_INVOICE_FIXDAY = -1
            .FLAG_INVALID = -1
            .CODE_EDIT_STAFF = -1
            .DATE_EDIT = cstVB_DATE_MIN
        End With

        If BLN_CASH Then
            Dim INT_CASH_INDEX As Integer
            INT_CASH_INDEX = FUNC_SEARCH_CASH(CASH_TABLE, SRT_DATA)
            If INT_CASH_INDEX <> -1 Then
                SRT_RET = CASH_TABLE(INT_CASH_INDEX).DATA
                Return True
            End If
        End If

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "*"
            ReDim .WHERE(1)
            .WHERE(1).COL_NAME = "CODE_OWNER"
            .WHERE(1).VALUE = SRT_DATA.CODE_OWNER
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)

        Dim SDR_READER As SqlClient.SqlDataReader
        SDR_READER = Nothing
        If Not FUNC_SYSTEM_GET_SQL_DATA_READER(STR_SQL, SDR_READER, CommandBehavior.SingleRow) Then
            Return False
        End If

        If Not SDR_READER.HasRows Then
            Call SDR_READER.Close()
            SDR_READER = Nothing
            Return True
        End If

        Call SDR_READER.Read()

        With SRT_RET
            .NAME_OWNER = CStr(SDR_READER.Item("NAME_OWNER"))
            .KANA_OWNER = CStr(SDR_READER.Item("KANA_OWNER"))
            .FLAG_OWNER = CInt(SDR_READER.Item("FLAG_OWNER"))
            .CODE_POST = CInt(SDR_READER.Item("CODE_POST"))
            .NAME_ADDRESS_01 = CStr(SDR_READER.Item("NAME_ADDRESS_01"))
            .NAME_ADDRESS_02 = CStr(SDR_READER.Item("NAME_ADDRESS_02"))
            .FLAG_INVOICE_FIXDAY = CInt(SDR_READER.Item("FLAG_INVOICE_FIXDAY"))
            .FLAG_INVALID = CInt(SDR_READER.Item("FLAG_INVALID"))
            .CODE_EDIT_STAFF = CInt(SDR_READER.Item("CODE_EDIT_STAFF"))
            .DATE_EDIT = CDate(SDR_READER.Item("DATE_EDIT"))
        End With

        Call SDR_READER.Close()
        SDR_READER = Nothing

        Dim SRT_CASH_ONE As SRT_TABLE_MNT_M_OWNER
        SRT_CASH_ONE.KEY = SRT_DATA
        SRT_CASH_ONE.DATA = SRT_RET

        Call SUB_ADD_CASH(CASH_TABLE, SRT_CASH_ONE)

        Return True
    End Function
#End Region

#Region "DELETE"
    Public Function FUNC_DELETE_TABLE_MNT_M_OWNER(
    ByRef SRT_DATA As SRT_TABLE_MNT_M_OWNER_KEY
    ) As Boolean
        Dim SRT_SQL As SRT_SQL_TOOL_DELETE
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            ReDim .WHERE(1)
            .WHERE(1).COL_NAME = "CODE_OWNER"
            .WHERE(1).VALUE = SRT_DATA.CODE_OWNER
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_DELETE(SRT_SQL)

        If Not FUNC_SYSTEM_DO_SQL_EXECUTE(STR_SQL) Then
            Return False
        End If

        Return True
    End Function
#End Region

#Region "INSERT"
    Public Function FUNC_INSERT_TABLE_MNT_M_OWNER(
    ByRef SRT_DATA As SRT_TABLE_MNT_M_OWNER
    ) As Boolean

        Dim STR_SQL As System.Text.StringBuilder
        STR_SQL = New System.Text.StringBuilder
        Call STR_SQL.Append("INSERT" & Environment.NewLine)
        Call STR_SQL.Append("INTO" & Environment.NewLine)
        Call STR_SQL.Append(CST_TABLE_NAME_DEFAULT & " " & "WITH(ROWLOCK)" & Environment.NewLine)
        Call STR_SQL.Append("VALUES" & Environment.NewLine)
        Call STR_SQL.Append("(" & Environment.NewLine)
        With SRT_DATA.KEY
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.CODE_OWNER) & "," & Environment.NewLine)
        End With
        With SRT_DATA.DATA
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.NAME_OWNER) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.KANA_OWNER) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.FLAG_OWNER) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.CODE_POST) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.NAME_ADDRESS_01) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.NAME_ADDRESS_02) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.FLAG_INVOICE_FIXDAY) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.FLAG_INVALID) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.CODE_EDIT_STAFF) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.DATE_EDIT) & "" & Environment.NewLine)
        End With
        Call STR_SQL.Append(")" & Environment.NewLine)

        If Not FUNC_SYSTEM_DO_SQL_EXECUTE(STR_SQL.ToString) Then
            Return False
        End If

        Return True
    End Function
#End Region

#Region "CHECK"
    Public Function FUNC_CHECK_TABLE_MNT_M_OWNER(
    ByRef SRT_DATA As SRT_TABLE_MNT_M_OWNER_KEY
    ) As Boolean

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "COUNT(*)"
            ReDim .WHERE(1)
            .WHERE(1).COL_NAME = "CODE_OWNER"
            .WHERE(1).VALUE = SRT_DATA.CODE_OWNER
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)

        Dim INT_CNT As Integer
        INT_CNT = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_NUMERIC(STR_SQL, 0)

        Dim BLN_RET As Boolean
        BLN_RET = (INT_CNT > 0)
        Return BLN_RET
    End Function
#End Region

End Module

#End Region

#Region "MNT_M_MAINTENANCE"

Public Module MOD_SYSTEM_INDIVIUAL_TABLE_STRUCTURE_MNT_M_MAINTENANCE

#Region "モジュール用・定数"
    Private Const CST_TABLE_NAME_DEFAULT As String = "MNT_M_MAINTENANCE"
#End Region

#Region "KEY"
    Public Structure SRT_TABLE_MNT_M_MAINTENANCE_KEY
        Public CODE_MAINTENANCE As Integer
    End Structure
#End Region

#Region "DATA"
    Public Structure SRT_TABLE_MNT_M_MAINTENANCE_DATA
        Public NAME_MAINTENANCE As String
        Public FLAG_WORK As Integer
        Public FLAG_INVALID As Integer
        Public CODE_EDIT_STAFF As Integer
        Public DATE_EDIT As DateTime
    End Structure
#End Region

    Public Structure SRT_TABLE_MNT_M_MAINTENANCE
        Public KEY As SRT_TABLE_MNT_M_MAINTENANCE_KEY
        Public DATA As SRT_TABLE_MNT_M_MAINTENANCE_DATA
    End Structure

#Region "CASH"
    Private CASH_TABLE() As SRT_TABLE_MNT_M_MAINTENANCE

    Private Function FUNC_SEARCH_CASH(
    ByRef SRT_CASH() As SRT_TABLE_MNT_M_MAINTENANCE, ByRef SRT_KEY As SRT_TABLE_MNT_M_MAINTENANCE_KEY
    ) As Integer


        If IsNothing(SRT_CASH) Then
            Return -1
        End If

        For i = LBound(SRT_CASH) To UBound(SRT_CASH)
            With SRT_CASH(i)
                If .KEY.CODE_MAINTENANCE = SRT_KEY.CODE_MAINTENANCE Then
                    Return i
                End If
            End With
        Next

        Return -1
    End Function

    Private Sub SUB_ADD_CASH(
    ByRef SRT_CASH() As SRT_TABLE_MNT_M_MAINTENANCE, ByRef SRT_CASH_ON As SRT_TABLE_MNT_M_MAINTENANCE
    )
        Dim INT_SERACH As Integer
        INT_SERACH = FUNC_SEARCH_CASH(SRT_CASH, SRT_CASH_ON.KEY)
        If INT_SERACH <> -1 Then
            Exit Sub
        End If

        Dim INT_INDEX As Integer
        If IsNothing(SRT_CASH) Then
            INT_INDEX = 0
        Else
            INT_INDEX = UBound(SRT_CASH) + 1
        End If
        ReDim Preserve SRT_CASH(INT_INDEX)

        SRT_CASH(INT_INDEX) = SRT_CASH_ON
    End Sub
#End Region

#Region "SELECT"
    Public Function FUNC_SELECT_TABLE_MNT_M_MAINTENANCE(
    ByRef SRT_DATA As SRT_TABLE_MNT_M_MAINTENANCE_KEY,
    ByRef SRT_RET As SRT_TABLE_MNT_M_MAINTENANCE_DATA,
    Optional ByVal BLN_CASH As Boolean = False
    ) As Boolean

        With SRT_RET
            .NAME_MAINTENANCE = ""
            .FLAG_WORK = -1
            .FLAG_INVALID = -1
            .CODE_EDIT_STAFF = -1
            .DATE_EDIT = cstVB_DATE_MIN
        End With

        If BLN_CASH Then
            Dim INT_CASH_INDEX As Integer
            INT_CASH_INDEX = FUNC_SEARCH_CASH(CASH_TABLE, SRT_DATA)
            If INT_CASH_INDEX <> -1 Then
                SRT_RET = CASH_TABLE(INT_CASH_INDEX).DATA
                Return True
            End If
        End If

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "*"
            ReDim .WHERE(1)
            .WHERE(1).COL_NAME = "CODE_MAINTENANCE"
            .WHERE(1).VALUE = SRT_DATA.CODE_MAINTENANCE
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)

        Dim SDR_READER As SqlClient.SqlDataReader
        SDR_READER = Nothing
        If Not FUNC_SYSTEM_GET_SQL_DATA_READER(STR_SQL, SDR_READER, CommandBehavior.SingleRow) Then
            Return False
        End If

        If Not SDR_READER.HasRows Then
            Call SDR_READER.Close()
            SDR_READER = Nothing
            Return True
        End If

        Call SDR_READER.Read()

        With SRT_RET
            .NAME_MAINTENANCE = CStr(SDR_READER.Item("NAME_MAINTENANCE"))
            .FLAG_WORK = CInt(SDR_READER.Item("FLAG_WORK"))
            .FLAG_INVALID = CInt(SDR_READER.Item("FLAG_INVALID"))
            .CODE_EDIT_STAFF = CInt(SDR_READER.Item("CODE_EDIT_STAFF"))
            .DATE_EDIT = CDate(SDR_READER.Item("DATE_EDIT"))
        End With

        Call SDR_READER.Close()
        SDR_READER = Nothing

        Dim SRT_CASH_ONE As SRT_TABLE_MNT_M_MAINTENANCE
        SRT_CASH_ONE.KEY = SRT_DATA
        SRT_CASH_ONE.DATA = SRT_RET

        Call SUB_ADD_CASH(CASH_TABLE, SRT_CASH_ONE)

        Return True
    End Function
#End Region

#Region "DELETE"
    Public Function FUNC_DELETE_TABLE_MNT_M_MAINTENANCE(
    ByRef SRT_DATA As SRT_TABLE_MNT_M_MAINTENANCE_KEY
    ) As Boolean
        Dim SRT_SQL As SRT_SQL_TOOL_DELETE
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            ReDim .WHERE(1)
            .WHERE(1).COL_NAME = "CODE_MAINTENANCE"
            .WHERE(1).VALUE = SRT_DATA.CODE_MAINTENANCE
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_DELETE(SRT_SQL)

        If Not FUNC_SYSTEM_DO_SQL_EXECUTE(STR_SQL) Then
            Return False
        End If

        Return True
    End Function
#End Region

#Region "INSERT"
    Public Function FUNC_INSERT_TABLE_MNT_M_MAINTENANCE(
    ByRef SRT_DATA As SRT_TABLE_MNT_M_MAINTENANCE
    ) As Boolean

        Dim STR_SQL As System.Text.StringBuilder
        STR_SQL = New System.Text.StringBuilder
        Call STR_SQL.Append("INSERT" & Environment.NewLine)
        Call STR_SQL.Append("INTO" & Environment.NewLine)
        Call STR_SQL.Append(CST_TABLE_NAME_DEFAULT & " " & "WITH(ROWLOCK)" & Environment.NewLine)
        Call STR_SQL.Append("VALUES" & Environment.NewLine)
        Call STR_SQL.Append("(" & Environment.NewLine)
        With SRT_DATA.KEY
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.CODE_MAINTENANCE) & "," & Environment.NewLine)
        End With
        With SRT_DATA.DATA
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.NAME_MAINTENANCE) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.FLAG_WORK) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.FLAG_INVALID) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.CODE_EDIT_STAFF) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.DATE_EDIT) & "" & Environment.NewLine)
        End With
        Call STR_SQL.Append(")" & Environment.NewLine)

        If Not FUNC_SYSTEM_DO_SQL_EXECUTE(STR_SQL.ToString) Then
            Return False
        End If

        Return True
    End Function
#End Region

#Region "CHECK"
    Public Function FUNC_CHECK_TABLE_MNT_M_MAINTENANCE(
    ByRef SRT_DATA As SRT_TABLE_MNT_M_MAINTENANCE_KEY
    ) As Boolean

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "COUNT(*)"
            ReDim .WHERE(1)
            .WHERE(1).COL_NAME = "CODE_MAINTENANCE"
            .WHERE(1).VALUE = SRT_DATA.CODE_MAINTENANCE
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)

        Dim INT_CNT As Integer
        INT_CNT = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_NUMERIC(STR_SQL, 0)

        Dim BLN_RET As Boolean
        BLN_RET = (INT_CNT > 0)
        Return BLN_RET
    End Function
#End Region

End Module

#End Region

#Region "MNT_M_ACCOUNT"

Public Module MOD_SYSTEM_INDIVIUAL_TABLE_STRUCTURE_MNT_M_ACCOUNT

#Region "モジュール用・定数"
    Private Const CST_TABLE_NAME_DEFAULT As String = "MNT_M_ACCOUNT"
#End Region

#Region "KEY"
    Public Structure SRT_TABLE_MNT_M_ACCOUNT_KEY
        Public FLAG_ACCOUNT As Integer
        Public CODE_ACCOUNT As Integer
    End Structure
#End Region

#Region "DATA"
    Public Structure SRT_TABLE_MNT_M_ACCOUNT_DATA
        Public NAME_ACCOUNT As String
        Public CODE_ACCOUNT_CONNECT As Integer
        Public FLAG_INVALID As Integer
        Public CODE_EDIT_STAFF As Integer
        Public DATE_EDIT As DateTime
    End Structure
#End Region

    Public Structure SRT_TABLE_MNT_M_ACCOUNT
        Public KEY As SRT_TABLE_MNT_M_ACCOUNT_KEY
        Public DATA As SRT_TABLE_MNT_M_ACCOUNT_DATA
    End Structure

#Region "CASH"
    Private CASH_TABLE() As SRT_TABLE_MNT_M_ACCOUNT

    Private Function FUNC_SEARCH_CASH(
    ByRef SRT_CASH() As SRT_TABLE_MNT_M_ACCOUNT, ByRef SRT_KEY As SRT_TABLE_MNT_M_ACCOUNT_KEY
    ) As Integer


        If IsNothing(SRT_CASH) Then
            Return -1
        End If

        For i = LBound(SRT_CASH) To UBound(SRT_CASH)
            With SRT_CASH(i)
                If .KEY.FLAG_ACCOUNT = SRT_KEY.FLAG_ACCOUNT _
                    And .KEY.CODE_ACCOUNT = SRT_KEY.CODE_ACCOUNT Then
                    Return i
                End If
            End With
        Next

        Return -1
    End Function

    Private Sub SUB_ADD_CASH(
    ByRef SRT_CASH() As SRT_TABLE_MNT_M_ACCOUNT, ByRef SRT_CASH_ON As SRT_TABLE_MNT_M_ACCOUNT
    )
        Dim INT_SERACH As Integer
        INT_SERACH = FUNC_SEARCH_CASH(SRT_CASH, SRT_CASH_ON.KEY)
        If INT_SERACH <> -1 Then
            Exit Sub
        End If

        Dim INT_INDEX As Integer
        If IsNothing(SRT_CASH) Then
            INT_INDEX = 0
        Else
            INT_INDEX = UBound(SRT_CASH) + 1
        End If
        ReDim Preserve SRT_CASH(INT_INDEX)

        SRT_CASH(INT_INDEX) = SRT_CASH_ON
    End Sub
#End Region

#Region "SELECT"
    Public Function FUNC_SELECT_TABLE_MNT_M_ACCOUNT(
    ByRef SRT_DATA As SRT_TABLE_MNT_M_ACCOUNT_KEY,
    ByRef SRT_RET As SRT_TABLE_MNT_M_ACCOUNT_DATA,
    Optional ByVal BLN_CASH As Boolean = False
    ) As Boolean

        With SRT_RET
            .NAME_ACCOUNT = ""
            .CODE_ACCOUNT_CONNECT = -1
            .FLAG_INVALID = -1
            .CODE_EDIT_STAFF = -1
            .DATE_EDIT = cstVB_DATE_MIN
        End With

        If BLN_CASH Then
            Dim INT_CASH_INDEX As Integer
            INT_CASH_INDEX = FUNC_SEARCH_CASH(CASH_TABLE, SRT_DATA)
            If INT_CASH_INDEX <> -1 Then
                SRT_RET = CASH_TABLE(INT_CASH_INDEX).DATA
                Return True
            End If
        End If

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "*"
            ReDim .WHERE(2)
            .WHERE(1).COL_NAME = "FLAG_ACCOUNT"
            .WHERE(1).VALUE = SRT_DATA.FLAG_ACCOUNT
            .WHERE(2).COL_NAME = "CODE_ACCOUNT"
            .WHERE(2).VALUE = SRT_DATA.CODE_ACCOUNT
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)

        Dim SDR_READER As SqlClient.SqlDataReader
        SDR_READER = Nothing
        If Not FUNC_SYSTEM_GET_SQL_DATA_READER(STR_SQL, SDR_READER, CommandBehavior.SingleRow) Then
            Return False
        End If

        If Not SDR_READER.HasRows Then
            Call SDR_READER.Close()
            SDR_READER = Nothing
            Return True
        End If

        Call SDR_READER.Read()

        With SRT_RET
            .NAME_ACCOUNT = CStr(SDR_READER.Item("NAME_ACCOUNT"))
            .CODE_ACCOUNT_CONNECT = CInt(SDR_READER.Item("CODE_ACCOUNT_CONNECT"))
            .FLAG_INVALID = CInt(SDR_READER.Item("FLAG_INVALID"))
            .CODE_EDIT_STAFF = CInt(SDR_READER.Item("CODE_EDIT_STAFF"))
            .DATE_EDIT = CDate(SDR_READER.Item("DATE_EDIT"))
        End With

        Call SDR_READER.Close()
        SDR_READER = Nothing

        Dim SRT_CASH_ONE As SRT_TABLE_MNT_M_ACCOUNT
        SRT_CASH_ONE.KEY = SRT_DATA
        SRT_CASH_ONE.DATA = SRT_RET

        Call SUB_ADD_CASH(CASH_TABLE, SRT_CASH_ONE)

        Return True
    End Function
#End Region

#Region "DELETE"
    Public Function FUNC_DELETE_TABLE_MNT_M_ACCOUNT(
    ByRef SRT_DATA As SRT_TABLE_MNT_M_ACCOUNT_KEY
    ) As Boolean
        Dim SRT_SQL As SRT_SQL_TOOL_DELETE
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            ReDim .WHERE(2)
            .WHERE(1).COL_NAME = "FLAG_ACCOUNT"
            .WHERE(1).VALUE = SRT_DATA.FLAG_ACCOUNT
            .WHERE(2).COL_NAME = "CODE_ACCOUNT"
            .WHERE(2).VALUE = SRT_DATA.CODE_ACCOUNT
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_DELETE(SRT_SQL)

        If Not FUNC_SYSTEM_DO_SQL_EXECUTE(STR_SQL) Then
            Return False
        End If

        Return True
    End Function
#End Region

#Region "INSERT"
    Public Function FUNC_INSERT_TABLE_MNT_M_ACCOUNT(
    ByRef SRT_DATA As SRT_TABLE_MNT_M_ACCOUNT
    ) As Boolean

        Dim STR_SQL As System.Text.StringBuilder
        STR_SQL = New System.Text.StringBuilder
        Call STR_SQL.Append("INSERT" & Environment.NewLine)
        Call STR_SQL.Append("INTO" & Environment.NewLine)
        Call STR_SQL.Append(CST_TABLE_NAME_DEFAULT & " " & "WITH(ROWLOCK)" & Environment.NewLine)
        Call STR_SQL.Append("VALUES" & Environment.NewLine)
        Call STR_SQL.Append("(" & Environment.NewLine)
        With SRT_DATA.KEY
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.FLAG_ACCOUNT) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.CODE_ACCOUNT) & "," & Environment.NewLine)
        End With
        With SRT_DATA.DATA
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.NAME_ACCOUNT) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.CODE_ACCOUNT_CONNECT) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.FLAG_INVALID) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.CODE_EDIT_STAFF) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.DATE_EDIT) & "" & Environment.NewLine)

        End With
        Call STR_SQL.Append(")" & Environment.NewLine)

        If Not FUNC_SYSTEM_DO_SQL_EXECUTE(STR_SQL.ToString) Then
            Return False
        End If

        Return True
    End Function
#End Region

#Region "CHECK"
    Public Function FUNC_CHECK_TABLE_MNT_M_ACCOUNT(
    ByRef SRT_DATA As SRT_TABLE_MNT_M_ACCOUNT_KEY
    ) As Boolean

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "COUNT(*)"
            ReDim .WHERE(2)
            .WHERE(1).COL_NAME = "FLAG_ACCOUNT"
            .WHERE(1).VALUE = SRT_DATA.FLAG_ACCOUNT
            .WHERE(2).COL_NAME = "CODE_ACCOUNT"
            .WHERE(2).VALUE = SRT_DATA.CODE_ACCOUNT
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)

        Dim INT_CNT As Integer
        INT_CNT = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_NUMERIC(STR_SQL, 0)

        Dim BLN_RET As Boolean
        BLN_RET = (INT_CNT > 0)
        Return BLN_RET
    End Function
#End Region

End Module

#End Region

#Region "MNT_M_SECTION"

Public Module MOD_SYSTEM_INDIVIUAL_TABLE_STRUCTURE_MNT_M_SECTION

#Region "モジュール用・定数"
    Private Const CST_TABLE_NAME_DEFAULT As String = "MNT_M_SECTION"
#End Region

#Region "KEY"
    Public Structure SRT_TABLE_MNT_M_SECTION_KEY
        Public CODE_SECTION As Integer
    End Structure
#End Region

#Region "DATA"
    Public Structure SRT_TABLE_MNT_M_SECTION_DATA
        Public NAME_SECTION As String
        Public FLAG_INVALID As Integer
        Public CODE_EDIT_STAFF As Integer
        Public DATE_EDIT As DateTime
    End Structure
#End Region

    Public Structure SRT_TABLE_MNT_M_SECTION
        Public KEY As SRT_TABLE_MNT_M_SECTION_KEY
        Public DATA As SRT_TABLE_MNT_M_SECTION_DATA
    End Structure


#Region "CASH"
    Private CASH_TABLE() As SRT_TABLE_MNT_M_SECTION

    Private Function FUNC_SEARCH_CASH(
    ByRef SRT_CASH() As SRT_TABLE_MNT_M_SECTION, ByRef SRT_KEY As SRT_TABLE_MNT_M_SECTION_KEY
    ) As Integer


        If IsNothing(SRT_CASH) Then
            Return -1
        End If

        For i = LBound(SRT_CASH) To UBound(SRT_CASH)
            With SRT_CASH(i)
                If .KEY.CODE_SECTION = SRT_KEY.CODE_SECTION Then
                    Return i
                End If
            End With
        Next

        Return -1
    End Function

    Private Sub SUB_ADD_CASH(
    ByRef SRT_CASH() As SRT_TABLE_MNT_M_SECTION, ByRef SRT_CASH_ON As SRT_TABLE_MNT_M_SECTION
    )
        Dim INT_SERACH As Integer
        INT_SERACH = FUNC_SEARCH_CASH(SRT_CASH, SRT_CASH_ON.KEY)
        If INT_SERACH <> -1 Then
            Exit Sub
        End If

        Dim INT_INDEX As Integer
        If IsNothing(SRT_CASH) Then
            INT_INDEX = 0
        Else
            INT_INDEX = UBound(SRT_CASH) + 1
        End If
        ReDim Preserve SRT_CASH(INT_INDEX)

        SRT_CASH(INT_INDEX) = SRT_CASH_ON
    End Sub
#End Region

#Region "SELECT"
    Public Function FUNC_SELECT_TABLE_MNT_M_SECTION(
    ByRef SRT_DATA As SRT_TABLE_MNT_M_SECTION_KEY,
    ByRef SRT_RET As SRT_TABLE_MNT_M_SECTION_DATA,
    Optional ByVal BLN_CASH As Boolean = False
    ) As Boolean

        With SRT_RET
            .NAME_SECTION = ""
            .FLAG_INVALID = -1
            .CODE_EDIT_STAFF = -1
            .DATE_EDIT = cstVB_DATE_MIN
        End With

        If BLN_CASH Then
            Dim INT_CASH_INDEX As Integer
            INT_CASH_INDEX = FUNC_SEARCH_CASH(CASH_TABLE, SRT_DATA)
            If INT_CASH_INDEX <> -1 Then
                SRT_RET = CASH_TABLE(INT_CASH_INDEX).DATA
                Return True
            End If
        End If

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "*"
            ReDim .WHERE(1)
            .WHERE(1).COL_NAME = "CODE_SECTION"
            .WHERE(1).VALUE = SRT_DATA.CODE_SECTION
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)

        Dim SDR_READER As SqlClient.SqlDataReader
        SDR_READER = Nothing
        If Not FUNC_SYSTEM_GET_SQL_DATA_READER(STR_SQL, SDR_READER, CommandBehavior.SingleRow) Then
            Return False
        End If

        If Not SDR_READER.HasRows Then
            Call SDR_READER.Close()
            SDR_READER = Nothing
            Return True
        End If

        Call SDR_READER.Read()

        With SRT_RET
            .NAME_SECTION = CStr(SDR_READER.Item("NAME_SECTION"))
            .FLAG_INVALID = CInt(SDR_READER.Item("FLAG_INVALID"))
            .CODE_EDIT_STAFF = CInt(SDR_READER.Item("CODE_EDIT_STAFF"))
            .DATE_EDIT = CDate(SDR_READER.Item("DATE_EDIT"))
        End With

        Call SDR_READER.Close()
        SDR_READER = Nothing

        Dim SRT_CASH_ONE As SRT_TABLE_MNT_M_SECTION
        SRT_CASH_ONE.KEY = SRT_DATA
        SRT_CASH_ONE.DATA = SRT_RET

        Call SUB_ADD_CASH(CASH_TABLE, SRT_CASH_ONE)

        Return True
    End Function
#End Region

#Region "DELETE"
    Public Function FUNC_DELETE_TABLE_MNT_M_SECTION(
    ByRef SRT_DATA As SRT_TABLE_MNT_M_SECTION_KEY
    ) As Boolean
        Dim SRT_SQL As SRT_SQL_TOOL_DELETE
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            ReDim .WHERE(1)
            .WHERE(1).COL_NAME = "CODE_SECTION"
            .WHERE(1).VALUE = SRT_DATA.CODE_SECTION
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_DELETE(SRT_SQL)

        If Not FUNC_SYSTEM_DO_SQL_EXECUTE(STR_SQL) Then
            Return False
        End If

        Return True
    End Function
#End Region

#Region "INSERT"
    Public Function FUNC_INSERT_TABLE_MNT_M_SECTION(
    ByRef SRT_DATA As SRT_TABLE_MNT_M_SECTION
    ) As Boolean

        Dim STR_SQL As System.Text.StringBuilder
        STR_SQL = New System.Text.StringBuilder
        Call STR_SQL.Append("INSERT" & Environment.NewLine)
        Call STR_SQL.Append("INTO" & Environment.NewLine)
        Call STR_SQL.Append(CST_TABLE_NAME_DEFAULT & " " & "WITH(ROWLOCK)" & Environment.NewLine)
        Call STR_SQL.Append("VALUES" & Environment.NewLine)
        Call STR_SQL.Append("(" & Environment.NewLine)
        With SRT_DATA.KEY
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.CODE_SECTION) & "," & Environment.NewLine)
        End With
        With SRT_DATA.DATA
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.NAME_SECTION) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.FLAG_INVALID) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.CODE_EDIT_STAFF) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.DATE_EDIT) & "" & Environment.NewLine)
        End With
        Call STR_SQL.Append(")" & Environment.NewLine)

        If Not FUNC_SYSTEM_DO_SQL_EXECUTE(STR_SQL.ToString) Then
            Return False
        End If

        Return True
    End Function
#End Region

#Region "CHECK"
    Public Function FUNC_CHECK_TABLE_MNT_M_SECTION(
    ByRef SRT_DATA As SRT_TABLE_MNT_M_SECTION_KEY
    ) As Boolean

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "COUNT(*)"
            ReDim .WHERE(1)
            .WHERE(1).COL_NAME = "CODE_SECTION"
            .WHERE(1).VALUE = SRT_DATA.CODE_SECTION
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)

        Dim INT_CNT As Integer
        INT_CNT = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_NUMERIC(STR_SQL, 0)

        Dim BLN_RET As Boolean
        BLN_RET = (INT_CNT > 0)
        Return BLN_RET
    End Function
#End Region

End Module

#End Region

#Region "MNT_T_CONTRACT"
Public Module MOD_SYSTEM_INDIVIUAL_TABLE_STRUCTURE_MNT_T_CONTRACT

#Region "モジュール用・定数"
    Private Const CST_TABLE_NAME_DEFAULT As String = "MNT_T_CONTRACT"
#End Region

#Region "KEY"
    Public Structure SRT_TABLE_MNT_T_CONTRACT_KEY
        Public NUMBER_CONTRACT As Integer
        Public SERIAL_CONTRACT As Integer
    End Structure
#End Region

#Region "DATA"
    Public Structure SRT_TABLE_MNT_T_CONTRACT_DATA
        Public FLAG_CONTRACT As Integer
        Public DATE_CONTRACT As DateTime
        Public CODE_OWNER As Integer
        Public CODE_SECTION As Integer
        Public CODE_MAINTENANCE As Integer
        Public NAME_CONTRACT As String
        Public DATE_MAINTENANCE_START As DateTime
        Public DATE_MAINTENANCE_END As DateTime
        Public FLAG_INVOICE_METHOD As Integer
        Public DATE_INVOICE_BASE As DateTime
        Public SPAN_INVOICE As Integer
        Public COUNT_INVOICE As Integer
        Public NUMBER_LIST_INVOICE As Integer
        Public KINGAKU_CONTRACT As Long
        Public NAME_MEMO As String
        Public FLAG_CONTINUE As Integer
        Public DATE_ACTIVE As DateTime
        Public CODE_EDIT_STAFF As Integer
        Public DATE_EDIT As DateTime
    End Structure
#End Region

    Public Structure SRT_TABLE_MNT_T_CONTRACT
        Public KEY As SRT_TABLE_MNT_T_CONTRACT_KEY
        Public DATA As SRT_TABLE_MNT_T_CONTRACT_DATA
    End Structure

#Region "CASH"
    Private CASH_TABLE() As SRT_TABLE_MNT_T_CONTRACT

    Private Function FUNC_SEARCH_CASH(
    ByRef SRT_CASH() As SRT_TABLE_MNT_T_CONTRACT, ByRef SRT_KEY As SRT_TABLE_MNT_T_CONTRACT_KEY
    ) As Integer


        If IsNothing(SRT_CASH) Then
            Return -1
        End If

        For i = LBound(SRT_CASH) To UBound(SRT_CASH)
            With SRT_CASH(i)
                If .KEY.NUMBER_CONTRACT = SRT_KEY.NUMBER_CONTRACT _
                And .KEY.SERIAL_CONTRACT = SRT_KEY.SERIAL_CONTRACT Then
                    Return i
                End If
            End With
        Next

        Return -1
    End Function

    Private Sub SUB_ADD_CASH(
    ByRef SRT_CASH() As SRT_TABLE_MNT_T_CONTRACT, ByRef SRT_CASH_ON As SRT_TABLE_MNT_T_CONTRACT
    )
        Dim INT_SERACH As Integer
        INT_SERACH = FUNC_SEARCH_CASH(SRT_CASH, SRT_CASH_ON.KEY)
        If INT_SERACH <> -1 Then
            Exit Sub
        End If

        Dim INT_INDEX As Integer
        If IsNothing(SRT_CASH) Then
            INT_INDEX = 0
        Else
            INT_INDEX = UBound(SRT_CASH) + 1
        End If
        ReDim Preserve SRT_CASH(INT_INDEX)

        SRT_CASH(INT_INDEX) = SRT_CASH_ON
    End Sub
#End Region

#Region "SELECT"
    Public Function FUNC_SELECT_TABLE_MNT_T_CONTRACT(
    ByRef SRT_DATA As SRT_TABLE_MNT_T_CONTRACT_KEY,
    ByRef SRT_RET As SRT_TABLE_MNT_T_CONTRACT_DATA,
    Optional ByVal BLN_CASH As Boolean = False
    ) As Boolean

        With SRT_RET
            .FLAG_CONTRACT = -1
            .DATE_CONTRACT = cstVB_DATE_MIN
            .CODE_OWNER = -1
            .CODE_SECTION = -1
            .CODE_MAINTENANCE = -1
            .NAME_CONTRACT = ""
            .DATE_MAINTENANCE_START = cstVB_DATE_MIN
            .DATE_MAINTENANCE_END = cstVB_DATE_MIN
            .FLAG_INVOICE_METHOD = -1
            .DATE_INVOICE_BASE = cstVB_DATE_MIN
            .SPAN_INVOICE = 0
            .COUNT_INVOICE = 0
            .NUMBER_LIST_INVOICE = 0
            .KINGAKU_CONTRACT = 0
            .NAME_MEMO = ""
            .FLAG_CONTINUE = -1
            .DATE_ACTIVE = cstVB_DATE_MIN
            .CODE_EDIT_STAFF = -1
            .DATE_EDIT = cstVB_DATE_MIN
        End With

        If BLN_CASH Then
            Dim INT_CASH_INDEX As Integer
            INT_CASH_INDEX = FUNC_SEARCH_CASH(CASH_TABLE, SRT_DATA)
            If INT_CASH_INDEX <> -1 Then
                SRT_RET = CASH_TABLE(INT_CASH_INDEX).DATA
                Return True
            End If
        End If

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "*"
            ReDim .WHERE(2)
            .WHERE(1).COL_NAME = "NUMBER_CONTRACT"
            .WHERE(1).VALUE = SRT_DATA.NUMBER_CONTRACT
            .WHERE(2).COL_NAME = "SERIAL_CONTRACT"
            .WHERE(2).VALUE = SRT_DATA.SERIAL_CONTRACT
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)

        Dim SDR_READER As SqlClient.SqlDataReader
        SDR_READER = Nothing
        If Not FUNC_SYSTEM_GET_SQL_DATA_READER(STR_SQL, SDR_READER, CommandBehavior.SingleRow) Then
            Return False
        End If

        If Not SDR_READER.HasRows Then
            Call SDR_READER.Close()
            SDR_READER = Nothing
            Return True
        End If

        Call SDR_READER.Read()

        With SRT_RET
            .FLAG_CONTRACT = CInt(SDR_READER.Item("FLAG_CONTRACT"))
            .DATE_CONTRACT = CDate(SDR_READER.Item("DATE_CONTRACT"))
            .CODE_OWNER = CInt(SDR_READER.Item("CODE_OWNER"))
            .CODE_SECTION = CInt(SDR_READER.Item("CODE_SECTION"))
            .CODE_MAINTENANCE = CInt(SDR_READER.Item("CODE_MAINTENANCE"))
            .NAME_CONTRACT = CStr(SDR_READER.Item("NAME_CONTRACT"))
            .DATE_MAINTENANCE_START = CDate(SDR_READER.Item("DATE_MAINTENANCE_START"))
            .DATE_MAINTENANCE_END = CDate(SDR_READER.Item("DATE_MAINTENANCE_END"))
            .FLAG_INVOICE_METHOD = CInt(SDR_READER.Item("FLAG_INVOICE_METHOD"))
            .DATE_INVOICE_BASE = CDate(SDR_READER.Item("DATE_INVOICE_BASE"))
            .SPAN_INVOICE = CInt(SDR_READER.Item("SPAN_INVOICE"))
            .COUNT_INVOICE = CInt(SDR_READER.Item("COUNT_INVOICE"))
            .NUMBER_LIST_INVOICE = CInt(SDR_READER.Item("NUMBER_LIST_INVOICE"))
            .KINGAKU_CONTRACT = CLng(SDR_READER.Item("KINGAKU_CONTRACT"))
            .NAME_MEMO = CStr(SDR_READER.Item("NAME_MEMO"))
            .FLAG_CONTINUE = CInt(SDR_READER.Item("FLAG_CONTINUE"))
            .DATE_ACTIVE = CDate(SDR_READER.Item("DATE_ACTIVE"))
            .CODE_EDIT_STAFF = CInt(SDR_READER.Item("CODE_EDIT_STAFF"))
            .DATE_EDIT = CDate(SDR_READER.Item("DATE_EDIT"))
        End With

        Call SDR_READER.Close()
        SDR_READER = Nothing

        Dim SRT_CASH_ONE As SRT_TABLE_MNT_T_CONTRACT
        SRT_CASH_ONE.KEY = SRT_DATA
        SRT_CASH_ONE.DATA = SRT_RET

        Call SUB_ADD_CASH(CASH_TABLE, SRT_CASH_ONE)

        Return True
    End Function
#End Region

#Region "DELETE"
    Public Function FUNC_DELETE_TABLE_MNT_T_CONTRACT(
    ByRef SRT_DATA As SRT_TABLE_MNT_T_CONTRACT_KEY
    ) As Boolean
        Dim SRT_SQL As SRT_SQL_TOOL_DELETE
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            ReDim .WHERE(2)
            .WHERE(1).COL_NAME = "NUMBER_CONTRACT"
            .WHERE(1).VALUE = SRT_DATA.NUMBER_CONTRACT
            .WHERE(2).COL_NAME = "SERIAL_CONTRACT"
            .WHERE(2).VALUE = SRT_DATA.SERIAL_CONTRACT
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_DELETE(SRT_SQL)

        If Not FUNC_SYSTEM_DO_SQL_EXECUTE(STR_SQL) Then
            Return False
        End If

        Return True
    End Function
#End Region

#Region "INSERT"
    Public Function FUNC_INSERT_TABLE_MNT_T_CONTRACT(
    ByRef SRT_DATA As SRT_TABLE_MNT_T_CONTRACT
    ) As Boolean

        Dim STR_SQL As System.Text.StringBuilder
        STR_SQL = New System.Text.StringBuilder
        Call STR_SQL.Append("INSERT" & Environment.NewLine)
        Call STR_SQL.Append("INTO" & Environment.NewLine)
        Call STR_SQL.Append(CST_TABLE_NAME_DEFAULT & " " & "WITH(ROWLOCK)" & Environment.NewLine)
        Call STR_SQL.Append("VALUES" & Environment.NewLine)
        Call STR_SQL.Append("(" & Environment.NewLine)
        With SRT_DATA.KEY
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.NUMBER_CONTRACT) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.SERIAL_CONTRACT) & "," & Environment.NewLine)
        End With
        With SRT_DATA.DATA
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.FLAG_CONTRACT) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.DATE_CONTRACT) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.CODE_OWNER) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.CODE_SECTION) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.CODE_MAINTENANCE) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.NAME_CONTRACT) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.DATE_MAINTENANCE_START) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.DATE_MAINTENANCE_END) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.FLAG_INVOICE_METHOD) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.DATE_INVOICE_BASE) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.SPAN_INVOICE) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.COUNT_INVOICE) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.NUMBER_LIST_INVOICE) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.KINGAKU_CONTRACT) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.NAME_MEMO) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.FLAG_CONTINUE) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.DATE_ACTIVE) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.CODE_EDIT_STAFF) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.DATE_EDIT) & "" & Environment.NewLine)
        End With
        Call STR_SQL.Append(")" & Environment.NewLine)

        If Not FUNC_SYSTEM_DO_SQL_EXECUTE(STR_SQL.ToString) Then
            Return False
        End If

        Return True
    End Function
#End Region

#Region "CHECK"
    Public Function FUNC_CHECK_TABLE_MNT_T_CONTRACT(
    ByRef SRT_DATA As SRT_TABLE_MNT_T_CONTRACT_KEY
    ) As Boolean

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "COUNT(*)"
            ReDim .WHERE(2)
            .WHERE(1).COL_NAME = "NUMBER_CONTRACT"
            .WHERE(1).VALUE = SRT_DATA.NUMBER_CONTRACT
            .WHERE(2).COL_NAME = "SERIAL_CONTRACT"
            .WHERE(2).VALUE = SRT_DATA.SERIAL_CONTRACT
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)

        Dim INT_CNT As Integer
        INT_CNT = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_NUMERIC(STR_SQL, 0)

        Dim BLN_RET As Boolean
        BLN_RET = (INT_CNT > 0)
        Return BLN_RET
    End Function
#End Region

End Module

#End Region

#Region "MNT_T_CONTRACT_SPOT"

Public Module MOD_SYSTEM_INDIVIUAL_TABLE_STRUCTURE_MNT_T_CONTRACT_SPOT

#Region "モジュール用・定数"
    Private Const CST_TABLE_NAME_DEFAULT As String = "MNT_T_CONTRACT_SPOT"
#End Region

#Region "KEY"
    Public Structure SRT_TABLE_MNT_T_CONTRACT_SPOT_KEY
        Public NUMBER_CONTRACT As Integer
        Public SERIAL_CONTRACT As Integer
    End Structure
#End Region

#Region "DATA"
    Public Structure SRT_TABLE_MNT_T_CONTRACT_SPOT_DATA
        Public NUMBER_ORDER As Integer
        Public NAME_OWNER As String
        Public CODE_POST As Integer
        Public NAME_ADDRESS_01 As String
        Public NAME_ADDRESS_02 As String
    End Structure
#End Region

    Public Structure SRT_TABLE_MNT_T_CONTRACT_SPOT
        Public KEY As SRT_TABLE_MNT_T_CONTRACT_SPOT_KEY
        Public DATA As SRT_TABLE_MNT_T_CONTRACT_SPOT_DATA
    End Structure

#Region "CASH"
    Private CASH_TABLE() As SRT_TABLE_MNT_T_CONTRACT_SPOT

    Private Function FUNC_SEARCH_CASH(
    ByRef SRT_CASH() As SRT_TABLE_MNT_T_CONTRACT_SPOT, ByRef SRT_KEY As SRT_TABLE_MNT_T_CONTRACT_SPOT_KEY
    ) As Integer

        If IsNothing(SRT_CASH) Then
            Return -1
        End If

        For i = LBound(SRT_CASH) To UBound(SRT_CASH)
            With SRT_CASH(i)
                If .KEY.NUMBER_CONTRACT = SRT_KEY.NUMBER_CONTRACT _
                And .KEY.SERIAL_CONTRACT = SRT_KEY.SERIAL_CONTRACT Then
                    Return i
                End If
            End With
        Next

        Return -1
    End Function

    Private Sub SUB_ADD_CASH(
    ByRef SRT_CASH() As SRT_TABLE_MNT_T_CONTRACT_SPOT, ByRef SRT_CASH_ON As SRT_TABLE_MNT_T_CONTRACT_SPOT
    )
        Dim INT_SERACH As Integer
        INT_SERACH = FUNC_SEARCH_CASH(SRT_CASH, SRT_CASH_ON.KEY)
        If INT_SERACH <> -1 Then
            Exit Sub
        End If

        Dim INT_INDEX As Integer
        If IsNothing(SRT_CASH) Then
            INT_INDEX = 0
        Else
            INT_INDEX = UBound(SRT_CASH) + 1
        End If
        ReDim Preserve SRT_CASH(INT_INDEX)

        SRT_CASH(INT_INDEX) = SRT_CASH_ON
    End Sub
#End Region

#Region "SELECT"
    Public Function FUNC_SELECT_TABLE_MNT_T_CONTRACT_SPOT(
    ByRef SRT_DATA As SRT_TABLE_MNT_T_CONTRACT_SPOT_KEY,
    ByRef SRT_RET As SRT_TABLE_MNT_T_CONTRACT_SPOT_DATA,
    Optional ByVal BLN_CASH As Boolean = False
    ) As Boolean

        With SRT_RET
            .NUMBER_ORDER = 0
            .NAME_OWNER = ""
            .CODE_POST = 0
            .NAME_ADDRESS_01 = ""
            .NAME_ADDRESS_02 = ""
        End With

        If BLN_CASH Then
            Dim INT_CASH_INDEX As Integer
            INT_CASH_INDEX = FUNC_SEARCH_CASH(CASH_TABLE, SRT_DATA)
            If INT_CASH_INDEX <> -1 Then
                SRT_RET = CASH_TABLE(INT_CASH_INDEX).DATA
                Return True
            End If
        End If

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "*"
            ReDim .WHERE(2)
            .WHERE(1).COL_NAME = "NUMBER_CONTRACT"
            .WHERE(1).VALUE = SRT_DATA.NUMBER_CONTRACT
            .WHERE(2).COL_NAME = "SERIAL_CONTRACT"
            .WHERE(2).VALUE = SRT_DATA.SERIAL_CONTRACT
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)

        Dim SDR_READER As SqlClient.SqlDataReader
        SDR_READER = Nothing
        If Not FUNC_SYSTEM_GET_SQL_DATA_READER(STR_SQL, SDR_READER, CommandBehavior.SingleRow) Then
            Return False
        End If

        If Not SDR_READER.HasRows Then
            Call SDR_READER.Close()
            SDR_READER = Nothing
            Return True
        End If

        Call SDR_READER.Read()

        With SRT_RET
            .NUMBER_ORDER = CInt(SDR_READER.Item("NUMBER_ORDER"))
            .NAME_OWNER = CStr(SDR_READER.Item("NAME_OWNER"))
            .CODE_POST = CInt(SDR_READER.Item("CODE_POST"))
            .NAME_ADDRESS_01 = CStr(SDR_READER.Item("NAME_ADDRESS_01"))
            .NAME_ADDRESS_02 = CStr(SDR_READER.Item("NAME_ADDRESS_02"))
        End With

        Call SDR_READER.Close()
        SDR_READER = Nothing

        Dim SRT_CASH_ONE As SRT_TABLE_MNT_T_CONTRACT_SPOT
        SRT_CASH_ONE.KEY = SRT_DATA
        SRT_CASH_ONE.DATA = SRT_RET

        Call SUB_ADD_CASH(CASH_TABLE, SRT_CASH_ONE)

        Return True
    End Function
#End Region

#Region "DELETE"
    Public Function FUNC_DELETE_TABLE_MNT_T_CONTRACT_SPOT(
    ByRef SRT_DATA As SRT_TABLE_MNT_T_CONTRACT_SPOT_KEY
    ) As Boolean
        Dim SRT_SQL As SRT_SQL_TOOL_DELETE
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            ReDim .WHERE(2)
            .WHERE(1).COL_NAME = "NUMBER_CONTRACT"
            .WHERE(1).VALUE = SRT_DATA.NUMBER_CONTRACT
            .WHERE(2).COL_NAME = "SERIAL_CONTRACT"
            .WHERE(2).VALUE = SRT_DATA.SERIAL_CONTRACT
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_DELETE(SRT_SQL)

        If Not FUNC_SYSTEM_DO_SQL_EXECUTE(STR_SQL) Then
            Return False
        End If

        Return True
    End Function
#End Region

#Region "INSERT"
    Public Function FUNC_INSERT_TABLE_MNT_T_CONTRACT_SPOT(
    ByRef SRT_DATA As SRT_TABLE_MNT_T_CONTRACT_SPOT
    ) As Boolean

        Dim STR_SQL As System.Text.StringBuilder
        STR_SQL = New System.Text.StringBuilder
        Call STR_SQL.Append("INSERT" & Environment.NewLine)
        Call STR_SQL.Append("INTO" & Environment.NewLine)
        Call STR_SQL.Append(CST_TABLE_NAME_DEFAULT & " " & "WITH(ROWLOCK)" & Environment.NewLine)
        Call STR_SQL.Append("VALUES" & Environment.NewLine)
        Call STR_SQL.Append("(" & Environment.NewLine)
        With SRT_DATA.KEY
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.NUMBER_CONTRACT) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.SERIAL_CONTRACT) & "," & Environment.NewLine)
        End With
        With SRT_DATA.DATA
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.NUMBER_ORDER) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.NAME_OWNER) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.CODE_POST) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.NAME_ADDRESS_01) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.NAME_ADDRESS_02) & "" & Environment.NewLine)
        End With
        Call STR_SQL.Append(")" & Environment.NewLine)

        If Not FUNC_SYSTEM_DO_SQL_EXECUTE(STR_SQL.ToString) Then
            Return False
        End If

        Return True
    End Function
#End Region

#Region "CHECK"
    Public Function FUNC_CHECK_TABLE_MNT_T_CONTRACT_SPOT(
    ByRef SRT_DATA As SRT_TABLE_MNT_T_CONTRACT_SPOT_KEY
    ) As Boolean

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "COUNT(*)"
            ReDim .WHERE(2)
            .WHERE(1).COL_NAME = "NUMBER_CONTRACT"
            .WHERE(1).VALUE = SRT_DATA.NUMBER_CONTRACT
            .WHERE(2).COL_NAME = "SERIAL_CONTRACT"
            .WHERE(2).VALUE = SRT_DATA.SERIAL_CONTRACT
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)

        Dim INT_CNT As Integer
        INT_CNT = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_NUMERIC(STR_SQL, 0)

        Dim BLN_RET As Boolean
        BLN_RET = (INT_CNT > 0)
        Return BLN_RET
    End Function
#End Region

End Module

#End Region

#Region "MNT_T_INVOICE"

Public Module MOD_SYSTEM_INDIVIUAL_TABLE_STRUCTURE_MNT_T_INVOICE

#Region "モジュール用・定数"
    Private Const CST_TABLE_NAME_DEFAULT As String = "MNT_T_INVOICE"
#End Region

#Region "KEY"
    Public Structure SRT_TABLE_MNT_T_INVOICE_KEY
        Public NUMBER_CONTRACT As Integer
        Public SERIAL_CONTRACT As Integer
        Public SERIAL_INVOICE As Integer
    End Structure
#End Region

#Region "DATA"
    Public Structure SRT_TABLE_MNT_T_INVOICE_DATA
        Public DATE_INVOICE As DateTime
        Public CODE_SECTION As Integer
        Public KINGAKU_INVOICE_DETAIL As Long
        Public KINGAKU_INVOICE_VAT As Long
    End Structure
#End Region

    Public Structure SRT_TABLE_MNT_T_INVOICE
        Public KEY As SRT_TABLE_MNT_T_INVOICE_KEY
        Public DATA As SRT_TABLE_MNT_T_INVOICE_DATA
    End Structure

#Region "CASH"
    Private CASH_TABLE() As SRT_TABLE_MNT_T_INVOICE

    Private Function FUNC_SEARCH_CASH(
    ByRef SRT_CASH() As SRT_TABLE_MNT_T_INVOICE, ByRef SRT_KEY As SRT_TABLE_MNT_T_INVOICE_KEY
    ) As Integer

        If IsNothing(SRT_CASH) Then
            Return -1
        End If

        For i = LBound(SRT_CASH) To UBound(SRT_CASH)
            With SRT_CASH(i)
                If .KEY.NUMBER_CONTRACT = SRT_KEY.NUMBER_CONTRACT _
                And .KEY.SERIAL_CONTRACT = SRT_KEY.SERIAL_CONTRACT _
                And .KEY.SERIAL_INVOICE = SRT_KEY.SERIAL_INVOICE _
                Then
                    Return i
                End If
            End With
        Next

        Return -1
    End Function

    Private Sub SUB_ADD_CASH(
    ByRef SRT_CASH() As SRT_TABLE_MNT_T_INVOICE, ByRef SRT_CASH_ON As SRT_TABLE_MNT_T_INVOICE
    )
        Dim INT_SERACH As Integer
        INT_SERACH = FUNC_SEARCH_CASH(SRT_CASH, SRT_CASH_ON.KEY)
        If INT_SERACH <> -1 Then
            Exit Sub
        End If

        Dim INT_INDEX As Integer
        If IsNothing(SRT_CASH) Then
            INT_INDEX = 0
        Else
            INT_INDEX = UBound(SRT_CASH) + 1
        End If
        ReDim Preserve SRT_CASH(INT_INDEX)

        SRT_CASH(INT_INDEX) = SRT_CASH_ON
    End Sub
#End Region

#Region "SELECT"
    Public Function FUNC_SELECT_TABLE_MNT_T_INVOICE(
    ByRef SRT_DATA As SRT_TABLE_MNT_T_INVOICE_KEY,
    ByRef SRT_RET As SRT_TABLE_MNT_T_INVOICE_DATA,
    Optional ByVal BLN_CASH As Boolean = False
    ) As Boolean

        With SRT_RET
            .DATE_INVOICE = cstVB_DATE_MIN
            .CODE_SECTION = -1
            .KINGAKU_INVOICE_DETAIL = 0
            .KINGAKU_INVOICE_VAT = 0
        End With

        If BLN_CASH Then
            Dim INT_CASH_INDEX As Integer
            INT_CASH_INDEX = FUNC_SEARCH_CASH(CASH_TABLE, SRT_DATA)
            If INT_CASH_INDEX <> -1 Then
                SRT_RET = CASH_TABLE(INT_CASH_INDEX).DATA
                Return True
            End If
        End If

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "*"
            ReDim .WHERE(3)
            .WHERE(1).COL_NAME = "NUMBER_CONTRACT"
            .WHERE(1).VALUE = SRT_DATA.NUMBER_CONTRACT
            .WHERE(2).COL_NAME = "SERIAL_CONTRACT"
            .WHERE(2).VALUE = SRT_DATA.SERIAL_CONTRACT
            .WHERE(3).COL_NAME = "SERIAL_INVOICE"
            .WHERE(3).VALUE = SRT_DATA.SERIAL_INVOICE
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)

        Dim SDR_READER As SqlClient.SqlDataReader
        SDR_READER = Nothing
        If Not FUNC_SYSTEM_GET_SQL_DATA_READER(STR_SQL, SDR_READER, CommandBehavior.SingleRow) Then
            Return False
        End If

        If Not SDR_READER.HasRows Then
            Call SDR_READER.Close()
            SDR_READER = Nothing
            Return True
        End If

        Call SDR_READER.Read()

        With SRT_RET
            .DATE_INVOICE = CDate(SDR_READER.Item("DATE_INVOICE"))
            .CODE_SECTION = CInt(SDR_READER.Item("CODE_SECTION"))
            .KINGAKU_INVOICE_DETAIL = CLng(SDR_READER.Item("KINGAKU_INVOICE_DETAIL"))
            .KINGAKU_INVOICE_VAT = CLng(SDR_READER.Item("KINGAKU_INVOICE_VAT"))
        End With

        Call SDR_READER.Close()
        SDR_READER = Nothing

        Dim SRT_CASH_ONE As SRT_TABLE_MNT_T_INVOICE
        SRT_CASH_ONE.KEY = SRT_DATA
        SRT_CASH_ONE.DATA = SRT_RET

        Call SUB_ADD_CASH(CASH_TABLE, SRT_CASH_ONE)

        Return True
    End Function
#End Region

#Region "DELETE"
    Public Function FUNC_DELETE_TABLE_MNT_T_INVOICE(
    ByRef SRT_DATA As SRT_TABLE_MNT_T_INVOICE_KEY
    ) As Boolean
        Dim SRT_SQL As SRT_SQL_TOOL_DELETE
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            ReDim .WHERE(3)
            .WHERE(1).COL_NAME = "NUMBER_CONTRACT"
            .WHERE(1).VALUE = SRT_DATA.NUMBER_CONTRACT
            .WHERE(2).COL_NAME = "SERIAL_CONTRACT"
            .WHERE(2).VALUE = SRT_DATA.SERIAL_CONTRACT
            .WHERE(3).COL_NAME = "SERIAL_INVOICE"
            .WHERE(3).VALUE = SRT_DATA.SERIAL_INVOICE
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_DELETE(SRT_SQL)

        If Not FUNC_SYSTEM_DO_SQL_EXECUTE(STR_SQL) Then
            Return False
        End If

        Return True
    End Function
#End Region

#Region "INSERT"
    Public Function FUNC_INSERT_TABLE_MNT_T_INVOICE(
    ByRef SRT_DATA As SRT_TABLE_MNT_T_INVOICE
    ) As Boolean

        Dim STR_SQL As System.Text.StringBuilder
        STR_SQL = New System.Text.StringBuilder
        Call STR_SQL.Append("INSERT" & Environment.NewLine)
        Call STR_SQL.Append("INTO" & Environment.NewLine)
        Call STR_SQL.Append(CST_TABLE_NAME_DEFAULT & " " & "WITH(ROWLOCK)" & Environment.NewLine)
        Call STR_SQL.Append("VALUES" & Environment.NewLine)
        Call STR_SQL.Append("(" & Environment.NewLine)
        With SRT_DATA.KEY
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.NUMBER_CONTRACT) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.SERIAL_CONTRACT) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.SERIAL_INVOICE) & "," & Environment.NewLine)
        End With
        With SRT_DATA.DATA
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.DATE_INVOICE) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.CODE_SECTION) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.KINGAKU_INVOICE_DETAIL) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.KINGAKU_INVOICE_VAT) & "" & Environment.NewLine)
        End With
        Call STR_SQL.Append(")" & Environment.NewLine)

        If Not FUNC_SYSTEM_DO_SQL_EXECUTE(STR_SQL.ToString) Then
            Return False
        End If

        Return True
    End Function
#End Region

#Region "CHECK"
    Public Function FUNC_CHECK_TABLE_MNT_T_INVOICE(
    ByRef SRT_DATA As SRT_TABLE_MNT_T_INVOICE_KEY
    ) As Boolean

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "COUNT(*)"
            ReDim .WHERE(3)
            .WHERE(1).COL_NAME = "NUMBER_CONTRACT"
            .WHERE(1).VALUE = SRT_DATA.NUMBER_CONTRACT
            .WHERE(2).COL_NAME = "SERIAL_CONTRACT"
            .WHERE(2).VALUE = SRT_DATA.SERIAL_CONTRACT
            .WHERE(3).COL_NAME = "SERIAL_INVOICE"
            .WHERE(3).VALUE = SRT_DATA.SERIAL_INVOICE
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)

        Dim INT_CNT As Integer
        INT_CNT = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_NUMERIC(STR_SQL, 0)

        Dim BLN_RET As Boolean
        BLN_RET = (INT_CNT > 0)
        Return BLN_RET
    End Function
#End Region

End Module

#End Region

#Region "MNT_T_DEPOSIT"

Public Module MOD_SYSTEM_INDIVIUAL_TABLE_STRUCTURE_MNT_T_DEPOSIT

#Region "モジュール用・定数"
    Private Const CST_TABLE_NAME_DEFAULT As String = "MNT_T_DEPOSIT"
#End Region

#Region "KEY"
    Public Structure SRT_TABLE_MNT_T_DEPOSIT_KEY
        Public NUMBER_CONTRACT As Integer
        Public SERIAL_CONTRACT As Integer
        Public SERIAL_INVOICE As Integer
    End Structure
#End Region

#Region "DATA"
    Public Structure SRT_TABLE_MNT_T_DEPOSIT_DATA
        Public DATE_DEPOSIT As DateTime
        Public FLAG_SALE As Integer
        Public FLAG_DEPOSIT As Integer
        Public FLAG_DEPOSIT_SUB As Integer
        Public KINGAKU_FEE_DETAIL As Long
        Public KINGAKU_FEE_VAT As Long
        Public FLAG_COST As Integer
        Public KINGAKU_COST_DETAIL As Long
        Public KINGAKU_COST_VAT As Long
        Public NAME_MEMO As String
        Public SERIAL_DEPOSIT As Integer
        Public FLAG_OUTPUT As Integer
        Public DATE_ACTIVE As DateTime
        Public CODE_EDIT_STAFF As Integer
        Public DATE_EDIT As DateTime
    End Structure
#End Region

    Public Structure SRT_TABLE_MNT_T_DEPOSIT
        Public KEY As SRT_TABLE_MNT_T_DEPOSIT_KEY
        Public DATA As SRT_TABLE_MNT_T_DEPOSIT_DATA
    End Structure

#Region "CASH"
    Private CASH_TABLE() As SRT_TABLE_MNT_T_DEPOSIT

    Private Function FUNC_SEARCH_CASH(
    ByRef SRT_CASH() As SRT_TABLE_MNT_T_DEPOSIT, ByRef SRT_KEY As SRT_TABLE_MNT_T_DEPOSIT_KEY
    ) As Integer

        If IsNothing(SRT_CASH) Then
            Return -1
        End If

        For i = LBound(SRT_CASH) To UBound(SRT_CASH)
            With SRT_CASH(i)
                If .KEY.NUMBER_CONTRACT = SRT_KEY.NUMBER_CONTRACT _
                And .KEY.SERIAL_CONTRACT = SRT_KEY.SERIAL_CONTRACT _
                And .KEY.SERIAL_INVOICE = SRT_KEY.SERIAL_INVOICE _
                Then
                    Return i
                End If
            End With
        Next

        Return -1
    End Function

    Private Sub SUB_ADD_CASH(
    ByRef SRT_CASH() As SRT_TABLE_MNT_T_DEPOSIT, ByRef SRT_CASH_ON As SRT_TABLE_MNT_T_DEPOSIT
    )
        Dim INT_SERACH As Integer
        INT_SERACH = FUNC_SEARCH_CASH(SRT_CASH, SRT_CASH_ON.KEY)
        If INT_SERACH <> -1 Then
            Exit Sub
        End If

        Dim INT_INDEX As Integer
        If IsNothing(SRT_CASH) Then
            INT_INDEX = 0
        Else
            INT_INDEX = UBound(SRT_CASH) + 1
        End If
        ReDim Preserve SRT_CASH(INT_INDEX)

        SRT_CASH(INT_INDEX) = SRT_CASH_ON
    End Sub
#End Region

#Region "SELECT"
    Public Function FUNC_SELECT_TABLE_MNT_T_DEPOSIT(
    ByRef SRT_DATA As SRT_TABLE_MNT_T_DEPOSIT_KEY,
    ByRef SRT_RET As SRT_TABLE_MNT_T_DEPOSIT_DATA,
    Optional ByVal BLN_CASH As Boolean = False
    ) As Boolean

        With SRT_RET
            .DATE_DEPOSIT = cstVB_DATE_MIN
            .FLAG_SALE = -1
            .FLAG_DEPOSIT = -1
            .FLAG_DEPOSIT_SUB = -1
            .KINGAKU_FEE_DETAIL = 0
            .KINGAKU_FEE_VAT = 0
            .FLAG_COST = -1
            .KINGAKU_COST_DETAIL = 0
            .KINGAKU_COST_VAT = 0
            .NAME_MEMO = ""
            .SERIAL_DEPOSIT = 0
            .FLAG_OUTPUT = -1
            .DATE_ACTIVE = cstVB_DATE_MIN
            .CODE_EDIT_STAFF = -1
            .DATE_EDIT = cstVB_DATE_MIN
        End With

        If BLN_CASH Then
            Dim INT_CASH_INDEX As Integer
            INT_CASH_INDEX = FUNC_SEARCH_CASH(CASH_TABLE, SRT_DATA)
            If INT_CASH_INDEX <> -1 Then
                SRT_RET = CASH_TABLE(INT_CASH_INDEX).DATA
                Return True
            End If
        End If

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "*"
            ReDim .WHERE(3)
            .WHERE(1).COL_NAME = "NUMBER_CONTRACT"
            .WHERE(1).VALUE = SRT_DATA.NUMBER_CONTRACT
            .WHERE(2).COL_NAME = "SERIAL_CONTRACT"
            .WHERE(2).VALUE = SRT_DATA.SERIAL_CONTRACT
            .WHERE(3).COL_NAME = "SERIAL_INVOICE"
            .WHERE(3).VALUE = SRT_DATA.SERIAL_INVOICE
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)

        Dim SDR_READER As SqlClient.SqlDataReader
        SDR_READER = Nothing
        If Not FUNC_SYSTEM_GET_SQL_DATA_READER(STR_SQL, SDR_READER, CommandBehavior.SingleRow) Then
            Return False
        End If

        If Not SDR_READER.HasRows Then
            Call SDR_READER.Close()
            SDR_READER = Nothing
            Return True
        End If

        Call SDR_READER.Read()

        With SRT_RET
            .DATE_DEPOSIT = CDate(SDR_READER.Item("DATE_DEPOSIT"))
            .FLAG_SALE = CInt(SDR_READER.Item("FLAG_SALE"))
            .FLAG_DEPOSIT = CInt(SDR_READER.Item("FLAG_DEPOSIT"))
            .FLAG_DEPOSIT_SUB = CInt(SDR_READER.Item("FLAG_DEPOSIT_SUB"))
            .KINGAKU_FEE_DETAIL = CLng(SDR_READER.Item("KINGAKU_FEE_DETAIL"))
            .KINGAKU_FEE_VAT = CLng(SDR_READER.Item("KINGAKU_FEE_VAT"))
            .FLAG_COST = CInt(SDR_READER.Item("FLAG_COST"))
            .KINGAKU_COST_DETAIL = CLng(SDR_READER.Item("KINGAKU_COST_DETAIL"))
            .KINGAKU_COST_VAT = CLng(SDR_READER.Item("KINGAKU_COST_VAT"))
            .NAME_MEMO = CStr(SDR_READER.Item("NAME_MEMO"))
            .SERIAL_DEPOSIT = CInt(SDR_READER.Item("SERIAL_DEPOSIT"))
            .FLAG_OUTPUT = CInt(SDR_READER.Item("FLAG_OUTPUT"))
            .DATE_ACTIVE = CDate(SDR_READER.Item("DATE_ACTIVE"))
            .CODE_EDIT_STAFF = CInt(SDR_READER.Item("CODE_EDIT_STAFF"))
            .DATE_EDIT = CDate(SDR_READER.Item("DATE_EDIT"))
        End With

        Call SDR_READER.Close()
        SDR_READER = Nothing

        Dim SRT_CASH_ONE As SRT_TABLE_MNT_T_DEPOSIT
        SRT_CASH_ONE.KEY = SRT_DATA
        SRT_CASH_ONE.DATA = SRT_RET

        Call SUB_ADD_CASH(CASH_TABLE, SRT_CASH_ONE)

        Return True
    End Function
#End Region

#Region "DELETE"
    Public Function FUNC_DELETE_TABLE_MNT_T_DEPOSIT(
    ByRef SRT_DATA As SRT_TABLE_MNT_T_DEPOSIT_KEY
    ) As Boolean
        Dim SRT_SQL As SRT_SQL_TOOL_DELETE
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            ReDim .WHERE(3)
            .WHERE(1).COL_NAME = "NUMBER_CONTRACT"
            .WHERE(1).VALUE = SRT_DATA.NUMBER_CONTRACT
            .WHERE(2).COL_NAME = "SERIAL_CONTRACT"
            .WHERE(2).VALUE = SRT_DATA.SERIAL_CONTRACT
            .WHERE(3).COL_NAME = "SERIAL_INVOICE"
            .WHERE(3).VALUE = SRT_DATA.SERIAL_INVOICE
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_DELETE(SRT_SQL)

        If Not FUNC_SYSTEM_DO_SQL_EXECUTE(STR_SQL) Then
            Return False
        End If

        Return True
    End Function
#End Region

#Region "INSERT"
    Public Function FUNC_INSERT_TABLE_MNT_T_DEPOSIT(
    ByRef SRT_DATA As SRT_TABLE_MNT_T_DEPOSIT
    ) As Boolean

        Dim STR_SQL As System.Text.StringBuilder
        STR_SQL = New System.Text.StringBuilder
        Call STR_SQL.Append("INSERT" & Environment.NewLine)
        Call STR_SQL.Append("INTO" & Environment.NewLine)
        Call STR_SQL.Append(CST_TABLE_NAME_DEFAULT & " " & "WITH(ROWLOCK)" & Environment.NewLine)
        Call STR_SQL.Append("VALUES" & Environment.NewLine)
        Call STR_SQL.Append("(" & Environment.NewLine)
        With SRT_DATA.KEY
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.NUMBER_CONTRACT) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.SERIAL_CONTRACT) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.SERIAL_INVOICE) & "," & Environment.NewLine)
        End With
        With SRT_DATA.DATA
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.DATE_DEPOSIT) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.FLAG_SALE) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.FLAG_DEPOSIT) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.FLAG_DEPOSIT_SUB) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.KINGAKU_FEE_DETAIL) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.KINGAKU_FEE_VAT) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.FLAG_COST) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.KINGAKU_COST_DETAIL) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.KINGAKU_COST_VAT) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.NAME_MEMO) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.SERIAL_DEPOSIT) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.FLAG_OUTPUT) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.DATE_ACTIVE) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.CODE_EDIT_STAFF) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.DATE_EDIT) & "" & Environment.NewLine)

        End With

        Call STR_SQL.Append(")" & Environment.NewLine)

        If Not FUNC_SYSTEM_DO_SQL_EXECUTE(STR_SQL.ToString) Then
            Return False
        End If

        Return True
    End Function
#End Region

#Region "CHECK"
    Public Function FUNC_CHECK_TABLE_MNT_T_DEPOSIT(
    ByRef SRT_DATA As SRT_TABLE_MNT_T_DEPOSIT_KEY
    ) As Boolean

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "COUNT(*)"
            ReDim .WHERE(3)
            .WHERE(1).COL_NAME = "NUMBER_CONTRACT"
            .WHERE(1).VALUE = SRT_DATA.NUMBER_CONTRACT
            .WHERE(2).COL_NAME = "SERIAL_CONTRACT"
            .WHERE(2).VALUE = SRT_DATA.SERIAL_CONTRACT
            .WHERE(3).COL_NAME = "SERIAL_INVOICE"
            .WHERE(3).VALUE = SRT_DATA.SERIAL_INVOICE
            .ORDER_KEY = ""
        End With

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL_TOOL_SELECT_ONE_COL(SRT_SQL)

        Dim INT_CNT As Integer
        INT_CNT = FUNC_SYSTEM_GET_SQL_SINGLE_VALUE_NUMERIC(STR_SQL, 0)

        Dim BLN_RET As Boolean
        BLN_RET = (INT_CNT > 0)
        Return BLN_RET
    End Function
#End Region

End Module

#End Region
