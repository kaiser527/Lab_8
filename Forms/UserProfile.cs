using Lab_8.DTO;
using Lab_8.Services;
using Lab_8.Utils;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WinFormApp.Forms;

namespace Lab_8.Forms
{
    public partial class UserProfile : Form
    {
        private readonly Home _home;

        private byte[] userImageBytes;

        public UserProfile(Home home)
        {
            InitializeComponent();
            _home = home;

            StyleButtons();
            StylePanels();
            LoadData();
        }

        #region Medthods
        private void StylePanels()
        {
            int radius = 15;

            foreach (Panel pnl in new[] { panel1, panel2, panel4, panel5, panel6, panel7, panel8, panel9 })
            {
                UIStyle.RoundPanel(pnl, radius);
            }
        }

        private void StyleButtons()
        {
            UIStyle.ModernUIButton(btnUpdate, Color.FromArgb(52, 152, 219), Color.FromArgb(35, 110, 160));
            UIStyle.ModernUIButton(btnExit, Color.FromArgb(231, 76, 60), Color.FromArgb(176, 52, 40));
        }

        private void LoadData()
        {
            var user = UserService.Instance.User;

            if (user == null)
                return;

            txbUserName.Text = user.Name;
            txbUserEmail.Text = user.Email;

            // Load profile image if exists
            if (user.Image != null && user.Image.Length > 0)
            {
                userImageBytes = user.Image;

                using (var ms = new MemoryStream(user.Image))
                {
                    btnUploadUserProfile.BackgroundImage = Image.FromStream(ms);
                    btnUploadUserProfile.BackgroundImageLayout = ImageLayout.Stretch;
                    btnUploadUserProfile.Text = ""; // Remove '+' sign
                }
            }
        }

        private bool ValidateForm()
        {
            bool isValid = true;
            string errorMessage = "";

            // Email validation
            if (string.IsNullOrWhiteSpace(txbUserEmail.Text))
            {
                errorMessage += "- Email is required.\n";
                isValid = false;
            }
            else if (!txbUserEmail.Text.Contains("@") || !txbUserEmail.Text.Contains("."))
            {
                errorMessage += "- Invalid email format.\n";
                isValid = false;
            }

            // Username validation
            if (string.IsNullOrWhiteSpace(txbUserName.Text))
            {
                errorMessage += "- Username is required.\n";
                isValid = false;
            }

            // Current password validation
            if (string.IsNullOrWhiteSpace(txbUserPassword.Text))
            {
                errorMessage += "- Current password is required.\n";
                isValid = false;
            }

            // New password + confirm password (optional)
            bool isNewPasswordEntered = !string.IsNullOrWhiteSpace(txbNewPassword.Text);
            bool isConfirmPasswordEntered = !string.IsNullOrWhiteSpace(txbConfirmPassword.Text);

            if (isNewPasswordEntered || isConfirmPasswordEntered)
            {
                if (txbNewPassword.Text.Length < 6)
                {
                    errorMessage += "- New password must be at least 6 characters long.\n";
                    isValid = false;
                }

                if (txbNewPassword.Text != txbConfirmPassword.Text)
                {
                    errorMessage += "- Confirm password does not match new password.\n";
                    isValid = false;
                }
            }

            // Show all errors at once
            if (!isValid)
                Alert.ShowAlert(errorMessage, Alert.AlertType.Error);

            return isValid;
        }
        #endregion

        #region Events
        private void btnUploadUserProfile_Click(object sender, EventArgs e)
        {
            try
            {
                userImageBytes = Helper.UploadImage(userProfileFileDialog);

                if (userImageBytes != null)
                {
                    var user = UserService.Instance.User;
                    user.Image = userImageBytes;

                    using (var ms = new MemoryStream(userImageBytes))
                    {
                        btnUploadUserProfile.BackgroundImage = Image.FromStream(ms);
                        btnUploadUserProfile.BackgroundImageLayout = ImageLayout.Stretch;
                        btnUploadUserProfile.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                Alert.ShowAlert("Failed to load image: " + ex.Message, Alert.AlertType.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            var updateUser = new UpdateUserProfile
            {
                Email = txbUserEmail.Text,
                Name = txbUserName.Text,
                Password = txbUserPassword.Text,
                NewPassword = txbNewPassword.Text,
                ConfirmPassword = txbConfirmPassword.Text,
                Image = userImageBytes,
            };

            (bool isSuccess, var user) = await UserService.Instance.UpdateUserProfile(updateUser);

            if (isSuccess)
            {
                UserService.Instance.User = user;
                _home.toolStripBtnDropdown.Text = user.Name;

                Close();
            }
            else
            {
                Alert.ShowAlert("Failed to update profile. Please check your current password or try again later.", Alert.AlertType.Error);
                return;
            }
        }
        #endregion
    }
}
