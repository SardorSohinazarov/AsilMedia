namespace AsilMedia.Application.DataTransferObjects
{
    public class RegisterDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpiredDate { get; set; } = DateTime.UtcNow;
        public long RoleId { get; set; }
    }
}
