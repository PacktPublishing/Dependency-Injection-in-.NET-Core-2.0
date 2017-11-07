using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FiltersAndMiddlewares.Filters;
using FiltersAndMiddlewares.Interfaces;
using FiltersAndMiddlewares.Services;
using Microsoft.AspNetCore.Http;

namespace FiltersAndMiddlewares
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ISomeService, SomeService>()
                    .AddTransient<SomeGlobalFilter>()
                    .AddTransient<SomeFilter>();

            services.AddMvc(mvc => mvc.Filters.AddService(typeof(SomeGlobalFilter)));
        }

        // Comment this when you want to try Middlewares. Uncomment the other Configure method written below.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        // For Middleware Demo, uncomment below Configure method and comment the above one.
        //public void Configure(IApplicationBuilder app)
        //{
        //    var response = string.Empty;

        //    app.Use(async (context, next) =>
        //    {
        //        response += "Inside Middleware 1\n";
        //        await next.Invoke();
        //    });

        //    app.Use(async (context, next) =>
        //    {
        //        response += "Inside Middleware 2\n";
        //        await next.Invoke();
        //    });

        //    app.Run(async context =>
        //    {
        //        response += "App run\n";
        //        await context.Response.WriteAsync(response);
        //    });
        //}
    }
}