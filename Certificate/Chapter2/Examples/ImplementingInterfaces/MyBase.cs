using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificate.Chapter2.Examples.ImplementingInterfaces
{
    public class MyBase
    {
        protected virtual void Execute() { }
    }

    public class MyDerived : MyBase
    {
        protected override void Execute()
        {
            Log("Before executing");
            base.Execute();
            Log("After executing");
        }

        private void Log(string message) { }
    }
}
