using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab_8.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public ICollection<User> Users { get; set; } = new HashSet<User>();

        public ICollection<RolePermission> RolePermissions { get; set; } = new HashSet<RolePermission>();
    }
}
