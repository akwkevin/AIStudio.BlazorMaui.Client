using System.Threading.Tasks;
using AIStudio.Blazor.Common.Models;
using AIStudio.Blazor.Common.Services;
using Microsoft.AspNetCore.Components;

namespace AIStudio.Blazor.Common.Pages.Account.Settings
{
    public partial class BaseView
    {
        private CurrentUser _currentUser = new CurrentUser();

        [Inject] protected IUserService UserService { get; set; }

        private void HandleFinish()
        {
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _currentUser = await UserService.GetCurrentUserAsync();
        }
    }
}