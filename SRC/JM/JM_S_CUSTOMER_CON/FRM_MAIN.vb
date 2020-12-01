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
        COUNT_CONNECTION = 0
        CODE_CUSTOMER
        CODE_CUSTOME_NAME
        CODE_CONNECTION_NAME
        UBOUND = CODE_CONNECTION_NAME
    End Enum

    Private Enum ENM_MY_WINDOW_MODE
        INPUT_KEY = 1
        INPUT_DATA
    End Enum
#End Region

#Region "画面用・構造体"
    Private Structure SRT_MY_GRID_DATA
        Public COUNT_CONNECTION As Integer
        Public CODE_CUSTOMER As Integer
        Public CODE_CONNECTION() As Integer

        Public CODE_CUSTOMER_NAME As String
        Public CODE_CONNECTION_NAME As String
    End Structure

    Public Structure SRT_SEARCH_CONDITIONS '検索条件
        Public NUMBER_USER As Integer
        Public CODE_CUSTOMER As Integer
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
        Call glbSubMakeDataTable(TBL_GRID_DATA_MAIN, "関連, ,顧客,属性", "ISSS")
        DGV_VIEW_DATA.DataSource = TBL_GRID_DATA_MAIN
        Call SUB_DGV_COLUMN_WIDTH_INIT_COUNT_FONT(DGV_VIEW_DATA, "3,3,15,10", "RRLL")
    End Sub

    Private Sub SUB_CTRL_VALUE_INIT()
        Call SUB_CONTROL_CLEAR_FORM(Me)

        LBL_NAME_USER_HEAD.Text = FUNC_GET_MNG_M_USER_NAME_STAFF(srtSYSTEM_TOTAL_COMMANDLINE.CODE_STAFF)
        LBL_DATE_ACTIVE_HEAD.Text = Format(datSYSTEM_TOTAL_DATE_ACTIVE, "yyyy年MM月dd日")

        ReDim SRT_GRID_DATA_MAIN(0)
        Call SUB_REFRESH_GRID()
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

    Private Sub SUB_REFRESH_COUNT(ByVal INT_COUNT As Integer)
        LBL_COUNT_SEARCH_MAX.Visible = False
        LBL_COUNT_SEARCH.Text = Format(INT_COUNT, "#,##0")

        If INT_COUNT >= CST_MY_GRID_COUNT_MAX Then
            LBL_COUNT_SEARCH_MAX.Visible = True
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

