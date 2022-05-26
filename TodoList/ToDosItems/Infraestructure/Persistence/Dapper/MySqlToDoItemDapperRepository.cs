using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
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

        public async Task Save(ToDoItem todoItem)
        {
            const string sql = "INSERT INTO todo_item (todo_id, title, description, is_done) " +
                                   " VALUES (@todo_id, @title, @description, @is_done)";

            await _connection.ExecuteAsync(sql, new {
                todo_id = todoItem.TodoItemId.Value,
                title = todoItem.Title.Value,
                description = todoItem.Description.Value,
                is_done = todoItem.IsDone.Value
            });
        }

        public async Task<IEnumerable<ToDoItem>> SearchAll()
        {
            using IDbConnection db = _connection;
            var listToDoItems = await db.QueryAsync("SELECT * FROM todo_item");
            return listToDoItems.Select(
                obj =>  new ToDoItem(
                        new ToDoId((string)Encoding.UTF8.GetString(obj.todo_id))
                        , new ToDoTitle((string)obj.title)
                        , new ToDoDescription((string)obj.description)
                        , new ToDoIsDone((bool)Convert.ToBoolean(obj.is_done))
                    ));
        }

        public async Task Update(ToDoItem toDoItem)
        {
            using IDbConnection db = _connection;
            const string sql = "UPDATE todo_item SET title = @title, description = @description, is_done = @is_done WHERE todo_id = @todo_id";
            await _connection.ExecuteAsync(sql, new
            {
                todo_id = toDoItem.TodoItemId.Value,
                title = toDoItem.Title.Value,
                description = toDoItem.Description.Value,
                is_done = toDoItem.IsDone.Value
            });
        }
    }
}