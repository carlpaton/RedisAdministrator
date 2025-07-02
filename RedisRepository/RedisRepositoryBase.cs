using Microsoft.Extensions.Options;
using RedisRepository.enums;
using RedisRepository.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RedisRepository
{
    public class RedisRepositoryBase : IRedisRepositoryBase
    {
        private readonly IDatabase _db;
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public RedisRepositoryBase(IOptions<DatabaseOptions> options)
        {
            _connectionMultiplexer = ConnectionMultiplexer.Connect(options.Value.ConnectionString);
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

        public RedisType GetType(string key)
        {
            return _db.KeyType(key);
        }

        public string Info(InfoEnum.Info infoParameter = InfoEnum.Info.All)
        {
            if (infoParameter.Equals(InfoEnum.Info.All))
                    return (string)_db.Execute("INFO");

           return (string)_db.Execute("INFO", new object[] { infoParameter.ToString() });
        }

        public IList<string> SelectListKeys(string keyMatch)
        {
            var list = new List<string>();

            var endpoints = _connectionMultiplexer.GetEndPoints(true);
            foreach (var endpoint in endpoints)
            {
                var server = _connectionMultiplexer.GetServer(endpoint);
                foreach (var key in server.Keys(pattern: keyMatch))
                {
                    list.Add(key);
                }
            }

            return list;
        }

        public IList<string> SelectListScan(string keyMatch, int maxResultsSoftLimit = 1000)
        {
            var list = new List<string>();
            var count = 1000;

            // Should the user limit the `maxResultsSoftLimit` it cannot be less than the `COUNT` value
            // See `IRedisRepository.SelectListScan` for remarks on the `COUNT` parameter
            if (count > maxResultsSoftLimit)
                count = maxResultsSoftLimit;

            int nextCursor = 0;
            do
            {
                var redisResult = _db.Execute("SCAN", new object[] { nextCursor.ToString(), "MATCH", keyMatch, "COUNT", count });
                var innerResult = (RedisResult[])redisResult;
                nextCursor = int.Parse((string)innerResult[0]);
                var resultLines = ((string[])innerResult[1]).ToList();
                list.AddRange(resultLines);

                if (list.Count >= maxResultsSoftLimit)
                    break;
            }
            while (nextCursor != 0);

            return list;
        }

        public bool SetTimeToLive(string key, double cacheMinuteTimeout)
        {
            var timeSpan = TimeSpan.FromMinutes(cacheMinuteTimeout);
            return _db.KeyExpire(key, timeSpan);
        }
    }
}
