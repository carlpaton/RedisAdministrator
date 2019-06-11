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
        /// StackExchange.Redis.SortedSetRangeByRankWithScores
        /// 
        ///     https://redis.io/commands/zrange
        /// 
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

        /// <summary>
        /// StackExchange.Redis.SortedSetScore
        /// 
        ///     Returns the score of member in the sorted set at key. If member does not exist in the sorted set, or key does not exist, nil is returned.
        ///     https://redis.io/commands/zscore
        ///     
        /// </summary>
        /// <param name="key"></param>
        /// <param name="member"></param>
        /// <returns></returns>
        double? SelectScore(string key, string member);
    }
}
