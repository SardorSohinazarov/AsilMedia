namespace AsilMedia.Domain.Exceptions.Actors
{
    public class ActorNotFoundException : Exception
    {
        public ActorNotFoundException() : base("Actor not found.") { }
    }
}
