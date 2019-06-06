# Redis Administrator
Application to help admin a redis instance, while developing I used redis-commander which is an AWESOME piece of software!

# Redis types

* Set
  * Redis Sets are an unordered collection of strings. In Redis, you can add, remove, and test for the existence of members in O(1) time complexity. 
* Sorted Set
  * Redis Sorted Sets are similar to Redis Sets, non-repeating collections of Strings. The difference is, every member of a Sorted Set is associated with a score, that is used in order to take the sorted set ordered, from the smallest to the greatest score. While members are unique, the scores may be repeated.
* String
* List
* Hash
* Stream

## Repository

#### Generic

These live in `RedisRepository`

* Clear
  * StackExchange.Redis.FlushAllDatabases; WARNING!! This will flush all keys on ALL endpoints.
* Delete
  * StackExchange.Redis.KeyDelete
* Exists
  * StackExchange.Redis.KeyExists; Checks if the given key exists.
* Info
* SetTimeToLive
  * StackExchange.Redis.KeyExpire; Set a timeout on key. After the timeout has expired, the key will automatically be deleted. A key with an associated timeout is said to be volatile in Redis terminology.

#### Set Type 

These live in `RedisRepositorySet`

* Insert
  * StackExchange.Redis.StringSet; Set key to hold the string value. If key already holds a value, it is overwritten, regardless of its type.
* Select
  * StackExchange.Redis.StringGet

#### Sorted Set Type

These live in `RedisRepositorySortedSet`

* Insert
  * StackExchange.Redis.SortedSetAdd; https://redis.io/commands/zadd
* SelectList
  * StackExchange.Redis.SortedSetRangeByValue
* SelectListOfKeysLike
  * SCAN; https://redis.io/commands/scan
* SelectListRecordWithScore
  * StackExchange.Redis.SortedSetAdd; https://redis.io/commands/zadd



## ConsoleApp

Pretty much an integration test harness (without the asserts) to test `RedisRepository`

# References

## Types

* https://www.tutorialspoint.com/redis/redis_data_types.htm

## Scan / Keys

* https://www.shellhacks.com/redis-get-all-keys-redis-cli/
* https://github.com/StackExchange/StackExchange.Redis/issues/763
* https://stackexchange.github.io/StackExchange.Redis/KeysScan

## Other 

* https://carlpaton.github.io/2019/05/02/redis/
* https://github.com/joeferner/redis-commander
* https://stackexchange.github.io/StackExchange.Redis/
* https://github.com/StackExchange/StackExchange.Redis/
* https://stackoverflow.com/questions/24531421/remove-delete-all-one-item-from-stackexchange-redis-cache/24609851
* https://stackoverflow.com/questions/21795340/linux-install-redis-cli-only
