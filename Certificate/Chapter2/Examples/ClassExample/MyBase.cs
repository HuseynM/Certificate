using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificate.Chapter2.Examples.ClassExample
{
    class MyBase
    {
        public virtual int MyMethod() => 42;
    }

    class MyDerived : MyBase
    {
        public sealed override int MyMethod() => base.MyMethod() * 2;
    }

    class MyDerived2 : MyDerived
    {
        // public override int MyMethod() { return 1;} -- method not exist in here
    }
}
