using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Certificate.Chapter2.Examples.AttributeExample
{
    public interface IPlugin
    {
        string Name { get; }
        string Description { get; }
        bool Load(MyApplication application);
    }

    public class MyApplication
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class MyPlugin : IPlugin
    {
        public string Name
        {
            get { return "MyPlugin"; }
        }
        public string Description
        {
            get { return "My Sample Plugin"; }
        }
        public bool Load(MyApplication application)
        {
            return true;
        }
    }

    public class MyExecute
    {
        public void Execute()
        {
            Assembly pluginAssembly = Assembly.LoadFile(@"F:\Huseyn\Programming\Projects\Own\Job\Job\BusinessLayer\bin\Debug\netcoreapp2.2\BusinessLayer.dll");
            var plugins = from type in pluginAssembly.GetTypes()
                          where typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface
                          select type;

            foreach (var pluginType in plugins)
            {
                IPlugin plugin = Activator.CreateInstance(pluginType) as IPlugin;
            }
        }

        public void GetField(object obj)
        {
            FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (FieldInfo field in fields)
            {
                if (field.FieldType == typeof(int))
                    Console.WriteLine(field.GetValue(obj));
            }
        }

        public void GetMethod()
        {
            int i = 38;
            MethodInfo compareToMethod = i.GetType().GetMethod("CompareTo",
            new Type[] { typeof(int) });
            int result = (int)compareToMethod.Invoke(i, new object[] { 41 });
        }
    }
}
