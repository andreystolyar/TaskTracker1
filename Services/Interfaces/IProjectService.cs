using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskTracker.Model;

namespace TaskTracker.Services.Interfaces
{
    ///<summary>
    // IProjectService interface contains methods for manipulating data send by user
    ///</summary>
    public interface IProjectService
    {
        Task<IEnumerable<ProjectViewModel>> GetAsync();
        Task<ProjectViewModel> GetAsync(int projectId);
        ValueTask<int> CreateAsync(ProjectViewModel project);
        Task UpdateAsync(int id, JsonPatchDocument<ProjectViewModel> patch);
        Task DeleteAsync(int id);
    }
}
