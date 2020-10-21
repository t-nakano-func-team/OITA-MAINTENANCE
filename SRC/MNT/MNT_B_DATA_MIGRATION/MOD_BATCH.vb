Module MOD_BATCH

#Region "バッチ用・定数"
#End Region

#Region "バッチ用列挙定数"
    Private Enum ENM_XLSX_INDEX
        OWNERCD = 1
        GENBACD
        GENBANM
        GENBARYAKU
        SAGYOCD
        KEIYAKUNO
        KEIYAKUEDANO
        KIKAKU
        SAGYONAIYO
        KEIYAKUBI
        SAGYOSTRBI
        SAGYOENDBI
        SEIKYUSTRTUKI
        SEIKYUENDTUKI
        KEIYAKUKIN

        KEIBUSYOCD = 20

        KAIYAKUKBN = 149
        KAIYAKUBI

        INSERTDATE = 216
        INSERTTIME
        UPDATEDATE
        UPDATETIME
    End Enum
#End Region

#Region "バッチ用・構造体"
    Public Structure SRT_BATCH_CONDITIONS 'バッチ条件
        Public FILE_PATH_GET As String
        Public DATE_INVOICE_TO As DateTime
        Public DATE_DEPOSIT_TO As DateTime
        Public DELETE_MAKE As Boolean

        Public DATE_DO_BATCH As DateTime
        Public FORM As Object
    End Structure

    Private Structure SRT_XLSX_INFO 'XLSXファイル構造

        Public OWNERCD As Integer
        Public GENBACD As Integer
        Public GENBANM As String
        Public GENBARYAKU As String
        Public SAGYOCD As Integer
        Public KEIYAKUNO As Integer
        Public KEIYAKUEDANO As Integer
        Public KIKAKU As String
        Public SAGYONAIYO As String
        Public KEIYAKUBI As Integer
        Public SAGYOSTRBI As Integer
        Public SAGYOENDBI As Integer
        Public SEIKYUSTRTUKI As Integer
        Public SEIKYUENDTUKI As Integer
        Public KEIYAKUKIN As Long

        Public KEIBUSYOCD As Integer

        Public KAIYAKUKBN As Integer
        Public KAIYAKUBI As Integer

        Public INSERTDATE As Integer
        Public INSERTTIME As Integer
        Public UPDATEDATE As Integer
        Public UPDATETIME As Integer
    End Structure
#End Region

#Region "バッチ用・変数"
    Friend STR_FUNC_BATCH_MAIN_ERR_STR As String '最終エラー文字列
