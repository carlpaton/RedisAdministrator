# Redis Administrator

Redis Administrator is an open source application written in C# using the .NET framework. I would love for you to colaborate with me on it and welcome PR’s!

Thank you to [Tomoyuki Tsuda](https://github.com/hoehoetester) for helping me with the UI! Cheers brother!

## Simplest Usage

1. Create a [network](https://docs.docker.com/network/) for the containers to connect to.

```
docker network create --driver bridge redis-bridge-network
```

2. Bring up the [Redis Server](https://hub.docker.com/_/redis?tab=description)

```
docker run --name red-srv -d -p 6379:6379 --network redis-bridge-network redis:4.0.5-alpine redis-server --appendonly yes
```

3. Bring up [Redis Administrator](https://hub.docker.com/r/carlpaton/redis-administrator), this is the user interface.

```
docker run --name red-admin -d -p 8081:80 --network redis-bridge-network --env REDIS_CONNECTION=red-srv,allowAdmin=true  carlpaton/redis-administrator:latest
```

This UI can then be seen at - http://localhost:8081/

## References

* [Source Code](https://github.com/carlpaton/RedisAdministrator)
* [Image on docker hub](https://hub.docker.com/r/carlpaton/redis-administrator)