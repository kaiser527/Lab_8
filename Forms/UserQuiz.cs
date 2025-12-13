using Lab_8.Forms;
using Lab_8.Models;
using Lab_8.Services;
using Lab_8.Utils;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormApp.Forms;

namespace Lab_8
{
    public partial class UserQuiz : Form
    {
        private readonly Home _home;

        private readonly int _quizId;
        private readonly int _historyId;
        private readonly string _category;

        private Quiz _quiz;
        private int _currentQuestionIndex = 0;
        private readonly Dictionary<int, Answer> _userSelectedAnswers = new Dictionary<int, Answer>();
        private bool _isQuizFinished = false;
        private readonly bool _isHistoryView;
        private Question _currentQuestion;

        private int _remainingSeconds;
        private Timer _timer;   

        public UserQuiz(int quizId, int historyId, string category, int remainingSeconds, Home home, bool isHistoryView = false)
        {
            InitializeComponent();
            _quizId = quizId;
            _historyId = historyId;
            _isHistoryView = isHistoryView;
            _home = home;
            _category = category;
            _remainingSeconds = remainingSeconds;
            StylePanels();

            Load += UserQuiz_Load;

            FormClosing += (s, e) => 
            {
                Helper.StopAudio(_currentQuestion);

                if (_timer != null)
                {
                    _timer.Stop();
                    _timer.Dispose();
                    _timer = null;
                }
            };
        }

        private void StylePanels()
        {
            UIStyle.RoundPanel(leftPanel, 15);
            UIStyle.RoundPanel(rightPanel, 15);
        }

