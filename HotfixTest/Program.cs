using System;
using System.Linq;
using System.Runtime.Loader;
using System.IO;
using System.Reflection;

namespace HotfixTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly hotfixAssembly = null;
            Type type = null;

            var hotfixLocation = Path.GetFullPath("HotfixLibrary.dll");

            if (File.Exists(hotfixLocation))
                hotfixAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(hotfixLocation);


            if (hotfixAssembly != null)
                type = hotfixAssembly.GetType("HotfixTest.ExampleNamespace.ExampleClass");

            if (type == null)
                type = Type.GetType("HotfixTest.ExampleNamespace.ExampleClass");


            var instance = Activator.CreateInstance(type);
            var example = instance as IExample ?? new ExampleNamespace.HotfixExample(instance);

            Console.WriteLine(string.Format("Class = {0}", example.GetType()));
            Console.WriteLine(example.ExampleProperty);
            example.ExampleProperty = "Set to a value";
            Console.WriteLine(example.ExampleProperty);

            example.DoSomething("with me!");

            Console.ReadKey();
        }
    }
}