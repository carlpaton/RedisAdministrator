using FluentAssertions;
using RedisAdmin.Application.Common.Interfaces;
using RedisAdmin.Infrastructure.IntegrationTests.Fixtures;
using System;
using Xunit;

namespace RedisAdmin.Infrastructure.IntegrationTests.Features.Generic
{
    [Collection("CollectionFixture")]
    public class ClearTests
    {
        private readonly IRedisRepositoryGeneric _redisRepositoryGeneric;
        private readonly IRedisRepositoryString _redisRepositoryString;

        public ClearTests(CollectionFixture collectionFixture) 
        {
            _redisRepositoryGeneric = collectionFixture.RedisRepositoryGenericForClearTests;
            _redisRepositoryString = collectionFixture.RedisRepositoryStringForClearTests;
        }

        [Fact]
        public void Clear_GivenDatabaseWithKeys_FlushesAllKeys()
        {
            // Arrange
            var recordsToInsert = 5;
            var searchOnAll = "*";

            for (int i = 1; i < recordsToInsert; i++)
            {
                _redisRepositoryString
                    .Insert(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
            }

            var expectedLargeKeyCount = _redisRepositoryGeneric
                .SelectListKeys(searchOnAll) //keys will lock the database
                .Count;

            // Act
            _redisRepositoryGeneric
                .Clear();

            var expectedZeroKeyCount = _redisRepositoryGeneric
                .SelectListKeys(searchOnAll)
                .Count;

            // Assert
            expectedLargeKeyCount.Should().Be(recordsToInsert);
            expectedZeroKeyCount.Should().Be(0);
        }
    }
}
