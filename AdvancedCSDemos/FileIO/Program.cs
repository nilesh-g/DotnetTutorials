using System.Diagnostics.Tracing;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FileIO
{
    [Serializable]
    class Person
    {
        [JsonPropertyName("personname")]
        public string Name { get; set; }
        [JsonPropertyName("personage")]
        public int Age { get; set; }
        [JsonIgnore]
        public string Address { get; set; }
        //[NonSerialized]
        //public int id;
        // ...
        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Address: {Address}";
        }
    }
    internal class Program
    {
        public static void Main1(string[] args)
        {
            // input a path from the user (file or dir path)
            Console.Write("Enter a path: ");
            string path = Console.ReadLine();
            // if path is "/", print all drives
            if (path == "/")
            {
                string[] drives = Directory.GetLogicalDrives();
                foreach (string drive in drives)
                    Console.WriteLine("Drive: " + drive);
            }
            // if it is directory, list all files/subdirectories
            else if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path);
                foreach (string file in files)
                    Console.WriteLine("File: " + file);
                string[] directories = Directory.GetDirectories(path);
                foreach (string directory in directories)
                    Console.WriteLine("Dir : " + directory);
            }
            // if it is file, print its content
            else if (File.Exists(path))
            {
                //string content = File.ReadAllText(path);
                //Console.WriteLine(content);
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                    Console.WriteLine(line);
            }
            // if it is not a valid path, print error
            else
                Console.WriteLine("Invalid path");
        }
        public static void Main2(string[] args)
        {
            // write a person data to a text file
            Person p = new Person() { Name = "James Bond", Age = 32, Address = "London" };
            using (StreamWriter sw = new StreamWriter("person.txt"))
            {
                sw.WriteLine(p.Name);
                sw.WriteLine(p.Age);
                sw.WriteLine(p.Address);
                Console.WriteLine("File written");
            } // sw.Dispose();
        }
        public static void Main3(string[] args)
        {
            // read a person data from a text file
            Person p = new Person();
            using (StreamReader sr = new StreamReader("person.txt"))
            {
                p.Name = sr.ReadLine();
                p.Age = int.Parse(sr.ReadLine());
                p.Address = sr.ReadLine();
            } // sr.Dispose();
            Console.WriteLine(p);
        }
        public static void Main4(string[] args)
        {
            // write a person data to a binary file
            Person p = new Person() { Name = "James Bond", Age = 32, Address = "London" };
            using (BinaryWriter bw = new BinaryWriter(File.Create("person.bin")))
            {
                bw.Write(p.Name);
                bw.Write(p.Age);
                bw.Write(p.Address);
                Console.WriteLine("File written");
            } // bw.Dispose();
        }
        public static void Main5(string[] args)
        {
            // read a person data from a binary file
            Person p = new Person();
            using (BinaryReader br = new BinaryReader(File.OpenRead("person.bin")))
            {
                p.Name = br.ReadString();
                p.Age = br.ReadInt32();
                p.Address = br.ReadString();
            } // br.Dispose();
            Console.WriteLine(p);
        }
        public static void Main6(string[] args)
        {
            Person p = new Person() { Name = "James Bond", Age = 32, Address = "London" };
            // write data into file using BinaryFormatter.
            BinaryFormatter formatter = new BinaryFormatter();
            using(FileStream stream = new FileStream("person2.bin", FileMode.Create))
            {
                formatter.Serialize(stream, p);
                Console.WriteLine("File written");
            }
            // read data from file using BinaryFormatter.
            using (FileStream stream = new FileStream("person2.bin", FileMode.Open))
            {
                Person p2 = (Person)formatter.Deserialize(stream);
                Console.WriteLine(p2);
            }
        }
        public static void Main7(string[] args)
        {
            Person p = new Person() { Name = "James Bond", Age = 32, Address = "London" };
            // write data in file using JsonSerializer
            using(FileStream stream = new FileStream("person.json", FileMode.Create))
            {
                JsonSerializer.Serialize(stream, p);
                Console.WriteLine("File written");
            }
        }
        public static void Main(string[] args)
        {
            // read data from file using JsonSerializer
            using (FileStream stream = new FileStream("person.json", FileMode.Open))
            {
                Person p = JsonSerializer.Deserialize<Person>(stream);
                Console.WriteLine(p);
            }
        }
    }
}
