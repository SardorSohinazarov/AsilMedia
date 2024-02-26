using AsilMedia.Domain.Enums;

namespace AsilMedia.Application.DataTransferObjects
{
    partial class ActorDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public Gender Gender { get; set; }
        public string PhotoPath { get; set; }
    }
}
