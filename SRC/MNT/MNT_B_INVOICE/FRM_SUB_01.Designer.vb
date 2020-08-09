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
        Me.PNL_NAME_TITLE_HEAD = New System.Windows.Forms.Panel()
        Me.LBL_NAME_TITLE_HEAD = New System.Windows.Forms.Label()
        Me.LBL_NAME_TITLE_HEAD_GUIDE = New System.Windows.Forms.Label()
        Me.GRP_BODY = New System.Windows.Forms.GroupBox()
        Me.PNL_INPUT_KEY = New System.Windows.Forms.Panel()
        Me.PNL_KINGAKU_INVOICE = New System.Windows.Forms.Panel()
        Me.LBL_KINGAKU_INVOICE_TOTAL = New System.Windows.Forms.Label()
        Me.TXT_KINGAKU_INVOICE_VAT = New System.Windows.Forms.TextBox()
        Me.LBL_KINGAKU_INVOICE_GUIDE = New System.Windows.Forms.Label()
        Me.TXT_KINGAKU_INVOICE_DETAIL = New System.Windows.Forms.TextBox()
        Me.PNL_CODE_SECTION = New System.Windows.Forms.Panel()
        Me.CMB_CODE_SECTION = New System.Windows.Forms.ComboBox()
        Me.LBL_CODE_SECTION_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_EDIT_INVOICE = New System.Windows.Forms.Panel()
        Me.CHK_EDIT_INVOICE = New System.Windows.Forms.CheckBox()
        Me.LBL_KIND_SORT_GUIDE = New System.Windows.Forms.Label()
        Me.GRP_FOOT = New System.Windows.Forms.GroupBox()
        Me.pnlFUNCTION_GROUP = New System.Windows.Forms.Panel()
        Me.BTN_OK = New System.Windows.Forms.Button()
        Me.BTN_CANCEL = New System.Windows.Forms.Button()
        Me.GRP_HEAD.SuspendLayout()
        Me.PNL_INFO_GUIDE.SuspendLayout()
        Me.PNL_NAME_TITLE_HEAD.SuspendLayout()
        Me.GRP_BODY.SuspendLayout()
        Me.PNL_INPUT_KEY.SuspendLayout()
        Me.PNL_KINGAKU_INVOICE.SuspendLayout()
        Me.PNL_CODE_SECTION.SuspendLayout()
        Me.PNL_EDIT_INVOICE.SuspendLayout()
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
        Me.GRP_HEAD.Size = New System.Drawing.Size(520, 50)
        Me.GRP_HEAD.TabIndex = 6
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
        Me.PNL_NAME_TITLE_HEAD.Size = New System.Drawing.Size(240, 30)
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
        Me.LBL_NAME_TITLE_HEAD.Size = New System.Drawing.Size(150, 25)
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
        'GRP_BODY
        '
        Me.GRP_BODY.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GRP_BODY.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.GRP_BODY.Controls.Add(Me.PNL_INPUT_KEY)
        Me.GRP_BODY.Location = New System.Drawing.Point(10, 60)
        Me.GRP_BODY.Name = "GRP_BODY"
        Me.GRP_BODY.Size = New System.Drawing.Size(520, 140)
        Me.GRP_BODY.TabIndex = 8
        Me.GRP_BODY.TabStop = False
        '
        'PNL_INPUT_KEY
        '
        Me.PNL_INPUT_KEY.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PNL_INPUT_KEY.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.PNL_INPUT_KEY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PNL_INPUT_KEY.Controls.Add(Me.PNL_KINGAKU_INVOICE)
        Me.PNL_INPUT_KEY.Controls.Add(Me.PNL_CODE_SECTION)
        Me.PNL_INPUT_KEY.Controls.Add(Me.PNL_EDIT_INVOICE)
        Me.PNL_INPUT_KEY.Location = New System.Drawing.Point(10, 20)
        Me.PNL_INPUT_KEY.Name = "PNL_INPUT_KEY"
        Me.PNL_INPUT_KEY.Size = New System.Drawing.Size(500, 110)
        Me.PNL_INPUT_KEY.TabIndex = 0
        '
        'PNL_KINGAKU_INVOICE
        '
        Me.PNL_KINGAKU_INVOICE.Controls.Add(Me.LBL_KINGAKU_INVOICE_TOTAL)
        Me.PNL_KINGAKU_INVOICE.Controls.Add(Me.TXT_KINGAKU_INVOICE_VAT)
        Me.PNL_KINGAKU_INVOICE.Controls.Add(Me.LBL_KINGAKU_INVOICE_GUIDE)
        Me.PNL_KINGAKU_INVOICE.Controls.Add(Me.TXT_KINGAKU_INVOICE_DETAIL)
        Me.PNL_KINGAKU_INVOICE.Location = New System.Drawing.Point(5, 75)
        Me.PNL_KINGAKU_INVOICE.Name = "PNL_KINGAKU_INVOICE"
        Me.PNL_KINGAKU_INVOICE.Size = New System.Drawing.Size(485, 30)
        Me.PNL_KINGAKU_INVOICE.TabIndex = 6
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
        Me.TXT_KINGAKU_INVOICE_VAT.Location = New System.Drawing.Point(230, 1)
        Me.TXT_KINGAKU_INVOICE_VAT.MaxLength = 9
        Me.TXT_KINGAKU_INVOICE_VAT.Name = "TXT_KINGAKU_INVOICE_VAT"
        Me.TXT_KINGAKU_INVOICE_VAT.Size = New System.Drawing.Size(95, 25)
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
        Me.LBL_KINGAKU_INVOICE_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_KINGAKU_INVOICE_GUIDE.TabIndex = 3
        Me.LBL_KINGAKU_INVOICE_GUIDE.Text = "請求金額"
        Me.LBL_KINGAKU_INVOICE_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXT_KINGAKU_INVOICE_DETAIL
        '
        Me.TXT_KINGAKU_INVOICE_DETAIL.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TXT_KINGAKU_INVOICE_DETAIL.Location = New System.Drawing.Point(80, 1)
        Me.TXT_KINGAKU_INVOICE_DETAIL.MaxLength = 9
        Me.TXT_KINGAKU_INVOICE_DETAIL.Name = "TXT_KINGAKU_INVOICE_DETAIL"
        Me.TXT_KINGAKU_INVOICE_DETAIL.Size = New System.Drawing.Size(150, 25)
        Me.TXT_KINGAKU_INVOICE_DETAIL.TabIndex = 1
        Me.TXT_KINGAKU_INVOICE_DETAIL.Tag = "Clear,Numeric,Format=#@##0,Check,NotNull,Plus"
        Me.TXT_KINGAKU_INVOICE_DETAIL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PNL_CODE_SECTION
        '
        Me.PNL_CODE_SECTION.Controls.Add(Me.CMB_CODE_SECTION)
        Me.PNL_CODE_SECTION.Controls.Add(Me.LBL_CODE_SECTION_GUIDE)
        Me.PNL_CODE_SECTION.Location = New System.Drawing.Point(5, 40)
        Me.PNL_CODE_SECTION.Name = "PNL_CODE_SECTION"
        Me.PNL_CODE_SECTION.Size = New System.Drawing.Size(240, 30)
        Me.PNL_CODE_SECTION.TabIndex = 5
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
        'PNL_EDIT_INVOICE
        '
        Me.PNL_EDIT_INVOICE.Controls.Add(Me.CHK_EDIT_INVOICE)
        Me.PNL_EDIT_INVOICE.Controls.Add(Me.LBL_KIND_SORT_GUIDE)
        Me.PNL_EDIT_INVOICE.Location = New System.Drawing.Point(5, 5)
        Me.PNL_EDIT_INVOICE.Name = "PNL_EDIT_INVOICE"
        Me.PNL_EDIT_INVOICE.Size = New System.Drawing.Size(240, 30)
        Me.PNL_EDIT_INVOICE.TabIndex = 1
        '
        'CHK_EDIT_INVOICE
        '
        Me.CHK_EDIT_INVOICE.AutoSize = True
        Me.CHK_EDIT_INVOICE.Location = New System.Drawing.Point(85, 3)
        Me.CHK_EDIT_INVOICE.Name = "CHK_EDIT_INVOICE"
        Me.CHK_EDIT_INVOICE.Size = New System.Drawing.Size(135, 22)
        Me.CHK_EDIT_INVOICE.TabIndex = 1
        Me.CHK_EDIT_INVOICE.Text = "請求情報を訂正する"
        Me.CHK_EDIT_INVOICE.UseVisualStyleBackColor = True
        '
        'LBL_KIND_SORT_GUIDE
        '
        Me.LBL_KIND_SORT_GUIDE.AutoEllipsis = True
        Me.LBL_KIND_SORT_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_KIND_SORT_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_KIND_SORT_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_KIND_SORT_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_KIND_SORT_GUIDE.Name = "LBL_KIND_SORT_GUIDE"
        Me.LBL_KIND_SORT_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_KIND_SORT_GUIDE.TabIndex = 0
        Me.LBL_KIND_SORT_GUIDE.Text = "訂正有無"
        Me.LBL_KIND_SORT_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GRP_FOOT
        '
        Me.GRP_FOOT.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GRP_FOOT.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.GRP_FOOT.Controls.Add(Me.pnlFUNCTION_GROUP)
        Me.GRP_FOOT.Location = New System.Drawing.Point(10, 200)
        Me.GRP_FOOT.Name = "GRP_FOOT"
        Me.GRP_FOOT.Size = New System.Drawing.Size(520, 60)
        Me.GRP_FOOT.TabIndex = 9
        Me.GRP_FOOT.TabStop = False
        '
        'pnlFUNCTION_GROUP
        '
        Me.pnlFUNCTION_GROUP.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnlFUNCTION_GROUP.AutoScroll = True
        Me.pnlFUNCTION_GROUP.Controls.Add(Me.BTN_OK)
        Me.pnlFUNCTION_GROUP.Controls.Add(Me.BTN_CANCEL)
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
        Me.BTN_CANCEL.Location = New System.Drawing.Point(90, 5)
        Me.BTN_CANCEL.MinimumSize = New System.Drawing.Size(80, 30)
        Me.BTN_CANCEL.Name = "BTN_CANCEL"
        Me.BTN_CANCEL.Size = New System.Drawing.Size(80, 30)
        Me.BTN_CANCEL.TabIndex = 4
        Me.BTN_CANCEL.Text = "キャンセル"
        Me.BTN_CANCEL.UseVisualStyleBackColor = False
        '
        'FRM_SUB_01
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(544, 271)
        Me.Controls.Add(Me.GRP_FOOT)
        Me.Controls.Add(Me.GRP_BODY)
        Me.Controls.Add(Me.GRP_HEAD)
        Me.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FRM_SUB_01"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FRM_SUB_01"
        Me.GRP_HEAD.ResumeLayout(False)
        Me.PNL_INFO_GUIDE.ResumeLayout(False)
        Me.PNL_NAME_TITLE_HEAD.ResumeLayout(False)
        Me.GRP_BODY.ResumeLayout(False)
        Me.PNL_INPUT_KEY.ResumeLayout(False)
        Me.PNL_KINGAKU_INVOICE.ResumeLayout(False)
        Me.PNL_KINGAKU_INVOICE.PerformLayout()
        Me.PNL_CODE_SECTION.ResumeLayout(False)
        Me.PNL_EDIT_INVOICE.ResumeLayout(False)
        Me.PNL_EDIT_INVOICE.PerformLayout()
        Me.GRP_FOOT.ResumeLayout(False)
        Me.pnlFUNCTION_GROUP.ResumeLayout(False)
        Me.pnlFUNCTION_GROUP.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GRP_HEAD As GroupBox
    Friend WithEvents PNL_INFO_GUIDE As Panel
    Friend WithEvents PNL_NAME_TITLE_HEAD As Panel
    Friend WithEvents LBL_NAME_TITLE_HEAD As Label
    Friend WithEvents LBL_NAME_TITLE_HEAD_GUIDE As Label
    Friend WithEvents GRP_BODY As GroupBox
    Friend WithEvents PNL_INPUT_KEY As Panel
    Friend WithEvents GRP_FOOT As GroupBox
    Friend WithEvents pnlFUNCTION_GROUP As Panel
    Friend WithEvents BTN_OK As Button
    Friend WithEvents BTN_CANCEL As Button
    Friend WithEvents PNL_EDIT_INVOICE As Panel
    Friend WithEvents CHK_EDIT_INVOICE As CheckBox
    Friend WithEvents LBL_KIND_SORT_GUIDE As Label
    Friend WithEvents PNL_CODE_SECTION As Panel
    Friend WithEvents CMB_CODE_SECTION As ComboBox
    Friend WithEvents LBL_CODE_SECTION_GUIDE As Label
    Friend WithEvents PNL_KINGAKU_INVOICE As Panel
    Friend WithEvents LBL_KINGAKU_INVOICE_TOTAL As Label
    Friend WithEvents TXT_KINGAKU_INVOICE_VAT As TextBox
    Friend WithEvents LBL_KINGAKU_INVOICE_GUIDE As Label
    Friend WithEvents TXT_KINGAKU_INVOICE_DETAIL As TextBox
End Class
