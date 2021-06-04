using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.ToDosItems.Domain
{
    public interface IToDoRepository
    {
        Task Save(ToDoItem todoItem);
        Task<IEnumerable<ToDoItem>> SearchAll(int id);
    }
}
