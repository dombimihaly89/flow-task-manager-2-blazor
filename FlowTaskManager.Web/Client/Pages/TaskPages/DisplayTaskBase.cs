using FlowTaskManager.Web.Client.Services;
using FlowTaskManager.Web.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowTaskManager.Web.Client.Pages.TaskPages
{
    public class DisplayTaskBase : ComponentBase
    {
        [Inject]
        private ITaskService TaskService { get; set; }
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        [Parameter]
        public ProgrammingTask Task { get; set; }

        public async void ClickDelete()
        {
            await TaskService.DeleteProgrammingTask(Task.Id);
            NavigationManager.NavigateTo("/tasks", true);
        }
    }
}
