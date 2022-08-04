using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoAssignment.Data;
using ToDoAssignment.Models;

namespace ToDoAssignment.Controllers
{
    public class TodoController : Controller
    {
        private readonly TodoContext _todoContext;

        public TodoController(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        //GET: List of todo
        public async Task<IActionResult> Index()
        {
            return View(await _todoContext.todo.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var todoList = await _todoContext.todo.
                FirstOrDefaultAsync(m => m.Id == id);
            if(todoList == null)
            {
                return NotFound();
            }
            return View(todoList);
        }

        public IActionResult Create()
        {
            return View();
        }

        //POST: ToDo/CreateToDo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,CreatedDate,IsCompleted")] Todo todo)
        {
            if (ModelState.IsValid)
            {
                _todoContext.Add(todo);
                await _todoContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }
    }
}
