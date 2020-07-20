Public Class FRM_SYSTEM_INDIVIDUAL_SEARCH_OWNER

#Region "画面用・定数"
    Private Const CST_MY_GRID_COUNT_MAX As Integer = 1000
#End Region

#Region "画面用・列挙定数"
    Private Enum ENM_MY_EXEC_DO
        DO_SEARCH = 1
        DO_OK
        DO_CANCEL
        DO_CLEAR
    End Enum

    Private Enum ENM_MY_GRID_MAIN
        CODE_OWNER = 0
        NAME_OWNER
        KANA_OWNER
        UBOUND = KANA_OWNER
    End Enum

    Private Enum ENM_MY_WINDOW_MODE
        INPUT_KEY = 1
        VIEW_DATA
    End Enum
#End Region

#Region "画面用・構造体"
    Private Structure SRT_MY_GRID_DATA
        Public CODE_OWNER As Integer
        Public NAME_OWNER As String
        Public KANA_OWNER As String
        Public KIND_OWNER As Integer

    End Structure

    Public Structure SRT_SEARCH_CONDITIONS '検索条件
        Public NAME_OWNER As String
        Public KANA_OWNER As String
        Public KIND_OWNER As Integer
    End Structure
#End Region

#Region "画面用・変数"
    Private blnPROCESS_DOING As Boolean
    Private enmWINDOW_MODE_CURRENT As ENM_MY_WINDOW_MODE '現在の画面状態
    Private tblGRID_DATA_MAIN As DataTable
    Private SRT_GRID_DATA_MAIN() As SRT_MY_GRID_DATA
#End Region

#Region "プロパティ用"
    Private BLN_PROPERTY_SEARCH_CANCEL As Boolean 'キャンセルフラグ(True:キャンセル / False:決定)
    Private INT_PROPERTY_RET_CODE As Integer '返却コード
#End Region

#Region "プロパティ"
    '返却コード
    Friend Property RET_CODE() As Integer
        Get
            Return INT_PROPERTY_RET_CODE
        End Get
        Set(ByVal Value As Integer)
            INT_PROPERTY_RET_CODE = Value
        End Set
    End Property

    'キャンセルフラグ
    Friend Property RET_SEARCH_CANCEL() As Boolean
        Get
            Return BLN_PROPERTY_SEARCH_CANCEL
        End Get
        Set(ByVal Value As Boolean)
            BLN_PROPERTY_SEARCH_CANCEL = Value
        End Set
    End Property

#End Region

