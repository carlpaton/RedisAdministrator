# Use the SDK image for the build stage
FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build-env
WORKDIR /app

# Copy csproj files and restore as distinct layers
# This leverages Docker's layer caching to speed up builds if only code changes
COPY ./*.sln ./
COPY ./Common/*.csproj ./Common/
COPY ./IntegrationTests/*.csproj ./IntegrationTests/
COPY ./RedisRepository/*.csproj ./RedisRepository/
COPY ./WebApp/*.csproj ./WebApp/
RUN dotnet restore

# Copy everything else and build (publish)
COPY . ./
RUN dotnet publish ./WebApp/WebApp.csproj -c Release -o out

# Unit tests (uncomment if you want to run them during the build)
# RUN dotnet test "./IntegrationTests/IntegrationTests.csproj" -c Release --no-build --no-restore

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0
WORKDIR /app
# Copy the published output from the build-env stage
COPY --from=build-env /app/out ./
ENTRYPOINT ["dotnet", "WebApp.dll"]