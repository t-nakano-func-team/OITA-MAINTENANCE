Public Class FRM_MAIN

#Region "画面用・定数"
    Private Const CST_MY_GRID_COUNT_MAX As Integer = 1000
#End Region

#Region "画面用・列挙定数"
    Private Enum ENM_MY_EXEC_DO
        DO_SHOW_SEARCH = 1
        DO_SEARCH
        DO_BATCH
        DO_CLEAR
        DO_SHOW_SUB_WINDOW
        DO_END = 81
        DO_SHOW_SETTING
        DO_SHOW_COMMANDLINE
        DO_SHOW_CONFIG_SETTINGS
    End Enum

    Private Enum ENM_MY_GRID_MAIN
        DATE_INVOICE = 0
        KIND_CONTRACT_NAME
        NUMBER_CONTRACT_VIEW
        NAME_OWNER
        NAME_CONTRACT
        COUNT_INVOICE_VIEW
        KINGAKU_INVOICE
        FLAG_DEPOSIT_DONE_NAME
        UBOUND = FLAG_DEPOSIT_DONE_NAME
    End Enum

    Private Enum ENM_MY_WINDOW_MODE
        INPUT_KEY = 1
        INPUT_DATA
    End Enum
#End Region

#Region "画面用・構造体"
    Private Structure SRT_MY_GRID_DATA
        Public NUMBER_CONTRACT As Integer
        Public SERIAL_CONTRACT As Integer
        Public SERIAL_INVOICE As Integer

        Public DATE_INVOICE As DateTime
        Public KIND_CONTRACT As Integer
        Public FLAG_DEPOSIT_DONE As Integer

        Public CODE_OWNER As Integer
        Public NAME_CONTRACT As String
        Public COUNT_INVOICE As Integer

        Public KINGAKU_INVOICE_DETAIL As Long
        Public KINGAKU_INVOICE_VAT As Long
        Public KIND_CONTRACT_NAME As String
        Public CODE_OWNER_NAME As String
        Public FLAG_DEPOSIT_DONE_NAME As String

        Public Function FUNC_GET_NUMBER_SERIAL_CONTRACT() As String
            Dim STR_NUMBER_CONTRACT As String
            STR_NUMBER_CONTRACT = MOD_CODE_TOOL.Format(Me.NUMBER_CONTRACT, New String("0", INT_SYSTEM_NUMBER_CONTRACT_MAX_LENGTH))

            Dim STR_SERIAL_CONTRACT As String
            STR_SERIAL_CONTRACT = MOD_CODE_TOOL.Format(Me.NUMBER_CONTRACT, New String("0", INT_SYSTEM_SERIAL_CONTRACT_MAX_LENGTH))

            Dim STR_RET As String
            STR_RET = ""
            STR_RET &= STR_NUMBER_CONTRACT
            STR_RET &= "-"
            STR_RET &= STR_SERIAL_CONTRACT

            Return STR_RET
        End Function

        Public Function FUNC_GET_COUNT_INVOICE_VIEW() As String
            Dim STR_RET As String
            STR_RET = ""
            STR_RET &= (Me.SERIAL_INVOICE) & ""
            STR_RET &= "/"
            STR_RET &= (Me.COUNT_INVOICE) & ""

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
        Public KIND_CONTRACT As Integer
        Public DATE_INVOICE_FROM As DateTime
        Public DATE_INVOICE_TO As DateTime
        Public CODE_OWNER_FROM As Integer
        Public CODE_OWNER_TO As Integer
        Public NAME_OWNER As String
        Public FLAG_DEPOSIT_DONE As Integer
    End Structure
#End Region

#Region "画面用・変数"
    Private BLN_PROCESS_DOING As Boolean
    Private ENM_WINDOW_MODE_CURRENT As ENM_MY_WINDOW_MODE '現在の画面状態
    Private TBL_GRID_DATA_MAIN As DataTable
    Private SRT_GRID_DATA_MAIN() As SRT_MY_GRID_DATA
#End Region

