using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using TaskTracker.Entity;
using TaskTracker.Model;
using TaskTracker.Repository.Interfaces;
using TaskTracker.Services.Interfaces;

namespace TaskTracker.Services
{
    // ProjectService is a realization of the IProjectService method.
    public class ProjectService : IProjectService
    {
        private readonly IMapper _mapper;

        private readonly IProjectRepository _repository;

        public ProjectService(
            IMapper mapper,
            IProjectRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<ProjectViewModel>> GetAsync()
        {
            var projects = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<ProjectViewModel>>(projects);
        }

        public async Task<ProjectViewModel> GetAsync(int projectId)
        {
            var project = await _repository.GetByIdAsync(projectId);

            if (project == null)
            {
                throw new HttpRequestException(
                    $"Project with Id: \"{projectId}\" not found.",
                    null,
                    HttpStatusCode.NotFound);
            }

            return _mapper.Map<ProjectViewModel>(project);
        }

        public async ValueTask<int> CreateAsync(ProjectViewModel project)
        {
            var newProject = _mapper.Map<ProjectEntity>(project);

            return await _repository.CreateAsync(newProject);
        }

        public async Task UpdateAsync(int id, JsonPatchDocument<ProjectViewModel> patch)
        {
            var projectEntity = await _repository.GetByIdAsync(id);

            if (projectEntity == null)
            {
                throw new HttpRequestException(
                    $"Project with Id: \"{id}\" not found.",
                    null,
                    HttpStatusCode.NotFound);
            }

            var entityPatch = _mapper.Map<JsonPatchDocument<ProjectEntity>>(patch);
            entityPatch.ApplyTo(projectEntity);

            await _repository.UpdateAsync(projectEntity);
        }

        public async Task DeleteAsync(int id)
        {
            var project = await _repository.GetByIdAsync(id);

            if (project == null)
            {
                throw new HttpRequestException(
                    $"Project with Id: \"{id}\" not found.",
                    null,
                    HttpStatusCode.NotFound);
            }

            await _repository.DeleteAsync(project);
        }
    }
}
