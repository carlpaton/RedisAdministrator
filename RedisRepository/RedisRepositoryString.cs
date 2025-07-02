using RedisRepository.Interfaces;
using StackExchange.Redis;
using System;
using Microsoft.Extensions.Options;

namespace RedisRepository
{
    public class RedisRepositoryString : IRedisRepositoryString
    {
        private readonly IDatabase _db;

        public RedisRepositoryString(IOptions<DatabaseOptions> options)
        {
            _db = ConnectionMultiplexer
                .Connect(options.Value.ConnectionString)
                .GetDatabase();
        }

        public void Insert(string key, string value, double cacheMinuteTimeout = 0)
        {
            TimeSpan? timeSpan = null;

            if (cacheMinuteTimeout > 0)
                timeSpan = TimeSpan.FromMinutes(cacheMinuteTimeout);

            _db.StringSet(key, value, timeSpan);
        }

        public string Select(string key)
        {
            return _db.StringGet(key);
        }
    }
}
