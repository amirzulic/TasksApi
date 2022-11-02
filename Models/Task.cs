using System.ComponentModel.DataAnnotations;

namespace FirstApi.Models
{
    public class Task
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public TaskType TaskType { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Completed { get; set; }
    }

    public enum Priority
    {
        Low, Medium, High
    }

    public enum TaskType
    {
        Work, Family, Friends
    }
}
