using BlazorBootstrap;
using FilesSafeReserve.App.Models;
using FilesSafeReserve.App.Watchers;
using FilesSafeReserve.UI.Data.Entities.Forms;
using Microsoft.AspNetCore.Components.Forms;

namespace FilesSafeReserve.UI.Data.ViewModels;

public class CopySafeViewModel : IDisposable
{
    public FileSystemWatcher FileSystemWatcher = new();
    public DriveWatcher DriveWatcher = new();

    public Modal CopyingProgress { get; set; } = default!;
    public Modal ConfirmCopying { get; set; } = default!;
    public Modal CopyingCompleted { get; set; } = default!;
    public Modal NotFoundModal { get; set; } = default!;
    public Modal DuplicateModal { get; set; } = default!;
    public Modal CannotCopyContentModal { get; set; } = default!;
    public Modal CannotDeletePrevSafeModal { get; set; } = default!;
    public EditContext EditContext { get; set; }

    public bool IsRemovable { get; set; }
    public bool IsDeleteOriginalSafe {  get; set; }
    public bool IsCopyOriginalSafeInnerContent {  get; set; }

    public VirtualSafeForm NewVirtualSafe { get; set; } = new();

    public VirtualSafeModel? PrevVirtualSafe { get; set; }

    public CopySafeViewModel()
    {
        EditContext = new(NewVirtualSafe);
    }

    public void Dispose()
    {
        FileSystemWatcher.Dispose();
        DriveWatcher.Dispose();
    }
}
