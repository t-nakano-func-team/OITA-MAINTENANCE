Imports System.ComponentModel

Public Class FRM_SUB_03

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

    Private Enum ENM_MY_GRID_MAIN
        COUNT = 0
        DATE_INVOICE
        UBOUND = DATE_INVOICE
    End Enum

#End Region

#Region "画面用・構造体"

    Private Structure SRT_CONDTIONS_GRID
        Public NUMBER_CONTRACT As Integer
        Public SERIAL_CONTRACT As Integer
    End Structure

    Private Structure SRT_DATA_GRID
        Public NUMBER_CONTRACT As Integer
        Public SERIAL_CONTRACT As Integer
        Public SERIAL_INVOICE As Integer
        Public DATE_DEPOSIT As DateTime
    End Structure
#End Region

#Region "画面用・変数"
    Private BLN_PROCESS_DOING As Boolean
    Private TBL_GRID_DATA_MAIN As DataTable
#End Region

#Region "プロパティ用"
    Private INT_PROPERTY_NUMBER_CONTRACT As Integer
    Private INT_PROPERTY_SERIAL_CONTRACT As Integer
#End Region

#Region "プロパティ"

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
        Call glbSubMakeDataTable(TBL_GRID_DATA_MAIN, "回数,入金日", "SS")
        DGV_VIEW_DATA.DataSource = TBL_GRID_DATA_MAIN
        Call SUB_DGV_COLUMN_WIDTH_INIT_COUNT_FONT(DGV_VIEW_DATA, "4,6", "LL")
    End Sub

    Private Sub SUB_CTRL_VALUE_INIT()
        Call SUB_CONTROL_CLEAR_FORM(Me)

        LBL_NAME_TITLE_HEAD.Text = Me.Text

        Dim SRT_CONDTIONS As SRT_CONDTIONS_GRID
        With SRT_CONDTIONS
            .NUMBER_CONTRACT = Me.NUMBER_CONTRACT
            .SERIAL_CONTRACT = Me.SERIAL_CONTRACT
        End With

        Call TBL_GRID_DATA_MAIN.Clear()
        Call SUB_GET_GRID_DATA(SRT_CONDTIONS)

        Dim INT_COUNT As Integer
        INT_COUNT = TBL_GRID_DATA_MAIN.Rows.Count
        LBL_COUNT_DEPOSIT_ALREADY.Text = INT_COUNT
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
    Private Sub SUB_GET_GRID_DATA(ByRef SRT_CONDTIONS As SRT_CONDTIONS_GRID)

        Dim STR_SQL As System.Text.StringBuilder
        STR_SQL = New System.Text.StringBuilder
        With STR_SQL
            .Append("SELECT" & System.Environment.NewLine)
            .Append("*" & System.Environment.NewLine)
            .Append("FROM" & System.Environment.NewLine)
            .Append("MNT_T_DEPOSIT WITH(NOLOCK)" & System.Environment.NewLine)
            .Append("WHERE" & System.Environment.NewLine)
            .Append("1=1" & System.Environment.NewLine)
            .Append("AND NUMBER_CONTRACT=" & SRT_CONDTIONS.NUMBER_CONTRACT & System.Environment.NewLine)
            .Append("AND SERIAL_CONTRACT=" & SRT_CONDTIONS.SERIAL_CONTRACT & System.Environment.NewLine)
            .Append("ORDER BY" & System.Environment.NewLine)
            .Append("NUMBER_CONTRACT,SERIAL_CONTRACT,SERIAL_INVOICE" & System.Environment.NewLine)
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

        Dim SRT_DATA() As SRT_DATA_GRID
        ReDim SRT_DATA(0)
        Dim INT_INDEX As Integer
        INT_INDEX = 0
        While SDR_READER.Read
            INT_INDEX = SRT_DATA.Length
            ReDim Preserve SRT_DATA(INT_INDEX)
            With SRT_DATA(INT_INDEX)
                .NUMBER_CONTRACT = CInt(SDR_READER.Item("NUMBER_CONTRACT"))
                .SERIAL_CONTRACT = CInt(SDR_READER.Item("SERIAL_CONTRACT"))
                .SERIAL_INVOICE = CInt(SDR_READER.Item("SERIAL_INVOICE"))
                .DATE_DEPOSIT = CDate(SDR_READER.Item("DATE_DEPOSIT"))
            End With
        End While

        Call SDR_READER.Close()
        SDR_READER = Nothing

        For i = 1 To (SRT_DATA.Length - 1) '補助情報取得
            With SRT_DATA(i)

            End With
        Next

        Call SUB_REFRESH_GRID(SRT_DATA)
    End Sub

    Private Sub SUB_REFRESH_GRID(ByRef SRT_DATA() As SRT_DATA_GRID)

        Call TBL_GRID_DATA_MAIN.Clear()

        Dim INT_MAX_INDEX As Integer
        INT_MAX_INDEX = (SRT_DATA.Length - 1)

        If INT_MAX_INDEX <= 0 Then
            Exit Sub
        End If

        Dim OBJ_TEMP(ENM_MY_GRID_MAIN.UBOUND) As Object

        For i = 1 To INT_MAX_INDEX
            With SRT_DATA(i)
                OBJ_TEMP(ENM_MY_GRID_MAIN.COUNT) = CStr(i & "回目")
                OBJ_TEMP(ENM_MY_GRID_MAIN.DATE_INVOICE) = .DATE_DEPOSIT.ToLongDateString
            End With
            Call glbSubAddRowDataTable(TBL_GRID_DATA_MAIN, OBJ_TEMP)
        Next

        Call DGV_VIEW_DATA.Refresh()
        Call System.Windows.Forms.Application.DoEvents()

        Call SUB_SET_SELECT_ROW_INDEX(DGV_VIEW_DATA, 0)
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

#End Region

    Private Sub FRM_SUB_03_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call SUB_CTRL_VIEW_INIT()
        Call SUB_CTRL_VALUE_INIT()
    End Sub

    Private Sub FRM_SUB_03_Activated(sender As Object, e As EventArgs) Handles Me.Activated

    End Sub

    Private Sub FRM_SUB_03_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Enabled = False
        Call Application.DoEvents()
    End Sub

    Private Sub FRM_SUB_03_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

    Private Sub FRM_SUB_03_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Call SUB_COMMON_EVENT_KEYPRESS(Me, e.KeyChar, e.Handled)
    End Sub
End Class