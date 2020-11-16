Public Class FRM_MAIN

#Region "画面用・定数"
    Private Const CST_MY_GRID_COUNT_MAX As Integer = 1000
#End Region

#Region "画面用・列挙定数"
    Private Enum ENM_MY_EXEC_DO
        DO_SHOW_SEARCH = 1
        DO_PREVIEW
        DO_PRINT
        DO_PUT_FILE
        DO_SEARCH
        DO_CLEAR
        DO_END = 81
        DO_SHOW_SETTING
        DO_SHOW_COMMANDLINE
        DO_SHOW_CONFIG_SETTINGS
    End Enum

    Private Enum ENM_MY_GRID_MAIN
        CHECK = 0
        FLAG_CONTRACT_NAME
        NUMBER_VIEW
        YEARMONTH_INVOICE
        NAME_OWNER
        KINGAKU_INVOICE
        UBOUND = KINGAKU_INVOICE
    End Enum

    Private Enum ENM_MY_WINDOW_MODE
        INPUT_KEY = 1
        INPUT_DATA
    End Enum
#End Region

#Region "画面用・構造体"
    Private Structure SRT_MY_GRID_DATA
        Public FLAG_CONTRACT As Integer
        Public YEAR_INVOICE As Integer
        Public MONTH_INVOICE As Integer
        Public CODE_OWNER As Integer
        Public NUMBER_LIST_INVOICE As Integer
        Public NUMBER_CONTRACT As Integer
        Public SERIAL_CONTRACT As Integer
        Public SERIAL_INVOICE As Integer
        Public KINGAKU_INVOICE_DETAIL As Long
        Public KINGAKU_INVOICE_VAT As Long

        Public FLAG_CONTRACT_NAME As String
        Public CODE_OWNER_NAME As String

        Public Function FUNC_GET_YEAR_MONTH_INVOICE() As String
            Dim STR_RET As String
            STR_RET = ""
            STR_RET &= Format(Me.YEAR_INVOICE, "0000") & "年"
            STR_RET &= Format(Me.MONTH_INVOICE, "00") & "月"

            Return STR_RET
        End Function

        Public Function FUNC_GET_KINGAKU_INVOICE_TOTAL() As Long
            Dim LNG_RET As Long
            LNG_RET = Me.KINGAKU_INVOICE_DETAIL + Me.KINGAKU_INVOICE_VAT

            Return LNG_RET
        End Function
    End Structure

    Private Structure SRT_MY_INVOICE_DATA
        Public NUMBER_CONTRACT As Integer
        Public SERIAL_CONTRACT As Integer
        Public SERIAL_INVOICE As Integer
        Public ENABLED_INVOICE_CANCEL As Boolean
    End Structure

    Public Structure SRT_SEARCH_CONDITIONS '検索条件
        Public DATE_INVOICE_FROM As DateTime
        Public DATE_INVOICE_TO As DateTime
        Public FLAG_CONTRACT As Integer
    End Structure
#End Region

#Region "画面用・変数"
    Private BLN_PROCESS_DOING As Boolean
    Private ENM_WINDOW_MODE_CURRENT As ENM_MY_WINDOW_MODE '現在の画面状態
    Private TBL_GRID_DATA_MAIN As DataTable
    Private SRT_GRID_DATA_MAIN() As SRT_MY_GRID_DATA
#End Region

#Region "プロパティ用"
    Private BLN_PROPERTY_CHECK_ALL As Boolean
#End Region

#Region "プロパティ"
    '全選択状態
    Friend Property CHECK_ALL() As Boolean
        Get
            Return BLN_PROPERTY_CHECK_ALL
        End Get
        Set(ByVal Value As Boolean)
            BLN_PROPERTY_CHECK_ALL = Value
        End Set
    End Property
#End Region

#Region "初期化・終了処理"
    Private Sub SUB_CTRL_NEW_INIT()
        Call SUB_CTRL_EVENT_HANDLED_ADD()
    End Sub

    Private Sub SUB_CTRL_VIEW_INIT()
        Call glbSubMakeDataTable(TBL_GRID_DATA_MAIN, " ,形態,番号,請求年月,オーナー,請求金額", "BSSSSS")
        DGV_VIEW_DATA.DataSource = TBL_GRID_DATA_MAIN
        Call SUB_DGV_COLUMN_WIDTH_INIT_COUNT_FONT(DGV_VIEW_DATA, "1,3,3,5,15,6", "CLLRLR")

        Dim DAT_DATE_TO As DateTime
        DAT_DATE_TO = FUNC_GET_DATE_LASTMONTH(datSYSTEM_TOTAL_DATE_ACTIVE.AddMonths(1))
        Call SUB_CONTROL_INITALIZE_DateTimePicker(DTP_DATE_INVOICE_FROM, srtSYSTEM_TOTAL_CONFIG_SETTINGS.LOCAL.DATE_SYSTEM_REPLACE, DAT_DATE_TO)
        Call SUB_CONTROL_INITALIZE_DateTimePicker(DTP_DATE_INVOICE_TO, srtSYSTEM_TOTAL_CONFIG_SETTINGS.LOCAL.DATE_SYSTEM_REPLACE, DAT_DATE_TO)

        Call SUB_SYSTEM_COMMBO_MNT_M_KIND(CMB_FLAG_CONTRACT, ENM_MNT_M_KIND_CODE_FLAG.FLAG_CONTRACT, True, "全て")

        Call SUB_CONTROL_INITALIZE_DateTimePicker(DTP_DATE_PRINT, srtSYSTEM_TOTAL_CONFIG_SETTINGS.LOCAL.DATE_SYSTEM_REPLACE, DAT_DATE_TO)
    End Sub

    Private Sub SUB_CTRL_VALUE_INIT()
        Call SUB_CONTROL_CLEAR_FORM(Me)

        LBL_NAME_USER_HEAD.Text = FUNC_GET_MNG_M_USER_NAME_STAFF(srtSYSTEM_TOTAL_COMMANDLINE.CODE_STAFF)
        LBL_DATE_ACTIVE_HEAD.Text = Format(datSYSTEM_TOTAL_DATE_ACTIVE, "yyyy年MM月dd日")

        Dim DAT_INVOICE_FROM As DateTime
        DAT_INVOICE_FROM = FUNC_GET_DATE_FIRSMONTH(datSYSTEM_TOTAL_DATE_ACTIVE)
        Call SUB_CONTROL_SET_VALUE_DateTimePicker(DTP_DATE_INVOICE_FROM, DAT_INVOICE_FROM)

        Dim DAT_INVOICE_TO As DateTime
        DAT_INVOICE_TO = FUNC_GET_DATE_LASTMONTH(datSYSTEM_TOTAL_DATE_ACTIVE)
        Call SUB_CONTROL_SET_VALUE_DateTimePicker(DTP_DATE_INVOICE_TO, DAT_INVOICE_TO)

        Call SUB_SET_COMBO_KIND_CODE_FIRST(CMB_FLAG_CONTRACT)

        ReDim SRT_GRID_DATA_MAIN(0)
        Call SUB_REFRESH_GRID()

        CHK_DATE_PRINT.Checked = True
        Call SUB_CONTROL_SET_VALUE_DateTimePicker(DTP_DATE_PRINT, datSYSTEM_TOTAL_DATE_ACTIVE)
    End Sub
