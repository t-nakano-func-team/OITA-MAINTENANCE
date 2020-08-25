Public Class FRM_SUB_01

#Region "画面用・定数"
#End Region

#Region "画面用・列挙定数"
    Private Enum ENM_MY_EXEC_DO
        DO_SHOW_SEARCH
        DO_OK
        DO_CANCEL = 81
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
    Private INT_PROPERTY_NUMBER_CONTRACT As Integer
    Private INT_PROPERTY_SERIAL_CONTRACT As Integer
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

    Friend Property NUMBER_CONTRACT() As Integer
        Get
            Return INT_PROPERTY_NUMBER_CONTRACT
        End Get
        Set(ByVal Value As Integer)
            INT_PROPERTY_NUMBER_CONTRACT = Value
        End Set
    End Property

    Friend Property SERIAL_CONTRACT() As Integer
        Get
            Return INT_PROPERTY_SERIAL_CONTRACT
        End Get
        Set(ByVal Value As Integer)
            INT_PROPERTY_SERIAL_CONTRACT = Value
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

        LBL_NAME_TITLE_HEAD.Text = Me.Text

        LBL_BATCH_GUIDE.Text = "該当契約の任意の回数請求／入金を確定済みにします。"

        Dim SRT_CONTRACT As SRT_TABLE_MNT_T_CONTRACT
        With SRT_CONTRACT.KEY
            .NUMBER_CONTRACT = Me.NUMBER_CONTRACT
            .SERIAL_CONTRACT = Me.SERIAL_CONTRACT
        End With
        SRT_CONTRACT.DATA = Nothing
        Call FUNC_SELECT_TABLE_MNT_T_CONTRACT(SRT_CONTRACT.KEY, SRT_CONTRACT.DATA)
        TXT_COUNT_INVOICE.Text = CStr(SRT_CONTRACT.DATA.COUNT_INVOICE)
        Call SUB_REFRESH_COUNT_DEPOSIT()
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
            Case ENM_MY_EXEC_DO.DO_OK
                Call SUB_OK()
            Case ENM_MY_EXEC_DO.DO_CANCEL
                Call SUB_CANCEL()
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
    Private Sub SUB_OK()

        Dim INT_COUNT_INVOICE As Integer
        INT_COUNT_INVOICE = FUNC_VALUE_CONVERT_NUMERIC_INT(TXT_COUNT_INVOICE.Text, 0)

        Dim INT_COUNT_DEPOSIT As Integer
        INT_COUNT_DEPOSIT = FUNC_VALUE_CONVERT_NUMERIC_INT(TXT_COUNT_DEPOSIT.Text, 0)

        If Not FUNC_DELETE_INVOICE_CONTRACT(Me.NUMBER_CONTRACT, Me.SERIAL_CONTRACT) Then
            Exit Sub
        End If

        For i = 1 To INT_COUNT_INVOICE
            Dim DAT_DATE_INVOICE As DateTime
            DAT_DATE_INVOICE = FUNC_GET_DATE_INVOICE_PLAN(Me.NUMBER_CONTRACT, Me.SERIAL_CONTRACT)

            Dim SRT_EDIT As SRT_EDIT_INVOICE
            With SRT_EDIT
                .CEHCK_EDIT = False
                .CODE_SECTION = 0
                .KINGAKU_INVOICE_DETAIL = 0
                .KINGAKU_INVOICE_VAT = 0
            End With
            If Not FUNC_MAKE_NEW_INVOICE(Me.NUMBER_CONTRACT, Me.SERIAL_CONTRACT, DAT_DATE_INVOICE, SRT_EDIT) Then
                Exit Sub
            End If

            Dim INT_SERIAL_INVOICE As Integer
            INT_SERIAL_INVOICE = FUNC_GET_MNT_T_INVOICE_MAX_SERIAL_INVOICE(Me.NUMBER_CONTRACT, Me.SERIAL_CONTRACT)

            Dim INT_YYYYMM_INVOICE As Integer
            INT_YYYYMM_INVOICE = FUNC_GET_YYYYMM_FROM_DATE(DAT_DATE_INVOICE)

            Dim INT_YYYYMM_INVOICE_NEXT As Integer
            INT_YYYYMM_INVOICE_NEXT = FUNC_ADD_MONTH_YYYYMM(INT_YYYYMM_INVOICE, 1) '翌月

            Dim INT_YEAR_DEPOSIT As Integer
            INT_YEAR_DEPOSIT = FUNC_GET_YYYY_FROM_YYYYMM(INT_YYYYMM_INVOICE_NEXT)

            Dim INT_MONTH_DEPOSIT As Integer
            INT_MONTH_DEPOSIT = FUNC_GET_MM_FROM_YYYYMM(INT_YYYYMM_INVOICE_NEXT)

            Dim DAT_DATE_DEPOSIT As DateTime
            DAT_DATE_DEPOSIT = New DateTime(INT_YEAR_DEPOSIT, INT_MONTH_DEPOSIT, 1) '翌月月初

            If i <= INT_COUNT_DEPOSIT Then
                If Not FUNC_MAKE_NEW_DEPOSIT(Me.NUMBER_CONTRACT, Me.SERIAL_CONTRACT, INT_SERIAL_INVOICE, DAT_DATE_DEPOSIT) Then
                    Exit Sub
                End If
            End If
        Next

        Me.RET_EDIT_CANCEL = False
        Call Me.Close()
    End Sub

    Private Sub SUB_CANCEL()
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

    Private Sub SUB_REFRESH_COUNT_DEPOSIT()
        Dim INT_COUNT_INVOICE As Integer
        INT_COUNT_INVOICE = FUNC_VALUE_CONVERT_NUMERIC_INT(TXT_COUNT_INVOICE.Text, 0)
        TXT_COUNT_DEPOSIT.Text = INT_COUNT_INVOICE
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
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_OK)
    End Sub

    Private Sub BTN_CANCEL_Click(sender As Object, e As EventArgs) Handles BTN_CANCEL.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_CANCEL)
    End Sub

#End Region

#Region "イベント-テキストチェンジ"

    Private Sub TXT_COUNT_INVOICE_TextChanged(sender As Object, e As EventArgs) Handles TXT_COUNT_INVOICE.TextChanged
        Call SUB_REFRESH_COUNT_DEPOSIT()
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