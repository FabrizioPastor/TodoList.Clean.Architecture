using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.ToDosItems.Domain;

namespace TodoList.ToDosItems.Application.Create
{
    public class ToDoItemCreator
    {
        private readonly IToDoRepository _context;

        public TodoItemCreator(IToDoRepository conext) => _context = conext;

        public async Task CreateToDoItem(int id, string title, string description, bool isDone) {
            var todoId = new ToDoId(id);
            var todoTitle = new ToDoTitle(title);
            var todoDescription = new ToDoDescription(description);
            var todoIsDone = new ToDoIsDone(isDone);

            var toDoItem = new ToDoItem(todoId, todoTitle, todoDescription, todoIsDone);

            await _context.Save(toDoItem);
        }
    }
}
