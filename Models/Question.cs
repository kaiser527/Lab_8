using NAudio.Wave;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_8.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Column(TypeName = "VARBINARY(MAX)")]
        public byte[] Image { get; set; }
            
        [Column(TypeName = "VARBINARY(MAX)")]
        public byte[] Audio { get; set; }

        [Required]
        public int QuizId { get; set; }

        [ForeignKey("QuizId")]
        public Quiz Quiz { get; set; }

        public ICollection<Answer> Answers { get; set; } = new List<Answer>();

        [NotMapped]
        public WaveOutEvent WaveOut { get; set; }

        [NotMapped]
        public WaveStream Reader { get; set; }
    }
}
