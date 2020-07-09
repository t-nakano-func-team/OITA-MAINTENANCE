Public Class FRM_SUB_01

#Region "画面用・定数"
#End Region

#Region "画面用・列挙定数"
    Private Enum ENM_MY_EXEC_DO
        DO_SHOW_SEARCH
        DO_ENTER
        DO_END = 81
        DO_SHOW_SETTING
        DO_SHOW_COMMANDLINE
        DO_SHOW_CONFIG_SETTINGS
    End Enum

#End Region

#Region "画面用・構造体"
#End Region

#Region "画面用・変数"
    Private BLN_PROCESS_DOING As Boolean
#End Region

#Region "プロパティ用"
    Private BLN_PROPERTY_EDIT_CANCEL As Boolean 'キャンセルフラグ(True:キャンセル / False:決定)
#End Region

#Region "プロパティ"
    Friend Property RET_EDIT_CANCEL() As Boolean
        Get
            Return BLN_PROPERTY_EDIT_CANCEL
        End Get
        Set(ByVal Value As Boolean)
            BLN_PROPERTY_EDIT_CANCEL = Value
        End Set
    End Property
#End Region

#Region "初期化・終了処理"
    Private Sub SUB_CTRL_NEW_INIT()
        Call SUB_CTRL_EVENT_HANDLED_ADD()
    End Sub

    Private Sub SUB_CTRL_VIEW_INIT()
        Me.RET_EDIT_CANCEL = True
    End Sub

    Private Sub SUB_CTRL_VALUE_INIT()
        Call SUB_CONTROL_CLEAR_FORM(Me)

        Const CST_CODE_ACTIVE As Integer = 1 '処理日取得用

        Dim BLN_CHECK As Boolean
        BLN_CHECK = FUNC_CHECK_MNG_M_ACTIVE(CST_CODE_ACTIVE)
        CHK_DATE_ACTIVE_INSERT.Checked = BLN_CHECK
        Call SUB_REFRESH_ENAVLED_DATE_ACTIVE()
        Call SUB_CONTROL_SET_VALUE_DateTimePicker(DTP_DATE_ACTIVE, datSYSTEM_TOTAL_DATE_ACTIVE)
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
            Case ENM_MY_EXEC_DO.DO_ENTER
                Call SUB_ENTER()
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
    Private Sub SUB_ENTER()


        If Not FUNC_SYSTEM_BEGIN_TRANSACTION() Then
            Call MessageBox.Show(FUNC_SYSTEM_SQLGET_ERR_MESSAGE(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Const CST_CODE_ACTIVE As Integer = 1 '処理日取得用
        Dim SRT_DATA As SRT_TABLE_MNG_M_ACTIVE
        With SRT_DATA.KEY
            .CODE_ACTIVE = CST_CODE_ACTIVE
        End With
        If Not FUNC_DELETE_TABLE_MNG_M_ACTIVE(SRT_DATA.KEY) Then
            Call MessageBox.Show(FUNC_SYSTEM_SQLGET_ERR_MESSAGE(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Call FUNC_SYSTEM_ROLLBACK_TRANSACTION()
            Exit Sub
        End If

        If CHK_DATE_ACTIVE_INSERT.Checked Then
            With SRT_DATA.DATA
                .DATE_ACTIVE = DTP_DATE_ACTIVE.Value
            End With
            If Not FUNC_INSERT_TABLE_MNG_M_ACTIVE(SRT_DATA) Then
                Call MessageBox.Show(FUNC_SYSTEM_SQLGET_ERR_MESSAGE(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Call FUNC_SYSTEM_ROLLBACK_TRANSACTION()
                Exit Sub
            End If
        End If

        If Not FUNC_SYSTEM_COMMIT_TRANSACTION() Then
            Call MessageBox.Show(FUNC_SYSTEM_SQLGET_ERR_MESSAGE(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Me.RET_EDIT_CANCEL = False
        Call Me.Close()
    End Sub

    Private Sub SUB_END()
        Call Me.Close()
    End Sub

    Private Sub SUB_SHOW_SETTING()
        blnSHOW_SETTING = True
        Call Me.Close()
    End Sub

    Private Sub SUB_SHOW_COMMANDLINE()
        Call SUB_SYSTEM_TOTAL_SHOW_COMMANDLINE(srtSYSTEM_TOTAL_COMMANDLINE)
    End Sub

    Private Sub SUB_SHOW_CONFIG_SETTINGS()
        Call SUB_SYSTEM_TOTAL_SHOW_SETTINGS(srtSYSTEM_TOTAL_CONFIG_SETTINGS)
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
                'Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_SHOW_SETTING)
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
    End Function
#End Region

#Region "内部処理"
    Private Sub SUB_REFRESH_ENAVLED_DATE_ACTIVE()
        Dim BLN_ENABLED As Boolean
        BLN_ENABLED = CHK_DATE_ACTIVE_INSERT.Checked
        PNL_DATE_ACTIVE.Enabled = BLN_ENABLED
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

    Private Sub BTN_OK_Click(sender As Object, e As EventArgs) Handles BTN_OK.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_ENTER)
    End Sub

    Private Sub BTN_CANCEL_Click(sender As Object, e As EventArgs) Handles BTN_CANCEL.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_END)
    End Sub

#End Region

#Region "イベント-チェックチェンジ"
    Private Sub CHK_DATE_ACTIVE_INSERT_CheckedChanged(sender As Object, e As EventArgs) Handles CHK_DATE_ACTIVE_INSERT.CheckedChanged
        Call SUB_REFRESH_ENAVLED_DATE_ACTIVE()
    End Sub
#End Region

    Private Sub FRM_SUB_01_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call SUB_CTRL_VIEW_INIT()
        Call SUB_CTRL_VALUE_INIT()
    End Sub

    Private Sub FRM_SUB_01_Activated(sender As Object, e As EventArgs) Handles Me.Activated

    End Sub

    Private Sub FRM_SUB_01_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Enabled = False
        Call Application.DoEvents()
    End Sub

    Private Sub FRM_SUB_01_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

    Private Sub FRM_SUB_01_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Call SUB_COMMON_EVENT_KEYPRESS(Me, e.KeyChar, e.Handled)
    End Sub

End Class