using MauiAgenda.Views;
using System;

namespace MauiAgenda;

public partial class App : Application
{
    public App(IServiceProvider serviceProvider)
    {
        InitializeComponent();

        // --- P�GINA DE PENDENTES ---
        var pendingPage = serviceProvider.GetService<TaskListPage>();
        // Define o t�tulo da BARRA DE NAVEGA��O (no topo da tela)
        pendingPage.Title = "To-do App";

        // Cria a NavigationPage que ser� a ABA e define o T�TULO DA ABA
        var navPending = new NavigationPage(pendingPage)
        {
            Title = "Pendentes"
        };


        // --- P�GINA DE CONCLU�DAS ---
        var completedPage = serviceProvider.GetService<TaskListPage>();
        // Define o t�tulo da BARRA DE NAVEGA��O (no topo da tela)
        completedPage.Title = "To-do App";

        // Cria a NavigationPage que ser� a ABA e define o T�TULO DA ABA
        var navCompleted = new NavigationPage(completedPage)
        {
            Title = "Conclu�das"
        };


        // --- CRIA��O DA TABBEDPAGE ---
        var tabbedPage = new TabbedPage();
        tabbedPage.Children.Add(navPending);
        tabbedPage.Children.Add(navCompleted);


        tabbedPage.BarBackgroundColor = Colors.Black;
        tabbedPage.UnselectedTabColor = Colors.Grey; // Cinza para contraste com o fundo preto
        tabbedPage.SelectedTabColor = Colors.White;    // Branco para contraste m�ximo


        MainPage = tabbedPage;
    }
}