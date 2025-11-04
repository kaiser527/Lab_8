namespace Lab_8.Models
{
    public class UserAnswer
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int AnswerId { get; set; }
        public Answer Answer { get; set; }

        public int HistoryId { get; set; }
        public History History { get; set; }
    }
}
