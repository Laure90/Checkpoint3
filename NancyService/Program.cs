using System;
using Nancy;
using Nancy.Hosting.Self;

namespace NancyService
{
    class Program
    {
        static void Main(string[] args)
        {
            HostConfiguration hostConfiguration = new HostConfiguration()
            {
                UrlReservations = new UrlReservations() { CreateAutomatically = true },
            };

            using (var host = new NancyHost(hostConfiguration, new Uri("http://localhost:1234")))
            {
                host.Start();
                Console.WriteLine("Running on http://localhost:1234");
                Console.ReadLine();
                host.Stop();
            }
        }
    }
}
