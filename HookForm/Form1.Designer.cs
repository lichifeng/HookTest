namespace AgeHood.HookTest
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
            this.topPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.topPanel.Name = "topPanel";
            this.topPanel.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.topPanel.Size = new System.Drawing.Size(725, 38);
            this.topPanel.TabIndex = 3;
            // 
            // btnSelectGame
            // 
            this.btnSelectGame.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSelectGame.Location = new System.Drawing.Point(5, 5);
            this.btnSelectGame.Margin = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.btnSelectGame.Name = "btnSelectGame";
            this.btnSelectGame.Size = new System.Drawing.Size(160, 28);
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
            this.rightButtonPanel.Location = new System.Drawing.Point(404, 5);
            this.rightButtonPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rightButtonPanel.Name = "rightButtonPanel";
            this.rightButtonPanel.Size = new System.Drawing.Size(316, 28);
            this.rightButtonPanel.TabIndex = 2;
            // 
            // btnCloseGame
            // 
            this.btnCloseGame.AutoSize = true;
            this.btnCloseGame.Enabled = false;
            this.btnCloseGame.Location = new System.Drawing.Point(128, 0);
            this.btnCloseGame.Margin = new System.Windows.Forms.Padding(0, 8, 12, 8);
            this.btnCloseGame.Name = "btnCloseGame";
            this.btnCloseGame.Size = new System.Drawing.Size(90, 28);
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
            this.btnStartGame.Location = new System.Drawing.Point(226, 0);
            this.btnStartGame.Margin = new System.Windows.Forms.Padding(12, 8, 5, 8);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(90, 28);
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
            this.middlePanel.Location = new System.Drawing.Point(0, 38);
            this.middlePanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.middlePanel.Name = "middlePanel";
            this.middlePanel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.middlePanel.Size = new System.Drawing.Size(725, 20);
            this.middlePanel.TabIndex = 5;
            // 
            // chkAutoScroll
            // 
            this.chkAutoScroll.AutoSize = true;
            this.chkAutoScroll.Dock = System.Windows.Forms.DockStyle.Right;
            this.chkAutoScroll.Location = new System.Drawing.Point(600, 0);
            this.chkAutoScroll.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkAutoScroll.Name = "chkAutoScroll";
            this.chkAutoScroll.Size = new System.Drawing.Size(120, 20);
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
            this.lnkProxyAction.Location = new System.Drawing.Point(110, 0);
            this.lnkProxyAction.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lnkProxyAction.MinimumSize = new System.Drawing.Size(0, 20);
            this.lnkProxyAction.Name = "lnkProxyAction";
            this.lnkProxyAction.Size = new System.Drawing.Size(35, 20);
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
            this.lblProxyStatus.Location = new System.Drawing.Point(5, 0);
            this.lblProxyStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lblProxyStatus.MinimumSize = new System.Drawing.Size(0, 20);
            this.lblProxyStatus.Name = "lblProxyStatus";
            this.lblProxyStatus.Size = new System.Drawing.Size(105, 20);
            this.lblProxyStatus.TabIndex = 1;
            this.lblProxyStatus.Text = "网络代理未启动";
            this.lblProxyStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 463);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.statusStrip1.Size = new System.Drawing.Size(725, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(92, 17);
            this.toolStripStatusLabel1.Text = "未选择游戏文件";
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.debugBox);
            this.panel1.Controls.Add(this.serverConfigPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 58);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.panel1.Size = new System.Drawing.Size(725, 405);
            this.panel1.TabIndex = 2;
            // 
            // debugBox
            // 
            this.debugBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.debugBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.debugBox.Location = new System.Drawing.Point(8, 8);
            this.debugBox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 8);
            this.debugBox.Name = "debugBox";
            this.debugBox.ReadOnly = true;
            this.debugBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.debugBox.Size = new System.Drawing.Size(712, 363);
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
            this.serverConfigPanel.Location = new System.Drawing.Point(8, 372);
            this.serverConfigPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.serverConfigPanel.Name = "serverConfigPanel";
            this.serverConfigPanel.Size = new System.Drawing.Size(710, 26);
            this.serverConfigPanel.TabIndex = 6;
            // 
            // btnUpdateServer
            // 
            this.btnUpdateServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateServer.AutoSize = true;
            this.btnUpdateServer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUpdateServer.Location = new System.Drawing.Point(670, 4);
            this.btnUpdateServer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUpdateServer.Name = "btnUpdateServer";
            this.btnUpdateServer.Size = new System.Drawing.Size(39, 22);
            this.btnUpdateServer.TabIndex = 2;
            this.btnUpdateServer.Text = "更新";
            this.btnUpdateServer.UseVisualStyleBackColor = true;
            this.btnUpdateServer.Click += new System.EventHandler(this.BtnUpdateServer_Click);
            // 
            // txtServerAddress
            // 
            this.txtServerAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServerAddress.Location = new System.Drawing.Point(482, 4);
            this.txtServerAddress.Margin = new System.Windows.Forms.Padding(2, 2, 8, 2);
            this.txtServerAddress.Name = "txtServerAddress";
            this.txtServerAddress.Size = new System.Drawing.Size(177, 21);
            this.txtServerAddress.TabIndex = 1;
            this.txtServerAddress.Text = "localhost:52300";
            // 
            // lblServerAddress
            // 
            this.lblServerAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblServerAddress.AutoSize = true;
            this.lblServerAddress.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblServerAddress.Location = new System.Drawing.Point(370, 6);
            this.lblServerAddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lblServerAddress.MinimumSize = new System.Drawing.Size(0, 11);
            this.lblServerAddress.Name = "lblServerAddress";
            this.lblServerAddress.Size = new System.Drawing.Size(112, 14);
            this.lblServerAddress.TabIndex = 0;
            this.lblServerAddress.Text = "远程服务器地址:";
            this.lblServerAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 485);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.middlePanel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.topPanel);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AgeHood Client";
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
