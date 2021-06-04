using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.ToDosItems.Domain
{
    public class ToDoIsDone
    {
        public bool Value { get; private set; }

        public ToDoIsDone(bool value) {
            Value = value;
        }
    }
}
