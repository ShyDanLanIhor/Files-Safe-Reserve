namespace ShyryiFileSystemLibrary.Exceptions;

/// <summary>
/// Represents an exception that is thrown when a path has an invalid format.
/// </summary>
public class InvalidPathFormatException : IOException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidPathFormatException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public InvalidPathFormatException(string message) : base(message) { }
}

