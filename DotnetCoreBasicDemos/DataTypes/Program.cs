using System.Collections;

namespace DataTypes
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            unchecked
            {
                short num1 = 32767;
                num1++; // num1 = num1 + 1;
                Console.WriteLine("num1 : " + num1); // -32768
            }
            checked
            {
                short num2 = 32760;
                num2++; // num2 = num2 + 1; // throw Exception -- Overflow
                Console.WriteLine("num2 : " + num2); 
            }
        }
        static void Main2(string[] args)
        {
            int num1 = 123;
            Console.WriteLine("num1 = " + num1);
            object obj = num1;
            Console.WriteLine("obj = " + obj);
            int num2 = (int)obj;
            Console.WriteLine("num2 = " + num2);
        }
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();
            list.Add(123); // boxing
            list.Add(456); // boxing
            list.Add(789); // boxing
            foreach (object obj in list)
            {
                int num = (int)obj; // unboxing
                Console.WriteLine(num);
            }
        }
    }
}
