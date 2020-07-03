using FlowTaskManager.Web.Client.Services;
using FlowTaskManager.Web.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FlowTaskManager.Web.Client.Pages
{
    public class UserListBase : ComponentBase
    {
        [Inject]
        public IUserService userService { get; set; }

        public List<User> Users { get; set; }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            Users = new List<User>(await userService.GetUsers());
        }
    }
}