#Region "初期化・終了処理"
    Private Sub SUB_CTRL_NEW_INIT()
        Call SUB_CTRL_EVENT_HANDLED_ADD()
    End Sub

    Private Sub SUB_CTRL_VIEW_INIT()
        Call glbSubMakeDataTable(TBL_GRID_DATA_MAIN, "請求日付,形態,契約番号,オーナー,契約内容,回数,請求金額,入金", "SSSSSSSS")
        DGV_VIEW_DATA.DataSource = TBL_GRID_DATA_MAIN
        Call SUB_DGV_COLUMN_WIDTH_INIT_COUNT_FONT(DGV_VIEW_DATA, "5,3,4,6,6,2,4,3", "LLRLLCRL")

        Dim DAT_DATE_TO As DateTime
        DAT_DATE_TO = FUNC_GET_DATE_LASTMONTH(datSYSTEM_TOTAL_DATE_ACTIVE.AddMonths(1))
        Call SUB_CONTROL_INITALIZE_DateTimePicker(DTP_DATE_INVOICE_FROM, srtSYSTEM_TOTAL_CONFIG_SETTINGS.LOCAL.DATE_SYSTEM_REPLACE, DAT_DATE_TO)
        Call SUB_CONTROL_INITALIZE_DateTimePicker(DTP_DATE_INVOICE_TO, srtSYSTEM_TOTAL_CONFIG_SETTINGS.LOCAL.DATE_SYSTEM_REPLACE, DAT_DATE_TO)

        Call SUB_SYSTEM_COMMBO_MNT_M_KIND(CMB_KIND_CONTRACT, ENM_MNT_M_KIND_CODE_FLAG.KIND_CONTRACT, True, "全て")
        Call SUB_SYSTEM_COMMBO_MNT_M_KIND(CMB_FLAG_DEPOSIT_DONE, ENM_MNT_M_KIND_CODE_FLAG.FLAG_DEPOSIT_DONE, True, "全て")
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

        Call SUB_SET_COMBO_KIND_CODE_FIRST(CMB_KIND_CONTRACT)
        Call SUB_REFRESH_ENABLED_NAME_OWNER()
        Call SUB_SET_COMBO_KIND_CODE(CMB_FLAG_DEPOSIT_DONE, ENM_SYSTEM_INDIVIDUAL_FLAG_DEPOSIT_DONE.NOT_DONE)

        ReDim SRT_GRID_DATA_MAIN(0)
        Call SUB_REFRESH_GRID()
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
            Case ENM_MY_EXEC_DO.DO_CLEAR
                Call SUB_CLEAR()
            Case ENM_MY_EXEC_DO.DO_SHOW_SUB_WINDOW
                Call SUB_SHOW_SUB_WINDOW()
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
        INT_COUNT = (SRT_GRID_DATA_MAIN.Length - 1)
        Call SUB_REFRESH_COUNT(INT_COUNT)

        If INT_COUNT <= 0 Then
            Call SUB_REFRESH_GRID()
            Dim STR_ERR_MSG As String
            STR_ERR_MSG = "対象データがありません。"
            Call System.Windows.Forms.MessageBox.Show(STR_ERR_MSG, Me.Text, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information)
            Call SUB_FOCUS_FIRST_INPUT_CONTROL(PNL_INPUT_KEY)
            Exit Sub
        End If

        Call SUB_WINDOW_MODE_CHANGE(ENM_MY_WINDOW_MODE.INPUT_DATA)
        Call SUB_REFRESH_GRID()
    End Sub

    Private Sub SUB_CLEAR()
        Call SUB_CONTROL_CLEAR_FORM(Me)
        Call SUB_CTRL_VALUE_INIT() '値を初期化
        Call SUB_WINDOW_MODE_CHANGE(ENM_MY_WINDOW_MODE.INPUT_KEY)
        Call SUB_FOCUS_FIRST_INPUT_CONTROL(Me)
    End Sub

    Private Sub SUB_SHOW_SUB_WINDOW()

        Dim INT_SELECT_ROW_INDEX As Integer
        INT_SELECT_ROW_INDEX = FUNC_GET_SELECT_ROW_INDEX(DGV_VIEW_DATA)

        If INT_SELECT_ROW_INDEX <= 0 Then
            Exit Sub
        End If

        Dim INT_SRT_INDEX As Integer
        INT_SRT_INDEX = INT_SELECT_ROW_INDEX
        With SRT_GRID_DATA_MAIN(INT_SRT_INDEX)
            Dim FRM_SHOW As FRM_SUB_01
            FRM_SHOW = New FRM_SUB_01
            FRM_SHOW.Font = New System.Drawing.Font(FRM_SHOW.Font.Name, Me.Font.Size)
            FRM_SHOW.Text = Me.Text
            FRM_SHOW.NUMBER_CONTRACT = .NUMBER_CONTRACT
            FRM_SHOW.SERIAL_CONTRACT = .SERIAL_CONTRACT
            FRM_SHOW.SERIAL_INVOICE = .SERIAL_INVOICE

            Call FRM_SHOW.ShowDialog()

            Dim BLN_CNACEL As Boolean
            BLN_CNACEL = FRM_SHOW.RET_EDIT_CANCEL

            Call FRM_SHOW.Dispose()
            FRM_SHOW = Nothing

            If BLN_CNACEL Then
                Exit Sub
            End If
        End With

        Call SUB_REFRESH_DATA_ONE(SRT_GRID_DATA_MAIN(INT_SRT_INDEX))
        Call SUB_REFRESH_GRID_ROW(INT_SRT_INDEX)
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
            Case (CTL_ACTIVE Is TXT_CODE_OWNER_FROM) Or (CTL_ACTIVE Is BTN_CODE_OWNER_FROM_SEARCH)
                CTL_SEARCH = TXT_CODE_OWNER_FROM
            Case (CTL_ACTIVE Is TXT_CODE_OWNER_TO) Or (CTL_ACTIVE Is BTN_CODE_OWNER_TO_SEARCH)
                CTL_SEARCH = TXT_CODE_OWNER_TO
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
            Case (CTL_SEARCH Is TXT_CODE_OWNER_FROM) Or (CTL_SEARCH Is TXT_CODE_OWNER_TO)
                Dim TXT_SEARCH As TextBox
                TXT_SEARCH = CTL_SEARCH
                Dim INT_CODE_OWNER As Integer
                INT_CODE_OWNER = FUNC_VALUE_CONVERT_NUMERIC_INT(TXT_SEARCH.Text)

                BLN_RET = FUNC_SHOW_SYSTEM_INDIVIDUAL_SEARCH_OWNER(INT_CODE_OWNER, SNG_FONT_SIZE)

                If BLN_RET Then
                    TXT_SEARCH.Text = Format(INT_CODE_OWNER, New String("0", TXT_SEARCH.MaxLength))
                    Call TXT_SEARCH.Focus()
                    Call TXT_SEARCH.SelectAll()
                End If
            Case Else
                'スルー
        End Select
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
            Call .Append("MAIN.*" & Environment.NewLine)
            Call .Append("FROM" & Environment.NewLine)
            Call .Append("(" & Environment.NewLine)
            Call .Append("SELECT" & Environment.NewLine)
            Call .Append("MAIN.*" & "," & Environment.NewLine)
            Call .Append("SUB_01.KIND_CONTRACT" & "," & Environment.NewLine)
            Call .Append("SUB_01.CODE_OWNER" & "," & Environment.NewLine)
            Call .Append("SUB_01.NAME_CONTRACT" & "," & Environment.NewLine)
            Call .Append("SUB_01.COUNT_INVOICE" & "" & Environment.NewLine)
            Call .Append("FROM" & Environment.NewLine)
            Call .Append("MNT_T_INVOICE AS MAIN WITH(NOLOCK)" & Environment.NewLine)
            Call .Append("INNER JOIN" & Environment.NewLine)
            Call .Append("MNT_T_CONTRACT AS SUB_01 WITH(NOLOCK)" & Environment.NewLine)
            Call .Append("ON" & Environment.NewLine)
            Call .Append("MAIN.NUMBER_CONTRACT=SUB_01.NUMBER_CONTRACT" & Environment.NewLine)
            Call .Append("AND MAIN.SERIAL_CONTRACT=SUB_01.SERIAL_CONTRACT" & Environment.NewLine)
            Call .Append(") AS MAIN" & Environment.NewLine)

            Call .Append("WHERE" & Environment.NewLine)
            Call .Append("1=1" & Environment.NewLine)
            Call .Append(STR_WHERE) 'WHERE条件

            Call .Append("ORDER BY" & Environment.NewLine)
            Call .Append("DATE_INVOICE,CODE_OWNER,NUMBER_CONTRACT,SERIAL_CONTRACT,SERIAL_INVOICE" & Environment.NewLine)
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
            End If
            INT_INDEX += 1
            With SRT_GRID_DATA_MAIN(INT_INDEX)
                .NUMBER_CONTRACT = CInt(SDR_READER.Item("NUMBER_CONTRACT"))
                .SERIAL_CONTRACT = CInt(SDR_READER.Item("SERIAL_CONTRACT"))
                .SERIAL_INVOICE = CInt(SDR_READER.Item("SERIAL_INVOICE"))

                .DATE_INVOICE = CDate(SDR_READER.Item("DATE_INVOICE"))
                .FLAG_DEPOSIT_DONE = CInt(SDR_READER.Item("FLAG_DEPOSIT_DONE"))
                .KINGAKU_INVOICE_DETAIL = CLng(SDR_READER.Item("KINGAKU_INVOICE_DETAIL"))
                .KINGAKU_INVOICE_VAT = CLng(SDR_READER.Item("KINGAKU_INVOICE_VAT"))

                .KIND_CONTRACT = CInt(SDR_READER.Item("KIND_CONTRACT"))
                .CODE_OWNER = CInt(SDR_READER.Item("CODE_OWNER"))
                .NAME_CONTRACT = CStr(SDR_READER.Item("NAME_CONTRACT"))
                .COUNT_INVOICE = CInt(SDR_READER.Item("COUNT_INVOICE"))
            End With
        End While

        ReDim Preserve SRT_GRID_DATA_MAIN(INT_INDEX)
        Call SDR_READER.Close()
        SDR_READER = Nothing

        For i = 1 To (SRT_GRID_DATA_MAIN.Length - 1) '補助情報取得
            Call SUB_GET_AUX_DATA_ONE(SRT_GRID_DATA_MAIN(i))
        Next
    End Sub

    '補助情報取得
    Private Sub SUB_GET_AUX_DATA_ONE(ByRef SRT_DATA As SRT_MY_GRID_DATA)
        With SRT_DATA
            .KIND_CONTRACT_NAME = FUNC_GET_MNT_M_KIND_NAME_KIND(ENM_MNT_M_KIND_CODE_FLAG.KIND_CONTRACT, .KIND_CONTRACT, True)
            .FLAG_DEPOSIT_DONE_NAME = FUNC_GET_MNT_M_KIND_NAME_KIND(ENM_MNT_M_KIND_CODE_FLAG.FLAG_DEPOSIT_DONE, .FLAG_DEPOSIT_DONE, True)

            Select Case .KIND_CONTRACT
                Case ENM_SYSTEM_INDIVIDUAL_KIND_CONTRACT.REGULAR
                    .CODE_OWNER_NAME = FUNC_GET_MNT_M_OWNER_NAME_OWNER(.CODE_OWNER, True)
                Case ENM_SYSTEM_INDIVIDUAL_KIND_CONTRACT.SPOT
                    Dim SRT_RECORD_CONTRACT_SPOT As SRT_TABLE_MNT_T_CONTRACT_SPOT
                    SRT_RECORD_CONTRACT_SPOT.KEY.NUMBER_CONTRACT = .NUMBER_CONTRACT
                    SRT_RECORD_CONTRACT_SPOT.KEY.SERIAL_CONTRACT = .SERIAL_CONTRACT
                    SRT_RECORD_CONTRACT_SPOT.DATA = Nothing
                    Call FUNC_SELECT_TABLE_MNT_T_CONTRACT_SPOT(SRT_RECORD_CONTRACT_SPOT.KEY, SRT_RECORD_CONTRACT_SPOT.DATA, True)
                    .CODE_OWNER_NAME = SRT_RECORD_CONTRACT_SPOT.DATA.NAME_OWNER
                Case Else
                    .CODE_OWNER_NAME = ""
            End Select
        End With
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
                OBJ_TEMP(ENM_MY_GRID_MAIN.DATE_INVOICE) = .DATE_INVOICE.ToLongDateString
                OBJ_TEMP(ENM_MY_GRID_MAIN.KIND_CONTRACT_NAME) = .KIND_CONTRACT_NAME
                OBJ_TEMP(ENM_MY_GRID_MAIN.NUMBER_CONTRACT_VIEW) = .FUNC_GET_NUMBER_SERIAL_CONTRACT
                OBJ_TEMP(ENM_MY_GRID_MAIN.NAME_OWNER) = .CODE_OWNER_NAME
                OBJ_TEMP(ENM_MY_GRID_MAIN.NAME_CONTRACT) = .NAME_CONTRACT
                OBJ_TEMP(ENM_MY_GRID_MAIN.COUNT_INVOICE_VIEW) = .FUNC_GET_COUNT_INVOICE_VIEW
                OBJ_TEMP(ENM_MY_GRID_MAIN.KINGAKU_INVOICE) = Format(.FUNC_GET_KINGAKU_INVOICE_TOTAL, "#,##0")
                OBJ_TEMP(ENM_MY_GRID_MAIN.FLAG_DEPOSIT_DONE_NAME) = .FLAG_DEPOSIT_DONE_NAME
            End With
            Call glbSubAddRowDataTable(TBL_GRID_DATA_MAIN, OBJ_TEMP)
        Next

        Call DGV_VIEW_DATA.Refresh()
        Call System.Windows.Forms.Application.DoEvents()

        Call SUB_SET_SELECT_ROW_INDEX(DGV_VIEW_DATA, 1)
    End Sub
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

