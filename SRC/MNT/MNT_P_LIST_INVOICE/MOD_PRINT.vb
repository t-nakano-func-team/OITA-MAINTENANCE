﻿Module MOD_PRINT

#Region "帳票用・定数"
    Private Const CST_PRINT_DEFINITION As String = "MNT_P_LIST_INVOICE" '定義体名称
    Private Const CST_PRINT_LIST_NAME As String = "請求書"
    Private Const CST_PRINT_DATA_FILE_EXTENT As String = ".dat"

    Private Const CST_PRINT_RECORD_MAX_COUNT As Integer = 1000 '印刷最大レコード数

    Private Const CST_PRINT_INVOICE_DETAIL_ROW As Integer = 5
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
        Public ENABLED_DATE_PRINT As Boolean
        Public DATE_PRINT As DateTime

        Public FORM As Object
    End Structure

    Public Structure SRT_DETAIL_INVOICE
        Public CODE_SECTION As Integer
        Public CODE_MAINTENANCE As Integer
        Public NAME_CONTRACT As String
        Public KINGAKU_INVOICE_DETAIL As Long
        Public KINGAKU_INVOICE_VAT As Long

        Public KINGAKU_INVOICE_DETAIL_BEFORE As Long
        Public KINGAKU_INVOICE_VAT_BEFORE As Long
        Public FLAG_DEPOSIT_DONE_BEFORE As Boolean
        Public Function KINGAKU_INVOICE_TOTAL_BEFORE()
            Dim LNG_RET As Long
            LNG_RET = Me.KINGAKU_INVOICE_DETAIL_BEFORE + Me.KINGAKU_INVOICE_VAT_BEFORE
            Return LNG_RET
        End Function

        Public Function KINGAKU_DEPOSIT_BEFORE() As Long
            Dim LNG_RET As Long
            If Me.FLAG_DEPOSIT_DONE_BEFORE Then
                LNG_RET = Me.KINGAKU_INVOICE_TOTAL_BEFORE
            Else
                LNG_RET = 0
            End If

            Return LNG_RET
        End Function

    End Structure

    Public Structure SRT_PRINT_DATA '印刷データ
        Public NUMBER_BREAK As Integer 'ブレイク連番

        Public DATE_PRINT As DateTime

        Public CODE_POST As Integer
        Public NAME_ADDRESS_01 As String
        Public NAME_ADDRESS_02 As String
        Public NAME_OWNER As String

        Public KEY As SRT_PTINT_INVOICE_KEY
        Public KINGAKU_TOTAL_INVOICE_BEFORE As Long
        Public KINGAKU_TOTAL_DEPOSIT As Long

        Public DETAIL() As SRT_DETAIL_INVOICE

        Public DATE_PRINT_YEAR As Integer
        Public DATE_PRINT_MONTH As Integer
        Public DATE_PRINT_DAY As Integer

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

            Dim INT_INDEX As Integer
            INT_INDEX = SRT_DATA.Length
            ReDim Preserve SRT_DATA(INT_INDEX)
            SRT_DATA(INT_INDEX).KEY = SRT_CONDITIONS.PRINT_DATA(i)
        Next
        Call SUB_PUT_GUIDE(SRT_CONDITIONS.FORM, "")

        If (SRT_DATA.Length - 1) <= 0 Then
            Return True 'データなし正常終了
        End If

        BLN_PUT = True

        Dim INT_NUMBER_BREAK As Integer
        INT_NUMBER_BREAK = 0

        INT_LOOP_INDEX_MAX = (SRT_DATA.Length - 1)
        For i = 1 To INT_LOOP_INDEX_MAX
            If i Mod 5 = 0 Then Call SUB_PUT_GUIDE(SRT_CONDITIONS.FORM, "情報取得中：" & i & "/" & INT_LOOP_INDEX_MAX)
            If True Then
                INT_NUMBER_BREAK += 1
            End If
            Call SUB_REPLACE_DATA(SRT_CONDITIONS, SRT_DATA(i), INT_NUMBER_BREAK)
        Next

        Call SUB_PUT_GUIDE(SRT_CONDITIONS.FORM, "")

        STR_FILE_NAME_PRINT_DATA = CST_PRINT_DEFINITION & CST_PRINT_DATA_FILE_EXTENT
        If Not FUNC_DIR_MAKE(srtSYSTEM_TOTAL_CONFIG_SETTINGS.LIST.DIR_DATA) Then
            STR_FUNC_PRINT_MAIN_ERR_STR = str_FILE_TOOL_LAST_ERR_STRING
            Return False
        End If
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

        If Not FUNC_DIR_MAKE(srtSYSTEM_TOTAL_CONFIG_SETTINGS.LIST.DIR_ASSETS) Then
            STR_FUNC_PRINT_MAIN_ERR_STR = str_FILE_TOOL_LAST_ERR_STRING
            Return False
        End If
        If Not FUNC_COPY_LIST_DEFINITION_BIP(CST_PRINT_DEFINITION, srtSYSTEM_TOTAL_CONFIG_SETTINGS.LIST.DIR_ASSETS_SERVER, srtSYSTEM_TOTAL_CONFIG_SETTINGS.LIST.DIR_ASSETS) Then
            STR_FUNC_PRINT_MAIN_ERR_STR = CST_SYSTEM_TOTAL_LIST_ERR_MSG_8002 & Environment.NewLine & CST_PRINT_DEFINITION
            Return False
        End If

        If BLN_PREVIEW Then
            If Not FUNC_SHOW_PREVIEW_BIP(srtSYSTEM_TOTAL_CONFIG_SETTINGS.LIST.DIR_BIP_EXE, srtSYSTEM_TOTAL_CONFIG_SETTINGS.LIST.DIR_ASSETS, CST_PRINT_DEFINITION, STR_PATH_PRINT_DATA) Then
                STR_FUNC_PRINT_MAIN_ERR_STR = CST_SYSTEM_TOTAL_LIST_ERR_MSG_8004 & System.Environment.NewLine & str_FILE_TOOL_LAST_ERR_STRING
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
                    STR_FUNC_PRINT_MAIN_ERR_STR = CST_SYSTEM_TOTAL_LIST_ERR_MSG_8003 & System.Environment.NewLine & str_FILE_TOOL_LAST_ERR_STRING
                    Return False
                End If
            End If
        End If

        Return True
    End Function

    Private Sub SUB_REPLACE_DATA(ByRef SRT_CONDITIONS As SRT_PRINT_CONDITIONS, ByRef SRT_DATA As SRT_PRINT_DATA, ByVal INT_NUMBER_BREAK As Integer)
        With SRT_DATA

            ReDim .DETAIL(CST_PRINT_INVOICE_DETAIL_ROW)
            For i = 1 To (.DETAIL.Length - 1)
                With SRT_DATA.DETAIL(i)
                    .NAME_CONTRACT = ""
                    .KINGAKU_INVOICE_DETAIL = 0
                    .KINGAKU_INVOICE_VAT = 0
                End With
            Next

            .DATE_PRINT = SRT_CONDITIONS.DATE_PRINT
            .DATE_PRINT_YEAR = .DATE_PRINT.Year
            .DATE_PRINT_MONTH = .DATE_PRINT.Month
            .DATE_PRINT_DAY = .DATE_PRINT.Day

            If .KEY.NUMBER_LIST_INVOICE > 0 Then '定期
                .NAME_OWNER = FUNC_GET_MNT_M_OWNER_NAME_OWNER(.KEY.CODE_OWNER, True)
                .CODE_POST = FUNC_GET_MNT_M_OWNER_CODE_POST(.KEY.CODE_OWNER, True)
                .NAME_ADDRESS_01 = FUNC_GET_MNT_M_OWNER_NAME_ADDRESS_01(.KEY.CODE_OWNER, True)
                .NAME_ADDRESS_02 = FUNC_GET_MNT_M_OWNER_NAME_ADDRESS_02(.KEY.CODE_OWNER, True)

                Dim SRT_KEY_INVOICE() As SRT_NUMBER_SERIAL_INVOICE
                SRT_KEY_INVOICE = FUNC_GET_INVOICE_FROM_REGULAR(.KEY.YEAR_INVOICE, .KEY.MONTH_INVOICE, SRT_CONDITIONS.DATE_INVOICE_FROM, SRT_CONDITIONS.DATE_INVOICE_TO, .KEY.CODE_OWNER, .KEY.NUMBER_LIST_INVOICE)
                For i = 1 To (SRT_KEY_INVOICE.Length - 1)
                    If i > (.DETAIL.Length - 1) Then
                        Exit For
                    End If
                    .DETAIL(i) = FUNC_GET_DETAIL_INVOICE(SRT_KEY_INVOICE(i).NUMBER_CONTRACT, SRT_KEY_INVOICE(i).SERIAL_CONTRACT, SRT_KEY_INVOICE(i).SERIAL_INVOICE)
                Next
            Else
                Dim SRT_SPOT As SRT_TABLE_MNT_T_CONTRACT_SPOT
                SRT_SPOT.KEY.NUMBER_CONTRACT = .KEY.NUMBER_CONTRACT
                SRT_SPOT.KEY.SERIAL_CONTRACT = .KEY.SERIAL_CONTRACT
                SRT_SPOT.DATA = Nothing
                Call FUNC_SELECT_TABLE_MNT_T_CONTRACT_SPOT(SRT_SPOT.KEY, SRT_SPOT.DATA, True)

                .NAME_OWNER = SRT_SPOT.DATA.NAME_OWNER
                .CODE_POST = SRT_SPOT.DATA.CODE_POST
                .NAME_ADDRESS_01 = SRT_SPOT.DATA.NAME_ADDRESS_01
                .NAME_ADDRESS_02 = SRT_SPOT.DATA.NAME_ADDRESS_02

                .DETAIL(1) = FUNC_GET_DETAIL_INVOICE(.KEY.NUMBER_CONTRACT, .KEY.SERIAL_CONTRACT, .KEY.SERIAL_INVOICE) 'スポットは1行固定
            End If

            .KINGAKU_TOTAL_INVOICE_BEFORE = 0
            .KINGAKU_TOTAL_DEPOSIT = 0
            For i = 1 To (.DETAIL.Length - 1)
                .KINGAKU_TOTAL_INVOICE_BEFORE += .DETAIL(i).KINGAKU_INVOICE_TOTAL_BEFORE
                .KINGAKU_TOTAL_DEPOSIT += .DETAIL(i).KINGAKU_DEPOSIT_BEFORE
            Next
        End With
    End Sub

    Private Function FUNC_GET_DETAIL_INVOICE(ByVal INT_NUMBER_CONTRACT As Integer, ByVal INT_SERIAL_CONTRACT As Integer, ByVal INT_SERIAL_INVOICE As Integer) As SRT_DETAIL_INVOICE
        Dim SRT_RET As SRT_DETAIL_INVOICE
        With SRT_RET
            .NAME_CONTRACT = ""
            .KINGAKU_INVOICE_DETAIL = 0
            .KINGAKU_INVOICE_VAT = 0
        End With

        Dim SRT_CONTRACT As SRT_TABLE_MNT_T_CONTRACT
        With SRT_CONTRACT.KEY
            .NUMBER_CONTRACT = INT_NUMBER_CONTRACT
            .SERIAL_CONTRACT = INT_SERIAL_CONTRACT
        End With
        SRT_CONTRACT.DATA = Nothing
        Call FUNC_SELECT_TABLE_MNT_T_CONTRACT(SRT_CONTRACT.KEY, SRT_CONTRACT.DATA, True)
        SRT_RET.NAME_CONTRACT = SRT_CONTRACT.DATA.NAME_CONTRACT
        SRT_RET.CODE_MAINTENANCE = SRT_CONTRACT.DATA.CODE_MAINTENANCE

        Dim SRT_INVOICE As SRT_TABLE_MNT_T_INVOICE
        With SRT_INVOICE.KEY
            .NUMBER_CONTRACT = INT_NUMBER_CONTRACT
            .SERIAL_CONTRACT = INT_SERIAL_CONTRACT
            .SERIAL_INVOICE = INT_SERIAL_INVOICE
        End With
        SRT_INVOICE.DATA = Nothing
        Call FUNC_SELECT_TABLE_MNT_T_INVOICE(SRT_INVOICE.KEY, SRT_INVOICE.DATA, True)
        SRT_RET.KINGAKU_INVOICE_DETAIL = SRT_INVOICE.DATA.KINGAKU_INVOICE_DETAIL
        SRT_RET.KINGAKU_INVOICE_VAT = SRT_INVOICE.DATA.KINGAKU_INVOICE_VAT
        SRT_RET.CODE_SECTION = SRT_INVOICE.DATA.CODE_SECTION

        '前回算出
        Dim INT_NUMBER_CONTRACT_BEFORE As Integer
        INT_NUMBER_CONTRACT_BEFORE = INT_NUMBER_CONTRACT

        Dim INT_SERIAL_CONTRACT_BEFORE As Integer
        Dim INT_SERIAL_INVOICE_BEFORE As Integer
        If INT_SERIAL_INVOICE = 1 Then
            INT_SERIAL_CONTRACT_BEFORE = INT_SERIAL_CONTRACT - 1
            INT_SERIAL_INVOICE_BEFORE = FUNC_GET_MNT_T_INVOICE_MAX_SERIAL_INVOICE(INT_NUMBER_CONTRACT_BEFORE, INT_SERIAL_CONTRACT_BEFORE)
        Else
            INT_SERIAL_CONTRACT_BEFORE = INT_SERIAL_CONTRACT
            INT_SERIAL_INVOICE_BEFORE = INT_SERIAL_INVOICE - 1
        End If

        Dim SRT_INVOICE_BEFORE As SRT_TABLE_MNT_T_INVOICE
        With SRT_INVOICE_BEFORE.KEY
            .NUMBER_CONTRACT = INT_NUMBER_CONTRACT_BEFORE
            .SERIAL_CONTRACT = INT_SERIAL_CONTRACT_BEFORE
            .SERIAL_INVOICE = INT_SERIAL_INVOICE_BEFORE
        End With
        SRT_INVOICE_BEFORE.DATA = Nothing
        Call FUNC_SELECT_TABLE_MNT_T_INVOICE(SRT_INVOICE_BEFORE.KEY, SRT_INVOICE_BEFORE.DATA, True)
        SRT_RET.KINGAKU_INVOICE_DETAIL_BEFORE = SRT_INVOICE_BEFORE.DATA.KINGAKU_INVOICE_DETAIL
        SRT_RET.KINGAKU_INVOICE_VAT_BEFORE = SRT_INVOICE_BEFORE.DATA.KINGAKU_INVOICE_VAT

        Dim SRT_DEPOSIT_KEY As SRT_TABLE_MNT_T_DEPOSIT_KEY
        With SRT_DEPOSIT_KEY
            .NUMBER_CONTRACT = SRT_INVOICE_BEFORE.KEY.NUMBER_CONTRACT
            .SERIAL_CONTRACT = SRT_INVOICE_BEFORE.KEY.SERIAL_CONTRACT
            .SERIAL_INVOICE = SRT_INVOICE_BEFORE.KEY.SERIAL_INVOICE
        End With
        SRT_RET.FLAG_DEPOSIT_DONE_BEFORE = FUNC_CHECK_TABLE_MNT_T_DEPOSIT(SRT_DEPOSIT_KEY)
        Return SRT_RET
    End Function

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
        End With

        With SRT_DATA
            If SRT_CONDITIONS.ENABLED_DATE_PRINT Then
                Call SUB_ADD_STR_ROW(STR_ROW, CStr(.DATE_PRINT_YEAR))
                Call SUB_ADD_STR_ROW(STR_ROW, CStr(.DATE_PRINT_MONTH))
                Call SUB_ADD_STR_ROW(STR_ROW, CStr(.DATE_PRINT_DAY))
            Else
                Call SUB_ADD_STR_ROW(STR_ROW, CStr(""))
                Call SUB_ADD_STR_ROW(STR_ROW, CStr(""))
                Call SUB_ADD_STR_ROW(STR_ROW, CStr(""))
            End If
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.CODE_POST))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.NAME_ADDRESS_01))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.NAME_ADDRESS_02))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.NAME_OWNER))
        End With

        With SRT_DATA
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.KINGAKU_TOTAL_INVOICE_BEFORE))
            Call SUB_ADD_STR_ROW(STR_ROW, CStr(.KINGAKU_TOTAL_DEPOSIT))
        End With

        For i = 1 To (SRT_DATA.DETAIL.Length - 1)
            With SRT_DATA.DETAIL(i)
                Call SUB_ADD_STR_ROW(STR_ROW, CStr(.CODE_SECTION))
                Call SUB_ADD_STR_ROW(STR_ROW, CStr(.NAME_CONTRACT))
                Call SUB_ADD_STR_ROW(STR_ROW, CStr(.KINGAKU_INVOICE_DETAIL))
                Call SUB_ADD_STR_ROW(STR_ROW, CStr(.KINGAKU_INVOICE_VAT))
            End With
        Next

        STR_RET = FUNC_GET_ONE_ROW_LIST_CSV(STR_ROW)

        Return STR_RET
    End Function

#Region "内部処理-汎用"
    Private Sub SUB_PUT_GUIDE(ByRef objFORM As Object, ByVal strGUIDE As String)
        Call objFORM.SUB_PUT_PROGRESS_GUIDE(strGUIDE)
    End Sub
#End Region

End Module
