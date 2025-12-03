namespace Lab_8.Forms
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.historyPanel = new System.Windows.Forms.Panel();
            this.tootStripHome = new System.Windows.Forms.ToolStrip();
            this.toolStripAdminBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnDropdown = new System.Windows.Forms.ToolStripSplitButton();
            this.userProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flpQuiz = new System.Windows.Forms.FlowLayoutPanel();
            this.paginatePanelQuiz = new System.Windows.Forms.Panel();
            this.paginatePanelHistory = new System.Windows.Forms.Panel();
            this.searchQuizPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txbSearchQuiz = new System.Windows.Forms.TextBox();
            this.quizFilterPanel = new System.Windows.Forms.Panel();
            this.tootStripHome.SuspendLayout();
            this.searchQuizPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // historyPanel
            // 
            this.historyPanel.BackColor = System.Drawing.Color.White;
            this.historyPanel.Location = new System.Drawing.Point(1137, 37);
            this.historyPanel.Name = "historyPanel";
            this.historyPanel.Size = new System.Drawing.Size(376, 632);
            this.historyPanel.TabIndex = 1;
            // 
            // tootStripHome
            // 
            this.tootStripHome.BackColor = System.Drawing.Color.White;
            this.tootStripHome.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tootStripHome.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tootStripHome.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripAdminBtn,
            this.toolStripBtnDropdown});
            this.tootStripHome.Location = new System.Drawing.Point(0, 0);
            this.tootStripHome.Name = "tootStripHome";
            this.tootStripHome.Size = new System.Drawing.Size(1526, 32);
            this.tootStripHome.TabIndex = 2;
            this.tootStripHome.Text = "toolStrip1";
            // 
            // toolStripAdminBtn
            // 
            this.toolStripAdminBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripAdminBtn.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripAdminBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripAdminBtn.Image")));
            this.toolStripAdminBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripAdminBtn.Name = "toolStripAdminBtn";
            this.toolStripAdminBtn.Size = new System.Drawing.Size(69, 29);
            this.toolStripAdminBtn.Text = "Admin";
            this.toolStripAdminBtn.Click += new System.EventHandler(this.toolStripAdminBtn_Click);
            // 
            // toolStripBtnDropdown
            // 
            this.toolStripBtnDropdown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBtnDropdown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userProfileToolStripMenuItem,
            this.logoutToolStripItem});
            this.toolStripBtnDropdown.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnDropdown.Image")));
            this.toolStripBtnDropdown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnDropdown.Name = "toolStripBtnDropdown";
            this.toolStripBtnDropdown.Size = new System.Drawing.Size(81, 29);
            this.toolStripBtnDropdown.Text = "Profile";
            // 
            // userProfileToolStripMenuItem
            // 
            this.userProfileToolStripMenuItem.Name = "userProfileToolStripMenuItem";
            this.userProfileToolStripMenuItem.Size = new System.Drawing.Size(188, 30);
            this.userProfileToolStripMenuItem.Text = "User Profile";
            this.userProfileToolStripMenuItem.Click += new System.EventHandler(this.userProfileToolStripMenuItem_Click);
            // 
            // logoutToolStripItem
            // 
            this.logoutToolStripItem.Name = "logoutToolStripItem";
            this.logoutToolStripItem.Size = new System.Drawing.Size(188, 30);
            this.logoutToolStripItem.Text = "Logout";
            this.logoutToolStripItem.Click += new System.EventHandler(this.logoutToolStripItem_Click);
            // 
            // flpQuiz
            // 
            this.flpQuiz.BackColor = System.Drawing.Color.White;
            this.flpQuiz.Location = new System.Drawing.Point(346, 37);
            this.flpQuiz.Name = "flpQuiz";
            this.flpQuiz.Size = new System.Drawing.Size(785, 632);
            this.flpQuiz.TabIndex = 3;
            // 
            // paginatePanelQuiz
            // 
            this.paginatePanelQuiz.BackColor = System.Drawing.Color.White;
            this.paginatePanelQuiz.Location = new System.Drawing.Point(346, 675);
            this.paginatePanelQuiz.Name = "paginatePanelQuiz";
            this.paginatePanelQuiz.Size = new System.Drawing.Size(785, 72);
            this.paginatePanelQuiz.TabIndex = 4;
            // 
            // paginatePanelHistory
            // 
            this.paginatePanelHistory.BackColor = System.Drawing.Color.White;
            this.paginatePanelHistory.Location = new System.Drawing.Point(1137, 675);
            this.paginatePanelHistory.Name = "paginatePanelHistory";
            this.paginatePanelHistory.Size = new System.Drawing.Size(376, 72);
            this.paginatePanelHistory.TabIndex = 5;
            // 
            // searchQuizPanel
            // 
            this.searchQuizPanel.BackColor = System.Drawing.Color.White;
            this.searchQuizPanel.Controls.Add(this.label1);
            this.searchQuizPanel.Controls.Add(this.txbSearchQuiz);
            this.searchQuizPanel.Location = new System.Drawing.Point(12, 37);
            this.searchQuizPanel.Name = "searchQuizPanel";
            this.searchQuizPanel.Size = new System.Drawing.Size(328, 68);
            this.searchQuizPanel.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Find quiz:";
            // 
            // txbSearchQuiz
            // 
            this.txbSearchQuiz.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSearchQuiz.Location = new System.Drawing.Point(113, 18);
            this.txbSearchQuiz.Name = "txbSearchQuiz";
            this.txbSearchQuiz.Size = new System.Drawing.Size(193, 28);
            this.txbSearchQuiz.TabIndex = 0;
            this.txbSearchQuiz.TextChanged += new System.EventHandler(this.txbSearchQuiz_TextChanged);
            // 
            // quizFilterPanel
            // 
            this.quizFilterPanel.BackColor = System.Drawing.Color.White;
            this.quizFilterPanel.Location = new System.Drawing.Point(13, 112);
            this.quizFilterPanel.Name = "quizFilterPanel";
            this.quizFilterPanel.Size = new System.Drawing.Size(327, 635);
            this.quizFilterPanel.TabIndex = 7;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1526, 759);
            this.Controls.Add(this.quizFilterPanel);
            this.Controls.Add(this.searchQuizPanel);
            this.Controls.Add(this.paginatePanelHistory);
            this.Controls.Add(this.paginatePanelQuiz);
            this.Controls.Add(this.flpQuiz);
            this.Controls.Add(this.tootStripHome);
            this.Controls.Add(this.historyPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.tootStripHome.ResumeLayout(false);
            this.tootStripHome.PerformLayout();
            this.searchQuizPanel.ResumeLayout(false);
            this.searchQuizPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel historyPanel;
        private System.Windows.Forms.ToolStrip tootStripHome;
        private System.Windows.Forms.ToolStripButton toolStripAdminBtn;
        private System.Windows.Forms.FlowLayoutPanel flpQuiz;
        private System.Windows.Forms.Panel paginatePanelQuiz;
        public System.Windows.Forms.ToolStripSplitButton toolStripBtnDropdown;
        private System.Windows.Forms.ToolStripMenuItem userProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripItem;
        private System.Windows.Forms.Panel paginatePanelHistory;
        private System.Windows.Forms.Panel searchQuizPanel;
        private System.Windows.Forms.Panel quizFilterPanel;
        private System.Windows.Forms.TextBox txbSearchQuiz;
        private System.Windows.Forms.Label label1;
    }
}