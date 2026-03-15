using System.Collections;

namespace LINQ
{
    internal class Program
    {
        public static void Main1(string[] args)
        {
            #region local variables (var keyword)
            var name = "Nilesh"; // string
            var age = 25; // int
            var flag = true; // bool
            var salary = 50000.00; // double
            var e1 = new Emp(); // object
            var d1 = new Dept(); // object
            #endregion

            #region using var keyword
            // var can be used with any class (pre-defined or user-defined or generic)
            var list = new List<int>() { 1, 2, 3, 4 };
            foreach(var n in list)
                Console.WriteLine(n);
            #endregion

            #region var limitations
            // 1. must be initialized at the time of declaration
            //var var1; // compiler error
            // 2. cannot be null
            //var var2 = null; // compiler error
            //var var2 = (string) null;
            // 3. cannot be reassigned to another data type
            var var3 = 10;
            //var3 = "Test"; // compiler error
            #endregion
        }
        public static void Main2(string[] args)
        {
            #region anonymous type simple example
            // anoymous type object hold readonly data & assigned to var reference
            var p1 = new { Name = "Nilesh", Age = 25, City = "Pune" };
            // checking anonymous type name?
            Console.WriteLine("p1 Type = " + p1.GetType());
            // <>f__AnonymousType0`3[System.String,System.Int32,System.String]
            // accessing properties
            Console.WriteLine("Name = " + p1.Name);
            Console.WriteLine("Age = " + p1.Age);
            Console.WriteLine("City = " + p1.City);
            // readonly properties
            //p1.Age = 42; // compiler error
            #endregion

            #region anonymous types auto-implemented methods
            // auto-implemented: ToString()
            Console.WriteLine("p1 -> " + p1.ToString());
            // auto-implemented: Equals(), GetHashCode()
            var p2 = new { Name = "Nilesh", Age = 42, City = "Pune" };
            if(p1.Equals(p2))
                Console.WriteLine("p1 and p2 are equal");
            else
                Console.WriteLine("p1 and p2 are not equal");
            #endregion

            #region array/collection of anonymous type objects
            // create array and iterate with foreach loop
            Console.WriteLine();
            var persons1 = new[]
            {
                new {Name="John", Age=42},
                new {Name="Dagny", Age=40},
            };
            foreach(var p in persons1)
                Console.WriteLine(p);
            Console.WriteLine();
            // create list and iterate with foreach loop
            var persons2 = new[]
            {
                new {Name="John", Age=42},
                new {Name="Dagny", Age=40},
            }.ToList();
            foreach(var p in persons2)
                Console.WriteLine(p);
            #endregion
        }

