using System;
using System.Collections.Generic;
using TaskTracker.Enum;

namespace TaskTracker.Entity
{
    // The Project table representation for repository layer.
    public sealed class ProjectEntity : BaseEntity
    {
        public ProjectEntity()
        {
            Tasks = new List<TaskEntity>();
        }

        public string Name { get; set; }
        
        public DateTime? Start { get; set; }
        
        public DateTime? Completion { get; set; }
        
        public ProjectStatus ProjectStatus { get; set; }
        
        public int Priority { get; set; }
        
        public List<TaskEntity> Tasks { get; set; }
    }
}
