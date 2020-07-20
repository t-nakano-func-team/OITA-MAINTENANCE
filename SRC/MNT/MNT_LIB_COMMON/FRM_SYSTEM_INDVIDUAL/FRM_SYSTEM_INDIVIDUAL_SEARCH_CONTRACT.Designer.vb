<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRM_SYSTEM_INDIVIDUAL_SEARCH_CONTRACT
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GRP_HEAD = New System.Windows.Forms.GroupBox()
        Me.PNL_INFO_GUIDE = New System.Windows.Forms.Panel()
        Me.PNL_NAME_USER_HEAD = New System.Windows.Forms.Panel()
        Me.LBL_NAME_USER_HEAD = New System.Windows.Forms.Label()
        Me.LBL_NAME_USER_HEAD_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_DATE_ACTIVE_HEAD = New System.Windows.Forms.Panel()
        Me.LBL_DATE_ACTIVE_HEAD = New System.Windows.Forms.Label()
        Me.LBL_DATE_ACTIVE_HEAD_GUIDE = New System.Windows.Forms.Label()
        Me.GRP_BODY = New System.Windows.Forms.GroupBox()
        Me.DGV_VIEW_DATA = New System.Windows.Forms.DataGridView()
        Me.PNL_INPUT_KEY = New System.Windows.Forms.Panel()
        Me.PNL_KIND_CONTRACT = New System.Windows.Forms.Panel()
        Me.CMB_KIND_CONTRACT = New System.Windows.Forms.ComboBox()
        Me.LBL_KIND_CONTRACT_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_SEARCH = New System.Windows.Forms.Panel()
        Me.LBL_COUNT_SEARCH_MAX = New System.Windows.Forms.Label()
        Me.LBL_COUNT_SEARCH_UNIT = New System.Windows.Forms.Label()
        Me.LBL_COUNT_SEARCH = New System.Windows.Forms.Label()
        Me.LBL_COUNT_SEARCH_GUIDE = New System.Windows.Forms.Label()
        Me.BTN_SEARCH = New System.Windows.Forms.Button()
        Me.grpFOOT = New System.Windows.Forms.GroupBox()
        Me.pnlFUNCTION_GROUP = New System.Windows.Forms.Panel()
        Me.BTN_CLEAR = New System.Windows.Forms.Button()
        Me.BTN_OK = New System.Windows.Forms.Button()
        Me.BTN_CANCEL = New System.Windows.Forms.Button()
        Me.PNL_CODE_OWNER = New System.Windows.Forms.Panel()
        Me.LBL_CODE_OWNER_FROM_TO_GUIDE = New System.Windows.Forms.Label()
        Me.BTN_CODE_OWNER_TO_SEARCH = New System.Windows.Forms.Button()
        Me.TXT_CODE_OWNER_TO = New System.Windows.Forms.TextBox()
        Me.LBL_CODE_OWNER_TO_NAME = New System.Windows.Forms.Label()
        Me.LBL_CODE_OWNER_GUIDE = New System.Windows.Forms.Label()
        Me.LBL_CODE_OWNER_FROM_NAME = New System.Windows.Forms.Label()
        Me.BTN_CODE_OWNER_FROM_SEARCH = New System.Windows.Forms.Button()
        Me.TXT_CODE_OWNER_FROM = New System.Windows.Forms.TextBox()
        Me.PNL_DATE_CONTRACT = New System.Windows.Forms.Panel()
        Me.LBL_DATE_CONTRACT_FROM_TO_GUIDE = New System.Windows.Forms.Label()
        Me.DTP_DATE_CONTRACT_TO = New System.Windows.Forms.DateTimePicker()
        Me.DTP_DATE_CONTRACT_FROM = New System.Windows.Forms.DateTimePicker()
        Me.LBL_DATE_CONTRACT_GUIDE = New System.Windows.Forms.Label()
        Me.GRP_HEAD.SuspendLayout()
        Me.PNL_INFO_GUIDE.SuspendLayout()
        Me.PNL_NAME_USER_HEAD.SuspendLayout()
        Me.PNL_DATE_ACTIVE_HEAD.SuspendLayout()
        Me.GRP_BODY.SuspendLayout()
        CType(Me.DGV_VIEW_DATA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PNL_INPUT_KEY.SuspendLayout()
        Me.PNL_KIND_CONTRACT.SuspendLayout()
        Me.PNL_SEARCH.SuspendLayout()
        Me.grpFOOT.SuspendLayout()
        Me.pnlFUNCTION_GROUP.SuspendLayout()
        Me.PNL_CODE_OWNER.SuspendLayout()
        Me.PNL_DATE_CONTRACT.SuspendLayout()
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
        Me.GRP_BODY.Controls.Add(Me.DGV_VIEW_DATA)
        Me.GRP_BODY.Controls.Add(Me.PNL_INPUT_KEY)
        Me.GRP_BODY.Location = New System.Drawing.Point(10, 60)
        Me.GRP_BODY.Name = "GRP_BODY"
        Me.GRP_BODY.Size = New System.Drawing.Size(760, 430)
        Me.GRP_BODY.TabIndex = 1
        Me.GRP_BODY.TabStop = False
        '
        'DGV_VIEW_DATA
        '
        Me.DGV_VIEW_DATA.AllowUserToAddRows = False
        Me.DGV_VIEW_DATA.AllowUserToDeleteRows = False
        Me.DGV_VIEW_DATA.AllowUserToResizeColumns = False
        Me.DGV_VIEW_DATA.AllowUserToResizeRows = False
        Me.DGV_VIEW_DATA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV_VIEW_DATA.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(235, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(118, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(118, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_VIEW_DATA.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_VIEW_DATA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_VIEW_DATA.Location = New System.Drawing.Point(10, 135)
        Me.DGV_VIEW_DATA.MultiSelect = False
        Me.DGV_VIEW_DATA.Name = "DGV_VIEW_DATA"
        Me.DGV_VIEW_DATA.ReadOnly = True
        Me.DGV_VIEW_DATA.RowHeadersVisible = False
        Me.DGV_VIEW_DATA.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DGV_VIEW_DATA.RowTemplate.Height = 24
        Me.DGV_VIEW_DATA.RowTemplate.ReadOnly = True
        Me.DGV_VIEW_DATA.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_VIEW_DATA.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DGV_VIEW_DATA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV_VIEW_DATA.ShowCellErrors = False
        Me.DGV_VIEW_DATA.ShowCellToolTips = False
        Me.DGV_VIEW_DATA.ShowEditingIcon = False
        Me.DGV_VIEW_DATA.ShowRowErrors = False
        Me.DGV_VIEW_DATA.Size = New System.Drawing.Size(740, 285)
        Me.DGV_VIEW_DATA.TabIndex = 1
        Me.DGV_VIEW_DATA.TabStop = False
        '
        'PNL_INPUT_KEY
        '
        Me.PNL_INPUT_KEY.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PNL_INPUT_KEY.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.PNL_INPUT_KEY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PNL_INPUT_KEY.Controls.Add(Me.PNL_DATE_CONTRACT)
        Me.PNL_INPUT_KEY.Controls.Add(Me.PNL_CODE_OWNER)
        Me.PNL_INPUT_KEY.Controls.Add(Me.PNL_KIND_CONTRACT)
        Me.PNL_INPUT_KEY.Controls.Add(Me.PNL_SEARCH)
        Me.PNL_INPUT_KEY.Location = New System.Drawing.Point(10, 20)
        Me.PNL_INPUT_KEY.Name = "PNL_INPUT_KEY"
        Me.PNL_INPUT_KEY.Size = New System.Drawing.Size(740, 110)
        Me.PNL_INPUT_KEY.TabIndex = 0
        '
        'PNL_KIND_CONTRACT
        '
        Me.PNL_KIND_CONTRACT.Controls.Add(Me.CMB_KIND_CONTRACT)
        Me.PNL_KIND_CONTRACT.Controls.Add(Me.LBL_KIND_CONTRACT_GUIDE)
        Me.PNL_KIND_CONTRACT.Location = New System.Drawing.Point(5, 5)
        Me.PNL_KIND_CONTRACT.Name = "PNL_KIND_CONTRACT"
        Me.PNL_KIND_CONTRACT.Size = New System.Drawing.Size(240, 30)
        Me.PNL_KIND_CONTRACT.TabIndex = 0
        '
        'CMB_KIND_CONTRACT
        '
        Me.CMB_KIND_CONTRACT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_KIND_CONTRACT.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CMB_KIND_CONTRACT.Location = New System.Drawing.Point(80, 1)
        Me.CMB_KIND_CONTRACT.Name = "CMB_KIND_CONTRACT"
        Me.CMB_KIND_CONTRACT.Size = New System.Drawing.Size(150, 26)
        Me.CMB_KIND_CONTRACT.TabIndex = 1
        Me.CMB_KIND_CONTRACT.Tag = "Clear"
        '
        'LBL_KIND_CONTRACT_GUIDE
        '
        Me.LBL_KIND_CONTRACT_GUIDE.AutoEllipsis = True
        Me.LBL_KIND_CONTRACT_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_KIND_CONTRACT_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_KIND_CONTRACT_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_KIND_CONTRACT_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_KIND_CONTRACT_GUIDE.Name = "LBL_KIND_CONTRACT_GUIDE"
        Me.LBL_KIND_CONTRACT_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_KIND_CONTRACT_GUIDE.TabIndex = 0
        Me.LBL_KIND_CONTRACT_GUIDE.Text = "契約形態"
        Me.LBL_KIND_CONTRACT_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PNL_SEARCH
        '
        Me.PNL_SEARCH.AutoScroll = True
        Me.PNL_SEARCH.Controls.Add(Me.LBL_COUNT_SEARCH_MAX)
        Me.PNL_SEARCH.Controls.Add(Me.LBL_COUNT_SEARCH_UNIT)
        Me.PNL_SEARCH.Controls.Add(Me.LBL_COUNT_SEARCH)
        Me.PNL_SEARCH.Controls.Add(Me.LBL_COUNT_SEARCH_GUIDE)
        Me.PNL_SEARCH.Controls.Add(Me.BTN_SEARCH)
        Me.PNL_SEARCH.Location = New System.Drawing.Point(495, 75)
        Me.PNL_SEARCH.MinimumSize = New System.Drawing.Size(100, 25)
        Me.PNL_SEARCH.Name = "PNL_SEARCH"
        Me.PNL_SEARCH.Size = New System.Drawing.Size(240, 30)
        Me.PNL_SEARCH.TabIndex = 3
        '
        'LBL_COUNT_SEARCH_MAX
        '
        Me.LBL_COUNT_SEARCH_MAX.AutoSize = True
        Me.LBL_COUNT_SEARCH_MAX.ForeColor = System.Drawing.Color.Black
        Me.LBL_COUNT_SEARCH_MAX.Location = New System.Drawing.Point(192, 4)
        Me.LBL_COUNT_SEARCH_MAX.Name = "LBL_COUNT_SEARCH_MAX"
        Me.LBL_COUNT_SEARCH_MAX.Size = New System.Drawing.Size(42, 18)
        Me.LBL_COUNT_SEARCH_MAX.TabIndex = 9
        Me.LBL_COUNT_SEARCH_MAX.Tag = ""
        Me.LBL_COUNT_SEARCH_MAX.Text = "(最大)"
        Me.LBL_COUNT_SEARCH_MAX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LBL_COUNT_SEARCH_MAX.Visible = False
        '
        'LBL_COUNT_SEARCH_UNIT
        '
        Me.LBL_COUNT_SEARCH_UNIT.AutoSize = True
        Me.LBL_COUNT_SEARCH_UNIT.ForeColor = System.Drawing.Color.Black
        Me.LBL_COUNT_SEARCH_UNIT.Location = New System.Drawing.Point(172, 4)
        Me.LBL_COUNT_SEARCH_UNIT.Name = "LBL_COUNT_SEARCH_UNIT"
        Me.LBL_COUNT_SEARCH_UNIT.Size = New System.Drawing.Size(20, 18)
        Me.LBL_COUNT_SEARCH_UNIT.TabIndex = 8
        Me.LBL_COUNT_SEARCH_UNIT.Tag = ""
        Me.LBL_COUNT_SEARCH_UNIT.Text = "件"
        Me.LBL_COUNT_SEARCH_UNIT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LBL_COUNT_SEARCH
        '
        Me.LBL_COUNT_SEARCH.AutoEllipsis = True
        Me.LBL_COUNT_SEARCH.BackColor = System.Drawing.Color.White
        Me.LBL_COUNT_SEARCH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_COUNT_SEARCH.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBL_COUNT_SEARCH.Location = New System.Drawing.Point(120, 1)
        Me.LBL_COUNT_SEARCH.Name = "LBL_COUNT_SEARCH"
        Me.LBL_COUNT_SEARCH.Size = New System.Drawing.Size(50, 25)
        Me.LBL_COUNT_SEARCH.TabIndex = 7
        Me.LBL_COUNT_SEARCH.Tag = "Clear"
        Me.LBL_COUNT_SEARCH.Text = "****"
        Me.LBL_COUNT_SEARCH.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LBL_COUNT_SEARCH_GUIDE
        '
        Me.LBL_COUNT_SEARCH_GUIDE.AutoEllipsis = True
        Me.LBL_COUNT_SEARCH_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_COUNT_SEARCH_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_COUNT_SEARCH_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_COUNT_SEARCH_GUIDE.Location = New System.Drawing.Point(80, 1)
        Me.LBL_COUNT_SEARCH_GUIDE.Name = "LBL_COUNT_SEARCH_GUIDE"
        Me.LBL_COUNT_SEARCH_GUIDE.Size = New System.Drawing.Size(39, 25)
        Me.LBL_COUNT_SEARCH_GUIDE.TabIndex = 6
        Me.LBL_COUNT_SEARCH_GUIDE.Text = "件数"
        Me.LBL_COUNT_SEARCH_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BTN_SEARCH
        '
        Me.BTN_SEARCH.AutoSize = True
        Me.BTN_SEARCH.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_SEARCH.Location = New System.Drawing.Point(0, 0)
        Me.BTN_SEARCH.MinimumSize = New System.Drawing.Size(80, 28)
        Me.BTN_SEARCH.Name = "BTN_SEARCH"
        Me.BTN_SEARCH.Size = New System.Drawing.Size(80, 28)
        Me.BTN_SEARCH.TabIndex = 1
        Me.BTN_SEARCH.Text = "検索"
        Me.BTN_SEARCH.UseVisualStyleBackColor = False
        '
        'grpFOOT
        '
        Me.grpFOOT.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFOOT.Controls.Add(Me.pnlFUNCTION_GROUP)
        Me.grpFOOT.Location = New System.Drawing.Point(10, 490)
        Me.grpFOOT.Name = "grpFOOT"
        Me.grpFOOT.Size = New System.Drawing.Size(760, 60)
        Me.grpFOOT.TabIndex = 2
        Me.grpFOOT.TabStop = False
        '
        'pnlFUNCTION_GROUP
        '
        Me.pnlFUNCTION_GROUP.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnlFUNCTION_GROUP.AutoScroll = True
        Me.pnlFUNCTION_GROUP.Controls.Add(Me.BTN_CLEAR)
        Me.pnlFUNCTION_GROUP.Controls.Add(Me.BTN_OK)
        Me.pnlFUNCTION_GROUP.Controls.Add(Me.BTN_CANCEL)
        Me.pnlFUNCTION_GROUP.Location = New System.Drawing.Point(250, 15)
        Me.pnlFUNCTION_GROUP.MinimumSize = New System.Drawing.Size(190, 40)
        Me.pnlFUNCTION_GROUP.Name = "pnlFUNCTION_GROUP"
        Me.pnlFUNCTION_GROUP.Size = New System.Drawing.Size(270, 40)
        Me.pnlFUNCTION_GROUP.TabIndex = 0
        '
        'BTN_CLEAR
        '
        Me.BTN_CLEAR.AutoSize = True
        Me.BTN_CLEAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_CLEAR.Location = New System.Drawing.Point(95, 5)
        Me.BTN_CLEAR.MinimumSize = New System.Drawing.Size(80, 30)
        Me.BTN_CLEAR.Name = "BTN_CLEAR"
        Me.BTN_CLEAR.Size = New System.Drawing.Size(80, 30)
        Me.BTN_CLEAR.TabIndex = 3
        Me.BTN_CLEAR.Text = "クリア"
        Me.BTN_CLEAR.UseVisualStyleBackColor = False
        '
        'BTN_OK
        '
        Me.BTN_OK.AutoSize = True
        Me.BTN_OK.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_OK.Location = New System.Drawing.Point(10, 5)
        Me.BTN_OK.MinimumSize = New System.Drawing.Size(80, 30)
        Me.BTN_OK.Name = "BTN_OK"
        Me.BTN_OK.Size = New System.Drawing.Size(80, 30)
        Me.BTN_OK.TabIndex = 1
        Me.BTN_OK.Text = "OK"
        Me.BTN_OK.UseVisualStyleBackColor = False
        '
        'BTN_CANCEL
        '
        Me.BTN_CANCEL.AutoSize = True
        Me.BTN_CANCEL.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_CANCEL.Location = New System.Drawing.Point(180, 5)
        Me.BTN_CANCEL.MinimumSize = New System.Drawing.Size(80, 30)
        Me.BTN_CANCEL.Name = "BTN_CANCEL"
        Me.BTN_CANCEL.Size = New System.Drawing.Size(80, 30)
        Me.BTN_CANCEL.TabIndex = 4
        Me.BTN_CANCEL.Text = "キャンセル"
        Me.BTN_CANCEL.UseVisualStyleBackColor = False
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
        Me.PNL_CODE_OWNER.Location = New System.Drawing.Point(5, 40)
        Me.PNL_CODE_OWNER.Name = "PNL_CODE_OWNER"
        Me.PNL_CODE_OWNER.Size = New System.Drawing.Size(730, 30)
        Me.PNL_CODE_OWNER.TabIndex = 1
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
        Me.BTN_CODE_OWNER_TO_SEARCH.BackgroundImage = Global.MNT_LIB_COMMON.My.Resources.Resources.Search_16x
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
        Me.BTN_CODE_OWNER_FROM_SEARCH.BackgroundImage = Global.MNT_LIB_COMMON.My.Resources.Resources.Search_16x
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
        'PNL_DATE_CONTRACT
        '
        Me.PNL_DATE_CONTRACT.Controls.Add(Me.LBL_DATE_CONTRACT_FROM_TO_GUIDE)
        Me.PNL_DATE_CONTRACT.Controls.Add(Me.DTP_DATE_CONTRACT_TO)
        Me.PNL_DATE_CONTRACT.Controls.Add(Me.DTP_DATE_CONTRACT_FROM)
        Me.PNL_DATE_CONTRACT.Controls.Add(Me.LBL_DATE_CONTRACT_GUIDE)
        Me.PNL_DATE_CONTRACT.Location = New System.Drawing.Point(5, 75)
        Me.PNL_DATE_CONTRACT.Name = "PNL_DATE_CONTRACT"
        Me.PNL_DATE_CONTRACT.Size = New System.Drawing.Size(420, 30)
        Me.PNL_DATE_CONTRACT.TabIndex = 2
        '
        'LBL_DATE_CONTRACT_FROM_TO_GUIDE
        '
        Me.LBL_DATE_CONTRACT_FROM_TO_GUIDE.AutoEllipsis = True
        Me.LBL_DATE_CONTRACT_FROM_TO_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_DATE_CONTRACT_FROM_TO_GUIDE.Location = New System.Drawing.Point(235, 1)
        Me.LBL_DATE_CONTRACT_FROM_TO_GUIDE.Name = "LBL_DATE_CONTRACT_FROM_TO_GUIDE"
        Me.LBL_DATE_CONTRACT_FROM_TO_GUIDE.Size = New System.Drawing.Size(20, 25)
        Me.LBL_DATE_CONTRACT_FROM_TO_GUIDE.TabIndex = 9
        Me.LBL_DATE_CONTRACT_FROM_TO_GUIDE.Text = "～"
        Me.LBL_DATE_CONTRACT_FROM_TO_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'FRM_SYSTEM_INDIVIDUAL_SEARCH_CONTRACT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.grpFOOT)
        Me.Controls.Add(Me.GRP_BODY)
        Me.Controls.Add(Me.GRP_HEAD)
        Me.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MinimumSize = New System.Drawing.Size(800, 600)
        Me.Name = "FRM_SYSTEM_INDIVIDUAL_SEARCH_CONTRACT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "**"
        Me.GRP_HEAD.ResumeLayout(False)
        Me.PNL_INFO_GUIDE.ResumeLayout(False)
        Me.PNL_NAME_USER_HEAD.ResumeLayout(False)
        Me.PNL_DATE_ACTIVE_HEAD.ResumeLayout(False)
        Me.GRP_BODY.ResumeLayout(False)
        CType(Me.DGV_VIEW_DATA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PNL_INPUT_KEY.ResumeLayout(False)
        Me.PNL_KIND_CONTRACT.ResumeLayout(False)
        Me.PNL_SEARCH.ResumeLayout(False)
        Me.PNL_SEARCH.PerformLayout()
        Me.grpFOOT.ResumeLayout(False)
        Me.pnlFUNCTION_GROUP.ResumeLayout(False)
        Me.pnlFUNCTION_GROUP.PerformLayout()
        Me.PNL_CODE_OWNER.ResumeLayout(False)
        Me.PNL_CODE_OWNER.PerformLayout()
        Me.PNL_DATE_CONTRACT.ResumeLayout(False)
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
    Friend WithEvents DGV_VIEW_DATA As DataGridView
    Friend WithEvents PNL_INPUT_KEY As Panel
    Friend WithEvents PNL_KIND_CONTRACT As Panel
    Friend WithEvents CMB_KIND_CONTRACT As ComboBox
    Friend WithEvents LBL_KIND_CONTRACT_GUIDE As Label
    Friend WithEvents PNL_SEARCH As Panel
    Friend WithEvents LBL_COUNT_SEARCH_MAX As Label
    Friend WithEvents LBL_COUNT_SEARCH_UNIT As Label
    Friend WithEvents LBL_COUNT_SEARCH As Label
    Friend WithEvents LBL_COUNT_SEARCH_GUIDE As Label
    Friend WithEvents BTN_SEARCH As Button
    Friend WithEvents grpFOOT As GroupBox
    Friend WithEvents pnlFUNCTION_GROUP As Panel
    Friend WithEvents BTN_CLEAR As Button
    Friend WithEvents BTN_OK As Button
    Friend WithEvents BTN_CANCEL As Button
    Friend WithEvents PNL_CODE_OWNER As Panel
    Friend WithEvents LBL_CODE_OWNER_FROM_TO_GUIDE As Label
    Friend WithEvents BTN_CODE_OWNER_TO_SEARCH As Button
    Friend WithEvents TXT_CODE_OWNER_TO As TextBox
    Friend WithEvents LBL_CODE_OWNER_TO_NAME As Label
    Friend WithEvents LBL_CODE_OWNER_GUIDE As Label
    Friend WithEvents LBL_CODE_OWNER_FROM_NAME As Label
    Friend WithEvents BTN_CODE_OWNER_FROM_SEARCH As Button
    Friend WithEvents TXT_CODE_OWNER_FROM As TextBox
    Friend WithEvents PNL_DATE_CONTRACT As Panel
    Friend WithEvents LBL_DATE_CONTRACT_FROM_TO_GUIDE As Label
    Friend WithEvents DTP_DATE_CONTRACT_TO As DateTimePicker
    Friend WithEvents DTP_DATE_CONTRACT_FROM As DateTimePicker
    Friend WithEvents LBL_DATE_CONTRACT_GUIDE As Label
End Class
