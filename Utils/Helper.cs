using System.Windows.Forms;

namespace Lab_8.Utils
{
    internal class Helper
    {
        public static byte[] UploadImage(OpenFileDialog openFileDialog, PictureBox pictureBox)
        {
            openFileDialog.Title = "Select User Image";
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                pictureBox.Image = System.Drawing.Image.FromFile(filePath);

                return System.IO.File.ReadAllBytes(filePath);
            }
            else
            {
                return null;
            }
        }
    }
}
