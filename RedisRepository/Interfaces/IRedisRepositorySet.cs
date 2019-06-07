namespace RedisRepository.Interfaces
{
    /// <summary>
    /// Used for Redis type: `Set`
    /// 
    ///     Redis Sets are an unordered collection of strings. 
    ///     In Redis, you can add, remove, and test for the existence of members in O(1) time complexity.
    ///     
    /// </summary>
    public interface IRedisRepositorySet
    {
        /// <summary>
        /// StackExchange.Redis.StringSet
        /// 
        ///     Set key to hold the string value. If key already holds a value, it is overwritten,
        ///     regardless of its type; https://redis.io/commands/set
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="cacheMinuteTimeout">
        /// If not 0 it will set the records TTL to the given value in seconds.
        /// </param>
        void Insert(string key, string value, double cacheMinuteTimeout = 0);

        /// <summary>
        /// StackExchange.Redis.StringGet
        /// 
        ///     https://redis.io/commands/get
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string Select(string key);
    }
}
