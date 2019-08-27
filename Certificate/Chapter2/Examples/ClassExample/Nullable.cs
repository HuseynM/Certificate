using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificate.Chapter2.Examples.ClassExample
{
    public class MyNullable<T> where T : struct
    {
        private bool hasValue;
        private T value;

        public MyNullable(T value)
        {
            hasValue = true;
            this.value = value;
        }

        public bool HasValue { get { return hasValue; } }

        public T Value
        {
            get
            {
                if (!HasValue) throw new ArgumentException();
                return value;
            }
        }

        public T GetValueOrDefault() => value;
    }
}
