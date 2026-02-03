namespace ObjectInterfaces
{
    class Date : IDisposable, ICloneable
    {
        private int _day, _month, _year;
        public Date() : this(1, 1, 2000)
        {
            
        }
        public Date(int day, int month, int year)
        {
            _day = day;
            _month = month;
            _year = year;
        }
        public int Day
        {
            get { return _day; }
            set
            {
                _day = value;
            }
        }
        public int Month
        {
            get { return _month; }
            set { _month = value; }
        }
        public int Year
        {
            get { return _year; }
            set
            {
                _year = value;
            }
        }
        public override string ToString()
        {
            return $"{this.Day}-{this.Month}-{this.Year}";
        }
        public override bool Equals(object other)
        {
            if(other == null)
                return false;
            Date that = other as Date;
            if(that == null)
                return false;
            return this.Day == that.Day && this.Month == that.Month && this.Year == that.Year;
        }
        public override int GetHashCode()
        {
            return this.Day * 17 + this.Month * 31 + this.Year;
        }
        ~Date() // void Finalize()
        {
            // close the resource
            Console.WriteLine("Date.Finalize() called");
        }
        public void Dispose()
        {
            // close the resource
            Console.WriteLine("Date.Dispose() called");
        }
        public Date Copy()
        {
            Date temp = (Date)this.MemberwiseClone();
            return temp;
        }
        public object Clone()
        {
            return this.Copy(); 
        }
    }
    class Employee
    {
        private int _id;
        private double _salary;
        private Date _joining;
        public Employee() : this(1, 0.0, new Date(1, 1, 2000))
        {

        }
        public Employee(int id, double salary, Date joining)
        {
            _id = id;
            _salary = salary;
            _joining = joining;
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public double Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }
        public Date Joining
        {
            get { return _joining; }
            set { _joining = value; }
        }
        public override string ToString()
        {
            return $"Employee: Id={this.Id}, Salary={this.Salary}, Joining={this.Joining.ToString()}";
        }
        public Employee ShallowCopy()
        {
            Employee temp = (Employee)base.MemberwiseClone();
            return temp;
        }
        public Employee DeepCopy()
        {
            Employee temp = (Employee)base.MemberwiseClone();
            temp.Joining = this.Joining.Copy();
            // ...
            return temp;
        }
    }
    internal class Program
    {
        static void Main1(string[] args)
        {
            Date d1 = new Date(15, 1, 2026);
            Console.WriteLine("d1 = " + d1.ToString()); // 15-1-2026
            Type dateType = d1.GetType();
            Console.WriteLine("d1 Type = " + dateType); // ObjectInterfaces.Date
            Date d2 = new Date(15, 1, 2026);
            if(d1.Equals(d2))
                Console.WriteLine("d1 is same as d2");
            else
                Console.WriteLine("d1 is different than d2");
            if(Object.Equals(d1, d2))
                Console.WriteLine("d1 is same as d2");
            else
                Console.WriteLine("d1 is different than d2");
            if (Object.ReferenceEquals(d1, d2))
                Console.WriteLine("d1 is same as d2 -- addr comparison");
            else
                Console.WriteLine("d1 is different than d2 -- addr comparison");
            if (d1 == d2)
                Console.WriteLine("d1 is same as d2 -- addr comparison");
            else
                Console.WriteLine("d1 is different than d2 -- addr comparison");
        }
        static void Main2(string[] args)
        {
            Date d1 = new Date(1, 1, 2026);
            Console.WriteLine("d1 = " + d1);
            d1.Dispose();
            d1 = null;

            using (Date d2 = new Date(2, 2, 2026))
            {
                Console.WriteLine("d2 = " + d2);
            } // d2.Dispose();
        }
        static void Main3(string[] args)
        {
            Date d1 = new Date(1, 1, 2026);
            Console.WriteLine("d1 = " + d1);
            //Date d2 = d1.Copy();
            Date d2 = (Date)d1.Clone();
            Console.WriteLine("d2 = " + d2);
            if(Object.ReferenceEquals(d1, d2))
                Console.WriteLine("d1 is same as d2");
            else
                Console.WriteLine("d1 is different than d2");
        }
        static void Main(string[] args)
        {
            Employee e1 = new Employee(1, 1000.0, new Date(1, 1, 2025));
            Console.WriteLine("e1 => " + e1);
            Employee e2 = e1.ShallowCopy();
            Console.WriteLine("e2 => " + e2);
            //e1.Joining.Year = 2026;
            //Console.WriteLine("e1 => " + e1);
            //Console.WriteLine("e2 => " + e2);
            Employee e3 = e1.DeepCopy();
            Console.WriteLine("e1 => " + e1);
            Console.WriteLine("e3 => " + e3);
            e1.Joining.Year = 2026;
            Console.WriteLine("e1 => " + e1);
            Console.WriteLine("e3 => " + e3);
        }
    }
}
