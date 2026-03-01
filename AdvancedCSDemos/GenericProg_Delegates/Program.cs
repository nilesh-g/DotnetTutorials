namespace GenericProg_Delegates
{
    // user-defined generic delegate
    delegate void Consumer<T>(T obj);

    internal class Program
    {
        public static bool IsEven(int x)
        {
            return x % 2 == 0;
        }
        static void Main(string[] args)
        {
            Consumer<string> print = Console.WriteLine;
            print("Hello World!");

            // delegate void Action<T>(T obj);
            Action<string> print2 = Console.WriteLine;
            print2("Bye World!");

            // delegate bool Predicate<T>(T obj);
            Predicate<int> isEven = IsEven;
            Console.WriteLine("IsEven -> " + isEven(10)); // true

            Predicate<int> isOdd = x => x % 2 != 0;
            Console.WriteLine("IsOdd -> " + isOdd(10)); // false

            // delegate R Func<T, R>(T obj);
            Func<string, int> contertToInt = int.Parse;
            int res = contertToInt("1234");
            Console.WriteLine("Converted Int: " + res);

            Func<int, int, int> add = Add;
            int sum = add(10, 20);
            Console.WriteLine("Sum: " + sum);

            Func<int, int, int> sub = (x, y) => x - y;
            int result = sub(22, 7);
            Console.WriteLine("Subtract: " + result);
        }

        public static int Add(int a, int b)
        {
            return a + b;
        }
    }
}
