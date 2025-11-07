using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_8.Models
{
    public class History
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int QuizId { get; set; }

        [Required]
        public bool IsFinish { get; set; }

        [Required]
        public DateTime TimeStart { get; set; }

        [Required]
        public DateTime TimeFinish { get; set; }

        [Required]
        public double TotalScore { get; set; }

        [ForeignKey("QuizId")]
        public Quiz Quiz { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public ICollection<UserAnswer> UserAnswers { get; set; }
    }
}
