using System;
using System.IO;
using System.Text.Json;
using Lab_8.Models;

namespace Lab_8.Services
{
    internal static class LocalStorage
    {
        private static readonly string filePath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "quiz_user.json");

        public static void SaveUser(User user)
        {
            var json = JsonSerializer.Serialize(new
            {
                user.Id,
                user.Email,
                user.Name,
                user.Image
            });
            File.WriteAllText(filePath, json);
        }

        public static User LoadUser()
        {
            if (!File.Exists(filePath)) return null;

            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<User>(json);
        }

        public static void ClearUser()
        {
            if (File.Exists(filePath)) File.Delete(filePath);
        }
    }
}
