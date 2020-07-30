Module MOD_BATCH

#Region "バッチ用・変数"
    Friend STR_FUNC_BATCH_MAIN_ERR_STR As String '最終エラー文字列
#End Region

#Region "バッチ用・構造体"
    Public Structure SRT_BATCH_CONDITIONS 'バッチ条件
        Public YYYYMM_B_MONTH As Integer

        Public DATE_DO_BATCH As DateTime
        Public FORM As Object

        Public RET_DELETE_CONTENT_COUNT As Integer
    End Structure

#End Region

    Friend Function FUNC_BACTH_MAIN(ByRef BLN_PUT As Boolean, ByRef SRT_CONDITIONS As SRT_BATCH_CONDITIONS) As Boolean
        BLN_PUT = True 'データ無しケースを考慮しない
        SRT_CONDITIONS.RET_DELETE_CONTENT_COUNT = 0

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL(SRT_CONDITIONS)

        Dim SDR_READER As SqlClient.SqlDataReader
        SDR_READER = Nothing
        If Not FUNC_SYSTEM_GET_SQL_DATA_READER(STR_SQL.ToString, SDR_READER) Then
            STR_FUNC_BATCH_MAIN_ERR_STR = str_SQL_TOOL_LAST_ERR_STRING
            Return False
        End If

        'If Not SDR_READER.HasRows Then
        '    Call SDR_READER.Close()
        '    SDR_READER = Nothing
        '    Return True 'データなし正常終了
        'End If

        Dim SRT_CONTRACT_ALL() As SRT_TABLE_MNT_T_CONTRACT '対象の契約すべて（定期かつ自動更新かつ契約連番が最大）
        ReDim SRT_CONTRACT_ALL(0)
        While SDR_READER.Read
            Dim INT_INDEX As Integer
            INT_INDEX = (SRT_CONTRACT_ALL.Length)
            ReDim Preserve SRT_CONTRACT_ALL(INT_INDEX)
            If INT_INDEX Mod 5 = 0 Then Call SUB_PUT_GUIDE(SRT_CONDITIONS.FORM, "最新契約取得中：" & INT_INDEX)

            With SRT_CONTRACT_ALL(INT_INDEX).KEY
                .NUMBER_CONTRACT = CInt(SDR_READER.Item("NUMBER_CONTRACT"))
                .SERIAL_CONTRACT = CInt(SDR_READER.Item("SERIAL_CONTRACT"))
            End With
            With SRT_CONTRACT_ALL(INT_INDEX).DATA
                .FLAG_CONTRACT = CInt(SDR_READER.Item("FLAG_CONTRACT"))
                .DATE_CONTRACT = CDate(SDR_READER.Item("DATE_CONTRACT"))
                .CODE_OWNER = CInt(SDR_READER.Item("CODE_OWNER"))
                .CODE_SECTION = CInt(SDR_READER.Item("CODE_SECTION"))
                .CODE_MAINTENANCE = CInt(SDR_READER.Item("CODE_MAINTENANCE"))
                .NAME_CONTRACT = CStr(SDR_READER.Item("NAME_CONTRACT"))
                .DATE_MAINTENANCE_START = CDate(SDR_READER.Item("DATE_MAINTENANCE_START"))
                .DATE_MAINTENANCE_END = CDate(SDR_READER.Item("DATE_MAINTENANCE_END"))
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
        End While

        Call SDR_READER.Close()
        SDR_READER = Nothing

        Dim SRT_CONTRACT_TARGET() As SRT_TABLE_MNT_T_CONTRACT '契約更新対象
        ReDim SRT_CONTRACT_TARGET(0)

        Dim INT_INDEX_MAX As Integer
        INT_INDEX_MAX = (SRT_CONTRACT_ALL.Length - 1)
        For i = 1 To (SRT_CONTRACT_ALL.Length - 1)
            If i Mod 5 = 0 Then Call SUB_PUT_GUIDE(SRT_CONDITIONS.FORM, "請求情報判断中：" & i & "/" & INT_INDEX_MAX)
            With SRT_CONTRACT_ALL(i)
                Dim INT_SERIAL_INVOICE_MAX As Integer
                INT_SERIAL_INVOICE_MAX = FUNC_GET_MNT_T_INVOICE_MAX_SERIAL_INVOICE(.KEY.NUMBER_CONTRACT, .KEY.SERIAL_CONTRACT)

                If INT_SERIAL_INVOICE_MAX > 0 Then '一度でも請求があれば
                    Continue For '対象外
                End If

                Dim INT_SERIAL_CONTRACT_BEFORE As Integer
                INT_SERIAL_CONTRACT_BEFORE = .KEY.SERIAL_CONTRACT - 1 '一つ前
                Dim INT_SERIAL_INVOICE_MAX_BEFORE As Integer
                INT_SERIAL_INVOICE_MAX_BEFORE = FUNC_GET_MNT_T_INVOICE_MAX_SERIAL_INVOICE(.KEY.NUMBER_CONTRACT, INT_SERIAL_CONTRACT_BEFORE)
                Dim SRT_INVOICE As SRT_TABLE_MNT_T_INVOICE
                SRT_INVOICE.KEY.NUMBER_CONTRACT = .KEY.NUMBER_CONTRACT
                SRT_INVOICE.KEY.SERIAL_CONTRACT = INT_SERIAL_CONTRACT_BEFORE
                SRT_INVOICE.KEY.SERIAL_INVOICE = INT_SERIAL_INVOICE_MAX_BEFORE
                SRT_INVOICE.DATA = Nothing
                Call FUNC_SELECT_TABLE_MNT_T_INVOICE(SRT_INVOICE.KEY, SRT_INVOICE.DATA)
                Dim DAT_DATE_INVOICE As DateTime
                DAT_DATE_INVOICE = SRT_INVOICE.DATA.DATE_INVOICE

                Dim INT_YYYYNN_B_MONTH_CANCEL As Integer 'キャンセルされる月次
                INT_YYYYNN_B_MONTH_CANCEL = FUNC_ADD_MONTH_YYYYMM(SRT_CONDITIONS.YYYYMM_B_MONTH, 1)
                Dim DAT_DATE_MONTH_LAST As DateTime
                DAT_DATE_MONTH_LAST = FUNC_GET_DATE_LAST_FROM_YEARMONTH(INT_YYYYNN_B_MONTH_CANCEL)
                Dim DAT_DATE_MONTH_FIRST As DateTime
                DAT_DATE_MONTH_FIRST = FUNC_GET_DATE_FROM_YEARMONTH(INT_YYYYNN_B_MONTH_CANCEL)
                If Not (DAT_DATE_MONTH_FIRST <= DAT_DATE_INVOICE And DAT_DATE_INVOICE <= DAT_DATE_MONTH_LAST) Then '対象月次期間が最終請求日でない場合は
                    Exit For '対象外
                End If

            End With

            Dim INT_INDEX As Integer
            INT_INDEX = (SRT_CONTRACT_TARGET.Length)
            ReDim Preserve SRT_CONTRACT_TARGET(INT_INDEX)
            SRT_CONTRACT_TARGET(INT_INDEX) = SRT_CONTRACT_ALL(i)
        Next

        SRT_CONDITIONS.RET_DELETE_CONTENT_COUNT = (SRT_CONTRACT_TARGET.Length - 1)

        If Not FUNC_SYSTEM_BEGIN_TRANSACTION() Then
            STR_FUNC_BATCH_MAIN_ERR_STR = FUNC_SYSTEM_SQLGET_ERR_MESSAGE()
            Return False
        End If

        For i = 1 To (SRT_CONTRACT_TARGET.Length - 1)
            If i Mod 5 = 0 Then Call SUB_PUT_GUIDE(SRT_CONDITIONS.FORM, "継続契約削除中：" & i & "/" & INT_INDEX_MAX)

            If Not FUNC_DELETE_TABLE_MNT_T_CONTRACT(SRT_CONTRACT_TARGET(i).KEY) Then
                STR_FUNC_BATCH_MAIN_ERR_STR = str_SQL_TOOL_LAST_ERR_STRING
                Call FUNC_SYSTEM_ROLLBACK_TRANSACTION()
                Return False
            End If
        Next

        '月次年月更新
        If Not FUNC_UPDATE_MNG_M_MONTH_CODE_YYYYMM(CST_SYSTEM_INDIVIDUAL_SYSTEM_CODE, SRT_CONDITIONS.YYYYMM_B_MONTH) Then
            STR_FUNC_BATCH_MAIN_ERR_STR = str_SQL_TOOL_LAST_ERR_STRING
            Call FUNC_SYSTEM_ROLLBACK_TRANSACTION()
        End If

        If Not FUNC_SYSTEM_COMMIT_TRANSACTION() Then
            STR_FUNC_BATCH_MAIN_ERR_STR = FUNC_SYSTEM_SQLGET_ERR_MESSAGE()
            Return False
        End If

        Return True
    End Function

    Private Function FUNC_GET_SQL(ByRef SRT_CONDITIONS As SRT_BATCH_CONDITIONS) As String
        Dim STR_SQL As System.Text.StringBuilder

        STR_SQL = New System.Text.StringBuilder
        With STR_SQL
            Call .Append("SELECT" & System.Environment.NewLine)
            Call .Append("MAIN.*" & System.Environment.NewLine)
            Call .Append("FROM" & System.Environment.NewLine)
            Call .Append("MNT_T_CONTRACT AS MAIN WITH(NOLOCK)" & System.Environment.NewLine)

            Call .Append("INNER JOIN" & System.Environment.NewLine)
            Call .Append("(" & System.Environment.NewLine)
            Call .Append("SELECT" & System.Environment.NewLine)
            Call .Append("NUMBER_CONTRACT," & System.Environment.NewLine)
            Call .Append("MAX(SERIAL_CONTRACT) AS SERIAL_CONTRACT" & System.Environment.NewLine)
            Call .Append("FROM" & System.Environment.NewLine)
            Call .Append("MNT_T_CONTRACT WITH(NOLOCK)" & System.Environment.NewLine)
            Call .Append("GROUP BY" & System.Environment.NewLine)
            Call .Append("NUMBER_CONTRACT" & System.Environment.NewLine)
            Call .Append(") AS SUB_01" & System.Environment.NewLine)
            Call .Append("ON" & System.Environment.NewLine)
            Call .Append("MAIN.NUMBER_CONTRACT=SUB_01.NUMBER_CONTRACT" & System.Environment.NewLine)
            Call .Append("AND MAIN.SERIAL_CONTRACT=SUB_01.SERIAL_CONTRACT" & System.Environment.NewLine)

            Call .Append("WHERE" & System.Environment.NewLine)
            Call .Append("1 = 1" & System.Environment.NewLine)
            Call .Append("AND FLAG_CONTRACT=" & ENM_SYSTEM_INDIVIDUAL_FLAG_CONTRACT.REGULAR & System.Environment.NewLine) '定期
            Call .Append("AND FLAG_CONTINUE=" & ENM_SYSTEM_INDIVIDUAL_FLAG_CONTINUE.AUTO_CONTINUE & System.Environment.NewLine) '自動継続
            Call .Append("AND MAIN.SERIAL_CONTRACT>" & 1 & System.Environment.NewLine) '連番が2～

            Call .Append("ORDER BY" & Environment.NewLine)
            Call .Append("MAIN.NUMBER_CONTRACT,MAIN.SERIAL_CONTRACT" & System.Environment.NewLine)
        End With

        Return STR_SQL.ToString
    End Function

#Region "内部処理-汎用"
    Private Sub SUB_PUT_GUIDE(ByRef objFORM As Object, ByVal strGUIDE As String)
        Call objFORM.SUB_PUT_PROGRESS_GUIDE(strGUIDE)
    End Sub
#End Region

End Module
