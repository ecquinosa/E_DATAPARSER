<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.lblClientProfile = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tsslStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsslStatus2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tvProfile = New System.Windows.Forms.TreeView()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbInputOutput = New System.Windows.Forms.ToolStripButton()
        Me.tssI1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbParseData = New System.Windows.Forms.ToolStripButton()
        Me.tss2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbExceptions = New System.Windows.Forms.ToolStripButton()
        Me.tss3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbGenerate = New System.Windows.Forms.ToolStripButton()
        Me.tss4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbExportToExcel = New System.Windows.Forms.ToolStripButton()
        Me.tsbLog = New System.Windows.Forms.ToolStripButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.DarkOrange
        Me.pnlHeader.Controls.Add(Me.Button2)
        Me.pnlHeader.Controls.Add(Me.Label2)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1087, 47)
        Me.pnlHeader.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(997, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Unicode MS", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label2.Location = New System.Drawing.Point(5, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(426, 36)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "ALLCARD DATA PARSER v1.0"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.TextBox2)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.lblClientProfile)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 47)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1087, 38)
        Me.Panel1.TabIndex = 1
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(515, 10)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(393, 23)
        Me.TextBox2.TabIndex = 3
        Me.TextBox2.Text = "1234"
        Me.TextBox2.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(116, 9)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(393, 23)
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.Visible = False
        '
        'lblClientProfile
        '
        Me.lblClientProfile.AutoSize = True
        Me.lblClientProfile.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClientProfile.Location = New System.Drawing.Point(81, 10)
        Me.lblClientProfile.Name = "lblClientProfile"
        Me.lblClientProfile.Size = New System.Drawing.Size(0, 16)
        Me.lblClientProfile.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Profile: "
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(997, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 29)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslStatus, Me.ToolStripSeparator3, Me.tsslStatus2})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 710)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1087, 23)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsslStatus
        '
        Me.tsslStatus.Name = "tsslStatus"
        Me.tsslStatus.Padding = New System.Windows.Forms.Padding(0, 0, 100, 0)
        Me.tsslStatus.Size = New System.Drawing.Size(139, 18)
        Me.tsslStatus.Text = "Ready"
        Me.tsslStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 23)
        '
        'tsslStatus2
        '
        Me.tsslStatus2.Name = "tsslStatus2"
        Me.tsslStatus2.Padding = New System.Windows.Forms.Padding(0, 0, 100, 0)
        Me.tsslStatus2.Size = New System.Drawing.Size(100, 18)
        Me.tsslStatus2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 85)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.tvProfile)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1087, 625)
        Me.SplitContainer1.SplitterDistance = 257
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 3
        '
        'tvProfile
        '
        Me.tvProfile.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvProfile.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvProfile.Location = New System.Drawing.Point(0, 0)
        Me.tvProfile.Name = "tvProfile"
        Me.tvProfile.Size = New System.Drawing.Size(257, 625)
        Me.tvProfile.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.ToolStrip1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.PictureBox1)
        Me.SplitContainer2.Size = New System.Drawing.Size(825, 625)
        Me.SplitContainer2.SplitterDistance = 41
        Me.SplitContainer2.SplitterWidth = 5
        Me.SplitContainer2.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbInputOutput, Me.tssI1, Me.tsbParseData, Me.tss2, Me.tsbExceptions, Me.tss3, Me.tsbGenerate, Me.tss4, Me.tsbExportToExcel, Me.tsbLog})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(825, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbInputOutput
        '
        Me.tsbInputOutput.Image = CType(resources.GetObject("tsbInputOutput.Image"), System.Drawing.Image)
        Me.tsbInputOutput.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbInputOutput.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbInputOutput.Name = "tsbInputOutput"
        Me.tsbInputOutput.Size = New System.Drawing.Size(115, 34)
        Me.tsbInputOutput.Text = "Input/ Output"
        Me.tsbInputOutput.Visible = False
        '
        'tssI1
        '
        Me.tssI1.Name = "tssI1"
        Me.tssI1.Size = New System.Drawing.Size(6, 37)
        Me.tssI1.Visible = False
        '
        'tsbParseData
        '
        Me.tsbParseData.Image = CType(resources.GetObject("tsbParseData.Image"), System.Drawing.Image)
        Me.tsbParseData.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbParseData.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbParseData.Name = "tsbParseData"
        Me.tsbParseData.Size = New System.Drawing.Size(96, 34)
        Me.tsbParseData.Text = "Parse Data"
        Me.tsbParseData.Visible = False
        '
        'tss2
        '
        Me.tss2.Name = "tss2"
        Me.tss2.Size = New System.Drawing.Size(6, 37)
        Me.tss2.Visible = False
        '
        'tsbExceptions
        '
        Me.tsbExceptions.Image = CType(resources.GetObject("tsbExceptions.Image"), System.Drawing.Image)
        Me.tsbExceptions.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbExceptions.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExceptions.Name = "tsbExceptions"
        Me.tsbExceptions.Size = New System.Drawing.Size(98, 34)
        Me.tsbExceptions.Text = "Exceptions"
        Me.tsbExceptions.Visible = False
        '
        'tss3
        '
        Me.tss3.Name = "tss3"
        Me.tss3.Size = New System.Drawing.Size(6, 37)
        Me.tss3.Visible = False
        '
        'tsbGenerate
        '
        Me.tsbGenerate.Image = CType(resources.GetObject("tsbGenerate.Image"), System.Drawing.Image)
        Me.tsbGenerate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbGenerate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGenerate.Name = "tsbGenerate"
        Me.tsbGenerate.Size = New System.Drawing.Size(88, 34)
        Me.tsbGenerate.Text = "Generate"
        Me.tsbGenerate.Visible = False
        '
        'tss4
        '
        Me.tss4.Name = "tss4"
        Me.tss4.Size = New System.Drawing.Size(6, 37)
        Me.tss4.Visible = False
        '
        'tsbExportToExcel
        '
        Me.tsbExportToExcel.Image = CType(resources.GetObject("tsbExportToExcel.Image"), System.Drawing.Image)
        Me.tsbExportToExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExportToExcel.Name = "tsbExportToExcel"
        Me.tsbExportToExcel.Size = New System.Drawing.Size(119, 34)
        Me.tsbExportToExcel.Text = "Export to Excel"
        Me.tsbExportToExcel.Visible = False
        '
        'tsbLog
        '
        Me.tsbLog.Image = CType(resources.GetObject("tsbLog.Image"), System.Drawing.Image)
        Me.tsbLog.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbLog.Name = "tsbLog"
        Me.tsbLog.Size = New System.Drawing.Size(47, 22)
        Me.tsbLog.Text = "Log"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(193, 80)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1087, 733)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlHeader)
        Me.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ALLCARD DATA PARSER"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsbParseData As ToolStripButton
    Friend WithEvents tss2 As ToolStripSeparator
    Friend WithEvents tsbExceptions As ToolStripButton
    Friend WithEvents tss3 As ToolStripSeparator
    Friend WithEvents tsbGenerate As ToolStripButton
    Friend WithEvents tsslStatus As ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents tsslStatus2 As ToolStripStatusLabel
    Friend WithEvents tsbInputOutput As ToolStripButton
    Friend WithEvents tvProfile As TreeView
    Friend WithEvents tsbExportToExcel As ToolStripButton
    Friend WithEvents Label1 As Label
    Friend WithEvents lblClientProfile As Label
    Friend WithEvents tssI1 As ToolStripSeparator
    Friend WithEvents tss4 As ToolStripSeparator
    Friend WithEvents Label2 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents tsbLog As ToolStripButton
    Friend WithEvents PictureBox1 As PictureBox
End Class
