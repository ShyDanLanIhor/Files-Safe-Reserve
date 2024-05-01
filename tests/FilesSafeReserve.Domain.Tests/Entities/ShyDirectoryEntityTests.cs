using FilesSafeReserve.Domain.Entities;
using FluentAssertions;

namespace FilesSafeReserve.Domain.Tests.Entities;

/// <summary>
/// Contains test methods for the <see cref="ShyDirectoryEntity"/> class.
/// </summary>
public class ShyDirectoryEntityTests
{
    /// <summary>
    /// Tests the behavior of the <see cref="ShyDirectoryEntity.Path"/> property when an invalid path is provided.
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
            ShyDirectoryEntity directory = new() { Path = path };
        };

        // Assert
        result.Should().Throw<Exception>();
    }

    /// <summary>
    /// Tests the behavior of the <see cref="ShyDirectoryEntity.Path"/> property when a valid path is provided.
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
        ShyDirectoryEntity directory = new() { Path = path };

        // Act
        var result = directory.Path;

        // Assert
        result.Should().Be(path);
    }

    /// <summary>
    /// Tests the behavior of the <see cref="ShyDirectoryEntity.Name"/> property when retrieving the directory name.
    /// </summary>
    /// <param name="path">The directory path.</param>
    /// <param name="folderName">The expected directory name.</param>
    [Theory]
    [InlineData(@"C:\Users\username\Documents\example", "example")]
    [InlineData(@"/home/username/Documents/example", "example")]
    public void NameProperty_GetsFolderName(string path, string folderName)
    {
        // Arrange
        ShyDirectoryEntity directory = new() { Path = path };

        // Act
        var result = directory.Name;

        // Assert
        result.Should().Be(folderName);
    }

    /// <summary>
    /// Tests the behavior of the <see cref="ShyDirectoryEntity.Name"/> property when setting the directory name.
    /// </summary>
    /// <param name="prevPath">The previous directory path.</param>
    /// <param name="newPath">The expected new directory path after setting the directory name.</param>
    [Theory]
    [InlineData(@"C:\Users\username\Documents\example.txt", @"C:\Users\username\Documents\new")]
    [InlineData(@"/home/username/Documents/example.txt", @"/home/username/Documents/new")]
    public void NameProperty_SetsFolderName(string prevPath, string newPath)
    {
        // Arrange
        ShyDirectoryEntity directory = prevPath;

        // Act
        directory.Name = "new";
        var result = directory.Path;

        // Assert
        result.Should().Be(newPath);
    }

    /// <summary>
    /// Tests the behavior of the <see cref="ShyDirectoryEntity.Name"/> property when an invalid directory name is provided.
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
        ShyDirectoryEntity directory = new() { Path = path };

        // Act
        var result = () =>
        {
            directory.Name = fileName;
        };

        // Assert
        result.Should().Throw<Exception>();
    }
}
