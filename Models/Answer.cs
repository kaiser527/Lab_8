using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_8.Models
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int QuestionId { get; set; }

        [Required]
        public bool IsCorrect { get; set; }

        [ForeignKey("QuestionId")]
        public Question Question { get; set; }
    }
}
