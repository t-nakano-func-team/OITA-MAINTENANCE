<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_SUB_01
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
        Me.PNL_INPUT_DATA = New System.Windows.Forms.Panel()
        Me.PNL_CODE_SECTION = New System.Windows.Forms.Panel()
        Me.CMB_CODE_SECTION = New System.Windows.Forms.ComboBox()
        Me.LBL_CODE_SECTION_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_DEPOSIT_INPUT_AREA = New System.Windows.Forms.Panel()
        Me.PNL_FLAG_SALE = New System.Windows.Forms.Panel()
        Me.CMB_FLAG_SALE = New System.Windows.Forms.ComboBox()
        Me.LBL_FLAG_SALE_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_SERIAL_DEPOSIT = New System.Windows.Forms.Panel()
        Me.LBL_SERIAL_DEPOSIT = New System.Windows.Forms.Label()
        Me.LBL_SERIAL_DEPOSIT_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_FLAG_DEPOSIT_SUB = New System.Windows.Forms.Panel()
        Me.CMB_FLAG_DEPOSIT_SUB = New System.Windows.Forms.ComboBox()
        Me.LBL_FLAG_DEPOSIT_SUB_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_NAME_MEMO = New System.Windows.Forms.Panel()
        Me.TXT_NAME_MEMO = New System.Windows.Forms.TextBox()
        Me.LBL_NAME_MEMO_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_KINGAKU_COST = New System.Windows.Forms.Panel()
        Me.LBL_KINGAKU_COST_TOTAL = New System.Windows.Forms.Label()
        Me.TXT_KINGAKU_COST_VAT = New System.Windows.Forms.TextBox()
        Me.LBL_KINGAKU_COST_GUIDE = New System.Windows.Forms.Label()
        Me.TXT_KINGAKU_COST_DETAIL = New System.Windows.Forms.TextBox()
        Me.PNL_FLAG_COST = New System.Windows.Forms.Panel()
        Me.CMB_FLAG_COST = New System.Windows.Forms.ComboBox()
        Me.LBL_FLAG_COST_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_KINGAKU_FEE = New System.Windows.Forms.Panel()
        Me.CMB_KINGAKU_FEE_DETAIL = New System.Windows.Forms.ComboBox()
        Me.LBL_KINGAKU_FEE_TOTAL = New System.Windows.Forms.Label()
        Me.TXT_KINGAKU_FEE_VAT = New System.Windows.Forms.TextBox()
        Me.LBL_KINGAKU_FEE_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_FLAG_DEPOSIT = New System.Windows.Forms.Panel()
        Me.CMB_FLAG_DEPOSIT = New System.Windows.Forms.ComboBox()
        Me.LBL_FLAG_DEPOSIT_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_DATE_DEPOSIT = New System.Windows.Forms.Panel()
        Me.DTP_DATE_DEPOSIT = New System.Windows.Forms.DateTimePicker()
        Me.LBL_DATE_DEPOSIT_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_FLAG_DEPOSIT_DONE = New System.Windows.Forms.Panel()
        Me.CHK_FLAG_DEPOSIT_DONE = New System.Windows.Forms.CheckBox()
        Me.LBL_FLAG_DEPOSIT_DONE_GUIDE = New System.Windows.Forms.Label()
        Me.LBL_FLAG_DEPOSIT_DONE_BACK = New System.Windows.Forms.Label()
        Me.PNL_KINGAKU_INVOICE = New System.Windows.Forms.Panel()
        Me.LBL_KINGAKU_INVOICE_TOTAL = New System.Windows.Forms.Label()
        Me.TXT_KINGAKU_INVOICE_VAT = New System.Windows.Forms.TextBox()
        Me.LBL_KINGAKU_INVOICE_GUIDE = New System.Windows.Forms.Label()
        Me.TXT_KINGAKU_INVOICE_DETAIL = New System.Windows.Forms.TextBox()
        Me.PNL_INPUT_KEY = New System.Windows.Forms.Panel()
        Me.PNL_DATE_INVOICE = New System.Windows.Forms.Panel()
        Me.LBL_DATE_INVOICE = New System.Windows.Forms.Label()
        Me.LBL_DATE_INVOICE_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_KINGAKU_CONTRACT = New System.Windows.Forms.Panel()
        Me.LBL_KINGAKU_CONTRACT = New System.Windows.Forms.Label()
        Me.LBL_KINGAKU_CONTRACT_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_NAME_CONTRACT = New System.Windows.Forms.Panel()
        Me.LBL_NAME_CONTRACT = New System.Windows.Forms.Label()
        Me.LBL_NAME_CONTRACT_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_CODE_SHINTO_PARENT = New System.Windows.Forms.Panel()
        Me.LBL_CODE_OWNER = New System.Windows.Forms.Label()
        Me.LBL_CODE_OWNER_GUIDE = New System.Windows.Forms.Label()
        Me.LBL_CODE_OWNER_NAME = New System.Windows.Forms.Label()
        Me.PNL_NUMBER_CONTRACT = New System.Windows.Forms.Panel()
        Me.LBL_NUMBER_CONTRACT_LINK = New System.Windows.Forms.Label()
        Me.LBL_SERIAL_CONTRACT = New System.Windows.Forms.Label()
        Me.LBL_NUMBER_CONTRACT = New System.Windows.Forms.Label()
        Me.LBL_NUMBER_CONTRACT_GUIDE = New System.Windows.Forms.Label()
        Me.GRP_FOOT = New System.Windows.Forms.GroupBox()
        Me.pnlFUNCTION_GROUP = New System.Windows.Forms.Panel()
        Me.BTN_CLEAR = New System.Windows.Forms.Button()
        Me.BTN_ENTER = New System.Windows.Forms.Button()
        Me.BTN_END = New System.Windows.Forms.Button()
        Me.PNL_FLAG_OUTPUT = New System.Windows.Forms.Panel()
        Me.LBL_FLAG_OUTPUT = New System.Windows.Forms.Label()
        Me.LBL_FLAG_OUTPUT_GUIDE = New System.Windows.Forms.Label()
        Me.GRP_HEAD.SuspendLayout()
        Me.PNL_INFO_GUIDE.SuspendLayout()
        Me.PNL_NAME_USER_HEAD.SuspendLayout()
        Me.PNL_DATE_ACTIVE_HEAD.SuspendLayout()
        Me.GRP_BODY.SuspendLayout()
        Me.PNL_INPUT_DATA.SuspendLayout()
        Me.PNL_CODE_SECTION.SuspendLayout()
        Me.PNL_DEPOSIT_INPUT_AREA.SuspendLayout()
        Me.PNL_FLAG_SALE.SuspendLayout()
        Me.PNL_SERIAL_DEPOSIT.SuspendLayout()
        Me.PNL_FLAG_DEPOSIT_SUB.SuspendLayout()
        Me.PNL_NAME_MEMO.SuspendLayout()
        Me.PNL_KINGAKU_COST.SuspendLayout()
        Me.PNL_FLAG_COST.SuspendLayout()
        Me.PNL_KINGAKU_FEE.SuspendLayout()
        Me.PNL_FLAG_DEPOSIT.SuspendLayout()
        Me.PNL_DATE_DEPOSIT.SuspendLayout()
        Me.PNL_FLAG_DEPOSIT_DONE.SuspendLayout()
        Me.PNL_KINGAKU_INVOICE.SuspendLayout()
        Me.PNL_INPUT_KEY.SuspendLayout()
        Me.PNL_DATE_INVOICE.SuspendLayout()
        Me.PNL_KINGAKU_CONTRACT.SuspendLayout()
        Me.PNL_NAME_CONTRACT.SuspendLayout()
        Me.PNL_CODE_SHINTO_PARENT.SuspendLayout()
        Me.PNL_NUMBER_CONTRACT.SuspendLayout()
        Me.GRP_FOOT.SuspendLayout()
        Me.pnlFUNCTION_GROUP.SuspendLayout()
        Me.PNL_FLAG_OUTPUT.SuspendLayout()
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
        Me.PNL_INPUT_DATA.Controls.Add(Me.PNL_CODE_SECTION)
        Me.PNL_INPUT_DATA.Controls.Add(Me.PNL_DEPOSIT_INPUT_AREA)
        Me.PNL_INPUT_DATA.Controls.Add(Me.PNL_FLAG_DEPOSIT_DONE)
        Me.PNL_INPUT_DATA.Controls.Add(Me.PNL_KINGAKU_INVOICE)
        Me.PNL_INPUT_DATA.Location = New System.Drawing.Point(10, 100)
        Me.PNL_INPUT_DATA.Name = "PNL_INPUT_DATA"
        Me.PNL_INPUT_DATA.Size = New System.Drawing.Size(740, 302)
        Me.PNL_INPUT_DATA.TabIndex = 1
        '
        'PNL_CODE_SECTION
        '
        Me.PNL_CODE_SECTION.Controls.Add(Me.CMB_CODE_SECTION)
        Me.PNL_CODE_SECTION.Controls.Add(Me.LBL_CODE_SECTION_GUIDE)
        Me.PNL_CODE_SECTION.Location = New System.Drawing.Point(495, 5)
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
        'PNL_DEPOSIT_INPUT_AREA
        '
        Me.PNL_DEPOSIT_INPUT_AREA.Controls.Add(Me.PNL_FLAG_OUTPUT)
        Me.PNL_DEPOSIT_INPUT_AREA.Controls.Add(Me.PNL_FLAG_SALE)
        Me.PNL_DEPOSIT_INPUT_AREA.Controls.Add(Me.PNL_SERIAL_DEPOSIT)
        Me.PNL_DEPOSIT_INPUT_AREA.Controls.Add(Me.PNL_FLAG_DEPOSIT_SUB)
        Me.PNL_DEPOSIT_INPUT_AREA.Controls.Add(Me.PNL_NAME_MEMO)
        Me.PNL_DEPOSIT_INPUT_AREA.Controls.Add(Me.PNL_KINGAKU_COST)
        Me.PNL_DEPOSIT_INPUT_AREA.Controls.Add(Me.PNL_FLAG_COST)
        Me.PNL_DEPOSIT_INPUT_AREA.Controls.Add(Me.PNL_KINGAKU_FEE)
        Me.PNL_DEPOSIT_INPUT_AREA.Controls.Add(Me.PNL_FLAG_DEPOSIT)
        Me.PNL_DEPOSIT_INPUT_AREA.Controls.Add(Me.PNL_DATE_DEPOSIT)
        Me.PNL_DEPOSIT_INPUT_AREA.Location = New System.Drawing.Point(0, 70)
        Me.PNL_DEPOSIT_INPUT_AREA.Name = "PNL_DEPOSIT_INPUT_AREA"
        Me.PNL_DEPOSIT_INPUT_AREA.Size = New System.Drawing.Size(740, 215)
        Me.PNL_DEPOSIT_INPUT_AREA.TabIndex = 3
        '
        'PNL_FLAG_SALE
        '
        Me.PNL_FLAG_SALE.Controls.Add(Me.CMB_FLAG_SALE)
        Me.PNL_FLAG_SALE.Controls.Add(Me.LBL_FLAG_SALE_GUIDE)
        Me.PNL_FLAG_SALE.Location = New System.Drawing.Point(5, 40)
        Me.PNL_FLAG_SALE.Name = "PNL_FLAG_SALE"
        Me.PNL_FLAG_SALE.Size = New System.Drawing.Size(240, 30)
        Me.PNL_FLAG_SALE.TabIndex = 2
        '
        'CMB_FLAG_SALE
        '
        Me.CMB_FLAG_SALE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_FLAG_SALE.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CMB_FLAG_SALE.Location = New System.Drawing.Point(80, 1)
        Me.CMB_FLAG_SALE.Name = "CMB_FLAG_SALE"
        Me.CMB_FLAG_SALE.Size = New System.Drawing.Size(150, 26)
        Me.CMB_FLAG_SALE.TabIndex = 1
        Me.CMB_FLAG_SALE.Tag = "Clear"
        '
        'LBL_FLAG_SALE_GUIDE
        '
        Me.LBL_FLAG_SALE_GUIDE.AutoEllipsis = True
        Me.LBL_FLAG_SALE_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_FLAG_SALE_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_FLAG_SALE_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_FLAG_SALE_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_FLAG_SALE_GUIDE.Name = "LBL_FLAG_SALE_GUIDE"
        Me.LBL_FLAG_SALE_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_FLAG_SALE_GUIDE.TabIndex = 0
        Me.LBL_FLAG_SALE_GUIDE.Text = "売掛種別"
        Me.LBL_FLAG_SALE_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PNL_SERIAL_DEPOSIT
        '
        Me.PNL_SERIAL_DEPOSIT.Controls.Add(Me.LBL_SERIAL_DEPOSIT)
        Me.PNL_SERIAL_DEPOSIT.Controls.Add(Me.LBL_SERIAL_DEPOSIT_GUIDE)
        Me.PNL_SERIAL_DEPOSIT.Location = New System.Drawing.Point(250, 5)
        Me.PNL_SERIAL_DEPOSIT.Name = "PNL_SERIAL_DEPOSIT"
        Me.PNL_SERIAL_DEPOSIT.Size = New System.Drawing.Size(240, 30)
        Me.PNL_SERIAL_DEPOSIT.TabIndex = 1
        '
        'LBL_SERIAL_DEPOSIT
        '
        Me.LBL_SERIAL_DEPOSIT.AutoEllipsis = True
        Me.LBL_SERIAL_DEPOSIT.BackColor = System.Drawing.Color.White
        Me.LBL_SERIAL_DEPOSIT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_SERIAL_DEPOSIT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBL_SERIAL_DEPOSIT.Location = New System.Drawing.Point(80, 1)
        Me.LBL_SERIAL_DEPOSIT.Name = "LBL_SERIAL_DEPOSIT"
        Me.LBL_SERIAL_DEPOSIT.Size = New System.Drawing.Size(60, 25)
        Me.LBL_SERIAL_DEPOSIT.TabIndex = 10
        Me.LBL_SERIAL_DEPOSIT.Tag = "Clear"
        Me.LBL_SERIAL_DEPOSIT.Text = "＊＊＊"
        Me.LBL_SERIAL_DEPOSIT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LBL_SERIAL_DEPOSIT_GUIDE
        '
        Me.LBL_SERIAL_DEPOSIT_GUIDE.AutoEllipsis = True
        Me.LBL_SERIAL_DEPOSIT_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_SERIAL_DEPOSIT_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_SERIAL_DEPOSIT_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_SERIAL_DEPOSIT_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_SERIAL_DEPOSIT_GUIDE.Name = "LBL_SERIAL_DEPOSIT_GUIDE"
        Me.LBL_SERIAL_DEPOSIT_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_SERIAL_DEPOSIT_GUIDE.TabIndex = 3
        Me.LBL_SERIAL_DEPOSIT_GUIDE.Text = "入金連番"
        Me.LBL_SERIAL_DEPOSIT_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PNL_FLAG_DEPOSIT_SUB
        '
        Me.PNL_FLAG_DEPOSIT_SUB.Controls.Add(Me.CMB_FLAG_DEPOSIT_SUB)
        Me.PNL_FLAG_DEPOSIT_SUB.Controls.Add(Me.LBL_FLAG_DEPOSIT_SUB_GUIDE)
        Me.PNL_FLAG_DEPOSIT_SUB.Location = New System.Drawing.Point(495, 40)
        Me.PNL_FLAG_DEPOSIT_SUB.Name = "PNL_FLAG_DEPOSIT_SUB"
        Me.PNL_FLAG_DEPOSIT_SUB.Size = New System.Drawing.Size(240, 30)
        Me.PNL_FLAG_DEPOSIT_SUB.TabIndex = 4
        '
        'CMB_FLAG_DEPOSIT_SUB
        '
        Me.CMB_FLAG_DEPOSIT_SUB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_FLAG_DEPOSIT_SUB.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CMB_FLAG_DEPOSIT_SUB.Location = New System.Drawing.Point(80, 1)
        Me.CMB_FLAG_DEPOSIT_SUB.Name = "CMB_FLAG_DEPOSIT_SUB"
        Me.CMB_FLAG_DEPOSIT_SUB.Size = New System.Drawing.Size(150, 26)
        Me.CMB_FLAG_DEPOSIT_SUB.TabIndex = 1
        Me.CMB_FLAG_DEPOSIT_SUB.Tag = "Clear"
        '
        'LBL_FLAG_DEPOSIT_SUB_GUIDE
        '
        Me.LBL_FLAG_DEPOSIT_SUB_GUIDE.AutoEllipsis = True
        Me.LBL_FLAG_DEPOSIT_SUB_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_FLAG_DEPOSIT_SUB_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_FLAG_DEPOSIT_SUB_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_FLAG_DEPOSIT_SUB_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_FLAG_DEPOSIT_SUB_GUIDE.Name = "LBL_FLAG_DEPOSIT_SUB_GUIDE"
        Me.LBL_FLAG_DEPOSIT_SUB_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_FLAG_DEPOSIT_SUB_GUIDE.TabIndex = 0
        Me.LBL_FLAG_DEPOSIT_SUB_GUIDE.Text = "振込先"
        Me.LBL_FLAG_DEPOSIT_SUB_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PNL_NAME_MEMO
        '
        Me.PNL_NAME_MEMO.Controls.Add(Me.TXT_NAME_MEMO)
        Me.PNL_NAME_MEMO.Controls.Add(Me.LBL_NAME_MEMO_GUIDE)
        Me.PNL_NAME_MEMO.Location = New System.Drawing.Point(5, 180)
        Me.PNL_NAME_MEMO.Name = "PNL_NAME_MEMO"
        Me.PNL_NAME_MEMO.Size = New System.Drawing.Size(485, 30)
        Me.PNL_NAME_MEMO.TabIndex = 8
        '
        'TXT_NAME_MEMO
        '
        Me.TXT_NAME_MEMO.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.TXT_NAME_MEMO.Location = New System.Drawing.Point(80, 1)
        Me.TXT_NAME_MEMO.MaxLength = 20
        Me.TXT_NAME_MEMO.Name = "TXT_NAME_MEMO"
        Me.TXT_NAME_MEMO.Size = New System.Drawing.Size(395, 25)
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
        'PNL_KINGAKU_COST
        '
        Me.PNL_KINGAKU_COST.Controls.Add(Me.LBL_KINGAKU_COST_TOTAL)
        Me.PNL_KINGAKU_COST.Controls.Add(Me.TXT_KINGAKU_COST_VAT)
        Me.PNL_KINGAKU_COST.Controls.Add(Me.LBL_KINGAKU_COST_GUIDE)
        Me.PNL_KINGAKU_COST.Controls.Add(Me.TXT_KINGAKU_COST_DETAIL)
        Me.PNL_KINGAKU_COST.Location = New System.Drawing.Point(5, 145)
        Me.PNL_KINGAKU_COST.Name = "PNL_KINGAKU_COST"
        Me.PNL_KINGAKU_COST.Size = New System.Drawing.Size(485, 30)
        Me.PNL_KINGAKU_COST.TabIndex = 7
        '
        'LBL_KINGAKU_COST_TOTAL
        '
        Me.LBL_KINGAKU_COST_TOTAL.AutoEllipsis = True
        Me.LBL_KINGAKU_COST_TOTAL.BackColor = System.Drawing.Color.White
        Me.LBL_KINGAKU_COST_TOTAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_KINGAKU_COST_TOTAL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBL_KINGAKU_COST_TOTAL.Location = New System.Drawing.Point(325, 1)
        Me.LBL_KINGAKU_COST_TOTAL.Name = "LBL_KINGAKU_COST_TOTAL"
        Me.LBL_KINGAKU_COST_TOTAL.Size = New System.Drawing.Size(150, 25)
        Me.LBL_KINGAKU_COST_TOTAL.TabIndex = 5
        Me.LBL_KINGAKU_COST_TOTAL.Tag = "Clear"
        Me.LBL_KINGAKU_COST_TOTAL.Text = "＊＊＊"
        Me.LBL_KINGAKU_COST_TOTAL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXT_KINGAKU_COST_VAT
        '
        Me.TXT_KINGAKU_COST_VAT.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TXT_KINGAKU_COST_VAT.Location = New System.Drawing.Point(230, 1)
        Me.TXT_KINGAKU_COST_VAT.MaxLength = 12
        Me.TXT_KINGAKU_COST_VAT.Name = "TXT_KINGAKU_COST_VAT"
        Me.TXT_KINGAKU_COST_VAT.Size = New System.Drawing.Size(95, 25)
        Me.TXT_KINGAKU_COST_VAT.TabIndex = 4
        Me.TXT_KINGAKU_COST_VAT.Tag = "Clear,Numeric,Format=#@##0,Check,NotNull,Plus"
        Me.TXT_KINGAKU_COST_VAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LBL_KINGAKU_COST_GUIDE
        '
        Me.LBL_KINGAKU_COST_GUIDE.AutoEllipsis = True
        Me.LBL_KINGAKU_COST_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_KINGAKU_COST_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_KINGAKU_COST_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_KINGAKU_COST_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_KINGAKU_COST_GUIDE.Name = "LBL_KINGAKU_COST_GUIDE"
        Me.LBL_KINGAKU_COST_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_KINGAKU_COST_GUIDE.TabIndex = 3
        Me.LBL_KINGAKU_COST_GUIDE.Text = "費用金額"
        Me.LBL_KINGAKU_COST_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXT_KINGAKU_COST_DETAIL
        '
        Me.TXT_KINGAKU_COST_DETAIL.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TXT_KINGAKU_COST_DETAIL.Location = New System.Drawing.Point(80, 1)
        Me.TXT_KINGAKU_COST_DETAIL.MaxLength = 12
        Me.TXT_KINGAKU_COST_DETAIL.Name = "TXT_KINGAKU_COST_DETAIL"
        Me.TXT_KINGAKU_COST_DETAIL.Size = New System.Drawing.Size(150, 25)
        Me.TXT_KINGAKU_COST_DETAIL.TabIndex = 1
        Me.TXT_KINGAKU_COST_DETAIL.Tag = "Clear,Numeric,Format=#@##0,Check,NotNull,Plus"
        Me.TXT_KINGAKU_COST_DETAIL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PNL_FLAG_COST
        '
        Me.PNL_FLAG_COST.Controls.Add(Me.CMB_FLAG_COST)
        Me.PNL_FLAG_COST.Controls.Add(Me.LBL_FLAG_COST_GUIDE)
        Me.PNL_FLAG_COST.Location = New System.Drawing.Point(5, 110)
        Me.PNL_FLAG_COST.Name = "PNL_FLAG_COST"
        Me.PNL_FLAG_COST.Size = New System.Drawing.Size(240, 30)
        Me.PNL_FLAG_COST.TabIndex = 6
        '
        'CMB_FLAG_COST
        '
        Me.CMB_FLAG_COST.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_FLAG_COST.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CMB_FLAG_COST.Location = New System.Drawing.Point(80, 1)
        Me.CMB_FLAG_COST.Name = "CMB_FLAG_COST"
        Me.CMB_FLAG_COST.Size = New System.Drawing.Size(150, 26)
        Me.CMB_FLAG_COST.TabIndex = 1
        Me.CMB_FLAG_COST.Tag = "Clear"
        '
        'LBL_FLAG_COST_GUIDE
        '
        Me.LBL_FLAG_COST_GUIDE.AutoEllipsis = True
        Me.LBL_FLAG_COST_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_FLAG_COST_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_FLAG_COST_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_FLAG_COST_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_FLAG_COST_GUIDE.Name = "LBL_FLAG_COST_GUIDE"
        Me.LBL_FLAG_COST_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_FLAG_COST_GUIDE.TabIndex = 0
        Me.LBL_FLAG_COST_GUIDE.Text = "費用科目"
        Me.LBL_FLAG_COST_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PNL_KINGAKU_FEE
        '
        Me.PNL_KINGAKU_FEE.Controls.Add(Me.CMB_KINGAKU_FEE_DETAIL)
        Me.PNL_KINGAKU_FEE.Controls.Add(Me.LBL_KINGAKU_FEE_TOTAL)
        Me.PNL_KINGAKU_FEE.Controls.Add(Me.TXT_KINGAKU_FEE_VAT)
        Me.PNL_KINGAKU_FEE.Controls.Add(Me.LBL_KINGAKU_FEE_GUIDE)
        Me.PNL_KINGAKU_FEE.Location = New System.Drawing.Point(5, 75)
        Me.PNL_KINGAKU_FEE.Name = "PNL_KINGAKU_FEE"
        Me.PNL_KINGAKU_FEE.Size = New System.Drawing.Size(485, 30)
        Me.PNL_KINGAKU_FEE.TabIndex = 5
        '
        'CMB_KINGAKU_FEE_DETAIL
        '
        Me.CMB_KINGAKU_FEE_DETAIL.FormattingEnabled = True
        Me.CMB_KINGAKU_FEE_DETAIL.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.CMB_KINGAKU_FEE_DETAIL.Items.AddRange(New Object() {"0", "200", "300", "400", "500", "600", "700"})
        Me.CMB_KINGAKU_FEE_DETAIL.Location = New System.Drawing.Point(80, 1)
        Me.CMB_KINGAKU_FEE_DETAIL.Name = "CMB_KINGAKU_FEE_DETAIL"
        Me.CMB_KINGAKU_FEE_DETAIL.Size = New System.Drawing.Size(150, 26)
        Me.CMB_KINGAKU_FEE_DETAIL.TabIndex = 0
        Me.CMB_KINGAKU_FEE_DETAIL.Tag = "Clear,Numeric,Format=#@##0,Check,NotNull,Plus"
        '
        'LBL_KINGAKU_FEE_TOTAL
        '
        Me.LBL_KINGAKU_FEE_TOTAL.AutoEllipsis = True
        Me.LBL_KINGAKU_FEE_TOTAL.BackColor = System.Drawing.Color.White
        Me.LBL_KINGAKU_FEE_TOTAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_KINGAKU_FEE_TOTAL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBL_KINGAKU_FEE_TOTAL.Location = New System.Drawing.Point(325, 1)
        Me.LBL_KINGAKU_FEE_TOTAL.Name = "LBL_KINGAKU_FEE_TOTAL"
        Me.LBL_KINGAKU_FEE_TOTAL.Size = New System.Drawing.Size(150, 25)
        Me.LBL_KINGAKU_FEE_TOTAL.TabIndex = 2
        Me.LBL_KINGAKU_FEE_TOTAL.Tag = "Clear"
        Me.LBL_KINGAKU_FEE_TOTAL.Text = "＊＊＊"
        Me.LBL_KINGAKU_FEE_TOTAL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXT_KINGAKU_FEE_VAT
        '
        Me.TXT_KINGAKU_FEE_VAT.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TXT_KINGAKU_FEE_VAT.Location = New System.Drawing.Point(230, 1)
        Me.TXT_KINGAKU_FEE_VAT.MaxLength = 12
        Me.TXT_KINGAKU_FEE_VAT.Name = "TXT_KINGAKU_FEE_VAT"
        Me.TXT_KINGAKU_FEE_VAT.Size = New System.Drawing.Size(95, 25)
        Me.TXT_KINGAKU_FEE_VAT.TabIndex = 1
        Me.TXT_KINGAKU_FEE_VAT.Tag = "Clear,Numeric,Format=#@##0,Check,NotNull,Plus"
        Me.TXT_KINGAKU_FEE_VAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LBL_KINGAKU_FEE_GUIDE
        '
        Me.LBL_KINGAKU_FEE_GUIDE.AutoEllipsis = True
        Me.LBL_KINGAKU_FEE_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_KINGAKU_FEE_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_KINGAKU_FEE_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_KINGAKU_FEE_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_KINGAKU_FEE_GUIDE.Name = "LBL_KINGAKU_FEE_GUIDE"
        Me.LBL_KINGAKU_FEE_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_KINGAKU_FEE_GUIDE.TabIndex = 3
        Me.LBL_KINGAKU_FEE_GUIDE.Text = "振込手数料"
        Me.LBL_KINGAKU_FEE_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PNL_FLAG_DEPOSIT
        '
        Me.PNL_FLAG_DEPOSIT.Controls.Add(Me.CMB_FLAG_DEPOSIT)
        Me.PNL_FLAG_DEPOSIT.Controls.Add(Me.LBL_FLAG_DEPOSIT_GUIDE)
        Me.PNL_FLAG_DEPOSIT.Location = New System.Drawing.Point(250, 40)
        Me.PNL_FLAG_DEPOSIT.Name = "PNL_FLAG_DEPOSIT"
        Me.PNL_FLAG_DEPOSIT.Size = New System.Drawing.Size(240, 30)
        Me.PNL_FLAG_DEPOSIT.TabIndex = 3
        '
        'CMB_FLAG_DEPOSIT
        '
        Me.CMB_FLAG_DEPOSIT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_FLAG_DEPOSIT.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CMB_FLAG_DEPOSIT.Location = New System.Drawing.Point(80, 1)
        Me.CMB_FLAG_DEPOSIT.Name = "CMB_FLAG_DEPOSIT"
        Me.CMB_FLAG_DEPOSIT.Size = New System.Drawing.Size(150, 26)
        Me.CMB_FLAG_DEPOSIT.TabIndex = 1
        Me.CMB_FLAG_DEPOSIT.Tag = "Clear"
        '
        'LBL_FLAG_DEPOSIT_GUIDE
        '
        Me.LBL_FLAG_DEPOSIT_GUIDE.AutoEllipsis = True
        Me.LBL_FLAG_DEPOSIT_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_FLAG_DEPOSIT_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_FLAG_DEPOSIT_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_FLAG_DEPOSIT_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_FLAG_DEPOSIT_GUIDE.Name = "LBL_FLAG_DEPOSIT_GUIDE"
        Me.LBL_FLAG_DEPOSIT_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_FLAG_DEPOSIT_GUIDE.TabIndex = 0
        Me.LBL_FLAG_DEPOSIT_GUIDE.Text = "入金種別"
        Me.LBL_FLAG_DEPOSIT_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PNL_DATE_DEPOSIT
        '
        Me.PNL_DATE_DEPOSIT.Controls.Add(Me.DTP_DATE_DEPOSIT)
        Me.PNL_DATE_DEPOSIT.Controls.Add(Me.LBL_DATE_DEPOSIT_GUIDE)
        Me.PNL_DATE_DEPOSIT.Location = New System.Drawing.Point(5, 5)
        Me.PNL_DATE_DEPOSIT.Name = "PNL_DATE_DEPOSIT"
        Me.PNL_DATE_DEPOSIT.Size = New System.Drawing.Size(240, 30)
        Me.PNL_DATE_DEPOSIT.TabIndex = 0
        '
        'DTP_DATE_DEPOSIT
        '
        Me.DTP_DATE_DEPOSIT.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.DTP_DATE_DEPOSIT.Location = New System.Drawing.Point(80, 1)
        Me.DTP_DATE_DEPOSIT.Name = "DTP_DATE_DEPOSIT"
        Me.DTP_DATE_DEPOSIT.Size = New System.Drawing.Size(150, 25)
        Me.DTP_DATE_DEPOSIT.TabIndex = 1
        Me.DTP_DATE_DEPOSIT.Tag = "Clear"
        '
        'LBL_DATE_DEPOSIT_GUIDE
        '
        Me.LBL_DATE_DEPOSIT_GUIDE.AutoEllipsis = True
        Me.LBL_DATE_DEPOSIT_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_DATE_DEPOSIT_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_DATE_DEPOSIT_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_DATE_DEPOSIT_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_DATE_DEPOSIT_GUIDE.Name = "LBL_DATE_DEPOSIT_GUIDE"
        Me.LBL_DATE_DEPOSIT_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_DATE_DEPOSIT_GUIDE.TabIndex = 0
        Me.LBL_DATE_DEPOSIT_GUIDE.Text = "入金日"
        Me.LBL_DATE_DEPOSIT_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PNL_FLAG_DEPOSIT_DONE
        '
        Me.PNL_FLAG_DEPOSIT_DONE.Controls.Add(Me.CHK_FLAG_DEPOSIT_DONE)
        Me.PNL_FLAG_DEPOSIT_DONE.Controls.Add(Me.LBL_FLAG_DEPOSIT_DONE_GUIDE)
        Me.PNL_FLAG_DEPOSIT_DONE.Controls.Add(Me.LBL_FLAG_DEPOSIT_DONE_BACK)
        Me.PNL_FLAG_DEPOSIT_DONE.Location = New System.Drawing.Point(5, 40)
        Me.PNL_FLAG_DEPOSIT_DONE.Name = "PNL_FLAG_DEPOSIT_DONE"
        Me.PNL_FLAG_DEPOSIT_DONE.Size = New System.Drawing.Size(240, 30)
        Me.PNL_FLAG_DEPOSIT_DONE.TabIndex = 2
        '
        'CHK_FLAG_DEPOSIT_DONE
        '
        Me.CHK_FLAG_DEPOSIT_DONE.AutoSize = True
        Me.CHK_FLAG_DEPOSIT_DONE.Location = New System.Drawing.Point(86, 7)
        Me.CHK_FLAG_DEPOSIT_DONE.Name = "CHK_FLAG_DEPOSIT_DONE"
        Me.CHK_FLAG_DEPOSIT_DONE.Size = New System.Drawing.Size(15, 14)
        Me.CHK_FLAG_DEPOSIT_DONE.TabIndex = 11
        Me.CHK_FLAG_DEPOSIT_DONE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CHK_FLAG_DEPOSIT_DONE.UseVisualStyleBackColor = False
        '
        'LBL_FLAG_DEPOSIT_DONE_GUIDE
        '
        Me.LBL_FLAG_DEPOSIT_DONE_GUIDE.AutoEllipsis = True
        Me.LBL_FLAG_DEPOSIT_DONE_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_FLAG_DEPOSIT_DONE_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_FLAG_DEPOSIT_DONE_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_FLAG_DEPOSIT_DONE_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_FLAG_DEPOSIT_DONE_GUIDE.Name = "LBL_FLAG_DEPOSIT_DONE_GUIDE"
        Me.LBL_FLAG_DEPOSIT_DONE_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_FLAG_DEPOSIT_DONE_GUIDE.TabIndex = 3
        Me.LBL_FLAG_DEPOSIT_DONE_GUIDE.Text = "入金済み"
        Me.LBL_FLAG_DEPOSIT_DONE_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LBL_FLAG_DEPOSIT_DONE_BACK
        '
        Me.LBL_FLAG_DEPOSIT_DONE_BACK.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.LBL_FLAG_DEPOSIT_DONE_BACK.Location = New System.Drawing.Point(80, 1)
        Me.LBL_FLAG_DEPOSIT_DONE_BACK.Name = "LBL_FLAG_DEPOSIT_DONE_BACK"
        Me.LBL_FLAG_DEPOSIT_DONE_BACK.Size = New System.Drawing.Size(24, 24)
        Me.LBL_FLAG_DEPOSIT_DONE_BACK.TabIndex = 12
        Me.LBL_FLAG_DEPOSIT_DONE_BACK.Visible = False
        '
        'PNL_KINGAKU_INVOICE
        '
        Me.PNL_KINGAKU_INVOICE.Controls.Add(Me.LBL_KINGAKU_INVOICE_TOTAL)
        Me.PNL_KINGAKU_INVOICE.Controls.Add(Me.TXT_KINGAKU_INVOICE_VAT)
        Me.PNL_KINGAKU_INVOICE.Controls.Add(Me.LBL_KINGAKU_INVOICE_GUIDE)
        Me.PNL_KINGAKU_INVOICE.Controls.Add(Me.TXT_KINGAKU_INVOICE_DETAIL)
        Me.PNL_KINGAKU_INVOICE.Location = New System.Drawing.Point(5, 5)
        Me.PNL_KINGAKU_INVOICE.Name = "PNL_KINGAKU_INVOICE"
        Me.PNL_KINGAKU_INVOICE.Size = New System.Drawing.Size(485, 30)
        Me.PNL_KINGAKU_INVOICE.TabIndex = 0
        '
        'LBL_KINGAKU_INVOICE_TOTAL
        '
        Me.LBL_KINGAKU_INVOICE_TOTAL.AutoEllipsis = True
        Me.LBL_KINGAKU_INVOICE_TOTAL.BackColor = System.Drawing.Color.White
        Me.LBL_KINGAKU_INVOICE_TOTAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_KINGAKU_INVOICE_TOTAL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBL_KINGAKU_INVOICE_TOTAL.Location = New System.Drawing.Point(325, 1)
        Me.LBL_KINGAKU_INVOICE_TOTAL.Name = "LBL_KINGAKU_INVOICE_TOTAL"
        Me.LBL_KINGAKU_INVOICE_TOTAL.Size = New System.Drawing.Size(150, 25)
        Me.LBL_KINGAKU_INVOICE_TOTAL.TabIndex = 5
        Me.LBL_KINGAKU_INVOICE_TOTAL.Tag = "Clear"
        Me.LBL_KINGAKU_INVOICE_TOTAL.Text = "＊＊＊"
        Me.LBL_KINGAKU_INVOICE_TOTAL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXT_KINGAKU_INVOICE_VAT
        '
        Me.TXT_KINGAKU_INVOICE_VAT.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TXT_KINGAKU_INVOICE_VAT.Location = New System.Drawing.Point(250, 1)
        Me.TXT_KINGAKU_INVOICE_VAT.MaxLength = 12
        Me.TXT_KINGAKU_INVOICE_VAT.Name = "TXT_KINGAKU_INVOICE_VAT"
        Me.TXT_KINGAKU_INVOICE_VAT.Size = New System.Drawing.Size(75, 25)
        Me.TXT_KINGAKU_INVOICE_VAT.TabIndex = 4
        Me.TXT_KINGAKU_INVOICE_VAT.Tag = "Clear,Numeric,Format=#@##0,Check,NotNull,Plus"
        Me.TXT_KINGAKU_INVOICE_VAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LBL_KINGAKU_INVOICE_GUIDE
        '
        Me.LBL_KINGAKU_INVOICE_GUIDE.AutoEllipsis = True
        Me.LBL_KINGAKU_INVOICE_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_KINGAKU_INVOICE_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_KINGAKU_INVOICE_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_KINGAKU_INVOICE_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_KINGAKU_INVOICE_GUIDE.Name = "LBL_KINGAKU_INVOICE_GUIDE"
        Me.LBL_KINGAKU_INVOICE_GUIDE.Size = New System.Drawing.Size(99, 25)
        Me.LBL_KINGAKU_INVOICE_GUIDE.TabIndex = 3
        Me.LBL_KINGAKU_INVOICE_GUIDE.Text = "請求(入金)金額"
        Me.LBL_KINGAKU_INVOICE_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXT_KINGAKU_INVOICE_DETAIL
        '
        Me.TXT_KINGAKU_INVOICE_DETAIL.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TXT_KINGAKU_INVOICE_DETAIL.Location = New System.Drawing.Point(100, 1)
        Me.TXT_KINGAKU_INVOICE_DETAIL.MaxLength = 12
        Me.TXT_KINGAKU_INVOICE_DETAIL.Name = "TXT_KINGAKU_INVOICE_DETAIL"
        Me.TXT_KINGAKU_INVOICE_DETAIL.Size = New System.Drawing.Size(150, 25)
        Me.TXT_KINGAKU_INVOICE_DETAIL.TabIndex = 1
        Me.TXT_KINGAKU_INVOICE_DETAIL.Tag = "Clear,Numeric,Format=#@##0,Check,NotNull,Plus"
        Me.TXT_KINGAKU_INVOICE_DETAIL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PNL_INPUT_KEY
        '
        Me.PNL_INPUT_KEY.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PNL_INPUT_KEY.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.PNL_INPUT_KEY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PNL_INPUT_KEY.Controls.Add(Me.PNL_DATE_INVOICE)
        Me.PNL_INPUT_KEY.Controls.Add(Me.PNL_KINGAKU_CONTRACT)
        Me.PNL_INPUT_KEY.Controls.Add(Me.PNL_NAME_CONTRACT)
        Me.PNL_INPUT_KEY.Controls.Add(Me.PNL_CODE_SHINTO_PARENT)
        Me.PNL_INPUT_KEY.Controls.Add(Me.PNL_NUMBER_CONTRACT)
        Me.PNL_INPUT_KEY.Location = New System.Drawing.Point(10, 20)
        Me.PNL_INPUT_KEY.Name = "PNL_INPUT_KEY"
        Me.PNL_INPUT_KEY.Size = New System.Drawing.Size(740, 80)
        Me.PNL_INPUT_KEY.TabIndex = 0
        '
        'PNL_DATE_INVOICE
        '
        Me.PNL_DATE_INVOICE.Controls.Add(Me.LBL_DATE_INVOICE)
        Me.PNL_DATE_INVOICE.Controls.Add(Me.LBL_DATE_INVOICE_GUIDE)
        Me.PNL_DATE_INVOICE.Location = New System.Drawing.Point(250, 40)
        Me.PNL_DATE_INVOICE.Name = "PNL_DATE_INVOICE"
        Me.PNL_DATE_INVOICE.Size = New System.Drawing.Size(240, 30)
        Me.PNL_DATE_INVOICE.TabIndex = 5
        '
        'LBL_DATE_INVOICE
        '
        Me.LBL_DATE_INVOICE.AutoEllipsis = True
        Me.LBL_DATE_INVOICE.BackColor = System.Drawing.Color.White
        Me.LBL_DATE_INVOICE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_DATE_INVOICE.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBL_DATE_INVOICE.Location = New System.Drawing.Point(80, 1)
        Me.LBL_DATE_INVOICE.Name = "LBL_DATE_INVOICE"
        Me.LBL_DATE_INVOICE.Size = New System.Drawing.Size(150, 25)
        Me.LBL_DATE_INVOICE.TabIndex = 4
        Me.LBL_DATE_INVOICE.Tag = "Clear"
        Me.LBL_DATE_INVOICE.Text = "＊＊＊"
        Me.LBL_DATE_INVOICE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LBL_DATE_INVOICE_GUIDE
        '
        Me.LBL_DATE_INVOICE_GUIDE.AutoEllipsis = True
        Me.LBL_DATE_INVOICE_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_DATE_INVOICE_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_DATE_INVOICE_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_DATE_INVOICE_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_DATE_INVOICE_GUIDE.Name = "LBL_DATE_INVOICE_GUIDE"
        Me.LBL_DATE_INVOICE_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_DATE_INVOICE_GUIDE.TabIndex = 0
        Me.LBL_DATE_INVOICE_GUIDE.Text = "請求日"
        Me.LBL_DATE_INVOICE_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PNL_KINGAKU_CONTRACT
        '
        Me.PNL_KINGAKU_CONTRACT.Controls.Add(Me.LBL_KINGAKU_CONTRACT)
        Me.PNL_KINGAKU_CONTRACT.Controls.Add(Me.LBL_KINGAKU_CONTRACT_GUIDE)
        Me.PNL_KINGAKU_CONTRACT.Location = New System.Drawing.Point(495, 40)
        Me.PNL_KINGAKU_CONTRACT.Name = "PNL_KINGAKU_CONTRACT"
        Me.PNL_KINGAKU_CONTRACT.Size = New System.Drawing.Size(240, 30)
        Me.PNL_KINGAKU_CONTRACT.TabIndex = 4
        '
        'LBL_KINGAKU_CONTRACT
        '
        Me.LBL_KINGAKU_CONTRACT.AutoEllipsis = True
        Me.LBL_KINGAKU_CONTRACT.BackColor = System.Drawing.Color.White
        Me.LBL_KINGAKU_CONTRACT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_KINGAKU_CONTRACT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBL_KINGAKU_CONTRACT.Location = New System.Drawing.Point(80, 1)
        Me.LBL_KINGAKU_CONTRACT.Name = "LBL_KINGAKU_CONTRACT"
        Me.LBL_KINGAKU_CONTRACT.Size = New System.Drawing.Size(150, 25)
        Me.LBL_KINGAKU_CONTRACT.TabIndex = 4
        Me.LBL_KINGAKU_CONTRACT.Tag = "Clear"
        Me.LBL_KINGAKU_CONTRACT.Text = "＊＊＊"
        Me.LBL_KINGAKU_CONTRACT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.LBL_KINGAKU_CONTRACT_GUIDE.TabIndex = 0
        Me.LBL_KINGAKU_CONTRACT_GUIDE.Text = "契約金額"
        Me.LBL_KINGAKU_CONTRACT_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PNL_NAME_CONTRACT
        '
        Me.PNL_NAME_CONTRACT.Controls.Add(Me.LBL_NAME_CONTRACT)
        Me.PNL_NAME_CONTRACT.Controls.Add(Me.LBL_NAME_CONTRACT_GUIDE)
        Me.PNL_NAME_CONTRACT.Location = New System.Drawing.Point(370, 5)
        Me.PNL_NAME_CONTRACT.Name = "PNL_NAME_CONTRACT"
        Me.PNL_NAME_CONTRACT.Size = New System.Drawing.Size(365, 30)
        Me.PNL_NAME_CONTRACT.TabIndex = 3
        '
        'LBL_NAME_CONTRACT
        '
        Me.LBL_NAME_CONTRACT.AutoEllipsis = True
        Me.LBL_NAME_CONTRACT.BackColor = System.Drawing.Color.White
        Me.LBL_NAME_CONTRACT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_NAME_CONTRACT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBL_NAME_CONTRACT.Location = New System.Drawing.Point(80, 1)
        Me.LBL_NAME_CONTRACT.Name = "LBL_NAME_CONTRACT"
        Me.LBL_NAME_CONTRACT.Size = New System.Drawing.Size(275, 25)
        Me.LBL_NAME_CONTRACT.TabIndex = 4
        Me.LBL_NAME_CONTRACT.Tag = "Clear"
        Me.LBL_NAME_CONTRACT.Text = "＊＊＊"
        Me.LBL_NAME_CONTRACT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'PNL_CODE_SHINTO_PARENT
        '
        Me.PNL_CODE_SHINTO_PARENT.Controls.Add(Me.LBL_CODE_OWNER)
        Me.PNL_CODE_SHINTO_PARENT.Controls.Add(Me.LBL_CODE_OWNER_GUIDE)
        Me.PNL_CODE_SHINTO_PARENT.Controls.Add(Me.LBL_CODE_OWNER_NAME)
        Me.PNL_CODE_SHINTO_PARENT.Location = New System.Drawing.Point(5, 5)
        Me.PNL_CODE_SHINTO_PARENT.Name = "PNL_CODE_SHINTO_PARENT"
        Me.PNL_CODE_SHINTO_PARENT.Size = New System.Drawing.Size(360, 30)
        Me.PNL_CODE_SHINTO_PARENT.TabIndex = 2
        '
        'LBL_CODE_OWNER
        '
        Me.LBL_CODE_OWNER.AutoEllipsis = True
        Me.LBL_CODE_OWNER.BackColor = System.Drawing.Color.White
        Me.LBL_CODE_OWNER.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_CODE_OWNER.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBL_CODE_OWNER.Location = New System.Drawing.Point(80, 1)
        Me.LBL_CODE_OWNER.Name = "LBL_CODE_OWNER"
        Me.LBL_CODE_OWNER.Size = New System.Drawing.Size(60, 25)
        Me.LBL_CODE_OWNER.TabIndex = 5
        Me.LBL_CODE_OWNER.Tag = "Clear"
        Me.LBL_CODE_OWNER.Text = "＊＊＊"
        Me.LBL_CODE_OWNER.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LBL_CODE_OWNER_GUIDE
        '
        Me.LBL_CODE_OWNER_GUIDE.AutoEllipsis = True
        Me.LBL_CODE_OWNER_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_CODE_OWNER_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_CODE_OWNER_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_CODE_OWNER_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_CODE_OWNER_GUIDE.Name = "LBL_CODE_OWNER_GUIDE"
        Me.LBL_CODE_OWNER_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_CODE_OWNER_GUIDE.TabIndex = 4
        Me.LBL_CODE_OWNER_GUIDE.Text = "オーナー"
        Me.LBL_CODE_OWNER_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LBL_CODE_OWNER_NAME
        '
        Me.LBL_CODE_OWNER_NAME.AutoEllipsis = True
        Me.LBL_CODE_OWNER_NAME.BackColor = System.Drawing.Color.White
        Me.LBL_CODE_OWNER_NAME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_CODE_OWNER_NAME.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBL_CODE_OWNER_NAME.Location = New System.Drawing.Point(140, 1)
        Me.LBL_CODE_OWNER_NAME.Name = "LBL_CODE_OWNER_NAME"
        Me.LBL_CODE_OWNER_NAME.Size = New System.Drawing.Size(210, 25)
        Me.LBL_CODE_OWNER_NAME.TabIndex = 3
        Me.LBL_CODE_OWNER_NAME.Tag = "Clear"
        Me.LBL_CODE_OWNER_NAME.Text = "＊＊＊"
        Me.LBL_CODE_OWNER_NAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PNL_NUMBER_CONTRACT
        '
        Me.PNL_NUMBER_CONTRACT.Controls.Add(Me.LBL_NUMBER_CONTRACT_LINK)
        Me.PNL_NUMBER_CONTRACT.Controls.Add(Me.LBL_SERIAL_CONTRACT)
        Me.PNL_NUMBER_CONTRACT.Controls.Add(Me.LBL_NUMBER_CONTRACT)
        Me.PNL_NUMBER_CONTRACT.Controls.Add(Me.LBL_NUMBER_CONTRACT_GUIDE)
        Me.PNL_NUMBER_CONTRACT.Location = New System.Drawing.Point(5, 40)
        Me.PNL_NUMBER_CONTRACT.Name = "PNL_NUMBER_CONTRACT"
        Me.PNL_NUMBER_CONTRACT.Size = New System.Drawing.Size(240, 30)
        Me.PNL_NUMBER_CONTRACT.TabIndex = 0
        '
        'LBL_NUMBER_CONTRACT_LINK
        '
        Me.LBL_NUMBER_CONTRACT_LINK.AutoEllipsis = True
        Me.LBL_NUMBER_CONTRACT_LINK.ForeColor = System.Drawing.Color.Black
        Me.LBL_NUMBER_CONTRACT_LINK.Location = New System.Drawing.Point(140, 1)
        Me.LBL_NUMBER_CONTRACT_LINK.Name = "LBL_NUMBER_CONTRACT_LINK"
        Me.LBL_NUMBER_CONTRACT_LINK.Size = New System.Drawing.Size(20, 25)
        Me.LBL_NUMBER_CONTRACT_LINK.TabIndex = 9
        Me.LBL_NUMBER_CONTRACT_LINK.Text = "-"
        Me.LBL_NUMBER_CONTRACT_LINK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LBL_SERIAL_CONTRACT
        '
        Me.LBL_SERIAL_CONTRACT.AutoEllipsis = True
        Me.LBL_SERIAL_CONTRACT.BackColor = System.Drawing.Color.White
        Me.LBL_SERIAL_CONTRACT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_SERIAL_CONTRACT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBL_SERIAL_CONTRACT.Location = New System.Drawing.Point(160, 1)
        Me.LBL_SERIAL_CONTRACT.Name = "LBL_SERIAL_CONTRACT"
        Me.LBL_SERIAL_CONTRACT.Size = New System.Drawing.Size(40, 25)
        Me.LBL_SERIAL_CONTRACT.TabIndex = 7
        Me.LBL_SERIAL_CONTRACT.Tag = "Clear"
        Me.LBL_SERIAL_CONTRACT.Text = "＊＊＊"
        Me.LBL_SERIAL_CONTRACT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LBL_NUMBER_CONTRACT
        '
        Me.LBL_NUMBER_CONTRACT.AutoEllipsis = True
        Me.LBL_NUMBER_CONTRACT.BackColor = System.Drawing.Color.White
        Me.LBL_NUMBER_CONTRACT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_NUMBER_CONTRACT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBL_NUMBER_CONTRACT.Location = New System.Drawing.Point(80, 1)
        Me.LBL_NUMBER_CONTRACT.Name = "LBL_NUMBER_CONTRACT"
        Me.LBL_NUMBER_CONTRACT.Size = New System.Drawing.Size(60, 25)
        Me.LBL_NUMBER_CONTRACT.TabIndex = 6
        Me.LBL_NUMBER_CONTRACT.Tag = "Clear"
        Me.LBL_NUMBER_CONTRACT.Text = "＊＊＊"
        Me.LBL_NUMBER_CONTRACT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.pnlFUNCTION_GROUP.Controls.Add(Me.BTN_ENTER)
        Me.pnlFUNCTION_GROUP.Controls.Add(Me.BTN_END)
        Me.pnlFUNCTION_GROUP.Location = New System.Drawing.Point(245, 15)
        Me.pnlFUNCTION_GROUP.MinimumSize = New System.Drawing.Size(190, 40)
        Me.pnlFUNCTION_GROUP.Name = "pnlFUNCTION_GROUP"
        Me.pnlFUNCTION_GROUP.Size = New System.Drawing.Size(270, 40)
        Me.pnlFUNCTION_GROUP.TabIndex = 1
        '
        'BTN_CLEAR
        '
        Me.BTN_CLEAR.AutoSize = True
        Me.BTN_CLEAR.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_CLEAR.Location = New System.Drawing.Point(95, 5)
        Me.BTN_CLEAR.MinimumSize = New System.Drawing.Size(80, 30)
        Me.BTN_CLEAR.Name = "BTN_CLEAR"
        Me.BTN_CLEAR.Size = New System.Drawing.Size(80, 30)
        Me.BTN_CLEAR.TabIndex = 2
        Me.BTN_CLEAR.Text = "クリア"
        Me.BTN_CLEAR.UseVisualStyleBackColor = False
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
        Me.BTN_END.Location = New System.Drawing.Point(180, 5)
        Me.BTN_END.MinimumSize = New System.Drawing.Size(80, 30)
        Me.BTN_END.Name = "BTN_END"
        Me.BTN_END.Size = New System.Drawing.Size(80, 30)
        Me.BTN_END.TabIndex = 3
        Me.BTN_END.Text = "終了"
        Me.BTN_END.UseVisualStyleBackColor = False
        '
        'PNL_FLAG_OUTPUT
        '
        Me.PNL_FLAG_OUTPUT.Controls.Add(Me.LBL_FLAG_OUTPUT)
        Me.PNL_FLAG_OUTPUT.Controls.Add(Me.LBL_FLAG_OUTPUT_GUIDE)
        Me.PNL_FLAG_OUTPUT.Location = New System.Drawing.Point(495, 5)
        Me.PNL_FLAG_OUTPUT.Name = "PNL_FLAG_OUTPUT"
        Me.PNL_FLAG_OUTPUT.Size = New System.Drawing.Size(240, 30)
        Me.PNL_FLAG_OUTPUT.TabIndex = 9
        '
        'LBL_FLAG_OUTPUT
        '
        Me.LBL_FLAG_OUTPUT.AutoEllipsis = True
        Me.LBL_FLAG_OUTPUT.BackColor = System.Drawing.Color.White
        Me.LBL_FLAG_OUTPUT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_FLAG_OUTPUT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBL_FLAG_OUTPUT.Location = New System.Drawing.Point(80, 1)
        Me.LBL_FLAG_OUTPUT.Name = "LBL_FLAG_OUTPUT"
        Me.LBL_FLAG_OUTPUT.Size = New System.Drawing.Size(150, 25)
        Me.LBL_FLAG_OUTPUT.TabIndex = 10
        Me.LBL_FLAG_OUTPUT.Tag = "Clear"
        Me.LBL_FLAG_OUTPUT.Text = "＊＊＊"
        Me.LBL_FLAG_OUTPUT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LBL_FLAG_OUTPUT_GUIDE
        '
        Me.LBL_FLAG_OUTPUT_GUIDE.AutoEllipsis = True
        Me.LBL_FLAG_OUTPUT_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_FLAG_OUTPUT_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_FLAG_OUTPUT_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_FLAG_OUTPUT_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_FLAG_OUTPUT_GUIDE.Name = "LBL_FLAG_OUTPUT_GUIDE"
        Me.LBL_FLAG_OUTPUT_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_FLAG_OUTPUT_GUIDE.TabIndex = 3
        Me.LBL_FLAG_OUTPUT_GUIDE.Text = "連携出力"
        Me.LBL_FLAG_OUTPUT_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FRM_SUB_01
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
        Me.Name = "FRM_SUB_01"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FRM_SUB_01"
        Me.GRP_HEAD.ResumeLayout(False)
        Me.PNL_INFO_GUIDE.ResumeLayout(False)
        Me.PNL_NAME_USER_HEAD.ResumeLayout(False)
        Me.PNL_DATE_ACTIVE_HEAD.ResumeLayout(False)
        Me.GRP_BODY.ResumeLayout(False)
        Me.PNL_INPUT_DATA.ResumeLayout(False)
        Me.PNL_CODE_SECTION.ResumeLayout(False)
        Me.PNL_DEPOSIT_INPUT_AREA.ResumeLayout(False)
        Me.PNL_FLAG_SALE.ResumeLayout(False)
        Me.PNL_SERIAL_DEPOSIT.ResumeLayout(False)
        Me.PNL_FLAG_DEPOSIT_SUB.ResumeLayout(False)
        Me.PNL_NAME_MEMO.ResumeLayout(False)
        Me.PNL_NAME_MEMO.PerformLayout()
        Me.PNL_KINGAKU_COST.ResumeLayout(False)
        Me.PNL_KINGAKU_COST.PerformLayout()
        Me.PNL_FLAG_COST.ResumeLayout(False)
        Me.PNL_KINGAKU_FEE.ResumeLayout(False)
        Me.PNL_KINGAKU_FEE.PerformLayout()
        Me.PNL_FLAG_DEPOSIT.ResumeLayout(False)
        Me.PNL_DATE_DEPOSIT.ResumeLayout(False)
        Me.PNL_FLAG_DEPOSIT_DONE.ResumeLayout(False)
        Me.PNL_FLAG_DEPOSIT_DONE.PerformLayout()
        Me.PNL_KINGAKU_INVOICE.ResumeLayout(False)
        Me.PNL_KINGAKU_INVOICE.PerformLayout()
        Me.PNL_INPUT_KEY.ResumeLayout(False)
        Me.PNL_DATE_INVOICE.ResumeLayout(False)
        Me.PNL_KINGAKU_CONTRACT.ResumeLayout(False)
        Me.PNL_NAME_CONTRACT.ResumeLayout(False)
        Me.PNL_CODE_SHINTO_PARENT.ResumeLayout(False)
        Me.PNL_NUMBER_CONTRACT.ResumeLayout(False)
        Me.GRP_FOOT.ResumeLayout(False)
        Me.pnlFUNCTION_GROUP.ResumeLayout(False)
        Me.pnlFUNCTION_GROUP.PerformLayout()
        Me.PNL_FLAG_OUTPUT.ResumeLayout(False)
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
    Friend WithEvents PNL_INPUT_DATA As Panel
    Friend WithEvents PNL_FLAG_DEPOSIT_DONE As Panel
    Friend WithEvents LBL_FLAG_DEPOSIT_DONE_GUIDE As Label
    Friend WithEvents PNL_KINGAKU_INVOICE As Panel
    Friend WithEvents LBL_KINGAKU_INVOICE_GUIDE As Label
    Friend WithEvents TXT_KINGAKU_INVOICE_DETAIL As TextBox
    Friend WithEvents PNL_INPUT_KEY As Panel
    Friend WithEvents PNL_NUMBER_CONTRACT As Panel
    Friend WithEvents LBL_NUMBER_CONTRACT_GUIDE As Label
    Friend WithEvents GRP_FOOT As GroupBox
    Friend WithEvents pnlFUNCTION_GROUP As Panel
    Friend WithEvents BTN_CLEAR As Button
    Friend WithEvents BTN_ENTER As Button
    Friend WithEvents BTN_END As Button
    Friend WithEvents PNL_NAME_CONTRACT As Panel
    Friend WithEvents LBL_NAME_CONTRACT_GUIDE As Label
    Friend WithEvents PNL_CODE_SHINTO_PARENT As Panel
    Friend WithEvents LBL_CODE_OWNER As Label
    Friend WithEvents LBL_CODE_OWNER_GUIDE As Label
    Friend WithEvents LBL_CODE_OWNER_NAME As Label
    Friend WithEvents LBL_NAME_CONTRACT As Label
    Friend WithEvents PNL_KINGAKU_CONTRACT As Panel
    Friend WithEvents LBL_KINGAKU_CONTRACT_GUIDE As Label
    Friend WithEvents LBL_NUMBER_CONTRACT_LINK As Label
    Friend WithEvents LBL_SERIAL_CONTRACT As Label
    Friend WithEvents LBL_NUMBER_CONTRACT As Label
    Friend WithEvents LBL_KINGAKU_INVOICE_TOTAL As Label
    Friend WithEvents TXT_KINGAKU_INVOICE_VAT As TextBox
    Friend WithEvents CHK_FLAG_DEPOSIT_DONE As CheckBox
    Friend WithEvents LBL_KINGAKU_CONTRACT As Label
    Friend WithEvents PNL_DATE_INVOICE As Panel
    Friend WithEvents LBL_DATE_INVOICE As Label
    Friend WithEvents LBL_DATE_INVOICE_GUIDE As Label
    Friend WithEvents PNL_KINGAKU_FEE As Panel
    Friend WithEvents LBL_KINGAKU_FEE_TOTAL As Label
    Friend WithEvents TXT_KINGAKU_FEE_VAT As TextBox
    Friend WithEvents LBL_KINGAKU_FEE_GUIDE As Label
    Friend WithEvents PNL_DEPOSIT_INPUT_AREA As Panel
    Friend WithEvents PNL_FLAG_DEPOSIT As Panel
    Friend WithEvents CMB_FLAG_DEPOSIT As ComboBox
    Friend WithEvents LBL_FLAG_DEPOSIT_GUIDE As Label
    Friend WithEvents PNL_DATE_DEPOSIT As Panel
    Friend WithEvents DTP_DATE_DEPOSIT As DateTimePicker
    Friend WithEvents LBL_DATE_DEPOSIT_GUIDE As Label
    Friend WithEvents PNL_FLAG_COST As Panel
    Friend WithEvents CMB_FLAG_COST As ComboBox
    Friend WithEvents LBL_FLAG_COST_GUIDE As Label
    Friend WithEvents PNL_KINGAKU_COST As Panel
    Friend WithEvents LBL_KINGAKU_COST_TOTAL As Label
    Friend WithEvents TXT_KINGAKU_COST_VAT As TextBox
    Friend WithEvents LBL_KINGAKU_COST_GUIDE As Label
    Friend WithEvents TXT_KINGAKU_COST_DETAIL As TextBox
    Friend WithEvents PNL_NAME_MEMO As Panel
    Friend WithEvents TXT_NAME_MEMO As TextBox
    Friend WithEvents LBL_NAME_MEMO_GUIDE As Label
    Friend WithEvents CMB_KINGAKU_FEE_DETAIL As ComboBox
    Friend WithEvents LBL_FLAG_DEPOSIT_DONE_BACK As Label
    Friend WithEvents PNL_FLAG_DEPOSIT_SUB As Panel
    Friend WithEvents CMB_FLAG_DEPOSIT_SUB As ComboBox
    Friend WithEvents LBL_FLAG_DEPOSIT_SUB_GUIDE As Label
    Friend WithEvents PNL_SERIAL_DEPOSIT As Panel
    Friend WithEvents LBL_SERIAL_DEPOSIT As Label
    Friend WithEvents LBL_SERIAL_DEPOSIT_GUIDE As Label
    Friend WithEvents PNL_FLAG_SALE As Panel
    Friend WithEvents CMB_FLAG_SALE As ComboBox
    Friend WithEvents LBL_FLAG_SALE_GUIDE As Label
    Friend WithEvents PNL_CODE_SECTION As Panel
    Friend WithEvents CMB_CODE_SECTION As ComboBox
    Friend WithEvents LBL_CODE_SECTION_GUIDE As Label
    Friend WithEvents PNL_FLAG_OUTPUT As Panel
    Friend WithEvents LBL_FLAG_OUTPUT As Label
    Friend WithEvents LBL_FLAG_OUTPUT_GUIDE As Label
End Class
