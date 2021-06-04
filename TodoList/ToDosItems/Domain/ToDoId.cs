using Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.ToDosItems.Domain
{
    public class ToDoId : IntValueObject
    {
        public ToDoId(int value) : base(value)
        {
        }
    }
}
