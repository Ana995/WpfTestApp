namespace WpfTestApp.Models
{
    public class TaskModel
    {
        public string Name { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public string Priority { get; set; } = "Medium";
        public string Category { get; set; } = "General";
        public Boolean IsCompleted { get; set; }
    }
}
