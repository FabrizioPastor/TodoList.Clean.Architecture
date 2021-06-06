using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.ToDosItems.Domain;

namespace TodoList.ToDosItems.Application.SearchAll
{
    public class AllToDoItemSearcher
    {
        private readonly IToDoRepository toDoRepository;

        public AllToDoItemSearcher(IToDoRepository toDoRepository)
        {
            this.toDoRepository = toDoRepository;
        }

        public async Task<IEnumerable<ToDoItem>> SearchAllToDoItems()
        {
            return await toDoRepository.SearchAll();
        }
    }
}