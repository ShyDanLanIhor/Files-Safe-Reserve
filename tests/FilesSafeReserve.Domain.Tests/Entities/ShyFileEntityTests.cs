using FilesSafeReserve.Domain.Entities;
using FluentAssertions;

namespace FilesSafeReserve.Domain.Tests.Entities;

/// <summary>
/// Contains test methods for the <see cref="ShyFileEntity"/> class.
/// </summary>
public class ShyFileEntityTests
{
    /// <summary>
    /// Tests the behavior of the <see cref="ShyFileEntity.Path"/> property when an invalid path is provided.
    /// </summary>
    /// <param name="path">The invalid file path.</param>
    [Theory]
    [InlineData(@"Users\username\Documents\example.txt")]
    [InlineData(@"C:\Users\username\Pictures\")]
    [InlineData(@"home/username/Documents/")]
    [InlineData(@"/Users/username/Documents/")]
    public void PathProperty_ThrowsException(string path)
    {
        // Arrange

        // Act
        var result = () =>
        {
            ShyFileEntity file = new() { Path = path };
        };

        // Assert
        result.Should().Throw<Exception>();
    }

    /// <summary>
    /// Tests the behavior of the <see cref="ShyFileEntity.Path"/> property when a valid path is provided.
    /// </summary>
    /// <param name="path">The valid file path.</param>
    [Theory]
    [InlineData(@"C:\Users\username\Documents\example.txt")]
    [InlineData(@"C:\Users\username\Pictures\example.jpg")]
    [InlineData(@"C:\Users\username\Videos\example.mp4")]
    [InlineData(@"/home/username/Documents/example.txt")]
    [InlineData(@"/home/username/Pictures/example.jpg")]
    [InlineData(@"/home/username/Videos/example.mp4")]
    public void PathProperty_SetsFilePath(string path)
    {
        // Arrange
        ShyFileEntity file = new() { Path = path };

        // Act
        var result = file.Path;

        // Assert
        result.Should().Be(path);
    }

    /// <summary>
    /// Tests the behavior of the <see cref="ShyFileEntity.Name"/> property when retrieving the file name.
    /// </summary>
    /// <param name="path">The file path.</param>
    /// <param name="fileName">The expected file name.</param>
    [Theory]
    [InlineData(@"C:\Users\username\Documents\example.txt", "example")]
    [InlineData(@"C:\Users\username\Pictures\example.jpg", "example")]
    [InlineData(@"C:\Users\username\Videos\example.mp4", "example")]
    [InlineData(@"/home/username/Documents/example.txt", "example")]
    [InlineData(@"/home/username/Pictures/example.jpg", "example")]
    [InlineData(@"/home/username/Videos/example.mp4", "example")]
    public void NameWithoutExtensionProperty_GetsFileName(string path, string fileName)
    {
        // Arrange
        ShyFileEntity file = new() { Path = path };

        // Act
        var result = file.NameWithoutExtension;

        // Assert
        result.Should().Be(fileName);
    }

    /// <summary>
    /// Tests the behavior of the <see cref="ShyFileEntity.Name"/> property when setting the file name.
    /// </summary>
    /// <param name="prevPath">The previous file path.</param>
    /// <param name="newPath">The expected new file path after setting the file name.</param>
    [Theory]
    [InlineData(@"C:\Users\username\Documents\example.txt", @"C:\Users\username\Documents\new.txt")]
    [InlineData(@"C:\Users\username\Pictures\example.jpg", @"C:\Users\username\Pictures\new.jpg")]
    [InlineData(@"C:\Users\username\Videos\example.mp4", @"C:\Users\username\Videos\new.mp4")]
    [InlineData(@"/home/username/Documents/example.txt", @"/home/username/Documents/new.txt")]
    [InlineData(@"/home/username/Pictures/example.jpg", @"/home/username/Pictures/new.jpg")]
    [InlineData(@"/home/username/Videos/example.mp4", @"/home/username/Videos/new.mp4")]
    public void NameWithoutExtensionProperty_SetsFileName(string prevPath, string newPath)
    {
        // Arrange
        ShyFileEntity file = prevPath;

        // Act
        file.NameWithoutExtension = "new";
        var result = file.Path;

        // Assert
        result.Should().Be(newPath);
    }

    /// <summary>
    /// Tests the behavior of the <see cref="ShyFileEntity.Name"/> property when an invalid file name is provided.
    /// </summary>
    /// <param name="path">The file path.</param>
    /// <param name="fileName">The invalid file name.</param>
    [Theory]
    [InlineData(@"C:\Users\username\Documents\example.txt", @"n.ew")]
    [InlineData(@"C:\Users\username\Pictures\example.jpg", @"n/ew")]
    [InlineData(@"C:\Users\username\Videos\example.mp4", @"n\ew")]
    [InlineData(@"/home/username/Documents/example.txt", @"n>ew")]
    [InlineData(@"/home/username/Pictures/example.jpg", @"n<ew")]
    [InlineData(@"/home/username/Videos/example.mp4", @"n?ew")]
    [InlineData(@"/Users/username/Documents/example.txt", @"n*ew")]
    [InlineData(@"/Users/username/Pictures/example.jpg", @"n:ew")]
    [InlineData(@"/Users/username/Movies/example.mp4", @"n|ew")]
    public void NameWithoutExtensionProperty_ThrowsException(string path, string fileName)
    {
        // Arrange
        ShyFileEntity file = new() { Path = path };

        // Act
        var result = () =>
        {
            file.NameWithoutExtension = fileName;
        };

        // Assert
        result.Should().Throw<Exception>();
    }

    /// <summary>
    /// Tests the behavior of the <see cref="ShyFileEntity.NameWithExtension"/> property when retrieving the file name with extension.
    /// </summary>
    /// <param name="path">The file path.</param>
    /// <param name="fileNameWithExtension">The expected file name with extension.</param>
    [Theory]
    [InlineData(@"C:\Users\username\Documents\example.txt", "example.txt")]
    [InlineData(@"C:\Users\username\Pictures\example.jpg", "example.jpg")]
    [InlineData(@"C:\Users\username\Videos\example.mp4", "example.mp4")]
    [InlineData(@"/home/username/Documents/example.txt", "example.txt")]
    [InlineData(@"/home/username/Pictures/example.jpg", "example.jpg")]
    [InlineData(@"/home/username/Videos/example.mp4", "example.mp4")]
    public void NameProperty_GetsFileNameWithExtension(string path, string fileNameWithExtension)
    {
        // Arrange
        ShyFileEntity file = new() { Path = path };

        // Act
        var result = file.Name;

        // Assert
        result.Should().Be(fileNameWithExtension);
    }

    /// <summary>
    /// Tests the behavior of the <see cref="ShyFileEntity.NameWithExtension"/> property when setting the file name with extension.
    /// </summary>
    /// <param name="prevPath">The previous file path.</param>
    /// <param name="newPath">The expected new file path after setting the file name with extension.</param>
    [Theory]
    [InlineData(@"C:\Users\username\Documents\example.txt", @"C:\Users\username\Documents\new.txt")]
    [InlineData(@"C:\Users\username\Pictures\example.jpg", @"C:\Users\username\Pictures\new.jpg")]
    [InlineData(@"C:\Users\username\Videos\example.mp4", @"C:\Users\username\Videos\new.mp4")]
    [InlineData(@"/home/username/Documents/example.txt", @"/home/username/Documents/new.txt")]
    [InlineData(@"/home/username/Pictures/example.jpg", @"/home/username/Pictures/new.jpg")]
    [InlineData(@"/home/username/Videos/example.mp4", @"/home/username/Videos/new.mp4")]
    public void NameProperty_SetsFileNameWithExtension(string prevPath, string newPath)
    {
        // Arrange
        ShyFileEntity file = new() { Path = prevPath };
        var extension = file.Path[file.Path.LastIndexOf('.')..];

        // Act
        file.Name = $"new{extension}";
        var result = file.Path;

        // Assert
        result.Should().Be(newPath);
    }

    /// <summary>
    /// Tests the behavior of the <see cref="ShyFileEntity.NameWithExtension"/> property when an invalid file name with extension is provided.
    /// </summary>
    /// <param name="path">The file path.</param>
    /// <param name="fileNameWithExtension">The invalid file name with extension.</param>
    [Theory]
    [InlineData(@"C:\Users\username\Documents\example.txt", @"n.ew.txt")]
    [InlineData(@"C:\Users\username\Pictures\example.jpg", @"n/ew.jpg")]
    [InlineData(@"C:\Users\username\Videos\example.mp4", @"n\ew.mp4")]
    [InlineData(@"/home/username/Documents/example.txt", @"n>ew.txt")]
    [InlineData(@"/home/username/Pictures/example.jpg", @"n<ew.jpg")]
    [InlineData(@"/home/username/Videos/example.mp4", @"n?ew.mp4")]
    [InlineData(@"/Users/username/Documents/example.txt", @"n*ew.txt")]
    [InlineData(@"/Users/username/Pictures/example.jpg", @"n:ew.jpg")]
    [InlineData(@"/Users/username/Movies/example.mp4", @"n|ew.mp4")]
    public void NameProperty_ThrowsException(string path, string fileNameWithExtension)
    {
        // Arrange
        ShyFileEntity file = new() { Path = path };

        // Act
        var result = () =>
        {
            file.Name = fileNameWithExtension;
        };

        // Assert
        result.Should().Throw<Exception>();
    }

    /// <summary>
    /// Tests the behavior of the <see cref="ShyFileEntity.Extension"/> property when retrieving the file extension.
    /// </summary>
    /// <param name="path">The file path.</param>
    /// <param name="fileExtension">The expected file extension.</param>
    [Theory]
    [InlineData(@"C:\Users\username\Documents\example.txt", ".txt")]
    [InlineData(@"C:\Users\username\Pictures\example.jpg", ".jpg")]
    [InlineData(@"C:\Users\username\Videos\example.mp4", ".mp4")]
    [InlineData(@"/home/username/Documents/example.txt", ".txt")]
    [InlineData(@"/home/username/Pictures/example.jpg", ".jpg")]
    [InlineData(@"/home/username/Videos/example.mp4", ".mp4")]
    public void ExtensionProperty_GetsFileExtension(string path, string fileExtension)
    {
        // Arrange
        ShyFileEntity file = new() { Path = path };

        // Act
        var result = file.Extension;

        // Assert
        result.Should().Be(fileExtension);
    }

    /// <summary>
    /// Tests the behavior of the <see cref="ShyFileEntity.Extension"/> property when setting the file extension.
    /// </summary>
    /// <param name="prevPath">The previous file path.</param>
    /// <param name="newPath">The expected new file path after setting the file extension.</param>
    [Theory]
    [InlineData(@"C:\Users\username\Documents\example.txt", @"C:\Users\username\Documents\example.NewExtension")]
    [InlineData(@"C:\Users\username\Pictures\example.jpg", @"C:\Users\username\Pictures\example.NewExtension")]
    [InlineData(@"C:\Users\username\Videos\example.mp4", @"C:\Users\username\Videos\example.NewExtension")]
    [InlineData(@"/home/username/Documents/example.txt", @"/home/username/Documents/example.NewExtension")]
    [InlineData(@"/home/username/Pictures/example.jpg", @"/home/username/Pictures/example.NewExtension")]
    [InlineData(@"/home/username/Videos/example.mp4", @"/home/username/Videos/example.NewExtension")]
    public void ExtensionProperty_SetsFileExtension(string prevPath, string newPath)
    {
        // Arrange
        ShyFileEntity file = prevPath;

        // Act
        file.Extension = "NewExtension";
        var result = file.Path;

        // Assert
        result.Should().Be(newPath);
    }

    /// <summary>
    /// Tests the behavior of the <see cref="ShyFileEntity.Extension"/> property when an invalid file extension is provided.
    /// </summary>
    /// <param name="path">The file path.</param>
    /// <param name="fileExtension">The invalid file extension.</param>
    [Theory]
    [InlineData(@"C:\Users\username\Documents\example.txt", @"n.ew")]
    [InlineData(@"C:\Users\username\Pictures\example.jpg", @"n/ew")]
    [InlineData(@"C:\Users\username\Videos\example.mp4", @"n\ew")]
    [InlineData(@"/home/username/Documents/example.txt", @"n>ew")]
    [InlineData(@"/home/username/Pictures/example.jpg", @"n<ew")]
    [InlineData(@"/home/username/Videos/example.mp4", @"n?ew")]
    [InlineData(@"/Users/username/Documents/example.txt", @"n*ew")]
    [InlineData(@"/Users/username/Pictures/example.jpg", @"n:ew")]
    [InlineData(@"/Users/username/Movies/example.mp4", @"n|ew")]
    public void ExtensionProperty_ThrowsException(string path, string fileExtension)
    {
        // Arrange
        ShyFileEntity file = new() { Path = path };

        // Act
        var result = () =>
        {
            file.Extension = fileExtension;
        };

        // Assert
        result.Should().Throw<Exception>();
    }
}
