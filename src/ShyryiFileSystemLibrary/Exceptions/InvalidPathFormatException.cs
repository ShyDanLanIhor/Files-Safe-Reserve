namespace ShyryiFileSystemLibrary.Exceptions;

[Serializable]
public class InvalidPathFormatException : Exception
{
    public InvalidPathFormatException()
    {
    }

    public InvalidPathFormatException(string? message) : base(message)
    {
    }

    public InvalidPathFormatException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}