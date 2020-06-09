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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.DGV_VIEW_DATA = New System.Windows.Forms.DataGridView()
        Me.PNL_INPUT_DATA = New System.Windows.Forms.Panel()
        Me.PNL_CODE_SECTION = New System.Windows.Forms.Panel()
        Me.CMB_CODE_SECTION = New System.Windows.Forms.ComboBox()
        Me.LBL_CODE_SECTION_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_KIND_OWNER = New System.Windows.Forms.Panel()
        Me.CMB_KIND_OWNER = New System.Windows.Forms.ComboBox()
        Me.LBL_KIND_OWNER_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_KIND_FIXED_DATE = New System.Windows.Forms.Panel()
        Me.CMB_KIND_FIXED_DATE = New System.Windows.Forms.ComboBox()
        Me.LBL_KIND_FIXED_DATE_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_NAME_ADDRESS_02 = New System.Windows.Forms.Panel()
        Me.TXT_NAME_ADDRESS_02 = New System.Windows.Forms.TextBox()
        Me.LBL_NAME_ADDRESS_02 = New System.Windows.Forms.Label()
        Me.PNL_NAME_ADDRESS_01 = New System.Windows.Forms.Panel()
        Me.TXT_NAME_ADDRESS_01 = New System.Windows.Forms.TextBox()
        Me.LBL_NAME_ADDRESS_01 = New System.Windows.Forms.Label()
        Me.PNL_CODE_POST = New System.Windows.Forms.Panel()
        Me.LBL_CODE_POST_GUIDE = New System.Windows.Forms.Label()
        Me.TXT_CODE_POST = New System.Windows.Forms.TextBox()
        Me.PNL_KANA_OWNER = New System.Windows.Forms.Panel()
        Me.TXT_KANA_OWNER = New System.Windows.Forms.TextBox()
        Me.LBL_KANA_OWNER_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_NAME_OWNER_SHORT = New System.Windows.Forms.Panel()
        Me.TXT_NAME_OWNER_SHORT = New System.Windows.Forms.TextBox()
        Me.LBL_NAME_OWNER_SHORT_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_NAME_OWNER = New System.Windows.Forms.Panel()
        Me.TXT_NAME_OWNER = New System.Windows.Forms.TextBox()
        Me.LBL_NAME_OWNER_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_INPUT_KEY = New System.Windows.Forms.Panel()
        Me.PNL_CODE_OWNER = New System.Windows.Forms.Panel()
        Me.LBL_CODE_OWNER_GUIDE = New System.Windows.Forms.Label()
        Me.TXT_CODE_OWNER = New System.Windows.Forms.TextBox()
        Me.GRP_HEAD.SuspendLayout()
        Me.PNL_INFO_GUIDE.SuspendLayout()
        Me.PNL_NAME_USER_HEAD.SuspendLayout()
        Me.PNL_DATE_ACTIVE_HEAD.SuspendLayout()
        Me.GRP_FOOT.SuspendLayout()
        Me.pnlFUNCTION_GROUP.SuspendLayout()
        Me.GRP_BODY.SuspendLayout()
        CType(Me.DGV_VIEW_DATA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PNL_INPUT_DATA.SuspendLayout()
        Me.PNL_CODE_SECTION.SuspendLayout()
        Me.PNL_KIND_OWNER.SuspendLayout()
        Me.PNL_KIND_FIXED_DATE.SuspendLayout()
        Me.PNL_NAME_ADDRESS_02.SuspendLayout()
        Me.PNL_NAME_ADDRESS_01.SuspendLayout()
        Me.PNL_CODE_POST.SuspendLayout()
        Me.PNL_KANA_OWNER.SuspendLayout()
        Me.PNL_NAME_OWNER_SHORT.SuspendLayout()
        Me.PNL_NAME_OWNER.SuspendLayout()
        Me.PNL_INPUT_KEY.SuspendLayout()
        Me.PNL_CODE_OWNER.SuspendLayout()
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
        Me.GRP_HEAD.TabIndex = 4
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
        'GRP_FOOT
        '
        Me.GRP_FOOT.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GRP_FOOT.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.GRP_FOOT.Controls.Add(Me.pnlFUNCTION_GROUP)
        Me.GRP_FOOT.Location = New System.Drawing.Point(10, 490)
        Me.GRP_FOOT.Name = "GRP_FOOT"
        Me.GRP_FOOT.Size = New System.Drawing.Size(760, 60)
        Me.GRP_FOOT.TabIndex = 8
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
        Me.GRP_BODY.Controls.Add(Me.DGV_VIEW_DATA)
        Me.GRP_BODY.Controls.Add(Me.PNL_INPUT_DATA)
        Me.GRP_BODY.Controls.Add(Me.PNL_INPUT_KEY)
        Me.GRP_BODY.Location = New System.Drawing.Point(10, 60)
        Me.GRP_BODY.Name = "GRP_BODY"
        Me.GRP_BODY.Size = New System.Drawing.Size(760, 430)
        Me.GRP_BODY.TabIndex = 9
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
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(118, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("メイリオ", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(118, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_VIEW_DATA.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_VIEW_DATA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_VIEW_DATA.Location = New System.Drawing.Point(10, 205)
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
        Me.DGV_VIEW_DATA.Size = New System.Drawing.Size(740, 215)
        Me.DGV_VIEW_DATA.TabIndex = 3
        Me.DGV_VIEW_DATA.TabStop = False
        '
        'PNL_INPUT_DATA
        '
        Me.PNL_INPUT_DATA.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PNL_INPUT_DATA.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.PNL_INPUT_DATA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PNL_INPUT_DATA.Controls.Add(Me.PNL_CODE_SECTION)
        Me.PNL_INPUT_DATA.Controls.Add(Me.PNL_KIND_OWNER)
        Me.PNL_INPUT_DATA.Controls.Add(Me.PNL_KIND_FIXED_DATE)
        Me.PNL_INPUT_DATA.Controls.Add(Me.PNL_NAME_ADDRESS_02)
        Me.PNL_INPUT_DATA.Controls.Add(Me.PNL_NAME_ADDRESS_01)
        Me.PNL_INPUT_DATA.Controls.Add(Me.PNL_CODE_POST)
        Me.PNL_INPUT_DATA.Controls.Add(Me.PNL_KANA_OWNER)
        Me.PNL_INPUT_DATA.Controls.Add(Me.PNL_NAME_OWNER_SHORT)
        Me.PNL_INPUT_DATA.Controls.Add(Me.PNL_NAME_OWNER)
        Me.PNL_INPUT_DATA.Location = New System.Drawing.Point(10, 70)
        Me.PNL_INPUT_DATA.Name = "PNL_INPUT_DATA"
        Me.PNL_INPUT_DATA.Size = New System.Drawing.Size(740, 130)
        Me.PNL_INPUT_DATA.TabIndex = 1
        '
        'PNL_CODE_SECTION
        '
        Me.PNL_CODE_SECTION.Controls.Add(Me.CMB_CODE_SECTION)
        Me.PNL_CODE_SECTION.Controls.Add(Me.LBL_CODE_SECTION_GUIDE)
        Me.PNL_CODE_SECTION.Location = New System.Drawing.Point(5, 35)
        Me.PNL_CODE_SECTION.Name = "PNL_CODE_SECTION"
        Me.PNL_CODE_SECTION.Size = New System.Drawing.Size(240, 30)
        Me.PNL_CODE_SECTION.TabIndex = 3
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
        'PNL_KIND_OWNER
        '
        Me.PNL_KIND_OWNER.Controls.Add(Me.CMB_KIND_OWNER)
        Me.PNL_KIND_OWNER.Controls.Add(Me.LBL_KIND_OWNER_GUIDE)
        Me.PNL_KIND_OWNER.Location = New System.Drawing.Point(255, 35)
        Me.PNL_KIND_OWNER.Name = "PNL_KIND_OWNER"
        Me.PNL_KIND_OWNER.Size = New System.Drawing.Size(240, 30)
        Me.PNL_KIND_OWNER.TabIndex = 4
        '
        'CMB_KIND_OWNER
        '
        Me.CMB_KIND_OWNER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_KIND_OWNER.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CMB_KIND_OWNER.Location = New System.Drawing.Point(80, 1)
        Me.CMB_KIND_OWNER.Name = "CMB_KIND_OWNER"
        Me.CMB_KIND_OWNER.Size = New System.Drawing.Size(150, 26)
        Me.CMB_KIND_OWNER.TabIndex = 1
        Me.CMB_KIND_OWNER.Tag = "Clear"
        '
        'LBL_KIND_OWNER_GUIDE
        '
        Me.LBL_KIND_OWNER_GUIDE.AutoEllipsis = True
        Me.LBL_KIND_OWNER_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_KIND_OWNER_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_KIND_OWNER_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_KIND_OWNER_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_KIND_OWNER_GUIDE.Name = "LBL_KIND_OWNER_GUIDE"
        Me.LBL_KIND_OWNER_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_KIND_OWNER_GUIDE.TabIndex = 0
        Me.LBL_KIND_OWNER_GUIDE.Text = "形式"
        Me.LBL_KIND_OWNER_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PNL_KIND_FIXED_DATE
        '
        Me.PNL_KIND_FIXED_DATE.Controls.Add(Me.CMB_KIND_FIXED_DATE)
        Me.PNL_KIND_FIXED_DATE.Controls.Add(Me.LBL_KIND_FIXED_DATE_GUIDE)
        Me.PNL_KIND_FIXED_DATE.Location = New System.Drawing.Point(5, 95)
        Me.PNL_KIND_FIXED_DATE.Name = "PNL_KIND_FIXED_DATE"
        Me.PNL_KIND_FIXED_DATE.Size = New System.Drawing.Size(240, 30)
        Me.PNL_KIND_FIXED_DATE.TabIndex = 8
        '
        'CMB_KIND_FIXED_DATE
        '
        Me.CMB_KIND_FIXED_DATE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_KIND_FIXED_DATE.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CMB_KIND_FIXED_DATE.Location = New System.Drawing.Point(80, 1)
        Me.CMB_KIND_FIXED_DATE.Name = "CMB_KIND_FIXED_DATE"
        Me.CMB_KIND_FIXED_DATE.Size = New System.Drawing.Size(150, 26)
        Me.CMB_KIND_FIXED_DATE.TabIndex = 1
        Me.CMB_KIND_FIXED_DATE.Tag = "Clear"
        '
        'LBL_KIND_FIXED_DATE_GUIDE
        '
        Me.LBL_KIND_FIXED_DATE_GUIDE.AutoEllipsis = True
        Me.LBL_KIND_FIXED_DATE_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_KIND_FIXED_DATE_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_KIND_FIXED_DATE_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_KIND_FIXED_DATE_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_KIND_FIXED_DATE_GUIDE.Name = "LBL_KIND_FIXED_DATE_GUIDE"
        Me.LBL_KIND_FIXED_DATE_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_KIND_FIXED_DATE_GUIDE.TabIndex = 0
        Me.LBL_KIND_FIXED_DATE_GUIDE.Text = "請求締日"
        Me.LBL_KIND_FIXED_DATE_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PNL_NAME_ADDRESS_02
        '
        Me.PNL_NAME_ADDRESS_02.Controls.Add(Me.TXT_NAME_ADDRESS_02)
        Me.PNL_NAME_ADDRESS_02.Controls.Add(Me.LBL_NAME_ADDRESS_02)
        Me.PNL_NAME_ADDRESS_02.Location = New System.Drawing.Point(500, 65)
        Me.PNL_NAME_ADDRESS_02.Name = "PNL_NAME_ADDRESS_02"
        Me.PNL_NAME_ADDRESS_02.Size = New System.Drawing.Size(240, 30)
        Me.PNL_NAME_ADDRESS_02.TabIndex = 7
        '
        'TXT_NAME_ADDRESS_02
        '
        Me.TXT_NAME_ADDRESS_02.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.TXT_NAME_ADDRESS_02.Location = New System.Drawing.Point(80, 1)
        Me.TXT_NAME_ADDRESS_02.MaxLength = 30
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
        Me.PNL_NAME_ADDRESS_01.Location = New System.Drawing.Point(255, 65)
        Me.PNL_NAME_ADDRESS_01.Name = "PNL_NAME_ADDRESS_01"
        Me.PNL_NAME_ADDRESS_01.Size = New System.Drawing.Size(240, 30)
        Me.PNL_NAME_ADDRESS_01.TabIndex = 6
        '
        'TXT_NAME_ADDRESS_01
        '
        Me.TXT_NAME_ADDRESS_01.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.TXT_NAME_ADDRESS_01.Location = New System.Drawing.Point(80, 1)
        Me.TXT_NAME_ADDRESS_01.MaxLength = 30
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
        Me.PNL_CODE_POST.Location = New System.Drawing.Point(5, 65)
        Me.PNL_CODE_POST.Name = "PNL_CODE_POST"
        Me.PNL_CODE_POST.Size = New System.Drawing.Size(240, 30)
        Me.PNL_CODE_POST.TabIndex = 5
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
        'PNL_KANA_OWNER
        '
        Me.PNL_KANA_OWNER.Controls.Add(Me.TXT_KANA_OWNER)
        Me.PNL_KANA_OWNER.Controls.Add(Me.LBL_KANA_OWNER_GUIDE)
        Me.PNL_KANA_OWNER.Location = New System.Drawing.Point(500, 6)
        Me.PNL_KANA_OWNER.Name = "PNL_KANA_OWNER"
        Me.PNL_KANA_OWNER.Size = New System.Drawing.Size(240, 30)
        Me.PNL_KANA_OWNER.TabIndex = 2
        '
        'TXT_KANA_OWNER
        '
        Me.TXT_KANA_OWNER.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.TXT_KANA_OWNER.Location = New System.Drawing.Point(80, 1)
        Me.TXT_KANA_OWNER.MaxLength = 40
        Me.TXT_KANA_OWNER.Name = "TXT_KANA_OWNER"
        Me.TXT_KANA_OWNER.Size = New System.Drawing.Size(150, 25)
        Me.TXT_KANA_OWNER.TabIndex = 1
        Me.TXT_KANA_OWNER.Tag = "Clear,Check,Char,NotNull"
        '
        'LBL_KANA_OWNER_GUIDE
        '
        Me.LBL_KANA_OWNER_GUIDE.AutoEllipsis = True
        Me.LBL_KANA_OWNER_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_KANA_OWNER_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_KANA_OWNER_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_KANA_OWNER_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_KANA_OWNER_GUIDE.Name = "LBL_KANA_OWNER_GUIDE"
        Me.LBL_KANA_OWNER_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_KANA_OWNER_GUIDE.TabIndex = 0
        Me.LBL_KANA_OWNER_GUIDE.Text = "カナ名称"
        Me.LBL_KANA_OWNER_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PNL_NAME_OWNER_SHORT
        '
        Me.PNL_NAME_OWNER_SHORT.Controls.Add(Me.TXT_NAME_OWNER_SHORT)
        Me.PNL_NAME_OWNER_SHORT.Controls.Add(Me.LBL_NAME_OWNER_SHORT_GUIDE)
        Me.PNL_NAME_OWNER_SHORT.Location = New System.Drawing.Point(255, 5)
        Me.PNL_NAME_OWNER_SHORT.Name = "PNL_NAME_OWNER_SHORT"
        Me.PNL_NAME_OWNER_SHORT.Size = New System.Drawing.Size(240, 30)
        Me.PNL_NAME_OWNER_SHORT.TabIndex = 1
        '
        'TXT_NAME_OWNER_SHORT
        '
        Me.TXT_NAME_OWNER_SHORT.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.TXT_NAME_OWNER_SHORT.Location = New System.Drawing.Point(80, 1)
        Me.TXT_NAME_OWNER_SHORT.MaxLength = 40
        Me.TXT_NAME_OWNER_SHORT.Name = "TXT_NAME_OWNER_SHORT"
        Me.TXT_NAME_OWNER_SHORT.Size = New System.Drawing.Size(150, 25)
        Me.TXT_NAME_OWNER_SHORT.TabIndex = 1
        Me.TXT_NAME_OWNER_SHORT.Tag = "Clear,Check,Char,NotNull"
        '
        'LBL_NAME_OWNER_SHORT_GUIDE
        '
        Me.LBL_NAME_OWNER_SHORT_GUIDE.AutoEllipsis = True
        Me.LBL_NAME_OWNER_SHORT_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_NAME_OWNER_SHORT_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_NAME_OWNER_SHORT_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_NAME_OWNER_SHORT_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_NAME_OWNER_SHORT_GUIDE.Name = "LBL_NAME_OWNER_SHORT_GUIDE"
        Me.LBL_NAME_OWNER_SHORT_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_NAME_OWNER_SHORT_GUIDE.TabIndex = 0
        Me.LBL_NAME_OWNER_SHORT_GUIDE.Text = "略称"
        Me.LBL_NAME_OWNER_SHORT_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PNL_NAME_OWNER
        '
        Me.PNL_NAME_OWNER.Controls.Add(Me.TXT_NAME_OWNER)
        Me.PNL_NAME_OWNER.Controls.Add(Me.LBL_NAME_OWNER_GUIDE)
        Me.PNL_NAME_OWNER.Location = New System.Drawing.Point(5, 5)
        Me.PNL_NAME_OWNER.Name = "PNL_NAME_OWNER"
        Me.PNL_NAME_OWNER.Size = New System.Drawing.Size(240, 30)
        Me.PNL_NAME_OWNER.TabIndex = 0
        '
        'TXT_NAME_OWNER
        '
        Me.TXT_NAME_OWNER.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.TXT_NAME_OWNER.Location = New System.Drawing.Point(90, 1)
        Me.TXT_NAME_OWNER.MaxLength = 40
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
        'PNL_INPUT_KEY
        '
        Me.PNL_INPUT_KEY.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PNL_INPUT_KEY.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.PNL_INPUT_KEY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PNL_INPUT_KEY.Controls.Add(Me.PNL_CODE_OWNER)
        Me.PNL_INPUT_KEY.Location = New System.Drawing.Point(10, 20)
        Me.PNL_INPUT_KEY.Name = "PNL_INPUT_KEY"
        Me.PNL_INPUT_KEY.Size = New System.Drawing.Size(740, 40)
        Me.PNL_INPUT_KEY.TabIndex = 0
        '
        'PNL_CODE_OWNER
        '
        Me.PNL_CODE_OWNER.Controls.Add(Me.LBL_CODE_OWNER_GUIDE)
        Me.PNL_CODE_OWNER.Controls.Add(Me.TXT_CODE_OWNER)
        Me.PNL_CODE_OWNER.Location = New System.Drawing.Point(5, 5)
        Me.PNL_CODE_OWNER.Name = "PNL_CODE_OWNER"
        Me.PNL_CODE_OWNER.Size = New System.Drawing.Size(240, 30)
        Me.PNL_CODE_OWNER.TabIndex = 0
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
        Me.LBL_CODE_OWNER_GUIDE.TabIndex = 3
        Me.LBL_CODE_OWNER_GUIDE.Text = "オーナーコード"
        Me.LBL_CODE_OWNER_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXT_CODE_OWNER
        '
        Me.TXT_CODE_OWNER.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TXT_CODE_OWNER.Location = New System.Drawing.Point(100, 1)
        Me.TXT_CODE_OWNER.MaxLength = 6
        Me.TXT_CODE_OWNER.Name = "TXT_CODE_OWNER"
        Me.TXT_CODE_OWNER.Size = New System.Drawing.Size(130, 25)
        Me.TXT_CODE_OWNER.TabIndex = 1
        Me.TXT_CODE_OWNER.Tag = "Clear,Numeric,Format=000000,Check,NotNull,NotZero,Plus"
        Me.TXT_CODE_OWNER.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.Font = New System.Drawing.Font("メイリオ", 9.0!)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
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
        CType(Me.DGV_VIEW_DATA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PNL_INPUT_DATA.ResumeLayout(False)
        Me.PNL_CODE_SECTION.ResumeLayout(False)
        Me.PNL_KIND_OWNER.ResumeLayout(False)
        Me.PNL_KIND_FIXED_DATE.ResumeLayout(False)
        Me.PNL_NAME_ADDRESS_02.ResumeLayout(False)
        Me.PNL_NAME_ADDRESS_02.PerformLayout()
        Me.PNL_NAME_ADDRESS_01.ResumeLayout(False)
        Me.PNL_NAME_ADDRESS_01.PerformLayout()
        Me.PNL_CODE_POST.ResumeLayout(False)
        Me.PNL_CODE_POST.PerformLayout()
        Me.PNL_KANA_OWNER.ResumeLayout(False)
        Me.PNL_KANA_OWNER.PerformLayout()
        Me.PNL_NAME_OWNER_SHORT.ResumeLayout(False)
        Me.PNL_NAME_OWNER_SHORT.PerformLayout()
        Me.PNL_NAME_OWNER.ResumeLayout(False)
        Me.PNL_NAME_OWNER.PerformLayout()
        Me.PNL_INPUT_KEY.ResumeLayout(False)
        Me.PNL_CODE_OWNER.ResumeLayout(False)
        Me.PNL_CODE_OWNER.PerformLayout()
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
    Friend WithEvents DGV_VIEW_DATA As DataGridView
    Friend WithEvents PNL_INPUT_DATA As Panel
    Friend WithEvents PNL_INPUT_KEY As Panel
    Friend WithEvents PNL_CODE_OWNER As Panel
    Friend WithEvents LBL_CODE_OWNER_GUIDE As Label
    Friend WithEvents TXT_CODE_OWNER As TextBox
    Friend WithEvents PNL_NAME_OWNER As Panel
    Friend WithEvents TXT_NAME_OWNER As TextBox
    Friend WithEvents LBL_NAME_OWNER_GUIDE As Label
    Friend WithEvents PNL_NAME_OWNER_SHORT As Panel
    Friend WithEvents TXT_NAME_OWNER_SHORT As TextBox
    Friend WithEvents LBL_NAME_OWNER_SHORT_GUIDE As Label
    Friend WithEvents PNL_KANA_OWNER As Panel
    Friend WithEvents TXT_KANA_OWNER As TextBox
    Friend WithEvents LBL_KANA_OWNER_GUIDE As Label
    Friend WithEvents PNL_CODE_POST As Panel
    Friend WithEvents LBL_CODE_POST_GUIDE As Label
    Friend WithEvents TXT_CODE_POST As TextBox
    Friend WithEvents PNL_NAME_ADDRESS_01 As Panel
    Friend WithEvents TXT_NAME_ADDRESS_01 As TextBox
    Friend WithEvents LBL_NAME_ADDRESS_01 As Label
    Friend WithEvents PNL_NAME_ADDRESS_02 As Panel
    Friend WithEvents TXT_NAME_ADDRESS_02 As TextBox
    Friend WithEvents LBL_NAME_ADDRESS_02 As Label
    Friend WithEvents PNL_KIND_FIXED_DATE As Panel
    Friend WithEvents CMB_KIND_FIXED_DATE As ComboBox
    Friend WithEvents LBL_KIND_FIXED_DATE_GUIDE As Label
    Friend WithEvents PNL_CODE_SECTION As Panel
    Friend WithEvents CMB_CODE_SECTION As ComboBox
    Friend WithEvents LBL_CODE_SECTION_GUIDE As Label
    Friend WithEvents PNL_KIND_OWNER As Panel
    Friend WithEvents CMB_KIND_OWNER As ComboBox
    Friend WithEvents LBL_KIND_OWNER_GUIDE As Label
End Class
