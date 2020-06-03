Public Module MOD_SYSTEM_INDIVIDUAL_SQL_TOOL

    Public Function FUNC_GET_SQL_WHERE_INT(ByVal intVALUE As Integer, ByVal STR_FIELD As String, ByVal STR_SIGN As String) As String
        Dim STR_WHERE As String
        STR_WHERE = ""

        If intVALUE < 0 Then
            Return STR_WHERE
        End If

        STR_WHERE &= " AND " & STR_FIELD & STR_SIGN & intVALUE & Environment.NewLine

        Return STR_WHERE
    End Function

    Public Function FUNC_GET_SQL_WHERE_STR(ByVal strVALUE As String, ByVal STR_FIELD As String, ByVal STR_SIGN As String) As String
        Dim STR_WHERE As String
        STR_WHERE = ""

        STR_WHERE &= " AND " & STR_FIELD & STR_SIGN & FUNC_ADD_ENCLOSED_SCOT(strVALUE) & Environment.NewLine

        Return STR_WHERE
    End Function

    Public Function FUNC_GET_SQL_WHERE_DATE(ByVal DAT_VALUE As DateTime, ByVal STR_FIELD As String, ByVal STR_SIGN As String) As String
        Dim STR_WHERE As String
        STR_WHERE = ""
        STR_WHERE &= " AND " & STR_FIELD & STR_SIGN & FUNC_ADD_ENCLOSED_SCOT(DAT_VALUE) & Environment.NewLine

        Return STR_WHERE
    End Function

    Public Function FUNC_GET_SQL_WHERE_DATE_FROM_TO(ByVal SRT_VALUE As SRT_DATE_PERIOD, ByVal STR_FIELD As String) As String
        Dim STR_WHERE As String
        STR_WHERE = ""

        STR_WHERE &= " AND " & STR_FIELD & ">=" & FUNC_ADD_ENCLOSED_SCOT(SRT_VALUE.DATE_FROM.ToShortDateString) & Environment.NewLine
        STR_WHERE &= " AND " & STR_FIELD & "<=" & FUNC_ADD_ENCLOSED_SCOT(SRT_VALUE.DATE_TO.ToShortDateString) & Environment.NewLine

        Return STR_WHERE
    End Function

    Public Function FUNC_GET_SQL_WHERE_STR_LIKE(ByVal STR_VALUE As String, ByVal STR_FIELD As String) As String
        Dim STR_WHERE As String
        STR_WHERE = ""

        If STR_VALUE = "" Then
            Return STR_WHERE
        End If

        STR_WHERE &= " AND " & STR_FIELD & " LIKE '%" & STR_VALUE & "%'" & Environment.NewLine

        Return STR_WHERE
    End Function
End Module
