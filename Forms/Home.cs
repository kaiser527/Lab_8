using Lab_8.Models;
using Lab_8.Services;
using Lab_8.Utils;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_8.Forms
{
    public partial class Home : Form
    {
        private int _currentPageQuiz = 1;
        private readonly int _pageSizeQuiz = 6;
        private int _totalPagesQuiz = 1;

        private int _currentPageHistory = 1;
        private readonly int _pageSizeHistory = 5;
        private int _totalPagesHistory = 1;
        private DateTime? _timeStart = null;
        private DateTime? _timeFinish = null;

        public Home()
        {
            InitializeComponent();
            StylePanels();
            Load += load_Data;
        }

        #region Methods
        public async Task LoadQuiz()
        {
            flpQuiz.Controls.Clear();

            var result = await QuizService.Instance.GetListQuiz(_pageSizeQuiz, _currentPageQuiz, null);
            if (result == null || !result.Items.Any()) return;

            _totalPagesQuiz = result.TotalPages;

            foreach (var quiz in result.Items)
            {
                var card = await CreateQuizCard(quiz);
                flpQuiz.Controls.Add(card);
            }

            LayoutForm.RenderPagination(
                paginatePanelQuiz,
                _currentPageQuiz,
                _totalPagesQuiz,
                async (newPage) =>
                {
                    _currentPageQuiz = newPage;
                    await LoadQuiz();
                }
            );
        }

        private void StylePanels()
        {
            UIStyle.RoundPanel(paginatePanelQuiz, 15);
            UIStyle.RoundPanel(historyPanel, 15);
            UIStyle.RoundPanel(flpQuiz, 15);
            UIStyle.RoundPanel(paginatePanelHistory, 15);
        }

        public async Task<int> ShowHistoryAsync(int quizId)
        {
            historyPanel.Controls.Clear();

            var user = UserService.Instance.User;

            // Title
            Label lblTitle = new Label
            {
                Text = "Quiz History",
                Dock = DockStyle.Top,
                Height = 40,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.FromArgb(0, 120, 215)
            };
            historyPanel.Controls.Add(lblTitle);

            // Base container (FlowLayoutPanel)
            var flow = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(15, 52, 15, 15), // keep your padding
                BackColor = Color.WhiteSmoke
            };
            historyPanel.Controls.Add(flow);

            // --- Create DateTimePickers panel (always visible) ---
            Panel datePickerPanel = new Panel
            {
                Width = flow.ClientSize.Width - 30,
                Height = 20,
                Margin = new Padding(0, 0, 0, 4) // keep your margin
            };

            DateTimePicker dtpStart = new DateTimePicker
            {
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "yyyy-MM-dd HH:mm",
                Width = (datePickerPanel.Width / 2) - 5,
                Location = new Point(0, 0)
            };
            dtpStart.ValueChanged += async (s, e) =>
            {
                _timeStart = dtpStart.Value;
                _currentPageHistory = 1;
                await RenderHistoryPagination(quizId);
            };

            DateTimePicker dtpFinish = new DateTimePicker
            {
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "yyyy-MM-dd HH:mm",
                Width = (datePickerPanel.Width / 2) - 5,
                Location = new Point(dtpStart.Right + 10, 0)
            };
            dtpFinish.ValueChanged += async (s, e) =>
            {
                _timeFinish = dtpFinish.Value;
                _currentPageHistory = 1;
                await RenderHistoryPagination(quizId);
            };

            datePickerPanel.Controls.Add(dtpStart);
            datePickerPanel.Controls.Add(dtpFinish);
            flow.Controls.Add(datePickerPanel);

            Panel resetPanel = new Panel
            {
                Width = datePickerPanel.Width,
                Height = 30,
                Margin = new Padding(0, 0, 0, 0)
            };

            Button btnReset = new Button
            {
                Text = "Reset Filter",
                Width = datePickerPanel.Width / 3,
                Height = 24,
                BackColor = Color.LightGray,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 8, FontStyle.Regular)
            };
            btnReset.FlatAppearance.BorderSize = 0;

            // Center the button in the panel
            btnReset.Left = (resetPanel.Width - btnReset.Width) / 2;
            btnReset.Top = (resetPanel.Height - btnReset.Height) / 2;

            btnReset.Click += async (s, e) =>
            {
                dtpStart.Value = DateTime.Now;
                dtpFinish.Value = DateTime.Now;
                _timeStart = null;
                _timeFinish = null;
                _currentPageHistory = 1;
                await RenderHistoryPagination(quizId);
            };

            resetPanel.Controls.Add(btnReset);
            flow.Controls.Add(resetPanel);

            // --- Fetch filtered history ---
            var result = await HistoryService.Instance.GetListHistoryByQuizIdAndUserId(
                quizId,
                user.Id,
                _pageSizeHistory,
                _currentPageHistory,
                _timeStart,
                _timeFinish
            );

            // --- Empty state ---
            if (result.Items == null || !result.Items.Any())
            {
                Panel emptyPanel = new Panel
                {
                    Dock = DockStyle.Fill,
                    BackColor = Color.WhiteSmoke
                };

                int topMargin = 170; // keep your topMargin

                Label lblIcon = new Label
                {
                    Text = "📭",
                    Font = new Font("Segoe UI Emoji", 40),
                    Height = 100,
                    Width = historyPanel.ClientSize.Width,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Top = topMargin
                };
                emptyPanel.Controls.Add(lblIcon);

                Label lblEmpty = new Label
                {
                    Text = "No quiz history yet.\nTry taking a quiz to see it here!",
                    Font = new Font("Segoe UI", 11, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    Width = historyPanel.ClientSize.Width,
                    Height = historyPanel.ClientSize.Height - lblIcon.Bottom - 20,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Top = lblIcon.Bottom - 97
                };
                emptyPanel.Controls.Add(lblEmpty);

                flow.Controls.Add(emptyPanel);
                return 0;
            }

            // --- Render history items ---
            foreach (var h in result.Items)
            {
                var item = new Panel
                {
                    Width = flow.ClientSize.Width - 40,
                    Height = 70,
                    Margin = new Padding(5),
                    BackColor = Color.White,
                    Padding = new Padding(15),
                    BorderStyle = BorderStyle.None,
                    Cursor = Cursors.Hand
                };

                // Optional: rounded corners + shadow
                item.Paint += (s, e) =>
                {
                    var g = e.Graphics;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                    using (var shadow = new SolidBrush(Color.FromArgb(30, 0, 0, 0)))
                        g.FillRectangle(shadow, 2, 2, item.Width - 2, item.Height - 2);

                    using (var bg = new SolidBrush(Color.White))
                    using (var borderPen = new Pen(Color.LightGray))
                    {
                        var rect = new Rectangle(0, 0, item.Width - 4, item.Height - 4);
                        g.FillRoundedRectangle(bg, rect, 8);
                        g.DrawRoundedRectangle(borderPen, rect, 8);
                    }
                };

                // Labels
                Label lblDate = new Label
                {
                    Text = $"📅 {(h.IsFinish ? h.TimeFinish.ToString("yyyy-MM-dd HH:mm") : h.TimeStart.ToString("yyyy-MM-dd HH:mm"))}",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 9, FontStyle.Regular),
                    ForeColor = Color.DimGray,
                    Left = 10,
                    Top = 10
                };

                Label lblScore = new Label
                {
                    Text = $"⭐ Score: {h.TotalScore}",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    ForeColor = Color.FromArgb(0, 120, 215),
                    Left = 10,
                    Top = 35
                };

                Label lblStatus = new Label
                {
                    Text = h.IsFinish ? "✅ Finished" : "⏳ In Progress",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 9, FontStyle.Italic),
                    ForeColor = h.IsFinish ? Color.FromArgb(0, 200, 83) : Color.FromArgb(255, 193, 7),
                    Anchor = AnchorStyles.Top | AnchorStyles.Right,
                    Left = item.Width - (h.IsFinish ? 80 : 94),
                    Top = 25
                };

                item.Controls.Add(lblDate);
                item.Controls.Add(lblScore);
                item.Controls.Add(lblStatus);

                flow.Controls.Add(item);
            }

            return result.TotalPages;
        }

        private async Task<Control> CreateQuizCard(Quiz quiz)
        {
            // Main card panel
            var card = new Panel
            {
                Width = 180,
                Height = 240,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Margin = new Padding(8)
            };

            // Quiz image
            PictureBox pic = new PictureBox
            {
                Width = 160,
                Height = 110,
                SizeMode = PictureBoxSizeMode.Zoom,
                Top = 8,
                Left = 10
            };

            if (quiz.Image != null && quiz.Image.Length > 0)
            {
                using (var ms = new System.IO.MemoryStream(quiz.Image))
                {
                    pic.Image = Image.FromStream(ms);
                }
            }

            // Quiz name
            Label lblName = new Label
            {
                Text = quiz.Name,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = false,
                Width = 160,
                Height = 35,
                Top = 125,
                Left = 10,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // 🎨 Difficulty color
            Color diffColor;
            switch (quiz.Difficulty.Trim().ToLower())
            {
                case "easy":
                    diffColor = Color.FromArgb(0, 200, 83); // Green
                    break;
                case "medium":
                    diffColor = Color.FromArgb(255, 193, 7); // Amber
                    break;
                case "hard":
                    diffColor = Color.FromArgb(244, 67, 54); // Red
                    break;
                default:
                    diffColor = Color.Gray;
                    break;
            }

            // Difficulty label (smaller)
            Label lblDiff = new Label
            {
                Text = quiz.Difficulty.ToUpper(),
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                AutoSize = false,
                Width = 160,
                Height = 20,
                Top = 160,
                Left = 10,
                ForeColor = diffColor,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Check if user has done this quiz before
            var user = UserService.Instance.User;
            var histories = (await HistoryService.Instance.GetListHistoryByQuizIdAndUserId(
                quiz.Id, 
                user.Id, 
                1000, 
                1
            )).Items;
            var latestHistory = histories?.FirstOrDefault();

            string buttonText;
            Color buttonColor;

            // 🧠 Determine state
            if (latestHistory == null)
            {
                buttonText = "Enter";
                buttonColor = Color.DodgerBlue;
            }
            else if (latestHistory.IsFinish)
            {
                buttonText = "Try Again";
                buttonColor = Color.MediumSeaGreen;
            }
            else
            {
                buttonText = "Continue";
                buttonColor = Color.Orange;
            }

            // Button
            Button btnEnter = new Button
            {
                Text = buttonText,
                Width = 140,
                Height = 30,
                Top = 192,
                Left = 20,
                BackColor = buttonColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnEnter.FlatAppearance.BorderSize = 0;

            btnEnter.Click += async (s, e) =>
            {
                histories = (await HistoryService.Instance.GetListHistoryByQuizIdAndUserId(
                    quiz.Id,
                    user.Id,
                    1000,
                    1
                )).Items;
                latestHistory = histories?.FirstOrDefault();

                History historyToUse = null;

                if (latestHistory == null || latestHistory.IsFinish)
                {
                    // No history exists or previous quiz finished → create new history
                    historyToUse = new History
                    {
                        UserId = user.Id,
                        QuizId = quiz.Id,
                        TimeStart = DateTime.Now,
                        IsFinish = false,
                        TotalScore = 0
                    };

                    await HistoryService.Instance.CreateUserHistory(historyToUse);

                    // Immediately update button to "Continue"
                    btnEnter.Text = "Continue";
                    btnEnter.BackColor = Color.Orange;
                }
                else
                {
                    // Continue in-progress history
                    historyToUse = latestHistory;
                }

                UserQuiz quizForm = new UserQuiz(quiz.Id, historyToUse.Id, this);
                quizForm.ShowDialog();

                await HandleClickQuiz(quiz.Id);
            };

            // Add all controls
            card.Controls.Add(pic);
            card.Controls.Add(lblName);
            card.Controls.Add(lblDiff);
            card.Controls.Add(btnEnter);

            // ✅ Proper hover effect for entire card
            void SetHoverEffect(Control ctrl)
            {
                ctrl.MouseEnter += (s, e) => card.BackColor = Color.AliceBlue;
                ctrl.MouseLeave += (s, e) =>
                {
                    if (!card.ClientRectangle.Contains(card.PointToClient(Cursor.Position)))
                        card.BackColor = Color.White;
                };
            }

            SetHoverEffect(card);
            SetHoverEffect(pic);
            SetHoverEffect(lblName);
            SetHoverEffect(lblDiff);
            SetHoverEffect(btnEnter);

            pic.Click += async (s, e) => await HandleClickQuiz(quiz.Id);
            lblName.Click += async (s, e) => await HandleClickQuiz(quiz.Id);
            lblDiff.Click += async (s, e) => await HandleClickQuiz(quiz.Id);
            card.Click += async (s, e) => await HandleClickQuiz(quiz.Id);

            return card;
        }

        private async Task HandleClickQuiz(int quizId)
        {
            _currentPageHistory = 1; 
            await RenderHistoryPagination(quizId);
        }

        private async Task RenderHistoryPagination(int quizId)
        {
            _totalPagesHistory = await ShowHistoryAsync(quizId);

            LayoutForm.RenderPagination(
                paginatePanelHistory,
                _currentPageHistory,
                _totalPagesHistory,
                async (newPage) =>
                {
                    _currentPageHistory = newPage; 
                    await RenderHistoryPagination(quizId);
                }
            );
        }
        #endregion

        #region Events
        private async void load_Data(object sender, EventArgs e)
        {
            var quizTask = LoadQuiz();

            await Task.WhenAll(quizTask);

            var user = UserService.Instance.User;
            toolStripBtnDropdown.Text = user.Name;
        }

        private void toolStripAdminBtn_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin(this);

            admin.ShowDialog(); 
        }

        private void userProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserProfile userProfile = new UserProfile(this);
            userProfile.ShowDialog();
        }

        private void logoutToolStripItem_Click(object sender, EventArgs e)
        {
            UserService.Instance.User = null;
            LocalStorage.ClearUser();

            Hide();
            var login = new Login();
            login.ShowDialog();
            Close();
        }
        #endregion
    }
}
