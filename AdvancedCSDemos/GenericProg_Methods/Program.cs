namespace GenericProg_Methods
{
    internal class Program
    {
        public static void Swap<T>(ref T a, ref T b)
        {
            T t = a;
            a = b;
            b = t;
        }
        static void Main(string[] args)
        {
            string s1 = "Hello", s2 = "World";
            Console.WriteLine($"Before Swap: s1 = {s1}, s2 = {s2}");
            Swap(ref s1, ref s2); // T => string
            Console.WriteLine($"After Swap: s1 = {s1}, s2 = {s2}");

            int i1 = 10, i2 = 20;
            Console.WriteLine($"Before Swap: i1 = {i1}, i2 = {i2}");
            Swap(ref i1, ref i2); // T => int
            Console.WriteLine($"After Swap: i1 = {i1}, i2 = {i2}");
        }
    }
}
