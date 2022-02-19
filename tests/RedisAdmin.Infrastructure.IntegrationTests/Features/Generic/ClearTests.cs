using FluentAssertions;
using RedisAdmin.Infrastructure.IntegrationTests.Fixtures;
using System;
using Xunit;

namespace RedisAdmin.Infrastructure.IntegrationTests.Features.Generic
{
    /// <summary>
    /// This test has to be run in isolation as it will cause race conditions
    /// </summary>
    [Collection("CollectionFixture")]
    public class ClearTests : IClassFixture<GenericFixture>
    {
        private readonly CollectionFixture _collectionFixture;
        private readonly GenericFixture _genericFixture;

        public ClearTests(CollectionFixture collectionFixture, GenericFixture genericFixture) 
        {
            _collectionFixture = collectionFixture;
            _genericFixture = genericFixture;
        }

        [Fact]
        public void Clear_GivenDatabaseWithKeys_FlushesAllKeys()
        {
            // Arrange
            var recordsToInsert = 5;
            for (int i = 0; i < recordsToInsert; i++)
            {
                _collectionFixture
                    .RedisRepositoryString
                    .Insert(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
            }
            var expectedLargeKeyCount = _collectionFixture
                .RedisRepositoryGeneric
                .SelectListKeys("*") //keys will lock the database
                .Count;

            // Act
            _collectionFixture
                .RedisRepositoryGeneric
                .Clear();

            var expectedZeroKeyCount = _collectionFixture
                .RedisRepositoryGeneric
                .SelectListKeys("*")
                .Count;

            // Assert
            expectedLargeKeyCount.Should().BeGreaterThan(recordsToInsert); // GenericFixture will add atleast 1 record
            expectedZeroKeyCount.Should().Be(0);
        }
    }
}
