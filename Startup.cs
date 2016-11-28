using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TheWorld.Models;
using TheWorld.Services;

namespace TheWorld
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;
        private IConfigurationRoot _config;

        public Startup(IHostingEnvironment env)
        {
            _env = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();

            _config = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddTransient<IMailService, DebugMailService>();
            services.AddSingleton(_config);
           
            if (_env.IsDevelopment())
            {
                services.AddScoped<IMailService, DebugMailService>();
            }

            services.AddDbContext<WorldContext>();

            services.AddScoped<IWorldRepository, WorldRepository>();
            // services.AddScoped<IWorldRepository, MockedWorldRepository>();

            services.AddTransient<WorldContextSeedData>();

            services.AddLogging();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            WorldContextSeedData seeder, ILoggerFactory factory)
        {

            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                factory.AddDebug(LogLevel.Information);
            }
            else
            {
                factory.AddDebug(LogLevel.Error);
            }

            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute(); // Defines route ‘{controller=Home}/{action=Index}/{id?}’.

            seeder.EnsureSeedData().Wait();
        }
    }
}
