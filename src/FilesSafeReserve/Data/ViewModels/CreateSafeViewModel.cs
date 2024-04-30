using BlazorBootstrap;
using FilesSafeReserve.Data.Entities.Forms;
using Microsoft.AspNetCore.Components.Forms;

namespace FilesSafeReserve.Data.ViewModels;

public class CreateSafeViewModel
{
    public Modal SuccessModal { get; set; } = default!;
    public Modal DuplicateModal { get; set; } = default!;

    public EditContext EditContext { get; set; }

    public VirtualSafeForm VirtualSafe { get; set; } = new();

    public CreateSafeViewModel()
    {
        EditContext = new(VirtualSafe);
    }
}
