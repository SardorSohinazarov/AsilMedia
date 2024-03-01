namespace AsilMedia.Domain.Exceptions.Users
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base("User not found.")
        {

        }
    }
}
