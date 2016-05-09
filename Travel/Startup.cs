using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Travel.Models;

namespace Travel
{
    public class Startup
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddEntityFramework().AddSqlServer().AddDbContext<TravelContext>();
            //services.AddEntityFramework().AddSqlServer().AddDbContext<TravelContext>(
            //  options =>
            //options.UseSqlServer(Configuration["Data:DefaultConnection:TripsConnectionString"])
            //);
            services.AddTransient<TripsSeedData>();
            services.AddScoped<TripsRepository>();
        }

        public void Configure(IApplicationBuilder app, TripsSeedData seed)
        {
            //  app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc(config =>
            {
                config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" }
                 );
            });
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });

            seed.InsertSeedData();

            Mapper.Initialize(config =>
            {
                config.CreateMap<Trip, TripViewModel>().ReverseMap();
            }
            );
        }

        public static IConfigurationRoot Configuration;
        public Startup(IApplicationEnvironment appEnv)
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(appEnv.ApplicationBasePath)
              .AddJsonFile("config.json");

            Configuration = builder.Build();
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}