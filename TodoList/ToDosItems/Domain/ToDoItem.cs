using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Domain.AggregateRoot;

namespace TodoList.ToDosItems.Domain
{
    public class ToDoItem : AggregateRoot
    {
        public int TodoItemId { get; private set; }
        public ToDoTitle Title { get; private set; }
        public string Description { get; private set; }
        public bool IsDone { get; private set; }

        public ToDoItem(int id, ToDoTitle title, string description, bool isDone) {
            TodoItemId = id;
            Title = title;
            Description = description;
            IsDone = isDone;
        }

        public void CheckAsCompleted() {
            IsDone = true;
        }

        public static ToDoItem Create(int id, ToDoTitle title, string description) {
            //TODO: Implement domain events
            return new ToDoItem(id, title, description, false);
        }

        public Dictionary<string, object> ToPrimitive() {
            return new Dictionary<string, object>
            {
                { "TodoItemId", TodoItemId },
                { "Title", Title.Value },
                { "Description", Description },
                { "IsDone", Description }
            };
        }
        
        public static ToDoItem FromPrimitive(Dictionary<string, object> primitive) {
            return new ToDoItem(
                Convert.ToInt32(primitive["TodoItemId"]),
                new ToDoTitle(Convert.ToString(primitive["Title"])),
                Convert.ToString(primitive["Description"]),
                Convert.ToBoolean(primitive["IsDone"])
                );
        }
    }
}
