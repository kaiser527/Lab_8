using Lab_8.Models;
using NAudio.Wave;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Lab_8.Utils
{
    internal static class Helper
    {
        private static Question currentPlayingQuestion;
        private static Button currentPlayPauseButton;

        private static Timer shimmerTimer;
        private static int shimmerOffset = 0;

        public static void StartShimmerAnimation(Control container)
        {
            if (container == null) return;

            shimmerTimer = new Timer
            {
                Interval = 50 
            };

            shimmerTimer.Tick += (s, e) =>
            {
                shimmerOffset += 5;

                foreach (Control card in container.Controls)
                {
                    foreach (Control placeholder in card.Controls)
                    {
                        if (placeholder is Panel)
                        {
                            int baseColor = 200;
                            int offset = (shimmerOffset + placeholder.Top) % 255;
                            int colorValue = baseColor + (offset / 2 % 55);
                            placeholder.BackColor = Color.FromArgb(colorValue, colorValue, colorValue);
                        }
                    }

                    if (card is Panel && card.Controls.Count == 0)
                    {
                        int baseColor = 200;
                        int offset = (shimmerOffset + card.Top) % 255;
                        int colorValue = baseColor + (offset / 2 % 55);
                        card.BackColor = Color.FromArgb(colorValue, colorValue, colorValue);
                    }
                }
            };

            shimmerTimer.Start();
        }

        public static void StopShimmerAnimation()
        {
            shimmerTimer?.Stop();
            shimmerTimer = null;
        }

        public static Image ByteArrayToImage(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
                return null;

            using (var ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }

        public static byte[] UploadImage(OpenFileDialog openFileDialog, PictureBox pictureBox = null)
        {
            openFileDialog.Title = "Select User Image";
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                if (pictureBox != null)
                    pictureBox.Image = Image.FromFile(filePath);

                return File.ReadAllBytes(filePath);
            }
            return null;
        }

        public static void PlayAudio(Question q, Button btnPlayPause)
        {
            if (q?.Audio == null || q.Audio.Length == 0) return;

            // Stop any other audio
            if (currentPlayingQuestion != null && currentPlayingQuestion != q)
            {
                StopAudio(currentPlayingQuestion);
                if (currentPlayPauseButton != null)
                    currentPlayPauseButton.Text = "▶";
            }

            // Start or resume current audio
            if (q.WaveOut != null && q.WaveOut.PlaybackState == PlaybackState.Paused)
            {
                q.WaveOut.Play(); // resume safely
            }
            else
            {
                var ms = new MemoryStream(q.Audio);
                q.Reader = IsMp3(ms) ? (WaveStream)new Mp3FileReader(ms) : new WaveFileReader(ms);
                q.WaveOut = new WaveOutEvent();
                q.WaveOut.Init(q.Reader);
                q.WaveOut.Play();

                currentPlayingQuestion = q;
                currentPlayPauseButton = btnPlayPause;

                q.WaveOut.PlaybackStopped += (s, e) =>
                {
                    q.WaveOut?.Dispose();
                    q.Reader?.Dispose();
                    q.WaveOut = null;
                    q.Reader = null;

                    if (currentPlayingQuestion == q)
                        currentPlayingQuestion = null;
                    if (currentPlayPauseButton == btnPlayPause)
                        currentPlayPauseButton = null;

                    btnPlayPause.Text = "▶";
                };
            }
        }

        public static void StopAudio(Question q)
        {
            if (q == null) return;

            q.WaveOut?.Stop();
            q.WaveOut?.Dispose();
            q.WaveOut = null;

            q.Reader?.Dispose();
            q.Reader = null;

            if (currentPlayingQuestion == q)
                currentPlayingQuestion = null;
        }

        public static void PauseAudio(Question q)
        {
            if (q?.WaveOut != null && q.WaveOut.PlaybackState == PlaybackState.Playing)
            {
                q.WaveOut.Pause();  
            }
        }

        private static bool IsMp3(Stream stream)
        {
            byte[] buffer = new byte[3];
            stream.Read(buffer, 0, 3);
            stream.Position = 0;
            return buffer[0] == 'I' && buffer[1] == 'D' && buffer[2] == '3';
        }
    }
}
