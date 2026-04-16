namespace YTY.HookTest
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.topPanel = new System.Windows.Forms.Panel();
            this.btnSelectGame = new System.Windows.Forms.Button();
            this.rightButtonPanel = new System.Windows.Forms.Panel();
            this.btnCloseGame = new System.Windows.Forms.Button();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.middlePanel = new System.Windows.Forms.Panel();
            this.chkAutoScroll = new System.Windows.Forms.CheckBox();
            this.lnkProxyAction = new System.Windows.Forms.LinkLabel();
            this.lblProxyStatus = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.debugBox = new System.Windows.Forms.RichTextBox();
            this.serverConfigPanel = new System.Windows.Forms.Panel();
            this.btnUpdateServer = new System.Windows.Forms.Button();
            this.txtServerAddress = new System.Windows.Forms.TextBox();
            this.lblServerAddress = new System.Windows.Forms.Label();
            this.topPanel.SuspendLayout();
            this.rightButtonPanel.SuspendLayout();
            this.middlePanel.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.serverConfigPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.btnSelectGame);
            this.topPanel.Controls.Add(this.rightButtonPanel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Padding = new System.Windows.Forms.Padding(10);
            this.topPanel.Size = new System.Drawing.Size(1450, 76);
            this.topPanel.TabIndex = 3;
            // 
            // btnSelectGame
            // 
            this.btnSelectGame.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSelectGame.Location = new System.Drawing.Point(10, 10);
            this.btnSelectGame.Margin = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.btnSelectGame.Name = "btnSelectGame";
            this.btnSelectGame.Size = new System.Drawing.Size(321, 56);
            this.btnSelectGame.TabIndex = 0;
            this.btnSelectGame.Text = "选择游戏可执行文件";
            this.btnSelectGame.UseVisualStyleBackColor = true;
            this.btnSelectGame.Click += new System.EventHandler(this.BtnSelectGame_Click);
            // 
            // rightButtonPanel
            // 
            this.rightButtonPanel.Controls.Add(this.btnCloseGame);
            this.rightButtonPanel.Controls.Add(this.btnStartGame);
            this.rightButtonPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightButtonPanel.Location = new System.Drawing.Point(808, 10);
            this.rightButtonPanel.Name = "rightButtonPanel";
            this.rightButtonPanel.Size = new System.Drawing.Size(632, 56);
            this.rightButtonPanel.TabIndex = 2;
            // 
            // btnCloseGame
            // 
            this.btnCloseGame.AutoSize = true;
            this.btnCloseGame.Enabled = false;
            this.btnCloseGame.Location = new System.Drawing.Point(256, 0);
            this.btnCloseGame.Margin = new System.Windows.Forms.Padding(0, 15, 25, 15);
            this.btnCloseGame.Name = "btnCloseGame";
            this.btnCloseGame.Size = new System.Drawing.Size(180, 56);
            this.btnCloseGame.TabIndex = 1;
            this.btnCloseGame.Text = "关闭游戏";
            this.btnCloseGame.UseVisualStyleBackColor = true;
            this.btnCloseGame.Click += new System.EventHandler(this.BtnCloseGame_Click);
            // 
            // btnStartGame
            // 
            this.btnStartGame.AutoSize = true;
            this.btnStartGame.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnStartGame.Enabled = false;
            this.btnStartGame.Location = new System.Drawing.Point(452, 0);
            this.btnStartGame.Margin = new System.Windows.Forms.Padding(25, 15, 10, 15);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(180, 56);
            this.btnStartGame.TabIndex = 0;
            this.btnStartGame.Text = "启动游戏";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.BtnStartGame_Click);
            // 
            // middlePanel
            // 
            this.middlePanel.Controls.Add(this.chkAutoScroll);
            this.middlePanel.Controls.Add(this.lnkProxyAction);
            this.middlePanel.Controls.Add(this.lblProxyStatus);
            this.middlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.middlePanel.Location = new System.Drawing.Point(0, 76);
            this.middlePanel.Name = "middlePanel";
            this.middlePanel.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.middlePanel.Size = new System.Drawing.Size(1450, 40);
            this.middlePanel.TabIndex = 5;
            // 
            // chkAutoScroll
            // 
            this.chkAutoScroll.AutoSize = true;
            this.chkAutoScroll.Dock = System.Windows.Forms.DockStyle.Right;
            this.chkAutoScroll.Location = new System.Drawing.Point(1206, 0);
            this.chkAutoScroll.Name = "chkAutoScroll";
            this.chkAutoScroll.Size = new System.Drawing.Size(234, 40);
            this.chkAutoScroll.TabIndex = 0;
            this.chkAutoScroll.Text = "调试日志自动滚动";
            this.chkAutoScroll.UseVisualStyleBackColor = true;
            // 
            // lnkProxyAction
            // 
            this.lnkProxyAction.AutoSize = true;
            this.lnkProxyAction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkProxyAction.Dock = System.Windows.Forms.DockStyle.Left;
            this.lnkProxyAction.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lnkProxyAction.Location = new System.Drawing.Point(211, 0);
            this.lnkProxyAction.Margin = new System.Windows.Forms.Padding(3);
            this.lnkProxyAction.MinimumSize = new System.Drawing.Size(0, 40);
            this.lnkProxyAction.Name = "lnkProxyAction";
            this.lnkProxyAction.Size = new System.Drawing.Size(66, 40);
            this.lnkProxyAction.TabIndex = 2;
            this.lnkProxyAction.TabStop = true;
            this.lnkProxyAction.Text = "启动";
            this.lnkProxyAction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkProxyAction.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkProxyAction_LinkClicked);
            // 
            // lblProxyStatus
            // 
            this.lblProxyStatus.AutoSize = true;
            this.lblProxyStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblProxyStatus.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblProxyStatus.Location = new System.Drawing.Point(10, 0);
            this.lblProxyStatus.Margin = new System.Windows.Forms.Padding(3);
            this.lblProxyStatus.MinimumSize = new System.Drawing.Size(0, 40);
            this.lblProxyStatus.Name = "lblProxyStatus";
            this.lblProxyStatus.Size = new System.Drawing.Size(201, 40);
            this.lblProxyStatus.TabIndex = 1;
            this.lblProxyStatus.Text = "网络代理未启动";
            this.lblProxyStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 929);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1450, 41);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(182, 31);
            this.toolStripStatusLabel1.Text = "未选择游戏文件";
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.debugBox);
            this.panel1.Controls.Add(this.serverConfigPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 116);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(15);
            this.panel1.Size = new System.Drawing.Size(1450, 813);
            this.panel1.TabIndex = 2;
            // 
            // debugBox
            // 
            this.debugBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.debugBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.debugBox.Location = new System.Drawing.Point(15, 15);
            this.debugBox.Margin = new System.Windows.Forms.Padding(3, 0, 3, 15);
            this.debugBox.Name = "debugBox";
            this.debugBox.ReadOnly = true;
            this.debugBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.debugBox.Size = new System.Drawing.Size(1420, 725);
            this.debugBox.TabIndex = 1;
            this.debugBox.Text = "";
            // 
            // serverConfigPanel
            // 
            this.serverConfigPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serverConfigPanel.Controls.Add(this.btnUpdateServer);
            this.serverConfigPanel.Controls.Add(this.txtServerAddress);
            this.serverConfigPanel.Controls.Add(this.lblServerAddress);
            this.serverConfigPanel.Location = new System.Drawing.Point(15, 746);
            this.serverConfigPanel.Name = "serverConfigPanel";
            this.serverConfigPanel.Size = new System.Drawing.Size(1420, 52);
            this.serverConfigPanel.TabIndex = 6;
            // 
            // btnUpdateServer
            // 
            this.btnUpdateServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateServer.AutoSize = true;
            this.btnUpdateServer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUpdateServer.Location = new System.Drawing.Point(1349, 9);
            this.btnUpdateServer.Name = "btnUpdateServer";
            this.btnUpdateServer.Size = new System.Drawing.Size(68, 34);
            this.btnUpdateServer.TabIndex = 2;
            this.btnUpdateServer.Text = "更新";
            this.btnUpdateServer.UseVisualStyleBackColor = true;
            this.btnUpdateServer.Click += new System.EventHandler(this.BtnUpdateServer_Click);
            // 
            // txtServerAddress
            // 
            this.txtServerAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServerAddress.Location = new System.Drawing.Point(963, 8);
            this.txtServerAddress.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.txtServerAddress.Name = "txtServerAddress";
            this.txtServerAddress.Size = new System.Drawing.Size(350, 35);
            this.txtServerAddress.TabIndex = 1;
            this.txtServerAddress.Text = "localhost:52300";
            // 
            // lblServerAddress
            // 
            this.lblServerAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblServerAddress.AutoSize = true;
            this.lblServerAddress.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblServerAddress.Location = new System.Drawing.Point(741, 12);
            this.lblServerAddress.Margin = new System.Windows.Forms.Padding(3);
            this.lblServerAddress.MinimumSize = new System.Drawing.Size(0, 22);
            this.lblServerAddress.Name = "lblServerAddress";
            this.lblServerAddress.Size = new System.Drawing.Size(215, 27);
            this.lblServerAddress.TabIndex = 0;
            this.lblServerAddress.Text = "远程服务器地址:";
            this.lblServerAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1450, 970);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.middlePanel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.topPanel);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.topPanel.ResumeLayout(false);
            this.rightButtonPanel.ResumeLayout(false);
            this.rightButtonPanel.PerformLayout();
            this.middlePanel.ResumeLayout(false);
            this.middlePanel.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.serverConfigPanel.ResumeLayout(false);
            this.serverConfigPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Panel topPanel;
    private System.Windows.Forms.Button btnSelectGame;
    private System.Windows.Forms.Button btnStartGame;
    private System.Windows.Forms.Button btnCloseGame;
    private System.Windows.Forms.Panel rightButtonPanel;
    private System.Windows.Forms.Panel middlePanel;
    private System.Windows.Forms.Label lblProxyStatus;
    private System.Windows.Forms.LinkLabel lnkProxyAction;
    private System.Windows.Forms.CheckBox chkAutoScroll;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.RichTextBox debugBox;
    private System.Windows.Forms.Panel serverConfigPanel;
    private System.Windows.Forms.Label lblServerAddress;
    private System.Windows.Forms.TextBox txtServerAddress;
    private System.Windows.Forms.Button btnUpdateServer;
  }
}
