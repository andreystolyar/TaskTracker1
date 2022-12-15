using System.ComponentModel.DataAnnotations;
using TaskTracker.Enum;

namespace TaskTracker.Model
{
    // TaskViewModel is the Service layer representation
    // of the Task table
    public class TaskViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public TaskStatus Status { get; set; }

        public int Priority { get; set; }
    }
}
