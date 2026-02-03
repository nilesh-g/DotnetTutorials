namespace Functions
{
    internal class Program
    {
        static void PrintInfo1(string name, int age, string addr, string email)
        {
            Console.WriteLine($"Name={name}, Age={age}, Address={addr}, Email={email}");
        }
        static void Main1(string[] args)
        {
            // call fn with positional args
            PrintInfo1("James Bond", 65, "London", "james@bond.com");
            // call fn with named args
            PrintInfo1(age: 50, name: "Ironman", email: "ironman@avenger.com", addr: "USA");
            // call fn with mixed args
            PrintInfo1(name: "Batman", 45, email: "batman@test.com", addr: "Gotham");
            // ERROR: positional args must be given on right position.
            //PrintInfo1(name: "Batman", email: "batman@test.com", 45, addr: "Gotham");
        }

        static void PrintInfo2(string name, int age, string addr = "Anywhere", string email = "Unknown")
        {
            Console.WriteLine($"Name={name}, Age={age}, Address={addr}, Email={email}");
        }
        static void Main2(string[] args)
        {
            PrintInfo2("James Bond", 65, "London", "james@bond.com");
            PrintInfo2("Superman", 876, "Crypton");
            PrintInfo2(age: 40, name: "Spiderman");
        }
        static void Main3(string[] args)
        {
            string greet = "Hello";
            // Local Function
            void PrintInfo1(string name, int age, string addr, string email)
            {
                greet = greet.ToUpper();
                Console.WriteLine($"{greet} -> Name={name}, Age={age}, Address={addr}, Email={email}");
            }

            // Static Local Function -- cannot access local vars out outer method.
            static void PrintInfo2(string name, int age, string addr, string email)
            {
                //greet = greet.ToUpper();
                Console.WriteLine($"Name={name}, Age={age}, Address={addr}, Email={email}");
            }

            PrintInfo1("James Bond", 65, "London", "james@bond.com");
            Console.WriteLine($"greet = {greet}");
        }

        public static void Swap1(int x, int y)
        {
            int t = x; x = y; y = t;
            Console.WriteLine($"Swap1: x={x}, y={y}");
        }
        static void Main4(string[] args)
        {
            int num1 = 22, num2 = 7;
            Console.WriteLine($"Before Swap: num1={num1}, num2={num2}");
            Swap1(num1, num2);
            Console.WriteLine($"After  Swap: num1={num1}, num2={num2}");
        }

        public class MyInt
        {
            public int n;
            public MyInt(int n = 0)
            {
                this.n = n;    
            }
        }
        public static void Swap2(MyInt x, MyInt y)
        {
            int t = x.n; x.n = y.n; y.n = t;
            Console.WriteLine($"Swap2: x={x.n}, y={y.n}");
        }
        static void Main5(string[] args)
        {
            MyInt num1 = new MyInt(22), num2 = new MyInt(7);
            Console.WriteLine($"Before Swap: num1={num1.n}, num2={num2.n}");
            Swap2(num1, num2);
            Console.WriteLine($"After Swap: num1={num1.n}, num2={num2.n}");
        }

        // ref keyword -- in-out param
        public static void Swap3(ref int x, ref int y)
        {
            int t = x; x = y; y = t;
            Console.WriteLine($"Swap3: x={x}, y={y}");
        }
        static void Main6(string[] args)
        {
            int num1 = 22, num2 = 7;
            Console.WriteLine($"Before Swap: num1={num1}, num2={num2}");
            Swap3(ref num1, ref num2);
            Console.WriteLine($"After  Swap: num1={num1}, num2={num2}");
        }

        public static bool Divide(in double num, in double den, out double res)
        {
            res = 0;
            if(den == 0)
                return false;
            res = num / den;
            return true;
        }
        static void Main(string[] args)
        {
            double num1 = 22, num2 = 0, result;
            if(Divide(num1, num2, out result))
                Console.WriteLine("result: " + result);
            else
                Console.WriteLine("Cannot divide by Zero.");
        }
    }
}
