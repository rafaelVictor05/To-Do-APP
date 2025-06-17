using MauiAgenda.Views;
using System;

namespace MauiAgenda;

public partial class App : Application
{
    public App(IServiceProvider serviceProvider)
    {
        InitializeComponent();

        // Cria a página de tarefas pendentes
        var pendingPage = serviceProvider.GetService<TaskListPage>();
        pendingPage.Title = "Pendentes";
        pendingPage.ShowCompletedTasks = false; // Configura para mostrar pendentes

        // Cria a página de tarefas concluídas
        var completedPage = serviceProvider.GetService<TaskListPage>();
        completedPage.Title = "Concluídas";
        completedPage.ShowCompletedTasks = true; // Configura para mostrar concluídas

        var tabbedPage = new TabbedPage();
        tabbedPage.Children.Add(new NavigationPage(pendingPage));
        tabbedPage.Children.Add(new NavigationPage(completedPage));

        // Mantém o estilo da barra de abas
        tabbedPage.BarBackgroundColor = Colors.Black;
        tabbedPage.UnselectedTabColor = Colors.Gray;
        tabbedPage.SelectedTabColor = Colors.Purple;

        MainPage = tabbedPage;
    }
}