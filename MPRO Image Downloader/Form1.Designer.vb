<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.btnHash = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.tbDest = New System.Windows.Forms.TextBox()
        Me.btnDest = New System.Windows.Forms.Button()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tbHash = New System.Windows.Forms.TextBox()
        Me.GameMenu = New System.Windows.Forms.MenuStrip()
        Me.mCV = New System.Windows.Forms.ToolStripMenuItem()
        Me.mFV = New System.Windows.Forms.ToolStripMenuItem()
        Me.mCaV = New System.Windows.Forms.ToolStripMenuItem()
        Me.mHC = New System.Windows.Forms.ToolStripMenuItem()
        Me.mFV2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NI = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Toggler = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.cbImages = New System.Windows.Forms.CheckBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.CBMultipleURL = New System.Windows.Forms.CheckBox()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.GameMenu.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.UserProfile
        '
        'btnHash
        '
        Me.btnHash.BackColor = System.Drawing.Color.Gold
        Me.btnHash.Location = New System.Drawing.Point(406, 30)
        Me.btnHash.Name = "btnHash"
        Me.btnHash.Size = New System.Drawing.Size(72, 21)
        Me.btnHash.TabIndex = 0
        Me.btnHash.TabStop = False
        Me.btnHash.Text = "Hash**.txt"
        Me.btnHash.UseVisualStyleBackColor = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "Text Files|*.txt|All Files|*.*"
        '
        'tbDest
        '
        Me.tbDest.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tbDest.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbDest.ForeColor = System.Drawing.Color.SeaGreen
        Me.tbDest.Location = New System.Drawing.Point(4, 50)
        Me.tbDest.Name = "tbDest"
        Me.tbDest.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tbDest.Size = New System.Drawing.Size(396, 21)
        Me.tbDest.TabIndex = 2
        Me.tbDest.TabStop = False
        '
        'btnDest
        '
        Me.btnDest.BackColor = System.Drawing.Color.Gold
        Me.btnDest.Location = New System.Drawing.Point(406, 50)
        Me.btnDest.Name = "btnDest"
        Me.btnDest.Size = New System.Drawing.Size(72, 21)
        Me.btnDest.TabIndex = 3
        Me.btnDest.TabStop = False
        Me.btnDest.Text = "Destination"
        Me.btnDest.UseVisualStyleBackColor = False
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 200
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(62, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Saved/skipped/error:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(3, 79)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 13)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Total:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(187, 97)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 13)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "0 (0%)"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Purple
        Me.Label12.Location = New System.Drawing.Point(3, 97)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(13, 13)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "0"
        '
        'tbHash
        '
        Me.tbHash.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tbHash.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbHash.ForeColor = System.Drawing.Color.SeaGreen
        Me.tbHash.Location = New System.Drawing.Point(4, 30)
        Me.tbHash.Name = "tbHash"
        Me.tbHash.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tbHash.Size = New System.Drawing.Size(396, 21)
        Me.tbHash.TabIndex = 17
        Me.tbHash.TabStop = False
        '
        'GameMenu
        '
        Me.GameMenu.BackColor = System.Drawing.Color.DarkGray
        Me.GameMenu.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GameMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mCV, Me.mFV, Me.mCaV, Me.mHC, Me.mFV2})
        Me.GameMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.GameMenu.Location = New System.Drawing.Point(0, 0)
        Me.GameMenu.Name = "GameMenu"
        Me.GameMenu.Size = New System.Drawing.Size(488, 24)
        Me.GameMenu.TabIndex = 19
        Me.GameMenu.Text = "MenuStrip1"
        '
        'mCV
        '
        Me.mCV.Image = CType(resources.GetObject("mCV.Image"), System.Drawing.Image)
        Me.mCV.Name = "mCV"
        Me.mCV.Size = New System.Drawing.Size(75, 20)
        Me.mCV.Text = "CityVille"
        '
        'mFV
        '
        Me.mFV.Image = CType(resources.GetObject("mFV.Image"), System.Drawing.Image)
        Me.mFV.Name = "mFV"
        Me.mFV.Size = New System.Drawing.Size(80, 20)
        Me.mFV.Text = "FarmVille"
        '
        'mCaV
        '
        Me.mCaV.Image = CType(resources.GetObject("mCaV.Image"), System.Drawing.Image)
        Me.mCaV.Name = "mCaV"
        Me.mCaV.Size = New System.Drawing.Size(85, 20)
        Me.mCaV.Text = "CastleVille"
        '
        'mHC
        '
        Me.mHC.Image = CType(resources.GetObject("mHC.Image"), System.Drawing.Image)
        Me.mHC.Name = "mHC"
        Me.mHC.Size = New System.Drawing.Size(120, 20)
        Me.mHC.Text = "Hidden Chronicles"
        '
        'mFV2
        '
        Me.mFV2.Image = CType(resources.GetObject("mFV2.Image"), System.Drawing.Image)
        Me.mFV2.Name = "mFV2"
        Me.mFV2.Size = New System.Drawing.Size(88, 20)
        Me.mFV2.Text = "FarmVille 2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(187, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Overall Progress:"
        '
        'NI
        '
        Me.NI.BalloonTipTitle = "MPRO Image Downloader"
        Me.NI.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NI.Icon = CType(resources.GetObject("NI.Icon"), System.Drawing.Icon)
        Me.NI.Tag = "0"
        Me.NI.Text = "MPRO Image Downloader"
        Me.NI.Visible = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.BackColor = System.Drawing.Color.DodgerBlue
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Toggler, Me.btnExit})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(106, 48)
        '
        'Toggler
        '
        Me.Toggler.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Toggler.Name = "Toggler"
        Me.Toggler.Size = New System.Drawing.Size(105, 22)
        Me.Toggler.Text = "Show"
        '
        'btnExit
        '
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(105, 22)
        Me.btnExit.Text = "Exit"
        '
        'cbImages
        '
        Me.cbImages.BackColor = System.Drawing.Color.Transparent
        Me.cbImages.Checked = True
        Me.cbImages.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbImages.Location = New System.Drawing.Point(278, 76)
        Me.cbImages.Name = "cbImages"
        Me.cbImages.Size = New System.Drawing.Size(134, 20)
        Me.cbImages.TabIndex = 22
        Me.cbImages.TabStop = False
        Me.cbImages.Text = "Download images only"
        Me.cbImages.UseVisualStyleBackColor = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkLabel1.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel1.ForeColor = System.Drawing.Color.Black
        Me.LinkLabel1.LinkArea = New System.Windows.Forms.LinkArea(41, 7)
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.Blue
        Me.LinkLabel1.Location = New System.Drawing.Point(0, 115)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(488, 21)
        Me.LinkLabel1.TabIndex = 18
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "MPRO Image Downloader (version 6.5.1) by Mihapro"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LinkLabel1.UseCompatibleTextRendering = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.Color.DodgerBlue
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.Location = New System.Drawing.Point(65, 97)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(115, 15)
        Me.RichTextBox1.TabIndex = 30
        Me.RichTextBox1.Text = "0 / 0 / 0"
        '
        'CBMultipleURL
        '
        Me.CBMultipleURL.BackColor = System.Drawing.Color.Transparent
        Me.CBMultipleURL.Location = New System.Drawing.Point(278, 95)
        Me.CBMultipleURL.Name = "CBMultipleURL"
        Me.CBMultipleURL.Size = New System.Drawing.Size(123, 18)
        Me.CBMultipleURL.TabIndex = 31
        Me.CBMultipleURL.TabStop = False
        Me.CBMultipleURL.Tag = "test"
        Me.CBMultipleURL.Text = "Check multiple URLs"
        Me.CBMultipleURL.UseVisualStyleBackColor = False
        '
        'btnStart
        '
        Me.btnStart.BackColor = System.Drawing.Color.Goldenrod
        Me.btnStart.Image = Global.MPRO_ID.My.Resources.Resources.Flag_Green
        Me.btnStart.Location = New System.Drawing.Point(406, 79)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(72, 30)
        Me.btnStart.TabIndex = 21
        Me.btnStart.TabStop = False
        Me.btnStart.Text = "START"
        Me.btnStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnStart.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DodgerBlue
        Me.ClientSize = New System.Drawing.Size(488, 134)
        Me.Controls.Add(Me.CBMultipleURL)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.tbHash)
        Me.Controls.Add(Me.btnDest)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.cbImages)
        Me.Controls.Add(Me.tbDest)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btnHash)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.GameMenu)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.GameMenu
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "MPRO Image Downloader"
        Me.GameMenu.ResumeLayout(False)
        Me.GameMenu.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btnHash As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents tbDest As System.Windows.Forms.TextBox
    Friend WithEvents btnDest As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tbHash As System.Windows.Forms.TextBox
    Friend WithEvents GameMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents mCV As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mFV As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents NI As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Toggler As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cbImages As System.Windows.Forms.CheckBox
    Friend WithEvents mCaV As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mHC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mFV2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents CBMultipleURL As System.Windows.Forms.CheckBox

End Class
