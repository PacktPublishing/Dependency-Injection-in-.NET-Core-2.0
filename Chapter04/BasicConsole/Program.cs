using System;
using Microsoft.AspNetCore.Hosting;

namespace BasicWebSite
{
    class Program
    {
        static void Main(string[] args)
        {
            var basicHost = new WebHostBuilder()
				.UseKestrel()
				.UseStartup<Startup>()
				.Build();
				
			basicHost.Run();
        }
    }
}
