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

    // Método para configurar a tarefa no modo de edição
    public void SetTask(TaskItem task)
    {
        _viewModel.SetTask(task);
    }

    async void OnSaveButton_Clicked(object sender, EventArgs e)
    {
        await _viewModel.SaveTaskCommand.ExecuteAsync(null);
        await Navigation.PopAsync();
    }

    async void OnCancelButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}