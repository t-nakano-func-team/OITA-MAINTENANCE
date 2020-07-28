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
        DO_SHOW_SUB_WINDOW
        DO_SHOW_SETTING
        DO_SHOW_COMMANDLINE
        DO_SHOW_CONFIG_SETTINGS
    End Enum

    Private Enum ENM_MY_GRID_MAIN
        CHECK = 0
        KIND_CONTRACT_NAME
        NUMBER_CONTRACT_VIEW
        DATE_CONTRACT
        NAME_OWNER
        NAME_CONTRACT
        COUNT_INVOICE_VIEW
        CODE_SECTION_NAME
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
        Public KIND_CONTRACT As Integer
        Public DATE_CONTRACT As DateTime
        Public CODE_OWNER As Integer
        Public NAME_CONTRACT As String
        Public COUNT_INVOICE As Integer
        Public CODE_SECTION As Integer
        Public KINGAKU_CONTRACT As Long

        Public KINGAKU_INVOICE_DETAIL As Long
        Public KINGAKU_INVOICE_VAT As Long
        Public SERIAL_INVOICE_MAX As Integer
        Public KIND_CONTRACT_NAME As String
        Public CODE_OWNER_NAME As String
        Public CODE_SECTION_INVOICE As Integer
        Public CODE_SECTION_INVOICE_NAME As String

        Public EDIT_INFO As SRT_EDIT_INVOICE

        Public Function FUNC_GET_NUMBER_SERIAL_CONTRACT() As String
            Dim STR_NUMBER_CONTRACT As String
            STR_NUMBER_CONTRACT = Format(Me.NUMBER_CONTRACT, New String("0", INT_SYSTEM_NUMBER_CONTRACT_MAX_LENGTH))

            Dim STR_SERIAL_CONTRACT As String
            STR_SERIAL_CONTRACT = Format(Me.SERIAL_CONTRACT, New String("0", INT_SYSTEM_SERIAL_CONTRACT_MAX_LENGTH))

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
            STR_RET &= (Me.SERIAL_INVOICE_MAX + 1) & ""
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
        Public ENABLED_INVOICE As Boolean
    End Structure

    Public Structure SRT_SEARCH_CONDITIONS '検索条件
        Public DATE_INVOICE As DateTime
    End Structure
#End Region

#Region "画面用・変数"
    Private BLN_PROCESS_DOING As Boolean
    Private ENM_WINDOW_MODE_CURRENT As ENM_MY_WINDOW_MODE '現在の画面状態
    Private TBL_GRID_DATA_MAIN As DataTable
    Private SRT_GRID_DATA_MAIN() As SRT_MY_GRID_DATA
#End Region

#Region "プロパティ用"
    Private BLN_PROPERTY_CHECK_ALL As Boolean
#End Region

#Region "プロパティ"
    '全選択状態
    Friend Property CHECK_ALL() As Boolean
        Get
            Return BLN_PROPERTY_CHECK_ALL
        End Get
        Set(ByVal Value As Boolean)
            BLN_PROPERTY_CHECK_ALL = Value
        End Set
    End Property
#End Region

