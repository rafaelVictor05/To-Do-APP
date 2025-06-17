using MauiAgenda.Models;
using System.Net.Http.Json;

namespace MauiAgenda.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://agenda-api-9zhi.onrender.com/api/tasks";

        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<TaskItem>> GetTasksAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<TaskItem>>(BaseUrl) ?? new();
        }

        public async Task<TaskItem?> AddTaskAsync(TaskItem task)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, task);
            return await response.Content.ReadFromJsonAsync<TaskItem>();
        }

        public async Task<bool> UpdateTaskAsync(TaskItem task)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{task.Id}", task);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteTaskAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}