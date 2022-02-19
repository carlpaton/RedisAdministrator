using System;
using System.Threading.Tasks;
using Xunit;

namespace RedisAdmin.Infrastructure.IntegrationTests.Fixtures
{
    /// <summary>
    /// Used to share context between tests (the tests in the class)
    /// For usage inherit/implement IClassFixture<GenericFixture> in the ctor pass `GenericFixture genericFixture`
    /// </summary>
    public class GenericFixture : IAsyncLifetime
    {
        private readonly CollectionFixture _collectionFixture;

        public GenericFixture(CollectionFixture collectionFixture)
        {
            _collectionFixture = collectionFixture;
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }

        public Task InitializeAsync()
        {
            var testKey = _collectionFixture
                .GenericOptions
                .TestKey;

            _collectionFixture
                .RedisRepositoryString
                .Insert(testKey, Guid.NewGuid().ToString());

            return Task.CompletedTask;
        }
    }
}
