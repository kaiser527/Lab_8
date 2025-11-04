using Lab_8.Models;
using Lab_8.Utils;
using System;
using System.Windows.Forms;

namespace Lab_8
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var context = new QuizDBContext())
            {
                DataSeeder.Seed(context);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
