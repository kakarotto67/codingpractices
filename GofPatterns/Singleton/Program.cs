using System;
using System.Collections.Generic;

namespace Singleton
{
    // The Singleton
    sealed class LoadBalancer
    {
        // Instance is private, static and readonly
        private static readonly LoadBalancer instance = new LoadBalancer();

        // Type-safe generic list of servers
        private List<Server> servers;
        private Random random = new Random();

        // Private constructor
        private LoadBalancer()
        {
            // Load list of available servers
            servers = new List<Server>
            { 
                new Server{ Name = "ServerI", IP = "120.14.220.18" },
                new Server{ Name = "ServerII", IP = "120.14.220.19" }
            };
        }

        public static LoadBalancer GetLoadBalancer()
        {
            return instance;
        }

        // Simple, but effective load balancer
        public Server NextServer
        {
            get
            {
                var r = random.Next(servers.Count);
                return servers[r];
            }
        }
    }

    // Represents a server machine
    class Server
    {
        // Gets or sets server name
        public string Name { get; set; }

        // Gets or sets server IP address
        public string IP { get; set; }
    }

    // The Application
    public class Program
    {
        public static void Main()
        {
            var b1 = LoadBalancer.GetLoadBalancer();
            var b2 = LoadBalancer.GetLoadBalancer();

            // Confirm these are the same instance
            if (b1 == b2)
            {
                Console.WriteLine("Same instance\n");
            }

            // Next, load balance 15 requests for a server
            var balancer = LoadBalancer.GetLoadBalancer();
            for (int i = 0; i < 15; i++)
            {
                string serverName = balancer.NextServer.Name;
                Console.WriteLine("Dispatch request to: " + serverName);
            }
        }
    }
}
