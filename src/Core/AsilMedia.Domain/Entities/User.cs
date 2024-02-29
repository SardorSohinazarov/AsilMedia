using AsilMedia.Domain.Common;

namespace AsilMedia.Domain.Entities
{
    public class User : Auditable
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpiredDate { get; set; }
        public long RoleId { get; set; }

        public Role Role { get; set; }
    }
}
