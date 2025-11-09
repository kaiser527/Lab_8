using Lab_8.Models;
using Lab_8.Services;
using Lab_8.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_8.Forms
{
    public partial class Admin : Form
    {
        //Dependency injection
        private readonly Home _home;

        //Data binding
        private readonly BindingSource userlist = new BindingSource();
        private readonly BindingSource quizlist = new BindingSource();

        //Placeholder
        private readonly bool _isPlaceholderUserApplied = false;
        private readonly bool _isPlaceholderQuizApplied = false;

        //Paginate
        private readonly int _pageSize = 10;
        //User
        private int _currentPageUser = 1;
        private int _totalPagesUser = 1;
        //Quiz
        private int _currentPageQuiz = 1;
        private int _totalPagesQuiz = 1;

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

        public Admin(Home home  )
        {
            InitializeComponent();
            StylePanels();

            //Placeholder
            UIStyle.ApplyPlaceholder(txbSearchUser, "Search user", ref _isPlaceholderUserApplied);
            UIStyle.ApplyPlaceholder(txbSearchQuiz, "Search quiz", ref _isPlaceholderQuizApplied);

            Load += LoadData;
            _home = home;
        }

        private void LoadQuizDifficulty()
        {
            cbQuizDifficulty.DataSource = new string[] { "EASY", "MEDIUM", "HARD" };
        }
        #region Methods
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
            int questionPanelPadding = 10; // padding inside question panel
            int answerPadding = 5;          // padding inside answer group

            foreach (var q in questionList)
            {
                // Question Panel
                var questionPanel = new Panel
                {
                    Width = panel8.Width - 40,
                    Height = 226, 
                    Left = 10,
                    Top = y,
                    BorderStyle = BorderStyle.FixedSingle,
                    Padding = new Padding(questionPanelPadding),
                    AutoScroll = true
                };

                // Question Label
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

                // GroupBox for Answers (handles radio grouping)
                var answerGroup = new GroupBox
                {
                    Text = "Answers",
                    Top = lbl.Bottom + 10,
                    Left = 10,
                    Width = questionPanel.Width - 2 * questionPanelPadding,
                    Height = questionPanel.Height - lbl.Bottom - 20,
                    Padding = new Padding(answerPadding)
                };
                questionPanel.Controls.Add(answerGroup);

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
                            //Uncheck current answer
                            foreach (var ans in q.Answers)
                                ans.IsCorrect = false;

                            a.IsCorrect = true;
                        }
                    };
                    answerGroup.Controls.Add(rb);

                    var txbAnswer = new TextBox
                    {
                        Top = yAnswer - 5 ,
                        Left = rb.Right + 5,
                        Width = 300,
                        Text = a.Name,
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    txbAnswer.TextChanged += (s, e) => a.Name = txbAnswer.Text.TrimStart();
                    answerGroup.Controls.Add(txbAnswer);

                    // Add / Remove Answer Buttons
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
                userTablePanel, userImagePanel, userNamePanel,
                //Quiz-QA
                panel8, listQuizPanel,
                //Quiz
                quizDifficultyPanel, quizImagePanel, quizPaginatePanel,
                quizNamePanel, quizTablePanel,
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
            ClearControlBindings(txbUserEmail, txbUserName, txbUserPassword);

            if (userlist == null || userlist.Count == 0) return;

            txbUserEmail.DataBindings.Add("Text", userlist, "Email", true, DataSourceUpdateMode.Never);
            txbUserName.DataBindings.Add("Text", userlist, "Name", true, DataSourceUpdateMode.Never);
            txbUserPassword.DataBindings.Add("Text", userlist, "Password", true, DataSourceUpdateMode.Never);

            dtgvUser.SelectionChanged += (s, e) => DisplaySelectedUserImage(dtgvUser, pbUserImage);
        }

        private void BindQuizData()
        {
            ClearControlBindings(txbQuizName, cbQuizDifficulty);

            if (quizlist == null || quizlist.Count == 0) return;

            txbQuizName.DataBindings.Add("Text", quizlist, "Name", true, DataSourceUpdateMode.Never);
            cbQuizDifficulty.DataBindings.Add("Text", quizlist, "Difficulty", true, DataSourceUpdateMode.Never);

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
                u.Image
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

        private async Task LoadQuizListToComboBox()
        {
            var result = await QuizService.Instance.GetListQuiz(100, 1, null);

            cbQuizName.DataSource = result.Items;
            cbQuizName.DisplayMember = "Name";
        }

        private async Task ReloadUser()
        {
            await LoadUserList();

            ButtonAction(new Button[] { btnEditUser, btnDeleteUser, btnAddUser }, true);
            ButtonAction(new Button[] { btnSaveUser, btnCancelUser }, false);

            selectedUserImageBytes = null;

            txbUserPassword.ReadOnly = true;
            txbUserEmail.ReadOnly = true;   

            btnUploadUserImage.Enabled = false;

            DisplaySelectedUserImage(dtgvUser, pbUserImage);
        }

        private async Task ReloadQuiz()
        {
            await LoadQuizList();

            ButtonAction(new Button[] { btnEditQuiz, btnAddQuiz, btnDeleteQuiz }, true);
            ButtonAction(new Button[] { btnSaveQuiz, btnCancelQuiz, btnUploadQuiz }, false);

            selectedQuizImageBytes = null;

            btnUploadQuiz.Enabled = false;

            DisplaySelectedQuizImage(dtgvQuiz, pbQuizImage);

            await _home.LoadQuiz();
        }
        #endregion

        #region Events
        public async void LoadData(object sender, EventArgs e)
        {
            var userTask = LoadUserList();
            var quizTaskToComboBox = LoadQuizListToComboBox();
            var quizTask = LoadQuizList();

            await Task.WhenAll(userTask, quizTaskToComboBox, quizTask);

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

            ClearControlBindings(txbUserEmail, txbUserName, txbUserPassword);

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

            ClearControlBindings(txbQuizName, cbQuizDifficulty);

            quizAction = "ADD";

            selectedQuizImageBytes = null;
            pbQuizImage.Image = null;
        }

        private void btnCancelUser_Click(object sender, EventArgs e)
        {
            ButtonAction(new Button[] { btnEditUser, btnDeleteUser, btnAddUser }, true);
            ButtonAction(new Button[] { btnSaveUser, btnCancelUser, btnUploadUserImage }, false);

            BindUserData();

            txbUserPassword.ReadOnly = true;
            txbUserEmail.ReadOnly = true;

            DisplaySelectedUserImage(dtgvUser, pbUserImage);
        }

        private void btnCancelQuiz_Click(object sender, EventArgs e)
        {
            ButtonAction(new Button[] { btnEditQuiz, btnAddQuiz, btnDeleteQuiz }, true);
            ButtonAction(new Button[] { btnSaveQuiz, btnCancelQuiz, btnUploadQuiz }, false);

            BindQuizData();

            DisplaySelectedUserImage(dtgvQuiz, pbQuizImage);
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

        private async void btnSaveQuiz_Click(object sender, EventArgs e)
        {
            switch (quizAction)
            {
                case "ADD":
                    Quiz quiz = new Quiz
                    {
                        Name = txbQuizName.Text,
                        Difficulty = cbQuizDifficulty.Text,
                        Image = selectedQuizImageBytes
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
                        Image = imageToSave
                    };

                    await QuizService.Instance.UpdateQuiz(updateQuiz);

                    await ReloadQuiz();
                break;

                default:
                    MessageBox.Show("Invalid action", "Error");
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

        private async void btnDeleteQuiz_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this quiz?",
                "Confirm Delete",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.OK)
            {
                await QuizService.Instance.DeleteQuiz(quizId);
                MessageBox.Show("Quiz deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await ReloadQuiz();
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
        #endregion
    }
}
