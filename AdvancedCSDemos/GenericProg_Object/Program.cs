using System.Collections;

namespace GenericProg_Object
{
    // Generic Program -- Not typesafe
    class Box
    {
        private object obj;
        public Box()
        {
            this.obj = null;
        }
        public void Set(object obj)
        {
            this.obj = obj;
        }
        public object Get()
        {
            return this.obj;
        }
        public void Display()
        {
            Console.WriteLine(this.obj);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Box b1 = new Box();
            b1.Set("String");
            string str = (string)b1.Get();
            Console.WriteLine("b1 --> " + str);
            b1.Display();

            Box b2 = new Box();
            b2.Set(100);    // boxing
            int i = (int)b2.Get(); // unboxing
            Console.WriteLine("b2 --> " + i);
            b2.Display();

            int num = (int)b1.Get();
            Console.WriteLine(num);
        }
    }
}