#Region "各処理呼出元"

    Private Sub SUB_EXEC_DO(
    ByVal enmEXEC_DO As ENM_MY_EXEC_DO
    )
        If blnPROCESS_DOING Then
            Exit Sub
        End If

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        blnPROCESS_DOING = True
        Call System.Windows.Forms.Application.DoEvents()

        Select Case enmEXEC_DO
            Case ENM_MY_EXEC_DO.DO_SEARCH
                Call SUB_SEARCH()
            Case ENM_MY_EXEC_DO.DO_OK
                Call SUB_OK()
            Case ENM_MY_EXEC_DO.DO_CANCEL
                Call SUB_CANCEL()
            Case ENM_MY_EXEC_DO.DO_CLEAR
                Call SUB_CLEAR()
        End Select

        Call System.Windows.Forms.Application.DoEvents()
        blnPROCESS_DOING = False
        Me.Cursor = System.Windows.Forms.Cursors.Default
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

        Dim STR_ERR_MSG As String
        Dim INT_COUNT As Integer
        INT_COUNT = UBound(SRT_GRID_DATA_MAIN)
        Call SUB_REFRESH_COUNT(INT_COUNT)
        If INT_COUNT <= 0 Then
            Call SUB_REFRESH_GRID()
            STR_ERR_MSG = "対象データがありません。"
            Call System.Windows.Forms.MessageBox.Show(STR_ERR_MSG, Me.Text, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information)
            Call SUB_FOCUS_FIRST_INPUT_CONTROL(PNL_INPUT_KEY)
            Exit Sub
        End If

        Call SUB_WINDOW_MODE_CHANGE(ENM_MY_WINDOW_MODE.VIEW_DATA)

        Call SUB_REFRESH_GRID()
    End Sub

    Private Sub SUB_OK()
        Call SUB_ROW_SELECT()
        If Me.RET_CODE <= 0 Then '未選択の場合
            Call MessageBox.Show("対象を選択してください。", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Me.RET_SEARCH_CANCEL = False
        Call Me.Close()
    End Sub

    Private Sub SUB_CANCEL()

        Me.RET_SEARCH_CANCEL = True
        Call Me.Close()
    End Sub

    Private Sub SUB_CLEAR()
        Call SUB_CONTROL_CLEAR_FORM(Me)
        Call SUB_CTRL_VALUE_INIT() '値を初期化

        Call SUB_WINDOW_MODE_CHANGE(ENM_MY_WINDOW_MODE.INPUT_KEY)
        Call SUB_FOCUS_FIRST_INPUT_CONTROL(Me)
    End Sub

    Private Sub SUB_ROW_SELECT()
        Dim intRET_CODE As Integer

        intRET_CODE = FUNC_GET_SELECT_RET_CODE()
        Me.RET_CODE = intRET_CODE
    End Sub
#End Region

#Region "初期化・終了処理"
    Private Sub SUB_CTRL_NEW_INIT()
        Call SUB_CTRL_EVENT_HANDLED_ADD()
    End Sub

    Private Sub SUB_CTRL_DISPOSED_FIN() '画面破棄時の追記処理(Dispose時)
        Call SUB_CTRL_EVENT_HANDLED_REMOVE() 'コントロール共通イベント削除
    End Sub

    Private Sub SUB_CTRL_VIEW_INIT()

        Call SUB_SYSTEM_COMMBO_MNT_M_KIND(CMB_KIND_OWNER, ENM_MNT_M_KIND_CODE_FLAG.KIND_OWNER, True, "全て")

        Call glbSubMakeDataTable(tblGRID_DATA_MAIN, "オーナーコード,オーナー名称,カナ名称", "SSS")
        DGV_VIEW_DATA.DataSource = tblGRID_DATA_MAIN
        Call SUB_DGV_COLUMN_WIDTH_INIT_COUNT_FONT(DGV_VIEW_DATA, "5,10,10", "RLL")

        Me.RET_SEARCH_CANCEL = True 'プロパティ初期化
    End Sub

    Private Sub SUB_CTRL_VALUE_INIT()
        Call SUB_CONTROL_CLEAR_FORM(Me)

        Call SUB_SET_COMBO_KIND_CODE_FIRST(CMB_KIND_OWNER)

        ReDim SRT_GRID_DATA_MAIN(0)
        Call SUB_REFRESH_GRID()

        LBL_NAME_USER_HEAD.Text = FUNC_GET_MNG_M_USER_NAME_STAFF(srtSYSTEM_TOTAL_COMMANDLINE.CODE_STAFF)
        LBL_DATE_ACTIVE_HEAD.Text = Format(datSYSTEM_TOTAL_DATE_ACTIVE, "yyyy年MM月dd日")
    End Sub
#End Region

#Region "画面状態遷移"
    Private Sub SUB_WINDOW_MODE_CHANGE(
    ByVal ENM_CHANGE_MODE As ENM_MY_WINDOW_MODE
    )

        If ENM_CHANGE_MODE = enmWINDOW_MODE_CURRENT Then
            Exit Sub
        End If

        Dim TXT_DUMMY As System.Windows.Forms.TextBox
        TXT_DUMMY = Nothing
        Call SUB_ADD_TEXTBOX_AND_MOVE_FOCUS(TXT_DUMMY, Me)

        Select Case ENM_CHANGE_MODE
            Case ENM_MY_WINDOW_MODE.INPUT_KEY
                PNL_INPUT_KEY.Enabled = True
                BTN_OK.Enabled = True
                BTN_CANCEL.Enabled = True
                BTN_CLEAR.Enabled = True
            Case ENM_MY_WINDOW_MODE.VIEW_DATA
                PNL_INPUT_KEY.Enabled = True
                BTN_OK.Enabled = True
                BTN_CANCEL.Enabled = True
                BTN_CLEAR.Enabled = True
            Case Else
                'スルー
        End Select

        Call SUB_REMOVE_TEXTBOX(TXT_DUMMY, Me)

        enmWINDOW_MODE_CURRENT = ENM_CHANGE_MODE
        Call System.Windows.Forms.Application.DoEvents()
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
            Call .Append("MNT_M_OWNER WITH(NOLOCK)" & Environment.NewLine)
            Call .Append("WHERE" & Environment.NewLine)
            Call .Append("1=1" & Environment.NewLine)
            Call .Append(STR_WHERE) 'WHERE条件
            Call .Append("ORDER BY" & Environment.NewLine)
            Call .Append("CODE_OWNER" & Environment.NewLine)
        End With

        Call SUB_TIME_MEASUREMEN_START()
        Dim SDR_READER As SqlClient.SqlDataReader
        SDR_READER = Nothing
        If Not FUNC_SYSTEM_GET_SQL_DATA_READER(STR_SQL.ToString, SDR_READER) Then
            SDR_READER = Nothing
            Exit Sub
        End If
        Call SUB_TIME_MEASUREMENT_STOP_AND_PUT_LOG(Me.Text & ":" & "クエリ実行")

        If Not SDR_READER.HasRows Then
            Call SDR_READER.Close()
            SDR_READER = Nothing
            Exit Sub
        End If

        Call SUB_TIME_MEASUREMEN_START()
        ReDim SRT_GRID_DATA_MAIN(CST_MY_GRID_COUNT_MAX)
        Dim INT_INDEX As Integer
        INT_INDEX = 0
        While SDR_READER.Read
            If INT_INDEX >= (SRT_GRID_DATA_MAIN.Length - 1) Then
                Exit While
            End If
            INT_INDEX += 1
            With SRT_GRID_DATA_MAIN(INT_INDEX)
                .CODE_OWNER = CInt(SDR_READER.Item("CODE_OWNER"))
                .NAME_OWNER = CStr(SDR_READER.Item("NAME_OWNER"))
                .KANA_OWNER = CStr(SDR_READER.Item("KANA_OWNER"))
                .KIND_OWNER = CInt(SDR_READER.Item("KIND_OWNER"))
            End With
        End While
        ReDim Preserve SRT_GRID_DATA_MAIN(INT_INDEX)
        Call SDR_READER.Close()
        SDR_READER = Nothing
        Call SUB_TIME_MEASUREMENT_STOP_AND_PUT_LOG(Me.Text & ":" & "ITEM取得")

        Call SUB_TIME_MEASUREMEN_START()
        For i = 1 To (SRT_GRID_DATA_MAIN.Length - 1) '補助情報取得
            With SRT_GRID_DATA_MAIN(i)
            End With
        Next
        Call SUB_TIME_MEASUREMENT_STOP_AND_PUT_LOG(Me.Text & ":" & "補助情報取得")
    End Sub

    Private Sub SUB_REFRESH_GRID()


        Call tblGRID_DATA_MAIN.Clear()

        Dim INT_MAX_INDEX As Integer
        INT_MAX_INDEX = (SRT_GRID_DATA_MAIN.Length - 1)

        If INT_MAX_INDEX <= 0 Then
            Exit Sub
        End If

        For intLOOP_INDEX = 1 To INT_MAX_INDEX
            Dim OBJ_TEMP(ENM_MY_GRID_MAIN.UBOUND) As Object
            With SRT_GRID_DATA_MAIN(intLOOP_INDEX)
                OBJ_TEMP(ENM_MY_GRID_MAIN.CODE_OWNER) = Format(.CODE_OWNER, New String("0", INT_SYSTEM_CODE_OWNER_MAX_LENGTH))
                OBJ_TEMP(ENM_MY_GRID_MAIN.NAME_OWNER) = .NAME_OWNER
                OBJ_TEMP(ENM_MY_GRID_MAIN.KANA_OWNER) = .KANA_OWNER
            End With
            Call glbSubAddRowDataTable(tblGRID_DATA_MAIN, OBJ_TEMP)
        Next

        Call DGV_VIEW_DATA.Refresh()
        Call System.Windows.Forms.Application.DoEvents()

        Call SUB_SET_SELECT_ROW_INDEX(DGV_VIEW_DATA, 0)

    End Sub
#End Region

#Region "チェック処理"
    Private Function FUNC_CHECK_INPUT_KEY() As Boolean
        'Enable = True の入力項目すべてチェック対象(TAG=Check_Head)
        Dim CTL_CONTROL As Control
        CTL_CONTROL = Nothing

        Dim ENM_ERR_CODE As CONTROL_CHECK_ERR_CODE
        Dim STR_ERR_MSG As String
        If Not FUNC_CONTROL_CHECK_INPUT_FORM_CONTROLS(PNL_INPUT_KEY, CTL_CONTROL, ENM_ERR_CODE, "Check") Then
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

    Private Function FUNC_RETURN_KEYDOWN() As Boolean
        Dim ctlACTIVE As Control
        Dim blnRET As Boolean

        If IsNothing(Me.ActiveControl) Then
            Return False
        End If

        ctlACTIVE = Me.ActiveControl

        Select Case True
            Case Else
                blnRET = True
        End Select

        ctlACTIVE = Nothing

        Return blnRET

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

    Private Function FUNC_GET_SELECT_RET_CODE() As Integer
        Dim INT_SELECT_ROW_INDEX As Integer
        INT_SELECT_ROW_INDEX = FUNC_GET_SELECT_ROW_INDEX(DGV_VIEW_DATA)

        If INT_SELECT_ROW_INDEX <= 0 Then
            Return -1
        End If

        Dim INT_SRT_INDEX As Integer
        INT_SRT_INDEX = INT_SELECT_ROW_INDEX

        Dim INT_RET As Integer
        With SRT_GRID_DATA_MAIN(INT_SRT_INDEX)
            INT_RET = FUNC_VALUE_CONVERT_NUMERIC_INT(.CODE_OWNER)
        End With

        Return INT_RET
    End Function

    Private Function FUNC_GET_SEARCH_CONDITHIONS() As SRT_SEARCH_CONDITIONS
        Dim SRT_CONDITIONS As SRT_SEARCH_CONDITIONS

        With SRT_CONDITIONS
            .NAME_OWNER = TXT_NAME_OWNER.Text
            .KANA_OWNER = TXT_KANA_OWNER.Text
            .KIND_OWNER = FUNC_GET_COMBO_KIND_CODE(CMB_KIND_OWNER)
        End With

        Return SRT_CONDITIONS

    End Function

    Private Function FUNC_GET_SQL_WHERE(ByVal SRT_CONDITIONS As SRT_SEARCH_CONDITIONS)
        Dim STR_WHERE As String
        STR_WHERE = ""

        With SRT_CONDITIONS
            STR_WHERE &= FUNC_GET_SQL_WHERE_STR_LIKE(.NAME_OWNER, "NAME_OWNER")
            STR_WHERE &= FUNC_GET_SQL_WHERE_STR_LIKE(.KANA_OWNER, "KANA_OWNER")
            If .KIND_OWNER >= 0 Then
                STR_WHERE &= FUNC_GET_SQL_WHERE_INT(.KIND_OWNER, "KIND_OWNER", "=")
            End If
        End With
        Return STR_WHERE
    End Function
#End Region

#Region "イベントハンドル(フォーカス制御)"
    Private Sub SUB_CTRL_EVENT_HANDLED_ADD() '共通イベントハンドルの追加
        Call SUB_CTRL_EVENT_HANDLED_ADD_MAIN(Me)
    End Sub

    Private Sub SUB_CTRL_EVENT_HANDLED_ADD_MAIN(ByRef objCONTENA As Object)
        Dim ctlCUR_CTRL As System.Windows.Forms.Control

        For Each ctlCUR_CTRL In objCONTENA.Controls
            Select Case True
                Case TypeOf ctlCUR_CTRL Is System.Windows.Forms.GroupBox
                    Call SUB_CTRL_EVENT_HANDLED_ADD_MAIN(ctlCUR_CTRL)
                Case TypeOf ctlCUR_CTRL Is System.Windows.Forms.Panel
                    Call SUB_CTRL_EVENT_HANDLED_ADD_MAIN(ctlCUR_CTRL)
                Case TypeOf ctlCUR_CTRL Is System.Windows.Forms.TextBox _
                  Or TypeOf ctlCUR_CTRL Is System.Windows.Forms.ComboBox
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
        Dim ctlCUR_CTRL As System.Windows.Forms.Control

        For Each ctlCUR_CTRL In objCONTENA
            Select Case True
                Case TypeOf ctlCUR_CTRL Is System.Windows.Forms.GroupBox
                    Call SUB_CTRL_EVENT_HANDLED_REMOVE_MAIN(ctlCUR_CTRL)
                Case TypeOf ctlCUR_CTRL Is System.Windows.Forms.Panel
                    Call SUB_CTRL_EVENT_HANDLED_REMOVE_MAIN(ctlCUR_CTRL)
                Case TypeOf ctlCUR_CTRL Is System.Windows.Forms.TextBox Or TypeOf ctlCUR_CTRL Is System.Windows.Forms.ComboBox
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
    Private Sub BTN_OK_Click(sender As Object, e As EventArgs) Handles BTN_OK.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_OK)
    End Sub

    Private Sub BTN_CLEAR_Click(sender As Object, e As EventArgs) Handles BTN_CLEAR.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_CLEAR)
    End Sub

    Private Sub BTN_CANCEL_Click(sender As Object, e As EventArgs) Handles BTN_CANCEL.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_CANCEL)
    End Sub

    Private Sub BTN_SEARCH_Click(sender As Object, e As EventArgs) Handles BTN_SEARCH.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_SEARCH)
    End Sub
