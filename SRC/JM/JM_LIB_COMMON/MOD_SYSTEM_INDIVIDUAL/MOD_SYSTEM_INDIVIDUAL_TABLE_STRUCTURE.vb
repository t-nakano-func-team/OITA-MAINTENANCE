Module MOD_SYSTEM_INDIVIDUAL_TABLE_STRUCTURE

End Module

#Region "JM_M_CUSTOMER"

Public Module MOD_SYSTEM_INDIVIUAL_TABLE_STRUCTURE_JM_M_CUSTOMER

#Region "モジュール用・定数"
    Private Const CST_TABLE_NAME_DEFAULT As String = "JM_M_CUSTOMER"
#End Region

#Region "KEY"
    Public Structure SRT_TABLE_JM_M_CUSTOMER_KEY
        Public NUMBER_USER As Integer
        Public CODE_CUSTOMER As Integer
    End Structure
#End Region

#Region "DATA"
    Public Structure SRT_TABLE_JM_M_CUSTOMER_DATA
        Public NAME_CUSTOMER As String
        Public FLAG_INVALID As Integer
    End Structure
#End Region

    Public Structure SRT_TABLE_JM_M_CUSTOMER
        Public KEY As SRT_TABLE_JM_M_CUSTOMER_KEY
        Public DATA As SRT_TABLE_JM_M_CUSTOMER_DATA
    End Structure

#Region "CASH"
    Private CASH_TABLE() As SRT_TABLE_JM_M_CUSTOMER

    Private Function FUNC_SEARCH_CASH(
    ByRef SRT_CASH() As SRT_TABLE_JM_M_CUSTOMER, ByRef SRT_KEY As SRT_TABLE_JM_M_CUSTOMER_KEY
    ) As Integer


        If IsNothing(SRT_CASH) Then
            Return -1
        End If

        For i = LBound(SRT_CASH) To UBound(SRT_CASH)
            With SRT_CASH(i)
                If .KEY.NUMBER_USER = SRT_KEY.NUMBER_USER _
                    And .KEY.CODE_CUSTOMER = SRT_KEY.CODE_CUSTOMER Then
                    Return i
                End If
            End With
        Next

        Return -1
    End Function

    Private Sub SUB_ADD_CASH(
    ByRef SRT_CASH() As SRT_TABLE_JM_M_CUSTOMER, ByRef SRT_CASH_ON As SRT_TABLE_JM_M_CUSTOMER
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
    Public Function FUNC_SELECT_TABLE_JM_M_CUSTOMER(
    ByRef SRT_DATA As SRT_TABLE_JM_M_CUSTOMER_KEY,
    ByRef SRT_RET As SRT_TABLE_JM_M_CUSTOMER_DATA,
    Optional ByVal BLN_CASH As Boolean = False
    ) As Boolean

        With SRT_RET
            .NAME_CUSTOMER = ""
            .FLAG_INVALID = -1
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
            .WHERE(1).COL_NAME = "NUMBER_USER"
            .WHERE(1).VALUE = SRT_DATA.NUMBER_USER
            .WHERE(2).COL_NAME = "CODE_CUSTOMER"
            .WHERE(2).VALUE = SRT_DATA.CODE_CUSTOMER
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
            .NAME_CUSTOMER = CStr(SDR_READER.Item("NAME_CUSTOMER"))
            .FLAG_INVALID = CInt(SDR_READER.Item("FLAG_INVALID"))
        End With

        Call SDR_READER.Close()
        SDR_READER = Nothing

        Dim SRT_CASH_ONE As SRT_TABLE_JM_M_CUSTOMER
        SRT_CASH_ONE.KEY = SRT_DATA
        SRT_CASH_ONE.DATA = SRT_RET

        Call SUB_ADD_CASH(CASH_TABLE, SRT_CASH_ONE)

        Return True
    End Function
#End Region

#Region "DELETE"
    Public Function FUNC_DELETE_TABLE_JM_M_CUSTOMER(
    ByRef SRT_DATA As SRT_TABLE_JM_M_CUSTOMER_KEY
    ) As Boolean
        Dim SRT_SQL As SRT_SQL_TOOL_DELETE
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            ReDim .WHERE(2)
            .WHERE(1).COL_NAME = "NUMBER_USER"
            .WHERE(1).VALUE = SRT_DATA.NUMBER_USER
            .WHERE(2).COL_NAME = "CODE_CUSTOMER"
            .WHERE(2).VALUE = SRT_DATA.CODE_CUSTOMER
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
    Public Function FUNC_INSERT_TABLE_JM_M_CUSTOMER(
    ByRef SRT_DATA As SRT_TABLE_JM_M_CUSTOMER
    ) As Boolean

        Dim STR_SQL As System.Text.StringBuilder
        STR_SQL = New System.Text.StringBuilder
        Call STR_SQL.Append("INSERT" & Environment.NewLine)
        Call STR_SQL.Append("INTO" & Environment.NewLine)
        Call STR_SQL.Append(CST_TABLE_NAME_DEFAULT & " " & "WITH(ROWLOCK)" & Environment.NewLine)
        Call STR_SQL.Append("VALUES" & Environment.NewLine)
        Call STR_SQL.Append("(" & Environment.NewLine)
        With SRT_DATA.KEY
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.NUMBER_USER) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.CODE_CUSTOMER) & "," & Environment.NewLine)
        End With
        With SRT_DATA.DATA
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.NAME_CUSTOMER) & "," & Environment.NewLine)
            Call STR_SQL.Append(FUNC_GET_VALUE_SQL_STRING(.FLAG_INVALID) & "" & Environment.NewLine)
        End With
        Call STR_SQL.Append(")" & Environment.NewLine)

        If Not FUNC_SYSTEM_DO_SQL_EXECUTE(STR_SQL.ToString) Then
            Return False
        End If

        Return True
    End Function
#End Region

#Region "CHECK"
    Public Function FUNC_CHECK_TABLE_JM_M_CUSTOMER(
    ByRef SRT_DATA As SRT_TABLE_JM_M_CUSTOMER_KEY
    ) As Boolean

        Dim SRT_SQL As SRT_SQL_TOOL_SELECT_ONE_COL
        With SRT_SQL
            .TABLE_NAME = CST_TABLE_NAME_DEFAULT
            .COL_NAME = "COUNT(*)"
            ReDim .WHERE(2)
            .WHERE(1).COL_NAME = "NUMBER_USER"
            .WHERE(1).VALUE = SRT_DATA.NUMBER_USER
            .WHERE(2).COL_NAME = "CODE_CUSTOMER"
            .WHERE(2).VALUE = SRT_DATA.CODE_CUSTOMER
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
