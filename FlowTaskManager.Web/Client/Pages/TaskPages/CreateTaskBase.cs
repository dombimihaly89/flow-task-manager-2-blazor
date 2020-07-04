﻿using FlowTaskManager.Web.Client.Services;
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
        private TaskService TaskService { get; set; }
        public ProgrammingTask Task { get; set; } = new ProgrammingTask();

        public async void HandleValidSubmit()
        {
            
        }
        public void ClickCancel()
        {
            NavigationManager.NavigateTo("/tasks");
        }
    }
}
