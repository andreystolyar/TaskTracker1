using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using TaskTracker.Model;

namespace TaskTracker.Services.Interfaces
{
    // ITaskService interface contains methods
    // for manipulating data send by user
    public interface ITaskService
    {
        Task<IEnumerable<TaskViewModel>> GetAsync();
        Task<TaskViewModel> GetAsync(int taskId);
        ValueTask<int> CreateAsync(TaskViewModel task);
        Task UpdateAsync(int id, JsonPatchDocument<TaskViewModel> patch);
        Task DeleteAsync(int id);
    }
}
