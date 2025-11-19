using Lab_8.Models;
using Lab_8.Services;
using Lab_8.Utils;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormApp.DTO;
using WinFormApp.Forms;

namespace Lab_8.Forms
{
    public partial class Admin : Form
    {
        //Dependency injection
        private readonly Home _home;

        //Data binding
        private readonly BindingSource userlist = new BindingSource();
        private readonly BindingSource quizlist = new BindingSource();
        private readonly BindingSource rolelist = new BindingSource();

        //Placeholder
        private readonly bool _isPlaceholderUserApplied = false;
        private readonly bool _isPlaceholderQuizApplied = false;
        private readonly bool _isPlaceholderRoleApplied = false;

        //Paginate
        private readonly int _pageSize = 10;
        //User
        private int _currentPageUser = 1;
        private int _totalPagesUser = 1;
        //Quiz
        private int _currentPageQuiz = 1;
        private int _totalPagesQuiz = 1;
        //Role
        private int _currentPageRole = 1;
        private int _totalPagesRole = 1;

        //User property
        private string userAction = null;
        private byte[] selectedUserImageBytes = null;
        private int selectedUserId = 0;

        //Upsert Quiz-QA
        private List<Question> questionList = new List<Question>();
        private int selectedQuizId = 0;

        //Quiz property
        private string quizAction = null;
        private byte[] selectedQuizImageBytes = null;
        private int quizId = 0;

        //Role property
        private List<Role> _roles;
        private Role _selectedRole;
        private string roleAction = null;

        public Admin(Home home  )
        {
            InitializeComponent();
            StylePanels();
            ApplyPermissions();

            //Placeholder
            UIStyle.ApplyPlaceholder(txbSearchUser, "Search user", ref _isPlaceholderUserApplied);
            UIStyle.ApplyPlaceholder(txbSearchQuiz, "Search quiz", ref _isPlaceholderQuizApplied);
            UIStyle.ApplyPlaceholder(txbSearchRole, "Search role", ref _isPlaceholderRoleApplied);

            Load += LoadData;
            _home = home;
        }

        #region Methods
        private void LoadQuizDifficulty()
        {
            cbQuizDifficulty.DataSource = new string[] { "EASY", "MEDIUM", "HARD" };
        }

        private void ApplyPermissions()
        {
            var role = UserService.Instance.User.Role;

            if (role == null || !role.IsActive)
            {
                Alert.ShowAlert(
                    "Your role is inactive. You do not have permission to access this area.",
                    Alert.AlertType.Error
                );

                tcAdmin.TabPages.Clear();

                return;
            }

            var permissionNames = role.RolePermissions
                .Select(rp => rp.Permission.Name)
                .ToList();

            var permissionActions = new Dictionary<string, Action>
            {
                // Question
                { "Upsert Question Answer", () => tcAdmin.TabPages.Remove(tpQuestionAnswer) },

                // User
                { "View User", () => tcAdmin.TabPages.Remove(tpUser) },
                { "Create User", () => btnAddUser.Enabled = false },
                { "Delete User", () => btnDeleteUser.Enabled = false },
                { "Update User", () => btnEditUser.Enabled = false },

                // Quiz
                { "View Quiz", () => tcAdmin.TabPages.Remove(tpQuiz) },
                { "Create Quiz", () => btnAddQuiz.Enabled = false },
                { "Delete Quiz", () => btnDeleteQuiz.Enabled = false },
                { "Update Quiz", () => btnEditQuiz.Enabled = false },

                //Role
                { "View Role", () => tcAdmin.TabPages.Remove(tpRole) },
                { "Create Role", () => btnAddRole.Enabled = false },
                { "Delete Role", () => btnDeleteRole.Enabled = false },
                { "Update Role", () => btnEditQuiz.Enabled = false },

                //Permission
                { "View Permission", () => tcAdmin.TabPages.Remove(tpPermission) },
            };

            foreach (var kvp in permissionActions)
            {
                if (!permissionNames.Contains(kvp.Key))
                {
                    kvp.Value.Invoke();
                }
            }
        }