#Region "初期化・終了処理"
    Private Sub SUB_CTRL_NEW_INIT()
        Call SUB_CTRL_EVENT_HANDLED_ADD()
    End Sub

    Private Sub SUB_CTRL_VIEW_INIT()
        Call glbSubMakeDataTable(TBL_GRID_DATA_MAIN, " ,形態,契約番号,契約日付,オーナー,契約内容,回数,担当部署,請求金額", "BSSSSSSSS")
        DGV_VIEW_DATA.DataSource = TBL_GRID_DATA_MAIN
        Call SUB_DGV_COLUMN_WIDTH_INIT_COUNT_FONT(DGV_VIEW_DATA, "1,3,4,5,6,6,2,4,4", "CLRRLLCLR")

        Dim DAT_DATE_TO As DateTime
        DAT_DATE_TO = FUNC_GET_DATE_LASTMONTH(datSYSTEM_TOTAL_DATE_ACTIVE.AddMonths(1))
        Call SUB_CONTROL_INITALIZE_DateTimePicker(DTP_DATE_INVOICE, cstVB_DATE_MIN, DAT_DATE_TO)
    End Sub

    Private Sub SUB_CTRL_VALUE_INIT()
        Call SUB_CONTROL_CLEAR_FORM(Me)

        LBL_NAME_USER_HEAD.Text = FUNC_GET_MNG_M_USER_NAME_STAFF(srtSYSTEM_TOTAL_COMMANDLINE.CODE_STAFF)
        LBL_DATE_ACTIVE_HEAD.Text = Format(datSYSTEM_TOTAL_DATE_ACTIVE, "yyyy年MM月dd日")

        Call SUB_CONTROL_SET_VALUE_DateTimePicker(DTP_DATE_INVOICE, datSYSTEM_TOTAL_DATE_ACTIVE)

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
            Case ENM_MY_EXEC_DO.DO_BATCH
                Call SUB_BATCH()
            Case ENM_MY_EXEC_DO.DO_CLEAR
                Call SUB_CLEAR()
            Case ENM_MY_EXEC_DO.DO_END
                Call SUB_END()
            Case ENM_MY_EXEC_DO.DO_SHOW_SUB_WINDOW
                Call SUB_SHOW_SUB_WINDOW()
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

    Private Sub SUB_BATCH()
        If Not FUNC_CHECK_INPUT_DATA() Then
            Exit Sub
        End If

        Dim SRT_CONDITIONS As MOD_BATCH.SRT_BATCH_CONDITIONS
        With SRT_CONDITIONS
            .RECORD = FUNC_GET_GRID_RECORD_INFO()
            .DATE_INVOICE = DTP_DATE_INVOICE.Value

            .DATE_DO_BATCH = DateTime.Now
            .FORM = Me
        End With

        If SRT_CONDITIONS.RECORD.Length <= 1 Then
            Call MessageBox.Show("1件以上選択してください。", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim STR_MSG As String
        STR_MSG = ""
        STR_MSG &= (SRT_CONDITIONS.RECORD.Length - 1) & "件の" & Environment.NewLine
        STR_MSG &= Me.Text & "を行います。" & Environment.NewLine & "よろしいですか？"
        Dim RST_MSG As System.Windows.Forms.DialogResult
        RST_MSG = MessageBox.Show(STR_MSG, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If RST_MSG = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        Call SUB_PUT_PROGRESS_GUIDE(Me.Text & "を行っています")
        Dim BLN_RET As Boolean
        Dim BLN_PUT As Boolean
        BLN_RET = MOD_BATCH.FUNC_BACTH_MAIN(BLN_PUT, SRT_CONDITIONS)
        Call SUB_PUT_PROGRESS_GUIDE("")

        If Not BLN_RET Then
            Call MessageBox.Show(MOD_BATCH.STR_FUNC_BATCH_MAIN_ERR_STR, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Not BLN_PUT Then
            Call MessageBox.Show("対象データがありません。", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Call MessageBox.Show(Me.Text & "を完了しました。", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Call SUB_CLEAR()
    End Sub

    Private Sub SUB_SEARCH()

        If Not FUNC_CHECK_INPUT_KEY() Then
            Exit Sub
        End If

        Dim SRT_CONDITIONS As SRT_SEARCH_CONDITIONS
        SRT_CONDITIONS = FUNC_GET_SEARCH_CONDITHIONS() '検索条件取得

        ReDim SRT_GRID_DATA_MAIN(0)
        Call SUB_MAKE_GRID_DATA(SRT_CONDITIONS)

        Dim INT_COUNT As Integer
        INT_COUNT = UBound(SRT_GRID_DATA_MAIN)
        Call SUB_REFRESH_COUNT(INT_COUNT)

        If INT_COUNT <= 0 Then
            Call SUB_REFRESH_GRID()
            Dim STR_ERR_MSG As String
            STR_ERR_MSG = "対象データがありません。"
            Call System.Windows.Forms.MessageBox.Show(STR_ERR_MSG, Me.Text, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information)
            Call SUB_FOCUS_FIRST_INPUT_CONTROL(PNL_INPUT_KEY)
            Exit Sub
        End If

        Me.CHECK_ALL = False
        Call SUB_WINDOW_MODE_CHANGE(ENM_MY_WINDOW_MODE.INPUT_DATA)
        Call SUB_REFRESH_GRID()
    End Sub

    Private Sub SUB_CLEAR()
        Call SUB_CONTROL_CLEAR_FORM(Me)
        Call SUB_CTRL_VALUE_INIT() '値を初期化
        Call SUB_WINDOW_MODE_CHANGE(ENM_MY_WINDOW_MODE.INPUT_KEY)
        Call SUB_FOCUS_FIRST_INPUT_CONTROL(Me)
    End Sub

    Private Sub SUB_SHOW_SUB_WINDOW()

        Dim INT_SELECT_ROW_INDEX As Integer
        INT_SELECT_ROW_INDEX = FUNC_GET_SELECT_ROW_INDEX(DGV_VIEW_DATA)

        If INT_SELECT_ROW_INDEX <= 0 Then
            Exit Sub
        End If

        Dim SRT_EDIT As SRT_EDIT_INVOICE
        Dim INT_SRT_INDEX As Integer
        INT_SRT_INDEX = INT_SELECT_ROW_INDEX
        With SRT_GRID_DATA_MAIN(INT_SRT_INDEX)
            Dim FRM_SHOW As FRM_SUB_01
            FRM_SHOW = New FRM_SUB_01
            FRM_SHOW.Font = New System.Drawing.Font(FRM_SHOW.Font.Name, Me.Font.Size)
            FRM_SHOW.Text = Me.Text
            FRM_SHOW.NUMBER_CONTRACT = .NUMBER_CONTRACT
            FRM_SHOW.SERIAL_CONTRACT = .SERIAL_CONTRACT
            FRM_SHOW.DATE_INVOICE = DTP_DATE_INVOICE.Value
            FRM_SHOW.RET_EDIT_INFO = .EDIT_INFO

            Call FRM_SHOW.ShowDialog()

            Dim BLN_CNACEL As Boolean
            BLN_CNACEL = FRM_SHOW.RET_EDIT_CANCEL

            SRT_EDIT = FRM_SHOW.RET_EDIT_INFO

            Call FRM_SHOW.Dispose()
            FRM_SHOW = Nothing

            If BLN_CNACEL Then
                Exit Sub
            End If
        End With

        Call SUB_REFRESH_DATA_ONE(SRT_GRID_DATA_MAIN(INT_SRT_INDEX), SRT_EDIT)
        Call SUB_REFRESH_GRID_ROW(INT_SRT_INDEX)
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

                BTN_BATCH.Enabled = False
                BTN_CLEAR.Enabled = True
                BTN_END.Enabled = True
            Case ENM_MY_WINDOW_MODE.INPUT_DATA
                PNL_INPUT_KEY.Enabled = False

                BTN_BATCH.Enabled = True
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

        Dim STR_WHERE As String
        STR_WHERE = FUNC_GET_SQL_WHERE(SRT_CONDITIONS) '検索条件からWHERE条件取得

        Dim STR_WHERE_SPOT As String
        STR_WHERE_SPOT = FUNC_GET_SQL_WHERE_SPOT(SRT_CONDITIONS) '検索条件からWHERE条件取得

        Dim STR_SQL As System.Text.StringBuilder
        STR_SQL = New System.Text.StringBuilder
        With STR_SQL
            Call .Append("SELECT" & Environment.NewLine)
            Call .Append("*" & Environment.NewLine)
            Call .Append("FROM" & Environment.NewLine)
            Call .Append("MNT_T_CONTRACT WITH(NOLOCK)" & Environment.NewLine)
            Call .Append("WHERE" & Environment.NewLine)
            Call .Append("1=1" & Environment.NewLine)
            Call .Append("AND KIND_CONTRACT=" & ENM_SYSTEM_INDIVIDUAL_KIND_CONTRACT.REGULAR & Environment.NewLine)
            Call .Append(STR_WHERE) 'WHERE条件
            Call .Append("UNION ALL" & Environment.NewLine)
            Call .Append("SELECT" & Environment.NewLine)
            Call .Append("*" & Environment.NewLine)
            Call .Append("FROM" & Environment.NewLine)
            Call .Append("MNT_T_CONTRACT WITH(NOLOCK)" & Environment.NewLine)
            Call .Append("WHERE" & Environment.NewLine)
            Call .Append("1=1" & Environment.NewLine)
            Call .Append("AND KIND_CONTRACT=" & ENM_SYSTEM_INDIVIDUAL_KIND_CONTRACT.SPOT & Environment.NewLine)
            Call .Append(STR_WHERE_SPOT) 'WHERE条件

            Call .Append("ORDER BY" & Environment.NewLine)
            Call .Append("KIND_CONTRACT,NUMBER_CONTRACT" & Environment.NewLine)
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

        Dim SRT_TEMP() As SRT_MY_INVOICE_DATA

        ReDim SRT_TEMP(CST_MY_GRID_COUNT_MAX * 10)
        Dim INT_INDEX As Integer
        INT_INDEX = 0
        While SDR_READER.Read
            If INT_INDEX >= (SRT_TEMP.Length - 1) Then
                Exit While
            End If
            INT_INDEX += 1
            With SRT_TEMP(INT_INDEX)
                .NUMBER_CONTRACT = CInt(SDR_READER.Item("NUMBER_CONTRACT"))
                .SERIAL_CONTRACT = CInt(SDR_READER.Item("SERIAL_CONTRACT"))
                .ENABLED_INVOICE = True
            End With
        End While
        ReDim Preserve SRT_TEMP(INT_INDEX)
        Call SDR_READER.Close()
        SDR_READER = Nothing

        For i = 1 To (SRT_TEMP.Length - 1) '補助情報取得
            With SRT_TEMP(i)
                .ENABLED_INVOICE = FUNC_GET_ENABLED_INVOICE(.NUMBER_CONTRACT, .SERIAL_CONTRACT, SRT_CONDITIONS.DATE_INVOICE)
            End With
        Next

        ReDim SRT_GRID_DATA_MAIN(CST_MY_GRID_COUNT_MAX)
        INT_INDEX = 0
        For i = 1 To (SRT_TEMP.Length - 1) 'グリッドデータへ転送
            If INT_INDEX >= (SRT_GRID_DATA_MAIN.Length - 1) Then
                Exit For
            End If

            If Not SRT_TEMP(i).ENABLED_INVOICE Then
                Continue For
            End If

            INT_INDEX += 1
            SRT_GRID_DATA_MAIN(INT_INDEX).NUMBER_CONTRACT = SRT_TEMP(i).NUMBER_CONTRACT
            SRT_GRID_DATA_MAIN(INT_INDEX).SERIAL_CONTRACT = SRT_TEMP(i).SERIAL_CONTRACT
        Next
        ReDim Preserve SRT_GRID_DATA_MAIN(INT_INDEX)

        For i = 1 To (SRT_GRID_DATA_MAIN.Length - 1) '補助情報取得
            Dim SRT_RECORD_CONTRACT As SRT_TABLE_MNT_T_CONTRACT
            With SRT_RECORD_CONTRACT.KEY
                .NUMBER_CONTRACT = SRT_GRID_DATA_MAIN(i).NUMBER_CONTRACT
                .SERIAL_CONTRACT = SRT_GRID_DATA_MAIN(i).SERIAL_CONTRACT
            End With
            SRT_RECORD_CONTRACT.DATA = Nothing
            Call FUNC_SELECT_TABLE_MNT_T_CONTRACT(SRT_RECORD_CONTRACT.KEY, SRT_RECORD_CONTRACT.DATA, True)

            Dim SRT_RECORD_CONTRACT_SPOT As SRT_TABLE_MNT_T_CONTRACT_SPOT
            With SRT_RECORD_CONTRACT_SPOT.KEY
                .NUMBER_CONTRACT = SRT_RECORD_CONTRACT.KEY.NUMBER_CONTRACT
                .SERIAL_CONTRACT = SRT_RECORD_CONTRACT.KEY.SERIAL_CONTRACT
            End With
            SRT_RECORD_CONTRACT_SPOT.DATA = Nothing
            Call FUNC_SELECT_TABLE_MNT_T_CONTRACT_SPOT(SRT_RECORD_CONTRACT_SPOT.KEY, SRT_RECORD_CONTRACT_SPOT.DATA, True)

            With SRT_GRID_DATA_MAIN(i)
                .KIND_CONTRACT = SRT_RECORD_CONTRACT.DATA.KIND_CONTRACT
                .CODE_OWNER = SRT_RECORD_CONTRACT.DATA.CODE_OWNER
                .NAME_CONTRACT = SRT_RECORD_CONTRACT.DATA.NAME_CONTRACT
                .CODE_SECTION = SRT_RECORD_CONTRACT.DATA.CODE_SECTION
                .COUNT_INVOICE = SRT_RECORD_CONTRACT.DATA.COUNT_INVOICE
                .DATE_CONTRACT = SRT_RECORD_CONTRACT.DATA.DATE_CONTRACT
                .KINGAKU_CONTRACT = SRT_RECORD_CONTRACT.DATA.KINGAKU_CONTRACT

                .SERIAL_INVOICE_MAX = FUNC_GET_MNT_T_INVOICE_MAX_SERIAL_INVOICE(.NUMBER_CONTRACT, .SERIAL_CONTRACT)
                .KIND_CONTRACT_NAME = FUNC_GET_MNT_M_KIND_NAME_KIND(ENM_MNT_M_KIND_CODE_FLAG.KIND_CONTRACT, .KIND_CONTRACT)
                Select Case .KIND_CONTRACT
                    Case ENM_SYSTEM_INDIVIDUAL_KIND_CONTRACT.REGULAR
                        .CODE_OWNER_NAME = FUNC_GET_MNT_M_OWNER_NAME_OWNER(.CODE_OWNER, True)
                    Case ENM_SYSTEM_INDIVIDUAL_KIND_CONTRACT.SPOT
                        .CODE_OWNER_NAME = SRT_RECORD_CONTRACT_SPOT.DATA.NAME_OWNER
                    Case Else
                        .CODE_OWNER_NAME = ""
                End Select
                .CODE_SECTION_INVOICE = .CODE_SECTION
                .CODE_SECTION_INVOICE_NAME = FUNC_GET_MNT_M_SECTION_NAME_SECTION(.CODE_SECTION)

                .KINGAKU_INVOICE_DETAIL = .KINGAKU_CONTRACT
                .KINGAKU_INVOICE_VAT = FUNC_GET_KINGAKU_VAT_FROM_DETAIL(.KINGAKU_INVOICE_DETAIL, SRT_CONDITIONS.DATE_INVOICE)

                .EDIT_INFO = FUNC_GET_EDIT_INFO_INIT()
            End With
        Next
    End Sub

    Private Function FUNC_GET_EDIT_INFO_INIT() As SRT_EDIT_INVOICE
        Dim SRT_RET As SRT_EDIT_INVOICE
        With SRT_RET
            .CEHCK_EDIT = False
            .CODE_SECTION = -1
            .KINGAKU_INVOICE_DETAIL = 0
            .KINGAKU_INVOICE_VAT = 0
        End With

        Return SRT_RET
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
                OBJ_TEMP(ENM_MY_GRID_MAIN.CHECK) = False
                OBJ_TEMP(ENM_MY_GRID_MAIN.KIND_CONTRACT_NAME) = .KIND_CONTRACT_NAME
                OBJ_TEMP(ENM_MY_GRID_MAIN.NUMBER_CONTRACT_VIEW) = .FUNC_GET_NUMBER_SERIAL_CONTRACT
                OBJ_TEMP(ENM_MY_GRID_MAIN.DATE_CONTRACT) = .DATE_CONTRACT.ToLongDateString
                OBJ_TEMP(ENM_MY_GRID_MAIN.NAME_OWNER) = .CODE_OWNER_NAME
                OBJ_TEMP(ENM_MY_GRID_MAIN.NAME_CONTRACT) = .NAME_CONTRACT
                OBJ_TEMP(ENM_MY_GRID_MAIN.COUNT_INVOICE_VIEW) = .FUNC_GET_COUNT_INVOICE_VIEW
                OBJ_TEMP(ENM_MY_GRID_MAIN.CODE_SECTION_NAME) = .CODE_SECTION_INVOICE_NAME
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

    Private Sub SUB_EDIT_GRID_VIEW_FLAG(ByVal BLN_FLAG As Boolean)
        Dim TBL_DATA_TABLE As DataTable

        TBL_DATA_TABLE = DGV_VIEW_DATA.DataSource
        Dim INT_MAX_INDEX As Integer

        INT_MAX_INDEX = (TBL_DATA_TABLE.Rows.Count - 1)
        For intLOOP_INDEX = 0 To INT_MAX_INDEX
            TBL_DATA_TABLE.Rows(intLOOP_INDEX).Item(ENM_MY_GRID_MAIN.CHECK) = BLN_FLAG
        Next

        'チラツキを抑えるため、選択モードを変更して、リフレッシュ
        Call SUB_DATA_GRID_REFRESH_CHG_SELECTION_MODE(DGV_VIEW_DATA)
    End Sub

    Private Function FUNC_GET_ENABLED_INVOICE(ByVal INT_NUMBER_CONTRACT As Integer, ByVal INT_SERIAL_CONTRACT As Integer, ByVal DAT_DATE_INVOICE As DateTime) As Boolean

        Dim SRT_RECORD As SRT_TABLE_MNT_T_CONTRACT
        With SRT_RECORD.KEY
            .NUMBER_CONTRACT = INT_NUMBER_CONTRACT
            .SERIAL_CONTRACT = INT_SERIAL_CONTRACT
        End With
        SRT_RECORD.DATA = Nothing
        Call FUNC_SELECT_TABLE_MNT_T_CONTRACT(SRT_RECORD.KEY, SRT_RECORD.DATA, True)

        Dim INT_MAX_INVOICE As Integer
        INT_MAX_INVOICE = FUNC_GET_MNT_T_INVOICE_MAX_SERIAL_INVOICE(SRT_RECORD.KEY.NUMBER_CONTRACT, SRT_RECORD.KEY.SERIAL_CONTRACT)

        If INT_MAX_INVOICE >= SRT_RECORD.DATA.COUNT_INVOICE Then '請求回数分の請求レコードがある場合は
            Return False '請求不可（スポットの既請求分はここで抜ける）
        End If

        If INT_MAX_INVOICE = 0 Then '請求レコードがない場合は
            Return True '請求可能（スポットの未請求分はここで抜ける）
        End If

        'ここからは定期のみ
        Dim DAT_DATE_INVOICE_FROM As DateTime
        Dim DAT_DATE_INVOICE_TO As DateTime

        DAT_DATE_INVOICE_FROM = FUNC_GET_DATE_FIRSMONTH(DAT_DATE_INVOICE) '月初
        DAT_DATE_INVOICE_TO = FUNC_GET_DATE_LASTMONTH(DAT_DATE_INVOICE) '月末

        Dim BLN_CHECK As Boolean
        BLN_CHECK = FUNC_CHECK_MNT_T_INVOICE_DATE_INVOICE_PERIOD(SRT_RECORD.KEY.NUMBER_CONTRACT, SRT_RECORD.KEY.SERIAL_CONTRACT, DAT_DATE_INVOICE_FROM, DAT_DATE_INVOICE_TO)
        If BLN_CHECK Then '今回請求日付と同一月の請求レコードがある場合は
            Return False '請求不可
        End If

        '請求見込日を過ぎているか（初回以外）
        Dim INT_CNT As Integer
        INT_CNT = FUNC_GET_MNT_T_INVOICE_COUNT(SRT_RECORD.KEY.NUMBER_CONTRACT, SRT_RECORD.KEY.SERIAL_CONTRACT) '既請求回数を取得
        If INT_CNT > 0 Then '既に1回以上請求されている場合
            Dim INT_YYYYMM_INVOICE_BASE As Integer
            INT_YYYYMM_INVOICE_BASE = FUNC_GET_YYYYMM_FROM_DATE(SRT_RECORD.DATA.DATE_INVOICE_BASE)

            Dim INT_YYYYMM_INVOICE_CALC As Integer '請求可能月
            INT_YYYYMM_INVOICE_CALC = FUNC_ADD_MONTH_YYYYMM(INT_YYYYMM_INVOICE_BASE, INT_CNT * SRT_RECORD.DATA.SPAN_INVOICE)

            Dim INT_YEAR As Integer
            INT_YEAR = FUNC_GET_YYYY_FROM_YYYYMM(INT_YYYYMM_INVOICE_CALC)

            Dim INT_MONTH As Integer
            INT_MONTH = FUNC_GET_MM_FROM_YYYYMM(INT_YYYYMM_INVOICE_CALC)

            Dim INT_DAY As Integer
            INT_DAY = SRT_RECORD.DATA.DATE_INVOICE_BASE.Day

            Dim DAT_DATE_INVOICE_ENABLED As DateTime
            If INT_DAY >= 28 Then
                DAT_DATE_INVOICE_ENABLED = New DateTime(INT_YEAR, INT_MONTH, 1)
                DAT_DATE_INVOICE_ENABLED = FUNC_GET_DATE_LASTMONTH(DAT_DATE_INVOICE_ENABLED)
            Else
                DAT_DATE_INVOICE_ENABLED = New DateTime(INT_YEAR, INT_MONTH, INT_DAY)
            End If

            If DAT_DATE_INVOICE.Date < DAT_DATE_INVOICE_ENABLED.Date Then
                Return False '請求不可
            End If
        End If

        If SRT_RECORD.DATA.SPAN_INVOICE > 1 Then '請求スパンが2～の場合は
            Dim INT_ADD_MONTH As Integer
            INT_ADD_MONTH = (SRT_RECORD.DATA.SPAN_INVOICE - 1) '前月以前の請求も確認
            INT_ADD_MONTH *= -1
            DAT_DATE_INVOICE_FROM = FUNC_GET_DATE_FIRSMONTH(DAT_DATE_INVOICE.AddMonths(INT_ADD_MONTH)) '月初
            DAT_DATE_INVOICE_TO = FUNC_GET_DATE_LASTMONTH(DAT_DATE_INVOICE) '月末
            BLN_CHECK = FUNC_CHECK_MNT_T_INVOICE_DATE_INVOICE_PERIOD(SRT_RECORD.KEY.NUMBER_CONTRACT, SRT_RECORD.KEY.SERIAL_CONTRACT, DAT_DATE_INVOICE_FROM, DAT_DATE_INVOICE_TO)
            If BLN_CHECK Then '対象期間に請求レコードがある場合は
                Return False '請求不可
            End If
        End If

        Return True
    End Function

    Private Function FUNC_GET_GRID_RECORD_INFO() As SRT_INVOICE_INFO_RECORD()

        Dim TBL_DATA_TABLE As DataTable
        TBL_DATA_TABLE = DGV_VIEW_DATA.DataSource

        Dim SRT_RET() As SRT_INVOICE_INFO_RECORD
        ReDim SRT_RET(0)
        If TBL_DATA_TABLE Is Nothing Then
            Return SRT_RET
        End If

        Dim INT_MAX_INDEX As Integer
        INT_MAX_INDEX = (SRT_GRID_DATA_MAIN.Length - 1)
        For i = 1 To INT_MAX_INDEX '構造体のLength分のデータがありきとする
            Dim INT_TABLE_INDEX As Integer
            INT_TABLE_INDEX = (i - 1)

            Dim ROW_DATA As DataRow
            Try
                ROW_DATA = TBL_DATA_TABLE.Rows(INT_TABLE_INDEX)
            Catch ex As Exception
                Exit For '行無
            End Try

            Dim OBJ_TEMP As Object
            Try
                OBJ_TEMP = ROW_DATA.Item(ENM_MY_GRID_MAIN.CHECK)
            Catch ex As Exception
                Exit For '列定義数不一致
            End Try

            Dim BLN_CHECK As Boolean
            BLN_CHECK = CBool(OBJ_TEMP)

            If BLN_CHECK Then
                Dim INT_INDEX As Integer
                INT_INDEX = SRT_RET.Length
                ReDim Preserve SRT_RET(INT_INDEX)
                SRT_RET(INT_INDEX).KEY.NUMBER_CONTRACT = SRT_GRID_DATA_MAIN(i).NUMBER_CONTRACT
                SRT_RET(INT_INDEX).KEY.SERIAL_CONTRACT = SRT_GRID_DATA_MAIN(i).SERIAL_CONTRACT
                SRT_RET(INT_INDEX).EDIT = SRT_GRID_DATA_MAIN(i).EDIT_INFO
            End If

            ROW_DATA = Nothing
        Next

        Return SRT_RET
    End Function
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

    Private Function FUNC_CHECK_INPUT_DATA() As Boolean
        Dim CTL_CONTROL As Control
        Dim ENM_ERR_CODE As CONTROL_CHECK_ERR_CODE
        Dim STR_ERR_MSG As String

        'Enable = True の入力項目すべてチェック対象(TAG=Check_Head)
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

#Region "内部処理"
    Private Sub SUB_REFRESH_COUNT(ByVal INT_COUNT As Integer)
        LBL_COUNT_SEARCH_MAX.Visible = False
        LBL_COUNT_SEARCH.Text = Format(INT_COUNT, "#,##0")

        If INT_COUNT >= CST_MY_GRID_COUNT_MAX Then
            LBL_COUNT_SEARCH_MAX.Visible = True
        End If
    End Sub

    Private Function FUNC_GET_SEARCH_CONDITHIONS() As SRT_SEARCH_CONDITIONS
        Dim srtCONDITIONS As SRT_SEARCH_CONDITIONS
        With srtCONDITIONS
            .DATE_INVOICE = DTP_DATE_INVOICE.Value
        End With

        Return srtCONDITIONS
    End Function

    Private Function FUNC_GET_SQL_WHERE(ByVal SRT_CONDITIONS As SRT_SEARCH_CONDITIONS)
        Dim STR_WHERE As String
        STR_WHERE = ""

        With SRT_CONDITIONS
            STR_WHERE &= FUNC_GET_SQL_WHERE_DATE(.DATE_INVOICE, "DATE_INVOICE_BASE", "<=")
        End With

        Return STR_WHERE
    End Function

    Private Function FUNC_GET_SQL_WHERE_SPOT(ByVal SRT_CONDITIONS As SRT_SEARCH_CONDITIONS)
        Dim STR_WHERE As String
        STR_WHERE = ""

        With SRT_CONDITIONS
            STR_WHERE &= FUNC_GET_SQL_WHERE_DATE(.DATE_INVOICE, "DATE_INVOICE_BASE", "<=")
        End With

        Return STR_WHERE
    End Function

    Public Sub SUB_PUT_PROGRESS_GUIDE(ByVal STR_PROGRESS As String)

        LBL_BATCH_PROGRESS.Text = STR_PROGRESS
        Call LBL_BATCH_PROGRESS.Refresh()
        Call Application.DoEvents()
    End Sub

    Private Sub SUB_REFRESH_DATA_ONE(ByRef SRT_DATA As SRT_MY_GRID_DATA, ByRef SRT_EDIT As SRT_EDIT_INVOICE)
        With SRT_DATA
            .EDIT_INFO = SRT_EDIT
            If SRT_EDIT.CEHCK_EDIT Then
                .CODE_SECTION_INVOICE = SRT_EDIT.CODE_SECTION
                .KINGAKU_INVOICE_DETAIL = SRT_EDIT.KINGAKU_INVOICE_DETAIL
                .KINGAKU_INVOICE_VAT = SRT_EDIT.KINGAKU_INVOICE_VAT
            Else
                .CODE_SECTION_INVOICE = .CODE_SECTION
                .KINGAKU_INVOICE_DETAIL = .KINGAKU_CONTRACT
                .KINGAKU_INVOICE_VAT = FUNC_GET_KINGAKU_VAT_FROM_DETAIL(.KINGAKU_INVOICE_DETAIL, DTP_DATE_INVOICE.Value)
            End If

            .CODE_SECTION_INVOICE_NAME = FUNC_GET_MNT_M_SECTION_NAME_SECTION(.CODE_SECTION_INVOICE)
        End With
    End Sub

    Private Sub SUB_REFRESH_GRID_ROW(ByVal INT_INDEX_SRT As Integer)
        Dim INT_INDEX_GRID As Integer
        INT_INDEX_GRID = (INT_INDEX_SRT - 1)

        With SRT_GRID_DATA_MAIN(INT_INDEX_SRT)
            TBL_GRID_DATA_MAIN.Rows(INT_INDEX_GRID).Item(ENM_MY_GRID_MAIN.CHECK) = False
            TBL_GRID_DATA_MAIN.Rows(INT_INDEX_GRID).Item(ENM_MY_GRID_MAIN.KIND_CONTRACT_NAME) = .KIND_CONTRACT_NAME
            TBL_GRID_DATA_MAIN.Rows(INT_INDEX_GRID).Item(ENM_MY_GRID_MAIN.NUMBER_CONTRACT_VIEW) = .FUNC_GET_NUMBER_SERIAL_CONTRACT
            TBL_GRID_DATA_MAIN.Rows(INT_INDEX_GRID).Item(ENM_MY_GRID_MAIN.DATE_CONTRACT) = .DATE_CONTRACT.ToLongDateString
            TBL_GRID_DATA_MAIN.Rows(INT_INDEX_GRID).Item(ENM_MY_GRID_MAIN.NAME_OWNER) = .CODE_OWNER_NAME
            TBL_GRID_DATA_MAIN.Rows(INT_INDEX_GRID).Item(ENM_MY_GRID_MAIN.NAME_CONTRACT) = .NAME_CONTRACT
            TBL_GRID_DATA_MAIN.Rows(INT_INDEX_GRID).Item(ENM_MY_GRID_MAIN.COUNT_INVOICE_VIEW) = .FUNC_GET_COUNT_INVOICE_VIEW
            TBL_GRID_DATA_MAIN.Rows(INT_INDEX_GRID).Item(ENM_MY_GRID_MAIN.CODE_SECTION_NAME) = .CODE_SECTION_INVOICE_NAME
            TBL_GRID_DATA_MAIN.Rows(INT_INDEX_GRID).Item(ENM_MY_GRID_MAIN.KINGAKU_CONTRACT) = Format(.FUNC_GET_KINGAKU_INVOICE_TOTAL, "#,##0")
        End With

        Call DGV_VIEW_DATA.Refresh()
        Call System.Windows.Forms.Application.DoEvents()
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

    Private Sub BTN_BATCH_Click(sender As Object, e As EventArgs) Handles BTN_BATCH.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_BATCH)
    End Sub

    Private Sub BTN_CLEAR_Click(sender As Object, e As EventArgs) Handles BTN_CLEAR.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_CLEAR)
    End Sub

    Private Sub BTN_END_Click(sender As Object, e As EventArgs) Handles BTN_END.Click
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_END)
    End Sub
#End Region

#Region "イベント-グリッドクリック"
    Private Sub DGV_VIEW_DATA_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_VIEW_DATA.ColumnHeaderMouseClick
        Select Case e.ColumnIndex
            Case ENM_MY_GRID_MAIN.CHECK
            Case Else
                Exit Sub
        End Select

        Me.CHECK_ALL = Not Me.CHECK_ALL
        Call SUB_EDIT_GRID_VIEW_FLAG(Me.CHECK_ALL)
    End Sub
#End Region

#Region "イベント-グリッドダブルクリック"
    Private Sub DGV_VIEW_DATA_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_VIEW_DATA.CellDoubleClick
        Call SUB_EXEC_DO(ENM_MY_EXEC_DO.DO_SHOW_SUB_WINDOW)
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
