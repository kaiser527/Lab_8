using System.Drawing;
using System.Windows.Forms;

namespace Lab_8.Forms
{
    partial class Register
    {
        private System.ComponentModel.IContainer components = null;

        private Label labelTitle;
        private Label labelName;
        private Label labelEmail;
        private Label labelPassword;
        private Label labelConfirmPassword;
        private TextBox txbName;
        private TextBox txbEmail;
        private TextBox txbPassword;
        private TextBox txbConfirmPassword;
        private Button btnRegister;
        private Button btnExit;
        private Label lblLogin;
        private Panel panelMain;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelConfirmPassword = new System.Windows.Forms.Label();
            this.txbName = new System.Windows.Forms.TextBox();
            this.txbEmail = new System.Windows.Forms.TextBox();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.txbConfirmPassword = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblLogin = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.labelTitle.Location = new System.Drawing.Point(140, 10);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(232, 41);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Create Account";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelName.Location = new System.Drawing.Point(40, 70);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(106, 25);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Full Name:";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelEmail.Location = new System.Drawing.Point(40, 120);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(64, 25);
            this.labelEmail.TabIndex = 3;
            this.labelEmail.Text = "Email:";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelPassword.Location = new System.Drawing.Point(40, 170);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(102, 25);
            this.labelPassword.TabIndex = 5;
            this.labelPassword.Text = "Password:";
            // 
            // labelConfirmPassword
            // 
            this.labelConfirmPassword.AutoSize = true;
            this.labelConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelConfirmPassword.Location = new System.Drawing.Point(40, 220);
            this.labelConfirmPassword.Name = "labelConfirmPassword";
            this.labelConfirmPassword.Size = new System.Drawing.Size(90, 25);
            this.labelConfirmPassword.TabIndex = 7;
            this.labelConfirmPassword.Text = "Confirm:";
            // 
            // txbName
            // 
            this.txbName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txbName.Location = new System.Drawing.Point(130, 65);
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(293, 32);
            this.txbName.TabIndex = 2;
            // 
            // txbEmail
            // 
            this.txbEmail.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txbEmail.Location = new System.Drawing.Point(130, 115);
            this.txbEmail.Name = "txbEmail";
            this.txbEmail.Size = new System.Drawing.Size(293, 32);
            this.txbEmail.TabIndex = 4;
            // 
            // txbPassword
            // 
            this.txbPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txbPassword.Location = new System.Drawing.Point(130, 165);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.Size = new System.Drawing.Size(293, 32);
            this.txbPassword.TabIndex = 6;
            this.txbPassword.UseSystemPasswordChar = true;
            this.txbPassword.TextChanged += new System.EventHandler(this.txbPassword_TextChanged);
            // 
            // txbConfirmPassword
            // 
            this.txbConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txbConfirmPassword.Location = new System.Drawing.Point(130, 215);
            this.txbConfirmPassword.Name = "txbConfirmPassword";
            this.txbConfirmPassword.Size = new System.Drawing.Size(293, 32);
            this.txbConfirmPassword.TabIndex = 8;
            this.txbConfirmPassword.UseSystemPasswordChar = true;
            this.txbConfirmPassword.TextChanged += new System.EventHandler(this.txbConfirmPassword_TextChanged);
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(131, 270);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(100, 35);
            this.btnRegister.TabIndex = 9;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Gray;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(322, 270);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 35);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLogin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.lblLogin.Location = new System.Drawing.Point(383, 313);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(52, 23);
            this.lblLogin.TabIndex = 11;
            this.lblLogin.Text = "Login";
            this.lblLogin.Click += new System.EventHandler(this.lblLogin_Click);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelMain.Controls.Add(this.labelTitle);
            this.panelMain.Controls.Add(this.labelName);
            this.panelMain.Controls.Add(this.txbName);
            this.panelMain.Controls.Add(this.labelEmail);
            this.panelMain.Controls.Add(this.txbEmail);
            this.panelMain.Controls.Add(this.labelPassword);
            this.panelMain.Controls.Add(this.txbPassword);
            this.panelMain.Controls.Add(this.labelConfirmPassword);
            this.panelMain.Controls.Add(this.txbConfirmPassword);
            this.panelMain.Controls.Add(this.btnRegister);
            this.panelMain.Controls.Add(this.btnExit);
            this.panelMain.Controls.Add(this.lblLogin);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(469, 347);
            this.panelMain.TabIndex = 0;
            // 
            // Register
            // 
            this.AcceptButton = this.btnRegister;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(469, 347);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Registration";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
    }
}
