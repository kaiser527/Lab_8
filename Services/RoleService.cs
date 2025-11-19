using Lab_8.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormApp.DTO;
using WinFormApp.Forms;

namespace Lab_8.Services
{
    internal class RoleService
    {
        private static RoleService instance;

        public static RoleService Instance
        {
            get
            {
                if (instance == null) instance = new RoleService();
                return instance;
            }
            private set { instance = value; }
        }

        private RoleService() { }

        public async Task<PaginatedResult<Role>> GetListRole(
           int pageSize = 100,
           int pageNumber = 1,
           string rolename = null)
        {
            using (var context = new QuizDBContext())
            {
                var query = context.Roles
                    .Include(r => r.RolePermissions)
                        .ThenInclude(rp => rp.Permission)
                    .AsQueryable();

                if (!string.IsNullOrEmpty(rolename))
                {
                    query = query.Where(f => f.Name.ToLower().Contains(rolename.ToLower()));
                }

                int totalCount = await query.CountAsync();
                int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

                var items = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                return new PaginatedResult<Role>
                {
                    Items = items,
                    TotalCount = totalCount,
                    TotalPages = totalPages
                };
            }
        }

        public async Task InsertRole(Role role)
        {
            using (var context = new QuizDBContext())
            {
                bool isExist = await context.Roles.AnyAsync(f => f.Name == role.Name);

                if (isExist)
                {
                    Alert.ShowAlert("Role is already exist", Alert.AlertType.Error);
                    return;
                }

                var newRole = new Role
                {
                    Name = role.Name,
                    IsActive = role.IsActive,
                    RolePermissions = role.RolePermissions
                };

                context.Roles.Add(newRole);

                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateRole(Role role)
        {
            using (var context = new QuizDBContext())
            {
                Role updatedRole = await context.Roles
                    .Include(r => r.RolePermissions)
                    .FirstOrDefaultAsync(r => r.Id == role.Id);

                if (updatedRole == null)
                {
                    Alert.ShowAlert("Role is not exist", Alert.AlertType.Error);
                    return;
                }

                bool isExist = await context.Roles.AnyAsync(f => f.Name == role.Name && f.Id != role.Id);

                if (isExist)
                {
                    Alert.ShowAlert("Role is already exist", Alert.AlertType.Error);
                    return;
                }

                updatedRole.Name = role.Name;
                updatedRole.IsActive = role.IsActive;

                context.RolePermissions.RemoveRange(updatedRole.RolePermissions);

                updatedRole.RolePermissions = role.RolePermissions
                    .Select(rp => new RolePermission { RoleId = role.Id, PermissionId = rp.PermissionId })
                    .ToList();

                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteRole(int roleId)
        {
            using (var context = new QuizDBContext())
            {
                var role = await context.Roles
                    .Include(r => r.Users)
                    .Include(r => r.RolePermissions)
                    .FirstOrDefaultAsync(r => r.Id == roleId);

                if (role == null)
                {
                    Alert.ShowAlert("Role does not exist", Alert.AlertType.Error);
                    return;
                }

                if (role.Name.Equals("admin", StringComparison.OrdinalIgnoreCase))
                {
                    Alert.ShowAlert("Cannot delete admin role", Alert.AlertType.Error);
                    return;
                }

                if (role.Users.Any())
                {
                    Alert.ShowAlert("There are users assigned to this role", Alert.AlertType.Error);
                    return;
                }

                context.RolePermissions.RemoveRange(role.RolePermissions);

                context.Roles.Remove(role);

                await context.SaveChangesAsync();

                Alert.ShowAlert("Role deleted successfully", Alert.AlertType.Success);
            }
        }
    }
}

