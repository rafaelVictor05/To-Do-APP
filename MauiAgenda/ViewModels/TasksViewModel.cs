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
    public async Task GetTasksAsync()
    {
        try
        {
            var tasks = await ApiService.GetTasksAsync();

            MainThread.BeginInvokeOnMainThread(() =>
            {
                PendingTasks.Clear();
                CompletedTasks.Clear();
                foreach (var task in tasks.OrderByDescending(t => t.Id))
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
            });
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

        // O binding do Switch já alterou a propriedade 'task.IsCompleted'.
        // Agora, nós apenas movemos o item entre as listas com base no seu NOVO estado.
        // Isso evita a 'race condition' e a lógica conflitante.
        MainThread.BeginInvokeOnMainThread(() =>
        {
            if (task.IsCompleted)
            {
                // Se a tarefa agora está marcada como COMPLETA,
                // ela deve ser movida da lista de PENDENTES para a de CONCLUÍDAS.
                if (PendingTasks.Remove(task))
                {
                    CompletedTasks.Add(task);
                }
            }
            else
            {
                // Se a tarefa agora está marcada como PENDENTE,
                // ela deve ser movida da lista de CONCLUÍDAS para a de PENDENTES.
                if (CompletedTasks.Remove(task))
                {
                    PendingTasks.Add(task);
                }
            }
        });

        try
        {
            // A chamada para a API agora envia o estado correto da tarefa.
            await ApiService.UpdateTaskAsync(task);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Erro ao atualizar tarefa na API: {ex.Message}");
            // Opcional: Adicionar lógica para reverter a troca na UI se a API falhar.
            // Para o seu prazo, podemos deixar sem a reversão.
        }
    }
}