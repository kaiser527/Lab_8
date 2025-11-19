using System;
using System.IO;

namespace Lab_8.Services
{
    internal static class LocalStorage
    {
        private static readonly string filePath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "quiz_user.json");

        public static void SaveUserId(int userId)
        {
            File.WriteAllText(filePath, userId.ToString());
        }

        public static int? LoadUserId()
        {
            if (!File.Exists(filePath)) return null;

            if (int.TryParse(File.ReadAllText(filePath), out int userId))
                return userId;

            return null;
        }

        public static void ClearUser()
        {
            if (File.Exists(filePath)) File.Delete(filePath);
        }
    }
}
