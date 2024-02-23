using AsilMedia.Domain.Common;

namespace AsilMedia.Domain.Entities
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }

        public List<Film> Films { get; set; }
    }
}
