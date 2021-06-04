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
        private readonly TodoListContext _conext;

        public MySqlToDoItemRepository(TodoListContext context) {
            _conext = context;
        }

        public async Task Save(ToDoItem todoItem)
        {
            await _conext.ToDoItems.AddAsync(todoItem);
            await _conext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ToDoItem>> SearchAll(int id)
        {
            return await _conext.ToDoItems.ToListAsync();
        }
    }
}
