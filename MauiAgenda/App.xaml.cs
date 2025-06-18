using MauiAgenda.Views;
using System;

namespace MauiAgenda;

public partial class App : Application
{
    public App(IServiceProvider serviceProvider)
    {
        InitializeComponent();

        // --- PÁGINA DE PENDENTES ---
        var pendingPage = serviceProvider.GetService<TaskListPage>();
        pendingPage.Title = "To-do App";
        pendingPage.ShowCompletedTasks = false; // 

        var navPending = new NavigationPage(pendingPage)
        {
            Title = "Pendentes"
        };


        // --- PÁGINA DE CONCLUÍDAS ---
        var completedPage = serviceProvider.GetService<TaskListPage>();
        completedPage.Title = "To-do App";
        completedPage.ShowCompletedTasks = true; //

        var navCompleted = new NavigationPage(completedPage)
        {
            Title = "Concluídas"
        };


        // --- CRIAÇÃO DA TABBEDPAGE ---
        var tabbedPage = new TabbedPage();
        tabbedPage.Children.Add(navPending);
        tabbedPage.Children.Add(navCompleted);

        tabbedPage.BarBackgroundColor = Colors.Black;
        tabbedPage.UnselectedTabColor = Colors.Grey;
        tabbedPage.SelectedTabColor = Colors.White;


        MainPage = tabbedPage;
    }
}