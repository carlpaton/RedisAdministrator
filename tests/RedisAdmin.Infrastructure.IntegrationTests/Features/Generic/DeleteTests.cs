using FluentAssertions;
using RedisAdmin.Application.Common.Interfaces;
using RedisAdmin.Infrastructure.IntegrationTests.Fixtures;
using System;
using Xunit;

namespace RedisAdmin.Infrastructure.IntegrationTests.Features.Generic
{
    [Collection("CollectionFixture")]
    public class DeleteTests
    {
        private readonly IRedisRepositoryGeneric _redisRepositoryGeneric;
        private readonly IRedisRepositoryString _redisRepositoryString;

        public DeleteTests(CollectionFixture collectionFixture)
        {
            _redisRepositoryGeneric = collectionFixture.RedisRepositoryGeneric;
            _redisRepositoryString = collectionFixture.RedisRepositoryString;
        }

        [Fact]
        public void Delete_GivenAKeyThatExists_ShouldDeleteIt()
        {
            // Arrange
            var newKey = Guid.NewGuid().ToString();

            // Act
            var actualInitialExistance = _redisRepositoryGeneric.Exists(newKey);

            _redisRepositoryString.Insert(newKey, Guid.NewGuid().ToString());
            var actualPostInsertExistance = _redisRepositoryGeneric.Exists(newKey);

            _redisRepositoryGeneric.Delete(newKey);
            var actualPostDeleteExistance = _redisRepositoryGeneric.Exists(newKey);

            // Assert
            actualInitialExistance.Should().Be(false);
            actualPostInsertExistance.Should().Be(true);
            actualPostDeleteExistance.Should().Be(false);
        }
    }
}
