using System.ComponentModel.DataAnnotations.Schema;
using TaskTracker.Enum;

namespace TaskTracker.Entity
{
    // The Task table representation for repository layer.
    public sealed class TaskEntity : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }
        
        public TaskStatus Status { get; set; }
        
        public int Priority { get; set; }
        
        [ForeignKey("Project")]
        public int? ProjectId { get; set; }
        
        public ProjectEntity Project { get; set; }
    }
}
