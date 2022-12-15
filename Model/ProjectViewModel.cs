using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskTracker.Entity;
using TaskTracker.Enum;

namespace TaskTracker.Model
{
    // ProjectViewModel is the Service layer representation
    // of the Project table
    public class ProjectViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Start { get; set; }

        public DateTime Completion { get; set; }

        public ProjectStatus ProjectStatus { get; set; }

        public int Priority { get; set; }

        public List<TaskViewModel> Tasks { get; set; }
    }
}
