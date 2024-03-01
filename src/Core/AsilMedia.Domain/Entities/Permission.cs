using AsilMedia.Domain.Common;

namespace AsilMedia.Domain.Entities
{
    public class Permission : BaseEntity
    {
        public string Name { get; set; }

        public List<Role> Roles { get; set; }
    }
}
