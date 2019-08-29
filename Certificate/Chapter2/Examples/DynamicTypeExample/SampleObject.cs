using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificate.Chapter2.Examples.DynamicTypeExample
{
    public class SampleObject : DynamicObject
    {
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = binder.Name;
            return true;
        }

        public static void Execute()
        {
            dynamic obj = new SampleObject();
            Console.WriteLine(obj.SomeProperty);
        }
    }
}
