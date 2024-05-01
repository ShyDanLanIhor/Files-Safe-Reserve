namespace FilesSafeReserve.Domain.Exceptions;

[Serializable]
public class FsRenamingException : Exception
{
    public FsRenamingException()
    {
    }

    public FsRenamingException(string? message) : base(message)
    {
    }

    public FsRenamingException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}