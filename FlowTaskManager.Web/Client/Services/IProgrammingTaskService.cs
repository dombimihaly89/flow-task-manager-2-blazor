﻿using FlowTaskManager.Web.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowTaskManager.Web.Client.Services
{
    public interface IProgrammingTaskService
    {
        Task<IEnumerable<ProgrammingTask>> GetProgrammingTasks();
    }
}
