using FlowTaskManager.Web.Client.Services;
using FlowTaskManager.Web.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowTaskManager.Web.Client.Pages.TaskPages
{
    public class CreateTaskBase : ComponentBase
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        [Inject]
        private ITaskService TaskService { get; set; }
        [Parameter]
        public string Id { get; set; }
        public ProgrammingTask Task { get; set; } = new ProgrammingTask();

        protected override async Task OnInitializedAsync()
        {
            int.TryParse(Id, out int id);
            if (id != 0)
            {
                Task = await TaskService.GetProgrammingTask(id);
            }
        }

        public async void HandleSubmit()
        {
            if (Id == null)
            {
                // For test reasons we save tasks to the user with id 3.
                Task.UserId = 3;
                await TaskService.CreateProgrammingTask(Task);
            }
            else
            {
                int.TryParse(Id, out int id);
                await TaskService.UpdateProgrammingTask(id, Task);
            }
                NavigationManager.NavigateTo("/tasks");
        }

        public void ClickCancel()
        {
            NavigationManager.NavigateTo("/tasks");
        }
    }
}
