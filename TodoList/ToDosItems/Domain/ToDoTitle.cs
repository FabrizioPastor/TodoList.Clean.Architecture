using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Domain.ValueObjects;

namespace TodoList.ToDosItems.Domain
{
    public class ToDoTitle : StringValueObject
    {
        public ToDoTitle(string value) : base(value) {
            IsEmpty(value);
        }

        private static void IsEmpty(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidEnumArgumentException("The title of the to-do cannot be null or empty");
            }
        }
    }
}
