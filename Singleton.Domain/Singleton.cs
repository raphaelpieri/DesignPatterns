using System;
using System.Collections.Generic;

namespace Singleton.Domain
{
    internal sealed class LoadBalancer
    {
        private static readonly LoadBalancer Instance = new LoadBalancer();

        private readonly IList<Server> servers;
        private readonly Random random = new Random();

        public LoadBalancer()
        {
            servers = new List<Server>()
            {
                new Server{Name = "Server 1", IP = "120.14.220.18"},
                new Server{Name = "Server 2", IP = "120.14.220.19"},
                new Server{Name = "Server 3", IP = "120.14.220.20"},
                new Server{Name = "Server 4", IP = "120.14.220.21"},
                new Server{Name = "Server 5", IP = "120.14.220.22"},
            };
        }

        public static LoadBalancer GetLoadBalancer() => Instance;

        public Server NextServer {
            get
            {
                var r = random.Next(servers.Count);
                return servers[r];
            }
        }

    }

    internal class Server
    {
        public string Name { get; set; }
        public string IP { get; set; }
    }

    public class Singleton
    {
        public static void Execution()
        {
            var b1 = LoadBalancer.GetLoadBalancer();
            var b2 = LoadBalancer.GetLoadBalancer();
            var b3 = LoadBalancer.GetLoadBalancer();
            var b4 = LoadBalancer.GetLoadBalancer();

            if(b1 == b2 && b2 == b3 && b3 == b4)
            {
                Console.WriteLine("Mesma instancia\n");
            }

            var balancer = LoadBalancer.GetLoadBalancer();
            for (var i = 0; i < 15; i++)
            {
                var serverName = balancer.NextServer.Name;
                Console.WriteLine($"Disparando request para: {serverName}");
            }

        }
    }
}
