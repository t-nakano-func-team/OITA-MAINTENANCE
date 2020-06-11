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
        DO_END = 81
        DO_SHOW_SETTING
        DO_SHOW_COMMANDLINE
        DO_SHOW_CONFIG_SETTINGS
    End Enum

    Private Enum ENM_MY_GRID_MAIN
        CHECK = 0
        KIND_CONTRACT_NAME
        NUMBER_CONTRACT_VIEW
        DATE_INVOICE
        NAME_OWNER
        NAME_CONTRACT
        COUNT_INVOICE_VIEW
        KINGAKU_CONTRACT
        UBOUND = KINGAKU_CONTRACT
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

        Public KIND_CONTRACT As Integer
        Public DATE_INVOICE As DateTime
        Public CODE_OWNER As Integer
        Public NAME_CONTRACT As String
        Public COUNT_INVOICE As Integer
        Public KINGAKU_CONTRACT As Long

        Public KINGAKU_INVOICE_DETAIL As Long
        Public KINGAKU_INVOICE_VAT As Long
        Public KIND_CONTRACT_NAME As String
        Public CODE_OWNER_NAME As String

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
        Public DATE_INVOICE_FROM As DateTime
        Public DATE_INVOICE_TO As DateTime
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
        Call glbSubMakeDataTable(TBL_GRID_DATA_MAIN, " ,形態,契約番号,請求日付,オーナー,契約内容,回数,請求金額", "BSSSSSSS")
        DGV_VIEW_DATA.DataSource = TBL_GRID_DATA_MAIN
        Call SUB_DGV_COLUMN_WIDTH_INIT_COUNT_FONT(DGV_VIEW_DATA, "1,3,5,5,6,6,2,6", "CLRRLLCR")

        Dim DAT_DATE_TO As DateTime
        DAT_DATE_TO = FUNC_GET_DATE_LASTMONTH(datSYSTEM_TOTAL_DATE_ACTIVE.AddMonths(1))
        Call SUB_CONTROL_INITALIZE_DateTimePicker(DTP_DATE_INVOICE_FROM, srtSYSTEM_TOTAL_CONFIG_SETTINGS.LOCAL.DATE_SYSTEM_REPLACE, DAT_DATE_TO)
        Call SUB_CONTROL_INITALIZE_DateTimePicker(DTP_DATE_INVOICE_TO, srtSYSTEM_TOTAL_CONFIG_SETTINGS.LOCAL.DATE_SYSTEM_REPLACE, DAT_DATE_TO)
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

#Region "グリッド関連"
    Private Sub SUB_MAKE_GRID_DATA(ByVal SRT_CONDITIONS As SRT_SEARCH_CONDITIONS)

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
                OBJ_TEMP(ENM_MY_GRID_MAIN.KIND_CONTRACT_NAME) = .KIND_CONTRACT_NAME
                OBJ_TEMP(ENM_MY_GRID_MAIN.NUMBER_CONTRACT_VIEW) = .FUNC_GET_NUMBER_SERIAL_CONTRACT
                OBJ_TEMP(ENM_MY_GRID_MAIN.DATE_INVOICE) = .DATE_INVOICE.ToLongDateString
                OBJ_TEMP(ENM_MY_GRID_MAIN.NAME_OWNER) = .CODE_OWNER_NAME
                OBJ_TEMP(ENM_MY_GRID_MAIN.NAME_CONTRACT) = .NAME_CONTRACT
                OBJ_TEMP(ENM_MY_GRID_MAIN.COUNT_INVOICE_VIEW) = .FUNC_GET_COUNT_INVOICE_VIEW
                OBJ_TEMP(ENM_MY_GRID_MAIN.KINGAKU_CONTRACT) = Format(.FUNC_GET_KINGAKU_INVOICE_TOTAL, "#,##0")
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