#End Region

#Region "各処理呼出元"
    Private Sub SUB_EXEC_DO(
    ByVal enmEXEC_DO As ENM_MY_EXEC_DO
    )
        If BLN_PROCESS_DOING Then
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        BLN_PROCESS_DOING = True
        Call Application.DoEvents()

        Select Case enmEXEC_DO
            Case ENM_MY_EXEC_DO.DO_SHOW_SEARCH
                Call SUB_SHOW_SEARCH()
            Case ENM_MY_EXEC_DO.DO_SEARCH
                Call SUB_SEARCH()
            Case ENM_MY_EXEC_DO.DO_PREVIEW
                Call SUB_PRINT(True, False)
            Case ENM_MY_EXEC_DO.DO_PRINT
                Call SUB_PRINT(False, False)
            Case ENM_MY_EXEC_DO.DO_PUT_FILE
                Call SUB_PRINT(False, True)
            Case ENM_MY_EXEC_DO.DO_CLEAR
                Call SUB_CLEAR()
            Case ENM_MY_EXEC_DO.DO_END
                Call SUB_END()
            Case ENM_MY_EXEC_DO.DO_SHOW_SETTING
                Call SUB_SHOW_SETTING()
            Case ENM_MY_EXEC_DO.DO_SHOW_COMMANDLINE
                Call SUB_SHOW_COMMANDLINE()
            Case ENM_MY_EXEC_DO.DO_SHOW_CONFIG_SETTINGS
                Call SUB_SHOW_CONFIG_SETTINGS()
        End Select

        Call Application.DoEvents()
        BLN_PROCESS_DOING = False
        Me.Cursor = Cursors.Default
    End Sub
#End Region

