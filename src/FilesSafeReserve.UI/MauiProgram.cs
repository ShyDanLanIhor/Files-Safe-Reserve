using CommunityToolkit.Maui.Core;
using FilesSafeReserve.App.Services.IServices;
using FilesSafeReserve.Infra.Configs;
using FilesSafeReserve.Infra.DataBase;
using FilesSafeReserve.Infra.Repositories;
using FilesSafeReserve.Infra.Repositories.IRepositories;
using FilesSafeReserve.Infra.Services;
using FilesSafeReserve.Infra.Services.IServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace FilesSafeReserve.UI;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        var basePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\..\\..\\..\\FilesSafeReserve.Infra"));
        var config = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var appDataConfig = config.GetRequiredSection("AppData").Get<AppDataConfig>();

        builder.Configuration.AddConfiguration(config);

        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkitCore()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddBlazorBootstrap();

        builder.Services.AddSingleton<IDbService, DbService>();
        builder.Services.AddSingleton<IAppService, AppService>();
        builder.Services.AddSingleton<IFileOpenerService, FileOpenerService>();
        builder.Services.AddSingleton<ILoggerService, LoggerService>();

        builder.Services.AddSingleton<IVirtualSafeRepo, VirtualSafeRepo>();
        builder.Services.AddSingleton<ILogRepo, LogRepo>();
        builder.Services.AddSingleton<ILogOperationRepo, LogOperationRepo>();
        builder.Services.AddSingleton<IFileRepo, FileRepo>();
        builder.Services.AddSingleton<IDirectoryRepo, DirectoryRepo>();

        builder.Services.AddDbContext<FsrDbContext>();
        builder.Services.AddTransient<MainPage>();

        var appService = new AppService();
        appService.EnsureCreatedDocumentsDirectory(appDataConfig!.AppName);

        var dbContext = new FsrDbContext(new(), config);
        dbContext.Database.EnsureCreated();
        dbContext.Dispose();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
