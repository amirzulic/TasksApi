using FirstApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task = FirstApi.Models.Task;

namespace FirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskDbContext context;

        public TaskController(TaskDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<IEnumerable<Task>> Get()
        {
            return await context.Tasks.ToListAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Task), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var task = context.Tasks.FindAsync(id);
            return task == null ? NotFound() : Ok(task);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Task task)
        {
            await context.Tasks.AddAsync(task);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new {id = task.Id}, task);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Task task)
        {
            if (id != task.Id) return BadRequest();
            context.Entry(task).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var taskToDelete = await context.Tasks.FindAsync(id);
            if (taskToDelete == null) return NotFound();

            context.Tasks.Remove(taskToDelete);
            await context.SaveChangesAsync();

            return NoContent();
        }

    }
}
