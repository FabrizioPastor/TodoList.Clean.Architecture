using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.ToDosItems.Domain;

namespace TodoList.ToDosItems.Infraestructure.Persistence
{
    public class MySqlToDoItemRepository : IToDoRepository
    {
        public Task Save(ToDoItem todoItem)
        {
            throw new NotImplementedException();
        }

        public Task<ToDoItem> Search(int id)
        {
            throw new NotImplementedException();
        }
    }
}
