global using NewNamespace;
using DataStructure.TreeSpace;

namespace DataStructure
{
    namespace ListSpace
    {
        class Node
        {
            // ...
        }
        class List
        {
            // ...
        }
    }
    namespace TreeSpace
    {
        class Node
        {
            // ...
        }

        class Tree
        {
            // ...
        }
    }
}

namespace Namespaces
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            DataStructure.ListSpace.List list = new DataStructure.ListSpace.List();
            // ...
            Tree tree = new Tree();
            // ...
            DataStructure.GraphSpace.Graph graph = new DataStructure.GraphSpace.Graph();
            // ...
            Program3 program3 = new Program3();
            program3.TestMethod();
        }
    }
}
