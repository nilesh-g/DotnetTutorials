namespace InheritanceBasics
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
        public void DisplayPerson()
        {
            Console.WriteLine($"Person: Name={this.Name}, Age={this.Age}");
        }
    }
    class Student : Person
    {
        public int Roll { get; set; }
        public double Marks { get; set; }
        public Student()
        {
            this.Roll = 0;
            this.Marks = 0.0;
        }
        public Student(string name, int age, int roll, double marks)
            :base(name, age)
        {
            this.Roll = roll;
            this.Marks = marks;
        }
        public void DisplayStudent()
        {
            base.DisplayPerson();
            Console.WriteLine($"Student: Roll={this.Roll}, Marks={this.Marks}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("Nilesh", 42);
            p1.DisplayPerson();
            Student s1 = new Student();
            //s1.DisplayPerson();
            Student s2 = new Student("John", 23, 12, 87.0);
            s2.DisplayStudent();
            Person p2 = new Student("Sachin", 21, 234, 86.0);
            p2.DisplayPerson();
            //p2.DisplayStudent(); // Error
        }
    }
}
