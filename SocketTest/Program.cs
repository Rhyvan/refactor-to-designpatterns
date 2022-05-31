using System;
using System.Net.Http;

//https://www.aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/
namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting connections");
            for (int i = 0; i < 10; i++)
            {
                var client = ClientService.GetService();
                //using (var client = new HttpClient())
                //{
                var result = client.GetAsync("http://aspnetmonsters.com").Result;
                    Console.WriteLine(result.StatusCode);

                //}
            }

            Console.WriteLine("Connections done");
            Console.ReadKey();
        }
    }

    public static class ClientService
    {
        private static HttpClientHandler handler = new HttpClientHandler();

        public static HttpClient GetService()
        {
            return new HttpClient(handler);
        }
    }
}
