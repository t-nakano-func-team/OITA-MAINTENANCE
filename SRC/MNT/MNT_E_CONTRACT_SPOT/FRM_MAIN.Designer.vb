<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_MAIN
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GRP_HEAD = New System.Windows.Forms.GroupBox()
        Me.PNL_INFO_GUIDE = New System.Windows.Forms.Panel()
        Me.PNL_NAME_USER_HEAD = New System.Windows.Forms.Panel()
        Me.LBL_NAME_USER_HEAD = New System.Windows.Forms.Label()
        Me.LBL_NAME_USER_HEAD_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_DATE_ACTIVE_HEAD = New System.Windows.Forms.Panel()
        Me.LBL_DATE_ACTIVE_HEAD = New System.Windows.Forms.Label()
        Me.LBL_DATE_ACTIVE_HEAD_GUIDE = New System.Windows.Forms.Label()
        Me.GRP_FOOT = New System.Windows.Forms.GroupBox()
        Me.pnlFUNCTION_GROUP = New System.Windows.Forms.Panel()
        Me.BTN_CLEAR = New System.Windows.Forms.Button()
        Me.BTN_DELETE = New System.Windows.Forms.Button()
        Me.BTN_ENTER = New System.Windows.Forms.Button()
        Me.BTN_END = New System.Windows.Forms.Button()
        Me.GRP_BODY = New System.Windows.Forms.GroupBox()
        Me.PNL_INPUT_DATA = New System.Windows.Forms.Panel()
        Me.PNL_CODE_WORK = New System.Windows.Forms.Panel()
        Me.CMB_CODE_WORK = New System.Windows.Forms.ComboBox()
        Me.LBL_CODE_WORK_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_KIND_WORK = New System.Windows.Forms.Panel()
        Me.CMB_KIND_WORK = New System.Windows.Forms.ComboBox()
        Me.LBL_KIND_WORK_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_CODE_HANDLE = New System.Windows.Forms.Panel()
        Me.CMB_CODE_SECTION = New System.Windows.Forms.ComboBox()
        Me.LBL_CODE_SECTION_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_DEPOSIT_DONE = New System.Windows.Forms.Panel()
        Me.LBL_DEPOSIT_DONE = New System.Windows.Forms.Label()
        Me.LBL_DEPOSIT_DONE_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_INVOICE_DONE = New System.Windows.Forms.Panel()
        Me.LBL_INVOICE_DONE = New System.Windows.Forms.Label()
        Me.LBL_INVOICE_DONE_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_DATE_INVOICE_BASE = New System.Windows.Forms.Panel()
        Me.DTP_DATE_INVOICE_BASE = New System.Windows.Forms.DateTimePicker()
        Me.LBL_DATE_INVOICE_BASE_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_NUMBER_ORDER = New System.Windows.Forms.Panel()
        Me.LBL_NUMBER_ORDER_GUIDE = New System.Windows.Forms.Label()
        Me.TXT_NUMBER_ORDER = New System.Windows.Forms.TextBox()
        Me.PNL_NAME_CONTRACT = New System.Windows.Forms.Panel()
        Me.TXT_NAME_CONTRACT = New System.Windows.Forms.TextBox()
        Me.LBL_NAME_CONTRACT_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_DATE_WORK = New System.Windows.Forms.Panel()
        Me.LBL_DATE_WORK_FROM_TO_GUIDE = New System.Windows.Forms.Label()
        Me.DTP_DATE_WORK_TO = New System.Windows.Forms.DateTimePicker()
        Me.DTP_DATE_WORK_FROM = New System.Windows.Forms.DateTimePicker()
        Me.LBL_DATE_WORK_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_EXT_SPOT = New System.Windows.Forms.Panel()
        Me.PNL_NAME_ADDRESS_02 = New System.Windows.Forms.Panel()
        Me.TXT_NAME_ADDRESS_02 = New System.Windows.Forms.TextBox()
        Me.LBL_NAME_ADDRESS_02 = New System.Windows.Forms.Label()
        Me.PNL_NAME_ADDRESS_01 = New System.Windows.Forms.Panel()
        Me.TXT_NAME_ADDRESS_01 = New System.Windows.Forms.TextBox()
        Me.LBL_NAME_ADDRESS_01 = New System.Windows.Forms.Label()
        Me.PNL_CODE_POST = New System.Windows.Forms.Panel()
        Me.LBL_CODE_POST_GUIDE = New System.Windows.Forms.Label()
        Me.TXT_CODE_POST = New System.Windows.Forms.TextBox()
        Me.PNL_NAME_OWNER = New System.Windows.Forms.Panel()
        Me.TXT_NAME_OWNER = New System.Windows.Forms.TextBox()
        Me.LBL_NAME_OWNER_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_NAME_MEMO = New System.Windows.Forms.Panel()
        Me.TXT_NAME_MEMO = New System.Windows.Forms.TextBox()
        Me.LBL_NAME_MEMO_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_KINGAKU_CONTRACT = New System.Windows.Forms.Panel()
        Me.LBL_KINGAKU_CONTRACT_GUIDE = New System.Windows.Forms.Label()
        Me.TXT_KINGAKU_CONTRACT = New System.Windows.Forms.TextBox()
        Me.PNL_DATE_CONTRACT = New System.Windows.Forms.Panel()
        Me.DTP_DATE_CONTRACT = New System.Windows.Forms.DateTimePicker()
        Me.LBL_DATE_CONTRACT_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_CODE_SHINTO_PARENT = New System.Windows.Forms.Panel()
        Me.LBL_CODE_OWNER_GUIDE = New System.Windows.Forms.Label()
        Me.LBL_CODE_OWNER_NAME = New System.Windows.Forms.Label()
        Me.BTN_CODE_OWNER_SEARCH = New System.Windows.Forms.Button()
        Me.TXT_CODE_OWNER = New System.Windows.Forms.TextBox()
        Me.PNL_INPUT_KEY = New System.Windows.Forms.Panel()
        Me.PNL_NUMBER_CONTRACT = New System.Windows.Forms.Panel()
        Me.BTN_NUMBER_CONTRACT_SEARCH = New System.Windows.Forms.Button()
        Me.LBL_NUMBER_CONTRACT_GUIDE = New System.Windows.Forms.Label()
        Me.TXT_NUMBER_CONTRACT = New System.Windows.Forms.TextBox()
        Me.GRP_HEAD.SuspendLayout()
        Me.PNL_INFO_GUIDE.SuspendLayout()
        Me.PNL_NAME_USER_HEAD.SuspendLayout()
        Me.PNL_DATE_ACTIVE_HEAD.SuspendLayout()
        Me.GRP_FOOT.SuspendLayout()
        Me.pnlFUNCTION_GROUP.SuspendLayout()
        Me.GRP_BODY.SuspendLayout()
        Me.PNL_INPUT_DATA.SuspendLayout()
        Me.PNL_CODE_WORK.SuspendLayout()
        Me.PNL_KIND_WORK.SuspendLayout()
        Me.PNL_CODE_HANDLE.SuspendLayout()
        Me.PNL_DEPOSIT_DONE.SuspendLayout()
        Me.PNL_INVOICE_DONE.SuspendLayout()
        Me.PNL_DATE_INVOICE_BASE.SuspendLayout()
        Me.PNL_NUMBER_ORDER.SuspendLayout()
        Me.PNL_NAME_CONTRACT.SuspendLayout()
        Me.PNL_DATE_WORK.SuspendLayout()
        Me.PNL_EXT_SPOT.SuspendLayout()
        Me.PNL_NAME_ADDRESS_02.SuspendLayout()
        Me.PNL_NAME_ADDRESS_01.SuspendLayout()
        Me.PNL_CODE_POST.SuspendLayout()
        Me.PNL_NAME_OWNER.SuspendLayout()
        Me.PNL_NAME_MEMO.SuspendLayout()
        Me.PNL_KINGAKU_CONTRACT.SuspendLayout()
        Me.PNL_DATE_CONTRACT.SuspendLayout()
        Me.PNL_CODE_SHINTO_PARENT.SuspendLayout()
        Me.PNL_INPUT_KEY.SuspendLayout()
        Me.PNL_NUMBER_CONTRACT.SuspendLayout()
        Me.SuspendLayout()
        '
        'GRP_HEAD
        '
        Me.GRP_HEAD.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GRP_HEAD.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.GRP_HEAD.Controls.Add(Me.PNL_INFO_GUIDE)
        Me.GRP_HEAD.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GRP_HEAD.Location = New System.Drawing.Point(10, 10)
        Me.GRP_HEAD.Name = "GRP_HEAD"
        Me.GRP_HEAD.Size = New System.Drawing.Size(760, 50)
        Me.GRP_HEAD.TabIndex = 0
        Me.GRP_HEAD.TabStop = False
        '
        'PNL_INFO_GUIDE
        '
        Me.PNL_INFO_GUIDE.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PNL_INFO_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.PNL_INFO_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PNL_INFO_GUIDE.Controls.Add(Me.PNL_NAME_USER_HEAD)
        Me.PNL_INFO_GUIDE.Controls.Add(Me.PNL_DATE_ACTIVE_HEAD)
        Me.PNL_INFO_GUIDE.Location = New System.Drawing.Point(10, 12)
        Me.PNL_INFO_GUIDE.Name = "PNL_INFO_GUIDE"
        Me.PNL_INFO_GUIDE.Size = New System.Drawing.Size(740, 34)
        Me.PNL_INFO_GUIDE.TabIndex = 0
        '
        'PNL_NAME_USER_HEAD
        '
        Me.PNL_NAME_USER_HEAD.Controls.Add(Me.LBL_NAME_USER_HEAD)
        Me.PNL_NAME_USER_HEAD.Controls.Add(Me.LBL_NAME_USER_HEAD_GUIDE)
        Me.PNL_NAME_USER_HEAD.Location = New System.Drawing.Point(250, 1)
        Me.PNL_NAME_USER_HEAD.Name = "PNL_NAME_USER_HEAD"
        Me.PNL_NAME_USER_HEAD.Size = New System.Drawing.Size(240, 30)
        Me.PNL_NAME_USER_HEAD.TabIndex = 10
        '
        'LBL_NAME_USER_HEAD
        '
        Me.LBL_NAME_USER_HEAD.AutoEllipsis = True
        Me.LBL_NAME_USER_HEAD.BackColor = System.Drawing.Color.White
        Me.LBL_NAME_USER_HEAD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_NAME_USER_HEAD.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBL_NAME_USER_HEAD.Location = New System.Drawing.Point(80, 1)
        Me.LBL_NAME_USER_HEAD.Name = "LBL_NAME_USER_HEAD"
        Me.LBL_NAME_USER_HEAD.Size = New System.Drawing.Size(150, 25)
        Me.LBL_NAME_USER_HEAD.TabIndex = 3
        Me.LBL_NAME_USER_HEAD.Tag = "Clear"
        Me.LBL_NAME_USER_HEAD.Text = "＊＊＊"
        Me.LBL_NAME_USER_HEAD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LBL_NAME_USER_HEAD_GUIDE
        '
        Me.LBL_NAME_USER_HEAD_GUIDE.AutoEllipsis = True
        Me.LBL_NAME_USER_HEAD_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_NAME_USER_HEAD_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_NAME_USER_HEAD_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_NAME_USER_HEAD_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_NAME_USER_HEAD_GUIDE.Name = "LBL_NAME_USER_HEAD_GUIDE"
        Me.LBL_NAME_USER_HEAD_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_NAME_USER_HEAD_GUIDE.TabIndex = 1
        Me.LBL_NAME_USER_HEAD_GUIDE.Text = "ログオン者"
        Me.LBL_NAME_USER_HEAD_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PNL_DATE_ACTIVE_HEAD
        '
        Me.PNL_DATE_ACTIVE_HEAD.Controls.Add(Me.LBL_DATE_ACTIVE_HEAD)
        Me.PNL_DATE_ACTIVE_HEAD.Controls.Add(Me.LBL_DATE_ACTIVE_HEAD_GUIDE)
        Me.PNL_DATE_ACTIVE_HEAD.Location = New System.Drawing.Point(5, 1)
        Me.PNL_DATE_ACTIVE_HEAD.Name = "PNL_DATE_ACTIVE_HEAD"
        Me.PNL_DATE_ACTIVE_HEAD.Size = New System.Drawing.Size(240, 30)
        Me.PNL_DATE_ACTIVE_HEAD.TabIndex = 9
        '
        'LBL_DATE_ACTIVE_HEAD
        '
        Me.LBL_DATE_ACTIVE_HEAD.AutoEllipsis = True
        Me.LBL_DATE_ACTIVE_HEAD.BackColor = System.Drawing.Color.White
        Me.LBL_DATE_ACTIVE_HEAD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_DATE_ACTIVE_HEAD.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBL_DATE_ACTIVE_HEAD.Location = New System.Drawing.Point(80, 1)
        Me.LBL_DATE_ACTIVE_HEAD.Name = "LBL_DATE_ACTIVE_HEAD"
        Me.LBL_DATE_ACTIVE_HEAD.Size = New System.Drawing.Size(150, 25)
        Me.LBL_DATE_ACTIVE_HEAD.TabIndex = 4
        Me.LBL_DATE_ACTIVE_HEAD.Tag = "Clear"
        Me.LBL_DATE_ACTIVE_HEAD.Text = "＊＊＊"
        Me.LBL_DATE_ACTIVE_HEAD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LBL_DATE_ACTIVE_HEAD_GUIDE
        '
        Me.LBL_DATE_ACTIVE_HEAD_GUIDE.AutoEllipsis = True
        Me.LBL_DATE_ACTIVE_HEAD_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_DATE_ACTIVE_HEAD_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_DATE_ACTIVE_HEAD_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_DATE_ACTIVE_HEAD_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_DATE_ACTIVE_HEAD_GUIDE.Name = "LBL_DATE_ACTIVE_HEAD_GUIDE"
        Me.LBL_DATE_ACTIVE_HEAD_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_DATE_ACTIVE_HEAD_GUIDE.TabIndex = 3
        Me.LBL_DATE_ACTIVE_HEAD_GUIDE.Text = "処理日"
        Me.LBL_DATE_ACTIVE_HEAD_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GRP_FOOT
        '
        Me.GRP_FOOT.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GRP_FOOT.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.GRP_FOOT.Controls.Add(Me.pnlFUNCTION_GROUP)
        Me.GRP_FOOT.Location = New System.Drawing.Point(10, 490)
        Me.GRP_FOOT.Name = "GRP_FOOT"
        Me.GRP_FOOT.Size = New System.Drawing.Size(760, 60)
        Me.GRP_FOOT.TabIndex = 2
        Me.GRP_FOOT.TabStop = False
        '
        'pnlFUNCTION_GROUP
        '
        Me.pnlFUNCTION_GROUP.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnlFUNCTION_GROUP.AutoScroll = True
        Me.pnlFUNCTION_GROUP.Controls.Add(Me.BTN_CLEAR)
        Me.pnlFUNCTION_GROUP.Controls.Add(Me.BTN_DELETE)
        Me.pnlFUNCTION_GROUP.Controls.Add(Me.BTN_ENTER)
        Me.pnlFUNCTION_GROUP.Controls.Add(Me.BTN_END)
        Me.pnlFUNCTION_GROUP.Location = New System.Drawing.Point(200, 15)
        Me.pnlFUNCTION_GROUP.MinimumSize = New System.Drawing.Size(190, 40)
        Me.pnlFUNCTION_GROUP.Name = "pnlFUNCTION_GROUP"
        Me.pnlFUNCTION_GROUP.Size = New System.Drawing.Size(355, 40)
        Me.pnlFUNCTION_GROUP.TabIndex = 1
        '
        'BTN_CLEAR
        '
        Me.BTN_CLEAR.AutoSize = True
        Me.BTN_CLEAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_CLEAR.Location = New System.Drawing.Point(180, 5)
        Me.BTN_CLEAR.MinimumSize = New System.Drawing.Size(80, 30)
        Me.BTN_CLEAR.Name = "BTN_CLEAR"
        Me.BTN_CLEAR.Size = New System.Drawing.Size(80, 30)
        Me.BTN_CLEAR.TabIndex = 2
        Me.BTN_CLEAR.Text = "クリア"
        Me.BTN_CLEAR.UseVisualStyleBackColor = False
        '
        'BTN_DELETE
        '
        Me.BTN_DELETE.AutoSize = True
        Me.BTN_DELETE.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_DELETE.Location = New System.Drawing.Point(95, 5)
        Me.BTN_DELETE.MinimumSize = New System.Drawing.Size(80, 30)
        Me.BTN_DELETE.Name = "BTN_DELETE"
        Me.BTN_DELETE.Size = New System.Drawing.Size(80, 30)
        Me.BTN_DELETE.TabIndex = 1
        Me.BTN_DELETE.Text = "削除"
        Me.BTN_DELETE.UseVisualStyleBackColor = False
        '
        'BTN_ENTER
        '
        Me.BTN_ENTER.AutoSize = True
        Me.BTN_ENTER.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_ENTER.Location = New System.Drawing.Point(10, 5)
        Me.BTN_ENTER.MinimumSize = New System.Drawing.Size(80, 30)
        Me.BTN_ENTER.Name = "BTN_ENTER"
        Me.BTN_ENTER.Size = New System.Drawing.Size(80, 30)
        Me.BTN_ENTER.TabIndex = 0
        Me.BTN_ENTER.Text = "登録"
        Me.BTN_ENTER.UseVisualStyleBackColor = False
        '
        'BTN_END
        '
        Me.BTN_END.AutoSize = True
        Me.BTN_END.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_END.Location = New System.Drawing.Point(265, 5)
        Me.BTN_END.MinimumSize = New System.Drawing.Size(80, 30)
        Me.BTN_END.Name = "BTN_END"
        Me.BTN_END.Size = New System.Drawing.Size(80, 30)
        Me.BTN_END.TabIndex = 3
        Me.BTN_END.Text = "終了"
        Me.BTN_END.UseVisualStyleBackColor = False
        '
        'GRP_BODY
        '
        Me.GRP_BODY.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GRP_BODY.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.GRP_BODY.Controls.Add(Me.PNL_INPUT_DATA)
        Me.GRP_BODY.Controls.Add(Me.PNL_INPUT_KEY)
        Me.GRP_BODY.Location = New System.Drawing.Point(10, 60)
        Me.GRP_BODY.Name = "GRP_BODY"
        Me.GRP_BODY.Size = New System.Drawing.Size(760, 430)
        Me.GRP_BODY.TabIndex = 1
        Me.GRP_BODY.TabStop = False
        '
        'PNL_INPUT_DATA
        '
        Me.PNL_INPUT_DATA.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PNL_INPUT_DATA.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.PNL_INPUT_DATA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PNL_INPUT_DATA.Controls.Add(Me.PNL_CODE_WORK)
        Me.PNL_INPUT_DATA.Controls.Add(Me.PNL_KIND_WORK)
        Me.PNL_INPUT_DATA.Controls.Add(Me.PNL_CODE_HANDLE)
        Me.PNL_INPUT_DATA.Controls.Add(Me.PNL_DEPOSIT_DONE)
        Me.PNL_INPUT_DATA.Controls.Add(Me.PNL_INVOICE_DONE)
        Me.PNL_INPUT_DATA.Controls.Add(Me.PNL_DATE_INVOICE_BASE)
        Me.PNL_INPUT_DATA.Controls.Add(Me.PNL_NUMBER_ORDER)
        Me.PNL_INPUT_DATA.Controls.Add(Me.PNL_NAME_CONTRACT)
        Me.PNL_INPUT_DATA.Controls.Add(Me.PNL_DATE_WORK)
        Me.PNL_INPUT_DATA.Controls.Add(Me.PNL_EXT_SPOT)
        Me.PNL_INPUT_DATA.Controls.Add(Me.PNL_NAME_MEMO)
        Me.PNL_INPUT_DATA.Controls.Add(Me.PNL_KINGAKU_CONTRACT)
        Me.PNL_INPUT_DATA.Controls.Add(Me.PNL_DATE_CONTRACT)
        Me.PNL_INPUT_DATA.Controls.Add(Me.PNL_CODE_SHINTO_PARENT)
        Me.PNL_INPUT_DATA.Location = New System.Drawing.Point(10, 70)
        Me.PNL_INPUT_DATA.Name = "PNL_INPUT_DATA"
        Me.PNL_INPUT_DATA.Size = New System.Drawing.Size(740, 350)
        Me.PNL_INPUT_DATA.TabIndex = 1
        '
        'PNL_CODE_WORK
        '
        Me.PNL_CODE_WORK.Controls.Add(Me.CMB_CODE_WORK)
        Me.PNL_CODE_WORK.Controls.Add(Me.LBL_CODE_WORK_GUIDE)
        Me.PNL_CODE_WORK.Location = New System.Drawing.Point(250, 170)
        Me.PNL_CODE_WORK.Name = "PNL_CODE_WORK"
        Me.PNL_CODE_WORK.Size = New System.Drawing.Size(240, 30)
        Me.PNL_CODE_WORK.TabIndex = 8
        '
        'CMB_CODE_WORK
        '
        Me.CMB_CODE_WORK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_CODE_WORK.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CMB_CODE_WORK.Location = New System.Drawing.Point(80, 1)
        Me.CMB_CODE_WORK.Name = "CMB_CODE_WORK"
        Me.CMB_CODE_WORK.Size = New System.Drawing.Size(150, 26)
        Me.CMB_CODE_WORK.TabIndex = 1
        Me.CMB_CODE_WORK.Tag = "Clear"
        '
        'LBL_CODE_WORK_GUIDE
        '
        Me.LBL_CODE_WORK_GUIDE.AutoEllipsis = True
        Me.LBL_CODE_WORK_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_CODE_WORK_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_CODE_WORK_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_CODE_WORK_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_CODE_WORK_GUIDE.Name = "LBL_CODE_WORK_GUIDE"
        Me.LBL_CODE_WORK_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_CODE_WORK_GUIDE.TabIndex = 0
        Me.LBL_CODE_WORK_GUIDE.Text = "作業"
        Me.LBL_CODE_WORK_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PNL_KIND_WORK
        '
        Me.PNL_KIND_WORK.Controls.Add(Me.CMB_KIND_WORK)
        Me.PNL_KIND_WORK.Controls.Add(Me.LBL_KIND_WORK_GUIDE)
        Me.PNL_KIND_WORK.Location = New System.Drawing.Point(5, 170)
        Me.PNL_KIND_WORK.Name = "PNL_KIND_WORK"
        Me.PNL_KIND_WORK.Size = New System.Drawing.Size(240, 30)
        Me.PNL_KIND_WORK.TabIndex = 7
        '
        'CMB_KIND_WORK
        '
        Me.CMB_KIND_WORK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_KIND_WORK.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CMB_KIND_WORK.Location = New System.Drawing.Point(80, 1)
        Me.CMB_KIND_WORK.Name = "CMB_KIND_WORK"
        Me.CMB_KIND_WORK.Size = New System.Drawing.Size(150, 26)
        Me.CMB_KIND_WORK.TabIndex = 1
        Me.CMB_KIND_WORK.Tag = "Clear"
        '
        'LBL_KIND_WORK_GUIDE
        '
        Me.LBL_KIND_WORK_GUIDE.AutoEllipsis = True
        Me.LBL_KIND_WORK_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_KIND_WORK_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_KIND_WORK_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_KIND_WORK_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_KIND_WORK_GUIDE.Name = "LBL_KIND_WORK_GUIDE"
        Me.LBL_KIND_WORK_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_KIND_WORK_GUIDE.TabIndex = 0
        Me.LBL_KIND_WORK_GUIDE.Text = "作業区分"
        Me.LBL_KIND_WORK_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PNL_CODE_HANDLE
        '
        Me.PNL_CODE_HANDLE.Controls.Add(Me.CMB_CODE_SECTION)
        Me.PNL_CODE_HANDLE.Controls.Add(Me.LBL_CODE_SECTION_GUIDE)
        Me.PNL_CODE_HANDLE.Location = New System.Drawing.Point(370, 75)
        Me.PNL_CODE_HANDLE.Name = "PNL_CODE_HANDLE"
        Me.PNL_CODE_HANDLE.Size = New System.Drawing.Size(240, 30)
        Me.PNL_CODE_HANDLE.TabIndex = 5
        '
        'CMB_CODE_SECTION
        '
        Me.CMB_CODE_SECTION.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_CODE_SECTION.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CMB_CODE_SECTION.Location = New System.Drawing.Point(80, 1)
        Me.CMB_CODE_SECTION.Name = "CMB_CODE_SECTION"
        Me.CMB_CODE_SECTION.Size = New System.Drawing.Size(150, 26)
        Me.CMB_CODE_SECTION.TabIndex = 1
        Me.CMB_CODE_SECTION.Tag = "Clear"
        '
        'LBL_CODE_SECTION_GUIDE
        '
        Me.LBL_CODE_SECTION_GUIDE.AutoEllipsis = True
        Me.LBL_CODE_SECTION_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_CODE_SECTION_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_CODE_SECTION_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_CODE_SECTION_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_CODE_SECTION_GUIDE.Name = "LBL_CODE_SECTION_GUIDE"
        Me.LBL_CODE_SECTION_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_CODE_SECTION_GUIDE.TabIndex = 0
        Me.LBL_CODE_SECTION_GUIDE.Text = "担当部署"
        Me.LBL_CODE_SECTION_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PNL_DEPOSIT_DONE
        '
        Me.PNL_DEPOSIT_DONE.Controls.Add(Me.LBL_DEPOSIT_DONE)
        Me.PNL_DEPOSIT_DONE.Controls.Add(Me.LBL_DEPOSIT_DONE_GUIDE)
        Me.PNL_DEPOSIT_DONE.Location = New System.Drawing.Point(495, 5)
        Me.PNL_DEPOSIT_DONE.Name = "PNL_DEPOSIT_DONE"
        Me.PNL_DEPOSIT_DONE.Size = New System.Drawing.Size(240, 30)
        Me.PNL_DEPOSIT_DONE.TabIndex = 2
        '
        'LBL_DEPOSIT_DONE
        '
        Me.LBL_DEPOSIT_DONE.AutoEllipsis = True
        Me.LBL_DEPOSIT_DONE.BackColor = System.Drawing.Color.White
        Me.LBL_DEPOSIT_DONE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_DEPOSIT_DONE.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBL_DEPOSIT_DONE.Location = New System.Drawing.Point(80, 1)
        Me.LBL_DEPOSIT_DONE.Name = "LBL_DEPOSIT_DONE"
        Me.LBL_DEPOSIT_DONE.Size = New System.Drawing.Size(150, 25)
        Me.LBL_DEPOSIT_DONE.TabIndex = 10
        Me.LBL_DEPOSIT_DONE.Tag = "Clear"
        Me.LBL_DEPOSIT_DONE.Text = "＊＊＊"
        Me.LBL_DEPOSIT_DONE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LBL_DEPOSIT_DONE_GUIDE
        '
        Me.LBL_DEPOSIT_DONE_GUIDE.AutoEllipsis = True
        Me.LBL_DEPOSIT_DONE_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_DEPOSIT_DONE_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_DEPOSIT_DONE_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_DEPOSIT_DONE_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_DEPOSIT_DONE_GUIDE.Name = "LBL_DEPOSIT_DONE_GUIDE"
        Me.LBL_DEPOSIT_DONE_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_DEPOSIT_DONE_GUIDE.TabIndex = 3
        Me.LBL_DEPOSIT_DONE_GUIDE.Text = "入金"
        Me.LBL_DEPOSIT_DONE_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PNL_INVOICE_DONE
        '
        Me.PNL_INVOICE_DONE.Controls.Add(Me.LBL_INVOICE_DONE)
        Me.PNL_INVOICE_DONE.Controls.Add(Me.LBL_INVOICE_DONE_GUIDE)
        Me.PNL_INVOICE_DONE.Location = New System.Drawing.Point(250, 5)
        Me.PNL_INVOICE_DONE.Name = "PNL_INVOICE_DONE"
        Me.PNL_INVOICE_DONE.Size = New System.Drawing.Size(240, 30)
        Me.PNL_INVOICE_DONE.TabIndex = 1
        '
        'LBL_INVOICE_DONE
        '
        Me.LBL_INVOICE_DONE.AutoEllipsis = True
        Me.LBL_INVOICE_DONE.BackColor = System.Drawing.Color.White
        Me.LBL_INVOICE_DONE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_INVOICE_DONE.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBL_INVOICE_DONE.Location = New System.Drawing.Point(80, 1)
        Me.LBL_INVOICE_DONE.Name = "LBL_INVOICE_DONE"
        Me.LBL_INVOICE_DONE.Size = New System.Drawing.Size(150, 25)
        Me.LBL_INVOICE_DONE.TabIndex = 10
        Me.LBL_INVOICE_DONE.Tag = "Clear"
        Me.LBL_INVOICE_DONE.Text = "＊＊＊"
        Me.LBL_INVOICE_DONE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LBL_INVOICE_DONE_GUIDE
        '
        Me.LBL_INVOICE_DONE_GUIDE.AutoEllipsis = True
        Me.LBL_INVOICE_DONE_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_INVOICE_DONE_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_INVOICE_DONE_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_INVOICE_DONE_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_INVOICE_DONE_GUIDE.Name = "LBL_INVOICE_DONE_GUIDE"
        Me.LBL_INVOICE_DONE_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_INVOICE_DONE_GUIDE.TabIndex = 3
        Me.LBL_INVOICE_DONE_GUIDE.Text = "請求"
        Me.LBL_INVOICE_DONE_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PNL_DATE_INVOICE_BASE
        '
        Me.PNL_DATE_INVOICE_BASE.Controls.Add(Me.DTP_DATE_INVOICE_BASE)
        Me.PNL_DATE_INVOICE_BASE.Controls.Add(Me.LBL_DATE_INVOICE_BASE_GUIDE)
        Me.PNL_DATE_INVOICE_BASE.Location = New System.Drawing.Point(5, 275)
        Me.PNL_DATE_INVOICE_BASE.Name = "PNL_DATE_INVOICE_BASE"
        Me.PNL_DATE_INVOICE_BASE.Size = New System.Drawing.Size(240, 30)
        Me.PNL_DATE_INVOICE_BASE.TabIndex = 11
        '
        'DTP_DATE_INVOICE_BASE
        '
        Me.DTP_DATE_INVOICE_BASE.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.DTP_DATE_INVOICE_BASE.Location = New System.Drawing.Point(90, 1)
        Me.DTP_DATE_INVOICE_BASE.Name = "DTP_DATE_INVOICE_BASE"
        Me.DTP_DATE_INVOICE_BASE.Size = New System.Drawing.Size(140, 25)
        Me.DTP_DATE_INVOICE_BASE.TabIndex = 1
        Me.DTP_DATE_INVOICE_BASE.Tag = "Clear"
        '
        'LBL_DATE_INVOICE_BASE_GUIDE
        '
        Me.LBL_DATE_INVOICE_BASE_GUIDE.AutoEllipsis = True
        Me.LBL_DATE_INVOICE_BASE_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_DATE_INVOICE_BASE_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_DATE_INVOICE_BASE_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_DATE_INVOICE_BASE_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_DATE_INVOICE_BASE_GUIDE.Name = "LBL_DATE_INVOICE_BASE_GUIDE"
        Me.LBL_DATE_INVOICE_BASE_GUIDE.Size = New System.Drawing.Size(89, 25)
        Me.LBL_DATE_INVOICE_BASE_GUIDE.TabIndex = 0
        Me.LBL_DATE_INVOICE_BASE_GUIDE.Text = "請求基準日付"
        Me.LBL_DATE_INVOICE_BASE_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PNL_NUMBER_ORDER
        '
        Me.PNL_NUMBER_ORDER.Controls.Add(Me.LBL_NUMBER_ORDER_GUIDE)
        Me.PNL_NUMBER_ORDER.Controls.Add(Me.TXT_NUMBER_ORDER)
        Me.PNL_NUMBER_ORDER.Location = New System.Drawing.Point(5, 5)
        Me.PNL_NUMBER_ORDER.Name = "PNL_NUMBER_ORDER"
        Me.PNL_NUMBER_ORDER.Size = New System.Drawing.Size(240, 30)
        Me.PNL_NUMBER_ORDER.TabIndex = 0
        '
        'LBL_NUMBER_ORDER_GUIDE
        '
        Me.LBL_NUMBER_ORDER_GUIDE.AutoEllipsis = True
        Me.LBL_NUMBER_ORDER_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_NUMBER_ORDER_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_NUMBER_ORDER_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_NUMBER_ORDER_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_NUMBER_ORDER_GUIDE.Name = "LBL_NUMBER_ORDER_GUIDE"
        Me.LBL_NUMBER_ORDER_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_NUMBER_ORDER_GUIDE.TabIndex = 3
        Me.LBL_NUMBER_ORDER_GUIDE.Text = "受注番号"
        Me.LBL_NUMBER_ORDER_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXT_NUMBER_ORDER
        '
        Me.TXT_NUMBER_ORDER.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TXT_NUMBER_ORDER.Location = New System.Drawing.Point(80, 1)
        Me.TXT_NUMBER_ORDER.MaxLength = 6
        Me.TXT_NUMBER_ORDER.Name = "TXT_NUMBER_ORDER"
        Me.TXT_NUMBER_ORDER.Size = New System.Drawing.Size(150, 25)
        Me.TXT_NUMBER_ORDER.TabIndex = 1
        Me.TXT_NUMBER_ORDER.Tag = "Clear,Numeric,Format=000000,Check,Plus"
        Me.TXT_NUMBER_ORDER.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PNL_NAME_CONTRACT
        '
        Me.PNL_NAME_CONTRACT.Controls.Add(Me.TXT_NAME_CONTRACT)
        Me.PNL_NAME_CONTRACT.Controls.Add(Me.LBL_NAME_CONTRACT_GUIDE)
        Me.PNL_NAME_CONTRACT.Location = New System.Drawing.Point(5, 205)
        Me.PNL_NAME_CONTRACT.Name = "PNL_NAME_CONTRACT"
        Me.PNL_NAME_CONTRACT.Size = New System.Drawing.Size(485, 30)
        Me.PNL_NAME_CONTRACT.TabIndex = 9
        '
        'TXT_NAME_CONTRACT
        '
        Me.TXT_NAME_CONTRACT.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.TXT_NAME_CONTRACT.Location = New System.Drawing.Point(80, 1)
        Me.TXT_NAME_CONTRACT.MaxLength = 20
        Me.TXT_NAME_CONTRACT.Name = "TXT_NAME_CONTRACT"
        Me.TXT_NAME_CONTRACT.Size = New System.Drawing.Size(400, 25)
        Me.TXT_NAME_CONTRACT.TabIndex = 1
        Me.TXT_NAME_CONTRACT.Tag = "Clear,Check,Char"
        '
        'LBL_NAME_CONTRACT_GUIDE
        '
        Me.LBL_NAME_CONTRACT_GUIDE.AutoEllipsis = True
        Me.LBL_NAME_CONTRACT_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_NAME_CONTRACT_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_NAME_CONTRACT_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_NAME_CONTRACT_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_NAME_CONTRACT_GUIDE.Name = "LBL_NAME_CONTRACT_GUIDE"
        Me.LBL_NAME_CONTRACT_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_NAME_CONTRACT_GUIDE.TabIndex = 0
        Me.LBL_NAME_CONTRACT_GUIDE.Text = "契約内容"
        Me.LBL_NAME_CONTRACT_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PNL_DATE_WORK
        '
        Me.PNL_DATE_WORK.Controls.Add(Me.LBL_DATE_WORK_FROM_TO_GUIDE)
        Me.PNL_DATE_WORK.Controls.Add(Me.DTP_DATE_WORK_TO)
        Me.PNL_DATE_WORK.Controls.Add(Me.DTP_DATE_WORK_FROM)
        Me.PNL_DATE_WORK.Controls.Add(Me.LBL_DATE_WORK_GUIDE)
        Me.PNL_DATE_WORK.Location = New System.Drawing.Point(5, 240)
        Me.PNL_DATE_WORK.Name = "PNL_DATE_WORK"
        Me.PNL_DATE_WORK.Size = New System.Drawing.Size(485, 30)
        Me.PNL_DATE_WORK.TabIndex = 10
        '
        'LBL_DATE_WORK_FROM_TO_GUIDE
        '
        Me.LBL_DATE_WORK_FROM_TO_GUIDE.AutoEllipsis = True
        Me.LBL_DATE_WORK_FROM_TO_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_DATE_WORK_FROM_TO_GUIDE.Location = New System.Drawing.Point(240, 1)
        Me.LBL_DATE_WORK_FROM_TO_GUIDE.Name = "LBL_DATE_WORK_FROM_TO_GUIDE"
        Me.LBL_DATE_WORK_FROM_TO_GUIDE.Size = New System.Drawing.Size(20, 25)
        Me.LBL_DATE_WORK_FROM_TO_GUIDE.TabIndex = 8
        Me.LBL_DATE_WORK_FROM_TO_GUIDE.Text = "～"
        Me.LBL_DATE_WORK_FROM_TO_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DTP_DATE_WORK_TO
        '
        Me.DTP_DATE_WORK_TO.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.DTP_DATE_WORK_TO.Location = New System.Drawing.Point(270, 1)
        Me.DTP_DATE_WORK_TO.Name = "DTP_DATE_WORK_TO"
        Me.DTP_DATE_WORK_TO.Size = New System.Drawing.Size(150, 25)
        Me.DTP_DATE_WORK_TO.TabIndex = 7
        Me.DTP_DATE_WORK_TO.Tag = "Clear"
        '
        'DTP_DATE_WORK_FROM
        '
        Me.DTP_DATE_WORK_FROM.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.DTP_DATE_WORK_FROM.Location = New System.Drawing.Point(80, 1)
        Me.DTP_DATE_WORK_FROM.Name = "DTP_DATE_WORK_FROM"
        Me.DTP_DATE_WORK_FROM.Size = New System.Drawing.Size(150, 25)
        Me.DTP_DATE_WORK_FROM.TabIndex = 1
        Me.DTP_DATE_WORK_FROM.Tag = "Clear"
        '
        'LBL_DATE_WORK_GUIDE
        '
        Me.LBL_DATE_WORK_GUIDE.AutoEllipsis = True
        Me.LBL_DATE_WORK_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_DATE_WORK_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_DATE_WORK_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_DATE_WORK_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_DATE_WORK_GUIDE.Name = "LBL_DATE_WORK_GUIDE"
        Me.LBL_DATE_WORK_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_DATE_WORK_GUIDE.TabIndex = 0
        Me.LBL_DATE_WORK_GUIDE.Text = "作業期間"
        Me.LBL_DATE_WORK_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PNL_EXT_SPOT
        '
        Me.PNL_EXT_SPOT.Controls.Add(Me.PNL_NAME_ADDRESS_02)
        Me.PNL_EXT_SPOT.Controls.Add(Me.PNL_NAME_ADDRESS_01)
        Me.PNL_EXT_SPOT.Controls.Add(Me.PNL_CODE_POST)
        Me.PNL_EXT_SPOT.Controls.Add(Me.PNL_NAME_OWNER)
        Me.PNL_EXT_SPOT.Location = New System.Drawing.Point(0, 105)
        Me.PNL_EXT_SPOT.Name = "PNL_EXT_SPOT"
        Me.PNL_EXT_SPOT.Size = New System.Drawing.Size(740, 60)
        Me.PNL_EXT_SPOT.TabIndex = 6
        '
        'PNL_NAME_ADDRESS_02
        '
        Me.PNL_NAME_ADDRESS_02.Controls.Add(Me.TXT_NAME_ADDRESS_02)
        Me.PNL_NAME_ADDRESS_02.Controls.Add(Me.LBL_NAME_ADDRESS_02)
        Me.PNL_NAME_ADDRESS_02.Location = New System.Drawing.Point(250, 30)
        Me.PNL_NAME_ADDRESS_02.Name = "PNL_NAME_ADDRESS_02"
        Me.PNL_NAME_ADDRESS_02.Size = New System.Drawing.Size(240, 30)
        Me.PNL_NAME_ADDRESS_02.TabIndex = 3
        '
        'TXT_NAME_ADDRESS_02
        '
        Me.TXT_NAME_ADDRESS_02.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.TXT_NAME_ADDRESS_02.Location = New System.Drawing.Point(80, 1)
        Me.TXT_NAME_ADDRESS_02.MaxLength = 12
        Me.TXT_NAME_ADDRESS_02.Name = "TXT_NAME_ADDRESS_02"
        Me.TXT_NAME_ADDRESS_02.Size = New System.Drawing.Size(150, 25)
        Me.TXT_NAME_ADDRESS_02.TabIndex = 1
        Me.TXT_NAME_ADDRESS_02.Tag = "Clear,Check,Char,NotNull"
        '
        'LBL_NAME_ADDRESS_02
        '
        Me.LBL_NAME_ADDRESS_02.AutoEllipsis = True
        Me.LBL_NAME_ADDRESS_02.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_NAME_ADDRESS_02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_NAME_ADDRESS_02.ForeColor = System.Drawing.Color.Black
        Me.LBL_NAME_ADDRESS_02.Location = New System.Drawing.Point(1, 1)
        Me.LBL_NAME_ADDRESS_02.Name = "LBL_NAME_ADDRESS_02"
        Me.LBL_NAME_ADDRESS_02.Size = New System.Drawing.Size(79, 25)
        Me.LBL_NAME_ADDRESS_02.TabIndex = 0
        Me.LBL_NAME_ADDRESS_02.Text = "住所2"
        Me.LBL_NAME_ADDRESS_02.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PNL_NAME_ADDRESS_01
        '
        Me.PNL_NAME_ADDRESS_01.Controls.Add(Me.TXT_NAME_ADDRESS_01)
        Me.PNL_NAME_ADDRESS_01.Controls.Add(Me.LBL_NAME_ADDRESS_01)
        Me.PNL_NAME_ADDRESS_01.Location = New System.Drawing.Point(5, 30)
        Me.PNL_NAME_ADDRESS_01.Name = "PNL_NAME_ADDRESS_01"
        Me.PNL_NAME_ADDRESS_01.Size = New System.Drawing.Size(240, 30)
        Me.PNL_NAME_ADDRESS_01.TabIndex = 2
        '
        'TXT_NAME_ADDRESS_01
        '
        Me.TXT_NAME_ADDRESS_01.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.TXT_NAME_ADDRESS_01.Location = New System.Drawing.Point(80, 1)
        Me.TXT_NAME_ADDRESS_01.MaxLength = 12
        Me.TXT_NAME_ADDRESS_01.Name = "TXT_NAME_ADDRESS_01"
        Me.TXT_NAME_ADDRESS_01.Size = New System.Drawing.Size(150, 25)
        Me.TXT_NAME_ADDRESS_01.TabIndex = 1
        Me.TXT_NAME_ADDRESS_01.Tag = "Clear,Check,Char,NotNull"
        '
        'LBL_NAME_ADDRESS_01
        '
        Me.LBL_NAME_ADDRESS_01.AutoEllipsis = True
        Me.LBL_NAME_ADDRESS_01.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_NAME_ADDRESS_01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_NAME_ADDRESS_01.ForeColor = System.Drawing.Color.Black
        Me.LBL_NAME_ADDRESS_01.Location = New System.Drawing.Point(1, 1)
        Me.LBL_NAME_ADDRESS_01.Name = "LBL_NAME_ADDRESS_01"
        Me.LBL_NAME_ADDRESS_01.Size = New System.Drawing.Size(79, 25)
        Me.LBL_NAME_ADDRESS_01.TabIndex = 0
        Me.LBL_NAME_ADDRESS_01.Text = "住所1"
        Me.LBL_NAME_ADDRESS_01.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PNL_CODE_POST
        '
        Me.PNL_CODE_POST.Controls.Add(Me.LBL_CODE_POST_GUIDE)
        Me.PNL_CODE_POST.Controls.Add(Me.TXT_CODE_POST)
        Me.PNL_CODE_POST.Location = New System.Drawing.Point(250, 0)
        Me.PNL_CODE_POST.Name = "PNL_CODE_POST"
        Me.PNL_CODE_POST.Size = New System.Drawing.Size(240, 30)
        Me.PNL_CODE_POST.TabIndex = 1
        '
        'LBL_CODE_POST_GUIDE
        '
        Me.LBL_CODE_POST_GUIDE.AutoEllipsis = True
        Me.LBL_CODE_POST_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_CODE_POST_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_CODE_POST_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_CODE_POST_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_CODE_POST_GUIDE.Name = "LBL_CODE_POST_GUIDE"
        Me.LBL_CODE_POST_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_CODE_POST_GUIDE.TabIndex = 3
        Me.LBL_CODE_POST_GUIDE.Text = "郵便番号"
        Me.LBL_CODE_POST_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXT_CODE_POST
        '
        Me.TXT_CODE_POST.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TXT_CODE_POST.Location = New System.Drawing.Point(80, 1)
        Me.TXT_CODE_POST.MaxLength = 7
        Me.TXT_CODE_POST.Name = "TXT_CODE_POST"
        Me.TXT_CODE_POST.Size = New System.Drawing.Size(150, 25)
        Me.TXT_CODE_POST.TabIndex = 1
        Me.TXT_CODE_POST.Tag = "Clear,Numeric,Format=0000000,Check,NotNull,Plus"
        Me.TXT_CODE_POST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PNL_NAME_OWNER
        '
        Me.PNL_NAME_OWNER.Controls.Add(Me.TXT_NAME_OWNER)
        Me.PNL_NAME_OWNER.Controls.Add(Me.LBL_NAME_OWNER_GUIDE)
        Me.PNL_NAME_OWNER.Location = New System.Drawing.Point(5, 0)
        Me.PNL_NAME_OWNER.Name = "PNL_NAME_OWNER"
        Me.PNL_NAME_OWNER.Size = New System.Drawing.Size(240, 30)
        Me.PNL_NAME_OWNER.TabIndex = 0
        '
        'TXT_NAME_OWNER
        '
        Me.TXT_NAME_OWNER.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.TXT_NAME_OWNER.Location = New System.Drawing.Point(90, 1)
        Me.TXT_NAME_OWNER.MaxLength = 12
        Me.TXT_NAME_OWNER.Name = "TXT_NAME_OWNER"
        Me.TXT_NAME_OWNER.Size = New System.Drawing.Size(140, 25)
        Me.TXT_NAME_OWNER.TabIndex = 1
        Me.TXT_NAME_OWNER.Tag = "Clear,Check,Char,NotNull"
        '
        'LBL_NAME_OWNER_GUIDE
        '
        Me.LBL_NAME_OWNER_GUIDE.AutoEllipsis = True
        Me.LBL_NAME_OWNER_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_NAME_OWNER_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_NAME_OWNER_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_NAME_OWNER_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_NAME_OWNER_GUIDE.Name = "LBL_NAME_OWNER_GUIDE"
        Me.LBL_NAME_OWNER_GUIDE.Size = New System.Drawing.Size(89, 25)
        Me.LBL_NAME_OWNER_GUIDE.TabIndex = 0
        Me.LBL_NAME_OWNER_GUIDE.Text = "オーナー名称"
        Me.LBL_NAME_OWNER_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PNL_NAME_MEMO
        '
        Me.PNL_NAME_MEMO.Controls.Add(Me.TXT_NAME_MEMO)
        Me.PNL_NAME_MEMO.Controls.Add(Me.LBL_NAME_MEMO_GUIDE)
        Me.PNL_NAME_MEMO.Location = New System.Drawing.Point(250, 310)
        Me.PNL_NAME_MEMO.Name = "PNL_NAME_MEMO"
        Me.PNL_NAME_MEMO.Size = New System.Drawing.Size(360, 30)
        Me.PNL_NAME_MEMO.TabIndex = 13
        '
        'TXT_NAME_MEMO
        '
        Me.TXT_NAME_MEMO.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.TXT_NAME_MEMO.Location = New System.Drawing.Point(80, 1)
        Me.TXT_NAME_MEMO.MaxLength = 20
        Me.TXT_NAME_MEMO.Name = "TXT_NAME_MEMO"
        Me.TXT_NAME_MEMO.Size = New System.Drawing.Size(270, 25)
        Me.TXT_NAME_MEMO.TabIndex = 1
        Me.TXT_NAME_MEMO.Tag = "Clear,Check,Char"
        '
        'LBL_NAME_MEMO_GUIDE
        '
        Me.LBL_NAME_MEMO_GUIDE.AutoEllipsis = True
        Me.LBL_NAME_MEMO_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_NAME_MEMO_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_NAME_MEMO_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_NAME_MEMO_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_NAME_MEMO_GUIDE.Name = "LBL_NAME_MEMO_GUIDE"
        Me.LBL_NAME_MEMO_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_NAME_MEMO_GUIDE.TabIndex = 0
        Me.LBL_NAME_MEMO_GUIDE.Text = "備考"
        Me.LBL_NAME_MEMO_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PNL_KINGAKU_CONTRACT
        '
        Me.PNL_KINGAKU_CONTRACT.Controls.Add(Me.LBL_KINGAKU_CONTRACT_GUIDE)
        Me.PNL_KINGAKU_CONTRACT.Controls.Add(Me.TXT_KINGAKU_CONTRACT)
        Me.PNL_KINGAKU_CONTRACT.Location = New System.Drawing.Point(5, 310)
        Me.PNL_KINGAKU_CONTRACT.Name = "PNL_KINGAKU_CONTRACT"
        Me.PNL_KINGAKU_CONTRACT.Size = New System.Drawing.Size(240, 30)
        Me.PNL_KINGAKU_CONTRACT.TabIndex = 12
        '
        'LBL_KINGAKU_CONTRACT_GUIDE
        '
        Me.LBL_KINGAKU_CONTRACT_GUIDE.AutoEllipsis = True
        Me.LBL_KINGAKU_CONTRACT_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_KINGAKU_CONTRACT_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_KINGAKU_CONTRACT_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_KINGAKU_CONTRACT_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_KINGAKU_CONTRACT_GUIDE.Name = "LBL_KINGAKU_CONTRACT_GUIDE"
        Me.LBL_KINGAKU_CONTRACT_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_KINGAKU_CONTRACT_GUIDE.TabIndex = 3
        Me.LBL_KINGAKU_CONTRACT_GUIDE.Text = "契約金額"
        Me.LBL_KINGAKU_CONTRACT_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXT_KINGAKU_CONTRACT
        '
        Me.TXT_KINGAKU_CONTRACT.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TXT_KINGAKU_CONTRACT.Location = New System.Drawing.Point(80, 1)
        Me.TXT_KINGAKU_CONTRACT.MaxLength = 12
        Me.TXT_KINGAKU_CONTRACT.Name = "TXT_KINGAKU_CONTRACT"
        Me.TXT_KINGAKU_CONTRACT.Size = New System.Drawing.Size(150, 25)
        Me.TXT_KINGAKU_CONTRACT.TabIndex = 1
        Me.TXT_KINGAKU_CONTRACT.Tag = "Clear,Numeric,Format=#@##0,Check,NotNull,Plus"
        Me.TXT_KINGAKU_CONTRACT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PNL_DATE_CONTRACT
        '
        Me.PNL_DATE_CONTRACT.Controls.Add(Me.DTP_DATE_CONTRACT)
        Me.PNL_DATE_CONTRACT.Controls.Add(Me.LBL_DATE_CONTRACT_GUIDE)
        Me.PNL_DATE_CONTRACT.Location = New System.Drawing.Point(5, 40)
        Me.PNL_DATE_CONTRACT.Name = "PNL_DATE_CONTRACT"
        Me.PNL_DATE_CONTRACT.Size = New System.Drawing.Size(240, 30)
        Me.PNL_DATE_CONTRACT.TabIndex = 3
        '
        'DTP_DATE_CONTRACT
        '
        Me.DTP_DATE_CONTRACT.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.DTP_DATE_CONTRACT.Location = New System.Drawing.Point(80, 1)
        Me.DTP_DATE_CONTRACT.Name = "DTP_DATE_CONTRACT"
        Me.DTP_DATE_CONTRACT.Size = New System.Drawing.Size(150, 25)
        Me.DTP_DATE_CONTRACT.TabIndex = 1
        Me.DTP_DATE_CONTRACT.Tag = "Clear"
        '
        'LBL_DATE_CONTRACT_GUIDE
        '
        Me.LBL_DATE_CONTRACT_GUIDE.AutoEllipsis = True
        Me.LBL_DATE_CONTRACT_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_DATE_CONTRACT_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_DATE_CONTRACT_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_DATE_CONTRACT_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_DATE_CONTRACT_GUIDE.Name = "LBL_DATE_CONTRACT_GUIDE"
        Me.LBL_DATE_CONTRACT_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_DATE_CONTRACT_GUIDE.TabIndex = 0
        Me.LBL_DATE_CONTRACT_GUIDE.Text = "契約日付"
        Me.LBL_DATE_CONTRACT_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PNL_CODE_SHINTO_PARENT
        '
        Me.PNL_CODE_SHINTO_PARENT.Controls.Add(Me.LBL_CODE_OWNER_GUIDE)
        Me.PNL_CODE_SHINTO_PARENT.Controls.Add(Me.LBL_CODE_OWNER_NAME)
        Me.PNL_CODE_SHINTO_PARENT.Controls.Add(Me.BTN_CODE_OWNER_SEARCH)
        Me.PNL_CODE_SHINTO_PARENT.Controls.Add(Me.TXT_CODE_OWNER)
        Me.PNL_CODE_SHINTO_PARENT.Location = New System.Drawing.Point(5, 75)
        Me.PNL_CODE_SHINTO_PARENT.Name = "PNL_CODE_SHINTO_PARENT"
        Me.PNL_CODE_SHINTO_PARENT.Size = New System.Drawing.Size(360, 30)
        Me.PNL_CODE_SHINTO_PARENT.TabIndex = 4
        '
        'LBL_CODE_OWNER_GUIDE
        '
        Me.LBL_CODE_OWNER_GUIDE.AutoEllipsis = True
        Me.LBL_CODE_OWNER_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_CODE_OWNER_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_CODE_OWNER_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_CODE_OWNER_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_CODE_OWNER_GUIDE.Name = "LBL_CODE_OWNER_GUIDE"
        Me.LBL_CODE_OWNER_GUIDE.Size = New System.Drawing.Size(99, 25)
        Me.LBL_CODE_OWNER_GUIDE.TabIndex = 4
        Me.LBL_CODE_OWNER_GUIDE.Text = "オーナーコード"
        Me.LBL_CODE_OWNER_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LBL_CODE_OWNER_NAME
        '
        Me.LBL_CODE_OWNER_NAME.AutoEllipsis = True
        Me.LBL_CODE_OWNER_NAME.BackColor = System.Drawing.Color.White
        Me.LBL_CODE_OWNER_NAME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_CODE_OWNER_NAME.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBL_CODE_OWNER_NAME.Location = New System.Drawing.Point(185, 1)
        Me.LBL_CODE_OWNER_NAME.Name = "LBL_CODE_OWNER_NAME"
        Me.LBL_CODE_OWNER_NAME.Size = New System.Drawing.Size(165, 25)
        Me.LBL_CODE_OWNER_NAME.TabIndex = 3
        Me.LBL_CODE_OWNER_NAME.Tag = "Clear"
        Me.LBL_CODE_OWNER_NAME.Text = "＊＊＊"
        Me.LBL_CODE_OWNER_NAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BTN_CODE_OWNER_SEARCH
        '
        Me.BTN_CODE_OWNER_SEARCH.BackgroundImage = Global.MNT_E_CONTRACT_SPOT.My.Resources.Resources.Search_16x
        Me.BTN_CODE_OWNER_SEARCH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BTN_CODE_OWNER_SEARCH.Location = New System.Drawing.Point(160, 1)
        Me.BTN_CODE_OWNER_SEARCH.Margin = New System.Windows.Forms.Padding(0)
        Me.BTN_CODE_OWNER_SEARCH.Name = "BTN_CODE_OWNER_SEARCH"
        Me.BTN_CODE_OWNER_SEARCH.Size = New System.Drawing.Size(25, 25)
        Me.BTN_CODE_OWNER_SEARCH.TabIndex = 2
        Me.BTN_CODE_OWNER_SEARCH.TabStop = False
        Me.BTN_CODE_OWNER_SEARCH.UseVisualStyleBackColor = True
        '
        'TXT_CODE_OWNER
        '
        Me.TXT_CODE_OWNER.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TXT_CODE_OWNER.Location = New System.Drawing.Point(100, 1)
        Me.TXT_CODE_OWNER.MaxLength = 6
        Me.TXT_CODE_OWNER.Name = "TXT_CODE_OWNER"
        Me.TXT_CODE_OWNER.Size = New System.Drawing.Size(60, 25)
        Me.TXT_CODE_OWNER.TabIndex = 1
        Me.TXT_CODE_OWNER.Tag = "Clear,Numeric,Format=000000,Check,NotNull,NotZero,Plus"
        Me.TXT_CODE_OWNER.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PNL_INPUT_KEY
        '
        Me.PNL_INPUT_KEY.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PNL_INPUT_KEY.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.PNL_INPUT_KEY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PNL_INPUT_KEY.Controls.Add(Me.PNL_NUMBER_CONTRACT)
        Me.PNL_INPUT_KEY.Location = New System.Drawing.Point(10, 20)
        Me.PNL_INPUT_KEY.Name = "PNL_INPUT_KEY"
        Me.PNL_INPUT_KEY.Size = New System.Drawing.Size(740, 40)
        Me.PNL_INPUT_KEY.TabIndex = 0
        '
        'PNL_NUMBER_CONTRACT
        '
        Me.PNL_NUMBER_CONTRACT.Controls.Add(Me.BTN_NUMBER_CONTRACT_SEARCH)
        Me.PNL_NUMBER_CONTRACT.Controls.Add(Me.LBL_NUMBER_CONTRACT_GUIDE)
        Me.PNL_NUMBER_CONTRACT.Controls.Add(Me.TXT_NUMBER_CONTRACT)
        Me.PNL_NUMBER_CONTRACT.Location = New System.Drawing.Point(5, 5)
        Me.PNL_NUMBER_CONTRACT.Name = "PNL_NUMBER_CONTRACT"
        Me.PNL_NUMBER_CONTRACT.Size = New System.Drawing.Size(240, 30)
        Me.PNL_NUMBER_CONTRACT.TabIndex = 0
        '
        'BTN_NUMBER_CONTRACT_SEARCH
        '
        Me.BTN_NUMBER_CONTRACT_SEARCH.BackgroundImage = Global.MNT_E_CONTRACT_SPOT.My.Resources.Resources.Search_16x
        Me.BTN_NUMBER_CONTRACT_SEARCH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BTN_NUMBER_CONTRACT_SEARCH.Location = New System.Drawing.Point(205, 1)
        Me.BTN_NUMBER_CONTRACT_SEARCH.Margin = New System.Windows.Forms.Padding(0)
        Me.BTN_NUMBER_CONTRACT_SEARCH.Name = "BTN_NUMBER_CONTRACT_SEARCH"
        Me.BTN_NUMBER_CONTRACT_SEARCH.Size = New System.Drawing.Size(25, 25)
        Me.BTN_NUMBER_CONTRACT_SEARCH.TabIndex = 4
        Me.BTN_NUMBER_CONTRACT_SEARCH.TabStop = False
        Me.BTN_NUMBER_CONTRACT_SEARCH.UseVisualStyleBackColor = True
        '
        'LBL_NUMBER_CONTRACT_GUIDE
        '
        Me.LBL_NUMBER_CONTRACT_GUIDE.AutoEllipsis = True
        Me.LBL_NUMBER_CONTRACT_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_NUMBER_CONTRACT_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_NUMBER_CONTRACT_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_NUMBER_CONTRACT_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_NUMBER_CONTRACT_GUIDE.Name = "LBL_NUMBER_CONTRACT_GUIDE"
        Me.LBL_NUMBER_CONTRACT_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_NUMBER_CONTRACT_GUIDE.TabIndex = 3
        Me.LBL_NUMBER_CONTRACT_GUIDE.Text = "契約番号"
        Me.LBL_NUMBER_CONTRACT_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXT_NUMBER_CONTRACT
        '
        Me.TXT_NUMBER_CONTRACT.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TXT_NUMBER_CONTRACT.Location = New System.Drawing.Point(80, 1)
        Me.TXT_NUMBER_CONTRACT.MaxLength = 6
        Me.TXT_NUMBER_CONTRACT.Name = "TXT_NUMBER_CONTRACT"
        Me.TXT_NUMBER_CONTRACT.Size = New System.Drawing.Size(125, 25)
        Me.TXT_NUMBER_CONTRACT.TabIndex = 1
        Me.TXT_NUMBER_CONTRACT.Tag = "Clear,Numeric,Format=000000,Check,NotZero,Plus"
        Me.TXT_NUMBER_CONTRACT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'FRM_MAIN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GRP_BODY)
        Me.Controls.Add(Me.GRP_FOOT)
        Me.Controls.Add(Me.GRP_HEAD)
        Me.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MinimumSize = New System.Drawing.Size(800, 600)
        Me.Name = "FRM_MAIN"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "***"
        Me.GRP_HEAD.ResumeLayout(False)
        Me.PNL_INFO_GUIDE.ResumeLayout(False)
        Me.PNL_NAME_USER_HEAD.ResumeLayout(False)
        Me.PNL_DATE_ACTIVE_HEAD.ResumeLayout(False)
        Me.GRP_FOOT.ResumeLayout(False)
        Me.pnlFUNCTION_GROUP.ResumeLayout(False)
        Me.pnlFUNCTION_GROUP.PerformLayout()
        Me.GRP_BODY.ResumeLayout(False)
        Me.PNL_INPUT_DATA.ResumeLayout(False)
        Me.PNL_CODE_WORK.ResumeLayout(False)
        Me.PNL_KIND_WORK.ResumeLayout(False)
        Me.PNL_CODE_HANDLE.ResumeLayout(False)
        Me.PNL_DEPOSIT_DONE.ResumeLayout(False)
        Me.PNL_INVOICE_DONE.ResumeLayout(False)
        Me.PNL_DATE_INVOICE_BASE.ResumeLayout(False)
        Me.PNL_NUMBER_ORDER.ResumeLayout(False)
        Me.PNL_NUMBER_ORDER.PerformLayout()
        Me.PNL_NAME_CONTRACT.ResumeLayout(False)
        Me.PNL_NAME_CONTRACT.PerformLayout()
        Me.PNL_DATE_WORK.ResumeLayout(False)
        Me.PNL_EXT_SPOT.ResumeLayout(False)
        Me.PNL_NAME_ADDRESS_02.ResumeLayout(False)
        Me.PNL_NAME_ADDRESS_02.PerformLayout()
        Me.PNL_NAME_ADDRESS_01.ResumeLayout(False)
        Me.PNL_NAME_ADDRESS_01.PerformLayout()
        Me.PNL_CODE_POST.ResumeLayout(False)
        Me.PNL_CODE_POST.PerformLayout()
        Me.PNL_NAME_OWNER.ResumeLayout(False)
        Me.PNL_NAME_OWNER.PerformLayout()
        Me.PNL_NAME_MEMO.ResumeLayout(False)
        Me.PNL_NAME_MEMO.PerformLayout()
        Me.PNL_KINGAKU_CONTRACT.ResumeLayout(False)
        Me.PNL_KINGAKU_CONTRACT.PerformLayout()
        Me.PNL_DATE_CONTRACT.ResumeLayout(False)
        Me.PNL_CODE_SHINTO_PARENT.ResumeLayout(False)
        Me.PNL_CODE_SHINTO_PARENT.PerformLayout()
        Me.PNL_INPUT_KEY.ResumeLayout(False)
        Me.PNL_NUMBER_CONTRACT.ResumeLayout(False)
        Me.PNL_NUMBER_CONTRACT.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GRP_HEAD As GroupBox
    Friend WithEvents PNL_INFO_GUIDE As Panel
    Friend WithEvents PNL_NAME_USER_HEAD As Panel
    Friend WithEvents LBL_NAME_USER_HEAD As Label
    Friend WithEvents LBL_NAME_USER_HEAD_GUIDE As Label
    Friend WithEvents PNL_DATE_ACTIVE_HEAD As Panel
    Friend WithEvents LBL_DATE_ACTIVE_HEAD As Label
    Friend WithEvents LBL_DATE_ACTIVE_HEAD_GUIDE As Label
    Friend WithEvents GRP_FOOT As GroupBox
    Friend WithEvents pnlFUNCTION_GROUP As Panel
    Friend WithEvents BTN_CLEAR As Button
    Friend WithEvents BTN_DELETE As Button
    Friend WithEvents BTN_ENTER As Button
    Friend WithEvents BTN_END As Button
    Friend WithEvents GRP_BODY As GroupBox
    Friend WithEvents PNL_INPUT_DATA As Panel
    Friend WithEvents PNL_INPUT_KEY As Panel
    Friend WithEvents PNL_NUMBER_CONTRACT As Panel
    Friend WithEvents LBL_NUMBER_CONTRACT_GUIDE As Label
    Friend WithEvents TXT_NUMBER_CONTRACT As TextBox
    Friend WithEvents PNL_CODE_SHINTO_PARENT As Panel
    Friend WithEvents LBL_CODE_OWNER_GUIDE As Label
    Friend WithEvents LBL_CODE_OWNER_NAME As Label
    Friend WithEvents BTN_CODE_OWNER_SEARCH As Button
    Friend WithEvents TXT_CODE_OWNER As TextBox
    Friend WithEvents PNL_DATE_CONTRACT As Panel
    Friend WithEvents DTP_DATE_CONTRACT As DateTimePicker
    Friend WithEvents LBL_DATE_CONTRACT_GUIDE As Label
    Friend WithEvents PNL_KINGAKU_CONTRACT As Panel
    Friend WithEvents LBL_KINGAKU_CONTRACT_GUIDE As Label
    Friend WithEvents TXT_KINGAKU_CONTRACT As TextBox
    Friend WithEvents PNL_NAME_MEMO As Panel
    Friend WithEvents TXT_NAME_MEMO As TextBox
    Friend WithEvents LBL_NAME_MEMO_GUIDE As Label
    Friend WithEvents PNL_EXT_SPOT As Panel
    Friend WithEvents PNL_CODE_POST As Panel
    Friend WithEvents LBL_CODE_POST_GUIDE As Label
    Friend WithEvents TXT_CODE_POST As TextBox
    Friend WithEvents PNL_NAME_OWNER As Panel
    Friend WithEvents TXT_NAME_OWNER As TextBox
    Friend WithEvents LBL_NAME_OWNER_GUIDE As Label
    Friend WithEvents PNL_NAME_ADDRESS_02 As Panel
    Friend WithEvents TXT_NAME_ADDRESS_02 As TextBox
    Friend WithEvents LBL_NAME_ADDRESS_02 As Label
    Friend WithEvents PNL_NAME_ADDRESS_01 As Panel
    Friend WithEvents TXT_NAME_ADDRESS_01 As TextBox
    Friend WithEvents LBL_NAME_ADDRESS_01 As Label
    Friend WithEvents PNL_DATE_WORK As Panel
    Friend WithEvents DTP_DATE_WORK_FROM As DateTimePicker
    Friend WithEvents LBL_DATE_WORK_GUIDE As Label
    Friend WithEvents LBL_DATE_WORK_FROM_TO_GUIDE As Label
    Friend WithEvents DTP_DATE_WORK_TO As DateTimePicker
    Friend WithEvents PNL_NAME_CONTRACT As Panel
    Friend WithEvents TXT_NAME_CONTRACT As TextBox
    Friend WithEvents LBL_NAME_CONTRACT_GUIDE As Label
    Friend WithEvents PNL_NUMBER_ORDER As Panel
    Friend WithEvents LBL_NUMBER_ORDER_GUIDE As Label
    Friend WithEvents TXT_NUMBER_ORDER As TextBox
    Friend WithEvents PNL_DATE_INVOICE_BASE As Panel
    Friend WithEvents DTP_DATE_INVOICE_BASE As DateTimePicker
    Friend WithEvents LBL_DATE_INVOICE_BASE_GUIDE As Label
    Friend WithEvents PNL_DEPOSIT_DONE As Panel
    Friend WithEvents LBL_DEPOSIT_DONE As Label
    Friend WithEvents LBL_DEPOSIT_DONE_GUIDE As Label
    Friend WithEvents PNL_INVOICE_DONE As Panel
    Friend WithEvents LBL_INVOICE_DONE As Label
    Friend WithEvents LBL_INVOICE_DONE_GUIDE As Label
    Friend WithEvents BTN_NUMBER_CONTRACT_SEARCH As Button
    Friend WithEvents PNL_CODE_HANDLE As Panel
    Friend WithEvents CMB_CODE_SECTION As ComboBox
    Friend WithEvents LBL_CODE_SECTION_GUIDE As Label
    Friend WithEvents PNL_KIND_WORK As Panel
    Friend WithEvents CMB_KIND_WORK As ComboBox
    Friend WithEvents LBL_KIND_WORK_GUIDE As Label
    Friend WithEvents PNL_CODE_WORK As Panel
    Friend WithEvents CMB_CODE_WORK As ComboBox
    Friend WithEvents LBL_CODE_WORK_GUIDE As Label
End Class
