using FilesSafeReserve.App.Builders.IBuilders;
using FilesSafeReserve.App.Entities.Params.ILogBuilder;
using FilesSafeReserve.App.Models;
using FilesSafeReserve.Domain.Extensions;
using FilesSafeReserve.Infra.Builders;
using FilesSafeReserve.Infra.Extensions;
using FilesSafeReserve.Infra.Repositories;
using FilesSafeReserve.Infra.Repositories.IRepositories;

namespace FilesSafeReserve.Services.Worker;

/// <summary>
/// Represents a background service for handling reservations.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="ReservationWorker"/> class.
/// </remarks>
/// <param name="logger">The logger instance.</param>
/// <param name="serviceProvider">The service provider instance.</param>
public class ReservationWorker(ILogger<ReservationWorker> logger, IServiceProvider serviceProvider) : BackgroundService
{
    private const int second = 1000;
    private const int minute = 60 * second;

    private readonly ILogger<ReservationWorker> _logger = logger;
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    /// <summary>
    /// Starts the reservation worker asynchronously.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public override Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Reservation worker started at: {time}", DateTimeOffset.Now);
        return base.StartAsync(cancellationToken);
    }

    /// <summary>
    /// Executes the reservation worker asynchronously.
    /// </summary>
    /// <param name="stoppingToken">The stopping token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var timeOfDay = DateTime.Now.TimeOfDay;

            using var scope = _serviceProvider.CreateScope();
            var services = scope.ServiceProvider;

            var reservationRepo = services.GetService<IReservationRepo>();
            var logRepo = services.GetService<ILogRepo>();
            var logBuilder = services.GetService<ILogBuilder>();

            if (reservationRepo is null || logBuilder is null || logRepo is null)
                _logger.LogInformation("Service provider returned null running at: {time}", DateTimeOffset.Now);
            else
            {
                var reservations = await reservationRepo.ToListAsync();

                var selectedReservation = reservations
                                            .Where(el => el.ReservedTimestamp.Date != DateTime.Now.Date)
                                            .Where(el => el.ToReserveTimeSpan < DateTime.Now.TimeOfDay)
                                            .Where(el => el.ToReserveTimeSpan != TimeSpan.Zero);

                foreach (var reservation in selectedReservation)
                {
                    await logBuilder
                            .WithDelegate(reservation.Patheds
                                .Select(el => new Action(() => el.CopyToAsSub(reservation.Safe.Path))))
                            .WithParameters(new()
                            {
                                VirtualSafeDetailsId = reservation.Safe.Details.Id,
                                Operations = reservation.Patheds
                                    .Select(el => new LogBuilderOpsParams.OperationsParams()
                                    {
                                        ItemPath = el.Path,
                                        Type = LogOperationModel.Types.TransferToVirtualSafe
                                    })
                                    .ToList()
                            })
                            .Build()
                            .LogResultAsync(logRepo);

                    reservation.ReservedTimestamp = DateTime.Now;

                    await reservationRepo.UpdateAsync(reservation);

                    _logger.LogInformation("Reservation worker reserved virtual safe '{name}' running at: {time}", reservation.Safe.Name, DateTimeOffset.Now);
                }

                _logger.LogInformation("Reservation worker running at: {time}", DateTimeOffset.Now);
            }

            await Task.Delay(10 * minute, stoppingToken);
        }
    }

    /// <summary>
    /// Stops the reservation worker asynchronously.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public override Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Reservation worker stopped at: {time}", DateTimeOffset.Now);
        return base.StopAsync(cancellationToken);
    }
}