#End Region

#Region "画面状態遷移"
    Private Sub SUB_WINDOW_MODE_CHANGE(
    ByVal enmCHANGE_MODE As ENM_MY_WINDOW_MODE
    )
        Dim txtDUMMY As TextBox

        If enmCHANGE_MODE = ENM_WINDOW_MODE_CURRENT Then
            Exit Sub
        End If
        txtDUMMY = Nothing
        Call SUB_ADD_TEXTBOX_AND_MOVE_FOCUS(txtDUMMY, Me)

        Select Case enmCHANGE_MODE
            Case ENM_MY_WINDOW_MODE.INPUT_KEY
                PNL_INPUT_KEY.Enabled = True

                BTN_CLEAR.Enabled = True
                BTN_END.Enabled = True
            Case ENM_MY_WINDOW_MODE.INPUT_DATA
                PNL_INPUT_KEY.Enabled = False

                BTN_CLEAR.Enabled = True
                BTN_END.Enabled = True
            Case Else
                'スルー
        End Select

        Call SUB_REMOVE_TEXTBOX(txtDUMMY, Me)

        ENM_WINDOW_MODE_CURRENT = enmCHANGE_MODE
        Call Application.DoEvents()
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
            Case CTL_ACTIVE Is TXT_CODE_OWNER_FROM
                If Not (CTL_ACTIVE.Text = "") Then
                    If TXT_CODE_OWNER_TO.Text = "" Then
                        TXT_CODE_OWNER_TO.Text = CTL_ACTIVE.Text
                    End If
                End If
                BLN_RET = True
            Case CTL_ACTIVE Is DGV_VIEW_DATA
                Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_SHOW_SUB_WINDOW)
                BLN_RET = False
            Case Else
                BLN_RET = True
        End Select

        CTL_ACTIVE = Nothing

        Return BLN_RET

        Return True
    End Function
