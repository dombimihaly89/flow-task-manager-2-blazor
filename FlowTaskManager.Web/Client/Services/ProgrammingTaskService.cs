using FlowTaskManager.Web.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FlowTaskManager.Web.Client.Services
{
    public class ProgrammingTaskService : IProgrammingTaskService
    {
        private readonly HttpClient httpClient;

        public ProgrammingTaskService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<ProgrammingTask>> GetProgrammingTasks()
        {
            return await httpClient.GetJsonAsync<ProgrammingTask[]>("api/programmingtasks");
        }
    }
}
