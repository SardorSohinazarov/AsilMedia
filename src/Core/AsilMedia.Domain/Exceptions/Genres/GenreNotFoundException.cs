namespace AsilMedia.Domain.Exceptions.Genres
{
    public class GenreNotFoundException : Exception
    {
        public GenreNotFoundException() : base("Genre not found") { }
    }
}
