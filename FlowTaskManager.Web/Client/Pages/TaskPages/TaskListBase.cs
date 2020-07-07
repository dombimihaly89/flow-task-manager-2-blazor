using FlowTaskManager.Web.Client.Services;
using FlowTaskManager.Web.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowTaskManager.Web.Client.Pages.TaskPages
{
    public class TaskListBase : ComponentBase
    {
        [Inject]
        private ITaskService TaskService { get; set; }
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        public List<ProgrammingTask> Tasks { get; set; }

        [Parameter]
        public string ActualPage { get; set; }
        public int LastPage { get; set; }

        protected async override Task OnInitializedAsync()
        {
            int.TryParse(ActualPage, out int actualPage);
            Tasks = new List<ProgrammingTask>((await TaskService.GetProgrammingTasks(actualPage)));
        }

        protected void ClickCreateTask()
        {
            NavigationManager.NavigateTo("/tasks/create");
        }

        protected async Task TaskDeleted()
        {
            Tasks = (await TaskService.GetProgrammingTasks(1)).ToList() ;
        }

        protected async Task MovePage(string direction)
        {
            LastPage = await TaskService.GetLastPage();
            int.TryParse(ActualPage, out int actualPage);
            if (direction.ToLower() == "next" && actualPage < LastPage)
            {
                actualPage += 1;
            }
            else if (direction.ToLower() == "prev" && actualPage > 1)
            {
                actualPage -= 1;
            }
            Tasks = (await TaskService.GetProgrammingTasks(actualPage)).ToList();
            NavigationManager.NavigateTo($"/tasks/{actualPage}/page");
        }
    }
}
