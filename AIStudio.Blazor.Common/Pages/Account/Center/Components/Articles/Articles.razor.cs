using System.Collections.Generic;
using AIStudio.Blazor.Common.Models;
using Microsoft.AspNetCore.Components;

namespace AIStudio.Blazor.Common.Pages.Account.Center
{
    public partial class Articles
    {
        [Parameter] public IList<ListItemDataType> List { get; set; }
    }
}