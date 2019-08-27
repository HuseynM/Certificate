using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificate.Chapter2.Examples.ClassExample
{
    public class MyClass<T> where T : class, new()
    {
        T MyProperty { get; set; }
        public MyClass()
        {
            MyProperty = new T(); // Thanks to 'new()' can create object of T  
        }

        public void MyGenericMethod<TT>()
        {
            TT defaultValue = default(TT);
        }
    }
}
