namespace ObjectSlicingVirtual
{
    class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public Person()
        {
            this.Age = 0;
            this.Name = "";
        }
        public Person(string name, int age)
        {
            this.Age = age;
            this.Name = name;
        }
        /*
        public void Display()
        {
            Console.WriteLine($"Person: Name={this.Name}, Age={this.Age}");
        }
        */
        public virtual void Display()
        {
            Console.WriteLine($"Person: Name={this.Name}, Age={this.Age}");
        }
    }
    class Player : Person
    {
        public string Sport { get; set; }
        public Player()
        {
            this.Sport = "";
        }
        public Player(string name, int age, string sport)
            :base(name, age)
        {
            this.Sport = sport;
        }
        /*
        public new void Display()
        {
            base.Display();
            Console.WriteLine($"Player: Sport={this.Sport}");
        }
        */
        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Player: Sport={this.Sport}");
        }
    }
    internal class Program
    {
        static void Main1(string[] args)
        {
            Person p1 = new Player("Messi", 37, "Football");
            p1.Display();
            Player p2 = new Player("Ronaldo", 39, "Football");
            p2.Display();
            // "is" operator -- bool -- 
            //  return true -- when ref is pointing to an object of the given class or its derived class
            //  otherwise return false
            Person p3 = new Person();
            Console.WriteLine($"p3 is Player -> {p3 is Player}"); // False
            Console.WriteLine($"p3 is Person -> {p3 is Person}"); // True
            Person p4 = new Player();
            Console.WriteLine($"p4 is Player -> {p4 is Player}"); // True
            Console.WriteLine($"p4 is Person -> {p4 is Person}"); // True
            // 
            //Person p5 = new Person();
            Person p5 = new Player();
            if (p5 is Player)
            {
                Player p = (Player)p5; // Downcasting
                p.Name = "Abc";
                p.Age = 43;
                p.Sport = "Cricket";
                p.Display();
            }
            else
            {
                Person p = p5;
                p.Name = "Nilesh";
                p.Age = 42;
                p.Display();
            }

            Player p6 = p5 as Player; // Runtime check + Down-Casting
            if(p6 != null)
            {
                Console.WriteLine("Player Found.");
                p6.Display();
            }
        }

        static void Main(string[] args)
        {
            //Person p = new Player("Ronaldo", 39, "Football");
            //Person p = new Person("Nilesh", 42);
            Person p = new Person();
            p.Display();
        }
    }
}
