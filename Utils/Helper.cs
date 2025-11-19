using Lab_8.Models;
using NAudio.Wave;
using System.IO;
using System.Windows.Forms;

namespace Lab_8.Utils
{
    internal static class Helper
    {
        private static Question currentPlayingQuestion;
        private static Button currentPlayPauseButton;

        public static byte[] UploadImage(OpenFileDialog openFileDialog, PictureBox pictureBox = null)
        {
            openFileDialog.Title = "Select User Image";
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                if (pictureBox != null)
                    pictureBox.Image = System.Drawing.Image.FromFile(filePath);

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
                    currentPlayPauseButton.Text = "Play";
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

                    btnPlayPause.Text = "Play";
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

        public static void ResumeAudio(Question q)
        {
            if (q?.WaveOut != null && q.WaveOut.PlaybackState == PlaybackState.Paused)
            {
                q.WaveOut.Play();
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
