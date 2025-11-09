using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_8.Models
{
    public class Quiz
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Difficulty { get; set; }

        public ICollection<Question> Questions { get; set; } = new List<Question>();

        [Column(TypeName = "VARBINARY(MAX)")]
        public byte[] Image { get; set; }

        public ICollection<History> Histories { get; set; } = new List<History>();
    }
}
