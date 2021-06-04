using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Domain.ValueObjects;

namespace TodoList.ToDosItems.Domain
{
    public class ToDoDescription : StringValueObject
    {
        public ToDoDescription(string value) : base(value)
        {
        }
    }
}
