namespace ClassObjects
{
    class Person
    {
        // Fields
        private string name;
        private string address;
        private int age;
        
        // Methods
        // constructor - initialize the object to default values
        public Person()
        {
            this.name = "Anonymous";
            this.address = "Unknown";
            this.age = 1;
            this.Mobile = "Empty";
            // open file
        }
        // constructor - initialize the object to given values
        public Person(string name, string address, int age, string mobile)
        {
            this.Name = name;
            this.Address = address;
            this.Age = age;
            this.Mobile = mobile;
        }
        // destructor - deinitialize the object
        //~Person()
        //{
        //    // close file
        //}
        
        public void Display()
        {
            Console.WriteLine("Name: {0}, Address: {1}, Age: {2}", this.name, this.address, this.age);
        }
        public void Accept()
        {
            Console.Write("Enter Name: ");
            this.name = Console.ReadLine();
            Console.Write("Enter Address: ");
            this.address = Console.ReadLine();
            Console.Write("Enter Age: ");
            string age = Console.ReadLine();
            this.age = Convert.ToInt32(age);
        }
        
        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetAddress(string address)
        {
            this.address = address;
        }
        public void SetAge(int age)
        {
            if (age > 0 && age < 100)
                this.age = age;
            else
                Console.WriteLine("Invalid Age");
        }
        public string GetName()
        {
            return this.name;
        }
        public string GetAddress()
        {
            return this.address;
        }
        public int GetAge()
        {
            return this.age;
        }
    
        public string Name
        {
            get
            {
                return this.name; 
            }
            set
            {
                this.name = value; 
            }
        }
        public string Address
        {
            get { return this.address; }
            set { this.address = value; }
        }
        public int Age
        {
            get { return this.age; }
            set {
                if(value > 0 && value < 100)
                    this.age = value;
                else
                    Console.WriteLine("Invalid Age");
            }
        }
        
        // auto-implmented properties - .Net 3.0+
        public string Mobile
        {
            get;
            set;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Person p1 = new Person();
            //p1.SetName("James Bond");
            //p1.SetAddress("London");
            //p1.SetAge(-5);
            //p1.Name = "James Bond"; // setter
            //p1.Address = "London"; // setter
            //p1.Age = 65; // setter
            //p1.Mobile = "9876543210"; // setter
            //p1.Display();
            //Console.WriteLine("p1 Name: " + p1.GetName() + "\np1 Address: " + p1.GetAddress() + "\np1 Age: " + p1.GetAge());
            //Console.WriteLine("p1 Name: " + p1.Name + "\np1 Address: " + p1.Address + "\np1 Age: " + p1.Age);
            //Console.WriteLine("p1 Mobile: " + p1.Mobile); // getter
            //Person p2 = new Person();
            //p2.Accept();
            //p2.Display();
            //Person p3 = new Person("Batman", "Gotham", 45, "12121212");
            //p3.Display();
            // object initializer -- constructor + properties
            Person p4 = new Person() { Name = "Ironman", Age = 50 };
            p4.Display();
        }
    }
}
