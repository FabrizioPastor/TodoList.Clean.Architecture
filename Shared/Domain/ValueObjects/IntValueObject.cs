using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Domain.ValueObjects
{
    public class IntValueObject
    {
        public int Value { get; private set; }

        public IntValueObject(int value) {
            Value = value;
        }
    }
}
