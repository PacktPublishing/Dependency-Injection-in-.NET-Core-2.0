using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ASPNETCoreDemo1
{
    public class Startup
    {
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        // This method gets called by the runtime. Use this method to add services 
        // to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
        }

        // This method gets called by the runtime. Use this method to configure 
        // the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
                              ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                if (env.IsEnvironment("Packt"))
                {
                    await context.Response.WriteAsync("We're in PACKT development mode!");
                }
                else await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
