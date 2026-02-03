namespace StructEnums
{
    struct Point
    {
        private int _x;
        private int _y;
        public Point() : this(0, 0)
        {
        }
        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
        public void Display()
        {
            Console.WriteLine("X={0}, Y={1}", X, Y);
        }
    }
    readonly struct Distance
    {
        readonly int feet;
        public int Inches
        {
            get;
            init;
        }
        public int Feet
        {
            get { return feet; } 
            init { feet = value; }
        }
    }
    record struct Date(int Day, int Month, int Year)
    {
        public void Display()
        {
            Console.WriteLine("{0}-{1}-{2}", Day, Month, Year);
        }
    }
    enum Weekday
    {
        Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday
    }
    enum Color
    {
        Red=4, Green, Blue=2, Yellow, Black, White=-3, Purple, Orange
    }
    enum Menu
    {
        Exit, Add, Subtract, Multiply, Divide
    }
    internal class Program
    {
        static void Main1(string[] args)
        {
            Point p1 = new Point();
            p1.Display();
            Point p2 = new Point(2, 6);
            p2.Display();
            Point p3 = new Point() { X = 4, Y = 7 };
            p3.Display();
        }
        static void Main2(string[] args)
        {
            Distance d1 = new Distance(); // f=0, i=0
            Distance d2 = new Distance() { Feet = 1, Inches = 1 };
            // ...
        }
        static void Main3(string[] args)
        {
            Date d1 = new Date() { Day = 1, Month = 1, Year = 2026 };
            Date d2 = new Date() { Day = 1, Month = 1, Year = 2025 };
            Console.WriteLine("d1 = " + d1.ToString());
            Console.WriteLine("d2 = " + d2.ToString());
            if(d1 == d2)
                Console.WriteLine("d1 and d2 are same");
            else
                Console.WriteLine("d1 and d2 are different");
            d1.Display();
         }

        static void Main4(string[] args)
        {
            Weekday d1 = Weekday.Monday;
            Console.WriteLine("d1 -> " + d1 + " : " + (int)d1);
            Weekday d2 = (Weekday)5;
            Console.WriteLine("d2 -> " + d2 + " : " + (int)d2);
            Weekday d3 = (Weekday)21;
            Console.WriteLine("d3 -> " + d3 + " : " + (int)d3);
        }
        static void Main5(string[] args)
        {
            Color c1 = (Color)4;
            Console.WriteLine("c1 -> " + c1 + " : " + (int)c1);

        }
        static void Main(string[] args)
        {
            Array menus = Enum.GetValues(typeof(Menu));
            foreach (Menu menu in menus)
                Console.WriteLine((int)menu + ". " + menu);
            Console.Write("Enter choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            Menu m = (Menu)choice;
            switch (m)
            {
                case Menu.Add:
                    Console.WriteLine("Add");
                    break;
                case Menu.Subtract:
                    Console.WriteLine("Subtract");
                    break;
                case Menu.Multiply:
                    Console.WriteLine("Multiply");
                    break;
                case Menu.Divide:
                    Console.WriteLine("Divide");
                    break;
                default:
                    Console.WriteLine("Unknown");
                    break;
            }
        }
    }
}
