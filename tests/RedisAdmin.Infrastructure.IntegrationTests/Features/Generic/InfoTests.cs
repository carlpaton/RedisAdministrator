using FluentAssertions;
using RedisAdmin.Application.Common.Interfaces;
using RedisAdmin.Domain.Enums;
using RedisAdmin.Infrastructure.IntegrationTests.Fixtures;
using Xunit;

namespace RedisAdmin.Infrastructure.IntegrationTests.Features.Generic
{
    [Collection("CollectionFixture")]
    public class InfoTests : IClassFixture<GenericFixture>
    {
        private readonly IRedisRepositoryGeneric _redisRepositoryGeneric;

        public InfoTests(CollectionFixture collectionFixture, GenericFixture genericFixture)
        {
            _redisRepositoryGeneric = collectionFixture.RedisRepositoryGeneric;
        }

        [Fact]
        public void Info_GivenNoInfoFilterAndServerIsRunning_ShouldReturnLargeDataResponse()
        {
            // Act
            var actualAllInfo = _redisRepositoryGeneric.Info();

            // Assert
            Assert.True(actualAllInfo.Length > 1000);
            actualAllInfo.Should().StartWith("# Server");
        }

        [Fact]
        public void Info_GivenKeyspaceInfoFilter_ShouldReturnFilteredResult()
        {
            // Arrange
            var filterByKeyspace = Information.Info.Keyspace;

            // Act
            var actualFiltered = _redisRepositoryGeneric.Info(filterByKeyspace);

            // Assert
            actualFiltered.Should().StartWith("# Keyspace");
        }
    }
}
