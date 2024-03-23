namespace Entity.Abstractions.Interfaces
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; set; }

        DateTime? DeletedAt { get; set; }
    }
}
