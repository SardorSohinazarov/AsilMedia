using AsilMedia.Domain.Common;

namespace AsilMedia.Domain.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }

        public List<User> Users { get; set; }
    }
}
