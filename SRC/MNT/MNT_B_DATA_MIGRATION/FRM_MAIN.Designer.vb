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
        Me.BTN_BATCH = New System.Windows.Forms.Button()
        Me.BTN_END = New System.Windows.Forms.Button()
        Me.GRP_BODY = New System.Windows.Forms.GroupBox()
        Me.PNL_INPUT_DATA = New System.Windows.Forms.Panel()
        Me.PNL_BATCH_PROGRESS = New System.Windows.Forms.Panel()
        Me.LBL_BATCH_PROGRESS = New System.Windows.Forms.Label()
        Me.PNL_INPUT_KEY = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CHK_DELETE_MAKE = New System.Windows.Forms.CheckBox()
        Me.LBL_DELETE_MAKE_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_DATE_DEPOSIT = New System.Windows.Forms.Panel()
        Me.DTP_DATE_DEPOSIT = New System.Windows.Forms.DateTimePicker()
        Me.LBL_DATE_DEPOSIT_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_DATE_INVOICE = New System.Windows.Forms.Panel()
        Me.DTP_DATE_INVOICE = New System.Windows.Forms.DateTimePicker()
        Me.LBL_DATE_INVOICE_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_COUNT_BATCH = New System.Windows.Forms.Panel()
        Me.LBL_COUNT_BATCH_UNIT = New System.Windows.Forms.Label()
        Me.LBL_COUNT_BATCH = New System.Windows.Forms.Label()
        Me.LBL_COUNT_BATCH_GUIDE = New System.Windows.Forms.Label()
        Me.OFD_FILE_OPEN = New System.Windows.Forms.OpenFileDialog()
        Me.PNL_DATE_ACTIVE = New System.Windows.Forms.Panel()
        Me.DTP_DATE_ACTIVE = New System.Windows.Forms.DateTimePicker()
        Me.LBL_DATE_ACTIVE_GUIDE = New System.Windows.Forms.Label()
        Me.GRP_HEAD.SuspendLayout()
        Me.PNL_INFO_GUIDE.SuspendLayout()
        Me.PNL_NAME_USER_HEAD.SuspendLayout()
        Me.PNL_DATE_ACTIVE_HEAD.SuspendLayout()
        Me.GRP_FOOT.SuspendLayout()
        Me.pnlFUNCTION_GROUP.SuspendLayout()
        Me.GRP_BODY.SuspendLayout()
        Me.PNL_INPUT_DATA.SuspendLayout()
        Me.PNL_BATCH_PROGRESS.SuspendLayout()
        Me.PNL_INPUT_KEY.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.PNL_DATE_DEPOSIT.SuspendLayout()
        Me.PNL_DATE_INVOICE.SuspendLayout()
        Me.PNL_COUNT_BATCH.SuspendLayout()
        Me.PNL_DATE_ACTIVE.SuspendLayout()
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
        Me.GRP_HEAD.TabIndex = 6
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
        Me.GRP_FOOT.TabIndex = 7
        Me.GRP_FOOT.TabStop = False
        '
        'pnlFUNCTION_GROUP
        '
        Me.pnlFUNCTION_GROUP.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnlFUNCTION_GROUP.AutoScroll = True
        Me.pnlFUNCTION_GROUP.Controls.Add(Me.BTN_CLEAR)
        Me.pnlFUNCTION_GROUP.Controls.Add(Me.BTN_BATCH)
        Me.pnlFUNCTION_GROUP.Controls.Add(Me.BTN_END)
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
        'BTN_BATCH
        '
        Me.BTN_BATCH.AutoSize = True
        Me.BTN_BATCH.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_BATCH.Location = New System.Drawing.Point(10, 5)
        Me.BTN_BATCH.MinimumSize = New System.Drawing.Size(80, 30)
        Me.BTN_BATCH.Name = "BTN_BATCH"
        Me.BTN_BATCH.Size = New System.Drawing.Size(80, 30)
        Me.BTN_BATCH.TabIndex = 1
        Me.BTN_BATCH.Text = "実行"
        Me.BTN_BATCH.UseVisualStyleBackColor = False
        '
        'BTN_END
        '
        Me.BTN_END.AutoSize = True
        Me.BTN_END.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_END.Location = New System.Drawing.Point(180, 5)
        Me.BTN_END.MinimumSize = New System.Drawing.Size(80, 30)
        Me.BTN_END.Name = "BTN_END"
        Me.BTN_END.Size = New System.Drawing.Size(80, 30)
        Me.BTN_END.TabIndex = 4
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
        Me.GRP_BODY.TabIndex = 10
        Me.GRP_BODY.TabStop = False
        '
        'PNL_INPUT_DATA
        '
        Me.PNL_INPUT_DATA.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PNL_INPUT_DATA.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.PNL_INPUT_DATA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PNL_INPUT_DATA.Controls.Add(Me.PNL_BATCH_PROGRESS)
        Me.PNL_INPUT_DATA.Location = New System.Drawing.Point(10, 380)
        Me.PNL_INPUT_DATA.Name = "PNL_INPUT_DATA"
        Me.PNL_INPUT_DATA.Size = New System.Drawing.Size(740, 40)
        Me.PNL_INPUT_DATA.TabIndex = 3
        '
        'PNL_BATCH_PROGRESS
        '
        Me.PNL_BATCH_PROGRESS.Controls.Add(Me.LBL_BATCH_PROGRESS)
        Me.PNL_BATCH_PROGRESS.Location = New System.Drawing.Point(5, 5)
        Me.PNL_BATCH_PROGRESS.Name = "PNL_BATCH_PROGRESS"
        Me.PNL_BATCH_PROGRESS.Size = New System.Drawing.Size(730, 30)
        Me.PNL_BATCH_PROGRESS.TabIndex = 4
        '
        'LBL_BATCH_PROGRESS
        '
        Me.LBL_BATCH_PROGRESS.AutoSize = True
        Me.LBL_BATCH_PROGRESS.ForeColor = System.Drawing.Color.Black
        Me.LBL_BATCH_PROGRESS.Location = New System.Drawing.Point(5, 5)
        Me.LBL_BATCH_PROGRESS.Name = "LBL_BATCH_PROGRESS"
        Me.LBL_BATCH_PROGRESS.Size = New System.Drawing.Size(29, 18)
        Me.LBL_BATCH_PROGRESS.TabIndex = 9
        Me.LBL_BATCH_PROGRESS.Tag = "Clear"
        Me.LBL_BATCH_PROGRESS.Text = "***"
        Me.LBL_BATCH_PROGRESS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PNL_INPUT_KEY
        '
        Me.PNL_INPUT_KEY.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PNL_INPUT_KEY.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.PNL_INPUT_KEY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PNL_INPUT_KEY.Controls.Add(Me.PNL_DATE_ACTIVE)
        Me.PNL_INPUT_KEY.Controls.Add(Me.Panel1)
        Me.PNL_INPUT_KEY.Controls.Add(Me.PNL_DATE_DEPOSIT)
        Me.PNL_INPUT_KEY.Controls.Add(Me.PNL_DATE_INVOICE)
        Me.PNL_INPUT_KEY.Controls.Add(Me.PNL_COUNT_BATCH)
        Me.PNL_INPUT_KEY.Location = New System.Drawing.Point(10, 20)
        Me.PNL_INPUT_KEY.Name = "PNL_INPUT_KEY"
        Me.PNL_INPUT_KEY.Size = New System.Drawing.Size(740, 350)
        Me.PNL_INPUT_KEY.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CHK_DELETE_MAKE)
        Me.Panel1.Controls.Add(Me.LBL_DELETE_MAKE_GUIDE)
        Me.Panel1.Location = New System.Drawing.Point(5, 110)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(480, 30)
        Me.Panel1.TabIndex = 13
        '
        'CHK_DELETE_MAKE
        '
        Me.CHK_DELETE_MAKE.AutoSize = True
        Me.CHK_DELETE_MAKE.Location = New System.Drawing.Point(80, 4)
        Me.CHK_DELETE_MAKE.Name = "CHK_DELETE_MAKE"
        Me.CHK_DELETE_MAKE.Size = New System.Drawing.Size(254, 22)
        Me.CHK_DELETE_MAKE.TabIndex = 15
        Me.CHK_DELETE_MAKE.Text = "作成者=9999998のレコードを削除します"
        Me.CHK_DELETE_MAKE.UseVisualStyleBackColor = True
        '
        'LBL_DELETE_MAKE_GUIDE
        '
        Me.LBL_DELETE_MAKE_GUIDE.AutoEllipsis = True
        Me.LBL_DELETE_MAKE_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_DELETE_MAKE_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_DELETE_MAKE_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_DELETE_MAKE_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_DELETE_MAKE_GUIDE.Name = "LBL_DELETE_MAKE_GUIDE"
        Me.LBL_DELETE_MAKE_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_DELETE_MAKE_GUIDE.TabIndex = 0
        Me.LBL_DELETE_MAKE_GUIDE.Text = "既移行削除"
        Me.LBL_DELETE_MAKE_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PNL_DATE_DEPOSIT
        '
        Me.PNL_DATE_DEPOSIT.Controls.Add(Me.DTP_DATE_DEPOSIT)
        Me.PNL_DATE_DEPOSIT.Controls.Add(Me.LBL_DATE_DEPOSIT_GUIDE)
        Me.PNL_DATE_DEPOSIT.Location = New System.Drawing.Point(5, 75)
        Me.PNL_DATE_DEPOSIT.Name = "PNL_DATE_DEPOSIT"
        Me.PNL_DATE_DEPOSIT.Size = New System.Drawing.Size(240, 30)
        Me.PNL_DATE_DEPOSIT.TabIndex = 12
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
        Me.LBL_DATE_DEPOSIT_GUIDE.Text = "入金完了日"
        Me.LBL_DATE_DEPOSIT_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PNL_DATE_INVOICE
        '
        Me.PNL_DATE_INVOICE.Controls.Add(Me.DTP_DATE_INVOICE)
        Me.PNL_DATE_INVOICE.Controls.Add(Me.LBL_DATE_INVOICE_GUIDE)
        Me.PNL_DATE_INVOICE.Location = New System.Drawing.Point(5, 40)
        Me.PNL_DATE_INVOICE.Name = "PNL_DATE_INVOICE"
        Me.PNL_DATE_INVOICE.Size = New System.Drawing.Size(240, 30)
        Me.PNL_DATE_INVOICE.TabIndex = 11
        '
        'DTP_DATE_INVOICE
        '
        Me.DTP_DATE_INVOICE.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.DTP_DATE_INVOICE.Location = New System.Drawing.Point(80, 1)
        Me.DTP_DATE_INVOICE.Name = "DTP_DATE_INVOICE"
        Me.DTP_DATE_INVOICE.Size = New System.Drawing.Size(150, 25)
        Me.DTP_DATE_INVOICE.TabIndex = 1
        Me.DTP_DATE_INVOICE.Tag = "Clear"
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
        Me.LBL_DATE_INVOICE_GUIDE.Text = "請求完了日"
        Me.LBL_DATE_INVOICE_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PNL_COUNT_BATCH
        '
        Me.PNL_COUNT_BATCH.Controls.Add(Me.LBL_COUNT_BATCH_UNIT)
        Me.PNL_COUNT_BATCH.Controls.Add(Me.LBL_COUNT_BATCH)
        Me.PNL_COUNT_BATCH.Controls.Add(Me.LBL_COUNT_BATCH_GUIDE)
        Me.PNL_COUNT_BATCH.Location = New System.Drawing.Point(5, 5)
        Me.PNL_COUNT_BATCH.Name = "PNL_COUNT_BATCH"
        Me.PNL_COUNT_BATCH.Size = New System.Drawing.Size(240, 30)
        Me.PNL_COUNT_BATCH.TabIndex = 0
        '
        'LBL_COUNT_BATCH_UNIT
        '
        Me.LBL_COUNT_BATCH_UNIT.AutoEllipsis = True
        Me.LBL_COUNT_BATCH_UNIT.ForeColor = System.Drawing.Color.Black
        Me.LBL_COUNT_BATCH_UNIT.Location = New System.Drawing.Point(200, 1)
        Me.LBL_COUNT_BATCH_UNIT.Name = "LBL_COUNT_BATCH_UNIT"
        Me.LBL_COUNT_BATCH_UNIT.Size = New System.Drawing.Size(20, 25)
        Me.LBL_COUNT_BATCH_UNIT.TabIndex = 10
        Me.LBL_COUNT_BATCH_UNIT.Text = "件"
        Me.LBL_COUNT_BATCH_UNIT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LBL_COUNT_BATCH
        '
        Me.LBL_COUNT_BATCH.AutoEllipsis = True
        Me.LBL_COUNT_BATCH.BackColor = System.Drawing.Color.White
        Me.LBL_COUNT_BATCH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_COUNT_BATCH.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBL_COUNT_BATCH.Location = New System.Drawing.Point(80, 1)
        Me.LBL_COUNT_BATCH.Name = "LBL_COUNT_BATCH"
        Me.LBL_COUNT_BATCH.Size = New System.Drawing.Size(120, 25)
        Me.LBL_COUNT_BATCH.TabIndex = 5
        Me.LBL_COUNT_BATCH.Tag = "Clear"
        Me.LBL_COUNT_BATCH.Text = "＊＊＊"
        Me.LBL_COUNT_BATCH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LBL_COUNT_BATCH_GUIDE
        '
        Me.LBL_COUNT_BATCH_GUIDE.AutoEllipsis = True
        Me.LBL_COUNT_BATCH_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_COUNT_BATCH_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_COUNT_BATCH_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_COUNT_BATCH_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_COUNT_BATCH_GUIDE.Name = "LBL_COUNT_BATCH_GUIDE"
        Me.LBL_COUNT_BATCH_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_COUNT_BATCH_GUIDE.TabIndex = 0
        Me.LBL_COUNT_BATCH_GUIDE.Text = "取込件数"
        Me.LBL_COUNT_BATCH_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OFD_FILE_OPEN
        '
        Me.OFD_FILE_OPEN.DefaultExt = "CSV"
        Me.OFD_FILE_OPEN.Filter = "Excelブック(*.xlsx)|*.xlsx"
        '
        'PNL_DATE_ACTIVE
        '
        Me.PNL_DATE_ACTIVE.Controls.Add(Me.DTP_DATE_ACTIVE)
        Me.PNL_DATE_ACTIVE.Controls.Add(Me.LBL_DATE_ACTIVE_GUIDE)
        Me.PNL_DATE_ACTIVE.Location = New System.Drawing.Point(5, 145)
        Me.PNL_DATE_ACTIVE.Name = "PNL_DATE_ACTIVE"
        Me.PNL_DATE_ACTIVE.Size = New System.Drawing.Size(240, 30)
        Me.PNL_DATE_ACTIVE.TabIndex = 14
        '
        'DTP_DATE_ACTIVE
        '
        Me.DTP_DATE_ACTIVE.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.DTP_DATE_ACTIVE.Location = New System.Drawing.Point(80, 1)
        Me.DTP_DATE_ACTIVE.Name = "DTP_DATE_ACTIVE"
        Me.DTP_DATE_ACTIVE.Size = New System.Drawing.Size(150, 25)
        Me.DTP_DATE_ACTIVE.TabIndex = 1
        Me.DTP_DATE_ACTIVE.Tag = "Clear"
        '
        'LBL_DATE_ACTIVE_GUIDE
        '
        Me.LBL_DATE_ACTIVE_GUIDE.AutoEllipsis = True
        Me.LBL_DATE_ACTIVE_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_DATE_ACTIVE_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_DATE_ACTIVE_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_DATE_ACTIVE_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_DATE_ACTIVE_GUIDE.Name = "LBL_DATE_ACTIVE_GUIDE"
        Me.LBL_DATE_ACTIVE_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_DATE_ACTIVE_GUIDE.TabIndex = 0
        Me.LBL_DATE_ACTIVE_GUIDE.Text = "処理日"
        Me.LBL_DATE_ACTIVE_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.PNL_BATCH_PROGRESS.ResumeLayout(False)
        Me.PNL_BATCH_PROGRESS.PerformLayout()
        Me.PNL_INPUT_KEY.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.PNL_DATE_DEPOSIT.ResumeLayout(False)
        Me.PNL_DATE_INVOICE.ResumeLayout(False)
        Me.PNL_COUNT_BATCH.ResumeLayout(False)
        Me.PNL_DATE_ACTIVE.ResumeLayout(False)
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
    Friend WithEvents BTN_BATCH As Button
    Friend WithEvents BTN_END As Button
    Friend WithEvents GRP_BODY As GroupBox
    Friend WithEvents PNL_INPUT_DATA As Panel
    Friend WithEvents PNL_BATCH_PROGRESS As Panel
    Friend WithEvents LBL_BATCH_PROGRESS As Label
    Friend WithEvents PNL_INPUT_KEY As Panel
    Friend WithEvents PNL_COUNT_BATCH As Panel
    Friend WithEvents LBL_COUNT_BATCH As Label
    Friend WithEvents LBL_COUNT_BATCH_GUIDE As Label
    Friend WithEvents OFD_FILE_OPEN As OpenFileDialog
    Friend WithEvents LBL_COUNT_BATCH_UNIT As Label
    Friend WithEvents PNL_DATE_INVOICE As Panel
    Friend WithEvents DTP_DATE_INVOICE As DateTimePicker
    Friend WithEvents LBL_DATE_INVOICE_GUIDE As Label
    Friend WithEvents PNL_DATE_DEPOSIT As Panel
    Friend WithEvents DTP_DATE_DEPOSIT As DateTimePicker
    Friend WithEvents LBL_DATE_DEPOSIT_GUIDE As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents CHK_DELETE_MAKE As CheckBox
    Friend WithEvents LBL_DELETE_MAKE_GUIDE As Label
    Friend WithEvents PNL_DATE_ACTIVE As Panel
    Friend WithEvents DTP_DATE_ACTIVE As DateTimePicker
    Friend WithEvents LBL_DATE_ACTIVE_GUIDE As Label
End Class