        public static void Main3(string[] args)
        {
            #region Sample data set
            List<Emp> emps = new List<Emp>
            {
                new Emp { EmpId = 7369, Ename = "SMITH", Job = "CLERK", ManagerId = 7902, Hire = DateTime.Parse("1980-12-17"), Salary = 800.00, Commission = null, DeptId = 20 },
                new Emp { EmpId = 7499, Ename = "ALLEN", Job = "SALESMAN", ManagerId = 7698, Hire = DateTime.Parse("1981-02-20"), Salary = 1600.00, Commission = 300.00, DeptId = 30 },
                new Emp { EmpId = 7521, Ename = "WARD", Job = "SALESMAN", ManagerId = 7698, Hire = DateTime.Parse("1981-02-22"), Salary = 1250.00, Commission = 500.00, DeptId = 30 },
                new Emp { EmpId = 7566, Ename = "JONES", Job = "MANAGER", ManagerId = 7839, Hire = DateTime.Parse("1981-04-02"), Salary = 2975.00, Commission = null, DeptId = 20 },
                new Emp { EmpId = 7654, Ename = "MARTIN", Job = "SALESMAN", ManagerId = 7698, Hire = DateTime.Parse("1981-09-28"), Salary = 1250.00, Commission = 1400.00, DeptId = 30 },
                new Emp { EmpId = 7698, Ename = "BLAKE", Job = "MANAGER", ManagerId = 7839, Hire = DateTime.Parse("1981-05-01"), Salary = 2850.00, Commission = null, DeptId = 30 },
                new Emp { EmpId = 7782, Ename = "CLARK", Job = "MANAGER", ManagerId = 7839, Hire = DateTime.Parse("1981-06-09"), Salary = 2450.00, Commission = null, DeptId = 10 },
                new Emp { EmpId = 7788, Ename = "SCOTT", Job = "ANALYST", ManagerId = 7566, Hire = DateTime.Parse("1982-12-09"), Salary = 3000.00, Commission = null, DeptId = 20 },
                new Emp { EmpId = 7839, Ename = "KING", Job = "PRESIDENT", ManagerId = null, Hire = DateTime.Parse("1981-11-17"), Salary = 5000.00, Commission = null, DeptId = 10 },
                new Emp { EmpId = 7844, Ename = "TURNER", Job = "SALESMAN", ManagerId = 7698, Hire = DateTime.Parse("1981-09-08"), Salary = 1500.00, Commission = 0.00, DeptId = 30 },
                new Emp { EmpId = 7876, Ename = "ADAMS", Job = "CLERK", ManagerId = 7788, Hire = DateTime.Parse("1983-01-12"), Salary = 1100.00, Commission = null, DeptId = 20 },
                new Emp { EmpId = 7900, Ename = "JAMES", Job = "CLERK", ManagerId = 7698, Hire = DateTime.Parse("1981-12-03"), Salary = 950.00, Commission = null, DeptId = 30 },
                new Emp { EmpId = 7902, Ename = "FORD", Job = "ANALYST", ManagerId = 7566, Hire = DateTime.Parse("1981-12-03"), Salary = 3000.00, Commission = null, DeptId = 20 },
                new Emp { EmpId = 7934, Ename = "MILLER", Job = "CLERK", ManagerId = 7782, Hire = DateTime.Parse("1982-01-23"), Salary = 1300.00, Commission = null, DeptId = 10 }
            };

            List<Dept> depts = new List<Dept>
            {
                new Dept { DeptId = 10, Dname = "Accounting", Location = "New York" },
                new Dept { DeptId = 20, Dname = "Research", Location = "Dallas" },
                new Dept { DeptId = 30, Dname = "Sales", Location = "Chicago" },
                new Dept { DeptId = 40, Dname = "Operations", Location = "Boston" }
            };
            #endregion

            #region LINQ Method Syntax
            //Console.WriteLine("\nEmp Names: ");
            var result1 = emps.Select(e => e.Ename);
            foreach(var name in result1)
                Console.WriteLine(name);
            Console.WriteLine();

            //Console.WriteLine("\nEmp Names and Salaries: ");
            //var result2 = emps.Select(e => new { Name=e.Ename, Sal=e.Salary });
            var result2 = emps.Select(e => new { e.Ename, e.Salary });
            foreach (var item in result2)
                Console.WriteLine(item);
            Console.WriteLine();

            //Console.WriteLine("Emps with salary > 1000: ");
            var result3 = emps.Where(e => e.Salary > 1000);
            foreach (var item in result3)
                Console.WriteLine(item);
            Console.WriteLine();

            //Console.WriteLine("\nEmps sorted by EmpId: ");
            var result4 = emps.OrderBy(e => e.EmpId);
            foreach (var item in result4)
                Console.WriteLine(item);
            Console.WriteLine();

            //Console.WriteLine("\nEmps sorted by DeptId (asc) then by salary (desc): ");
            var result5 = emps.OrderBy(e => e.DeptId).ThenByDescending(e => e.Salary);
            foreach (var item in result5)
                Console.WriteLine(item);
            Console.WriteLine();

            //Console.WriteLine("\nEmps grouped by Job: ");
            var result6 = emps.GroupBy(e => e.Job);
            foreach (var item in result6)
            {
                Console.WriteLine(item.Key + " -> ");
                foreach(var emp in item)
                    Console.WriteLine(emp);
            }
            Console.WriteLine();

            //Console.WriteLine("\nJobwise Total Sal & Max Sal: ");
            var result7 = emps.GroupBy(e => e.Job).Select(g => new
            {
                Job = g.Key,
                TotalSal = g.Sum(e => e.Salary),
                MaxSal = g.Max(e => e.Salary)
            });
            foreach (var item in result7)
                Console.WriteLine(item);
            Console.WriteLine();
            #endregion

            #region LINQ Method Syntax vs Query Syntax
            Console.WriteLine("\nEmps with salary > 1000, sorted by Ename: ");
            var result8 = emps.Where(e => e.Salary > 1000)
                            .OrderBy(e => e.Ename);
            foreach (var item in result8)
                Console.WriteLine(item);
            Console.WriteLine();

            Console.WriteLine("\nEmps with salary > 1000, sorted by Ename: ");
            var result9 = from e in emps
                          where e.Salary > 1000
                          orderby e.Ename
                          select e;
            foreach (var item in result9)
                Console.WriteLine(item);
            Console.WriteLine();
            #endregion

            #region LINQ Query Syntax
            Console.WriteLine("\nGet All Emps: ");
            var result10 = from e in emps select e;
            foreach (var item in result10)
                Console.WriteLine(item);
            Console.WriteLine();

            Console.WriteLine("\nGet All Emps -- Name and Salary only: ");
            var result11 = from e in emps select new { e.Ename, e.Salary };
            foreach (var item in result11)
                Console.WriteLine(item);
            Console.WriteLine();

            Console.WriteLine("\nAll Emps in Sorted order of Sal (desc): ");
            var result12 = from e in emps 
                           orderby e.Salary descending
                           select e;
            foreach (var item in result12)
                Console.WriteLine(item);
            Console.WriteLine();

            Console.WriteLine("\nDeptwise Total Salary: ");
            var result13 = from e in emps
                           group e by e.DeptId into gr
                           select new
                           {
                               DeptId = gr.Key,
                               TotalSal = gr.Sum(e => e.Salary)
                           };
            foreach (var item in result13)
                Console.WriteLine(item);
            Console.WriteLine();

            Console.WriteLine("\nEmp and Dept Names: ");
            var result14 = from e in emps
                           join d in depts on e.DeptId equals d.DeptId
                           select new
                           {
                               EmpName = e.Ename,
                               DeptName = d.Dname
                           };
            foreach (var item in result14)
                Console.WriteLine(item);
            Console.WriteLine();

            #endregion

            #region LINQ Mixed Syntax - Method Syntax + Query Syntax
            Console.WriteLine("\nTop 3 Emps (Skipping the First): ");
            var result15 = (from e in emps
                           orderby e.Salary descending
                           select e)
                           .Skip(1).Take(3);
            foreach (var item in result15)
                Console.WriteLine(item);
            Console.WriteLine();
            #endregion
        }

