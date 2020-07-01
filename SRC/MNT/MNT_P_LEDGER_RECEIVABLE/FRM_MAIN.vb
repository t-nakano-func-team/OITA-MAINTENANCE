Public Class FRM_MAIN

#Region "画面用・定数"
#End Region

#Region "画面用・列挙定数"
    Private Enum ENM_MY_EXEC_DO
        DO_SHOW_SEARCH = 1
        DO_PREVIEW
        DO_PRINT
        DO_CLEAR
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

#Region "初期化・終了処理"
    Private Sub SUB_CTRL_NEW_INIT()
        Call SUB_CTRL_EVENT_HANDLED_ADD()
    End Sub

    Private Sub SUB_CTRL_VIEW_INIT()

        Dim DAT_DATE_TO As DateTime
        DAT_DATE_TO = datSYSTEM_TOTAL_DATE_ACTIVE
        Call SUB_CONTROL_INITALIZE_DateTimePicker(DTP_DATE_CONTRACT_FROM, srtSYSTEM_TOTAL_CONFIG_SETTINGS.LOCAL.DATE_SYSTEM_REPLACE, DAT_DATE_TO)
        Call SUB_CONTROL_INITALIZE_DateTimePicker(DTP_DATE_CONTRACT_TO, srtSYSTEM_TOTAL_CONFIG_SETTINGS.LOCAL.DATE_SYSTEM_REPLACE, DAT_DATE_TO)

        DAT_DATE_TO = datSYSTEM_TOTAL_DATE_ACTIVE
        Call SUB_CONTROL_INITALIZE_DateTimePicker(DTP_DATE_CALC, srtSYSTEM_TOTAL_CONFIG_SETTINGS.LOCAL.DATE_SYSTEM_REPLACE, DAT_DATE_TO)

        Call SUB_SYSTEM_COMMBO_MNT_M_KIND(CMB_CODE_SECTION, ENM_MNT_M_KIND_CODE_FLAG.CODE_SECTION, True, "全て")
        Call SUB_SYSTEM_COMMBO_MNT_M_KIND(CMB_KIND_TARGET, ENM_MNT_M_KIND_CODE_FLAG.KIND_TARGET_RECEIVABLE, True, "全て")
    End Sub

    Private Sub SUB_CTRL_VALUE_INIT()
        Call SUB_CONTROL_CLEAR_FORM(Me)

        LBL_NAME_USER_HEAD.Text = FUNC_GET_MNG_M_USER_NAME_STAFF(srtSYSTEM_TOTAL_COMMANDLINE.CODE_STAFF)
        LBL_DATE_ACTIVE_HEAD.Text = Format(datSYSTEM_TOTAL_DATE_ACTIVE, "yyyy年MM月dd日")

        Dim DAT_FROM As DateTime
        DAT_FROM = FUNC_GET_DATE_FIRSMONTH(datSYSTEM_TOTAL_DATE_ACTIVE.AddYears(-1))
        Call SUB_CONTROL_SET_VALUE_DateTimePicker(DTP_DATE_CONTRACT_FROM, DAT_FROM)

        Dim DAT_TO As DateTime
        DAT_TO = datSYSTEM_TOTAL_DATE_ACTIVE
        Call SUB_CONTROL_SET_VALUE_DateTimePicker(DTP_DATE_CONTRACT_TO, DAT_TO)

        Call SUB_CONTROL_SET_VALUE_DateTimePicker(DTP_DATE_CALC, datSYSTEM_TOTAL_DATE_ACTIVE)

        Call SUB_SET_COMBO_KIND_CODE_FIRST(CMB_CODE_SECTION)
        Call SUB_SET_COMBO_KIND_CODE(CMB_KIND_TARGET, ENM_SYSTEM_INDIVIDUAL_KIND_TARGET_RECEIVABLE.BALANCE_HAVE)
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
            Case ENM_MY_EXEC_DO.DO_PREVIEW
                Call SUB_PRINT(True, False)
            Case ENM_MY_EXEC_DO.DO_PRINT
                Call SUB_PRINT(False, False)
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

    '印刷/プレビュー/ファイル出力
    Private Sub SUB_PRINT(ByVal BLN_PREVIEW As Boolean, ByVal BLN_PUT_FILE As Boolean)

    End Sub

    Private Sub SUB_CLEAR()
        Call SUB_CONTROL_CLEAR_FORM(Me)
        Call SUB_CTRL_VALUE_INIT() '値を初期化
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
            Case Else
                BLN_RET = True
        End Select

        CTL_ACTIVE = Nothing

        Return BLN_RET
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

    Private Sub BTN_PREVIEW_Click(sender As Object, e As EventArgs) Handles BTN_PREVIEW.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_PREVIEW)
    End Sub

    Private Sub BTN_PRINT_Click(sender As Object, e As EventArgs) Handles BTN_PRINT.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_PRINT)
    End Sub

    Private Sub BTN_CLEAR_Click(sender As Object, e As EventArgs) Handles BTN_CLEAR.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_CLEAR)
    End Sub

    Private Sub BTN_END_Click(sender As Object, e As EventArgs) Handles BTN_END.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_END)
    End Sub
#End Region

    Private Sub FRM_MAIN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call SUB_CTRL_VIEW_INIT()
        Call SUB_CTRL_VALUE_INIT()
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
