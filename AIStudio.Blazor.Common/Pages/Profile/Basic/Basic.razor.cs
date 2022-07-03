using System.Threading.Tasks;
using AIStudio.Blazor.Common.Models;
using AIStudio.Blazor.Common.Services;
using Microsoft.AspNetCore.Components;

namespace AIStudio.Blazor.Common.Pages.Profile
{
    public partial class Basic
    {
        private BasicProfileDataType _data = new BasicProfileDataType();

        [Inject] protected IProfileService ProfileService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _data = await ProfileService.GetBasicAsync();
        }
    }
}