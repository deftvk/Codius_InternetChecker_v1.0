<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfig
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfig))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtServers = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCount = New System.Windows.Forms.TextBox()
        Me.chkSaveToFile = New System.Windows.Forms.CheckBox()
        Me.btnOpenLog = New System.Windows.Forms.Button()
        Me.chkMinimizeToTray = New System.Windows.Forms.CheckBox()
        Me.chkStartWithWin = New System.Windows.Forms.CheckBox()
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.chkShowBubbles = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.pnlButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 137.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.52968!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.47032!))
        Me.TableLayoutPanel1.Controls.Add(Me.txtServers, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtCount, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.chkSaveToFile, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.btnOpenLog, 3, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.chkMinimizeToTray, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.chkStartWithWin, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.chkShowBubbles, 0, 6)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.Padding = New System.Windows.Forms.Padding(10)
        Me.TableLayoutPanel1.RowCount = 8
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(415, 292)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'txtServers
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtServers, 4)
        Me.txtServers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtServers.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtServers.Location = New System.Drawing.Point(13, 69)
        Me.txtServers.Multiline = True
        Me.txtServers.Name = "txtServers"
        Me.txtServers.Size = New System.Drawing.Size(389, 102)
        Me.txtServers.TabIndex = 2
        Me.txtServers.Text = "http://www.ya.ru" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "http://www.google.ru"
        '
        'Label1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label1, 4)
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(13, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(389, 26)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Использовать следующие серверы для проверки соединения (по одному в каждой строке" & _
    "):"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(13, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(131, 26)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Проверять каждые"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(189, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 26)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "сек."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCount
        '
        Me.txtCount.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCount.Location = New System.Drawing.Point(150, 13)
        Me.txtCount.Name = "txtCount"
        Me.txtCount.Size = New System.Drawing.Size(33, 20)
        Me.txtCount.TabIndex = 4
        Me.txtCount.Text = "30"
        Me.txtCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkSaveToFile
        '
        Me.chkSaveToFile.Checked = True
        Me.chkSaveToFile.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TableLayoutPanel1.SetColumnSpan(Me.chkSaveToFile, 3)
        Me.chkSaveToFile.Location = New System.Drawing.Point(13, 177)
        Me.chkSaveToFile.Name = "chkSaveToFile"
        Me.chkSaveToFile.Size = New System.Drawing.Size(249, 24)
        Me.chkSaveToFile.TabIndex = 5
        Me.chkSaveToFile.Text = "Сохранять логи в файл"
        Me.chkSaveToFile.UseVisualStyleBackColor = True
        '
        'btnOpenLog
        '
        Me.btnOpenLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnOpenLog.Location = New System.Drawing.Point(268, 177)
        Me.btnOpenLog.Name = "btnOpenLog"
        Me.btnOpenLog.Size = New System.Drawing.Size(134, 24)
        Me.btnOpenLog.TabIndex = 6
        Me.btnOpenLog.Text = "Открыть лог-файл"
        Me.btnOpenLog.UseVisualStyleBackColor = True
        '
        'chkMinimizeToTray
        '
        Me.chkMinimizeToTray.Checked = True
        Me.chkMinimizeToTray.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TableLayoutPanel1.SetColumnSpan(Me.chkMinimizeToTray, 4)
        Me.chkMinimizeToTray.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chkMinimizeToTray.Location = New System.Drawing.Point(13, 207)
        Me.chkMinimizeToTray.Name = "chkMinimizeToTray"
        Me.chkMinimizeToTray.Size = New System.Drawing.Size(389, 20)
        Me.chkMinimizeToTray.TabIndex = 5
        Me.chkMinimizeToTray.Text = "Сворачивать в трей"
        Me.chkMinimizeToTray.UseVisualStyleBackColor = True
        '
        'chkStartWithWin
        '
        Me.chkStartWithWin.Checked = True
        Me.chkStartWithWin.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TableLayoutPanel1.SetColumnSpan(Me.chkStartWithWin, 4)
        Me.chkStartWithWin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chkStartWithWin.Location = New System.Drawing.Point(13, 259)
        Me.chkStartWithWin.Name = "chkStartWithWin"
        Me.chkStartWithWin.Size = New System.Drawing.Size(389, 20)
        Me.chkStartWithWin.TabIndex = 5
        Me.chkStartWithWin.Text = "Запускать программу при запуске Windows"
        Me.chkStartWithWin.UseVisualStyleBackColor = True
        '
        'pnlButtons
        '
        Me.pnlButtons.Controls.Add(Me.btnOK)
        Me.pnlButtons.Controls.Add(Me.btnCancel)
        Me.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlButtons.Location = New System.Drawing.Point(0, 292)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(415, 47)
        Me.pnlButtons.TabIndex = 1
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(226, 10)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(85, 28)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "ОК"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(317, 10)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(85, 28)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "Отмена"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'chkShowBubbles
        '
        Me.chkShowBubbles.Checked = True
        Me.chkShowBubbles.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TableLayoutPanel1.SetColumnSpan(Me.chkShowBubbles, 4)
        Me.chkShowBubbles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chkShowBubbles.Location = New System.Drawing.Point(13, 233)
        Me.chkShowBubbles.Name = "chkShowBubbles"
        Me.chkShowBubbles.Size = New System.Drawing.Size(389, 20)
        Me.chkShowBubbles.TabIndex = 5
        Me.chkShowBubbles.Text = "Показывать уведомления об изменении состояния"
        Me.chkShowBubbles.UseVisualStyleBackColor = True
        '
        'frmConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(415, 339)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.pnlButtons)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConfig"
        Me.Text = "Настройки"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.pnlButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtServers As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCount As System.Windows.Forms.TextBox
    Friend WithEvents chkSaveToFile As System.Windows.Forms.CheckBox
    Friend WithEvents pnlButtons As System.Windows.Forms.Panel
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOpenLog As System.Windows.Forms.Button
    Friend WithEvents chkMinimizeToTray As System.Windows.Forms.CheckBox
    Friend WithEvents chkStartWithWin As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowBubbles As System.Windows.Forms.CheckBox
End Class
