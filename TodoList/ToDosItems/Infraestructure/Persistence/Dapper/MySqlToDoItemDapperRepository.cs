using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using TodoList.ToDosItems.Domain;
using TodoList.ToDosItems.Shared.Infraestrucutre.Persistence.Dapper;

namespace TodoList.ToDosItems.Infraestructure.Persistence.Dapper
{
    public class MySqlToDoItemDapperRepository : IToDoRepository
    {
        private readonly MySqlConnection _connection;
        
        public MySqlToDoItemDapperRepository()
        {
            _connection = MySqlConnectionDb.GetInstance().Connection;
        }

        public Task Save(ToDoItem todoItem)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<ToDoItem>> SearchAll()
        {
            using IDbConnection db = _connection;
            var listToDoItems = db.Query("SELECT * FROM todo_item").Select(
                obj =>
                    new ToDoItem(
                        new ToDoId((string)System.Text.Encoding.UTF8.GetString(obj.todo_id))
                        , new ToDoTitle((string)obj.title)
                        , new ToDoDescription((string)obj.description)
                        , new ToDoIsDone((bool)Convert.ToBoolean(obj.is_done))
                    ));

            return listToDoItems;
        }

        public Task Update(ToDoItem toDoItem)
        {
            throw new System.NotImplementedException();
        }
    }
}