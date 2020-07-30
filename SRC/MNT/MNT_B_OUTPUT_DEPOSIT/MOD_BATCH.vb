Module MOD_BATCH

#Region "バッチ用・変数"
    Friend STR_FUNC_BATCH_MAIN_ERR_STR As String '最終エラー文字列
#End Region

#Region "バッチ用・構造体"

    Public Structure SRT_BATCH_CONDITIONS 'バッチ条件
        Public DATE_DEPOSIT_TO As DateTime
        Public PATH_FILE As String

        Public DATE_DO_BATCH As DateTime
        Public FORM As Object

        Public RET_OUTPUT_COUNT As Integer
    End Structure
#End Region

    Friend Function FUNC_BACTH_MAIN(ByRef BLN_PUT As Boolean, ByRef SRT_CONDITIONS As SRT_BATCH_CONDITIONS) As Boolean

        SRT_CONDITIONS.RET_OUTPUT_COUNT = 0

        Dim STR_SQL As String
        STR_SQL = FUNC_GET_SQL(SRT_CONDITIONS)

        Dim SDR_READER As SqlClient.SqlDataReader
        SDR_READER = Nothing
        If Not FUNC_SYSTEM_GET_SQL_DATA_READER(STR_SQL.ToString, SDR_READER) Then
            STR_FUNC_BATCH_MAIN_ERR_STR = str_SQL_TOOL_LAST_ERR_STRING
            Return False
        End If

        If Not SDR_READER.HasRows Then
            Call SDR_READER.Close()
            SDR_READER = Nothing
            Return True 'データなし正常終了
        End If

        Dim SRT_DEPOSIT() As SRT_TABLE_MNT_T_DEPOSIT '対象の契約すべて（定期かつ自動更新かつ契約連番が最大）
        ReDim SRT_DEPOSIT(0)
        While SDR_READER.Read
            Dim INT_INDEX As Integer
            INT_INDEX = (SRT_DEPOSIT.Length)
            ReDim Preserve SRT_DEPOSIT(INT_INDEX)
            If INT_INDEX Mod 5 = 0 Then Call SUB_PUT_GUIDE(SRT_CONDITIONS.FORM, "入金取得中：" & INT_INDEX)

            With SRT_DEPOSIT(INT_INDEX).KEY
                .NUMBER_CONTRACT = CInt(SDR_READER.Item("NUMBER_CONTRACT"))
                .SERIAL_CONTRACT = CInt(SDR_READER.Item("SERIAL_CONTRACT"))
                .SERIAL_INVOICE = CInt(SDR_READER.Item("SERIAL_INVOICE"))
            End With
            With SRT_DEPOSIT(INT_INDEX).DATA

                .DATE_ACTIVE = CDate(SDR_READER.Item("DATE_ACTIVE"))
                .CODE_EDIT_STAFF = CInt(SDR_READER.Item("CODE_EDIT_STAFF"))
                .DATE_EDIT = CDate(SDR_READER.Item("DATE_EDIT"))
            End With
        End While

        Call SDR_READER.Close()
        SDR_READER = Nothing

        'ファイル出力

        SRT_CONDITIONS.RET_OUTPUT_COUNT = (SRT_DEPOSIT.Length - 1)
        If Not FUNC_SYSTEM_BEGIN_TRANSACTION() Then
            STR_FUNC_BATCH_MAIN_ERR_STR = FUNC_SYSTEM_SQLGET_ERR_MESSAGE()
            Return False
        End If

        Dim INT_INDEX_MAX As Integer
        INT_INDEX_MAX = (SRT_DEPOSIT.Length - 1)

        If Not FUNC_SYSTEM_BEGIN_TRANSACTION() Then
            STR_FUNC_BATCH_MAIN_ERR_STR = FUNC_SYSTEM_SQLGET_ERR_MESSAGE()
            Return False
        End If

        For i = 1 To (SRT_DEPOSIT.Length - 1)
            If i Mod 5 = 0 Then Call SUB_PUT_GUIDE(SRT_CONDITIONS.FORM, "入金更新中：" & i & "/" & INT_INDEX_MAX)
            With SRT_DEPOSIT(i).KEY
                If Not FUNC_UPDATE_DEPOSIT_FLAG_OUTPUT(.NUMBER_CONTRACT, .SERIAL_CONTRACT, .SERIAL_INVOICE, ENM_SYSTEM_INDIVIDUAL_FLAG_OUTPUT.DONE) Then
                    STR_FUNC_BATCH_MAIN_ERR_STR = FUNC_SYSTEM_SQLGET_ERR_MESSAGE()
                    Return False
                End If
            End With
        Next

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
            Call .Append("MNT_T_DEPOSIT AS MAIN WITH(NOLOCK)" & System.Environment.NewLine)

            Call .Append("WHERE" & System.Environment.NewLine)
            Call .Append("1 = 1" & System.Environment.NewLine)
            Call .Append("AND FLAG_OUTPUT=" & ENM_SYSTEM_INDIVIDUAL_FLAG_OUTPUT.NOT_DONE & System.Environment.NewLine) '定期
            Call .Append("AND DATE_DEPOSIT<=" & FUNC_ADD_ENCLOSED_SCOT(SRT_CONDITIONS.DATE_DEPOSIT_TO.ToShortDateString) & System.Environment.NewLine) '自動継続

            Call .Append("ORDER BY" & Environment.NewLine)
            Call .Append("NUMBER_CONTRACT,SERIAL_CONTRACT,SERIAL_INVOICE" & System.Environment.NewLine)
        End With

        Return STR_SQL.ToString
    End Function

#Region "内部処理-汎用"
    Private Sub SUB_PUT_GUIDE(ByRef objFORM As Object, ByVal strGUIDE As String)
        Call objFORM.SUB_PUT_PROGRESS_GUIDE(strGUIDE)
    End Sub

#End Region

End Module