        #region Load Quiz
        private async Task LoadQuiz()
        {
            ShowSkeletonLoading();

            _quiz = await QuizService.Instance.GetQuizById(_quizId);

            if (_category == "Reading")
            {
                CreateReadingPanel(_quiz.Text);
            }

            Helper.StopShimmerAnimation();

            flpQuestion.Controls.Clear();

            if (_quiz == null) return;

            quizNameLabel.Text = _quiz.Name;

            if (!_isHistoryView)
            {
                StartCountdown();
            }
            else
            {
                timeLabel.Visible = false;
            }

            flpQuestion.AutoScroll = true;
            flpQuestion.WrapContents = true;
            flpQuestion.FlowDirection = FlowDirection.LeftToRight;

            // Load user answers if viewing history
            if (_isHistoryView)
            {
                await LoadUserAnswer();
            }

            // Create question buttons
            int buttonSize = 62;
            for (int i = 0; i < _quiz.Questions.Count; i++)
            {
                int index = i;
                Button btn = new Button
                {
                    Text = (i + 1).ToString(),
                    Width = buttonSize,
                    Height = buttonSize,
                    Margin = new Padding(8),
                    Font = new Font("Segoe UI", 14, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.LightGray,
                    Tag = index
                };
                btn.FlatAppearance.BorderSize = 0;
                btn.Click += (s, e) =>
                {
                    _currentQuestionIndex = (int)((Button)s).Tag;
                    DisplayQuestion(_currentQuestionIndex);
                    UpdateProgressBar(_currentQuestionIndex);
                    HighlightCurrentQuestionButton();
                };
                flpQuestion.Controls.Add(btn);
            }

            HighlightCurrentQuestionButton();

            if (_quiz.Questions.Any())
            {
                DisplayQuestion(0);
                UpdateProgressBar(0);
            }
        }
        #endregion

        #region Timer
        private void StartCountdown()
        {
            timeLabel.Text = TimeSpan.FromSeconds(_remainingSeconds).ToString(@"mm\:ss");

            _timer = new Timer
            {
                Interval = 1000
            };
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            if (_remainingSeconds <= 0)
            {
                await SubmitQuiz(true);
                return;
            }

            _remainingSeconds--;

            timeLabel.Text = TimeSpan.FromSeconds(_remainingSeconds).ToString(@"mm\:ss");

            await HistoryService.Instance.UpdateRemainingTime(_historyId, _remainingSeconds);
        }
        #endregion

        #region Submit Quiz
        private async Task SubmitQuiz(bool isTimeUp)
        {
            if (_isQuizFinished) return;
            _isQuizFinished = true;

            if (_timer != null)
            {
                _timer.Stop();
                _timer.Dispose();
                _timer = null;
            }

            if (_currentQuestion != null) Helper.StopAudio(_currentQuestion);

            // Refresh UI first
            HighlightCurrentQuestionButton();
            DisplayQuestion(_currentQuestionIndex);

            // Batch save all answers to DB
            foreach (var ua in _userSelectedAnswers)
            {
                await UserService.Instance.SaveUserAnswerEachCheck(new UserAnswer
                {
                    UserId = UserService.Instance.User.Id,
                    HistoryId = _historyId,
                    AnswerId = ua.Value.Id
                });
            }

            int correctCount = 0;
            int totalCount = 0;

            foreach (Control control in flpQuestion.Controls)
            {
                if (control is Button btn)
                {
                    int indexQ = (int)btn.Tag;
                    var question = _quiz.Questions.ToList()[indexQ];

                    var correctAnswer = question.Answers?.FirstOrDefault(a => a.IsCorrect);

                    if (correctAnswer == null)
                    {
                        btn.BackColor = Color.Gray;
                        btn.ForeColor = Color.White;
                        continue;
                    }

                    totalCount++;

                    _userSelectedAnswers.TryGetValue(question.Id, out var userAnswer);

                    if (userAnswer != null && userAnswer.Id == correctAnswer.Id)
                    {
                        btn.BackColor = Color.LimeGreen;
                        correctCount++;
                    }
                    else
                    {
                        btn.BackColor = Color.Red;
                    }

                    btn.ForeColor = Color.White;
                }
            }

            await HistoryService.Instance.SubmitQuizHistory(new History
            {
                Id = _historyId,
                QuizId = _quizId
            });

            double scorePercentage = totalCount > 0 ? (double)correctCount / totalCount * 100 : 0;
            bool confirm = Confirmation.ShowConfirm(
                isTimeUp ? "Time's Up!" : "Quiz Completed",
                $"Your final score is {Math.Round(scorePercentage, 2)}%. Do you want to close the quiz?");

            if (confirm) Close();

            await _home.LoadQuiz();
            await _home.ShowHistoryAsync(_quizId);
        }
        #endregion

        #region Highlight Question Button
        private void HighlightCurrentQuestionButton()
        {
            foreach (Control control in flpQuestion.Controls)
            {
                if (control is Button btn)
                {
                    int index = (int)btn.Tag;
                    var question = _quiz.Questions.ToList()[index];

                    // ===== FINISHED or HISTORY VIEW =====
                    if (_isQuizFinished || _isHistoryView)
                    {
                        var correctAnswer = question.Answers.FirstOrDefault(a => a.IsCorrect);
                        _userSelectedAnswers.TryGetValue(question.Id, out var userAnswer);

                        if (correctAnswer == null)
                        {
                            btn.BackColor = Color.Gray;
                        }
                        else if (userAnswer != null && userAnswer.Id == correctAnswer.Id)
                        {
                            btn.BackColor = Color.LimeGreen;
                        }
                        else
                        {
                            btn.BackColor = Color.Red;
                        }

                        btn.ForeColor = Color.White;
                        btn.FlatAppearance.BorderSize = index == _currentQuestionIndex ? 2 : 0;
                        btn.FlatAppearance.BorderColor = Color.Black;
                        continue;
                    }

                    // ===== DURING QUIZ =====
                    bool isAnswered = _userSelectedAnswers.ContainsKey(question.Id);

                    if (index == _currentQuestionIndex)
                    {
                        btn.BackColor = Color.DodgerBlue;
                        btn.ForeColor = Color.White;
                        btn.Font = new Font("Segoe UI", 16, FontStyle.Bold);
                    }
                    else if (isAnswered)
                    {
                        btn.BackColor = Color.Orange;   
                        btn.ForeColor = Color.White;
                        btn.Font = new Font("Segoe UI", 14, FontStyle.Bold);
                    }
                    else
                    {
                        btn.BackColor = Color.LightGray;
                        btn.ForeColor = Color.Black;
                        btn.Font = new Font("Segoe UI", 14, FontStyle.Bold);
                    }
                }
            }
        }
        #endregion

        #region Display Question
        private void DisplayQuestion(int index)
        {
            if (_category != "Reading")
                questionsPanel.Controls.Clear();
            else
            {
                // Clear all except reading panel
                for (int i = questionsPanel.Controls.Count - 1; i >= 0; i--)
                {
                    if (questionsPanel.Controls[i] != readingPanel)
                        questionsPanel.Controls.RemoveAt(i);
                }
            }
            if (_quiz?.Questions == null || index < 0 || index >= _quiz.Questions.Count)
                return;

            var question = _quiz.Questions.ToList()[index];
            int y = (_category == "Reading") ? 222 : 15;
            int marginLeft = 15;
            bool readOnly = _isHistoryView || _isQuizFinished;

            // Image
            if (question.Image != null && question.Image.Length > 0)
            {
                PictureBox pic = new PictureBox
                {
                    Image = Helper.ByteArrayToImage(question.Image),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Location = new Point(marginLeft, y),
                    Width = questionsPanel.Width - 2 * marginLeft,
                    Height = 165,
                    BorderStyle = BorderStyle.FixedSingle
                };
                questionsPanel.Controls.Add(pic);
                y += pic.Height + 10;
            }

            // Question title
            Label lblTitle = new Label
            {
                Text = question.Name,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                AutoSize = true,
                MaximumSize = new Size(questionsPanel.Width - 2 * marginLeft, 0),
                Location = new Point(marginLeft, y)
            };
            questionsPanel.Controls.Add(lblTitle);
            y += lblTitle.Height + 10;

            // Audio
            if (question.Audio != null && question.Audio.Length > 0)
            {
                Button btnPlayPause = new Button
                {
                    Width = 100,
                    Height = 30,
                    Location = new Point(marginLeft, y),
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Enabled = !readOnly
                };

                if (question.WaveOut != null && question.WaveOut.PlaybackState == PlaybackState.Playing)
                    btnPlayPause.Text = "⏸";
                else
                    btnPlayPause.Text = "▶";

                btnPlayPause.Click += (s, e) =>
                {
                    _currentQuestion = question;

                    if (question.WaveOut != null && question.WaveOut.PlaybackState == PlaybackState.Playing)
                    {
                        Helper.PauseAudio(question);
                        btnPlayPause.Text = "▶";
                    }
                    else
                    {
                        Helper.PlayAudio(question, btnPlayPause);
                        btnPlayPause.Text = "⏸";
                    }
                };

                questionsPanel.Controls.Add(btnPlayPause);
                y += btnPlayPause.Height + 10;
            }

            // Display answers
            foreach (var answer in question.Answers)
            {
                RadioButton rb = new RadioButton
                {
                    Text = answer.Name,
                    Font = new Font("Segoe UI", 12),
                    AutoSize = true,
                    Location = new Point(marginLeft + 20, y),
                    Tag = answer,
                    Enabled = !readOnly
                };

                if (_userSelectedAnswers.TryGetValue(question.Id, out var selected) && selected.Id == answer.Id)
                    rb.Checked = true;

                rb.CheckedChanged += async (s, e) =>
                {
                    if (!rb.Checked || readOnly) return;

                    var selectedAnswer = (Answer)rb.Tag;
                    _userSelectedAnswers[selectedAnswer.QuestionId] = selectedAnswer;

                    await UserService.Instance.SaveUserAnswerEachCheck(new UserAnswer
                    {
                        UserId = UserService.Instance.User.Id,
                        HistoryId = _historyId,
                        AnswerId = selectedAnswer.Id
                    });

                    HighlightCurrentQuestionButton();
                };

                questionsPanel.Controls.Add(rb);
                y += 35;
            }

            AddNavigationButtons(index);

            if (readOnly) ShowCorrectAnswer(question);
        }
        #endregion

        #region Load User Answer
        private async Task LoadUserAnswer()
        {
            var allUserAnswers = await UserService.Instance.GetUserAnswersByHistory(_historyId);
            foreach (var ua in allUserAnswers)
            {
                var question = _quiz.Questions.FirstOrDefault(q => q.Id == ua.Answer.QuestionId);
                if (question != null)
                {
                    var answer = question.Answers.FirstOrDefault(a => a.Id == ua.AnswerId);
                    if (answer != null)
                        _userSelectedAnswers[question.Id] = answer;
                }
            }
        }
        #endregion

        #region Navigation Buttons
        private void AddNavigationButtons(int index)
        {
            int buttonWidth = 95;
            int buttonHeight = 35;
            int buttonTop = questionsPanel.Height - buttonHeight - 10;
            int spacing = 20;
            int leftPrev = 40;
            int leftNext = leftPrev + buttonWidth + spacing;
            int leftFinish = leftNext + buttonWidth + spacing;

            void styleButton(Button btn)
            {
                btn.BackColor = Color.LightGray;
                btn.ForeColor = Color.Black;
                btn.Font = new Font("Microsoft Sans Serif", 10.8F);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
            }

            // Previous
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
                    HighlightCurrentQuestionButton();
                    DisplayQuestion(_currentQuestionIndex);
                    UpdateProgressBar(_currentQuestionIndex);
                }
            };
            questionsPanel.Controls.Add(btnPrev);

