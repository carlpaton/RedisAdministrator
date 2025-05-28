# Redis Administrator
Open source C# Web Application to help Admin and understand a [Redis](https://redis.io/) database.

## Getting started
Using the [docker image](https://hub.docker.com/r/carlpaton/redis-administrator/)

1. (optional) start redis server, see [Local Setup](./docs/local-setup.md) for details.
1. `docker run --name red-admin -d -p 8081:80 --env REDIS_CONNECTION=red-srv,allowAdmin=true  carlpaton/redis-administrator:latest`
1. browse to http://localhost:8081

## Contributing

Pull requests welcome!

- [Local Setup](./docs/local-setup.md)

## Developers

- [Carl Paton](https://www.linkedin.com/in/carl-paton/)
- [Tomoyuki Tsuda](https://github.com/hoehoetester)