using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificate.Chapter2.Examples.ImplementingInterfaces
{
    abstract public class MyBase
    {
        protected virtual void Execute() { }

        public abstract void AbstractMethod();
    }

    public class MyDerived : MyBase
    {
        protected override void Execute()
        {
            Log("Before executing");
            base.Execute();
            Log("After executing");
        }

        public override void AbstractMethod()
        {
            throw new NotImplementedException();
        }

        private void Log(string message) { }
    }
}
