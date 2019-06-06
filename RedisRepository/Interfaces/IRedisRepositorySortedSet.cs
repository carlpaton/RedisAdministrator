using System;
using System.Collections.Generic;

namespace RedisRepository.Interfaces
{
    /// <summary>
    /// Used for Redis type: `Sorted Set`
    /// 
    ///     Redis Sorted Sets are similar to Redis Sets, non-repeating collections of Strings. 
    ///     The difference is, every member of a Sorted Set is associated with a score, that is used in order to take the sorted set ordered, from the smallest to the greatest score. 
    ///     While members are unique, the scores may be repeated.
    ///     
    /// </summary>
    public interface IRedisRepositorySortedSet
    {
        /// <summary>
        /// StackExchange.Redis.SortedSetRangeByValue
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        IList<string> SelectList(string key);

        /// <summary>
        /// SCAN
        /// 
        ///     https://redis.io/commands/scan
        ///     
        /// </summary>
        /// <param name="keyMatch">Wildcard to match partial key, example "AP:201401:*"</param>
        /// <returns></returns>
        IList<string> SelectListOfKeysLike(string keyMatch);

        /// <summary>
        /// StackExchange.Redis.SortedSetRangeByValue
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        List<Tuple<double, string>> SelectListRecordWithScore(string key);

        /// <summary>
        /// StackExchange.Redis.SortedSetAdd
        /// 
        ///     https://redis.io/commands/zadd
        ///     
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Insert(string key, string value);
    }
}
