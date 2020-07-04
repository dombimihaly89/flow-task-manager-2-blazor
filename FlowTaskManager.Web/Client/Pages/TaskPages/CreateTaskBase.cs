using FlowTaskManager.Web.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowTaskManager.Web.Client.Pages.TaskPages
{
    public class CreateTaskBase : ComponentBase
    {
        public ProgrammingTask Task { get; set; } = new ProgrammingTask();

        public void HandleValidSubmit()
        {

        }
    }
}
