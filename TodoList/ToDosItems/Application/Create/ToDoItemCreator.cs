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

        public ToDoItemCreator(IToDoRepository conext) => _context = conext;

        public async Task CreateToDoItem(string id, string title, string description) {
            var todoId = new ToDoId(id);
            var todoTitle = new ToDoTitle(title);
            var todoDescription = new ToDoDescription(description);

            var toDoItem = ToDoItem.Create(todoId, todoTitle, todoDescription);

            await _context.Save(toDoItem);
        }
    }
}