#End Region

#Region "内部処理"

    Private Sub SUB_REFRESH_DATA_ONE(ByRef SRT_DATA As SRT_MY_GRID_DATA)
        With SRT_DATA
            Dim SRT_INVOICE As SRT_TABLE_MNT_T_INVOICE
            SRT_INVOICE.KEY.NUMBER_CONTRACT = .NUMBER_CONTRACT
            SRT_INVOICE.KEY.SERIAL_CONTRACT = .SERIAL_CONTRACT
            SRT_INVOICE.KEY.SERIAL_INVOICE = .SERIAL_INVOICE
            SRT_INVOICE.DATA = Nothing
            Call FUNC_SELECT_TABLE_MNT_T_INVOICE(SRT_INVOICE.KEY, SRT_INVOICE.DATA)

            .DATE_INVOICE = SRT_INVOICE.DATA.DATE_INVOICE
            .FLAG_DEPOSIT_DONE = SRT_INVOICE.DATA.FLAG_DEPOSIT_DONE
            .KINGAKU_INVOICE_DETAIL = SRT_INVOICE.DATA.KINGAKU_INVOICE_DETAIL
            .KINGAKU_INVOICE_VAT = SRT_INVOICE.DATA.KINGAKU_INVOICE_VAT
        End With

        Call SUB_GET_AUX_DATA_ONE(SRT_DATA)
    End Sub

    Private Sub SUB_REFRESH_GRID_ROW(ByVal INT_INDEX_SRT As Integer)
        Dim INT_INDEX_GRID As Integer
        INT_INDEX_GRID = (INT_INDEX_SRT - 1)

        With SRT_GRID_DATA_MAIN(INT_INDEX_SRT)
            TBL_GRID_DATA_MAIN.Rows(INT_INDEX_GRID).Item(ENM_MY_GRID_MAIN.DATE_INVOICE) = .DATE_INVOICE.ToLongDateString
            TBL_GRID_DATA_MAIN.Rows(INT_INDEX_GRID).Item(ENM_MY_GRID_MAIN.KIND_CONTRACT_NAME) = .KIND_CONTRACT_NAME
            TBL_GRID_DATA_MAIN.Rows(INT_INDEX_GRID).Item(ENM_MY_GRID_MAIN.NUMBER_CONTRACT_VIEW) = .FUNC_GET_NUMBER_SERIAL_CONTRACT
            TBL_GRID_DATA_MAIN.Rows(INT_INDEX_GRID).Item(ENM_MY_GRID_MAIN.NAME_OWNER) = .CODE_OWNER_NAME
            TBL_GRID_DATA_MAIN.Rows(INT_INDEX_GRID).Item(ENM_MY_GRID_MAIN.NAME_CONTRACT) = .NAME_CONTRACT
            TBL_GRID_DATA_MAIN.Rows(INT_INDEX_GRID).Item(ENM_MY_GRID_MAIN.COUNT_INVOICE_VIEW) = .FUNC_GET_COUNT_INVOICE_VIEW
            TBL_GRID_DATA_MAIN.Rows(INT_INDEX_GRID).Item(ENM_MY_GRID_MAIN.KINGAKU_INVOICE) = Format(.FUNC_GET_KINGAKU_INVOICE_TOTAL, "#,##0")
            TBL_GRID_DATA_MAIN.Rows(INT_INDEX_GRID).Item(ENM_MY_GRID_MAIN.FLAG_DEPOSIT_DONE_NAME) = .FLAG_DEPOSIT_DONE_NAME
        End With

        Call DGV_VIEW_DATA.Refresh()
        Call System.Windows.Forms.Application.DoEvents()
    End Sub

    Private Sub SUB_REFRESH_COUNT(ByVal INT_COUNT As Integer)
        LBL_COUNT_SEARCH_MAX.Visible = False
        LBL_COUNT_SEARCH.Text = Format(INT_COUNT, "#,##0")

        If INT_COUNT >= CST_MY_GRID_COUNT_MAX Then
            LBL_COUNT_SEARCH_MAX.Visible = True
        End If
    End Sub

    Private Function FUNC_GET_SEARCH_CONDITHIONS() As SRT_SEARCH_CONDITIONS
        Dim SRT_RET As SRT_SEARCH_CONDITIONS
        With SRT_RET
            .DATE_INVOICE_FROM = DTP_DATE_INVOICE_FROM.Value
            .DATE_INVOICE_TO = DTP_DATE_INVOICE_TO.Value
            .KIND_CONTRACT = FUNC_GET_COMBO_KIND_CODE(CMB_KIND_CONTRACT)
            .CODE_OWNER_FROM = FUNC_VALUE_CONVERT_NUMERIC_INT(TXT_CODE_OWNER_FROM.Text, CST_SYSTEM_CODE_OWNER_MIN_VALUE)
            .CODE_OWNER_TO = FUNC_VALUE_CONVERT_NUMERIC_INT(TXT_CODE_OWNER_TO.Text, CST_SYSTEM_CODE_OWNER_MAX_VALUE)
            .NAME_OWNER = TXT_NAME_OWNER.Text
            .FLAG_DEPOSIT_DONE = FUNC_GET_COMBO_KIND_CODE(CMB_FLAG_DEPOSIT_DONE)
        End With

        Return SRT_RET
    End Function

    Private Function FUNC_GET_SQL_WHERE(ByVal SRT_CONDITIONS As SRT_SEARCH_CONDITIONS)
        Dim STR_WHERE As String
        STR_WHERE = ""

        With SRT_CONDITIONS
            Dim SRT_INVOICE_PERIOD As SRT_DATE_PERIOD
            SRT_INVOICE_PERIOD.DATE_FROM = SRT_CONDITIONS.DATE_INVOICE_FROM
            SRT_INVOICE_PERIOD.DATE_TO = SRT_CONDITIONS.DATE_INVOICE_TO
            STR_WHERE &= FUNC_GET_SQL_WHERE_DATE_FROM_TO(SRT_INVOICE_PERIOD, "DATE_INVOICE")
            If .KIND_CONTRACT >= 0 Then
                STR_WHERE &= FUNC_GET_SQL_WHERE_INT(.KIND_CONTRACT, "KIND_CONTRACT", "=")
            End If
            STR_WHERE &= FUNC_GET_SQL_WHERE_INT(.CODE_OWNER_FROM, "CODE_OWNER", ">=")
            STR_WHERE &= FUNC_GET_SQL_WHERE_INT(.CODE_OWNER_TO, "CODE_OWNER", "<=")
            If .FLAG_DEPOSIT_DONE >= 0 Then
                STR_WHERE &= FUNC_GET_SQL_WHERE_INT(.FLAG_DEPOSIT_DONE, "FLAG_DEPOSIT_DONE", "=")
            End If
        End With

        Return STR_WHERE
    End Function
