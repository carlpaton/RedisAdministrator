using Microsoft.Extensions.Configuration;
using System;

namespace WebApp.Services
{
    public interface IAppSettings
    {
        string Connection { get; set; }
    }

    public class AppSettings : IAppSettings
    {
        public string Connection { get; set; }

        public AppSettings()
        {
            var appSettings = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            Connection = (Environment.GetEnvironmentVariable("REDIS_CONNECTION") ?? appSettings["AppSettings:RedisConnection"]);
        }
    }
}
