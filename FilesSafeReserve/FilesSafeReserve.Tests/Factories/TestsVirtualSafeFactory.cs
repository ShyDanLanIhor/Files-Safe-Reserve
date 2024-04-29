using FilesSafeReserve.Data.Models;

namespace FilesSafeReserve.Tests.Factories;

public abstract class TestsVirtualSafeFactory
{
    private static readonly Random random = new();

    public static List<VirtualSafeModel> CreateRandomList()
    {
        List<VirtualSafeModel> list = [];

        for (int i = 0; i < 10; i++)
        {
            list.Add(CreateRandom());
        }

        return list;
    }

    public static VirtualSafeModel CreateRandom()
    {
        var virtualSafeId = Guid.NewGuid();

        var virtualSafe = new VirtualSafeModel
        {
            Id = virtualSafeId,
            Name = GenerateRandomName(),
            Description = GenerateRandomDescription(),
            Path = $@"C:\Users\username\SafeFolder{Guid.NewGuid():N}",
            Details = GenerateRandomVirtualSafeDetails(virtualSafeId),
            Reservation = GenerateRandomReservation(virtualSafeId)
        };

        return virtualSafe;
    }

    private static string GenerateRandomName()
    {
        return $"SampleName {Guid.NewGuid():N}";
    }

    private static string GenerateRandomDescription()
    {
        return $"SampleDescription {Guid.NewGuid():N}";
    }

    private static string GenerateRandomPath()
    {
        return $@"C:\Users\username\file{Guid.NewGuid():N}";
    }

    private static VirtualSafeDetailsModel GenerateRandomVirtualSafeDetails(Guid virtualSafeId)
    {
        var virtualSafeDetailsId = Guid.NewGuid();

        var virtualSafeDetails = new VirtualSafeDetailsModel
        {
            Id = virtualSafeDetailsId,
            SafeId = virtualSafeId,
            CreatedTimestamp = DateTime.Now,
            UpdatedTimestamp = DateTime.Now,
            ReservedTimestamp = DateTime.Now
        };

        // Generate random logs
        for (int i = 0; i < 5; i++)
        {
            virtualSafeDetails.Logs.Add(GenerateRandomLog(virtualSafeDetailsId));
        }

        return virtualSafeDetails;
    }

    private static LogModel GenerateRandomLog(Guid virtualSafeDetailsId)
    {
        var logId = Guid.NewGuid();

        var log = new LogModel
        {
            Id = logId,
            StartTimestamp = DateTime.Now.AddHours(-random.Next(1, 24)),
            EndTimestamp = DateTime.Now,
            VirtualSafeDetailsId = virtualSafeDetailsId
        };

        // Generate random log operations
        for (int i = 0; i < 3; i++)
        {
            log.Operations.Add(GenerateRandomLogOperation(logId));
        }

        return log;
    }

    private static LogOperationModel GenerateRandomLogOperation(Guid logId)
    {
        var logOperationId = Guid.NewGuid();

        var logOperation = new LogOperationModel
        {
            Id = logOperationId,
            IsSucceeded = random.Next(0, 2) == 1,
            Type = (LogOperationModel.Types)random.Next(0, Enum.GetValues(typeof(LogOperationModel.Types)).Length),
            ItemPath = GenerateRandomPath(),
            PerformTimestamp = DateTime.Now.AddMinutes(-random.Next(1, 60)),
            LogId = logId
        };

        return logOperation;
    }

    private static ReservationModel GenerateRandomReservation(Guid virtualSafeId)
    {
        var reservationId = Guid.NewGuid();

        var reservation = new ReservationModel
        {
            Id = reservationId,
            SafeId = virtualSafeId,
        };

        // Generate random files and directories for reservation
        for (int i = 0; i < 3; i++)
        {
            reservation.Files.Add(GenerateRandomReservationFile(reservationId));
            reservation.Directories.Add(GenerateRandomReservationDirectory(reservationId));
        }

        return reservation;
    }

    private static FileModel GenerateRandomReservationFile(Guid reservationId)
    {
        var reservationFileId = Guid.NewGuid();

        var reservationFile = new FileModel
        {
            Id = reservationFileId,
            ReservationId = reservationId,
            Path = $"{GenerateRandomPath()}.extension",
        };

        return reservationFile;
    }

    private static DirectoryModel GenerateRandomReservationDirectory(Guid reservationId)
    {
        var reservationDirectoryId = Guid.NewGuid();

        var reservationDirectory = new DirectoryModel
        {
            Id = reservationDirectoryId,
            ReservationId = reservationId,
            Path = GenerateRandomPath(),
        };

        return reservationDirectory;
    }
}