#End Region

    Friend Function FUNC_BACTH_MAIN(ByRef BLN_PUT As Boolean, ByRef SRT_CONDITIONS As SRT_BATCH_CONDITIONS, ByRef INT_COUNT As Integer) As Boolean
        BLN_PUT = False
        INT_COUNT = 0

        Dim SRT_FILE() As SRT_XLSX_INFO
        ReDim SRT_FILE(0)

        Call SUB_PUT_GUIDE(SRT_CONDITIONS.FORM, "Excelファイル読込中：" & SRT_CONDITIONS.FILE_PATH_GET & "")
        If Not FUNC_GET_FILE_DATA_FROM_XLSX(SRT_CONDITIONS.FILE_PATH_GET, SRT_FILE) Then
            STR_FUNC_BATCH_MAIN_ERR_STR = "ファイルの読取に失敗しました。" & System.Environment.NewLine & SRT_CONDITIONS.FILE_PATH_GET
            Return False
        End If
        Call SUB_PUT_GUIDE(SRT_CONDITIONS.FORM, "")

        Dim SRT_FILE_ENABLED() As SRT_XLSX_INFO
        ReDim SRT_FILE_ENABLED(0)
        Dim INT_LOOP_INDEX_MAX As Integer
        INT_LOOP_INDEX_MAX = (SRT_FILE.Length - 1)
        For i = 1 To INT_LOOP_INDEX_MAX
            If i Mod 5 = 0 Then Call SUB_PUT_GUIDE(SRT_CONDITIONS.FORM, "解約チェック中：" & i & "/" & INT_LOOP_INDEX_MAX)
            If Not FUNC_CHECK_KAIYAKU(SRT_FILE(i)) Then
                Dim INT_INDEX As Integer
                INT_INDEX = SRT_FILE_ENABLED.Length
                ReDim Preserve SRT_FILE_ENABLED(INT_INDEX)
                SRT_FILE_ENABLED(INT_INDEX) = SRT_FILE(i)
            End If
        Next
        Call SUB_PUT_GUIDE(SRT_CONDITIONS.FORM, "")

        INT_COUNT = (SRT_FILE_ENABLED.Length - 1)
        If INT_COUNT <= 0 Then
            Return True 'データなし正常終了
        End If

        BLN_PUT = True

        Dim SRT_TABLE() As SRT_TABLE_MNT_T_CONTRACT
        ReDim SRT_TABLE(0)
        INT_LOOP_INDEX_MAX = (SRT_FILE_ENABLED.Length - 1)
        For i = 1 To INT_LOOP_INDEX_MAX
            If i Mod 5 = 0 Then Call SUB_PUT_GUIDE(SRT_CONDITIONS.FORM, "テーブル情報作成中：" & i & "/" & INT_LOOP_INDEX_MAX)
            Dim INT_INDEX As Integer
            INT_INDEX = SRT_TABLE.Length
            ReDim Preserve SRT_TABLE(INT_INDEX)
            SRT_TABLE(INT_INDEX) = FUNC_GET_TABLE_DATA(SRT_FILE_ENABLED(i))
        Next
        Call SUB_PUT_GUIDE(SRT_CONDITIONS.FORM, "")

        If Not FUNC_SYSTEM_BEGIN_TRANSACTION() Then
            STR_FUNC_BATCH_MAIN_ERR_STR = FUNC_SYSTEM_SQLGET_ERR_MESSAGE()
            Return False
        End If

        If SRT_CONDITIONS.DELETE_MAKE Then
            Call SUB_PUT_GUIDE(SRT_CONDITIONS.FORM, "削除中")
            If Not FUNC_DETELE_MAKE(9999999) Then
                STR_FUNC_BATCH_MAIN_ERR_STR = FUNC_SYSTEM_SQLGET_ERR_MESSAGE()
                Call FUNC_SYSTEM_ROLLBACK_TRANSACTION()
                Return False
            End If
        End If

        INT_LOOP_INDEX_MAX = (SRT_TABLE.Length - 1)
        For i = 1 To INT_LOOP_INDEX_MAX
            If i Mod 5 = 0 Then Call SUB_PUT_GUIDE(SRT_CONDITIONS.FORM, "テーブル挿入中：" & i & "/" & INT_LOOP_INDEX_MAX)
            Dim INT_NUMBER_CONTRACT As Integer
            INT_NUMBER_CONTRACT = FUNC_GET_NUMBER_CONTRACT_NEW(True)
            With SRT_TABLE(i).KEY
                .NUMBER_CONTRACT = INT_NUMBER_CONTRACT
            End With

            If Not FUNC_INSERT_TABLE_MNT_T_CONTRACT(SRT_TABLE(i)) Then
                STR_FUNC_BATCH_MAIN_ERR_STR = FUNC_SYSTEM_SQLGET_ERR_MESSAGE()
                Call FUNC_SYSTEM_ROLLBACK_TRANSACTION()
                Return False
            End If

            If Not FUNC_MAKE_INVOICE(SRT_TABLE(i), SRT_CONDITIONS.DATE_INVOICE_TO, SRT_CONDITIONS.DATE_DEPOSIT_TO) Then
                STR_FUNC_BATCH_MAIN_ERR_STR = FUNC_SYSTEM_SQLGET_ERR_MESSAGE()
                Call FUNC_SYSTEM_ROLLBACK_TRANSACTION()
                Return False
            End If
        Next

        If Not FUNC_SYSTEM_COMMIT_TRANSACTION() Then
            STR_FUNC_BATCH_MAIN_ERR_STR = FUNC_SYSTEM_SQLGET_ERR_MESSAGE()
            Return False
        End If


        Return True
    End Function

