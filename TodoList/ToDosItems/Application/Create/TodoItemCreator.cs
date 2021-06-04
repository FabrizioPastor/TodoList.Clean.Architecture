using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.ToDosItems.Domain;

namespace TodoList.ToDosItems.Application.Create
{
    public class TodoItemCreator
    {
        private readonly IToDoRepository _context;

        public TodoItemCreator(IToDoRepository conext) => _context = conext;

        public async Task CreateToDoItem(int id, string title, string description, bool isDone) {
            var todoTitle = new ToDoTitle(title);

            var toDoItem = new ToDoItem(id, todoTitle, description, isDone);

            await _context.Save(toDoItem);
        }
    }
}
