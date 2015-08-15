using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int num_obj_creations = 10000000;
            object[] arr = new object[num_obj_creations];

            Stopwatch watch = new Stopwatch();
           
            var constructor = typeof(TestClass).GetConstructor(new Type[] { });
            Console.Write("Using constructor info ...");
            ClearArray(arr);
            watch.Restart();
            for (int i = 0; i < num_obj_creations; i++)
            {
                arr[i] = constructor.Invoke(null);
            }
            watch.Stop();
            Console.WriteLine(watch.Elapsed.TotalSeconds.ToString());

          

            Console.Write("Normal constructor ...");
            ClearArray(arr);
            watch.Restart();
            for (int i = 0; i < num_obj_creations; i++)
            {
                arr[i] = new TestClass();
            }
            watch.Stop();
            Console.WriteLine(watch.Elapsed.TotalSeconds.ToString());



            Func<object> factory = Expression.Lambda<Func<object>>(Expression.New(typeof(TestClass).GetConstructor(new Type[] { }), null)).Compile();
            Console.Write("Using compiled expression tree ...");
            ClearArray(arr);
            watch.Restart();
            for (int i = 0; i < num_obj_creations; i++)
            {
                arr[i] = factory();
            }
            watch.Stop();
            Console.WriteLine(watch.Elapsed.TotalSeconds.ToString());



            Console.Write("Using activator ...");
            ClearArray(arr);
            watch.Restart();
            for (int i = 0; i < num_obj_creations; i++)
            {
                arr[i] = Activator.CreateInstance<TestClass>();
            }
            watch.Stop();
            Console.WriteLine(watch.Elapsed.TotalSeconds.ToString());



                       

            Console.WriteLine("Press any key to continiue ..");
            Console.ReadKey();
        }

        private static void ClearArray(object[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = null;
            }
            GC.Collect();
        }
    }


    public class TestClass
    {

    }
}