#Region "グリッド関連"
    Private Sub SUB_MAKE_GRID_DATA(ByVal SRT_CONDITIONS As SRT_SEARCH_CONDITIONS)
        ReDim SRT_GRID_DATA_MAIN(0)

        Dim SRT_RECORD_MAIN() As SRT_TABLE_JM_T_CUSTOMER_CON
        SRT_RECORD_MAIN = FUNC_GET_CODE_CUSTOMER_CON(SRT_CONDITIONS.NUMBER_USER, SRT_CONDITIONS.CODE_CUSTOMER)
        Dim INT_CODE_CONNECTION() As Integer
        ReDim INT_CODE_CONNECTION(0)
        Call SUB_ADD_GRID_DATA(SRT_CONDITIONS.CODE_CUSTOMER, SRT_GRID_DATA_MAIN, SRT_RECORD_MAIN, 1, INT_CODE_CONNECTION)

        For i = 1 To SRT_RECORD_MAIN.Length - 1
            Dim SRT_RECORD_SUB() As SRT_TABLE_JM_T_CUSTOMER_CON
            SRT_RECORD_SUB = FUNC_GET_CODE_CUSTOMER_CON(SRT_CONDITIONS.NUMBER_USER, SRT_RECORD_MAIN(i).KEY.CODE_CUSTOMER_SUB)
            ReDim INT_CODE_CONNECTION(1)
            INT_CODE_CONNECTION(1) = SRT_RECORD_MAIN(i).DATA.CODE_CONNECTION
            Call SUB_ADD_GRID_DATA(SRT_CONDITIONS.CODE_CUSTOMER, SRT_GRID_DATA_MAIN, SRT_RECORD_SUB, 2, INT_CODE_CONNECTION)
        Next

        For i = 1 To (SRT_GRID_DATA_MAIN.Length - 1) '補助情報取得
            With SRT_GRID_DATA_MAIN(i)
                .CODE_CUSTOMER_NAME = FUNC_GET_JM_M_CUSTOMER_NAME_CUSTOMER(SRT_CONDITIONS.NUMBER_USER, .CODE_CUSTOMER, True)
                .CODE_CONNECTION_NAME = FUNC_GET_NAME_CODE_CONNECTION(.CODE_CONNECTION)
            End With
        Next

    End Sub

    Private Function FUNC_GET_CODE_CUSTOMER_CON(ByVal INT_NUMBER_USER As Integer, ByVal INT_CODE_CUSTOMER As Integer) As SRT_TABLE_JM_T_CUSTOMER_CON()
        Dim SRT_RET() As SRT_TABLE_JM_T_CUSTOMER_CON
        ReDim SRT_RET(0)

        Dim STR_SQL As System.Text.StringBuilder
        STR_SQL = New System.Text.StringBuilder
        With STR_SQL
            Call .Append("SELECT" & Environment.NewLine)
            Call .Append("*" & Environment.NewLine)
            Call .Append("FROM" & Environment.NewLine)
            Call .Append("JM_T_CUSTOMER_CON WITH(NOLOCK)" & Environment.NewLine)
            Call .Append("WHERE" & Environment.NewLine)
            Call .Append("1=1" & Environment.NewLine)
            Call .Append("AND NUMBER_USER=" & INT_NUMBER_USER & Environment.NewLine)
            Call .Append("AND CODE_CUSTOMER=" & INT_CODE_CUSTOMER & Environment.NewLine)
            Call .Append("ORDER BY" & Environment.NewLine)
            Call .Append("NUMBER_USER,CODE_CUSTOMER,CODE_CUSTOMER_SUB" & Environment.NewLine)
        End With

        Dim SDR_READER As SqlClient.SqlDataReader
        SDR_READER = Nothing
        If Not FUNC_SYSTEM_GET_SQL_DATA_READER(STR_SQL.ToString, SDR_READER) Then
            SDR_READER = Nothing
            Return SRT_RET
        End If

        If Not SDR_READER.HasRows Then
            Call SDR_READER.Close()
            SDR_READER = Nothing
            Return SRT_RET
        End If

        Dim INT_INDEX As Integer
        INT_INDEX = 0
        While SDR_READER.Read
            INT_INDEX = SRT_RET.Length
            ReDim Preserve SRT_RET(INT_INDEX)
            With SRT_RET(INT_INDEX).KEY
                .NUMBER_USER = CInt(SDR_READER.Item("NUMBER_USER"))
                .CODE_CUSTOMER = CInt(SDR_READER.Item("CODE_CUSTOMER"))
                .CODE_CUSTOMER_SUB = CInt(SDR_READER.Item("CODE_CUSTOMER_SUB"))
            End With
            With SRT_RET(INT_INDEX).DATA
                .CODE_CONNECTION = CInt(SDR_READER.Item("CODE_CONNECTION"))
            End With
        End While

        Call SDR_READER.Close()
        SDR_READER = Nothing

        Return SRT_RET
    End Function

    Private Sub SUB_ADD_GRID_DATA(ByVal INT_CODE_CUSTOMER_MAIN As Integer, ByRef SRT_DATA() As SRT_MY_GRID_DATA, ByRef SRT_RECORD() As SRT_TABLE_JM_T_CUSTOMER_CON, ByVal INT_COUNT_CONNECTION As Integer, ByRef INT_CODE_CONNECTION() As Integer)

        For i = 1 To (SRT_RECORD.Length - 1)
            If FUNC_CHECK_CUSTOMER(INT_CODE_CUSTOMER_MAIN, SRT_DATA, SRT_RECORD(i).KEY.CODE_CUSTOMER_SUB) Then
                Continue For
            End If
            Dim INT_INDEX As Integer
            INT_INDEX = SRT_DATA.Length
            ReDim Preserve SRT_DATA(INT_INDEX)
            With SRT_DATA(INT_INDEX)
                .CODE_CUSTOMER = SRT_RECORD(i).KEY.CODE_CUSTOMER_SUB
                .COUNT_CONNECTION = INT_COUNT_CONNECTION

                ReDim .CODE_CONNECTION(0)
                Dim INT_JNDEX As Integer
                For j = 1 To INT_CODE_CONNECTION.Length - 1
                    INT_JNDEX = .CODE_CONNECTION.Length
                    ReDim Preserve .CODE_CONNECTION(INT_JNDEX)
                    .CODE_CONNECTION(INT_JNDEX) = INT_CODE_CONNECTION(j)
                Next
                INT_JNDEX = .CODE_CONNECTION.Length
                ReDim Preserve .CODE_CONNECTION(INT_JNDEX)
                .CODE_CONNECTION(INT_JNDEX) = SRT_RECORD(i).DATA.CODE_CONNECTION
            End With
        Next
    End Sub

    Private Function FUNC_CHECK_CUSTOMER(ByVal INT_CODE_CUSTOMER_MAIN As Integer, ByRef SRT_DATA() As SRT_MY_GRID_DATA, ByVal INT_CODE_CUSTOMER As Integer) As Boolean

        If INT_CODE_CUSTOMER_MAIN = INT_CODE_CUSTOMER Then
            Return True
        End If

        For i = 1 To (SRT_DATA.Length - 1)
            With SRT_DATA(i)
                If .CODE_CUSTOMER = INT_CODE_CUSTOMER Then
                    Return True
                End If
            End With
        Next

        Return False
    End Function

    Private Function FUNC_GET_NAME_CODE_CONNECTION(ByRef INT_CODE() As Integer) As String
        Dim STR_RET As String
        STR_RET = ""

        For i = 1 To (INT_CODE.Length - 1)
            Dim STR_TEMP As String
            STR_TEMP = FUNC_GET_JM_M_CONNECTION_NAME_CONNECTION(INT_CODE(i), True)
            Dim STR_SEP As String
            If i = 1 Then
                STR_SEP = ""
            Else
                STR_SEP = "-"
            End If
            STR_RET &= STR_SEP & STR_TEMP
        Next

        Return STR_RET
    End Function

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
                OBJ_TEMP(ENM_MY_GRID_MAIN.COUNT_CONNECTION) = .COUNT_CONNECTION
                OBJ_TEMP(ENM_MY_GRID_MAIN.CODE_CUSTOMER) = Format(.CODE_CUSTOMER, New String("0", INT_SYSTEM_CODE_CUSTOMER_MAX_LENGTH))
                OBJ_TEMP(ENM_MY_GRID_MAIN.CODE_CUSTOME_NAME) = .CODE_CUSTOMER_NAME
                OBJ_TEMP(ENM_MY_GRID_MAIN.CODE_CONNECTION_NAME) = .CODE_CONNECTION_NAME
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

        Return True
    End Function

