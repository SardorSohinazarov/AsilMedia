namespace AsilMedia.Application.DataTransferObjects
{
    public class RoleDTO
    {
        public string Name { get; set; }

        public List<long> Permissions { get; set; }
    }
}
