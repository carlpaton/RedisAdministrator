using RedisRepository.Interfaces;
using StackExchange.Redis;
using System;

namespace RedisRepository
{
    public class RedisRepository : IRedisRepository
    {
        private readonly IDatabase _db;
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public RedisRepository(string connection)
        {
            _connectionMultiplexer = ConnectionMultiplexer.Connect(connection);
            _db = _connectionMultiplexer.GetDatabase();
        }

        public void Clear()
        {
            var endpoints = _connectionMultiplexer.GetEndPoints(true);
            foreach (var endpoint in endpoints)
            {
                var server = _connectionMultiplexer.GetServer(endpoint);
                server.FlushAllDatabases();
            }
        }

        public void Delete(string key)
        {
            _db.KeyDelete(key);
        }

        public bool Exists(string key)
        {
            return _db.KeyExists(key);
        }

        public string Info()
        {
            var redisResult = _db.Execute("INFO");
            return (string)redisResult;
        }

        public bool SetTimeToLive(string key, double cacheMinuteTimeout)
        {
            var timeSpan = TimeSpan.FromMinutes(cacheMinuteTimeout);
            return _db.KeyExpire(key, timeSpan);
        }
    }
}
