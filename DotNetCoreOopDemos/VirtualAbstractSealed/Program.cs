namespace VirtualAbstractSealed
{
    abstract class Emp
    {
        public int Id { get; set; }
        public double Salary { get; set; }
        public virtual double CalcIncome()
        {
            return Salary;
        }
        public abstract void DoWork();
        public static double CalcTotalExpenses(Emp[] arr)
        {
            double total = 0.0;
            foreach (Emp emp in arr)
                total += emp.CalcIncome();
            return total;
        }
    }
    class Labor : Emp
    {
        private int _hours;
        private double _rate;
        public int Hours
        {
            get { return _hours; }
            set {
                _hours = value;
                this.Salary = this._hours * this._rate;
            }
        }
        public double Rate
        {
            get { return _rate; }
            set {
                _rate = value;
                this.Salary = this._hours * this._rate;
            }
        }
        public override void DoWork()
        {
            Console.WriteLine("Labor: Physical Work."); ;
        }
    }
    class Manager : Emp
    {
        public double Bonus { get; set; }
        public sealed override double CalcIncome()
        {
            return Salary + Bonus;
        }
        public override void DoWork()
        {
            Console.WriteLine("Manager: Management Work");
        }
    }
    class SalesManager : Manager
    {
        // ...
        public override void DoWork()
        {
            Console.WriteLine("SalesManager: Sales Management Work");
        }
    }
    class HRManager : Manager
    {
        public override void DoWork()
        {
            Console.WriteLine("HRManager: HR Management Work");
        }
    }
    //class SpecialManager : SalesManager, HRManager
    //{
    // ...
    //}
    class Salesman : Emp
    {
        public double Commission { get; set; }
        public sealed override double CalcIncome()
        {
            return Salary + Commission;
        }

        public override void DoWork()
        {
            Console.WriteLine("Salesman: Sales Work");
        }
    }
    sealed class Clerk : Emp
    {
        public override void DoWork()
        {
            Console.WriteLine("Clerk: Clerical Work");
        }
    }
    //class DataEntryClerk : Clerk
    //{
    //}

    internal class Program
    {
        static void Main(string[] args)
        {
            //Emp emp = new Emp();
            Emp[] arr = new Emp[]
            {
                new Labor() { Id=3, Rate=100.0, Hours=20},
                new Salesman() { Id=5, Salary=3000.0, Commission=1000.0},
                new Manager() { Id=1, Salary=6000.0, Bonus=2000.0},
                new HRManager() { Id=2,Salary=4000.0, Bonus=1000.0 },
                new SalesManager() { Id=4, Salary=3500.0, Bonus=1500.0},
                new Clerk() { Id=6, Salary=2500.0}
            };
            double totalExpenses = Emp.CalcTotalExpenses(arr);
            Console.WriteLine("Total Expenses: " + totalExpenses);
            foreach (Emp emp in arr)
            {
                emp.DoWork();
            }
        }
    }
}