        public async Task LoadGroupPermission()
        {
            var result = await PermissionService.Instance.GetListPermission();

            var groupedPermissions = result.Items
                .GroupBy(p => p.Module)
                .Select(g => new
                {
                    Module = g.Key,
                    Permissions = g.ToList()
                })
                .ToList();

            flpRole.Controls.Clear();
            flpRole.AutoScroll = true;

            // ✅ Add padding around modules
            flpRole.Padding = new Padding(13);

            // ✅ 2 columns compact layout
            int columns = 2;
            int spacing = 8;

            // ✅ Width after padding applied
            int parentInnerWidth = flpRole.ClientSize.Width - flpRole.Padding.Horizontal;
            int moduleWidth = Math.Max(140, (parentInnerWidth - (columns - 1) * spacing) / columns);


            void UpdateModuleHeight(Panel modulePanel, Panel headerPanel, Panel permissionPanel)
            {
                modulePanel.Height = permissionPanel.Visible
                    ? headerPanel.Height + permissionPanel.Height + 8
                    : headerPanel.Height + 12;
            }

            void Reflow()
            {
                int x = flpRole.Padding.Left;
                int y = flpRole.Padding.Top;
                int col = 0;
                int rowMax = 0;

                foreach (Control ctl in flpRole.Controls)
                {
                    if (ctl is Panel panel)
                    {
                        panel.Location = new Point(x, y);
                        panel.Width = moduleWidth;

                        rowMax = Math.Max(rowMax, panel.Height);
                        col++;

                        if (col >= columns)
                        {
                            col = 0;
                            x = flpRole.Padding.Left;
                            y += rowMax + spacing;
                            rowMax = 0;
                        }
                        else x += moduleWidth + spacing;
                    }
                }
            }

            foreach (var group in groupedPermissions)
            {
                var modulePanel = new Panel
                {
                    Width = moduleWidth,
                    BorderStyle = BorderStyle.FixedSingle,
                    Padding = new Padding(2),
                    AutoSize = false
                };

                // Header
                var headerPanel = new Panel
                {
                    Height = 28,
                    Dock = DockStyle.Top
                };

                var btnToggle = new Button
                {
                    Text = "▶",
                    Width = 23,
                    Height = 23,
                    FlatStyle = FlatStyle.Flat
                };
                btnToggle.FlatAppearance.BorderSize = 0;
                btnToggle.Location = new Point(2, (headerPanel.Height - btnToggle.Height) / 2 + 1);

                var moduleCheckBox = new CheckBox
                {
                    Text = group.Module,
                    AutoSize = true,
                    Font = new Font("Segoe UI", 11f, FontStyle.Bold),
                    Location = new Point(btnToggle.Right + 6, (headerPanel.Height - 20) / 2 + 1)
                };

                headerPanel.Controls.Add(btnToggle);
                headerPanel.Controls.Add(moduleCheckBox);
                modulePanel.Controls.Add(headerPanel);

                // Permissions panel
                var permissionPanel = new Panel
                {
                    Visible = false,
                    AutoSize = true,
                    Location = new Point(18, headerPanel.Bottom + 1)
                };

                List<EventHandler> permHandlers = new List<EventHandler>();
                int yOff = 0;

                foreach (var perm in group.Permissions)
                {
                    var cb = new CheckBox
                    {
                        Text = perm.Name,
                        AutoSize = false,
                        Tag = perm,
                        Font = new Font("Segoe UI", 9.3f),
                        Location = new Point(0, yOff),
                        Width = moduleWidth - 40   // << FIX HERE
                    };

                    // Adjust height after measuring wrapped text
                    cb.Height = TextRenderer.MeasureText(cb.Text, cb.Font,
                        new Size(cb.Width, int.MaxValue),
                        TextFormatFlags.WordBreak).Height + 4;

                    yOff += cb.Height + 4;

                    EventHandler eh = (s, e) =>
                    {
                        bool allChecked = permissionPanel.Controls.OfType<CheckBox>().All(c => c.Checked);
                        moduleCheckBox.CheckedChanged -= ModuleCheckHandler;
                        moduleCheckBox.Checked = allChecked;
                        moduleCheckBox.CheckedChanged += ModuleCheckHandler;
                    };

                    cb.CheckedChanged += eh;
                    permHandlers.Add(eh);
                    permissionPanel.Controls.Add(cb);
                }

                void ModuleCheckHandler(object s, EventArgs e)
                {
                    int i = 0;
                    foreach (CheckBox cb in permissionPanel.Controls.OfType<CheckBox>())
                    {
                        cb.CheckedChanged -= permHandlers[i];
                        cb.Checked = moduleCheckBox.Checked;
                        cb.CheckedChanged += permHandlers[i];
                        i++;
                    }
                }

                moduleCheckBox.CheckedChanged += ModuleCheckHandler;
                modulePanel.Controls.Add(permissionPanel);

                // Expand/Collapse event
                btnToggle.Click += (s, e) =>
                {
                    permissionPanel.Visible = !permissionPanel.Visible;
                    btnToggle.Text = permissionPanel.Visible ? "▼" : "▶";
                    UpdateModuleHeight(modulePanel, headerPanel, permissionPanel);
                    Reflow();
                };

                UpdateModuleHeight(modulePanel, headerPanel, permissionPanel);
                flpRole.Controls.Add(modulePanel);
            }
            Reflow();
        }

