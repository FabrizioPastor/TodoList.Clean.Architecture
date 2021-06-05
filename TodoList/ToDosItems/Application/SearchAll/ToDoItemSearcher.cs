using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.ToDosItems.Domain;

namespace TodoList.ToDosItems.Application.SearchAll
{
    public class ToDoItemSearcher
    {
        private readonly IToDoRepository _context;

        public ToDoItemSearcher(IToDoRepository context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ToDoItem>> SearchAllToDoItems()
        {
            return await _context.SearchAll();
        }
    }
}