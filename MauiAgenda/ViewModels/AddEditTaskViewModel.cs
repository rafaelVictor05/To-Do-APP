using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAgenda.Models;
using MauiAgenda.Services;
using System.Threading.Tasks;

namespace MauiAgenda.ViewModels;

public partial class AddEditTaskViewModel : ObservableObject
{
    [ObservableProperty]
    string id;

    [ObservableProperty]
    string name;

    [ObservableProperty]
    string description;

    [ObservableProperty]
    bool isCompleted;

    private readonly ApiService _apiService;
    private readonly TasksViewModel _tasksViewModel;

    public AddEditTaskViewModel(ApiService apiService, TasksViewModel tasksViewModel)
    {
        _apiService = apiService;
        _tasksViewModel = tasksViewModel;
    }

    public void SetTask(TaskItem task)
    {
        Id = task.Id;
        Name = task.Name;
        Description = task.Description;
        IsCompleted = task.IsCompleted;
    }

    [RelayCommand]
    private async Task SaveTaskAsync()
    {
        var task = new TaskItem
        {
            Id = this.Id,
            Name = this.Name,
            Description = this.Description,
            IsCompleted = this.IsCompleted
        };

        if (string.IsNullOrEmpty(task.Id))
        {
            await _apiService.AddTaskAsync(task);
        }
        else
        {
            await _apiService.UpdateTaskAsync(task);
        }

        // Avisa o ViewModel principal para recarregar a lista
        await _tasksViewModel.GetTasksCommand.ExecuteAsync(null);
    }
}