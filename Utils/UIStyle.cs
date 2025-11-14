using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Lab_8.Utils
{
    public static class UIStyle
    {
        private static readonly Color PlaceholderColor = Color.Gray;
        private static readonly Color TextColor = Color.Black;

        [DllImport("gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect,
            int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        public static void RoundPanel(Panel panel, int radius)
        {
            panel.Region = Region.FromHrgn(CreateRoundRectRgn(
                0, 0, panel.Width, panel.Height, radius, radius));
        }

        public static void ModernUIButton(Button btn, Color baseColor, Color hoverColor)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = baseColor;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn.Width, btn.Height, 18, 18));
            btn.Cursor = Cursors.Hand;
            btn.FlatAppearance.MouseOverBackColor = hoverColor;
            btn.FlatAppearance.MouseDownBackColor = hoverColor;

            btn.MouseEnter += (s, e) => btn.BackColor = hoverColor;
            btn.MouseLeave += (s, e) => btn.BackColor = baseColor;
        }

        public static void ApplyPlaceholder(TextBox textBox, string placeholder, ref bool isPlaceholderFlag)
        {
            isPlaceholderFlag = true;
            textBox.ForeColor = PlaceholderColor;
            textBox.Text = placeholder;
            isPlaceholderFlag = false;

            // Attach events only once
            textBox.Enter -= RemovePlaceholder;
            textBox.Enter += RemovePlaceholder;

            textBox.Leave -= SetPlaceholder;
            textBox.Leave += SetPlaceholder;

            // Store placeholder text in Tag
            textBox.Tag = (placeholder, isPlaceholderFlag);
        }

        private static void RemovePlaceholder(object sender, EventArgs e)
        {
            var txt = sender as TextBox;
            var (placeholder, _) = ((string, bool))txt.Tag;

            if (txt.Text == placeholder)
            {
                txt.Text = "";
                txt.ForeColor = TextColor;
            }
        }

        private static void SetPlaceholder(object sender, EventArgs e)
        {
            var txt = sender as TextBox;
            var (placeholder, flag) = ((string, bool))txt.Tag;

            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                flag = true;
                txt.ForeColor = PlaceholderColor;
                txt.Text = placeholder;
                flag = false;
                txt.Tag = (placeholder, flag);
            }
        }

        public static void FillRoundedRectangle(this Graphics g, Brush brush, Rectangle rect, int radius)
        {
            using (var path = RoundedRect(rect, radius))
            {
                g.FillPath(brush, path);
            }
        }

        public static void DrawRoundedRectangle(this Graphics g, Pen pen, Rectangle rect, int radius)
        {
            using (var path = RoundedRect(rect, radius))
            {
                g.DrawPath(pen, path);
            }
        }

        private static System.Drawing.Drawing2D.GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int d = radius * 2;
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
