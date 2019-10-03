using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Certificate.Chapter4.Examples.LinqExample
{
    public class LinqQuery
    {
        readonly int[] data = { 1, 2, 5, 8, 11 };
        List<Order> orders = new List<Order>()
        {
            new Order{ Id = 1, OrderLines=new List<OrderLine>{ } },
            new Order{ Id = 2, OrderLines=new List<OrderLine>{ } },
            new Order{ Id = 3, OrderLines=new List<OrderLine>{ } },
            new Order{ Id = 4, OrderLines=new List<OrderLine>{ } },
            new Order{ Id = 5, OrderLines=new List<OrderLine>{ } },
        };
        List<Product> products = new List<Product>
        {
             new Product { Description = "A", Price = 20 },
             new Product { Description = "B", Price = 20 },
             new Product { Description = "C", Price = 20 }
        };
        public void GetEvenNumbers()
        {

            var result = from d in data
                         where d % 2 == 0
                         select d;

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            
        }

        public void GreaterThan5()
        {
            var result = from d in data
                         where d > 5
                         orderby d descending
                         select d;

            Console.WriteLine(string.Join(",", result));
        }

        public void MultiplyEachOther()
        {
            int[] data1 = { 1, 3, 5 };
            int[] data2 = { 2, 4, 6 };

            var result = from d1 in data1
                         from d2 in data2
                         select d1 * d2;


        }

        public void AverageNumberOfOrderLine()
        {
            var averageNumberOfOrderLines = orders.Average(o => o.OrderLines.Count);
        }

        public void GroupByProduct()
        {
            var result = from o in orders
                         from l in o.OrderLines
                         group l by l.Product into p
                         select new
                         {
                             Product = p.Key,
                             Amount = p.Sum(x => x.Amount)
                         };
        }

        public void Join()
        {
            string[] popularProductNames = { "A", "B" };
            var popularProducts = from p in products
                                  join n in popularProductNames on p.Description equals n
                                  select p;

            foreach (var item in popularProducts)
            {
                Console.WriteLine(item.Description);
            }
        }

        public void Paging(int pageIndex, int pageSize)
        {
            var pagedOrders = orders
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);
        }

        public void LinqToXml()
        {
            string xml = @"<?xml version =""1.0"" encoding =""utf - 8""?>
                 <people>
                    <person firstname =""john"" lastname =""doe"">
                        <contactdetails>
                         <emailaddress> john@unknown.com </emailaddress>
                         </contactdetails>
                    </person>
                    <person firstname =""jane"" lastname =""doe"">
                         <contactdetails>
                          <emailaddress> jane@unknown.com </emailaddress>
                             <phonenumber> 001122334455 </phonenumber>
                             </contactdetails>
                             </person>
                  </people>";


            XDocument doc = XDocument.Parse(xml);
            IEnumerable<string> personNames = from p in doc.Descendants("person")
                                              select (string)p.Attribute("firstname")
                                              + " " + (string)p.Attribute("lastname");

            foreach (var name in personNames)
            {
                Console.Write(name+"\n");
            }
        }
    }

    public class Product
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
    public class OrderLine
    {
        public int Amount { get; set; }
        public Product Product { get; set; }
    }
    public class Order
    {
        public int Id { get; set; }
        public List<OrderLine> OrderLines { get; set; }
    }
}
