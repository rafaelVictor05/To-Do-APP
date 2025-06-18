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
        if (string.IsNullOrWhiteSpace(_viewModel.Name) || string.IsNullOrWhiteSpace(_viewModel.Description))
        {
            await DisplayAlert("Campos Obrigatórios", "Por favor, preencha o nome e a descrição da tarefa.", "OK");
            return;
        }

        var saveButton = sender as Button;
        try
        {
            if (saveButton != null) saveButton.IsEnabled = false;

            await _viewModel.SaveTaskCommand.ExecuteAsync(null);

            await DisplayAlert("Sucesso", "Tarefa salva!", "OK");

        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Não foi possível salvar a tarefa: {ex.Message}", "OK");
        }
        finally
        {
            if (saveButton != null) saveButton.IsEnabled = true;
        }
    }

    async void OnCancelButton_Clicked(object sender, EventArgs e)
    {
        if (Navigation.NavigationStack.Count > 1)
        {
            await Navigation.PopAsync();
        }
    }
}