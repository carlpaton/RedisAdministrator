namespace RedisRepository.Interfaces
{
    public interface IRedisRepository
    {
        /// <summary>
        /// Flush all databases
        /// </summary>
        void Clear();
        void Delete(string key);
        void Insert(string key, string value);

        string Select(string key);

        bool Exists(string key);

        /// <summary>
        /// SortedSetAdd
        /// 
        /// https://redis.io/commands/zadd
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Update(string key, string value);

        /// <summary>
        /// KeyExpire
        /// 
        //     Set a timeout on key. After the timeout has expired, the key will automatically
        //     be deleted. A key with an associated timeout is said to be volatile in Redis
        //     terminology.
        //
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool SetTTL(string key);
    }
}
