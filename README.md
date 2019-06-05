# Redis Administrator
Application to help admin a redis instance, while developing I used redis-commander which is an AWESOME piece of software!

## RedisRepository

* Exists
Checks if the given key exists.

* Insert
Inserts the give key, value.

* Select
Selects the given key.

* Update
Updates the given key, value and orders on score using `SortedSetAdd`. https://redis.io/commands/zadd

* Clear
Flush all databases on the instance.

* SetTTL
hoe?

## ConsoleApp

Pretty much an integration test harness (without the asserts) to test `RedisRepository`

# References

* https://carlpaton.github.io/2019/05/02/redis/
* https://github.com/joeferner/redis-commander
* https://stackexchange.github.io/StackExchange.Redis/
* https://github.com/StackExchange/StackExchange.Redis/
* https://stackoverflow.com/questions/24531421/remove-delete-all-one-item-from-stackexchange-redis-cache/24609851
