# Redis Administrator

[CHANGELOG](CHANGELOG.md)

Open source C# Web Application to help Admin and understand a [Redis](https://redis.io/) database.

## Getting started
Using the [docker image](https://hub.docker.com/r/carlpaton/redis-administrator/)

1. create a bridge `docker network create --driver bridge redis-bridge-network`
1. start redis server with `docker run --name red-srv -d -p 6379:6379 --network redis-bridge-network redis:4.0.5-alpine redis-server --appendonly yes`
1. start redis admin with `docker run --name red-admin -d -p 8081:80 --network redis-bridge-network --env Database__ConnectionString=red-srv,allowAdmin=true carlpaton/redis-administrator:latest`
1. browse to http://localhost:8081

Optional debugging
```
docker run --name red-admin -d -p 8081:80 --env Database__ConnectionString=red-srv,allowAdmin=true --env ASPNETCORE_ENVIRONMENT=Development carlpaton/redis-administrator:latest
```

## Contributing

Pull requests welcome, see [contributing](CONTRIBUTING.md) guidelines.

- [Local Setup](./docs/local-setup.md)
- [Redis Types](https://carlpaton.github.io/2022/02/redis-types/)

## Developers

- [Carl Paton](https://www.linkedin.com/in/carl-paton/)
- [Tomoyuki Tsuda](https://github.com/hoehoetester)