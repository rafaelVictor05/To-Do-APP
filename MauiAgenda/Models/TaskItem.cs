using System.Text.Json.Serialization;

namespace MauiAgenda.Models
{
    public class TaskItem
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }
    }
}