        public static void Main4(string[] args)
        {
            #region Sample data sets
            List<Emp> emps = new List<Emp>
            {
                new Emp { EmpId = 7369, Ename = "SMITH", Job = "CLERK", ManagerId = 7902, Hire = DateTime.Parse("1980-12-17"), Salary = 800.00, Commission = null, DeptId = 20 },
                new Emp { EmpId = 7499, Ename = "ALLEN", Job = "SALESMAN", ManagerId = 7698, Hire = DateTime.Parse("1981-02-20"), Salary = 1600.00, Commission = 300.00, DeptId = 30 },
                new Emp { EmpId = 7521, Ename = "WARD", Job = "SALESMAN", ManagerId = 7698, Hire = DateTime.Parse("1981-02-22"), Salary = 1250.00, Commission = 500.00, DeptId = 30 },
                new Emp { EmpId = 7566, Ename = "JONES", Job = "MANAGER", ManagerId = 7839, Hire = DateTime.Parse("1981-04-02"), Salary = 2975.00, Commission = null, DeptId = 20 },
                new Emp { EmpId = 7654, Ename = "MARTIN", Job = "SALESMAN", ManagerId = 7698, Hire = DateTime.Parse("1981-09-28"), Salary = 1250.00, Commission = 1400.00, DeptId = 30 },
                new Emp { EmpId = 7698, Ename = "BLAKE", Job = "MANAGER", ManagerId = 7839, Hire = DateTime.Parse("1981-05-01"), Salary = 2850.00, Commission = null, DeptId = 30 },
                new Emp { EmpId = 7782, Ename = "CLARK", Job = "MANAGER", ManagerId = 7839, Hire = DateTime.Parse("1981-06-09"), Salary = 2450.00, Commission = null, DeptId = 10 },
                new Emp { EmpId = 7788, Ename = "SCOTT", Job = "ANALYST", ManagerId = 7566, Hire = DateTime.Parse("1982-12-09"), Salary = 3000.00, Commission = null, DeptId = 20 },
                new Emp { EmpId = 7839, Ename = "KING", Job = "PRESIDENT", ManagerId = null, Hire = DateTime.Parse("1981-11-17"), Salary = 5000.00, Commission = null, DeptId = 10 },
                new Emp { EmpId = 7844, Ename = "TURNER", Job = "SALESMAN", ManagerId = 7698, Hire = DateTime.Parse("1981-09-08"), Salary = 1500.00, Commission = 0.00, DeptId = 30 },
                new Emp { EmpId = 7876, Ename = "ADAMS", Job = "CLERK", ManagerId = 7788, Hire = DateTime.Parse("1983-01-12"), Salary = 1100.00, Commission = null, DeptId = 20 },
                new Emp { EmpId = 7900, Ename = "JAMES", Job = "CLERK", ManagerId = 7698, Hire = DateTime.Parse("1981-12-03"), Salary = 950.00, Commission = null, DeptId = 30 },
                new Emp { EmpId = 7902, Ename = "FORD", Job = "ANALYST", ManagerId = 7566, Hire = DateTime.Parse("1981-12-03"), Salary = 3000.00, Commission = null, DeptId = 20 },
                new Emp { EmpId = 7934, Ename = "MILLER", Job = "CLERK", ManagerId = 7782, Hire = DateTime.Parse("1982-01-23"), Salary = 1300.00, Commission = null, DeptId = 10 }
            };
            List<Dept> depts = new List<Dept>
            {
                new Dept { DeptId = 10, Dname = "Accounting", Location = "New York" },
                new Dept { DeptId = 20, Dname = "Research", Location = "Dallas" },
                new Dept { DeptId = 30, Dname = "Sales", Location = "Chicago" },
                new Dept { DeptId = 40, Dname = "Operations", Location = "Boston" }
            };
            #endregion

            #region Set Operations
            Console.WriteLine("\nDistinct Emp Jobs: ");
            var result1 = emps.Select(e => e.Job).Distinct();
            foreach (var item in result1)
                Console.WriteLine(item);
            Console.WriteLine();

            var emps20 = emps.Where(e => e.DeptId == 20);
            var clerks = emps.Where(e => e.Job == "CLERK");
            Console.WriteLine("\nUnion of Emps in Dept 20 and All Clerks: ");
            var result2 = emps20.Union(clerks);
            foreach (var item in result2)
                Console.WriteLine(item);
            Console.WriteLine();

            Console.WriteLine("\nIntersection of Emps in Dept 20 and All Clerks: ");
            var result3 = emps20.Intersect(clerks);
            foreach (var item in result3)
                Console.WriteLine(item);
            Console.WriteLine();

            Console.WriteLine("\nEmps in Dept 20 except All Clerks: ");
            var result4 = emps20.Except(clerks);
            foreach (var item in result4)
                Console.WriteLine(item);
            Console.WriteLine();
            #endregion

            #region Nested Query
            Console.WriteLine("\nNested Query: DeptName with Emp Names: ");
            var result5 = from d in depts
                          select new
                          {
                              DeptName = d.Dname,
                              EmpNames = (from e in emps where e.DeptId == d.DeptId select e.Ename)
                          };
            foreach(var item in result5)
                Console.WriteLine(item.DeptName + " -> " + string.Join(", ", item.EmpNames));

            #endregion

            #region Query Deferred Execution & Side Effects
            int count = 0;
            var result = emps.Where(e => e.DeptId == 10).Select(e =>
            {
                count++; // side effect
                return e.Ename;
            });
            Console.WriteLine("\nEmp Count : " + count);

            //LINQ Execution is triggered when enumerated using foreach or
            //predefined methods e.g. ToList(), ToArray(), First(), Single(), Any(), All(), Count(), ...
            foreach (var item in result)
                Console.WriteLine(item);
            Console.WriteLine("\nEmp Count : " + count);

            var test = result.ToList();
            Console.WriteLine("\nEmp Count : " + count);

            #endregion

            #region Avoid Side Effects
            //To avoid LINQ side effects, we can use convert to List & then perform operations
            var resultList = result.ToList();
            Console.WriteLine("\nList Emp Count : " + resultList.Count);
            // ...
            #endregion
        }

