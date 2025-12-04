using Lab_8.Models;
using Lab_8.Services;
using Lab_8.Utils;
using System;
using System.IO;
using System.Windows.Forms;
using WinFormApp.Forms;

namespace Lab_8.Forms
{
    public partial class Register : Form
    {
        private readonly bool _isPlaceholderEmailApplied = false;
        private readonly bool _isPlaceholderUsernameApplied = false;
        private readonly bool _isPlaceholderPasswordApplied = false;
        private readonly bool _isPlaceholderConfirmApplied = false;

        public Register()
        {
            InitializeComponent();

            UIStyle.ApplyPlaceholder(txbName, "Enter Username...", ref _isPlaceholderUsernameApplied);
            UIStyle.ApplyPlaceholder(txbEmail, "Enter Email...", ref _isPlaceholderEmailApplied);

            txbPassword.UseSystemPasswordChar = false;
            UIStyle.ApplyPlaceholder(txbPassword, "Enter Password...", ref _isPlaceholderPasswordApplied);

            txbConfirmPassword.UseSystemPasswordChar = false;
            UIStyle.ApplyPlaceholder(txbConfirmPassword, "Enter confirm Password...", ref _isPlaceholderConfirmApplied);
        }

        #region Methods
        #endregion

        #region Events
        private void lblLogin_Click(object sender, EventArgs e)
        {
            Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void txbPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbPassword.Text) || txbPassword.Text == "Enter Password...")
            {
                txbPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txbPassword.UseSystemPasswordChar = true;
            }
        }

        private void txbConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbConfirmPassword.Text) || txbConfirmPassword.Text == "Enter confirm Password...")
            {
                txbConfirmPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txbConfirmPassword.UseSystemPasswordChar = true;
            }
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbEmail.Text) || txbEmail.Text == "Enter Email..."
                || string.IsNullOrEmpty(txbName.Text) || txbName.Text == "Enter Username..."
                || string.IsNullOrEmpty(txbPassword.Text) || txbPassword.Text == "Enter Password..."
                || string.IsNullOrEmpty(txbConfirmPassword.Text) || txbConfirmPassword.Text == "Enter confirm Password...")
            {
                Alert.ShowAlert("Missing information", Alert.AlertType.Warning);
                return;
            }

            if(txbConfirmPassword.Text != txbPassword.Text)
            {
                Alert.ShowAlert("Password and Confirm password not match", Alert.AlertType.Error);
                return;
            }

            string basePath = Path.Combine(Application.StartupPath, "Image");
            string userImg = Path.Combine(basePath, "User");

            User user = new User 
            {
                Name = txbName.Text,
                Email = txbEmail.Text,
                Password = BCrypt.Net.BCrypt.HashPassword(txbConfirmPassword.Text),
                Image = File.ReadAllBytes(Path.Combine(userImg, "user.png")),
                RoleId = 2
            };

            await UserService.Instance.CreateUser(user);

            Hide();
            Login login = new Login();
            login.ShowDialog(); 
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Hide();
            Login login = new Login();
            login.ShowDialog();
        }
        #endregion
    }
}
