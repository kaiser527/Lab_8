using System;
using System.Windows.Forms;
using Lab_8.Services;

namespace Lab_8
{
    public partial class Login : Form
    {
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
        }

        #region Methods
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (IsLoading) return; // Prevent clicking twice quickly

            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
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
                    UserQuiz userQuiz = new UserQuiz();
                    Hide();
                    userQuiz.ShowDialog();
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
    }
}
