using FlowTaskManager.Web.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowTaskManager.Web.Server.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
    }
}
