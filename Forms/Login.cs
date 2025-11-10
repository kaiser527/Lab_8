using Lab_8.Forms;
using Lab_8.Services;
using Lab_8.Utils;
using System;
using System.Windows.Forms;

namespace Lab_8
{
    public partial class Login : Form
    {
        private readonly bool _isPlaceholderEmailApplied = false;

        private readonly bool _isPlaceholderPasswordApplied = false;

        private bool isLoading;
        private bool IsLoading
        {
            get => isLoading;
            set
            {
                isLoading = value;
                btnLogin.Enabled = !value;
                btnLogin.Text = value ? "Loading..." : "Login";
                Cursor = value ? Cursors.WaitCursor : Cursors.Default;
            }
        }

        public Login()
        {
            InitializeComponent();

            UIStyle.ApplyPlaceholder(txbUserEmail, "User Email...", ref _isPlaceholderEmailApplied);

            txbUserPassword.UseSystemPasswordChar = false;
            UIStyle.ApplyPlaceholder(txbUserPassword, "User Password...", ref _isPlaceholderPasswordApplied);
        }

        #region Methods
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (IsLoading) return; // Prevent clicking twice quickly

            string username = txbUserEmail.Text.Trim();
            string password = txbUserPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) ||
                txbUserEmail.Text == "User Email..." || txbUserPassword.Text == "User Password...")
            {
                MessageBox.Show("Missing information", "Alert");
                return;
            }

            IsLoading = true;

            try
            {
                var (user, success) = await UserService.Instance.Login(username, password);

                if (user != null && success)
                {
                    Home home = new Home();
                    Hide();
                    home.ShowDialog();
                    Show();
                }
                else
                {
                    MessageBox.Show("Incorrect email or password", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error");
            }
            finally
            {
                IsLoading = false;
                btnLogin.Text = "Login";
            }
        }
        #endregion

        #region Events
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit the program?",
                "Exit Confirmation",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Cancel)
            {
                e.Cancel = true; // Prevent closing
            }
        }
        #endregion

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbUserPassword.Text) || txbUserPassword.Text == "User Password...")
            {
                txbUserPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txbUserPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
