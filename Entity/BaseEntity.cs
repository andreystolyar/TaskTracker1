namespace TaskTracker.Entity
{
    // BaseEntity is the parent class for ProjectEntity and TaskEntity classes.
    // It has the sole "Id" property.
    public abstract class BaseEntity
    {
        public int Id { get; set; }
    }
}
