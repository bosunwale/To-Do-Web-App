namespace ToDoAssignment.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsCompleted { get; set; }

        public List<Todo> TodoList { get; set; }
    }
}
