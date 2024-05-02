using FilesSafeReserve.App.Services.IServices;
using FilesSafeReserve.Infra.DataBase;
using FilesSafeReserve.Infra.Repositories.IRepositories;
using FilesSafeReserve.Infra.Repositories;
using FilesSafeReserve.Infra.Services;
using FilesSafeReserve.Services.Worker;

var builder = Host.CreateApplicationBuilder(args);

var basePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\..\\FilesSafeReserve.Infra"));

var config = new ConfigurationBuilder()
                        .SetBasePath(basePath)
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .Build();

builder.Configuration.AddConfiguration(config);

builder.Services.AddDbContext<FsrDbContext>();

builder.Services.AddScoped<ILogRepo, LogRepo>();
builder.Services.AddScoped<IReservationRepo, ReservationRepo>();

builder.Services.AddScoped<ILoggerService, LoggerService>();

builder.Services.AddHostedService<ReservationWorker>();

var host = builder.Build();
host.Run();
