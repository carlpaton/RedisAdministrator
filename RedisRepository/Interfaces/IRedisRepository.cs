namespace RedisRepository.Interfaces
{
    /// <summary>
    /// Should work with all Redis types.
    /// </summary>
    public interface IRedisRepository
    {
        /// <summary>
        /// StackExchange.Redis.FlushAllDatabases
        /// 
        ///     WARNING!! This will flush all keys on ALL endpoints.
        ///     
        /// </summary>
        void Clear();

        /// <summary>
        /// StackExchange.Redis.KeyDelete
        /// 
        ///     Delete by key.
        /// 
        /// </summary>
        /// <param name="key"></param>
        void Delete(string key);

        /// <summary>
        /// StackExchange.Redis.KeyExists
        /// 
        ///     Checks if the given key exists.
        ///     
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool Exists(string key);

        /// <summary>
        /// StackExchange.Redis.KeyExpire
        /// 
        ///     Set a timeout on key. After the timeout has expired, the key will automatically
        ///     be deleted. A key with an associated timeout is said to be volatile in Redis
        ///     terminology.
        ///     
        /// </summary>
        /// <param name="key"></param>
        /// <param name="cacheMinuteTimeout"></param>
        /// <returns></returns>
        bool SetTimeToLive(string key, double cacheMinuteTimeout);

        /// <summary>
        /// INFO
        /// </summary>
        /// <returns></returns>
        string Info();
    }
}
