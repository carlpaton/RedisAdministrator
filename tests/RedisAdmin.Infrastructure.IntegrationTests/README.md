# Running Integration Tests

Before running tests the following infastructure is required

```
docker network create --driver bridge redis-bridge-network

docker run --name red-srv -d -p 6379:6379 --network redis-bridge-network redis:4.0.5-alpine redis-server --appendonly yes

docker run --name red-srv-clear-tests -d -p 6380:6379 --network redis-bridge-network redis:4.0.5-alpine redis-server --appendonly yes
```

You can then also use the application UI to verify some results

```
docker run --name red-admin -d -p 8081:80 --network redis-bridge-network --env REDIS_CONNECTION=red-srv,allowAdmin=true  carlpaton/redis-administrator:latest
```