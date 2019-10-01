using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificate.Chapter4.Examples.LinqExample
{
    public class AnonymousType
    {
        public void Execute()
        {
            var person = new
            {
                FirstName = "Huseyn",
                LastName = "Mikayil"
            };

            Console.WriteLine(person.GetType().Name); // <>f__AnonymousType1`2
        }
    }
}