        private void ApplyRolePermissionsToUI()
        {
            if (_selectedRole == null) return;

            var rolePermissionNames = _selectedRole.RolePermissions
                .Select(rp => rp.Permission.Name)
                .ToHashSet();

            foreach (var modulePanel in flpRole.Controls.OfType<Panel>())
            {
                foreach (var permissionPanel in modulePanel.Controls.OfType<Panel>())
                {
                    foreach (var cb in permissionPanel.Controls.OfType<CheckBox>())
                    {
                        if (cb.Tag is Permission perm)
                        {
                            cb.Checked = rolePermissionNames.Contains(perm.Name);
                        }
                    }
                }
            }
        }

        private async Task InsertOrUpdateRole(Func<Role, Task> action)
        {
            var selectedPermissions = new List<Permission>();

            foreach (var modulePanel in flpRole.Controls.OfType<Panel>())
            {
                foreach (var permissionPanel in modulePanel.Controls.OfType<Panel>())
                {
                    foreach (var cb in permissionPanel.Controls.OfType<CheckBox>())
                    {
                        if (cb.Checked && cb.Tag is Permission perm)
                            selectedPermissions.Add(perm);
                    }
                }
            }

            var newRole = new Role
            {
                Name = txbRoleName.Text,
                IsActive = cbIsActiveRole.SelectedItem?.ToString() == "Active",
                RolePermissions = selectedPermissions
                    .Select(p => new RolePermission { PermissionId = p.Id })
                    .ToList()
                };

            if (roleAction != "ADD" && _selectedRole != null)
            {
                newRole.Id = _selectedRole.Id;
            }

            await action(newRole);

            await GetListRole();
        }

        public async Task GetListRole()
        {
            string searchTerm = txbSearchRole.Text == "Search role" ? null : txbSearchRole.Text;
            var result = await RoleService.Instance.GetListRole(_pageSize, _currentPageRole, searchTerm);

            if (result == null || !result.Items.Any())
            {
                dtgvRole.DataSource = null;
                return;
            }

            _roles = result.Items.ToList();

            var rolesWithString = _roles.Select(r => new
            {
                r.Id,
                r.Name,
                IsActive = r.IsActive ? "Active" : "Inactive",
                Permissions = string.Join(", ", r.RolePermissions.Select(rp => rp.Permission.Name))
            }).ToList();

            rolelist.DataSource = rolesWithString;

            dtgvRole.DataSource = rolelist;

            if (dtgvRole.Columns.Contains("Permissions"))
            {
                dtgvRole.Columns["Permissions"].Visible = false;
            }

            _totalPagesRole = result.TotalPages;

            LayoutForm.RenderPagination(
                rolePaginatePanel,
                _currentPageRole,
                _totalPagesRole,
                async (newPage) =>
                {
                    _currentPageRole = newPage;
                    await GetListRole();
                }
            );

            cbIsActiveRole.DataSource = new List<string> { "Active", "Inactive" };

            BindRoleData();
        }

        private async Task LoadDataIntoCombobox<T>(ComboBox comboBox, Func<Task<PaginatedResult<T>>> dataFetcher)
        {
            var result = await dataFetcher();
            var items = result?.Items ?? new List<T>();

            if (typeof(T) == typeof(Role))
            {
                items = items
                    .Cast<Role>()        
                    .Where(r => r.IsActive)
                    .Cast<T>()            
                    .ToList();
            }

            comboBox.DataSource = items;
            comboBox.DisplayMember = "Name";
            comboBox.ValueMember = "Id";
        }

        private async Task LoadQuestionsByQuizId(int quizId)
        {
            selectedQuizId = quizId;

            // Fetch from service
            var result = await QuestionService.Instance.GetListQuestionByQuiz(quizId);
            questionList = result.ToList() ?? new List<Question>();

            // If no question found, start with one empty
            if (questionList.Count == 0)
                questionList.Add(new Question
                {
                    QuizId = quizId,
                    Name = "",
                    Answers = new List<Answer> 
                    {
                        new Answer { Name = "", IsCorrect = false }
                    }
                });

            RenderQuestionList();
        }

