<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_SUB_02
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
        Me.GRP_FOOT = New System.Windows.Forms.GroupBox()
        Me.pnlFUNCTION_GROUP = New System.Windows.Forms.Panel()
        Me.BTN_OK = New System.Windows.Forms.Button()
        Me.GRP_BODY = New System.Windows.Forms.GroupBox()
        Me.DGV_VIEW_DATA = New System.Windows.Forms.DataGridView()
        Me.PNL_INPUT_KEY = New System.Windows.Forms.Panel()
        Me.PNL_COUNT_INVOICE = New System.Windows.Forms.Panel()
        Me.LBL_COUNT_INVOICE_UNIT = New System.Windows.Forms.Label()
        Me.LBL_COUNT_INVOICE_GUIDE = New System.Windows.Forms.Label()
        Me.GRP_HEAD = New System.Windows.Forms.GroupBox()
        Me.PNL_INFO_GUIDE = New System.Windows.Forms.Panel()
        Me.PNL_NAME_TITLE_HEAD = New System.Windows.Forms.Panel()
        Me.LBL_NAME_TITLE_HEAD = New System.Windows.Forms.Label()
        Me.LBL_NAME_TITLE_HEAD_GUIDE = New System.Windows.Forms.Label()
        Me.LBL_COUNT_INVOICE_ALREADY = New System.Windows.Forms.Label()
        Me.GRP_FOOT.SuspendLayout()
        Me.pnlFUNCTION_GROUP.SuspendLayout()
        Me.GRP_BODY.SuspendLayout()
        CType(Me.DGV_VIEW_DATA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PNL_INPUT_KEY.SuspendLayout()
        Me.PNL_COUNT_INVOICE.SuspendLayout()
        Me.GRP_HEAD.SuspendLayout()
        Me.PNL_INFO_GUIDE.SuspendLayout()
        Me.PNL_NAME_TITLE_HEAD.SuspendLayout()
        Me.SuspendLayout()
        '
        'GRP_FOOT
        '
        Me.GRP_FOOT.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GRP_FOOT.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.GRP_FOOT.Controls.Add(Me.pnlFUNCTION_GROUP)
        Me.GRP_FOOT.Location = New System.Drawing.Point(10, 450)
        Me.GRP_FOOT.Name = "GRP_FOOT"
        Me.GRP_FOOT.Size = New System.Drawing.Size(520, 60)
        Me.GRP_FOOT.TabIndex = 13
        Me.GRP_FOOT.TabStop = False
        '
        'pnlFUNCTION_GROUP
        '
        Me.pnlFUNCTION_GROUP.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnlFUNCTION_GROUP.AutoScroll = True
        Me.pnlFUNCTION_GROUP.Controls.Add(Me.BTN_OK)
        Me.pnlFUNCTION_GROUP.Location = New System.Drawing.Point(170, 15)
        Me.pnlFUNCTION_GROUP.MinimumSize = New System.Drawing.Size(180, 40)
        Me.pnlFUNCTION_GROUP.Name = "pnlFUNCTION_GROUP"
        Me.pnlFUNCTION_GROUP.Size = New System.Drawing.Size(180, 40)
        Me.pnlFUNCTION_GROUP.TabIndex = 0
        '
        'BTN_OK
        '
        Me.BTN_OK.AutoSize = True
        Me.BTN_OK.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_OK.Location = New System.Drawing.Point(50, 5)
        Me.BTN_OK.MinimumSize = New System.Drawing.Size(80, 30)
        Me.BTN_OK.Name = "BTN_OK"
        Me.BTN_OK.Size = New System.Drawing.Size(80, 30)
        Me.BTN_OK.TabIndex = 1
        Me.BTN_OK.Text = "OK"
        Me.BTN_OK.UseVisualStyleBackColor = False
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
        Me.GRP_BODY.Size = New System.Drawing.Size(520, 390)
        Me.GRP_BODY.TabIndex = 12
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
        Me.DGV_VIEW_DATA.Location = New System.Drawing.Point(10, 70)
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
        Me.DGV_VIEW_DATA.Size = New System.Drawing.Size(500, 310)
        Me.DGV_VIEW_DATA.TabIndex = 2
        Me.DGV_VIEW_DATA.TabStop = False
        '
        'PNL_INPUT_KEY
        '
        Me.PNL_INPUT_KEY.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PNL_INPUT_KEY.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.PNL_INPUT_KEY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PNL_INPUT_KEY.Controls.Add(Me.PNL_COUNT_INVOICE)
        Me.PNL_INPUT_KEY.Location = New System.Drawing.Point(10, 20)
        Me.PNL_INPUT_KEY.Name = "PNL_INPUT_KEY"
        Me.PNL_INPUT_KEY.Size = New System.Drawing.Size(500, 40)
        Me.PNL_INPUT_KEY.TabIndex = 0
        '
        'PNL_COUNT_INVOICE
        '
        Me.PNL_COUNT_INVOICE.Controls.Add(Me.LBL_COUNT_INVOICE_ALREADY)
        Me.PNL_COUNT_INVOICE.Controls.Add(Me.LBL_COUNT_INVOICE_UNIT)
        Me.PNL_COUNT_INVOICE.Controls.Add(Me.LBL_COUNT_INVOICE_GUIDE)
        Me.PNL_COUNT_INVOICE.Location = New System.Drawing.Point(5, 5)
        Me.PNL_COUNT_INVOICE.Name = "PNL_COUNT_INVOICE"
        Me.PNL_COUNT_INVOICE.Size = New System.Drawing.Size(240, 30)
        Me.PNL_COUNT_INVOICE.TabIndex = 12
        '
        'LBL_COUNT_INVOICE_UNIT
        '
        Me.LBL_COUNT_INVOICE_UNIT.AutoEllipsis = True
        Me.LBL_COUNT_INVOICE_UNIT.ForeColor = System.Drawing.Color.Black
        Me.LBL_COUNT_INVOICE_UNIT.Location = New System.Drawing.Point(140, 1)
        Me.LBL_COUNT_INVOICE_UNIT.Name = "LBL_COUNT_INVOICE_UNIT"
        Me.LBL_COUNT_INVOICE_UNIT.Size = New System.Drawing.Size(20, 25)
        Me.LBL_COUNT_INVOICE_UNIT.TabIndex = 9
        Me.LBL_COUNT_INVOICE_UNIT.Text = "回"
        Me.LBL_COUNT_INVOICE_UNIT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LBL_COUNT_INVOICE_GUIDE
        '
        Me.LBL_COUNT_INVOICE_GUIDE.AutoEllipsis = True
        Me.LBL_COUNT_INVOICE_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_COUNT_INVOICE_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_COUNT_INVOICE_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_COUNT_INVOICE_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_COUNT_INVOICE_GUIDE.Name = "LBL_COUNT_INVOICE_GUIDE"
        Me.LBL_COUNT_INVOICE_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_COUNT_INVOICE_GUIDE.TabIndex = 3
        Me.LBL_COUNT_INVOICE_GUIDE.Text = "既請求回数"
        Me.LBL_COUNT_INVOICE_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.GRP_HEAD.Size = New System.Drawing.Size(520, 50)
        Me.GRP_HEAD.TabIndex = 11
        Me.GRP_HEAD.TabStop = False
        '
        'PNL_INFO_GUIDE
        '
        Me.PNL_INFO_GUIDE.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PNL_INFO_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.PNL_INFO_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PNL_INFO_GUIDE.Controls.Add(Me.PNL_NAME_TITLE_HEAD)
        Me.PNL_INFO_GUIDE.Location = New System.Drawing.Point(10, 12)
        Me.PNL_INFO_GUIDE.Name = "PNL_INFO_GUIDE"
        Me.PNL_INFO_GUIDE.Size = New System.Drawing.Size(500, 34)
        Me.PNL_INFO_GUIDE.TabIndex = 6
        '
        'PNL_NAME_TITLE_HEAD
        '
        Me.PNL_NAME_TITLE_HEAD.Controls.Add(Me.LBL_NAME_TITLE_HEAD)
        Me.PNL_NAME_TITLE_HEAD.Controls.Add(Me.LBL_NAME_TITLE_HEAD_GUIDE)
        Me.PNL_NAME_TITLE_HEAD.Location = New System.Drawing.Point(5, 1)
        Me.PNL_NAME_TITLE_HEAD.Name = "PNL_NAME_TITLE_HEAD"
        Me.PNL_NAME_TITLE_HEAD.Size = New System.Drawing.Size(480, 30)
        Me.PNL_NAME_TITLE_HEAD.TabIndex = 9
        '
        'LBL_NAME_TITLE_HEAD
        '
        Me.LBL_NAME_TITLE_HEAD.AutoEllipsis = True
        Me.LBL_NAME_TITLE_HEAD.BackColor = System.Drawing.Color.White
        Me.LBL_NAME_TITLE_HEAD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_NAME_TITLE_HEAD.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBL_NAME_TITLE_HEAD.Location = New System.Drawing.Point(80, 1)
        Me.LBL_NAME_TITLE_HEAD.Name = "LBL_NAME_TITLE_HEAD"
        Me.LBL_NAME_TITLE_HEAD.Size = New System.Drawing.Size(390, 25)
        Me.LBL_NAME_TITLE_HEAD.TabIndex = 4
        Me.LBL_NAME_TITLE_HEAD.Tag = "Clear"
        Me.LBL_NAME_TITLE_HEAD.Text = "＊＊＊"
        Me.LBL_NAME_TITLE_HEAD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LBL_NAME_TITLE_HEAD_GUIDE
        '
        Me.LBL_NAME_TITLE_HEAD_GUIDE.AutoEllipsis = True
        Me.LBL_NAME_TITLE_HEAD_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_NAME_TITLE_HEAD_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_NAME_TITLE_HEAD_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_NAME_TITLE_HEAD_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_NAME_TITLE_HEAD_GUIDE.Name = "LBL_NAME_TITLE_HEAD_GUIDE"
        Me.LBL_NAME_TITLE_HEAD_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_NAME_TITLE_HEAD_GUIDE.TabIndex = 3
        Me.LBL_NAME_TITLE_HEAD_GUIDE.Text = "タイトル"
        Me.LBL_NAME_TITLE_HEAD_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LBL_COUNT_INVOICE_ALREADY
        '
        Me.LBL_COUNT_INVOICE_ALREADY.AutoEllipsis = True
        Me.LBL_COUNT_INVOICE_ALREADY.BackColor = System.Drawing.Color.White
        Me.LBL_COUNT_INVOICE_ALREADY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_COUNT_INVOICE_ALREADY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBL_COUNT_INVOICE_ALREADY.Location = New System.Drawing.Point(80, 1)
        Me.LBL_COUNT_INVOICE_ALREADY.Name = "LBL_COUNT_INVOICE_ALREADY"
        Me.LBL_COUNT_INVOICE_ALREADY.Size = New System.Drawing.Size(60, 25)
        Me.LBL_COUNT_INVOICE_ALREADY.TabIndex = 11
        Me.LBL_COUNT_INVOICE_ALREADY.Tag = "Clear"
        Me.LBL_COUNT_INVOICE_ALREADY.Text = "＊＊＊"
        Me.LBL_COUNT_INVOICE_ALREADY.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FRM_SUB_02
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(544, 521)
        Me.Controls.Add(Me.GRP_FOOT)
        Me.Controls.Add(Me.GRP_BODY)
        Me.Controls.Add(Me.GRP_HEAD)
        Me.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FRM_SUB_02"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "***"
        Me.GRP_FOOT.ResumeLayout(False)
        Me.pnlFUNCTION_GROUP.ResumeLayout(False)
        Me.pnlFUNCTION_GROUP.PerformLayout()
        Me.GRP_BODY.ResumeLayout(False)
        CType(Me.DGV_VIEW_DATA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PNL_INPUT_KEY.ResumeLayout(False)
        Me.PNL_COUNT_INVOICE.ResumeLayout(False)
        Me.GRP_HEAD.ResumeLayout(False)
        Me.PNL_INFO_GUIDE.ResumeLayout(False)
        Me.PNL_NAME_TITLE_HEAD.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GRP_FOOT As GroupBox
    Friend WithEvents pnlFUNCTION_GROUP As Panel
    Friend WithEvents BTN_OK As Button
    Friend WithEvents GRP_BODY As GroupBox
    Friend WithEvents PNL_INPUT_KEY As Panel
    Friend WithEvents PNL_COUNT_INVOICE As Panel
    Friend WithEvents LBL_COUNT_INVOICE_UNIT As Label
    Friend WithEvents LBL_COUNT_INVOICE_GUIDE As Label
    Friend WithEvents GRP_HEAD As GroupBox
    Friend WithEvents PNL_INFO_GUIDE As Panel
    Friend WithEvents PNL_NAME_TITLE_HEAD As Panel
    Friend WithEvents LBL_NAME_TITLE_HEAD As Label
    Friend WithEvents LBL_NAME_TITLE_HEAD_GUIDE As Label
    Friend WithEvents DGV_VIEW_DATA As DataGridView
    Friend WithEvents LBL_COUNT_INVOICE_ALREADY As Label
End Class
