namespace Delegates
{
    class MathUtil
    {
        public void Subtract(int a, int b)
        {
            int result = a - b;
            Console.WriteLine($"Subtract = {result}");
        }
    }
    delegate void MathOp(int a, int b);
    internal class Program
    {
        public static void Add(int a, int b)
        {
            int result = a + b;
            Console.WriteLine($"Add = {result}");
        }
        static void Main1(string[] args)
        {
            MathOp ptr;
            ptr = new MathOp(Program.Add);
            ptr(22, 7);

            MathUtil obj = new MathUtil();
            MathOp ptr2 = new MathOp(obj.Subtract);
            ptr2(22, 7);

            void Multiply(int a, int b)
            {
                int result = a * b;
                Console.WriteLine($"Multiply = {result}");
            }
            MathOp ptr3 = new MathOp(Multiply);
            ptr3(22, 7);

            void Divide(int a, int b)
            {
                int result = a / b;
                Console.WriteLine($"Divide = {result}");
            }
            MathOp ptr4 = Divide; // new MathOp(Divide);
            ptr4(22, 7);

            MathOp ptr5 = delegate (int a, int b)
            {
                int result = a % b;
                Console.WriteLine($"Modulus = {result}");
            };
            ptr5(22, 7);

            MathOp ptr6 = (a, b) =>
            {
                int result = int.Max(a, b);
                Console.WriteLine($"Max = {result}");
            };
            ptr6(22, 7);

            MathOp ptr7 = (a, b) => Console.WriteLine($"Min = {int.Min(a, b)}");
            ptr7(22, 7);

            Console.WriteLine("======================================");
            ptr += ptr2; // ptr = Delegate.Combine(ptr, ptr2);
            ptr += ptr3;
            ptr += ptr4;
            ptr += ptr5;
            ptr += ptr6;
            ptr += ptr7;
            ptr(22, 7);
            Console.WriteLine("======================================");
            ptr -= ptr2;
            ptr -= ptr4;
            ptr -= ptr6;
            ptr(22, 7);
        }
        static void Main(string[] args)
        {
            MathRetOp ptr = (a, b) => a + b;
            ptr += (a, b) => a - b;
            ptr += (a, b) => a * b;

            int res = ptr(22, 7);
            Console.WriteLine($"Result = {res}");

            foreach(MathRetOp op in ptr.GetInvocationList())
            {
                int result = op(10, 3);
                Console.WriteLine("Operation Result = " + result);
            }
        }
    }
    delegate int MathRetOp(int a, int b);
}
