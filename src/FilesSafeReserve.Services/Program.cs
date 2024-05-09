using FilesSafeReserve.Infra.DataBase;
using FilesSafeReserve.Infra.Repositories.IRepositories;
using FilesSafeReserve.Infra.Repositories;
using FilesSafeReserve.Services.Worker;
using FilesSafeReserve.App.Builders.IBuilders;
using FilesSafeReserve.Infra.Builders;

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

builder.Services.AddScoped<ILogBuilder, LogBuilder>();

builder.Services.AddHostedService<ReservationWorker>();

var host = builder.Build();
host.Run();