#End Region

#Region "イベント-グリッドダブルクリック"
    Private Sub DGV_VIEW_DATA_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_VIEW_DATA.CellDoubleClick
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_OK)
    End Sub
#End Region

    Private Sub FRM_SYSTEM_INDIVIDUAL_SEARCH_OWNER_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call SUB_CTRL_VIEW_INIT()
        Call SUB_CTRL_VALUE_INIT()

        Call SUB_WINDOW_MODE_CHANGE(ENM_MY_WINDOW_MODE.INPUT_KEY)
    End Sub

    Private Sub FRM_SYSTEM_INDIVIDUAL_SEARCH_OWNER_Activated(sender As Object, e As EventArgs) Handles Me.Activated

    End Sub

    Private Sub FRM_SYSTEM_INDIVIDUAL_SEARCH_OWNER_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub FRM_SYSTEM_INDIVIDUAL_SEARCH_OWNER_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub FRM_SYSTEM_INDIVIDUAL_SEARCH_OWNER_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case True
            Case e.Control
            Case e.Alt
            Case e.Shift
            Case Else
                Call SUB_KEY_DOWN(e.KeyCode, e.Handled)
        End Select
    End Sub

    Private Sub FRM_SYSTEM_INDIVIDUAL_SEARCH_OWNER_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Call SUB_COMMON_EVENT_KEYPRESS(Me, e.KeyChar, e.Handled)
    End Sub
End Class