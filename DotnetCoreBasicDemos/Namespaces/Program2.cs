using Gen = System.Collections.Generic;

namespace DataStructure
{
    namespace GraphSpace
    {
        class Graph
        {
            // ...
        }
    }
}

namespace Namespaces
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Program3 program = new Program3();
            program.TestMethod();
            Gen.List<int> nums = new Gen.List<int>();
            nums.Add(1);
            nums.Add(2);
            nums.Add(3);
            Console.WriteLine("nums: " + nums);
        }
    }
}
