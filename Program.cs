using Lab_8.Forms;
using Lab_8.Models;
using Lab_8.Services;
using Lab_8.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Lab_8
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var context = new QuizDBContext())
            {
                DataSeeder.Seed(context); // Seed DB if empty

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var savedUserId = LocalStorage.LoadUserId();

                if (savedUserId.HasValue)
                {
                    // Load full user with role and permissions
                    var user = context.Users
                        .Include(u => u.Role)
                            .ThenInclude(r => r.RolePermissions)
                                .ThenInclude(rp => rp.Permission)
                        .FirstOrDefault(u => u.Id == savedUserId.Value);

                    if (user != null)
                    {
                        UserService.Instance.User = user;
                        Application.Run(new Home());
                        return;
                    }
                }

                // No saved user, or user not found
                Application.Run(new Login());
            }
        }
    }
}
