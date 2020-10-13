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
        Me.GRP_BODY = New System.Windows.Forms.GroupBox()
        Me.PNL_INPUT_KEY = New System.Windows.Forms.Panel()
        Me.PNL_CODE_MAINTENANCE = New System.Windows.Forms.Panel()
        Me.LBL_CODE_MAINTENANCE_FROM_TO_GUIDE = New System.Windows.Forms.Label()
        Me.TXT_CODE_MAINTENANCE_TO = New System.Windows.Forms.TextBox()
        Me.LBL_CODE_MAINTENANCE_TO_NAME = New System.Windows.Forms.Label()
        Me.LBL_CODE_MAINTENANCE_GUIDE = New System.Windows.Forms.Label()
        Me.LBL_CODE_MAINTENANCE_FROM_NAME = New System.Windows.Forms.Label()
        Me.TXT_CODE_MAINTENANCE_FROM = New System.Windows.Forms.TextBox()
        Me.PNL_FLAG_CONTRACT = New System.Windows.Forms.Panel()
        Me.CMB_FLAG_CONTRACT = New System.Windows.Forms.ComboBox()
        Me.LBL_FLAG_CONTRACT_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_KIND_TARGET = New System.Windows.Forms.Panel()
        Me.CMB_KIND_TARGET = New System.Windows.Forms.ComboBox()
        Me.LBL_KIND_TARGET_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_DATE_CALC = New System.Windows.Forms.Panel()
        Me.DTP_DATE_CALC_TO = New System.Windows.Forms.DateTimePicker()
        Me.LBL_DATE_CALC_FROM_TO_GUIDE = New System.Windows.Forms.Label()
        Me.DTP_DATE_CALC_FROM = New System.Windows.Forms.DateTimePicker()
        Me.LBL_DATE_CALC_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_CODE_SECTION = New System.Windows.Forms.Panel()
        Me.CMB_CODE_SECTION = New System.Windows.Forms.ComboBox()
        Me.LBL_CODE_SECTION_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_CODE_OWNER = New System.Windows.Forms.Panel()
        Me.LBL_CODE_OWNER_FROM_TO_GUIDE = New System.Windows.Forms.Label()
        Me.BTN_CODE_OWNER_TO_SEARCH = New System.Windows.Forms.Button()
        Me.TXT_CODE_OWNER_TO = New System.Windows.Forms.TextBox()
        Me.LBL_CODE_OWNER_TO_NAME = New System.Windows.Forms.Label()
        Me.LBL_CODE_OWNER_GUIDE = New System.Windows.Forms.Label()
        Me.LBL_CODE_OWNER_FROM_NAME = New System.Windows.Forms.Label()
        Me.BTN_CODE_OWNER_FROM_SEARCH = New System.Windows.Forms.Button()
        Me.TXT_CODE_OWNER_FROM = New System.Windows.Forms.TextBox()
        Me.PNL_DATE__CONTRACT = New System.Windows.Forms.Panel()
        Me.LBL_DATE_DEPOSIT_FROM_TO_GUIDE = New System.Windows.Forms.Label()
        Me.DTP_DATE_CONTRACT_TO = New System.Windows.Forms.DateTimePicker()
        Me.DTP_DATE_CONTRACT_FROM = New System.Windows.Forms.DateTimePicker()
        Me.LBL_DATE_CONTRACT_GUIDE = New System.Windows.Forms.Label()
        Me.GRP_FOOT = New System.Windows.Forms.GroupBox()
        Me.pnlFUNCTION_GROUP = New System.Windows.Forms.Panel()
        Me.BTN_PUT_FILE = New System.Windows.Forms.Button()
        Me.BTN_PRINT = New System.Windows.Forms.Button()
        Me.BTN_PREVIEW = New System.Windows.Forms.Button()
        Me.BTN_CLEAR = New System.Windows.Forms.Button()
        Me.BTN_END = New System.Windows.Forms.Button()
        Me.GRP_HEAD.SuspendLayout()
        Me.PNL_INFO_GUIDE.SuspendLayout()
        Me.PNL_NAME_USER_HEAD.SuspendLayout()
        Me.PNL_DATE_ACTIVE_HEAD.SuspendLayout()
        Me.GRP_BODY.SuspendLayout()
        Me.PNL_INPUT_KEY.SuspendLayout()
        Me.PNL_CODE_MAINTENANCE.SuspendLayout()
        Me.PNL_FLAG_CONTRACT.SuspendLayout()
        Me.PNL_KIND_TARGET.SuspendLayout()
        Me.PNL_DATE_CALC.SuspendLayout()
        Me.PNL_CODE_SECTION.SuspendLayout()
        Me.PNL_CODE_OWNER.SuspendLayout()
        Me.PNL_DATE__CONTRACT.SuspendLayout()
        Me.GRP_FOOT.SuspendLayout()
        Me.pnlFUNCTION_GROUP.SuspendLayout()
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
        Me.GRP_HEAD.TabIndex = 1
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
        Me.PNL_INFO_GUIDE.TabIndex = 6
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
        'GRP_BODY
        '
        Me.GRP_BODY.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GRP_BODY.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.GRP_BODY.Controls.Add(Me.PNL_INPUT_KEY)
        Me.GRP_BODY.Location = New System.Drawing.Point(10, 60)
        Me.GRP_BODY.Name = "GRP_BODY"
        Me.GRP_BODY.Size = New System.Drawing.Size(760, 430)
        Me.GRP_BODY.TabIndex = 2
        Me.GRP_BODY.TabStop = False
        '
        'PNL_INPUT_KEY
        '
        Me.PNL_INPUT_KEY.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PNL_INPUT_KEY.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.PNL_INPUT_KEY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PNL_INPUT_KEY.Controls.Add(Me.PNL_CODE_MAINTENANCE)
        Me.PNL_INPUT_KEY.Controls.Add(Me.PNL_FLAG_CONTRACT)
        Me.PNL_INPUT_KEY.Controls.Add(Me.PNL_KIND_TARGET)
        Me.PNL_INPUT_KEY.Controls.Add(Me.PNL_DATE_CALC)
        Me.PNL_INPUT_KEY.Controls.Add(Me.PNL_CODE_SECTION)
        Me.PNL_INPUT_KEY.Controls.Add(Me.PNL_CODE_OWNER)
        Me.PNL_INPUT_KEY.Controls.Add(Me.PNL_DATE__CONTRACT)
        Me.PNL_INPUT_KEY.Location = New System.Drawing.Point(10, 20)
        Me.PNL_INPUT_KEY.Name = "PNL_INPUT_KEY"
        Me.PNL_INPUT_KEY.Size = New System.Drawing.Size(740, 400)
        Me.PNL_INPUT_KEY.TabIndex = 0
        '
        'PNL_CODE_MAINTENANCE
        '
        Me.PNL_CODE_MAINTENANCE.Controls.Add(Me.LBL_CODE_MAINTENANCE_FROM_TO_GUIDE)
        Me.PNL_CODE_MAINTENANCE.Controls.Add(Me.TXT_CODE_MAINTENANCE_TO)
        Me.PNL_CODE_MAINTENANCE.Controls.Add(Me.LBL_CODE_MAINTENANCE_TO_NAME)
        Me.PNL_CODE_MAINTENANCE.Controls.Add(Me.LBL_CODE_MAINTENANCE_GUIDE)
        Me.PNL_CODE_MAINTENANCE.Controls.Add(Me.LBL_CODE_MAINTENANCE_FROM_NAME)
        Me.PNL_CODE_MAINTENANCE.Controls.Add(Me.TXT_CODE_MAINTENANCE_FROM)
        Me.PNL_CODE_MAINTENANCE.Location = New System.Drawing.Point(5, 145)
        Me.PNL_CODE_MAINTENANCE.Name = "PNL_CODE_MAINTENANCE"
        Me.PNL_CODE_MAINTENANCE.Size = New System.Drawing.Size(730, 30)
        Me.PNL_CODE_MAINTENANCE.TabIndex = 4
        '
        'LBL_CODE_MAINTENANCE_FROM_TO_GUIDE
        '
        Me.LBL_CODE_MAINTENANCE_FROM_TO_GUIDE.AutoEllipsis = True
        Me.LBL_CODE_MAINTENANCE_FROM_TO_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_CODE_MAINTENANCE_FROM_TO_GUIDE.Location = New System.Drawing.Point(390, 1)
        Me.LBL_CODE_MAINTENANCE_FROM_TO_GUIDE.Name = "LBL_CODE_MAINTENANCE_FROM_TO_GUIDE"
        Me.LBL_CODE_MAINTENANCE_FROM_TO_GUIDE.Size = New System.Drawing.Size(20, 25)
        Me.LBL_CODE_MAINTENANCE_FROM_TO_GUIDE.TabIndex = 4
        Me.LBL_CODE_MAINTENANCE_FROM_TO_GUIDE.Text = "～"
        Me.LBL_CODE_MAINTENANCE_FROM_TO_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TXT_CODE_MAINTENANCE_TO
        '
        Me.TXT_CODE_MAINTENANCE_TO.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TXT_CODE_MAINTENANCE_TO.Location = New System.Drawing.Point(415, 1)
        Me.TXT_CODE_MAINTENANCE_TO.MaxLength = 6
        Me.TXT_CODE_MAINTENANCE_TO.Name = "TXT_CODE_MAINTENANCE_TO"
        Me.TXT_CODE_MAINTENANCE_TO.Size = New System.Drawing.Size(60, 25)
        Me.TXT_CODE_MAINTENANCE_TO.TabIndex = 5
        Me.TXT_CODE_MAINTENANCE_TO.Tag = "Clear,Numeric,Format=0000,Check,NotZero,Plus"
        Me.TXT_CODE_MAINTENANCE_TO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LBL_CODE_MAINTENANCE_TO_NAME
        '
        Me.LBL_CODE_MAINTENANCE_TO_NAME.AutoEllipsis = True
        Me.LBL_CODE_MAINTENANCE_TO_NAME.BackColor = System.Drawing.Color.White
        Me.LBL_CODE_MAINTENANCE_TO_NAME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_CODE_MAINTENANCE_TO_NAME.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBL_CODE_MAINTENANCE_TO_NAME.Location = New System.Drawing.Point(475, 1)
        Me.LBL_CODE_MAINTENANCE_TO_NAME.Name = "LBL_CODE_MAINTENANCE_TO_NAME"
        Me.LBL_CODE_MAINTENANCE_TO_NAME.Size = New System.Drawing.Size(245, 25)
        Me.LBL_CODE_MAINTENANCE_TO_NAME.TabIndex = 7
        Me.LBL_CODE_MAINTENANCE_TO_NAME.Tag = "Clear"
        Me.LBL_CODE_MAINTENANCE_TO_NAME.Text = "＊＊＊"
        Me.LBL_CODE_MAINTENANCE_TO_NAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LBL_CODE_MAINTENANCE_GUIDE
        '
        Me.LBL_CODE_MAINTENANCE_GUIDE.AutoEllipsis = True
        Me.LBL_CODE_MAINTENANCE_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_CODE_MAINTENANCE_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_CODE_MAINTENANCE_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_CODE_MAINTENANCE_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_CODE_MAINTENANCE_GUIDE.Name = "LBL_CODE_MAINTENANCE_GUIDE"
        Me.LBL_CODE_MAINTENANCE_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_CODE_MAINTENANCE_GUIDE.TabIndex = 0
        Me.LBL_CODE_MAINTENANCE_GUIDE.Text = "作業コード"
        Me.LBL_CODE_MAINTENANCE_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LBL_CODE_MAINTENANCE_FROM_NAME
        '
        Me.LBL_CODE_MAINTENANCE_FROM_NAME.AutoEllipsis = True
        Me.LBL_CODE_MAINTENANCE_FROM_NAME.BackColor = System.Drawing.Color.White
        Me.LBL_CODE_MAINTENANCE_FROM_NAME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_CODE_MAINTENANCE_FROM_NAME.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBL_CODE_MAINTENANCE_FROM_NAME.Location = New System.Drawing.Point(140, 1)
        Me.LBL_CODE_MAINTENANCE_FROM_NAME.Name = "LBL_CODE_MAINTENANCE_FROM_NAME"
        Me.LBL_CODE_MAINTENANCE_FROM_NAME.Size = New System.Drawing.Size(245, 25)
        Me.LBL_CODE_MAINTENANCE_FROM_NAME.TabIndex = 3
        Me.LBL_CODE_MAINTENANCE_FROM_NAME.Tag = "Clear"
        Me.LBL_CODE_MAINTENANCE_FROM_NAME.Text = "＊＊＊"
        Me.LBL_CODE_MAINTENANCE_FROM_NAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TXT_CODE_MAINTENANCE_FROM
        '
        Me.TXT_CODE_MAINTENANCE_FROM.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TXT_CODE_MAINTENANCE_FROM.Location = New System.Drawing.Point(80, 1)
        Me.TXT_CODE_MAINTENANCE_FROM.MaxLength = 6
        Me.TXT_CODE_MAINTENANCE_FROM.Name = "TXT_CODE_MAINTENANCE_FROM"
        Me.TXT_CODE_MAINTENANCE_FROM.Size = New System.Drawing.Size(60, 25)
        Me.TXT_CODE_MAINTENANCE_FROM.TabIndex = 1
        Me.TXT_CODE_MAINTENANCE_FROM.Tag = "Clear,Numeric,Format=0000,Check,NotZero,Plus"
        Me.TXT_CODE_MAINTENANCE_FROM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PNL_FLAG_CONTRACT
        '
        Me.PNL_FLAG_CONTRACT.Controls.Add(Me.CMB_FLAG_CONTRACT)
        Me.PNL_FLAG_CONTRACT.Controls.Add(Me.LBL_FLAG_CONTRACT_GUIDE)
        Me.PNL_FLAG_CONTRACT.Location = New System.Drawing.Point(5, 75)
        Me.PNL_FLAG_CONTRACT.Name = "PNL_FLAG_CONTRACT"
        Me.PNL_FLAG_CONTRACT.Size = New System.Drawing.Size(240, 30)
        Me.PNL_FLAG_CONTRACT.TabIndex = 2
        '
        'CMB_FLAG_CONTRACT
        '
        Me.CMB_FLAG_CONTRACT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_FLAG_CONTRACT.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CMB_FLAG_CONTRACT.Location = New System.Drawing.Point(80, 1)
        Me.CMB_FLAG_CONTRACT.Name = "CMB_FLAG_CONTRACT"
        Me.CMB_FLAG_CONTRACT.Size = New System.Drawing.Size(150, 26)
        Me.CMB_FLAG_CONTRACT.TabIndex = 1
        Me.CMB_FLAG_CONTRACT.Tag = "Clear"
        '
        'LBL_FLAG_CONTRACT_GUIDE
        '
        Me.LBL_FLAG_CONTRACT_GUIDE.AutoEllipsis = True
        Me.LBL_FLAG_CONTRACT_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_FLAG_CONTRACT_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_FLAG_CONTRACT_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_FLAG_CONTRACT_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_FLAG_CONTRACT_GUIDE.Name = "LBL_FLAG_CONTRACT_GUIDE"
        Me.LBL_FLAG_CONTRACT_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_FLAG_CONTRACT_GUIDE.TabIndex = 0
        Me.LBL_FLAG_CONTRACT_GUIDE.Text = "契約形態"
        Me.LBL_FLAG_CONTRACT_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PNL_KIND_TARGET
        '
        Me.PNL_KIND_TARGET.Controls.Add(Me.CMB_KIND_TARGET)
        Me.PNL_KIND_TARGET.Controls.Add(Me.LBL_KIND_TARGET_GUIDE)
        Me.PNL_KIND_TARGET.Location = New System.Drawing.Point(5, 215)
        Me.PNL_KIND_TARGET.Name = "PNL_KIND_TARGET"
        Me.PNL_KIND_TARGET.Size = New System.Drawing.Size(240, 30)
        Me.PNL_KIND_TARGET.TabIndex = 6
        '
        'CMB_KIND_TARGET
        '
        Me.CMB_KIND_TARGET.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_KIND_TARGET.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CMB_KIND_TARGET.Location = New System.Drawing.Point(80, 1)
        Me.CMB_KIND_TARGET.Name = "CMB_KIND_TARGET"
        Me.CMB_KIND_TARGET.Size = New System.Drawing.Size(150, 26)
        Me.CMB_KIND_TARGET.TabIndex = 1
        Me.CMB_KIND_TARGET.Tag = "Clear"
        '
        'LBL_KIND_TARGET_GUIDE
        '
        Me.LBL_KIND_TARGET_GUIDE.AutoEllipsis = True
        Me.LBL_KIND_TARGET_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_KIND_TARGET_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_KIND_TARGET_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_KIND_TARGET_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_KIND_TARGET_GUIDE.Name = "LBL_KIND_TARGET_GUIDE"
        Me.LBL_KIND_TARGET_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_KIND_TARGET_GUIDE.TabIndex = 0
        Me.LBL_KIND_TARGET_GUIDE.Text = "対象"
        Me.LBL_KIND_TARGET_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PNL_DATE_CALC
        '
        Me.PNL_DATE_CALC.Controls.Add(Me.DTP_DATE_CALC_TO)
        Me.PNL_DATE_CALC.Controls.Add(Me.LBL_DATE_CALC_FROM_TO_GUIDE)
        Me.PNL_DATE_CALC.Controls.Add(Me.DTP_DATE_CALC_FROM)
        Me.PNL_DATE_CALC.Controls.Add(Me.LBL_DATE_CALC_GUIDE)
        Me.PNL_DATE_CALC.Location = New System.Drawing.Point(5, 180)
        Me.PNL_DATE_CALC.Name = "PNL_DATE_CALC"
        Me.PNL_DATE_CALC.Size = New System.Drawing.Size(420, 30)
        Me.PNL_DATE_CALC.TabIndex = 5
        '
        'DTP_DATE_CALC_TO
        '
        Me.DTP_DATE_CALC_TO.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.DTP_DATE_CALC_TO.Location = New System.Drawing.Point(260, 1)
        Me.DTP_DATE_CALC_TO.Name = "DTP_DATE_CALC_TO"
        Me.DTP_DATE_CALC_TO.Size = New System.Drawing.Size(150, 25)
        Me.DTP_DATE_CALC_TO.TabIndex = 11
        Me.DTP_DATE_CALC_TO.Tag = "Clear"
        '
        'LBL_DATE_CALC_FROM_TO_GUIDE
        '
        Me.LBL_DATE_CALC_FROM_TO_GUIDE.AutoEllipsis = True
        Me.LBL_DATE_CALC_FROM_TO_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_DATE_CALC_FROM_TO_GUIDE.Location = New System.Drawing.Point(235, 1)
        Me.LBL_DATE_CALC_FROM_TO_GUIDE.Name = "LBL_DATE_CALC_FROM_TO_GUIDE"
        Me.LBL_DATE_CALC_FROM_TO_GUIDE.Size = New System.Drawing.Size(20, 25)
        Me.LBL_DATE_CALC_FROM_TO_GUIDE.TabIndex = 10
        Me.LBL_DATE_CALC_FROM_TO_GUIDE.Text = "～"
        Me.LBL_DATE_CALC_FROM_TO_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DTP_DATE_CALC_FROM
        '
        Me.DTP_DATE_CALC_FROM.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.DTP_DATE_CALC_FROM.Location = New System.Drawing.Point(80, 1)
        Me.DTP_DATE_CALC_FROM.Name = "DTP_DATE_CALC_FROM"
        Me.DTP_DATE_CALC_FROM.Size = New System.Drawing.Size(150, 25)
        Me.DTP_DATE_CALC_FROM.TabIndex = 1
        Me.DTP_DATE_CALC_FROM.Tag = "Clear"
        '
        'LBL_DATE_CALC_GUIDE
        '
        Me.LBL_DATE_CALC_GUIDE.AutoEllipsis = True
        Me.LBL_DATE_CALC_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_DATE_CALC_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_DATE_CALC_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_DATE_CALC_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_DATE_CALC_GUIDE.Name = "LBL_DATE_CALC_GUIDE"
        Me.LBL_DATE_CALC_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_DATE_CALC_GUIDE.TabIndex = 0
        Me.LBL_DATE_CALC_GUIDE.Text = "計算期間"
        Me.LBL_DATE_CALC_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PNL_CODE_SECTION
        '
        Me.PNL_CODE_SECTION.Controls.Add(Me.CMB_CODE_SECTION)
        Me.PNL_CODE_SECTION.Controls.Add(Me.LBL_CODE_SECTION_GUIDE)
        Me.PNL_CODE_SECTION.Location = New System.Drawing.Point(5, 40)
        Me.PNL_CODE_SECTION.Name = "PNL_CODE_SECTION"
        Me.PNL_CODE_SECTION.Size = New System.Drawing.Size(240, 30)
        Me.PNL_CODE_SECTION.TabIndex = 1
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
        Me.LBL_CODE_SECTION_GUIDE.Text = "部署"
        Me.LBL_CODE_SECTION_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PNL_CODE_OWNER
        '
        Me.PNL_CODE_OWNER.Controls.Add(Me.LBL_CODE_OWNER_FROM_TO_GUIDE)
        Me.PNL_CODE_OWNER.Controls.Add(Me.BTN_CODE_OWNER_TO_SEARCH)
        Me.PNL_CODE_OWNER.Controls.Add(Me.TXT_CODE_OWNER_TO)
        Me.PNL_CODE_OWNER.Controls.Add(Me.LBL_CODE_OWNER_TO_NAME)
        Me.PNL_CODE_OWNER.Controls.Add(Me.LBL_CODE_OWNER_GUIDE)
        Me.PNL_CODE_OWNER.Controls.Add(Me.LBL_CODE_OWNER_FROM_NAME)
        Me.PNL_CODE_OWNER.Controls.Add(Me.BTN_CODE_OWNER_FROM_SEARCH)
        Me.PNL_CODE_OWNER.Controls.Add(Me.TXT_CODE_OWNER_FROM)
        Me.PNL_CODE_OWNER.Location = New System.Drawing.Point(5, 110)
        Me.PNL_CODE_OWNER.Name = "PNL_CODE_OWNER"
        Me.PNL_CODE_OWNER.Size = New System.Drawing.Size(730, 30)
        Me.PNL_CODE_OWNER.TabIndex = 3
        '
        'LBL_CODE_OWNER_FROM_TO_GUIDE
        '
        Me.LBL_CODE_OWNER_FROM_TO_GUIDE.AutoEllipsis = True
        Me.LBL_CODE_OWNER_FROM_TO_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_CODE_OWNER_FROM_TO_GUIDE.Location = New System.Drawing.Point(400, 1)
        Me.LBL_CODE_OWNER_FROM_TO_GUIDE.Name = "LBL_CODE_OWNER_FROM_TO_GUIDE"
        Me.LBL_CODE_OWNER_FROM_TO_GUIDE.Size = New System.Drawing.Size(20, 25)
        Me.LBL_CODE_OWNER_FROM_TO_GUIDE.TabIndex = 4
        Me.LBL_CODE_OWNER_FROM_TO_GUIDE.Text = "～"
        Me.LBL_CODE_OWNER_FROM_TO_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BTN_CODE_OWNER_TO_SEARCH
        '
        Me.BTN_CODE_OWNER_TO_SEARCH.BackgroundImage = Global.MNT_P_LEDGER_RECEIVABLE.My.Resources.Resources.Search_16x
        Me.BTN_CODE_OWNER_TO_SEARCH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BTN_CODE_OWNER_TO_SEARCH.Location = New System.Drawing.Point(485, 1)
        Me.BTN_CODE_OWNER_TO_SEARCH.Margin = New System.Windows.Forms.Padding(0)
        Me.BTN_CODE_OWNER_TO_SEARCH.Name = "BTN_CODE_OWNER_TO_SEARCH"
        Me.BTN_CODE_OWNER_TO_SEARCH.Size = New System.Drawing.Size(25, 25)
        Me.BTN_CODE_OWNER_TO_SEARCH.TabIndex = 6
        Me.BTN_CODE_OWNER_TO_SEARCH.TabStop = False
        Me.BTN_CODE_OWNER_TO_SEARCH.UseVisualStyleBackColor = True
        '
        'TXT_CODE_OWNER_TO
        '
        Me.TXT_CODE_OWNER_TO.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TXT_CODE_OWNER_TO.Location = New System.Drawing.Point(425, 1)
        Me.TXT_CODE_OWNER_TO.MaxLength = 6
        Me.TXT_CODE_OWNER_TO.Name = "TXT_CODE_OWNER_TO"
        Me.TXT_CODE_OWNER_TO.Size = New System.Drawing.Size(60, 25)
        Me.TXT_CODE_OWNER_TO.TabIndex = 5
        Me.TXT_CODE_OWNER_TO.Tag = "Clear,Numeric,Format=000000,Check,NotZero,Plus"
        Me.TXT_CODE_OWNER_TO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LBL_CODE_OWNER_TO_NAME
        '
        Me.LBL_CODE_OWNER_TO_NAME.AutoEllipsis = True
        Me.LBL_CODE_OWNER_TO_NAME.BackColor = System.Drawing.Color.White
        Me.LBL_CODE_OWNER_TO_NAME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_CODE_OWNER_TO_NAME.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBL_CODE_OWNER_TO_NAME.Location = New System.Drawing.Point(510, 1)
        Me.LBL_CODE_OWNER_TO_NAME.Name = "LBL_CODE_OWNER_TO_NAME"
        Me.LBL_CODE_OWNER_TO_NAME.Size = New System.Drawing.Size(210, 25)
        Me.LBL_CODE_OWNER_TO_NAME.TabIndex = 7
        Me.LBL_CODE_OWNER_TO_NAME.Tag = "Clear"
        Me.LBL_CODE_OWNER_TO_NAME.Text = "＊＊＊"
        Me.LBL_CODE_OWNER_TO_NAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.LBL_CODE_OWNER_GUIDE.TabIndex = 0
        Me.LBL_CODE_OWNER_GUIDE.Text = "オーナーコード"
        Me.LBL_CODE_OWNER_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LBL_CODE_OWNER_FROM_NAME
        '
        Me.LBL_CODE_OWNER_FROM_NAME.AutoEllipsis = True
        Me.LBL_CODE_OWNER_FROM_NAME.BackColor = System.Drawing.Color.White
        Me.LBL_CODE_OWNER_FROM_NAME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_CODE_OWNER_FROM_NAME.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBL_CODE_OWNER_FROM_NAME.Location = New System.Drawing.Point(185, 1)
        Me.LBL_CODE_OWNER_FROM_NAME.Name = "LBL_CODE_OWNER_FROM_NAME"
        Me.LBL_CODE_OWNER_FROM_NAME.Size = New System.Drawing.Size(210, 25)
        Me.LBL_CODE_OWNER_FROM_NAME.TabIndex = 3
        Me.LBL_CODE_OWNER_FROM_NAME.Tag = "Clear"
        Me.LBL_CODE_OWNER_FROM_NAME.Text = "＊＊＊"
        Me.LBL_CODE_OWNER_FROM_NAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BTN_CODE_OWNER_FROM_SEARCH
        '
        Me.BTN_CODE_OWNER_FROM_SEARCH.BackgroundImage = Global.MNT_P_LEDGER_RECEIVABLE.My.Resources.Resources.Search_16x
        Me.BTN_CODE_OWNER_FROM_SEARCH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BTN_CODE_OWNER_FROM_SEARCH.Location = New System.Drawing.Point(160, 1)
        Me.BTN_CODE_OWNER_FROM_SEARCH.Margin = New System.Windows.Forms.Padding(0)
        Me.BTN_CODE_OWNER_FROM_SEARCH.Name = "BTN_CODE_OWNER_FROM_SEARCH"
        Me.BTN_CODE_OWNER_FROM_SEARCH.Size = New System.Drawing.Size(25, 25)
        Me.BTN_CODE_OWNER_FROM_SEARCH.TabIndex = 2
        Me.BTN_CODE_OWNER_FROM_SEARCH.TabStop = False
        Me.BTN_CODE_OWNER_FROM_SEARCH.UseVisualStyleBackColor = True
        '
        'TXT_CODE_OWNER_FROM
        '
        Me.TXT_CODE_OWNER_FROM.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TXT_CODE_OWNER_FROM.Location = New System.Drawing.Point(100, 1)
        Me.TXT_CODE_OWNER_FROM.MaxLength = 6
        Me.TXT_CODE_OWNER_FROM.Name = "TXT_CODE_OWNER_FROM"
        Me.TXT_CODE_OWNER_FROM.Size = New System.Drawing.Size(60, 25)
        Me.TXT_CODE_OWNER_FROM.TabIndex = 1
        Me.TXT_CODE_OWNER_FROM.Tag = "Clear,Numeric,Format=000000,Check,NotZero,Plus"
        Me.TXT_CODE_OWNER_FROM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PNL_DATE__CONTRACT
        '
        Me.PNL_DATE__CONTRACT.Controls.Add(Me.LBL_DATE_DEPOSIT_FROM_TO_GUIDE)
        Me.PNL_DATE__CONTRACT.Controls.Add(Me.DTP_DATE_CONTRACT_TO)
        Me.PNL_DATE__CONTRACT.Controls.Add(Me.DTP_DATE_CONTRACT_FROM)
        Me.PNL_DATE__CONTRACT.Controls.Add(Me.LBL_DATE_CONTRACT_GUIDE)
        Me.PNL_DATE__CONTRACT.Location = New System.Drawing.Point(5, 5)
        Me.PNL_DATE__CONTRACT.Name = "PNL_DATE__CONTRACT"
        Me.PNL_DATE__CONTRACT.Size = New System.Drawing.Size(420, 30)
        Me.PNL_DATE__CONTRACT.TabIndex = 0
        '
        'LBL_DATE_DEPOSIT_FROM_TO_GUIDE
        '
        Me.LBL_DATE_DEPOSIT_FROM_TO_GUIDE.AutoEllipsis = True
        Me.LBL_DATE_DEPOSIT_FROM_TO_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_DATE_DEPOSIT_FROM_TO_GUIDE.Location = New System.Drawing.Point(235, 1)
        Me.LBL_DATE_DEPOSIT_FROM_TO_GUIDE.Name = "LBL_DATE_DEPOSIT_FROM_TO_GUIDE"
        Me.LBL_DATE_DEPOSIT_FROM_TO_GUIDE.Size = New System.Drawing.Size(20, 25)
        Me.LBL_DATE_DEPOSIT_FROM_TO_GUIDE.TabIndex = 9
        Me.LBL_DATE_DEPOSIT_FROM_TO_GUIDE.Text = "～"
        Me.LBL_DATE_DEPOSIT_FROM_TO_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DTP_DATE_CONTRACT_TO
        '
        Me.DTP_DATE_CONTRACT_TO.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.DTP_DATE_CONTRACT_TO.Location = New System.Drawing.Point(260, 1)
        Me.DTP_DATE_CONTRACT_TO.Name = "DTP_DATE_CONTRACT_TO"
        Me.DTP_DATE_CONTRACT_TO.Size = New System.Drawing.Size(150, 25)
        Me.DTP_DATE_CONTRACT_TO.TabIndex = 2
        Me.DTP_DATE_CONTRACT_TO.Tag = "Clear"
        '
        'DTP_DATE_CONTRACT_FROM
        '
        Me.DTP_DATE_CONTRACT_FROM.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.DTP_DATE_CONTRACT_FROM.Location = New System.Drawing.Point(80, 1)
        Me.DTP_DATE_CONTRACT_FROM.Name = "DTP_DATE_CONTRACT_FROM"
        Me.DTP_DATE_CONTRACT_FROM.Size = New System.Drawing.Size(150, 25)
        Me.DTP_DATE_CONTRACT_FROM.TabIndex = 1
        Me.DTP_DATE_CONTRACT_FROM.Tag = "Clear"
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
        Me.LBL_DATE_CONTRACT_GUIDE.Text = "契約日"
        Me.LBL_DATE_CONTRACT_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.GRP_FOOT.TabIndex = 3
        Me.GRP_FOOT.TabStop = False
        '
        'pnlFUNCTION_GROUP
        '
        Me.pnlFUNCTION_GROUP.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnlFUNCTION_GROUP.AutoScroll = True
        Me.pnlFUNCTION_GROUP.Controls.Add(Me.BTN_PUT_FILE)
        Me.pnlFUNCTION_GROUP.Controls.Add(Me.BTN_PRINT)
        Me.pnlFUNCTION_GROUP.Controls.Add(Me.BTN_PREVIEW)
        Me.pnlFUNCTION_GROUP.Controls.Add(Me.BTN_CLEAR)
        Me.pnlFUNCTION_GROUP.Controls.Add(Me.BTN_END)
        Me.pnlFUNCTION_GROUP.Location = New System.Drawing.Point(180, 15)
        Me.pnlFUNCTION_GROUP.MinimumSize = New System.Drawing.Size(190, 40)
        Me.pnlFUNCTION_GROUP.Name = "pnlFUNCTION_GROUP"
        Me.pnlFUNCTION_GROUP.Size = New System.Drawing.Size(440, 40)
        Me.pnlFUNCTION_GROUP.TabIndex = 0
        '
        'BTN_PUT_FILE
        '
        Me.BTN_PUT_FILE.AutoSize = True
        Me.BTN_PUT_FILE.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_PUT_FILE.Location = New System.Drawing.Point(180, 5)
        Me.BTN_PUT_FILE.MinimumSize = New System.Drawing.Size(80, 30)
        Me.BTN_PUT_FILE.Name = "BTN_PUT_FILE"
        Me.BTN_PUT_FILE.Size = New System.Drawing.Size(80, 30)
        Me.BTN_PUT_FILE.TabIndex = 2
        Me.BTN_PUT_FILE.Text = "ファイル"
        Me.BTN_PUT_FILE.UseVisualStyleBackColor = False
        '
        'BTN_PRINT
        '
        Me.BTN_PRINT.AutoSize = True
        Me.BTN_PRINT.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_PRINT.Location = New System.Drawing.Point(95, 5)
        Me.BTN_PRINT.MinimumSize = New System.Drawing.Size(80, 30)
        Me.BTN_PRINT.Name = "BTN_PRINT"
        Me.BTN_PRINT.Size = New System.Drawing.Size(80, 30)
        Me.BTN_PRINT.TabIndex = 1
        Me.BTN_PRINT.Text = "印刷"
        Me.BTN_PRINT.UseVisualStyleBackColor = False
        '
        'BTN_PREVIEW
        '
        Me.BTN_PREVIEW.AutoSize = True
        Me.BTN_PREVIEW.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_PREVIEW.Location = New System.Drawing.Point(10, 5)
        Me.BTN_PREVIEW.MinimumSize = New System.Drawing.Size(80, 30)
        Me.BTN_PREVIEW.Name = "BTN_PREVIEW"
        Me.BTN_PREVIEW.Size = New System.Drawing.Size(80, 30)
        Me.BTN_PREVIEW.TabIndex = 0
        Me.BTN_PREVIEW.Text = "プレビュー"
        Me.BTN_PREVIEW.UseVisualStyleBackColor = False
        '
        'BTN_CLEAR
        '
        Me.BTN_CLEAR.AutoSize = True
        Me.BTN_CLEAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_CLEAR.Location = New System.Drawing.Point(265, 5)
        Me.BTN_CLEAR.MinimumSize = New System.Drawing.Size(80, 30)
        Me.BTN_CLEAR.Name = "BTN_CLEAR"
        Me.BTN_CLEAR.Size = New System.Drawing.Size(80, 30)
        Me.BTN_CLEAR.TabIndex = 3
        Me.BTN_CLEAR.Text = "クリア"
        Me.BTN_CLEAR.UseVisualStyleBackColor = False
        '
        'BTN_END
        '
        Me.BTN_END.AutoSize = True
        Me.BTN_END.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_END.Location = New System.Drawing.Point(350, 5)
        Me.BTN_END.MinimumSize = New System.Drawing.Size(80, 30)
        Me.BTN_END.Name = "BTN_END"
        Me.BTN_END.Size = New System.Drawing.Size(80, 30)
        Me.BTN_END.TabIndex = 4
        Me.BTN_END.Text = "終了"
        Me.BTN_END.UseVisualStyleBackColor = False
        '
        'FRM_MAIN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GRP_FOOT)
        Me.Controls.Add(Me.GRP_BODY)
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
        Me.GRP_BODY.ResumeLayout(False)
        Me.PNL_INPUT_KEY.ResumeLayout(False)
        Me.PNL_CODE_MAINTENANCE.ResumeLayout(False)
        Me.PNL_CODE_MAINTENANCE.PerformLayout()
        Me.PNL_FLAG_CONTRACT.ResumeLayout(False)
        Me.PNL_KIND_TARGET.ResumeLayout(False)
        Me.PNL_DATE_CALC.ResumeLayout(False)
        Me.PNL_CODE_SECTION.ResumeLayout(False)
        Me.PNL_CODE_OWNER.ResumeLayout(False)
        Me.PNL_CODE_OWNER.PerformLayout()
        Me.PNL_DATE__CONTRACT.ResumeLayout(False)
        Me.GRP_FOOT.ResumeLayout(False)
        Me.pnlFUNCTION_GROUP.ResumeLayout(False)
        Me.pnlFUNCTION_GROUP.PerformLayout()
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
    Friend WithEvents GRP_BODY As GroupBox
    Friend WithEvents PNL_INPUT_KEY As Panel
    Friend WithEvents PNL_CODE_OWNER As Panel
    Friend WithEvents LBL_CODE_OWNER_FROM_TO_GUIDE As Label
    Friend WithEvents BTN_CODE_OWNER_TO_SEARCH As Button
    Friend WithEvents TXT_CODE_OWNER_TO As TextBox
    Friend WithEvents LBL_CODE_OWNER_TO_NAME As Label
    Friend WithEvents LBL_CODE_OWNER_GUIDE As Label
    Friend WithEvents LBL_CODE_OWNER_FROM_NAME As Label
    Friend WithEvents BTN_CODE_OWNER_FROM_SEARCH As Button
    Friend WithEvents TXT_CODE_OWNER_FROM As TextBox
    Friend WithEvents PNL_DATE__CONTRACT As Panel
    Friend WithEvents LBL_DATE_DEPOSIT_FROM_TO_GUIDE As Label
    Friend WithEvents DTP_DATE_CONTRACT_TO As DateTimePicker
    Friend WithEvents DTP_DATE_CONTRACT_FROM As DateTimePicker
    Friend WithEvents LBL_DATE_CONTRACT_GUIDE As Label
    Friend WithEvents GRP_FOOT As GroupBox
    Friend WithEvents pnlFUNCTION_GROUP As Panel
    Friend WithEvents BTN_PRINT As Button
    Friend WithEvents BTN_PREVIEW As Button
    Friend WithEvents BTN_CLEAR As Button
    Friend WithEvents BTN_END As Button
    Friend WithEvents PNL_CODE_SECTION As Panel
    Friend WithEvents CMB_CODE_SECTION As ComboBox
    Friend WithEvents LBL_CODE_SECTION_GUIDE As Label
    Friend WithEvents PNL_KIND_TARGET As Panel
    Friend WithEvents CMB_KIND_TARGET As ComboBox
    Friend WithEvents LBL_KIND_TARGET_GUIDE As Label
    Friend WithEvents PNL_DATE_CALC As Panel
    Friend WithEvents DTP_DATE_CALC_FROM As DateTimePicker
    Friend WithEvents LBL_DATE_CALC_GUIDE As Label
    Friend WithEvents DTP_DATE_CALC_TO As DateTimePicker
    Friend WithEvents LBL_DATE_CALC_FROM_TO_GUIDE As Label
    Friend WithEvents BTN_PUT_FILE As Button
    Friend WithEvents PNL_CODE_MAINTENANCE As Panel
    Friend WithEvents LBL_CODE_MAINTENANCE_FROM_TO_GUIDE As Label
    Friend WithEvents TXT_CODE_MAINTENANCE_TO As TextBox
    Friend WithEvents LBL_CODE_MAINTENANCE_TO_NAME As Label
    Friend WithEvents LBL_CODE_MAINTENANCE_GUIDE As Label
    Friend WithEvents LBL_CODE_MAINTENANCE_FROM_NAME As Label
    Friend WithEvents TXT_CODE_MAINTENANCE_FROM As TextBox
    Friend WithEvents PNL_FLAG_CONTRACT As Panel
    Friend WithEvents CMB_FLAG_CONTRACT As ComboBox
    Friend WithEvents LBL_FLAG_CONTRACT_GUIDE As Label
End Class
