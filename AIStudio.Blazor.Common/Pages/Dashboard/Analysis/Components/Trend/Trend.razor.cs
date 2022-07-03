using Microsoft.AspNetCore.Components;

namespace AIStudio.Blazor.Common.Pages.Dashboard.Analysis
{
    public partial class Trend
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string Flag { get; set; }
    }
}