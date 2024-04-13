using FilesSafeReserve.Data.Configs;
using FilesSafeReserve.Data.DataBase;
using FilesSafeReserve.Data.Repositories;
using FilesSafeReserve.Data.Repositories.IRepositories;
using FilesSafeReserve.Data.Services;
using FilesSafeReserve.Data.Services.IServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace FilesSafeReserve;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        var a = Assembly.GetExecutingAssembly();
        using var stream = a.GetManifestResourceStream("FilesSafeReserve.appsettings.json");

        var config = new ConfigurationBuilder()
                    .AddJsonStream(stream)
                    .Build();

        var appDataConfig = config.GetRequiredSection("AppData").Get<AppDataConfig>();

        builder.Configuration.AddConfiguration(config);

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddBlazorBootstrap();

        builder.Services.AddSingleton<IDbService, DbService>();
        builder.Services.AddSingleton<IAppService, AppService>();
        builder.Services.AddSingleton<IVirtualSafeRepo, VirtualSafeRepo>();

        builder.Services.AddDbContext<FsrDbContext>();
        builder.Services.AddTransient<MainPage>();

        var appService = new AppService();
        appService.EnsureCreatedDocumentsDirectory(appDataConfig.AppName);

        var dbContext = new FsrDbContext(new(),config);
        dbContext.Database.EnsureCreated();
        dbContext.Dispose();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
