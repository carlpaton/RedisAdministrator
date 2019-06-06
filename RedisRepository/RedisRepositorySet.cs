using RedisRepository.Interfaces;
using StackExchange.Redis;
using System;

namespace RedisRepository
{
    public class RedisRepositorySet : IRedisRepositorySet
    {
        private readonly IDatabase _db;

        public RedisRepositorySet(string connection)
        {
            _db = ConnectionMultiplexer.Connect(connection).GetDatabase();
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
