using RedisRepository.Interfaces;
using StackExchange.Redis;
using System;

namespace RedisRepository
{
    public class RedisRepository : IRedisRepository
    {
        private readonly double _cacheTimeout = 9001;
        private readonly string _connection;
        private readonly IDatabase _db;
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public RedisRepository(string connection)
        {
            _connection = connection;
            _connectionMultiplexer = ConnectionMultiplexer.Connect(_connection);
            _db = _connectionMultiplexer.GetDatabase();
            _cacheTimeout = 1; // TODO, remove - this was for testing!
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

        public void Insert(string key, string value)
        {
            var timeSpan = TimeSpan.FromMinutes(_cacheTimeout);
            _db.StringSet(key, value, timeSpan);
        }

        public string Select(string key)
        {
            return _db.StringGet(key);
        }

        public bool Exists(string key)
        {
            return _db.KeyExists(key);
        }

        public bool Update(string key, string value)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
            var span = (DateTime.Now.ToLocalTime() - epoch);
            var score = span.TotalSeconds;

            return _db.SortedSetAdd(key, value, score);
        }

        public bool SetTTL(string key)
        {
            var timeSpan = TimeSpan.FromMinutes(_cacheTimeout);
            return _db.KeyExpire(key, timeSpan);
        }
    }
}
