using RedisRepository.enums;
using System.Collections.Generic;

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
        ///     Delete by key; https://redis.io/commands/del
        /// 
        /// </summary>
        /// <param name="key"></param>
        void Delete(string key);

        /// <summary>
        /// StackExchange.Redis.KeyExists
        /// 
        ///     Checks if the given key exists; https://redis.io/commands/exists
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
        ///     terminology. https://redis.io/commands/expire
        ///     
        /// </summary>
        /// <param name="key"></param>
        /// <param name="cacheMinuteTimeout"></param>
        /// <returns></returns>
        bool SetTimeToLive(string key, double cacheMinuteTimeout);

        /// <summary>
        /// INFO
        /// 
        ///     The INFO command returns information and statistics about the server in a format that is simple to parse by computers and easy to read by humans.
        ///     https://redis.io/commands/INFO
        /// 
        /// </summary>
        /// <param name="infoParameter">Option to filter by a specific section of information; example: MEMORY</param>
        /// <returns></returns>
        string Info(InfoEnum.Info infoParameter = InfoEnum.Info.All);

        /// <summary>
        /// SCAN
        /// 
        ///     Returns value is an array of two values: the first value is the new cursor to use in the next call, the second value is an array of elements (these are the redis keys)
        ///     https://redis.io/commands/scan
        ///     
        /// COUNT remarks
        /// 
        ///     While SCAN does not provide guarantees about the number of elements returned at every iteration, it is possible to empirically adjust the behavior of SCAN
        ///     using the COUNT option. Basically with COUNT the user specified the amount of work that should be done at every call in order to retrieve elements from the
        ///     collection. This is just a hint for the implementation, however generally speaking this is what you could expect most of the times from the implementation.
        /// 
        /// </summary>
        /// <param name="keyMatch">Wildcard to match partial key, example "AP:201401:*"</param>
        /// <param name="maxResultsSoftLimit">The max amount of records to return. Helps with performance should users try search on a single wildcard like `*`. It will not ALWAYS limit to this amount, the exact count will be determined on the COUNT which is 1000</param>
        /// <returns></returns>
        IList<string> SelectListOfKeysLike(string keyMatch, int maxResultsSoftLimit = 1000);
    }
}
