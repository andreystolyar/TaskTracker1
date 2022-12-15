namespace TaskTracker.Entity
{
    ///<summary>
    /// BaseEntity is the parent class for ProjectEntity and TaskEntity classes. It has the sole "Id" property.
    ///</summary>
    public abstract class BaseEntity
    {
        public int Id { get; set; }
    }
}
