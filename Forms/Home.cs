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
        private int _currentPage = 1;
        private readonly int _pageSize = 6;
        private int _totalPages = 1;

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

            var result = await QuizService.Instance.GetListQuiz(_pageSize, _currentPage, null);
            if (result == null || !result.Items.Any()) return;

            _totalPages = result.TotalPages;

            foreach (var quiz in result.Items)
            {
                var card = await CreateQuizCard(quiz);
                flpQuiz.Controls.Add(card);
            }

            LayoutForm.RenderPagination(
                paginatePanel,
                _currentPage,
                _totalPages,
                async (newPage) =>
                {
                    _currentPage = newPage;
                    await LoadQuiz();
                }
            );
        }

        private void StylePanels()
        {
            UIStyle.RoundPanel(paginatePanel, 15);
            UIStyle.RoundPanel(historyPanel, 15);
            UIStyle.RoundPanel(flpQuiz, 15);
        }

        public async Task ShowHistoryAsync(int quizId)
        {
            historyPanel.Controls.Clear();

            var user = UserService.Instance.User;
            var histories = await HistoryService.Instance.GetListHistoryByQuizIdAndUserId(quizId, user.Id);

            // create a scrollable container for history items
            FlowLayoutPanel flow = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(10)
            };
            historyPanel.Controls.Add(flow);

            if (histories == null || !histories.Any())
            {
                Label lblNoHistory = new Label
                {
                    Text = "No history found for this quiz.",
                    Dock = DockStyle.Top,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 10, FontStyle.Italic),
                    ForeColor = Color.Gray
                };
                flow.Controls.Add(lblNoHistory);
                return;
            }

            foreach (var h in histories.OrderByDescending(h => h.TimeFinish))
            {
                var item = new Panel
                {
                    Width = flow.Width - 26,
                    Height = 65,
                    Margin = new Padding(3),
                    BackColor = Color.WhiteSmoke,
                    BorderStyle = BorderStyle.FixedSingle
                };

                Label lblDate = new Label
                {
                    Text = $"📅 Date: {(h.IsFinish ? h.TimeFinish.ToString("yyyy-MM-dd HH:mm") : h.TimeStart.ToString("yyyy-MM-dd HH:mm"))}",
                    Left = 10,
                    Top = 13,
                    AutoSize = true,
                    Font = new Font("Segoe UI", 9, FontStyle.Regular)
                };

                Label lblScore = new Label
                {
                    Text = $"⭐ Score: {h.TotalScore}",
                    Left = 10,
                    Top = 36,
                    AutoSize = true,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold)
                };

                Label lblStatus = new Label
                {
                    Text = h.IsFinish ? "✅ Finished" : "⏳ In Progress",
                    AutoSize = true,
                    Left =  item.Width - ( h.IsFinish ? 78 : 91 ),
                    Top = 24,
                    Font = new Font("Segoe UI", 9, FontStyle.Italic),
                    ForeColor = h.IsFinish ? Color.FromArgb(0, 200, 83) : Color.FromArgb(255, 193, 7)
                };

                item.Controls.Add(lblDate);
                item.Controls.Add(lblScore);
                item.Controls.Add(lblStatus);

                flow.Controls.Add(item);
            }
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
                Text = $"Difficulty: {quiz.Difficulty}",
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
            var histories = await HistoryService.Instance.GetListHistoryByQuizIdAndUserId(quiz.Id, user.Id);
            var latestHistory = histories?
                .OrderByDescending(h => h.IsFinish ? h.TimeFinish : h.TimeStart)
                .FirstOrDefault();

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
                histories = await HistoryService.Instance.GetListHistoryByQuizIdAndUserId(quiz.Id, user.Id);
                latestHistory = histories?
                   .OrderByDescending(h => h.IsFinish ? h.TimeFinish : h.TimeStart)
                   .FirstOrDefault();

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

                _ = ShowHistoryAsync(quiz.Id);
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

            pic.Click += async (s, e) => await ShowHistoryAsync(quiz.Id);
            lblName.Click += async (s, e) => await ShowHistoryAsync(quiz.Id);
            lblDiff.Click += async (s, e) => await ShowHistoryAsync(quiz.Id);
            card.Click += async (s, e) => await ShowHistoryAsync(quiz.Id);

            return card;
        }
        #endregion

        #region Events
        private async void load_Data(object sender, EventArgs e)
        {
            var quizTask = LoadQuiz();

            await Task.WhenAll(quizTask);
        }

        private void toolStripAdminBtn_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin(this);

            admin.ShowDialog(); 
        }
        #endregion
    }
}
