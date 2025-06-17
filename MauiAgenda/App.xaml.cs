using MauiAgenda.Views;
using System;

namespace MauiAgenda;

public partial class App : Application
{
    public App(IServiceProvider serviceProvider)
    {
        InitializeComponent();

        // Cria a p�gina de tarefas pendentes
        var pendingPage = serviceProvider.GetService<TaskListPage>();
        pendingPage.Title = "Pendentes";
        pendingPage.ShowCompletedTasks = false; // Configura para mostrar pendentes

        // Cria a p�gina de tarefas conclu�das
        var completedPage = serviceProvider.GetService<TaskListPage>();
        completedPage.Title = "Conclu�das";
        completedPage.ShowCompletedTasks = true; // Configura para mostrar conclu�das

        var tabbedPage = new TabbedPage();
        tabbedPage.Children.Add(new NavigationPage(pendingPage));
        tabbedPage.Children.Add(new NavigationPage(completedPage));

        // Mant�m o estilo da barra de abas
        tabbedPage.BarBackgroundColor = Colors.Black;
        tabbedPage.UnselectedTabColor = Colors.Gray;
        tabbedPage.SelectedTabColor = Colors.Purple;

        MainPage = tabbedPage;
    }
}