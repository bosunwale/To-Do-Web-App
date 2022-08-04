using Microsoft.EntityFrameworkCore;
using ToDoAssignment.Models;

namespace ToDoAssignment.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {

        }

        public DbSet<Todo> todo { get; set; }
    }
}
