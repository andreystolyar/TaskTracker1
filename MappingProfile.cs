using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using TaskTracker.Entity;
using TaskTracker.Model;

namespace TaskTracker
{
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Mapping settings.
        /// </summary>
        public MappingProfile()
        {

        // ProjectEntity and TaskEntity from repository level
        // have the same properties as ProjectViewModel and TaskViewModel
        // so we can just copy data from one to the other.

            CreateMap<ProjectEntity, ProjectViewModel>().ReverseMap();
            CreateMap<TaskEntity, TaskViewModel>().ReverseMap();
            CreateMap<JsonPatchDocument<ProjectViewModel>, JsonPatchDocument<ProjectEntity>>().ReverseMap();
            CreateMap<Operation<ProjectViewModel>, Operation<ProjectEntity>>().ReverseMap();
        }
    }
}