#End Region

#Region "キー制御処理"
    '通常のコマンドキー制御(シフトマスク無し)
    Private Sub SUB_KEY_DOWN(ByVal ENM_KEY_CODE As Windows.Forms.Keys, ByRef BLN_HANDLED As Boolean)
        Select Case ENM_KEY_CODE
            Case Keys.Enter
                BLN_HANDLED = True
                If Not FUNC_RETURN_KEYDOWN() Then
                    Exit Sub
                End If
                Call SUB_CONTROL_FOCUS_MOVE(ENM_MOVE_FOCUS_TYPE.FOCUS_NEXT)
            Case Else
                'スルー
        End Select
    End Sub

    '通常のコマンドキー制御(CTRL)
    Private Sub SUB_KEY_DOWN_CTRL(ByVal ENM_KEY_CODE As Windows.Forms.Keys, ByRef BLN_HANDLED As Boolean)
        Select Case ENM_KEY_CODE
            Case Keys.F
                Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_SHOW_SEARCH)
            Case Else
                'スルー
        End Select
    End Sub

    '通常のコマンドキー制御(ALT)
    Private Sub SUB_KEY_DOWN_ALT(ByVal ENM_KEY_CODE As Windows.Forms.Keys, ByRef BLN_HANDLED As Boolean)
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
            Case Else
                BLN_RET = True
        End Select

        CTL_ACTIVE = Nothing

        Return BLN_RET
        Return True
    End Function
#End Region

#Region "内部処理"

    Private Function FUNC_GET_SEARCH_CONDITHIONS() As SRT_SEARCH_CONDITIONS
        Dim SRT_RET As SRT_SEARCH_CONDITIONS
        With SRT_RET
            .NUMBER_USER = INT_SYSTEM_INDIVIDUAL_NUMBER_USER
            .CODE_CUSTOMER = CInt(TXT_CODE_CUSTOMER.Text)
        End With

        Return SRT_RET
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

#Region "イベント-テキストチェンジ"

    Private Sub TXT_CODE_CUSTOMER_TextChanged(sender As Object, e As EventArgs) Handles TXT_CODE_CUSTOMER.TextChanged
        Call SUB_GET_NAME_CUSTOMER_INPUT(sender)
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