#Region "実行処理群"

    Private Sub SUB_SEARCH()

        If Not FUNC_CHECK_INPUT_KEY() Then
            Exit Sub
        End If

        Dim SRT_CONDITIONS As SRT_SEARCH_CONDITIONS
        SRT_CONDITIONS = FUNC_GET_SEARCH_CONDITHIONS() '検索条件取得

        ReDim SRT_GRID_DATA_MAIN(0)
        Call SUB_MAKE_GRID_DATA(SRT_CONDITIONS)

        Dim INT_COUNT As Integer
        INT_COUNT = UBound(SRT_GRID_DATA_MAIN)
        Call SUB_REFRESH_COUNT(INT_COUNT)

        If INT_COUNT <= 0 Then
            Call SUB_REFRESH_GRID()
            Dim STR_ERR_MSG As String
            STR_ERR_MSG = "対象データがありません。"
            Call System.Windows.Forms.MessageBox.Show(STR_ERR_MSG, Me.Text, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information)
            Call SUB_FOCUS_FIRST_INPUT_CONTROL(PNL_INPUT_KEY)
            Exit Sub
        End If

        Me.CHECK_ALL = False
        Call SUB_WINDOW_MODE_CHANGE(ENM_MY_WINDOW_MODE.INPUT_DATA)
        Call SUB_REFRESH_GRID()
    End Sub


    '印刷/プレビュー/ファイル出力
    Private Sub SUB_PRINT(ByVal BLN_PREVIEW As Boolean, ByVal BLN_PUT_FILE As Boolean)

        If Not FUNC_CHECK_INPUT_KEY() Then
            Exit Sub
        End If

        Dim SRT_CONDITIONS As MOD_PRINT.SRT_PRINT_CONDITIONS
        With SRT_CONDITIONS
            .PRINT_DATA = FUNC_GET_GRID_INVOICE()

            .DATE_INVOICE_FROM = DTP_DATE_INVOICE_FROM.Value
            .DATE_INVOICE_TO = DTP_DATE_INVOICE_TO.Value

            .ENABLED_DATE_PRINT = CHK_DATE_PRINT.Checked
            .DATE_PRINT = DTP_DATE_PRINT.Value
            .FORM = Me
        End With

        If SRT_CONDITIONS.PRINT_DATA.Length <= 1 Then
            Call MessageBox.Show("1件以上選択してください。", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim BLN_RET As Boolean
        Dim BLN_PUT As Boolean
        Dim BLN_CANCEL As Boolean
        BLN_RET = MOD_PRINT.FUNC_PRINT_MAIN(BLN_PUT, BLN_CANCEL, SRT_CONDITIONS, BLN_PREVIEW, BLN_PUT_FILE)

        If Not BLN_RET Then
            Call MessageBox.Show(MOD_PRINT_99.STR_FUNC_PRINT_MAIN_ERR_STR, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Call SUB_PUT_PROGRESS_GUIDE("")

        If Not BLN_PUT Then
            Call MessageBox.Show("対象データがありません。", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If Not BLN_PREVIEW Then
            If BLN_PUT_FILE Then
                If Not BLN_CANCEL Then
                    Call MessageBox.Show("ファイル出力を行いました。", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                Call MessageBox.Show("印刷を行いました。", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub SUB_CLEAR()
        Call SUB_CONTROL_CLEAR_FORM(Me)
        Call SUB_CTRL_VALUE_INIT() '値を初期化
        Call SUB_WINDOW_MODE_CHANGE(ENM_MY_WINDOW_MODE.INPUT_KEY)
        Call SUB_FOCUS_FIRST_INPUT_CONTROL(Me)
    End Sub

    Private Sub SUB_END()
        Call Me.Close()
    End Sub

    Private Sub SUB_SHOW_SETTING()
        BLN_SHOW_SETTING = True
        Call Me.Close()
    End Sub

    Private Sub SUB_SHOW_COMMANDLINE()
        Call SUB_SYSTEM_TOTAL_SHOW_COMMANDLINE(srtSYSTEM_TOTAL_COMMANDLINE)
    End Sub

    Private Sub SUB_SHOW_CONFIG_SETTINGS()
        Call SUB_SYSTEM_TOTAL_SHOW_SETTINGS(srtSYSTEM_TOTAL_CONFIG_SETTINGS)
    End Sub

    Private Sub SUB_SHOW_SEARCH()

        Dim CTL_ACTIVE As Control
        CTL_ACTIVE = Me.ActiveControl

        Dim CTL_SEARCH As Control
        CTL_SEARCH = Nothing
        Select Case True

            Case Else

        End Select

        If CTL_SEARCH Is Nothing Then
            Exit Sub
        End If

        Dim SNG_FONT_SIZE As Single
        SNG_FONT_SIZE = Me.Font.Size

        Dim BLN_RET As Boolean
        BLN_RET = False
        Select Case True
            Case Else
                'スルー
        End Select
    End Sub
#End Region

#Region "画面状態遷移"
    Private Sub SUB_WINDOW_MODE_CHANGE(
    ByVal ENM_CHANGE_MODE As ENM_MY_WINDOW_MODE
    )
        Dim TXT_DUMMY As TextBox

        If ENM_CHANGE_MODE = ENM_WINDOW_MODE_CURRENT Then
            Exit Sub
        End If
        TXT_DUMMY = Nothing
        Call SUB_ADD_TEXTBOX_AND_MOVE_FOCUS(TXT_DUMMY, Me)

        Select Case ENM_CHANGE_MODE
            Case ENM_MY_WINDOW_MODE.INPUT_KEY
                PNL_INPUT_KEY.Enabled = True
                PNL_INPUT_DATA.Enabled = False

                BTN_PREVIEW.Enabled = False
                BTN_PRINT.Enabled = False
                BTN_CLEAR.Enabled = True
                BTN_END.Enabled = True
            Case ENM_MY_WINDOW_MODE.INPUT_DATA
                PNL_INPUT_KEY.Enabled = False
                PNL_INPUT_DATA.Enabled = True

                BTN_PREVIEW.Enabled = True
                BTN_PRINT.Enabled = True
                BTN_CLEAR.Enabled = True
                BTN_END.Enabled = True
            Case Else
                'スルー
        End Select

        Call SUB_REMOVE_TEXTBOX(TXT_DUMMY, Me)

        ENM_WINDOW_MODE_CURRENT = ENM_CHANGE_MODE
        Call Application.DoEvents()
    End Sub
#End Region

#Region "グリッド関連"
    Private Sub SUB_MAKE_GRID_DATA(ByVal SRT_CONDITIONS As SRT_SEARCH_CONDITIONS)

        ReDim SRT_GRID_DATA_MAIN(0)

        Dim STR_WHERE As String
        STR_WHERE = FUNC_GET_SQL_WHERE(SRT_CONDITIONS) '検索条件からWHERE条件取得

        Dim STR_SQL As System.Text.StringBuilder
        STR_SQL = New System.Text.StringBuilder
        With STR_SQL
            Call .Append("SELECT" & Environment.NewLine)
            Call .Append("*" & Environment.NewLine)
            Call .Append("FROM" & Environment.NewLine)
            Call .Append("(" & Environment.NewLine)

            '定期分ココカラ
            Call .Append("SELECT" & Environment.NewLine)
            Call .Append(ENM_SYSTEM_INDIVIDUAL_FLAG_CONTRACT.REGULAR & " AS FLAG_CONTRACT" & "," & Environment.NewLine)
            Call .Append("YEAR_INVOICE" & "," & Environment.NewLine)
            Call .Append("MONTH_INVOICE" & "," & Environment.NewLine)
            Call .Append("CODE_OWNER" & "," & Environment.NewLine)
            Call .Append("CODE_OWNER AS CODE_OWNER_SORT" & "," & Environment.NewLine)
            Call .Append("NUMBER_LIST_INVOICE" & "," & Environment.NewLine)
            Call .Append(0 & " AS NUMBER_CONTRACT" & "," & Environment.NewLine)
            Call .Append(0 & " AS SERIAL_CONTRACT" & "," & Environment.NewLine)
            Call .Append(0 & " AS SERIAL_INVOICE" & "," & Environment.NewLine)
            Call .Append("SUM(KINGAKU_INVOICE_DETAIL) AS KINGAKU_INVOICE_DETAIL" & "," & Environment.NewLine)
            Call .Append("SUM(KINGAKU_INVOICE_VAT) AS KINGAKU_INVOICE_VAT" & "" & Environment.NewLine)
            Call .Append("FROM" & Environment.NewLine)
            Call .Append("(" & Environment.NewLine)
            Call .Append("SELECT" & Environment.NewLine)
            Call .Append("YEAR(MAIN.DATE_INVOICE) AS YEAR_INVOICE" & "," & Environment.NewLine)
            Call .Append("MONTH(MAIN.DATE_INVOICE) AS MONTH_INVOICE" & "," & Environment.NewLine)
            Call .Append("SUB_01.CODE_OWNER" & "," & Environment.NewLine)
            Call .Append("SUB_01.NUMBER_LIST_INVOICE" & "," & Environment.NewLine)
            Call .Append("MAIN.KINGAKU_INVOICE_DETAIL" & "," & Environment.NewLine)
            Call .Append("MAIN.KINGAKU_INVOICE_VAT" & "" & Environment.NewLine)
            Call .Append("FROM" & Environment.NewLine)
            Call .Append("(" & Environment.NewLine)
            Call .Append("SELECT" & Environment.NewLine)
            Call .Append("*" & Environment.NewLine)
            Call .Append("FROM" & Environment.NewLine)
            Call .Append("MNT_T_INVOICE WITH(NOLOCK)" & Environment.NewLine)
            Call .Append(") AS MAIN" & Environment.NewLine)
            Call .Append("INNER JOIN" & Environment.NewLine)
            Call .Append("(" & Environment.NewLine)
            Call .Append("SELECT" & Environment.NewLine)
            Call .Append("*" & Environment.NewLine)
            Call .Append("FROM" & Environment.NewLine)
            Call .Append("MNT_T_CONTRACT WITH(NOLOCK)" & Environment.NewLine)
            Call .Append("WHERE" & Environment.NewLine)
            Call .Append("1=1" & Environment.NewLine)
            Call .Append("AND NUMBER_LIST_INVOICE<>" & 0 & Environment.NewLine)
            Call .Append(") AS SUB_01" & Environment.NewLine)
            Call .Append("ON" & Environment.NewLine)
            Call .Append("MAIN.NUMBER_CONTRACT=SUB_01.NUMBER_CONTRACT" & Environment.NewLine)
            Call .Append("AND MAIN.SERIAL_CONTRACT=SUB_01.SERIAL_CONTRACT" & Environment.NewLine)
            Call .Append("WHERE" & Environment.NewLine)
            Call .Append("1=1" & Environment.NewLine)
            Call .Append(STR_WHERE) 'WHERE条件
            Call .Append(") AS MAIN" & Environment.NewLine)
            Call .Append("GROUP BY" & Environment.NewLine)
            Call .Append("YEAR_INVOICE,MONTH_INVOICE,CODE_OWNER,NUMBER_LIST_INVOICE" & Environment.NewLine)
            '定期分ココマデ
            Call .Append("UNION ALL" & Environment.NewLine)
            'スポット分ココカラ
            Call .Append("SELECT" & Environment.NewLine)
            Call .Append(ENM_SYSTEM_INDIVIDUAL_FLAG_CONTRACT.SPOT & " AS FLAG_CONTRACT" & "," & Environment.NewLine)
            Call .Append("YEAR(MAIN.DATE_INVOICE) AS YEAR_INVOICE" & "," & Environment.NewLine)
            Call .Append("MONTH(MAIN.DATE_INVOICE) AS MONTH_INVOICE" & "," & Environment.NewLine)
            Call .Append("SUB_01.CODE_OWNER" & "," & Environment.NewLine)
            Call .Append("0 AS CODE_OWNER_SORT" & "," & Environment.NewLine)
            Call .Append("SUB_01.NUMBER_LIST_INVOICE" & "," & Environment.NewLine)
            Call .Append("MAIN.NUMBER_CONTRACT" & "," & Environment.NewLine)
            Call .Append("MAIN.SERIAL_CONTRACT" & "," & Environment.NewLine)
            Call .Append("MAIN.SERIAL_INVOICE" & "," & Environment.NewLine)
            Call .Append("MAIN.KINGAKU_INVOICE_DETAIL" & "," & Environment.NewLine)
            Call .Append("MAIN.KINGAKU_INVOICE_VAT" & "" & Environment.NewLine)
            Call .Append("FROM" & Environment.NewLine)
            Call .Append("(" & Environment.NewLine)
            Call .Append("SELECT" & Environment.NewLine)
            Call .Append("*" & Environment.NewLine)
            Call .Append("FROM" & Environment.NewLine)
            Call .Append("MNT_T_INVOICE WITH(NOLOCK)" & Environment.NewLine)
            Call .Append(") AS MAIN" & Environment.NewLine)
            Call .Append("INNER JOIN" & Environment.NewLine)
            Call .Append("(" & Environment.NewLine)
            Call .Append("SELECT" & Environment.NewLine)
            Call .Append("*" & Environment.NewLine)
            Call .Append("FROM" & Environment.NewLine)
            Call .Append("MNT_T_CONTRACT WITH(NOLOCK)" & Environment.NewLine)
            Call .Append("WHERE" & Environment.NewLine)
            Call .Append("1=1" & Environment.NewLine)
            Call .Append("AND NUMBER_LIST_INVOICE=" & 0 & Environment.NewLine)
            Call .Append(") AS SUB_01" & Environment.NewLine)
            Call .Append("ON" & Environment.NewLine)
            Call .Append("MAIN.NUMBER_CONTRACT=SUB_01.NUMBER_CONTRACT" & Environment.NewLine)
            Call .Append("AND MAIN.SERIAL_CONTRACT=SUB_01.SERIAL_CONTRACT" & Environment.NewLine)
            Call .Append("WHERE" & Environment.NewLine)
            Call .Append("1=1" & Environment.NewLine)
            Call .Append(STR_WHERE) 'WHERE条件

            'スポット分ココマデ

            Call .Append(") AS MAIN" & Environment.NewLine)

            Call .Append("ORDER BY" & Environment.NewLine)
            Call .Append("FLAG_CONTRACT,YEAR_INVOICE,MONTH_INVOICE,CODE_OWNER_SORT,NUMBER_LIST_INVOICE,NUMBER_CONTRACT,SERIAL_CONTRACT,SERIAL_INVOICE" & Environment.NewLine)
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

        ReDim SRT_GRID_DATA_MAIN(CST_MY_GRID_COUNT_MAX)
        Dim INT_INDEX As Integer
        INT_INDEX = 0
        While SDR_READER.Read
            If INT_INDEX >= (SRT_GRID_DATA_MAIN.Length - 1) Then
                Exit While
            End If
            INT_INDEX += 1
            With SRT_GRID_DATA_MAIN(INT_INDEX)
                .FLAG_CONTRACT = CInt(SDR_READER.Item("FLAG_CONTRACT"))
                .YEAR_INVOICE = CInt(SDR_READER.Item("YEAR_INVOICE"))
                .MONTH_INVOICE = CInt(SDR_READER.Item("MONTH_INVOICE"))
                .CODE_OWNER = CInt(SDR_READER.Item("CODE_OWNER"))
                .NUMBER_LIST_INVOICE = CInt(SDR_READER.Item("NUMBER_LIST_INVOICE"))
                .NUMBER_CONTRACT = CInt(SDR_READER.Item("NUMBER_CONTRACT"))
                .SERIAL_CONTRACT = CInt(SDR_READER.Item("SERIAL_CONTRACT"))
                .SERIAL_INVOICE = CInt(SDR_READER.Item("SERIAL_INVOICE"))
                .KINGAKU_INVOICE_DETAIL = CLng(SDR_READER.Item("KINGAKU_INVOICE_DETAIL"))
                .KINGAKU_INVOICE_VAT = CLng(SDR_READER.Item("KINGAKU_INVOICE_VAT"))
            End With
        End While
        ReDim Preserve SRT_GRID_DATA_MAIN(INT_INDEX)
        Call SDR_READER.Close()
        SDR_READER = Nothing

        For i = 1 To (SRT_GRID_DATA_MAIN.Length - 1) '補助情報取得

            Dim SRT_RECORD_CONTRACT_SPOT As SRT_TABLE_MNT_T_CONTRACT_SPOT
            With SRT_RECORD_CONTRACT_SPOT.KEY
                .NUMBER_CONTRACT = SRT_GRID_DATA_MAIN(i).NUMBER_CONTRACT
                .SERIAL_CONTRACT = SRT_GRID_DATA_MAIN(i).SERIAL_CONTRACT
            End With
            SRT_RECORD_CONTRACT_SPOT.DATA = Nothing
            Call FUNC_SELECT_TABLE_MNT_T_CONTRACT_SPOT(SRT_RECORD_CONTRACT_SPOT.KEY, SRT_RECORD_CONTRACT_SPOT.DATA, True)

            With SRT_GRID_DATA_MAIN(i)
                .FLAG_CONTRACT_NAME = FUNC_GET_MNT_M_KIND_NAME_KIND(ENM_MNT_M_KIND_CODE_FLAG.FLAG_CONTRACT, .FLAG_CONTRACT)
                Select Case .FLAG_CONTRACT
                    Case ENM_SYSTEM_INDIVIDUAL_FLAG_CONTRACT.REGULAR
                        .CODE_OWNER_NAME = FUNC_GET_MNT_M_OWNER_NAME_OWNER(.CODE_OWNER, True)
                    Case ENM_SYSTEM_INDIVIDUAL_FLAG_CONTRACT.SPOT
                        .CODE_OWNER_NAME = SRT_RECORD_CONTRACT_SPOT.DATA.NAME_OWNER
                    Case Else
                        .CODE_OWNER_NAME = ""
                End Select
            End With
        Next
    End Sub

    Private Sub SUB_REFRESH_GRID()
        Dim OBJ_TEMP(ENM_MY_GRID_MAIN.UBOUND) As Object
        Dim INT_MAX_INDEX As Integer

        Call TBL_GRID_DATA_MAIN.Clear()

        INT_MAX_INDEX = (SRT_GRID_DATA_MAIN.Length - 1)

        If INT_MAX_INDEX <= 0 Then
            Exit Sub
        End If

        For i = 1 To INT_MAX_INDEX
            With SRT_GRID_DATA_MAIN(i)
                OBJ_TEMP(ENM_MY_GRID_MAIN.CHECK) = False
                OBJ_TEMP(ENM_MY_GRID_MAIN.FLAG_CONTRACT_NAME) = .FLAG_CONTRACT_NAME
                OBJ_TEMP(ENM_MY_GRID_MAIN.YEARMONTH_INVOICE) = .FUNC_GET_YEAR_MONTH_INVOICE
                OBJ_TEMP(ENM_MY_GRID_MAIN.NAME_OWNER) = .CODE_OWNER_NAME
                OBJ_TEMP(ENM_MY_GRID_MAIN.KINGAKU_INVOICE) = Format(.FUNC_GET_KINGAKU_INVOICE_TOTAL, "#,##0")
            End With
            Call glbSubAddRowDataTable(TBL_GRID_DATA_MAIN, OBJ_TEMP)
        Next

        'グリッドのセルの編集可項目を変更
        Call SUB_DATA_GRID_SET_READ_ONLY_MODE_CELL(DGV_VIEW_DATA)
        Call SUB_DATA_GRID_CELL_READ_ONLY_MODE(DGV_VIEW_DATA, ENM_MY_GRID_MAIN.CHECK, False)

        Call DGV_VIEW_DATA.Refresh()
        Call System.Windows.Forms.Application.DoEvents()

        Call SUB_SET_SELECT_ROW_INDEX(DGV_VIEW_DATA, 0)
    End Sub

    Private Sub SUB_EDIT_GRID_VIEW_FLAG(ByVal BLN_FLAG As Boolean)
        Dim TBL_DATA_TABLE As DataTable

        TBL_DATA_TABLE = DGV_VIEW_DATA.DataSource
        Dim INT_MAX_INDEX As Integer

        INT_MAX_INDEX = (TBL_DATA_TABLE.Rows.Count - 1)
        For intLOOP_INDEX = 0 To INT_MAX_INDEX
            TBL_DATA_TABLE.Rows(intLOOP_INDEX).Item(ENM_MY_GRID_MAIN.CHECK) = BLN_FLAG
        Next

        'チラツキを抑えるため、選択モードを変更して、リフレッシュ
        Call SUB_DATA_GRID_REFRESH_CHG_SELECTION_MODE(DGV_VIEW_DATA)
    End Sub

    Private Function FUNC_GET_ENABLED_INVOICE_CANCEL(ByVal INT_NUMBER_CONTRACT As Integer, ByVal INT_SERIAL_CONTRACT As Integer, ByVal DAT_DATE_INVOICE As DateTime) As Boolean

        Return True
    End Function

    Private Function FUNC_GET_GRID_INVOICE() As MOD_PRINT.SRT_PTINT_INVOICE_KEY()

        Dim SRT_RET() As MOD_PRINT.SRT_PTINT_INVOICE_KEY
        ReDim SRT_RET(0)

        Dim INT_MAX_INDEX As Integer
        INT_MAX_INDEX = (SRT_GRID_DATA_MAIN.Length - 1)
        For i = 1 To INT_MAX_INDEX '構造体のLength分のデータがありきとする

            Dim BLN_CHECK As Boolean
            BLN_CHECK = FUNC_GET_CHECK_STATE_GRID(i)

            If BLN_CHECK Then
                Dim INT_INDEX As Integer
                INT_INDEX = SRT_RET.Length
                ReDim Preserve SRT_RET(INT_INDEX)
                SRT_RET(INT_INDEX).YEAR_INVOICE = SRT_GRID_DATA_MAIN(i).YEAR_INVOICE
                SRT_RET(INT_INDEX).MONTH_INVOICE = SRT_GRID_DATA_MAIN(i).MONTH_INVOICE
                SRT_RET(INT_INDEX).CODE_OWNER = SRT_GRID_DATA_MAIN(i).CODE_OWNER
                SRT_RET(INT_INDEX).NUMBER_LIST_INVOICE = SRT_GRID_DATA_MAIN(i).NUMBER_LIST_INVOICE
                SRT_RET(INT_INDEX).NUMBER_CONTRACT = SRT_GRID_DATA_MAIN(i).NUMBER_CONTRACT
                SRT_RET(INT_INDEX).SERIAL_CONTRACT = SRT_GRID_DATA_MAIN(i).SERIAL_CONTRACT
                SRT_RET(INT_INDEX).SERIAL_INVOICE = SRT_GRID_DATA_MAIN(i).SERIAL_INVOICE
            End If
        Next

        Return SRT_RET
    End Function

    Private Function FUNC_GET_CHECK_STATE_GRID(ByVal INT_ROW_INDEX As Integer) As Boolean
        Dim INT_TABLE_INDEX As Integer
        INT_TABLE_INDEX = (INT_ROW_INDEX - 1)

        Dim TBL_DATA_TABLE As DataTable
        TBL_DATA_TABLE = DGV_VIEW_DATA.DataSource
        If TBL_DATA_TABLE Is Nothing Then
            Return False
        End If

        Dim ROW_DATA As DataRow
        Try
            ROW_DATA = TBL_DATA_TABLE.Rows(INT_TABLE_INDEX)
        Catch ex As Exception
            Return False '行無
        End Try

        Dim OBJ_TEMP As Object
        Try
            OBJ_TEMP = ROW_DATA.Item(ENM_MY_GRID_MAIN.CHECK)
        Catch ex As Exception
            Return False '列定義数不一致
        End Try

        Dim BLN_CHECK As Boolean
        BLN_CHECK = CBool(OBJ_TEMP)

        ROW_DATA = Nothing

        Return BLN_CHECK
    End Function
#End Region

#Region "チェック処理"
    Private Function FUNC_CHECK_INPUT_KEY() As Boolean
        Dim CTL_CONTROL As Control
        Dim ENM_ERR_CODE As CONTROL_CHECK_ERR_CODE
        Dim STR_ERR_MSG As String

        'Enable = True の入力項目すべてチェック対象(TAG=Check_Head)
        CTL_CONTROL = Nothing
        If Not FUNC_CONTROL_CHECK_INPUT_FORM_CONTROLS(PNL_INPUT_KEY, CTL_CONTROL, ENM_ERR_CODE, "Check") Then
            STR_ERR_MSG = FUNC_GET_MESSAGE_CTRL_CHECK(ENM_ERR_CODE, FUNC_GET_TEXT_GUIDE_LABEL(CTL_CONTROL))
            Call MessageBox.Show(STR_ERR_MSG, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Call CTL_CONTROL.Focus()
            Return False
        End If

        '請求日　大小チェック
        CTL_CONTROL = DTP_DATE_INVOICE_FROM
        Dim DAT_DATE_INVOICE_FROM As DateTime
        DAT_DATE_INVOICE_FROM = DTP_DATE_INVOICE_FROM.Value
        Dim DAT_DATE_INVOICE_TO As DateTime
        DAT_DATE_INVOICE_TO = DTP_DATE_INVOICE_TO.Value
        If DAT_DATE_INVOICE_FROM > DAT_DATE_INVOICE_TO Then
            STR_ERR_MSG = FUNC_GET_INPUT_CHECK_ERROR_MESSAGE(ENM_SYSTEM_INDIVIDUAL_INPUT_CHECK.CHK_ERR_FROM_TO, FUNC_GET_TEXT_GUIDE_LABEL(CTL_CONTROL))
            Call MessageBox.Show(STR_ERR_MSG, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Call CTL_CONTROL.Focus()
            Return False
        End If

        Return True
    End Function

    Private Function FUNC_CHECK_INPUT_DATA() As Boolean
        Dim CTL_CONTROL As Control
        Dim ENM_ERR_CODE As CONTROL_CHECK_ERR_CODE
        Dim STR_ERR_MSG As String

        'Enable = True の入力項目すべてチェック対象(TAG=Check_Head)
        CTL_CONTROL = Nothing
        If Not FUNC_CONTROL_CHECK_INPUT_FORM_CONTROLS(PNL_INPUT_DATA, CTL_CONTROL, ENM_ERR_CODE, "Check") Then
            STR_ERR_MSG = FUNC_GET_MESSAGE_CTRL_CHECK(ENM_ERR_CODE, FUNC_GET_TEXT_GUIDE_LABEL(CTL_CONTROL))
            Call MessageBox.Show(STR_ERR_MSG, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Call CTL_CONTROL.Focus()
            Return False
        End If

        Return True
    End Function

#End Region

#Region "内部処理"
    Private Sub SUB_REFRESH_COUNT(ByVal INT_COUNT As Integer)
        LBL_COUNT_SEARCH_MAX.Visible = False
        LBL_COUNT_SEARCH.Text = Format(INT_COUNT, "#,##0")

        If INT_COUNT >= CST_MY_GRID_COUNT_MAX Then
            LBL_COUNT_SEARCH_MAX.Visible = True
        End If
    End Sub

    Private Function FUNC_GET_SEARCH_CONDITHIONS() As SRT_SEARCH_CONDITIONS
        Dim srtCONDITIONS As SRT_SEARCH_CONDITIONS
        With srtCONDITIONS
            .FLAG_CONTRACT = FUNC_GET_COMBO_KIND_CODE(CMB_FLAG_CONTRACT)
            .DATE_INVOICE_FROM = DTP_DATE_INVOICE_FROM.Value
            .DATE_INVOICE_TO = DTP_DATE_INVOICE_TO.Value
        End With

        Return srtCONDITIONS
    End Function

    Private Function FUNC_GET_SQL_WHERE(ByVal SRT_CONDITIONS As SRT_SEARCH_CONDITIONS)
        Dim STR_WHERE As String
        STR_WHERE = ""

        With SRT_CONDITIONS
            Dim SRT_INVOICE_PERIOD As SRT_DATE_PERIOD
            SRT_INVOICE_PERIOD.DATE_FROM = SRT_CONDITIONS.DATE_INVOICE_FROM
            SRT_INVOICE_PERIOD.DATE_TO = SRT_CONDITIONS.DATE_INVOICE_TO
            STR_WHERE &= FUNC_GET_SQL_WHERE_DATE_FROM_TO(SRT_INVOICE_PERIOD, "DATE_INVOICE")

            If .FLAG_CONTRACT > 0 Then
                STR_WHERE &= FUNC_GET_SQL_WHERE_INT(SRT_CONDITIONS.FLAG_CONTRACT, "SUB_01.FLAG_CONTRACT", "=")
            End If
        End With

        Return STR_WHERE
    End Function

    Public Sub SUB_PUT_PROGRESS_GUIDE(ByVal STR_PROGRESS As String)

        LBL_BATCH_PROGRESS.Text = STR_PROGRESS
        Call LBL_BATCH_PROGRESS.Refresh()
        Call Application.DoEvents()
    End Sub

    Private Sub SUB_REFRESH_ENABLED_DATE_PRINT()
        Dim BLN_CHECK As Boolean
        BLN_CHECK = CHK_DATE_PRINT.Checked
        If BLN_CHECK Then
            DTP_DATE_PRINT.Enabled = True
        Else
            DTP_DATE_PRINT.Enabled = False
        End If
    End Sub
#End Region

#Region "キー制御処理"
    '通常のコマンドキー制御(シフトマスク無し)
    Private Sub SUB_KEY_DOWN(ByVal enmKEY_CODE As Windows.Forms.Keys, ByRef blnHandled As Boolean)
        Select Case enmKEY_CODE
            Case Keys.Enter
                blnHandled = True
                If Not FUNC_RETURN_KEYDOWN() Then
                    Exit Sub
                End If
                Call SUB_CONTROL_FOCUS_MOVE(ENM_MOVE_FOCUS_TYPE.FOCUS_NEXT)
            Case Else
                'スルー
        End Select
    End Sub

    '通常のコマンドキー制御(CTRL)
    Private Sub SUB_KEY_DOWN_CTRL(ByVal enmKEY_CODE As Windows.Forms.Keys, ByRef blnHandled As Boolean)
        Select Case enmKEY_CODE
            Case Keys.F
                Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_SHOW_SEARCH)
            Case Else
                'スルー
        End Select
    End Sub

    '通常のコマンドキー制御(ALT)
    Private Sub SUB_KEY_DOWN_ALT(ByVal enmKEY_CODE As Windows.Forms.Keys, ByRef blnHandled As Boolean)
        Select Case enmKEY_CODE
            Case Keys.C
                Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_SHOW_COMMANDLINE)
            Case Keys.V
                Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_SHOW_CONFIG_SETTINGS)
            Case Keys.S
                Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_SHOW_SETTING)
            Case Else
                'スルー
        End Select
    End Sub

    Private Function FUNC_RETURN_KEYDOWN() As Boolean
        Dim CTL_ACTIVE As Control
        Dim BLN_RET As Boolean

        If IsNothing(Me.ActiveControl) Then
            Return False
        End If

        CTL_ACTIVE = Me.ActiveControl

        Select Case True
            Case Else
                BLN_RET = True
        End Select

        CTL_ACTIVE = Nothing

        Return BLN_RET

        Return True
    End Function
#End Region

#Region "NEW"
    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        Call SUB_CTRL_NEW_INIT()
    End Sub
#End Region

#Region "イベントハンドル(フォーカス制御)"
    Private Sub SUB_CTRL_EVENT_HANDLED_ADD() '共通イベントハンドルの追加
        Call SUB_CTRL_EVENT_HANDLED_ADD_MAIN(Me)
    End Sub

    Private Sub SUB_CTRL_EVENT_HANDLED_ADD_MAIN(ByRef objCONTENA As Object)
        Dim ctlCUR_CTRL As Control

        For Each ctlCUR_CTRL In objCONTENA.Controls
            Select Case True
                Case TypeOf ctlCUR_CTRL Is GroupBox
                    Call SUB_CTRL_EVENT_HANDLED_ADD_MAIN(ctlCUR_CTRL)
                Case TypeOf ctlCUR_CTRL Is Panel
                    Call SUB_CTRL_EVENT_HANDLED_ADD_MAIN(ctlCUR_CTRL)
                Case TypeOf ctlCUR_CTRL Is TextBox _
                  Or TypeOf ctlCUR_CTRL Is ComboBox
                    AddHandler ctlCUR_CTRL.GotFocus, AddressOf SUB_CTRL_GOTFOCUS    'フォーカス取得
                    AddHandler ctlCUR_CTRL.LostFocus, AddressOf SUB_CTRL_LOSTFOCUS  'フォーカス喪失
                Case Else

            End Select
        Next
    End Sub

    Private Sub SUB_CTRL_EVENT_HANDLED_REMOVE() '共通イベントハンドルの削除
        Call SUB_CTRL_EVENT_HANDLED_REMOVE_MAIN(Me)
    End Sub

    Private Sub SUB_CTRL_EVENT_HANDLED_REMOVE_MAIN(ByRef objCONTENA As Object)
        Dim ctlCUR_CTRL As Control

        For Each ctlCUR_CTRL In objCONTENA
            Select Case True
                Case TypeOf ctlCUR_CTRL Is GroupBox
                    Call SUB_CTRL_EVENT_HANDLED_REMOVE_MAIN(ctlCUR_CTRL)
                Case TypeOf ctlCUR_CTRL Is Panel
                    Call SUB_CTRL_EVENT_HANDLED_REMOVE_MAIN(ctlCUR_CTRL)
                Case TypeOf ctlCUR_CTRL Is TextBox Or TypeOf ctlCUR_CTRL Is ComboBox
                    RemoveHandler ctlCUR_CTRL.GotFocus, AddressOf SUB_CTRL_GOTFOCUS   'フォーカス取得
                    RemoveHandler ctlCUR_CTRL.LostFocus, AddressOf SUB_CTRL_LOSTFOCUS  'フォーカス喪失
                Case Else

            End Select
        Next
    End Sub
#End Region

#Region "イベント-フォーカス取得"
    Private Sub SUB_CTRL_GOTFOCUS(ByVal sender As Object, ByVal e As System.EventArgs)
        Call SUB_COMMON_EVENT_GOTFOCUS(sender)
    End Sub
#End Region

#Region "イベント-フォーカス喪失"
    Private Sub SUB_CTRL_LOSTFOCUS(ByVal sender As Object, ByVal e As System.EventArgs)
        Call SUB_COMMON_EVENT_LOSTFOCUS(sender)
    End Sub
#End Region

#Region "イベント-ボタンクリック"

    Private Sub BTN_SEARCH_Click(sender As Object, e As EventArgs) Handles BTN_SEARCH.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_SEARCH)
    End Sub

    Private Sub BTN_PREVIEW_Click(sender As Object, e As EventArgs) Handles BTN_PREVIEW.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_PREVIEW)
    End Sub

    Private Sub BTN_PRINT_Click(sender As Object, e As EventArgs) Handles BTN_PRINT.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_PRINT)
    End Sub

    Private Sub BTN_PUT_FILE_Click(sender As Object, e As EventArgs) Handles BTN_PUT_FILE.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_PUT_FILE)
    End Sub

    Private Sub BTN_CLEAR_Click(sender As Object, e As EventArgs) Handles BTN_CLEAR.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_CLEAR)
    End Sub

    Private Sub BTN_END_Click(sender As Object, e As EventArgs) Handles BTN_END.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_END)
    End Sub
