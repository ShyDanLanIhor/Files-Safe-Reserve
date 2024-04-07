namespace ShyryiFileSystemLibrary.Exceptions;

/// <summary>
/// Represents an exception that is thrown when an error occurs during the renaming of a file system item.
/// </summary>
public class FileSystemItemRenamingException : ArgumentException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FileSystemItemRenamingException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public FileSystemItemRenamingException(string message) : base(message) { }
}

