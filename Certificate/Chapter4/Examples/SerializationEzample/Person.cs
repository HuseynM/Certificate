using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Certificate.Chapter4.Examples.SerializationEzample
{
    [Serializable]
    public class Person1
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    [Serializable]
    public class Person2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private bool isDirty = false;
    }

    [DataContract]
    public class PersonDataContract
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }
        private bool isDirty = false;
    }

    public class Serializer
    {
        public static void Serialize()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Person1));
            string xml;
            using (StringWriter stringWriter = new StringWriter())
            {
                Person1 p = new Person1
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Age = 42
                };
                serializer.Serialize(stringWriter, p);
                xml = stringWriter.ToString();
            }
            Console.WriteLine(xml);
            using (StringReader stringReader = new StringReader(xml))
            {
                Person1 p = (Person1)serializer.Deserialize(stringReader);
                Console.WriteLine("{0} {1} is {2}  years old", p.FirstName, p.LastName, p.Age);
            }
        }

        public static void BinarySerialize()
        {
            Person2 p = new Person2
            {
                Id = 1,
                Name = "John Doe"
            };
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream("data.bin", FileMode.Create))
            {
                formatter.Serialize(stream, p);
            }
            using (Stream stream = new FileStream("data.bin", FileMode.Open))
            {
                Person2 dp = (Person2)formatter.Deserialize(stream);
            }
        }

        public static void DataContractSerialize()
        {
            PersonDataContract p = new PersonDataContract
            {
                Id = 1,
                Name = "John Doe"
            };
            using (Stream stream = new FileStream("data.xml", FileMode.Create))
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(PersonDataContract));
                ser.WriteObject(stream, p);
            }
            using (Stream stream = new FileStream("data.xml", FileMode.Open))
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(PersonDataContract));
                PersonDataContract result = (PersonDataContract)ser.ReadObject(stream);
            }
        }
    }
}
