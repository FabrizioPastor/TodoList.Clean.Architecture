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
        public ToDoId TodoItemId { get; }
        public ToDoTitle Title { get; }
        public ToDoDescription Description { get; }
        public ToDoIsDone IsDone { get; private set; }

        public ToDoItem(ToDoId id, ToDoTitle title, ToDoDescription description, ToDoIsDone isDone) {
            TodoItemId = id;
            Title = title;
            Description = description;
            IsDone = isDone;
        }

        private ToDoItem()
        {
        }

        public void CheckAsCompleted() {
            IsDone = new ToDoIsDone(true);
        }

        public void ToggleCompleted() {
            IsDone = new ToDoIsDone(!IsDone.Value);
        }

        public static ToDoItem Create(ToDoId id, ToDoTitle title, ToDoDescription description) {
            //TODO: Implement domain events
            return new ToDoItem(id, title, description, new ToDoIsDone(false));
        }

        public Dictionary<string, object> ToPrimitive() {
            return new Dictionary<string, object>
            {
                { "TodoItemId", TodoItemId.Value },
                { "Title", Title.Value },
                { "Description", Description.Value },
                { "IsDone", IsDone.Value }
            };
        }
        
        public static ToDoItem FromPrimitive(Dictionary<string, object> primitive) {
            return new ToDoItem(
                new ToDoId(Convert.ToInt32(primitive["TodoItemId"])),
                new ToDoTitle(Convert.ToString(primitive["Title"])),
                new ToDoDescription(Convert.ToString(primitive["Description"])),
                new ToDoIsDone(Convert.ToBoolean(primitive["IsDone"]))
                );
        }
    }
}
