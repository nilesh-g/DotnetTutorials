namespace Arrays
{
    internal class Program
    {
        // 1-D arrays
        static void Main1(string[] args)
        {
            int[] arr = { 10, 20, 30, 40 };
            Console.WriteLine("arr Length: " + arr.Length);
            Console.WriteLine("arr[0] : " + arr[0]); // 10
            Console.WriteLine("arr[1] : " + arr[1]); // 20
            Console.WriteLine("arr[2] : " + arr[2]); // 30
            Console.WriteLine("arr[3] : " + arr[3]); // 40
        //    Console.WriteLine("arr[4] : " + arr[4]); // Exception
            // for loop
            for(int i=0; i<arr.Length; i++)
                Console.WriteLine($"arr[{i}] = {arr[i]}");
            // foreach loop - repeated once for each element in the array
            foreach(int n in arr)
                Console.WriteLine($"Elem: {n}");
        }
        // 1-D array of reference type
        static void Main2(string[] args)
        {
            string[] arr = new string[4];
            arr[0] = "India";
            arr[1] = "Lanka";
            arr[2] = "Nepal";
            arr[3] = "Bhutan";
            foreach(string country in arr)
                Console.WriteLine(country);
        }
        static void Main3(string[] args)
        {
            object[] arr = new object[]
            {
                123,            // elem 0
                3.14,           // elem 1
                false,          // elem 2
                "Nilesh",       // elem 3
                DateTime.Now    // elem 4
            };
            foreach(object obj in arr)
                Console.WriteLine(obj);
        }
        static void Main4(string[] args)
        {
            int AddAll(params int[] arr)
            {
                int sum = 0;
                foreach (int num in arr)
                    sum = sum + num;
                return sum;
            }

            int res1 = AddAll(1, 2);
            Console.WriteLine($"res1 = {res1}"); // 3
            int res2 = AddAll(1, 2, 3, 4);
            Console.WriteLine($"res2 = {res2}"); // 10
            int res3 = AddAll(1, 2, 3, 4, 5, 6, 7, 8);
            Console.WriteLine($"res3 = {res3}"); // 36
        }

        static void Main5(string[] args)
        {
            int[,] mat = new int[3, 3]
            {
                {11, 22, 33},
                {44, 55, 66},
                {77, 88, 99}
            };
            Console.WriteLine("Rows: " + mat.GetLength(0)); // 3 Rows
            Console.WriteLine("Cols: " + mat.GetLength(1)); // 3 Cols
            //mat[i,j]
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                    Console.Write(mat[i,j] + "\t");
                Console.Write("\n");
            }
        }

        // Jagged array -- Array of arrays
        static void Main(string[] args)
        {
            int[][] mat = new int[3][];
            mat[0] = new int[] { 1, 2, 3, 4 };
            mat[1] = new int[] { 5, 6 };
            mat[2] = new int[] { 7, 8, 9 };
            // mat[i][j]
            for(int i=0; i<mat.Length; i++)
            {
                for (int j = 0; j < mat[i].Length; j++)
                    Console.Write(mat[i][j] + "\t");
                Console.Write("\n");
            }
        }
    }
}
