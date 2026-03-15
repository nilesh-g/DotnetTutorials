
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AsyncAwait
{
    internal class Program
    {
        public static async Task AsyncTask1()
        {
            Console.WriteLine("Task 1 started ");
            await Task.Delay(1000);
            Console.WriteLine("Task 1 completed ");
        }
        public static void Main1(string[] args)
        {
            Console.WriteLine("Main thread started ");
            Task task = AsyncTask1();
            task.Wait();
            Console.WriteLine("Main thread completed ");
        }


        public static async Task<string> AsyncTask2()
        {
            Console.WriteLine("Task 2 started : " + Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(1000);
            Console.WriteLine("Task 2 completed " + Thread.CurrentThread.ManagedThreadId);
            return "Task 2 result";
        }
        public static void Main2(string[] args)
        {
            Console.WriteLine("Main thread started " + Thread.CurrentThread.ManagedThreadId);
            Task<string> task = AsyncTask2();
            Console.WriteLine("Task 2 result is " + task.Result);
            Console.WriteLine("Main thread completed " + Thread.CurrentThread.ManagedThreadId);
        }

        public static async Task Main3(string[] args)
        {
            Console.WriteLine("Main thread started " + Thread.CurrentThread.ManagedThreadId);
            string result = await AsyncTask2();
            Console.WriteLine("Task 2 result is " + result);
            Console.WriteLine("Main thread completed " + Thread.CurrentThread.ManagedThreadId);
        }

        public static async Task Main4(string[] args)
        {
            string path = @"D:\YouTube\DotNet\AdvancedCSDemos\AsyncAwait\Program.cs";
            string text = await File.ReadAllTextAsync(path);
            Console.WriteLine(text);
        }

        public static async Task Main5(string[] args)
        {
            string path = @"D:\YouTube\DotNet\AdvancedCSDemos\AsyncAwait\Program.cs";
            using (StreamReader reader = new StreamReader(path))
            {
                string text = await reader.ReadToEndAsync();
                Console.WriteLine(text);
            }
        }

        public static async Task Main6(string[] args)
        {
            string path = @"D:\YouTube\DotNet\AdvancedCSDemos\AsyncAwait\Program.cs";
            try
            {
                using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, useAsync: true))
                {
                    byte[] buffer = new byte[1024];
                    int count = await stream.ReadAsync(buffer, 0, buffer.Length);
                    string text = Encoding.UTF8.GetString(buffer, 0, count);
                    Console.WriteLine(text);
                }
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static async Task Main7(string[] args)
        {
            string url = "https://nilesh-g.github.io/learn-web/data/novels.json";
            HttpClient client = new HttpClient();
            //var response = await client.GetAsync(url);
            var data = await client.GetStringAsync(url);
            //Console.WriteLine(data);
            var novels = JsonSerializer.Deserialize<Novel[]>(data);
            foreach (var novel in novels)
                Console.WriteLine(novel);
        }

        public static async Task Main(string[] args)
        {
            string url = "https://nilesh-g.github.io/learn-web/data/novels.json";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var novels = await client.GetFromJsonAsync<Novel[]>(url);
                    foreach (var novel in novels)
                        Console.WriteLine(novel);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    class Novel
    {
        [JsonPropertyName("srno")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("author")]
        public string Author { get; set; }
        [JsonPropertyName("category")]
        public string Category { get; set; }
        [JsonPropertyName("price")]
        public int Price { get; set; }
        public override string ToString()
        {
            return $"Id: {Id}, Title: {Title}, Author: {Author}, Category: {Category}, Price: {Price}";
        }
    }
}
