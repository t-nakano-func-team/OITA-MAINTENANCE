﻿Public Class FRM_MAIN

#Region "画面用・列挙定数"
    Private Enum ENM_MY_EXEC_DO
        DO_SHOW_SEARCH = 1
        DO_SELECT_SEQ
        DO_DATA_EDIT
        DO_ENTER
        DO_DELETE
        DO_PREVIEW
        DO_PRINT
        DO_PUT_FILE
        DO_CLEAR
        DO_END = 81
        DO_SHOW_SETTING
        DO_SHOW_COMMANDLINE
        DO_SHOW_CONFIG_SETTINGS
    End Enum

    Private Enum ENM_MY_WINDOW_MODE
        INPUT_KEY = 1
        INPUT_DATA_INSERT
        INPUT_DATA_UPDATE
    End Enum

    Private Enum ENM_MY_GRID_MAIN
        KIND_ACCOUNT_NAME
        CODE_KIND
        NAME_ACCOUNT
        CODE_ACCOUNT
        UBOUND = CODE_ACCOUNT
    End Enum
#End Region

#Region "画面用・構造体"
    Private Structure SRT_MY_GRID_DATA
        Public KIND_ACCOUNT As Integer
        Public CODE_KIND As Integer
        Public NAME_ACCOUNT As String
        Public CODE_ACCOUNT As Integer

        Public KIND_ACCOUNT_NAME As String
    End Structure

    Public Structure SRT_SEARCH_CONDITIONS '検索条件
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
        Call glbSubMakeDataTable(TBL_GRID_DATA_MAIN, "科目種別,種別コード,科目名称,科目コード", "SSSS")
        DGV_VIEW_DATA.DataSource = TBL_GRID_DATA_MAIN
        Call SUB_DGV_COLUMN_WIDTH_INIT_COUNT_FONT(DGV_VIEW_DATA, "4,4,9,4", "LRLR")

        Call SUB_SYSTEM_COMMBO_MNT_M_KIND(CMB_KIND_ACCOUNT, ENM_MNT_M_KIND_CODE_FLAG.KIND_ACCOUNT)
    End Sub

    Private Sub SUB_CTRL_VALUE_INIT()
        Call SUB_CONTROL_CLEAR_FORM(Me)

        Call SUB_SET_COMBO_KIND_CODE_FIRST(CMB_KIND_ACCOUNT)

        Dim SRT_CONDITIONS As SRT_SEARCH_CONDITIONS 'グリッド条件
        SRT_CONDITIONS = Nothing '条件の取得（項目がない為、クリア）
        Call SUB_MAKE_GRID_DATA(SRT_CONDITIONS) 'グリッド構造体を作成
        Call SUB_REFRESH_GRID() 'グリッドの表示をリフレッシュ

        LBL_NAME_USER_HEAD.Text = FUNC_GET_MNG_M_USER_NAME_STAFF(srtSYSTEM_TOTAL_COMMANDLINE.CODE_STAFF)
        LBL_DATE_ACTIVE_HEAD.Text = Format(datSYSTEM_TOTAL_DATE_ACTIVE, "yyyy年MM月dd日")
    End Sub
#End Region

