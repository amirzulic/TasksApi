using Microsoft.EntityFrameworkCore;
using Task = FirstApi.Models.Task;

namespace FirstApi.Data
{
    public class TaskDbContext : DbContext
    { 
        public TaskDbContext(DbContextOptions<TaskDbContext> options)
            : base(options) 
        {

        }
        public DbSet<Task> Tasks { get; set; }
    }
}
