using MauiAgenda.Models;
using MauiAgenda.ViewModels;

namespace MauiAgenda.Views;

public partial class AddEditTaskPage : ContentPage
{
    private readonly AddEditTaskViewModel _viewModel;

    public AddEditTaskPage(AddEditTaskViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    public void SetTask(TaskItem task)
    {
        _viewModel.SetTask(task);
    }

    // ESTE MÉTODO É RESPONSÁVEL POR FECHAR A PÁGINA 
    async void OnSaveButton_Clicked(object sender, EventArgs e)
    {
        // Espera o comando SaveTaskCommand terminar de executar
        if (_viewModel.SaveTaskCommand.IsRunning)
        {
            return; // Evita cliques duplos
        }

        await _viewModel.SaveTaskCommand.ExecuteAsync(null);

        // Garante que a navegação ocorra na thread da UI para evitar erros
        if (Navigation.NavigationStack.Count > 1)
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await Navigation.PopAsync();
            });
        }
    }
}