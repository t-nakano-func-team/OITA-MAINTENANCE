Public Class FRM_SUB_01

#Region "画面用・定数"
#End Region

#Region "画面用・列挙定数"
    Private Enum ENM_MY_EXEC_DO
        DO_SHOW_SEARCH = 1
        DO_ENTER
        DO_CLEAR
        DO_END = 81
        DO_SHOW_SETTING
        DO_SHOW_COMMANDLINE
        DO_SHOW_CONFIG_SETTINGS
    End Enum

    Private Enum ENM_MY_WINDOW_MODE
        INPUT_DATA
    End Enum

#End Region

#Region "画面用・構造体"

#End Region

#Region "画面用・変数"
    Private BLN_PROCESS_DOING As Boolean
    Private ENM_WINDOW_MODE_CURRENT As ENM_MY_WINDOW_MODE '現在の画面状態
    Private SRT_RECORD As SRT_TABLE_MNT_T_INVOICE
    Private SRT_RECORD_DEPOSIT As SRT_TABLE_MNT_T_DEPOSIT
#End Region

#Region "プロパティ用"
    Private BLN_PROPERTY_EDIT_CANCEL As Boolean 'キャンセルフラグ(True:キャンセル / False:決定)
    Private INT_PROPERTY_NUMBER_CONTRACT As Integer
    Private INT_PROPERTY_SERIAL_CONTRACT As Integer
    Private INT_PROPERTY_SERIAL_INVOICE As Integer
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

    Friend Property SERIAL_INVOICE() As Integer
        Get
            Return INT_PROPERTY_SERIAL_INVOICE
        End Get
        Set(ByVal Value As Integer)
            INT_PROPERTY_SERIAL_INVOICE = Value
        End Set
    End Property

#End Region

