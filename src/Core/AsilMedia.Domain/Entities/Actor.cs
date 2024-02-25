using AsilMedia.Domain.Common;
using AsilMedia.Domain.Enums;

namespace AsilMedia.Domain.Entities
{
    public class Actor : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public Gender Gender { get; set; }
        public string PhotoPath { get; set; }

        public List<Film> Films { get; set; }
    }
}
