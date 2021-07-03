using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.ToDosItems.Domain;
using TodoList.ToDosItems.Shared.Infraestrucutre.Persistence.EntityFramework;

namespace TodoList.ToDosItems.Infraestructure.Persistence
{
    public class MySqlToDoItemRepository : IToDoRepository
    {
        private readonly TodoListContext _context;

        public MySqlToDoItemRepository(TodoListContext context) {
            _context = context;
        }

        public async Task Save(ToDoItem todoItem)
        {
            await _context.ToDoItems.AddAsync(todoItem);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ToDoItem>> SearchAll()
        {
            return await _context.ToDoItems.ToListAsync();
        }

        public async Task Update(ToDoItem toDoItem)
        {
            var todo = await _context.ToDoItems.FirstOrDefaultAsync(
                 x => 
                    x.TodoItemId.Value == toDoItem.TodoItemId.Value
                    );
            
            todo = toDoItem;
            
            await _context.SaveChangesAsync();
        }
    }
}
