namespace Lab_8
{
    partial class UserQuiz
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.quizNameLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.QuestionAnswerGroupbox = new System.Windows.Forms.GroupBox();
            this.listViewQuestion = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.timeLabel);
            this.panel1.Controls.Add(this.quizNameLabel);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(840, 109);
            this.panel1.TabIndex = 0;
            // 
            // quizNameLabel
            // 
            this.quizNameLabel.AutoSize = true;
            this.quizNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quizNameLabel.Location = new System.Drawing.Point(3, 19);
            this.quizNameLabel.Name = "quizNameLabel";
            this.quizNameLabel.Size = new System.Drawing.Size(370, 69);
            this.quizNameLabel.TabIndex = 0;
            this.quizNameLabel.Text = "English Test";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.ForeColor = System.Drawing.Color.Red;
            this.timeLabel.Location = new System.Drawing.Point(600, 35); // position next to quiz name
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(200, 46);
            this.timeLabel.TabIndex = 1;
            this.timeLabel.Text = "01:00";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Controls.Add(this.QuestionAnswerGroupbox);
            this.panel2.Controls.Add(this.listViewQuestion);
            this.panel2.Location = new System.Drawing.Point(13, 129);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(840, 424);
            this.panel2.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(243, 380);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(594, 41);
            this.progressBar1.TabIndex = 2;
            // 
            // QuestionAnswerGroupbox
            // 
            this.QuestionAnswerGroupbox.Location = new System.Drawing.Point(243, 4);
            this.QuestionAnswerGroupbox.Name = "QuestionAnswerGroupbox";
            this.QuestionAnswerGroupbox.Size = new System.Drawing.Size(594, 370);
            this.QuestionAnswerGroupbox.TabIndex = 1;
            this.QuestionAnswerGroupbox.TabStop = false;
            // 
            // listViewQuestion
            // 
            this.listViewQuestion.HideSelection = false;
            this.listViewQuestion.Location = new System.Drawing.Point(4, 4);
            this.listViewQuestion.Name = "listViewQuestion";
            this.listViewQuestion.Size = new System.Drawing.Size(233, 417);
            this.listViewQuestion.TabIndex = 0;
            this.listViewQuestion.UseCompatibleStateImageBehavior = false;
            // 
            // UserQuiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 565);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "UserQuiz";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserQuiz";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label quizNameLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.ListView listViewQuestion;
        private System.Windows.Forms.GroupBox QuestionAnswerGroupbox;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}