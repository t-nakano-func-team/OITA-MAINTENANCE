Module MOD_PRINT

#Region "帳票用・定数"
    Private Const CST_PRINT_DEFINITION As String = "MNT_P_LIST_INVOICE" '定義体名称
    Private Const CST_PRINT_LIST_NAME As String = "請求書"
    Private Const CST_PRINT_DATA_FILE_EXTENT As String = ".dat"

    Private Const CST_PRINT_RECORD_MAX_COUNT As Integer = 1000 '印刷最大レコード数
#End Region

#Region "帳票用・列挙定数"

#End Region

#Region "帳票用・構造体"
    Public Structure SRT_PTINT_INVOICE_KEY
        Public YEAR_INVOICE As Integer
        Public MONTH_INVOICE As Integer
        Public CODE_OWNER As Integer
        Public NUMBER_LIST_INVOICE As Integer
        Public NUMBER_CONTRACT As Integer
        Public SERIAL_CONTRACT As Integer
        Public SERIAL_INVOICE As Integer
    End Structure

    Public Structure SRT_PRINT_CONDITIONS '印刷条件
        Public PRINT_DATA() As SRT_PTINT_INVOICE_KEY
        Public DATE_INVOICE_FROM As DateTime
        Public DATE_INVOICE_TO As DateTime

        Public FORM As Object
    End Structure

    Public Structure SRT_PRINT_DATA '印刷データ
        Public NUMBER_BREAK As Integer 'ブレイク連番
        Public NUMBER_ROW As Integer '行番号

        Public CODE_POST As String
        Public NAME_ADDRESS_01 As String
        Public NAME_ADDRESS_02 As String
        Public NAME_OWNER As String

        Public NAME_CONTRACT As String
        Public KINGAKU_INVOICE_DETAIL As Long
        Public KINGAKU_INVOICE_VAT As Long
        Public KINGAKU_INVOICE_TOTAL As Long
    End Structure
#End Region

#Region "帳票用・変数"
    Private STR_FILE_NAME_PRINT_DATA As String 'データファイルの名称
    Private STR_PATH_PRINT_DATA As String 'データファイルのパス
    Friend STR_FUNC_PRINT_MAIN_ERR_STR As String '最終エラー文字列
