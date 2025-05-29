# Local Setup

## Prerequisites
Install the following

1. [.Net SDK 3](https://dotnet.microsoft.com/en-us/download/dotnet/3.0)
1. libman with `dotnet tool install -g Microsoft.Web.LibraryManager.Cli`
1. [docker desktop](https://www.docker.com/products/docker-desktop/)

## Setup
After cloning `cd .\RedisAdministrator\WebApp`

1. run `libman restore` to pull down assets
1. create a bridge `docker network create --driver bridge redis-bridge-network`, this is not needed for the when you run the app from source but its useful when you use the same server with images pulled from docker hub or when you test with local images built from source
1. start redis server with `docker run --name red-srv -d -p 6379:6379 --network redis-bridge-network redis:4.0.5-alpine redis-server --appendonly yes`
1. run the app with `dotnet run` and browse to http://localhost:5000

## Tests
Currently no unit tests exist 🐒, also dafuc is [MS Test](https://carlpaton.github.io/2018/12/unit-testing-with-mstest/)? 🐒 Dont all the cool kids use [xUnit](https://carlpaton.github.io/2019/06/unit-testing-with-xunit/) ... naa they just put monkeys in their markdown, nobody reads this anyway right?

1. `cd .\IntegrationTests\`
1. run `dotnet test`

## Deploy Docker Registry
This deploys to https://hub.docker.com/

I last did this with an integration from Github to Docker.com but they have since canned this feature and put it behind a paywall, I'll update here after I figure out how to do it.

1. build image with `docker build -t redis-administrator:dev .`
1. run it locally as `docker run --name red-admin-dev -d -p 8082:80 --network redis-bridge-network --env REDIS_CONNECTION=red-srv,allowAdmin=true redis-administrator:dev`
1. browse to http://localhost:8082

Now actually deploy

1. `docker login`, one time device confirmation opens docker.com for you to confirm 
1. tag the image `docker tag redis-administrator:dev carlpaton/redis-administrator:dev`
1. now push `docker push carlpaton/redis-administrator:dev`
1. browse and check the tag exists at https://hub.docker.com/r/carlpaton/redis-administrator/

Test the deployed image

1. locally as `docker run --name red-admin-deploy -d -p 8083:80 --network redis-bridge-network --env REDIS_CONNECTION=red-srv,allowAdmin=true carlpaton/redis-administrator:dev`