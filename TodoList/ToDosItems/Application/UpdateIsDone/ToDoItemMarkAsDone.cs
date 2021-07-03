using System.Threading.Tasks;
using TodoList.ToDosItems.Domain;

namespace TodoList.ToDosItems.Application.UpdateIsDone
{
    public class ToDoItemMarkAsDone
    {
        private readonly IToDoRepository _repository;

        public ToDoItemMarkAsDone(IToDoRepository repository)
        {
            _repository = repository;
        }

        public async Task MarkToDoItemAsCompleted(string id, string title, string description, bool isDone)
        {
            var todoId = new ToDoId(id);
            var todoTitle = new ToDoTitle(title);
            var todoDescription = new ToDoDescription(description);
            var todoIsDone = new ToDoIsDone(isDone);

            var toDoItem = new ToDoItem(todoId, todoTitle, todoDescription, todoIsDone);
            
            await _repository.Update(toDoItem);
        }
    }
}