namespace AsilMedia.Domain.Exceptions.Actor
{
    public class ActorNotFoundException : Exception
    {
        public ActorNotFoundException() : base("Actor Not Found.") { }
    }
}
