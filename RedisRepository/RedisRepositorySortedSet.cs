using System;
using System.Collections.Generic;
using System.Linq;
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

        public IList<string> SelectListOfKeysLike(string keyMatch)
        {
            var list = new List<string>();

            int nextCursor = 0;
            do
            {
                var redisResult = _db.Execute("SCAN", new object[] { nextCursor.ToString(), "MATCH", keyMatch, "COUNT", "1000" });
                var innerResult = (RedisResult[])redisResult;
                nextCursor = int.Parse((string)innerResult[0]);
                var resultLines = ((string[])innerResult[1]).ToList();
                list.AddRange(resultLines);
            }
            while (nextCursor != 0);

            return list;


            // All documentation I see online and in SE.Readis warns about the use of `Keys`
            // This did however seem to return the `VALUE` of the KVP so may be useful on smaller db's?
            //var endpoints = _connectionMultiplexer.GetEndPoints(true);
            //foreach (var endpoint in endpoints)
            //{
            //    var server = _connectionMultiplexer.GetServer(endpoint);
            //    foreach(var key in server.Keys(pattern: keyMatch)) 
            //    {
                  
            //    }
            //}
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