#Region "各処理呼出元"
    Private Sub SUB_EXEC_DO(
    ByVal ENM_EXEC_DO As ENM_MY_EXEC_DO
    )
        If BLN_PROCESS_DOING Then
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        BLN_PROCESS_DOING = True
        Call Application.DoEvents()

        '実処理を呼出
        Select Case ENM_EXEC_DO
            Case ENM_MY_EXEC_DO.DO_SELECT_SEQ
                Call SUB_SELECT_SEQ()
            Case ENM_MY_EXEC_DO.DO_DATA_EDIT
                Call SUB_DATA_EDIT()
            Case ENM_MY_EXEC_DO.DO_ENTER
                Call SUB_ENTER()
            Case ENM_MY_EXEC_DO.DO_DELETE
                Call SUB_DELETE()
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
    'グリッド行選択処理
    Private Sub SUB_SELECT_SEQ()

        Dim SRT_KEY As SRT_TABLE_MNT_M_ACCOUNT_KEY
        SRT_KEY = FUNC_GET_SELECT_RET_CODE()
        If SRT_KEY.KIND_ACCOUNT <= 0 Then
            Exit Sub
        End If
        If SRT_KEY.CODE_KIND <= 0 Then
            Exit Sub
        End If

        Call SUB_CLEAR()

        With SRT_KEY
            Call SUB_SET_COMBO_KIND_CODE(CMB_KIND_ACCOUNT, .KIND_ACCOUNT)
            TXT_CODE_KIND.Text = .CODE_KIND
        End With

        Call TXT_CODE_KIND.Focus()
        Call Application.DoEvents()

        Call SUB_DATA_EDIT()
    End Sub

    'データ入力モードへ変更
    Private Sub SUB_DATA_EDIT()

        If Not FUNC_CHECK_INPUT_KEY() Then
            Exit Sub
        End If

        Dim SRT_KEY As SRT_TABLE_MNT_M_ACCOUNT_KEY
        SRT_KEY = FUNC_GET_INPUT_KEY()

        Dim BLN_CHECK As Boolean
        BLN_CHECK = FUNC_CHECK_TABLE_MNT_M_ACCOUNT(SRT_KEY)

        Dim ENM_CHANGE_MODE As ENM_MY_WINDOW_MODE
        If BLN_CHECK Then
            Dim SRT_DATA As SRT_TABLE_MNT_M_ACCOUNT_DATA
            SRT_DATA = Nothing
            Call FUNC_SELECT_TABLE_MNT_M_ACCOUNT(SRT_KEY, SRT_DATA)
            Call SUB_SET_INPUT_DATA(SRT_DATA)
            ENM_CHANGE_MODE = ENM_MY_WINDOW_MODE.INPUT_DATA_UPDATE '更新
        Else
            ENM_CHANGE_MODE = ENM_MY_WINDOW_MODE.INPUT_DATA_INSERT '新規追加
        End If

        Call SUB_WINDOW_MODE_CHANGE(ENM_CHANGE_MODE)
        Call SUB_FOCUS_FIRST_INPUT_CONTROL(Me.PNL_INPUT_DATA)
    End Sub

    '登録
    Private Sub SUB_ENTER()
        If Not FUNC_CHECK_INPUT_DATA() Then
            Exit Sub
        End If

        Dim RST_MSG As System.Windows.Forms.DialogResult
        RST_MSG = MessageBox.Show("データを登録します。" & Environment.NewLine & "よろしいですか？", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If RST_MSG = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        Dim SRT_RECORD As SRT_TABLE_MNT_M_ACCOUNT
        SRT_RECORD.KEY = FUNC_GET_INPUT_KEY()
        SRT_RECORD.DATA = FUNC_GET_INPUT_DATA()

        If Not FUNC_SYSTEM_BEGIN_TRANSACTION() Then
            Call MessageBox.Show(FUNC_SYSTEM_SQLGET_ERR_MESSAGE(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Not FUNC_EDIT_RECORD(SRT_RECORD) Then
            Call MessageBox.Show(STR_FUNC_EDIT_RECORD_LAST_ERROR, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Call FUNC_SYSTEM_ROLLBACK_TRANSACTION()
            Exit Sub
        End If

        If Not FUNC_SYSTEM_COMMIT_TRANSACTION() Then
            Call MessageBox.Show(FUNC_SYSTEM_SQLGET_ERR_MESSAGE(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Call SUB_CLEAR()
    End Sub

    '削除
    Private Sub SUB_DELETE()
        Dim RST_MSG As System.Windows.Forms.DialogResult
        RST_MSG = MessageBox.Show("データを削除します。" & Environment.NewLine & "よろしいですか？", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If RST_MSG = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        Dim SRT_KEY As SRT_TABLE_MNT_M_ACCOUNT_KEY
        SRT_KEY = FUNC_GET_INPUT_KEY()

        If Not FUNC_SYSTEM_BEGIN_TRANSACTION() Then
            Call MessageBox.Show(FUNC_SYSTEM_SQLGET_ERR_MESSAGE(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        '物理削除
        If Not FUNC_DELETE_TABLE_MNT_M_ACCOUNT(SRT_KEY) Then
            Call MessageBox.Show(FUNC_SYSTEM_SQLGET_ERR_MESSAGE(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Call FUNC_SYSTEM_ROLLBACK_TRANSACTION()
            Exit Sub
        End If

        If Not FUNC_SYSTEM_COMMIT_TRANSACTION() Then
            Call MessageBox.Show(FUNC_SYSTEM_SQLGET_ERR_MESSAGE(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Call SUB_CLEAR()
    End Sub

    Private STR_FUNC_EDIT_RECORD_LAST_ERROR As String
    Private Function FUNC_EDIT_RECORD(ByRef SRT_RECORD As SRT_TABLE_MNT_M_ACCOUNT) As Boolean

        If Not FUNC_DELETE_TABLE_MNT_M_ACCOUNT(SRT_RECORD.KEY) Then
            STR_FUNC_EDIT_RECORD_LAST_ERROR = FUNC_SYSTEM_SQLGET_ERR_MESSAGE()
            Return False
        End If

        If Not FUNC_INSERT_TABLE_MNT_M_ACCOUNT(SRT_RECORD) Then
            STR_FUNC_EDIT_RECORD_LAST_ERROR = FUNC_SYSTEM_SQLGET_ERR_MESSAGE()
            Return False
        End If

        Return True
    End Function

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

#End Region

#Region "グリッド関連"
    'グリッド用構造体を作成
    Private Sub SUB_MAKE_GRID_DATA(ByVal SRT_CONDITIONS As SRT_SEARCH_CONDITIONS)
        Dim STR_SQL As System.Text.StringBuilder
        Dim SDR_READER As SqlClient.SqlDataReader
        Dim STR_WHERE As String
        ReDim SRT_GRID_DATA_MAIN(0)

        '検索条件からWHERE条件取得
        STR_WHERE = FUNC_GET_SQL_WHERE(SRT_CONDITIONS)

        STR_SQL = New System.Text.StringBuilder
        With STR_SQL
            Call .Append("SELECT" & Environment.NewLine)
            Call .Append("*" & Environment.NewLine)
            Call .Append("FROM" & Environment.NewLine)
            Call .Append("MNT_M_ACCOUNT WITH(NOLOCK)" & Environment.NewLine)
            Call .Append("WHERE" & Environment.NewLine)
            Call .Append("1=1" & Environment.NewLine)
            Call .Append(STR_WHERE) 'WHERE条件
            Call .Append("ORDER BY" & Environment.NewLine)
            Call .Append("KIND_ACCOUNT,CODE_KIND" & Environment.NewLine)
        End With

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

        ReDim SRT_GRID_DATA_MAIN(0)
        While SDR_READER.Read
            Dim INT_INDEX As Integer
            INT_INDEX = SRT_GRID_DATA_MAIN.Length
            ReDim Preserve SRT_GRID_DATA_MAIN(INT_INDEX)
            With SRT_GRID_DATA_MAIN(INT_INDEX)
                .KIND_ACCOUNT = CInt(SDR_READER.Item("KIND_ACCOUNT"))
                .CODE_KIND = CInt(SDR_READER.Item("CODE_KIND"))
                .NAME_ACCOUNT = CStr(SDR_READER.Item("NAME_ACCOUNT"))
                .CODE_ACCOUNT = CInt(SDR_READER.Item("CODE_ACCOUNT"))
            End With
        End While
        Call SDR_READER.Close()
        SDR_READER = Nothing

        For i = 1 To (SRT_GRID_DATA_MAIN.Length - 1) '補助情報取得
            With SRT_GRID_DATA_MAIN(i)
                .KIND_ACCOUNT_NAME = FUNC_GET_MNT_M_KIND_NAME_KIND(ENM_MNT_M_KIND_CODE_FLAG.KIND_ACCOUNT, .KIND_ACCOUNT)
            End With
        Next

    End Sub

    'グリッド表示をリフレッシュ
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
                OBJ_TEMP(ENM_MY_GRID_MAIN.KIND_ACCOUNT_NAME) = .KIND_ACCOUNT_NAME
                OBJ_TEMP(ENM_MY_GRID_MAIN.CODE_KIND) = Format(.CODE_KIND, New String("0", INT_SYSTEM_CODE_KIND_MAX_LENGTH))
                OBJ_TEMP(ENM_MY_GRID_MAIN.NAME_ACCOUNT) = .NAME_ACCOUNT
                OBJ_TEMP(ENM_MY_GRID_MAIN.CODE_ACCOUNT) = Format(.CODE_ACCOUNT, New String("0", INT_SYSTEM_CODE_ACCOUNT_MAX_LENGTH))
            End With
            Call glbSubAddRowDataTable(TBL_GRID_DATA_MAIN, OBJ_TEMP)
        Next

        Call DGV_VIEW_DATA.Refresh()
        Call System.Windows.Forms.Application.DoEvents()

        Call SUB_SET_SELECT_ROW_INDEX(DGV_VIEW_DATA, 0)
    End Sub

    'グリッドの選択されているキー項目を取得
    Private Function FUNC_GET_SELECT_RET_CODE() As SRT_TABLE_MNT_M_ACCOUNT_KEY
        Dim INT_SELECT_ROW_INDEX As Integer
        INT_SELECT_ROW_INDEX = FUNC_GET_SELECT_ROW_INDEX(DGV_VIEW_DATA)

        Dim SRT_RET As SRT_TABLE_MNT_M_ACCOUNT_KEY
        With SRT_RET
            .KIND_ACCOUNT = -1
            .CODE_KIND = -1
        End With

        If INT_SELECT_ROW_INDEX <= 0 Then
            Return SRT_RET
        End If

        Dim INT_SRT_INDEX As Integer

        INT_SRT_INDEX = INT_SELECT_ROW_INDEX
        With SRT_GRID_DATA_MAIN(INT_SRT_INDEX)
            SRT_RET.KIND_ACCOUNT = FUNC_VALUE_CONVERT_NUMERIC_INT(.KIND_ACCOUNT)
            SRT_RET.CODE_KIND = FUNC_VALUE_CONVERT_NUMERIC_INT(.CODE_KIND)
        End With
        Return SRT_RET
    End Function
#End Region

#Region "画面状態遷移"
    Private Sub SUB_WINDOW_MODE_CHANGE(
    ByVal enmCHANGE_MODE As ENM_MY_WINDOW_MODE
    )

        If enmCHANGE_MODE = ENM_WINDOW_MODE_CURRENT Then
            Exit Sub
        End If

        Dim TXT_DUMMY As TextBox
        TXT_DUMMY = Nothing
        Call SUB_ADD_TEXTBOX_AND_MOVE_FOCUS(TXT_DUMMY, Me)

        Select Case enmCHANGE_MODE
            Case ENM_MY_WINDOW_MODE.INPUT_KEY
                PNL_INPUT_KEY.Enabled = True
                PNL_INPUT_DATA.Enabled = False

                BTN_ENTER.Enabled = False
                BTN_DELETE.Enabled = False
                BTN_PREVIEW.Enabled = True
                BTN_PRINT.Enabled = True
                BTN_PUT_FILE.Enabled = True
                BTN_CLEAR.Enabled = True
                BTN_END.Enabled = True
            Case ENM_MY_WINDOW_MODE.INPUT_DATA_INSERT
                PNL_INPUT_KEY.Enabled = False
                PNL_INPUT_DATA.Enabled = True

                BTN_ENTER.Enabled = True
                BTN_DELETE.Enabled = False
                BTN_PREVIEW.Enabled = True
                BTN_PRINT.Enabled = True
                BTN_PUT_FILE.Enabled = True
                BTN_CLEAR.Enabled = True
                BTN_END.Enabled = True
            Case ENM_MY_WINDOW_MODE.INPUT_DATA_UPDATE
                PNL_INPUT_KEY.Enabled = False
                PNL_INPUT_DATA.Enabled = True

                BTN_ENTER.Enabled = True
                BTN_DELETE.Enabled = True
                BTN_PREVIEW.Enabled = True
                BTN_PRINT.Enabled = True
                BTN_PUT_FILE.Enabled = True
                BTN_CLEAR.Enabled = True
                BTN_END.Enabled = True
            Case Else
                'スルー
        End Select

        Call SUB_REMOVE_TEXTBOX(TXT_DUMMY, Me)

        ENM_WINDOW_MODE_CURRENT = enmCHANGE_MODE
        Call Application.DoEvents()
    End Sub
#End Region

#Region "画面コントロール←→構造体"
    Private Function FUNC_GET_INPUT_KEY() As SRT_TABLE_MNT_M_ACCOUNT_KEY
        Dim SRT_RET As SRT_TABLE_MNT_M_ACCOUNT_KEY

        With SRT_RET
            .KIND_ACCOUNT = FUNC_GET_COMBO_KIND_CODE(CMB_KIND_ACCOUNT)
            .CODE_KIND = CInt(TXT_CODE_KIND.Text)
        End With

        Return SRT_RET
    End Function

    Private Function FUNC_GET_INPUT_DATA() As SRT_TABLE_MNT_M_ACCOUNT_DATA
        Dim SRT_RET As SRT_TABLE_MNT_M_ACCOUNT_DATA

        With SRT_RET
            .NAME_ACCOUNT = CStr(TXT_NAME_ACCOUNT.Text)
            .CODE_ACCOUNT = CInt(TXT_CODE_ACCOUNT.Text)
            .FLAG_INVALID = ENM_SYSTEM_INDIVIDUAL_FLAG_INVALID.NORMAL
        End With

        Return SRT_RET
    End Function


    Private Sub SUB_SET_INPUT_DATA(ByRef SRT_DATA As SRT_TABLE_MNT_M_ACCOUNT_DATA)
        With SRT_DATA
            TXT_NAME_ACCOUNT.Text = .NAME_ACCOUNT
            TXT_CODE_ACCOUNT.Text = Format(.CODE_ACCOUNT, New String("0", INT_SYSTEM_CODE_ACCOUNT_MAX_LENGTH))
            LBL_FLAG_INVALID.Text = FUNC_GET_MNT_M_KIND_NAME_KIND(ENM_MNT_M_KIND_CODE_FLAG.FLAG_INVALID, .FLAG_INVALID)
        End With
    End Sub
#End Region

#Region "チェック処理"
    'キー部のチェック処理
    Private Function FUNC_CHECK_INPUT_KEY() As Boolean
        Dim CTL_CONTROL As Control
        Dim ENM_ERR_CODE As CONTROL_CHECK_ERR_CODE
        Dim STR_ERR_MSG As String

        'Enable = True の入力項目すべてチェック対象(TAG=Check)
        CTL_CONTROL = Nothing
        If Not FUNC_CONTROL_CHECK_INPUT_FORM_CONTROLS(PNL_INPUT_KEY, CTL_CONTROL, ENM_ERR_CODE, "Check") Then
            STR_ERR_MSG = FUNC_GET_MESSAGE_CTRL_CHECK(ENM_ERR_CODE, FUNC_GET_TEXT_GUIDE_LABEL(CTL_CONTROL))
            Call MessageBox.Show(STR_ERR_MSG, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Call CTL_CONTROL.Focus()
            Return False
        End If

        Return True
    End Function

    'データ部のチェック処理
    Private Function FUNC_CHECK_INPUT_DATA() As Boolean
        Dim CTL_CONTROL As Control
        Dim ENM_ERR_CODE As CONTROL_CHECK_ERR_CODE
        Dim STR_ERR_MSG As String

        'Enable = True の入力項目すべてチェック対象(TAG=Check)
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

#Region "キー制御処理"
    '通常のコマンドキー制御(シフトマスク無し)
    Private Sub SUB_KEY_DOWN(ByVal ENM_KEY_CODE As Windows.Forms.Keys, ByRef blnHandled As Boolean)
        Select Case ENM_KEY_CODE
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
    Private Sub SUB_KEY_DOWN_CTRL(ByVal ENM_KEY_CODE As Windows.Forms.Keys, ByRef blnHandled As Boolean)
        Select Case ENM_KEY_CODE
            Case Keys.F
                Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_SHOW_SEARCH)
            Case Else
                'スルー
        End Select
    End Sub

    '通常のコマンドキー制御(ALT)
    Private Sub SUB_KEY_DOWN_ALT(ByVal ENM_KEY_CODE As Windows.Forms.Keys, ByRef blnHandled As Boolean)
        Select Case ENM_KEY_CODE
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
        If IsNothing(Me.ActiveControl) Then
            Return False
        End If

        Dim CTL_ACTIVE As Control
        CTL_ACTIVE = Me.ActiveControl

        Dim BLN_RET As Boolean
        Select Case True
            Case (CTL_ACTIVE Is TXT_CODE_KIND)
                Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_DATA_EDIT)
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
    '検索条件を取得
    Private Function FUNC_GET_SEARCH_CONDITHIONS() As SRT_SEARCH_CONDITIONS
        Dim SRT_CONDITIONS As SRT_SEARCH_CONDITIONS
        With SRT_CONDITIONS
            '条件なし
        End With

        Return SRT_CONDITIONS
    End Function

    '検索条件からWHERE句を作成
    Private Function FUNC_GET_SQL_WHERE(ByVal SRT_CONDITIONS As SRT_SEARCH_CONDITIONS)
        Dim STR_WHERE As String
        STR_WHERE = ""

        With SRT_CONDITIONS
            '条件なし
        End With

        Return STR_WHERE
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
    Private Sub BTN_ENTER_Click(sender As Object, e As EventArgs) Handles BTN_ENTER.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_ENTER)
    End Sub

    Private Sub BTN_DELETE_Click(sender As Object, e As EventArgs) Handles BTN_DELETE.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_DELETE)
    End Sub

    Private Sub BTN_PREVIEW_Click_1(sender As Object, e As EventArgs) Handles BTN_PREVIEW.Click
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

#Region "イベント-グリッドダブルクリック"
    Private Sub DGV_VIEW_DATA_DoubleClick(sender As Object, e As EventArgs) Handles DGV_VIEW_DATA.DoubleClick
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_SELECT_SEQ)
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
        Call SUB_LIST_PREVIEW_WINDOW_CLOSE_ALL()
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
