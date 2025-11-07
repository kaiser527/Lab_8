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
            this.tcAdmin = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txbSearchUser = new System.Windows.Forms.TextBox();
            this.btnCancelUser = new System.Windows.Forms.Button();
            this.btnSaveUser = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.userImagePanel = new System.Windows.Forms.Panel();
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.userFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.userPaginatePanel = new System.Windows.Forms.Panel();
            this.pbUserImage = new System.Windows.Forms.PictureBox();
            this.tcAdmin.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.userImagePanel.SuspendLayout();
            this.userNamePanel.SuspendLayout();
            this.userPasswordPanel.SuspendLayout();
            this.userEmailPanel.SuspendLayout();
            this.userTablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserImage)).BeginInit();
            this.SuspendLayout();
            // 
            // tcAdmin
            // 
            this.tcAdmin.Controls.Add(this.tabPage1);
            this.tcAdmin.Controls.Add(this.tabPage2);
            this.tcAdmin.Controls.Add(this.tabPage3);
            this.tcAdmin.Controls.Add(this.tabPage4);
            this.tcAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcAdmin.Location = new System.Drawing.Point(13, 13);
            this.tcAdmin.Name = "tcAdmin";
            this.tcAdmin.SelectedIndex = 0;
            this.tcAdmin.Size = new System.Drawing.Size(1102, 650);
            this.tcAdmin.TabIndex = 0;
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
            this.panel3.Location = new System.Drawing.Point(7, 7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1081, 184);
            this.panel3.TabIndex = 2;
            // 
            // txbSearchUser
            // 
            this.txbSearchUser.Location = new System.Drawing.Point(551, 139);
            this.txbSearchUser.Name = "txbSearchUser";
            this.txbSearchUser.Size = new System.Drawing.Size(145, 28);
            this.txbSearchUser.TabIndex = 6;
            this.txbSearchUser.TextChanged += new System.EventHandler(this.txbSearchUser_TextChanged);
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
            this.label4.Size = new System.Drawing.Size(58, 22);
            this.label4.TabIndex = 0;
            this.label4.Text = "Image";
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
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1094, 615);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Quiz";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 31);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1094, 615);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Question-Answer";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 31);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1094, 615);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "History";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // userFileDialog
            // 
            this.userFileDialog.FileName = "openFileDialog1";
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
            // pbUserImage
            // 
            this.pbUserImage.Location = new System.Drawing.Point(272, 7);
            this.pbUserImage.Name = "pbUserImage";
            this.pbUserImage.Size = new System.Drawing.Size(41, 41);
            this.pbUserImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbUserImage.TabIndex = 2;
            this.pbUserImage.TabStop = false;
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
            this.tcAdmin.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.userImagePanel.ResumeLayout(false);
            this.userImagePanel.PerformLayout();
            this.userNamePanel.ResumeLayout(false);
            this.userNamePanel.PerformLayout();
            this.userPasswordPanel.ResumeLayout(false);
            this.userPasswordPanel.PerformLayout();
            this.userEmailPanel.ResumeLayout(false);
            this.userEmailPanel.PerformLayout();
            this.userTablePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcAdmin;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel userTablePanel;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel userEmailPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbUserEmail;
        private System.Windows.Forms.Panel userPasswordPanel;
        private System.Windows.Forms.TextBox txbUserPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel userNamePanel;
        private System.Windows.Forms.TextBox txbUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel userImagePanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnUploadUserImage;
        private System.Windows.Forms.DataGridView dtgvUser;
        private System.Windows.Forms.Button btnCancelUser;
        private System.Windows.Forms.Button btnSaveUser;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.TextBox txbSearchUser;
        private System.Windows.Forms.OpenFileDialog userFileDialog;
        private System.Windows.Forms.Panel userPaginatePanel;
        private System.Windows.Forms.PictureBox pbUserImage;
    }
}