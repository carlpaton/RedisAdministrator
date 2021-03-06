# Redis Administrator
Open source C# Web Application to help Admin and understand a [Redis](https://redis.io/) database.

## Credit

* Developers
  * [Carl Paton](https://www.linkedin.com/in/carl-paton/)
  * [Tomoyuki Tsuda](https://github.com/hoehoetester)

While trying to understand how Redis works I used the [Redis CLI](https://redis.io/topics/rediscli) and [redis-commander](https://www.npmjs.com/package/redis-commander) which is an AWESOME piece of software!


## Example Docker Image Usage

1. Create your own bridge network

   ```
   docker network create --driver bridge redis-bridge-network
   ```

2. Spin up a `redis server` if you don't have one

   ```
   docker run --name red-srv -d -p 6379:6379 --network redis-bridge-network redis:4.0.5-alpine redis-server --appendonly yes
   ```

3. Spin up `redis administrator` and pass the environment setting to tell it which redis server to connect to. If not set it will default to `localhost:6379,allowAdmin=true` 

   ```
   docker run --name red-admin -d -p 8080:80 --network redis-bridge-network --env REDIS_CONNECTION=red-srv,allowAdmin=true  carlpaton/redis-administrator:latest
   ```

4. Access from http://localhost:8080

5. Cleanup

   ```
   docker kill red-srv
   docker rm red-srv
   docker kill red-admin
   docker rm red-admin
   docker network rm redis-bridge-network
   ```

* Also see <https://hub.docker.com/r/carlpaton/redis-administrator>

# Redis types

https://redis.io/topics/data-types

* String
  * Strings are the most basic kind of Redis value. Redis Strings are binary safe, this means that a Redis string can contain any kind of data, for instance a JPEG image or a serialized Ruby object.
* Sorted Set
  * Redis Sorted Sets are similar to Redis Sets, non-repeating collections of Strings. The difference is, every member of a Sorted Set is associated with a score, that is used in order to take the sorted set ordered, from the smallest to the greatest score. While members are unique, the scores may be repeated.

In the `Redis Administrator` code base the following types have not as yet been touched/used.

* Set
  * Redis Sets are an unordered collection of strings. In Redis, you can add, remove, and test for the existence of members in O(1) time complexity. 
* List
* Hash
* Stream

# Source Code

These are the projects inside the `RedisAdministrator` solution.

## WebApp

.Net Core MVC web application, that's quite a mouthful!

## Repository

#### Generic

These live in `RedisRepository`

> Clear

StackExchange.Redis.FlushAllDatabases; WARNING!! This will flush all keys on ALL endpoints.

> Delete

StackExchange.Redis.KeyDelete; Delete by key; https://redis.io/commands/del

> Exists

StackExchange.Redis.KeyExists; Checks if the given key exists. https://redis.io/commands/exists

> Info

INFO; https://redis.io/commands/INFO

> SetTimeToLive

StackExchange.Redis.KeyExpire; Set a timeout on key. After the timeout has expired, the key will automatically be deleted. A key with an associated timeout is said to be volatile in Redis terminology; https://redis.io/commands/expire

> SelectListScan

SCAN; https://redis.io/commands/scan

> SelectListKeys

Warning: consider KEYS as a command that should only be used in production environments with extreme care.
StackExchange.Redis.Keys; https://redis.io/commands/keys

> GetType

Returns the Redis database type for the given key.
https://redis.io/commands/type

#### String Type 

These live in `RedisRepositoryString`

> Insert

StackExchange.Redis.StringSet; Set key to hold the string value. If key already holds a value, it is overwritten, regardless of its type. https://redis.io/commands/set

> Select

StackExchange.Redis.StringGet; https://redis.io/commands/get

#### Set Type 

These live in `RedisRepositorySet`

> Insert

StackExchange.Redis.?; https://redis.io/commands/sadd

> Select

?

#### Sorted Set Type

These live in `RedisRepositorySortedSet`

> Insert

StackExchange.Redis.SortedSetAdd; https://redis.io/commands/zadd

> SelectList

StackExchange.Redis.SortedSetRangeByValue

> SelectListRecordWithScore

StackExchange.Redis.SortedSetRangeByRankWithScores; https://redis.io/commands/zadd

## IntegrationTests

Tests that were used during the repository development, true integration tests as they will indeed hit the supplied database.

## UnitTests

These are specified in the docker image build:

`RUN dotnet test "./UnitTest/UnitTest.csproj" -c Release --no-build --no-restore`

* https://github.com/carlpaton/RedisAdministrator/blob/master/Dockerfile

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