#End Region

    '印刷処理
    Public Function FUNC_PRINT_MAIN(
    ByRef BLN_PUT As Boolean,
    ByRef BLN_CANCEL As Boolean,
    ByRef SRT_CONDITIONS As SRT_PRINT_CONDITIONS,
    ByVal BLN_PREVIEW As Boolean,
    ByVal BLN_PUT_FILE As Boolean
    ) As Boolean
        '初期化
        STR_FUNC_PRINT_MAIN_ERR_STR = ""
        BLN_PUT = False
        BLN_CANCEL = False

        Dim SRT_DATA() As SRT_PRINT_DATA
        ReDim SRT_DATA(0)
        Dim INT_LOOP_INDEX_MAX As Integer
        INT_LOOP_INDEX_MAX = (SRT_CONDITIONS.PRINT_DATA.Length - 1)
        For i = 1 To INT_LOOP_INDEX_MAX
            If i Mod 5 = 0 Then Call SUB_PUT_GUIDE(SRT_CONDITIONS.FORM, "帳票出力データ作成中：" & i & "/" & INT_LOOP_INDEX_MAX)

            With SRT_CONDITIONS.PRINT_DATA(i)
                If .NUMBER_LIST_INVOICE > 0 Then '定期
                    Call SUB_ADD_DATA_REGULAR(i, SRT_DATA, SRT_CONDITIONS.PRINT_DATA(i), SRT_CONDITIONS.DATE_INVOICE_FROM, SRT_CONDITIONS.DATE_INVOICE_TO)
                Else
                    Call SUB_ADD_DATA_SPOT(i, SRT_DATA, SRT_CONDITIONS.PRINT_DATA(i))
                End If
            End With
        Next
        Call SUB_PUT_GUIDE(SRT_CONDITIONS.FORM, "")

        If (SRT_DATA.Length - 1) <= 0 Then
            Return True 'データなし正常終了
        End If

        BLN_PUT = True

        STR_FILE_NAME_PRINT_DATA = CST_PRINT_DEFINITION & CST_PRINT_DATA_FILE_EXTENT
        STR_PATH_PRINT_DATA = srtSYSTEM_TOTAL_CONFIG_SETTINGS.LIST.DIR_DATA & "\" & STR_FILE_NAME_PRINT_DATA

        Dim STW_CSV_WRITER As System.IO.StreamWriter 'ファイル出力用のIOオブジェクト
        Try
            STW_CSV_WRITER = New System.IO.StreamWriter(STR_PATH_PRINT_DATA, False, System.Text.Encoding.Default)   'ファイルライターを開く
        Catch ex As Exception
            STR_FUNC_PRINT_MAIN_ERR_STR = CST_SYSTEM_TOTAL_LIST_ERR_MSG_8001 & Environment.NewLine & STR_PATH_PRINT_DATA
            Return False
        End Try

        Dim STR_ONE_ROW As String
        For i = 1 To (SRT_DATA.Length - 1)
            STR_ONE_ROW = FUNC_GET_ONE_ROW(SRT_CONDITIONS, SRT_DATA(i)) '1行分の情報を作成
            STW_CSV_WRITER.WriteLine(STR_ONE_ROW) 'CSVﾌｧｲﾙ書き込み
        Next

        Call STW_CSV_WRITER.Close() 'ファイルライターを閉じる

        If Not FUNC_COPY_LIST_DEFINITION_BIP(CST_PRINT_DEFINITION, srtSYSTEM_TOTAL_CONFIG_SETTINGS.LIST.DIR_ASSETS_SERVER, srtSYSTEM_TOTAL_CONFIG_SETTINGS.LIST.DIR_ASSETS) Then
            STR_FUNC_PRINT_MAIN_ERR_STR = CST_SYSTEM_TOTAL_LIST_ERR_MSG_8002 & Environment.NewLine & CST_PRINT_DEFINITION
            Return False
        End If

        If BLN_PREVIEW Then
            If Not FUNC_SHOW_PREVIEW_BIP(srtSYSTEM_TOTAL_CONFIG_SETTINGS.LIST.DIR_BIP_EXE, srtSYSTEM_TOTAL_CONFIG_SETTINGS.LIST.DIR_ASSETS, CST_PRINT_DEFINITION, STR_PATH_PRINT_DATA) Then
                STR_FUNC_PRINT_MAIN_ERR_STR = CST_SYSTEM_TOTAL_LIST_ERR_MSG_8004
                Return False
            End If
        Else
            If BLN_PUT_FILE Then
                Dim STR_FILE_PATH As String
                STR_FILE_PATH = ""
                If Not FUNC_SHOW_PUT_FILE_DIALOG(STR_FILE_PATH, CST_PRINT_LIST_NAME) Then
                    BLN_CANCEL = True
                    Return True 'ファイル出力なし正常終了
                End If
                If Not FUNC_PUT_FILE_BIP(srtSYSTEM_TOTAL_CONFIG_SETTINGS.LIST.DIR_BIP_EXE, srtSYSTEM_TOTAL_CONFIG_SETTINGS.LIST.DIR_ASSETS, CST_PRINT_DEFINITION, STR_PATH_PRINT_DATA, STR_FILE_PATH) Then
                    STR_FUNC_PRINT_MAIN_ERR_STR = CST_SYSTEM_TOTAL_LIST_ERR_MSG_8005
                    Return False
                End If
            Else
                If Not FUNC_PUT_LIST_BIP(srtSYSTEM_TOTAL_CONFIG_SETTINGS.LIST.DIR_BIP_EXE, srtSYSTEM_TOTAL_CONFIG_SETTINGS.LIST.DIR_ASSETS, CST_PRINT_DEFINITION, STR_PATH_PRINT_DATA) Then
                    STR_FUNC_PRINT_MAIN_ERR_STR = CST_SYSTEM_TOTAL_LIST_ERR_MSG_8003
                    Return False
                End If
            End If
        End If

        Return True
    End Function

    Private Sub SUB_ADD_DATA_REGULAR(
    ByVal INT_NUMBER_BREAK As Integer,
    ByRef SRT_DATA() As SRT_PRINT_DATA, ByRef SRT_CONDITION_KEY As SRT_PTINT_INVOICE_KEY,
    ByVal DAT_DATE_INVOICE_FROM As DateTime, ByVal DAT_DATE_INVOICE_TO As DateTime
    )

        Dim DAT_DATE_INVOICE_KEY_FROM As DateTime
        DAT_DATE_INVOICE_KEY_FROM = New DateTime(SRT_CONDITION_KEY.YEAR_INVOICE, SRT_CONDITION_KEY.MONTH_INVOICE, 1)
        Dim DAT_DATE_INVOICE_KEY_TO As DateTime
        DAT_DATE_INVOICE_KEY_TO = FUNC_GET_DATE_LASTMONTH(DAT_DATE_INVOICE_KEY_FROM)

        Dim STR_SQL As System.Text.StringBuilder
        STR_SQL = New System.Text.StringBuilder
        With STR_SQL
            Call .Append("SELECT" & Environment.NewLine)
            Call .Append("MAIN.NUMBER_CONTRACT" & "," & Environment.NewLine)
            Call .Append("MAIN.SERIAL_CONTRACT" & "," & Environment.NewLine)
            Call .Append("MAIN.SERIAL_INVOICE" & "" & Environment.NewLine)
            Call .Append("FROM" & Environment.NewLine)
            Call .Append("(" & Environment.NewLine)
            Call .Append("SELECT" & Environment.NewLine)
            Call .Append("*" & Environment.NewLine)
            Call .Append("FROM" & Environment.NewLine)
            Call .Append("MNT_T_INVOICE WITH(NOLOCK)" & Environment.NewLine)
            Call .Append("WHERE" & Environment.NewLine)
            Call .Append("1=1" & Environment.NewLine)
            Call .Append("AND DATE_INVOICE>=" & FUNC_ADD_ENCLOSED_SCOT(DAT_DATE_INVOICE_FROM.ToShortDateString) & Environment.NewLine)
            Call .Append("AND DATE_INVOICE<=" & FUNC_ADD_ENCLOSED_SCOT(DAT_DATE_INVOICE_TO.ToShortDateString) & Environment.NewLine)
            Call .Append("AND DATE_INVOICE>=" & FUNC_ADD_ENCLOSED_SCOT(DAT_DATE_INVOICE_KEY_FROM.ToShortDateString) & Environment.NewLine)
            Call .Append("AND DATE_INVOICE<=" & FUNC_ADD_ENCLOSED_SCOT(DAT_DATE_INVOICE_KEY_TO.ToShortDateString) & Environment.NewLine)
            Call .Append(") AS MAIN" & Environment.NewLine)
            Call .Append("INNER JOIN" & Environment.NewLine)
            Call .Append("(" & Environment.NewLine)
            Call .Append("SELECT" & Environment.NewLine)
            Call .Append("*" & Environment.NewLine)
            Call .Append("FROM" & Environment.NewLine)
            Call .Append("MNT_T_CONTRACT WITH(NOLOCK)" & Environment.NewLine)
            Call .Append("WHERE" & Environment.NewLine)
            Call .Append("1=1" & Environment.NewLine)
            Call .Append("AND CODE_OWNER=" & SRT_CONDITION_KEY.CODE_OWNER & Environment.NewLine)
            Call .Append("AND NUMBER_LIST_INVOICE=" & SRT_CONDITION_KEY.NUMBER_LIST_INVOICE & Environment.NewLine)
            Call .Append(") AS SUB_01" & Environment.NewLine)
            Call .Append("ON" & Environment.NewLine)
            Call .Append("MAIN.NUMBER_CONTRACT=SUB_01.NUMBER_CONTRACT" & Environment.NewLine)
            Call .Append("AND MAIN.SERIAL_CONTRACT=SUB_01.SERIAL_CONTRACT" & Environment.NewLine)
            Call .Append("ORDER BY" & Environment.NewLine)
            Call .Append("NUMBER_CONTRACT,SERIAL_CONTRACT,SERIAL_INVOICE" & Environment.NewLine)
        End With

        Dim SDR_READER As SqlClient.SqlDataReader
        SDR_READER = Nothing
        If Not FUNC_SYSTEM_GET_SQL_DATA_READER(STR_SQL.ToString, SDR_READER) Then
            SDR_READER = Nothing
            Exit Sub
        End If

        If Not SDR_READER.HasRows Then
            Call SDR_READER.Close()
            SDR_READER = Nothing
            Exit Sub
        End If

        Dim INT_INDEX As Integer
        INT_INDEX = 0
        Dim SRT_KEY_INVOICE() As SRT_NUMBER_SERIAL_INVOICE
        ReDim SRT_KEY_INVOICE(0)
        While SDR_READER.Read
            INT_INDEX += 1
            ReDim Preserve SRT_KEY_INVOICE(INT_INDEX)
            With SRT_KEY_INVOICE(INT_INDEX)
                .NUMBER_CONTRACT = CInt(SDR_READER.Item("NUMBER_CONTRACT"))
                .SERIAL_CONTRACT = CInt(SDR_READER.Item("SERIAL_CONTRACT"))
                .SERIAL_INVOICE = CInt(SDR_READER.Item("SERIAL_INVOICE"))
            End With
        End While

        Call SDR_READER.Close()
        SDR_READER = Nothing

        For i = 1 To (SRT_KEY_INVOICE.Length - 1)
            Call SUB_ADD_DATA_REGULAR_ONE(INT_NUMBER_BREAK, i, SRT_DATA, SRT_KEY_INVOICE(i))
        Next
    End Sub

    Private Sub SUB_ADD_DATA_REGULAR_ONE(ByVal INT_NUMBER_BREAK As Integer, ByVal INT_ROW_BREAK As Integer, ByRef SRT_DATA() As SRT_PRINT_DATA, ByRef SRT_INVOICE_KEY As SRT_NUMBER_SERIAL_INVOICE)

        Dim SRT_RECORD_CONTRACT As SRT_TABLE_MNT_T_CONTRACT
        With SRT_RECORD_CONTRACT.KEY
            .NUMBER_CONTRACT = SRT_INVOICE_KEY.NUMBER_CONTRACT
            .SERIAL_CONTRACT = SRT_INVOICE_KEY.SERIAL_CONTRACT
        End With
        SRT_RECORD_CONTRACT.DATA = Nothing
        Call FUNC_SELECT_TABLE_MNT_T_CONTRACT(SRT_RECORD_CONTRACT.KEY, SRT_RECORD_CONTRACT.DATA, True)

        Dim SRT_RECORD_INVOICE As SRT_TABLE_MNT_T_INVOICE
        With SRT_RECORD_INVOICE.KEY
            .NUMBER_CONTRACT = SRT_INVOICE_KEY.NUMBER_CONTRACT
            .SERIAL_CONTRACT = SRT_INVOICE_KEY.SERIAL_CONTRACT
            .SERIAL_INVOICE = SRT_INVOICE_KEY.SERIAL_INVOICE
        End With
        SRT_RECORD_INVOICE.DATA = Nothing
        Call FUNC_SELECT_TABLE_MNT_T_INVOICE(SRT_RECORD_INVOICE.KEY, SRT_RECORD_INVOICE.DATA, True)

        Dim INT_INDEX As Integer
        INT_INDEX = SRT_DATA.Length
        ReDim Preserve SRT_DATA(INT_INDEX)
        With SRT_DATA(INT_INDEX)
            .NUMBER_BREAK = INT_NUMBER_BREAK
            .NUMBER_ROW = INT_ROW_BREAK

            .CODE_POST = ""
            .NAME_ADDRESS_01 = FUNC_GET_MNT_M_OWNER_NAME_ADDRESS_01(SRT_RECORD_CONTRACT.DATA.CODE_OWNER, True)
            .NAME_ADDRESS_02 = FUNC_GET_MNT_M_OWNER_NAME_ADDRESS_02(SRT_RECORD_CONTRACT.DATA.CODE_OWNER, True)
            .NAME_OWNER = FUNC_GET_MNT_M_OWNER_NAME_OWNER(SRT_RECORD_CONTRACT.DATA.CODE_OWNER, True)

            .NAME_CONTRACT = SRT_RECORD_CONTRACT.DATA.NAME_CONTRACT
            .KINGAKU_INVOICE_DETAIL = SRT_RECORD_INVOICE.DATA.KINGAKU_INVOICE_DETAIL
            .KINGAKU_INVOICE_VAT = SRT_RECORD_INVOICE.DATA.KINGAKU_INVOICE_VAT
            .KINGAKU_INVOICE_TOTAL = .KINGAKU_INVOICE_DETAIL + .KINGAKU_INVOICE_VAT
        End With

    End Sub

    Private Sub SUB_ADD_DATA_SPOT(ByVal INT_NUMBER_BREAK As Integer, ByRef SRT_DATA() As SRT_PRINT_DATA, ByRef SRT_CONDITION_KEY As SRT_PTINT_INVOICE_KEY)

        Dim SRT_RECORD_CONTRACT As SRT_TABLE_MNT_T_CONTRACT
        With SRT_RECORD_CONTRACT.KEY
            .NUMBER_CONTRACT = SRT_CONDITION_KEY.NUMBER_CONTRACT
            .SERIAL_CONTRACT = SRT_CONDITION_KEY.SERIAL_CONTRACT
        End With
        SRT_RECORD_CONTRACT.DATA = Nothing
        Call FUNC_SELECT_TABLE_MNT_T_CONTRACT(SRT_RECORD_CONTRACT.KEY, SRT_RECORD_CONTRACT.DATA, True)

        Dim SRT_RECORD_CONTRACT_SPOT As SRT_TABLE_MNT_T_CONTRACT_SPOT
        With SRT_RECORD_CONTRACT_SPOT.KEY
            .NUMBER_CONTRACT = SRT_CONDITION_KEY.NUMBER_CONTRACT
            .SERIAL_CONTRACT = SRT_CONDITION_KEY.SERIAL_CONTRACT
        End With
        SRT_RECORD_CONTRACT_SPOT.DATA = Nothing
        Call FUNC_SELECT_TABLE_MNT_T_CONTRACT_SPOT(SRT_RECORD_CONTRACT_SPOT.KEY, SRT_RECORD_CONTRACT_SPOT.DATA, True)

        Dim SRT_RECORD_INVOICE As SRT_TABLE_MNT_T_INVOICE
        With SRT_RECORD_INVOICE.KEY
            .NUMBER_CONTRACT = SRT_CONDITION_KEY.NUMBER_CONTRACT
            .SERIAL_CONTRACT = SRT_CONDITION_KEY.SERIAL_CONTRACT
            .SERIAL_INVOICE = SRT_CONDITION_KEY.SERIAL_INVOICE
        End With
        SRT_RECORD_INVOICE.DATA = Nothing
        Call FUNC_SELECT_TABLE_MNT_T_INVOICE(SRT_RECORD_INVOICE.KEY, SRT_RECORD_INVOICE.DATA, True)

        Dim INT_INDEX As Integer
        INT_INDEX = SRT_DATA.Length
        ReDim Preserve SRT_DATA(INT_INDEX)
        With SRT_DATA(INT_INDEX)
            .NUMBER_BREAK = INT_NUMBER_BREAK
            .NUMBER_ROW = 1

            .CODE_POST = SRT_RECORD_CONTRACT_SPOT.DATA.CODE_POST
            .NAME_ADDRESS_01 = SRT_RECORD_CONTRACT_SPOT.DATA.NAME_ADDRESS_01
            .NAME_ADDRESS_02 = SRT_RECORD_CONTRACT_SPOT.DATA.NAME_ADDRESS_02
            .NAME_OWNER = SRT_RECORD_CONTRACT_SPOT.DATA.NAME_OWNER

            .NAME_CONTRACT = SRT_RECORD_CONTRACT.DATA.NAME_CONTRACT
            .KINGAKU_INVOICE_DETAIL = SRT_RECORD_INVOICE.DATA.KINGAKU_INVOICE_DETAIL
            .KINGAKU_INVOICE_VAT = SRT_RECORD_INVOICE.DATA.KINGAKU_INVOICE_VAT
            .KINGAKU_INVOICE_TOTAL = .KINGAKU_INVOICE_DETAIL + .KINGAKU_INVOICE_VAT
        End With
    End Sub

    'CSV1行の文字列を取得
    Private Function FUNC_GET_ONE_ROW(
    ByRef SRT_CONDITIONS As SRT_PRINT_CONDITIONS,
    ByRef SRT_DATA As SRT_PRINT_DATA
    ) As String
        Dim STR_RET As String
        Dim STR_ROW() As String

        ReDim STR_ROW(0)
        With SRT_DATA
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.NUMBER_BREAK))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.NUMBER_ROW))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.CODE_POST))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.NAME_ADDRESS_01))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.NAME_ADDRESS_02))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.NAME_OWNER))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.NAME_CONTRACT))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.KINGAKU_INVOICE_DETAIL))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.KINGAKU_INVOICE_VAT))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.KINGAKU_INVOICE_TOTAL))
        End With
        STR_RET = FUNC_GET_ONE_ROW_LIST_CSV(STR_ROW)

        Return STR_RET
    End Function

#Region "内部処理-汎用"
    Private Sub SUB_PUT_GUIDE(ByRef objFORM As Object, ByVal strGUIDE As String)
        Call objFORM.SUB_PUT_PROGRESS_GUIDE(strGUIDE)
    End Sub
#End Region

End Module
