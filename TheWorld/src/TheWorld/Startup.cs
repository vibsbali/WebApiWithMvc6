using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using TheWorld.Model;
using TheWorld.Repository;
using TheWorld.Services;

namespace TheWorld
{
    public class Startup
    {

        //This is a pattern that allows you to get environment variables 
        public static IConfigurationRoot Configuration;

        public Startup(IApplicationEnvironment appEnv)
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(appEnv.ApplicationBasePath)
                            .AddJsonFile("config.json")
                            .AddEnvironmentVariables();

            Configuration = builder.Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<IMailService, DebugMailService>();
            services.AddTransient<WorldContextSeedData>();
            services.AddScoped<IRepository, WorldRespository>();


            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<WorldContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, WorldContextSeedData seeder)
        {
            app.UseMvc();

            app.UseMvc(config =>
            {
                config.MapRoute("Default", "{controller}/{action}/{id?}", new {controller = "App", action = "Index"});
            });
            
            seeder.EnsureSeedData();

            //This will look for default files type like index.html 
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"Hello World! {context.Request.Path}");
            });
        }

        // Entry point for the application.
        public static void Main(string[] args)
        {
            WebApplication.Run<Startup>(args);
        } 
    }
}
