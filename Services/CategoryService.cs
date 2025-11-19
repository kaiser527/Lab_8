using Lab_8.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WinFormApp.DTO;
using WinFormApp.Forms;

namespace Lab_8.Services
{
    internal class CategoryService
    {
        private static CategoryService instance;

        public static CategoryService Instance
        {
            get
            {
                if (instance == null) instance = new CategoryService();
                return instance;
            }
            private set { instance = value; }
        }

        private CategoryService() { }

        public async Task<PaginatedResult<Category>> GetListCategory(
           int pageSize = 100,
           int pageNumber = 1,
           string name = null)
        {
            using (var context = new QuizDBContext())
            {
                var query = context.Categories
                    .Where(c => c.IsActive) 
                    .AsQueryable();

                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(a =>
                        a.Name.ToLower().Contains(name.ToLower())
                    );
                }

                int totalCount = await query.CountAsync();
                int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

                var items = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                return new PaginatedResult<Category>
                {
                    Items = items,
                    TotalCount = totalCount,
                    TotalPages = totalPages
                };
            }
        }

        public async Task InsertCategory(Category category)
        {
            using (var context = new QuizDBContext())
            {
                bool isExist = await context.Categories.AnyAsync(c => c.Name == category.Name);

                if (isExist)
                {
                    Alert.ShowAlert("Category is already exist", Alert.AlertType.Error);
                    return;
                }

                context.Categories.Add(category);

                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateCategory(Category category)
        {
            using (var context = new QuizDBContext())
            {
                var updatedCategory = await context.Categories.FindAsync(category.Id);

                if (updatedCategory == null)
                {
                    Alert.ShowAlert("Category is not exist", Alert.AlertType.Error);
                    return;
                }

                bool isExist = await context.Categories
                    .AnyAsync(c => c.Name == category.Name && c.Id != c.Id);

                if (isExist)
                {
                    Alert.ShowAlert("Category is already exist", Alert.AlertType.Error);
                    return;
                }

                updatedCategory.Name = category.Name;
                updatedCategory.IsActive = category.IsActive;

                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteCategory(int categoryId)
        {
            using (var context = new QuizDBContext())
            {
                var category = await context.Categories
                    .Include(f => f.Quizzes)
                    .FirstOrDefaultAsync(f => f.Id == categoryId);

                if (category == null)
                {
                    Alert.ShowAlert("Category is not exist", Alert.AlertType.Error);
                    return;
                }

                if (category.Quizzes.Any())
                {
                    Alert.ShowAlert("There are some quiz assigned to this category", Alert.AlertType.Error);
                    return;
                }

                context.Categories.Remove(category);

                await context.SaveChangesAsync();
            }
        }
    }
}
