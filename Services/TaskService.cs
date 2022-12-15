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
    ///<summary>
    /// TaskService is an implementation of the ITaskService interface.
    ///</summary>
    public class TaskService : ITaskService
    {
        private readonly IMapper _mapper;

        private readonly IRepository<TaskEntity> _repository;

        public TaskService(
            IMapper mapper,
            IRepository<TaskEntity> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<TaskViewModel>> GetAsync()
        {
            var tasks = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<TaskViewModel>>(tasks);
        }

        public async Task<TaskViewModel> GetAsync(int taskId)
        {
            var task = await _repository.GetByIdAsync(taskId);

            if (task == null)
            {
                throw new HttpRequestException(
                    $"Task with Id: \"{taskId}\" not found.",
                    null,
                    HttpStatusCode.NotFound);
            }

            return _mapper.Map<TaskViewModel>(task);
        }

        public async ValueTask<int> CreateAsync(TaskViewModel task)
        {
            var newTask = _mapper.Map<TaskEntity>(task);

            return await _repository.CreateAsync(newTask);
        }

        public async Task UpdateAsync(int id, JsonPatchDocument<TaskViewModel> patch)
        {
            var taskEntity = await _repository.GetByIdAsync(id);

            if (taskEntity == null)
            {
                throw new HttpRequestException(
                    $"Task with Id: \"{id}\" not found.",
                    null,
                    HttpStatusCode.NotFound);
            }

            var taskViewModel = _mapper.Map<TaskViewModel>(taskEntity);
            patch.ApplyTo(taskViewModel);
            _mapper.Map(taskViewModel, taskEntity);

            await _repository.UpdateAsync(taskEntity);
        }

        public async Task DeleteAsync(int id)
        {
            var task = await _repository.GetByIdAsync(id);

            if (task == null)
            {
                throw new HttpRequestException(
                    $"Task with Id: \"{id}\" not found.",
                    null,
                    HttpStatusCode.NotFound);
            }

            await _repository.DeleteAsync(task);
        }
    }
}
