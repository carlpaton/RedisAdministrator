using System;
using System.Collections.Generic;
using RedisRepository.Interfaces;
using StackExchange.Redis;

namespace RedisRepository
{
    public class RedisRepositorySortedSet : IRedisRepositorySortedSet
    {
        private readonly IDatabase _db;

        public RedisRepositorySortedSet(string connection)
        {
            _db = ConnectionMultiplexer.Connect(connection).GetDatabase();
        }

        public bool Insert(string key, string value)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
            var span = (DateTime.Now.ToLocalTime() - epoch);
            var score = span.TotalSeconds;

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
    }
}
