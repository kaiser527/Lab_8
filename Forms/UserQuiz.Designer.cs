using System.Windows.Forms;

namespace Lab_8
{
    partial class UserQuiz
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label quizNameLabel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.FlowLayoutPanel flpQuestion;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.PictureBox pbQuestion;
        private System.Windows.Forms.Panel questionsPanel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RichTextBox readingParagraphBox;
        private System.Windows.Forms.Panel readingPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.headerPanel = new System.Windows.Forms.Panel();
            this.quizNameLabel = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.questionsPanel = new System.Windows.Forms.Panel();
            this.pbQuestion = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.flpQuestion = new System.Windows.Forms.FlowLayoutPanel();
            this.headerPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.rightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbQuestion)).BeginInit();
            this.leftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.White;
            this.headerPanel.Controls.Add(this.quizNameLabel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(15);
            this.headerPanel.Size = new System.Drawing.Size(900, 70);
            this.headerPanel.TabIndex = 1;
            // 
            // quizNameLabel
            // 
            this.quizNameLabel.AutoSize = true;
            this.quizNameLabel.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quizNameLabel.Location = new System.Drawing.Point(18, 13);
            this.quizNameLabel.Name = "quizNameLabel";
            this.quizNameLabel.Size = new System.Drawing.Size(202, 45);
            this.quizNameLabel.TabIndex = 0;
            this.quizNameLabel.Text = "English Test";
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.rightPanel);
            this.mainPanel.Controls.Add(this.leftPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 70);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(8);
            this.mainPanel.Size = new System.Drawing.Size(900, 530);
            this.mainPanel.TabIndex = 0;
            // 
            // rightPanel
            // 
            this.rightPanel.BackColor = System.Drawing.Color.White;
            this.rightPanel.Controls.Add(this.questionsPanel);
            this.rightPanel.Controls.Add(this.pbQuestion);
            this.rightPanel.Controls.Add(this.progressBar1);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightPanel.Location = new System.Drawing.Point(338, 8);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Padding = new System.Windows.Forms.Padding(8);
            this.rightPanel.Size = new System.Drawing.Size(554, 514);
            this.rightPanel.TabIndex = 0;
            // 
            // questionsPanel
            // 
            this.questionsPanel.AutoScroll = true;
            this.questionsPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.questionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.questionsPanel.Location = new System.Drawing.Point(8, 8);
            this.questionsPanel.Name = "questionsPanel";
            this.questionsPanel.Padding = new System.Windows.Forms.Padding(8);
            this.questionsPanel.Size = new System.Drawing.Size(538, 473);
            this.questionsPanel.TabIndex = 0;
            // 
            // pbQuestion
            // 
            this.pbQuestion.Location = new System.Drawing.Point(0, 0);
            this.pbQuestion.Name = "pbQuestion";
            this.pbQuestion.Size = new System.Drawing.Size(100, 50);
            this.pbQuestion.TabIndex = 1;
            this.pbQuestion.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(8, 481);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(538, 25);
            this.progressBar1.TabIndex = 2;
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.Color.White;
            this.leftPanel.Controls.Add(this.flpQuestion);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(8, 8);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Padding = new System.Windows.Forms.Padding(8);
            this.leftPanel.Size = new System.Drawing.Size(330, 514);
            this.leftPanel.TabIndex = 1;
            // 
            // flpQuestion
            // 
            this.flpQuestion.AutoScroll = true;
            this.flpQuestion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpQuestion.Location = new System.Drawing.Point(8, 8);
            this.flpQuestion.Name = "flpQuestion";
            this.flpQuestion.Size = new System.Drawing.Size(314, 498);
            this.flpQuestion.TabIndex = 0;
            // 
            // UserQuiz
            // 
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.headerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "UserQuiz";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Quiz";
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.rightPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbQuestion)).EndInit();
            this.leftPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
