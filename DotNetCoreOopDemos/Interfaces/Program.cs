namespace Interfaces
{
    interface IShape
    {
        const double PI = 3.1415;
        double CalcArea();
        double CalcPeri();
        string Name
        {
            get; 
        }
    }
    interface IColor
    {
        string Color
        {
            get;
            set;
        }
    }
    class Rectangle : IShape, IColor
    {
        public double Length { get; set; }
        public double Breadth { get; set; }
        public double CalcArea()
        {
            return Length * Breadth;
        }
        public double CalcPeri()
        {
            return 2 * (Length + Breadth);
        }
        public string Name
        {
            get { return "Rectangle"; }
        }
        private string _color;
        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }
    }
    class Circle : IShape, IColor
    {
        public double Radius { get; set; }

        public double CalcArea()
        {
            return IShape.PI * Radius * Radius;
        }

        public double CalcPeri()
        {
            return 2 * IShape.PI * Radius;
        }
        public string Name
        {
            get { return "Circle";  }
        }

        public string Color
        {
            get;
            set;
        }
    }
    interface BackendDev
    {
        void Develop();
    }
    interface FrontendDev
    {
        void Develop();
    }
    class FresherFullStackDev : BackendDev, FrontendDev
    {
        public void Develop()
        {
            Console.WriteLine("Fresher implementing Backend and Frontend");
        }
    }
    class ExperiencedFullStackDev : FrontendDev, BackendDev
    {
        void FrontendDev.Develop()
        {
            Console.WriteLine("ExperiencedFullStackDev is Expert in Frontend Dev.");
        }
        void BackendDev.Develop()
        {
            Console.WriteLine("ExperiencedFullStackDev is Expert in Backend Dev.");
        }
    }
    interface ILogger
    {
        void Log(string message);
        void LogError(string error)
        {
            Console.WriteLine("Error: " + error);
        }
    }
    class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Console: " + message);
        }
    }
    class FileLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("File: " + message);
        }
        public void LogError(string error)
        {
            Console.WriteLine("File: Error: " + error);
        }
    }
    interface IA
    {
        void Fun()
        {
            Console.WriteLine("IA.Fun() called");
        }
    }
    interface IB : IA
    {
        void IA.Fun()
        {
            Console.WriteLine("IB.Fun() called");
        }
    }
    interface IC : IA
    {
        void IA.Fun()
        {
            Console.WriteLine("IC.Fun() called");
        }
    }
    class Derived : IB, IC
    {
        void IA.Fun()
        {
            Console.WriteLine("Derived.Fun() called");
        }
        public void Fun()
        {
            Console.WriteLine("** Derived.Fun() called");
        }
    }
    internal class Program
    {
        static void Main1(string[] args)
        {
            IShape shape = new Rectangle() { Length = 10, Breadth = 5 };
            //IShape shape = new Circle() { Radius = 7 };
            Console.WriteLine($"{shape.Name} Area = {shape.CalcArea()}, Peri = {shape.CalcPeri()}");
        }
        static void Main2(string[] args)
        {
            Circle c = new Circle() { Radius = 7, Color = "Red" };
            Console.WriteLine($"Circle Area: {c.CalcArea()}");
            Console.WriteLine($"Circle Color: {c.Color}");
        }
        static void Main3(string[] args)
        {
            FresherFullStackDev dev = new FresherFullStackDev();
            dev.Develop();
            BackendDev bDev = dev;
            bDev.Develop();
            FrontendDev fDev = dev;
            fDev.Develop();
        }
        static void Main4(string[] args)
        {
            ExperiencedFullStackDev dev = new ExperiencedFullStackDev();
            //dev.Develop();
            BackendDev bDev = dev;
            bDev.Develop();
            FrontendDev fDev = dev;
            fDev.Develop();
        }
        static void Main5(string[] args)
        {
            ILogger logger1 = new ConsoleLogger();
            logger1.Log("First Message");
            logger1.LogError("First Error");
            ILogger logger2 = new FileLogger();
            logger2.Log("Second Message");
            logger2.LogError("Second Error");
        }
        static void Main(string[] args)
        {
            IA d = new Derived();
            d.Fun();
        }
    }
}
