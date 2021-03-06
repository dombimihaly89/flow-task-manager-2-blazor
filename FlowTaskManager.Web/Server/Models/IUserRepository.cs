﻿using FlowTaskManager.Web.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowTaskManager.Web.Server.Models
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
    }
}
