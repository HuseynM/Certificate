using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificate.Chapter2.Examples.StringExample
{
    public class StringExecuter
    {
        public void Execute()
        {
            Human human = new Human("Huseyn", "Mikayil");
            Console.WriteLine(human); // Huseyn Mikayil
        }
    }

    public class Human
    {
        public Human(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
        public string Name { get; set; }
        public string Surname { get; set; }

        public override string ToString()
        {
            return Name + " " + Surname;
        }

    }
}
