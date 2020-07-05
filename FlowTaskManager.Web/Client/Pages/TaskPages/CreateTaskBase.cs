using FlowTaskManager.Web.Client.Services;
using FlowTaskManager.Web.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowTaskManager.Web.Client.Pages.TaskPages
{
    public class CreateTaskBase : ComponentBase
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        [Inject]
        private ITaskService TaskService { get; set; }
        public ProgrammingTask Task { get; set; } = new ProgrammingTask();

        public async void HandleSubmit()
        {
            // For test reasons we save tasks to the user with id 3.
            Task.UserId = 3;
            await TaskService.CreateProgrammingTask(Task);
            NavigationManager.NavigateTo("/tasks");
        }
        public void ClickCancel()
        {
            NavigationManager.NavigateTo("/tasks");
        }
    }
}
