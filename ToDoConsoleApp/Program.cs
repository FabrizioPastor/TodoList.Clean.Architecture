using System;
using System.Threading.Tasks;
using TodoList.ToDosItems.Application.SearchAll;
using TodoList.ToDosItems.Infraestructure.Persistence;
using TodoList.ToDosItems.Shared.Infraestrucutre.Persistence.EntityFramework;

namespace ToDoConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {   
                var repository = new MySqlToDoItemRepository(new TodoListContext());
                var toDoSearcher = new AllToDoItemSearcher(repository);
                var response = await toDoSearcher.SearchAllToDoItems();

                Console.WriteLine("Message from console");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

    public enum Repository { 
        MySql,
        InMemory,
        SqlServer
    }
}
