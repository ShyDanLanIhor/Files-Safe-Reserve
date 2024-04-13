using FilesSafeReserve.Data.Models;

namespace FilesSafeReserve.Data.ViewModels;

public class SafesListViewModel
{
    public List<VirtualSafeModel> VirtualSafes { get; set; } = new();
}
