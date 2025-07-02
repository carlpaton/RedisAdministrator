using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using RedisRepository.Interfaces;
using StackExchange.Redis;

namespace RedisRepository
{
    public class RedisRepositorySortedSet : IRedisRepositorySortedSet
    {
        private readonly IDatabase _db;

        public RedisRepositorySortedSet(IOptions<DatabaseOptions> options)
        {
            _db = ConnectionMultiplexer
                .Connect(options.Value.ConnectionString)
                .GetDatabase();
        }

        public bool Insert(string key, string value, double score)
        {
            return _db.SortedSetAdd(key, value, score);
        }

        public IList<string> SelectList(string key)
        {
            var list = new List<string>();

            var results = _db.SortedSetRangeByValue(key);
            for (int i = 0; i < results.Length; i++)
            {
                list.Add(results[i].ToString());
            }

            return list;
        }

        public List<Tuple<double, string>> SelectListRecordWithScore(string key)
        {
            var response = new List<Tuple<double, string>>();
            var results = _db.SortedSetRangeByRankWithScores(key);
            
            for (var i = 0; i < results.Length; i++)
            {
                var score = results[i].Score;
                var element = results[i].Element.ToString();
                response.Add(Tuple.Create(score, element));
            }

            return response;
        }

        public double? SelectScore(string key, string member)
        {
            return _db.SortedSetScore(key, member);
        }

        public void SortedSetRemoveRangeByScore(string key, double start, double stop)
        {
            _db.SortedSetRemoveRangeByScore(key, start, stop);
        }

        public bool SortedSetRemove(string key, string member)
        {
            return _db.SortedSetRemove(key, member);
        }
    }
}