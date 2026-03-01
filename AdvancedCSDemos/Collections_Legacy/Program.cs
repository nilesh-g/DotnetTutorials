using System.Collections;

namespace Collections_Legacy
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            ArrayList list = new ArrayList();
            list.Add(4);
            list.Add(3.14);
            list.Add("Hello");
            list.Add(true);
            list.Insert(2, "Nilesh");
            Console.WriteLine("Count of Elems: " + list.Count);
            foreach(object obj in list)
                Console.WriteLine("List Item: " + obj);
            list.RemoveAt(3);
            list.Remove(true);
            list[0] = 108;
            for(int i = 0; i < list.Count; i++)
                Console.WriteLine($"List Item {i}: " + list[i]);
            list.Clear();
            Console.WriteLine("Count of Elems: " + list.Count);
        }
        static void Main(string[] args)
        {
            Hashtable map = new Hashtable();
            map.Add(3, "Elon");
            map.Add(2, "Bill");
            map.Add(4, "Sundar");
            map.Add(1, "Steve");
            //map.Add(1, "Tim"); // ArgumentException: Item has already been added
            map[3] = "Parag"; // overwrite the previous value
            map[5] = "Mark"; // add a new key-value pair
            int id = 3;
            string name = (string)map[id];
            Console.WriteLine("Found Name: " + name);
            Console.WriteLine("Count of Elems: " + map.Count);
            foreach(DictionaryEntry entry in map)
                Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
        }
    }
}
