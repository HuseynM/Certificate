using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificate.Chapter2.Examples.ClassExample
{
    public class ConstructorChaining
    {
        public readonly int _p;
        public ConstructorChaining() : this(3) { }
        public ConstructorChaining(int p)
        {
            _p = p;
        }
    }
}
