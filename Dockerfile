# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY ./Common/*.csproj ./Common/
COPY ./IntegrationTests/*.csproj ./IntegrationTests/
COPY ./RedisRepository/*.csproj ./RedisRepository/
COPY ./WebApp/*.csproj ./WebApp/
RUN dotnet restore

# copy everything else and build app
COPY ./Common/. ./Common/
COPY ./IntegrationTests/. ./IntegrationTests/
COPY ./RedisRepository/. ./RedisRepository/
COPY ./WebApp/. ./WebApp/
RUN dotnet publish -c release -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "WebApp.dll"]