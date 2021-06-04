using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Domain.ValueObjects
{
    public class StringValueObject
    {
        public string Value { get; private set; }

        public StringValueObject(string value) {
            Value = value;
        }
    }
}
