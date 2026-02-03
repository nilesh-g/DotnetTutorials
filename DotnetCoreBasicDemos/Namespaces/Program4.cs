// when any namespace is not mentioned in C# file.
// all members are considered to be part of a default "global" namespace.

class MyClass
{

}

internal class Program4
{
    static void Main(string[] args)
    {
        global::MyClass obj = new global::MyClass();    
    }
}
