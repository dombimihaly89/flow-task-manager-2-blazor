using FlowTaskManager.Web.Client.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowTaskManager.Web.Client.Modals
{
    public class ConfirmationBase : ComponentBase
    {
        public bool ShowModal = false;
        public string Title { get; set; }
        public string Content { get; set; }
        public string ActionButton { get; set; }
        public string CancelButton { get; set; }

        [Parameter]
        public EventCallback<bool> ModalClick { get; set; }

        public void Show()
        {
            ShowModal = true;
            StateHasChanged();
        }

        public async void Action(bool actionValue)
        {
            ShowModal = false;
            await ModalClick.InvokeAsync(actionValue);
        }
    }
}
