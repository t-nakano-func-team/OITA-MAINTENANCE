﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.PNL_INPUT_DATA = New System.Windows.Forms.Panel()
        Me.PNL_CODE_CONNECTION = New System.Windows.Forms.Panel()
        Me.CMB_CODE_CONNECTION = New System.Windows.Forms.ComboBox()
        Me.LBL_CODE_CONNECTION_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_INPUT_KEY = New System.Windows.Forms.Panel()
        Me.PNL_CODE_CUSTOMER_SUB = New System.Windows.Forms.Panel()
        Me.LBL_CODE_CUSTOMER_SUB_NAME = New System.Windows.Forms.Label()
        Me.LBL_CODE_CUSTOMER_SUB_GUIDE = New System.Windows.Forms.Label()
        Me.TXT_CODE_CUSTOMER_SUB = New System.Windows.Forms.TextBox()
        Me.PNL_CODE_CUSTOMER = New System.Windows.Forms.Panel()
        Me.LBL_CODE_CUSTOMER_NAME = New System.Windows.Forms.Label()
        Me.LBL_CODE_CUSTOMER_GUIDE = New System.Windows.Forms.Label()
        Me.TXT_CODE_CUSTOMER = New System.Windows.Forms.TextBox()
        Me.GRP_FOOT = New System.Windows.Forms.GroupBox()
        Me.pnlFUNCTION_GROUP = New System.Windows.Forms.Panel()
        Me.BTN_CLEAR = New System.Windows.Forms.Button()
        Me.BTN_DELETE = New System.Windows.Forms.Button()
        Me.BTN_ENTER = New System.Windows.Forms.Button()
        Me.BTN_END = New System.Windows.Forms.Button()
        Me.GRP_HEAD.SuspendLayout()
        Me.PNL_INFO_GUIDE.SuspendLayout()
        Me.PNL_NAME_USER_HEAD.SuspendLayout()
        Me.PNL_DATE_ACTIVE_HEAD.SuspendLayout()
        Me.GRP_BODY.SuspendLayout()
        CType(Me.DGV_VIEW_DATA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PNL_INPUT_DATA.SuspendLayout()
        Me.PNL_CODE_CONNECTION.SuspendLayout()
        Me.PNL_INPUT_KEY.SuspendLayout()
        Me.PNL_CODE_CUSTOMER_SUB.SuspendLayout()
        Me.PNL_CODE_CUSTOMER.SuspendLayout()
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
        Me.GRP_HEAD.TabIndex = 2
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
        Me.GRP_BODY.Controls.Add(Me.PNL_INPUT_DATA)
        Me.GRP_BODY.Controls.Add(Me.PNL_INPUT_KEY)
        Me.GRP_BODY.Location = New System.Drawing.Point(10, 60)
        Me.GRP_BODY.Name = "GRP_BODY"
        Me.GRP_BODY.Size = New System.Drawing.Size(760, 430)
        Me.GRP_BODY.TabIndex = 3
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
        Me.DGV_VIEW_DATA.Location = New System.Drawing.Point(10, 115)
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
        Me.DGV_VIEW_DATA.Size = New System.Drawing.Size(740, 305)
        Me.DGV_VIEW_DATA.TabIndex = 3
        Me.DGV_VIEW_DATA.TabStop = False
        '
        'PNL_INPUT_DATA
        '
        Me.PNL_INPUT_DATA.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PNL_INPUT_DATA.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.PNL_INPUT_DATA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PNL_INPUT_DATA.Controls.Add(Me.PNL_CODE_CONNECTION)
        Me.PNL_INPUT_DATA.Location = New System.Drawing.Point(10, 70)
        Me.PNL_INPUT_DATA.Name = "PNL_INPUT_DATA"
        Me.PNL_INPUT_DATA.Size = New System.Drawing.Size(740, 40)
        Me.PNL_INPUT_DATA.TabIndex = 2
        '
        'PNL_CODE_CONNECTION
        '
        Me.PNL_CODE_CONNECTION.Controls.Add(Me.CMB_CODE_CONNECTION)
        Me.PNL_CODE_CONNECTION.Controls.Add(Me.LBL_CODE_CONNECTION_GUIDE)
        Me.PNL_CODE_CONNECTION.Location = New System.Drawing.Point(5, 5)
        Me.PNL_CODE_CONNECTION.Name = "PNL_CODE_CONNECTION"
        Me.PNL_CODE_CONNECTION.Size = New System.Drawing.Size(240, 30)
        Me.PNL_CODE_CONNECTION.TabIndex = 5
        '
        'CMB_CODE_CONNECTION
        '
        Me.CMB_CODE_CONNECTION.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_CODE_CONNECTION.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CMB_CODE_CONNECTION.Location = New System.Drawing.Point(90, 1)
        Me.CMB_CODE_CONNECTION.Name = "CMB_CODE_CONNECTION"
        Me.CMB_CODE_CONNECTION.Size = New System.Drawing.Size(140, 26)
        Me.CMB_CODE_CONNECTION.TabIndex = 1
        Me.CMB_CODE_CONNECTION.Tag = "Clear,Check,Selected"
        '
        'LBL_CODE_CONNECTION_GUIDE
        '
        Me.LBL_CODE_CONNECTION_GUIDE.AutoEllipsis = True
        Me.LBL_CODE_CONNECTION_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_CODE_CONNECTION_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_CODE_CONNECTION_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_CODE_CONNECTION_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_CODE_CONNECTION_GUIDE.Name = "LBL_CODE_CONNECTION_GUIDE"
        Me.LBL_CODE_CONNECTION_GUIDE.Size = New System.Drawing.Size(89, 25)
        Me.LBL_CODE_CONNECTION_GUIDE.TabIndex = 0
        Me.LBL_CODE_CONNECTION_GUIDE.Text = "属性"
        Me.LBL_CODE_CONNECTION_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PNL_INPUT_KEY
        '
        Me.PNL_INPUT_KEY.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PNL_INPUT_KEY.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.PNL_INPUT_KEY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PNL_INPUT_KEY.Controls.Add(Me.PNL_CODE_CUSTOMER_SUB)
        Me.PNL_INPUT_KEY.Controls.Add(Me.PNL_CODE_CUSTOMER)
        Me.PNL_INPUT_KEY.Location = New System.Drawing.Point(10, 20)
        Me.PNL_INPUT_KEY.Name = "PNL_INPUT_KEY"
        Me.PNL_INPUT_KEY.Size = New System.Drawing.Size(740, 40)
        Me.PNL_INPUT_KEY.TabIndex = 0
        '
        'PNL_CODE_CUSTOMER_SUB
        '
        Me.PNL_CODE_CUSTOMER_SUB.Controls.Add(Me.LBL_CODE_CUSTOMER_SUB_NAME)
        Me.PNL_CODE_CUSTOMER_SUB.Controls.Add(Me.LBL_CODE_CUSTOMER_SUB_GUIDE)
        Me.PNL_CODE_CUSTOMER_SUB.Controls.Add(Me.TXT_CODE_CUSTOMER_SUB)
        Me.PNL_CODE_CUSTOMER_SUB.Location = New System.Drawing.Point(250, 5)
        Me.PNL_CODE_CUSTOMER_SUB.Name = "PNL_CODE_CUSTOMER_SUB"
        Me.PNL_CODE_CUSTOMER_SUB.Size = New System.Drawing.Size(240, 30)
        Me.PNL_CODE_CUSTOMER_SUB.TabIndex = 1
        '
        'LBL_CODE_CUSTOMER_SUB_NAME
        '
        Me.LBL_CODE_CUSTOMER_SUB_NAME.AutoEllipsis = True
        Me.LBL_CODE_CUSTOMER_SUB_NAME.BackColor = System.Drawing.Color.White
        Me.LBL_CODE_CUSTOMER_SUB_NAME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_CODE_CUSTOMER_SUB_NAME.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBL_CODE_CUSTOMER_SUB_NAME.Location = New System.Drawing.Point(140, 1)
        Me.LBL_CODE_CUSTOMER_SUB_NAME.Name = "LBL_CODE_CUSTOMER_SUB_NAME"
        Me.LBL_CODE_CUSTOMER_SUB_NAME.Size = New System.Drawing.Size(90, 25)
        Me.LBL_CODE_CUSTOMER_SUB_NAME.TabIndex = 5
        Me.LBL_CODE_CUSTOMER_SUB_NAME.Tag = "Clear"
        Me.LBL_CODE_CUSTOMER_SUB_NAME.Text = "＊＊＊"
        Me.LBL_CODE_CUSTOMER_SUB_NAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LBL_CODE_CUSTOMER_SUB_GUIDE
        '
        Me.LBL_CODE_CUSTOMER_SUB_GUIDE.AutoEllipsis = True
        Me.LBL_CODE_CUSTOMER_SUB_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_CODE_CUSTOMER_SUB_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_CODE_CUSTOMER_SUB_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_CODE_CUSTOMER_SUB_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_CODE_CUSTOMER_SUB_GUIDE.Name = "LBL_CODE_CUSTOMER_SUB_GUIDE"
        Me.LBL_CODE_CUSTOMER_SUB_GUIDE.Size = New System.Drawing.Size(89, 25)
        Me.LBL_CODE_CUSTOMER_SUB_GUIDE.TabIndex = 3
        Me.LBL_CODE_CUSTOMER_SUB_GUIDE.Text = "関連顧客"
        Me.LBL_CODE_CUSTOMER_SUB_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXT_CODE_CUSTOMER_SUB
        '
        Me.TXT_CODE_CUSTOMER_SUB.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TXT_CODE_CUSTOMER_SUB.Location = New System.Drawing.Point(90, 1)
        Me.TXT_CODE_CUSTOMER_SUB.MaxLength = 6
        Me.TXT_CODE_CUSTOMER_SUB.Name = "TXT_CODE_CUSTOMER_SUB"
        Me.TXT_CODE_CUSTOMER_SUB.Size = New System.Drawing.Size(50, 25)
        Me.TXT_CODE_CUSTOMER_SUB.TabIndex = 1
        Me.TXT_CODE_CUSTOMER_SUB.Tag = "Clear,Numeric,Format=000000,Check,NotNull,NotZero,Plus"
        Me.TXT_CODE_CUSTOMER_SUB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PNL_CODE_CUSTOMER
        '
        Me.PNL_CODE_CUSTOMER.Controls.Add(Me.LBL_CODE_CUSTOMER_NAME)
        Me.PNL_CODE_CUSTOMER.Controls.Add(Me.LBL_CODE_CUSTOMER_GUIDE)
        Me.PNL_CODE_CUSTOMER.Controls.Add(Me.TXT_CODE_CUSTOMER)
        Me.PNL_CODE_CUSTOMER.Location = New System.Drawing.Point(5, 5)
        Me.PNL_CODE_CUSTOMER.Name = "PNL_CODE_CUSTOMER"
        Me.PNL_CODE_CUSTOMER.Size = New System.Drawing.Size(240, 30)
        Me.PNL_CODE_CUSTOMER.TabIndex = 0
        '
        'LBL_CODE_CUSTOMER_NAME
        '
        Me.LBL_CODE_CUSTOMER_NAME.AutoEllipsis = True
        Me.LBL_CODE_CUSTOMER_NAME.BackColor = System.Drawing.Color.White
        Me.LBL_CODE_CUSTOMER_NAME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_CODE_CUSTOMER_NAME.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBL_CODE_CUSTOMER_NAME.Location = New System.Drawing.Point(140, 1)
        Me.LBL_CODE_CUSTOMER_NAME.Name = "LBL_CODE_CUSTOMER_NAME"
        Me.LBL_CODE_CUSTOMER_NAME.Size = New System.Drawing.Size(90, 25)
        Me.LBL_CODE_CUSTOMER_NAME.TabIndex = 4
        Me.LBL_CODE_CUSTOMER_NAME.Tag = "Clear"
        Me.LBL_CODE_CUSTOMER_NAME.Text = "＊＊＊"
        Me.LBL_CODE_CUSTOMER_NAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LBL_CODE_CUSTOMER_GUIDE
        '
        Me.LBL_CODE_CUSTOMER_GUIDE.AutoEllipsis = True
        Me.LBL_CODE_CUSTOMER_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_CODE_CUSTOMER_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_CODE_CUSTOMER_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_CODE_CUSTOMER_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_CODE_CUSTOMER_GUIDE.Name = "LBL_CODE_CUSTOMER_GUIDE"
        Me.LBL_CODE_CUSTOMER_GUIDE.Size = New System.Drawing.Size(89, 25)
        Me.LBL_CODE_CUSTOMER_GUIDE.TabIndex = 3
        Me.LBL_CODE_CUSTOMER_GUIDE.Text = "顧客"
        Me.LBL_CODE_CUSTOMER_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXT_CODE_CUSTOMER
        '
        Me.TXT_CODE_CUSTOMER.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TXT_CODE_CUSTOMER.Location = New System.Drawing.Point(90, 1)
        Me.TXT_CODE_CUSTOMER.MaxLength = 6
        Me.TXT_CODE_CUSTOMER.Name = "TXT_CODE_CUSTOMER"
        Me.TXT_CODE_CUSTOMER.Size = New System.Drawing.Size(50, 25)
        Me.TXT_CODE_CUSTOMER.TabIndex = 1
        Me.TXT_CODE_CUSTOMER.Tag = "Clear,Numeric,Format=000000,Check,NotNull,NotZero,Plus"
        Me.TXT_CODE_CUSTOMER.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.GRP_FOOT.TabIndex = 4
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
        Me.pnlFUNCTION_GROUP.Location = New System.Drawing.Point(190, 15)
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
        Me.BTN_CLEAR.TabIndex = 5
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
        Me.BTN_END.TabIndex = 6
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
        Me.Name = "FRM_MAIN"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "***"
        Me.GRP_HEAD.ResumeLayout(False)
        Me.PNL_INFO_GUIDE.ResumeLayout(False)
        Me.PNL_NAME_USER_HEAD.ResumeLayout(False)
        Me.PNL_DATE_ACTIVE_HEAD.ResumeLayout(False)
        Me.GRP_BODY.ResumeLayout(False)
        CType(Me.DGV_VIEW_DATA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PNL_INPUT_DATA.ResumeLayout(False)
        Me.PNL_CODE_CONNECTION.ResumeLayout(False)
        Me.PNL_INPUT_KEY.ResumeLayout(False)
        Me.PNL_CODE_CUSTOMER_SUB.ResumeLayout(False)
        Me.PNL_CODE_CUSTOMER_SUB.PerformLayout()
        Me.PNL_CODE_CUSTOMER.ResumeLayout(False)
        Me.PNL_CODE_CUSTOMER.PerformLayout()
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
    Friend WithEvents DGV_VIEW_DATA As DataGridView
    Friend WithEvents PNL_INPUT_DATA As Panel
    Friend WithEvents PNL_INPUT_KEY As Panel
    Friend WithEvents PNL_CODE_CUSTOMER As Panel
    Friend WithEvents LBL_CODE_CUSTOMER_GUIDE As Label
    Friend WithEvents TXT_CODE_CUSTOMER As TextBox
    Friend WithEvents GRP_FOOT As GroupBox
    Friend WithEvents pnlFUNCTION_GROUP As Panel
    Friend WithEvents BTN_CLEAR As Button
    Friend WithEvents BTN_DELETE As Button
    Friend WithEvents BTN_ENTER As Button
    Friend WithEvents BTN_END As Button
    Friend WithEvents PNL_CODE_CUSTOMER_SUB As Panel
    Friend WithEvents LBL_CODE_CUSTOMER_SUB_GUIDE As Label
    Friend WithEvents TXT_CODE_CUSTOMER_SUB As TextBox
    Friend WithEvents PNL_CODE_CONNECTION As Panel
    Friend WithEvents CMB_CODE_CONNECTION As ComboBox
    Friend WithEvents LBL_CODE_CONNECTION_GUIDE As Label
    Friend WithEvents LBL_CODE_CUSTOMER_NAME As Label
    Friend WithEvents LBL_CODE_CUSTOMER_SUB_NAME As Label
End Class
