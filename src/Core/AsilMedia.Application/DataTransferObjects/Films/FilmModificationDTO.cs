namespace AsilMedia.Application.DataTransferObjects.Films
{
    public class FilmModificationDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public long FilmMakerId { get; set; }
        public int AgeRestriction { get; set; }
        public int PublishedYear { get; set; }
        public string? PhotoPath { get; set; }
        public string VideoPath { get; set; }
    }
}
