using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAgenda.Models;
using MauiAgenda.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MauiAgenda.ViewModels;

public partial class TasksViewModel : ObservableObject
{
    public ApiService ApiService { get; }
    public ObservableCollection<TaskItem> PendingTasks { get; } = new();
    public ObservableCollection<TaskItem> CompletedTasks { get; } = new();

    public TasksViewModel(ApiService apiService)
    {
        ApiService = apiService;
    }

    [RelayCommand]
    private async Task GetTasksAsync()
    {
        try
        {
            var tasks = await ApiService.GetTasksAsync();
            PendingTasks.Clear();
            CompletedTasks.Clear();

            foreach (var task in tasks.OrderBy(t => t.Name))
            {
                if (task.IsCompleted)
                {
                    CompletedTasks.Add(task);
                }
                else
                {
                    PendingTasks.Add(task);
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Erro ao buscar tarefas: {ex.Message}");
        }
    }

    [RelayCommand]
    private async Task ToggleIsCompletedAsync(TaskItem task)
    {
        if (task is null) return;

        task.IsCompleted = !task.IsCompleted;
        await ApiService.UpdateTaskAsync(task);

        // Move a tarefa entre as listas na UI
        if (task.IsCompleted)
        {
            if (PendingTasks.Contains(task))
            {
                PendingTasks.Remove(task);
                CompletedTasks.Add(task);
            }
        }
        else
        {
            if (CompletedTasks.Contains(task))
            {
                CompletedTasks.Remove(task);
                PendingTasks.Add(task);
            }
        }
    }
}