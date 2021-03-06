﻿using AutoMapper;
using FlowTaskManager.Web.Server.Exceptions;
using FlowTaskManager.Web.Server.Models;
using FlowTaskManager.Web.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowTaskManager.Web.Server.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository taskRepository;
        private readonly IMapper mapper;

        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            this.taskRepository = taskRepository;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<ProgrammingTask>> GetProgrammingTasks(int page, int tasksOnPage)
        {
            int allTasks = await taskRepository.CountAllTasks();
            int lastPage = (allTasks % tasksOnPage) == 0 ? (allTasks / tasksOnPage) : (allTasks / tasksOnPage) + 1;
            if (page > lastPage || page < 1)
            {
                throw new PageOutOfBoundException(lastPage);
            }
            return await taskRepository.GetProgrammingTasks(page, tasksOnPage);
        }

        public async Task<ProgrammingTask> GetProgrammingTask(int id)
        {
            return await taskRepository.GetProgrammingTask(id);
        }

        public async Task<ProgrammingTask> CreateProgrammingTask(ProgrammingTask task)
        {
            task.CreatedAt = DateTime.Now;
            if (task.Id == 0)
            {
                return await taskRepository.CreateProgrammingTask(task);
            }
            return null;
            
        }

        public async Task<ProgrammingTask> UpdateProgrammingTask(int id, ProgrammingTask task)
        {
            var taskToUpdate = await GetProgrammingTask(id);
            if (taskToUpdate != null)
            {
                mapper.Map<ProgrammingTask, ProgrammingTask>(task, taskToUpdate);
                taskToUpdate.UpdatedAt = DateTime.Now;
                return await taskRepository.UpdateProgrammingTask(taskToUpdate);
            }
            return null;
        }

        public async Task<ProgrammingTask> DeleteProgrammingTask(int id)
        {
            return await taskRepository.DeleteProgrammingTask(id);
        }

        public async Task<int> CountAllTasks()
        {
            return await taskRepository.CountAllTasks();
        }
    }
}
