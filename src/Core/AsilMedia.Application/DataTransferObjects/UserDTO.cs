namespace AsilMedia.Application.DataTransferObjects
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpiredDate { get; set; } = DateTime.UtcNow;
        public long RoleId { get; set; }
    }
}
