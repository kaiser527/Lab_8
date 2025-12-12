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
            this.tpQuestionAnswer = new System.Windows.Forms.TabPage();
            this.quizRichText = new System.Windows.Forms.RichTextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnUpsertQuizQA = new System.Windows.Forms.Button();
            this.listQuizPanel = new System.Windows.Forms.Panel();
            this.cbQuizName = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tpQuiz = new System.Windows.Forms.TabPage();
            this.quizPaginatePanel = new System.Windows.Forms.Panel();
            this.quizTablePanel = new System.Windows.Forms.Panel();
            this.dtgvQuiz = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.quizCategoryPanel = new System.Windows.Forms.Panel();
            this.cbQuizCategory = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txbSearchQuiz = new System.Windows.Forms.TextBox();
            this.btnCancelQuiz = new System.Windows.Forms.Button();
            this.btnSaveQuiz = new System.Windows.Forms.Button();
            this.btnDeleteQuiz = new System.Windows.Forms.Button();
            this.btnEditQuiz = new System.Windows.Forms.Button();
            this.btnAddQuiz = new System.Windows.Forms.Button();
            this.quizImagePanel = new System.Windows.Forms.Panel();
            this.pbQuizImage = new System.Windows.Forms.PictureBox();
            this.btnUploadQuiz = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.quizDifficultyPanel = new System.Windows.Forms.Panel();
            this.cbQuizDifficulty = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.quizNamePanel = new System.Windows.Forms.Panel();
            this.txbQuizName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tpUser = new System.Windows.Forms.TabPage();
            this.userPaginatePanel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.userRolePanel = new System.Windows.Forms.Panel();
            this.cbUserRole = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txbSearchUser = new System.Windows.Forms.TextBox();
            this.btnCancelUser = new System.Windows.Forms.Button();
            this.btnSaveUser = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.userImagePanel = new System.Windows.Forms.Panel();
            this.pbUserImage = new System.Windows.Forms.PictureBox();
            this.btnUploadUserImage = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.userNamePanel = new System.Windows.Forms.Panel();
            this.txbUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.userPasswordPanel = new System.Windows.Forms.Panel();
            this.txbUserPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.userEmailPanel = new System.Windows.Forms.Panel();
            this.txbUserEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.userTablePanel = new System.Windows.Forms.Panel();
            this.dtgvUser = new System.Windows.Forms.DataGridView();
            this.tcAdmin = new System.Windows.Forms.TabControl();
            this.tpRole = new System.Windows.Forms.TabPage();
            this.moduleListPanel = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.roleTablePanel = new System.Windows.Forms.Panel();
            this.dtgvRole = new System.Windows.Forms.DataGridView();
            this.flpRole = new System.Windows.Forms.Panel();
            this.rolePaginatePanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txbSearchRole = new System.Windows.Forms.TextBox();
            this.btnCancelRole = new System.Windows.Forms.Button();
            this.btnSaveRole = new System.Windows.Forms.Button();
            this.btnDeleteRole = new System.Windows.Forms.Button();
            this.btnEditRole = new System.Windows.Forms.Button();
            this.btnAddRole = new System.Windows.Forms.Button();
            this.roleIsActivePanel = new System.Windows.Forms.Panel();
            this.cbIsActiveRole = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.roleNamePanel = new System.Windows.Forms.Panel();
            this.txbRoleName = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tpPermission = new System.Windows.Forms.TabPage();
            this.tablePermissionPanel = new System.Windows.Forms.Panel();
            this.dtgvPermission = new System.Windows.Forms.DataGridView();
            this.permissionPaginatePanel = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.permissionModulePanel = new System.Windows.Forms.Panel();
            this.cbPermissionModule = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txbSearchPermission = new System.Windows.Forms.TextBox();
            this.btnCancelPermission = new System.Windows.Forms.Button();
            this.btnSavePermission = new System.Windows.Forms.Button();
            this.btnDeletePermission = new System.Windows.Forms.Button();
            this.btnEditPermission = new System.Windows.Forms.Button();
            this.btnAddPermission = new System.Windows.Forms.Button();
            this.permissionNamePanel = new System.Windows.Forms.Panel();
            this.txbPermissionName = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tpCategory = new System.Windows.Forms.TabPage();
            this.tableCategory = new System.Windows.Forms.Panel();
            this.dtgvCategory = new System.Windows.Forms.DataGridView();
            this.categoryPaginatePanel = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.categoryIsActivePanel = new System.Windows.Forms.Panel();
            this.cbCategoryIsActive = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txbSearchCategory = new System.Windows.Forms.TextBox();
            this.btnCancelCategory = new System.Windows.Forms.Button();
            this.btnSaveCategory = new System.Windows.Forms.Button();
            this.btnDeleteCategory = new System.Windows.Forms.Button();
            this.btnEditCategory = new System.Windows.Forms.Button();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.categoryNamePanel = new System.Windows.Forms.Panel();
            this.txbCategoryName = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.nmTime = new System.Windows.Forms.NumericUpDown();
            this.panel6 = new System.Windows.Forms.Panel();
            this.Time = new System.Windows.Forms.Label();
            this.tpQuestionAnswer.SuspendLayout();
            this.panel7.SuspendLayout();
            this.listQuizPanel.SuspendLayout();
            this.tpQuiz.SuspendLayout();
            this.quizTablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvQuiz)).BeginInit();
            this.panel1.SuspendLayout();
            this.quizCategoryPanel.SuspendLayout();
            this.quizImagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbQuizImage)).BeginInit();
            this.quizDifficultyPanel.SuspendLayout();
            this.quizNamePanel.SuspendLayout();
            this.tpUser.SuspendLayout();
            this.panel3.SuspendLayout();
            this.userRolePanel.SuspendLayout();
            this.userImagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserImage)).BeginInit();
            this.userNamePanel.SuspendLayout();
            this.userPasswordPanel.SuspendLayout();
            this.userEmailPanel.SuspendLayout();
            this.userTablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvUser)).BeginInit();
            this.tcAdmin.SuspendLayout();
            this.tpRole.SuspendLayout();
            this.moduleListPanel.SuspendLayout();
            this.roleTablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvRole)).BeginInit();
            this.panel2.SuspendLayout();
            this.roleIsActivePanel.SuspendLayout();
            this.roleNamePanel.SuspendLayout();
            this.tpPermission.SuspendLayout();
            this.tablePermissionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvPermission)).BeginInit();
            this.panel4.SuspendLayout();
            this.permissionModulePanel.SuspendLayout();
            this.permissionNamePanel.SuspendLayout();
            this.tpCategory.SuspendLayout();
            this.tableCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCategory)).BeginInit();
            this.panel5.SuspendLayout();
            this.categoryIsActivePanel.SuspendLayout();
            this.categoryNamePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmTime)).BeginInit();
            this.panel6.SuspendLayout();
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
            // tpQuestionAnswer
            // 
            this.tpQuestionAnswer.Controls.Add(this.panel6);
            this.tpQuestionAnswer.Controls.Add(this.quizRichText);
            this.tpQuestionAnswer.Controls.Add(this.panel8);
            this.tpQuestionAnswer.Controls.Add(this.label9);
            this.tpQuestionAnswer.Controls.Add(this.panel7);
            this.tpQuestionAnswer.Location = new System.Drawing.Point(4, 31);
            this.tpQuestionAnswer.Name = "tpQuestionAnswer";
            this.tpQuestionAnswer.Size = new System.Drawing.Size(1094, 615);
            this.tpQuestionAnswer.TabIndex = 2;
            this.tpQuestionAnswer.Text = "Question-Answer";
            this.tpQuestionAnswer.UseVisualStyleBackColor = true;
            // 
            // quizRichText
            // 
            this.quizRichText.Location = new System.Drawing.Point(646, 6);
            this.quizRichText.Name = "quizRichText";
            this.quizRichText.Size = new System.Drawing.Size(397, 145);
            this.quizRichText.TabIndex = 7;
            this.quizRichText.Text = "";
            // 
            // panel8
            // 
            this.panel8.AutoScroll = true;
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.Location = new System.Drawing.Point(3, 157);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1088, 455);
            this.panel8.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(57, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(168, 25);
            this.label9.TabIndex = 3;
            this.label9.Text = "Question Answer:";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnUpsertQuizQA);
            this.panel7.Controls.Add(this.listQuizPanel);
            this.panel7.Location = new System.Drawing.Point(6, 6);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(634, 84);
            this.panel7.TabIndex = 5;
            // 
            // btnUpsertQuizQA
            // 
            this.btnUpsertQuizQA.BackColor = System.Drawing.Color.LightGray;
            this.btnUpsertQuizQA.Location = new System.Drawing.Point(486, 21);
            this.btnUpsertQuizQA.Name = "btnUpsertQuizQA";
            this.btnUpsertQuizQA.Size = new System.Drawing.Size(145, 41);
            this.btnUpsertQuizQA.TabIndex = 6;
            this.btnUpsertQuizQA.Text = "Update";
            this.btnUpsertQuizQA.UseVisualStyleBackColor = false;
            this.btnUpsertQuizQA.Click += new System.EventHandler(this.btnUpsertQuizQA_Click);
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
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 22);
            this.label12.TabIndex = 0;
            this.label12.Text = "Quizzes:";
            // 
            // tpQuiz
            // 
            this.tpQuiz.Controls.Add(this.quizPaginatePanel);
            this.tpQuiz.Controls.Add(this.quizTablePanel);
            this.tpQuiz.Controls.Add(this.panel1);
            this.tpQuiz.Location = new System.Drawing.Point(4, 31);
            this.tpQuiz.Name = "tpQuiz";
            this.tpQuiz.Padding = new System.Windows.Forms.Padding(3);
            this.tpQuiz.Size = new System.Drawing.Size(1094, 615);
            this.tpQuiz.TabIndex = 1;
            this.tpQuiz.Text = "Quiz";
            this.tpQuiz.UseVisualStyleBackColor = true;
            // 
            // quizPaginatePanel
            // 
            this.quizPaginatePanel.BackColor = System.Drawing.Color.White;
            this.quizPaginatePanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quizPaginatePanel.Location = new System.Drawing.Point(6, 539);
            this.quizPaginatePanel.Name = "quizPaginatePanel";
            this.quizPaginatePanel.Size = new System.Drawing.Size(1081, 70);
            this.quizPaginatePanel.TabIndex = 5;
            // 
            // quizTablePanel
            // 
            this.quizTablePanel.BackColor = System.Drawing.Color.White;
            this.quizTablePanel.Controls.Add(this.dtgvQuiz);
            this.quizTablePanel.Location = new System.Drawing.Point(6, 197);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.quizCategoryPanel);
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
            // quizCategoryPanel
            // 
            this.quizCategoryPanel.BackColor = System.Drawing.Color.White;
            this.quizCategoryPanel.Controls.Add(this.cbQuizCategory);
            this.quizCategoryPanel.Controls.Add(this.label7);
            this.quizCategoryPanel.ForeColor = System.Drawing.Color.Black;
            this.quizCategoryPanel.Location = new System.Drawing.Point(551, 72);
            this.quizCategoryPanel.Name = "quizCategoryPanel";
            this.quizCategoryPanel.Size = new System.Drawing.Size(441, 55);
            this.quizCategoryPanel.TabIndex = 3;
            // 
            // cbQuizCategory
            // 
            this.cbQuizCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbQuizCategory.FormattingEnabled = true;
            this.cbQuizCategory.Location = new System.Drawing.Point(124, 13);
            this.cbQuizCategory.Name = "cbQuizCategory";
            this.cbQuizCategory.Size = new System.Drawing.Size(299, 28);
            this.cbQuizCategory.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 22);
            this.label7.TabIndex = 0;
            this.label7.Text = "Category:";
            // 
            // txbSearchQuiz
            // 
            this.txbSearchQuiz.Location = new System.Drawing.Point(551, 139);
            this.txbSearchQuiz.Name = "txbSearchQuiz";
            this.txbSearchQuiz.Size = new System.Drawing.Size(145, 28);
            this.txbSearchQuiz.TabIndex = 6;
            this.txbSearchQuiz.TextChanged += new System.EventHandler(this.txbSearchQuiz_TextChanged);
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
            // pbQuizImage
            // 
            this.pbQuizImage.Location = new System.Drawing.Point(272, 0);
            this.pbQuizImage.Name = "pbQuizImage";
            this.pbQuizImage.Size = new System.Drawing.Size(55, 55);
            this.pbQuizImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbQuizImage.TabIndex = 2;
            this.pbQuizImage.TabStop = false;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 22);
            this.label5.TabIndex = 0;
            this.label5.Text = "Image:";
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
            // cbQuizDifficulty
            // 
            this.cbQuizDifficulty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbQuizDifficulty.FormattingEnabled = true;
            this.cbQuizDifficulty.Location = new System.Drawing.Point(124, 13);
            this.cbQuizDifficulty.Name = "cbQuizDifficulty";
            this.cbQuizDifficulty.Size = new System.Drawing.Size(299, 28);
            this.cbQuizDifficulty.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 22);
            this.label6.TabIndex = 0;
            this.label6.Text = "Difficulty:";
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
            // txbQuizName
            // 
            this.txbQuizName.Location = new System.Drawing.Point(124, 13);
            this.txbQuizName.Name = "txbQuizName";
            this.txbQuizName.Size = new System.Drawing.Size(299, 28);
            this.txbQuizName.TabIndex = 1;
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
            // tpUser
            // 
            this.tpUser.Controls.Add(this.userPaginatePanel);
            this.tpUser.Controls.Add(this.panel3);
            this.tpUser.Controls.Add(this.userTablePanel);
            this.tpUser.Location = new System.Drawing.Point(4, 31);
            this.tpUser.Name = "tpUser";
            this.tpUser.Padding = new System.Windows.Forms.Padding(3);
            this.tpUser.Size = new System.Drawing.Size(1094, 615);
            this.tpUser.TabIndex = 0;
            this.tpUser.Text = "User";
            this.tpUser.UseVisualStyleBackColor = true;
            // 
            // userPaginatePanel
            // 
            this.userPaginatePanel.BackColor = System.Drawing.Color.White;
            this.userPaginatePanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userPaginatePanel.Location = new System.Drawing.Point(6, 539);
            this.userPaginatePanel.Name = "userPaginatePanel";
            this.userPaginatePanel.Size = new System.Drawing.Size(1082, 70);
            this.userPaginatePanel.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.userRolePanel);
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
            this.panel3.Size = new System.Drawing.Size(1082, 241);
            this.panel3.TabIndex = 2;
            // 
            // userRolePanel
            // 
            this.userRolePanel.BackColor = System.Drawing.Color.White;
            this.userRolePanel.Controls.Add(this.cbUserRole);
            this.userRolePanel.Controls.Add(this.label10);
            this.userRolePanel.ForeColor = System.Drawing.Color.Black;
            this.userRolePanel.Location = new System.Drawing.Point(92, 133);
            this.userRolePanel.Name = "userRolePanel";
            this.userRolePanel.Size = new System.Drawing.Size(441, 55);
            this.userRolePanel.TabIndex = 7;
            // 
            // cbUserRole
            // 
            this.cbUserRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbUserRole.FormattingEnabled = true;
            this.cbUserRole.Location = new System.Drawing.Point(124, 13);
            this.cbUserRole.Name = "cbUserRole";
            this.cbUserRole.Size = new System.Drawing.Size(299, 28);
            this.cbUserRole.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 22);
            this.label10.TabIndex = 0;
            this.label10.Text = "Role:";
            // 
            // txbSearchUser
            // 
            this.txbSearchUser.Location = new System.Drawing.Point(551, 200);
            this.txbSearchUser.Name = "txbSearchUser";
            this.txbSearchUser.Size = new System.Drawing.Size(145, 28);
            this.txbSearchUser.TabIndex = 6;
            this.txbSearchUser.TextChanged += new System.EventHandler(this.txbSearchUser_TextChanged);
            // 
            // btnCancelUser
            // 
            this.btnCancelUser.BackColor = System.Drawing.Color.LightGray;
            this.btnCancelUser.Enabled = false;
            this.btnCancelUser.Location = new System.Drawing.Point(850, 194);
            this.btnCancelUser.Name = "btnCancelUser";
            this.btnCancelUser.Size = new System.Drawing.Size(142, 41);
            this.btnCancelUser.TabIndex = 5;
            this.btnCancelUser.Text = "Cancel";
            this.btnCancelUser.UseVisualStyleBackColor = false;
            this.btnCancelUser.Click += new System.EventHandler(this.btnCancelUser_Click);
            // 
            // btnSaveUser
            // 
            this.btnSaveUser.BackColor = System.Drawing.Color.LightGray;
            this.btnSaveUser.Enabled = false;
            this.btnSaveUser.Location = new System.Drawing.Point(702, 194);
            this.btnSaveUser.Name = "btnSaveUser";
            this.btnSaveUser.Size = new System.Drawing.Size(142, 41);
            this.btnSaveUser.TabIndex = 5;
            this.btnSaveUser.Text = "Save";
            this.btnSaveUser.UseVisualStyleBackColor = false;
            this.btnSaveUser.Click += new System.EventHandler(this.btnSaveUser_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.BackColor = System.Drawing.Color.LightGray;
            this.btnDeleteUser.Location = new System.Drawing.Point(388, 194);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(142, 41);
            this.btnDeleteUser.TabIndex = 5;
            this.btnDeleteUser.Text = "Delete";
            this.btnDeleteUser.UseVisualStyleBackColor = false;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnEditUser
            // 
            this.btnEditUser.BackColor = System.Drawing.Color.LightGray;
            this.btnEditUser.Location = new System.Drawing.Point(240, 194);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(142, 41);
            this.btnEditUser.TabIndex = 4;
            this.btnEditUser.Text = "Edit";
            this.btnEditUser.UseVisualStyleBackColor = false;
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.BackColor = System.Drawing.Color.LightGray;
            this.btnAddUser.Location = new System.Drawing.Point(92, 194);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(142, 41);
            this.btnAddUser.TabIndex = 2;
            this.btnAddUser.Text = "Add";
            this.btnAddUser.UseVisualStyleBackColor = false;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
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
            // pbUserImage
            // 
            this.pbUserImage.Location = new System.Drawing.Point(272, 0);
            this.pbUserImage.Name = "pbUserImage";
            this.pbUserImage.Size = new System.Drawing.Size(55, 55);
            this.pbUserImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbUserImage.TabIndex = 2;
            this.pbUserImage.TabStop = false;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 22);
            this.label4.TabIndex = 0;
            this.label4.Text = "Image:";
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
            // txbUserName
            // 
            this.txbUserName.Location = new System.Drawing.Point(124, 13);
            this.txbUserName.Name = "txbUserName";
            this.txbUserName.Size = new System.Drawing.Size(299, 28);
            this.txbUserName.TabIndex = 1;
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
            // txbUserPassword
            // 
            this.txbUserPassword.Location = new System.Drawing.Point(124, 13);
            this.txbUserPassword.Name = "txbUserPassword";
            this.txbUserPassword.ReadOnly = true;
            this.txbUserPassword.Size = new System.Drawing.Size(299, 28);
            this.txbUserPassword.TabIndex = 1;
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
            // txbUserEmail
            // 
            this.txbUserEmail.Location = new System.Drawing.Point(124, 13);
            this.txbUserEmail.Name = "txbUserEmail";
            this.txbUserEmail.ReadOnly = true;
            this.txbUserEmail.Size = new System.Drawing.Size(299, 28);
            this.txbUserEmail.TabIndex = 1;
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
            // userTablePanel
            // 
            this.userTablePanel.BackColor = System.Drawing.Color.White;
            this.userTablePanel.Controls.Add(this.dtgvUser);
            this.userTablePanel.Location = new System.Drawing.Point(6, 253);
            this.userTablePanel.Name = "userTablePanel";
            this.userTablePanel.Size = new System.Drawing.Size(1082, 280);
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
            this.dtgvUser.Size = new System.Drawing.Size(1059, 256);
            this.dtgvUser.TabIndex = 0;
            // 
            // tcAdmin
            // 
            this.tcAdmin.Controls.Add(this.tpUser);
            this.tcAdmin.Controls.Add(this.tpQuiz);
            this.tcAdmin.Controls.Add(this.tpQuestionAnswer);
            this.tcAdmin.Controls.Add(this.tpRole);
            this.tcAdmin.Controls.Add(this.tpPermission);
            this.tcAdmin.Controls.Add(this.tpCategory);
            this.tcAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcAdmin.Location = new System.Drawing.Point(13, 13);
            this.tcAdmin.Name = "tcAdmin";
            this.tcAdmin.SelectedIndex = 0;
            this.tcAdmin.Size = new System.Drawing.Size(1102, 650);
            this.tcAdmin.TabIndex = 0;
            // 
            // tpRole
            // 
            this.tpRole.Controls.Add(this.moduleListPanel);
            this.tpRole.Controls.Add(this.roleTablePanel);
            this.tpRole.Controls.Add(this.flpRole);
            this.tpRole.Controls.Add(this.rolePaginatePanel);
            this.tpRole.Controls.Add(this.panel2);
            this.tpRole.Location = new System.Drawing.Point(4, 31);
            this.tpRole.Name = "tpRole";
            this.tpRole.Size = new System.Drawing.Size(1094, 615);
            this.tpRole.TabIndex = 3;
            this.tpRole.Text = "Role";
            this.tpRole.UseVisualStyleBackColor = true;
            // 
            // moduleListPanel
            // 
            this.moduleListPanel.BackColor = System.Drawing.Color.White;
            this.moduleListPanel.Controls.Add(this.label11);
            this.moduleListPanel.Location = new System.Drawing.Point(569, 197);
            this.moduleListPanel.Name = "moduleListPanel";
            this.moduleListPanel.Size = new System.Drawing.Size(518, 65);
            this.moduleListPanel.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(196, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(130, 29);
            this.label11.TabIndex = 19;
            this.label11.Text = "Module list";
            // 
            // roleTablePanel
            // 
            this.roleTablePanel.BackColor = System.Drawing.Color.White;
            this.roleTablePanel.Controls.Add(this.dtgvRole);
            this.roleTablePanel.Location = new System.Drawing.Point(6, 197);
            this.roleTablePanel.Name = "roleTablePanel";
            this.roleTablePanel.Size = new System.Drawing.Size(557, 336);
            this.roleTablePanel.TabIndex = 17;
            // 
            // dtgvRole
            // 
            this.dtgvRole.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvRole.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvRole.Location = new System.Drawing.Point(12, 12);
            this.dtgvRole.Name = "dtgvRole";
            this.dtgvRole.RowHeadersWidth = 51;
            this.dtgvRole.RowTemplate.Height = 24;
            this.dtgvRole.Size = new System.Drawing.Size(533, 312);
            this.dtgvRole.TabIndex = 0;
            this.dtgvRole.SelectionChanged += new System.EventHandler(this.dtgvRole_SelectionChanged);
            // 
            // flpRole
            // 
            this.flpRole.BackColor = System.Drawing.Color.White;
            this.flpRole.Location = new System.Drawing.Point(569, 268);
            this.flpRole.Name = "flpRole";
            this.flpRole.Size = new System.Drawing.Size(518, 265);
            this.flpRole.TabIndex = 16;
            // 
            // rolePaginatePanel
            // 
            this.rolePaginatePanel.BackColor = System.Drawing.Color.White;
            this.rolePaginatePanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rolePaginatePanel.Location = new System.Drawing.Point(6, 539);
            this.rolePaginatePanel.Name = "rolePaginatePanel";
            this.rolePaginatePanel.Size = new System.Drawing.Size(1081, 70);
            this.rolePaginatePanel.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txbSearchRole);
            this.panel2.Controls.Add(this.btnCancelRole);
            this.panel2.Controls.Add(this.btnSaveRole);
            this.panel2.Controls.Add(this.btnDeleteRole);
            this.panel2.Controls.Add(this.btnEditRole);
            this.panel2.Controls.Add(this.btnAddRole);
            this.panel2.Controls.Add(this.roleIsActivePanel);
            this.panel2.Controls.Add(this.roleNamePanel);
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1081, 185);
            this.panel2.TabIndex = 4;
            // 
            // txbSearchRole
            // 
            this.txbSearchRole.Location = new System.Drawing.Point(551, 139);
            this.txbSearchRole.Name = "txbSearchRole";
            this.txbSearchRole.Size = new System.Drawing.Size(145, 28);
            this.txbSearchRole.TabIndex = 6;
            this.txbSearchRole.TextChanged += new System.EventHandler(this.txbSearchRole_TextChanged);
            // 
            // btnCancelRole
            // 
            this.btnCancelRole.BackColor = System.Drawing.Color.LightGray;
            this.btnCancelRole.Enabled = false;
            this.btnCancelRole.Location = new System.Drawing.Point(850, 133);
            this.btnCancelRole.Name = "btnCancelRole";
            this.btnCancelRole.Size = new System.Drawing.Size(142, 41);
            this.btnCancelRole.TabIndex = 5;
            this.btnCancelRole.Text = "Cancel";
            this.btnCancelRole.UseVisualStyleBackColor = false;
            this.btnCancelRole.Click += new System.EventHandler(this.btnCancelRole_Click);
            // 
            // btnSaveRole
            // 
            this.btnSaveRole.BackColor = System.Drawing.Color.LightGray;
            this.btnSaveRole.Enabled = false;
            this.btnSaveRole.Location = new System.Drawing.Point(702, 133);
            this.btnSaveRole.Name = "btnSaveRole";
            this.btnSaveRole.Size = new System.Drawing.Size(142, 41);
            this.btnSaveRole.TabIndex = 5;
            this.btnSaveRole.Text = "Save";
            this.btnSaveRole.UseVisualStyleBackColor = false;
            this.btnSaveRole.Click += new System.EventHandler(this.btnSaveRole_Click);
            // 
            // btnDeleteRole
            // 
            this.btnDeleteRole.BackColor = System.Drawing.Color.LightGray;
            this.btnDeleteRole.Location = new System.Drawing.Point(388, 133);
            this.btnDeleteRole.Name = "btnDeleteRole";
            this.btnDeleteRole.Size = new System.Drawing.Size(142, 41);
            this.btnDeleteRole.TabIndex = 5;
            this.btnDeleteRole.Text = "Delete";
            this.btnDeleteRole.UseVisualStyleBackColor = false;
            this.btnDeleteRole.Click += new System.EventHandler(this.btnDeleteRole_Click);
            // 
            // btnEditRole
            // 
            this.btnEditRole.BackColor = System.Drawing.Color.LightGray;
            this.btnEditRole.Location = new System.Drawing.Point(240, 133);
            this.btnEditRole.Name = "btnEditRole";
            this.btnEditRole.Size = new System.Drawing.Size(142, 41);
            this.btnEditRole.TabIndex = 4;
            this.btnEditRole.Text = "Edit";
            this.btnEditRole.UseVisualStyleBackColor = false;
            this.btnEditRole.Click += new System.EventHandler(this.btnEditRole_Click);
            // 
            // btnAddRole
            // 
            this.btnAddRole.BackColor = System.Drawing.Color.LightGray;
            this.btnAddRole.Location = new System.Drawing.Point(92, 133);
            this.btnAddRole.Name = "btnAddRole";
            this.btnAddRole.Size = new System.Drawing.Size(142, 41);
            this.btnAddRole.TabIndex = 2;
            this.btnAddRole.Text = "Add";
            this.btnAddRole.UseVisualStyleBackColor = false;
            this.btnAddRole.Click += new System.EventHandler(this.btnAddRole_Click);
            // 
            // roleIsActivePanel
            // 
            this.roleIsActivePanel.BackColor = System.Drawing.Color.White;
            this.roleIsActivePanel.Controls.Add(this.cbIsActiveRole);
            this.roleIsActivePanel.Controls.Add(this.label14);
            this.roleIsActivePanel.ForeColor = System.Drawing.Color.Black;
            this.roleIsActivePanel.Location = new System.Drawing.Point(92, 72);
            this.roleIsActivePanel.Name = "roleIsActivePanel";
            this.roleIsActivePanel.Size = new System.Drawing.Size(441, 55);
            this.roleIsActivePanel.TabIndex = 2;
            // 
            // cbIsActiveRole
            // 
            this.cbIsActiveRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIsActiveRole.FormattingEnabled = true;
            this.cbIsActiveRole.Location = new System.Drawing.Point(124, 13);
            this.cbIsActiveRole.Name = "cbIsActiveRole";
            this.cbIsActiveRole.Size = new System.Drawing.Size(299, 28);
            this.cbIsActiveRole.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(13, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 22);
            this.label14.TabIndex = 0;
            this.label14.Text = "Is Active:";
            // 
            // roleNamePanel
            // 
            this.roleNamePanel.BackColor = System.Drawing.Color.White;
            this.roleNamePanel.Controls.Add(this.txbRoleName);
            this.roleNamePanel.Controls.Add(this.label15);
            this.roleNamePanel.ForeColor = System.Drawing.Color.Black;
            this.roleNamePanel.Location = new System.Drawing.Point(92, 11);
            this.roleNamePanel.Name = "roleNamePanel";
            this.roleNamePanel.Size = new System.Drawing.Size(441, 55);
            this.roleNamePanel.TabIndex = 0;
            // 
            // txbRoleName
            // 
            this.txbRoleName.Location = new System.Drawing.Point(124, 13);
            this.txbRoleName.Name = "txbRoleName";
            this.txbRoleName.Size = new System.Drawing.Size(299, 28);
            this.txbRoleName.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(13, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 22);
            this.label15.TabIndex = 0;
            this.label15.Text = "Name:";
            // 
            // tpPermission
            // 
            this.tpPermission.Controls.Add(this.tablePermissionPanel);
            this.tpPermission.Controls.Add(this.permissionPaginatePanel);
            this.tpPermission.Controls.Add(this.panel4);
            this.tpPermission.Location = new System.Drawing.Point(4, 31);
            this.tpPermission.Name = "tpPermission";
            this.tpPermission.Size = new System.Drawing.Size(1094, 615);
            this.tpPermission.TabIndex = 4;
            this.tpPermission.Text = "Permission";
            this.tpPermission.UseVisualStyleBackColor = true;
            // 
            // tablePermissionPanel
            // 
            this.tablePermissionPanel.BackColor = System.Drawing.Color.White;
            this.tablePermissionPanel.Controls.Add(this.dtgvPermission);
            this.tablePermissionPanel.Location = new System.Drawing.Point(6, 197);
            this.tablePermissionPanel.Name = "tablePermissionPanel";
            this.tablePermissionPanel.Size = new System.Drawing.Size(1081, 336);
            this.tablePermissionPanel.TabIndex = 8;
            // 
            // dtgvPermission
            // 
            this.dtgvPermission.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvPermission.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvPermission.Location = new System.Drawing.Point(12, 12);
            this.dtgvPermission.Name = "dtgvPermission";
            this.dtgvPermission.RowHeadersWidth = 51;
            this.dtgvPermission.RowTemplate.Height = 24;
            this.dtgvPermission.Size = new System.Drawing.Size(1058, 312);
            this.dtgvPermission.TabIndex = 0;
            this.dtgvPermission.SelectionChanged += new System.EventHandler(this.dtgvPermission_SelectionChanged);
            // 
            // permissionPaginatePanel
            // 
            this.permissionPaginatePanel.BackColor = System.Drawing.Color.White;
            this.permissionPaginatePanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.permissionPaginatePanel.Location = new System.Drawing.Point(6, 539);
            this.permissionPaginatePanel.Name = "permissionPaginatePanel";
            this.permissionPaginatePanel.Size = new System.Drawing.Size(1081, 70);
            this.permissionPaginatePanel.TabIndex = 7;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.permissionModulePanel);
            this.panel4.Controls.Add(this.txbSearchPermission);
            this.panel4.Controls.Add(this.btnCancelPermission);
            this.panel4.Controls.Add(this.btnSavePermission);
            this.panel4.Controls.Add(this.btnDeletePermission);
            this.panel4.Controls.Add(this.btnEditPermission);
            this.panel4.Controls.Add(this.btnAddPermission);
            this.panel4.Controls.Add(this.permissionNamePanel);
            this.panel4.Location = new System.Drawing.Point(6, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1081, 185);
            this.panel4.TabIndex = 4;
            // 
            // permissionModulePanel
            // 
            this.permissionModulePanel.BackColor = System.Drawing.Color.White;
            this.permissionModulePanel.Controls.Add(this.cbPermissionModule);
            this.permissionModulePanel.Controls.Add(this.label13);
            this.permissionModulePanel.ForeColor = System.Drawing.Color.Black;
            this.permissionModulePanel.Location = new System.Drawing.Point(92, 72);
            this.permissionModulePanel.Name = "permissionModulePanel";
            this.permissionModulePanel.Size = new System.Drawing.Size(441, 55);
            this.permissionModulePanel.TabIndex = 3;
            // 
            // cbPermissionModule
            // 
            this.cbPermissionModule.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPermissionModule.FormattingEnabled = true;
            this.cbPermissionModule.Location = new System.Drawing.Point(124, 13);
            this.cbPermissionModule.Name = "cbPermissionModule";
            this.cbPermissionModule.Size = new System.Drawing.Size(299, 28);
            this.cbPermissionModule.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 22);
            this.label13.TabIndex = 0;
            this.label13.Text = "Module:";
            // 
            // txbSearchPermission
            // 
            this.txbSearchPermission.Location = new System.Drawing.Point(551, 139);
            this.txbSearchPermission.Name = "txbSearchPermission";
            this.txbSearchPermission.Size = new System.Drawing.Size(145, 28);
            this.txbSearchPermission.TabIndex = 6;
            this.txbSearchPermission.TextChanged += new System.EventHandler(this.txbSearchPermission_TextChanged);
            // 
            // btnCancelPermission
            // 
            this.btnCancelPermission.BackColor = System.Drawing.Color.LightGray;
            this.btnCancelPermission.Enabled = false;
            this.btnCancelPermission.Location = new System.Drawing.Point(850, 133);
            this.btnCancelPermission.Name = "btnCancelPermission";
            this.btnCancelPermission.Size = new System.Drawing.Size(142, 41);
            this.btnCancelPermission.TabIndex = 5;
            this.btnCancelPermission.Text = "Cancel";
            this.btnCancelPermission.UseVisualStyleBackColor = false;
            this.btnCancelPermission.Click += new System.EventHandler(this.btnCancelPermission_Click);
            // 
            // btnSavePermission
            // 
            this.btnSavePermission.BackColor = System.Drawing.Color.LightGray;
            this.btnSavePermission.Enabled = false;
            this.btnSavePermission.Location = new System.Drawing.Point(702, 133);
            this.btnSavePermission.Name = "btnSavePermission";
            this.btnSavePermission.Size = new System.Drawing.Size(142, 41);
            this.btnSavePermission.TabIndex = 5;
            this.btnSavePermission.Text = "Save";
            this.btnSavePermission.UseVisualStyleBackColor = false;
            this.btnSavePermission.Click += new System.EventHandler(this.btnSavePermission_Click);
            // 
            // btnDeletePermission
            // 
            this.btnDeletePermission.BackColor = System.Drawing.Color.LightGray;
            this.btnDeletePermission.Location = new System.Drawing.Point(388, 133);
            this.btnDeletePermission.Name = "btnDeletePermission";
            this.btnDeletePermission.Size = new System.Drawing.Size(142, 41);
            this.btnDeletePermission.TabIndex = 5;
            this.btnDeletePermission.Text = "Delete";
            this.btnDeletePermission.UseVisualStyleBackColor = false;
            this.btnDeletePermission.Click += new System.EventHandler(this.btnDeletePermission_Click);
            // 
            // btnEditPermission
            // 
            this.btnEditPermission.BackColor = System.Drawing.Color.LightGray;
            this.btnEditPermission.Location = new System.Drawing.Point(240, 133);
            this.btnEditPermission.Name = "btnEditPermission";
            this.btnEditPermission.Size = new System.Drawing.Size(142, 41);
            this.btnEditPermission.TabIndex = 4;
            this.btnEditPermission.Text = "Edit";
            this.btnEditPermission.UseVisualStyleBackColor = false;
            this.btnEditPermission.Click += new System.EventHandler(this.btnEditPermission_Click);
            // 
            // btnAddPermission
            // 
            this.btnAddPermission.BackColor = System.Drawing.Color.LightGray;
            this.btnAddPermission.Location = new System.Drawing.Point(92, 133);
            this.btnAddPermission.Name = "btnAddPermission";
            this.btnAddPermission.Size = new System.Drawing.Size(142, 41);
            this.btnAddPermission.TabIndex = 2;
            this.btnAddPermission.Text = "Add";
            this.btnAddPermission.UseVisualStyleBackColor = false;
            this.btnAddPermission.Click += new System.EventHandler(this.btnAddPermission_Click);
            // 
            // permissionNamePanel
            // 
            this.permissionNamePanel.BackColor = System.Drawing.Color.White;
            this.permissionNamePanel.Controls.Add(this.txbPermissionName);
            this.permissionNamePanel.Controls.Add(this.label18);
            this.permissionNamePanel.ForeColor = System.Drawing.Color.Black;
            this.permissionNamePanel.Location = new System.Drawing.Point(92, 11);
            this.permissionNamePanel.Name = "permissionNamePanel";
            this.permissionNamePanel.Size = new System.Drawing.Size(441, 55);
            this.permissionNamePanel.TabIndex = 0;
            // 
            // txbPermissionName
            // 
            this.txbPermissionName.Location = new System.Drawing.Point(124, 13);
            this.txbPermissionName.Name = "txbPermissionName";
            this.txbPermissionName.Size = new System.Drawing.Size(299, 28);
            this.txbPermissionName.TabIndex = 1;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(13, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(62, 22);
            this.label18.TabIndex = 0;
            this.label18.Text = "Name:";
            // 
            // tpCategory
            // 
            this.tpCategory.Controls.Add(this.tableCategory);
            this.tpCategory.Controls.Add(this.categoryPaginatePanel);
            this.tpCategory.Controls.Add(this.panel5);
            this.tpCategory.Location = new System.Drawing.Point(4, 31);
            this.tpCategory.Name = "tpCategory";
            this.tpCategory.Size = new System.Drawing.Size(1094, 615);
            this.tpCategory.TabIndex = 5;
            this.tpCategory.Text = "Category";
            this.tpCategory.UseVisualStyleBackColor = true;
            // 
            // tableCategory
            // 
            this.tableCategory.BackColor = System.Drawing.Color.White;
            this.tableCategory.Controls.Add(this.dtgvCategory);
            this.tableCategory.Location = new System.Drawing.Point(6, 197);
            this.tableCategory.Name = "tableCategory";
            this.tableCategory.Size = new System.Drawing.Size(1081, 336);
            this.tableCategory.TabIndex = 9;
            // 
            // dtgvCategory
            // 
            this.dtgvCategory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvCategory.Location = new System.Drawing.Point(12, 12);
            this.dtgvCategory.Name = "dtgvCategory";
            this.dtgvCategory.RowHeadersWidth = 51;
            this.dtgvCategory.RowTemplate.Height = 24;
            this.dtgvCategory.Size = new System.Drawing.Size(1058, 312);
            this.dtgvCategory.TabIndex = 0;
            this.dtgvCategory.SelectionChanged += new System.EventHandler(this.dtgvCategory_SelectionChanged);
            // 
            // categoryPaginatePanel
            // 
            this.categoryPaginatePanel.BackColor = System.Drawing.Color.White;
            this.categoryPaginatePanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryPaginatePanel.Location = new System.Drawing.Point(6, 539);
            this.categoryPaginatePanel.Name = "categoryPaginatePanel";
            this.categoryPaginatePanel.Size = new System.Drawing.Size(1081, 70);
            this.categoryPaginatePanel.TabIndex = 8;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.categoryIsActivePanel);
            this.panel5.Controls.Add(this.txbSearchCategory);
            this.panel5.Controls.Add(this.btnCancelCategory);
            this.panel5.Controls.Add(this.btnSaveCategory);
            this.panel5.Controls.Add(this.btnDeleteCategory);
            this.panel5.Controls.Add(this.btnEditCategory);
            this.panel5.Controls.Add(this.btnAddCategory);
            this.panel5.Controls.Add(this.categoryNamePanel);
            this.panel5.Location = new System.Drawing.Point(6, 6);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1081, 185);
            this.panel5.TabIndex = 5;
            // 
            // categoryIsActivePanel
            // 
            this.categoryIsActivePanel.BackColor = System.Drawing.Color.White;
            this.categoryIsActivePanel.Controls.Add(this.cbCategoryIsActive);
            this.categoryIsActivePanel.Controls.Add(this.label16);
            this.categoryIsActivePanel.ForeColor = System.Drawing.Color.Black;
            this.categoryIsActivePanel.Location = new System.Drawing.Point(92, 72);
            this.categoryIsActivePanel.Name = "categoryIsActivePanel";
            this.categoryIsActivePanel.Size = new System.Drawing.Size(441, 55);
            this.categoryIsActivePanel.TabIndex = 7;
            // 
            // cbCategoryIsActive
            // 
            this.cbCategoryIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategoryIsActive.FormattingEnabled = true;
            this.cbCategoryIsActive.Location = new System.Drawing.Point(124, 13);
            this.cbCategoryIsActive.Name = "cbCategoryIsActive";
            this.cbCategoryIsActive.Size = new System.Drawing.Size(299, 28);
            this.cbCategoryIsActive.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(13, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(82, 22);
            this.label16.TabIndex = 0;
            this.label16.Text = "Is Active:";
            // 
            // txbSearchCategory
            // 
            this.txbSearchCategory.Location = new System.Drawing.Point(551, 139);
            this.txbSearchCategory.Name = "txbSearchCategory";
            this.txbSearchCategory.Size = new System.Drawing.Size(145, 28);
            this.txbSearchCategory.TabIndex = 6;
            this.txbSearchCategory.TextChanged += new System.EventHandler(this.txbSearchCategory_TextChanged);
            // 
            // btnCancelCategory
            // 
            this.btnCancelCategory.BackColor = System.Drawing.Color.LightGray;
            this.btnCancelCategory.Enabled = false;
            this.btnCancelCategory.Location = new System.Drawing.Point(850, 133);
            this.btnCancelCategory.Name = "btnCancelCategory";
            this.btnCancelCategory.Size = new System.Drawing.Size(142, 41);
            this.btnCancelCategory.TabIndex = 5;
            this.btnCancelCategory.Text = "Cancel";
            this.btnCancelCategory.UseVisualStyleBackColor = false;
            this.btnCancelCategory.Click += new System.EventHandler(this.btnCancelCategory_Click);
            // 
            // btnSaveCategory
            // 
            this.btnSaveCategory.BackColor = System.Drawing.Color.LightGray;
            this.btnSaveCategory.Enabled = false;
            this.btnSaveCategory.Location = new System.Drawing.Point(702, 133);
            this.btnSaveCategory.Name = "btnSaveCategory";
            this.btnSaveCategory.Size = new System.Drawing.Size(142, 41);
            this.btnSaveCategory.TabIndex = 5;
            this.btnSaveCategory.Text = "Save";
            this.btnSaveCategory.UseVisualStyleBackColor = false;
            this.btnSaveCategory.Click += new System.EventHandler(this.btnSaveCategory_Click);
            // 
            // btnDeleteCategory
            // 
            this.btnDeleteCategory.BackColor = System.Drawing.Color.LightGray;
            this.btnDeleteCategory.Location = new System.Drawing.Point(388, 133);
            this.btnDeleteCategory.Name = "btnDeleteCategory";
            this.btnDeleteCategory.Size = new System.Drawing.Size(142, 41);
            this.btnDeleteCategory.TabIndex = 5;
            this.btnDeleteCategory.Text = "Delete";
            this.btnDeleteCategory.UseVisualStyleBackColor = false;
            this.btnDeleteCategory.Click += new System.EventHandler(this.btnDeleteCategory_Click);
            // 
            // btnEditCategory
            // 
            this.btnEditCategory.BackColor = System.Drawing.Color.LightGray;
            this.btnEditCategory.Location = new System.Drawing.Point(240, 133);
            this.btnEditCategory.Name = "btnEditCategory";
            this.btnEditCategory.Size = new System.Drawing.Size(142, 41);
            this.btnEditCategory.TabIndex = 4;
            this.btnEditCategory.Text = "Edit";
            this.btnEditCategory.UseVisualStyleBackColor = false;
            this.btnEditCategory.Click += new System.EventHandler(this.btnEditCategory_Click);
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.BackColor = System.Drawing.Color.LightGray;
            this.btnAddCategory.Location = new System.Drawing.Point(92, 133);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(142, 41);
            this.btnAddCategory.TabIndex = 2;
            this.btnAddCategory.Text = "Add";
            this.btnAddCategory.UseVisualStyleBackColor = false;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // categoryNamePanel
            // 
            this.categoryNamePanel.BackColor = System.Drawing.Color.White;
            this.categoryNamePanel.Controls.Add(this.txbCategoryName);
            this.categoryNamePanel.Controls.Add(this.label17);
            this.categoryNamePanel.ForeColor = System.Drawing.Color.Black;
            this.categoryNamePanel.Location = new System.Drawing.Point(92, 11);
            this.categoryNamePanel.Name = "categoryNamePanel";
            this.categoryNamePanel.Size = new System.Drawing.Size(441, 55);
            this.categoryNamePanel.TabIndex = 0;
            // 
            // txbCategoryName
            // 
            this.txbCategoryName.Location = new System.Drawing.Point(124, 13);
            this.txbCategoryName.Name = "txbCategoryName";
            this.txbCategoryName.Size = new System.Drawing.Size(299, 28);
            this.txbCategoryName.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(13, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 22);
            this.label17.TabIndex = 0;
            this.label17.Text = "Name:";
            // 
            // nmTime
            // 
            this.nmTime.Location = new System.Drawing.Point(73, 12);
            this.nmTime.Maximum = new decimal(new int[] {
            1569325056,
            23283064,
            0,
            0});
            this.nmTime.Name = "nmTime";
            this.nmTime.Size = new System.Drawing.Size(86, 28);
            this.nmTime.TabIndex = 8;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.Time);
            this.panel6.Controls.Add(this.nmTime);
            this.panel6.Location = new System.Drawing.Point(463, 90);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(177, 54);
            this.panel6.TabIndex = 9;
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.Time.Location = new System.Drawing.Point(12, 15);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(55, 22);
            this.Time.TabIndex = 3;
            this.Time.Text = "Time:";
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
            this.tpQuestionAnswer.ResumeLayout(false);
            this.tpQuestionAnswer.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.listQuizPanel.ResumeLayout(false);
            this.listQuizPanel.PerformLayout();
            this.tpQuiz.ResumeLayout(false);
            this.quizTablePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvQuiz)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.quizCategoryPanel.ResumeLayout(false);
            this.quizCategoryPanel.PerformLayout();
            this.quizImagePanel.ResumeLayout(false);
            this.quizImagePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbQuizImage)).EndInit();
            this.quizDifficultyPanel.ResumeLayout(false);
            this.quizDifficultyPanel.PerformLayout();
            this.quizNamePanel.ResumeLayout(false);
            this.quizNamePanel.PerformLayout();
            this.tpUser.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.userRolePanel.ResumeLayout(false);
            this.userRolePanel.PerformLayout();
            this.userImagePanel.ResumeLayout(false);
            this.userImagePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserImage)).EndInit();
            this.userNamePanel.ResumeLayout(false);
            this.userNamePanel.PerformLayout();
            this.userPasswordPanel.ResumeLayout(false);
            this.userPasswordPanel.PerformLayout();
            this.userEmailPanel.ResumeLayout(false);
            this.userEmailPanel.PerformLayout();
            this.userTablePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvUser)).EndInit();
            this.tcAdmin.ResumeLayout(false);
            this.tpRole.ResumeLayout(false);
            this.moduleListPanel.ResumeLayout(false);
            this.moduleListPanel.PerformLayout();
            this.roleTablePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvRole)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.roleIsActivePanel.ResumeLayout(false);
            this.roleIsActivePanel.PerformLayout();
            this.roleNamePanel.ResumeLayout(false);
            this.roleNamePanel.PerformLayout();
            this.tpPermission.ResumeLayout(false);
            this.tablePermissionPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvPermission)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.permissionModulePanel.ResumeLayout(false);
            this.permissionModulePanel.PerformLayout();
            this.permissionNamePanel.ResumeLayout(false);
            this.permissionNamePanel.PerformLayout();
            this.tpCategory.ResumeLayout(false);
            this.tableCategory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCategory)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.categoryIsActivePanel.ResumeLayout(false);
            this.categoryIsActivePanel.PerformLayout();
            this.categoryNamePanel.ResumeLayout(false);
            this.categoryNamePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmTime)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog userFileDialog;
        private System.Windows.Forms.OpenFileDialog quizFileDialog;
        private System.Windows.Forms.TabPage tpQuestionAnswer;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnUpsertQuizQA;
        private System.Windows.Forms.Panel listQuizPanel;
        private System.Windows.Forms.ComboBox cbQuizName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabPage tpQuiz;
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
        private System.Windows.Forms.TabPage tpUser;
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
        private System.Windows.Forms.Panel quizCategoryPanel;
        private System.Windows.Forms.ComboBox cbQuizCategory;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel userRolePanel;
        private System.Windows.Forms.ComboBox cbUserRole;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tpRole;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txbSearchRole;
        private System.Windows.Forms.Button btnCancelRole;
        private System.Windows.Forms.Button btnSaveRole;
        private System.Windows.Forms.Button btnDeleteRole;
        private System.Windows.Forms.Button btnEditRole;
        private System.Windows.Forms.Button btnAddRole;
        private System.Windows.Forms.Panel roleIsActivePanel;
        private System.Windows.Forms.ComboBox cbIsActiveRole;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel roleNamePanel;
        private System.Windows.Forms.TextBox txbRoleName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TabPage tpPermission;
        private System.Windows.Forms.Panel rolePaginatePanel;
        private System.Windows.Forms.Panel flpRole;
        private System.Windows.Forms.Panel roleTablePanel;
        private System.Windows.Forms.DataGridView dtgvRole;
        private System.Windows.Forms.Panel moduleListPanel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel permissionModulePanel;
        private System.Windows.Forms.ComboBox cbPermissionModule;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txbSearchPermission;
        private System.Windows.Forms.Button btnCancelPermission;
        private System.Windows.Forms.Button btnSavePermission;
        private System.Windows.Forms.Button btnDeletePermission;
        private System.Windows.Forms.Button btnEditPermission;
        private System.Windows.Forms.Button btnAddPermission;
        private System.Windows.Forms.Panel permissionNamePanel;
        private System.Windows.Forms.TextBox txbPermissionName;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel permissionPaginatePanel;
        private System.Windows.Forms.Panel tablePermissionPanel;
        private System.Windows.Forms.DataGridView dtgvPermission;
        private System.Windows.Forms.TabPage tpCategory;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txbSearchCategory;
        private System.Windows.Forms.Button btnCancelCategory;
        private System.Windows.Forms.Button btnSaveCategory;
        private System.Windows.Forms.Button btnDeleteCategory;
        private System.Windows.Forms.Button btnEditCategory;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Panel categoryNamePanel;
        private System.Windows.Forms.TextBox txbCategoryName;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel categoryPaginatePanel;
        private System.Windows.Forms.Panel tableCategory;
        private System.Windows.Forms.DataGridView dtgvCategory;
        private System.Windows.Forms.Panel categoryIsActivePanel;
        private System.Windows.Forms.ComboBox cbCategoryIsActive;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.RichTextBox quizRichText;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.NumericUpDown nmTime;
        private System.Windows.Forms.Label Time;
    }
}