using AsilMedia.Domain.Enums;

namespace AsilMedia.Application.DataTransferObjects
{
    public class FilmMakerDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public Gender Gender { get; set; }
        public string PhotoPath { get; set; }
    }
}
