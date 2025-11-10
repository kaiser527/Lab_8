namespace Lab_8.DTO
{
    public class UpdateUserProfile
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
    }
}
