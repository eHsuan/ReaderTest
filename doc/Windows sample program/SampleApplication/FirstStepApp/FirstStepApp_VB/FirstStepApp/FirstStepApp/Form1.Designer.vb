<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.SchBtn = New System.Windows.Forms.Button()
        Me.comboBox1 = New System.Windows.Forms.ComboBox()
        Me.DataText = New System.Windows.Forms.TextBox()
        Me.TgrBtn = New System.Windows.Forms.Button()
        Me.liveviewForm1 = New Keyence.AutoID.SDK.LiveviewForm()
        Me.SctBtn = New System.Windows.Forms.CheckBox()
        Me.NICcomboBox = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'SchBtn
        '
        Me.SchBtn.Location = New System.Drawing.Point(166, 8)
        Me.SchBtn.Name = "SchBtn"
        Me.SchBtn.Size = New System.Drawing.Size(83, 23)
        Me.SchBtn.TabIndex = 13
        Me.SchBtn.Text = "Search"
        Me.SchBtn.UseVisualStyleBackColor = True
        '
        'comboBox1
        '
        Me.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboBox1.FormattingEnabled = True
        Me.comboBox1.Location = New System.Drawing.Point(10, 37)
        Me.comboBox1.Name = "comboBox1"
        Me.comboBox1.Size = New System.Drawing.Size(150, 20)
        Me.comboBox1.TabIndex = 12
        '
        'DataText
        '
        Me.DataText.BackColor = System.Drawing.SystemColors.Control
        Me.DataText.Location = New System.Drawing.Point(10, 321)
        Me.DataText.MaxLength = 10
        Me.DataText.Name = "DataText"
        Me.DataText.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.DataText.Size = New System.Drawing.Size(334, 19)
        Me.DataText.TabIndex = 11
        '
        'TgrBtn
        '
        Me.TgrBtn.Enabled = False
        Me.TgrBtn.Location = New System.Drawing.Point(10, 62)
        Me.TgrBtn.Name = "TgrBtn"
        Me.TgrBtn.Size = New System.Drawing.Size(103, 26)
        Me.TgrBtn.TabIndex = 10
        Me.TgrBtn.Text = "Trigger On"
        Me.TgrBtn.UseVisualStyleBackColor = True
        '
        'liveviewForm1
        '
        Me.liveviewForm1.BackColor = System.Drawing.Color.Black
        Me.liveviewForm1.BinningType = Keyence.AutoID.SDK.LiveviewForm.ImageBinningType.OneQuarter
        Me.liveviewForm1.ImageFormat = Keyence.AutoID.SDK.LiveviewForm.ImageFormatType.Jpeg
        Me.liveviewForm1.ImageQuality = 5
        Me.liveviewForm1.IpAddress = "192.168.100.100"
        Me.liveviewForm1.Location = New System.Drawing.Point(10, 94)
        Me.liveviewForm1.Name = "liveviewForm1"
        Me.liveviewForm1.PullTimeSpan = 100
        Me.liveviewForm1.Size = New System.Drawing.Size(334, 219)
        Me.liveviewForm1.TabIndex = 8
        Me.liveviewForm1.TimeoutMs = 2000
        '
        'SctBtn
        '
        Me.SctBtn.Appearance = System.Windows.Forms.Appearance.Button
        Me.SctBtn.AutoSize = True
        Me.SctBtn.Enabled = False
        Me.SctBtn.Location = New System.Drawing.Point(166, 37)
        Me.SctBtn.Name = "SctBtn"
        Me.SctBtn.Size = New System.Drawing.Size(83, 22)
        Me.SctBtn.TabIndex = 14
        Me.SctBtn.Text = "ReaderSelect"
        Me.SctBtn.UseVisualStyleBackColor = True
        '
        'NICcomboBox
        '
        Me.NICcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.NICcomboBox.FormattingEnabled = True
        Me.NICcomboBox.Location = New System.Drawing.Point(13, 8)
        Me.NICcomboBox.Name = "NICcomboBox"
        Me.NICcomboBox.Size = New System.Drawing.Size(147, 20)
        Me.NICcomboBox.TabIndex = 15
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(354, 348)
        Me.Controls.Add(Me.NICcomboBox)
        Me.Controls.Add(Me.SctBtn)
        Me.Controls.Add(Me.SchBtn)
        Me.Controls.Add(Me.comboBox1)
        Me.Controls.Add(Me.DataText)
        Me.Controls.Add(Me.TgrBtn)
        Me.Controls.Add(Me.liveviewForm1)
        Me.Name = "Form1"
        Me.Text = "FirstStepApp"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents SchBtn As Button
    Private WithEvents comboBox1 As ComboBox
    Private WithEvents DataText As TextBox
    Private WithEvents TgrBtn As Button
    Private WithEvents liveviewForm1 As Keyence.AutoID.SDK.LiveviewForm
    Private WithEvents SctBtn As CheckBox
    Friend WithEvents NICcomboBox As ComboBox
End Class
