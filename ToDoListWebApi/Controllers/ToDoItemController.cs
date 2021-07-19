using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoList.ToDosItems.Application.SearchAll;
using TodoList.ToDosItems.Infraestructure.Persistence.Dapper;
using ToDoListWebApi.Models;

namespace ToDoListWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoItemController : ControllerBase
    {
        // GET
        [HttpGet]
        public async Task<IEnumerable<ToDoItemModel>> Index()
        {
            var allTodoItemSearcher = new AllToDoItemSearcher(new MySqlToDoItemDapperRepository());
            var toDoItems =  await allTodoItemSearcher.SearchAllToDoItems();

            return toDoItems.Select(item => new ToDoItemModel
            {
                Id = item.TodoItemId.Value,
                Title = item.Title.Value,
                Description = item.Description.Value,
                IsDone = item.IsDone.Value
            });
        }
    }
}