#Region "内部処理"
    Private Function FUNC_GET_FILE_DATA_FROM_XLSX(ByVal STR_FILE_PATH As String, ByRef SRT_FILE() As SRT_XLSX_INFO) As Boolean
        ReDim SRT_FILE(0)

        If Not FUNC_INIT_XLS(STR_FILE_PATH, 2) Then
            Return False
        End If

        Dim INT_ROW As Integer

        INT_ROW = 0
        Do
            INT_ROW += 1
            If INT_ROW <= 1 Then 'ヘッダ読飛
                Continue Do
            End If

            Dim STR_TEMP As String
            STR_TEMP = FUNC_GET_VALUE_XLSX(INT_ROW, ENM_XLSX_INDEX.OWNERCD)
            If Not IsNumeric(STR_TEMP) Then
                Exit Do
            End If

            Dim INT_INDEX As Integer
            INT_INDEX = SRT_FILE.Length
            ReDim Preserve SRT_FILE(INT_INDEX)
            With SRT_FILE(INT_INDEX)
                .OWNERCD = CInt(STR_TEMP)
                Try
                    STR_TEMP = FUNC_GET_VALUE_XLSX(INT_ROW, ENM_XLSX_INDEX.GENBACD)
                    .GENBACD = CInt(STR_TEMP)
                    STR_TEMP = FUNC_GET_VALUE_XLSX(INT_ROW, ENM_XLSX_INDEX.GENBANM)
                    .GENBANM = CStr(STR_TEMP)
                    STR_TEMP = FUNC_GET_VALUE_XLSX(INT_ROW, ENM_XLSX_INDEX.GENBARYAKU)
                    .GENBARYAKU = CStr(STR_TEMP)
                    STR_TEMP = FUNC_GET_VALUE_XLSX(INT_ROW, ENM_XLSX_INDEX.SAGYOCD)
                    .SAGYOCD = CInt(STR_TEMP)
                    STR_TEMP = FUNC_GET_VALUE_XLSX(INT_ROW, ENM_XLSX_INDEX.KEIYAKUNO)
                    .KEIYAKUNO = CInt(STR_TEMP)
                    STR_TEMP = FUNC_GET_VALUE_XLSX(INT_ROW, ENM_XLSX_INDEX.KEIYAKUEDANO)
                    .KEIYAKUEDANO = CInt(STR_TEMP)
                    STR_TEMP = FUNC_GET_VALUE_XLSX(INT_ROW, ENM_XLSX_INDEX.KIKAKU)
                    .KIKAKU = CStr(STR_TEMP)
                    STR_TEMP = FUNC_GET_VALUE_XLSX(INT_ROW, ENM_XLSX_INDEX.SAGYONAIYO)
                    .SAGYONAIYO = CStr(STR_TEMP)
                    STR_TEMP = FUNC_GET_VALUE_XLSX(INT_ROW, ENM_XLSX_INDEX.KEIYAKUBI)
                    .KEIYAKUBI = CInt(STR_TEMP)
                    STR_TEMP = FUNC_GET_VALUE_XLSX(INT_ROW, ENM_XLSX_INDEX.SAGYOSTRBI)
                    .SAGYOSTRBI = CInt(STR_TEMP)
                    STR_TEMP = FUNC_GET_VALUE_XLSX(INT_ROW, ENM_XLSX_INDEX.SAGYOENDBI)
                    .SAGYOENDBI = CInt(STR_TEMP)
                    STR_TEMP = FUNC_GET_VALUE_XLSX(INT_ROW, ENM_XLSX_INDEX.SEIKYUSTRTUKI)
                    .SEIKYUSTRTUKI = CInt(STR_TEMP)
                    STR_TEMP = FUNC_GET_VALUE_XLSX(INT_ROW, ENM_XLSX_INDEX.SEIKYUENDTUKI)
                    .SEIKYUENDTUKI = CInt(STR_TEMP)
                    STR_TEMP = FUNC_GET_VALUE_XLSX(INT_ROW, ENM_XLSX_INDEX.SEIKYUENDTUKI)
                    .SEIKYUENDTUKI = CInt(STR_TEMP)
                    STR_TEMP = FUNC_GET_VALUE_XLSX(INT_ROW, ENM_XLSX_INDEX.KEIYAKUKIN)
                    .KEIYAKUKIN = CLng(STR_TEMP)

                    STR_TEMP = FUNC_GET_VALUE_XLSX(INT_ROW, ENM_XLSX_INDEX.KEIBUSYOCD)
                    .KEIBUSYOCD = CLng(STR_TEMP)

                    STR_TEMP = FUNC_GET_VALUE_XLSX(INT_ROW, ENM_XLSX_INDEX.KAIYAKUKBN)
                    .KAIYAKUKBN = CInt(STR_TEMP)
                    STR_TEMP = FUNC_GET_VALUE_XLSX(INT_ROW, ENM_XLSX_INDEX.KAIYAKUBI)
                    .KAIYAKUBI = CInt(STR_TEMP)

                    STR_TEMP = FUNC_GET_VALUE_XLSX(INT_ROW, ENM_XLSX_INDEX.INSERTDATE)
                    .INSERTDATE = FUNC_VALUE_CONVERT_NUMERIC_INT(STR_TEMP, 99981231)
                    STR_TEMP = FUNC_GET_VALUE_XLSX(INT_ROW, ENM_XLSX_INDEX.INSERTTIME)
                    .INSERTTIME = FUNC_VALUE_CONVERT_NUMERIC_INT(STR_TEMP, 1159)
                    STR_TEMP = FUNC_GET_VALUE_XLSX(INT_ROW, ENM_XLSX_INDEX.UPDATEDATE)
                    .UPDATEDATE = FUNC_VALUE_CONVERT_NUMERIC_INT(STR_TEMP, 99981231)
                    If .UPDATEDATE = 0 Then
                        .UPDATEDATE = 99981231
                    End If
                    STR_TEMP = FUNC_GET_VALUE_XLSX(INT_ROW, ENM_XLSX_INDEX.UPDATETIME)
                    .UPDATETIME = FUNC_VALUE_CONVERT_NUMERIC_INT(STR_TEMP, 1159)
                Catch ex As Exception
                    Call FUNC_END_XLS()
                    Return False
                End Try
            End With
        Loop

        Call FUNC_END_XLS()

        Return True
    End Function

    Private Function FUNC_CHECK_KAIYAKU(ByRef SRT_DATA As SRT_XLSX_INFO) As Boolean
        With SRT_DATA

            If .KAIYAKUKBN <> 0 Then
                Return True
            End If

            'If .KAIYAKUBI <> 0 Then
            '    Return True
            'End If

        End With

        Return False
    End Function

    Private Function FUNC_GET_TABLE_DATA(ByRef SRT_DATA As SRT_XLSX_INFO) As SRT_TABLE_MNT_T_CONTRACT
        Dim SRT_RET As SRT_TABLE_MNT_T_CONTRACT
        With SRT_RET.KEY
            .NUMBER_CONTRACT = 0
            .SERIAL_CONTRACT = 1
        End With

        With SRT_RET.DATA
            .FLAG_CONTRACT = ENM_SYSTEM_INDIVIDUAL_FLAG_CONTRACT.REGULAR
            .DATE_CONTRACT = FUNC_CONVERT_NUMERIC_DATE_TO_DATETIME(SRT_DATA.KEIYAKUBI)
            .CODE_OWNER = SRT_DATA.OWNERCD
            .CODE_SECTION = SRT_DATA.KEIBUSYOCD
            .CODE_MAINTENANCE = SRT_DATA.SAGYOCD
            .NAME_CONTRACT = FUNC_GET_NAME_CONTRACT(SRT_DATA)
            If .NAME_CONTRACT.Length > 40 Then
                .NAME_CONTRACT = .NAME_CONTRACT.Substring(0, 40)
            End If
            .DATE_MAINTENANCE_START = FUNC_CONVERT_NUMERIC_DATE_TO_DATETIME(SRT_DATA.SAGYOSTRBI)
            .DATE_MAINTENANCE_END = FUNC_CONVERT_NUMERIC_DATE_TO_DATETIME(SRT_DATA.SAGYOENDBI)

            Dim INT_SEIKYU_FROM As Integer
            INT_SEIKYU_FROM = FUNC_GET_SEIKYU_FROM(SRT_DATA)
            Dim ENM_KIND_FIX_DATE As ENM_SYSTEM_INDIVIDUAL_FLAG_INVOICE_FIXDAY
            ENM_KIND_FIX_DATE = FUNC_GET_MNT_M_OWNER_FLAG_INVOICE_FIXDAY(.CODE_OWNER, True)
            If ENM_KIND_FIX_DATE <= 0 Then
                ENM_KIND_FIX_DATE = ENM_SYSTEM_INDIVIDUAL_FLAG_INVOICE_FIXDAY.FIX_LAST
            End If
            Dim DAT_SEIKYU_BASE As DateTime
            Dim INT_SEIKYU_FROM_YEAR As Integer
            INT_SEIKYU_FROM_YEAR = FUNC_GET_YYYY_FROM_YYYYMM(INT_SEIKYU_FROM)
            Dim INT_SEIKYU_FROM_MONTH As Integer
            INT_SEIKYU_FROM_MONTH = FUNC_GET_MM_FROM_YYYYMM(INT_SEIKYU_FROM)
            Select Case ENM_KIND_FIX_DATE
                Case ENM_SYSTEM_INDIVIDUAL_FLAG_INVOICE_FIXDAY.FIX_10, ENM_SYSTEM_INDIVIDUAL_FLAG_INVOICE_FIXDAY.FIX_20, ENM_SYSTEM_INDIVIDUAL_FLAG_INVOICE_FIXDAY.FIX_25
                    DAT_SEIKYU_BASE = New Date(INT_SEIKYU_FROM_YEAR, INT_SEIKYU_FROM_MONTH, CInt(ENM_KIND_FIX_DATE))
                Case ENM_SYSTEM_INDIVIDUAL_FLAG_INVOICE_FIXDAY.FIX_LAST
                    DAT_SEIKYU_BASE = New Date(INT_SEIKYU_FROM_YEAR, INT_SEIKYU_FROM_MONTH, 1)
                    DAT_SEIKYU_BASE = FUNC_GET_DATE_LASTMONTH(DAT_SEIKYU_BASE)
                Case Else
                    DAT_SEIKYU_BASE = New Date(INT_SEIKYU_FROM_YEAR, INT_SEIKYU_FROM_MONTH, 1)
                    DAT_SEIKYU_BASE = FUNC_GET_DATE_LASTMONTH(DAT_SEIKYU_BASE)
            End Select
            .DATE_INVOICE_BASE = DAT_SEIKYU_BASE
            .SPAN_INVOICE = 1
            .COUNT_INVOICE = FUNC_GET_MONTH_FROM_TO(INT_SEIKYU_FROM, SRT_DATA.SEIKYUENDTUKI) + 1
            Select Case .SPAN_INVOICE
                Case 1
                    .FLAG_INVOICE_METHOD = 1
                Case 2
                    Dim INT_MONTH As Integer
                    INT_MONTH = .DATE_INVOICE_BASE.Month
                    If (INT_MONTH Mod 2) = 0 Then
                        .FLAG_INVOICE_METHOD = 3
                    Else
                        .FLAG_INVOICE_METHOD = 2
                    End If
                Case 3
                    Dim INT_MONTH As Integer
                    INT_MONTH = .DATE_INVOICE_BASE.Month
                    Select Case INT_MONTH
                        Case 6, 9, 12, 3
                            .FLAG_INVOICE_METHOD = 5
                        Case Else
                            .FLAG_INVOICE_METHOD = 4
                    End Select
                Case 6
                    .FLAG_INVOICE_METHOD = 6
                Case Else
                    .FLAG_INVOICE_METHOD = 0
            End Select
            .NUMBER_LIST_INVOICE = 1

            .KINGAKU_CONTRACT = SRT_DATA.KEIYAKUKIN
            .NAME_MEMO = CStr(SRT_DATA.KEIYAKUNO)
            .FLAG_CONTINUE = ENM_SYSTEM_INDIVIDUAL_FLAG_CONTINUE.AUTO_CONTINUE
            .DATE_ACTIVE = datSYSTEM_TOTAL_DATE_ACTIVE
            .CODE_EDIT_STAFF = srtSYSTEM_TOTAL_COMMANDLINE.CODE_STAFF
            .DATE_EDIT = FUNC_CONVERT_NUMERIC_DATE_TO_DATETIME(SRT_DATA.UPDATEDATE)
        End With

        Return SRT_RET
    End Function

    Private Function FUNC_GET_NAME_CONTRACT(ByRef SRT_DATA As SRT_XLSX_INFO) As String
        Dim STR_RET As String
        STR_RET = ""

        With SRT_DATA
            If .GENBANM = "" Then
                STR_RET = .SAGYONAIYO
            Else
                STR_RET = .GENBANM & "-" & .SAGYONAIYO
            End If
        End With

        Return STR_RET
    End Function

    Private Function FUNC_GET_SEIKYU_FROM(ByRef SRT_DATA As SRT_XLSX_INFO) As Integer

        Dim INT_TUKI As Integer
        INT_TUKI = FUNC_GET_MONTH_FROM_TO(SRT_DATA.SEIKYUSTRTUKI, SRT_DATA.SEIKYUENDTUKI)
        INT_TUKI += 1

        If (INT_TUKI Mod 12) = 0 Then
            Return SRT_DATA.SEIKYUSTRTUKI
        End If

        Dim DAT_SAGYO_FROM As DateTime
        DAT_SAGYO_FROM = FUNC_CONVERT_NUMERIC_DATE_TO_DATETIME(SRT_DATA.SAGYOSTRBI)
        Dim INT_SAGYO_FROM As Integer
        INT_SAGYO_FROM = FUNC_GET_YYYYMM_FROM_DATE(DAT_SAGYO_FROM)
        'If INT_SAGYO_FROM > SRT_DATA.SEIKYUSTRTUKI Then
        '    Return INT_SAGYO_FROM
        'End If

        Return SRT_DATA.SEIKYUSTRTUKI
    End Function

    Private Function FUNC_MAKE_INVOICE(ByRef SRT_DATA As SRT_TABLE_MNT_T_CONTRACT, ByVal DAT_DATE_INVOICE_TO As DateTime, ByVal DAT_DATE_DEPOSIT_TO As DateTime) As Boolean

        For i = 1 To SRT_DATA.DATA.COUNT_INVOICE
            Dim DAT_DATE_INVOICE As DateTime
            DAT_DATE_INVOICE = FUNC_GET_DATE_INVOICE_PLAN(SRT_DATA.KEY.NUMBER_CONTRACT, SRT_DATA.KEY.SERIAL_CONTRACT)

            Dim SRT_EDIT As SRT_EDIT_INVOICE
            With SRT_EDIT
                .CEHCK_EDIT = False
                .CODE_SECTION = 0
                .KINGAKU_INVOICE_DETAIL = 0
                .KINGAKU_INVOICE_VAT = 0
            End With

            If DAT_DATE_INVOICE_TO <= DAT_DATE_INVOICE_TO Then
                If Not FUNC_MAKE_NEW_INVOICE(SRT_DATA.KEY.NUMBER_CONTRACT, SRT_DATA.KEY.SERIAL_CONTRACT, DAT_DATE_INVOICE, SRT_EDIT) Then
                    Return False
                End If
            Else
                Continue For
            End If

            Dim INT_SERIAL_INVOICE As Integer
            INT_SERIAL_INVOICE = FUNC_GET_MNT_T_INVOICE_MAX_SERIAL_INVOICE(SRT_DATA.KEY.NUMBER_CONTRACT, SRT_DATA.KEY.SERIAL_CONTRACT)

            Dim DAT_DATE_DEPOSIT As DateTime
            DAT_DATE_DEPOSIT = FUNC_GET_DATE_NEXT_MONTH_FIRST(DAT_DATE_INVOICE)
            If DAT_DATE_DEPOSIT <= DAT_DATE_DEPOSIT_TO Then
                If Not FUNC_MAKE_NEW_DEPOSIT(SRT_DATA.KEY.NUMBER_CONTRACT, SRT_DATA.KEY.SERIAL_CONTRACT, INT_SERIAL_INVOICE, DAT_DATE_DEPOSIT) Then
                    Return False
                End If
            End If

        Next

        Return True
    End Function

    Private Function FUNC_GET_DATE_NEXT_MONTH_FIRST(ByVal DAT_DATE_BASE As DateTime) As DateTime

        Dim INT_YYYYMM As Integer
        INT_YYYYMM = FUNC_GET_YYYYMM_FROM_DATE(DAT_DATE_BASE)

        Dim INT_YYYYMM_NEXT As Integer
        INT_YYYYMM_NEXT = FUNC_ADD_MONTH_YYYYMM(INT_YYYYMM, 1) '翌月

        Dim INT_YEAR As Integer
        INT_YEAR = FUNC_GET_YYYY_FROM_YYYYMM(INT_YYYYMM_NEXT)

        Dim INT_MONTH As Integer
        INT_MONTH = FUNC_GET_MM_FROM_YYYYMM(INT_YYYYMM_NEXT)

        Dim DAT_RET As DateTime
        DAT_RET = New DateTime(INT_YEAR, INT_MONTH, 1) '翌月月初

        Return DAT_RET
    End Function

    Private Function FUNC_DETELE_MAKE(ByVal INT_CODE_STAFF As Integer) As Boolean
        Dim STR_SQL As System.Text.StringBuilder

        STR_SQL = New System.Text.StringBuilder
        With STR_SQL
            .Append("DELETE" & System.Environment.NewLine)
            .Append("FROM" & System.Environment.NewLine)
            .Append("MNT_T_CONTRACT WITH(ROWLOCK)" & System.Environment.NewLine)
            .Append("WHERE" & System.Environment.NewLine)
            .Append("1=1" & System.Environment.NewLine)
            .Append("AND " & System.Environment.NewLine)
        End With

        Return True
    End Function
#End Region

#Region "内部処理（汎用）"
    Private Sub SUB_PUT_GUIDE(ByRef OBJ_FORM As Object, ByVal STR_GUIDE As String)
        Call OBJ_FORM.SUB_PUT_PROGRESS_GUIDE(STR_GUIDE)
    End Sub
#End Region

End Module
