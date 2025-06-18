using MauiAgenda.Services;
using MauiAgenda.ViewModels;
using MauiAgenda.Views; 
using Microsoft.Extensions.Logging;

namespace MauiAgenda;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<ApiService>();

        builder.Services.AddSingleton<TasksViewModel>();
        builder.Services.AddTransient<AddEditTaskViewModel>();

        builder.Services.AddTransient<TaskListPage>();
        builder.Services.AddTransient<AddEditTaskPage>();
        builder.Services.AddSingleton<MainTabbedPage>();

        return builder.Build();
    }
}