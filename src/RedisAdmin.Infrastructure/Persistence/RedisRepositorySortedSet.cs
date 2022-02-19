using RedisAdmin.Application.Common.Interfaces;
using StackExchange.Redis;

namespace RedisAdmin.Infrastructure.Persistence
{
    ///<inheritdoc/>
    public class RedisRepositorySortedSet : IRedisRepositorySortedSet
    {
        private readonly IDatabase _db;

        public RedisRepositorySortedSet(string connection)
        {
            _db = ConnectionMultiplexer.Connect(connection).GetDatabase();
        }

        ///<inheritdoc/>
        public bool Insert(string key, string value, double score)
        {
            return _db.SortedSetAdd(key, value, score);
        }

        ///<inheritdoc/>
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

        ///<inheritdoc/>
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

        ///<inheritdoc/>
        public double? SelectScore(string key, string member)
        {
            return _db.SortedSetScore(key, member);
        }

        ///<inheritdoc/>
        public void SortedSetRemoveRangeByScore(string key, double start, double stop)
        {
            _db.SortedSetRemoveRangeByScore(key, start, stop);
        }

        ///<inheritdoc/>
        public bool SortedSetRemove(string key, string member)
        {
            return _db.SortedSetRemove(key, member);
        }
    }
}