        private void RenderQuestionList()
        {
            panel8.Controls.Clear();
            panel8.AutoScroll = true;

            int y = 10;
            int questionPanelPadding = 10;
            int answerPadding = 5;

            foreach (var q in questionList)
            {
                // Calculate dynamic height
                int questionHeight = 40; // question label + textbox
                int pictureRowHeight = 100; // PictureBox row height
                int answersHeight = 35 * q.Answers.Count + 30; // estimated height for answers
                int panelHeight = questionHeight + pictureRowHeight + answersHeight + 30;

                // Question Panel
                var questionPanel = new Panel
                {
                    Width = panel8.Width - 40,
                    Height = panelHeight,
                    Left = 10,
                    Top = y,
                    BorderStyle = BorderStyle.FixedSingle,
                    Padding = new Padding(questionPanelPadding),
                    AutoScroll = true
                };

                // Question Label and TextBox
                var lbl = new Label { Text = "Question:", Left = 10, Top = 10, Width = 70 };
                questionPanel.Controls.Add(lbl);

                var txbQuestion = new TextBox
                {
                    Left = lbl.Right + 5,
                    Top = lbl.Top - 5,
                    Width = 400,
                    Text = q.Name
                };
                txbQuestion.TextChanged += (s, e) => q.Name = txbQuestion.Text;
                questionPanel.Controls.Add(txbQuestion);

                // Add / Remove Question Buttons
                var btnAddQ = new Button { Text = "+", Left = txbQuestion.Right + 5, Top = lbl.Top - 4, Width = 30 };
                var btnRemoveQ = new Button { Text = "-", Left = btnAddQ.Right + 5, Top = lbl.Top - 4, Width = 30 };
                btnAddQ.Click += (s, e) => AddQuestion();
                btnRemoveQ.Click += (s, e) => RemoveQuestion(q);
                questionPanel.Controls.Add(btnAddQ);
                if (questionList.Count > 1) questionPanel.Controls.Add(btnRemoveQ);

                // --- PictureBox ---
                var pic = new PictureBox
                {
                    Left = 10,
                    Top = lbl.Bottom + 10,
                    Width = 163,
                    Height = 100,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BorderStyle = BorderStyle.FixedSingle,
                    Cursor = Cursors.Hand
                };
                if (q.Image != null)
                    using (var ms = new MemoryStream(q.Image))
                        pic.Image = Image.FromStream(ms);

                pic.Click += (s, e) =>
                {
                    using (OpenFileDialog dlg = new OpenFileDialog())
                    {
                        dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                        dlg.Title = "Select Question Image";

                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            q.Image = File.ReadAllBytes(dlg.FileName);
                            pic.Image = Image.FromFile(dlg.FileName);
                        }
                    }
                };
                questionPanel.Controls.Add(pic);

                // --- Upload Audio Button (same row) ---
                var btnUploadAudio = new Button
                {
                    Text = "Upload Audio",
                    Left = pic.Right + 10,
                    Top = pic.Top,
                    Width = 100,
                    Height = 27
                };
                btnUploadAudio.Click += (s, e) =>
                {
                    using (OpenFileDialog dlg = new OpenFileDialog())
                    {
                        dlg.Filter = "Audio Files|*.wav;*.mp3";
                        dlg.Title = "Select Question Audio";

                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            q.Audio = File.ReadAllBytes(dlg.FileName);
                            RenderQuestionList(); // refresh to show Play/Stop buttons
                        }
                    }
                };
                questionPanel.Controls.Add(btnUploadAudio);

                // --- Play / Stop Audio Buttons (if audio exists) ---
                if (q.Audio != null)
                {
                    var btnPlayPause = new Button
                    {
                        Text = "Play",
                        Left = btnUploadAudio.Right + 5,
                        Top = pic.Top,
                        Width = 100,
                        Height = 27
                    };

                    btnPlayPause.Click += (s, e) =>
                    {
                        if (q.WaveOut != null && q.WaveOut.PlaybackState == PlaybackState.Playing)
                        {
                            Helper.PauseAudio(q);   
                            btnPlayPause.Text = "Play";
                        }
                        else
                        {
                            Helper.PlayAudio(q, btnPlayPause);
                            btnPlayPause.Text = "Pause";
                        }
                    };
                    questionPanel.Controls.Add(btnPlayPause);
                }

                // --- GroupBox for Answers ---
                int answersTop = pic.Bottom + 10; // start below PictureBox row
                var answerGroup = new GroupBox
                {
                    Text = "Answers",
                    Top = answersTop,
                    Left = 10,
                    Width = questionPanel.Width - 2 * questionPanelPadding,
                    Height = panelHeight - answersTop - 10,
                    Padding = new Padding(answerPadding)
                };
                questionPanel.Controls.Add(answerGroup);