        public static void Main(string[] args)
        {
            // create user-defined stack object & push items
            Stack s = new Stack(6);
            s.Push(11);
            s.Push(22);
            s.Push(33);
            s.Push(44);
            s.Push(55);
            s.Push(66);
            // display items - stack is IEnumerable
            foreach(int item in s)
                Console.WriteLine("Stack Item: " + item);

            // display even numbers from stack using LINQ query syntax
            Console.WriteLine("\nEven numbers from stack: ");
            var evenNums = from n in s
                           where n % 2 == 0
                           select n;
            foreach(int item in evenNums)
                Console.WriteLine(item);
        }
    }

    public class Emp
    {
        public int EmpId { get; set; }
        public string Ename { get; set; }
        public string Job { get; set; }
        public int? ManagerId { get; set; }
        public DateTime Hire { get; set; }
        public double Salary { get; set; }
        public double? Commission { get; set; }
        public int DeptId { get; set; }

        public override string ToString()
        {
            return $"Emp -> Id: {EmpId}, Name: {Ename}, Job: {Job}, Manager: {ManagerId}, Hire: {Hire.ToShortDateString()}, Salary: {Salary}, Comm: {Commission}, Dept: {DeptId}";
        }
    }

    public class Dept
    {
        public int DeptId { get; set; }
        public string Dname { get; set; }
        public string Location { get; set; }
        public override string ToString()
        {
            return $"Dept -> Id: {DeptId}, Name: {Dname}, Location: {Location}";
        }
    }

    public class Stack : IEnumerable<int>
    {
        private int _top = -1;
        private int[] _arr = null;
        public Stack(int size) => _arr = new int[size];
        public void Push(int num) => _arr[++_top] = num;
        public int Pop() => _arr[_top--];
        public int Peek() => _arr[_top];
        public bool IsEmpty() => _top == -1;
        public IEnumerator<int> GetEnumerator()
        {
            for(int i=0; i<=_top; i++)
                yield return _arr[i];
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
