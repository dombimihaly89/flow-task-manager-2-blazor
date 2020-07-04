﻿using FlowTaskManager.Web.Client.Services;
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
        private ITaskService ProgrammingTaskService { get; set; }
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        public List<ProgrammingTask> Tasks { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Tasks = new List<ProgrammingTask>((await ProgrammingTaskService.GetProgrammingTasks()));
        }

        protected void ClickCreateTask()
        {
            NavigationManager.NavigateTo("/tasks/create");
        }
    }
}
