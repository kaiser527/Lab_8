namespace Lab_8.Forms
{
    partial class Admin
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
            this.userFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.quizFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tpQuiz = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.listQuizPanel = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.cbQuizName = new System.Windows.Forms.ComboBox();
            this.btnUpsertQuizQA = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.quizNamePanel = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txbQuizName = new System.Windows.Forms.TextBox();
            this.quizDifficultyPanel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.cbQuizDifficulty = new System.Windows.Forms.ComboBox();
            this.quizImagePanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnUploadQuiz = new System.Windows.Forms.Button();
            this.pbQuizImage = new System.Windows.Forms.PictureBox();
            this.btnAddQuiz = new System.Windows.Forms.Button();
            this.btnEditQuiz = new System.Windows.Forms.Button();
            this.btnDeleteQuiz = new System.Windows.Forms.Button();
            this.btnSaveQuiz = new System.Windows.Forms.Button();
            this.btnCancelQuiz = new System.Windows.Forms.Button();
            this.txbSearchQuiz = new System.Windows.Forms.TextBox();
            this.quizTablePanel = new System.Windows.Forms.Panel();
            this.dtgvQuiz = new System.Windows.Forms.DataGridView();
            this.quizPaginatePanel = new System.Windows.Forms.Panel();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.userTablePanel = new System.Windows.Forms.Panel();
            this.dtgvUser = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.userEmailPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txbUserEmail = new System.Windows.Forms.TextBox();
            this.userPasswordPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txbUserPassword = new System.Windows.Forms.TextBox();
            this.userNamePanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txbUserName = new System.Windows.Forms.TextBox();
            this.userImagePanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUploadUserImage = new System.Windows.Forms.Button();
            this.pbUserImage = new System.Windows.Forms.PictureBox();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnSaveUser = new System.Windows.Forms.Button();
            this.btnCancelUser = new System.Windows.Forms.Button();
            this.txbSearchUser = new System.Windows.Forms.TextBox();
            this.userPaginatePanel = new System.Windows.Forms.Panel();
            this.tcAdmin = new System.Windows.Forms.TabControl();
            this.tpQuiz.SuspendLayout();
            this.panel7.SuspendLayout();
            this.listQuizPanel.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.quizNamePanel.SuspendLayout();
            this.quizDifficultyPanel.SuspendLayout();
            this.quizImagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbQuizImage)).BeginInit();
            this.quizTablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvQuiz)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.userTablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvUser)).BeginInit();
            this.panel3.SuspendLayout();
            this.userEmailPanel.SuspendLayout();
            this.userPasswordPanel.SuspendLayout();
            this.userNamePanel.SuspendLayout();
            this.userImagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserImage)).BeginInit();
            this.tcAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // userFileDialog
            // 
            this.userFileDialog.FileName = "openFileDialog1";
            // 
            // quizFileDialog
            // 
            this.quizFileDialog.FileName = "openFileDialog1";
            // 
            // tpQuiz
            // 
            this.tpQuiz.Controls.Add(this.panel8);
            this.tpQuiz.Controls.Add(this.label9);
            this.tpQuiz.Controls.Add(this.panel7);
            this.tpQuiz.Location = new System.Drawing.Point(4, 31);
            this.tpQuiz.Name = "tpQuiz";
            this.tpQuiz.Size = new System.Drawing.Size(1094, 615);
            this.tpQuiz.TabIndex = 2;
            this.tpQuiz.Text = "Question-Answer";
            this.tpQuiz.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnUpsertQuizQA);
            this.panel7.Controls.Add(this.listQuizPanel);
            this.panel7.Location = new System.Drawing.Point(6, 6);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1081, 84);
            this.panel7.TabIndex = 5;
            // 
            // listQuizPanel
            // 
            this.listQuizPanel.BackColor = System.Drawing.Color.White;
            this.listQuizPanel.Controls.Add(this.cbQuizName);
            this.listQuizPanel.Controls.Add(this.label12);
            this.listQuizPanel.ForeColor = System.Drawing.Color.Black;
            this.listQuizPanel.Location = new System.Drawing.Point(39, 14);
            this.listQuizPanel.Name = "listQuizPanel";
            this.listQuizPanel.Size = new System.Drawing.Size(441, 55);
            this.listQuizPanel.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 22);
            this.label12.TabIndex = 0;
            this.label12.Text = "Quizzes:";
            // 
            // cbQuizName
            // 
            this.cbQuizName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbQuizName.FormattingEnabled = true;
            this.cbQuizName.Location = new System.Drawing.Point(124, 13);
            this.cbQuizName.Name = "cbQuizName";
            this.cbQuizName.Size = new System.Drawing.Size(299, 28);
            this.cbQuizName.TabIndex = 2;
            this.cbQuizName.SelectedIndexChanged += new System.EventHandler(this.cbQuizName_SelectedIndexChanged);
            // 
            // btnUpsertQuizQA
            // 
            this.btnUpsertQuizQA.BackColor = System.Drawing.Color.LightGray;
            this.btnUpsertQuizQA.Location = new System.Drawing.Point(486, 21);
            this.btnUpsertQuizQA.Name = "btnUpsertQuizQA";
            this.btnUpsertQuizQA.Size = new System.Drawing.Size(142, 41);
            this.btnUpsertQuizQA.TabIndex = 6;
            this.btnUpsertQuizQA.Text = "Update";
            this.btnUpsertQuizQA.UseVisualStyleBackColor = false;
            this.btnUpsertQuizQA.Click += new System.EventHandler(this.btnUpsertQuizQA_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(57, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(168, 25);
            this.label9.TabIndex = 3;
            this.label9.Text = "Question Answer:";
            // 
            // panel8
            // 
            this.panel8.AutoScroll = true;
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.Location = new System.Drawing.Point(6, 135);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1081, 473);
            this.panel8.TabIndex = 6;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.quizPaginatePanel);
            this.tabPage2.Controls.Add(this.quizTablePanel);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1094, 615);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Quiz";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txbSearchQuiz);
            this.panel1.Controls.Add(this.btnCancelQuiz);
            this.panel1.Controls.Add(this.btnSaveQuiz);
            this.panel1.Controls.Add(this.btnDeleteQuiz);
            this.panel1.Controls.Add(this.btnEditQuiz);
            this.panel1.Controls.Add(this.btnAddQuiz);
            this.panel1.Controls.Add(this.quizImagePanel);
            this.panel1.Controls.Add(this.quizDifficultyPanel);
            this.panel1.Controls.Add(this.quizNamePanel);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1081, 185);
            this.panel1.TabIndex = 3;
            // 
            // quizNamePanel
            // 
            this.quizNamePanel.BackColor = System.Drawing.Color.White;
            this.quizNamePanel.Controls.Add(this.txbQuizName);
            this.quizNamePanel.Controls.Add(this.label8);
            this.quizNamePanel.ForeColor = System.Drawing.Color.Black;
            this.quizNamePanel.Location = new System.Drawing.Point(92, 11);
            this.quizNamePanel.Name = "quizNamePanel";
            this.quizNamePanel.Size = new System.Drawing.Size(441, 55);
            this.quizNamePanel.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 22);
            this.label8.TabIndex = 0;
            this.label8.Text = "Name:";
            // 
            // txbQuizName
            // 
            this.txbQuizName.Location = new System.Drawing.Point(124, 13);
            this.txbQuizName.Name = "txbQuizName";
            this.txbQuizName.Size = new System.Drawing.Size(299, 28);
            this.txbQuizName.TabIndex = 1;
            // 
            // quizDifficultyPanel
            // 
            this.quizDifficultyPanel.BackColor = System.Drawing.Color.White;
            this.quizDifficultyPanel.Controls.Add(this.cbQuizDifficulty);
            this.quizDifficultyPanel.Controls.Add(this.label6);
            this.quizDifficultyPanel.ForeColor = System.Drawing.Color.Black;
            this.quizDifficultyPanel.Location = new System.Drawing.Point(551, 11);
            this.quizDifficultyPanel.Name = "quizDifficultyPanel";
            this.quizDifficultyPanel.Size = new System.Drawing.Size(441, 55);
            this.quizDifficultyPanel.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 22);
            this.label6.TabIndex = 0;
            this.label6.Text = "Difficulty";
            // 
            // cbQuizDifficulty
            // 
            this.cbQuizDifficulty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbQuizDifficulty.FormattingEnabled = true;
            this.cbQuizDifficulty.Location = new System.Drawing.Point(124, 13);
            this.cbQuizDifficulty.Name = "cbQuizDifficulty";
            this.cbQuizDifficulty.Size = new System.Drawing.Size(299, 28);
            this.cbQuizDifficulty.TabIndex = 1;
            // 
            // quizImagePanel
            // 
            this.quizImagePanel.BackColor = System.Drawing.Color.White;
            this.quizImagePanel.Controls.Add(this.pbQuizImage);
            this.quizImagePanel.Controls.Add(this.btnUploadQuiz);
            this.quizImagePanel.Controls.Add(this.label5);
            this.quizImagePanel.ForeColor = System.Drawing.Color.Black;
            this.quizImagePanel.Location = new System.Drawing.Point(92, 72);
            this.quizImagePanel.Name = "quizImagePanel";
            this.quizImagePanel.Size = new System.Drawing.Size(441, 55);
            this.quizImagePanel.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 22);
            this.label5.TabIndex = 0;
            this.label5.Text = "Image";
            // 
            // btnUploadQuiz
            // 
            this.btnUploadQuiz.BackColor = System.Drawing.Color.LightGray;
            this.btnUploadQuiz.Enabled = false;
            this.btnUploadQuiz.Location = new System.Drawing.Point(124, 7);
            this.btnUploadQuiz.Name = "btnUploadQuiz";
            this.btnUploadQuiz.Size = new System.Drawing.Size(142, 41);
            this.btnUploadQuiz.TabIndex = 1;
            this.btnUploadQuiz.Text = "Upload";
            this.btnUploadQuiz.UseVisualStyleBackColor = false;
            this.btnUploadQuiz.Click += new System.EventHandler(this.btnUploadQuiz_Click);
            // 
            // pbQuizImage
            // 
            this.pbQuizImage.Location = new System.Drawing.Point(272, 7);
            this.pbQuizImage.Name = "pbQuizImage";
            this.pbQuizImage.Size = new System.Drawing.Size(41, 41);
            this.pbQuizImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbQuizImage.TabIndex = 2;
            this.pbQuizImage.TabStop = false;
            // 
            // btnAddQuiz
            // 
            this.btnAddQuiz.BackColor = System.Drawing.Color.LightGray;
            this.btnAddQuiz.Location = new System.Drawing.Point(92, 133);
            this.btnAddQuiz.Name = "btnAddQuiz";
            this.btnAddQuiz.Size = new System.Drawing.Size(142, 41);
            this.btnAddQuiz.TabIndex = 2;
            this.btnAddQuiz.Text = "Add";
            this.btnAddQuiz.UseVisualStyleBackColor = false;
            this.btnAddQuiz.Click += new System.EventHandler(this.btnAddQuiz_Click);
            // 
            // btnEditQuiz
            // 
            this.btnEditQuiz.BackColor = System.Drawing.Color.LightGray;
            this.btnEditQuiz.Location = new System.Drawing.Point(240, 133);
            this.btnEditQuiz.Name = "btnEditQuiz";
            this.btnEditQuiz.Size = new System.Drawing.Size(142, 41);
            this.btnEditQuiz.TabIndex = 4;
            this.btnEditQuiz.Text = "Edit";
            this.btnEditQuiz.UseVisualStyleBackColor = false;
            this.btnEditQuiz.Click += new System.EventHandler(this.btnEditQuiz_Click);
            // 
            // btnDeleteQuiz
            // 
            this.btnDeleteQuiz.BackColor = System.Drawing.Color.LightGray;
            this.btnDeleteQuiz.Location = new System.Drawing.Point(388, 133);
            this.btnDeleteQuiz.Name = "btnDeleteQuiz";
            this.btnDeleteQuiz.Size = new System.Drawing.Size(142, 41);
            this.btnDeleteQuiz.TabIndex = 5;
            this.btnDeleteQuiz.Text = "Delete";
            this.btnDeleteQuiz.UseVisualStyleBackColor = false;
            this.btnDeleteQuiz.Click += new System.EventHandler(this.btnDeleteQuiz_Click);
            // 
            // btnSaveQuiz
            // 
            this.btnSaveQuiz.BackColor = System.Drawing.Color.LightGray;
            this.btnSaveQuiz.Enabled = false;
            this.btnSaveQuiz.Location = new System.Drawing.Point(702, 133);
            this.btnSaveQuiz.Name = "btnSaveQuiz";
            this.btnSaveQuiz.Size = new System.Drawing.Size(142, 41);
            this.btnSaveQuiz.TabIndex = 5;
            this.btnSaveQuiz.Text = "Save";
            this.btnSaveQuiz.UseVisualStyleBackColor = false;
            this.btnSaveQuiz.Click += new System.EventHandler(this.btnSaveQuiz_Click);
            // 
            // btnCancelQuiz
            // 
            this.btnCancelQuiz.BackColor = System.Drawing.Color.LightGray;
            this.btnCancelQuiz.Enabled = false;
            this.btnCancelQuiz.Location = new System.Drawing.Point(850, 133);
            this.btnCancelQuiz.Name = "btnCancelQuiz";
            this.btnCancelQuiz.Size = new System.Drawing.Size(142, 41);
            this.btnCancelQuiz.TabIndex = 5;
            this.btnCancelQuiz.Text = "Cancel";
            this.btnCancelQuiz.UseVisualStyleBackColor = false;
            this.btnCancelQuiz.Click += new System.EventHandler(this.btnCancelQuiz_Click);
            // 
            // txbSearchQuiz
            // 
            this.txbSearchQuiz.Location = new System.Drawing.Point(551, 139);
            this.txbSearchQuiz.Name = "txbSearchQuiz";
            this.txbSearchQuiz.Size = new System.Drawing.Size(145, 28);
            this.txbSearchQuiz.TabIndex = 6;
            this.txbSearchQuiz.TextChanged += new System.EventHandler(this.txbSearchQuiz_TextChanged);
            // 
            // quizTablePanel
            // 
            this.quizTablePanel.BackColor = System.Drawing.Color.White;
            this.quizTablePanel.Controls.Add(this.dtgvQuiz);
            this.quizTablePanel.Location = new System.Drawing.Point(7, 197);
            this.quizTablePanel.Name = "quizTablePanel";
            this.quizTablePanel.Size = new System.Drawing.Size(1081, 336);
            this.quizTablePanel.TabIndex = 4;
            // 
            // dtgvQuiz
            // 
            this.dtgvQuiz.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvQuiz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvQuiz.Location = new System.Drawing.Point(12, 12);
            this.dtgvQuiz.Name = "dtgvQuiz";
            this.dtgvQuiz.RowHeadersWidth = 51;
            this.dtgvQuiz.RowTemplate.Height = 24;
            this.dtgvQuiz.Size = new System.Drawing.Size(1058, 312);
            this.dtgvQuiz.TabIndex = 0;
            // 
            // quizPaginatePanel
            // 
            this.quizPaginatePanel.BackColor = System.Drawing.Color.White;
            this.quizPaginatePanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quizPaginatePanel.Location = new System.Drawing.Point(7, 539);
            this.quizPaginatePanel.Name = "quizPaginatePanel";
            this.quizPaginatePanel.Size = new System.Drawing.Size(1081, 70);
            this.quizPaginatePanel.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.userPaginatePanel);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.userTablePanel);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1094, 615);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "User";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // userTablePanel
            // 
            this.userTablePanel.BackColor = System.Drawing.Color.White;
            this.userTablePanel.Controls.Add(this.dtgvUser);
            this.userTablePanel.Location = new System.Drawing.Point(7, 197);
            this.userTablePanel.Name = "userTablePanel";
            this.userTablePanel.Size = new System.Drawing.Size(1081, 336);
            this.userTablePanel.TabIndex = 0;
            // 
            // dtgvUser
            // 
            this.dtgvUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvUser.Location = new System.Drawing.Point(12, 12);
            this.dtgvUser.Name = "dtgvUser";
            this.dtgvUser.RowHeadersWidth = 51;
            this.dtgvUser.RowTemplate.Height = 24;
            this.dtgvUser.Size = new System.Drawing.Size(1058, 312);
            this.dtgvUser.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txbSearchUser);
            this.panel3.Controls.Add(this.btnCancelUser);
            this.panel3.Controls.Add(this.btnSaveUser);
            this.panel3.Controls.Add(this.btnDeleteUser);
            this.panel3.Controls.Add(this.btnEditUser);
            this.panel3.Controls.Add(this.btnAddUser);
            this.panel3.Controls.Add(this.userImagePanel);
            this.panel3.Controls.Add(this.userNamePanel);
            this.panel3.Controls.Add(this.userPasswordPanel);
            this.panel3.Controls.Add(this.userEmailPanel);
            this.panel3.Location = new System.Drawing.Point(6, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1082, 185);
            this.panel3.TabIndex = 2;
            // 
            // userEmailPanel
            // 
            this.userEmailPanel.BackColor = System.Drawing.Color.White;
            this.userEmailPanel.Controls.Add(this.txbUserEmail);
            this.userEmailPanel.Controls.Add(this.label1);
            this.userEmailPanel.ForeColor = System.Drawing.Color.Black;
            this.userEmailPanel.Location = new System.Drawing.Point(92, 11);
            this.userEmailPanel.Name = "userEmailPanel";
            this.userEmailPanel.Size = new System.Drawing.Size(441, 55);
            this.userEmailPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Email:";
            // 
            // txbUserEmail
            // 
            this.txbUserEmail.Location = new System.Drawing.Point(124, 13);
            this.txbUserEmail.Name = "txbUserEmail";
            this.txbUserEmail.ReadOnly = true;
            this.txbUserEmail.Size = new System.Drawing.Size(299, 28);
            this.txbUserEmail.TabIndex = 1;
            // 
            // userPasswordPanel
            // 
            this.userPasswordPanel.BackColor = System.Drawing.Color.White;
            this.userPasswordPanel.Controls.Add(this.txbUserPassword);
            this.userPasswordPanel.Controls.Add(this.label2);
            this.userPasswordPanel.ForeColor = System.Drawing.Color.Black;
            this.userPasswordPanel.Location = new System.Drawing.Point(92, 72);
            this.userPasswordPanel.Name = "userPasswordPanel";
            this.userPasswordPanel.Size = new System.Drawing.Size(441, 55);
            this.userPasswordPanel.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Password:";
            // 
            // txbUserPassword
            // 
            this.txbUserPassword.Location = new System.Drawing.Point(124, 13);
            this.txbUserPassword.Name = "txbUserPassword";
            this.txbUserPassword.ReadOnly = true;
            this.txbUserPassword.Size = new System.Drawing.Size(299, 28);
            this.txbUserPassword.TabIndex = 1;
            // 
            // userNamePanel
            // 
            this.userNamePanel.BackColor = System.Drawing.Color.White;
            this.userNamePanel.Controls.Add(this.txbUserName);
            this.userNamePanel.Controls.Add(this.label3);
            this.userNamePanel.ForeColor = System.Drawing.Color.Black;
            this.userNamePanel.Location = new System.Drawing.Point(551, 11);
            this.userNamePanel.Name = "userNamePanel";
            this.userNamePanel.Size = new System.Drawing.Size(441, 55);
            this.userNamePanel.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Name:";
            // 
            // txbUserName
            // 
            this.txbUserName.Location = new System.Drawing.Point(124, 13);
            this.txbUserName.Name = "txbUserName";
            this.txbUserName.Size = new System.Drawing.Size(299, 28);
            this.txbUserName.TabIndex = 1;
            // 
            // userImagePanel
            // 
            this.userImagePanel.BackColor = System.Drawing.Color.White;
            this.userImagePanel.Controls.Add(this.pbUserImage);
            this.userImagePanel.Controls.Add(this.btnUploadUserImage);
            this.userImagePanel.Controls.Add(this.label4);
            this.userImagePanel.ForeColor = System.Drawing.Color.Black;
            this.userImagePanel.Location = new System.Drawing.Point(551, 72);
            this.userImagePanel.Name = "userImagePanel";
            this.userImagePanel.Size = new System.Drawing.Size(441, 55);
            this.userImagePanel.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 22);
            this.label4.TabIndex = 0;
            this.label4.Text = "Image:";
            // 
            // btnUploadUserImage
            // 
            this.btnUploadUserImage.BackColor = System.Drawing.Color.LightGray;
            this.btnUploadUserImage.Enabled = false;
            this.btnUploadUserImage.Location = new System.Drawing.Point(124, 7);
            this.btnUploadUserImage.Name = "btnUploadUserImage";
            this.btnUploadUserImage.Size = new System.Drawing.Size(142, 41);
            this.btnUploadUserImage.TabIndex = 1;
            this.btnUploadUserImage.Text = "Upload";
            this.btnUploadUserImage.UseVisualStyleBackColor = false;
            this.btnUploadUserImage.Click += new System.EventHandler(this.btnUploadUserImage_Click);
            // 
            // pbUserImage
            // 
            this.pbUserImage.Location = new System.Drawing.Point(272, 7);
            this.pbUserImage.Name = "pbUserImage";
            this.pbUserImage.Size = new System.Drawing.Size(41, 41);
            this.pbUserImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbUserImage.TabIndex = 2;
            this.pbUserImage.TabStop = false;
            // 
            // btnAddUser
            // 
            this.btnAddUser.BackColor = System.Drawing.Color.LightGray;
            this.btnAddUser.Location = new System.Drawing.Point(92, 133);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(142, 41);
            this.btnAddUser.TabIndex = 2;
            this.btnAddUser.Text = "Add";
            this.btnAddUser.UseVisualStyleBackColor = false;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnEditUser
            // 
            this.btnEditUser.BackColor = System.Drawing.Color.LightGray;
            this.btnEditUser.Location = new System.Drawing.Point(240, 133);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(142, 41);
            this.btnEditUser.TabIndex = 4;
            this.btnEditUser.Text = "Edit";
            this.btnEditUser.UseVisualStyleBackColor = false;
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.BackColor = System.Drawing.Color.LightGray;
            this.btnDeleteUser.Location = new System.Drawing.Point(388, 133);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(142, 41);
            this.btnDeleteUser.TabIndex = 5;
            this.btnDeleteUser.Text = "Delete";
            this.btnDeleteUser.UseVisualStyleBackColor = false;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnSaveUser
            // 
            this.btnSaveUser.BackColor = System.Drawing.Color.LightGray;
            this.btnSaveUser.Enabled = false;
            this.btnSaveUser.Location = new System.Drawing.Point(702, 133);
            this.btnSaveUser.Name = "btnSaveUser";
            this.btnSaveUser.Size = new System.Drawing.Size(142, 41);
            this.btnSaveUser.TabIndex = 5;
            this.btnSaveUser.Text = "Save";
            this.btnSaveUser.UseVisualStyleBackColor = false;
            this.btnSaveUser.Click += new System.EventHandler(this.btnSaveUser_Click);
            // 
            // btnCancelUser
            // 
            this.btnCancelUser.BackColor = System.Drawing.Color.LightGray;
            this.btnCancelUser.Enabled = false;
            this.btnCancelUser.Location = new System.Drawing.Point(850, 133);
            this.btnCancelUser.Name = "btnCancelUser";
            this.btnCancelUser.Size = new System.Drawing.Size(142, 41);
            this.btnCancelUser.TabIndex = 5;
            this.btnCancelUser.Text = "Cancel";
            this.btnCancelUser.UseVisualStyleBackColor = false;
            this.btnCancelUser.Click += new System.EventHandler(this.btnCancelUser_Click);
            // 
            // txbSearchUser
            // 
            this.txbSearchUser.Location = new System.Drawing.Point(551, 139);
            this.txbSearchUser.Name = "txbSearchUser";
            this.txbSearchUser.Size = new System.Drawing.Size(145, 28);
            this.txbSearchUser.TabIndex = 6;
            this.txbSearchUser.TextChanged += new System.EventHandler(this.txbSearchUser_TextChanged);
            // 
            // userPaginatePanel
            // 
            this.userPaginatePanel.BackColor = System.Drawing.Color.White;
            this.userPaginatePanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userPaginatePanel.Location = new System.Drawing.Point(7, 539);
            this.userPaginatePanel.Name = "userPaginatePanel";
            this.userPaginatePanel.Size = new System.Drawing.Size(1081, 70);
            this.userPaginatePanel.TabIndex = 3;
            // 
            // tcAdmin
            // 
            this.tcAdmin.Controls.Add(this.tabPage1);
            this.tcAdmin.Controls.Add(this.tabPage2);
            this.tcAdmin.Controls.Add(this.tpQuiz);
            this.tcAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcAdmin.Location = new System.Drawing.Point(13, 13);
            this.tcAdmin.Name = "tcAdmin";
            this.tcAdmin.SelectedIndex = 0;
            this.tcAdmin.Size = new System.Drawing.Size(1102, 650);
            this.tcAdmin.TabIndex = 0;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 675);
            this.Controls.Add(this.tcAdmin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            this.tpQuiz.ResumeLayout(false);
            this.tpQuiz.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.listQuizPanel.ResumeLayout(false);
            this.listQuizPanel.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.quizNamePanel.ResumeLayout(false);
            this.quizNamePanel.PerformLayout();
            this.quizDifficultyPanel.ResumeLayout(false);
            this.quizDifficultyPanel.PerformLayout();
            this.quizImagePanel.ResumeLayout(false);
            this.quizImagePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbQuizImage)).EndInit();
            this.quizTablePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvQuiz)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.userTablePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvUser)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.userEmailPanel.ResumeLayout(false);
            this.userEmailPanel.PerformLayout();
            this.userPasswordPanel.ResumeLayout(false);
            this.userPasswordPanel.PerformLayout();
            this.userNamePanel.ResumeLayout(false);
            this.userNamePanel.PerformLayout();
            this.userImagePanel.ResumeLayout(false);
            this.userImagePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserImage)).EndInit();
            this.tcAdmin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog userFileDialog;
        private System.Windows.Forms.OpenFileDialog quizFileDialog;
        private System.Windows.Forms.TabPage tpQuiz;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnUpsertQuizQA;
        private System.Windows.Forms.Panel listQuizPanel;
        private System.Windows.Forms.ComboBox cbQuizName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel quizPaginatePanel;
        private System.Windows.Forms.Panel quizTablePanel;
        private System.Windows.Forms.DataGridView dtgvQuiz;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txbSearchQuiz;
        private System.Windows.Forms.Button btnCancelQuiz;
        private System.Windows.Forms.Button btnSaveQuiz;
        private System.Windows.Forms.Button btnDeleteQuiz;
        private System.Windows.Forms.Button btnEditQuiz;
        private System.Windows.Forms.Button btnAddQuiz;
        private System.Windows.Forms.Panel quizImagePanel;
        private System.Windows.Forms.PictureBox pbQuizImage;
        private System.Windows.Forms.Button btnUploadQuiz;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel quizDifficultyPanel;
        private System.Windows.Forms.ComboBox cbQuizDifficulty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel quizNamePanel;
        private System.Windows.Forms.TextBox txbQuizName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel userPaginatePanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txbSearchUser;
        private System.Windows.Forms.Button btnCancelUser;
        private System.Windows.Forms.Button btnSaveUser;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Panel userImagePanel;
        private System.Windows.Forms.PictureBox pbUserImage;
        private System.Windows.Forms.Button btnUploadUserImage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel userNamePanel;
        private System.Windows.Forms.TextBox txbUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel userPasswordPanel;
        private System.Windows.Forms.TextBox txbUserPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel userEmailPanel;
        private System.Windows.Forms.TextBox txbUserEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel userTablePanel;
        private System.Windows.Forms.DataGridView dtgvUser;
        private System.Windows.Forms.TabControl tcAdmin;
    }
}