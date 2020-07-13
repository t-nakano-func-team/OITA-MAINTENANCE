Public Class FRM_MAIN

#Region "画面用・列挙定数"
    Private Enum ENM_MY_EXEC_DO
        DO_SHOW_SEARCH = 1
        DO_SELECT_SEQ
        DO_DATA_EDIT
        DO_ENTER
        DO_DELETE
        DO_CLEAR
        DO_END = 81
        DO_SHOW_SETTING
        DO_SHOW_COMMANDLINE
        DO_SHOW_CONFIG_SETTINGS
    End Enum

    Private Enum ENM_MY_WINDOW_MODE
        INPUT_KEY = 1
        INPUT_DATA_INSERT
        INPUT_DATA_UPDATE_NORMAL
        INPUT_DATA_UPDATE_INVOICE
    End Enum

#End Region

#Region "画面用・構造体"

    Public Structure SRT_MY_SEARCH_CONDITIONS '検索条件
    End Structure

    Public Structure SRT_COUNT_ALREADY
        Public COUNT_INVOICE_ALREADY As Integer
        Public COUNT_DEPOSIT_ALREADY As Integer
    End Structure
#End Region

#Region "画面用・変数"
    Private BLN_PROCESS_DOING As Boolean
    Private ENM_WINDOW_MODE_CURRENT As ENM_MY_WINDOW_MODE '現在の画面状態
#End Region