#Region "初期化・終了処理"
    Private Sub SUB_CTRL_NEW_INIT()
        Call SUB_CTRL_EVENT_HANDLED_ADD()
    End Sub

    Private Sub SUB_CTRL_VIEW_INIT()
        Me.RET_EDIT_CANCEL = True

        With SRT_RECORD.KEY
            .NUMBER_CONTRACT = Me.NUMBER_CONTRACT
            .SERIAL_CONTRACT = Me.SERIAL_CONTRACT
            .SERIAL_INVOICE = Me.SERIAL_INVOICE
        End With
        SRT_RECORD.DATA = Nothing
        Call FUNC_SELECT_TABLE_MNT_T_INVOICE(SRT_RECORD.KEY, SRT_RECORD.DATA)

        With SRT_RECORD_DEPOSIT.KEY
            .NUMBER_CONTRACT = Me.NUMBER_CONTRACT
            .SERIAL_CONTRACT = Me.SERIAL_CONTRACT
            .SERIAL_INVOICE = Me.SERIAL_INVOICE
        End With
        SRT_RECORD_DEPOSIT.DATA = Nothing
        Call FUNC_SELECT_TABLE_MNT_T_DEPOSIT(SRT_RECORD_DEPOSIT.KEY, SRT_RECORD_DEPOSIT.DATA)

        Dim DAT_DATE_INPUT_MAX As DateTime
        DAT_DATE_INPUT_MAX = datSYSTEM_TOTAL_DATE_ACTIVE.AddMonths(1)
        Call SUB_CONTROL_INITALIZE_DateTimePicker(DTP_DATE_DEPOSIT, srtSYSTEM_TOTAL_CONFIG_SETTINGS.LOCAL.DATE_SYSTEM_REPLACE, DAT_DATE_INPUT_MAX)

        Call SUB_SYSTEM_COMMBO_MNT_M_SECTION(CMB_CODE_SECTION)

        Call SUB_SYSTEM_COMMBO_MNT_M_ACCOUNT(CMB_KIND_SALE, ENM_SYSTEM_INDIVIDUAL_FLAG_ACCOUNT.KIND_SALE)
        Call SUB_SYSTEM_COMMBO_MNT_M_ACCOUNT(CMB_KIND_DEPOSIT, ENM_SYSTEM_INDIVIDUAL_FLAG_ACCOUNT.KIND_DEPOSIT)
        Call SUB_SYSTEM_COMMBO_MNT_M_ACCOUNT(CMB_KIND_DEPOSIT_SUB, ENM_SYSTEM_INDIVIDUAL_FLAG_ACCOUNT.KIND_PAYEE)
        Call SUB_SYSTEM_COMMBO_MNT_M_ACCOUNT(CMB_KIND_COST, ENM_SYSTEM_INDIVIDUAL_FLAG_ACCOUNT.KIND_COST, True, "なし")
    End Sub

    Private Sub SUB_CTRL_VALUE_INIT()
        Call SUB_CONTROL_CLEAR_FORM(Me)

        LBL_NAME_USER_HEAD.Text = FUNC_GET_MNG_M_USER_NAME_STAFF(srtSYSTEM_TOTAL_COMMANDLINE.CODE_STAFF)
        LBL_DATE_ACTIVE_HEAD.Text = Format(datSYSTEM_TOTAL_DATE_ACTIVE, "yyyy年MM月dd日")

        Call SUB_SET_INPUT_KEY(SRT_RECORD.KEY)
        Call SUB_SET_INPUT_DATA(SRT_RECORD.DATA)

        Call SUB_SET_INPUT_DATA_DEPOSIT(SRT_RECORD_DEPOSIT.DATA)
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
            Case ENM_MY_EXEC_DO.DO_ENTER
                Call SUB_ENTER()
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
    Private Sub SUB_ENTER()
        If Not FUNC_CHECK_INPUT_DATA() Then
            Exit Sub
        End If

        Dim RST_MSG As System.Windows.Forms.DialogResult
        RST_MSG = MessageBox.Show("データを登録します。" & Environment.NewLine & "よろしいですか？", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If RST_MSG = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        Dim SRT_UPDATE As SRT_TABLE_MNT_T_INVOICE
        SRT_UPDATE.KEY = FUNC_GET_INPUT_KEY()
        SRT_UPDATE.DATA = FUNC_GET_INPUT_DATA()

        Dim SRT_INSERT As SRT_TABLE_MNT_T_DEPOSIT
        SRT_INSERT.KEY = FUNC_GET_INPUT_KEY_DEPOSIT()
        SRT_INSERT.DATA = FUNC_GET_INPUT_DATA_DEPOSIT()

        If Not FUNC_SYSTEM_BEGIN_TRANSACTION() Then
            Call MessageBox.Show(FUNC_SYSTEM_SQLGET_ERR_MESSAGE(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Not FUNC_INSERT_RECORD(SRT_UPDATE, CHK_FLAG_DEPOSIT_DONE.Checked, SRT_INSERT) Then
            Call MessageBox.Show(FUNC_SYSTEM_SQLGET_ERR_MESSAGE(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Call FUNC_SYSTEM_ROLLBACK_TRANSACTION()
            Exit Sub
        End If

        If Not FUNC_SYSTEM_COMMIT_TRANSACTION() Then
            Call MessageBox.Show(FUNC_SYSTEM_SQLGET_ERR_MESSAGE(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Me.RET_EDIT_CANCEL = False
        Call SUB_END()

    End Sub

#Region "登録時の内部処理"
    Private Function FUNC_INSERT_RECORD(ByRef SRT_RECORD As SRT_TABLE_MNT_T_INVOICE, ByVal BLN_ADD_DEPOSIT As Boolean, ByRef SRT_RECORD_DEPOSIT As SRT_TABLE_MNT_T_DEPOSIT) As Boolean

        If Not FUNC_DELETE_TABLE_MNT_T_INVOICE(SRT_RECORD.KEY) Then
            Return False
        End If

        If Not FUNC_INSERT_TABLE_MNT_T_INVOICE(SRT_RECORD) Then
            Return False
        End If

        If BLN_ADD_DEPOSIT Then
            If Not FUNC_INSERT_TABLE_MNT_T_DEPOSIT(SRT_RECORD_DEPOSIT) Then
                Return False
            End If
        End If

        Return True
    End Function
#End Region

    Private Sub SUB_CLEAR()
        Call SUB_CONTROL_CLEAR_FORM(Me)
        Call SUB_CTRL_VALUE_INIT() '値を初期化
        Call SUB_WINDOW_MODE_CHANGE(ENM_MY_WINDOW_MODE.INPUT_DATA)
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

#Region "画面コントロール←→構造体"

    Private Sub SUB_SET_INPUT_KEY(ByRef SRT_DATA As SRT_TABLE_MNT_T_INVOICE_KEY)

        With SRT_DATA
            Dim SRT_CONTRACT As SRT_TABLE_MNT_T_CONTRACT
            SRT_CONTRACT.KEY.NUMBER_CONTRACT = .NUMBER_CONTRACT
            SRT_CONTRACT.KEY.SERIAL_CONTRACT = .SERIAL_CONTRACT
            SRT_CONTRACT.DATA = Nothing
            Call FUNC_SELECT_TABLE_MNT_T_CONTRACT(SRT_CONTRACT.KEY, SRT_CONTRACT.DATA, True)

            Dim SRT_CONTRACT_SPOT As SRT_TABLE_MNT_T_CONTRACT_SPOT
            SRT_CONTRACT_SPOT.KEY.NUMBER_CONTRACT = .NUMBER_CONTRACT
            SRT_CONTRACT_SPOT.KEY.SERIAL_CONTRACT = .SERIAL_CONTRACT
            SRT_CONTRACT_SPOT.DATA = Nothing
            Call FUNC_SELECT_TABLE_MNT_T_CONTRACT_SPOT(SRT_CONTRACT_SPOT.KEY, SRT_CONTRACT_SPOT.DATA)

            Dim SRT_INVOICE_DATA As SRT_TABLE_MNT_T_INVOICE_DATA
            SRT_INVOICE_DATA = Nothing
            Call FUNC_SELECT_TABLE_MNT_T_INVOICE(SRT_DATA, SRT_INVOICE_DATA)

            LBL_CODE_OWNER.Text = Format(SRT_CONTRACT.DATA.CODE_OWNER, New String("0", INT_SYSTEM_CODE_OWNER_MAX_LENGTH))
            Dim STR_NAME_OWNER As String
            Select Case SRT_CONTRACT.DATA.KIND_CONTRACT
                Case ENM_SYSTEM_INDIVIDUAL_KIND_CONTRACT.SPOT
                    STR_NAME_OWNER = SRT_CONTRACT_SPOT.DATA.NAME_OWNER
                Case ENM_SYSTEM_INDIVIDUAL_KIND_CONTRACT.REGULAR
                    STR_NAME_OWNER = FUNC_GET_MNT_M_OWNER_NAME_OWNER(SRT_CONTRACT.DATA.CODE_OWNER, True)
                Case Else
                    STR_NAME_OWNER = ""
            End Select
            LBL_CODE_OWNER_NAME.Text = STR_NAME_OWNER
            LBL_NAME_CONTRACT.Text = SRT_CONTRACT.DATA.NAME_CONTRACT
            LBL_NUMBER_CONTRACT.Text = Format(.NUMBER_CONTRACT, New String("0", INT_SYSTEM_NUMBER_CONTRACT_MAX_LENGTH))
            LBL_SERIAL_CONTRACT.Text = Format(.SERIAL_CONTRACT, New String("0", INT_SYSTEM_SERIAL_CONTRACT_MAX_LENGTH))
            LBL_DATE_INVOICE.Text = Format(SRT_INVOICE_DATA.DATE_INVOICE, "yyyy年MM月dd日")
            LBL_KINGAKU_CONTRACT.Text = Format(SRT_CONTRACT.DATA.KINGAKU_CONTRACT, "#,##0")
        End With

    End Sub

    Private Sub SUB_SET_INPUT_DATA(ByRef SRT_DATA As SRT_TABLE_MNT_T_INVOICE_DATA)
        With SRT_DATA
            TXT_KINGAKU_INVOICE_DETAIL.Text = Format(.KINGAKU_INVOICE_DETAIL, "#,##0")
            TXT_KINGAKU_INVOICE_VAT.Text = Format(.KINGAKU_INVOICE_VAT, "#,##0")
            Call SUB_REFRESH_KINGAKU_INVOICE_TOTAL()
            Call SUB_SET_COMBO_KIND_CODE(CMB_CODE_SECTION, .CODE_SECTION)

            Dim BLN_FLAG_DEPOSIT_DONE As Boolean
            BLN_FLAG_DEPOSIT_DONE = FUNC_GET_FLAG_DEPOSIT_DONE(SRT_RECORD.KEY.NUMBER_CONTRACT, SRT_RECORD.KEY.SERIAL_CONTRACT, SRT_RECORD.KEY.SERIAL_INVOICE)
            CHK_FLAG_DEPOSIT_DONE.Checked = BLN_FLAG_DEPOSIT_DONE
            Call SUB_REFRESH_DEPOSIT_INPUT_AREA()
        End With
    End Sub

    Private Sub SUB_SET_INPUT_DATA_DEPOSIT(ByRef SRT_DATA As SRT_TABLE_MNT_T_DEPOSIT_DATA)
        With SRT_DATA
            If CHK_FLAG_DEPOSIT_DONE.Checked Then
                Call SUB_CONTROL_SET_VALUE_DateTimePicker(DTP_DATE_DEPOSIT, .DATE_DEPOSIT)
                Call SUB_SET_COMBO_KIND_CODE(CMB_KIND_SALE, .KIND_SALE)
                Call SUB_SET_COMBO_KIND_CODE(CMB_KIND_DEPOSIT, .KIND_DEPOSIT)
                Call SUB_REFRSH_ENABLED_KIND_DEPOSIT_SUB()
                Call SUB_SET_COMBO_KIND_CODE(CMB_KIND_DEPOSIT_SUB, .KIND_DEPOSIT_SUB)
                CMB_KINGAKU_FEE_DETAIL.Text = Format(.KINGAKU_FEE_DETAIL, "#,##0")
                TXT_KINGAKU_FEE_VAT.Text = Format(.KINGAKU_FEE_VAT, "#,##0")
                Call SUB_REFRESH_KINGAKU_FEE_TOTAL()
                Call SUB_SET_COMBO_KIND_CODE(CMB_KIND_COST, .KIND_COST)
                Call SUB_REFRSH_ENABLED_KINGAKU_COST()
                TXT_KINGAKU_COST_DETAIL.Text = Format(.KINGAKU_COST_DETAIL, "#,##0")
                TXT_KINGAKU_COST_VAT.Text = Format(.KINGAKU_COST_VAT, "#,##0")
                Call SUB_REFRESH_KINGAKU_COST_TOTAL()
                TXT_NAME_MEMO.Text = .NAME_MEMO
                If .DATE_ACTIVE = datSYSTEM_TOTAL_DATE_ACTIVE Then
                    LBL_SERIAL_DEPOSIT.Text = .SERIAL_DEPOSIT
                Else
                    LBL_SERIAL_DEPOSIT.Text = FUNC_GET_MNT_T_DEPOSIT_MAX_SERIAL_DEPOSIT(datSYSTEM_TOTAL_DATE_ACTIVE) + 1
                End If
            Else
                Call SUB_CONTROL_SET_VALUE_DateTimePicker(DTP_DATE_DEPOSIT, datSYSTEM_TOTAL_DATE_ACTIVE)
                Call SUB_SET_COMBO_KIND_CODE_FIRST(CMB_KIND_SALE)
                Call SUB_SET_COMBO_KIND_CODE_FIRST(CMB_KIND_DEPOSIT)
                Call SUB_REFRSH_ENABLED_KIND_DEPOSIT_SUB()
                CMB_KINGAKU_FEE_DETAIL.Text = Format(0, "#,##0")
                TXT_KINGAKU_FEE_VAT.Text = Format(0, "#,##0")
                Call SUB_REFRESH_KINGAKU_FEE_TOTAL()
                Call SUB_SET_COMBO_KIND_CODE_FIRST(CMB_KIND_COST)
                Call SUB_REFRSH_ENABLED_KINGAKU_COST()
                TXT_KINGAKU_COST_DETAIL.Text = Format(0, "#,##0")
                TXT_KINGAKU_COST_VAT.Text = Format(0, "#,##0")
                Call SUB_REFRESH_KINGAKU_COST_TOTAL()
                TXT_NAME_MEMO.Text = ""
                LBL_SERIAL_DEPOSIT.Text = FUNC_GET_MNT_T_DEPOSIT_MAX_SERIAL_DEPOSIT(datSYSTEM_TOTAL_DATE_ACTIVE) + 1
            End If
        End With
    End Sub

    Private Function FUNC_GET_INPUT_KEY() As SRT_TABLE_MNT_T_INVOICE_KEY
        Return SRT_RECORD.KEY
    End Function

    Private Function FUNC_GET_INPUT_KEY_DEPOSIT() As SRT_TABLE_MNT_T_DEPOSIT_KEY
        Dim SRT_RET As SRT_TABLE_MNT_T_DEPOSIT_KEY

        With SRT_RET
            .NUMBER_CONTRACT = SRT_RECORD.KEY.NUMBER_CONTRACT
            .SERIAL_CONTRACT = SRT_RECORD.KEY.SERIAL_CONTRACT
            .SERIAL_INVOICE = SRT_RECORD.KEY.SERIAL_INVOICE
        End With

        Return SRT_RET
    End Function

    Private Function FUNC_GET_INPUT_DATA() As SRT_TABLE_MNT_T_INVOICE_DATA
        Dim SRT_RET As SRT_TABLE_MNT_T_INVOICE_DATA
        With SRT_RET
            .DATE_INVOICE = SRT_RECORD.DATA.DATE_INVOICE
            .KINGAKU_INVOICE_DETAIL = CLng(TXT_KINGAKU_INVOICE_DETAIL.Text)
            .KINGAKU_INVOICE_VAT = CLng(TXT_KINGAKU_INVOICE_VAT.Text)
            .CODE_SECTION = FUNC_GET_COMBO_KIND_CODE(CMB_CODE_SECTION)
        End With

        Return SRT_RET
    End Function

    Private Function FUNC_GET_INPUT_DATA_DEPOSIT() As SRT_TABLE_MNT_T_DEPOSIT_DATA
        Dim SRT_RET As SRT_TABLE_MNT_T_DEPOSIT_DATA
        With SRT_RET
            .DATE_DEPOSIT = DTP_DATE_DEPOSIT.Value
            .KIND_SALE = FUNC_GET_COMBO_KIND_CODE(CMB_KIND_SALE)
            .KIND_DEPOSIT = FUNC_GET_COMBO_KIND_CODE(CMB_KIND_DEPOSIT)
            .KIND_DEPOSIT_SUB = FUNC_GET_COMBO_KIND_CODE(CMB_KIND_DEPOSIT_SUB)
            .KINGAKU_FEE_DETAIL = CLng(CMB_KINGAKU_FEE_DETAIL.Text)
            .KINGAKU_FEE_VAT = CLng(TXT_KINGAKU_FEE_VAT.Text)
            .KIND_COST = FUNC_GET_COMBO_KIND_CODE(CMB_KIND_COST)
            .KINGAKU_COST_DETAIL = CLng(TXT_KINGAKU_COST_DETAIL.Text)
            .KINGAKU_COST_VAT = CLng(TXT_KINGAKU_COST_VAT.Text)
            .FLAG_OUTPUT_DONE = ENM_SYSTEM_INDIVIDUAL_FLAG_DEPOSIT_DONE.NOT_DONE
            .NAME_MEMO = TXT_NAME_MEMO.Text
            .DATE_ACTIVE = datSYSTEM_TOTAL_DATE_ACTIVE

            If FUNC_CHECK_TABLE_MNT_T_DEPOSIT(SRT_RECORD_DEPOSIT.KEY) Then
                If .DATE_ACTIVE = SRT_RECORD_DEPOSIT.DATA.DATE_ACTIVE Then '処理日が同一なら
                    .SERIAL_DEPOSIT = SRT_RECORD_DEPOSIT.DATA.SERIAL_DEPOSIT '連番を引き継ぐ
                Else
                    .SERIAL_DEPOSIT = FUNC_GET_MNT_T_DEPOSIT_MAX_SERIAL_DEPOSIT(.DATE_ACTIVE) + 1
                End If
            Else
                .SERIAL_DEPOSIT = FUNC_GET_MNT_T_DEPOSIT_MAX_SERIAL_DEPOSIT(.DATE_ACTIVE) + 1
            End If

        End With

        Return SRT_RET
    End Function

#End Region

#Region "画面状態遷移"
    Private Sub SUB_WINDOW_MODE_CHANGE(
    ByVal ENM_CHANGE_MODE As ENM_MY_WINDOW_MODE
    )

        If ENM_CHANGE_MODE = ENM_WINDOW_MODE_CURRENT Then
            Exit Sub
        End If

        Dim TXT_DUMMY As TextBox
        TXT_DUMMY = Nothing
        Call SUB_ADD_TEXTBOX_AND_MOVE_FOCUS(TXT_DUMMY, Me)

        Select Case ENM_CHANGE_MODE
            Case ENM_MY_WINDOW_MODE.INPUT_DATA
                PNL_INPUT_KEY.Enabled = True
                PNL_INPUT_DATA.Enabled = True

                BTN_ENTER.Enabled = True
                BTN_CLEAR.Enabled = True
                BTN_END.Enabled = True
            Case Else
                'スルー
        End Select

        Call SUB_REMOVE_TEXTBOX(TXT_DUMMY, Me)

        ENM_WINDOW_MODE_CURRENT = ENM_CHANGE_MODE
        Call Application.DoEvents()
    End Sub

#End Region

#Region "チェック処理"

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

#Region "内部処理"
    Private Sub SUB_REFRESH_KINGAKU_INVOICE_VAT()
        Dim LNG_KINGAKU_INVOICE_DETAIL As Long
        LNG_KINGAKU_INVOICE_DETAIL = FUNC_VALUE_CONVERT_NUMERIC_LONG(TXT_KINGAKU_INVOICE_DETAIL.Text, 0)

        Dim LNG_KINGAKU_INVOICE_VAT As Long
        LNG_KINGAKU_INVOICE_VAT = FUNC_GET_KINGAKU_VAT_FROM_DETAIL(LNG_KINGAKU_INVOICE_DETAIL, SRT_RECORD.DATA.DATE_INVOICE)
        TXT_KINGAKU_INVOICE_VAT.Text = Format(LNG_KINGAKU_INVOICE_VAT, "#,##0")

        Call SUB_REFRESH_KINGAKU_INVOICE_TOTAL()
    End Sub

    Private Sub SUB_REFRESH_KINGAKU_INVOICE_TOTAL()
        Dim LNG_KINGAKU_INVOICE_DETAIL As Long
        LNG_KINGAKU_INVOICE_DETAIL = FUNC_VALUE_CONVERT_NUMERIC_LONG(TXT_KINGAKU_INVOICE_DETAIL.Text, 0)

        Dim LNG_KINGAKU_INVOICE_VAT As Long
        LNG_KINGAKU_INVOICE_VAT = FUNC_VALUE_CONVERT_NUMERIC_LONG(TXT_KINGAKU_INVOICE_VAT.Text, 0)

        Dim LNG_KINGAKU_INVOICE_TOTAL As Long
        LNG_KINGAKU_INVOICE_TOTAL = LNG_KINGAKU_INVOICE_DETAIL + LNG_KINGAKU_INVOICE_VAT
        LBL_KINGAKU_INVOICE_TOTAL.Text = Format(LNG_KINGAKU_INVOICE_TOTAL, "#,##0")
    End Sub

    Private Sub SUB_REFRESH_DEPOSIT_INPUT_AREA()
        If CHK_FLAG_DEPOSIT_DONE.Checked Then
            PNL_DEPOSIT_INPUT_AREA.Enabled = True
        Else
            PNL_DEPOSIT_INPUT_AREA.Enabled = False

        End If
    End Sub

    Private Sub SUB_REFRESH_KINGAKU_FEE_VAT()
        Dim LNG_KINGAKU_FEE_DETAIL As Long
        LNG_KINGAKU_FEE_DETAIL = FUNC_VALUE_CONVERT_NUMERIC_LONG(CMB_KINGAKU_FEE_DETAIL.Text, 0)

        Dim LNG_KINGAKU_FEE_VAT As Long
        LNG_KINGAKU_FEE_VAT = FUNC_GET_KINGAKU_VAT_FROM_DETAIL(LNG_KINGAKU_FEE_DETAIL, DTP_DATE_DEPOSIT.Value)
        TXT_KINGAKU_FEE_VAT.Text = Format(LNG_KINGAKU_FEE_VAT, "#,##0")

        Call SUB_REFRESH_KINGAKU_FEE_TOTAL()
    End Sub

    Private Sub SUB_REFRESH_KINGAKU_FEE_TOTAL()
        Dim LNG_KINGAKU_FEE_DETAIL As Long
        LNG_KINGAKU_FEE_DETAIL = FUNC_VALUE_CONVERT_NUMERIC_LONG(CMB_KINGAKU_FEE_DETAIL.Text, 0)

        Dim LNG_KINGAKU_FEE_VAT As Long
        LNG_KINGAKU_FEE_VAT = FUNC_VALUE_CONVERT_NUMERIC_LONG(TXT_KINGAKU_FEE_VAT.Text, 0)

        Dim LNG_KINGAKU_FEE_TOTAL As Long
        LNG_KINGAKU_FEE_TOTAL = LNG_KINGAKU_FEE_DETAIL + LNG_KINGAKU_FEE_VAT
        LBL_KINGAKU_FEE_TOTAL.Text = Format(LNG_KINGAKU_FEE_TOTAL, "#,##0")
    End Sub

    Private Sub SUB_REFRESH_KINGAKU_COST_VAT()
        Dim LNG_KINGAKU_COST_DETAIL As Long
        LNG_KINGAKU_COST_DETAIL = FUNC_VALUE_CONVERT_NUMERIC_LONG(TXT_KINGAKU_COST_DETAIL.Text, 0)

        Dim LNG_KINGAKU_COST_VAT As Long
        LNG_KINGAKU_COST_VAT = FUNC_GET_KINGAKU_VAT_FROM_DETAIL(LNG_KINGAKU_COST_DETAIL, DTP_DATE_DEPOSIT.Value)
        TXT_KINGAKU_COST_VAT.Text = Format(LNG_KINGAKU_COST_VAT, "#,##0")

        Call SUB_REFRESH_KINGAKU_COST_TOTAL()
    End Sub

    Private Sub SUB_REFRESH_KINGAKU_COST_TOTAL()
        Dim LNG_KINGAKU_COST_DETAIL As Long
        LNG_KINGAKU_COST_DETAIL = FUNC_VALUE_CONVERT_NUMERIC_LONG(TXT_KINGAKU_COST_DETAIL.Text, 0)

        Dim LNG_KINGAKU_COST_VAT As Long
        LNG_KINGAKU_COST_VAT = FUNC_VALUE_CONVERT_NUMERIC_LONG(TXT_KINGAKU_COST_VAT.Text, 0)

        Dim LNG_KINGAKU_COST_TOTAL As Long
        LNG_KINGAKU_COST_TOTAL = LNG_KINGAKU_COST_DETAIL + LNG_KINGAKU_COST_VAT
        LBL_KINGAKU_COST_TOTAL.Text = Format(LNG_KINGAKU_COST_TOTAL, "#,##0")
    End Sub

    Private Sub SUB_REFRSH_ENABLED_KINGAKU_COST()
        Dim INT_KIND_COST As Integer
        INT_KIND_COST = FUNC_GET_COMBO_KIND_CODE(CMB_KIND_COST)

        Dim BLN_ENABLED As Boolean
        If INT_KIND_COST <= 0 Then
            BLN_ENABLED = False
        Else
            BLN_ENABLED = True
        End If

        PNL_KINGAKU_COST.Enabled = BLN_ENABLED
    End Sub

    Private Sub SUB_REFRSH_ENABLED_KIND_DEPOSIT_SUB()
        Dim INT_KIND_DEPOSIT As Integer
        INT_KIND_DEPOSIT = FUNC_GET_COMBO_KIND_CODE(CMB_KIND_DEPOSIT)

        Dim BLN_ENABLED As Boolean
        If INT_KIND_DEPOSIT = CST_SYSTEM_ACCOUNT_CODE_KIND_ORDINARY_DEPOSIT Then
            BLN_ENABLED = True
        Else
            BLN_ENABLED = False
        End If

        If BLN_ENABLED Then
            Call SUB_SET_COMBO_KIND_CODE_FIRST(CMB_KIND_DEPOSIT_SUB)
        Else
            Call SUB_SET_COMBO_KIND_CODE(CMB_KIND_DEPOSIT_SUB, -1)
        End If
        PNL_KIND_DEPOSIT_SUB.Enabled = BLN_ENABLED
        PNL_KINGAKU_FEE.Enabled = BLN_ENABLED
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

    Private Sub CHK_FLAG_DEPOSIT_DONE_GotFocus(sender As Object, e As EventArgs) Handles CHK_FLAG_DEPOSIT_DONE.GotFocus
        'CHK_FLAG_DEPOSIT_DONE.BackColor = System.Drawing.Color.Cyan
        LBL_FLAG_DEPOSIT_DONE_BACK.Visible = True
    End Sub

#End Region

#Region "イベント-フォーカス喪失"
    Private Sub SUB_CTRL_LOSTFOCUS(ByVal sender As Object, ByVal e As System.EventArgs)
        Call SUB_COMMON_EVENT_LOSTFOCUS(sender)
    End Sub

    Private Sub CHK_FLAG_DEPOSIT_DONE_LostFocus(sender As Object, e As EventArgs) Handles CHK_FLAG_DEPOSIT_DONE.LostFocus
        'CHK_FLAG_DEPOSIT_DONE.BackColor = Me.BackColor
        LBL_FLAG_DEPOSIT_DONE_BACK.Visible = False
    End Sub

#End Region

#Region "イベント-ボタンクリック"
    Private Sub BTN_ENTER_Click(sender As Object, e As EventArgs) Handles BTN_ENTER.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_ENTER)
    End Sub

    Private Sub BTN_CLEAR_Click(sender As Object, e As EventArgs) Handles BTN_CLEAR.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_CLEAR)
    End Sub

    Private Sub BTN_END_Click(sender As Object, e As EventArgs) Handles BTN_END.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_END)
    End Sub
#End Region

#Region "イベント-テキストチェンジ"

    Private Sub TXT_KINGAKU_INVOICE_DETAIL_TextChanged(sender As Object, e As EventArgs) Handles TXT_KINGAKU_INVOICE_DETAIL.TextChanged
        Call SUB_REFRESH_KINGAKU_INVOICE_VAT()
    End Sub

    Private Sub TXT_KINGAKU_INVOICE_VAT_TextChanged(sender As Object, e As EventArgs) Handles TXT_KINGAKU_INVOICE_VAT.TextChanged
        Call SUB_REFRESH_KINGAKU_INVOICE_TOTAL()
    End Sub

    Private Sub CMB_KINGAKU_FEE_DETAIL_TextChanged(sender As Object, e As EventArgs) Handles CMB_KINGAKU_FEE_DETAIL.TextChanged
        Call SUB_REFRESH_KINGAKU_FEE_VAT()
    End Sub

    Private Sub TXT_KINGAKU_FEE_VAT_TextChanged(sender As Object, e As EventArgs) Handles TXT_KINGAKU_FEE_VAT.TextChanged
        Call SUB_REFRESH_KINGAKU_FEE_TOTAL()
    End Sub

    Private Sub TXT_KINGAKU_COST_DETAIL_TextChanged(sender As Object, e As EventArgs) Handles TXT_KINGAKU_COST_DETAIL.TextChanged
        Call SUB_REFRESH_KINGAKU_COST_VAT()
    End Sub

    Private Sub TXT_KINGAKU_COST_VAT_TextChanged(sender As Object, e As EventArgs) Handles TXT_KINGAKU_COST_VAT.TextChanged
        Call SUB_REFRESH_KINGAKU_COST_TOTAL()
    End Sub
#End Region

#Region "イベント-チェックチェンジ"
    Private Sub CHK_FLAG_DEPOSIT_DONE_CheckedChanged(sender As Object, e As EventArgs) Handles CHK_FLAG_DEPOSIT_DONE.CheckedChanged
        Call SUB_REFRESH_DEPOSIT_INPUT_AREA()
    End Sub
#End Region

#Region "イベント-セレクトインデックスチェンジ"

    Private Sub CMB_KIND_DEPOSIT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_KIND_DEPOSIT.SelectedIndexChanged
        Call SUB_REFRSH_ENABLED_KIND_DEPOSIT_SUB()
    End Sub

    Private Sub CMB_KIND_COST_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_KIND_COST.SelectedIndexChanged
        Call SUB_REFRSH_ENABLED_KINGAKU_COST()
    End Sub
#End Region

    Private Sub FRM_SUB_01_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call SUB_CTRL_VIEW_INIT()
        Call SUB_CTRL_VALUE_INIT()
        Call SUB_WINDOW_MODE_CHANGE(ENM_MY_WINDOW_MODE.INPUT_DATA)
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