                // --- Add answers ---
                int yAnswer = 30;
                foreach (var a in q.Answers)
                {
                    var rb = new RadioButton
                    {
                        Top = yAnswer,
                        Left = 20,
                        AutoSize = true,
                        Checked = a.IsCorrect
                    };
                    rb.CheckedChanged += (s, e) =>
                    {
                        if (rb.Checked)
                        {
                            foreach (var ans in q.Answers)
                                ans.IsCorrect = false;
                            a.IsCorrect = true;
                        }
                    };
                    answerGroup.Controls.Add(rb);

                    var txbAnswer = new TextBox
                    {
                        Top = yAnswer - 5,
                        Left = rb.Right + 5,
                        Width = 300,
                        Text = a.Name,
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    txbAnswer.TextChanged += (s, e) => a.Name = txbAnswer.Text.TrimStart();
                    answerGroup.Controls.Add(txbAnswer);

                    // Add / Remove buttons
                    var btnAddA = new Button { Text = "+", Left = txbAnswer.Right + 5, Top = yAnswer - 4, Width = 30, Enabled = q.Answers.Count < 4 };
                    var btnRemoveA = new Button { Text = "-", Left = btnAddA.Right + 5, Top = yAnswer - 4, Width = 30 };
                    btnAddA.Click += (s, e) => AddAnswer(q);
                    btnRemoveA.Click += (s, e) => RemoveAnswer(q, a);
                    answerGroup.Controls.Add(btnAddA);
                    if (q.Answers.Count > 1) answerGroup.Controls.Add(btnRemoveA);

                    yAnswer += 35;
                }

                panel8.Controls.Add(questionPanel);
                y += questionPanel.Height + 10;
            }
        }

        private void AddQuestion()
        {
            questionList.Add(new Question
            {
                QuizId = selectedQuizId,
                Name = "",
                Answers = new List<Answer> { new Answer { Name = "", IsCorrect = false } }
            });
            RenderQuestionList();
        }

        private void RemoveQuestion(Question q)
        {
            questionList.Remove(q);
            if (questionList.Count == 0)
                AddQuestion(); // Always keep at least one
            RenderQuestionList();
        }

        private void AddAnswer(Question q)
        {
            q.Answers.Add(new Answer { Name = "", IsCorrect = false });
            RenderQuestionList();
        }

        private void RemoveAnswer(Question q, Answer a)
        {
            q.Answers.Remove(a);
            if (q.Answers.Count == 0)
                AddAnswer(q);
            RenderQuestionList();
        }

