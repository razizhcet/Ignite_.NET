using Apache.Ignite.Core;
using Apache.Ignite.Core.Compute;
using Apache.Ignite.Core.Deployment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignite.NET1
{
    class RemoteAssemblyLoading
    {
        static void Main(string[] args)
        {
            var cfg = new IgniteConfiguration
            {
                PeerAssemblyLoadingMode = PeerAssemblyLoadingMode.CurrentAppDomain
            };

            using (var ignite = Ignition.Start(cfg))
            {
                ignite.GetCompute().Broadcast(new HelloAction());
            }
        }

        class HelloAction : IComputeAction
        {
            public void Invoke()
            {
                Console.WriteLine("Hello, World!");
                Console.ReadKey();
            }
        }
    }
}
