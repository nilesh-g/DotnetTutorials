using System.Collections;

namespace GenericProg_Constraints
{
    internal class Program
    {
        class MyClass
        {
            // ...
        }
        public static T GetMax<T>(T x, T y) where T : IComparable
        {
            if (x.CompareTo(y) > 0)
                return x;
            return y;
        }
        public static T Create<T>() where T : class, new()
        {
            return new T();
        }
        static void Main(string[] args)
        {
            string ret1 = GetMax("A", "B");
            Console.WriteLine("Max Str: " + ret1);

            //GetMax(new MyClass(), new MyClass()); // compiler error : due to generic constraint
            ArrayList list = Create<ArrayList>();
            list.Add("A");
            Console.WriteLine(list);
        }
    }
}
