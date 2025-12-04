using Lab_8.Models;
using Lab_8.Services;
using Lab_8.Utils;
using System;
using System.Collections.Generic;
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

        private readonly bool _isPlaceholderApplied = false;

        private bool _formReady = false;

        private readonly List<int> _categoryIds = new List<int>();    

        public Home()
        {
            InitializeComponent();
            ApplyRoleBase();
            StylePanels();
            UIStyle.ApplyPlaceholder(txbSearchQuiz, "Search quiz", ref _isPlaceholderApplied);
            Load += load_Data;
        }

        #region Methods
        private void ApplyRoleBase()
        {
            var role = UserService.Instance.User.Role;

            if (role == null) return;

            if (role.Name != "Admin" && role.Name != "Tester")
            {
                toolStripAdminBtn.Visible = false;
            }

            var permissionNames = role.RolePermissions
                .Select(rp => rp.Permission.Name)
                .ToList();
        }

        public async Task LoadFilter()
        {
            ShowFilterSkeleton();

            var result = await CategoryService.Instance.GetListCategory(100, 1, null);

            Helper.StopShimmerAnimation();

            if (result == null || result.Items == null) return;

            quizFilterPanel.Controls.Clear();
            quizFilterPanel.AutoScroll = true;
            quizFilterPanel.BackColor = Color.WhiteSmoke;

            // --- Add a title ---
            Label title = new Label
            {
                Text = "Categories",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 120, 215),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleLeft,
                Width = quizFilterPanel.Width - 40,
                Height = 40,
                Location = new Point(20, 10)
            };
            quizFilterPanel.Controls.Add(title);

            // --- Layout variables ---
            int xStart = 23;
            int y = 60; // start below title
            int spacingX = 30;
            int spacingY = 15;
            int col = 0;

            int cbWidth = (quizFilterPanel.Width - xStart * 2 - spacingX) / 2;
            int cbHeight = 50; // height for a checkbox

            foreach (var category in result.Items.Where(c => c.IsActive))
            {
                // Panel container
                Panel cbContainer = new Panel
                {
                    Width = cbWidth + 20,
                    Height = cbHeight,
                    Location = new Point(xStart + (cbWidth + spacingX) * col - 10, y),
                    BackColor = Color.White,
                };

                UIStyle.RoundPanel(cbContainer, 15);

                // Checkbox
                CheckBox cb = new CheckBox
                {
                    Text = category.Name,
                    Tag = category,
                    Font = new Font("Segoe UI", 10.8f, FontStyle.Regular),
                    AutoSize = true, // let Windows handle checkbox + text size
                    Location = new Point(5, (cbContainer.Height - 20) / 2 - 3), // vertically centered
                };

                // Hover effect on panel
                cbContainer.MouseEnter += (s, e) => cbContainer.BackColor = Color.AliceBlue;
                cbContainer.MouseLeave += (s, e) => cbContainer.BackColor = Color.White;

                cb.CheckedChanged += Checkbox_CheckedChanged;

                cbContainer.Controls.Add(cb);
                quizFilterPanel.Controls.Add(cbContainer);

                col++;
                if (col >= 2)
                {
                    col = 0;
                    y += cbHeight + spacingY;
                }
            }

            // --- Reset Categories Button ---
            Button btnResetCategories = new Button
            {
                Text = "Reset Categories",
                Width = cbWidth * 2 + spacingX, // span across two columns
                Height = 35,
                Top = 260, // some extra spacing
                Left = xStart,
                BackColor = Color.FromArgb(220, 53, 69), // Bootstrap-like red
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            UIStyle.ModernUIButton(btnResetCategories, Color.FromArgb(200, 35, 51), Color.FromArgb(220, 53, 69));

            // Click event: reset selected categories
            btnResetCategories.Click += async (s, e) =>
            {
                _categoryIds.Clear();

                // Temporarily remove CheckedChanged events
                foreach (Panel panel in quizFilterPanel.Controls.OfType<Panel>())
                {
                    if (panel.Controls[0] is CheckBox cbx)
                    {
                        cbx.CheckedChanged -= Checkbox_CheckedChanged; // detach handler
                        cbx.Checked = false;
                        cbx.CheckedChanged += Checkbox_CheckedChanged; // reattach handler
                    }
                }

                _currentPageQuiz = 1;
                await LoadQuiz();
            };
            quizFilterPanel.Controls.Add(btnResetCategories);
        }

        public async Task LoadQuiz()
        {
            ShowQuizSkeletonLoader(_pageSizeQuiz);

            var result = await QuizService.Instance.GetListQuiz(
                _pageSizeQuiz, 
                _currentPageQuiz,
                txbSearchQuiz.Text == "Search quiz" ? null : txbSearchQuiz.Text,
                _categoryIds);

            Helper.StopShimmerAnimation();

            flpQuiz.Controls.Clear();

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
            UIStyle.RoundPanel(searchQuizPanel, 15);
            UIStyle.RoundPanel(quizFilterPanel, 15);
        }

        public async Task<int> ShowHistoryAsync(int quizId)
        {
            var user = UserService.Instance.User;

            ShowHistorySkeleton(_pageSizeHistory);

            // --- Fetch filtered history ---
            var result = await HistoryService.Instance.GetListHistoryByQuizIdAndUserId(
                quizId,
                user.Id,
                _pageSizeHistory,
                _currentPageHistory,
                _timeStart,
                _timeFinish
            );

            Helper.StopShimmerAnimation();

            historyPanel.Controls.Clear();

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
                Margin = new Padding(0, 0, 0, 4)
            };

            DateTimePicker dtpStart = new DateTimePicker
            {
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "yyyy-MM-dd HH:mm",
                Width = (datePickerPanel.Width / 2) - 5,
                Location = new Point(0, 0)
            };
            dtpStart.CloseUp += async (s, e) =>
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
            dtpFinish.CloseUp += async (s, e) =>
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
                Margin = new Padding(0)
            };

            Button btnReset = new Button
            {
                Text = "Reset Filter",
                Width = 80,
                Height = 26,
                BackColor = Color.FromArgb(220, 53, 69), // Bootstrap-style red
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 8.3f, FontStyle.Bold),
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };

            // Rounded edges
            btnReset.FlatAppearance.BorderSize = 0;

            // Hover effect: slightly darker red
            btnReset.MouseEnter += (s, e) => btnReset.BackColor = Color.FromArgb(200, 35, 51);
            btnReset.MouseLeave += (s, e) => btnReset.BackColor = Color.FromArgb(220, 53, 69);

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


            // --- Empty state ---
            if (result.Items == null || !result.Items.Any())
            {
                Panel emptyPanel = new Panel
                {
                    Width = flow.ClientSize.Width - 30,
                    Height = 300, // set a reasonable height
                    BackColor = Color.WhiteSmoke
                };

                Label lblIcon = new Label
                {
                    Text = "📭",
                    Font = new Font("Segoe UI Emoji", 40),
                    Width = emptyPanel.Width,
                    Height = 70,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Top = 110
                };

                Label lblEmpty = new Label
                {
                    Text = "No quiz history yet.\nTry taking a quiz to see it here!",
                    Font = new Font("Segoe UI", 11, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    Width = emptyPanel.Width,
                    Height = 60,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Top = lblIcon.Bottom
                };

                emptyPanel.Controls.Add(lblIcon);
                emptyPanel.Controls.Add(lblEmpty);

                flow.Controls.Add(emptyPanel);
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

                item.Click += (s, e) =>
                {
                    if (!h.IsFinish) return;

                    UserQuiz quizForm = new UserQuiz(quizId, h.Id, this, true); // history mode
                    quizForm.ShowDialog();                 
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

                var quiz = await QuizService.Instance.GetQuizById(quizId);
                var userAnswers = await UserService.Instance.GetUserAnswersByHistory(h.Id);

                // Count correct answers
                int correctCount = 0;
                int totalCount = 0; 

                if (h.IsFinish)
                {
                    foreach (var question in quiz.Questions)
                    {
                        var correctAnswer = question.Answers?.FirstOrDefault(a => a.IsCorrect);

                        if (correctAnswer == null)
                            continue;

                        totalCount++; 

                        // Get user's answer
                        var userAnswer = userAnswers
                            .FirstOrDefault(ua => ua.Answer != null && ua.Answer.QuestionId == question.Id)
                            ?.Answer;

                        if (userAnswer != null && userAnswer.Id == correctAnswer.Id)
                            correctCount++;
                    }
                }

                // Calculate percentage
                double percentage = totalCount > 0 ? (double)correctCount / totalCount * 100 : 0;

                // Create label
                Label lblScore = new Label
                {
                    Text = $"⭐ Score: {Math.Round(percentage, 2)}%",
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
                        IsFinish = false
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

        private void ShowHistorySkeleton(int count = 5)
        {
            historyPanel.Controls.Clear();

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

            // Flow container
            FlowLayoutPanel flow = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(15, 45, 15, 15),
                BackColor = Color.WhiteSmoke
            };
            historyPanel.Controls.Add(flow);

            // Skeleton rows
            for (int i = 0; i < count; i++)
            {
                Panel skel = new Panel
                {
                    Width = flow.ClientSize.Width - 40,
                    Height = 70,
                    BackColor = Color.Gainsboro,
                    Margin = new Padding(5)
                };

                Panel line1 = new Panel
                {
                    Width = skel.Width - 40,
                    Height = 15,
                    Top = 10,
                    Left = 20,
                    BackColor = Color.LightGray
                };

                Panel line2 = new Panel
                {
                    Width = skel.Width - 100,
                    Height = 15,
                    Top = 40,
                    Left = 20,
                    BackColor = Color.LightGray
                };

                skel.Controls.Add(line1);
                skel.Controls.Add(line2);
                flow.Controls.Add(skel);
            }

            // Start shimmer effect (reuse same method)
            Helper.StartShimmerAnimation(flow);
        }

        private void ShowQuizSkeletonLoader(int count = 6)
        {
            flpQuiz.Controls.Clear();

            for (int i = 0; i < count; i++)
            {
                Panel skeletonCard = new Panel
                {
                    Width = 180,
                    Height = 240,
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.Gainsboro,
                    Margin = new Padding(8)
                };

                // Image placeholder
                Panel imgPlaceholder = new Panel
                {
                    Width = 160,
                    Height = 110,
                    Top = 8,
                    Left = 10,
                    BackColor = Color.LightGray
                };
                skeletonCard.Controls.Add(imgPlaceholder);

                // Name placeholder
                Panel namePlaceholder = new Panel
                {
                    Width = 160,
                    Height = 20,
                    Top = 125,
                    Left = 10,
                    BackColor = Color.LightGray
                };
                skeletonCard.Controls.Add(namePlaceholder);

                // Difficulty placeholder
                Panel diffPlaceholder = new Panel
                {
                    Width = 160,
                    Height = 20,
                    Top = 160,
                    Left = 10,
                    BackColor = Color.LightGray
                };
                skeletonCard.Controls.Add(diffPlaceholder);

                // Button placeholder
                Panel btnPlaceholder = new Panel
                {
                    Width = 140,
                    Height = 30,
                    Top = 192,
                    Left = 20,
                    BackColor = Color.Gray
                };
                skeletonCard.Controls.Add(btnPlaceholder);

                flpQuiz.Controls.Add(skeletonCard);
            }

            // Optional: start shimmer animation
            Helper.StartShimmerAnimation(flpQuiz);
        }

        private void ShowFilterSkeleton()
        {
            quizFilterPanel.Controls.Clear();
            quizFilterPanel.AutoScroll = true;
            quizFilterPanel.BackColor = Color.WhiteSmoke;

            // --- Title skeleton ---
            Panel titleSkel = new Panel
            {
                Width = quizFilterPanel.Width - 40,
                Height = 40,
                Location = new Point(20, 10),
                BackColor = Color.Gainsboro
            };
            quizFilterPanel.Controls.Add(titleSkel);

            // --- Checkbox skeletons (2 columns × 4 rows = 8 placeholders) ---
            int xStart = 23;
            int y = 80;
            int spacingX = 30;
            int spacingY = 15;
            int col = 0;

            int cbWidth = (quizFilterPanel.Width - xStart * 2 - spacingX) / 2;
            int cbHeight = 50;

            for (int i = 0; i < 8; i++)
            {
                Panel cbSkeleton = new Panel
                {
                    Width = cbWidth + 20,
                    Height = cbHeight,
                    Location = new Point(xStart + (cbWidth + spacingX) * col - 10, y),
                    BackColor = Color.Gainsboro
                };

                // Placeholder inner bar
                Panel bar = new Panel
                {
                    Width = cbWidth - 20,
                    Height = 12,
                    Left = 20,
                    Top = (cbHeight - 12) / 2,
                    BackColor = Color.LightGray
                };
                cbSkeleton.Controls.Add(bar);

                quizFilterPanel.Controls.Add(cbSkeleton);

                col++;
                if (col >= 2)
                {
                    col = 0;
                    y += cbHeight + spacingY;
                }
            }

            // --- Reset button placeholder ---
            Panel resetBtnSkel = new Panel
            {
                Width = cbWidth * 2 + spacingX,
                Height = 35,
                Location = new Point(xStart, y + 20),
                BackColor = Color.Silver
            };
            quizFilterPanel.Controls.Add(resetBtnSkel);

            // Start shimmer
            Helper.StartShimmerAnimation(quizFilterPanel);
        }
        #endregion

        #region Events
        private async void load_Data(object sender, EventArgs e)
        {
            var user = UserService.Instance.User;
            toolStripBtnDropdown.Text = user.Name;

            var role = user.Role;
            var permissionNames = role?.RolePermissions.Select(rp => rp.Permission.Name).ToList() ?? new List<string>();

            if (permissionNames.Contains("View Quiz"))
            {
                await LoadQuiz();
                _formReady = true;

                await LoadFilter();
            }

            var firstHistoryId = await HistoryService.Instance.GetFirstHistoryId();
            await RenderHistoryPagination(firstHistoryId);
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

        private async void txbSearchQuiz_TextChanged(object sender, EventArgs e)
        {
            if (!_formReady) return;

            await LoadQuiz();
        }

        private async void Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender is CheckBox cb)) return;

            var id = (cb.Tag as Category).Id;
            if (cb.Checked)
            {
                if (!_categoryIds.Contains(id))
                    _categoryIds.Add(id);
            }
            else
            {
                _categoryIds.Remove(id);
            }

            _currentPageQuiz = 1;
            await LoadQuiz();
        }
        #endregion
    }
}
