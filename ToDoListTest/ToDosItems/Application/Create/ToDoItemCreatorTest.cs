using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.ToDosItems.Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TodoList.ToDosItems.Application.Create;
using TodoList.ToDosItems.Application.SearchAll;
using TodoList.ToDosItems.Domain;
using TodoList.ToDosItems.Infraestructure.Persistence;
using TodoList.ToDosItems.Shared.Infraestrucutre.Persistence.EntityFramework;

namespace ToDoListTest.ToDosItems.Application.Create
{
    [TestClass]
    public class ToDoItemCreatorTest
    {
        [TestMethod]
        public async Task CreateToDo()
        {
            var repository = new MySqlToDoItemRepository(new TodoListContext());
            var useCase = new ToDoItemCreator(repository);
            
            await useCase.CreateToDoItem(Guid.NewGuid().ToString(), "My title", "My description");
        }
    }
}