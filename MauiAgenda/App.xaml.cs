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
        // Define o título da BARRA DE NAVEGAÇÃO (no topo da tela)
        pendingPage.Title = "To-do App";

        // Cria a NavigationPage que será a ABA e define o TÍTULO DA ABA
        var navPending = new NavigationPage(pendingPage)
        {
            Title = "Pendentes"
        };


        // --- PÁGINA DE CONCLUÍDAS ---
        var completedPage = serviceProvider.GetService<TaskListPage>();
        // Define o título da BARRA DE NAVEGAÇÃO (no topo da tela)
        completedPage.Title = "To-do App";

        // Cria a NavigationPage que será a ABA e define o TÍTULO DA ABA
        var navCompleted = new NavigationPage(completedPage)
        {
            Title = "Concluídas"
        };


        // --- CRIAÇÃO DA TABBEDPAGE ---
        var tabbedPage = new TabbedPage();
        tabbedPage.Children.Add(navPending);
        tabbedPage.Children.Add(navCompleted);


        tabbedPage.BarBackgroundColor = Colors.Black;
        tabbedPage.UnselectedTabColor = Colors.Grey; // Cinza para contraste com o fundo preto
        tabbedPage.SelectedTabColor = Colors.White;    // Branco para contraste máximo


        MainPage = tabbedPage;
    }
}