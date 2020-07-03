using FlowTaskManager.Web.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowTaskManager.Web.Client.Pages.ProgrammingTaskPages
{
    public class DisplayTaskBase : ComponentBase
    {
        [Parameter]
        public ProgrammingTask Task { get; set; }
    }
}
