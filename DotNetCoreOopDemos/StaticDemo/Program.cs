using System.Runtime.CompilerServices;

namespace StaticDemo
{
    class StartupInit
    {
        [ModuleInitializer]
        public static void ModuleInit()
        {
            Console.WriteLine("Module Initializer -- One time initialization.");
        }
    }
    class Chair
    {
        private int _weight;
        private string _color;
        private static double _price = 100.0; // static field initializer
        static Chair() // static constructor
        {
            _price = 300.0;
        }

        public Chair() : this(0, "")
        {
        }
        public Chair(int weight, string color)
        {
            _weight = weight;
            _color = color;
        }
        public int Weight
        {
            get { return _weight; } 
            set { _weight = value; }
        }
        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }
        public override string ToString()
        {
            return $"Chair: Weight={this.Weight} kg, Color={this.Color}, Price={Chair._price}";
        }
        public static void DisplayPrice()
        {
            Console.WriteLine("Chair Price: " + _price);
        }
        public static double Price
        {
            get { return _price; } 
            set { _price = value; }
        }
    }
    static class Util
    {
        public static int Add(int a, int b)
        {
            return a + b; 
        }
        public static int Subtract(int a, int b)
        {
            return a - b;
        }
    }
    static class ChairHelpers
    {
        public static void Display(this Chair chair)
        {
            Console.WriteLine("Weight: " + chair.Weight);
            Console.WriteLine("Color: " + chair.Color);
            Console.WriteLine("Price: " + Chair.Price);
        }
    }
    static class StringHelpers
    {
        public static string SwapCase(this string s)
        {
            string res = "";
            foreach(char c in s)
            {
                if (char.IsUpper(c))
                    res += char.ToLower(c);
                else if (char.IsLower(c))
                    res += char.ToUpper(c);
                else
                    res += c;
            }
            return res;
        }
        public static string Concat(this string s, int num, bool flag)
        {
            s += " num=" + num;
            s += " flag=" + flag;
            return s;
        }
    }

    class Circle
    {
        public const double PI = 3.14; // field init
        private readonly double _radius = 7.0; // field init
        public Circle(double radius) // constructor
        {
            _radius = radius;
        }
        public double CalcArea()
        {
            return PI * _radius * _radius;
        }
    }

    class Vector
    {
        public int X { get; set; }
        public int Y { get; set; }
        // ...
        public static Vector operator +(Vector a, Vector b)
        {
            Vector res = new Vector();
            res.X = a.X + b.X;
            res.Y = a.Y + b.Y;
            return res;
        }
        public static bool operator==(Vector a, Vector b)
        {
            return a.X == b.X && a.Y == b.Y;
        }
        public static bool operator!=(Vector a, Vector b)
        {
            return !(a == b);
        }
        public override string ToString()
        {
            return $"(x={X},y={Y})";
        }
    }
    internal class Program
    {
        static void Main1(string[] args)
        {
            //Chair.Price = 200.0;
            Chair c1 = new Chair(1, "Red");
            Chair c2 = new Chair(2, "Blue");
            Chair c3 = new Chair(3, "Green");
            Console.WriteLine("c1 => " + c1);
            Console.WriteLine("c2 => " + c2);
            Console.WriteLine("c3 => " + c3);
            Chair.DisplayPrice();
        }
        static void Main2(string[] args)
        {
            //Util util = new Util();
            Console.WriteLine("Add --> " + Util.Add(22, 7));
            Console.WriteLine("Subtract --> " + Util.Subtract(22, 7));
        }
        static void Main3(string[] args)
        {
            Chair c1 = new Chair(2, "Black");
            c1.Display();
            string str = "Nilesh Ghule";
            string newStr = str.SwapCase();
            Console.WriteLine("New Str : " + newStr);
            string testStr = str.Concat(42, true);
            Console.WriteLine("Test Str : " + testStr);
        }
        static void Main4(string[] args)
        {
            Circle c = new Circle(14);
            Console.WriteLine("Area = " + c.CalcArea());
            Console.WriteLine("PI = " + Circle.PI);
        }
        static void Main(string[] args)
        {
            Vector v1 = new Vector() { X = 1, Y = 2 };
            Vector v2 = new Vector() { X = 3, Y = 4 };
            Vector v3 = v1 + v2; // v3 = Vector.operator+(v1, v2);
            Console.WriteLine("v3 => " + v3); // 4, 6
            if(v1 == v2)
                Console.WriteLine("v1 and v2 are same");
            else
                Console.WriteLine("v1 and v2 are different");
        }
    }
}
