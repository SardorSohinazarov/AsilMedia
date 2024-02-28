using AsilMedia.Domain.Common;

namespace AsilMedia.Domain.Entities
{
    public class Genre : BaseEntity, ISoftDeletedEntity
    {
        public string Name { get; set; }

        public List<Film> Films { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTime { get; set; }
    }
}
