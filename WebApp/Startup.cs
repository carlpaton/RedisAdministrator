using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedisRepository.Interfaces;

namespace WebApp
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //DI ~ Appsettings
            var appSettings = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json", true, true)
             .Build();

            var redisConnection = (Environment.GetEnvironmentVariable("REDIS_CONNECTION") ?? appSettings["AppSettings:RedisConnection"]);

            services.AddTransient<IRedisRepository>(sp => new RedisRepository.RedisRepository(redisConnection));
            services.AddTransient<IRedisRepositoryString>(sp => new RedisRepository.RedisRepositoryString(redisConnection));
            //services.AddTransient<IRedisRepositorySet>(sp => new RedisRepository.RedisRepositorySet(redisConnection));
            services.AddTransient<IRedisRepositorySortedSet>(sp => new RedisRepository.RedisRepositorySortedSet(redisConnection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
