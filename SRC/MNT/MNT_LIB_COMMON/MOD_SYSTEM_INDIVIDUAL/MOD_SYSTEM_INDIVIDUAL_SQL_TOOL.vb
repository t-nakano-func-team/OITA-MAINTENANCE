Module MOD_SYSTEM_INDIVIDUAL_SQL_TOOL

    Public Function FUNC_GET_SQL_WHERE_INT(ByVal intVALUE As Integer, ByVal srtFIELD As String, ByVal srtSIGN As String) As String
        Dim strWHERE As String
        strWHERE = ""

        If intVALUE < 0 Then
            Return strWHERE
        End If

        strWHERE &= " AND " & srtFIELD & srtSIGN & intVALUE & Environment.NewLine

        Return strWHERE
    End Function

    Public Function FUNC_GET_SQL_WHERE_STR(ByVal strVALUE As String, ByVal srtFIELD As String, ByVal srtSIGN As String) As String
        Dim strWHERE As String
        strWHERE = ""

        strWHERE &= " AND " & srtFIELD & srtSIGN & FUNC_ADD_ENCLOSED_SCOT(strVALUE) & Environment.NewLine

        Return strWHERE
    End Function

    Public Function FUNC_GET_SQL_WHERE_DATE_FROM_TO(ByVal srtVALUE As SRT_DATE_PERIOD, ByVal srtFIELD As String) As String
        Dim strWHERE As String
        strWHERE = ""

        strWHERE &= " AND " & srtFIELD & ">=" & FUNC_ADD_ENCLOSED_SCOT(srtVALUE.DATE_FROM.ToShortDateString) & Environment.NewLine
        strWHERE &= " AND " & srtFIELD & "<=" & FUNC_ADD_ENCLOSED_SCOT(srtVALUE.DATE_TO.ToShortDateString) & Environment.NewLine

        Return strWHERE
    End Function

    Public Function FUNC_GET_SQL_WHERE_STR_LIKE(ByVal srtVALUE As String, ByVal srtFIELD As String) As String
        Dim strWHERE As String
        strWHERE = ""

        If srtVALUE = "" Then
            Return strWHERE
        End If

        strWHERE &= " AND " & srtFIELD & " LIKE '%" & srtVALUE & "%'" & Environment.NewLine

        Return strWHERE
    End Function
End Module
