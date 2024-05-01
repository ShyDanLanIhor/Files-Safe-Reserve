using System.ComponentModel.DataAnnotations;

namespace FilesSafeReserve.UI.Data.Entities.Forms;

/// <summary>
/// Represents a virtual safe form.
/// </summary>
public class VirtualSafeForm
{
    /// <summary>
    /// Gets or sets the name of the safe.
    /// </summary>
    [Required(ErrorMessage = "Safe name cannot be empty.")]
    [RegularExpression(@"[\p{L}\d\s]+", ErrorMessage = "Safe name can contain only letters, numbers, and spaces.")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description of the safe.
    /// </summary>
    [Required(ErrorMessage = "Safe description cannot be empty.")]
    [RegularExpression(@"[\p{L}\d\s]+", ErrorMessage = "Safe description can contain only letters, numbers, and spaces.")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the path of the safe.
    /// </summary>
    [Required(ErrorMessage = "Safe path cannot be empty.")]
    [RegularExpression(@"^([a-zA-Z]:\\)([^\\/:*?""<>|\r\n]+\\)*[^\\/:*?""<>|\r\n]*$|^/([^\\/:*?""<>|\r\n]+/)*[^\\/:*?""<>|\r\n]*$", ErrorMessage = "Safe path does not match pattern.")]
    public string Path { get; set; } = string.Empty;
}
