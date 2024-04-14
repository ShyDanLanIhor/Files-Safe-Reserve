using FluentAssertions;
using ShyryiFileSystemLibrary.Models;

namespace ShyryiFileSystemLibrary.Tests.Models;

/// <summary>
/// Contains test methods for the <see cref="DirectoryModel"/> class.
/// </summary>
public class DirectoryModelTests
{
    /// <summary>
    /// Tests the behavior of the <see cref="DirectoryModel.Path"/> property when an invalid path is provided.
    /// </summary>
    /// <param name="path">The invalid directory path.</param>
    [Theory]
    [InlineData(@"Users\username\Documents\")]
    [InlineData(@"C:\Users\username\Pictures\example>txt")]
    [InlineData(@"home/username/Documents/")]
    [InlineData(@"/Users/username/Documents/example|txt")]
    public void PathProperty_ThrowsException(string path)
    {
        // Arrange

        // Act
        var result = () =>
        {
            DirectoryModel file = new() { Path = path };
        };

        // Assert
        result.Should().Throw<Exception>();
    }

    /// <summary>
    /// Tests the behavior of the <see cref="DirectoryModel.Path"/> property when a valid path is provided.
    /// </summary>
    /// <param name="path">The valid directory path.</param>
    [Theory]
    [InlineData(@"C:\Users\username\Documents\")]
    [InlineData(@"C:\Users\username\Pictures")]
    [InlineData(@"/home/username/Documents/")]
    [InlineData(@"/home/username/Pictures")]
    public void PathProperty_SetsFolderPath(string path)
    {
        // Arrange
        DirectoryModel file = new() { Path = path };

        // Act
        var result = file.Path;

        // Assert
        result.Should().Be(path);
    }

    /// <summary>
    /// Tests the behavior of the <see cref="DirectoryModel.Name"/> property when retrieving the directory name.
    /// </summary>
    /// <param name="path">The directory path.</param>
    /// <param name="folderName">The expected directory name.</param>
    [Theory]
    [InlineData(@"C:\Users\username\Documents\example", "example")]
    [InlineData(@"/home/username/Documents/example", "example")]
    public void NameProperty_GetsFolderName(string path, string folderName)
    {
        // Arrange
        DirectoryModel file = new() { Path = path };

        // Act
        var result = file.Name;

        // Assert
        result.Should().Be(folderName);
    }

    /// <summary>
    /// Tests the behavior of the <see cref="DirectoryModel.Name"/> property when setting the directory name.
    /// </summary>
    /// <param name="prevPath">The previous directory path.</param>
    /// <param name="newPath">The expected new directory path after setting the directory name.</param>
    [Theory]
    [InlineData(@"C:\Users\username\Documents\example.txt", @"C:\Users\username\Documents\new")]
    [InlineData(@"/home/username/Documents/example.txt", @"/home/username/Documents/new")]
    public void NameProperty_SetsFolderName(string prevPath, string newPath)
    {
        // Arrange
        DirectoryModel file = prevPath;

        // Act
        file.Name = "new";
        var result = file.Path;

        // Assert
        result.Should().Be(newPath);
    }

    /// <summary>
    /// Tests the behavior of the <see cref="DirectoryModel.Name"/> property when an invalid directory name is provided.
    /// </summary>
    /// <param name="path">The directory path.</param>
    /// <param name="fileName">The invalid directory name.</param>
    [Theory]
    [InlineData(@"C:\Users\username\Pictures\example.jpg", @"n/ew")]
    [InlineData(@"C:\Users\username\Videos\example.mp4", @"n\ew")]
    [InlineData(@"/home/username/Documents/example.txt", @"n>ew")]
    [InlineData(@"/home/username/Pictures/example.jpg", @"n<ew")]
    [InlineData(@"/home/username/Videos/example.mp4", @"n?ew")]
    [InlineData(@"/Users/username/Documents/example.txt", @"n*ew")]
    [InlineData(@"/Users/username/Pictures/example.jpg", @"n:ew")]
    [InlineData(@"/Users/username/Movies/example.mp4", @"n|ew")]
    public void NameProperty_ThrowsException(string path, string fileName)
    {
        // Arrange
        DirectoryModel file = new() { Path = path };

        // Act
        var result = () =>
        {
            file.Name = fileName;
        };

        // Assert
        result.Should().Throw<Exception>();
    }

    /// <summary>
    /// Tests the behavior of the <see cref="DirectoryModel.PrevDirectory"/> property when retrieving the previous directory.
    /// </summary>
    /// <param name="filePath">The directory path.</param>
    /// <param name="prevDirectoryPath">The expected previous directory path.</param>
    [Theory]
    [InlineData(@"C:\Users\username\Documents\example", @"C:\Users\username\Documents")]
    [InlineData(@"C:\Users\username\Pictures\example",  @"C:\Users\username\Pictures")]
    [InlineData(@"C:\Users\username\Videos\example",    @"C:\Users\username\Videos")]
    [InlineData(@"/home/username/Documents/example",    @"/home/username/Documents")]
    [InlineData(@"/home/username/Pictures/example",     @"/home/username/Pictures")]
    [InlineData(@"/home/username/Videos/example",       @"/home/username/Videos")]
    public void PrevDirectoryProperty_GetsDirectoryModel(string filePath, string prevDirectoryPath)
    {
        // Arrange
        DirectoryModel file = new() { Path = filePath };

        // Act
        var result = file.PrevDirectory;

        // Assert
        result.Path.Should().Be(prevDirectoryPath);
    }
}
