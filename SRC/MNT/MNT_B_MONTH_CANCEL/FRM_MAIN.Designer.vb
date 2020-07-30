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
        Me.PNL_INPUT_DATA = New System.Windows.Forms.Panel()
        Me.PNL_BATCH_PROGRESS = New System.Windows.Forms.Panel()
        Me.LBL_BATCH_PROGRESS = New System.Windows.Forms.Label()
        Me.PNL_INPUT_KEY = New System.Windows.Forms.Panel()
        Me.PNL_CODE_YYYYMM_AFTER = New System.Windows.Forms.Panel()
        Me.LBL_CODE_YYYYMM_AFTER = New System.Windows.Forms.Label()
        Me.LBL_CODE_YYYYMM_AFTER_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_CODE_YYYYMM_BEFORE = New System.Windows.Forms.Panel()
        Me.LBL_CODE_YYYYMM_BEFORE = New System.Windows.Forms.Label()
        Me.LBL_CODE_YYYYMM_BEFORE_GUIDE = New System.Windows.Forms.Label()
        Me.GRP_FOOT = New System.Windows.Forms.GroupBox()
        Me.pnlFUNCTION_GROUP = New System.Windows.Forms.Panel()
        Me.BTN_BATCH = New System.Windows.Forms.Button()
        Me.BTN_END = New System.Windows.Forms.Button()
        Me.GRP_HEAD.SuspendLayout()
        Me.PNL_INFO_GUIDE.SuspendLayout()
        Me.PNL_NAME_USER_HEAD.SuspendLayout()
        Me.PNL_DATE_ACTIVE_HEAD.SuspendLayout()
        Me.GRP_BODY.SuspendLayout()
        Me.PNL_INPUT_DATA.SuspendLayout()
        Me.PNL_BATCH_PROGRESS.SuspendLayout()
        Me.PNL_INPUT_KEY.SuspendLayout()
        Me.PNL_CODE_YYYYMM_AFTER.SuspendLayout()
        Me.PNL_CODE_YYYYMM_BEFORE.SuspendLayout()
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
        Me.GRP_HEAD.TabIndex = 7
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
        Me.GRP_BODY.Controls.Add(Me.PNL_INPUT_DATA)
        Me.GRP_BODY.Controls.Add(Me.PNL_INPUT_KEY)
        Me.GRP_BODY.Location = New System.Drawing.Point(10, 60)
        Me.GRP_BODY.Name = "GRP_BODY"
        Me.GRP_BODY.Size = New System.Drawing.Size(760, 430)
        Me.GRP_BODY.TabIndex = 9
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
        Me.PNL_INPUT_KEY.Controls.Add(Me.PNL_CODE_YYYYMM_AFTER)
        Me.PNL_INPUT_KEY.Controls.Add(Me.PNL_CODE_YYYYMM_BEFORE)
        Me.PNL_INPUT_KEY.Location = New System.Drawing.Point(10, 20)
        Me.PNL_INPUT_KEY.Name = "PNL_INPUT_KEY"
        Me.PNL_INPUT_KEY.Size = New System.Drawing.Size(740, 350)
        Me.PNL_INPUT_KEY.TabIndex = 0
        '
        'PNL_CODE_YYYYMM_AFTER
        '
        Me.PNL_CODE_YYYYMM_AFTER.Controls.Add(Me.LBL_CODE_YYYYMM_AFTER)
        Me.PNL_CODE_YYYYMM_AFTER.Controls.Add(Me.LBL_CODE_YYYYMM_AFTER_GUIDE)
        Me.PNL_CODE_YYYYMM_AFTER.Location = New System.Drawing.Point(5, 40)
        Me.PNL_CODE_YYYYMM_AFTER.Name = "PNL_CODE_YYYYMM_AFTER"
        Me.PNL_CODE_YYYYMM_AFTER.Size = New System.Drawing.Size(240, 30)
        Me.PNL_CODE_YYYYMM_AFTER.TabIndex = 1
        '
        'LBL_CODE_YYYYMM_AFTER
        '
        Me.LBL_CODE_YYYYMM_AFTER.AutoEllipsis = True
        Me.LBL_CODE_YYYYMM_AFTER.BackColor = System.Drawing.Color.White
        Me.LBL_CODE_YYYYMM_AFTER.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_CODE_YYYYMM_AFTER.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBL_CODE_YYYYMM_AFTER.Location = New System.Drawing.Point(80, 1)
        Me.LBL_CODE_YYYYMM_AFTER.Name = "LBL_CODE_YYYYMM_AFTER"
        Me.LBL_CODE_YYYYMM_AFTER.Size = New System.Drawing.Size(150, 25)
        Me.LBL_CODE_YYYYMM_AFTER.TabIndex = 5
        Me.LBL_CODE_YYYYMM_AFTER.Tag = "Clear"
        Me.LBL_CODE_YYYYMM_AFTER.Text = "＊＊＊"
        Me.LBL_CODE_YYYYMM_AFTER.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LBL_CODE_YYYYMM_AFTER_GUIDE
        '
        Me.LBL_CODE_YYYYMM_AFTER_GUIDE.AutoEllipsis = True
        Me.LBL_CODE_YYYYMM_AFTER_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_CODE_YYYYMM_AFTER_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_CODE_YYYYMM_AFTER_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_CODE_YYYYMM_AFTER_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_CODE_YYYYMM_AFTER_GUIDE.Name = "LBL_CODE_YYYYMM_AFTER_GUIDE"
        Me.LBL_CODE_YYYYMM_AFTER_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_CODE_YYYYMM_AFTER_GUIDE.TabIndex = 0
        Me.LBL_CODE_YYYYMM_AFTER_GUIDE.Text = "更新後月次"
        Me.LBL_CODE_YYYYMM_AFTER_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PNL_CODE_YYYYMM_BEFORE
        '
        Me.PNL_CODE_YYYYMM_BEFORE.Controls.Add(Me.LBL_CODE_YYYYMM_BEFORE)
        Me.PNL_CODE_YYYYMM_BEFORE.Controls.Add(Me.LBL_CODE_YYYYMM_BEFORE_GUIDE)
        Me.PNL_CODE_YYYYMM_BEFORE.Location = New System.Drawing.Point(5, 5)
        Me.PNL_CODE_YYYYMM_BEFORE.Name = "PNL_CODE_YYYYMM_BEFORE"
        Me.PNL_CODE_YYYYMM_BEFORE.Size = New System.Drawing.Size(240, 30)
        Me.PNL_CODE_YYYYMM_BEFORE.TabIndex = 0
        '
        'LBL_CODE_YYYYMM_BEFORE
        '
        Me.LBL_CODE_YYYYMM_BEFORE.AutoEllipsis = True
        Me.LBL_CODE_YYYYMM_BEFORE.BackColor = System.Drawing.Color.White
        Me.LBL_CODE_YYYYMM_BEFORE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_CODE_YYYYMM_BEFORE.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBL_CODE_YYYYMM_BEFORE.Location = New System.Drawing.Point(80, 1)
        Me.LBL_CODE_YYYYMM_BEFORE.Name = "LBL_CODE_YYYYMM_BEFORE"
        Me.LBL_CODE_YYYYMM_BEFORE.Size = New System.Drawing.Size(150, 25)
        Me.LBL_CODE_YYYYMM_BEFORE.TabIndex = 5
        Me.LBL_CODE_YYYYMM_BEFORE.Tag = "Clear"
        Me.LBL_CODE_YYYYMM_BEFORE.Text = "＊＊＊"
        Me.LBL_CODE_YYYYMM_BEFORE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LBL_CODE_YYYYMM_BEFORE_GUIDE
        '
        Me.LBL_CODE_YYYYMM_BEFORE_GUIDE.AutoEllipsis = True
        Me.LBL_CODE_YYYYMM_BEFORE_GUIDE.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LBL_CODE_YYYYMM_BEFORE_GUIDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_CODE_YYYYMM_BEFORE_GUIDE.ForeColor = System.Drawing.Color.Black
        Me.LBL_CODE_YYYYMM_BEFORE_GUIDE.Location = New System.Drawing.Point(1, 1)
        Me.LBL_CODE_YYYYMM_BEFORE_GUIDE.Name = "LBL_CODE_YYYYMM_BEFORE_GUIDE"
        Me.LBL_CODE_YYYYMM_BEFORE_GUIDE.Size = New System.Drawing.Size(79, 25)
        Me.LBL_CODE_YYYYMM_BEFORE_GUIDE.TabIndex = 0
        Me.LBL_CODE_YYYYMM_BEFORE_GUIDE.Text = "確定月次"
        Me.LBL_CODE_YYYYMM_BEFORE_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.GRP_FOOT.TabIndex = 10
        Me.GRP_FOOT.TabStop = False
        '
        'pnlFUNCTION_GROUP
        '
        Me.pnlFUNCTION_GROUP.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnlFUNCTION_GROUP.AutoScroll = True
        Me.pnlFUNCTION_GROUP.Controls.Add(Me.BTN_BATCH)
        Me.pnlFUNCTION_GROUP.Controls.Add(Me.BTN_END)
        Me.pnlFUNCTION_GROUP.Location = New System.Drawing.Point(290, 15)
        Me.pnlFUNCTION_GROUP.MinimumSize = New System.Drawing.Size(185, 40)
        Me.pnlFUNCTION_GROUP.Name = "pnlFUNCTION_GROUP"
        Me.pnlFUNCTION_GROUP.Size = New System.Drawing.Size(185, 40)
        Me.pnlFUNCTION_GROUP.TabIndex = 0
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
        Me.BTN_END.Location = New System.Drawing.Point(95, 5)
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
        Me.Text = "**"
        Me.GRP_HEAD.ResumeLayout(False)
        Me.PNL_INFO_GUIDE.ResumeLayout(False)
        Me.PNL_NAME_USER_HEAD.ResumeLayout(False)
        Me.PNL_DATE_ACTIVE_HEAD.ResumeLayout(False)
        Me.GRP_BODY.ResumeLayout(False)
        Me.PNL_INPUT_DATA.ResumeLayout(False)
        Me.PNL_BATCH_PROGRESS.ResumeLayout(False)
        Me.PNL_BATCH_PROGRESS.PerformLayout()
        Me.PNL_INPUT_KEY.ResumeLayout(False)
        Me.PNL_CODE_YYYYMM_AFTER.ResumeLayout(False)
        Me.PNL_CODE_YYYYMM_BEFORE.ResumeLayout(False)
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
    Friend WithEvents PNL_INPUT_DATA As Panel
    Friend WithEvents PNL_BATCH_PROGRESS As Panel
    Friend WithEvents LBL_BATCH_PROGRESS As Label
    Friend WithEvents PNL_INPUT_KEY As Panel
    Friend WithEvents PNL_CODE_YYYYMM_AFTER As Panel
    Friend WithEvents LBL_CODE_YYYYMM_AFTER As Label
    Friend WithEvents LBL_CODE_YYYYMM_AFTER_GUIDE As Label
    Friend WithEvents PNL_CODE_YYYYMM_BEFORE As Panel
    Friend WithEvents LBL_CODE_YYYYMM_BEFORE As Label
    Friend WithEvents LBL_CODE_YYYYMM_BEFORE_GUIDE As Label
    Friend WithEvents GRP_FOOT As GroupBox
    Friend WithEvents pnlFUNCTION_GROUP As Panel
    Friend WithEvents BTN_BATCH As Button
    Friend WithEvents BTN_END As Button
End Class
