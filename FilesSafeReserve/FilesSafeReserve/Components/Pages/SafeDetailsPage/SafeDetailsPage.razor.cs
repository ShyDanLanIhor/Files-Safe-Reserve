using Microsoft.AspNetCore.Components;

namespace FilesSafeReserve.Components.Pages.SafeDetailsPage;
public partial class SafeDetailsPage : ComponentBase
{
    [Parameter]
    public required string Id { get; set; }
}
