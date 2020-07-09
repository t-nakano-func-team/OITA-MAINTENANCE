<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRM_SUB_01
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
        Me.GRP_FOOT = New System.Windows.Forms.GroupBox()
        Me.PNL_FUNCTION_GROUP = New System.Windows.Forms.Panel()
        Me.BTN_CANCEL = New System.Windows.Forms.Button()
        Me.BTN_OK = New System.Windows.Forms.Button()
        Me.GRP_HEAD = New System.Windows.Forms.GroupBox()
        Me.PNL_TITLE = New System.Windows.Forms.Panel()
        Me.LBL_TITLE = New System.Windows.Forms.Label()
        Me.GRP_BODY = New System.Windows.Forms.GroupBox()
        Me.PNL_DATE_ACTIVE = New System.Windows.Forms.Panel()
        Me.DTP_DATE_ACTIVE = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PNL_KIND_SORT = New System.Windows.Forms.Panel()
        Me.CHK_DATE_ACTIVE_INSERT = New System.Windows.Forms.CheckBox()
        Me.LBL_KIND_SORT_GUIDE = New System.Windows.Forms.Label()
        Me.GRP_FOOT.SuspendLayout()
        Me.PNL_FUNCTION_GROUP.SuspendLayout()
        Me.GRP_HEAD.SuspendLayout()
        Me.PNL_TITLE.SuspendLayout()
        Me.GRP_BODY.SuspendLayout()
        Me.PNL_DATE_ACTIVE.SuspendLayout()
        Me.PNL_KIND_SORT.SuspendLayout()
        Me.SuspendLayout()
        '
        'GRP_FOOT
        '
        Me.GRP_FOOT.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GRP_FOOT.Controls.Add(Me.PNL_FUNCTION_GROUP)
        Me.GRP_FOOT.Location = New System.Drawing.Point(10, 150)
        Me.GRP_FOOT.Name = "GRP_FOOT"
        Me.GRP_FOOT.Size = New System.Drawing.Size(280, 60)
        Me.GRP_FOOT.TabIndex = 2
        Me.GRP_FOOT.TabStop = False
        '
        'PNL_FUNCTION_GROUP
        '
        Me.PNL_FUNCTION_GROUP.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PNL_FUNCTION_GROUP.AutoScroll = True
        Me.PNL_FUNCTION_GROUP.Controls.Add(Me.BTN_CANCEL)
        Me.PNL_FUNCTION_GROUP.Controls.Add(Me.BTN_OK)
        Me.PNL_FUNCTION_GROUP.Location = New System.Drawing.Point(40, 16)
        Me.PNL_FUNCTION_GROUP.MinimumSize = New System.Drawing.Size(190, 40)
        Me.PNL_FUNCTION_GROUP.Name = "PNL_FUNCTION_GROUP"
        Me.PNL_FUNCTION_GROUP.Size = New System.Drawing.Size(190, 40)
        Me.PNL_FUNCTION_GROUP.TabIndex = 0
        '
        'BTN_CANCEL
        '
        Me.BTN_CANCEL.AutoSize = True
        Me.BTN_CANCEL.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_CANCEL.Location = New System.Drawing.Point(100, 4)
        Me.BTN_CANCEL.MinimumSize = New System.Drawing.Size(80, 30)
        Me.BTN_CANCEL.Name = "BTN_CANCEL"
        Me.BTN_CANCEL.Size = New System.Drawing.Size(80, 30)
        Me.BTN_CANCEL.TabIndex = 1
        Me.BTN_CANCEL.Text = "キャンセル"
        Me.BTN_CANCEL.UseVisualStyleBackColor = False
        '
        'BTN_OK
        '
        Me.BTN_OK.AutoSize = True
        Me.BTN_OK.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BTN_OK.Location = New System.Drawing.Point(10, 4)
        Me.BTN_OK.MinimumSize = New System.Drawing.Size(80, 30)
        Me.BTN_OK.Name = "BTN_OK"
        Me.BTN_OK.Size = New System.Drawing.Size(80, 30)
        Me.BTN_OK.TabIndex = 0
        Me.BTN_OK.Text = "OK"
        Me.BTN_OK.UseVisualStyleBackColor = False
        '
        'GRP_HEAD
        '
        Me.GRP_HEAD.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GRP_HEAD.Controls.Add(Me.PNL_TITLE)
        Me.GRP_HEAD.Location = New System.Drawing.Point(10, 10)
        Me.GRP_HEAD.Name = "GRP_HEAD"
        Me.GRP_HEAD.Size = New System.Drawing.Size(280, 50)
        Me.GRP_HEAD.TabIndex = 0
        Me.GRP_HEAD.TabStop = False
        '
        'PNL_TITLE
        '
        Me.PNL_TITLE.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.PNL_TITLE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PNL_TITLE.Controls.Add(Me.LBL_TITLE)
        Me.PNL_TITLE.Location = New System.Drawing.Point(10, 12)
        Me.PNL_TITLE.Name = "PNL_TITLE"
        Me.PNL_TITLE.Size = New System.Drawing.Size(260, 34)
        Me.PNL_TITLE.TabIndex = 2
        '
        'LBL_TITLE
        '
        Me.LBL_TITLE.Location = New System.Drawing.Point(5, 8)
        Me.LBL_TITLE.Name = "LBL_TITLE"
        Me.LBL_TITLE.Size = New System.Drawing.Size(250, 18)
        Me.LBL_TITLE.TabIndex = 0
        Me.LBL_TITLE.Text = "処理日設定"
        Me.LBL_TITLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GRP_BODY
        '
        Me.GRP_BODY.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GRP_BODY.Controls.Add(Me.PNL_DATE_ACTIVE)
        Me.GRP_BODY.Controls.Add(Me.PNL_KIND_SORT)
        Me.GRP_BODY.Location = New System.Drawing.Point(10, 60)
        Me.GRP_BODY.Name = "GRP_BODY"
        Me.GRP_BODY.Size = New System.Drawing.Size(280, 90)
        Me.GRP_BODY.TabIndex = 1
        Me.GRP_BODY.TabStop = False
        '
        'PNL_DATE_ACTIVE
        '
        Me.PNL_DATE_ACTIVE.Controls.Add(Me.DTP_DATE_ACTIVE)
        Me.PNL_DATE_ACTIVE.Controls.Add(Me.Label1)
        Me.PNL_DATE_ACTIVE.Location = New System.Drawing.Point(10, 50)
        Me.PNL_DATE_ACTIVE.Name = "PNL_DATE_ACTIVE"
        Me.PNL_DATE_ACTIVE.Size = New System.Drawing.Size(240, 30)
        Me.PNL_DATE_ACTIVE.TabIndex = 1
        '
        'DTP_DATE_ACTIVE
        '
        Me.DTP_DATE_ACTIVE.Location = New System.Drawing.Point(80, 2)
        Me.DTP_DATE_ACTIVE.Name = "DTP_DATE_ACTIVE"
        Me.DTP_DATE_ACTIVE.Size = New System.Drawing.Size(123, 25)
        Me.DTP_DATE_ACTIVE.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoEllipsis = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(1, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "処理日付"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PNL_KIND_SORT
        '
        Me.PNL_KIND_SORT.Controls.Add(Me.CHK_DATE_ACTIVE_INSERT)
        Me.PNL_KIND_SORT.Controls.Add(Me.LBL_KIND_SORT_GUIDE)
        Me.PNL_KIND_SORT.Location = New System.Drawing.Point(10, 15)
        Me.PNL_KIND_SORT.Name = "PNL_KIND_SORT"
        Me.PNL_KIND_SORT.Size = New System.Drawing.Size(240, 30)
        Me.PNL_KIND_SORT.TabIndex = 0
        '
        'CHK_DATE_ACTIVE_INSERT
        '
        Me.CHK_DATE_ACTIVE_INSERT.AutoSize = True
        Me.CHK_DATE_ACTIVE_INSERT.Location = New System.Drawing.Point(85, 3)
        Me.CHK_DATE_ACTIVE_INSERT.Name = "CHK_DATE_ACTIVE_INSERT"
        Me.CHK_DATE_ACTIVE_INSERT.Size = New System.Drawing.Size(135, 22)
        Me.CHK_DATE_ACTIVE_INSERT.TabIndex = 1
        Me.CHK_DATE_ACTIVE_INSERT.Text = "処理日付を固定する"
        Me.CHK_DATE_ACTIVE_INSERT.UseVisualStyleBackColor = True
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
        Me.LBL_KIND_SORT_GUIDE.Text = "設定"
        Me.LBL_KIND_SORT_GUIDE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FRM_SUB_01
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(304, 221)
        Me.Controls.Add(Me.GRP_BODY)
        Me.Controls.Add(Me.GRP_HEAD)
        Me.Controls.Add(Me.GRP_FOOT)
        Me.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FRM_SUB_01"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "**"
        Me.GRP_FOOT.ResumeLayout(False)
        Me.PNL_FUNCTION_GROUP.ResumeLayout(False)
        Me.PNL_FUNCTION_GROUP.PerformLayout()
        Me.GRP_HEAD.ResumeLayout(False)
        Me.PNL_TITLE.ResumeLayout(False)
        Me.GRP_BODY.ResumeLayout(False)
        Me.PNL_DATE_ACTIVE.ResumeLayout(False)
        Me.PNL_KIND_SORT.ResumeLayout(False)
        Me.PNL_KIND_SORT.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GRP_FOOT As GroupBox
    Friend WithEvents PNL_FUNCTION_GROUP As Panel
    Friend WithEvents BTN_CANCEL As Button
    Friend WithEvents BTN_OK As Button
    Friend WithEvents GRP_HEAD As GroupBox
    Friend WithEvents PNL_TITLE As Panel
    Friend WithEvents LBL_TITLE As Label
    Friend WithEvents GRP_BODY As GroupBox
    Friend WithEvents PNL_DATE_ACTIVE As Panel
    Friend WithEvents DTP_DATE_ACTIVE As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents PNL_KIND_SORT As Panel
    Friend WithEvents CHK_DATE_ACTIVE_INSERT As CheckBox
    Friend WithEvents LBL_KIND_SORT_GUIDE As Label
End Class
