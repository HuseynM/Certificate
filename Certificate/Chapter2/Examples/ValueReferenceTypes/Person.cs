using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificate.Chapter2.Examples.ValueReferenceTypes
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public static void ExchangePerson()
        {
            Person p1 = new Person()
            {
                Name = "Huseyn",
                Age = 24
            };

            Person p2;

            p2 = p1;

            p2.Name = "Aziz";
            p2.Age = 28;

            Console.WriteLine(p1.Name + " " + p1.Age);
        }

        public static void ExchangeString()
        {
            string a = "abcd";
            string b;

            b = a;
            b = "fghj";
            Console.WriteLine(a);
        }

        public static void ExchangePersonWithMethod()
        {
            Person p = new Person()
            {
                Name = "Huseyn",
                Age = 24
            };
            ChangePerson(p);

            Console.WriteLine(p.Name + " " + p.Age);
        }

        public static void ExchangeStringWithMethod()
        {
            string s = "Huseyn";
            ChangeString(s);
            Console.WriteLine(s);
        }

        private static void ChangePerson(Person person)
        {
            person.Name = "Namiq";
            person.Age = 10;
        }
        private static void ChangeString(string s)
        {
            s = "Namiq";
        }
    }
}
