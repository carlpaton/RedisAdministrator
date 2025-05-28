using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RedisRepository.Interfaces;
using WebApp.Services;

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

            services.AddControllersWithViews();

            //DI ~ Appsettings
            var appSettings = new AppSettings();

            services.AddTransient<IRedisRepository>(x => new RedisRepository.RedisRepository(appSettings.Connection));
            services.AddTransient<IRedisRepositoryString>(x => new RedisRepository.RedisRepositoryString(appSettings.Connection));
            //services.AddTransient<IRedisRepositorySet>(x => new RedisRepository.RedisRepositorySet(appSettings.Connection));
            services.AddTransient<IRedisRepositorySortedSet>(x => new RedisRepository.RedisRepositorySortedSet(appSettings.Connection));
            services.AddTransient<IAppSettings>(x => appSettings);
            services.AddTransient<IScoreCalculator>(x => new ScoreCalculator());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
