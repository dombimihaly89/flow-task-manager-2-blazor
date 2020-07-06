using FlowTaskManager.Web.Client.Modals;
using FlowTaskManager.Web.Client.Services;
using FlowTaskManager.Web.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public ConfirmationBase DeleteConfirmation { get; set; }
        [Parameter]
        public EventCallback<bool> TaskDeletion { get; set; }
        
        public async void ClickDelete()
        {
            DeleteConfirmation.Title = "Delete Task";
            DeleteConfirmation.Content = "Are you sure you want to delete this task?";
            DeleteConfirmation.ActionButton = "Delete";
            DeleteConfirmation.CancelButton = "Cancel";
            DeleteConfirmation.Show();
        }

        public async void ClickUpdate()
        {
            NavigationManager.NavigateTo($"/tasks/create/{Task.Id}");
        }

        public async void DeleteModalResult(bool actionValue)
        {
            if (actionValue)
            {
                await TaskService.DeleteProgrammingTask(Task.Id);
                await TaskDeletion.InvokeAsync(true);
            }
        }
    }
}
