using System.Collections;

namespace GenericProg_Collection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // System.Collections ns --> ArrayList -- non-generic class
            ArrayList list1 = new ArrayList();
            list1.Add(10);
            list1.Add(20);
            //list1.Add("30"); // no compile time error
            list1.Add(40);
            foreach(object obj in list1)
            {
                int num = (int)obj; // runtime error for "30"
                Console.WriteLine(num);
            }
            Console.WriteLine();

            // System.Collections.Generic ns --> List<T> -- generic class
            List<int> list2 = new List<int>();
            list2.Add(10);
            list2.Add(20);
            //list2.Add("30"); // compile time error
            list2.Add(40);
            foreach(int num in list2)
            {
                Console.WriteLine(num);
            }
        }
    }
}
