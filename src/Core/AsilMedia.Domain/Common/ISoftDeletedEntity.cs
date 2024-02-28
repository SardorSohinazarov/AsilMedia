namespace AsilMedia.Domain.Common
{
    public interface ISoftDeletedEntity
    {
        bool IsDeleted { get; set; }
        DateTime? DeletedDateTime { get; set; }
    }
}
