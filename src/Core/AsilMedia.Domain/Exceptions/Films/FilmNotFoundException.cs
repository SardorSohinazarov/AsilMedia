namespace AsilMedia.Domain.Exceptions.Films
{
    public class FilmNotFoundException : Exception
    {
        public FilmNotFoundException() : base("Film not found.") { }
    }
}
