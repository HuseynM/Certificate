using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Certificate.Chapter1.Examples.ThreadExamples
{
    public class ThreadTest
    {
        public static void Execute1()
        {
            bool stopped = false;
            Thread t = new Thread(new ThreadStart(() =>
            {
                while (!stopped)
                {
                    Console.WriteLine("Running...");
                    Thread.Sleep(1000);
                }
            }));

            t.Start();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            stopped = true;
            t.Join();
        }

        [ThreadStatic]
        public static int _field;
        public static void Execute2()
        {
            new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    _field++;
                    Console.WriteLine("Thread A:{0}", _field);
                }
            }).Start();

            new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    _field++;
                    Console.WriteLine("Thread B:{0}", _field);
                }
            }).Start();

            Console.ReadKey();
        }


        public static ThreadLocal<int> _field2 = new ThreadLocal<int>(() =>
          {
              return Thread.CurrentThread.ManagedThreadId;
          });
        public static void Execute3()
        {
            new Thread(() =>
            {
                for (int i = 0; i < _field2.Value; i++)
                {
                    Console.WriteLine("Thread A: {0}", i);
                }
            }).Start();

            new Thread(() => 
            {
                for (int i = 0; i < _field2.Value; i++)
                {
                    Console.WriteLine("Thread B: {0}", i);
                }
            }).Start();

            Console.ReadKey();
        }

        public static void Execute4()
        {
            ThreadPool.QueueUserWorkItem((s) => 
            {
                Console.WriteLine("Working on a thread from threadpool");
            });

            Console.ReadLine();
        }
    }
}
