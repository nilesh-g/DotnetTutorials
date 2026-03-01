using System.Collections.Generic;

namespace Collections_Generics
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(33);
            list.Add(22);
            list.Add(11);
            list.Add(55);
            list.Add(44);
            list.Insert(2, 66);
            Console.WriteLine("Num of Elements: " + list.Count);
            foreach (int item in list)
                Console.WriteLine("List Item: " + item);
            list.Remove(11);
            list.RemoveAt(4);
            list[0] = 10;
            for(int i=0; i<list.Count; i++)
                Console.WriteLine($"List Item {i}: " + list[i]);
        }
        static void Main2(string[] args)
        {
            List<int> list = new List<int>() { 33, 22, 11, 55, 44 };
            foreach (int item in list)
            {
                Console.WriteLine("List Item: " + item);
                if (item == 55)
                    list.Remove(55); // InvalidOperationException: Collection was modified
            }
            //list.Remove(55); // Can delete element properly after iterating
        }
        static void Main3(string[] args)
        {
            List<int> list = new List<int>(); // dynamic array
            Console.WriteLine("Item Count: " + list.Count);         // 0
            Console.WriteLine("Item Capacity: " + list.Capacity);   // 0
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            Console.WriteLine("Item Count: " + list.Count);         // 4
            Console.WriteLine("Item Capacity: " + list.Capacity);   // 4
            list.Add(5);
            Console.WriteLine("Item Count: " + list.Count);         // 5
            Console.WriteLine("Item Capacity: " + list.Capacity);   // 8
            list.TrimExcess();
            Console.WriteLine("Item Count: " + list.Count);         // 5
            Console.WriteLine("Item Capacity: " + list.Capacity);   // 5
        }
        static void Main4(string[] args)
        {
            List<Person> list = new List<Person>()
            {
                new Person() { Name="Superman", Age=876, Address="Crypton"},
                new Person() { Name="Batman", Age=45, Address="Gotham"},
                new Person() { Name="Bond", Age=67, Address="London"}
            };
            foreach(Person p in list)
                Console.WriteLine("List Person -> " + p);

            string name = "Batman";
            Person key = new Person() { Name = name };
            if(list.Contains(key))
                Console.WriteLine("Person Found");
            else
                Console.WriteLine("Person Not Found");

            list.Sort();
            foreach (Person p in list)
                Console.WriteLine("List Person -> " + p);
        }
        static void Main5(string[] args)
        {
            LinkedList<string> list = new();
            list.AddLast("India");
            list.AddLast("UK");
            list.AddLast("Australia");
            list.AddFirst("Nepal");
            foreach (string item in list)
                Console.WriteLine("List Item: " + item);
        }
        static void Main6(string[] args)
        {
            Stack<int> s = new();
            s.Push(11);
            s.Push(22);
            s.Push(33);
            s.Push(44);
            Console.WriteLine("Stack Item Count: " + s.Count);
            while (s.Count > 0)
            {
                int ele = s.Pop();
                Console.WriteLine("Popped Item: " + ele);
            }
        }
        static void Main7(string[] args)
        {
            Queue<int> q = new();
            q.Enqueue(11);
            q.Enqueue(22);
            q.Enqueue(33);
            q.Enqueue(44);
            Console.WriteLine("Queue Item Count: " + q.Count);
            while (q.Count > 0)
            {
                int ele = q.Dequeue();
                Console.WriteLine("Dequeued Item: " + ele);
            }
        }
        static void Main8(string[] args)
        {
            HashSet<int> set = new();
            set.Add(11);
            set.Add(55);
            set.Add(33);
            set.Add(22);
            set.Add(44);
            set.Remove(55);
            set.Add(33); // return false -- Element not added again
            Console.WriteLine("Set Item Count: " + set.Count);
            foreach (int item in set)
                Console.WriteLine("Set Item: " + item);
        }
        static void Main9(string[] args)
        {
            HashSet<int> set1 = new HashSet<int>() { 1, 2, 3, 4, 5 };
            HashSet<int> set2 = new HashSet<int>() { 4, 5, 6, 7 };
            IEnumerable<int> intersection = set1.Intersect(set2);
            foreach(int item in intersection)
                Console.WriteLine("Intersection : " + item);
            Console.WriteLine();
            IEnumerable<int> union = set1.Union(set2);
            foreach (int item in union)
                Console.WriteLine("Union : " + item);
            Console.WriteLine();
            IEnumerable<int> except = set1.Except(set2);
            foreach (int item in except)
                Console.WriteLine("Except : " + item);
        }
        static void Main(string[] args)
        {
            Dictionary<int,string> dict = new Dictionary<int, string>();
            dict.Add(3, "Elon");
            dict.Add(1, "Steve");
            dict.Add(4, "Sundar");
            dict.Add(2, "Bill");
            foreach (KeyValuePair<int, string> item in dict)
                Console.WriteLine($"Key={item.Key}, Value={item.Value}");
            int id = 8;
            if (dict.ContainsKey(id))
            {
                string name = dict[id];
                Console.WriteLine("Found Name = " + name);
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }
    }
    class Person : IEquatable<Person>, IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        // ...
        public bool Equals(Person other)
        {
            return this.Name == other.Name;
        }
        public int CompareTo(Person other)
        {
            return this.Name.CompareTo(other.Name);
        }
        public override string ToString()
        {
            return $"Name={Name}, Age={Age}, Address={Address}";
        }
    }
}