#End Region

#Region "その他処理"
    Private Sub SUB_REFRESH_ENABLED_NAME_OWNER()
        Dim ENM_KIND_CONTRACT As ENM_SYSTEM_INDIVIDUAL_KIND_CONTRACT
        ENM_KIND_CONTRACT = FUNC_GET_COMBO_KIND_CODE(CMB_KIND_CONTRACT)
        Dim BLN_ENABLED As Boolean
        If ENM_KIND_CONTRACT = ENM_SYSTEM_INDIVIDUAL_KIND_CONTRACT.SPOT Then
            BLN_ENABLED = True
        Else
            BLN_ENABLED = False
        End If

        PNL_NAME_OWNER.Enabled = BLN_ENABLED
    End Sub
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
    Private Sub BTN_CLEAR_Click(sender As Object, e As EventArgs) Handles BTN_CLEAR.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_CLEAR)
    End Sub

    Private Sub BTN_END_Click(sender As Object, e As EventArgs) Handles BTN_END.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_END)
    End Sub

    Private Sub BTN_CODE_OWNER_FROM_SEARCH_Click(sender As Object, e As EventArgs) Handles BTN_CODE_OWNER_FROM_SEARCH.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_SHOW_SEARCH)
    End Sub

    Private Sub BTN_CODE_OWNER_TO_SEARCH_Click(sender As Object, e As EventArgs) Handles BTN_CODE_OWNER_TO_SEARCH.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_SHOW_SEARCH)
    End Sub
#End Region

#Region "イベント-テキストチェンジ"
    Private Sub TXT_CODE_OWNER_FROM_TextChanged(sender As Object, e As EventArgs) Handles TXT_CODE_OWNER_FROM.TextChanged
        Call SUB_GET_NAME_OWNER_INPUT(sender)
    End Sub

    Private Sub TXT_CODE_OWNER_TO_TextChanged(sender As Object, e As EventArgs) Handles TXT_CODE_OWNER_TO.TextChanged
        Call SUB_GET_NAME_OWNER_INPUT(sender)
    End Sub
#End Region

#Region "イベント-セレクトインデックスチェンジ"
    Private Sub CMB_KIND_CONTRACT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_KIND_CONTRACT.SelectedIndexChanged
        Call SUB_REFRESH_ENABLED_NAME_OWNER()
    End Sub
#End Region

#Region "イベント-グリッドダブルクリック"
    Private Sub DGV_VIEW_DATA_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_VIEW_DATA.CellDoubleClick
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_SHOW_SUB_WINDOW)
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
