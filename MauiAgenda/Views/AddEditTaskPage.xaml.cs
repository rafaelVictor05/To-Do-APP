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

    async void OnSaveButton_Clicked(object sender, EventArgs e)
    {
        // Espera o comando SaveTaskCommand terminar de executar
        if (_viewModel.SaveTaskCommand.IsRunning)
        {
            return; // Evita cliques duplos
        }

        await _viewModel.SaveTaskCommand.ExecuteAsync(null);

        if (Navigation.NavigationStack.Count > 1)
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await Navigation.PopAsync();
            });
        }
    }
}