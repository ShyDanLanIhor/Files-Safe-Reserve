using FilesSafeReserve.App.Interfaces.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilesSafeReserve.App.Models;

[Table("RemovableDrive")]
public class RemovableDriveModel : IModelBase<Guid>
{
    /// <summary>
    /// Gets or sets the unique identifier of the virtual safe.
    /// </summary>
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string VolumeLabel { get; set; } = string.Empty;

    [NotMapped]
    public DriveInfo Info { get => new(Name); }

    /// <summary>
    /// Gets or sets the unique identifier of the associated virtual safe details.
    /// </summary>
    public Guid VirtualSafeDetailsId { get; set; }

    /// <summary>
    /// Gets or sets the associated virtual safe details.
    /// The default value is `null`.
    /// </summary>
    public VirtualSafeDetailsModel VirtualSafeDetails { get; set; } = null!;
}
