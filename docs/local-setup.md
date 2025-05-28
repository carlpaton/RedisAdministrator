# Local Setup

## Prerequisites
Install the following

1. [.Net SDK 3](https://dotnet.microsoft.com/en-us/download/dotnet/3.0)
1. libman with `dotnet tool install -g Microsoft.Web.LibraryManager.Cli`
1. [docker desktop](https://www.docker.com/products/docker-desktop/)

## Setup
After cloning `cd .\RedisAdministrator\WebApp`

1. run `libman restore` to pull down assets
1. start redis server with `docker run --name red-srv -d -p 6379:6379 redis:4.0.5-alpine redis-server --appendonly yes`
1. run the app with `dotnet run` and browse to http://localhost:5000

## Tests
Currently no unit tests exist 🐒, also dafuc is [MS Test](https://carlpaton.github.io/2018/12/unit-testing-with-mstest/)? 🐒 Dont all the cool kids use [xUnit](https://carlpaton.github.io/2019/06/unit-testing-with-xunit/) ... naa they just put monkeys in their markdown, nobody reads this anyway right?

1. `cd .\IntegrationTests\`
1. run `dotnet test`

## Deploy Docker Registry
This deploys to https://hub.docker.com/

I last did this with an integration from Github to Docker.com but they have since canned this feature and put it behind a paywall, I'll update here after I figure out how to do it.

```
wip high level steps will be

build docker image locally
tag image
login to docker.com registry, however that works
push image
hope it works
```