using Microsoft.Extensions.Configuration;
using RedisAdmin.Application.Common.Interfaces;
using RedisAdmin.Infrastructure.IntegrationTests.Common;
using RedisAdmin.Infrastructure.Persistence;
using System.Threading.Tasks;
using Xunit;

namespace RedisAdmin.Infrastructure.IntegrationTests.Fixtures
{
    /// <summary>
    /// Used to share context between tests (in several test classes)
    /// For usage decorated the test class with [Collection("CollectionFixture")] and in the ctor pass `CollectionFixture collectionFixture`
    /// </summary>
    public class CollectionFixture : IAsyncLifetime
    {
        private readonly RedisServerOptions _redisServerOptions;
        private readonly GenericOptions _genericOptions;

        private IRedisRepositoryGeneric _redisRepository;
        private IRedisRepositoryString _redisRepositoryString;
        private IRedisRepositorySortedSet _redisRepositorySortedSet;

        public CollectionFixture()
        {
            var appSettings = "appsettings.json";

            var configuration = new ConfigurationBuilder()
                .AddJsonFile(appSettings)
                .Build();

            _redisServerOptions = configuration
                .GetSection(RedisServerOptions.RedisServer)
                .Get<RedisServerOptions>();

            _genericOptions = configuration
                .GetSection(GenericOptions.Generic)
                .Get<GenericOptions>();
        }

        public IRedisRepositoryGeneric RedisRepositoryGeneric
        {
            get
            {
                if (_redisRepository != null)
                    return _redisRepository;

                _redisRepository = new RedisRepositoryGeneric(_redisServerOptions.ConnectionString);
                return _redisRepository;
            }
        }

        public IRedisRepositoryString RedisRepositoryString
        {
            get
            {
                if (_redisRepositoryString != null)
                    return _redisRepositoryString;

                _redisRepositoryString = new RedisRepositoryString(_redisServerOptions.ConnectionString);
                return _redisRepositoryString;
            }
        }

        public IRedisRepositorySortedSet RedisRepositorySortedSet
        {
            get
            {
                if (_redisRepositorySortedSet != null)
                    return _redisRepositorySortedSet;

                _redisRepositorySortedSet = new RedisRepositorySortedSet(_redisServerOptions.ConnectionString);
                return _redisRepositorySortedSet;
            }
        }

        /// <summary>
        /// Generic options for RedisRepositoryGeneric
        /// </summary>
        public GenericOptions GenericOptions
        {
            get
            {
                return _genericOptions;
            }
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }

        public Task InitializeAsync()
        {
            return Task.CompletedTask;
        }
    }

    [CollectionDefinition("CollectionFixture")]
    public class SharedCollectionFixture : ICollectionFixture<CollectionFixture>
    {
        // https://xunit.net/docs/shared-context
    }
}
