using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Domain.AggregateRoot;
using Shared.Domain.ToDosItems.Domain;

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
        
        //Used by EntityFramework 
        private ToDoItem()
        {
        }

        public void CheckAsCompleted() {
            IsDone = new ToDoIsDone(true);
        }

        public void ToggleCompleted() {
            IsDone = new ToDoIsDone(!IsDone.Value);
        }

        /// <summary>
        /// El name constructor es usado para crear instancias de nuestra clase que no necesariamente
        /// quiere decir que sean "Nuevas" creaciones de este, por ejemplo es distinto querer crear
        /// un todoitem que esté llegando desde base de datos a querer crear un nuevo todoitem que
        /// se vaya a registrar en la base de datos
        /// </summary>
        /// <param name="id">UUID del todoItem</param>
        /// <param name="title">Titulol del todoitem </param>
        /// <param name="description">Descripción del todoitem</param>
        /// <returns>retorna una instancia de ToDoItem</returns>
        public static ToDoItem Create(ToDoId id, ToDoTitle title, ToDoDescription description) {
            var toDoItem = new ToDoItem(id, title, description, new ToDoIsDone(false));

            toDoItem.Record(new ToDoItemCreatedDomainEvent(id.Value, title.Value, description.Value, false)); 
            
            return toDoItem;
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
                new ToDoId(Convert.ToString(primitive["TodoItemId"])),
                new ToDoTitle(Convert.ToString(primitive["Title"])),
                new ToDoDescription(Convert.ToString(primitive["Description"])),
                new ToDoIsDone(Convert.ToBoolean(primitive["IsDone"]))
                );
        }
    }
}
