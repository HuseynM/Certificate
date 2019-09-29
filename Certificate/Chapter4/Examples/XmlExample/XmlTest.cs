using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Certificate.Chapter4.Examples.XmlExample
{
    public class XmlTest
    {
        public void Reader()
        {
            string xml = @"<?xml version ='1.0' encoding ='utf - 8'?>
                             <people>
                                <person firstname ='john' lastname ='doe'>
                                    <contactdetails>
                                        <emailaddress> john@unknown.com </emailaddress>
                                   </contactdetails>
                                </person>
                                <person firstname ='jane' lastname ='doe'>
                                    <contactdetails>
                                        <emailaddress> jane@unknown.com </emailaddress>
                                        <phonenumber> 001122334455 </phonenumber>
                                    </contactdetails>
                                 </person>
                               </people>";

            using (StringReader stringReader = new StringReader(xml))
            {
                using (XmlReader xmlReader = XmlReader.Create(stringReader,
                new XmlReaderSettings() {IgnoreWhitespace = true }))
                {
                    xmlReader.MoveToContent();
                    xmlReader.ReadStartElement("people");
                    string firstName = xmlReader.GetAttribute("firstname");
                    string lastName = xmlReader.GetAttribute("lastname");
                    Console.WriteLine("Person: {0} {1}", firstName, lastName);
                    xmlReader.ReadStartElement("person");
                    Console.WriteLine("contactdetails");
                    xmlReader.ReadStartElement("contactdetails");
                    string emailAddress = xmlReader.ReadString();
                    Console.WriteLine("Email address: {0}", emailAddress);
                }
            }
        }

        public void Writer()
        {
            StringWriter stream = new StringWriter();
            using (XmlWriter writer = XmlWriter.Create(
                stream,
            new XmlWriterSettings() {Indent = true }))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("People");
                writer.WriteStartElement("Person");
                writer.WriteAttributeString("firstName", "John");
                writer.WriteAttributeString("lastName", "Doe");
                writer.WriteStartElement("ContactDetails");
                writer.WriteElementString("EmailAddress", "john@unknown.com");
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.Flush();
            }
            Console.WriteLine(stream.ToString());
        }

        public void Document()
        {
            string xml = @"<?xml version ='1.0' encoding ='utf - 8'?>
                             <people>
                                <person firstname ='john' lastname ='doe'>
                                    <contactdetails>
                                        <emailaddress> john@unknown.com </emailaddress>
                                   </contactdetails>
                                </person>
                                <person firstname ='jane' lastname ='doe'>
                                    <contactdetails>
                                        <emailaddress> jane@unknown.com </emailaddress>
                                        <phonenumber> 001122334455 </phonenumber>
                                    </contactdetails>
                                 </person>
                               </people>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlNodeList nodes = doc.GetElementsByTagName("Person");
            // Output the names of the people in the document
            foreach (XmlNode node in nodes)
            {
                string firstName = node.Attributes["firstName"].Value;
                string lastName = node.Attributes["lastName"].Value;
                Console.WriteLine("Name: {0} {1}", firstName, lastName);
            }
            // Start creating a new node
            XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "Person", "");
            XmlAttribute firstNameAttribute = doc.CreateAttribute("firstName");
            firstNameAttribute.Value = "Foo";
            XmlAttribute lastNameAttribute = doc.CreateAttribute("lastName");
            lastNameAttribute.Value = "Bar";
            newNode.Attributes.Append(firstNameAttribute);
            newNode.Attributes.Append(lastNameAttribute);
            doc.DocumentElement.AppendChild(newNode);
            Console.WriteLine("Modified xml...");
            doc.Save(Console.Out);
        }
    }
}