        private void StylePanels()
        {
            foreach (var panel in (new Panel[]
            { 
                //User
                userPaginatePanel, userEmailPanel, userPasswordPanel,
                userTablePanel, userImagePanel, userNamePanel, userRolePanel,
                //Quiz-QA
                panel8, listQuizPanel,
                //Quiz
                quizDifficultyPanel, quizImagePanel, quizPaginatePanel,
                quizNamePanel, quizTablePanel, quizCategoryPanel,
                //Role
                roleNamePanel, roleIsActivePanel, flpRole,
                rolePaginatePanel, roleTablePanel, moduleListPanel
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
                using (var ms = new MemoryStream(imageBytes))
                {
                    pictureBox.Image = Image.FromStream(ms);
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

        private void DisplaySelectedQuizImage(DataGridView dataGridView, PictureBox pictureBox)
        {
            if (dataGridView.CurrentRow?.DataBoundItem is object entityObj)
            {
                var idProp = entityObj.GetType().GetProperty("Id");
                if (idProp != null)
                    quizId = (int)idProp.GetValue(entityObj);

                LoadImage(pictureBox, entityObj);
            }
            else
            {
                pictureBox.Image = null;
            }
        }

        private void ClearControlBindings(params Control[] controls)
        {
            foreach (var ctrl in controls)
            {
                ctrl.DataBindings.Clear();
                if (ctrl is TextBox txb) txb.Clear();
                if (ctrl is ComboBox cb) cb.SelectedIndex = -1;
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
            ClearControlBindings(txbUserEmail, txbUserName, txbUserPassword, cbUserRole);

            if (userlist == null || userlist.Count == 0) return;

            txbUserEmail.DataBindings.Add("Text", userlist, "Email", true, DataSourceUpdateMode.Never);
            txbUserName.DataBindings.Add("Text", userlist, "Name", true, DataSourceUpdateMode.Never);
            txbUserPassword.DataBindings.Add("Text", userlist, "Password", true, DataSourceUpdateMode.Never);
            cbUserRole.DataBindings.Add("Text", userlist, "Role", true, DataSourceUpdateMode.Never);

            dtgvUser.SelectionChanged += (s, e) => DisplaySelectedUserImage(dtgvUser, pbUserImage);
        }

        private void BindRoleData()
        {
            ClearControlBindings(txbRoleName, cbIsActiveRole);

            if (rolelist == null || rolelist.Count == 0) return;

            txbRoleName.DataBindings.Add("Text", rolelist, "Name", true, DataSourceUpdateMode.Never);
            cbIsActiveRole.DataBindings.Add("SelectedItem", rolelist, "IsActive", true, DataSourceUpdateMode.Never);
        }

        private void BindQuizData()
        {
            ClearControlBindings(txbQuizName, cbQuizDifficulty, cbQuizCategory);

            if (quizlist == null || quizlist.Count == 0) return;

            txbQuizName.DataBindings.Add("Text", quizlist, "Name", true, DataSourceUpdateMode.Never);
            cbQuizDifficulty.DataBindings.Add("Text", quizlist, "Difficulty", true, DataSourceUpdateMode.Never);
            cbQuizCategory.DataBindings.Add("Text", quizlist, "Category", true, DataSourceUpdateMode.Never);

            dtgvQuiz.SelectionChanged += (s, e) => DisplaySelectedQuizImage(dtgvQuiz, pbQuizImage);
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
                u.Image,
                Role = u.Role.Name
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

        private async Task LoadQuizList()
        {
            var result = await QuizService.Instance.GetListQuiz(
                _pageSize,
                _currentPageQuiz,
                txbSearchQuiz.Text == "Search quiz" ? null : txbSearchQuiz.Text);

            if (result == null || !result.Items.Any())
            {
                dtgvQuiz.DataSource = null;
                return;
            }

            quizlist.DataSource = result.Items.Select(u => new
            {
                u.Id,
                u.Name,
                u.Difficulty,
                u.Image,
                Category = u.Category.Name,
            }).ToList();

            dtgvQuiz.DataSource = quizlist;

            if (dtgvQuiz.Columns.Contains("Image"))
            {
                dtgvQuiz.Columns["Image"].Visible = false;
            }

            _totalPagesQuiz = result.TotalPages;

            LayoutForm.RenderPagination(
               quizPaginatePanel,
               _currentPageQuiz,
               _totalPagesQuiz,
               async (newPage) =>
               {
                   _currentPageQuiz = newPage;
                   await LoadQuizList();
               }
            );

            BindQuizData();

            DisplaySelectedQuizImage(dtgvQuiz, pbQuizImage);
        }

        private async Task ReloadUser()
        {
            await LoadUserList();

            ButtonAction(new Button[] { btnEditUser, btnDeleteUser, btnAddUser }, true);
            ButtonAction(new Button[] { btnSaveUser, btnCancelUser, btnUploadUserImage }, false);

            selectedUserImageBytes = null;

            txbUserPassword.ReadOnly = true;
            txbUserEmail.ReadOnly = true;

            userAction = null;

            DisplaySelectedUserImage(dtgvUser, pbUserImage);
        }

        private async Task ReloadQuiz()
        {
            await LoadQuizList();

            ButtonAction(new Button[] { btnEditQuiz, btnAddQuiz, btnDeleteQuiz }, true);
            ButtonAction(new Button[] { btnSaveQuiz, btnCancelQuiz, btnUploadQuiz }, false);

            selectedQuizImageBytes = null;

            DisplaySelectedQuizImage(dtgvQuiz, pbQuizImage);

            quizAction = null;

            await _home.LoadQuiz();
        }

        private async Task ReloadRole()
        {
            await GetListRole();

            ButtonAction(new Button[] { btnAddRole, btnEditRole, btnDeleteRole }, true);
            ButtonAction(new Button[] { btnSaveRole, btnCancelRole }, false);

            ApplyRolePermissionsToUI();

            await LoadDataIntoCombobox(
                cbUserRole,
                () => RoleService.Instance.GetListRole(100, 1, null));

            roleAction = null;
        }

        private void ClearAllCheckoxPermission()
        {
            foreach (var modulePanel in flpRole.Controls.OfType<Panel>())
            {
                foreach (var permissionPanel in modulePanel.Controls.OfType<Panel>())
                {
                    foreach (var cb in permissionPanel.Controls.OfType<CheckBox>())
                    {
                        cb.Checked = false;
                    }
                }
            }
        }
        #endregion

        #region Events
        public async void LoadData(object sender, EventArgs e)
        {
            var userTask = LoadUserList();
            var quizTask = LoadQuizList();
            var groupPermissionTask = LoadGroupPermission();
            var roleTask = GetListRole();

            var quizTaskToComboBox = LoadDataIntoCombobox(
                cbQuizName,
                () => QuizService.Instance.GetListQuiz(100, 1, null));
            var quizCategoryToComboBoxTask = LoadDataIntoCombobox(
                cbQuizCategory, 
                () => CategoryService.Instance.GetListCategory(100, 1, null));
            var userRoleToComboBoxTask = LoadDataIntoCombobox(
                cbUserRole,
                () => RoleService.Instance.GetListRole(100, 1, null));

            await Task.WhenAll(
                userTask, 
                quizTaskToComboBox, 
                quizTask, 
                quizCategoryToComboBoxTask, 
                userRoleToComboBoxTask,
                groupPermissionTask,
                roleTask
            );

            if (cbQuizName.SelectedItem is Quiz selectedQuiz)
            {
                await LoadQuestionsByQuizId(selectedQuiz.Id);
            }

            LoadQuizDifficulty();
        }

        private async void txbSearchUser_TextChanged(object sender, EventArgs e)
        {
            await LoadUserList();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            ButtonAction(new Button[] { btnEditUser, btnDeleteUser, btnAddUser }, false);
            ButtonAction(new Button[] { btnSaveUser, btnCancelUser, btnUploadUserImage }, true);

            ClearControlBindings(txbUserEmail, txbUserName, txbUserPassword, cbUserRole);

            userAction = "ADD";

            txbUserPassword.ReadOnly = false;
            txbUserEmail.ReadOnly = false;

            selectedUserImageBytes = null;
            pbUserImage.Image = null;
        }

        private void btnAddQuiz_Click(object sender, EventArgs e)
        {
            ButtonAction(new Button[] { btnEditQuiz, btnAddQuiz, btnDeleteQuiz }, false);
            ButtonAction(new Button[] { btnSaveQuiz, btnCancelQuiz, btnUploadQuiz }, true);

            ClearControlBindings(txbQuizName, cbQuizDifficulty, cbQuizCategory);

            quizAction = "ADD";

            selectedQuizImageBytes = null;
            pbQuizImage.Image = null;
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            ButtonAction(new Button[] { btnAddRole, btnEditRole, btnDeleteRole }, false);
            ButtonAction(new Button[] { btnSaveRole, btnCancelRole }, true);

            ClearControlBindings(txbRoleName, cbIsActiveRole);

            roleAction = "ADD";

            ClearAllCheckoxPermission();
        }

        private void btnCancelUser_Click(object sender, EventArgs e)
        {
            ButtonAction(new Button[] { btnEditUser, btnDeleteUser, btnAddUser }, true);
            ButtonAction(new Button[] { btnSaveUser, btnCancelUser, btnUploadUserImage }, false);

            BindUserData();

            txbUserPassword.ReadOnly = true;
            txbUserEmail.ReadOnly = true;

            userAction = null;

            DisplaySelectedUserImage(dtgvUser, pbUserImage);
        }

        private void btnCancelQuiz_Click(object sender, EventArgs e)
        {
            ButtonAction(new Button[] { btnEditQuiz, btnAddQuiz, btnDeleteQuiz }, true);
            ButtonAction(new Button[] { btnSaveQuiz, btnCancelQuiz, btnUploadQuiz }, false);

            BindQuizData();

            quizAction = null;

            DisplaySelectedUserImage(dtgvQuiz, pbQuizImage);
        }

        private void btnCancelRole_Click(object sender, EventArgs e)
        {
            ButtonAction(new Button[] { btnAddRole, btnEditRole, btnDeleteRole }, true);
            ButtonAction(new Button[] { btnSaveRole, btnCancelRole }, false);

            BindRoleData();

            ApplyRolePermissionsToUI();

            roleAction = null;
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
                        RoleId = (int)cbUserRole.SelectedValue
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

                    User updateToUser = new User
                    {
                        Id = selectedUserId,
                        Name = txbUserName.Text,
                        Email = txbUserEmail.Text,
                        Image = imageToSave,
                        RoleId = (int)cbUserRole.SelectedValue
                    };

                    var updatedUser = await UserService.Instance.UpdateUser(updateToUser);

                    await ReloadUser();

                    if(UserService.Instance.User.Id == updatedUser.Id)
                    {
                        UserService.Instance.User = updatedUser;
                        _home.toolStripBtnDropdown.Text = updatedUser.Name;
                    }
                break;

                default:
                    Alert.ShowAlert("Invalid action", Alert.AlertType.Error);
                break;
            }
        }

        private async void btnSaveQuiz_Click(object sender, EventArgs e)
        {
            switch (quizAction)
            {
                case "ADD":
                    Quiz quiz = new Quiz
                    {
                        Name = txbQuizName.Text,
                        Difficulty = cbQuizDifficulty.Text,
                        Image = selectedQuizImageBytes,
                        CategoryId = (int)cbQuizCategory.SelectedValue
                    };

                    await QuizService.Instance.CreateQuiz(quiz);

                    await ReloadQuiz(); 
                break;

                case "EDIT":
                    byte[] imageToSave = selectedQuizImageBytes;

                    if (imageToSave == null)
                    {
                        var quizObj = dtgvQuiz.CurrentRow?.DataBoundItem;
                        var imageProp = quizObj?.GetType().GetProperty("Image");
                        if (imageProp != null)
                            imageToSave = (byte[])imageProp.GetValue(quizObj);
                    }

                    Quiz updateQuiz = new Quiz
                    {
                        Id = quizId,
                        Name = txbQuizName.Text,
                        Difficulty = cbQuizDifficulty.Text,
                        Image = imageToSave,
                        CategoryId = (int)cbQuizCategory.SelectedValue
                    };

                    await QuizService.Instance.UpdateQuiz(updateQuiz);

                    await ReloadQuiz();
                break;

                default:
                    Alert.ShowAlert("Invalid action", Alert.AlertType.Error);
                break;
            }
        }

        private async void btnSaveRole_Click(object sender, EventArgs e)
        {
            switch (roleAction)
            {
                case "ADD":
                    await InsertOrUpdateRole(RoleService.Instance.InsertRole);
                    await ReloadRole();
                break;

                case "EDIT":
                    await InsertOrUpdateRole(RoleService.Instance.UpdateRole);
                    await ReloadRole();
                break;

                default:
                    Alert.ShowAlert("Invalid action", Alert.AlertType.Error);
                break;
            }
        }

        private void btnUploadUserImage_Click(object sender, EventArgs e)
        {
            selectedUserImageBytes = Helper.UploadImage(userFileDialog, pbUserImage);
        }

        private void btnUploadQuiz_Click(object sender, EventArgs e)
        {
            selectedQuizImageBytes = Helper.UploadImage(quizFileDialog, pbQuizImage);
        }

        private void btnEditRole_Click(object sender, EventArgs e)
        {
            ButtonAction(new Button[] { btnAddRole, btnEditRole, btnDeleteRole }, false);
            ButtonAction(new Button[] { btnSaveRole, btnCancelRole }, true);

            roleAction = "EDIT";
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            ButtonAction(new Button[] { btnEditUser, btnDeleteUser, btnAddUser }, false);
            ButtonAction(new Button[] { btnSaveUser, btnCancelUser, btnUploadUserImage }, true);

            userAction = "EDIT";
        }

        private void btnEditQuiz_Click(object sender, EventArgs e)
        {
            ButtonAction(new Button[] { btnEditQuiz, btnAddQuiz, btnDeleteQuiz }, false);
            ButtonAction(new Button[] { btnSaveQuiz, btnCancelQuiz, btnUploadQuiz }, true);

            quizAction = "EDIT";
        }

        private async void btnDeleteUser_Click(object sender, EventArgs e)
        {
            bool confirm = Confirmation.ShowConfirm("Confirm Delete",
              "Are you sure you want to delete this user?");

            if (confirm)
            {
                await UserService.Instance.DeleteUser(selectedUserId);

                await ReloadUser();
            }
        }

        private async void btnDeleteQuiz_Click(object sender, EventArgs e)
        {
            bool confirm = Confirmation.ShowConfirm("Confirm Delete",
              "Are you sure you want to delete this quiz?");

            if (confirm)
            {
                await QuizService.Instance.DeleteQuiz(quizId);

                await ReloadQuiz();
            }
        }

        private async void btnDeleteRole_Click(object sender, EventArgs e)
        {
            bool confirm = Confirmation.ShowConfirm("Confirm Delete",
              "Are you sure you want to delete this role?");

            if (confirm)
            {
                await RoleService.Instance.DeleteRole(_selectedRole.Id);

                await ReloadRole();
            }
        }

        private async void cbQuizName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbQuizName.SelectedItem is Quiz selectedQuiz)
                await LoadQuestionsByQuizId(selectedQuiz.Id);
        }

        private async void btnUpsertQuizQA_Click(object sender, EventArgs e)
        {
            if(questionList != null && questionList.Count > 0)
            {
                await QuestionService.Instance.UpsertQuestionAnswer(questionList, selectedQuizId);

                RenderQuestionList();
            }
        }

        private async void txbSearchQuiz_TextChanged(object sender, EventArgs e)
        {
            await LoadQuizList();
        }

        private void dtgvRole_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgvRole.CurrentRow != null)
            {
                int roleId = (int)dtgvRole.CurrentRow.Cells["Id"].Value;
                _selectedRole = _roles.FirstOrDefault(r => r.Id == roleId);
                ApplyRolePermissionsToUI();
            }
        }

        private async void txbSearchRole_TextChanged(object sender, EventArgs e)
        {
            await GetListRole();
        }
        #endregion
    }
}
