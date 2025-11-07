using Lab_8.Models;
using Lab_8.Services;
using Lab_8.Utils;
using System;
using System.IdentityModel.Metadata;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_8.Forms
{
    public partial class Admin : Form
    {
        //Data binding
        private BindingSource userlist = new BindingSource();

        //Placeholder
        private readonly bool _isPlaceholderUserApplied = false;

        //Paginate
        private readonly int _pageSize = 10;
        //User
        private int _currentPageUser = 1;
        private int _totalPagesUser = 1;

        //User property
        private string userAction = null;
        private byte[] selectedUserImageBytes = null;
        private int selectedUserId = 0;

        public Admin()
        {
            InitializeComponent();
            StylePanels();

            UIStyle.ApplyPlaceholder(txbSearchUser, "Search user", ref _isPlaceholderUserApplied);
        }

        #region Methods
        private void StylePanels()
        {
            foreach (var panel in (new Panel[]
            { 
                //User
                userPaginatePanel, userEmailPanel, userPasswordPanel,
                userTablePanel, userImagePanel, userNamePanel,
            }).Cast<Panel>())
            {
                UIStyle.RoundPanel(panel, 15);
            }
        }
        private void LoadImage(PictureBox pictureBox, object entityObj)
        {
            var imageProp = entityObj.GetType().GetProperty("Image");
            if (imageProp?.GetValue(entityObj) is byte[] imageBytes && imageBytes.Length > 0)
            {
                using (var ms = new System.IO.MemoryStream(imageBytes))
                {
                    pictureBox.Image = System.Drawing.Image.FromStream(ms);
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            else
            {
                pictureBox.Image = null;
            }
        }
        private void DisplaySelectedUserImage(DataGridView dataGridView, PictureBox pictureBox)
        {
            if (dataGridView.CurrentRow?.DataBoundItem is object entityObj)
            {
                var idProp = entityObj.GetType().GetProperty("Id");
                if (idProp != null)
                    selectedUserId = (int)idProp.GetValue(entityObj);

                LoadImage(pictureBox, entityObj);
            }
            else
            {
                pictureBox.Image = null;
            }
        }

        private void BindImageData(DataGridView dataGridView, PictureBox pictureBox)
        {
            dataGridView.SelectionChanged += (s, e) =>
            {
                DisplaySelectedUserImage(dataGridView, pictureBox);
            };
        }

        private void ClearTextbox(TextBox[] txbs)
        {
            foreach(var txb in txbs)
            {
                txb.DataBindings.Clear();
                txb.Clear();
            }
        }
        private void ButtonAction(Button[] btns, bool isDisable)
        {
            foreach (var btn in btns)
            {
                btn.Enabled = isDisable;
            }
        }
        private void BindUserData()
        {
            if (userlist == null || userlist.Count == 0)
            {
                ClearTextbox(new TextBox[] { txbUserEmail, txbUserName, txbUserPassword });
                return;
            }

            ClearTextbox(new TextBox[] { txbUserEmail, txbUserName, txbUserPassword });

            txbUserEmail.DataBindings.Add("Text", userlist, "Email", true, DataSourceUpdateMode.Never);
            txbUserName.DataBindings.Add("Text", userlist, "Name", true, DataSourceUpdateMode.Never);
            txbUserPassword.DataBindings.Add("Text", userlist, "Password", true, DataSourceUpdateMode.Never);

            BindImageData(dtgvUser, pbUserImage);
        }
        private async Task LoadUserList()
        {
            var result = await UserService.Instance.GetListUser(
                _pageSize, 
                _currentPageUser, 
                txbSearchUser.Text == "Search user" ? null : txbSearchUser.Text);

            if (result == null || !result.Items.Any())
            {
                dtgvUser.DataSource = null;
                return;
            }

            userlist.DataSource = result.Items.Select(u => new
            {
                u.Id,
                u.Email,
                u.Name,
                u.Password,
                u.Image
            }).ToList();

            dtgvUser.DataSource = userlist;

            if (dtgvUser.Columns.Contains("Image"))
            {
                dtgvUser.Columns["Image"].Visible = false;
            }

            _totalPagesUser = result.TotalPages;

            LayoutForm.RenderPagination(
                userPaginatePanel,
                _currentPageUser,
                _totalPagesUser,
                async (newPage) =>
                {
                    _currentPageUser = newPage;
                    await LoadUserList();
                }
            );

            BindUserData();

            DisplaySelectedUserImage(dtgvUser, pbUserImage);
        }

        private async Task ReloadUser()
        {
            await LoadUserList();

            ButtonAction(new Button[] { btnEditUser, btnDeleteUser, btnAddUser }, true);
            ButtonAction(new Button[] { btnSaveUser, btnCancelUser }, false);

            selectedUserImageBytes = null;

            txbUserPassword.ReadOnly = true;

            btnUploadUserImage.Enabled = false;

            DisplaySelectedUserImage(dtgvUser, pbUserImage);
        }
        #endregion

        #region Events
        public async void LoadData(object sender, EventArgs e)
        {
            var userTask = LoadUserList();

            await Task.WhenAll(userTask);
        }

        private async void txbSearchUser_TextChanged(object sender, EventArgs e)
        {
            await LoadUserList();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            ButtonAction(new Button[] { btnEditUser, btnDeleteUser, btnAddUser }, false);
            ButtonAction(new Button[] { btnSaveUser, btnCancelUser, btnUploadUserImage }, true);

            ClearTextbox(new TextBox[] { txbUserEmail, txbUserName, txbUserPassword });

            userAction = "ADD";

            txbUserPassword.ReadOnly = false;

            selectedUserImageBytes = null;
            pbUserImage.Image = null;
        }

        private void btnCancelUser_Click(object sender, EventArgs e)
        {
            ButtonAction(new Button[] { btnEditUser, btnDeleteUser, btnAddUser }, true);
            ButtonAction(new Button[] { btnSaveUser, btnCancelUser, btnUploadUserImage }, false);

            BindUserData();

            txbUserPassword.ReadOnly = true;

            DisplaySelectedUserImage(dtgvUser, pbUserImage);
        }

        private async void btnSaveUser_Click(object sender, EventArgs e)
        {
            switch (userAction)
            {
                case "ADD":
                    User user = new User
                    {
                        Name = txbUserName.Text,
                        Email = txbUserEmail.Text,  
                        Password = BCrypt.Net.BCrypt.HashPassword(txbUserPassword.Text),
                        Image = selectedUserImageBytes,
                    };

                    await UserService.Instance.CreateUser(user);

                    await ReloadUser();
                break;

                case "EDIT":
                    byte[] imageToSave = selectedUserImageBytes;

                    if (imageToSave == null)
                    {
                        var userObj = dtgvUser.CurrentRow?.DataBoundItem;
                        var imageProp = userObj?.GetType().GetProperty("Image");
                        if (imageProp != null)
                            imageToSave = (byte[])imageProp.GetValue(userObj);
                    }

                    User updateUser = new User
                    {
                        Id = selectedUserId,
                        Name = txbUserName.Text,
                        Email = txbUserEmail.Text,
                        Image = imageToSave,
                    };

                    await UserService.Instance.UpdateUser(updateUser);

                    await ReloadUser();
                break;

                default:
                    MessageBox.Show("Invalid action", "Error");
                break;
            }
        }

        private void btnUploadUserImage_Click(object sender, EventArgs e)
        {
            userFileDialog.Title = "Select User Image";
            userFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (userFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = userFileDialog.FileName;

                // Preview image
                pbUserImage.Image = System.Drawing.Image.FromFile(filePath);

                // Convert image to byte[]
                selectedUserImageBytes = System.IO.File.ReadAllBytes(filePath);
            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            ButtonAction(new Button[] { btnEditUser, btnDeleteUser, btnAddUser }, false);
            ButtonAction(new Button[] { btnSaveUser, btnCancelUser, btnUploadUserImage }, true);

            userAction = "EDIT";
        }

        private async void btnDeleteUser_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this user?",
                "Confirm Delete",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.OK)
            {
                await UserService.Instance.DeleteUser(selectedUserId);
                MessageBox.Show("User deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await ReloadUser();
            }
        }
        #endregion
    }
}
