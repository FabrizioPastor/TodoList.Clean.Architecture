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
        private TodoListContext _conext;

        public MySqlToDoItemRepository(TodoListContext context) {
            _conext = context;
        }

        public async Task Save(ToDoItem todoItem)
        {
            await _conext.ToDoItems.AddAsync(todoItem);
            await _conext.SaveChangesAsync();
        }

        public Task<ToDoItem> Search(int id)
        {
            throw new NotImplementedException();
        }
    }
}
