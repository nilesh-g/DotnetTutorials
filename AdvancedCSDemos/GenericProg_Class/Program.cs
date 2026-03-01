namespace GenericProg_Class
{
    class Box<T>
    {
        private T obj;
        public Box()
        {
            obj = default(T);
                // default value of reference type T = null
                // default value of value type T = 0 (int), 0.0 (double), false (bool)
        }
        public void Set(T obj)
        {
            this.obj = obj;
        }
        public T Get()
        {
            return obj;
        }
        public void Display()
        {
            Console.WriteLine("Boxed Obj: " + obj);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Box<string> b1 = new Box<string>();
            b1.Set("Hello");
            b1.Display();
            string str = b1.Get();
            Console.WriteLine("b1 --> " + str);

            Box<int> b2 = new Box<int>();
            b2.Set(100);
            b2.Display();
            int i = b2.Get();
            Console.WriteLine("b2 --> " + i);

            //int n = b1.Get(); // compiler error
        }
    }
}
