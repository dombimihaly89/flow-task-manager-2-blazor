using FlowTaskManager.Web.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FlowTaskManager.Web.Client.Services
{
    public class TaskService : ITaskService
    {
        private readonly HttpClient httpClient;

        public TaskService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<ProgrammingTask>> GetProgrammingTasks()
        {
            return await httpClient.GetJsonAsync<ProgrammingTask[]>("api/tasks");
        }

        public async Task<ProgrammingTask> GetProgrammingTask(int id)
        {
            return await httpClient.GetJsonAsync<ProgrammingTask>($"api/tasks/{id}");
        }
        public async Task<ProgrammingTask> UpdateProgrammingTask(int id, ProgrammingTask task)
        {
            return await httpClient.PutJsonAsync<ProgrammingTask>($"api/tasks/{id}", task);
        }

        public async Task<ProgrammingTask> CreateProgrammingTask( ProgrammingTask task)
        {
            return await httpClient.PostJsonAsync<ProgrammingTask>("api/tasks", task);
        }

        public async Task DeleteProgrammingTask(int id)
        {
            await httpClient.DeleteAsync($"api/tasks/{id}");
        }
    }
}
