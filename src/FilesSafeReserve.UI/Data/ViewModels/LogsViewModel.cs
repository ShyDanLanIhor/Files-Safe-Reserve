using BlazorBootstrap;
using FilesSafeReserve.App.Models;

namespace FilesSafeReserve.UI.Data.ViewModels;

public class LogsViewModel
{
    public Modal NotFoundModal { get; set; } = default!;
    public Modal FilterProgress { get; set; } = default!;
    public Modal EmptySearchFieldModal { get; set; } = default!;

    public bool IsSearched { get; set; }
    public bool IsFiltered { get; set; }
    public bool IsShowFilter { get; set; }
    public string SearchText { get; set; } = string.Empty;
    public DateTime? StartTimestamp { get; set; }
    public DateTime? EndTimestamp { get; set; }

    public ICollection<LogModel> LogsList = [];
    public VirtualSafeModel? VirtualSafe { get; set; }

    public class FileLogsEntity
    {
        public required string Description { get; init; }
        public required IEnumerable<string> Operations { get; init; }
    }
}
