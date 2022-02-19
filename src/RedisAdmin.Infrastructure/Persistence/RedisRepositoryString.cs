using RedisAdmin.Application.Common.Interfaces;
using StackExchange.Redis;

namespace RedisAdmin.Infrastructure.Persistence
{
    ///<inheritdoc/>
    public class RedisRepositoryString : IRedisRepositoryString
    {
        private readonly IDatabase _db;

        public RedisRepositoryString(string connection)
        {
            _db = ConnectionMultiplexer.Connect(connection).GetDatabase();
        }

        ///<inheritdoc/>
        public void Insert(string key, string value, double cacheMinuteTimeout = 0)
        {
            TimeSpan? timeSpan = null;

            if (cacheMinuteTimeout > 0)
                timeSpan = TimeSpan.FromMinutes(cacheMinuteTimeout);

            _db.StringSet(key, value, timeSpan);
        }

        ///<inheritdoc/>
        public string Select(string key)
        {
            return _db.StringGet(key);
        }
    }
}