#End Region

#Region "イベント-グリッドクリック"
    Private Sub DGV_VIEW_DATA_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_VIEW_DATA.ColumnHeaderMouseClick
        Select Case e.ColumnIndex
            Case ENM_MY_GRID_MAIN.CHECK
            Case Else
                Exit Sub
        End Select

        Me.CHECK_ALL = Not Me.CHECK_ALL
        Call SUB_EDIT_GRID_VIEW_FLAG(Me.CHECK_ALL)
    End Sub
#End Region

#Region "イベント-バリューチェンジ"
    Private Sub DTP_DATE_INVOICE_FROM_ValueChanged(sender As Object, e As EventArgs) Handles DTP_DATE_INVOICE_FROM.ValueChanged
        Dim DAT_FROM As DateTime
        DAT_FROM = sender.Value
        Dim DAT_TO As DateTime
        DAT_TO = FUNC_GET_DATE_LASTMONTH(DAT_FROM)
        Call SUB_CONTROL_SET_VALUE_DateTimePicker(DTP_DATE_INVOICE_TO, DAT_TO)
    End Sub
#End Region

#Region "イベント-チェックチェンジ"

    Private Sub CHK_DATE_PRINT_CheckedChanged(sender As Object, e As EventArgs) Handles CHK_DATE_PRINT.CheckedChanged
        Call SUB_REFRESH_ENABLED_DATE_PRINT()
    End Sub
#End Region

    Private Sub FRM_MAIN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call SUB_CTRL_VIEW_INIT()
        Call SUB_CTRL_VALUE_INIT()
        Call SUB_WINDOW_MODE_CHANGE(ENM_MY_WINDOW_MODE.INPUT_KEY)
    End Sub

    Private Sub FRM_MAIN_Activated(sender As Object, e As EventArgs) Handles Me.Activated

    End Sub

    Private Sub FRM_MAIN_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Enabled = False
        Call Application.DoEvents()
    End Sub

    Private Sub FRM_MAIN_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case True
            Case e.Control
                Call SUB_KEY_DOWN_CTRL(e.KeyCode, e.Handled)
            Case e.Alt
                Call SUB_KEY_DOWN_ALT(e.KeyCode, e.Handled)
            Case e.Shift
            Case Else
                Call SUB_KEY_DOWN(e.KeyCode, e.Handled)
        End Select
    End Sub

    Private Sub FRM_MAIN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Call SUB_COMMON_EVENT_KEYPRESS(Me, e.KeyChar, e.Handled)
    End Sub

End Class
