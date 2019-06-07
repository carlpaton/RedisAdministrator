FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./*.sln ./
COPY ./Common/*.csproj ./Common/
COPY ./ConsoleApp/*.csproj ./ConsoleApp/
COPY ./RedisRepository/*.csproj ./RedisRepository/
COPY ./WebApp/*.csproj ./WebApp/
RUN dotnet restore

# Copy everything else and build
COPY ./Common/. ./Common/
COPY ./ConsoleApp/. ./ConsoleApp/
COPY ./RedisRepository/. ./RedisRepository/
COPY ./WebApp/. ./WebApp/
RUN dotnet publish -c Release -o out

# Unit tests
#RUN dotnet test "./UnitTest/UnitTest.csproj" -c Release --no-build --no-restore

# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/WebApp/out .
ENTRYPOINT ["dotnet", "WebApp.dll"]