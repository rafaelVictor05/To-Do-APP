using MauiAgenda.Services;
using MauiAgenda.ViewModels;
using MauiAgenda.Views; // Certifique-se que este using existe
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

        // ===== INJEÇÃO DE DEPENDÊNCIA (VERSÃO ATUALIZADA) =====

        builder.Services.AddSingleton<ApiService>();

        // O ViewModel agora é um Singleton para ser compartilhado entre as abas
        builder.Services.AddSingleton<TasksViewModel>();
        builder.Services.AddTransient<AddEditTaskViewModel>();

        // Registra as páginas
        builder.Services.AddTransient<TaskListPage>(); // A página de lista é transitória
        builder.Services.AddTransient<AddEditTaskPage>();
        builder.Services.AddSingleton<MainTabbedPage>(); // A TabbedPage é a raiz, Singleton

        return builder.Build();
    }
}