#Region "初期化・終了処理"
    Private Sub SUB_CTRL_NEW_INIT()
        Call SUB_CTRL_EVENT_HANDLED_ADD()
    End Sub

    Private Sub SUB_CTRL_VIEW_INIT()

        Dim DAT_DATE_INPUT_MAX As DateTime
        DAT_DATE_INPUT_MAX = datSYSTEM_TOTAL_DATE_ACTIVE.AddMonths(1)
        Call SUB_CONTROL_INITALIZE_DateTimePicker(DTP_DATE_CONTRACT, srtSYSTEM_TOTAL_CONFIG_SETTINGS.LOCAL.DATE_SYSTEM_REPLACE, DAT_DATE_INPUT_MAX)

        Call SUB_SYSTEM_COMMBO_MNT_M_KIND(CMB_CODE_SECTION, ENM_MNT_M_KIND_CODE_FLAG.CODE_SECTION)
        Call SUB_SYSTEM_COMMBO_MNT_M_KIND(CMB_KIND_WORK, ENM_MNT_M_KIND_CODE_FLAG.KIND_WORK)

        DAT_DATE_INPUT_MAX = datSYSTEM_TOTAL_DATE_ACTIVE.AddMonths(1)
        Call SUB_CONTROL_INITALIZE_DateTimePicker(DTP_DATE_WORK_FROM, srtSYSTEM_TOTAL_CONFIG_SETTINGS.LOCAL.DATE_SYSTEM_REPLACE, DAT_DATE_INPUT_MAX)

        DAT_DATE_INPUT_MAX = datSYSTEM_TOTAL_DATE_ACTIVE.AddYears(2)
        Call SUB_CONTROL_INITALIZE_DateTimePicker(DTP_DATE_WORK_TO, srtSYSTEM_TOTAL_CONFIG_SETTINGS.LOCAL.DATE_SYSTEM_REPLACE, DAT_DATE_INPUT_MAX)
    End Sub

    Private Sub SUB_CTRL_VALUE_INIT()
        Call SUB_CONTROL_CLEAR_FORM(Me)

        LBL_NAME_USER_HEAD.Text = FUNC_GET_MNG_M_USER_NAME_STAFF(srtSYSTEM_TOTAL_COMMANDLINE.CODE_STAFF)
        LBL_DATE_ACTIVE_HEAD.Text = Format(datSYSTEM_TOTAL_DATE_ACTIVE, "yyyy年MM月dd日")

        Call SUB_CONTROL_SET_VALUE_DateTimePicker(DTP_DATE_CONTRACT, datSYSTEM_TOTAL_DATE_ACTIVE)
        Call SUB_REFRESH_DATE_WORK()
        Call SUB_REFRESH_DATE_INVOICE_BASE_VALUE()

        Call SUB_SET_COMBO_KIND_CODE_FIRST(CMB_CODE_SECTION)
        Call SUB_SET_COMBO_KIND_CODE_FIRST(CMB_KIND_WORK)
        Call SUB_REFRESH_CODE_WORK()

        TXT_KINGAKU_CONTRACT.Text = Format(0, "#,##0")
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
            Case ENM_MY_EXEC_DO.DO_SHOW_SEARCH
                Call SUB_SHOW_SEARCH()
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

    Private Sub SUB_SHOW_SEARCH()

        Dim CTL_ACTIVE As Control
        CTL_ACTIVE = Me.ActiveControl

        Dim CTL_SEARCH As Control
        CTL_SEARCH = Nothing
        Select Case True
            Case (CTL_ACTIVE Is TXT_CODE_OWNER) Or (CTL_ACTIVE Is BTN_CODE_OWNER_SEARCH)
                CTL_SEARCH = TXT_CODE_OWNER
            Case Else

        End Select

        If CTL_SEARCH Is Nothing Then
            Exit Sub
        End If

        Dim sngFONT_SIZE As Single
        sngFONT_SIZE = Me.Font.Size

        Dim BLN_RET As Boolean
        Select Case True
            Case (CTL_SEARCH Is TXT_CODE_OWNER)
                Dim TXT_SEARCH As TextBox
                TXT_SEARCH = CTL_SEARCH
                Dim INT_CODE_OWNER As Integer
                INT_CODE_OWNER = FUNC_VALUE_CONVERT_NUMERIC_INT(TXT_SEARCH.Text)

                BLN_RET = FUNC_SHOW_SYSTEM_INDIVIDUAL_SEARCH_OWNER(INT_CODE_OWNER, sngFONT_SIZE)

                If BLN_RET Then
                    TXT_SEARCH.Text = Format(INT_CODE_OWNER, New String("0", TXT_SEARCH.MaxLength))
                    Call TXT_SEARCH.Focus()
                    Call TXT_SEARCH.SelectAll()
                End If

            Case Else
                'スルー
        End Select
    End Sub


    'データ入力モードへ変更
    Private Sub SUB_DATA_EDIT()

        If Not FUNC_CHECK_INPUT_KEY() Then
            Exit Sub
        End If

        If TXT_NUMBER_CONTRACT.Text = "" Then
            Dim INT_NUMBER_CONTRACT As Integer
            INT_NUMBER_CONTRACT = FUNC_GET_NUMBER_CONTRACT_NEW(True)
            TXT_NUMBER_CONTRACT.Text = Format(INT_NUMBER_CONTRACT, New String("0", TXT_NUMBER_CONTRACT.MaxLength))
        End If

        Dim SRT_KEY As SRT_TABLE_MNT_T_CONTRACT_KEY
        SRT_KEY = FUNC_GET_INPUT_KEY()
        Dim BLN_CHECK As Boolean
        BLN_CHECK = FUNC_CHECK_TABLE_MNT_T_CONTRACT(SRT_KEY)

        Dim ENM_CHANGE_MODE As ENM_MY_WINDOW_MODE
        Dim SRT_ALREADY As SRT_COUNT_ALREADY
        If BLN_CHECK Then

            With SRT_ALREADY
                .COUNT_INVOICE_ALREADY = FUNC_GET_MNT_T_INVOICE_COUNT(SRT_KEY.NUMBER_CONTRACT, SRT_KEY.SERIAL_CONTRACT)
                .COUNT_DEPOSIT_ALREADY = FUNC_GET_MNT_T_INVOICE_COUNT_DEPOSIT_DONE(SRT_KEY.NUMBER_CONTRACT, SRT_KEY.SERIAL_CONTRACT)
            End With

            If SRT_ALREADY.COUNT_INVOICE_ALREADY > 0 Then
                ENM_CHANGE_MODE = ENM_MY_WINDOW_MODE.INPUT_DATA_UPDATE_INVOICE
            Else
                ENM_CHANGE_MODE = ENM_MY_WINDOW_MODE.INPUT_DATA_UPDATE_NORMAL
            End If

            Dim SRT_DATA As SRT_TABLE_MNT_T_CONTRACT_DATA
            SRT_DATA = Nothing
            Call FUNC_SELECT_TABLE_MNT_T_CONTRACT(SRT_KEY, SRT_DATA)

            Dim SRT_KEY_SPOT As SRT_TABLE_MNT_T_CONTRACT_SPOT_KEY
            With SRT_KEY_SPOT
                .NUMBER_CONTRACT = SRT_KEY.NUMBER_CONTRACT
                .SERIAL_CONTRACT = SRT_KEY.SERIAL_CONTRACT
            End With
            Dim SRT_DATA_SPOT As SRT_TABLE_MNT_T_CONTRACT_SPOT_DATA
            SRT_DATA_SPOT = Nothing
            Call FUNC_SELECT_TABLE_MNT_T_CONTRACT_SPOT(SRT_KEY_SPOT, SRT_DATA_SPOT)

            Call SUB_SET_INPUT_DATA(SRT_DATA)
            Call SUB_SET_INPUT_SPOT_DATA(SRT_DATA_SPOT)
        Else
            ENM_CHANGE_MODE = ENM_MY_WINDOW_MODE.INPUT_DATA_INSERT
            With SRT_ALREADY
                .COUNT_INVOICE_ALREADY = 0
                .COUNT_DEPOSIT_ALREADY = 0
            End With
        End If
        Call SUB_REFRESH_ID_DONE(SRT_ALREADY)
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

        Dim SRT_RECORD As SRT_TABLE_MNT_T_CONTRACT
        SRT_RECORD.KEY = FUNC_GET_INPUT_KEY()
        SRT_RECORD.DATA = FUNC_GET_INPUT_DATA()

        Dim SRT_RECORD_SPOT As SRT_TABLE_MNT_T_CONTRACT_SPOT
        SRT_RECORD_SPOT.KEY = FUNC_GET_INPUT_SPOT_KEY()
        SRT_RECORD_SPOT.DATA = FUNC_GET_INPUT_SPOT_DATA()

        If Not FUNC_SYSTEM_BEGIN_TRANSACTION() Then
            Call MessageBox.Show(FUNC_SYSTEM_SQLGET_ERR_MESSAGE(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If ENM_WINDOW_MODE_CURRENT = ENM_MY_WINDOW_MODE.INPUT_DATA_INSERT Then '新規の場合は
            Dim INT_NUMBER_CONTRACT As Integer
            INT_NUMBER_CONTRACT = FUNC_CHECK_GET_NUMBER_CONTRACT(SRT_RECORD.KEY.NUMBER_CONTRACT)

            SRT_RECORD.KEY.NUMBER_CONTRACT = INT_NUMBER_CONTRACT
            SRT_RECORD_SPOT.KEY.NUMBER_CONTRACT = INT_NUMBER_CONTRACT
        End If

        Select Case ENM_WINDOW_MODE_CURRENT
            Case ENM_MY_WINDOW_MODE.INPUT_DATA_INSERT, ENM_MY_WINDOW_MODE.INPUT_DATA_UPDATE_NORMAL, ENM_MY_WINDOW_MODE.INPUT_DATA_UPDATE_INVOICE
                If Not FUNC_INSERT_RECORD(SRT_RECORD, SRT_RECORD_SPOT) Then
                    Call MessageBox.Show(FUNC_SYSTEM_SQLGET_ERR_MESSAGE(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Call FUNC_SYSTEM_ROLLBACK_TRANSACTION()
                    Exit Sub
                End If
            Case Else
                'スルー
        End Select

        If Not FUNC_SYSTEM_COMMIT_TRANSACTION() Then
            Call MessageBox.Show(FUNC_SYSTEM_SQLGET_ERR_MESSAGE(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If ENM_WINDOW_MODE_CURRENT = ENM_MY_WINDOW_MODE.INPUT_DATA_INSERT Then
            Dim STR_MSG As String
            STR_MSG = ""
            STR_MSG &= "契約番号：" & SRT_RECORD.KEY.NUMBER_CONTRACT & System.Environment.NewLine
            STR_MSG &= "登録しました。" & System.Environment.NewLine
            Call MessageBox.Show(STR_MSG, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Call SUB_CLEAR()
    End Sub

#Region "登録等の内部処理"
    Private Function FUNC_CHECK_GET_NUMBER_CONTRACT(ByVal INT_NUMBER_CONTRACT As Integer) As Integer

        Dim SRT_KEY As SRT_TABLE_MNT_T_CONTRACT_KEY
        With SRT_KEY
            .NUMBER_CONTRACT = INT_NUMBER_CONTRACT
            .SERIAL_CONTRACT = 1
        End With

        Dim BLN_CHECK As Boolean
        BLN_CHECK = FUNC_CHECK_TABLE_MNT_T_CONTRACT(SRT_KEY) '既に該当の契約番号でレコードがあるか
        If Not BLN_CHECK Then '無ければ
            Return INT_NUMBER_CONTRACT 'その番号が使用可能
        End If

        '使用出来ない場合
        Dim INT_RET As Integer
        INT_RET = FUNC_GET_NUMBER_CONTRACT_NEW(True) '新規で採番
        Return INT_RET
    End Function

    Private Function FUNC_INSERT_RECORD(ByRef SRT_RECORD As SRT_TABLE_MNT_T_CONTRACT, ByRef SRT_RECORD_SPOT As SRT_TABLE_MNT_T_CONTRACT_SPOT) As Boolean

        Dim SRT_INVOICE_ROW() As SRT_TABLE_MNT_T_INVOICE
        SRT_INVOICE_ROW = FUNC_GET_INVOICE_RECORD_ALL(SRT_RECORD.KEY.NUMBER_CONTRACT, SRT_RECORD.KEY.SERIAL_CONTRACT)

        Dim SRT_DEPOSIT_ROW() As SRT_TABLE_MNT_T_DEPOSIT
        SRT_DEPOSIT_ROW = FUNC_GET_DEPOSIT_RECORD_ALL(SRT_RECORD.KEY.NUMBER_CONTRACT, SRT_RECORD.KEY.SERIAL_CONTRACT)

        If Not FUNC_DELETE_TABLE_MNT_T_CONTRACT(SRT_RECORD.KEY) Then 'SPOT,INVOICE,DEPOSITも連動して削除
            Return False
        End If

        If Not FUNC_INSERT_TABLE_MNT_T_CONTRACT(SRT_RECORD) Then
            Return False
        End If

        If Not FUNC_INSERT_TABLE_MNT_T_CONTRACT_SPOT(SRT_RECORD_SPOT) Then
            Return False
        End If

        For i = 1 To (SRT_INVOICE_ROW.Length - 1)
            If Not FUNC_INSERT_TABLE_MNT_T_INVOICE(SRT_INVOICE_ROW(i)) Then
                Return False
            End If
        Next

        For i = 1 To (SRT_DEPOSIT_ROW.Length - 1)
            If Not FUNC_INSERT_TABLE_MNT_T_DEPOSIT(SRT_DEPOSIT_ROW(i)) Then
                Return False
            End If
        Next

        Return True
    End Function
#End Region

    '削除
    Private Sub SUB_DELETE()

        Dim RST_MSG As System.Windows.Forms.DialogResult
        RST_MSG = MessageBox.Show("データを削除します。" & Environment.NewLine & "よろしいですか？", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If RST_MSG = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        Dim SRT_KEY As SRT_TABLE_MNT_T_CONTRACT_KEY
        SRT_KEY = FUNC_GET_INPUT_KEY()

        If Not FUNC_SYSTEM_BEGIN_TRANSACTION() Then
            Call MessageBox.Show(FUNC_SYSTEM_SQLGET_ERR_MESSAGE(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Not FUNC_DELETE_TABLE_MNT_T_CONTRACT(SRT_KEY) Then
            Call FUNC_SYSTEM_ROLLBACK_TRANSACTION()
            Call MessageBox.Show(FUNC_SYSTEM_SQLGET_ERR_MESSAGE(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Not FUNC_SYSTEM_COMMIT_TRANSACTION() Then
            Call MessageBox.Show(FUNC_SYSTEM_SQLGET_ERR_MESSAGE(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Call SUB_CLEAR()

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

#Region "画面コントロール←→構造体"

    Private Function FUNC_GET_INPUT_KEY() As SRT_TABLE_MNT_T_CONTRACT_KEY
        Dim SRT_RET As SRT_TABLE_MNT_T_CONTRACT_KEY

        With SRT_RET
            .NUMBER_CONTRACT = CInt(TXT_NUMBER_CONTRACT.Text)
            .SERIAL_CONTRACT = 1
        End With

        Return SRT_RET
    End Function

    Private Function FUNC_GET_INPUT_DATA() As SRT_TABLE_MNT_T_CONTRACT_DATA
        Dim SRT_RET As SRT_TABLE_MNT_T_CONTRACT_DATA

        With SRT_RET
            .KIND_CONTRACT = ENM_SYSTEM_INDIVIDUAL_KIND_CONTRACT.SPOT
            .DATE_CONTRACT = DTP_DATE_CONTRACT.Value
            .CODE_OWNER = CInt(TXT_CODE_OWNER.Text)
            .CODE_SECTION = FUNC_GET_COMBO_KIND_CODE(CMB_CODE_SECTION)
            .CODE_WORK = FUNC_GET_COMBO_KIND_CODE(CMB_CODE_WORK)
            .NAME_CONTRACT = TXT_NAME_CONTRACT.Text
            .DATE_WORK_FROM = DTP_DATE_WORK_FROM.Value
            .DATE_WORK_TO = DTP_DATE_WORK_TO.Value
            .DATE_INVOICE_BASE = DTP_DATE_INVOICE_BASE.Value
            .SPAN_INVOICE = 1
            .COUNT_INVOICE = 1
            .NUMBER_LIST_INVOICE = 0
            .KINGAKU_CONTRACT = CLng(TXT_KINGAKU_CONTRACT.Text)
            .NAME_MEMO = TXT_NAME_MEMO.Text
            .CODE_STAFF = srtSYSTEM_TOTAL_COMMANDLINE.CODE_STAFF
            .DATE_ACTIVE = System.DateTime.Today
        End With

        Return SRT_RET
    End Function

    Private Function FUNC_GET_INPUT_SPOT_KEY() As SRT_TABLE_MNT_T_CONTRACT_SPOT_KEY
        Dim SRT_RET As SRT_TABLE_MNT_T_CONTRACT_SPOT_KEY

        With SRT_RET
            .NUMBER_CONTRACT = CInt(TXT_NUMBER_CONTRACT.Text)
            .SERIAL_CONTRACT = 1
        End With

        Return SRT_RET
    End Function

    Private Function FUNC_GET_INPUT_SPOT_DATA() As SRT_TABLE_MNT_T_CONTRACT_SPOT_DATA
        Dim SRT_RET As SRT_TABLE_MNT_T_CONTRACT_SPOT_DATA

        With SRT_RET
            .NUMBER_ORDER = CInt(TXT_NUMBER_ORDER.Text)
            .NAME_OWNER = TXT_NAME_OWNER.Text
            .CODE_POST = TXT_CODE_POST.Text
            .NAME_ADDRESS_01 = TXT_NAME_ADDRESS_01.Text
            .NAME_ADDRESS_02 = TXT_NAME_ADDRESS_02.Text
        End With

        Return SRT_RET
    End Function

    Private Sub SUB_SET_INPUT_DATA(ByRef SRT_DATA As SRT_TABLE_MNT_T_CONTRACT_DATA)

        With SRT_DATA
            Call SUB_CONTROL_SET_VALUE_DateTimePicker(DTP_DATE_CONTRACT, .DATE_CONTRACT)
            TXT_CODE_OWNER.Text = Format(.CODE_OWNER, New String("0", TXT_CODE_OWNER.MaxLength))
            Call SUB_SET_COMBO_KIND_CODE(CMB_CODE_SECTION, .CODE_SECTION)
            Dim INT_KIND_WORK As Integer
            INT_KIND_WORK = FUNC_GET_MNT_M_WORK_KIND_WORK(.CODE_WORK, True)
            Call SUB_SET_COMBO_KIND_CODE(CMB_KIND_WORK, INT_KIND_WORK)
            Call SUB_SET_COMBO_KIND_CODE(CMB_CODE_WORK, .CODE_WORK)

            TXT_NAME_CONTRACT.Text = .NAME_CONTRACT
            Call SUB_CONTROL_SET_VALUE_DateTimePicker(DTP_DATE_WORK_FROM, .DATE_WORK_FROM)
            Call SUB_CONTROL_SET_VALUE_DateTimePicker(DTP_DATE_WORK_TO, .DATE_WORK_TO)
            Call SUB_CONTROL_SET_VALUE_DateTimePicker(DTP_DATE_INVOICE_BASE, .DATE_INVOICE_BASE)
            TXT_KINGAKU_CONTRACT.Text = Format(.KINGAKU_CONTRACT, "#,##0")
            TXT_NAME_MEMO.Text = .NAME_MEMO
        End With

    End Sub

    Private Sub SUB_SET_INPUT_SPOT_DATA(ByRef SRT_DATA As SRT_TABLE_MNT_T_CONTRACT_SPOT_DATA)

        With SRT_DATA
            TXT_NUMBER_ORDER.Text = Format(.NUMBER_ORDER, New String("0", TXT_NUMBER_ORDER.MaxLength))
            TXT_NAME_OWNER.Text = .NAME_OWNER
            TXT_CODE_POST.Text = .CODE_POST
            TXT_NAME_ADDRESS_01.Text = .NAME_ADDRESS_01
            TXT_NAME_ADDRESS_02.Text = .NAME_ADDRESS_02
        End With

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
                PNL_INPUT_DATA.Enabled = False

                BTN_ENTER.Enabled = False
                BTN_DELETE.Enabled = False
                BTN_CLEAR.Enabled = True
                BTN_END.Enabled = True
            Case ENM_MY_WINDOW_MODE.INPUT_DATA_INSERT
                PNL_INPUT_KEY.Enabled = False
                PNL_INPUT_DATA.Enabled = True

                BTN_ENTER.Enabled = True
                BTN_DELETE.Enabled = False
                BTN_CLEAR.Enabled = True
                BTN_END.Enabled = True
            Case ENM_MY_WINDOW_MODE.INPUT_DATA_UPDATE_NORMAL
                PNL_INPUT_KEY.Enabled = False
                PNL_INPUT_DATA.Enabled = True
                PNL_DATE_INVOICE_BASE.Enabled = True
                PNL_KINGAKU_CONTRACT.Enabled = True

                BTN_ENTER.Enabled = True
                BTN_DELETE.Enabled = True
                BTN_CLEAR.Enabled = True
                BTN_END.Enabled = True
            Case ENM_MY_WINDOW_MODE.INPUT_DATA_UPDATE_INVOICE
                PNL_INPUT_KEY.Enabled = False
                PNL_INPUT_DATA.Enabled = True
                PNL_DATE_INVOICE_BASE.Enabled = False
                PNL_KINGAKU_CONTRACT.Enabled = False

                BTN_ENTER.Enabled = True
                BTN_DELETE.Enabled = True
                BTN_CLEAR.Enabled = True
                BTN_END.Enabled = True
            Case Else
                'スルー
        End Select

        Call SUB_REMOVE_TEXTBOX(txtDUMMY, Me)

        ENM_WINDOW_MODE_CURRENT = enmCHANGE_MODE
        Call Application.DoEvents()
    End Sub

    Private Sub SUB_REFRESH_ENABLD_EXT_SPOT()
        Dim INT_CODE_OWNER As Integer
        If IsNumeric(TXT_CODE_OWNER.Text) Then
            INT_CODE_OWNER = CInt(TXT_CODE_OWNER.Text)
        Else
            INT_CODE_OWNER = -1
        End If

        Dim ENM_KIND_OWNER As ENM_SYSTEM_INDIVIDUAL_KIND_OWNER
        ENM_KIND_OWNER = FUNC_GET_MNT_M_OWNER_KIND_OWNER(INT_CODE_OWNER, True)

        Dim BLN_EANBLED As Boolean
        Select Case ENM_KIND_OWNER
            Case ENM_SYSTEM_INDIVIDUAL_KIND_OWNER.NORMAL
                BLN_EANBLED = False
            Case ENM_SYSTEM_INDIVIDUAL_KIND_OWNER.SPOT
                BLN_EANBLED = True
            Case Else
                BLN_EANBLED = False
        End Select

        If BLN_EANBLED Then
            TXT_NAME_OWNER.Text = ""
            TXT_CODE_POST.Text = ""
            TXT_NAME_ADDRESS_01.Text = ""
            TXT_NAME_ADDRESS_02.Text = ""
        Else
            TXT_NAME_OWNER.Text = FUNC_GET_MNT_M_OWNER_NAME_OWNER(INT_CODE_OWNER, True)
            TXT_CODE_POST.Text = FUNC_GET_MNT_M_OWNER_CODE_POST(INT_CODE_OWNER, True)
            TXT_NAME_ADDRESS_01.Text = FUNC_GET_MNT_M_OWNER_NAME_ADDRESS_01(INT_CODE_OWNER, True)
            TXT_NAME_ADDRESS_02.Text = FUNC_GET_MNT_M_OWNER_NAME_ADDRESS_02(INT_CODE_OWNER, True)
        End If

        PNL_EXT_SPOT.Enabled = BLN_EANBLED
    End Sub
#End Region

#Region "チェック処理"
    Private Function FUNC_CHECK_INPUT_KEY() As Boolean

        Dim CTL_CONTROL As Control
        CTL_CONTROL = Nothing
        'Enable = True の入力項目すべてチェック対象(TAG=Check)
        Dim ENM_ERR_CODE As CONTROL_CHECK_ERR_CODE
        Dim STR_ERR_MSG As String
        If Not FUNC_CONTROL_CHECK_INPUT_FORM_CONTROLS(PNL_INPUT_KEY, CTL_CONTROL, ENM_ERR_CODE, "Check") Then
            STR_ERR_MSG = FUNC_GET_MESSAGE_CTRL_CHECK(ENM_ERR_CODE, FUNC_GET_TEXT_GUIDE_LABEL(CTL_CONTROL))
            Call MessageBox.Show(STR_ERR_MSG, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Call CTL_CONTROL.Focus()
            Return False
        End If

        CTL_CONTROL = TXT_NUMBER_CONTRACT
        If Not IsNumeric(CTL_CONTROL.Text) Then '契約番号が入力されていない場合は
            Return True '以後のチェックは全てパスする
        End If
        Dim INT_NUMBER_CONTRACT As Integer
        INT_NUMBER_CONTRACT = CInt(CTL_CONTROL.Text)
        Dim SRT_KEY As SRT_TABLE_MNT_T_CONTRACT_KEY
        Dim SRT_DATA As SRT_TABLE_MNT_T_CONTRACT_DATA


        With SRT_KEY
            .NUMBER_CONTRACT = INT_NUMBER_CONTRACT
            .SERIAL_CONTRACT = 1
        End With
        If Not FUNC_CHECK_TABLE_MNT_T_CONTRACT(SRT_KEY) Then
            STR_ERR_MSG = FUNC_GET_INPUT_CHECK_ERROR_MESSAGE(ENM_SYSTEM_INDIVIDUAL_INPUT_CHECK.CHK_ERR_NO_DATA, FUNC_GET_TEXT_GUIDE_LABEL(CTL_CONTROL))
            Call MessageBox.Show(STR_ERR_MSG, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Call CTL_CONTROL.Focus()
            Return False
        End If
        SRT_DATA = Nothing
        Call FUNC_SELECT_TABLE_MNT_T_CONTRACT(SRT_KEY, SRT_DATA)
        If Not (SRT_DATA.KIND_CONTRACT = ENM_SYSTEM_INDIVIDUAL_KIND_CONTRACT.SPOT) Then
            Dim STR_NAME_KIND As String
            STR_NAME_KIND = FUNC_GET_MNT_M_KIND_NAME_KIND(ENM_MNT_M_KIND_CODE_FLAG.KIND_CONTRACT, ENM_SYSTEM_INDIVIDUAL_KIND_CONTRACT.SPOT)
            STR_ERR_MSG = ""
            STR_ERR_MSG &= "入力された" & FUNC_GET_TEXT_GUIDE_LABEL(CTL_CONTROL) & "は"
            STR_ERR_MSG &= "「" & STR_NAME_KIND & "」" & "の契約ではありません。"
            Call MessageBox.Show(STR_ERR_MSG, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Call CTL_CONTROL.Focus()
            Return False
        End If

        Return True
    End Function

    Private Function FUNC_CHECK_INPUT_DATA() As Boolean

        Dim CTL_CONTROL As Control
        CTL_CONTROL = Nothing
        'Enable = True の入力項目すべてチェック対象(TAG=Check)

        Dim ENM_ERR_CODE As CONTROL_CHECK_ERR_CODE
        Dim STR_ERR_MSG As String
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
            Case (CTL_ACTIVE Is TXT_NUMBER_CONTRACT)
                Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_DATA_EDIT)
                BLN_RET = False
            Case (CTL_ACTIVE Is CMB_CODE_WORK)
                SUB_REFRESH_NAME_COTRACT()
                BLN_RET = True
            Case Else
                BLN_RET = True
        End Select

        CTL_ACTIVE = Nothing

        Return BLN_RET
    End Function
#End Region

#Region "その他処理"
    Private Sub SUB_REFRESH_DATE_WORK()
        Dim DAT_SET_FROM As DateTime
        DAT_SET_FROM = DTP_DATE_CONTRACT.Value.AddDays(-1)

        Call SUB_CONTROL_SET_VALUE_DateTimePicker(DTP_DATE_WORK_FROM, DAT_SET_FROM)

        Call SUB_REFRESH_DATE_WORK_TO_VALUE()
    End Sub

    Private Sub SUB_REFRESH_DATE_WORK_TO_VALUE()
        Dim DAT_FROM As DateTime
        DAT_FROM = DTP_DATE_WORK_FROM.Value
        Dim DAT_SET As DateTime
        DAT_SET = DAT_FROM
        Call SUB_CONTROL_SET_VALUE_DateTimePicker(DTP_DATE_WORK_TO, DAT_SET)
    End Sub

    Private Sub SUB_REFRESH_DATE_INVOICE_BASE_VALUE()

        Dim INT_CODE_OWNER As Integer
        INT_CODE_OWNER = FUNC_VALUE_CONVERT_NUMERIC_INT(TXT_CODE_OWNER.Text)
        Dim ENM_KIND_FIX_DATE As ENM_SYSTEM_INDIVIDUAL_KIND_FIXED_DATE
        ENM_KIND_FIX_DATE = FUNC_GET_MNT_M_OWNER_KIND_FIXED_DATE(INT_CODE_OWNER, True)
        If ENM_KIND_FIX_DATE <= 0 Then
            ENM_KIND_FIX_DATE = ENM_SYSTEM_INDIVIDUAL_KIND_FIXED_DATE.FIX_LAST
        End If

        Dim DAT_DATE_WORK_FROM As DateTime
        DAT_DATE_WORK_FROM = DTP_DATE_WORK_FROM.Value

        Dim DAT_DATE_CALC_BASE As DateTime
        DAT_DATE_CALC_BASE = DTP_DATE_WORK_TO.Value 'FUNC_GET_DATE_FIRSMONTH(DAT_DATE_WORK_FROM.AddMonths(1))

        Dim DAT_SET As DateTime
        Select Case ENM_KIND_FIX_DATE
            Case ENM_SYSTEM_INDIVIDUAL_KIND_FIXED_DATE.FIX_10, ENM_SYSTEM_INDIVIDUAL_KIND_FIXED_DATE.FIX_20, ENM_SYSTEM_INDIVIDUAL_KIND_FIXED_DATE.FIX_25
                If CInt(ENM_KIND_FIX_DATE) < DAT_DATE_CALC_BASE.Day Then '作業開始が請求基準より大きい場合
                    Dim DAT_CALC As DateTime
                    DAT_CALC = DAT_DATE_CALC_BASE.AddMonths(1) '翌月基準
                    DAT_SET = New Date(DAT_CALC.Year, DAT_CALC.Month, CInt(ENM_KIND_FIX_DATE))
                Else
                    DAT_SET = New Date(DAT_DATE_CALC_BASE.Year, DAT_DATE_CALC_BASE.Month, CInt(ENM_KIND_FIX_DATE))
                End If
            Case ENM_SYSTEM_INDIVIDUAL_KIND_FIXED_DATE.FIX_LAST
                DAT_SET = FUNC_GET_DATE_LASTMONTH(DAT_DATE_CALC_BASE)
        End Select

        Call SUB_CONTROL_SET_VALUE_DateTimePicker(DTP_DATE_INVOICE_BASE, DAT_SET)
    End Sub

    Private Sub SUB_REFRESH_ID_DONE(ByRef SRT_DATA As SRT_COUNT_ALREADY)
        Dim ENM_DONE_INVOICE As ENM_SYSTEM_INDIVIDUAL_FLAG_DONE
        ENM_DONE_INVOICE = If(SRT_DATA.COUNT_INVOICE_ALREADY > 0, ENM_SYSTEM_INDIVIDUAL_FLAG_DONE.DONE, ENM_SYSTEM_INDIVIDUAL_FLAG_DONE.NOT_DONE)
        LBL_INVOICE_DONE.Text = FUNC_GET_MNT_M_KIND_NAME_KIND(ENM_MNT_M_KIND_CODE_FLAG.FLAG_DONE, ENM_DONE_INVOICE)

        Dim ENM_DONE_DEPOSIT As ENM_SYSTEM_INDIVIDUAL_FLAG_DONE
        ENM_DONE_DEPOSIT = If(SRT_DATA.COUNT_DEPOSIT_ALREADY > 0, ENM_SYSTEM_INDIVIDUAL_FLAG_DONE.DONE, ENM_SYSTEM_INDIVIDUAL_FLAG_DONE.NOT_DONE)
        LBL_DEPOSIT_DONE.Text = FUNC_GET_MNT_M_KIND_NAME_KIND(ENM_MNT_M_KIND_CODE_FLAG.FLAG_DONE, ENM_DONE_DEPOSIT)
    End Sub

    Private Sub SUB_REFRESH_CODE_WORK()
        Dim INT_KIND_WORK As Integer
        INT_KIND_WORK = FUNC_GET_COMBO_KIND_CODE(CMB_KIND_WORK)
        Call SUB_SYSTEM_COMMBO_MNT_M_WORK(CMB_CODE_WORK, INT_KIND_WORK)
        Call SUB_SET_COMBO_KIND_CODE_FIRST(CMB_CODE_WORK)
    End Sub

    Private Sub SUB_REFRESH_NAME_COTRACT()

        If Not (TXT_NAME_CONTRACT.Text = "") Then
            Exit Sub
        End If

        TXT_NAME_CONTRACT.Text = CMB_CODE_WORK.Text
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
    Private Sub BTN_ENTER_Click(sender As Object, e As EventArgs) Handles BTN_ENTER.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_ENTER)
    End Sub

    Private Sub BTN_DELETE_Click(sender As Object, e As EventArgs) Handles BTN_DELETE.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_DELETE)
    End Sub

    Private Sub BTN_CLEAR_Click(sender As Object, e As EventArgs) Handles BTN_CLEAR.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_CLEAR)
    End Sub

    Private Sub BTN_END_Click(sender As Object, e As EventArgs) Handles BTN_END.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_END)
    End Sub

    Private Sub BTN_CODE_OWNER_SEARCH_Click(sender As Object, e As EventArgs) Handles BTN_CODE_OWNER_SEARCH.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_SHOW_SEARCH)
    End Sub
#End Region

#Region "イベント-テキストチェンジ"
    Private Sub TXT_CODE_OWNER_TextChanged(sender As Object, e As EventArgs) Handles TXT_CODE_OWNER.TextChanged
        Call SUB_GET_NAME_OWNER_INPUT(sender)

        Call SUB_REFRESH_ENABLD_EXT_SPOT()
        Call SUB_REFRESH_DATE_INVOICE_BASE_VALUE()
    End Sub
#End Region

#Region "イベント-バリューチェンジ"

    Private Sub DTP_DATE_CONTRACT_ValueChanged(sender As Object, e As EventArgs) Handles DTP_DATE_CONTRACT.ValueChanged
        Call SUB_REFRESH_DATE_WORK()
    End Sub

    Private Sub DTP_DATE_WORK_FROM_ValueChanged(sender As Object, e As EventArgs) Handles DTP_DATE_WORK_FROM.ValueChanged
        Call SUB_REFRESH_DATE_WORK_TO_VALUE()
    End Sub

    Private Sub DTP_DATE_WORK_TO_ValueChanged(sender As Object, e As EventArgs) Handles DTP_DATE_WORK_TO.ValueChanged
        Call SUB_REFRESH_DATE_INVOICE_BASE_VALUE()
    End Sub
#End Region

#Region "イベント-インデックスチェンジ"

    Private Sub CMB_KIND_WORK_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_KIND_WORK.SelectedIndexChanged
        Call SUB_REFRESH_CODE_WORK()
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