            // Next
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
                    DisplayQuestion(_currentQuestionIndex);
                    UpdateProgressBar(_currentQuestionIndex);
                }
            };
            questionsPanel.Controls.Add(btnNext);

            // Finish
            Button btnFinish = new Button
            {
                Text = "Finish",
                Width = buttonWidth,
                Height = buttonHeight,
                Location = new Point(leftFinish, buttonTop),
                Visible = !_isHistoryView,
                Enabled = !_isQuizFinished
            };
            styleButton(btnFinish);

            btnFinish.Click += async (s, e) => await SubmitQuiz(false);

            questionsPanel.Controls.Add(btnFinish);

            HighlightCurrentQuestionButton();
        }
        #endregion

        #region Show Correct Answer
        private void ShowCorrectAnswer(Question question)
        {
            var correct = question.Answers.FirstOrDefault(a => a.IsCorrect);
            foreach (Control ctrl in questionsPanel.Controls)
            {
                if (ctrl is RadioButton rb)
                {
                    var ans = (Answer)rb.Tag;
                    if (ans.Id == correct?.Id)
                    {
                        rb.BackColor = Color.LightGreen;
                        rb.ForeColor = Color.Black;
                    }
                    else
                    {
                        rb.BackColor = Color.White;
                        rb.ForeColor = Color.Black;
                    }

                    // If wrong was chosen, mark it red
                    if (_userSelectedAnswers.TryGetValue(question.Id, out var selected) &&
                        selected.Id == ans.Id && ans.Id != correct?.Id)
                    {
                        rb.BackColor = Color.LightCoral;
                        rb.ForeColor = Color.White;
                    }
                }
            }
        }
        #endregion

        #region Progress Bar
        private void UpdateProgressBar(int index)
        {
            if (_quiz.Questions.Count == 0) return;
            int progress = (int)((index + 1) / (float)_quiz.Questions.Count * 100);
            progressBar1.Value = progress;
        }
        #endregion

        #region Form Load
        private async void UserQuiz_Load(object sender, EventArgs e)
        {
            ShowQuestionSkeleton();
            await LoadQuiz();
            await LoadUserAnswer();
            DisplayQuestion(_currentQuestionIndex);
            HighlightCurrentQuestionButton();
        }
        #endregion

        private void CreateReadingPanel(string paragraphText)
        {
            readingPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 200,
                Padding = new Padding(10),
                BackColor = Color.White,
            };

            readingParagraphBox = new RichTextBox
            {
                Dock = DockStyle.Fill,
                Text = paragraphText,
                ReadOnly = true,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                BackColor = Color.White,
                ScrollBars = RichTextBoxScrollBars.Vertical
            };

            readingPanel.Controls.Add(readingParagraphBox);

            // Insert before question content
            questionsPanel.Controls.Add(readingPanel);
            readingPanel.BringToFront();
        }


        #region Skeleton
        private Panel CreateSkeletonCard()
        {
            Panel card = new Panel
            {
                Width = 62,
                Height = 62,
                Margin = new Padding(8),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            // Placeholder panel for shimmer
            Panel shimmer = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(220, 220, 220)
            };

            card.Controls.Add(shimmer);
            return card;
        }

        private void ShowSkeletonLoading()
        {
            flpQuestion.Controls.Clear();

            // Add 8 fake skeleton tiles
            for (int i = 0; i < 20; i++)
            {
                flpQuestion.Controls.Add(CreateSkeletonCard());
            }

            Helper.StartShimmerAnimation(flpQuestion);
        }

        private void ShowQuestionSkeleton()
        {
            questionsPanel.Controls.Clear();

            // Create a FlowLayoutPanel because shimmer only works on FlowLayoutPanel
            FlowLayoutPanel skeletonContainer = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = false,
                WrapContents = false,
                FlowDirection = FlowDirection.TopDown,
                BackColor = Color.WhiteSmoke
            };

            questionsPanel.Controls.Add(skeletonContainer);

            int marginLeft = 20;
            int width = questionsPanel.Width - 40;

            // ----- Image placeholder -----
            Panel imgBlock = new Panel
            {
                Width = width,
                Height = 150,
                Margin = new Padding(marginLeft, 20, 0, 20),
                BackColor = Color.FromArgb(220, 220, 220)
            };
            skeletonContainer.Controls.Add(imgBlock);

            // ----- Title placeholder -----
            Panel titleBlock = new Panel
            {
                Width = width,
                Height = 30,
                Margin = new Padding(marginLeft, 0, 0, 20),
                BackColor = Color.FromArgb(220, 220, 220)
            };
            skeletonContainer.Controls.Add(titleBlock);

            // ----- 4 Answer placeholders -----
            for (int i = 0; i < 4; i++)
            {
                Panel answerBlock = new Panel
                {
                    Width = width - 20,
                    Height = 25,
                    Margin = new Padding(marginLeft + 20, 0, 0, 20),
                    BackColor = Color.FromArgb(220, 220, 220)
                };
                skeletonContainer.Controls.Add(answerBlock);
            }

            // Start shimmer on FlowLayoutPanel (now correct type)
            Helper.StartShimmerAnimation(skeletonContainer);
        }
        #endregion
    }
}
