namespace RedisAdmin.Application.Common.Interfaces
{
    /// <summary>
    /// Used for Redis type: `String`
    /// 
    ///     Strings are the most basic kind of Redis value. Redis Strings are binary safe, this means that a Redis string can contain any kind of data, for instance a JPEG image or a serialized Ruby object.
    ///     
    /// </summary>
    public interface IRedisRepositoryString
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
