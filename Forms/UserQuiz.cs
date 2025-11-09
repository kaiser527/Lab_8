using Lab_8.Forms;
using Lab_8.Models;
using Lab_8.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_8
{
    public partial class UserQuiz : Form
    {
        private readonly Home _home;

        private readonly int _quizId;
        private readonly int _historyId;

        private Quiz _quiz;
        private int _currentQuestionIndex = 0;

        private readonly Dictionary<int, Answer> _userSelectedAnswers = new Dictionary<int, Answer>();

        private Timer _timer;
        private TimeSpan _remainingTime;
        private readonly int _quizDurationMinutes = 1;

        public UserQuiz(int quizId, int historyId, Home home)
        {
            InitializeComponent();
            _quizId = quizId;
            _historyId = historyId;
            Load += UserQuiz_Load;
            _home = home;
        }

        #region Methods
        private async Task SubmitQuiz()
        {
            var checkedAnswers = _userSelectedAnswers.Values.ToList();

            await HistoryService.Instance.SubmitQuizHistory(new History
            {
                Id = _historyId,
                QuizId = _quizId
            }, checkedAnswers);

            await _home.LoadQuiz();
            await _home.ShowHistoryAsync(_quizId);

            Close();
        }

        private async Task LoadQuiz()
        {
            _quiz = await QuizService.Instance.GetQuizById(_quizId);
            if (_quiz == null) return;

            quizNameLabel.Text = _quiz.Name;

            // ListView setup - tighter spacing
            listViewQuestion.View = View.Tile;
            listViewQuestion.TileSize = new Size(200, 35); // reduced height
            listViewQuestion.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            listViewQuestion.FullRowSelect = true;
            listViewQuestion.MultiSelect = false;
            listViewQuestion.Items.Clear();

            for (int i = 0; i < _quiz.Questions.Count; i++)
            {
                listViewQuestion.Items.Add($"Question {i + 1}");
            }

            listViewQuestion.SelectedIndexChanged += ListViewQuestion_SelectedIndexChanged;

            if (_quiz.Questions.Any())
            {
                listViewQuestion.Items[0].Selected = true;
            }
        }

        private async Task DisplayQuestion(int index)
        {
            QuestionAnswerGroupbox.Controls.Clear();

            if (_quiz?.Questions == null || index < 0 || index >= _quiz.Questions.Count) return;

            var question = _quiz.Questions.ElementAt(index);

            // Question title
            Label lblTitle = new Label
            {
                Text = question.Name,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                AutoSize = true,
                MaximumSize = new Size(QuestionAnswerGroupbox.Width - 40, 0),
                Location = new Point(20, 20),
                TextAlign = ContentAlignment.TopLeft
            };
            QuestionAnswerGroupbox.Controls.Add(lblTitle);

            int y = lblTitle.Bottom + 20;
            var userId = UserService.Instance.User.Id;

            // Get all existing answers for this history
            var userAnswers = await UserService.Instance.GetUserAnswersByHistory(_historyId);

            foreach (var answer in question.Answers)
            {
                RadioButton rb = new RadioButton
                {
                    Text = answer.Name,
                    Font = new Font("Segoe UI", 12),
                    AutoSize = true,
                    Location = new Point(40, y),
                    Tag = answer
                };

                // Pre-check if this question has an existing answer
                var existingAnswer = userAnswers
                    .FirstOrDefault(ua => ua.Answer != null && ua.Answer.QuestionId == question.Id);

                if (existingAnswer != null && existingAnswer.AnswerId == answer.Id)
                {
                    rb.Checked = true;
                }

                rb.CheckedChanged += async (s, e) =>
                {
                    if (!rb.Checked) return;

                    var selectedAnswer = (Answer)rb.Tag;

                    // Update local dictionary
                    _userSelectedAnswers[selectedAnswer.QuestionId] = selectedAnswer;

                    await UserService.Instance.SaveUserAnswerEachCheck(new UserAnswer
                    {
                        UserId = userId,
                        HistoryId = _historyId,
                        AnswerId = answer.Id
                    });

                    // Update local cache to reflect selection
                    if (existingAnswer != null)
                    {
                        existingAnswer.AnswerId = answer.Id;
                    }
                    else
                    {
                        userAnswers.Add(new UserAnswer
                        {
                            UserId = userId,
                            HistoryId = _historyId,
                            AnswerId = answer.Id
                        });
                    }
                };

                QuestionAnswerGroupbox.Controls.Add(rb);
                y += 35;
            }

            // --- Navigation buttons ---
            int buttonWidth = 95;
            int buttonHeight = 35;
            int buttonTop = QuestionAnswerGroupbox.Height - buttonHeight - 10;
            int spacing = 20;
            int leftPrev = 40;
            int leftNext = leftPrev + buttonWidth + spacing;
            int leftFinish = leftNext + buttonWidth + spacing;

            Action<Button> styleButton = btn =>
            {
                btn.BackColor = Color.LightGray;
                btn.ForeColor = Color.Black;
                btn.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
            };

            // Previous button
            Button btnPrev = new Button
            {
                Text = "Previous",
                Width = buttonWidth,
                Height = buttonHeight,
                Location = new Point(leftPrev, buttonTop),
                Enabled = index > 0
            };
            styleButton(btnPrev);
            btnPrev.Click += (s, e) =>
            {
                if (_currentQuestionIndex > 0)
                {
                    _currentQuestionIndex--;
                    listViewQuestion.Items[_currentQuestionIndex].Selected = true;
                }
            };
            QuestionAnswerGroupbox.Controls.Add(btnPrev);

            // Next button
            Button btnNext = new Button
            {
                Text = "Next",
                Width = buttonWidth,
                Height = buttonHeight,
                Location = new Point(leftNext, buttonTop),
                Enabled = index < _quiz.Questions.Count - 1
            };
            styleButton(btnNext);
            btnNext.Click += (s, e) =>
            {
                if (_currentQuestionIndex < _quiz.Questions.Count - 1)
                {
                    _currentQuestionIndex++;
                    listViewQuestion.Items[_currentQuestionIndex].Selected = true;
                }
            };
            QuestionAnswerGroupbox.Controls.Add(btnNext);

            // Finish button
            Button btnFinish = new Button
            {
                Text = "Finish",
                Width = buttonWidth,
                Height = buttonHeight,
                Location = new Point(leftFinish, buttonTop)
            };
            styleButton(btnFinish);
            btnFinish.Click += async (s, e) =>
            {
                MessageBox.Show("Quiz submitted successfully!");

                await SubmitQuiz();
            };
            QuestionAnswerGroupbox.Controls.Add(btnFinish);
        }

        private void UpdateProgressBar(int index)
        {
            if (_quiz.Questions.Count == 0) return;
            int progress = (int)(((index + 1) / (float)_quiz.Questions.Count) * 100);
            progressBar1.Value = progress;
        }
        #endregion

        #region Events
        private async void ListViewQuestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewQuestion.SelectedIndices.Count == 0) return;

            _currentQuestionIndex = listViewQuestion.SelectedIndices[0];
            await DisplayQuestion(_currentQuestionIndex);
            UpdateProgressBar(_currentQuestionIndex);
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            _remainingTime = _remainingTime.Subtract(TimeSpan.FromSeconds(1));
            timeLabel.Text = _remainingTime.ToString(@"mm\:ss");

            if (_remainingTime <= TimeSpan.Zero)
            {
                _timer.Stop();
                MessageBox.Show("Time is up! The quiz will be submitted automatically.");

                await SubmitQuiz();
            }
        }

        private async void UserQuiz_Load(object sender, EventArgs e)
        {
            await LoadQuiz();

            // Initialize countdown timer
            _remainingTime = TimeSpan.FromMinutes(_quizDurationMinutes);
            timeLabel.Text = _remainingTime.ToString(@"mm\:ss");

            _timer = new Timer
            {
                Interval = 1000 // 1 second
            };
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }
        #endregion
    }
}
