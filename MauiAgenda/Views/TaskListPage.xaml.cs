using MauiAgenda.Models;
using MauiAgenda.ViewModels;
using System.Collections.ObjectModel;

namespace MauiAgenda.Views;

public partial class TaskListPage : ContentPage
{
    private readonly TasksViewModel _viewModel;

    // Propriedade para controlar o modo da página (pendentes ou concluídas)
    public bool ShowCompletedTasks { get; set; }

    public ObservableCollection<TaskItem> TaskSource =>
        ShowCompletedTasks ? _viewModel.CompletedTasks : _viewModel.PendingTasks;

    public TaskListPage(TasksViewModel viewModel)
    {
        _viewModel = viewModel;

        InitializeComponent();

        BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Task.Run(() => _viewModel.GetTasksCommand.Execute(null));
        OnPropertyChanged(nameof(TaskSource));
    }

    private async void OnTaskToggled(object sender, ToggledEventArgs e)
    {
        var sw = sender as Switch;
        if (sw?.BindingContext is TaskItem task)
        {
            sw.IsEnabled = false;
            await _viewModel.ToggleIsCompletedCommand.ExecuteAsync(task);
            sw.IsEnabled = true;
        }
    }

    private async void OnAddButton_Clicked(object sender, EventArgs e)
    {
        var addPage = Handler.MauiContext.Services.GetService<AddEditTaskPage>();
        await Navigation.PushAsync(addPage);
    }

    private async void OnEditButton_Clicked(object sender, EventArgs e)
    {
        if ((sender as Button).CommandParameter is TaskItem task)
        {
            var editPage = Handler.MauiContext.Services.GetService<AddEditTaskPage>();
            editPage.SetTask(task);
            await Navigation.PushAsync(editPage);
        }
    }

    private async void OnDeleteButton_Clicked(object sender, EventArgs e)
    {
        if ((sender as Button).CommandParameter is TaskItem task)
        {
            bool confirm = await DisplayAlert("Confirmar", $"Excluir a tarefa '{task.Name}'?", "Sim", "Não");
            if (confirm)
            {
                await _viewModel.ApiService.DeleteTaskAsync(task.Id);
                await Task.Run(() => _viewModel.GetTasksCommand.Execute(null));
            }
        }
    }
}