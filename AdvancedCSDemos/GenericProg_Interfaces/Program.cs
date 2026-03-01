namespace GenericProg_Interfaces
{
    class Emp : IComparable<Emp>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            if(obj is Emp)
            {
                Emp other = (Emp)obj;
                return this.Id == other.Id;
            }
            return false;
        }
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Salary: {Salary}";
        }
        public int CompareTo(Emp other)
        {
            int diff = this.Id - other.Id;
            return diff;
        }
    }

    class EmpNameComparer : IComparer<Emp>
    {
        public int Compare(Emp x, Emp y)
        {
            int diff = x.Name.CompareTo(y.Name);
            return diff;
        }
    }

    class EmpSalComparerDesc : IComparer<Emp>
    {
        public int Compare(Emp x, Emp y)
        {
            int diff = x.Salary.CompareTo(y.Salary);
            return -diff;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Emp[] arr = new Emp[5]
            {
                new Emp { Id = 2, Name = "John", Salary = 2000.0 },
                new Emp { Id = 5, Name = "Mark", Salary = 1500.0 },
                new Emp { Id = 1, Name = "Steve", Salary = 3500.0 },
                new Emp { Id = 4, Name = "Peter", Salary = 4000.0 },
                new Emp { Id = 3, Name = "Tony", Salary = 3000.0 }
            };
            Console.WriteLine("Before Sort: "); 
            foreach (Emp item in arr)
                Console.WriteLine(item);
            //Array.Sort(arr);
            //Array.Sort(arr, new EmpNameComparer());
            Array.Sort(arr, new EmpSalComparerDesc());
            Console.WriteLine("After Sort: ");
            foreach (Emp item in arr)
                Console.WriteLine(item);
        }
    }
}
