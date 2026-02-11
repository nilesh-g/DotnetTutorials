namespace ExceptionHandling
{
    /*
    class Time
    {
        private int _hours;
        private int _minutes;
        private int _seconds;
        public int Hours
        {
            get
            {
                return _hours;
            }
            set
            {
                if (value < 0 || value > 23)
                    throw new ArgumentException("Hours must be between 0 and 23");
                _hours = value;
            }
        }
        public int Minutes
        {
            get
            {
                return _minutes;
            }
            set
            {
                if (value < 0 || value > 59)
                    throw new ArgumentException("Minutes must be between 0 and 59");
                _minutes = value;
            }
        }
        public int Seconds
        {
            get
            {
                return _seconds;
            }
            set
            {
                if (value < 0 || value > 59)
                    throw new ArgumentException("Seconds must be between 0 and 59");
                _seconds = value;
            }
        }
        override public string ToString()
        {
            return $"{Hours}:{Minutes}:{Seconds}";
        }
        // ... other methods
    }
    */

    class InvalidTimeException : ApplicationException
    {
        public string Field { get; set; }
        public string Value { get; set; }
        public InvalidTimeException(string field, string value)
            :base($"Invalid value {value} for field {field}")
        {
            Field = field;
            Value = value;
        }
        // ...
    }

    class Time
    {
        private int _hours;
        private int _minutes;
        private int _seconds;
        public int Hours
        {
            get
            {
                return _hours;
            }
            set
            {
                if (value < 0 || value > 23)
                    throw new InvalidTimeException("Hours", value.ToString());
                _hours = value;
            }
        }
        public int Minutes
        {
            get
            {
                return _minutes;
            }
            set
            {
                if (value < 0 || value > 59)
                    throw new InvalidTimeException("Minutes", value.ToString());
                _minutes = value;
            }
        }
        public int Seconds
        {
            get
            {
                return _seconds;
            }
            set
            {
                if (value < 0 || value > 59)
                    throw new InvalidTimeException("Seconds", value.ToString());
                _seconds = value;
            }
        }
        override public string ToString()
        {
            return $"{Hours}:{Minutes}:{Seconds}";
        }
        // ... other methods
    }
    internal class Program
    {
        static void Main1(string[] args)
        {
            try
            {
                Console.WriteLine("Enter two numbers: ");
                int num = Convert.ToInt32(Console.ReadLine());
                int den = Convert.ToInt32(Console.ReadLine());
                int result = num / den;
                Console.WriteLine("Result: " + result);
            }
            catch
            {
                Console.WriteLine("Something went wrong");
            }
        }
        static void Main2(string[] args)
        {
            try
            {
                Console.WriteLine("Enter two numbers: ");
                int num = Convert.ToInt32(Console.ReadLine());
                int den = Convert.ToInt32(Console.ReadLine());
                int result = num / den;
                Console.WriteLine("Result: " + result);
            }
            catch(Exception e)
            {
                Console.WriteLine("ERROR: " + e.ToString());
            }
        }
        static void Main3(string[] args)
        {
            try
            {
                Console.WriteLine("Enter two numbers: ");
                int num = Convert.ToInt32(Console.ReadLine());
                int den = Convert.ToInt32(Console.ReadLine());
                int result = num / den;
                Console.WriteLine("Result: " + result);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Divide By Zero Error: " + e);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Format Error: " + e);
            }
            catch (Exception e)
            {
                Console.WriteLine("General Error: " + e.ToString());
            }
        }
        static void Main4(string[] args)
        {
            string filepath = @"D:\YouTube\DotNet\DotNetCoreOopDemos\ExceptionHandling\test.txt";
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(filepath);
                string text = sr.ReadToEnd();
                Console.WriteLine(text);
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex);
            }
            finally
            {
                Console.WriteLine("Finally Block Executed");
                if (sr != null)
                    sr.Close();
            }
        }
        static void Main5(string[] args)
        {
            string filepath = @"D:\YouTube\DotNet\DotNetCoreOopDemos\ExceptionHandling\test.txt";
            try
            {
                using (StreamReader sr = new StreamReader(filepath))
                {
                    string text = sr.ReadToEnd();
                    Console.WriteLine(text);
                } // sr.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex);
            }
        }
        static void Main6(string[] args)
        {
            try
            {
                Time t = new Time();
                t.Hours = -4;
                t.Minutes = 59;
                t.Seconds = 59;
                Console.WriteLine(t.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex);
            }
        }
        static void Main7(string[] args)
        {
            try
            {
                Time t = new Time();
                t.Hours = 4;
                t.Minutes = 69;
                t.Seconds = 59;
                Console.WriteLine(t.ToString());
            }
            catch (InvalidTimeException ex) when (ex.Field == "Hours")
            {
                Console.WriteLine("Time Hours Error: " + ex);
            }
            catch (InvalidTimeException ex) when (ex.Field == "Minutes")
            {
                Console.WriteLine("Time Minutes Error: " + ex);
            }
            catch (InvalidTimeException ex) when (ex.Field == "Seconds")
            {
                Console.WriteLine("Time Seconds Error: " + ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter two numbers: ");
            int num, den;
            if (int.TryParse(Console.ReadLine(), out num) == false)
            {
                Console.WriteLine("Invalid numerator");
                return;
            }
            if (int.TryParse(Console.ReadLine(), out den) == false)
            {
                Console.WriteLine("Invalid denominator");
                return;
            }
            if (den != 0)
            {
                int result = num / den;
                Console.WriteLine("Result: " + result);
            }
            else
                Console.WriteLine("Denominator cannot be zero");
        }
    }
}
